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

	#region Class: DocumentProductSchema

	/// <exclude/>
	public class DocumentProductSchema : BPMSoft.Configuration.BaseProductEntrySchema
	{

		#region Constructors: Public

		public DocumentProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DocumentProductSchema(DocumentProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DocumentProductSchema(DocumentProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5bab82ce-a828-4259-8ed9-5416ea3a0113");
			RealUId = new Guid("5bab82ce-a828-4259-8ed9-5416ea3a0113");
			Name = "DocumentProduct";
			ParentSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			return new DocumentProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DocumentProduct_DocumentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DocumentProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DocumentProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5bab82ce-a828-4259-8ed9-5416ea3a0113"));
		}

		#endregion

	}

	#endregion

	#region Class: DocumentProduct

	/// <summary>
	/// Продукт в документе.
	/// </summary>
	public class DocumentProduct : BPMSoft.Configuration.BaseProductEntry
	{

		#region Constructors: Public

		public DocumentProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DocumentProduct";
		}

		public DocumentProduct(DocumentProduct source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DocumentProduct_DocumentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DocumentProductDeleted", e);
			Deleting += (s, e) => ThrowEvent("DocumentProductDeleting", e);
			Inserted += (s, e) => ThrowEvent("DocumentProductInserted", e);
			Inserting += (s, e) => ThrowEvent("DocumentProductInserting", e);
			Saved += (s, e) => ThrowEvent("DocumentProductSaved", e);
			Saving += (s, e) => ThrowEvent("DocumentProductSaving", e);
			Validating += (s, e) => ThrowEvent("DocumentProductValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DocumentProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: DocumentProduct_DocumentEventsProcess

	/// <exclude/>
	public partial class DocumentProduct_DocumentEventsProcess<TEntity> : BPMSoft.Configuration.BaseProductEntry_ProductCatalogueEventsProcess<TEntity> where TEntity : DocumentProduct
	{

		public DocumentProduct_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DocumentProduct_DocumentEventsProcess";
			SchemaUId = new Guid("5bab82ce-a828-4259-8ed9-5416ea3a0113");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5bab82ce-a828-4259-8ed9-5416ea3a0113");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("d5e8925e-16d4-40b1-813e-9e93a51896ae"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _documentProductSaved;
		public ProcessFlowElement DocumentProductSaved {
			get {
				return _documentProductSaved ?? (_documentProductSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "DocumentProductSaved",
					SchemaElementUId = new Guid("2a8d994e-20cc-47bc-a63d-2b4e0bd2f102"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _documentProductDeleted;
		public ProcessFlowElement DocumentProductDeleted {
			get {
				return _documentProductDeleted ?? (_documentProductDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "DocumentProductDeleted",
					SchemaElementUId = new Guid("74f1e84a-5397-4665-8de8-8cc927da6aba"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("05bcf640-754e-4158-a7c4-2018d556e4cd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _scriptAmountChange;
		public ProcessScriptTask ScriptAmountChange {
			get {
				return _scriptAmountChange ?? (_scriptAmountChange = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptAmountChange",
					SchemaElementUId = new Guid("eaada027-d022-4dc2-942e-4461de651d34"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptAmountChangeExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("b3e19716-0b9a-49d2-a7f0-ae66b4e33ba5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _documentProductSaving;
		public ProcessFlowElement DocumentProductSaving {
			get {
				return _documentProductSaving ?? (_documentProductSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "DocumentProductSaving",
					SchemaElementUId = new Guid("5e58d946-8a6b-4aee-a4b2-f19f2f5054a5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _documentProductSavingScriptTask;
		public ProcessScriptTask DocumentProductSavingScriptTask {
			get {
				return _documentProductSavingScriptTask ?? (_documentProductSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DocumentProductSavingScriptTask",
					SchemaElementUId = new Guid("defc0132-948f-4f10-b7c0-68fdf239474d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = DocumentProductSavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[DocumentProductSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { DocumentProductSaved };
			FlowElements[DocumentProductDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { DocumentProductDeleted };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ScriptAmountChange.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptAmountChange };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[DocumentProductSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { DocumentProductSaving };
			FlowElements[DocumentProductSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { DocumentProductSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "DocumentProductSaved":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "DocumentProductDeleted":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "ExclusiveGateway1":
							e.Context.QueueTasks.Enqueue("ScriptAmountChange");
						break;
					case "ScriptAmountChange":
						break;
					case "EventSubProcess2":
						break;
					case "DocumentProductSaving":
						e.Context.QueueTasks.Enqueue("DocumentProductSavingScriptTask");
						break;
					case "DocumentProductSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("DocumentProductSaved");
			ActivatedEventElements.Add("DocumentProductDeleted");
			ActivatedEventElements.Add("DocumentProductSaving");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "DocumentProductSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "DocumentProductSaved";
					result = DocumentProductSaved.Execute(context);
					break;
				case "DocumentProductDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "DocumentProductDeleted";
					result = DocumentProductDeleted.Execute(context);
					break;
				case "ExclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway1";
					result = ExclusiveGateway1.Execute(context);
					break;
				case "ScriptAmountChange":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptAmountChange";
					result = ScriptAmountChange.Execute(context, ScriptAmountChangeExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "DocumentProductSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "DocumentProductSaving";
					result = DocumentProductSaving.Execute(context);
					break;
				case "DocumentProductSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "DocumentProductSavingScriptTask";
					result = DocumentProductSavingScriptTask.Execute(context, DocumentProductSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptAmountChangeExecute(ProcessExecutingContext context) {
			UpdateTotalAmmount(context);
			return true;
		}

		public virtual bool DocumentProductSavingScriptTaskExecute(ProcessExecutingContext context) {
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "DocumentProductSaved":
							if (ActivatedEventElements.Contains("DocumentProductSaved")) {
							context.QueueTasks.Enqueue("DocumentProductSaved");
						}
						break;
					case "DocumentProductDeleted":
							if (ActivatedEventElements.Contains("DocumentProductDeleted")) {
							context.QueueTasks.Enqueue("DocumentProductDeleted");
						}
						break;
					case "DocumentProductSaving":
							if (ActivatedEventElements.Contains("DocumentProductSaving")) {
							context.QueueTasks.Enqueue("DocumentProductSaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: DocumentProduct_DocumentEventsProcess

	/// <exclude/>
	public class DocumentProduct_DocumentEventsProcess : DocumentProduct_DocumentEventsProcess<DocumentProduct>
	{

		public DocumentProduct_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DocumentProduct_DocumentEventsProcess

	public partial class DocumentProduct_DocumentEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void UpdateTotalAmmount(ProcessExecutingContext context) {
		}

		#endregion

	}

	#endregion


	#region Class: DocumentProductEventsProcess

	/// <exclude/>
	public class DocumentProductEventsProcess : DocumentProduct_DocumentEventsProcess
	{

		public DocumentProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

