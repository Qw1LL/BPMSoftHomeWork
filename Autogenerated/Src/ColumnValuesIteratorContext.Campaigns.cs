namespace BPMSoft.Configuration.Campaigns
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core.Campaign;

	#region Class: ColumnValuesIteratorContext

	/// <summary>
	/// Context which contains input parameters for <see cref="ColumnValuesIterator"/> and results from each element.
	/// </summary>
	public class ColumnValuesIteratorContext
	{

		#region Properties: Public

		/// <summary>
		/// Campaign time zone.
		/// </summary>
		public TimeZoneInfo TimeZoneOffset { get; set; } = TimeZoneInfo.Utc;

		/// <summary>
		/// Collection of macros models.
		/// </summary>
		public List<MacroValueModel> MacrosValues { get; } = new List<MacroValueModel>();

		/// <summary>
		/// Collection of column values which will be inserted in entity.
		/// </summary>
		public List<ColumnValue> ColumnValues { get; } = new List<ColumnValue>();

		/// <summary>
		/// Collection of results for each entity column.
		/// </summary>
		public Dictionary<Guid, ColumnValueResult> Results { get; } = new Dictionary<Guid, ColumnValueResult>();

		#endregion

	}

	#endregion

}
