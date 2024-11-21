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

	#region Class: Invoice_Passport_BPMSoftSchema

	/// <exclude/>
	public class Invoice_Passport_BPMSoftSchema : BPMSoft.Configuration.Invoice_ContractInInvoice_BPMSoftSchema
	{

		#region Constructors: Public

		public Invoice_Passport_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Invoice_Passport_BPMSoftSchema(Invoice_Passport_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Invoice_Passport_BPMSoftSchema(Invoice_Passport_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("7a364256-ee50-4219-aed1-dfe247a7832b");
			Name = "Invoice_Passport_BPMSoft";
			ParentSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c4bef748-df1b-4c41-878a-658ffe06f804");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b419c3b3-22c7-44ad-8fc8-c02618d362dc")) == null) {
				Columns.Add(CreateAmountWithoutTaxColumn());
			}
			if (Columns.FindByUId(new Guid("08be4ee9-724d-45ee-b01a-1906f7e9670c")) == null) {
				Columns.Add(CreatePrimaryAmountWithoutTaxColumn());
			}
			if (Columns.FindByUId(new Guid("a7a263e8-7fc8-409c-9ada-14d2d38ba1d1")) == null) {
				Columns.Add(CreatePaymentAmountWithoutTaxColumn());
			}
			if (Columns.FindByUId(new Guid("f6182f6b-cf24-4858-b9e2-5377f59fa07a")) == null) {
				Columns.Add(CreatePrimaryPaymentAmountWithoutTaxColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAmountWithoutTaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("b419c3b3-22c7-44ad-8fc8-c02618d362dc"),
				Name = @"AmountWithoutTax",
				CreatedInSchemaUId = new Guid("7a364256-ee50-4219-aed1-dfe247a7832b"),
				ModifiedInSchemaUId = new Guid("7a364256-ee50-4219-aed1-dfe247a7832b"),
				CreatedInPackageId = new Guid("a002bd5f-14f1-4196-ac19-0a0feddeb334")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryAmountWithoutTaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("08be4ee9-724d-45ee-b01a-1906f7e9670c"),
				Name = @"PrimaryAmountWithoutTax",
				CreatedInSchemaUId = new Guid("7a364256-ee50-4219-aed1-dfe247a7832b"),
				ModifiedInSchemaUId = new Guid("7a364256-ee50-4219-aed1-dfe247a7832b"),
				CreatedInPackageId = new Guid("a002bd5f-14f1-4196-ac19-0a0feddeb334")
			};
		}

		protected virtual EntitySchemaColumn CreatePaymentAmountWithoutTaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("a7a263e8-7fc8-409c-9ada-14d2d38ba1d1"),
				Name = @"PaymentAmountWithoutTax",
				CreatedInSchemaUId = new Guid("7a364256-ee50-4219-aed1-dfe247a7832b"),
				ModifiedInSchemaUId = new Guid("7a364256-ee50-4219-aed1-dfe247a7832b"),
				CreatedInPackageId = new Guid("a002bd5f-14f1-4196-ac19-0a0feddeb334")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryPaymentAmountWithoutTaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("f6182f6b-cf24-4858-b9e2-5377f59fa07a"),
				Name = @"PrimaryPaymentAmountWithoutTax",
				CreatedInSchemaUId = new Guid("7a364256-ee50-4219-aed1-dfe247a7832b"),
				ModifiedInSchemaUId = new Guid("7a364256-ee50-4219-aed1-dfe247a7832b"),
				CreatedInPackageId = new Guid("a002bd5f-14f1-4196-ac19-0a0feddeb334")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Invoice_Passport_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Invoice_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Invoice_Passport_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Invoice_Passport_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a364256-ee50-4219-aed1-dfe247a7832b"));
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_Passport_BPMSoft

	/// <summary>
	/// Счет.
	/// </summary>
	public class Invoice_Passport_BPMSoft : BPMSoft.Configuration.Invoice_ContractInInvoice_BPMSoft
	{

		#region Constructors: Public

		public Invoice_Passport_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Invoice_Passport_BPMSoft";
		}

		public Invoice_Passport_BPMSoft(Invoice_Passport_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Сумма без налога.
		/// </summary>
		public Decimal AmountWithoutTax {
			get {
				return GetTypedColumnValue<Decimal>("AmountWithoutTax");
			}
			set {
				SetColumnValue("AmountWithoutTax", value);
			}
		}

		/// <summary>
		/// Сумма без налога, б.в.
		/// </summary>
		public Decimal PrimaryAmountWithoutTax {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmountWithoutTax");
			}
			set {
				SetColumnValue("PrimaryAmountWithoutTax", value);
			}
		}

		/// <summary>
		/// Сумма оплаты без налога.
		/// </summary>
		public Decimal PaymentAmountWithoutTax {
			get {
				return GetTypedColumnValue<Decimal>("PaymentAmountWithoutTax");
			}
			set {
				SetColumnValue("PaymentAmountWithoutTax", value);
			}
		}

		/// <summary>
		/// Сумма оплаты без налога, б.в.
		/// </summary>
		public Decimal PrimaryPaymentAmountWithoutTax {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryPaymentAmountWithoutTax");
			}
			set {
				SetColumnValue("PrimaryPaymentAmountWithoutTax", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Invoice_PassportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Invoice_Passport_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Invoice_Passport_BPMSoftDeleting", e);
			Saved += (s, e) => ThrowEvent("Invoice_Passport_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Invoice_Passport_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Invoice_Passport_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Invoice_Passport_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_PassportEventsProcess

	/// <exclude/>
	public partial class Invoice_PassportEventsProcess<TEntity> : BPMSoft.Configuration.Invoice_ContractInInvoiceEventsProcess<TEntity> where TEntity : Invoice_Passport_BPMSoft
	{

		public Invoice_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Invoice_PassportEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			_isInvoiceCanceled = () => {{ return false; }};
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a364256-ee50-4219-aed1-dfe247a7832b");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private Func<bool> _isInvoiceCanceled;
		public virtual bool IsInvoiceCanceled {
			get {
				return (_isInvoiceCanceled ?? (_isInvoiceCanceled = () => false)).Invoke();
			}
			set {
				_isInvoiceCanceled = () => { return value; };
			}
		}

		public virtual Object ChangedColumnValues {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("f66dbaa2-fdd4-4396-92ce-13ebffcab02e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _passportInvoiceSaving;
		public ProcessFlowElement PassportInvoiceSaving {
			get {
				return _passportInvoiceSaving ?? (_passportInvoiceSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PassportInvoiceSaving",
					SchemaElementUId = new Guid("68950f9c-cc32-469f-94d9-d003296355a0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _isPaymentStatusCanceled;
		public ProcessScriptTask IsPaymentStatusCanceled {
			get {
				return _isPaymentStatusCanceled ?? (_isPaymentStatusCanceled = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "IsPaymentStatusCanceled",
					SchemaElementUId = new Guid("c69a5e84-d99a-4154-908d-b90c057a36cd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = IsPaymentStatusCanceledExecute,
				});
			}
		}

		private ProcessFlowElement _deletedEventSubProcess;
		public ProcessFlowElement DeletedEventSubProcess {
			get {
				return _deletedEventSubProcess ?? (_deletedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "DeletedEventSubProcess",
					SchemaElementUId = new Guid("8238d963-44d7-4d21-b865-45931d931373"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _invoiceDeletedStartMessage;
		public ProcessFlowElement InvoiceDeletedStartMessage {
			get {
				return _invoiceDeletedStartMessage ?? (_invoiceDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InvoiceDeletedStartMessage",
					SchemaElementUId = new Guid("e99e59b8-9d2a-4073-b182-58303437863e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onDeletedScriptTask;
		public ProcessScriptTask OnDeletedScriptTask {
			get {
				return _onDeletedScriptTask ?? (_onDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnDeletedScriptTask",
					SchemaElementUId = new Guid("fed8d9f3-319d-44e4-818f-50436f075221"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnDeletedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[PassportInvoiceSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { PassportInvoiceSaving };
			FlowElements[IsPaymentStatusCanceled.SchemaElementUId] = new Collection<ProcessFlowElement> { IsPaymentStatusCanceled };
			FlowElements[DeletedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { DeletedEventSubProcess };
			FlowElements[InvoiceDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { InvoiceDeletedStartMessage };
			FlowElements[OnDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OnDeletedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess2":
						break;
					case "PassportInvoiceSaving":
						e.Context.QueueTasks.Enqueue("IsPaymentStatusCanceled");
						break;
					case "IsPaymentStatusCanceled":
						break;
					case "DeletedEventSubProcess":
						break;
					case "InvoiceDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("OnDeletedScriptTask");
						break;
					case "OnDeletedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("PassportInvoiceSaving");
			ActivatedEventElements.Add("InvoiceDeletedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "PassportInvoiceSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "PassportInvoiceSaving";
					result = PassportInvoiceSaving.Execute(context);
					break;
				case "IsPaymentStatusCanceled":
					context.QueueTasks.Dequeue();
					context.SenderName = "IsPaymentStatusCanceled";
					result = IsPaymentStatusCanceled.Execute(context, IsPaymentStatusCanceledExecute);
					break;
				case "DeletedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "InvoiceDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "InvoiceDeletedStartMessage";
					result = InvoiceDeletedStartMessage.Execute(context);
					break;
				case "OnDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnDeletedScriptTask";
					result = OnDeletedScriptTask.Execute(context, OnDeletedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool IsPaymentStatusCanceledExecute(ProcessExecutingContext context) {
			ChangedColumnValues = new List<EntityColumnValue>(Entity.GetChangedColumnValues());
			return true;
		}

		public virtual bool OnDeletedScriptTaskExecute(ProcessExecutingContext context) {
			var orderAmountHelper = ClassFactory.Get<OrderAmountHelper>(new ConstructorArgument("userConnection", UserConnection));
			orderAmountHelper.UpdateOrderPaymentAmountOnInvoiceDeleted(Entity.GetTypedColumnValue<Guid>("OrderId"));
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Invoice_Passport_BPMSoftSaving":
							if (ActivatedEventElements.Contains("PassportInvoiceSaving")) {
							context.QueueTasks.Enqueue("PassportInvoiceSaving");
							ProcessQueue(context);
							return;
						}
						break;
					case "Invoice_Passport_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("InvoiceDeletedStartMessage")) {
							context.QueueTasks.Enqueue("InvoiceDeletedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_PassportEventsProcess

	/// <exclude/>
	public class Invoice_PassportEventsProcess : Invoice_PassportEventsProcess<Invoice_Passport_BPMSoft>
	{

		public Invoice_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Invoice_PassportEventsProcess

	public partial class Invoice_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CleanInvoiceIdInSupplyPayment() {
			var supplyPaymentElementSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SupplyPaymentElement");
				var item = supplyPaymentElementSchema.CreateEntity(UserConnection);
				var invoiceId = Entity.GetTypedColumnValue<Guid>("Id");
				if (item.FetchFromDB(new Dictionary<string, object>{{"Invoice", invoiceId}})) {
					item.SetColumnValue("InvoiceId", null);
					item.SetColumnValue("AmountFact", null);
					item.SetColumnValue("PrimaryAmountFact", null);
					item.SetColumnValue("DateFact", null);
					item.SetColumnValue("StateId", PassportConstants.SupplyPaymentStateNotFinished);
					item.Save(false);
				};
		}

		public override void OnSaved() {
			var orderAmountHelper = GetOrderAmountHelper();
			if (NeedFinRecalc) {
				bool productAmountRecalculated = orderAmountHelper.UpdateInvoiceProductAmountOnCurrencyChange(Entity.PrimaryColumnValue);
				NeedFinRecalc = !productAmountRecalculated;
			}
			base.OnSaved();
			var changedColumnValues = ChangedColumnValues as List<EntityColumnValue>;
			if (changedColumnValues == null) {
				return;
			}
			bool orderPaymentAmountUpdated;
			orderAmountHelper.UpdateSupplyPaymentElementOnInvoiceChanged(Entity.PrimaryColumnValue, changedColumnValues, out orderPaymentAmountUpdated);
			var paymentStatusColumnValue = changedColumnValues.FirstOrDefault(changedColumn => changedColumn.Column.Name == "PaymentStatus");
			if (paymentStatusColumnValue != null && (Guid)paymentStatusColumnValue.Value == PassportConstants.InvoicePaymentStatusCanceled) {
				CleanInvoiceIdInSupplyPayment();
			}
			if (!orderPaymentAmountUpdated && changedColumnValues.ConvertAll(cv => cv.Column.Name).Intersect(new[] { "PrimaryPaymentAmount", "PaymentStatus" }).Any()) {
				orderAmountHelper.UpdateOrderPaymentAmountOnInvoiceChanged(Entity.PrimaryColumnValue);
			}
		}

		public virtual OrderAmountHelper GetOrderAmountHelper() {
			return ClassFactory.Get<OrderAmountHelper>(new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

	}

	#endregion

}

