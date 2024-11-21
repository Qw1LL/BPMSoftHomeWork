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

	#region Class: OrderDeliveryStatus_Order_BPMSoftSchema

	/// <exclude/>
	public class OrderDeliveryStatus_Order_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OrderDeliveryStatus_Order_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderDeliveryStatus_Order_BPMSoftSchema(OrderDeliveryStatus_Order_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderDeliveryStatus_Order_BPMSoftSchema(OrderDeliveryStatus_Order_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			RealUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			Name = "OrderDeliveryStatus_Order_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8d86568b-3932-4687-92fe-b637c234d390")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("8d86568b-3932-4687-92fe-b637c234d390"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09"),
				ModifiedInSchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09"),
				CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OrderDeliveryStatus_Order_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderDeliveryStatus_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderDeliveryStatus_Order_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderDeliveryStatus_Order_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderDeliveryStatus_Order_BPMSoft

	/// <summary>
	/// Состояние поставки заказа.
	/// </summary>
	public class OrderDeliveryStatus_Order_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OrderDeliveryStatus_Order_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderDeliveryStatus_Order_BPMSoft";
		}

		public OrderDeliveryStatus_Order_BPMSoft(OrderDeliveryStatus_Order_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Позиция.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrderDeliveryStatus_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OrderDeliveryStatus_Order_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("OrderDeliveryStatus_Order_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("OrderDeliveryStatus_Order_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrderDeliveryStatus_Order_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderDeliveryStatus_OrderEventsProcess

	/// <exclude/>
	public partial class OrderDeliveryStatus_OrderEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OrderDeliveryStatus_Order_BPMSoft
	{

		public OrderDeliveryStatus_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderDeliveryStatus_OrderEventsProcess";
			SchemaUId = new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("40955b77-5ef4-480c-95fb-49dfbd502c09");
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

	#region Class: OrderDeliveryStatus_OrderEventsProcess

	/// <exclude/>
	public class OrderDeliveryStatus_OrderEventsProcess : OrderDeliveryStatus_OrderEventsProcess<OrderDeliveryStatus_Order_BPMSoft>
	{

		public OrderDeliveryStatus_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderDeliveryStatus_OrderEventsProcess

	public partial class OrderDeliveryStatus_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

