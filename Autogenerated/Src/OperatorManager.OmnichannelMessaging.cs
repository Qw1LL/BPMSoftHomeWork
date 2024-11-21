namespace BPMSoft.Configuration.Omnichannel.Messaging 
{
	using global::Common.Logging;
	using System;
	using System.Linq;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Store;
	using SystemSettings = Core.Configuration.SysSettings;

	#region Class: OperatorManager

	/// <summary>
	/// Get operators for chat.
	/// </summary>
	public class OperatorManager 
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private ConcurrentDictionary<Guid, string> ChannelOperatorRoutingRules {
			get {
				return _userConnection.ApplicationCache.WithLocalCaching()
					.GetValue<ConcurrentDictionary<Guid, string>>(OmnichannelMessagingConsts.QueueOperatorRoutingRulesCacheKey) ??
					InitializeChannelOperatorRoutingRules();
			}
		}

		private readonly IDictionary<string, IOperatorRoutingRule> _rulesMap;
		private readonly ILog _log = LogManager.GetLogger("OmnichannelOperatorManager");

		private OperatorSessionRepository _sessionRepository;

		private ChatQueueOperatorRepository _chatQueueOperatorRepository;

		private ChatRepository _chatRepository;

		private ChatOperatorCache _chatOperatorCache;

		#endregion

		#region Properties: Private

		/// <summary>
		/// <see cref="ChatOperatorCache"/> instance.
		/// </summary>
		private ChatOperatorCache ChatOperatorCache { 
			get {
				return _chatOperatorCache = _chatOperatorCache ?? new ChatOperatorCache(_userConnection);
			}
		}

		/// <summary>
		/// Operator session repository instance of <see cref="OperatorSessionRepository"/> class.
		/// </summary>
		private OperatorSessionRepository SessionRepository {
			get {
				return _sessionRepository = _sessionRepository ?? new OperatorSessionRepository(_userConnection);
			}
		}

		/// <summary>
		/// Chat queue operators repository instance of <see cref="ChatQueueOperatorRepository"/> class.
		/// </summary>
		private ChatQueueOperatorRepository ChatQueueOperatorRepository {
			get {
				return _chatQueueOperatorRepository = _chatQueueOperatorRepository ?? new ChatQueueOperatorRepository(_userConnection);
			}
		}

		/// <summary>
		/// Chat repository instance of <see cref="ChatRepository"/> class.
		/// </summary>
		private ChatRepository ChatRepository {
			get {
				return _chatRepository = _chatRepository ?? new ChatRepository(_userConnection);
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="OperatorManager"/>.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public OperatorManager(UserConnection userConnection) {
			_userConnection = userConnection;
			_rulesMap = new Dictionary<string, IOperatorRoutingRule>();
		}

		#endregion

		#region Methods: Private

		private ConcurrentDictionary<Guid, string> InitializeChannelOperatorRoutingRules() {
			var channelOperatorRoutingRules = new ConcurrentDictionary<Guid, string>();
			_userConnection.ApplicationCache.WithLocalCaching()
				.SetOrRemoveValue(OmnichannelMessagingConsts.QueueOperatorRoutingRulesCacheKey,
					channelOperatorRoutingRules);
			return channelOperatorRoutingRules;
		}

		private string GetOperatorRoutingRule(Guid queueId) {
			string rule = string.Empty;
			if ((queueId != Guid.Empty) && !TryGetOperatorRoutingRuleFromCache(queueId, out rule)) {
				rule = GetOperatorRoutingRuleFromDb(queueId);
				PushRuleToCache(queueId, rule);
			}
			return rule;
		}

		private string GetOperatorRoutingRuleFromDb(Guid queueId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "ChatQueue");
			esq.UseAdminRights = false;
			var ruleCodeColumnName = esq.AddColumn("OperatorRoutingRule.Code").Name;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var queue = esq.GetEntity(_userConnection, queueId);
			return queue != null
				? queue.GetTypedColumnValue<string>(ruleCodeColumnName)
				: OmnichannelMessagingConsts.DefaultQueueOperatorRoutingRule;
		}

		private void PushRuleToCache(Guid cacheKey, string rule) {
			ChannelOperatorRoutingRules[cacheKey] = rule;
			_userConnection.ApplicationCache.WithLocalCaching()
				.SetOrRemoveValue(OmnichannelMessagingConsts.QueueOperatorRoutingRulesCacheKey, ChannelOperatorRoutingRules);
			_log.InfoFormat("Rule {0} was saved in cache", rule);
		}

		private bool TryGetOperatorRoutingRuleFromCache(Guid cacheKey, out string rule) {
			return ChannelOperatorRoutingRules.TryGetValue(cacheKey, out rule);
		}

		private IOperatorRoutingRule MapRule(string ruleName) {
			var manager = ClassFactory.Get<IOperatorRoutingRule>(ruleName,
				new ConstructorArgument("userConnection", _userConnection));
			_rulesMap.Add(ruleName, manager);
			return manager;
		}


		private IOperatorRoutingRule GetRuleInstance(string ruleName) {
			return _rulesMap.ContainsKey(ruleName) ? _rulesMap[ruleName] : MapRule(ruleName);
		}

		private IOperatorRoutingRule GetRuleByQueue(Guid queueId) {
			var operatorRoutingRuleName = GetOperatorRoutingRule(queueId);
			return GetRuleInstance(operatorRoutingRuleName);
		}

		private OperatorState GetOperatorState(Guid operatorId) {
			return operatorId != Guid.Empty
				? SessionRepository.GetOperatorState(operatorId)
				: new OperatorState {
					Id = OmnichannelMessagingConsts.OperatorState.Inactive.Id,
					Code = OmnichannelMessagingConsts.OperatorState.Inactive.Code,
					OperatorAvailable = OmnichannelMessagingConsts.OperatorState.Inactive.OperatorAvailable
				};
		}

		private Entity GetOperatorStateByCode(string code) {
			var manager = _userConnection.EntitySchemaManager.GetInstanceByName("OperatorState");
			var entity = manager.CreateEntity(_userConnection);
			if (entity.FetchFromDB("Code", code)) {
				return entity;
			}
			return null;
		}

		private string GetTimeoutJobGroupName() {
			return OmnichannelMessagingConsts.Scheduler.OperatorTimeoutJob.JobGroup;
		}

		private string GetTimeoutJobName(string chatId) {
			return string.Format(OmnichannelMessagingConsts.Scheduler.OperatorTimeoutJob.JobNameTpl, chatId);
		}

		private int GetTimeout() {
			return BPMSoft.Core.Configuration.SysSettings.GetValue<int>(_userConnection,
				OmnichannelMessagingConsts.Scheduler.OperatorTimeoutJob.TimeoutSettingCode,
				OmnichannelMessagingConsts.Scheduler.OperatorTimeoutJob.DefOperatorTimeoutInMinutes);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get operators for chat using OperatorRoutingRule.
		/// </summary>
		/// <param name="message">Message with filled ChatId and ChannelQueueId.</param>
		/// <returns>Identifiers of SysAdminUnit operators.</returns>
		public List<Guid> GetOperatorIds(MessagingMessage messagingMessage) {
			return GetOperatorIds(messagingMessage.ChatId, messagingMessage.ChannelQueueId);
		}

		/// <summary>
		/// Get operators for chat using OperatorRoutingRule.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="queueId">Channel queue identifier.</param>
		/// <returns>Identifiers of SysAdminUnit operators.</returns>
		public List<Guid> GetOperatorIds(string chatId, Guid queueId) {
			var operatorRoutingRule = GetRuleByQueue(queueId);
			var operators = operatorRoutingRule.GetOperatorIds(chatId, queueId);
			_log.DebugFormat("Rule {0} of channel queue {1} returns operators Ids: {2}",
				operatorRoutingRule.GetType().Name, queueId, string.Join(", ", operators));
			return operators;
		}

		/// <summary>
		/// Gets all possible chats by operator identifier.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="EntityCollection"/> collection of omnichats for operator.</returns>
		public EntityCollection GetChatsByOperator(Guid operatorId, bool applyColumns = true) {
			var activeOperatorChats = ChatRepository.GetChatsByOperator(operatorId, applyColumns);
			var cacheOperator = ChatOperatorCache.GetOperator(operatorId);
			if (cacheOperator != null && cacheOperator.Active && cacheOperator.DirectedChatsCount > 0) {
				var directedChats = ChatRepository.GetChatsById(cacheOperator.DirectedChats, applyColumns);
				directedChats.AddRangeIfNotExists(activeOperatorChats);
				return directedChats;
			}
			string reason = cacheOperator == null ? "is null" : $"has {cacheOperator.DirectedChatsCount} directed chats; status Active = {cacheOperator.Active}";
			_log.DebugFormat($"GetChatsByOperator - cache operator {operatorId} {reason}");
			return activeOperatorChats;
		}

		/// <summary>
		/// Does the operator have active sessions.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns>If operator has active session returns <c>true</c> otherwise <c>false</c>.</returns>
		public bool IsOperatorHasActiveSession(Guid operatorId) {
			var operatorState = GetOperatorState(operatorId);
			return operatorState.OperatorAvailable;
		}

		/// <summary>
		/// Get the current operator state code.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="string"/> current operator state code.</returns>
		public string GetOperatorStateCode(Guid operatorId) {
			var operatorState = GetOperatorState(operatorId);
			return operatorState != null
				? operatorState.Code
				: OmnichannelMessagingConsts.OperatorState.Inactive.Code;
		}

		/// <summary>
		/// Get the value of the operator's participation in the chat queue.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns>If operator exists in chat queue returns <c>true</c> otherwise <c>false</c>.</returns>
		public bool IsOperatorExistsInChatQueue(Guid operatorId) {
			var allOperators = ChatQueueOperatorRepository.GetAllOperatorIds();
			return allOperators.Contains(operatorId);
		}

		/// <summary>
		/// Change operator state.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <param name="stateCode">Required status code.</param>
		public void ChangeOperatorState(Guid operatorId, string stateCode) {
			var operatorState = GetOperatorStateByCode(stateCode);
			SessionRepository.CreateOperatorSession(operatorId, operatorState.PrimaryColumnValue);
			var operatorNotifier = new ChatOperatorNotifier(_userConnection);
			operatorNotifier.StatusChangeNotify(operatorId, stateCode);
		}

		/// <summary>
		/// Gets queue identifier by <paramref name="operatorId"/>.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="List<Guid>"/> collection of queue identifiers.</returns>
		public List<Guid> GetQueuesByOperator(Guid operatorId) {
			return ChatQueueOperatorRepository.GetQueuesByOperator(operatorId);
		}

		/// <summary>
		/// Sets handlers, that will switch <paramref name="operatorIds"/> state to inactive,
		/// if <paramref name="chatId"/> not accepted.
		/// </summary>
		/// <param name="operatorIds">Chat operators identifiers collection.</param>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="queueId">Channel queue identifier.</param>
		public void SetOperatorsTimeoutHandler(IEnumerable<Guid> operatorIds, string chatId, Guid queueId) {
			var operatorRoutingRule = GetRuleByQueue(queueId);
			var operatorTimeout = GetTimeout();
			if (operatorRoutingRule.IsChatDistributedToAllOperators || operatorTimeout <= 0) {
				return;
			}
			var scheduler = ClassFactory.Get<IAppSchedulerWraper>();
			var jobGroup = GetTimeoutJobGroupName();
			RemoveOperatorTimeoutHandler(chatId);
			var jobName = GetTimeoutJobName(chatId);
			var parameters = new Dictionary<string, object> {
				{ "OperatorIds", operatorIds },
				{ "ChatId", chatId },
				{ "QueueId", queueId }
			};
			var startDate = DateTime.UtcNow.AddMinutes(operatorTimeout);
			scheduler.CreateAndScheduleJob<ChatOperatorTimeoutJob>(jobName, jobGroup, _userConnection, parameters,
				false, TimeZoneInfo.Utc.Id, true, startDate, DateTime.MinValue, null);
		}

		/// <summary>
		/// Removes handlers, that will switch operator state to inactive,
		/// if <paramref name="chatId"/> not accepted.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		public void RemoveOperatorTimeoutHandler(string chatId) {
			var jobGroup = GetTimeoutJobGroupName();
			var jobName = GetTimeoutJobName(chatId);
			var scheduler = ClassFactory.Get<IAppSchedulerWraper>();
			if (scheduler.DoesJobExist(jobName, jobGroup)) {
				scheduler.RemoveJob(jobName, jobGroup);
			}
		}

		/// <summary>
		/// Calls chat distribution for <paramref name="chatId"/>.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="queueId">Channel queue identifier.</param>
		/// <returns><c>True</c> if chat distributed to operators. Returns <c>false</c> otherwise.</returns>
		public bool TryReDistributeOperatorChat(string chatId, Guid queueId) {
			var operatorRoutingRule = GetRuleByQueue(queueId);
			if (operatorRoutingRule.IsChatDistributedToAllOperators) {
				return false;
			}
			var chatProvider = new OmnichannelChatProvider(_userConnection);
			return chatProvider.DistributeChat(chatId, queueId);
		}

		#endregion

	}

	#endregion

}

