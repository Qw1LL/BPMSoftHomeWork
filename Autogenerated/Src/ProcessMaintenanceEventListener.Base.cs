namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using global::Common.Logging;
	using Quartz;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;

	#region Class: ProcessMaintenanceEventListener

	/// <summary>
	/// Process maintenance Quartz job starter.
	/// </summary>
	/// <seealso cref="BPMSoft.Web.Common.IAppEventListener" />
	public class ProcessMaintenanceEventListener : IAppEventListener
	{

		#region Methods: Protected

		protected virtual UserConnection GetUserConnection(AppEventContext context) {
			var appConnection = (AppConnection)context.Application["AppConnection"];
			return appConnection.SystemUserConnection;
		}

		#endregion

		#region Custom: IAppEventListener members

		/// <inheritdoc cref="BPMSoft.Web.Common.IAppEventListener.OnAppStart"/>
		public void OnAppStart(AppEventContext context) {
			UserConnection userConnection = GetUserConnection(context);
			var appSchedulerWrapper = ClassFactory.Get<IAppSchedulerWraper>();
			ProcessMaintenanceJob.Register(userConnection, appSchedulerWrapper);
		}

		/// <inheritdoc cref="BPMSoft.Web.Common.IAppEventListener.OnAppEnd"/>
		public void OnAppEnd(AppEventContext context) {
		}

		/// <inheritdoc cref="BPMSoft.Web.Common.IAppEventListener.OnSessionStart"/>
		public void OnSessionStart(AppEventContext context) {
		}

		/// <inheritdoc cref="BPMSoft.Web.Common.IAppEventListener.OnSessionEnd"/>
		public void OnSessionEnd(AppEventContext context) {
		}

		#endregion

	}

	#endregion

	#region Class: ProcessMaintenanceJob

	/// <summary>
	/// Process maintenance job.
	/// </summary>
	[DefaultBinding(typeof(IJobExecutor), Name = nameof(ProcessMaintenanceJob))]
	public class ProcessMaintenanceJob : IJobExecutor
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("ProcessMaintenanceLog");
		private static readonly string _initialFrequencyParameterName = "initialFrequency";
		private readonly IProcessLogMaintainer _processLogMaintainer;
		private readonly IAppSchedulerWraper _appSchedulerWrapper;

		#endregion

		#region Constructors: Public

		public ProcessMaintenanceJob() {
		}

		public ProcessMaintenanceJob(IProcessLogMaintainer processLogMaintainer,
				IAppSchedulerWraper appSchedulerWrapper) {
			_processLogMaintainer = processLogMaintainer;
			_appSchedulerWrapper = appSchedulerWrapper;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets the frequency of running operations for process log maintenance system setting name.
		/// </summary>
		public static string ProcessMaintenanceJobFrequency => "ProcessMaintenanceJobFrequencyMinutes";

		/// <summary>
		/// Gets default value of frequency of running operations for process log maintenance system setting,
		/// in minutes.
		/// </summary>
		public static int DefaultFrequency => 5;

		#endregion

		#region Methods: Private

		private static IJobDetail CreateJob(UserConnection userConnection, IAppSchedulerWraper appSchedulerWrapper,
				int maintenanceFrequency, string jobName, string jobGroup) {
			var parameters = new Dictionary<string, object> {
				{ _initialFrequencyParameterName, maintenanceFrequency }
			};
			return appSchedulerWrapper.CreateClassJob<ProcessMaintenanceJob>(jobName,
				jobGroup, userConnection, parameters, true);
		}

		private static ITrigger GetJobTrigger(int maintenanceFrequency) {
			return TriggerBuilder.Create()
				.WithSimpleSchedule(s => s.WithIntervalInMinutes(maintenanceFrequency).RepeatForever())
				.StartNow()
				.Build();
		}

		private static int GetMaintenanceFrequencySysSetting(UserConnection userConnection) {
			return Core.Configuration.SysSettings.GetValue(userConnection,
				ProcessMaintenanceJobFrequency, DefaultFrequency);
		}

		private static void Register(UserConnection userConnection, IAppSchedulerWraper appSchedulerWrapper,
				int maintenanceFrequency) {
			string jobName = typeof(ProcessMaintenanceJob).FullName;
			var jobGroup = "ProcessMaintenanceGroup";
			if (appSchedulerWrapper.DoesJobExist(jobName, jobGroup)) {
				appSchedulerWrapper.RemoveJob(jobName, jobGroup);
				_log.Info($"ProcessMaintenanceJob removed.");
			}
			if (maintenanceFrequency <= 0) {
				return;
			}
			IJobDetail job = CreateJob(userConnection, appSchedulerWrapper, maintenanceFrequency, jobName, jobGroup);
			appSchedulerWrapper.Instance.ScheduleJob(job, GetJobTrigger(maintenanceFrequency));
			_log.Info($"ProcessMaintenanceJob scheduled with {maintenanceFrequency} minutes frequency.");
		}

		#endregion

		#region Methods: Protected

		protected virtual IEntityArchiver GetArchiver(DBExecutor dbExecutor) {
			return new SysProcessLogArchiver(dbExecutor);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Registers <see cref="ProcessMaintenanceJob"/> in scheduler.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="appSchedulerWrapper">Scheduler.</param>
		public static void Register(UserConnection userConnection, IAppSchedulerWraper appSchedulerWrapper) {
			const string oldJobGroup = "ProcessLogArchivingJobGroup";
			const string oldJobName = "BPMSoft.Configuration.ProcessLogArchivingJob";
			if (appSchedulerWrapper.DoesJobExist(oldJobName, oldJobGroup)) {
				appSchedulerWrapper.RemoveJob(oldJobName, oldJobGroup);
			}
			int maintenanceFrequency = GetMaintenanceFrequencySysSetting(userConnection);
			Register(userConnection, appSchedulerWrapper, maintenanceFrequency);
		}

		/// <inheritdoc cref="BPMSoft.Core.IJobExecutor.Execute"/>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			if (!GlobalAppSettings.FeatureUseNewProcessLogMaintenance) {
				using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
					IEntityArchiver archiver = GetArchiver(dbExecutor);
					archiver.Archive();
				}
				return;
			}
			int initialFrequency = parameters.TryGetValue(_initialFrequencyParameterName, out object value)
				? (int)value
				: DefaultFrequency;
			int maintenanceFrequency = GetMaintenanceFrequencySysSetting(userConnection);
			if (maintenanceFrequency != initialFrequency) {
				Register(userConnection, _appSchedulerWrapper, maintenanceFrequency);
			}
			_processLogMaintainer.ExecuteStep();
		}

		#endregion

	}

	#endregion

}

