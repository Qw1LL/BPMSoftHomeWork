namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: Invoice_ContractInInvoice_BPMSoftSchema

	/// <exclude/>
	public class Invoice_ContractInInvoice_BPMSoftSchema : BPMSoft.Configuration.Invoice_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public Invoice_ContractInInvoice_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Invoice_ContractInInvoice_BPMSoftSchema(Invoice_ContractInInvoice_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Invoice_ContractInInvoice_BPMSoftSchema(Invoice_ContractInInvoice_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("f78de52b-73c0-471f-9a69-d93183ba0fd9");
			Name = "Invoice_ContractInInvoice_BPMSoft";
			ParentSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			ExtendParent = true;
			CreatedInPackageId = new Guid("ccd436d6-0b26-486d-9df7-4fd6de2cb937");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2467a848-5e0b-4891-8657-0a5776eb4ab9")) == null) {
				Columns.Add(CreateContractColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContractColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2467a848-5e0b-4891-8657-0a5776eb4ab9"),
				Name = @"Contract",
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f78de52b-73c0-471f-9a69-d93183ba0fd9"),
				ModifiedInSchemaUId = new Guid("f78de52b-73c0-471f-9a69-d93183ba0fd9"),
				CreatedInPackageId = new Guid("ccd436d6-0b26-486d-9df7-4fd6de2cb937")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Invoice_ContractInInvoice_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Invoice_ContractInInvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Invoice_ContractInInvoice_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Invoice_ContractInInvoice_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f78de52b-73c0-471f-9a69-d93183ba0fd9"));
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_ContractInInvoice_BPMSoft

	/// <summary>
	/// Счет.
	/// </summary>
	public class Invoice_ContractInInvoice_BPMSoft : BPMSoft.Configuration.Invoice_Order_BPMSoft
	{

		#region Constructors: Public

		public Invoice_ContractInInvoice_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Invoice_ContractInInvoice_BPMSoft";
		}

		public Invoice_ContractInInvoice_BPMSoft(Invoice_ContractInInvoice_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContractId {
			get {
				return GetTypedColumnValue<Guid>("ContractId");
			}
			set {
				SetColumnValue("ContractId", value);
				_contract = null;
			}
		}

		/// <exclude/>
		public string ContractNumber {
			get {
				return GetTypedColumnValue<string>("ContractNumber");
			}
			set {
				SetColumnValue("ContractNumber", value);
				if (_contract != null) {
					_contract.Number = value;
				}
			}
		}

		private Contract _contract;
		/// <summary>
		/// Договор.
		/// </summary>
		public Contract Contract {
			get {
				return _contract ??
					(_contract = LookupColumnEntities.GetEntity("Contract") as Contract);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Invoice_ContractInInvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Invoice_ContractInInvoice_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("Invoice_ContractInInvoice_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Invoice_ContractInInvoice_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_ContractInInvoiceEventsProcess

	/// <exclude/>
	public partial class Invoice_ContractInInvoiceEventsProcess<TEntity> : BPMSoft.Configuration.Invoice_OrderEventsProcess<TEntity> where TEntity : Invoice_ContractInInvoice_BPMSoft
	{

		public Invoice_ContractInInvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Invoice_ContractInInvoiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f78de52b-73c0-471f-9a69-d93183ba0fd9");
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

	#region Class: Invoice_ContractInInvoiceEventsProcess

	/// <exclude/>
	public class Invoice_ContractInInvoiceEventsProcess : Invoice_ContractInInvoiceEventsProcess<Invoice_ContractInInvoice_BPMSoft>
	{

		public Invoice_ContractInInvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Invoice_ContractInInvoiceEventsProcess

	public partial class Invoice_ContractInInvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

