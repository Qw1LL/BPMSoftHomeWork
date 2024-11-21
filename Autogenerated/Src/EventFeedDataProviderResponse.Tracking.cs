namespace BPMSoft.Configuration.Tracking
{
	using System.Collections.Generic;

	#region Class: EventFeedDataProviderResponse

	/// <summary>
	/// Response class for <see cref="ResourceDataProvider"/> and inherited classes.
	/// DTO contains records for visualize in contact feed.
	/// </summary>
	public class EventFeedDataProviderResponse : DataProviderResponse
	{

		#region Properties: Public

		/// <summary>
		/// Offset of records.
		/// </summary>
		public string Offset { get; set; }

		/// <summary>
		/// Feed records.
		/// </summary>
		public List<EventFeedRecord> Events { get; set; }

		#endregion

	}

	#endregion
}

