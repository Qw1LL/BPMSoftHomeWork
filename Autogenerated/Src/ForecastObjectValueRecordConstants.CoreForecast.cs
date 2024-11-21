 namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;

	#region Class: ForecastHistoryRowConstants

	/// <summary>
	/// Provides forecast object value record constants.
	/// </summary>
	public static class ForecastObjectValueRecordConstants
	{
		public const string RefEntityColumnName = "RefEntityId";
		public const string PeriodColumnName = "PeriodId";
		public const string ColumnColumnName = "ColumnId";
		public const string FuncColumnNameAlias = "FuncColumn";
		public const string EntityIdColumnName = "EntityId";
		public const string DeletedOnColumnName = "DeletedOn";
		public const string DisplayValueColumnName = "EntityDisplayValue";
		public const string ValueColumnName = "Value";
		public const string SnapshotColumnName = "SnapshotId";
		public const string ForecastObjValueRecordSchemaName = "ForecastObjValueRecord";
		public const string ForecastHistoryObjValueRecordSchemaName = "ForecastHistDrilldown";
		public const string ForecastSnapshotSchemaName  = "ForecastSnapshot";
		public const string ForecastObjValueRecordSchemaAlias = "fovr";
		public const string ForecastCellEntitySchemaAlias = "fce";
	}

	#endregion

	#region Class: ObjectValueRecord

	/// <summary>
	/// Provides properties for object value record data.
	/// </summary>
	[DataContract]
	public class ObjectValueRecord
	{

		/// <summary>
		/// Gets or sets the unique identifier.
		/// </summary>
		/// <value>
		/// The unique identifier.
		/// </value>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the display value.
		/// </summary>
		/// <value>
		/// The display value.
		/// </value>
		[DataMember(Name = "displayValue")]
		public string DisplayValue { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		[DataMember(Name = "value")]
		public decimal Value { get; set; }

		/// <summary>
		/// Gets or sets the period.
		/// </summary>
		/// <value>
		/// The period identifier.
		/// </value>
		[DataMember(Name = "periodId")]
		public Guid PeriodId { get; set; }

		/// <summary>
		/// Gets or sets the column.
		/// </summary>
		/// <value>
		/// The column identifier.
		/// </value>
		[DataMember(Name = "columnId")]
		public Guid ColumnId { get; set; }

		/// <summary>
		/// Gets or sets the reference entity identifier.
		/// </summary>
		/// <value>
		/// The reference entity identifier.
		/// </value>
		[DataMember(Name = "refEntityId")]
		public Guid RefEntityId { get; set; }

		/// <summary>
		/// Gets or sets the entity identifier.
		/// </summary>
		/// <value>
		/// The entity identifier.
		/// </value>
		[DataMember(Name = "entityId")]
		public Guid EntityId { get; set; }

		/// <summary>
		/// Gets or sets the deleted on date and time.
		/// </summary>
		/// <value>
		/// The deleted on date and time.
		/// </value>
		public DateTime DeletedOn { get; set; }
	}

	#endregion
}

