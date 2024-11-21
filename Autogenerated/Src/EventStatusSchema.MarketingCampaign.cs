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

	#region Class: EventStatusSchema

	/// <exclude/>
	public class EventStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public EventStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EventStatusSchema(EventStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EventStatusSchema(EventStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
			RealUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
			Name = "EventStatus";
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
			column.ModifiedInSchemaUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
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
			return new EventStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EventStatus_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EventStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EventStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b52918af-f05e-4251-985a-7877360e1e02"));
		}

		#endregion

	}

	#endregion

	#region Class: EventStatus

	/// <summary>
	/// Состояние мероприятия.
	/// </summary>
	public class EventStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public EventStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EventStatus";
		}

		public EventStatus(EventStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EventStatus_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EventStatusDeleted", e);
			Inserting += (s, e) => ThrowEvent("EventStatusInserting", e);
			Validating += (s, e) => ThrowEvent("EventStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EventStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: EventStatus_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class EventStatus_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : EventStatus
	{

		public EventStatus_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EventStatus_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b52918af-f05e-4251-985a-7877360e1e02");
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

	#region Class: EventStatus_MarketingCampaignEventsProcess

	/// <exclude/>
	public class EventStatus_MarketingCampaignEventsProcess : EventStatus_MarketingCampaignEventsProcess<EventStatus>
	{

		public EventStatus_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EventStatus_MarketingCampaignEventsProcess

	public partial class EventStatus_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EventStatusEventsProcess

	/// <exclude/>
	public class EventStatusEventsProcess : EventStatus_MarketingCampaignEventsProcess
	{

		public EventStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

