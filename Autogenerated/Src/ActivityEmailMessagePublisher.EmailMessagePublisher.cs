namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Mail.Sender;

	#region Class: ActivityEmailMessagePublisher

	public class ActivityEmailMessagePublisher : BaseMessagePublisher
	{

		#region Constructor: Public

		public ActivityEmailMessagePublisher(UserConnection userConnection, Dictionary<string, string> entityFieldsData)
				: base(userConnection, entityFieldsData) {
			EntitySchemaName = "Activity";
		}

		#endregion

		#region Constants: Private

		private const string NotifySubjectLczName = "FailedEmailNotifySubject";

		#endregion

		#region Methods: Private

		/// <summary>
		/// Notify contact after failed email sending. 
		/// </summary>
		private void NotifyContact() {
			var contactId = UserConnection.CurrentUser.ContactId;
			DateTime userDateTime = UserConnection.CurrentUser.GetCurrentDateTime();
			string subject = GetLocalizableStringValue(NotifySubjectLczName);
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(EntitySchemaName);
			EntitySchema remindingSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Reminding");
			Entity remindingEntity = remindingSchema.CreateEntity(UserConnection);
			remindingEntity.SetDefColumnValues();
			remindingEntity.SetColumnValue("ModifiedOn", userDateTime);
			remindingEntity.SetColumnValue("AuthorId", contactId);
			remindingEntity.SetColumnValue("ContactId", contactId);
			remindingEntity.SetColumnValue("SourceId", RemindingConsts.RemindingSourceAuthorId);
			remindingEntity.SetColumnValue("RemindTime", userDateTime);
			remindingEntity.SetColumnValue("SubjectCaption", subject);
			remindingEntity.SetColumnValue("SysEntitySchemaId", entitySchema.UId);
			remindingEntity.SetColumnValue("SubjectId", EntityRecordId);
			remindingEntity.SetColumnValue("Hash", GetRemindingHash(contactId, entitySchema.UId));
			remindingEntity.SetColumnValue("NotificationTypeId", RemindingConsts.NotificationTypeRemindingId);
			remindingEntity.Save();
		}

		/// <summary>
		/// Create hash for reminding.
		/// </summary>
		/// <param name="contactId">Contact identifier.</param>
		/// <param name="entitySchemaUId">Entity schema identifier.</param>
		/// <returns>Reminding hash.</returns>
		private string GetRemindingHash(Guid contactId, Guid entitySchemaUId) {
			var condition = new Dictionary<string, object> {
					{ "Contact", contactId },
					{ "Author", contactId },
					{ "Source", RemindingConsts.NotificationTypeNotificationId },
					{ "SubjectId", EntityRecordId },
					{ "SysEntitySchema", entitySchemaUId }
				};
			var str = new StringBuilder();
			foreach (object value in condition.Values) {
				str.Append(value);
			}
			return FileUtilities.GetMD5Hash(Encoding.Unicode.GetBytes(str.ToString()));
		}

		/// <summary>
		/// Get localizable value by localizable string name.
		/// </summary>
		/// <param name="lczName">Localizable string name. </param>
		/// <returns>Localizable string value.</returns>
		private string GetLocalizableStringValue(string lczName) {
			return new LocalizableString(UserConnection.Workspace.ResourceStorage, "ActivityEmailMessagePublisher",
				"LocalizableStrings." + lczName + ".Value").ToString();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Send email.
		/// </summary>
		protected virtual void SendEmail() {
			var emailClientFactory = ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection", UserConnection));
			var activityEmailSender = UserConnection.GetIsFeatureEnabled("SecureEstimation") ? new SecureActivityEmailSender(emailClientFactory, UserConnection) :
					new ActivityEmailSender(emailClientFactory, UserConnection);
			activityEmailSender.Send(EntityRecordId);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Publish message.
		/// </summary>
		public override void Publish() {
			try {
				var entity = GetEntity();
				entity.SetColumnValue("TypeId", ActivityConsts.EmailTypeUId);
				entity.SetColumnValue("ActivityCategoryId", ActivityConsts.EmailActivityCategoryId);
				entity.SetColumnValue("MessageTypeId", ActivityConsts.OutgoingEmailTypeId);
				entity.SetColumnValue("EmailSendStatusId", ActivityConsts.InProgressEmailStatusId);
				entity.SetColumnValue("IsHtmlBody", true);
				entity.Save();
				SendEmail();
			} catch (Exception) {
				bool isHandlingEnabled = UserConnection.GetIsFeatureEnabled("HandleMessagePublishingExceptions");
				if (isHandlingEnabled) {
					NotifyContact();
					throw;
				}
			}
		}

		#endregion

	}

	#endregion

}
