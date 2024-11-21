namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;

	#region Class: ParticipantsAnalyticsProvider

	/// <summary>
	/// Contains logic for calculates analytics for campaign.
	/// </summary>
	public class CampaignAnalyticsProvider
	{

		#region Fields: Private

		private readonly Guid HistoryStatusId = new Guid("7078E39E-FFA9-4140-A2E9-43D3B573D60A");

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor which defines user connection.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="BPMSoft.Core.UserConnection"/></param>
		public CampaignAnalyticsProvider(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection {
			get; set;
		}

		#endregion

		#region Methods: Private

		private void AddTimeFilters(ref Select sourceSelect, DateTime startDate, DateTime dueDate) {
			var filterStartDateCondition = sourceSelect.AddCondition(sourceSelect.SourceExpression.Alias, "CreatedOn",
					LogicalOperation.And);
			filterStartDateCondition.IsGreaterOrEqual(Column.Parameter(startDate));
			var filterDueDateCondition = sourceSelect.AddCondition(sourceSelect.SourceExpression.Alias, "CreatedOn",
				LogicalOperation.And);
			filterDueDateCondition.IsLessOrEqual(Column.Parameter(dueDate));
		}

		private Select GetParticipantsAnalyticsSelect(ParticipantsAnalyticsRequest analyticsRequest) {
			var select = new Select(UserConnection)
				.Column("cp", "CampaignItemId")
				.Column("cp", "StepCompleted")
				.Column("cp", "StatusId")
				.Column(Func.Count("cp", "CampaignItemId")).As("Count")
				.From("CampaignParticipant").As("cp")
				.Where("cp", "CampaignId").IsEqual(Column.Parameter(analyticsRequest.CampaignId))
				.And("cp", "StatusId")
					.IsNotEqual(Column.Parameter(CampaignConstants.CampaignParticipantInProgressStatusId))
				.GroupBy("cp", "CampaignItemId")
				.GroupBy("cp", "StatusId")
				.GroupBy("cp", "StepCompleted") as Select;
			select.SpecifyNoLockHints();
			if (analyticsRequest.UseTimeFilters) {
				AddTimeFilters(ref select, analyticsRequest.FilterStartDate, analyticsRequest.FilterDueDate);
			}
			return select;
		}

		private Select GetParticipantsInQueueSelect(ParticipantsAnalyticsRequest analyticsRequest) {
			var addModifyRecordsSelect = new Select(UserConnection)
				.Column("cp", "CampaignItemId")
				.Column(Column.Parameter(null, "Boolean")).As("StepCompleted")
				.Column(Column.Parameter(CampaignConstants.CampaignParticipantInProgressStatusId)).As("StatusId")
				.Column(Func.Count("cp", "CampaignItemId")).As("Count")
				.From("CampaignParticipant").As("cp")
				.InnerJoin("CampaignQueue").As("q").On("cp", "Id").IsEqual("q", "CampaignParticipantId")
				.Where("cp", "CampaignId").IsEqual(Column.Parameter(analyticsRequest.CampaignId))
				.And("cp", "StatusId")
					.IsEqual(Column.Parameter(CampaignConstants.CampaignParticipantInProgressStatusId))
				.GroupBy("cp", "CampaignItemId")
				.GroupBy("cp", "StatusId")
				.GroupBy("cp", "StepCompleted") as Select;
			var signalRecordsSelect = new Select(UserConnection)
				.Column("q", "CampaignItemId")
				.Column(Column.Parameter(null, "Boolean")).As("StepCompleted")
				.Column(Column.Parameter(CampaignConstants.CampaignParticipantInProgressStatusId)).As("StatusId")
				.Column(Func.Count("q", "CampaignItemId")).As("Count")
				.From("CampaignQueue").As("q")
				.InnerJoin("CampaignItem").As("ci").On("ci", "Id").IsEqual("q", "CampaignItemId")
				.Where("ci", "CampaignId").IsEqual(Column.Parameter(analyticsRequest.CampaignId))
				.GroupBy("q", "CampaignItemId") as Select;
			if (analyticsRequest.UseTimeFilters) {
				AddTimeFilters(ref addModifyRecordsSelect, analyticsRequest.FilterStartDate,
					analyticsRequest.FilterDueDate);
				AddTimeFilters(ref signalRecordsSelect, analyticsRequest.FilterStartDate,
					analyticsRequest.FilterDueDate);
			}
			var select = addModifyRecordsSelect.Union(signalRecordsSelect) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		private Select GetOpParticipantsAnalyticsSelect(ParticipantsAnalyticsRequest analyticsRequest) {
			var select = new Select(UserConnection)
				.Column("cp", "CampaignItemId")
				.Column(Column.Parameter(null, "Boolean")).As("StepCompleted")
				.Column(Column.Parameter(CampaignConstants.CampaignParticipantInProgressStatusId)).As("StatusId")
				.Column(Func.Count("cp", "CampaignItemId")).As("Count")
				.From("CampaignParticipantOp").As("cp")
				.Where("cp", "CampaignId").IsEqual(Column.Parameter(analyticsRequest.CampaignId))
				.And("cp", "IsReadyToSync").IsEqual(Column.Parameter(true))
				.GroupBy("cp", "CampaignItemId") as Select;
			select.SpecifyNoLockHints();
			if (analyticsRequest.UseTimeFilters) {
				AddTimeFilters(ref select, analyticsRequest.FilterStartDate, analyticsRequest.FilterDueDate);
			}
			return select;
		}

		private Select GetHistoryAnalyticsSelect(ParticipantsAnalyticsRequest analyticsRequest) {
			var select = new Select(UserConnection)
				.Column("ci", "Id").As("CampaignItemId")
				.Column(Column.Parameter(null, "Boolean")).As("StepCompleted")
				.Column(Column.Parameter(HistoryStatusId)).As("StatusId")
				.Column(Func.Sum("cl", "Amount")).As("Count")
				.From("CampaignLog").As("cl")
				.InnerJoin("CampaignItem").As("ci").On("ci", "Id").IsEqual("cl", "CampaignItemId")
				.Where("cl", "CampaignId").IsEqual(Column.Parameter(analyticsRequest.CampaignId))
				.And("ci", "IsDeleted").IsEqual(Column.Parameter(false))
				.And("ci", "CampaignElementType").Not().IsLike(Column.Parameter("Transition%"))
				.And().OpenBlock()
				.OpenBlock("cl", "ActionId").IsNotEqual(Column.Parameter(CampaignConsts.CampaignLogTypeUpdateObject))
				.And("cl", "ActionId").IsNotEqual(Column.Parameter(CampaignConsts.CampaignLogTypeAddObject))
				.CloseBlock()
				.Or("cl", "SessionId").Not().IsNull()
				.CloseBlock()
				.And("cl", "ActionId").IsNotEqual(Column.Parameter(CampaignConsts.CampaignLogTypeMoveAudience))
				.GroupBy("ci", "Id") as Select;
			select.SpecifyNoLockHints();
			if (analyticsRequest.UseTimeFilters) {
				AddTimeFilters(ref select, analyticsRequest.FilterStartDate, analyticsRequest.FilterDueDate);
			}
			return select;
		}

		private Select GetArchivedHistoryAnalyticsSelect(ParticipantsAnalyticsRequest analyticsRequest) {
			var select = new Select(UserConnection)
				.Column("cal", "CampaignItemId").As("CampaignItemId")
				.Column(Column.Parameter(null, "Boolean")).As("StepCompleted")
				.Column(Column.Parameter(HistoryStatusId)).As("StatusId")
				.Column(Func.Sum("cal", "Amount")).As("Count")
				.From("CampaignAnalyticsLog").As("cal")
				.Where("cal", "CampaignId").IsEqual(Column.Parameter(analyticsRequest.CampaignId))
				.GroupBy("cal", "CampaignItemId") as Select;
			if (analyticsRequest.UseTimeFilters) {
				select
					.And("cal", "Date").IsGreaterOrEqual(Column.Parameter(analyticsRequest.FilterStartDate))
					.And("cal", "Date").IsLessOrEqual(Column.Parameter(analyticsRequest.FilterDueDate));
			}
			return select;
		}

			private void SetParticipantsCountValue(ref Dictionary<Guid, ParticipantsAnalyticsItem> items, Guid itemId,
				Guid statusId, bool isStepCompleted, int count) {
			if (!items.TryGetValue(itemId, out var existingItem)) {
				existingItem = new ParticipantsAnalyticsItem {
					ItemId = itemId
				};
				items[itemId] = existingItem;
			}
			if (statusId == HistoryStatusId) {
				existingItem.HistoryParticipantsCount += count;
			} else if (statusId == CampaignConstants.CampaignParticipantErrorStatusId) {
				existingItem.ErrorParticipantsCount += count;
			} else if (statusId == CampaignConstants.CampaignParticipantInProgressStatusId) {
				existingItem.ProcessingParticipantsCount += count;
			} else if (statusId == CampaignConstants.CampaignParticipantSuspendedStatusId
					|| statusId == CampaignConstants.CampaignParticipantSuspendingStatusId) {
				existingItem.SuspendedParticipantsCount += count;
			} else if (isStepCompleted) {
				existingItem.CompletedParticipantsCount += count;
			} else {
				existingItem.NonCompletedParticipantsCount += count;
			}
		}

		private void FillParticipantsAnalyticsItems(Dictionary<Guid, ParticipantsAnalyticsItem> analyticsItems,
				Select analyticsSelect) {
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection(QueryKind.Limited)) {
				analyticsSelect.ExecuteReader((IDataReader reader) => {
					var itemId = reader.GetColumnValue<Guid>("CampaignItemId");
					var statusId = reader.GetColumnValue<Guid>("statusId");
					var isStepCompleted = reader.GetColumnValue<bool>("StepCompleted");
					var count = reader.GetColumnValue<int>("Count");
					SetParticipantsCountValue(ref analyticsItems, itemId, statusId, isStepCompleted, count);
				});
			}
		}

		/// <summary>
		/// Swaps <see cref="ParticipantsAnalyticsRequest.FilterStartDate"/> and 
		/// <see cref="ParticipantsAnalyticsRequest.FilterDueDate"/>
		/// when first greater than second.
		/// </summary>
		/// <param name="request">Instance of <see cref="ParticipantsAnalyticsRequest"/>.</param>
		private void NormalizeFilterDatesOrder(ref ParticipantsAnalyticsRequest request) {
			if (request.FilterStartDate > request.FilterDueDate) {
				var tmpStartDate = request.FilterStartDate;
				request.FilterStartDate = request.FilterDueDate;
				request.FilterDueDate = tmpStartDate;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Calculates campaign participant analytics by <paramref name="analyticsRequest"/>.
		/// Calculates participants count with completed and non completed flags for each campaign item.
		/// </summary>
		/// <param name="analyticsRequest">Instance of <see cref="ParticipantsAnalyticsRequest"/>.
		/// Contains parameters for calculate analytics.</param>
		/// <returns>Returns <see cref="ParticipantsAnalyticsResponse"/> instance.</returns>
		public ParticipantsAnalyticsResponse GetParticipantsAnalytics(ParticipantsAnalyticsRequest analyticsRequest) {
			var response = new ParticipantsAnalyticsResponse {
				CampaignId = analyticsRequest.CampaignId
			};
			NormalizeFilterDatesOrder(ref analyticsRequest);
			var analyticsSelect = GetParticipantsAnalyticsSelect(analyticsRequest);
			var queueAnalyticsSelect = GetParticipantsInQueueSelect(analyticsRequest);
			var operationalAnalyticsSelect = GetOpParticipantsAnalyticsSelect(analyticsRequest);
			var analyticsItems = new Dictionary<Guid, ParticipantsAnalyticsItem>();
			FillParticipantsAnalyticsItems(analyticsItems, analyticsSelect);
			FillParticipantsAnalyticsItems(analyticsItems, queueAnalyticsSelect);
			FillParticipantsAnalyticsItems(analyticsItems, operationalAnalyticsSelect);
			if (analyticsRequest.UseHistoryData) {
				var historySelect = GetHistoryAnalyticsSelect(analyticsRequest);
				FillParticipantsAnalyticsItems(analyticsItems, historySelect);
				historySelect = GetArchivedHistoryAnalyticsSelect(analyticsRequest);
				FillParticipantsAnalyticsItems(analyticsItems, historySelect);
			}
			response.AnalyticsItems = analyticsItems.Values;
			return response;
		}

		#endregion

	}

	#endregion

}
