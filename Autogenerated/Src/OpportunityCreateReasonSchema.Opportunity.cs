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

	#region Class: OpportunityCreateReasonSchema

	/// <exclude/>
	public class OpportunityCreateReasonSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OpportunityCreateReasonSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityCreateReasonSchema(OpportunityCreateReasonSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityCreateReasonSchema(OpportunityCreateReasonSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("77f3becc-ab61-415a-920f-0f757c4475f7");
			RealUId = new Guid("77f3becc-ab61-415a-920f-0f757c4475f7");
			Name = "OpportunityCreateReason";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			return new OpportunityCreateReason(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityCreateReason_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityCreateReasonSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityCreateReasonSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("77f3becc-ab61-415a-920f-0f757c4475f7"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityCreateReason

	/// <summary>
	/// Причина создания продажи.
	/// </summary>
	public class OpportunityCreateReason : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OpportunityCreateReason(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityCreateReason";
		}

		public OpportunityCreateReason(OpportunityCreateReason source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityCreateReason_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityCreateReasonDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityCreateReasonDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityCreateReasonInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityCreateReasonInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityCreateReasonSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityCreateReasonSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityCreateReasonValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityCreateReason(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityCreateReason_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityCreateReason_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OpportunityCreateReason
	{

		public OpportunityCreateReason_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityCreateReason_OpportunityEventsProcess";
			SchemaUId = new Guid("77f3becc-ab61-415a-920f-0f757c4475f7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("77f3becc-ab61-415a-920f-0f757c4475f7");
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

	#region Class: OpportunityCreateReason_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityCreateReason_OpportunityEventsProcess : OpportunityCreateReason_OpportunityEventsProcess<OpportunityCreateReason>
	{

		public OpportunityCreateReason_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityCreateReason_OpportunityEventsProcess

	public partial class OpportunityCreateReason_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityCreateReasonEventsProcess

	/// <exclude/>
	public class OpportunityCreateReasonEventsProcess : OpportunityCreateReason_OpportunityEventsProcess
	{

		public OpportunityCreateReasonEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

