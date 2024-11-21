namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Touch

	/// <exclude/>
	public class Touch : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Touch(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Touch";
		}

		public Touch(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Touch";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<TouchAction> TouchActionCollectionByTouch {
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
		/// Created on.
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
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
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
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Active processes.
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
		/// City.
		/// </summary>
		public City City {
			get {
				return _city ??
					(_city = new City(LookupColumnEntities.GetEntity("City")));
			}
		}

		/// <summary>
		/// Page referrer URL.
		/// </summary>
		/// <remarks>
		/// URL of the previous webpage from which a link was followed.
		/// </remarks>
		public string PageReferrer {
			get {
				return GetTypedColumnValue<string>("PageReferrer");
			}
			set {
				SetColumnValue("PageReferrer", value);
			}
		}

		/// <summary>
		/// Web session duration, seconds.
		/// </summary>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		/// <summary>
		/// Domain.
		/// </summary>
		public string Domain {
			get {
				return GetTypedColumnValue<string>("Domain");
			}
			set {
				SetColumnValue("Domain", value);
			}
		}

		/// <exclude/>
		public Guid LanguageId {
			get {
				return GetTypedColumnValue<Guid>("LanguageId");
			}
			set {
				SetColumnValue("LanguageId", value);
				_language = null;
			}
		}

		/// <exclude/>
		public string LanguageName {
			get {
				return GetTypedColumnValue<string>("LanguageName");
			}
			set {
				SetColumnValue("LanguageName", value);
				if (_language != null) {
					_language.Name = value;
				}
			}
		}

		private SysLanguage _language;
		/// <summary>
		/// Language.
		/// </summary>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = new SysLanguage(LookupColumnEntities.GetEntity("Language")));
			}
		}

		/// <summary>
		/// IP address.
		/// </summary>
		public string IP {
			get {
				return GetTypedColumnValue<string>("IP");
			}
			set {
				SetColumnValue("IP", value);
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
		/// Country.
		/// </summary>
		public Country Country {
			get {
				return _country ??
					(_country = new Country(LookupColumnEntities.GetEntity("Country")));
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
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <summary>
		/// utm_term.
		/// </summary>
		/// <remarks>
		/// Identifies search terms.
		/// </remarks>
		public string UtmTermStr {
			get {
				return GetTypedColumnValue<string>("UtmTermStr");
			}
			set {
				SetColumnValue("UtmTermStr", value);
			}
		}

		/// <summary>
		/// utm_source.
		/// </summary>
		/// <remarks>
		/// Identifies which site sent the traffic, and is a required parameter.
		/// </remarks>
		public string UtmSourceStr {
			get {
				return GetTypedColumnValue<string>("UtmSourceStr");
			}
			set {
				SetColumnValue("UtmSourceStr", value);
			}
		}

		/// <summary>
		/// utm_medium.
		/// </summary>
		/// <remarks>
		/// Identifies what type of link was used, such as cost per click or email.
		/// </remarks>
		public string UtmMediumStr {
			get {
				return GetTypedColumnValue<string>("UtmMediumStr");
			}
			set {
				SetColumnValue("UtmMediumStr", value);
			}
		}

		/// <summary>
		/// utm_content.
		/// </summary>
		/// <remarks>
		/// Identifies what specifically was clicked to bring the user to the site, such as a banner ad or a text link. It is often used for A/B testing and content-targeted ads.
		/// </remarks>
		public string UtmContentStr {
			get {
				return GetTypedColumnValue<string>("UtmContentStr");
			}
			set {
				SetColumnValue("UtmContentStr", value);
			}
		}

		/// <summary>
		/// utm_campaign.
		/// </summary>
		/// <remarks>
		/// Identifies a specific product promotion or strategic campaign.
		/// </remarks>
		public string UtmCampaignStr {
			get {
				return GetTypedColumnValue<string>("UtmCampaignStr");
			}
			set {
				SetColumnValue("UtmCampaignStr", value);
			}
		}

		/// <exclude/>
		public Guid PlatformId {
			get {
				return GetTypedColumnValue<Guid>("PlatformId");
			}
			set {
				SetColumnValue("PlatformId", value);
				_platform = null;
			}
		}

		/// <exclude/>
		public string PlatformName {
			get {
				return GetTypedColumnValue<string>("PlatformName");
			}
			set {
				SetColumnValue("PlatformName", value);
				if (_platform != null) {
					_platform.Name = value;
				}
			}
		}

		private TouchPlatform _platform;
		/// <summary>
		/// Platform.
		/// </summary>
		public TouchPlatform Platform {
			get {
				return _platform ??
					(_platform = new TouchPlatform(LookupColumnEntities.GetEntity("Platform")));
			}
		}

		/// <exclude/>
		public Guid DeviceId {
			get {
				return GetTypedColumnValue<Guid>("DeviceId");
			}
			set {
				SetColumnValue("DeviceId", value);
				_device = null;
			}
		}

		/// <exclude/>
		public string DeviceName {
			get {
				return GetTypedColumnValue<string>("DeviceName");
			}
			set {
				SetColumnValue("DeviceName", value);
				if (_device != null) {
					_device.Name = value;
				}
			}
		}

		private TouchDevice _device;
		/// <summary>
		/// Device.
		/// </summary>
		public TouchDevice Device {
			get {
				return _device ??
					(_device = new TouchDevice(LookupColumnEntities.GetEntity("Device")));
			}
		}

		/// <summary>
		/// Session.
		/// </summary>
		public string SessionId {
			get {
				return GetTypedColumnValue<string>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// Platform (string).
		/// </summary>
		public string PlatformStr {
			get {
				return GetTypedColumnValue<string>("PlatformStr");
			}
			set {
				SetColumnValue("PlatformStr", value);
			}
		}

		/// <summary>
		/// Language (string).
		/// </summary>
		public string LanguageStr {
			get {
				return GetTypedColumnValue<string>("LanguageStr");
			}
			set {
				SetColumnValue("LanguageStr", value);
			}
		}

		/// <summary>
		/// Device (string).
		/// </summary>
		public string DeviceStr {
			get {
				return GetTypedColumnValue<string>("DeviceStr");
			}
			set {
				SetColumnValue("DeviceStr", value);
			}
		}

		/// <summary>
		/// Country (string).
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
		/// City (string).
		/// </summary>
		public string CityStr {
			get {
				return GetTypedColumnValue<string>("CityStr");
			}
			set {
				SetColumnValue("CityStr", value);
			}
		}

		/// <summary>
		/// Session start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Country code.
		/// </summary>
		public string CountryCode {
			get {
				return GetTypedColumnValue<string>("CountryCode");
			}
			set {
				SetColumnValue("CountryCode", value);
			}
		}

		/// <summary>
		/// Region code.
		/// </summary>
		public string RegionCode {
			get {
				return GetTypedColumnValue<string>("RegionCode");
			}
			set {
				SetColumnValue("RegionCode", value);
			}
		}

		/// <summary>
		/// Region (string).
		/// </summary>
		public string RegionStr {
			get {
				return GetTypedColumnValue<string>("RegionStr");
			}
			set {
				SetColumnValue("RegionStr", value);
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
		/// Region.
		/// </summary>
		public Region Region {
			get {
				return _region ??
					(_region = new Region(LookupColumnEntities.GetEntity("Region")));
			}
		}

		/// <summary>
		/// Location.
		/// </summary>
		public string Location {
			get {
				return GetTypedColumnValue<string>("Location");
			}
			set {
				SetColumnValue("Location", value);
			}
		}

		/// <summary>
		/// Referrer type (string).
		/// </summary>
		public string ReferrerTypeStr {
			get {
				return GetTypedColumnValue<string>("ReferrerTypeStr");
			}
			set {
				SetColumnValue("ReferrerTypeStr", value);
			}
		}

		/// <summary>
		/// Referrer name (string).
		/// </summary>
		public string ReferrerNameStr {
			get {
				return GetTypedColumnValue<string>("ReferrerNameStr");
			}
			set {
				SetColumnValue("ReferrerNameStr", value);
			}
		}

		/// <summary>
		/// Referrer keyword.
		/// </summary>
		public string ReferrerKeyword {
			get {
				return GetTypedColumnValue<string>("ReferrerKeyword");
			}
			set {
				SetColumnValue("ReferrerKeyword", value);
			}
		}

		/// <summary>
		/// Referrer URL.
		/// </summary>
		public string ReferrerUrl {
			get {
				return GetTypedColumnValue<string>("ReferrerUrl");
			}
			set {
				SetColumnValue("ReferrerUrl", value);
			}
		}

		/// <exclude/>
		public Guid ReferrerTypeId {
			get {
				return GetTypedColumnValue<Guid>("ReferrerTypeId");
			}
			set {
				SetColumnValue("ReferrerTypeId", value);
				_referrerType = null;
			}
		}

		/// <exclude/>
		public string ReferrerTypeName {
			get {
				return GetTypedColumnValue<string>("ReferrerTypeName");
			}
			set {
				SetColumnValue("ReferrerTypeName", value);
				if (_referrerType != null) {
					_referrerType.Name = value;
				}
			}
		}

		private ReferrerType _referrerType;
		/// <summary>
		/// Referrer type.
		/// </summary>
		public ReferrerType ReferrerType {
			get {
				return _referrerType ??
					(_referrerType = new ReferrerType(LookupColumnEntities.GetEntity("ReferrerType")));
			}
		}

		/// <exclude/>
		public Guid ReferrerNameId {
			get {
				return GetTypedColumnValue<Guid>("ReferrerNameId");
			}
			set {
				SetColumnValue("ReferrerNameId", value);
				_referrerName = null;
			}
		}

		/// <exclude/>
		public string ReferrerNameName {
			get {
				return GetTypedColumnValue<string>("ReferrerNameName");
			}
			set {
				SetColumnValue("ReferrerNameName", value);
				if (_referrerName != null) {
					_referrerName.Name = value;
				}
			}
		}

		private ReferrerName _referrerName;
		/// <summary>
		/// Referrer name.
		/// </summary>
		public ReferrerName ReferrerName {
			get {
				return _referrerName ??
					(_referrerName = new ReferrerName(LookupColumnEntities.GetEntity("ReferrerName")));
			}
		}

		/// <summary>
		/// utm_id.
		/// </summary>
		public string UtmIdStr {
			get {
				return GetTypedColumnValue<string>("UtmIdStr");
			}
			set {
				SetColumnValue("UtmIdStr", value);
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
		/// Source.
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
		/// Channel.
		/// </summary>
		public LeadMedium Channel {
			get {
				return _channel ??
					(_channel = new LeadMedium(LookupColumnEntities.GetEntity("Channel")));
			}
		}

		/// <summary>
		/// Notes.
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
		/// No. of employees (range).
		/// </summary>
		public string AccountEmployeesNumber {
			get {
				return GetTypedColumnValue<string>("AccountEmployeesNumber");
			}
			set {
				SetColumnValue("AccountEmployeesNumber", value);
			}
		}

		/// <summary>
		/// Exact number of employees.
		/// </summary>
		public string AccountExactNoOfEmployees {
			get {
				return GetTypedColumnValue<string>("AccountExactNoOfEmployees");
			}
			set {
				SetColumnValue("AccountExactNoOfEmployees", value);
			}
		}

		/// <summary>
		/// Facebook profile.
		/// </summary>
		public string FacebookProfileUrl {
			get {
				return GetTypedColumnValue<string>("FacebookProfileUrl");
			}
			set {
				SetColumnValue("FacebookProfileUrl", value);
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

		/// <summary>
		/// LinkedIn profile.
		/// </summary>
		public string LinkedInProfileUrl {
			get {
				return GetTypedColumnValue<string>("LinkedInProfileUrl");
			}
			set {
				SetColumnValue("LinkedInProfileUrl", value);
			}
		}

		/// <summary>
		/// SubIndustry.
		/// </summary>
		public string SubIndustry {
			get {
				return GetTypedColumnValue<string>("SubIndustry");
			}
			set {
				SetColumnValue("SubIndustry", value);
			}
		}

		/// <summary>
		/// Industry.
		/// </summary>
		public string Industry {
			get {
				return GetTypedColumnValue<string>("Industry");
			}
			set {
				SetColumnValue("Industry", value);
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
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
			}
		}

		/// <summary>
		/// Account name.
		/// </summary>
		public string AccountNameText {
			get {
				return GetTypedColumnValue<string>("AccountNameText");
			}
			set {
				SetColumnValue("AccountNameText", value);
			}
		}

		#endregion

	}

	#endregion

}

