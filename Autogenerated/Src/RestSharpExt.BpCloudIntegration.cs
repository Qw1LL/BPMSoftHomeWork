namespace BPMSoft.Configuration
{
	using RestSharp;
	using RestSharp.Deserializers;

	/// <summary>
	/// Provides utility extension methods for RestSharp classes.
	/// </summary>
	public static class RestSharpExt
	{

		#region Methods: Public

		/// <summary>
		/// Adds deserialization handlers to the given REST client.
		/// </summary>
		/// <param name="restClient">REST client to setup.</param>
		public static void SetupDeserializationHandlers(this RestClient restClient) {
#if NETFRAMEWORK
			IDeserializer deserializer = new RestSharpJsonConverter();
			restClient.AddHandler("application/json", deserializer);
			restClient.AddHandler("text/json", deserializer);
			restClient.AddHandler("text/x-json", deserializer);
			restClient.AddHandler("text/javascript", deserializer);
			restClient.AddHandler("*+json", deserializer);
#else
			IDeserializer deserializerInstance = new RestSharpJsonConverter();
			IDeserializer getDeserializerAction() => deserializerInstance;
			restClient.AddHandler("application/json", getDeserializerAction);
			restClient.AddHandler("text/json", getDeserializerAction);
			restClient.AddHandler("text/x-json", getDeserializerAction);
			restClient.AddHandler("text/javascript", getDeserializerAction);
			restClient.AddHandler("*+json", getDeserializerAction);
#endif
		}

		/// <summary>
		/// Creates REST request with JSON content.
		/// </summary>
		/// <param name="restClient">REST client to setup.</param>
		/// <param name="resource">URI of the request.</param>
		/// <param name="body">Body of the request.</param>
		/// <param name="method">HTTP method to use.</param>
		/// <returns>REST request.</returns>
		public static IRestRequest CreateJsonRequest(this IRestClient restClient, string resource, object body,
				Method method = Method.POST) {
			var restRequest = restClient.CreateRequest(resource, method, DataFormat.Json);
			restRequest.JsonSerializer = new RestSharpJsonConverter();
#if NETFRAMEWORK
			restRequest.AddBody(body);
#else
			restRequest.AddJsonBody(body);
#endif
			return restRequest;
		}

		/// <summary>
		/// Creates REST request.
		/// </summary>
		/// <param name="restClient">REST client to setup.</param>
		/// <param name="resource">URI of the request.</param>
		/// <param name="method">HTTP method to use.</param>
		/// <param name="dataFormat">The data format.</param>
		/// <returns>
		/// REST request.
		/// </returns>
		public static IRestRequest CreateRequest(this IRestClient restClient, string resource,
				Method method = Method.POST, DataFormat? dataFormat = null) {
			var restRequest = new RestRequest {
				Resource = resource,
				Method = method
			};
			if (dataFormat.HasValue) {
				restRequest.RequestFormat = dataFormat.Value;
			}
			return restRequest;
		}

		#endregion

	}
}

