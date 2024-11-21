namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;

	#region Class: EnrichTextDataItem

	/// <summary>
	/// Enrich text data root element info.
	/// </summary>
	[DataContract]
	public class EnrichTextDataItem
	{

		#region Properties: Public

		/// <summary>
		/// <see cref="EnrchTextData"/> json data value.
		/// </summary>
		[DataMember(Name = "JsonData")]
		public string JsonData {
			get;
			set;
		}

		/// <summary>
		/// <see cref="EnrchTextData"/> hash unique identifier.
		/// </summary>
		[DataMember(Name = "Hash")]
		public string Hash {
			get;
			set;
		}

		/// <summary>
		/// <see cref="EnrchTextData"/> type value.
		/// </summary>
		[DataMember(Name = "Type")]
		public string Type {
			get;
			set;
		}

		/// <summary>
		/// <see cref="EnrchTextData"/> duplication status value.
		/// </summary>
		[DataMember(Name = "DuplicationStatus")]
		public string DuplicationStatus {
			get;
			set;
		}
		#endregion

		#region Constructors: Public

		public EnrichTextDataItem() {
			DuplicationStatus = string.Empty;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// <see cref="System.Object.Equals(object)"/>
		/// </summary>
		public override bool Equals(object obj) {
			var objToCompare = obj as EnrichTextDataItem;
			if (objToCompare == null) {
				return false;
			}
			return Hash.Equals(objToCompare.Hash) && JsonData.Equals(objToCompare.JsonData) &&
				Type.Equals(objToCompare.Type) && DuplicationStatus.Equals(objToCompare.DuplicationStatus);
		}

		/// <summary>
		/// <see cref="System.Object.Equals(object)"/>
		/// </summary>
		public bool Equals(EnrichTextDataItem obj) {
			if (obj == null) {
				return false;
			}
			return Hash.Equals(obj.Hash) && JsonData.Equals(obj.JsonData) &&
				Type.Equals(obj.Type) && DuplicationStatus.Equals(obj.DuplicationStatus);
		}

		/// <summary>
		/// <see cref="System.Object.GetHashCode()"/>
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode() {
			return (Hash + JsonData + Type + DuplicationStatus).GetHashCode();
		}

		#endregion

	}

	#endregion

	#region Class: EnrichAccountItem

	/// <summary>
	/// Account item found by parsed info.
	/// </summary>
	[DataContract]
	public class EnrichAccountItem
	{

		#region Properties: Public

		/// <summary>
		/// Account Id.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Account name.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Link to enrich text entity for account.
		/// </summary>
		[DataMember(Name = "enrchTextEntityId")]
		public Guid EnrchTextEntityId { get; set; }

		#endregion

	}

	#endregion

}
