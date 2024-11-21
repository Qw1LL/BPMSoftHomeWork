namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Enum: EventTrackMode

	/// <summary>
	/// Event track mode.
	/// </summary>
	public enum EventTrackMode {
		Id = 1,
		Class,
		JQuerySelector
	}

	#endregion

	#region Enum: EventKind

	/// <summary>
	/// Event kind.
	/// </summary>
	public enum EventKind {
		OnClick = 1,
		OnPageLoad
	}

	#endregion

	#region Enum: ModificationAction

	/// <summary>
	/// Action event.
	/// </summary>
	public enum ModificationAction {
		Add = 1,
		Remove = -1
	}

	#endregion

	#region Class: KnownSessionRequest

	/// <summary>
	/// Class for request body of SetKnownSession service.
	/// </summary>
	public class KnownSessionRequest : BaseRestClient<int>
	{
		/// <summary>
		/// Client key.
		/// </summary>
		public string ApiKey {
			get;
			set;
		}

		/// <summary>
		/// Lead's session id
		/// </summary>
		public Guid SessionId {
			get;
			set;
		}
	}

	#endregion

	#region Class: SetEventTypeRequest

	/// <summary>
	/// Class for request body of SetEventType service.
	/// </summary>
	public class SetEventTypeRequest : BaseRestClient<int>
	{

		#region Properties: Public

		/// <summary>
		/// Client key.
		/// </summary>
		public string ApiKey {
			get;
			set;
		}

		/// <summary>
		/// List of items to sync.
		/// </summary>
		public List<EventTypeItem> EventTypeList {
			get;
			set;
		}
		
		#endregion

	}

	#endregion

	#region Class: EventTypeItem

	/// <summary>
	/// Web site event item.
	/// </summary>
	public class EventTypeItem
	{

		#region Properties: Public

		/// <summary>
		/// Web elements tracking identification mode.
		/// </summary>
		public EventTrackMode TrackModeId {
			get;
			set;
		}

		/// <summary>
		/// Value of selector.
		/// </summary>
		public string IdValue {
			get;
			set;
		}

		/// <summary>
		/// Kind of event. 
		/// </summary>
		public EventKind KindId {
			get;
			set;
		}

		/// <summary>
		/// Action of event.
		/// </summary>
		public ModificationAction Action {
			get;
			set;
		}
		
		#endregion

	}

	#endregion

}
