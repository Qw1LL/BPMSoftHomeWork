namespace BPMSoft.Configuration
{
	using System;
	
	#region Class: CampaignInfo

	/// <summary>
	/// Class that represents lightweight campaign state info model.
	/// </summary>
	public class CampaignInfo
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier of campaign entity.
		/// </summary>
		public Guid CampaignId { get; set; }

		/// <summary>
		/// Unique identifier of campaign status.
		/// </summary>
		public Guid CampaignStatusId { get; set; }

		/// <summary>
		/// Flag that indicates campaign progress state.
		/// </summary>
		public bool InProgress { get; set; }

		/// <summary>
		/// Unique identifier of the paricipant linked entity schema.
		/// </summary>
		public Guid EntitySchemaUId { get; set; }

		#endregion

	}

	#endregion
	
}

