namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModule

	/// <exclude/>
	public class SysModule : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModule";
		}

		public SysModule(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModule";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<MessageNotifierBySection> MessageNotifierBySectionCollectionBySection {
			get;
			set;
		}

		public IEnumerable<MessagePublisherBySection> MessagePublisherBySectionCollectionBySection {
			get;
			set;
		}

		public IEnumerable<ProcessInModules> ProcessInModulesCollectionBySysModule {
			get;
			set;
		}

		public IEnumerable<SysAdminUnit> SysAdminUnitCollectionByHomePage {
			get;
			set;
		}

		public IEnumerable<SysDashboard> SysDashboardCollectionBySection {
			get;
			set;
		}

		public IEnumerable<SysModuleAction> SysModuleActionCollectionBySysModule {
			get;
			set;
		}

		public IEnumerable<SysModuleAnalyticsReport> SysModuleAnalyticsReportCollectionBySysModule {
			get;
			set;
		}

		public IEnumerable<SysModuleDetail> SysModuleDetailCollectionBySysModule {
			get;
			set;
		}

		public IEnumerable<SysModuleInSysModuleFolder> SysModuleInSysModuleFolderCollectionBySysModule {
			get;
			set;
		}

		public IEnumerable<SysModuleInWorkplace> SysModuleInWorkplaceCollectionBySysModule {
			get;
			set;
		}

		public IEnumerable<SysModuleLczOld> SysModuleLczOldCollectionByRecord {
			get;
			set;
		}

		public IEnumerable<SysModulePrimaryGrid> SysModulePrimaryGridCollectionBySysModule {
			get;
			set;
		}

		public IEnumerable<SysModuleReport> SysModuleReportCollectionBySysModule {
			get;
			set;
		}

		public IEnumerable<SysWidgetDashboard> SysWidgetDashboardCollectionBySection {
			get;
			set;
		}

		public IEnumerable<VwGroupSysAdminUnit> VwGroupSysAdminUnitCollectionByHomePage {
			get;
			set;
		}

		public IEnumerable<VwSSPSysAdminUnit> VwSSPSysAdminUnitCollectionByHomePage {
			get;
			set;
		}

		public IEnumerable<VwSysAdminUnit> VwSysAdminUnitCollectionByHomePage {
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
		public Guid SysModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEntityId");
			}
			set {
				SetColumnValue("SysModuleEntityId", value);
				_sysModuleEntity = null;
			}
		}

		private SysModuleEntity _sysModuleEntity;
		/// <summary>
		/// Объект раздела.
		/// </summary>
		public SysModuleEntity SysModuleEntity {
			get {
				return _sysModuleEntity ??
					(_sysModuleEntity = new SysModuleEntity(LookupColumnEntities.GetEntity("SysModuleEntity")));
			}
		}

		/// <exclude/>
		public Guid FolderModeId {
			get {
				return GetTypedColumnValue<Guid>("FolderModeId");
			}
			set {
				SetColumnValue("FolderModeId", value);
				_folderMode = null;
			}
		}

		/// <exclude/>
		public string FolderModeName {
			get {
				return GetTypedColumnValue<string>("FolderModeName");
			}
			set {
				SetColumnValue("FolderModeName", value);
				if (_folderMode != null) {
					_folderMode.Name = value;
				}
			}
		}

		private SysModuleFolderMode _folderMode;
		/// <summary>
		/// Режим групп раздела.
		/// </summary>
		public SysModuleFolderMode FolderMode {
			get {
				return _folderMode ??
					(_folderMode = new SysModuleFolderMode(LookupColumnEntities.GetEntity("FolderMode")));
			}
		}

		/// <summary>
		/// Использовать в поиске.
		/// </summary>
		public bool GlobalSearchAvailable {
			get {
				return GetTypedColumnValue<bool>("GlobalSearchAvailable");
			}
			set {
				SetColumnValue("GlobalSearchAvailable", value);
			}
		}

		/// <summary>
		/// Содержит аналитику.
		/// </summary>
		public bool HasAnalytics {
			get {
				return GetTypedColumnValue<bool>("HasAnalytics");
			}
			set {
				SetColumnValue("HasAnalytics", value);
			}
		}

		/// <summary>
		/// Содержит процессы.
		/// </summary>
		public bool HasActions {
			get {
				return GetTypedColumnValue<bool>("HasActions");
			}
			set {
				SetColumnValue("HasActions", value);
			}
		}

		/// <summary>
		/// Содержит группу Недавние.
		/// </summary>
		public bool HasRecent {
			get {
				return GetTypedColumnValue<bool>("HasRecent");
			}
			set {
				SetColumnValue("HasRecent", value);
			}
		}

		/// <summary>
		/// Code.
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
		/// Идентификатор контекстной справки.
		/// </summary>
		public string HelpContextId {
			get {
				return GetTypedColumnValue<string>("HelpContextId");
			}
			set {
				SetColumnValue("HelpContextId", value);
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
		/// Заголовок модуля.
		/// </summary>
		public string ModuleHeader {
			get {
				return GetTypedColumnValue<string>("ModuleHeader");
			}
			set {
				SetColumnValue("ModuleHeader", value);
			}
		}

		/// <summary>
		/// Атрибут.
		/// </summary>
		public string Attribute {
			get {
				return GetTypedColumnValue<string>("Attribute");
			}
			set {
				SetColumnValue("Attribute", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор страницы раздела.
		/// </summary>
		public Guid SysPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysPageSchemaUId");
			}
			set {
				SetColumnValue("SysPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор схемы страницы редактирования раздела.
		/// </summary>
		public Guid CardSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("CardSchemaUId");
			}
			set {
				SetColumnValue("CardSchemaUId", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор схемы модуля раздела.
		/// </summary>
		public Guid SectionModuleSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SectionModuleSchemaUId");
			}
			set {
				SetColumnValue("SectionModuleSchemaUId", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор схемы раздела.
		/// </summary>
		public Guid SectionSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SectionSchemaUId");
			}
			set {
				SetColumnValue("SectionSchemaUId", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор схемы модуля страницы редактирования.
		/// </summary>
		public Guid CardModuleUId {
			get {
				return GetTypedColumnValue<Guid>("CardModuleUId");
			}
			set {
				SetColumnValue("CardModuleUId", value);
			}
		}

		/// <summary>
		/// Значение колонки типа.
		/// </summary>
		public Guid TypeColumnValue {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnValue");
			}
			set {
				SetColumnValue("TypeColumnValue", value);
			}
		}

		/// <exclude/>
		public Guid Image32Id {
			get {
				return GetTypedColumnValue<Guid>("Image32Id");
			}
			set {
				SetColumnValue("Image32Id", value);
				_image32 = null;
			}
		}

		/// <exclude/>
		public string Image32Name {
			get {
				return GetTypedColumnValue<string>("Image32Name");
			}
			set {
				SetColumnValue("Image32Name", value);
				if (_image32 != null) {
					_image32.Name = value;
				}
			}
		}

		private SysImage _image32;
		/// <summary>
		/// Изображение (32x32).
		/// </summary>
		public SysImage Image32 {
			get {
				return _image32 ??
					(_image32 = new SysImage(LookupColumnEntities.GetEntity("Image32")));
			}
		}

		/// <exclude/>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
				_logo = null;
			}
		}

		/// <exclude/>
		public string LogoName {
			get {
				return GetTypedColumnValue<string>("LogoName");
			}
			set {
				SetColumnValue("LogoName", value);
				if (_logo != null) {
					_logo.Name = value;
				}
			}
		}

		private SysImage _logo;
		/// <summary>
		/// Лого.
		/// </summary>
		public SysImage Logo {
			get {
				return _logo ??
					(_logo = new SysImage(LookupColumnEntities.GetEntity("Logo")));
			}
		}

		/// <exclude/>
		public Guid SysModuleVisaId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleVisaId");
			}
			set {
				SetColumnValue("SysModuleVisaId", value);
				_sysModuleVisa = null;
			}
		}

		private SysModuleVisa _sysModuleVisa;
		/// <summary>
		/// Настройки визирования.
		/// </summary>
		public SysModuleVisa SysModuleVisa {
			get {
				return _sysModuleVisa ??
					(_sysModuleVisa = new SysModuleVisa(LookupColumnEntities.GetEntity("SysModuleVisa")));
			}
		}

		/// <summary>
		/// Системный раздел.
		/// </summary>
		public bool IsSystem {
			get {
				return GetTypedColumnValue<bool>("IsSystem");
			}
			set {
				SetColumnValue("IsSystem", value);
			}
		}

		/// <summary>
		/// Типы раздела.
		/// </summary>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		#endregion

	}

	#endregion

}

