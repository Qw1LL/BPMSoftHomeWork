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
	using BPMSoft.Core.Store;
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
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;

	#region Class: Activity_Order_BPMSoftSchema

	/// <exclude/>
	public class Activity_Order_BPMSoftSchema : BPMSoft.Configuration.Activity_CoreContracts_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_Order_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_Order_BPMSoftSchema(Activity_Order_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_Order_BPMSoftSchema(Activity_Order_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("04c57b8d-91a0-410e-9de0-9b5ef6317bbb");
			Name = "Activity_Order_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("11b832b1-75bb-4c0d-bb5d-5aa5088efe52");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e6098162-2f14-42af-833f-a83c8ce8e78c")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e6098162-2f14-42af-833f-a83c8ce8e78c"),
				Name = @"Order",
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("04c57b8d-91a0-410e-9de0-9b5ef6317bbb"),
				ModifiedInSchemaUId = new Guid("04c57b8d-91a0-410e-9de0-9b5ef6317bbb"),
				CreatedInPackageId = new Guid("11b832b1-75bb-4c0d-bb5d-5aa5088efe52")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Activity_Order_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_OrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_Order_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_Order_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("04c57b8d-91a0-410e-9de0-9b5ef6317bbb"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_Order_BPMSoft

	/// <summary>
	/// Активность.
	/// </summary>
	public class Activity_Order_BPMSoft : BPMSoft.Configuration.Activity_CoreContracts_BPMSoft
	{

		#region Constructors: Public

		public Activity_Order_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_Order_BPMSoft";
		}

		public Activity_Order_BPMSoft(Activity_Order_BPMSoft source)
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
			var process = new Activity_OrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Activity_Order_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Activity_Order_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_OrderEventsProcess

	/// <exclude/>
	public partial class Activity_OrderEventsProcess<TEntity> : BPMSoft.Configuration.Activity_CoreContractsEventsProcess<TEntity> where TEntity : Activity_Order_BPMSoft
	{

		public Activity_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_OrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("04c57b8d-91a0-410e-9de0-9b5ef6317bbb");
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

	#region Class: Activity_OrderEventsProcess

	/// <exclude/>
	public class Activity_OrderEventsProcess : Activity_OrderEventsProcess<Activity_Order_BPMSoft>
	{

		public Activity_OrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_OrderEventsProcess

	public partial class Activity_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void PrepereSynchronizeSubjectRemindingUserTask(SynchronizeSubjectRemindingUserTask userTask, Guid contact, DateTime remindTime, bool active, Guid source) {
			base.PrepereSynchronizeSubjectRemindingUserTask(userTask, contact, remindTime, active, source);
			bool isFeatureEnabled = FeatureUtilities.GetIsFeatureEnabled(UserConnection, "NotificationV2");
			if (isFeatureEnabled && active) {
				IRemindingTextFormer textFormer = ClassFactory.Get<ActivityRemindingTextFormer>(
					new ConstructorArgument("userConnection", UserConnection));
				string accountName = GetLookupDisplayColumnValue(Entity, "Account");
				string contactName = GetLookupDisplayColumnValue(Entity, "Contact");
				string title = Entity.GetTypedColumnValue<string>("Title");
				userTask.SubjectCaption = textFormer.GetBody(new Dictionary<string, object> {
					{"AccountName", accountName},
					{"ContactName", contactName},
					{"Title", title}
				});
				userTask.PopupTitle = textFormer.GetTitle(new Dictionary<string, object>());
			}
		}

		#endregion

	}

	#endregion

}

