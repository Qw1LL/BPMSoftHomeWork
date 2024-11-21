namespace BPMSoft.Configuration
{
	using System;

	#region Class: CampaignQueueItem

	/// <summary>
	/// Base DTO for campaign queue.
	/// </summary>
	public class CampaignQueueItem
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes an instance of <see cref="CampaignQueueItem"/> with new <see cref="Id"/> 
		/// and <see cref="CreatedOn"/> property.
		/// </summary>
		public CampaignQueueItem() {
			Id = Guid.NewGuid();
			CreatedOn = DateTime.UtcNow;
		}

		/// <summary>
		/// Initializes an instance of <see cref="CampaignQueueItem"/>.
		/// </summary>
		/// <param name="contactId">Unique identifier of contact.</param>
		/// <param name="campaignItemId">Unique identifier of campaign step.</param>
		[Obsolete("7.13.3 | Method is deprecated. Use class parameters for set properties.")]
		public CampaignQueueItem(Guid contactId, Guid campaignItemId) {
			Id = Guid.NewGuid();
			ContactId = contactId;
			CampaignItemId = campaignItemId;
			CreatedOn = DateTime.UtcNow;
		}

		/// <summary>
		/// Initializes an instance of <see cref="CampaignQueueItem"/>.
		/// </summary>
		/// <param name="contactId">Unique identifier of contact.</param>
		/// <param name="campaignItemId">Unique identifier of campaign step.</param>
		/// <param name="id">Unique identifier of <see cref="CampaignQueue"/> record.</param>
		[Obsolete("7.13.3 | Method is deprecated. Use class parameters for set properties.")]
		public CampaignQueueItem(Guid contactId, Guid campaignItemId, Guid id)
			: this(contactId, campaignItemId) {
			Id = id;
		}

		/// <summary>
		/// Initializes an instance of <see cref="CampaignQueueItem"/>.
		/// </summary>
		/// <param name="contactId">Unique identifier of contact.</param>
		/// <param name="campaignItemId">Unique identifier of campaign step.</param>
		/// <param name="id">Unique identifier of <see cref="CampaignQueue"/> record.</param>
		/// <param name="createdOn">The date and time, when record was inserted into the queue.</param>
		[Obsolete("7.13.3 | Method is deprecated. Use class parameters for set properties.")]
		public CampaignQueueItem(Guid contactId, Guid campaignItemId, Guid id, DateTime createdOn)
			: this(contactId, campaignItemId, id) {
			CreatedOn = createdOn;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id of the queue item.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Unique identifier of contact.
		/// </summary>
		public Guid ContactId { get; set; }

		/// <summary>
		/// Unique identifier of linked entity.
		/// </summary>
		public Guid LinkedEntityId { get; set; }

		/// <summary>
		/// Unique identifier of linked entity schema.
		/// </summary>
		public Guid EntitySchemaUId { get; set; }

		/// <summary>
		/// Unique identifier of campaign participant.
		/// </summary>
		public Guid CampaignParticipantId { get; set; }

		/// <summary>
		/// Unique identifier of campaign step.
		/// </summary>
		public Guid CampaignItemId { get; set; }

		/// <summary>
		/// The date and time, when record was inserted into the queue.
		/// </summary>
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// Maximum period of record relevance (in minutes).
		/// </summary>
		public int ExpirationPeriod { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns true if item is not reached the <paramref name="expirationPeriod"/> at current moment.
		/// </summary>
		/// <param name="expirationPeriod">Maximum period of item relevance (in minutes).</param>
		/// <returns></returns>
		public bool IsRelevantNow(int expirationPeriod) => CreatedOn.AddMinutes(expirationPeriod) > DateTime.UtcNow;

		/// <summary>
		/// Returns true if item is not reached the ExpirationPeriod at current moment.
		/// </summary>
		/// <returns></returns>
		public bool IsRelevantNow() => CreatedOn.AddMinutes(ExpirationPeriod) > DateTime.UtcNow;

		#endregion

		#region Methods: Public

		/// <summary>
		/// Stringifies <see cref="CampaignQueueItem"/> DTO.
		/// </summary>
		/// <returns>String value.</returns>
		public override string ToString() {
			return $"CampaignQueueItem Id: {Id}, Contact: {ContactId}, CampaignItem: {CampaignItemId}";
		}

		#endregion
	}

	#endregion

}
