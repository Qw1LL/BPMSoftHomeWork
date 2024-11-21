namespace BPMSoft.Configuration
{
	using BPMSoft.Core.DB;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using System;

	#region Class: LeadNotificationProvider

	/// <summary>
	/// Lead notification provider.
	/// </summary>
	public class LeadNotificationProvider : BaseNotificationProvider, INotificationProvider
	{
		#region Fields: Private

		private const string GROUP_NAME = "Notification";
		private const string NAME = "Lead";

		#endregion

		#region Constructors: Public

		public LeadNotificationProvider(UserConnection userConnection)
			: base(userConnection) {
		}

		public LeadNotificationProvider(Dictionary<string, object> parameters)
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

		#region Methods: Protected

		protected override void AddColumns(Select select) {
			select
				.Column("Reminding", "Id").As("Id")
				.Column("Reminding", "RemindTime").As("RemindTime")
				.Column("Reminding", "ContactId").As("RemindingContactId")
				.Column("Reminding", "Description").As("Description")
				.Column("Lead", "Id").As("LeadId")
				.Column("Lead", "Name").As("Title")
				.Column("SysSchema", "Name").As("EntitySchemaName")
				.Column("NotificationsSettings", "SysImageId").As("ImageId");
		}

		protected override void JoinTables(Select select) {
			select
				.LeftOuterJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
				.InnerJoin("Lead").On("Reminding", "SubjectId").IsEqual("Lead", "Id")
				.LeftOuterJoin("SysSchema").On("Reminding", "SysEntitySchemaId").IsEqual("SysSchema", "UId")
				.LeftOuterJoin("NotificationsSettings")
					.On("Reminding", "SysEntitySchemaId").IsEqual("NotificationsSettings", "SysEntitySchemaUId");
		}

		protected override void AddConditions(Select select) {
			base.AddConditions(select);
			select.And("Reminding", "NotificationTypeId")
				.IsEqual(Column.Parameter(RemindingConsts.NotificationTypeRemindingId));
		}

		protected override INotificationInfo GetRecordNotificationInfo(
				Dictionary<string, string> dictionaryColumnValues) {
			Guid imageId;
			Guid.TryParse(dictionaryColumnValues["ImageId"], out imageId);
			return new NotificationInfo() {
				Title = dictionaryColumnValues["Title"],
				Body = dictionaryColumnValues["Description"],
				ImageId = imageId,
				EntityId = new Guid(dictionaryColumnValues["LeadId"]),
				EntitySchemaName = dictionaryColumnValues["EntitySchemaName"],
				MessageId = new Guid(dictionaryColumnValues["Id"]),
				SysAdminUnit = new Guid(dictionaryColumnValues["SysAdminUnitId"]),
				GroupName = Group
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Appending name of columns for creating dictionary of the values.
		/// </summary>
		/// <param name="columns">A <see cref="List<T></see>"/> columns.</param>
		public override void SetColumns(List<string> columns) {
			columns.Add("Id");
			columns.Add("ContactId");
			columns.Add("RemindTime");
			columns.Add("SubjectCaption");
			columns.Add("SubjectId");
			columns.Add("Description");
		}

		/// <summary>
		/// Returns the record result.
		/// </summary>
		/// <param name="dictionaryColumnValues">A <see cref="Dictionary<string, string>"> column value.</param>
		/// <returns>A <see cref="Strng">.</returns>
		public override string GetRecordResult(Dictionary<string, string> dictionaryColumnValues) {
			string title = dictionaryColumnValues["Description"];
			string id = dictionaryColumnValues["Id"];
			string remindTime = dictionaryColumnValues["RemindTime"];
			string body = dictionaryColumnValues["SubjectCaption"];
			string subjectId = dictionaryColumnValues["SubjectId"];
			var key = id + "_" + remindTime;
			var popup = new PopupData() {
				Title = title,
				Body = body,
				EntityId = subjectId,
				EntitySchemaName = "Lead"
			};
			var serializePopup = popup.Serialize();
			return string.Format("\"{0}\": {1}", key, serializePopup);
		}

		/// <summary>
		/// Returns <see cref="Select" of entity./>
		/// </summary>
		/// <returns>A <see cref="Select"/> instance.</returns>
		public override Select GetEntitiesSelect() {
			Select entitiesSelect = null;
			if (parameters != null && parameters.ContainsKey("sysAdminUnitId") && parameters.ContainsKey("dueDate")) {
				Guid sysAdminUnitId = (Guid)parameters["sysAdminUnitId"];
				DateTime date = (DateTime)parameters["dueDate"];
				entitiesSelect = new Select(UserConnection)
					.Column("Reminding", "Id")
					.Column("Reminding", "RemindTime").As("RemindTime")
					.Column("Reminding", "ContactId").As("ContactId")
					.Column("Reminding", "SubjectId").As("SubjectId")
					.Column("Reminding", "Description").As("Description")
					.Column("Reminding", "SubjectCaption")
					.Distinct()
					.From("Reminding")
					.LeftOuterJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
					.InnerJoin("Lead").On("Reminding", "SubjectId").IsEqual("Lead", "Id")
					.Where("RemindTime").IsLessOrEqual(Column.Parameter(date.ToUniversalTime()))
					.And("IsRead").IsEqual(Column.Parameter(false))
					.And("SysAdminUnit", "Id").IsEqual(Column.Parameter(sysAdminUnitId)) as Select;
			}
			return entitiesSelect;
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

