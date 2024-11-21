namespace BPMSoft.Configuration
{
	using System.Collections.Generic;

	/// <summary>
	/// Provides sending notifications methods.
	/// </summary>
	public interface INotificationSender
	{
		/// <summary>
		/// Sends notifications.
		/// </summary>
		/// <param name="notifications">The notification informations.</param>
		void Send(IEnumerable<INotificationInfo> notifications);
	}
}
