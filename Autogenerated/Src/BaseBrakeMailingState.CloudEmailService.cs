namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.DB;

	#region Class: BaseBrakeMailingState

	public abstract class BaseBrakeMailingState : MailingState
	{

		#region Constants: Private

		private const int BatchSize = 500;

		#endregion

		#region Properties: Protected

		protected abstract Guid FinalRecipientResponse { get; }

		protected abstract string StateResponseCountColumnName { get; }

		protected abstract string EventProgressCaptionLczStringCode { get; }

		protected abstract string EventProgressMessageLczStringCode { get; }

		#endregion

		#region Methods: Protected

		private void WriteLog(Guid bulkEmailId, int recipientCount) {
			if (recipientCount > 0) {
				BulkEmailEventLogger.LogInfo(bulkEmailId, DateTime.UtcNow,
					GetLczStringValue(EventProgressCaptionLczStringCode),
					GetLczStringValue(EventProgressMessageLczStringCode), Context.UserConnection.CurrentUser.ContactId,
					recipientCount);
			}
		}

		protected void SetAudienceResponse(BulkEmail bulkEmail) {
			var updatedCount = 0;
			do {
				Query update = new Update(Context.UserConnection, "BulkEmailTarget")
					.Set("BulkEmailResponseId", Column.Parameter(FinalRecipientResponse)).Where("Id").In(
						new Select(Context.UserConnection).Top(BatchSize).Column("s", "Id").From("BulkEmailTarget")
							.As("s").Where("s", "BulkEmailId").IsEqual(Column.Parameter(bulkEmail.Id))
							.And("BulkEmailResponseId")
							.IsEqual(Column.Parameter(MailingConsts.BulkEmailResponseReadyToSendId)));
				updatedCount = update.Execute();
				Query bulkEmailUpdate = new Update(Context.UserConnection, "BulkEmail")
					.Set(StateResponseCountColumnName,
						QueryColumnExpression.Add(new QueryColumnExpression(StateResponseCountColumnName),
							Column.Parameter(updatedCount))).Where("Id").IsEqual(Column.Parameter(bulkEmail.Id));
				bulkEmailUpdate.Execute();
				WriteLog(bulkEmail.Id, updatedCount);
			} while (updatedCount > 0);
		}

		#endregion

	}

	#endregion

}

