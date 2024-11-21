namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.ProcessDesigner;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	public class EmailTemplateUserTaskMessageProvider : BaseProcessEmailMessageProvider
	{

		#region Constants: Private

		/// <summary>
		/// Email template entity schema name.
		/// </summary>
		private const string _emailTemplateSchemaName = "EmailTemplate";

		/// <summary>
		/// Tag for getting email template user task language iterator.
		/// </summary>
		private const string _emailTemplateUserTaskLanguageIteratorTag = "EmailTemplateUserTask";

		/// <summary>
		/// Contact schema name.
		/// </summary>
		private const string _contactSchemaName = "Contact";

		#endregion

		#region Constructors: Public

		public EmailTemplateUserTaskMessageProvider(EmailTemplateUserTask userTask)
			: base(userTask) {
		}

		#endregion

		#region Properties: Public

		private MLangContentFactory _contentFactory;
		/// <summary>
		/// Multilanguage content factory.
		/// </summary>
		public MLangContentFactory MLangContentFactory
		{
			get => _contentFactory ?? (_contentFactory = new MLangContentFactory(UserConnection));
			set => _contentFactory = value;
		}

		#endregion

		#region Methods: Private

		private EntitySchemaQuery GetEmailTemplateContentEsq(Guid templateId) {
			var manager = UserConnection.EntitySchemaManager;
			var esq = new EntitySchemaQuery(manager, "EmailTemplate");
			esq.AddColumn("Body");
			esq.AddColumn("Subject");
			var primariFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", templateId);
			esq.Filters.Add(primariFilter);
			if (EmailUserTask.SendEmailType == (int)SendEmailType.Auto) {
				esq.UseAdminRights = false;
			}
			return esq;
		}

		private List<ProcessSchemaParameter> GetProcessSchemaParameters() {
			var regex = new Regex(@"^Recipient\d+$");
			var response = new List<ProcessSchemaParameter>();
			BaseProcessSchemaElement userTaskSchema = EmailUserTask.GetSchemaElement();
			var processParametersMetaInfo = userTaskSchema as IProcessParametersMetaInfo;
			if (processParametersMetaInfo == null) {
				return response;
			}
			ProcessSchemaParameterCollection parameters = processParametersMetaInfo.ForceGetParameters();
			response = parameters.Where(p =>
				regex.IsMatch(p.Name) &&
				((p.DataValueType.IsLookup && p.ReferenceSchema != null &&
					p.ReferenceSchema.Name == _contactSchemaName) || !p.DataValueType.IsLookup)).ToList();

			return response;
		}

		private bool UseDefaultCultureTemplate(string schemaName) {
			var recipients = GetProcessSchemaParameters();
			if (recipients.Any(p => !p.DataValueType.IsLookup)) {
				return true;
			}
			var languageIterator = GetLanguageIterator(schemaName);
			var languages = recipients
				.Select(GetProcessSchemaGuidParameterValue)
				.Where(recipientId => recipientId != Guid.Empty)
				.Select(recipientId => GetLanguageByRecipientParameter(recipientId, languageIterator))
				.Distinct();
			return languages.Count() != 1;
		}

		private Guid GetProcessSchemaGuidParameterValue(ProcessSchemaParameter parameter) {
			object propertyValue = EmailUserTask.GetParameterValue(parameter);
			return (Guid)propertyValue;
		}

		private Guid GetLanguageByRecipientParameter(Guid recipientId, ILanguageIterator languageIterator) {
			return languageIterator.GetLanguages(recipientId).FirstOrDefault(languageId => languageId != Guid.Empty);
		}

		private ILanguageIterator GetLanguageIterator(string iteratorTagName) {
			var userConnectionArgument = new ConstructorArgument("userConnection", UserConnection);
			ClassFactory.TryGet(iteratorTagName, out ILanguageIterator languageIterator,
				userConnectionArgument);
			if (languageIterator == null) {
				var schemaNameArgument = new ConstructorArgument("schemaName", iteratorTagName);
				languageIterator =
					ClassFactory.Get<ILanguageIterator>("Default", schemaNameArgument);
			}
			return languageIterator;
		}

		private Guid GetDefaultLanguageId() {
			var defaultLanguageRule = new DefaultLanguageRule(UserConnection);
			return defaultLanguageRule.GetLanguageId(Guid.Empty);
		}
		
		private Entity GetDefaultCultureTemplate(Guid templateId, IContentStore contentStore) {
			return contentStore.Get(templateId, GetDefaultLanguageId()) ?? contentStore.GetDefault(templateId);
		}

		#endregion

		#region Methods: Protected

		protected override (string Body, string Subject) GetEmailContent() {
			Entity entity = null;
			if (UserConnection.GetIsFeatureEnabled("EmailTemplateUserTaskMultiLanguageV2")) {
				entity = GetMultiLanguageTemplate(EmailUserTask.EmailTemplateId, GetTemplateRecipientId(),
					_emailTemplateUserTaskLanguageIteratorTag);
			} else {
				var templateEsq = GetEmailTemplateContentEsq(EmailUserTask.EmailTemplateId);
				entity = templateEsq.GetEntityCollection(UserConnection).SingleOrDefault();
			}
			var templateSubject = string.Empty;
			var body = string.Empty;
			if (entity != null) {
				if (UserConnection.GetIsFeatureEnabled("UseMacrosAdditionalParameters")) {
					EmailUserTask.MacrosExtendedProperties.LanguageId = entity.GetTypedColumnValue<Guid>("LanguageId");
				}
				body = entity.GetTypedColumnValue<string>("Body");
				templateSubject = entity.GetTypedColumnValue<string>("Subject");
			} else {
				throw new ApplicationException($"Localizable template not found for record {EmailUserTask.EmailTemplateId}");
			}
			string userTaskSubject = GetEmailSubject();
			var subject = string.IsNullOrEmpty(userTaskSubject) ? templateSubject : userTaskSubject;
			return (body, subject);
		}

		/// <summary>
		/// Returns recipient identifier from email template user task.
		/// </summary>
		/// <returns>Recipient identifier from email template user task.</returns>
		protected virtual Guid GetTemplateRecipientId() {
			var regex = new Regex(@"^Recipient\d+$");
			BaseProcessSchemaElement userTaskSchema = EmailUserTask.GetSchemaElement();
			var processParametersMetaInfo = userTaskSchema as IProcessParametersMetaInfo;
			if (processParametersMetaInfo == null) {
				return Guid.Empty;
			}
			ProcessSchemaParameterCollection parameters = processParametersMetaInfo.ForceGetParameters();
			if (parameters == null || parameters.Count == 0) {
				return Guid.Empty;
			}
			foreach (ProcessSchemaParameter parameter in parameters) {
				if (regex.IsMatch(parameter.Name) && parameter.DataValueType.IsLookup &&
					parameter.ReferenceSchema != null && parameter.ReferenceSchema.Name == _contactSchemaName) {
					object propertyValue = EmailUserTask.GetParameterValue(parameter);
					return (Guid)propertyValue;
				}
			}
			return Guid.Empty;
		}

		/// <summary>
		/// Gets multi language template entity.
		/// </summary>
		/// <param name="templateId">Template record identifier.</param>
		/// <param name="recordId">Entity record identifier.</param>
		/// <param name="schemaName">Tag name to get an iterator.</param>
		/// <returns>Multi language template entity.</returns>
		protected Entity GetMultiLanguageTemplate(Guid templateId, Guid recordId, string schemaName) {
			var contentKit = MLangContentFactory.GetContentKit(schemaName, _emailTemplateSchemaName);
			if (EmailUserTask.SendEmailType == (int)SendEmailType.Auto) {
				contentKit.ContentStore.UseAdminRights = false;
			}
			bool multiLanguageEnabled =
				!UserConnection.GetIsFeatureEnabled("DisableMultiLanguageTemplateCultureCorrector");
			return multiLanguageEnabled && UseDefaultCultureTemplate(schemaName)
				? GetDefaultCultureTemplate(templateId, contentKit.ContentStore)
				: contentKit.GetContent(templateId, recordId);
		}

		protected override string GetEmailBody() {
			var content = GetEmailContent();
			return content.Body;
		}

		#endregion

	}

}

