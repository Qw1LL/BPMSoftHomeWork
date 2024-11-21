  namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Represents data contract for updating email's schedule.
	/// </summary>
	[DataContract]
	public class UpdateEmailScheduleRequest
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the business time end.
		/// </summary>
		/// <value>
		/// The business time end.
		/// </value>
		[DataMember(Name = "business_time_end")]
		public DateTime BusinessTimeEnd { get; set; }

		/// <summary>
		/// Gets or sets the business time start.
		/// </summary>
		/// <value>
		/// The business time start.
		/// </value>
		[DataMember(Name = "business_time_start")]
		public DateTime BusinessTimeStart { get; set; }

		/// <summary>
		/// Gets or sets the delivery schedule days.
		/// </summary>
		/// <value>
		/// The delivery schedule days.
		/// </value>
		[DataMember(Name = "delivery_schedule_days")]
		public string DeliveryScheduleDays { get; set; }

		/// <summary>
		/// Gets or sets unique identifier of the email.
		/// </summary>
		/// <value>
		/// The email identifier.
		/// </value>
		[DataMember(Name = "email_id")]
		public Guid EmailId { get; set; }

		/// <summary>
		/// Gets or sets the due date when email must be canceled.
		/// </summary>
		/// <value>
		/// The due date.
		/// </value>
		[DataMember(Name = "expiration_date")]
		public DateTime? ExpirationDate { get; set; }

		/// <summary>
		/// Gets or sets the due date when email must be canceled.
		/// </summary>
		/// <value>
		/// The due date.
		/// </value>
		public DateTime ExpirationDateValue => ExpirationDate ?? DateTime.MinValue;

		/// <summary>
		/// Gets or sets the priority of Email.
		/// </summary>
		/// <value>
		/// The priority.
		/// </value>
		[DataMember(Name = "priority_id")]
		public Guid PriorityId { get; set; }

		/// <summary>
		/// Gets or sets the id of time zone for sending.
		/// </summary>
		/// <value>
		/// The target time zone identifier.
		/// </value>
		[DataMember(Name = "target_time_zone_id")]
		public Guid TargetTimeZoneId { get; set; }

		#endregion

	}
}
