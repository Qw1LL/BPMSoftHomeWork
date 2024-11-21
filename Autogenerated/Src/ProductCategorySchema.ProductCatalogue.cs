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

	#region Class: ProductCategorySchema

	/// <exclude/>
	public class ProductCategorySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ProductCategorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductCategorySchema(ProductCategorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductCategorySchema(ProductCategorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			RealUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			Name = "ProductCategory";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			column.CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductCategory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductCategory_ProductCatalogueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductCategorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductCategorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3e22e8d3-36f6-4c32-adbe-678155527541"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductCategory

	/// <summary>
	/// Категория продукта.
	/// </summary>
	public class ProductCategory : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ProductCategory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductCategory";
		}

		public ProductCategory(ProductCategory source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductCategory_ProductCatalogueEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductCategoryDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductCategoryInserting", e);
			Validating += (s, e) => ThrowEvent("ProductCategoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductCategory(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductCategory_ProductCatalogueEventsProcess

	/// <exclude/>
	public partial class ProductCategory_ProductCatalogueEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ProductCategory
	{

		public ProductCategory_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductCategory_ProductCatalogueEventsProcess";
			SchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3e22e8d3-36f6-4c32-adbe-678155527541");
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

	#region Class: ProductCategory_ProductCatalogueEventsProcess

	/// <exclude/>
	public class ProductCategory_ProductCatalogueEventsProcess : ProductCategory_ProductCatalogueEventsProcess<ProductCategory>
	{

		public ProductCategory_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductCategory_ProductCatalogueEventsProcess

	public partial class ProductCategory_ProductCatalogueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductCategoryEventsProcess

	/// <exclude/>
	public class ProductCategoryEventsProcess : ProductCategory_ProductCatalogueEventsProcess
	{

		public ProductCategoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

