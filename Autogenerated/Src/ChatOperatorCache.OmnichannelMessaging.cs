namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Store;

	#region Class: ChatOperatorCache

	/// <summary>
	/// Chat operator cache.
	/// </summary>
	public class ChatOperatorCache {

		#region Constants: Private

		/// <summary>
		/// Application cache key for chat operators list.
		/// </summary>
		private const string _operatorsCacheKey = "OmniChatOperators";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="ICacheStore"/> implementation instance.
		/// Represents application level cache.
		/// </summary>
		private readonly ICacheStore _applicationCache;

		/// <summary>
		/// <see cref="ChatRepository"/> instance.
		/// </summary>
		private readonly ChatRepository _chatRepository;

		/// <summary>
		/// <see cref="ChatQueueOperatorRepository"/> instance.
		/// </summary>
		private readonly ChatQueueOperatorRepository _chatQueueOperatorRepository;

		/// <summary>
		/// <see cref="OperatorSessionRepository"/> instance.
		/// </summary>
		private readonly OperatorSessionRepository _operatorSessionRepository;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ChatOperatorCache"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ChatOperatorCache(UserConnection userConnection) {
			_applicationCache = userConnection.ApplicationCache;
			_chatRepository = new ChatRepository(userConnection, this);
			_chatQueueOperatorRepository = new ChatQueueOperatorRepository(userConnection);
			_operatorSessionRepository = new OperatorSessionRepository(userConnection, this);
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Loads operators from storage and saves in cache.
		/// </summary>
		/// <returns>Cached <see cref="ChatOperator"/> list.</returns>
		private List<ChatOperator> InitOperatorsCache() {
			var collection = LoadOperators();
			_applicationCache[_operatorsCacheKey] = collection;
			return collection;
		}

		/// <summary>
		/// Loads operators from storage.
		/// </summary>
		/// <returns>Loaded <see cref="ChatOperator"/> list.</returns>
		private List<ChatOperator> LoadOperators() {
			var collection = new List<ChatOperator>();
			var allOperators = _chatQueueOperatorRepository.GetAllOperatorIds();
			allOperators.Distinct().ForEach(userId => {
				var chatOperator = collection.FirstOrDefault(o => o.UserId.Equals(userId));
				if (chatOperator == null) {
					chatOperator = CreateChatOperator(userId);
					collection.Add(chatOperator);
				}
			});
			return collection;
		}

		/// <summary>
		/// Creates <see cref="ChatOperator"/> instance.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="ChatOperator"/> instance.</returns>
		private ChatOperator CreateChatOperator(Guid operatorId) {
			var chatOperator = new ChatOperator(operatorId);
			FillOperatorQueues(chatOperator);
			FillChatParameters(chatOperator);
			FillOperatorState(chatOperator);
			return chatOperator;
		}

		/// <summary>
		/// Loads <paramref name="chatOperator"/> queues identifiers.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		private void FillOperatorQueues(ChatOperator chatOperator) {
			_chatQueueOperatorRepository.LoadOperatorState(chatOperator);
		}

		/// <summary>
		/// Loads <paramref name="chatOperator"/> chat parameters.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		private void FillChatParameters(ChatOperator chatOperator) {
			_chatRepository.LoadOperatorState(chatOperator);
		}

		/// <summary>
		/// Loads <paramref name="chatOperator"/> state.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		private void FillOperatorState(ChatOperator chatOperator) {
			_operatorSessionRepository.LoadOperatorState(chatOperator);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns <see cref="ChatOperator"/> instance. Loads operators cache if empty.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="ChatOperator"/> instance.</returns>
		public ChatOperator GetOperator(Guid operatorId) {
			var operatorsList = GetOperatorsCache();
			return operatorsList.FirstOrDefault(o => o.UserId.Equals(operatorId));
		}

		/// <summary>
		/// Returns cached chat operators list.
		/// </summary>
		/// <returns><see cref="ChatOperator"/> list.</returns>
		public List<ChatOperator> GetOperatorsCache() {
			var operatorsList = _applicationCache[_operatorsCacheKey] as List<ChatOperator>;
			if (operatorsList.IsNullOrEmpty()) {
				operatorsList = InitOperatorsCache();
			}
			return operatorsList;
		}

		/// <summary>
		/// Updates operator instance in cache.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		public void UpdateOperatorInCache(ChatOperator chatOperator) {
			var operatorsList = GetOperatorsCache();
			operatorsList.RemoveAll(o => o.UserId.Equals(chatOperator.UserId));
			operatorsList.Add(chatOperator);
			_applicationCache[_operatorsCacheKey] = operatorsList;
		}

		/// <summary>
		/// Updates operator accepted chats count in cache.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <param name="diff">Chats count differnse.</param>
		public void UpdateActiveChatsCount(Guid operatorId, int diff) {
			ChatOperator chatOperator = GetOperator(operatorId);
			if (chatOperator != null) {
				chatOperator.ActiveChatsCount = Math.Max(chatOperator.ActiveChatsCount + diff, 0);
				chatOperator.LastChatAcceptedDate = diff > 0 ? DateTime.UtcNow : chatOperator.LastChatAcceptedDate;
				UpdateOperatorInCache(chatOperator);
			}
		}

		/// <summary>
		/// Add operator directed chat in cache.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="operatorId">Operator identifier.</param>
		public void AddDirectedChat(Guid chatId, Guid operatorId) {
			ChatOperator chatOperator = GetOperator(operatorId);
			if (chatOperator != null) {
				chatOperator.DirectedChats.AddIfNotExists(chatId);
				UpdateOperatorInCache(chatOperator);
			}
		}

		/// <summary>
		/// Remove operator directed chat from cache.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="operatorId">Operator identifier.</param>
		public void RemoveDirectedChat(Guid chatId, Guid operatorId = default) {
			List<ChatOperator> operators = operatorId.IsNotEmpty()
				? new List<ChatOperator> { GetOperator(operatorId) }
				: GetOperatorsCache();
			operators.Where(o => o != null && o.DirectedChats.Contains(chatId)).ToList()
				.ForEach(o => {
					o.DirectedChats.Remove(chatId);
					UpdateOperatorInCache(o);
				});	
		}

		/// <summary>
		/// Clears operators cache.
		/// </summary>
		public void ClearCache() {
			_applicationCache.Remove(_operatorsCacheKey);
		}

		#endregion

	}

	#endregion

}
