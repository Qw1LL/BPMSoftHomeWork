namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: VwProcessDashboardSchema

	/// <exclude/>
	public class VwProcessDashboardSchema : BPMSoft.Configuration.VwProcessDashboard_ActionsDashboard_BPMSoftSchema
	{

		#region Constructors: Public

		public VwProcessDashboardSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProcessDashboardSchema(VwProcessDashboardSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProcessDashboardSchema(VwProcessDashboardSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("6061fc3f-7a19-4f8f-b847-eb9e4c15d999");
			Name = "VwProcessDashboard";
			ParentSchemaUId = new Guid("ef3a3dcb-5f88-4af4-9894-1e36c4876085");
			ExtendParent = true;
			CreatedInPackageId = new Guid("6e774b28-4cf2-458d-872b-08ef49cd87a7");
			IsDBView = true;
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
			return new VwProcessDashboard(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProcessDashboard_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProcessDashboardSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProcessDashboardSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6061fc3f-7a19-4f8f-b847-eb9e4c15d999"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessDashboard

	/// <summary>
	/// The process dashboard.
	/// </summary>
	public class VwProcessDashboard : BPMSoft.Configuration.VwProcessDashboard_ActionsDashboard_BPMSoft
	{

		#region Constructors: Public

		public VwProcessDashboard(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProcessDashboard";
		}

		public VwProcessDashboard(VwProcessDashboard source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProcessDashboard_SSPEventsProcess(UserConnection);
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
			return new VwProcessDashboard(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessDashboard_SSPEventsProcess

	/// <exclude/>
	public partial class VwProcessDashboard_SSPEventsProcess<TEntity> : BPMSoft.Configuration.VwProcessDashboard_ActionsDashboardEventsProcess<TEntity> where TEntity : VwProcessDashboard
	{

		public VwProcessDashboard_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProcessDashboard_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6061fc3f-7a19-4f8f-b847-eb9e4c15d999");
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

	#region Class: VwProcessDashboard_SSPEventsProcess

	/// <exclude/>
	public class VwProcessDashboard_SSPEventsProcess : VwProcessDashboard_SSPEventsProcess<VwProcessDashboard>
	{

		public VwProcessDashboard_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProcessDashboard_SSPEventsProcess

	public partial class VwProcessDashboard_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwProcessDashboardEventsProcess

	/// <exclude/>
	public class VwProcessDashboardEventsProcess : VwProcessDashboard_SSPEventsProcess
	{

		public VwProcessDashboardEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

