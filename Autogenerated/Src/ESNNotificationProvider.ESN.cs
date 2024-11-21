namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Common;

	#region Enum: ESNNotificationTitle

	public enum ESNNotificationTitle
	{
		Liked = 0,
		Commented = 1,
		Mentioned = 2,
		NewMessage = 3
	}

	#endregion

	#region Class: ESNNotificationProvider

	public class ESNNotificationProvider : BaseNotificationProvider, INotification
	{
		#region Constants: Private

		private const string GROUP_NAME = "ESNNotification";
		private const string NAME = "ESN";

		#endregion

		#region Fields: Private

		private string _titleCommented;
		private string _titleMentioned;
		private string _titleNewMessage;
		private string _titleLiked;
		private string _dateMacros;
		private string _timeMacros;
		private string _bodyDateEvent;

		#endregion

		#region Constructors: Public

		public ESNNotificationProvider(Dictionary<string, object> parameters)
			: base(parameters) {
			SetStringValue();
		}

		public ESNNotificationProvider(UserConnection userConnection)
			: base(userConnection) {
			SetStringValue();
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

		private string GetDateEvent(string value) {
			DateTime dateTime = Convert.ToDateTime(value);
			var date = dateTime.ToString(_dateMacros);
			var time = dateTime.ToString(_timeMacros);
			return string.Format(_bodyDateEvent, date, time);
		}

		private string GetTitle(string typeName) {
			var item = (ESNNotificationTitle)Enum.Parse(typeof(ESNNotificationTitle), typeName);
			switch (item) {
				case ESNNotificationTitle.Commented:
					return _titleCommented;
				case ESNNotificationTitle.Liked:
					return _titleLiked;
				case ESNNotificationTitle.Mentioned:
					return _titleMentioned;
				case ESNNotificationTitle.NewMessage:
					return _titleNewMessage;
				default:
					return string.Empty;
			}
		}

		private Select GetSubSelect() {
			var select = new Select(UserConnection).Distinct()
				.Column("SysAdminUnit", "Id").As("SysAdminUnitId")
				.Column("ESNNotification", "CreatedOn").As("CreatedOn")
				.Column("ContactInfo", "Name").As("CreatedByName")
				.Column("ContactInfo", "PhotoId").As("PhotoId")
				.Column("ESNNotificationType", "Name").As("TypeName")
				.Column("ESNNotificationType", "Action").As("TypeAction")
				.Column("SocialMessage", "Id").As("MessageId")
				.Column("SocialMessage", "EntityId").As("EntityId")
				.Column("SysSchema", "Name").As("SchemaName")
				.From("ESNNotification")
				.Join(JoinType.LeftOuter, "SocialMessage")
					.On("ESNNotification", "SocialMessageId").IsEqual("SocialMessage", "Id")
				.Join(JoinType.LeftOuter, "SysSchema")
					.On("SocialMessage", "EntitySchemaUId").IsEqual("SysSchema", "UId")
				.Join(JoinType.LeftOuter, "Contact")
					.On("ESNNotification", "OwnerId").IsEqual("Contact", "Id")
				.Join(JoinType.Inner, "SysAdminUnit")
					.On("Contact", "Id").IsEqual("SysAdminUnit", "ContactId")
				.Join(JoinType.LeftOuter, "Contact").As("ContactInfo")
					.On("ESNNotification", "CreatedById").IsEqual("ContactInfo", "Id")
				.Join(JoinType.LeftOuter, "ESNNotificationType")
					.On("ESNNotification", "TypeId").IsEqual("ESNNotificationType", "Id")
				 .Where("ESNNotification", "IsRead").IsEqual(Column.Parameter(false))
				 .And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true))
				 .And("ESNNotification", "CreatedById").Not().IsEqual("ESNNotification", "OwnerId") as Select;
			return select;
		}

		private void SetStringValue() {
			_titleCommented = UserConnection.GetLocalizableString("ESNNotificationProvider", "TitleCommented");
			_titleMentioned = UserConnection.GetLocalizableString("ESNNotificationProvider", "TitleMentioned");
			_titleNewMessage = UserConnection.GetLocalizableString("ESNNotificationProvider", "TitleNewMessage");
			_titleLiked = UserConnection.GetLocalizableString("ESNNotificationProvider", "TitleLiked");
			_dateMacros = UserConnection.GetLocalizableString("ESNNotificationProvider", "DateMacros");
			_timeMacros = UserConnection.GetLocalizableString("ESNNotificationProvider", "TimeMacros");
			_bodyDateEvent = UserConnection.GetLocalizableString("ESNNotificationProvider", "BodyDateEvent");
		}

		private Guid TryParseGuid(string value) {
			var result = Guid.Empty;
			Guid.TryParse(value, out result);
			return result;
		}

		private string GetBody(Dictionary<string, string> dictionaryColumnValues) {
			string createdOn = dictionaryColumnValues["CreatedOn"];
			string createdByName = dictionaryColumnValues["CreatedByName"];
			string dateTime = GetDateEvent(createdOn);
			string typeAction = dictionaryColumnValues["TypeAction"];
			string message = dictionaryColumnValues["Message"];
			string clearString = message.GetClearString();
			return createdByName + " " + typeAction + " \"" + clearString + "\" " + dateTime;
		}
	
		#endregion

		#region Methods: Protected

		protected override Select GetBaseSelect() {
			Select subSelect = GetSubSelect();
			return new Select(UserConnection)
				.From(subSelect).As("Notifications");
		}

		protected override void AddColumns(Select select) {
			select
				.Column("Notifications", "SysAdminUnitId").As("SysAdminUnitId")
				.Column("Notifications", "CreatedOn").As("CreatedOn")
				.Column("Notifications", "CreatedByName").As("CreatedByName")
				.Column("Notifications", "PhotoId").As("PhotoId")
				.Column("Notifications", "TypeName").As("TypeName")
				.Column("Notifications", "TypeAction").As("TypeAction")
				.Column("Notifications", "MessageId").As("MessageId")
				.Column("SocialMessage", "Message").As("Message")
				.Column("Notifications", "EntityId").As("EntityId")
				.Column("Notifications", "SchemaName").As("SchemaName");
		}

		protected override void JoinTables(Select select) {
			select
				.Join(JoinType.Inner, "SocialMessage")
					.On("SocialMessage", "Id").IsEqual("Notifications", "MessageId");
		}

		protected override INotificationInfo GetRecordNotificationInfo(Dictionary<string, string> dictionaryColumnValues) {
			string typeName = dictionaryColumnValues["TypeName"];
			return new NotificationInfo() {
				Title = GetTitle(typeName),
				Body = GetBody(dictionaryColumnValues),
				ImageId = TryParseGuid(dictionaryColumnValues["PhotoId"]),
				EntityId = TryParseGuid(dictionaryColumnValues["EntityId"]),
				EntitySchemaName = dictionaryColumnValues["SchemaName"],
				MessageId = TryParseGuid(dictionaryColumnValues["MessageId"]),
				SysAdminUnit = TryParseGuid(dictionaryColumnValues["SysAdminUnitId"]),
				GroupName = Group
			};
		}

		protected override void AddActiveUserFilter(Select select) {
		}

		protected override void AddConditions(Select select) {
		}

		#endregion

		#region Methods: Public

		public override void SetColumns(List<string> columns) {
			columns.Add("Id");
			columns.Add("CreatedById");
			columns.Add("CreatedOn");
			columns.Add("CreatedByName");
			columns.Add("PhotoId");
			columns.Add("TypeName");
			columns.Add("TypeAction");
			columns.Add("MessageId");
			columns.Add("Message");
			columns.Add("EntityId");
			columns.Add("SchemaName");
		}

		public override string GetRecordResult(Dictionary<string, string> dictionaryColumnValues) {
			var id = dictionaryColumnValues["Id"];
			var notificationString = string.Empty;
			var notificationId = dictionaryColumnValues["Id"];
			var createdById = dictionaryColumnValues["CreatedById"];
			var createdOn = dictionaryColumnValues["CreatedOn"];
			var createdByName = dictionaryColumnValues["CreatedByName"];
			var photoId = dictionaryColumnValues["PhotoId"];
			var typeName = dictionaryColumnValues["TypeName"];
			var typeAction = dictionaryColumnValues["TypeAction"];
			var messageId = dictionaryColumnValues["MessageId"];
			var message = dictionaryColumnValues["Message"];
			var entityId = dictionaryColumnValues["EntityId"];
			var schemaName = dictionaryColumnValues["SchemaName"];
			var clearString = message.GetClearString();
			var dateTime = GetDateEvent(createdOn);
			var popup = new PopupData() {
				Title = GetTitle(typeName),
				Body = createdByName + " " + typeAction + " \"" + clearString + "\" " + dateTime,
				ImageId = photoId,
				EntityId = entityId,
				EntitySchemaName = schemaName,
				MessageId = messageId
			};
			var serializePopup = popup.Serialize();
			return string.Format(template, notificationId, serializePopup);
		}

		public override Select GetEntitiesSelect() {
			Guid contactId = UserConnection.CurrentUser.ContactId;
			var select = new Select(UserConnection)
				.Column("ESNNotification", "Id").As("Id")
				.Column("ESNNotification", "CreatedById").As("CreatedById")
				.Column("ESNNotification", "CreatedOn").As("CreatedOn")
				.Column("Contact", "Name").As("CreatedByName")
				.Column("Contact", "PhotoId").As("PhotoId")
				.Column("ESNNotificationType", "Name").As("TypeName")
				.Column("ESNNotificationType", "Action").As("TypeAction")
				.Column("SocialMessage", "Id").As("MessageId")
				.Column("SocialMessage", "EntityId").As("EntityId")
				.Column("SysSchema", "Name").As("SchemaName")
					.Distinct()
				.From("ESNNotification")
				.Join(JoinType.LeftOuter, "SocialMessage")
					.On("ESNNotification", "SocialMessageId").IsEqual("SocialMessage", "Id")
				.Join(JoinType.LeftOuter, "SysSchema")
					.On("SocialMessage", "EntitySchemaUId").IsEqual("SysSchema", "UId")
				.Join(JoinType.LeftOuter, "Contact")
					.On("ESNNotification", "CreatedById").IsEqual("Contact", "Id")
				.Join(JoinType.LeftOuter, "ESNNotificationType")
					.On("ESNNotification", "TypeId").IsEqual("ESNNotificationType", "Id")
				 .Where("ESNNotification", "IsRead").IsEqual(Column.Parameter(false))
				 .And("ESNNotification", "OwnerId").IsEqual(Column.Parameter(contactId))
				 .And("ESNNotification", "CreatedById").Not().IsEqual(Column.Parameter(contactId))
				 .And("SocialMessage", "ParentId").IsNull()
				 .UnionAll(
					new Select(UserConnection)
						.Column("ESNNotification", "Id").As("Id")
						.Column("ESNNotification", "CreatedById").As("CreatedById")
						.Column("ESNNotification", "CreatedOn").As("CreatedOn")
						.Column("Contact", "Name").As("CreatedByName")
						.Column("Contact", "PhotoId").As("PhotoId")
						.Column("ESNNotificationType", "Name").As("TypeName")
						.Column("ESNNotificationType", "Action").As("TypeAction")
						.Column("SocialMessage", "ParentId").As("MessageId")
						.Column("SocialMessageParent", "EntityId").As("EntityId")
						.Column("SysSchema", "Name").As("SchemaName")
							.Distinct()
						.From("ESNNotification")
						.Join(JoinType.LeftOuter, "SocialMessage")
							.On("ESNNotification", "SocialMessageId").IsEqual("SocialMessage", "Id")
						.Join(JoinType.LeftOuter, "SocialMessage").As("SocialMessageParent")
							.On("SocialMessageParent", "Id").IsEqual("SocialMessage", "ParentId")
						.Join(JoinType.LeftOuter, "SysSchema")
							.On("SocialMessageParent", "EntitySchemaUId").IsEqual("SysSchema", "UId")
						.Join(JoinType.LeftOuter, "Contact")
							.On("ESNNotification", "CreatedById").IsEqual("Contact", "Id")
						.Join(JoinType.LeftOuter, "ESNNotificationType")
							.On("ESNNotification", "TypeId").IsEqual("ESNNotificationType", "Id")
						 .Where("ESNNotification", "IsRead").IsEqual(Column.Parameter(false))
						 .And("ESNNotification", "OwnerId").IsEqual(Column.Parameter(contactId))
						 .And("ESNNotification", "CreatedById").Not().IsEqual(Column.Parameter(contactId))
						 .And("SocialMessage", "ParentId").Not().IsNull()
				 ) as Select;
			var result = new Select(UserConnection)
				.Column("Notifications", "Id")
				.Column("Notifications", "CreatedById")
				.Column("Notifications", "CreatedOn")
				.Column("Notifications", "CreatedByName")
				.Column("Notifications", "PhotoId")
				.Column("Notifications", "TypeName")
				.Column("Notifications", "TypeAction")
				.Column("Notifications", "MessageId")
				.Column("SocialMessage", "Message")
				.Column("Notifications", "EntityId")
				.Column("Notifications", "SchemaName")
				.From(select)
					.As("Notifications")
				.Join(JoinType.Inner, "SocialMessage")
					.On("SocialMessage", "Id").IsEqual("Notifications", "MessageId")
				as Select;
			return result;
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

