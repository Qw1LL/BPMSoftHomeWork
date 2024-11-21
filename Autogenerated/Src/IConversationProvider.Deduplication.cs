using System;

namespace BPMSoft.Configuration {

	#region Interface: IConversationProvider

	/// <summary>
	/// Implements logging of execution of procedure.
	/// </summary>
	public interface IConversationProvider {

		/// <summary>
		/// Logged information about beginning execution of procedure.
		/// </summary>
		/// <param name="procedureName">Procedure name.</param>
		/// <returns>Conversation id.</returns>
		Guid BeginConversation(string procedureName);

		/// <summary>
		/// Logged information about completion of the procedure.
		/// </summary>
		/// <param name="conversationId">Conversation id.</param>
		void EndConversation(Guid conversationId);

		/// <summary>
		/// Logged information about error during execution of procedure.
		/// </summary>
		/// <param name="conversationId">Conversation id.</param>
		/// <param name="errorCode">Error id.</param>
		/// <param name="errorMessage">Error message.</param>
		void EndConversationWithError (Guid conversationId, int errorCode, string errorMessage);
	}

	#endregion
}

