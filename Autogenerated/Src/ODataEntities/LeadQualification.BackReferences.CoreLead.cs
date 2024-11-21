namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: LeadQualification

	/// <exclude/>
	public class LeadQualification : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public LeadQualification(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadQualification";
		}

		public LeadQualification(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "LeadQualification";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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
		/// Лид.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Рабочий телефон.
		/// </summary>
		public string ContactBusinessPhone {
			get {
				return GetTypedColumnValue<string>("ContactBusinessPhone");
			}
			set {
				SetColumnValue("ContactBusinessPhone", value);
			}
		}

		/// <summary>
		/// Мобильный телефон.
		/// </summary>
		public string ContactMobilePhone {
			get {
				return GetTypedColumnValue<string>("ContactMobilePhone");
			}
			set {
				SetColumnValue("ContactMobilePhone", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string ContactEmail {
			get {
				return GetTypedColumnValue<string>("ContactEmail");
			}
			set {
				SetColumnValue("ContactEmail", value);
			}
		}

		/// <summary>
		/// Основной телефон.
		/// </summary>
		public string AccountBusinessPhone {
			get {
				return GetTypedColumnValue<string>("AccountBusinessPhone");
			}
			set {
				SetColumnValue("AccountBusinessPhone", value);
			}
		}

		/// <summary>
		/// Факс.
		/// </summary>
		public string AccountFax {
			get {
				return GetTypedColumnValue<string>("AccountFax");
			}
			set {
				SetColumnValue("AccountFax", value);
			}
		}

		/// <summary>
		/// Интернет.
		/// </summary>
		public string AccountWebsite {
			get {
				return GetTypedColumnValue<string>("AccountWebsite");
			}
			set {
				SetColumnValue("AccountWebsite", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
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

		/// <summary>
		/// ФИО.
		/// </summary>
		public string LeadContactName {
			get {
				return GetTypedColumnValue<string>("LeadContactName");
			}
			set {
				SetColumnValue("LeadContactName", value);
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
		public Guid SalutationId {
			get {
				return GetTypedColumnValue<Guid>("SalutationId");
			}
			set {
				SetColumnValue("SalutationId", value);
				_salutation = null;
			}
		}

		/// <exclude/>
		public string SalutationName {
			get {
				return GetTypedColumnValue<string>("SalutationName");
			}
			set {
				SetColumnValue("SalutationName", value);
				if (_salutation != null) {
					_salutation.Name = value;
				}
			}
		}

		private ContactSalutationType _salutation;
		/// <summary>
		/// Обращение.
		/// </summary>
		public ContactSalutationType Salutation {
			get {
				return _salutation ??
					(_salutation = new ContactSalutationType(LookupColumnEntities.GetEntity("Salutation")));
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

		/// <summary>
		/// Название.
		/// </summary>
		public string LeadAccountName {
			get {
				return GetTypedColumnValue<string>("LeadAccountName");
			}
			set {
				SetColumnValue("LeadAccountName", value);
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
		public Guid LeadTypeRipenessId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeRipenessId");
			}
			set {
				SetColumnValue("LeadTypeRipenessId", value);
				_leadTypeRipeness = null;
			}
		}

		/// <exclude/>
		public string LeadTypeRipenessName {
			get {
				return GetTypedColumnValue<string>("LeadTypeRipenessName");
			}
			set {
				SetColumnValue("LeadTypeRipenessName", value);
				if (_leadTypeRipeness != null) {
					_leadTypeRipeness.Name = value;
				}
			}
		}

		private LeadTypeStatus _leadTypeRipeness;
		/// <summary>
		/// Зрелость потребности.
		/// </summary>
		public LeadTypeStatus LeadTypeRipeness {
			get {
				return _leadTypeRipeness ??
					(_leadTypeRipeness = new LeadTypeStatus(LookupColumnEntities.GetEntity("LeadTypeRipeness")));
			}
		}

		/// <exclude/>
		public Guid LeadContactAddressTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadContactAddressTypeId");
			}
			set {
				SetColumnValue("LeadContactAddressTypeId", value);
				_leadContactAddressType = null;
			}
		}

		/// <exclude/>
		public string LeadContactAddressTypeName {
			get {
				return GetTypedColumnValue<string>("LeadContactAddressTypeName");
			}
			set {
				SetColumnValue("LeadContactAddressTypeName", value);
				if (_leadContactAddressType != null) {
					_leadContactAddressType.Name = value;
				}
			}
		}

		private AddressType _leadContactAddressType;
		/// <summary>
		/// Тип адреса.
		/// </summary>
		public AddressType LeadContactAddressType {
			get {
				return _leadContactAddressType ??
					(_leadContactAddressType = new AddressType(LookupColumnEntities.GetEntity("LeadContactAddressType")));
			}
		}

		/// <exclude/>
		public Guid LeadContactCountryId {
			get {
				return GetTypedColumnValue<Guid>("LeadContactCountryId");
			}
			set {
				SetColumnValue("LeadContactCountryId", value);
				_leadContactCountry = null;
			}
		}

		/// <exclude/>
		public string LeadContactCountryName {
			get {
				return GetTypedColumnValue<string>("LeadContactCountryName");
			}
			set {
				SetColumnValue("LeadContactCountryName", value);
				if (_leadContactCountry != null) {
					_leadContactCountry.Name = value;
				}
			}
		}

		private Country _leadContactCountry;
		/// <summary>
		/// Страна.
		/// </summary>
		public Country LeadContactCountry {
			get {
				return _leadContactCountry ??
					(_leadContactCountry = new Country(LookupColumnEntities.GetEntity("LeadContactCountry")));
			}
		}

		/// <exclude/>
		public Guid LeadContactRegionId {
			get {
				return GetTypedColumnValue<Guid>("LeadContactRegionId");
			}
			set {
				SetColumnValue("LeadContactRegionId", value);
				_leadContactRegion = null;
			}
		}

		/// <exclude/>
		public string LeadContactRegionName {
			get {
				return GetTypedColumnValue<string>("LeadContactRegionName");
			}
			set {
				SetColumnValue("LeadContactRegionName", value);
				if (_leadContactRegion != null) {
					_leadContactRegion.Name = value;
				}
			}
		}

		private Region _leadContactRegion;
		/// <summary>
		/// Область/штат.
		/// </summary>
		public Region LeadContactRegion {
			get {
				return _leadContactRegion ??
					(_leadContactRegion = new Region(LookupColumnEntities.GetEntity("LeadContactRegion")));
			}
		}

		/// <exclude/>
		public Guid LeadContactCityId {
			get {
				return GetTypedColumnValue<Guid>("LeadContactCityId");
			}
			set {
				SetColumnValue("LeadContactCityId", value);
				_leadContactCity = null;
			}
		}

		/// <exclude/>
		public string LeadContactCityName {
			get {
				return GetTypedColumnValue<string>("LeadContactCityName");
			}
			set {
				SetColumnValue("LeadContactCityName", value);
				if (_leadContactCity != null) {
					_leadContactCity.Name = value;
				}
			}
		}

		private City _leadContactCity;
		/// <summary>
		/// Город.
		/// </summary>
		public City LeadContactCity {
			get {
				return _leadContactCity ??
					(_leadContactCity = new City(LookupColumnEntities.GetEntity("LeadContactCity")));
			}
		}

		/// <summary>
		/// Индекс.
		/// </summary>
		public string LeadContactZip {
			get {
				return GetTypedColumnValue<string>("LeadContactZip");
			}
			set {
				SetColumnValue("LeadContactZip", value);
			}
		}

		/// <summary>
		/// Адрес.
		/// </summary>
		public string LeadContactAddress {
			get {
				return GetTypedColumnValue<string>("LeadContactAddress");
			}
			set {
				SetColumnValue("LeadContactAddress", value);
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

		private InformationSource _leadSource;
		/// <summary>
		/// Источник.
		/// </summary>
		public InformationSource LeadSource {
			get {
				return _leadSource ??
					(_leadSource = new InformationSource(LookupColumnEntities.GetEntity("LeadSource")));
			}
		}

		/// <exclude/>
		public Guid LeadAccountAddressTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadAccountAddressTypeId");
			}
			set {
				SetColumnValue("LeadAccountAddressTypeId", value);
				_leadAccountAddressType = null;
			}
		}

		/// <exclude/>
		public string LeadAccountAddressTypeName {
			get {
				return GetTypedColumnValue<string>("LeadAccountAddressTypeName");
			}
			set {
				SetColumnValue("LeadAccountAddressTypeName", value);
				if (_leadAccountAddressType != null) {
					_leadAccountAddressType.Name = value;
				}
			}
		}

		private AddressType _leadAccountAddressType;
		/// <summary>
		/// Тип адреса.
		/// </summary>
		public AddressType LeadAccountAddressType {
			get {
				return _leadAccountAddressType ??
					(_leadAccountAddressType = new AddressType(LookupColumnEntities.GetEntity("LeadAccountAddressType")));
			}
		}

		/// <exclude/>
		public Guid LeadAccountCountryId {
			get {
				return GetTypedColumnValue<Guid>("LeadAccountCountryId");
			}
			set {
				SetColumnValue("LeadAccountCountryId", value);
				_leadAccountCountry = null;
			}
		}

		/// <exclude/>
		public string LeadAccountCountryName {
			get {
				return GetTypedColumnValue<string>("LeadAccountCountryName");
			}
			set {
				SetColumnValue("LeadAccountCountryName", value);
				if (_leadAccountCountry != null) {
					_leadAccountCountry.Name = value;
				}
			}
		}

		private Country _leadAccountCountry;
		/// <summary>
		/// Страна.
		/// </summary>
		public Country LeadAccountCountry {
			get {
				return _leadAccountCountry ??
					(_leadAccountCountry = new Country(LookupColumnEntities.GetEntity("LeadAccountCountry")));
			}
		}

		/// <exclude/>
		public Guid LeadAccountRegionId {
			get {
				return GetTypedColumnValue<Guid>("LeadAccountRegionId");
			}
			set {
				SetColumnValue("LeadAccountRegionId", value);
				_leadAccountRegion = null;
			}
		}

		/// <exclude/>
		public string LeadAccountRegionName {
			get {
				return GetTypedColumnValue<string>("LeadAccountRegionName");
			}
			set {
				SetColumnValue("LeadAccountRegionName", value);
				if (_leadAccountRegion != null) {
					_leadAccountRegion.Name = value;
				}
			}
		}

		private Region _leadAccountRegion;
		/// <summary>
		/// Область/штат.
		/// </summary>
		public Region LeadAccountRegion {
			get {
				return _leadAccountRegion ??
					(_leadAccountRegion = new Region(LookupColumnEntities.GetEntity("LeadAccountRegion")));
			}
		}

		/// <exclude/>
		public Guid LeadAccountCityId {
			get {
				return GetTypedColumnValue<Guid>("LeadAccountCityId");
			}
			set {
				SetColumnValue("LeadAccountCityId", value);
				_leadAccountCity = null;
			}
		}

		/// <exclude/>
		public string LeadAccountCityName {
			get {
				return GetTypedColumnValue<string>("LeadAccountCityName");
			}
			set {
				SetColumnValue("LeadAccountCityName", value);
				if (_leadAccountCity != null) {
					_leadAccountCity.Name = value;
				}
			}
		}

		private City _leadAccountCity;
		/// <summary>
		/// Город.
		/// </summary>
		public City LeadAccountCity {
			get {
				return _leadAccountCity ??
					(_leadAccountCity = new City(LookupColumnEntities.GetEntity("LeadAccountCity")));
			}
		}

		/// <summary>
		/// Индекс.
		/// </summary>
		public string LeadAccountZip {
			get {
				return GetTypedColumnValue<string>("LeadAccountZip");
			}
			set {
				SetColumnValue("LeadAccountZip", value);
			}
		}

		/// <summary>
		/// Адрес.
		/// </summary>
		public string LeadAccountAddress {
			get {
				return GetTypedColumnValue<string>("LeadAccountAddress");
			}
			set {
				SetColumnValue("LeadAccountAddress", value);
			}
		}

		#endregion

	}

	#endregion

}

