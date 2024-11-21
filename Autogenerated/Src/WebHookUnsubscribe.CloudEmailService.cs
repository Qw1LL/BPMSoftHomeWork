namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using Core.DB;

	#region Class: Unsubscribe

	public class Unsubscribe : BaseWebHook
	{

		#region Properties: Public

		public string EmailAddress {
			get;
			set;
		}

		/// <summary>
		/// Represents the identifier of the recipient in a concrete email.
		/// </summary>
		public Guid RecipientUid {
			get;
			set;
		}

		#endregion

		#region Methods: Private

		private void UpdateEmailAddress(UserConnection userConnection) {
			if (!string.IsNullOrEmpty(EmailAddress) || RecipientUid == Guid.Empty) {
				return;
			}
			var bet = new BulkEmailTarget(userConnection);
			var isFetchSuccess = bet.FetchFromDB("MandrillId", RecipientUid, new[] { "EmailAddress" });
			if (isFetchSuccess) {
				EmailAddress = bet.EmailAddress;
			}
		}

		#endregion

		#region Methods: Public

		public override string GetGroupKey() {
			return base.GetGroupKey() + EmailAddress + RecipientUid;
		}

		public override void HandleWebHook(UserConnection userConnection) {
			UpdateEmailAddress(userConnection);
			var subSelectQuery = new Select(userConnection)
				.Column(Column.Const(1))
				.From("ContactCommunication")
				.Where("ContactId").IsEqual("Contact","Id")
				.And("CommunicationTypeId")
				.IsEqual(Column.Parameter(new Guid(CommunicationTypeConsts.EmailId)))
				.And("Number").IsEqual(Column.Parameter(EmailAddress)) as Select;
			subSelectQuery.SpecifyNoLockHints();
			new Update(userConnection, "Contact")
				.Set("DoNotUseEmail", Column.Const(true))
				.Where()
				.Exists(subSelectQuery).Execute();
		}

		#endregion

	}
	
	#endregion

}

