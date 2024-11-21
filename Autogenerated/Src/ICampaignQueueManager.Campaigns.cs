namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core.DB;

	#region Interface: ICampaignQueueManager

	/// <summary>
	/// Represents methods for the queue of campaign message records.
	/// </summary>
	public interface ICampaignQueueManager
	{

		#region Methods: Public

		/// <summary>
		/// Tries to extract record from queue.
		/// </summary>
		/// <returns>A list of dequeued records.</returns>
		IEnumerable<CampaignQueueItem> Dequeue();

		/// <summary>
		/// Adds single record to queue.
		/// </summary>
		/// <param name="queueItem">An instance of <see cref="CampaignQueueItem"/> to enqueue.</param>
		/// <returns>A number of items that has been enqueued.</returns>
		int Enqueue(CampaignQueueItem queueItem);

		/// <summary>
		/// Adds few records to queue.
		/// </summary>
		/// <param name="queueItems">A list of <see cref="CampaignQueueItem"/> instances to enqueue.</param>
		/// <returns>A number of items that has been enqueued.</returns>
		int Enqueue(IEnumerable<CampaignQueueItem> queueItems);

		/// <summary>
		/// Adds all contacts from <paramref name="contactsSelect"/> to <see cref="CampaignQueue"/>.
		/// </summary>
		/// <param name="contactsSelect">Select query which contains contacts to add.
		/// For correct method work <paramref name="contactsSelect"/> need contains column 
		/// with alias "ContactId".</param>
		/// <param name="campaignItemId">Campaign step identifier.</param>
		/// <param name="expirationPeriod">Expiration for all records which will created 
		/// from <paramref name="contactsSelect"/>.</param>
		/// <returns>A number of items that has been enqueued.</returns>
		int Enqueue(Select contactsSelect, Guid campaignItemId, int expirationPeriod);

		/// <summary>
		/// Clears <see cref="CampaignQueueItem"/> from <see cref="CampaignQueue"/> 
		/// by <see cref="CampaignQueueItem.CampaignItemId"/> which match with <paramref name="campaignItemIds"/>.
		/// </summary>
		/// <param name="campaignItemIds">List of the campaign item identifiers.</param>
		void ClearByCampaignItems(List<Guid> campaignItemIds);

		#endregion

	}

	#endregion

}
