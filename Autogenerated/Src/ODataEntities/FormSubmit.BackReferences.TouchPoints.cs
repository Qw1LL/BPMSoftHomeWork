namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: FormSubmit

	/// <exclude/>
	public class FormSubmit : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public FormSubmit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FormSubmit";
		}

		public FormSubmit(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "FormSubmit";
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

		/// <summary>
		/// Данные.
		/// </summary>
		public string FormData {
			get {
				return GetTypedColumnValue<string>("FormData");
			}
			set {
				SetColumnValue("FormData", value);
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
		/// Вэб форма.
		/// </summary>
		public GeneratedWebForm WebForm {
			get {
				return _webForm ??
					(_webForm = new GeneratedWebForm(LookupColumnEntities.GetEntity("WebForm")));
			}
		}

		/// <summary>
		/// Номер телефона.
		/// </summary>
		public string PhoneNumber {
			get {
				return GetTypedColumnValue<string>("PhoneNumber");
			}
			set {
				SetColumnValue("PhoneNumber", value);
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
		/// Фамилия.
		/// </summary>
		public string LastName {
			get {
				return GetTypedColumnValue<string>("LastName");
			}
			set {
				SetColumnValue("LastName", value);
			}
		}

		/// <summary>
		/// Имя.
		/// </summary>
		public string FirstName {
			get {
				return GetTypedColumnValue<string>("FirstName");
			}
			set {
				SetColumnValue("FirstName", value);
			}
		}

		/// <summary>
		/// ФИО.
		/// </summary>
		public string FullName {
			get {
				return GetTypedColumnValue<string>("FullName");
			}
			set {
				SetColumnValue("FullName", value);
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

		/// <summary>
		/// Отрасль (строка).
		/// </summary>
		public string AccountIndustryStr {
			get {
				return GetTypedColumnValue<string>("AccountIndustryStr");
			}
			set {
				SetColumnValue("AccountIndustryStr", value);
			}
		}

		/// <exclude/>
		public Guid AccountIndustryId {
			get {
				return GetTypedColumnValue<Guid>("AccountIndustryId");
			}
			set {
				SetColumnValue("AccountIndustryId", value);
				_accountIndustry = null;
			}
		}

		/// <exclude/>
		public string AccountIndustryName {
			get {
				return GetTypedColumnValue<string>("AccountIndustryName");
			}
			set {
				SetColumnValue("AccountIndustryName", value);
				if (_accountIndustry != null) {
					_accountIndustry.Name = value;
				}
			}
		}

		private AccountIndustry _accountIndustry;
		/// <summary>
		/// Отрасль.
		/// </summary>
		public AccountIndustry AccountIndustry {
			get {
				return _accountIndustry ??
					(_accountIndustry = new AccountIndustry(LookupColumnEntities.GetEntity("AccountIndustry")));
			}
		}

		/// <summary>
		/// Должность.
		/// </summary>
		public string JobTitle {
			get {
				return GetTypedColumnValue<string>("JobTitle");
			}
			set {
				SetColumnValue("JobTitle", value);
			}
		}

		/// <summary>
		/// Роль (строка).
		/// </summary>
		public string ContactDecisionRoleStr {
			get {
				return GetTypedColumnValue<string>("ContactDecisionRoleStr");
			}
			set {
				SetColumnValue("ContactDecisionRoleStr", value);
			}
		}

		/// <exclude/>
		public Guid ContactDecisionRoleId {
			get {
				return GetTypedColumnValue<Guid>("ContactDecisionRoleId");
			}
			set {
				SetColumnValue("ContactDecisionRoleId", value);
				_contactDecisionRole = null;
			}
		}

		/// <exclude/>
		public string ContactDecisionRoleName {
			get {
				return GetTypedColumnValue<string>("ContactDecisionRoleName");
			}
			set {
				SetColumnValue("ContactDecisionRoleName", value);
				if (_contactDecisionRole != null) {
					_contactDecisionRole.Name = value;
				}
			}
		}

		private ContactDecisionRole _contactDecisionRole;
		/// <summary>
		/// Роль.
		/// </summary>
		public ContactDecisionRole ContactDecisionRole {
			get {
				return _contactDecisionRole ??
					(_contactDecisionRole = new ContactDecisionRole(LookupColumnEntities.GetEntity("ContactDecisionRole")));
			}
		}

		/// <summary>
		/// Рабочий email.
		/// </summary>
		public string WorkEmail {
			get {
				return GetTypedColumnValue<string>("WorkEmail");
			}
			set {
				SetColumnValue("WorkEmail", value);
			}
		}

		/// <summary>
		/// Количество сотрудников (строка).
		/// </summary>
		public string AccountEmployeesNumberStr {
			get {
				return GetTypedColumnValue<string>("AccountEmployeesNumberStr");
			}
			set {
				SetColumnValue("AccountEmployeesNumberStr", value);
			}
		}

		/// <exclude/>
		public Guid AccountEmployeesNumberId {
			get {
				return GetTypedColumnValue<Guid>("AccountEmployeesNumberId");
			}
			set {
				SetColumnValue("AccountEmployeesNumberId", value);
				_accountEmployeesNumber = null;
			}
		}

		/// <exclude/>
		public string AccountEmployeesNumberName {
			get {
				return GetTypedColumnValue<string>("AccountEmployeesNumberName");
			}
			set {
				SetColumnValue("AccountEmployeesNumberName", value);
				if (_accountEmployeesNumber != null) {
					_accountEmployeesNumber.Name = value;
				}
			}
		}

		private AccountEmployeesNumber _accountEmployeesNumber;
		/// <summary>
		/// Количество сотрудников.
		/// </summary>
		public AccountEmployeesNumber AccountEmployeesNumber {
			get {
				return _accountEmployeesNumber ??
					(_accountEmployeesNumber = new AccountEmployeesNumber(LookupColumnEntities.GetEntity("AccountEmployeesNumber")));
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
		/// Website.
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
		public Guid TimeZoneId {
			get {
				return GetTypedColumnValue<Guid>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
				_timeZone = null;
			}
		}

		/// <exclude/>
		public string TimeZoneName {
			get {
				return GetTypedColumnValue<string>("TimeZoneName");
			}
			set {
				SetColumnValue("TimeZoneName", value);
				if (_timeZone != null) {
					_timeZone.Name = value;
				}
			}
		}

		private TimeZone _timeZone;
		/// <summary>
		/// Часовой пояс.
		/// </summary>
		public TimeZone TimeZone {
			get {
				return _timeZone ??
					(_timeZone = new TimeZone(LookupColumnEntities.GetEntity("TimeZone")));
			}
		}

		/// <exclude/>
		public Guid TerritoryId {
			get {
				return GetTypedColumnValue<Guid>("TerritoryId");
			}
			set {
				SetColumnValue("TerritoryId", value);
				_territory = null;
			}
		}

		/// <exclude/>
		public string TerritoryName {
			get {
				return GetTypedColumnValue<string>("TerritoryName");
			}
			set {
				SetColumnValue("TerritoryName", value);
				if (_territory != null) {
					_territory.Name = value;
				}
			}
		}

		private Territory _territory;
		/// <summary>
		/// Территория.
		/// </summary>
		public Territory Territory {
			get {
				return _territory ??
					(_territory = new Territory(LookupColumnEntities.GetEntity("Territory")));
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
		/// Дата рождения.
		/// </summary>
		public DateTime BirthDate {
			get {
				return GetTypedColumnValue<DateTime>("BirthDate");
			}
			set {
				SetColumnValue("BirthDate", value);
			}
		}

		/// <summary>
		/// Пароль.
		/// </summary>
		public string Password {
			get {
				return GetTypedColumnValue<string>("Password");
			}
			set {
				SetColumnValue("Password", value);
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

		private RegisterMethod _registerMethod;
		/// <summary>
		/// Способ регистрации.
		/// </summary>
		public RegisterMethod RegisterMethod {
			get {
				return _registerMethod ??
					(_registerMethod = new RegisterMethod(LookupColumnEntities.GetEntity("RegisterMethod")));
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

		/// <exclude/>
		public Guid SourceId {
			get {
				return GetTypedColumnValue<Guid>("SourceId");
			}
			set {
				SetColumnValue("SourceId", value);
				_source = null;
			}
		}

		/// <exclude/>
		public string SourceName {
			get {
				return GetTypedColumnValue<string>("SourceName");
			}
			set {
				SetColumnValue("SourceName", value);
				if (_source != null) {
					_source.Name = value;
				}
			}
		}

		private LeadSource _source;
		/// <summary>
		/// Источник.
		/// </summary>
		public LeadSource Source {
			get {
				return _source ??
					(_source = new LeadSource(LookupColumnEntities.GetEntity("Source")));
			}
		}

		/// <exclude/>
		public Guid ChannelId {
			get {
				return GetTypedColumnValue<Guid>("ChannelId");
			}
			set {
				SetColumnValue("ChannelId", value);
				_channel = null;
			}
		}

		/// <exclude/>
		public string ChannelName {
			get {
				return GetTypedColumnValue<string>("ChannelName");
			}
			set {
				SetColumnValue("ChannelName", value);
				if (_channel != null) {
					_channel.Name = value;
				}
			}
		}

		private LeadMedium _channel;
		/// <summary>
		/// Канал.
		/// </summary>
		public LeadMedium Channel {
			get {
				return _channel ??
					(_channel = new LeadMedium(LookupColumnEntities.GetEntity("Channel")));
			}
		}

		/// <summary>
		/// utm_campaign.
		/// </summary>
		public string UtmCampaignStr {
			get {
				return GetTypedColumnValue<string>("UtmCampaignStr");
			}
			set {
				SetColumnValue("UtmCampaignStr", value);
			}
		}

		/// <summary>
		/// utm_medium.
		/// </summary>
		public string UtmMediumStr {
			get {
				return GetTypedColumnValue<string>("UtmMediumStr");
			}
			set {
				SetColumnValue("UtmMediumStr", value);
			}
		}

		/// <summary>
		/// utm_source.
		/// </summary>
		public string UtmSourceStr {
			get {
				return GetTypedColumnValue<string>("UtmSourceStr");
			}
			set {
				SetColumnValue("UtmSourceStr", value);
			}
		}

		/// <summary>
		/// Сайт перехода.
		/// </summary>
		public string Referrer {
			get {
				return GetTypedColumnValue<string>("Referrer");
			}
			set {
				SetColumnValue("Referrer", value);
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
		public Guid WebFormDataId {
			get {
				return GetTypedColumnValue<Guid>("WebFormDataId");
			}
			set {
				SetColumnValue("WebFormDataId", value);
				_webFormData = null;
			}
		}

		private WebFormData _webFormData;
		/// <summary>
		/// Данные из веб-формы.
		/// </summary>
		public WebFormData WebFormData {
			get {
				return _webFormData ??
					(_webFormData = new WebFormData(LookupColumnEntities.GetEntity("WebFormData")));
			}
		}

		#endregion

	}

	#endregion

}

