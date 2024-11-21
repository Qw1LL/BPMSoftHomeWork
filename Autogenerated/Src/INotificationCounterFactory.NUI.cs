namespace BPMSoft.Configuration
{
	using System.Collections.Generic;

	#region Interface: INotificationCounterFactory

	/// <summary>
	/// Provides a method to access the classes for getting the counters.
	/// </summary>
	public interface INotificationCounterFactory
	{
		/// <summary>
		/// Returns instances of <see cref="INotificationCounter"/> by <see cref="NotificationGroup"/>
		/// </summary>
		/// <param name="group">The group name.</param>
		/// <returns>Collection of <see cref="INotificationCounter"/></returns>
		IEnumerable<INotificationCounter> GetNotificationCounters(string group);
	}

	#endregion
}
