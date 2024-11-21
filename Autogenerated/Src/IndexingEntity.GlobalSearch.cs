namespace BPMSoft.Configuration.GlobalSearch
{
	using System.Runtime.Serialization;

	#region Class: IndexingEntity

	/// <summary>
	/// Represents indexing entity.
	/// </summary>
	[DataContract]
	public class IndexingEntity
	{
		#region Fields: Public

		/// <summary>
		/// Entity key.
		/// </summary>
		[DataMember(Name = "Key")]
		public string Key;

		/// <summary>
		/// Entity schema name.
		/// </summary>
		[DataMember(Name = "EntityName")]
		public string EntityName;

		/// <summary>
		/// Parent entity schema name.
		/// </summary>
		[DataMember(Name = "ParentEntityName")]
		public string ParentEntityName;

		/// <summary>
		/// Sql text.
		/// </summary>
		[DataMember(Name = "SqlText")]
		public string SqlText;

		/// <summary>
		/// Indexing type (index, create, upsert, update, delete).
		/// </summary>
		[DataMember(Name = "IndexingType")]
		public IndexingType IndexingType;

		/// <summary>
		/// Tracking modified column name.
		/// </summary>
		[DataMember(Name = "TrackingColumnName")]
		public string TrackingColumnName;

		/// <summary>
		/// Single file flag.
		/// </summary>
		[DataMember(Name = "IsSingle")]
		public bool IsSingle;

		#endregion
	}

	#endregion
}


