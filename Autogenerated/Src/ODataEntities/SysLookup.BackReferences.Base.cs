namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysLookup

	/// <exclude/>
	public class SysLookup : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLookup";
		}

		public SysLookup(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysLookup";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<CampaignLogItemType> CampaignLogItemTypeCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<ContentBuilderCustomerFont> ContentBuilderCustomerFontCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<ContentBuilderFontSet> ContentBuilderFontSetCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<DeduplicateOperation> DeduplicateOperationCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<FileSecurityExcludedUri> FileSecurityExcludedUriCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<FileSecurityMode> FileSecurityModeCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<Lookup> LookupCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<RuleRelationSections> RuleRelationSectionsCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<SysLookupColumn> SysLookupColumnCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<SysLookupSearchColumn> SysLookupSearchColumnCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<VwSysLookupInFolder> VwSysLookupInFolderCollectionByVwSysLookup {
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
		public Guid SysFolderId {
			get {
				return GetTypedColumnValue<Guid>("SysFolderId");
			}
			set {
				SetColumnValue("SysFolderId", value);
				_sysFolder = null;
			}
		}

		/// <exclude/>
		public string SysFolderName {
			get {
				return GetTypedColumnValue<string>("SysFolderName");
			}
			set {
				SetColumnValue("SysFolderName", value);
				if (_sysFolder != null) {
					_sysFolder.Name = value;
				}
			}
		}

		private SysLookupFolder _sysFolder;
		/// <summary>
		/// Группа.
		/// </summary>
		public SysLookupFolder SysFolder {
			get {
				return _sysFolder ??
					(_sysFolder = new SysLookupFolder(LookupColumnEntities.GetEntity("SysFolder")));
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
		/// Системный.
		/// </summary>
		/// <remarks>
		/// Важный системный справочник, участвующий в бизнес-процессах. Изменение запрещено.
		/// </remarks>
		public bool IsSystem {
			get {
				return GetTypedColumnValue<bool>("IsSystem");
			}
			set {
				SetColumnValue("IsSystem", value);
			}
		}

		/// <summary>
		/// Простой.
		/// </summary>
		/// <remarks>
		/// Простой справочник с небольшим количеством записей. Кешируется.
		/// </remarks>
		public bool IsSimple {
			get {
				return GetTypedColumnValue<bool>("IsSimple");
			}
			set {
				SetColumnValue("IsSimple", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор страницы редактирования.
		/// </summary>
		public Guid SysEditPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEditPageSchemaUId");
			}
			set {
				SetColumnValue("SysEditPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор страницы реестра.
		/// </summary>
		public Guid SysGridPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysGridPageSchemaUId");
			}
			set {
				SetColumnValue("SysGridPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор объекта.
		/// </summary>
		public Guid SysEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			}
			set {
				SetColumnValue("SysEntitySchemaUId", value);
			}
		}

		#endregion

	}

	#endregion

}

