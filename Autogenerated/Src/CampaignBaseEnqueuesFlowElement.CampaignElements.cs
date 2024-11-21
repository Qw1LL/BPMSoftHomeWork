namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;
	using global::Common.Logging;
	using System.Data;
	using System.Collections.Generic;

	#region Class: CampaignBaseCrudObjectFlowElement

	/// <summary>
	/// Base class for regular executable elements for enqueues participants to <see cref="CampaignQueue"/>.
	/// </summary>
	public abstract class CampaignBaseEnqueuesFlowElement : CampaignFlowElement
	{

		#region Properties: Protected

		/// <summary>
		/// Expiration time of <see cref="CampaignQueueItem"/> in <see cref="CampaignQueue"/>.
		/// </summary>
		protected virtual int QueueItemExpirationPeriod => int.MaxValue;

		/// <summary>
		/// Instance of the <see cref="CampaignQueueManager"/>.
		/// </summary>
		protected CampaignQueueManager CampaignQueueManager => new CampaignQueueManager(UserConnection);

		/// <summary>
		/// Campaign logger.
		/// </summary>
		private ILog _logger;
		protected ILog CampaignLogger =>
			_logger ?? (_logger = LogManager.GetLogger(CampaignConstants.CampaignLoggerName));

		#endregion

		#region Methods: Private

		private bool IsFragmentExecution() => SessionId != default(Guid);

		private Select GetParticipatingContactsSelect(Select audieceQuery) {
			var select = new Select(audieceQuery);
			select.Columns.Clear();
			select
				.Column("Id").As("CampaignParticipantId")
				.Column("ContactId").As("ContactId");
			return select;
		}

		private void SetParticipantsErrorStatus(Exception ex) {
			try {
				SetParticipantsStatus((Select)GetAudienceQuery(), CampaignConstants.CampaignParticipantErrorStatusId);
			} catch (Exception e) {
				throw new AggregateException(new List<Exception> { ex, e });
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes current flow element in fragment.
		/// </summary>
		/// <returns>Count of participants which has been processed.</returns>
		protected abstract int FragmentExecute();

		/// <summary>
		/// Executes current flow element for selected audience.
		/// Adds participants to <see cref="CampaignQueue"/> and sets them 
		/// <see cref="CampaignConstants.CampaignParticipantInProgressStatusId"/>.
		/// </summary>
		/// <param name="audieceQuery">Query for item audience to be processed.</param>
		/// <returns>Count of participants which has been processed.</returns>
		protected override int SingleExecute(Query audieceQuery) {
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction(IsolationLevel.ReadCommitted);
				try {
					var contactsSelect = GetParticipatingContactsSelect((Select)audieceQuery);
					CampaignQueueManager.Enqueue(contactsSelect, CampaignItemId, QueueItemExpirationPeriod);
					var result = SetParticipantsStatus((Select)audieceQuery,
						CampaignConstants.CampaignParticipantInProgressStatusId, false);
					dbExecutor.CommitTransaction();
					return result;
				} catch {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
		}

		/// <summary>
		/// Executes current flow element.
		/// Used logic of <see cref="FragmentExecute"/> when current flow element executes in fragment.
		/// <param name="context">The execution context.</param>
		/// <returns>Count of participants that has been processed.</returns>
		protected override int SafeExecute(ProcessExecutingContext context) {
			if (IsFragmentExecution()) {
				try {
					return FragmentExecute();
				} catch (Exception ex) {
					CampaignLogger.ErrorFormat($"{GetType().Name} failed to run {nameof(FragmentExecute)} method.", ex,
						CampaignItemId);
					SetParticipantsErrorStatus(ex);
					throw ex;
				}
			}
			return base.SafeExecute(context);
		}

		#endregion

	}

	#endregion

}

