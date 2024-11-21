namespace BPMSoft.Configuration
{
	using OmnichannelMessaging;
	using System;
	using BPMSoft.Configuration.Omnichannel.Messaging;
	using BPMSoft.Core;
	using MessageType = OmnichannelProviders.Domain.Entities.MessageType;
	using global::Common.Logging;
	using BPMSoft.Core.DB;

	#region Class: BaseChatTransferProvider

	/// <summary>
	/// Represents common functionality of transferring chat.
	/// </summary>
	public abstract class BaseChatTransferProvider
	{

		#region Fields: Protected

		protected readonly UserConnection UserConnection;
		protected readonly MessagingMessage Message;
		protected readonly Guid ChatId;

		#endregion

		#region Properties: Private

		private ILog _log;
		protected ILog Log => _log ?? (_log = LogManager.GetLogger("OmnichannelChatTransfer"));

		private ChatRepository _chatRepository;
		protected ChatRepository ChatRepository => _chatRepository ?? (_chatRepository = new ChatRepository(UserConnection));

		private ChatQueueDistributor _chatQueueDistributor;
		protected ChatQueueDistributor ChatQueueDistributor => _chatQueueDistributor ?? (_chatQueueDistributor = new ChatQueueDistributor(UserConnection));

		private ChatOperatorNotifier _notifier;
		protected ChatOperatorNotifier Notifier => _notifier ?? (_notifier = new ChatOperatorNotifier(UserConnection));

		private MessageManager _manager;
		protected MessageManager Manager => _manager ?? (_manager = new MessageManager(UserConnection));

		private OmnichannelChatProvider _omnichannelChatProvider;
		protected OmnichannelChatProvider OmnichannelChatProvider => _omnichannelChatProvider ?? (_omnichannelChatProvider = new OmnichannelChatProvider(UserConnection));

		private ChatQueueRepository _chatQueueRepository;
		protected ChatQueueRepository ChatQueueRepository => _chatQueueRepository ?? (_chatQueueRepository = new ChatQueueRepository(UserConnection));

		#endregion

		#region Contructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="BaseChatTransferProvider"/>
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="message">Message template to be published.</param>
		public BaseChatTransferProvider(UserConnection userConnection, MessagingMessage message) {
			UserConnection = userConnection;
			Message = message;
			ChatId = Guid.Parse(Message.ChatId);
		}

		#endregion

		#region Methods: Private

		private long GetCurrentTime() {
			return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
		}

		#endregion

		#region Methods: Protected

		protected ChatMessage GetChatSystemMessage(MessagingMessage message) {
			return new ChatMessage() {
				Text = message.Message,
				Type = message.MessageType,
				Time = OmnichannelChatProvider.GetTimeInUserTimeZone(message.Timestamp).ToString("yyyy'-'MM'-'ddTHH':'mm':'ss"),
				Author = new ChatContact() {
					Id = UserConnection.CurrentUser.Id
				},
				Direction = OmnichannelProviders.Domain.Entities.MessageDirection.Outcoming
			};
		}

		protected MessagingMessage GetSystemMessage(string messageText) {
			var systemMessage = new MessagingMessage {
				Message = messageText,
				ChatId = ChatId.ToString(),
				MessageType = MessageType.System,
				Timestamp = GetCurrentTime(),
				Recipient = Message.Recipient,
				Sender = Message.Sender,
				MessageDirection = OmnichannelProviders.Domain.Entities.MessageDirection.Outcoming,
				ChannelId = Message.ChannelId,
				Source = Message.Source
			};
			return systemMessage;
		}

		protected void SetChatPreview(Guid chatId, string message) {
			new Update(UserConnection, "OmniChat")
				.Set("ChatPreview", Column.Parameter(message))
				.Where("Id").IsEqual(Column.Parameter(chatId))
				.Execute();
		}

		#endregion

	}

	#endregion

}

