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

	#region Class: OrderInTag_Order_BPMSoftSchema

	/// <exclude/>
	public class OrderInTag_Order_BPMSoftSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public OrderInTag_Order_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderInTag_Order_BPMSoftSchema(OrderInTag_Order_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderInTag_Order_BPMSoftSchema(OrderInTag_Order_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f4330954-fa69-408f-a489-ef87b1daf153");
			RealUId = new Guid("f4330954-fa69-408f-a489-ef87b1daf153");
			Name = "OrderInTag_Order_BPMSoft";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("765c4500-20c0-452a-9b54-ab5cbb32cf28");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("f4330954-fa69-408f-a489-ef87b1daf153");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityNumber";
			column.ModifiedInSchemaUId = new Guid("f4330954-fa69-408f-a489-ef87b1daf153");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OrderInTag_Order_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderInTag_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderInTag_Order_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderInTag_Order_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f4330954-fa69-408f-a489-ef87b1daf153"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderInTag_Order_BPMSoft

	/// <summary>
	/// Тег в записи раздела заказы.
	/// </summary>
	public class OrderInTag_Order_BPMSoft : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public OrderInTag_Order_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderInTag_Order_BPMSoft";
		}

		public OrderInTag_Order_BPMSoft(OrderInTag_Order_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrderInTag_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrderInTag_Order_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderInTag_OrderEventsProcess

	/// <exclude/>
	public partial class OrderInTag_OrderEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : OrderInTag_Order_BPMSoft
	{

		public OrderInTag_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderInTag_OrderEventsProcess";
			SchemaUId = new Guid("f4330954-fa69-408f-a489-ef87b1daf153");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f4330954-fa69-408f-a489-ef87b1daf153");
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

	#region Class: OrderInTag_OrderEventsProcess

	/// <exclude/>
	public class OrderInTag_OrderEventsProcess : OrderInTag_OrderEventsProcess<OrderInTag_Order_BPMSoft>
	{

		public OrderInTag_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderInTag_OrderEventsProcess

	public partial class OrderInTag_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

