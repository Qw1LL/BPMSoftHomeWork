namespace BPMSoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;

	/// <summary>
	/// Represents an Google OAuth authentication service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GoogleOAuthAuthenticator : BaseGoogleOAuthAuthenticator {

		#region Constructors: Public

		/// <summary><see cref="OAuthAuthenticator(UserConnection)"/></summary>
		public GoogleOAuthAuthenticator(UserConnection userConnection): base(userConnection) {
		}

		/// <summary><see cref="OAuthAuthenticator()"/></summary>
		public GoogleOAuthAuthenticator() : base() {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Authentications user in the specific OAuth application.
		/// </summary>
		/// <param name="userLogin">User login to the application.</param>
		/// <param name="mailServerId">Mail server unique identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "AuthenticateUser?userLogin={userLogin}&mailServerId={mailServerId}",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public override string AuthenticateUser(string userLogin, Guid mailServerId) {
			return base.AuthenticateUser(userLogin, mailServerId);
		}

		/// <summary>
		/// Processes authentication code from OAuth application.
		/// </summary>
		/// <param name="code">Authentication code.</param>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "ProcessAuthenticationCode?code={code}", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public override void ProcessAuthenticationCode(string code) {
			base.ProcessAuthenticationCode(code);
		}

		#endregion

	}
}
