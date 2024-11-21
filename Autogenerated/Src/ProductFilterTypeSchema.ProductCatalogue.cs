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

	#region Class: ProductFilterTypeSchema

	/// <exclude/>
	public class ProductFilterTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ProductFilterTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductFilterTypeSchema(ProductFilterTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductFilterTypeSchema(ProductFilterTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			RealUId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			Name = "ProductFilterType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			column.CreatedInPackageId = new Guid("e502d56a-e797-4315-8a0b-0fab9b8f01ab");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductFilterType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductFilterType_ProductCatalogueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductFilterTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductFilterTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductFilterType

	/// <summary>
	/// Тип фильтра продуктов.
	/// </summary>
	public class ProductFilterType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ProductFilterType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductFilterType";
		}

		public ProductFilterType(ProductFilterType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductFilterType_ProductCatalogueEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductFilterTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductFilterTypeInserting", e);
			Validating += (s, e) => ThrowEvent("ProductFilterTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductFilterType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductFilterType_ProductCatalogueEventsProcess

	/// <exclude/>
	public partial class ProductFilterType_ProductCatalogueEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ProductFilterType
	{

		public ProductFilterType_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductFilterType_ProductCatalogueEventsProcess";
			SchemaUId = new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("54ab3775-a12e-418d-a6ad-9365d00a53a9");
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

	#region Class: ProductFilterType_ProductCatalogueEventsProcess

	/// <exclude/>
	public class ProductFilterType_ProductCatalogueEventsProcess : ProductFilterType_ProductCatalogueEventsProcess<ProductFilterType>
	{

		public ProductFilterType_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductFilterType_ProductCatalogueEventsProcess

	public partial class ProductFilterType_ProductCatalogueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductFilterTypeEventsProcess

	/// <exclude/>
	public class ProductFilterTypeEventsProcess : ProductFilterType_ProductCatalogueEventsProcess
	{

		public ProductFilterTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

