namespace BPMSoft.Configuration.ScoringEngine {
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Globalization;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: ScoringEngine

	/// <summary>
	/// Implement business logic of scoring.
	/// </summary>
	public class ScoringEngine {

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Instance of <see cref="UserConnection"/>.
		/// </summary>
		public UserConnection UserConnection {
			get {
				return _userConnection;
			}
			set {
				_userConnection = value;
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		public ScoringEngine(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Update CreateUpdateScoreValueQuery(string entitySchemaName, string entitySchemaPrimaryColumnName,
				Guid primaryColumnValue, string scoreColumnName, object scoreColumnValue) {
			return new Update(UserConnection, entitySchemaName)
				.Set(scoreColumnName, Column.Parameter(scoreColumnValue))
				.Where(entitySchemaPrimaryColumnName).IsEqual(Column.Parameter(primaryColumnValue)) as Update;
		}

		private Select CreateSynchronizationRecordsSelect(string schemaName, DateTime lastSynchronizationDate,
				Guid lastSynchronizationId, List<string> columns, int limit) {
			Select select = new Select(UserConnection)
				.Top(limit)
			.From(schemaName)
			.Where("ModifiedOn")
				.IsGreaterOrEqual(Column.Parameter(lastSynchronizationDate))
			.And("ModifiedOn")
				.IsLessOrEqual(Column.Parameter(DateTime.UtcNow))
			.And("Id")
				.IsGreater(Column.Parameter(lastSynchronizationId))
			.OrderByAsc("Id") as Select;
			select.SpecifyNoLockHints();
			foreach (var column in columns) {
				select.Column(column);
			}
			return select;
		}

		private List<object> CreateSynchronizationDataRow(IDataReader dr, List<string> columns) {
			List<object> dataRow = new List<object>();
			foreach (var column in columns) {
				object columnValue = dr[column] == DBNull.Value ? (string)null : dr[column];
				if (columnValue is DateTime) {
					columnValue = DateTime.SpecifyKind((DateTime)columnValue, DateTimeKind.Utc);
				}
				dataRow.Add(columnValue);
			}
			return dataRow;
		}

		private ScoringModel CreateScoringModel(Entity scoringModelEntity) {
			var model = new ScoringModel();
			Guid scoringObjectId = scoringModelEntity.GetTypedColumnValue<Guid>("ScoringObjectId");
			Guid columnUId = scoringModelEntity.GetTypedColumnValue<Guid>("ColumnUId");
			EntitySchema scoringModelSchema = UserConnection.EntitySchemaManager.GetInstanceByUId(scoringObjectId);
			string scoringModelColumnName = scoringModelSchema.Columns.GetByUId(columnUId).Name;
			model.Rules = new List<ScoringRule>();
			model.Id = scoringModelEntity.PrimaryColumnValue;
			model.ModifiedOn = scoringModelEntity.GetTypedColumnValue<DateTime>("ModifiedOn");
			model.IsActive = scoringModelEntity.GetTypedColumnValue<bool>("IsActive");
			model.Name = scoringModelEntity.GetTypedColumnValue<string>("Name");
			model.ScoringObjectId = scoringObjectId;
			model.ScoringObjectName = scoringModelSchema.Name;
			model.ScoringColumnName = scoringModelColumnName;
			return model;
		}

		private List<ScoringModel> GetScoringModels() {
			var models = new List<ScoringModel>();
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName("ScoringModel");
			EntitySchemaQuery esq = new EntitySchemaQuery(schema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.IgnoreDisplayValues = true;
			esq.AddAllSchemaColumns();
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			foreach (Entity scoringModelEntity in entityCollection) {
				ScoringModel model = CreateScoringModel(scoringModelEntity);
				models.Add(model);
			}
			return models;
		}

		private ScoringRule CreateScoringRule(Entity scoringRuleEntity, ScoringModel scoringModel,
				RuleSerializationHelper ruleSerializationHelper) {
			var rule = new ScoringRule();
			string filterData = scoringRuleEntity.GetTypedColumnValue<string>("FilterData");
			string ruleCriteria = ruleSerializationHelper.CreateRuleCriteria(filterData, scoringModel.ScoringObjectId,
				UserConnection);
			string ruleQuery = ruleSerializationHelper.CreateRuleCriteria(filterData, scoringModel.ScoringObjectId,
				UserConnection, true);
			rule.RuleCriteriaQuery = ruleQuery;
			rule.RuleCriteria = ruleCriteria;
			rule.ScoringModelId = scoringModel.Id;
			rule.Id = scoringRuleEntity.GetTypedColumnValue<Guid>("Id");
			rule.ModifiedOn = scoringRuleEntity.GetTypedColumnValue<DateTime>("ModifiedOn");
			rule.ScoringCount = scoringRuleEntity.GetTypedColumnValue<int>("ScoringCount");
			rule.ScoringPoints = scoringRuleEntity.GetTypedColumnValue<decimal>("ScoringPoints");
			rule.Duration = scoringRuleEntity.GetTypedColumnValue<int>("Duration");
			rule.Name = scoringRuleEntity.GetTypedColumnValue<string>("Name");
			return rule;
		}

		private void ApplyScoringRules(List<ScoringModel> models) {
			var ruleSerializationHelper = new RuleSerializationHelper();
			EntitySchema scoringRuleSchema = UserConnection.EntitySchemaManager.GetInstanceByName("ScoringRule");
			EntitySchemaQuery esq = new EntitySchemaQuery(scoringRuleSchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.IgnoreDisplayValues = true;
			esq.AddAllSchemaColumns();
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			foreach (Entity scoringRuleEntity in entityCollection) {
				Guid scoringModelId = scoringRuleEntity.GetTypedColumnValue<Guid>("ScoringModelId");
				ScoringModel scoringModel = models.FirstOrDefault(model => model.Id == scoringModelId);
				if (scoringModel != null) {
					ScoringRule rule = CreateScoringRule(scoringRuleEntity, scoringModel, ruleSerializationHelper);
					scoringModel.Rules.Add(rule);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validate authentication cloud key in request.
		/// </summary>
		/// <param name="request">Instance of <see cref="HttpRequest"/> current request.</param>
		/// <returns>Message text if key wrong or empty string.</returns>
		public virtual string ValidateAuthKey(HttpRequest request) {
			AuthenticationResult result = BpmCrmCloudEngine.Authenticate(request, UserConnection);
			if (result.Success) {
				return string.Empty;
			}
			return result.Message;
		}

		/// <summary>
		/// Returns collection of required records.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="lastSynchronizationDate">Least modified date of recoreds.</param>
		/// <param name="lastSynchronizationId">Least unique identifier of recoreds.</param>
		/// <param name="columns">Requested columns.</param>
		/// <param name="limit">Records count.</param>
		/// <returns>Collection elements are the result of invoking method.</returns>
		public virtual List<List<object>> GetSynchronizationRecords(string schemaName, string lastSynchronizationDate,
				Guid lastSynchronizationId, List<string> columns, int limit) {
			var synchronizationData = new List<List<object>>();
			DateTime lastSynchronizationDateValue = DateTime.MinValue;
			if (!string.IsNullOrEmpty(lastSynchronizationDate)) {
				lastSynchronizationDateValue = DateTime.Parse(lastSynchronizationDate, CultureInfo.InvariantCulture);
			}
			Select synchronizationRecordsSelect = CreateSynchronizationRecordsSelect(schemaName, lastSynchronizationDateValue,
				lastSynchronizationId, columns, limit);
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = synchronizationRecordsSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						List<object> dataRow = CreateSynchronizationDataRow(dr, columns);
						synchronizationData.Add(dataRow);
					}
				}
			}
			return synchronizationData;
		}

		/// <summary>
		/// Saves scored results for entity.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="schemaColumnName">Schema column name.</param>
		/// <param name="scoredData">Dictionary of unique record identifiers and their result score values.</param>
		public void SaveScoredResults(string schemaName, string schemaColumnName,
				Dictionary<string, object> scoredData) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			EntitySchemaColumn entitySchemaColumn = entitySchema.Columns.GetByName(schemaColumnName);
			foreach (KeyValuePair<string, object> kvp in scoredData) {
				Guid primaryColumnValue = Guid.Parse(kvp.Key);
				Update updateScoreValueQuery = CreateUpdateScoreValueQuery(entitySchema.Name,
					entitySchema.PrimaryColumn.Name, primaryColumnValue, entitySchemaColumn.Name, kvp.Value);
				updateScoreValueQuery.Execute();
			}
		}

		/// <summary>
		/// Returns scoring map with scoring model and scoring rules.
		/// </summary>
		/// <returns>An <see cref="GetScoringMapResponse"/> result of invoking method.</returns>
		public virtual GetScoringMapResponse GetScoringMap() {
			GetScoringMapResponse response = new GetScoringMapResponse();
			List<ScoringModel> models = GetScoringModels();
			ApplyScoringRules(models);
			response.Models = models;
			DateTime? syncTime = (DateTime?)SysSettings.GetValue(UserConnection, "ScoringRulesSyncTime");
			response.SyncTime = syncTime;
			return response;
		}

		#endregion

	}

	#endregion

	#region Class: GetScoringMapResponse

	public class GetScoringMapResponse {

		#region Properties: Public

		public List<ScoringModel> Models {
			get;
			set;
		}

		public DateTime? SyncTime {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: ScoringModel

	public class ScoringModel {

		#region Properties: Public

		public Guid Id {
			get;
			set;
		}

		public DateTime ModifiedOn {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public bool IsActive {
			get;
			set;
		}

		public Guid ScoringObjectId {
			get;
			set;
		}

		public string ScoringObjectName {
			get;
			set;
		}

		public string ScoringColumnName {
			get;
			set;
		}

		public List<ScoringRule> Rules {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: ScoringRule

	public class ScoringRule {

		#region Properties: Public

		public Guid Id {
			get;
			set;
		}

		public DateTime ModifiedOn {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public bool IsActive {
			get;
			set;
		}

		public Guid ScoringModelId {
			get;
			set;
		}

		public int ScoringCount {
			get;
			set;
		}

		public decimal ScoringPoints {
			get;
			set;
		}

		public int Duration {
			get;
			set;
		}

		public string RuleCriteria {
			get;
			set;
		}

		public string RuleCriteriaQuery {
			get;
			set;
		}

		#endregion

	}

	#endregion
}
