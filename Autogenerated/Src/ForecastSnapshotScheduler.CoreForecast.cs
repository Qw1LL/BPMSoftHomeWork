namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Quartz;
	using Quartz.Impl.Matchers;
	using Quartz.Impl.Triggers;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastSnapshotScheduler
	
	/// <summary>
	/// Provides config properties for quartz scheduler.
	/// </summary>
	public partial class QuartzSchedulerConfig
	{
		public Guid ForecastId { get; set; }
		
		public string CroneExpression { get; set; }
		
		public IEnumerable<Guid> PeriodIds { get; set; }
		
		public Entity Entity { get; set; }
		
		public TimeZoneInfo TimeZoneInfo { get; set; }
	}
	
	/// <summary>
	/// Provides methods for schedule forecast snapshot jobs.
	/// </summary>
	public interface IForecastSnapshotScheduler
	{
		/// <summary>
		/// Removes snapshot creation job.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		void RemoveJob(QuartzSchedulerConfig config);

		/// <summary>
		/// Triggers snapshot creation job.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		void TriggerJob(QuartzSchedulerConfig config);

		/// <summary>
		/// Checks auto-snapshot settings changes.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		/// <returns>Designator.</returns>
		bool IsAutoSnapshotSettingsChanged(QuartzSchedulerConfig config);

		/// <summary>
		/// Schedulers forecast automatic snapshot.
		/// </summary>
		/// <param name="config">The Quartz scheduler config.</param>
		void ScheduleForecastAutoSnapshot(QuartzSchedulerConfig config);
	}

	#endregion

	#region Class: ForecastSnapshotScheduler

	/// <inheritdoc />
	[DefaultBinding(typeof(IForecastSnapshotScheduler))]
	public class ForecastSnapshotScheduler : IForecastSnapshotScheduler
	{

		#region Constants: Private

		/// <summary>
		/// Cron expression translate: Every day at specific time, where {0} is minutes and {1} is hours.
		/// </summary>
		private const string CronExpressionTpl = "0 {0} {1} ? * * *";

		private static readonly AutoSnapshotTime _defaultTime = new AutoSnapshotTime() {
			Hours = 3,
			Minutes = 0
		};

		#endregion

		#region Fields: Private

		private readonly ILog _log;
		private readonly IAppSchedulerWraper _scheduleWrapper;
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Context connection.</param>
		/// <param name="wrapper">Context scheduler wrapper.</param>
		public ForecastSnapshotScheduler(UserConnection userConnection, IAppSchedulerWraper wrapper) {
			_scheduleWrapper = wrapper;
			_userConnection = userConnection;
			_log = LogManager.GetLogger(nameof(ForecastSnapshotScheduler));
		}

		#endregion

		#region Properties: Protected

		#endregion

		#region Methods: Private

		private AutoSnapshotSettings GetAutoSnapshotSettings(string sheetSettings) {
			if (sheetSettings == null) {
				return null;
			}
			var forecastSheetSettings = JsonConvert.DeserializeObject<SheetSetting>(sheetSettings);
			AutoSnapshotSettings autoSnapshotSettings = forecastSheetSettings?.AutoSnapshot;
			return autoSnapshotSettings;
		}

		private string GetCronExpression(TimeSpan scheduleTime) {
			return string.Format(CronExpressionTpl, scheduleTime.Minutes, scheduleTime.Hours);
		}

		private bool IsSettingsChanged(Entity entity) {
			var changedColumns = entity.GetChangedColumnValues();
			return changedColumns.Any(column => column.Name.Equals("Setting"));
		}

		/// <summary>
		/// Schedules snapshot creation job.
		/// </summary>
		/// <param name="forecastId">Forecast id.</param>
		/// <param name="cronExpression">CRON-expression.</param>
		/// <param name="timeZoneInfo">The timezone information.</param>
		private void ScheduleJob(Guid forecastId, string cronExpression, TimeZoneInfo timeZoneInfo) {
			string jobGroupName = GetJobGroupName(forecastId, ForecastJobType.Auto);
			string jobTriggerName = GetJobTriggerName(forecastId, ForecastJobType.Auto);
			var parameters = new Dictionary<string, object>() {
				{ "ForecastId", forecastId },
				{ "IsUseSystemUser", true }
			};
			IJobDetail job = _scheduleWrapper.CreateClassJob<ForecastSnapshotExecutor>(jobTriggerName, jobGroupName,
				_userConnection, parameters, true);
			var trigger = new CronTriggerImpl(jobTriggerName, jobGroupName, cronExpression) {
				TimeZone = timeZoneInfo
			};
			_scheduleWrapper.Instance.ScheduleJob(job, trigger);
			_log.Info($"Automatic forecast snapshot jobs with job group \"{jobGroupName}\"," +
				$" job trigger name \"{jobTriggerName}\" and forecastId \"{forecastId}\" had been planned.");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns template job group name.
		/// </summary>
		/// <param name="forecastId">Context forecast id.</param>
		/// <param name="jobType">Context job type.</param>
		/// <returns>Group name.</returns>
		public string GetJobGroupName(Guid forecastId, ForecastJobType jobType) {
			var autoJobMarker = jobType == ForecastJobType.Auto ? "auto" : null;
			var parts =
				(new[] { nameof(ForecastSnapshotScheduler), forecastId.ToString(), autoJobMarker }).Where(x =>
					x != null);
			return String.Join("_", parts);
		}

		/// <summary>
		/// Returns template job trigger name.
		/// </summary>
		/// <param name="forecastId">Context forecast id.</param>
		/// <param name="jobType">Context job type.</param>
		/// <returns>Trigger name.</returns>
		public string GetJobTriggerName(Guid forecastId, ForecastJobType jobType) {
			var autoJobMarker = jobType == ForecastJobType.Auto ? "auto" : null;
			var parts = (new[] { nameof(ForecastSnapshotScheduler), forecastId.ToString(), "trigger", autoJobMarker })
				.Where(x => x != null);
			return String.Join("_", parts);
		}

		/// <inheritdoc />
		public bool IsAutoSnapshotSettingsChanged(QuartzSchedulerConfig config) {
			config.CheckArgumentNull(nameof(config));
			config.Entity.CheckArgumentNull(nameof(config.Entity));
			bool isSettingsNotChanged = !IsSettingsChanged(config.Entity);
			if (isSettingsNotChanged) {
				return false;
			}
			var settings = config.Entity.GetTypedColumnValue<string>("Setting");
			AutoSnapshotSettings newAutoSnapshotSettings = GetAutoSnapshotSettings(settings);
			if (newAutoSnapshotSettings == null) {
				return false;
			}
			var oldSettings = config.Entity.GetTypedOldColumnValue<string>("Setting");
			AutoSnapshotSettings oldAutoSnapshotSettings = GetAutoSnapshotSettings(oldSettings);
			bool isAutoSnapshotStateChanged = !newAutoSnapshotSettings.Equals(oldAutoSnapshotSettings);
			return isAutoSnapshotStateChanged;
		}

		/// <inheritdoc />
		public void RemoveJob(QuartzSchedulerConfig config) {
			config.CheckArgumentNull(nameof(config));
			config.ForecastId.CheckArgumentEmpty(nameof(config.ForecastId));
			string jobGroupName = GetJobGroupName(config.ForecastId, ForecastJobType.Auto);
			var groupMatcher = GroupMatcher<JobKey>.GroupContains(jobGroupName);
			var jobKeys = _scheduleWrapper.Instance.GetJobKeys(groupMatcher).ToList();
			_scheduleWrapper.Instance.DeleteJobs(jobKeys);
			_log.Info($"Automatic forecast snapshot jobs with job group \"{jobGroupName}\"" +
				$" and forecastId \"{config.ForecastId}\" had been deleted.");
		}

		/// <inheritdoc />
		public void ScheduleForecastAutoSnapshot(QuartzSchedulerConfig config) {
			config.CheckArgumentNull(nameof(config));
			config.Entity.CheckArgumentNull(nameof(config.Entity));
			var forecastId = config.Entity.GetTypedColumnValue<Guid>("Id");
			var settings = config.Entity.GetTypedColumnValue<string>("Setting");
			AutoSnapshotSettings autoSnapshotSettings = GetAutoSnapshotSettings(settings);
			if (autoSnapshotSettings == null) {
				return;
			}
			RemoveJob(new QuartzSchedulerConfig() {
				ForecastId = forecastId
			});
			if (autoSnapshotSettings.IsEnabled) {
				AutoSnapshotTime time = autoSnapshotSettings.Time;
				var scheduleTime = 
					new TimeSpan(time?.Hours ?? _defaultTime.Hours, time?.Minutes ?? _defaultTime.Minutes, 0);
				string cronExpression = GetCronExpression(scheduleTime);
				ScheduleJob(forecastId, cronExpression, config.TimeZoneInfo ?? TimeZoneInfo.Utc);
			}
		}

		/// <inheritdoc />
		public void TriggerJob(QuartzSchedulerConfig config) {
			config.CheckArgumentNull(nameof(config));
			config.ForecastId.CheckArgumentEmpty(nameof(config.ForecastId));
			IDictionary<string, object> parameters = new Dictionary<string, object> {
				{ "ForecastId", config.ForecastId },
				{ "IsUseSystemUser", true }
			};
			string jobGroupName = GetJobGroupName(config.ForecastId, ForecastJobType.OneTime);
			string jobTriggerName = GetJobTriggerName(config.ForecastId, ForecastJobType.OneTime);
			_scheduleWrapper.RemoveJob(jobTriggerName, jobGroupName);
			IJobDetail job = _scheduleWrapper.CreateClassJob<ForecastSnapshotExecutor>(jobTriggerName, jobGroupName,
				_userConnection, parameters, false);
			var trigger = new SimpleTriggerImpl(jobTriggerName, jobGroupName);
			_scheduleWrapper.Instance.ScheduleJob(job, trigger);
		}

		#endregion

	}

	#endregion

}

