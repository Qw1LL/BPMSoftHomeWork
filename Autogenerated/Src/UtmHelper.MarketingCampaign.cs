namespace BPMSoft.Configuration.MandrillService
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;

	#region Class: UtmData

	public class UtmData
	{
		public bool UseUtm { get; set; }
		public string Domains { get; set; }
		public string UtmSource { get; set; }
		public string UtmMedium { get; set; }
		public string UtmCampaign { get; set; }
		public string UtmTerm { get; set; }
		public string UtmContent { get; set; }
		public string TemplateCode { get; set; }
	}

	public static class ConvertedUtmData
	{
		public static UtmData ConvertToUtmData(this BulkEmail bulkEmail, string templateCode) {
			return new UtmData {
				UseUtm = bulkEmail.UseUtm,
				Domains = bulkEmail.Domains,
				UtmSource = bulkEmail.UtmSource,
				UtmMedium = bulkEmail.UtmMedium,
				UtmCampaign = bulkEmail.UtmCampaign,
				UtmTerm = bulkEmail.UtmTerm,
				UtmContent = bulkEmail.UtmContent,
				TemplateCode = templateCode
			};
		}
	}

	#endregion

	#region Class: UtmHelper

	/// <summary>
	/// Class for work with Utm tags.
	/// </summary>
	public class UtmHelper
	{

		#region Constants: Private

		const string PatternLink = "(<a[^>]*?[^-]href\\s*=[\"\'])(?<link>[^\"\']+)([\"\'])([^>]+)?>";

		const string PatternPartamInLink =
			"(?<start><a[^>]*?\\s*href\\s*=[\"\'][^\"\'\\?#]+)(?<query_string>\\?[^\"\'#]+)?(?<fragment_id>#[^\"\']+)?(?<end>[^>]+>)";

		const string PatternDomain =
			"([^:]+://)?(?<domain>[a-zA-Z0-9][a-zA-Z0-9-_]{1,61}[a-zA-Z0-9-_.]{0,})(/)?";

		const string PatternUtmLabel = "[?&](utm_source|utm_campaign|utm_medium|utm_term|utm_content)=";

		#endregion

		#region Constants: Public

		public const string PatternUtmEmailIdLabel = "bulk_email_rid=";

		#endregion

		#region Methods: Private

		/// <summary>
		/// Creates domain list.
		/// </summary>
		/// <param name="domains">String with domains(delimited with ',' or ';')</param>
		/// <returns>List of domains</returns>
		protected static List<string> GetDomainList(string domains) {
			var pattern = string.Format("^{0}$", PatternDomain);
			var result = (from domain in domains.Split(new[] { ',', ';' })
						  select Regex.Matches(domain.Trim(), pattern, RegexOptions.IgnoreCase)
							  into matchDomain
						  where matchDomain.Count == 1
						  select matchDomain[0].Groups["domain"].Value).ToList();
			return result;
		}

		/// <summary>
		/// Returns paramater string for url with utm-tags.
		/// </summary>
		/// <param name="data">Data with utm tags</param>
		/// <returns>String with parameters for url</returns>
		protected static string GetUtmParamString(UtmData data) {
			string utmParam = string.Format("utm_source={0}&utm_medium={1}&utm_campaign={2}",
				data.UtmSource,
				data.UtmMedium,
				data.UtmCampaign);
			if(!string.IsNullOrEmpty(data.UtmTerm)) {
				utmParam += "&utm_term=" + data.UtmTerm;
			}
			if(!string.IsNullOrEmpty(data.UtmContent)) {
				utmParam += "&utm_content=" + data.UtmContent;
			}
			return utmParam;
		}

		/// <summary>
		/// Returns paramater string for url with obligatory utm tags.
		/// </summary>
		/// <param name="bulkEmailRId">BulkEmail RId</param>
		/// <returns>String with parameters for url</returns>
		protected static string GetBulkEmailRIdParamString(int bulkEmailRId) {
			string utmParam = PatternUtmEmailIdLabel + bulkEmailRId.ToString();
			return utmParam;
		}

		/// <summary>
		/// ############ ###### ###### # ####### ##### ######## utm-#####.
		/// </summary>
		/// <param name="domains">###### #######</param>
		/// <param name="templateCode">###### ########</param>
		/// <param name="utmParam">######-########## # utm-#######</param>
		/// <param name="unsubscribeMacrosAliases">######### ####### ######## #######</summary></param>
		/// <returns>###### ###### # ####### ##### ######## utm-#####</returns>
		protected static Dictionary<string, string> GetLinksForReplace(List<string> domains, string templateCode, bool useUtm, string utmParam,
				string requiredUtmParam, IEnumerable<string> unsubscribeMacrosAliases) {
			var hyperlinks = new Dictionary<string, string>();
			foreach(Match matchLink in Regex.Matches(templateCode, PatternLink, RegexOptions.IgnoreCase)) {
				var link = matchLink.Groups["link"].Value;
				// ########## ######, # ####### #### #### ## utm-#####
				bool isUtmExist = Regex.Matches(link, PatternUtmLabel, RegexOptions.IgnoreCase).Count > 0 || !useUtm;
				bool isBulkEmailIdExist = Regex.Matches(link, PatternUtmEmailIdLabel, RegexOptions.IgnoreCase).Count > 0 || string.IsNullOrEmpty(requiredUtmParam);
				bool isUnsubscribeAlias = link.Contains("*|UNSUB:");
				foreach(string alias in unsubscribeMacrosAliases) {
					if(link.Contains(alias)) {
						isUnsubscribeAlias = true;
						break;
					}
				}
				if(isUnsubscribeAlias || (isUtmExist && isBulkEmailIdExist)) {
					continue;
				}

				// ######## ###### # ######
				bool domainMatched = true;
				var matchDomain = Regex.Matches(link, PatternDomain, RegexOptions.IgnoreCase);
				if((matchDomain.Count == 0) ||
					(!domains.Any(domain => matchDomain[0].Groups["domain"].Value.Equals(domain, StringComparison.OrdinalIgnoreCase)))) {
					domainMatched = false;
				}

				// ########## ######, #### ### ### ######### # ###### ### ######
				if(hyperlinks.ContainsKey(matchLink.ToString())) {
					continue;
				}

				var matchLinkDetails = Regex.Matches(matchLink.ToString(), PatternPartamInLink, RegexOptions.IgnoreCase);
				if(matchLinkDetails.Count == 1) {
					// ############ ###### ##########
					string queryString = matchLinkDetails[0].Groups["query_string"].Value;
					if(!isBulkEmailIdExist) {
						InsertQueryString(ref queryString, requiredUtmParam);
					}
					if(!isUtmExist && domainMatched) {
						InsertQueryString(ref queryString, utmParam);
					}
					// ############ ##### ###### # ###### utm-#######
					string resultLink = string.Format("{0}?{1}{2}{3}",
						matchLinkDetails[0].Groups["start"].Value,
						queryString,
						matchLinkDetails[0].Groups["fragment_id"].Value,
						matchLinkDetails[0].Groups["end"].Value);
					hyperlinks.Add(matchLink.ToString(), resultLink);
				}
			}
			return hyperlinks;
		}

		/// <summary>
		/// ######### ####### Utm-##### # ###### ########## URL.
		/// </summary>
		/// <param name="queryString">###### ########## URL</param>
		/// <param name="utmParam">######## utm-#####</param>
		/// <param name="doNotIsert">#### ########### ######### ## #######</param>
		/// <returns>###### ######## # utm-#######</returns>
		protected static void InsertQueryString(ref string queryString, string utmParam) {
			if(!string.IsNullOrEmpty(queryString)) {
				queryString = string.Format("{0}&{1}",
					utmParam,
					queryString.StartsWith("?") ? queryString.Substring(1, queryString.Length - 1) : queryString);
			} else {
				queryString = utmParam;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Appends utm parameters to the email template.
		/// </summary>
		/// <param name="data">Source data of utm parameters.</param>
		/// <param name="bulkEmailRId">RId of the BulkEmail</param>
		/// <param name="unsubscribeMacrosAliases">Collection of the aliases of unsubscribe macros.</param>
		/// <returns>Email template with utm parameters.</returns>
		public static string GetTemplateCodeWithUtmLabel(UtmData data, int bulkEmailRId,
				IEnumerable<string> unsubscribeMacrosAliases) {
			string resultTemplateCode = data.TemplateCode;
			List<string> domains = GetDomainList(data.Domains);
			string utmParam = GetUtmParamString(data);
			string requiredUtmParam = GetBulkEmailRIdParamString(bulkEmailRId);
			Dictionary<string, string> hyperlinks = GetLinksForReplace(domains, data.TemplateCode, data.UseUtm,
				utmParam, requiredUtmParam, unsubscribeMacrosAliases);
			return hyperlinks.Aggregate(resultTemplateCode,
				(current, hyperlink) => current.Replace(hyperlink.Key, hyperlink.Value));
		}


		/// <summary>
		/// Removes utm parameters from url.
		/// </summary>
		/// <param name="url">Url.</param>
		/// <returns>Url.</returns>
		public static string RemoveUtmFromUri(string url) {
			Uri uri;
			if(!Uri.TryCreate(url, UriKind.Absolute, out uri)) {
				return url;
			}
			string query = uri.Query;
			if(String.IsNullOrEmpty(query)) {
				return url;
			}
			char splitter = '&';
			string querySign = query.Substring(0, 1);
			string[] queryParameters =
				query.Substring(1).Split(new char[] { splitter }, StringSplitOptions.RemoveEmptyEntries);
			string processedQuery = string.Empty;
			foreach(string queryParameter in queryParameters) {
				if(queryParameter.StartsWith(PatternUtmEmailIdLabel) || queryParameter.StartsWith("utm_source=") ||
						queryParameter.StartsWith("utm_campaign=") || queryParameter.StartsWith("utm_term=") ||
						queryParameter.StartsWith("utm_content=") || queryParameter.StartsWith("utm_medium=")) {
					continue;
				}
				if(!String.IsNullOrEmpty(processedQuery)) {
					processedQuery += splitter;
				}
				processedQuery += queryParameter;
			}
			if(!String.IsNullOrEmpty(processedQuery)) {
				processedQuery = querySign + processedQuery;
			}
			return uri.OriginalString.Replace(query, processedQuery);
		}

		#endregion

	}

	#endregion
}

