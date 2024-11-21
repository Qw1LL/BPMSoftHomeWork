namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwSysLookup

	/// <exclude/>
	public class VwSysLookup : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysLookup";
		}

		public VwSysLookup(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSysLookup";
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

		/// <summary>
		/// Name.
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
		/// Description.
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
		/// Folder.
		/// </summary>
		public SysLookupFolder SysFolder {
			get {
				return _sysFolder ??
					(_sysFolder = new SysLookupFolder(LookupColumnEntities.GetEntity("SysFolder")));
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

		/// <summary>
		/// Simple.
		/// </summary>
		public bool IsSimple {
			get {
				return GetTypedColumnValue<bool>("IsSimple");
			}
			set {
				SetColumnValue("IsSimple", value);
			}
		}

		/// <summary>
		/// System.
		/// </summary>
		public bool IsSystem {
			get {
				return GetTypedColumnValue<bool>("IsSystem");
			}
			set {
				SetColumnValue("IsSystem", value);
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
		/// User workspace.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = new SysWorkspace(LookupColumnEntities.GetEntity("SysWorkspace")));
			}
		}

		/// <summary>
		/// Unique identifier of edit page.
		/// </summary>
		public Guid SysEditPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEditPageSchemaUId");
			}
			set {
				SetColumnValue("SysEditPageSchemaUId", value);
			}
		}

		/// <exclude/>
		public Guid SysGridPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysGridPageSchemaUId");
			}
			set {
				SetColumnValue("SysGridPageSchemaUId", value);
				_sysGridPageSchemaU = null;
			}
		}

		/// <exclude/>
		public string SysGridPageSchemaUCaption {
			get {
				return GetTypedColumnValue<string>("SysGridPageSchemaUCaption");
			}
			set {
				SetColumnValue("SysGridPageSchemaUCaption", value);
				if (_sysGridPageSchemaU != null) {
					_sysGridPageSchemaU.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _sysGridPageSchemaU;
		/// <summary>
		/// Unique identifier of list page.
		/// </summary>
		public VwSysSchemaInfo SysGridPageSchemaU {
			get {
				return _sysGridPageSchemaU ??
					(_sysGridPageSchemaU = new VwSysSchemaInfo(LookupColumnEntities.GetEntity("SysGridPageSchemaU")));
			}
		}

		/// <exclude/>
		public Guid SysEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			}
			set {
				SetColumnValue("SysEntitySchemaUId", value);
				_sysEntitySchemaU = null;
			}
		}

		/// <exclude/>
		public string SysEntitySchemaUCaption {
			get {
				return GetTypedColumnValue<string>("SysEntitySchemaUCaption");
			}
			set {
				SetColumnValue("SysEntitySchemaUCaption", value);
				if (_sysEntitySchemaU != null) {
					_sysEntitySchemaU.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _sysEntitySchemaU;
		/// <summary>
		/// Unique identifier of object.
		/// </summary>
		public VwSysSchemaInfo SysEntitySchemaU {
			get {
				return _sysEntitySchemaU ??
					(_sysEntitySchemaU = new VwSysSchemaInfo(LookupColumnEntities.GetEntity("SysEntitySchemaU")));
			}
		}

		#endregion

	}

	#endregion

}

