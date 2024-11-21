namespace BPMSoft.Configuration
{
	
	/// <summary>
	/// Interface for creating notification provider.
	/// </summary>
	public interface INotificationFactory
	{
		/// <summary>
		/// Created notification provider.
		/// </summary>
		/// <param name="className">Class name.</param>
		/// <returns>Notification provider.</returns>
		INotification CreateInstance(string className);
	}
}

