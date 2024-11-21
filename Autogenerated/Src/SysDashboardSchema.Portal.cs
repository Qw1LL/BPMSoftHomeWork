namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: SysDashboardSchema

	/// <exclude/>
	public class SysDashboardSchema : BPMSoft.Configuration.SysDashboard_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysDashboardSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDashboardSchema(SysDashboardSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDashboardSchema(SysDashboardSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ad003e99-19b5-40e2-b1d8-9be2776b065f");
			Name = "SysDashboard";
			ParentSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
			ExtendParent = true;
			CreatedInPackageId = new Guid("24171d81-8069-411d-ae5c-6792ab7f6776");
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
			return new SysDashboard(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDashboard_PortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDashboardSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDashboardSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ad003e99-19b5-40e2-b1d8-9be2776b065f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDashboard

	/// <summary>
	/// Итог.
	/// </summary>
	public class SysDashboard : BPMSoft.Configuration.SysDashboard_Base_BPMSoft
	{

		#region Constructors: Public

		public SysDashboard(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDashboard";
		}

		public SysDashboard(SysDashboard source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDashboard_PortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysDashboardDeleted", e);
			Validating += (s, e) => ThrowEvent("SysDashboardValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysDashboard(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDashboard_PortalEventsProcess

	/// <exclude/>
	public partial class SysDashboard_PortalEventsProcess<TEntity> : BPMSoft.Configuration.SysDashboard_BaseEventsProcess<TEntity> where TEntity : SysDashboard
	{

		public SysDashboard_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDashboard_PortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ad003e99-19b5-40e2-b1d8-9be2776b065f");
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

	#region Class: SysDashboard_PortalEventsProcess

	/// <exclude/>
	public class SysDashboard_PortalEventsProcess : SysDashboard_PortalEventsProcess<SysDashboard>
	{

		public SysDashboard_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDashboard_PortalEventsProcess

	public partial class SysDashboard_PortalEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: SysDashboardEventsProcess

	/// <exclude/>
	public class SysDashboardEventsProcess : SysDashboard_PortalEventsProcess
	{

		public SysDashboardEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

