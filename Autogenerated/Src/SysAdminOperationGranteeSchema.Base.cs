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
	using BPMSoft.Core.OperationLog;
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

	#region Class: SysAdminOperationGranteeSchema

	/// <exclude/>
	public class SysAdminOperationGranteeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysAdminOperationGranteeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminOperationGranteeSchema(SysAdminOperationGranteeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminOperationGranteeSchema(SysAdminOperationGranteeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a");
			RealUId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a");
			Name = "SysAdminOperationGrantee";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a64eb826-4dc1-45fb-a5ac-d768275eb719")) == null) {
				Columns.Add(CreateSysAdminOperationColumn());
			}
			if (Columns.FindByUId(new Guid("423b165f-9759-437b-b532-95ef1b78063b")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("e1f978af-3b07-4c9f-a422-c6170cd1b1a4")) == null) {
				Columns.Add(CreateCanExecuteColumn());
			}
			if (Columns.FindByUId(new Guid("9d032101-3db5-4bba-ab16-294104cd15ad")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a64eb826-4dc1-45fb-a5ac-d768275eb719"),
				Name = @"SysAdminOperation",
				ReferenceSchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a"),
				ModifiedInSchemaUId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("423b165f-9759-437b-b532-95ef1b78063b"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a"),
				ModifiedInSchemaUId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateCanExecuteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e1f978af-3b07-4c9f-a422-c6170cd1b1a4"),
				Name = @"CanExecute",
				CreatedInSchemaUId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a"),
				ModifiedInSchemaUId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9d032101-3db5-4bba-ab16-294104cd15ad"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a"),
				ModifiedInSchemaUId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminOperationGrantee(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminOperationGrantee_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminOperationGranteeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminOperationGranteeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminOperationGrantee

	/// <summary>
	/// Permission granted to.
	/// </summary>
	public class SysAdminOperationGrantee : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysAdminOperationGrantee(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminOperationGrantee";
		}

		public SysAdminOperationGrantee(SysAdminOperationGrantee source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminOperationId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminOperationId");
			}
			set {
				SetColumnValue("SysAdminOperationId", value);
				_sysAdminOperation = null;
			}
		}

		/// <exclude/>
		public string SysAdminOperationName {
			get {
				return GetTypedColumnValue<string>("SysAdminOperationName");
			}
			set {
				SetColumnValue("SysAdminOperationName", value);
				if (_sysAdminOperation != null) {
					_sysAdminOperation.Name = value;
				}
			}
		}

		private SysAdminOperation _sysAdminOperation;
		/// <summary>
		/// Operation.
		/// </summary>
		public SysAdminOperation SysAdminOperation {
			get {
				return _sysAdminOperation ??
					(_sysAdminOperation = LookupColumnEntities.GetEntity("SysAdminOperation") as SysAdminOperation);
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// User/role.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Access level.
		/// </summary>
		public bool CanExecute {
			get {
				return GetTypedColumnValue<bool>("CanExecute");
			}
			set {
				SetColumnValue("CanExecute", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminOperationGrantee_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysAdminOperationGranteeDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysAdminOperationGranteeDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysAdminOperationGranteeInserted", e);
			Inserting += (s, e) => ThrowEvent("SysAdminOperationGranteeInserting", e);
			Saved += (s, e) => ThrowEvent("SysAdminOperationGranteeSaved", e);
			Saving += (s, e) => ThrowEvent("SysAdminOperationGranteeSaving", e);
			Updated += (s, e) => ThrowEvent("SysAdminOperationGranteeUpdated", e);
			Validating += (s, e) => ThrowEvent("SysAdminOperationGranteeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminOperationGrantee(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminOperationGrantee_BaseEventsProcess

	/// <exclude/>
	public partial class SysAdminOperationGrantee_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysAdminOperationGrantee
	{

		public SysAdminOperationGrantee_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminOperationGrantee_BaseEventsProcess";
			SchemaUId = new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3987bdc6-38bb-4b41-bcf7-90bb3995117a");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("866cebdd-d009-445b-ad0b-8535a1e65bca"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminOperationGranteeInserted_StartMessage;
		public ProcessFlowElement SysAdminOperationGranteeInserted_StartMessage {
			get {
				return _sysAdminOperationGranteeInserted_StartMessage ?? (_sysAdminOperationGranteeInserted_StartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminOperationGranteeInserted_StartMessage",
					SchemaElementUId = new Guid("e50cdb5f-bc9e-4e1c-a2b8-47c7e6e2a018"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _sysAdminOperationGranteeInserted_IntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SysAdminOperationGranteeInserted_IntermediateThrowMessageEvent {
			get {
				return _sysAdminOperationGranteeInserted_IntermediateThrowMessageEvent ?? (_sysAdminOperationGranteeInserted_IntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SysAdminOperationGranteeInserted_IntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("5fabeb90-f222-4a7c-b38f-18532cc12256"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SysAdminOperationGranteeInserted",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _inserted_ScriptTask;
		public ProcessScriptTask Inserted_ScriptTask {
			get {
				return _inserted_ScriptTask ?? (_inserted_ScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "Inserted_ScriptTask",
					SchemaElementUId = new Guid("f71f5db7-998e-49d2-8170-34d1149a2794"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = Inserted_ScriptTaskExecute,
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
					SchemaElementUId = new Guid("ca6ac841-a7fa-489c-b566-127a460fbfb6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminOperationGranteeDeleting_StartMessage;
		public ProcessFlowElement SysAdminOperationGranteeDeleting_StartMessage {
			get {
				return _sysAdminOperationGranteeDeleting_StartMessage ?? (_sysAdminOperationGranteeDeleting_StartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminOperationGranteeDeleting_StartMessage",
					SchemaElementUId = new Guid("012997eb-40cb-4ea0-8482-8f47f8128397"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _sysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent {
			get {
				return _sysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent ?? (_sysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("18f3157c-90f4-46c1-a50c-5a7d5c52b337"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SysAdminOperationGranteeDeleting",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _logDelete_ScriptTask;
		public ProcessScriptTask LogDelete_ScriptTask {
			get {
				return _logDelete_ScriptTask ?? (_logDelete_ScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LogDelete_ScriptTask",
					SchemaElementUId = new Guid("591ef89f-616e-4692-a6b5-11d0a9131713"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = LogDelete_ScriptTaskExecute,
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
					SchemaElementUId = new Guid("dc65fb93-2ff2-4f70-bcad-2b5a827d4b20"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updated_ScriptTask;
		public ProcessScriptTask Updated_ScriptTask {
			get {
				return _updated_ScriptTask ?? (_updated_ScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "Updated_ScriptTask",
					SchemaElementUId = new Guid("5dcf602a-02b3-4529-b8a8-d140a3355d2f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = Updated_ScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _sysAdminOperationGranteeUpdated_StartMessage;
		public ProcessFlowElement SysAdminOperationGranteeUpdated_StartMessage {
			get {
				return _sysAdminOperationGranteeUpdated_StartMessage ?? (_sysAdminOperationGranteeUpdated_StartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminOperationGranteeUpdated_StartMessage",
					SchemaElementUId = new Guid("1efe4bd4-34fb-46da-8f31-d74bbfa24aab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _sysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent {
			get {
				return _sysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent ?? (_sysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("2a9fca7e-0c7e-4140-a7cd-97267300c4a6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SysAdminOperationGranteeUpdated",
						ThrowToBase = true,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[SysAdminOperationGranteeInserted_StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminOperationGranteeInserted_StartMessage };
			FlowElements[SysAdminOperationGranteeInserted_IntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminOperationGranteeInserted_IntermediateThrowMessageEvent };
			FlowElements[Inserted_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { Inserted_ScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[SysAdminOperationGranteeDeleting_StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminOperationGranteeDeleting_StartMessage };
			FlowElements[SysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent };
			FlowElements[LogDelete_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogDelete_ScriptTask };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[Updated_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { Updated_ScriptTask };
			FlowElements[SysAdminOperationGranteeUpdated_StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminOperationGranteeUpdated_StartMessage };
			FlowElements[SysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "SysAdminOperationGranteeInserted_StartMessage":
						e.Context.QueueTasks.Enqueue("Inserted_ScriptTask");
						break;
					case "SysAdminOperationGranteeInserted_IntermediateThrowMessageEvent":
						break;
					case "Inserted_ScriptTask":
						e.Context.QueueTasks.Enqueue("SysAdminOperationGranteeInserted_IntermediateThrowMessageEvent");
						break;
					case "EventSubProcess2":
						break;
					case "SysAdminOperationGranteeDeleting_StartMessage":
						e.Context.QueueTasks.Enqueue("LogDelete_ScriptTask");
						break;
					case "SysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent":
						break;
					case "LogDelete_ScriptTask":
						e.Context.QueueTasks.Enqueue("SysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent");
						break;
					case "EventSubProcess3":
						break;
					case "Updated_ScriptTask":
						e.Context.QueueTasks.Enqueue("SysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent");
						break;
					case "SysAdminOperationGranteeUpdated_StartMessage":
						e.Context.QueueTasks.Enqueue("Updated_ScriptTask");
						break;
					case "SysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysAdminOperationGranteeInserted_StartMessage");
			ActivatedEventElements.Add("SysAdminOperationGranteeDeleting_StartMessage");
			ActivatedEventElements.Add("SysAdminOperationGranteeUpdated_StartMessage");
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
				case "SysAdminOperationGranteeInserted_StartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminOperationGranteeInserted_StartMessage";
					result = SysAdminOperationGranteeInserted_StartMessage.Execute(context);
					break;
				case "SysAdminOperationGranteeInserted_IntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "SysAdminOperationGranteeInserted");
					result = SysAdminOperationGranteeInserted_IntermediateThrowMessageEvent.Execute(context);
					break;
				case "Inserted_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "Inserted_ScriptTask";
					result = Inserted_ScriptTask.Execute(context, Inserted_ScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "SysAdminOperationGranteeDeleting_StartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminOperationGranteeDeleting_StartMessage";
					result = SysAdminOperationGranteeDeleting_StartMessage.Execute(context);
					break;
				case "SysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "SysAdminOperationGranteeDeleting");
					result = SysAdminOperationGranteeDeleting_IntermediateThrowMessageEvent.Execute(context);
					break;
				case "LogDelete_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LogDelete_ScriptTask";
					result = LogDelete_ScriptTask.Execute(context, LogDelete_ScriptTaskExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "Updated_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "Updated_ScriptTask";
					result = Updated_ScriptTask.Execute(context, Updated_ScriptTaskExecute);
					break;
				case "SysAdminOperationGranteeUpdated_StartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminOperationGranteeUpdated_StartMessage";
					result = SysAdminOperationGranteeUpdated_StartMessage.Execute(context);
					break;
				case "SysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "SysAdminOperationGranteeUpdated");
					result = SysAdminOperationGranteeUpdated_IntermediateThrowMessageEvent.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool Inserted_ScriptTaskExecute(ProcessExecutingContext context) {
			OperationLogger.Instance.LogAdminOperationRightAdd(UserConnection, Entity.PrimaryColumnValue);
			return true;
		}

		public virtual bool LogDelete_ScriptTaskExecute(ProcessExecutingContext context) {
			OperationLogger.Instance.LogAdminOperationRightDelete(UserConnection, Entity.PrimaryColumnValue);
			return true;
		}

		public virtual bool Updated_ScriptTaskExecute(ProcessExecutingContext context) {
			var eventArgs = (context.ThrowEventArgs as BPMSoft.Core.Entities.EntityAfterEventArgs);
			var modifiedColumnValues = eventArgs.ModifiedColumnValues;
			bool positionChanged = modifiedColumnValues.FindByName("Position") != null;
			OperationLogger.Instance.LogAdminOperationRightChange(UserConnection, Entity.PrimaryColumnValue, positionChanged);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysAdminOperationGranteeInserted":
							if (ActivatedEventElements.Contains("SysAdminOperationGranteeInserted_StartMessage")) {
							context.QueueTasks.Enqueue("SysAdminOperationGranteeInserted_StartMessage");
						}
						break;
					case "SysAdminOperationGranteeDeleting":
							if (ActivatedEventElements.Contains("SysAdminOperationGranteeDeleting_StartMessage")) {
							context.QueueTasks.Enqueue("SysAdminOperationGranteeDeleting_StartMessage");
						}
						break;
					case "SysAdminOperationGranteeUpdated":
							if (ActivatedEventElements.Contains("SysAdminOperationGranteeUpdated_StartMessage")) {
							context.QueueTasks.Enqueue("SysAdminOperationGranteeUpdated_StartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminOperationGrantee_BaseEventsProcess

	/// <exclude/>
	public class SysAdminOperationGrantee_BaseEventsProcess : SysAdminOperationGrantee_BaseEventsProcess<SysAdminOperationGrantee>
	{

		public SysAdminOperationGrantee_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminOperationGrantee_BaseEventsProcess

	public partial class SysAdminOperationGrantee_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAdminOperationGranteeEventsProcess

	/// <exclude/>
	public class SysAdminOperationGranteeEventsProcess : SysAdminOperationGrantee_BaseEventsProcess
	{

		public SysAdminOperationGranteeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

