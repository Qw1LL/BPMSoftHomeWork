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

	#region Class: EventSegmentSchema

	/// <exclude/>
	public class EventSegmentSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EventSegmentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EventSegmentSchema(EventSegmentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EventSegmentSchema(EventSegmentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7");
			RealUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7");
			Name = "EventSegment";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("db695356-ecb7-4fbc-be38-e04511c2dd6b")) == null) {
				Columns.Add(CreateSegmentColumn());
			}
			if (Columns.FindByUId(new Guid("7857b851-2447-4040-b970-b5dee4bbeacf")) == null) {
				Columns.Add(CreateEventColumn());
			}
			if (Columns.FindByUId(new Guid("ecb2ec76-6ca6-413b-92c7-86898d163379")) == null) {
				Columns.Add(CreateStateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7");
			column.CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7");
			column.CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7");
			column.CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7");
			column.CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7");
			column.CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7");
			column.CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSegmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("db695356-ecb7-4fbc-be38-e04511c2dd6b"),
				Name = @"Segment",
				ReferenceSchemaUId = new Guid("8b5c01a2-59e9-40dc-855b-6e3bebddc6ee"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7"),
				ModifiedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7"),
				CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b")
			};
		}

		protected virtual EntitySchemaColumn CreateEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7857b851-2447-4040-b970-b5dee4bbeacf"),
				Name = @"Event",
				ReferenceSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7"),
				ModifiedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7"),
				CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ecb2ec76-6ca6-413b-92c7-86898d163379"),
				Name = @"State",
				ReferenceSchemaUId = new Guid("80ea7f5b-3991-42c6-bc29-f101d9757c70"),
				IsValueCloneable = false,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7"),
				ModifiedInSchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7"),
				CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EventSegment(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EventSegment_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EventSegmentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EventSegmentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d0796434-2b4d-423c-85bd-ec51928533b7"));
		}

		#endregion

	}

	#endregion

	#region Class: EventSegment

	/// <summary>
	/// Сегменты мероприятия.
	/// </summary>
	public class EventSegment : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EventSegment(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EventSegment";
		}

		public EventSegment(EventSegment source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SegmentId {
			get {
				return GetTypedColumnValue<Guid>("SegmentId");
			}
			set {
				SetColumnValue("SegmentId", value);
				_segment = null;
			}
		}

		/// <exclude/>
		public string SegmentName {
			get {
				return GetTypedColumnValue<string>("SegmentName");
			}
			set {
				SetColumnValue("SegmentName", value);
				if (_segment != null) {
					_segment.Name = value;
				}
			}
		}

		private ContactFolder _segment;
		/// <summary>
		/// Сегмент.
		/// </summary>
		public ContactFolder Segment {
			get {
				return _segment ??
					(_segment = LookupColumnEntities.GetEntity("Segment") as ContactFolder);
			}
		}

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
		/// Мероприятие.
		/// </summary>
		public Event Event {
			get {
				return _event ??
					(_event = LookupColumnEntities.GetEntity("Event") as Event);
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private SegmentStatus _state;
		/// <summary>
		/// Состояние.
		/// </summary>
		public SegmentStatus State {
			get {
				return _state ??
					(_state = LookupColumnEntities.GetEntity("State") as SegmentStatus);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EventSegment_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EventSegmentDeleted", e);
			Inserting += (s, e) => ThrowEvent("EventSegmentInserting", e);
			Validating += (s, e) => ThrowEvent("EventSegmentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EventSegment(this);
		}

		#endregion

	}

	#endregion

	#region Class: EventSegment_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class EventSegment_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EventSegment
	{

		public EventSegment_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EventSegment_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("d0796434-2b4d-423c-85bd-ec51928533b7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d0796434-2b4d-423c-85bd-ec51928533b7");
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

	#region Class: EventSegment_MarketingCampaignEventsProcess

	/// <exclude/>
	public class EventSegment_MarketingCampaignEventsProcess : EventSegment_MarketingCampaignEventsProcess<EventSegment>
	{

		public EventSegment_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EventSegment_MarketingCampaignEventsProcess

	public partial class EventSegment_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EventSegmentEventsProcess

	/// <exclude/>
	public class EventSegmentEventsProcess : EventSegment_MarketingCampaignEventsProcess
	{

		public EventSegmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

