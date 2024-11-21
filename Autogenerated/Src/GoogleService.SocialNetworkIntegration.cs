namespace BPMSoft.Configuration.Social
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel.Activation;
	using System.Web.SessionState;
	using BPMSoft.GoogleServerConnector;

	#region Class: GoogleService

	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GoogleService : SocialNetworkService<GoogleSharedApplicationConnector>, IGoogleService, IReadOnlySessionState
	{

		#region Methods: Public

		/// <summary>
		/// Returns consumer information about google shared application.
		/// </summary>
		/// <returns>Consumer information.</returns>
		public GoogleConsumerInfoResponse GetConsumerInfo() {
			try {
				return new GoogleConsumerInfoResponse {
					ConsumerInfo = ServerConnector.GetConsumerInfo()
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<GoogleConsumerInfoResponse>(e);
			}
		}

		#endregion

	}

	#endregion

	#region Class: GoogleConsumerInfoResponse

	[DataContract]
	public class GoogleConsumerInfoResponse : ConfigurationServiceResponse
	{

		#region Properties: Public
		
		[DataMember(Name = "consumerInfo")]
		public GoogleConsumerInfo ConsumerInfo {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
