namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Configuration.CampaignElements;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: AddCampaignAudienceElement

	/// <summary>
	/// Executable campaign element which adds contacts to campaign audience.
	/// </summary>
	public class AddCampaignAudienceElement : BaseCampaignAudienceFlowElement
	{

		#region Properties: Private

		/// <summary>
		/// Size of a single batch to split queries while using CampaignBatchedQueries feature.
		/// </summary>
		private int _campaignElementAudienceQueryBatchSize = int.MinValue;
		private int CampaignElementAudienceQueryBatchSize {
			get {
				if (_campaignElementAudienceQueryBatchSize < 0) {
					var value = Core.Configuration.SysSettings.GetValue(UserConnection,
						"CampaignElementAudienceQueryBatchSize", SafeQueryBatchSize);
					_campaignElementAudienceQueryBatchSize = Math.Max(value, 0);
				}
				return _campaignElementAudienceQueryBatchSize;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Root folder schema name.
		/// </summary>
		public string FolderSchemaName => AudienceEntitySchemaName + "Folder";

		/// <summary>
		/// Entity schema name which contacts will be imported from.
		/// </summary>
		public string AudienceEntitySchemaName { get; set; }

		/// <summary>
		/// Column path for the imported entity.
		/// </summary>
		public string AudienceEntityContactPath { get; set; }

		/// <summary>
		/// Entity schema id which contacts will be imported from.
		/// </summary>
		public Guid AudienceEntityId { get; set; }

		/// <summary>
		/// Defines if element can do recurring add from folder.
		/// </summary>
		public bool IsRecurring { get; set; }

		/// <summary>
		/// Number of days before participant will be added next time.
		/// </summary>
		public int RecurringFrequencyInDays { get; set; }

		/// <summary>
		/// Flag to indicate that import is by filter.
		/// </summary>
		public bool HasFilter { get; set; }

		/// <summary>
		/// Filter to import audience.
		/// </summary>
		public string Filter { get; set; }

		/// <summary>
		/// Unique identifier of the folder.
		/// </summary>
		public Guid FolderRecordId { get; set; }

		private FolderHelper _folderHelper;

		/// <summary>
		/// An instance of the <see cref="FolderHelper"/>. Is using for Mock purposes.
		/// </summary>
		public FolderHelper FolderHelper {
			get => _folderHelper ?? (_folderHelper = new FolderHelper());
			set => _folderHelper = value;
		}

		#endregion

		#region Methods: Private

		private Select GetCurrentItemRecurringContactIdsSelect(Guid campaignItemId, int recurringFrequency) {
			var selectCurrentContacts = new Select(UserConnection)
				.Distinct()
				.Column("ContactId")
				.From("CampaignParticipant")
				.Where("CampaignItemId").IsEqual(Column.Parameter(campaignItemId))
					.And("CreatedOn").IsGreater(Column.Parameter(DateTime.UtcNow.AddDays(-recurringFrequency)))
				as Select;
			selectCurrentContacts.SpecifyNoLockHints();
			return selectCurrentContacts;
		}

		private void AddSuspendingQueryConditions(Query suspendingQuery, Select currentAddAudienceSelect,
				Guid[] currentParticipantsStatuses, int recurringFrequency) {
			suspendingQuery
				.Where("CampaignId").IsEqual(Column.Parameter(CampaignId))
					.And("StatusId").In(Column.Parameters(currentParticipantsStatuses))
					.And("CreatedOn").IsLess(Column.Parameter(DateTime.UtcNow.AddDays(-recurringFrequency)))
					.And("ContactId").In(currentAddAudienceSelect);
		}

		private void SuspendingParticipants(Select currentAddAudienceSelect, Guid[] currentParticipantsStatuses,
				Guid newParticipantsStatus, int recurringFrequency) {
			var campaignParticipantsSelect = new Select(UserConnection)
				.Column("Id")
				.From(CampaignParticipantTable);
			AddSuspendingQueryConditions(campaignParticipantsSelect, currentAddAudienceSelect,
				currentParticipantsStatuses, recurringFrequency);
			campaignParticipantsSelect.SpecifyNoLockHints();
			var campaignParticipantIds = campaignParticipantsSelect
				.ExecuteEnumerable(r => r.GetColumnValue<Guid>("Id")).ToList();
			int participantsCount = campaignParticipantIds.Count;
			int batchSize = CampaignElementAudienceQueryBatchSize;
			int processedCount = 0;
			while (processedCount < participantsCount) {
				var batch = campaignParticipantIds.GetRange(processedCount,
					Math.Min(batchSize, campaignParticipantIds.Count - processedCount));
				if (batch.Count == 0) {
					break;
				}
				var updateToSuspendingStatus = new Update(UserConnection, CampaignParticipantTable)
					.Set("StatusId", Column.Parameter(newParticipantsStatus))
					.Where("Id").In(Column.Parameters(batch)) as Update;
				updateToSuspendingStatus.WithHints(new RowLockHint());
				updateToSuspendingStatus.Execute();
				processedCount += batchSize;
			}
		}

		private Select GetLinkedAudienceFromContactsSelect(Select folderSelect) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(AudienceEntitySchemaName);
			var esq = new EntitySchemaQuery(entitySchema);
			esq.AddColumn("Id").SetForcedQueryColumnValueAlias("LinkedEntityId");
			esq.AddColumn(AudienceEntityContactPath).SetForcedQueryColumnValueAlias("ContactId");
			esq.IsDistinct = true;
			var isNotNullContactFilter = esq.CreateIsNotNullFilter(AudienceEntityContactPath);
			esq.Filters.Add(isNotNullContactFilter);
			var contactSelect = esq.GetSelectQuery(UserConnection);
			var linkedEntityIdColumn = contactSelect.Columns.FindByAlias("LinkedEntityId");
			var contactIdColumn =  contactSelect.Columns.FindByAlias("ContactId");
			contactSelect.InnerJoin(folderSelect).As("FolderSelect")
				.On("FolderSelect", "LinkedEntityId").IsEqual(linkedEntityIdColumn);
			contactSelect.Column(new WindowQueryFunction(new RowNumberQueryFunction(),
				contactIdColumn, new QueryColumnExpression(entitySchema.Name, "CreatedOn"),
				OrderDirection.Descending)).As("RowNum");
			var uniqueContactsSelect = new Select(UserConnection)
				.Column("LinkedContactsSelect", "LinkedEntityId").As("LinkedEntityId")
				.Column("LinkedContactsSelect", "ContactId").As("ContactId")
				.From(contactSelect).As("LinkedContactsSelect")
				.Where("LinkedContactsSelect", "RowNum").IsEqual(Column.Parameter(1)) as Select;
			uniqueContactsSelect.SpecifyNoLockHints();
			return uniqueContactsSelect;
		}

		private void LinkParticipantsWithEntities(Query audienceQuery) {
			if (AudienceEntitySchemaName == "Contact") {
				return;
			}
			AddParticipantsInfo(audienceQuery as Select);
		}

		private Select GetFolderSelect() {
			Select folderSelect = FolderHelper.GetFolderSelectV2(AudienceEntitySchemaName, FolderSchemaName,
				FolderRecordId, UserConnection);
			if (folderSelect != null) {
				return folderSelect;
			}
			string errorMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
				"AddCampaignAudienceElement", "LocalizableStrings.DeletedContactFolderMessage.Value");
			throw new CampaignElementBrokenDataException(string.Format(errorMessage, Caption ?? Name));
		}

		private Select GetFilterSelect() {
			if (string.IsNullOrWhiteSpace(Filter)) {
				string errorMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"AddCampaignAudienceElement", "LocalizableStrings.BrokenFilterMessage.Value");
				throw new CampaignElementBrokenDataException(string.Format(errorMessage, Caption ?? Name));
			}
			var searchData = Encoding.UTF8.GetBytes(Filter);
			if (!FolderHelper.CheckSearchDataHasFilter(AudienceEntitySchemaName, searchData, UserConnection)) {
				return null;
			}
			var esq = FolderHelper.GetDynamicFolderESQ(AudienceEntitySchemaName, searchData, UserConnection);
			if (esq == null) {
				return null;
			}
			esq.UseAdminRights = false;
			return esq.GetSelectQuery(UserConnection);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns <see cref="Select"/> of contacts by folder or filter
		/// which represents contact ids to add in campaign.
		/// </summary>
		/// <returns>Select of contact ids.</returns>
		protected override Select GetContactsSelect() {
			var contactSelect = HasFilter
				? GetFilterSelect()
				: GetFolderSelect();
			if (contactSelect == null) {
				return null;
			}
			if (AudienceEntitySchemaName != "Contact") {
				SourceSelectContactIdColumnName = "Id";
				contactSelect.Columns.First().Alias = "LinkedEntityId";
				return GetLinkedAudienceFromContactsSelect(contactSelect);
			}
			SourceSelectContactIdColumnName = contactSelect.SourceExpression.SchemaName == "Contact"
				? "Id"
				: "ContactId";
			return contactSelect;
		}

		/// <summary>
		/// Builds <see cref="Select"/> which represents contact ids of campaign participants
		/// which still exist in campaign.
		/// Add more conditions for Select query when <see cref="IsRecurring"/> is <see cref="true"/>.
		/// </summary>
		/// <returns>Select of contact ids.</returns>
		protected override Select GetExistingAudienceSelect() {
			var select = base.GetExistingAudienceSelect();
			if (RecurringFrequencyInDays > 0 && IsRecurring) {
				select.And("CreatedOn")
					.IsGreaterOrEqual(Column.Parameter(DateTime.UtcNow.AddDays(-RecurringFrequencyInDays)));
			}
			select.SpecifyNoLockHints();
			return select;
		}

		/// <summary>
		/// Suspending duplicated participants in campaign participants.
		/// </summary>
		protected virtual void SuspendingParticipants() {
			var currentAddAudienceSelect = GetCurrentItemRecurringContactIdsSelect(CampaignItemId, 
				RecurringFrequencyInDays);
			SuspendingParticipants(currentAddAudienceSelect,
				new[] {
					CampaignConstants.CampaignParticipantParticipatingStatusId,
					CampaignConstants.CampaignParticipantExitedStatusId,
					CampaignConstants.CampaignParticipantReachedGoalStatusId,
					CampaignConstants.CampaignParticipantErrorStatusId
				},
				CampaignConstants.CampaignParticipantSuspendedStatusId, RecurringFrequencyInDays);
			SuspendingParticipants(currentAddAudienceSelect,
				new[] {
					CampaignConstants.CampaignParticipantInProgressStatusId
				},
				CampaignConstants.CampaignParticipantSuspendingStatusId, RecurringFrequencyInDays);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes current flow element for selected audience.
		/// </summary>
		/// <param name="audienceQuery">Query for item audience to be processed.</param>
		/// <returns>Number of processed participants.</returns>
		protected override int SingleExecute(Query audienceQuery) {
			if (audienceQuery == null
				|| (AudienceEntitySchemaName != "Contact"
				&& !UserConnection.GetIsFeatureEnabled("CampaignAudienceImport"))) {
				return 0;
			}
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				try {
					var processedAmount = AddParticipants(audienceQuery);
					if (processedAmount > 0 && IsRecurring) {
						SuspendingParticipants();
					}
					LinkParticipantsWithEntities(audienceQuery);
					dbExecutor.CommitTransaction();
					return processedAmount;
				} catch {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
		}

		#endregion

	}

	#endregion

}

