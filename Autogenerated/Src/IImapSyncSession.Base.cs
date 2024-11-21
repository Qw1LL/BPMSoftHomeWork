namespace BPMSoft.Mail
{
    using System;

	#region Interface: IImapSyncSession

	/// <summary>
	/// Provides methods for IMAP synchronization interaction.
	/// </summary>
	public interface IImapSyncSession: IDisposable
	{
		#region Properties: Public

		/// <summary>
		/// Remote change items count.
		/// </summary>
		int RemoteChangesCount { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Starts imap mail synchronization session.
		/// </summary>
		void SyncImapMail();

		#endregion

	}

	#endregion

}
