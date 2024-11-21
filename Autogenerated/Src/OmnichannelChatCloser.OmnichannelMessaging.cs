namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using Core;
	using System.Collections.Generic;

	#region Class : OmnichannelChatCloser

	/// <summary>
	/// Represents a OmnichannelChat Closer job.
	/// </summary>
	public class OmnichannelChatCloser : IJobExecutor
	{
		#region Fields : Private

		private ChatRepository _repository;

		#endregion

		#region Methods : Private

		private ChatRepository GetChatRepository(UserConnection userConnection) {
			return _repository ?? (_repository = new ChatRepository(userConnection));
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Close OmnichannelChat when it is time.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			var chatRepository = GetChatRepository(userConnection);
			chatRepository.CloseExpiredChats();
		}

		#endregion

	}

	#endregion

}
