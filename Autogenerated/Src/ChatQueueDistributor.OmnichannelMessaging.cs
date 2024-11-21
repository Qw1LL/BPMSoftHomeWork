namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Linq;
	using BPMSoft.Core;

	#region Class: ChatQueueDistribution
 
	/// <summary>
	/// Represents a mechanism for distributing chats from the queue.
	/// </summary>
	public class ChatQueueDistributor
	{

		#region Fields: Private

		/// <summary>
		/// <see cref="ChatRepository"/> instance.
		/// </summary>
		private readonly ChatRepository _chatRepository;

		/// <summary>
		/// <see cref="OmnichannelChatProvider"/> instance.
		/// </summary>
		private readonly OmnichannelChatProvider _chatProvider;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ChatQueueDistributor(UserConnection userConnection) {
			_chatRepository = new ChatRepository(userConnection);
			_chatProvider = new OmnichannelChatProvider(userConnection);
		}

		#endregion

		#region Methods: Public		

		/// <summary>
		/// Distribute chats to operators by <paramref name="chatQueueId"/>.
		/// </summary>
		/// <param name="chatQueueId">Chat queue identifier.</param>
		public void Distribute(Guid chatQueueId) {
			var freeChats = _chatRepository.GetFreeChatsByQueue(chatQueueId);
			foreach (var freeChatId in freeChats) {
				if (!_chatProvider.DistributeChat(freeChatId.ToString(), chatQueueId)) {
					break;
				}
			}
		}

		/// <summary>
		/// Distribute after closed chat to operator by queue from <paramref name="chatQueueId"/>.
		/// </summary>
		/// <param name="chatQueueId">Chat queue identifier.</param>
		/// <param name="chatId">Chat identifier to skip.</param>
		public void DistributeAfterClosedChat(Guid chatQueueId, Guid chatId) {
			var freeChats = _chatRepository.GetFreeChatsByQueue(chatQueueId);
			var chatsToDistribute = freeChats.Where(x => !x.Equals(chatId));
			foreach (var freeChatId in chatsToDistribute) {
				if (!_chatProvider.DistributeChat(freeChatId.ToString(), chatQueueId, false)) {
					break;
				}
			}
		}

		/// <summary>
		/// Distribute chats to operators by queue from <paramref name="chatId"/>.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		public void DistributeQueueChatsByChatId(Guid chatId) {
			var chatQueueId = _chatRepository.GetChatQueueId(chatId);
			Distribute(chatQueueId);
		}

		#endregion

	}

	#endregion

}
