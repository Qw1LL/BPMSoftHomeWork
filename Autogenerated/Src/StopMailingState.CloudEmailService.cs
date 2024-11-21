namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Configuration.Marketing.Utilities;
	using BPMSoft.Configuration.CES;

	#region Class: StopMailingState

	/// <summary>
	/// Mailing state that implements email stop.
	/// </summary>
	public class StopMailingState : BaseBrakeMailingState
	{

		#region Properties: Protected

		protected override string ErrorMessageStringCode => "MailingStoppedManuallyErrorMsg";

		protected override string EventLczStringCode => "MailingStoppedManually";

		protected override Guid FinalRecipientResponse => MailingConsts.BulkEmailResponseStoppedManually;

		protected override string StateResponseCountColumnName => "StoppedManuallyCount";

		protected override string EventProgressCaptionLczStringCode => "StopEventProgressCaptionLczStringCode";

		protected override string EventProgressMessageLczStringCode => "StopEventProgressMessageLczStringCode";

		#endregion

		#region Properties: Public

		public override Guid[] AvailableForExecutionStatuses =>
			new[] { MailingConsts.BulkEmailStatusBreakingId, MailingConsts.BulkEmailStatusHardStoppedId };

		#endregion

		#region Methods: Private

		private void UpdateBulkEmailStatistics(Guid bulkEmailId) {
			var bulkEmail = new BulkEmail(Context.UserConnection);
			bulkEmail.FetchFromDB("Id", bulkEmailId,
				new[] { "Id", "StoppedManuallyCount", "StoppedSummaryCount", "StoppedInProviderCount" });
			int stoppedSummaryCount = bulkEmail.StoppedInProviderCount + bulkEmail.StoppedManuallyCount;
			BulkEmailQueryHelper.UpdateBulkEmail(bulkEmailId, Context.UserConnection,
				new KeyValuePair<string, object>("StoppedSummaryCount", stoppedSummaryCount));
			SendingEmailProgressRepository.IncrementPreparedRecipients(bulkEmailId, bulkEmail.StoppedManuallyCount);
			SendingEmailProgressRepository.IncrementProcessedRecipients(bulkEmailId, bulkEmail.StoppedManuallyCount);
			SendingEmailProgressRepository.IncrementReceivedInitialResponses(bulkEmailId);
		}
		
		private void StopBulkEmailInProvider(Guid bulkEmailId) {
			if (!Context.UserConnection.GetIsFeatureEnabled("BulkEmailStop")) {
				return;
			}
			try {
				Utilities.RetryOnFailure(() => Context.ServiceApi.StopBulkEmail(bulkEmailId), 15, 5);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat("[StopMailingState.StopBulkEmailInCes]: BulkEmail with " +
					"Id: {0} stop email execution error", e, bulkEmailId);
				BulkEmailEventLogger.LogError(bulkEmailId, DateTime.UtcNow,
					GetLczStringValue("MailingStoppedManually"), e, GetLczStringValue("MailingStoppedManuallyErrorMsg"),
					Context.UserConnection.CurrentUser.ContactId);
				throw;
			}
		}

		#endregion

		#region Methods: Protected

		protected override MailingStateExecutionResult HandleStepInternal() {
			var bulkEmail = (BulkEmail)Context.BulkEmailEntity;
			if (!Context.UserConnection.GetIsFeatureEnabled("BulkEmailStop")) {
				return new MailingStateExecutionResult(this.GetType()) {
					Success = true,
					Status = MailingStateExecutionStatus.Skipped
				};
			}
			var start = DateTime.UtcNow;
			SetBulkEmailStatus(bulkEmail.Id, MailingConsts.BulkEmailStatusBreakingId);
			SetAudienceResponse(bulkEmail);
			UpdateBulkEmailStatistics(bulkEmail.Id);
			StopBulkEmailInProvider(bulkEmail.Id);
			SetBulkEmailStatus(bulkEmail.Id, MailingConsts.BulkEmailStatusHardStoppedId);
			BulkEmailEventLogger.LogInfo(bulkEmail.Id, start, GetLczStringValue(EventLczStringCode), 
				GetLczStringValue("MailingStoppedManuallyDescription"), Context.UserConnection.CurrentUser.ContactId);
			return new MailingStateExecutionResult(this.GetType()) {
				Success = true,
				Status = MailingStateExecutionStatus.Done
			};
		}

		#endregion

	}

	#endregion

}

