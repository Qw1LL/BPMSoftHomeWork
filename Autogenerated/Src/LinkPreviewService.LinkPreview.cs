 using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web.SessionState;
using BPMSoft.Core.Factories;
using BPMSoft.Web.Common;

namespace BPMSoft.Configuration
{
	#region Class: LinkPreviewServiceResponse

	/// <summary>
	/// Class of link preview service response.
	/// </summary>
	[DataContract]
	public class LinkPreviewServiceResponse : ConfigurationServiceResponse
	{
		#region Properties: Public

		[DataMember(Name = "linkPreviewInfo")]
		public LinkPreviewInfo LinkPreviewInfo { get; set; }

		#endregion
	}

	#endregion

	#region Class: LinkPreviewService

	/// <summary>
	/// Class of link preview service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class LinkPreviewService : BaseService, IReadOnlySessionState
	{
		#region Methods: Private

		private LinkPreview CreateLinkPreview() {
			return ClassFactory.Get<LinkPreview>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets web page link preview info.
		/// </summary>
		/// <param name="url">Url.</param>
		/// <returns>Web page link preview info.</returns>
		[OperationContract]
		[return: MessageParameter(Name = "result")]
		[WebInvoke(Method = "POST", UriTemplate = "GetWebPageLinkPreview", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public LinkPreviewServiceResponse GetWebPageLinkPreview(string url) {
			LinkPreview linkPreview = CreateLinkPreview();
			LinkPreviewServiceResponse response = new LinkPreviewServiceResponse();
			try {
				response.LinkPreviewInfo = linkPreview.GetWebPageLinkPreview(url);
			} catch (Exception e) {
				response.Exception = e;
			}
			return response;
		}

		#endregion
	}

	#endregion
}
