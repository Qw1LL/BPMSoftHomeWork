namespace BPMSoft.Configuration
{
	using System;

	#region Class: CampaignCrudObjectColumnValue

	/// <summary>
	/// Column value model that is used by campaign CRUD object elements.
	/// </summary>
	public class CampaignCrudObjectColumnValue
	{

		#region Methods: Public

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

		#endregion

	}

	#endregion

}

