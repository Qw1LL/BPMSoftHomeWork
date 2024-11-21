using System;
using System.Globalization;

namespace BPMSoft.Configuration
{
	public class CurrencyRateHelper
	{
		/// <summary>
		/// Gets the cut mantissa of currency rate.
		/// </summary>
		/// <param name="rate">Rate.</param>
		/// <returns>Cut mantissa</returns>
		public static string GetRateMantissa(decimal rate) {
			decimal fraction = rate - (ulong)rate;
			var nfi = new NumberFormatInfo {
				NumberDecimalSeparator = ","
			};
			return fraction.ToString(nfi).Replace("0,", "");
		}

		/// <summary>
		/// Sets mantissa to rate.
		/// </summary>
		/// <param name="rate">Rate.</param>
		/// <param name="mantissa">Mantissa.</param>
		/// <returns>R</returns>
		public static decimal SetMantissaToRate(decimal rate, string mantissa) {
			if (long.TryParse(mantissa, out long mantissaValue)) {
				decimal fraction = mantissaValue / (decimal)Math.Pow(10, mantissa.Length);
				rate = Math.Floor(rate);
				rate+= fraction;
			}
			return rate;
		}
	}
}

