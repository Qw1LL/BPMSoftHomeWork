namespace BPMSoft.Configuration
{
	using System.Collections.Generic;

	/// <summary>
	/// Interface for processing notifications.
	/// </summary>
	public interface INotificationHandler
	{
		/// <summary>
		/// Processes notifications.
		/// </summary>
		/// <param name="notifications">Collection of the notifications.</param>
		void Handle(IEnumerable<INotificationInfo> notifications);
	}
}
