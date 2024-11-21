namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwProcessLib

	/// <exclude/>
	public class VwProcessLib : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwProcessLib(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProcessLib";
		}

		public VwProcessLib(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwProcessLib";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<VwSubProcessInProcess> VwSubProcessInProcessCollectionByActiveSubProcess {
			get;
			set;
		}

		public IEnumerable<VwSubProcessInProcess> VwSubProcessInProcessCollectionByHostProcess {
			get;
			set;
		}

		public IEnumerable<VwSubProcessInProcess> VwSubProcessInProcessCollectionByParentProcess {
			get;
			set;
		}

		public IEnumerable<VwSubProcessInProcess> VwSubProcessInProcessCollectionByParentSubProcess {
			get;
			set;
		}

		public IEnumerable<VwSubProcessInProcess> VwSubProcessInProcessCollectionBySubProcess {
			get;
			set;
		}

		public IEnumerable<WebFormContactIdentifier> WebFormContactIdentifierCollectionBySysProcess {
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
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Manager name.
		/// </summary>
		public string ManagerName {
			get {
				return GetTypedColumnValue<string>("ManagerName");
			}
			set {
				SetColumnValue("ManagerName", value);
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
		/// Parent.
		/// </summary>
		public SysSchema Parent {
			get {
				return _parent ??
					(_parent = new SysSchema(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		/// <summary>
		/// Extends parent.
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
		/// Modified.
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
		/// Locked.
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
		/// Metadata changed.
		/// </summary>
		public DateTime MetaDataModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("MetaDataModifiedOn");
			}
			set {
				SetColumnValue("MetaDataModifiedOn", value);
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
		/// Package.
		/// </summary>
		public SysPackage SysPackage {
			get {
				return _sysPackage ??
					(_sysPackage = new SysPackage(LookupColumnEntities.GetEntity("SysPackage")));
			}
		}

		/// <summary>
		/// Package Id.
		/// </summary>
		public Guid PackageUId {
			get {
				return GetTypedColumnValue<Guid>("PackageUId");
			}
			set {
				SetColumnValue("PackageUId", value);
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
		/// Workspace.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = new SysWorkspace(LookupColumnEntities.GetEntity("SysWorkspace")));
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
		/// Source code update required.
		/// </summary>
		public bool NeedUpdateSourceCode {
			get {
				return GetTypedColumnValue<bool>("NeedUpdateSourceCode");
			}
			set {
				SetColumnValue("NeedUpdateSourceCode", value);
			}
		}

		/// <summary>
		/// Update required: Table in database.
		/// </summary>
		public bool NeedUpdateStructure {
			get {
				return GetTypedColumnValue<bool>("NeedUpdateStructure");
			}
			set {
				SetColumnValue("NeedUpdateStructure", value);
			}
		}

		/// <summary>
		/// Needs installing.
		/// </summary>
		public bool NeedInstall {
			get {
				return GetTypedColumnValue<bool>("NeedInstall");
			}
			set {
				SetColumnValue("NeedInstall", value);
			}
		}

		/// <summary>
		/// Maximum version.
		/// </summary>
		public bool IsMaxVersion {
			get {
				return GetTypedColumnValue<bool>("IsMaxVersion");
			}
			set {
				SetColumnValue("IsMaxVersion", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public string TagProperty {
			get {
				return GetTypedColumnValue<string>("TagProperty");
			}
			set {
				SetColumnValue("TagProperty", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool Enabled {
			get {
				return GetTypedColumnValue<bool>("Enabled");
			}
			set {
				SetColumnValue("Enabled", value);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		/// <exclude/>
		public Guid ProcessSchemaTypeId {
			get {
				return GetTypedColumnValue<Guid>("ProcessSchemaTypeId");
			}
			set {
				SetColumnValue("ProcessSchemaTypeId", value);
				_processSchemaType = null;
			}
		}

		/// <exclude/>
		public string ProcessSchemaTypeName {
			get {
				return GetTypedColumnValue<string>("ProcessSchemaTypeName");
			}
			set {
				SetColumnValue("ProcessSchemaTypeName", value);
				if (_processSchemaType != null) {
					_processSchemaType.Name = value;
				}
			}
		}

		private ProcessSchemaType _processSchemaType;
		/// <summary>
		/// Process schema type.
		/// </summary>
		public ProcessSchemaType ProcessSchemaType {
			get {
				return _processSchemaType ??
					(_processSchemaType = new ProcessSchemaType(LookupColumnEntities.GetEntity("ProcessSchemaType")));
			}
		}

		/// <summary>
		/// Unique identifier of workspace schema.
		/// </summary>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
			}
		}

		/// <summary>
		/// Display in run process button list.
		/// </summary>
		public bool AddToRunButton {
			get {
				return GetTypedColumnValue<bool>("AddToRunButton");
			}
			set {
				SetColumnValue("AddToRunButton", value);
			}
		}

		/// <summary>
		/// Actual version.
		/// </summary>
		public bool IsActiveVersion {
			get {
				return GetTypedColumnValue<bool>("IsActiveVersion");
			}
			set {
				SetColumnValue("IsActiveVersion", value);
			}
		}

		/// <summary>
		/// Parent version Id.
		/// </summary>
		public Guid VersionParentId {
			get {
				return GetTypedColumnValue<Guid>("VersionParentId");
			}
			set {
				SetColumnValue("VersionParentId", value);
			}
		}

		/// <summary>
		/// HasStartEvent.
		/// </summary>
		public bool HasStartEvent {
			get {
				return GetTypedColumnValue<bool>("HasStartEvent");
			}
			set {
				SetColumnValue("HasStartEvent", value);
			}
		}

		/// <summary>
		/// VersionParentUId.
		/// </summary>
		public Guid VersionParentUId {
			get {
				return GetTypedColumnValue<Guid>("VersionParentUId");
			}
			set {
				SetColumnValue("VersionParentUId", value);
			}
		}

		/// <exclude/>
		public Guid StartOptionsImageId {
			get {
				return GetTypedColumnValue<Guid>("StartOptionsImageId");
			}
			set {
				SetColumnValue("StartOptionsImageId", value);
				_startOptionsImage = null;
			}
		}

		/// <exclude/>
		public string StartOptionsImageName {
			get {
				return GetTypedColumnValue<string>("StartOptionsImageName");
			}
			set {
				SetColumnValue("StartOptionsImageName", value);
				if (_startOptionsImage != null) {
					_startOptionsImage.Name = value;
				}
			}
		}

		private SysImage _startOptionsImage;
		/// <summary>
		/// Start options image.
		/// </summary>
		public SysImage StartOptionsImage {
			get {
				return _startOptionsImage ??
					(_startOptionsImage = new SysImage(LookupColumnEntities.GetEntity("StartOptionsImage")));
			}
		}

		/// <summary>
		/// Trace enabled.
		/// </summary>
		public bool IsProcessTracing {
			get {
				return GetTypedColumnValue<bool>("IsProcessTracing");
			}
			set {
				SetColumnValue("IsProcessTracing", value);
			}
		}

		#endregion

	}

	#endregion

}

