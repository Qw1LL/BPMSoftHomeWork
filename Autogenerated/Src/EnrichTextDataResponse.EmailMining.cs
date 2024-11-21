namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: EnrichTextDataResponse

	/// <summary>
	/// Enrich text data elements collection.
	/// </summary>
	[DataContract]
	public class EnrichTextDataResponse
	{

		#region Properties: Public

		/// <summary>
		/// <see cref="EnrichContactItem" /> items list.
		/// </summary>
		[DataMember(Name = "data")]
		public List<EnrichTextDataItem> Data {
			get;
			set;
		}

		/// <summary>
		/// Lookup values of accounts that relative to contact.
		/// </summary>
		[DataMember(Name = "foundAccounts")]
		public List<EnrichAccountItem> FoundAccounts {
			get;
			set;
		}

		#endregion

		#region Constructors: Public

		public EnrichTextDataResponse() {
			Data = new List<EnrichTextDataItem>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds <paramref name="item"/> to <see cref="Data"/> list.
		/// </summary>
		/// <param name="item"><see cref="EnrichContactItem"/> instance.</param>
		public void Add(EnrichTextDataItem item) {
			Data.Add(item);
		}

		#endregion
	}

	#endregion

}
