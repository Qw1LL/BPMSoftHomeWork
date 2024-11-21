namespace BPMSoft.Configuration
{
	using System;

	/// <summary>
	/// Represents the SendingEmailProgressRepository contract.
	/// </summary>
	public interface ISendingEmailProgressRepository
	{

		#region Methods: Public

		void IncrementPreparedRecipients(Guid emailId, int preparedToSendCount);

		void IncrementProcessedRecipients(Guid emailId, int sendingCount);

		void IncrementReceivedInitialResponses(Guid emailId);

		#endregion

	}
}

