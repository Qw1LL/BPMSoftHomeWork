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

	#region Class: RoleInServiceTeamSchema

	/// <exclude/>
	public class RoleInServiceTeamSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public RoleInServiceTeamSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RoleInServiceTeamSchema(RoleInServiceTeamSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RoleInServiceTeamSchema(RoleInServiceTeamSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			RealUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			Name = "RoleInServiceTeam";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RoleInServiceTeam(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RoleInServiceTeam_SLMITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RoleInServiceTeamSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RoleInServiceTeamSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14"));
		}

		#endregion

	}

	#endregion

	#region Class: RoleInServiceTeam

	/// <summary>
	/// Роль в команде обслуживания.
	/// </summary>
	public class RoleInServiceTeam : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public RoleInServiceTeam(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RoleInServiceTeam";
		}

		public RoleInServiceTeam(RoleInServiceTeam source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RoleInServiceTeam_SLMITILServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("RoleInServiceTeamDeleted", e);
			Validating += (s, e) => ThrowEvent("RoleInServiceTeamValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new RoleInServiceTeam(this);
		}

		#endregion

	}

	#endregion

	#region Class: RoleInServiceTeam_SLMITILServiceEventsProcess

	/// <exclude/>
	public partial class RoleInServiceTeam_SLMITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : RoleInServiceTeam
	{

		public RoleInServiceTeam_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RoleInServiceTeam_SLMITILServiceEventsProcess";
			SchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14");
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

	#region Class: RoleInServiceTeam_SLMITILServiceEventsProcess

	/// <exclude/>
	public class RoleInServiceTeam_SLMITILServiceEventsProcess : RoleInServiceTeam_SLMITILServiceEventsProcess<RoleInServiceTeam>
	{

		public RoleInServiceTeam_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RoleInServiceTeam_SLMITILServiceEventsProcess

	public partial class RoleInServiceTeam_SLMITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: RoleInServiceTeamEventsProcess

	/// <exclude/>
	public class RoleInServiceTeamEventsProcess : RoleInServiceTeam_SLMITILServiceEventsProcess
	{

		public RoleInServiceTeamEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

