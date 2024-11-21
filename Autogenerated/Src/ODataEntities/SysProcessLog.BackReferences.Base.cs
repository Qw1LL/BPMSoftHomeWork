namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysProcessLog

	/// <exclude/>
	public class SysProcessLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysProcessLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessLog";
		}

		public SysProcessLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysProcessLog";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysProcessElementLog> SysProcessElementLogCollectionBySysProcess {
			get;
			set;
		}

		public IEnumerable<SysProcessEntity> SysProcessEntityCollectionBySysProcess {
			get;
			set;
		}

		public IEnumerable<SysProcessLog> SysProcessLogCollectionByParent {
			get;
			set;
		}

		public IEnumerable<SysProcessLogInFolder> SysProcessLogInFolderCollectionBySysProcessLog {
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
		public DateTime CompleteDate {
			get {
				return GetTypedColumnValue<DateTime>("CompleteDate");
			}
			set {
				SetColumnValue("CompleteDate", value);
			}
		}

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Процесс.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = new SysSchema(LookupColumnEntities.GetEntity("SysSchema")));
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

		private SysProcessLog _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public SysProcessLog Parent {
			get {
				return _parent ??
					(_parent = new SysProcessLog(LookupColumnEntities.GetEntity("Parent")));
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

		private SysProcessStatus _status;
		/// <summary>
		/// Состояние процесса.
		/// </summary>
		public SysProcessStatus Status {
			get {
				return _status ??
					(_status = new SysProcessStatus(LookupColumnEntities.GetEntity("Status")));
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
		public Guid SysWorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("SysWorkspaceId");
			}
			set {
				SetColumnValue("SysWorkspaceId", value);
				_sysWorkspace = null;
			}
		}

		/// <exclude/>
		public string SysWorkspaceName {
			get {
				return GetTypedColumnValue<string>("SysWorkspaceName");
			}
			set {
				SetColumnValue("SysWorkspaceName", value);
				if (_sysWorkspace != null) {
					_sysWorkspace.Name = value;
				}
			}
		}

		private SysWorkspace _sysWorkspace;
		/// <summary>
		/// Рабочее пространство.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = new SysWorkspace(LookupColumnEntities.GetEntity("SysWorkspace")));
			}
		}

		/// <summary>
		/// Длительность, минут.
		/// </summary>
		public Decimal DurationInMinutes {
			get {
				return GetTypedColumnValue<Decimal>("DurationInMinutes");
			}
			set {
				SetColumnValue("DurationInMinutes", value);
			}
		}

		/// <summary>
		/// Длительность, дней.
		/// </summary>
		public Decimal DurationInDays {
			get {
				return GetTypedColumnValue<Decimal>("DurationInDays");
			}
			set {
				SetColumnValue("DurationInDays", value);
			}
		}

		/// <summary>
		/// Длительность, часов.
		/// </summary>
		public Decimal DurationInHours {
			get {
				return GetTypedColumnValue<Decimal>("DurationInHours");
			}
			set {
				SetColumnValue("DurationInHours", value);
			}
		}

		/// <summary>
		/// Пакет.
		/// </summary>
		public string PackageName {
			get {
				return GetTypedColumnValue<string>("PackageName");
			}
			set {
				SetColumnValue("PackageName", value);
			}
		}

		/// <summary>
		/// Версия.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		/// <summary>
		/// Длительность, миллисекунд.
		/// </summary>
		public Decimal DurationInMilliseconds {
			get {
				return GetTypedColumnValue<Decimal>("DurationInMilliseconds");
			}
			set {
				SetColumnValue("DurationInMilliseconds", value);
			}
		}

		/// <summary>
		/// Описание ошибки.
		/// </summary>
		public string ErrorDescription {
			get {
				return GetTypedColumnValue<string>("ErrorDescription");
			}
			set {
				SetColumnValue("ErrorDescription", value);
			}
		}

		#endregion

	}

	#endregion

}

