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

	#region Class: OrderProduct_ProductCatalogueInOrder_BPMSoftSchema

	/// <exclude/>
	public class OrderProduct_ProductCatalogueInOrder_BPMSoftSchema : BPMSoft.Configuration.OrderProduct_Passport_BPMSoftSchema
	{

		#region Constructors: Public

		public OrderProduct_ProductCatalogueInOrder_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderProduct_ProductCatalogueInOrder_BPMSoftSchema(OrderProduct_ProductCatalogueInOrder_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderProduct_ProductCatalogueInOrder_BPMSoftSchema(OrderProduct_ProductCatalogueInOrder_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("6a489998-7f84-4171-815d-5894a5826838");
			Name = "OrderProduct_ProductCatalogueInOrder_BPMSoft";
			ParentSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("205fe81c-724a-4cdd-84e3-8959f298b37c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreatePriceListColumn() {
			EntitySchemaColumn column = base.CreatePriceListColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"fa689c95-c63c-4908-8fd2-19a95e0425bd"
			};
			column.ModifiedInSchemaUId = new Guid("6a489998-7f84-4171-815d-5894a5826838");
			column.CreatedInPackageId = new Guid("205fe81c-724a-4cdd-84e3-8959f298b37c");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OrderProduct_ProductCatalogueInOrder_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderProduct_ProductCatalogueInOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderProduct_ProductCatalogueInOrder_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderProduct_ProductCatalogueInOrder_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6a489998-7f84-4171-815d-5894a5826838"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderProduct_ProductCatalogueInOrder_BPMSoft

	/// <summary>
	/// Продукт в заказе.
	/// </summary>
	public class OrderProduct_ProductCatalogueInOrder_BPMSoft : BPMSoft.Configuration.OrderProduct_Passport_BPMSoft
	{

		#region Constructors: Public

		public OrderProduct_ProductCatalogueInOrder_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderProduct_ProductCatalogueInOrder_BPMSoft";
		}

		public OrderProduct_ProductCatalogueInOrder_BPMSoft(OrderProduct_ProductCatalogueInOrder_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrderProduct_ProductCatalogueInOrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("OrderProduct_ProductCatalogueInOrder_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("OrderProduct_ProductCatalogueInOrder_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrderProduct_ProductCatalogueInOrder_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderProduct_ProductCatalogueInOrderEventsProcess

	/// <exclude/>
	public partial class OrderProduct_ProductCatalogueInOrderEventsProcess<TEntity> : BPMSoft.Configuration.OrderProduct_PassportEventsProcess<TEntity> where TEntity : OrderProduct_ProductCatalogueInOrder_BPMSoft
	{

		public OrderProduct_ProductCatalogueInOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderProduct_ProductCatalogueInOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6a489998-7f84-4171-815d-5894a5826838");
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

	#region Class: OrderProduct_ProductCatalogueInOrderEventsProcess

	/// <exclude/>
	public class OrderProduct_ProductCatalogueInOrderEventsProcess : OrderProduct_ProductCatalogueInOrderEventsProcess<OrderProduct_ProductCatalogueInOrder_BPMSoft>
	{

		public OrderProduct_ProductCatalogueInOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderProduct_ProductCatalogueInOrderEventsProcess

	public partial class OrderProduct_ProductCatalogueInOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void UpdatePrimaryAmounts() {
			if (NeedRecalcPrimaryValues){
				base.UpdatePrimaryAmounts();
			}
		}

		#endregion

	}

	#endregion

}

