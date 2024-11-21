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

	#region Class: LeadInQualifyStatusSchema

	/// <exclude/>
	public class LeadInQualifyStatusSchema : BPMSoft.Configuration.LeadInQualifyStatus_Lead_BPMSoftSchema
	{

		#region Constructors: Public

		public LeadInQualifyStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadInQualifyStatusSchema(LeadInQualifyStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadInQualifyStatusSchema(LeadInQualifyStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("d04ad5a7-3d2d-4109-a27a-0f04fc6b14f9");
			Name = "LeadInQualifyStatus";
			ParentSchemaUId = new Guid("071aba13-b2b4-4050-aa8f-dab49a65b4b1");
			ExtendParent = true;
			CreatedInPackageId = new Guid("580620fc-064a-4cdc-95d9-80175a4d3b0d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateLeadColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
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
			return new LeadInQualifyStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadInQualifyStatus_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadInQualifyStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadInQualifyStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d04ad5a7-3d2d-4109-a27a-0f04fc6b14f9"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadInQualifyStatus

	/// <summary>
	/// Стадия в лиде.
	/// </summary>
	public class LeadInQualifyStatus : BPMSoft.Configuration.LeadInQualifyStatus_Lead_BPMSoft
	{

		#region Constructors: Public

		public LeadInQualifyStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadInQualifyStatus";
		}

		public LeadInQualifyStatus(LeadInQualifyStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadInQualifyStatus_PRMPortalEventsProcess(UserConnection);
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
			return new LeadInQualifyStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadInQualifyStatus_PRMPortalEventsProcess

	/// <exclude/>
	public partial class LeadInQualifyStatus_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.LeadInQualifyStatus_LeadEventsProcess<TEntity> where TEntity : LeadInQualifyStatus
	{

		public LeadInQualifyStatus_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadInQualifyStatus_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d04ad5a7-3d2d-4109-a27a-0f04fc6b14f9");
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

	#region Class: LeadInQualifyStatus_PRMPortalEventsProcess

	/// <exclude/>
	public class LeadInQualifyStatus_PRMPortalEventsProcess : LeadInQualifyStatus_PRMPortalEventsProcess<LeadInQualifyStatus>
	{

		public LeadInQualifyStatus_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadInQualifyStatus_PRMPortalEventsProcess

	public partial class LeadInQualifyStatus_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadInQualifyStatusEventsProcess

	/// <exclude/>
	public class LeadInQualifyStatusEventsProcess : LeadInQualifyStatus_PRMPortalEventsProcess
	{

		public LeadInQualifyStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

