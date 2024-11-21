namespace BPMSoft.Configuration
{
	using Polly;
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: BulkEmailTargetArchiveJobExecutor

	public class BulkEmailTargetArchiveJobExecutor : IJobExecutor
	{

		#region Constants: Private

		private const string ArchivingTableName = "archivingTableName";
		private const string BetFirstTableName = "BETArchiveFirstGeneration";
		private const string BetSecondTableName = "BETArchiveSecondGeneration";
		private const string BetTableName = "BulkEmailTarget";
		private const string DbExecutor = "dbExecutor";
		private const string RecordsToProcessCount = "recordsToProcessCount";
		private const string ArchiveDate = "archiveDate";
		private const int RetryCount = 3;

		#endregion

		#region Fields: Private

		private BulkEmailTargetArchiver _dataArchiver;
		private int _firstPeriodNumberOfDays;
		private int _iterationSize;
		private Policy _policy;
		private Context _retryContext;
		private int _secondPeriodNumberOfDays;
		private UserConnection _userConnection;

		#endregion

		#region Methods: Private

		private static void OnRetry(Context context, int retryIteration, Exception exception) {
			(context[DbExecutor] as DBExecutor)?.RollbackTransaction();
			MailingUtilities.Log.WarnFormat(
				"[BulkEmailTargetArchiver.DeleteArchiveLevel. Error while archiving BulkEmailTarget. Rollback transaction. " +
				$"RecordsToProcess: {context[RecordsToProcessCount]} " +
				$"Archiving table name: {context[ArchivingTableName]} " + $"Iteration: {retryIteration}.", exception);
		}

		private void Archive() {
			ArchiveLevelSafe(BetTableName, BetFirstTableName, _firstPeriodNumberOfDays);
			ArchiveLevelSafe(BetFirstTableName, BetSecondTableName, _secondPeriodNumberOfDays);
		}

		private void ArchiveLevelSafe(string sourceTableName, string targetTableName, int archivingPeriod) {
			PrepareRetryContext(sourceTableName, archivingPeriod);
			_policy.Execute(() => TransferArchiveLevel(sourceTableName, targetTableName),
				_retryContext);
		}

		private void InitializeArchiving() {
			_policy = Policy.Handle<Exception>()
				.Retry(RetryCount, (exception, retryIteration, context) => OnRetry(context, retryIteration, exception));
			_iterationSize = CoreSysSettings.GetValue(_userConnection, "BETArchivingIterationSize", 10000);
			_firstPeriodNumberOfDays =
				CoreSysSettings.GetValue(_userConnection, "BETArchiveFirstGenerationPeriod", 365);
			_secondPeriodNumberOfDays =
				CoreSysSettings.GetValue(_userConnection, "BETArchiveSecondGenerationPeriod", 455);
		}

		private void PrepareRetryContext(string schemaName, int periodDays) {
			var archiveDate = DateTime.Today.AddDays(-periodDays);
			_retryContext = new Context("bulkEmailTargetArchivePolicy", new Dictionary<string, object> {
				{ ArchivingTableName, schemaName },
				{ RecordsToProcessCount,  _iterationSize} ,
				{ ArchiveDate, archiveDate }
			});
		}

		private void TransferArchiveLevel(string sourceSchemaName, string targetSchemaName) {
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				_retryContext[DbExecutor] = dbExecutor;
				_dataArchiver = new BulkEmailTargetArchiver(dbExecutor);
				DateTime archiveDate = (DateTime)_retryContext[ArchiveDate];
				int processedRecords;
				do {
					dbExecutor.StartTransaction();
					processedRecords = _dataArchiver.Archive(sourceSchemaName, targetSchemaName, archiveDate);
					dbExecutor.CommitTransaction();
					_retryContext[RecordsToProcessCount] = (int)_retryContext[RecordsToProcessCount] - processedRecords;
				} while((int)_retryContext[RecordsToProcessCount] > 0 && processedRecords > 0);
			}
		}

		#endregion

		#region Methods: Public

		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			InitializeArchiving();
			Archive();
		}

		#endregion

	}

	#endregion

}

