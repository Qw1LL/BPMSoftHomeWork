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

	#region Class: VwQueueItemSchema

	/// <exclude/>
	public class VwQueueItemSchema : BPMSoft.Configuration.VwQueueItem_ServiceDefSettings_BPMSoftSchema
	{

		#region Constructors: Public

		public VwQueueItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwQueueItemSchema(VwQueueItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwQueueItemSchema(VwQueueItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIQueueItemEntityRecordIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("c4cef279-2524-4af8-b82f-fc6d4c4ef131");
			index.Name = "IQueueItemEntityRecordId";
			index.CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7");
			EntitySchemaIndexColumn entityRecordIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2bdc98e1-62f3-48a6-9fc0-74cce71d2f69"),
				ColumnUId = new Guid("c4b1d2f2-528c-4e66-9440-67125f0707dd"),
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityRecordIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIQueueItemSysProcessDataIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("17149bf5-6c6c-411a-adbd-6e507c3dcf05");
			index.Name = "IQueueItemSysProcessDataId";
			index.CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7");
			EntitySchemaIndexColumn sysProcessDataIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ed385332-3853-404c-aaeb-879761c31bae"),
				ColumnUId = new Guid("96eca8e1-84f2-4c9d-8b05-8c0d852211bf"),
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysProcessDataIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("e52c206f-46bc-42b1-a595-886f32325d10");
			Name = "VwQueueItem";
			ParentSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569");
			ExtendParent = true;
			CreatedInPackageId = new Guid("7f3e86e8-9e6f-45ec-ad31-b62ba1e77772");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b847392f-153d-466c-ac87-86b2126ebfc3")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b847392f-153d-466c-ac87-86b2126ebfc3"),
				Name = @"Order",
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e52c206f-46bc-42b1-a595-886f32325d10"),
				ModifiedInSchemaUId = new Guid("e52c206f-46bc-42b1-a595-886f32325d10"),
				CreatedInPackageId = new Guid("7f3e86e8-9e6f-45ec-ad31-b62ba1e77772")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIQueueItemEntityRecordIdIndex());
			Indexes.Add(CreateIQueueItemSysProcessDataIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwQueueItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwQueueItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwQueueItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e52c206f-46bc-42b1-a595-886f32325d10"));
		}

		#endregion

	}

	#endregion

	#region Class: VwQueueItem

	/// <summary>
	/// Элемент очереди единого окна (представление).
	/// </summary>
	public class VwQueueItem : BPMSoft.Configuration.VwQueueItem_ServiceDefSettings_BPMSoft
	{

		#region Constructors: Public

		public VwQueueItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwQueueItem";
		}

		public VwQueueItem(VwQueueItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OrderId {
			get {
				return GetTypedColumnValue<Guid>("OrderId");
			}
			set {
				SetColumnValue("OrderId", value);
				_order = null;
			}
		}

		/// <exclude/>
		public string OrderNumber {
			get {
				return GetTypedColumnValue<string>("OrderNumber");
			}
			set {
				SetColumnValue("OrderNumber", value);
				if (_order != null) {
					_order.Number = value;
				}
			}
		}

		private Order _order;
		/// <summary>
		/// Заказ.
		/// </summary>
		public Order Order {
			get {
				return _order ??
					(_order = LookupColumnEntities.GetEntity("Order") as Order);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwQueueItemDeleted", e);
			Validating += (s, e) => ThrowEvent("VwQueueItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwQueueItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.VwQueueItem_ServiceDefSettingsEventsProcess<TEntity> where TEntity : VwQueueItem
	{

		public VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e52c206f-46bc-42b1-a595-886f32325d10");
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

	#region Class: VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess : VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess<VwQueueItem>
	{

		public VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess

	public partial class VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: VwQueueItemEventsProcess

	/// <exclude/>
	public class VwQueueItemEventsProcess : VwQueueItem_OrderInSales_OperatorSingleWindowEventsProcess
	{

		public VwQueueItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

