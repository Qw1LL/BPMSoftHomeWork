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

	#region Class: MLTaskStartMethodSchema

	/// <exclude/>
	public class MLTaskStartMethodSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MLTaskStartMethodSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLTaskStartMethodSchema(MLTaskStartMethodSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLTaskStartMethodSchema(MLTaskStartMethodSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f4f5ebb7-7a26-4894-b9ef-16d25c13d0f9");
			RealUId = new Guid("f4f5ebb7-7a26-4894-b9ef-16d25c13d0f9");
			Name = "MLTaskStartMethod";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
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
			return new MLTaskStartMethod(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLTaskStartMethod_MLBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLTaskStartMethodSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLTaskStartMethodSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f4f5ebb7-7a26-4894-b9ef-16d25c13d0f9"));
		}

		#endregion

	}

	#endregion

	#region Class: MLTaskStartMethod

	/// <summary>
	/// MLTaskStartMethod.
	/// </summary>
	public class MLTaskStartMethod : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MLTaskStartMethod(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLTaskStartMethod";
		}

		public MLTaskStartMethod(MLTaskStartMethod source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLTaskStartMethod_MLBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MLTaskStartMethodDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MLTaskStartMethod(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLTaskStartMethod_MLBaseEventsProcess

	/// <exclude/>
	public partial class MLTaskStartMethod_MLBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MLTaskStartMethod
	{

		public MLTaskStartMethod_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLTaskStartMethod_MLBaseEventsProcess";
			SchemaUId = new Guid("f4f5ebb7-7a26-4894-b9ef-16d25c13d0f9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f4f5ebb7-7a26-4894-b9ef-16d25c13d0f9");
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

	#region Class: MLTaskStartMethod_MLBaseEventsProcess

	/// <exclude/>
	public class MLTaskStartMethod_MLBaseEventsProcess : MLTaskStartMethod_MLBaseEventsProcess<MLTaskStartMethod>
	{

		public MLTaskStartMethod_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLTaskStartMethod_MLBaseEventsProcess

	public partial class MLTaskStartMethod_MLBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLTaskStartMethodEventsProcess

	/// <exclude/>
	public class MLTaskStartMethodEventsProcess : MLTaskStartMethod_MLBaseEventsProcess
	{

		public MLTaskStartMethodEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

