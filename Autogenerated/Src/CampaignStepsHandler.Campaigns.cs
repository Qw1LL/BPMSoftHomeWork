namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using System.Text;
	using System.Data;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;

	/// <summary>
	/// Class storage parameters of the process of creating leads.
	/// </summary>
	internal class ProcParams
	{

		#region Preoperties : Public

		/// <summary>
		/// Id step "Create a lead."
		/// </summary>
		public Guid LeadStepId {
			get;
			set;
		}

		/// <summary>
		/// List of pairs [recordId, contactId] of campaign target
		/// </summary>
		public IEnumerable<KeyValuePair<Guid, Guid>> TargetInfoCollection {
			get;
			set;
		}

		#endregion

	}

	internal class CampaignNextStepInfo
	{

		#region Preoperties : Public

		public Guid NextStepId {
			get;
			set;
		}

		public DateTime NextStepStartDate {
			get;
			set;
		}

		public Guid TypeId {
			get;
			set;
		}

		public Guid NextStepTypeId {
			get;
			set;
		}

		public Guid SysSchemaUId {
			get;
			set;
		}

		public Guid RecordId {
			get;
			set;
		}

		public string JSON {
			get;
			set;
		}

		public Guid CampaignId {
			get;
			set;
		}

		#endregion

	}

	internal class CampaignNextStepPriority
	{

		#region Preoperties : Public

		public Guid FilterId {
			get;
			set;
		}

		public int Priority {
			get;
			set;
		}

		public Guid NextStepId {
			get;
			set;
		}

		public DateTime NextStepStartDate {
			get;
			set;
		}

		public double DayTransitionCount {
			get;
			set;
		}

		public List<Guid> BulkEmailHyperlinks {
			get;
			set;
		}

		#endregion

	}

	public class FolderInfo
	{
		public Guid FolderId {
			get;
			set;
		}
		public Guid FolderTypeId {
			get;
			set;
		}
		public byte[] SearchData {
			get;
			set;
		}
	}

	public partial class CampaignStepsHandler
	{

		#region Constants: Private

		private const double DefaultMinimumDayTransitionCount = 0.0104;

		#endregion

		#region Fields : Private

		/// <summary>
		///ESQ caching key
		/// </summary>
		Guid _cacheKey;

		int _rowCount;

		/// <summary>
		/// Semaphore to block access to the database when you call Update
		/// </summary> 
		private static object setNextStepUpdateLocker = new object();

		private static object contactsToFinishUpdateLocker = new object();

		private static object initNextStepByCampaignLocker = new object();

		private IList<Guid> _processedCampaigns;

		private EntityCollection _baseFilterCollection;

		#endregion

		#region Fields : Protected

		protected UserConnection _userConnection;

		#endregion

		#region Constructors

		public CampaignStepsHandler(UserConnection userConnection) {
			_userConnection = userConnection;
			_cacheKey = Guid.NewGuid();
			_processedCampaigns = new List<Guid>();
		}

		#endregion

		#region Preoperties : Public

		public int RowCount {
			get {
				return _rowCount;
			}
		}

		public IList<Guid> ProcessedCampaigns {
			get {
				return _processedCampaigns;
			}
		}

		#endregion

		#region Methods : Private

		private Select GetTargetStepsSelect(Guid stepId) {
			return new Select(_userConnection)
				.Column("TargetStepId")
				.From("CampaignStepRoute")
				.Where("SourceStepId").IsEqual(Column.Parameter(stepId)) as Select;
		}

		private Select GetImmediateTargetStepsSelect(Guid stepId) {
			Select targetStepsSelect = GetTargetStepsSelect(stepId);
			return new Select(_userConnection)
				.Column("Id")
				.From("CampaignStep")
				.Where("Id").In(targetStepsSelect)
				.And("TypeId").IsEqual(Column.Parameter(CampaignConsts.BulkEmailCampaignStepTypeId))
				.And().Exists(
					new Select(_userConnection)
						.Column(Column.Const(null))
						.From("BulkEmail")
						.Where("Id").IsEqual("CampaignStep", "RecordId")
						.And("LaunchOptionId").IsEqual(
							Column.Parameter(MailingConsts.TriggerEmailImmediateLaunchOptionId))
				) as Select;
		}
		/// <summary>
		/// Load the filters of basic steps.
		/// </summary>
		/// <returns>Collection of all elements of the conditions for the steps of the campaign.</returns>
		private EntityCollection GetBaseCampaignFilterCollection() {
			EntitySchema campaignFilterSchema = _userConnection.EntitySchemaManager.GetInstanceByName("CampaignFilter");
			EntitySchemaQuery esq = new EntitySchemaQuery(campaignFilterSchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Title");
			esq.AddColumn("StepType");
			esq.AddColumn("Priority");
			esq.AddColumn("SearchData");
			esq.JoinRightState = QueryJoinRightLevel.Disabled;
			esq.CacheItemName = campaignFilterSchema.Name + _cacheKey;
			esq.IgnoreDisplayValues = false;
			esq.UseLocalization = false;
			return esq.GetEntityCollection(_userConnection);
		}

		/// <summary>
		///Returns information about the next step.
		/// </summary>
		/// <param name="sourceStepId">The unique identifier of step.</param>
		private CampaignNextStepPriority GetCampaignNextStepInfo(Guid sourceStepId) {
			CampaignNextStepPriority result = null;
			Select selectFirstStepRoute = new Select(_userConnection)
				.Top(1)
				.Column("TargetStepId")
				.Column("JSON")
				.From("CampaignStepRoute")
				.Where("SourceStepId").IsEqual(Column.Parameter(sourceStepId)) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectFirstStepRoute.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						result = new CampaignNextStepPriority();
						result.NextStepId = _userConnection.DBTypeConverter.DBValueToGuid(
							reader.GetValue(reader.GetOrdinal("TargetStepId")));
						var JSON = reader.GetColumnValue<string>("JSON");
						result.DayTransitionCount = DeserializeDayTransitionCount(JSON, _userConnection);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Returns information about the second step of the campaign.
		/// </summary>
		/// <param name="campaignId">The unique identifier of the campaign.</param>
		private CampaignNextStepPriority GetCampaignSecondStepInfo(Guid campaignId) {
			CampaignNextStepPriority result = null;
			Select firstStepIdSelect = GetCampaignFirstStepSelect(campaignId);
			Select selectFirstStepRoute = new Select(_userConnection)
				.Top(1)
				.Column("TargetStepId")
				.Column("JSON")
				.From("CampaignStepRoute")
				.Where("SourceStepId").IsEqual(firstStepIdSelect) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectFirstStepRoute.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						result = new CampaignNextStepPriority();
						result.NextStepId = _userConnection.DBTypeConverter.DBValueToGuid(
							reader.GetValue(reader.GetOrdinal("TargetStepId")));
						var JSON = reader.GetColumnValue<string>("JSON");
						result.DayTransitionCount = DeserializeDayTransitionCount(JSON, _userConnection);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Sets the next step for the audience of the campaign, when you start the campaign.
		/// </summary>
		/// <param name="campaignId">The unique identifier of the campaign.</param>
		private void InitNextStepByCampaignId(Guid campaignId) {
			CampaignNextStepPriority nextStepInfo = GetCampaignSecondStepInfo(campaignId);
			if (nextStepInfo != null) {
				ProcParams procParams = null;
				Guid nextStepType = GetStepTypeByStepId(nextStepInfo.NextStepId);
				if (nextStepType == CampaignConsts.CreateLeadCampaignStepTypeId) {
					Guid currentStepId = GetCampaignFirstStep(campaignId);
					Select selectQuery = GetTargetInfoSelectQuery(currentStepId, nextStepInfo.NextStepId);
					IEnumerable<KeyValuePair<Guid, Guid>> targetInfoCollection = GetTargetInfoCollection(selectQuery);
					if (targetInfoCollection != null) {
						procParams = new ProcParams {
							LeadStepId = nextStepInfo.NextStepId,
							TargetInfoCollection = targetInfoCollection
						};
					}
					nextStepInfo.NextStepId = GetNextVisibleStep(nextStepInfo.NextStepId);
				}
				Select firstStepSelect = GetCampaignFirstStepSelect(campaignId);
				var update = new Update(_userConnection, "CampaignTarget")
					.Set("NextStepId", Column.Parameter(nextStepInfo.NextStepId))
					.Where("CampaignId").IsEqual(Column.Parameter(campaignId))
					.And("CurrentStepId").In(firstStepSelect)
					.And("NextStepId").IsNull();
				if (nextStepInfo.DayTransitionCount >= 0) {
					update.And("ModifiedOn").IsLessOrEqual(Column.Parameter(DateTime.UtcNow.AddDays(
							-nextStepInfo.DayTransitionCount)));
				};
				lock (initNextStepByCampaignLocker) {
					update.Execute();
				}
				if (procParams != null) {
					CampaignCreateLeadProcessHelper.CreateCampaignLead(_userConnection, procParams.LeadStepId, procParams.TargetInfoCollection);
				}
			}
		}

		/// <summary>
		/// Sets the next step for the audience of the campaign by current step
		/// </summary>
		/// <param name="currentStepId">The unique identifier of the current step.</param>
		/// <param name="campaignId">The unique identifier of the campaign.</param>
		private void InitNextStepByCurrentStepId(Guid currentStepId, Guid campaignId) {
			CampaignNextStepPriority nextStepInfo = GetCampaignNextStepInfo(currentStepId);
			if (nextStepInfo != null) {
				ProcParams procParams = null;
				Guid nextStepType = GetStepTypeByStepId(nextStepInfo.NextStepId);
				if (nextStepType == CampaignConsts.CreateLeadCampaignStepTypeId) {
					Select selectQuery = GetTargetInfoSelectQuery(currentStepId, nextStepInfo.NextStepId);
					IEnumerable<KeyValuePair<Guid, Guid>> targetInfoCollection = GetTargetInfoCollection(selectQuery);
					if (targetInfoCollection != null) {
						procParams = new ProcParams {
							LeadStepId = nextStepInfo.NextStepId,
							TargetInfoCollection = targetInfoCollection
						};
					}
					nextStepInfo.NextStepId = GetNextVisibleStep(nextStepInfo.NextStepId);
				}
				var update = new Update(_userConnection, "CampaignTarget")
					.Set("NextStepId", Column.Parameter(nextStepInfo.NextStepId))
					.Where("CampaignId").IsEqual(Column.Parameter(campaignId))
					.And("CurrentStepId").IsEqual(Column.Parameter(currentStepId))
					.And("NextStepId").IsNull();
				if (nextStepInfo.DayTransitionCount >= 0) {
					update.And("ModifiedOn").IsLessOrEqual(Column.Parameter(DateTime.UtcNow.AddDays(
						-nextStepInfo.DayTransitionCount)));
				};
				lock (setNextStepUpdateLocker) {
					update.Execute();
				}				
				if (procParams != null) {
					CampaignCreateLeadProcessHelper.CreateCampaignLead(_userConnection, procParams.LeadStepId, procParams.TargetInfoCollection);
				}
			}
		}

		/// <summary>
		/// Returns the identifier step type.
		/// </summary>
		/// <param name="stepId">The unique identifier of the step.</param>
		private Guid GetStepTypeByStepId(Guid stepId) {
			var selectQuery = new Select(_userConnection)
				.Column("TypeId")
				.From("CampaignStep")
				.Where("Id").IsEqual(Column.Parameter(stepId)) as Select;
			return selectQuery.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Returns List of pairs [recordId, contactId] of campaign target.
		/// returns null if target is empty
		/// </summary>
		/// <param name="selectQuery">Select-query.</param>
		/// <returns>List of pairs [recordId, contactId] of campaign target</returns>
		private IEnumerable<KeyValuePair<Guid, Guid>> GetTargetInfoCollection(Select selectQuery) {
			List<KeyValuePair<Guid, Guid>> list = new List<KeyValuePair<Guid, Guid>>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectQuery.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						list.Add(new KeyValuePair<Guid, Guid>(
							_userConnection.DBTypeConverter.DBValueToGuid(
								reader.GetValue(reader.GetOrdinal("Id"))),
							_userConnection.DBTypeConverter.DBValueToGuid(
								reader.GetValue(reader.GetOrdinal("ContactId")))));
					}
				}
			}
			return list.Count > 0 ? list : null;
		}

		/// <summary>
		/// Returns query to get campaign terget.
		/// </summary>
		/// <param name="currentStepId">Id of current step</param>
		/// <param name="passedStepId">Id of step to be skipped.</param>
		private Select GetTargetInfoSelectQuery(Guid currentStepId, Guid passedStepId) {
			var selectQuery = new Select(_userConnection)
				.Column("Id")
				.Column("ContactId")
				.From("CampaignTarget")
				.Where("CurrentStepId").IsEqual(Column.Parameter(currentStepId))
				.And()
				.OpenBlock("PassedStepId").IsNull()
				.Or("PassedStepId").Not().IsEqual(Column.Parameter(passedStepId))
				.CloseBlock()
				.And("NextStepId").IsNull();
			return selectQuery as Select;
		}

		/// <summary>
		/// Returns next step visible for audience
		/// </summary>
		/// <param name="currentStepId">Id of current step</param>
		private Guid GetNextVisibleStep(Guid currentStepId) {
			CampaignNextStepPriority nextStep = GetCampaignNextStepInfo(currentStepId);
			if (nextStep == null) {
				return Guid.Empty;
			}
			Guid nextStepType = GetStepTypeByStepId(nextStep.NextStepId);
			if (nextStepType == CampaignConsts.CreateLeadCampaignStepTypeId) {
				return GetNextVisibleStep(nextStep.NextStepId);
			}
			return nextStep.NextStepId;
		}

		/// <summary>
		/// Set null to next step of audience
		/// </summary>
		/// <param name="campaignId">Id of campaign</param>
		/// <param name="currentStepId">Id of current step</param>
		private void ClearNextStep(Guid campaignId, Guid currentStepId) {
			Update updateQuery = new Update(_userConnection, "CampaignTarget")
				.Set("NextStepId", Column.Const(null))
				.Where("CampaignId").IsEqual(Column.Parameter(campaignId))
				.And("CurrentStepId").IsEqual(Column.Parameter(currentStepId))
				.And("NextStepId").Not().IsNull() as Update;
			updateQuery.Execute();
		}


		/// <summary>
		/// Check if steps actialization needed at the moment
		/// </summary>
		/// <param name="campaignId">Id of campaign</param>
		private bool NeedActualization(Guid campaignId) {
			var campaignSelect = new Select(_userConnection)
				.Column("NextFireTime")
				.Column("FirePeriod")
				.From("Campaign")
				.Where("Id").IsEqual(Column.Parameter(campaignId))
				.And("NextFireTime").Not().IsNull()
				.And("FirePeriod").Not().IsNull() as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dr = campaignSelect.ExecuteReader(dbExecutor)) {
					if (!dr.Read()) {
						return true;
					}
					var nextFireTime = (DateTime)dr["NextFireTime"];
					var firePeriod = (int)dr["FirePeriod"];
					if (nextFireTime > DateTime.UtcNow) {
						return false;
					}
					nextFireTime = nextFireTime.AddMinutes(firePeriod);
					new Update(_userConnection, "Campaign")
						.Set("NextFireTime", Column.Parameter(nextFireTime))
						.Where("Id").IsEqual(Column.Parameter(campaignId)).Execute();
					return true;
				}
			}
		}

		/// <summary>
		/// Set the current time for the launch mailing for mailings, linked to the current step.
		/// </summary>
		private void ActivateReferencedCampaignEmails(Guid campaignId, Guid stepId) {
			try {
				var select = new Select(_userConnection)
					.Column("RecordId")
					.From("CampaignStep")
					.Where("TypeId").IsEqual(Column.Parameter(CampaignConsts.BulkEmailCampaignStepTypeId))
					.And("CampaignId").IsEqual(Column.Parameter(campaignId))
					.And("Id").IsEqual(Column.Parameter(stepId)) as Select;

				QueryCase queryCase = new QueryCase();
				QueryCondition queryCondition = new QueryCondition(QueryConditionType.Equal) {
					LeftExpression = new QueryColumnExpression("CategoryId")
				};
				queryCondition.RightExpressions.Add(Column.Parameter(MarketingConsts.MassmailingBulkEmailCategoryId));
				queryCase.AddWhenItem(queryCondition, Column.Parameter(MarketingConsts.BulkEmailStatusStartPlanedId));
				queryCase.ElseExpression = new QueryColumnExpression(
						Column.Parameter(MarketingConsts.BulkEmailStatusActiveId));

				var updateStatusId = new Update(_userConnection, "BulkEmail").WithHints(new RowLockHint())
					.Set("StatusId", new QueryColumnExpression(queryCase))
					.Where("Id").In(select)
					.And("LaunchOptionId").IsEqual(Column.Parameter(MarketingConsts.TriggerEmailFromCampaignLaunchOptionId))
					.And("StatusId").In(
						Column.Parameter(MarketingConsts.BulkEmailStatusStoppedId),
						Column.Parameter(MarketingConsts.BulkEmailStatusFinishedId)
					)as Update;

				var updateTriggerStartDate = new Update(_userConnection, "BulkEmail").WithHints(new RowLockHint())
					.Set("StartDate", Column.Parameter(DateTime.UtcNow))
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Where("Id").In(select)
					.And("LaunchOptionId").IsEqual(Column.Parameter(MarketingConsts.TriggerEmailFromCampaignLaunchOptionId))
					.And("CategoryId").Not().IsEqual(Column.Parameter(MarketingConsts.MassmailingBulkEmailCategoryId))
					.And("StatusId").IsEqual(Column.Parameter(MarketingConsts.BulkEmailStatusActiveId))
					as Update;
				updateStatusId.Execute();
				updateTriggerStartDate.Execute();
			} catch(Exception e){
				MailingUtilities.Log.ErrorFormat("[CampaignStepsHandler.ActivateReferencedCampaignEmails] Failed: " +
					"CampaignId {0}, Step {1}.", e, campaignId, stepId);
				throw;
			}
		}

		/// <summary>
		/// Returns a collection of the next steps.
		/// </summary>
		/// <param name="sourceStepId">Id of current step</param>
		private Collection<CampaignNextStepInfo> GetTargetStepCollection(Guid sourceStepId) {
			Collection<CampaignNextStepInfo> resultCollection = new Collection<CampaignNextStepInfo>();
			Select startDateSubSelect = new Select(_userConnection)
				.Column(Func.Max("StartDate"))
				.From(new Select(_userConnection)
				.Column("StartDate")
				.From("BulkEmail")
				.Where("Id").IsEqual(
					new Select(_userConnection).Top(1).Column("ts1", "RecordId")
						.From("CampaignStep").As("ts1").Where("Id")
						.IsEqual("TargetStepId"))
				.Union(new Select(_userConnection)
				.Column("StartDate")
				.From("Event")
				.Where("Id").IsEqual(
					new Select(_userConnection).Top(1).Column("ts2", "RecordId")
						.From("CampaignStep").As("ts2").Where("Id")
						.IsEqual("TargetStepId")))).As("DT");

			Select selectQuery = new Select(_userConnection)
				.Column("CampaignStepRoute", "TargetStepId")
				.Column("CampaignStep", "TypeId")
				.Column("CampaignTargetStep", "TypeId").As("TargetStepTypeId")
				.Column("CampaignStepType", "SysSchemaUId")
				.Column("CampaignStep", "CampaignId")
				.Column("CampaignStep", "RecordId")
				.Column(startDateSubSelect).As("TargetStepStartDate")
				.Column("CampaignStepRoute", "JSON")
				.From("CampaignStepRoute")
				.InnerJoin("CampaignStep").As("CampaignStep")
				.On("CampaignStepRoute", "SourceStepId").IsEqual("CampaignStep", "Id")
				.InnerJoin("CampaignStepType").As("CampaignStepType")
				.On("CampaignStep", "TypeId").IsEqual("CampaignStepType", "Id")
				// Get next step type.
				.InnerJoin("CampaignStep").As("CampaignTargetStep")
				.On("CampaignStepRoute", "TargetStepId").IsEqual("CampaignTargetStep", "Id")
				.InnerJoin("CampaignStepType").As("CampaignTargetStepType")
				.On("CampaignStep", "TypeId").IsEqual("CampaignTargetStepType", "Id")
				.Where("CampaignStepRoute", "SourceStepId").IsEqual(Column.Parameter(sourceStepId))
				.And()
				// Condition OR determine next step type 'Create lead'
				.OpenBlock("CampaignStep", "RecordId").Not().IsNull()
				.And("CampaignStepType", "SysSchemaUId").Not().IsNull()
				.Or("CampaignTargetStep", "TypeId").IsEqual(Column.Parameter(CampaignConsts.CreateLeadCampaignStepTypeId))
				.CloseBlock()
				.OrderByAsc("TargetStepStartDate") as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectQuery.ExecuteReader(dbExecutor)) {
					int recordIdIndex = reader.GetOrdinal("RecordId");
					int schemaUIdIndex = reader.GetOrdinal("SysSchemaUId");
					while (reader.Read()) {
						resultCollection.Add(new CampaignNextStepInfo() {
							NextStepId = _userConnection.DBTypeConverter.DBValueToGuid(
								reader.GetValue(reader.GetOrdinal("TargetStepId"))),
							TypeId = _userConnection.DBTypeConverter.DBValueToGuid(
								reader.GetValue(reader.GetOrdinal("TypeId"))),
							NextStepTypeId = _userConnection.DBTypeConverter.DBValueToGuid(
								reader.GetValue(reader.GetOrdinal("TargetStepTypeId"))),
							SysSchemaUId = reader.IsDBNull(schemaUIdIndex) ? Guid.Empty : _userConnection.DBTypeConverter.DBValueToGuid(
								reader.GetValue(schemaUIdIndex)),
							RecordId = reader.IsDBNull(recordIdIndex) ? Guid.Empty : _userConnection.DBTypeConverter.DBValueToGuid(
								reader.GetValue(recordIdIndex)),
							JSON = reader.GetColumnValue<string>("JSON"),
							CampaignId = _userConnection.DBTypeConverter.DBValueToGuid(
								reader.GetValue(reader.GetOrdinal("CampaignId"))),
						});
					}
				}
			}
			return resultCollection;
		}

		/// <summary>
		/// Get identifiers of responces from route JSON
		/// </summary>
		/// <param name="jsonValue">JSON containing filters</param>
		private List<Guid> DeserializeRouteFilterIds(string jsonValue) {
			List<Guid> result = new List<Guid>();
			var JsonInfoData = GetAddInfoObject(jsonValue);
			if (JsonInfoData != null) {
				JArray filterIds = JsonInfoData["Filters"] as JArray;
				if (filterIds != null && filterIds.Count > 0) {
					result = filterIds.ToObject<IList<Guid>>().ToList();
				}
			}
			return result;
		}

		private List<Guid> DeserializeBulkEmailHyperlinks(string jsonValue) {
			List<Guid> deserializeBulkEmailHyperlinks = null;
			var JsonInfoData = GetAddInfoObject(jsonValue);
			if (JsonInfoData != null) {
				JArray hyperlinkIds = JsonInfoData["BulkEmailHyperlinks"] as JArray;
				if (hyperlinkIds != null && hyperlinkIds.Count > 0) {
					deserializeBulkEmailHyperlinks = GetHyperlinkIds(hyperlinkIds);
				}
			}
			return deserializeBulkEmailHyperlinks ?? new List<Guid>();
		}

		private static List<Guid> GetHyperlinkIds(JArray hyperlinkIds) {
			var result = new List<Guid>();
			foreach (JToken hyperlink in hyperlinkIds) {
				Guid id;
				var isGuid = Guid.TryParse((string)hyperlink["Id"], out id);
				if (isGuid) {
					result.Add(id);
				}
			}
			return result;
		}

		private JObject GetAddInfoObject(string json) {
			JObject jsonData = Json.Deserialize(json) as JObject;
			if (jsonData == null) {
				return null;
			}
			return jsonData["addInfo"] as JObject;
		}

		/// <summary>
		/// Get audience query with given filters  
		/// </summary>
		/// <param name="stepItem">Next step parameters.</param>
		/// <param name="filter">IEntitySchemaQueryFilterItem filter.</param>
		private Select GetSourceTargetQuery(CampaignNextStepInfo stepItem, IEntitySchemaQueryFilterItem filter, CampaignNextStepPriority priorityItem) {
			Guid recordId = stepItem.RecordId;
			Guid sysSchemaUId = stepItem.SysSchemaUId;
			EntitySchema rootSchema = _userConnection.EntitySchemaManager.GetInstanceByUId(sysSchemaUId);
			string targetSchemaName = GetSourceTargetSchemaName(rootSchema.Name);
			string targetSchemaReferenceColumnName = rootSchema.Name + "." + rootSchema.PrimaryColumn.Name;
			EntitySchemaQuery resultEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, targetSchemaName);
			resultEsq.AddColumn(targetSchemaReferenceColumnName).SetForcedQueryColumnValueAlias("RecordId");
			resultEsq.AddColumn("Contact.Id").SetForcedQueryColumnValueAlias("ContactId");
			if (filter != null) {
				resultEsq.Filters.Add(filter);
			}
			resultEsq.Filters.Insert(0, resultEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
				targetSchemaReferenceColumnName,
				recordId));
			Select sourceTargetQuery = resultEsq.GetSelectQuery(_userConnection);
			Guid filterId = priorityItem.FilterId;
			if (filterId == CampaignConsts.HyperlinkClickedCampaignFilterId && priorityItem.BulkEmailHyperlinks.Any()) {
				AddBulkEmailHyperlinkFilter(priorityItem, sourceTargetQuery);
			}
			return sourceTargetQuery;
		}

		private static void AddBulkEmailHyperlinkFilter(CampaignNextStepPriority priorityItem, Select sourceTargetQuery) {
			sourceTargetQuery.InnerJoin("VwBulkEmailClickedLink").As("Links").WithHints(new NoLockHint())
				.On("BulkEmailTarget", "ContactId").IsEqual("Links", "ContactId")
				.And("Links", "BulkEmailHyperlinkId").In(Column.Parameters(priorityItem.BulkEmailHyperlinks));
		}

		/// <summary>
		/// Deserializes basic filters campaign steps and converts into IEntitySchemaQueryFilterItem
		/// </summary>
		/// <param name="filterInstance">CampaignFilter entity.</param>
		/// <param name="sysSchemaUId">The unique identifier of step's schema</param>
		private IEntitySchemaQueryFilterItem DeserializeSourceTargetFilter(Entity filterInstance, Guid sysSchemaUId) {
			EntitySchema sourceSchema = _userConnection.EntitySchemaManager.GetInstanceByUId(sysSchemaUId);
			IEntitySchemaQueryFilterItem esqFilters = null;
			byte[] searchData = filterInstance.GetBytesValue("SearchData");
			if (searchData == null) {
				return null;
			}
			string serializedFilters = Encoding.UTF8.GetString(searchData, 0, searchData.Length);
			if (string.IsNullOrEmpty(serializedFilters)) {
				return null;
			}
			DataContract.Filters deserializedFilters =
				Json.Deserialize<DataContract.Filters>(serializedFilters);
			if (sourceSchema.Name.Equals(deserializedFilters.RootSchemaName)
					&& deserializedFilters.Items.Count > 0) {
				DataContract.Filter rootFilter = deserializedFilters.Items.First().Value;
				DataContract.Filters targetFilters = rootFilter.SubFilters;
				EntitySchema sourceTargetSchema = _userConnection.EntitySchemaManager
					.GetInstanceByName(targetFilters.RootSchemaName);
				esqFilters = targetFilters.BuildEsqFilter(sourceTargetSchema.UId, _userConnection);
				return esqFilters;
			}
			return esqFilters;
		}

		/// <summary>
		/// Substitute schema name to audience target template
		/// </summary>
		/// <param name="schemaName">Schema name</param>
		/// <returns>Name of the audience target schema</returns>
		private string GetSourceTargetSchemaName(string schemaName) {
			return String.Format("{0}Target", schemaName);
		}

		/// <summary>
		/// Returns list of steps of started campaigns
		/// </summary>
		/// <param name="campaignList">List of campaigns identifiers to be filtered</param>
		/// <returns>Dictionary of campaigns and its steps (ids)</returns>
		private Dictionary<Guid, Guid> GetCampaingsStepsForActualize(IList<Guid> campaignList = null) {
			Dictionary<Guid, Guid> stepIds = new Dictionary<Guid, Guid>();
			Select selectQuery = new Select(_userConnection)
				.Column("CampaignStep", "Id")
				.Column("CampaignStep", "CampaignId")
				.From("Campaign")
				.InnerJoin("CampaignStep")
				.On("Campaign", "Id").IsEqual("CampaignStep", "CampaignId")
				.Where("Campaign", "CampaignStatusId").IsEqual(Column.Parameter(CampaignConsts.RunCampaignStatusId))
				.And("CampaignStep", "TypeId").In(Column.Parameters(
					new object[] {
						CampaignConsts.BulkEmailCampaignStepTypeId,
						CampaignConsts.EventCampaignStepTypeId,
						CampaignConsts.AudienceCampaignStepTypeId,
						CampaignConsts.LendingCampaignStepTypeId,
						CampaignConsts.CreateLeadCampaignStepTypeId
					})) as Select;

			if (campaignList != null && campaignList.Count > 0) {
				selectQuery.And("Campaign", "Id").In(Column.Parameters(campaignList));
			}
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectQuery.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						stepIds.Add(_userConnection.DBTypeConverter.DBValueToGuid(reader.GetValue(0)),
							_userConnection.DBTypeConverter.DBValueToGuid(reader.GetValue(1)));
					}
				}
			}
			return stepIds;
		}

		/// <Summary>
		/// Returns the query to get the first step of the Campaign
		/// </Summary>
		/// <Param name = "campaignId">Unique ID of the campaign</ Param>
		private Select GetCampaignFirstStepSelect(Guid campaignId) {
			var select = new Select(_userConnection)
				.Top(1)
				.Column("Id")
				.From("CampaignStep")
				.Where("CampaignId").IsEqual(Column.Parameter(campaignId))
				.And().Exists(
					new Select(_userConnection)
						.Column(Column.Parameter(1))
						.From("CampaignStepRoute")
						.Where("SourceStepId").IsEqual("CampaignStep", "Id")
				)
				.And().Not().Exists(
					new Select(_userConnection)
						.Column(Column.Parameter(1))
						.From("CampaignStepRoute")
						.Where("TargetStepId").IsEqual("CampaignStep", "Id")
				) as Select;
			return select;
		}

		/// <summary>
		/// Returns step identifier by step type
		/// </summary>
		/// <param name="campaignId">Unique ID of the campaign</param>
		/// <param name="typeId">Unique ID of the step type</param>
		/// <returns></returns>
		private Guid GetCampaignStepByType(Guid campaignId, Guid typeId) {
			var select = new Select(_userConnection)
				.Column("Id")
				.From("CampaignStep")
				.Where("CampaignId").IsEqual(Column.Parameter(campaignId))
				.And("TypeId").IsEqual(Column.Parameter(typeId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Returns query to get new actual audience
		/// </summary>
		/// <param name="campaignId">Unique ID of the campaign</param>
		private Select GetNewContactSelect(Guid campaignId) {
			Guid firstStepId = GetCampaignStepByType(campaignId, CampaignConsts.AudienceCampaignStepTypeId);
			string rootTableName;
			string rootContactColumName;
			Select audienceSelect = GetFolderSelectByStep(firstStepId, out rootTableName, out rootContactColumName);
			if (audienceSelect == null) {
				return null;
			}
			//Guid successStepId = GetCampaignStepByType(campaignId, CampaignConsts.GoalCampaignStepTypeId);
			//const string successAlias = "Success";
			//Select sucessSelect = GetFolderSelectByStep(successStepId, successAlias + "ContactId");
			//Guid exitStepId = GetCampaignStepByType(campaignId, CampaignConsts.ExitCampaignStepTypeId);
			//const string exitAlias = "Exit";
			//Select exitSelect = GetFolderSelectByStep(exitStepId, exitAlias + "ContactId");
			const string existingAlias = "Existing";
			Select existingSelect = GetCurrentAudienceSelect(campaignId, existingAlias + "ContactId",
				new[] { Guid.Empty }, false);
			Select resultSelect = audienceSelect;
			//At first add condition where - because they don't add after join
			//Where
			audienceSelect.And(existingAlias, existingAlias + "ContactId").IsNull();
			//if (sucessSelect != null) {
			//	audienceSelect.And(successAlias, successAlias + "ContactId").IsNull();
			//}
			//if (exitSelect != null) {
			//	audienceSelect.And(exitAlias, exitAlias + "ContactId").IsNull();
			//}
			//Joins
			AddExceptSelectJoin(resultSelect, existingSelect, rootTableName, rootContactColumName, existingAlias);
			//if (sucessSelect != null) {
			//	AddExceptSelectJoin(resultSelect, sucessSelect, rootTableName, rootContactColumName, successAlias);
			//}
			//if (exitSelect != null) {
			//	AddExceptSelectJoin(resultSelect, exitSelect, rootTableName, rootContactColumName, exitAlias);
			//}
			resultSelect.Column(Column.Parameter(campaignId)).As("CampaignId");
			return resultSelect;
		}

		/// <summary>
		/// Update contacts finishing campaign ahead of schedule
		/// </summary>
		/// <param name="campaignId">Unique ID of the campaign</param>
		private void UpdateContactsToFinishInCampaignTarget(Guid campaignId) {
			QueryColumnExpression nullParameter =
				Column.Parameter(DBNull.Value, new GuidDataValueType(_userConnection.DataValueTypeManager));
			if (campaignId != Guid.Empty) {
				Guid successStepId = GetCampaignStepByType(campaignId, CampaignConsts.GoalCampaignStepTypeId);
				var contactSelectSuccess = GetContactsToFinishSelect(campaignId, successStepId);
				if (contactSelectSuccess != null) {
					var contactUpdateSuccess = new Update(_userConnection, "CampaignTarget")
						.Set("CurrentStepId", Column.Parameter(successStepId))
						.Set("NextStepId", nullParameter)
						.Where("ContactId").In(contactSelectSuccess)
						.And("CampaignId").IsEqual(Column.Parameter(campaignId)) as Update;
					lock (contactsToFinishUpdateLocker) {
						contactUpdateSuccess.Execute();
					}
				}

				Guid exitStepId = GetCampaignStepByType(campaignId, CampaignConsts.ExitCampaignStepTypeId);
				Select contactSelectExit = GetContactsToFinishSelect(campaignId, exitStepId);
				if (contactSelectExit != null) {
					var contactUpdateExit = new Update(_userConnection, "CampaignTarget")
						.Set("CurrentStepId", Column.Parameter(exitStepId))
						.Set("NextStepId", nullParameter)
						.Where("ContactId").In(contactSelectExit)
						.And("CampaignId").IsEqual(Column.Parameter(campaignId)) as Update;
					lock (contactsToFinishUpdateLocker) {
						contactUpdateExit.Execute();
					}
				}
			}
		}

		/// <summary>
		/// Returns query to get contacts finishing campaign ahead of schedule (success / out of campaign)
		/// </summary>
		/// <param name="campaignId">Unique ID of the campaign</param>
		/// <param name="finishStepId">Unique ID of the finishing step</param>
		private Select GetContactsToFinishSelect(Guid campaignId, Guid finishStepId) {
			const string stepAlias = "SubSelect";

			Select audienceSelect = GetCurrentAudienceSelect(campaignId, stepAlias + "ContactId",
				new[] { CampaignConsts.GoalCampaignStepTypeId, CampaignConsts.ExitCampaignStepTypeId }, false);
			if (audienceSelect == null) {
				return null;
			}

			Select stepSelect = GetFolderSelectByStep(finishStepId, stepAlias + "ContactId");

			Select resultSelect = audienceSelect;
			//At first add condition where - because they dosen't add after join
			//Where
			if (stepSelect != null) {
				audienceSelect.And(stepAlias + "ContactId").Not().IsNull();
				AddExceptSelectJoin(resultSelect, stepSelect, "CampaignTarget", "ContactId", stepAlias);
			} else {
				resultSelect = null;
			}
			return resultSelect;
		}

		/// <summary>
		/// Returns query to get current campaign audience
		/// </summary>
		/// <param name="campaignId">Unique ID of the campaign</param>
		/// <param name="contactColumnAlias">Alias of the column with contact Id</param>
		/// <param name="currentStepTypesIds">List of step type Ids to be filtered</param>
		/// <param name="isEqual">Filter method</param>
		private Select GetCurrentAudienceSelect(Guid campaignId, string contactColumnAlias, Guid[] currentStepTypesIds,
			bool isEqual) {
			var select = new Select(_userConnection)
				.Column("ContactId").As(contactColumnAlias)
				.From("CampaignTarget")
				.LeftOuterJoin("CampaignStep")
					.On("CampaignStep", "Id").IsEqual("CampaignTarget", "CurrentStepId")
				.Where("CampaignTarget", "CampaignId").IsEqual(Column.Parameter(campaignId)) as Select;
			select.SpecifyNoLockHints();
			if (currentStepTypesIds == null || currentStepTypesIds.IsEmpty()) {
				return select as Select;
			} else {
				return isEqual 
					? select.And("CampaignStep", "TypeId").In(Column.Parameters(currentStepTypesIds)) as Select
					: select.And("CampaignStep", "TypeId").Not().In(Column.Parameters(currentStepTypesIds)) as Select;
			}
		}

		/// <summary>
		///  Returns query to get contacts by step containing folder id
		/// </summary>
		/// <param name="stepId">Unique Id of the step with folder</param>
		/// <param name="rootTablename">Alias of the root table in the query</param>
		/// <param name="rootTableContactColumnName">Name of the column with contact id in root table</param>
		/// <param name="contactColumnAlias">Alias of the column with contact id in the resulting query</param>	
		private Select GetFolderSelectByStep(Guid stepId, out string rootTablename,
			out string rootTableContactColumnName, string contactColumnAlias = "ContactId") {
			FolderInfo folderInfo = GetStepFolderInfo(stepId);
			rootTablename = "";
			rootTableContactColumnName = "";
			return folderInfo != null && folderInfo.FolderId != Guid.Empty ?
				GetFolderSelect(folderInfo, contactColumnAlias, out rootTablename, out rootTableContactColumnName) :
				null;
		}

		/// <summary>
		///  Returns query to get contacts by step containing folder id
		/// </summary>
		/// <param name="stepId">Unique Id of the step with folder</param>
		/// <param name="contactColumnAlias">Alias of the column with contact id in the resulting query</param>	
		private Select GetFolderSelectByStep(Guid stepId, string contactColumnAlias = "ContactId") {
			string dummy1;
			string dummy2;
			return GetFolderSelectByStep(stepId, out dummy1, out dummy2, contactColumnAlias);
		}

		private Update GetUpdateFilteredQuery(Guid currentStepId, Guid nextStepId, CampaignNextStepInfo stepItem,
				Select filteredSubSelectQuery, bool notExistsFilter, bool isImmediately, CampaignNextStepPriority priorityItem) {
			string stepColumnName = stepItem.NextStepTypeId == CampaignConsts.LendingCampaignStepTypeId ?
				"CurrentStepId" : "NextStepId";
			var updateFilteredQuery = new Update(_userConnection, "CampaignTarget")
				.Set(stepColumnName, Column.Parameter(nextStepId))
				.Where("CampaignId").IsEqual(Column.Parameter(stepItem.CampaignId))
				.And("CurrentStepId").IsEqual(Column.Parameter(currentStepId))
				.And("NextStepId").IsNull();
			if (notExistsFilter) {
				updateFilteredQuery.And().Not().Exists(filteredSubSelectQuery);
			} else {
				updateFilteredQuery.And().Exists(new Select(_userConnection)
					.Column("ContactId").From(filteredSubSelectQuery).As("sub")
					.Where("sub", "ContactId").IsEqual("CampaignTarget", "ContactId"));
			}
			if (!isImmediately) {
				updateFilteredQuery.And("ModifiedOn").IsLessOrEqual(
					Column.Parameter(DateTime.UtcNow.AddDays(-priorityItem.DayTransitionCount)));
			}
			return updateFilteredQuery as Update;
		}

		private List<CampaignNextStepPriority> SortPriorityCollection(
				IEnumerable<CampaignNextStepPriority> rawPriorityCollection, bool isImmediately) {
			List<CampaignNextStepPriority> sortedPriorityCollection;
			if (isImmediately) {
				sortedPriorityCollection = rawPriorityCollection.OrderBy(p => p.Priority)
					.ThenBy(d => d.NextStepStartDate).ToList();
			} else {
				sortedPriorityCollection = rawPriorityCollection.OrderBy(p => p.Priority)
					.ThenBy(d => d.DayTransitionCount).ToList();
			}

			return sortedPriorityCollection;
		}

		#endregion

		#region Methods : Protected

		/// <summary>
		/// Sets next step to campaign audience
		/// </summary>
		/// <param name="currentStepId">Unique Id of the source step</param>
		/// <param name="campaignId">Unique Id of the campaign</param>
		/// <returns>Count of affected rows</returns>
		protected virtual int SetNextStep(Guid currentStepId, Guid campaignId) {
			int updateRecordsCount = 0;
			bool isImmediately = true;
			Guid firstStepId = GetCampaignFirstStep(campaignId);
			if (firstStepId == currentStepId) {
				InitNextStepByCurrentStepId(currentStepId, campaignId);
				return updateRecordsCount;
			}
			Guid currentStepTypeId = GetStepTypeByStepId(currentStepId);
			if (currentStepTypeId == CampaignConsts.GoalCampaignStepTypeId ||
				currentStepTypeId == CampaignConsts.ExitCampaignStepTypeId) {
				return updateRecordsCount;
			}
			Collection<CampaignNextStepInfo> stepCollection = GetTargetStepCollection(currentStepId);
			if (stepCollection.Count == 0) {
				return updateRecordsCount;
			}
			// Reset next step
			lock (setNextStepUpdateLocker) {
				ClearNextStep(stepCollection[0].CampaignId, currentStepId);
			}
			Collection<CampaignNextStepPriority> rawPriorityCollection = new Collection<CampaignNextStepPriority>();
			foreach (CampaignNextStepInfo stepItem in stepCollection) {
				if (stepItem.TypeId == CampaignConsts.GoalCampaignStepTypeId ||
						stepItem.TypeId == CampaignConsts.ExitCampaignStepTypeId) {
					var updateQuery = new Update(_userConnection, "CampaignTarget")
						.Set("NextStepId", Column.Parameter(stepItem.NextStepId))
						.Where("CampaignId").IsEqual(Column.Parameter(stepItem.CampaignId))
						.And("CurrentStepId").IsEqual(Column.Parameter(currentStepId));
					lock (setNextStepUpdateLocker) {
						updateRecordsCount += updateQuery.Execute();
					}
					continue;
				}
				List<Guid> filterIds = DeserializeRouteFilterIds(stepItem.JSON);
				double dayTransitionCount = DeserializeDayTransitionCount(stepItem.JSON, _userConnection);
				List<Guid> bulkEmailHyperlinks = DeserializeBulkEmailHyperlinks(stepItem.JSON);
				if (isImmediately && dayTransitionCount >= 0) {
					isImmediately = false;
				}
				// Default arrow (!don't delete!)
				if (filterIds.Count == 0) {
					rawPriorityCollection.Add(
						new CampaignNextStepPriority() {
							FilterId = Guid.Empty,
							NextStepId = stepItem.NextStepId,
							Priority = int.MaxValue,
							NextStepStartDate = DateTime.MaxValue,
							DayTransitionCount = dayTransitionCount,
							BulkEmailHyperlinks = bulkEmailHyperlinks
						});
				}
				foreach (Guid item in filterIds) {
					int filterPriority = _baseFilterCollection.First(e => e.PrimaryColumnValue == item)
						.GetTypedColumnValue<int>("Priority");
					DateTime startDate = stepItem.NextStepStartDate == DateTime.MinValue ?
						DateTime.MaxValue : stepItem.NextStepStartDate;
					rawPriorityCollection.Add(
						new CampaignNextStepPriority() {
							FilterId = item,
							NextStepId = stepItem.NextStepId,
							Priority = filterPriority,
							NextStepStartDate = startDate,
							DayTransitionCount = dayTransitionCount,
							BulkEmailHyperlinks = bulkEmailHyperlinks
						});
				}
			}
			List<CampaignNextStepPriority> sortedPriorityCollection
				= SortPriorityCollection(rawPriorityCollection, isImmediately);
			foreach (CampaignNextStepPriority priorityItem in sortedPriorityCollection) {
				CampaignNextStepInfo stepItem = stepCollection.First(s => s.NextStepId == priorityItem.NextStepId);
				Select filteredSubSelectQuery;
				var notExistsFilter = false;
				if (currentStepId != firstStepId && currentStepTypeId == CampaignConsts.LendingCampaignStepTypeId) {
					filteredSubSelectQuery = WebFormObjectCampaignFilter.GetFilterQuery(_userConnection,
						priorityItem.FilterId, stepItem.RecordId, out notExistsFilter);
				} else {
					IEntitySchemaQueryFilterItem filterItem = null;
					if (priorityItem.FilterId != Guid.Empty) {
						Entity filterEntity = _baseFilterCollection
							.First(e => e.PrimaryColumnValue == priorityItem.FilterId);
						filterItem = DeserializeSourceTargetFilter(filterEntity, stepItem.SysSchemaUId);
						if (filterItem == null) {
							continue;
						}
					}
					filteredSubSelectQuery = GetSourceTargetQuery(stepItem, filterItem, priorityItem);
				}
				Guid nextStepId = stepItem.NextStepId;
				ProcParams procParams = null;
				if (stepItem.NextStepTypeId == CampaignConsts.CreateLeadCampaignStepTypeId) {
					Select selectQuery = GetTargetInfoSelectQuery(currentStepId, nextStepId);
					selectQuery.And().Exists(new Select(_userConnection)
						.Column("ContactId").From(filteredSubSelectQuery).As("sub")
						.Where("sub", "ContactId").IsEqual("CampaignTarget", "ContactId"));
					IEnumerable<KeyValuePair<Guid, Guid>> targetInfoCollection = GetTargetInfoCollection(selectQuery);
					if (targetInfoCollection != null) {
						procParams = new ProcParams {
							LeadStepId = nextStepId,
							TargetInfoCollection = targetInfoCollection
						};
					}
					nextStepId = GetNextVisibleStep(nextStepId);
				}
				var updateFilteredQuery
					= GetUpdateFilteredQuery(currentStepId, nextStepId, stepItem, filteredSubSelectQuery, notExistsFilter,
						isImmediately, priorityItem);
				lock (setNextStepUpdateLocker) {
					updateRecordsCount += updateFilteredQuery.Execute();
				}
				if (procParams != null) {
					CampaignCreateLeadProcessHelper.CreateCampaignLead(_userConnection, procParams.LeadStepId,
						procParams.TargetInfoCollection);
				}
			}
			return updateRecordsCount;
		}

		/// <summary>
		/// Returns Id of the first step
		/// </summary>
		/// <param name="campaignId">Unique Id of the campign.</param>
		protected Guid GetCampaignFirstStep(Guid campaignId) {
			Select select = GetCampaignFirstStepSelect(campaignId);
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Add query of contacts that should by excluded from root query
		/// </summary>
		/// <param name="rootSelect">Root query - new contscts</param>
		/// <param name="exceptSelect">Excluding query</param>
		/// <param name="rootTablename">Root table alias</param>
		/// <param name="rootTableContactColumnName">Name of the column with contact id in root table</param>
		/// <param name="joinAlias">Alias of joined table</param>
		/// <returns></returns>
		protected Select AddExceptSelectJoin(Select rootSelect, Select exceptSelect, string rootTablename,
			string rootTableContactColumnName, string joinAlias) {
			if (exceptSelect != null) {
				return rootSelect.LeftOuterJoin(exceptSelect).As(joinAlias)
					.On(rootTablename, rootTableContactColumnName).IsEqual(joinAlias + "ContactId") as Select;
			}
			return rootSelect;
		}

		/// <summary>
		/// Fills campaign audience by contacts from folder in the audience step
		/// </summary>
		/// <param name="campaignId">Unique Id of the campign.</param>
		protected virtual void SetCampaignTargetFromAudienceFolder(Guid campaignId) {
			Select contactSelect = GetNewContactSelect(campaignId);
			if (contactSelect != null) {
				var contactInsert = new InsertSelect(_userConnection)
					.Into("CampaignTarget")
					.Set("ContactId", "CampaignId")
					.FromSelect(contactSelect);
				contactInsert.Execute();
			}

			SetCurrentStepCamapignAudience(campaignId);
			Select existingSelect = GetCurrentAudienceSelect(campaignId, "ContactId", new Guid[] {}, false);
			existingSelect.Columns.Clear();
			existingSelect.Column(Func.Count("ContactId"));
			new Update(_userConnection, "Campaign")
				.Set("TargetTotal", existingSelect)
				.Where("Id").IsEqual(Column.Parameter(campaignId)).Execute();
			InitNextStepByCampaignId(campaignId);
		}

		/// <summary> 
		/// Returns query to get contacts by folder in step
		/// </summary>
		/// <param name="folderInfo">Parameters of the folder got from GetStepFolderInfo</param>
		/// <param name="contactColumnAlias">Alias of the column with contact id in the resulting query</param>	
		/// <param name="rootTablename">Alias of the root table in the query</param>
		/// <param name="rootTableContactColumnName">Name of the column with contact id in root table</param>		
		protected virtual Select GetFolderSelect(FolderInfo folderInfo, string contactColumnAlias,
			out string rootTablename, out string rootTableContactColumnName) {
			Select folderSelect;
			EntitySchemaQueryColumn recordIdColumn;
			if (folderInfo.FolderTypeId == MarketingConsts.FolderTypeDynamicId) {
				rootTablename = "Contact";
				rootTableContactColumnName = "Id";
				folderSelect = FolderHelper.GetDynamicFolderESQ(rootTablename, folderInfo.SearchData,
					_userConnection, out recordIdColumn).GetSelectQuery(_userConnection);
				folderSelect.Columns.Clear();
				folderSelect.Column(rootTablename, rootTableContactColumnName).As(contactColumnAlias);
			} else {
				rootTablename = "ContactInFolder";
				rootTableContactColumnName = "ContactId";
				folderSelect = FolderHelper.GetStaticFolderESQ("Contact", folderInfo.FolderId, _userConnection,
					out recordIdColumn).GetSelectQuery(_userConnection);
				folderSelect.Columns.Clear();
				folderSelect.Column(rootTablename, rootTableContactColumnName).As(contactColumnAlias);
				folderSelect.Joins.Remove(folderSelect.Joins.FindByAlias("Contact"));
			}
			return folderSelect;
		}

		/// <summary> 
		/// Returns query to get contacts by folder in step
		/// </summary>
		/// <param name="folderInfo">Parameters of the folder got from GetStepFolderInfo</param>
		/// <param name="contactColumnAlias">Alias of the column with contact id in the resulting query</param>	
		protected virtual Select GetFolderSelect(FolderInfo folderInfo, string contactColumnAlias) {
			string dummy1;
			string dummy2;
			return GetFolderSelect(folderInfo, contactColumnAlias, out dummy1, out dummy2);
		}

		/// <summary>
		/// Get folder parameters by step Id
		/// </summary>
		/// <param name="stepId">Unique Id of the step</param>
		/// <returns>Instance of FolderInfo if step has a folder otherwise null</returns>
		protected virtual FolderInfo GetStepFolderInfo(Guid stepId) {
			var select = new Select(_userConnection)
				.Column("CampaignStep", "RecordId")
				.Column("ContactFolder", "FolderTypeId")
				.Column("ContactFolder", "SearchData")
				.From("CampaignStep")
				.LeftOuterJoin("ContactFolder").On("ContactFolder", "Id").IsEqual("CampaignStep", "RecordId")
				.Where("CampaignStep", "Id").IsEqual(Column.Parameter(stepId)) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					if (!dr.Read()) {
						return null;
					}
					var folderId = dr[0] != DBNull.Value ? new Guid(dr[0].ToString()) : Guid.Empty;
					var folderTypeId = dr[1] != DBNull.Value ? new Guid(dr[1].ToString()) : Guid.Empty;
					return new FolderInfo {
						FolderId = folderId,
						FolderTypeId = folderTypeId,
						SearchData = dr.GetValue(dr.GetOrdinal("SearchData")) as byte[]
					};
				}
			}
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Returns time shift (days) from route JSON parameters
		/// </summary>
		/// <param name="jsonValue">route JSON</param>
		public static double DeserializeDayTransitionCount(string jsonValue, UserConnection userConnection) {
			double result = -1;
			if (String.IsNullOrEmpty(jsonValue)) {
				return result;
			}
			JObject jsonData = Json.Deserialize(jsonValue) as JObject;
			if (jsonData == null) {
				return result;
			}
			JObject jsonInfoData = jsonData["addInfo"] as JObject;
			if (jsonInfoData != null) {
				bool isInstantRoute = false;
				JValue launchOption = jsonInfoData["LaunchOptionRadio"] as JValue;
				if (launchOption != null) {
					string launchOptionString = launchOption.ToObject<string>();
					string instantLaunchOption = MarketingConsts.TriggerEmailImmediateLaunchOptionId.ToString();
					string fromCampaignLaunchOption = MarketingConsts.TriggerEmailFromCampaignLaunchOptionId.ToString();

					int isInstantLaunchOption = String.Compare(instantLaunchOption, launchOptionString, true);
					int isFromCampaignLaunchOption = String.Compare(fromCampaignLaunchOption, launchOptionString, true);
					isInstantRoute = isInstantLaunchOption == 0;

					if (isFromCampaignLaunchOption == 0) {
						Guid campaignPeriodTimeValue =
							((jsonInfoData["CampaignPeriodTime"] as JObject)["value"] as JValue).ToObject<Guid>();
						Select campaignPeriodTimeSelect = new Select(userConnection)
							.Column("Time")
							.From("CampaignPeriodTime")
							.Where("Id").IsEqual(Column.Parameter(campaignPeriodTimeValue)) as Select;
						double timeValue = campaignPeriodTimeSelect.ExecuteScalar<double>();
						result = timeValue;
					}
				}
				if (result < 0) {
					JValue dayTransitionCount = jsonInfoData["DayTransitionCount"] as JValue;
					if (dayTransitionCount != null && !isInstantRoute) {
						result = dayTransitionCount.ToObject<double>();
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Actualize steps for given campaign
		/// </summary>
		/// <param name="campaignId">Unique Id of the campaign</param>
		/// <param name="refreshAudience">If audience should be actualized</param>
		public virtual void ActualizeStepsByCampaign(Guid campaignId, bool refreshAudience = false) {
			if (refreshAudience) {
				if (!NeedActualization(campaignId)) {
					return;
				}
				SetCampaignTargetFromAudienceFolder(campaignId);
				UpdateContactsToFinishInCampaignTarget(campaignId);
			}
			Dictionary<Guid, Guid> campaignSteps = GetCampaingsStepsForActualize(new List<Guid>(1) { campaignId });
			MailingUtilities.Log.InfoFormat("[CampaignStepsHandler.ActualizeStepsByCampaign] Steps actualization " +
				"for campaign {0} started.", campaignId);
			_baseFilterCollection = GetBaseCampaignFilterCollection();
			foreach (KeyValuePair<Guid, Guid> step in campaignSteps) {
				int currentCount = SetNextStep(step.Key, campaignId);
				if (currentCount > 0) {
					_rowCount += currentCount;
					if (!_processedCampaigns.Contains(step.Value)) {
						_processedCampaigns.Add(step.Value);
					}
				}
				ActivateReferencedCampaignEmails(campaignId, step.Key);
			}
			MailingUtilities.Log.InfoFormat("[CampaignStepsHandler.ActualizeStepsByCampaign] Steps actualization" +
				" for campaign {0} finished.", campaignId);
		}

		/// <summary>
		/// Sets first step for campaign audience
		/// </summary>
		/// <param name="campaignId">Unique Id of the campaign</param>
		public void SetCurrentStepCamapignAudience(Guid campaignId) {
			Select currentStepIdSelect = GetCampaignFirstStepSelect(campaignId);
			var update = new Update(_userConnection, "CampaignTarget")
				.Set("CurrentStepId", currentStepIdSelect)
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Where("CampaignId").IsEqual(Column.Parameter(campaignId))
				.And("CurrentStepId").IsNull() as Update;
			update.Execute();
		}

		/// <summary>
		/// Returns second step folowing either audience or lending
		/// </summary>
		/// <remarks>
		/// This method returns the any next step of campaign,
		/// including the step, which shall not be set
		/// for the audience of the campaign (for example, step "Create a lead").
		/// </remarks>
		/// <param name="campaignId">Unique Id of the campaign</param>
		public Guid? GetCampaignSecondStepId(Guid campaignId) {
			CampaignNextStepPriority secondStepInfo = GetCampaignSecondStepInfo(campaignId);
			return (secondStepInfo == null || secondStepInfo.DayTransitionCount > 0)
				? null
				: (Guid?)secondStepInfo.NextStepId;
		}

		/// <summary>
		/// Returns collection of the target steps.
		/// </summary>
		/// <param name="stepId">Unique identifier of the campaign step.</param>
		/// <returns>Collection of the "CampaignStep" unique identifiers.</returns>
		public List<Guid> GetTargetSteps(Guid stepId) {
			List<Guid> resultCollection = new List<Guid>();
			Select targetStepsSelect = GetTargetStepsSelect(stepId);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = targetStepsSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid targetId = reader.GetGuid(0);
						resultCollection.Add(targetId);
					}
				}
			}
			return resultCollection;
		}

		/// <summary>
		/// Returns collection of the immediate target steps.
		/// </summary>
		/// <param name="stepId">Unique identifier of the campaign step.</param>
		/// <returns>Collection of the "CampaignStep" unique identifiers.</returns>
		public List<Guid> GetImmediateTargetSteps(Guid stepId) {
			List<Guid> resultCollection = new List<Guid>();
			Select targetStepsSelect = GetImmediateTargetStepsSelect(stepId);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = targetStepsSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid targetId = reader.GetGuid(0);
						resultCollection.Add(targetId);
					}
				}
			}
			return resultCollection;
		}
		#endregion

	}
}
