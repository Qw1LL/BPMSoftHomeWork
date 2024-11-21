namespace BPMSoft.Configuration.SyncJobService
{
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;

	#region Class: SyncJobService
	/// <summary>
	/// ##### ####### ## ###### # #############
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SyncJobService : BaseService
	{
		#region Methods: Public
		/// <summary>
		/// ####### ########### ####### ######## # ##########.
		/// </summary>
		/// <param name="request">######.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public void CreateSyncJob(SyncJobRequest request) {
			var jobName = request.JobName;
			var jobGroupName = request.JobName + "Group";
			var processName = request.ProcessName;
			var periodInMinutes = request.PeriodInMinutes;
			if (periodInMinutes > 0) {
				AppScheduler.ScheduleMinutelyProcessJob(jobName, jobGroupName, processName,
					UserConnection.Workspace.Name, UserConnection.CurrentUser.Name, periodInMinutes, null, true);
			}
			else {
				AppScheduler.RemoveJob(jobName, jobGroupName);
			}
		}
		#endregion
	}
	#endregion
	
	#region Class: SyncJobRequest
	/// <summary>
	/// ##### ####### ### ######## ###### # ############
	/// </summary>
	[DataContract]
	public class SyncJobRequest
	{
		#region Properties: Public
		/// <summary>
		/// ######## ###### ############.
		/// </summary>
		[DataMember]
		public string JobName { get; set; }
		
		/// <summary>
		/// ######## ############ ############# ########.
		/// </summary>
		[DataMember]
		public string ProcessName { get; set; }
		
		/// <summary>
		/// ######## ####### ######## # #######.
		/// </summary>
		[DataMember]
		public int PeriodInMinutes { get; set; }
		#endregion
	}
	#endregion
}
