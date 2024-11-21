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

	#region Class: ReasonForLeavingSchema

	/// <exclude/>
	public class ReasonForLeavingSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ReasonForLeavingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReasonForLeavingSchema(ReasonForLeavingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReasonForLeavingSchema(ReasonForLeavingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			RealUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			Name = "ReasonForLeaving";
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

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ReasonForLeaving(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReasonForLeaving_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReasonForLeavingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReasonForLeavingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79"));
		}

		#endregion

	}

	#endregion

	#region Class: ReasonForLeaving

	/// <summary>
	/// Reason for dismissal.
	/// </summary>
	public class ReasonForLeaving : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ReasonForLeaving(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReasonForLeaving";
		}

		public ReasonForLeaving(ReasonForLeaving source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReasonForLeaving_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReasonForLeavingDeleted", e);
			Deleting += (s, e) => ThrowEvent("ReasonForLeavingDeleting", e);
			Inserted += (s, e) => ThrowEvent("ReasonForLeavingInserted", e);
			Inserting += (s, e) => ThrowEvent("ReasonForLeavingInserting", e);
			Saved += (s, e) => ThrowEvent("ReasonForLeavingSaved", e);
			Saving += (s, e) => ThrowEvent("ReasonForLeavingSaving", e);
			Validating += (s, e) => ThrowEvent("ReasonForLeavingValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ReasonForLeaving(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReasonForLeaving_BaseEventsProcess

	/// <exclude/>
	public partial class ReasonForLeaving_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ReasonForLeaving
	{

		public ReasonForLeaving_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReasonForLeaving_BaseEventsProcess";
			SchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79");
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

	#region Class: ReasonForLeaving_BaseEventsProcess

	/// <exclude/>
	public class ReasonForLeaving_BaseEventsProcess : ReasonForLeaving_BaseEventsProcess<ReasonForLeaving>
	{

		public ReasonForLeaving_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReasonForLeaving_BaseEventsProcess

	public partial class ReasonForLeaving_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ReasonForLeavingEventsProcess

	/// <exclude/>
	public class ReasonForLeavingEventsProcess : ReasonForLeaving_BaseEventsProcess
	{

		public ReasonForLeavingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

