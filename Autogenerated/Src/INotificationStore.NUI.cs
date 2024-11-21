namespace BPMSoft.Configuration
{
	using System.Collections.Generic;

	/// <summary>
	/// Interface for access data of the notification providers.
	/// </summary>
	public interface INotificationStore
	{

		/// <summary>
		/// Returns providers name.
		/// </summary>
		/// <returns></returns>
		IEnumerable<string> GetNotificationProvidersName();
		
	}
}

