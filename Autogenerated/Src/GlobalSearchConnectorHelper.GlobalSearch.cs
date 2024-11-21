namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Text;
	using System.Text.RegularExpressions;
	using RestSharp;
	using BPMSoft.Core;

	#region Class: GlobalSearchConnectorHelper

	public class GlobalSearchConnectorHelper
	{
		#region Constants: Private

		/// <summary>
		/// Pattern for parsing connection string with wanted values.
		/// </summary>
		private const string ValuePattern = "^.*{0}=([^;]+).*$";
		
		/// <summary>
		/// Delimiter pattern of the connection string.
		/// </summary>
		private const string DelimiterPattern = "(;)";

		/// <summary>
		/// Key pattern of the connection string.
		/// </summary>
		private const string KeyPattern = "([a-z]+)=[^;]+;?";

		/// <summary>
		/// Spaces pattern of the connection string.
		/// </summary>
		private const string SpacesPattern = "\\s+";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		/// <summary>
		/// Parsed settings of the elasticsearch connection string.
		/// </summary>
		private readonly Dictionary<string, string> _elasticSearchSettings;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// <see cref="GlobalSearchConnectorHelper"/> constructor.
		/// </summary>
		/// <param name="userConnection">Configuration object of current user application session.</param>
		public GlobalSearchConnectorHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_elasticSearchSettings = GetElasticSearchSettings();
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// Authorisation header credentials
		/// </summary>
		private string AuthorizationHeaderCredentials {
			get {
				string user = GetElasticSearchSetting("user");
				string password = GetElasticSearchSetting("password");
				string credentionals = string.Format("{0}:{1}", user, password);
				string base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentionals));
				return string.Format("Basic {0}", base64Credentials);
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ElasticSearch index path url.
		/// </summary>
		public string ElasticSearchIndexPath {
			get {
				string url = GetElasticSearchSetting("url");
				string port = GetElasticSearchSetting("port");
				string index = GetElasticSearchSetting("index");
				return string.Format("{0}:{1}/{2}", url, port, index);
			}
		}

		/// <summary>
		/// ElasticSearch index search path url.
		/// </summary>
		public string ElasticSearchIndexSearchPath {
			get {
				return string.Format("{0}/{1}", ElasticSearchIndexPath, "/_search");
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Get value by parsing connection string.
		/// </summary>
		/// <param name="valueName">Value name for parser.</param>
		/// <param name="connectionString">Connection string.</param>
		/// <returns>Wanted value.</returns>
		private string GetValueFromConnectionString(string valueName, string connectionString) {
			string pattern = string.Format(ValuePattern, valueName);
			Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
			return rgx.Replace(connectionString, "$1").Trim();
		}

		/// <summary>
		/// Get keys of the connection string.
		/// </summary>
		/// <param name="connectionString">Connection string.</param>
		/// <returns>Splited keys of the connection string.</returns>
		private string[] GetConnectionStringKeys(string connectionString) {
			Regex delimiterPattern = new Regex(DelimiterPattern);
			Regex keyPattern = new Regex(KeyPattern);
			Regex spacesPattern = new Regex(SpacesPattern);
			connectionString = delimiterPattern.Replace(connectionString, "$1 ");
			connectionString = keyPattern.Replace(connectionString, "$1");
			connectionString = spacesPattern.Replace(connectionString, " ");
			connectionString = connectionString.Trim();
			connectionString = connectionString.ToLower();
			return spacesPattern.Split(connectionString);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Get elasticSearch credentials string.
		/// </summary>
		/// <returns>ElasticSearch credentials string.</returns>
		protected virtual string GetElasticSearchCredentials() {
			return _userConnection.AppConnection.ElasticSearchCredentials;
		}

		/// <summary>
		/// Get parsed connection string settings.
		/// </summary>
		/// <param name="connectionString">Connection string.</param>
		/// <returns>Parsed connection string settings</returns>
		protected Dictionary<string, string> GetParsedConnectionStringSettings(string connectionString) {
			string[] connectionStringKeys = GetConnectionStringKeys(connectionString);
			Dictionary<string, string> connectionStringSettings = new Dictionary<string, string>();
			foreach (var key in connectionStringKeys) {
				string value = GetValueFromConnectionString(key, connectionString);
				connectionStringSettings.Add(key, value);
			}
			return connectionStringSettings;
		}

		/// <summary>
		/// Get parsed elasticSearch connection string settings.
		/// </summary>
		/// <returns>Parsed elasticSearch connection string settings</returns>
		protected Dictionary<string, string> GetElasticSearchSettings() {
			var elasticsearchCredentials = GetElasticSearchCredentials();
			return GetParsedConnectionStringSettings(elasticsearchCredentials);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get elasticSearch setting value.
		/// </summary>
		/// <param name="key">Search key.</param>
		/// <returns>ElasticSearch setting value.</returns>
		public string GetElasticSearchSetting(string key) {
			if (_elasticSearchSettings.ContainsKey(key)) {
				return _elasticSearchSettings[key];
			}
			return null;
		}

		/// <summary>
		/// Append credentials to http request.
		/// </summary>
		/// <param name="request">Http Request.</param>
		public void AppendCredentials(HttpWebRequest request) {
			request.Headers.Add("Authorization", AuthorizationHeaderCredentials);
		}

		/// <summary>
		/// Append credentials to Rest request.
		/// </summary>
		/// <param name="request">Rest request.</param>
		public void AppendCredentials(RestRequest request) {
			request.AddHeader("Authorization", AuthorizationHeaderCredentials);
		}

		#endregion
	}

	#endregion
}
