namespace BPMSoft.Configuration
{
	using System;

	#region Class: LowerExpressionConverter


	/// <summary>
	/// Lower case string expression converter class.
	/// </summary>
	[ExpressionConverterAttribute("Lower")]
	public class LowerExpressionConverter : IExpressionConverter 
	{
		
		#region Methods: Public
		
		/// <summary>
		/// Converts string value.
		/// </summary>
		/// <param name="value">String value.</param>
		/// <param name="arguments"> Additional arguments.</param>
		/// <returns>Converted string value to lower case.</returns>
		public string Evaluate(object value, string arguments = "") {
			string str = (string)value;
			if (string.IsNullOrEmpty(str)) {
				return str;
			}
			return str.ToLowerInvariant();
		}

		#endregion

	}

	#endregion

}
