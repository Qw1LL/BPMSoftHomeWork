namespace BPMSoft.Configuration.MandrillService
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: MacrosHelper

	/// <summary>
	/// ############ ##### ############## ############ # ########### ########.
	/// </summary>
	public class MacrosHelper {

		#region Class: Internal

		internal class Macros {

			public string MacrosText {
				get;
				set;
			}

			public string ColumnPath {
				get;
				set;
			}

			public bool IsGlobal {
				get;
				set;
			}

			public bool IsEnabled {
				get;
				set;
			}

			public string Alias {
				get;
				set;
			}

			public string MacrosTextMandrill {
				get {
					return string.Format("{0}{1}{2}", MandrillMacrosBeginPattern, Alias,
						MandrillMacrosEndPattern);
				}
			}

			public Guid ParentMacrosId {
				get;
				set;
			}

			public string Code {
				get;
				set;
			}
		}

		#endregion

		#region Constants: Private

		private const string GlobalMacrosSchema = "Contact";

		private const string MacrosSearchPattern = @"\[#.+?#\]";

		private const string BPMSoftMacrosBeginPattern = "[#";

		private const string BPMSoftMacrosEndPattern = "#]";

		private const string MandrillMacrosBeginPattern = "*|";

		private const string MandrillMacrosEndPattern = "|*";

		private const string UnsubscribeLinkPattern = "{0}/0/ServiceModel/MandrillService.svc/UnsubscribeRecipient";

		private const string UnsubscribeLinkParameterPattern = "?key={0}";

		private const string MandrillUnsubcribeAllLinkPattern = "UNSUB:{0}";

		#endregion

		#region Constants: Public

		public const string PersonalMacrosSchema = "Contact";

		#endregion

		#region Fields: Private

		private readonly List<Macros> _macrosCollection;

		private readonly UserConnection _userConnection;

		private string _body;

		private List<merge_var> _globalMergeVars;

		private Guid _globalMacrosContactId;

		private string _applicationUrl;

		private bool _isUsubscribeFromAllMailings;

		private string _unsubscribeApplicationUrl;

		#endregion

		#region Properties: Private

		private IEnumerable<Macros> EnabledGlobalMacroses {
			get {
				foreach (var macros in _macrosCollection) {
					if (macros.IsEnabled && !string.IsNullOrEmpty(macros.ColumnPath) && macros.IsGlobal) {
						yield return macros;
					}
				}
			}
		}

		#endregion

		#region Properties: Internal

		internal IEnumerable<Macros> EnabledPersonalMacroses {
			get {
				foreach (var macros in _macrosCollection) {
					if (macros.IsEnabled && !string.IsNullOrEmpty(macros.ColumnPath) && !macros.IsGlobal) {
						yield return macros;
					}
				}
			}
		}

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
		/// ######### ####### ############ ########.
		/// </summary>
		public IEnumerable<string> PersonalMacrosAliases {
			get {
				foreach (var macros in _macrosCollection) {
					if (macros.IsEnabled && !string.IsNullOrEmpty(macros.ColumnPath) && !macros.IsGlobal) {
						yield return macros.Alias;
					}
				}
			}
		}

		/// <summary>
		/// ######### ####### ########## ########.
		/// </summary>
		public IEnumerable<string> GlobalMacrosAliases {
			get {
				foreach (var macros in _macrosCollection) {
					if (macros.IsEnabled && !string.IsNullOrEmpty(macros.ColumnPath) && macros.IsGlobal) {
						yield return macros.Alias;
					}
				}
			}
		}

		/// <summary>
		/// ######### ####### ######## #######.
		/// </summary>
		public IEnumerable<string> UnsubscribeMacrosAliases {
			get {
				foreach (var macros in _macrosCollection) {
					if (macros.IsEnabled && macros.ParentMacrosId == MarketingConsts.EmailTemplateMacrosParentUnsubscribeId) {
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
		public MacrosHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_macrosCollection = new List<Macros>();
			_globalMergeVars = new List<merge_var>();
		}

		#endregion

		#region Methods: Private

		private void InitMacrosCollection() {
			int macrosCount = 0;
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "EmailTemplateMacros");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Name");
			esq.AddColumn("Parent");
			esq.AddColumn("Parent.Name");
			esq.AddColumn("ColumnPath");
			esq.AddColumn("Code");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.IsNotNull, "Parent"));
			EntityCollection entityCollection = esq.GetEntityCollection(_userConnection);
			foreach (Entity entity in entityCollection) {
				var name = entity.GetTypedColumnValue<string>("Name");
				var parentName = entity.GetTypedColumnValue<string>("ParentName");
				var columnPath = entity.GetTypedColumnValue<string>("ColumnPath");
				var parent = entity.GetTypedColumnValue<Guid>("ParentId");
				var code = entity.GetTypedColumnValue<string>("Code");
				var macros = new Macros();
				macros.MacrosText = string.Format("{0}{1}.{2}{3}", BPMSoftMacrosBeginPattern, parentName, name,
					BPMSoftMacrosEndPattern);
				macros.ColumnPath = columnPath;
				macros.IsGlobal = (parent == MarketingConsts.EmailTemplateMacrosParentGlobalId);
				macros.Alias = string.Format("MACROS{0}", macrosCount);
				macros.ParentMacrosId = parent;
				macros.Code = code;
				macrosCount++;
				_macrosCollection.Add(macros);
			}
		}

		private void FillMacrosFromTemplate() {
			var myRegex = new Regex(MacrosSearchPattern, RegexOptions.None);
			foreach (Match myMatch in myRegex.Matches(_body)) {
				if (myMatch.Success) {
					AddTemplateMacros(myMatch.Value);
				}
			}
		}

		private void AddTemplateMacros(string macrosText) {
			Macros macros = _macrosCollection.FirstOrDefault(x => x.MacrosText == macrosText);
			if (macros != null) {
				macros.IsEnabled = true;
			}
		}

		private void ClearAndReplaceMacros() {
			foreach (var macros in _macrosCollection) {
				if (macros.IsEnabled) {
					_body = _body.Replace(macros.MacrosText, macros.MacrosTextMandrill);
				}
			}
		}

		private void ProcessGlobalMacros() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, GlobalMacrosSchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			foreach (var macros in EnabledGlobalMacroses) {
				esq.AddColumn(macros.ColumnPath);
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", _globalMacrosContactId));
			if (esq.Columns.Count == 1) {
				return;
			}
			var entityCollection = esq.GetEntityCollection(_userConnection);
			foreach (var entity in entityCollection) {
				foreach (var macros in EnabledGlobalMacroses) {
					var entitySchemaQueryColumn = esq.Columns.FirstOrDefault(r => r.Path == macros.ColumnPath);
					if (entitySchemaQueryColumn == null) {
						continue;
					}
					string entitySchemaQueryColumnValue = entity.
					GetTypedColumnValue<object>(entitySchemaQueryColumn.Name).ToString();
					var globalMergeVar = new merge_var {
						name = macros.Alias,
						content = entitySchemaQueryColumnValue
					};
					_globalMergeVars.Add(globalMergeVar);
				}
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
		public void InitPersonalUnsubscribeMacroses(rcpt_merge_var rcptMergeVar, int bulkEmailRId,
				Guid bulkEmailId, string emailAddress) {
			if(_isUsubscribeFromAllMailings) {
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
						: string.Concat(string.Format(UnsubscribeLinkPattern, _applicationUrl), unsubscribeLinkParameter);
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
		public string SetTemplateBody(string body, Guid globalMacrosContactId, string applicationUrl) {
			_body = body;
			_globalMacrosContactId = globalMacrosContactId;
			_applicationUrl = applicationUrl;
			InitMacrosCollection();
			FillMacrosFromTemplate();
			ClearAndReplaceMacros();
			ProcessGlobalMacros();
			InitializeUsnsubscribeParameters();
			return _body;
		}

		#endregion

	}

	#endregion

}
