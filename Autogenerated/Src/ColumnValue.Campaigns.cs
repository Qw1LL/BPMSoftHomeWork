namespace BPMSoft.Configuration.Campaigns
{
	using System;
	using BPMSoft.Core;

	#region Class: ColumnValue

	/// <summary>
	/// Contains information about value for entity column.
	/// </summary>
	public class ColumnValue
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier of entity column.
		/// </summary>
		public Guid ColumnUId { get; set; }

		/// <summary>
		/// Value of selected column.
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// Flag to indicate that value has macros.
		/// </summary>
		public bool HasMacrosValue { get; set; }

		/// <summary>
		/// <see cref="DataValueType"/> of entity column.
		/// </summary>
		public DataValueType DataValueType { get; set; }

		/// <summary>
		/// Checks whether column value data type is text.
		/// </summary>
		/// <returns>True when value data type is text.</returns>
		public bool IsTextColumn => DataValueType is TextDataValueType;

		/// <summary>
		/// Checks whether column value data type is DateTime.
		/// </summary>
		/// <returns>True when value data type is DateTime.</returns>
		public bool IsDateTimeColumn => DataValueType.IsDateTime;

		/// <summary>
		/// Checks whether column value data type is guid.
		/// </summary>
		/// <returns>True when value data type is guid.</returns>
		public bool IsGuidColumn => DataValueType.IsLookup
			|| DataValueType.IsMultiLookup
			|| DataValueType is GuidDataValueType;

		/// <summary>
		/// Checks whether column value data type is bool.
		/// </summary>
		/// <returns>True when value data type is bool.</returns>
		public bool IsBooleanColumn => DataValueType is BooleanDataValueType;

		#endregion

	}

	#endregion

}
