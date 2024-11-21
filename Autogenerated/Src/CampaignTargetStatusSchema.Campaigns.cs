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

	#region Class: CampaignTargetStatusSchema

	/// <exclude/>
	public class CampaignTargetStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CampaignTargetStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignTargetStatusSchema(CampaignTargetStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignTargetStatusSchema(CampaignTargetStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4632eea4-8425-48a6-a698-c5088b2884f1");
			RealUId = new Guid("4632eea4-8425-48a6-a698-c5088b2884f1");
			Name = "CampaignTargetStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("781fc653-c4cb-4c1b-b941-83a6b0fc8787");
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
			return new CampaignTargetStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignTargetStatus_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignTargetStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignTargetStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4632eea4-8425-48a6-a698-c5088b2884f1"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignTargetStatus

	/// <summary>
	/// Статус участника компании.
	/// </summary>
	public class CampaignTargetStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CampaignTargetStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignTargetStatus";
		}

		public CampaignTargetStatus(CampaignTargetStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignTargetStatus_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignTargetStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignTargetStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignTargetStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignTargetStatus_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignTargetStatus_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : CampaignTargetStatus
	{

		public CampaignTargetStatus_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignTargetStatus_CampaignsEventsProcess";
			SchemaUId = new Guid("4632eea4-8425-48a6-a698-c5088b2884f1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4632eea4-8425-48a6-a698-c5088b2884f1");
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

	#region Class: CampaignTargetStatus_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignTargetStatus_CampaignsEventsProcess : CampaignTargetStatus_CampaignsEventsProcess<CampaignTargetStatus>
	{

		public CampaignTargetStatus_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignTargetStatus_CampaignsEventsProcess

	public partial class CampaignTargetStatus_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignTargetStatusEventsProcess

	/// <exclude/>
	public class CampaignTargetStatusEventsProcess : CampaignTargetStatus_CampaignsEventsProcess
	{

		public CampaignTargetStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

