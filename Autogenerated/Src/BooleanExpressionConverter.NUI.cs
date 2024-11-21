namespace BPMSoft.Configuration
{
	using System;

	#region Class: BooleanExpressionConverter

	/// <summary>
	/// Boolean expression converter class.
	/// </summary>
	[ExpressionConverterAttribute("Boolean")]
	public class BooleanExpressionConverter : IExpressionConverter 
	{

		#region Methods: Public

		/// <summary>
		/// Converts boolean value.
		/// </summary>
		/// <param name="value">Boolean value.</param>
		/// <param name="arguments"> Additional arguments.</param>
		/// <returns>Converted boolean value.</returns>
		public string Evaluate(object value, string arguments = "") {
			string result = (string)value;
			bool booleanValue;
			if (bool.TryParse(result, out booleanValue) && !string.IsNullOrEmpty(arguments)) {
				if (arguments == "CheckBox") {
					char trueBox = '\u2611';
					char falseBox = '\u2610';
					result = booleanValue ? trueBox.ToString() : falseBox.ToString();
				} else {
					char separator = ',';
					string[] textValues = arguments.Split(separator);
					if (textValues.Length == 2) {
						string trueValue = textValues[0];
						string falseValue = textValues[1];
						result = booleanValue ? trueValue : falseValue;
					}
				}
			}
			return result;
		}

		#endregion

	}

	#endregion

}

