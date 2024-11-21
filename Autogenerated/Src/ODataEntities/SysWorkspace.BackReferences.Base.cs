namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysWorkspace

	/// <exclude/>
	public class SysWorkspace : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysWorkspace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysWorkspace";
		}

		public SysWorkspace(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysWorkspace";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysPackage> SysPackageCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<SysPackageHierarchy> SysPackageHierarchyCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<SysPrcHistoryLog> SysPrcHistoryLogCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<SysProcessLog> SysProcessLogCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwAdministrativeObjects> VwAdministrativeObjectsCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwLogObjects> VwLogObjectsCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwProcessLib> VwProcessLibCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysClientUnitSchema> VwSysClientUnitSchemaCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysClientUnitSchemaInPackage> VwSysClientUnitSchemaInPackageCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysDcmLib> VwSysDcmLibCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysEntitySchemaInPackage> VwSysEntitySchemaInPackageCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysEntitySchemaInWorkspace> VwSysEntitySchemaInWorkspaceCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysLookup> VwSysLookupCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysModuleEdit> VwSysModuleEditCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysModuleEntity> VwSysModuleEntityCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysModuleEntityForEdit> VwSysModuleEntityForEditCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysPageSchemaInWorkspace> VwSysPageSchemaInWorkspaceCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysProcess> VwSysProcessCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysProcessEntity> VwSysProcessEntityCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysProcessLog> VwSysProcessLogCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysProcessMILog> VwSysProcessMILogCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaInfo> VwSysSchemaInfoCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaInfoForLookups> VwSysSchemaInfoForLookupsCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaInPackage> VwSysSchemaInPackageCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaInWorkspace> VwSysSchemaInWorkspaceCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwSysSqlScriptInPackage> VwSysSqlScriptInPackageCollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwWebServiceV2> VwWebServiceV2CollectionBySysWorkspace {
			get;
			set;
		}

		public IEnumerable<VwWorkspaceObjects> VwWorkspaceObjectsCollectionBySysWorkspace {
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
		/// По умолчанию.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
			}
		}

		/// <summary>
		/// Номер.
		/// </summary>
		public int Number {
			get {
				return GetTypedColumnValue<int>("Number");
			}
			set {
				SetColumnValue("Number", value);
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
		/// Uri репозитория.
		/// </summary>
		public string RepositoryUri {
			get {
				return GetTypedColumnValue<string>("RepositoryUri");
			}
			set {
				SetColumnValue("RepositoryUri", value);
			}
		}

		/// <summary>
		/// Путь к рабочей копии.
		/// </summary>
		public string WorkingCopyPath {
			get {
				return GetTypedColumnValue<string>("WorkingCopyPath");
			}
			set {
				SetColumnValue("WorkingCopyPath", value);
			}
		}

		/// <summary>
		/// Текущий номер ревизии репозитория.
		/// </summary>
		public int RepositoryRevisionNumber {
			get {
				return GetTypedColumnValue<int>("RepositoryRevisionNumber");
			}
			set {
				SetColumnValue("RepositoryRevisionNumber", value);
			}
		}

		/// <exclude/>
		public Guid BuildODataStartedById {
			get {
				return GetTypedColumnValue<Guid>("BuildODataStartedById");
			}
			set {
				SetColumnValue("BuildODataStartedById", value);
				_buildODataStartedBy = null;
			}
		}

		/// <exclude/>
		public string BuildODataStartedByName {
			get {
				return GetTypedColumnValue<string>("BuildODataStartedByName");
			}
			set {
				SetColumnValue("BuildODataStartedByName", value);
				if (_buildODataStartedBy != null) {
					_buildODataStartedBy.Name = value;
				}
			}
		}

		private Contact _buildODataStartedBy;
		/// <summary>
		/// Пользователь, инициировавший компиляцию моделей OData.
		/// </summary>
		public Contact BuildODataStartedBy {
			get {
				return _buildODataStartedBy ??
					(_buildODataStartedBy = new Contact(LookupColumnEntities.GetEntity("BuildODataStartedBy")));
			}
		}

		#endregion

	}

	#endregion

}

