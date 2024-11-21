namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleInSysModuleFolder

	/// <exclude/>
	public class SysModuleInSysModuleFolder : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleInSysModuleFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleInSysModuleFolder";
		}

		public SysModuleInSysModuleFolder(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleInSysModuleFolder";
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
		/// Created on.
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
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
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
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <exclude/>
		public Guid SysModuleId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleId");
			}
			set {
				SetColumnValue("SysModuleId", value);
				_sysModule = null;
			}
		}

		/// <exclude/>
		public string SysModuleCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleCaption");
			}
			set {
				SetColumnValue("SysModuleCaption", value);
				if (_sysModule != null) {
					_sysModule.Caption = value;
				}
			}
		}

		private SysModule _sysModule;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule SysModule {
			get {
				return _sysModule ??
					(_sysModule = new SysModule(LookupColumnEntities.GetEntity("SysModule")));
			}
		}

		/// <exclude/>
		public Guid SubSysModuleFolderId {
			get {
				return GetTypedColumnValue<Guid>("SubSysModuleFolderId");
			}
			set {
				SetColumnValue("SubSysModuleFolderId", value);
				_subSysModuleFolder = null;
			}
		}

		/// <exclude/>
		public string SubSysModuleFolderCaption {
			get {
				return GetTypedColumnValue<string>("SubSysModuleFolderCaption");
			}
			set {
				SetColumnValue("SubSysModuleFolderCaption", value);
				if (_subSysModuleFolder != null) {
					_subSysModuleFolder.Caption = value;
				}
			}
		}

		private SysModuleFolder _subSysModuleFolder;
		/// <summary>
		/// Subordinate workplace.
		/// </summary>
		public SysModuleFolder SubSysModuleFolder {
			get {
				return _subSysModuleFolder ??
					(_subSysModuleFolder = new SysModuleFolder(LookupColumnEntities.GetEntity("SubSysModuleFolder")));
			}
		}

		/// <exclude/>
		public Guid SysModuleFolderId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleFolderId");
			}
			set {
				SetColumnValue("SysModuleFolderId", value);
				_sysModuleFolder = null;
			}
		}

		/// <exclude/>
		public string SysModuleFolderCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleFolderCaption");
			}
			set {
				SetColumnValue("SysModuleFolderCaption", value);
				if (_sysModuleFolder != null) {
					_sysModuleFolder.Caption = value;
				}
			}
		}

		private SysModuleFolder _sysModuleFolder;
		/// <summary>
		/// Workplace.
		/// </summary>
		public SysModuleFolder SysModuleFolder {
			get {
				return _sysModuleFolder ??
					(_sysModuleFolder = new SysModuleFolder(LookupColumnEntities.GetEntity("SysModuleFolder")));
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		#endregion

	}

	#endregion

}

