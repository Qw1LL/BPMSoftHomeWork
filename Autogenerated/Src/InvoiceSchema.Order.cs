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

	#region Class: Invoice_Order_BPMSoftSchema

	/// <exclude/>
	public class Invoice_Order_BPMSoftSchema : BPMSoft.Configuration.Invoice_Invoice_BPMSoftSchema
	{

		#region Constructors: Public

		public Invoice_Order_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Invoice_Order_BPMSoftSchema(Invoice_Order_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Invoice_Order_BPMSoftSchema(Invoice_Order_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("0cd1b612-1b9a-4681-883d-9b076c21cec3");
			Name = "Invoice_Order_BPMSoft";
			ParentSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			ExtendParent = true;
			CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4e473dd6-40a8-463b-8ae4-9af8afe2599e")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4e473dd6-40a8-463b-8ae4-9af8afe2599e"),
				Name = @"Order",
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0cd1b612-1b9a-4681-883d-9b076c21cec3"),
				ModifiedInSchemaUId = new Guid("0cd1b612-1b9a-4681-883d-9b076c21cec3"),
				CreatedInPackageId = new Guid("52964353-9e8f-48e5-896c-d741fb4f3eb4")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Invoice_Order_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Invoice_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Invoice_Order_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Invoice_Order_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0cd1b612-1b9a-4681-883d-9b076c21cec3"));
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_Order_BPMSoft

	/// <summary>
	/// Счет.
	/// </summary>
	public class Invoice_Order_BPMSoft : BPMSoft.Configuration.Invoice_Invoice_BPMSoft
	{

		#region Constructors: Public

		public Invoice_Order_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Invoice_Order_BPMSoft";
		}

		public Invoice_Order_BPMSoft(Invoice_Order_BPMSoft source)
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
			var process = new Invoice_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Invoice_Order_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Invoice_Order_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Invoice_Order_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Invoice_Order_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_OrderEventsProcess

	/// <exclude/>
	public partial class Invoice_OrderEventsProcess<TEntity> : BPMSoft.Configuration.Invoice_InvoiceEventsProcess<TEntity> where TEntity : Invoice_Order_BPMSoft
	{

		public Invoice_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Invoice_OrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0cd1b612-1b9a-4681-883d-9b076c21cec3");
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

	#region Class: Invoice_OrderEventsProcess

	/// <exclude/>
	public class Invoice_OrderEventsProcess : Invoice_OrderEventsProcess<Invoice_Order_BPMSoft>
	{

		public Invoice_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Invoice_OrderEventsProcess

	public partial class Invoice_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

