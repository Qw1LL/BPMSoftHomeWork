namespace BPMSoft.Configuration
{
	using System;

	#region Class: UpperExpressionConverter

	/// <summary>
	/// Upper case string expression converter class.
	/// </summary>
	[ExpressionConverterAttribute("Upper")]
	public class UpperExpressionConverter : IExpressionConverter 
	{

		#region Methods: Public

		/// <summary>
		/// Converts string value.
		/// </summary>
		/// <param name="value">String value.</param>
		/// <param name="arguments"> Additional arguments.</param>
		/// <returns>Converted string value to upper case.</returns>
		public string Evaluate(object value, string arguments = "") {
			string str = (string)value;
			if (string.IsNullOrEmpty(str)) {
				return str;
			}
			switch (arguments) {
				case "FirstChar": 
					return str.Substring(0, 1).ToUpperInvariant() + (str.Length > 1 ? str.Substring(1) : "");
				default: 
					return str.ToUpperInvariant();
			}
		}

		#endregion

	}

	#endregion

}
