namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Account

	/// <exclude/>
	public class Account : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Account(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Account";
		}

		public Account(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Account";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Account> AccountCollectionByParent {
			get;
			set;
		}

		public IEnumerable<AccountAddress> AccountAddressCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountAlternativeName> AccountAlternativeNameCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountAnniversary> AccountAnniversaryCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountBillingInfo> AccountBillingInfoCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountCommunication> AccountCommunicationCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountDuplicate> AccountDuplicateCollectionByEntity1 {
			get;
			set;
		}

		public IEnumerable<AccountDuplicate> AccountDuplicateCollectionByEntity2 {
			get;
			set;
		}

		public IEnumerable<AccountEnrichedData> AccountEnrichedDataCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountFile> AccountFileCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountForecast> AccountForecastCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountInFolder> AccountInFolderCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountInTag> AccountInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<AccountOrganizationChart> AccountOrganizationChartCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Activity> ActivityCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Call> CallCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Case> CaseCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<CompetitorProduct> CompetitorProductCollectionByCompetitor {
			get;
			set;
		}

		public IEnumerable<ConfItemUser> ConfItemUserCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Contact> ContactCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<ContactCareer> ContactCareerCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Contract> ContractCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Contract> ContractCollectionByOurCompany {
			get;
			set;
		}

		public IEnumerable<CTISearchResult> CTISearchResultCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Document> DocumentCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<EmailFolderColumnValuesSetting> EmailFolderColumnValuesSettingCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Employee> EmployeeCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<EmployeeCareer> EmployeeCareerCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<EnrchFoundAccount> EnrchFoundAccountCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<EventTeam> EventTeamCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Invoice> InvoiceCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Invoice> InvoiceCollectionBySupplier {
			get;
			set;
		}

		public IEnumerable<Lead> LeadCollectionByPartner {
			get;
			set;
		}

		public IEnumerable<Lead> LeadCollectionByQualifiedAccount {
			get;
			set;
		}

		public IEnumerable<LeadQualification> LeadQualificationCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<MktgActivity> MktgActivityCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Opportunity> OpportunityCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Opportunity> OpportunityCollectionByPartner {
			get;
			set;
		}

		public IEnumerable<Opportunity> OpportunityCollectionByWinner {
			get;
			set;
		}

		public IEnumerable<OpportunityCompetitor> OpportunityCompetitorCollectionByCompetitor {
			get;
			set;
		}

		public IEnumerable<OpportunityCompetitor> OpportunityCompetitorCollectionBySupplier {
			get;
			set;
		}

		public IEnumerable<OpportunityParticipant> OpportunityParticipantCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Order> OrderCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Partnership> PartnershipCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Project> ProjectCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Project> ProjectCollectionBySupplier {
			get;
			set;
		}

		public IEnumerable<QuickDialUserSettings> QuickDialUserSettingsCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<RecommendedProduct> RecommendedProductCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Relationship> RelationshipCollectionByAccountA {
			get;
			set;
		}

		public IEnumerable<Relationship> RelationshipCollectionByAccountB {
			get;
			set;
		}

		public IEnumerable<ServiceObject> ServiceObjectCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<ServicePact> ServicePactCollectionByServiceProvider {
			get;
			set;
		}

		public IEnumerable<SysAdminUnit> SysAdminUnitCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<SysAdminUnit> SysAdminUnitCollectionByPortalAccount {
			get;
			set;
		}

		public IEnumerable<Touch> TouchCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<UsrCarPark> UsrCarParkCollectionByUsrCompany {
			get;
			set;
		}

		public IEnumerable<UsrTransportRequests> UsrTransportRequestsCollectionByUsrCompany {
			get;
			set;
		}

		public IEnumerable<VwAccountDuplicate> VwAccountDuplicateCollectionByEntity1 {
			get;
			set;
		}

		public IEnumerable<VwAccountDuplicate> VwAccountDuplicateCollectionByEntity2 {
			get;
			set;
		}

		public IEnumerable<VwAccountModuleHistory> VwAccountModuleHistoryCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwAccountRelationship> VwAccountRelationshipCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwAccountRelationship> VwAccountRelationshipCollectionByRelatedAccount {
			get;
			set;
		}

		public IEnumerable<VwAnniversary> VwAnniversaryCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwContactRelationship> VwContactRelationshipCollectionByRelatedAccount {
			get;
			set;
		}

		public IEnumerable<VwGroupSysAdminUnit> VwGroupSysAdminUnitCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwModuleHistory> VwModuleHistoryCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwPortalOpportunity> VwPortalOpportunityCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwPortalOpportunity> VwPortalOpportunityCollectionByPartner {
			get;
			set;
		}

		public IEnumerable<VwProjectHierarchy> VwProjectHierarchyCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwQueueItem> VwQueueItemCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwRelationship> VwRelationshipCollectionByAccountA {
			get;
			set;
		}

		public IEnumerable<VwRelationship> VwRelationshipCollectionByAccountB {
			get;
			set;
		}

		public IEnumerable<VwServiceRecepients> VwServiceRecepientsCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwSspAdminUnit> VwSspAdminUnitCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwSspAdminUnit> VwSspAdminUnitCollectionByPortalAccount {
			get;
			set;
		}

		public IEnumerable<VwSSPSysAdminUnit> VwSSPSysAdminUnitCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwSysAdminUnit> VwSysAdminUnitCollectionByAccount {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
			}
		}

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Активные процессы.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <exclude/>
		public Guid OwnershipId {
			get {
				return GetTypedColumnValue<Guid>("OwnershipId");
			}
			set {
				SetColumnValue("OwnershipId", value);
				_ownership = null;
			}
		}

		/// <exclude/>
		public string OwnershipName {
			get {
				return GetTypedColumnValue<string>("OwnershipName");
			}
			set {
				SetColumnValue("OwnershipName", value);
				if (_ownership != null) {
					_ownership.Name = value;
				}
			}
		}

		private AccountOwnership _ownership;
		/// <summary>
		/// Форма собственности.
		/// </summary>
		public AccountOwnership Ownership {
			get {
				return _ownership ??
					(_ownership = new AccountOwnership(LookupColumnEntities.GetEntity("Ownership")));
			}
		}

		/// <exclude/>
		public Guid PrimaryContactId {
			get {
				return GetTypedColumnValue<Guid>("PrimaryContactId");
			}
			set {
				SetColumnValue("PrimaryContactId", value);
				_primaryContact = null;
			}
		}

		/// <exclude/>
		public string PrimaryContactName {
			get {
				return GetTypedColumnValue<string>("PrimaryContactName");
			}
			set {
				SetColumnValue("PrimaryContactName", value);
				if (_primaryContact != null) {
					_primaryContact.Name = value;
				}
			}
		}

		private Contact _primaryContact;
		/// <summary>
		/// Основной контакт.
		/// </summary>
		public Contact PrimaryContact {
			get {
				return _primaryContact ??
					(_primaryContact = new Contact(LookupColumnEntities.GetEntity("PrimaryContact")));
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private Account _parent;
		/// <summary>
		/// Родительский контрагент.
		/// </summary>
		public Account Parent {
			get {
				return _parent ??
					(_parent = new Account(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		/// <exclude/>
		public Guid IndustryId {
			get {
				return GetTypedColumnValue<Guid>("IndustryId");
			}
			set {
				SetColumnValue("IndustryId", value);
				_industry = null;
			}
		}

		/// <exclude/>
		public string IndustryName {
			get {
				return GetTypedColumnValue<string>("IndustryName");
			}
			set {
				SetColumnValue("IndustryName", value);
				if (_industry != null) {
					_industry.Name = value;
				}
			}
		}

		private AccountIndustry _industry;
		/// <summary>
		/// Отрасль.
		/// </summary>
		public AccountIndustry Industry {
			get {
				return _industry ??
					(_industry = new AccountIndustry(LookupColumnEntities.GetEntity("Industry")));
			}
		}

		/// <summary>
		/// Код.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private AccountType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public AccountType Type {
			get {
				return _type ??
					(_type = new AccountType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <summary>
		/// Основной телефон.
		/// </summary>
		public string Phone {
			get {
				return GetTypedColumnValue<string>("Phone");
			}
			set {
				SetColumnValue("Phone", value);
			}
		}

		/// <summary>
		/// Дополнительный телефон.
		/// </summary>
		public string AdditionalPhone {
			get {
				return GetTypedColumnValue<string>("AdditionalPhone");
			}
			set {
				SetColumnValue("AdditionalPhone", value);
			}
		}

		/// <summary>
		/// Факс.
		/// </summary>
		public string Fax {
			get {
				return GetTypedColumnValue<string>("Fax");
			}
			set {
				SetColumnValue("Fax", value);
			}
		}

		/// <summary>
		/// Web.
		/// </summary>
		public string Web {
			get {
				return GetTypedColumnValue<string>("Web");
			}
			set {
				SetColumnValue("Web", value);
			}
		}

		/// <exclude/>
		public Guid AddressTypeId {
			get {
				return GetTypedColumnValue<Guid>("AddressTypeId");
			}
			set {
				SetColumnValue("AddressTypeId", value);
				_addressType = null;
			}
		}

		/// <exclude/>
		public string AddressTypeName {
			get {
				return GetTypedColumnValue<string>("AddressTypeName");
			}
			set {
				SetColumnValue("AddressTypeName", value);
				if (_addressType != null) {
					_addressType.Name = value;
				}
			}
		}

		private AddressType _addressType;
		/// <summary>
		/// Тип адреса.
		/// </summary>
		public AddressType AddressType {
			get {
				return _addressType ??
					(_addressType = new AddressType(LookupColumnEntities.GetEntity("AddressType")));
			}
		}

		/// <summary>
		/// Адрес.
		/// </summary>
		public string Address {
			get {
				return GetTypedColumnValue<string>("Address");
			}
			set {
				SetColumnValue("Address", value);
			}
		}

		/// <exclude/>
		public Guid CityId {
			get {
				return GetTypedColumnValue<Guid>("CityId");
			}
			set {
				SetColumnValue("CityId", value);
				_city = null;
			}
		}

		/// <exclude/>
		public string CityName {
			get {
				return GetTypedColumnValue<string>("CityName");
			}
			set {
				SetColumnValue("CityName", value);
				if (_city != null) {
					_city.Name = value;
				}
			}
		}

		private City _city;
		/// <summary>
		/// Город.
		/// </summary>
		public City City {
			get {
				return _city ??
					(_city = new City(LookupColumnEntities.GetEntity("City")));
			}
		}

		/// <exclude/>
		public Guid RegionId {
			get {
				return GetTypedColumnValue<Guid>("RegionId");
			}
			set {
				SetColumnValue("RegionId", value);
				_region = null;
			}
		}

		/// <exclude/>
		public string RegionName {
			get {
				return GetTypedColumnValue<string>("RegionName");
			}
			set {
				SetColumnValue("RegionName", value);
				if (_region != null) {
					_region.Name = value;
				}
			}
		}

		private Region _region;
		/// <summary>
		/// Область.
		/// </summary>
		public Region Region {
			get {
				return _region ??
					(_region = new Region(LookupColumnEntities.GetEntity("Region")));
			}
		}

		/// <summary>
		/// Индекс.
		/// </summary>
		public string Zip {
			get {
				return GetTypedColumnValue<string>("Zip");
			}
			set {
				SetColumnValue("Zip", value);
			}
		}

		/// <exclude/>
		public Guid CountryId {
			get {
				return GetTypedColumnValue<Guid>("CountryId");
			}
			set {
				SetColumnValue("CountryId", value);
				_country = null;
			}
		}

		/// <exclude/>
		public string CountryName {
			get {
				return GetTypedColumnValue<string>("CountryName");
			}
			set {
				SetColumnValue("CountryName", value);
				if (_country != null) {
					_country.Name = value;
				}
			}
		}

		private Country _country;
		/// <summary>
		/// Страна.
		/// </summary>
		public Country Country {
			get {
				return _country ??
					(_country = new Country(LookupColumnEntities.GetEntity("Country")));
			}
		}

		/// <exclude/>
		public Guid AccountCategoryId {
			get {
				return GetTypedColumnValue<Guid>("AccountCategoryId");
			}
			set {
				SetColumnValue("AccountCategoryId", value);
				_accountCategory = null;
			}
		}

		/// <exclude/>
		public string AccountCategoryName {
			get {
				return GetTypedColumnValue<string>("AccountCategoryName");
			}
			set {
				SetColumnValue("AccountCategoryName", value);
				if (_accountCategory != null) {
					_accountCategory.Name = value;
				}
			}
		}

		private AccountCategory _accountCategory;
		/// <summary>
		/// Категория.
		/// </summary>
		public AccountCategory AccountCategory {
			get {
				return _accountCategory ??
					(_accountCategory = new AccountCategory(LookupColumnEntities.GetEntity("AccountCategory")));
			}
		}

		/// <exclude/>
		public Guid EmployeesNumberId {
			get {
				return GetTypedColumnValue<Guid>("EmployeesNumberId");
			}
			set {
				SetColumnValue("EmployeesNumberId", value);
				_employeesNumber = null;
			}
		}

		/// <exclude/>
		public string EmployeesNumberName {
			get {
				return GetTypedColumnValue<string>("EmployeesNumberName");
			}
			set {
				SetColumnValue("EmployeesNumberName", value);
				if (_employeesNumber != null) {
					_employeesNumber.Name = value;
				}
			}
		}

		private AccountEmployeesNumber _employeesNumber;
		/// <summary>
		/// Количество сотрудников.
		/// </summary>
		public AccountEmployeesNumber EmployeesNumber {
			get {
				return _employeesNumber ??
					(_employeesNumber = new AccountEmployeesNumber(LookupColumnEntities.GetEntity("EmployeesNumber")));
			}
		}

		/// <exclude/>
		public Guid AnnualRevenueId {
			get {
				return GetTypedColumnValue<Guid>("AnnualRevenueId");
			}
			set {
				SetColumnValue("AnnualRevenueId", value);
				_annualRevenue = null;
			}
		}

		/// <exclude/>
		public string AnnualRevenueName {
			get {
				return GetTypedColumnValue<string>("AnnualRevenueName");
			}
			set {
				SetColumnValue("AnnualRevenueName", value);
				if (_annualRevenue != null) {
					_annualRevenue.Name = value;
				}
			}
		}

		private AccountAnnualRevenue _annualRevenue;
		/// <summary>
		/// Годовой оборот.
		/// </summary>
		public AccountAnnualRevenue AnnualRevenue {
			get {
				return _annualRevenue ??
					(_annualRevenue = new AccountAnnualRevenue(LookupColumnEntities.GetEntity("AnnualRevenue")));
			}
		}

		/// <summary>
		/// Заметки.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// Альтернативные названия.
		/// </summary>
		public string AlternativeName {
			get {
				return GetTypedColumnValue<string>("AlternativeName");
			}
			set {
				SetColumnValue("AlternativeName", value);
			}
		}

		/// <summary>
		/// GPS N.
		/// </summary>
		public string GPSN {
			get {
				return GetTypedColumnValue<string>("GPSN");
			}
			set {
				SetColumnValue("GPSN", value);
			}
		}

		/// <summary>
		/// GPS E.
		/// </summary>
		public string GPSE {
			get {
				return GetTypedColumnValue<string>("GPSE");
			}
			set {
				SetColumnValue("GPSE", value);
			}
		}

		/// <exclude/>
		public Guid PriceListId {
			get {
				return GetTypedColumnValue<Guid>("PriceListId");
			}
			set {
				SetColumnValue("PriceListId", value);
				_priceList = null;
			}
		}

		/// <exclude/>
		public string PriceListName {
			get {
				return GetTypedColumnValue<string>("PriceListName");
			}
			set {
				SetColumnValue("PriceListName", value);
				if (_priceList != null) {
					_priceList.Name = value;
				}
			}
		}

		private Pricelist _priceList;
		/// <summary>
		/// Прайс-лист.
		/// </summary>
		public Pricelist PriceList {
			get {
				return _priceList ??
					(_priceList = new Pricelist(LookupColumnEntities.GetEntity("PriceList")));
			}
		}

		/// <exclude/>
		public Guid AccountLogoId {
			get {
				return GetTypedColumnValue<Guid>("AccountLogoId");
			}
			set {
				SetColumnValue("AccountLogoId", value);
				_accountLogo = null;
			}
		}

		/// <exclude/>
		public string AccountLogoName {
			get {
				return GetTypedColumnValue<string>("AccountLogoName");
			}
			set {
				SetColumnValue("AccountLogoName", value);
				if (_accountLogo != null) {
					_accountLogo.Name = value;
				}
			}
		}

		private SysImage _accountLogo;
		/// <summary>
		/// Логотип контрагента.
		/// </summary>
		public SysImage AccountLogo {
			get {
				return _accountLogo ??
					(_accountLogo = new SysImage(LookupColumnEntities.GetEntity("AccountLogo")));
			}
		}

		/// <summary>
		/// AUM.
		/// </summary>
		public string AUM {
			get {
				return GetTypedColumnValue<string>("AUM");
			}
			set {
				SetColumnValue("AUM", value);
			}
		}

		/// <summary>
		/// Полнота наполнения данными.
		/// </summary>
		public int Completeness {
			get {
				return GetTypedColumnValue<int>("Completeness");
			}
			set {
				SetColumnValue("Completeness", value);
			}
		}

		/// <summary>
		/// Номер карты.
		/// </summary>
		public string RtxCardNumber {
			get {
				return GetTypedColumnValue<string>("RtxCardNumber");
			}
			set {
				SetColumnValue("RtxCardNumber", value);
			}
		}

		/// <exclude/>
		public Guid RtxBankId {
			get {
				return GetTypedColumnValue<Guid>("RtxBankId");
			}
			set {
				SetColumnValue("RtxBankId", value);
				_rtxBank = null;
			}
		}

		/// <exclude/>
		public string RtxBankName {
			get {
				return GetTypedColumnValue<string>("RtxBankName");
			}
			set {
				SetColumnValue("RtxBankName", value);
				if (_rtxBank != null) {
					_rtxBank.Name = value;
				}
			}
		}

		private RtxBank _rtxBank;
		/// <summary>
		/// Банк.
		/// </summary>
		public RtxBank RtxBank {
			get {
				return _rtxBank ??
					(_rtxBank = new RtxBank(LookupColumnEntities.GetEntity("RtxBank")));
			}
		}

		/// <summary>
		/// Строка реквизитов.
		/// </summary>
		public string RtxClientDetails {
			get {
				return GetTypedColumnValue<string>("RtxClientDetails");
			}
			set {
				SetColumnValue("RtxClientDetails", value);
			}
		}

		#endregion

	}

	#endregion

}

