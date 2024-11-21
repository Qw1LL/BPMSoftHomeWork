namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using OmnichannelMessaging;
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.ServiceModelContract;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;
	using MessageDirection = OmnichannelProviders.Domain.Entities.MessageDirection;
	using SystemSettings = Core.Configuration.SysSettings;

	#region Class: OmnichannelChatProvider

	/// <summary>
	/// Provides a class for working with omnichannel chats.
	/// </summary>
	public class OmnichannelChatProvider
	{

		#region Fields: Private	

		private readonly UserConnection _userConnection;

		private static readonly string _dateFormat = "yyyy'-'MM'-'ddTHH':'mm':'ss";

		private readonly ChatOperatorCache _chatOperatorCache;

		private readonly ChatRepository _chatRepository;

		private readonly List<string> _contactColumns = new List<string> {
			"Contact.Id",
			"Contact.Name",
			"Contact.Photo",
			"Contact.Email",
			"Contact.Account.Id",
			"Contact.Account.Name"
		};

		private readonly List<string> _operatorColumns = new List<string> {
			"Operator",
			"Operator.Contact.Id",
			"Operator.Contact.Name",
			"Operator.Contact.Photo"
		};

		#endregion

		#region Constructors: Public

		public OmnichannelChatProvider(UserConnection userConnection) {
			_userConnection = userConnection;
			_chatOperatorCache = new ChatOperatorCache(userConnection);
			_chatRepository = new ChatRepository(userConnection);
		}

		#endregion

		#region Properties: Protected

		private ChatOperatorNotifier _operatorNotifier;
		protected ChatOperatorNotifier OperatorNotifier {
			get {
				return _operatorNotifier = _operatorNotifier ?? new ChatOperatorNotifier(_userConnection);
			}
		}

		private OperatorManager _operatorManager;
		protected OperatorManager OperatorManager {
			get {
				return _operatorManager ?? (_operatorManager = new OperatorManager(_userConnection));
			}
		}

		private MessageManager _messageManager;
		/// <summary>
		/// Class which save and send messages <see cref="MessageManager"/> class.
		/// </summary>
		protected MessageManager MessageManager {
			get {
				return _messageManager = _messageManager ?? new MessageManager(_userConnection);
			}
		}

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _detailsLogger;
		protected ILog DetailsLogger {
			get {
				return _detailsLogger ?? (_detailsLogger = LogManager.GetLogger("OmnichannelDetails"));
			}
		}

		#endregion

		#region Methods: Private

		private bool AssignOperator(Guid chatId, Guid operatorId, Predicate<Entity> predicate) {
			var chatEsq = CreateEsqWithColumns(new List<string> {
				"Status",
				"Operator",
				"AcceptDate",
				"DirectedOperator",
				"CloseDate"
			});
			var chat = chatEsq.GetEntity(_userConnection, chatId);
			if (predicate(chat)) {
				chat.SetColumnValue("StatusId", OmnichannelMessagingConsts.InProgressChatStatus);
				chat.SetColumnValue("OperatorId", operatorId);
				chat.SetColumnValue("CloseDate", null);
				_chatOperatorCache.UpdateActiveChatsCount(operatorId, 1);
				_chatOperatorCache.RemoveDirectedChat(chatId);
				OperatorManager.RemoveOperatorTimeoutHandler(chatId.ToString());
				return chat.Save(false);
			}
			return false;
		}

		private (ChatContact, ChatContact) GetContactAndOperatorDataByChatId(Guid chatId) {
			List<string> contactAndOperatorColumns = _contactColumns.Concat(_operatorColumns).ToList();
			var chatEsq = CreateEsqWithColumns(contactAndOperatorColumns);
			var chat = chatEsq.GetEntity(_userConnection, chatId);
			return (GetContactDataByEntity(chat), GetOperatorDataByEntity(chat));
		}

		private ChatContact GetContactDataByChatId(Guid chatId) {
			var chatEsq = CreateEsqWithColumns(_contactColumns);
			var chat = chatEsq.GetEntity(_userConnection, chatId);
			return GetContactDataByEntity(chat);
		}

		private Dictionary<Guid, ChatContact> GetOperatorsDataByChatId(List<Guid> chatIds) {
			var chatEsq = CreateEsqWithColumns(_operatorColumns);
			var primaryColumnFilter = chatEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id",
				chatIds.Cast<object>().ToArray());
			chatEsq.Filters.Add(primaryColumnFilter);
			var chats = chatEsq.GetEntityCollection(_userConnection);
			var result = new Dictionary<Guid, ChatContact>();
			foreach(Guid chatId in chatIds) {
				var chat = chats.Find(chatId);
				result.Add(chatId, GetOperatorDataByEntity(chat));
			}
			return result;
		}

		private ChatContact GetContactDataByEntity(Entity chat) {
			return new ChatContact {
				Id = chat.GetTypedColumnValue<Guid>("Contact_Id"),
				Name = chat.GetTypedColumnValue<string>("Contact_Name"),
				Photo = GetPhoto(chat.GetTypedColumnValue<Guid>("Contact_PhotoId")),
				Email = chat.GetTypedColumnValue<string>("Contact_Email"),
				Account = new LookupValue {
					Value = chat.GetTypedColumnValue<Guid>("Contact_Account_Id"),
					DisplayValue = chat.GetTypedColumnValue<string>("Contact_Account_Name")
				}
			};
		}

		private ChatContact GetOperatorDataByEntity(Entity chat) {
			var chatContact = chat.GetTypedColumnValue<Guid>("OperatorId") != default ? new ChatContact {
					Id = chat.GetTypedColumnValue<Guid>("Operator_Contact_Id"),
					Name = chat.GetTypedColumnValue<string>("Operator_Contact_Name"),
					Photo = GetPhoto(chat.GetTypedColumnValue<Guid>("Operator_Contact_PhotoId")),
				} : new ChatContact();
			return chatContact;
		}

		private string GetImageUrl(Guid photoId) {
			return new Uri(GetApplicationUrl()).Append("/img/entity/hash/SysImage/Data/", photoId.ToString()).AbsoluteUri;
		}

		private string GetApplicationUrl() {
			return HttpContext.Current != null
				? WebUtilities.GetBaseApplicationUrl(HttpContext.Current.Request)
				: SystemSettings.GetValue(_userConnection, "SiteUrl", string.Empty);
		}

		private EntitySchemaQuery CreateEsqWithColumns(List<string> chatColumns) {
			var chatEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OmniChat");
			chatEsq.UseAdminRights = false;
			chatEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			foreach (var column in chatColumns) {
				chatEsq.AddColumn(column);
			}
			return chatEsq;
		}

		private ChatMessage MapChatMessage(UnifiedMessage message, (ChatContact, ChatContact) contactAndOperatorData) {
			return new ChatMessage {
				Id = message.Id,
				Author = message.MessageDirection == MessageDirection.Incoming ?
							contactAndOperatorData.Item1 : contactAndOperatorData.Item2,
				Time = GetTimeInUserTimeZone(message.Timestamp).ToString(_dateFormat),
				Text = message.Message,
				Direction = message.MessageDirection,
				Type = message.MessageType,
				Attachments = message.Attachments,
				IsBotMessage = message.IsEcho
			};
		}

		private Guid GetParentChatId(Guid chatId) {
			var chatQuery = new Select(_userConnection)
				.Column("ParentId")
				.From("OmniChat", "oc")
				.Where("oc", "Id").IsEqual(Column.Parameter(chatId))
				 as Select;
			return chatQuery.ExecuteScalar<Guid>();
		}
		
		private string GetContactIdentity(Guid contactId, Guid channelId) {
			return (new Select(_userConnection)
				.Column("ChannelIdentity")
				.From("ContactIdentity", "ci")
				.InnerJoin("Channel").As("c").On("c", "Id").IsEqual(Column.Parameter(channelId))
				.InnerJoin("Channel").As("cc").On("cc", "ProviderId").IsEqual("c", "ProviderId")
				.Where("ci", "ChannelId").In(Column.SourceColumn("cc", "Id"))
					.And("ci", "ContactId").IsEqual(Column.Parameter(contactId))
				 as Select).ExecuteScalar<string>();
		}
		
		private List<Guid> GetOperatorsIds(string chatId, Guid queueId) {
			List<Guid> operatorIds = new List<Guid>();
			if (queueId == Guid.Empty) {
				Guid operatorId = _chatRepository.GetOperatorIdByChatId(Guid.Parse(chatId));
				if (operatorId != Guid.Empty) {
					operatorIds.Add(operatorId);
				}
			} else {
				operatorIds = OperatorManager.GetOperatorIds(chatId, queueId);
				DetailsLogger.DebugFormat($"Get operatorIds for chat {chatId} Operators: {string.Join(", ", operatorIds)}");
			}

			return operatorIds;
		}

		private ChatMessage GetMessageByChatId(string chatId, MessagingMessage message) {
			ChatMessage msg;
			if (message == null) {
				msg = GetChatMessages(Guid.Parse(chatId)).LastOrDefault();
			} else {
				var contactAndOperatorData = GetContactAndOperatorDataByChatId(new Guid(chatId));
				msg = MapChatMessage(message, contactAndOperatorData);
			}
			return msg;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Assigns operator to the chat.
		/// </summary>
		/// <param name="chatId">Identifier of chat.</param>
		/// <param name="operatorId">Identifier of operator.</param>
		/// <param name="assigningCondition">Operator assigning condition.</param>
		/// <returns>True if operator was assigned, otherwise returns false.</returns>
		public virtual bool AssignChatOperator(Guid chatId, Guid operatorId, Predicate<Entity> assigningCondition) {
			DetailsLogger.DebugFormat($"Assigning chat with id {chatId} to operator {operatorId}");
			var isOperatorAssigned = AssignOperator(chatId, operatorId, assigningCondition);
			if (isOperatorAssigned) {
				DetailsLogger.DebugFormat($"Chat with id {chatId} was assigned to operator {operatorId}");
				var chatDistributor = new ChatQueueDistributor(_userConnection);
				DetailsLogger.DebugFormat($"Distributing chat with id {chatId}");
				var chatQueue = _chatRepository.GetChatQueueId(chatId);
				chatDistributor.Distribute(chatQueue);
				DetailsLogger.DebugFormat($"Chat with id {chatId} was distributed to queue {chatQueue}");
				DetailsLogger.DebugFormat($"Loading operators for chat {chatId} from cache");
				var operators = _chatOperatorCache.GetOperatorsCache()
				   .Where(op => op.ChatQueues.Contains(chatQueue))
				   .Select(o => o.UserId).ToList();
				DetailsLogger.DebugFormat($"Operators for chat {chatId} were loaded from cache");
				OperatorNotifier.AcceptChatNotifyAsync(operators, chatId);
			}
			return isOperatorAssigned;
		}

		/// <summary>
		/// Get count of unread chats.
		/// </summary>
		/// <param name="operatorId">Id of operator.</param>
		/// <returns>Count of unread chats.</returns>
		public virtual int GetUnreadChatsCount(Guid operatorId) {
			var chats = OperatorManager.GetChatsByOperator(operatorId, false);
			var chatsId = chats.Select((record) => record.GetTypedColumnValue<Guid>("Id")).ToList();
			var count = 0;
			if (chatsId.Any()) {
				count = (new Select(_userConnection)
				.Column(Func.Count("Id"))
				.From("OmniChat", "oc")
				.Where("oc", "UnprocessedMsgCount").IsGreater(Column.Const(0))
					.And("oc", "Id").In(Column.Parameters(chatsId))
				.CloseBlock() as Select)
				.ExecuteScalar<int>();
			}
			return count;
		}

		/// <summary>
		/// Get count of unread messages in current user and unassigned chats.
		/// </summary>
		/// <returns>Key-value pair array with chat id and unread messages count.</returns>
		public virtual Dictionary<Guid, int> GetUnreadMessagesCount() {
			Select newMessagesSelect = new Select(_userConnection)
				.Column("Id")
				.Column("UnprocessedMsgCount")
				.From("OmniChat", "oc")
				.Where()
				.OpenBlock("oc", "OperatorId").IsNull()
					.Or("oc", "OperatorId").IsEqual(Column.Parameter(_userConnection.CurrentUser.Id))
				.CloseBlock() as Select;
			return newMessagesSelect.ExecuteEnumerable(
				reader => new KeyValuePair<Guid, int>(
					reader.GetColumnValue<Guid>("Id"),
					reader.GetColumnValue<int>("UnprocessedMsgCount")))
				.ToDictionary(x => x.Key, x => x.Value);
		}

		/// <summary>
		/// Get chat messages.
		/// </summary>
		/// <param name="chatId">Id of chat.</param>
		/// <returns>Collection with messages.</returns>
		public IEnumerable<ChatMessage> GetChatMessages(Guid chatId) {
			List<ChatMessage> result = new List<ChatMessage>();
			if (chatId != default(Guid)) {
				IEnumerable<Guid> chatsId = _chatRepository.GetRelatedChatsId(chatId);
				IEnumerable<UnifiedMessage> unifiedMessages = MessageManager.GetMessagesByChatId(chatsId);
				var contactAndOperatorData = GetContactAndOperatorDataByChatId(chatId);
				foreach (var message in unifiedMessages) {
					result.Add(MapChatMessage(message, contactAndOperatorData));
				}
			}
			return result;
		}

		/// <summary>
		/// Get contact messages.
		/// </summary>
		/// <param name="contactId">Id of contact.</param>
		/// <param name="channelId">Id of channel.</param>
		/// <param name="rowCount">Count of rows.</param>
		/// <param name="rowOffset">Rows offset.</param>
		/// <returns>Collection with messages.</returns>
		public IEnumerable<ChatMessage> GetAllMessages(Guid contactId, Guid channelId, int rowCount = 50, int rowOffset = 0) {
			List<ChatMessage> result = new List<ChatMessage>();
			var sender = GetContactIdentity(contactId, channelId);
			if (sender.IsNullOrEmpty()) {
				DetailsLogger.ErrorFormat($"Contact identity was not found by ContactId [{contactId}] and ChannelId [{channelId}]");
				return result;
			}
			var allMessages = MessageManager.GetMessagesBySender(sender, channelId, rowCount, rowOffset);
			if (allMessages.Any()) {
				var chatIds = allMessages.Select(m => Guid.Parse(m.ChatId)).Distinct().ToList();
				ChatContact contactData = GetContactDataByChatId(chatIds.FirstOrDefault());
				Dictionary<Guid, ChatContact> operators = GetOperatorsDataByChatId(chatIds);
				foreach (KeyValuePair<Guid, ChatContact> entry in operators) {
					var chatId = entry.Key;
					var operatorData = entry.Value;
					IEnumerable<UnifiedMessage> messages = allMessages.Where(m => chatId.Equals(Guid.Parse(m.ChatId))).ToList();
					result.AddRange(messages.Select(m => MapChatMessage(m, (contactData, operatorData))));
				}
			}
			return result;
		}

		/// <summary>
		/// Get chat message from unified message.
		/// </summary>
		/// <param name="message">Unified message.</param>
		/// <returns>Collection with messages.</returns>
		public virtual ChatMessage GetChatMessage(UnifiedMessage message) {
			var contactAndOperatorData = GetContactAndOperatorDataByChatId(Guid.Parse(message.ChatId));
			return MapChatMessage(message, contactAndOperatorData);
		}

		/// <summary>
		/// Gets history by chat identifier.
		/// </summary>
		/// <param name="chatId">Chat identifier</param>
		/// <returns>Collection of chat messages.</returns>
		public IEnumerable<ChatMessage> GetChatHistory(Guid chatId) {
			IEnumerable<UnifiedMessage> unifiedMessages = _chatRepository.GetChatConversation(chatId);
			(ChatContact, ChatContact) contactAndOperatorData = GetContactAndOperatorDataByChatId(chatId);
			return unifiedMessages.Select(message => MapChatMessage(message, contactAndOperatorData));
		}

		/// <summary>
		/// Get pre-filled Unified message template.
		/// </summary>
		/// <param name="ChatId">Chat identifier.</param>
		public virtual UnifiedMessage GetOutcomingMessageTemplate(Guid chatId) {
			DetailsLogger.Error("Cannot get Outcoming message template: chatID is empty.");
			if (chatId != default(Guid)) {
				var messages = MessageManager.GetMessagesByChatId(chatId);
				var unifiedMessage = messages.Any() ? messages.FirstOrDefault() :
					MessageManager.GetMessagesByChatId(GetParentChatId(chatId)).FirstOrDefault();
				if (unifiedMessage != null) {
					return new UnifiedMessage {
						Recipient = unifiedMessage.MessageDirection == MessageDirection.Incoming ?
						unifiedMessage.Sender : unifiedMessage.Recipient,
						Sender = unifiedMessage.MessageDirection == MessageDirection.Incoming ?
						unifiedMessage.Recipient : unifiedMessage.Sender,
						MessageDirection = MessageDirection.Outcoming,
						ChatId = chatId.ToString(),
						ChannelId = unifiedMessage.ChannelId,
						Source = unifiedMessage.Source,
						MessageType = OmnichannelProviders.Domain.Entities.MessageType.Text
					};
				}
				DetailsLogger.Error($"Cannot get Outcoming message template for chat {chatId}: no template found.");
			}
			return new UnifiedMessage();
		}

		/// <summary>
		/// Mark all chat messages as processed.
		/// </summary>
		/// <param name="ChatId">Id of chat.</param>
		public virtual void MarkChatAsRead(Guid chatId) {
			_chatRepository.MarkChatAsRead(chatId);
		}

		/// <summary>
		/// Sends all new chat notifications to available operators from <paramref name="queueId"/>.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="queueId">Channel queue identifier.</param>
		/// <param name="isNewChat">Is chat new flag.</param>
		/// <returns><c>True</c> if notification sent to any of operators. Otherwise returns <c>false</c>.</returns>
		public bool DistributeChat(string chatId, Guid queueId, bool isNewChat = true, MessagingMessage message = null) {
			List<Guid> operatorIds = GetOperatorsIds(chatId, queueId);
			if (operatorIds.IsNullOrEmpty()) {
				DetailsLogger.DebugFormat($"Get operatorIds for chat {chatId} and queue {queueId} returned empty list");
				return false;
			}
			if (isNewChat) {
				foreach (var operatorId in operatorIds) {
					_chatOperatorCache.AddDirectedChat(new Guid(chatId), operatorId);
				}
				OperatorNotifier.NewIncomingChatNotify(operatorIds, chatId);
				OperatorManager.SetOperatorsTimeoutHandler(operatorIds, chatId, queueId);
			} else {
				OperatorNotifier.NewMessageInChatNotify(operatorIds, chatId);
			}
			OperatorNotifier.NewUnreadMessageNotify(operatorIds, chatId);
			var msg = GetMessageByChatId(chatId, message);
			OperatorNotifier.NewConversationMessageNotify(operatorIds, chatId, msg);
			OperatorNotifier.UnreadChatsCountNotify(operatorIds);
			return true;
		}

		/// <summary>
		/// Returns operator name and queue name
		/// </summary>
		/// <param name="closedChatId">ID of closed chat</param>
		/// <param name="newChatId">ID of new created chat</param>
		/// <returns>Pair of operator name for closed chat and queue name for new chat</returns>
		public (string, string) GetOperatorAndQueueNameByChatId(Guid closedChatId, Guid newChatId) {
			var chatEsq = CreateEsqWithColumns(new List<string> {
				"Operator.Name",
				"Queue.Name"
			});
			var oldChat = chatEsq.GetEntity(_userConnection, closedChatId);
			var newChat = chatEsq.GetEntity(_userConnection, newChatId);
			string operatorName = oldChat.GetTypedColumnValue<string>("Operator_Name");
			string queueName = newChat.GetTypedColumnValue<string>("Queue_Name");
			return (operatorName, queueName);
		}

		/// <summary>
		/// Returns operator and directed operator names.
		/// </summary>
		/// <param name="closedChatId">Identifier of closed chat.</param>
		/// <param name="newChatId">Identified of new created chat.</param>
		/// <returns>Pair of operator names.</returns>
		public (string, string) GetOperatorAndDirectedOperatorNameByChatId(Guid closedChatId, Guid newChatId) {
			var chatEsq = CreateEsqWithColumns(new List<string> {
				"Operator.Name",
			});
			var oldChat = chatEsq.GetEntity(_userConnection, closedChatId);
			var newChat = chatEsq.GetEntity(_userConnection, newChatId);
			string operatorName = oldChat.GetTypedColumnValue<string>("Operator_Name");
			string directedOperatorName = newChat.GetTypedColumnValue<string>("Operator_Name");
			return (operatorName, directedOperatorName);
		}

		/// <summary>
		/// Converts time to current user time zone.
		/// </summary>
		/// <param name="timestamp">Time to convert.</param>
		/// <returns>Converted time.</returns>
		public DateTime GetTimeInUserTimeZone(long timestamp) {
			DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
			return dt;
		}		

		/// <summary>
		/// Builds photo url.
		/// </summary>
		/// <param name="photoId">Identifier of photo.</param>
		/// <returns>Url to photo.</returns>
		public string GetPhoto(Guid photoId) {
			return photoId != default(Guid) ?
				GetImageUrl(photoId) : string.Empty;
		}

		#endregion

	}

	#endregion

}

