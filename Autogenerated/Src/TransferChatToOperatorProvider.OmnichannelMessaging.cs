namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Omnichannel.Messaging;
	using BPMSoft.Core;

	/// <summary>
	/// Represents functionality of transferring chat to operator.
	/// </summary>
	public class TransferChatToOperatorProvider : BaseChatTransferProvider
	{

		#region Properties: Private

		private ChatOperatorCache _chatOperatorCache;
		private ChatOperatorCache OperatorCache => _chatOperatorCache ?? (_chatOperatorCache = new ChatOperatorCache(UserConnection));

		#endregion

		#region Methods: Private

		private string GetLczTextMessage(Guid chatId, Guid newChatId) {
			(string operatorName, string directedOperatorName) = OmnichannelChatProvider.GetOperatorAndDirectedOperatorNameByChatId(chatId, newChatId);
			return string.Format(new LocalizableString(UserConnection.Workspace.ResourceStorage, "TransferChatToOperatorProvider",
				"LocalizableStrings.ChatTransferredToOperator.Value"), operatorName, directedOperatorName);
		}

		private void TransferToOperator(Guid operatorId, Guid chatId) {
			string transferredChatId = chatId.ToString();
			OperatorCache.UpdateActiveChatsCount(operatorId, 1);
			Notifier.NewTransferredChatNotify(operatorId, chatId);
			Notifier.NewUnreadMessageNotify(new List<Guid> { operatorId }, transferredChatId);
			var message = OmnichannelChatProvider.GetChatMessages(chatId).LastOrDefault();
			Notifier.NewConversationMessageNotify(new List<Guid> { operatorId }, transferredChatId, message);
			Notifier.UnreadChatsCountNotify(new List<Guid> { operatorId });
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="TransferChatToOperatorProvider"/>
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="message">Message template to be published.</param>
		public TransferChatToOperatorProvider(UserConnection userConnection, MessagingMessage message) : base(userConnection, message) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Transfers chat to operator.
		/// </summary>
		/// <param name="operatorId">Identifier of new operator.</param>
		/// <returns>Result of chat transferring and new chat identifier.</returns>
		public (bool, Guid) Transfer(Guid operatorId) {
			var columns = new Dictionary<string, object> {
				{ "OperatorId", operatorId },
				{ "UnprocessedMsgCount", 1 },
				{ "StatusId", OmnichannelMessagingConsts.InProgressChatStatus }
			};
			Guid newChatId = ChatRepository.CreateChildChat(ChatId, columns);
			if (newChatId == Guid.Empty) {
				return (false, newChatId);
			}
			try {
				string message = GetLczTextMessage(ChatId, newChatId);
				var systemMessage = GetSystemMessage(message);
				ChatRepository.AddMessage(systemMessage, out _);
				Manager.AddSystemMessage(systemMessage);
				ChatRepository.CloseTransferringChat(ChatId, newChatId);
				SetChatPreview(newChatId, message);
				TransferToOperator(operatorId, newChatId);
				Notifier.NewSystemMessageNotify(UserConnection.CurrentUser.Id, ChatId, GetChatSystemMessage(systemMessage));
			} catch (Exception ex) {
				Log.Error($"An error occurred while transferring Chat {ChatId} to Operator {operatorId}. Error {ex.Message}");
				return (false, newChatId);
			}
			Log.Debug($"Chat: {ChatId} was transferred to Operator {operatorId}.");
			return (true, newChatId);
		}

		#endregion

	}

}

