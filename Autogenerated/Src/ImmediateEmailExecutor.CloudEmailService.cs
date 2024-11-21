namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Configuration.DynamicContent;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Configuration.Mailing;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: ImmediateEmailExecutor

	public class ImmediateEmailExecutor
	{

		#region Constants: Private

		private const string EmailSplitRegexPattern = @"[;,\s]\s*";

		private const string TestMessageTag = "test_message";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public ImmediateEmailExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		public BpmCrmCloudEngine CloudEngine { get; set; }

		public ICESApi ServiceApi { get; set; }

		public CESMailingTemplateFactory TemplateFactory { get; set; }

		public BulkEmailValidator Validator { get; set; }

		public BulkEmailMacroParser BulkEmailMacroParser { get; set; }

		#endregion

		public DCTemplateRepository<DCTemplateModel> TemplateRepository;

		#region Methods: Private

		private merge_var CreateMergeVar(string macrosName, string macrosContent) {
			return new merge_var {
				name = macrosName,
				content = BulkEmailMacroParser.EncodeUrlMacrosValue(macrosName, macrosContent)
			};
		}

		private rcpt_merge_var CreateRecipientMergeVars(Guid contactId, string emailAddress,
				Dictionary<string, string> macrosValues) {
			var personalMergeVar = new rcpt_merge_var();
			foreach (var macros in macrosValues) {
				personalMergeVar.vars.Add(CreateMergeVar(macros.Key, macros.Value));
			}
			personalMergeVar.vars.Add(
				CreateMergeVar(BulkEmailHyperlinkHelper.ContactIdMacrosName, contactId.ToString()));
			personalMergeVar.vars.Add(CreateMergeVar(BulkEmailHyperlinkHelper.BulkEmailRecipientIdName,
				Guid.Empty.ToString()));
			personalMergeVar.rcpt = emailAddress;
			return personalMergeVar;
		}

		private SendMessageData CreateSendMessageData(BulkEmail bulkEmail) {
			var startDateUtc = TimeZoneInfo.ConvertTimeToUtc(bulkEmail.StartDate, _userConnection.CurrentUser.TimeZone);
			var messageData = new SendMessageData {
				UserConnection = _userConnection,
				BulkEmail = bulkEmail,
				BulkEmailStartDate = startDateUtc,
				SessionId = Guid.NewGuid()
			};
			return messageData;
		}

		private SendTestMessageResult ExecuteDCTestMessageSending(SendTestMessageData data, BulkEmail bulkEmail,
			SendMessageData messageData, IEnumerable<DCReplicaModel> replicas) {
			var sentReplicaMasks = new List<int>();
			var failedReplicaMasks = new List<int>();
			var templates = TemplateFactory.CreateInstances(_userConnection, bulkEmail, replicas, BulkEmailMacroParser);
			var templatesWithMasks = templates.Select(t => new {
				Template = t,
				ReplicaMask = replicas.First(replica => replica.Id == ((IMailingTemplateReplica)t).ReplicaId).Mask
			});
			var macroComposer = GetMacroComposer(bulkEmail);
			foreach (var template in templatesWithMasks) {
				var sentSuccessfully = SendTestMessageTemplate(bulkEmail.Id, data.ContactId, data.LinkedEntityId,
					data.EmailRecipients, template.Template, messageData, macroComposer);
				if (sentSuccessfully) {
					sentReplicaMasks.Add(template.ReplicaMask);
				} else {
					failedReplicaMasks.Add(template.ReplicaMask);
				}
			}
			if (data.ReplicaMasks == null) {
				return new SendTestMessageResult {
					Success = sentReplicaMasks.Count > 0,
					SentReplicaMasks = sentReplicaMasks.ToArray(),
					FailedReplicaMasks = failedReplicaMasks.ToArray()
				};
			}
			foreach (var mask in data.ReplicaMasks) {
				if (!sentReplicaMasks.Contains(mask) && !failedReplicaMasks.Contains(mask)) {
					failedReplicaMasks.Add(mask);
				}
			}
			return new SendTestMessageResult {
				Success = sentReplicaMasks.Count > 0,
				SentReplicaMasks = sentReplicaMasks.ToArray(),
				FailedReplicaMasks = failedReplicaMasks.ToArray()
			};
		}

		private BulkEmail GetBulkEmailFromDB(Guid bulkEmailId) {
			var bulkEmail = new BulkEmail(_userConnection);
			var fetchBulkEmailResult = bulkEmail.FetchFromDB("Id", bulkEmailId,
				new[] {
					"Id",
					"StartDate",
					"TemplateSubject",
					"SenderName",
					"SenderEmail",
					"AudienceSchema",
					"Owner",
					"UseUtm",
					"Domains",
					"UtmSource",
					"UtmMedium",
					"UtmCampaign",
					"UtmTerm",
					"UtmContent",
					"ProviderName"
				});
			if (fetchBulkEmailResult) {
				return bulkEmail;
			}
			MailingUtilities.Log.WarnFormat(
				"[CESMaillingProvider.GetBulkEmailFromDB]: FetchFromDB BulkEmail: {0} fails.", bulkEmailId);
			throw new Exception(
				$"[CESMaillingProvider.GetBulkEmailFromDB]: FetchFromDB BulkEmail: {bulkEmailId} fails.");
		}

		private DCTemplateModel GetDcTemplateModel(Guid bulkEmailId,
			DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> templateReadOptions) {
			var template = TemplateRepository.ReadByRecordId(bulkEmailId, templateReadOptions);
			return template;
		}

		private string GetLinkedEntitySchemaName(Guid audienceSchemaId) {
			var audienceSchema = new BulkEmailAudienceSchema(_userConnection);
			audienceSchema.FetchFromDB("Id", audienceSchemaId, new[] { "EntityObject" });
			return _userConnection.EntitySchemaManager
				.FindInstanceByUId(audienceSchema.EntityObjectId)?.Name;
		}

		private BulkEmailMacroComposer GetMacroComposer(BulkEmail bulkEmail) {
			var linkedEntitySchemaName = bulkEmail.AudienceSchemaId.IsEmpty() 
				? string.Empty 
				: GetLinkedEntitySchemaName(bulkEmail.AudienceSchemaId);
			var bulkEmailMacroComposer = ClassFactory.Get<BulkEmailMacroComposer>(
				new ConstructorArgument("userConnection", _userConnection),
				new ConstructorArgument("bulkEmail", bulkEmail),
				new ConstructorArgument("linkedEntitySchemaName", linkedEntitySchemaName));
			bulkEmailMacroComposer.MacrosHelper.UserConnection = _userConnection;
			return bulkEmailMacroComposer;
		}

		private IEnumerable<DCReplicaModel> GetReplicasByMasks(DCTemplateModel template,
			IEnumerable<int> replicaMasks = null) {
			var replicas = template.Replicas;
			if (replicaMasks?.Any() == true) {
				replicas = replicas.Where(x => replicaMasks.Contains(x.Mask));
			}
			return replicas;
		}

		private EmailMessage InitEmailMessage(SendMessageData messageData, BulkEmailMacroComposer macroComposer,
			IMailingTemplate template) {
			var bulkEmail = messageData.BulkEmail;
			string senderEmail;
			string senderName;
			if (template is IMailingTemplateWithHeaders templateReplica) {
				senderEmail = templateReplica.SenderEmail;
				senderName = templateReplica.SenderName;
			} else {
				senderEmail = bulkEmail.SenderEmail;
				senderName = bulkEmail.SenderName;
			}
			var message = new EmailMessage {
				subject = template.TemplateSubject,
				from_email = senderEmail,
				from_name = senderName,
				track_clicks = true,
				track_opens = true,
				images = messageData.Images,
				inline_css = true,
				provider_name = bulkEmail.ProviderName
			};
			var globalMacros = macroComposer.GetCommonMacrosValues(template.MacrosCollection);
			var mergeVars = globalMacros.Select(macros => new merge_var {
				name = macros.Key,
				content = BulkEmailMacroParser.EncodeUrlMacrosValue(macros.Key, macros.Value)
			}).ToList();
			if (!mergeVars.Any()) {
				return message;
			}
			message.InitGlobalVariable();
			message.global_merge_vars.AddRange(mergeVars);
			return message;
		}

		private void OverrideFromEmailHeader(EmailMessage emailMessage, CESMailingTemplate cesTemplate,
			IEnumerable<merge_var> recipientMergeVars) {
			if (cesTemplate.TrackedAliases.TryGetValue(MailingConsts.FromNameMacroKey, out var fromNameMacroName)) {
				var fromNameMacroValue = recipientMergeVars.FirstOrDefault(x => x.name == fromNameMacroName)?.content;
				emailMessage.from_name = fromNameMacroValue;
			}
			if (!cesTemplate.TrackedAliases.TryGetValue(MailingConsts.FromEmailMacroKey, out var fromEmailMacroName)) {
				return;
			}
			var fromEmailMacroValue = recipientMergeVars.FirstOrDefault(x => x.name == fromEmailMacroName)?.content;
			emailMessage.from_email = fromEmailMacroValue;
		}

		private void PrepareTestRecipient(Guid contactId, Guid linkedEntityId, string emailRecipient,
				BulkEmailMacroComposer macroComposer, EmailMessage emailMessage, IMailingTemplate template) {
			var emailAddresses = emailRecipient == null ? Enumerable.Empty<EmailAddress>() : Regex
				.Split(emailRecipient, EmailSplitRegexPattern).Where(x => x.IsNotNullOrWhiteSpace())
				.Select(x => new EmailAddress(Guid.NewGuid(), x.Trim()));
			if (!contactId.Equals(Guid.Empty)) {
				emailMessage.InitRecipientVariable();
				foreach (var emailAddress in emailAddresses) {
					var macrosValues = macroComposer.GetContactMacrosValues(contactId, template.MacrosCollection);
					if (linkedEntityId.IsNotEmpty()) {
						var linkedEntityMacrosValues = macroComposer.GetLinkedEntityMacrosValues(linkedEntityId,
							template.MacrosCollection);
						macrosValues = macrosValues.Concat(linkedEntityMacrosValues)
							.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
					}
					var mergeVars = CreateRecipientMergeVars(contactId, emailAddress.email, macrosValues);
					emailMessage.merge_vars.Add(mergeVars);
				}
			}
			emailMessage.to = emailAddresses;
			var cesTemplate = template as CESMailingTemplate;
			var recipientMergeVars = emailMessage.merge_vars.FirstOrDefault()?.vars;
			if (cesTemplate == null || recipientMergeVars == null) {
				return;
			}
			OverrideFromEmailHeader(emailMessage, cesTemplate, recipientMergeVars);
		}

		private void RegisterSenderDomain(string senderEmail) {
			try {
				var domain = new Regex("^.*@").Replace(senderEmail, "");
				CloudEngine.RegisterSenderDomain(domain);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[CESMaillingProvider.RegisterSenderDomain]: Error while registering domain for email: {0}", e,
					senderEmail);
			}
		}

		private bool SendTestMessageTemplate(Guid bulkEmailId, Guid contactId, Guid linkedEntityId,
				string emailRecipient, IMailingTemplate template, SendMessageData messageData,
				BulkEmailMacroComposer macroComposer) {
			var templateContent = template.Content;
			if (templateContent?.IsEmpty() != false) {
				MailingUtilities.Log.InfoFormat("[SendTestMessage]: Can't save template");
				return false;
			}
			var emailMessage = InitEmailMessage(messageData, macroComposer, template);
			emailMessage.images = template.InlineImages.ToCESImage();
			emailMessage.html = templateContent;
			emailMessage.tags = new List<string> {
				TestMessageTag
			};
			PrepareTestRecipient(contactId, linkedEntityId, emailRecipient, macroComposer, emailMessage, template);
			if (!Validator.ValidateTestMessage(bulkEmailId, contactId, template, emailMessage)) {
				return false;
			}
			try {
				ServiceApi.SendMessage(emailMessage, bulkEmailId);
				MailingUtilities.Log.InfoFormat("[SendTestMessage]: Can't save template");
				return true;
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat("[SendTestMessage]: Error while sending message", e);
				return false;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sends test bulk email message with dynamic content. Sends all replicas if 
		/// <see cref="SendTestMessageData.ReplicaMasks"/> property of the parameter <paramref name="data"/>
		/// is null or empty, or chosen replicas in another case.
		/// </summary>
		/// <param name="data">Data required for test message sending.</param>
		/// <returns>Results of successful sending for each replica.</returns>
		public SendTestMessageResult Send(SendTestMessageData data) {
			var bulkEmailId = data.BulkEmailId;
			var bulkEmail = GetBulkEmailFromDB(bulkEmailId);
			RegisterSenderDomain(bulkEmail.SenderEmail);
			var messageData = CreateSendMessageData(bulkEmail);
			var templateReadOptions = new DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> {
				TemplateReadOptions = DCTemplateReadOption.None
			};
			var dcTemplateModel = GetDcTemplateModel(bulkEmail.Id, templateReadOptions);
			var replicasToSend = GetReplicasByMasks(dcTemplateModel, data.ReplicaMasks).ToArray();
			return ExecuteDCTestMessageSending(data, bulkEmail, messageData, replicasToSend);
		}

		#endregion

	}

	#endregion

}

