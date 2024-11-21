namespace BPMSoft.Configuration.BpCloudIntegration
{
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Services;
	using CoreConfig = Core.Configuration;

	#region Class: IdentityServerProvider

	/// <summary>
	/// Class to work with IdentityServer.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.Tracking.IIdentityServerProvider" />
	[DefaultBinding(typeof(IdentityServerProvider))]
	public class IdentityServerProvider
	{

		#region Constants: Private

		private const string _identityAddressSettingsName = "IdentityServerUrl";
		private const string _clientIdSettingsName = "IdentityServerClientId";
		private const string _clientSecretSettingsName = "IdentityServerClientSecret";

		#endregion

		#region Fields: Private

		private readonly string _serverUrl;
		private readonly string _clientId;
		private readonly string _clientSecret;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="IdentityServerProvider"/> class.
		/// </summary>
		/// <param name="userConnection">User connection parameters.</param>
		public IdentityServerProvider(UserConnection userConnection) {
			(_serverUrl, _clientId, _clientSecret) = GetConnectionParams(userConnection);
		}

		#endregion

		#region Methods: Private

		private (string serverAddress, string clientId, string clientSecret) GetConnectionParams(UserConnection userConnection) {
			var serverAddress = CoreConfig.SysSettings.GetValue(userConnection, _identityAddressSettingsName, "");
			var clientId = CoreConfig.SysSettings.GetValue(userConnection, _clientIdSettingsName, "");
			var clientSecret = CoreConfig.SysSettings.GetValue(userConnection, _clientSecretSettingsName, "");
			return (serverAddress, clientId, clientSecret);
		}

		#endregion

		#region Methods: Public

		public string GetAccessToken(string scope) {
			var settingsProvider = new IdentityServiceSettingsProvider(_serverUrl, _clientId, _clientSecret);
			IIdentityClient identityClient = ClassFactory.Get<IIdentityClient>(
				new ConstructorArgument("settingsProvider", settingsProvider));
			var token = identityClient.RequestClientCredentialsTokenAsync(_clientId, _clientSecret, scope)
				.GetAwaiter().GetResult();
			return token;
		}

		#endregion

	}

	#endregion
}
