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

	#region Class: EventInFolderSchema

	/// <exclude/>
	public class EventInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public EventInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EventInFolderSchema(EventInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EventInFolderSchema(EventInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
			RealUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
			Name = "EventInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f2a44cd7-684a-4922-a769-8853fbbfc3ba")) == null) {
				Columns.Add(CreateEventColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("1a2a3673-b8a5-4a4d-b1c5-4b1b8f39eb42");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f2a44cd7-684a-4922-a769-8853fbbfc3ba"),
				Name = @"Event",
				ReferenceSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87"),
				ModifiedInSchemaUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EventInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EventInFolder_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EventInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EventInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87"));
		}

		#endregion

	}

	#endregion

	#region Class: EventInFolder

	/// <summary>
	/// Объект "Мероприятие" в группе.
	/// </summary>
	public class EventInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public EventInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EventInFolder";
		}

		public EventInFolder(EventInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EventId {
			get {
				return GetTypedColumnValue<Guid>("EventId");
			}
			set {
				SetColumnValue("EventId", value);
				_event = null;
			}
		}

		/// <exclude/>
		public string EventName {
			get {
				return GetTypedColumnValue<string>("EventName");
			}
			set {
				SetColumnValue("EventName", value);
				if (_event != null) {
					_event.Name = value;
				}
			}
		}

		private Event _event;
		/// <summary>
		/// Мероприятия.
		/// </summary>
		public Event Event {
			get {
				return _event ??
					(_event = LookupColumnEntities.GetEntity("Event") as Event);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EventInFolder_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EventInFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("EventInFolderInserting", e);
			Validating += (s, e) => ThrowEvent("EventInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EventInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: EventInFolder_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class EventInFolder_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : EventInFolder
	{

		public EventInFolder_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EventInFolder_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eba4fce1-f8b9-4ebd-a190-8aeb62fc8b87");
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

	#region Class: EventInFolder_MarketingCampaignEventsProcess

	/// <exclude/>
	public class EventInFolder_MarketingCampaignEventsProcess : EventInFolder_MarketingCampaignEventsProcess<EventInFolder>
	{

		public EventInFolder_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EventInFolder_MarketingCampaignEventsProcess

	public partial class EventInFolder_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EventInFolderEventsProcess

	/// <exclude/>
	public class EventInFolderEventsProcess : EventInFolder_MarketingCampaignEventsProcess
	{

		public EventInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

