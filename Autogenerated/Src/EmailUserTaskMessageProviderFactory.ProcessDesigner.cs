namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using BPMSoft.Configuration.ProcessDesigner;

	#region Class: EmailUserTaskMessageProviderFactory

	public static class EmailUserTaskMessageProviderFactory
	{

		#region Methods: Public

		public static IEmailUserTaskMessageProvider GetEmailMessageProvider(EmailTemplateUserTask userTask) {
			switch ((BodyTemplateType)userTask.BodyTemplateType) {
				case BodyTemplateType.EmailTemplate:
					return new EmailTemplateUserTaskMessageProvider(userTask);
				case BodyTemplateType.ProcessTemplate:
					return new EmailProcessTemplateUserTaskMessageProvider(userTask);
				default:
					throw new NotImplementedException();
			}
		}

		#endregion

	}

	#endregion

}

