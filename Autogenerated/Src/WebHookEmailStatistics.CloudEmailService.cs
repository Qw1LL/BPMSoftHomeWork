namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Configuration.Marketing.Utilities;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: EmailStatistics

	public class EmailStatistics : BaseWebHook
	{

		#region Properties: Public

		public Guid EmailId { get; set; }

		public int Clicks { get; set; }

		public int Opens { get; set; }

		public int SoftBounce { get; set; }

		public int HardBounce { get; set; }

		public int Spam { get; set; }

		public int Delivered { get; set; }

		public int Sent { get; set; }

		public int Rejected { get; set; }

		public int Unsubscribe { get; set; }

		public int DeliveryError { get; set; }

		public int Expired { get; set; }
		
		public int StoppedManually { get; set; }

		public int EmailStateId { get; set; }

		#endregion

		#region Methods: Private

		private void UpdateProgress(UserConnection userConnection) {
			var progressRepository = ClassFactory.Get<SendingEmailProgressRepository>(
				new ConstructorArgument("userConnection", userConnection));
			progressRepository.IncrementReceivedInitialResponses(EmailId);
		}

		private int SetBulkEmailStatus(UserConnection userConnection, Guid statusId, Guid[] categoryIds) {
			return new Update(userConnection, "BulkEmail")
				.Set("StatusId", Column.Parameter(statusId))
				.Where("Id").IsEqual(Column.Parameter(EmailId))
				.And("CategoryId").In(Column.Parameters(categoryIds)).Execute();
		}

		private void HandleEmailExpiredResponse(UserConnection userConnection) {
			SetBulkEmailStatus(userConnection, MailingConsts.BulkEmailStatusExpiredId, 
				new []{ MailingConsts.MassmailingBulkEmailCategoryId, MailingConsts.TriggeredEmailBulkEmailCategoryId });
		}

		private void HandleEmailCompletedResponse(UserConnection userConnection) {
			var bulkEmail = new BulkEmail(userConnection);
			if (!bulkEmail.FetchFromDB("Id", EmailId, new[] { "Status" }) ||
				bulkEmail.StatusId != MailingConsts.BulkEmailStatusQueuedId) {
				return;
			}
			var updatedRecords = SetBulkEmailStatus(userConnection, MailingConsts.BulkEmailStatusFinishedId, 
				new []{ MailingConsts.MassmailingBulkEmailCategoryId });
			if (updatedRecords > 0) {
				var selectSplitTestId = new Select(userConnection).Column("SplitTestId").From("BulkEmail")
					.Where("Id").IsEqual(Column.Parameter(EmailId)) as Select;
				var splitTestId = selectSplitTestId.ExecuteScalar<Guid>();
				if (splitTestId != Guid.Empty) {
					SetBulkEmailSplitStatus(userConnection, splitTestId);
				}
			}
		}

		private void SetBulkEmailSplitStatus(UserConnection userConnection, Guid splitTestId) {
			var bulkEmailSplit = new BulkEmailSplit(userConnection);
			if (!bulkEmailSplit.FetchFromDB(splitTestId)) {
				MailingUtilities.Log.ErrorFormat(
					"[EmailStatistics.SetBulkEmailSplitStatus]: Failed to fetch BulkEmailSplit from DB." + "Id: {0}",
					splitTestId);
				return;
			}
			var selectCount = new Select(userConnection).Column(Func.Count("Id")).From("BulkEmail").Where("SplitTestId")
				.IsEqual(Column.Parameter(splitTestId)).And("StatusId")
				.IsNotEqual(Column.Parameter(MailingConsts.BulkEmailStatusFinishedId)) as Select;
			var count = selectCount.ExecuteScalar<int>();
			if (count == 0) {
				bulkEmailSplit.SetColumnValue("StatusId", MailingConsts.BulkEmailSplitStatusFinishedId);
				string tableName = string.Format("ST_{0}", splitTestId.ToBase36());
				Utilities.DropTable(tableName, userConnection, true);
			}
			bulkEmailSplit.Save();
		}
		
		private int GetBulkEmailResponseValue(UserConnection userConnection, string responseName) {
			var selectCount = new Select(userConnection)
				.Column(responseName)
				.From("BulkEmail")
				.Where("Id").IsEqual(Column.Parameter(EmailId)) as Select;
			return selectCount.ExecuteScalar<int>();
		}

		#endregion

		#region Methods: Public

		public override string GetGroupKey() {
			return base.GetGroupKey() + EmailId;
		}

		public override void HandleWebHook(UserConnection userConnection) {
			var bulkEmailStoppedManuallyCount = GetBulkEmailResponseValue(userConnection, "StoppedManuallyCount");
			var expiredCount = GetBulkEmailResponseValue(userConnection, "ExpiredCount");
			var stoppedSummaryCount = bulkEmailStoppedManuallyCount + StoppedManually;
			var expiredSummaryCount = expiredCount + Expired;
			new Update(userConnection, "BulkEmail").Set("SendCount", Column.Parameter(Sent))
				.Set("HardBounceCount", Column.Parameter(HardBounce))
				.Set("SoftBounceCount", Column.Parameter(SoftBounce))
				.Set("RejectedCount", Column.Parameter(Rejected))
				.Set("UnsubscribeCount", Column.Parameter(Unsubscribe))
				.Set("SpamCount", Column.Parameter(Spam))
				.Set("ClicksCount", Column.Parameter(Clicks))
				.Set("OpensCount", Column.Parameter(Opens))
				.Set("DeliveredCount", Column.Parameter(Delivered))
				.Set("ModifiedById", Column.Parameter(MarketingConsts.MandrillUserId))
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("StatisticDate", Column.Parameter(DateTime.UtcNow))
				.Set("DeliveryError", Column.Parameter(DeliveryError))
				.Set("ExpiredSummaryCount", Column.Parameter(expiredSummaryCount))
				.Set("ExpiredInProviderCount", Column.Parameter(Expired))
				.Set("StoppedInProviderCount", Column.Parameter(StoppedManually))
				.Set("StoppedSummaryCount", Column.Parameter(stoppedSummaryCount))
				.Where("Id").IsEqual(Column.Parameter(EmailId)).Execute();
			var handlersByResponseCode = new Dictionary<int, Action<UserConnection>> {
				{ (int)EmailState.Expired, HandleEmailExpiredResponse },
				{ (int)EmailState.Complete, HandleEmailCompletedResponse }
			};
			if (handlersByResponseCode.TryGetValue(EmailStateId, out var handler)) {
				try {
					handler(userConnection);
				} catch(Exception e) {
					MailingUtilities.Log.ErrorFormat(
						"[EmailStatistics.HandleWebHook]: Error while handling BulkEmailStatus with Id: {0}", e,
						EmailId);
				}
			}
			UpdateProgress(userConnection);
		}

		#endregion

	}

	#endregion

}

