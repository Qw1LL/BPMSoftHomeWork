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

	#region Class: OpportunityCompetitorSchema

	/// <exclude/>
	public class OpportunityCompetitorSchema : BPMSoft.Configuration.OpportunityCompetitor_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OpportunityCompetitorSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityCompetitorSchema(OpportunityCompetitorSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityCompetitorSchema(OpportunityCompetitorSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("57cd8c4e-0640-4c02-adb2-5bc2ee563150");
			Name = "OpportunityCompetitor";
			ParentSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b");
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
			return new OpportunityCompetitor(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityCompetitor_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityCompetitorSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityCompetitorSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("57cd8c4e-0640-4c02-adb2-5bc2ee563150"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityCompetitor

	/// <summary>
	/// Конкурент в продаже.
	/// </summary>
	public class OpportunityCompetitor : BPMSoft.Configuration.OpportunityCompetitor_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OpportunityCompetitor(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityCompetitor";
		}

		public OpportunityCompetitor(OpportunityCompetitor source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityCompetitor_PRMPortalEventsProcess(UserConnection);
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
			return new OpportunityCompetitor(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityCompetitor_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OpportunityCompetitor_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OpportunityCompetitor_OpportunityEventsProcess<TEntity> where TEntity : OpportunityCompetitor
	{

		public OpportunityCompetitor_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityCompetitor_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("57cd8c4e-0640-4c02-adb2-5bc2ee563150");
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

	#region Class: OpportunityCompetitor_PRMPortalEventsProcess

	/// <exclude/>
	public class OpportunityCompetitor_PRMPortalEventsProcess : OpportunityCompetitor_PRMPortalEventsProcess<OpportunityCompetitor>
	{

		public OpportunityCompetitor_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityCompetitor_PRMPortalEventsProcess

	public partial class OpportunityCompetitor_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityCompetitorEventsProcess

	/// <exclude/>
	public class OpportunityCompetitorEventsProcess : OpportunityCompetitor_PRMPortalEventsProcess
	{

		public OpportunityCompetitorEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

