namespace BPMSoft.Configuration.QueuesService
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Text;
	using System.Web;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Web.Common;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;

	#region Class: QueuesService

	/// <summary>
	/// Single Window Queuing Service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class QueuesService : BaseService, System.Web.SessionState.IReadOnlySessionState
	{
		#region Properties: Private

		private IAppSchedulerWraper AppSchedulerWrapper {
			get {
				return ClassFactory.Get<IAppSchedulerWraper>();
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets the id of the queue item by the id of the running process instance.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="processUId">The identifier of the running queue item processing process.</param>
		/// <returns>Queue item Id.</returns>
		private static Guid GetProcessQueueItemId(UserConnection userConnection, string processUId) {
			Process process = userConnection.ProcessEngine.GetProcessByUId(processUId, true);
			return (Guid)process.GetPropertyValue("queueItemId");
		}

		/// <summary>
		/// Returns the value of the resource string.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="resourceName">Resource name.</param>
		/// <returns>Text value.</returns>
		private string GetResourceValue(UserConnection userConnection, string resourceName) {
			if (userConnection == null) {
				return string.Empty;
			}
			var resourceStorage = userConnection.Workspace.ResourceStorage;
			var resource = new LocalizableString(resourceStorage, "QueuesService",
				string.Format("LocalizableStrings.{0}.Value", resourceName));
			return (resource == null) ? string.Empty : resource.Value;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Signs the current user to receive a Single Window queue update notification.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SubscribeForQueuesNotifications",
			BodyStyle = WebMessageBodyStyle.Wrapped,RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public void SubscribeForQueuesNotifications() {
			var userConnection = UserConnection;
			if (userConnection == null) {
				throw new ArgumentNullException("UserConnection");
			}
			var userId = userConnection.CurrentUser.Id;
			if (!QueuesUtilities.QueuesNotificationsSubscribers.Contains(userId)) {
				string message = string.Format(
					GetResourceValue(userConnection, "AddingUserToQueuesNotificationsSubscribersMessage"), userId);
				QueuesUtilities.LogDebug(message);
				QueuesUtilities.QueuesNotificationsSubscribers.Add(userId);
			}
		}

		/// <summary>
		/// Updates the Single Window Queue Seeding Scheduler job.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateQueuesTrigger", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void UpdateQueuesTrigger() {
			var appConnection = AppConnection;
			if (appConnection == null) {
				throw new ArgumentNullException("AppConnection");
			}
			QueuesUtilities.UpdateQueuesTrigger(appConnection.SystemUserConnection);
		}

		/// <summary>
		/// Updates the next processing of the queue item.
		/// </summary>
		/// <param name="processUId">The identifier of the running queue item processing process.</param>
		/// <param name="nextProcessingDateMilliseconds">The next processing date for the queue item.<remarks>
		/// Transmitted as the number of milliseconds since January 1, 1970.</remarks></param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ChangeQueueItemDate", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ChangeQueueItemDate(string processUId, long nextProcessingDateMilliseconds) {
			DateTime nextProcessingDate = new DateTime(1970, 01, 01).AddMilliseconds(nextProcessingDateMilliseconds);
			nextProcessingDate = DateTime.SpecifyKind(nextProcessingDate, DateTimeKind.Utc);
			var userConnection = UserConnection;
			string message = string.Empty;
			try {
				if (userConnection == null) {
					throw new ArgumentNullException("UserConnection");
				}
				Guid queueItemId = GetProcessQueueItemId(userConnection, processUId);
				var update =
					new Update(userConnection, "QueueItem")
						.Set("NextProcessingDate", new QueryParameter("NextProcessingDate", nextProcessingDate))
					.Where("Id").IsEqual(new QueryParameter("QueueItemId", queueItemId));
				update.Execute();
				message = string.Format(GetResourceValue(userConnection, "QueueItemDateUpdatedMessage"), queueItemId,
					nextProcessingDate.ToString());
				QueuesUtilities.LogDebug(message);
			} catch (Exception e) {
				message = string.Format(GetResourceValue(userConnection, "InvokeMethodErrorMessage"),
					"ChangeQueueItemDate", e.Message);
				QueuesUtilities.LogError(message, e);
				throw;
			}
		}

		/// <summary>
		/// Postpones (queues up) a queue item.
		/// </summary>
		/// <param name="queueItemId">Queue item identifier.</param>
		/// <returns>The number of items processed in the queue.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "PostponeQueueItem", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int PostponeQueueItem(Guid queueItemId) {
			var userConnection = UserConnection;
			int updateCount = 0;
			string message = string.Empty;
			try {
				if (userConnection == null) {
					throw new ArgumentNullException("UserConnection");
				}
				var schema = userConnection.EntitySchemaManager.GetInstanceByName("QueueItem");
				var entity = schema.CreateEntity(userConnection);
				entity.UseAdminRights = false;
				if (entity.FetchFromDB(queueItemId, false)) {
					entity.SetColumnValue("PostponesCount", entity.GetTypedColumnValue<int>("PostponesCount") + 1);
					entity.SetColumnValue("OperatorId", null);
					entity.SetColumnValue("NextProcessingDate", null);
					if (entity.Save()) {
						updateCount++;
					}
				}
				message = string.Format(GetResourceValue(userConnection, "QueueItemPostponeUpdatedMessage"),
					queueItemId);
				QueuesUtilities.LogDebug(message);
			} catch (Exception e) {
				message = string.Format(GetResourceValue(userConnection, "InvokeMethodErrorMessage"),
					"PostponeQueueItem", e.Message);
				QueuesUtilities.LogError(message, e);
				throw;
			}
			return updateCount;
		}

		/// <summary>
		/// Adds queue items from selected groups.
		/// </summary>
		/// <param name="folderIds">List of identifiers of the selected groups.</param>
		/// <param name="entitySchemaName">The schema name of the queue object.</param>
		/// <param name="queueId">Queue identifier.</param>
		/// <returns>A serialized object with information about the number of entries added and error messages.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddFoldersQueueItems",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public string AddFoldersQueueItems(List<object> folderIds, string entitySchemaName, Guid queueId) {
			var queueFolderUtilities = ClassFactory.Get<QueuesFolderUtilities>(new[] {
				new ConstructorArgument("userConnection", UserConnection)
			});
			var validationError = queueFolderUtilities.ValidateAddFolderQueueItemsParams(folderIds, entitySchemaName, queueId);
			if (validationError.IsNotNullOrEmpty()) {
				return validationError;
			}
			var response = queueFolderUtilities.AddQueueItems(folderIds, entitySchemaName, queueId);
			return response;
		}

		/// <summary>
		/// Asynchronously adds queue items from selected groups.
		/// </summary>
		/// <param name="folderIds">List of identifiers of the selected groups.</param>
		/// <param name="entitySchemaName">The schema name of the queue object.</param>
		/// <param name="queueId">Queue identifier.</param>
		/// <returns>A serialized object with information and error messages.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ScheduleAddFoldersQueueItems",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public string ScheduleAddFoldersQueueItems(List<object> folderIds, string entitySchemaName, Guid queueId) {
			var queueFolderUtilities = new QueuesFolderUtilities(UserConnection);
			var validationError = queueFolderUtilities.ValidateAddFolderQueueItemsParams(folderIds, entitySchemaName, queueId);
			if (validationError.IsNotNullOrEmpty()) {
				return validationError;
			}
			var errorMessage = "";
			var info = GetResourceValue(UserConnection, "AddFoldersQueueItemsStarted");
			try {
				var currentUser = UserConnection.CurrentUser;
				string jobGroup = string.Concat("AsyncAddingFolderQueueItems", "_", currentUser.Id.ToString());
				if (!AppSchedulerWrapper.DoesJobGroupExist(jobGroup)) {
					var parameters = new Dictionary<string, object> {
						{ "folderIds", folderIds },
						{ "entitySchemaName", entitySchemaName },
						{ "queueId", queueId }
					};
					AppSchedulerWrapper.ScheduleImmediateJob<AsyncAddingFolderQueueItemsExecutor>(jobGroup, UserConnection.Workspace.Name,
						currentUser.Name, parameters);
				} else {
					info = GetResourceValue(UserConnection, "AddFoldersQueueItemsAlreadyStarted");
				}	
			} catch (Exception e) {
				errorMessage = e.Message;
				info = "";
			}
			var result = new {
				infoMessage = info,
				errorMessages = errorMessage
			};
			return ServiceStackTextHelper.Serialize(result);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "FillSingleQueue",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public void FillSingleQueue(Guid queueId) {
			if (!UserConnection.GetIsFeatureEnabled("FillSingleQueue")) {
				return;
			}
			var queuesUpdateUtilities = ClassFactory.Get<QueuesUpdateUtilities>(new[] {
				new ConstructorArgument("userConnection", UserConnection)
			});
			queuesUpdateUtilities.ProcessAutoUpdateQueues(queueId);
			queuesUpdateUtilities.ProcessDeleteInactiveQueueItems();
		}

		#endregion

	}

	#endregion

}

