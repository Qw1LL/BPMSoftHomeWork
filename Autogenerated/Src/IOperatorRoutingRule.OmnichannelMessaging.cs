namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;

	#region Interface: IOperatorRoutingRule

	public interface IOperatorRoutingRule
	{

		#region Properties: Public

		/// <summary>
		/// Is chat distributed to all avaliable operators flag.
		/// If value <c>false</c> chat redistribution logic will be applied.
		/// </summary>
		bool IsChatDistributedToAllOperators { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get operators for chat using specific logic for current OperatorRoutingRule.
		/// </summary>
		/// <param name="message">Message with filled ChatId and ChannelQueueId.</param>
		/// <returns>Identifiers of SysadminUnit operators.</returns>
		List<Guid> GetOperatorIds(MessagingMessage message);

		/// <summary>
		/// Get operators for chat using specific logic for current OperatorRoutingRule.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="queueId">Channel queue identifier.</param>
 		/// <returns>Identifiers of SysadminUnit operators.</returns>
		List<Guid> GetOperatorIds(string chatId, Guid queueId);

		#endregion

	}

	#endregion

}

