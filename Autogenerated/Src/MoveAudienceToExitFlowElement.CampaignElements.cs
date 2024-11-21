 namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Configuration.CampaignElements;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;

	#region Class: MoveAudienceToExitFlowElement

	/// <summary>
	/// Executable campaign element which moves contacts to current campaign item.
	/// </summary>
	public class MoveAudienceToExitFlowElement : CampaignFlowElement
	{

		#region Constants: Public

		private const string ContactTableName = nameof(Contact);

		#endregion

		#region Properties: Private

		private Guid ParticipantStatusId => IsCampaignGoal
			? CampaignConstants.CampaignParticipantReachedGoalStatusId
			: CampaignConstants.CampaignParticipantExitedStatusId;

		private Select ContactToMoveSelect { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Root folder schema name.
		/// </summary>
		public string FolderSchemaName => nameof(ContactFolder);

		/// <summary>
		/// Unique identifier of the folder.
		/// </summary>
		public Guid FolderRecordId { get; set; }

		/// <summary>
		/// Flag which indicates that element is campaign's goal or not.
		/// </summary>
		public bool IsCampaignGoal { get; set; }

		/// <summary>
		/// Flag to indicate that move audience is by filter.
		/// </summary>
		public bool HasFilter { get; set; }

		/// <summary>
		/// Filter to move audience.
		/// </summary>
		public string Filter { get; set; }

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

		private IEnumerable<Guid> GetAllowedParticipantStatuses() =>
			ParticipantStatusId.Equals(CampaignConstants.CampaignParticipantReachedGoalStatusId)
				? new[] {
						CampaignConstants.CampaignParticipantParticipatingStatusId,
						CampaignConstants.CampaignParticipantExitedStatusId
					}
				: new[] { CampaignConstants.CampaignParticipantParticipatingStatusId };

		private Select InitContactSubSelect(Select folderSelect) {
			var selectSchemaName = folderSelect.SourceExpression.SchemaName;
			var contactIdColumn = selectSchemaName == nameof(Contact) ? "Id" : "ContactId";
			if (folderSelect.HasCondition) {
				var existingConditions = folderSelect.Condition.CloneMe().WrapBlock();
				folderSelect.Condition.Clear();
				folderSelect.Where(existingConditions);
			}
			var contactSubSelectCondition = new QueryCondition(QueryConditionType.Equal) {
				LeftExpression = new QueryColumnExpression(selectSchemaName, contactIdColumn)
			};
			contactSubSelectCondition.RightExpressions.Add(CampaignParticipantTable, "ContactId");
			folderSelect.AddCondition(contactSubSelectCondition, Common.LogicalOperation.And);
			return folderSelect;
		}

		private Select CreateAudienceSelect(IEnumerable<Guid> participantStatuses, Select contactSubSelect) {
			var audienceSelect = new Select(UserConnection)
					.Column(CampaignParticipantTable, "Id")
				.From(CampaignParticipantTable).As(CampaignParticipantTable)
				.Where(CampaignParticipantTable, "CampaignId")
					.IsEqual(Column.Parameter(CampaignId))
				.And(CampaignParticipantTable, "CampaignItemId")
					.IsNotEqual(Column.Parameter(CampaignItemId))
				.And(CampaignParticipantTable, "StatusId")
					.In(Column.Parameters(participantStatuses))
				.And().Exists(contactSubSelect) as Select;
			audienceSelect.SpecifyNoLockHints();
			return audienceSelect;
		}

		private Select GetAudienceSelectQuery() {
			if (ContactToMoveSelect == null) {
				return null;
			}
			var contactSubSelect = InitContactSubSelect(ContactToMoveSelect);
			var participantStatuses = GetAllowedParticipantStatuses();
			return CreateAudienceSelect(participantStatuses, contactSubSelect);
		}

		private Update GetExcludeAudienceQuery(Query audienceQuery) {
			var updateQuery = new Update(UserConnection, CampaignParticipantTable)
					.Set("CampaignItemId", Column.Parameter(CampaignItemId))
					.Set("StatusId", Column.Parameter(ParticipantStatusId))
					.Set("StepModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Set("StepCompleted", Column.Parameter(false))
				.Where(audienceQuery.Condition) as Update;
			updateQuery.WithHints(new RowLockHint());
			return updateQuery;
		}

		private Select GetFolderSelect() {
			if (FolderRecordId.IsEmpty()) { 
				return null;
			}
			var select = FolderHelper.GetFolderSelectV2(ContactTableName, FolderSchemaName, FolderRecordId,
					UserConnection);
			if (select == null) {
				string errorMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"MoveAudienceToExitFlowElement", "LocalizableStrings.DeletedContactFolderMessage.Value");
				throw new CampaignElementBrokenDataException(string.Format(errorMessage, Caption ?? Name));
			}
			return select;
		}

		private Select GetFilterSelect() {
			if (string.IsNullOrWhiteSpace(Filter)) {
				string errorMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"MoveAudienceToExitFlowElement", "LocalizableStrings.BrokenFilterMessage.Value");
				throw new CampaignElementBrokenDataException(string.Format(errorMessage, Caption ?? Name));
			}
			var searchData = Encoding.UTF8.GetBytes(Filter);
			if (!FolderHelper.CheckSearchDataHasFilter(ContactTableName, searchData, UserConnection)) {
				return null;
			}
			var esq = FolderHelper.GetDynamicFolderESQ(ContactTableName, searchData, UserConnection);
			if (esq == null) {
				return null;
			}
			esq.UseAdminRights = false;
			return esq.GetSelectQuery(UserConnection);
		}

		private Select GetContactToMoveSelect() => HasFilter ? GetFilterSelect() : GetFolderSelect();

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes current flow element.
		/// </summary>
		/// <param name="context">The execution context.</param>
		/// <returns>Count of campaign participants which were processed by current element.</returns>
		protected override int SafeExecute(ProcessExecutingContext context) {
			ContactToMoveSelect = GetContactToMoveSelect();
			if (ContactToMoveSelect != null && ContactToMoveSelect.HasCondition) {
				return base.SafeExecute(context);
			}
			return 0;
		}

		/// <summary>
		/// Returns instance of <see cref="Query"/> with conditions to get audience to process.
		/// </summary>
		/// <returns>Query with filter audience conditions.</returns>
		protected override Query GetAudienceQuery() => GetAudienceSelectQuery();

		/// <summary>
		/// Executes current flow element with audience query conditions.
		/// </summary>
		/// <param name="audieceQuery">Query for item audience to be processed.</param>
		/// <returns>Count of campaign participants which were processed by current step.</returns>
		protected override int SingleExecute(Query audieceQuery) {
			var query = GetExcludeAudienceQuery(audieceQuery);
			return query.Execute();
		}

		#endregion

	}

	#endregion

}

