namespace BPMSoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;


	#region Class: GoogleSharedOAuthAuthenticator

	/// <summary>
	/// Represents an Google shared application OAuth authenticator service contract.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GoogleSharedOAuthAuthenticator: BaseGoogleSharedOAuthAuthenticator
	{

		#region Constructors: Public

		/// <summary><see cref="OAuthAuthenticator(UserConnection)"/></summary>
		public GoogleSharedOAuthAuthenticator(UserConnection userConnection): base(userConnection) {
		}

		/// <summary><see cref="OAuthAuthenticator(UserConnection)"/></summary>
		public GoogleSharedOAuthAuthenticator() : base(){
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Start OAuth authentification flow for user using google shared application.
		/// </summary>
		/// <param name="userLogin">User login to the application.</param>
		/// <param name="mailServerId">Mail server unique identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "AuthenticateUser?userLogin={userLogin}&mailServerId={mailServerId}", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public override string AuthenticateUser(string userLogin, Guid mailServerId) {
			return base.AuthenticateUser(userLogin, mailServerId);
		}

		/// <summary>
		/// Saves recived from shared application OAuth tokes and user settings.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "SharedAppAuthCallback",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public override void SharedAppAuthCallback() {
			base.SharedAppAuthCallback();
		}

		#endregion

	}

	#endregion

}

