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

	#region Class: VwSupplyPaymentProduct_Passport_BPMSoftSchema

	/// <exclude/>
	public class VwSupplyPaymentProduct_Passport_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSupplyPaymentProduct_Passport_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSupplyPaymentProduct_Passport_BPMSoftSchema(VwSupplyPaymentProduct_Passport_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSupplyPaymentProduct_Passport_BPMSoftSchema(VwSupplyPaymentProduct_Passport_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb");
			RealUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb");
			Name = "VwSupplyPaymentProduct_Passport_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("485aad79-d61d-41d3-b43a-702c4d517eb8")) == null) {
				Columns.Add(CreateSupplyPaymentElementColumn());
			}
			if (Columns.FindByUId(new Guid("35d1dcfa-9043-4353-af77-eb122f227453")) == null) {
				Columns.Add(CreateSupplyPaymentProductColumn());
			}
			if (Columns.FindByUId(new Guid("2a863b50-214c-41f0-8d20-bb9042a7571b")) == null) {
				Columns.Add(CreateOrderProductColumn());
			}
			if (Columns.FindByUId(new Guid("b1141a69-1c47-4263-af95-ba3ca3e54d8b")) == null) {
				Columns.Add(CreateUsedQuantityColumn());
			}
			if (Columns.FindByUId(new Guid("1333adb9-3cef-450c-8d98-7bca3090571b")) == null) {
				Columns.Add(CreateUsedAmountColumn());
			}
			if (Columns.FindByUId(new Guid("98b768be-0360-481e-b3e6-9ca26ddf6769")) == null) {
				Columns.Add(CreateMaxQuantityColumn());
			}
			if (Columns.FindByUId(new Guid("3444fc14-c107-4926-a893-90913f9028f1")) == null) {
				Columns.Add(CreateIsDistributedColumn());
			}
			if (Columns.FindByUId(new Guid("a5fcdcaa-1f34-4030-aa1e-08f2cf5b5237")) == null) {
				Columns.Add(CreatePriceColumn());
			}
			if (Columns.FindByUId(new Guid("92d9c377-2a35-494f-b44c-c7406cb6c795")) == null) {
				Columns.Add(CreateDiscountPercentColumn());
			}
			if (Columns.FindByUId(new Guid("a669eb1d-8278-4d7d-dbf4-a5ed549122f8")) == null) {
				Columns.Add(CreateDiscountAmountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSupplyPaymentElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("485aad79-d61d-41d3-b43a-702c4d517eb8"),
				Name = @"SupplyPaymentElement",
				ReferenceSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				ModifiedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a")
			};
		}

		protected virtual EntitySchemaColumn CreateSupplyPaymentProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("35d1dcfa-9043-4353-af77-eb122f227453"),
				Name = @"SupplyPaymentProduct",
				ReferenceSchemaUId = new Guid("5e50c5fa-41cc-4c91-a04f-9d7888236c1c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				ModifiedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a")
			};
		}

		protected virtual EntitySchemaColumn CreateOrderProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2a863b50-214c-41f0-8d20-bb9042a7571b"),
				Name = @"OrderProduct",
				ReferenceSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				ModifiedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a")
			};
		}

		protected virtual EntitySchemaColumn CreateUsedQuantityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("b1141a69-1c47-4263-af95-ba3ca3e54d8b"),
				Name = @"UsedQuantity",
				CreatedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				ModifiedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a")
			};
		}

		protected virtual EntitySchemaColumn CreateUsedAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("1333adb9-3cef-450c-8d98-7bca3090571b"),
				Name = @"UsedAmount",
				CreatedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				ModifiedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a")
			};
		}

		protected virtual EntitySchemaColumn CreateMaxQuantityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("98b768be-0360-481e-b3e6-9ca26ddf6769"),
				Name = @"MaxQuantity",
				CreatedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				ModifiedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDistributedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3444fc14-c107-4926-a893-90913f9028f1"),
				Name = @"IsDistributed",
				CreatedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				ModifiedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				CreatedInPackageId = new Guid("ea2e3ae4-7b44-4850-bdfa-8147ce4d763d")
			};
		}

		protected virtual EntitySchemaColumn CreatePriceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("a5fcdcaa-1f34-4030-aa1e-08f2cf5b5237"),
				Name = @"Price",
				CreatedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				ModifiedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				CreatedInPackageId = new Guid("6f755330-bde3-4969-8b89-b0bc46685fbc")
			};
		}

		protected virtual EntitySchemaColumn CreateDiscountPercentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("92d9c377-2a35-494f-b44c-c7406cb6c795"),
				Name = @"DiscountPercent",
				CreatedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				ModifiedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				CreatedInPackageId = new Guid("6f755330-bde3-4969-8b89-b0bc46685fbc")
			};
		}

		protected virtual EntitySchemaColumn CreateDiscountAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("a669eb1d-8278-4d7d-dbf4-a5ed549122f8"),
				Name = @"DiscountAmount",
				CreatedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				ModifiedInSchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"),
				CreatedInPackageId = new Guid("0e488ac0-fe51-4dc3-8d9a-11caac414976")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSupplyPaymentProduct_Passport_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSupplyPaymentProduct_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSupplyPaymentProduct_Passport_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSupplyPaymentProduct_Passport_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSupplyPaymentProduct_Passport_BPMSoft

	/// <summary>
	/// Доступные продукты графика поставок и оплат.
	/// </summary>
	public class VwSupplyPaymentProduct_Passport_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSupplyPaymentProduct_Passport_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSupplyPaymentProduct_Passport_BPMSoft";
		}

		public VwSupplyPaymentProduct_Passport_BPMSoft(VwSupplyPaymentProduct_Passport_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SupplyPaymentElementId {
			get {
				return GetTypedColumnValue<Guid>("SupplyPaymentElementId");
			}
			set {
				SetColumnValue("SupplyPaymentElementId", value);
				_supplyPaymentElement = null;
			}
		}

		/// <exclude/>
		public string SupplyPaymentElementName {
			get {
				return GetTypedColumnValue<string>("SupplyPaymentElementName");
			}
			set {
				SetColumnValue("SupplyPaymentElementName", value);
				if (_supplyPaymentElement != null) {
					_supplyPaymentElement.Name = value;
				}
			}
		}

		private SupplyPaymentElement _supplyPaymentElement;
		/// <summary>
		/// Шаг графика поставок и оплат.
		/// </summary>
		public SupplyPaymentElement SupplyPaymentElement {
			get {
				return _supplyPaymentElement ??
					(_supplyPaymentElement = LookupColumnEntities.GetEntity("SupplyPaymentElement") as SupplyPaymentElement);
			}
		}

		/// <exclude/>
		public Guid SupplyPaymentProductId {
			get {
				return GetTypedColumnValue<Guid>("SupplyPaymentProductId");
			}
			set {
				SetColumnValue("SupplyPaymentProductId", value);
				_supplyPaymentProduct = null;
			}
		}

		private SupplyPaymentProduct _supplyPaymentProduct;
		/// <summary>
		/// Продукт графика поставок и оплат.
		/// </summary>
		public SupplyPaymentProduct SupplyPaymentProduct {
			get {
				return _supplyPaymentProduct ??
					(_supplyPaymentProduct = LookupColumnEntities.GetEntity("SupplyPaymentProduct") as SupplyPaymentProduct);
			}
		}

		/// <exclude/>
		public Guid OrderProductId {
			get {
				return GetTypedColumnValue<Guid>("OrderProductId");
			}
			set {
				SetColumnValue("OrderProductId", value);
				_orderProduct = null;
			}
		}

		/// <exclude/>
		public string OrderProductName {
			get {
				return GetTypedColumnValue<string>("OrderProductName");
			}
			set {
				SetColumnValue("OrderProductName", value);
				if (_orderProduct != null) {
					_orderProduct.Name = value;
				}
			}
		}

		private OrderProduct _orderProduct;
		/// <summary>
		/// Продукт.
		/// </summary>
		public OrderProduct OrderProduct {
			get {
				return _orderProduct ??
					(_orderProduct = LookupColumnEntities.GetEntity("OrderProduct") as OrderProduct);
			}
		}

		/// <summary>
		/// Количество.
		/// </summary>
		public Decimal UsedQuantity {
			get {
				return GetTypedColumnValue<Decimal>("UsedQuantity");
			}
			set {
				SetColumnValue("UsedQuantity", value);
			}
		}

		/// <summary>
		/// Сумма.
		/// </summary>
		public Decimal UsedAmount {
			get {
				return GetTypedColumnValue<Decimal>("UsedAmount");
			}
			set {
				SetColumnValue("UsedAmount", value);
			}
		}

		/// <summary>
		/// Доступно.
		/// </summary>
		public Decimal MaxQuantity {
			get {
				return GetTypedColumnValue<Decimal>("MaxQuantity");
			}
			set {
				SetColumnValue("MaxQuantity", value);
			}
		}

		/// <summary>
		/// Распределен.
		/// </summary>
		public int IsDistributed {
			get {
				return GetTypedColumnValue<int>("IsDistributed");
			}
			set {
				SetColumnValue("IsDistributed", value);
			}
		}

		/// <summary>
		/// Цена.
		/// </summary>
		public Decimal Price {
			get {
				return GetTypedColumnValue<Decimal>("Price");
			}
			set {
				SetColumnValue("Price", value);
			}
		}

		/// <summary>
		/// Скидка, %.
		/// </summary>
		public Decimal DiscountPercent {
			get {
				return GetTypedColumnValue<Decimal>("DiscountPercent");
			}
			set {
				SetColumnValue("DiscountPercent", value);
			}
		}

		/// <summary>
		/// Сумма скидки.
		/// </summary>
		public Decimal DiscountAmount {
			get {
				return GetTypedColumnValue<Decimal>("DiscountAmount");
			}
			set {
				SetColumnValue("DiscountAmount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSupplyPaymentProduct_PassportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSupplyPaymentProduct_Passport_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("VwSupplyPaymentProduct_Passport_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSupplyPaymentProduct_Passport_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSupplyPaymentProduct_PassportEventsProcess

	/// <exclude/>
	public partial class VwSupplyPaymentProduct_PassportEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSupplyPaymentProduct_Passport_BPMSoft
	{

		public VwSupplyPaymentProduct_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSupplyPaymentProduct_PassportEventsProcess";
			SchemaUId = new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("69fe7c6b-e6cf-4f60-af51-5dede58906cb");
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

	#region Class: VwSupplyPaymentProduct_PassportEventsProcess

	/// <exclude/>
	public class VwSupplyPaymentProduct_PassportEventsProcess : VwSupplyPaymentProduct_PassportEventsProcess<VwSupplyPaymentProduct_Passport_BPMSoft>
	{

		public VwSupplyPaymentProduct_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSupplyPaymentProduct_PassportEventsProcess

	public partial class VwSupplyPaymentProduct_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

