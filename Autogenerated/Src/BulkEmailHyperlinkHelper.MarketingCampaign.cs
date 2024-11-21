namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Configuration.MandrillService;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using HttpUtility = System.Web.HttpUtility;

	#region class: BulkEmailHyperlinkHelper

	public class BulkEmailHyperlinkHelper
	{

		#region Constants: Private

		/// <summary>
		/// Contact identifier parameter name.
		/// </summary>
		private const string ContactIdParameterName = "contactId";

		/// <summary>
		/// Bulk email recipient identifier parameter name.
		/// </summary>
		private const string BulkEmailRecipientIdParameterName = "bulkEmailRecipientId";

		#endregion

		#region Constants: Public

		/// <summary>
		/// Contact identifier macros.
		/// </summary>
		public const string ContactIdMacrosName = "CONTACT_ID";

		/// <summary>
		/// Bulk email recipient identifier macros.
		/// </summary>
		public const string BulkEmailRecipientIdName = "RECIPIENT_ID";

		#endregion

		#region Methods: Private

		private static void ClearBulkEmailHyperlinks(Guid bulkEmailId, UserConnection userConnection) {
			var delete = new Delete(userConnection)
				.From("BulkEmailHyperlink")
				.Where("BulkEmailId").IsEqual(Column.Parameter(bulkEmailId));
			delete.Execute();
		}

		private static bool HasMacros(string hyperLink) {
			const string macrosPattern = @"\[#.+?#\]";
			var macrosRegex = new Regex(macrosPattern, RegexOptions.None);
			return macrosRegex.IsMatch(hyperLink);
		}

		/// <summary>
		/// Adds parameters to template <paramref name="links"/>.
		/// </summary>
		/// <param name="links">Template links.</param>
		private static Dictionary<string, string> ModifyTemplateLinks(IEnumerable<string> links) {
			var results = new Dictionary<string, string>();
			foreach (string link in links) {
				string modifiedLink = link;
				string linkHref = MailingUtilities.ParseHtmlHrefValue(modifiedLink);
				if (!string.IsNullOrEmpty(linkHref) 
						&& (linkHref.StartsWith("http://") || linkHref.StartsWith("https://"))) {
					string decodedLinkHref = HttpUtility.HtmlDecode(HttpUtility.UrlDecode(linkHref));
					string modifiedLinkHref = AddParametersToLink(decodedLinkHref);
					modifiedLink = link.ReplaceFirstInstanceOf(linkHref, HttpUtility.HtmlEncode(modifiedLinkHref));
				}
				results[link] = modifiedLink;
			}
			return results;
		}

		/// <summary>
		/// Adds parameters to <paramref name="link"/>.
		/// </summary>
		/// <param name="link">Source link.</param>
		/// <returns>Modified link.</returns>
		private static string AddParametersToLink(string link) {
			var parameters = new Dictionary<string, string> {
				{ ContactIdParameterName, GetFormattedMacros(ContactIdMacrosName) },
				{ BulkEmailRecipientIdParameterName, GetFormattedMacros(BulkEmailRecipientIdName) }
			};
			return BulkEmailUriHelper.AddParametersToUri(link, parameters);
		}

		/// <summary>
		/// Replaces <paramref name="links"/> in <paramref name="templateBody"/>.
		/// </summary>
		/// <param name="templateBody">Template body.</param>
		/// <param name="links">Links.</param>
		/// <returns>Modified template body.</returns>
		private static string ReplaceLinksInTemplate(string templateBody, IDictionary<string, string> links) {
			return links.Aggregate(templateBody,
				(current, link) => current.Replace(link.Key, link.Value, StringComparison.InvariantCultureIgnoreCase));
		}

		/// <summary>
		/// Returns formatted macros.
		/// </summary>
		/// <param name="macrosName">Macros name.</param>
		/// <returns>Formatted macros.</returns>
		private static string GetFormattedMacros(string macrosName) {
			return string.Format("*|{0}|*", macrosName);
		}

		#endregion

		#region Methods: Public

		public static void SaveBulkEmailHyperlinks(Guid bulkEmailId, string templateBody, bool replace,
				UserConnection userConnection) {
			if (replace) {
				ClearBulkEmailHyperlinks(bulkEmailId, userConnection);
			}
			if (string.IsNullOrEmpty(templateBody)) {
				return;
			}

			IDictionary<string, string> hyperlinks = MailingUtilities.ParseHtmlHyperlinks(templateBody);
			foreach (KeyValuePair<string, string> hyperlink in hyperlinks) {
				try {
					if (HasMacros(hyperlink.Key)) {
						continue;
					}
					string decodeUrl = HttpUtility.UrlDecode(hyperlink.Key);
					string url = UtmHelper.RemoveUtmFromUri(decodeUrl);
					string caption = string.IsNullOrEmpty(hyperlink.Value) ? url : hyperlink.Value;
					decodeUrl = HttpUtility.UrlDecode(url.ToLower());
					Guid hashLink = MailingUtilities.GetMD5HashGuid(decodeUrl);
					var bulkEmailHyperlink = new BulkEmailHyperlink(userConnection);
					Dictionary<string, object> conditions = new Dictionary<string, object> {
						{ "BulkEmail", bulkEmailId },
						{ "Hash", hashLink }
					};
					if (!bulkEmailHyperlink.FetchFromDB(conditions)) {
						bulkEmailHyperlink.SetDefColumnValues();
						bulkEmailHyperlink.BulkEmailId = bulkEmailId;
						bulkEmailHyperlink.Caption = caption;
						bulkEmailHyperlink.Url = url;
						bulkEmailHyperlink.Hash = hashLink;
						bulkEmailHyperlink.Save();
					}
				} catch (Exception e) {
					MailingUtilities.Log.ErrorFormat(
						"[BulkEmailHyperlinkHelper.SaveBulkEmailHyperlinks]: Error while saving BulkEmailHyperlink" +
						" \"{0}\" for BulkEmail with Id: {1}", e, hyperlink, bulkEmailId);
				}
			}
		}

		/// <summary>
		/// Removes extra parameters (contactId and bulkEmailRecipientId) from the uri.
		/// </summary>
		/// <param name="sourceUri">Uri.</param>
		/// <returns>Uri.</returns>
		public static string RemoveExtraParametersFromUri(string sourceUri) {
			return BulkEmailUriHelper.RemoveParametersFromUri(sourceUri, ContactIdParameterName,
				BulkEmailRecipientIdParameterName);
		}

		/// <summary>
		/// Modifies <paramref name="templateBody"/>.
		/// </summary>
		/// <param name="templateBody">Template body.</param>
		/// <returns>Modified template body.</returns>
		public static string ModifyTemplate(string templateBody) {
			List<string> anchorElements = MailingUtilities.ParseHtmlAnchorElement(templateBody);
			Dictionary<string, string> modifiedLinks = ModifyTemplateLinks(anchorElements);
			return ReplaceLinksInTemplate(templateBody, modifiedLinks);
		}

		#endregion

	}

	#endregion

}

