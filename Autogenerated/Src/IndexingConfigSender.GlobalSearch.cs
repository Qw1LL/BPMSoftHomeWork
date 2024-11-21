namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using RestSharp;
	using BPMSoft.Core;
	using SysSettingsCore = BPMSoft.Core.Configuration.SysSettings;
	using BPMSoft.Core.Factories;

	#region Class: IndexingConfigSender

	/// <summary>
	/// Sends indexed entities to the indexing service.
	/// </summary>
	public class IndexingConfigSender
	{

		#region Constants: Private

		/// <summary>
		/// Elastic delimiter pattern.
		/// </summary>
		private static readonly Regex _elasticDelimiterPattern = new Regex("(.*)/([^/]+)$");

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		/// <summary>
		/// Log manager.
		/// </summary>
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");

		#endregion

		#region Properties: Protected

		/// <summary>
		/// ElasticSearch host address.
		/// </summary>
		protected string ElasticHost {
			get {
				return _elasticDelimiterPattern.Replace(ElasticUrl, "$1");
			}
		}

		/// <summary>
		/// ElasticSearch index name.
		/// </summary>
		protected string ElasticIndex {
			get {
				return _elasticDelimiterPattern.Replace(ElasticUrl, "$2");
			}
		}

		/// <summary>
		/// ElasticSearch full url address.
		/// </summary>
		protected string _elasticUrl;
		protected virtual string ElasticUrl {
			get {
				return _elasticUrl ?? SysSettingsCore.GetValue(_userConnection, "GlobalSearchUrl", string.Empty);
			}
		}

		/// <summary>
		/// Global search config service url adress.
		/// </summary>
		protected string _globalSearchServiceUrl;
		protected virtual string GlobalSearchServiceUrl {
			get {
				return _globalSearchServiceUrl ?? (_globalSearchServiceUrl = SysSettingsCore.GetValue(_userConnection, "GlobalSearchConfigServiceUrl", string.Empty));
			}
		}

		/// <summary>
		/// Indexing entity list manager.
		/// </summary>
		protected IndexingEntityListManager _indexingEntityListManager;
		protected virtual IndexingEntityListManager IndexingEntityListManager {
			get {
				if (_indexingEntityListManager == null) {
					_indexingEntityListManager = ClassFactory.Get<IndexingEntityListManager>(new ConstructorArgument("userConnection", _userConnection));
				}
				return _indexingEntityListManager;
			}
		}

		/// <summary>
		/// Implemented instance of <see cref="IRestClient"/>.
		/// </summary>
		private IRestClient _restClient;
		public virtual IRestClient RestClient {
			get {
				return _restClient ?? (_restClient = new RestClient());
			}
		}

		#endregion
		
		#region Constructors: Public

		/// <summary>Initializes a new instance of the <see cref="UserConnection" /> class.</summary>
		public IndexingConfigSender(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private void SaveConfigsCallback(IRestResponse restResponse) {
			if (restResponse.StatusCode != System.Net.HttpStatusCode.OK) {
				_log.Error(restResponse.ErrorMessage);
			} else {
				_log.Info(string.Format("Sending indexings configs finished with " +
						"ResponseStatus: {0}, StatusCode: {1}, Content: {2}",
						restResponse.ResponseStatus, restResponse.StatusCode, restResponse.Content));
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sends indexation configs to indexing service.
		/// </summary>
		public void Send() {
			if (string.IsNullOrEmpty(GlobalSearchServiceUrl) && string.IsNullOrEmpty(ElasticUrl)) {
				_log.Info("GlobalSearch connection settings are empty.");
				return;
			}
			List<IndexingEntity> indexingEntityList = IndexingEntityListManager.GetIndexingEntities();
#if NETSTANDARD2_0
			RestClient.BaseUrl = new Uri($"{GlobalSearchServiceUrl.TrimEnd('/')}/saveConfigs");
#else
			RestClient.BaseUrl = new Uri($"{GlobalSearchServiceUrl.TrimEnd('/')}/saveConfigs").ToString();
#endif
			RestRequest request = new RestRequest {
				Method = Method.POST
			};
			request.AddParameter("IndexationConfigs", JsonConvert.SerializeObject(indexingEntityList));
			request.AddParameter("IndexName", ElasticIndex);
			_log.Info("Sending indexings configs started.");
			RestClient.ExecuteAsync(request, resp => SaveConfigsCallback(resp));
		}

		#endregion
	}
	
	#endregion
}

