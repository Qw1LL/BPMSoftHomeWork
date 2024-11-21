namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CaseLifecycle

	/// <exclude/>
	public class CaseLifecycle : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CaseLifecycle(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseLifecycle";
		}

		public CaseLifecycle(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CaseLifecycle";
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
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = new Case(LookupColumnEntities.GetEntity("Case")));
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

		private CaseStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public CaseStatus Status {
			get {
				return _status ??
					(_status = new CaseStatus(LookupColumnEntities.GetEntity("Status")));
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
		/// Дата завершения.
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
		public Guid PriorityId {
			get {
				return GetTypedColumnValue<Guid>("PriorityId");
			}
			set {
				SetColumnValue("PriorityId", value);
				_priority = null;
			}
		}

		/// <exclude/>
		public string PriorityName {
			get {
				return GetTypedColumnValue<string>("PriorityName");
			}
			set {
				SetColumnValue("PriorityName", value);
				if (_priority != null) {
					_priority.Name = value;
				}
			}
		}

		private CasePriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public CasePriority Priority {
			get {
				return _priority ??
					(_priority = new CasePriority(LookupColumnEntities.GetEntity("Priority")));
			}
		}

		/// <exclude/>
		public Guid ServiceItemId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemId");
			}
			set {
				SetColumnValue("ServiceItemId", value);
				_serviceItem = null;
			}
		}

		/// <exclude/>
		public string ServiceItemName {
			get {
				return GetTypedColumnValue<string>("ServiceItemName");
			}
			set {
				SetColumnValue("ServiceItemName", value);
				if (_serviceItem != null) {
					_serviceItem.Name = value;
				}
			}
		}

		private ServiceItem _serviceItem;
		/// <summary>
		/// Сервис.
		/// </summary>
		public ServiceItem ServiceItem {
			get {
				return _serviceItem ??
					(_serviceItem = new ServiceItem(LookupColumnEntities.GetEntity("ServiceItem")));
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
		/// Просрочен по реакции.
		/// </summary>
		public bool ResponseOverdue {
			get {
				return GetTypedColumnValue<bool>("ResponseOverdue");
			}
			set {
				SetColumnValue("ResponseOverdue", value);
			}
		}

		/// <summary>
		/// Просрочен по разрешению.
		/// </summary>
		public bool SolutionOverdue {
			get {
				return GetTypedColumnValue<bool>("SolutionOverdue");
			}
			set {
				SetColumnValue("SolutionOverdue", value);
			}
		}

		/// <exclude/>
		public Guid GroupId {
			get {
				return GetTypedColumnValue<Guid>("GroupId");
			}
			set {
				SetColumnValue("GroupId", value);
				_group = null;
			}
		}

		/// <exclude/>
		public string GroupName {
			get {
				return GetTypedColumnValue<string>("GroupName");
			}
			set {
				SetColumnValue("GroupName", value);
				if (_group != null) {
					_group.Name = value;
				}
			}
		}

		private SysAdminUnit _group;
		/// <summary>
		/// Группа ответственных.
		/// </summary>
		public SysAdminUnit Group {
			get {
				return _group ??
					(_group = new SysAdminUnit(LookupColumnEntities.GetEntity("Group")));
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

		private RoleInServiceTeam _supportLevel;
		/// <summary>
		/// Уровень поддержки.
		/// </summary>
		public RoleInServiceTeam SupportLevel {
			get {
				return _supportLevel ??
					(_supportLevel = new RoleInServiceTeam(LookupColumnEntities.GetEntity("SupportLevel")));
			}
		}

		/// <summary>
		/// Продолжительность (минут).
		/// </summary>
		public int StateDurationInMinutes {
			get {
				return GetTypedColumnValue<int>("StateDurationInMinutes");
			}
			set {
				SetColumnValue("StateDurationInMinutes", value);
			}
		}

		/// <summary>
		/// Продолжительность (часов).
		/// </summary>
		public Decimal StateDurationInHours {
			get {
				return GetTypedColumnValue<Decimal>("StateDurationInHours");
			}
			set {
				SetColumnValue("StateDurationInHours", value);
			}
		}

		/// <summary>
		/// Продолжительность (дней).
		/// </summary>
		public Decimal StateDurationInDays {
			get {
				return GetTypedColumnValue<Decimal>("StateDurationInDays");
			}
			set {
				SetColumnValue("StateDurationInDays", value);
			}
		}

		/// <summary>
		/// Фактическое разрешение.
		/// </summary>
		public DateTime SolutionProvidedOn {
			get {
				return GetTypedColumnValue<DateTime>("SolutionProvidedOn");
			}
			set {
				SetColumnValue("SolutionProvidedOn", value);
			}
		}

		/// <summary>
		/// Время разрешения.
		/// </summary>
		public DateTime SolutionDate {
			get {
				return GetTypedColumnValue<DateTime>("SolutionDate");
			}
			set {
				SetColumnValue("SolutionDate", value);
			}
		}

		/// <summary>
		/// Идентификатор обращения.
		/// </summary>
		public Guid CaseRecordId {
			get {
				return GetTypedColumnValue<Guid>("CaseRecordId");
			}
			set {
				SetColumnValue("CaseRecordId", value);
			}
		}

		#endregion

	}

	#endregion

}

