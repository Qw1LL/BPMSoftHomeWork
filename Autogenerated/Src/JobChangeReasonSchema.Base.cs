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

	#region Class: JobChangeReasonSchema

	/// <exclude/>
	public class JobChangeReasonSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public JobChangeReasonSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public JobChangeReasonSchema(JobChangeReasonSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public JobChangeReasonSchema(JobChangeReasonSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("91d12da5-4a3b-4a57-ac8c-17abda1d115e");
			RealUId = new Guid("91d12da5-4a3b-4a57-ac8c-17abda1d115e");
			Name = "JobChangeReason";
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
			return new JobChangeReason(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new JobChangeReason_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new JobChangeReasonSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new JobChangeReasonSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("91d12da5-4a3b-4a57-ac8c-17abda1d115e"));
		}

		#endregion

	}

	#endregion

	#region Class: JobChangeReason

	/// <summary>
	/// Reason for Job Change.
	/// </summary>
	public class JobChangeReason : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public JobChangeReason(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "JobChangeReason";
		}

		public JobChangeReason(JobChangeReason source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new JobChangeReason_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("JobChangeReasonDeleted", e);
			Deleting += (s, e) => ThrowEvent("JobChangeReasonDeleting", e);
			Inserted += (s, e) => ThrowEvent("JobChangeReasonInserted", e);
			Inserting += (s, e) => ThrowEvent("JobChangeReasonInserting", e);
			Saved += (s, e) => ThrowEvent("JobChangeReasonSaved", e);
			Saving += (s, e) => ThrowEvent("JobChangeReasonSaving", e);
			Validating += (s, e) => ThrowEvent("JobChangeReasonValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new JobChangeReason(this);
		}

		#endregion

	}

	#endregion

	#region Class: JobChangeReason_BaseEventsProcess

	/// <exclude/>
	public partial class JobChangeReason_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : JobChangeReason
	{

		public JobChangeReason_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "JobChangeReason_BaseEventsProcess";
			SchemaUId = new Guid("91d12da5-4a3b-4a57-ac8c-17abda1d115e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("91d12da5-4a3b-4a57-ac8c-17abda1d115e");
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

	#region Class: JobChangeReason_BaseEventsProcess

	/// <exclude/>
	public class JobChangeReason_BaseEventsProcess : JobChangeReason_BaseEventsProcess<JobChangeReason>
	{

		public JobChangeReason_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: JobChangeReason_BaseEventsProcess

	public partial class JobChangeReason_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: JobChangeReasonEventsProcess

	/// <exclude/>
	public class JobChangeReasonEventsProcess : JobChangeReason_BaseEventsProcess
	{

		public JobChangeReasonEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

