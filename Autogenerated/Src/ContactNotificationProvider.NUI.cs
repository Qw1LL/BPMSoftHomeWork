namespace BPMSoft.Configuration
{
	using BPMSoft.Core.DB;
	using BPMSoft.Core;
	using BPMSoft.Common;
	using System;
	using System.Data;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	#region Class: ContactNotificationProvider

	public class ContactNotificationProvider : BaseNotificationProvider, INotification
	{
		#region Constants: Private

		private const string GROUP_NAME = "Notification";
		private const string NAME = "Contact";

		#endregion

		#region Fields: Private

		QueryColumnExpression contactSchemaUId;

		#endregion

		#region Constructors: Public

		public ContactNotificationProvider(UserConnection userConnection)
			: base(userConnection) {
			SetContactSchemaUid();
		}

		public ContactNotificationProvider(Dictionary<string, object> parameters)
			: base(parameters) {
			SetContactSchemaUid();
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
		
		private void SetContactSchemaUid() {
			var manager = UserConnection.GetSchemaManager("EntitySchemaManager");
			var contact = manager.FindItemByName("Contact");
			contactSchemaUId = Column.Parameter(contact.UId);
		}
		
		#endregion

		#region Methods: Protected

		protected override void AddColumns(Select select) {
			select
				.Column("Reminding", "Id").As("Id")
				.Column("Reminding", "RemindTime").As("RemindTime")
				.Column("Reminding", "ContactId").As("ContactId")
				.Column("Reminding", "SubjectId").As("SubjectId")
				.Column("Reminding", "Description").As("Description")
				.Column("VwSysSchemaInWorkspace", "Name").As("LoaderName")
				.Column("Reminding", "SubjectCaption").As("SubjectCaption");
		}

		protected override void JoinTables(Select select) {
			select
				.LeftOuterJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
				.LeftOuterJoin("NotificationType").On("Reminding", "NotificationTypeId").IsEqual("NotificationType", "Id")
				.LeftOuterJoin("VwSysSchemaInWorkspace").On("Reminding", "LoaderId").IsEqual("VwSysSchemaInWorkspace", "UId")
				.And("VwSysSchemaInWorkspace", "SysWorkspaceId").IsEqual(Column.Parameter(UserConnection.Workspace.Id));

		}

		protected override void AddConditions(Select select) {
			base.AddConditions(select);
			string notificationTypeName = NotificationProviderType.Notification.ToString();
			select
				.And("NotificationType", "Name").IsEqual(Column.Parameter(notificationTypeName))
				.And("Reminding", "SysEntitySchemaId").IsEqual(contactSchemaUId);
		}

		protected override INotificationInfo GetRecordNotificationInfo(Dictionary<string, string> dictionaryColumnValues) {
			Guid subjectId;
			DateTime dateTime;
			Guid.TryParse(dictionaryColumnValues["SubjectId"], out subjectId);
			DateTime.TryParse(dictionaryColumnValues["RemindTime"], out dateTime);
			return new NotificationInfo() {
				Title = dictionaryColumnValues["Description"],
				Body = dictionaryColumnValues["SubjectCaption"],
				ImageId = Guid.Empty,
				EntityId = subjectId,
				EntitySchemaName = "Contact",
				MessageId = new Guid(dictionaryColumnValues["Id"]),
				SysAdminUnit = new Guid(dictionaryColumnValues["SysAdminUnitId"]),
				GroupName = Group,
				LoaderName = dictionaryColumnValues["LoaderName"],
				RemindTime = dateTime
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns notification.
		/// </summary>
		/// <returns>Notification.</returns>
		public IEnumerable<INotificationInfo> GetNotifications() {
			return GetNotificationsInfos();
		}

		public override void SetColumns(List<string> columns) {
			columns.Add("Id");
			columns.Add("ContactId");
			columns.Add("RemindTime");
			columns.Add("LoaderName");
			columns.Add("SubjectCaption");
			columns.Add("SubjectId");
			columns.Add("Description");
		}

		public override string GetRecordResult(Dictionary<string, string> dictionaryColumnValues) {
			string title = dictionaryColumnValues["Description"];
			string id = dictionaryColumnValues["Id"];
			string contactId = dictionaryColumnValues["ContactId"];
			string remindTime = dictionaryColumnValues["RemindTime"];
			string loaderName = dictionaryColumnValues["LoaderName"];
			string body = dictionaryColumnValues["SubjectCaption"];
			string subjectId = dictionaryColumnValues["SubjectId"];

			string key = id + "_" + remindTime;
			var popup = new PopupData() {
				Title = title,
				Body = body,
				ImageId = string.Empty,
				EntityId = subjectId,
				EntitySchemaName = "Contact",
				LoaderName = loaderName
			};
			var serializePopup = popup.Serialize();
			return string.Format("\"{0}\": {1}", key, serializePopup);
		}

		public override Select GetEntitiesSelect() {
			Guid sysAdminUnitId = (Guid)this.parameters["sysAdminUnitId"];
			string notificationTypeName = NotificationProviderType.Notification.ToString();
			DateTime date = (DateTime)this.parameters["dueDate"];
			var select = new Select(UserConnection)
				.Column("Reminding", "Id").As("Id")
				.Column("Reminding", "RemindTime").As("RemindTime")
				.Column("Reminding", "ContactId").As("ContactId")
				.Column("Reminding", "SubjectId").As("SubjectId")
				.Column("Reminding", "Description").As("Description")
				.Column("VwSysSchemaInWorkspace", "Name").As("LoaderName")
				.Column("Reminding", "SubjectCaption")
				.Distinct()
				.From("Reminding")
				.LeftOuterJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
				.LeftOuterJoin("NotificationType").On("Reminding", "NotificationTypeId").IsEqual("NotificationType", "Id")
				.LeftOuterJoin("VwSysSchemaInWorkspace").On("Reminding", "LoaderId").IsEqual("VwSysSchemaInWorkspace", "UId")
				.And("VwSysSchemaInWorkspace", "SysWorkspaceId").IsEqual(Column.Parameter(UserConnection.Workspace.Id))
				.Where("RemindTime").IsLessOrEqual(Column.Parameter(date.ToUniversalTime()))
				.And("SysAdminUnit", "Id").IsEqual(Column.Parameter(sysAdminUnitId))
				.And("NotificationType", "Name").IsEqual(Column.Parameter(notificationTypeName))
				.And("Reminding", "SysEntitySchemaId").IsEqual(contactSchemaUId)
				.And("Reminding", "IsRead").IsEqual(Column.Parameter(false)) as Select;
			return select;
		}

		#endregion
	}

	#endregion
}

