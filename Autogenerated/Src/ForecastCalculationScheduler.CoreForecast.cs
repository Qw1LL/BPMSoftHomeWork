namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Quartz;
	using Quartz.Impl.Matchers;
	using Quartz.Impl.Triggers;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;

	#region Enum: ForecastJobType

	/// <summary>
	/// The forecast calculation job type.
	/// </summary>
	public enum ForecastJobType
	{
		/// <summary>
		/// The one time calculation job.
		/// </summary>
		OneTime = 0,

		/// <summary>
		/// The auto calculation job
		/// </summary>
		Auto = 1,
	}

	#endregion

	#region Class: ForecastCalculationStatus

	/// <summary>
	/// Provides information about forecast calculation status.
	/// </summary>
	public class ForecastCalculationStatus
	{
		public bool IsInProgress { get; set; }

		public DateTime? LastCalcDateTime { get; set; }

		public DateTime? NextCalcDateTime { get; set; }

	}

	#endregion

	#region Interface: IForecastCalculationScheduler

	/// <summary>
	/// Provides methods to schedule forecast calculation jobs.
	/// </summary>
	public interface IForecastCalculationScheduler
	{
		/// <summary>
		/// Schedule forecast auto calculation jobs.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		void ScheduleJobs(QuartzSchedulerConfig config);

		/// <summary>
		/// Remove scheduled forecast auto calculation jobs.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		void RemoveJobs(QuartzSchedulerConfig config);

		/// <summary>
		/// Trigger one time forecast calculation job.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		void TriggerJob(QuartzSchedulerConfig config);

		/// <summary>
		/// Get the forecast calculation status.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		/// <returns>The forecast calculation status.</returns>
		ForecastCalculationStatus GetCalculationStatus(QuartzSchedulerConfig config);
	}

	#endregion

	#region Class: ForecastCalculationScheduler

	/// <summary>
	/// Provides methods to schedule forecast calculation jobs.
	/// </summary>
	/// <seealso cref="IForecastCalculationScheduler" />
	[DefaultBinding(typeof(IForecastCalculationScheduler))]
	public class ForecastCalculationScheduler: IForecastCalculationScheduler
	{
		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger(nameof(ForecastCalculationScheduler));

		#endregion

		#region Properties: Public

		private IAppSchedulerWraper _appSchedulerWrapper;

		/// <summary>Gets the app schedule wrapper.</summary>
		/// <value>The app schedule wrapper.</value>
		public IAppSchedulerWraper AppSchedulerWrapper {
			get => _appSchedulerWrapper ?? (_appSchedulerWrapper = ClassFactory.Get<IAppSchedulerWraper>());
			set => _appSchedulerWrapper = value;
		}

		#endregion

		#region Properties: Protected

		private IForecastSheetRepositoryV2 _sheetRepository;

		/// <summary>Gets the forecast sheet repository.</summary>
		/// <value>The forecast sheet repository.</value>
		protected IForecastSheetRepositoryV2 SheetRepository =>
			_sheetRepository ?? (_sheetRepository = ClassFactory.Get<IForecastSheetRepositoryV2>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected UserConnection UserConnection { get; }

		#endregion

		#region Constructors: Public

		public ForecastCalculationScheduler(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private string GetJobGroup(Guid forecastId, ForecastJobType forecastJobType) {
			string group = $"{nameof(ForecastCalculatorExecutor)}_{forecastId}";
			if (forecastJobType == ForecastJobType.Auto) {
				group += "_auto";
			}
			return group;
		}

		private string GetJobTriggerName(Guid forecastId, ForecastJobType forecastJobType) {
			string triggerName= $"{nameof(ForecastCalculatorExecutor)}_{forecastId}_trigger";
			if (forecastJobType == ForecastJobType.Auto) {
				triggerName += "_auto";
			}
			return triggerName;
		}

		private IEnumerable<TriggerKey> GetJobTriggerKeys(Guid forecastId) {
			string jobGroup = GetJobGroup(forecastId, ForecastJobType.OneTime);
			var groupMatcher = GroupMatcher<TriggerKey>.GroupContains(jobGroup);
			var jobTriggerKeys = AppSchedulerWrapper.Instance.GetTriggerKeys(groupMatcher);
			return jobTriggerKeys;
		}

		private DateTime? GetNextDateTime(DateTimeOffset? nextStartDate) {
			var nextDateTime = nextStartDate?.DateTime ?? DateTime.MinValue;
			nextDateTime = DateTime.SpecifyKind(nextDateTime, DateTimeKind.Utc);
			var converted = TimeZoneInfo.ConvertTime(nextDateTime,
				TimeZoneInfo.Utc, UserConnection.CurrentUser.TimeZone);
			return nextDateTime < DateTime.UtcNow ? (DateTime?)null : converted;
		}

		private DateTime? GetLastDateTime(DateTime lastCalculationDateTime) {
			var lastDateTime = lastCalculationDateTime.Equals(DateTime.MinValue)
				? DateTime.MaxValue
				: lastCalculationDateTime;
			var lastTimeUtc = TimeZoneInfo.ConvertTime(lastDateTime,
				UserConnection.CurrentUser.TimeZone, TimeZoneInfo.Utc);
			return lastTimeUtc > DateTime.UtcNow ? (DateTime?)null : lastDateTime;
		}

		private bool GetIsCalculateInProgress(List<ITrigger> triggers, DateTime lastCalculationDateTime, Guid forecastId) {
			string autoJobGroup = GetJobGroup(forecastId, ForecastJobType.Auto);
			string manualJobGroup = GetJobGroup(forecastId, ForecastJobType.OneTime);
			var autoTrigger = triggers.FirstOrDefault(trigger => trigger.JobKey.Group == autoJobGroup);
			var manualTrigger = triggers.FirstOrDefault(trigger => trigger.JobKey.Group == manualJobGroup);
			var autoTriggerStartTime = autoTrigger?.GetPreviousFireTimeUtc();
			var manualTriggerStartTime = manualTrigger?.GetPreviousFireTimeUtc() ??
				manualTrigger?.GetNextFireTimeUtc();
			var lastCalcTimeUtc = TimeZoneInfo.ConvertTime(lastCalculationDateTime,
				UserConnection.CurrentUser.TimeZone, TimeZoneInfo.Utc);
			var autoTriggerInProgress = autoTriggerStartTime != null && ShiftDateTime(autoTriggerStartTime.Value) > lastCalcTimeUtc;
			var manualTriggerInProgress = manualTriggerStartTime != null && manualTriggerStartTime < DateTime.UtcNow;
			return autoTriggerInProgress || manualTriggerInProgress;
		}

		private DateTimeOffset ShiftDateTime(DateTimeOffset dateTime) {
			return dateTime.AddSeconds(-1);
		}

		#endregion

		#region Methdos: Public

		/// <summary>
		/// Schedule forecast auto calculation jobs.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		public void ScheduleJobs(QuartzSchedulerConfig config) {
			config.CheckArgumentNull(nameof(config));
			config.ForecastId.CheckArgumentEmpty(nameof(config.ForecastId));
			config.CroneExpression.CheckArgumentNullOrEmpty(config.CroneExpression);
			var periods = ForecastExtensions.GetPeriodsId(UserConnection, config.ForecastId)
				.Take(ForecastConsts.MaxPeriodsCount).ToList();
			IDictionary<string, object> parameters = new Dictionary<string, object> {
				{ "ForecastId", config.ForecastId },
				{ "PeriodIds", periods },
				{ "IsUseSystemUser", true },
				{ "IsAutoCalculationJob", true }
			};
			string jobGroup = GetJobGroup(config.ForecastId, ForecastJobType.Auto);
			string jobTriggerName = GetJobTriggerName(config.ForecastId, ForecastJobType.Auto);
			IJobDetail job = AppSchedulerWrapper.CreateClassJob<ForecastCalculatorExecutor>(jobTriggerName,
				jobGroup, UserConnection, parameters, true);
			var trigger = new CronTriggerImpl(jobTriggerName, jobGroup, config.CroneExpression) {
				TimeZone = config.TimeZoneInfo ?? TimeZoneInfo.Utc 
			};
			AppSchedulerWrapper.Instance.ScheduleJob(job, trigger);
			_log.Info($"Automatic forecast calculation jobs with job group \"{jobGroup}\"," +
				$" job trigger name \"{jobTriggerName}\" and forecastId \"{config.ForecastId}\" had been planned.");
		}

		/// <summary>
		/// Remove scheduled forecast auto calculation jobs.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		public void RemoveJobs(QuartzSchedulerConfig config) {
			config.CheckArgumentNull(nameof(config));
			config.ForecastId.CheckArgumentEmpty(nameof(config.ForecastId));
			string jobGroup = GetJobGroup(config.ForecastId, ForecastJobType.Auto);
			var groupMatcher = GroupMatcher<JobKey>.GroupContains(jobGroup);
			var jobKeys = AppSchedulerWrapper.Instance.GetJobKeys(groupMatcher).ToList();
			AppSchedulerWrapper.Instance.DeleteJobs(jobKeys);
			_log.Info($"Automatic forecast calculation jobs with job group \"{jobGroup}\"" +
				$" and forecastId \"{config.ForecastId}\" had been deleted.");
		}

		/// <summary>
		/// Trigger one time forecast calculation job.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		public void TriggerJob(QuartzSchedulerConfig config) {
			config.CheckArgumentNull(nameof(config));
			config.ForecastId.CheckArgumentEmpty(nameof(config.ForecastId));
			config.PeriodIds.CheckArgumentNull(nameof(config.PeriodIds));
			IDictionary<string, object> parameters = new Dictionary<string, object> {
				{ "ForecastId", config.ForecastId },
				{ "PeriodIds", config.PeriodIds },
				{ "IsUseSystemUser", true },
				{ "IsAutoCalculationJob", false }
			};
			string jobGroup = GetJobGroup(config.ForecastId, ForecastJobType.OneTime);
			string jobTriggerName = GetJobTriggerName(config.ForecastId, ForecastJobType.OneTime);
			AppSchedulerWrapper.RemoveJob(jobTriggerName, jobGroup);
			IJobDetail job = AppSchedulerWrapper.CreateClassJob<ForecastCalculatorExecutor>(jobTriggerName,
				jobGroup, UserConnection, parameters, false);
			var trigger = new SimpleTriggerImpl(jobTriggerName, jobGroup);
			AppSchedulerWrapper.Instance.ScheduleJob(job, trigger);
		}

		/// <summary>
		/// Get the forecast calculation status.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		/// <returns>The forecast calculation status.</returns>
		public ForecastCalculationStatus GetCalculationStatus(QuartzSchedulerConfig config) {
			config.CheckArgumentNull(nameof(config));
			config.ForecastId.CheckArgumentEmpty(nameof(config.ForecastId));
			var response = new ForecastCalculationStatus();
			Sheet sheet = SheetRepository.GetSheet(new SheetFilterConfig {
				ForecastId = config.ForecastId,
				UseCaching = false
			});
			var jobTriggerKeys = GetJobTriggerKeys(config.ForecastId);
			var triggers = jobTriggerKeys?.Select(key => AppSchedulerWrapper.Instance.GetTrigger(key))
				.ToList();
			var nextStartDate = triggers.Where(trigger => trigger.GetNextFireTimeUtc().HasValue)
				.DefaultIfEmpty()
				.Min(x => x?.GetNextFireTimeUtc());
			response.IsInProgress = GetIsCalculateInProgress(triggers, sheet.LastCalculationDateTime, config.ForecastId);
			response.LastCalcDateTime = GetLastDateTime(sheet.LastCalculationDateTime);
			response.NextCalcDateTime = GetNextDateTime(nextStartDate);
			return response;
		}

		#endregion

	}

	#endregion

}

