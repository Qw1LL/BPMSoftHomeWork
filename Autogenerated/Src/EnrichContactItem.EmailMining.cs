namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;

	#region Class: EnrichContactItem

	/// <summary>
	/// Enrich contact root element info.
	/// </summary>
	[DataContract]
	public class EnrichContactItem
	{

		#region Properties: Public

		/// <summary>
		/// <see cref="EnrchTextData"/> unique identifier.
		/// </summary>
		[DataMember(Name = "EnrchTextDataId")]
		public Guid EnrchTextDataId {
			get;
			set;
		}

		/// <summary>
		/// <see cref="Contact"/> unique identifier.
		/// </summary>
		[DataMember(Name = "ContactId")]
		public Guid ContactId {
			get;
			set;
		}

		/// <summary>
		/// <see cref="EnrchTextData"/> json data value.
		/// </summary>
		[DataMember(Name = "JsonData")]
		public string JsonData {
			get;
			set;
		}

		#endregion

		#region Methods: Public 

		/// <summary>
		/// <see cref="System.Object.Equals(object)"/>
		/// </summary>
		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}
			EnrichContactItem objToCompare = obj as EnrichContactItem;
			if (objToCompare == null) {
				return false;
			}
			return EnrchTextDataId.Equals(objToCompare.EnrchTextDataId) && ContactId.Equals(objToCompare.ContactId) &&
				JsonData.Equals(objToCompare.JsonData);
		}

		/// <summary>
		/// <see cref="System.Object.Equals(object)"/>
		/// </summary>
		public bool Equals(EnrichContactItem obj) {
			if (obj == null) {
				return false;
			}
			return EnrchTextDataId.Equals(obj.EnrchTextDataId) &&
				ContactId.Equals(obj.ContactId) && JsonData.Equals(obj.JsonData);
		}

		/// <summary>
		/// <see cref="System.Object.GetHashCode()"/>
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode() {
			return (EnrchTextDataId + ContactId.ToString() + JsonData).GetHashCode();
		}

		#endregion

	}

	#endregion

}
