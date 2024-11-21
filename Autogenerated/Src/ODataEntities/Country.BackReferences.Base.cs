namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Country

	/// <exclude/>
	public class Country : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Country(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Country";
		}

		public Country(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Country";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Account> AccountCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<AccountAddress> AccountAddressCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<AccountBillingInfo> AccountBillingInfoCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<AccountOwnership> AccountOwnershipCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<City> CityCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<ConfItem> ConfItemCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<ConfItemAddress> ConfItemAddressCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<Contact> ContactCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<ContactAddress> ContactAddressCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<DialingCode> DialingCodeCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<FormSubmit> FormSubmitCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<Lead> LeadCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<LeadAddress> LeadAddressCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<LeadQualification> LeadQualificationCollectionByLeadAccountCountry {
			get;
			set;
		}

		public IEnumerable<LeadQualification> LeadQualificationCollectionByLeadContactCountry {
			get;
			set;
		}

		public IEnumerable<Region> RegionCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<Touch> TouchCollectionByCountry {
			get;
			set;
		}

		public IEnumerable<VwClientAddress> VwClientAddressCollectionByCountry {
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

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Платежные реквизиты.
		/// </summary>
		public string BillingInfo {
			get {
				return GetTypedColumnValue<string>("BillingInfo");
			}
			set {
				SetColumnValue("BillingInfo", value);
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

		/// <summary>
		/// Код страны.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Двухбуквенный код страны.
		/// </summary>
		/// <remarks>
		/// ISO 3166-1 alpha-2.
		/// </remarks>
		public string Alpha2Code {
			get {
				return GetTypedColumnValue<string>("Alpha2Code");
			}
			set {
				SetColumnValue("Alpha2Code", value);
			}
		}

		#endregion

	}

	#endregion

}

