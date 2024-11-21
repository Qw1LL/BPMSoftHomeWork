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

	#region Class: TouchQueueOpSchema

	/// <exclude/>
	public class TouchQueueOpSchema : BPMSoft.Configuration.TouchQueueSchema
	{

		#region Constructors: Public

		public TouchQueueOpSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TouchQueueOpSchema(TouchQueueOpSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TouchQueueOpSchema(TouchQueueOpSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b65de3be-f9ee-4013-9012-a02d6648636d");
			RealUId = new Guid("b65de3be-f9ee-4013-9012-a02d6648636d");
			Name = "TouchQueueOp";
			ParentSchemaUId = new Guid("8e06adb6-61a3-48e5-ad4e-908b3909fc32");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a");
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
			return new TouchQueueOp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TouchQueueOp_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TouchQueueOpSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TouchQueueOpSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b65de3be-f9ee-4013-9012-a02d6648636d"));
		}

		#endregion

	}

	#endregion

	#region Class: TouchQueueOp

	/// <summary>
	/// TouchQueueOp.
	/// </summary>
	public class TouchQueueOp : BPMSoft.Configuration.TouchQueue
	{

		#region Constructors: Public

		public TouchQueueOp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TouchQueueOp";
		}

		public TouchQueueOp(TouchQueueOp source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TouchQueueOp_TouchPointsEventsProcess(UserConnection);
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
			return new TouchQueueOp(this);
		}

		#endregion

	}

	#endregion

	#region Class: TouchQueueOp_TouchPointsEventsProcess

	/// <exclude/>
	public partial class TouchQueueOp_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.TouchQueue_TouchPointsEventsProcess<TEntity> where TEntity : TouchQueueOp
	{

		public TouchQueueOp_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TouchQueueOp_TouchPointsEventsProcess";
			SchemaUId = new Guid("b65de3be-f9ee-4013-9012-a02d6648636d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b65de3be-f9ee-4013-9012-a02d6648636d");
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

	#region Class: TouchQueueOp_TouchPointsEventsProcess

	/// <exclude/>
	public class TouchQueueOp_TouchPointsEventsProcess : TouchQueueOp_TouchPointsEventsProcess<TouchQueueOp>
	{

		public TouchQueueOp_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TouchQueueOp_TouchPointsEventsProcess

	public partial class TouchQueueOp_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TouchQueueOpEventsProcess

	/// <exclude/>
	public class TouchQueueOpEventsProcess : TouchQueueOp_TouchPointsEventsProcess
	{

		public TouchQueueOpEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

