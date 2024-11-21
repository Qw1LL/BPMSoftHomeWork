namespace BPMSoft.Configuration.ESN
{
	using System;

	#region  Interface: ISocialMentionExecutor

	/// <summary>
	/// Provides methods for work with user mentions.
	/// </summary>
	public interface ISocialMentionExecutor {

		#region Methods: Public

		/// <summary>
		/// Save mention about users that mentions in the current message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <param name="message">Message text.</param>
		void MentionContacts(Guid messageId, string message);

		#endregion

	}

	#endregion
}
