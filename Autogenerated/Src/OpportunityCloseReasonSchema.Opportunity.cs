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

	#region Class: OpportunityCloseReasonSchema

	/// <exclude/>
	public class OpportunityCloseReasonSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OpportunityCloseReasonSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityCloseReasonSchema(OpportunityCloseReasonSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityCloseReasonSchema(OpportunityCloseReasonSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27ba43e5-6280-4458-855d-3c7118f678d7");
			RealUId = new Guid("27ba43e5-6280-4458-855d-3c7118f678d7");
			Name = "OpportunityCloseReason";
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
			return new OpportunityCloseReason(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityCloseReason_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityCloseReasonSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityCloseReasonSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27ba43e5-6280-4458-855d-3c7118f678d7"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityCloseReason

	/// <summary>
	/// Причина закрытия продажи.
	/// </summary>
	public class OpportunityCloseReason : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OpportunityCloseReason(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityCloseReason";
		}

		public OpportunityCloseReason(OpportunityCloseReason source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityCloseReason_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityCloseReasonDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityCloseReasonDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityCloseReasonInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityCloseReasonInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityCloseReasonSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityCloseReasonSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityCloseReasonValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityCloseReason(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityCloseReason_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityCloseReason_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OpportunityCloseReason
	{

		public OpportunityCloseReason_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityCloseReason_OpportunityEventsProcess";
			SchemaUId = new Guid("27ba43e5-6280-4458-855d-3c7118f678d7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("27ba43e5-6280-4458-855d-3c7118f678d7");
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

	#region Class: OpportunityCloseReason_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityCloseReason_OpportunityEventsProcess : OpportunityCloseReason_OpportunityEventsProcess<OpportunityCloseReason>
	{

		public OpportunityCloseReason_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityCloseReason_OpportunityEventsProcess

	public partial class OpportunityCloseReason_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityCloseReasonEventsProcess

	/// <exclude/>
	public class OpportunityCloseReasonEventsProcess : OpportunityCloseReason_OpportunityEventsProcess
	{

		public OpportunityCloseReasonEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

