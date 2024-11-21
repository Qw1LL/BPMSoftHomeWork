namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	/// <summary>
	/// Represents the ping service api validation rule.
	/// </summary>
	public class StatusValidationRule : IMailingStateValidationRule
	{

		#region Properties: Protected

		/// <summary>
		/// The array of statuses available for execution bulk email.
		/// </summary>
		[Obsolete("7.17.2 | Use MailingState.AvailableForExecutionStatuses instead.")]
		protected virtual Guid[] AvailableForExecutionStatuses {
			get {
				return new[] {
					MailingConsts.BulkEmailStatusPlannedId,
					MailingConsts.BulkEmailStatusStartPlanedId,
					MailingConsts.BulkEmailStatusActiveId,
					MailingConsts.BulkEmailStatusErrorId,
					MailingConsts.BulkEmailStatusStoppedId
				};
			}
		}

		#endregion

		#region Methods: Private

		private Guid GetBulkEmailStatus(Guid bulkEmailId, UserConnection userConnection) {
			var select = new Select(userConnection)
				.Top(1)
				.Column("StatusId")
				.From("BulkEmail")
				.Where("Id").IsEqual(Column.Parameter(bulkEmailId)) as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<Guid>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		///	Execute validation for bulkEmail status rule.
		/// </summary>
		/// <param name="state">The state for validation.</param>
		/// <returns>Instance of <see cref="ValidationResponse"/> represents validation results.</returns>
		public ValidationResponse Validate(MailingState state) {
			var bulkEmail = state.Context.BulkEmailEntity;
			var bulkEmailId = bulkEmail.GetTypedColumnValue<Guid>("Id");
			var bulkEmailStatusId = GetBulkEmailStatus(bulkEmailId, state.Context.UserConnection);
			bool isAvailableForExecution = state.AvailableForExecutionStatuses.Contains(bulkEmailStatusId);
			if (!isAvailableForExecution) {
				MailingUtilities.Log.Info("[StatusValidationRule.Validate] " +
					"Bulk email is not in expected status. Step execution interrupted. Break iteration. " +
					$"Step: {state.GetType().Name}, "+
					$"Available statuses: {string.Join(" ", state.AvailableForExecutionStatuses)}, " +
					$"Actual status: {bulkEmailStatusId}, BulkEmailId: {bulkEmailId}");
				return new ValidationResponse {
					Success = false,
					LczStringCode = "StatusValidationFailed"
				};
			}
			return new ValidationResponse {
				Success = true
			};
		}

		#endregion

	}

}

