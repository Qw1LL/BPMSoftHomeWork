namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Configuration.Marketing.Utilities;
	using BPMSoft.Core.DB;

	#region Class: InitialSendingMailingState

	/// <summary>
	/// Mailing state that implements Update bulk email status for starting send process.
	/// </summary>
	public class InitialSendingMailingState : MailingState
	{

		#region Properties: Protected

		protected override string ErrorMessageStringCode => "BulkEmailStatusUpdateEvent";

		protected override string EventLczStringCode => "InitialSendingMailingState";

		#endregion

		#region Properties: Public

		public override Guid[] AvailableForExecutionStatuses => new [] {
			MailingConsts.BulkEmailStatusWaitingBeforeSendId,
			MailingConsts.BulkEmailStatusActiveId,
			MailingConsts.BulkEmailStatusStartPlanedId
		};

		#endregion

		#region Methods: Private

		private Guid GetActualStatus(BulkEmail bulkEmail) {
			var emailExpired = bulkEmail.ExpirationDate > DateTime.MinValue &&
				bulkEmail.ExpirationDate.ToUniversalTime() < DateTime.UtcNow;
			return  emailExpired ? MailingConsts.BulkEmailStatusExpiredId : MailingConsts.BulkEmailStatusStartsId;
		}
		private void SetBulkEmailSplitStatus(Guid splitTestId, Guid bulkEmailStatusId) {
			try {
				var bulkEmailSplit = new BulkEmailSplit(Context.UserConnection);
				if (!bulkEmailSplit.FetchFromDB(splitTestId)) {
					MailingUtilities.Log.ErrorFormat(
						"[InitialSendingMailingState.SetBulkEmailSplitStatus]: Failed to fetch BulkEmailSplit from DB." +
						"Id: {0}", splitTestId);
					return;
				}
				if (bulkEmailStatusId == MailingConsts.BulkEmailStatusStartsId &&
					bulkEmailSplit.StatusId == MailingConsts.BulkEmailSplitStatusStartPlanedId) {
					bulkEmailSplit.SetColumnValue("StatusId", MailingConsts.BulkEmailSplitStatusLaunchedId);
				}
				if (bulkEmailStatusId == MailingConsts.BulkEmailStatusFinishedId) {
					var selectCount = new Select(Context.UserConnection).Column(Func.Count("Id")).From("BulkEmail")
						.Where("SplitTestId").IsEqual(Column.Parameter(splitTestId)).And("StatusId")
						.IsNotEqual(Column.Parameter(MailingConsts.BulkEmailStatusFinishedId)) as Select;
					var count = selectCount.ExecuteScalar<int>();
					if (count == 0) {
						bulkEmailSplit.SetColumnValue("StatusId", MailingConsts.BulkEmailSplitStatusFinishedId);
						string tableName = $"ST_{splitTestId.ToBase36()}";
						Utilities.DropTable(tableName, Context.UserConnection, true);
					}
				}
				bulkEmailSplit.Save();
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[InitialSendingMailingState.SetBulkEmailSplitStatus]: Error while InitialSendingMailingState BulkEmailSplit with Id: {0}",
					e, splitTestId);
			}
		}

		private void SetBulkEmailStatus(BulkEmail bulkEmail, Guid statusId) {
			var bulkEmailId = Guid.Empty;
			try {
				bulkEmailId = bulkEmail.Id;
				var bulkEmailStatusUpdate = new Update(Context.UserConnection, "BulkEmail")
					.Set("StatusId", Column.Parameter(statusId)).Where("Id")
					.IsEqual(Column.Parameter(bulkEmailId)) as Update;
				bulkEmailStatusUpdate.WithHints(new RowLockHint());
				bulkEmailStatusUpdate.Execute();
				bulkEmail.StatusId = statusId;
				if (bulkEmail.SplitTestId != Guid.Empty) {
					SetBulkEmailSplitStatus(bulkEmail.SplitTestId, statusId);
				}
				MailingUtilities.Log.InfoFormat("BulkEmail with Id: {0} set to {1} status.", bulkEmailId, statusId);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[InitialSendingMailingState.SetBulkEmailStatus]: Error while InitialSendingMailingState BulkEmail with Id: {0}",
					e, bulkEmailId);
				BulkEmailEventLogger.LogError(bulkEmailId, DateTime.UtcNow,
					GetLczStringValue("BulkEmailStatusUpdateEvent"), e, GetLczStringValue("SaveErrorMsg"),
					Context.UserConnection.CurrentUser.ContactId);
				throw;
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Handles the step with step-specific logic.
		/// </summary>
		/// <returns>Instance of <see cref="MailingStateExecutionResult"/>.</returns>
		protected override MailingStateExecutionResult HandleStepInternal() {
			var bulkEmail = (BulkEmail)Context.BulkEmailEntity;
			var actualStatus = GetActualStatus(bulkEmail);
			SetBulkEmailStatus(bulkEmail, actualStatus);
			MailingUtilities.Log.InfoFormat(
				"[InitialSendingMailingState.SetBulkEmailStatusStartsId]: " + "Step Finished. BulkEmailId {0}.",
				bulkEmail.Id);
			return new MailingStateExecutionResult(this.GetType()) {
				Success = true,
				Status = MailingStateExecutionStatus.Done
			};
		}


		#endregion

	}

	#endregion

}

