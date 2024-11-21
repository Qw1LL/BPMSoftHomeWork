namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;

	#region Class: BaseCampaignFlowElement

	/// <summary>
	/// Base class for executable campaign elements.
	/// </summary>
	public class BaseCampaignFlowElement : CampaignProcessFlowElement
	{

		#region Constants: Private

		private const string CampaignParticipantTableName = "CampaignParticipant";
		private const string CampaignParticipantOpTableName = "CampaignParticipantOp";

		#endregion

		#region Constants: Protected

		/// <summary>
		/// Safe batch size for most of query types.
		/// </summary>
		protected const int SafeQueryBatchSize = 500;

		#endregion

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

		#region Properties: Protected

		/// <summary>
		/// Campaign audience table name.
		/// </summary>
		protected string CampaignParticipantTable => SessionId.Equals(default(Guid))
				? CampaignParticipantTableName
				: CampaignParticipantOpTableName;

		/// <summary>
		/// Column name with foreign key on Contact.Id at original select. It is used to select distinct contacts
		/// using query, returned by <see cref="GetAudienceQuery"/> method.
		/// </summary>
		protected virtual string SourceSelectContactIdColumnName { get; set; }

		/// <summary>
		/// Table name that contains an additional info linked with campaign participant.
		/// </summary>
		protected string CampaignParticipantInfoTable => CampaignParticipantTable + "Info";

		/// <summary>
		/// Campaign audience data source.
		/// </summary>
		private ICampaignAudience _campaignAudience;
		protected ICampaignAudience CampaignAudience {
			get => _campaignAudience ?? (_campaignAudience = GetCampaignAudience());
			set => _campaignAudience = value;
		}

		/// <summary>
		/// Reminding utilities. Instance of <see cref="RemindingUtilities"/>.
		/// </summary>
		private RemindingUtilities _remindingUtilities;
		public RemindingUtilities RemindingUtilities {
			get => _remindingUtilities ?? (_remindingUtilities = new RemindingUtilities());
			set => _remindingUtilities = value;
		}

		/// <summary>
		/// Campaign helper. Instance of <see cref="CampaignHelper"/>.
		/// </summary>
		private CampaignHelper _campaignHelper;
		public CampaignHelper CampaignHelper {
			get => _campaignHelper ?? (_campaignHelper = new CampaignHelper(UserConnection));
			set => _campaignHelper = value;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Current list of campaign participants in work.
		/// </summary>
		public IEnumerable<Guid> AudienceBatch { get; internal set; }

		#endregion

		#region Methods: Private

		private ICampaignAudience GetCampaignAudience() {
			CampaignAudienceConfig config = new CampaignAudienceConfig(UserConnection, CampaignId, SessionId) {
				CampaignScheduledDate = ScheduledDate
			};
			return CampaignAudienceFactory.Instance.GetCampaignAudience(config);
		}

		private string GetSourceAlias(Query query) =>
			(query as Update)?.Source.SchemaName
				?? (query as Select)?.SourceExpression.Alias
				?? (query as Select)?.SourceExpression.SchemaName;

		private Select GetKeysSelect(Update sourceAudienceQuery) {
			var source = sourceAudienceQuery.Source.SchemaName;
			var resultSelect = new Select(UserConnection)
				.Column(source, "Id")
				.From(source).As(source)
				.Where(sourceAudienceQuery.Condition) as Select;
			return resultSelect;
		}

		private Select GetKeysSelect(Select sourceAudienceQuery) {
			var source = sourceAudienceQuery.SourceExpression.SchemaName;
			var alias = GetSourceAlias(sourceAudienceQuery);
			if (source == null) {
				return sourceAudienceQuery.Column(alias, "LinkedEntityId").As("Id");
			}
			var resultSelect = new Select(UserConnection)
				.From(source).As(source)
				.Where(sourceAudienceQuery.Condition) as Select;
			if (string.IsNullOrWhiteSpace(SourceSelectContactIdColumnName)) {
				resultSelect.Column(alias, "Id");
			} else {
				var contactColumn = sourceAudienceQuery.Columns.FindByAlias(SourceSelectContactIdColumnName);
				resultSelect.Column(Func.Max(alias, "Id")).As("Id")
					.GroupBy(alias, contactColumn?.SourceColumnAlias ?? SourceSelectContactIdColumnName);
			}
			return resultSelect;
		}

		private Query ReplaceAudienceQueryWithInCondition(Query audienceQuery) {
			var query = audienceQuery.Clone() as Query;
			var linkedEntityIdColumn = (query as Select)?.Columns.FindByAlias("LinkedEntityId");
			var alias = GetSourceAlias(audienceQuery);
			query.Condition.Clear();
			if (linkedEntityIdColumn != null) {
				query.Where(linkedEntityIdColumn).In(Column.Parameters(AudienceBatch));
			} else {
				query.Where(alias, "Id").In(Column.Parameters(AudienceBatch));
			}
			return query;
		}

		private void BatchedExecute(Query audienceQuery) {
			var participants = GetKeysByQuery(audienceQuery);
			int participantsCount = participants.Count;
			int batchSize = CampaignElementAudienceQueryBatchSize;
			int processedCount = 0;
			ProcessedAudienceAmount = 0;
			while (processedCount < participantsCount) {
				AudienceBatch = participants.Skip(processedCount).Take(batchSize);
				var preparedQuery = ReplaceAudienceQueryWithInCondition(audienceQuery);
				ProcessedAudienceAmount += SingleExecute(preparedQuery);
				processedCount += batchSize;
				Task.Delay(10).Wait();
			}
		}

		#endregion

		#region Methods: Protected

		protected string GetLczStringValue(string className, string lczStringName) {
			string localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczStringName);
			var localizableString = new LocalizableString(
				UserConnection.Workspace.ResourceStorage, className, localizableStringName);
			string value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		protected void CreateNotification(string notification) {
			var campaign = CampaignHelper.GetCampaign(CampaignId, "Owner");
			var config = new RemindingConfig(campaign.Schema.UId) {
				AuthorId = UserConnection.CurrentUser.ContactId,
				ContactId = campaign.OwnerId,
				SubjectId = CampaignId,
				Description = notification
			};
			RemindingUtilities.CreateReminding(UserConnection, config);
		}

		protected Update GetItemParticipantsUpdate(Select audienceSelect) {
			var update = new Update(UserConnection, CampaignParticipantTable)
				.Set("StepModifiedOn", Column.Parameter(DateTime.UtcNow));
			update.Where(audienceSelect.Condition);
			update.WithHints(new RowLockHint());
			return update;
		}

		/// <summary>
		/// Retrieves a list of identifiers from the source Select or Update query.
		/// </summary>
		protected List<Guid> GetKeysByQuery(Query sourceAudienceQuery) {
			var selectQuery = default(Select);
			if (sourceAudienceQuery is Update) {
				selectQuery = GetKeysSelect(sourceAudienceQuery as Update);
			} else {
				selectQuery = GetKeysSelect(sourceAudienceQuery as Select);
			}
			selectQuery.Joins.AddRange(sourceAudienceQuery.Joins);
			selectQuery.GroupByItems.AddRange(sourceAudienceQuery.GroupByItems);
			selectQuery.SpecifyNoLockHints();
			return selectQuery.ExecuteEnumerable(r => r.GetColumnValue<Guid>("Id")).ToList();
		}

		protected virtual int SetItemCompleted(Select audienceSelect) {
			var update = GetItemParticipantsUpdate(audienceSelect);
			update.Set("StepCompleted", Column.Parameter(true))
				.Set("StepCompletedOn", Column.Parameter(DateTime.UtcNow));
			return update.Execute();
		}

		protected virtual int SetParticipantsStatus(Select audienceSelect, Guid statusId, bool stepCompleted = true) {
			var update = GetItemParticipantsUpdate(audienceSelect);
			update.Set("StatusId", Column.Parameter(statusId));
			if (stepCompleted) {
				update.Set("StepCompleted", Column.Parameter(true))
				.Set("StepCompletedOn", Column.Parameter(DateTime.UtcNow));
			}
			return update.Execute();
		}

		/// <summary>
		/// Contains custom logic for <see cref="AudieceQuery"/> initialization.
		/// </summary>
		protected virtual Query GetAudienceQuery() {
			return null;
		}

		/// <summary>
		/// Executes current flow element for selected audience.
		/// </summary>
		/// <param name="audienceQuery">Query for item audience to be processed.</param>
		/// <returns>Number of processed participants.</returns>
		protected virtual int SingleExecute(Query audienceQuery) {
			return 0;
		}

		/// <summary>
		/// Executes current flow element.
		/// </summary>
		/// <param name="context">The execution context.</param>
		/// <returns>Number of processed participants.</returns>
		protected override int SafeExecute(ProcessExecutingContext context) {
			var audienceQuery = GetAudienceQuery();
			if (audienceQuery != null) {
				BatchedExecute(audienceQuery);
			}
			return ProcessedAudienceAmount ?? 0;
		}

		#endregion

	}

	#endregion

}

