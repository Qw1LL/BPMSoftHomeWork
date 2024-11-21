namespace BPMSoft.Configuration.Campaigns
{
	using BPMSoft.Core;

	#region Class: TypedValueModel

	/// <summary>
	/// Describes model for campaign entity schema macro value.
	/// </summary>
	public class TypedValueModel
	{

		#region Properties: Public

		/// <summary>
		/// Value of campaign entity schema macro.
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// Macros entity column data value type.
		/// </summary>
		public DataValueType Type { get; set; }

		#endregion

	}

	#endregion

}

