namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Web;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: RecipientMacroContract

	/// <summary>
	/// Data contract to get macro values for recipients from <see cref="MacroValuesDataSource"/>
	/// </summary>
	public class RecipientMacroContract
	{

		#region Properties: Public

		/// <summary>
		/// Recipient's contact identifier.
		/// </summary>
		public Guid ContactId { get; set; }

		/// <summary>
		/// Recipients linked entity for extended macros.
		/// </summary>
		public Guid LinkedEntityId { get; set; }

		/// <summary>
		/// Recipient's identifier.
		/// </summary>
		public Guid RecipientUId { get; set; }

		#endregion

	}
	
	#endregion
	
	#region Class: MacroValuesDataSource

	/// <summary>
	/// Provides methods to get macro values for mailing recipients.
	/// </summary>
	public class MacroValuesDataSource
	{

		/// <summary>
		/// Represents the internal config for generate macros for specified schema.
		/// </summary>
		private class MacroEntityConfig
		{
			/// <summary>Initializes a new instance of the <see cref="MacroEntityConfig" /> class.</summary>
			public MacroEntityConfig(string schemaName, Guid macrosParentId) {
				SchemaName = schemaName;
				MacrosParentId = macrosParentId;
			}

			/// <summary>
			/// Name of EntitySchema for macro generation.
			/// </summary>
			public string SchemaName { get; set; }

			/// <summary>
			/// Identifier of macro parent entity.
			/// </summary>
			public Guid MacrosParentId { get; set; }

		}

		#region Constants: Private

		private const string _personalMacrosSchema = "Contact";
		private const string _unsubscribeMacrosName = "UNSUB_URL";
		private const string _useDefaultUnsubscriptionMacrosName = "USE_DEFAULT_UNSUB";
		private const string BulkEmailRecipientIdName = BulkEmailHyperlinkHelper.BulkEmailRecipientIdName;
		private const string ContactIdMacrosName = BulkEmailHyperlinkHelper.ContactIdMacrosName;
		private const double MaxParametersCountPerQueryBatch = 1000;

		#endregion

		#region Fields: Private

		private readonly string _linkedEntitySchemaName;
		private readonly UserConnection _userConnection;
		private MacrosHelperV2 _macrosHelper;
		private Dictionary<string, string> _trackedAliases;

		#endregion

		#region Class: MacrosValuesData

		private class MacrosValuesData
		{

			#region Properties: Public

			public Dictionary<object, Dictionary<string, string>> ContactMacrosValues { get; set; }

			public Dictionary<object, Dictionary<string, string>> LinkedEntityMacrosValues { get; set; }

			public Dictionary<string, string> GlobalMacrosValues { get; set; }

			#endregion

		}

		#endregion

		private static readonly Regex UrlEncodedMacrosAliasRegex = new Regex("^Url.*$");

		#region Constructors: Public

		public MacroValuesDataSource(UserConnection userConnection, string linkedEntitySchemaName) {
			_userConnection = userConnection;
			_linkedEntitySchemaName = linkedEntitySchemaName;
		}

		#endregion

		#region Properties: Public

		public virtual MacrosHelperV2 MacrosHelper {
			get => _macrosHelper ?? (_macrosHelper = InitMacrosHelper());
			set {
				_macrosHelper = value;
				_macrosHelper.UserConnection = _userConnection;
			}
		}

		private MacrosHelperV2 InitMacrosHelper() {
			var macrosHelper = ClassFactory.Get<MacrosHelperV2>();
			macrosHelper.UserConnection = _userConnection;
			return macrosHelper;
		}

		public Dictionary<string, string> TrackedAliases {
			get => _trackedAliases ?? (_trackedAliases = new Dictionary<string, string>());
			set => _trackedAliases = value;
		}

		#endregion

		#region Methods: Private

		private static void ConcatenateSafely<TKey,TValue>(Dictionary<TKey,TValue> first,
			Dictionary<TKey,TValue> second) {
			foreach (var keyValuePair in second) {
				first[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		private Dictionary<Guid, object> CreateMacrosWorkerParameters(Guid macroGroupKey, string schemaName,
			IEnumerable<Guid> keys) {
			var result = new Dictionary<Guid, object>();
			Query recordsSelect = new Select(_userConnection).Column("Id").From(schemaName).Where("Id")
				.In(Column.Parameters(keys));
			var argValue = new Dictionary<string, object> {
				{ "SubSelect", recordsSelect },
				{ "JoinColumnName", "Id" },
				{ "SchemaName", schemaName }
			};
			result.Add(Guid.Empty, argValue);
			result.Add(macroGroupKey, argValue);
			return result;
		}

		private string EncodeUrlLikeMacro(string macrosName, string macrosContent) {
			if (UrlEncodedMacrosAliasRegex.IsMatch(macrosName)) {
				macrosContent = HttpUtility.UrlPathEncode(macrosContent);
			}
			return macrosContent;
		}

		private IEnumerable<KeyValuePair<string, string>> GetBulkEmailMacrosValues(
			IEnumerable<MacrosInfo> macrosCollection, Guid bulkEmailId) {
			var workersParameters = new Dictionary<Guid, object> {
				{ Guid.Empty, new KeyValuePair<string, Guid>("BulkEmail", bulkEmailId) }
			};
			return GetGlobalMacrosValues(macrosCollection, workersParameters);
		}

		private Dictionary<string, string> GetGlobalMacrosValues(IEnumerable<MacrosInfo> macrosCollection,
			Dictionary<Guid, object> arguments) {
			var result = new Dictionary<string, string>();
			var macros = macrosCollection.Where(m => m.IsGlobal && arguments.ContainsKey(m.ParentId));
			if (!macros.Any()) {
				return result;
			}
			result = MacrosHelper.GetMacrosValues(macros, arguments);
			return result;
		}

		private Dictionary<Guid, IEnumerable<BulkEmailMacroInfo>> GetRecipientMacrosValues(
			IEnumerable<RecipientMacroContract> recipientsIds, IEnumerable<MacrosInfo> macrosCollection,
			MacrosValuesData macrosValuesData) {
			var result = new Dictionary<Guid, IEnumerable<BulkEmailMacroInfo>>();
			foreach (RecipientMacroContract recipient in recipientsIds) {
				var recipientMacrosValues = new Dictionary<string, string>();
				if (macrosValuesData.LinkedEntityMacrosValues.ContainsKey(recipient.LinkedEntityId)) {
					recipientMacrosValues = macrosValuesData.LinkedEntityMacrosValues[recipient.LinkedEntityId];
				}
				if (macrosValuesData.ContactMacrosValues.ContainsKey(recipient.ContactId)) {
					ConcatenateSafely(recipientMacrosValues,
						macrosValuesData.ContactMacrosValues[recipient.ContactId]);
				}
				recipientMacrosValues[ContactIdMacrosName] = recipient.ContactId.ToString();
				recipientMacrosValues[BulkEmailRecipientIdName] = recipient.RecipientUId.ToString();
				ConcatenateSafely(recipientMacrosValues, macrosValuesData.GlobalMacrosValues);
				SetTrackedRecipientMacrosValues(recipientMacrosValues);
				var allMacrosValues =
					recipientMacrosValues.Select(kvp => PrepareMacroValue(kvp.Key, kvp.Value, macrosCollection));
				result[recipient.RecipientUId] = allMacrosValues;
			}
			return result;
		}

		private IEnumerable<KeyValuePair<string, string>> GetSenderMacrosValues(
			IEnumerable<MacrosInfo> macrosCollection, Guid globalMacrosContactId) {
			return GetGlobalMacrosValues(macrosCollection, new Dictionary<Guid, object> {
				{ MailingConsts.EmailTemplateMacrosParentGlobalId, globalMacrosContactId }
			});
		}

		private KeyValuePair<string, string> GetUnsubscribeMacrosValue() {
			var unsubscribeLink = (string)CoreSysSettings.GetValue(_userConnection, "RedirectUnsuscribersTo");
			return new KeyValuePair<string, string>(_unsubscribeMacrosName, unsubscribeLink);
		}

		private IEnumerable<KeyValuePair<string, string>> GetUnsubscribeMacrosValues() {
			var unsubDictionary = new Dictionary<string, string>();
			var unsubMacrosValue = GetUnsubscribeMacrosValue();
			var unsubFromAllMailingsMacrosValue = GetUseDefaultUnsubscriptionMacrosValue();
			unsubDictionary.Add(unsubMacrosValue.Key, unsubMacrosValue.Value);
			unsubDictionary.Add(unsubFromAllMailingsMacrosValue.Key, unsubFromAllMailingsMacrosValue.Value);
			return unsubDictionary;
		}

		private KeyValuePair<string, string> GetUseDefaultUnsubscriptionMacrosValue() {
			var unsubFromAllMailings =
				CoreSysSettings.GetValue(_userConnection, "UnsubscribeFromAllMailings").ToString();
			return new KeyValuePair<string, string>(_useDefaultUnsubscriptionMacrosName, unsubFromAllMailings);
		}

		private BulkEmailMacroInfo PrepareMacroValue(string macroAlias, string value,
			IEnumerable<MacrosInfo> macrosCollection) {
			MacrosInfo macro = macrosCollection.FirstOrDefault(x => x.Alias == macroAlias);
			return new BulkEmailMacroInfo {
				Alias = macro?.Alias ?? macroAlias,
				Value = EncodeUrlLikeMacro(macroAlias, value),
				MacroText = macro?.MacrosText ?? macroAlias
			};
		}

		private Dictionary<object, Dictionary<string, string>> GetMacrosValuesCollectionByContactsBatch(IEnumerable<MacrosInfo> macrosCollection,
			IEnumerable<Guid> recipientsIds, MacroEntityConfig config) {
			var arguments = CreateMacrosWorkerParameters(config.MacrosParentId,
				config.SchemaName, recipientsIds);
			return MacrosHelper.GetMacrosValuesCollection(macrosCollection, arguments);
		}
		
		private Dictionary<object, Dictionary<string, string>> ReadMacrosValues(Guid[] recipientsIds,
			IEnumerable<MacrosInfo> macrosCollection, MacroEntityConfig config) {
			var batchesCount = (int)Math.Ceiling(recipientsIds.Length / MaxParametersCountPerQueryBatch);
			var recipientsIdsBatches = recipientsIds.SplitOnParts(batchesCount);
			var resultDictionary = new Dictionary<object, Dictionary<string, string>>();
			foreach (var recipientsIdsBatch in recipientsIdsBatches) {
				var macroValuesForBatch =
					GetMacrosValuesCollectionByContactsBatch(macrosCollection, recipientsIdsBatch, config);
				ConcatenateSafely(resultDictionary, macroValuesForBatch);
			}
			return resultDictionary;
		}

		private Dictionary<object, Dictionary<string, string>> ReadContactEntityMacrosValues(
			IEnumerable<RecipientMacroContract> recipientsIds, IEnumerable<MacrosInfo> macrosCollection) {
			var contactIds = recipientsIds.Select(r => r.ContactId).Distinct().ToArray();
			var contactMacros =
				macrosCollection.Where(m => !m.IsGlobal && m.ParentId == MailingConsts.EmailTemplateMacrosParentContactId);
			var macroConfig =
				new MacroEntityConfig(_personalMacrosSchema, MailingConsts.EmailTemplateMacrosParentContactId);
			return ReadMacrosValues(contactIds, contactMacros, macroConfig);
		}

		private Dictionary<object, Dictionary<string, string>> ReadLinkedEntityMacrosValues(
			IEnumerable<RecipientMacroContract> recipientsIds, IEnumerable<MacrosInfo> macrosCollection) {
			if (string.IsNullOrEmpty(_linkedEntitySchemaName) || _linkedEntitySchemaName == "Contact") {
				return new Dictionary<object, Dictionary<string, string>>();
			}
			var linkedEntityIds = recipientsIds.Select(r => r.LinkedEntityId).Distinct().ToArray();
			var linkedMacros =
				macrosCollection.Where(m => !m.IsGlobal && m.ParentId == MailingConsts.EmailTemplateMacrosParentEntityId);
			var macroConfig =
				new MacroEntityConfig(_linkedEntitySchemaName, MailingConsts.EmailTemplateMacrosParentEntityId);
			return ReadMacrosValues(linkedEntityIds, linkedMacros, macroConfig);
		}

		private void SetTrackedRecipientMacrosValues(Dictionary<string, string> macroValues) {
			foreach (var trackedItem in TrackedAliases) {
				if (macroValues.TryGetValue(trackedItem.Value, out string macroValue)) {
					macroValues[trackedItem.Key] = macroValue;
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get values of global macros.
		/// </summary>
		/// <param name="bulkEmailId">Email identifier.</param>
		/// <param name="globalContactId">Sender contact identifier.</param>
		/// <param name="macrosCollection">Email's macros collection.</param>
		/// <returns>Dictionary with macro name and its value</returns>
		public Dictionary<string, string> GetGlobalMacrosValues(Guid bulkEmailId, Guid globalContactId,
			IEnumerable<MacrosInfo> macrosCollection) {
			var globalMacrosValues = new Dictionary<string, string>();
			var senderMacrosValues = GetSenderMacrosValues(macrosCollection, globalContactId);
			globalMacrosValues.AddRange(senderMacrosValues);
			var bulkEmailMacrosValues = GetBulkEmailMacrosValues(macrosCollection, bulkEmailId);
			globalMacrosValues.AddRange(bulkEmailMacrosValues);
			var unsubscribeMacrosValues = GetUnsubscribeMacrosValues();
			globalMacrosValues.AddRange(unsubscribeMacrosValues);
			return globalMacrosValues;
		}

		/// <summary>
		/// Gets collection of macros with values for given batch of recipents.
		/// </summary>
		/// <param name="recipientsIds">Collection of recipients identifiers - <see cref="RecipientMacroContract"/>.</param>
		/// <param name="globalMacros">Global macros and values</param>
		/// <param name="macrosCollection"></param>
		/// <returns>Dictionary with recipient's UId as key, and collection of <see cref="BulkEmailMacroInfo"/> as value.</returns>
		public Dictionary<Guid, IEnumerable<BulkEmailMacroInfo>> GetMacroValues(
			IEnumerable<RecipientMacroContract> recipientsIds, Dictionary<string, string> globalMacros,
			IEnumerable<MacrosInfo> macrosCollection) {
			var macrosValuesData = new MacrosValuesData {
				ContactMacrosValues = ReadContactEntityMacrosValues(recipientsIds, macrosCollection),
				LinkedEntityMacrosValues = ReadLinkedEntityMacrosValues(recipientsIds, macrosCollection),
				GlobalMacrosValues = globalMacros
			};
			return GetRecipientMacrosValues(recipientsIds, macrosCollection, macrosValuesData);
		}

		#endregion

	}

	#endregion

}

