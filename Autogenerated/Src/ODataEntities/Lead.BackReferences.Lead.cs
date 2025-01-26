namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Lead

	/// <exclude/>
	public class Lead : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Lead(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Lead";
		}

		public Lead(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Lead";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByLead {
			get;
			set;
		}

		public IEnumerable<Call> CallCollectionByLead {
			get;
			set;
		}

		public IEnumerable<FileLead> FileLeadCollectionByLead {
			get;
			set;
		}

		public IEnumerable<LeadAddress> LeadAddressCollectionByLead {
			get;
			set;
		}

		public IEnumerable<LeadInFolder> LeadInFolderCollectionByLead {
			get;
			set;
		}

		public IEnumerable<LeadInQualifyStatus> LeadInQualifyStatusCollectionByLead {
			get;
			set;
		}

		public IEnumerable<LeadInTag> LeadInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<LeadMessageHistory> LeadMessageHistoryCollectionByLead {
			get;
			set;
		}

		public IEnumerable<LeadProduct> LeadProductCollectionByLead {
			get;
			set;
		}

		public IEnumerable<OmniChat> OmniChatCollectionByLead {
			get;
			set;
		}

		public IEnumerable<SpecificationInLead> SpecificationInLeadCollectionByLead {
			get;
			set;
		}

		public IEnumerable<VwSiteEvent> VwSiteEventCollectionByLead {
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
		/// Название контрагента.
		/// </summary>
		public string Account {
			get {
				return GetTypedColumnValue<string>("Account");
			}
			set {
				SetColumnValue("Account", value);
			}
		}

		/// <summary>
		/// ФИО контакта.
		/// </summary>
		public string Contact {
			get {
				return GetTypedColumnValue<string>("Contact");
			}
			set {
				SetColumnValue("Contact", value);
			}
		}

		/// <exclude/>
		public Guid TitleId {
			get {
				return GetTypedColumnValue<Guid>("TitleId");
			}
			set {
				SetColumnValue("TitleId", value);
				_title = null;
			}
		}

		/// <exclude/>
		public string TitleName {
			get {
				return GetTypedColumnValue<string>("TitleName");
			}
			set {
				SetColumnValue("TitleName", value);
				if (_title != null) {
					_title.Name = value;
				}
			}
		}

		private ContactSalutationType _title;
		/// <summary>
		/// Обращение.
		/// </summary>
		public ContactSalutationType Title {
			get {
				return _title ??
					(_title = new ContactSalutationType(LookupColumnEntities.GetEntity("Title")));
			}
		}

		/// <summary>
		/// Полное название должности.
		/// </summary>
		public string FullJobTitle {
			get {
				return GetTypedColumnValue<string>("FullJobTitle");
			}
			set {
				SetColumnValue("FullJobTitle", value);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private LeadStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public LeadStatus Status {
			get {
				return _status ??
					(_status = new LeadStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		/// <exclude/>
		public Guid InformationSourceId {
			get {
				return GetTypedColumnValue<Guid>("InformationSourceId");
			}
			set {
				SetColumnValue("InformationSourceId", value);
				_informationSource = null;
			}
		}

		/// <exclude/>
		public string InformationSourceName {
			get {
				return GetTypedColumnValue<string>("InformationSourceName");
			}
			set {
				SetColumnValue("InformationSourceName", value);
				if (_informationSource != null) {
					_informationSource.Name = value;
				}
			}
		}

		private InformationSource _informationSource;
		/// <summary>
		/// Источник информации.
		/// </summary>
		public InformationSource InformationSource {
			get {
				return _informationSource ??
					(_informationSource = new InformationSource(LookupColumnEntities.GetEntity("InformationSource")));
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

		/// <summary>
		/// Рабочий телефон.
		/// </summary>
		public string BusinesPhone {
			get {
				return GetTypedColumnValue<string>("BusinesPhone");
			}
			set {
				SetColumnValue("BusinesPhone", value);
			}
		}

		/// <summary>
		/// Мобильный телефон.
		/// </summary>
		public string MobilePhone {
			get {
				return GetTypedColumnValue<string>("MobilePhone");
			}
			set {
				SetColumnValue("MobilePhone", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string Email {
			get {
				return GetTypedColumnValue<string>("Email");
			}
			set {
				SetColumnValue("Email", value);
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
		public string Website {
			get {
				return GetTypedColumnValue<string>("Website");
			}
			set {
				SetColumnValue("Website", value);
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
		/// Область/штат.
		/// </summary>
		public Region Region {
			get {
				return _region ??
					(_region = new Region(LookupColumnEntities.GetEntity("Region")));
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

		/// <summary>
		/// Не использовать email.
		/// </summary>
		public bool DoNotUseEmail {
			get {
				return GetTypedColumnValue<bool>("DoNotUseEmail");
			}
			set {
				SetColumnValue("DoNotUseEmail", value);
			}
		}

		/// <summary>
		/// Не использовать телефон.
		/// </summary>
		public bool DoNotUsePhone {
			get {
				return GetTypedColumnValue<bool>("DoNotUsePhone");
			}
			set {
				SetColumnValue("DoNotUsePhone", value);
			}
		}

		/// <summary>
		/// Не использовать факс.
		/// </summary>
		public bool DoNotUseFax {
			get {
				return GetTypedColumnValue<bool>("DoNotUseFax");
			}
			set {
				SetColumnValue("DoNotUseFax", value);
			}
		}

		/// <summary>
		/// Не использовать SMS.
		/// </summary>
		public bool DoNotUseSMS {
			get {
				return GetTypedColumnValue<bool>("DoNotUseSMS");
			}
			set {
				SetColumnValue("DoNotUseSMS", value);
			}
		}

		/// <summary>
		/// Не использовать почту.
		/// </summary>
		public bool DoNotUseMail {
			get {
				return GetTypedColumnValue<bool>("DoNotUseMail");
			}
			set {
				SetColumnValue("DoNotUseMail", value);
			}
		}

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Commentary {
			get {
				return GetTypedColumnValue<string>("Commentary");
			}
			set {
				SetColumnValue("Commentary", value);
			}
		}

		/// <exclude/>
		public Guid QualifiedContactId {
			get {
				return GetTypedColumnValue<Guid>("QualifiedContactId");
			}
			set {
				SetColumnValue("QualifiedContactId", value);
				_qualifiedContact = null;
			}
		}

		/// <exclude/>
		public string QualifiedContactName {
			get {
				return GetTypedColumnValue<string>("QualifiedContactName");
			}
			set {
				SetColumnValue("QualifiedContactName", value);
				if (_qualifiedContact != null) {
					_qualifiedContact.Name = value;
				}
			}
		}

		private Contact _qualifiedContact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact QualifiedContact {
			get {
				return _qualifiedContact ??
					(_qualifiedContact = new Contact(LookupColumnEntities.GetEntity("QualifiedContact")));
			}
		}

		/// <exclude/>
		public Guid QualifiedAccountId {
			get {
				return GetTypedColumnValue<Guid>("QualifiedAccountId");
			}
			set {
				SetColumnValue("QualifiedAccountId", value);
				_qualifiedAccount = null;
			}
		}

		/// <exclude/>
		public string QualifiedAccountName {
			get {
				return GetTypedColumnValue<string>("QualifiedAccountName");
			}
			set {
				SetColumnValue("QualifiedAccountName", value);
				if (_qualifiedAccount != null) {
					_qualifiedAccount.Name = value;
				}
			}
		}

		private Account _qualifiedAccount;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account QualifiedAccount {
			get {
				return _qualifiedAccount ??
					(_qualifiedAccount = new Account(LookupColumnEntities.GetEntity("QualifiedAccount")));
			}
		}

		/// <summary>
		/// Лид.
		/// </summary>
		public string LeadName {
			get {
				return GetTypedColumnValue<string>("LeadName");
			}
			set {
				SetColumnValue("LeadName", value);
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

		/// <summary>
		/// Страна (строка).
		/// </summary>
		public string CountryStr {
			get {
				return GetTypedColumnValue<string>("CountryStr");
			}
			set {
				SetColumnValue("CountryStr", value);
			}
		}

		/// <summary>
		/// Область/штат (строка).
		/// </summary>
		public string RegionStr {
			get {
				return GetTypedColumnValue<string>("RegionStr");
			}
			set {
				SetColumnValue("RegionStr", value);
			}
		}

		/// <summary>
		/// Город (строка).
		/// </summary>
		public string CityStr {
			get {
				return GetTypedColumnValue<string>("CityStr");
			}
			set {
				SetColumnValue("CityStr", value);
			}
		}

		/// <exclude/>
		public Guid WebFormId {
			get {
				return GetTypedColumnValue<Guid>("WebFormId");
			}
			set {
				SetColumnValue("WebFormId", value);
				_webForm = null;
			}
		}

		/// <exclude/>
		public string WebFormName {
			get {
				return GetTypedColumnValue<string>("WebFormName");
			}
			set {
				SetColumnValue("WebFormName", value);
				if (_webForm != null) {
					_webForm.Name = value;
				}
			}
		}

		private GeneratedWebForm _webForm;
		/// <summary>
		/// Лендинг.
		/// </summary>
		public GeneratedWebForm WebForm {
			get {
				return _webForm ??
					(_webForm = new GeneratedWebForm(LookupColumnEntities.GetEntity("WebForm")));
			}
		}

		/// <exclude/>
		public Guid LeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeId");
			}
			set {
				SetColumnValue("LeadTypeId", value);
				_leadType = null;
			}
		}

		/// <exclude/>
		public string LeadTypeName {
			get {
				return GetTypedColumnValue<string>("LeadTypeName");
			}
			set {
				SetColumnValue("LeadTypeName", value);
				if (_leadType != null) {
					_leadType.Name = value;
				}
			}
		}

		private LeadType _leadType;
		/// <summary>
		/// Тип потребности.
		/// </summary>
		public LeadType LeadType {
			get {
				return _leadType ??
					(_leadType = new LeadType(LookupColumnEntities.GetEntity("LeadType")));
			}
		}

		/// <exclude/>
		public Guid LeadTypeStatusId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeStatusId");
			}
			set {
				SetColumnValue("LeadTypeStatusId", value);
				_leadTypeStatus = null;
			}
		}

		/// <exclude/>
		public string LeadTypeStatusName {
			get {
				return GetTypedColumnValue<string>("LeadTypeStatusName");
			}
			set {
				SetColumnValue("LeadTypeStatusName", value);
				if (_leadTypeStatus != null) {
					_leadTypeStatus.Name = value;
				}
			}
		}

		private LeadTypeStatus _leadTypeStatus;
		/// <summary>
		/// Зрелость потребности.
		/// </summary>
		public LeadTypeStatus LeadTypeStatus {
			get {
				return _leadTypeStatus ??
					(_leadTypeStatus = new LeadTypeStatus(LookupColumnEntities.GetEntity("LeadTypeStatus")));
			}
		}

		/// <exclude/>
		public Guid LeadDisqualifyReasonId {
			get {
				return GetTypedColumnValue<Guid>("LeadDisqualifyReasonId");
			}
			set {
				SetColumnValue("LeadDisqualifyReasonId", value);
				_leadDisqualifyReason = null;
			}
		}

		/// <exclude/>
		public string LeadDisqualifyReasonName {
			get {
				return GetTypedColumnValue<string>("LeadDisqualifyReasonName");
			}
			set {
				SetColumnValue("LeadDisqualifyReasonName", value);
				if (_leadDisqualifyReason != null) {
					_leadDisqualifyReason.Name = value;
				}
			}
		}

		private LeadDisqualifyReason _leadDisqualifyReason;
		/// <summary>
		/// Причина дисквалификации.
		/// </summary>
		public LeadDisqualifyReason LeadDisqualifyReason {
			get {
				return _leadDisqualifyReason ??
					(_leadDisqualifyReason = new LeadDisqualifyReason(LookupColumnEntities.GetEntity("LeadDisqualifyReason")));
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
		public Guid AccountOwnershipId {
			get {
				return GetTypedColumnValue<Guid>("AccountOwnershipId");
			}
			set {
				SetColumnValue("AccountOwnershipId", value);
				_accountOwnership = null;
			}
		}

		/// <exclude/>
		public string AccountOwnershipName {
			get {
				return GetTypedColumnValue<string>("AccountOwnershipName");
			}
			set {
				SetColumnValue("AccountOwnershipName", value);
				if (_accountOwnership != null) {
					_accountOwnership.Name = value;
				}
			}
		}

		private AccountOwnership _accountOwnership;
		/// <summary>
		/// Форма собственности.
		/// </summary>
		public AccountOwnership AccountOwnership {
			get {
				return _accountOwnership ??
					(_accountOwnership = new AccountOwnership(LookupColumnEntities.GetEntity("AccountOwnership")));
			}
		}

		/// <exclude/>
		public Guid DepartmentId {
			get {
				return GetTypedColumnValue<Guid>("DepartmentId");
			}
			set {
				SetColumnValue("DepartmentId", value);
				_department = null;
			}
		}

		/// <exclude/>
		public string DepartmentName {
			get {
				return GetTypedColumnValue<string>("DepartmentName");
			}
			set {
				SetColumnValue("DepartmentName", value);
				if (_department != null) {
					_department.Name = value;
				}
			}
		}

		private Department _department;
		/// <summary>
		/// Департамент.
		/// </summary>
		public Department Department {
			get {
				return _department ??
					(_department = new Department(LookupColumnEntities.GetEntity("Department")));
			}
		}

		/// <exclude/>
		public Guid GenderId {
			get {
				return GetTypedColumnValue<Guid>("GenderId");
			}
			set {
				SetColumnValue("GenderId", value);
				_gender = null;
			}
		}

		/// <exclude/>
		public string GenderName {
			get {
				return GetTypedColumnValue<string>("GenderName");
			}
			set {
				SetColumnValue("GenderName", value);
				if (_gender != null) {
					_gender.Name = value;
				}
			}
		}

		private Gender _gender;
		/// <summary>
		/// Пол.
		/// </summary>
		public Gender Gender {
			get {
				return _gender ??
					(_gender = new Gender(LookupColumnEntities.GetEntity("Gender")));
			}
		}

		/// <exclude/>
		public Guid JobId {
			get {
				return GetTypedColumnValue<Guid>("JobId");
			}
			set {
				SetColumnValue("JobId", value);
				_job = null;
			}
		}

		/// <exclude/>
		public string JobName {
			get {
				return GetTypedColumnValue<string>("JobName");
			}
			set {
				SetColumnValue("JobName", value);
				if (_job != null) {
					_job.Name = value;
				}
			}
		}

		private Job _job;
		/// <summary>
		/// Должность.
		/// </summary>
		public Job Job {
			get {
				return _job ??
					(_job = new Job(LookupColumnEntities.GetEntity("Job")));
			}
		}

		/// <exclude/>
		public Guid DecisionRoleId {
			get {
				return GetTypedColumnValue<Guid>("DecisionRoleId");
			}
			set {
				SetColumnValue("DecisionRoleId", value);
				_decisionRole = null;
			}
		}

		/// <exclude/>
		public string DecisionRoleName {
			get {
				return GetTypedColumnValue<string>("DecisionRoleName");
			}
			set {
				SetColumnValue("DecisionRoleName", value);
				if (_decisionRole != null) {
					_decisionRole.Name = value;
				}
			}
		}

		private ContactDecisionRole _decisionRole;
		/// <summary>
		/// Роль.
		/// </summary>
		public ContactDecisionRole DecisionRole {
			get {
				return _decisionRole ??
					(_decisionRole = new ContactDecisionRole(LookupColumnEntities.GetEntity("DecisionRole")));
			}
		}

		/// <exclude/>
		public Guid QualifyStatusId {
			get {
				return GetTypedColumnValue<Guid>("QualifyStatusId");
			}
			set {
				SetColumnValue("QualifyStatusId", value);
				_qualifyStatus = null;
			}
		}

		/// <exclude/>
		public string QualifyStatusName {
			get {
				return GetTypedColumnValue<string>("QualifyStatusName");
			}
			set {
				SetColumnValue("QualifyStatusName", value);
				if (_qualifyStatus != null) {
					_qualifyStatus.Name = value;
				}
			}
		}

		private QualifyStatus _qualifyStatus;
		/// <summary>
		/// Стадия лида.
		/// </summary>
		public QualifyStatus QualifyStatus {
			get {
				return _qualifyStatus ??
					(_qualifyStatus = new QualifyStatus(LookupColumnEntities.GetEntity("QualifyStatus")));
			}
		}

		/// <summary>
		/// Приветствие.
		/// </summary>
		public string Dear {
			get {
				return GetTypedColumnValue<string>("Dear");
			}
			set {
				SetColumnValue("Dear", value);
			}
		}

		/// <summary>
		/// QualificationProcessId.
		/// </summary>
		/// <remarks>
		/// Идентификатор в таблице SysProcessData.
		/// </remarks>
		public Guid QualificationProcessId {
			get {
				return GetTypedColumnValue<Guid>("QualificationProcessId");
			}
			set {
				SetColumnValue("QualificationProcessId", value);
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
		/// Напоминание ответственному.
		/// </summary>
		public bool RemindToOwner {
			get {
				return GetTypedColumnValue<bool>("RemindToOwner");
			}
			set {
				SetColumnValue("RemindToOwner", value);
			}
		}

		/// <exclude/>
		public Guid SalesOwnerId {
			get {
				return GetTypedColumnValue<Guid>("SalesOwnerId");
			}
			set {
				SetColumnValue("SalesOwnerId", value);
				_salesOwner = null;
			}
		}

		/// <exclude/>
		public string SalesOwnerName {
			get {
				return GetTypedColumnValue<string>("SalesOwnerName");
			}
			set {
				SetColumnValue("SalesOwnerName", value);
				if (_salesOwner != null) {
					_salesOwner.Name = value;
				}
			}
		}

		private Contact _salesOwner;
		/// <summary>
		/// Ответственный за продажу.
		/// </summary>
		public Contact SalesOwner {
			get {
				return _salesOwner ??
					(_salesOwner = new Contact(LookupColumnEntities.GetEntity("SalesOwner")));
			}
		}

		/// <summary>
		/// Бюджет.
		/// </summary>
		public Decimal Budget {
			get {
				return GetTypedColumnValue<Decimal>("Budget");
			}
			set {
				SetColumnValue("Budget", value);
			}
		}

		/// <summary>
		/// Дата и время встречи.
		/// </summary>
		public DateTime MeetingDate {
			get {
				return GetTypedColumnValue<DateTime>("MeetingDate");
			}
			set {
				SetColumnValue("MeetingDate", value);
			}
		}

		/// <summary>
		/// Дата принятия решения.
		/// </summary>
		public DateTime DecisionDate {
			get {
				return GetTypedColumnValue<DateTime>("DecisionDate");
			}
			set {
				SetColumnValue("DecisionDate", value);
			}
		}

		/// <summary>
		/// Отображать страницу распределения.
		/// </summary>
		public bool ShowDistributionPage {
			get {
				return GetTypedColumnValue<bool>("ShowDistributionPage");
			}
			set {
				SetColumnValue("ShowDistributionPage", value);
			}
		}

		/// <summary>
		/// BpmHref.
		/// </summary>
		public string BpmHref {
			get {
				return GetTypedColumnValue<string>("BpmHref");
			}
			set {
				SetColumnValue("BpmHref", value);
			}
		}

		/// <summary>
		/// Сайт перехода.
		/// </summary>
		public string BpmRef {
			get {
				return GetTypedColumnValue<string>("BpmRef");
			}
			set {
				SetColumnValue("BpmRef", value);
			}
		}

		/// <exclude/>
		public Guid RegisterMethodId {
			get {
				return GetTypedColumnValue<Guid>("RegisterMethodId");
			}
			set {
				SetColumnValue("RegisterMethodId", value);
				_registerMethod = null;
			}
		}

		/// <exclude/>
		public string RegisterMethodName {
			get {
				return GetTypedColumnValue<string>("RegisterMethodName");
			}
			set {
				SetColumnValue("RegisterMethodName", value);
				if (_registerMethod != null) {
					_registerMethod.Name = value;
				}
			}
		}

		private LeadRegisterMethod _registerMethod;
		/// <summary>
		/// Как зарегистрирован.
		/// </summary>
		public LeadRegisterMethod RegisterMethod {
			get {
				return _registerMethod ??
					(_registerMethod = new LeadRegisterMethod(LookupColumnEntities.GetEntity("RegisterMethod")));
			}
		}

		/// <exclude/>
		public Guid LeadSourceId {
			get {
				return GetTypedColumnValue<Guid>("LeadSourceId");
			}
			set {
				SetColumnValue("LeadSourceId", value);
				_leadSource = null;
			}
		}

		/// <exclude/>
		public string LeadSourceName {
			get {
				return GetTypedColumnValue<string>("LeadSourceName");
			}
			set {
				SetColumnValue("LeadSourceName", value);
				if (_leadSource != null) {
					_leadSource.Name = value;
				}
			}
		}

		private LeadSource _leadSource;
		/// <summary>
		/// Источник.
		/// </summary>
		public LeadSource LeadSource {
			get {
				return _leadSource ??
					(_leadSource = new LeadSource(LookupColumnEntities.GetEntity("LeadSource")));
			}
		}

		/// <exclude/>
		public Guid LeadMediumId {
			get {
				return GetTypedColumnValue<Guid>("LeadMediumId");
			}
			set {
				SetColumnValue("LeadMediumId", value);
				_leadMedium = null;
			}
		}

		/// <exclude/>
		public string LeadMediumName {
			get {
				return GetTypedColumnValue<string>("LeadMediumName");
			}
			set {
				SetColumnValue("LeadMediumName", value);
				if (_leadMedium != null) {
					_leadMedium.Name = value;
				}
			}
		}

		private LeadMedium _leadMedium;
		/// <summary>
		/// Канал.
		/// </summary>
		public LeadMedium LeadMedium {
			get {
				return _leadMedium ??
					(_leadMedium = new LeadMedium(LookupColumnEntities.GetEntity("LeadMedium")));
			}
		}

		/// <exclude/>
		public Guid OpportunityDepartmentId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityDepartmentId");
			}
			set {
				SetColumnValue("OpportunityDepartmentId", value);
				_opportunityDepartment = null;
			}
		}

		/// <exclude/>
		public string OpportunityDepartmentName {
			get {
				return GetTypedColumnValue<string>("OpportunityDepartmentName");
			}
			set {
				SetColumnValue("OpportunityDepartmentName", value);
				if (_opportunityDepartment != null) {
					_opportunityDepartment.Name = value;
				}
			}
		}

		private OpportunityDepartment _opportunityDepartment;
		/// <summary>
		/// Направление продажи.
		/// </summary>
		public OpportunityDepartment OpportunityDepartment {
			get {
				return _opportunityDepartment ??
					(_opportunityDepartment = new OpportunityDepartment(LookupColumnEntities.GetEntity("OpportunityDepartment")));
			}
		}

		/// <summary>
		/// Идентификация пройдена.
		/// </summary>
		public bool IdentificationPassed {
			get {
				return GetTypedColumnValue<bool>("IdentificationPassed");
			}
			set {
				SetColumnValue("IdentificationPassed", value);
			}
		}

		/// <exclude/>
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампания.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = new Campaign(LookupColumnEntities.GetEntity("Campaign")));
			}
		}

		/// <exclude/>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
				_bulkEmail = null;
			}
		}

		/// <exclude/>
		public string BulkEmailName {
			get {
				return GetTypedColumnValue<string>("BulkEmailName");
			}
			set {
				SetColumnValue("BulkEmailName", value);
				if (_bulkEmail != null) {
					_bulkEmail.Name = value;
				}
			}
		}

		private BulkEmail _bulkEmail;
		/// <summary>
		/// Рассылка.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = new BulkEmail(LookupColumnEntities.GetEntity("BulkEmail")));
			}
		}

		/// <summary>
		/// Квалифицирован.
		/// </summary>
		public int Qualified {
			get {
				return GetTypedColumnValue<int>("Qualified");
			}
			set {
				SetColumnValue("Qualified", value);
			}
		}

		/// <summary>
		/// Участник продаж.
		/// </summary>
		public int SaleParticipant {
			get {
				return GetTypedColumnValue<int>("SaleParticipant");
			}
			set {
				SetColumnValue("SaleParticipant", value);
			}
		}

		/// <summary>
		/// % квалифицированных.
		/// </summary>
		public Decimal QualifiedPercent {
			get {
				return GetTypedColumnValue<Decimal>("QualifiedPercent");
			}
			set {
				SetColumnValue("QualifiedPercent", value);
			}
		}

		/// <summary>
		/// % продаж.
		/// </summary>
		public Decimal SalePercent {
			get {
				return GetTypedColumnValue<Decimal>("SalePercent");
			}
			set {
				SetColumnValue("SalePercent", value);
			}
		}

		/// <summary>
		/// Запускать процесс при создании лида.
		/// </summary>
		public bool StartLeadManagementProcess {
			get {
				return GetTypedColumnValue<bool>("StartLeadManagementProcess");
			}
			set {
				SetColumnValue("StartLeadManagementProcess", value);
			}
		}

		/// <summary>
		/// Тип продажи.
		/// </summary>
		public string SaleType {
			get {
				return GetTypedColumnValue<string>("SaleType");
			}
			set {
				SetColumnValue("SaleType", value);
			}
		}

		/// <summary>
		/// Рейтинг.
		/// </summary>
		public Decimal Score {
			get {
				return GetTypedColumnValue<Decimal>("Score");
			}
			set {
				SetColumnValue("Score", value);
			}
		}

		/// <summary>
		/// Квалификация пройдена.
		/// </summary>
		public bool QualificationPassed {
			get {
				return GetTypedColumnValue<bool>("QualificationPassed");
			}
			set {
				SetColumnValue("QualificationPassed", value);
			}
		}

		/// <exclude/>
		public Guid EventId {
			get {
				return GetTypedColumnValue<Guid>("EventId");
			}
			set {
				SetColumnValue("EventId", value);
				_event = null;
			}
		}

		/// <exclude/>
		public string EventName {
			get {
				return GetTypedColumnValue<string>("EventName");
			}
			set {
				SetColumnValue("EventName", value);
				if (_event != null) {
					_event.Name = value;
				}
			}
		}

		private Event _event;
		/// <summary>
		/// Мероприятие.
		/// </summary>
		public Event Event {
			get {
				return _event ??
					(_event = new Event(LookupColumnEntities.GetEntity("Event")));
			}
		}

		/// <summary>
		/// Дата следующей актуализации.
		/// </summary>
		public DateTime NextActualizationDate {
			get {
				return GetTypedColumnValue<DateTime>("NextActualizationDate");
			}
			set {
				SetColumnValue("NextActualizationDate", value);
			}
		}

		/// <summary>
		/// BpmSessionId.
		/// </summary>
		public Guid BpmSessionId {
			get {
				return GetTypedColumnValue<Guid>("BpmSessionId");
			}
			set {
				SetColumnValue("BpmSessionId", value);
			}
		}

		/// <summary>
		/// Предиктивный рейтинг.
		/// </summary>
		public int PredictiveScore {
			get {
				return GetTypedColumnValue<int>("PredictiveScore");
			}
			set {
				SetColumnValue("PredictiveScore", value);
			}
		}

		/// <summary>
		/// Дата перевода в конечную стадию .
		/// </summary>
		public DateTime MovedToFinalStateOn {
			get {
				return GetTypedColumnValue<DateTime>("MovedToFinalStateOn");
			}
			set {
				SetColumnValue("MovedToFinalStateOn", value);
			}
		}

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = new Opportunity(LookupColumnEntities.GetEntity("Opportunity")));
			}
		}

		/// <exclude/>
		public Guid PartnerId {
			get {
				return GetTypedColumnValue<Guid>("PartnerId");
			}
			set {
				SetColumnValue("PartnerId", value);
				_partner = null;
			}
		}

		/// <exclude/>
		public string PartnerName {
			get {
				return GetTypedColumnValue<string>("PartnerName");
			}
			set {
				SetColumnValue("PartnerName", value);
				if (_partner != null) {
					_partner.Name = value;
				}
			}
		}

		private Account _partner;
		/// <summary>
		/// Партнер.
		/// </summary>
		public Account Partner {
			get {
				return _partner ??
					(_partner = new Account(LookupColumnEntities.GetEntity("Partner")));
			}
		}

		/// <exclude/>
		public Guid PartnerOwnerId {
			get {
				return GetTypedColumnValue<Guid>("PartnerOwnerId");
			}
			set {
				SetColumnValue("PartnerOwnerId", value);
				_partnerOwner = null;
			}
		}

		/// <exclude/>
		public string PartnerOwnerName {
			get {
				return GetTypedColumnValue<string>("PartnerOwnerName");
			}
			set {
				SetColumnValue("PartnerOwnerName", value);
				if (_partnerOwner != null) {
					_partnerOwner.Name = value;
				}
			}
		}

		private Contact _partnerOwner;
		/// <summary>
		/// Ответственный партнера за сделку.
		/// </summary>
		public Contact PartnerOwner {
			get {
				return _partnerOwner ??
					(_partnerOwner = new Contact(LookupColumnEntities.GetEntity("PartnerOwner")));
			}
		}

		/// <exclude/>
		public Guid PartnerTypeId {
			get {
				return GetTypedColumnValue<Guid>("PartnerTypeId");
			}
			set {
				SetColumnValue("PartnerTypeId", value);
				_partnerType = null;
			}
		}

		/// <exclude/>
		public string PartnerTypeName {
			get {
				return GetTypedColumnValue<string>("PartnerTypeName");
			}
			set {
				SetColumnValue("PartnerTypeName", value);
				if (_partnerType != null) {
					_partnerType.Name = value;
				}
			}
		}

		private PartnerType _partnerType;
		/// <summary>
		/// Тип партнера.
		/// </summary>
		public PartnerType PartnerType {
			get {
				return _partnerType ??
					(_partnerType = new PartnerType(LookupColumnEntities.GetEntity("PartnerType")));
			}
		}

		/// <exclude/>
		public Guid SalesChannelId {
			get {
				return GetTypedColumnValue<Guid>("SalesChannelId");
			}
			set {
				SetColumnValue("SalesChannelId", value);
				_salesChannel = null;
			}
		}

		/// <exclude/>
		public string SalesChannelName {
			get {
				return GetTypedColumnValue<string>("SalesChannelName");
			}
			set {
				SetColumnValue("SalesChannelName", value);
				if (_salesChannel != null) {
					_salesChannel.Name = value;
				}
			}
		}

		private OpportunityType _salesChannel;
		/// <summary>
		/// Канал продажи.
		/// </summary>
		public OpportunityType SalesChannel {
			get {
				return _salesChannel ??
					(_salesChannel = new OpportunityType(LookupColumnEntities.GetEntity("SalesChannel")));
			}
		}

		/// <exclude/>
		public Guid OrderId {
			get {
				return GetTypedColumnValue<Guid>("OrderId");
			}
			set {
				SetColumnValue("OrderId", value);
				_order = null;
			}
		}

		/// <exclude/>
		public string OrderNumber {
			get {
				return GetTypedColumnValue<string>("OrderNumber");
			}
			set {
				SetColumnValue("OrderNumber", value);
				if (_order != null) {
					_order.Number = value;
				}
			}
		}

		private Order _order;
		/// <summary>
		/// Заказ.
		/// </summary>
		public Order Order {
			get {
				return _order ??
					(_order = new Order(LookupColumnEntities.GetEntity("Order")));
			}
		}

		/// <exclude/>
		public Guid LeadGenExtendedLeadInfoId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenExtendedLeadInfoId");
			}
			set {
				SetColumnValue("LeadGenExtendedLeadInfoId", value);
				_leadGenExtendedLeadInfo = null;
			}
		}

		/// <exclude/>
		public string LeadGenExtendedLeadInfoSocialLeadId {
			get {
				return GetTypedColumnValue<string>("LeadGenExtendedLeadInfoSocialLeadId");
			}
			set {
				SetColumnValue("LeadGenExtendedLeadInfoSocialLeadId", value);
				if (_leadGenExtendedLeadInfo != null) {
					_leadGenExtendedLeadInfo.SocialLeadId = value;
				}
			}
		}

		private LeadGenExtendedLeadInformation _leadGenExtendedLeadInfo;
		/// <summary>
		/// Расширенная информация о лиде.
		/// </summary>
		public LeadGenExtendedLeadInformation LeadGenExtendedLeadInfo {
			get {
				return _leadGenExtendedLeadInfo ??
					(_leadGenExtendedLeadInfo = new LeadGenExtendedLeadInformation(LookupColumnEntities.GetEntity("LeadGenExtendedLeadInfo")));
			}
		}

		/// <summary>
		/// Социальные метаданные.
		/// </summary>
		public string SocialMetadata {
			get {
				return GetTypedColumnValue<string>("SocialMetadata");
			}
			set {
				SetColumnValue("SocialMetadata", value);
			}
		}

		#endregion

	}

	#endregion

}

