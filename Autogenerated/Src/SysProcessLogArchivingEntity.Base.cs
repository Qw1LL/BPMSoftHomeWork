namespace BPMSoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;
	using System.Linq;
	using BPMSoft.Core.Process.Configuration;

	[Obsolete("7.12.2 | Class is obsolete and will be removed in upcoming releases")]
	#region Class: SysProcessLogArchivingEntity

	public class SysProcessLogArchivingEntity : IArchivingEntity
	{

		#region Constants: Private

		private const string HistoryPeriodSysSettingCode = "ProcessLogArchivingPeriod";
		private const int DefaultHistoryPeriodDays = 30;
		private const string ProcessLogArchivingRecordsCount = "ProcessLogArchivingRecordsCount";
		private const int DefaultArchivingRecordsCount = 500;

		#endregion

		#region Fields: Private

		private IList<string> _columnNames;

		#endregion

		#region Constructors: Public

		public SysProcessLogArchivingEntity(UserConnection userConnection,
				string schemaName, string historySchemaName) {
			UserConnection = userConnection;
			SchemaName = schemaName;
			HistorySchemaName = historySchemaName;
		}

		#endregion

		#region Custom: IArchivingEntity Members

		/// <summary>
		/// User connection.
		/// </summary>
		public UserConnection UserConnection {
			get;
			set;
		}

		/// <summary>
		/// Schema name.
		/// </summary>
		public string SchemaName {
			get;
			set;
		}

		/// <summary>
		/// History schema name.
		/// </summary>
		public string HistorySchemaName {
			get;
			set;
		}

		/// <summary>
		/// Column names.
		/// </summary>
		public IList<string> ColumnNames {
			get {
				if (_columnNames == null) {
					var schema = GetEntitySchema();
					_columnNames = schema.Columns.Select(col => col.ColumnValueName).ToList();
				}
				return _columnNames;
			}
			set {
				_columnNames = value;
			}
		}

		/// <summary>
		/// Insert archiving data command.
		/// </summary>
		public IDBCommand InsertSelectCommand {
			get {
				return GetArchivingInsertSelectQuery();
			}
		}

		/// <summary>
		/// Delete archiving data command.
		/// </summary>
		public IDBCommand DeleteCommand {
			get {
				return GetArchivingDeleteQuery();
			}
		}

		/// <summary>
		/// Indicates this schema is referenced schema.
		/// </summary>
		public virtual bool GetIsReferencedSchema() {
			return true;
		}

		#endregion

		#region Methods: Private

		private Select GetSelectFromQuery() {
			var select = new Select(UserConnection).WithHints(Hints.NoLock);
			foreach (string column in ColumnNames) {
				select.Column(SchemaName, column);
			}
			select.From(SchemaName).As(SchemaName);
			return select;
		}

		private Query GetArchivedRecordsQuery() {
			var query = new Select(UserConnection)
				.WithHints(Hints.NoLock)
				.Column(SchemaName, "Id")
				.From(SchemaName);
			AddDeleteArchivingQueryFilters(query);
			return query;
		}

		private DateTime GetArchivationStartDate() {
			int archievationPeriod = GetProcessLogArchivingPeriod();
			return DateTime.UtcNow.AddDays(-archievationPeriod);
		}

		private InsertSelect GetInsertToQuery(Select selectQuery) {
			var insertSelect = new InsertSelect(UserConnection)
				.Into(HistorySchemaName)
				.Set(ColumnNames)
				.FromSelect(selectQuery);
			insertSelect.InitializeParameters();
			insertSelect.BuildParametersAsValue = true;
			return insertSelect;
		}

		#endregion

		#region Methods: Protected

		protected InsertSelect GetArchivingInsertSelectQuery() {
			Select selectQuery = GetSelectFromQuery();
			AddArchivingQueryFilters(selectQuery);
			return GetInsertToQuery(selectQuery);
		}

		protected Delete GetArchivingDeleteQuery() {
			var deleteQuery = new Delete(UserConnection).From(SchemaName);
			deleteQuery.Where(SchemaName, "Id").In(GetArchivedRecordsQuery());
			return deleteQuery;
		}

		protected void AddBaseArchivingQueryFilters(Query query, string schemaName) {
			var startDate = new QueryParameter(GetArchivationStartDate());
			var statusId = new QueryParameter(new Guid("815C9586-B6E2-DF11-971B-001D60E938C6"));
			query.Where(schemaName, "StatusId").IsEqual(statusId)
				.And(schemaName, "CompleteDate").IsLessOrEqual(startDate);
		}

		protected void AddDeleteArchivingQueryFilters(Query query) {
			var startDate = new QueryParameter(GetArchivationStartDate());
			var statusId = new QueryParameter(new Guid("815C9586-B6E2-DF11-971B-001D60E938C6"));
			query.Where(SchemaName, "StatusId").IsEqual(statusId)
				.And(SchemaName, "CompleteDate").IsLessOrEqual(startDate)
				.And().Exists(
					new Select(UserConnection)
						.Column("Id")
							.From("SysPrcHistoryLog")
							.Where("SysPrcHistoryLog", "Id").IsEqual(SchemaName, "Id") as Select);
		}

		protected virtual void AddArchivingQueryFilters(Select query) {
			AddBaseArchivingQueryFilters(query, SchemaName);
			query.Top(GetProcessLogArchivingCount());
		}

		protected virtual int GetProcessLogArchivingPeriod() {
			return BPMSoft.Core.Configuration.SysSettings
				.GetValue(UserConnection, HistoryPeriodSysSettingCode, DefaultHistoryPeriodDays);
		}

		protected virtual int GetProcessLogArchivingCount() {
			return BPMSoft.Core.Configuration.SysSettings
				.GetValue(UserConnection, ProcessLogArchivingRecordsCount, DefaultArchivingRecordsCount);
		}

		protected virtual EntitySchema GetEntitySchema() {
			EntitySchemaManager manager = UserConnection.AppConnection.SystemUserConnection.EntitySchemaManager;
			return manager.GetInstanceByName(SchemaName);
		}

		#endregion

	}

	#endregion

}
