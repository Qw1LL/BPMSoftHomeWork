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

	#region Class: BulkEmailQueueOpSchema

	/// <exclude/>
	public class BulkEmailQueueOpSchema : BPMSoft.Configuration.BulkEmailQueueSchema
	{

		#region Constructors: Public

		public BulkEmailQueueOpSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailQueueOpSchema(BulkEmailQueueOpSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailQueueOpSchema(BulkEmailQueueOpSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1dda178-78c0-4f78-80a1-a3ea8a1967b6");
			RealUId = new Guid("a1dda178-78c0-4f78-80a1-a3ea8a1967b6");
			Name = "BulkEmailQueueOp";
			ParentSchemaUId = new Guid("7b585999-843e-4553-8674-74bba330a056");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f24dc5fa-2f9b-4ab1-9633-a911cdb81e3b");
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
			return new BulkEmailQueueOp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailQueueOp_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailQueueOpSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailQueueOpSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1dda178-78c0-4f78-80a1-a3ea8a1967b6"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailQueueOp

	/// <summary>
	/// BulkEmailQueueOp.
	/// </summary>
	public class BulkEmailQueueOp : BPMSoft.Configuration.BulkEmailQueue
	{

		#region Constructors: Public

		public BulkEmailQueueOp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailQueueOp";
		}

		public BulkEmailQueueOp(BulkEmailQueueOp source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailQueueOp_MarketingCampaignEventsProcess(UserConnection);
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
			return new BulkEmailQueueOp(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailQueueOp_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailQueueOp_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BulkEmailQueue_MarketingCampaignEventsProcess<TEntity> where TEntity : BulkEmailQueueOp
	{

		public BulkEmailQueueOp_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailQueueOp_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("a1dda178-78c0-4f78-80a1-a3ea8a1967b6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a1dda178-78c0-4f78-80a1-a3ea8a1967b6");
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

	#region Class: BulkEmailQueueOp_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailQueueOp_MarketingCampaignEventsProcess : BulkEmailQueueOp_MarketingCampaignEventsProcess<BulkEmailQueueOp>
	{

		public BulkEmailQueueOp_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailQueueOp_MarketingCampaignEventsProcess

	public partial class BulkEmailQueueOp_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailQueueOpEventsProcess

	/// <exclude/>
	public class BulkEmailQueueOpEventsProcess : BulkEmailQueueOp_MarketingCampaignEventsProcess
	{

		public BulkEmailQueueOpEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

