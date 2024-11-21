namespace BPMSoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using IntegrationApi.Interfaces;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: ExchangeEventsService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ExchangeEventsService : BaseService
	{

		#region Methods: Protected

		/// <summary>
		/// Gets <see cref="IExchangeListenerManager"/> instance.
		/// </summary>
		protected IExchangeListenerManager GetExchangeListenerManager() {
			var managerFactory = ClassFactory.Get<IListenerManagerFactory>();
			return managerFactory.GetExchangeListenerManager(UserConnection);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Starts exchange listener by <see cref="MailboxSyncSettings"/> identifier.
		/// </summary>
		/// <param name="mailboxId"><see cref="MailboxSyncSettings"/> identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void StartListener(Guid mailboxId) {
			IExchangeListenerManager manager = GetExchangeListenerManager();
			manager.StartListener(mailboxId);
		}

		/// <summary>
		/// Stops exchange listener by <see cref="MailboxSyncSettings"/> identifier.
		/// </summary>
		/// <param name="mailboxId"><see cref="MailboxSyncSettings"/> identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void StopListener(Guid mailboxId) {
			IExchangeListenerManager manager = GetExchangeListenerManager();
			manager.StopListener(mailboxId);
		}

		/// <summary>
		/// Recreates exchange listener by <see cref="MailboxSyncSettings"/> identifier.
		/// </summary>
		/// <param name="mailboxId"><see cref="MailboxSyncSettings"/> identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RecreateListener(Guid mailboxId) {
			IExchangeListenerManager manager = GetExchangeListenerManager();
			manager.RecreateListener(mailboxId);
		}

		#endregion

	}

	#endregion

}

