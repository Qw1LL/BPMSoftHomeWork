namespace BPMSoft.Configuration.SocialNetworksUtilitiesService
{
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Social;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: SocialNetworksUtilitiesService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SocialNetworksUtilitiesService : BaseService
	{

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method="POST", UriTemplate = "GetOAuthTokens", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetOAuthTokens(string socialNetworkName) {
			
			// NOT USED, FOR FUTURE NEEDS
			if (string.IsNullOrEmpty(socialNetworkName)) {
				throw new ArgumentNullOrEmptyException("socialNetworkName");
			}
			string accessToken = string.Empty;
			string accessSecretToken = string.Empty;
			string socialId = string.Empty;
			string userId = UserConnection.CurrentUser.ContactId.ToString();
			
			//TODO check is always should be current user
			string errorMessage;
			AuthResult authResult = SocialCommutator.CompleteAuthentication(UserConnection, socialNetworkName,
				out accessToken, out accessSecretToken, out socialId, out errorMessage);
			if (authResult == AuthResult.Failed) {
				if (string.IsNullOrEmpty(errorMessage)){
					var userToken = new UserToken(userId, true);
					try {
						SocialCommutator.StartAuthentication(UserConnection, socialNetworkName, userToken);
					} catch (SocialNetworkException){
						// TODO !!!!
					}
				} else {
					// TODO
				}
				return string.Empty;
			}
			if (authResult == AuthResult.Success) {
				string result = @"
				{
					""Token"": """ + accessToken + @""",
					""Secret"":  """ + accessSecretToken + @""",
					""SocialId"": """ + socialId + @"""
				}";
			}
			// TODO !!!
			return string.Empty;
		}

		[OperationContract]
		[WebInvoke(UriTemplate = "GetOldOAuthAuthenticationUrl", ResponseFormat = WebMessageFormat.Json)]
		public string GetOldOAuthAuthenticationUrl() {
			return WebUtilities.GetUrl(HttpContext.Current.Request, "LegacySocialAccountAuthPage.aspx",
				HttpUtility.ParseQueryString("Id=3b22f0ff-034a-48da-8758-a0660e5a26ff"));
		}

		[OperationContract]
		[WebInvoke(Method="POST", UriTemplate = "GetSocialNetworkLogin", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		 public string GetSocialNetworkLogin(string socialNetworkName, string socialId, string accessToken) {
			string login = "System";
			if (socialNetworkName == "Google") {
				login = BPMSoft.Social.Google.GoogleConsumer.GetUserEmail(accessToken);
			}
			var network = SocialCommutator.CreateSocialNetwork(UserConnection, socialNetworkName);
			try {
				login = network.GetProfile(socialId).Name;
			} catch {}
			return login;
		 }

		#endregion

	}

	#endregion

}

