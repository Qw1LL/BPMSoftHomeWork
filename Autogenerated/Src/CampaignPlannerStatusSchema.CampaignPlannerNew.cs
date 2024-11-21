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

	#region Class: CampaignPlannerStatusSchema

	/// <exclude/>
	public class CampaignPlannerStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CampaignPlannerStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignPlannerStatusSchema(CampaignPlannerStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignPlannerStatusSchema(CampaignPlannerStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("60706b93-af92-4107-9718-01488109709e");
			RealUId = new Guid("60706b93-af92-4107-9718-01488109709e");
			Name = "CampaignPlannerStatus";
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
			return new CampaignPlannerStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignPlannerStatus_CampaignPlannerNewEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignPlannerStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignPlannerStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("60706b93-af92-4107-9718-01488109709e"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerStatus

	/// <summary>
	/// Состояние маркетингового плана.
	/// </summary>
	public class CampaignPlannerStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CampaignPlannerStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignPlannerStatus";
		}

		public CampaignPlannerStatus(CampaignPlannerStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignPlannerStatus_CampaignPlannerNewEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignPlannerStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignPlannerStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignPlannerStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerStatus_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public partial class CampaignPlannerStatus_CampaignPlannerNewEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : CampaignPlannerStatus
	{

		public CampaignPlannerStatus_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignPlannerStatus_CampaignPlannerNewEventsProcess";
			SchemaUId = new Guid("60706b93-af92-4107-9718-01488109709e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("60706b93-af92-4107-9718-01488109709e");
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

	#region Class: CampaignPlannerStatus_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public class CampaignPlannerStatus_CampaignPlannerNewEventsProcess : CampaignPlannerStatus_CampaignPlannerNewEventsProcess<CampaignPlannerStatus>
	{

		public CampaignPlannerStatus_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignPlannerStatus_CampaignPlannerNewEventsProcess

	public partial class CampaignPlannerStatus_CampaignPlannerNewEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignPlannerStatusEventsProcess

	/// <exclude/>
	public class CampaignPlannerStatusEventsProcess : CampaignPlannerStatus_CampaignPlannerNewEventsProcess
	{

		public CampaignPlannerStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

