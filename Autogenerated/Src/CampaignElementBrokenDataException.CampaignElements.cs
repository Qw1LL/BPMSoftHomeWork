namespace BPMSoft.Configuration.CampaignElements
{
	using System;

	#region Class: CampaignElementBrokenDataException

	/// <summary>
	/// Exception indicated broken or inconsistent data in campaign element.
	/// </summary>
	public class CampaignElementBrokenDataException : Exception
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="CampaignElementBrokenDataException"/> class with 
		/// a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public CampaignElementBrokenDataException(string message) : base(message) { }

		#endregion

	}

	#endregion

}
