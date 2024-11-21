namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: Order_Passport_BPMSoftSchema

	/// <exclude/>
	public class Order_Passport_BPMSoftSchema : BPMSoft.Configuration.Order_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public Order_Passport_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Order_Passport_BPMSoftSchema(Order_Passport_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Order_Passport_BPMSoftSchema(Order_Passport_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("f2688517-820b-4f01-9361-0ce31cc5a1d2");
			Name = "Order_Passport_BPMSoft";
			ParentSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71");
			ExtendParent = true;
			CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a");
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
			return new Order_Passport_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Order_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Order_Passport_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Order_Passport_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f2688517-820b-4f01-9361-0ce31cc5a1d2"));
		}

		#endregion

	}

	#endregion

	#region Class: Order_Passport_BPMSoft

	/// <summary>
	/// Заказ.
	/// </summary>
	public class Order_Passport_BPMSoft : BPMSoft.Configuration.Order_Order_BPMSoft
	{

		#region Constructors: Public

		public Order_Passport_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Order_Passport_BPMSoft";
		}

		public Order_Passport_BPMSoft(Order_Passport_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Order_PassportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Order_Passport_BPMSoftDeleted", e);
			Inserted += (s, e) => ThrowEvent("Order_Passport_BPMSoftInserted", e);
			Saved += (s, e) => ThrowEvent("Order_Passport_BPMSoftSaved", e);
			Validating += (s, e) => ThrowEvent("Order_Passport_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Order_Passport_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Order_PassportEventsProcess

	/// <exclude/>
	public partial class Order_PassportEventsProcess<TEntity> : BPMSoft.Configuration.Order_OrderEventsProcess<TEntity> where TEntity : Order_Passport_BPMSoft
	{

		public Order_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Order_PassportEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f2688517-820b-4f01-9361-0ce31cc5a1d2");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _passportOrderInsertedEventSubProcess;
		public ProcessFlowElement PassportOrderInsertedEventSubProcess {
			get {
				return _passportOrderInsertedEventSubProcess ?? (_passportOrderInsertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "PassportOrderInsertedEventSubProcess",
					SchemaElementUId = new Guid("66b3c66b-41b1-4a0f-85a2-1163185506b0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _passportOrderInsertedStartMessage;
		public ProcessFlowElement PassportOrderInsertedStartMessage {
			get {
				return _passportOrderInsertedStartMessage ?? (_passportOrderInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PassportOrderInsertedStartMessage",
					SchemaElementUId = new Guid("5b3e219b-6442-427d-ac11-126c4e9845c4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _createSupplyPaymentItemsScriptTask;
		public ProcessScriptTask CreateSupplyPaymentItemsScriptTask {
			get {
				return _createSupplyPaymentItemsScriptTask ?? (_createSupplyPaymentItemsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CreateSupplyPaymentItemsScriptTask",
					SchemaElementUId = new Guid("83042d05-8267-4714-8415-ad1468ddb281"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CreateSupplyPaymentItemsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[PassportOrderInsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { PassportOrderInsertedEventSubProcess };
			FlowElements[PassportOrderInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { PassportOrderInsertedStartMessage };
			FlowElements[CreateSupplyPaymentItemsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateSupplyPaymentItemsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "PassportOrderInsertedEventSubProcess":
						break;
					case "PassportOrderInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("CreateSupplyPaymentItemsScriptTask");
						break;
					case "CreateSupplyPaymentItemsScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("PassportOrderInsertedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "PassportOrderInsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "PassportOrderInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "PassportOrderInsertedStartMessage";
					result = PassportOrderInsertedStartMessage.Execute(context);
					break;
				case "CreateSupplyPaymentItemsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CreateSupplyPaymentItemsScriptTask";
					result = CreateSupplyPaymentItemsScriptTask.Execute(context, CreateSupplyPaymentItemsScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CreateSupplyPaymentItemsScriptTaskExecute(ProcessExecutingContext context) {
			CreateDefSupplyPaymentItems();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Order_Passport_BPMSoftInserted":
							if (ActivatedEventElements.Contains("PassportOrderInsertedStartMessage")) {
							context.QueueTasks.Enqueue("PassportOrderInsertedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Order_PassportEventsProcess

	/// <exclude/>
	public class Order_PassportEventsProcess : Order_PassportEventsProcess<Order_Passport_BPMSoft>
	{

		public Order_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Order_PassportEventsProcess

	public partial class Order_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CreateDefSupplyPaymentItems() {
			var passportHelper = ClassFactory.Get<BPMSoft.Configuration.Passport.OrderPassportHelper>(new ConstructorArgument("userConnection", UserConnection));
			passportHelper.SetTemplate(Entity.PrimaryColumnValue);
		}

		public override void UpdateProductAmounts() {
			base.UpdateProductAmounts();
			if (NeedFinRecalc) {
				var orderAmountHelper = ClassFactory.Get<BPMSoft.Configuration.Passport.OrderAmountHelper>(new ConstructorArgument("userConnection", UserConnection));
				orderAmountHelper.UpdateAmountsByOrderId(Entity.GetTypedColumnValue<Guid>("Id"));
			}
		}

		#endregion

	}

	#endregion

}

