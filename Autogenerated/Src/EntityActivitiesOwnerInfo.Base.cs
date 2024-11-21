namespace BPMSoft.Configuration
{
	using System;

	#region Class: EntityActivitiesOwnerInfo

	/// <summary>
	/// Stores information necessary to change owner of activity.
	/// </summary>
	public class EntityActivitiesOwnerInfo
	{

		#region Properties: Public

		/// <summary>
		/// Identifier of entity.
		/// </summary>
		public Guid EntityId { get; set; }

		/// <summary>
		/// Idenfitier of old activity owner.
		/// </summary>
		public Guid OldOwnerId { get; set; }

		/// <summary>
		/// Idenfitier of new activity owner.
		/// </summary>
		public Guid NewOwnerId { get; set; }

		/// <summary>
		/// Name of entity schema.
		/// </summary>
		public string EntitySchemaName { get; set; }

		#endregion

	}

	#endregion
	
}
