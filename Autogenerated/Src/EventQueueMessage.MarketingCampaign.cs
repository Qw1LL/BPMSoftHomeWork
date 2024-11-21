namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;

	#region Enum: Public

	/// <summary>
	/// Defines what exactly contains queue message.
	/// </summary>
	public enum EventQueueMessageType
	{
		AddAudienceByList = 0,
		AddAudienceByFolderId = 1,
		AddAudienceByFilter = 2,
		RemoveAudienceByList = 3,
		RemoveAudienceByFilter = 4,
		RemoveAllAudience = 5
	}

	#endregion

	#region Class: EventQueueMessage

	/// <summary>
	/// Base DTO for <see cref="MarketingEventQueue"/>.
	/// </summary>
	public class EventQueueMessage: BaseQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="EventQueueMessage"/>.
		/// </summary>
		/// <param name="eventId"></param>
		public EventQueueMessage(Guid eventId) : base() {
			EventId = eventId;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id of related event.
		/// </summary>
		public Guid EventId { get; set; }

		/// <summary>
		/// Message type defines what exactly contains queue message.
		/// </summary>
		public EventQueueMessageType Type { get; set; }

		/// <summary>
		/// Returns linked record column name.
		/// </summary>
		public static string RecordName => nameof(EventId);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates message instance from JSON.
		/// </summary>
		///<param name="messageId">Message identifier.</param>
		/// <param name="json">String representation of message.</param>
		/// <param name="retriesCount">Number of retries to process message in case of crash or error.</param>
		/// <returns>Instance of <see cref="EventQueueMessage"/> class.</returns>
		/// <exception cref="ArgumentNullOrEmptyException">In case of empty JSON.</exception>
		public static EventQueueMessage Create(Guid messageId, string json, int retriesCount) {
			json.CheckArgumentNullOrEmpty(nameof(json));
			var result = Json.Deserialize<EventQueueMessage>(json, new JsonSerializerSettings {
				TypeNameHandling = TypeNameHandling.All
			});
			result.Id = messageId;
			result.MaxRetryCount = retriesCount;
			return result;
		}

		/// <inheritdoc />
		public override int GetMessageType() => (int)Type;

		#endregion

	}

	#endregion

	#region Class: ChunkableEventQueueMessage

	/// <summary>
	/// DTO for <see cref="EventQueue"/> item that contains fixed records count to process.
	/// </summary>
	public class ChunkableEventQueueMessage : EventQueueMessage
	{

		#region Constants: Protected

		/// <summary>
		/// Max number of identifiers, stored in one message.
		/// </summary>
		[JsonIgnore]
		protected const int MessageCollectionLimit = 1000;

		#endregion

		#region Constructors: Public

		public ChunkableEventQueueMessage(Guid eventId, IEnumerable<Guid> sourceEntityList)
				: base(eventId) {
			SourceEntityList = sourceEntityList;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// List of entity identifiers to import to event audience from or null.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public IEnumerable<Guid> SourceEntityList { get; set; }

		#endregion

	}

	#endregion

	#region Class: AddEventAudienceByListQueueMessage

	/// <summary>
	/// DTO for <see cref="EventQueue"/> item with type <see cref="EventQueueMessageType.AddAudienceByList"/>.
	/// </summary>
	public class AddEventAudienceByListQueueMessage : ChunkableEventQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="AddEventAudienceByListQueueMessage"/>.
		/// </summary>
		/// <param name="eventId">Event unique identifier.</param>
		/// <param name="sourceEntityList">Collection of source records' ids.</param>
		public AddEventAudienceByListQueueMessage(Guid eventId, IEnumerable<Guid> sourceEntityList)
				: base(eventId, sourceEntityList) {
			Type = EventQueueMessageType.AddAudienceByList;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Factory method. Creates new messages with EventId and list of source entities.
		/// If the number of source identifiers is greater than <see cref="MessageCollectionLimit"/>, splits into few
		/// messages.
		/// </summary>
		/// <param name="eventId">Id of related event.</param>
		/// <param name="sourceEntityCollection">List of entity identifiers to import to event audience from.</param>
		/// <returns>Collection of <see cref="AddEventAudienceByListQueueMessage"/>.</returns>
		public static IEnumerable<AddEventAudienceByListQueueMessage> Create(Guid eventId,
				IEnumerable<Guid> sourceEntityCollection) =>
			sourceEntityCollection
				.SplitOnChunks(MessageCollectionLimit)
				.Select(sourceChunk => new AddEventAudienceByListQueueMessage(eventId, sourceChunk) {
					EstimatedRowsCount = sourceChunk.Count()
				})
				.ToArray();

		#endregion

	}

	#endregion

	#region Class: AddAudienceByFolderQueueMessage

	/// <summary>
	/// DTO for <see cref="EventQueue"/> item with type <see cref="EventQueueMessageType.AddAudienceByFolderId"/>.
	/// </summary>
	public class AddEventAudienceByFolderQueueMessage : EventQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="AddEventAudienceByFolderQueueMessage"/>.
		/// </summary>
		/// <param name="eventId">Event unique identifier.</param>
		/// <param name="folderId">Folder unique identifier.</param>
		public AddEventAudienceByFolderQueueMessage(Guid eventId, Guid folderId) : base(eventId) {
			Type = EventQueueMessageType.AddAudienceByFolderId;
			FolderId = folderId;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Contains folder id or <see cref="Guid.Empty"/>.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Guid FolderId { get; set; }

		#endregion

	}

	#endregion

	#region Class: AddEventAudienceByFilterQueueMessage

	/// <summary>
	/// DTO for <see cref="EventQueue"/> item with type <see cref="EventQueueMessageType.AddAudienceByFilter"/>.
	/// </summary>
	public class AddEventAudienceByFilterQueueMessage : EventQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="AddEventAudienceByFilterQueueMessage"/>.
		/// </summary>
		/// <param name="eventId">Event unique identifier.</param>
		/// <param name="esqSerialized">Serialized esq to filter records.</param>
		public AddEventAudienceByFilterQueueMessage(Guid eventId, string esqSerialized) : base(eventId) {
			Type = EventQueueMessageType.AddAudienceByFilter;
			EsqSerialized = esqSerialized;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Serialized ESQ. Contains JSON that can be deserialized as
		/// <see cref="BPMSoft.Nui.ServiceModel.DataContract.SelectQuery"/>.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EsqSerialized { get; set; }

		#endregion

	}

	#endregion

	#region Class: RemoveEventAudienceByListQueueMessage

	/// <summary>
	/// DTO for <see cref="EventQueue"/> item with type <see cref="EventQueueMessageType.RemoveAudienceByList"/>.
	/// </summary>
	public class RemoveEventAudienceByListQueueMessage : ChunkableEventQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="RemoveEventAudienceByListQueueMessage"/>
		/// </summary>
		/// <param name="eventId">Event unique identifier.</param>
		/// <param name="sourceEntityList">Collection of source records' ids.</param>
		public RemoveEventAudienceByListQueueMessage(Guid eventId, IEnumerable<Guid> sourceEntityList)
				: base(eventId, sourceEntityList) {
			Type = EventQueueMessageType.RemoveAudienceByList;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Factory method. Creates new messages with BulkEmailId and list of source entities.
		/// If the number of source identifiers is greater than <see cref="MessageCollectionLimit"/>, splits into few
		/// messages.
		/// </summary>
		/// <param name="eventId">Id of related event.</param>
		/// <param name="sourceEntityCollection">List of entity identifiers to remove from event audience.</param>
		/// <returns>Collection of <see cref="RemoveEventAudienceByListQueueMessage"/>.</returns>
		public static IEnumerable<RemoveEventAudienceByListQueueMessage> Create(Guid eventId,
				IEnumerable<Guid> sourceEntityCollection) =>
			sourceEntityCollection
				.SplitOnChunks(MessageCollectionLimit)
				.Select(sourceChunk => new RemoveEventAudienceByListQueueMessage(eventId, sourceChunk) {
					EstimatedRowsCount = sourceChunk.Count()
				})
				.ToArray();

		/// <summary>
		/// Returns max retry count for message processing.
		/// </summary>
		/// <returns>Max retry countg.</returns>
		public override int GetMaxRetryCount() => 3;

		#endregion

	}

	#endregion

	#region Class: RemoveEventAudienceByFilterQueueMessage

	/// <summary>
	/// DTO for <see cref="EventQueue"/> item with type <see cref="EventQueueMessageType.RemoveAudienceByFilter"/>.
	/// </summary>
	public class RemoveEventAudienceByFilterQueueMessage : EventQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="RemoveEventAudienceByFilterQueueMessage"/>.
		/// </summary>
		/// <param name="eventId">Event unique identifier.</param>
		/// <param name="esqSerialized">Serialized esq to filter records.</param>
		public RemoveEventAudienceByFilterQueueMessage(Guid eventId, string esqSerialized) : base(eventId) {
			Type = EventQueueMessageType.RemoveAudienceByFilter;
			EsqSerialized = esqSerialized;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Serialized ESQ. Contains JSON that can be deserialized as
		/// <see cref="BPMSoft.Nui.ServiceModel.DataContract.SelectQuery"/>.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EsqSerialized { get; set; }

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="EventQueueMessage.GetMaxRetryCount"/>
		public override int GetMaxRetryCount() => 3;

		#endregion

	}

	#endregion

	#region Class: RemoveAllEventAudienceQueueMessage

	/// <summary>
	/// DTO for <see cref="EventQueue"/> item with type <see cref="EventQueueMessageType.RemoveAllAudience"/>.
	/// </summary>
	public class RemoveAllEventAudienceQueueMessage : EventQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="RemoveAllAudienceQueueMessage"/>.
		/// </summary>
		/// <param name="eventId">Event unique identifier.</param>
		public RemoveAllEventAudienceQueueMessage(Guid eventId) : base(eventId) {
			Type = EventQueueMessageType.RemoveAllAudience;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="EventQueueMessage.GetMaxRetryCount"/>
		public override int GetMaxRetryCount() => 3;

		#endregion

	}

	#endregion

}

