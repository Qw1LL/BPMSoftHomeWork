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

	#region Class: LeadDisqualifyReasonSchema

	/// <exclude/>
	public class LeadDisqualifyReasonSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadDisqualifyReasonSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadDisqualifyReasonSchema(LeadDisqualifyReasonSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadDisqualifyReasonSchema(LeadDisqualifyReasonSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			RealUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			Name = "LeadDisqualifyReason";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadDisqualifyReason(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadDisqualifyReason_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadDisqualifyReasonSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadDisqualifyReasonSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("086904b2-10a7-4156-bb21-c23a98228ace"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadDisqualifyReason

	/// <summary>
	/// Причины дисквалификации.
	/// </summary>
	public class LeadDisqualifyReason : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadDisqualifyReason(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadDisqualifyReason";
		}

		public LeadDisqualifyReason(LeadDisqualifyReason source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadDisqualifyReason_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadDisqualifyReasonDeleted", e);
			Inserting += (s, e) => ThrowEvent("LeadDisqualifyReasonInserting", e);
			Validating += (s, e) => ThrowEvent("LeadDisqualifyReasonValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadDisqualifyReason(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadDisqualifyReason_LeadEventsProcess

	/// <exclude/>
	public partial class LeadDisqualifyReason_LeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadDisqualifyReason
	{

		public LeadDisqualifyReason_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadDisqualifyReason_LeadEventsProcess";
			SchemaUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("086904b2-10a7-4156-bb21-c23a98228ace");
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

	#region Class: LeadDisqualifyReason_LeadEventsProcess

	/// <exclude/>
	public class LeadDisqualifyReason_LeadEventsProcess : LeadDisqualifyReason_LeadEventsProcess<LeadDisqualifyReason>
	{

		public LeadDisqualifyReason_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadDisqualifyReason_LeadEventsProcess

	public partial class LeadDisqualifyReason_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadDisqualifyReasonEventsProcess

	/// <exclude/>
	public class LeadDisqualifyReasonEventsProcess : LeadDisqualifyReason_LeadEventsProcess
	{

		public LeadDisqualifyReasonEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

