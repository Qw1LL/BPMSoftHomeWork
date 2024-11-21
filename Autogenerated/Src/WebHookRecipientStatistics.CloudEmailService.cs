namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using Core;
	using Core.DB;
	using BPMSoft.Common;

	#region Class: RecipientStatistics

	public class RecipientStatistics : BaseWebHook
	{
		#region Properties: Private

		private UserConnection UserConnection {
			get;
			set;
		}

		#endregion

		#region Properties: Public

		public Guid RecipientUId {
			get;
			set;
		}

		public Guid EmailId {
			get;
			set;
		}

		public string ResponseCode {
			get;
			set;
		}

		public int Opens {
			get;
			set;
		}

		public int Clicks {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the provider.
		/// </summary>
		public string ProviderName {
			get;
			set;
		}

		#endregion

		#region Methods: Private

		private void UpdateNonActualContactCommunication(Guid nonActualReasonId, string recipientEmail) {
			var update = new Update(UserConnection, "ContactCommunication")
				.Set("NonActual", Column.Parameter(true))
				.Set("NonActualReasonId", Column.Parameter(nonActualReasonId))
				.Set("DateSetNonActual", Column.Parameter(DateTime.UtcNow))
				.Where("Number").IsEqual(Column.Parameter(recipientEmail))
				.And("CommunicationTypeId").IsEqual(Column.Parameter(Guid.Parse(CommunicationTypeConsts.EmailId))) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private Select GetHardBouncedContactsSelect(string recipientEmail) {
			var communicationExistsSelect = new Select(UserConnection).Column(Column.Parameter(1))
				.From("ContactCommunication").As("cmn")
				.Where("cmn", "Number").IsNotEqual(Column.Parameter(recipientEmail))
				.And("cmn", "CommunicationTypeId").IsEqual(Column.Parameter(Guid.Parse(CommunicationTypeConsts.EmailId)))
				.And("cmn", "NonActual").IsEqual(Column.Parameter(false))
				.And("cmn", "ContactId").IsEqual("c", "Id")
				.And("c", "Email").IsEqual(Column.Parameter(recipientEmail)) as Select;
			communicationExistsSelect.SpecifyNoLockHints();
			var hardBouncedContacts = new Select(UserConnection)
				.Column("Id").As("HardBouncedContactId")
				.From("Contact").As("c")
				.Where().Exists(communicationExistsSelect) as Select;
			hardBouncedContacts.SpecifyNoLockHints();
			return hardBouncedContacts;
		}

		private void SetActualEmailToContactById(Guid contactId, string recipientEmail) {
			var emailSubSelect = new Select(UserConnection).Top(1)
				.Column("Number")
				.From("ContactCommunication").As("cc")
				.Where("cc", "ContactId").IsEqual(Column.Parameter(contactId))
				.And("cc", "Number").IsNotEqual(Column.Parameter(recipientEmail))
				.And("cc", "NonActual").IsEqual(Column.Parameter(false))
				.And("cc", "CommunicationTypeId").IsEqual(Column.Parameter(Guid.Parse(CommunicationTypeConsts.EmailId)))
				.OrderByDesc("cc", "ModifiedOn") as Select;
			emailSubSelect.SpecifyNoLockHints();
			var update = new Update(UserConnection, "Contact")
				.Set("Email", emailSubSelect)
				.Where("Id").IsEqual(Column.Parameter(contactId)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private void SetActualEmailToContact(string recipientEmail) {
			var hardBouncedContactsSelect = GetHardBouncedContactsSelect(recipientEmail);
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = hardBouncedContactsSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var contactId = reader.GetColumnValue<Guid>("HardBouncedContactId");
						SetActualEmailToContactById(contactId, recipientEmail);
					}
				}
			}
		}

		private void UpdateNonActualContactEmail(string recipientEmail) {
			var update = new Update(UserConnection, "Contact")
				.Set("IsNonActualEmail", Column.Parameter(true))
				.Where("Email").IsEqual(Column.Parameter(recipientEmail))as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private string GetRecipientEmailAddress() {
			var select = new Select(UserConnection)
				.Column("EmailAddress")
				.From("BulkEmailTarget")
				.Where("MandrillId").IsEqual(Column.Parameter(RecipientUId)) as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<string>();
		}

		private void HandleSpamResponse() {
			var recipientEmail = GetRecipientEmailAddress();
			var subSelectQuery = new Select(UserConnection)
				.Column(Column.Parameter(1))
				.From("ContactCommunication")
				.Where("ContactId").IsEqual("Contact", "Id")
				.And("CommunicationTypeId")
				.IsEqual(Column.Parameter(Guid.Parse(CommunicationTypeConsts.EmailId)))
				.And("Number").IsEqual(Column.Parameter(recipientEmail)) as Select;
			subSelectQuery.SpecifyNoLockHints();
			var update = new Update(UserConnection, "Contact")
				.Set("DoNotUseEmail", Column.Parameter(true))
				.Where()
				.Exists(subSelectQuery) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private void HandleHardBounceResponseByReasonId(Guid nonActualReasonId) {
			var recipientEmail = GetRecipientEmailAddress();
			UpdateNonActualContactCommunication(nonActualReasonId, recipientEmail);
			SetActualEmailToContact(recipientEmail);
			UpdateNonActualContactEmail(recipientEmail);
		}

		private int GetOpensCount() {
			return Opens == 0 && Clicks > 0 ? 1 : Opens;
		}

		private void HandlePersonalResponse(int responseCode) {
			var responseId = BulkEmailResponseMapping.GetResponseIdByCode(UserConnection, responseCode);
			var opensCount = GetOpensCount();
			var update = new Update(UserConnection, "BulkEmailTarget")
					.Set("ProviderName", Column.Parameter(ProviderName))
					.Set("Opens", Column.Parameter(opensCount))
					.Set("Clicks", Column.Parameter(Clicks))
					.Set("ModifiedOn", Column.Parameter(EventDate))
					.Set("BulkEmailResponseId", Column.Parameter(responseId))
				.Where("MandrillId").IsEqual(Column.Parameter(RecipientUId))
					.And("ModifiedOn").IsLess(Column.Parameter(EventDate)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private void HandleHardBounceResponse() {
			HandleHardBounceResponseByReasonId(MailingConsts.HardBounceNonActualReasonId);
		}

		private void HandleInvalidEmailResponse() {
			HandleHardBounceResponseByReasonId(MailingConsts.InvalidEmailNonActualReasonId);
		}

		#endregion

		#region Methods: Public

		public override string GetGroupKey() {
			return base.GetGroupKey() + RecipientUId.ToString();
		}

		public override void HandleWebHook(UserConnection userConnection) {
			this.UserConnection = userConnection;
			var responseCode = Convert.ToInt32(ResponseCode);
			HandlePersonalResponse(responseCode);
			var handlersByResponseCode = new Dictionary<int, Action> {
				{(int)MailingResponseCode.Spam, HandleSpamResponse},
				{(int)MailingResponseCode.HardBounce, HandleHardBounceResponse},
				{(int)MailingResponseCode.Invalid, HandleInvalidEmailResponse}
			};
			if (handlersByResponseCode.TryGetValue(responseCode, out Action handler)) {
				handler();
			}
		}

		#endregion

	}

	#endregion

}
