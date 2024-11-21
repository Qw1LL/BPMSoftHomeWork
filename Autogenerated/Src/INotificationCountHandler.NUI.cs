namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Interface: INotificationCountHandler 

	/// <summary>
	/// Provides method to retrieve the counters.
	/// </summary>
	public interface INotificationCountHandler
	{
		
		/// <summary>
		/// Returns the counters for a user. 
		/// </summary>
		/// <param name="contactId">User identifier.</param>
		/// <param name="group">Name of the group.</param>
		/// <returns>Dictionary, where key is group of count and value is count.</returns>
		IDictionary<string, int> GetNotificationCounters(Guid contactId, string group);
	}

	#endregion
}
