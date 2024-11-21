namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using BPMSoft.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Mail.Sender;
	using BPMSoft.Configuration.ProcessDesigner;

	#region Class: ProcessEmailUserTaskMacrosHelper

	public abstract class BaseEmailUserTaskMacrosHelper : GlobalMacrosHelper, IEmailUserTaskMacrosProvider
	{

		#region Properties: Private

		private EntitySchema EntitySchema {
			get;
			set;
		}

		#endregion

		#region Properties: Protected

		protected EmailTemplateUserTask UserTask {
			get;
			set;
		}

		#endregion

		#region Constructors: Public

		protected BaseEmailUserTaskMacrosHelper(EmailTemplateUserTask userTask) {
			UserTask = userTask;
			EntitySchema = FindSourceEntitySchema();
		}

		#endregion

		#region Methods: Private

		private EntitySchema FindSourceEntitySchema() {
			EntitySchemaManager entitySchemaManager = UserTask.UserConnection.EntitySchemaManager;
			BaseProcessSchemaElement userTaskSchema = UserTask.GetSchemaElement();
			var parametersMetaInfo = userTaskSchema as IProcessParametersMetaInfo;
			EntitySchema schema = null;
			if (parametersMetaInfo != null) {
				ProcessSchemaParameterCollection parameters = parametersMetaInfo.ForceGetParameters();
				ProcessSchemaParameter parameter = parameters.GetByName("EmailTemplateEntityId");
				schema = entitySchemaManager.FindInstanceByUId(parameter.ReferenceSchemaUId);
			}
			return schema;
		}

		private string GetTextTemplate(string template) {
			string entitySchemaName = EntitySchema != null ? EntitySchema.Name : string.Empty;
			if (UserConnection.GetIsFeatureEnabled("UseMacrosAdditionalParameters")) {
				return GetTextTemplate(template, entitySchemaName, UserTask.EmailTemplateEntityId,
					UserTask.MacrosExtendedProperties);
			}
			return GetTextTemplate(template, entitySchemaName, UserTask.EmailTemplateEntityId);
		}

		private string GetPlainTextTemplate(string textTemplate){
			string entitySchemaName = EntitySchema != null ? EntitySchema.Name : string.Empty;
			if (UserConnection.GetIsFeatureEnabled("UseMacrosAdditionalParameters")) {
				return GetPlainTextTemplate(textTemplate, entitySchemaName, UserTask.EmailTemplateEntityId,
					UserTask.MacrosExtendedProperties);
			}
			return GetPlainTextTemplate(textTemplate, entitySchemaName, UserTask.EmailTemplateEntityId);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns macros worker id.
		/// </summary>
		/// <returns>
		/// Macros worker id.
		/// </returns>
		protected abstract Guid GetMacrosWorkerId();

		#endregion

		#region Methods: Public

		public void ReplaceMacroses(EmailMessage emailMessage) {
			emailMessage.Body = UserTask.SendEmailType == (int)SendEmailType.Auto ?
				GetPlainTextTemplate(emailMessage.Body) : GetTextTemplate(emailMessage.Body);
			emailMessage.Subject = GetPlainTextTemplate(emailMessage.Subject);
			emailMessage.From = GetPlainTextTemplate(emailMessage.From);
		}

		#endregion

	}

	#endregion

}

