namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using BPMSoft.Configuration.ProcessDesigner;

	#region Class: EmailUserTaskSenderFactory

	public static class EmailUserTaskSenderFactory
	{

		#region Methods: Public

		public static IEmailUserTaskSender GetEmailSender(EmailTemplateUserTask userTask) {
			switch ((SendEmailType)userTask.SendEmailType) {
				case SendEmailType.Auto:
					return new AutoEmailUserTaskSender {
						UserConnection = userTask.UserConnection
					};
				case SendEmailType.Manual:
					return new ManualEmailUserTaskSender {
						UserConnection = userTask.UserConnection
					};
				default:
					throw new NotImplementedException();
			}
		}

		#endregion

	}

	#endregion

}

