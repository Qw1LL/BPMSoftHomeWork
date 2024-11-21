namespace BPMSoft.Configuration.SocialLeadGen
{
	using System.Net;
	using BPMSoft.Configuration.BpCloudIntegration;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using RestSharp;
	using Newtonsoft.Json;

	#region Class: SocialLeadGenRestProvider

	/// <summary>
	/// Provide information from tracking service.
	/// </summary>
	public class SocialLeadGenRestProvider
	{

		#region Properties: Private

		private IdentityServerProvider _identityServerProvider;
		/// <summary>
		/// Identity server provider instance. Returns established provider.
		/// If established is null then create instance of <see cref="IdentityServerProvider"/> 
		/// from <see cref="ClassFactory"/>.
		/// </summary>
		private IdentityServerProvider IdentityServerProvider {
			get {
				if (_identityServerProvider == null) {
					_identityServerProvider = CreateIdentityServerProvider();
				}
				return _identityServerProvider;
			}
			set {
				_identityServerProvider = value;
			}
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection { get; private set; }

		private IRestClient _restClient;
		/// <summary>
		/// Gets or sets the rest client for Api calls.
		/// </summary>
		/// <value>
		/// The rest client.
		/// </value>
		protected IRestClient RestClient {
			get {
				if (_restClient == null) {
					_restClient = new RestClient();
					_restClient.AddDefaultHeader("Content-Type", "application/json");
				}
				return _restClient;
			}
			set {
				_restClient = value;
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		public SocialLeadGenRestProvider(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private IdentityServerProvider CreateIdentityServerProvider() {
			var userConnectionArg = new ConstructorArgument("userConnection", UserConnection);
			return ClassFactory.Get<IdentityServerProvider>(userConnectionArg);
		}

		private RestRequest CreateRequestWithToken(string url) {
			var token = IdentityServerProvider.GetAccessToken("social_leadgen_api");
			var request = new RestRequest(url);
			request.AddHeader("Authorization", $"Bearer {token}");
			return request;
		}

		private T GetResponseData<T>(IRestResponse<T> response) where T : SocialLeadGenRestProviderResponse, new() {
			return response?.Data ?? new T();
		}

		private T SendTokenizedReques<T>(Method method, string url, object bodyObject = default)
				where T : SocialLeadGenRestProviderResponse, new() {
			var request = CreateRequestWithToken(url);
			request.RequestFormat = DataFormat.Json;
			request.Method = method;
			if (bodyObject != default) {
#if NETFRAMEWORK
				request.AddBody(bodyObject);
#else
				request.AddJsonBody(bodyObject);
#endif
			}
			var response = RestClient.Execute<T>(request);
			CheckResponseForError(response);
			return GetResponseData(response);
		}

		private IRestResponse SendTokenizedReques(Method method, string url, string jsonBody) {
			var request = CreateRequestWithToken(url);
			request.RequestFormat = DataFormat.Json;
			request.Method = method;
			if (jsonBody != default) {
				request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
			}
			var response = RestClient.Execute(request);
			CheckResponseForError(response);
			return response;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Checks response for exceptions occured.
		/// </summary>
		/// <typeparam name="T">Data provider response type.</typeparam>
		/// <param name="response">Instance of the response.</param>
		/// <exception cref="DataProviderException">Throws when <paramref name="response"/> 
		/// status code is not <see cref="HttpStatusCode.OK"/></exception>
		protected void CheckResponseForError<T>(IRestResponse<T> response) where T : SocialLeadGenRestProviderResponse, new() {
			if (response.StatusCode != HttpStatusCode.OK) {
				var errorMessage = response.Data?.ErrorMessage ?? response.ErrorMessage
					?? response.Content ?? response.StatusDescription;
				throw new SocialLeadGenRestProviderException(response.Data?.ErrorMessage, errorMessage,
					response.ErrorException, response.StatusCode, response.Request?.Resource);
			}
		}

		/// <summary>
		/// Checks response for exceptions occured.
		/// </summary>
		/// <param name="response">Instance of the response.</param>
		/// <exception cref="DataProviderException">Throws when <paramref name="response"/> 
		/// status code is not <see cref="HttpStatusCode.OK"/></exception>
		protected void CheckResponseForError(IRestResponse response) {
			if (response.StatusCode != HttpStatusCode.OK) {
				SocialLeadGenRestProviderResponse remoteErrorResponse = null;
				try {
					remoteErrorResponse = JsonConvert.DeserializeObject<SocialLeadGenRestProviderResponse>(response.Content);
				} catch { }
				var errorMessage = remoteErrorResponse?.ErrorMessage ?? response.ErrorMessage
					?? response.Content ?? response.StatusDescription;
				throw new SocialLeadGenRestProviderException(remoteErrorResponse?.ErrorMessage, errorMessage,
					response.ErrorException, response.StatusCode, response.Request?.Resource);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sends <see cref="RestRequest"/> to <paramref name="url"/> with <paramref name="bodyObject"/>.
		/// Sets token to request and request body format <see cref="Method.POST"/>.
		/// </summary>
		/// <typeparam name="T"><see cref="DataProviderResponse"/> object or inherited classes 
		/// with default constructor.</typeparam>
		/// <param name="url">Url addres for request.</param>
		/// <param name="bodyObject">Body object for request.</param>
		/// <returns>Response data.</returns>
		/// <exception cref="DataProviderException">Exception thrown when request has network problems 
		/// or cloud endpoint returns response with error message.</exception>
		public T SendTokenizedPostRequest<T>(string url, object bodyObject) where T : SocialLeadGenRestProviderResponse, new() {
			return SendTokenizedReques<T>(Method.POST, url, bodyObject);
		}

		/// <summary>
		/// Sends <see cref="RestRequest"/> to <paramref name="url"/> with <paramref name="bodyObject"/>.
		/// Sets token to request and request body format <see cref="Method.POST"/>.
		/// </summary>
		/// <param name="url">Url addres for request.</param>
		/// <param name="bodyObject">Body object for request as string</param>
		/// <returns>Raw response from API.</returns>
		/// <exception cref="DataProviderException">Exception thrown when request has network problems 
		/// or cloud endpoint returns response with error message.</exception>
		public string SendTokenizedPostRequest(string url, string bodyObject) {
			var response = SendTokenizedReques(Method.POST, url, bodyObject);
			return response.Content;
		}

		#endregion

	}

	#endregion

}
