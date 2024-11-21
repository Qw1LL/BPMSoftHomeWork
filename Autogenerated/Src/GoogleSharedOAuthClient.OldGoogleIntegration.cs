namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Social.OAuth;

	#region Class: GoogleSharedOAuthClient

	/// <summary>
	/// Represents an Google OAuth client for shared google application.
	/// </summary>
	[DefaultBinding(typeof(OAuthClient), Name = "GoogleSharedOAuthClient")]
	public class GoogleSharedOAuthClient : GoogleOAuthClient
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userLogin"></param>
		public GoogleSharedOAuthClient(string userLogin, UserConnection userConnection)
			: base(userLogin, userConnection) {
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns authenticator for the Google OAuth client for shared google application.
		/// </summary>
		/// <returns><see cref="BPMSoft.Social.OAuth.IOAuthAuthenticator"/> instance.</returns>
		protected override IOAuthAuthenticator GetAuthenticator(UserConnection userConnection) {
			return new GoogleSharedOAuthAuthenticator(userConnection);
		}

		#endregion

	}

	#endregion

}

