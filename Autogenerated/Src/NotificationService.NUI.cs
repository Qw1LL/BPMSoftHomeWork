namespace BPMSoft.Configuration.Notifications
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: NotificationService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class NotificationService : BaseService, IReadOnlySessionState
	{

		#region Fields: Private

		private IMarkNotificationAsReadExecutor _markNotificationAsReadExecutor;

		#endregion

		#region Constructors: Public

		public NotificationService() { }

		public NotificationService(UserConnection userConnection,
			IMarkNotificationAsReadExecutor markNotificationAsReadExecutor)
			: base(userConnection) {
			_markNotificationAsReadExecutor = markNotificationAsReadExecutor;
		}

		#endregion

		#region Properties: Private

		private IMarkNotificationAsReadExecutor MarkNotificationAsReadExecutor =>
			_markNotificationAsReadExecutor ?? (_markNotificationAsReadExecutor =
				ClassFactory.Get<IMarkNotificationAsReadExecutor>(new ConstructorArgument("userConnection",
					UserConnection)));

		#endregion

		#region Methods: Public

		// Sets IsRead for notifications.
		/// <param name="notificationTypeId"></param>
		/// <param name="remindTime"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse MarkNotificationAsRead(Guid notificationTypeId, string remindTime) {
			var response = new ConfigurationServiceResponse();
			try {
				notificationTypeId.CheckArgumentEmpty(nameof(notificationTypeId));
				remindTime.CheckArgumentNull(nameof(remindTime));
				var dateRemindTime = DateTime.Parse(remindTime);
				MarkNotificationAsReadExecutor.Execute(notificationTypeId, dateRemindTime);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		#endregion

	}

	#endregion

}

