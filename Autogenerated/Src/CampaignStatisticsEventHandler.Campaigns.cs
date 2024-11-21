namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Attributes;
	using BPMSoft.Core.Campaign.EventHandler;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Campaign;

	#region Class: CampaignEventHandler

	/// <summary>
	/// Contains methods to actualize campaign statistics during campaign events.
	/// </summary>
	public sealed class CampaignStatisticsEventHandler : CampaignEventHandlerBase, IOnCampaignStop, IOnCampaignExecutionTerminate
	{

		#region Constants: Private

		private const string ElementHandlerName = nameof(CampaignStatisticsEventHandler);
		private const string CampaignTableName = nameof(Campaign);
		private const string CampaignParticipantTableName = nameof(CampaignParticipant);

		#endregion

		#region Properties: Public

		#endregion

		#region Methods: Private

		private Select GetTotalCampaignParticipantsCountSelect() {
			var select = new Select(UserConnection)
					.Column(Func.Count("Id"))
				.From(CampaignParticipantTableName)
				.Where("CampaignId").IsEqual(Column.Parameter(CampaignSchema.EntityId)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		private Select GetReachedTheGoalParticipantsCountSelect() {
			var select = GetTotalCampaignParticipantsCountSelect();
			return select.And("StatusId")
				.IsEqual(Column.Parameter(CampaignConstants.CampaignParticipantReachedGoalStatusId)) as Select;
		}

		private void UpdateCampaignAudienceCounters() {
			var totalCountSelect = GetTotalCampaignParticipantsCountSelect();
			var reachedGoalCountSelect = GetReachedTheGoalParticipantsCountSelect();
			var update = new Update(UserConnection, CampaignTableName)
					.Set("TargetTotal", Column.SubSelect(totalCountSelect))
					.Set("TargetAchieve", Column.SubSelect(reachedGoalCountSelect))
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
				.Where("Id").IsEqual(Column.Parameter(CampaignSchema.EntityId)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Applies methods for campaign statistics on stop.
		/// Actualizes campaign audience counters.
		/// </summary>
		[Order(100)]
		public void OnStop() {
			try {
				UpdateCampaignAudienceCounters();
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnStopException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Contains logic for campaign statistics on execution terminate.
		/// Actualizes campaign audience counters.
		/// </summary>
		[Order(100)]
		public void OnExecutionTerminate() {
			try {
				UpdateCampaignAudienceCounters();
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnExecutionTerminateException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		#endregion

	}

	#endregion

}

