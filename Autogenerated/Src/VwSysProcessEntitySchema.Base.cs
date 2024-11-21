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

	#region Class: VwSysProcessEntitySchema

	/// <exclude/>
	public class VwSysProcessEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysProcessEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysProcessEntitySchema(VwSysProcessEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysProcessEntitySchema(VwSysProcessEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7");
			RealUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7");
			Name = "VwSysProcessEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateEntityDisplayValueColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fb90ed59-84f3-4af8-91eb-c0671e2bdea1")) == null) {
				Columns.Add(CreateSysProcessColumn());
			}
			if (Columns.FindByUId(new Guid("0449fccb-9b26-4340-9588-485acd065b07")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("99f99d01-6085-4376-9199-b2210a192349")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("67812343-41d0-4e76-bf1a-61c81eba9ad6")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
			if (Columns.FindByUId(new Guid("123c1d2b-349a-4127-8068-3a008e1410e8")) == null) {
				Columns.Add(CreateReferenceSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("d97fb174-4ed4-4344-8fe6-1bff3d4696d8")) == null) {
				Columns.Add(CreateArchivedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fb90ed59-84f3-4af8-91eb-c0671e2bdea1"),
				Name = @"SysProcess",
				ReferenceSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b"),
				CreatedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				ModifiedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0449fccb-9b26-4340-9588-485acd065b07"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				ModifiedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityDisplayValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e2fd49bc-42c5-44fb-ac41-37ecb9d74845"),
				Name = @"EntityDisplayValue",
				CreatedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				ModifiedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("99f99d01-6085-4376-9199-b2210a192349"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				ModifiedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("67812343-41d0-4e76-bf1a-61c81eba9ad6"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				CreatedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				ModifiedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateReferenceSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("123c1d2b-349a-4127-8068-3a008e1410e8"),
				Name = @"ReferenceSchemaName",
				CreatedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				ModifiedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateArchivedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d97fb174-4ed4-4344-8fe6-1bff3d4696d8"),
				Name = @"Archived",
				CreatedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				ModifiedInSchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysProcessEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysProcessEntity_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysProcessEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysProcessEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessEntity

	/// <summary>
	/// Process object view (packages).
	/// </summary>
	public class VwSysProcessEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysProcessEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysProcessEntity";
		}

		public VwSysProcessEntity(VwSysProcessEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysProcessId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessId");
			}
			set {
				SetColumnValue("SysProcessId", value);
				_sysProcess = null;
			}
		}

		/// <exclude/>
		public string SysProcessName {
			get {
				return GetTypedColumnValue<string>("SysProcessName");
			}
			set {
				SetColumnValue("SysProcessName", value);
				if (_sysProcess != null) {
					_sysProcess.Name = value;
				}
			}
		}

		private VwSysProcessLog _sysProcess;
		/// <summary>
		/// Process.
		/// </summary>
		public VwSysProcessLog SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = LookupColumnEntities.GetEntity("SysProcess") as VwSysProcessLog);
			}
		}

		/// <summary>
		/// Object Id.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string EntityDisplayValue {
			get {
				return GetTypedColumnValue<string>("EntityDisplayValue");
			}
			set {
				SetColumnValue("EntityDisplayValue", value);
			}
		}

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private VwSysSchemaInWorkspace _sysSchema;
		/// <summary>
		/// Object.
		/// </summary>
		public VwSysSchemaInWorkspace SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as VwSysSchemaInWorkspace);
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

		/// <summary>
		/// ReferenceSchemaName.
		/// </summary>
		public string ReferenceSchemaName {
			get {
				return GetTypedColumnValue<string>("ReferenceSchemaName");
			}
			set {
				SetColumnValue("ReferenceSchemaName", value);
			}
		}

		/// <summary>
		/// Archived.
		/// </summary>
		public bool Archived {
			get {
				return GetTypedColumnValue<bool>("Archived");
			}
			set {
				SetColumnValue("Archived", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysProcessEntity_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysProcessEntityDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysProcessEntityDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysProcessEntityInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysProcessEntityInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysProcessEntitySaved", e);
			Saving += (s, e) => ThrowEvent("VwSysProcessEntitySaving", e);
			Validating += (s, e) => ThrowEvent("VwSysProcessEntityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysProcessEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessEntity_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysProcessEntity_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysProcessEntity
	{

		public VwSysProcessEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysProcessEntity_BaseEventsProcess";
			SchemaUId = new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("456d8deb-e4ec-45bf-a5dc-764574caf3c7");
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

	#region Class: VwSysProcessEntity_BaseEventsProcess

	/// <exclude/>
	public class VwSysProcessEntity_BaseEventsProcess : VwSysProcessEntity_BaseEventsProcess<VwSysProcessEntity>
	{

		public VwSysProcessEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysProcessEntity_BaseEventsProcess

	public partial class VwSysProcessEntity_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysProcessEntityEventsProcess

	/// <exclude/>
	public class VwSysProcessEntityEventsProcess : VwSysProcessEntity_BaseEventsProcess
	{

		public VwSysProcessEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

