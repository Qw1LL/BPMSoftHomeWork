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

	#region Class: VwSysClientUnitSchemaSchema

	/// <exclude/>
	public class VwSysClientUnitSchemaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysClientUnitSchemaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysClientUnitSchemaSchema(VwSysClientUnitSchemaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysClientUnitSchemaSchema(VwSysClientUnitSchemaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf");
			RealUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf");
			Name = "VwSysClientUnitSchema";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768");
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
			if (Columns.FindByUId(new Guid("d31409d0-d0d4-4ead-b805-f0c944fddaf9")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("c036526b-292f-415b-98fb-e984acbbaf29")) == null) {
				Columns.Add(CreateManagerNameColumn());
			}
			if (Columns.FindByUId(new Guid("b8f31d0f-f041-4eef-b193-4c231b3d033b")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("5baa38bb-d7e3-4508-9d3c-34f433813238")) == null) {
				Columns.Add(CreatePackageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("1b1a1aa0-83ae-4679-abcc-c7ff63ebbeb6")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("7bf511da-c756-45f8-8247-14ee3486ebb7")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
			if (Columns.FindByUId(new Guid("8b677b31-526f-451a-a2e0-1fc3848ca49d")) == null) {
				Columns.Add(CreateExtendParentColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf");
			column.CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf");
			column.CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf");
			column.CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf");
			column.CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf");
			column.CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf");
			column.CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d31409d0-d0d4-4ead-b805-f0c944fddaf9"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("76a5d543-d9e9-44c0-aa27-e577da681249"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreateManagerNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c036526b-292f-415b-98fb-e984acbbaf29"),
				Name = @"ManagerName",
				CreatedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b8f31d0f-f041-4eef-b193-4c231b3d033b"),
				Name = @"UId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreatePackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5baa38bb-d7e3-4508-9d3c-34f433813238"),
				Name = @"PackageUId",
				CreatedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1b1a1aa0-83ae-4679-abcc-c7ff63ebbeb6"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7bf511da-c756-45f8-8247-14ee3486ebb7"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreateExtendParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8b677b31-526f-451a-a2e0-1fc3848ca49d"),
				Name = @"ExtendParent",
				CreatedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				ModifiedInSchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"),
				CreatedInPackageId = new Guid("f69f6aca-d587-4abd-9a90-ac4521baf251")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysClientUnitSchema(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysClientUnitSchema_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysClientUnitSchemaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysClientUnitSchemaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysClientUnitSchema

	/// <summary>
	/// Workspace customer schemas (view).
	/// </summary>
	public class VwSysClientUnitSchema : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysClientUnitSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysClientUnitSchema";
		}

		public VwSysClientUnitSchema(VwSysClientUnitSchema source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// ExtendParent.
		/// </summary>
		public bool ExtendParent {
			get {
				return GetTypedColumnValue<bool>("ExtendParent");
			}
			set {
				SetColumnValue("ExtendParent", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysClientUnitSchema_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysClientUnitSchemaDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwSysClientUnitSchemaInserting", e);
			Validating += (s, e) => ThrowEvent("VwSysClientUnitSchemaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysClientUnitSchema(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysClientUnitSchema_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysClientUnitSchema_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysClientUnitSchema
	{

		public VwSysClientUnitSchema_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysClientUnitSchema_BaseEventsProcess";
			SchemaUId = new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("46ffda25-af49-4a3d-aa4d-10b43e7154cf");
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

	#region Class: VwSysClientUnitSchema_BaseEventsProcess

	/// <exclude/>
	public class VwSysClientUnitSchema_BaseEventsProcess : VwSysClientUnitSchema_BaseEventsProcess<VwSysClientUnitSchema>
	{

		public VwSysClientUnitSchema_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysClientUnitSchema_BaseEventsProcess

	public partial class VwSysClientUnitSchema_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysClientUnitSchemaEventsProcess

	/// <exclude/>
	public class VwSysClientUnitSchemaEventsProcess : VwSysClientUnitSchema_BaseEventsProcess
	{

		public VwSysClientUnitSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

