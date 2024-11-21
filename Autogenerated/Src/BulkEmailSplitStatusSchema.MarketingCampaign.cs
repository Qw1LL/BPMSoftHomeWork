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

	#region Class: BulkEmailSplitStatusSchema

	/// <exclude/>
	public class BulkEmailSplitStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public BulkEmailSplitStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailSplitStatusSchema(BulkEmailSplitStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailSplitStatusSchema(BulkEmailSplitStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f91bf1c9-a18d-4446-9a5d-ed7e90d37d98");
			RealUId = new Guid("f91bf1c9-a18d-4446-9a5d-ed7e90d37d98");
			Name = "BulkEmailSplitStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855");
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
			return new BulkEmailSplitStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailSplitStatus_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailSplitStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailSplitStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f91bf1c9-a18d-4446-9a5d-ed7e90d37d98"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSplitStatus

	/// <summary>
	/// Состояние сплит-теста.
	/// </summary>
	public class BulkEmailSplitStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public BulkEmailSplitStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailSplitStatus";
		}

		public BulkEmailSplitStatus(BulkEmailSplitStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailSplitStatus_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailSplitStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("BulkEmailSplitStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailSplitStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSplitStatus_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailSplitStatus_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : BulkEmailSplitStatus
	{

		public BulkEmailSplitStatus_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailSplitStatus_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("f91bf1c9-a18d-4446-9a5d-ed7e90d37d98");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f91bf1c9-a18d-4446-9a5d-ed7e90d37d98");
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

	#region Class: BulkEmailSplitStatus_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailSplitStatus_MarketingCampaignEventsProcess : BulkEmailSplitStatus_MarketingCampaignEventsProcess<BulkEmailSplitStatus>
	{

		public BulkEmailSplitStatus_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailSplitStatus_MarketingCampaignEventsProcess

	public partial class BulkEmailSplitStatus_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailSplitStatusEventsProcess

	/// <exclude/>
	public class BulkEmailSplitStatusEventsProcess : BulkEmailSplitStatus_MarketingCampaignEventsProcess
	{

		public BulkEmailSplitStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

