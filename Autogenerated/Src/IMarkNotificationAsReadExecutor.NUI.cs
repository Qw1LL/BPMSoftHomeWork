namespace BPMSoft.Configuration.Notifications
{
	using System;

	#region Interface: IMarkNotificationAsReadExecutor

	public interface IMarkNotificationAsReadExecutor
	{

		#region Methods: Public

		void Execute(Guid notificationTypeId, DateTime remindTime);

		#endregion
	}

	#endregion

}

