namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Runtime.Serialization;

	#region Class: BulkDuplicatesGroupResponse

	[DataContract]
	public class BulkDuplicatesCountResponse
	{
		#region Properties: Public

		/// <summary>
		/// Gets or sets the number of groups.
		/// </summary>
		/// <value>The number of groups.</value>
		[DataMember(Name = "groupsCount")]
		public long GroupsCount { get; set; }

		/// <summary>
		/// Gets or sets the number of duplicates in groups.
		/// </summary>
		/// <value>The number of duplicates in groups.</value>
		[DataMember(Name = "duplicatesCount")]
		public long DuplicatesCount { get; set; }

		#endregion
	}

	#endregion

}
