namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Core;
	using Core.DB;
	using Core.Factories;
	using Marketing.Utilities;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;

	#region Class: BulkEmailAudienceDataSource

	/// <summary>
	/// Implements realization for retrieving audience of the bulk email.
	/// </summary>
	[Obsolete("Will be removed after 7.17.3")]
	public class BulkEmailAudienceDataSource : IMailingAudienceDataSource, IDCAudienceDataSource
	{

		#region Constants: Private

		private const int QueryBatchSize = 1000;
		private const string RecipientTableName = "BulkEmailTarget";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly int _batchSize;
		private readonly Lazy<BulkEmail> _bulkEmailLazy;
		private readonly Guid _bulkEmailId;
		private readonly Guid _mailingSessionId = Guid.Empty;
		private readonly int _bulkEmailExpirationPeriod;
		private readonly Lazy<Dictionary<Guid, int>> _duplicatingRecipients;
		private Lazy<Dictionary<Guid, int>> _limitedRecipients;
		private readonly BulkEmailRecipientMacroRepository _bulkEmailRecipientMacroRepository;

		#endregion

		#region Properties: Private

		private BulkEmail _bulkEmail { get => _bulkEmailLazy.Value; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BulkEmailAudienceDataSource"/> class.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="batchSize">Size of the batch of the recipients to select.</param>
		public BulkEmailAudienceDataSource(UserConnection userConnection, Guid bulkEmailId, int batchSize) {
			_userConnection = userConnection;
			var argsRecipientMacroRepository = GetArgumentsRecipientMacroRepository(userConnection);
			_bulkEmailRecipientMacroRepository =
				ClassFactory.Get<BulkEmailRecipientMacroRepository>(argsRecipientMacroRepository);
			_batchSize = batchSize;
			_bulkEmailId = bulkEmailId;
			_bulkEmailLazy = new Lazy<BulkEmail>(() => InitializeBulkEmailEntity());
			_bulkEmailExpirationPeriod = (int)Core.Configuration.SysSettings.GetValue(userConnection,
				"BulkEmailExpirationPeriod");
			_duplicatingRecipients = new Lazy<Dictionary<Guid, int>>(GetAudienceDuplicateResponses);
			InitCommunicationRestrictions(userConnection, bulkEmailId);
		}

		private BulkEmail InitializeBulkEmailEntity() {
			var bulkEmail = new BulkEmail(_userConnection);
			bulkEmail.FetchFromDB("Id", _bulkEmailId, new[] {
				"Id", "Category","Type", "SendStartDate", "StartDate", "IsSystemEmail"
			});
			return bulkEmail;

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BulkEmailAudienceDataSource"/> class with the bulk mailing sessionId.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="sessionId">Mailing session identifier.</param>
		/// <param name="batchSize">Size of the batch of the recipients to select.</param>
		public BulkEmailAudienceDataSource(UserConnection userConnection, Guid bulkEmailId, int batchSize, Guid sessionId)
			: this(userConnection, bulkEmailId, batchSize) {
			_mailingSessionId = sessionId;
		}

    #endregion

		#region Properties: Private

		private int _bulkEmailRId;
		private int BulkEmailRId {
			get {
				return _bulkEmailRId == 0
					? _bulkEmailRId = BulkEmailQueryHelper.GetBulkEmailRId(_bulkEmailId, _userConnection)
					: _bulkEmailRId;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the number of the current page.
		/// </summary>
		public int PageNumber { get; set; }

		/// <summary>
		/// Get size of last recieved batch.
		/// </summary>
		public int LastBatchSize { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance works with bulk email containing dynamic template.
		/// </summary>
		public bool IsDCBulkEmail { get; set; }

		#endregion

		#region Methods: Private

		private Dictionary<string, string> DeserializeMacrosFromReader(IDataReader reader, int macrosColumnIndex) {
			var macrosString = reader.IsDBNull(macrosColumnIndex) ? string.Empty : reader.GetString(macrosColumnIndex);
			var macros = string.IsNullOrEmpty(macrosString)
				? new Dictionary<string, string>()
				: _bulkEmailRecipientMacroRepository.ParseBulkEmailMacroInfo(macrosString)
					.ToDictionary(x => x.Alias, x => x.Value);
			return macros;
		}

		private void InitCommunicationRestrictions(UserConnection userConnection, Guid bulkEmailId) {
			_limitedRecipients = new Lazy<Dictionary<Guid, int>>(() => {
				var isFeatureEnabled = userConnection.GetIsFeatureEnabled("EmailCommunicationRestriction");
				if (!isFeatureEnabled || _bulkEmail.IsSystemEmail) {
					return new Dictionary<Guid, int>();
				}
				var args = new[] {
					new ConstructorArgument("userConnection", userConnection),
					new ConstructorArgument("bulkEmailId", bulkEmailId),
					new ConstructorArgument("sessionId", _mailingSessionId)
				};
				var communicationRestrictionRepository = ClassFactory.Get<EmailCommunicationRestrictionRepository>(args);
				return communicationRestrictionRepository.GetAudienceLimitResponses();
			});
		}

		private ConstructorArgument[] GetArgumentsRecipientMacroRepository(UserConnection userConnection) {
			return new[] {
				new ConstructorArgument("userConnection", userConnection)
			};
		}

		private Dictionary<Guid, int> GetAudienceDuplicateResponses() {
			var result = new Dictionary<Guid, int>();
			var checkDuplicates =
				(bool)Core.Configuration.SysSettings.GetValue(_userConnection, "PreventDuplicatesSending");
			if (!checkDuplicates) {
				return result;
			}
			var rootSelect = new Select(_userConnection)
				.Column(RecipientTableName, "MandrillId").As("RecipientUId")
				.Column(new WindowQueryFunction(
					new RowNumberQueryFunction(),
					new QueryColumnExpression("EmailAddress"),
					new QueryColumnExpression(RecipientTableName, "Id"))).As("RowNum")
				.From(RecipientTableName)
				.Where(RecipientTableName, "BulkEmailId").IsEqual(Column.Parameter(_bulkEmailId));
			var responseSelect = new Select(_userConnection)
				.Column("RecipientUId")
				.From(rootSelect).As("SourceRecords")
				.Where("RowNum").IsGreater(Column.Parameter(1)) as Select;
			responseSelect.SpecifyNoLockHints();
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				using (var reader = responseSelect.ExecuteReader(dbExecutor)) {
					var uidColumnIndex = reader.GetOrdinal("RecipientUId");
					while (reader.Read()) {
						var id = reader.GetGuid(uidColumnIndex);
						result[id] = (int)MailingResponseCode.Duplicated;
					}
				}
			}
			return result;
		}

		private Select AddRestrictionsToRecipientsBatchSelect(Select select) {
			return select.Where(RecipientTableName, "BulkEmailId").IsEqual(Column.Parameter(_bulkEmailId))
				.And(RecipientTableName, "BulkEmailResponseId")
				.IsEqual(Column.Parameter(MailingConsts.BulkEmailResponseReadyToSendId)) as Select;
		}

		private void AddRestrictionsBasedOnRecipientSubscriptions(Select select) {	
			select.LeftOuterJoin("BulkEmailSubscription").On("BulkEmailSubscription", "ContactId")	
				.IsEqual("Contact", "Id").And("BulkEmailSubscription", "BulkEmailTypeId")	
				.IsEqual(Column.Parameter(_bulkEmail.TypeId));	
		}
		
		private Select GetRecipientsNonPageableBatchSelect() {
			var recipientSelect = new Select(_userConnection)
				.Column(RecipientTableName, "ContactId").As("ContactId")
				.Column(RecipientTableName, "EmailAddress").As("EmailAddress")
				.Column("Contact", "RId").As("ContactRId")
				.Column(RecipientTableName, "MandrillId").As("RecipientUId")
				.From(RecipientTableName)
				.InnerJoin("Contact").On(RecipientTableName, "ContactId").IsEqual("Contact", "Id") as Select;
			recipientSelect = AddRestrictionsToRecipientsBatchSelect(recipientSelect);
			recipientSelect.SpecifyNoLockHints();
			return recipientSelect;
		}

		private Select GetRecipientsPageableBatchSelect() {
			var bulkEmailCategoryId = _bulkEmail.CategoryId;
			var responseCase = GetDefaultResponseCase(_bulkEmail.IsSystemEmail);
			var innerRecipientSelect = new Select(_userConnection)
				.Column(RecipientTableName, "ContactId").As("ContactId")
				.Column(RecipientTableName, "EmailAddress").As("EmailAddress")
				.Column("Contact", "RId").As("ContactRId")
				.Column(RecipientTableName, "MandrillId").As("RecipientUId")
				.Column("BulkEmailRecipientReplica", "DCReplicaId").As("DCReplicaId")
				.Column(responseCase).As("InitialResponseCode")
				.Column(new WindowQueryFunction(
					new RowNumberQueryFunction(),
					null,
					new QueryColumnExpression(RecipientTableName, "Id"))).As("RowNum")
				.From(RecipientTableName)
				.InnerJoin("Contact").On(RecipientTableName, "ContactId").IsEqual("Contact", "Id")
				.LeftOuterJoin("BulkEmailRecipientReplica")
				.On(RecipientTableName, "MandrillId").IsEqual("BulkEmailRecipientReplica", "RecipientId") as Select;
			innerRecipientSelect = AddRestrictionsToRecipientsBatchSelect(innerRecipientSelect);
			AddRestrictionsBasedOnRecipientSubscriptions(innerRecipientSelect);
			var lowPackageEdge = GetLowPackageEdge();
			var highPackageEdge = GetHighPackageEdge();
			var recipientSelect = new Select(_userConnection)
				.Column("MandrillDeliveryPackage", "ContactRId")
				.Column("MandrillDeliveryPackage", "EmailAddress")
				.Column("MandrillDeliveryPackage", "ContactId")
				.Column("MandrillDeliveryPackage", "RecipientUId")
				.Column("MandrillDeliveryPackage", "DCReplicaId")
				.Column("MandrillDeliveryPackage", "InitialResponseCode")
				.Column("BulkEmailRecipientMacro", "Macros")
				.From(innerRecipientSelect)
				.As("MandrillDeliveryPackage")
				.LeftOuterJoin("BulkEmailRecipientMacro")
				.On("BulkEmailRecipientMacro", "RecipientUId").IsEqual("MandrillDeliveryPackage", "RecipientUId")
				.Where("RowNum").IsBetween(Column.Parameter(lowPackageEdge))
				.And(Column.Parameter(highPackageEdge)) as Select;
			recipientSelect.SpecifyNoLockHints();
			return recipientSelect;
		}

		private Select GetRecipientsIdsPageableBatchSelect(Guid replicaId) {
			var innerRecipientSelect = new Select(_userConnection)
				.Column("Contact", "Id").As("ContactId")
				.Column(RecipientTableName, "MandrillId").As("RecipientUId")
				.Column(new WindowQueryFunction(
					new RowNumberQueryFunction(),
					null,
					new QueryColumnExpression(RecipientTableName, "Id"))).As("RowNum")
				.From(RecipientTableName)
				.InnerJoin("Contact").On(RecipientTableName, "ContactId").IsEqual("Contact", "Id") as Select;
			if (replicaId != Guid.Empty) {
				innerRecipientSelect = innerRecipientSelect.InnerJoin("BulkEmailRecipientReplica")
					.On(RecipientTableName, "MandrillId").IsEqual("BulkEmailRecipientReplica", "RecipientId")
					.And("BulkEmailRecipientReplica", "DCReplicaId").IsEqual(Column.Parameter(replicaId))
					.And("BulkEmailRecipientReplica", "BulkEmailId").IsEqual(Column.Parameter(_bulkEmail.Id)) as Select;
			}
			innerRecipientSelect = AddRestrictionsToRecipientsBatchSelect(innerRecipientSelect);
			var lowPackageEdge = GetLowPackageEdge();
			var highPackageEdge = GetHighPackageEdge();
			var recipientSelect = new Select(_userConnection)
				.Column("MandrillDeliveryPackage", "ContactId")
				.Column("MandrillDeliveryPackage", "RecipientUId")
				.From(innerRecipientSelect)
				.As("MandrillDeliveryPackage")
				.Where("RowNum").IsBetween(Column.Parameter(lowPackageEdge))
				.And(Column.Parameter(highPackageEdge)) as Select;
			recipientSelect.SpecifyNoLockHints();
			return recipientSelect;
		}

		private Select GetRecipientsIdsSelect(Guid replicaId) {
			var innerRecipientSelect = new Select(_userConnection)
				.Column("Contact", "Id").As("ContactId")
				.Column(RecipientTableName, "MandrillId").As("RecipientUId")
				.From(RecipientTableName)
				.InnerJoin("Contact")
				.On(RecipientTableName, "ContactId")
				.IsEqual("Contact", "Id") as Select;
			if (replicaId != Guid.Empty) {
				innerRecipientSelect = innerRecipientSelect.InnerJoin("BulkEmailRecipientReplica")
					.On(RecipientTableName, "MandrillId").IsEqual("BulkEmailRecipientReplica", "RecipientId")
					.And("BulkEmailRecipientReplica", "DCReplicaId").IsEqual(Column.Parameter(replicaId))
					.And("BulkEmailRecipientReplica", "BulkEmailId").IsEqual(Column.Parameter(_bulkEmail.Id)) as Select;
			}
			innerRecipientSelect = AddRestrictionsToRecipientsBatchSelect(innerRecipientSelect);
			var recipientSelect = new Select(_userConnection)
				.Column("MandrillDeliveryPackage", "ContactId")
				.Column("MandrillDeliveryPackage", "RecipientUId")
				.From(innerRecipientSelect)
				.As("MandrillDeliveryPackage");
			recipientSelect.SpecifyNoLockHints();
			return recipientSelect;
		}

		private QueryCase GetDefaultResponseCase(bool isSystemEmail) {
			var responseCase = new QueryCase();
			MailingDbUtilities.AddWhenCondition(
				responseCase, "Contact", "Email", QueryConditionType.Equal, string.Empty,
				(int)MailingResponseCode.CanceledBlankEmail);
			MailingDbUtilities.AddWhenCondition(
				responseCase, "Contact", "Email", QueryConditionType.IsNull, null,
				(int)MailingResponseCode.CanceledBlankEmail);
			MailingDbUtilities.AddWhenCondition(
				responseCase, "Contact", "IsNonActualEmail", QueryConditionType.Equal, true,
				(int)MailingResponseCode.CanceledInvalidEmail);
			if (!isSystemEmail) {
				MailingDbUtilities.AddWhenCondition(
					responseCase, "Contact", "DoNotUseEmail", QueryConditionType.Equal, true,
					(int)MailingResponseCode.CanceledDoNotUseEmail);
				MailingDbUtilities.AddWhenCondition(	
					responseCase, "BulkEmailSubscription", "BulkEmailSubsStatusId", QueryConditionType.Equal, 	
					MailingConsts.BulkEmailContactUnsubscribed, (int)MailingResponseCode.CanceledUnsubscribedByType);
			}
			responseCase.ElseExpression =
				new QueryColumnExpression(Column.Parameter((int)MailingResponseCode.PostedProvider));
			return responseCase;
		}

		private Select GetRecipientsBatchSelect(bool usePageable = true) {
			return usePageable
				? GetRecipientsPageableBatchSelect()
				: GetRecipientsNonPageableBatchSelect();
		}

		private int GetLowPackageEdge() {
			return (PageNumber - 1) * _batchSize + 1;
		}

		private int GetHighPackageEdge() {
			return PageNumber * _batchSize;
		}

		private Select ApplyBulkEmailInfoToAudienceSelect(Select audienceSelect, Guid bulkEmailId, Guid sessionUId) {
			var bulkEmailRId = BulkEmailQueryHelper.GetBulkEmailRId(bulkEmailId, _userConnection);
			var select = audienceSelect
				.Column(Column.Parameter(bulkEmailRId)).As("BulkEmailRId")
				.Column(Column.Parameter(sessionUId)).As("SessionUId")
				.Column(Column.Parameter(false)).As("IsSent")
				.Column(Column.Parameter(Utilities.ConvertDateTimeToTimestamp(DateTime.UtcNow))).As("Timestamp");
			return select;
		}

		private Select ApplyBulkEmailUnsubscribedRestrictionSelect(Select audienceSelect, Guid bulkEmailId) {
			var select = new Select(_userConnection)
				.Column(Column.Parameter(1))
				.From("BulkEmailSubscription").As("BulkEmailSubscription")
				.Where("BulkEmailSubscription", "ContactId")
				.IsEqual("Contact", "Id")
				.And("BulkEmailSubscription", "BulkEmailSubsStatusId")
				.IsEqual(Column.Parameter(MarketingConsts.BulkEmailContactUnsubscribed))
				.And("BulkEmailSubscription", "BulkEmailTypeId").In(
					new Select(_userConnection)
						.Column("TypeId")
						.From("BulkEmail")
						.Where("Id").IsEqual(Column.Parameter(bulkEmailId))
				) as Select;
			select.SpecifyNoLockHints();
			audienceSelect.And().Not().Exists(select);
			return audienceSelect;
		}

		private void SetExpirationDate(BulkEmailRecipientInfo recipientInfo, IDataReader dataReader) {
			DateTime messageDate;
			var bulkEmailCategoryId = _bulkEmail.CategoryId;
			if (bulkEmailCategoryId.Equals(MailingConsts.TriggeredEmailBulkEmailCategoryId)) {
				var timestampColumnIndex = dataReader.GetOrdinal("Timestamp");
				if (dataReader[timestampColumnIndex] == DBNull.Value) {
					return;
				}
				var timestamp = _userConnection.DBTypeConverter.DBValueToInt(dataReader[timestampColumnIndex]);
				if (timestamp == 0) {
					return;
				}
				messageDate = Utilities.ConvertTimestampToDateTime(timestamp);
				messageDate = DateTime.SpecifyKind(messageDate, DateTimeKind.Utc);
			} else {
				var timezoneOffset = _userConnection.CurrentUser.TimeZone.GetUtcOffset(_bulkEmail.StartDate);
				if (_bulkEmail.StartDate.Year == DateTime.MinValue.Year) {
					messageDate = DateTime.UtcNow;
				} else {
					messageDate = _bulkEmail.StartDate.Add(-timezoneOffset);
					messageDate = DateTime.SpecifyKind(messageDate, DateTimeKind.Utc);
				}
			}
			recipientInfo.ExpirationDate = messageDate.AddMinutes(_bulkEmailExpirationPeriod);
		}

		private int GetInitialResponseCode(IDataReader reader, BulkEmailRecipientInfo recipientInfo,
			int responseCodeColumnIndex) {
			var initialResponseCode = reader.GetInt32(responseCodeColumnIndex);
			if (initialResponseCode != (int)MailingResponseCode.PostedProvider) {
				return initialResponseCode;
			}
			if (!MailingUtilities.ValidateEmail(recipientInfo.EmailAddress)) {
				initialResponseCode = (int)MailingResponseCode.CanceledIncorrectEmail;
			} else if (_limitedRecipients.Value.ContainsKey(recipientInfo.ContactId)) {
				initialResponseCode = _limitedRecipients.Value[recipientInfo.ContactId];
			} else if (_duplicatingRecipients.Value.ContainsKey(recipientInfo.Id)) {
				initialResponseCode = _duplicatingRecipients.Value[recipientInfo.Id];
			} else if (recipientInfo.ReplicaId == Guid.Empty) {
				initialResponseCode = (int)MailingResponseCode.CanceledTemplateNotFound;
			}
			return initialResponseCode;
		}

		private void AddColumnWithoutDisplayValue(EntitySchemaQuery esq, EntitySchema schema, string column) {
			var columnExpression = EntitySchemaQuery.CreateSchemaColumnQueryExpression(column, schema);
			columnExpression.UId = Guid.NewGuid();
			esq.AddColumn(new EntitySchemaQueryColumn(column) {
				ValueExpression = columnExpression
			});
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets actual Select query object for fetching of batch of recipints (after calling of GetAudience method).
		/// </summary>
		/// <returns>Instance of <see cref="Select"/>.</returns>
		public Select GetRecipientsSelectQuery() {
			return GetRecipientsPageableBatchSelect();
		}

		/// <summary>
		/// Gets the audience of the bulk email to send.
		/// </summary>
		/// <returns>List of <see cref="IMessageRecipientInfo"/>.</returns>
		public List<IMessageRecipientInfo> GetAudience() {
			if (PageNumber <= 0) {
				PageNumber = 1;
			}
			var recipientsSelect = GetRecipientsBatchSelect();
			var result = new List<IMessageRecipientInfo>();
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				using (var reader = recipientsSelect.ExecuteReader(dbExecutor)) {
					var emailColumnIndex = reader.GetOrdinal("EmailAddress");
					var contactRIdColumnIndex = reader.GetOrdinal("ContactRId");
					var contactIdColumnIndex = reader.GetOrdinal("ContactId");
					var uidColumnIndex = reader.GetOrdinal("RecipientUId");
					var macrosColumnIndex = reader.GetOrdinal("Macros");
					var replicaIdColumnIndex = reader.GetOrdinal("DCReplicaId");
					var responseCodeColumnIndex = reader.GetOrdinal("InitialResponseCode");
					while (reader.Read()) {
						var address = reader.GetString(emailColumnIndex).Trim();
						var macros = DeserializeMacrosFromReader(reader, macrosColumnIndex);
						var replicaId = reader.IsDBNull(replicaIdColumnIndex)
							? Guid.Empty
							: reader.GetGuid(replicaIdColumnIndex);
						var recipientInfo = new BulkEmailRecipientInfo {
							Id = reader.GetGuid(uidColumnIndex),
							ContactId = reader.GetGuid(contactIdColumnIndex),
							ContactRId = reader.GetInt32(contactRIdColumnIndex),
							EmailAddress = address,
							Macros = macros,
							ReplicaId = replicaId
						};
						var initialResponseCode = GetInitialResponseCode(reader, recipientInfo, responseCodeColumnIndex);
						recipientInfo.InitialResponseCode = initialResponseCode;
						SetExpirationDate(recipientInfo, reader);
						result.Add(recipientInfo);
					}
				}
			}
			if (result.Any()) {
				LastBatchSize = result.Count;
			}
			return result;
		}

		/// <summary>
		/// Gets the recipients ids select query.
		/// </summary>
		/// <param name="replicaId">The replica identifier.</param>
		/// <returns>
		/// Select query.
		/// </returns>
		public Select GetRecipientsIdsSelectQuery(Guid replicaId) {
			var recipientsSelect = GetRecipientsIdsSelect(replicaId);
			var notExistsSelect = new Select(_userConnection)
				.Column("BulkEmailRecipientReplica", "RecipientId")
				.From("BulkEmailRecipientReplica")
				.Where("MandrillDeliveryPackage", "RecipientUId").IsEqual("BulkEmailRecipientReplica", "RecipientId");
			recipientsSelect = recipientsSelect.Where().Not().Exists(notExistsSelect) as Select;
			return recipientsSelect;
		}

		/// <summary>
		/// Gets the contacts ids select query for specified replica.
		/// </summary>
		/// <param name="replicaId">The replica identifier.</param>
		/// <returns>
		/// Select query.
		/// </returns>
		[Obsolete("7.17.0 | Use GetRecipientsIdsSelectQuery instead")]
		public Select GetContactsIdsSelectQuery(Guid replicaId) {
			var recipientsSelect = GetRecipientsIdsPageableBatchSelect(replicaId);
			var contactsIdsSelectQuery = new Select(_userConnection)
				.Column("ContactId")
				.From(recipientsSelect)
				.As("ContactSelect");
			return contactsIdsSelectQuery;
		}

		/// <summary>
		/// Get the audience of the bulk email by replica.
		/// </summary>
		/// <param name="bulkEmail">Instance of <see cref="BulkEmail"/> object.</param>
		/// <param name="replicaId">Identifier of the replica.</param>
		/// <param name="batchNumber">Number of current batch.</param>
		/// <param name="lastRecipientId">Last processed recipient id.</param>
		/// <returns><see cref="EntityCollection"/> of the bulk email recipients.</returns>
		public EntityCollection GetBatchedReplicaAudience(BulkEmail bulkEmail, Guid replicaId, int batchNumber,
				Guid lastRecipientId) {
			var schema = _userConnection.EntitySchemaManager.GetInstanceByName("VwBulkEmailAudience")
				.Clone() as EntitySchema;
			var esq = new EntitySchemaQuery(schema) {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			AddColumnWithoutDisplayValue(esq, schema, "Contact");
			AddColumnWithoutDisplayValue(esq, schema, "LinkedEntity");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "BulkEmail", bulkEmail.Id));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Replica", replicaId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "BulkEmailResponse",
				MailingConsts.BulkEmailResponseReadyToSendId));
			esq.Filters.Add(esq.CreateNotExistsFilter("[BulkEmailRecipientMacro:RecipientUId:Id].Id"));
			esq.RowCount = QueryBatchSize;
			return esq.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Gets the audience identifiers.
		/// </summary>
		/// <param name="replicaId">The replica identifier.</param>
		/// <returns>
		/// Dictionary with RecipientUId and ContactId key-value pair.
		/// </returns>
		[Obsolete("7.17.0 | Use GetRecipientsIdsSelectQuery instead")]
		public Dictionary<Guid, Guid> GetAudienceIdentifiers(Guid replicaId) {
			if (PageNumber <= 0) {
				PageNumber = 1;
			}
			var recipientsSelect = GetRecipientsIdsPageableBatchSelect(replicaId);
			var result = new Dictionary<Guid, Guid>();
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				using (var reader = recipientsSelect.ExecuteReader(dbExecutor)) {
					var contactIdColumnIndex = reader.GetOrdinal("ContactId");
					var uidColumnIndex = reader.GetOrdinal("RecipientUId");
					while (reader.Read()) {
						var recipientId = reader.GetGuid(uidColumnIndex);
						var contactId = reader.GetGuid(contactIdColumnIndex);
						result[recipientId] = contactId;
					}
				}
			}
			if (result.Any()) {
				LastBatchSize = result.Count;
			}
			return result;
		}

		/// <summary>
		/// Check if audience is empty.
		/// </summary>
		/// <returns>True if audience is empty.</returns>
		public bool IsEmpty() {
			if (PageNumber < 1) {
				PageNumber = 1;
			}
			var recipientsBatchSelect = GetRecipientsBatchSelect(true);
			var execSelect = new Select(_userConnection)
				.Column(Func.Count("ContactRId"))
				.From(recipientsBatchSelect.Top(1)).As("Select");
			var bulkEmailAudienceCount = execSelect.ExecuteScalar<int>();
			return bulkEmailAudienceCount == 0;
		}

		/// <summary>
		/// Add audience by filter.
		/// </summary>
		/// <param name="audienceSelect">Query for inserting audience.</param>
		/// <param name="bulkEmailId">Unique identifier of the campaign step.</param>
		/// <param name="sessionUId">Unique identifier of the session.</param>
		/// <returns>Number of contacts added.</returns>
		[Obsolete]
		public virtual int Add(Select audienceSelect, Guid bulkEmailId, Guid sessionUId) {
			var workSelect = ApplyBulkEmailInfoToAudienceSelect(audienceSelect, bulkEmailId, sessionUId);
			workSelect = ApplyBulkEmailUnsubscribedRestrictionSelect(workSelect, bulkEmailId);
			var insertSelect = new InsertSelect(_userConnection)
				.Into("MandrillRecipient")
				.Set("ContactRId", "EmailAddress", "BulkEmailRId", "SessionUId", "IsSent", "Timestamp")
				.FromSelect(workSelect);
			return insertSelect.Execute();
		}

		/// <summary>
		/// Get select for ready to transfer audience from MandrillRecipient.
		/// </summary>
		[Obsolete]
		public Select GetMandrillRecipientsReadyToTransferSelect(Guid bulkEmailId, int batchSize) {
			var mandrillSelect = new Select(_userConnection).Top(batchSize)
					.Column("MandrillRecipient", "UId").As("UId")
					.Column("MandrillRecipient", "EmailAddress").As("EmailAddress")
					.Column("MandrillRecipient", "LinkedEntityId").As("LinkedEntityId")
					.Column("Contact", "Id").As("ContactId")
					.Column("BulkEmail", "Id").As("BulkEmailId")
					.Column(Column.Parameter(MailingConsts.BulkEmailResponseReadyToSendId)).As("ResponseId")
					.From("MandrillRecipient")
					.InnerJoin("Contact").On("MandrillRecipient", "ContactRId").IsEqual("Contact", "RId")
					.InnerJoin("BulkEmail").On("MandrillRecipient", "BulkEmailRId").IsEqual("BulkEmail", "RId")
					.Where("BulkEmail", "Id").IsEqual(Column.Parameter(bulkEmailId))
					.And().Not().Exists(new Select(_userConnection)
						.Column(Column.Parameter(1))
						.From("BulkEmailTarget")
						.Where("BulkEmailTarget", "MandrillId").IsEqual("MandrillRecipient", "UId"))
				as Select;
			mandrillSelect.SpecifyNoLockHints();
			return mandrillSelect;
		}

		#endregion

	}

	#endregion
}
