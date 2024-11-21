namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Mailing;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core.Factories;

	#region Class: TemplateSizeValidator

	/// <summary>
	/// Manages validation of messages template size.
	/// </summary>
	public class TemplateSizeValidator : BaseMessageValidator
	{

		#region Constants: Private

		private const int MailingMaxTemplateSizeInBytes = 5242880;

		#endregion

		#region Fields: Private

		private BulkEmailMacroParser _bulkEmailMacroParser;

		private CESMailingTemplateFactory _templateFactory;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets the template factory.
		/// </summary>
		public CESMailingTemplateFactory TemplateFactory =>
			_templateFactory ?? (_templateFactory = new CESMailingTemplateFactory());

		/// <summary>
		/// Gets or sets the bulk email macro parser.
		/// </summary>
		public BulkEmailMacroParser BulkEmailMacroParser {
			get => _bulkEmailMacroParser ?? (_bulkEmailMacroParser = GetMacroParser());
			set => _bulkEmailMacroParser = value;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets or sets name of linked entity schema.
		/// </summary>
		protected string LinkedEntitySchemaName { get; set; }

		/// <summary>
		/// Gets the possibility to interrupt chain of validators.
		/// </summary>
		protected override bool IsAbortOnValidation => false;

		#endregion

		#region Methods: Private

		private double ConvertBytesToMegabytes(int sizeInBytes) {
			return Math.Round(sizeInBytes / 1024f / 1024f, 2);
		}

		private int GetTemplateSize(IMailingTemplate template) {
			var images = template.InlineImages.ToCESImage().ToList();
			var templateSize = CESUtilities.GetTemplateSize(template.Content, images);
			return templateSize;
		}

		private BulkEmailMacroParser GetMacroParser() {
			var macrosHelper = ClassFactory.Get<MacrosHelperV2>();
			macrosHelper.UserConnection = UserConnection;
			var bulkEmailMacroParser = ClassFactory.Get<BulkEmailMacroParser>(
				new ConstructorArgument("macrosHelper", macrosHelper),
				new ConstructorArgument("linkedEntitySchemaName", LinkedEntitySchemaName));
			return bulkEmailMacroParser;
		}

		private Dictionary<string, int> GetOversizedTemplates(BulkEmail bulkEmail) {
			var templateCollection = new List<IMailingTemplate>();
			var invalidTemplateNames = new Dictionary<string, int>();
			if (!bulkEmail.AudienceSchemaId.IsEmpty()) {
				InitLinkedEntitySchemaName(bulkEmail.AudienceSchemaId);
			}
			var templateReplicas = TemplateFactory.CreateDCTemplates(UserConnection, bulkEmail, BulkEmailMacroParser);
			if (templateReplicas == null) {
				return null;
			}
			templateCollection.AddRange(templateReplicas);
			foreach (var mailingTemplate in templateCollection) {
				if (ValidateTemplateSize(mailingTemplate, out var templateSize)) {
					continue;
				}
				var templateName = string.Concat("\"", bulkEmail.Name, "\"");
				invalidTemplateNames.Add(templateName, templateSize);
				return invalidTemplateNames;
			}
			return invalidTemplateNames;
		}

		private string GetTemplateValidationExceptionMessage(string lczPattern, Dictionary<string, int> bulkEmails) {
			var emails = string.Join(", ", bulkEmails.Keys);
			string message, result;
			var maxSizeInMegabytes = ConvertBytesToMegabytes(MailingMaxTemplateSizeInBytes);
			if (bulkEmails.Count == 1) {
				var templateSizeInMegabytes = ConvertBytesToMegabytes(bulkEmails.Values.FirstOrDefault());
				message = GetLczStringValue(string.Format(lczPattern, "Singular"));
				result = string.Format(message, templateSizeInMegabytes, maxSizeInMegabytes);
			} else {
				message = GetLczStringValue(string.Format(lczPattern, "Plural"));
				result = string.Format(message, emails, maxSizeInMegabytes);
			}
			return result;
		}

		private void InitLinkedEntitySchemaName(Guid audienceSchemaId) {
			var audienceSchema = new BulkEmailAudienceSchema(UserConnection);
			audienceSchema.FetchFromDB("Id", audienceSchemaId, new[] { "EntityObject" });
			LinkedEntitySchemaName = UserConnection.EntitySchemaManager
				.GetInstanceByUId(audienceSchema.EntityObjectId).Name;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Validates template size of bulk email message.
		/// </summary>
		/// <param name="emailContext">Dto with necessary bulk email info</param>
		/// <returns>Validation message if not succeed.</returns>
		protected override string Validate(BulkEmailContext emailContext) {
			var result = string.Empty;
			var invalidTemplates = new Dictionary<string, int>();
			foreach(var messageId in emailContext.MessageIds) {
				var bulkEmail = GetBulkEmailFromDB(messageId);
				var oversizedTemplates = GetOversizedTemplates(bulkEmail);
				if(oversizedTemplates == null) {
					result += string.Format(GetLczStringValue("TemplateSavedValidationError"),
						"\"" + bulkEmail.Name + "\"");
					result += '\n';
				} else {
					invalidTemplates.AddRange(oversizedTemplates);
				}
			}
			if(invalidTemplates.Any()) {
				result += GetTemplateValidationExceptionMessage("TemplateSizeValidation{0}Warning", invalidTemplates);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates the size of the template.
		/// </summary>
		/// <param name="template">The template.</param>
		/// <param name="templateSize">Result size of the template.</param>
		/// <returns></returns>
		public bool ValidateTemplateSize(IMailingTemplate template, out int templateSize) {
			templateSize = GetTemplateSize(template);
			return templateSize <= MailingMaxTemplateSizeInBytes;
		}

		#endregion

	}

	#endregion

}
