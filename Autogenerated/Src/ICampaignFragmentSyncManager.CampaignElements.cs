namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Interface: ICampaignFragmentSyncManager

	/// <summary>
	/// Describes functionality for campaign participants synchronization 
	/// that is common for group of campaign schema elements with equal synchronization logic.
	/// </summary>
	public interface ICampaignFragmentSyncManager
	{

		#region Methods: Public

		/// <summary>
		/// Synchronizes campaign participants for which campaign fragments had been executed.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/> class.</param>
		/// <param name="synchronizedCount">Count of synchronized participants.</param>
		void Synchronize(UserConnection userConnection, ref int synchronizedCount);

		/// <summary>
		/// Force synchronizes campaign participants for which campaign fragments had been executed.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/> class.</param>
		/// <param name="synchronizedCount">Count of synchronized participants.</param>
		void ForceSynchronize(UserConnection userConnection, ref int synchronizedCount);

		#endregion

	}

	#endregion

}

