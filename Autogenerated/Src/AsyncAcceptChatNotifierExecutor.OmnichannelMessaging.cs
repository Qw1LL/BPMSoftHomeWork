namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;

	#region Class : AsyncAcceptChatNotifier

	/// <summary>
	/// Represents an asynchronous chat notifier.
	/// </summary>
	public class AsyncAcceptChatNotifierExecutor : IJobExecutor
	{

		#region Methods : Public

		/// <summary>
		/// Notifies operators about chats count asynchronously.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			if (parameters == null) {
				throw new ArgumentNullOrEmptyException("parameters can't be null");
			}
			List<Guid> operators = parameters.GetValue("operators", new List<Guid>());
			var notifier = new ChatOperatorNotifier(userConnection);
			foreach (var operatorId in operators) {
				notifier.UnreadChatsCountNotify(operatorId);
			}
		}

		#endregion

	}

	#endregion

}
