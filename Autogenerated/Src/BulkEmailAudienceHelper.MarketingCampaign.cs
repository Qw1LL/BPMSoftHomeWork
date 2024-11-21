namespace BPMSoft.Configuration.MandrillService
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Globalization;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Common;
	using BPMSoft.Web.Http.Abstractions;

	public class UpdateTargetAudienceData
	{
		public UpdateTargetAudienceData(UserConnection userConnection, string schemaName, Guid recordId, bool isSetCampaignFirstStep = false) {
			RecordId = recordId;
			SchemaName = schemaName;
			UserConnection = userConnection;
			IsSetCampaignFirstStep = isSetCampaignFirstStep;
		}

		public UserConnection UserConnection {
			get;
			set;
		}

		public Guid RecordId {
			get;
			private set;
		}

		public string SchemaName {
			get;
			private set;
		}

		public bool IsSetCampaignFirstStep {
			get;
			private set;
		}

	}

	#region Class: BulkEmailAudienceHelper

	public class BulkEmailAudienceHelper {

		#region Fields: Private

		private UserConnection _userConnection;

		private static bool _isAnonymousAuthentication = false;

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get {
				if (_userConnection != null) {
					return _userConnection;
				}
				_userConnection = HttpContext.Current.Session["UserConnection"] as UserConnection;
				if (_userConnection != null) {
					return _userConnection;
				}
				if (_isAnonymousAuthentication) {
					var appConnection = (AppConnection)HttpContext.Current.Application["AppConnection"];
					_userConnection = appConnection.SystemUserConnection;
				}
				return _userConnection;
			}
			set {
				_userConnection = value;
			}
		}

		#endregion

		#region Methods: Private
		private void CreateReminding(Entity entity, string lczStringName, params object[] parameters) {
			CreateReminding(entity, lczStringName, GetLczStringValue("RemindingMsgCaption"), parameters);
		}
		
		private void CreateReminding(Entity entity, string lczStringName, string caption, 
				params object[] parameters) {
			string description = string.Empty;
			if (parameters.Any()) {
				description = string.Format(GetLczStringValue(lczStringName), parameters);
			} else {
				description = GetLczStringValue(lczStringName);
			}
			MandrillUtilities.CreateReminding(UserConnection, entity, description, caption);
		}
		
		virtual protected void ExecuteUpdateStatistic(Guid id, UserConnection userConnection) {
			UserConnection = userConnection;
			ProcessSchema schema = 
				UserConnection.ProcessSchemaManager.GetInstanceByName("UpdateBulkEmailStatisticProcess");
			Process process = schema.CreateProcess(UserConnection);
			process.SetPropertyValue("BulkEmailId", id);
			process.Execute(UserConnection);
		}

		virtual protected string GetTransferTableName(BulkEmailSplit bulkEmailSplit, Guid id) {
			var transferTableName = bulkEmailSplit.TransferTableName;
			if (string.IsNullOrEmpty(transferTableName)) {
				transferTableName = string.Format("ST_{0}", id.ToBase36());
				var sp = new StoredProcedure(UserConnection, "tsp_CreateSplitTestTargetTbl");
				sp.WithParameter("tableName", transferTableName);
				sp.Execute();
				bulkEmailSplit.TransferTableName = transferTableName;
				bulkEmailSplit.Save();
			}
			return transferTableName;
		}
		
		virtual protected List<int> GetSplitTestTargetRIdList(BulkEmailSplit bulkEmailSplit, Guid id) {
		//Get split test targets count
		List<int> targets = new List<int>();
		var targetsSelect = new Select(UserConnection)
				.Column("RId")
				.From("BulkEmail")
				.Where("SplitTestId").IsEqual(Column.Parameter(id)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = targetsSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						int bulkEmailRId = reader.GetInt32(0);
						targets.Add(bulkEmailRId);
					}
				}
			}
			return targets;
		}
		
		virtual protected long GetMaxIdFromTransferTable(string tableName) {
			long maxTransferTableId = 0;
			var maxSelect = new Select(UserConnection)
				.Column(Func.Max("Id"))
				.From(tableName);
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = maxSelect.ExecuteReader(dbExecutor)) {
					if (reader.Read() && reader[0] != DBNull.Value) {
						maxTransferTableId = reader.GetInt64(0);
					}
				}
			}
			return maxTransferTableId;
		}
		
		virtual protected void StartUpdateTargetAudience(Guid id, string rootSchemaName, bool isSetCampaignFirstStep,
				string transferTableName) {
			ProcessSchema schema = 
					UserConnection.ProcessSchemaManager.GetInstanceByName("UpdateTargetAudienceProcess");
			Process process = schema.CreateProcess(UserConnection);
			process.SetPropertyValue("RootSchemaRecordId", id);
			if(!String.IsNullOrWhiteSpace(rootSchemaName)) {
				process.SetPropertyValue("RootSchemaName", rootSchemaName);
				process.SetPropertyValue("IsSetCampaignFirstStep", isSetCampaignFirstStep);
			} else {
				process.SetPropertyValue("RootSchemaName", "BulkEmailSplit");
				process.SetPropertyValue("RootSchemaRecordRId", 1);
				process.SetPropertyValue("TargetSchemaBindingColumnValueName", "BulkEmailSplitId");
				process.SetPropertyValue("TargetSchemaName", transferTableName);
				process.SetPropertyValue("SegmentSchemaName", "BulkEmailSplitSegment");
			}
			process.Execute(UserConnection);
		}

		protected void InsertRecipientsIntoBulkEmails(int newRecipientsCount, int recipientsPerEmail, 
				int initialLowBound, int targetsCount, List<int> targets, string transferTableName) {
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.CommandTimeout = 1800;
				int maxRowsInQuery = 100000;
				int batchesCount = recipientsPerEmail / maxRowsInQuery;
				if (recipientsPerEmail % maxRowsInQuery > 0) {
					batchesCount++;
				}
				for (int i = 0; i < targetsCount; i++) {
					int bulkEmailRId = targets[i];
					int audienceCount = 0;
					//Batch counter
					int lowBound = i * recipientsPerEmail;
					int highBound = lowBound;
					for (int j = 0; j < batchesCount; j++) {
						if (recipientsPerEmail < (maxRowsInQuery * (j + 1))) {
							highBound += recipientsPerEmail - (maxRowsInQuery * j);
						} else {
							highBound += maxRowsInQuery;
						}
						//Build insertSelect
						var innerSelect = new Select(UserConnection)
							.Top(recipientsPerEmail)
							.Column("BulkEmailId").As("BulkEmailId")
							.Column("EmailAddress").As("EmailAddress")
							.Column("ContactId").As("ContactId")
							.Column("ContactId").As("LinkedEntityId")
							.Column(Column.Parameter(MailingConsts.BulkEmailResponseReadyToSendId)).As("BulkEmailResponseId")
							.From(new Select(UserConnection)
								.Column("be", "Id").As("BulkEmailId")
								.Column("tt", "EmailAddress").As("EmailAddress")
								.Column("c","Id").As("ContactId")
								.Column(new WindowQueryFunction(
									new RowNumberQueryFunction(),
									null,
									new QueryColumnExpression("Order"))).As("RowNum")
								.From(transferTableName, "tt")
								.InnerJoin("BulkEmail").As("be").On("be", "RId").IsEqual(Column.Parameter(bulkEmailRId))
								.InnerJoin("Contact").As("c").On("c", "RId").IsEqual("tt", "ContactRId")
								.Where("tt", "Id").IsGreater(Column.Parameter(initialLowBound))
							).As("middleSelect")
							.Where("RowNum").IsBetween(Column.Parameter(lowBound + 1))
							.And(Column.Parameter(highBound));
						InsertSelect insertSelect = new InsertSelect(UserConnection)
							.Into("BulkEmailTarget")
							.Set("BulkEmailId", "EmailAddress", "ContactId", "LinkedEntityId", "BulkEmailResponseId")
						.FromSelect(innerSelect);
						//Do it
						lowBound = highBound;
						audienceCount += insertSelect.Execute(dbExecutor);
					}
					//Update BulkEmail Recipient Counter
					var update = new Update(UserConnection, "BulkEmail")
						.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
						.Set("RecipientCount", QueryColumnExpression.Add(
							new QueryColumnExpression("RecipientCount"),
							Column.Parameter(audienceCount)))
						.Set("SegmentsStatusId", Column.Parameter(MarketingConsts.SegmentStatusUpdatedId))
						.Where("RId").IsEqual(Column.Parameter(bulkEmailRId))
						.Execute(dbExecutor);
				}
			}
		}

		virtual protected void ExecuteUpdateSplitTestAudience(Guid id, UserConnection userConnection) {
			UserConnection = userConnection;
			//Check current segments state and set it to "RequiresUpdating" when need
			bool updateInProcess = IsSchemaAudienceUpdateInProcess("BulkEmailSplit", id);
			if (updateInProcess) {
				SetSchemaSegmentStatus("BulkEmailSplit", id);
				return;
			}
			processStart:
			//Read split test entity
			var bulkEmailSplit = new BulkEmailSplit(UserConnection);
			if (!bulkEmailSplit.FetchFromDB(id)) {
				MandrillUtilities.Log.ErrorFormat(
					"[MandrillService.ExecuteUpdateSplitTestAudience]: Failed to fetch BulkEmailSplit from DB." +
					"Id: {0}", id);
				return;
			}
			//Get split test targets count
				
			List<int> targets = null;
			try {
				targets = GetSplitTestTargetRIdList(bulkEmailSplit, id);
			} catch (Exception e) {
				MandrillUtilities.Log.ErrorFormat(
					"[MandrillService.ExecuteUpdateSplitTestAudience]: Failed to read email from BulkEmailSplit." +
					"Id: {0}", id, e);
				return;
			}
			//Check targets count
			int targetsCount = targets.Count;
			if (targetsCount <= 1) {
				return;
			}
			
			//CreateTempTable
			string transferTableName = string.Empty;
			try {
				 transferTableName = GetTransferTableName(bulkEmailSplit, id);
			} catch (Exception e) {
					MandrillUtilities.Log.ErrorFormat(
						"[MandrillService.ExecuteUpdateSplitTestAudience]: UpdateTargetAudienceProcess " +
						"Creation of temp table failed. BulkEmailSplit.Id: {0}", id, e);
					return;
			}
			
			long initialLowBound = GetMaxIdFromTransferTable(transferTableName);
			
			//Check percent
			double percent = Convert.ToDouble(bulkEmailSplit.RecipientPercent);
			if (percent <= 0) {
				return;
			}
			if (percent > 100) {
				percent = 100;
			}
			int initialRecipientCount = bulkEmailSplit.RecipientCount;
			//Fill temp table with audience
			try {
				StartUpdateTargetAudience(id, "", false, transferTableName);
			} catch (Exception e) {
				MandrillUtilities.Log.ErrorFormat(
					"[MandrillService.ExecuteUpdateSplitTestAudience]: UpdateTargetAudienceProcess failed." +
					"BulkEmailSplit.Id: {0}", id, e);
				return;
			}		
			//Read split test entity
			bulkEmailSplit = new BulkEmailSplit(UserConnection);
			if (!bulkEmailSplit.FetchFromDB(id)) {
				MandrillUtilities.Log.ErrorFormat(
					"[MandrillService.ExecuteUpdateSplitTestAudience]: Failed to fetch BulkEmailSplit from DB." +
					"Id: {0}", id);
				return;
			}
			int newRecipientsCount = bulkEmailSplit.RecipientCount - initialRecipientCount;
			//Check added recipients count
			if (newRecipientsCount <= 0) {
				CreateReminding(bulkEmailSplit, "UpdateSplitTestAudienceSuccessMessage", 
					bulkEmailSplit.Schema.Caption.ToString(), 0, 0);
				return;
			}
			//calc recipients per email count
			int recipientsPerEmail = Convert.ToInt32(Math.Floor(
				Convert.ToDouble(newRecipientsCount) / Convert.ToDouble(targetsCount) / 100.0 * percent
			));
			//Check recipients count
			if (recipientsPerEmail <= 0) {
				//restore recipients list
				new Delete(UserConnection).From(transferTableName)
					.Where("Id").IsGreater(Column.Parameter(initialRecipientCount))
					.Execute();
				//restore SpltTest state
				new Update(UserConnection, "BulkEmailSplit")
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Set("SegmentsStatusId", Column.Parameter(MarketingConsts.SegmentStatusUpdatedId))
					.Set("RecipientCount", Column.Parameter(initialRecipientCount))
					.Where("Id").IsEqual(Column.Parameter(bulkEmailSplit.Id))
					.Execute();
				CreateReminding(bulkEmailSplit, "UpdateSplitTestAudienceSuccessMessage", 
					bulkEmailSplit.Schema.Caption.ToString(), 0, 0);
				return;
			}
			try {
				//Insert recipients to target BulkEmail
				InsertRecipientsIntoBulkEmails(newRecipientsCount, recipientsPerEmail,
						initialRecipientCount, targetsCount, targets, transferTableName);
				} catch (Exception e) {
				MandrillUtilities.Log.ErrorFormat(
					"[MandrillService.ExecuteUpdateSplitTestAudience]: Failed to spread test audience betwean email." +
					"Id: {0}", id, e);
				return;
			}
			if (IsSchemaSegmentsStatusEquals("BulkEmailSplit", id, MarketingConsts.SegmentStatusRequiresUpdatingId)) {
				goto processStart;
			}
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				new Update(UserConnection, "BulkEmailSplit")
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Set("SegmentsStatusId", Column.Parameter(MarketingConsts.SegmentStatusUpdatedId))
					.Set("TestRecipientCount", new Select(UserConnection)
						.Column(Func.Sum("RecipientCount"))
						.From("BulkEmail")
						.Where("RId").In(Column.Parameters(targets))
					)
					.Where("Id").IsEqual(Column.Parameter(bulkEmailSplit.Id))
					.Execute(dbExecutor);
			}
			int contactsAdded = recipientsPerEmail * targetsCount;
			CreateReminding(bulkEmailSplit, "UpdateSplitTestAudienceSuccessMessage", 
				bulkEmailSplit.Schema.Caption.ToString(), contactsAdded, newRecipientsCount);
		}

		virtual protected bool IsSchemaSegmentsStatusEquals(string schemaName, Guid recordId, Guid statusId) {
			Select checkStatusQuery = (Select)new Select(UserConnection)
				.Column("Id")
				.From(schemaName)
				.Where("Id").IsEqual(Column.Parameter(recordId))
				.And("SegmentsStatusId").IsEqual(Column.Parameter(statusId));
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = checkStatusQuery.ExecuteReader(dbExecutor)) {
					return reader.Read();
				}
			}
		}

		virtual protected bool IsSchemaAudienceUpdateInProcess(string schemaName, Guid recordId) {
			return IsSchemaSegmentsStatusEquals(schemaName, recordId, MarketingConsts.SegmentStatusUpdatingId);
		}

		virtual protected void SetSchemaSegmentStatus(string schemaName, Guid recordId) {
			new Update(UserConnection, schemaName)
					.Set("SegmentsStatusId",
						Column.Parameter(MarketingConsts.SegmentStatusRequiresUpdatingId))
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Set("ModifiedById", Column.Parameter(MarketingConsts.MandrillUserId))
					.Where("Id").IsEqual(Column.Parameter(recordId))
					.Execute();
		}

		virtual protected void ExecuteUpdateTargetAudience(UpdateTargetAudienceData data) {
			UserConnection = data.UserConnection;
			string schemaName = data.SchemaName;
			Guid recordId = data.RecordId;
			bool isSetCampaignFirstStep = data.IsSetCampaignFirstStep;
			bool updateInProcess = IsSchemaAudienceUpdateInProcess(schemaName, recordId);
			if (updateInProcess) {
				SetSchemaSegmentStatus(schemaName, recordId);
			} else {
				StartUpdateTargetAudience(recordId, schemaName, isSetCampaignFirstStep, "");
			}
		}


		#endregion

		#region Methods: Public
		/// <summary>
		/// Creates a scheduler in the schedule for updating the target audience.
		/// </ summary>
		/// <param name = "schemaName"> The schema name. </ Param>
		/// <param name = "recordId"> The unique identifier of the entry in the schema. </ Param>
		virtual public void UpdateSplitTestAudience(UserConnection userConnection, Guid recordId) {
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			Task.Factory.StartNew(() => {
				Thread.CurrentThread.CurrentCulture = culture;
				ExecuteUpdateSplitTestAudience(recordId, userConnection);
			});
		}

		virtual public void UpdateSplitTestAudience(UpdateTargetAudienceData parametrs) {
			ExecuteUpdateSplitTestAudience(parametrs.RecordId, parametrs.UserConnection);
		}

		/// <summary>
		/// Creates a task in the scheduler's schedule to update the target audience.
		/// </ summary>
		/// <param name = "schemaName"> The schema name. </ Param>
		/// <param name = "recordId"> The unique identifier of the record in the schema. </ Param>
		/// <param name = "isSetCampaignFirstStep"> A sign that you want to set the first step for the campaign audience. </ Param>
		virtual public void UpdateTargetAudience(UserConnection userConnection, string schemaName, Guid recordId, bool isSetCampaignFirstStep = false) {
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			Task.Factory.StartNew(() => {
				Thread.CurrentThread.CurrentCulture = culture;
				ExecuteUpdateTargetAudience(new UpdateTargetAudienceData(userConnection, schemaName, recordId, isSetCampaignFirstStep));
			});
		}

		virtual public void UpdateTargetAudience(UpdateTargetAudienceData parameters) {
			ExecuteUpdateTargetAudience(parameters);
		}

		/// <summary>
		/// Starts the process of updating statistics for the Mandrill distribution.
		/// </ summary>
		/// <param name = "id"> The unique Mandrill distribution ID. </ Param>
		virtual public void UpdateStatistic(UserConnection userConnection, Guid id) {
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			System.Threading.Tasks.Task.Factory.StartNew(() => {
				Thread.CurrentThread.CurrentCulture = culture;
				ExecuteUpdateStatistic(id, userConnection);
			});
		}

		
		private string GetLczStringValue(string lczName) {
			string localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(
				UserConnection.Workspace.ResourceStorage, "MandrillService", localizableStringName);
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
