namespace BPMSoft.Configuration
{
	using RestSharp;

	#region Class: RestClientFactory

	/// <summary>
	/// Factory, which creates REST client with correct default settings.
	/// </summary>
	public static class RestClientFactory
	{

		#region Methods: Public

		/// <summary>
		/// Creates REST client with appropriate handlers.
		/// </summary>
		/// <param name="baseUrl">Base URL to use for all requests.</param>
		/// <returns>REST request.</returns>
		public static IRestClient CreateRestClient(string baseUrl = "") {
			RestClient client = string.IsNullOrEmpty(baseUrl)
				? new RestClient()
				: new RestClient(baseUrl);
			client.SetupDeserializationHandlers();
			return client;
		}

		#endregion

	}

	#endregion

}
