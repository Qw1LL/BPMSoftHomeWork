namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Common;

	#region Class: RemindingRepository

	/// <summary>
	/// Provides a method for receiving reminders.
	/// </summary>
	public class RemindingRepository : IRemindingRepository
	{
		#region Constants: Private

		private const string RemindingTableName = "Reminding";
		private const int IntervalInMinutesForFindReminding = 5;

		#endregion
		
		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly INotificationSettingsRepository _notificationSettingsRepository;

		#endregion

		#region Constructors: Public

		public RemindingRepository(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
			_notificationSettingsRepository = ClassFactory.Get<NotificationSettingsRepository>(
				new ConstructorArgument("userConnection", _userConnection));
		}

		#endregion

		#region Methods: Private

		private int GetIntervalInMinutesForFindReminding() {
			var intervalInMinutes = GetIntervalInMinutesForFindRemindingSysSettingsValue();
			var notificatonJobInterval = GetNotificatonJobIntervalSysSettingsValue();
			return intervalInMinutes > notificatonJobInterval ? 
				intervalInMinutes : 
				notificatonJobInterval + intervalInMinutes;
		}

		private int GetIntervalInMinutesForFindRemindingSysSettingsValue() {
			return Core.Configuration.SysSettings
					.GetValue(_userConnection, "IntervalInMinutesForFindReminding", IntervalInMinutesForFindReminding);
		}
		
		private int GetNotificatonJobIntervalSysSettingsValue() {
			return Core.Configuration.SysSettings.GetValue(_userConnection, "NotificatonJobInterval", 1);
		}
		
		private Select GetRemindingSelect() {
			Select select = new Select(_userConnection);
			AddColumns(select);
			JoinTables(select);
			AddFilters(select);
			select.From(RemindingTableName);
			return select;
		}

		private IEnumerable<INotificationInfo> ExecuteSelect(Select select) {
			var result = new List<INotificationInfo>();
			select.ExecuteReader(reader => {
				result.Add(GetNotificationInfo(reader));
			});
			return result;
		}

		private string GetSchemaName(ISchemaManager manager, Guid itemUid) {
			var schemaName = string.Empty;
			var schema = manager.FindItemByUId(itemUid);
			if (schema != null) {
				schemaName = schema.Name;
			}
			return schemaName;
		}

		#endregion

		#region Methods: Protected

		protected virtual Guid GetSysImage(Guid entitySchemaUId) {
			return _notificationSettingsRepository.GetNotificationImage(entitySchemaUId, 
				RemindingConsts.NotificationTypeRemindingId);
		}
		
		protected virtual void AddColumns(Select select) {
			select
				.Column(RemindingTableName, "Id").As("Id")
				.Column(RemindingTableName, "ContactId").As("ContactId")
				.Column(RemindingTableName, "RemindTime").As("RemindTime")
				.Column(RemindingTableName, "PopupTitle").As("PopupTitle")
				.Column(RemindingTableName, "SubjectId").As("SubjectId")
				.Column(RemindingTableName, "SysEntitySchemaId").As("SysEntitySchemaId")
				.Column(RemindingTableName, "SubjectCaption").As("SubjectCaption")
				.Column(RemindingTableName, "LoaderId").As("LoaderId")
				.Column(RemindingTableName, "SenderId").As("SenderId")
				.Column("SysAdminUnit", "Id").As("SysAdminUnitId");
		}
		
		protected virtual void JoinTables(Select select) {
			select
				.InnerJoin("SysAdminUnit").On(RemindingTableName, "ContactId").IsEqual("SysAdminUnit", "ContactId");
		}
		
		protected virtual void AddFilters(Select select) {
			DateTime currentUniversalTime = DateTime.UtcNow;
			int intervalInMinutes = GetIntervalInMinutesForFindReminding();
			DateTime minUniversalTime = currentUniversalTime.AddMinutes(-intervalInMinutes);
			select.Where("RemindTime")
					.IsBetween(Column.Parameter(minUniversalTime)).And(Column.Parameter(currentUniversalTime))
				.And("NotificationTypeId").IsEqual(Column.Parameter(RemindingConsts.NotificationTypeRemindingId))
					.And("IsNeedToSend").IsEqual(Column.Const(true));
		}
		
		protected virtual INotificationInfo GetNotificationInfo(IDataReader dataReader) {
			var sysEntitySchemaUId = dataReader.GetColumnValue<Guid>("SysEntitySchemaId");
			var loaderUId = dataReader.GetColumnValue<Guid>("LoaderId");
			var entitySchemaName = GetSchemaName(_userConnection.EntitySchemaManager, sysEntitySchemaUId);
			var loaderSchemaName = GetSchemaName(_userConnection.ClientUnitSchemaManager, loaderUId);
			Guid imageId = GetSysImage(sysEntitySchemaUId);
			return new NotificationInfo {
				MessageId = dataReader.GetColumnValue<Guid>("Id"),
				Title = dataReader.GetColumnValue<string>("PopupTitle"),
				Body = dataReader.GetColumnValue<string>("SubjectCaption"),
				EntityId = dataReader.GetColumnValue<Guid>("SubjectId"),
				RemindTime = dataReader.GetColumnValue<DateTime>("RemindTime"),
				SysAdminUnit = dataReader.GetColumnValue<Guid>("SysAdminUnitId"),
				EntitySchemaName = entitySchemaName,
				LoaderName = loaderSchemaName,
				ImageId = imageId,
				GroupName = "Reminding"
			};
		}
		
		protected virtual void UpdateRemindingsIsSent(IEnumerable<Guid> remindingsId) {
			var update = new Update(_userConnection, RemindingTableName)
				.Set("IsNeedToSend", Column.Const(false))
				.Where(RemindingTableName, "Id").In(Column.Parameters(remindingsId));
			update.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns remindings.
		/// </summary>
		/// <returns>Collection of the remindings.</returns>
		public IEnumerable<INotificationInfo> GetRemindings() {
			Select select = GetRemindingSelect();
			IEnumerable<INotificationInfo> notificationInfos = ExecuteSelect(select);
			return notificationInfos;
		}

		/// <summary>
		/// Sets remindings is sent.
		/// </summary>
		/// <param name="remindingsId">Collection of the reminding identifier.</param>
		public void SetRemindingsIsSent(IEnumerable<Guid> remindingsId) {
			remindingsId.CheckArgumentNull(nameof(remindingsId));
			UpdateRemindingsIsSent(remindingsId);
		}

		#endregion
	}

	#endregion
}
