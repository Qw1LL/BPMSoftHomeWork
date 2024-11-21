namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;

	#region Class: BaseCampaignAudienceFlowElement

	/// <summary>
	/// Base campaign flow element which contains logic for add contacts to campaign audience.
	/// </summary>
	public abstract class BaseCampaignAudienceFlowElement : CampaignFlowElement
	{

		#region Properties: Public

		/// <summary>
		/// SysSchema.UId of current element audience.
		/// </summary>
		public Guid AudienceSchemaUId { get; set; }

		#endregion

		#region Methods: Private

		private Select GetSelectExceptExistingContacts(Select audienceSelect) {
			Select existingSelect;
			var schemaName = audienceSelect.SourceExpression.SchemaName;
			if (schemaName == "Contact") {
				var contactIdColumn = SourceSelectContactIdColumnName;
				existingSelect = GetExistingAudienceSelect()
					.And(CampaignParticipantTable, "ContactId")
					.IsEqual(schemaName, contactIdColumn) as Select;
			} else {
				var contactIdColumn = audienceSelect.Columns.FindByAlias("ContactId").CloneMe();
				existingSelect = GetExistingAudienceSelect()
					.And(CampaignParticipantTable, "ContactId")
					.IsEqual(contactIdColumn) as Select;
			}
			if (audienceSelect.HasCondition) {
				var condition = audienceSelect.Condition.CloneMe().WrapBlock();
				audienceSelect.Condition.Clear();
				audienceSelect.Where(condition);
				audienceSelect.And().Not().Exists(existingSelect);
			} else {
				audienceSelect.Where().Not().Exists(existingSelect);
			}
			return audienceSelect;
		}

		private InsertSelect GetQueryForInsertInCampaignParticipants(Query audienceQuery) {
			var queryClone = (audienceQuery as Select).CloneMe();
			ExtendSelectColumnsForInsert(queryClone);
			InsertSelect audienceInsert = new InsertSelect(UserConnection).Into(CampaignParticipantTable)
				.Set("ContactId", "CampaignId", "CampaignItemId", "StepModifiedOn",
					"StepCompletedOn", "StatusId", "StepCompleted")
				.FromSelect(queryClone);
			return audienceInsert;
		}

		private void ExtendSelectColumnsForInsert(Select audienceSelect) {
			var contactIdColumn = audienceSelect.Columns.FindByAlias("ContactId");
			if (contactIdColumn == null) {
				var schemaName = audienceSelect.SourceExpression.SchemaName;
				audienceSelect.Columns.Clear();
				audienceSelect.Column(schemaName, SourceSelectContactIdColumnName).As("ContactId");
			} else {
				var contactIdColumnClone = contactIdColumn.CloneMe();
				audienceSelect.Columns.Clear();
				audienceSelect.Column(contactIdColumnClone);
			}
			audienceSelect.Column(Column.Parameter(CampaignId)).As("CampaignId");
			audienceSelect.Column(Column.Parameter(CampaignItemId)).As("CampaignItemId");
			audienceSelect.Column(Column.Parameter(DateTime.UtcNow)).As("StepModifiedOn");
			audienceSelect.Column(Column.Parameter(ScheduledDate)).As("StepCompletedOn");
			audienceSelect.Column(Column.Parameter(
				CampaignConstants.CampaignParticipantParticipatingStatusId)).As("StatusId");
			audienceSelect.Column(Column.Parameter(true)).As("StepCompleted");
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns <see cref="Select"/> which represents contact ids to add in campaign.
		/// </summary>
		/// <returns>Select of contact ids.</returns>
		protected abstract Select GetContactsSelect();

		/// <summary>
		/// Builds <see cref="Select"/> which represents contact ids of campaign participants
		/// which still exist in campaign.
		/// </summary>
		/// <returns>Select of contact ids.</returns>
		protected virtual Select GetExistingAudienceSelect() {
			var select =
				new Select(UserConnection)
					.Column(CampaignParticipantTable, "ContactId")
					.From(CampaignParticipantTable)
					.Where(CampaignParticipantTable, "CampaignId").IsEqual(Column.Parameter(CampaignId))
				as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		/// <summary>
		/// Defines <see cref="AudienceQuery"/> for add new participants in campaign.
		/// </summary>
		/// <returns><see cref="Select"/>Query returns contacts and linked entities to add into campaign.</returns>
		protected override Query GetAudienceQuery() {
			Select contactsSelect = GetContactsSelect();
			return contactsSelect != null
				? GetSelectExceptExistingContacts(contactsSelect)
				: null;
		}

		/// <summary>
		/// Adds new participants from <paramref name="audienceQuery"/> to campaign participants.
		/// </summary>
		/// <param name="audienceQuery">Query for item audience to be processed.</param>
		/// <returns>Number of processed participants.</returns>
		protected virtual int AddParticipants(Query audienceQuery) {
			var audienceInsert = GetQueryForInsertInCampaignParticipants(audienceQuery);
			return audienceInsert.Execute();
		}

		/// <summary>
		/// Enriches campaign participants with linked entities.
		/// </summary>
		/// <param name="audienceSelect">Source audience query. Pairs of LinkedEntityId and ContactId.</param>
		protected virtual void AddParticipantsInfo(Select audienceSelect) {
			if (audienceSelect == null) {
				return;
			}
			var participantInfoSelect = new Select(UserConnection)
				.Column("AudienceSelect", "LinkedEntityId")
				.Column(CampaignParticipantTable, "Id").As("CampaignParticipantId")
				.Column(Column.Parameter(AudienceSchemaUId)).As("EntityObjectId")
				.From(audienceSelect).As("AudienceSelect")
				.InnerJoin(CampaignParticipantTable)
					.On(CampaignParticipantTable, "ContactId").IsEqual("AudienceSelect", "ContactId")
					.And(CampaignParticipantTable, "CampaignId").IsEqual(Column.Parameter(CampaignId))
					.And(CampaignParticipantTable, "CampaignItemId").IsEqual(Column.Parameter(CampaignItemId)) as Select;
			var existedParticipantInfo = new Select(UserConnection)
				.Column(Column.Parameter(1))
				.From(CampaignParticipantInfoTable)
				.Where(CampaignParticipantInfoTable, "CampaignParticipantId").IsEqual(CampaignParticipantTable, "Id")
					.And(CampaignParticipantInfoTable, "EntityObjectId").IsEqual(Column.Parameter(AudienceSchemaUId));
			participantInfoSelect.Where().Not().Exists(existedParticipantInfo);
			participantInfoSelect.SpecifyNoLockHints();
			var insertSelect = new InsertSelect(UserConnection)
				.Into(CampaignParticipantInfoTable)
				.Set("LinkedEntityId", "CampaignParticipantId", "EntityObjectId")
				.FromSelect(participantInfoSelect);
			insertSelect.Execute();
		}

		/// <summary>
		/// Tries to add new campaign participants using audience query and links existed campaign participants with
		/// latest entities in case of empty linked entity.
		/// </summary>
		/// <param name="audienceQuery">Query with contacts and linked entities.</param>
		/// <returns>Number of added participants.</returns>
		protected override int SingleExecute(Query audienceQuery) {
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				try {
					var processedAmount = AddParticipants(audienceQuery);
					if (UserConnection.GetIsFeatureEnabled("CampaignAudienceImport")) {
						AddParticipantsInfo(audienceQuery as Select);
					}
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

