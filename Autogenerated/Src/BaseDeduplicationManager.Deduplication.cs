namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Text.RegularExpressions;
	using global::Common.Logging;
	using RestSharp;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Factories;

	#region Class: BaseDeduplicationManager

	public class BaseDeduplicationManager
	{

		#region Fields: Protected

		protected readonly string DeduplicationTaskControllerPath = "api/deduplication/task/";
		protected readonly string DuplicationControllerPath = "api/duplication/duplicate";
		protected readonly string DuplicationGroupControllerPath = "api/duplication/group";
		protected readonly string DuplicatesCountControllerPath = "api/duplicates/groups/count";
		protected readonly string UniqueControllerPath = "api/duplication/unique";
		protected static readonly ILog Log = LogManager.GetLogger("Deduplication");
		protected readonly string DeduplicationWebApiUrl = string.Empty;
		protected readonly string GlobalSearchUrl = string.Empty;
		protected UserConnection UserConnection;

		#endregion

		#region Properties: Protected

		private string _indexName;
		protected string IndexName {
			get {
				if(_indexName != null) {
					return _indexName;
				}
				if(string.IsNullOrEmpty(GlobalSearchUrl)) {
					Log.Error("GlobalSearchUrl is empty.");
					_indexName = string.Empty;
					return _indexName;
				}
				_indexName = new Regex("^(.*)/([^/]+)$").Replace(GlobalSearchUrl, "$2");
				return _indexName;
			}
		}

		private IRestClient _restClient;
		protected IRestClient RestClient {
			get {
				if(_restClient != null) {
					return _restClient;
				}
				var tag = DeduplicationEventListener.BulkDeduplicationRestClientTag;
				if(!ClassFactory.TryGet(tag, out _restClient)) {
					throw new ArgumentNullException($"Deduplication rest client - {tag} not resolved.");
				}
				string url = DeduplicationWebApiUrl.TrimEnd('/');
#if NETSTANDARD2_0
				RestClient.BaseUrl = new Uri(url);
#else
				RestClient.BaseUrl = url;
#endif
				
				return _restClient;
			}
		}

		#endregion

		#region Contructors: Public

		public BaseDeduplicationManager(UserConnection userConnection) {
			UserConnection = userConnection;
			DeduplicationWebApiUrl = SysSettings.GetValue(UserConnection, "DeduplicationWebApiUrl", string.Empty);
			if(string.IsNullOrEmpty(DeduplicationWebApiUrl)) {
				Log.Error("DeduplicationWebApiUrl is empty.");
			}
			GlobalSearchUrl = SysSettings.GetValue(UserConnection, "GlobalSearchUrl", string.Empty);
		}

		#endregion

	}

	#endregion

}
