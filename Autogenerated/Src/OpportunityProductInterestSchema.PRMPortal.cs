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

	#region Class: OpportunityProductInterestSchema

	/// <exclude/>
	public class OpportunityProductInterestSchema : BPMSoft.Configuration.OpportunityProductInterest_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OpportunityProductInterestSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityProductInterestSchema(OpportunityProductInterestSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityProductInterestSchema(OpportunityProductInterestSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("42f95095-ad31-454b-8245-f14f5cf521c7");
			Name = "OpportunityProductInterest";
			ParentSchemaUId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860");
			ExtendParent = true;
			CreatedInPackageId = new Guid("580620fc-064a-4cdc-95d9-80175a4d3b0d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateOpportunityColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
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
			return new OpportunityProductInterest(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityProductInterest_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityProductInterestSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityProductInterestSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("42f95095-ad31-454b-8245-f14f5cf521c7"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityProductInterest

	/// <summary>
	/// Продукт в продаже.
	/// </summary>
	public class OpportunityProductInterest : BPMSoft.Configuration.OpportunityProductInterest_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OpportunityProductInterest(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityProductInterest";
		}

		public OpportunityProductInterest(OpportunityProductInterest source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityProductInterest_PRMPortalEventsProcess(UserConnection);
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
			return new OpportunityProductInterest(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityProductInterest_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OpportunityProductInterest_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OpportunityProductInterest_OpportunityEventsProcess<TEntity> where TEntity : OpportunityProductInterest
	{

		public OpportunityProductInterest_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityProductInterest_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("42f95095-ad31-454b-8245-f14f5cf521c7");
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

	#region Class: OpportunityProductInterest_PRMPortalEventsProcess

	/// <exclude/>
	public class OpportunityProductInterest_PRMPortalEventsProcess : OpportunityProductInterest_PRMPortalEventsProcess<OpportunityProductInterest>
	{

		public OpportunityProductInterest_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityProductInterest_PRMPortalEventsProcess

	public partial class OpportunityProductInterest_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityProductInterestEventsProcess

	/// <exclude/>
	public class OpportunityProductInterestEventsProcess : OpportunityProductInterest_PRMPortalEventsProcess
	{

		public OpportunityProductInterestEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

