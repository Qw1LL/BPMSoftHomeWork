using System;

namespace BPMSoft.Configuration {

	#region Interface: IActionLocker

	/// <summary>
	/// Controls access to execution of operations.
	/// </summary>
	public interface IActionLocker {

		/// <summary>
		/// Lock/unlock execution of operations.
		/// </summary>
		/// <param name="conversationId">Conversation id.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="operationId">Deduplicat operation id.</param>
		/// <param name="isLock">Lock state.</param>
		void SetLockState(Guid conversationId, string schemaName, Guid operationId, bool isLock);

		/// <summary>
		/// Checks ability execute of operation.
		/// </summary>
		/// <param name="operationId">Deduplicat operation id.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <returns>Access to execution of operations.</returns>
		bool CanExecute(Guid operationId, string schemaName);

	}

	#endregion

}

