namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Class: ExpiredMailingState

	/// <summary>
	/// Mailing state that implements handle email behavior after expiration.
	/// </summary>
	public class ExpiredMailingState : BaseBrakeMailingState
	{

		#region Properties: Protected

		protected override string ErrorMessageStringCode => "ExpiredMailingStateErrorMsg";

		protected override string EventLczStringCode => "ExpiredMailingState";

		protected override Guid FinalRecipientResponse => MailingConsts.BulkEmailResponseStoppedExpired;

		protected override string StateResponseCountColumnName => "ExpiredCount";

		protected override string EventProgressCaptionLczStringCode => "ExpiredEventProgressCaptionLczStringCode";

		protected override string EventProgressMessageLczStringCode => "ExpiredEventProgressMessageLczStringCode";

		#endregion

		#region Properties: Public

		public override Guid[] AvailableForExecutionStatuses =>
			new[] { MailingConsts.BulkEmailStatusExpiredId, MailingConsts.BulkEmailStatusExpiredInProgressId };

		#endregion

		#region Methods: Private

		private void UpdateBulkEmailStatistics(Guid bulkEmailId) {
			var bulkEmail = new BulkEmail(Context.UserConnection);
			bulkEmail.FetchFromDB("Id", bulkEmailId,
				new[] { "Id", "ExpiredCount", "ExpiredSummaryCount", "ExpiredInProviderCount" });
			int expiredSummary = bulkEmail.ExpiredInProviderCount + bulkEmail.ExpiredCount;
			BulkEmailQueryHelper.UpdateBulkEmail(bulkEmailId, Context.UserConnection,
				new KeyValuePair<string, object>("ExpiredSummaryCount", expiredSummary));
			SendingEmailProgressRepository.IncrementPreparedRecipients(bulkEmailId, bulkEmail.ExpiredCount);
			SendingEmailProgressRepository.IncrementProcessedRecipients(bulkEmailId, bulkEmail.ExpiredCount);
			SendingEmailProgressRepository.IncrementReceivedInitialResponses(bulkEmailId);
		}

		#endregion

		#region Methods: Protected

		protected override MailingStateExecutionResult HandleStepInternal() {
			var bulkEmail = (BulkEmail)Context.BulkEmailEntity;
			if (!Context.UserConnection.GetIsFeatureEnabled("TriggerEmailThrottlingQueue")) {
				return new MailingStateExecutionResult(this.GetType()) {
					Success = true,
					Status = MailingStateExecutionStatus.Skipped
				};
			}
			var start = DateTime.UtcNow;
			SetBulkEmailStatus(bulkEmail.Id, MailingConsts.BulkEmailStatusExpiredInProgressId);
			SetAudienceResponse(bulkEmail);
			UpdateBulkEmailStatistics(bulkEmail.Id);
			SetBulkEmailStatus(bulkEmail.Id, MailingConsts.BulkEmailStatusExpiredId);
			BulkEmailEventLogger.LogInfo(bulkEmail.Id, start, GetLczStringValue(EventLczStringCode), 
				GetLczStringValue("ExpiredMailingStateSuccess"), Context.UserConnection.CurrentUser.ContactId);
			return new MailingStateExecutionResult(this.GetType()) {
				Success = true,
				Status = MailingStateExecutionStatus.Done
			};
		}

		#endregion

	}

	#endregion

}

