namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.MarketingCampaign;
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

	#region Class: EventTargetSchema

	/// <exclude/>
	public class EventTargetSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EventTargetSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EventTargetSchema(EventTargetSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EventTargetSchema(EventTargetSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87");
			RealUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87");
			Name = "EventTarget";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNoteColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6eaac54f-9bf3-470c-8bf5-4478a07094a8")) == null) {
				Columns.Add(CreateEventColumn());
			}
			if (Columns.FindByUId(new Guid("b352323b-76f5-4633-b11b-378d66ed9282")) == null) {
				Columns.Add(CreateEventResponseColumn());
			}
			if (Columns.FindByUId(new Guid("7aedd8e6-8654-474d-9da8-21f92dc045f9")) == null) {
				Columns.Add(CreateIsFromGroupColumn());
			}
			if (Columns.FindByUId(new Guid("3e2f761d-432c-43fc-ae14-386b07f004a7")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("1a79fbd7-10b2-4e29-bb1f-c4b3aec9e534")) == null) {
				Columns.Add(CreateGeneratedWebFormColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6eaac54f-9bf3-470c-8bf5-4478a07094a8"),
				Name = @"Event",
				ReferenceSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateEventResponseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b352323b-76f5-4633-b11b-378d66ed9282"),
				Name = @"EventResponse",
				ReferenceSchemaUId = new Guid("07c07e96-3347-4788-91bd-36935aeada6c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"c6eae023-2778-49c6-8273-6b015c1cc611"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNoteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c1ab957f-49de-47bc-9df2-2b52e71fde23"),
				Name = @"Note",
				CreatedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateIsFromGroupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7aedd8e6-8654-474d-9da8-21f92dc045f9"),
				Name = @"IsFromGroup",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3e2f761d-432c-43fc-ae14-386b07f004a7"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				CreatedInPackageId = new Guid("f34f31e2-7f75-40a5-8a68-3d9273ea8cb6")
			};
		}

		protected virtual EntitySchemaColumn CreateGeneratedWebFormColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1a79fbd7-10b2-4e29-bb1f-c4b3aec9e534"),
				Name = @"GeneratedWebForm",
				ReferenceSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				IsValueCloneable = false,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				ModifiedInSchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"),
				CreatedInPackageId = new Guid("d29e8339-d159-492c-b850-b36f13c6eff8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EventTarget(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EventTarget_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EventTargetSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EventTargetSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87"));
		}

		#endregion

	}

	#endregion

	#region Class: EventTarget

	/// <summary>
	/// Участник мероприятия.
	/// </summary>
	public class EventTarget : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EventTarget(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EventTarget";
		}

		public EventTarget(EventTarget source)
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
		/// Мероприятие.
		/// </summary>
		public Event Event {
			get {
				return _event ??
					(_event = LookupColumnEntities.GetEntity("Event") as Event);
			}
		}

		/// <exclude/>
		public Guid EventResponseId {
			get {
				return GetTypedColumnValue<Guid>("EventResponseId");
			}
			set {
				SetColumnValue("EventResponseId", value);
				_eventResponse = null;
			}
		}

		/// <exclude/>
		public string EventResponseName {
			get {
				return GetTypedColumnValue<string>("EventResponseName");
			}
			set {
				SetColumnValue("EventResponseName", value);
				if (_eventResponse != null) {
					_eventResponse.Name = value;
				}
			}
		}

		private EventResponse _eventResponse;
		/// <summary>
		/// Отклик.
		/// </summary>
		public EventResponse EventResponse {
			get {
				return _eventResponse ??
					(_eventResponse = LookupColumnEntities.GetEntity("EventResponse") as EventResponse);
			}
		}

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Note {
			get {
				return GetTypedColumnValue<string>("Note");
			}
			set {
				SetColumnValue("Note", value);
			}
		}

		/// <summary>
		/// IsFromGroup.
		/// </summary>
		public bool IsFromGroup {
			get {
				return GetTypedColumnValue<bool>("IsFromGroup");
			}
			set {
				SetColumnValue("IsFromGroup", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid GeneratedWebFormId {
			get {
				return GetTypedColumnValue<Guid>("GeneratedWebFormId");
			}
			set {
				SetColumnValue("GeneratedWebFormId", value);
				_generatedWebForm = null;
			}
		}

		/// <exclude/>
		public string GeneratedWebFormName {
			get {
				return GetTypedColumnValue<string>("GeneratedWebFormName");
			}
			set {
				SetColumnValue("GeneratedWebFormName", value);
				if (_generatedWebForm != null) {
					_generatedWebForm.Name = value;
				}
			}
		}

		private GeneratedWebForm _generatedWebForm;
		/// <summary>
		/// GeneratedWebForm.
		/// </summary>
		public GeneratedWebForm GeneratedWebForm {
			get {
				return _generatedWebForm ??
					(_generatedWebForm = LookupColumnEntities.GetEntity("GeneratedWebForm") as GeneratedWebForm);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EventTarget_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EventTargetDeleted", e);
			Inserted += (s, e) => ThrowEvent("EventTargetInserted", e);
			Inserting += (s, e) => ThrowEvent("EventTargetInserting", e);
			Validating += (s, e) => ThrowEvent("EventTargetValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EventTarget(this);
		}

		#endregion

	}

	#endregion

	#region Class: EventTarget_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class EventTarget_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EventTarget
	{

		public EventTarget_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EventTarget_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fb50e79e-ede8-4714-b6c8-c7cf4d3a9f87");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventTargetInsertedEventSubProcess;
		public ProcessFlowElement EventTargetInsertedEventSubProcess {
			get {
				return _eventTargetInsertedEventSubProcess ?? (_eventTargetInsertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventTargetInsertedEventSubProcess",
					SchemaElementUId = new Guid("6a1f2c07-dfd2-4c74-a39b-d8b35fe96deb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _eventTargetInsertedMessage;
		public ProcessFlowElement EventTargetInsertedMessage {
			get {
				return _eventTargetInsertedMessage ?? (_eventTargetInsertedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EventTargetInsertedMessage",
					SchemaElementUId = new Guid("ec94274a-f9d2-4fe3-9753-0421a296381d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _eventTargetInsertedScriptTask;
		public ProcessScriptTask EventTargetInsertedScriptTask {
			get {
				return _eventTargetInsertedScriptTask ?? (_eventTargetInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "EventTargetInsertedScriptTask",
					SchemaElementUId = new Guid("42b83b69-f0ce-4434-949f-fb19470017dd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = EventTargetInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventTargetDeletedEventSubProcess;
		public ProcessFlowElement EventTargetDeletedEventSubProcess {
			get {
				return _eventTargetDeletedEventSubProcess ?? (_eventTargetDeletedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventTargetDeletedEventSubProcess",
					SchemaElementUId = new Guid("f93145e4-0b2f-4a91-a6f5-b46b056565b2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _eventTargetDeletedMessage;
		public ProcessFlowElement EventTargetDeletedMessage {
			get {
				return _eventTargetDeletedMessage ?? (_eventTargetDeletedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EventTargetDeletedMessage",
					SchemaElementUId = new Guid("7dca9a7d-f485-4a16-9c0e-24383b35bd95"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _eventTargetDeletedScriptTask;
		public ProcessScriptTask EventTargetDeletedScriptTask {
			get {
				return _eventTargetDeletedScriptTask ?? (_eventTargetDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "EventTargetDeletedScriptTask",
					SchemaElementUId = new Guid("eb76c1ea-cf36-424a-8ce5-a78ea0658fd3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = EventTargetDeletedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3_480f29c3b9b14d548f9e17acbe56366c;
		public ProcessFlowElement EventSubProcess3_480f29c3b9b14d548f9e17acbe56366c {
			get {
				return _eventSubProcess3_480f29c3b9b14d548f9e17acbe56366c ?? (_eventSubProcess3_480f29c3b9b14d548f9e17acbe56366c = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_480f29c3b9b14d548f9e17acbe56366c",
					SchemaElementUId = new Guid("480f29c3-b9b1-4d54-8f9e-17acbe56366c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_4beebb560e174209a9ddd22032cf9520;
		public ProcessFlowElement StartMessage3_4beebb560e174209a9ddd22032cf9520 {
			get {
				return _startMessage3_4beebb560e174209a9ddd22032cf9520 ?? (_startMessage3_4beebb560e174209a9ddd22032cf9520 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_4beebb560e174209a9ddd22032cf9520",
					SchemaElementUId = new Guid("4beebb56-0e17-4209-a9dd-d22032cf9520"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_dc8bd2905b244667b64d9b6d0f99bda3;
		public ProcessScriptTask ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3 {
			get {
				return _scriptTask3_dc8bd2905b244667b64d9b6d0f99bda3 ?? (_scriptTask3_dc8bd2905b244667b64d9b6d0f99bda3 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3",
					SchemaElementUId = new Guid("dc8bd290-5b24-4667-b64d-9b6d0f99bda3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3Execute,
				});
			}
		}

		private LocalizableString _uniqueConstraintMessageText;
		public LocalizableString UniqueConstraintMessageText {
			get {
				return _uniqueConstraintMessageText ?? (_uniqueConstraintMessageText = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.UniqueConstraintMessageText.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventTargetInsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EventTargetInsertedEventSubProcess };
			FlowElements[EventTargetInsertedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EventTargetInsertedMessage };
			FlowElements[EventTargetInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EventTargetInsertedScriptTask };
			FlowElements[EventTargetDeletedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EventTargetDeletedEventSubProcess };
			FlowElements[EventTargetDeletedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EventTargetDeletedMessage };
			FlowElements[EventTargetDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EventTargetDeletedScriptTask };
			FlowElements[EventSubProcess3_480f29c3b9b14d548f9e17acbe56366c.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_480f29c3b9b14d548f9e17acbe56366c };
			FlowElements[StartMessage3_4beebb560e174209a9ddd22032cf9520.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_4beebb560e174209a9ddd22032cf9520 };
			FlowElements[ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventTargetInsertedEventSubProcess":
						break;
					case "EventTargetInsertedMessage":
						e.Context.QueueTasks.Enqueue("EventTargetInsertedScriptTask");
						break;
					case "EventTargetInsertedScriptTask":
						break;
					case "EventTargetDeletedEventSubProcess":
						break;
					case "EventTargetDeletedMessage":
						e.Context.QueueTasks.Enqueue("EventTargetDeletedScriptTask");
						break;
					case "EventTargetDeletedScriptTask":
						break;
					case "EventSubProcess3_480f29c3b9b14d548f9e17acbe56366c":
						break;
					case "StartMessage3_4beebb560e174209a9ddd22032cf9520":
						e.Context.QueueTasks.Enqueue("ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3");
						break;
					case "ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("EventTargetInsertedMessage");
			ActivatedEventElements.Add("EventTargetDeletedMessage");
			ActivatedEventElements.Add("StartMessage3_4beebb560e174209a9ddd22032cf9520");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventTargetInsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "EventTargetInsertedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "EventTargetInsertedMessage";
					result = EventTargetInsertedMessage.Execute(context);
					break;
				case "EventTargetInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "EventTargetInsertedScriptTask";
					result = EventTargetInsertedScriptTask.Execute(context, EventTargetInsertedScriptTaskExecute);
					break;
				case "EventTargetDeletedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "EventTargetDeletedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "EventTargetDeletedMessage";
					result = EventTargetDeletedMessage.Execute(context);
					break;
				case "EventTargetDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "EventTargetDeletedScriptTask";
					result = EventTargetDeletedScriptTask.Execute(context, EventTargetDeletedScriptTaskExecute);
					break;
				case "EventSubProcess3_480f29c3b9b14d548f9e17acbe56366c":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_4beebb560e174209a9ddd22032cf9520":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_4beebb560e174209a9ddd22032cf9520";
					result = StartMessage3_4beebb560e174209a9ddd22032cf9520.Execute(context);
					break;
				case "ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3";
					result = ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3.Execute(context, ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool EventTargetInsertedScriptTaskExecute(ProcessExecutingContext context) {
			UpdateEventRecipientCount(1);
			return true;
		}

		public virtual bool EventTargetDeletedScriptTaskExecute(ProcessExecutingContext context) {
			UpdateEventRecipientCount(-1);
			return true;
		}

		public virtual bool ScriptTask3_dc8bd2905b244667b64d9b6d0f99bda3Execute(ProcessExecutingContext context) {
			OnInserting();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "EventTargetInserted":
							if (ActivatedEventElements.Contains("EventTargetInsertedMessage")) {
							context.QueueTasks.Enqueue("EventTargetInsertedMessage");
						}
						break;
					case "EventTargetDeleted":
							if (ActivatedEventElements.Contains("EventTargetDeletedMessage")) {
							context.QueueTasks.Enqueue("EventTargetDeletedMessage");
						}
						break;
					case "EventTargetInserting":
							if (ActivatedEventElements.Contains("StartMessage3_4beebb560e174209a9ddd22032cf9520")) {
							context.QueueTasks.Enqueue("StartMessage3_4beebb560e174209a9ddd22032cf9520");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: EventTarget_MarketingCampaignEventsProcess

	/// <exclude/>
	public class EventTarget_MarketingCampaignEventsProcess : EventTarget_MarketingCampaignEventsProcess<EventTarget>
	{

		public EventTarget_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: EventTargetEventsProcess

	/// <exclude/>
	public class EventTargetEventsProcess : EventTarget_MarketingCampaignEventsProcess
	{

		public EventTargetEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

