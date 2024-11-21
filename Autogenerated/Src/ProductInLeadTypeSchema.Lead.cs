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

	#region Class: ProductInLeadTypeSchema

	/// <exclude/>
	public class ProductInLeadTypeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProductInLeadTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductInLeadTypeSchema(ProductInLeadTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductInLeadTypeSchema(ProductInLeadTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
			RealUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
			Name = "ProductInLeadType";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2b6f3712-6f24-4801-9fbd-ccdc1623e8d8")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("0fcce791-2c61-478a-a45e-456c0004b3dd")) == null) {
				Columns.Add(CreateProductFolderColumn());
			}
			if (Columns.FindByUId(new Guid("9f959d0f-1b57-4fab-b3ab-b0b8f5f87417")) == null) {
				Columns.Add(CreateLeadTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2b6f3712-6f24-4801-9fbd-ccdc1623e8d8"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1"),
				ModifiedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1"),
				CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae")
			};
		}

		protected virtual EntitySchemaColumn CreateProductFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0fcce791-2c61-478a-a45e-456c0004b3dd"),
				Name = @"ProductFolder",
				ReferenceSchemaUId = new Guid("4c1f5748-24fe-4226-bd13-df099094c0e5"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1"),
				ModifiedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1"),
				CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9f959d0f-1b57-4fab-b3ab-b0b8f5f87417"),
				Name = @"LeadType",
				ReferenceSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1"),
				ModifiedInSchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1"),
				CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductInLeadType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductInLeadType_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductInLeadTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductInLeadTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductInLeadType

	/// <summary>
	/// Продукт в типе потребности.
	/// </summary>
	public class ProductInLeadType : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProductInLeadType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductInLeadType";
		}

		public ProductInLeadType(ProductInLeadType source)
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
		public Guid ProductFolderId {
			get {
				return GetTypedColumnValue<Guid>("ProductFolderId");
			}
			set {
				SetColumnValue("ProductFolderId", value);
				_productFolder = null;
			}
		}

		/// <exclude/>
		public string ProductFolderName {
			get {
				return GetTypedColumnValue<string>("ProductFolderName");
			}
			set {
				SetColumnValue("ProductFolderName", value);
				if (_productFolder != null) {
					_productFolder.Name = value;
				}
			}
		}

		private ProductFolder _productFolder;
		/// <summary>
		/// Группа продукта.
		/// </summary>
		public ProductFolder ProductFolder {
			get {
				return _productFolder ??
					(_productFolder = LookupColumnEntities.GetEntity("ProductFolder") as ProductFolder);
			}
		}

		/// <exclude/>
		public Guid LeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeId");
			}
			set {
				SetColumnValue("LeadTypeId", value);
				_leadType = null;
			}
		}

		/// <exclude/>
		public string LeadTypeName {
			get {
				return GetTypedColumnValue<string>("LeadTypeName");
			}
			set {
				SetColumnValue("LeadTypeName", value);
				if (_leadType != null) {
					_leadType.Name = value;
				}
			}
		}

		private LeadType _leadType;
		/// <summary>
		/// Тип потребности.
		/// </summary>
		public LeadType LeadType {
			get {
				return _leadType ??
					(_leadType = LookupColumnEntities.GetEntity("LeadType") as LeadType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductInLeadType_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductInLeadTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductInLeadTypeInserting", e);
			Validating += (s, e) => ThrowEvent("ProductInLeadTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductInLeadType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductInLeadType_LeadEventsProcess

	/// <exclude/>
	public partial class ProductInLeadType_LeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ProductInLeadType
	{

		public ProductInLeadType_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductInLeadType_LeadEventsProcess";
			SchemaUId = new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("05d4a3f0-34be-4465-aa10-db18f9ec10d1");
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

	#region Class: ProductInLeadType_LeadEventsProcess

	/// <exclude/>
	public class ProductInLeadType_LeadEventsProcess : ProductInLeadType_LeadEventsProcess<ProductInLeadType>
	{

		public ProductInLeadType_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductInLeadType_LeadEventsProcess

	public partial class ProductInLeadType_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductInLeadTypeEventsProcess

	/// <exclude/>
	public class ProductInLeadTypeEventsProcess : ProductInLeadType_LeadEventsProcess
	{

		public ProductInLeadTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

