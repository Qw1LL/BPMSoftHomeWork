namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Campaigns;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: CampaignEntitySchemaMacrosWorker

	/// <summary>
	/// Describes campaign macros worker to get macros values for entity schema macros.
	/// </summary>
	[MacrosWorker("{64CFA82A-4C12-4D13-8CE7-0E5831E75670}")]
	public class CampaignEntitySchemaMacrosWorker : BaseEntityMacrosWorker
	{

		#region Methods: Private

		private object FormatSourceValue(EntityColumnValue columnValue) {
			if (columnValue.Column.DataValueType is DateTimeDataValueType dateTimeType) {
				return FormatDateTimeValue(columnValue.Value, dateTimeType.Kind);
			}
			return columnValue.Value;
		}

		private object FormatDateTimeValue(object value, DateTimeValueKind kind) {
			var dateTimeValue = value is TimeSpan
				? new DateTime(((TimeSpan)value).Ticks)
				: (DateTime)value;
			switch (kind) {
				case DateTimeValueKind.Date:
					return dateTimeValue.Date;
				case DateTimeValueKind.DateTime:
					var curentUserTimeZone = UserConnection.CurrentUser.TimeZone ?? TimeZoneInfo.Utc;
					return TimeZoneInfo.ConvertTimeToUtc(dateTimeValue, curentUserTimeZone);
				case DateTimeValueKind.Time:
				default:
					return dateTimeValue;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns macros values collection.
		/// </summary>
		/// <param name="macrosCollection">Collection of <see cref="MacrosInfo"/>.</param>
		/// <param name="arguments">Proceed arguments.</param>
		/// <param name="withFormatting">Flag to apply formatting.</param>
		/// <returns>Collection of type <see cref="Dictionary{Alias, TypedValueModel}"/>.</returns>
		public virtual Dictionary<string, TypedValueModel> GetMacrosValues(IEnumerable<MacrosInfo> macrosCollection,
				object arguments, bool withFormatting) {
			var macrosValues = InternalProceed(macrosCollection, arguments);
			if (withFormatting) {
				macrosValues?.ForEach(x => {
					x.Value.Value = FormatSourceValue(x.Value);
				});
			}
			return macrosValues?.ToDictionary(
					x => x.Key,
					y => new TypedValueModel {
						Value = y.Value.Value,
						Type = y.Value.Column.DataValueType
					})
				?? new Dictionary<string, TypedValueModel>();
		}

		/// <summary>
		/// Returns macros values collection with formatting.
		/// </summary>
		/// <param name="macrosCollection">Collection of <see cref="MacrosInfo"/>.</param>
		/// <param name="arguments">Proceed arguments.</param>
		/// <returns>Collection of type <see cref="Dictionary{Alias, TypedValueModel}"/>.</returns>
		public virtual Dictionary<string, TypedValueModel> GetMacrosValues(IEnumerable<MacrosInfo> macrosCollection,
				object arguments) => GetMacrosValues(macrosCollection, arguments, true);

		#endregion

	}

	#endregion

}

