namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Net;
	using global::Common.Logging;
	using RestSharp;
	using DeduplicationElastic.Domain.Deduplication.Task;
	using DeduplicationElastic.WebApi.Contracts.Response;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Web.Http.Abstractions;

	#region class: BulkDeduplicationTaskRestClient

	/// <summary>
	/// Rest based implementation of <see cref="IBulkDeduplicationTaskClient"/>
	/// </summary>
	[DefaultBinding(typeof(IBulkDeduplicationTaskClient))]
	public class BulkDeduplicationTaskRestClient : IBulkDeduplicationTaskClient
	{

		#region Fields: Private

		private const string DeduplicationTaskControllerPath = "api/deduplication/task/";
		private readonly string _deduplicationWebApiUrl = string.Empty;
		private readonly string _globalSearchUrl = string.Empty;
		private static readonly ILog _log = LogManager.GetLogger("Deduplication");
		private static string DeduplicationWebApiUrlSettingCode = "DeduplicationWebApiUrl";

		#endregion

		#region Properties: Private

		private IRestClient _restClient;
		private IRestClient RestClient {
			get {
				if (_restClient != null) {
					return _restClient;
				}
				var tag = DeduplicationEventListener.BulkDeduplicationTaskRestClientTag;
				if (!ClassFactory.TryGet(tag, out _restClient)) {
					throw new ArgumentNullException($"Deduplication rest client - {tag} not resolved.");
				}
				string url = _deduplicationWebApiUrl.TrimEnd('/');
		#if NETSTANDARD2_0
				RestClient.BaseUrl = new Uri(url);
		#else
				RestClient.BaseUrl = url;
		#endif
				return _restClient;
			}
		}

		#endregion

		#region Constructors: Public

		public BulkDeduplicationTaskRestClient(UserConnection userConnection) {
			_deduplicationWebApiUrl = SysSettings.GetValue(userConnection, DeduplicationWebApiUrlSettingCode, string.Empty);
		}

		#endregion

		#region Methods: Private

		private DeduplicationTaskStatus? GetDeduplicationTaskStatus(IRestResponse<DeduplicationTaskResponse> response, string entityName) {
			var deduplicationTaskResponse = response.Data;
			switch (response.StatusCode) {
				case HttpStatusCode.OK: {
					return deduplicationTaskResponse.TaskStatus;
				}
				case HttpStatusCode.NotFound: {
					if (deduplicationTaskResponse == null) {
						_log.Error($"GetDeduplicationTaskStatus for '{entityName}' failed. StatusCode: {response.StatusCode}, " +
							$"ErrorMessage: {response.ErrorMessage}, ErrorException: {response.ErrorException}, " +
							$"Content: {response.Content}, ResponseUri: {response.ResponseUri}");
						throw new HttpException(HttpStatusCode.NotFound, response.Content);
					}
					return null;
				}
				default: {
					_log.Error($"GetDeduplicationTaskStatus failed. StatusCode: {response.StatusCode}, " +
						$"ErrorMessage: {response.ErrorMessage}, ErrorException: {response.ErrorException}, " +
						$"Content: {response.Content}, ResponseUri: {response.ResponseUri}");
					throw new NotSupportedException($"Status code {response.StatusCode} not supported. ");
				}
			}
		}

		private IRestResponse<DeduplicationTaskResponse> GetDeduplicationTaskResponse(string controllerActionName, string entityName, string indexName) {
			var resource = $"{DeduplicationTaskControllerPath}{controllerActionName}";
			var request = new RestRequest(resource, Method.GET);
			request.RequestFormat = DataFormat.Json;
			request.AddParameter("sourceEntityName", entityName, ParameterType.QueryString);
			request.AddParameter("elasticIndexName", indexName, ParameterType.QueryString);
			return RestClient.Execute<DeduplicationTaskResponse>(request);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public DeduplicationTaskStatus? GetDeduplicationTaskStatus(string entityName, string indexName) {
			var response = GetDeduplicationTaskResponse("status", entityName, indexName);
			return GetDeduplicationTaskStatus(response, entityName);
		}

		/// <inheritdoc/>
		public DeduplicationTaskResponse GetActualDeduplicationTask(string entityName, string indexName) {
			var response = GetDeduplicationTaskResponse("actual", entityName, indexName);
			if (response.StatusCode == HttpStatusCode.NotFound) {
				return null;
			}
			if (response.StatusCode != HttpStatusCode.OK) {
				throw new HttpException(response.StatusCode, response.Content);
			}
			return response.Data;
		}

		#endregion

	} 

	#endregion

}

