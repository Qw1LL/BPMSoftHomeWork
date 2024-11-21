namespace BPMSoft.Configuration
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: EmailWithMacrosManager

	/// <summary>
	/// An obsolete part of EmailWithMacrosManager that should be removed.
	/// </summary>
	public partial class EmailWithMacrosManager
	{

		#region Properties: Public

		[ExcludeFromCodeCoverage]
		[Obsolete("7.10.2 | Property is not in use.")]
		public string EmailSender {
			get;
			set;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailWithMacrosManager"/> class.
		/// </summary>
		[ExcludeFromCodeCoverage]
		[Obsolete("7.10.2 | There's no way to work without user connection.")]
		protected EmailWithMacrosManager() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailWithMacrosManager"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="emailSender">The sender of the email.</param>
		[ExcludeFromCodeCoverage]
		[Obsolete("7.10.2 | Email sender shouldn't be set from a constructor.")]
		public EmailWithMacrosManager(UserConnection userConnection, string emailSender)
			: this(userConnection) {
			EmailSender = emailSender;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Fill recipent`s fields in the activity.
		/// </summary>
		/// <param name="activity">Activity.</param>
		/// <param name="recordId">Record which used to get activity params.</param>
		/// <param name="schemaName">Schema which contains record.</param>
		[Obsolete("7.10.2 | Use FillActivityWithCaseData instead.")]
		[ExcludeFromCodeCoverage]
		protected virtual void FillRecepientActivityField(Activity activity, Guid recordId, string schemaName) {
			var contactEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schemaName);
			string contactIdName = contactEsq.AddColumn("Contact.Id").Name;
			string emailColumnName = contactEsq.AddColumn("Contact.Email").Name;
			string emailTitleColumnName = contactEsq.AddColumn("ParentActivity.Title").Name;
			string emailSenderColumnName = contactEsq.AddColumn("ParentActivity.Sender").Name;
			string emailRecipientColumnName = contactEsq.AddColumn("ParentActivity.Recepient").Name;
			string emailCcColumnName = contactEsq.AddColumn("ParentActivity.CopyRecepient").Name;
			string emailBlindCopyColumnName = contactEsq.AddColumn("ParentActivity.BlindCopyRecepient").Name;
			var contact = contactEsq.GetEntity(UserConnection, recordId);
			if (contact != null) {
				Guid contactId = contact.GetTypedColumnValue<Guid>(contactIdName);
				activity.SetColumnValue("ContactId", contactId);
				string contactEmail = contact.GetTypedColumnValue<string>(emailSenderColumnName);
				if (contactEmail.IsNullOrEmpty()) {
					contactEmail = contact.GetTypedColumnValue<string>(emailColumnName).IsNullOrEmpty() ?
						ContactUtilities.GetLastAddContactEmail(UserConnection,
						contact.GetTypedColumnValue<Guid>(contactIdName)) :
						contact.GetTypedColumnValue<string>(emailColumnName);
				}
				activity.SetColumnValue("Recepient", contactEmail);
				string title = contact.GetTypedColumnValue<string>(emailTitleColumnName);
				activity.SetColumnValue("Title", title);
				string recipient = contact.GetTypedColumnValue<string>(emailRecipientColumnName);
				string copyRecipient = contact.GetTypedColumnValue<string>(emailCcColumnName);
				string blindCopyRecipient = contact.GetTypedColumnValue<string>(emailBlindCopyColumnName);
				activity.SetColumnValue("CopyRecepient", copyRecipient);
				string recipients = recipient + ";" + copyRecipient + ";" + blindCopyRecipient;
				EmailSender = EmailSenderObtainerWrapper.GetSupportMailBox(recipients, contactId);
			}
		}

		/// <summary>
		/// Fills recipient of the e-mail <paramref name="activity"/>.
		/// Note that <paramref name="recordId"/> is identifier of the entity
		/// of entity schema with given name (<paramref name="schemaName"/>).
		/// </summary>
		/// <param name="activity">Activity entity.</param>
		/// <param name="recordId">Entity record identifier.</param>
		/// <param name="schemaName">Name of entity schema with contact.</param>
		[ExcludeFromCodeCoverage]
		[Obsolete("7.10.2 | Use FillActivityWithCaseData instead.")]
		protected virtual void FillRecipient(Activity activity, Guid recordId, string schemaName) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schemaName);
			string contactEmailColumnName = esq.AddColumn("Contact.Email").Name;
			string parentActivitySenderColumnName = esq.AddColumn("ParentActivity.Sender").Name;
			var contact = esq.GetEntity(UserConnection, recordId);
			if (contact != null) {
				var recipient = contact.GetTypedColumnValue<string>(contactEmailColumnName);
				if (string.IsNullOrEmpty(recipient)) {
					recipient = contact.GetTypedColumnValue<string>(parentActivitySenderColumnName);
				}
				activity.Recepient = recipient;
			}
		}

		#endregion

		#region Methods: Public

		[ExcludeFromCodeCoverage]
		[Obsolete("7.10.2 | Use SendEmailFrom overload instead.")]
		public void SendEmail(Guid templateId, Guid recordId, string schemaName) {
			string emailSchemaName = GetEmailTemplateSchemaName();
			var esqMacros = new EntitySchemaQuery(UserConnection.EntitySchemaManager, emailSchemaName);
			string templateBodyColumnName = esqMacros.AddColumn("Body").Name;
			string templateSubjectColumnName = esqMacros.AddColumn("Subject").Name;
			esqMacros.Filters.Add(esqMacros.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", templateId));
			var macrosTemplate = esqMacros.GetEntity(UserConnection, templateId);
			if (macrosTemplate == null) {
				return;
			}
			string macrosBody = macrosTemplate.GetTypedColumnValue<string>(templateBodyColumnName);
			string macrosSubject = macrosTemplate.GetTypedColumnValue<string>(templateSubjectColumnName);
			macrosBody = ApplyReplacements(macrosBody);
			Activity activity = CreateActivity();
			var macrosHelper = new InvokableMacrosHelper {
				UserConnection = UserConnection
			};
			activity.Body = macrosHelper.GetTextTemplate(macrosBody, schemaName, recordId);
			activity.CaseId = recordId;
			FillRecepientActivityField(activity, recordId, schemaName);
			if (string.IsNullOrEmpty(activity.Title)) {
				activity.Title = macrosHelper.GetTextTemplate(macrosSubject, schemaName, recordId);
			} else {
				activity.Title = activity.Title.IndexOf("RE: ", StringComparison.OrdinalIgnoreCase) == 0
					? activity.Title
					: "RE: " + activity.Title;
			}
			activity.Sender = EmailSender;
			activity.Save();
			SendActivity(activity.Id);
		}

		/// <summary>
		/// Builds an activity and sends it from <paramref name="sender"/>.
		/// </summary>
		/// <param name="schemaName">Entity schema name <paramref name="recordId"/> belongs to.</param>
		/// <param name="recordId">Entity record identifier.</param>
		/// <param name="sender">Sender e-mail.</param>
		/// <param name="tplId">Template record identifier.</param>
		[ExcludeFromCodeCoverage]
		[Obsolete("7.10.2 | Use SendEmail(caseId, tplId) overload instead.")]
		public void SendEmail(string schemaName, Guid recordId, string sender, Guid tplId) {
			Activity activity = CreateActivity();
			activity.Body = GetTemplateBody(schemaName, recordId, tplId);
			activity.Title = GetTemplateSubject(schemaName, recordId, tplId);
			activity.Sender = sender;
			FillRecipient(activity, recordId, schemaName);
			activity.Save();
			SendActivity(activity.Id);
		}

		#endregion

	}

	#endregion

}
