namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: ContactCommunication_Base_BPMSoftSchema

	/// <exclude/>
	public class ContactCommunication_Base_BPMSoftSchema : BPMSoft.Configuration.BaseCommunicationSchema
	{

		#region Constructors: Public

		public ContactCommunication_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactCommunication_Base_BPMSoftSchema(ContactCommunication_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactCommunication_Base_BPMSoftSchema(ContactCommunication_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41");
			RealUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41");
			Name = "ContactCommunication_Base_BPMSoft";
			ParentSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateContactColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c93fe4de-6262-4a06-bd20-df27c2b7982c")) == null) {
				Columns.Add(CreateIsCreatedBySynchronizationColumn());
			}
			if (Columns.FindByUId(new Guid("31c70950-bdc3-4d5d-86fe-0cce719c84dc")) == null) {
				Columns.Add(CreateExternalCommunicationTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchNumberColumn() {
			EntitySchemaColumn column = base.CreateSearchNumberColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("MediumText");
			column.ModifiedInSchemaUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf226458-c1c0-4d0c-afe5-41664f2d570e"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41"),
				ModifiedInSchemaUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsCreatedBySynchronizationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c93fe4de-6262-4a06-bd20-df27c2b7982c"),
				Name = @"IsCreatedBySynchronization",
				CreatedInSchemaUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41"),
				ModifiedInSchemaUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateExternalCommunicationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("31c70950-bdc3-4d5d-86fe-0cce719c84dc"),
				Name = @"ExternalCommunicationType",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41"),
				ModifiedInSchemaUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41"),
				CreatedInPackageId = new Guid("45b7d114-643d-4217-a8b2-b9950d3eddb7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactCommunication_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactCommunication_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactCommunication_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactCommunication_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactCommunication_Base_BPMSoft

	/// <summary>
	/// Средство связи контакта.
	/// </summary>
	public class ContactCommunication_Base_BPMSoft : BPMSoft.Configuration.BaseCommunication
	{

		#region Constructors: Public

		public ContactCommunication_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactCommunication_Base_BPMSoft";
		}

		public ContactCommunication_Base_BPMSoft(ContactCommunication_Base_BPMSoft source)
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
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Created by synchronization.
		/// </summary>
		public bool IsCreatedBySynchronization {
			get {
				return GetTypedColumnValue<bool>("IsCreatedBySynchronization");
			}
			set {
				SetColumnValue("IsCreatedBySynchronization", value);
			}
		}

		/// <summary>
		/// Тип средства связи во внешнем ресурсе.
		/// </summary>
		public string ExternalCommunicationType {
			get {
				return GetTypedColumnValue<string>("ExternalCommunicationType");
			}
			set {
				SetColumnValue("ExternalCommunicationType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactCommunication_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactCommunication_Base_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("ContactCommunication_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("ContactCommunication_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("ContactCommunication_Base_BPMSoftSaving", e);
			Updating += (s, e) => ThrowEvent("ContactCommunication_Base_BPMSoftUpdating", e);
			Validating += (s, e) => ThrowEvent("ContactCommunication_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactCommunication_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactCommunication_BaseEventsProcess

	/// <exclude/>
	public partial class ContactCommunication_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCommunication_BaseEventsProcess<TEntity> where TEntity : ContactCommunication_Base_BPMSoft
	{

		public ContactCommunication_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactCommunication_BaseEventsProcess";
			SchemaUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool DeletedMain {
			get;
			set;
		}

		public virtual bool IsNew {
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
					SchemaElementUId = new Guid("e6515633-f307-4575-a468-9506113f07b7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactCommunicationSaved;
		public ProcessFlowElement ContactCommunicationSaved {
			get {
				return _contactCommunicationSaved ?? (_contactCommunicationSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactCommunicationSaved",
					SchemaElementUId = new Guid("f886d715-d1fc-4a62-a4a2-6988c192cdaa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContactCommunicationSaved;
		public ProcessScriptTask ScriptContactCommunicationSaved {
			get {
				return _scriptContactCommunicationSaved ?? (_scriptContactCommunicationSaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContactCommunicationSaved",
					SchemaElementUId = new Guid("000ae750-aea5-44b4-8339-81795bd840be"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContactCommunicationSavedExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3;
		public ProcessFlowElement EventSubProcess3 {
			get {
				return _eventSubProcess3 ?? (_eventSubProcess3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3",
					SchemaElementUId = new Guid("f80e73a9-7634-453c-8e30-aa57dbf03366"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactCommunicationDeleted;
		public ProcessFlowElement ContactCommunicationDeleted {
			get {
				return _contactCommunicationDeleted ?? (_contactCommunicationDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactCommunicationDeleted",
					SchemaElementUId = new Guid("616c80f6-9658-4c86-8e5c-fa9d1054268e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContactCommunicationDeleted;
		public ProcessScriptTask ScriptContactCommunicationDeleted {
			get {
				return _scriptContactCommunicationDeleted ?? (_scriptContactCommunicationDeleted = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContactCommunicationDeleted",
					SchemaElementUId = new Guid("b3eb100d-00ab-43bf-8b71-1ba877178682"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContactCommunicationDeletedExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("cde71769-f95b-40c6-a70a-dd0bc670f691"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactCommunicationSavingStartMessage;
		public ProcessFlowElement ContactCommunicationSavingStartMessage {
			get {
				return _contactCommunicationSavingStartMessage ?? (_contactCommunicationSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactCommunicationSavingStartMessage",
					SchemaElementUId = new Guid("61a13bc5-6c00-4ff1-9bcd-e454a44231b2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _contactCommunicationSavingScriptTask;
		public ProcessScriptTask ContactCommunicationSavingScriptTask {
			get {
				return _contactCommunicationSavingScriptTask ?? (_contactCommunicationSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ContactCommunicationSavingScriptTask",
					SchemaElementUId = new Guid("b72ffab2-963a-481c-826d-686a7090b4e9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ContactCommunicationSavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4846;
		public ProcessFlowElement EventSubProcess4846 {
			get {
				return _eventSubProcess4846 ?? (_eventSubProcess4846 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4846",
					SchemaElementUId = new Guid("2de10518-9086-45b8-8a1a-70282e233518"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactCommunicationUpdating;
		public ProcessFlowElement ContactCommunicationUpdating {
			get {
				return _contactCommunicationUpdating ?? (_contactCommunicationUpdating = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactCommunicationUpdating",
					SchemaElementUId = new Guid("34608bf1-84ea-4f70-b303-c37d183b0ae0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContactCommunicationUpdating;
		public ProcessScriptTask ScriptContactCommunicationUpdating {
			get {
				return _scriptContactCommunicationUpdating ?? (_scriptContactCommunicationUpdating = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContactCommunicationUpdating",
					SchemaElementUId = new Guid("f01709d4-d644-49e2-b6b1-99bdb8f14240"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContactCommunicationUpdatingExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ContactCommunicationSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactCommunicationSaved };
			FlowElements[ScriptContactCommunicationSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContactCommunicationSaved };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[ContactCommunicationDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactCommunicationDeleted };
			FlowElements[ScriptContactCommunicationDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContactCommunicationDeleted };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[ContactCommunicationSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactCommunicationSavingStartMessage };
			FlowElements[ContactCommunicationSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactCommunicationSavingScriptTask };
			FlowElements[EventSubProcess4846.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4846 };
			FlowElements[ContactCommunicationUpdating.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactCommunicationUpdating };
			FlowElements[ScriptContactCommunicationUpdating.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContactCommunicationUpdating };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ContactCommunicationSaved":
						e.Context.QueueTasks.Enqueue("ScriptContactCommunicationSaved");
						break;
					case "ScriptContactCommunicationSaved":
						break;
					case "EventSubProcess3":
						break;
					case "ContactCommunicationDeleted":
						e.Context.QueueTasks.Enqueue("ScriptContactCommunicationDeleted");
						break;
					case "ScriptContactCommunicationDeleted":
						break;
					case "EventSubProcess2":
						break;
					case "ContactCommunicationSavingStartMessage":
						e.Context.QueueTasks.Enqueue("ContactCommunicationSavingScriptTask");
						break;
					case "ContactCommunicationSavingScriptTask":
						break;
					case "EventSubProcess4846":
						break;
					case "ContactCommunicationUpdating":
						e.Context.QueueTasks.Enqueue("ScriptContactCommunicationUpdating");
						break;
					case "ScriptContactCommunicationUpdating":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ContactCommunicationSaved");
			ActivatedEventElements.Add("ContactCommunicationDeleted");
			ActivatedEventElements.Add("ContactCommunicationSavingStartMessage");
			ActivatedEventElements.Add("ContactCommunicationUpdating");
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
				case "ContactCommunicationSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactCommunicationSaved";
					result = ContactCommunicationSaved.Execute(context);
					break;
				case "ScriptContactCommunicationSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContactCommunicationSaved";
					result = ScriptContactCommunicationSaved.Execute(context, ScriptContactCommunicationSavedExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "ContactCommunicationDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactCommunicationDeleted";
					result = ContactCommunicationDeleted.Execute(context);
					break;
				case "ScriptContactCommunicationDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContactCommunicationDeleted";
					result = ScriptContactCommunicationDeleted.Execute(context, ScriptContactCommunicationDeletedExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "ContactCommunicationSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactCommunicationSavingStartMessage";
					result = ContactCommunicationSavingStartMessage.Execute(context);
					break;
				case "ContactCommunicationSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactCommunicationSavingScriptTask";
					result = ContactCommunicationSavingScriptTask.Execute(context, ContactCommunicationSavingScriptTaskExecute);
					break;
				case "EventSubProcess4846":
					context.QueueTasks.Dequeue();
					break;
				case "ContactCommunicationUpdating":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactCommunicationUpdating";
					result = ContactCommunicationUpdating.Execute(context);
					break;
				case "ScriptContactCommunicationUpdating":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContactCommunicationUpdating";
					result = ScriptContactCommunicationUpdating.Execute(context, ScriptContactCommunicationUpdatingExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptContactCommunicationSavedExecute(ProcessExecutingContext context) {
			SetNewContactCommunication();
			RemoveDuplicates();
			return true;
		}

		public virtual bool ScriptContactCommunicationDeletedExecute(ProcessExecutingContext context) {
			OnContactCommunicationDeleted();
			return true;
		}

		public virtual bool ContactCommunicationSavingScriptTaskExecute(ProcessExecutingContext context) {
			OnContactCommunicationSaving();
			return true;
		}

		public virtual bool ScriptContactCommunicationUpdatingExecute(ProcessExecutingContext context) {
			ActualizeExternalCommunicationType();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ContactCommunication_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("ContactCommunicationSaved")) {
							context.QueueTasks.Enqueue("ContactCommunicationSaved");
						}
						break;
					case "ContactCommunication_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("ContactCommunicationDeleted")) {
							context.QueueTasks.Enqueue("ContactCommunicationDeleted");
						}
						break;
					case "ContactCommunication_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("ContactCommunicationSavingStartMessage")) {
							context.QueueTasks.Enqueue("ContactCommunicationSavingStartMessage");
						}
						break;
					case "ContactCommunication_Base_BPMSoftUpdating":
							if (ActivatedEventElements.Contains("ContactCommunicationUpdating")) {
							context.QueueTasks.Enqueue("ContactCommunicationUpdating");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ContactCommunication_BaseEventsProcess

	/// <exclude/>
	public class ContactCommunication_BaseEventsProcess : ContactCommunication_BaseEventsProcess<ContactCommunication_Base_BPMSoft>
	{

		public ContactCommunication_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

