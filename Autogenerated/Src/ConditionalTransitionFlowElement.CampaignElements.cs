namespace BPMSoft.Configuration
{
	using System;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;

	#region Class: ConditionalTransitionFlowElement

	/// <summary>
	/// Conditional transition process element.
	/// </summary>
	public class ConditionalTransitionFlowElement : CampaignTransitionProcessElement
	{

		#region Fields: Private

		private readonly string ContactSchemaName = "Contact";
		private readonly Guid ContactSchemaUId = new Guid("16BE3651-8FE2-4159-8DD0-A803D4683DD3");

		#endregion

		#region Properties: Protected

		private FolderHelper _folderHelper;

		/// <summary>
		/// An instance of the <see cref="FolderHelper"/>.
		/// </summary>
		protected FolderHelper FolderHelper {
			get => _folderHelper ?? (_folderHelper = new FolderHelper());
			set => _folderHelper = value;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Defines if transition execution is delayed.
		/// </summary>
		public bool IsDelayedStart { get; set; }

		/// <summary>
		/// Delay in days before the conditional flow execution.
		/// </summary>
		public int DelayInDays { get; set; }

		/// <summary>
		/// Delay unit for part of query with time condition.
		/// </summary>
		public ConditionalSequenceFlowDelayUnit DelayUnit { get; set; }

		/// <summary>
		/// Defines if transition execution has a filter.
		/// </summary>
		public bool HasFilter { get; set; }

		/// <summary>
		/// Unique identifier of the record in ContactFolder table.
		/// </summary>
		public Guid FilterId { get; set; }

		/// <summary>
		/// Search data to filter campaign participants.
		/// </summary>
		public string Filter { get; set; }

		/// <summary>
		/// Entity schema identifier to filter campaign participants.
		/// </summary>
		public Guid FilterEntitySchemaUId { get; set; }

		/// <summary>
		/// Entity schema name which campaign audience will be filtered by.
		/// </summary>
		public string FilterEntitySchemaName { get; set; }

		/// <summary>
		/// Column path for the filtered entity.
		/// </summary>
		public string FilterEntityContactPath { get; set; }

		#endregion

		#region Methods: Private

		private int GetDelayInHours() {
			return DelayUnit == ConditionalSequenceFlowDelayUnit.Days ? DelayInDays * 24 : DelayInDays;
		}

		private void ExtendWithTimeCondition() {
			if (!IsDelayedStart || DelayInDays == 0 || ScheduledDate == null) {
				return;
			}
			var jobScheduledOn = (DateTime)ScheduledDate;
			var delayedHours = GetDelayInHours();
			DateTime dateWithoutDelay = jobScheduledOn.AddHours(-delayedHours);
			TransitionQuery.And("StepCompletedOn").IsLessOrEqual(Column.Parameter(dateWithoutDelay));
		}

		private Select GetFilterSelect(byte[] searchData) {
			var esq = FolderHelper.GetDynamicFolderESQ(FilterEntitySchemaName, searchData, UserConnection);
			if (esq == null) {
				return null;
			}
			esq.UseAdminRights = false;
			return esq.GetSelectQuery(UserConnection);
		}

		private void ExtendWithLinkedEntityFilter(Select filterSelect) {
			filterSelect.And(FilterEntitySchemaName, "Id").IsEqual(CampaignParticipantInfoTable, "LinkedEntityId");
			var participantInfoSelect = new Select(UserConnection)
				.Column(CampaignParticipantInfoTable, "LinkedEntityId")
				.From(CampaignParticipantInfoTable)
				.InnerJoin(nameof(SysSchema))
					.On(nameof(SysSchema), "UId").IsEqual(CampaignParticipantInfoTable, "EntityObjectId")
					.And(nameof(SysSchema), "Name").IsEqual(Column.Parameter(FilterEntitySchemaName))
				.InnerJoin(FilterEntitySchemaName)
					.On(FilterEntitySchemaName, "Id").IsEqual("LinkedEntityId")
				.Where(CampaignParticipantInfoTable, "CampaignParticipantId").IsEqual(CampaignParticipantTable, "Id")
					.And().Exists(filterSelect) as Select;
			participantInfoSelect.SpecifyNoLockHints();
			TransitionQuery.And().Exists(participantInfoSelect);
		}

		private void ExtendWithFilterEntityCondition() {
			var searchData = Encoding.UTF8.GetBytes(Filter);
			if (!FolderHelper.CheckSearchDataHasFilter(FilterEntitySchemaName, searchData, UserConnection)) {
				return;
			}
			var filterSelect = GetFilterSelect(searchData);
			if (filterSelect.HasCondition) {
				var existingConditions = filterSelect.Condition.CloneMe().WrapBlock();
				filterSelect.Condition.Clear();
				filterSelect.Where(existingConditions);
			}
			if (FilterEntitySchemaName != nameof(Contact)) {
				ExtendWithLinkedEntityFilter(filterSelect);
				return;
			}
			if (filterSelect.HasCondition) {
				filterSelect.And(FilterEntitySchemaName, "Id").IsEqual(CampaignParticipantTable, "ContactId");
			} else {
				filterSelect.Where(FilterEntitySchemaName, "Id").IsEqual(CampaignParticipantTable, "ContactId");
			}
			TransitionQuery.And().Exists(filterSelect);
		}

		private void ExtendWithFilterConditionFromFolder() {
			if (FilterId.IsEmpty()) {
				return;
			}
			Select folderSelect = FolderHelper.GetFolderSelectV2(ContactSchemaName, "ContactFolder", FilterId,
				UserConnection);
			if (folderSelect != null) {
				TransitionQuery.And("ContactId").In(folderSelect);
			}
		}

		private void ExtendWithFilterCondition() {
			if (!HasFilter) {
				return;
			}
			if (FilterEntitySchemaUId.IsEmpty()) {
				FilterEntityContactPath = "Id";
				FilterEntitySchemaName = ContactSchemaName;
				FilterEntitySchemaUId = ContactSchemaUId;
			}
			if (Filter.IsNotNullOrWhiteSpace()) {
				ExtendWithFilterEntityCondition();
				return;
			}
			ExtendWithFilterConditionFromFolder();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns query that includes additional logic.
		/// </summary>
		/// <returns>Base <see cref="Update"/> extended with time and filter conditions.</returns>
		protected override void CreateQuery() {
			base.CreateQuery();
			ExtendWithTimeCondition();
			ExtendWithFilterCondition();
		}

		#endregion

	}

	#endregion

}

