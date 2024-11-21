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

	#region Class: VwSysSchemaInfoSchema

	/// <exclude/>
	public class VwSysSchemaInfoSchema : BPMSoft.Configuration.VwSysSchemaInWorkspaceSchema
	{

		#region Constructors: Public

		public VwSysSchemaInfoSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysSchemaInfoSchema(VwSysSchemaInfoSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysSchemaInfoSchema(VwSysSchemaInfoSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae");
			RealUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae");
			Name = "VwSysSchemaInfo";
			ParentSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysSchemaInfo(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysSchemaInfo_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysSchemaInfoSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysSchemaInfoSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaInfo

	/// <summary>
	/// Schema used in workspace (view) .
	/// </summary>
	public class VwSysSchemaInfo : BPMSoft.Configuration.VwSysSchemaInWorkspace
	{

		#region Constructors: Public

		public VwSysSchemaInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSchemaInfo";
		}

		public VwSysSchemaInfo(VwSysSchemaInfo source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysSchemaInfo_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysSchemaInfoDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysSchemaInfoDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysSchemaInfoInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysSchemaInfoInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysSchemaInfoSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysSchemaInfoSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysSchemaInfoValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysSchemaInfo(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaInfo_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysSchemaInfo_BaseEventsProcess<TEntity> : BPMSoft.Configuration.VwSysSchemaInWorkspace_BaseEventsProcess<TEntity> where TEntity : VwSysSchemaInfo
	{

		public VwSysSchemaInfo_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysSchemaInfo_BaseEventsProcess";
			SchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae");
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

	#region Class: VwSysSchemaInfo_BaseEventsProcess

	/// <exclude/>
	public class VwSysSchemaInfo_BaseEventsProcess : VwSysSchemaInfo_BaseEventsProcess<VwSysSchemaInfo>
	{

		public VwSysSchemaInfo_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysSchemaInfo_BaseEventsProcess

	public partial class VwSysSchemaInfo_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysSchemaInfoEventsProcess

	/// <exclude/>
	public class VwSysSchemaInfoEventsProcess : VwSysSchemaInfo_BaseEventsProcess
	{

		public VwSysSchemaInfoEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

