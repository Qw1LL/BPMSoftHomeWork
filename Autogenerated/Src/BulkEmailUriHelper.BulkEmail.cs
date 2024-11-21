namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Linq;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: BulkEmailUriHelper

	/// <summary>
	/// Helper class for work with Uri.
	/// </summary>
	public static class BulkEmailUriHelper
	{

		#region Methods: Private

		private static NameValueCollection ParseQueryParameters(Uri uri) {
			return HttpUtility.ParseQueryString(uri.Query);
		}

		private static string QueryParametersToQueryString(Uri uri, NameValueCollection queryParameters) {
			var uriBuilder = new UriBuilder(uri);
			uriBuilder.Query = queryParameters.ToString();
			return uriBuilder.Query + uriBuilder.Fragment;
		}

		private static string BuildUriString(Uri uri, NameValueCollection queryParameters) {
			string processedQuery = QueryParametersToQueryString(uri, queryParameters);
			string originalQuery = HttpUtility.UrlDecode(uri.Query + uri.Fragment);
			string originalUri = HttpUtility.UrlDecode(uri.OriginalString);
			if (!string.IsNullOrEmpty(originalQuery)) {
				originalUri = originalUri.Replace(originalQuery, string.Empty);
			}
			return originalUri + Uri.UnescapeDataString(processedQuery);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Removes parameters from the uri.
		/// </summary>
		/// <param name="sourceUri">Uri.</param>
		/// <param name="parameters">Parameters to remove.</param>
		/// <returns>Uri.</returns>
		public static string RemoveParametersFromUri(string sourceUri, params string[] parameters) {
			Uri uri;
			if (!Uri.TryCreate(sourceUri.ToLower(), UriKind.Absolute, out uri)) {
				return sourceUri;
			}
			NameValueCollection queryParameters = ParseQueryParameters(uri);
			if (!queryParameters.HasKeys()) {
				return sourceUri;
			}
			foreach (string parameter in parameters) {
				queryParameters.Remove(parameter.ToLower());
			}
			return BuildUriString(uri, queryParameters);
		}

		/// <summary>
		/// Get parameters from uri.
		/// </summary>
		/// <param name="sourceUri">Uri.</param>
		/// <param name="keys">Parameters to remove.</param>
		/// <returns>Returns Uri parameters by keys. If keys array is empty - returns empty collection.</returns>
		public static Dictionary<string, string> GetParametersFromUri(string sourceUri, params string[] keys) {
			Uri uri;
			var resultCollection = new Dictionary<string, string>();
			if (!Uri.TryCreate(sourceUri.ToLower(), UriKind.Absolute, out uri)) {
				return resultCollection;
			}
			NameValueCollection queryParameters = ParseQueryParameters(uri);
			if (queryParameters.HasKeys()) {
				foreach (var key in keys) {
					var values = queryParameters.GetValues(key.ToLower());
					if (values?.Length > 0) {
						resultCollection.Add(key, values[0]);
					}
				}
			}
			return resultCollection;
		}

		/// <summary>
		/// Adds parameters to the uri.
		/// </summary>
		/// <param name="sourceUri">Uri.</param>
		/// <param name="parameters">Parameters to add.</param>
		/// <returns>Uri.</returns>
		public static string AddParametersToUri(string sourceUri, Dictionary<string, string> parameters) {
			if (parameters == null) {
				return sourceUri;
			}
			Uri uri;
			if (!Uri.TryCreate(sourceUri, UriKind.Absolute, out uri)) {
				return sourceUri;
			}
			NameValueCollection queryParameters = ParseQueryParameters(uri);
			foreach (KeyValuePair<string, string> parameter in parameters) {
				string parameterName = parameter.Key;
				string parameterValue = parameter.Value;
				if (!queryParameters.AllKeys.Any(_ => !string.IsNullOrEmpty(_) &&
						_.Equals(parameterName, StringComparison.OrdinalIgnoreCase))) {
					queryParameters.Add(parameterName, parameterValue);
				}
			}
			return BuildUriString(uri, queryParameters);
		}

		#endregion

	}

	#endregion

}

