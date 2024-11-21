namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using Newtonsoft.Json;
	using OmnichannelMessaging;
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using OmnichannelDirection = OmnichannelProviders.Domain.Entities;

	#region Class: ChatRepository

	/// <summary>
	/// Provides repository for working with chats.
	/// </summary>
	public class ChatRepository
	{

		#region Constants: Private

		private const int CLOSE_DEAD_CHAT_TIMEOUT_IN_MINUTES = 60;

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		/// <summary>
		/// <see cref="ChatOperatorCache"/> instance.
		/// </summary>
		private readonly ChatOperatorCache _chatOperatorCache;

		#endregion

		#region Properties: Protected 

		
		private OpenChatFromContactVerifier _openChatFromContactVerifier;
		/// <summary>
		/// Contact data verifier for chat opening.
		/// </summary>
		protected OpenChatFromContactVerifier OpenChatFromContactVerifier {
			get {
				return _openChatFromContactVerifier = _openChatFromContactVerifier ?? new OpenChatFromContactVerifier(_userConnection);
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

		private ChatQueueRepository _chatQueueRepository;
		/// <summary>
		/// Repository of chats queue.
		/// </summary>
		protected ChatQueueRepository ChatQueueRepository {
			get {
				return _chatQueueRepository = _chatQueueRepository ?? new ChatQueueRepository(_userConnection);
			}
		}

		private ChatOperatorNotifier _operatorNotifier;
		/// <summary>
		/// Instance of <see cref="ChatOperatorNotifier"/> class.
		/// </summary>
		protected ChatOperatorNotifier OperatorNotifier {
			get {
				return _operatorNotifier = _operatorNotifier ?? new ChatOperatorNotifier(_userConnection);
			}
		}

		private OperatorManager _operatorManager;
		/// <summary>
		/// Instance of <see cref="OperatorManager"/> class.
		/// </summary>
		protected OperatorManager OperatorManager {
			get {
				return _operatorManager = _operatorManager ?? new OperatorManager(_userConnection);
			}
		}

		private ChatQueueDistributor _queueDistribution;
		/// <summary>
		/// Distributors of chats queue.
		/// </summary>
		protected ChatQueueDistributor QueueDistribution {
			get {
				return _queueDistribution = _queueDistribution ?? new ChatQueueDistributor(_userConnection);
			}
		}

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _log;
		protected ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("OmnichannelChat"));
			}
		}

		#endregion

		#region Delegate: Protected

		protected delegate void SetAdditionalColumns(Entity entity);

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ChatRepository"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ChatRepository(UserConnection userConnection) : this(userConnection, new ChatOperatorCache(userConnection)) {
		}

		/// <summary>
		/// Initializes new instance of <see cref="ChatRepository"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="cache">Operators cache instance.</param>
		public ChatRepository(UserConnection userConnection, ChatOperatorCache cache) {
			_userConnection = userConnection;
			_chatOperatorCache = cache;
		}

		#endregion

		#region Methods: Private

		private void AddBaseColumns(EntitySchemaQuery esq) {
			esq.AddColumn("Contact");
			esq.AddColumn("CloseDate");
			esq.AddColumn("ChatPreview");
			esq.AddColumn("Channel");
			esq.AddColumn("Channel.ChatQueue");
			esq.AddColumn("Operator");
			esq.AddColumn("Status");
			esq.AddColumn("UnprocessedMsgCount");
			esq.AddColumn("LastMessageDirection");
			esq.AddColumn("Queue");
			esq.AddColumn("CreatedOn").OrderByDesc();
			esq.AddColumn("ModifiedOn").OrderByDesc();
		}

		private Entity FindActiveChat(MessagingMessage message) {
			var esq = CreateOmnichannelEsq();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact",
				message.ContactId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Channel",
				message.ChannelId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status",
				OmnichannelMessagingConsts.CompletedChatStatus));
			EntityCollection collection = esq.GetEntityCollection(_userConnection);
			if (collection.IsEmpty()) {
				return null;
			}
			if (collection.Count > 1) {
				Log.Error($"Multiple active chats for contactId: {message.ContactId}, channelId: {message.ChannelId}");
			}
			return collection[0];
		}

		private int GetFirstReplyTime(IEnumerable<UnifiedMessage> unifiedMessages, DateTime chatStartDate) {
			var firstReplyMessageTimeCollection = unifiedMessages.Where(message => message.MessageDirection
				== OmnichannelDirection.MessageDirection.Outcoming);
			if (firstReplyMessageTimeCollection.Any()) {
				TimeSpan result = GetTimeInUserTimeZone(firstReplyMessageTimeCollection.Min(message => message.Timestamp)) -
					chatStartDate;
				return Convert.ToInt32(result.TotalSeconds);
			}
			return default(int);
		}

		private int GetChatDuration(DateTime startDate, DateTime endDate) {
			TimeSpan result = endDate - startDate;
			return Convert.ToInt32(result.TotalMinutes);
		}

		private DateTime GetTimeInUserTimeZone(long timestamp) {
			DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
			dt = TimeZoneInfo.ConvertTimeFromUtc(dt, _userConnection.CurrentUser.TimeZone);
			return dt;
		}

		private DateTime GetChatEndDate(IEnumerable<UnifiedMessage> unifiedMessages) {
			return GetTimeInUserTimeZone(unifiedMessages.Max(message => message.Timestamp));
		}

		private DateTime GetChatStartDate(IEnumerable<UnifiedMessage> unifiedMessages) {
			return GetTimeInUserTimeZone(unifiedMessages.Min(message => message.Timestamp));
		}

		private EntitySchemaQuery CreateOmnichannelEsq(bool applyColumns = true) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OmniChat");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			if (applyColumns) {
				AddBaseColumns(esq);
			}
			return esq;
		}

		private EntitySchemaQuery CreateActualOperatorChatsEsq(bool applyColumns = true) {
			var esq = CreateOmnichannelEsq(applyColumns);
			if (applyColumns) {
				esq.AddColumn("Contact.Name");
				esq.AddColumn("Contact.Account");
				esq.AddColumn("Contact.Account.Name");
				esq.AddColumn("Channel.MsgSettingsId");
				esq.AddColumn("Channel.Provider");
				esq.AddColumn("Channel.Source");
				esq.AddColumn("Channel");
				esq.AddColumn("ModifiedOn");
				esq.AddColumn("LastMessageDirection");
				esq.Columns.FindByName("CreatedOn").OrderByAsc();
			}
			var chatFilter = new EntitySchemaQueryFilterCollection(esq);
			chatFilter.LogicalOperation = LogicalOperationStrict.And;
			chatFilter.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status",
			  OmnichannelMessagingConsts.CompletedChatStatus));
			chatFilter.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status",
			  OmnichannelMessagingConsts.BotProcessingChatStatus));
			esq.Filters.Add(chatFilter);
			return esq;
		}

		private Entity GetOmnichannelChat(Guid? chatId) {
			var esq = CreateOmnichannelEsq();
			return esq.GetEntity(_userConnection, chatId);
		}

		private void SetCloseDate(Entity chat, MessagingMessage message) {
			if ((message.MessageDirection == OmnichannelDirection.MessageDirection.Incoming) && !message.IsStandBy) {
				chat.SetColumnValue("CloseDate", null);
			} else {
				var channelQueueId = chat.GetTypedColumnValue<Guid>("QueueId");
				int timeout = ChatQueueRepository.GetSettings(channelQueueId).Timeout;
				if (message.IsStandBy) {
					chat.SetColumnValue("CloseDate", DateTime.UtcNow.AddMinutes(CLOSE_DEAD_CHAT_TIMEOUT_IN_MINUTES));
					return;
				}
				if (timeout >= 1) {
					chat.SetColumnValue("CloseDate", DateTime.UtcNow.AddMinutes(timeout));
				}
			}
		}

		private void AddExpiredOmnichannelChatColumns(EntitySchemaQuery esq) {
			esq.AddColumn("Operator");
			esq.AddColumn("Status");
			esq.AddColumn("CloseDate");
			esq.AddColumn("ChatStartDate");
			esq.AddColumn("ChatEndDate");
			esq.AddColumn("FirstReplyTime");
			esq.AddColumn("ChatDuration");
			esq.AddColumn("Conversation");
			esq.AddColumn("CompletionDate");
		}

		private void AddExpiredOmnichannelChatFilters(EntitySchemaQuery esq) {
			var filters = new[] {
				esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "CloseDate", DateTime.UtcNow),
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", OmnichannelMessagingConsts.CompletedChatStatus),
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", OmnichannelMessagingConsts.WaitingForProcessing),
			};
			esq.Filters.AddRange(filters);
		}

		private string GetChatPreview(MessagingMessage message) {
			if (message.Attachments != null) {
				return new LocalizableString(_userConnection.Workspace.ResourceStorage, "ChatRepository",
					"LocalizableStrings.FileChatPreview.Value").ToString();
			}
			return message.Message;
		}

		private bool TryGetChatEntity(Guid chatId, out Entity chat, bool IsEmptyEntity = false) {
			EntitySchema schema = _userConnection.EntitySchemaManager.GetInstanceByName("OmniChat");
			chat = schema.CreateEntity(_userConnection);
			if (IsEmptyEntity) {
				return IsEmptyEntity;
			} else {
				return chat.FetchFromDB(chatId);
			}
		}

		private Select GetRelatedChatsSelect() {
			return new Select(_userConnection)
					.Column("OC", "Id").As("Id")
					.Column("OC", "ParentId").As("ParentId")
				.From("OmniChat").As("OC") as Select;
		}

		private HierarchicalSelectOptions GetRelatedChatsHierarchicalOptions(Guid chatId) {
			var options = new HierarchicalSelectOptions {
				PrimaryColumnName = "Id",
				ParentColumnName = "ParentId",
				SelectType = HierarchicalSelectType.Parents
			};
			var startingIdParameter = new QueryParameter("Id", chatId);
			QueryCondition startingCondition = options.StartingPrimaryColumnCondition;
			startingCondition.LeftExpression = new QueryColumnExpression("Id");
			startingCondition.ConditionType = QueryConditionType.Equal;
			startingCondition.RightExpressions.Add(startingIdParameter);
			return options;
		}

		private IEnumerable<Guid> FindRelatedChats(Guid chatId) {
			Select select = GetRelatedChatsSelect();
			select.HierarchicalOptions = GetRelatedChatsHierarchicalOptions(chatId);
			return select.ExecuteEnumerable(r => r.GetColumnValue<Guid>("Id")).ToArray();
		}

		private Guid GetParentChatId(Guid chatId) {
			return (new Select(_userConnection).Top(1)
				.Column("ParentId")
				.From("OmniChat")
				.Where("Id").IsEqual(Column.Parameter(chatId)) as Select).ExecuteScalar<Guid>();
		}

		private Guid GetChannelProvider(string channelId) {
			return (new Select(_userConnection).Top(1)
				.Column("ProviderId")
				.From("Channel")
				.Where("Id").IsEqual(Column.Parameter(Guid.Parse(channelId))) as Select).ExecuteScalar<Guid>();
		}

		private EntitySchemaQuery GetChatConversationEsq() {
			var chatEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OmniChat");
			chatEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			chatEsq.AddColumn("Conversation");
			return chatEsq;
		}

		private IEnumerable<MessagingMessage> GetParentChatConversation(Guid chatId) {
			Guid parentChatId = GetParentChatId(chatId);
			if (parentChatId == default(Guid)) {
				return null;
			}
			IEnumerable<MessagingMessage> conversation = GetChatConversation(parentChatId);
			return conversation;
		}

		private IEnumerable<UnifiedMessage> BuildConversation(IEnumerable<UnifiedMessage> unifiedMessages, Guid chatId) {
			IEnumerable<UnifiedMessage> parentConversation = GetParentChatConversation(chatId);
			if (parentConversation == null) {
				return unifiedMessages;
			}
			return parentConversation.Concat(unifiedMessages);
		}

		private void PassControlToBotIfNeeded(UnifiedMessage message) {
			if (message.IsStandBy) {
				var result = MessageManager.PassControlToBot(message);
				Log.DebugFormat("Control was passed to external bot with recipient {0}. Result = {1}", message.Sender, result);
			}
		}

		private void SaveChatMessages(IEnumerable<UnifiedMessage> unifiedMessages) {
			var textMessages = unifiedMessages.Where(mes => mes.MessageType == OmnichannelDirection.MessageType.Text);
			foreach (var message in textMessages) {
				var insert = new Insert(_userConnection)
				.Into("ChatMessages")
				.Set("Timestamp", Column.Parameter(message.Timestamp.ToString()))
				.Set("Sender", Column.Parameter(message.Sender))
				.Set("Recipient", Column.Parameter(message.Recipient))
				.Set("Source", Column.Parameter(message.Source))
				.Set("OmniChatId", Column.Parameter(Guid.Parse(message.ChatId)))
				.Set("Message", Column.Parameter(message.Message))
				.Set("MessageDirection", Column.Parameter(message.MessageDirection))
				.Set("ChannelId", Column.Parameter(Guid.Parse(message.ChannelId)))
				.Set("CreatedDate", Column.Parameter(DateTimeOffset.FromUnixTimeMilliseconds(message.Timestamp).UtcDateTime))
				as Insert;
				insert.Execute();
			}
		}

		private IEnumerable<UnifiedMessage> GetMessagesByChannelId(Guid channelId) {
			Select chatSelect = new Select(_userConnection)
				.Column("Id")
				.From("OmniChat").As("OC")
				.Where("OC", "ChannelId").IsEqual(Column.Parameter(channelId))
				.And("OC", "StatusId").IsEqual(Column.Const(OmnichannelMessagingConsts.BotProcessingChatStatus)) as Select;
			List<Guid> botChats = new List<Guid>();
			chatSelect.ExecuteReader(r => {
				botChats.Add(r.GetColumnValue<Guid>("Id"));
			});
			var messages = MessageManager.GetMessagesByChatId(botChats);
			return messages;
		}

		private IEnumerable<UnifiedMessage> InnerCloseChat(Entity chat, bool createSystemMessage = false) {
			var oldStatus = chat.GetTypedColumnValue<Guid>("StatusId");
			if (oldStatus == OmnichannelMessagingConsts.CompletedChatStatus) {
				return new List<UnifiedMessage>();
			}
			var chatId = chat.GetTypedColumnValue<Guid>("Id");
			IEnumerable<UnifiedMessage> unifiedMessages = MessageManager.GetMessagesByChatId(chatId);
			SaveChatMessages(unifiedMessages);
			BuildConversation(unifiedMessages, chatId);
			string serializedConversation = JsonConvert.SerializeObject(unifiedMessages);
			chat.SetColumnValue("Conversation", serializedConversation);
			var chatStartDate = GetChatStartDate(unifiedMessages);
			var chatEndDate = GetChatEndDate(unifiedMessages);
			chat.SetColumnValue("ChatStartDate", chatStartDate);
			chat.SetColumnValue("ChatEndDate", chatEndDate);
			chat.SetColumnValue("CompletionDate", DateTime.UtcNow);
			var firstReplyTime = GetFirstReplyTime(unifiedMessages, chatStartDate);
			if (firstReplyTime != default(int)) {
				chat.SetColumnValue("FirstReplyTime", firstReplyTime);
			}
			int chatDuration = GetChatDuration(chatStartDate, chatEndDate);
			chat.SetColumnValue("ChatDuration", chatDuration);
			chat.SetColumnValue("StatusId", OmnichannelMessagingConsts.CompletedChatStatus);
			chat.Save(false);
			if (createSystemMessage &&
					chat.GetTypedColumnValue<Guid>("OperatorId").IsNotEmpty()) {
				CreateChatClosedSystemMessage(unifiedMessages.LastOrDefault());
			}
			return unifiedMessages;
		}

		private void CreateChatClosedSystemMessage(UnifiedMessage lastMessage) {
			string messageText = new LocalizableString(_userConnection.Workspace.ResourceStorage, "ChatRepository",
				"LocalizableStrings.ChatWasClosedSystemMessage.Value").ToString();
			var systemMessage = new MessagingMessage {
				Message = messageText,
				ChatId = lastMessage.ChatId.ToString(),
				MessageType = OmnichannelDirection.MessageType.System,
				Timestamp = GetCurrentTime(),
				Recipient = lastMessage.Recipient,
				Sender = lastMessage.Sender,
				MessageDirection = OmnichannelDirection.MessageDirection.Outcoming,
				ChannelId = lastMessage.ChannelId,
				Source = lastMessage.Source
			};
			MessageManager.AddSystemMessage(systemMessage);
		}

		private long GetCurrentTime() {
			return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
		}

		#endregion

		#region Methods: Protected

		protected virtual Guid CreateChat(MessagingMessage message, SetAdditionalColumns setAdditionalColumns) {
			Guid chatId = Guid.NewGuid();
			TryGetChatEntity(chatId, out Entity omniChatEntity, true);
			omniChatEntity.SetDefColumnValues();
			omniChatEntity.SetColumnValue("Id", chatId);
			omniChatEntity.SetColumnValue("ChatPreview", GetChatPreview(message));
			omniChatEntity.SetColumnValue("ContactId", message.ContactId);
			omniChatEntity.SetColumnValue("ChannelId", message.ChannelId);
			omniChatEntity.SetColumnValue("CloseDate", null);
			omniChatEntity.SetColumnValue("LastMessageDirection", message.MessageDirection);
			setAdditionalColumns(omniChatEntity);
			omniChatEntity.Save(false);
			Log.InfoFormat("Chat (id={0}) with Contact {1} was created", chatId, message.ContactId);
			return chatId;
		}

		protected virtual Guid UpdateChat(MessagingMessage message, Entity chat) {
			Guid chatId = chat.GetTypedColumnValue<Guid>("Id");
			if (message.MessageDirection == OmnichannelDirection.MessageDirection.Incoming) {
				UpdateUnreadMsgCount(chat);
			}
			SetCloseDate(chat, message);
			chat.SetColumnValue("ChatPreview", GetChatPreview(message));
			chat.SetColumnValue("LastMessageDirection", message.MessageDirection);
			chat.Save(false);
			return chatId;
		}

		protected virtual void UpdateUnreadMsgCount(Entity chat) {
			int msgCount = chat.GetTypedColumnValue<int>("UnprocessedMsgCount");
			msgCount += 1;
			chat.SetColumnValue("UnprocessedMsgCount", msgCount);
		}

		/// <summary>
		/// Get esq to OmnichannelChat.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		protected virtual EntitySchemaQuery GetExpiredOmnichannelChatEsq(UserConnection userConnection) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "OmniChat");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			AddExpiredOmnichannelChatColumns(esq);
			AddExpiredOmnichannelChatFilters(esq);
			return esq;
		}

		/// <summary>
		/// Close OmnichannelChat.
		/// </summary>
		/// <param name="chat">OmnichannelChat entity.</param>
		protected virtual void CloseOmnichannelChat(Entity chat, bool createSystemMessage = false) {
			var oldStatus = chat.GetTypedColumnValue<Guid>("StatusId");
			var chatId = chat.GetTypedColumnValue<Guid>("Id");
			var unifiedMessages = InnerCloseChat(chat, createSystemMessage);
			if (oldStatus == OmnichannelMessagingConsts.InProgressChatStatus) {
				PassControlToBotIfNeeded(unifiedMessages.First(m => !m.IsEcho));
			}
			var operatorId = chat.GetTypedColumnValue<Guid>("OperatorId");
			OperatorNotifier.CompleteChatNotify(operatorId, chatId);
			_chatOperatorCache.UpdateActiveChatsCount(operatorId, -1);
			QueueDistribution.DistributeQueueChatsByChatId(chatId);
			Log.InfoFormat("Chat (id={0}) was closed", chatId);
		}

		protected virtual void ClosePreviousChat(Entity chat) {
			InnerCloseChat(chat);
			var operatorId = chat.GetTypedColumnValue<Guid>("OperatorId");
			_chatOperatorCache.UpdateActiveChatsCount(operatorId, -1);
		}

		/// <summary>
		/// Get a collection of active operator chats.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="EntityCollection"/> collection of active operator chats.</returns>
		protected virtual EntityCollection InternalGetChatsByOperator(Guid operatorId, bool applyColumns = true) {
			var esq = CreateActualOperatorChatsEsq(applyColumns);
			var operatorFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Operator", operatorId);
			esq.Filters.Add(operatorFilter);
			return esq.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Get a collection of possible operator chats.
		/// </summary>
		/// <param name="ids">Collection of IDs of distributed operator omnichats.</param>
		/// <returns><see cref="EntityCollection"/> collection of distributed operator omnichats.</returns>
		protected virtual EntityCollection InternalGetChatsById(List<Guid> ids, bool applyColumns = true) {
			var esq = CreateActualOperatorChatsEsq(applyColumns);
			var primaryColumnFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id",
				ids.Cast<object>().ToArray());
			esq.Filters.Add(primaryColumnFilter);
			return esq.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Get operator accepted chats information query.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		protected virtual Select GetAcceptedChatsInfoQuery(UserConnection userConnection, Guid operatorId) {
			return new Select(userConnection)
					.Column(Func.Count("Id")).As("Count")
					.Column(Func.Max("AcceptDate")).As("LatestChat")
				.From("OmniChat")
				.Where("OperatorId").IsEqual(Column.Parameter(operatorId))
					.And("StatusId").IsEqual(Column.Parameter(OmnichannelMessagingConsts.InProgressChatStatus))
					.GroupBy("OperatorId") as Select;
		}

		/// <summary>
		/// Get operator directed chats information query.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		protected virtual Select GetDirectedChatsInfoQuery(UserConnection userConnection, Guid operatorId) {
			return new Select(userConnection)
					.Column("Id")
				.From("OmniChat")
				.Where("DirectedOperatorId").IsEqual(Column.Parameter(operatorId))
				.And("StatusId").In(
				Column.Parameters(new[] {
					OmnichannelMessagingConsts.WaitingForProcessing,
					OmnichannelMessagingConsts.InProgressChatStatus})) as Select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds message to chat.
		/// </summary>
		/// <param name="message">Messaging message which will be added to chat.</param>
		/// <returns>Identifier of chat.</returns>
		public Guid AddMessage(MessagingMessage message, out bool isNewChat) {
			Entity activeChat = string.IsNullOrEmpty(message.ChatId)
				? FindActiveChat(message)
				: GetOmnichannelChat(Guid.Parse(message.ChatId));
			if (activeChat == null) {
				message.ChannelQueueId = GetChatQueueIdFromChannel(Guid.Parse(message.ChannelId));
				isNewChat = true;
				return CreateChat(message, chat => {
					Guid chatStatus = message.IsStandBy
						? OmnichannelMessagingConsts.BotProcessingChatStatus
						: OmnichannelMessagingConsts.WaitingForProcessing;
					chat.SetColumnValue("StatusId", chatStatus);
					chat.SetColumnValue("UnprocessedMsgCount", 1);
					chat.SetColumnValue("QueueId", message.ChannelQueueId);
				});
			}
			message.ChannelQueueId = activeChat.GetTypedColumnValue<Guid>("QueueId");
			isNewChat = false;
			return UpdateChat(message, activeChat);
		}

		/// <summary>
		/// Adds outcomning message to chat.
		/// </summary>
		/// <param name="message">Messaging message which will be added to chat.</param>
		/// <returns><see cref="GetLastChatResponse"/> instance.</returns>
		public GetLastChatResponse AddOutcomingMessage(MessagingMessage message) {
			Entity activeChat = string.IsNullOrEmpty(message.ChatId)
				? FindActiveChat(message)
				: GetOmnichannelChat(Guid.Parse(message.ChatId));
			var result = new GetLastChatResponse();
			if (activeChat == null || activeChat.GetTypedColumnValue<Guid>("StatusId") == OmnichannelMessagingConsts.CompletedChatStatus) {
				var lastChat = OpenChatFromContactVerifier.CheckContactDataAndGetChatId(activeChat.GetTypedColumnValue<Guid>("ContactId"), GetChannelProvider(message.ChannelId));
				if (lastChat.Success) {
					message.ChannelQueueId = GetChatQueueIdFromChannel(Guid.Parse(message.ChannelId));
					result.LastChatId = lastChat.IsLastChatCompleted ? CreateChat(message, chat => { chat.SetColumnValue("StatusId", OmnichannelMessagingConsts.InProgressChatStatus);
						chat.SetColumnValue("OperatorId", _userConnection.CurrentUser.Id);
						chat.SetColumnValue("ContactId", activeChat.GetTypedColumnValue<Guid>("ContactId"));
						chat.SetColumnValue("AcceptDate", DateTime.UtcNow);
					}) : lastChat.LastChatId;
					result.IsLastChatCompleted = lastChat.IsLastChatCompleted;
					return result;
				} else {
					return lastChat;
				}
			}
			message.ChannelQueueId = activeChat.GetTypedColumnValue<Guid>("QueueId");
			result.LastChatId = UpdateChat(message, activeChat);
			return result;
		}

		/// <summary>
		/// Close OmnichannelChat when it is time.
		/// </summary>
		public void CloseExpiredChats() {
			var esq = GetExpiredOmnichannelChatEsq(_userConnection);
			EntityCollection chats = esq.GetEntityCollection(_userConnection);
			foreach (Entity chat in chats) {
				Log.DebugFormat("Try to close expired chat {0}", chat.GetTypedColumnValue<Guid>("Id"));
				CloseOmnichannelChat(chat, true);
			}
		}

		/// <summary>
		/// Close active chat.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		public void CloseActiveChat(Guid chatId, bool createSystemMessage = false) {
			Log.DebugFormat("Try to close chat by id {0}", chatId);
			if (TryGetChatEntity(chatId, out Entity omniChat)) {
				CloseOmnichannelChat(omniChat, createSystemMessage);
			}
		}

		/// <summary>
		/// Close chat which is transferring.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="chatIdToSkip">Chat identifier to skip.</param>
		public void CloseTransferringChat(Guid chatId, Guid chatIdToSkip) {
			if (TryGetChatEntity(chatId, out Entity omniChat)) {
				ClosePreviousChat(omniChat);
				var chatQueueId = GetChatQueueId(chatId);
				QueueDistribution.DistributeAfterClosedChat(chatQueueId, chatIdToSkip);
			}
		}

		/// <summary>
		/// Get a collection of active chats by operator identifier.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="EntityCollection"/> collection of operators chats.</returns>
		public EntityCollection GetChatsByOperator(Guid operatorId, bool applyColumns = true) {
			return InternalGetChatsByOperator(operatorId, applyColumns);
		}

		/// <summary>
		/// Get a collection of possible operator chats by identifiers.
		/// </summary>
		/// <param name="ids">Collection of IDs of distributed operator omnichats.</param>
		/// <returns><see cref="EntityCollection"/> collection of chats.</returns>
		public EntityCollection GetChatsById(List<Guid> ids, bool applyColumns = true) {
			return InternalGetChatsById(ids, applyColumns);
		}

		/// <summary>
		/// Loads <paramref name="chatOperator"/> fields from database.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		public void LoadOperatorState(ChatOperator chatOperator) {
			Select acceptedChatSelect = GetAcceptedChatsInfoQuery(_userConnection, chatOperator.UserId);
			acceptedChatSelect.ExecuteReader(reader => {
				chatOperator.ActiveChatsCount = reader.GetColumnValue<int>("Count");
				Log.DebugFormat($"Init ActiveChatsCount {chatOperator.ActiveChatsCount} for operator {chatOperator.UserId}");
				chatOperator.LastChatAcceptedDate = reader.GetColumnValue<DateTime>("LatestChat");
			});
			Select directedChatSelect = GetDirectedChatsInfoQuery(_userConnection, chatOperator.UserId);
			directedChatSelect.ExecuteReader(reader => {
				chatOperator.DirectedChats.AddIfNotExists(reader.GetColumnValue<Guid>("Id"));
			});
		}

		/// <summary>
		/// Get chat queue identifier by chat identifier.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <returns>Chat queue identifier.</returns>
		public Guid GetChatQueueId(Guid chatId) {
			var select = new Select(_userConnection).Top(1)
					.Column("QueueId")
				.From("OmniChat")
					.Where("Id").IsEqual(Column.Parameter(chatId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Get chat queue identifier by channel identifier.
		/// </summary>
		/// <param name="channelId">Channel identifier.</param>
		/// <returns>Chat queue identifier.</returns>
		public Guid GetChatQueueIdFromChannel(Guid channelId) {
			var select = new Select(_userConnection).Top(1)
				.Column("ChatQueueId")
				.From("Channel")
				.Where("Id").IsEqual(Column.Parameter(channelId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Get free chats by chat queue identifier.
		/// </summary>
		/// <param name="chatQueueId">Chat queue identifier.</param>
		/// <returns>Free chat identifier by chat queue ID.</returns>
		public List<Guid> GetFreeChatsByQueue(Guid chatQueueId) {
			var select = new Select(_userConnection)
					.Column("Id").As("ChatId")
				.From("OmniChat")
				.Where("QueueId").IsEqual(Column.Parameter(chatQueueId))
					.And("OperatorId").IsNull()
					.And("DirectedOperatorId").IsNull()
					.And("StatusId").Not().In(
				Column.Parameters(new[] {
					OmnichannelMessagingConsts.BotProcessingChatStatus,
					OmnichannelMessagingConsts.CompletedChatStatus}))
				.OrderByAsc("CreatedOn") as Select;
			return select.ExecuteEnumerable(r => r.GetColumnValue<Guid>("ChatId")).ToList();
		}

		/// <summary>
		/// Set chat status.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="chatStatus">Chat status identifier.</param>
		public void SetChatStatus(Guid chatId, Guid chatStatus) {
			if (TryGetChatEntity(chatId, out Entity omniChat)) {
				omniChat.SetColumnValue("StatusId", chatStatus);
				omniChat.Save(false);
			}
		}

		/// <summary>
		/// Mark all chat messages as processed.
		/// </summary>
		/// <param name="ChatId">Id of chat.</param>
		public void MarkChatAsRead(Guid chatId) {
			var update = new Core.DB.Update(_userConnection, "OmniChat")
				.Set("UnprocessedMsgCount", Column.Parameter(0))
				.Where("Id")
				.IsEqual(Column.Parameter(chatId));
			update.Execute();
		}

		/// <summary>
		/// Returns identifiers of related chats by the given chat identifier.
		/// </summary>
		/// <param name="chatId">Identifier of primary chat.</param>
		/// <returns>List of related chats.</returns>
		public IEnumerable<Guid> GetRelatedChatsId(Guid chatId) {
			IEnumerable<Guid> chats = FindRelatedChats(chatId);
			return chats;
		}

		/// <summary>
		/// Returns conversation by chat identifier.
		/// </summary>
		/// <param name="chatId">Identifier of chat.</param>
		/// <returns>Chat conversation.</returns>
		public IEnumerable<MessagingMessage> GetChatConversation(Guid chatId) {
			var esq = GetChatConversationEsq();
			var chat = esq.GetEntity(_userConnection, chatId);
			string conversationSerialized = chat?.GetTypedColumnValue<string>("Conversation");
			if (conversationSerialized == null) {
				return default;
			}
			return
				JsonConvert
				.DeserializeObject<List<MessagingMessage>>(conversationSerialized);
		}

		/// <summary>
		/// Create child chat for chat with specified Id.
		/// </summary>
		/// <param name="parentChatId">Id of parent chat.</param>
		/// <param name="queueId">Id of queue for chat</param>
		/// <returns></returns>
		public Guid CreateChildChat(Guid parentChatId, Dictionary<string, object> additionalColumns = default) {
			bool parentChatExists = TryGetChatEntity(parentChatId, out var parentChat);
			if (!parentChatExists) {
				Log.Error($"Can't create child chat for chat with id={parentChatId}. Parent chat doesn't exist");
				return Guid.Empty;
			}
			Guid childChatId = Guid.NewGuid();
			TryGetChatEntity(childChatId, out var childChat, true);
			childChat.SetDefColumnValues();
			childChat.SetColumnValue("Id", childChatId);
			childChat.SetColumnValue("ChannelId", parentChat.GetColumnValue("ChannelId"));
			childChat.SetColumnValue("ContactId", parentChat.GetColumnValue("ContactId"));
			childChat.SetColumnValue("ChatPreview", parentChat.GetColumnValue("ChatPreview"));
			childChat.SetColumnValue("ParentId", parentChatId);
			childChat.SetColumnValue("UnprocessedMsgCount", MessageManager.GetMessagesByChatId(parentChatId).Count());
			if (additionalColumns != null) {
				foreach (var column in additionalColumns) {
					childChat.SetColumnValue(column.Key, column.Value);
				}
			}
			childChat.Save(false);
			return childChatId;
		}

		/// <summary>
		/// Get chats with bot by channel and sender identifiers.
		/// </summary>
		/// <param name="channelId">Id of channel.</param>
		/// <param name="sender">Sender identifier.</param>
		/// <returns>List of chats guids.</returns>
		public List<Guid> GetBotProcessingChatIds(Guid channelId, string sender) {
			IEnumerable<UnifiedMessage> messages = GetMessagesByChannelId(channelId);
			return messages.Where(m => m.Sender == sender)
				.Select(m => Guid.Parse(m.ChatId)).Distinct()
				.ToList();
		}

		/// <summary>
		/// Get chats with bot by channel.
		/// </summary>
		/// <param name="channelId">Id of channel.</param>
		/// <returns>List of chats guids.</returns>
		public IEnumerable<UnifiedMessage> GetBotProcessingMessages(Guid channelId) {
			return GetMessagesByChannelId(channelId);
		}

		/// <summary>
		/// Delete unnecessary chats .
		/// </summary>
		/// <param name="chatsId">Identifiers of chats.</param>
		public void DeleteUnnecessaryChats(IEnumerable<Guid> chatsId) {
			if (chatsId.Any()) {
				Query delete = new Delete(_userConnection)
					.From("OmniChat")
					.Where("Id")
						.In(Column.Parameters(chatsId));
				delete.Execute();
			}
		}

		/// <summary>
		/// Returns operator's identifier by chat identifier
		/// </summary>
		/// <param name="chatId">Identifier of chat</param>
		/// <returns>Operator's identifier</returns>
		public Guid GetOperatorIdByChatId(Guid chatId) {
			var select = new Select(_userConnection).Top(1)
				.Column("OperatorId")
				.From("OmniChat")
				.Where("Id").IsEqual(Column.Parameter(chatId))as Select;
			return select.ExecuteScalar<Guid>();
		}

		#endregion

	}

	#endregion

}
