namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using Utils;

	#region Class: BulkEmailMacroParser

	/// <summary>
	/// Provides methods for the parsing macros within email template.
	/// </summary>
	public class BulkEmailMacroParser
	{

		#region Constants: Private

		private const string _unsubscribeMacroName = "UNSUB_URL";
		private const string _bpmMacroPattern = "[#{0}#]";
		private const string _globalMacroSchemaBulkEmail = "BulkEmail";
		private const string _cesMacroPattern = "*|{0}|*";
		private const string _urlEncodedMacroPattern = "Url{0}";

		#endregion

		#region Fields: Private
		
		private readonly Regex UrlEncodedMacrosAliasRegex = new Regex("^Url.*$");
		private readonly Regex _urlEncodedMacroAliasRegex = new Regex("^Url.*$");
		private readonly Regex _macroNameRegex = new Regex("\\[#([^\\]]*)#\\]");
		private readonly string[] _invalidUnsubscribeUrlPrefix = {"http://", "https://"};
		private readonly string _linkedEntityColumnName = "LinkedEntity";
		private readonly string _linkedEntitySchemaName;
		private readonly MacrosHelperV2 _macrosHelper;

		#endregion

		#region Fields: Protected

		protected readonly UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="BulkEmailMacroParser"/> class.
		/// </summary>
		public BulkEmailMacroParser(MacrosHelperV2 macrosHelper) {
			_macrosHelper = macrosHelper;
			UserConnection = macrosHelper?.UserConnection;
		}

		/// <summary>
		/// Creates instance of <see cref="BulkEmailMacroParser"/> class.
		/// </summary>
		public BulkEmailMacroParser(MacrosHelperV2 macrosHelper, string linkedEntitySchemaName) : this(macrosHelper) {
			_linkedEntitySchemaName = linkedEntitySchemaName;
		}

		#endregion

		#region Methods: Private

		private string TryGetDisplayValueColumn(string macroAlias) {
			var entitySchemaName = macroAlias == _linkedEntityColumnName ? _linkedEntitySchemaName : macroAlias;
			if (string.IsNullOrWhiteSpace(entitySchemaName)) {
				return null;
			}
			var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(entitySchemaName);
			return entitySchema?.FindPrimaryDisplayColumnName();
		}

		private string GetMacroColumnPath(MacrosInfo macro) {
			if (macro.ParentId != Guid.Empty) {
				return macro.ColumnPath;
			}
			var dotPosition = macro.Alias.IndexOf(".", StringComparison.Ordinal);
			return dotPosition != -1 ? macro.Alias.Substring(dotPosition + 1) : TryGetDisplayValueColumn(macro.Alias);
		}

		private Guid GetMacroParentId(MacrosInfo macro) {
			if (macro.ParentId != Guid.Empty || macro.IsGlobal) {
				return macro.ParentId;
			}
			var parentId = Guid.Empty;
			var rootElementMacro = macro.Alias.Split('.')[0];
			switch (rootElementMacro) {
				case "LinkedEntity":
					parentId = MailingConsts.EmailTemplateMacrosParentEntityId;
					break;
				case "Contact":
					parentId = MailingConsts.EmailTemplateMacrosParentContactId;
					break;
			}
			return parentId;
		}

		private bool IsSenderMacro(MacrosInfo macro) {
			return macro.ParentId == MailingConsts.EmailTemplateMacrosParentGlobalId;
		}

		private bool IsBulkEmailMacro(MacrosInfo macro) {
			var rootElementMacro = macro.Alias.Split('.')[0];
			return rootElementMacro == _globalMacroSchemaBulkEmail;
		}

		private void InitMacrosCollection(IEnumerable<MacrosInfo> macros) {
			var macroIndex = 0;
			foreach (var macro in macros) {
				macro.IsGlobal = IsSenderMacro(macro) || IsBulkEmailMacro(macro);
				macro.ColumnPath = GetMacroColumnPath(macro);
				macro.Id = macro.Id.IsEmpty() ? Guid.NewGuid() : macro.Id;
				macro.ParentId = GetMacroParentId(macro);
				macro.MacrosText = string.Format(_bpmMacroPattern, macro.Alias);
				macro.Alias = $"MACROS{macroIndex}";
				macroIndex++;
			}
		}

		private string GetUnsubscribeMacroAlias(IEnumerable<MacrosInfo> macrosCollection) {
			var unsubMacro = macrosCollection.FirstOrDefault(
				macro => macro.Id == MailingConsts.EmailTemplateMacrosUnsubscribeUrlId);
			var unsubAlias = string.Empty;
			if (unsubMacro != null) {
				unsubAlias = string.Format(_cesMacroPattern, unsubMacro.Alias);
			}
			return unsubAlias;
		}

		private void FixInvalidUnsubMacros(IEnumerable<MacrosInfo> macrosCollection, StringBuilder stringBuilder) {
			var unsubMacro = GetUnsubscribeMacroAlias(macrosCollection);
			if (string.IsNullOrEmpty(unsubMacro)) {
				return;
			}
			var invalidUnsubscribeMacros = _invalidUnsubscribeUrlPrefix
				.Select(self => string.Concat(self, unsubMacro)).ToArray();
			foreach (var invalidMacro in invalidUnsubscribeMacros) {
				stringBuilder.Replace(invalidMacro, unsubMacro);
			}
		}

		private void ReplaceUsnsubscribeMacros(IEnumerable<MacrosInfo> macrosCollection, StringBuilder stringBuilder) {
			var unsubscribeMacroAlias = GetUnsubscribeMacroAlias(macrosCollection);
			if(string.IsNullOrEmpty(unsubscribeMacroAlias)) {
				return;
			}
			stringBuilder.Replace(unsubscribeMacroAlias, string.Format(_cesMacroPattern, _unsubscribeMacroName));
		}

		private IEnumerable<string> GetUrlElementsWithMacro(string src) {
			var hrefValues = MailingUtilities.ParseHtmlHrefValues(src);
			return hrefValues.Where(x => _macroNameRegex.IsMatch(x));
		}

		private List<MacrosInfo> GetUriEncodedMacrosCollection(List<MacrosInfo> macrosList, string src) {
			var anchorElements = GetUrlElementsWithMacro(src);
			var result = new Dictionary<string, MacrosInfo>();
			foreach (var macro in macrosList) {
				var macroProcessed = false;
				for (var i = 0; !macroProcessed && i < anchorElements.Count(); i++) {
					var anchorElemet = anchorElements.ElementAt(i);
					if (anchorElemet.Contains(macro.MacrosText) && !result.Keys.Contains(macro.Alias)) {
						var newMacro = new MacrosInfo(macro);
						newMacro.Alias = string.Format(_urlEncodedMacroPattern, newMacro.Alias);
						result[macro.Alias] = newMacro;
						macroProcessed = true;
					}
				}
			}
			return result.Values.ToList();
		}

		private void ReplaceMacroInUrlElemets(StringBuilder stringBuilder, IEnumerable<string> urlElements,
				string oldMacro, string newMacro) {
			var elementsToReplace = urlElements.Where(x => x.Contains(oldMacro));
			foreach (var urlElement in elementsToReplace) {
				var modifiedUrlElement = urlElement.Replace(oldMacro, newMacro);
				stringBuilder.Replace(urlElement, modifiedUrlElement);
			}
		}

		private void ReplaceBodyMacros(IEnumerable<MacrosInfo> textMacros, StringBuilder stringBuilder) {
			foreach (var macro in textMacros) {
				var newMacroText = string.Format(_cesMacroPattern, macro.Alias);
				stringBuilder.Replace(macro.MacrosText, newMacroText);
			}
		}

		private void ReplaceUrlMacros(IEnumerable<MacrosInfo> urlMacros, StringBuilder stringBuilder, string source) {
			var urlElements = GetUrlElementsWithMacro(source);
			foreach (var macro in urlMacros) {
				var newMacroText = string.Format(_cesMacroPattern, macro.Alias);
				ReplaceMacroInUrlElemets(stringBuilder, urlElements, macro.MacrosText, newMacroText);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Parses source text and returns collection of found macros.
		/// </summary>
		/// <param name="src">Source text.</param>
		/// <returns>Macroses.</returns>
		public virtual IEnumerable<MacrosInfo> GetMacrosCollection(string src) {
			var macrosList = _macrosHelper.GetMacrosCollection(src);
			InitMacrosCollection(macrosList);
			var uriEncodedMacrosList = GetUriEncodedMacrosCollection(macrosList, src);
			macrosList.InsertRange(0, uriEncodedMacrosList);
			return macrosList;
		}

		/// <summary>
		/// Replaces macros definition in source text on its alias.
		/// </summary>
		/// <param name="source">Source text.</param>
		/// <param name="allMacros">Collection of macros.</param>
		/// <returns>Processed text.</returns>
		public virtual string ReplaceMacros(string source, IEnumerable<MacrosInfo> allMacros) {
			var urlMacros = allMacros.Where(x => _urlEncodedMacroAliasRegex.IsMatch(x.Alias));
			var textMacros = allMacros.Except(urlMacros);
			var stringBuilder = new StringBuilder(source);
			ReplaceUrlMacros(urlMacros, stringBuilder, source);
			ReplaceBodyMacros(textMacros, stringBuilder);
			FixInvalidUnsubMacros(allMacros, stringBuilder);
			ReplaceUsnsubscribeMacros(allMacros, stringBuilder);
			return stringBuilder.ToString();
		}
		
		public string EncodeUrlMacrosValue(string macrosName, string macrosContent) {
			var resultContent = macrosContent;
			if (UrlEncodedMacrosAliasRegex.IsMatch(macrosName)) {
				resultContent = HttpUtility.UrlPathEncode(macrosContent);
			}
			return resultContent;
		}

		#endregion

	}

	#endregion
}
