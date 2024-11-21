namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: OpportunityFileSchema

	/// <exclude/>
	public class OpportunityFileSchema : BPMSoft.Configuration.OpportunityFile_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OpportunityFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityFileSchema(OpportunityFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityFileSchema(OpportunityFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("157c5671-438d-4b50-833a-03b5a777dbbb");
			Name = "OpportunityFile";
			ParentSchemaUId = new Guid("4135a9ba-5936-438f-9795-40fbc090c07b");
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
			return new OpportunityFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityFile_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("157c5671-438d-4b50-833a-03b5a777dbbb"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityFile

	/// <summary>
	/// Файл и ссылка продажи.
	/// </summary>
	public class OpportunityFile : BPMSoft.Configuration.OpportunityFile_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OpportunityFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityFile";
		}

		public OpportunityFile(OpportunityFile source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityFile_PRMPortalEventsProcess(UserConnection);
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
			return new OpportunityFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityFile_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OpportunityFile_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OpportunityFile_OpportunityEventsProcess<TEntity> where TEntity : OpportunityFile
	{

		public OpportunityFile_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityFile_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("157c5671-438d-4b50-833a-03b5a777dbbb");
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

	#region Class: OpportunityFile_PRMPortalEventsProcess

	/// <exclude/>
	public class OpportunityFile_PRMPortalEventsProcess : OpportunityFile_PRMPortalEventsProcess<OpportunityFile>
	{

		public OpportunityFile_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityFile_PRMPortalEventsProcess

	public partial class OpportunityFile_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityFileEventsProcess

	/// <exclude/>
	public class OpportunityFileEventsProcess : OpportunityFile_PRMPortalEventsProcess
	{

		public OpportunityFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

