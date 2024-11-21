namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;

	#region Class: ChatLocksRepository

	/// <summary>
	/// Class for manage chats dependent quick lock operations in cache.
	/// </summary>
	public class ChatLocksRepository
	{

		#region Constants: Private

		private const string ChatLockCacheKeyPrefix = "Omni_ChatLock_";
		private const string ChatQueueCacheKeyPrefix = "Omni_ChatQueue_";

		#endregion

		#region Constructors: Public

		public ChatLocksRepository(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection {
			get; set;
		}

		#endregion

		#region Methods: Private

		private string GetChatLockCacheKey(string channelId, string senderId) {
			return $"{ChatLockCacheKeyPrefix}{channelId}_{senderId}";
		}

		private string GetChatQueueCacheKey(string channelId, string senderId) {
			return $"{ChatQueueCacheKeyPrefix}{channelId}_{senderId}";
		}

		#endregion

		#region Methods: Internal

		/// <summary>
		/// Tries to obtain chat lock in cache.
		/// </summary>
		/// <param name="channelId">Id of chat channel.</param>
		/// <param name="contactId">Id of chat contact.</param>
		/// <param name="lockAcquired">"true" if lock was acquired in this try. "false" if chat was already locked.</param>
		internal void TryLockChat(string channelId, string senderId, out bool lockAcquired) {
			string cacheKey = GetChatLockCacheKey(channelId, senderId);
			if (UserConnection.ApplicationCache[cacheKey] == null) {
				UserConnection.ApplicationCache[cacheKey] = true;
				lockAcquired = true;
			} else {
				lockAcquired = false;
			}
		}

		/// <summary>
		/// Release chat lock in cache.
		/// </summary>
		/// <param name="channelId">Id of chat channel.</param>
		/// <param name="contactId">Id of chat contact.</param>
		internal void ReleaseChatLock(string channelId, string senderId) {
			string cacheKey = GetChatLockCacheKey(channelId, senderId);
			UserConnection.ApplicationCache.Remove(cacheKey);
		}

		/// <summary>
		/// Enqueue message in waiting chat queue in cache.
		/// </summary>
		/// <param name="channelId">Id of chat channel.</param>
		/// <param name="contactId">Id of chat contact.</param>
		/// <param name="message">Message to enqueue.</param>
		internal void EnqueueMessage(string channelId, string senderId, Object message) {
			string cacheKey = GetChatQueueCacheKey(channelId, senderId);
			var messagesCollection = UserConnection.ApplicationCache[cacheKey] as List<object> ?? new List<object>();
			messagesCollection.Add(message);
			UserConnection.ApplicationCache[cacheKey] = messagesCollection;
		}

		/// <summary>
		/// Dequeue all messages from waiting chat queue in cache. Also flushes queue in cache.
		/// </summary>
		/// <param name="channelId">Id of chat channel.</param>
		/// <param name="contactId">Id of chat channel.</param>
		/// <returns>List of dequeued messages.</returns>
		internal List<object> DequeueLockedChatsQueue(string channelId, string senderId) {
			string cacheKey = GetChatQueueCacheKey(channelId, senderId);
			var messagesCollection = (List<object>)UserConnection.ApplicationCache[cacheKey];
			if (messagesCollection != null) {
				UserConnection.ApplicationCache.Remove(cacheKey);
			}
			return messagesCollection;
		}

		#endregion

	}

	#endregion

}
