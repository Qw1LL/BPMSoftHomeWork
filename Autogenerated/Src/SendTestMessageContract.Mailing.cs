namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;

	#region Class: SentTestMessageRequest

	/// <summary>
	/// Class for wrapping a data for test message sending request.
	/// </summary>
	[DataContract]
	public class SendTestMessageRequest
	{

		#region Properties: Public

		/// <summary>
		/// Identifier of the bulk email record.
		/// </summary>
		[DataMember(Name = "bulkEmailId")]
		public Guid BulkEmailId { get; set; }

		/// <summary>
		/// Identifier of the contact record.
		/// </summary>
		[DataMember(Name = "contactId")]
		public Guid ContactId { get; set; }

		/// <summary>
		/// Identifier of the linked entity record.
		/// </summary>
		[DataMember(Name = "linkedEntityId")]
		public Guid LinkedEntityId { get; set; }

		/// <summary>
		/// Email addresses of the recipients that are concatenated with a delimiter.
		/// </summary>
		[DataMember(Name = "emailRecipients")]
		public string EmailRecipients { get; set; }

		/// <summary>
		/// Masks of replicas that should be sent.
		/// </summary>
		[DataMember(Name = "replicaMasks")]
		public int[] ReplicaMasks { get; set; }

		#endregion

	}

	#endregion

	#region Class: SentTestMessageResponse

	/// <summary>
	/// Class for wrapping an information about completion of test message sending.
	/// </summary>
	[DataContract]
	public class SendTestMessageResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		/// <summary>
		/// Total count of replicas.
		/// </summary>
		[DataMember(Name = "replicasCount")]
		public int ReplicasCount { get; set; }

		/// <summary>
		/// Count of replicas that was successfully sent.
		/// </summary>
		[DataMember(Name = "sentReplicasCount")]
		public int SentReplicasCount { get; set; }

		/// <summary>
		/// Additional information message for user.
		/// </summary>
		[DataMember(Name = "message")]
		public string Message { get; set; }

		#endregion

	}

	#endregion

}

