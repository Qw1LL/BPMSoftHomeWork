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

	#region Class: ProductFileSchema

	/// <exclude/>
	public class ProductFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public ProductFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductFileSchema(ProductFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductFileSchema(ProductFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("80ccf8ab-2514-49ce-adea-3de1b6f249e3");
			RealUId = new Guid("80ccf8ab-2514-49ce-adea-3de1b6f249e3");
			Name = "ProductFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9590f798-1c5f-4933-927c-48da921c2cc2")) == null) {
				Columns.Add(CreateProductColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("80ccf8ab-2514-49ce-adea-3de1b6f249e3");
			return column;
		}

		protected override EntitySchemaColumn CreateDataColumn() {
			EntitySchemaColumn column = base.CreateDataColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("80ccf8ab-2514-49ce-adea-3de1b6f249e3");
			return column;
		}

		protected override EntitySchemaColumn CreateVersionColumn() {
			EntitySchemaColumn column = base.CreateVersionColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("80ccf8ab-2514-49ce-adea-3de1b6f249e3");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9590f798-1c5f-4933-927c-48da921c2cc2"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("80ccf8ab-2514-49ce-adea-3de1b6f249e3"),
				ModifiedInSchemaUId = new Guid("80ccf8ab-2514-49ce-adea-3de1b6f249e3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductFile_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("80ccf8ab-2514-49ce-adea-3de1b6f249e3"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductFile

	/// <summary>
	/// Product attachment.
	/// </summary>
	public class ProductFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public ProductFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductFile";
		}

		public ProductFile(ProductFile source)
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
		/// Product.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = LookupColumnEntities.GetEntity("Product") as Product);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductFile_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductFileDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductFileInserting", e);
			Updated += (s, e) => ThrowEvent("ProductFileUpdated", e);
			Validating += (s, e) => ThrowEvent("ProductFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductFile_BaseEventsProcess

	/// <exclude/>
	public partial class ProductFile_BaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : ProductFile
	{

		public ProductFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductFile_BaseEventsProcess";
			SchemaUId = new Guid("80ccf8ab-2514-49ce-adea-3de1b6f249e3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("80ccf8ab-2514-49ce-adea-3de1b6f249e3");
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

	#region Class: ProductFile_BaseEventsProcess

	/// <exclude/>
	public class ProductFile_BaseEventsProcess : ProductFile_BaseEventsProcess<ProductFile>
	{

		public ProductFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductFile_BaseEventsProcess

	public partial class ProductFile_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductFileEventsProcess

	/// <exclude/>
	public class ProductFileEventsProcess : ProductFile_BaseEventsProcess
	{

		public ProductFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

