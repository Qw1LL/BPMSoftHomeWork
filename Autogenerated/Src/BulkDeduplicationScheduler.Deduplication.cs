namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using Quartz;
	using Quartz.Impl.Triggers;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;

	#region Class: _BulkDeduplicationSearchScheduler

	/// <summary>
	/// Default implementation of the <see cref="IBulkDeduplicationScheduler"/> interface.
	/// </summary>
	[DefaultBinding(typeof(IBulkDeduplicationScheduler))]
	public class BulkDeduplicationScheduler : IBulkDeduplicationScheduler
	{
		#region Constants: Private

		private const string ScheduledSearchDuplicatesJobGroup = "BulkDeduplication";

		private const string ScheduledSearchDuplicatesJobNamePattern = "{0}ScheduledSearchDuplicates";

		private const string ScheduledSearchDuplicatesJobProcessName = "BulkDuplicatesSearchProcess";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public BulkDeduplicationScheduler(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private static string GetSearchJobName(string schemaName) {
			return string.Format(ScheduledSearchDuplicatesJobNamePattern, schemaName);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IBulkDeduplicationScheduler.ScheduleSearchJob"/>
		public void ScheduleSearchJob(DuplicatesScheduledSearchParameter duplicatesScheduledSearchParameter) {
			var schemaName = duplicatesScheduledSearchParameter.SearchSchemaName;
			var cronExpression = duplicatesScheduledSearchParameter.GetCronExpression();
			var jobName = string.Format(ScheduledSearchDuplicatesJobNamePattern, schemaName);
			var jobParameters = new Dictionary<string, object> {
				{ "SchemaName", schemaName },
			};
			var jobDetail = AppScheduler.CreateProcessJob(
				jobName,
				ScheduledSearchDuplicatesJobGroup,
				ScheduledSearchDuplicatesJobProcessName,
				_userConnection.Workspace.Name,
				_userConnection.CurrentUser.Name,
				jobParameters);
			var cronTrigger = new CronTriggerImpl {
				Name = jobName,
				Group = ScheduledSearchDuplicatesJobGroup,
				TimeZone = TimeZoneInfo.Utc,
				CronExpression = new CronExpression(cronExpression),
				MisfireInstruction = MisfireInstruction.CronTrigger.DoNothing
			};
			AppScheduler.Instance.ScheduleJob(jobDetail, cronTrigger);
		}

		/// <inheritdoc cref="IBulkDeduplicationScheduler.DeleteSearchJob"/>
		public void DeleteSearchJob(string schemaName) {
			AppScheduler.RemoveJob(GetSearchJobName(schemaName), ScheduledSearchDuplicatesJobGroup);
		}

		#endregion

	}

	#endregion
}

