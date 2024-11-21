using System;

namespace BPMSoft.Configuration
{
	/// <summary>
	/// Interface for notification execution.
	/// </summary>
	[Obsolete("7.16.2 | Interface will be removed after delete feature 'NotificationsOnOneClassJob'.")]
	public interface INotificationInfoExecutor
	{

		/// <summary>
		/// Notification execution.
		/// </summary>
		/// <returns>Returns execution state.</returns>
		bool Execute();
	}
}

