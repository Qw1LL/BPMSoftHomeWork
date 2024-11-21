namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.Passport;
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

	#region Class: OrderProduct_Passport_BPMSoftSchema

	/// <exclude/>
	public class OrderProduct_Passport_BPMSoftSchema : BPMSoft.Configuration.OrderProduct_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public OrderProduct_Passport_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderProduct_Passport_BPMSoftSchema(OrderProduct_Passport_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderProduct_Passport_BPMSoftSchema(OrderProduct_Passport_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("a4db212d-a935-4e07-85be-0f44f761c227");
			Name = "OrderProduct_Passport_BPMSoft";
			ParentSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("5ad21e1a-95d7-43e1-8821-5a5bb2a4bde1");
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
			return new OrderProduct_Passport_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderProduct_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderProduct_Passport_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderProduct_Passport_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a4db212d-a935-4e07-85be-0f44f761c227"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderProduct_Passport_BPMSoft

	/// <summary>
	/// Продукт в заказе.
	/// </summary>
	public class OrderProduct_Passport_BPMSoft : BPMSoft.Configuration.OrderProduct_Order_BPMSoft
	{

		#region Constructors: Public

		public OrderProduct_Passport_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderProduct_Passport_BPMSoft";
		}

		public OrderProduct_Passport_BPMSoft(OrderProduct_Passport_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrderProduct_PassportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OrderProduct_Passport_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("OrderProduct_Passport_BPMSoftDeleting", e);
			Saved += (s, e) => ThrowEvent("OrderProduct_Passport_BPMSoftSaved", e);
			Validating += (s, e) => ThrowEvent("OrderProduct_Passport_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrderProduct_Passport_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderProduct_PassportEventsProcess

	/// <exclude/>
	public partial class OrderProduct_PassportEventsProcess<TEntity> : BPMSoft.Configuration.OrderProduct_OrderEventsProcess<TEntity> where TEntity : OrderProduct_Passport_BPMSoft
	{

		public OrderProduct_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderProduct_PassportEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a4db212d-a935-4e07-85be-0f44f761c227");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Object SupplyPaymentElementsToRecalc {
			get;
			set;
		}

		private ProcessFlowElement _beforeDeleteEventSubProcess;
		public ProcessFlowElement BeforeDeleteEventSubProcess {
			get {
				return _beforeDeleteEventSubProcess ?? (_beforeDeleteEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BeforeDeleteEventSubProcess",
					SchemaElementUId = new Guid("f0d29e68-a154-4045-b2a3-aa28b1d224f3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _orderProductDeletingStartMessage;
		public ProcessFlowElement OrderProductDeletingStartMessage {
			get {
				return _orderProductDeletingStartMessage ?? (_orderProductDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OrderProductDeletingStartMessage",
					SchemaElementUId = new Guid("30f14d8f-e6ec-447a-85b6-da4e2a8a1bea"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _passportBeforeDeleteScriptTask;
		public ProcessScriptTask PassportBeforeDeleteScriptTask {
			get {
				return _passportBeforeDeleteScriptTask ?? (_passportBeforeDeleteScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PassportBeforeDeleteScriptTask",
					SchemaElementUId = new Guid("648cabb4-e1c3-4b9a-b268-a9efc731e79d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PassportBeforeDeleteScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BeforeDeleteEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BeforeDeleteEventSubProcess };
			FlowElements[OrderProductDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { OrderProductDeletingStartMessage };
			FlowElements[PassportBeforeDeleteScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PassportBeforeDeleteScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BeforeDeleteEventSubProcess":
						break;
					case "OrderProductDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("PassportBeforeDeleteScriptTask");
						break;
					case "PassportBeforeDeleteScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("OrderProductDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BeforeDeleteEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "OrderProductDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "OrderProductDeletingStartMessage";
					result = OrderProductDeletingStartMessage.Execute(context);
					break;
				case "PassportBeforeDeleteScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PassportBeforeDeleteScriptTask";
					result = PassportBeforeDeleteScriptTask.Execute(context, PassportBeforeDeleteScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool PassportBeforeDeleteScriptTaskExecute(ProcessExecutingContext context) {
			var helper = ClassFactory.Get<OrderAmountHelper>(new ConstructorArgument("userConnection", UserConnection));
			SupplyPaymentElementsToRecalc = helper.GetSupplyPaymentElementIdsByOrderProduct(Entity.PrimaryColumnValue);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "OrderProduct_Passport_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("OrderProductDeletingStartMessage")) {
							context.QueueTasks.Enqueue("OrderProductDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: OrderProduct_PassportEventsProcess

	/// <exclude/>
	public class OrderProduct_PassportEventsProcess : OrderProduct_PassportEventsProcess<OrderProduct_Passport_BPMSoft>
	{

		public OrderProduct_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderProduct_PassportEventsProcess

	public partial class OrderProduct_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void RecalculateOrderAmount() {
			base.RecalculateOrderAmount();
			var helper = ClassFactory.Get<OrderAmountHelper>(new ConstructorArgument("userConnection", UserConnection));
			if (IsProductDeleted){
				if (SupplyPaymentElementsToRecalc != null) {
					var speIds = (List<Guid>)SupplyPaymentElementsToRecalc;
					helper.OnOrderProductDeleted(Entity.GetTypedColumnValue<Guid>("OrderId"), speIds);
				}
			} else {
				var changedColumnValues = ChangedColumnValues as IEnumerable<EntityColumnValue>;
				helper.OnOrderProductChanged(Entity.PrimaryColumnValue, changedColumnValues);
			}
		}

		public override void UpdatePrimaryAmounts() {
			if (NeedRecalcPrimaryValues){
				base.UpdatePrimaryAmounts();
			}
		}

		#endregion

	}

	#endregion

}

