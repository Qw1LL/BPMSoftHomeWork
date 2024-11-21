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

	#region Class: ProductForecastSchema

	/// <exclude/>
	public class ProductForecastSchema : BPMSoft.Configuration.EntityInForecastCellSchema
	{

		#region Constructors: Public

		public ProductForecastSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductForecastSchema(ProductForecastSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductForecastSchema(ProductForecastSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e");
			RealUId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e");
			Name = "ProductForecast";
			ParentSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c5621d45-871a-4a56-adb8-f53023547ef7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c2d7a782-743e-4b42-a6a0-821981945cb2")) == null) {
				Columns.Add(CreateProductColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c2d7a782-743e-4b42-a6a0-821981945cb2"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e"),
				ModifiedInSchemaUId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e"),
				CreatedInPackageId = new Guid("c5621d45-871a-4a56-adb8-f53023547ef7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductForecast(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductForecast_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductForecastSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductForecastSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductForecast

	/// <summary>
	/// Планирование по продуктам.
	/// </summary>
	public class ProductForecast : BPMSoft.Configuration.EntityInForecastCell
	{

		#region Constructors: Public

		public ProductForecast(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductForecast";
		}

		public ProductForecast(ProductForecast source)
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
			var process = new ProductForecast_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("ProductForecastInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductForecast(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductForecast_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ProductForecast_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.EntityInForecastCell_CoreForecastEventsProcess<TEntity> where TEntity : ProductForecast
	{

		public ProductForecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductForecast_CoreForecastEventsProcess";
			SchemaUId = new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dc221a80-9735-4b1a-a55c-c14a5d57cf3e");
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

	#region Class: ProductForecast_CoreForecastEventsProcess

	/// <exclude/>
	public class ProductForecast_CoreForecastEventsProcess : ProductForecast_CoreForecastEventsProcess<ProductForecast>
	{

		public ProductForecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductForecast_CoreForecastEventsProcess

	public partial class ProductForecast_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductForecastEventsProcess

	/// <exclude/>
	public class ProductForecastEventsProcess : ProductForecast_CoreForecastEventsProcess
	{

		public ProductForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

