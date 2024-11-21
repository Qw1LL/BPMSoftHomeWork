 namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.EventHandler;
	using BPMSoft.Core.DB;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	/// <summary>
	/// Contains methods for maintaining Timer elements in campaign.
	/// </summary>
	public sealed class CampaignTimerElementHandler : CampaignEventHandlerBase, IOnCampaignValidate
	{

		#region Class: CampaignTimeParameters

		private class CampaignTimeParameters
		{

			#region Properties: Internal

			internal Guid ScheduledStartModeId {
				get; set;
			}

			internal DateTime ScheduledStartDate {
				get; set;
			}

			internal Guid ScheduledStopModeId {
				get; set;
			}

			internal DateTime ScheduledStopDate {
				get; set;
			}

			#endregion

		}

		#endregion

		#region Methods: Private

		private IEnumerable<CampaignTimerElement> GetTimerElements(CoreCampaignSchema schema) {
			return schema.FlowElements.OfType<CampaignTimerElement>();
		}

		private bool CanProcessSingleRunTimerInCampaign(CampaignTimerElement timer,
				CampaignTimeParameters campaignParameter) {
			if (timer.ExpressionType != Core.Process.StartTimerEventExpresionType.SingleRun) {
				return true;
			}
			var isLessThanNow = new Func<CampaignTimerElement, bool>(
				(t) => {
					return t.StartDateTimeUtc < DateTime.UtcNow;
			});
			var isLessThanScheduledStart = new Func<CampaignTimerElement, CampaignTimeParameters, bool>(
				(t, c) => {
					return c.ScheduledStartModeId == CampaignConsts.CampaingSpecifiedTimeModeId
						&& t.StartDateTimeUtc < c.ScheduledStartDate;
			});
			var isGreaterThanScheduledStop = new Func<CampaignTimerElement, CampaignTimeParameters, bool>(
				(t, c) => {
					return c.ScheduledStopModeId == CampaignConsts.CampaingSpecifiedTimeModeId
						&& t.StartDateTimeUtc > c.ScheduledStopDate;
			});
			if (isLessThanNow(timer) || isLessThanScheduledStart(timer, campaignParameter)
					|| isGreaterThanScheduledStop(timer, campaignParameter)) {
				return false;
			}
			return true;
		}

		private bool CanProcessTimerPeriodInCampaign(CampaignTimerElement timer,
				CampaignTimeParameters campaignParameter) {
			var isStartTimeGreaterThanScheduledStop = new Func<CampaignTimerElement, CampaignTimeParameters, bool>(
				(t, c) => {
					return t.UseStartDateTime && c.ScheduledStopModeId == CampaignConsts.CampaingSpecifiedTimeModeId
						&& t.StartDateTimeUtc > c.ScheduledStopDate;
			});
			var isEndDateLessThanNow = new Func<CampaignTimerElement, CampaignTimeParameters, bool>(
				(t, c) => {
					return t.UseEndDateTime && t.EndDateTimeUtc < DateTime.UtcNow;
			});
			var isEndDateTimeLessThanScheduledStart = new Func<CampaignTimerElement, CampaignTimeParameters, bool>(
				(t, c) => {
					return t.UseEndDateTime && c.ScheduledStartModeId == CampaignConsts.CampaingSpecifiedTimeModeId
							&& t.EndDateTimeUtc < c.ScheduledStartDate;
			});
			if (isStartTimeGreaterThanScheduledStop(timer, campaignParameter)
					|| isEndDateLessThanNow(timer, campaignParameter)
					|| isEndDateTimeLessThanScheduledStart(timer, campaignParameter)) {
				return false;
			}
			return true;
		}

		private bool CanProcessTimerInCampaign(CampaignTimerElement timer, CampaignTimeParameters campaignParameter) {
			return CanProcessSingleRunTimerInCampaign(timer, campaignParameter)
				&& CanProcessTimerPeriodInCampaign(timer, campaignParameter);
		}

		private IEnumerable<CampaignTimerElement> GetOutOfRangeTimers(CampaignTimeParameters campaignParameter) {
			var elements = GetTimerElements(CampaignSchema);
			return elements.Where(x => !CanProcessTimerInCampaign(x, campaignParameter));
		}

		private void WriteTimerOutOfRangeMessagesToCampaign(IEnumerable<CampaignTimerElement> timers) {
			if (!timers.Any()) {
				return;
			}
			var timersCaptions = string.Empty;
			foreach (var timer in timers) {
				timersCaptions += (string.IsNullOrEmpty(timersCaptions) ? "\"" : ", \"") + timer.Caption + "\"";
			}
			string message = GetLczStringValue(nameof(CampaignTimerElementHandler), "TimerNeverExecuteWarning");
			string validationInfoMessage = string.Format(message, timersCaptions);
			CampaignSchema.AddValidationInfo(validationInfoMessage, CampaignValidationInfoLevel.Warning);
		}

		private CampaignTimeParameters GetCampaignTimeParameters(Guid campaignId) {
			var scheduledParametersContainer = new CampaignTimeParameters();
			var campaignSelect = new Select(UserConnection)
				.Column("ScheduledStartDate")
				.Column("ScheduledStopDate")
				.Column("ScheduledStartModeId")
				.Column("ScheduledStopModeId")
				.From("Campaign")
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Select;
			campaignSelect.SpecifyNoLockHints();
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				campaignSelect.ExecuteReader((IDataReader reader) => {
					scheduledParametersContainer.ScheduledStartDate
						= reader.GetColumnValue<DateTime>("ScheduledStartDate");
					scheduledParametersContainer.ScheduledStopDate
						= reader.GetColumnValue<DateTime>("ScheduledStopDate");
					scheduledParametersContainer.ScheduledStartModeId
						= reader.GetColumnValue<Guid>("ScheduledStartModeId");
					scheduledParametersContainer.ScheduledStopModeId
						= reader.GetColumnValue<Guid>("ScheduledStopModeId");
				});
			}
			return scheduledParametersContainer;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates Timer elements on campaign validation. Searches out of range timers.
		/// </summary>
		public void OnValidate() {
			var campaignParameters = GetCampaignTimeParameters(CampaignSchema.EntityId);
			var outOfRangeTimers = GetOutOfRangeTimers(campaignParameters);
			if (!outOfRangeTimers.Any()) {
				return;
			}
			WriteTimerOutOfRangeMessagesToCampaign(outOfRangeTimers);
		}

		#endregion

	}
}

