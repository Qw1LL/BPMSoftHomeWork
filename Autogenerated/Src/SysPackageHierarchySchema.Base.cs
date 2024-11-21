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

	#region Class: SysPackageHierarchySchema

	/// <exclude/>
	public class SysPackageHierarchySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPackageHierarchySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPackageHierarchySchema(SysPackageHierarchySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPackageHierarchySchema(SysPackageHierarchySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIBaseSysPackageIdLevelIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("e79e013f-384f-444d-ad00-7d9bdec7965e");
			index.Name = "IBaseSysPackageIdLevel";
			index.CreatedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359");
			index.ModifiedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn baseSysPackageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("feb00c4b-e1c5-4aa5-b647-19abab77df65"),
				ColumnUId = new Guid("ec6c9398-01f1-41ff-a832-da7cbbfecff3"),
				CreatedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				ModifiedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(baseSysPackageIdIndexColumn);
			EntitySchemaIndexColumn levelIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("02cea8fa-24a7-473e-ba6d-a3275f98a4f2"),
				ColumnUId = new Guid("23eb1b69-5564-466e-835c-be56affcf804"),
				CreatedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				ModifiedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(levelIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("42f9648a-f518-42e8-a680-3ace45689359");
			RealUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359");
			Name = "SysPackageHierarchy";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ec6c9398-01f1-41ff-a832-da7cbbfecff3")) == null) {
				Columns.Add(CreateBaseSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("23eb1b69-5564-466e-835c-be56affcf804")) == null) {
				Columns.Add(CreateLevelColumn());
			}
			if (Columns.FindByUId(new Guid("69185f55-fc6b-4cc4-aaf5-74cb6302f783")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("ded331e4-48df-4d52-be00-563c17f5b9ed")) == null) {
				Columns.Add(CreateDependOnPackageColumn());
			}
			if (Columns.FindByUId(new Guid("e9738f63-16ac-41ca-b643-9aa9698bb35e")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBaseSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ec6c9398-01f1-41ff-a832-da7cbbfecff3"),
				Name = @"BaseSysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				ModifiedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("23eb1b69-5564-466e-835c-be56affcf804"),
				Name = @"Level",
				CreatedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				ModifiedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("69185f55-fc6b-4cc4-aaf5-74cb6302f783"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				ModifiedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateDependOnPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ded331e4-48df-4d52-be00-563c17f5b9ed"),
				Name = @"DependOnPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				ModifiedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e9738f63-16ac-41ca-b643-9aa9698bb35e"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				ModifiedInSchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359"),
				CreatedInPackageId = new Guid("f8088863-40c9-4044-96b4-321b32fe7a77")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIBaseSysPackageIdLevelIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPackageHierarchy(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPackageHierarchy_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPackageHierarchySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPackageHierarchySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("42f9648a-f518-42e8-a680-3ace45689359"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageHierarchy

	/// <summary>
	/// Package hierarchy.
	/// </summary>
	public class SysPackageHierarchy : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPackageHierarchy(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackageHierarchy";
		}

		public SysPackageHierarchy(SysPackageHierarchy source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid BaseSysPackageId {
			get {
				return GetTypedColumnValue<Guid>("BaseSysPackageId");
			}
			set {
				SetColumnValue("BaseSysPackageId", value);
				_baseSysPackage = null;
			}
		}

		/// <exclude/>
		public string BaseSysPackageName {
			get {
				return GetTypedColumnValue<string>("BaseSysPackageName");
			}
			set {
				SetColumnValue("BaseSysPackageName", value);
				if (_baseSysPackage != null) {
					_baseSysPackage.Name = value;
				}
			}
		}

		private SysPackage _baseSysPackage;
		/// <summary>
		/// Base package.
		/// </summary>
		public SysPackage BaseSysPackage {
			get {
				return _baseSysPackage ??
					(_baseSysPackage = LookupColumnEntities.GetEntity("BaseSysPackage") as SysPackage);
			}
		}

		/// <summary>
		/// Level.
		/// </summary>
		public int Level {
			get {
				return GetTypedColumnValue<int>("Level");
			}
			set {
				SetColumnValue("Level", value);
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

		/// <exclude/>
		public Guid DependOnPackageId {
			get {
				return GetTypedColumnValue<Guid>("DependOnPackageId");
			}
			set {
				SetColumnValue("DependOnPackageId", value);
				_dependOnPackage = null;
			}
		}

		/// <exclude/>
		public string DependOnPackageName {
			get {
				return GetTypedColumnValue<string>("DependOnPackageName");
			}
			set {
				SetColumnValue("DependOnPackageName", value);
				if (_dependOnPackage != null) {
					_dependOnPackage.Name = value;
				}
			}
		}

		private SysPackage _dependOnPackage;
		/// <summary>
		/// Depends on package.
		/// </summary>
		public SysPackage DependOnPackage {
			get {
				return _dependOnPackage ??
					(_dependOnPackage = LookupColumnEntities.GetEntity("DependOnPackage") as SysPackage);
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
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = LookupColumnEntities.GetEntity("SysWorkspace") as SysWorkspace);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPackageHierarchy_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPackageHierarchyDeleted", e);
			Validating += (s, e) => ThrowEvent("SysPackageHierarchyValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPackageHierarchy(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageHierarchy_BaseEventsProcess

	/// <exclude/>
	public partial class SysPackageHierarchy_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPackageHierarchy
	{

		public SysPackageHierarchy_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPackageHierarchy_BaseEventsProcess";
			SchemaUId = new Guid("42f9648a-f518-42e8-a680-3ace45689359");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("42f9648a-f518-42e8-a680-3ace45689359");
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

	#region Class: SysPackageHierarchy_BaseEventsProcess

	/// <exclude/>
	public class SysPackageHierarchy_BaseEventsProcess : SysPackageHierarchy_BaseEventsProcess<SysPackageHierarchy>
	{

		public SysPackageHierarchy_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPackageHierarchy_BaseEventsProcess

	public partial class SysPackageHierarchy_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPackageHierarchyEventsProcess

	/// <exclude/>
	public class SysPackageHierarchyEventsProcess : SysPackageHierarchy_BaseEventsProcess
	{

		public SysPackageHierarchyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

