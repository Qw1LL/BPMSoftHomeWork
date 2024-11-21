namespace BPMSoft.Configuration.ForecastV2 {
	
	#region Interface: IForecastCalculator

	/// <summary>
	/// Calculator interface for forecast columns.
	/// </summary>
	public interface IForecastCalculator
	{
		/// <summary>
		/// Calculates forecast column values.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		/// <returns>Modified parameters.</returns>
		ForecastCalcParams Calculate(ForecastCalcParams parameters);
	}

	#endregion
	
}
