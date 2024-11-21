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

	#region Class: MktgActivityStatusSchema

	/// <exclude/>
	public class MktgActivityStatusSchema : BPMSoft.Configuration.MktgActivityStatus_CampaignPlannerNew_BPMSoftSchema
	{

		#region Constructors: Public

		public MktgActivityStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MktgActivityStatusSchema(MktgActivityStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MktgActivityStatusSchema(MktgActivityStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("c3be1646-e28f-4f4b-a777-e62fc4501d9c");
			Name = "MktgActivityStatus";
			ParentSchemaUId = new Guid("80b0b33e-3dc6-4900-b7fe-844446c56a53");
			ExtendParent = true;
			CreatedInPackageId = new Guid("be128478-78b2-4e0c-970c-9dfa8eab194e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = true;
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
			return new MktgActivityStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MktgActivityStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MktgActivityStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c3be1646-e28f-4f4b-a777-e62fc4501d9c"));
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivityStatus

	/// <summary>
	/// Состояние маркетинговой активности.
	/// </summary>
	public class MktgActivityStatus : BPMSoft.Configuration.MktgActivityStatus_CampaignPlannerNew_BPMSoft
	{

		#region Constructors: Public

		public MktgActivityStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MktgActivityStatus";
		}

		public MktgActivityStatus(MktgActivityStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MktgActivityStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("MktgActivityStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MktgActivityStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess

	/// <exclude/>
	public partial class MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess<TEntity> : BPMSoft.Configuration.MktgActivityStatus_CampaignPlannerNewEventsProcess<TEntity> where TEntity : MktgActivityStatus
	{

		public MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c3be1646-e28f-4f4b-a777-e62fc4501d9c");
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

	#region Class: MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess

	/// <exclude/>
	public class MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess : MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess<MktgActivityStatus>
	{

		public MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess

	public partial class MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MktgActivityStatusEventsProcess

	/// <exclude/>
	public class MktgActivityStatusEventsProcess : MktgActivityStatus_PRMMktgActivitiesPortalEventsProcess
	{

		public MktgActivityStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

