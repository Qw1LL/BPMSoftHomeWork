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

	#region Class: InvoiceProduct_Invoice_BPMSoftSchema

	/// <exclude/>
	public class InvoiceProduct_Invoice_BPMSoftSchema : BPMSoft.Configuration.BaseProductEntrySchema
	{

		#region Constructors: Public

		public InvoiceProduct_Invoice_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public InvoiceProduct_Invoice_BPMSoftSchema(InvoiceProduct_Invoice_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public InvoiceProduct_Invoice_BPMSoftSchema(InvoiceProduct_Invoice_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("732baa21-890b-4894-a457-623630e33a6f");
			RealUId = new Guid("732baa21-890b-4894-a457-623630e33a6f");
			Name = "InvoiceProduct_Invoice_BPMSoft";
			ParentSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("86bbc99f-1967-4f26-8394-3720e7d22144")) == null) {
				Columns.Add(CreateInvoiceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateInvoiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("86bbc99f-1967-4f26-8394-3720e7d22144"),
				Name = @"Invoice",
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("732baa21-890b-4894-a457-623630e33a6f"),
				ModifiedInSchemaUId = new Guid("732baa21-890b-4894-a457-623630e33a6f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new InvoiceProduct_Invoice_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new InvoiceProduct_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new InvoiceProduct_Invoice_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new InvoiceProduct_Invoice_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("732baa21-890b-4894-a457-623630e33a6f"));
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceProduct_Invoice_BPMSoft

	/// <summary>
	/// Продукт в счете.
	/// </summary>
	public class InvoiceProduct_Invoice_BPMSoft : BPMSoft.Configuration.BaseProductEntry
	{

		#region Constructors: Public

		public InvoiceProduct_Invoice_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InvoiceProduct_Invoice_BPMSoft";
		}

		public InvoiceProduct_Invoice_BPMSoft(InvoiceProduct_Invoice_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid InvoiceId {
			get {
				return GetTypedColumnValue<Guid>("InvoiceId");
			}
			set {
				SetColumnValue("InvoiceId", value);
				_invoice = null;
			}
		}

		/// <exclude/>
		public string InvoiceNumber {
			get {
				return GetTypedColumnValue<string>("InvoiceNumber");
			}
			set {
				SetColumnValue("InvoiceNumber", value);
				if (_invoice != null) {
					_invoice.Number = value;
				}
			}
		}

		private Invoice _invoice;
		/// <summary>
		/// Счет.
		/// </summary>
		public Invoice Invoice {
			get {
				return _invoice ??
					(_invoice = LookupColumnEntities.GetEntity("Invoice") as Invoice);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new InvoiceProduct_InvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("InvoiceProduct_Invoice_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("InvoiceProduct_Invoice_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("InvoiceProduct_Invoice_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("InvoiceProduct_Invoice_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("InvoiceProduct_Invoice_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("InvoiceProduct_Invoice_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("InvoiceProduct_Invoice_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new InvoiceProduct_Invoice_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceProduct_InvoiceEventsProcess

	/// <exclude/>
	public partial class InvoiceProduct_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseProductEntry_ProductCatalogueEventsProcess<TEntity> where TEntity : InvoiceProduct_Invoice_BPMSoft
	{

		public InvoiceProduct_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InvoiceProduct_InvoiceEventsProcess";
			SchemaUId = new Guid("732baa21-890b-4894-a457-623630e33a6f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("732baa21-890b-4894-a457-623630e33a6f");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _subProcessScriptAmountChange;
		public ProcessFlowElement SubProcessScriptAmountChange {
			get {
				return _subProcessScriptAmountChange ?? (_subProcessScriptAmountChange = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcessScriptAmountChange",
					SchemaElementUId = new Guid("4bd077a8-da39-4239-a2d0-055f6cb491cb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _invoiceProductSaved;
		public ProcessFlowElement InvoiceProductSaved {
			get {
				return _invoiceProductSaved ?? (_invoiceProductSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InvoiceProductSaved",
					SchemaElementUId = new Guid("f8d5afcd-6412-423c-be17-8b36c9264eb7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("7be32003-5969-418d-9f47-1107bc41de67"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptAmountChangeExecute,
				});
			}
		}

		private ProcessFlowElement _invoiceProductDeleted;
		public ProcessFlowElement InvoiceProductDeleted {
			get {
				return _invoiceProductDeleted ?? (_invoiceProductDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InvoiceProductDeleted",
					SchemaElementUId = new Guid("e58caf66-5923-41e7-ae22-5e38b3afab4f"),
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
					SchemaElementUId = new Guid("787d5a89-4cbc-49c5-b488-b8253792019e"),
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

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("5d01c5d0-ff6b-49e3-888b-24622b285f96"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _invoiceProductSaving;
		public ProcessFlowElement InvoiceProductSaving {
			get {
				return _invoiceProductSaving ?? (_invoiceProductSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InvoiceProductSaving",
					SchemaElementUId = new Guid("c916e8c0-6843-484a-8c19-9e28c85f9c7e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _invoiceProductSavingScriptTask;
		public ProcessScriptTask InvoiceProductSavingScriptTask {
			get {
				return _invoiceProductSavingScriptTask ?? (_invoiceProductSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "InvoiceProductSavingScriptTask",
					SchemaElementUId = new Guid("00ce74b0-f11b-45c7-bb37-9e10891970c1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = InvoiceProductSavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SubProcessScriptAmountChange.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcessScriptAmountChange };
			FlowElements[InvoiceProductSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { InvoiceProductSaved };
			FlowElements[ScriptAmountChange.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptAmountChange };
			FlowElements[InvoiceProductDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { InvoiceProductDeleted };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[InvoiceProductSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { InvoiceProductSaving };
			FlowElements[InvoiceProductSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { InvoiceProductSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SubProcessScriptAmountChange":
						break;
					case "InvoiceProductSaved":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "ScriptAmountChange":
						break;
					case "InvoiceProductDeleted":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "ExclusiveGateway1":
							e.Context.QueueTasks.Enqueue("ScriptAmountChange");
						break;
					case "EventSubProcess1":
						break;
					case "InvoiceProductSaving":
						e.Context.QueueTasks.Enqueue("InvoiceProductSavingScriptTask");
						break;
					case "InvoiceProductSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("InvoiceProductSaved");
			ActivatedEventElements.Add("InvoiceProductDeleted");
			ActivatedEventElements.Add("InvoiceProductSaving");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SubProcessScriptAmountChange":
					context.QueueTasks.Dequeue();
					break;
				case "InvoiceProductSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "InvoiceProductSaved";
					result = InvoiceProductSaved.Execute(context);
					break;
				case "ScriptAmountChange":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptAmountChange";
					result = ScriptAmountChange.Execute(context, ScriptAmountChangeExecute);
					break;
				case "InvoiceProductDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "InvoiceProductDeleted";
					result = InvoiceProductDeleted.Execute(context);
					break;
				case "ExclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway1";
					result = ExclusiveGateway1.Execute(context);
					break;
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "InvoiceProductSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "InvoiceProductSaving";
					result = InvoiceProductSaving.Execute(context);
					break;
				case "InvoiceProductSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "InvoiceProductSavingScriptTask";
					result = InvoiceProductSavingScriptTask.Execute(context, InvoiceProductSavingScriptTaskExecute);
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
			UpdateInvoiceAmount(UserConnection);
			
			/*var entitySchemaManager = this.UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
			EntitySchemaQuery invoiceProductEntitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, "InvoiceProduct");
			var invoiceIdColumn = invoiceProductEntitySchemaQuery.AddColumn("Invoice");
			var primaryAmountColumn = invoiceProductEntitySchemaQuery.AddColumn(invoiceProductEntitySchemaQuery.CreateAggregationFunction(AggregationTypeStrict.Sum, "PrimaryTotalAmount"));
			var amountColumn = invoiceProductEntitySchemaQuery.AddColumn(invoiceProductEntitySchemaQuery.CreateAggregationFunction(AggregationTypeStrict.Sum, "TotalAmount"));
			var filters = invoiceProductEntitySchemaQuery.Filters;
			var invoiceId = this.Entity.GetTypedColumnValue<Guid>("InvoiceId");
			filters.Add(invoiceProductEntitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Invoice", invoiceId));
			var entityCollection = invoiceProductEntitySchemaQuery.GetEntityCollection(this.UserConnection);
			var invoice = new Invoice(this.UserConnection);
			invoice.FetchFromDB(invoiceId);
			decimal PrimarySumTotalAmount = 0;
			decimal SumTotalAmount = 0;
			var discountPercent = invoice.GetTypedColumnValue<decimal>("DiscountPercent");
			decimal totalAmount = 0; 
			decimal PrimaryTotalAmount = 0; 
			decimal discountAmount = 0;
			if (entityCollection.Count > 0) {
				PrimarySumTotalAmount = entityCollection[0].GetTypedColumnValue<decimal>(primaryAmountColumn.Name);
				SumTotalAmount = entityCollection[0].GetTypedColumnValue<decimal>(amountColumn.Name);
				totalAmount = SumTotalAmount; 
				PrimaryTotalAmount = PrimarySumTotalAmount; 
				discountAmount = invoice.GetTypedColumnValue<decimal>("DiscountAmount");
				if (discountPercent != 0) {
					discountAmount = Multiply(Division(SumTotalAmount, 100), discountPercent);
					totalAmount = SumTotalAmount - Multiply(Division(SumTotalAmount, 100), discountPercent);
					PrimaryTotalAmount = PrimarySumTotalAmount - Multiply(Division(PrimarySumTotalAmount, 100), discountPercent);
				} else {
					if (discountAmount != 0) {
						totalAmount = SumTotalAmount - discountAmount;
						discountPercent = Division(Multiply(discountAmount, 100), SumTotalAmount);
						PrimaryTotalAmount = PrimarySumTotalAmount - Multiply(Division(PrimarySumTotalAmount, 100), discountPercent);
					} 
				}
			}
			var update = new Update(context.UserConnection, "Invoice")
				.Set("PrimaryAmount",Column.Parameter(PrimarySumTotalAmount))
				.Set("Amount",Column.Parameter(SumTotalAmount))
				.Set("DiscountAmount",Column.Parameter(discountAmount))
				.Set("DiscountPercent",Column.Parameter(discountPercent))
				.Set("TotalAmount",Column.Parameter(totalAmount))
				.Set("PrimaryTotalAmount",Column.Parameter(PrimaryTotalAmount))
				.Where("Id").IsEqual(Column.Parameter(invoiceId)) as Update;
			update.Execute();*/
			return true;
		}

		public virtual bool InvoiceProductSavingScriptTaskExecute(ProcessExecutingContext context) {
			var invoiceId = Entity.GetColumnValue("InvoiceId");
			if (invoiceId != null) {
				Select productFinanceSelect = new Select(UserConnection)
								.Column("Invoice", "CurrencyId")
								.Column("Invoice", "CurrencyRate")
								.Column("c", "Division")
								.From("Invoice").As("Invoice")
								.LeftOuterJoin("Currency").As("c").On("Invoice", "CurrencyId").IsEqual("c", "Id")
					.Where("Invoice", "Id").IsEqual(Column.Parameter(invoiceId)) as Select;
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
							using (var dataReader = productFinanceSelect.ExecuteReader(dbExecutor)) {
								while (dataReader.Read()) {
									var rate = UserConnection.DBTypeConverter.DBValueToDecimal(dataReader[1]);
									var division = UserConnection.DBTypeConverter.DBValueToDecimal(dataReader[2]);
									CurrencyRate = rate / (division != 0 ? division : 1);
								}
								
							}
						}
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "InvoiceProduct_Invoice_BPMSoftSaved":
							if (ActivatedEventElements.Contains("InvoiceProductSaved")) {
							context.QueueTasks.Enqueue("InvoiceProductSaved");
						}
						break;
					case "InvoiceProduct_Invoice_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("InvoiceProductDeleted")) {
							context.QueueTasks.Enqueue("InvoiceProductDeleted");
						}
						break;
					case "InvoiceProduct_Invoice_BPMSoftSaving":
							if (ActivatedEventElements.Contains("InvoiceProductSaving")) {
							context.QueueTasks.Enqueue("InvoiceProductSaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceProduct_InvoiceEventsProcess

	/// <exclude/>
	public class InvoiceProduct_InvoiceEventsProcess : InvoiceProduct_InvoiceEventsProcess<InvoiceProduct_Invoice_BPMSoft>
	{

		public InvoiceProduct_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: InvoiceProduct_InvoiceEventsProcess

	public partial class InvoiceProduct_InvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void UpdateInvoiceAmount(UserConnection userConnection) {
			decimal sumTotalAmount = 0; 
			decimal sumPrimaryTotalAmount = 0; 
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "InvoiceProduct");
			var totalAmountColumn = esq.AddColumn("TotalAmount");
			var primaryTotalAmountColumn = esq.AddColumn("PrimaryTotalAmount");
			var invoiceId = this.Entity.GetTypedColumnValue<Guid>("InvoiceId");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Invoice", invoiceId));
			var entityCollection = esq.GetEntityCollection(userConnection);
			if (entityCollection.Count > 0) {
				foreach(var entity in entityCollection) {
					sumTotalAmount += entity.GetTypedColumnValue<decimal>(totalAmountColumn.Name);
					sumPrimaryTotalAmount += entity.GetTypedColumnValue<decimal>(primaryTotalAmountColumn.Name);
				}
			}
			var update = new Update(userConnection, "Invoice")
				.Set("Amount",Column.Parameter(sumTotalAmount))
				.Set("PrimaryAmount",Column.Parameter(sumPrimaryTotalAmount))
				.Where("Id").IsEqual(Column.Parameter(invoiceId)) as Update;
			update.Execute();
		}

		#endregion

	}

	#endregion

}

