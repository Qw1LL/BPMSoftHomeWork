namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Class: BulkEmailRecipientInfo

	/// <summary>
	/// Provides methods and properties for work with recipient of bulk email.
	/// </summary>
	public class BulkEmailRecipientInfo : IMessageRecipientInfo, IExpirationInfo, IDCRecipientInfo
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier of recipient.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Email address of recipient.
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// RId in contacts table.
		/// </summary>
		public int ContactRId { get; set; }

		/// <summary>
		/// Contact's unique idetifier.
		/// </summary>
		public Guid ContactId { get; set; }

		/// <summary>
		/// Default code of the response for the recipient.
		/// </summary>
		public int InitialResponseCode { get; set; }

		/// <summary>
		/// Message expiration date.
		/// </summary>
		[Obsolete("7.17.3 | Use AddTemplateRequest.ExpirationDate instead.")]
		public DateTime? ExpirationDate { get; set; }

		/// <summary>
		/// Gets or sets the macros content.
		/// </summary>
		public Dictionary<string, string> Macros { get; set; }

		/// <summary>
		/// Gets or sets the replica identifier.
		/// </summary>
		public Guid ReplicaId { get; set; }

		/// <summary>
		/// Gets or sets recipient's linked entity for extended macros.
		/// </summary>
		public Guid LinkedEntityId { get; set; }

		#endregion

	}

	#endregion
}
