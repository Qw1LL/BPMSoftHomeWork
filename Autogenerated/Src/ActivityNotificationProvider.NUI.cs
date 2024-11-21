namespace BPMSoft.Configuration
{
	using BPMSoft.Core.DB;
	using BPMSoft.Core;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	#region Class: ActivityNotificationProvider

	[Obsolete("Will be removed in 7.12.2")]
	public class ActivityNotificationProvider : BaseNotificationProvider, INotification
	{

		#region Fields: Private

		private const string GROUP_NAME = "Reminding";
		private const string NAME = "Activity";

		#endregion

		#region Constructors: Public

		public ActivityNotificationProvider(UserConnection userConnection)
			: base(userConnection) {
		}

		public ActivityNotificationProvider(Dictionary<string, object> parameters) 
			: base(parameters) {
		}
		 
		#endregion

		#region Properties: Public

		/// <summary>
		/// Group name.
		/// </summary>
		public string Group {
			get {
				return GROUP_NAME;
			}
		}

		/// <summary>
		/// Provider name.
		/// </summary>
		public string Name {
			get {
				return NAME;
			}
		}

		#endregion

		#region Methods: Private

		private string GetBody(Dictionary<string, string> dictionaryColumnValues) {
			var activityTitle = dictionaryColumnValues["Title"];
			var accountName = dictionaryColumnValues["AccountName"];
			var contactName = dictionaryColumnValues["ContactName"];
			var customer = (new List<string>() { accountName, contactName })
				.Where(item => !string.IsNullOrWhiteSpace(item));
			var customerTitle = string.Join(", ", customer);
			var bodyWithCustomerTitle = string.Format("{0}: {1}", customerTitle, activityTitle);
			var bodyWithoutCustomerTitle = string.Format("{0}", activityTitle);
			var body = string.IsNullOrWhiteSpace(customerTitle) ? bodyWithoutCustomerTitle : bodyWithCustomerTitle;
			return body;
		}

		#endregion

		#region Methods: Protected

		protected override void AddColumns(Select select) {
			select
				.Column("Reminding", "Id").As("Id")
				.Column("Reminding", "RemindTime").As("RemindTime")
				.Column("Reminding", "ContactId").As("RemindingContactId")
				.Column("Reminding", "Description").As("Description")
				.Column("Activity", "Id").As("ActivityId")
				.Column("Activity", "Title").As("Title")
				.Column("Activity", "AccountId").As("AccountId")
				.Column("Activity", "AccountId").As("ContactId")
				.Column("Account", "Name").As("AccountName")
				.Column("Contact", "Name").As("ContactName");
		}
		
		protected override void JoinTables(Select select) {
			select
				.InnerJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
				.InnerJoin("Activity").On("Reminding", "SubjectId").IsEqual("Activity", "Id")
				.LeftOuterJoin("Account").On("Activity", "AccountId").IsEqual("Account", "Id")
				.LeftOuterJoin("Contact").On("Activity", "ContactId").IsEqual("Contact", "Id");
		}

		protected override void AddConditions(Select select) {
			base.AddConditions(select);
			select
				.And("Reminding", "NotificationTypeId")
					.IsEqual(Column.Parameter(RemindingConsts.NotificationTypeRemindingId))
				.And("Activity", "StatusId").Not().In(
					new Select(UserConnection).Column("ActivityStatus", "Id").From("ActivityStatus")
						.Where("ActivityStatus", "Finish").IsEqual(Column.Parameter(true))
				);
		}

		protected override INotificationInfo GetRecordNotificationInfo(Dictionary<string, string> dictionaryColumnValues) {
			string body = GetBody(dictionaryColumnValues);
			Guid imageId = NotificationUtilities.GetSysImageBySchemaName(UserConnection, "Activity");
			string title = UserConnection.GetLocalizableString("ActivityNotificationProvider", "Title");
			return new NotificationInfo() {
				Title = title,
				Body = body,
				ImageId = imageId,
				EntityId = new Guid(dictionaryColumnValues["ActivityId"]),
				EntitySchemaName = "Activity",
				MessageId = new Guid(dictionaryColumnValues["Id"]),
				SysAdminUnit = new Guid(dictionaryColumnValues["SysAdminUnitId"]),
				RemindTime = Convert.ToDateTime(dictionaryColumnValues["RemindTime"]),
				GroupName = Group
			};
		}

		#endregion

		#region Methods: Public

		public override void SetColumns(List<string> columns) {
			columns.Add("Id");
			columns.Add("ContactId");
			columns.Add("RemindTime");
			columns.Add("ActivityId");
			columns.Add("Title");
			columns.Add("AccountId");
			columns.Add("AccountName");
			columns.Add("ContactName");
			columns.Add("ImageId");
		}

		public override string GetRecordResult(Dictionary<string, string> dictionaryColumnValues) {
			var title = UserConnection.GetLocalizableString("ActivityNotificationProvider", "Title");
			var id = dictionaryColumnValues["Id"];
			var remindTime = dictionaryColumnValues["RemindTime"];
			var activityId = dictionaryColumnValues["ActivityId"];
			var imageId = dictionaryColumnValues["ImageId"];
			string body = GetBody(dictionaryColumnValues);
			var key = id + "_" + remindTime;
			var popup = new PopupData() {
				Title = title,
				Body = body, 
				ImageId = imageId, 
				EntityId = activityId,
				EntitySchemaName = "Activity"
			}; 
			var serializePopup = popup.Serialize();
			return string.Format("\"{0}\": {1}", key, serializePopup);
		}

		public override Select GetEntitiesSelect() {
			Guid sysAdminUnitId = (Guid)this.parameters["sysAdminUnitId"];
			DateTime date = (DateTime)this.parameters["dueDate"];
			var select = new Select(UserConnection)
				.Column("Reminding", "Id").As("Id")
				.Column("Reminding", "RemindTime").As("RemindTime")
				.Column("Reminding", "ContactId").As("RemindingContactId")
				.Column("Activity", "Id").As("ActivityId")
				.Column("Activity", "Title").As("Title")
				.Column("Activity", "AccountId").As("AccountId")
				.Column("Activity", "AccountId").As("ContactId")
				.Column("Account", "Name").As("AccountName")
				.Column("Contact", "Name").As("ContactName")
				.Column("NotificationsSettings", "SysImageId").As("ImageId")
				.Distinct()
				.From("Reminding")
				.LeftOuterJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
				.InnerJoin("Activity").On("Reminding", "SubjectId").IsEqual("Activity", "Id")
				.LeftOuterJoin("Account").On("Activity", "AccountId").IsEqual("Account", "Id")
				.LeftOuterJoin("Contact").On("Activity", "ContactId").IsEqual("Contact", "Id")
				.LeftOuterJoin("NotificationsSettings")
					.On("Reminding", "SysEntitySchemaId").IsEqual("NotificationsSettings", "SysEntitySchemaUId")
				.Where("RemindTime").IsLessOrEqual(Column.Parameter(date.ToUniversalTime()))
				.And("Reminding", "NotificationTypeId")
					.IsEqual(Column.Parameter(RemindingConsts.NotificationTypeRemindingId))
				.And("SysAdminUnit", "Id").IsEqual(Column.Parameter(sysAdminUnitId))
				.And("Activity", "StatusId").Not().In(
					new Select(UserConnection).Column("ActivityStatus", "Id").From("ActivityStatus")
						.Where("ActivityStatus", "Finish").IsEqual(Column.Parameter(true))
				) as Select;
			return select;
		}

		/// <summary>
		/// Returns notification.
		/// </summary>
		/// <returns>Notification.</returns>
		public IEnumerable<INotificationInfo> GetNotifications() {
			return GetNotificationsInfos();
		}

		#endregion
	}

	#endregion
}


