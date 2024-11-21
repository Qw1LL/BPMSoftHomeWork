namespace BPMSoft.Configuration {
	using System;
	using BPMSoft.Core.DB;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;

	#region Class: DeduplicationActionLocker

	/// <summary>
	/// Controls access to execution of operations deduplication.
	/// </summary>
	public class DeduplicationActionLocker : IActionLocker {

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		public DeduplicationActionLocker(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Lock/unlock execution of operations.
		/// </summary>
		/// <param name="conversationId">Conversation id.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="operationId">Deduplicat operation id.</param>
		/// <param name="isLock">Lock state.</param>
		public void SetLockState(Guid conversationId, string schemaName, Guid operationId, bool isLock) {
			Guid lockId;
			var select = new Select(_userConnection)
				.Column("Id").From("DeduplicateExecLocker")
				.Where("EntitySchemaName").IsEqual(Column.Parameter(schemaName))
				.And("OperationId").IsEqual(Column.Parameter(operationId)) as Select;
			lockId = select.ExecuteScalar<Guid>();
			if (lockId.IsNotEmpty()) {
				var update = new Update(_userConnection, "DeduplicateExecLocker")
					.Set("IsInProgress", Column.Parameter(isLock))
					.Set("ConversationId", Column.Parameter(conversationId))
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Where("Id").IsEqual(Column.Parameter(lockId));
				update.Execute();
			} else {
				var insert = new Insert(_userConnection).Into("DeduplicateExecLocker")
					.Set("CreatedOn", Column.Parameter(DateTime.UtcNow))
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Set("EntitySchemaName", Column.Parameter(schemaName))
					.Set("OperationId", Column.Parameter(operationId))
					.Set("IsInProgress", Column.Parameter(isLock))
					.Set("ConversationId", Column.Parameter(conversationId));
				insert.Execute();
			}
		}

		/// <summary>
		/// Checks ability execute of operation.
		/// </summary>
		/// <param name="operationId">Deduplicat operation id.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <returns>Access to execution of operations.</returns>
		public bool CanExecute(Guid operationId, string schemaName) {
			var select = new Select(_userConnection)
				.Column("Id").From("DeduplicateExecLocker")
				.Where("EntitySchemaName").IsEqual(Column.Parameter(schemaName))
				.And("OperationId").IsEqual(Column.Parameter(operationId))
				.And("IsInProgress").IsEqual(Column.Parameter(true)) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					return !reader.Read();
				}
			}
		}

		#endregion

	}

	#endregion

}
