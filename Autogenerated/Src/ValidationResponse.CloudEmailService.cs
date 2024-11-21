namespace BPMSoft.Configuration
{

	/// <summary>
	/// Represents the result of checking validation rule.
	/// </summary>
	public class ValidationResponse
	{

		#region Properties: Public

		/// <summary>
		/// Result.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Localizable message code.
		/// </summary>
		public string LczStringCode { get; set; }

		#endregion

	}
}

