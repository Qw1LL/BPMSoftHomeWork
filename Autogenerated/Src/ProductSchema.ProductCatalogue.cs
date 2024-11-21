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

	#region Class: Product_ProductCatalogue_BPMSoftSchema

	/// <exclude/>
	public class Product_ProductCatalogue_BPMSoftSchema : BPMSoft.Configuration.Product_ProductBase_BPMSoftSchema
	{

		#region Constructors: Public

		public Product_ProductCatalogue_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Product_ProductCatalogue_BPMSoftSchema(Product_ProductCatalogue_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Product_ProductCatalogue_BPMSoftSchema(Product_ProductCatalogue_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2");
			Name = "Product_ProductCatalogue_BPMSoft";
			ParentSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("84c5953d-e261-449e-9189-8fac859db36d")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("bc105fcf-3068-4525-9c22-efc1942262cd")) == null) {
				Columns.Add(CreateTradeMarkColumn());
			}
			if (Columns.FindByUId(new Guid("374c1573-9519-1354-cfd0-e8e05f9bf139")) == null) {
				Columns.Add(CreateShortDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("fa2b1d57-70d8-de17-b6ef-489f7ce676e5")) == null) {
				Columns.Add(CreateBenefitsColumn());
			}
			if (Columns.FindByUId(new Guid("a1f91e7a-b322-de8c-9482-373b7cf109e1")) == null) {
				Columns.Add(CreateGeneralConditionsColumn());
			}
		}

		protected override EntitySchemaColumn CreateUnitColumn() {
			EntitySchemaColumn column = base.CreateUnitColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"DefaultUnit"
			};
			column.ModifiedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2");
			return column;
		}

		protected override EntitySchemaColumn CreateCurrencyColumn() {
			EntitySchemaColumn column = base.CreateCurrencyColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"PrimaryCurrency"
			};
			column.ModifiedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2");
			return column;
		}

		protected override EntitySchemaColumn CreateTaxColumn() {
			EntitySchemaColumn column = base.CreateTaxColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"DefaultTax"
			};
			column.ModifiedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2");
			return column;
		}

		protected override EntitySchemaColumn CreateOwnerColumn() {
			EntitySchemaColumn column = base.CreateOwnerColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.SystemValue,
				ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
			};
			column.ModifiedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2");
			return column;
		}

		protected override EntitySchemaColumn CreateProductSourceColumn() {
			EntitySchemaColumn column = base.CreateProductSourceColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"5facb8b4-ed6a-41bb-b224-659c2bf1eb8a"
			};
			column.ModifiedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("84c5953d-e261-449e-9189-8fac859db36d"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"),
				ModifiedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467")
			};
		}

		protected virtual EntitySchemaColumn CreateTradeMarkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bc105fcf-3068-4525-9c22-efc1942262cd"),
				Name = @"TradeMark",
				ReferenceSchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"),
				ModifiedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467")
			};
		}

		protected virtual EntitySchemaColumn CreateShortDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("374c1573-9519-1354-cfd0-e8e05f9bf139"),
				Name = @"ShortDescription",
				CreatedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"),
				ModifiedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"),
				CreatedInPackageId = new Guid("6a5e4b1f-f47c-4cd7-9331-5bb1381386bb")
			};
		}

		protected virtual EntitySchemaColumn CreateBenefitsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("fa2b1d57-70d8-de17-b6ef-489f7ce676e5"),
				Name = @"Benefits",
				CreatedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"),
				ModifiedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"),
				CreatedInPackageId = new Guid("6a5e4b1f-f47c-4cd7-9331-5bb1381386bb")
			};
		}

		protected virtual EntitySchemaColumn CreateGeneralConditionsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a1f91e7a-b322-de8c-9482-373b7cf109e1"),
				Name = @"GeneralConditions",
				CreatedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"),
				ModifiedInSchemaUId = new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"),
				CreatedInPackageId = new Guid("6a5e4b1f-f47c-4cd7-9331-5bb1381386bb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Product_ProductCatalogue_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Product_ProductCatalogueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Product_ProductCatalogue_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Product_ProductCatalogue_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2"));
		}

		#endregion

	}

	#endregion

	#region Class: Product_ProductCatalogue_BPMSoft

	/// <summary>
	/// Продукт.
	/// </summary>
	public class Product_ProductCatalogue_BPMSoft : BPMSoft.Configuration.Product_ProductBase_BPMSoft
	{

		#region Constructors: Public

		public Product_ProductCatalogue_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Product_ProductCatalogue_BPMSoft";
		}

		public Product_ProductCatalogue_BPMSoft(Product_ProductCatalogue_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private ProductCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public ProductCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as ProductCategory);
			}
		}

		/// <exclude/>
		public Guid TradeMarkId {
			get {
				return GetTypedColumnValue<Guid>("TradeMarkId");
			}
			set {
				SetColumnValue("TradeMarkId", value);
				_tradeMark = null;
			}
		}

		/// <exclude/>
		public string TradeMarkName {
			get {
				return GetTypedColumnValue<string>("TradeMarkName");
			}
			set {
				SetColumnValue("TradeMarkName", value);
				if (_tradeMark != null) {
					_tradeMark.Name = value;
				}
			}
		}

		private TradeMark _tradeMark;
		/// <summary>
		/// Торговая марка.
		/// </summary>
		public TradeMark TradeMark {
			get {
				return _tradeMark ??
					(_tradeMark = LookupColumnEntities.GetEntity("TradeMark") as TradeMark);
			}
		}

		/// <summary>
		/// Краткое описание.
		/// </summary>
		public string ShortDescription {
			get {
				return GetTypedColumnValue<string>("ShortDescription");
			}
			set {
				SetColumnValue("ShortDescription", value);
			}
		}

		/// <summary>
		/// Преимущества.
		/// </summary>
		public string Benefits {
			get {
				return GetTypedColumnValue<string>("Benefits");
			}
			set {
				SetColumnValue("Benefits", value);
			}
		}

		/// <summary>
		/// Основные условия.
		/// </summary>
		public string GeneralConditions {
			get {
				return GetTypedColumnValue<string>("GeneralConditions");
			}
			set {
				SetColumnValue("GeneralConditions", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Product_ProductCatalogueEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Product_ProductCatalogue_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Product_ProductCatalogue_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Product_ProductCatalogue_BPMSoftSaved", e);
			Validating += (s, e) => ThrowEvent("Product_ProductCatalogue_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Product_ProductCatalogue_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Product_ProductCatalogueEventsProcess

	/// <exclude/>
	public partial class Product_ProductCatalogueEventsProcess<TEntity> : BPMSoft.Configuration.Product_ProductBaseEventsProcess<TEntity> where TEntity : Product_ProductCatalogue_BPMSoft
	{

		public Product_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Product_ProductCatalogueEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e2e35eeb-1d87-4ce0-b885-c3a8c6c23bd2");
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
					SchemaElementUId = new Guid("7e06e388-ced2-4eca-8ce1-ee29bc77fdb8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _productSaved;
		public ProcessFlowElement ProductSaved {
			get {
				return _productSaved ?? (_productSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ProductSaved",
					SchemaElementUId = new Guid("7b9bf1e0-4946-406e-b815-42e038ebb1ae"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _setPrices;
		public ProcessScriptTask SetPrices {
			get {
				return _setPrices ?? (_setPrices = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetPrices",
					SchemaElementUId = new Guid("73a117ec-7b80-4f1d-9866-7b921e5e89e9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetPricesExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ProductSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ProductSaved };
			FlowElements[SetPrices.SchemaElementUId] = new Collection<ProcessFlowElement> { SetPrices };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ProductSaved":
						e.Context.QueueTasks.Enqueue("SetPrices");
						break;
					case "SetPrices":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ProductSaved");
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
				case "ProductSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProductSaved";
					result = ProductSaved.Execute(context);
					break;
				case "SetPrices":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetPrices";
					result = SetPrices.Execute(context, SetPricesExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SetPricesExecute(ProcessExecutingContext context) {
			var productPriceHelper = BPMSoft.Core.Factories.ClassFactory.Get<BPMSoft.Configuration.ProductPriceHelper>(
				new BPMSoft.Core.Factories.ConstructorArgument("userConnection", UserConnection));
			productPriceHelper.SetPriceInBasePriceList(Entity);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Product_ProductCatalogue_BPMSoftSaved":
							if (ActivatedEventElements.Contains("ProductSaved")) {
							context.QueueTasks.Enqueue("ProductSaved");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Product_ProductCatalogueEventsProcess

	/// <exclude/>
	public class Product_ProductCatalogueEventsProcess : Product_ProductCatalogueEventsProcess<Product_ProductCatalogue_BPMSoft>
	{

		public Product_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Product_ProductCatalogueEventsProcess

	public partial class Product_ProductCatalogueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

