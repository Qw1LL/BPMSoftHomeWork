namespace BPMSoft.Configuration.ForecastV2
{

	#region Interface: IForecastEntitySnapshotService

	/// <summary>
	/// Save snapshot service for entity.
	/// </summary>
	public interface IForecastEntitySnapshotService
	{
		/// <summary>
		/// Saves snapshot data for entity.
		/// </summary>
		/// <param name="snapshot">Snapshot metadata.</param>
		/// <param name="filter">Filter configuration.</param>
		void SaveSnapshot(ForecastSnapshotData snapshot, FilterConfig filter);
	}

	#endregion

}

