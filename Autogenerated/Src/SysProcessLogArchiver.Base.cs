namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;
	using System.Linq;

	#region Interface: IEntityArchiver

	public interface IEntityArchiver
	{

		/// <summary>
		/// Archieves entity records.
		/// </summary>
		void Archive();

	}

	#endregion

	#region Class: SysProcessLogArchiver

	public class SysProcessLogArchiver : IEntityArchiver
	{

		#region Constants: Private

		private const string HistoryPeriodSysSettingCode = "ProcessLogArchivingPeriod";
		private const int DefaultHistoryPeriodDays = 30;
		private const string ProcessLogArchivingRecordsCount = "ProcessLogArchivingRecordsCount";
		private const int DefaultArchivingRecordsCount = 500;
		private const string LogBuffer = "SysPrcHistoryLogBuffer";
		private const string SysProcessLog = "SysProcessLog";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly DBExecutor _dbExecutor;
		private readonly Dictionary<string, string> _archiveSchemaMap;

		#endregion

		#region Constructors: Public

		public SysProcessLogArchiver(DBExecutor dbExecutor) {
			_dbExecutor = dbExecutor;
			_userConnection = _dbExecutor.UserConnection;
			_archiveSchemaMap = new Dictionary<string, string> {
				{ "SysProcessLog", "SysPrcHistoryLog" },
				{ "SysProcessEntity", "SysPrcEntityHistory" },
				{ "SysProcessElementLog", "SysPrcElHistoryLog" }
			};
		}

		#endregion

		#region Methods: Private

		private void Bufferize() {
			Query selectQuery = GetHistorizeCollectionQuery(GetProcessLogArchivingCount(), GetArchivationStartDate());
			IDBCommand insertSelect = new InsertSelect(_userConnection)
				.Into(LogBuffer)
				.Set("SysProcessLogId", "SessionId")
				.FromSelect(selectQuery);
			insertSelect.Execute(_dbExecutor);
		}

		private void HistorizeSchema(string schemaName) {
			var insertSelectCommand = 
				GetArchiveQuery(schemaName, _archiveSchemaMap[schemaName], GetSchemaColumnsNames(schemaName));
			insertSelectCommand.Execute(_dbExecutor);
		}

		private void ClearSysProcessLog() {
			var columnSelect = new List<string>() { "Id" };
			var deleteQuery = 
				new Delete(_userConnection)
				.From(SysProcessLog)
				.Where(SysProcessLog, "Id").In(GetArchiveFromQuery(SysProcessLog, columnSelect));
			deleteQuery.Execute(_dbExecutor);
		}

		private Select GetArchiveFromQuery(string schemaName, IList<string> columnList) {
			var selectQuery = new Select(_userConnection);
			foreach (string column in columnList) {
				selectQuery.Column(schemaName, column);
			}
			selectQuery.From(schemaName).As(schemaName).WithHints(Hints.NoLock);
			var keyColumnId = schemaName == SysProcessLog ? "Id" : "SysProcessId";
			selectQuery.Join(JoinType.Inner, LogBuffer).WithHints(Hints.NoLock)
				.On(LogBuffer, "SysProcessLogId").IsEqual(schemaName, keyColumnId)
				.Where(LogBuffer, "SessionId").IsEqual(Column.Parameter(_userConnection.SessionId));
			return selectQuery;
		}

		private void ClearBuffer() {
			Query deleteQuery = GetClearBufferQuery();
			deleteQuery.Execute(_dbExecutor);
		}

		private int GetProcessLogArchivingCount() {
			return BPMSoft.Core.Configuration.SysSettings
				.GetValue(_userConnection, ProcessLogArchivingRecordsCount, DefaultArchivingRecordsCount);
		}

		private List<string> GetSchemaColumnsNames(string schemaFrom) {
			var schema = GetEntitySchema(schemaFrom);
			var columnList = schema.Columns.Select(col => col.ColumnValueName).ToList();
			return columnList;
		}

		private DateTime GetArchivationStartDate() {
			int archievationPeriod = GetProcessLogArchivingPeriod();
			return DateTime.UtcNow.AddDays(-archievationPeriod);
		}

		private int GetProcessLogArchivingPeriod() {
			return BPMSoft.Core.Configuration.SysSettings
				.GetValue(_userConnection, HistoryPeriodSysSettingCode, DefaultHistoryPeriodDays);
		}

		private EntitySchema GetEntitySchema(string schemaName) {
			EntitySchemaManager manager = _userConnection.AppConnection.SystemUserConnection.EntitySchemaManager;
			return manager.GetInstanceByName(schemaName);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns Delete query to clear buffer table;
		/// </summary>
		/// <returns></returns>
		public Query GetClearBufferQuery() {
			return new Delete(_userConnection)
				.From(LogBuffer)
				.Where(LogBuffer, "SessionId").IsEqual(Column.Parameter(_userConnection.SessionId));
		}

		/// <summary>
		/// Returns Insert query to archive specified schema.
		/// </summary>
		/// <param name="schemaFrom">Schema to archive from</param>
		/// <param name="schemaTo">Archive strorage schema</param>
		/// <returns>InsertSelect</returns>
		public InsertSelect GetArchiveQuery(string schemaFrom, string schemaTo, IList<string> columnList) {
			return new InsertSelect(_userConnection)
				.Into(schemaTo)
				.Set(columnList)
				.FromSelect(GetArchiveFromQuery(schemaFrom, columnList));
		}

		/// <summary>
		/// Returns process log items selection query to historize.
		/// </summary>
		/// <returns>Query</returns>
		public Query GetHistorizeCollectionQuery(int archivingCount, DateTime startDate) {
			var statusId = new QueryParameter(new Guid("ED2AE277-B6E2-DF11-971B-001D60E938C6"));
			var selectQuery =
				new Select(_userConnection).Top(archivingCount)
					.Column("ProcessLog", "Id")
					.Column(Column.Parameter(_userConnection.SessionId)).As("SessionId")
				.From(SysProcessLog).As("ProcessLog").WithHints(Hints.NoLock)
				.LeftOuterJoin(SysProcessLog).As("ParentProcessLog").WithHints(Hints.NoLock)
					.On("ParentProcessLog", "Id").IsEqual("ProcessLog", "ParentId")
				.Where("ProcessLog", "StatusId").IsNotEqual(statusId)
					.And("ProcessLog", "CompleteDate").IsLessOrEqual(new QueryParameter(startDate))
					.And("ParentProcessLog", "Id").IsNull();
			return selectQuery;
		}

		public void Archive() {
			try {
				_dbExecutor.StartTransaction();
				Bufferize();
				HistorizeSchema(SysProcessLog);
				HistorizeSchema("SysProcessElementLog");
				HistorizeSchema("SysProcessEntity");
				ClearSysProcessLog();
				ClearBuffer();
				_dbExecutor.CommitTransaction();
			} catch (Exception exception) {
				_dbExecutor.RollbackTransaction();
				throw exception;
			}
		}

		#endregion

	}

	#endregion
}
