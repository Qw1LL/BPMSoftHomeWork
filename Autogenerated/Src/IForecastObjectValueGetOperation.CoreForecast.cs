namespace BPMSoft.Configuration.ForecastV2
{
	using System.Collections.Generic;

	#region Interface: IForecastObjectValueGetOperation

	/// <summary>
	/// Interface for getting forecast object value records.
	/// </summary>
	public interface IForecastObjectValueGetOperation
	{

		/// <summary>
		/// Get forecast object value records.
		/// </summary>
		/// <param name="sheet">Sheet</param>
		/// <param name="filterConfig">Filter config</param>
		/// <returns>List enumerable of records</returns>
		IEnumerable<ObjectValueRecord> GetRecords(Sheet sheet, FilterConfig filterConfig);
	}

	#endregion

}

