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

	#region Class: ProductSchema

	/// <exclude/>
	public class ProductSchema : BPMSoft.Configuration.Product_ProductCatalogue_BPMSoftSchema
	{

		#region Constructors: Public

		public ProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductSchema(ProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductSchema(ProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("286da5ec-5752-4a1b-9be4-806a6d056543");
			Name = "Product";
			ParentSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed");
			ExtendParent = true;
			CreatedInPackageId = new Guid("10676561-1f93-46bf-90be-fe5cd67025e0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateUnitColumn() {
			EntitySchemaColumn column = base.CreateUnitColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"DefaultUnit"
			};
			column.ModifiedInSchemaUId = new Guid("286da5ec-5752-4a1b-9be4-806a6d056543");
			return column;
		}

		protected override EntitySchemaColumn CreateCurrencyColumn() {
			EntitySchemaColumn column = base.CreateCurrencyColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"PrimaryCurrency"
			};
			column.ModifiedInSchemaUId = new Guid("286da5ec-5752-4a1b-9be4-806a6d056543");
			return column;
		}

		protected override EntitySchemaColumn CreateTaxColumn() {
			EntitySchemaColumn column = base.CreateTaxColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"DefaultTax"
			};
			column.ModifiedInSchemaUId = new Guid("286da5ec-5752-4a1b-9be4-806a6d056543");
			return column;
		}

		protected override EntitySchemaColumn CreateOwnerColumn() {
			EntitySchemaColumn column = base.CreateOwnerColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.SystemValue,
				ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
			};
			column.ModifiedInSchemaUId = new Guid("286da5ec-5752-4a1b-9be4-806a6d056543");
			return column;
		}

		protected override EntitySchemaColumn CreateProductSourceColumn() {
			EntitySchemaColumn column = base.CreateProductSourceColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"5facb8b4-ed6a-41bb-b224-659c2bf1eb8a"
			};
			column.ModifiedInSchemaUId = new Guid("286da5ec-5752-4a1b-9be4-806a6d056543");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Product(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Product_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("286da5ec-5752-4a1b-9be4-806a6d056543"));
		}

		#endregion

	}

	#endregion

	#region Class: Product

	/// <summary>
	/// Продукт.
	/// </summary>
	public class Product : BPMSoft.Configuration.Product_ProductCatalogue_BPMSoft
	{

		#region Constructors: Public

		public Product(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Product";
		}

		public Product(Product source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Product_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductDeleted", e);
			Validating += (s, e) => ThrowEvent("ProductValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Product(this);
		}

		#endregion

	}

	#endregion

	#region Class: Product_PRMPortalEventsProcess

	/// <exclude/>
	public partial class Product_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.Product_ProductCatalogueEventsProcess<TEntity> where TEntity : Product
	{

		public Product_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Product_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("286da5ec-5752-4a1b-9be4-806a6d056543");
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

	#region Class: Product_PRMPortalEventsProcess

	/// <exclude/>
	public class Product_PRMPortalEventsProcess : Product_PRMPortalEventsProcess<Product>
	{

		public Product_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Product_PRMPortalEventsProcess

	public partial class Product_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductEventsProcess

	/// <exclude/>
	public class ProductEventsProcess : Product_PRMPortalEventsProcess
	{

		public ProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

