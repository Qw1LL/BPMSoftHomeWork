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

	#region Class: OrderDeliveryStatusSchema

	/// <exclude/>
	public class OrderDeliveryStatusSchema : BPMSoft.Configuration.OrderDeliveryStatus_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public OrderDeliveryStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderDeliveryStatusSchema(OrderDeliveryStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderDeliveryStatusSchema(OrderDeliveryStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("b2b850ee-0f72-49a8-a176-d7adcce0eccb");
			Name = "OrderDeliveryStatus";
			ParentSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
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
			return new OrderDeliveryStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderDeliveryStatus_PRMOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderDeliveryStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderDeliveryStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b2b850ee-0f72-49a8-a176-d7adcce0eccb"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderDeliveryStatus

	/// <summary>
	/// Состояние поставки заказа.
	/// </summary>
	public class OrderDeliveryStatus : BPMSoft.Configuration.OrderDeliveryStatus_Order_BPMSoft
	{

		#region Constructors: Public

		public OrderDeliveryStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderDeliveryStatus";
		}

		public OrderDeliveryStatus(OrderDeliveryStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrderDeliveryStatus_PRMOrderEventsProcess(UserConnection);
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
			return new OrderDeliveryStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderDeliveryStatus_PRMOrderEventsProcess

	/// <exclude/>
	public partial class OrderDeliveryStatus_PRMOrderEventsProcess<TEntity> : BPMSoft.Configuration.OrderDeliveryStatus_OrderEventsProcess<TEntity> where TEntity : OrderDeliveryStatus
	{

		public OrderDeliveryStatus_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderDeliveryStatus_PRMOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b2b850ee-0f72-49a8-a176-d7adcce0eccb");
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

	#region Class: OrderDeliveryStatus_PRMOrderEventsProcess

	/// <exclude/>
	public class OrderDeliveryStatus_PRMOrderEventsProcess : OrderDeliveryStatus_PRMOrderEventsProcess<OrderDeliveryStatus>
	{

		public OrderDeliveryStatus_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderDeliveryStatus_PRMOrderEventsProcess

	public partial class OrderDeliveryStatus_PRMOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OrderDeliveryStatusEventsProcess

	/// <exclude/>
	public class OrderDeliveryStatusEventsProcess : OrderDeliveryStatus_PRMOrderEventsProcess
	{

		public OrderDeliveryStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

