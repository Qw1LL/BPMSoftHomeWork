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

	#region Class: SysAdminUnitIPRangeSchema

	/// <exclude/>
	public class SysAdminUnitIPRangeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysAdminUnitIPRangeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminUnitIPRangeSchema(SysAdminUnitIPRangeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminUnitIPRangeSchema(SysAdminUnitIPRangeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add");
			RealUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add");
			Name = "SysAdminUnitIPRange";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("80562de5-dd61-480f-af1f-84ceefea423f")) == null) {
				Columns.Add(CreateBeginIPColumn());
			}
			if (Columns.FindByUId(new Guid("3df16c98-3a83-4b7b-94b0-c138ba6ded0d")) == null) {
				Columns.Add(CreateEndIPColumn());
			}
			if (Columns.FindByUId(new Guid("1e3c68d3-97a9-45a6-ae30-951580afc7c5")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add");
			column.CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add");
			column.CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add");
			column.CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add");
			column.CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add");
			column.CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add");
			column.CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376");
			return column;
		}

		protected virtual EntitySchemaColumn CreateBeginIPColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("80562de5-dd61-480f-af1f-84ceefea423f"),
				Name = @"BeginIP",
				CreatedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add"),
				ModifiedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add"),
				CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376")
			};
		}

		protected virtual EntitySchemaColumn CreateEndIPColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3df16c98-3a83-4b7b-94b0-c138ba6ded0d"),
				Name = @"EndIP",
				CreatedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add"),
				ModifiedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add"),
				CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1e3c68d3-97a9-45a6-ae30-951580afc7c5"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add"),
				ModifiedInSchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add"),
				CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminUnitIPRange(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminUnitIPRange_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminUnitIPRangeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminUnitIPRangeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitIPRange

	/// <summary>
	/// IP range.
	/// </summary>
	public class SysAdminUnitIPRange : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysAdminUnitIPRange(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnitIPRange";
		}

		public SysAdminUnitIPRange(SysAdminUnitIPRange source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Start IP address.
		/// </summary>
		public string BeginIP {
			get {
				return GetTypedColumnValue<string>("BeginIP");
			}
			set {
				SetColumnValue("BeginIP", value);
			}
		}

		/// <summary>
		/// End IP address.
		/// </summary>
		public string EndIP {
			get {
				return GetTypedColumnValue<string>("EndIP");
			}
			set {
				SetColumnValue("EndIP", value);
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
		/// Object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminUnitIPRange_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysAdminUnitIPRangeDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysAdminUnitIPRangeDeleting", e);
			Inserting += (s, e) => ThrowEvent("SysAdminUnitIPRangeInserting", e);
			Saved += (s, e) => ThrowEvent("SysAdminUnitIPRangeSaved", e);
			Saving += (s, e) => ThrowEvent("SysAdminUnitIPRangeSaving", e);
			Validating += (s, e) => ThrowEvent("SysAdminUnitIPRangeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminUnitIPRange(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitIPRange_BaseEventsProcess

	/// <exclude/>
	public partial class SysAdminUnitIPRange_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysAdminUnitIPRange
	{

		public SysAdminUnitIPRange_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminUnitIPRange_BaseEventsProcess";
			SchemaUId = new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ba5b0dfd-5632-4ca1-b50e-0d56ba338add");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual string AdminUnitName {
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
					SchemaElementUId = new Guid("70bac210-61ba-4444-b50c-575288f98f25"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitIPRangeSaved_StartMessage;
		public ProcessFlowElement SysAdminUnitIPRangeSaved_StartMessage {
			get {
				return _sysAdminUnitIPRangeSaved_StartMessage ?? (_sysAdminUnitIPRangeSaved_StartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitIPRangeSaved_StartMessage",
					SchemaElementUId = new Guid("e11386a7-5da6-487d-b415-b987eafae95e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _sysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent {
			get {
				return _sysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent ?? (_sysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("c2b2dfc0-e59e-4a1f-8551-d0607663b1f0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SysAdminUnitIPRangeSaved",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _logSave_ScriptTask;
		public ProcessScriptTask LogSave_ScriptTask {
			get {
				return _logSave_ScriptTask ?? (_logSave_ScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LogSave_ScriptTask",
					SchemaElementUId = new Guid("c7d5f13d-ae26-4efc-97ca-5b4e5289197a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = LogSave_ScriptTaskExecute,
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
					SchemaElementUId = new Guid("da4fecdd-fde3-4a7b-b3bb-c610ded2e81a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitIPRangeDeleted_StartMessage;
		public ProcessFlowElement SysAdminUnitIPRangeDeleted_StartMessage {
			get {
				return _sysAdminUnitIPRangeDeleted_StartMessage ?? (_sysAdminUnitIPRangeDeleted_StartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitIPRangeDeleted_StartMessage",
					SchemaElementUId = new Guid("5ea447b2-2e91-426f-a427-56d142ad8f04"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _sysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent {
			get {
				return _sysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent ?? (_sysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("ab11b8bd-723f-4609-8dc5-2a9b4d5f64d3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SysAdminUnitIPRangeDeleted",
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
					SchemaElementUId = new Guid("4f64a6c3-b88f-41af-8400-b5a9591cfbce"),
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
					SchemaElementUId = new Guid("e9bee84e-c359-4b2a-a3a5-bf54e0e94c54"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitIPRangeDeleting_StartMessage;
		public ProcessFlowElement SysAdminUnitIPRangeDeleting_StartMessage {
			get {
				return _sysAdminUnitIPRangeDeleting_StartMessage ?? (_sysAdminUnitIPRangeDeleting_StartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitIPRangeDeleting_StartMessage",
					SchemaElementUId = new Guid("9577f9b9-71fa-46d6-9aa5-3d731c8f71a0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _sysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent {
			get {
				return _sysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent ?? (_sysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("e9eedd7b-c7e7-47c4-937a-5fb132e750c7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SysAdminUnitIPRangeDeleting",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _getAdminUnit_ScriptTask;
		public ProcessScriptTask GetAdminUnit_ScriptTask {
			get {
				return _getAdminUnit_ScriptTask ?? (_getAdminUnit_ScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "GetAdminUnit_ScriptTask",
					SchemaElementUId = new Guid("c8a66c40-97b7-49c6-b729-71ed34a3013b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = GetAdminUnit_ScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4;
		public ProcessFlowElement EventSubProcess4 {
			get {
				return _eventSubProcess4 ?? (_eventSubProcess4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4",
					SchemaElementUId = new Guid("23ee951e-642e-4ba5-9bb3-c489d6b12442"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitIPRangeSaving;
		public ProcessFlowElement SysAdminUnitIPRangeSaving {
			get {
				return _sysAdminUnitIPRangeSaving ?? (_sysAdminUnitIPRangeSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitIPRangeSaving",
					SchemaElementUId = new Guid("89288b34-e6f9-40bb-8379-a1f4d3f7a731"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("a56e1fb6-ea80-46c3-a226-f375289003b5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[SysAdminUnitIPRangeSaved_StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitIPRangeSaved_StartMessage };
			FlowElements[SysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent };
			FlowElements[LogSave_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogSave_ScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[SysAdminUnitIPRangeDeleted_StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitIPRangeDeleted_StartMessage };
			FlowElements[SysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent };
			FlowElements[LogDelete_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogDelete_ScriptTask };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[SysAdminUnitIPRangeDeleting_StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitIPRangeDeleting_StartMessage };
			FlowElements[SysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent };
			FlowElements[GetAdminUnit_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GetAdminUnit_ScriptTask };
			FlowElements[EventSubProcess4.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4 };
			FlowElements[SysAdminUnitIPRangeSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitIPRangeSaving };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "SysAdminUnitIPRangeSaved_StartMessage":
						e.Context.QueueTasks.Enqueue("LogSave_ScriptTask");
						break;
					case "SysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent":
						break;
					case "LogSave_ScriptTask":
						e.Context.QueueTasks.Enqueue("SysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent");
						break;
					case "EventSubProcess2":
						break;
					case "SysAdminUnitIPRangeDeleted_StartMessage":
						e.Context.QueueTasks.Enqueue("LogDelete_ScriptTask");
						break;
					case "SysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent":
						break;
					case "LogDelete_ScriptTask":
						e.Context.QueueTasks.Enqueue("SysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent");
						break;
					case "EventSubProcess3":
						break;
					case "SysAdminUnitIPRangeDeleting_StartMessage":
						e.Context.QueueTasks.Enqueue("GetAdminUnit_ScriptTask");
						break;
					case "SysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent":
						break;
					case "GetAdminUnit_ScriptTask":
						e.Context.QueueTasks.Enqueue("SysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent");
						break;
					case "EventSubProcess4":
						break;
					case "SysAdminUnitIPRangeSaving":
						e.Context.QueueTasks.Enqueue("ScriptTask1");
						break;
					case "ScriptTask1":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysAdminUnitIPRangeSaved_StartMessage");
			ActivatedEventElements.Add("SysAdminUnitIPRangeDeleted_StartMessage");
			ActivatedEventElements.Add("SysAdminUnitIPRangeDeleting_StartMessage");
			ActivatedEventElements.Add("SysAdminUnitIPRangeSaving");
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
				case "SysAdminUnitIPRangeSaved_StartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitIPRangeSaved_StartMessage";
					result = SysAdminUnitIPRangeSaved_StartMessage.Execute(context);
					break;
				case "SysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "SysAdminUnitIPRangeSaved");
					result = SysAdminUnitIPRangeSaved_IntermediateThrowMessageEvent.Execute(context);
					break;
				case "LogSave_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LogSave_ScriptTask";
					result = LogSave_ScriptTask.Execute(context, LogSave_ScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "SysAdminUnitIPRangeDeleted_StartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitIPRangeDeleted_StartMessage";
					result = SysAdminUnitIPRangeDeleted_StartMessage.Execute(context);
					break;
				case "SysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "SysAdminUnitIPRangeDeleted");
					result = SysAdminUnitIPRangeDeleted_IntermediateThrowMessageEvent.Execute(context);
					break;
				case "LogDelete_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LogDelete_ScriptTask";
					result = LogDelete_ScriptTask.Execute(context, LogDelete_ScriptTaskExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "SysAdminUnitIPRangeDeleting_StartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitIPRangeDeleting_StartMessage";
					result = SysAdminUnitIPRangeDeleting_StartMessage.Execute(context);
					break;
				case "SysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "SysAdminUnitIPRangeDeleting");
					result = SysAdminUnitIPRangeDeleting_IntermediateThrowMessageEvent.Execute(context);
					break;
				case "GetAdminUnit_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "GetAdminUnit_ScriptTask";
					result = GetAdminUnit_ScriptTask.Execute(context, GetAdminUnit_ScriptTaskExecute);
					break;
				case "EventSubProcess4":
					context.QueueTasks.Dequeue();
					break;
				case "SysAdminUnitIPRangeSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitIPRangeSaving";
					result = SysAdminUnitIPRangeSaving.Execute(context);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool LogSave_ScriptTaskExecute(ProcessExecutingContext context) {
			var sysAdminUnitName = Entity.GetTypedColumnValue<string>(Entity.Schema.GetSchemaColumnByPath("SysAdminUnit").DisplayColumnValueName);
			var beginIP = Entity.GetTypedColumnValue<string>("BeginIP");
			var endIP = Entity.GetTypedColumnValue<string>("EndIP");
			OperationLogger.Instance.LogClientIPRangeEdit(UserConnection, sysAdminUnitName, beginIP, endIP);
			return true;
		}

		public virtual bool LogDelete_ScriptTaskExecute(ProcessExecutingContext context) {
			var beginIP = Entity.GetTypedColumnValue<string>("BeginIP");
			var endIP = Entity.GetTypedColumnValue<string>("EndIP");
			OperationLogger.Instance.LogClientIPRangeDelete(UserConnection, AdminUnitName, beginIP, endIP);
			return true;
		}

		public virtual bool GetAdminUnit_ScriptTaskExecute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			var ipRangeId = Entity.GetTypedColumnValue<Guid>("Id");
			var selectAdminUnitId = 
				new Select(UserConnection)
					.Column("SysAdminUnitId")
				.From("SysAdminUnitIPRange")
				.Where("Id").IsEqual(Column.Parameter(ipRangeId)) as Select;
			var selectAdminName = 
				new Select(UserConnection)
					.Column("Name")
				.From("SysAdminUnit")
				.Where("Id").IsEqual(selectAdminUnitId) as Select;
			AdminUnitName = selectAdminName.ExecuteScalar<string>();
			return true;
		}

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysAdminUnitIPRangeSaved":
							if (ActivatedEventElements.Contains("SysAdminUnitIPRangeSaved_StartMessage")) {
							context.QueueTasks.Enqueue("SysAdminUnitIPRangeSaved_StartMessage");
						}
						break;
					case "SysAdminUnitIPRangeDeleted":
							if (ActivatedEventElements.Contains("SysAdminUnitIPRangeDeleted_StartMessage")) {
							context.QueueTasks.Enqueue("SysAdminUnitIPRangeDeleted_StartMessage");
						}
						break;
					case "SysAdminUnitIPRangeDeleting":
							if (ActivatedEventElements.Contains("SysAdminUnitIPRangeDeleting_StartMessage")) {
							context.QueueTasks.Enqueue("SysAdminUnitIPRangeDeleting_StartMessage");
						}
						break;
					case "SysAdminUnitIPRangeSaving":
							if (ActivatedEventElements.Contains("SysAdminUnitIPRangeSaving")) {
							context.QueueTasks.Enqueue("SysAdminUnitIPRangeSaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitIPRange_BaseEventsProcess

	/// <exclude/>
	public class SysAdminUnitIPRange_BaseEventsProcess : SysAdminUnitIPRange_BaseEventsProcess<SysAdminUnitIPRange>
	{

		public SysAdminUnitIPRange_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminUnitIPRange_BaseEventsProcess

	public partial class SysAdminUnitIPRange_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAdminUnitIPRangeEventsProcess

	/// <exclude/>
	public class SysAdminUnitIPRangeEventsProcess : SysAdminUnitIPRange_BaseEventsProcess
	{

		public SysAdminUnitIPRangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

