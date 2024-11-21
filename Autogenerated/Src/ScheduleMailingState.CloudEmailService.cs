namespace BPMSoft.Configuration
{
	using System;

	public class ScheduleMailingState : MailingState
	{
		public override Guid[] AvailableForExecutionStatuses => throw new NotImplementedException();

		protected override string ErrorMessageStringCode => throw new NotImplementedException();

		protected override string EventLczStringCode => throw new NotImplementedException();

		/// <summary>
		/// Executes this state.
		/// </summary>
		/// <returns>Instance of <see cref="MailingStateExecutionResult"/>.</returns>
		protected override MailingStateExecutionResult HandleStepInternal() {
			throw new NotImplementedException();
		}
	}
}

