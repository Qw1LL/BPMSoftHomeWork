namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common;
	using Newtonsoft.Json;
	using System.Linq;
	using System.Xml;
	using BPMSoft.Core.Factories;
	using System.Runtime.Serialization;
	using System.Collections.ObjectModel;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Scheduler;
	using Quartz;
	using Quartz.Impl;
	using Quartz.Impl.Triggers;
	using Quartz.Impl.Calendar;

	#region Struct: SimilarSearchXmlMatch

	/// <summary>
	/// Describes matching entity column to create search values.
	/// </summary>
	public struct SimilarSearchXmlMatch {

		/// <summary>
		/// Matching rule for column.
		/// </summary>
		public struct Rule {

			/// <summary>
			/// Column name.
			/// </summary>
			public string ColumnName {
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
			/// Record type in detail.
			/// </summary>
			public Guid TypeId {
				get;
				set;
			}

		}

		/// <summary>
		/// Source schema name.
		/// </summary>
		public string SourceSchemaName;

		/// <summary>
		/// Destination schema name.
		/// </summary>
		public string DestinationSchemaName;

		/// <summary>
		/// Entity columns with match rule.
		/// </summary>
		public Dictionary<string, Rule> EntityColumns {
			get;
			set;
		}

	}

	#endregion

	#region Class: DuplicatesSearchResponse

	/// <summary>
	/// Deduplication action response.
	/// </summary>
	[DataContract]
	public class DuplicatesSearchResponse {

		/// <summary>
		/// Result.
		/// </summary>
		[DataMember(Name = "success")]
		public bool Success {
			get;
			set;
		}

		/// <summary>
		/// Info message.
		/// </summary>
		[DataMember(Name = "message")]
		public string Message {
			get;
			set;
		}

		/// <summary>
		/// Methods Response.
		/// </summary>
		[DataMember(Name = "response")]
		public Dictionary<string, string> Response {
			get;
			set;
		}
	}

	#endregion

	#region Class: DeduplicationSearch

	/// <summary>
	/// Implement search of duplicates.
	/// </summary>
	public class DeduplicationSearch {

		#region Constants: Private

		private const string QuartzJobGroup = "Deduplication";

		private const string ScheduledSearchDuplicatesJobName = "ScheduledSearchDuplicates";
		
		private const string ScheduledSearchSchemas = "Contact|Account";

		private const string DeduplicationJobProcessName = "DeduplicationActionProcess";

		private const string SimilarRecordsTspPattern = "tsp_Find{0}SimilarRecords";

		private const string JobNamePattern = "{0}SearchDuplicates";

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		private IActionLocker _locker;

		#endregion

		#region Properties: Protected

		protected IActionLocker Locker {
			get {
				return _locker ?? (_locker = new DeduplicationActionLocker(_userConnection));
			}
			set {
				_locker = value;
			}
		}

		#endregion

		#region Methods: Private

		private string GetLczStringValue(string lczName) {
			string localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(
				_userConnection.Workspace.ResourceStorage, "DeduplicationSearch", localizableStringName);
			string value = localizableString.Value;
			if (value.IsNullOrEmpty()) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		private XmlElement CreateSimilarSearchXmlItem(string schemaName, string parentSchemaName,
				Guid typeId, string columnName, object value, XmlDocument xmlConfig) {
			XmlElement column = xmlConfig.CreateElement("item");
			XmlElement elementSchemaName = xmlConfig.CreateElement("schemaName");
			XmlElement elementParentSchemaName = xmlConfig.CreateElement("parentSchemaName");
			XmlElement elementTypeId = xmlConfig.CreateElement("typeId");
			XmlElement elementColumnName = xmlConfig.CreateElement("columnName");
			XmlElement elementValue = xmlConfig.CreateElement("columnValue");
			elementSchemaName.InnerText = schemaName;
			elementParentSchemaName.InnerText = parentSchemaName;
			elementColumnName.InnerText = columnName;
			elementValue.InnerText = (value == null) ? null : value.ToString();
			elementTypeId.InnerText = (typeId == Guid.Empty) ? null : typeId.ToString();
			column.AppendChild(elementSchemaName);
			column.AppendChild(elementParentSchemaName);
			column.AppendChild(elementTypeId);
			column.AppendChild(elementColumnName);
			column.AppendChild(elementValue);
			return column;
		}

		private bool CheckExistsSearchDuplicatesJob(string schemaName) {
			IScheduler scheduler = AppScheduler.Instance;
			string jobName = string.Format(JobNamePattern, schemaName);
			var jobKey = new JobKey(jobName, QuartzJobGroup);
			bool isExists = scheduler.CheckExists(jobKey);
			return isExists;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		public DeduplicationSearch(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Invokes search process.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <returns>Instance <see cref="DuplicatesSearchResponse"/> results for search process execution.</returns>
		public virtual DuplicatesSearchResponse FindEntityDuplicatesAsync(string schemaName) {
			DuplicatesSearchResponse result = new DuplicatesSearchResponse() {
				Message = GetLczStringValue("CommonErrorMessage")
			};
			if (!Locker.CanExecute(DeduplicationConsts.SearchOperationId, schemaName)) {
				result.Message = GetLczStringValue("InProgressMessage");
				return result;
			}
			string jobName = string.Format(JobNamePattern, schemaName);
			string processName = "DeduplicationActionProcess";
			var parameters = new Dictionary<string, object>() {
				{ "SchemaName" , schemaName },
				{ "OperationId", DeduplicationConsts.SearchOperationId }
			};
			AppScheduler.ScheduleImmediateProcessJob(jobName, QuartzJobGroup, processName,
			_userConnection.Workspace.Name, _userConnection.CurrentUser.Name, parameters);
			result.Success = true;
			result.Message = GetLczStringValue("SuccessMessage");
			return result;
		}

		/// <summary>
		/// Schedules periodical search of duplicates.
		/// </summary>
		/// <param name="cronExpression">Scheduler cron expression.</param>
		public void FindEntityDuplicatesBySchedule(string cronExpression) {
			RemoveSchedule();
			var parameters = new Dictionary<string, object>() {
				{"SchemaName", ScheduledSearchSchemas},
				{"OperationId", DeduplicationConsts.SearchOperationId}
			};
			IJobDetail job = AppScheduler.CreateProcessJob(
				ScheduledSearchDuplicatesJobName,
				QuartzJobGroup,
				DeduplicationJobProcessName,
				_userConnection.Workspace.Name,
				_userConnection.CurrentUser.Name,
				parameters);
			CronTriggerImpl trigger = new CronTriggerImpl(ScheduledSearchDuplicatesJobName, QuartzJobGroup,
				cronExpression);
			trigger.TimeZone = TimeZoneInfo.Utc;
			trigger.MisfireInstruction = MisfireInstruction.CronTrigger.FireOnceNow;
			AppScheduler.Instance.ScheduleJob(job, trigger);
		}

		/// <summary>
		/// Removes search schedule.
		/// </summary>
		public void RemoveSchedule() {
			AppScheduler.RemoveJob(ScheduledSearchDuplicatesJobName, QuartzJobGroup);
		}

		/// <summary>
		/// Performs search similar records using stored procedure.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="recordId">Record unique identifier.</param>
		/// <param name="searchValues">Values to find similar records.</param>
		/// <returns></returns>
		public List<Guid> FindSimilarEntity(string schemaName, Guid recordId, XmlDocument searchValues) {
			List<Guid> similarRecords = new List<Guid>();
			string tspName = string.Format(SimilarRecordsTspPattern, schemaName);
			var storedProcedure = new StoredProcedure(_userConnection, tspName);
			storedProcedure.WithParameter("recordId", recordId);
			storedProcedure.WithParameter("searchValues", searchValues.OuterXml);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (var reader = storedProcedure.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid id = reader.GetColumnValue<Guid>("Id");
						similarRecords.Add(id);
					}
				}
			}
			return similarRecords;
		}

		/// <summary>
		/// Gets Search execution info from log
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <returns>Instance <see cref="DuplicatesSearchResponse"/> results info search process execution.</returns>
		public virtual DuplicatesSearchResponse GetInfo(string schemaName) {
			DuplicatesSearchResponse result = new DuplicatesSearchResponse();
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "DeduplicateExecLocker");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			EntitySchemaQueryColumn completedOnColumn = esq.AddColumn("Conversation.ExecutedOn");
			EntitySchemaQueryColumn isInProgressColumn = esq.AddColumn("IsInProgress");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"EntitySchemaName", new object[] { schemaName }));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Operation", new object[] { DeduplicationConsts.SearchOperationId }));
			EntityCollection esqCollection = esq.GetEntityCollection(_userConnection);
			bool isExists = CheckExistsSearchDuplicatesJob(schemaName);
			if (esqCollection.Any()) {
				Entity entity = esqCollection[0];
				bool isInProgress = entity.GetTypedColumnValue<bool>(isInProgressColumn.Name) || isExists;
				DateTime completedOnValue = entity.GetTypedColumnValue<DateTime>(completedOnColumn.Name);
				result.Success = true;
				result.Response = new Dictionary<string, string>() {
					{
						"LastExecutionDate",
						DateTimeDataValueType.Serialize(completedOnValue, TimeZoneInfo.Utc)
					},
					{ "IsInProgress", JsonConvert.SerializeObject(isInProgress) }
				};
			} else {
				if (isExists) {
					result.Success = true;
					result.Response = new Dictionary<string, string>() {
						{ "IsInProgress", JsonConvert.SerializeObject(true) }
					};
				}
			}
			return result;
		}

		/// <summary>
		/// Create XML used for search similar records.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="xmlMatch">Columns matching for create search values.</param>
		/// <returns>XML for search similar records.</returns>
		public virtual XmlDocument CreateXmlSimilarSearchValue(Entity entity, SimilarSearchXmlMatch xmlMatch) {
			XmlDocument xmlConfig = new XmlDocument();
			XmlElement columns = xmlConfig.CreateElement("columns");
			xmlConfig.AppendChild(columns);
			foreach (var configItem in xmlMatch.EntityColumns) {
				SimilarSearchXmlMatch.Rule rule = configItem.Value;
				string leadColumnName = entity.Schema.Columns.GetByName(configItem.Key).ColumnValueName;
				object columnValue = entity.GetColumnValue(leadColumnName);
				XmlElement column = CreateSimilarSearchXmlItem(rule.SchemaName, xmlMatch.DestinationSchemaName,
					rule.TypeId, rule.ColumnName, columnValue, xmlConfig);
				columns.AppendChild(column);
			}
			return xmlConfig;
		}

		#endregion

	}

	#endregion

}

