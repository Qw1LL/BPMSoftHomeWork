namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Interface: INotificationCounter

	/// <summary>
	/// Provides a method to get the number of notifications by group.
	/// </summary>
	public interface INotificationCounter
	{
		/// <summary>
		/// Returns notification counters by contact.
		/// </summary>
		/// <param name="contactId">Contact identifier.</param>
		/// <returns>Dictionary, where key is group of count and value is count.</returns>
		IDictionary<string, int> GetNotificationCount(Guid contactId);
	}

	#endregion
}
