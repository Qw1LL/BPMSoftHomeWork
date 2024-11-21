namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Scheduler;

	#region Class: NotificationCleanerJob

	/// <summary>
	/// Class for notification cleaning.
	/// </summary>
	public class NotificationCleanerJob : IJobExecutor
	{
		#region Fields: Private

		private DateTime _minDate;
		private UserConnection _userConnection;
		private const int DefaultMaxAgeInDays = 30;

		#endregion

		#region Methods: Private

		private void DeleteRemindings() {
			var deleteQuery = new Delete(_userConnection)
				.From("Reminding") as Delete;
			AddFilters(deleteQuery);
			deleteQuery.Execute();
		}

		private void DeleteEsnRemindings() {
			var deleteQuery = new Delete(_userConnection)
				.From("ESNNotification") as Delete;
			AddEsnFilters(deleteQuery);
			deleteQuery.Execute();
		}

		private void DeleteAnniversaryRemindings() {
			var deleteQuery = new Delete(_userConnection)
				.From("Reminding") as Delete;
			AddAnnivFilters(deleteQuery);
			deleteQuery.Execute();
		}
		
		private void DeleteRemindingForFinishedActivity() {
			var finishedActivityExistsSelectQuery = GetFinishedActivityExistsSelectQuery();
			var deleteQuery = new Delete(_userConnection)
				.From("Reminding")
				.Where("NotificationTypeId").IsEqual(Column.Parameter(RemindingConsts.NotificationTypeRemindingId))
				.And()
				.Exists(finishedActivityExistsSelectQuery);
			deleteQuery.Execute();
		}

		private void DeleteAllRemindings() {
			int maxAgeInDays = Core.Configuration.SysSettings.GetValue<int>(_userConnection,
				"NotificationsExpirationTerm", DefaultMaxAgeInDays);
			_minDate = DateTime.Now.AddDays(-maxAgeInDays);
			DeleteRemindings();
			DeleteEsnRemindings();
			DeleteAnniversaryRemindings();
			DeleteRemindingForFinishedActivity();
		}

		private void AddRemindingFilters(Delete deleteQuery, Guid notificationTypeId) {
			deleteQuery
				.Where("Reminding", "RemindTime")
					.IsLess(Column.Parameter(_minDate))
				.And("Reminding", "NotificationTypeId")
					.IsEqual(Column.Parameter(notificationTypeId));
		}

		private Select GetFinishedActivityExistsSelectQuery() {
			return (Select)new Select(_userConnection)
				.Column(Column.Const(null)).As("NullAlias")
				.From("Activity").InnerJoin("ActivityStatus").On("ActivityStatus", "Id").IsEqual("Activity", "StatusId")
				.Where("ActivityStatus", "Finish").IsEqual(Column.Parameter(true))
				.And("Activity", "Id").IsEqual("Reminding", "SubjectId");
		}
		
		#endregion

		#region Methods: Protected

		/// <summary>
		/// Sets request filters.
		/// </summary>
		/// <param name="deleteQuery">Delete query.</param>
		protected virtual void AddFilters(Delete deleteQuery) {
			AddRemindingFilters(deleteQuery, RemindingConsts.NotificationTypeNotificationId);
			deleteQuery.And("Reminding", "IsRead").IsEqual(Column.Parameter(true));
		}

		/// <summary>
		/// Sets anniversary request filters.
		/// </summary>
		/// <param name="deleteQuery">Delete query.</param>
		protected virtual void AddAnnivFilters(Delete deleteQuery) {
			AddRemindingFilters(deleteQuery, RemindingConsts.NotificationTypeAnniversaryId);
		}

		/// <summary>
		/// Sets ESN request filters.
		/// </summary>
		/// <param name="deleteQuery">Delete query.</param>
		protected virtual void AddEsnFilters(Delete deleteQuery) {
			deleteQuery
				.Where("ESNNotification", "CreatedOn")
					.IsLess(Column.Parameter(_minDate))
				.And("ESNNotification", "IsRead")
					.IsEqual(Column.Parameter(true));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes cleaning job.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			DeleteAllRemindings();
		}

		#endregion
	}

	#endregion
}

