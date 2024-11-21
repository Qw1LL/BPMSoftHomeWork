namespace BPMSoft.Configuration.EmailMining
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;
	using global::Common.Logging;
	using BPMSoft.Enrichment.Interfaces;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Monitoring;

	#region Class: EmailMiner

	/// <summary>
	/// Business logic for email parsing.
	/// </summary>
	public class EmailMiner
	{

		private class IdentificationInfo
		{
			public bool IsIdentified { get; set; }
			public bool IsActual { get; set; }
		}

		/// <summary>
		/// The result of the email mining.
		/// </summary>
		[DataContract]
		public class MiningResult
		{
			/// <summary>
			/// The email activity identifier.
			/// </summary>
			[DataMember(Name = "activityId")]
			public Guid ActivityId { get; set; }
			/// <summary>
			/// Activity enrich status <see cref="EnrichStatus"/>.
			/// </summary>
			[DataMember(Name = "enrichStatus")]
			public string EnrichStatus { get; set; }
			/// <summary>
			/// The enrich email data records identifier.
			/// </summary>
			[DataMember(Name = "enrchEmailDataId")]
			public Guid EnrchEmailDataId { get; set; }
			/// <summary>
			/// The enrich email data status  <see cref="EnrichEmailDataStatus"/>.
			/// </summary>
			[DataMember(Name = "enrchEmailDataStatus")]
			public string EnrchEmailDataStatus { get; set; }
		}

		#region Consts: Private

		private const string IdentificationActualPeriodSysSettingsName = "EmailMiningIdentificationActualPeriod";
		private const string EmailMiningTimeMetricName = "email_mining_latency_seconds";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("EmailMining");
		private readonly UserConnection _userConnection;
		private readonly IEmailMiningServiceProxy _emailMinerService;
		private readonly IContactSearcher _contactSearcher;
		private readonly IDeduplicator _deduplicator;
		private readonly DateTime _actualMinDate;
		private readonly EntitySchema _enrchTextEntitySchema;
		private readonly EnrichEntitySearchHelper _enrichEntitySearchHelper;
		private readonly IMetricReporter _metricReporter = ClassFactory.Get<IMetricReporter>();

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Inintialize new instance of <see cref="EmailMiner"/>
		/// </summary>
		/// <param name="userConnection">User connection for data operations (search contacts, accounts).</param>
		public EmailMiner(UserConnection userConnection) {
			_userConnection = userConnection;
			var userConnectionConstructorArgument = new ConstructorArgument("userConnection", userConnection);
			_emailMinerService = ClassFactory.Get<IEmailMiningServiceProxy>(userConnectionConstructorArgument);
			_contactSearcher = ClassFactory.Get<IContactSearcher>(userConnectionConstructorArgument);
			_deduplicator = ClassFactory.Get<IDeduplicator>(userConnectionConstructorArgument);
			int actualDaysPeriod = Core.Configuration.SysSettings.GetValue(userConnection,
				IdentificationActualPeriodSysSettingsName, 1);
			_actualMinDate = _userConnection.CurrentUser.GetCurrentDateTime().AddDays(-actualDaysPeriod);
			_enrchTextEntitySchema = _userConnection.EntitySchemaManager.GetInstanceByName("EnrchTextEntity");
			_enrichEntitySearchHelper = new EnrichEntitySearchHelper(_userConnection);
		}

		#endregion

		#region Methods: Private

		private List<MiningResult> ProcessEntities(Dictionary<Entity, GetEmailEntitiesResponse> minedInfo) {
			var results = new List<MiningResult>();
			foreach (KeyValuePair<Entity, GetEmailEntitiesResponse> pairs in minedInfo) {
				Entity activity = pairs.Key;
				GetEmailEntitiesResponse response = pairs.Value;
				try {
					if (response.IsFailure) {
						SetAcivityIsEnriched(activity.PrimaryColumnValue, Guid.Empty, EnrichStatus.Error);
						continue;
					}
					TextEntities emailEntities = response.TextEntities;
					string entitiesHash = emailEntities.GetHash();
					Entity enrichedRecord = FindEnrichedData(entitiesHash);
					bool isNewEnrichedData = enrichedRecord == null;
					Guid enrchEmailDataId;
					EnrichEmailDataStatus status;
					if (isNewEnrichedData) {
						enrichedRecord = CreateNewEnrichedData(emailEntities);
						enrchEmailDataId = enrichedRecord.PrimaryColumnValue;
						status = EnrichEmailDataStatus.Mined;
						CreateEnrichedTextEntities(enrchEmailDataId, emailEntities);
					} else {
						enrchEmailDataId = enrichedRecord.PrimaryColumnValue;
						status = enrichedRecord.GetTypedColumnValue<string>("Status");
					}
					Guid primaryContactTextEntityId =
						FindPrimaryContact(emailEntities, enrchEmailDataId, isNewEnrichedData);
					string sender = activity.GetTypedColumnValue<string>("Sender");
					string senderEmail = sender.ExtractEmailAddress();
					Dictionary<Guid, Guid> identifiedContacts = UpdateContactIdentificationInfo(enrchEmailDataId,
						emailEntities, senderEmail, isNewEnrichedData);
					UpdateAccountIdentificationInfo(enrchEmailDataId, emailEntities, isNewEnrichedData);
					if (senderEmail.IsNotNullOrEmpty()) {
						AppendSenderEmail(enrchEmailDataId, senderEmail, response.IsSenderEmailDomainFree,
							primaryContactTextEntityId, emailEntities);
					}
					_deduplicator.DeduplicateContactData(identifiedContacts, emailEntities);
					results.Add(new MiningResult {
						ActivityId = activity.PrimaryColumnValue,
						EnrchEmailDataId = enrchEmailDataId,
						EnrichStatus = EnrichStatus.Done,
						EnrchEmailDataStatus = status
					});
					SetAcivityIsEnriched(activity.PrimaryColumnValue, enrichedRecord.PrimaryColumnValue,
						EnrichStatus.Done);
					PublishEmailEnrichmentMetrics(activity);
				} catch (Exception ex) {
					_log.ErrorFormat("Cannot save enriched data for email id = {0}. Error: {1}",
						activity.PrimaryColumnValue, ex);
				}
			}
			return results;
		}

		private void PublishEmailEnrichmentMetrics(Entity activity) {
			var startDate = activity.GetTypedColumnValue<DateTime>("CreatedOn");
			var now = _userConnection.CurrentUser.GetCurrentDateTime();
			var miningDurationSec = now.Subtract(startDate).TotalSeconds;
			_metricReporter.Gauge(EmailMiningTimeMetricName, miningDurationSec);
		}

		private void SetAcivityIsEnriched(Guid activityId, Guid enrchEmailDataId, EnrichStatus status) {
			var update = (Update)new Update(_userConnection, "Activity").Set("EnrichStatus",
				Column.Parameter(status.ToString()))
				.Where("Id").IsEqual(Column.Parameter(activityId));
			if (enrchEmailDataId != Guid.Empty) {
				update.Set("EnrchEmailDataId", Column.Parameter(enrchEmailDataId));
			}
			update.Execute();
		}

		private void UpdateAccountIdentificationInfo(Guid enrchEmailDataId, TextEntities textEntities,
				bool isNewEnrichedData) {
			HashSet<OrganizationEntity> organizations = textEntities.Organizations;
			foreach (OrganizationEntity organizationEntity in organizations) {
				bool isAccountIdentified = false;
				if (!isNewEnrichedData) {
					string organizationHash = organizationEntity.GetHash();
					isAccountIdentified = CheckActualAccountIdentification(organizationHash, enrchEmailDataId);
				}
				if (isAccountIdentified) {
					continue;
				}
				IEnumerable<Guid> accountIds;
				AccountIdentificationType identificationType = _enrichEntitySearchHelper
					.IdentifyAccount(organizationEntity, textEntities, out accountIds);
				if (!accountIds.IsNullOrEmpty()) {
					Guid entityId = GetTextEntityId(enrchEmailDataId, isNewEnrichedData, organizationEntity);
					if (entityId.IsEmpty()) {
						continue;
					}
					_enrichEntitySearchHelper.AddFoundAccounts(entityId, accountIds, identificationType);
				}
			}
		}

		private Dictionary<Guid, Guid> UpdateContactIdentificationInfo(Guid enrchEmailDataId, 
				TextEntities textEntities, string senderEmail, bool isNewEnrichedData) {
			HashSet<ContactEntity> contacts = textEntities.Contacts;
			Dictionary<Guid, Guid> identifiedContacts = new Dictionary<Guid, Guid>();
			foreach (ContactEntity contactEntity in contacts) {
				bool isContactIdentified = false;
				if (!isNewEnrichedData) {
					string contactHash = contactEntity.GetHash();
					isContactIdentified = CheckActualContactIdentification(contactHash, enrchEmailDataId);
				}
				if (isContactIdentified) {
					continue;
				}
				IEnumerable<Guid> contactIds;
				ContactIdentificationType identificationType = IdentifyContact(contactEntity, textEntities, senderEmail,
					out contactIds);
				if (!contactIds.IsNullOrEmpty()) {
					if (contactIds.Count() == 1) {
						identifiedContacts.Add(contactEntity.Id, contactIds.First());
					}
					Guid entityId = GetTextEntityId(enrchEmailDataId, isNewEnrichedData, contactEntity);
					if (entityId.IsEmpty()) {
						continue;
					}
					_enrichEntitySearchHelper.AddFoundContacts(entityId, contactIds, identificationType);
				}
			}
			return identifiedContacts;
		}

		private Guid GetTextEntityId(Guid enrchEmailDataId, bool isNewEnrichedData, MiningEntity entity) {
			if (!isNewEnrichedData) {
				return GetTextEntityId(entity.GetHash(), enrchEmailDataId);
			}
			return entity.Id;
		}

		private Guid GetTextEntityId(string entityHash, Guid enrchEmailDataId) {
			var select = (Select)new Select(_userConnection)
					.Column("Id")
				.From("EnrchTextEntity")
				.Where("Hash").IsEqual(Column.Parameter(entityHash))
					.And("EnrchEmailDataId").IsEqual(Column.Parameter(enrchEmailDataId));
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					if (!dataReader.Read()) {
						_log.WarnFormat("Text entity not found by hash '{0}' and enrchEmailDataId {1}",
							entityHash, enrchEmailDataId);
						return Guid.Empty;
					}
					Guid entityId = dataReader.GetColumnValue<Guid>("Id");
					if (dataReader.Read()) {
						_log.WarnFormat("Found more than 1 text entities by hash '{0}' and enrchEmailDataId {1}",
							entityHash, enrchEmailDataId);
					}
					return entityId;
				}
			}
		}

		private ContactIdentificationType IdentifyContact(ContactEntity contactEntity, TextEntities textEntities,
				string senderEmail, out IEnumerable<Guid> contactIds) {
			if (contactEntity.IsFoundInLastEmail) {
				contactIds = _contactSearcher.SearchByEmails(new List<string> { senderEmail });
				if (!contactIds.IsNullOrEmpty()) {
					return ContactIdentificationType.SenderEmail;
				}
			}
			List<string> emails = EnrichEntitySearchHelper.GetEmails(textEntities, contactEntity.Id);
			contactIds = _contactSearcher.SearchByEmails(emails);
			if (!contactIds.IsNullOrEmpty()) {
				return ContactIdentificationType.Email;
			}
			contactIds = _contactSearcher.SearchByName(contactEntity.Value);
			if (!contactIds.IsNullOrEmpty()) {
				return ContactIdentificationType.Name;
			}
			contactIds = _contactSearcher.SearchByFirstAndLastName(contactEntity.GivenName, contactEntity.Surname);
			if (!contactIds.IsNullOrEmpty()) {
				return ContactIdentificationType.FirstLastName;
			}
			List<string> phones = EnrichEntitySearchHelper.GetPhones(textEntities, contactEntity.Id);
			contactIds = _contactSearcher.SearchByPhones(phones);
			if (!contactIds.IsNullOrEmpty()) {
				return ContactIdentificationType.Phone;
			}
			return null;
		}

		private IdentificationInfo GetContactIdentificationInfo(string contactHash, Guid enrchEmailDataId) {
			return GetIdentificationInfo(contactHash, enrchEmailDataId, "EnrchFoundContact");
		}

		private IdentificationInfo GetAccountIdentificationInfo(string accountHash, Guid enrchEmailDataId) {
			return GetIdentificationInfo(accountHash, enrchEmailDataId, "EnrchFoundAccount");
		}

		private IdentificationInfo GetIdentificationInfo(string entityHash, Guid enrchEmailDataId,
				string foundEntityTableName) {
			IdentificationInfo identificationInfo = new IdentificationInfo {
				IsIdentified = false
			};
			var select = (Select) new Select(_userConnection)
					.Column("efc", "CreatedOn")
					.Column("efc", "IdentificationType")
				.From(foundEntityTableName).As("efc")
					.InnerJoin("EnrchTextEntity").As("ete").On("ete", "Id").IsEqual("efc", "EnrchTextEntityId")
				.Where("ete", "Hash").IsEqual(Column.Parameter(entityHash))
					.And("ete", "EnrchEmailDataId").IsEqual(Column.Parameter(enrchEmailDataId));
			select.SpecifyNoLockHints();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						DateTime createdOn = dataReader.GetColumnValue<DateTime>("CreatedOn");
						string identificationType = dataReader.GetColumnValue<string>("IdentificationType");
						bool isManuallyIdentified = identificationType == IdentificationType.Manual;
						identificationInfo.IsIdentified = true;
						identificationInfo.IsActual = createdOn > _actualMinDate || isManuallyIdentified;
						if (identificationInfo.IsActual) {
							return identificationInfo;
						}
					}
				}
			}
			return identificationInfo;
		}

		private void ClearContactIdentification(string contactHash, Guid enrchEmailDataId) {
			ClearIdentification(contactHash, enrchEmailDataId, "EnrchFoundContact");
		}

		private void ClearAccountIdentification(string accountHash, Guid enrchEmailDataId) {
			ClearIdentification(accountHash, enrchEmailDataId, "EnrchFoundAccount");
		}

		private void ClearIdentification(string entityHash, Guid enrchEmailDataId, string foundEntityTableName) {
			Delete delete = (Delete) new Delete(_userConnection)
				.From(foundEntityTableName)
				.Where("IdentificationType").IsNotEqual(Column.Parameter(IdentificationType.Manual.ToString()))
					.And().Exists(
						new Select(_userConnection)
								.Column(Column.Const(null))
							.From("EnrchTextEntity").As("ete")
							.Where("ete", "Id").IsEqual(foundEntityTableName, "EnrchTextEntityId")
								.And("ete", "Hash").IsEqual(Column.Parameter(entityHash))
								.And("ete", "EnrchEmailDataId").IsEqual(Column.Parameter(enrchEmailDataId))
					);
			delete.Execute();
		}

		private bool CheckActualContactIdentification(string contactHash, Guid enrchEmailDataId) {
			IdentificationInfo identificationInfo = GetContactIdentificationInfo(contactHash, enrchEmailDataId);
			if (identificationInfo.IsIdentified && !identificationInfo.IsActual) {
				ClearContactIdentification(contactHash, enrchEmailDataId);
			}
			return identificationInfo.IsIdentified && identificationInfo.IsActual;
		}

		private bool CheckActualAccountIdentification(string accountHash, Guid enrchEmailDataId) {
			IdentificationInfo identificationInfo = GetAccountIdentificationInfo(accountHash, enrchEmailDataId);
			if (identificationInfo.IsIdentified && !identificationInfo.IsActual) {
				ClearAccountIdentification(accountHash, enrchEmailDataId);
			}
			return identificationInfo.IsIdentified && identificationInfo.IsActual;
		}

		private void CreateTextEntity(Guid enrchEmailDataId, MiningEntity textFact, EnrchTextEntityType factType,
				Guid parentId, EnrchTextEntitySource source = null, string hash = null) {
			Entity newTextEntity = _enrchTextEntitySchema.CreateEntity(_userConnection);
			newTextEntity.SetDefColumnValues();
			newTextEntity.PrimaryColumnValue = textFact.Id;
			newTextEntity.SetColumnValue("EnrchEmailDataId", enrchEmailDataId);
			if (parentId != Guid.Empty) {
				newTextEntity.SetColumnValue("ParentId", parentId);
			}
			if (source != null) {
				newTextEntity.SetColumnValue("Source", source.ToString());
			}
			newTextEntity.SetColumnValue("Type", factType.ToString());
			newTextEntity.SetColumnValue("JsonData", JsonConvert.SerializeObject(textFact));
			newTextEntity.SetColumnValue("Hash", hash ?? textFact.GetHash());
			newTextEntity.SetColumnValue("HashVersion", textFact.GetHashVersion());
			newTextEntity.Save();
		}

		private void CreateEnrichedTextEntities(Guid enrchEmailDataId, TextEntities emailEntities) {
			foreach (OrganizationEntity organization in emailEntities.Organizations) {
				CreateTextEntity(enrchEmailDataId, organization, EnrchTextEntityType.Organization, Guid.Empty);
			}
			foreach (ContactEntity contact in emailEntities.Contacts) {
				CreateTextEntity(enrchEmailDataId, contact, EnrchTextEntityType.Contact, contact.OrganizationId);
			}
			foreach (CommunicationEntity communication in emailEntities.Communications) {
				CreateTextEntity(enrchEmailDataId, communication, EnrchTextEntityType.Communication,
					communication.ContactId);
			}
			foreach (AddressEntity address in emailEntities.Addresses) {
				CreateTextEntity(enrchEmailDataId, address, EnrchTextEntityType.Address, address.ContactId);
			}
			foreach (JobEntity job in emailEntities.Jobs) {
				CreateTextEntity(enrchEmailDataId, job, EnrchTextEntityType.Job, job.ContactId);
			}
		}

		private Entity CreateNewEnrichedData(TextEntities emailEntities) {
			EntitySchema enrchEmailDataSchema = _userConnection.EntitySchemaManager.GetInstanceByName("EnrchEmailData");
			Entity newEnrichedData = enrchEmailDataSchema.CreateEntity(_userConnection);
			newEnrichedData.SetDefColumnValues();
			newEnrichedData.SetColumnValue("JsonData", JsonConvert.SerializeObject(emailEntities));
			newEnrichedData.SetColumnValue("Hash", emailEntities.GetHash());
			newEnrichedData.Save();
			return newEnrichedData;
		}

		private Entity FindEnrichedData(string hash) {
			EntitySchema enrichedDataSchema = _userConnection.EntitySchemaManager.GetInstanceByName("EnrchEmailData");
			var esq = new EntitySchemaQuery(enrichedDataSchema);
			esq.PrimaryQueryColumn.IsVisible = true;
			esq.AddColumn("Status");
			esq.RowCount = 1;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Hash", hash));
			EntityCollection collection = esq.GetEntityCollection(_userConnection);
			if (collection.Count == 0) {
				return null;
			}
			return collection.First.Value;
		}

		private Guid FindPrimaryContact(TextEntities textEntities, Guid enrchEmailDataId, bool newContact) {
			ContactEntity primaryContact = textEntities.Contacts
				.FirstOrDefault(contact => contact.IsFoundInLastEmail);
			if (primaryContact == null) {
				return Guid.Empty;
			}
			if (newContact) {
				return primaryContact.Id;
			} else {
				string hash = primaryContact.GetHash();
				return GetTextEntityId(hash, enrchEmailDataId);
			}
		}

		private void AppendSenderEmail(Guid enrchEmailDataId, string senderEmail, bool isFreeDomain, 
				Guid primaryContact, TextEntities textEntities) {
			if (primaryContact.IsEmpty()) {
				return;
			}
			CommunicationEntity senderEmailEte = new CommunicationEntity {
				Id = Guid.NewGuid(),
				Value = senderEmail,
				ContactId = primaryContact,
				Type = EnrchCommunicationType.Email.ToString(),
				IsFoundInLastEmail = true,
				IsPhone = false,
				IsFreeDomain = isFreeDomain
			};
			if (textEntities.Communications.Contains(senderEmailEte)) {
				return;
			}
			string entityHash = senderEmailEte.GetHash();
			var select = (Select)new Select(_userConnection)
					.Column(Func.Count("Id"))
				.From("EnrchTextEntity")
				.Where("Hash").IsEqual(Column.Parameter(entityHash))
					.And("ParentId").IsEqual(Column.Parameter(primaryContact));
			int emailsWithSameHash = select.ExecuteScalar<int>();
			if (emailsWithSameHash > 0) {
				return;
			}
			textEntities.Communications.Add(senderEmailEte);
			CreateTextEntity(enrchEmailDataId, senderEmailEte, EnrchTextEntityType.Communication, primaryContact,
				EnrchTextEntitySource.AppDbActivity, entityHash);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Runs text entities extraction for email collection.
		/// </summary>
		/// <param name="emails">Email collection for mining. Entities must be loaded with Id, Body, IsHtmlBody, Sender,
		/// EnrichStatus, EnrchEmailData, CreatedOn columns.</param>
		public virtual List<MiningResult> Execute(EntityCollection emails) {
			Dictionary<Entity, GetEmailEntitiesResponse> minedCollection = _emailMinerService.BatchCall(emails);
			List<MiningResult> results = ProcessEntities(minedCollection);
			return results;
		}

		#endregion

	}

	#endregion

}

