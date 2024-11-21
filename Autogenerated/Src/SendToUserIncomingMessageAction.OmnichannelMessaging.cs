using Newtonsoft.Json;
using System;
using BPMSoft.Messaging.Common;

namespace BPMSoft.Configuration.Omnichannel.Messaging
{

	#region Class: SendToUserIncomingMessageAction

	/// <summary>
	/// Represents listener on incoming message with send message to system user.
	/// </summary>
	public class SendToUserIncomingMessageListener : IIncomingMessageListener
	{

		#region Fields: Private

		private readonly MsgChannelManager _channelManager = MsgChannelManager.Instance;

		#endregion

		#region Methods: Private

		private IMsg GetChannelMessage(Guid sysAdminUnit, string messageBody) {
			return new SimpleMessage {
				Id = sysAdminUnit,
				Body = messageBody,
				Header = {
					Sender = "MessagingService",
					BodyTypeName = "System.String"
				}
			};
		}

		private void SendMessage(Guid sysAdminUnitId, string messageBody) {
			IMsgChannel channel = _channelManager.FindItemByUId(sysAdminUnitId);
			if (channel == null) {
				Console.WriteLine($"Empty channel for '{sysAdminUnitId}'");
				return;
			}
			IMsg message = GetChannelMessage(sysAdminUnitId, messageBody);
			channel.PostMessage(message);
		}

		private Guid GetRecipientAdminUnit(MessagingMessage message) {
			//TODO: implement user selection by recipent in UnifiedMessage
			return new Guid("7F3B869F-34F3-4F20-AB4D-7480A5FDF647");
		}

		#endregion

		#region Methods: Public		

		/// <inheritdoc cref="BPMSoft.Configuration.Omnichannel.Messaging.IIncomingMessageListener" />
		public void Update(MessagingMessage message) {
			Guid recipient = GetRecipientAdminUnit(message);
			SendMessage(recipient, JsonConvert.SerializeObject(message));
		}

		#endregion

	}

	#endregion

}
