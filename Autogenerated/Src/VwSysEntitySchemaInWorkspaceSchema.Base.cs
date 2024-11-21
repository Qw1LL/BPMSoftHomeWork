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

	#region Class: VwSysEntitySchemaInWorkspaceSchema

	/// <exclude/>
	public class VwSysEntitySchemaInWorkspaceSchema : BPMSoft.Configuration.VwSysSchemaInWorkspaceSchema
	{

		#region Constructors: Public

		public VwSysEntitySchemaInWorkspaceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysEntitySchemaInWorkspaceSchema(VwSysEntitySchemaInWorkspaceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysEntitySchemaInWorkspaceSchema(VwSysEntitySchemaInWorkspaceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111");
			RealUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111");
			Name = "VwSysEntitySchemaInWorkspace";
			ParentSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			DesignLocalizationSchemaName = @"VwSysEntityInWorkspaceLcz";
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1f63f50c-e413-4992-9baf-7de2310a1149")) == null) {
				Columns.Add(CreateIsVirtualColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsVirtualColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1f63f50c-e413-4992-9baf-7de2310a1149"),
				Name = @"IsVirtual",
				CreatedInSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				ModifiedInSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				CreatedInPackageId = new Guid("003972a7-ed7e-4a15-aed6-e95d2dfe05dc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysEntitySchemaInWorkspace(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysEntitySchemaInWorkspace_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysEntitySchemaInWorkspaceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysEntitySchemaInWorkspaceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysEntitySchemaInWorkspace

	/// <summary>
	/// Object in workspace configuration (view).
	/// </summary>
	public class VwSysEntitySchemaInWorkspace : BPMSoft.Configuration.VwSysSchemaInWorkspace
	{

		#region Constructors: Public

		public VwSysEntitySchemaInWorkspace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysEntitySchemaInWorkspace";
		}

		public VwSysEntitySchemaInWorkspace(VwSysEntitySchemaInWorkspace source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		public bool IsVirtual {
			get {
				return GetTypedColumnValue<bool>("IsVirtual");
			}
			set {
				SetColumnValue("IsVirtual", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysEntitySchemaInWorkspace_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysEntitySchemaInWorkspaceDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysEntitySchemaInWorkspaceDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysEntitySchemaInWorkspaceInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysEntitySchemaInWorkspaceInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysEntitySchemaInWorkspaceSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysEntitySchemaInWorkspaceSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysEntitySchemaInWorkspaceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysEntitySchemaInWorkspace(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysEntitySchemaInWorkspace_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysEntitySchemaInWorkspace_BaseEventsProcess<TEntity> : BPMSoft.Configuration.VwSysSchemaInWorkspace_BaseEventsProcess<TEntity> where TEntity : VwSysEntitySchemaInWorkspace
	{

		public VwSysEntitySchemaInWorkspace_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysEntitySchemaInWorkspace_BaseEventsProcess";
			SchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111");
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

	#region Class: VwSysEntitySchemaInWorkspace_BaseEventsProcess

	/// <exclude/>
	public class VwSysEntitySchemaInWorkspace_BaseEventsProcess : VwSysEntitySchemaInWorkspace_BaseEventsProcess<VwSysEntitySchemaInWorkspace>
	{

		public VwSysEntitySchemaInWorkspace_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysEntitySchemaInWorkspace_BaseEventsProcess

	public partial class VwSysEntitySchemaInWorkspace_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysEntitySchemaInWorkspaceEventsProcess

	/// <exclude/>
	public class VwSysEntitySchemaInWorkspaceEventsProcess : VwSysEntitySchemaInWorkspace_BaseEventsProcess
	{

		public VwSysEntitySchemaInWorkspaceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

