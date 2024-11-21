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

	#region Class: OrderProduct_Order_BPMSoftSchema

	/// <exclude/>
	public class OrderProduct_Order_BPMSoftSchema : BPMSoft.Configuration.BaseProductEntrySchema
	{

		#region Constructors: Public

		public OrderProduct_Order_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderProduct_Order_BPMSoftSchema(OrderProduct_Order_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderProduct_Order_BPMSoftSchema(OrderProduct_Order_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			RealUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			Name = "OrderProduct_Order_BPMSoft";
			ParentSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4");
			ExtendParent = false;
			CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5d990ae6-2f01-4ab2-ae31-d384e6070ec3")) == null) {
				Columns.Add(CreateOrderColumn());
			}
			if (Columns.FindByUId(new Guid("d39634bd-ec70-4b48-964d-47d0c052a47a")) == null) {
				Columns.Add(CreateCurrencyColumn());
			}
			if (Columns.FindByUId(new Guid("727aff73-e56f-401b-af5f-4a4d3a28c235")) == null) {
				Columns.Add(CreateCurrencyRateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateProductColumn() {
			EntitySchemaColumn column = base.CreateProductColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateCustomProductColumn() {
			EntitySchemaColumn column = base.CreateCustomProductColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateDeliveryDateColumn() {
			EntitySchemaColumn column = base.CreateDeliveryDateColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateQuantityColumn() {
			EntitySchemaColumn column = base.CreateQuantityColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateUnitColumn() {
			EntitySchemaColumn column = base.CreateUnitColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryPriceColumn() {
			EntitySchemaColumn column = base.CreatePrimaryPriceColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreatePriceColumn() {
			EntitySchemaColumn column = base.CreatePriceColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryAmountColumn() {
			EntitySchemaColumn column = base.CreatePrimaryAmountColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateAmountColumn() {
			EntitySchemaColumn column = base.CreateAmountColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryDiscountAmountColumn() {
			EntitySchemaColumn column = base.CreatePrimaryDiscountAmountColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateDiscountAmountColumn() {
			EntitySchemaColumn column = base.CreateDiscountAmountColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateDiscountPercentColumn() {
			EntitySchemaColumn column = base.CreateDiscountPercentColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateTaxColumn() {
			EntitySchemaColumn column = base.CreateTaxColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryTaxAmountColumn() {
			EntitySchemaColumn column = base.CreatePrimaryTaxAmountColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateTaxAmountColumn() {
			EntitySchemaColumn column = base.CreateTaxAmountColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryTotalAmountColumn() {
			EntitySchemaColumn column = base.CreatePrimaryTotalAmountColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateTotalAmountColumn() {
			EntitySchemaColumn column = base.CreateTotalAmountColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateDiscountTaxColumn() {
			EntitySchemaColumn column = base.CreateDiscountTaxColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			column.CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5d990ae6-2f01-4ab2-ae31-d384e6070ec3"),
				Name = @"Order",
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e"),
				ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e"),
				CreatedInPackageId = new Guid("dd9fef59-5c55-4ab9-987f-84fb816c4cbb")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d39634bd-ec70-4b48-964d-47d0c052a47a"),
				Name = @"Currency",
				ReferenceSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e"),
				ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e"),
				CreatedInPackageId = new Guid("6439b666-7603-43a5-90d0-7ee1e44814cf")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("727aff73-e56f-401b-af5f-4a4d3a28c235"),
				Name = @"CurrencyRate",
				CreatedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e"),
				ModifiedInSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e"),
				CreatedInPackageId = new Guid("6439b666-7603-43a5-90d0-7ee1e44814cf")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OrderProduct_Order_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderProduct_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderProduct_Order_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderProduct_Order_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderProduct_Order_BPMSoft

	/// <summary>
	/// Продукт в заказе.
	/// </summary>
	public class OrderProduct_Order_BPMSoft : BPMSoft.Configuration.BaseProductEntry
	{

		#region Constructors: Public

		public OrderProduct_Order_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderProduct_Order_BPMSoft";
		}

		public OrderProduct_Order_BPMSoft(OrderProduct_Order_BPMSoft source)
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

		/// <exclude/>
		public Guid CurrencyId {
			get {
				return GetTypedColumnValue<Guid>("CurrencyId");
			}
			set {
				SetColumnValue("CurrencyId", value);
				_currency = null;
			}
		}

		/// <exclude/>
		public string CurrencyName {
			get {
				return GetTypedColumnValue<string>("CurrencyName");
			}
			set {
				SetColumnValue("CurrencyName", value);
				if (_currency != null) {
					_currency.Name = value;
				}
			}
		}

		private Currency _currency;
		/// <summary>
		/// Валюта.
		/// </summary>
		public Currency Currency {
			get {
				return _currency ??
					(_currency = LookupColumnEntities.GetEntity("Currency") as Currency);
			}
		}

		/// <summary>
		/// Курс.
		/// </summary>
		public Decimal CurrencyRate {
			get {
				return GetTypedColumnValue<Decimal>("CurrencyRate");
			}
			set {
				SetColumnValue("CurrencyRate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrderProduct_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OrderProduct_Order_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("OrderProduct_Order_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("OrderProduct_Order_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("OrderProduct_Order_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("OrderProduct_Order_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrderProduct_Order_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderProduct_OrderEventsProcess

	/// <exclude/>
	public partial class OrderProduct_OrderEventsProcess<TEntity> : BPMSoft.Configuration.BaseProductEntry_ProductCatalogueEventsProcess<TEntity> where TEntity : OrderProduct_Order_BPMSoft
	{

		public OrderProduct_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderProduct_OrderEventsProcess";
			SchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool NeedUpdateOrderAmount {
			get;
			set;
		}

		public virtual bool IsProductDeleted {
			get;
			set;
		}

		public virtual Object ChangedColumnValues {
			get;
			set;
		}

		public virtual bool NeedRecalcPrimaryValues {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("db6e08fa-3572-4cb3-a01f-aea11476efec"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _recalcOrderProductSavedStartMessage;
		public ProcessFlowElement RecalcOrderProductSavedStartMessage {
			get {
				return _recalcOrderProductSavedStartMessage ?? (_recalcOrderProductSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RecalcOrderProductSavedStartMessage",
					SchemaElementUId = new Guid("4f7c89e9-e384-4e17-931a-783ea0cb3197"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _recalcOrderProductDeletedStartMessage;
		public ProcessFlowElement RecalcOrderProductDeletedStartMessage {
			get {
				return _recalcOrderProductDeletedStartMessage ?? (_recalcOrderProductDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RecalcOrderProductDeletedStartMessage",
					SchemaElementUId = new Guid("beeacac1-ec16-46d9-be2c-f507fe04bc5c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _recalculateOrderAmountScriptTask;
		public ProcessScriptTask RecalculateOrderAmountScriptTask {
			get {
				return _recalculateOrderAmountScriptTask ?? (_recalculateOrderAmountScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RecalculateOrderAmountScriptTask",
					SchemaElementUId = new Guid("489b00b3-0a19-4c9f-bd85-febdd989d5f7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RecalculateOrderAmountScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _setNeedUpdateAmountScriptTask;
		public ProcessScriptTask SetNeedUpdateAmountScriptTask {
			get {
				return _setNeedUpdateAmountScriptTask ?? (_setNeedUpdateAmountScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetNeedUpdateAmountScriptTask",
					SchemaElementUId = new Guid("988e0c7e-a9da-48f7-aced-2826540572fa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetNeedUpdateAmountScriptTaskExecute,
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
					SchemaElementUId = new Guid("ca5735a3-2a7f-40e5-afc3-42da98341736"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _orderProductSaving;
		public ProcessFlowElement OrderProductSaving {
			get {
				return _orderProductSaving ?? (_orderProductSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OrderProductSaving",
					SchemaElementUId = new Guid("93237e85-4d8d-445e-b45a-e2328e1f1e02"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessageOrderProductSaving;
		public ProcessThrowMessageEvent IntermediateThrowMessageOrderProductSaving {
			get {
				return _intermediateThrowMessageOrderProductSaving ?? (_intermediateThrowMessageOrderProductSaving = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessageOrderProductSaving",
					SchemaElementUId = new Guid("f2eeafc8-973a-461e-b4ca-a88f5a569edd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "OrderProductSaving",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _scriptUpdateFinance;
		public ProcessScriptTask ScriptUpdateFinance {
			get {
				return _scriptUpdateFinance ?? (_scriptUpdateFinance = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptUpdateFinance",
					SchemaElementUId = new Guid("99f01749-87fc-479c-9937-aefacb13e57a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptUpdateFinanceExecute,
				});
			}
		}

		private ProcessScriptTask _checkNeedUpdateOrderAmountScriptTask;
		public ProcessScriptTask CheckNeedUpdateOrderAmountScriptTask {
			get {
				return _checkNeedUpdateOrderAmountScriptTask ?? (_checkNeedUpdateOrderAmountScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckNeedUpdateOrderAmountScriptTask",
					SchemaElementUId = new Guid("2e415177-d5ed-4a47-bd6b-126c99e8b578"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckNeedUpdateOrderAmountScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[RecalcOrderProductSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RecalcOrderProductSavedStartMessage };
			FlowElements[RecalcOrderProductDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RecalcOrderProductDeletedStartMessage };
			FlowElements[RecalculateOrderAmountScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RecalculateOrderAmountScriptTask };
			FlowElements[SetNeedUpdateAmountScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetNeedUpdateAmountScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[OrderProductSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { OrderProductSaving };
			FlowElements[IntermediateThrowMessageOrderProductSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessageOrderProductSaving };
			FlowElements[ScriptUpdateFinance.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptUpdateFinance };
			FlowElements[CheckNeedUpdateOrderAmountScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckNeedUpdateOrderAmountScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "RecalcOrderProductSavedStartMessage":
						e.Context.QueueTasks.Enqueue("RecalculateOrderAmountScriptTask");
						break;
					case "RecalcOrderProductDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("SetNeedUpdateAmountScriptTask");
						break;
					case "RecalculateOrderAmountScriptTask":
						break;
					case "SetNeedUpdateAmountScriptTask":
						e.Context.QueueTasks.Enqueue("RecalculateOrderAmountScriptTask");
						break;
					case "EventSubProcess2":
						break;
					case "OrderProductSaving":
						e.Context.QueueTasks.Enqueue("ScriptUpdateFinance");
						break;
					case "IntermediateThrowMessageOrderProductSaving":
						e.Context.QueueTasks.Enqueue("CheckNeedUpdateOrderAmountScriptTask");
						break;
					case "ScriptUpdateFinance":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessageOrderProductSaving");
						break;
					case "CheckNeedUpdateOrderAmountScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("RecalcOrderProductSavedStartMessage");
			ActivatedEventElements.Add("RecalcOrderProductDeletedStartMessage");
			ActivatedEventElements.Add("OrderProductSaving");
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
				case "RecalcOrderProductSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RecalcOrderProductSavedStartMessage";
					result = RecalcOrderProductSavedStartMessage.Execute(context);
					break;
				case "RecalcOrderProductDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RecalcOrderProductDeletedStartMessage";
					result = RecalcOrderProductDeletedStartMessage.Execute(context);
					break;
				case "RecalculateOrderAmountScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "RecalculateOrderAmountScriptTask";
					result = RecalculateOrderAmountScriptTask.Execute(context, RecalculateOrderAmountScriptTaskExecute);
					break;
				case "SetNeedUpdateAmountScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetNeedUpdateAmountScriptTask";
					result = SetNeedUpdateAmountScriptTask.Execute(context, SetNeedUpdateAmountScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "OrderProductSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "OrderProductSaving";
					result = OrderProductSaving.Execute(context);
					break;
				case "IntermediateThrowMessageOrderProductSaving":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "OrderProductSaving");
					result = IntermediateThrowMessageOrderProductSaving.Execute(context);
					break;
				case "ScriptUpdateFinance":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptUpdateFinance";
					result = ScriptUpdateFinance.Execute(context, ScriptUpdateFinanceExecute);
					break;
				case "CheckNeedUpdateOrderAmountScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckNeedUpdateOrderAmountScriptTask";
					result = CheckNeedUpdateOrderAmountScriptTask.Execute(context, CheckNeedUpdateOrderAmountScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool RecalculateOrderAmountScriptTaskExecute(ProcessExecutingContext context) {
			if (NeedUpdateOrderAmount) {
				RecalculateOrderAmount();
			}
			return true;
		}

		public virtual bool SetNeedUpdateAmountScriptTaskExecute(ProcessExecutingContext context) {
			NeedUpdateOrderAmount = true;
			IsProductDeleted = true;
			return true;
		}

		public virtual bool ScriptUpdateFinanceExecute(ProcessExecutingContext context) {
			LoadCurrencyFromOrder();
			return true;
		}

		public virtual bool CheckNeedUpdateOrderAmountScriptTaskExecute(ProcessExecutingContext context) {
			var changedValues = Entity.GetChangedColumnValues();
			List<string> changedColumnNames = changedValues.Where(cv => cv.Value != cv.OldValue).ToList().ConvertAll(cv => cv.Column.Name);
			NeedUpdateOrderAmount = changedColumnNames.Intersect(new[] {"TotalAmount", "PrimaryTotalAmount"}).Any();
			ChangedColumnValues = changedValues;
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "OrderProduct_Order_BPMSoftSaved":
							if (ActivatedEventElements.Contains("RecalcOrderProductSavedStartMessage")) {
							context.QueueTasks.Enqueue("RecalcOrderProductSavedStartMessage");
						}
						break;
					case "OrderProduct_Order_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("RecalcOrderProductDeletedStartMessage")) {
							context.QueueTasks.Enqueue("RecalcOrderProductDeletedStartMessage");
						}
						break;
					case "OrderProduct_Order_BPMSoftSaving":
							if (ActivatedEventElements.Contains("OrderProductSaving")) {
							context.QueueTasks.Enqueue("OrderProductSaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: OrderProduct_OrderEventsProcess

	/// <exclude/>
	public class OrderProduct_OrderEventsProcess : OrderProduct_OrderEventsProcess<OrderProduct_Order_BPMSoft>
	{

		public OrderProduct_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderProduct_OrderEventsProcess

	public partial class OrderProduct_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void RecalculateOrderAmount() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OrderProduct");
			var totalAmountColumn = esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Sum, "TotalAmount"));
			var primaryTotalAmountColumn = esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Sum, "PrimaryTotalAmount"));
			var orderId = Entity.GetTypedColumnValue<Guid>("OrderId");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Order", orderId));
			var entity = esq.GetEntityCollection(UserConnection).FirstOrDefault();
			if (entity == null) {
				return;
			}
			var order = UserConnection.EntitySchemaManager.GetInstanceByName("Order").CreateEntity(UserConnection);
			if (order.FetchFromDB(orderId)) {
				var amount = entity.GetTypedColumnValue<decimal>(totalAmountColumn.Name);
				var primaryAmount = entity.GetTypedColumnValue<decimal>(primaryTotalAmountColumn.Name);
				order.SetColumnValue("Amount", amount);
				order.SetColumnValue("PrimaryAmount", primaryAmount);
				order.Save(false);
			}
		}

		public virtual void LoadCurrencyFromOrder() {
			var currencyId = Entity.GetColumnValue("CurrencyId");
			if (currencyId == null) {
				var orderId = Entity.GetTypedColumnValue<Guid>("OrderId");
				if (orderId == Guid.Empty) {
					return;
				}
				var orderEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Order");
				var currnecyIdColumn = orderEsq.AddColumn("Currency.Id");
				var currnecyDivisionColumn = orderEsq.AddColumn("Currency.Division");
				var currnecyRateColumn = orderEsq.AddColumn("CurrencyRate");
				var order = orderEsq.GetEntity(UserConnection, orderId);
				if (order != null) {
					var division = order.GetTypedColumnValue<decimal>(currnecyDivisionColumn.Name);
					var currencyRate = order.GetTypedColumnValue<decimal>(currnecyRateColumn.Name);
					Entity.SetColumnValue("CurrencyId", order.GetTypedColumnValue<Guid>(currnecyIdColumn.Name));
					Entity.SetColumnValue("CurrencyRate", currencyRate);
					CurrencyRate = currencyRate / (division != 0 ? division : 1);
					NeedRecalcPrimaryValues = true;
				}
			}
			return;
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

