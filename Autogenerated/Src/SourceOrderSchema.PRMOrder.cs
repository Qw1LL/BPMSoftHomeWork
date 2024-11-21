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

	#region Class: SourceOrderSchema

	/// <exclude/>
	public class SourceOrderSchema : BPMSoft.Configuration.SourceOrder_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public SourceOrderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SourceOrderSchema(SourceOrderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SourceOrderSchema(SourceOrderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("9689a827-d665-405a-b0fd-3478e8262cd9");
			Name = "SourceOrder";
			ParentSchemaUId = new Guid("ccfa0e1e-c7fb-4251-8fbc-b59e0817f7ed");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c09bcc89-cd4a-49df-a8fa-3a15879bc3c5");
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
			return new SourceOrder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SourceOrder_PRMOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SourceOrderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SourceOrderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9689a827-d665-405a-b0fd-3478e8262cd9"));
		}

		#endregion

	}

	#endregion

	#region Class: SourceOrder

	/// <summary>
	/// Источник заказа.
	/// </summary>
	public class SourceOrder : BPMSoft.Configuration.SourceOrder_Order_BPMSoft
	{

		#region Constructors: Public

		public SourceOrder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SourceOrder";
		}

		public SourceOrder(SourceOrder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SourceOrder_PRMOrderEventsProcess(UserConnection);
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
			return new SourceOrder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SourceOrder_PRMOrderEventsProcess

	/// <exclude/>
	public partial class SourceOrder_PRMOrderEventsProcess<TEntity> : BPMSoft.Configuration.SourceOrder_OrderEventsProcess<TEntity> where TEntity : SourceOrder
	{

		public SourceOrder_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SourceOrder_PRMOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9689a827-d665-405a-b0fd-3478e8262cd9");
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

	#region Class: SourceOrder_PRMOrderEventsProcess

	/// <exclude/>
	public class SourceOrder_PRMOrderEventsProcess : SourceOrder_PRMOrderEventsProcess<SourceOrder>
	{

		public SourceOrder_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SourceOrder_PRMOrderEventsProcess

	public partial class SourceOrder_PRMOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SourceOrderEventsProcess

	/// <exclude/>
	public class SourceOrderEventsProcess : SourceOrder_PRMOrderEventsProcess
	{

		public SourceOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

