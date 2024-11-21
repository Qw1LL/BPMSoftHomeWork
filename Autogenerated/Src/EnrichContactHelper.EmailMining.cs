namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.EmailMining;
	using BPMSoft.Configuration.FileImport;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Messaging.Common;

	#region Class: EnrichContactHelper

	/// <summary>
	/// Provides contact enrichment methods.
	/// </summary>
	public class EnrichContactHelper
	{

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		/// <summary>
		/// <see cref="Contact"/> instance existance check results.
		/// </summary>
		private readonly Dictionary<Guid, bool> _contactExists = new Dictionary<Guid, bool>();

		/// <summary>
		/// New <see cref="EnrchFoundContact"/> save data.
		/// </summary>
		private readonly Dictionary<Guid, Guid> _newEnrchFoundContactEteIds = new Dictionary<Guid, Guid>();

		/// <summary>
		/// Existing <see cref="EnrchFoundContact"/> save data.
		/// </summary>
		private readonly Dictionary<Guid, Guid> _updateEnrchFoundContactEteIds = new Dictionary<Guid, Guid>();
		private readonly EnrichEntitySearchHelper _enrichEntitySearchHelper;

		#endregion

		#region Constructors: Public

		public EnrichContactHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_enrichEntitySearchHelper = new EnrichEntitySearchHelper(_userConnection);
	}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// <see cref="IFileImporter"/> instance.
		/// </summary>
		protected virtual IFileImporter Importer {
			get {
				var userConnection = new ConstructorArgument("userConnection", _userConnection);
				return ClassFactory.Get<IFileImporter>(userConnection);
			}
		}

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _log;
		protected ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("ContactEnrichment"));
			}
		}

		/// <summary>
		/// <see cref="EmailParticipantHelper"/> instance.
		/// </summary>
		private EmailParticipantHelper _participantsHelper;

		protected virtual EmailParticipantHelper ParticipantsHelper {
			get {
				var userConnection = new ConstructorArgument("userConnection", _userConnection);
				return _participantsHelper ??
					(_participantsHelper = ClassFactory.Get<EmailParticipantHelper>(userConnection));
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Saves entity instance filled with data from <paramref name="item"/>.
		/// </summary>
		/// <param name="item"><see cref="EnrichSaveEntityData"/> instance.</param>
		private void SaveEnrichedEntity(EnrichSaveEntityData item) {
			EntitySchema entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(item.EntityName);
			Log.Info(string.Format("SaveEnrichedEntity: Preparing parameters for {0} save. Values: {1}", item.EntityName,
				item.Values.Select(kvp => kvp.Key + "=" + kvp.Value).ConcatIfNotEmpty(", ")));
			ImportParameters parameters = CreateParameters(item, entitySchema);
			Log.Info(string.Format("SaveEnrichedEntity: import for {0} stated", item.EntityName));
			Importer.ImportWithParams(parameters);
			Log.Info(string.Format("SaveEnrichedEntity: import for {0} ended", item.EntityName));
		}

		/// <summary>
		/// Checks that current user has <see cref="Contact"/> instance edit  rights.
		/// </summary>
		/// <param name="rawData"><see cref="EnrichSaveEntityData"/> collection.</param>
		/// <returns><c>True</c> if user has edit rights, <c>false</c> otherwise.</returns>
		private bool GetHasContactEditRights(IEnumerable<EnrichSaveEntityData> rawData) {
			EnrichSaveEntityData contactInfo = rawData.FirstOrDefault(item => item.EntityName == "Contact");
			if (contactInfo == null) {
				Log.Error("GetHasContactEditRights: Contact info not passed from client");
				return false;
			}
			Guid contactId = Guid.Parse(contactInfo.Values["Id"]);
			if (!GetContactExists(contactId)) {
				Log.Info(string.Format("GetHasContactEditRights: Contact {0} not created yet, author has full rights", contactId));
				return true;
			}
			Log.Info(string.Format("GetHasContactEditRights: Check current user edit rights for contact {0}", contactId));
			DBSecurityEngine securityEngine = _userConnection.DBSecurityEngine;
			SchemaRecordRightLevels rights = securityEngine.GetEntitySchemaRecordRightLevel("Contact", contactId);
			return (rights & SchemaRecordRightLevels.CanEdit) == SchemaRecordRightLevels.CanEdit;
		}

		/// <summary>
		/// Sets <see cref="EnrchProcessedData.Status"/> column value.
		/// </summary>
		/// <param name="data"><see cref="EnrichSaveEntityData"/> collection.</param>
		private void SetStatusColumnValue(IEnumerable<EnrichSaveEntityData> data) {
			foreach (EnrichSaveEntityData item in data.Where(d => d.EntityName == "EnrchProcessedData")) {
				if (item.Values.ContainsKey("IsChecked")) {
					item.Values["Status"] = GetEnrchProcessedDataStatus(item);
					item.Values.Remove("IsChecked");
					Log.Info(string.Format("SetStatusColumnValue: EnrchProcessedData with hash {0} recived status {1}",
						item.Values["TextEntityHash"], item.Values["Status"]));
				}
			}
		}

		/// <summary>
		/// Returns <see cref="ProcessedDataStatus"/> for <paramref name="item"/>.
		/// </summary>
		/// <param name="item"><see cref="EnrichSaveEntityData"/> instance.</param>
		/// <returns><see cref="ProcessedDataStatus"/> instance.</returns>
		private string GetEnrchProcessedDataStatus(EnrichSaveEntityData item) {
			return bool.Parse(item.Values["IsChecked"])
				? ProcessedDataStatus.Applied
				: ProcessedDataStatus.Rejected;
		}

		/// <summary>
		/// Fills <see cref="EnrchFoundContact"/> items save data.
		/// </summary>
		/// <param name="data"><see cref="EnrichSaveEntityData"/> collection.</param>
		/// <returns><see cref="EnrichSaveEntityData"/> items collection with actualized
		/// <see cref="EnrchFoundContact"/> items.</returns>
		private IEnumerable<EnrichSaveEntityData> PrepareEnrchFoundContactData(
				IEnumerable<EnrichSaveEntityData> data) {
			_newEnrchFoundContactEteIds.Clear();
			_updateEnrchFoundContactEteIds.Clear();
			foreach (EnrichSaveEntityData item in data.Where(d => d.EntityName == "EnrchFoundContact")) {
				Guid contactId = Guid.Parse(item.Values["Contact"]);
				string rawTextEntityId = string.Empty;
				Guid textEntityId = Guid.Empty;
				item.Values.TryGetValue("EnrchTextEntity", out rawTextEntityId);
				bool isNewRecord = bool.Parse(item.Values["IsNewRecord"]);
				bool hasEnrchTextEntityId = Guid.TryParse(rawTextEntityId, out textEntityId);
				if (isNewRecord) {
					Log.Info(string.Format("PrepareEnrchFoundContactData: EnrchFoundContact for contactId {0}" +
						" recived status {1}", contactId, IdentificationType.Manual));
					_newEnrchFoundContactEteIds.Add(textEntityId, contactId);
				} else if (hasEnrchTextEntityId) {
					Log.Info(string.Format("PrepareEnrchFoundContactData: EnrchFoundContact for enrchTextEntityId {0}" +
						" fill be updated with {1} contactId", textEntityId, contactId));
					_updateEnrchFoundContactEteIds.Add(textEntityId, contactId);
				}
			}
			return data.Where(item => item.EntityName != "EnrchFoundContact");
		}

		/// <summary>
		/// Creates users notifications data select.
		/// </summary>
		/// <param name="textEntityHashes"><see cref="EnrchTextEntity"/> Hash column values.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		private Select GetNotificationsDataSelect(IEnumerable<string> textEntityHashes) {
			return new Select(_userConnection)
					.Column("A", "Id").As("ActivityId")
					.Column("SAU", "Id").As("AdminUnitId")
				.From("EnrchTextEntity").As("ETE")
					.InnerJoin("EnrchEmailData").As("EED").On("EED", "Id").IsEqual("ETE", "EnrchEmailDataId")
						.And("ETE", "Type").IsEqual(Column.Const("ContactEntity"))
						.InnerJoin("Activity").As("A").On("EED", "Id").IsEqual("A", "EnrchEmailDataId")
							.And("A", "SendDate").IsGreater(Column.Parameter(DateTime.UtcNow.AddDays(-7)))
								.InnerJoin("EmailMessageData").As("EMD").On("EMD", "ActivityId").IsEqual("A", "Id")
									.InnerJoin("SysAdminUnit").As("SAU").On("EMD", "OwnerId").IsEqual("SAU", "ContactId")
				.Where("ETE", "Hash").In(Column.Parameters(textEntityHashes)) as Select;
		}

		/// <summary>
		/// Creates <see cref="EnrchFoundContact"/> instances for new contacts.
		/// </summary>
		private void CreateEnrchFoundContact() {
			Log.Info("CreateEnrchFoundContact: started");
			foreach (Guid contactId in _newEnrchFoundContactEteIds.Select(kvp => kvp.Value).Distinct()) {
				InsertSelect foundContactsInsert = new InsertSelect(_userConnection)
					.Into("EnrchFoundContact")
					.Set(new[] { "EnrchTextEntityId", "ContactId", "IdentificationType" })
					.FromSelect(
						new Select(_userConnection)
								.Column("ETE", "Id")
								.Column(Column.Parameter(contactId))
								.Column(Column.Const(IdentificationType.Manual.ToString()))
							.From("EnrchTextEntity").As("ETE")
							.LeftOuterJoin("EnrchFoundContact").As("EFC").On("EFC", "EnrchTextEntityId")
								.IsEqual("ETE", "Id")
							.Where("ETE", "Hash").In(
								new Select(_userConnection)
										.Column("Hash")
									.From("EnrchTextEntity").As("PETE")
									.Where("PETE", "Id").In(Column.Parameters(_newEnrchFoundContactEteIds
										.Where(kvp => kvp.Value.Equals(contactId)).Select(kvp => kvp.Key)))
								)
								.And("EFC", "Id").IsNull()
					);
				string sqlText = foundContactsInsert.GetSqlText();
				Log.Debug(string.Format("CreateEnrchFoundContact: sqlText - {0}", sqlText));
				foundContactsInsert.Execute();
			}
		}

		/// <summary>
		/// Updates <see cref="EnrchFoundContact"/> instances for existing contacts.
		/// </summary>
		private void UpdateEnrchFoundContact() {
			Log.Info("UpdateEnrchFoundContact: started");
			foreach (Guid contactId in _updateEnrchFoundContactEteIds.Select(kvp => kvp.Value).Distinct()) {
				Update updateEfc = new Update(_userConnection, "EnrchFoundContact")
					.Set("ContactId", Column.Parameter(contactId))
				.Where("EnrchTextEntityId").In(
						new Select(_userConnection)
								.Column("ETE", "Id")
							.From("EnrchTextEntity").As("ETE")
								.InnerJoin("EnrchTextEntity").As("CETE").On("ETE", "Hash").IsEqual("CETE", "Hash")
							.Where("CETE", "Id").In(Column.Parameters(_updateEnrchFoundContactEteIds
								.Where(kvp => kvp.Value.Equals(contactId)).Select(kvp => kvp.Key)))
					) as Update;
				string sqlText = updateEfc.GetSqlText();
				Log.Debug(string.Format("CreateEnrchFoundContact: sqlText - {0}", sqlText));
				updateEfc.Execute();
			}
		}

		private void AddRelativeAccounts(EnrichTextDataResponse result, IList<Guid> organizationIds) {
			result.FoundAccounts = new List<EnrichAccountItem>();
			if (!organizationIds.IsEmpty()) {
				AppendFoundAccounts(result, organizationIds);
			}
			if (result.FoundAccounts.Count == 0) {
				List<EnrichTextDataItem> organizations =
					result.Data.Where(item => item.Type == EnrchTextEntityType.Organization).ToList();
				if (organizations.Count > 0) {
					result.FoundAccounts = _enrichEntitySearchHelper.UpdateAccountIdentificationInfo(organizations);
					SetupAccountLookupValues(result.FoundAccounts);
				} else {
					IList<Guid> accountIds = _enrichEntitySearchHelper.IdentifyAccountByEte(result.Data);
					result.FoundAccounts = SetupAccountLookupValues(accountIds);
				}
			}
		}

		private void AppendFoundAccounts(EnrichTextDataResponse result, IList<Guid> organizationIds) {
			EntitySchema foundAccountSchema = _userConnection.EntitySchemaManager.GetInstanceByName("EnrchFoundAccount");
			var esq = new EntitySchemaQuery(foundAccountSchema);
			esq.AddColumn("Account");
			esq.AddColumn("EnrchTextEntity");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "EnrchTextEntity",
				organizationIds.Cast<object>()));
			EntityCollection collection = esq.GetEntityCollection(_userConnection);
			if (collection.Count == 0) {
				return;
			}
			foreach (var entity in collection) {
				result.FoundAccounts.Add(new EnrichAccountItem {
					Id = entity.GetTypedColumnValue<Guid>("AccountId"),
					Name = entity.GetTypedColumnValue<string>("AccountName"),
					EnrchTextEntityId = entity.GetTypedColumnValue<Guid>("EnrchTextEntityId")
				});
			}
		}

		private void SetupAccountLookupValues(List<EnrichAccountItem> foundAccounts) {
			IList<Guid> accountIds = foundAccounts.Select(item => item.Id).ToList();
			if (accountIds.IsNullOrEmpty()) {
				return;
			}
			EntityCollection collection = GetAccountCollection(accountIds);
			if (collection.Count != 0) {
				foreach (EnrichAccountItem foundAccount in foundAccounts) {
					Entity account = collection.First(entity => entity.PrimaryColumnValue == foundAccount.Id);
					foundAccount.Name = account.PrimaryDisplayColumnValue;
				}
			}
		}

		private List<EnrichAccountItem> SetupAccountLookupValues(IList<Guid> accountIds) {
			List<EnrichAccountItem> result = new List<EnrichAccountItem>();
			if (accountIds.IsNullOrEmpty()) {
				return result;
			}
			var collection = GetAccountCollection(accountIds);
			if (collection.Count != 0) {
				foreach (var entity in collection) {
					result.Add(new EnrichAccountItem {
						Id = entity.PrimaryColumnValue,
						Name = entity.PrimaryDisplayColumnValue
					});
				}
			}
			return result;
		}

		private EntityCollection GetAccountCollection(IList<Guid> accountIds) {
			EntitySchema accountSchema = _userConnection.EntitySchemaManager.GetInstanceByName("Account");
			var esq = new EntitySchemaQuery(accountSchema);
			esq.PrimaryQueryColumn.IsVisible = true;
			esq.AddColumn(accountSchema.PrimaryDisplayColumn.Name);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", accountIds.Cast<object>()));
			EntityCollection collection = esq.GetEntityCollection(_userConnection);
			return collection;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns email message instance contact enrich actions select.
		/// </summary>
		/// <param name="entityId"><see cref="Activity"/> instance unique identifier.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		/// <remarks>Be sure when you modify this select that fn_GetEnrchCloudData function 
		/// in fn_GetEnrchCloudDataMSSql_EmailMining_Tests DB test is up to date.</remarks>
		protected virtual Select GetEmailContactsEnrichSelect(Guid entityId) {
			Log.Debug(string.Format("GetEmailContactsEnrichSelect: entityId: {0}", entityId));
			var select = new Select(_userConnection)
				.Column("ETE", "Id")
				.Column("ETE", "JsonData")
				.Column("EFC", "ContactId")
				.Column("C", "Name")
			.From("EnrchTextEntity").As("ETE")
				.LeftOuterJoin("EnrchFoundContact").As("EFC").On("ETE", "Id").IsEqual("EFC", "EnrchTextEntityId")
					.LeftOuterJoin("Contact").As("C").On("EFC", "ContactId").IsEqual("C", "Id")
						.InnerJoin("EnrchEmailData").As("EMD").On("ETE", "EnrchEmailDataId").IsEqual("EMD", "Id")
							.InnerJoin("Activity").As("A").On("EMD", "Id").IsEqual("A", "EnrchEmailDataId")
			.Where("ETE", "Type").IsEqual(Column.Const("ContactEntity"))
				.And("A", "Id").IsEqual(Column.Parameter(entityId))
				.And("A", "EnrichStatus").IsEqual(Column.Const(EnrichStatus.Done.ToString()))
				.And().Exists(
						new Select(_userConnection)
							.Column(Column.Const(1))
						.From("EnrchTextEntity").As("CETE")
						.Where().OpenBlock("CETE", "ParentId").IsEqual("ETE", "Id")
							.Or("CETE", "Id").IsEqual("ETE", "ParentId")
							.CloseBlock()
							.And(Func.IsNull(Column.SourceColumn("CETE", "DuplicationStatus"), Column.Const("New")))
								.Not().IsEqual(Column.Const(EnrchDuplicateStatus.ExistsInEntity.ToString()))
							.And().Not().Exists(
								new Select(_userConnection)
									.Column(Column.Const(1))
								.From("EnrchProcessedData").As("EPD")
								.Where("EPD", "ContactId").IsEqual("EFC", "ContactId")
									.And("EPD", "TextEntityHash").IsEqual("CETE", "Hash")
						)
				) as Select;
			return select;
		}

		/// <summary>
		/// Returns contact enrich actions for email message.
		/// </summary>
		/// <param name="select"><see cref="Select"/> instance.</param>
		/// <returns><see cref="CloudDataResponse"/> instance.</returns>
		protected virtual CloudDataResponse CreateEmailContactsEnrichResponse(Select select) {
			var result = new CloudDataResponse();
			string sqlText = select.GetSqlText();
			Log.Debug(string.Format("CreateEmailContactsEnrichResponse: select text: {0}", sqlText));
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid contactId = reader.GetColumnValue<Guid>("ContactId");
						string jsonData = reader.GetColumnValue<string>("JsonData");
						string contactName = reader.GetColumnValue<string>("Name");
						var enrichContactItem = new EnrichContactItem {
							EnrchTextDataId = reader.GetColumnValue<Guid>("Id")
						};
						if (contactId.IsNotEmpty()) {
							enrichContactItem.ContactId = contactId;
							var json = new JObject();
							json["value"] = contactName;
							jsonData = Json.FormatJsonString(Json.Serialize(json), Formatting.Indented);
						}
						enrichContactItem.JsonData = jsonData;
						Log.Debug(string.Format("CreateEmailContactsEnrichResponse: contactId={0}, jsonData={1}," +
							" contactName={2}", contactId, jsonData, contactName));
						result.Add(enrichContactItem);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Returns contact instance enrich actions.
		/// </summary>
		/// <param name="entityId"><see cref="Contact"/> instance unique identifier.</param>
		/// <returns><see cref="CloudDataResponse"/> instance.</returns>
		/// <remarks>Be sure that when you modify this select fn_GetEnrchCloudData function 
		/// in fn_GetEnrchCloudDataContactMSSql_EmailMining_Tests DB test is up to date.</remarks>
		protected virtual CloudDataResponse CreateContactEnrichResponse(Guid entityId) {
			Log.Debug(string.Format("CreateContactEnrichResponse: entityId={0}", entityId));
			var select = new Select(_userConnection).Top(1)
					.Column(Column.Const(null)).As("NullAlias")
				.From("EnrchTextEntity").As("Contact_ETE")
					.InnerJoin("EnrchFoundContact").As("EFC").On("Contact_ETE", "Id")
						.IsEqual("EFC", "EnrchTextEntityId")
				.Where("EFC", "ContactId").IsEqual(Column.Parameter(entityId))
					.And()
						.OpenBlock()
							.OpenBlock()
								.Exists(
									new Select(_userConnection)
										.Column(Column.Const(null)).As("NullAlias")
									.From("EnrchTextEntity").As("Child_ETE")
										.LeftOuterJoin("EnrchProcessedData").As("EPD").On("Child_ETE", "Hash")
											.IsEqual("EPD", "TextEntityHash")
										.And("EPD", "ContactId").IsEqual(Column.Parameter(entityId))
									.Where("Child_ETE", "ParentId").IsEqual("Contact_ETE", "Id")
										.And("EPD", "Id").IsNull()
										.And("Child_ETE", "DuplicationStatus").Not().IsEqual(Column.Const(EnrchDuplicateStatus.ExistsInEntity.ToString()))
								)
								.CloseBlock()
							.Or()
								.OpenBlock().Exists(
									new Select(_userConnection)
										.Column(Column.Const(null)).As("NullAlias")
									.From("EnrchTextEntity").As("Parent_ETE")
										.LeftOuterJoin("EnrchProcessedData").As("EPD").On("Parent_ETE", "Hash")
											.IsEqual("EPD", "TextEntityHash")
										.And("EPD", "ContactId").IsEqual(Column.Parameter(entityId))
									.Where("Parent_ETE", "Id").IsEqual("Contact_ETE", "ParentId")
										.And("EPD", "Id").IsNull()
									)
								.CloseBlock()
						.CloseBlock() as Select;
			string sqlText = select.GetSqlText();
			Log.Debug(string.Format("CreateContactEnrichResponse: sqlText={0}", sqlText));
			var result = new CloudDataResponse();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						Log.Debug("CreateContactEnrichResponse: contact can be enriched");
						result.Add(new EnrichContactItem {
							ContactId = entityId,
							JsonData = string.Empty
						});
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Returns <see cref="CloudDataResponse"/> instance, filled using <paramref name="entityId"/> and
		/// <paramref name="entityName"/>.
		/// </summary>
		/// <param name="entityId"><see cref="Entity"/> instance unique identifier.</param>
		/// <param name="entityName"><see cref="Entity"/> name.</param>
		/// <returns><see cref="CloudDataResponse"/> instance.</returns>
		/// <remarks><see cref="Activity"/> and <see cref="Contact"/> entities are supported.</remarks>
		protected virtual CloudDataResponse GetCloudActionsFromDB(Guid entityId, string entityName) {
			switch (entityName) {
				case "Activity":
					Select select = GetEmailContactsEnrichSelect(entityId);
					return CreateEmailContactsEnrichResponse(select);
				case "Contact":
					return CreateContactEnrichResponse(entityId);
				default:
					return new CloudDataResponse();
			}
		}

		/// <summary>
		/// Returns contact enrichment data, using <paramref name="entityId"/> and <paramref name="entityName"/>.
		/// </summary>
		/// <param name="entityId"><see cref="Entity"/> instance unique identifier.</param>
		/// <param name="entityName"><see cref="Entity"/> name.</param>
		/// <returns><see cref="EnrichTextDataResponse"/> instance.</returns>
		protected virtual EnrichTextDataResponse GetEnrchTextDataFromDB(Guid entityId, string entityName) {
			switch (entityName) {
				case "EnrchTextEntity":
					return CreateTextEntityDataResponse(entityId);
				case "Contact":
					return CreateContactDataResponse(entityId);
				default:
					return new EnrichTextDataResponse();
			}
		}

		/// <summary>
		/// Returns <see cref="EnrichTextDataResponse"/> instance.
		/// </summary>
		/// <param name="contactId"><see cref="Contact"/> instance unique identifier.</param>
		/// <returns><see cref="EnrichTextDataResponse"/> instance.</returns>
		/// <remarks>Be sure when you modify this select that fn_GetEnrchTextData function 
		/// in fn_GetEnrchTextDataMSSql_EmailMining_Tests DB test is up to date.</remarks>
		protected virtual EnrichTextDataResponse CreateContactDataResponse(Guid contactId) {
			Dictionary<KeyValuePair<Guid, Guid>, EnrichTextDataItem> personsDataResponse = GetPersonsDataResponse(contactId);
			var select = new Select(_userConnection)
					.Column(Func.Min("ETE", "JsonData")).As("JsonData")
					.Column("ETE", "Hash").As("Hash")
					.Column(Func.Min("ETE", "Type")).As("Type")
					.Column(Func.Max("ETE", "DuplicationStatus")).As("DuplicationStatus")
				.From("EnrchTextEntity").As("ETE")
				.Where().Not().Exists(
					new Select(_userConnection)
						.Column(Column.Const(1))
					.From("EnrchProcessedData").As("EPD")
					.Where("EPD", "TextEntityHash").IsEqual("ETE", "Hash")
						.And("EPD", "ContactId").IsEqual(Column.Parameter(contactId))
				)
				.And().OpenBlock("ETE", "ParentId").In(Column.Parameters(personsDataResponse.Keys.Select(p => p.Key)))
					.Or("ETE", "Id").In(Column.Parameters(personsDataResponse.Keys.Select(p => p.Key)))
					.Or("ETE", "Id").In(Column.Parameters(personsDataResponse.Keys.Select(p => p.Value)))
					.CloseBlock()
				.GroupBy("ETE", "Hash") as Select;
			var result = new EnrichTextDataResponse();
			select.BuildParametersAsValue = true;
			foreach (var person in personsDataResponse.Values) {
				result.Add(person);
			}
			string sqlText = select.GetSqlText();
			Log.Debug(string.Format("CreateContactDataResponse: sqlText={0}", sqlText));
			List<Guid> organizationIds = personsDataResponse.Keys.Select(p => p.Value).Distinct().ToList();
			AddEnrichTextDataResponse(select, result, organizationIds);
			return result;
		}

		/// <summary>
		/// Gets list <see cref="EnrichTextDataItem"/> by <paramref name="contactId"/>
		/// </summary>
		/// <param name="contactId"> Contact uniqueidentifier.</param>
		/// <returns>List <see cref="EnrichTextDataItem"/></returns>
		protected virtual Dictionary<KeyValuePair<Guid, Guid>, EnrichTextDataItem> GetPersonsDataResponse(Guid contactId) {
			Log.Debug(string.Format("GetPersonsDataResponse: contactId={0}", contactId));
			var select = new Select(_userConnection)
					.Column("ETE", "Id")
					.Column("ETE", "JsonData")
					.Column("ETE", "Hash")
					.Column("ETE", "Type")
					.Column("ETE", "ParentId")
				.From("EnrchFoundContact").As("EFC")
					.InnerJoin("EnrchTextEntity").As("ETE").On("EFC", "EnrchTextEntityId").IsEqual("ETE", "Id")
				.Where("EFC", "ContactId").IsEqual(Column.Parameter(contactId)) as Select;
			var result = new Dictionary<KeyValuePair<Guid, Guid>, EnrichTextDataItem>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid parentId = reader.GetColumnValue<Guid>("ParentId");
						Guid enrchTextDataId = reader.GetColumnValue<Guid>("Id");
						var enrichContactItem = new EnrichTextDataItem {
							JsonData = reader.GetColumnValue<string>("JsonData"),
							Hash = reader.GetColumnValue<string>("Hash"),
							Type = reader.GetColumnValue<string>("Type")
						};
						var key = new KeyValuePair<Guid, Guid>(enrchTextDataId, parentId);
						if (!result.ContainsKey(key)) {
							result.Add(new KeyValuePair<Guid, Guid>(enrchTextDataId, parentId), enrichContactItem);
							Log.Debug(string.Format("GetPersonsDataResponse: Type={0}, JsonData={1}, Hash={2}",
								enrichContactItem.Type, enrichContactItem.JsonData, enrichContactItem.Hash));
						}
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Gets unique identifiers of new persons and related organization by <paramref name="personEteId"/>
		/// </summary>
		/// <param name="personEteId"> Contact uniqueidentifier.</param>
		/// <returns>Unique identifiers of new persons</returns>
		protected virtual Dictionary<Guid, Guid> GetNewPersonsIds(Guid personEteId) {
			Log.Debug(string.Format("GetNewPersonsIds: personEteId={0}", personEteId));
			var select = new Select(_userConnection)
					.Column("ETE", "Id")
					.Column("ETE", "ParentId")
				.From("EnrchTextEntity").As("ETE")
				.Where("ETE", "Hash").IsEqual(
					new Select(_userConnection)
							.Column("PETE", "Hash")
						.From("EnrchTextEntity").As("PETE")
						.Where("PETE", "Id").IsEqual(Column.Parameter(personEteId))
				) as Select;
			var result = new Dictionary<Guid, Guid>();
			string sqlText = select.GetSqlText();
			Log.Debug(string.Format("GetNewPersonsIds: sqlText={0}", sqlText));
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid enrchTextDataId = reader.GetColumnValue<Guid>("Id");
						Guid parentTextDataId = reader.GetColumnValue<Guid>("ParentId");
						result.Add(enrchTextDataId, parentTextDataId);
					}
				}
			}
			Log.Debug(string.Format("GetNewPersonsIds: Ids={0}", result.Select(id => id.ToString())
				.ConcatIfNotEmpty(", ")));
			return result;
		}

		/// <summary>
		/// Creates <see cref="EnrichTextDataResponse"/> instance.
		/// </summary>
		/// <param name="entityId"> enrich text entity uniqueidentifier.</param>
		/// <returns><see cref="EnrichTextDataResponse"/> instance.</returns>
		/// <remarks>Be sure when you modify this select that fn_GetEnrchTextData function 
		/// in fn_GetEnrchTextDataMSSql_EmailMining_Tests DB test is up to date.</remarks>
		protected virtual EnrichTextDataResponse CreateTextEntityDataResponse(Guid entityId) {
			Log.Debug(string.Format("CreateTextEntityDataResponse: entityId={0}", entityId));
			IDictionary<Guid, Guid> personsIds = GetNewPersonsIds(entityId);
			var select = new Select(_userConnection)
					.Column(Func.Min("ETE", "JsonData")).As("JsonData")
					.Column("ETE", "Hash").As("Hash")
					.Column(Func.Min("ETE", "Type")).As("Type")
					.Column(Func.Min("ETE", "DuplicationStatus")).As("DuplicationStatus")
				.From("EnrchTextEntity").As("ETE")
				.Where("ETE", "ParentId").In(Column.Parameters(personsIds.Keys))
					.Or("ETE", "Id").In(Column.Parameters(personsIds.Keys))
					.Or("ETE", "Id").In(
						new Select(_userConnection)
							.Column("ParentId")
						.From("EnrchTextEntity").As("CETE")
						.Where("CETE", "Id").In(Column.Parameters(personsIds.Keys))
					)
				.GroupBy("ETE", "Hash") as Select;
			string sqlText = select.GetSqlText();
			Log.Debug(string.Format("CreateTextEntityDataResponse: sqlText={0}", sqlText));
			var result = new EnrichTextDataResponse();
			IList<Guid> organizationIds = personsIds.Values.Distinct().ToList();
			AddEnrichTextDataResponse(select, result, organizationIds);
			return result;
		}

		/// <summary>
		/// Adds <see cref="EnrichTextDataItem"/> to <paramref name="enrichTextDataResponse"/>
		/// </summary>
		/// <param name="select"> <see cref="Select"/> instance.</param>
		/// <param name="enrichTextDataResponse"><see cref="EnrichTextDataResponse"/> instance.</param>
		/// <param name="organizationIds">Person organization ids</param>
		protected virtual void AddEnrichTextDataResponse(Select select, EnrichTextDataResponse enrichTextDataResponse,
				IList<Guid> organizationIds) {
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var enrichContactItem = new EnrichTextDataItem {
							JsonData = reader.GetColumnValue<string>("JsonData"),
							Hash = reader.GetColumnValue<string>("Hash"),
							Type = reader.GetColumnValue<string>("Type"),
							DuplicationStatus = reader.GetColumnValue<string>("DuplicationStatus")
						};
						enrichTextDataResponse.Add(enrichContactItem);
						Log.Debug(string.Format("AddEnrichTextDataResponse: Type={0}, JsonData={1}, Hash={2}",
							enrichContactItem.Type, enrichContactItem.JsonData, enrichContactItem.Hash));
					}
				}
			}
			AddRelativeAccounts(enrichTextDataResponse, organizationIds);
		}

		/// <summary>
		/// Creates <see cref="ImportParameters"/> instance from <paramref name="item"/>.
		/// </summary>
		/// <param name="item"><see cref="EnrichSaveEntityData"/> instance.</param>
		/// <param name="entitySchema"><see cref="EntitySchema"/> instance.</param>
		/// <returns><see cref="ImportParameters"/> instance.</returns>
		protected virtual ImportParameters CreateParameters(EnrichSaveEntityData item, EntitySchema entitySchema) {
			var importParamsGenerator = new BaseImportParamsGenerator();
			ImportParameters parameters = importParamsGenerator.GenerateParameters(entitySchema, item.Values);
			SetKeyColumns(parameters, item.KeyColumns, entitySchema);
			return parameters;
		}

		/// <summary>
		/// Sets key columns for existing entity search in <paramref name="parameters"/>.
		/// </summary>
		/// <param name="parameters"><see cref="ImportParameters"/> instance.</param>
		/// <param name="keyColumns">Search column names collection.</param>
		/// <param name="schema"><see cref="EntitySchema"/> instance.</param>
		protected virtual void SetKeyColumns(ImportParameters parameters, IEnumerable<string> keyColumns, EntitySchema schema) {
			IEnumerable<ImportColumn> columns = parameters.Columns;
			foreach (ImportColumn column in columns.Where(c => keyColumns.Any(keyColumn => keyColumn == c.Source))) {
				foreach (ImportColumnDestination destination in column.Destinations.Where(d => d.SchemaUId.Equals(schema.UId))) {
					destination.IsKey = true;
					Log.Info(string.Format("SetKeyColumns: Column {0} set as key column", column.Source));
				}
			}
		}

		/// <summary>
		/// Fills <see cref="_contactExists"/> dictionary using <paramref name="rawData"/>.
		/// </summary>
		/// <param name="rawData"><see cref="EnrichSaveEntityData"/> collection.</param>
		protected virtual void SetContactExist(IEnumerable<EnrichSaveEntityData> rawData) {
			foreach (EnrichSaveEntityData contactInfo in rawData.Where(d => d.EntityName == "Contact")) {
				if (contactInfo.Values.ContainsKey("IsNewRecord")) {
					Guid contactId = Guid.Parse(contactInfo.Values["Id"]);
					bool isNewRecord = bool.Parse(contactInfo.Values["IsNewRecord"]);
					_contactExists[contactId] = !isNewRecord;
					contactInfo.Values.Remove("IsNewRecord");
					Log.Info(string.Format("SetContactExist: Contact {0} state passed from client, isNewRecord = {1}", contactId, isNewRecord));
				}
			}
		}

		/// <summary>
		/// Returns prepared for save <see cref="EnrichSaveEntityData"/> items collection.
		/// </summary>
		/// <param name="rawData"><see cref="EnrichSaveEntityData"/> collection.</param>
		/// <returns>Prepared for save <see cref="EnrichSaveEntityData"/> items collection.</returns>
		protected virtual IEnumerable<EnrichSaveEntityData> PrepareSaveData(IEnumerable<EnrichSaveEntityData> rawData) {
			SetContactExist(rawData);
			if (!GetHasContactEditRights(rawData)) {
				Log.Error("PrepareSaveData: User has no edit right for contact");
				return new List<EnrichSaveEntityData>();
			}
			IEnumerable<EnrichSaveEntityData> data = UpdateProcessedDataValues(rawData);
			data = PrepareEnrchFoundContactData(data);
			return data.Where(item => item.EntityName != "EnrchEmailData").OrderBy(item => item.Order);
		}

		/// <summary>
		/// Updates <see cref="EnrichSaveEntityData"/> items for <see cref="EnrchProcessedData"/> entities in 
		/// <paramref name="data"/>.
		/// </summary>
		/// <param name="data"><see cref="EnrichSaveEntityData"/> collection.</param>
		/// <returns><see cref="EnrichSaveEntityData"/> collection.</returns>
		protected virtual IEnumerable<EnrichSaveEntityData> UpdateProcessedDataValues(IEnumerable<EnrichSaveEntityData> data) {
			SetStatusColumnValue(data);
			return data;
		}

		/// <summary>
		/// Checks that <see cref="Contact"/> exists.
		/// </summary>
		/// <param name="contactId"><see cref="Contact"/> unique identifier.</param>
		/// <returns><c>True</c> if contact exists, <c>false</c> otherwise.</returns>
		protected virtual bool GetContactExists(Guid contactId) {
			if (_contactExists.ContainsKey(contactId)) {
				return _contactExists[contactId];
			}
			Log.Info(string.Format("GetContactExists: Contact {0} state must be checked in DB", contactId));
			var select = new Select(_userConnection).Top(1)
					.Column("Id")
				.From("Contact")
				.Where("Id").IsEqual(Column.Parameter(contactId)) as Select;
			bool result = select.ExecuteScalar<Guid>().IsNotEmpty();
			_contactExists[contactId] = result;
			Log.Info(string.Format("GetContactExists: Contact {0} state in DB - {1}", contactId, result));
			return result;
		}

		/// <summary>
		/// Creates users data fror update messages.
		/// </summary>
		/// <param name="data">Enriched data collection.</param>
		/// <returns>Users data fror update messages.</returns>
		protected virtual Dictionary<Guid, List<EnrichActivityInfo>> GetNotificationsData(
				IEnumerable<EnrichSaveEntityData> data) {
			IEnumerable<string> textEntityHashes = data.Where(d => d.EntityName == "EnrchProcessedData")
				.Select(d => d.Values["TextEntityHash"]);
			EnrichSaveEntityData contactInfo = data.First(d => d.EntityName == "Contact");
			Guid contactId = Guid.Parse(contactInfo.Values["Id"]);
			string contactName = contactInfo.Values["Name"].ToString();
			Log.Info(string.Format("GetNotificationsData: EnrchTextEntity hashes: {0}",
				textEntityHashes.ConcatIfNotEmpty(",")));
			Select select = GetNotificationsDataSelect(textEntityHashes);
			string sqlText = select.GetSqlText();
			Log.Debug(string.Format("GetNotificationsData: sqlText: {0}", sqlText));
			return FillNotifications(select, contactId, contactName);
		}

		/// <summary>
		/// Creates users notification data collection.
		/// </summary>
		/// <param name="select"><see cref="Select"/> instance.</param>
		/// <param name="contactId"><see cref="Contact"/> instance unique identifier.</param>
		/// <param name="contactName"><see cref="Contact"/> instance name.</param>
		/// <returns>Users notification data collection.</returns>
		protected Dictionary<Guid, List<EnrichActivityInfo>> FillNotifications(Select select, Guid contactId, string contactName) {
			var result = new Dictionary<Guid, List<EnrichActivityInfo>>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid subsriberId = dataReader.GetColumnValue<Guid>("AdminUnitId");
						Guid activityId = dataReader.GetColumnValue<Guid>("ActivityId");
						Log.Debug(string.Format("FillNotifications: activityId - {0}, subsriberId - {1}", activityId, subsriberId));
						List<EnrichActivityInfo> subsriberActivities;
						if (!result.ContainsKey(subsriberId)) {
							subsriberActivities = new List<EnrichActivityInfo>();
							result.Add(subsriberId, subsriberActivities);
						} else {
							subsriberActivities = result[subsriberId];
						}
						subsriberActivities.AddIfNotExists(new EnrichActivityInfo {
							ActivityId = activityId,
							ContactId = contactId,
							ContactName = contactName
						});
					}
				}
			}
			Log.Info(string.Format("FillNotifications: created notifications for {0} subsribers", result.Count));
			return result;
		}

		/// <summary>
		/// Creates users notification data collection.
		/// </summary>
		/// <param name="select"><see cref="Select"/> instance.</param>
		/// <param name="contactId"><see cref="Contact"/> instance unique identifier.</param>
		/// <returns>Users notification data collection.</returns>
		protected Dictionary<Guid, List<EnrichActivityInfo>> FillNotifications(Select select, Guid contactId) {
			return FillNotifications(select, contactId, null);
		}

		/// <summary>
		/// Sends update message to users.
		/// </summary>
		/// <param name="notifications">Notifications collection.</param>
		/// <param name="savedData">Enriched data collection.</param>
		protected virtual void SendUsersNotifications(Dictionary<Guid, List<EnrichActivityInfo>> notifications) {
			if (notifications.IsEmpty()) {
				Log.Info("SendUsersNotifications: no notifications need to be sended");
				return;
			}
			foreach (KeyValuePair<Guid, List<EnrichActivityInfo>> valuePair in notifications) {
				Guid subscriberId = valuePair.Key;
				IMsgChannel channel = GetMessageChannel(subscriberId);
				if (channel == null) {
					continue;
				}
				List<EnrichActivityInfo> activityIds = valuePair.Value;
				var simpleMessage = new SimpleMessage();
				simpleMessage.Body = JsonConvert.SerializeObject(activityIds);
				simpleMessage.Id = channel.Id;
				simpleMessage.Header.BodyTypeName = "EnrichedDataSaved";
				simpleMessage.Header.Sender = "EmailMining";
				Log.Info(string.Format("SendUsersNotifications: sending message {0} to user {1}", simpleMessage.Body,
					subscriberId));
				channel.PostMessage(simpleMessage);
			}
		}

		/// <summary>
		/// Gets <see cref="IMsgChannel"/> instance for <paramref name="sysAdminUnitId"/>.
		/// </summary>
		/// <param name="sysAdminUnitId"><see cref="SysAdminUnit"/> instance unique identifier.</param>
		/// <returns><see cref="IMsgChannel"/> instance.</returns>
		protected virtual IMsgChannel GetMessageChannel(Guid sysAdminUnitId) {
			return MsgChannelManager.Instance.FindItemByUId(sysAdminUnitId);
		}

		/// <summary>
		/// Updates participants for enriched emails.
		/// </summary>
		/// <param name="notifications">Users notifications collection.</param>
		protected virtual void UpdateActivityParticipants(Dictionary<Guid, List<EnrichActivityInfo>> notifications) {
			EntitySchema activitySchema = _userConnection.EntitySchemaManager.GetInstanceByName("Activity");
			foreach (Guid activityId in notifications.SelectMany(kvp => kvp.Value).Select(eai => eai.ActivityId).Distinct()) {
				Entity activity = activitySchema.CreateEntity(_userConnection);
				if (activity.FetchFromDB(activityId)) {
					Log.Info(string.Format("UpdateActivityParticipants: Call update ActivityParticipant for activity {0}",
						activityId));
					ParticipantsHelper.InitializeParameters(activity, true);
					ParticipantsHelper.SetEmailParticipants();
					_participantsHelper = null;
				}
			}
		}

		/// <summary>
		/// Returns need regenerate email participants flag.
		/// </summary>
		/// <param name="savedData">Save data collection.</param>
		/// <returns><c>True</c> if email participants need reloading, <c>false</c> otherwise.</returns>
		protected virtual bool GetNeedRegenerateParticipants(IEnumerable<EnrichSaveEntityData> savedData) {
			return savedData.Any(data => data.EntityName == "ContactCommunication" &&
					data.Values["CommunicationType"].ToLower() == CommunicationTypeConsts.EmailId);
		}

		/// <summary>
		/// Updates <see cref="EnrchEmailData"/> status.
		/// </summary>
		/// <param name="savedData">Save data collection.</param>
		protected virtual void UpdateEnrichEmailDataStatus(IEnumerable<EnrichSaveEntityData> savedData) {
			IEnumerable<string> enrchProcessedDataHashes = savedData
				.Where(item => item.EntityName == "EnrchProcessedData")
				.Select(item => item.Values["TextEntityHash"]);
			if (enrchProcessedDataHashes.IsEmpty()) {
				Log.Warn("UpdateEnrichEmailDataStatus: No EnrchEmailData need to be updated, status update skipped.");
				return;
			}
			var update = new Update(_userConnection, "EnrchEmailData")
					.Set("Status", Column.Parameter(EnrichEmailDataStatus.Enriched.ToString()))
				.Where("Id").In(
						new Select(_userConnection)
							.Column("SETE", "EnrchEmailDataId")
						.From("EnrchTextEntity").As("SETE")
						.Where("SETE", "Hash").In(Column.Parameters(enrchProcessedDataHashes))
					)
					.And().Not().Exists(
						new Select(_userConnection)
							.Column(Column.Const(1))
						.From("EnrchTextEntity").As("ETE")
							.LeftOuterJoin("EnrchProcessedData").As("EPD").On("EPD", "TextEntityHash")
								.IsEqual("ETE", "Hash")
						.Where("ETE", "EnrchEmailDataId").IsEqual("EnrchEmailData", "Id")
							.And("EPD", "Id").IsNull()
				) as Update;
			string sqlText = update.GetSqlText();
			Log.Debug(string.Format("UpdateEnrichEmailDataStatus: update text: {0}, EED Ids: {1}", sqlText,
				enrchProcessedDataHashes.ConcatIfNotEmpty(",")));
			update.Execute();
		}

		/// <summary>
		/// Returns <paramref name="contact"/> is employee.
		/// </summary>
		/// <param name="contact"><see cref="Contact"/> instance.</param>
		/// <returns><c>True</c> if contact employee, <c>false</c> otherwise.</returns>
		protected virtual bool GetIsContactEmployee(Entity contact) {
			Guid contactType = contact.GetTypedColumnValue<Guid>("TypeId");
			bool result = contactType.Equals(ContactConsts.EmployeeTypeId);
			string logTpl = result
				? "GetIsContactEmployee: Contact {0} is employee"
				: "GetIsContactEmployee: Contact {0} is not employee";
			Log.Info(string.Format(logTpl, contact.PrimaryColumnValue));
			return result;
		}

		/// <summary>
		/// Updates activities relations columns.
		/// </summary>
		/// <param name="notifications">Users notifications collection.</param>
		/// <param name="savedData">Save data collection.</param>
		protected virtual void UpdateActivitiesRelations(Dictionary<Guid, List<EnrichActivityInfo>> notifications,
				IEnumerable<EnrichSaveEntityData> savedData) {
			EnrichSaveEntityData contactInfo = savedData.First(d => d.EntityName == "Contact");
			Guid contactId = Guid.Parse(contactInfo.Values["Id"]);
			IEnumerable<Guid> activityIds = notifications.SelectMany(kvp => kvp.Value).Select(eai => eai.ActivityId);
			if (activityIds.IsEmpty()) {
				Log.Warn("UpdateActivitiesRelations: There is not activities to update realtions.");
				return;
			}
			EntitySchema contactSchema = _userConnection.EntitySchemaManager.GetInstanceByName("Contact");
			Entity contact = contactSchema.CreateEntity(_userConnection);
			Log.Info(string.Format("UpdateActivitiesRelations: Updating activities {0} with contact {1}",
				activityIds.Select(aid => aid.ToString()).ConcatIfNotEmpty(", "), contactId));
			if (contact.FetchFromDB(contactId) && !GetIsContactEmployee(contact)) {
				Guid accountId = contact.GetTypedColumnValue<Guid>("AccountId");
				Update activityUpdate = new Update(_userConnection, "Activity")
						.Set("ContactId", Column.Parameter(contactId));
				if (accountId.IsNotEmpty()) {
					activityUpdate = activityUpdate.Set("AccountId", Column.Parameter(accountId));
				}
				activityUpdate = activityUpdate.Where("Id").In(Column.Parameters(activityIds))
						.And("ContactId").IsNull() as Update;
				string sqlText = activityUpdate.GetSqlText();
				Log.Debug(string.Format("UpdateActivitiesRelations: sql {0},\r\ncontact id: {1}, account id: {2}",
					sqlText, contactId, accountId));
				activityUpdate.Execute();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates and fills <see cref="CloudDataResponse"/> instance, using <paramref name="entityId"/> and
		/// <paramref name="entityName"/>.
		/// </summary>
		/// <param name="entityId"><see cref="Entity"/> instance unique identifier.</param>
		/// <param name="entityName"><see cref="Entity"/> name.</param>
		/// <returns><see cref="CloudDataResponse"/> instance.</returns>
		/// <remarks><see cref="Activity"/> and <see cref="Contact"/> entities are supported.</remarks>
		public virtual CloudDataResponse GetCloudActions(Guid entityId, string entityName) {
			Log.Info(string.Format("GetCloudActions: started, entityId={0}, entityName={1}", entityId, entityName));
			return GetCloudActionsFromDB(entityId, entityName);
		}

		/// <summary>
		/// Creates and fills <see cref="EnrichTextDataResponse"/> instance, using <paramref name="entityId"/> and
		/// <paramref name="entityName"/>.
		/// </summary>
		/// <param name="entityId"><see cref="Entity"/> instance unique identifier.</param>
		/// <param name="entityName"><see cref="Entity"/> name.</param>
		/// <returns><see cref="EnrichTextDataResponse"/> instance.</returns>
		public virtual EnrichTextDataResponse GetEnrchTextData(Guid entityId, string entityName) {
			Log.Info(string.Format("GetEnrchTextData: started, entityId={0}, entityName={1}", entityId, entityName));
			return GetEnrchTextDataFromDB(entityId, entityName);
		}

		/// <summary>
		/// Saves all items from <paramref name="rawData"/>.
		/// </summary>
		/// <param name="rawData"><see cref="EnrichSaveEntityData"/> collection.</param>
		public virtual void SaveEnrichedData(IEnumerable<EnrichSaveEntityData> rawData) {
			Log.Info("SaveEnrichedData started");
			Dictionary<Guid, List<EnrichActivityInfo>> sendData = GetNotificationsData(rawData);
			IEnumerable<EnrichSaveEntityData> preparedData = PrepareSaveData(rawData);
			if (preparedData.IsEmpty()) {
				Log.Warn("SaveEnrichedData: preparedData is empty, nothing will be enriched");
				return;
			}
			foreach (EnrichSaveEntityData data in preparedData) {
				SaveEnrichedEntity(data);
			}
			CreateEnrchFoundContact();
			UpdateEnrchFoundContact();
			UpdateEnrichEmailDataStatus(rawData);
			if (GetNeedRegenerateParticipants(preparedData)) {
				UpdateActivityParticipants(sendData);
			}
			UpdateActivitiesRelations(sendData, preparedData);
			SendUsersNotifications(sendData);
			Log.Info("SaveEnrichedData ended");
		}

		#endregion

	}

	#endregion

}

