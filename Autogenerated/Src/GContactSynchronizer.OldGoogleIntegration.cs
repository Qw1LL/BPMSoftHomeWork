namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Reflection;
	using Google.GData.Extensions;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.GoogleServices;

	#region Class: GContactSynchronizer

	/// <summary>
	/// Google contacts synchronizer class.
	/// </summary>
	public class GContactSynchronizer : BaseGoogleSynchronizer
	{
		#region Constants: Public

		/// <summary>
		/// Phone types mapping.
		/// </summary>
		private readonly Dictionary<string, Guid> ContactPhoneTypesMapping =
			new Dictionary<string, Guid>() {
				{ContactsRelationships.IsWork, Guid.Parse(CommunicationTypeConsts.WorkPhoneId)},
				{ContactsRelationships.IsWorkFax, Guid.Parse(CommunicationTypeConsts.WorkPhoneId)},
				{ContactsRelationships.IsWorkMobile, Guid.Parse(CommunicationTypeConsts.WorkPhoneId)},
				{ContactsRelationships.IsWorkPager, Guid.Parse(CommunicationTypeConsts.WorkPhoneId)},
				{ContactsRelationships.IsCompanyMain, Guid.Parse(CommunicationTypeConsts.WorkPhoneId)},
				{ContactsRelationships.IsHome, Guid.Parse(CommunicationTypeConsts.HomePhoneId)},
				{ContactsRelationships.IsHomeFax, Guid.Parse(CommunicationTypeConsts.HomePhoneId)},
				{ContactsRelationships.IsMobile, Guid.Parse(CommunicationTypeConsts.MobilePhoneId)},
				{ContactsRelationships.IsMain, Guid.Parse(CommunicationTypeConsts.MobilePhoneId)},
				{ContactsRelationships.IsOther, Guid.Parse(CommunicationTypeConsts.OtherPhoneId)},
				{ContactsRelationships.IsGeneral, Guid.Parse(CommunicationTypeConsts.OtherPhoneId)},
				{ContactsRelationships.IsFax, Guid.Parse(CommunicationTypeConsts.OtherPhoneId)},
				{ContactsRelationships.IsPager, Guid.Parse(CommunicationTypeConsts.OtherPhoneId)},
				{ContactsRelationships.IsOtherFax, Guid.Parse(CommunicationTypeConsts.OtherPhoneId)}
			};

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes an instance of GContactSynchronizer.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		public GContactSynchronizer(UserConnection userConnection)
			: base(userConnection) {
			_canImportContactsFromGoogle = userConnection.DBSecurityEngine.GetCanExecuteOperation("CanImportContactsFromGoogle",
				userConnection.CurrentUser.Id);
			_canExportContactsToGoogle = userConnection.DBSecurityEngine.GetCanExecuteOperation("CanExportContactsToGoogle",
				userConnection.CurrentUser.Id);
			_canManageLookups = userConnection.DBSecurityEngine.GetCanExecuteOperation("CanManageLookups",
				userConnection.CurrentUser.Id);
			SyncProvider = new GContactSyncProvider() {
				UserConnection = userConnection
			};
			MessageSender = "GoogleContact";
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// Contact tag for synchronization.
		/// </summary>
		private Guid ContactGroupId {
			get;
			set;
		}

		private readonly bool _canImportContactsFromGoogle;

		/// <summary>
		/// Can import contacts from google contacts.
		/// </summary>
		private bool CanImportContactsFromGoogle {
			get {
				return _canImportContactsFromGoogle;
			}
		}

		private readonly bool _canExportContactsToGoogle;

		/// <summary>
		/// Can export contacts to google contacts.
		/// </summary>
		private bool CanExportContactsToGoogle {
			get {
				return _canExportContactsToGoogle;
			}
		}

		private readonly bool _canManageLookups;

		/// <summary>
		/// Can manage lookups
		/// </summary>
		private bool CanManageLookups {
			get {
				return _canManageLookups;
			}
		}

		private string _shippingLabel;

		/// <summary>
		/// Google contact address shipping label.
		/// </summary>
		private string ShippingLabel {
			get {
				if (_shippingLabel.IsNullOrEmpty()) {
					_shippingLabel = new LocalizableString(UserConnection.ResourceStorage, "GContactSynchronizer",
						"LocalizableStrings.ShippingLabel.Value");
				}
				return _shippingLabel;
			}
		}

		private string _extensionPhoneLabel;

		/// <summary>
		/// Google contact extension phone label.
		/// </summary>
		private string ExtensionPhoneLabel {
			get {
				if (_extensionPhoneLabel.IsNullOrEmpty()) {
					_extensionPhoneLabel = new LocalizableString(UserConnection.ResourceStorage, "GContactSynchronizer",
						"LocalizableStrings.ExtensionPhoneLabel.Value");
				}
				return _extensionPhoneLabel;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Google contacts sync provider.
		/// </summary>
		public GContactSyncProvider SyncProvider {
			get;
			set;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Returns contact address entity schema query with filter by <paramref name="contactId"/>.
		/// </summary>
		/// <param name="contactId">Contact unique identifier.</param>
		/// <returns>Contact address entity schema query.</returns>
		private EntitySchemaQuery GetContactAddressesESQ(Guid contactId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactAddress");
			esq.AddAllSchemaColumns();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Contact", contactId));
			return esq;
		}

		/// <summary>
		/// Returns google contact structured postal addresses.
		/// </summary>
		/// <param name="contactId">Contact unique identifier.</param>
		/// <returns>Collection of google contact structured postal addresses.</returns>
		private IEnumerable<StructuredPostalAddress> GetContactAddresses(Guid contactId) {
			var addressesESQ = GetContactAddressesESQ(contactId);
			var addresses = addressesESQ.GetEntityCollection(UserConnection);
			var contactAddresses = new List<StructuredPostalAddress>();
			foreach (var item in addresses) {
				StructuredPostalAddress structuredPostalAddress = new StructuredPostalAddress {
					City = item.GetTypedColumnValue<string>("CityName"),
					Region = item.GetTypedColumnValue<string>("RegionName"),
					Country = item.GetTypedColumnValue<string>("CountryName"),
					Postcode = item.GetTypedColumnValue<string>("Zip"),
					Primary = item.GetTypedColumnValue<bool>("Primary"),
					Street = item.GetTypedColumnValue<string>("Address"),
				};
				var bpmAddressType = item.GetTypedColumnValue<Guid>("AddressTypeId");
				FillGoogleAddressType(bpmAddressType, structuredPostalAddress);
				contactAddresses.Add(structuredPostalAddress);
			}
			return contactAddresses;
		}

		/// <summary>
		/// Fills google contact address type.
		/// </summary>
		/// <param name="bpmAddressType">Local address type.</param>
		/// <param name="structuredPostalAddress">Google contact address.</param>
		private void FillGoogleAddressType(Guid bpmAddressType, StructuredPostalAddress structuredPostalAddress) {
			if (bpmAddressType == AddressTypeConsts.BusinessId) {
				structuredPostalAddress.Rel = ContactsRelationships.IsWork;
			} else if (bpmAddressType == AddressTypeConsts.HomeId) {
				structuredPostalAddress.Rel = ContactsRelationships.IsHome;
			} else if (bpmAddressType == AddressTypeConsts.ShippingId) {
				structuredPostalAddress.Label = ShippingLabel;
			} else {
				structuredPostalAddress.Rel = ContactsRelationships.IsOther;
			}
		}

		/// <summary>
		/// Fills google contact entity from <paramref name="contact"/>.
		/// </summary>
		/// <param name="contact">bpmcrm entity.</param>
		/// <returns>Google contact entity.</returns>
		private GoogleContact ContactToGContact(Contact contact) {
			var googleContact = new GoogleContact() {
				ContactId = contact.PrimaryColumnValue,
				SalutationType = contact.SalutationTypeName,
				Birthday = contact.BirthDate,
				Notes = StringUtilities.ConvertHtmlToPlainText(contact.Notes),
				Skype = contact.Skype,
				PostalAddresses = GetContactAddresses(contact.PrimaryColumnValue),
				Department = contact.DepartmentName,
				Company = contact.AccountName,
				JobTitle = contact.JobTitle
			};
			FillGContactCommunications(googleContact, contact);
			GetContactName(googleContact, contact);
			return googleContact;
		}

		/// <summary>
		/// Create contacts entity schema query for update operation.
		/// </summary>
		/// <returns>Contacts entity schema query.</returns>
		private EntitySchemaQuery CreateContactESQForUpdate() {
			var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var esq = new EntitySchemaQuery(contactSchema);
			esq.AddAllSchemaColumns();
			esq.AddColumn("[ContactCorrespondence:Contact].SourceContactId");
			esq.AddColumn("[ContactCorrespondence:Contact].ModifiedOn");
			return esq;
		}

		/// <summary>
		/// Returns contacts entity schema query for insert operation.
		/// </summary>
		/// <returns>Contacts entity schema query.</returns>
		private EntitySchemaQuery CreateContactESQForInsert() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Contact");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("CreatedOn");
			esq.AddColumn("SalutationType");
			esq.AddColumn("Owner");
			esq.AddColumn("Account");
			esq.AddColumn("Name");
			esq.AddColumn("BirthDate");
			esq.AddColumn("Notes");
			esq.AddColumn("Email");
			esq.AddColumn("MobilePhone");
			esq.AddColumn("HomePhone");
			esq.AddColumn("Skype");
			esq.AddColumn("Phone");
			esq.AddColumn("City");
			esq.AddColumn("Country");
			esq.AddColumn("Region");
			esq.AddColumn("Address");
			esq.AddColumn("Zip");
			esq.AddColumn("Department");
			esq.AddColumn("Account.Name");
			esq.AddColumn("JobTitle");
			esq.AddColumn("Surname");
			esq.AddColumn("GivenName");
			esq.AddColumn("MiddleName");
			return esq;
		}

		/// <summary>
		/// Processes <paramref name="deletedEntities"/>.
		/// </summary>
		/// <param name="deletedEntities">Google deleted entities.</param>
		private void ProcessGoogleDeletedContacts(IEnumerable<SyncEntity<GoogleContact>> deletedEntities) {
			if (deletedEntities.IsEmpty()) {
				return;
			}
			var esq = CreateContactESQForUpdate();
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			string contactInTagEntityModifiedOn = esq.AddColumn("[ContactInTag:Entity].ModifiedOn").Name;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].SocialAccountName", SocialAccountName));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].Source.Id", CommunicationConsts.GoogleTypeUId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].SourceContactId", (from a in deletedEntities
																	select a.Item.Id).ToArray()));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactInTag:Entity].Tag.Id", ContactGroupId));
			var contacts = esq.GetEntityCollection(UserConnection);
			foreach (Entity contact in contacts) {
				var gEntity =
					deletedEntities.FirstOrDefault(
						e => e.Item.Id == contact.GetTypedColumnValue<string>("ContactCorrespondence_Contact_SourceContactId"));
				if (gEntity == null) {
					continue;
				}
				var gContact = gEntity.Item;
				if ((GetUtcDateTime((DateTime)contact.GetColumnValue("ModifiedOn"))) >= gContact.ModifiedOnUTC
					|| (GetUtcDateTime((DateTime)contact.GetColumnValue(contactInTagEntityModifiedOn))) >= gContact.ModifiedOnUTC) {
					continue;
				}
				var contactId = (Guid)contact.GetColumnValue("Id");
				var del = new Delete(UserConnection).From("ContactInTag")
					.Where("EntityId").IsEqual(Column.Parameter(contactId))
					.And("TagId").IsEqual(Column.Parameter(ContactGroupId)) as Delete;
				DeletedRecordsInBPMCRMCount += del.Execute();
				if (gContact.Deleted) {
					var delContactCorrespondence = new Delete(UserConnection)
						.From("ContactCorrespondence")
						.Where("SocialAccountName").IsEqual(Column.Parameter(SocialAccountName))
						.And("SourceContactId").IsEqual(Column.Parameter(gContact.Id))
						.And("SourceId").IsEqual(Column.Parameter(CommunicationConsts.GoogleTypeUId)) as Delete;
					delContactCorrespondence.Execute();
				} else {
					var upd = new Update(UserConnection, "ContactCorrespondence").
						Set("ModifiedOn", Column.Parameter(DateTime.UtcNow)).
						Where("SocialAccountName").IsEqual(Column.Parameter(SocialAccountName)).
						And("SourceContactId").IsEqual(Column.Parameter(gContact.Id)).
						And("SourceId").IsEqual(Column.Parameter(CommunicationConsts.GoogleTypeUId)) as Update;
					upd.Execute();
				}
			}
		}

		/// <summary>
		/// Gets deleted bpmcrm contacts.
		/// </summary>
		/// <param name="newEditedEntities">Google new or modified contacts.</param>
		/// <returns>Deleted contacts collection.</returns>
		private EntityCollection GetDeletedBPMContacts(IEnumerable<SyncEntity<GoogleContact>> newEditedEntities) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactCorrespondence");
			esq.AddColumn("SourceContactId");
			esq.AddColumn("ModifiedOn");
			esq.AddColumn("Contact");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SocialAccountName", SocialAccountName));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Greater, "ModifiedOn", LastSynchronizationDate));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Source.Id",
				CommunicationConsts.GoogleTypeUId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SourceContactId",
				(from googleContact in newEditedEntities
				 select googleContact.Item.Id)));
			esq.Filters.Add(esq.CreateIsNullFilter("Contact"));
			var deletedContacts = esq.GetEntityCollection(UserConnection);
			return deletedContacts;
		}

		/// <summary>
		/// Checks if google contact is deleted in bpmcrm.
		/// </summary>
		/// <param name="gContact">Google contact.</param>
		/// <param name="deletedEntities">Deleted contacts collection.</param>
		/// <returns>Is bpmcrm contact deleted.</returns>
		private bool CheckIsDeletedContact(GoogleContact gContact, EntityCollection deletedEntities) {
			var result =
				deletedEntities.Any(
					del =>
						del.GetTypedColumnValue<string>("SourceContactId") == gContact.Id &&
						del.GetTypedColumnValue<Guid>("ContactId").IsEmpty());
			return result;
		}

		/// <summary>
		/// Processes <paramref name="newEditedEntities"/>.
		/// </summary>
		/// <param name="newEditedEntities">Google new and changed entities.</param>
		private void ProcessGoogleNewEditedContacts(IEnumerable<SyncEntity<GoogleContact>> newEditedEntities) {
			var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var esq = CreateContactESQForUpdate();
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].SocialAccountName", SocialAccountName));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].Source.Id", CommunicationConsts.GoogleTypeUId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].SourceContactId", (from a in newEditedEntities
																	select a.Item.Id)));
			var contacts = esq.GetEntityCollection(UserConnection);
			var deletedContacts = GetDeletedBPMContacts(newEditedEntities);
			var editedEntities = from a in newEditedEntities
								 join act in contacts on a.Item.Id equals
									 act.GetTypedColumnValue<string>("ContactCorrespondence_Contact_SourceContactId")
								 select a;
			var newEntities = newEditedEntities.Where(item => !editedEntities.Contains(item));
			Entity contact;
			Guid contactId;
			var contactCorrespondenceInstance = UserConnection.EntitySchemaManager.GetInstanceByName("ContactCorrespondence");
			foreach (SyncEntity<GoogleContact> gEntity in newEntities) {
				var gContact = gEntity.Item;
				if (CheckIsDeletedContact(gContact, deletedContacts)) {
					continue;
				}
				if (gContact.Name == null) {
					continue;
				}
				contact = contactSchema.CreateEntity(UserConnection);
				contact.SetDefColumnValues();
				FillContactFromGoogleContact(contact, gContact);
				var contactCorrespondenceEntity = contactCorrespondenceInstance.CreateEntity(UserConnection);
				contactCorrespondenceEntity.SetDefColumnValues();
				contactCorrespondenceEntity.SetColumnValue("SourceAccountId", SourceAccountId);
				contactCorrespondenceEntity.SetColumnValue("SocialAccountName", SocialAccountName);
				contactCorrespondenceEntity.SetColumnValue("SourceId", CommunicationConsts.GoogleTypeUId);
				contactCorrespondenceEntity.SetColumnValue("SourceContactId", gContact.Id);
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					dbExecutor.StartTransaction();
					try {
						contactCorrespondenceEntity.Save();
						contact.Save();
						FillAndSaveContactDetails(contact, gContact);
						contactId = (Guid)contact.GetColumnValue("Id");
						contactCorrespondenceEntity.SetColumnValue("ContactId", contactId);
						contactCorrespondenceEntity.Save();
						var ins = new Insert(UserConnection).Into("ContactInTag")
							.Set("CreatedOn", Column.Parameter(DateTime.UtcNow))
							.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
							.Set("EntityId", new QueryParameter(contactId))
							.Set("TagId", new QueryParameter(ContactGroupId));
						ins.Execute();
						dbExecutor.CommitTransaction();
						AddedRecordsInBPMCRMCount++;
					} catch (Exception ex) {
						dbExecutor.RollbackTransaction();
						if (ex.GetType() != typeof(RequiredColumnsEmptyValuesException)) {
							throw;
						}
					}
				}
			}
			foreach (SyncEntity<GoogleContact> gEntity in editedEntities) {
				var gContact = gEntity.Item;
				if (gContact.Name == null) {
					continue;
				}
				contact = (from a in contacts
						   where a.GetTypedColumnValue<string>("ContactCorrespondence_Contact_SourceContactId") == gContact.Id
						   select a).First();
				if ((GetUtcDateTime((DateTime)contact.GetColumnValue("ModifiedOn"))) >= gContact.ModifiedOnUTC) {
					continue;
				}
				contactId = contact.PrimaryColumnValue;
				FillContactFromGoogleContact(contact, gContact);
				if (contact.Save()) {
					FillAndSaveContactDetails(contact, gContact);
					UpdatedRecordsInBPMCRMCount++;
				}
				var upd = new Update(UserConnection, "ContactCorrespondence")
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Where("SocialAccountName").IsEqual(Column.Parameter(SocialAccountName))
					.And("SourceContactId").IsEqual(Column.Parameter(gContact.Id))
					.And("SourceId").IsEqual(Column.Parameter(CommunicationConsts.GoogleTypeUId)) as Update;
				upd.Execute();
				Select s =
					new Select(UserConnection)
						.Column("Id")
						.From("ContactInTag")
						.Where("EntityId").IsEqual(Column.Parameter(contactId))
						.And("TagId").IsEqual(Column.Parameter(ContactGroupId)) as Select;
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader dr = s.ExecuteReader(dbExecutor)) {
						if (!dr.Read()) {
							var ins = new Insert(UserConnection).Into("ContactInTag")
								.Set("CreatedOn", Column.Parameter(DateTime.UtcNow))
								.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
								.Set("EntityId", new QueryParameter(contactId))
								.Set("TagId", new QueryParameter(ContactGroupId));
							ins.Execute();
						}
					}
				}
			}
		}

		/// <summary>
		/// Processes <paramref name="gContact"/> addresses.
		/// </summary>
		/// <param name="contact">bpmcrm contact.</param>
		/// <param name="gContact">Google contact.</param>
		private void ProcessGoogleContactAddresses(Entity contact, GoogleContact gContact) {
			var contactAddressesESQ = GetContactAddressesESQ(contact.PrimaryColumnValue);
			var contactAddresses = contactAddressesESQ.GetEntityCollection(UserConnection);
			List<Entity> entities = contactAddresses.Select(entity => entity).ToList();
			var gContactAddresses = gContact.PostalAddresses;
			var structuredPostalAddresses = gContactAddresses as IList<StructuredPostalAddress> ?? gContactAddresses.ToList();
			if (gContactAddresses != null) {
				if (structuredPostalAddresses.Count > 0 &&
					structuredPostalAddresses.All(gContactAddress => !gContactAddress.Primary) && contactAddresses.Count == 0) {
					structuredPostalAddresses.First().Primary = true;
				}
				foreach (var gAddress in structuredPostalAddresses) {
					if (contactAddresses.All(address =>
						(address.GetTypedColumnValue<Guid>("AddressTypeId") != GetAddressTypeId(gAddress) ||
						address.GetTypedColumnValue<string>("CountryName") != (gAddress.Country ?? "") ||
						address.GetTypedColumnValue<string>("RegionName") != (gAddress.Region ?? "") ||
						address.GetTypedColumnValue<string>("CityName") != (gAddress.City ?? "") ||
						address.GetTypedColumnValue<string>("Address") != (gAddress.Street ?? "") ||
						address.GetTypedColumnValue<string>("Zip") != (gAddress.Postcode ?? "")))) {
						var addressEntity = GetContactAddressEntity(gAddress, contact.PrimaryColumnValue);
						if (gAddress.Primary) {
							addressEntity.Save();
						} else {
							addressEntity.CreateInsert().Execute();
						}
					}
				}
			}
			DeleteContactAddress(structuredPostalAddresses, entities);
		}

		/// <summary>
		/// Returns local address type.
		/// </summary>
		/// <param name="postalAddress">Google contact address.</param>
		/// <returns>Address type.</returns>
		private Guid GetAddressTypeId(StructuredPostalAddress postalAddress) {
			Guid addressTypeId;
			if (postalAddress.Rel != null && postalAddress.Rel == ContactsRelationships.IsHome) {
				addressTypeId = AddressTypeConsts.HomeId;
			} else if (postalAddress.Rel != null && postalAddress.Rel == ContactsRelationships.IsWork) {
				addressTypeId = AddressTypeConsts.BusinessId;
			} else if (postalAddress.Label == ShippingLabel) {
				addressTypeId = AddressTypeConsts.ShippingId;
			} else {
				addressTypeId = AddressTypeConsts.OtherId;
			}
			return addressTypeId;
		}

		/// <summary>
		/// Returns contact addrtess entity.
		/// </summary>
		/// <param name="postalAddress">Google contact address.</param>
		/// <param name="contactId">Contact unique identifier.</param>
		/// <returns>Contact address entity..</returns>
		private Entity GetContactAddressEntity(StructuredPostalAddress postalAddress, Guid contactId) {
			var contactAddressSchema = UserConnection.EntitySchemaManager.GetInstanceByName("ContactAddress");
			var contactAddress = contactAddressSchema.CreateEntity(UserConnection);
			contactAddress.SetDefColumnValues();
			contactAddress.SetColumnValue("ContactId", contactId);
			Guid addressTypeId = GetAddressTypeId(postalAddress);
			contactAddress.SetColumnValue("AddressTypeId", addressTypeId);
			contactAddress.SetColumnValue("Primary", postalAddress.Primary);
			FillAddressFields(postalAddress, contactAddress);
			contactAddress.SetColumnValue("Zip", postalAddress.Postcode);
			return contactAddress;
		}

		/// <summary>
		/// Adds filters  to <paramref name="esq"/> with <paramref name="conditions"/>.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/> instance.</param>
		/// <param name="conditions">List filter conditions.</param>
		private void AddEsqFilter(EntitySchemaQuery esq, Dictionary<string, object> conditions) {
			foreach (var condition in conditions) {
				esq.Filters.Add(condition.Value != null
					? esq.CreateFilterWithParameters(FilterComparisonType.Equal, condition.Key, condition.Value)
					: esq.CreateIsNullFilter(condition.Key));
			}
		}

		/// <summary>
		/// Gets <see cref="Entity"/> instance by <paramref name="schemaName"/> and <paramref name="conditions"/>.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="conditions">List of conditions.</param>
		/// <param name="isEntityExists">Flag,that indicates if operation was successfully completed.</param>
		/// <returns><see cref="Entity"/> instance.</returns>
		private Entity GetEntityByName(string schemaName, Dictionary<string, object> conditions, out bool isEntityExists) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			Entity entity = entitySchema.CreateEntity(UserConnection);
			if (conditions.Count == 0) {
				isEntityExists = false;
				return entity;
			}
			var esq = new EntitySchemaQuery(entitySchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			AddEsqFilter(esq, conditions);
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			if (entityCollection.Count > 0) {
				Guid entityId = (Guid)entityCollection.First().GetColumnValue("Id");
				isEntityExists = entity.FetchFromDB(entityId);
				return entity;
			}
			isEntityExists = false;
			return entity;
		}

		/// <summary>
		/// Fills local <paramref name="contactAddress"/> from <paramref name="postalAddress"/>.
		/// </summary>
		/// <param name="postalAddress">Google contact address.</param>
		/// <param name="contactAddress">bpmcrm contact address.</param>
		private void FillAddressFields(StructuredPostalAddress postalAddress, Entity contactAddress) {
			Guid? countryId = null;
			Guid? regionId = null;
			Guid? cityId = null;
			if (postalAddress.Country.IsNotNullOrEmpty()) {
				bool isEntityExists;
				Entity country = GetEntityByName("Country", new Dictionary<string, object> {
					{
						"Name", postalAddress.Country
					}
				}, out isEntityExists);
				if (isEntityExists) {
					countryId = (Guid?)country.GetColumnValue("Id");
				} else if (CanManageLookups) {
					country.SetDefColumnValues();
					country.SetColumnValue("Name", postalAddress.Country);
					SaveEntity(country);
					countryId = country.PrimaryColumnValue;
				}
				contactAddress.SetColumnValue("CountryId", countryId);
			}
			if (postalAddress.Region.IsNotNullOrEmpty()) {
				bool isEntityExists;
				Entity region = GetEntityByName("Region", new Dictionary<string, object> {
					{
						"Name", postalAddress.Region
					}, {
						"Country", countryId
					}
				}, out isEntityExists);
				if (isEntityExists) {
					regionId = (Guid?)region.GetColumnValue("Id");
				} else if (CanManageLookups) {
					region.SetDefColumnValues();
					region.SetColumnValue("Name", postalAddress.Region);
					region.SetColumnValue("CountryId", countryId);
					SaveEntity(region);
					regionId = region.PrimaryColumnValue;
				}
				contactAddress.SetColumnValue("RegionId", regionId);
			}
			if (postalAddress.City.IsNotNullOrEmpty()) {
				bool isEntityExists;
				Entity city = GetEntityByName("City", new Dictionary<string, object> {
					{
						"Name", postalAddress.City
					}, {
						"Country", countryId
					}, {
						"Region", regionId
					}
				}, out isEntityExists);
				if (isEntityExists) {
					cityId = (Guid?)city.GetColumnValue("Id");
				} else if (CanManageLookups) {
					city.SetDefColumnValues();
					city.SetColumnValue("Name", postalAddress.City);
					city.SetColumnValue("CountryId", countryId);
					city.SetColumnValue("RegionId", regionId);
					SaveEntity(city);
					cityId = city.PrimaryColumnValue;
				}
				contactAddress.SetColumnValue("CityId", cityId);
			}
			string bpmAddress = postalAddress.Street ?? string.Empty;
			if (cityId.IsNullOrEmpty()) {
				bpmAddress += string.Format(", {0}", postalAddress.City);
			}
			if (regionId.IsNullOrEmpty()) {
				bpmAddress += string.Format(", {0}", postalAddress.Region);
			}
			if (countryId.IsNullOrEmpty()) {
				bpmAddress += string.Format(", {0}", postalAddress.Country);
			}
			contactAddress.SetColumnValue("Address", bpmAddress.Trim(new char[] { ' ', ',' }));
		}

		/// <summary>
		/// Returns contact communication entity.
		/// </summary>
		/// <param name="number">Communication number.</param>
		/// <param name="contactId">Contact unique identifier.</param>
		/// <param name="typeId">Communication type unique identifier.</param>
		/// <returns>Contact communication entity.</returns>
		private Entity GetContactCommunicationEntity(string number, Guid contactId, Guid typeId) {
			bool isEntityExists;
			Entity contactCommunication = GetEntityByName("ContactCommunication", new Dictionary<string, object> {
				{
					"Number", number
				}, {
					"Contact", contactId
				}, {
					"CommunicationType", typeId
				}
			}, out isEntityExists);
			if (isEntityExists) {
				contactCommunication.SetColumnValue("Number", number);
			} else {
				contactCommunication.SetDefColumnValues();
				contactCommunication.SetColumnValue("ContactId", contactId);
				contactCommunication.SetColumnValue("CommunicationTypeId", typeId);
				contactCommunication.SetColumnValue("Number", number);
			}
			return contactCommunication;
		}

		/// <summary>
		/// Returns contact communication entity schema query with filter by <paramref name="contactId"/>.
		/// </summary>
		/// <param name="contactId">Contact unique identifier.</param>
		/// <returns>Contact communication entity schema query.</returns>
		private EntitySchemaQuery GetContactCommunicationESQ(Guid contactId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactCommunication");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddAllSchemaColumns();
			esq.AddColumn("ModifiedOn").OrderByDesc();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", contactId));
			return esq;
		}

		/// <summary>
		/// Add contact phone types filter to <paramref name="esq"/>.
		/// </summary>
		/// <param name="esq">Contact communication entity schema query.</param>
		private void AddContactPhoneTypesFilter(EntitySchemaQuery esq) {
			var orFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or) {
				esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"CommunicationType", Guid.Parse(CommunicationTypeConsts.HomePhoneId)),
				esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"CommunicationType", Guid.Parse(CommunicationTypeConsts.WorkPhoneId)),
				esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"CommunicationType", Guid.Parse(CommunicationTypeConsts.MobilePhoneId)),
				esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"CommunicationType", Guid.Parse(CommunicationTypeConsts.ExtensionId)),
				esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"CommunicationType", Guid.Parse(CommunicationTypeConsts.OtherPhoneId))
			};
			esq.Filters.Add(orFilterGroup);
		}

		/// <summary>
		/// Fills <paramref name="googleContact"/> communications.
		/// </summary>
		/// <param name="googleContact">Google contact.</param>
		/// <param name="contact">bpmcrm communications.</param>
		private void FillGContactCommunications(GoogleContact googleContact, Entity contact) {
			FillGContactEmails(googleContact, contact.PrimaryColumnValue);
			FillGContactPhoneNumbers(googleContact, contact.PrimaryColumnValue);
		}

		/// <summary>
		/// Fills <paramref name="googleContact"/> emails.
		/// </summary>
		/// <param name="googleContact">Google contact.</param>
		/// <param name="contactId">Contact unique identifier.</param>
		private void FillGContactEmails(GoogleContact googleContact, Guid contactId) {
			var esq = GetContactCommunicationESQ(contactId);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "CommunicationType",
				Guid.Parse(CommunicationTypeConsts.EmailId)));
			var emailsCollection = esq.GetEntityCollection(UserConnection);
			var gContactEmails = new List<EMail>();
			foreach (var entity in emailsCollection) {
				var number = entity.GetTypedColumnValue<string>("Number");
				var externalCommunicationType = entity.GetTypedColumnValue<string>("ExternalCommunicationType");
				var eMail = new EMail(number, externalCommunicationType.IsEmpty()
					? ContactsRelationships.IsOther
					: externalCommunicationType);
				gContactEmails.Add(eMail);
			}
			googleContact.Emails = gContactEmails;
		}

		/// <summary>
		/// Fills <paramref name="googleContact"/> phone numbers.
		/// </summary>
		/// <param name="googleContact">Google contact.</param>
		/// <param name="contactId">Contact unique identifier.</param>
		private void FillGContactPhoneNumbers(GoogleContact googleContact, Guid contactId) {
			var esq = GetContactCommunicationESQ(contactId);
			AddContactPhoneTypesFilter(esq);
			var phonesCollection = esq.GetEntityCollection(UserConnection);
			var gContactPhoneNumbers = new List<PhoneNumber>();
			foreach (var entity in phonesCollection) {
				string number = entity.GetTypedColumnValue<string>("Number");
				Guid typeId = entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
				string externalCommunicationType = entity.GetTypedColumnValue<string>("ExternalCommunicationType");
				string googleLabel = typeId == Guid.Parse(CommunicationTypeConsts.ExtensionId) ? ExtensionPhoneLabel : string.Empty;
				var googleRel = ContactPhoneTypesMapping.FirstOrDefault(kvp => kvp.Value == typeId);
				PhoneNumber phoneNumber = new PhoneNumber(number);
				if (googleLabel.IsNullOrEmpty()) {
					phoneNumber.Rel = externalCommunicationType.IsNullOrEmpty() ? googleRel.Key : externalCommunicationType;
				} else {
					phoneNumber.Label = googleLabel;
				}
				gContactPhoneNumbers.Add(phoneNumber);
				if (externalCommunicationType.IsNullOrEmpty()) {
					entity.SetColumnValue("ExternalCommunicationType", googleRel.Key);
					entity.Save();
				}
			}
			googleContact.PhoneNumbers = gContactPhoneNumbers;
		}

		/// <summary>
		/// Add filter by tag to <paramref name="esqFilterCollection"/>.
		/// </summary>
		/// <param name="esqFilterCollection">Entity schema query filters collection.</param>
		private void AddTagFilters(EntitySchemaQueryFilterCollection esqFilterCollection) {
			esqFilterCollection.Add(esqFilterCollection.ParentQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactInTag:Entity].Tag.Id", ContactGroupId));
		}

		/// <summary>
		/// Returns contact anniversary entity.
		/// </summary>
		/// <param name="date">Anniversary date.</param>
		/// <param name="contactId">Contact unique identifier.</param>
		/// <param name="typeId">Anniversary type.</param>
		/// <returns>Contact anniversary entity.</returns>
		private Entity GetContactAnniversaryEntity(DateTime date, Guid contactId, Guid typeId) {
			var contactAnniversarySchema = UserConnection.EntitySchemaManager.GetInstanceByName("ContactAnniversary");
			var contactAnniversary = contactAnniversarySchema.CreateEntity(UserConnection);
			contactAnniversary.SetDefColumnValues();
			var select = new Select(UserConnection).Top(1).
				Column("Id").
				From("ContactAnniversary").
				Where("ContactId").IsEqual(Column.Parameter(contactId)).
				And("AnniversaryTypeId").IsEqual(Column.Parameter(typeId)) as Select;
			var id = select.ExecuteScalar<Guid>();
			if (id.IsEmpty()) {
				contactAnniversary.SetColumnValue("Id", Guid.NewGuid());
				contactAnniversary.SetColumnValue("ContactId", contactId);
				contactAnniversary.SetColumnValue("AnniversaryTypeId", typeId);
			} else {
				contactAnniversary.FetchFromDB(id);
			}
			contactAnniversary.SetColumnValue("Date", date);
			return contactAnniversary;
		}

		/// <summary>
		/// Returns contacts entity schema query for update.
		/// </summary>
		/// <returns>Contacts entity schema query.</returns>
		private EntitySchemaQuery CreateContactESQForChange() {
			var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var esq = new EntitySchemaQuery(contactSchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("CreatedOn");
			esq.AddColumn("SalutationType");
			esq.AddColumn("Owner");
			esq.AddColumn("Account");
			esq.AddColumn("Name");
			esq.AddColumn("BirthDate");
			esq.AddColumn("Notes");
			esq.AddColumn("Email");
			esq.AddColumn("MobilePhone");
			esq.AddColumn("HomePhone");
			esq.AddColumn("Phone");
			esq.AddColumn("Skype");
			esq.AddColumn("City");
			esq.AddColumn("Country");
			esq.AddColumn("Region");
			esq.AddColumn("Address");
			esq.AddColumn("Zip");
			esq.AddColumn("Department");
			esq.AddColumn("Account.Name");
			esq.AddColumn("JobTitle");
			esq.AddColumn("Surname");
			esq.AddColumn("GivenName");
			esq.AddColumn("MiddleName");
			esq.AddColumn("[ContactCorrespondence:Contact].SourceContactId");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].Source.Id", CommunicationConsts.GoogleTypeUId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].SocialAccountName", SocialAccountName));
			var orFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			var firstFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
				esq.CreateFilterWithParameters(FilterComparisonType.Greater, "ModifiedOn", LastSynchronizationDate),
				esq.CreateFilter(FilterComparisonType.Less, "[ContactCorrespondence:Contact].ModifiedOn",
					esq.CreateSchemaColumnExpression("ModifiedOn"))
			};
			orFilterGroup.Add(firstFilterGroup);
			var secondFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
				esq.CreateFilterWithParameters(FilterComparisonType.Greater, "[ContactInTag:Entity].ModifiedOn",
					LastSynchronizationDate),
				esq.CreateFilter(FilterComparisonType.Less, "[ContactCorrespondence:Contact].ModifiedOn",
					esq.CreateSchemaColumnExpression("[ContactInTag:Entity].ModifiedOn"))
			};
			orFilterGroup.Add(secondFilterGroup);
			var thirdFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
				esq.CreateFilterWithParameters(FilterComparisonType.Greater,
					"[ContactAnniversary:Contact].ModifiedOn", LastSynchronizationDate)
			};
			orFilterGroup.Add(thirdFilterGroup);
			esq.Filters.Add(orFilterGroup);
			AddTagFilters(esq.Filters);
			return esq;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Excludes contact from BPMCRM group in google.
		/// </summary>
		protected virtual void ExcludeFromGroupBPMCRMExcludedContacts() {
			var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var esq = new EntitySchemaQuery(contactSchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			string contactCorrespondenceContactModifiedOn = esq.AddColumn("[ContactCorrespondence:Contact].ModifiedOn").Name;
			string contactCorrespondenceContactSourceContactId =
				esq.AddColumn("[ContactCorrespondence:Contact].SourceContactId").Name;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].Source.Id", CommunicationConsts.GoogleTypeUId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].IsDeleted", false));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].SocialAccountName", SocialAccountName));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Greater, "ModifiedOn",
				LastSynchronizationDate));
			var notFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
				IsNot = true
			};
			notFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactInTag:Entity].Tag.Id", ContactGroupId));
			notFilterGroup.Add(esq.CreateFilter(FilterComparisonType.Equal,
				"[ContactInTag:Entity].Entity.Id", esq.CreateSchemaColumnExpression("Id")));
			esq.Filters.Add(notFilterGroup);
			EntityCollection contacts = esq.GetEntityCollection(UserConnection);
			var deletedContacts =
				contacts.ToDictionary(contact => contact.GetTypedColumnValue<string>(contactCorrespondenceContactSourceContactId),
					contact => contact.GetTypedColumnValue<DateTime>(contactCorrespondenceContactModifiedOn));
			DeletedRecordsInGoogleCount = SyncProvider.ExcludeEntitiesFromGroup(deletedContacts);
		}

		/// <summary>
		/// Processes <paramref name="gContact"/> communications.
		/// </summary>
		/// <param name="contact">bpmcrm contact.</param>
		/// <param name="gContact">Google contact.</param>
		protected virtual void ProcessGoogleContactCommunications(Entity contact, GoogleContact gContact) {
			ProcessGoogleContactEmails(gContact.Emails, contact.PrimaryColumnValue);
			ProcessGoogleContactPhones(gContact.PhoneNumbers, contact.PrimaryColumnValue);
		}

		/// <summary>
		/// Processes <paramref name="phoneNumbers"/>.
		/// </summary>
		/// <param name="phoneNumbers">Google contact phone numbers.</param>
		/// <param name="contactId">Contact unique identifier.</param>
		protected virtual void ProcessGoogleContactPhones(IEnumerable<PhoneNumber> phoneNumbers, Guid contactId) {
			EntitySchemaQuery esq = GetContactCommunicationESQ(contactId);
			AddContactPhoneTypesFilter(esq);
			EntityCollection phonesCollection = esq.GetEntityCollection(UserConnection);
			List<Entity> entities = phonesCollection.Select(entity => entity).ToList();
			IList<PhoneNumber> phoneNumbersList = phoneNumbers as IList<PhoneNumber> ?? phoneNumbers.ToList();
			foreach (var entity in entities) {
				if (phoneNumbersList.Count == 0 || phoneNumbersList.All(
					phoneNumber =>
						entity.GetTypedColumnValue<string>("Number") != phoneNumber.Value ||
						entity.GetTypedColumnValue<string>("ExternalCommunicationType") != phoneNumber.Rel)) {
					entity.Delete();
				}
			}
			if (phoneNumbersList.Count > 0) {
				foreach (var gContactPhone in phoneNumbersList) {
					Guid communicationTypeId;
					if (gContactPhone.Rel.IsNullOrEmpty() && gContactPhone.Label != ExtensionPhoneLabel) {
						communicationTypeId = Guid.Parse(CommunicationTypeConsts.OtherPhoneId);
					} else if (gContactPhone.Label == ExtensionPhoneLabel) {
						communicationTypeId = Guid.Parse(CommunicationTypeConsts.ExtensionId);
					} else {
						ContactPhoneTypesMapping.TryGetValue(gContactPhone.Rel, out communicationTypeId);
					}
					var phoneEntity = GetContactCommunicationEntity(gContactPhone.Value, contactId, communicationTypeId);
					phoneEntity.SetColumnValue("ExternalCommunicationType", gContactPhone.Rel);
					SaveEntity(phoneEntity);
				}
			}
		}

		/// <summary>
		/// Deletes entity.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/> instance.</param>
		protected virtual void DeleteEntity(Entity entity) {
			entity.Delete();
		}

		/// <summary>
		/// Saves entity.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/> instance.</param>
		protected virtual void SaveEntity(Entity entity) {
			entity.Save();
		}

		/// <summary>
		/// Process <paramref name="gContactEmails"/>.
		/// </summary>
		/// <param name="gContactEmails">Google contact emails.</param>
		/// <param name="contactId">Contact unique identifier.</param>
		protected virtual void ProcessGoogleContactEmails(IEnumerable<EMail> gContactEmails, Guid contactId) {
			EntitySchemaQuery esq = GetContactCommunicationESQ(contactId);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "CommunicationType",
				Guid.Parse(CommunicationTypeConsts.EmailId)));
			EntityCollection emailsCollection = esq.GetEntityCollection(UserConnection);
			List<Entity> entities = emailsCollection.Select(entity => entity).ToList();
			IList<EMail> contactEmails = gContactEmails as IList<EMail> ?? gContactEmails.ToList();
			foreach (var entity in entities) {
				if (contactEmails.Count == 0 || !contactEmails.All(email => email.Address != entity.GetTypedColumnValue<string>("Number")
						&& email.Rel != entity.GetTypedColumnValue<string>("ExternalCommunicationType"))) {
					entity.Delete();
				}
			}
			if (contactEmails.Count > 0) {
				foreach (var gContactEmail in contactEmails.OrderBy(email => email.Primary)) {
					var emailTypeId = new Guid(CommunicationTypeConsts.EmailId);
					Entity emailEntity = GetContactCommunicationEntity(gContactEmail.Address, contactId, emailTypeId);
					emailEntity.SetColumnValue("ExternalCommunicationType", gContactEmail.Rel);
					emailEntity.Save();
				}
			}
		}

		/// <summary>
		/// Returns contact field converter.
		/// </summary>
		/// <returns>Contact field converter.</returns>
		protected IContactFieldConverter GetContactConverter() {
			var converterIdValue = Core.Configuration.SysSettings.GetValue<Guid>(UserConnection, "ContactFieldConverter", Guid.Empty);
			if (converterIdValue == null || converterIdValue.ToString().IsNullOrEmpty()) {
				return null;
			}
			var converterId = Guid.Parse(converterIdValue.ToString());
			if (converterId.IsEmpty()) {
				return null;
			}
			var showNamesByESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ShowNamesBy");
			showNamesByESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			string converterColumnName = showNamesByESQ.AddColumn("Converter").Name;
			string separatorColumnName = showNamesByESQ.AddColumn("Separator").Name;
			showNamesByESQ.Filters.Add(
				showNamesByESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", converterId));
			EntityCollection showNamesByEntityCollection = showNamesByESQ.GetEntityCollection(UserConnection);
			if (showNamesByEntityCollection.IsEmpty()) {
				return null;
			}
			string converterName = showNamesByEntityCollection[0].GetTypedColumnValue<string>(converterColumnName);
			if (converterName.IsNullOrEmpty()) {
				return null;
			}
			string separator = showNamesByEntityCollection[0].GetTypedColumnValue<string>(separatorColumnName);
			if (!UserConnection.Workspace.IsWorkspaceAssemblyInitialized) {
				return null;
			}
			var converter = UserConnection.Workspace.WorkspaceAssembly.CreateInstance(converterName) as IContactFieldConverter;
			if (converter == null) {
				return null;
			}
			if (!separator.IsNullOrEmpty()) {
				converter.Separator = separator.ToCharArray();
			}
			return converter;
		}

		/// <summary>
		/// Deletes contact addresses.
		/// </summary>
		/// <param name="structuredPostalAddresses">List google contact addresses.</param>
		/// <param name="entities"> list <see cref="ContactAddress"/> instances.</param>
		protected virtual void DeleteContactAddress(IList<StructuredPostalAddress> structuredPostalAddresses, List<Entity> entities) {
			foreach (var contactAddress in entities) {
				if (structuredPostalAddresses.All(address =>
					(GetAddressTypeId(address) != contactAddress.GetTypedColumnValue<Guid>("AddressTypeId") ||
					(address.Country ?? "") != contactAddress.GetTypedColumnValue<string>("CountryName") ||
					(address.Region ?? "") != contactAddress.GetTypedColumnValue<string>("RegionName") ||
					(address.City ?? "") != contactAddress.GetTypedColumnValue<string>("CityName") ||
					(address.Street ?? "") != contactAddress.GetTypedColumnValue<string>("Address") ||
					(address.Postcode ?? "") != contactAddress.GetTypedColumnValue<string>("Zip")))) {
					contactAddress.Delete();
				}
			}
		}

		/// <summary>
		/// Fills <paramref name="contact"/> name fields from <paramref name="googleContact"/>.
		/// </summary>
		/// <param name="contact">bpmcrm contact.</param>
		/// <param name="googleContact">Google contact.</param>
		protected virtual void FillContactName(Entity contact, GoogleContact googleContact) {
			string contactName = googleContact.Name;
			var gContactProp = googleContact.GetType().GetField("_contact", BindingFlags.NonPublic | BindingFlags.Instance);
			if (gContactProp != null) { 
				object gContact = gContactProp.GetValue(googleContact);
				object gContactName = gContact.GetPropertyValue("Name");
				object familyName = gContactName.GetPropertyValue("FamilyName");
				object givenName = gContactName.GetPropertyValue("GivenName");
				object additionalName = gContactName.GetPropertyValue("AdditionalName");
				var bpmContactNameConverter = GetContactConverter();
				contactName = bpmContactNameConverter.GetContactName(new ContactSgm {
					Surname = (string)familyName,
					GivenName = (string)givenName,
					MiddleName = (string)additionalName
				});
				if (contactName.IsNullOrEmpty()) {
					contactName = googleContact.Name;
				}
			}
			contact.SetColumnValue("Name", contactName.Trim(' '));
		}

		/// <summary>
		/// Fills <paramref name="contact"/> from <paramref name="googleContact"/>.
		/// </summary>
		/// <param name="contact">bpmcrm contact.</param>
		/// <param name="googleContact">Google contact.</param>
		protected virtual void FillContactFromGoogleContact(Entity contact, GoogleContact googleContact) {
			var contactTypeId = contact.GetTypedColumnValue<Guid>("TypeId");
			if (contactTypeId.IsEmpty()) {
				contactTypeId = Core.Configuration.SysSettings.GetValue<Guid>(UserConnection, "GoogleContactType", Guid.Empty);
			}
			FillContactName(contact, googleContact);
			var SalutationTypeId = GetIdByName(googleContact.SalutationType, "ContactSalutationType");
			if (SalutationTypeId.IsNotEmpty()) {
				contact.SetColumnValue("SalutationTypeId", SalutationTypeId);
			}
			contact.SetColumnValue("BirthDate", googleContact.Birthday > DateTime.MinValue ? googleContact.Birthday : null);
			contact.SetColumnValue("Notes", googleContact.Notes);
			contact.SetColumnValue("Skype", googleContact.Skype);
			var departmentId = GetIdByName(googleContact.Department, "Department");
			if (departmentId.IsNotEmpty()) {
				contact.SetColumnValue("DepartmentId", departmentId);
			}
			var jobId = GetIdByName(googleContact.JobTitle, "Job");
			if (jobId.IsNotEmpty()) {
				contact.SetColumnValue("JobId", jobId);
			} else {
				contact.SetColumnValue("JobTitle", googleContact.JobTitle);
			}
			var accountId = GetIdByName(googleContact.Company, "Account");
			if (accountId.IsNotEmpty()) {
				contact.SetColumnValue("AccountId", accountId);
			} else {
				if (!string.IsNullOrEmpty(googleContact.Company)) {
					var accountSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Account");
					var account = accountSchema.CreateEntity(UserConnection);
					account.SetDefColumnValues();
					account.SetColumnValue("Name", googleContact.Company);
					try {
						account.Save();
						contact.SetColumnValue("AccountId", account.PrimaryColumnValue);
					} catch (Exception) {
						throw;
					}
				}
			}
			contact.SetColumnValue("OwnerId", UserConnection.CurrentUser.ContactId);
			contact.SetColumnValue("TypeId", contactTypeId);
		}

		/// <summary>
		/// Fills and save <paramref name="contact"/> details.
		/// </summary>
		/// <param name="contact">bpmcrm contact.</param>
		/// <param name="gContact">Google contact</param>
		protected virtual void FillAndSaveContactDetails(Entity contact, GoogleContact gContact) {
			DateTime date = contact.GetTypedColumnValue<DateTime>("BirthDate");
			if (date != default(DateTime)) {
				var entity = GetContactAnniversaryEntity(date, contact.PrimaryColumnValue, AnniversaryTypeConsts.BirthdayId);
				entity.Save();
			} else {
				bool isEntityExists;
				Entity contactAnniversary = GetEntityByName("ContactAnniversary", new Dictionary<string, object> {
					{"Contact", contact.PrimaryColumnValue},
					{"AnniversaryType", AnniversaryTypeConsts.BirthdayId}
				}, out isEntityExists);
				if (isEntityExists) {
					DeleteEntity(contactAnniversary);
				}
			}
			ProcessGoogleContactCommunications(contact, gContact);
			ProcessGoogleContactAddresses(contact, gContact);
		}

		/// <summary>
		/// Fills <paramref name="googleContact"/> name, parsed from <paramref name="bpmContactName"/>.
		/// </summary>
		/// <param name="googleContact">Google contact.</param>
		/// <param name="contact">Bpm online contact instance.</param>
		protected virtual void GetContactName(GoogleContact googleContact, Entity contact) {
			string bpmContactName = contact.GetTypedColumnValue<string>("Name");
			var bpmContactNameConverter = GetContactConverter();
			ContactSgm contactSgm = bpmContactNameConverter.GetContactSgm(bpmContactName);
			var gContactProp = googleContact.GetType().GetField("_contact", BindingFlags.NonPublic | BindingFlags.Instance);
			if (gContactProp != null) {
				object gContact = gContactProp.GetValue(googleContact);
				object gContactName = gContact.GetPropertyValue("Name");
				gContactName.SetPropertyValue("FamilyName", contactSgm.Surname);
				gContactName.SetPropertyValue("GivenName", contactSgm.GivenName);
				gContactName.SetPropertyValue("AdditionalName", contactSgm.MiddleName);
				gContactName.SetPropertyValue("FullName", bpmContactNameConverter.GetContactName(contactSgm));
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Prepare google synchronization.
		/// </summary>
		public override void PrepareGoogleSynchronization() {
			ContactGroupId = (Guid)(Core.Configuration.SysSettings.GetValue(UserConnection,
				"GoogleContactGroup") ?? Guid.Empty);
			GetLastSyncDate("GoogleContactLastSynchronization", "GoogleContactLastSynchronizationEnd");
			try {
				SyncProvider.Authenticate(AccessToken);
			} catch (Exception e) {
				throw new GoogleSynchronizationException(e.Message, e);
			}
			CurrentSynchronizationDate = UserConnection.CurrentUser.GetCurrentDateTime();
		}

		/// <summary>
		/// Processes google changed entities.
		/// </summary>
		public override void ProcessGoogleChangedEntities() {
			if (!CanImportContactsFromGoogle) {
				return;
			}
			IEnumerable<SyncEntity<GoogleContact>> modifiedContacts = new List<SyncEntity<GoogleContact>>();
			try {
				modifiedContacts = SyncProvider.GetModifiedEntities(GetUtcDateTime(LastSynchronizationEndDate));
			} catch (Exception ex) {
				LogMessage(ex.ToString(), UserConnection, "GoogleContact");
				throw new GoogleSynchronizationDataAccessException("Contact data not recived", ex);
			}
			var deletedEntities = modifiedContacts.Where(synchEntity => (int)synchEntity.State == 0);
			var newEditedContacts = modifiedContacts.Where(synchEntity => (int)synchEntity.State != 0);
			Action<IEnumerable<SyncEntity<GoogleContact>>, Action<List<SyncEntity<GoogleContact>>>> paging = (list, action) => {
				var portion = new List<SyncEntity<GoogleContact>>();
				int i = 1;
				foreach (var item in list) {
					portion.Add(item);
					if (i % RecordsPerPortion == 0) {
						action(portion);
						portion.Clear();
					}
					i++;
				}
				if (portion.Count > 0) {
					action(portion);
					portion.Clear();
				}
			};
			paging(deletedEntities, ProcessGoogleDeletedContacts);
			ExcludeFromGroupBPMCRMExcludedContacts();
			paging(newEditedContacts, ProcessGoogleNewEditedContacts);
		}

		/// <summary>
		/// Processes bpmcrm added entities.
		/// </summary>
		public override void ProcessBPMCRMAddedEntities() {
			if (!CanExportContactsToGoogle) {
				return;
			}
			var esq = CreateContactESQForInsert();
			var notFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
				IsNot = true
			};
			notFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].Source.Id", CommunicationConsts.GoogleTypeUId));
			notFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ContactCorrespondence:Contact].SocialAccountName", SocialAccountName));
			esq.Filters.Add(notFilterGroup);
			AddTagFilters(esq.Filters);
			EntityCollection contacts = esq.GetEntityCollection(UserConnection);
			if (contacts.Count < 1) {
				return;
			}
			var gContacts = contacts.Select(contact => ContactToGContact((Contact)contact)).ToList();
			SyncProvider.CreateEntities(gContacts);
			var createdOn = DateTime.UtcNow;
			var modifiedOn = GetUtcDateTime(CurrentSynchronizationDate);
			var contactCorrespondenceInstance = UserConnection.EntitySchemaManager.GetInstanceByName("ContactCorrespondence");
			foreach (GoogleContact gContact in gContacts) {
				if (string.IsNullOrEmpty(gContact.Id)) {
					continue;
				}
				var contactCorrespondenceEntity = contactCorrespondenceInstance.CreateEntity(UserConnection);
				contactCorrespondenceEntity.SetDefColumnValues();
				contactCorrespondenceEntity.SetColumnValue("CreatedOn", createdOn);
				contactCorrespondenceEntity.SetColumnValue("ModifiedOn", createdOn);
				contactCorrespondenceEntity.SetColumnValue("ContactId", gContact.ContactId);
				contactCorrespondenceEntity.SetColumnValue("SourceAccountId", SourceAccountId);
				contactCorrespondenceEntity.SetColumnValue("SocialAccountName", SocialAccountName);
				contactCorrespondenceEntity.SetColumnValue("SourceId", CommunicationConsts.GoogleTypeUId);
				contactCorrespondenceEntity.SetColumnValue("SourceContactId", gContact.Id);
				contactCorrespondenceEntity.Save();
				var updateModifiedDate = new Update(UserConnection, "Contact").
					Set("ModifiedOn", Column.Parameter(modifiedOn)).
					Where("Id").IsEqual(Column.Parameter(gContact.ContactId)) as Update;
				updateModifiedDate.Execute();
				AddedRecordsInGoogleCount++;
			}
		}

		/// <summary>
		/// Processes bpmcrm changed entities.
		/// </summary>
		public override void ProcessBPMCRMChangedEntities() {
			if (!CanExportContactsToGoogle) {
				return;
			}
			var esq = CreateContactESQForChange();
			var contacts = esq.GetEntityCollection(UserConnection);
			if (contacts.Count < 1) {
				return;
			}
			var gContacts = new List<GoogleContact>();
			var modifiedOn = GetUtcDateTime(CurrentSynchronizationDate);
			foreach (var contact in contacts) {
				Guid contactId = contact.PrimaryColumnValue;
				var googleContact = new GoogleContact {
					ContactId = contactId,
					SalutationType = contact.GetTypedColumnValue<string>("SalutationTypeName"),
					Birthday = contact.GetTypedColumnValue<DateTime>("BirthDate"),
					Notes = StringUtilities.ConvertHtmlToPlainText(contact.GetTypedColumnValue<string>("Notes")),
					Skype = contact.GetTypedColumnValue<string>("Skype"),
					PostalAddresses = GetContactAddresses(contactId),
					Department = contact.GetTypedColumnValue<string>("DepartmentName"),
					Company = contact.GetTypedColumnValue<string>("AccountName"),
					JobTitle = contact.GetTypedColumnValue<string>("JobTitle"),
					Id = contact.GetTypedColumnValue<string>("ContactCorrespondence_Contact_SourceContactId")
				};
				FillGContactCommunications(googleContact, contact);
				GetContactName(googleContact, contact);
				gContacts.Add(googleContact);
				new Update(UserConnection, "Contact").
					Set("ModifiedOn", Column.Parameter(modifiedOn)).
					Where("Id").IsEqual(Column.Parameter(contactId)).Execute();
				new Update(UserConnection, "ContactCorrespondence").
					Set("ModifiedOn", Column.Parameter(modifiedOn)).
					Where("ContactId").IsEqual(Column.Parameter(contactId)).Execute();
				UpdatedRecordsInGoogleCount++;
			}
			SyncProvider.UpdateEntities(gContacts);
		}

		/// <summary>
		/// Processes bpmcrm deleted entities.
		/// </summary>
		public override void ProcessBPMCRMDeletedEntities() {
			if (!CanExportContactsToGoogle) {
				return;
			}
			var del = new Delete(UserConnection).From("ContactCorrespondence").
				Where("IsDeleted").IsEqual(Column.Parameter(true)).
				And("ContactId").IsNull() as Delete;
			del.Execute();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactCorrespondence");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Contact");
			esq.AddColumn("SourceContactId");
			esq.AddColumn("ProcessListeners");
			esq.AddColumn("ModifiedOn");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.IsNull, "Contact"));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SocialAccountName", SocialAccountName));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "IsDeleted", true));
			var deletedContactsUri = new List<string>();
			var deletedContacts = new Dictionary<string, DateTime>();
			EntityCollection entitiesForDelete = esq.GetEntityCollection(UserConnection);
			foreach (var entity in entitiesForDelete) {
				var deletedContact = (ContactCorrespondence)entity;
				deletedContactsUri.Add(deletedContact.SourceContactId);
				deletedContacts.Add(deletedContact.SourceContactId,
					UserConnection.CurrentUser.GetCurrentDateTime());
			}
			SyncProvider.ExcludeEntitiesFromGroup(deletedContacts);
			var k = 0;
			for (var i = 0; i < deletedContactsUri.Count; i++) {
				var item = entitiesForDelete[k];
				if (!item.Delete()) {
					k++;
				}
				DeletedRecordsInGoogleCount++;
			}
		}

		/// <summary>
		/// Finalizes google synchronization.
		/// </summary>
		public override void FinalizeSynchronization() {
			SetLastSyncDate("GoogleContactLastSynchronization", "GoogleContactLastSynchronizationEnd");
		}

		#endregion

	}

	#endregion

}
