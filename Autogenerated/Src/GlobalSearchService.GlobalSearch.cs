namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Web.SessionState;
	using Core.Factories;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using RestSharp;
	using BPMSoft.Configuration.GlobalSearchDto;
	using BPMSoft.Configuration.GlobalSearchHelper;
	using BPMSoft.Core.DB;
	using Web.Common;
	using BPMSoft.GlobalSearch;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Monitoring;
	using BPMSoft.GlobalSearch.Monitoring;
	using BPMSoft.Web.Common.ServiceRouting;
	using BPMSoft.Web.Http.Abstractions;
	using ErrorInfo = BPMSoft.Core.ServiceModelContract.ErrorInfo;

	#region Class: GlobalSearchService

	/// <summary>
	/// Global search service proxy.
	/// </summary>
	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GlobalSearchService : BaseService, IReadOnlySessionState
	{

		#region Fields: Private

		private IMetricReporter _metricReporter = ClassFactory.Get<IMetricReporter>();
		private IRestClient _restClient;
		private GlobalSearchHelper _globalSearchHelper;
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");

		#endregion

		#region Properties: Private

		private GlobalSearchHelper SearchHelper {
			get {
				if (_globalSearchHelper == null) {
					_globalSearchHelper = ClassFactory.Get<GlobalSearchHelper>(new ConstructorArgument("userConnection",
						UserConnection));
				}
				return _globalSearchHelper;
			}
		}

		private string SearchServiceUrl {
			get {
				return (string)Core.Configuration.SysSettings.GetValue(UserConnection, "GlobalSearchUrl");
			}
		}

		private int RequestTimeout {
			get {
				return (int) Core.Configuration.SysSettings.GetValue(UserConnection, "DataServiceQueryTimeout");
			}
		}

		private IRestClient RestClient {
			get {
				if (_restClient == null && !ClassFactory.TryGet("GlobalSearchServiceRestClient", out _restClient)) {
					_restClient = new RestClient { Timeout = RequestTimeout };
				}
				return _restClient;
			}
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Global search connector helper instance <see cref="GlobalSearchConnectorHelper"/>.
		/// </summary>
		private GlobalSearchConnectorHelper _globalSearchConnectorHelper;
		protected virtual GlobalSearchConnectorHelper GlobalSearchConnectorHelper {
			get {
				return _globalSearchConnectorHelper ??
				       (_globalSearchConnectorHelper =
					       ClassFactory.Get<GlobalSearchConnectorHelper>(new ConstructorArgument("userConnection", UserConnection)));
			}
		}

		/// <summary>
		/// <see cref="BaseSearchSerializer"/> instance.
		/// </summary>
		private BaseSearchSerializer _jsonSerializer;
		protected BaseSearchSerializer JsonSerializer {
			get {
				return _jsonSerializer ?? (_jsonSerializer = new BaseSearchSerializer());
			}
		}

		/// <summary>
		/// Cancellation token instance <see cref="CancellationToken"/>.
		/// </summary>
		protected virtual CancellationToken CancellationToken {
			get {
				if (HttpContext.Current != null && HttpContext.Current.Response != null) {
					return HttpContext.Current.Response.ClientDisconnectedToken;
				}
				return CancellationToken.None;
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Filters passed types by access rights of current user.
		/// </summary>
		/// <param name="type">Comma-separated entity schema names.</param>
		/// <returns>Comma-separated entity schema names filtered by current user access rights.</returns>
		private string FilterTypeByAccessRights(string type) {
			var sections = type
				.Split(',')
				.Where(UserConnection.DBSecurityEngine.GetIsEntitySchemaReadingAllowed);
			return string.Join(",", sections);
		}

		private RestRequest PrepareRequest(ISearchRequestQuery searchRequestQuery, string type) {
			var typeString = string.IsNullOrEmpty(type) ?
				string.Empty :
				string.Format("/{0}", FilterTypeByAccessRights(type));
#if NETSTANDARD2_0
			RestClient.BaseUrl = new Uri(String.Format("{0}{1}/_search?search_type=dfs_query_then_fetch",
				SearchServiceUrl, typeString));
#else
			RestClient.BaseUrl = String.Format("{0}{1}/_search?search_type=dfs_query_then_fetch",
				SearchServiceUrl, typeString);
#endif
			var request = new RestRequest {
				Method = Method.GET,
				RequestFormat = DataFormat.Json,
				JsonSerializer = JsonSerializer
			};
#if NETFRAMEWORK
			request.AddBody(searchRequestQuery);
#else
			request.AddJsonBody(searchRequestQuery);
#endif
			GlobalSearchConnectorHelper.AppendCredentials(request);
			return request;
		}

		private BaseResponse GetErrorResponse(IRestResponse response, ErrorInfo errorInfo = null) {
			var info = errorInfo ?? new ErrorInfo {
				Message = response.ErrorMessage,
				ErrorCode = response.ResponseStatus.ToString()
			};
			BpmSearchResponse searchResponse = new BpmSearchResponse {
				Success = false,
				ErrorInfo = info
			};
			var responseJson = JsonConvert.SerializeObject(response);
			_log.Error(string.Format(@"ResponseStatus: {0}
						ErrorMessage: {1}
						Content: {2}, 
						Response: {3}", info.ErrorCode, info.Message, response.Content, responseJson));
			return searchResponse;
		}

		private void SetResponseNextFrom(BpmSearchResponse bpmSearchResponse, ESSearchResponse esSearchResponse,
			SearchRequestQuery searchRequestQuery) {
			var lastNeededHitId = bpmSearchResponse.Data.Last().Id;
			var lastIndexFromElasticResponce =
				esSearchResponse.SearchResult.Hits.ToList()
					.FindIndex(x => string.Equals(x.Id, lastNeededHitId, StringComparison.InvariantCultureIgnoreCase));
			bpmSearchResponse.NextFrom = searchRequestQuery.From + lastIndexFromElasticResponce + 1;
		}

		private bool GetNeedLoadRecords(int recordCount, BpmSearchResponse bpmSearchResponse) {
			int availableRecordCount = bpmSearchResponse == null ? 0 : bpmSearchResponse.Data.Count;
			return availableRecordCount < recordCount;
		}

		private bool HasAvailableElasticRecords(SearchRequestQuery searchRequestQuery, int totalFoundRecordCount) {
			return searchRequestQuery == null || searchRequestQuery.From + searchRequestQuery.Size < totalFoundRecordCount;
		}

		private bool GetNeedLoadNextPage(BpmSearchResponse bpmSearchResponse, SearchRequestQuery searchRequestQuery, int totalFoundRecordCount, int recordCount) {
			return GetNeedLoadRecords(recordCount, bpmSearchResponse) && HasAvailableElasticRecords(searchRequestQuery, totalFoundRecordCount);
		}

		private IRestResponse ExecutePostRequest(RestRequest request) {
			Task<IRestResponse> task = null;
			try {
				task = RestClient.ExecutePostTaskAsync(request, CancellationToken);
				task.Wait();
			} catch (Exception ex) {
				RestSharp.ResponseStatus status;
				if (ex is TimeoutException) {
					status = RestSharp.ResponseStatus.TimedOut;
					_metricReporter.Report(new ErrorMetric { SearchErrorCode = GlobalSearchErrorCode.Timeout });
				} else if (ex is OperationCanceledException || (task != null && task.IsCanceled)) {
					status = RestSharp.ResponseStatus.Aborted;
					_metricReporter.Report(new ErrorMetric { SearchErrorCode = GlobalSearchErrorCode.Aborted });
				} else {
					status = RestSharp.ResponseStatus.Error;
					_metricReporter.Report(new ErrorMetric { SearchErrorCode = GlobalSearchErrorCode.ElasticError });
				}
				RestResponse response = new RestResponse {
					ResponseStatus = status,
					ErrorMessage = ex.Message
				};
				return response;
			}
			return task.Result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Run global search.
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="sectionEntityName">Current section entity name.</param>
		/// <param name="recordCount">Count of selected records.</param>
		/// <param name="type">Type filter.</param>
		/// <param name="from">First record index for search.</param>
		/// <returns>Serializable <see cref="BpmSearchResponse"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public string Search(string queryString, string sectionEntityName, int recordCount, string type = "", int from = 0) {
			int pageNum = 0;
			int totalFoundRecordCount = -1;
			SearchRequestQuery searchRequestQuery = null;
			BpmSearchResponse bpmSearchResponse = null;
			while (GetNeedLoadNextPage(bpmSearchResponse, searchRequestQuery, totalFoundRecordCount, recordCount)) {
				searchRequestQuery = SearchHelper.GetSearchScoreRequestQuery(queryString, sectionEntityName, recordCount, pageNum, from);
				var request = PrepareRequest(searchRequestQuery, type);
				IRestResponse response = ExecutePostRequest(request);
				if (response.ResponseStatus != RestSharp.ResponseStatus.Completed) {
					var errorMessage = GetErrorResponse(response);
					return JsonSerializer.Serialize(errorMessage);
				}
				var esSearchResponse = JsonConvert.DeserializeObject<ESSearchResponse>(response.Content);
				if (esSearchResponse.SearchResult == null) {
					_metricReporter.Report(new ErrorMetric { SearchErrorCode = GlobalSearchErrorCode.ElasticError });
					return JsonSerializer.Serialize(GetErrorResponse(response, new ErrorInfo {
						Message = "Search result is empty",
						ErrorCode = "EmptyResult"
					}));
				}
				_metricReporter.Report(new SearchMetric { Duration = esSearchResponse.Took });
				var processedEsResponse = SearchHelper.ProcessEsSearchResponse(esSearchResponse);
				totalFoundRecordCount = processedEsResponse.Total;
				if (bpmSearchResponse == null) {
					bpmSearchResponse = processedEsResponse;
				} else {
					bpmSearchResponse.Data.AddRange(processedEsResponse.Data);
				}
				if (bpmSearchResponse.Data.Count >= recordCount) {
					bpmSearchResponse.Data = bpmSearchResponse.Data.Take(recordCount).ToList();
					SetResponseNextFrom(bpmSearchResponse, esSearchResponse, searchRequestQuery);
				}
				pageNum++;
			}
			return JsonSerializer.Serialize(bpmSearchResponse);
		}

		/// <summary>
		/// Get aggregations by query
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="sectionEntityName">Current section entity name.</param>
		/// <returns>Serializable list of <see cref="BpmSearchAggregation"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "sections")]
		public string GetGroupedSections(string queryString, string sectionEntityName) {
			var aggsSearchRequestQuery = SearchHelper.GetAggsSearchScoreRequestQuery(queryString, sectionEntityName);
			var request = PrepareRequest(aggsSearchRequestQuery, "");
			IRestResponse response = ExecutePostRequest(request);
			if (response.ResponseStatus != RestSharp.ResponseStatus.Completed) {
				return JsonSerializer.Serialize(GetErrorResponse(response));
			}
			var esAggsSearchResponse = JsonConvert.DeserializeObject<ESAggregationResponse>(response.Content);
			List<BpmSearchAggregation> groups = SearchHelper.ProcessEsAggregationResponse(esAggsSearchResponse);
			return JsonSerializer.Serialize(groups);
		}

		#endregion

	}

	#endregion

}

