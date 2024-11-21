namespace BPMSoft.Configuration.Campaigns
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: MacrosInterpreter

	/// <summary>
	/// Describes class to interpret macros for campaigns.
	/// Gets column values, finds macros, interprets predefined macros,
	/// interprets entityschema macros and returns aggregated collection of macro value models.
	/// Contains custom predefined macros collection to override.
	/// Contains methods to customize format of string macro values.
	/// </summary>
	public class MacrosInterpreter
	{

		#region Constants: Private

		private const string MacrosPattern = "[#{0}#]";
		private const string DigitPattern = @"(\d)+";
		private const string DateTimeMacroPattern = @"\[#Macros\.DateTime\.(CurrentDate|\d+DaysAfter|\d+DaysBefore)" +
			@"@(CurrentTime|\d+HoursAfter|\d+HoursBefore|(2[0123]|[01]\d|\d):[0-5]\d)#\]";
		private const string DateMacroPattern = @"\[#Macros\.Date\.(CurrentDate|\d+DaysAfter|\d+DaysBefore)#\]";
		private const string TimeMacroPattern = @"\[#Macros\.Time\.(CurrentTime|\d+HoursAfter|\d+HoursBefore)#\]";
		private const string ExactTimeMacroPattern = @"(2[0123]|[01]\d|\d):([0-5]\d)\b";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="MacrosInterpreter"/>.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		public MacrosInterpreter(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Collection of predefined macros and func to invoke.
		/// </summary>
		/// <returns>Collection of type <see cref="Dictionary{Alias, FuncToInvoke}}"/>.</returns>
		private Dictionary<string, Func<string, MacroValueModel>> PredefinedMacrosToInterpret => 
			new Dictionary<string, Func<string, MacroValueModel>> {
				{ DateTimeMacroPattern, GetPredefinedDateTimeValue },
				{ DateMacroPattern, GetPredefinedDateValue },
				{ TimeMacroPattern, GetPredefinedTimeValue }
			};

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Collection of custom predefined macros and func to invoke.
		/// </summary>
		/// <returns>Collection of type <see cref="Dictionary{Alias, FuncToInvoke}}"/>.</returns>
		protected virtual Dictionary<string, Func<string, MacroValueModel>> CustomPredefinedMacrosToInterpret =>
			new Dictionary<string, Func<string, MacroValueModel>> { };

		#endregion

		#region Properties: Public

		/// <summary>
		/// Instance of <see cref="UserConnection"/>.
		/// </summary>
		public UserConnection UserConnection { get; }

		/// <summary>
		/// Campaign time zone of type <see cref="TimeZoneInfo"/>.
		/// Uses for correct macros interpretation of DateTime column values to save its in DB (UTC).
		/// </summary>
		private TimeZoneInfo _timeZoneOffset;
		public TimeZoneInfo TimeZoneOffset {
			get => _timeZoneOffset ?? (_timeZoneOffset = TimeZoneInfo.Utc);
			set => _timeZoneOffset = value;
		}

		/// <summary>
		/// Instance of <see cref="MacrosHelperV2"/>.
		/// </summary>
		private MacrosHelperV2 _macrosHelper;
		public virtual MacrosHelperV2 MacrosHelper {
			get => _macrosHelper ?? (_macrosHelper = GetMacrosHelper());
			set => _macrosHelper = value;
		}

		/// <summary>
		/// Instance of <see cref="CampaignEntitySchemaMacrosWorker"/> to interpret entity schema macros.
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

		private IEnumerable<MacrosInfo> GetMacrosCollection(IEnumerable<ColumnValue> columnValues) {
			var macrosCollection = new Collection<MacrosInfo>();
			columnValues.ForEach(column => {
				if (column.Value != null) {
					AddColumnMacrosList(ref column, macrosCollection);
				}
			});
			return macrosCollection;
		}

		private void AddColumnMacrosList(ref ColumnValue column,
				Collection<MacrosInfo> macrosCollection) {
			var sourceMacrosList = MacrosHelper.ExtractMacrosCollectionFromText(column.Value?.ToString());
			column.HasMacrosValue = sourceMacrosList != null && sourceMacrosList.Any();
			sourceMacrosList?.ForEach(x => {
				var alias = string.Format(MacrosPattern, x.Alias);
				if (!macrosCollection.Any(m => m.Alias.Equals(alias))) {
					x.Alias = alias;
					macrosCollection.Add(x);
				}
			});
		}

		private IEnumerable<MacroValueModel> InterpretMacrosValues(ref IEnumerable<MacrosInfo> macrosCollection,
				Guid contactId) {
			var macrosValues = new Collection<MacroValueModel>();
			AddCustomPredefinedMacrosValues(ref macrosCollection, ref macrosValues);
			AddPredefinedMacrosValues(ref macrosCollection, ref macrosValues);
			AddEntitySchemaMacrosValues(ref macrosCollection, ref macrosValues, contactId);
			return macrosValues;
		}

		private void AddCustomPredefinedMacrosValues(ref IEnumerable<MacrosInfo> macrosCollection,
				ref Collection<MacroValueModel> result) {
			var customMacrosValues = GetPredefinedMacrosValues(macrosCollection,
				CustomPredefinedMacrosToInterpret);
			result.AddRangeIfNotExists(customMacrosValues);
		}

		private void AddPredefinedMacrosValues(ref IEnumerable<MacrosInfo> macrosCollection,
				ref Collection<MacroValueModel> result) {
			var macrosToInterpret = GetMacrosToInterpret(ref macrosCollection, ref result);
			var predefinedMacrosValues = GetPredefinedMacrosValues(macrosToInterpret, PredefinedMacrosToInterpret);
			result.AddRangeIfNotExists(predefinedMacrosValues);
		}

		private IEnumerable<MacroValueModel> GetPredefinedMacrosValues(IEnumerable<MacrosInfo> macrosCollection,
				Dictionary<string, Func<string, MacroValueModel>> patternsToInterpret) {
			var result = new List<MacroValueModel>();
			macrosCollection
				.ForEach(macro => {
					foreach (var pattern in patternsToInterpret) {
						var regex = new Regex(pattern.Key);
						if (!regex.IsMatch(macro.Alias)) {
							continue;
						}
						var macroValue = pattern.Value.Invoke(macro.Alias);
						if (!result.Any(x => x.Alias.Equals(macro.Alias))) {
							result.Add(macroValue);
						}
						break;
					}
				});
			return result;
		}

		private void AddEntitySchemaMacrosValues(ref IEnumerable<MacrosInfo> macrosCollection,
				ref Collection<MacroValueModel> result, Guid contactId) {
			var macrosToInterpret = GetMacrosToInterpret(ref macrosCollection, ref result);
			var entitySchemaMacrosValues = MacrosWorker.GetMacrosValues(macrosToInterpret, contactId);
			var macrosValueModels = entitySchemaMacrosValues
				.Select(x => CreateMacroValueModel(x.Key, x.Value));
			result.AddRangeIfNotExists(macrosValueModels);
		}

		private IEnumerable<MacrosInfo> GetMacrosToInterpret(ref IEnumerable<MacrosInfo> macrosCollection,
				ref Collection<MacroValueModel> result) {
			var interpretedMacros = result.Select(x => x.Alias);
			return macrosCollection.Where(x => !interpretedMacros.Contains(x.Alias));
		}

		private TimeSpan GetOffsetDifference(DateTime start, DateTime end) {
			var startOffset = TimeZoneOffset.GetUtcOffset(start);
			var endOffset = TimeZoneOffset.GetUtcOffset(end);
			return endOffset - startOffset;
		}

		private MacroValueModel GetPredefinedDateTimeValue(string macroText) {
			var sourceDateTimeValue = GetCampaignDateTimeNow();
			var resultDateTimeValue = sourceDateTimeValue;
			var regex = new Regex(DateTimeMacroPattern);
			var match = regex.Match(macroText);
			ApplyDateCondition(ref resultDateTimeValue, match.Groups[1].Value);
			var timeModified = ApplyTimeCondition(ref resultDateTimeValue, match.Groups[2].Value);
			if (timeModified) {
				var offsetDifference = GetOffsetDifference(sourceDateTimeValue, resultDateTimeValue);
				resultDateTimeValue = resultDateTimeValue.Add(offsetDifference);
			}
			var stringValue = GetMacrosDateTimeStringValue(resultDateTimeValue, DateTimeValueKind.DateTime);
			var utcDateTimeValue = TimeZoneInfo.ConvertTimeToUtc(resultDateTimeValue, TimeZoneOffset);
			return CreateMacroValueModel(macroText, utcDateTimeValue, stringValue);
		}

		private MacroValueModel GetPredefinedDateValue(string macroText) {
			var dateValue = GetCampaignDateTimeNow().Date;
			var regex = new Regex(DateMacroPattern);
			var match = regex.Match(macroText);
			ApplyDateCondition(ref dateValue, match.Groups[1].Value);
			var stringValue = GetDateStringValue(dateValue);
			return CreateMacroValueModel(macroText, dateValue, stringValue);
		}

		private MacroValueModel GetPredefinedTimeValue(string macroText) {
			var sourceDateTimeValue = GetCampaignDateTimeNow();
			var resultDateTimeValue = sourceDateTimeValue;
			var regex = new Regex(TimeMacroPattern);
			var match = regex.Match(macroText);
			var timeModified = ApplyTimeCondition(ref resultDateTimeValue, match.Groups[1].Value);
			if (timeModified) {
				var offsetDifference = GetOffsetDifference(sourceDateTimeValue, resultDateTimeValue);
				resultDateTimeValue = resultDateTimeValue.Add(offsetDifference);
			}
			var stringValue = GetTimeStringValue(resultDateTimeValue);
			return CreateMacroValueModel(macroText, resultDateTimeValue, stringValue);
		}

		private void ApplyDateCondition(ref DateTime value, string dateCapture) {
			if (dateCapture.Equals("CurrentDate")) {
				return;
			}
			var digit = ExtractFirstDigitFromText(dateCapture);
			if (dateCapture.EndsWith("DaysAfter")) {
				value = value.AddDays(digit);
				return;
			}
			if (dateCapture.EndsWith("DaysBefore")) {
				value = value.AddDays(-digit);
			}
		}

		private bool ApplyTimeCondition(ref DateTime value, string timeCapture) {
			if (timeCapture.Equals("CurrentTime")) {
				return false;
			}
			var exactTimeRegex = new Regex(ExactTimeMacroPattern);
			if (exactTimeRegex.IsMatch(timeCapture)) {
				ApplyExactTimePattern(ref value, timeCapture);
				return false;
			}
			var digit = ExtractFirstDigitFromText(timeCapture);
			if (timeCapture.EndsWith("HoursAfter")) {
				value = value.AddHours(digit);
			} else if (timeCapture.EndsWith("HoursBefore")) {
				value = value.AddHours(-digit);
			}
			return true;
		}

		private DateTime GetCampaignDateTimeNow() {
			var dateTimeValue = DateTime.UtcNow;
			return TimeZoneInfo.ConvertTimeFromUtc(dateTimeValue, TimeZoneOffset);
		}

		private void ApplyExactTimePattern(ref DateTime value, string timeCapture) {
			var regex = new Regex(ExactTimeMacroPattern);
			var match = regex.Match(timeCapture);
			var hours = int.Parse(match.Groups[1].Value);
			var minutes = int.Parse(match.Groups[2].Value);
			value = value.Date.AddHours(hours).AddMinutes(minutes);
		}

		private int ExtractFirstDigitFromText(string text) {
			var digitRegExp = new Regex(DigitPattern);
			var digitString = digitRegExp.Match(text).Value;
			return int.Parse(digitString);
		}

		private MacroValueModel CreateMacroValueModel(string macroAlias, TypedValueModel valueModel) {
			return new MacroValueModel {
				Alias = macroAlias,
				Value = valueModel.Value,
				StringValue = GetStringMacroValue(valueModel)
			};
		}

		private MacroValueModel CreateMacroValueModel(string macroAlias, object macroValue, string textValue) {
			return new MacroValueModel {
				Alias = macroAlias,
				Value = macroValue,
				StringValue = textValue
			};
		}

		private string GetTimeZoneOffsetText(DateTime value) {
			if (TimeZoneOffset.GetUtcOffset(value).Equals(TimeSpan.Zero)) {
				return TimeZoneInfo.Utc.DisplayName;
			}
			var startSymbol = TimeZoneOffset.GetUtcOffset(value) < TimeSpan.Zero ? "-" : "+";
			var offsetText = TimeZoneOffset.GetUtcOffset(value).ToString("hh\\:mm");
			return $"{startSymbol}{offsetText}";
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns string representation of boxed macro value.
		/// </summary>
		/// <param name="value">Boxed macro value to convert.</param>
		/// <returns>String representation of macro value.</returns>
		protected virtual string GetStringMacroValue(TypedValueModel valueModel) {
			if (valueModel.Value == null || string.IsNullOrWhiteSpace(valueModel.Value?.ToString())) {
				return string.Empty;
			}
			if (valueModel.Type is DateTimeDataValueType dateTimeType) {
				return GetMacrosDateTimeStringValue(valueModel.Value, dateTimeType.Kind);
			}
			return valueModel.Value.ToString();
		}

		/// <summary>
		/// Returns string representation of DateTime value.
		/// </summary>
		/// <param name="dateTimeValue">Typed DateTime value.</param>
		/// <returns>String representation of datetime value.</returns>
		protected virtual string GetMacrosDateTimeStringValue(object value, DateTimeValueKind kind) {
			var dateTimeValue = value is TimeSpan ? new DateTime(((TimeSpan)value).Ticks) : (DateTime)value;
			switch (kind) {
				case DateTimeValueKind.Date:
					return GetDateStringValue(dateTimeValue);
				case DateTimeValueKind.Time:
					return GetTimeStringValue(dateTimeValue);
				case DateTimeValueKind.DateTime:
					return GetDateTimeStringValue(dateTimeValue);
				default:
					return dateTimeValue.ToString();
			}
		}

		/// <summary>
		/// Returns date string representation of DateTime value.
		/// </summary>
		/// <param name="dateTimeValue">Typed DateTime value.</param>
		/// <returns>String representation of datetime value.</returns>
		protected virtual string GetDateStringValue(DateTime dateTimeValue) {
			return dateTimeValue.ToString("d", CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Returns time string representation of DateTime value.
		/// </summary>
		/// <param name="dateTimeValue">Typed DateTime value.</param>
		/// <returns>String representation of datetime value.</returns>
		protected virtual string GetTimeStringValue(DateTime dateTimeValue) {
			return dateTimeValue.ToString("t", CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Returns time string representation of DateTime value.
		/// </summary>
		/// <param name="dateTimeValue">Typed DateTime value.</param>
		/// <returns>String representation of datetime value.</returns>
		protected virtual string GetDateTimeStringValue(DateTime dateTimeValue) {
			var stringValue = dateTimeValue.ToString("g", CultureInfo.InvariantCulture);
			return $"{stringValue} ({GetTimeZoneOffsetText(dateTimeValue)})";
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Parses macros from column values and returns collection of macros values.
		/// </summary>
		/// <param name="columnValues">Collection of column values to interpret.</param>
		/// <param name="contactId">Current campaign participant contact unique identifier.</param>
		/// <returns>Macros values collection.</returns>
		public IEnumerable<MacroValueModel> GetMacrosValues(
				IEnumerable<ColumnValue> columnValues, Guid contactId) {
			var macrosCollection = GetMacrosCollection(columnValues);
			return InterpretMacrosValues(ref macrosCollection, contactId);
		}

		#endregion

	}

	#endregion

}

