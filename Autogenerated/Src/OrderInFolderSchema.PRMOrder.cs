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

	#region Class: OrderInFolderSchema

	/// <exclude/>
	public class OrderInFolderSchema : BPMSoft.Configuration.OrderInFolder_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public OrderInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderInFolderSchema(OrderInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderInFolderSchema(OrderInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("6e065842-95cc-4a79-a8c8-da5be6c75c59");
			Name = "OrderInFolder";
			ParentSchemaUId = new Guid("58ae4081-3f5b-4485-b4a7-824c0e0ba618");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c09bcc89-cd4a-49df-a8fa-3a15879bc3c5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OrderInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderInFolder_PRMOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6e065842-95cc-4a79-a8c8-da5be6c75c59"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderInFolder

	/// <summary>
	/// Заказ в группе.
	/// </summary>
	public class OrderInFolder : BPMSoft.Configuration.OrderInFolder_Order_BPMSoft
	{

		#region Constructors: Public

		public OrderInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderInFolder";
		}

		public OrderInFolder(OrderInFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrderInFolder_PRMOrderEventsProcess(UserConnection);
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
			return new OrderInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderInFolder_PRMOrderEventsProcess

	/// <exclude/>
	public partial class OrderInFolder_PRMOrderEventsProcess<TEntity> : BPMSoft.Configuration.OrderInFolder_OrderEventsProcess<TEntity> where TEntity : OrderInFolder
	{

		public OrderInFolder_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderInFolder_PRMOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6e065842-95cc-4a79-a8c8-da5be6c75c59");
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

	#region Class: OrderInFolder_PRMOrderEventsProcess

	/// <exclude/>
	public class OrderInFolder_PRMOrderEventsProcess : OrderInFolder_PRMOrderEventsProcess<OrderInFolder>
	{

		public OrderInFolder_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderInFolder_PRMOrderEventsProcess

	public partial class OrderInFolder_PRMOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OrderInFolderEventsProcess

	/// <exclude/>
	public class OrderInFolderEventsProcess : OrderInFolder_PRMOrderEventsProcess
	{

		public OrderInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

