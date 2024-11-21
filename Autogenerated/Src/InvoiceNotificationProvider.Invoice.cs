namespace BPMSoft.Configuration
{
	using BPMSoft.Core.DB;
	using BPMSoft.Core;
	using System;
	using System.Linq;
	using System.Collections.Generic;

	#region Class: InvoiceNotificationProvider

	[Obsolete("Will be removed in 7.12.2")]
	public class InvoiceNotificationProvider : BaseNotificationProvider, INotification
	{
		#region Fields: Private

		private const string GROUP_NAME = "Reminding";
		private const string NAME = "Invoice";

		#endregion

		#region Constructors: Public

		public InvoiceNotificationProvider(Dictionary<string, object> parameters) 
			: base(parameters) {
		}

		public InvoiceNotificationProvider(UserConnection userConnection)
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

		private string GetDate(string datetime) {
			var dateMacros = UserConnection.GetLocalizableString("InvoiceNotificationProvider" ,"DateMacros");
			var result = Convert.ToDateTime(datetime);
			return result.ToString(dateMacros);
		}

		private string GetBody(Dictionary<string, string> dictionaryColumnValues) {
			var bodyTemplate = UserConnection.GetLocalizableString("InvoiceNotificationProvider", "BodyTemplate");
			var number = dictionaryColumnValues["Number"];
			var startDate = dictionaryColumnValues["StartDate"];
			var contactName = dictionaryColumnValues["ContactName"];
			var accountName = dictionaryColumnValues["AccountName"];
			var date = GetDate(startDate);
			var body = string.Format(bodyTemplate, number, date);
			var customer = (new List<string>() { accountName, contactName })
				.Where(item => !string.IsNullOrWhiteSpace(item));
			body += string.Join(", ", customer);
			return body;
		}

		#endregion

		#region Methods: Protected

		protected override void AddColumns(Select select) {
			select
				.Column("Reminding", "Id").As("Id")
				.Column("Reminding", "RemindTime").As("RemindTime")
				.Column("Reminding", "Description").As("Description")
				.Column("Invoice", "Id").As("InvoiceId")
				.Column("Invoice", "Number").As("Number")
				.Column("Invoice", "StartDate").As("StartDate")
				.Column("Contact", "Name").As("ContactName")
				.Column("Account", "Name").As("AccountName");
		}

		protected override void JoinTables(Select select) {
			select
				.InnerJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
				.InnerJoin("Invoice").On("Reminding", "SubjectId").IsEqual("Invoice", "Id")
				.LeftOuterJoin("Contact").On("Invoice", "ContactId").IsEqual("Contact", "Id")
				.LeftOuterJoin("Account").On("Invoice", "AccountId").IsEqual("Account", "Id");
		}

		protected override void AddConditions(Select select) {
			base.AddConditions(select);
			select
				.And("Reminding", "NotificationTypeId")
					.IsEqual(Column.Parameter(RemindingConsts.NotificationTypeRemindingId))
				.And("Invoice", "PaymentStatusId").Not().In(
					new Select(UserConnection).Column("InvoicePaymentStatus", "Id").From("InvoicePaymentStatus")
						.Where("InvoicePaymentStatus", "FinalStatus").IsEqual(Column.Parameter(true))
				);
		}

		protected override INotificationInfo GetRecordNotificationInfo(Dictionary<string, string> dictionaryColumnValues) {
			string body = GetBody(dictionaryColumnValues);
			Guid imageId = NotificationUtilities.GetSysImageBySchemaName(UserConnection, "Invoice");
			string titleTemplate = UserConnection.GetLocalizableString("InvoiceNotificationProvider", "TitleTemplate");
			return new NotificationInfo() {
				Title = titleTemplate,
				Body = body,
				ImageId = imageId,
				EntityId = new Guid(dictionaryColumnValues["InvoiceId"]),
				EntitySchemaName = "Invoice",
				MessageId = new Guid(dictionaryColumnValues["Id"]),
				SysAdminUnit = new Guid(dictionaryColumnValues["SysAdminUnitId"]),
				GroupName = Group
			};
		}

		#endregion

		#region Methods: Public

		public override void SetColumns(List<string> columns) {
			columns.Add("Id");
			columns.Add("InvoiceId");
			columns.Add("Number");
			columns.Add("RemindTime");
			columns.Add("StartDate");
			columns.Add("ContactName");
			columns.Add("AccountName");
			columns.Add("ImageId");
		}

		public override string GetRecordResult(Dictionary<string, string> dictionaryColumnValues) {
			var titleTemplate = UserConnection.GetLocalizableString("InvoiceNotificationProvider", "TitleTemplate");
			var id = dictionaryColumnValues["Id"];
			var invoiceId = dictionaryColumnValues["InvoiceId"];
			var remindTime = dictionaryColumnValues["RemindTime"];
			var imageId = dictionaryColumnValues["ImageId"];
			var body = GetBody(dictionaryColumnValues);
			var key = id + "_" + remindTime;
			var popup = new PopupData() {
				Title = titleTemplate,
				Body = body, 
				ImageId = imageId, 
				EntityId = invoiceId,
				EntitySchemaName = "Invoice"
			}; 
			var serializePopup = popup.Serialize();
			return string.Format(template, key, serializePopup);
		}

		public override Select GetEntitiesSelect() {
			Guid sysAdminUnitId = (Guid)this.parameters["sysAdminUnitId"];
			DateTime date = (DateTime)this.parameters["dueDate"];
			var select = new Select(UserConnection)
				.Column("Reminding", "Id").As("Id")
				.Column("Reminding", "RemindTime").As("RemindTime")
				.Column("Invoice", "Id").As("InvoiceId")
				.Column("Invoice", "Number").As("Number")
				.Column("Invoice", "StartDate").As("StartDate")
				.Column("Contact", "Name").As("ContactName")
				.Column("Account", "Name").As("AccountName")
				.Column("NotificationsSettings", "SysImageId").As("ImageId")
				.Distinct()
				.From("Reminding")
				.LeftOuterJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
				.InnerJoin("Invoice").On("Reminding", "SubjectId").IsEqual("Invoice", "Id")
				.LeftOuterJoin("Contact").On("Invoice", "ContactId").IsEqual("Contact", "Id")
				.LeftOuterJoin("Account").On("Invoice", "AccountId").IsEqual("Account", "Id")
				.LeftOuterJoin("NotificationsSettings")
					.On("Reminding", "SysEntitySchemaId").IsEqual("NotificationsSettings", "SysEntitySchemaUId")
				.Where("RemindTime").IsLessOrEqual(Column.Parameter(date.ToUniversalTime()))
				.And("SysAdminUnit", "Id").IsEqual(Column.Parameter(sysAdminUnitId))
				.And("IsRead").IsEqual(Column.Parameter(false))
				.And("Invoice", "PaymentStatusId").Not().In(
					new Select(UserConnection).Column("InvoicePaymentStatus", "Id").From("InvoicePaymentStatus")
						.Where("InvoicePaymentStatus", "FinalStatus").IsEqual(Column.Parameter(true))
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
