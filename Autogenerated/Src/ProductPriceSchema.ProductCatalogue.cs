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

	#region Class: ProductPrice_ProductCatalogue_BPMSoftSchema

	/// <exclude/>
	public class ProductPrice_ProductCatalogue_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProductPrice_ProductCatalogue_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductPrice_ProductCatalogue_BPMSoftSchema(ProductPrice_ProductCatalogue_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductPrice_ProductCatalogue_BPMSoftSchema(ProductPrice_ProductCatalogue_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3");
			RealUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3");
			Name = "ProductPrice_ProductCatalogue_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("977fbc10-2e8f-4ad3-a98f-da1d7f52a2e1")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("b1bb8a4f-0f43-4f71-aaba-5208d9944676")) == null) {
				Columns.Add(CreateCurrencyColumn());
			}
			if (Columns.FindByUId(new Guid("5575acd0-57f5-4eca-a9ff-075495e89ae4")) == null) {
				Columns.Add(CreateTaxColumn());
			}
			if (Columns.FindByUId(new Guid("9c418440-11fc-45d0-b1a2-aea6415f29d3")) == null) {
				Columns.Add(CreatePriceColumn());
			}
			if (Columns.FindByUId(new Guid("302e9470-1bfd-4907-b336-95f891378535")) == null) {
				Columns.Add(CreatePriceListColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("977fbc10-2e8f-4ad3-a98f-da1d7f52a2e1"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"),
				ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b1bb8a4f-0f43-4f71-aaba-5208d9944676"),
				Name = @"Currency",
				ReferenceSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"),
				ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"PrimaryCurrency"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5575acd0-57f5-4eca-a9ff-075495e89ae4"),
				Name = @"Tax",
				ReferenceSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"),
				ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"DefaultTax"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePriceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("9c418440-11fc-45d0-b1a2-aea6415f29d3"),
				Name = @"Price",
				CreatedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"),
				ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467")
			};
		}

		protected virtual EntitySchemaColumn CreatePriceListColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("302e9470-1bfd-4907-b336-95f891378535"),
				Name = @"PriceList",
				ReferenceSchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"),
				ModifiedInSchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"BasePriceList"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductPrice_ProductCatalogue_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductPrice_ProductCatalogueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductPrice_ProductCatalogue_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductPrice_ProductCatalogue_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductPrice_ProductCatalogue_BPMSoft

	/// <summary>
	/// Цена продукта.
	/// </summary>
	public class ProductPrice_ProductCatalogue_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProductPrice_ProductCatalogue_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductPrice_ProductCatalogue_BPMSoft";
		}

		public ProductPrice_ProductCatalogue_BPMSoft(ProductPrice_ProductCatalogue_BPMSoft source)
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

		/// <exclude/>
		public Guid TaxId {
			get {
				return GetTypedColumnValue<Guid>("TaxId");
			}
			set {
				SetColumnValue("TaxId", value);
				_tax = null;
			}
		}

		/// <exclude/>
		public string TaxName {
			get {
				return GetTypedColumnValue<string>("TaxName");
			}
			set {
				SetColumnValue("TaxName", value);
				if (_tax != null) {
					_tax.Name = value;
				}
			}
		}

		private Tax _tax;
		/// <summary>
		/// Налог.
		/// </summary>
		public Tax Tax {
			get {
				return _tax ??
					(_tax = LookupColumnEntities.GetEntity("Tax") as Tax);
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

		/// <exclude/>
		public Guid PriceListId {
			get {
				return GetTypedColumnValue<Guid>("PriceListId");
			}
			set {
				SetColumnValue("PriceListId", value);
				_priceList = null;
			}
		}

		/// <exclude/>
		public string PriceListName {
			get {
				return GetTypedColumnValue<string>("PriceListName");
			}
			set {
				SetColumnValue("PriceListName", value);
				if (_priceList != null) {
					_priceList.Name = value;
				}
			}
		}

		private Pricelist _priceList;
		/// <summary>
		/// Прайс-лист.
		/// </summary>
		public Pricelist PriceList {
			get {
				return _priceList ??
					(_priceList = LookupColumnEntities.GetEntity("PriceList") as Pricelist);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductPrice_ProductCatalogueEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductPrice_ProductCatalogue_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductPrice_ProductCatalogue_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("ProductPrice_ProductCatalogue_BPMSoftSaved", e);
			Validating += (s, e) => ThrowEvent("ProductPrice_ProductCatalogue_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductPrice_ProductCatalogue_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductPrice_ProductCatalogueEventsProcess

	/// <exclude/>
	public partial class ProductPrice_ProductCatalogueEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ProductPrice_ProductCatalogue_BPMSoft
	{

		public ProductPrice_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductPrice_ProductCatalogueEventsProcess";
			SchemaUId = new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dd9a991c-01a6-44f1-b1ae-ebaf75800ee3");
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
					SchemaElementUId = new Guid("7f5039b2-1e9c-4db2-8b04-8fa74e09e62a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _productPriceSaved;
		public ProcessFlowElement ProductPriceSaved {
			get {
				return _productPriceSaved ?? (_productPriceSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ProductPriceSaved",
					SchemaElementUId = new Guid("c09c0cb3-d083-416e-9620-a5d256523132"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _actulizePriceInProduct;
		public ProcessScriptTask ActulizePriceInProduct {
			get {
				return _actulizePriceInProduct ?? (_actulizePriceInProduct = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActulizePriceInProduct",
					SchemaElementUId = new Guid("eb55167c-466c-458a-aa88-371089f9223b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActulizePriceInProductExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ProductPriceSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ProductPriceSaved };
			FlowElements[ActulizePriceInProduct.SchemaElementUId] = new Collection<ProcessFlowElement> { ActulizePriceInProduct };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ProductPriceSaved":
						e.Context.QueueTasks.Enqueue("ActulizePriceInProduct");
						break;
					case "ActulizePriceInProduct":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ProductPriceSaved");
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
				case "ProductPriceSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProductPriceSaved";
					result = ProductPriceSaved.Execute(context);
					break;
				case "ActulizePriceInProduct":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActulizePriceInProduct";
					result = ActulizePriceInProduct.Execute(context, ActulizePriceInProductExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ActulizePriceInProductExecute(ProcessExecutingContext context) {
			var productPriceHelper = BPMSoft.Core.Factories.ClassFactory.Get<BPMSoft.Configuration.ProductPriceHelper>(
				new BPMSoft.Core.Factories.ConstructorArgument("userConnection", UserConnection));
			productPriceHelper.SetPriceInProduct(Entity);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ProductPrice_ProductCatalogue_BPMSoftSaved":
							if (ActivatedEventElements.Contains("ProductPriceSaved")) {
							context.QueueTasks.Enqueue("ProductPriceSaved");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ProductPrice_ProductCatalogueEventsProcess

	/// <exclude/>
	public class ProductPrice_ProductCatalogueEventsProcess : ProductPrice_ProductCatalogueEventsProcess<ProductPrice_ProductCatalogue_BPMSoft>
	{

		public ProductPrice_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductPrice_ProductCatalogueEventsProcess

	public partial class ProductPrice_ProductCatalogueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

