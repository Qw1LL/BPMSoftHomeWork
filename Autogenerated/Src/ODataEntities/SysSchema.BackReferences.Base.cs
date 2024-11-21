namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysSchema

	/// <exclude/>
	public class SysSchema : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSchema";
		}

		public SysSchema(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysSchema";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AppBuild> AppBuildCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<Attribute> AttributeCollectionByOwnerSchema {
			get;
			set;
		}

		public IEnumerable<Attribute> AttributeCollectionByReferenceSchema {
			get;
			set;
		}

		public IEnumerable<AttributeReferenceSchema> AttributeReferenceSchemaCollectionByReferenceSchema {
			get;
			set;
		}

		public IEnumerable<Playbook> PlaybookCollectionByCase {
			get;
			set;
		}

		public IEnumerable<SysClientUnitSchemaDependency> SysClientUnitSchemaDependencyCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysClientUnitSchemaSource> SysClientUnitSchemaSourceCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysEditPage> SysEditPageCollectionBySysEntitySchema {
			get;
			set;
		}

		public IEnumerable<SysEditPage> SysEditPageCollectionBySysPageSchema {
			get;
			set;
		}

		public IEnumerable<SysEntityPrcStartEvent> SysEntityPrcStartEventCollectionByProcessSchema {
			get;
			set;
		}

		public IEnumerable<SysEntitySchemaReference> SysEntitySchemaReferenceCollectionByReferenceSchema {
			get;
			set;
		}

		public IEnumerable<SysEntitySchemaReference> SysEntitySchemaReferenceCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysGridPage> SysGridPageCollectionBySysEntitySchema {
			get;
			set;
		}

		public IEnumerable<SysGridPage> SysGridPageCollectionBySysPageSchema {
			get;
			set;
		}

		public IEnumerable<SysInstalledPackageData> SysInstalledPackageDataCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysLocalizableValue> SysLocalizableValueCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysModuleGridEditPage> SysModuleGridEditPageCollectionBySysEditPageSchema {
			get;
			set;
		}

		public IEnumerable<SysModuleGridEditPage> SysModuleGridEditPageCollectionBySysModuleGridPage {
			get;
			set;
		}

		public IEnumerable<SysPackageResourceChecksum> SysPackageResourceChecksumCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysPackageSchemaData> SysPackageSchemaDataCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysPrcActualVersion> SysPrcActualVersionCollectionByActualVersionSchema {
			get;
			set;
		}

		public IEnumerable<SysPrcActualVersion> SysPrcActualVersionCollectionByRootVersionSchema {
			get;
			set;
		}

		public IEnumerable<SysPrcHistoryLog> SysPrcHistoryLogCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysProcessData> SysProcessDataCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysProcessDisabled> SysProcessDisabledCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysProcessLog> SysProcessLogCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysSchema> SysSchemaCollectionByParent {
			get;
			set;
		}

		public IEnumerable<SysSchemaContent> SysSchemaContentCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysSchemaProperty> SysSchemaPropertyCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<SysSSPCustomerSchema> SysSSPCustomerSchemaCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<VwProcessLib> VwProcessLibCollectionByParent {
			get;
			set;
		}

		public IEnumerable<VwSysDcmLib> VwSysDcmLibCollectionByParent {
			get;
			set;
		}

		public IEnumerable<VwSysEntitySchemaInWorkspace> VwSysEntitySchemaInWorkspaceCollectionByParent {
			get;
			set;
		}

		public IEnumerable<VwSysPageSchemaInWorkspace> VwSysPageSchemaInWorkspaceCollectionByParent {
			get;
			set;
		}

		public IEnumerable<VwSysProcess> VwSysProcessCollectionByParent {
			get;
			set;
		}

		public IEnumerable<VwSysProcessLog> VwSysProcessLogCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<VwSysProcessMILog> VwSysProcessMILogCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<VwSysProcessSchemaUserRight> VwSysProcessSchemaUserRightCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaDataInPackage> VwSysSchemaDataInPackageCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaInfo> VwSysSchemaInfoCollectionByParent {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaInfoForLookups> VwSysSchemaInfoForLookupsCollectionByParent {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaInWorkspace> VwSysSchemaInWorkspaceCollectionByParent {
			get;
			set;
		}

		public IEnumerable<VwSysSSPEntitySchemaAccessList> VwSysSSPEntitySchemaAccessListCollectionBySysSchema {
			get;
			set;
		}

		public IEnumerable<VwWebServiceV2> VwWebServiceV2CollectionByParent {
			get;
			set;
		}

		public IEnumerable<WSColourOfField> WSColourOfFieldCollectionByWSFolder {
			get;
			set;
		}

		public IEnumerable<WSPattern> WSPatternCollectionByWSFolder {
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
		/// Менеджер.
		/// </summary>
		public string ManagerName {
			get {
				return GetTypedColumnValue<string>("ManagerName");
			}
			set {
				SetColumnValue("ManagerName", value);
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
		public Guid LockedById {
			get {
				return GetTypedColumnValue<Guid>("LockedById");
			}
			set {
				SetColumnValue("LockedById", value);
				_lockedBy = null;
			}
		}

		/// <exclude/>
		public string LockedByName {
			get {
				return GetTypedColumnValue<string>("LockedByName");
			}
			set {
				SetColumnValue("LockedByName", value);
				if (_lockedBy != null) {
					_lockedBy.Name = value;
				}
			}
		}

		private SysAdminUnit _lockedBy;
		/// <summary>
		/// Заблокировал.
		/// </summary>
		public SysAdminUnit LockedBy {
			get {
				return _lockedBy ??
					(_lockedBy = new SysAdminUnit(LookupColumnEntities.GetEntity("LockedBy")));
			}
		}

		/// <summary>
		/// UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// Имя.
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
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
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
		public string ParentCaption {
			get {
				return GetTypedColumnValue<string>("ParentCaption");
			}
			set {
				SetColumnValue("ParentCaption", value);
				if (_parent != null) {
					_parent.Caption = value;
				}
			}
		}

		private SysSchema _parent;
		/// <summary>
		/// Родительская схема.
		/// </summary>
		public SysSchema Parent {
			get {
				return _parent ??
					(_parent = new SysSchema(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		/// <exclude/>
		public Guid SysPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageId");
			}
			set {
				SetColumnValue("SysPackageId", value);
				_sysPackage = null;
			}
		}

		/// <exclude/>
		public string SysPackageName {
			get {
				return GetTypedColumnValue<string>("SysPackageName");
			}
			set {
				SetColumnValue("SysPackageName", value);
				if (_sysPackage != null) {
					_sysPackage.Name = value;
				}
			}
		}

		private SysPackage _sysPackage;
		/// <summary>
		/// Пакет.
		/// </summary>
		public SysPackage SysPackage {
			get {
				return _sysPackage ??
					(_sysPackage = new SysPackage(LookupColumnEntities.GetEntity("SysPackage")));
			}
		}

		/// <summary>
		/// Метаданные изменено.
		/// </summary>
		public DateTime MetaDataModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("MetaDataModifiedOn");
			}
			set {
				SetColumnValue("MetaDataModifiedOn", value);
			}
		}

		/// <summary>
		/// Замещать родителя.
		/// </summary>
		public bool ExtendParent {
			get {
				return GetTypedColumnValue<bool>("ExtendParent");
			}
			set {
				SetColumnValue("ExtendParent", value);
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
		/// Схема изменена.
		/// </summary>
		public bool IsChanged {
			get {
				return GetTypedColumnValue<bool>("IsChanged");
			}
			set {
				SetColumnValue("IsChanged", value);
			}
		}

		/// <summary>
		/// Схема заблокирована.
		/// </summary>
		public bool IsLocked {
			get {
				return GetTypedColumnValue<bool>("IsLocked");
			}
			set {
				SetColumnValue("IsLocked", value);
			}
		}

		/// <summary>
		/// Дата актуализации клиентского модуля.
		/// </summary>
		public DateTime ClientContentModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ClientContentModifiedOn");
			}
			set {
				SetColumnValue("ClientContentModifiedOn", value);
			}
		}

		/// <summary>
		/// Текст последней ошибки.
		/// </summary>
		public string LastError {
			get {
				return GetTypedColumnValue<string>("LastError");
			}
			set {
				SetColumnValue("LastError", value);
			}
		}

		/// <summary>
		/// Запретить замещение.
		/// </summary>
		public bool DenyExtending {
			get {
				return GetTypedColumnValue<bool>("DenyExtending");
			}
			set {
				SetColumnValue("DenyExtending", value);
			}
		}

		/// <summary>
		/// Включить коды зависимых клиентских схем.
		/// </summary>
		public bool IncludeDependenciesSource {
			get {
				return GetTypedColumnValue<bool>("IncludeDependenciesSource");
			}
			set {
				SetColumnValue("IncludeDependenciesSource", value);
			}
		}

		/// <summary>
		/// Контрольная сумма.
		/// </summary>
		public string Checksum {
			get {
				return GetTypedColumnValue<string>("Checksum");
			}
			set {
				SetColumnValue("Checksum", value);
			}
		}

		/// <summary>
		/// Дата изменения структуры БД.
		/// </summary>
		public DateTime StructureModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("StructureModifiedOn");
			}
			set {
				SetColumnValue("StructureModifiedOn", value);
			}
		}

		/// <summary>
		/// Совместима с .Net Standard.
		/// </summary>
		public bool IsNetStandard {
			get {
				return GetTypedColumnValue<bool>("IsNetStandard");
			}
			set {
				SetColumnValue("IsNetStandard", value);
			}
		}

		#endregion

	}

	#endregion

}

