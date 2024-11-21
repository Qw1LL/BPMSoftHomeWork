namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;

	#region Class: ValidationMailingState

	/// <summary>
	/// Represents the class of validation mailing state.
	/// </summary>
	public class ValidationMailingState : MailingState
	{

		#region Properties: Protected

		/// <summary>
		/// The mailing state validator.
		/// </summary>
		protected MailingStateValidator Validator { get; set; }

		/// <summary>
		/// The builder for mailing state validation rules.
		/// </summary>
		protected IMailingStateValidationBuilder ValidationBuilder { get; set; }

		protected override string ErrorMessageStringCode => "ValidateEmailErrorMsg";

		protected override string EventLczStringCode => "ValidateBulkEmailEventName";

		#endregion

		#region Properties: Public

		public override Guid[] AvailableForExecutionStatuses => new[] {
			MailingConsts.BulkEmailStatusPlannedId,
			MailingConsts.BulkEmailStatusStartPlanedId,
			MailingConsts.BulkEmailStatusActiveId,
			MailingConsts.BulkEmailStatusErrorId,
			MailingConsts.BulkEmailStatusStoppedId,
			MailingConsts.BulkEmailStatusHardStoppedId,
			MailingConsts.BulkEmailStatusExpiredId
		};

		#endregion

		#region Methods: Protected

		protected override bool CanHandle() {
			return true;
		}

		protected override MailingStateExecutionResult HandleStepInternal() {
			var validationResult = Validator.Validate(this);
			var failedResults = validationResult.Where(x => !x.Success).ToList();
			var result = new MailingStateExecutionResult(this.GetType());
			result.Success = !failedResults.Any();
			result.NotificationLcsStringCodes = failedResults.Where(x => !string.IsNullOrEmpty(x.LczStringCode))
				.Select(x => x.LczStringCode);
			result.EventLczStringCode = EventLczStringCode;
			result.Status = MailingStateExecutionStatus.Done;
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		public override void Initialize() {
			base.Initialize();
			ValidationBuilder = new ValidationStateRuleBuilder();
			Validator = new MailingStateValidator(ValidationBuilder);
		}

		#endregion

	}

	#endregion

}

