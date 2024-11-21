namespace BPMSoft.Configuration
{
	using System;

	#region Class: CampaignDeduplicatorRule

	/// <summary>
	/// Rule data model that is used by campaign deduplicator elements.
	/// </summary>
	public class CampaignDeduplicatorRule
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier of entity schema.
		/// </summary>
		public Guid EntitySchemaUId { get; set; }

		/// <summary>
		/// Path to column to find duplicates by.
		/// </summary>
		public string ColumnPath { get; set; }

		/// <summary>
		/// Name for the rule.
		/// </summary>
		public string Name { get; set; }

		#endregion

	}

	#endregion

}

