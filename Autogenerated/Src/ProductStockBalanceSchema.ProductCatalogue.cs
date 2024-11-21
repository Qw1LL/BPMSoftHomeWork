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

	#region Class: ProductStockBalanceSchema

	/// <exclude/>
	public class ProductStockBalanceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProductStockBalanceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductStockBalanceSchema(ProductStockBalanceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductStockBalanceSchema(ProductStockBalanceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c");
			RealUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c");
			Name = "ProductStockBalance";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("46234a17-f20d-4296-8bf9-ed56380208a0")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("fef0f8bc-f68c-4c86-b10a-a4b3daea65fd")) == null) {
				Columns.Add(CreateTotalQuantityColumn());
			}
			if (Columns.FindByUId(new Guid("d904455a-12f0-4626-ae10-d2719eeff146")) == null) {
				Columns.Add(CreateReserveQuantityColumn());
			}
			if (Columns.FindByUId(new Guid("047898fd-2b76-45f5-8f07-9659214c9103")) == null) {
				Columns.Add(CreateAvailableQuantityColumn());
			}
			if (Columns.FindByUId(new Guid("8e73ef53-54b6-4302-9caa-50e1f4be8c14")) == null) {
				Columns.Add(CreateWarehouseColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("46234a17-f20d-4296-8bf9-ed56380208a0"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"),
				ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"),
				CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab")
			};
		}

		protected virtual EntitySchemaColumn CreateTotalQuantityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float3")) {
				UId = new Guid("fef0f8bc-f68c-4c86-b10a-a4b3daea65fd"),
				Name = @"TotalQuantity",
				CreatedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"),
				ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"),
				CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab")
			};
		}

		protected virtual EntitySchemaColumn CreateReserveQuantityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float3")) {
				UId = new Guid("d904455a-12f0-4626-ae10-d2719eeff146"),
				Name = @"ReserveQuantity",
				CreatedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"),
				ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"),
				CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab")
			};
		}

		protected virtual EntitySchemaColumn CreateAvailableQuantityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float3")) {
				UId = new Guid("047898fd-2b76-45f5-8f07-9659214c9103"),
				Name = @"AvailableQuantity",
				CreatedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"),
				ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"),
				CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab")
			};
		}

		protected virtual EntitySchemaColumn CreateWarehouseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8e73ef53-54b6-4302-9caa-50e1f4be8c14"),
				Name = @"Warehouse",
				ReferenceSchemaUId = new Guid("70daff1b-1b40-4ac3-9c93-cd76e1835fe3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"),
				ModifiedInSchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"),
				CreatedInPackageId = new Guid("a637dd4e-eb51-48a6-87f0-a0fabbc2fa75")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductStockBalance(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductStockBalance_ProductCatalogueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductStockBalanceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductStockBalanceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductStockBalance

	/// <summary>
	/// Остаток продукта.
	/// </summary>
	public class ProductStockBalance : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProductStockBalance(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductStockBalance";
		}

		public ProductStockBalance(ProductStockBalance source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProductId {
			get {
				return GetTypedColumnValue<Guid>("ProductId");
			}
			set {
				SetColumnValue("ProductId", value);
				_product = null;
			}
		}

		/// <exclude/>
		public string ProductName {
			get {
				return GetTypedColumnValue<string>("ProductName");
			}
			set {
				SetColumnValue("ProductName", value);
				if (_product != null) {
					_product.Name = value;
				}
			}
		}

		private Product _product;
		/// <summary>
		/// Продукт.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = LookupColumnEntities.GetEntity("Product") as Product);
			}
		}

		/// <summary>
		/// Остаток.
		/// </summary>
		public Decimal TotalQuantity {
			get {
				return GetTypedColumnValue<Decimal>("TotalQuantity");
			}
			set {
				SetColumnValue("TotalQuantity", value);
			}
		}

		/// <summary>
		/// Резерв.
		/// </summary>
		public Decimal ReserveQuantity {
			get {
				return GetTypedColumnValue<Decimal>("ReserveQuantity");
			}
			set {
				SetColumnValue("ReserveQuantity", value);
			}
		}

		/// <summary>
		/// Доступно.
		/// </summary>
		public Decimal AvailableQuantity {
			get {
				return GetTypedColumnValue<Decimal>("AvailableQuantity");
			}
			set {
				SetColumnValue("AvailableQuantity", value);
			}
		}

		/// <exclude/>
		public Guid WarehouseId {
			get {
				return GetTypedColumnValue<Guid>("WarehouseId");
			}
			set {
				SetColumnValue("WarehouseId", value);
				_warehouse = null;
			}
		}

		/// <exclude/>
		public string WarehouseName {
			get {
				return GetTypedColumnValue<string>("WarehouseName");
			}
			set {
				SetColumnValue("WarehouseName", value);
				if (_warehouse != null) {
					_warehouse.Name = value;
				}
			}
		}

		private Warehouse _warehouse;
		/// <summary>
		/// Склад.
		/// </summary>
		public Warehouse Warehouse {
			get {
				return _warehouse ??
					(_warehouse = LookupColumnEntities.GetEntity("Warehouse") as Warehouse);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductStockBalance_ProductCatalogueEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductStockBalanceDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductStockBalanceInserting", e);
			Validating += (s, e) => ThrowEvent("ProductStockBalanceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductStockBalance(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductStockBalance_ProductCatalogueEventsProcess

	/// <exclude/>
	public partial class ProductStockBalance_ProductCatalogueEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ProductStockBalance
	{

		public ProductStockBalance_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductStockBalance_ProductCatalogueEventsProcess";
			SchemaUId = new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("45ca8581-a0f1-40d9-b08a-924d9be42a8c");
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

	#region Class: ProductStockBalance_ProductCatalogueEventsProcess

	/// <exclude/>
	public class ProductStockBalance_ProductCatalogueEventsProcess : ProductStockBalance_ProductCatalogueEventsProcess<ProductStockBalance>
	{

		public ProductStockBalance_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductStockBalance_ProductCatalogueEventsProcess

	public partial class ProductStockBalance_ProductCatalogueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductStockBalanceEventsProcess

	/// <exclude/>
	public class ProductStockBalanceEventsProcess : ProductStockBalance_ProductCatalogueEventsProcess
	{

		public ProductStockBalanceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

