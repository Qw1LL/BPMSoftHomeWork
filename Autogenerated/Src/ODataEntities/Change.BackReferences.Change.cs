namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Change

	/// <exclude/>
	public class Change : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Change(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Change";
		}

		public Change(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Change";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByChange {
			get;
			set;
		}

		public IEnumerable<Case> CaseCollectionByChange {
			get;
			set;
		}

		public IEnumerable<Change> ChangeCollectionByParentChange {
			get;
			set;
		}

		public IEnumerable<ChangeConfItem> ChangeConfItemCollectionByChange {
			get;
			set;
		}

		public IEnumerable<ChangeFile> ChangeFileCollectionByChange {
			get;
			set;
		}

		public IEnumerable<ChangeInFolder> ChangeInFolderCollectionByChange {
			get;
			set;
		}

		public IEnumerable<ChangeInTag> ChangeInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<ChangeServiceItem> ChangeServiceItemCollectionByChange {
			get;
			set;
		}

		public IEnumerable<Problem> ProblemCollectionByChange {
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
		/// Тема.
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
		public Guid AuthorId {
			get {
				return GetTypedColumnValue<Guid>("AuthorId");
			}
			set {
				SetColumnValue("AuthorId", value);
				_author = null;
			}
		}

		/// <exclude/>
		public string AuthorName {
			get {
				return GetTypedColumnValue<string>("AuthorName");
			}
			set {
				SetColumnValue("AuthorName", value);
				if (_author != null) {
					_author.Name = value;
				}
			}
		}

		private Contact _author;
		/// <summary>
		/// Автор.
		/// </summary>
		public Contact Author {
			get {
				return _author ??
					(_author = new Contact(LookupColumnEntities.GetEntity("Author")));
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
		/// Дата регистрации.
		/// </summary>
		public DateTime RegisteredOn {
			get {
				return GetTypedColumnValue<DateTime>("RegisteredOn");
			}
			set {
				SetColumnValue("RegisteredOn", value);
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

		/// <summary>
		/// План. завершение.
		/// </summary>
		public DateTime ScheduledClosureDate {
			get {
				return GetTypedColumnValue<DateTime>("ScheduledClosureDate");
			}
			set {
				SetColumnValue("ScheduledClosureDate", value);
			}
		}

		/// <summary>
		/// Факт. завершение.
		/// </summary>
		public DateTime ClosureDate {
			get {
				return GetTypedColumnValue<DateTime>("ClosureDate");
			}
			set {
				SetColumnValue("ClosureDate", value);
			}
		}

		/// <summary>
		/// План. трудозатраты (часов).
		/// </summary>
		public int PlannedLabor {
			get {
				return GetTypedColumnValue<int>("PlannedLabor");
			}
			set {
				SetColumnValue("PlannedLabor", value);
			}
		}

		/// <summary>
		/// Факт. трудозатраты (часов).
		/// </summary>
		public int ActualLabor {
			get {
				return GetTypedColumnValue<int>("ActualLabor");
			}
			set {
				SetColumnValue("ActualLabor", value);
			}
		}

		/// <exclude/>
		public Guid ParentChangeId {
			get {
				return GetTypedColumnValue<Guid>("ParentChangeId");
			}
			set {
				SetColumnValue("ParentChangeId", value);
				_parentChange = null;
			}
		}

		/// <exclude/>
		public string ParentChangeNumber {
			get {
				return GetTypedColumnValue<string>("ParentChangeNumber");
			}
			set {
				SetColumnValue("ParentChangeNumber", value);
				if (_parentChange != null) {
					_parentChange.Number = value;
				}
			}
		}

		private Change _parentChange;
		/// <summary>
		/// Родительское изменение.
		/// </summary>
		public Change ParentChange {
			get {
				return _parentChange ??
					(_parentChange = new Change(LookupColumnEntities.GetEntity("ParentChange")));
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

		private ChangeSource _source;
		/// <summary>
		/// Источник.
		/// </summary>
		public ChangeSource Source {
			get {
				return _source ??
					(_source = new ChangeSource(LookupColumnEntities.GetEntity("Source")));
			}
		}

		/// <exclude/>
		public Guid PurposeId {
			get {
				return GetTypedColumnValue<Guid>("PurposeId");
			}
			set {
				SetColumnValue("PurposeId", value);
				_purpose = null;
			}
		}

		/// <exclude/>
		public string PurposeName {
			get {
				return GetTypedColumnValue<string>("PurposeName");
			}
			set {
				SetColumnValue("PurposeName", value);
				if (_purpose != null) {
					_purpose.Name = value;
				}
			}
		}

		private ChangePurpose _purpose;
		/// <summary>
		/// Цель.
		/// </summary>
		public ChangePurpose Purpose {
			get {
				return _purpose ??
					(_purpose = new ChangePurpose(LookupColumnEntities.GetEntity("Purpose")));
			}
		}

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private ChangeCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public ChangeCategory Category {
			get {
				return _category ??
					(_category = new ChangeCategory(LookupColumnEntities.GetEntity("Category")));
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

		private ChangePriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public ChangePriority Priority {
			get {
				return _priority ??
					(_priority = new ChangePriority(LookupColumnEntities.GetEntity("Priority")));
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

		private ChangeStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public ChangeStatus Status {
			get {
				return _status ??
					(_status = new ChangeStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		/// <summary>
		/// Примечание.
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
		public Guid ReleaseId {
			get {
				return GetTypedColumnValue<Guid>("ReleaseId");
			}
			set {
				SetColumnValue("ReleaseId", value);
				_release = null;
			}
		}

		/// <exclude/>
		public string ReleaseNumber {
			get {
				return GetTypedColumnValue<string>("ReleaseNumber");
			}
			set {
				SetColumnValue("ReleaseNumber", value);
				if (_release != null) {
					_release.Number = value;
				}
			}
		}

		private Release _release;
		/// <summary>
		/// Релиз.
		/// </summary>
		public Release Release {
			get {
				return _release ??
					(_release = new Release(LookupColumnEntities.GetEntity("Release")));
			}
		}

		#endregion

	}

	#endregion

}

