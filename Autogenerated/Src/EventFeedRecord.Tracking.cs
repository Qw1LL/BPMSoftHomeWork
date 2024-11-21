namespace BPMSoft.Configuration.Tracking
{
	using System;
	using System.Runtime.Serialization;

	#region Class: EventFeedRecord

	/// <summary>
	/// DTO object which contains information from cloud about one record contact feed.
	/// </summary>
	[DataContract]
	public class EventFeedRecord
	{

		#region Properties: Public

		[DataMember(Name = "id")]
		public string EventId { get; set; }

		[DataMember(Name = "type")]
		public string EventType { get; set; }

		[DataMember(Name = "name")]
		public string EventName { get; set; }

		[DataMember(Name = "value")]
		public string EventValue { get; set; }

		[DataMember(Name = "cost")]
		public string EventCost { get; set; }

		[DataMember(Name = "date")]
		public string Timestamp { get; set; }

		[DataMember(Name = "href")]
		public string Href { get; set; }

		[DataMember(Name = "referrer")]
		public string Referrer { get; set; }

		[DataMember(Name = "language")]
		public string Language { get; set; }

		[DataMember(Name = "platform")]
		public string Platform { get; set; }

		[DataMember(Name = "browser")]
		public string Browser { get; set; }

		[DataMember(Name = "languages")]
		public string Languages { get; set; }

		[DataMember(Name = "screenWidth")]
		public int? ScreenWidth { get; set; }

		[DataMember(Name = "screenHeight")]
		public int? ScreenHeight { get; set; }

		[DataMember(Name = "screenPixelDepth")]
		public int? ScreenPixelDepth { get; set; }

		[DataMember(Name = "screenAvailWidth")]
		public int? ScreenAvailWidth { get; set; }

		[DataMember(Name = "screenAvailHeight")]
		public int? ScreenAvailHeight { get; set; }

		[DataMember(Name = "screenColorDepth")]
		public int? ScreenColorDepth { get; set; }
		#endregion

	}

	#endregion
}

