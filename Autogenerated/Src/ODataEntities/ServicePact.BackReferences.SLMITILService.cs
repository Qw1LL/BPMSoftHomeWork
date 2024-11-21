namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ServicePact

	/// <exclude/>
	public class ServicePact : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ServicePact(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServicePact";
		}

		public ServicePact(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ServicePact";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Case> CaseCollectionByServicePact {
			get;
			set;
		}

		public IEnumerable<ServiceInServicePact> ServiceInServicePactCollectionByServicePact {
			get;
			set;
		}

		public IEnumerable<ServiceObject> ServiceObjectCollectionByServicePact {
			get;
			set;
		}

		public IEnumerable<ServicePactFile> ServicePactFileCollectionByServicePact {
			get;
			set;
		}

		public IEnumerable<ServicePactInFolder> ServicePactInFolderCollectionByServicePact {
			get;
			set;
		}

		public IEnumerable<ServicePactInTag> ServicePactInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<VwServiceRecepients> VwServiceRecepientsCollectionByServicePact {
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
		/// Заголовок.
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

		private ServicePactStatus _status;
		/// <summary>
		/// Статус.
		/// </summary>
		public ServicePactStatus Status {
			get {
				return _status ??
					(_status = new ServicePactStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		/// <summary>
		/// Дата начала.
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
		/// Дата окончания.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
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
		/// Создатель.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
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

		private ServicePactType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ServicePactType Type {
			get {
				return _type ??
					(_type = new ServicePactType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <summary>
		/// Номер.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <exclude/>
		public Guid ServiceProviderId {
			get {
				return GetTypedColumnValue<Guid>("ServiceProviderId");
			}
			set {
				SetColumnValue("ServiceProviderId", value);
				_serviceProvider = null;
			}
		}

		/// <exclude/>
		public string ServiceProviderName {
			get {
				return GetTypedColumnValue<string>("ServiceProviderName");
			}
			set {
				SetColumnValue("ServiceProviderName", value);
				if (_serviceProvider != null) {
					_serviceProvider.Name = value;
				}
			}
		}

		private Account _serviceProvider;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account ServiceProvider {
			get {
				return _serviceProvider ??
					(_serviceProvider = new Account(LookupColumnEntities.GetEntity("ServiceProvider")));
			}
		}

		/// <exclude/>
		public Guid ServiceProviderContactId {
			get {
				return GetTypedColumnValue<Guid>("ServiceProviderContactId");
			}
			set {
				SetColumnValue("ServiceProviderContactId", value);
				_serviceProviderContact = null;
			}
		}

		/// <exclude/>
		public string ServiceProviderContactName {
			get {
				return GetTypedColumnValue<string>("ServiceProviderContactName");
			}
			set {
				SetColumnValue("ServiceProviderContactName", value);
				if (_serviceProviderContact != null) {
					_serviceProviderContact.Name = value;
				}
			}
		}

		private Contact _serviceProviderContact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact ServiceProviderContact {
			get {
				return _serviceProviderContact ??
					(_serviceProviderContact = new Contact(LookupColumnEntities.GetEntity("ServiceProviderContact")));
			}
		}

		/// <summary>
		/// Примечания.
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
		public Guid CalendarId {
			get {
				return GetTypedColumnValue<Guid>("CalendarId");
			}
			set {
				SetColumnValue("CalendarId", value);
				_calendar = null;
			}
		}

		/// <exclude/>
		public string CalendarName {
			get {
				return GetTypedColumnValue<string>("CalendarName");
			}
			set {
				SetColumnValue("CalendarName", value);
				if (_calendar != null) {
					_calendar.Name = value;
				}
			}
		}

		private Calendar _calendar;
		/// <summary>
		/// Календарь.
		/// </summary>
		public Calendar Calendar {
			get {
				return _calendar ??
					(_calendar = new Calendar(LookupColumnEntities.GetEntity("Calendar")));
			}
		}

		/// <exclude/>
		public Guid SupportLevelId {
			get {
				return GetTypedColumnValue<Guid>("SupportLevelId");
			}
			set {
				SetColumnValue("SupportLevelId", value);
				_supportLevel = null;
			}
		}

		/// <exclude/>
		public string SupportLevelName {
			get {
				return GetTypedColumnValue<string>("SupportLevelName");
			}
			set {
				SetColumnValue("SupportLevelName", value);
				if (_supportLevel != null) {
					_supportLevel.Name = value;
				}
			}
		}

		private SupportLevel _supportLevel;
		/// <summary>
		/// Уровень поддержки.
		/// </summary>
		public SupportLevel SupportLevel {
			get {
				return _supportLevel ??
					(_supportLevel = new SupportLevel(LookupColumnEntities.GetEntity("SupportLevel")));
			}
		}

		#endregion

	}

	#endregion

}

