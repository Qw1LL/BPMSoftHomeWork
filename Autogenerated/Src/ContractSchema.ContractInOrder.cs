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

	#region Class: ContractSchema

	/// <exclude/>
	public class ContractSchema : BPMSoft.Configuration.Contract_SalesContracts_BPMSoftSchema
	{

		#region Constructors: Public

		public ContractSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContractSchema(ContractSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContractSchema(ContractSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("045d818c-9760-4555-9b59-7b6158c6b816");
			Name = "Contract";
			ParentSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810");
			ExtendParent = true;
			CreatedInPackageId = new Guid("2a36bdd9-0ef6-48f3-957f-b7efa409d0a7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fe23692e-01f1-476d-9605-3a1fede76644")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fe23692e-01f1-476d-9605-3a1fede76644"),
				Name = @"Order",
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("045d818c-9760-4555-9b59-7b6158c6b816"),
				ModifiedInSchemaUId = new Guid("045d818c-9760-4555-9b59-7b6158c6b816"),
				CreatedInPackageId = new Guid("2a36bdd9-0ef6-48f3-957f-b7efa409d0a7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Contract(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contract_ContractInOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContractSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContractSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("045d818c-9760-4555-9b59-7b6158c6b816"));
		}

		#endregion

	}

	#endregion

	#region Class: Contract

	/// <summary>
	/// Договор.
	/// </summary>
	public class Contract : BPMSoft.Configuration.Contract_SalesContracts_BPMSoft
	{

		#region Constructors: Public

		public Contract(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contract";
		}

		public Contract(Contract source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OrderId {
			get {
				return GetTypedColumnValue<Guid>("OrderId");
			}
			set {
				SetColumnValue("OrderId", value);
				_order = null;
			}
		}

		/// <exclude/>
		public string OrderNumber {
			get {
				return GetTypedColumnValue<string>("OrderNumber");
			}
			set {
				SetColumnValue("OrderNumber", value);
				if (_order != null) {
					_order.Number = value;
				}
			}
		}

		private Order _order;
		/// <summary>
		/// Заказ.
		/// </summary>
		public Order Order {
			get {
				return _order ??
					(_order = LookupColumnEntities.GetEntity("Order") as Order);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Contract_ContractInOrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContractDeleted", e);
			Deleting += (s, e) => ThrowEvent("ContractDeleting", e);
			Saved += (s, e) => ThrowEvent("ContractSaved", e);
			Saving += (s, e) => ThrowEvent("ContractSaving", e);
			Validating += (s, e) => ThrowEvent("ContractValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Contract(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contract_ContractInOrderEventsProcess

	/// <exclude/>
	public partial class Contract_ContractInOrderEventsProcess<TEntity> : BPMSoft.Configuration.Contract_SalesContractsEventsProcess<TEntity> where TEntity : Contract
	{

		public Contract_ContractInOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contract_ContractInOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("045d818c-9760-4555-9b59-7b6158c6b816");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid oldOrderId {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcessContractSaving;
		public ProcessFlowElement EventSubProcessContractSaving {
			get {
				return _eventSubProcessContractSaving ?? (_eventSubProcessContractSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcessContractSaving",
					SchemaElementUId = new Guid("b1ed7dfb-b4d1-4adf-8967-1ff041663f64"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContractSaving;
		public ProcessScriptTask ScriptContractSaving {
			get {
				return _scriptContractSaving ?? (_scriptContractSaving = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContractSaving",
					SchemaElementUId = new Guid("cbf016a7-201d-418f-8a8f-f811accb0aef"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContractSavingExecute,
				});
			}
		}

		private ProcessFlowElement _contractSaving;
		public ProcessFlowElement ContractSaving {
			get {
				return _contractSaving ?? (_contractSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContractSaving",
					SchemaElementUId = new Guid("efb0b775-7de6-475c-8faa-c1fadcfe0c6a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage1;
		public ProcessFlowElement StartMessage1 {
			get {
				return _startMessage1 ?? (_startMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1",
					SchemaElementUId = new Guid("22fe653a-ef27-4baa-a877-1b44a7f3af18"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContractSaved;
		public ProcessScriptTask ScriptContractSaved {
			get {
				return _scriptContractSaved ?? (_scriptContractSaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContractSaved",
					SchemaElementUId = new Guid("63ada70c-2379-4e06-9798-74c94cdfd02c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContractSavedExecute,
				});
			}
		}

		private ProcessFlowElement _contractDeleting;
		public ProcessFlowElement ContractDeleting {
			get {
				return _contractDeleting ?? (_contractDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContractDeleting",
					SchemaElementUId = new Guid("318899de-4ac6-4604-8d3f-50223dd539d6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContractDeleting;
		public ProcessScriptTask ScriptContractDeleting {
			get {
				return _scriptContractDeleting ?? (_scriptContractDeleting = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContractDeleting",
					SchemaElementUId = new Guid("d49e46b6-1618-4036-a186-94d866018fd8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContractDeletingExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcessContractSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcessContractSaving };
			FlowElements[ScriptContractSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContractSaving };
			FlowElements[ContractSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ContractSaving };
			FlowElements[StartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1 };
			FlowElements[ScriptContractSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContractSaved };
			FlowElements[ContractDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { ContractDeleting };
			FlowElements[ScriptContractDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContractDeleting };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcessContractSaving":
						break;
					case "ScriptContractSaving":
						break;
					case "ContractSaving":
						e.Context.QueueTasks.Enqueue("ScriptContractSaving");
						break;
					case "StartMessage1":
						e.Context.QueueTasks.Enqueue("ScriptContractSaved");
						break;
					case "ScriptContractSaved":
						break;
					case "ContractDeleting":
						e.Context.QueueTasks.Enqueue("ScriptContractDeleting");
						break;
					case "ScriptContractDeleting":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ContractSaving");
			ActivatedEventElements.Add("StartMessage1");
			ActivatedEventElements.Add("ContractDeleting");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcessContractSaving":
					context.QueueTasks.Dequeue();
					break;
				case "ScriptContractSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContractSaving";
					result = ScriptContractSaving.Execute(context, ScriptContractSavingExecute);
					break;
				case "ContractSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContractSaving";
					result = ContractSaving.Execute(context);
					break;
				case "StartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage1";
					result = StartMessage1.Execute(context);
					break;
				case "ScriptContractSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContractSaved";
					result = ScriptContractSaved.Execute(context, ScriptContractSavedExecute);
					break;
				case "ContractDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContractDeleting";
					result = ContractDeleting.Execute(context);
					break;
				case "ScriptContractDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContractDeleting";
					result = ScriptContractDeleting.Execute(context, ScriptContractDeletingExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptContractSavingExecute(ProcessExecutingContext context) {
			oldOrderId = Entity.GetTypedOldColumnValue<Guid>("OrderId");
			return true;
		}

		public virtual bool ScriptContractSavedExecute(ProcessExecutingContext context) {
			var OrderId = Entity.GetTypedColumnValue<Guid>("OrderId");
			var doUpdate = false;
			if (OrderId == null || OrderId.Equals(Guid.Empty)) {
				doUpdate = true;
			} else {
				if (OrderId != oldOrderId) {
					doUpdate = true;
				}
			}
			if (doUpdate) {
				var update = new Update(UserConnection, "OrderProduct")
								.Set("ContractId", Column.Const(null))
								.Where("OrderId").IsEqual(Column.Parameter(oldOrderId));
								update.Execute();	
			}
			return true;
		}

		public virtual bool ScriptContractDeletingExecute(ProcessExecutingContext context) {
			var OrderId = Entity.GetTypedColumnValue<Guid>("OrderId");
			var update = new Update(UserConnection, "OrderProduct")
							.Set("ContractId", Column.Const(null))
							.Where("OrderId").IsEqual(Column.Parameter(OrderId))
							.And("ContractId").IsEqual(Column.Parameter(Entity.Id));
							update.Execute();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ContractSaving":
							if (ActivatedEventElements.Contains("ContractSaving")) {
							context.QueueTasks.Enqueue("ContractSaving");
						}
						break;
					case "ContractSaved":
							if (ActivatedEventElements.Contains("StartMessage1")) {
							context.QueueTasks.Enqueue("StartMessage1");
						}
						break;
					case "ContractDeleting":
							if (ActivatedEventElements.Contains("ContractDeleting")) {
							context.QueueTasks.Enqueue("ContractDeleting");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Contract_ContractInOrderEventsProcess

	/// <exclude/>
	public class Contract_ContractInOrderEventsProcess : Contract_ContractInOrderEventsProcess<Contract>
	{

		public Contract_ContractInOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Contract_ContractInOrderEventsProcess

	public partial class Contract_ContractInOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContractEventsProcess

	/// <exclude/>
	public class ContractEventsProcess : Contract_ContractInOrderEventsProcess
	{

		public ContractEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

