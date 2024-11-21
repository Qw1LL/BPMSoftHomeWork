namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: CampaignMacrosInterpreter

	/// <summary>
	/// Describes class to interpret macros and column values for campaign CRUD object elements.
	/// </summary>
	[Obsolete("7.14.1 | Use BPMSoft.Configuration.Campaigns.MacrosInterpreter instead")]
	public class CampaignMacrosInterpreter
	{

		#region Constants: Private

		private const string MacrosPattern = "[#{0}#]";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="CampaignMacrosInterpreter"/>.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		/// <param name="timeZoneOffset">Campaign time zone.</param>
		public CampaignMacrosInterpreter(UserConnection userConnection, TimeZoneInfo timeZoneOffset) {
			UserConnection = userConnection;
			_campaignTimeZoneOffset = timeZoneOffset;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Collection of predefined macros and func to invoke.
		/// </summary>
		/// <returns>Collection of type <see cref="Dictionary{Alias, FuncToInvoke}}"/>.</returns>
		protected virtual Dictionary<string, Func<object>> PredefinedMacrosToInterpret => 
			new Dictionary<string, Func<object>> {
				{ "[#Macros.DateTime.Now#]", GetDateTimeUtcNow }
			};

		#endregion

		#region Properties: Public

		/// <summary>
		/// Instance of <see cref="UserConnection"/>.
		/// </summary>
		public UserConnection UserConnection { get; }

		/// <summary>
		/// Campaign time zone of type <see cref="TimeZoneInfo"/>.
		/// </summary>
		private TimeZoneInfo _campaignTimeZoneOffset;
		public TimeZoneInfo CampaignTimeZoneOffset =>
			_campaignTimeZoneOffset ?? (_campaignTimeZoneOffset = TimeZoneInfo.Utc);

		/// <summary>
		/// Instance of <see cref="MacrosHelperV2"/>.
		/// </summary>
		private MacrosHelperV2 _macrosHelper;
		public virtual MacrosHelperV2 MacrosHelper {
			get => _macrosHelper ?? (_macrosHelper = GetMacrosHelper());
			set => _macrosHelper = value;
		}

		/// <summary>
		/// Instance of <see cref="MacrosHelperV2"/>.
		/// </summary>
		private CampaignEntitySchemaMacrosWorker _macrosWorker;
		public virtual CampaignEntitySchemaMacrosWorker MacrosWorker {
			get => _macrosWorker ?? (_macrosWorker = GetCampaignMacrosWorker());
			set => _macrosWorker = value;
		}

		#endregion

		#region Methods: Private

		private MacrosHelperV2 GetMacrosHelper() {
			_macrosHelper = ClassFactory.Get<MacrosHelperV2>();
			_macrosHelper.UserConnection = UserConnection;
			return _macrosHelper;
		}

		private CampaignEntitySchemaMacrosWorker GetCampaignMacrosWorker() {
			return new CampaignEntitySchemaMacrosWorker {
				UserConnection = UserConnection,
				UseAdminRights = true
			};
		}

		private Dictionary<string, MacrosInfo> GetMacrosCollection(
				IEnumerable<CampaignCrudObjectColumnValue> columnValues) {
			var macrosCollection = new Dictionary<string, MacrosInfo>();
			columnValues.ForEach(column => {
				if (column.Value != null) {
					AddColumnMacrosList(column, macrosCollection);
				}
			});
			return macrosCollection;
		}

		private void AddColumnMacrosList(CampaignCrudObjectColumnValue column,
				Dictionary<string, MacrosInfo> macrosCollection) {
			var sourceMacrosList = MacrosHelper.ExtractMacrosCollectionFromText(column.Value?.ToString());
			sourceMacrosList?.ForEach(x => {
				var alias = string.Format(MacrosPattern, x.Alias);
				if (!macrosCollection.ContainsKey(alias)) {
					x.Alias = alias;
					x.Id = CampaignConsts.CampaignEntitySchemaMacrosWorkerId;
					macrosCollection.Add(alias, x);
				}
			});
		}

		private void AddPredefinedMacrosValues(IEnumerable<MacrosInfo> macrosCollection,
				ref Dictionary<string, object> result) {
			var predefinedMacrosValues = GetPredefinedMacrosValues(macrosCollection);
			result.AddRangeIfNotExists(predefinedMacrosValues);
		}

		private Dictionary<string, object> GetPredefinedMacrosValues(IEnumerable<MacrosInfo> macrosCollection) {
			var result = new Dictionary<string, object>();
			macrosCollection
				.Where(x => PredefinedMacrosToInterpret.ContainsKey(x.Alias))
				.ForEach(macros => {
					var value = PredefinedMacrosToInterpret[macros.Alias].Invoke();
					result.Add(macros.Alias, value);
				});
			return result;
		}

		private void AddEntitySchemaMacrosValues(IEnumerable<MacrosInfo> macrosCollection,
				ref Dictionary<string, object> result, Guid contactId) {
			var entitySchemaMacrosValues = GetEntitySchemaMacrosValues(macrosCollection, contactId);
			result.AddRangeIfNotExists(entitySchemaMacrosValues);
		}

		private Dictionary<string, object> GetEntitySchemaMacrosValues(IEnumerable<MacrosInfo> macrosCollection,
				Guid contactId) {
			var entitySchemaMacrosCollection = macrosCollection
				.Where(x => !PredefinedMacrosToInterpret.ContainsKey(x.Alias));
			return MacrosWorker
				.GetMacrosValues(entitySchemaMacrosCollection, contactId)
				.ToDictionary(
					m => m.Key,
					n => n.Value.Value);
		}

		private object GetFormattedColumnValue(EntitySchemaColumn entityColumn,
				CampaignCrudObjectColumnValue columnValue, Dictionary<string, object> macrosValues) {
			if (entityColumn.DataValueType.IsDateTime) {
				return GetFirstDateTimeColumnValue(columnValue, macrosValues);
			}
			if (entityColumn.DataValueType.IsLookup
					|| entityColumn.DataValueType.IsMultiLookup
					|| entityColumn.DataValueType is GuidDataValueType) {
				return GetFirstGuidColumnValue(columnValue, macrosValues);
			}
			if (entityColumn.DataValueType is BooleanDataValueType) {
				return GetFirstBooleanColumnValue(columnValue, macrosValues);
			}
			return GetFirstStringColumnValue(columnValue, macrosValues);
		}

		private object GetFirstDateTimeColumnValue(CampaignCrudObjectColumnValue columnValue,
				Dictionary<string, object> macrosValues) {
			var value = columnValue.Value;
			if (macrosValues.Any()) {
				value = macrosValues.FirstOrDefault().Value;
			}
			return TryBoxDateTimeValue(value);
		}

		private object GetFirstGuidColumnValue(CampaignCrudObjectColumnValue columnValue,
				Dictionary<string, object> macrosValues) {
			var value = columnValue.Value;
			if (macrosValues.Any()) {
				value = macrosValues.FirstOrDefault().Value;
			}
			return TryBoxGuidValue(value);
		}

		private object GetFirstBooleanColumnValue(CampaignCrudObjectColumnValue columnValue,
				Dictionary<string, object> macrosValues) {
			var value = columnValue.Value;
			if (macrosValues.Any()) {
				value = macrosValues.FirstOrDefault().Value;
			}
			return TryBoxBooleanValue(value);
		}

		private string GetFirstStringColumnValue(CampaignCrudObjectColumnValue columnValue,
				Dictionary<string, object> macrosValues) {
			var value = columnValue.Value;
			if (macrosValues.Any()) {
				var stringBuilder = new StringBuilder(value?.ToString());
				macrosValues
					.ToDictionary(
						x => x.Key,
						y => GetStringValue(y.Value))
					.ForEach(macro => {
						stringBuilder.Replace(macro.Key, macro.Value);
					});
				return stringBuilder.ToString();
			}
			return GetStringValue(value);
		}

		private string GetStringValue(object value) {
			if (value == null || string.IsNullOrWhiteSpace(value?.ToString())) {
				return string.Empty;
			}
			if (value is DateTime dateTimeValue) {
				return $"{dateTimeValue.ToString("g", CultureInfo.InvariantCulture)} (UTC)";
			}
			return value.ToString();
		}

		private object TryBoxDateTimeValue(object value) {
			if (value is DateTime typedValue && typedValue != DateTime.MinValue) {
				return typedValue;
			}
			if (DateTime.TryParse(value?.ToString(), out var dateTimeValue)
					&& dateTimeValue != DateTime.MinValue) {
				return TimeZoneInfo.ConvertTimeToUtc(dateTimeValue, CampaignTimeZoneOffset);
			}
			return null;
		}

		private object TryBoxGuidValue(object value) {
			if (value is Guid typedValue && !Guid.Empty.Equals(typedValue)) {
				return typedValue;
			}
			if (Guid.TryParse(value?.ToString(), out var guidValue) && !Guid.Empty.Equals(guidValue)) {
				return guidValue;
			}
			return null;
		}

		private object TryBoxBooleanValue(object value) {
			if (value is bool typedValue) {
				return typedValue;
			}
			if (bool.TryParse(value?.ToString(), out var boolValue)) {
				return boolValue;
			}
			return null;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Predefined macro function to invoke.
		/// Returns UTC Date time on current moment.
		/// </summary>
		/// <returns>DateTime Utc now</returns>
		protected virtual object GetDateTimeUtcNow() => DateTime.UtcNow;

		/// <summary>
		/// Returns list of pairs {MacroAlias, MacroValue} for specified macros collection and contact id.
		/// </summary>
		/// <param name="macrosCollection">Collection of Macros.</param>
		/// <param name="contactId">Unique identifier for current campaign participant contact.</param>
		/// <returns>Macros values collection of type <see cref="Dictionary{Alias, Value}}"/>.</returns>
		protected Dictionary<string, object> GetMacrosValues(IEnumerable<MacrosInfo> macrosCollection,
				Guid contactId) {
			var macrosValues = new Dictionary<string, object>();
			AddPredefinedMacrosValues(macrosCollection, ref macrosValues);
			AddEntitySchemaMacrosValues(macrosCollection, ref macrosValues, contactId);
			return macrosValues;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Parses macros from column values and returns collection of macros values.
		/// </summary>
		/// <param name="columnValues">Collection of column values to interpret.</param>
		/// <param name="contactId">Current campaign participant contact unique identifier.</param>
		/// <returns>Macros values collection of type <see cref="Dictionary{Alias, Value}}"/>.</returns>
		public Dictionary<string, object> GetMacrosValues(IEnumerable<CampaignCrudObjectColumnValue> columnValues,
				Guid contactId) {
			var macrosCollection = GetMacrosCollection(columnValues);
			return GetMacrosValues(macrosCollection.Values, contactId);
		}

		/// <summary>
		/// Replaces all available column value macros with formatting for current column.
		/// If there is no macro - returns column formatted value.
		/// </summary>
		/// <param name="macrosValues"></param>
		/// <param name="entityColumn">Entity schema column.</param>
		/// <param name="columnValue">Column value model to process.</param>
		/// <returns>Formatted column value.</returns>
		public object InterpretColumnValue(ref Dictionary<string, object> macrosValues,
				EntitySchemaColumn entityColumn, CampaignCrudObjectColumnValue columnValue) {
			var columnMacrosValues = macrosValues
				.Where(x => columnValue.Value != null
					&& columnValue.Value.ToString().Contains(x.Key))
				.ToDictionary(x => x.Key, y => y.Value);
			return GetFormattedColumnValue(entityColumn, columnValue, columnMacrosValues);
		}

		#endregion

	}

	#endregion

}

