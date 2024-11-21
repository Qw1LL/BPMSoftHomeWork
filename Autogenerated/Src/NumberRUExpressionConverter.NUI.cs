namespace BPMSoft.Configuration
{
	using System;
	using System.Text;

	#region Class: NumberRUExpressionConverter

	/// <summary>
	/// Number to string (russian) expression converter class.
	/// </summary>
	[ExpressionConverterAttribute("NumberRU")]
	public class NumberRUExpressionConverter : IExpressionConverter 
	{

		#region Methods: Public

		/// <summary>
		/// Converts number value.
		/// </summary>
		/// <param name="value">Number value.</param>
		/// <param name="arguments"> Additional arguments.</param>
		/// <returns>Converted number to string value.</returns>
		public string Evaluate(object value, string arguments = "") {
			decimal dec;
			if (!decimal.TryParse((string)value, out dec)) {
				return string.Empty;
			}
			switch (arguments) {
				case "Cent": 
					decimal cent = decimal.Floor(dec * 100) % 100;
					return cent.ToString("00");
				case "Decimal": 
					StringBuilder sb = new StringBuilder();
					NumberInWords.ConstractDblValueString((double)dec, ref sb);
					return sb.ToString();
				default: 
					return NumberInWords.ConvertAmountToMaleStr(Math.Truncate(dec));
			}
		}

		#endregion

	}

	#endregion

}
