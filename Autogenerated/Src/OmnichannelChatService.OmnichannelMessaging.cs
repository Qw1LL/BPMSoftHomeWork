namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Web.Common;
	using MessageDirection = OmnichannelProviders.Domain.Entities.MessageDirection;

	#region Class: OmnichannelChatService

	/// <summary>
	/// Provides a service for working with omnichannel chats. 
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
#if NETSTANDARD2_0
	public class OmnichannelChatService : BaseService
#else
	public class OmnichannelChatService : BaseService, IReadOnlySessionState
#endif
	{

		#region Class: OmnichannelChatResponse

		public class OmnichannelChatResponse : ConfigurationServiceResponse
		{
			[DataMember(Name = "Chats")]
			public List<OmnichannelChat> Chats { get; set; } = new List<OmnichannelChat>();
		}

		#endregion

		#region Class: OmnichannelChat

		[DataContract]
		public class OmnichannelChat
		{

			#region Fields: Public

			/// <summary>
			/// Unique identification of entity.
			/// </summary>
			[DataMember(Name = "Id")]
			public Guid Id { get; set; }

			/// <summary>
			/// Chat contact.
			/// </summary>
			[DataMember(Name = "Contact")]
			public LookupColumnValue Contact { get; set; }

			/// <summary>
			/// Account of contact.
			/// </summary>
			[DataMember(Name = "Contact.Account")]
			public LookupColumnValue Account { get; set; }

			/// <summary>
			/// Channel provider.
			/// </summary>
			[DataMember(Name = "Channel.Provider")]
			public LookupColumnValue Channel { get; set; }

			/// <summary>
			/// Date of modification.
			/// </summary>
			[DataMember(Name = "ModifiedOn")]
			public string ModifiedOn { get; set; }

			/// <summary>
			/// Chat status.
			/// </summary>
			[DataMember(Name = "Status")]
			public LookupColumnValue Status { get; set; }

			/// <summary>
			/// Chat preview.
			/// </summary>
			[DataMember(Name = "ChatPreview")]
			public string ChatPreview { get; set; }

			/// <summary>
			/// Chat operator.
			/// </summary>
			[DataMember(Name = "Operator")]
			public LookupColumnValue Operator { get; set; }

			/// <summary>
			/// Count of unprocessed messages.
			/// </summary>
			[DataMember(Name = "UnprocessedMsgCount")]
			public int UnprocessedMsgCount { get; set; }

			/// <summary>
			/// Channel settings identifier.
			/// </summary>
			[DataMember(Name = "Channel.MsgSettingsId")]
			public Guid MsgSettingsId { get; set; }

			/// <summary>
			/// Channel source.
			/// </summary>
			[DataMember(Name = "Channel.Source")]
			public string Source { get; set; }

			[DataMember(Name = "LastMessageDirection")]
			public MessageDirection LastMessageDirection { get; set; }

			/// <summary>
			/// Identifier of channel.
			/// </summary>
			[DataMember(Name = "ChannelId")]
			public Guid ChannelId { get; set; }
			
			/// <summary>
			/// Identifier of queue for current chat.
			/// </summary>
			[DataMember(Name = "ChatQueueId")]
			public Guid ChatQueueId { get; set; }

			#endregion

		}

		#endregion

		#region Fields: Private

		private readonly OmnichannelChatProvider _chatProvider;

		#endregion

		#region Properties: Protected

		private ChatOperatorNotifier _operatorNotifier;
		/// <summary>
		/// Instance of <see cref="ChatOperatorNotifier"/> class.
		/// </summary>
		protected ChatOperatorNotifier OperatorNotifier {
			get {
				return _operatorNotifier = _operatorNotifier ?? new ChatOperatorNotifier(UserConnection);
			}
			set {
				_operatorNotifier = value;
			}
		}

		private ChatRepository _chatRepository;
		/// <summary>
		/// Instance of <see cref="ChatRepository"/> class.
		/// </summary>
		public ChatRepository ChatRepository {
			get {
				return _chatRepository = _chatRepository ?? new ChatRepository(UserConnection);
			}
		}

		private ChatQueueRepository _chatQueueRepository;
		/// <summary>
		/// Instance of <see cref="ChatQueueRepository"/> class.
		/// </summary>
		public ChatQueueRepository ChatQueueRepository {
			get {
				return _chatQueueRepository = _chatQueueRepository ?? new ChatQueueRepository(UserConnection);
			}
		}

		private OperatorManager _operatorManager;
		/// <summary>
		/// Operator manager instance of <see cref="OperatorManager"/> class.
		/// </summary>
		public OperatorManager OperatorManager {
			get {
				return _operatorManager = _operatorManager ?? new OperatorManager(UserConnection);
			}
		}

		#endregion

		#region Constructors: Public

		public OmnichannelChatService() {
			_chatProvider = ClassFactory.Get<OmnichannelChatProvider>(
					new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

		#region Methods: Private

		private LookupColumnValue CreateLookupColumn(Entity record, string columnName, bool hasImage = false) {
			return CreateLookupColumn(record, columnName, $"{columnName}Name", hasImage);
		}

		private LookupColumnValue CreateLookupColumn(Entity record, string lookupName, string displayColumn, bool hasImage = false) {
			var id = record.GetTypedColumnValue<Guid>($"{lookupName}Id");
			if (id.IsEmpty()) {
				return null;
			}
			var primaryImageValue = hasImage ? record.GetTypedColumnValue<Guid>($"{lookupName}PrimaryImage") : Guid.Empty;
			return new LookupColumnValue {
				Value = id.ToString(),
				DisplayValue = record.GetTypedColumnValue<string>($"{displayColumn}"),
				PrimaryImageValue = primaryImageValue.IsEmpty() ? "" : primaryImageValue.ToString(),
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Accepts a chat to the current operator.
		/// </summary>
		/// <param name="chatId">Identifier of chat.</param>
		/// <returns>True if the chat was accepted, otherwise returns false.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		ResponseFormat = WebMessageFormat.Json)]
		public bool AcceptChat(Guid chatId) {
			var currentOperatorId = UserConnection.CurrentUser.Id;
			var isAccepted = _chatProvider.AssignChatOperator(chatId, currentOperatorId, e => {
				return e != null && e.GetTypedColumnValue<Guid>("OperatorId") == Guid.Empty;
			});
			return isAccepted;
		}

		/// <summary>
		/// Get count of unread chats.
		/// </summary>
		/// <returns>Count of unread chats.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public int GetUnreadChatsCount() {
			return _chatProvider.GetUnreadChatsCount(UserConnection.CurrentUser.Id);
		}

		/// <summary>
		/// Get count of unread messages in chat.
		/// </summary>
		/// <returns>Key-value pair array with chat id and unread messages count.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<Guid, int> GetUnreadMessagesCount() {
			return _chatProvider.GetUnreadMessagesCount();
		}

		/// <summary>
		/// Mark all chat messages as processed.
		/// </summary>
		/// <param name="chatId">Id of chat.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public void MarkChatAsRead(Guid chatId) {
			_chatProvider.MarkChatAsRead(chatId);
			OperatorNotifier.UnreadChatsCountNotify(UserConnection.CurrentUser.Id);
		}

		/// <summary>
		/// Get chat messages.
		/// </summary>
		/// <param name="chatId">Id of chat.</param>
		/// <returns>Collection with messages.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<ChatMessage> GetConversation(Guid chatId) {
			return _chatProvider.GetChatMessages(chatId);
		}

		/// <summary>
		/// Get contact messages.
		/// </summary>
		/// <param name="contactId">Id of contact.</param>
		/// <param name="channelId">Id of channel.</param>
		/// <param name="rowCount">Count of rows.</param>
		/// <param name="rowOffset">Rows offset.</param>
		/// <returns>Collection with messages.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<ChatMessage> GetAllConversation(Guid contactId, Guid channelId, int rowCount = 50, int rowOffset = 0) {
			return _chatProvider.GetAllMessages(contactId, channelId, rowCount, rowOffset);
		}

		/// <summary>
		/// Gets history by chat identifier.
		/// </summary>
		/// <param name="chatId">Chat identifier</param>
		/// <returns>Collection of chat messages.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<ChatMessage> GetHistory(Guid chatId) {
			return _chatProvider.GetChatHistory(chatId);
		}

		/// <summary>
		/// Get pre-filled Unified message template.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public UnifiedMessage GetUnifiedMessageTemplate(Guid chatId) {
			return _chatProvider.GetOutcomingMessageTemplate(chatId);
		}

		/// <summary>
		/// Close active chat.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public void CloseActiveChat(Guid chatId) {
			ChatRepository.CloseActiveChat(chatId, true);
		}

		/// <summary>
		/// Gets chats by operator identifier.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public OmnichannelChatResponse GetChats(Guid operatorId) {
			var response = new OmnichannelChatResponse();
			try {
				var chats = OperatorManager.GetChatsByOperator(operatorId);
				response.Chats = chats.Select((record) => new OmnichannelChat {
					Id = record.GetTypedColumnValue<Guid>("Id"),
					Account = CreateLookupColumn(record, "Contact_Account", "Contact_Account_Name", true),
					Contact = CreateLookupColumn(record, "Contact", "Contact_Name", true),
					Channel = CreateLookupColumn(record, "Channel_Provider", true),
					Operator = CreateLookupColumn(record, "Operator"),
					Status = CreateLookupColumn(record, "Status"),
					ChatPreview = record.GetTypedColumnValue<string>("ChatPreview"),
					ModifiedOn = DateTimeDataValueType.Serialize(record.GetColumnValue("ModifiedOn"), TimeZoneInfo.Utc),
					UnprocessedMsgCount = record.GetTypedColumnValue<int>("UnprocessedMsgCount"),
					MsgSettingsId = record.GetTypedColumnValue<Guid>("Channel_MsgSettingsId"),
					LastMessageDirection = record.GetTypedColumnValue<MessageDirection>("LastMessageDirection"),
					Source = record.GetTypedColumnValue<string>("Channel_Source"),
					ChannelId = record.GetTypedColumnValue<Guid>("ChannelId"),
					ChatQueueId = record.GetTypedColumnValue<Guid>("QueueId")
				}).ToList();
			} catch (Exception e) {
				response.Success = false;
				response.ErrorInfo = response.SetErrorInfo(e);
			}
			return response;
		}

		/// <summary>
		/// Clear contact identity cache.
		/// </summary>
		/// <param name="contactIds">List of contact identifiers.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public void ClearContactIdentityCache(List<Guid> contactIds) {
			contactIds.ForEach(id => OmnichannelContactIdentifier.RemoveIdentityFromCache(id, UserConnection));
		}

		/// <summary>
		/// Returns chat actions list.
		/// </summary>
		/// <param name="chatId"><see cref="OmniChat"/> identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public List<OmniChatAction> GetChatActions(Guid chatId) {
			var chatQueueId = ChatRepository.GetChatQueueId(chatId);
			return ChatQueueRepository.GetQueueActions(chatQueueId);
		}

		#endregion

	}

	#endregion

}
