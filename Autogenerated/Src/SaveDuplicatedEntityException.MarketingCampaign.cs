namespace BPMSoft.Configuration.MarketingCampaign
{
	using System;

	#region Class: SaveDuplicatedEntityException

	/// <summary>
	/// Exception throws when duplicate entity trying to insert.
	/// </summary>
	public class SaveDuplicatedEntityException : Exception
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the System.Exception class with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public SaveDuplicatedEntityException(string message)
				: base(message) { }

		#endregion

	}

	#endregion

}
