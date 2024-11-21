namespace BPMSoft.Configuration
{
	using System;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Core;
	using BPMSoft.GoogleServerConnector;
	using BPMSoft.Social.OAuth;

	#region Class BaseGoogleSharedOAuthAuthenticator

	/// <summary>
	/// Class contains settings and methods for OAuth authorization flow realization, using bpmcrm google shared application.
	/// </summary>
	public class BaseGoogleSharedOAuthAuthenticator : BaseGoogleOAuthAuthenticator
	{

		#region Constructors: Public

		/// <summary><see cref="OAuthAuthenticator(UserConnection)"/></summary>
		public BaseGoogleSharedOAuthAuthenticator(UserConnection userConnection): base(userConnection) {
		}

		/// <summary><see cref="OAuthAuthenticator()"/></summary>
		public BaseGoogleSharedOAuthAuthenticator() : base() {
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// <see cref="GoogleServerConnector"/> instance. Used as access point to shared google application api keys.
		/// </summary>
		private GoogleServerConnector _googleServerConnector;
		protected GoogleServerConnector GoogleServerConnector {
			get {
				if (_googleServerConnector != null) {
					return _googleServerConnector;
				}
				return _googleServerConnector = new GoogleServerConnector() {
					UserConnection = UserConnection
				};
			}
			set {
				_googleServerConnector = value;
			}
		}

		/// <summary>
		/// State parameter for google shared application contains bpmcrm endpoint, where access token would be processed.
		/// </summary>
		protected virtual string StateUri {
			get {
				return string.Format("{0}/rest/{1}/SharedAppAuthCallback", BpmDomainApplicationUrl, ApplicationClassName);
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Google shared application redirect url.
		/// </summary>
		public override string RedirectUrl {
			get {
				return UserConnection.AppConnection.ConsumerInfoServiceAccessInfoPageUri;
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary><see cref="OAuthAuthenticator.Initialize"/></summary>
		protected override void Initialize() {
			base.Initialize();
			GoogleConsumerInfo consumerInfo = GoogleServerConnector.GetConsumerInfo();
			ClientId = consumerInfo.Key;
			SecretKey = consumerInfo.Secret;
		}

		/// <summary><see cref="OAuthAuthenticator.GetStateAsString"/></summary>
		protected override string GetStateAsString() {
			string userParams = base.GetStateAsString();
			return string.Format("{0}?userParams={1}", StateUri, userParams);
		}

		/// <summary>
		/// Creates <see cref="OAuthUserCredentials"/> instance using google shared application response.
		/// By default, shared application will return requested access and refresh tokens, and any parameters, 
		/// encoded in state parameter.
		/// This implementation sets user login and mail server unique identifier to state parameter in <see cref="SetState"/> method.
		/// </summary>
		/// <returns><see cref="OAuthUserCredentials"/> instance.</returns>
		protected virtual OAuthUserCredentials GetCredentials() {
			string access_token = Request.QueryString["access_token"];
			string refresh_token = Request.QueryString["access_secret"];
			string rawUserParams = Request.QueryString["userParams"];
			JObject userParams = JObject.Parse(rawUserParams);
			if (!State.ContainsKey("MailServerId")) {
				State.Add("MailServerId", userParams.Value<string>("MailServerId"));
			}
			return new OAuthUserCredentials {
				AccessToken = access_token,
				RefreshToken = refresh_token,
				ExpiresOn = 0,
				UserLogin = userParams.Value<string>("login"),
				ApplicationId = ApplicationId
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Saves recived from shared application OAuth tokes and user settings.
		/// </summary>
		public virtual void SharedAppAuthCallback() {
			Initialize();
			try {
				OAuthUserCredentials credentials = GetCredentials();
				SaveCredentials(credentials);
				JObject result = GetSuccessResultObject(credentials);
				AppendCookieToResponse(true, result);
			} catch (Exception ex) {
				AppendError(ex);
			}
			RedirectToBpm(FinalStageRedirectUrl);
		}

		#endregion

	}

	#endregion

}
