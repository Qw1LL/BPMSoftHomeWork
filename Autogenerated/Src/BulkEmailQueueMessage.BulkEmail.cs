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
	public enum BulkEmailQueueMessageType
	{
		AddAudienceByList = 0,
		AddAudienceByFolderId = 1,
		RemoveAllAudience = 2,
		RemoveAudienceByList = 3,
		SendTriggerEmail = 4,
		AddAudienceByFilter = 5,
		RemoveAudienceByFilter = 6
	}

	#endregion

	#region Class: BulkEmailQueueMessage

	/// <summary>
	/// Base DTO for <see cref="BulkEmailQueue"/>.
	/// </summary>
	public class BulkEmailQueueMessage : BaseQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="BulkEmailQueueMessage"/>.
		/// </summary>
		/// <param name="bulkEmailId"></param>
		public BulkEmailQueueMessage(Guid bulkEmailId) : base() {
			BulkEmailId = bulkEmailId;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id of related bulk email.
		/// </summary>
		public Guid BulkEmailId { get; set; }

		/// <summary>
		/// Id of trigger email session.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Guid TriggerEmailSessionId { get; set; }

		/// <summary>
		/// Message type defines what exactly contains queue message.
		/// </summary>
		public BulkEmailQueueMessageType Type { get; set;  }

		/// <summary>
		/// Returns linked record column name.
		/// </summary>
		public static string RecordName => nameof(BulkEmailId);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates message instance from JSON.
		/// </summary>
		///<param name="messageId">Message identifier.</param>
		/// <param name="json">String representation of message.</param>
		/// <param name="retriesCount">Number of retries to process message in case of crash or error.</param>
		/// <returns>Instance of <see cref="BulkEmailQueueMessage"/> class.</returns>
		/// <exception cref="ArgumentNullOrEmptyException">In case of empty JSON.</exception>
		public static BulkEmailQueueMessage Create(Guid messageId, string json, int retriesCount) {
			json.CheckArgumentNullOrEmpty(nameof(json));
			var result = Json.Deserialize<BulkEmailQueueMessage>(json, new JsonSerializerSettings {
				TypeNameHandling = TypeNameHandling.All
			});
			result.Id = messageId;
			result.MaxRetryCount = retriesCount;
			return result;
		}

		/// <inheritdoc />
		public override int GetMessageType() => (int)Type;

		/// <summary>
		/// Defines priority of current message. Messages with highest priority will be processed first.
		/// </summary>
		/// <returns>
		/// 50 -> Trigger email message.
		/// 25 -> Bulk email message.
		/// </returns>
		public override int GetPriority() => TriggerEmailSessionId.IsNotEmpty() ? 50 : 25;

		#endregion

	}

	#endregion

	#region Class: AddAudienceByFilterQueueMessage

	/// <summary>
	/// DTO for <see cref="BulkEmailQueue"/> item with type <see cref="BulkEmailQueueMessageType.AddAudienceByFilter"/>.
	/// </summary>
	public class AddAudienceByFilterQueueMessage : BulkEmailQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="AddAudienceByFilterQueueMessage"/>.
		/// </summary>
		/// <param name="bulkEmailId">Bulk email unique identifier.</param>
		/// <param name="esqSerialized">Serialized esq to filter records.</param>
		public AddAudienceByFilterQueueMessage(Guid bulkEmailId, string esqSerialized) : base(bulkEmailId) {
			Type = BulkEmailQueueMessageType.AddAudienceByFilter;
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

	#region Class: AddAudienceByFolderQueueMessage

	/// <summary>
	/// DTO for <see cref="BulkEmailQueue"/> item with type <see cref="BulkEmailQueueMessageType.AddAudienceByFolderId"/>.
	/// </summary>
	public class AddAudienceByFolderQueueMessage : BulkEmailQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="AddAudienceByFolderQueueMessage"/>.
		/// </summary>
		/// <param name="bulkEmailId">Bulk email unique identifier.</param>
		/// <param name="folderId">Folder unique identifier.</param>
		public AddAudienceByFolderQueueMessage(Guid bulkEmailId, Guid folderId) : base(bulkEmailId) {
			Type = BulkEmailQueueMessageType.AddAudienceByFolderId;
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

	#region Class: AddAudienceByListQueueMessage

	/// <summary>
	/// DTO for <see cref="BulkEmailQueue"/> item with type <see cref="BulkEmailQueueMessageType.AddAudienceByList"/>.
	/// </summary>
	public class AddAudienceByListQueueMessage : ChunkableBulkEmailQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="AddAudienceByListQueueMessage"/>.
		/// </summary>
		/// <param name="bulkEmailId">Bulk email unique identifier.</param>
		/// <param name="sourceEntityList">Collection of source records' ids.</param>
		public AddAudienceByListQueueMessage(Guid bulkEmailId, IEnumerable<Guid> sourceEntityList)
				: base(bulkEmailId, sourceEntityList) {
			Type = BulkEmailQueueMessageType.AddAudienceByList;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Factory method. Creates new messages with BulkEmailId and list of source entities.
		/// If the number of source identifiers is greater than <see cref="MessageCollectionLimit"/>, splits into few
		/// messages.
		/// </summary>
		/// <param name="bulkEmailId">Id of related bulk email.</param>
		/// <param name="sourceEntityCollection">List of entity identifiers to import email audience from.</param>
		/// <returns>Collection of <see cref="AddAudienceByListQueueMessage"/>.</returns>
		public static IEnumerable<AddAudienceByListQueueMessage> Create(Guid bulkEmailId,
				IEnumerable<Guid> sourceEntityCollection) =>
			sourceEntityCollection
				.SplitOnChunks(MessageCollectionLimit)
				.Select(sourceChunk => new AddAudienceByListQueueMessage(bulkEmailId, sourceChunk) {
					EstimatedRowsCount = sourceChunk.Count()
				})
				.ToArray();

		#endregion

	}

	#endregion

	#region Class: RemoveAllAudienceQueueMessage

	/// <summary>
	/// DTO for <see cref="BulkEmailQueue"/> item with type <see cref="BulkEmailQueueMessageType.RemoveAllAudience"/>.
	/// </summary>
	public class RemoveAllAudienceQueueMessage : BulkEmailQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="RemoveAllAudienceQueueMessage"/>.
		/// </summary>
		/// <param name="bulkEmailId">Bulk email unique identifier.</param>
		public RemoveAllAudienceQueueMessage(Guid bulkEmailId) : base(bulkEmailId) {
			Type = BulkEmailQueueMessageType.RemoveAllAudience;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="BulkEmailQueueMessage.GetMaxRetryCount"/>
		public override int GetMaxRetryCount() => 3;

		#endregion

	}

	#endregion

	#region Class: RemoveAudienceByFilterQueueMessage

	/// <summary>
	/// DTO for <see cref="BulkEmailQueue"/> item with type <see cref="BulkEmailQueueMessageType.RemoveAudienceByFilter"/>.
	/// </summary>
	public class RemoveAudienceByFilterQueueMessage : BulkEmailQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="RemoveAudienceByFilterQueueMessage"/>.
		/// </summary>
		/// <param name="bulkEmailId">Bulk email unique identifier.</param>
		/// <param name="esqSerialized">Serialized esq to filter records.</param>
		/// <param name="duplicateType">Type of <see cref="BulkEmailAudienceDuplicateType"/>.</param>
		public RemoveAudienceByFilterQueueMessage(Guid bulkEmailId, string esqSerialized,
				BulkEmailAudienceDuplicateType duplicateType) : base(bulkEmailId) {
			Type = BulkEmailQueueMessageType.RemoveAudienceByFilter;
			EsqSerialized = esqSerialized;
			DuplicateType = duplicateType;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Serialized ESQ. Contains JSON that can be deserialized as
		/// <see cref="BPMSoft.Nui.ServiceModel.DataContract.SelectQuery"/>.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EsqSerialized { get; set; }

		/// <summary>
		/// Audience duplicate type.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BulkEmailAudienceDuplicateType DuplicateType { get; set; }

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="BulkEmailQueueMessage.GetMaxRetryCount"/>
		public override int GetMaxRetryCount() => 3;

		#endregion

	}

	#endregion

	#region Class: ChunkableBulkEmailQueueMessage

	/// <summary>
	/// DTO for <see cref="BulkEmailQueue"/> item that contains fixed records count to process.
	/// </summary>
	public class ChunkableBulkEmailQueueMessage : BulkEmailQueueMessage
	{

		#region Constants: Protected

		/// <summary>
		/// Max number of identifiers, stored in one message.
		/// </summary>
		[JsonIgnore]
		protected const int MessageCollectionLimit = 10000;

		#endregion

		#region Constructors: Public

		public ChunkableBulkEmailQueueMessage(Guid bulkEmailId, IEnumerable<Guid> sourceEntityList)
				: base(bulkEmailId) {
			SourceEntityList = sourceEntityList;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// List of entity identifiers to import email audience from or null.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public IEnumerable<Guid> SourceEntityList { get; set; }

		#endregion

	}

	#endregion

	#region Class: RemoveAudienceByListQueueMessage

	/// <summary>
	/// DTO for <see cref="BulkEmailQueue"/> item with type <see cref="BulkEmailQueueMessageType.RemoveAudienceByList"/>.
	/// </summary>
	public class RemoveAudienceByListQueueMessage : ChunkableBulkEmailQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="RemoveAudienceByListQueueMessage"/>
		/// </summary>
		/// <param name="bulkEmailId">Bulk email unique identifier.</param>
		/// <param name="sourceEntityList">Collection of source records' ids.</param>
		public RemoveAudienceByListQueueMessage(Guid bulkEmailId, IEnumerable<Guid> sourceEntityList)
				: base(bulkEmailId, sourceEntityList) {
			Type = BulkEmailQueueMessageType.RemoveAudienceByList;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Factory method. Creates new messages with BulkEmailId and list of source entities.
		/// If the number of source identifiers is greater than <see cref="MessageCollectionLimit"/>, splits into few
		/// messages.
		/// </summary>
		/// <param name="bulkEmailId">Id of related bulk email.</param>
		/// <param name="sourceEntityCollection">List of entity identifiers to remove email audience.</param>
		/// <returns>Collection of <see cref="RemoveAudienceByListQueueMessage"/>.</returns>
		public static IEnumerable<RemoveAudienceByListQueueMessage> Create(Guid bulkEmailId,
				IEnumerable<Guid> sourceEntityCollection) =>
			sourceEntityCollection
				.SplitOnChunks(MessageCollectionLimit)
				.Select(sourceChunk => new RemoveAudienceByListQueueMessage(bulkEmailId, sourceChunk) {
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

	#region Class: SendTriggerEmailQueueMessage

	/// <summary>
	/// DTO for <see cref="BulkEmailQueue"/> item with type <see cref="BulkEmailQueueMessageType.SendTriggerEmail"/>.
	/// </summary>
	public class SendTriggerEmailQueueMessage : BulkEmailQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="SendTriggerEmailQueueMessage"/>
		/// </summary>
		/// <param name="bulkEmailId">Bulk email unique identifier.</param>
		public SendTriggerEmailQueueMessage(Guid bulkEmailId) : base(bulkEmailId) {
			Type = BulkEmailQueueMessageType.SendTriggerEmail;
		}

		#endregion

	}

	#endregion

}

