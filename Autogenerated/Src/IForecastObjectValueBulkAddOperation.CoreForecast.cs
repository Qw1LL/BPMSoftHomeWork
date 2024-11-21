namespace BPMSoft.Configuration.ForecastV2
{
	using System.Collections.Generic;

	#region Interface: IForecastObjectValueBulkAddOperation

	/// <summary>
	/// Interface for adding records to forecast history object value record.
	/// </summary>
	public interface IForecastObjectValueBulkAddOperation
	{

		/// <summary>
		/// Add records to forecast history object value record.
		/// </summary>
		/// <param name="snapshot">Forecast snapshot</param>
		/// <param name="records">Records</param>
		void AddRecords(ForecastSnapshotData snapshot, IEnumerable<ObjectValueRecord> records);
	}

	#endregion

}

