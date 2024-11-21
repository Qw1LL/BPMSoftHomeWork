namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Common;

	#region Class: AnniversaryNotificationProvider

	public class AnniversaryNotificationProvider : BaseNotificationProvider, INotification
	{
		#region Constants: Private

		private const string GROUP_NAME = "Anniversary";
		private const string NAME = "Anniversary";

		#endregion

		#region Fields: Private

		private string _body;
		private string _bodyContact;
		private string _bodyAccount;
		private string _titleContact;
		private string _titleAccount;
		private string _th;
		private string _st;
		private string _nd;
		private string _rd;

		#endregion

		#region Constructors: Public

		public AnniversaryNotificationProvider(UserConnection userConnection)
			: base(userConnection) {
			SetResources();
		}

		public AnniversaryNotificationProvider(Dictionary<string, object> parameters)
			: base(parameters) {
			SetResources();
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

		private void SetResources() {
			_bodyContact = UserConnection.GetLocalizableString("AnniversaryNotificationProvider", "BodyContact");
			_bodyAccount = UserConnection.GetLocalizableString("AnniversaryNotificationProvider", "BodyAccount");
			_titleContact = UserConnection.GetLocalizableString("AnniversaryNotificationProvider", "TitleContact");
			_titleAccount = UserConnection.GetLocalizableString("AnniversaryNotificationProvider", "TitleAccount");
			_th = UserConnection.GetLocalizableString("AnniversaryNotificationProvider", "thOrdinal");
			_st = UserConnection.GetLocalizableString("AnniversaryNotificationProvider", "stOrdinal");
			_nd = UserConnection.GetLocalizableString("AnniversaryNotificationProvider", "ndOrdinal");
			_rd = UserConnection.GetLocalizableString("AnniversaryNotificationProvider", "rdOrdinal");
		}

		private int GetYear(string date) {
			var zeroTime = new DateTime(1, 1, 1);
			var currentDate = UserConnection.CurrentUser.GetCurrentDateTime();
			DateTime anniversaryDate = Convert.ToDateTime(date);
			if (anniversaryDate.CompareTo(currentDate) > 0) {
				return 0;
			}
			TimeSpan interval = currentDate.Subtract(anniversaryDate);
			int year = (zeroTime + interval).Year;
			return year;
		}

		private string AddOrdinalEnu(string value) {
			var number = int.Parse(value);
			if (number <= 0) {
				return string.Empty;
			}
			switch (number % 100) {
				case 11:
				case 12:
				case 13:
					return number + _th;
			}
			switch (number % 10) {
				case 1:
					return number + _st;
				case 2:
					return number + _nd;
				case 3:
					return number + _rd;
				default:
					return number + _th;
			}
		}

		private string GetContractions(string value) {
			string currentCulture = UserConnection.CurrentUser.Culture.Name;
			if (currentCulture.Contains("en")) {
				return AddOrdinalEnu(value);
			}
			return value;
		}

		private string GetDayAndMonth(string value) {
			DateTime anniversaryDate = Convert.ToDateTime(value);
			return anniversaryDate.ToString("MM/dd");
		}

		private void SetBodyForContact(string contactName, string contactDate) {
			if (!string.IsNullOrWhiteSpace(contactName) && !string.IsNullOrWhiteSpace(contactDate)) {
				string date = GetDayAndMonth(contactDate);
				_body = string.Format(_bodyContact, date, contactName);
			}
		}

		private void SetBodyForAccount(string accountName, string accountDate) {
			if (!string.IsNullOrWhiteSpace(accountName) && !string.IsNullOrWhiteSpace(accountDate)) {
				string years = GetYear(accountDate).ToString();
				string contraction = GetContractions(years);
				string date = GetDayAndMonth(accountDate);
				_body = string.Format(_bodyAccount, date, accountName, contraction);
			}
		}

		private void SetBody(IDictionary<string, string> dictionaryColumnValues) {
			var contactName = dictionaryColumnValues["ContactName"];
			var contactDate = dictionaryColumnValues["ContactDate"];
			var accountName = dictionaryColumnValues["AccountName"];
			var accountDate = dictionaryColumnValues["AccountDate"];
			SetBodyForContact(contactName, contactDate);
			SetBodyForAccount(accountName, accountDate);
		}

		private string GetTitle(string contactName) {
			return string.IsNullOrWhiteSpace(contactName) ? _titleAccount : _titleContact;
		}

		private void AddGeneralGroupBy(Select select) {
			select.GroupBy("Reminding", "SubjectId")
				.GroupBy("SysSchema", "Name")
				.GroupBy("SysAdminUnit", "Id")
				.GroupBy("NotificationsSettings", "SysImageId");
		}

		private Select GetContactSelect() {
			Select select = base.GetBaseSelect();
			select
				.Column("Contact", "Name").As("ContactName")
				.Column("Contact", "BirthDate").As("ContactDate")
				.Column(Column.Parameter(string.Empty)).As("AccountName")
				.Column(Column.Parameter(DateTime.Now)).As("AccountDate");
			AddGeneralColumns(select);
			JoinGeneralTables(select);
			select.InnerJoin("Contact").On("Reminding", "SubjectId").IsEqual("Contact", "Id");
			AddGeneralConditions(select);
			AddGeneralGroupBy(select);
			select
				.GroupBy("Contact", "Name")
				.GroupBy("Contact", "BirthDate");
			return select;
		}

		private Select GetAccountSelect() {
			Select select = base.GetBaseSelect();
			select
				.Column(Column.Parameter(string.Empty)).As("ContactName")
				.Column(Column.Parameter(DateTime.Now)).As("ContactDate")
				.Column("Account", "Name").As("AccountName")
				.Column("AccountAnniversary", "Date").As("AccountDate");
			AddGeneralColumns(select);
			JoinGeneralTables(select);
			select
				.InnerJoin("Account").On("Reminding", "SubjectId").IsEqual("Account", "Id")
				.InnerJoin("AccountAnniversary").On("Reminding", "SubjectId").IsEqual("Account", "Id");
			AddGeneralConditions(select);
			AddGeneralGroupBy(select);
			select
				.GroupBy("Account", "Name")
				.GroupBy("AccountAnniversary", "Date");
			return select;
		}

		private void AddGeneralColumns(Select select) {
			var integerDataValueType = new IntegerDataValueType(new DataValueTypeManager()) {
				Name = "Integer"
			};
			select
				.Column("Reminding", "SubjectId").As("Id")
				.Column(Func.Max("Reminding", "RemindTime")).As("RemindTime")
				.Column("Reminding", "SubjectId").As("EntityId")
				.Column("SysSchema", "Name").As("EntitySchemaName")
				.Column("NotificationsSettings", "SysImageId").As("ImageId")
				.Column("SysAdminUnit", "Id").As("SysAdminUnitId")
				.Column(Func.Max(Func.Cast("IsRead", integerDataValueType))).As("IsRead");
		}

		private void JoinGeneralTables(Select select) {
			select
				.InnerJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
				.InnerJoin("SysSchema").On("Reminding", "SysEntitySchemaId").IsEqual("SysSchema", "UId")
				.InnerJoin("NotificationsSettings").On("Reminding", "SysEntitySchemaId").IsEqual("NotificationsSettings", "SysEntitySchemaUId");
		}

		private void AddGeneralConditions(Select select) {
			base.AddConditions(select);
			var integerDataValueType = new IntegerDataValueType(new DataValueTypeManager()) {
				Name = "Integer"
			};
			Select activeSysAdminUnitSelect = GetActiveSysAdminUnitSelect();
			select
				.And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true))
				.And("SysAdminUnit", "LoggedIn").IsEqual(Column.Parameter(true))
				.And("Reminding", "NotificationTypeId").IsEqual(Column.Parameter(RemindingConsts.NotificationTypeAnniversaryId))
				.And().Exists(activeSysAdminUnitSelect)
			.Having(Func.Max(Func.Cast("IsRead", integerDataValueType))).IsEqual(Column.Parameter(0));
		}


		#endregion

		#region Methods: Protected

		protected override void AddColumns(Select select) {
		}

		protected override void JoinTables(Select select) {
		}

		protected override void AddConditions(Select select) {
		}

		protected override void AddActiveUserFilter(Select select) {
		}

		protected override INotificationInfo GetRecordNotificationInfo(Dictionary<string, string> dictionaryColumnValues) {
			string title = GetTitle(dictionaryColumnValues["ContactName"]);
			SetBody(dictionaryColumnValues);
			Guid imageId;
			Guid.TryParse(dictionaryColumnValues["ImageId"], out imageId);
			return new NotificationInfo() {
				Title = title,
				Body = _body,
				ImageId = imageId,
				EntityId = new Guid(dictionaryColumnValues["EntityId"]),
				EntitySchemaName = dictionaryColumnValues["EntitySchemaName"],
				MessageId = new Guid(dictionaryColumnValues["EntityId"]),
				SysAdminUnit = new Guid(dictionaryColumnValues["SysAdminUnitId"]),
				GroupName = Group
			};
		}

		protected override Select GetBaseSelect() {
			var contactSelect = GetContactSelect();
			var accountSelect = GetAccountSelect();
			contactSelect.UnionAll(accountSelect);
			return contactSelect;
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
			columns.Add("RemindTime");
			columns.Add("EntityId");
			columns.Add("EntitySchemaName");
			columns.Add("ContactName");
			columns.Add("ContactDate");
			columns.Add("AccountName");
			columns.Add("AccountDate");
			columns.Add("ImageId");
		}

		public override string GetRecordResult(Dictionary<string, string> dictionaryColumnValues) {
			var remindTime = dictionaryColumnValues["RemindTime"];
			var entityId = dictionaryColumnValues["EntityId"];
			var entitySchemaName = dictionaryColumnValues["EntitySchemaName"];
			var imageId = dictionaryColumnValues["ImageId"];
			var id = entitySchemaName + entityId;
			string title = GetTitle(dictionaryColumnValues["ContactName"]);
			SetBody(dictionaryColumnValues);
			var popup = new PopupData() {
				Title = title,
				Body = _body,
				ImageId = imageId,
				EntityId = entityId,
				EntitySchemaName = entitySchemaName
			};
			var serialisedPopup = popup.Serialize();
			return string.Format(template, id, serialisedPopup);
		}

		public override Select GetEntitiesSelect() {
			var sysAdminUnitId = (Guid)this.parameters["sysAdminUnitId"];
			var notificationTypeName = NotificationProviderType.Anniversary.ToString();
			var date = DateTime.Now;
			var integerDataValueType = new IntegerDataValueType(new DataValueTypeManager()) {
				Name = "Integer"
			};
			var select =
				new Select(UserConnection)
					.Column("Reminding", "SubjectId").As("Id")
					.Column(Func.Max("Reminding", "RemindTime")).As("RemindTime")
					.Column("Reminding", "SubjectId").As("EntityId")
					.Column("SysSchema", "Name").As("EntitySchemaName")
					.Column("Contact", "Name").As("ContactName")
					.Column("Contact", "BirthDate").As("ContactDate")
					.Column("Account", "Name").As("AccountName")
					.Column("AccountAnniversary", "Date").As("AccountDate")
					.Column("NotificationsSettings", "SysImageId").As("ImageId")
					.Column(Func.Max(Func.Cast("IsRead", integerDataValueType))).As("IsRead")
					.Distinct()
				.From("Reminding")
					.LeftOuterJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
						.LeftOuterJoin("SysSchema").On("Reminding", "SysEntitySchemaId").IsEqual("SysSchema", "UId")
					.LeftOuterJoin("Contact").On("Reminding", "SubjectId").IsEqual("Contact", "Id")
						.LeftOuterJoin("Account").On("Reminding", "SubjectId").IsEqual("Account", "Id")
					.LeftOuterJoin("NotificationType").On("Reminding", "NotificationTypeId").IsEqual("NotificationType", "Id")
						.LeftOuterJoin("AccountAnniversary").On("Account", "Id").IsEqual("AccountAnniversary", "AccountId")
					.LeftOuterJoin("NotificationsSettings").On("Reminding", "SysEntitySchemaId").IsEqual("NotificationsSettings", "SysEntitySchemaUId")
				.Where("RemindTime").IsLessOrEqual(Column.Parameter(date.ToUniversalTime()))
					.And("SysAdminUnit", "Id").IsEqual(Column.Parameter(sysAdminUnitId))
					.And("NotificationType", "Name").IsEqual(Column.Parameter(notificationTypeName))
				.Having(Func.Max(Func.Cast("IsRead", integerDataValueType))).IsEqual(Column.Parameter(0))
				.GroupBy("Reminding", "SubjectId")
				.GroupBy("SysSchema", "Name")
				.GroupBy("Contact", "Name")
				.GroupBy("Contact", "BirthDate")
				.GroupBy("Account", "Name")
				.GroupBy("AccountAnniversary", "Date")
				.GroupBy("NotificationsSettings", "SysImageId") as Select;
			return select;
		}

		#endregion
	}

	#endregion
}

