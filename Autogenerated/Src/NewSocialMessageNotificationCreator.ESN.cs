namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Configuration.ESN;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: NewSocialMessageNotificationCreator

	public class NewSocialMessageNotificationCreator {

		#region Constans: Private

		private const string FeatureName = "NotifyOfNewSocialMessages";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public NewSocialMessageNotificationCreator(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion
		
		#region Properties: Private
		
		private Guid CurrentContactId => _userConnection.CurrentUser.ContactId;
		
		#endregion

		#region Methods: Private

		private Select CreateOwnersQuery(Guid socialMessageId) {
			Select recordIdQuery = CreateRecordIdQuery(socialMessageId);
			Query subscriptionFilter = CreateSubscriptionFilter(recordIdQuery);
			Query unSubscriptionFilter = CreateUnSubscriptionFilter(recordIdQuery);
			Query existsNotificationFilter = CreateExistsNotificationFilter(socialMessageId);
			Query userMentionedFilter = CreateUserMentionedFilter(socialMessageId);
			Query userDenyNotificationFilter = CreateUserDenyNotificationFilter();
			var ownersQuery = new Select(_userConnection).Column("SysAdminUnit", "ContactId").As("OwnerId")
				.From("SysAdminUnit").As("SysAdminUnit").Where("SysAdminUnit", "Active").IsEqual(Column.Parameter(true))
				.And("SysAdminUnit", "ContactId").Not().IsEqual(Column.Parameter(CurrentContactId)).And()
				.Exists(subscriptionFilter).And().Not().Exists(unSubscriptionFilter).And().Not()
				.Exists(userMentionedFilter).And().Not().Exists(userDenyNotificationFilter).And().Not()
				.Exists(existsNotificationFilter) as Select;
			return ownersQuery;
		}

		private Query CreateExistsNotificationFilter(Guid socialMessageId) {
			var existsNotificationFilter = new Select(_userConnection).Column(Column.Parameter(true))
				.From("ESNNotification").As("ESNNotification").Where("ESNNotification", "SocialMessageId")
				.IsEqual(Column.Parameter(socialMessageId)).And("ESNNotification", "OwnerId")
				.IsEqual("SysAdminUnit", "ContactId");
			return existsNotificationFilter;
		}

		private Query CreateUserMentionedFilter(Guid socialMessageId) {
			var userMentionedFilter = new Select(_userConnection).Column(Column.Parameter(true))
				.From("SocialMention")
				.Where("SocialMention", "SocialMessageId").IsEqual(Column.Parameter(socialMessageId))
				.And("SocialMention", "ContactId").IsEqual("SysAdminUnit", "ContactId");
			return userMentionedFilter;
		}

		private Query CreateUserDenyNotificationFilter() {
			var userDenyNotificationFilter = new Select(_userConnection).Column(Column.Parameter(true))
				.From("EsnNotificationSettings").As("EsnNotificationSettings")
				.Where("EsnNotificationSettings", "DenyNotifyOfNewSocialMessages").IsEqual(Column.Parameter(true))
				.And("EsnNotificationSettings", "ContactId").IsEqual("SysAdminUnit", "ContactId");
			return userDenyNotificationFilter;
		}

		private Query CreateUnSubscriptionFilter(Select recordIdQuery) {
			var unSubscriptionFilter = new Select(_userConnection).Column(Column.Parameter(true)).From("SocialUnsubscription")
				.As("SocialUnsubscription").Where("SocialUnsubscription", "EntityId").IsEqual(recordIdQuery)
				.And("SocialUnsubscription", "SysAdminUnitId").IsEqual("SysAdminUnit", "Id");
			return unSubscriptionFilter;
		}

		private Query CreateSubscriptionFilter(Select recordIdQuery) {
			var subscriptionFilter = new Select(_userConnection).Column(Column.Parameter(true)).From("SocialSubscription")
				.As("SocialSubscription").Where("SocialSubscription", "EntityId").IsEqual(recordIdQuery)
				.And("SocialSubscription", "SysAdminUnitId").IsEqual("SysAdminUnit", "Id");
			return subscriptionFilter;
		}

		private Select CreateRecordIdQuery(Guid socialMessageId) {
			var recordIdQuery = new Select(_userConnection).Top(1).Column("EntityId").From("SocialMessage").Where("Id")
				.IsEqual(Column.Parameter(socialMessageId)) as Select;
			return recordIdQuery;
		}

		private void CreateNotifications(Guid socialMessageId, IEnumerable<Guid> owners) {
				Guid notificationTypeId = GetNotificationTypeId();
				var esnNotificationSchema = _userConnection.EntitySchemaManager.GetInstanceByName("ESNNotification");
				foreach (Guid ownerId in owners) {
						var newNotification = esnNotificationSchema.CreateEntity(_userConnection);
						newNotification.SetDefColumnValues();
						newNotification.SetColumnValue("CreatedById", CurrentContactId);
						newNotification.SetColumnValue("OwnerId", ownerId);
						newNotification.SetColumnValue("IsRead", false);
						newNotification.SetColumnValue("TypeId", notificationTypeId);
						newNotification.SetColumnValue("SocialMessageId", socialMessageId);
						newNotification.Save();
				}
		}

		private IEnumerable<Guid> ReadNotificationOwners(Guid socialMessageId) {
			Select ownersQuery = CreateOwnersQuery(socialMessageId);
			List<Guid> owners = new List<Guid>();
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				using (var dataReader = ownersQuery.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						owners.Add(Guid.Parse(dataReader["OwnerId"].ToString()));
					}
				}
			}
			var mentionedContacts = new List<Guid>();
			if (owners.Any()) {
				mentionedContacts.AddRange(GetMentionedContacts(socialMessageId));
			}
			return owners.Except(mentionedContacts);
		}

		private IEnumerable<Guid> GetMentionedContacts(Guid socialMessageId) {
				Select messageTextQuery = new Select(_userConnection).Column("Message")
					.From("SocialMessage").Where("Id")
					.IsEqual(Column.Parameter(socialMessageId)) as Select;
				var messageText = messageTextQuery.ExecuteScalar<string>();
				return CommonUtilities.ParseGuidsFromString(messageText);
		}

		private Guid GetNotificationTypeId() {
			var notificationTypeIddQuery = new Select(_userConnection).Top(1).Column("Id").From("ESNNotificationType")
				.Where("Name").IsEqual(Column.Parameter("NewMessage")) as Select;
			var notificationTypeId = notificationTypeIddQuery.ExecuteScalar<Guid>();
			return notificationTypeId;
		}

		#endregion

		#region Methods: Public

		public void CreateNotificationBySocialMessage(Guid socialMessageId) {
			var owners = ReadNotificationOwners(socialMessageId);
			CreateNotifications(socialMessageId, owners);
		}

		#endregion

	} 

	#endregion
}
