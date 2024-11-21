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

	#region Class: OpportunityInStageSchema

	/// <exclude/>
	public class OpportunityInStageSchema : BPMSoft.Configuration.OpportunityInStage_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OpportunityInStageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityInStageSchema(OpportunityInStageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityInStageSchema(OpportunityInStageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("49597dc2-57e5-4aa3-b164-3cf0199a281b");
			Name = "OpportunityInStage";
			ParentSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6");
			ExtendParent = true;
			CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881");
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
			return new OpportunityInStage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityInStage_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityInStageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityInStageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("49597dc2-57e5-4aa3-b164-3cf0199a281b"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityInStage

	/// <summary>
	/// Стадия в продаже.
	/// </summary>
	public class OpportunityInStage : BPMSoft.Configuration.OpportunityInStage_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OpportunityInStage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityInStage";
		}

		public OpportunityInStage(OpportunityInStage source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityInStage_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityInStageDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityInStage(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityInStage_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OpportunityInStage_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OpportunityInStage_OpportunityEventsProcess<TEntity> where TEntity : OpportunityInStage
	{

		public OpportunityInStage_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityInStage_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("49597dc2-57e5-4aa3-b164-3cf0199a281b");
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

	#region Class: OpportunityInStage_PRMPortalEventsProcess

	/// <exclude/>
	public class OpportunityInStage_PRMPortalEventsProcess : OpportunityInStage_PRMPortalEventsProcess<OpportunityInStage>
	{

		public OpportunityInStage_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityInStage_PRMPortalEventsProcess

	public partial class OpportunityInStage_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityInStageEventsProcess

	/// <exclude/>
	public class OpportunityInStageEventsProcess : OpportunityInStage_PRMPortalEventsProcess
	{

		public OpportunityInStageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

