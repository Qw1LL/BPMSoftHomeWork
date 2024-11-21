namespace BPMSoft.Configuration.MandrillService {
	using System;
	using System.Runtime.Serialization;

	#region Class: MandrillMailingResponse

	/// <summary>Result of the Mandrill service mailing.</summary>
	[DataContract]
	public class MandrillMailingResponse {

		#region Properties: Public

		/// <summary>
		/// Result of mailing execution.
		/// </summary>
		[DataMember]
		public bool Success {
			get;
			set;
		}

		/// <summary>
		/// Mailing status.
		/// </summary>
		[DataMember]
		public Guid StatusId {
			get;
			set;
		}

		#endregion
	}

	#endregion
}

