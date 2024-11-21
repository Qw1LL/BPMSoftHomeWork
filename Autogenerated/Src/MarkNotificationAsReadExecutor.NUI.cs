namespace BPMSoft.Configuration.Notifications
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: MarkNotificationAsReadExecutor

	[DefaultBinding(typeof(IMarkNotificationAsReadExecutor), Name = "MarkNotificationAsReadExecutor")]
	public class MarkNotificationAsReadExecutor : IMarkNotificationAsReadExecutor
	{

		#region Constants: Private

		private const int MaxAllowedChunkSize = 1000;
		private const string IsReadColumnNameName = "IsRead";
		private const string RemindingTableName = "Reminding";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private int _notificationSelectChunkSize;

		#endregion

		#region Constructors: Public

		public MarkNotificationAsReadExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private int NotificationSelectChunkSize {
			get {
				if (_notificationSelectChunkSize > 0)
					return _notificationSelectChunkSize;
				InitNotificationSelectChunkSize();
				return _notificationSelectChunkSize;
			}
		}

		#endregion

		#region Methods: Private

		private IEnumerable<Guid> GetNotificationsToMark(Guid notificationTypeId, DateTime remindTime) {
			var notificationIdsQuery = new Select(_userConnection).Top(NotificationSelectChunkSize).Column("Id")
				.From(RemindingTableName).Where("ContactId")
				.IsEqual(Column.Parameter(_userConnection.CurrentUser.ContactId)).And("NotificationTypeId")
				.IsEqual(Column.Parameter(notificationTypeId)).And("RemindTime")
				.IsLessOrEqual(Column.Parameter(remindTime)).And(IsReadColumnNameName)
				.IsEqual(Column.Parameter(false)) as Select;
			var notificationIds = notificationIdsQuery.ExecuteEnumerable(reader => reader.GetColumnValue<Guid>("Id"))
				.ToList();
			return notificationIds;
		}

		private void InitNotificationSelectChunkSize() {
			if (!CoreSysSettings.TryGetValue(_userConnection, "UpdateNotificationStatusChunkSize",
				out object sysSettingsValue)) {
				_notificationSelectChunkSize = MaxAllowedChunkSize;
				return;
			}
			var sysSettingsChunkSize = Convert.ToInt32(sysSettingsValue);
			_notificationSelectChunkSize = sysSettingsChunkSize <= 0 || sysSettingsChunkSize > MaxAllowedChunkSize
				? MaxAllowedChunkSize
				: sysSettingsChunkSize;
		}

		private void MarkAsRead(IEnumerable<Guid> notificationIds) {
			new Update(_userConnection, RemindingTableName).Set(IsReadColumnNameName, Column.Parameter(true))
				.Where("Id").In(Column.Parameters(notificationIds)).Execute();
		}

		#endregion

		#region Methods: Public

		public void Execute(Guid notificationTypeId, DateTime remindTime) {
			notificationTypeId.CheckArgumentEmpty(nameof(notificationTypeId));
			remindTime.CheckArgumentNull(nameof(remindTime));
			IEnumerable<Guid> notificationIds;
			while ((notificationIds = GetNotificationsToMark(notificationTypeId, remindTime)).Any())
				MarkAsRead(notificationIds);
		}

		#endregion

	}

	#endregion

}

