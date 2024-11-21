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

	#region Class: ProductTypeSchema

	/// <exclude/>
	public class ProductTypeSchema : BPMSoft.Configuration.ProductType_ProductBase_BPMSoftSchema
	{

		#region Constructors: Public

		public ProductTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductTypeSchema(ProductTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductTypeSchema(ProductTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("eeb575f1-edb7-4278-a702-680b7b8fd545");
			Name = "ProductType";
			ParentSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("694a7a4e-a952-4163-a0ce-df045e72aedb")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("694a7a4e-a952-4163-a0ce-df045e72aedb"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("eeb575f1-edb7-4278-a702-680b7b8fd545"),
				ModifiedInSchemaUId = new Guid("eeb575f1-edb7-4278-a702-680b7b8fd545"),
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
			return new ProductType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductType_ProductCatalogueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eeb575f1-edb7-4278-a702-680b7b8fd545"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductType

	/// <summary>
	/// Тип продукта.
	/// </summary>
	public class ProductType : BPMSoft.Configuration.ProductType_ProductBase_BPMSoft
	{

		#region Constructors: Public

		public ProductType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductType";
		}

		public ProductType(ProductType source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductType_ProductCatalogueEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductTypeInserting", e);
			Validating += (s, e) => ThrowEvent("ProductTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductType_ProductCatalogueEventsProcess

	/// <exclude/>
	public partial class ProductType_ProductCatalogueEventsProcess<TEntity> : BPMSoft.Configuration.ProductType_ProductBaseEventsProcess<TEntity> where TEntity : ProductType
	{

		public ProductType_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductType_ProductCatalogueEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eeb575f1-edb7-4278-a702-680b7b8fd545");
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

	#region Class: ProductType_ProductCatalogueEventsProcess

	/// <exclude/>
	public class ProductType_ProductCatalogueEventsProcess : ProductType_ProductCatalogueEventsProcess<ProductType>
	{

		public ProductType_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductType_ProductCatalogueEventsProcess

	public partial class ProductType_ProductCatalogueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductTypeEventsProcess

	/// <exclude/>
	public class ProductTypeEventsProcess : ProductType_ProductCatalogueEventsProcess
	{

		public ProductTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

