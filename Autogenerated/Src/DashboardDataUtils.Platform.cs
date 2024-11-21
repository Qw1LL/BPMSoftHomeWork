namespace BPMSoft.Configuration
{

	using Core.Entities;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Common.Json;

	#region Class: DashboardDataUtils

	/// <summary>
	/// Provides utility methods for work with dashboards data.
	/// </summary>
	public static class DashboardDataUtils {

		#region Constants: Private

		private const char _columnKeySplitter = '#';

		#endregion

		/// <summary>
		/// Returns date part function interval by name.
		/// </summary>
		/// <param name="datePart">Part of date</param>
		/// <returns>Query function interval.</returns>
		public static EntitySchemaDatePartQueryFunctionInterval GetDatePartInterval(string datePart) {
			EntitySchemaDatePartQueryFunctionInterval interval;
			switch (datePart) {
				case "Day":
					interval = EntitySchemaDatePartQueryFunctionInterval.Day;
					break;
				case "Hour":
					interval = EntitySchemaDatePartQueryFunctionInterval.Hour;
					break;
				case "HourMinute":
					interval = EntitySchemaDatePartQueryFunctionInterval.HourMinute;
					break;
				case "Month":
					interval = EntitySchemaDatePartQueryFunctionInterval.Month;
					break;
				case "Week":
					interval = EntitySchemaDatePartQueryFunctionInterval.Week;
					break;
				case "Weekday":
					interval = EntitySchemaDatePartQueryFunctionInterval.Weekday;
					break;
				default:
					interval = EntitySchemaDatePartQueryFunctionInterval.Year;
					break;
			}
			return interval;
		}

		/// <summary>
		/// Gets column path without suffix.
		/// </summary>
		/// <param name="columnPath">Column path with suffix.</param>
		/// <returns>Column path without suffix.</returns>
		public static string ClearColumnPathSuffix(string columnPath) {
			return columnPath.Split(_columnKeySplitter)[0];
		}

		/// <summary>
		/// Gets column path from column config.
		/// </summary>
		/// <param name="columnItem">Column config.</param>
		/// <returns>Column path.</returns>
		public static string GetColumnPath(JObject columnItem) {
			string columnPath = columnItem.Value<string>("path");
			if (string.IsNullOrEmpty(columnPath)) {
				columnPath = columnItem.Value<string>("bindTo");
			}
			if (string.IsNullOrEmpty(columnPath)) {
				columnPath = columnItem.Value<string>("metaPath");
			}
			return columnPath;
		}

		/// <summary>
		/// Gets a column configuration object for displaying data.
		/// </summary>
		/// <param name="entitySchema">Schema of column.</param>
		/// <param name="columnPath">Column path.</param>
		/// <returns>Column config.</returns>
		public static JObject GetGridColumnConfig(EntitySchema entitySchema, string columnPath) {
			EntitySchemaColumn column = entitySchema.FindSchemaColumnByPath(columnPath);
			var data = new JObject();
			data.Add(new JProperty("caption", (string)column.Caption));
			data.Add(new JProperty("metaPath", columnPath));
			BPMSoft.Core.DataValueType columnValueType = column.DataValueType;
			data.Add(new JProperty("dataValueType", (int)Nui.ServiceModel.Extensions.DataValueTypeExtension.ToEnum(columnValueType)));
			if (column.ReferenceSchema != null) {
				data.Add(new JProperty("referenceSchemaName", column.ReferenceSchema.Name));
			}
			return data;
		}

	}

	#endregion
}

