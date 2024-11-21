namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using BPMSoft.Configuration.ProcessDesigner;

	#region Class: EmailUserTaskMacrosHelperFactory

	public static class EmailUserTaskMacrosHelperFactory
	{

		#region Methods: Public

		public static IEmailUserTaskMacrosProvider GetMacrosHelper(
				EmailTemplateUserTask userTask, UserConnection userConnection) {
			bool useAdminRights = userTask.SendEmailType != (int)SendEmailType.Auto;
			switch ((BodyTemplateType)userTask.BodyTemplateType) {
				case BodyTemplateType.EmailTemplate:
					return new EmailTemplateUserTaskMacrosHelper(userTask) {
						UserConnection = userConnection,
						UseAdminRights = useAdminRights
					};
				case BodyTemplateType.ProcessTemplate:
					return new ProcessEmailUserTaskMacrosHelper(userTask) {
						UserConnection = userConnection,
						UseAdminRights = useAdminRights
					};
				default:
					throw new NotImplementedException();
			}
		}

		#endregion

	}

	#endregion

}
