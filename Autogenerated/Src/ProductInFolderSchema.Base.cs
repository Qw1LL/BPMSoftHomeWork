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

	#region Class: ProductInFolderSchema

	/// <exclude/>
	public class ProductInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public ProductInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductInFolderSchema(ProductInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductInFolderSchema(ProductInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("473d7dcb-3fa6-436a-aca9-dd9dae398167");
			RealUId = new Guid("473d7dcb-3fa6-436a-aca9-dd9dae398167");
			Name = "ProductInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9af8bfdb-4351-422f-87f7-2248797adbcb")) == null) {
				Columns.Add(CreateProductColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("4c1f5748-24fe-4226-bd13-df099094c0e5");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("473d7dcb-3fa6-436a-aca9-dd9dae398167");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9af8bfdb-4351-422f-87f7-2248797adbcb"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("473d7dcb-3fa6-436a-aca9-dd9dae398167"),
				ModifiedInSchemaUId = new Guid("473d7dcb-3fa6-436a-aca9-dd9dae398167"),
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
			return new ProductInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("473d7dcb-3fa6-436a-aca9-dd9dae398167"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductInFolder

	/// <summary>
	/// Product in folder.
	/// </summary>
	public class ProductInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public ProductInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductInFolder";
		}

		public ProductInFolder(ProductInFolder source)
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
			var process = new ProductInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductInFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductInFolderInserting", e);
			Validating += (s, e) => ThrowEvent("ProductInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class ProductInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : ProductInFolder
	{

		public ProductInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductInFolder_BaseEventsProcess";
			SchemaUId = new Guid("473d7dcb-3fa6-436a-aca9-dd9dae398167");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("473d7dcb-3fa6-436a-aca9-dd9dae398167");
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

	#region Class: ProductInFolder_BaseEventsProcess

	/// <exclude/>
	public class ProductInFolder_BaseEventsProcess : ProductInFolder_BaseEventsProcess<ProductInFolder>
	{

		public ProductInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductInFolder_BaseEventsProcess

	public partial class ProductInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductInFolderEventsProcess

	/// <exclude/>
	public class ProductInFolderEventsProcess : ProductInFolder_BaseEventsProcess
	{

		public ProductInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

