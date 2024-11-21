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

	#region Class: OpportunityInFolderSchema

	/// <exclude/>
	public class OpportunityInFolderSchema : BPMSoft.Configuration.OpportunityInFolder_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OpportunityInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityInFolderSchema(OpportunityInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityInFolderSchema(OpportunityInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ae428608-eaa7-44a7-9764-0243d6b4b1ff");
			Name = "OpportunityInFolder";
			ParentSchemaUId = new Guid("57e5c814-e83b-4e79-a18c-adaa69a39970");
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
			return new OpportunityInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityInFolder_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ae428608-eaa7-44a7-9764-0243d6b4b1ff"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityInFolder

	/// <summary>
	/// Продажа в группе.
	/// </summary>
	public class OpportunityInFolder : BPMSoft.Configuration.OpportunityInFolder_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OpportunityInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityInFolder";
		}

		public OpportunityInFolder(OpportunityInFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityInFolder_PRMPortalEventsProcess(UserConnection);
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
			return new OpportunityInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityInFolder_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OpportunityInFolder_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OpportunityInFolder_OpportunityEventsProcess<TEntity> where TEntity : OpportunityInFolder
	{

		public OpportunityInFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityInFolder_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ae428608-eaa7-44a7-9764-0243d6b4b1ff");
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

	#region Class: OpportunityInFolder_PRMPortalEventsProcess

	/// <exclude/>
	public class OpportunityInFolder_PRMPortalEventsProcess : OpportunityInFolder_PRMPortalEventsProcess<OpportunityInFolder>
	{

		public OpportunityInFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityInFolder_PRMPortalEventsProcess

	public partial class OpportunityInFolder_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityInFolderEventsProcess

	/// <exclude/>
	public class OpportunityInFolderEventsProcess : OpportunityInFolder_PRMPortalEventsProcess
	{

		public OpportunityInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

