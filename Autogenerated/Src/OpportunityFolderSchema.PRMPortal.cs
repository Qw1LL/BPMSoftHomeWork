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

	#region Class: OpportunityFolderSchema

	/// <exclude/>
	public class OpportunityFolderSchema : BPMSoft.Configuration.OpportunityFolder_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OpportunityFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityFolderSchema(OpportunityFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityFolderSchema(OpportunityFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("7f6fd4fe-d696-4ead-ad89-397c2afbf3c5");
			Name = "OpportunityFolder";
			ParentSchemaUId = new Guid("ba431b60-ce67-4198-9281-6571b6920f70");
			ExtendParent = true;
			CreatedInPackageId = new Guid("580620fc-064a-4cdc-95d9-80175a4d3b0d");
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
			return new OpportunityFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityFolder_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7f6fd4fe-d696-4ead-ad89-397c2afbf3c5"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityFolder

	/// <summary>
	/// Группа продажи.
	/// </summary>
	public class OpportunityFolder : BPMSoft.Configuration.OpportunityFolder_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OpportunityFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityFolder";
		}

		public OpportunityFolder(OpportunityFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityFolder_PRMPortalEventsProcess(UserConnection);
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
			return new OpportunityFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityFolder_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OpportunityFolder_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OpportunityFolder_OpportunityEventsProcess<TEntity> where TEntity : OpportunityFolder
	{

		public OpportunityFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityFolder_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7f6fd4fe-d696-4ead-ad89-397c2afbf3c5");
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

	#region Class: OpportunityFolder_PRMPortalEventsProcess

	/// <exclude/>
	public class OpportunityFolder_PRMPortalEventsProcess : OpportunityFolder_PRMPortalEventsProcess<OpportunityFolder>
	{

		public OpportunityFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityFolder_PRMPortalEventsProcess

	public partial class OpportunityFolder_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityFolderEventsProcess

	/// <exclude/>
	public class OpportunityFolderEventsProcess : OpportunityFolder_PRMPortalEventsProcess
	{

		public OpportunityFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

