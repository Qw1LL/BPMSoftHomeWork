 namespace BPMSoft.Configuration
{
    using System;
	using System.Runtime.Serialization;
	using SysDayOfWeek = System.DayOfWeek;

    #region Class: EmailScheduleSettings

	/// <summary>
	/// Data contract for email schedule settings.
	/// </summary>
    [DataContract]
    public class EmailScheduleSettings
    {

        #region Properties: Public

		/// <summary>
		///     Gets or sets the time zone identifier.
		/// </summary>
		/// <value>
		///     The time zone identifier.
		/// </value>
		[DataMember(Name = "TimeZoneId")]
        public string TimeZoneId { get; set; }

		/// <summary>
		///     Gets or sets the business time start.
		/// </summary>
		/// <value>
		///     The business time start.
		/// </value>
		[DataMember(Name = "BusinessTimeStart")]
		public DateTime BusinessTimeStart { get; set; }

		/// <summary>
		///     Gets or sets the business time end.
		/// </summary>
		/// <value>
		///     The business time end.
		/// </value>
		[DataMember(Name = "BusinessTimeEnd")]
		public DateTime BusinessTimeEnd { get; set; }

		/// <summary>
		///     Gets or sets the cron expression.
		/// </summary>
		/// <value>
		///     The cron expression.
		/// </value>
		[DataMember(Name = "CronExpression")]
        public string CronExpression { get; set; }

        #endregion

    }

	#endregion
	
	#region Class: EmailFirstScheduleDateResponse
	
	/// <summary>
	/// Response object to get first scheduled date and time for email.
	/// </summary>
	[DataContract]
	public class EmailFirstScheduleDateResponse
	{

		[DataMember(Name = "firstLaunchDate")]
		public DateTime FirstLaunchDate { get; set; }
		
	}

	#endregion


	/// <summary>
	/// Response object to get first scheduled date and time for email.
	/// </summary>
	[DataContract]
	public class CurrentTimeZoneInfo
	{

		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "displayValue")]
		public string DisplayName { get; set; }

		[DataMember(Name = "gmtOffset")]
		public string GmtOffset { get; set; }

		[DataMember(Name = "offsetValue")]
		public double OffsetValue { get; set; }

		[DataMember(Name = "timeZoneId")]
		public string TimeZoneId { get; set; }

	}

}
