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

	#region Class: OpportunityParticipantRoleSchema

	/// <exclude/>
	public class OpportunityParticipantRoleSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OpportunityParticipantRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityParticipantRoleSchema(OpportunityParticipantRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityParticipantRoleSchema(OpportunityParticipantRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c98f005b-faa4-4279-818c-54c72ad9c161");
			RealUId = new Guid("c98f005b-faa4-4279-818c-54c72ad9c161");
			Name = "OpportunityParticipantRole";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			DesignLocalizationSchemaName = @"SysOpportunityParticipRoleLcz";
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
			return new OpportunityParticipantRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityParticipantRole_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityParticipantRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityParticipantRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c98f005b-faa4-4279-818c-54c72ad9c161"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityParticipantRole

	/// <summary>
	/// Роль участника продажи.
	/// </summary>
	public class OpportunityParticipantRole : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OpportunityParticipantRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityParticipantRole";
		}

		public OpportunityParticipantRole(OpportunityParticipantRole source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityParticipantRole_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityParticipantRoleDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityParticipantRoleDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityParticipantRoleInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityParticipantRoleInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityParticipantRoleSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityParticipantRoleSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityParticipantRoleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityParticipantRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityParticipantRole_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityParticipantRole_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OpportunityParticipantRole
	{

		public OpportunityParticipantRole_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityParticipantRole_OpportunityEventsProcess";
			SchemaUId = new Guid("c98f005b-faa4-4279-818c-54c72ad9c161");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c98f005b-faa4-4279-818c-54c72ad9c161");
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

	#region Class: OpportunityParticipantRole_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityParticipantRole_OpportunityEventsProcess : OpportunityParticipantRole_OpportunityEventsProcess<OpportunityParticipantRole>
	{

		public OpportunityParticipantRole_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityParticipantRole_OpportunityEventsProcess

	public partial class OpportunityParticipantRole_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityParticipantRoleEventsProcess

	/// <exclude/>
	public class OpportunityParticipantRoleEventsProcess : OpportunityParticipantRole_OpportunityEventsProcess
	{

		public OpportunityParticipantRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

