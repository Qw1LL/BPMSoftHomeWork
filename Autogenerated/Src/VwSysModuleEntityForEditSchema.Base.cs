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

	#region Class: VwSysModuleEntityForEditSchema

	/// <exclude/>
	public class VwSysModuleEntityForEditSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysModuleEntityForEditSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysModuleEntityForEditSchema(VwSysModuleEntityForEditSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysModuleEntityForEditSchema(VwSysModuleEntityForEditSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a");
			RealUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a");
			Name = "VwSysModuleEntityForEdit";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cbbb40bf-10d8-442a-bae7-303f99a3d370")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cd28413b-f24e-4262-8d12-55335462f57b"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a"),
				ModifiedInSchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a"),
				CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cbbb40bf-10d8-442a-bae7-303f99a3d370"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a"),
				ModifiedInSchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a"),
				CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysModuleEntityForEdit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysModuleEntityForEdit_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysModuleEntityForEditSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysModuleEntityForEditSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysModuleEntityForEdit

	/// <summary>
	/// Section object (edit view).
	/// </summary>
	public class VwSysModuleEntityForEdit : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysModuleEntityForEdit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysModuleEntityForEdit";
		}

		public VwSysModuleEntityForEdit(VwSysModuleEntityForEdit source)
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
					(_sysWorkspace = LookupColumnEntities.GetEntity("SysWorkspace") as SysWorkspace);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysModuleEntityForEdit_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysModuleEntityForEditDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwSysModuleEntityForEditInserting", e);
			Validating += (s, e) => ThrowEvent("VwSysModuleEntityForEditValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysModuleEntityForEdit(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysModuleEntityForEdit_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysModuleEntityForEdit_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysModuleEntityForEdit
	{

		public VwSysModuleEntityForEdit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysModuleEntityForEdit_BaseEventsProcess";
			SchemaUId = new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9a3fdadf-218b-46d8-a867-5d33a69f125a");
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

	#region Class: VwSysModuleEntityForEdit_BaseEventsProcess

	/// <exclude/>
	public class VwSysModuleEntityForEdit_BaseEventsProcess : VwSysModuleEntityForEdit_BaseEventsProcess<VwSysModuleEntityForEdit>
	{

		public VwSysModuleEntityForEdit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysModuleEntityForEdit_BaseEventsProcess

	public partial class VwSysModuleEntityForEdit_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysModuleEntityForEditEventsProcess

	/// <exclude/>
	public class VwSysModuleEntityForEditEventsProcess : VwSysModuleEntityForEdit_BaseEventsProcess
	{

		public VwSysModuleEntityForEditEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

