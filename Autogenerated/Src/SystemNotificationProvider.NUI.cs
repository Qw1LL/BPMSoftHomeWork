namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: SystemNotificationProvider

	public class SystemNotificationProvider : BaseNotificationProvider, INotification
	{
		#region Constants: Private

		private const string GROUP_NAME = "Notification";
		private const string NAME = "System";

		#endregion

		#region Constructors: Public

		public SystemNotificationProvider(UserConnection userConnection)
			: base(userConnection) {
		}

		public SystemNotificationProvider(Dictionary<string, object> parameters)
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

		private Guid GetSysProcessLogUId() {
			var manager = UserConnection.GetSchemaManager("EntitySchemaManager");
			var sysProcessLog = manager.FindItemByName("SysProcessLog");
			return sysProcessLog.UId;
		}

		#endregion

		#region Methods: Protected

		protected override void AddColumns(Select select) {
			select
				.Column("Reminding", "SubjectCaption").As("SubjectCaption")
				.Column("Reminding", "Description").As("Description")
				.Column("Reminding", "SubjectId").As("EntityId")
				.Column("SysSchema", "Name").As("EntitySchemaName")
				.Column("Reminding", "Id").As("Id")
				.Column("LoaderSchema", "Name").As("LoaderName")
				.Column("Reminding", "RemindTime").As("RemindTime");
		}

		protected override void JoinTables(Select select) {
			select
				.InnerJoin("SysSchema").As("LoaderSchema")
					.On("Reminding", "LoaderId").IsEqual("LoaderSchema", "UId")
				.InnerJoin("SysSchema")
					.On("Reminding", "SysEntitySchemaId").IsEqual("SysSchema", "UId")
				.InnerJoin("SysAdminUnit")
					.On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId");
		}

		protected override INotificationInfo GetRecordNotificationInfo(Dictionary<string, string> dictionaryColumnValues) {
			Guid imageId = GetNotificationImage(dictionaryColumnValues["EntitySchemaName"], 
				RemindingConsts.NotificationTypeNotificationId);
			return new NotificationInfo() {
				Title = dictionaryColumnValues["Description"],
				Body = dictionaryColumnValues["SubjectCaption"],
				ImageId = imageId,
				EntityId = new Guid(dictionaryColumnValues["EntityId"]),
				EntitySchemaName = dictionaryColumnValues["EntitySchemaName"],
				MessageId = new Guid(dictionaryColumnValues["Id"]),
				LoaderName = dictionaryColumnValues["LoaderName"],
				SysAdminUnit = new Guid(dictionaryColumnValues["SysAdminUnitId"]),
				GroupName = Group
			};
		}
		
		protected override void AddConditions(Select select) {
			base.AddConditions(select);
			select.And("Reminding", "NotificationTypeId")
				.IsEqual(Column.Parameter(RemindingConsts.NotificationTypeNotificationId))
				.And("Reminding", "SysEntitySchemaId").In(Column.Parameter(GetSysProcessLogUId()));
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
		}

		public override string GetRecordResult(Dictionary<string, string> dictionaryColumnValues) {
			throw new NotImplementedException();
		}

		new public int GetCount() {
			Guid sysAdminUnitId = (Guid)parameters["sysAdminUnitId"];
			DateTime date = (DateTime)parameters["dueDate"];
			var countSelect = new Select(UserConnection).Column(Func.Count("Reminding", "Id")).Distinct()
				.From("Reminding")
				.LeftOuterJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
				.Where("RemindTime").IsLessOrEqual(Column.Parameter(date.ToUniversalTime()))
				.And("SysAdminUnit", "Id").IsEqual(Column.Parameter(sysAdminUnitId))
				.And("IsRead").IsEqual(Column.Parameter(false))
				.And("Reminding", "SysEntitySchemaId").In(Column.Parameter(GetSysProcessLogUId()))
				.And("Reminding", "NotificationTypeId")
					.IsEqual(Column.Parameter(RemindingConsts.NotificationTypeNotificationId)) as Select;
			int result = countSelect.ExecuteScalar<int>();
			return result;
		}

		public override Select GetEntitiesSelect() {
			return null;
		}

		#endregion
	}

	#endregion
}

