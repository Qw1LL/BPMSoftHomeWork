namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;

	#region Class: CampaignEventFlowElement

	/// <summary>
	/// Executable event element in campaign.
	/// </summary>
	public class CampaignEventFlowElement : CampaignFlowElement
	{

		#region Constants: Private

		private const string EventTargetTableName = nameof(EventTarget);
		private const string EventTableName = nameof(Event);
		private readonly Guid EventTargetSchemaUId = new Guid("FB50E79E-EDE8-4714-B6C8-C7CF4D3A9F87");

		#endregion

		#region Properties: Private

		private int AddedEventTargetCount;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of event.
		/// </summary>
		public Guid EventId { get; set; }

		#endregion

		#region Methods: Private

		private void ExcludeExistingContacts(Select audienceSelect) {
			var existingEventTargetContactsSelect = new Select(UserConnection)
					.Column(EventTargetTableName, "ContactId")
				.From(EventTargetTableName)
				.Where(EventTargetTableName, "EventId").IsEqual(Column.Parameter(EventId))
				.And(EventTargetTableName, "ContactId").IsEqual(CampaignParticipantTable, "ContactId") as Select;
			existingEventTargetContactsSelect.SpecifyNoLockHints();
			audienceSelect.And().Not().Exists(existingEventTargetContactsSelect);
		}

		private Select GetAudienceToAddSelect(Select audienceSelect) {
			var select = new Select(audienceSelect);
			select.Columns.Clear();
			select
				.Column(CampaignParticipantTable, "ContactId").As("ContactId")
				.Column(Column.Parameter(EventId)).As("EventId")
				.Column(Column.Parameter(MarketingConsts.EventResponsePlannedId)).As("EventResponseId");
			select.SpecifyNoLockHints();
			ExcludeExistingContacts(select);
			return select;
		}

		private int AddAudienceToEvent(Select audienceSelect) {
			var audienceToAddSelect = GetAudienceToAddSelect(audienceSelect);
			var insertSelect = new InsertSelect(UserConnection)
				.Into(EventTargetTableName)
					.Set("ContactId", "EventId", "EventResponseId")
				.FromSelect(audienceToAddSelect);
			return insertSelect.Execute();
		}

		private Select GetEventTotalCountSelect() {
			var select = new Select(UserConnection)
					.Column(Func.Count("Id"))
				.From(EventTargetTableName)
				.Where("EventId").IsEqual(Column.Parameter(EventId)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		private void UpdateEventParticipantsCount() {
			var totalCountSelect = GetEventTotalCountSelect();
			var update = new Update(UserConnection, EventTableName)
					.Set("RecipientCount", Column.SubSelect(totalCountSelect))
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
				.Where("Id").IsEqual(Column.Parameter(EventId)) as Update;
			update.WithHints(Hints.RowLock);
			update.Execute();
		}

		/// <summary>
		/// Link campaign participants with created event targets.
		/// </summary>
		private void AddParticipantsInfo() {
			var existedParticipantInfo = new Select(UserConnection)
				.Column(Column.Parameter(1))
				.From(CampaignParticipantInfoTable)
				.Where(CampaignParticipantInfoTable, "CampaignParticipantId").IsEqual(CampaignParticipantTable, "Id")
					.And(CampaignParticipantInfoTable, "EntityObjectId").IsEqual(Column.Parameter(EventTargetSchemaUId));
			var participantInfoSelect = new Select(UserConnection)
				.Column(EventTargetTableName, "Id").As("LinkedEntityId")
				.Column(CampaignParticipantTable, "Id").As("CampaignParticipantId")
				.Column(Column.Parameter(EventTargetSchemaUId)).As("EntityObjectId")
				.From(CampaignParticipantTable)
				.InnerJoin(EventTargetTableName)
					.On(EventTargetTableName, "ContactId").IsEqual(CampaignParticipantTable, "ContactId")
				.Where(CampaignParticipantTable, "Id").In(Column.Parameters(AudienceBatch))
				.And(EventTargetTableName, "EventId").IsEqual(Column.Parameter(EventId))
				.And().Not().Exists(existedParticipantInfo) as Select;
			participantInfoSelect.SpecifyNoLockHints();
			var insertSelect = new InsertSelect(UserConnection)
				.Into(CampaignParticipantInfoTable)
				.Set("LinkedEntityId", "CampaignParticipantId", "EntityObjectId")
				.FromSelect(participantInfoSelect);
			insertSelect.Execute();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes current flow element.
		/// </summary>
		/// <param name="context">The execution context.</param>
		/// <returns><c>true</c>, if element was successfully executed. Otherwise - <c>false</c>.</returns>
		protected override int SafeExecute(ProcessExecutingContext context) {
			try {
				return base.SafeExecute(context);
			} finally {
				if (AddedEventTargetCount > 0) {
					UpdateEventParticipantsCount();
				}
			}
		}

		/// <summary>
		/// Executes current flow element with audience query conditions.
		/// </summary>
		/// <param name="audieceQuery">Query for item audience to be processed.</param>
		/// <returns>Count of campaign participants which were processed by current step.</returns>
		protected override int SingleExecute(Query audieceQuery) {
			var audienceSelect = audieceQuery as Select;
			AddedEventTargetCount += AddAudienceToEvent(audienceSelect);
			if (AddedEventTargetCount > 0 && AudienceBatch.Count() > 0
					&& UserConnection.GetIsFeatureEnabled("CampaignAudienceImport")) {
				AddParticipantsInfo();
			}
			return SetItemCompleted(audienceSelect);
		}

		#endregion

	}

	#endregion

}

