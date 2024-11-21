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

	#region Class: VwSysProcessSchema

	/// <exclude/>
	public class VwSysProcessSchema : BPMSoft.Configuration.VwSysSchemaInWorkspaceSchema
	{

		#region Constructors: Public

		public VwSysProcessSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysProcessSchema(VwSysProcessSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysProcessSchema(VwSysProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229");
			RealUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229");
			Name = "VwSysProcess";
			ParentSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("97fdd120-a668-46eb-a0a1-2728fe9c143c")) == null) {
				Columns.Add(CreateIsMaxVersionColumn());
			}
			if (Columns.FindByUId(new Guid("a8d119be-c436-438e-a81f-4121c4d4e7f1")) == null) {
				Columns.Add(CreateTagPropertyColumn());
			}
			if (Columns.FindByUId(new Guid("22e80bb0-b4f5-c045-f859-e86cd73ecc28")) == null) {
				Columns.Add(CreateSysSchemaIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateUIdColumn() {
			EntitySchemaColumn column = base.CreateUIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.Advanced;
			column.ModifiedInSchemaUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229");
			return column;
		}

		protected override EntitySchemaColumn CreatePackageUIdColumn() {
			EntitySchemaColumn column = base.CreatePackageUIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.Advanced;
			column.ModifiedInSchemaUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsMaxVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("97fdd120-a668-46eb-a0a1-2728fe9c143c"),
				Name = @"IsMaxVersion",
				CreatedInSchemaUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229"),
				ModifiedInSchemaUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229"),
				CreatedInPackageId = new Guid("8faebbb4-6032-45a8-ace5-f8b3ded3b01d")
			};
		}

		protected virtual EntitySchemaColumn CreateTagPropertyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a8d119be-c436-438e-a81f-4121c4d4e7f1"),
				Name = @"TagProperty",
				CreatedInSchemaUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229"),
				ModifiedInSchemaUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229"),
				CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("22e80bb0-b4f5-c045-f859-e86cd73ecc28"),
				Name = @"SysSchemaId",
				CreatedInSchemaUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229"),
				ModifiedInSchemaUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysProcess(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysProcess_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysProcessSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysProcessSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcess

	/// <summary>
	/// Workspace process in package (view).
	/// </summary>
	public class VwSysProcess : BPMSoft.Configuration.VwSysSchemaInWorkspace
	{

		#region Constructors: Public

		public VwSysProcess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysProcess";
		}

		public VwSysProcess(VwSysProcess source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Tag.
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysProcess_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysProcessDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwSysProcessInserting", e);
			Validating += (s, e) => ThrowEvent("VwSysProcessValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysProcess(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcess_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysProcess_BaseEventsProcess<TEntity> : BPMSoft.Configuration.VwSysSchemaInWorkspace_BaseEventsProcess<TEntity> where TEntity : VwSysProcess
	{

		public VwSysProcess_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysProcess_BaseEventsProcess";
			SchemaUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229");
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

	#region Class: VwSysProcess_BaseEventsProcess

	/// <exclude/>
	public class VwSysProcess_BaseEventsProcess : VwSysProcess_BaseEventsProcess<VwSysProcess>
	{

		public VwSysProcess_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysProcess_BaseEventsProcess

	public partial class VwSysProcess_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysProcessEventsProcess

	/// <exclude/>
	public class VwSysProcessEventsProcess : VwSysProcess_BaseEventsProcess
	{

		public VwSysProcessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

