namespace BPMSoft.Configuration.Campaigns
{

	#region Class: MacroValueModel
	
	/// <summary>
	/// Contains info about macro value for entity column.
	/// </summary>
	public class MacroValueModel
	{

		#region Properties: Public

		/// <summary>
		/// Alias of macro.
		/// </summary>
		public string Alias { get; set; }

		/// <summary>
		/// Macros value.
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// String representation on <see cref="Value"/>
		/// </summary>
		public string StringValue { get; set; }

		#endregion

	}

	#endregion

}
