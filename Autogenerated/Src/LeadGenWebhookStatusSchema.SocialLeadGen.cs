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

	#region Class: LeadGenWebhookStatusSchema

	/// <exclude/>
	public class LeadGenWebhookStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadGenWebhookStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadGenWebhookStatusSchema(LeadGenWebhookStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadGenWebhookStatusSchema(LeadGenWebhookStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1b63dd98-ab55-4b21-bd81-2419b32d2c09");
			RealUId = new Guid("1b63dd98-ab55-4b21-bd81-2419b32d2c09");
			Name = "LeadGenWebhookStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
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
			return new LeadGenWebhookStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadGenWebhookStatus_SocialLeadGenEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadGenWebhookStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadGenWebhookStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b63dd98-ab55-4b21-bd81-2419b32d2c09"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenWebhookStatus

	/// <summary>
	/// Статус создания вебхука.
	/// </summary>
	public class LeadGenWebhookStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadGenWebhookStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadGenWebhookStatus";
		}

		public LeadGenWebhookStatus(LeadGenWebhookStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadGenWebhookStatus_SocialLeadGenEventsProcess(UserConnection);
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
			return new LeadGenWebhookStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenWebhookStatus_SocialLeadGenEventsProcess

	/// <exclude/>
	public partial class LeadGenWebhookStatus_SocialLeadGenEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadGenWebhookStatus
	{

		public LeadGenWebhookStatus_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadGenWebhookStatus_SocialLeadGenEventsProcess";
			SchemaUId = new Guid("1b63dd98-ab55-4b21-bd81-2419b32d2c09");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1b63dd98-ab55-4b21-bd81-2419b32d2c09");
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

	#region Class: LeadGenWebhookStatus_SocialLeadGenEventsProcess

	/// <exclude/>
	public class LeadGenWebhookStatus_SocialLeadGenEventsProcess : LeadGenWebhookStatus_SocialLeadGenEventsProcess<LeadGenWebhookStatus>
	{

		public LeadGenWebhookStatus_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadGenWebhookStatus_SocialLeadGenEventsProcess

	public partial class LeadGenWebhookStatus_SocialLeadGenEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadGenWebhookStatusEventsProcess

	/// <exclude/>
	public class LeadGenWebhookStatusEventsProcess : LeadGenWebhookStatus_SocialLeadGenEventsProcess
	{

		public LeadGenWebhookStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

