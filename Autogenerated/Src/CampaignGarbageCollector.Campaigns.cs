namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Scheduler;
	using CoreSysSettings = Core.Configuration.SysSettings;
	using CoreCampaignConsts = Core.Campaign.CampaignConstants;
	using System.Threading;
	using global::Common.Logging;

	#region Class: CampaignGarbageCollector

	/// <summary>
	/// Provides methods to collect and remove unlinked entities etc.
	/// </summary>
	public class CampaignGarbageCollector : IFailoverHandler
	{

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Properties: Protected

		private ILog _logger;
		protected ILog CampaignLogger {
			get {
				return _logger ?? (_logger = LogManager.GetLogger(CoreCampaignConsts.CampaignLoggerName));
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Job interval, in minutes.
		/// Default = 1440 (1 day).
		/// </summary>
		public int CampaignGCInterval { get; set; } = 1440;

		/// <summary>
		/// Query batch size.
		/// Default = 500.
		/// </summary>
		public int CampaignGCBatchSize { get; set; } = 500;

		/// <summary>
		/// Gets or sets the campaign job dispatcher. Instance of <see cref="CampaignJobDispatcher"/>.
		/// </summary>
		private ICampaignJobDispatcher _campaignJobDispatcher;
		public ICampaignJobDispatcher CampaignJobDispatcher {
			get => _campaignJobDispatcher ?? (_campaignJobDispatcher = new CampaignJobDispatcher(_userConnection));
			set => _campaignJobDispatcher = value;
		}

		/// <summary>
		/// Gets or sets the campaign analytics log manager. Instance of <see cref="CampaignAnalyticsLogManager"/>.
		/// </summary>
		private CampaignAnalyticsLogManager _campaignAnalyticsLogManager;
		public CampaignAnalyticsLogManager CampaignAnalyticsLogManager {
			get => _campaignAnalyticsLogManager ?? (_campaignAnalyticsLogManager =
				new CampaignAnalyticsLogManager(_userConnection));
			set => _campaignAnalyticsLogManager = value;
		}

		#endregion

		#region Methods: Private

		private void MoveRecordsToAnalyticsLog(UserConnection userConnection) {
			try {
				var lifetime = (int)CoreSysSettings.GetValue(userConnection, "CampaignLogRecordLifeTime");
				if (lifetime <= 0) {
					return;
				}
				var tillDate = DateTime.Now.AddDays(-lifetime);
				CampaignAnalyticsLogManager.MoveRecordsToAnalyticsLog(tillDate);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat("Exception has occured when records from execution log were removing.", ex);
			}
		}

		private List<Guid> GetSuspendedParticipantInfo(UserConnection userConnection, int lifetime) {
			var selectQuery = new Select(userConnection)
				.Column("cpi", "Id").As("Id")
				.From("CampaignParticipantInfo").As("cpi")
				.InnerJoin("CampaignParticipant").As("cp").On("cp", "Id").IsEqual("cpi", "CampaignParticipantId")
				.Where("cp", "StatusId")
				.IsEqual(Column.Parameter(CoreCampaignConsts.CampaignParticipantSuspendedStatusId))
				.And("cpi", "CreatedOn")
				.IsLess(Column.Parameter(DateTime.UtcNow.AddDays(-lifetime))) as Select;
			selectQuery.SpecifyNoLockHints();
			var result = selectQuery.ExecuteEnumerable(x => x.GetColumnValue<Guid>("Id"));
			return result.ToList();
		}

		private void DeleteSuspendedParticipantInfo(UserConnection userConnection) {
			try {
				var lifetime = (int)CoreSysSettings.GetValue(userConnection, "CampaignGarbageLifeTime");
				if (lifetime <= 0) {
					return;
				}
				var participantInfoToDelete = GetSuspendedParticipantInfo(userConnection, lifetime);
				int processedCount = 0;
				var totalCount = participantInfoToDelete.Count;
				while (processedCount < totalCount) {
					var batch = participantInfoToDelete.GetRange(processedCount,
						Math.Min(CampaignGCBatchSize, totalCount - processedCount));
					if (batch.Count == 0) {
						break;
					}
					var delete = new Delete(userConnection)
						.From("CampaignParticipantInfo")
						.Where("Id").In(Column.Parameters(batch)) as Delete;
					delete.Execute();
					processedCount += CampaignGCBatchSize;
					Thread.Sleep(10);
				}
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat("Exception has occured when records of suspended participants "
					+ "info were removing.", ex);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates job to collect campaign's garbage.
		/// <param name="userConnection">The user connection.</param>
		/// </summary>
		public void CreateJob(UserConnection userConnection) {
			_userConnection = userConnection;
			var currentUser = userConnection.CurrentUser;
			var lifetime = (int)CoreSysSettings.GetValue(_userConnection, "CampaignGarbageLifeTime");
			if (lifetime <= 0) {
				return;
			}
			var isSystemUser = true;
			var scheduler = CampaignJobDispatcher.CampaignScheduler;
			var misfirePolicy = AppSchedulerMisfireInstruction.RescheduleNowWithRemainingRepeatCount;
			AppScheduler.ScheduleMinutelyJob<CampaignGarbageCollector>(CampaignConsts.CampaignJobGroupName,
				_userConnection.Workspace.Name, currentUser.Name, CampaignGCInterval, null,
				isSystemUser, misfirePolicy, scheduler);
		}

		/// <summary>
		/// Collect campaign's garbage.
		/// <param name="userConnection">The user connection.</param>
		/// <param name="parameters">Job parameters.</param>
		/// </summary>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			DeleteSuspendedParticipantInfo(userConnection);
			MoveRecordsToAnalyticsLog(userConnection);
		}

		#endregion

	}

	#endregion

}
