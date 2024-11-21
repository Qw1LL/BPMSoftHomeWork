namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;

	#region Class: TriggerEmailQueueJobDispatcher

	/// <summary>
	/// Serves bulk email queue with messages for triggered emails.
	/// </summary>
	public class TriggerEmailQueueJobDispatcher : BaseBulkEmailQueueJobDispatcher, IAppEventListener
	{

		#region Properties: Protected

		/// <inheritdoc/>
		protected override IEnumerable<BulkEmailQueueMessageType> AllowedMessageTypes =>
			new BulkEmailQueueMessageType[] {
				BulkEmailQueueMessageType.SendTriggerEmail
			};

		#endregion

		#region Methods: Protected

		/// <inheritdoc/>
		protected override void ScheduleJob(string workspaceName, string userName) {
			AppScheduler.ScheduleMinutelyJob<TriggerEmailQueueJobDispatcher>(
				JobGroupName, workspaceName, userName, periodInMinutes: 1,
				isSystemUser: true, scheduler: Scheduler,
				misfireInstruction: AppSchedulerMisfireInstruction.SmartPolicy);
		}

		#endregion

	}

	#endregion

}

