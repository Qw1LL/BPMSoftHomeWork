namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	///Interface for processing notifications.
	/// </summary>
	[Obsolete("Will be removed after 7.12.2, instead use BPMSoft.Configuration.INotificationHandler")]
	public interface INotificationInfoHandler
	{

		/// <summary>
		/// Processes notifications.
		/// </summary>
		/// <param name="infos">Collection of the notifications.</param>
		/// <param name="userIds">Collection of ids from SysAdminUnit.</param>
		void HandleInfo(IEnumerable<INotificationInfo> informations, IEnumerable<Guid> userIds);
	}
}

