namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Interface: ITestMessageProvider

	/// <summary>
	/// Provides functionality for test message sending.
	/// </summary>
	public interface ITestMessageProvider
	{

		#region Methods: Public

		/// <summary>
		/// Sends test bulk email message with dynamic content. Sends all replicas if 
		/// <see cref="SendTestMessageData.ReplicaMasks"/> property of the parameter <paramref name="data"/>
		/// is null or empty, or chosen replicas in another case.
		/// </summary>
		/// <param name="data">Data required for test message sending.</param>
		/// <returns>Results of successful sending for each replica.</returns>
		SendTestMessageResult SendDCTestMessage(SendTestMessageData data);

		#endregion

	}

	#endregion

	#region Class: SendTestMessageData

	/// <summary>
	/// Class for wrapping a data required for test message sending.
	/// </summary>
	public class SendTestMessageData
	{

		#region Properties: Public

		/// <summary>
		/// Identifier of the bulk email record.
		/// </summary>
		public Guid BulkEmailId { get; set; }

		/// <summary>
		/// Identifier of the contact record.
		/// </summary>
		public Guid ContactId { get; set; }

		/// <summary>
		/// Identifier of the linked entity record.
		/// </summary>
		public Guid LinkedEntityId { get; set; }

		/// <summary>
		/// Email addresses of the recipients that are concatenated with a delimiter.
		/// </summary>
		public string EmailRecipients { get; set; }

		/// <summary>
		/// Masks of replicas that should be sent.
		/// </summary>
		public int[] ReplicaMasks { get; set; }

		#endregion

	}

	#endregion

	#region Class: SendTestMessageResult

	/// <summary>
	/// Class for wrapping a result data of test message sending.
	/// </summary>
	public class SendTestMessageResult
	{

		#region Properties: Public

		/// <summary>
		/// Indicates whether the sending was successful.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Masks of replicas that was successfully sent.
		/// </summary>
		public int[] SentReplicaMasks { get; set; }

		/// <summary>
		/// Masks of replicas that was failed to send.
		/// </summary>
		public int[] FailedReplicaMasks { get; set; }

		#endregion

	}

	#endregion

}

