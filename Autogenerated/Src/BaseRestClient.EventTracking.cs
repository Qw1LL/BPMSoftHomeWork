namespace BPMSoft.Configuration
{
	using System;
	using System.IO;
	using System.Net;
	using System.Text;
	using System.Runtime.Serialization;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;
	using BPMSoft.Core;

	#region Class: BaseRestClient

	public abstract class BaseRestClient<T>
	{

		#region Fields: Private

		private string _requestMethod;

		private string _responseJson;

		private UserConnection _userConnection;

		private string _basicAuth;

		#endregion
		
		#region Properties: Public

		[IgnoreDataMember]
		public bool Success {
			get;
			set;
		}

		[IgnoreDataMember]
		public string ExceptionMessage {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected UserConnection GetUserConnection() {
			return _userConnection;
		}

		#endregion

		#region Methods: Private

		private string SendRequest(string urlWebService) {
			var error = string.Empty;
			Success = true;
			try {
				var request = (HttpWebRequest)HttpWebRequest.Create(urlWebService);
				request.ContentType = "application/json";
				if (!string.IsNullOrEmpty(_basicAuth)) {
					request.Headers.Add("Authorization", _basicAuth);
				}
				var stringRequest = GetRequestJson();
				var bytes = System.Text.Encoding.UTF8.GetBytes(stringRequest);

				if (!string.IsNullOrEmpty(stringRequest) && _requestMethod != "GET") {
					request.Method = _requestMethod;
					using (var stream = request.GetRequestStream()) {
						stream.Write(bytes, 0, bytes.Length);
					}
				}
				using (var respons = request.GetResponse()) {
					var streamRespons = respons.GetResponseStream();
					using (var reader = new StreamReader(streamRespons)) {
						_responseJson = reader.ReadToEnd();
						return _responseJson;
					}
				}
			} catch (WebException e) {
				ExceptionMessage = e.Message;
				Success = false;
				return null;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Set basic authorization for request.
		/// </summary>
		/// <param name="login">Login.</param>
		/// <param name="password">Password.</param>
		public void SetBasicAuth(string login, string password) {
			byte[] toEncodeAsBytes = ASCIIEncoding.ASCII.GetBytes(login + ":" + password);
			_basicAuth = "Basic " + Convert.ToBase64String(toEncodeAsBytes);
		}

		/// <summary>
		/// Set request method.
		/// </summary>
		/// <param name="requestMethod">Request method POST/GET.</param>
		public void SetRequestMethod(string requestMethod) {
			_requestMethod = requestMethod;
		}

		/// <summary>
		/// Execute HTTP web request.
		/// </summary>
		/// <param name="url">Request url.</param>
		/// <returns>Return type.</returns>
		public T Execute(string url) {
			var bodyResponse = SendRequest(url);
			return !string.IsNullOrEmpty(bodyResponse) ? JsonConvert.DeserializeObject<T>(bodyResponse) : default(T);
		}

		/// <summary>
		/// Return request body.
		/// </summary>
		/// <returns>Object.</returns>
		public string GetRequestJson() {
			var settings = new JsonSerializerSettings();
			settings.Converters.Add(new StringEnumConverter());
			settings.Converters.Add(new IsoDateTimeConverter());
			var serializer = JsonSerializer.Create(settings);
			var sb = new StringBuilder();
			using (var sw = new StringWriter(sb)) {
				serializer.Serialize(sw, this);
			}
			return sb.ToString();
		}

		/// <summary>
		/// Return response body.
		/// </summary>
		/// <returns>Object.</returns>
		public string GetResponseJson() {
			return _responseJson;
		}

		/// <summary>
		/// Set UserConnection.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		public void SetUserConnection(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

	}

	#endregion

}
