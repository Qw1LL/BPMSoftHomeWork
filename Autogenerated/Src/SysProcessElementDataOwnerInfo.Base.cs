namespace BPMSoft.Configuration
{
	using System;

	#region Class: SysProcessElementDataOwnerInfo

	/// <summary>
	/// Stores information necessary to change owner of process element data.
	/// </summary>
	public class SysProcessElementDataOwnerInfo
	{

		#region Properties: Public

		/// <summary>
		/// Identifier of entity.
		/// </summary>
		public Guid EntityId { get; set; }

		/// <summary>
		/// Idenfitier of old process element data owner.
		/// </summary>
		public Guid OldOwnerId { get; set; }

		/// <summary>
		/// Idenfitier of new process element data owner.
		/// </summary>
		public Guid NewOwnerId { get; set; }

		#endregion

	}

	#endregion
	
}
