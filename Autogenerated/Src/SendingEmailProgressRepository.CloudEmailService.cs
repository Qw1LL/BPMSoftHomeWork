namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;

	#region Class: SendingEmailProgressRepository

	/// <summary>
	/// Represents the repository for marketing email sending progress table.
	/// </summary>
	public class SendingEmailProgressRepository: ISendingEmailProgressRepository
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>Initializes a new instance of the <see cref="SendingEmailProgressRepository" /> class.</summary>
		public SendingEmailProgressRepository(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private bool GetBulkEmail(Guid emailId, string [] properties,out BulkEmail entity) {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName("BulkEmail");
			entity = (BulkEmail)entitySchema.CreateEntity(_userConnection);
			return entity.FetchFromDB(nameof(entity.Id), emailId, properties);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns the instance of <see cref="SendingEmailProgress"/> with email progress counters.
		/// </summary>
		/// <param name="emailId">Identifier of BulkEmail.</param>
		/// <returns>Instance of <see cref="SendingEmailProgress"/>.</returns>
		public SendingEmailProgress GetProgressRecord(Guid emailId) {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName("SendingEmailProgress");
			var entity = (SendingEmailProgress)entitySchema.CreateEntity(_userConnection);
			if(!entity.FetchFromDB("BulkEmail", emailId, false)) {
				entity.SetDefColumnValues();
				entity.Id = Guid.NewGuid();
				entity.BulkEmailId = emailId;
			}
			entity.ModifiedOn = DateTime.UtcNow;
			return entity;
		}


		/// <summary>
		/// Adds value <param name="preparedToSendCount"> to counter which describe count of recipients has been prepared to be send.</param>
		/// </summary>
		/// <param name="emailId">Id of email.</param>
		/// <param name="preparedToSendCount">Count of prepared to send recipients in current iteration.</param>
		public void IncrementPreparedRecipients(Guid emailId, int preparedToSendCount) {
			var record = GetProgressRecord(emailId);
			var propertyToFetch = new[] { "RecipientCount" };
			if(GetBulkEmail(emailId, propertyToFetch, out var email)) {
				record.PreparedRecipientsCount = Math.Min(preparedToSendCount + record.PreparedRecipientsCount,
					email.RecipientCount);
				record.Save(false);
			}
		}

		/// <summary>
		/// Adds value <param name="sendingCount"> to counter which describe count of recipients which has been sent to provider.</param>
		/// </summary>
		/// <param name="emailId">Id of email.</param>
		/// <param name="sendingCount">Count of recipients which has been sent to provider.</param>
		public void IncrementProcessedRecipients(Guid emailId, int sendingCount) {
			var record = GetProgressRecord(emailId);
			var propertyToFetch = new[] { "RecipientCount" };
			if (GetBulkEmail(emailId, propertyToFetch, out var email)) {
				record.ProcessedRecipientCount =
					Math.Min(sendingCount + record.ProcessedRecipientCount, email.RecipientCount);
				record.Save(false);
			}
		}

		/// <summary>
		/// Actualize value ReceivedInitialResponseCount value for email.
		/// </summary>
		/// <param name="emailId">Id of email.</param>
		public void IncrementReceivedInitialResponses(Guid emailId) {
			var record = GetProgressRecord(emailId);
			var propertyToFetch = new[] {
				"CanceledCount", "HardBounceCount", "SoftBounceCount", "RejectedCount", "DeliveryError",
				"DeliveredCount", "StoppedSummaryCount", "ExpiredSummaryCount"
			};
			if (GetBulkEmail(emailId, propertyToFetch, out var email)) {
				var sentCountValue = email.CanceledCount + email.HardBounceCount + email.SoftBounceCount +
					email.RejectedCount + email.DeliveryError + email.DeliveredCount + email.StoppedSummaryCount +
					email.ExpiredSummaryCount;
				record.ReceivedInitialResponseCount = sentCountValue;
				record.Save(false);
			}
		}

		#endregion

	}

	#endregion

}

