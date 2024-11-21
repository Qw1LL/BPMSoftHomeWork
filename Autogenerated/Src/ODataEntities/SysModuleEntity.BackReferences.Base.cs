namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleEntity

	/// <exclude/>
	public class SysModuleEntity : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleEntity";
		}

		public SysModuleEntity(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleEntity";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Portal_SysModule> Portal_SysModuleCollectionBySysModuleEntity {
			get;
			set;
		}

		public IEnumerable<SysDcmSettings> SysDcmSettingsCollectionBySysModuleEntity {
			get;
			set;
		}

		public IEnumerable<SysModule> SysModuleCollectionBySysModuleEntity {
			get;
			set;
		}

		public IEnumerable<SysModuleDcmSettings> SysModuleDcmSettingsCollectionBySysModuleEntity {
			get;
			set;
		}

		public IEnumerable<SysModuleEdit> SysModuleEditCollectionBySysModuleEntity {
			get;
			set;
		}

		public IEnumerable<SysModuleEntityInPortal> SysModuleEntityInPortalCollectionBySysModuleEntity {
			get;
			set;
		}

		public IEnumerable<SysModuleGrid> SysModuleGridCollectionBySysModuleEntity {
			get;
			set;
		}

		public IEnumerable<VwSysModuleEdit> VwSysModuleEditCollectionBySysModuleEntity {
			get;
			set;
		}

		public IEnumerable<VwSysModuleSchemaEdit> VwSysModuleSchemaEditCollectionBySysModuleEntity {
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
		/// Колонка типа.
		/// </summary>
		public Guid TypeColumnUId {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnUId");
			}
			set {
				SetColumnValue("TypeColumnUId", value);
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

