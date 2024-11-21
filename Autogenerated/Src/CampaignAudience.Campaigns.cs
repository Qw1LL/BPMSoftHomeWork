namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Configuration.Campaigns;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;

	#region Class: CampaignAudience

	/// <summary>
	/// Campaign audience store
	/// </summary>
	public sealed class CampaignAudience : BaseCampaignAudience
	{

		#region Constructors: Public

		/// <summary>
		/// Campaign audience constructor.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="campaignId">Unique ID of the campaign.</param>
		public CampaignAudience(UserConnection userConnection, Guid campaignId)
				: base(userConnection, campaignId) {
			CampaignParticipantTableName = "CampaignParticipant";
		}

		public CampaignAudience(CampaignAudienceConfig config)
				: this(config.UserConnection, config.CampaignId) {
			CampaignScheduledDate = config.CampaignScheduledDate;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// The scheduled <see cref="DateTime"/> of the current campaign job.
		/// </summary>
		private DateTime? _campaignScheduledDate;
		public DateTime? CampaignScheduledDate {
			get => _campaignScheduledDate ?? DateTime.UtcNow;
			set => _campaignScheduledDate = value;
		}

		#endregion

		#region Methods: Private

		private Select GetExistingAudienceSelect() {
			var select =
				new Select(UserConnection)
					.Column(CampaignParticipantTableName, "ContactId")
					.From(CampaignParticipantTableName)
					.Where(CampaignParticipantTableName, "CampaignId").IsEqual(Column.Parameter(CampaignId)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		private Select ExcludeExistingContacts(Select audienceSelect, string contactIdColumn) {
			Select existingSelect = GetExistingAudienceSelect();
			var schemaName = audienceSelect.SourceExpression.SchemaName;
			if (audienceSelect.HasCondition) {
				audienceSelect.And(schemaName, contactIdColumn).Not().In(existingSelect);
			} else {
				audienceSelect.Where(schemaName, contactIdColumn).Not().In(existingSelect);
			}
			return audienceSelect;
		}

		private void AddColumnsToInsertQuery(Select audienceSelect, Guid campaignItemId, string contactIdColumn) {
			audienceSelect.Columns.Clear();
			var schemaName = audienceSelect.SourceExpression.SchemaName;
			audienceSelect.Column(schemaName, contactIdColumn).As("ContactId");
			audienceSelect.Column(Column.Parameter(CampaignId)).As("CampaignId");
			audienceSelect.Column(Column.Parameter(campaignItemId)).As("CampaignItemId");
			audienceSelect.Column(Column.Parameter(DateTime.UtcNow)).As("StepModifiedOn");
			audienceSelect.Column(Column.Parameter(CampaignScheduledDate)).As("StepCompletedOn");
			audienceSelect.Column(Column.Parameter(
				CampaignConstants.CampaignParticipantParticipatingStatusId)).As("StatusId");
			audienceSelect.Column(Column.Parameter(true)).As("StepCompleted");
		}

		private Select PrepareSelectForAdd(Select audienceSelect, Guid addingCampaignItemId,
				string contactIdColumn) {
			Select workSelect = ExcludeExistingContacts(audienceSelect, contactIdColumn);
			AddColumnsToInsertQuery(workSelect, addingCampaignItemId, contactIdColumn);
			return workSelect;
		}

		private int AddParticipantsFromSelect(Select select, Guid campaignItemId, string contactIdColumn) {
			if (select == null) {
				return 0;
			}
			Select audienceSelect = PrepareSelectForAdd(select, campaignItemId, contactIdColumn);
			InsertSelect audienceInsert = new InsertSelect(UserConnection).Into(CampaignParticipantTableName)
				.Set("ContactId", "CampaignId", "CampaignItemId", "StepModifiedOn",
					"StepCompletedOn", "StatusId", "StepCompleted")
				.FromSelect(audienceSelect);
			return audienceInsert.Execute();
		}

		private Select AddConditionByContactId(Select folderSelect, string contactIdColumn) {
			var schemaName = folderSelect.SourceExpression.SchemaName;
			if (folderSelect.HasCondition) {
				folderSelect.And(schemaName, contactIdColumn).IsEqual(CampaignParticipantTableName, "ContactId");
			} else {
				folderSelect.Where(schemaName, contactIdColumn).IsEqual(CampaignParticipantTableName, "ContactId");
			}
			return folderSelect;
		}

		private Update GetBaseExcludeAudienceUpdate(Guid campaignItemId,
				Guid participantStatusId, Select audienceSelect) {
			var update =
				new Update(UserConnection, CampaignParticipantTableName)
					.Set("CampaignItemId", Column.Parameter(campaignItemId))
					.Set("StatusId", Column.Parameter(participantStatusId))
					.Set("StepModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Set("StepCompleted", Column.Parameter(false))
					.Where(CampaignParticipantTableName, "CampaignId")
						.IsEqual(Column.Parameter(CampaignId))
					.And(CampaignParticipantTableName, "CampaignItemId")
						.IsNotEqual(Column.Parameter(campaignItemId))
					.And().Exists(audienceSelect) as Update;
			update.WithHints(new RowLockHint());
			AddStatusIdCondition(update, participantStatusId);
			return update;
		}

		private void AddStatusIdCondition(Update audienceUpdate, Guid participantStatusId) {
			if (participantStatusId == CampaignConstants.CampaignParticipantReachedGoalStatusId) {
				audienceUpdate
					.And(CampaignParticipantTableName, "StatusId")
						.In(Column.Parameters(new[] {
							CampaignConstants.CampaignParticipantParticipatingStatusId,
							CampaignConstants.CampaignParticipantExitedStatusId
						}));
			} else {
				audienceUpdate.And(CampaignParticipantTableName, "StatusId")
					.IsEqual(Column.Parameter(CampaignConstants.CampaignParticipantParticipatingStatusId));
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adding audience to campaign from query.
		/// Select should contains Id column.
		/// </summary>
		/// <param name="select">Insertion audience query.</param>
		/// <param name="campaignItemId">Unique identifier of the campaign step item.</param>
		/// <param name="contactIdColumn">Name of column with identifier of the contact.</param>
		/// <returns>Count of added participants.</returns>
		public override int Add(Select select, Guid campaignItemId, string contactIdColumn) {
			return AddParticipantsFromSelect(select, campaignItemId, contactIdColumn);
		}

		public override void Add(IEnumerable<Guid> contacts, Guid campaignItemId) {
			throw new NotSupportedException();
		}

		/// <summary>
		/// Excluding audience from campaign.
		/// Select should contains Id column.
		/// </summary>
		/// <param name="select">Query for gets updating audience.</param>
		/// <param name="campaignItemId">Unique identifier of the campaign step item.</param>
		/// <returns>Count of excluded participants.</returns>
		public override int Exclude(Select select, Guid campaignItemId) {
			return Exclude(select, campaignItemId, CampaignConstants.CampaignParticipantExitedStatusId);
		}

		/// <summary>
		/// Excludes campaign audience with update of participants' status to specified.
		/// Select should contains Id column.
		/// </summary>
		/// <param name="select">Query for gets updating audience.</param>
		/// <param name="campaignItemId">Unique identifier of the campaign step item.</param>
		/// <param name="participantStatusId">Unique identifier of the campaign participant status to set.</param>
		/// <returns>Count of excluded participants.</returns>
		public override int Exclude(Select select, Guid campaignItemId, Guid participantStatusId) {
			var contactIdColumn = select.SourceExpression.SchemaName == "Contact" ? "Id" : "ContactId";
			Select audienceSelect = AddConditionByContactId(select, contactIdColumn);
			var audienceUpdate = GetBaseExcludeAudienceUpdate(campaignItemId, participantStatusId, audienceSelect);
			return audienceUpdate.Execute();
		}

		/// <summary>
		/// Gets campaign audience with not completed sign filtered by campaign step.
		/// </summary>
		/// <param name="itemId">Unique identifier of the campaign step.</param>
		/// <returns>Instance of <see cref="Select"/>.</returns>
		public override Select GetAudienceByItemSelect(Guid itemId) {
			var select = new Select(UserConnection)
				.Column(CampaignParticipantTableName, "ContactId").As("ContactId")
				.From(CampaignParticipantTableName)
				.Where(CampaignParticipantTableName, "CampaignId").IsEqual(Column.Parameter(CampaignId))
				.And(CampaignParticipantTableName, "CampaignItemId").IsEqual(Column.Parameter(itemId))
				.And(CampaignParticipantTableName, "StatusId")
					.IsEqual(Column.Parameter(CampaignConstants.CampaignParticipantParticipatingStatusId))
				.And(CampaignParticipantTableName, "StepCompleted").IsEqual(Column.Const(false)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		/// <summary>
		/// Sets the flag StepCompleted to true for a specified participants at the campaign step.
		/// </summary>
		/// <param name="campaignStepId">Unique identifier of the campaign step.</param>
		/// <param name="contactSelect">Query returns a list of contactId to filter an audience for update.</param>
		/// <returns>Count of updated participants.</returns>
		public override int SetItemCompleted(Guid campaignStepId, Select contactSelect) {
			var audienceUpdate = GetItemCompletedUpdate(campaignStepId);
			audienceUpdate.And(CampaignParticipantTableName, "ContactId").In(contactSelect);
			return audienceUpdate.Execute();
		}

		/// <summary>
		/// Increases total participants count of campaign by adding new participants' count
		/// to current value of campaign's TargetTotal column.
		/// </summary>
		/// <param name="addedParticipantsCount">Count of new campaign participants which were added to campaign.</param>
		public override void IncreaseCampaignParticipantsCount(int addedParticipantsCount) {
			var update = new Update(UserConnection, "Campaign")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
				.Set("TargetTotal",
					QueryColumnExpression.Add(new QueryColumnExpression("TargetTotal"),
						Column.Parameter(addedParticipantsCount)))
				.Where("Id").IsEqual(Column.Parameter(CampaignId)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		#endregion

	}

	#endregion

}

