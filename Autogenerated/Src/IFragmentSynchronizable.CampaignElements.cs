namespace BPMSoft.Configuration
{

	#region Interface: IFragmentSynchronizable

	/// <summary>
	/// Describes specific logic for campaign participants synchronization.
	/// </summary>
	public interface IFragmentSynchronizable
	{

		#region Methods: Public

		/// <summary>
		/// Returns synchronization manager that is specific for current element.
		/// </summary>
		/// <returns>Instance of <see cref="ICampaignFragmentSyncManager">.</returns>
		ICampaignFragmentSyncManager GetSyncManager();

		#endregion

	}

	#endregion

}

