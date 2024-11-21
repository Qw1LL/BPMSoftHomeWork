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

	#region Class: EventTeamRolesSchema

	/// <exclude/>
	public class EventTeamRolesSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public EventTeamRolesSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EventTeamRolesSchema(EventTeamRolesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EventTeamRolesSchema(EventTeamRolesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			RealUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			Name = "EventTeamRoles";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EventTeamRoles(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EventTeamRoles_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EventTeamRolesSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EventTeamRolesSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9"));
		}

		#endregion

	}

	#endregion

	#region Class: EventTeamRoles

	/// <summary>
	/// Роль команды мероприятия.
	/// </summary>
	public class EventTeamRoles : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public EventTeamRoles(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EventTeamRoles";
		}

		public EventTeamRoles(EventTeamRoles source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EventTeamRoles_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EventTeamRolesDeleted", e);
			Inserting += (s, e) => ThrowEvent("EventTeamRolesInserting", e);
			Validating += (s, e) => ThrowEvent("EventTeamRolesValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EventTeamRoles(this);
		}

		#endregion

	}

	#endregion

	#region Class: EventTeamRoles_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class EventTeamRoles_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : EventTeamRoles
	{

		public EventTeamRoles_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EventTeamRoles_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9");
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

	#region Class: EventTeamRoles_MarketingCampaignEventsProcess

	/// <exclude/>
	public class EventTeamRoles_MarketingCampaignEventsProcess : EventTeamRoles_MarketingCampaignEventsProcess<EventTeamRoles>
	{

		public EventTeamRoles_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EventTeamRoles_MarketingCampaignEventsProcess

	public partial class EventTeamRoles_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EventTeamRolesEventsProcess

	/// <exclude/>
	public class EventTeamRolesEventsProcess : EventTeamRoles_MarketingCampaignEventsProcess
	{

		public EventTeamRolesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

