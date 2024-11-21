namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;

	#region Class: ChatOperatorTimeoutJob 

	/// <summary>
	/// Switch chat operators state to inactive.
	/// Called after chat accept timeout.
	/// </summary>
	public class ChatOperatorTimeoutJob : IJobExecutor
	{

		#region Methods: Public

		/// <inheritdoc cref="IJobExecutor.Execute(UserConnection, IDictionary{string, object})"/>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			var operatorIds = (IEnumerable<Guid>)parameters["OperatorIds"];
			var chatId = (string)parameters["ChatId"];
			var operatorManager = new OperatorManager(userConnection);
			operatorIds.ForEach(operatorId => {
				operatorManager.ChangeOperatorState(operatorId, OmnichannelMessagingConsts.OperatorState.Inactive.Code);
			});
			var operatorNotifier = new ChatOperatorNotifier(userConnection);
			operatorNotifier.AcceptChatNotify(operatorIds.ToList(), Guid.Parse(chatId));
			var queueId = (Guid)parameters["QueueId"];
			operatorManager.TryReDistributeOperatorChat(chatId, queueId);
		}

		#endregion

	}

	#endregion

}
