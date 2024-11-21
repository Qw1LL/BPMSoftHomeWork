namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	
	/// <summary>
	/// Interface for data access notification.
	/// </summary>
	public interface INotificationRepository
	{
		/// <summary>
		/// Returns all notifications.
		/// </summary>
		/// <returns>Collection of the notifications.</returns>
		IEnumerable<INotificationInfo> GetAll();
		
		/// <summary>
		/// Returns notifications by name.
		/// </summary>
		/// <param name="name">Name of the notification.</param>
		/// <returns>Collection of the notifications.</returns>
		IEnumerable<INotificationInfo> GetByName(string name);
		
		/// <summary>
		/// Returns notifications by group name.
		/// </summary>
		/// <param name="group">Group name of the notification.</param>
		/// <returns>Collection of the notifications.</returns>
		IEnumerable<INotificationInfo> GetByGroup(string group);
	}
}

