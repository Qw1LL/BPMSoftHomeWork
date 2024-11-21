namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;

	#region Class: VwSysSchemaInPackageSchema

	/// <exclude/>
	public class VwSysSchemaInPackageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysSchemaInPackageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysSchemaInPackageSchema(VwSysSchemaInPackageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysSchemaInPackageSchema(VwSysSchemaInPackageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548");
			RealUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548");
			Name = "VwSysSchemaInPackage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a921fc66-bbc8-4f59-9253-d410625ec49a")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("c59fb128-90ee-487e-b702-c6f6acae2583")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("8ae30f71-25f0-473d-8c97-16cf03c8d408")) == null) {
				Columns.Add(CreateManagerNameColumn());
			}
			if (Columns.FindByUId(new Guid("7c442291-96f2-402f-88f4-998317c143b3")) == null) {
				Columns.Add(CreateParentColumn());
			}
			if (Columns.FindByUId(new Guid("ae58db1d-12b0-4b46-b4ec-0393898aadcd")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
			if (Columns.FindByUId(new Guid("5d589a1f-237d-4c7e-ac6c-c0e0582f1323")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("b6a05bf8-5caa-4eb5-ab57-a617aa7eb230")) == null) {
				Columns.Add(CreateSysPackageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("1be83498-498b-47d4-aff1-c9a429b78dfd")) == null) {
				Columns.Add(CreateSysPackageLevelColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a921fc66-bbc8-4f59-9253-d410625ec49a"),
				Name = @"UId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				ModifiedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c59fb128-90ee-487e-b702-c6f6acae2583"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				ModifiedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("40cbdc3d-3d91-419a-a921-8e0643185d8a"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				ModifiedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateManagerNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8ae30f71-25f0-473d-8c97-16cf03c8d408"),
				Name = @"ManagerName",
				CreatedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				ModifiedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7c442291-96f2-402f-88f4-998317c143b3"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				ModifiedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ae58db1d-12b0-4b46-b4ec-0393898aadcd"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				ModifiedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5d589a1f-237d-4c7e-ac6c-c0e0582f1323"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				ModifiedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b6a05bf8-5caa-4eb5-ab57-a617aa7eb230"),
				Name = @"SysPackageUId",
				CreatedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				ModifiedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1be83498-498b-47d4-aff1-c9a429b78dfd"),
				Name = @"SysPackageLevel",
				CreatedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				ModifiedInSchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysSchemaInPackage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysSchemaInPackage_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysSchemaInPackageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysSchemaInPackageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaInPackage

	/// <summary>
	/// Package item (view).
	/// </summary>
	public class VwSysSchemaInPackage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysSchemaInPackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSchemaInPackage";
		}

		public VwSysSchemaInPackage(VwSysSchemaInPackage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		private VwSysSchemaInPackage _parent;
		/// <summary>
		/// Parent item.
		/// </summary>
		public VwSysSchemaInPackage Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as VwSysSchemaInPackage);
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
					(_sysWorkspace = LookupColumnEntities.GetEntity("SysWorkspace") as SysWorkspace);
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
					(_sysPackage = LookupColumnEntities.GetEntity("SysPackage") as SysPackage);
			}
		}

		/// <summary>
		/// Package Id.
		/// </summary>
		public Guid SysPackageUId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageUId");
			}
			set {
				SetColumnValue("SysPackageUId", value);
			}
		}

		/// <summary>
		/// Package level.
		/// </summary>
		public int SysPackageLevel {
			get {
				return GetTypedColumnValue<int>("SysPackageLevel");
			}
			set {
				SetColumnValue("SysPackageLevel", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysSchemaInPackage_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysSchemaInPackageDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwSysSchemaInPackageInserting", e);
			Validating += (s, e) => ThrowEvent("VwSysSchemaInPackageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysSchemaInPackage(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaInPackage_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysSchemaInPackage_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysSchemaInPackage
	{

		public VwSysSchemaInPackage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysSchemaInPackage_BaseEventsProcess";
			SchemaUId = new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a594c3c0-91bd-400f-a209-6d38cf0d7548");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaInPackage_BaseEventsProcess

	/// <exclude/>
	public class VwSysSchemaInPackage_BaseEventsProcess : VwSysSchemaInPackage_BaseEventsProcess<VwSysSchemaInPackage>
	{

		public VwSysSchemaInPackage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysSchemaInPackage_BaseEventsProcess

	public partial class VwSysSchemaInPackage_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysSchemaInPackageEventsProcess

	/// <exclude/>
	public class VwSysSchemaInPackageEventsProcess : VwSysSchemaInPackage_BaseEventsProcess
	{

		public VwSysSchemaInPackageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

