namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using SystemSettings = Core.Configuration.SysSettings;

	#region Class: BaseOperatorRoutingRule

	/// <summary>
	/// Class for processing base operator routing rule.
	/// </summary>
	public abstract class BaseOperatorRoutingRule: IOperatorRoutingRule
	{

		#region Properties: Protected

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		protected UserConnection UserConnection { get; set; }

		/// <summary>
		/// <see cref="OperatorSessionRepository"/> instance.
		/// </summary>
		protected readonly OperatorSessionRepository SessionRepository;

		private ChatOperatorCache _chatOperatorCache;

		/// <summary>
		/// <see cref="ChatOperatorCache"/> instance.
		/// </summary>
		protected ChatOperatorCache ChatOperatorCache {
			get {
				return _chatOperatorCache = _chatOperatorCache ?? new ChatOperatorCache(UserConnection);
			}
		}

		#endregion

		#region Properties: Public

		/// <inheritdoc cref="IOperatorRoutingRule.IsChatDistributedToAllOperators"/>
		public virtual bool IsChatDistributedToAllOperators => true;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="BaseOperatorRoutingRule"/>.
		/// </summary>
		/// <param name="userConnection"><see cref="BPMSoft.Core.UserConnection"/> instance.</param>
		protected BaseOperatorRoutingRule(UserConnection userConnection) {
			UserConnection = userConnection;
			SessionRepository = new OperatorSessionRepository(userConnection);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Checks if operator with <paramref name="operatorId"/> identifier is active.
		/// </summary>
		/// <param name="operatorId"><see cref="SysAdminUnit"/> instance identifier.</param>
		/// <returns><c>true</c> if operator is active; otherwise, <c>false</c>.</returns>
		protected bool IsOperatorActive(Guid operatorId) {
			var operatorManager = ClassFactory.Get<OperatorManager>(new ConstructorArgument("userConnection", UserConnection));
			return operatorManager.IsOperatorHasActiveSession(operatorId);
		}

		/// <summary>
		/// Checks if operator has exceeded chat limit.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		/// <returns><c>true</c> if operator has exceeded chat limit; otherwise, <c>false</c>.</returns>
		protected bool IsChatLimitExceeded(ChatOperator chatOperator) {
			int simultaneousChats = SystemSettings.GetValue(UserConnection, "SimultaneousChats", 0);
			var isSimultaneousChats = simultaneousChats > 0;
			return isSimultaneousChats
				&& chatOperator.DirectedChatsCount + chatOperator.ActiveChatsCount >= simultaneousChats;
		}

		/// <summary>
		/// Pick up and returns queue operator identifiers.
		/// </summary>
		/// <param name="chatId"><see cref="OmniChat"/> operator identifier.</param>
		/// <param name="queueId"><see cref="ChatQueue"/> instance identifier.</param>
		/// <returns>Queue operator identifiers.</returns>
		protected abstract List<Guid> PickUpFreeQueueOperators(Guid chatId, Guid queueId);

		/// <summary>
		/// Returns <see cref="OmniChat"/> operator identifier.
		/// </summary>
		/// <param name="chatId"><see cref="OmniChat"/> operator identifier.</param>
		/// <returns>�hat operator.</returns>
		protected abstract Guid GetChatOperator(Guid chatId);

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IOperatorRoutingRule.GetOperatorIds(MessagingMessage)"/>
		public List<Guid> GetOperatorIds(MessagingMessage message) {
			return GetOperatorIds(message.ChatId, message.ChannelQueueId);
		}

		/// <inheritdoc cref="IOperatorRoutingRule.GetOperatorIds(string, Guid)"/>
		public List<Guid> GetOperatorIds(string chatId, Guid queueId) {
			var parsedChatId = Guid.Parse(chatId);
			var chatOperator = GetChatOperator(parsedChatId);
			return chatOperator.IsNotEmpty()
				? new List<Guid> { chatOperator }
				: PickUpFreeQueueOperators(parsedChatId, queueId);
		}

		#endregion

	}

	#endregion
} 

