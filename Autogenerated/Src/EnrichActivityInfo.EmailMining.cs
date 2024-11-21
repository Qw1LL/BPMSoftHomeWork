namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;

	#region Class: EnrichActivityInfo
	
	/// <summary>
	/// Enriched email information.
	/// </summary>
	[DataContract]
	public class EnrichActivityInfo
	{

		#region Properties: Public 

		/// <summary>
		/// The email activity identifier.
		/// </summary>
		[DataMember(Name = "activityId")]
		public Guid ActivityId;

		/// <summary>
		/// Enriched contact identifier.
		/// </summary>
		[DataMember(Name = "contactId")]
		public Guid ContactId;

		/// <summary>
		/// Enriched contact name.
		/// </summary>
		[DataMember(Name = "contactName")]
		public string ContactName;

		#endregion

		#region Methods: Public 

		/// <summary>
		/// <see cref="System.Object.Equals(object)"/>
		/// </summary>
		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}
			EnrichActivityInfo objToCompare = obj as EnrichActivityInfo;
			if (objToCompare == null) {
				return false;
			}
			return ActivityId.Equals(objToCompare.ActivityId) && ContactId.Equals(objToCompare.ContactId);
		}

		/// <summary>
		/// <see cref="System.Object.Equals(object)"/>
		/// </summary>
		public bool Equals(EnrichActivityInfo obj) {
			if (obj == null) {
				return false;
			}
			return ActivityId.Equals(obj.ActivityId) && ContactId.Equals(obj.ContactId);
		}

		/// <summary>
		/// <see cref="System.Object.GetHashCode()"/>
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode() {
			return (ActivityId.ToString() + ContactId.ToString()).GetHashCode();
		}

		#endregion

	}

	#endregion

}

