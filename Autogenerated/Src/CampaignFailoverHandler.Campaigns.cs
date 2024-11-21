namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;
	using global::Common.Logging;
	using CoreSysSettings = Core.Configuration.SysSettings;
	using CoreCampaignConsts = Core.Campaign.CampaignConstants;
	using Quartz.Impl.Matchers;
	using Quartz;

	#region Class: CampaignFailoverHandler

	/// <summary>
	/// Provides methods to handle broken campaigns.
	/// </summary>
	public class CampaignFailoverHandler : IFailoverHandler
	{

		#region Class: CampaignModel

		/// <summary>
		/// Defines campaigns parameters for failover.
		/// </summary>
		private class CampaignModel
		{

			#region Constructors: Internal

			internal CampaignModel(Guid id, Guid statusId, bool inProgress, Guid schemaUId) {
				Id = id;
				StatusId = statusId;
				InProgress = inProgress;
				SchemaUId = schemaUId;
			}

			#endregion

			#region Properties: Internal

			/// <summary>
			/// Identifier.
			/// </summary>
			internal Guid Id {
				get;
				set;
			}

			/// <summary>
			/// Status.
			/// </summary>
			internal Guid StatusId {
				get;
				set;
			}

			/// <summary>
			/// In progress sign.
			/// </summary>
			internal bool InProgress {
				get;
				set;
			}

			/// <summary>
			/// Schema identifier.
			/// </summary>
			internal Guid SchemaUId {
				get;
				set;
			}

			/// <summary>
			/// Scheduled sign for working campaign.
			/// </summary>
			internal bool IsQrtzTriggerExist {
				get;
				set;
			}

			#endregion

		}

		#endregion

		#region Class: TriggerInfo

		private class TriggerInfo
		{

			#region Properties: Internal

			internal string Name {
				get; set;
			}

			#endregion

		}

		#endregion

		#region Constants: Private

		private const string _campaignTriggerNameRegexString = @"^Campaign(?<CampaignId>[0-9a-f]{8}[-]?([0-9a-f]{4}[-]?){3}"
			+ @"[0-9a-f]{12})(\d{1,2}[\/.]){2}\d{4}\d{1,2}[:]\d{2}";

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Properties: Private

		private ILog _logger;
		private ILog Logger => _logger ?? (_logger = LogManager.GetLogger(CoreCampaignConsts.CampaignLoggerName));

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the campaign helper. Instance of <see cref="CampaignHelper"/>.
		/// </summary>
		private CampaignHelper _campaignHelper;
		public CampaignHelper CampaignHelper {
			get => _campaignHelper ?? (_campaignHelper = new CampaignHelper(_userConnection));
			set => _campaignHelper = value;
		}

		/// <summary>
		/// Gets or sets the campaign job dispatcher. Instance of <see cref="CampaignJobDispatcher"/>.
		/// </summary>
		private ICampaignJobDispatcher _campaignJobDispatcher;
		public ICampaignJobDispatcher CampaignJobDispatcher {
			get => _campaignJobDispatcher ?? (_campaignJobDispatcher = new CampaignJobDispatcher(_userConnection));
			set => _campaignJobDispatcher = value;
		}

		/// <summary>
		/// Gets or sets the campaign queue monitoring job dispatcher.
		/// Instance of <see cref="CampaignQueueMonitoringJobDispatcher"/>.
		/// </summary>
		private CampaignQueueMonitoringJobDispatcher _campaignQueueMonitoringJobDispatcher;
		public CampaignQueueMonitoringJobDispatcher CampaignQueueMonitoringJobDispatcher {
			get => _campaignQueueMonitoringJobDispatcher
				?? (_campaignQueueMonitoringJobDispatcher = new CampaignQueueMonitoringJobDispatcher { 
					UserConnection = _userConnection.AppConnection.SystemUserConnection
				});
			set => _campaignQueueMonitoringJobDispatcher = value;
		}

		/// <summary>
		/// Gets or sets campaign logger. Instance of <see cref="ICampaignExecutionLogger"/>.
		/// </summary>
		private static ICampaignExecutionLogger _campaignLogger;
		public ICampaignExecutionLogger CampaignLogger {
			get =>
				_campaignLogger ?? (_campaignLogger = ClassFactory.Get<ICampaignExecutionLogger>(new ConstructorArgument(
					"userConnection",
					_userConnection)));
			set => _campaignLogger = value;
		}

		/// <summary>
		/// Gets or sets the campaign job executor. Instance of <see cref="CampaignJobExecutor"/>.
		/// </summary>
		private CampaignJobExecutor _campaignJobExecutor;
		public CampaignJobExecutor CampaignJobExecutor {
			get => _campaignJobExecutor ?? (_campaignJobExecutor = new CampaignJobExecutor());
			set => _campaignJobExecutor = value;
		}

		#endregion

		#region Methods: Private

		private List<CampaignModel> GetWorkingCampaigns() {
			var campaigns = new List<CampaignModel>();
			var selectQuery = new Select(_userConnection)
				.Column("Id")
				.Column("CampaignStatusId")
				.Column("InProgress")
				.Column("CampaignSchemaUId")
				.From("Campaign")
				.Where("CampaignSchemaUId").Not().IsNull()
				.And("CampaignStatusId")
				.In(Column.Parameter(CampaignConsts.RunCampaignStatusId),
					Column.Parameter(CampaignConsts.StoppingCampaignStatusId),
					Column.Parameter(CampaignConsts.ScheduledCampaignStatusId)) as Select;
			selectQuery.SpecifyNoLockHints();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectQuery.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						CampaignModel campaign = new CampaignModel(
							reader.GetColumnValue<Guid>("Id"),
							reader.GetColumnValue<Guid>("CampaignStatusId"),
							reader.GetColumnValue<bool>("InProgress"),
							reader.GetColumnValue<Guid>("CampaignSchemaUId"));
						campaigns.Add(campaign);
					}
				}
			}
			return campaigns;
		}

		private IEnumerable<TriggerInfo> GetCampaignsExistingTriggers() {
			var groupMatcher = GroupMatcher<TriggerKey>.GroupEquals(CampaignConsts.CampaignJobGroupName);
			var triggerKeys = CampaignJobDispatcher.CampaignScheduler.GetTriggerKeys(groupMatcher);
			if (CampaignJobDispatcher.CampaignScheduler != AppScheduler.Instance) {
				var defaultKeys = AppScheduler.Instance.GetTriggerKeys(groupMatcher);
				triggerKeys.AddRange(defaultKeys);
			}
			return triggerKeys.Select(k => new TriggerInfo { Name = k.Name });
		}

		private void FillIsScheduledFlag(ref IEnumerable<CampaignModel> campaigns) {
			var triggersInfo = GetCampaignsExistingTriggers();
			foreach (var triggerInfo in triggersInfo) {
				Regex campaignTriggerNamePattern = new Regex(_campaignTriggerNameRegexString);
				Match matchResult = campaignTriggerNamePattern.Match(triggerInfo.Name);
				if (matchResult.Success && Guid.TryParse(matchResult.Groups["CampaignId"].Value, out var campaignId)) {
					var campaign = campaigns.FirstOrDefault(x => x.Id == campaignId);
					if (campaign != null) {
						campaign.IsQrtzTriggerExist = true;
					}
				}
			}
		}

		private IEnumerable<CampaignModel> GetBrokenCampaigns() {
			IEnumerable<CampaignModel> campaigns = GetWorkingCampaigns();
			if (campaigns.Any()) {
				FillIsScheduledFlag(ref campaigns);
				return campaigns.Where(c => !c.IsQrtzTriggerExist);
			}
			return new List<CampaignModel>();
		}

		private void RescheduleCampaigns(IEnumerable<CampaignModel> campaigns) {
			foreach (CampaignModel campaignModel in campaigns) {
				try {
					var logInfo = new CampaignLogInfo {
						CampaignId = campaignModel.Id,
						StartDate = DateTime.UtcNow,
						Action = CampaignConsts.CampaignLogTypeCampaignRestart,
						IsSuccess = true
					};
					CampaignJobDispatcher.RemoveJobs(campaignModel.Id);
					CampaignLogger.LogAction(logInfo);
					CampaignJobExecutor.TryScheduleNextJob(_userConnection, campaignModel.SchemaUId, null);
				} catch (Exception ex) {
					string message = string.Format(CampaignHelper.GetLczStringValue("CampaignFailoverHandler",
						"RescheduleCampaignsException"), campaignModel.Id);
					Logger.Error(message, ex);
				}
			}
		}

		private bool IsFailoverJobScheduled() {
			var triggers = GetCampaignsExistingTriggers();
			return triggers.Any(x => x.Name.Contains(typeof(CampaignFailoverHandler).FullName));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates job to monitor broken campaigns.
		/// <param name="userConnection">The user connection.</param>
		/// </summary>
		public void CreateJob(UserConnection userConnection) {
			var currentUser = userConnection.CurrentUser;
			var periodInMinutes = (int)CoreSysSettings.GetValue(userConnection, "CampaignFailoverJobInterval");
			if (periodInMinutes > 0 && !IsFailoverJobScheduled()) {
				var isSystemUser = true;
				var scheduler = CampaignJobDispatcher.CampaignScheduler;
				var misfirePolicy = AppSchedulerMisfireInstruction.RescheduleNowWithRemainingRepeatCount;
				AppScheduler.ScheduleMinutelyJob<CampaignFailoverHandler>(CampaignConsts.CampaignJobGroupName,
					userConnection.Workspace.Name, currentUser.Name, periodInMinutes, null,
					isSystemUser, misfirePolicy, scheduler);
			}
		}

		/// <summary>
		/// Processes broken campaigns if they exist.
		/// <param name="userConnection">The user connection.</param>
		/// <param name="parameters">Job parameters.</param>
		/// </summary>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			try {
				_userConnection = userConnection;
				IEnumerable<CampaignModel> brokenCampaigns = GetBrokenCampaigns();
				RescheduleCampaigns(brokenCampaigns);
				CampaignQueueMonitoringJobDispatcher.TryRescheduleJob();
			} catch(Exception ex) {
				string message = CampaignHelper.GetLczStringValue("CampaignFailoverHandler", "ExecutionException");
				Logger.Error(message, ex);
				throw;
			}
		}

		#endregion

	}

	#endregion

}
