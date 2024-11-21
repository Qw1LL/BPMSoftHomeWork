namespace BPMSoft.Configuration.MandrillService
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Configuration.Utils;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: MarketingMacrosHelper

	/// <summary>
	/// ############ ##### ############## ############ # ########### ########.
	/// </summary>
	public class MarketingMacrosHelper: MacrosHelperV2 {

		#region Constants: Private

		private const string GlobalMacrosSchema = "Contact";

		private const string GlobalMacrosSchemaBulkEmail = "BulkEmail";

		private const string MacrosSearchPattern = @"\[#.+?#\]";

		private const string BPMSoftMacrosBeginPattern = "[#";

		private const string BPMSoftMacrosEndPattern = "#]";

		private const string MandrillMacrosBeginPattern = "*|";

		private const string MandrillMacrosEndPattern = "|*";

		private const string UnsubscribeLinkPattern = "{0}/0/ServiceModel/MandrillService.svc/UnsubscribeRecipient";

		private const string UnsubscribeLinkParameterPattern = "?key={0}";

		private const string MandrillUnsubcribeAllLinkPattern = "UNSUB:{0}";

		private const string JoinColumnName = "Id";

		#endregion

		#region Constants: Public

		public const string PersonalMacrosSchema = "Contact";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		private string _body;

		private List<merge_var> _globalMergeVars;

		private Guid _globalMacrosContactId;

		private Guid _globalBulkEmailId;

		private string _applicationUrl;

		private bool _isUsubscribeFromAllMailings;

		private string _unsubscribeApplicationUrl;
		
		private List<MacrosInfo> _macrosCollection;

		#endregion

		#region Properties: Public

		/// <summary>
		/// ######### ########## ######## # ## ########.
		/// </summary>
		public List<merge_var> GlobalMergeVars {
			get {
				return _globalMergeVars;
			}
		}

		/// <summary>
		/// ######### ####### ######## #######.
		/// </summary>
		public IEnumerable<string> UnsubscribeMacrosAliases {
			get {
				foreach (var macros in _macrosCollection) {
					if (macros.ParentId == MarketingConsts.EmailTemplateMacrosParentUnsubscribeId) {
						yield return macros.Alias;
					}
				}
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// ####### ######### ###### MacrosHelper, ### ########## ########## # ############ ########.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		public MarketingMacrosHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_macrosCollection = new List<MacrosInfo>();
			_globalMergeVars = new List<merge_var>();
		}

		#endregion

		#region Methods: Private

		private void InitMacrosCollection() {
			var numberMacros = 0;
			foreach (var macros in _macrosCollection) {
				var rootElementMacros = macros.Alias.Split('.')[0];
				macros.IsGlobal = (macros.ParentId == MarketingConsts.EmailTemplateMacrosParentGlobalId) ||
					(rootElementMacros == GlobalMacrosSchemaBulkEmail);
				string columnPath = "Name";
				if (macros.ParentId == Guid.Empty) {
					var dotPosition =  macros.Alias.IndexOf(".");
					if (dotPosition != -1) {
						columnPath = macros.Alias.Substring(dotPosition + 1);
					}
					macros.ColumnPath = columnPath;
				}
				macros.MacrosText = string.Format("{0}{1}{2}", BPMSoftMacrosBeginPattern, macros.Alias, 
					BPMSoftMacrosEndPattern);
				macros.Alias = string.Format("MACROS{0}", numberMacros);
				numberMacros++;
			}
		}

		public static string ReplaceWithStringComparison(string input, string search, string replace,
				StringComparison comparison) {
			var stringBuilder = new StringBuilder();
			var lastIndex = 0;
			var currIndex = input.IndexOf(search, comparison);
			while (currIndex != -1) {
				stringBuilder.Append(input.Substring(lastIndex, currIndex - lastIndex));
				stringBuilder.Append(replace);
				currIndex += search.Length;
				lastIndex = currIndex;
				currIndex = input.IndexOf(search, currIndex, comparison);
			}
			stringBuilder.Append(input.Substring(lastIndex));
			return stringBuilder.ToString();
		}

		private void ReplaceMacrosInBody() {
			foreach (var macros in _macrosCollection) {
				_body = _body.Replace(macros.MacrosText, string.Format("{0}{1}{2}", MandrillMacrosBeginPattern, 
					macros.Alias, MandrillMacrosEndPattern));
			}
			MacrosInfo unsubscribeUrlMacro = _macrosCollection.FirstOrDefault(macro => 
					macro.Id == MarketingConsts.EmailTemplateMacrosUnsubscribeUrlId);
			if (unsubscribeUrlMacro != null) {
				string unsubscribeUrlMacroMandrillAlias = string.Format("{0}{1}{2}",
					MandrillMacrosBeginPattern, unsubscribeUrlMacro.Alias, MandrillMacrosEndPattern);
				string[] invalidUnsubscribeUrlPrefix = new string[] { "http://" , "https://" };
				foreach (var prefix in invalidUnsubscribeUrlPrefix) {
					string invalidUnsubscribeUrlTextMacros = string.Format("{0}{1}",
						prefix, unsubscribeUrlMacroMandrillAlias);
					_body = ReplaceWithStringComparison(_body, invalidUnsubscribeUrlTextMacros,
						unsubscribeUrlMacroMandrillAlias, StringComparison.OrdinalIgnoreCase);
				}
			}
		}

		private void ProcessGlobalMacros() {
			var globalMacros = _macrosCollection.Where(m => m.IsGlobal).ToList<MacrosInfo>();
			var globalBulkEmailMacros = globalMacros.Where(x => x.ParentId == Guid.Empty);
			var globalOwnerMacros = globalMacros.Where(x => x.ParentId != Guid.Empty);
			var result = new Dictionary<string, string>();
			var	arguments = new Dictionary<Guid, Object>();
			if (globalOwnerMacros.Any()) {
				arguments.Add(MarketingConsts.EmailTemplateMacrosParentGlobalId, _globalMacrosContactId);
				var macrosWithValue = base.GetMacrosValues(globalOwnerMacros, arguments);
				foreach (var macroWithValue in macrosWithValue) {
					result.Add(macroWithValue.Key, macroWithValue.Value);
				}
			}
			if (globalBulkEmailMacros.Any()) {
				arguments = new Dictionary<Guid, Object>();
				arguments.Add(Guid.Empty, new KeyValuePair<string, Guid>(GlobalMacrosSchemaBulkEmail, 
					_globalBulkEmailId));
				var macrosWithValue = base.GetMacrosValues(globalBulkEmailMacros, arguments);
				foreach (var macroWithValue in macrosWithValue) {
					result.Add(macroWithValue.Key, macroWithValue.Value);
				}
			}
			foreach (var macros in result) {
				var globalMergeVar = new merge_var {
						name = macros.Key,
						content = macros.Value
					};
					_globalMergeVars.Add(globalMergeVar);
			}
		}

		private void InitializeUsnsubscribeParameters() {
			_isUsubscribeFromAllMailings = (bool)BPMSoft.Core.Configuration.SysSettings.
				GetValue(_userConnection, "UnsubscribeFromAllMailings");
			_unsubscribeApplicationUrl = (string)BPMSoft.Core.Configuration.SysSettings.
				GetValue(_userConnection, "UnsubscribeApplicationUrl");
			if (_isUsubscribeFromAllMailings) {
				foreach (string alias in UnsubscribeMacrosAliases) {
					string unsubscribeLink = !string.IsNullOrEmpty(_unsubscribeApplicationUrl)
						? _unsubscribeApplicationUrl
						: string.Format(UnsubscribeLinkPattern, _applicationUrl);
					string mandrillUnsubTaggedLink = string.Format(MandrillUnsubcribeAllLinkPattern, unsubscribeLink);
					var taggedBody = _body.Replace(alias, mandrillUnsubTaggedLink);
					_body = taggedBody;
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ######### ######### ############ ########, ######### #######
		/// </summary>
		/// <param name="rcptMergeVar">###### ######### ############ ########</param>
		/// <param name="bulkEmailRId">######## ############# ###### email ########</param>
		/// <param name="bulkEmailId">############# ###### email ########</param>
		/// <param name="emailAddress">Email ##### ##########</param>
		public void InitPersonalUnsubscribeMacros(rcpt_merge_var rcptMergeVar, int bulkEmailRId,
				Guid bulkEmailId, string emailAddress) {
			if (_isUsubscribeFromAllMailings) {
				return;
			}
			string bulkEmail = String.Format("{0:0000000000}", bulkEmailRId);
			foreach (string alias in UnsubscribeMacrosAliases) {
				rcptMergeVar.rcpt = emailAddress;
					string unsubscribeHash = MandrillUtilities.StringCrypto.EncryptString(emailAddress,
						bulkEmailId.ToString("N"));
					string unsubscribeKey = string.Concat(bulkEmail, unsubscribeHash);
					unsubscribeKey = HttpUtility.UrlEncode(unsubscribeKey);
					string unsubscribeLinkParameter = string.Format(UnsubscribeLinkParameterPattern, unsubscribeKey);
					string unsubscribeLink = !string.IsNullOrEmpty(_unsubscribeApplicationUrl)
						? string.Concat(_unsubscribeApplicationUrl, unsubscribeLinkParameter)
						: string.Concat(string.Format(UnsubscribeLinkPattern, _applicationUrl), 
							unsubscribeLinkParameter);
					var mergeVar = new merge_var() {name = alias, content = unsubscribeLink};
					rcptMergeVar.vars.Add(mergeVar);
			}
		}

		/// <summary>
		/// ##### ############# ##### #########, # ######### ############ ######### ########## ########.
		/// </summary>
		/// <param name="body">##### #########.</param>
		/// <param name="globalMacrosContactId">
		/// ########## ############# ############, ###### ######## ####### ### ########## ########.
		/// </param>
		/// <param name="applicationUrl">Url ##### ##########</param>
		/// <returns></returns>
		public string SetTemplateBody(string body, Guid globalMacrosContactId, Guid globalMacrosBulkEmailId, 
				string applicationUrl) {
			_body = body;
			_globalMacrosContactId = globalMacrosContactId;
			_globalBulkEmailId = globalMacrosBulkEmailId;
			_applicationUrl = applicationUrl;
			base.UserConnection = _userConnection;
			_macrosCollection = base.GetMacrosCollection(_body);
			InitMacrosCollection();
			ReplaceMacrosInBody();
			ProcessGlobalMacros();
			InitializeUsnsubscribeParameters();
			return _body;
		}

		/// <summary>
		/// Returns unique identifier BulkEmail by RId.
		/// </summary>
		/// <param name="RId">Numeric identifier of BulkEmail.</param>
		/// <returns>Unique identifier of BulkEmail.</returns>
		public Guid GetBulkEmailIdFromRId(int RId) {
			var select = new Select(_userConnection)
				.Column("Id")
				.From("BulkEmail")
				.Where("RId").IsEqual(Column.Parameter(RId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Returns RId column for object BulkEmail by unique Guid.
		/// </summary>
		/// <param name="Id">Unique identifier of BulkEmail.</param>
		/// <returns>Numeric identifier of BulkEmail.</returns>
		public int GetBulkEmailRIdFromId(Guid Id) {
			var select = new Select(_userConnection)
				.Column("RId")
				.From("BulkEmail")
				.Where("Id").IsEqual(Column.Parameter(Id)) as Select;
			return select.ExecuteScalar<int>();
		}

		/// <summary>
		/// Returns contact macros.
		/// </summary>
		/// <param name="contactId">Unique identifier of Contact.</param>
		/// <param name="emailRecipient">Email address of recipients.</param>
		/// <param name="bulkEmailId">Unique identifier of BulkEmail.</param>
		/// <returns></returns>
		public rcpt_merge_var GetRecipientMacros(Guid contactId, string emailRecipient, Guid bulkEmailId) {
			var personalMacros = _macrosCollection.Where(m => !m.IsGlobal);
			var	arguments = new Dictionary<Guid, Object>();
			arguments.Add(Guid.Empty, new KeyValuePair<string, Guid>(PersonalMacrosSchema, contactId));
			arguments.Add(MarketingConsts.EmailTemplateMacrosParentContactId, contactId);
			var replaceDictionary = base.GetMacrosValues(personalMacros, arguments);
			rcpt_merge_var personalMergeVar = new rcpt_merge_var();
			foreach (var macros in replaceDictionary) {
				var merge_var_new = new merge_var {
						name = macros.Key,
						content = macros.Value
					};
					personalMergeVar.vars.Add(merge_var_new);
			}
			personalMergeVar.rcpt = emailRecipient;
			int bulkEmailRId = GetBulkEmailRIdFromId(bulkEmailId);
			InitPersonalUnsubscribeMacros(personalMergeVar, bulkEmailRId , bulkEmailId, emailRecipient);
			return personalMergeVar;
		}

		/// <summary>
		/// Returns recipients collection with macros.
		/// </summary>
		/// <param name="select">Query subselect conditional.</param>
		/// <param name="contactCollection">Unique identifier of contacts with email address.</param>
		/// <param name="bulkEmailRId">Numeric identifier of BulkEmail.</param>
		/// <returns></returns>
		public List<rcpt_merge_var> GetRecipientsMacrosCollection(Select select, 
				Dictionary<Guid, string> contactCollection, int bulkEmailRId) {
			List<rcpt_merge_var> personalMergeVars = new List<rcpt_merge_var>();
			var bulkEmailId = GetBulkEmailIdFromRId(bulkEmailRId);
			var personalMacros = _macrosCollection.Where(m => !m.IsGlobal);
			var	arguments = new Dictionary<Guid, Object>();
			var	argValue = new Dictionary<string, Object>();
			argValue.Add("SubSelect", select);
			argValue.Add("JoinColumnName", JoinColumnName);
			argValue.Add("SchemaName", PersonalMacrosSchema);
			arguments.Add(Guid.Empty, argValue);
			arguments.Add(MarketingConsts.EmailTemplateMacrosParentContactId, argValue);
			var result = base.GetMacrosValuesCollection(personalMacros, arguments);
			foreach (var res in result) {
				rcpt_merge_var personalMergeVar = new rcpt_merge_var();
				foreach (var macros in res.Value) {
					var merge_var_new = new merge_var {
							name = macros.Key,
							content = macros.Value
						};
					personalMergeVar.vars.Add(merge_var_new);
				}
				var address = contactCollection[(Guid)res.Key];
				personalMergeVar.rcpt =  address;
				InitPersonalUnsubscribeMacros(personalMergeVar, bulkEmailRId, bulkEmailId, address);
				personalMergeVars.Add(personalMergeVar);
			}
			return personalMergeVars;
		}

		#endregion

	}

	#endregion
}

