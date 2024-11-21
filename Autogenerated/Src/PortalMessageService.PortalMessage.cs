namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;

	#region Class: PortalMessageService

	/// <summary>
	/// Service for working with portal messages.
	/// </summary>
	[ServiceContract]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class PortalMessageService : BaseService
	{

		#region Methods: Public

		/// <summary>
		/// Gets portal message attributes connected to <paramref name="messageHistoryId"/>.
		/// </summary>
		/// <param name="messageHistoryId">MessageHistory identifier.</param>
		/// <param name="historySchemaName">Schema name of history object.</param>
		/// <returns>Portal email message.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public SecurePortalMessageAttributes GetPortalMessageAttributes(Guid messageHistoryId,
				string historySchemaName) {
			return new SecurePortalMessage(UserConnection).FetchAttributesByMessageHistory(messageHistoryId,
				historySchemaName);
		}

		#endregion

	}

	#endregion

	#region Class: SecurePortalMessageAttributes

	[DataContract]
	public class SecurePortalMessageAttributes
	{
		[DataMember(Name = "hideOnPortal")]
		public bool HideOnPortal { get; set; }

		[DataMember(Name = "fromPortal")]
		public bool FromPortal { get; set; }

		[DataMember(Name = "messageType")]
		public Guid MessageType { get; set; }

		[DataMember(Name = "messageTypeCaption")]
		public string MessageTypeCaption { get; set; }
	}

	#endregion

}
