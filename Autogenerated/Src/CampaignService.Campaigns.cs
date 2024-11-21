namespace BPMSoft.Configuration.CampaignService
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Globalization;
	using System.Threading;
	using System.Threading.Tasks;
	using Newtonsoft.Json.Linq;
	using Quartz;
	using Quartz.Impl.Triggers;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.WebService;
	using BPMSoft.Web.Http.Abstractions;
	using ErrorInfo = BPMSoft.Core.ServiceModelContract.ErrorInfo;

	#region Class: CampaignService

	/// <summary>
	/// Service class for managing of campaigns.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CampaignService
	{

		#region Constants: Private

		private const string CampaignJobGroupName = "Campaign";

		private const string ActualizeStepsCamapignJobName = "CampaignSyncJob";

		private const string ActualizeStepsCamapignProcessName = "CampaignSyncJobProcess";

		private const string ActualizeStepsCamapignCronExpressionPattern = "0 0 6/{0} * * ? *";

		private const int DefaultCampaignSyncJobPocessInterval = 23;

		private const string ActualizeStepsTriggerCampaignCronExpression = "0 0/15 * * * ? *";

		private const int HourMinutesCount = 60;

		private const int DayHourCount = 24;

		private const string RouteJsonAddInfoSection = "addInfo";

		private const string RouteJsonFilterSection = "Filters";

		private const double DefaultMinimumDayTransitionCount = 0.0104;
		
		private const string CampaignHasAlreadyStoppedException = "CampaignHasAlreadyStopped";

		#endregion

		#region Properties: Public

		private UserConnection _userConnection;

		/// <summary>
		/// Gets or sets user connection.
		/// </summary>
		public UserConnection UserConnection {
			get {
				return _userConnection ??
					(_userConnection = HttpContext.Current.Session["UserConnection"] as UserConnection);
			}
			set {
				_userConnection = value;
			}
		}

		/// <summary>
		/// An instance of the <see cref="FolderHelper"/> class.
		/// </summary>
		private FolderHelper _folderHelper;
		public FolderHelper FolderHelper {
			get {
				return _folderHelper ?? (_folderHelper = new FolderHelper());
			}
			set {
				_folderHelper = value;
			}
		}

		/// <summary>
		/// Gets or sets the campaign helper. Instance of <see cref="CampaignHelper"/>.
		/// </summary>
		private CampaignHelper _campaignHelper;
		public CampaignHelper CampaignHelper {
			get {
				return _campaignHelper ?? (_campaignHelper = new CampaignHelper(UserConnection));
			}
			set {
				_campaignHelper = value;
			}
		}

		/// <summary>
		/// Gets or sets campaign engine to manage campaigns created with new designer.
		/// Instance of <see cref="ICampaignEngine"/>.
		/// </summary>
		private ICampaignEngine _campaignEngine;
		[Obsolete("7.12.2 | Property is obsolete and will be removed in upcoming releases")]
		public ICampaignEngine CampaignEngine {
			get {
				return _campaignEngine ?? (_campaignEngine = new CampaignEngine(UserConnection));
			}
			set {
				_campaignEngine = value;
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets inctance of Select for route's JSONs.
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		/// <param name="stepTypeId">Unique identifier of the step.</param>
		private Select GetStepRoutesSelectTemplate(Guid campaignId, Guid? stepTypeId = null) {
			var select = new Select(UserConnection)
			.Column("CampaignStepRoute", "Id").As("RouteId")
			.Column("CampaignStepRoute", "JSON").As("JSON")
			.From("CampaignStep")
			.InnerJoin("CampaignStepRoute").On("CampaignStepRoute", "SourceStepId")
				.IsEqual("CampaignStep", "Id")
			.Where("CampaignStep", "CampaignId").IsEqual(Column.Parameter(campaignId)) as Select;
			if (stepTypeId.HasValue) {
				select.And("CampaignStep", "TypeId").IsEqual(Column.Parameter(stepTypeId));
			}
			return select;
		}

		/// <summary>
		/// Gets minimum period of step route in campaign.
		/// </summary>
		/// <param name="campaignId">unique identifier of campaign</param>
		private double GetMinimumStepRoutePeriod(Guid campaignId) {
			Select jsonSelect = GetStepRoutesSelectTemplate(campaignId);
			double result = -1d;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = jsonSelect.ExecuteReader(dbExecutor)) {
					dr.Read();
					result = CampaignStepsHandler.DeserializeDayTransitionCount(dr.GetColumnValue<string>("JSON"),
						UserConnection);
					while (dr.Read()) {
						double routePeriod =
							CampaignStepsHandler.DeserializeDayTransitionCount(dr.GetColumnValue<string>("JSON"),
								UserConnection);
						if (routePeriod < result) {
							result = routePeriod;
						}
					}
				}
				if (result <= 0) {
					result = DefaultMinimumDayTransitionCount;
				}
			}
			return result;
		}

		/// <summary>
		/// Sets next fire time and execution period for trigger campaign.
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		/// <returns>Count of affected rows.</returns>
		private int UpdateCampaignFireTime(Guid campaignId) {
			var nextFireTime = DateTime.UtcNow;
			var rowsAffected = 0;
			double firePeriod = GetMinimumStepRoutePeriod(campaignId);
			int fireperiodInMinutes = (int)Math.Round((firePeriod * DayHourCount * HourMinutesCount), 
				MidpointRounding.AwayFromZero);
			var actualizePeriod = (int)SysSettings.GetValue(UserConnection, "PeriodActualizeBulkEmailRecipients");
			if ((actualizePeriod * HourMinutesCount) <= fireperiodInMinutes || fireperiodInMinutes <= 0) {
				return rowsAffected;
			}
			var update = new Update(UserConnection, "Campaign")
				.Set("NextFireTime", Column.Parameter(nextFireTime))
				.Set("FirePeriod", Column.Parameter(fireperiodInMinutes))
				.Where("Id").IsEqual(Column.Parameter(campaignId));
			rowsAffected = update.Execute();	
			return rowsAffected;
		}

		/// <summary>
		/// Sets route filters to null if route period greater or equal to response (campaign's campaign)
		/// actualization period.
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		private void UpdateUnconditionedRoutes(Guid campaignId) {
			var actualizePeriod = (int)SysSettings.GetValue(UserConnection, "PeriodActualizeBulkEmailRecipients") / 
				DayHourCount;
			Select routePeriodSelect = GetStepRoutesSelectTemplate(campaignId, 
				CampaignConsts.BulkEmailCampaignStepTypeId);
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = routePeriodSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						var id = new Guid(dr[0].ToString());
						var json = dr.GetColumnValue<string>("JSON");
						double routePeriod = CampaignStepsHandler.DeserializeDayTransitionCount(json, UserConnection);
						if (routePeriod <= 0) {
							routePeriod = DefaultMinimumDayTransitionCount;
						}
						if (routePeriod >= actualizePeriod) {
							continue;
						}
						JObject jsonData = Json.Deserialize(json) as JObject;
						if (jsonData == null) {
							continue;
						}
						JObject jsonInfoData = jsonData[RouteJsonAddInfoSection] as JObject;
						if (jsonInfoData == null) {
							continue;
						}
						JArray jsonFiltersData = jsonInfoData[RouteJsonFilterSection] as JArray;
						if (jsonFiltersData == null) {
							continue;
						}
						jsonFiltersData.Replace(new JArray());
						json = Json.Serialize(jsonData);
						new Update(_userConnection, "CampaignStepRoute")
						 .Set("JSON", Column.Parameter(json))
						 .Where("Id").IsEqual(Column.Parameter(id)).Execute();
					}
				}
			}
		}

		/// <summary>
		/// Creates QRTZ job to launch actualization process of campaign steps.
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		private void CreateActualizeStepsCamapignJob(Guid campaignId) {
			try {
				UserConnection userConnection = UserConnection;
				if (userConnection == null) {
					var appConnection = (AppConnection)HttpContext.Current.Application["AppConnection"];
					userConnection = appConnection.SystemUserConnection;
				}
				RemoveActualizeStepsCampaignJob(campaignId);
				string curCampaignJobName = ActualizeStepsCamapignJobName + campaignId;
				IJobDetail job = AppScheduler.CreateProcessJob(curCampaignJobName, CampaignJobGroupName,
					ActualizeStepsCamapignProcessName, userConnection.Workspace.Name,
					userConnection.CurrentUser.Name, new Dictionary<string, object> { { "CampaignId", campaignId } });
				int affectedRows = UpdateCampaignFireTime(campaignId);
				string cronExpression = string.Empty;
				if (affectedRows > 0) {
					cronExpression = ActualizeStepsTriggerCampaignCronExpression;
				}
				if (string.IsNullOrEmpty(cronExpression)) {
					int interval = (int)SysSettings.GetValue(userConnection, "CampaignSyncJobPocessInterval");
					if (interval <= 0 || interval > 23) {
						interval = DefaultCampaignSyncJobPocessInterval;
					}
					cronExpression = string.Format(ActualizeStepsCamapignCronExpressionPattern, interval);
				}
				var trigger = new CronTriggerImpl(curCampaignJobName + "Trigger",
					CampaignJobGroupName, cronExpression);
				trigger.TimeZone = TimeZoneInfo.Utc;
				AppScheduler.Instance.ScheduleJob(job, trigger);
			} catch (Exception e) {
				CampaignUtilities.Log.ErrorFormat("[CampaignService.CreateActualizeStepsCamapignJob].", e);
			}
		}

		/// <summary>
		/// Delete QRTZ job for given campaign
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		private static void RemoveActualizeStepsCampaignJob(Guid campaignId) {
			string curCampaignJobName = ActualizeStepsCamapignJobName + campaignId;
			IJobDetail jobDetail = FindJob(curCampaignJobName, CampaignJobGroupName);
			if (jobDetail != null) {
				AppScheduler.RemoveJob(curCampaignJobName, CampaignJobGroupName);
			}
		}

		/// <summary>
		/// Activate bulk emails used in campaign
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		/// <param name="userConnection">User connection.</param>
		private void ActivateReferencedCampaignEmails(Guid campaignId, UserConnection userConnection) {
			var storedProcedure = new StoredProcedure(UserConnection, "tsp_ActivateBulkEmailByCampaign");
			storedProcedure.WithParameter(campaignId);
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				storedProcedure.Execute(dbExecutor);
			}
		}

		private MailingService GetMailingService(UserConnection userConnection) {
			return ClassFactory.Get<MailingService>(new ConstructorArgument("userConnection", userConnection));
		}

		private Select GetBaseBulkEmailsSelect(Guid campaignId, UserConnection userConnection) {
			return new Select(userConnection)
				.Column("RecordId")
				.From("CampaignStep")
			.Where("TypeId").IsEqual(Column.Parameter(CampaignConsts.BulkEmailCampaignStepTypeId))
			.And("CampaignId").IsEqual(Column.Parameter(campaignId)) as Select;
		}

		private List<Guid> GetBulkEmailIdentifiers(Guid campaignId, UserConnection userConnection) {
			List<Guid> resultCollection = new List<Guid>();
			Select baseBulkEmailSalect = GetBaseBulkEmailsSelect(campaignId, userConnection);
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = baseBulkEmailSalect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						resultCollection.Add(reader.GetGuid(0));
					}
				}
			}
			return resultCollection;
		}

		private ConfigurationServiceResponse ValidateBulkEmails(Guid campaignId, UserConnection userConnection) {
			List<Guid> identifiers = GetBulkEmailIdentifiers(campaignId, userConnection);
			MailingService mailingService = GetMailingService(userConnection);
			return mailingService.ValidateMessages(identifiers.ToArray());
		}

		/// <summary>
		/// Stop bulk emails used in campaign
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		/// <param name="userConnection">User connection.</param>
		private void DeactivateReferencedCampaignEmails(Guid campaignId, UserConnection userConnection) {
			Select baseBulkEmailSalect = GetBaseBulkEmailsSelect(campaignId, userConnection);
			var update = new Update(userConnection, "BulkEmail")
				.Set("StatusId", Column.Parameter(MarketingConsts.BulkEmailStatusStoppedId))
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Where("Id").In(
					baseBulkEmailSalect
					.And("StatusId").In(
						Column.Parameter(MarketingConsts.BulkEmailStatusPlannedId),
						Column.Parameter(MarketingConsts.BulkEmailStatusStartPlanedId),
						Column.Parameter(MarketingConsts.BulkEmailStatusActiveId),
						Column.Parameter(MarketingConsts.BulkEmailStatusStartsId)
					)
				) as Update;
			update.Execute();
		}

		/// <summary>
		/// Gets step of campaign by type.
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		/// <param name="typeId">Identifier of step type.</param>
		/// <param name="userConnection">User connection.</param>
		private Guid GetFirstCampainStepByType(Guid campaignId, Guid typeId, UserConnection userConnection) {
			var select = new Select(userConnection)
				.Top(1)
				.Column("Id")
				.From("CampaignStep")
				.Where("CampaignId").IsEqual(Column.Parameter(campaignId))
				.And("TypeId").IsEqual(Column.Parameter(typeId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Uppdates current step and set next step to null for finalized campaign.
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		/// <param name="userConnection">User connection.</param>
		private void SetGoalForCampaignStep(Guid campaignId, UserConnection userConnection) {
			Guid goalCampaignStepId = GetFirstCampainStepByType(campaignId, CampaignConsts.GoalCampaignStepTypeId,
					userConnection);
			Guid exitCampaignStepId = GetFirstCampainStepByType(campaignId, CampaignConsts.ExitCampaignStepTypeId,
					userConnection);
			QueryColumnExpression nullParameter =
				Column.Parameter(DBNull.Value, new GuidDataValueType(UserConnection.DataValueTypeManager));
			QueryCase queryCase = new QueryCase();
			QueryCondition queryCondition = new QueryCondition(QueryConditionType.Equal) {
				LeftExpression = new QueryColumnExpression("CurrentStepId")
			};
			queryCondition.RightExpressions.Add(Column.Parameter(goalCampaignStepId));
			queryCase.AddWhenItem(queryCondition, Column.Parameter(goalCampaignStepId));
			queryCondition = new QueryCondition(QueryConditionType.Equal) {
				LeftExpression = new QueryColumnExpression("NextStepId")
			};
			queryCondition.RightExpressions.Add(Column.Parameter(goalCampaignStepId));
			queryCase.AddWhenItem(queryCondition, Column.Parameter(goalCampaignStepId));
			queryCase.ElseExpression = new QueryColumnExpression(Column.Parameter(exitCampaignStepId));
			var update = new Update(userConnection, "CampaignTarget")
				.Set("CurrentStepId", new QueryColumnExpression(queryCase))
				.Set("NextStepId", nullParameter)
				.Where("CampaignId").IsEqual(Column.Parameter(campaignId)) as Update;
			update.Execute();
		}

		/// <summary>
		/// Checks if bulk email contains an empty template
		/// </summary>
		/// <param name="bulkEmailIds">array of email's ids</param>
		private bool IsEmptyTemplateExist(Guid[] bulkEmailIds) {
			var selectCount = new Select(UserConnection)
				.Column(Func.Count("Id"))
				.From("BulkEmail")
				.Where("Id").In(Column.Parameters(bulkEmailIds))
				.And("TemplateBody").IsEqual(Column.Parameter(string.Empty)) as Select;
			int count = selectCount.ExecuteScalar<int>();
			return count > 0;
		}
		
		private void UpdateCampaignStatus(Guid campaignId, UserConnection userConnection, string dateFieldName,
				Guid statusId) {
			var fields = new Dictionary<string, object>();
			fields["CampaignStatusId"] = statusId;
			fields[dateFieldName] = DateTime.UtcNow;
			CampaignHelper.SetCampaignFields(campaignId, fields, userConnection);
		}

		private CampaignConfigurationServiceResponse GetResponse(CampaignSchema schema, bool isWarningsIgnore) {
			return new CampaignConfigurationServiceResponse {
				Success = schema.IsSchemaValid(isWarningsIgnore),
				ErrorInfo = new ErrorInfo {
					Message = schema.ErrorValidationMessage
				},
				WarningInfo = new WarningInfo {
					Message = schema.WarningValidationMessage
				}
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Finds QRTZ job by name and group name.
		/// </summary>
		/// <param name="jobName">Name of job.</param>
		/// <param name="jobGroupName">Name of group.</param>
		public static IJobDetail FindJob(string jobName, string jobGroupName) {
			var key = new JobKey(jobName, jobGroupName);
			IJobDetail jobDetail = AppScheduler.Instance.GetJobDetail(key);
			return jobDetail;
		}

		/// <summary>
		/// Launches given campaign.
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "LaunchCampaign", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse LaunchCampaign(Guid campaignId) {
			UserConnection userConnection = UserConnection;
			ConfigurationServiceResponse response = ValidateBulkEmails(campaignId, userConnection);
			if (!response.Success) {
				return response;
			}
			CreateActualizeStepsCamapignJob(campaignId);
			UpdateCampaignStatus(campaignId, userConnection, "StartDate", CampaignConsts.RunCampaignStatusId);
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			Task.Factory.StartNew(() => {
				try {
					Thread.CurrentThread.CurrentCulture = culture;
					UpdateUnconditionedRoutes(campaignId);
					var campaignStepsHandler =
						ClassFactory.Get<CampaignStepsHandler>(new ConstructorArgument("userConnection", userConnection));
					campaignStepsHandler.SetCurrentStepCamapignAudience(campaignId);
					ActivateReferencedCampaignEmails(campaignId, userConnection);
					campaignStepsHandler.ActualizeStepsByCampaign(campaignId, true);
				} catch (Exception e) {
					CampaignUtilities.Log.ErrorFormat("[CampaignService.LaunchCampaign].", e);
				}
			});
			return response;
		}

		/// <summary>
		/// Launches given campaign with new engine.
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign created in new designer.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "v2/LaunchCampaign", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public CampaignConfigurationServiceResponse LaunchCampaignV2(Guid campaignId, bool ignoreWarnings = false) {
			try {
				CampaignSchema schema = CampaignHelper.GetCampaignSchema(campaignId);
				if (ignoreWarnings) {
					CampaignEventFacade.StartWithWarnings(UserConnection, schema);
				} else {
					CampaignEventFacade.Start(UserConnection, schema);
				}
				return GetResponse(schema, ignoreWarnings);
			} catch (Exception e) {
				return new CampaignConfigurationServiceResponse(e);
			}
		}

		/// <summary>
		/// Finalize given campaign
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CompleteCampaign", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CompleteCampaign(Guid campaignId) {
			UserConnection userConnection = UserConnection;
			UpdateCampaignStatus(campaignId, UserConnection, "EndDate", CampaignConsts.CompletedCampaignStatusId);
			RemoveActualizeStepsCampaignJob(campaignId);
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			Task.Factory.StartNew(() => {
				Thread.CurrentThread.CurrentCulture = culture;
				var campaignStepsHandler =
					ClassFactory.Get<CampaignStepsHandler>(new ConstructorArgument("userConnection", userConnection));
				campaignStepsHandler.ActualizeStepsByCampaign(campaignId, false);
				DeactivateReferencedCampaignEmails(campaignId, userConnection);
				SetGoalForCampaignStep(campaignId, userConnection);
				CampaignHelper.UpdateCampaignTargetAchieve(campaignId, userConnection);
			});
		}

		/// <summary>
		/// Completes given campaign with new engine.
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign created in new designer.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "v2/CompleteCampaign", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public CampaignConfigurationServiceResponse CompleteCampaignV2(Guid campaignId) {
			try {
				var campaignInfo = CampaignHelper.GetCampaignInfo(campaignId);
				if (campaignInfo.CampaignStatusId == CampaignConsts.StoppingCampaignStatusId
						|| campaignInfo.CampaignStatusId == CampaignConsts.CompletedCampaignStatusId) {
					string errorText = CampaignHelper
						.GetLczStringValue(nameof(CampaignService), CampaignHasAlreadyStoppedException);
					string message = string.Format(errorText, campaignId);
					throw new InvalidOperationException(message);
				}
				var schema = CampaignHelper.GetCampaignSchema(campaignId);
				CampaignEventFacade.Finalize(UserConnection, schema);
				if (!campaignInfo.InProgress) {
					CampaignEventFacade.Stop(UserConnection, schema);
				}
			} catch (Exception e) {
				return new CampaignConfigurationServiceResponse(e);
			}
			return new CampaignConfigurationServiceResponse();
		}

		/// <summary>
		/// Check if given bulk emails have an empty template.
		/// </summary>
		/// <param name="bulkEmailIds">Array of email's ids.</param>
		/// <returns>False if at least one email contains an empty template.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "EmptyTemplateValidation", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool EmptyTemplateValidation(Guid[] bulkEmailIds) {
			return IsEmptyTemplateExist(bulkEmailIds);
		}

		/// <summary>
		/// Excludes participants from campaign.
		/// </summary>
		/// <param name="campaignId">The campaign identifier.</param>
		/// <param name="campaignTargetIds">The campaign target ids.</param>
		/// <returns>Count of affected rows.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ExcludeFromCampaign", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int ExcludeFromCampaign(Guid campaignId, Guid[] campaignTargetIds) {
			Guid exitFromCampaignId = GetFirstCampainStepByType(campaignId, CampaignConsts.ExitCampaignStepTypeId,
				UserConnection);
			QueryColumnExpression nullParameter =
				Column.Parameter(DBNull.Value, new GuidDataValueType(UserConnection.DataValueTypeManager));
			if (exitFromCampaignId.IsEmpty()) {
				return 0;
			}
			var excludeQuery = new Update(UserConnection, "CampaignTarget")
				.Set("NextStepId", nullParameter)
				.Set("CurrentStepId", Column.Parameter(exitFromCampaignId))
				.Where("Id").In(Column.Parameters(campaignTargetIds))
				.And("CurrentStepId").Not().IsEqual(Column.Parameter(exitFromCampaignId));
			return excludeQuery.Execute();
		}

		/// <summary>
		/// Returns entities folder info model of type <see cref="FolderInfoModel"/>.
		/// </summary>
		/// <param name="folderId">The folder identifier.</param>
		/// <returns>Folder data info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetContactFolderInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public FolderInfoModel GetContactFolderInfo(Guid folderId, string folderSchemaName = null) {
			return FolderHelper.GetFolderInfo(folderSchemaName ?? "ContactFolder", folderId, UserConnection);
		}

		/// <summary>
		/// Service method which returns next fire time for campaign with id <paramref name="campaignId"/>
		/// starting from now.
		/// </summary>
		/// <param name="campaignId">Campaign identifier.</param>
		/// <param name="includeTimezoneOffset">A flag that indicates if necessary to add current user
		/// time zone offset in minutes.</param>
		/// <returns>Instance of <see cref="CampaignNextFireTimeResponse"/> which includes information 
		/// about campaign next fire time.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCampaignNextFireTime", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public CampaignNextFireTimeResponse GetCampaignNextFireTime(Guid campaignId, bool includeTimezoneOffset) {
			var campaignScheduler = new CampaignTimeScheduler(UserConnection);
			var nextFireTime = campaignScheduler.GetCampaignNextFireTime(campaignId, includeTimezoneOffset);
			var response = new CampaignNextFireTimeResponse {
				NextFireTime = DateTimeDataValueType.Serialize(nextFireTime, TimeZoneInfo.Utc)
			};
			return response;
		}

		/// <summary>
		/// Service method which calculates campaign participant analytics.
		/// </summary>
		/// <param name="request">Instance of <see cref="ParticipantsAnalyticsRequest"/> which contains 
		/// parameters for calculation.</param>
		/// <returns>Instance of <see cref="ParticipantsAnalyticsResponse"/> which contains analytics 
		/// for each campaign item which contains participants.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetParticipantsAnalytics", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ParticipantsAnalyticsResponse GetParticipantsAnalytics(ParticipantsAnalyticsRequest request) {
			var analyticsProvider = new CampaignAnalyticsProvider(UserConnection);
			return analyticsProvider.GetParticipantsAnalytics(request);
		}

		#endregion

	}

	#endregion

}

