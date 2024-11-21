namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using global::Common.Logging;
	using Quartz;
	using Quartz.Impl.Matchers;
	using Quartz.Impl.Triggers;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Factories;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;
	using CoreScheduler = Core.Scheduler.AppScheduler;

	#region Calss: CampaignJobDispatcher

	/// <summary>
	/// Provides methods for campaign job management.
	/// </summary>
	public class CampaignJobDispatcher : ICampaignJobDispatcher
	{

		#region Constants: Private

		private const string _campaignJobNameTamplate = "Campaign{0}{1}";
		private const string _scheduledTimeFormat = "dd.MM.yyyyHH:mm";
		private const string _campaignSchedulerName = "CampaignQuartzScheduler";

		#endregion

		#region Fields: Private

		private static readonly object _rescheduleLockObject = new object();

		private UserConnection _userConnection;
		private IAppSchedulerWraper _appSchedulerWraper;

		#endregion

		#region Constructors: Public

		public CampaignJobDispatcher(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		public CampaignJobDispatcher(UserConnection userConnection, IAppSchedulerWraper schedulerWraper)
				: this(userConnection) {
			_appSchedulerWraper = schedulerWraper;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// Gets or sets the process service provider.
		/// </summary>
		private IAppSchedulerWraper AppScheduler {
			get {
				return _appSchedulerWraper ?? (_appSchedulerWraper = ClassFactory.Get<IAppSchedulerWraper>());
			}
		}

		/// <summary>
		/// Instance of <see cref="IScheduler"/> with name <see cref="_campaignSchedulerName"/> or default.
		/// </summary>
		public IScheduler CampaignScheduler => AppScheduler.FindScheduler(_campaignSchedulerName)
			?? AppScheduler.Instance;

		private ILog _logger;
		private ILog Logger {
			get {
				return _logger ?? (_logger = LogManager.GetLogger(CampaignConstants.CampaignLoggerName));
			}
		}

		/// <summary>
		/// Gets or sets the campaign helper. Instance of <see cref="CampaignHelper"/>.
		/// </summary>
		private CampaignHelper _campaignHelper;
		private CampaignHelper CampaignHelper {
			get {
				return _campaignHelper ?? (_campaignHelper = new CampaignHelper(_userConnection));
			}
		}

		#endregion

		#region Properties: Public

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

		private string GetCampaignJobName(Guid campaignId, DateTime fireTime) {
			return string.Format(_campaignJobNameTamplate, campaignId, fireTime.ToString(_scheduledTimeFormat));
		}

		private void LogScheduledJob(Guid campaignId, CampaignFireTimeConfig jobConfig) {
			Guid actionId;
			switch (jobConfig.ScheduledAction) {
				case CampaignScheduledAction.Run:
					actionId = CampaignConsts.CampaignLogTypeScheduledRun;
					break;
				case CampaignScheduledAction.ScheduledStop:
					actionId = CampaignConsts.CampaignLogTypeScheduledStop;
					break;
				case CampaignScheduledAction.ScheduledStart:
					actionId = CampaignConsts.CampaignLogTypeScheduledStart;
					break;
				default:
					actionId = Guid.Empty;
					break;
			}
			if (actionId != Guid.Empty) {
				LogAction(campaignId, actionId, jobConfig.Time);
			}
		}

		private void LogAction(Guid campaignId, Guid actionId, DateTime scheduledDate) {
			var logInfo = new CampaignLogInfo {
				CampaignId = campaignId,
				ScheduledDate = scheduledDate,
				Action = actionId,
				IsSuccess = true
			};
			CampaignLogger.LogAction(logInfo);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedule next job for the specified campaign.
		/// </summary>
		/// <param name="schema">The <see cref="BPMSoft.Core.Campaign.CampaignSchema"/> object for wich Job plans.</param>
		/// <param name="fireTimeConfig">Fire time config for job.</param>
		public void ScheduleJob(CoreCampaignSchema schema, CampaignFireTimeConfig fireTimeConfig) {
			try {
				schema.CheckArgumentNull(nameof(schema));
				fireTimeConfig.CheckArgumentNull(nameof(fireTimeConfig));
				Guid campaignId = schema.EntityId;
				var campaignJobName = GetCampaignJobName(campaignId, fireTimeConfig.Time);
				var sysUserConnection = _userConnection.AppConnection.SystemUserConnection;
				var parameters = new Dictionary<string, object> {
					{ "CampaignSchemaUId", schema.UId },
					{ "ScheduledUtcFireTime", fireTimeConfig.Time },
					{ "SchemaGeneratorStrategy", fireTimeConfig.ExecutionStrategy },
					{ "ScheduledAction", (int)fireTimeConfig.ScheduledAction }
				};
				IJobDetail job = AppScheduler.CreateClassJob<CampaignJobExecutor>(campaignJobName,
					CampaignConsts.CampaignJobGroupName, sysUserConnection, parameters);
				ITrigger trigger = new SimpleTriggerImpl(campaignJobName + "Trigger",
						CampaignConsts.CampaignJobGroupName, fireTimeConfig.Time) {
					MisfireInstruction = MisfireInstruction.IgnoreMisfirePolicy
				};
				CampaignScheduler.ScheduleJob(job, trigger);
				LogScheduledJob(schema.EntityId, fireTimeConfig);
			} catch (Exception ex) {
				string message = CampaignHelper.GetLczStringValue(nameof(CampaignJobDispatcher), "ScheduleException");
				Logger.ErrorFormat(message, ex, schema == null ? Guid.Empty : schema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Schedule next job for the specified campaign.
		/// </summary>
		/// <param name="campaignSchemaUId">The unique identifier of campaign schema instance.</param>
		/// <param name="fireTimeConfig">Fire time config for job.</param>
		public void ScheduleJob(Guid campaignSchemaUId, CampaignFireTimeConfig fireTimeConfig) {
			try {
				var schemaManager = (CampaignSchemaManager)_userConnection.GetSchemaManager("CampaignSchemaManager");
				CoreCampaignSchema campaignSchema = schemaManager.GetSchemaInstance(campaignSchemaUId);
				ScheduleJob(campaignSchema, fireTimeConfig);
			} catch (Exception ex) {
				string message = CampaignHelper.GetLczStringValue(nameof(CampaignJobDispatcher),
					"ScheduleBySchemaUIdException");
				Logger.ErrorFormat(message, ex, campaignSchemaUId);
				throw;
			}
		}

		/// <summary>
		/// Removes scheduled jobs for the specified campaign using default and campaign schedulers.
		/// </summary>
		/// <param name="campaignId">The <see cref="BPMSoft.Core.Campaign.CampaignSchema"/> UId which job should be deleted.</param>
		public void RemoveJobs(Guid campaignId) {
			try {
				var groupMatcher = GroupMatcher<JobKey>.GroupContains(CampaignConsts.CampaignJobGroupName);
				var defaultSchedulerJobs = AppScheduler.Instance.GetJobKeys(groupMatcher);
				IEnumerable<JobKey> jobKeys = defaultSchedulerJobs;
				if (CampaignScheduler != AppScheduler.Instance) {
					var campaignSchedulerJobs = CampaignScheduler.GetJobKeys(groupMatcher);
					jobKeys = jobKeys.Concat(campaignSchedulerJobs);
				}
				var campaignJobs = jobKeys.Where(x => x.Name.Contains(campaignId.ToString()));
				foreach (var job in campaignJobs) {
					CoreScheduler.RemoveJob(job.Name, CampaignConsts.CampaignJobGroupName, CampaignScheduler);
				}
			} catch (Exception ex) {
				string message = CampaignHelper.GetLczStringValue(nameof(CampaignJobDispatcher), "RemoveJobException");
				Logger.ErrorFormat(message, ex, campaignId);
				throw;
			}
		}

		/// <summary>
		/// Reschedule job for the specified campaign.
		/// </summary>
		/// <param name="schema">The <see cref="BPMSoft.Core.Campaign.CampaignSchema"/> object for wich Job plans.</param>
		/// <param name="fireTimeConfig">Fire time config for job.</param>
		public void RescheduleJob(CoreCampaignSchema schema, CampaignFireTimeConfig fireTimeConfig) {
			lock (_rescheduleLockObject) {
				RemoveJobs(schema.EntityId);
				ScheduleJob(schema, fireTimeConfig);
			}
		}

		#endregion

	}

	#endregion

}

