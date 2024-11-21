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

	#region Class: ProductUnit_ProductCatalogue_BPMSoftSchema

	/// <exclude/>
	public class ProductUnit_ProductCatalogue_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProductUnit_ProductCatalogue_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductUnit_ProductCatalogue_BPMSoftSchema(ProductUnit_ProductCatalogue_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductUnit_ProductCatalogue_BPMSoftSchema(ProductUnit_ProductCatalogue_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089");
			RealUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089");
			Name = "ProductUnit_ProductCatalogue_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1a63dafe-d633-4a06-9e3f-4750a553b336")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("86b00b9c-fb90-4a47-a136-907ec786ace8")) == null) {
				Columns.Add(CreateUnitColumn());
			}
			if (Columns.FindByUId(new Guid("419a8d58-699f-4c5e-bc90-816e8ba110a6")) == null) {
				Columns.Add(CreateIsBaseColumn());
			}
			if (Columns.FindByUId(new Guid("062a695b-e095-4e24-8be5-522b26bd0e3d")) == null) {
				Columns.Add(CreateNumberOfBaseUnitsColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1a63dafe-d633-4a06-9e3f-4750a553b336"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089"),
				ModifiedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467")
			};
		}

		protected virtual EntitySchemaColumn CreateUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("86b00b9c-fb90-4a47-a136-907ec786ace8"),
				Name = @"Unit",
				ReferenceSchemaUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089"),
				ModifiedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467")
			};
		}

		protected virtual EntitySchemaColumn CreateIsBaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("419a8d58-699f-4c5e-bc90-816e8ba110a6"),
				Name = @"IsBase",
				CreatedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089"),
				ModifiedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNumberOfBaseUnitsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float3")) {
				UId = new Guid("062a695b-e095-4e24-8be5-522b26bd0e3d"),
				Name = @"NumberOfBaseUnits",
				CreatedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089"),
				ModifiedInSchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089"),
				CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductUnit_ProductCatalogue_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductUnit_ProductCatalogueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductUnit_ProductCatalogue_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductUnit_ProductCatalogue_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductUnit_ProductCatalogue_BPMSoft

	/// <summary>
	/// Единица измерения продукта.
	/// </summary>
	public class ProductUnit_ProductCatalogue_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProductUnit_ProductCatalogue_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductUnit_ProductCatalogue_BPMSoft";
		}

		public ProductUnit_ProductCatalogue_BPMSoft(ProductUnit_ProductCatalogue_BPMSoft source)
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
		public Guid UnitId {
			get {
				return GetTypedColumnValue<Guid>("UnitId");
			}
			set {
				SetColumnValue("UnitId", value);
				_unit = null;
			}
		}

		/// <exclude/>
		public string UnitName {
			get {
				return GetTypedColumnValue<string>("UnitName");
			}
			set {
				SetColumnValue("UnitName", value);
				if (_unit != null) {
					_unit.Name = value;
				}
			}
		}

		private Unit _unit;
		/// <summary>
		/// Единица измерения.
		/// </summary>
		public Unit Unit {
			get {
				return _unit ??
					(_unit = LookupColumnEntities.GetEntity("Unit") as Unit);
			}
		}

		/// <summary>
		/// Базовая.
		/// </summary>
		public bool IsBase {
			get {
				return GetTypedColumnValue<bool>("IsBase");
			}
			set {
				SetColumnValue("IsBase", value);
			}
		}

		/// <summary>
		/// Базовых единиц.
		/// </summary>
		public Decimal NumberOfBaseUnits {
			get {
				return GetTypedColumnValue<Decimal>("NumberOfBaseUnits");
			}
			set {
				SetColumnValue("NumberOfBaseUnits", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductUnit_ProductCatalogueEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductUnit_ProductCatalogue_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductUnit_ProductCatalogue_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("ProductUnit_ProductCatalogue_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductUnit_ProductCatalogue_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductUnit_ProductCatalogueEventsProcess

	/// <exclude/>
	public partial class ProductUnit_ProductCatalogueEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ProductUnit_ProductCatalogue_BPMSoft
	{

		public ProductUnit_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductUnit_ProductCatalogueEventsProcess";
			SchemaUId = new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("34e3e6a8-32c0-4451-9565-c295a9d8a089");
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

	#region Class: ProductUnit_ProductCatalogueEventsProcess

	/// <exclude/>
	public class ProductUnit_ProductCatalogueEventsProcess : ProductUnit_ProductCatalogueEventsProcess<ProductUnit_ProductCatalogue_BPMSoft>
	{

		public ProductUnit_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductUnit_ProductCatalogueEventsProcess

	public partial class ProductUnit_ProductCatalogueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

