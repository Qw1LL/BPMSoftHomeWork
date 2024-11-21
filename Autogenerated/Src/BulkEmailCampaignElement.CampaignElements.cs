namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;
	using global::Common.Logging;
	using CoreCampaignConsts = Core.Campaign.CampaignConstants;

	#region Class: BulkEmailCampaignElement

	/// <summary>
	/// Executable bulk email element in campaign.
	/// </summary>
	public class BulkEmailCampaignElement : CampaignFlowElement
	{

		#region Constants: Private

		private const string CampaignParticipantEmailTargetTableName = "CmpgnPrtcpntEmailTarget";
		private const string CampaignParticipantEmailTargetOpTableName = "CmpgnPrtcpntEmailTargetOp";

		#endregion

		#region Properties: Protected
		[Obsolete("Will be removed after 7.17.2")]
		private BulkEmailAudienceDataSource _bulkEmailAudienceDataSource;
		/// <summary>
		/// Bulk email audience data source.
		/// </summary>
		[Obsolete("Will be removed after 7.17.2")]
		protected BulkEmailAudienceDataSource BulkEmailAudienceDataSource {
			get => _bulkEmailAudienceDataSource ??
					(_bulkEmailAudienceDataSource = new BulkEmailAudienceDataSource(UserConnection, BulkEmailId, 200,
						SessionUId));
			set => _bulkEmailAudienceDataSource = value;
		}

		/// <summary>
		/// Gets or sets the campaign logger. Instance of <see cref="ILog"/>.
		/// </summary>
		private ILog _logger;
		protected ILog Logger {
			get => _logger ?? (_logger = LogManager.GetLogger(CoreCampaignConsts.CampaignLoggerName));
			set => _logger = value;
		}

		/// <summary>
		/// Serves CRUD operations for audience of the bulk email.
		/// </summary>
		private BulkEmailAudienceRepository _bulkEmailAudienceRepository;
		public BulkEmailAudienceRepository BulkEmailAudienceRepository {
			get => _bulkEmailAudienceRepository ?? new BulkEmailAudienceRepository(UserConnection);
			set => _bulkEmailAudienceRepository = value;
		}

		/// <summary>
		/// An instance of <see cref="BulkEmailFacade"/> class.
		/// </summary>
		private BulkEmailFacade _bulkEmailFacade;
		public BulkEmailFacade BulkEmailFacade {
			get => _bulkEmailFacade ?? (_bulkEmailFacade = new BulkEmailFacade(UserConnection));
			set => _bulkEmailFacade = value;
		}

		/// <summary>
		/// Name of the email audience schema.
		/// </summary>
		public string AudienceSchemaName { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of bulk email.
		/// </summary>
		public Guid BulkEmailId { get; set; }

		private Guid _sessionUId;
		/// <summary>
		/// Unique identifier of mailing session.
		/// </summary>
		public Guid SessionUId {
			get => _sessionUId.IsEmpty() ? (_sessionUId = Guid.NewGuid()) : _sessionUId;
			internal set => _sessionUId = value;
		}

		#endregion

		#region Methods: Private

		private string GetCampaignParticipantEmailTargetTableName() => SessionId.Equals(default(Guid))
				? CampaignParticipantEmailTargetTableName
				: CampaignParticipantEmailTargetOpTableName;


		private Select GetRecipientSelect(Select audienceSelect) {
			var select = new Select(audienceSelect);
			select.Columns.Clear();
			select
				.Column("Contact", "RId").As("ContactRId")
				.Column("Contact", "Email").As("EmailAddress")
				.InnerJoin("Contact")
					.On("Contact", "Id").IsEqual(CampaignParticipantTable, "ContactId");
			select.SpecifyNoLockHints();
			return select;
		}

		private Select GetMandrillIdToCampaignParticipantIdRelationSelect(Select audienceSelect) {
			var select = new Select(audienceSelect);
			select.Columns.Clear();
			select
				.Column("bet", "MandrillId")
				.Column(CampaignParticipantTable, "Id")
				.Column("bet", "BulkEmailId")
				.InnerJoin("BulkEmailTarget").As("bet").On("bet", "ContactId").IsEqual(CampaignParticipantTable, "ContactId")
				.And("bet", "BulkEmailId").IsEqual(Column.Parameter(BulkEmailId))
				.InnerJoin("CampaignItem").As("ci").On("ci", "Id").IsEqual(CampaignParticipantTable, "CampaignItemId")
				.And("ci", "RecordId").IsEqual("bet", "BulkEmailId");
			var existingEmailTargetSelect = new Select(UserConnection)
					.Column(Column.Parameter(1))
					.From(GetCampaignParticipantEmailTargetTableName()).As("cpetop")
					.Where("cpetop", "MandrillRecipientUId").IsEqual("bet", "MandrillId");
			if (select.Condition.IsEmpty()) {
				select.Where().Not().Exists(existingEmailTargetSelect);
			} else {
				var whereConditions = select.Condition.CloneMe();
				select.Condition.Clear();
				select.Where(whereConditions).And().Not().Exists(existingEmailTargetSelect);
			}
			select.SpecifyNoLockHints();
			return select;
		}

		private void IncreaseRecipientCount(Guid bulkEmailId, int count) {
			var update = new Update(UserConnection, "BulkEmail")
				.Set("RecipientCount",
					QueryColumnExpression.Add(Column.SourceColumn("RecipientCount"), Column.Parameter(count)))
				.Where("Id").IsEqual(Column.Parameter(bulkEmailId));
			update.Execute();
		}

		private int SetParticipantsErrorStatus(Select audienceSelect, Exception ex) {
			try {
				return SetParticipantsStatus(audienceSelect, CampaignConstants.CampaignParticipantErrorStatusId);
			} catch (Exception e) {
				throw new AggregateException(new List<Exception> { ex, e });
			}
		}

		private void AddRecipientsToCampaignEmailTarget(Select recipientsSelect) {
			var tableName = GetCampaignParticipantEmailTargetTableName();
			var insertSelect = new InsertSelect(UserConnection)
				.Into(tableName)
				.Set("MandrillRecipientUId", "CampaignParticipantId", "BulkEmailId")
				.FromSelect(recipientsSelect);
			insertSelect.Execute();
		}

		private IEnumerable<Guid> GetAudienceContacts(Select audienceSelect) {
			var select = new Select(audienceSelect);
			select.Columns.Clear();
			select.Column("ContactId");
			return select.ExecuteEnumerable(r => r.GetColumnValue<Guid>("ContactId"));
		}

		private IEnumerable<Guid> GetAudienceEntities(Select audienceSelect) {
			var select = new Select(audienceSelect)
				.InnerJoin(CampaignParticipantInfoTable)
					.On(CampaignParticipantInfoTable, "CampaignParticipantId").IsEqual(CampaignParticipantTable, "Id")
				.InnerJoin("SysSchema")
					.On("SysSchema", "UId").IsEqual(CampaignParticipantInfoTable, "EntityObjectId")
					.And("SysSchema", "Name").IsEqual(Column.Parameter(AudienceSchemaName)) as Select;
			select.Columns.Clear();
			select.Column(CampaignParticipantTable, "Id").As("Id")
				.Column(CampaignParticipantInfoTable, "LinkedEntityId").As("LinkedEntityId")
				.Column(Column.Parameter(0)).As("Priority");
			select.SpecifyNoLockHints();
			if (SessionId.IsNotEmpty()) {
				var infoSelect = new Select(audienceSelect)
					.InnerJoin("CampaignParticipantInfo").As("pi")
					.On("pi", "CampaignParticipantId").IsEqual(CampaignParticipantTable, "CampaignParticipantId")
					.InnerJoin("SysSchema")
						.On("SysSchema", "UId").IsEqual("pi", "EntityObjectId")
						.And("SysSchema", "Name").IsEqual(Column.Parameter(AudienceSchemaName)) as Select;
				infoSelect.Columns.Clear();
				infoSelect.Column(CampaignParticipantTable, "Id").As("Id")
					.Column("pi", "LinkedEntityId").As("LinkedEntityId")
					.Column(Column.Parameter(1)).As("Priority");
				infoSelect.SpecifyNoLockHints();
				select.Union(infoSelect);
			}
			var entitySelect = new Select(UserConnection)
				.Column("OuterQuery", "LinkedEntityId")
				.From(new Select(UserConnection)
					.Column("InnerQuery", "LinkedEntityId")
					.Column(new WindowQueryFunction(
						new RowNumberQueryFunction(),
						new QueryColumnExpression("InnerQuery", "Id"),
						new QueryColumnExpression("InnerQuery", "Priority"))).As("RowNum")
					.From(select).As("InnerQuery")).As("OuterQuery")
				.Where("OuterQuery", "RowNum").IsEqual(Column.Parameter(1)) as Select;
			return entitySelect.ExecuteEnumerable(r => r.GetColumnValue<Guid>("LinkedEntityId"));
		}

		private bool UseContactAudienceSchema() {
			return !UserConnection.GetIsFeatureEnabled("CampaignAudienceImport") ||
				string.IsNullOrWhiteSpace(AudienceSchemaName) || AudienceSchemaName == "Contact";
		}

		private int AddParticipantsToEmailAudience(Select audienceSelect) {
			var entityIds = UseContactAudienceSchema()
				? GetAudienceContacts(audienceSelect)
				: GetAudienceEntities(audienceSelect);
			var count = BulkEmailAudienceRepository.ImportEntities(entityIds, BulkEmailId, SessionUId);
			if (count > 0) {
				var recipientSelect = GetMandrillIdToCampaignParticipantIdRelationSelect(audienceSelect);
				AddRecipientsToCampaignEmailTarget(recipientSelect);
			}
			return count;
		}

		private void ValidateAudience(Select audienceQuery) {
			if (UseContactAudienceSchema()) {
				return;
			}
			var participantInfoSelect = new Select(UserConnection)
				.Column("LinkedEntityId")
				.From(CampaignParticipantInfoTable)
				.InnerJoin("SysSchema")
					.On("SysSchema", "UId").IsEqual(CampaignParticipantInfoTable, "EntityObjectId")
					.And("SysSchema", "Name").IsEqual(Column.Parameter(AudienceSchemaName))
				.InnerJoin(AudienceSchemaName).On(AudienceSchemaName, "Id").IsEqual("LinkedEntityId")
				.Where(CampaignParticipantInfoTable, "CampaignParticipantId")
					.IsEqual(CampaignParticipantTable, "Id") as Select;
			participantInfoSelect.SpecifyNoLockHints();
			if (SessionId.IsNotEmpty()) {
				var infoSelect = new Select(UserConnection)
					.Column("LinkedEntityId")
					.From("CampaignParticipantInfo").As("pi")
					.InnerJoin("SysSchema")
						.On("SysSchema", "UId").IsEqual("pi", "EntityObjectId")
						.And("SysSchema", "Name").IsEqual(Column.Parameter(AudienceSchemaName))
					.InnerJoin(AudienceSchemaName).On(AudienceSchemaName, "Id").IsEqual("LinkedEntityId")
					.Where("pi", "CampaignParticipantId")
						.IsEqual(CampaignParticipantTable, "CampaignParticipantId") as Select;
				participantInfoSelect.SpecifyNoLockHints();
				participantInfoSelect.Union(infoSelect);
			}
			var select = new Select(audienceQuery);
			select.And().Not().Exists(participantInfoSelect);
			var count = SetParticipantsErrorStatus(select, new Exception());
			if (count > 0) {
				Logger.Error($"Data for {count} campaign participants does not match with required entity of campaign "
					+ $"element Email [{CampaignItemId}]. Trigger email [{BulkEmailId}].");
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes current flow element for selected audience.
		/// </summary>
		/// <param name="audienceQuery">Query for item audience to be processed.</param>
		protected override int SingleExecute(Query audienceQuery) {
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction(IsolationLevel.ReadCommitted);
				try {
					var result = 0;
					ValidateAudience((Select)audienceQuery);
					AddParticipantsToEmailAudience((Select)audienceQuery);
					result = SetItemCompleted((Select)audienceQuery);
					dbExecutor.CommitTransaction();
					return result;
				} catch (Exception ex) {
					dbExecutor.RollbackTransaction();
					if (!SessionId.Equals(default(Guid))) {
						SetParticipantsErrorStatus((Select)audienceQuery, ex);
						Logger.Error($"Error occured in campaign element Email [{CampaignItemId}]. "
							+ $"Trigger email [{BulkEmailId}].", ex);
					}
					throw;
				}
			}
		}

		/// <summary>
		/// Executes current flow element.
		/// </summary>
		/// <param name="context">The execution context.</param>
		/// <returns>Number of processed participants.</returns>
		protected override int SafeExecute(ProcessExecutingContext context) {
			var result = base.SafeExecute(context);
			if (result <= 0) {
				return 0;
			}
			BulkEmailFacade.SendTriggerEmail(BulkEmailId, SessionUId);
			return result;
		}

		#endregion

		}

	#endregion

}

