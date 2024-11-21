namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Core.Entities;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: BulkEmailUtmData

	public class BulkEmailUtmData {
		public bool UseUtm { get; set; }
		public string Domains { get; set; }
		public string UtmSource { get; set; }
		public string UtmMedium { get; set; }
		public string UtmCampaign { get; set; }
		public string UtmTerm { get; set; }
		public string UtmContent { get; set; }
		public string TemplateCode { get; set; }
	}

	#endregion

	#region Class: BulkEmailUtmHelper

	/// <summary>
	/// Class for work with Utm tags.
	/// </summary>
	public class BulkEmailUtmHelper {

		#region Constants: Private

		private const string PatternLink = "(<a[^>]*?[^-]href\\s*=[\"\'])(?<link>[^\"\']+)([\"\'])([^>]+)?>";

		private const string PatternPartamInLink =
			"(?<start><a[^>]*?\\s*href\\s*=[\"\'][^\"\'\\?#]+)(?<query_string>\\?[^\"\'#]+)?(?<fragment_id>#[^\"\']+)?(?<end>[^>]+>)";

		private const string ValidUrl = "[-a-z\\u0430-\\u044fA-Z\\u0410-\\u042f0-9@:%._\\+~#=]{2,256}\\.[a-z\\u0430-\\u044f]{2,6}\\b([-a-z\\u0430-\\u044fA-Z\\u0410-\\u042f0-9@:%_\\+.~#?&//=]*)";
		
		private const string PatternDomain =
			"([^:]+://)?(?<domain>[a-z\\u0430-\\u044fA-Z\\u0410-\\u042f0-9][a-z\\u0430-\\u044fA-Z\\u0410-\\u042f0-9-_]{1,61}[a-z\\u0430-\\u044fA-Z\\u0410-\\u042f0-9-_.]{0,})(/)?";

		private const string PatternUtmLabel = "[?&](utm_source|utm_campaign|utm_medium|utm_term|utm_content)=";

		private const string EmailRIdParameterName = "bulk_email_rid";

		#endregion

		#region Constants: Public

		public const string PatternUtmEmailIdLabel = "bulk_email_rid=";

		#endregion

		#region Methods: Private

		private static bool IsWellFormedUriString(string link) {
			var testLink = link.IndexOf('?') == -1 ? link : link.Substring(0, link.IndexOf('?'));
			var matchDomain = Regex.Matches(testLink, ValidUrl, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
			return matchDomain.Count > 0;
		}
		
		#endregion

		#region Methods: Protected

		/// <summary>
		/// Creates domain list.
		/// </summary>
		/// <param name="domains">String with domains(delimited with ',' or ';').</param>
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
		protected static string GetUtmParamString(BulkEmailUtmData data) {
			string utmParam = string.Format("utm_source={0}&utm_medium={1}&utm_campaign={2}",
				data.UtmSource,
				data.UtmMedium,
				data.UtmCampaign);
			if (!string.IsNullOrEmpty(data.UtmTerm)) {
				utmParam += "&utm_term=" + data.UtmTerm;
			}
			if (!string.IsNullOrEmpty(data.UtmContent)) {
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
		/// Forming a list of links in which you need to insert utm-tags.
		/// </summary>
		/// <param name="domains">The list of domains.</param>
		/// <param name="templateCode">The email template.</param>
		/// <param name="utmParam">Parameter string with utm-labels.</param>
		/// <param name="unsubscribeMacrosAliases">The collection of aliases of the unsubscription macros.</param>
		/// <returns>List of references in which you need to insert utm-tags.</returns>
		protected static Dictionary<string, string> GetLinksForReplace(List<string> domains, string templateCode,
				bool useUtm, string utmParam, string requiredUtmParam, IEnumerable<string> unsubscribeMacrosAliases) {
			var hyperlinks = new Dictionary<string, string>();
			foreach (Match matchLink in Regex.Matches(templateCode, PatternLink, RegexOptions.IgnoreCase)) {
				var link = matchLink.Groups["link"].Value;
				string decodedLink = HttpUtility.UrlDecode(link);
				// Exclude references in which there is one of the utm-labels
				bool isUtmExist = Regex.Matches(decodedLink, PatternUtmLabel, RegexOptions.IgnoreCase)
					.Count > 0 || !useUtm;
				bool isBulkEmailIdExist = Regex.Matches(decodedLink, PatternUtmEmailIdLabel, RegexOptions.IgnoreCase)
				.Count > 0 || string.IsNullOrEmpty(requiredUtmParam);
				bool isValidUrl = IsWellFormedUriString(link);
				bool isUnsubscribeAlias = link.Contains("*|UNSUB");
				foreach (string alias in unsubscribeMacrosAliases) {
					if (link.Contains(alias)) {
						isUnsubscribeAlias = true;
						break;
					}
				}
				if (isUnsubscribeAlias || (isUtmExist && isBulkEmailIdExist) || !isValidUrl) {
					continue;
				}
				// Checking domain in link
				bool domainMatched = true;
				var matchDomain = Regex.Matches(link, PatternDomain, RegexOptions.IgnoreCase);
				if ((matchDomain.Count == 0) ||
					(!domains.Any(domain => matchDomain[0].Groups["domain"].Value.Equals(domain, StringComparison.OrdinalIgnoreCase)))) {
					domainMatched = false;
				}
				// Exclude a link if it is already added to the list for replacement
				if (hyperlinks.ContainsKey(matchLink.ToString())) {
					continue;
				}

				var matchLinkDetails = Regex.Matches(matchLink.ToString(), PatternPartamInLink, RegexOptions.IgnoreCase);
				if (matchLinkDetails.Count == 1) {
					// Creates a query string
					string queryString = matchLinkDetails[0].Groups["query_string"].Value;
					if (!isBulkEmailIdExist) {
						InsertQueryString(ref queryString, requiredUtmParam);
					}
					if (!isUtmExist && domainMatched) {
						InsertQueryString(ref queryString, utmParam);
					}
					// Creates new link with utm-labels
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
		/// Inserts the Utm labels into the URL parameter string.
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="utmParam">Parameter string with utm-labels.</param>
		/// <returns>Email template with utm-labels.</returns>
		protected static void InsertQueryString(ref string queryString, string utmParam) {
			if (!string.IsNullOrEmpty(queryString)) {
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
		public static string GetTemplateCodeWithUtmLabel(BulkEmailUtmData data, int bulkEmailRId,
				IEnumerable<string> unsubscribeMacrosAliases = null) {
			string resultTemplateCode = data.TemplateCode;
			List<string> domains = GetDomainList(data.Domains);
			string utmParam = GetUtmParamString(data);
			string requiredUtmParam = GetBulkEmailRIdParamString(bulkEmailRId);
			if (unsubscribeMacrosAliases == null) {
				unsubscribeMacrosAliases = new string[0];
			}
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
			return BulkEmailUriHelper.RemoveParametersFromUri(url, EmailRIdParameterName, "utm_source", 
				"utm_campaign", "utm_term", "utm_content", "utm_medium");
		}

		/// <summary>
		/// Converts entity to utm data.
		/// </summary>
		/// <param name="entity">Entity object.</param>
		/// <param name="templateCode">Template code.</param>
		/// <returns>Utm data.</returns>
		public static BulkEmailUtmData ConvertToUtmData(Entity entity, string templateCode) {
			return new BulkEmailUtmData {
				UseUtm =  entity.GetTypedColumnValue<bool>("UseUtm"),
				Domains = entity.GetTypedColumnValue<string>("Domains"),
				UtmSource = entity.GetTypedColumnValue<string>("UtmSource"),
				UtmMedium = entity.GetTypedColumnValue<string>("UtmMedium"),
				UtmCampaign = entity.GetTypedColumnValue<string>("UtmCampaign"),
				UtmTerm = entity.GetTypedColumnValue<string>("UtmTerm"),
				UtmContent = entity.GetTypedColumnValue<string>("UtmContent"),
				TemplateCode = templateCode
			};
		}

		#endregion

	}

	#endregion
}
