namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: CloudDataResponse

	/// <summary>
	/// Enrich contact elements collection.
	/// </summary>
	[DataContract]
	public class CloudDataResponse
	{

		#region Properties: Public

		/// <summary>
		/// <see cref="EnrichContactItem" /> items list.
		/// </summary>
		[DataMember(Name = "data")]
		public List<EnrichContactItem> Data {
			get;
			set;
		}

		#endregion

		#region Constructors: Public

		public CloudDataResponse() {
			Data = new List<EnrichContactItem>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds <paramref name="item"/> to <see cref="Data"/> list.
		/// </summary>
		/// <param name="item"><see cref="EnrichContactItem"/> instance.</param>
		public void Add(EnrichContactItem item) {
			Data.Add(item);
		}

		#endregion
	}

	#endregion

}
