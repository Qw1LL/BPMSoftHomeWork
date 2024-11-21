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

	#region Class: ProductEntrySchema

	/// <exclude/>
	public class ProductEntrySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProductEntrySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductEntrySchema(ProductEntrySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductEntrySchema(ProductEntrySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22");
			RealUId = new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22");
			Name = "ProductEntry";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("235a15fe-cfd4-416f-a2c6-d6eb46909686")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("c963d91f-612c-4e31-98e6-5f04da387692")) == null) {
				Columns.Add(CreateCrossSalesOferringColumn());
			}
			if (Columns.FindByUId(new Guid("558938b3-2730-49a6-9564-ff16929a8ea3")) == null) {
				Columns.Add(CreateNotesColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("235a15fe-cfd4-416f-a2c6-d6eb46909686"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22"),
				ModifiedInSchemaUId = new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCrossSalesOferringColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c963d91f-612c-4e31-98e6-5f04da387692"),
				Name = @"CrossSalesOferring",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInSchemaUId = new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22"),
				ModifiedInSchemaUId = new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("558938b3-2730-49a6-9564-ff16929a8ea3"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22"),
				ModifiedInSchemaUId = new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22"),
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
			return new ProductEntry(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductEntry_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductEntrySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductEntrySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductEntry

	/// <summary>
	/// Product inclusion.
	/// </summary>
	public class ProductEntry : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProductEntry(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductEntry";
		}

		public ProductEntry(ProductEntry source)
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

		/// <exclude/>
		public Guid CrossSalesOferringId {
			get {
				return GetTypedColumnValue<Guid>("CrossSalesOferringId");
			}
			set {
				SetColumnValue("CrossSalesOferringId", value);
				_crossSalesOferring = null;
			}
		}

		/// <exclude/>
		public string CrossSalesOferringName {
			get {
				return GetTypedColumnValue<string>("CrossSalesOferringName");
			}
			set {
				SetColumnValue("CrossSalesOferringName", value);
				if (_crossSalesOferring != null) {
					_crossSalesOferring.Name = value;
				}
			}
		}

		private Product _crossSalesOferring;
		/// <summary>
		/// Cross-sale product.
		/// </summary>
		public Product CrossSalesOferring {
			get {
				return _crossSalesOferring ??
					(_crossSalesOferring = LookupColumnEntities.GetEntity("CrossSalesOferring") as Product);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductEntry_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductEntryDeleted", e);
			Deleting += (s, e) => ThrowEvent("ProductEntryDeleting", e);
			Inserted += (s, e) => ThrowEvent("ProductEntryInserted", e);
			Inserting += (s, e) => ThrowEvent("ProductEntryInserting", e);
			Saved += (s, e) => ThrowEvent("ProductEntrySaved", e);
			Saving += (s, e) => ThrowEvent("ProductEntrySaving", e);
			Validating += (s, e) => ThrowEvent("ProductEntryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductEntry(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductEntry_BaseEventsProcess

	/// <exclude/>
	public partial class ProductEntry_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ProductEntry
	{

		public ProductEntry_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductEntry_BaseEventsProcess";
			SchemaUId = new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0e3a349c-4c69-4a8b-9eb4-1c01e758da22");
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

	#region Class: ProductEntry_BaseEventsProcess

	/// <exclude/>
	public class ProductEntry_BaseEventsProcess : ProductEntry_BaseEventsProcess<ProductEntry>
	{

		public ProductEntry_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductEntry_BaseEventsProcess

	public partial class ProductEntry_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductEntryEventsProcess

	/// <exclude/>
	public class ProductEntryEventsProcess : ProductEntry_BaseEventsProcess
	{

		public ProductEntryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

