namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Core.DB;

	#region Class: EmailSendingLimitValidator

	/// <summary>
	/// Manages validation of bulk email sending limit.
	/// </summary>
	public class EmailSendingLimitValidator : BaseMessageValidator
	{

		#region Constants: Private

		private const int UnlimitedSendingFlag = -1;

		#endregion

		#region Fields: Private

		private BulkEmailEventLogger _bulkEmailEventLogger;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets the possibility to interrupt chain of validators.
		/// </summary>
		protected override bool IsAbortOnValidation => false;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets the bulk email event logger.
		/// </summary>
		public BulkEmailEventLogger BulkEmailEventLogger =>
			_bulkEmailEventLogger ?? (_bulkEmailEventLogger = new BulkEmailEventLogger(UserConnection));

		#endregion

		#region Methods: Private

		private int GetAudienceToSendCount(Guid messageId) {
			var select = new Select(UserConnection).Column(Func.Count("Id")).From("BulkEmailTarget")
				.Where("BulkEmailId")
				.IsEqual(Column.Parameter(messageId)).And("BulkEmailResponseId")
				.IsEqual(Column.Const(MailingConsts.BulkEmailResponseReadyToSendId)) as Select;
			return select.ExecuteScalar<int>();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Validates sending by limits from cloud email service.
		/// </summary>
		/// <param name="emailContext">Dto with necessary bulk email info</param>
		/// <returns>Validation message if not succeed.</returns>
		protected override string Validate(BulkEmailContext emailContext) {
			var licInfo = ServiceApi.GetAccountLicenseInformation(new BaseServiceRequest {
				ApiKey = ServiceApi.ApiKey
			});
			if (licInfo.DailyLimitCount == UnlimitedSendingFlag) {
				return string.Empty;
			}
			var audienceCount = emailContext.RecipientCount > 0 ? emailContext.RecipientCount : emailContext.MessageIds.Sum(GetAudienceToSendCount);
			int emailRemains = licInfo.DailyLimitCount - licInfo.TodayUsage;
			emailRemains = emailRemains > 0 ? emailRemains : 0;
			if (audienceCount <= emailRemains) {
				return string.Empty;
			}
			var validationMessageTemplate = GetLczStringValue("EmailSendingLimitValidationMessage");
			var validationMessage = string.Format(validationMessageTemplate, licInfo.DailyLimitCount,
				audienceCount, licInfo.TodayUsage, emailRemains);
			foreach (var messageId in emailContext.MessageIds) {
				BulkEmailEventLogger.LogError(messageId, DateTime.UtcNow, GetLczStringValue("ValidateMessageEvent"),
					validationMessage, UserConnection.CurrentUser.ContactId);
			}
			return validationMessage;
		}

		#endregion

	}

	#endregion

}
