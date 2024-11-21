namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	
	#region Interface: IRemindingRepository

	/// <summary>
	/// Provides a method for receiving reminders.
	/// </summary>
	public interface IRemindingRepository
	{
		/// <summary>
		/// Returns remindings.
		/// </summary>
		/// <returns>Collection if the remindings.</returns>
		IEnumerable<INotificationInfo> GetRemindings();

		/// <summary>
		/// Sets remindings is sent.
		/// </summary>
		/// <param name="remindingId">Collection of the reminding identifier.</param>
		void SetRemindingsIsSent(IEnumerable<Guid> remindingId);
	}

	#endregion
	
}

