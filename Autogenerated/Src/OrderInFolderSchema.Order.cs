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

	#region Class: OrderInFolder_Order_BPMSoftSchema

	/// <exclude/>
	public class OrderInFolder_Order_BPMSoftSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public OrderInFolder_Order_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderInFolder_Order_BPMSoftSchema(OrderInFolder_Order_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderInFolder_Order_BPMSoftSchema(OrderInFolder_Order_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			RealUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			Name = "OrderInFolder_Order_BPMSoft";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d4382331-15ac-41be-929b-d76bc296f4fa")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("4a8e2437-fc34-4f24-9d41-92da7c4a20ae");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d4382331-15ac-41be-929b-d76bc296f4fa"),
				Name = @"Order",
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618"),
				ModifiedInSchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618"),
				CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OrderInFolder_Order_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderInFolder_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderInFolder_Order_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderInFolder_Order_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderInFolder_Order_BPMSoft

	/// <summary>
	/// Заказ в группе.
	/// </summary>
	public class OrderInFolder_Order_BPMSoft : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public OrderInFolder_Order_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderInFolder_Order_BPMSoft";
		}

		public OrderInFolder_Order_BPMSoft(OrderInFolder_Order_BPMSoft source)
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
			var process = new OrderInFolder_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OrderInFolder_Order_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("OrderInFolder_Order_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("OrderInFolder_Order_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrderInFolder_Order_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderInFolder_OrderEventsProcess

	/// <exclude/>
	public partial class OrderInFolder_OrderEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : OrderInFolder_Order_BPMSoft
	{

		public OrderInFolder_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderInFolder_OrderEventsProcess";
			SchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
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

	#region Class: OrderInFolder_OrderEventsProcess

	/// <exclude/>
	public class OrderInFolder_OrderEventsProcess : OrderInFolder_OrderEventsProcess<OrderInFolder_Order_BPMSoft>
	{

		public OrderInFolder_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderInFolder_OrderEventsProcess

	public partial class OrderInFolder_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

