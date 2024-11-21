namespace BPMSoft.Configuration.ForecastV2
{
	using BPMSoft.Common;

	/// <summary>
	/// Provides forecast utilities.
	/// </summary>
	public static class ForecastUtilities
	{

		/// <summary>
		/// Returns strict aggregation type.
		/// </summary>
		/// <param name="funcCode">Code of aggregation type</param>
		/// <returns>Strict aggregation type value<see cref="AggregationTypeStrict"/></returns>
		public static AggregationTypeStrict GetCalcFunction(string funcCode) {
			switch (funcCode) {
				case "sum":
					return AggregationTypeStrict.Sum;
				case "count":
					return AggregationTypeStrict.Count;
				case "avg":
					return AggregationTypeStrict.Avg;
				default:
					return AggregationTypeStrict.Sum;
			}
		}
	}
}
