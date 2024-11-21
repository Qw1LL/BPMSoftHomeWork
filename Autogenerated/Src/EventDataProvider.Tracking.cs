namespace BPMSoft.Configuration.Tracking
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;

	#region Class: EventDataProvider

	/// <summary>
	/// Provide information from report service.
	/// </summary>
	public class EventDataProvider : ReportServiceDataProvider
	{

		#region Fields: Private

		private const string _feedPathSuffix = "/api/Event/feed";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		public EventDataProvider(UserConnection userConnection) 
				: base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns contact tracking feed.
		/// </summary>
		/// <param name="sessionIds">Session identifiers for get feed.</param>
		/// <param name="offset">Records offset.</param>
		/// <param name="count">Records count.</param>
		/// <returns>Object <see cref="EventFeedDataProviderResponse"/> which contains all needed records.</returns>
		public EventFeedDataProviderResponse GetFeed(IEnumerable<Guid> bpmstudioTrackingIds, string offset, int count) {
			var url = ReportUrl + _feedPathSuffix;
			return SendTokenizedPostRequest<EventFeedDataProviderResponse>(url, new
			{
				offset,
				count,
				bpmstudioTrackingIds = Array.ConvertAll(bpmstudioTrackingIds.ToArray(), x => x.ToString())
			});
		}

		#endregion

	}

	#endregion
}
