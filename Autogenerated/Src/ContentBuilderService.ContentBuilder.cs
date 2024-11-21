namespace BPMSoft.Configuration 
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Web.Common;

	#region Class: ContentBuilderService

	/// <summary>############### web-service ######### ########</summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ContentBuilderService : BaseService {

		#region Fields: Private

		#endregion

		#region Methods: Public

		/// <summary>
		/// ########## ######### # ##### websocket.
		/// </summary>
		/// <param name="recordId">########## ############# ######.</param>
		/// <param name="senderName">############# ###########.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ReloadContent", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ReloadContent(Guid recordId, string senderName) {
			string msg = string.Format("{{\"recordId\": \"{0}\"}}", recordId);
			MsgChannelUtilities.PostMessage(UserConnection, senderName, msg);
		}

		#endregion

	}

	#endregion

	#region Class: ContentBuilderServirce

	[Obsolete("Class is deprecated. Use ContentBuilderService instead")]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ContentBuilderServirce : ContentBuilderService {
	}

	#endregion

}
