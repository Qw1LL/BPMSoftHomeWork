namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	#region Class: CampaignFragmentSynchronizer

	/// <summary>
	/// Represents class for campaign participants synchronization after campaign fragments' execution.
	/// Manages sync process by calling sync method for all elements' SyncManagers
	/// that are available for current campaign schema.
	/// </summary>
	public class CampaignFragmentSynchronizer : ICampaignFragmentSynchronizer
	{

		#region Properties: Public

		#endregion

		#region Methods: Private

		private CampaignSynchronizationInfo InternalSynchronize(UserConnection userConnection, CoreCampaignSchema campaignSchema,
				bool isForce) {
			var elementsToSync = campaignSchema.FlowElements
				.OfType<IFragmentSynchronizable>();
			var syncInfo = new CampaignSynchronizationInfo();
			foreach (var element in elementsToSync) {
				int synchronizedCount = 0;
				try {
					var syncManager = element.GetSyncManager();
					SyncByManager(userConnection, syncManager, isForce, ref synchronizedCount);
				} catch (Exception ex) {
					syncInfo.Success = false;
					syncInfo.Errors.Add(ex);
				} finally {
					syncInfo.SynchronizedParticipantsCount += synchronizedCount;
				}
			}
			return syncInfo;
		}

		private void SyncByManager(UserConnection userConnection, ICampaignFragmentSyncManager syncManager,
				bool isForce, ref int synchronizedCount) {
			if (isForce) {
				syncManager.ForceSynchronize(userConnection, ref synchronizedCount);
			} else {
				syncManager.Synchronize(userConnection, ref synchronizedCount);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Synchronizes campaign participants for which campaign fragments execution is finished.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <param name="campaignSchema">Current instance of <see cref="CoreCampaignSchema"/>.</param>
		/// <returns>Count of synchronized campaign participants.</returns>
		public CampaignSynchronizationInfo Synchronize(UserConnection userConnection, CoreCampaignSchema campaignSchema) {
			userConnection.CheckArgumentNull("userConnection");
			campaignSchema.CheckArgumentNull("campaignSchema");
			return InternalSynchronize(userConnection, campaignSchema, false);
		}

		/// <summary>
		/// Force synchronizes all campaign participants independently from campaign fragment execution results.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <param name="campaignSchema">Current instance of <see cref="CoreCampaignSchema"/>.</param>
		/// <returns>Count of synchronized campaign participants.</returns>
		public CampaignSynchronizationInfo ForceSynchronize(UserConnection userConnection, CoreCampaignSchema campaignSchema) {
			userConnection.CheckArgumentNull("userConnection");
			campaignSchema.CheckArgumentNull("campaignSchema");
			return InternalSynchronize(userConnection, campaignSchema, true);
		}

		#endregion

	}

	#endregion

}

