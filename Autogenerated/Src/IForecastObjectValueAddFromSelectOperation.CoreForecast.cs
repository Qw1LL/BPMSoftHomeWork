namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using BPMSoft.Core.DB;

	/// <summary>
	/// Interface for adding forecast object value records.
	/// </summary>
	public interface IForecastObjectValueAddFromSelectOperation
	{

		/// <summary>
		///  Execute add records to ForecastObjValueRecord.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="select">Select, with all required columns.</param>
		void BulkAddRecords(Sheet sheet, Select select);
	}
}
