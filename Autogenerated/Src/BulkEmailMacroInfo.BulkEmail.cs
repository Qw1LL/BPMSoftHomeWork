namespace BPMSoft.Configuration
{
	/// <summary>
	/// Represents the data contract for bulk email macro value saving.
	/// </summary>
	public class BulkEmailMacroInfo
	{

		#region Properties: Public

		/// <summary>
		/// Macros alias like MACROS0.
		/// </summary>
		public string Alias { get; set; }

		/// <summary>
		/// Original macro text from template.
		/// </summary>
		public string MacroText { get; set; }

		/// <summary>
		/// Result value of macro.
		/// </summary>
		public string Value { get; set; }

		#endregion

	}
}
