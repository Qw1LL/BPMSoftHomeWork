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

	#region Class: OrderStatusSchema

	/// <exclude/>
	public class OrderStatusSchema : BPMSoft.Configuration.OrderStatus_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public OrderStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderStatusSchema(OrderStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderStatusSchema(OrderStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("237151c6-d357-4d4c-92d3-1a3550b19e7d");
			Name = "OrderStatus";
			ParentSchemaUId = new Guid("41201050-146e-47a5-8952-c3d0242e0787");
			ExtendParent = true;
			CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
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
			return new OrderStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderStatus_PRMOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("237151c6-d357-4d4c-92d3-1a3550b19e7d"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderStatus

	/// <summary>
	/// Состояние заказа.
	/// </summary>
	public class OrderStatus : BPMSoft.Configuration.OrderStatus_Order_BPMSoft
	{

		#region Constructors: Public

		public OrderStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderStatus";
		}

		public OrderStatus(OrderStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrderStatus_PRMOrderEventsProcess(UserConnection);
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
			return new OrderStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderStatus_PRMOrderEventsProcess

	/// <exclude/>
	public partial class OrderStatus_PRMOrderEventsProcess<TEntity> : BPMSoft.Configuration.OrderStatus_OrderEventsProcess<TEntity> where TEntity : OrderStatus
	{

		public OrderStatus_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderStatus_PRMOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("237151c6-d357-4d4c-92d3-1a3550b19e7d");
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

	#region Class: OrderStatus_PRMOrderEventsProcess

	/// <exclude/>
	public class OrderStatus_PRMOrderEventsProcess : OrderStatus_PRMOrderEventsProcess<OrderStatus>
	{

		public OrderStatus_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderStatus_PRMOrderEventsProcess

	public partial class OrderStatus_PRMOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OrderStatusEventsProcess

	/// <exclude/>
	public class OrderStatusEventsProcess : OrderStatus_PRMOrderEventsProcess
	{

		public OrderStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

