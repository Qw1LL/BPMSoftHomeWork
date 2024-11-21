namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: OrderFile_Order_BPMSoftSchema

	/// <exclude/>
	public class OrderFile_Order_BPMSoftSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public OrderFile_Order_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderFile_Order_BPMSoftSchema(OrderFile_Order_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderFile_Order_BPMSoftSchema(OrderFile_Order_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			RealUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			Name = "OrderFile_Order_BPMSoft";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("601bc0b9-c981-405b-ab34-64bd83fe670f")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedByColumn() {
			EntitySchemaColumn column = base.CreateLockedByColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedOnColumn() {
			EntitySchemaColumn column = base.CreateLockedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateDataColumn() {
			EntitySchemaColumn column = base.CreateDataColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateVersionColumn() {
			EntitySchemaColumn column = base.CreateVersionColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected override EntitySchemaColumn CreateSizeColumn() {
			EntitySchemaColumn column = base.CreateSizeColumn();
			column.ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			column.CreatedInPackageId = new Guid("125f8fc5-5cbf-4395-9865-451eb0929445");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("601bc0b9-c981-405b-ab34-64bd83fe670f"),
				Name = @"Order",
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44"),
				ModifiedInSchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44"),
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
			return new OrderFile_Order_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderFile_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderFile_Order_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderFile_Order_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderFile_Order_BPMSoft

	/// <summary>
	/// Файлы заказа.
	/// </summary>
	public class OrderFile_Order_BPMSoft : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public OrderFile_Order_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderFile_Order_BPMSoft";
		}

		public OrderFile_Order_BPMSoft(OrderFile_Order_BPMSoft source)
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
			var process = new OrderFile_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OrderFile_Order_BPMSoftDeleted", e);
			Updated += (s, e) => ThrowEvent("OrderFile_Order_BPMSoftUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrderFile_Order_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderFile_OrderEventsProcess

	/// <exclude/>
	public partial class OrderFile_OrderEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : OrderFile_Order_BPMSoft
	{

		public OrderFile_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderFile_OrderEventsProcess";
			SchemaUId = new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d75d815b-0b2e-4e33-973a-ed9a43601b44");
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

	#region Class: OrderFile_OrderEventsProcess

	/// <exclude/>
	public class OrderFile_OrderEventsProcess : OrderFile_OrderEventsProcess<OrderFile_Order_BPMSoft>
	{

		public OrderFile_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderFile_OrderEventsProcess

	public partial class OrderFile_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void OnFileSaved() {
			base.OnFileSaved();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId) {
				var url = Entity.GetTypedColumnValue<string>("Name").Trim();
				if (IsURLValid(url)) {
					LinkPreview linkPreview = new LinkPreview();
					LinkPreviewInfo linkPreviewInfo = linkPreview.GetWebPageLinkPreview(url);
					if (linkPreviewInfo != null) {
						LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
						linkPreviewProvider.SaveLinkPreviewInfo(linkPreviewInfo, Entity.PrimaryColumnValue);
					}
				}
			}
		}

		public override void OnFileDeleted() {
			base.OnFileDeleted();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		public override void OnFileUpdated() {
			base.OnFileUpdated();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			string oldUrl = (string)Entity.GetColumnOldValue("Name");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId && IsURLValid(oldUrl)) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		#endregion

	}

	#endregion

}

