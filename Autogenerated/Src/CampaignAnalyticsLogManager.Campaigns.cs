namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: CampaignAnalyticsLogManager


	/// <summary>
	/// Contains logic for analytics gathering from campaign log.
	/// </summary>
	public class CampaignAnalyticsLogManager {

		#region Constructors: Public

		/// <summary>
		/// Constructor which defines user connection.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="BPMSoft.Core.UserConnection"/></param>
		public CampaignAnalyticsLogManager(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Private

		private KeyValuePair<Guid, DateTime> GetFirstRecordInLog(DateTime tillDate) {
			var startDateSelect = new Select(UserConnection).Top(1)
					.Column("CampaignId")
					.Column("CreatedOn")
					.From("CampaignLog")
					.Where("CreatedOn").IsLess(Column.Parameter(tillDate))
					.OrderByAsc("CreatedOn") as Select;
			startDateSelect.SpecifyNoLockHints();
			var result = startDateSelect.ExecuteEnumerable(r => {
				var key = r.GetColumnValue<Guid>("CampaignId");
				var value = r.GetColumnValue<DateTime>("CreatedOn");
				return new KeyValuePair<Guid, DateTime>(key, value);
			});
			return result.FirstOrDefault();
		}

		private Select GetCampaignLogSelect(DateTime dueDate, Guid campaignId) {
			var date = dueDate.AddDays(-1);
			var select = new Select(UserConnection)
				.Column("cl", "CampaignId")
				.Column("cl", "CampaignItemId")
				.Column(Func.Sum("cl", "Amount")).As("Amount")
				.Column(Column.Parameter(date)).As("Date")
				.From("CampaignLog").As("cl")
				.InnerJoin("CampaignItem").As("ci").On("ci", "Id").IsEqual("cl", "CampaignItemId")
				.Where("ci", "CampaignElementType").Not().IsLike(Column.Parameter("Transition%"))
				.And("cl", "ActionId").IsNotEqual(Column.Parameter(CampaignConsts.CampaignLogTypeMoveAudience))
				.And("cl", "CreatedOn").IsLess(Column.Parameter(dueDate)) as Select;
			if (campaignId != Guid.Empty) {
				select.And("cl", "CampaignId").IsEqual(Column.Parameter(campaignId));
			}
			select.And().OpenBlock()
				.OpenBlock("cl", "ActionId").IsNotEqual(Column.Parameter(CampaignConsts.CampaignLogTypeUpdateObject))
				.And("cl", "ActionId").IsNotEqual(Column.Parameter(CampaignConsts.CampaignLogTypeAddObject))
				.CloseBlock()
				.Or("cl", "SessionId").Not().IsNull()
				.CloseBlock();
			select.GroupBy("cl", "CampaignId")
				.GroupBy("cl", "CampaignItemId")
				.Having(Func.Sum("cl", "Amount")).IsGreater(Column.Parameter(0));
			select.SpecifyNoLockHints();
			return select;
		}

		private void InsertFromCampaignLog(DateTime dueDate, Guid campaignId) {
			var select = GetCampaignLogSelect(dueDate, campaignId);
			var insertSelect = new InsertSelect(UserConnection)
				.Into("CampaignAnalyticsLog")
				.Set("CampaignId", "CampaignItemId", "Amount", "Date")
				.FromSelect(select);
			insertSelect.Execute();
		}

		private void DeleteFromCampaignLog(DateTime dueDate, Guid campaignId) {
			var delete = new Delete(UserConnection)
				.From("CampaignLog")
				.Where("CreatedOn").IsLess(Column.Parameter(dueDate)) as Delete;
			if (campaignId != Guid.Empty) {
				delete.And("CampaignId").IsEqual(Column.Parameter(campaignId));
			}
			delete.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gathers campaign participant analytics to log and clears campaign execution log.
		/// </summary>
		/// <param name="tillDate">Date limit for gathering analytics.</param>
		public virtual void MoveRecordsToAnalyticsLog(DateTime tillDate) {
			tillDate = new DateTime(tillDate.Year, tillDate.Month, tillDate.Day, 0, 0, 0, 0, tillDate.Kind);
			var logRecord = GetFirstRecordInLog(tillDate);
			while (logRecord.Key != Guid.Empty) {
				var campaignId = logRecord.Key;
				var dueDate = logRecord.Value.AddDays(1);
				dueDate = new DateTime(dueDate.Year, dueDate.Month, dueDate.Day, 0, 0, 0, 0, dueDate.Kind);
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
					dbExecutor.StartTransaction(IsolationLevel.ReadCommitted);
					try {
						InsertFromCampaignLog(dueDate, campaignId);
						DeleteFromCampaignLog(dueDate, campaignId);
						dbExecutor.CommitTransaction();
					} catch {
						dbExecutor.RollbackTransaction();
						throw;
					}
				}
				logRecord = GetFirstRecordInLog(tillDate);
			}
		}

		#endregion

	}

	#endregion

}

