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

	#region Class: Document_DocumentInOrder_BPMSoftSchema

	/// <exclude/>
	public class Document_DocumentInOrder_BPMSoftSchema : BPMSoft.Configuration.Document_DocumentInOpportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public Document_DocumentInOrder_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Document_DocumentInOrder_BPMSoftSchema(Document_DocumentInOrder_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Document_DocumentInOrder_BPMSoftSchema(Document_DocumentInOrder_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("e80415d7-73fb-43c9-bd98-0ba9c0fc62be");
			Name = "Document_DocumentInOrder_BPMSoft";
			ParentSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			ExtendParent = true;
			CreatedInPackageId = new Guid("5d9b28ba-4fc6-47b4-a9dc-af73da976584");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("722a29cd-767f-419a-8208-ab455f88217d")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("722a29cd-767f-419a-8208-ab455f88217d"),
				Name = @"Order",
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e80415d7-73fb-43c9-bd98-0ba9c0fc62be"),
				ModifiedInSchemaUId = new Guid("e80415d7-73fb-43c9-bd98-0ba9c0fc62be"),
				CreatedInPackageId = new Guid("5d9b28ba-4fc6-47b4-a9dc-af73da976584")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Document_DocumentInOrder_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Document_DocumentInOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Document_DocumentInOrder_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Document_DocumentInOrder_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e80415d7-73fb-43c9-bd98-0ba9c0fc62be"));
		}

		#endregion

	}

	#endregion

	#region Class: Document_DocumentInOrder_BPMSoft

	/// <summary>
	/// Документ.
	/// </summary>
	public class Document_DocumentInOrder_BPMSoft : BPMSoft.Configuration.Document_DocumentInOpportunity_BPMSoft
	{

		#region Constructors: Public

		public Document_DocumentInOrder_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Document_DocumentInOrder_BPMSoft";
		}

		public Document_DocumentInOrder_BPMSoft(Document_DocumentInOrder_BPMSoft source)
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
			var process = new Document_DocumentInOrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Document_DocumentInOrder_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("Document_DocumentInOrder_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Document_DocumentInOrder_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Document_DocumentInOrderEventsProcess

	/// <exclude/>
	public partial class Document_DocumentInOrderEventsProcess<TEntity> : BPMSoft.Configuration.Document_DocumentInOpportunityEventsProcess<TEntity> where TEntity : Document_DocumentInOrder_BPMSoft
	{

		public Document_DocumentInOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Document_DocumentInOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e80415d7-73fb-43c9-bd98-0ba9c0fc62be");
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

	#region Class: Document_DocumentInOrderEventsProcess

	/// <exclude/>
	public class Document_DocumentInOrderEventsProcess : Document_DocumentInOrderEventsProcess<Document_DocumentInOrder_BPMSoft>
	{

		public Document_DocumentInOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Document_DocumentInOrderEventsProcess

	public partial class Document_DocumentInOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

