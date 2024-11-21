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

	#region Class: ContactAnniversarySchema

	/// <exclude/>
	public class ContactAnniversarySchema : BPMSoft.Configuration.BaseAnniversarySchema
	{

		#region Constructors: Public

		public ContactAnniversarySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactAnniversarySchema(ContactAnniversarySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactAnniversarySchema(ContactAnniversarySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fa36e9a5-c2fc-47b2-b5cb-2b58ef61d4e6");
			RealUId = new Guid("fa36e9a5-c2fc-47b2-b5cb-2b58ef61d4e6");
			Name = "ContactAnniversary";
			ParentSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e172fdfc-48ce-4a83-9e40-0c93bd26188f")) == null) {
				Columns.Add(CreateContactColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.SystemValue,
				ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
			};
			column.ModifiedInSchemaUId = new Guid("fa36e9a5-c2fc-47b2-b5cb-2b58ef61d4e6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.SystemValue,
				ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
			};
			column.ModifiedInSchemaUId = new Guid("fa36e9a5-c2fc-47b2-b5cb-2b58ef61d4e6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("fa36e9a5-c2fc-47b2-b5cb-2b58ef61d4e6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e172fdfc-48ce-4a83-9e40-0c93bd26188f"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("fa36e9a5-c2fc-47b2-b5cb-2b58ef61d4e6"),
				ModifiedInSchemaUId = new Guid("fa36e9a5-c2fc-47b2-b5cb-2b58ef61d4e6"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactAnniversary(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactAnniversary_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactAnniversarySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactAnniversarySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fa36e9a5-c2fc-47b2-b5cb-2b58ef61d4e6"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactAnniversary

	/// <summary>
	/// Noteworthy event of contact.
	/// </summary>
	public class ContactAnniversary : BPMSoft.Configuration.BaseAnniversary
	{

		#region Constructors: Public

		public ContactAnniversary(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactAnniversary";
		}

		public ContactAnniversary(ContactAnniversary source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactAnniversary_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactAnniversaryDeleted", e);
			Deleting += (s, e) => ThrowEvent("ContactAnniversaryDeleting", e);
			Inserting += (s, e) => ThrowEvent("ContactAnniversaryInserting", e);
			Saved += (s, e) => ThrowEvent("ContactAnniversarySaved", e);
			Saving += (s, e) => ThrowEvent("ContactAnniversarySaving", e);
			Validating += (s, e) => ThrowEvent("ContactAnniversaryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactAnniversary(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactAnniversary_BaseEventsProcess

	/// <exclude/>
	public partial class ContactAnniversary_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseAnniversary_BaseEventsProcess<TEntity> where TEntity : ContactAnniversary
	{

		#region Class: SynchronizeContactDataFlowElement

		/// <exclude/>
		public class SynchronizeContactDataFlowElement : SynchronizeParentEntityData
		{

			public SynchronizeContactDataFlowElement(UserConnection userConnection, ContactAnniversary_BaseEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SynchronizeContactData";
				IsLogging = false;
				SchemaElementUId = new Guid("3652ed05-819a-4102-917d-dace3ab4d495");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public ContactAnniversary_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactAnniversary_BaseEventsProcess";
			SchemaUId = new Guid("fa36e9a5-c2fc-47b2-b5cb-2b58ef61d4e6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fa36e9a5-c2fc-47b2-b5cb-2b58ef61d4e6");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid TypeOldValue {
			get;
			set;
		}

		public virtual bool IsCurrentContactBirthday {
			get;
			set;
		}

		public virtual bool IsBirthDateChanged {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("424d3fcf-eb2b-44b3-8555-5c0ac3e2a30f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactAnniversarySaved;
		public ProcessFlowElement ContactAnniversarySaved {
			get {
				return _contactAnniversarySaved ?? (_contactAnniversarySaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactAnniversarySaved",
					SchemaElementUId = new Guid("440db6c0-ff9f-47ed-9c62-67e55f6e6a79"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContactAnniversarySaved;
		public ProcessScriptTask ScriptContactAnniversarySaved {
			get {
				return _scriptContactAnniversarySaved ?? (_scriptContactAnniversarySaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContactAnniversarySaved",
					SchemaElementUId = new Guid("eeab9c46-1fe0-4dc4-ad9c-093214604655"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContactAnniversarySavedExecute,
				});
			}
		}

		private SynchronizeContactDataFlowElement _synchronizeContactData;
		public SynchronizeContactDataFlowElement SynchronizeContactData {
			get {
				return _synchronizeContactData ?? (_synchronizeContactData = new SynchronizeContactDataFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _scriptTask2;
		public ProcessScriptTask ScriptTask2 {
			get {
				return _scriptTask2 ?? (_scriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask2",
					SchemaElementUId = new Guid("daaed5bf-853f-4420-952f-6cfaa85c2d3a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask2Execute,
				});
			}
		}

		private ProcessScriptTask _updateContact;
		public ProcessScriptTask UpdateContact {
			get {
				return _updateContact ?? (_updateContact = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateContact",
					SchemaElementUId = new Guid("d4331a0d-ad4b-4ebf-975e-9c42e00d79e5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateContactExecute,
				});
			}
		}

		private ProcessScriptTask _updateRemindings;
		public ProcessScriptTask UpdateRemindings {
			get {
				return _updateRemindings ?? (_updateRemindings = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateRemindings",
					SchemaElementUId = new Guid("ee0b8d22-9347-4315-98fe-7c8d0025dd71"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateRemindingsExecute,
				});
			}
		}

		private ProcessFlowElement _subProcess1;
		public ProcessFlowElement SubProcess1 {
			get {
				return _subProcess1 ?? (_subProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess1",
					SchemaElementUId = new Guid("fe0343c3-0156-43a3-8ef5-0272760bc31b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactAnniversaryDeleted;
		public ProcessFlowElement ContactAnniversaryDeleted {
			get {
				return _contactAnniversaryDeleted ?? (_contactAnniversaryDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactAnniversaryDeleted",
					SchemaElementUId = new Guid("d5967a6b-4d60-4373-a28e-bb505b05529f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContactAnniversaryDeleted;
		public ProcessScriptTask ScriptContactAnniversaryDeleted {
			get {
				return _scriptContactAnniversaryDeleted ?? (_scriptContactAnniversaryDeleted = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContactAnniversaryDeleted",
					SchemaElementUId = new Guid("83931b88-8f3d-460e-810d-2b856fdd63cd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContactAnniversaryDeletedExecute,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("5a7868e9-c996-46aa-9c4a-a3c9a56aa185"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("5775ae89-a558-4cdf-8179-58c1cef66760"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessFlowElement _subProcess2;
		public ProcessFlowElement SubProcess2 {
			get {
				return _subProcess2 ?? (_subProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess2",
					SchemaElementUId = new Guid("fa6975d5-6872-4dac-bf64-d62644f1dbaf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactAnniversaryDeleting;
		public ProcessFlowElement ContactAnniversaryDeleting {
			get {
				return _contactAnniversaryDeleting ?? (_contactAnniversaryDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactAnniversaryDeleting",
					SchemaElementUId = new Guid("ff12752a-dbbb-4bf8-bd12-3270401a4070"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContactAnniversaryDeleting;
		public ProcessScriptTask ScriptContactAnniversaryDeleting {
			get {
				return _scriptContactAnniversaryDeleting ?? (_scriptContactAnniversaryDeleting = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContactAnniversaryDeleting",
					SchemaElementUId = new Guid("645b0ac9-19cc-4b92-96b5-92451ca11b5b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContactAnniversaryDeletingExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3_128f81454a2b4a1cb112cdec8d554bc1;
		public ProcessFlowElement EventSubProcess3_128f81454a2b4a1cb112cdec8d554bc1 {
			get {
				return _eventSubProcess3_128f81454a2b4a1cb112cdec8d554bc1 ?? (_eventSubProcess3_128f81454a2b4a1cb112cdec8d554bc1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_128f81454a2b4a1cb112cdec8d554bc1",
					SchemaElementUId = new Guid("128f8145-4a2b-4a1c-b112-cdec8d554bc1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactAnniversarySaving_Base;
		public ProcessFlowElement ContactAnniversarySaving_Base {
			get {
				return _contactAnniversarySaving_Base ?? (_contactAnniversarySaving_Base = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactAnniversarySaving_Base",
					SchemaElementUId = new Guid("12777a63-1ce5-4a98-a8c9-204c614985d9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _initValues;
		public ProcessScriptTask InitValues {
			get {
				return _initValues ?? (_initValues = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "InitValues",
					SchemaElementUId = new Guid("a58f9919-d1a3-4dd9-9cf4-de80a6f1afe6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = InitValuesExecute,
				});
			}
		}

		private ProcessConditionalFlow _sequenceFlow16338;
		public ProcessConditionalFlow SequenceFlow16338 {
			get {
				return _sequenceFlow16338 ?? (_sequenceFlow16338 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "SequenceFlow16338",
					SchemaElementUId = new Guid("68b4dfb4-c8c0-40c2-97e1-049c2664f8d6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ContactAnniversarySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactAnniversarySaved };
			FlowElements[ScriptContactAnniversarySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContactAnniversarySaved };
			FlowElements[SynchronizeContactData.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeContactData };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
			FlowElements[UpdateContact.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateContact };
			FlowElements[UpdateRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateRemindings };
			FlowElements[SubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess1 };
			FlowElements[ContactAnniversaryDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactAnniversaryDeleted };
			FlowElements[ScriptContactAnniversaryDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContactAnniversaryDeleted };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[SubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess2 };
			FlowElements[ContactAnniversaryDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactAnniversaryDeleting };
			FlowElements[ScriptContactAnniversaryDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContactAnniversaryDeleting };
			FlowElements[EventSubProcess3_128f81454a2b4a1cb112cdec8d554bc1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_128f81454a2b4a1cb112cdec8d554bc1 };
			FlowElements[ContactAnniversarySaving_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactAnniversarySaving_Base };
			FlowElements[InitValues.SchemaElementUId] = new Collection<ProcessFlowElement> { InitValues };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ContactAnniversarySaved":
						e.Context.QueueTasks.Enqueue("ScriptContactAnniversarySaved");
						break;
					case "ScriptContactAnniversarySaved":
						e.Context.QueueTasks.Enqueue("ScriptTask2");
						break;
					case "SynchronizeContactData":
							e.Context.QueueTasks.Enqueue("UpdateContact");
						break;
					case "ScriptTask2":
						e.Context.QueueTasks.Enqueue("SynchronizeContactData");
						break;
					case "UpdateContact":
						e.Context.QueueTasks.Enqueue("UpdateRemindings");
						break;
					case "UpdateRemindings":
						break;
					case "SubProcess1":
						break;
					case "ContactAnniversaryDeleted":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "ScriptContactAnniversaryDeleted":
						break;
					case "ScriptTask1":
						e.Context.QueueTasks.Enqueue("ScriptTask2");
						break;
					case "ExclusiveGateway1":
							e.Context.QueueTasks.Enqueue("ScriptContactAnniversaryDeleted");
						if (SequenceFlow16338ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("ScriptTask1");
							break;
						}
						break;
					case "SubProcess2":
						break;
					case "ContactAnniversaryDeleting":
						e.Context.QueueTasks.Enqueue("ScriptContactAnniversaryDeleting");
						break;
					case "ScriptContactAnniversaryDeleting":
						break;
					case "EventSubProcess3_128f81454a2b4a1cb112cdec8d554bc1":
						break;
					case "ContactAnniversarySaving_Base":
						e.Context.QueueTasks.Enqueue("InitValues");
						break;
					case "InitValues":
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool SequenceFlow16338ExpressionExecute() {
			return Convert.ToBoolean(IsCurrentContactBirthday);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ContactAnniversarySaved");
			ActivatedEventElements.Add("ContactAnniversaryDeleted");
			ActivatedEventElements.Add("ContactAnniversaryDeleting");
			ActivatedEventElements.Add("ContactAnniversarySaving_Base");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "ContactAnniversarySaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactAnniversarySaved";
					result = ContactAnniversarySaved.Execute(context);
					break;
				case "ScriptContactAnniversarySaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContactAnniversarySaved";
					result = ScriptContactAnniversarySaved.Execute(context, ScriptContactAnniversarySavedExecute);
					break;
				case "SynchronizeContactData":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeContactData";
					result = SynchronizeContactData.Execute(context);
					break;
				case "ScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask2";
					result = ScriptTask2.Execute(context, ScriptTask2Execute);
					break;
				case "UpdateContact":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateContact";
					result = UpdateContact.Execute(context, UpdateContactExecute);
					break;
				case "UpdateRemindings":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateRemindings";
					result = UpdateRemindings.Execute(context, UpdateRemindingsExecute);
					break;
				case "SubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "ContactAnniversaryDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactAnniversaryDeleted";
					result = ContactAnniversaryDeleted.Execute(context);
					break;
				case "ScriptContactAnniversaryDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContactAnniversaryDeleted";
					result = ScriptContactAnniversaryDeleted.Execute(context, ScriptContactAnniversaryDeletedExecute);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "ExclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway1";
					result = ExclusiveGateway1.Execute(context);
					break;
				case "SubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "ContactAnniversaryDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactAnniversaryDeleting";
					result = ContactAnniversaryDeleting.Execute(context);
					break;
				case "ScriptContactAnniversaryDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContactAnniversaryDeleting";
					result = ScriptContactAnniversaryDeleting.Execute(context, ScriptContactAnniversaryDeletingExecute);
					break;
				case "EventSubProcess3_128f81454a2b4a1cb112cdec8d554bc1":
					context.QueueTasks.Dequeue();
					break;
				case "ContactAnniversarySaving_Base":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactAnniversarySaving_Base";
					result = ContactAnniversarySaving_Base.Execute(context);
					break;
				case "InitValues":
					context.QueueTasks.Dequeue();
					context.SenderName = "InitValues";
					result = InitValues.Execute(context, InitValuesExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptContactAnniversarySavedExecute(ProcessExecutingContext context) {
			SynchronizeContactData.DeleteChild = false;
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			AddSyncContactData();
			return true;
		}

		public virtual bool UpdateContactExecute(ProcessExecutingContext context) {
			UpdateContactModifedOn();
			return true;
		}

		public virtual bool UpdateRemindingsExecute(ProcessExecutingContext context) {
			UpdateRemindingsExecute();
			return true;
		}

		public virtual bool ScriptContactAnniversaryDeletedExecute(ProcessExecutingContext context) {
			return true;
			
			
		}

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			Guid id = Entity.GetTypedColumnValue<Guid>("ContactId");
			Guid schemaUId = Entity.Contact.Schema.UId;
			Entity contactEntity = Entity.Contact.Schema.CreateEntity(UserConnection);
			contactEntity.FetchFromDB(id);
			BaseAnniversaryReminding remindingsGenerator = GetRemindingsGenerator(contactEntity);
			remindingsGenerator.DeleteRecordRemindings(schemaUId);
			SynchronizeContactData.DeleteChild = true;
			return true;
		}

		public virtual bool ScriptContactAnniversaryDeletingExecute(ProcessExecutingContext context) {
			IsCurrentContactBirthday = false;
			if (Entity.AnniversaryTypeId != new Guid("173D56D2-FDCA-DF11-9B2A-001D60E938C6")) {
				return true;
			}
			TypeOldValue= Entity.GetTypedOldColumnValue<Guid>(Entity.Schema.Columns.GetByName("AnniversaryType").ColumnValueName);
			var entitySchemaManager = UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, "Contact");
			entitySchemaQuery.AddColumn("Id");
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"BirthDate", Entity.Date));
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Id", Entity.ContactId));
			var entities = entitySchemaQuery.GetEntityCollection(UserConnection);
			if (entities.Count == 1) {
				entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, "ContactAnniversary");
				entitySchemaQuery.AddColumn("Id");
				entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
					"AnniversaryType", "173D56D2-FDCA-DF11-9B2A-001D60E938C6"));
				entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Contact", Entity.ContactId));
				entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Date", Entity.Date));
				entities = entitySchemaQuery.GetEntityCollection(UserConnection);
				if (entities.Count == 1) {
					IsCurrentContactBirthday = true;
				}
			}
			return true;
		}

		public virtual bool InitValuesExecute(ProcessExecutingContext context) {
			IsBirthDateChanged = Entity.GetChangedColumnValues().Any(col => col.Name == "Date");
			TypeOldValue = Entity.GetTypedOldColumnValue<Guid>("AnniversaryTypeId");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ContactAnniversarySaved":
							if (ActivatedEventElements.Contains("ContactAnniversarySaved")) {
							context.QueueTasks.Enqueue("ContactAnniversarySaved");
						}
						break;
					case "ContactAnniversaryDeleted":
							if (ActivatedEventElements.Contains("ContactAnniversaryDeleted")) {
							context.QueueTasks.Enqueue("ContactAnniversaryDeleted");
						}
						break;
					case "ContactAnniversaryDeleting":
							if (ActivatedEventElements.Contains("ContactAnniversaryDeleting")) {
							context.QueueTasks.Enqueue("ContactAnniversaryDeleting");
						}
						break;
					case "ContactAnniversarySaving":
							if (ActivatedEventElements.Contains("ContactAnniversarySaving_Base")) {
							context.QueueTasks.Enqueue("ContactAnniversarySaving_Base");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ContactAnniversary_BaseEventsProcess

	/// <exclude/>
	public class ContactAnniversary_BaseEventsProcess : ContactAnniversary_BaseEventsProcess<ContactAnniversary>
	{

		public ContactAnniversary_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: ContactAnniversaryEventsProcess

	/// <exclude/>
	public class ContactAnniversaryEventsProcess : ContactAnniversary_BaseEventsProcess
	{

		public ContactAnniversaryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

