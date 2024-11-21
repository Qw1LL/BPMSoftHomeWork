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

	#region Class: ProductType_ProductBase_BPMSoftSchema

	/// <exclude/>
	public class ProductType_ProductBase_BPMSoftSchema : BPMSoft.Configuration.ProductType_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public ProductType_ProductBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductType_ProductBase_BPMSoftSchema(ProductType_ProductBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductType_ProductBase_BPMSoftSchema(ProductType_ProductBase_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("384855d1-4565-44d2-94f0-c0af49aaa33f");
			Name = "ProductType_ProductBase_BPMSoft";
			ParentSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c1015b29-fbac-474a-91b4-541120d8a031");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIsServiceColumn() {
			EntitySchemaColumn column = base.CreateIsServiceColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("384855d1-4565-44d2-94f0-c0af49aaa33f");
			column.CreatedInPackageId = new Guid("c1015b29-fbac-474a-91b4-541120d8a031");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductType_ProductBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductType_ProductBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductType_ProductBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductType_ProductBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("384855d1-4565-44d2-94f0-c0af49aaa33f"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductType_ProductBase_BPMSoft

	/// <summary>
	/// Тип продукта.
	/// </summary>
	public class ProductType_ProductBase_BPMSoft : BPMSoft.Configuration.ProductType_Base_BPMSoft
	{

		#region Constructors: Public

		public ProductType_ProductBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductType_ProductBase_BPMSoft";
		}

		public ProductType_ProductBase_BPMSoft(ProductType_ProductBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProductType_ProductBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductType_ProductBase_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProductType_ProductBase_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("ProductType_ProductBase_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductType_ProductBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductType_ProductBaseEventsProcess

	/// <exclude/>
	public partial class ProductType_ProductBaseEventsProcess<TEntity> : BPMSoft.Configuration.ProductType_BaseEventsProcess<TEntity> where TEntity : ProductType_ProductBase_BPMSoft
	{

		public ProductType_ProductBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductType_ProductBaseEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("384855d1-4565-44d2-94f0-c0af49aaa33f");
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

	#region Class: ProductType_ProductBaseEventsProcess

	/// <exclude/>
	public class ProductType_ProductBaseEventsProcess : ProductType_ProductBaseEventsProcess<ProductType_ProductBase_BPMSoft>
	{

		public ProductType_ProductBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductType_ProductBaseEventsProcess

	public partial class ProductType_ProductBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

