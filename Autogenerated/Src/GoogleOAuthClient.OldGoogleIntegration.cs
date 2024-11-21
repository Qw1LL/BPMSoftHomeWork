namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Social.OAuth;

	/// <summary>
	/// Represents an Google OAuth client.
	/// </summary>
	[DefaultBinding(typeof(OAuthClient), Name = "GoogleOAuthClient")]
	public class GoogleOAuthClient : OAuthClient
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userLogin"></param>
		public GoogleOAuthClient(string userLogin, UserConnection userConnection) 
			: base(userLogin, userConnection) {
		}

		/// <summary>
		/// Returns authenticator for the Google OAuth client.
		/// </summary>
		/// <returns><see cref="BPMSoft.Social.OAuth.IOAuthAuthenticator"/> instance.</returns>
		protected override IOAuthAuthenticator GetAuthenticator(UserConnection userConnection) {
			return new GoogleOAuthAuthenticator(userConnection);
		}
	}
}

