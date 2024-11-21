namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Scheduler;
	using SysSettingsCore = BPMSoft.Core.Configuration.SysSettings;

	#region Class: BulkEmailFailoverHandler

	/// <summary>
	/// Provides methods to get broken bulk emails and cleanup its status.
	/// </summary>
	public class BulkEmailFailoverHandler : IFailoverHandler
	{

		#region Constants: Private

		private const string UpdateLogPattern = "Id: {0}, StatusId: {1}, SendStartDate: {2}";

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the bulk email queue job dispatcher.
		/// Instance of <see cref="BulkEmailQueueJobDispatcher"/>.
		/// </summary>
		private BulkEmailQueueJobDispatcher _bulkEmailQueueJobDispatcher;
		public BulkEmailQueueJobDispatcher BulkEmailQueueJobDispatcher {
			get => _bulkEmailQueueJobDispatcher
				?? (_bulkEmailQueueJobDispatcher = new BulkEmailQueueJobDispatcher {
					UserConnection = _userConnection.AppConnection.SystemUserConnection
				});
			set => _bulkEmailQueueJobDispatcher = value;
		}

		/// <summary>
		/// Gets or sets the triggered email queue job dispatcher.
		/// Instance of <see cref="TriggerEmailQueueJobDispatcher"/>.
		/// </summary>
		private TriggerEmailQueueJobDispatcher _triggerEmailQueueJobDispatcher;
		public TriggerEmailQueueJobDispatcher TriggerEmailQueueJobDispatcher {
			get => _triggerEmailQueueJobDispatcher
				?? (_triggerEmailQueueJobDispatcher = new TriggerEmailQueueJobDispatcher {
					UserConnection = _userConnection.AppConnection.SystemUserConnection
				});
			set => _triggerEmailQueueJobDispatcher = value;
		}

		#endregion

		#region Methods: Private

		private Select CreateBulkEmailsSelect(UserConnection userConnection, int timeout) {
			var endCheckTime = DateTime.UtcNow.AddMinutes(-timeout);
			var startCheckTime = endCheckTime.AddHours(-6);
			var select = new Select(userConnection)
				.Column("BulkEmail", "Id")
				.Column("BulkEmail", "CategoryId")
				.Column("BulkEmail", "SendStartDate")
				.Column("BulkEmail", "StatusId")
				.Column("BulkEmail", "LaunchOptionId")
				.From("BulkEmail")
				.InnerJoin("SendingEmailProgress").On("SendingEmailProgress", "BulkEmailId").IsEqual("BulkEmail", "Id")
				.LeftOuterJoin("Campaign").On("Campaign", "Id").IsEqual("BulkEmail", "CampaignId")
				.Where("BulkEmail", "StatusId").In(Column.Parameters(MarketingConsts.BulkEmailStatusStartsId, MarketingConsts.BulkEmailStatusWaitingBeforeSendId,
					MarketingConsts.BulkEmailStatusLaunchedId, MarketingConsts.BulkEmailStatusBreakingId, MailingConsts.BulkEmailStatusExpiredInProgressId))
				.And("Campaign", "CampaignSchemaUId").IsNull()
				.And("SendingEmailProgress", "ModifiedOn").IsLess(Column.Parameter(endCheckTime))
				.And("SendingEmailProgress", "ModifiedOn").IsGreater(Column.Parameter(startCheckTime)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the broken bulk emails list.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <returns>List of <see cref="BulkEmail"/>.</returns>
		public virtual List<BulkEmail> GetBrokenBulkEmails(UserConnection userConnection) {
			var sendingInProgressTimeOut = (int)SysSettingsCore.GetValue(userConnection, "SendingInProgressTimeoutPeriod");
			Select bulkEmailSelect = CreateBulkEmailsSelect(userConnection, sendingInProgressTimeOut);
			var resultList = new List<BulkEmail>();
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dr = bulkEmailSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						var sendStartDate = (DateTime)dr["SendStartDate"];
						Guid statusId = userConnection.DBTypeConverter.DBValueToGuid(dr["StatusId"]);
						Guid launchOptionId = userConnection.DBTypeConverter.DBValueToGuid(dr["LaunchOptionId"]);
						var bulkEmail = new BulkEmail(userConnection) {
							Id = userConnection.DBTypeConverter.DBValueToGuid(dr["Id"]),
							CategoryId = userConnection.DBTypeConverter.DBValueToGuid(dr["CategoryId"]),
							SendStartDate = sendStartDate,
							StatusId = statusId,
							LaunchOptionId = launchOptionId
						};
						resultList.Add(bulkEmail);
					}
				}
			}
			return resultList;
		}

		/// <summary>
		/// Cleans up status of bulk emails.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="bulkEmails">The bulk emails list.</param>
		public virtual void CleanUpStatus(UserConnection userConnection, IEnumerable<BulkEmail> bulkEmails) {
			foreach (BulkEmail bulkEmail in bulkEmails) {
				Guid bulkEmailStatusId = bulkEmail.CategoryId == MarketingConsts.MassmailingBulkEmailCategoryId
					? MarketingConsts.BulkEmailStatusStartPlanedId
					: MarketingConsts.BulkEmailStatusActiveId;
				try {
					var update = new Update(userConnection, "BulkEmail")
						.Set("StatusId", Column.Parameter(bulkEmailStatusId))
						.Where("Id").IsEqual(Column.Parameter(bulkEmail.Id))
						.And("StatusId").IsEqual(Column.Parameter(bulkEmail.StatusId)) as Update;
					if (bulkEmail.LaunchOptionId == MarketingConsts.BulkEmailManaulLaunchOptionId) {
						update
							.Set("LaunchOptionId", Column.Parameter(MarketingConsts.BulkEmailScheduledaunchOptionId))
							.Set("StartDate", Column.Parameter(DateTime.UtcNow));
					}
					update.WithHints(new RowLockHint());
					var affectedRecords = update.Execute();
					if (affectedRecords > 0) {
						MailingUtilities.Log.InfoFormat("[EmailFailoverHandler.CleanUpStatus]: Email status updated. " +
							UpdateLogPattern, bulkEmail.Id, bulkEmailStatusId, bulkEmail.SendStartDate);
					}
				} catch (Exception e) {
					MailingUtilities.Log.ErrorFormat("[EmailFailoverHandler.CleanUpStatus]: Unable to set status. " +
						UpdateLogPattern, e, bulkEmail.Id, bulkEmailStatusId, bulkEmail.SendStartDate);
				}
			}
		}

		/// <summary>
		/// Processes the bulk emails to find out and reset broken ones.
		/// <param name="userConnection">The user connection.</param>
		/// <param name="parameters">Job parameters.</param>
		/// </summary>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			IEnumerable<BulkEmail> emails = GetBrokenBulkEmails(userConnection);
			CleanUpStatus(userConnection, emails);
			BulkEmailQueueJobDispatcher.TryRescheduleJob();
			TriggerEmailQueueJobDispatcher.TryRescheduleJob();
		}

		/// <summary>
		/// Creates job to monitor fails.
		/// <param name="userConnection">The user connection.</param>
		/// </summary>
		public void CreateJob(UserConnection userConnection) {
			SysUserInfo currentUser = userConnection.CurrentUser;
			int periodInMinutes = (int)SysSettingsCore.GetValue(userConnection, "BulkEmailFailoverJobInterval");
			string jobGroupName = "Mailing";
			bool isSystemUser = true;
			var misfirePolicy = AppSchedulerMisfireInstruction.RescheduleNowWithRemainingRepeatCount;
			AppScheduler.ScheduleMinutelyJob<BulkEmailFailoverHandler>(jobGroupName, userConnection.Workspace.Name,
				currentUser.Name, periodInMinutes, null, isSystemUser, misfirePolicy);
		}

		#endregion

	}

	#endregion

}
