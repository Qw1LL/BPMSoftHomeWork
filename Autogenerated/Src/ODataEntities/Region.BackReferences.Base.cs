namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Region

	/// <exclude/>
	public class Region : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Region(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Region";
		}

		public Region(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Region";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Account> AccountCollectionByRegion {
			get;
			set;
		}

		public IEnumerable<AccountAddress> AccountAddressCollectionByRegion {
			get;
			set;
		}

		public IEnumerable<City> CityCollectionByRegion {
			get;
			set;
		}

		public IEnumerable<ConfItem> ConfItemCollectionByRegion {
			get;
			set;
		}

		public IEnumerable<ConfItemAddress> ConfItemAddressCollectionByRegion {
			get;
			set;
		}

		public IEnumerable<Contact> ContactCollectionByRegion {
			get;
			set;
		}

		public IEnumerable<ContactAddress> ContactAddressCollectionByRegion {
			get;
			set;
		}

		public IEnumerable<Lead> LeadCollectionByRegion {
			get;
			set;
		}

		public IEnumerable<LeadAddress> LeadAddressCollectionByRegion {
			get;
			set;
		}

		public IEnumerable<LeadQualification> LeadQualificationCollectionByLeadAccountRegion {
			get;
			set;
		}

		public IEnumerable<LeadQualification> LeadQualificationCollectionByLeadContactRegion {
			get;
			set;
		}

		public IEnumerable<Touch> TouchCollectionByRegion {
			get;
			set;
		}

		public IEnumerable<VwClientAddress> VwClientAddressCollectionByRegion {
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
		/// Код региона.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

	}

	#endregion

}

