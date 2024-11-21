namespace BPMSoft.Configuration
{
	using System.ComponentModel;

	#region Enum: StatisticEventType

	/// <summary>
	/// Statistic types.
	/// </summary>
	public enum StatisticEventType
	{
		/// <summary>
		/// Email statistic.
		/// </summary>
		[Description("email_statistics")]
		EmailStatistics = 1,

		/// <summary>
		/// Recipient statistic.
		/// </summary>
		[Description("recipient_statistics")]
		RecipientStatistics = 2,

		/// <summary>
		/// Recipient hourly statistic.
		/// </summary>
		[Description("recipient_hourly_statistics")]
		RecipientHourlyStatistics = 3,

		/// <summary>
		/// Recipient hyperlink statistic.
		/// </summary>
		[Description("recipient_hyperlink_statistics")]
		RecipientHyperlinkStatistics = 4,

		/// <summary>
		/// Email hyperlink statistic.
		/// </summary>
		[Description("email_hyperlink_statistics")]
		EmailHyperlinkStatistics = 5,

		/// <summary>
		/// Unsubscribe statistic.
		/// </summary>
		[Description("unsubscribe")]
		Unsubscribe = 6
	}

	#endregion

}

