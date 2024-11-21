namespace BPMSoft.Configuration {
	using System;
	using BPMSoft.Core.DB;
	using BPMSoft.Common;
	using BPMSoft.Core;

	#region Class: ConversationProvider

	/// <summary>
	/// Implements logging of execution deduplication operations.
	/// </summary>
	public class ConversationProvider : IConversationProvider {

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		public ConversationProvider(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Logged information about beginning execution of procedure.
		/// </summary>
		/// <param name="procedureName">Procedure name.</param>
		/// <returns>Conversation id.</returns>
		public Guid BeginConversation(string procedureName) {
			Guid conversationId = Guid.NewGuid();
			var insert = new Insert(_userConnection).Into("DeduplicateExecLog")
				.Set("Id", Column.Parameter(conversationId))
				.Set("ProcedureName", Column.Parameter(procedureName))
				.Set("CreatedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ExecutedOn", Column.Parameter(DateTime.UtcNow));
			insert.Execute();
			return conversationId;
		}

		/// <summary>
		/// Logged information about completion of the procedure.
		/// </summary>
		/// <param name="conversationId">Conversation id.</param>
		public void EndConversation(Guid conversationId) {
			var update = new Update(_userConnection, "DeduplicateExecLog")
				.Set("CompletedOn", Column.Parameter(DateTime.UtcNow))
				.Where("Id").IsEqual(Column.Parameter(conversationId));
			update.Execute();
		}

		/// <summary>
		/// Logged information about error during execution of procedure.
		/// </summary>
		/// <param name="conversationId">Conversation id.</param>
		/// <param name="errorCode">Error id.</param>
		/// <param name="errorMessage">Error message.</param>
		public void EndConversationWithError(Guid conversationId, int errorCode, string errorMessage) {
			var update = new Update(_userConnection, "DeduplicateExecLog")
				.Set("CompletedOn", Column.Parameter(DateTime.MinValue))
				.Set("SqlErrorCode", Column.Parameter(errorCode))
				.Set("SqlErrorMessage", Column.Parameter(errorMessage))
				.Where("Id").IsEqual(Column.Parameter(conversationId));
			update.Execute();
		}

		#endregion

	}

	#endregion

}
