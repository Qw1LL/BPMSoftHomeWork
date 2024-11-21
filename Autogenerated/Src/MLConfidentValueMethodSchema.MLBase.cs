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

	#region Class: MLConfidentValueMethodSchema

	/// <exclude/>
	public class MLConfidentValueMethodSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MLConfidentValueMethodSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLConfidentValueMethodSchema(MLConfidentValueMethodSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLConfidentValueMethodSchema(MLConfidentValueMethodSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b41eaba-7a85-49f5-b32b-3cdf47f7619b");
			RealUId = new Guid("0b41eaba-7a85-49f5-b32b-3cdf47f7619b");
			Name = "MLConfidentValueMethod";
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
			return new MLConfidentValueMethod(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLConfidentValueMethod_MLBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLConfidentValueMethodSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLConfidentValueMethodSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b41eaba-7a85-49f5-b32b-3cdf47f7619b"));
		}

		#endregion

	}

	#endregion

	#region Class: MLConfidentValueMethod

	/// <summary>
	/// Confident value selection method.
	/// </summary>
	public class MLConfidentValueMethod : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MLConfidentValueMethod(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLConfidentValueMethod";
		}

		public MLConfidentValueMethod(MLConfidentValueMethod source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLConfidentValueMethod_MLBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MLConfidentValueMethod(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLConfidentValueMethod_MLBaseEventsProcess

	/// <exclude/>
	public partial class MLConfidentValueMethod_MLBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MLConfidentValueMethod
	{

		public MLConfidentValueMethod_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLConfidentValueMethod_MLBaseEventsProcess";
			SchemaUId = new Guid("0b41eaba-7a85-49f5-b32b-3cdf47f7619b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0b41eaba-7a85-49f5-b32b-3cdf47f7619b");
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

	#region Class: MLConfidentValueMethod_MLBaseEventsProcess

	/// <exclude/>
	public class MLConfidentValueMethod_MLBaseEventsProcess : MLConfidentValueMethod_MLBaseEventsProcess<MLConfidentValueMethod>
	{

		public MLConfidentValueMethod_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLConfidentValueMethod_MLBaseEventsProcess

	public partial class MLConfidentValueMethod_MLBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLConfidentValueMethodEventsProcess

	/// <exclude/>
	public class MLConfidentValueMethodEventsProcess : MLConfidentValueMethod_MLBaseEventsProcess
	{

		public MLConfidentValueMethodEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

