namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Enums;
	using BPMSoft.Core.DB;
	using BPMSoft.Nui.ServiceModel.WebService;
	using CoreCampaignConsts = Core.Campaign.CampaignConstants;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;
	using global::Common.Logging;

	#region Class: CampaignJobExecutor

	/// <summary>
	/// Provides methods to execute jobs for campaign actions.
	/// </summary>
	public class CampaignJobExecutor : IJobExecutor
	{

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Properties: Private

		private ILog _logger;
		private ILog Logger {
			get {
				return _logger ?? (_logger = LogManager.GetLogger(CoreCampaignConsts.CampaignLoggerName));
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets campaign engine. Instance of <see cref="ICampaignEngine"/>.
		/// </summary>
		private ICampaignEngine _campaignEngine;
		public ICampaignEngine CampaignEngine {
			get {
				return _campaignEngine ?? (_campaignEngine = new CampaignEngine(_userConnection));
			}
			set {
				_campaignEngine = value;
			}
		}

		/// <summary>
		/// Gets or sets the campaign job dispatcher. Instance of <see cref="ICampaignJobDispatcher"/>.
		/// </summary>
		private ICampaignJobDispatcher _campaignJobDispatcher;
		public ICampaignJobDispatcher CampaignJobDispatcher {
			get {
				return _campaignJobDispatcher ?? (_campaignJobDispatcher = new CampaignJobDispatcher(_userConnection));
			}
			set {
				_campaignJobDispatcher = value;
			}
		}

		/// <summary>
		/// Gets or sets the campaign time scheduler. Instance of <see cref="ICampaignTimeScheduler"/>.
		/// </summary>
		private ICampaignTimeScheduler _campaignTimeScheduler;
		public ICampaignTimeScheduler CampaignTimeScheduler {
			get {
				return _campaignTimeScheduler ?? (_campaignTimeScheduler = new CampaignTimeScheduler(_userConnection));
			}
			set {
				_campaignTimeScheduler = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the campaign helper. Instance of <see cref="CampaignHelper"/>.
		/// </summary>
		private CampaignHelper _campaignHelper;
		public CampaignHelper CampaignHelper {
			get {
				return _campaignHelper ?? (_campaignHelper = new CampaignHelper(_userConnection));
			}
			set {
				_campaignHelper = value;
			}
		}

		/// <summary>
		/// Gets or sets the reminding utilities. Instance of <see cref="RemindingUtilities"/>.
		/// </summary>
		private RemindingUtilities _remindingUtilities;
		public RemindingUtilities RemindingUtilities {
			get {
				return _remindingUtilities ?? (_remindingUtilities = new RemindingUtilities());
			}
			set {
				_remindingUtilities = value;
			}
		}

		/// <summary>
		/// Gets or sets campaign logger. Instance of <see cref="ICampaignExecutionLogger"/>.
		/// </summary>
		private ICampaignExecutionLogger _campaignLogger;
		public ICampaignExecutionLogger CampaignLogger {
			get {
				return _campaignLogger ?? (_campaignLogger = new CampaignExecutionLogger(_userConnection));
			}
			set {
				_campaignLogger = value;
			}
		}

		#endregion

		#region Methods: Private

		private T GetTypedParameter<T>(string name, IDictionary<string, object> parameters) {
			if (!parameters.ContainsKey(name)) {
				throw new ArgumentException("Parameter with such name is not found.", name);
			}
			ValidateParameter<T>(parameters[name], name);
			return (T)parameters[name];
		}

		private void ValidateParameter<T>(object parameter, string name) {
			if (parameter == null) {
				throw new ArgumentException("Parameter is null.", name);
			}
			if (parameter.GetType() != typeof(T)) {
				throw new ArgumentException("Parameter type is not as expected.", name);
			}
			if (parameter is Guid && (Guid)parameter == Guid.Empty) {
				throw new ArgumentException("Parameter is empty guid.", name);
			}
		}
		
		private void SetCampaignInProgress(Guid campaignId, bool inProgressValue, DateTime? scheduledDate) {
			var update = new Update(_userConnection, "Campaign")
				.Set("InProgress", Column.Parameter(inProgressValue))
				.Set("ModifiedById", Column.Parameter(_userConnection.CurrentUser.ContactId))
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Update;
			if (inProgressValue) {
				update.Set("NextFireTime", Column.Parameter(null, "DateTime"));
			}
			if (scheduledDate != null) {
				update.Set("PrevExecutedOn", Column.Parameter(scheduledDate));
			}
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private void SetCampaignNextFireTime(Guid campaignId, DateTime scheduledDate) {
			var update = new Update(_userConnection, "Campaign")
				.Set("NextFireTime", Column.Parameter(scheduledDate))
				.Set("ModifiedById", Column.Parameter(_userConnection.CurrentUser.ContactId))
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

        private void ChangeStatusToActive(Guid campaignSchemaUId) {
			var update = new Update(_userConnection, "Campaign")
				.Set("CampaignStatusId", Column.Parameter(CampaignConsts.RunCampaignStatusId))
				.Set("StartDate", Column.Parameter(DateTime.UtcNow))
				.Set("InProgress", Column.Parameter(true))
				.Set("ModifiedById", Column.Parameter(_userConnection.CurrentUser.ContactId))
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Where("CampaignSchemaUId").IsEqual(Column.Parameter(campaignSchemaUId)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private DateTime? GetScheduledStopDate(Guid campaignId) {
			DateTime? result = null;
			var stopDateSelect = new Select(_userConnection)
				.Column("ScheduledStopDate")
				.Column("ScheduledStopModeId")
				.From("Campaign")
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Select;
			stopDateSelect.SpecifyNoLockHints();
			stopDateSelect.ExecuteReader(dr => {
				var scheduledStopModeId = dr.GetColumnValue<Guid>("ScheduledStopModeId");
				if (scheduledStopModeId == CampaignConsts.CampaingSpecifiedTimeModeId) {
					result = dr.GetColumnValue<DateTime>("ScheduledStopDate");
				}
			});
			return result;
		}

		private Guid GetCampaignStatusId(Guid campaignId) {
			var select = new Select(_userConnection)
				.Column("CampaignStatusId")
				.From("Campaign")
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<Guid>();
		}

		private void CreateNotification(Guid campaignId, string notification) {
			var campaign = CampaignHelper.GetCampaign(campaignId, "Owner");
			var config = new RemindingConfig(campaign.Schema.UId) {
				AuthorId = _userConnection.CurrentUser.ContactId,
				ContactId = campaign.OwnerId,
				SubjectId = campaignId,
				Description = notification
			};
			RemindingUtilities.CreateReminding(_userConnection, config);
		}

		private void LogMisfiredRun(CoreCampaignSchema campaignSchema,
				CampaignExecutionLatenessConfig latenessConfig, DateTime scheduledDate) {
			string message;
			switch (latenessConfig.Lateness) {
				case CampaignExecutionLateness.MisfiredTimeConditionElements: {
					string errorText = CampaignHelper
						.GetLczStringValue(nameof(CampaignJobExecutor), "MisfiredTimeConditionElementError");
					message = string.Format(errorText, scheduledDate.ToString("g"),
						TimeSpanToString(latenessConfig.LatenessTime),
						GetElementsNames(latenessConfig.MisfiredTimeConditionElements));
					LogError(campaignSchema.EntityId, CampaignConsts.CampaignLogTypeSkippedElement, message);
					break;
				}
				case CampaignExecutionLateness.Critical: {
					string errorText = CampaignHelper
						.GetLczStringValue(nameof(CampaignJobExecutor), "MisfiredCampaignExecutionError");
					message = string.Format(errorText, scheduledDate.ToString("g"),
						TimeSpanToString(latenessConfig.LatenessTime));
					LogError(campaignSchema.EntityId, CampaignConsts.CampaignLogTypeSkippedRun, message);
					break;
				}
				case CampaignExecutionLateness.CriticalAndMisfiredTimeConditionElements: {
					string errorText = CampaignHelper
						.GetLczStringValue(nameof(CampaignJobExecutor), "CriticalExecutionLatenessError");
					message = string.Format(errorText, TimeSpanToString(latenessConfig.LatenessTime),
						TimeSpanToString(TimeSpan.FromMinutes(campaignSchema.CriticalExecutionLateness)),
						GetElementsNames(latenessConfig.MisfiredTimeConditionElements));
					LogError(campaignSchema.EntityId, CampaignConsts.CampaignLogTypeCriticalLateness, message);
					string notificationText = CampaignHelper
						.GetLczStringValue(nameof(CampaignJobExecutor), "CriticalLatenessNotification");
					string notification = string.Format(notificationText, campaignSchema.Caption,
						TimeSpanToString(TimeSpan.FromMinutes(campaignSchema.CriticalExecutionLateness)));
					CreateNotification(campaignSchema.EntityId, notification);
					break;
				}
				default:
					break;
			}
		}
		
		private void RunCampaign(CoreCampaignSchema campaignSchema,
				CampaignSchemaExecutionStrategy schemaGeneratorStrategy, DateTime scheduledFireTime) {
			try {
				DateTime? stopDate = GetScheduledStopDate(campaignSchema.EntityId);
				var latenessConfig = CampaignTimeScheduler.GetLatenessConfig(campaignSchema, scheduledFireTime);
				LogMisfiredRun(campaignSchema, latenessConfig, scheduledFireTime);
				if (stopDate <= DateTime.UtcNow) {
					LogAction(campaignSchema.EntityId, CampaignConsts.CampaignLogTypeStoppedBySchedule);
				}
				if (latenessConfig.Lateness == CampaignExecutionLateness.CriticalAndMisfiredTimeConditionElements ||
						stopDate <= DateTime.UtcNow) {
					CampaignEventFacade.Finalize(_userConnection, campaignSchema);
					CampaignEventFacade.Stop(_userConnection, campaignSchema);
					return;
				}
				if (latenessConfig.Lateness == CampaignExecutionLateness.NoMisfire) {
					campaignSchema.CampaignConfiguration["ScheduledUtcFireTime"] = scheduledFireTime;
					var config = new CampaignExecutionConfig {
						CurrentFireTime = scheduledFireTime,
						ExecutionStrategy = schemaGeneratorStrategy
					};
					CampaignEngine.Run(campaignSchema, config);
				} else {
					scheduledFireTime = DateTime.UtcNow;
				}
			} catch (Exception e) {
				string message = CampaignHelper.GetLczStringValue(nameof(CampaignJobExecutor), "ExecutionException");
				Logger.Error(message, e);
			}
			TryScheduleNextJob(campaignSchema, scheduledFireTime);
		}

		private void StartCampaign(CoreCampaignSchema campaignSchema, DateTime scheduledFireTime) {
			var schemaManager = (CampaignSchemaManager)_userConnection.GetSchemaManager("CampaignSchemaManager");
			ChangeStatusToActive(campaignSchema.UId);
			schemaManager.ActualizeCampaignSchemaInfo(campaignSchema, _userConnection);
			LogAction(campaignSchema.EntityId, CampaignConsts.CampaignLogTypeCampaignStart);
			RunCampaign(campaignSchema, CampaignSchemaExecutionStrategy.DefaultPeriod, scheduledFireTime);
		}

		private void StopCampaignByScheduledDate(CoreCampaignSchema campaignSchema) {
			var campaignInfo = CampaignHelper.GetCampaignInfo(campaignSchema.EntityId);
			if (campaignInfo.CampaignStatusId == CampaignConsts.RunCampaignStatusId) {
				CampaignEventFacade.Finalize(_userConnection, campaignSchema);
				LogAction(campaignSchema.EntityId, CampaignConsts.CampaignLogTypeStoppedBySchedule);
				CampaignEventFacade.Stop(_userConnection, campaignSchema);
			}
		}

		private void LogAction(Guid campaignId, Guid actionId) {
			var logInfo = new CampaignLogInfo {
				CampaignId = campaignId,
				StartDate = DateTime.UtcNow,
				Action = actionId,
				IsSuccess = true
			};
			CampaignLogger.LogAction(logInfo);
		}

		private void LogError(Guid campaignId, Guid actionId, string message) {
			var logInfo = new CampaignLogInfo {
				CampaignId = campaignId,
				StartDate = DateTime.UtcNow,
				Action = actionId,
				IsSuccess = false,
				ErrorText = message
			};
			CampaignLogger.LogAction(logInfo);
		}

		private string GetElementsNames(IEnumerable<CampaignSchemaElement> elements) {
			return string.Join(", ", elements.Select(x => "\"" + x.Caption + "\""));
		}

		private string TimeSpanToString(TimeSpan span) {
			return string.Join(" ", GetReadableParts(span).Where(str => !string.IsNullOrEmpty(str)));
		}

		private IEnumerable<string> GetReadableParts(TimeSpan span) {
			int days = (int)Math.Floor(span.TotalDays);
			yield return days != 0 ? string.Format(CampaignHelper
						.GetLczStringValue("CampaignJobExecutor", "DayPartInPeriod"), days) : string.Empty;
			yield return span.Hours != 0 ? string.Format(CampaignHelper
						.GetLczStringValue("CampaignJobExecutor", "HourPartInPeriod"), span.Hours) : string.Empty;
			yield return span.Minutes != 0 ? string.Format(CampaignHelper
						.GetLczStringValue("CampaignJobExecutor", "MinutePartInPeriod"), span.Minutes) : string.Empty;
		}

		private bool TryScheduleNextJob(CoreCampaignSchema campaignSchema, DateTime? scheduledDate) {
			SetCampaignInProgress(campaignSchema.EntityId, false, scheduledDate);
			var jobConfig = CampaignTimeScheduler.GetNextFireTime(campaignSchema, scheduledDate);
			if (jobConfig.ScheduledAction == CampaignScheduledAction.Stop) {
				CampaignEventFacade.Stop(_userConnection, campaignSchema);
				return false;
			}
			var latenessConfig = CampaignTimeScheduler.GetLatenessConfig(campaignSchema, jobConfig.Time);
			LogMisfiredRun(campaignSchema, latenessConfig, jobConfig.Time);
			if (latenessConfig.Lateness == CampaignExecutionLateness.CriticalAndMisfiredTimeConditionElements) {
				CampaignEventFacade.Stop(_userConnection, campaignSchema);
				return false;
			}
			if (latenessConfig.Lateness == CampaignExecutionLateness.Critical ||
					latenessConfig.Lateness == CampaignExecutionLateness.MisfiredTimeConditionElements) {
				jobConfig = CampaignTimeScheduler.GetNextFireTime(campaignSchema, DateTime.UtcNow);
			}
			if (jobConfig.ScheduledAction != CampaignScheduledAction.ScheduledStop) {
				SetCampaignNextFireTime(campaignSchema.EntityId, jobConfig.Time);
			}
			CampaignJobDispatcher.ScheduleJob(campaignSchema, jobConfig);
			return true;
		}

		private void RunCampaignWithInProgress(CoreCampaignSchema campaignSchema,
				CampaignSchemaExecutionStrategy strategy, DateTime scheduledFireTime) {
			var campaignStatusId = GetCampaignStatusId(campaignSchema.EntityId);
			if (campaignStatusId == CampaignConsts.RunCampaignStatusId) {
				SetCampaignInProgress(campaignSchema.EntityId, true, null);
				RunCampaign(campaignSchema, strategy, scheduledFireTime);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Processes job for campaign action.
		/// <param name="userConnection">The user connection.</param>
		/// <param name="parameters">Job parameters.</param>
		/// </summary>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			try {
				_userConnection = userConnection;
				var schemaUid = GetTypedParameter<Guid>("CampaignSchemaUId", parameters);
				var scheduledFireTime = GetTypedParameter<DateTime>("ScheduledUtcFireTime", parameters);
				var action = (CampaignScheduledAction)GetTypedParameter<int>("ScheduledAction", parameters);
				var schemaGeneratorStrategy =
					GetTypedParameter<CampaignSchemaExecutionStrategy>("SchemaGeneratorStrategy", parameters);
				var schemaManager =
					(CampaignSchemaManager)_userConnection.GetSchemaManager("CampaignSchemaManager");
				CoreCampaignSchema campaignSchema = schemaManager.GetSchemaInstance(schemaUid);
				switch (action) {
					case CampaignScheduledAction.ScheduledStart:
						StartCampaign(campaignSchema, scheduledFireTime);
						break;
					case CampaignScheduledAction.Start:
						RunCampaign(campaignSchema, schemaGeneratorStrategy, scheduledFireTime);
						break;
					case CampaignScheduledAction.Run:
						RunCampaignWithInProgress(campaignSchema, schemaGeneratorStrategy, scheduledFireTime);
						break;
					case CampaignScheduledAction.Stop:
						CampaignEventFacade.Stop(_userConnection, campaignSchema);
						break;
					case CampaignScheduledAction.ScheduledStop:
						StopCampaignByScheduledDate(campaignSchema);
						break;
					default:
						break;
				}
			} catch (Exception ex) {
				string message = CampaignHelper.GetLczStringValue(nameof(CampaignJobExecutor), "ExecutionException");
				Logger.Error(message, ex);
				throw;
			}
		}

		/// <summary>
		/// Schedules next campaign job if it is possible.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="campaignSchemaUId">Unique identifier of campaign schema.</param>
		/// <param name="scheduledDate">Time of the previous campaign run.
		/// It can be null when need calculate next fire time relatively to current time.</param>
		/// <returns>Returns true when campaign job is scheduled.</returns>
		public virtual bool TryScheduleNextJob(UserConnection userConnection, Guid campaignSchemaUId,
				DateTime? scheduledDate) {
			_userConnection = userConnection;
			try {
				var schemaManager =
					(CampaignSchemaManager)_userConnection.GetSchemaManager(nameof(CampaignSchemaManager));
				CoreCampaignSchema campaignSchema = schemaManager.GetSchemaInstance(campaignSchemaUId);
				return TryScheduleNextJob(campaignSchema, scheduledDate);
			} catch (Exception e) {
				string message = string.Format(CampaignHelper
					.GetLczStringValue(nameof(CampaignJobExecutor), "ScheduleNextJobError"), campaignSchemaUId);
				Logger.Error(message, e);
				return false;
			}
		}

		#endregion

	}

	#endregion

}

