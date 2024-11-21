namespace BPMSoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Core;
	using BPMSoft.Core.Scheduler;
	using Web.Common;

	#region  Class: QueuesUpdateService

	/// <summary>
	/// Provides methods for queue updating.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class QueuesUpdateService : BaseService, IReadOnlySessionState
	{

		#region Constants: Private

		private const string UpdateQueuesJobName = "ImmediateUpdateQueuesJob";
		private const string UpdateQueuesJobGroupName = "ImmediateUpdateQueuesJobGroup";
		private const string QueuesUpdateProcessName = "QueuesUpdateProcess";

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedules QueuesUpdateProcess process.
		/// </summary>
		/// <returns>Sign that process was scheduled.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool ScheduleQueuesUpdateProcess() {
			if (!AppScheduler.IsJobRunning(UpdateQueuesJobName, UpdateQueuesJobGroupName)) {
				AppScheduler.ScheduleImmediateProcessJob(UpdateQueuesJobName, UpdateQueuesJobGroupName,
					QueuesUpdateProcessName, UserConnection.Workspace.Name, UserConnection.CurrentUser.Name);
				return true;
			}
			return false; 
		}

		#endregion
	}

	#endregion
}

