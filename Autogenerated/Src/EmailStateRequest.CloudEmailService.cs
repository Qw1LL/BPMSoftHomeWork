namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;

	#region Class: EmailStateRequest

	/// <summary>
	/// Represents request of the email state service.
	/// </summary>
	[DataContract]
	public class EmailStateRequest
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets email Id to check.
		/// </summary>
		[DataMember(Name = "emailId")]
		public Guid? EmailId {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets start date of the period for sent emails to check.
		/// </summary>
		[DataMember(Name = "startDate")]
		public DateTime? StartDate {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets end date of the period for sent emails to check.
		/// </summary>
		[DataMember(Name = "endDate")]
		public DateTime? EndDate {
			get;
			set;
		} 

		#endregion

	}

	#endregion

}

