namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	
	#region Class: DateTimeExpressionConverter

	/// <summary>
	/// Date time expression converter class.
	/// </summary>
	[ExpressionConverterAttribute("Date")]
	public class DateTimeExpressionConverter : IExpressionConverter 
	{

		#region Methods: Public

		/// <summary>
		/// Converts date time value.
		/// </summary>
		/// <param name="value">Date time value.</param>
		/// <param name="arguments"> Additional arguments.</param>
		/// <returns>Converted date time string.</returns>
		public string Evaluate(object value, string arguments = "") {
			string dateFormat = "dd.MM.yyyy";
			if (!arguments.IsNullOrEmpty()) {
				dateFormat = arguments;
			}
			DateTime date;
			if (DateTime.TryParse((string)value, out date)) {
				return date.ToString(dateFormat);
			}
			return string.Empty;
		}

		#endregion

	}

	#endregion

}
