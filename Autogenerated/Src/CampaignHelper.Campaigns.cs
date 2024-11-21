namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Common;
	using Core;
	using Core.Campaign;
	using Core.DB;
	using Marketing.Utilities;
	using BPMSoft.Core.Entities;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	#region Class: CampaignHelper

	public class CampaignHelper
	{

		#region Const: Private

		private const string SendEmailImmediatelyJobGroupName = "ImmediatelyTriggeredEmail";

		private const string SendImmediatelyTriggeredEmailProcessName = "SendImmediatelyTriggeredEmailProcess";

		private const string SendEmailImmediatelyJobNamePattern = "ImmediatelyTriggeredEmail_{0}";

		private const string CampaignHelperClassName = nameof(CampaignHelper);

		private const string CampaignSchemaNotFoundException = "CampaignSchemaNotFoundException";

		private const string CampaignNotFoundException = "CampaignNotFoundException";

		#endregion

		#region Constructors: Public

		[Obsolete("7.12.2 | Constructor is not in use and will be removed in upcoming releases.")]
		public CampaignHelper(UserConnection userConnection, ICampaignEngine campaignEngine)
			: this(userConnection) {
		}

		public CampaignHelper(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Methods: Private

		private static Select GetBulkEmailUnsubscribeSelect(UserConnection userConnection, Guid bulkEmailId) {
			var unsubscribeSubSelect = new Select(userConnection)
				.Column(Column.Parameter(1))
				.From("BulkEmailSubscription")
				.Where("ContactId").IsEqual("main", "ContactId")
				.And("BulkEmailSubsStatusId")
				.IsEqual(Column.Parameter(MailingConsts.BulkEmailContactUnsubscribed))
				.And("BulkEmailTypeId").In(
					new Select(userConnection)
						.Column("TypeId")
						.From("BulkEmail")
						.Where("Id").IsEqual(Column.Parameter(bulkEmailId))) as Select;
			unsubscribeSubSelect.SpecifyNoLockHints();
			return unsubscribeSubSelect;
		}

		private static Select GetExistingRecipientsSelect(UserConnection userConnection) {
			var existingRecipientsSelect = new Select(userConnection)
				.Column(Column.Parameter(1))
				.From("MandrillRecipient").As("MR")
				.Where("MR", "BulkEmailRId").IsEqual("main", "BulkEmailRId")
				.And("MR", "EmailAddress").IsEqual("main", "EmailAddress") as Select;
			existingRecipientsSelect.SpecifyNoLockHints();
			return existingRecipientsSelect;
		}

		private static Select GetImmediatelyTriggerBulkEmailIdentifierByStepIdSelect(
				UserConnection userConnection, Guid stepId) {
			var selectStepBulkEmailId = new Select(userConnection)
				.Column("RecordId")
				.From("CampaignStep")
				.Where("Id").IsEqual(Column.Parameter(stepId))
				.And("TypeId").IsEqual(Column.Parameter(CampaignConsts.BulkEmailCampaignStepTypeId));
			var select = new Select(userConnection)
				.Column("Id")
				.Column("RId")
				.From("BulkEmail")
				.Where("Id").IsEqual(selectStepBulkEmailId)
				.And("CategoryId").IsEqual(Column.Parameter(MarketingConsts.TriggeredEmailBulkEmailCategoryId))
				.And("StatusId").IsEqual(Column.Parameter(MarketingConsts.BulkEmailStatusActiveId))
				.And("LaunchOptionId")
				.IsEqual(Column.Parameter(MarketingConsts.TriggerEmailImmediateLaunchOptionId)) as Select;
			return select;
		}

		private static Select GetCampaignListByLandingIdSelect(UserConnection userConnection, Guid landingId) {
			var select = new Select(userConnection)
				.Column("C", "Id").As("CampaignId")
				.Column("CS", "Id").As("CampaignLendingStepId")
				.From("Campaign").As("C")
				.Join(JoinType.Inner, "CampaignStep").As("CS")
				.On("CS", "CampaignId").IsEqual("C", "Id")
				.Where("C", "CampaignStatusId").IsEqual(Column.Parameter(CampaignConsts.RunCampaignStatusId))
				.And("CS", "TypeId").IsEqual(Column.Parameter(CampaignConsts.LendingCampaignStepTypeId))
				.And("CS", "RecordId").IsEqual(Column.Parameter(landingId)) as Select;
			return select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Determines that contact can be moved onto required step of the campaign.
		/// </summary>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		/// <param name="campaignId">Unique identifier of the Campaign.</param>
		/// <param name="stepId">Unique identifier of the CampaignStep.</param>
		/// <param name="contactId">Unique identifier of the Contact.</param>
		/// <returns>Result of the merge operation.</returns>
		public static bool CanMergeContactIntoCampaign(UserConnection userConnection, Guid campaignId, Guid stepId,
				Guid contactId) {
			var merged = false;
			var dataValueTypeManager = userConnection.DataValueTypeManager;
			var booleanDataType = dataValueTypeManager.GetInstanceByName("Boolean");
			var sp = new StoredProcedure(userConnection,
				"tsp_CampaignStepHandler_CanMergeContactIntoCampaign");
			sp.WithParameter("CampaignId", campaignId);
			sp.WithParameter("StepId", stepId);
			sp.WithParameter("ContactId", contactId);
			sp.WithOutputParameter("Result", booleanDataType);
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				sp.Execute(dbExecutor);
				if (sp.Parameters[3].Value is bool) {
					merged = (bool)sp.Parameters[3].Value;
				}
			}
			return merged;
		}

		/// <summary>
		/// Moves contact onto required step of the campaign.
		/// </summary>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		/// <param name="campaignId">Unique identifier of the Campaign.</param>
		/// <param name="stepId">Unique identifier of the CampaignStep.</param>
		/// <param name="contactId">Unique identifier of the Contact.</param>
		public static void MergeContactIntoCampaign(UserConnection userConnection, Guid campaignId, Guid stepId,
			Guid contactId) {
			var sp = new StoredProcedure(userConnection, "tsp_CampaignStepHandler_MergeContactIntoCampaign");
			sp.WithParameter("CampaignId", campaignId);
			sp.WithParameter("StepId", stepId);
			sp.WithParameter("ContactId", contactId);
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				sp.Execute(dbExecutor);
			}
		}

		/// <summary>
		/// Creates immediately job that executes the SendImmediatelyTriggeredEmailProcess process.
		/// </summary>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		/// <param name="parameters">Set of the process parameters.</param>
		public static void CreateSendEmailImmediatelyJob(UserConnection userConnection,
				IDictionary<string, object> parameters) {
			var jobName = string.Format(SendEmailImmediatelyJobNamePattern, Guid.NewGuid());
			try {
				MailingSchedulerUtilities.CreateImmediatelyJob(userConnection, jobName,
					SendEmailImmediatelyJobGroupName, SendImmediatelyTriggeredEmailProcessName, parameters);
				MailingUtilities.Log.InfoFormat("[CampaignHelper.CreateSendEmailImmediatelyJob]: " +
					"Job {0} for process {1}", jobName, SendImmediatelyTriggeredEmailProcessName);
			} catch (Exception exception) {
				MailingUtilities.Log.ErrorFormat("[CampaignHelper.CreateSendEmailImmediatelyJob]: " +
					"Error while scheduling job {0}", exception, jobName);
				throw;
			}
		}

		/// <summary>
		/// Returns pair of identifiers of the BulkEmail, Id as the Key and RId as the Value.
		/// </summary>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		/// <param name="stepId">Unique identifier of the CampaignStep.</param>
		/// <returns>Identifiers of the BulkEmail.</returns>
		public static KeyValuePair<Guid, int> GetImmediatelyTriggerBulkEmailIdentifierByStepId(
				UserConnection userConnection, Guid stepId) {
			var identifier = new KeyValuePair<Guid, int>(Guid.Empty, -1);
			var select = GetImmediatelyTriggerBulkEmailIdentifierByStepIdSelect(userConnection, stepId);
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					var bulkEmailIdColumnIndex = reader.GetOrdinal("Id");
					var bulkEmailRIdColumnIndex = reader.GetOrdinal("RId");
					if (reader.Read()) {
						var bulkEmailId = reader.GetGuid(bulkEmailIdColumnIndex);
						var bulkEmailRId = reader.GetInt32(bulkEmailRIdColumnIndex);
						identifier = new KeyValuePair<Guid, int>(bulkEmailId, bulkEmailRId);
					}
				}
			}
			return identifier;
		}

		/// <summary>
		/// Returns collection of the Campaigns that assignet with required GeneratedWebForm,
		/// each item of the collection contains Id of the Campaign as Key and Id of the CampaignStep as its Value.
		/// </summary>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		/// <param name="landingId">Unique identifier of the GeneratedWebForm.</param>
		/// <returns>Collection of the Campaigns.</returns>
		public static Dictionary<Guid, Guid> GetCampaignListByLandingId(UserConnection userConnection,
				Guid landingId) {
			var select = GetCampaignListByLandingIdSelect(userConnection, landingId);
			var result = new Dictionary<Guid, Guid>();
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					var campaignIdColumnIndex = reader.GetOrdinal("CampaignId");
					var campaignLendingStepIdColumnIndex = reader.GetOrdinal("CampaignLendingStepId");
					while (reader.Read()) {
						var campaignId = reader.GetGuid(campaignIdColumnIndex);
						var campaignLendingStepId = reader.GetGuid(campaignLendingStepIdColumnIndex);
						result[campaignId] = campaignLendingStepId;
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Returns query for audience of campaign that should be moved to bulk email.
		/// </summary>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		/// <param name="campaignId">Unique identifier of the Campaign.</param>
		/// <param name="bulkEmailId">Unique identifier of the BulkEmail.</param>
		/// <param name="stepId">Unique identifier of the CampaignStep.</param>
		public static Select GetCampaignAudienceToBulkEmailSelect(UserConnection userConnection, Guid campaignId,
				Guid bulkEmailId, Guid stepId) {
			var bulkEmailRId = BulkEmailQueryHelper.GetBulkEmailRId(bulkEmailId, userConnection);
			var unixTimestamp = Utilities.ConvertDateTimeToTimestamp(DateTime.UtcNow);
			var unsubscribeSubSelect = GetBulkEmailUnsubscribeSelect(userConnection, bulkEmailId);
			var existingRecipientsSelect = GetExistingRecipientsSelect(userConnection);
			var mainQuery = new Select(userConnection)
				.Column("main", "BulkEmailRId")
				.Column("main", "ContactRId")
				.Column("main", "EmailAddress")
				.Column(Column.Parameter(unixTimestamp)).As("Timestamp")
				.From(new Select(userConnection)
					.Column(Column.Parameter(bulkEmailRId)).As("BulkEmailRId")
					.Column("C", "Id").As("ContactId")
					.Column("C", "RId").As("ContactRId")
					.Column("C", "Email").As("EmailAddress")
					.Column(Column.Parameter(unixTimestamp)).As("Timestamp")
					.From("CampaignTarget").As("CT")
					.InnerJoin("Contact").As("C").On("CT", "ContactId").IsEqual("C", "Id")
					.Where("CT", "CampaignId").IsEqual(Column.Parameter(campaignId))
					.And("CT", "NextStepId").IsEqual(Column.Parameter(stepId)) as Select).As("main")
				.Where().Not().Exists(existingRecipientsSelect)
				.And().Not().Exists(unsubscribeSubSelect) as Select;
			mainQuery.SpecifyNoLockHints();
			return mainQuery;
		}

		/// <summary>
		/// Updates TargetAchieve counter of the Campaign.
		/// </summary>
		/// <param name="campaignId">Unique identifier of the Campaign.</param>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		public static void UpdateCampaignTargetAchieve(Guid campaignId, UserConnection userConnection) {
			var countQuery = new Select(userConnection)
				.Column(Func.Count("CT", "Id"))
				.From("CampaignTarget").As("CT")
				.LeftOuterJoin("CampaignStep").As("CCS").On("CCS", "Id").IsEqual("CT", "CurrentStepId")
				.LeftOuterJoin("CampaignStep").As("NCS").On("NCS", "Id").IsEqual("CT", "NextStepId")
				.Where("CT", "CampaignId").IsEqual(Column.Parameter(campaignId))
				.And()
				.OpenBlock("CCS", "TypeId")
				.IsEqual(Column.Parameter(CampaignConsts.GoalCampaignStepTypeId))
				.Or("NCS", "TypeId").IsEqual(Column.Parameter(CampaignConsts.GoalCampaignStepTypeId))
				.CloseBlock() as Select;
			countQuery.SpecifyNoLockHints();
			var countResult = countQuery.ExecuteScalar<int>();
			var updateQuery = new Update(userConnection, "Campaign")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ModifiedById", Column.Parameter(userConnection.CurrentUser.Id))
				.Set("TargetAchieve", Column.Parameter(countResult))
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Update;
			updateQuery.Execute();
		}

		/// <summary>
		/// Updates TargetAchieve counter of the Campaigns.
		/// </summary>
		/// <param name="campaignIdCollection">Collection of the Campaigns identifiers.</param>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		public static void UpdateCampaignsTargetAchieve(IEnumerable<Guid> campaignIdCollection,
				UserConnection userConnection) {
			foreach (var campaignId in campaignIdCollection) {
				UpdateCampaignTargetAchieve(campaignId, userConnection);
			}
		}

		/// <summary>
		/// Increase counter of the Campaign audience.
		/// </summary>
		/// <param name="campaignId">Unique identifier of the Campaign.</param>
		/// <param name="count">Increment count.</param>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		[Obsolete("7.8.3 | Method is deprecated")]
		public static int IncCampaignRecipietCount(Guid campaignId, int count, UserConnection userConnection) {
			var update = new Update(userConnection, "Campaign")
				.Set("TargetTotal", QueryColumnExpression.Add(new QueryColumnExpression("TargetTotal"),
					Column.Parameter(count)))
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Update;
			return update.Execute();
		}

		/// <summary>
		/// Adds contact into campaign audience.
		/// </summary>
		/// <param name="campaignId">Unique identifier of Campaign.</param>
		/// <param name="contactId">Unique identifier of Contact.</param>
		/// <param name="currentStepId">Unique identifier of currrent campaign step.</param>
		/// <param name="nextStepId">Unique identifier of next campaign step.</param>
		/// <param name="modifiedOn">Modification date.</param>
		/// <param name="userConnection">Instance of user connection.</param>
		[Obsolete("7.8.3 | Method is deprecated, use instead CampaignHelper.MergeContactIntoCampaign.")]
		public static int InsertContactToCampaignAudience(Guid campaignId, Guid contactId, Guid currentStepId,
				Guid? nextStepId, DateTime modifiedOn, UserConnection userConnection) {
			var insert = new Insert(userConnection)
				.Into("CampaignTarget")
				.Set("CampaignId", Column.Parameter(campaignId))
				.Set("ContactId", Column.Parameter(contactId))
				.Set("ModifiedOn", Column.Parameter(modifiedOn))
				.Set("CurrentStepId", Column.Parameter(currentStepId))
				.Set("CampaignTargetStatusId", Column.Parameter(CampaignConsts.CampaignTargetStatusPlannedId))
				.Set("IsFromGroup", Column.Parameter(false));
			if (nextStepId.HasValue) {
				insert = insert.Set("NextStepId", Column.Parameter(nextStepId.Value));
			}
			return insert.Execute();
		}

		/// <summary>
		/// Sets Campaign fields.
		/// </summary>
		/// <param name="id">Unique identifier of Campaign.</param>
		/// <param name="fields">Fields to be set.</param>
		/// <param name="userConnection">Instance of user connection.</param>
		public static int SetCampaignFields(Guid id, Dictionary<string, object> fields, 
				UserConnection userConnection) {
			var update = new Update(userConnection, "Campaign")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ModifiedById", Column.Parameter(userConnection.CurrentUser.ContactId))
				.Where("Id").IsEqual(Column.Parameter(id)) as Update;
			foreach (var field in fields) {
				update.Set(field.Key, Column.Parameter(field.Value));
			}
			update.WithHints(new RowLockHint());
			return update.Execute();
		}

		/// <summary>
		/// Gets the campaign with specified fields filled in from DB.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="campaignId">The campaign identifier.</param>
		/// <param name="columnsToFetch">The columns names to fetch.</param>
		/// <returns></returns>
		public static Campaign GetCampaign(UserConnection userConnection, Guid campaignId,
				params string[] columnsToFetch) {
			EntitySchema schema = userConnection.EntitySchemaManager.GetInstanceByName("Campaign");
			Entity campaign = schema.CreateEntity(userConnection);
			IEnumerable<EntitySchemaColumn> columns = schema.Columns.GetByNames(columnsToFetch);
			if (campaign.FetchFromDB(schema.PrimaryColumn, campaignId, columns)) {
				return campaign as Campaign;
			}
			return null;
		}

		/// <summary>
		/// Gets the campaign with specified fields filled in from DB. Instnace method.
		/// </summary>
		/// <param name="campaignId">The campaign identifier.</param>
		/// <param name="columnsToFetch">The columns to fetch.</param>
		/// <returns>Instance of <see cref="Campaign"/>.</returns>
		public virtual Campaign GetCampaign(Guid campaignId,
				params string[] columnsToFetch) {
			return GetCampaign(_userConnection, campaignId, columnsToFetch);
		}

		/// <summary>
		/// Returns lightweight campaign model with status and progress state.
		/// </summary>
		/// <param name="campaignId">The campaign identifier.</param>
		/// <returns>Instance of <see cref="CampaignInfo"/>.</returns>
		public virtual CampaignInfo GetCampaignInfo(Guid campaignId) {
			CampaignInfo campaignInfo = null;
			var select = new Select(_userConnection)
				.Column("InProgress")
				.Column("CampaignStatusId")
				.From("Campaign")
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Select;
			select.SpecifyNoLockHints();
			select.ExecuteReader(dr => {
				campaignInfo = new CampaignInfo {
					CampaignStatusId = dr.GetColumnValue<Guid>("CampaignStatusId"),
					InProgress = dr.GetColumnValue<bool>("InProgress"),
					CampaignId = campaignId
				};
			});
			if (campaignInfo == null) {
				string errorText = GetLczStringValue(CampaignHelperClassName, CampaignNotFoundException);
				throw new Exception(string.Format(errorText, campaignId));
			}
			return campaignInfo;
		}

		/// <summary>
		/// Gets the campaign schema.
		/// </summary>
		/// <param name="campaignId">The campaign identifier.</param>
		/// <returns>Instance of the campaign schema.</returns>
		/// <exception cref="Exception">Will be thrown in case of campaign schema absence.</exception>
		public virtual CoreCampaignSchema GetCampaignSchema(Guid campaignId) {
			var select = new Select(_userConnection)
				.Column("CampaignSchemaUId")
				.From("Campaign")
				.Where("Id")
				.IsEqual(Column.Parameter(campaignId)) as Select;
			var schemaUid = select.ExecuteScalar<Guid>();
			if (schemaUid.IsEmpty()) {
				string message = GetLczStringValue(CampaignHelperClassName, CampaignSchemaNotFoundException);
				throw new Exception(message);
			}
			var schemaManager =
				(CampaignSchemaManager)_userConnection.GetSchemaManager("CampaignSchemaManager");
			return schemaManager.FindInstanceByUId(schemaUid);
		}

		/// <summary>
		/// Sets Campaign fields. Instance method.
		/// </summary>
		/// <param name="id">Unique identifier of Campaign.</param>
		/// <param name="fields">Fields to be set.</param>
		public virtual int SetCampaignFields(Guid id, Dictionary<string, object> fields) {
			return SetCampaignFields(id, fields, _userConnection);
		}

		/// <summary>
		/// Returns localized string by string name. 
		/// </summary>
		/// <param name="className">Class name for localizable string</param>
		/// <param name="lczStringName">String name</param>
		/// <returns>Localizable string</returns>
		public string GetLczStringValue(string className, string lczStringName) {
			string localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczStringName);
			var localizableString = new LocalizableString(
				_userConnection.Workspace.ResourceStorage, className, localizableStringName);
			string value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		#endregion

	}

	#endregion

}
