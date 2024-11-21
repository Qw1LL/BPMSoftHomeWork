namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.ServiceModelContract;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;

	#region Class: GetLastChatResponse

	[DataContract]
	public class GetLastChatResponse : BaseResponse
	{

		#region Properties: Public

		/// <summary>
		/// Last chat identifier.
		/// </summary>
		[DataMember(Name = "lastChatId")]
		public Guid LastChatId { get; set; }

		/// <summary>
		/// Whether the last chat is completed.
		/// </summary>
		public bool IsLastChatCompleted { get; set; }

		#endregion

	}

	#endregion

	#region Class: OmnichannelContactService

	/// <summary>
	/// Service for using omnichannel in contact.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class OmnichannelContactService : BaseService
	{

		#region Properties: Protected

		private OpenChatFromContactVerifier _openChatFromContactVerifier;
		protected OpenChatFromContactVerifier OpenChatFromContactVerifier {
			get {
				return _openChatFromContactVerifier = _openChatFromContactVerifier ?? new OpenChatFromContactVerifier(UserConnection);
			}
		}

		#endregion

		#region Methods: Public


		/// <summary>
		/// Returns last chat identifier.
		/// </summary>
		/// <param name="contactId">Identifier of contact.</param>
		///  <param name="providerId">Identifier of provider.</param>
		/// <returns>Last chat identifier</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public GetLastChatResponse GetLastChatId(Guid contactId, Guid providerId) {
			return OpenChatFromContactVerifier.CheckContactDataAndGetChatId(contactId, providerId);
		}

		#endregion

	}

	#endregion

}
