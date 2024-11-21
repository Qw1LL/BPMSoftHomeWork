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

	#region Class: MarketingEventQueueOpSchema

	/// <exclude/>
	public class MarketingEventQueueOpSchema : BPMSoft.Configuration.MarketingEventQueueSchema
	{

		#region Constructors: Public

		public MarketingEventQueueOpSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MarketingEventQueueOpSchema(MarketingEventQueueOpSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MarketingEventQueueOpSchema(MarketingEventQueueOpSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8317ab14-3d6b-2d94-6a88-059ac4efc228");
			RealUId = new Guid("8317ab14-3d6b-2d94-6a88-059ac4efc228");
			Name = "MarketingEventQueueOp";
			ParentSchemaUId = new Guid("446a6f90-aa50-1451-56bb-23db66d83dee");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e");
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
			return new MarketingEventQueueOp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MarketingEventQueueOp_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MarketingEventQueueOpSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MarketingEventQueueOpSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8317ab14-3d6b-2d94-6a88-059ac4efc228"));
		}

		#endregion

	}

	#endregion

	#region Class: MarketingEventQueueOp

	/// <summary>
	/// Очередь заданий для маркетинговых мероприятий (операционная).
	/// </summary>
	public class MarketingEventQueueOp : BPMSoft.Configuration.MarketingEventQueue
	{

		#region Constructors: Public

		public MarketingEventQueueOp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MarketingEventQueueOp";
		}

		public MarketingEventQueueOp(MarketingEventQueueOp source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MarketingEventQueueOp_MarketingCampaignEventsProcess(UserConnection);
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
			return new MarketingEventQueueOp(this);
		}

		#endregion

	}

	#endregion

	#region Class: MarketingEventQueueOp_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class MarketingEventQueueOp_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.MarketingEventQueue_MarketingCampaignEventsProcess<TEntity> where TEntity : MarketingEventQueueOp
	{

		public MarketingEventQueueOp_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MarketingEventQueueOp_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("8317ab14-3d6b-2d94-6a88-059ac4efc228");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8317ab14-3d6b-2d94-6a88-059ac4efc228");
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

	#region Class: MarketingEventQueueOp_MarketingCampaignEventsProcess

	/// <exclude/>
	public class MarketingEventQueueOp_MarketingCampaignEventsProcess : MarketingEventQueueOp_MarketingCampaignEventsProcess<MarketingEventQueueOp>
	{

		public MarketingEventQueueOp_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MarketingEventQueueOp_MarketingCampaignEventsProcess

	public partial class MarketingEventQueueOp_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MarketingEventQueueOpEventsProcess

	/// <exclude/>
	public class MarketingEventQueueOpEventsProcess : MarketingEventQueueOp_MarketingCampaignEventsProcess
	{

		public MarketingEventQueueOpEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

