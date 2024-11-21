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

	#region Class: OrderFolderSchema

	/// <exclude/>
	public class OrderFolderSchema : BPMSoft.Configuration.OrderFolder_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public OrderFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderFolderSchema(OrderFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderFolderSchema(OrderFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("0d9d8b7c-3638-4afc-8318-dc08bb7db37b");
			Name = "OrderFolder";
			ParentSchemaUId = new Guid("4a8e2437-fc34-4f24-9d41-92da7c4a20ae");
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
			return new OrderFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderFolder_PRMOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0d9d8b7c-3638-4afc-8318-dc08bb7db37b"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderFolder

	/// <summary>
	/// Группа заказов.
	/// </summary>
	public class OrderFolder : BPMSoft.Configuration.OrderFolder_Order_BPMSoft
	{

		#region Constructors: Public

		public OrderFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderFolder";
		}

		public OrderFolder(OrderFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrderFolder_PRMOrderEventsProcess(UserConnection);
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
			return new OrderFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderFolder_PRMOrderEventsProcess

	/// <exclude/>
	public partial class OrderFolder_PRMOrderEventsProcess<TEntity> : BPMSoft.Configuration.OrderFolder_OrderEventsProcess<TEntity> where TEntity : OrderFolder
	{

		public OrderFolder_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderFolder_PRMOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0d9d8b7c-3638-4afc-8318-dc08bb7db37b");
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

	#region Class: OrderFolder_PRMOrderEventsProcess

	/// <exclude/>
	public class OrderFolder_PRMOrderEventsProcess : OrderFolder_PRMOrderEventsProcess<OrderFolder>
	{

		public OrderFolder_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderFolder_PRMOrderEventsProcess

	public partial class OrderFolder_PRMOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OrderFolderEventsProcess

	/// <exclude/>
	public class OrderFolderEventsProcess : OrderFolder_PRMOrderEventsProcess
	{

		public OrderFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

