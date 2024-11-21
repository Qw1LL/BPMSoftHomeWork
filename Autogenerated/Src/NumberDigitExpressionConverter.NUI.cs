namespace BPMSoft.Configuration
{
	using System;
	using System.Globalization;
	using System.Threading;

	#region Class: NumberDigitExpressionConverter

	/// <summary>
	/// Number digit expression converter class.
	/// </summary>
	[ExpressionConverterAttribute("NumberDigit")]
	public class NumberDigitExpressionConverter : IExpressionConverter 
	{

		#region Methods: Public

		/// <summary>
		/// Separates thousands with number group separator.
		/// </summary>
		/// <param name="value">Number value.</param>
		/// <param name="arguments"> Additional arguments.</param>
		/// <returns>Converted separated string value.</returns>
		public string Evaluate(object value, string arguments = " ") {
			decimal dec;
			if (!decimal.TryParse((string)value, out dec)) {
				return string.Empty;
			}
			NumberFormatInfo nfi = NumberFormatInfo.GetInstance(Thread.CurrentThread.CurrentCulture).Clone() as NumberFormatInfo;
			nfi.NumberGroupSeparator = string.IsNullOrEmpty(arguments) ? " " : arguments;
			return dec.ToString("###,###,###,###,##0.###,###,###,###", nfi).Trim();
		}

		#endregion

	}

	#endregion

}
