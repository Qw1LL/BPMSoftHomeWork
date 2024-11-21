namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Runtime.Serialization;

	#region Class: BulkEntityClientDuplicatesGroup

	[DataContract]
	public class BulkEntityClientDuplicatesGroup : EntityClientDuplicatesGroup
	{
		/// <summary>
		/// Identifier of group.
		/// </summary>
		[DataMember(Name = "groupId")]
		public new Guid GroupId { get; set; }

		/// <summary>
		/// Identifier of source entity.
		/// </summary>
		[DataMember(Name = "sourceEntityId")]
		public Guid SourceEntityId { get; set; }

		/// <summary>
		/// Count of duplicates in group.
		/// </summary>
		[DataMember(Name = "duplicatesCount")]
		public long DuplicatesCount { get; set; }

		/// <summary>
		/// Source entity entity values.
		/// </summary>
		[DataMember(Name = "sourceEntity")]
		public Dictionary<string, object> SourceEntity { get; set; }

	}

	#endregion

	#region Class: BulkDuplicatesGroupResponse

	[DataContract]
	public class BulkDuplicatesGroupResponse : DuplicatesGroupResponse
	{
		/// <summary>
		/// Collection of groups.
		/// </summary>
		[DataMember(Name = "groups")]
		public new Collection<BulkEntityClientDuplicatesGroup> Groups { get; set; }
	}

	#endregion

}
