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

	#region Class: SpecificationInProductSchema

	/// <exclude/>
	public class SpecificationInProductSchema : BPMSoft.Configuration.SpecificationInObjectSchema
	{

		#region Constructors: Public

		public SpecificationInProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SpecificationInProductSchema(SpecificationInProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SpecificationInProductSchema(SpecificationInProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			RealUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			Name = "SpecificationInProduct";
			ParentSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f3edd8e0-8447-4a5a-9667-e83b42b5de3c")) == null) {
				Columns.Add(CreateProductColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateStringValueColumn() {
			EntitySchemaColumn column = base.CreateStringValueColumn();
			column.ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateIntValueColumn() {
			EntitySchemaColumn column = base.CreateIntValueColumn();
			column.ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateFloatValueColumn() {
			EntitySchemaColumn column = base.CreateFloatValueColumn();
			column.ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateBooleanValueColumn() {
			EntitySchemaColumn column = base.CreateBooleanValueColumn();
			column.ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f3edd8e0-8447-4a5a-9667-e83b42b5de3c"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509"),
				ModifiedInSchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509"),
				CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SpecificationInProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SpecificationInProduct_ProductSpecificationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SpecificationInProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SpecificationInProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509"));
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationInProduct

	/// <summary>
	/// Характеристика продукта.
	/// </summary>
	public class SpecificationInProduct : BPMSoft.Configuration.SpecificationInObject
	{

		#region Constructors: Public

		public SpecificationInProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SpecificationInProduct";
		}

		public SpecificationInProduct(SpecificationInProduct source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SpecificationInProduct_ProductSpecificationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SpecificationInProductDeleted", e);
			Inserting += (s, e) => ThrowEvent("SpecificationInProductInserting", e);
			Saving += (s, e) => ThrowEvent("SpecificationInProductSaving", e);
			Validating += (s, e) => ThrowEvent("SpecificationInProductValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SpecificationInProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationInProduct_ProductSpecificationEventsProcess

	/// <exclude/>
	public partial class SpecificationInProduct_ProductSpecificationEventsProcess<TEntity> : BPMSoft.Configuration.SpecificationInObject_SpecificationEventsProcess<TEntity> where TEntity : SpecificationInProduct
	{

		public SpecificationInProduct_ProductSpecificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SpecificationInProduct_ProductSpecificationEventsProcess";
			SchemaUId = new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5fa8a10e-372c-4d18-9709-04b9932d5509");
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

	#region Class: SpecificationInProduct_ProductSpecificationEventsProcess

	/// <exclude/>
	public class SpecificationInProduct_ProductSpecificationEventsProcess : SpecificationInProduct_ProductSpecificationEventsProcess<SpecificationInProduct>
	{

		public SpecificationInProduct_ProductSpecificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SpecificationInProduct_ProductSpecificationEventsProcess

	public partial class SpecificationInProduct_ProductSpecificationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SpecificationInProductEventsProcess

	/// <exclude/>
	public class SpecificationInProductEventsProcess : SpecificationInProduct_ProductSpecificationEventsProcess
	{

		public SpecificationInProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

