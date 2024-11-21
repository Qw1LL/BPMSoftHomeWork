namespace BPMSoft.Mail
{
	using System;

	#region Interface: ISyncStrategy

	/// <summary>
	/// Provides methods for get query to searching not synced messages.
	/// </summary>
	public partial interface ISyncStrategy
	{
		#region Methods: Public
		
		/// <summary>
		/// Creates search expression in IMAP4 language.
		/// </summary>
		/// <returns>
		/// Search expression.
		/// </returns>
		string GetUnsyncMsgSearchQuery();

		/// <summary>
		/// Creates search expression in IMAP4 language.
		/// </summary>
		/// <param name="sinceDate">Since date value.</param>
		/// <returns> Search expression.</returns>
		string GetFailoverMsgSearchQuery(DateTime sinceDate);

		#endregion
	}

	#endregion

}
