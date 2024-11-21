
namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Threading.Tasks;
	using BPMSoft.Common;
	using BPMSoft.Core.Attributes;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.EventHandler;
	using BPMSoft.Core.DB;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	/// <summary>
	/// Contains methods for maintaining Exclude Audience elements in campaign.
	/// </summary>
	public sealed class ExcludeCampaignAudienceElementHandler : BaseCampaignAudienceElementHandler,
		IOnCampaignValidate, IOnCampaignExecutionTerminate, IOnCampaignStop
	{

		#region Constants: Private

		private const string CampaignParticipantTableName = nameof(CampaignParticipant);

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="ExcludeCampaignAudienceElementHandler"/>.
		/// </summary>
		public ExcludeCampaignAudienceElementHandler() {
			elementHandlerName = GetType().Name;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// Flag based on CampaignBatchQueries feature state.
		/// </summary>
		private bool UseCampaignBatchedQueries => UserConnection.GetIsFeatureEnabled("CampaignBatchedQueries");

		/// <summary>
		/// Size of a single batch to split queries while using CampaignBatchedQueries feature.
		/// </summary>
		private int _campaignElementAudienceQueryBatchSize = int.MinValue;
		private int CampaignElementAudienceQueryBatchSize {
			get {
				if (_campaignElementAudienceQueryBatchSize < 0) {
					var value = Core.Configuration.SysSettings.GetValue(UserConnection,
						"CampaignElementAudienceQueryBatchSize", 500);
					_campaignElementAudienceQueryBatchSize = Math.Max(value, 0);
				}
				return _campaignElementAudienceQueryBatchSize;
			}
		}

		#endregion

		#region Methods: Private

		private IEnumerable<Guid> GetParticipantStatusesToUpdate(bool isCampaignGoal) => isCampaignGoal
			? new [] {
				CampaignConstants.CampaignParticipantParticipatingStatusId,
				CampaignConstants.CampaignParticipantExitedStatusId
			}
			: new [] {
				CampaignConstants.CampaignParticipantParticipatingStatusId,
				CampaignConstants.CampaignParticipantReachedGoalStatusId
			};

		private Guid GetParticipantStatusToSet(bool isCampaignGoal) => isCampaignGoal
			? CampaignConstants.CampaignParticipantReachedGoalStatusId
			: CampaignConstants.CampaignParticipantExitedStatusId;

		private Select GetParticipantIdsToUpdateSelectQuery(ExitFromCampaignElement element) {
			var statusesToUpdate = GetParticipantStatusesToUpdate(element.IsCampaignGoal);
			var select = new Select(UserConnection)
					.Column("Id")
				.From(CampaignParticipantTableName)
				.Where("CampaignId").IsEqual(Column.Parameter(CampaignSchema.EntityId))
					.And("CampaignItemId").IsEqual(Column.Parameter(element.UId))
					.And("StepCompleted").IsEqual(Column.Parameter(true))
					.And("StatusId").In(Column.Parameters(statusesToUpdate)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		private Update GetBaseUpdateParticipantStatusesForItemQuery(ExitFromCampaignElement element) {
			var statusIdToSet = GetParticipantStatusToSet(element.IsCampaignGoal);
			var update =
				new Update(UserConnection, CampaignParticipantTableName)
					.Set("StatusId", Column.Parameter(statusIdToSet))
					.Set("StepModifiedOn", Column.Parameter(DateTime.UtcNow));
			update.WithHints(new RowLockHint());
			return update;
		}

		private void UpdateParticipantStatusesForItem(ExitFromCampaignElement element) {
			var update = GetBaseUpdateParticipantStatusesForItemQuery(element);
			var statusesToUpdate = GetParticipantStatusesToUpdate(element.IsCampaignGoal);
			update.Where("CampaignId").IsEqual(Column.Parameter(CampaignSchema.EntityId))
				.And("CampaignItemId").IsEqual(Column.Parameter(element.UId))
				.And("StepCompleted").IsEqual(Column.Parameter(true))
				.And("StatusId").In(Column.Parameters(statusesToUpdate));
			update.Execute();
		}

		private void BatchedUpdateParticipantStatusesForItem(ExitFromCampaignElement element) {
			var participantsSelect = GetParticipantIdsToUpdateSelectQuery(element);
			var participantsCollection = participantsSelect
				.ExecuteEnumerable(r => r.GetColumnValue<Guid>("Id")).ToList();
			int participantsCount = participantsCollection.Count;
			int batchSize = CampaignElementAudienceQueryBatchSize;
			int processedCount = 0;
			while (processedCount < participantsCount) {
				var participantsBatch = participantsCollection.Skip(processedCount).Take(batchSize);
				var updateQuery = GetBaseUpdateParticipantStatusesForItemQuery(element);
				updateQuery.Where("Id").In(Column.Parameters(participantsBatch));
				updateQuery.Execute();
				processedCount += batchSize;
				Task.Delay(10).Wait();
			}
		}

		private void ActualizeParticipantStatusesForItem(ExitFromCampaignElement element) {
			if (UseCampaignBatchedQueries) {
				BatchedUpdateParticipantStatusesForItem(element);
			} else {
				UpdateParticipantStatusesForItem(element);
			}
		}

		private void ActualizeParticipantStatuses() {
			var elements = GetAudienceElements(CampaignSchema);
			elements.ForEach(x => {
				if (x is ExitFromCampaignElement exitElement) {
					ActualizeParticipantStatusesForItem(exitElement);
				}
			});
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns the list of <see cref="ExitFromCampaignElement"/> campaign audience elements.
		/// </summary>
		/// <param name="schema">Campaign schema instance.</param>
		/// <returns>List of concrete campaign audience elements.</returns>
		protected override IEnumerable<BaseCampaignAudienceElement> GetAudienceElements(CoreCampaignSchema schema) {
			return schema.FlowElements.OfType<ExitFromCampaignElement>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates Exclude Audience elements on campaign validation. Searches folders with no conditions.
		/// </summary>
		public void OnValidate() {
			try {
				var elements = GetAudienceElements(CampaignSchema);
				var elementsWithFolder = elements.Where(x => !x.FolderId.IsEmpty());
				if (!elementsWithFolder.Any()) {
					return;
				}
				var folders = LoadFoldersInfo(elementsWithFolder);
				CheckFoldersExistense(elementsWithFolder, folders);
				var foldersWithNoFilter = FindFoldersWithNoFilter(folders);
				string message = GetLczStringValue(elementHandlerName, "FolderWithNoConditionError");
				WriteValidationInfo(elements, foldersWithNoFilter, message, CampaignValidationInfoLevel.Error);
			} catch (Exception ex) {
				string message = GetLczStringValue(elementHandlerName, "OnValidateException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Contains logic for exclude audience elements on campaign execution terminate.
		/// Actualizes campaign participants' statuses for audience on exclude from campaign items.
		/// If actualized participants are found updates campaign reached the goal counter.
		/// </summary>
		[Order(1)]
		public void OnExecutionTerminate() {
			try {
				ActualizeParticipantStatuses();
			} catch (Exception ex) {
				string message = GetLczStringValue(elementHandlerName, "OnExecutionTerminateException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Contains logic for exclude audience elements on campaign stop.
		/// Actualizes campaign participants' statuses for audience on exclude from campaign items.
		/// If actualized participants are found updates campaign reached the goal counter.
		/// </summary>
		public void OnStop() {
			try {
				ActualizeParticipantStatuses();
			} catch (Exception ex) {
				string message = GetLczStringValue(elementHandlerName, "OnStopException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		#endregion

	}
}

