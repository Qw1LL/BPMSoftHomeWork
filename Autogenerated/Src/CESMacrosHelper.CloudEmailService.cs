namespace BPMSoft.Configuration
{
	using BPMSoft.Configuration.CESModels;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Common;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: CESMacrosHelper

	/// <summary>
	/// Provides methods for the processing macros of email template.
	/// </summary>
	public class CESMacrosHelper : MacrosHelperV2
	{

		#region Constants: Private

		private const string UnsubscribeMacrosName = "UNSUB_URL";

		private const string UseDefaultUnsubscriptionMacrosName = "USE_DEFAULT_UNSUB";

		private const string GlobalMacrosSchemaBulkEmail = "BulkEmail";

		private const string CESMacrosPattern = "*|{0}|*";

		private readonly string[] InvalidUnsubscribeUrlPrefix = { "http://", "https://" };

		private const string UrlEncodedMacrosPattern = "Url{0}";

		private static readonly Regex UrlEncodedMacrosAliasRegex = new Regex("^Url.*$");

		#endregion

		#region Constants: Protected

		protected const string JoinColumnName = "Id";

		#endregion

		#region Constants: Public

		public static readonly string PersonalMacrosSchema = "Contact";

		#endregion

		#region Fields: Private

		private readonly Guid _globalMacrosContactId;

		private readonly Guid _globalBulkEmailId;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates instance of MacrosHelper class, to prepare global and personal macros.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="contactId">Unique identifier of the contact that will be used for 
		/// initializing collection of global macros.</param>
		/// <param name="bulkEmailId">Unique identifier of the bulk email that will be used for 
		/// initializing collection of global macros.</param>
		public CESMacrosHelper(UserConnection userConnection, Guid contactId, Guid bulkEmailId) {
			UserConnection = userConnection;
			_globalMacrosContactId = contactId;
			_globalBulkEmailId = bulkEmailId;
		}

		#endregion

		#region Methods: Private

		private void InitMacrosCollection(List<MacrosInfo> macroses) {
			var numberMacros = 0;
			foreach (var macros in macroses) {
				string rootElementMacros = macros.Alias.Split('.')[0];
				macros.IsGlobal = (macros.ParentId == MailingConsts.EmailTemplateMacrosParentGlobalId) ||
					(rootElementMacros == GlobalMacrosSchemaBulkEmail);
				string columnPath = "Name";
				if (macros.ParentId == Guid.Empty) {
					int dotPosition = macros.Alias.IndexOf(".");
					if (dotPosition != -1) {
						columnPath = macros.Alias.Substring(dotPosition + 1);
					}
					macros.ColumnPath = columnPath;
				}
				macros.MacrosText = string.Format(MacrosTemplate, macros.Alias);
				macros.Alias = string.Format("MACROS{0}", numberMacros);
				numberMacros++;
			}
		}

		private string GetUnsubscribeMacrosAlias(IEnumerable<MacrosInfo> macrosCollection) {
			MacrosInfo unsubMacros = macrosCollection.FirstOrDefault(
				macro => macro.Id == MailingConsts.EmailTemplateMacrosUnsubscribeUrlId);
			string unsubAlias = string.Empty;
			if (unsubMacros != null) {
				unsubAlias = string.Format(CESMacrosPattern, unsubMacros.Alias);
			}
			return unsubAlias;
		}

		private IEnumerable<string> GetUnsubscribeMacrosAliases(IEnumerable<MacrosInfo> macrosCollection) {
			return macrosCollection
				.Where(_ => _.ParentId == MailingConsts.EmailTemplateMacrosParentUnsubscribeId)
				.Select(_ => _.Alias);
		}

		private string[] GetInvalidUnsubscribeTextMacroses(IEnumerable<MacrosInfo> macrosCollection) {
			string unsubMacrosAlias = GetUnsubscribeMacrosAlias(macrosCollection);
			string[] result = { };
			if (!string.IsNullOrEmpty(unsubMacrosAlias)) {
				result = InvalidUnsubscribeUrlPrefix.Select(self => string.Concat(self, unsubMacrosAlias)).ToArray();
			}
			return result;
		}

		private string FixInvalidUnsubMacros(string source, IEnumerable<MacrosInfo> macrosCollection) {
			string unsubMacrosAlias = GetUnsubscribeMacrosAlias(macrosCollection);
			string result = source;
			if (!string.IsNullOrEmpty(unsubMacrosAlias)) {
				foreach (string invalidMacrosText in GetInvalidUnsubscribeTextMacroses(macrosCollection)) {
					result = ReplaceWithStringComparison(result, invalidMacrosText, unsubMacrosAlias);
				}
			}
			return result;
		}

		private static string ReplaceWithStringComparison(string input, string search, string replace) {
			var stringBuilder = new StringBuilder();
			var lastIndex = 0;
			var currIndex = input.IndexOf(search, StringComparison.OrdinalIgnoreCase);
			while (currIndex != -1) {
				stringBuilder.Append(input.Substring(lastIndex, currIndex - lastIndex));
				stringBuilder.Append(replace);
				currIndex += search.Length;
				lastIndex = currIndex;
				currIndex = input.IndexOf(search, currIndex, StringComparison.OrdinalIgnoreCase);
			}
			stringBuilder.Append(input.Substring(lastIndex));
			return stringBuilder.ToString();
		}

		private string ReplaceUsnsubscribeMacros(string body, IEnumerable<MacrosInfo> macrosCollection) {
			string result = body;
			foreach (string alias in GetUnsubscribeMacrosAliases(macrosCollection)) {
				result = result.Replace(alias, UnsubscribeMacrosName);
			}
			return result;
		}

		private IEnumerable<MacrosInfo> GetGlobalBulkEmailMacros(IEnumerable<MacrosInfo> macrosCollection) {
			return macrosCollection.Where(m => m.IsGlobal && m.ParentId == Guid.Empty);
		}

		private IEnumerable<MacrosInfo> GetGlobalOwnerMacros(IEnumerable<MacrosInfo> macrosCollection) {
			return macrosCollection.Where(m => m.IsGlobal && m.ParentId != Guid.Empty);
		}

		private KeyValuePair<string, string> GetUnsubscribeMacrosValue() {
			string unsubscribeLink = GetUnsubscribeUrl();
			return new KeyValuePair<string, string>(UnsubscribeMacrosName, unsubscribeLink);
		}

		private KeyValuePair<string, string> GetUseDefaultUnsubscriptionMacrosValue() {
			string unsubFromAllMailings = GetUnsubscribeFromAllMailingsSetting();
			return new KeyValuePair<string, string>(UseDefaultUnsubscriptionMacrosName, unsubFromAllMailings);
		}

		private Dictionary<string, string> GetGlobalMacrosValues(IEnumerable<MacrosInfo> macrosCollection) {
			var globalMacrosValues = new Dictionary<string, string>();
			Dictionary<string, string> ownerMacrosWithValue = GetGlobalOwnerMacrosValues(macrosCollection);
			Dictionary<string, string> bulkEmailMacrosWithValue = GetGlobalBulkEmailMacrosValues(macrosCollection);
			KeyValuePair<string, string> unsubMacrosValue = GetUnsubscribeMacrosValue();
			KeyValuePair<string, string> unsubFromAllMailingsMacrosValue = GetUseDefaultUnsubscriptionMacrosValue();
			globalMacrosValues.AddRange((IEnumerable<KeyValuePair<string, string>>)ownerMacrosWithValue);
			globalMacrosValues.AddRange((IEnumerable<KeyValuePair<string, string>>)bulkEmailMacrosWithValue);
			globalMacrosValues.Add(unsubMacrosValue.Key, unsubMacrosValue.Value);
			globalMacrosValues.Add(unsubFromAllMailingsMacrosValue.Key, unsubFromAllMailingsMacrosValue.Value);
			return globalMacrosValues;
		}

		private Dictionary<string, string> GetGlobalOwnerMacrosValues(IEnumerable<MacrosInfo> macrosCollection) {
			var result = new Dictionary<string, string>();
			var globalOwnerMacros = GetGlobalOwnerMacros(macrosCollection);
			if (globalOwnerMacros.Any()) {
				var arguments = new Dictionary<Guid, Object>();
				arguments.Add(MailingConsts.EmailTemplateMacrosParentGlobalId, _globalMacrosContactId);
				result = GetMacrosValues(globalOwnerMacros, arguments);
			}
			return result;
		}

		private Dictionary<string, string> GetGlobalBulkEmailMacrosValues(IEnumerable<MacrosInfo> macrosCollection) {
			var result = new Dictionary<string, string>();
			var globalBulkEmailMacros = GetGlobalBulkEmailMacros(macrosCollection);
			if (globalBulkEmailMacros.Any()) {
				var arguments = new Dictionary<Guid, Object>();
				arguments.Add(Guid.Empty, new KeyValuePair<string, Guid>(GlobalMacrosSchemaBulkEmail,
					_globalBulkEmailId));
				result = GetMacrosValues(globalBulkEmailMacros, arguments);
			}
			return result;
		}

		private Dictionary<string, string> GetPersonalMacrosValues(Guid contactId,
				IEnumerable<MacrosInfo> macrosCollection) {
			var personalMacros = macrosCollection.Where(m => !m.IsGlobal);
			var arguments = new Dictionary<Guid, Object>();
			arguments.Add(Guid.Empty, new KeyValuePair<string, Guid>(PersonalMacrosSchema, contactId));
			arguments.Add(MailingConsts.EmailTemplateMacrosParentContactId, contactId);
			return GetMacrosValues(personalMacros, arguments);
		}

		private Dictionary<object, Dictionary<string, string>> GetPersonalMacrosValues(Select select,
				IEnumerable<MacrosInfo> macrosCollection) {
			var personalMacros = macrosCollection.Where(m => !m.IsGlobal);
			var arguments = CreateMacrosWorkerParameters(select);
			return GetMacrosValuesCollection(personalMacros, arguments);
		}

		private string GetUnsubscribeUrl() {
			return (string)BPMSoft.Core.Configuration.SysSettings.
				GetValue(UserConnection, "RedirectUnsuscribersTo");
		}

		private string GetUnsubscribeFromAllMailingsSetting() {
			return BPMSoft.Core.Configuration.SysSettings.
				GetValue(UserConnection, "UnsubscribeFromAllMailings").ToString();
		}

		/// <summary>
		/// Creates macros variables for recipient template.
		/// </summary>
		/// <param name="recipient">Recipient information. Contains contact identifier, recipient identifier.</param>
		/// <param name="macrosValues">Macros values.</param>
		/// <returns>Macros variables for recipient template.</returns>
		private rcpt_merge_var CreateRecipientMergeVars(IMessageRecipientInfo recipient,
				Dictionary<string, string> macrosValues) {
			rcpt_merge_var personalMergeVar = new rcpt_merge_var();
			foreach (KeyValuePair<string, string> macros in macrosValues) {
				personalMergeVar.vars.Add(CreateMergeVar(macros.Key, macros.Value));
			}
			personalMergeVar.vars.Add(CreateMergeVar(
				BulkEmailHyperlinkHelper.ContactIdMacrosName,
				recipient.ContactId.ToString()
			));
			personalMergeVar.vars.Add(CreateMergeVar(
				BulkEmailHyperlinkHelper.BulkEmailRecipientIdName,
				recipient.Id.ToString()
			));
			personalMergeVar.rcpt = recipient.EmailAddress;
			return personalMergeVar;
		}

		private string GetMacrosValue(string macrosName, string macrosContent) {
			string resultContent = macrosContent;
			if (UrlEncodedMacrosAliasRegex.IsMatch(macrosName)) {
				resultContent = HttpUtility.UrlPathEncode(macrosContent);
			}
			return resultContent;
		}

		/// <summary>
		/// Creates merge var.
		/// </summary>
		/// <param name="macrosName">Macros name.</param>
		/// <param name="macrosContent">Macros content.</param>
		/// <returns></returns>
		private merge_var CreateMergeVar(string macrosName, string macrosContent) {
			return new merge_var {
				name = macrosName,
				content = GetMacrosValue(macrosName, macrosContent)
			};
		}

		/// <summary>
		/// Returns all anchor elements from <paramref name="src"/>.
		/// </summary>
		/// <param name="src">Source text.</param>
		/// <returns>Collection of anchor elements, element definition as key and href parameter as value.</returns>
		private Dictionary<string, string> ParseHtmlAnchorElements(string src) {
			var result = new Dictionary<string, string>();
			List<string> anchorElements = MailingUtilities.ParseHtmlAnchorElement(src);
			foreach (string anchorElement in anchorElements) {
				result[anchorElement] = MailingUtilities.ParseHtmlHrefValue(anchorElement);
			}
			return result;
		}

		private List<MacrosInfo> GetUriEncodedMacrosCollection(List<MacrosInfo> macrosList, string src) {
			Dictionary<string, string> anchorElements = ParseHtmlAnchorElements(src);
			var result = new Dictionary<string, MacrosInfo>();
			foreach (MacrosInfo macros in macrosList) {
				bool macrosProcessed = false;
				for (int i = 0; !macrosProcessed && i < anchorElements.Count; i++) {
					KeyValuePair<string, string> anchorElemet = anchorElements.ElementAt(i);
					if (anchorElemet.Value.Contains(macros.MacrosText) && !result.Keys.Contains(macros.Alias)) {
						var newMacros = new MacrosInfo(macros);
						newMacros.Alias = string.Format(UrlEncodedMacrosPattern, newMacros.Alias);
						result[macros.Alias] = (newMacros);
						macrosProcessed = true;
					}
				}
			}
			return result.Values.ToList();
		}

		private string ReplaceMacrosInUrl(string src, string oldMacros, string newMacros) {
			Dictionary<string, string> anchorElements = ParseHtmlAnchorElements(src);
			string result = src;
			foreach (KeyValuePair<string, string> anchorElemet in anchorElements) {
				if (anchorElemet.Value.Contains(oldMacros)) {
					string modifiedUri = anchorElemet.Value.Replace(oldMacros, newMacros);
					string modifiedAnchorEl = anchorElemet.Key.Replace(anchorElemet.Value, modifiedUri);
					result = result.ReplaceFirstInstanceOf(anchorElemet.Key, modifiedAnchorEl);
				}
			}
			return result;
		}

		#endregion

		#region Methods: Protected

		protected virtual Dictionary<Guid, object> CreateMacrosWorkerParameters(Select select) {
			var result = new Dictionary<Guid, object>();
			var argValue = new Dictionary<string, object>();
			argValue.Add("SubSelect", select);
			argValue.Add("JoinColumnName", JoinColumnName);
			argValue.Add("SchemaName", PersonalMacrosSchema);
			result.Add(Guid.Empty, argValue);
			result.Add(MailingConsts.EmailTemplateMacrosParentContactId, argValue);
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Parses source text and returns collection of macros fond in there.
		/// </summary>
		/// <param name="src">Source text.</param>
		/// <returns>Macroses.</returns>
		public override List<MacrosInfo> GetMacrosCollection(string src) {
			List<MacrosInfo> macrosList = base.GetMacrosCollection(src);
			InitMacrosCollection(macrosList);
			List<MacrosInfo> uriEncodedMacrosList = GetUriEncodedMacrosCollection(macrosList, src);
			macrosList.InsertRange(0, uriEncodedMacrosList);
			return macrosList;
		}

		/// <summary>
		/// Replaces macros definition in source text on its alias.
		/// </summary>
		/// <param name="src">Source text.</param>
		/// <param name="macrosCollection">Collection of macros.</param>
		/// <returns>Processed text.</returns>
		public string ReplaceMacros(string src, IEnumerable<MacrosInfo> macrosCollection) {
			string result = src;
			foreach (MacrosInfo macros in macrosCollection) {
				string newMacrosText = string.Format(CESMacrosPattern, macros.Alias);
				if (UrlEncodedMacrosAliasRegex.IsMatch(macros.Alias)) {
					result = ReplaceMacrosInUrl(result, macros.MacrosText, newMacrosText);
				} else {
					result = result.Replace(macros.MacrosText, newMacrosText);
				}
			}
			result = FixInvalidUnsubMacros(result, macrosCollection);
			result = ReplaceUsnsubscribeMacros(result, macrosCollection);
			return result;
		}

		/// <summary>
		/// Returns global macros values collection.
		/// </summary>
		/// <param name="macrosCollection">Collection of macros.</param>
		/// <returns>Macros values collection.</returns>
		public List<merge_var> GetGlobalMergeVars(IEnumerable<MacrosInfo> macrosCollection) {
			List<merge_var> mergeVars = new List<merge_var>();
			Dictionary<string, string> result = GetGlobalMacrosValues(macrosCollection);
			foreach (KeyValuePair<string, string> macros in result) {
				mergeVars.Add(CreateMergeVar(macros.Key, macros.Value));
			}
			return mergeVars;
		}

		/// <summary>
		/// Returns personal macros of the contact.
		/// </summary>
		/// <param name="contactId">Unique identifier of Contact.</param>
		/// <param name="emailRecipient">Email address of recipients.</param>
		/// <param name="macrosCollection">Collection of macros.</param>
		/// <returns>The recipient macros.</returns>
		public rcpt_merge_var GetPersonalMergeVars(Guid contactId, string emailRecipient,
				IEnumerable<MacrosInfo> macrosCollection) {
			Dictionary<string, string> macrosValues = GetPersonalMacrosValues(contactId, macrosCollection);
			IMessageRecipientInfo recipient = new BulkEmailRecipientInfo {
				EmailAddress = emailRecipient,
				ContactId = contactId
			};
			return CreateRecipientMergeVars(recipient, macrosValues);
		}

		/// <summary>
		/// Returns personal macros of the contact.
		/// </summary>
		/// <param name="recipient">Recipient.</param>
		/// <param name="macrosCollection">Collection of macros.</param>
		/// <returns>The recipient macros.</returns>
		public rcpt_merge_var GetPersonalMergeVars(IMessageRecipientInfo recipient,
				IEnumerable<MacrosInfo> macrosCollection) {
			Dictionary<string, string> macrosValues = GetPersonalMacrosValues(recipient.ContactId, macrosCollection);
			return CreateRecipientMergeVars(recipient, macrosValues);
		}

		/// <summary>
		/// Returns personal macros of the contacts.
		/// </summary>
		/// <param name="select">Query subselect conditional.</param>
		/// <param name="contactCollection">Unique identifier of contacts with recipient information.</param>
		/// <param name="macrosCollection">Collection of macros.</param>
		/// <returns>The recipients macros.</returns>
		[Obsolete]
		public List<rcpt_merge_var> GetPersonalMergeVars(Select select,
				Dictionary<Guid, IMessageRecipientInfo> contactCollection, IEnumerable<MacrosInfo> macrosCollection) {
			List<rcpt_merge_var> personalMergeVars = new List<rcpt_merge_var>();
			Dictionary<object, Dictionary<string, string>> results = GetPersonalMacrosValues(select, macrosCollection);
			foreach (KeyValuePair<object, Dictionary<string, string>> result in results) {
				Guid contactId = (Guid)result.Key;
				Dictionary<string, string> macrosValues = result.Value;
				if (contactCollection.ContainsKey(contactId)) {
					IMessageRecipientInfo recipient = contactCollection[contactId];
					rcpt_merge_var personalMergeVar = CreateRecipientMergeVars(recipient, macrosValues);
					personalMergeVars.Add(personalMergeVar);
				}
			}
			return personalMergeVars;
		}
				
		/// <summary>
		/// Returns personal macros of the contacts.
		/// </summary>
		/// <param name="select">Query subselect conditional.</param>
		/// <param name="contactCollection">Unique identifier of contacts with recipient information.</param>
		/// <param name="macrosCollection">Collection of macros.</param>
		/// <returns>The recipients macros.</returns>
		public Dictionary<IMessageRecipientInfo, rcpt_merge_var> GetRecipientMergeVars(Select select,
				Dictionary<Guid, IMessageRecipientInfo> contactCollection, IEnumerable<MacrosInfo> macrosCollection) {
			Dictionary<IMessageRecipientInfo, rcpt_merge_var> personalMergeVars =
				new Dictionary<IMessageRecipientInfo, rcpt_merge_var>();
			Dictionary<Guid, Dictionary<string, string>> personalMacrosResult =
				GetPersonalMacrosValues(select, macrosCollection).ToDictionary(entry => (Guid)entry.Key,
					entry => entry.Value);
			foreach (KeyValuePair<Guid, IMessageRecipientInfo> recipient in contactCollection) {
				rcpt_merge_var personalMergeVar = null;
				if (personalMacrosResult.ContainsKey(recipient.Key)) {
					Dictionary<string, string> macrosValues = personalMacrosResult[recipient.Key];
					personalMergeVar = CreateRecipientMergeVars(recipient.Value, macrosValues);
				}
				personalMergeVars.Add(recipient.Value, personalMergeVar);
			}
			return personalMergeVars;
		}

		#endregion

	}

	#endregion
}

