namespace BPMSoft.Configuration
{
	using BPMSoft.Core.DB;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Common;
	using System;
	using System.Data;
	using System.Linq;
	using System.Collections;

	#region Class: ForecastNotificationProvider

	public class ForecastNotificationProvider : BaseNotificationProvider, INotification
	{

		#region Fields: Private

		private const string GROUP_NAME = "Notification";
		private const string NAME = "Forecast";

		#endregion

		#region Constructors: Public

		public ForecastNotificationProvider(Dictionary<string, object> parameters)
			: base(parameters) {
		}

		public ForecastNotificationProvider(UserConnection userConnection)
			: base(userConnection) {
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
			var bodyTemplate = UserConnection.GetLocalizableString("ForecastNotificationProvider", "BodyTemplate");
			var body = dictionaryColumnValues["Description"];
			body = string.Format(bodyTemplate, body);
			return body;
		}

		private string GetTitle(Dictionary<string, string> dictionaryColumnValues) {
			var titleTemplate = UserConnection.GetLocalizableString("ForecastNotificationProvider", "TitleTemplate");
			var title = dictionaryColumnValues["SubjectCaption"];
			title = string.Format(titleTemplate, title);
			return title;
		}

		#endregion

		#region Methods: Protected

		protected override void AddColumns(Select select) {
			select
				.Column("Reminding", "Id").As("Id")
				.Column("Reminding", "CreatedById").As("CreatedById")
				.Column("Reminding", "Description").As("Description")
				.Column("Reminding", "SubjectCaption").As("SubjectCaption")
				.Column("Reminding", "SubjectId").As("EntityId");
		}

		protected override void JoinTables(Select select) {
			select
				.InnerJoin("Forecast").On("Reminding", "SubjectId").IsEqual("Forecast", "Id")
				.InnerJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId");
		}

		protected override INotificationInfo GetRecordNotificationInfo(Dictionary<string, string> dictionaryColumnValues) {
			string body = GetBody(dictionaryColumnValues);
			string title = GetTitle(dictionaryColumnValues);
			Guid imageId = GetNotificationImage("Forecast", RemindingConsts.NotificationTypeNotificationId);
			return new NotificationInfo() {
				Title = title,
				Body = body,
				ImageId = imageId,
				EntityId = new Guid(dictionaryColumnValues["EntityId"]),
				EntitySchemaName = "Forecast",
				MessageId = new Guid(dictionaryColumnValues["Id"]),
				SysAdminUnit = new Guid(dictionaryColumnValues["SysAdminUnitId"]),
				GroupName = Group
			};
		}

		#endregion

		#region Methods: Public

		public override void SetColumns(List<string> columns) {
			columns.Add("Id");
			columns.Add("CreatedById");
			columns.Add("Description");
			columns.Add("SubjectCaption");
			columns.Add("EntityId");
			columns.Add("SchemaName");
			columns.Add("ImageId");
		}

		public override string GetRecordResult(Dictionary<string, string> dictionaryColumnValues) {
			var titleTemplate = UserConnection.GetLocalizableString("ForecastNotificationProvider", "TitleTemplate");
			var bodyTemplate = UserConnection.GetLocalizableString("ForecastNotificationProvider", "BodyTemplate");
			var notificationId = dictionaryColumnValues["Id"];
			var createdById = dictionaryColumnValues["CreatedById"];
			var body = dictionaryColumnValues["Description"];
			var title = dictionaryColumnValues["SubjectCaption"];
			var entityId = dictionaryColumnValues["EntityId"];
			var schemaName = dictionaryColumnValues["SchemaName"];
			var imageId = dictionaryColumnValues["ImageId"];
			body = string.Format(bodyTemplate, body);
			title = string.Format(titleTemplate, title);
			var popup = new PopupData() {
				Title = title,
				Body = body,
				ImageId = imageId,
				EntityId = entityId,
				EntitySchemaName = schemaName
			};
			var serializePopup = popup.Serialize();
			return string.Format(template, notificationId, serializePopup);
		}

		public override Select GetEntitiesSelect() {
			Guid currentContactId = UserConnection.CurrentUser.ContactId;
			var select = new Select(UserConnection)
				.Column("Reminding", "Id").As("Id")
				.Column("Reminding", "CreatedById").As("CreatedById")
				.Column("Reminding", "Description").As("Description")
				.Column("Reminding", "SubjectCaption").As("SubjectCaption")
				.Column("Reminding", "SubjectId").As("EntityId")
				.Column("SysSchema", "Name").As("SchemaName")
				.Column("NotificationsSettings", "SysImageId").As("ImageId")
					.Distinct()
				.From("Reminding")
				.InnerJoin("Forecast").On("Reminding", "SubjectId").IsEqual("Forecast", "Id")
				.Join(JoinType.LeftOuter, "SysSchema")
					.On("Reminding", "SysEntitySchemaId").IsEqual("SysSchema", "UId")
				.Join(JoinType.LeftOuter, "NotificationsSettings")
					.On("Reminding", "SysEntitySchemaId").IsEqual("NotificationsSettings", "SysEntitySchemaUId")
				.Where("Reminding", "IsRead").IsEqual(Column.Parameter(false))
				.And("Reminding", "AuthorId").IsEqual(Column.Parameter(currentContactId))
				.And("Reminding", "CreatedById").IsEqual(Column.Parameter(currentContactId))
				as Select;
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
