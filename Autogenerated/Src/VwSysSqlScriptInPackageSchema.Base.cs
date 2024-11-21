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

	#region Class: VwSysSqlScriptInPackageSchema

	/// <exclude/>
	public class VwSysSqlScriptInPackageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysSqlScriptInPackageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysSqlScriptInPackageSchema(VwSysSqlScriptInPackageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysSqlScriptInPackageSchema(VwSysSqlScriptInPackageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de");
			RealUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de");
			Name = "VwSysSqlScriptInPackage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("17d728df-eb0b-4343-8669-a96e11b6c862")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("5baa5dde-a689-446a-8f1b-788889d418eb")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("5d141a01-4bd5-4146-b0b1-999195b3bef2")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
			if (Columns.FindByUId(new Guid("609ba298-3309-4509-9b8f-c74ad4b1c8cf")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("70965a98-5393-4b5a-b1e0-eb8cb4027745")) == null) {
				Columns.Add(CreateSysSQLScriptLevelColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("17d728df-eb0b-4343-8669-a96e11b6c862"),
				Name = @"UId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"),
				ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5baa5dde-a689-446a-8f1b-788889d418eb"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"),
				ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5d141a01-4bd5-4146-b0b1-999195b3bef2"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"),
				ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("609ba298-3309-4509-9b8f-c74ad4b1c8cf"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"),
				ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSQLScriptLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("70965a98-5393-4b5a-b1e0-eb8cb4027745"),
				Name = @"SysSQLScriptLevel",
				CreatedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"),
				ModifiedInSchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysSqlScriptInPackage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysSqlScriptInPackage_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysSqlScriptInPackageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysSqlScriptInPackageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSqlScriptInPackage

	/// <summary>
	/// SQL script item (view).
	/// </summary>
	public class VwSysSqlScriptInPackage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysSqlScriptInPackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSqlScriptInPackage";
		}

		public VwSysSqlScriptInPackage(VwSysSqlScriptInPackage source)
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
		/// SQL script level.
		/// </summary>
		public int SysSQLScriptLevel {
			get {
				return GetTypedColumnValue<int>("SysSQLScriptLevel");
			}
			set {
				SetColumnValue("SysSQLScriptLevel", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysSqlScriptInPackage_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysSqlScriptInPackageDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwSysSqlScriptInPackageInserting", e);
			Validating += (s, e) => ThrowEvent("VwSysSqlScriptInPackageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysSqlScriptInPackage(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSqlScriptInPackage_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysSqlScriptInPackage_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysSqlScriptInPackage
	{

		public VwSysSqlScriptInPackage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysSqlScriptInPackage_BaseEventsProcess";
			SchemaUId = new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("57b6028d-ae61-4fb3-8413-8e9ba64d98de");
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

	#region Class: VwSysSqlScriptInPackage_BaseEventsProcess

	/// <exclude/>
	public class VwSysSqlScriptInPackage_BaseEventsProcess : VwSysSqlScriptInPackage_BaseEventsProcess<VwSysSqlScriptInPackage>
	{

		public VwSysSqlScriptInPackage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysSqlScriptInPackage_BaseEventsProcess

	public partial class VwSysSqlScriptInPackage_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysSqlScriptInPackageEventsProcess

	/// <exclude/>
	public class VwSysSqlScriptInPackageEventsProcess : VwSysSqlScriptInPackage_BaseEventsProcess
	{

		public VwSysSqlScriptInPackageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

