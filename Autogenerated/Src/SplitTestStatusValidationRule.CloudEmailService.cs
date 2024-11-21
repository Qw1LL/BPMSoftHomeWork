namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Entities;

	/// <summary>
	/// Represents the SplitTest status validation rule.
	/// </summary>
	public class SplitTestStatusValidationRule : IMailingStateValidationRule
	{

		#region Methods: Public

		/// <summary>
		///	Execute validation for SplitTest status rule.
		/// </summary>
		/// <param name="state">The state for validation.</param>
		/// <returns>Instance of <see cref="ValidationResponse"/> represents validation results.</returns>
		public ValidationResponse Validate(MailingState state) {
			MailingContext context = state.Context;
			Entity bulkEmail = context.BulkEmailEntity;
			if (bulkEmail.GetTypedColumnValue<Guid>("SegmentsStatusId") == MailingConsts.SegmentStatusUpdatingId) {
				MailingUtilities.Log.InfoFormat(
					"BulkEmail with Id: {0} can't get started. Segment status is 'Updating'.",
					bulkEmail.GetTypedColumnValue<Guid>("Id") );
				//TODO add validation lcz string
				return new ValidationResponse {
					Success = false
				};
			}
			return new ValidationResponse {
				Success = true
			};
		}

		#endregion

	}
}

