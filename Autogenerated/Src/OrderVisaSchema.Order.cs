namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Mail;
	using BPMSoft.Messaging.Common;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;

	#region Class: OrderVisaSchema

	/// <exclude/>
	public class OrderVisaSchema : BPMSoft.Configuration.BaseVisaSchema
	{

		#region Constructors: Public

		public OrderVisaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderVisaSchema(OrderVisaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderVisaSchema(OrderVisaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5");
			RealUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5");
			Name = "OrderVisa";
			ParentSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("20073fe5-438b-4250-bdb9-1cc0573c7db3")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("20073fe5-438b-4250-bdb9-1cc0573c7db3"),
				Name = @"Order",
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"),
				ModifiedInSchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OrderVisa(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderVisa_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderVisaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderVisaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderVisa

	/// <summary>
	/// Виза заказа.
	/// </summary>
	public class OrderVisa : BPMSoft.Configuration.BaseVisa
	{

		#region Constructors: Public

		public OrderVisa(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderVisa";
		}

		public OrderVisa(OrderVisa source)
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
			var process = new OrderVisa_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("OrderVisaInserting", e);
			Validating += (s, e) => ThrowEvent("OrderVisaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrderVisa(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderVisa_OrderEventsProcess

	/// <exclude/>
	public partial class OrderVisa_OrderEventsProcess<TEntity> : BPMSoft.Configuration.BaseVisa_NUIEventsProcess<TEntity> where TEntity : OrderVisa
	{

		public OrderVisa_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderVisa_OrderEventsProcess";
			SchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5");
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

	#region Class: OrderVisa_OrderEventsProcess

	/// <exclude/>
	public class OrderVisa_OrderEventsProcess : OrderVisa_OrderEventsProcess<OrderVisa>
	{

		public OrderVisa_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderVisa_OrderEventsProcess

	public partial class OrderVisa_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		public override List<string> GetVisaTemplateSchemaQueryColumns() {
			List<string> columns = base.GetVisaTemplateSchemaQueryColumns();
			columns.AddRange( new string[] {
				"Order.Number",
				"Order.Date",
				"Order.Currency.ShortName",
				"Order.Amount",
				"Order.Owner.Name",
				"Order.Contact.Name",
				"Order.Account.Name"
			});
			return columns;
		}

		public override INotificationInfo GetNotificationInfo() {
			Entity.Order.FetchFromDB(Entity.OrderId);
			var order = Entity.Order;	
			var orderDate = order.Date.ToString(PopupBodyDateFormat);
			var accountName = order.AccountName;
			var contactName = order.ContactName;
			var accountContactString = string.Join(", ", new[] {accountName, contactName}.Where(s => s.IsNotEmpty()));
			var body = string.Format(PopupBodyTemplate, order.Number, orderDate, accountContactString);
			var notificationInfo = base.GetNotificationInfo();
			notificationInfo.EntityId = order.Id;
			notificationInfo.Body = body;
			return notificationInfo;
		}

		#endregion

	}

	#endregion


	#region Class: OrderVisaEventsProcess

	/// <exclude/>
	public class OrderVisaEventsProcess : OrderVisa_OrderEventsProcess
	{

		public OrderVisaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

