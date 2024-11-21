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

	#region Class: MLModelStateSchema

	/// <exclude/>
	public class MLModelStateSchema : BPMSoft.Configuration.SysCodeLookupSchema
	{

		#region Constructors: Public

		public MLModelStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLModelStateSchema(MLModelStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLModelStateSchema(MLModelStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("83a4b85c-3c8f-45c5-bb2c-ee6a45ba8cdc");
			RealUId = new Guid("83a4b85c-3c8f-45c5-bb2c-ee6a45ba8cdc");
			Name = "MLModelState";
			ParentSchemaUId = new Guid("28699730-9cf0-4702-87a9-c64d612e4b14");
			ExtendParent = false;
			CreatedInPackageId = new Guid("62fdb191-1544-4399-9d20-c308d8466eaa");
			IsDBView = false;
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
			return new MLModelState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLModelState_MLBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLModelStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLModelStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("83a4b85c-3c8f-45c5-bb2c-ee6a45ba8cdc"));
		}

		#endregion

	}

	#endregion

	#region Class: MLModelState

	/// <summary>
	/// ML model state.
	/// </summary>
	public class MLModelState : BPMSoft.Configuration.SysCodeLookup
	{

		#region Constructors: Public

		public MLModelState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLModelState";
		}

		public MLModelState(MLModelState source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLModelState_MLBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MLModelStateDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MLModelState(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLModelState_MLBaseEventsProcess

	/// <exclude/>
	public partial class MLModelState_MLBaseEventsProcess<TEntity> : BPMSoft.Configuration.SysCodeLookup_BaseEventsProcess<TEntity> where TEntity : MLModelState
	{

		public MLModelState_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLModelState_MLBaseEventsProcess";
			SchemaUId = new Guid("83a4b85c-3c8f-45c5-bb2c-ee6a45ba8cdc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("83a4b85c-3c8f-45c5-bb2c-ee6a45ba8cdc");
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

	#region Class: MLModelState_MLBaseEventsProcess

	/// <exclude/>
	public class MLModelState_MLBaseEventsProcess : MLModelState_MLBaseEventsProcess<MLModelState>
	{

		public MLModelState_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLModelState_MLBaseEventsProcess

	public partial class MLModelState_MLBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLModelStateEventsProcess

	/// <exclude/>
	public class MLModelStateEventsProcess : MLModelState_MLBaseEventsProcess
	{

		public MLModelStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

