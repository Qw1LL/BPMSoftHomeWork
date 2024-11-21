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

	#region Class: VwSysEntitySchemaColumnRightSchema

	/// <exclude/>
	public class VwSysEntitySchemaColumnRightSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysEntitySchemaColumnRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysEntitySchemaColumnRightSchema(VwSysEntitySchemaColumnRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysEntitySchemaColumnRightSchema(VwSysEntitySchemaColumnRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555");
			RealUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555");
			Name = "VwSysEntitySchemaColumnRight";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4e633c16-e807-4873-9c46-375d376d0a2a")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("4d7ac7e2-9285-462a-b942-b8ae69d229ea")) == null) {
				Columns.Add(CreateRightLevelColumn());
			}
			if (Columns.FindByUId(new Guid("90af7c81-0689-48a8-83fb-3ecaeba22b7f")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("6bae586e-5d9c-4484-b8d0-5c9a59f3bfb9")) == null) {
				Columns.Add(CreateSubjectColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("c55f4107-514d-4fe3-8ed6-f56e272c31a7")) == null) {
				Columns.Add(CreateSubjectSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4e633c16-e807-4873-9c46-375d376d0a2a"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"),
				ModifiedInSchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected virtual EntitySchemaColumn CreateRightLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4d7ac7e2-9285-462a-b942-b8ae69d229ea"),
				Name = @"RightLevel",
				ReferenceSchemaUId = new Guid("f77c0b8d-14db-43fc-b3ad-db3c815140a0"),
				CreatedInSchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"),
				ModifiedInSchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("90af7c81-0689-48a8-83fb-3ecaeba22b7f"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"),
				ModifiedInSchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6bae586e-5d9c-4484-b8d0-5c9a59f3bfb9"),
				Name = @"SubjectColumnUId",
				CreatedInSchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"),
				ModifiedInSchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c55f4107-514d-4fe3-8ed6-f56e272c31a7"),
				Name = @"SubjectSchemaUId",
				CreatedInSchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"),
				ModifiedInSchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysEntitySchemaColumnRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysEntitySchemaColumnRight_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysEntitySchemaColumnRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysEntitySchemaColumnRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f302c13d-4a72-483f-9744-345f6b0eb555"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysEntitySchemaColumnRight

	/// <summary>
	/// Columns permissions (view).
	/// </summary>
	public class VwSysEntitySchemaColumnRight : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysEntitySchemaColumnRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysEntitySchemaColumnRight";
		}

		public VwSysEntitySchemaColumnRight(VwSysEntitySchemaColumnRight source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		private VwSysAdminUnit _sysAdminUnit;
		/// <summary>
		/// User/role.
		/// </summary>
		public VwSysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as VwSysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid RightLevelId {
			get {
				return GetTypedColumnValue<Guid>("RightLevelId");
			}
			set {
				SetColumnValue("RightLevelId", value);
				_rightLevel = null;
			}
		}

		/// <exclude/>
		public string RightLevelName {
			get {
				return GetTypedColumnValue<string>("RightLevelName");
			}
			set {
				SetColumnValue("RightLevelName", value);
				if (_rightLevel != null) {
					_rightLevel.Name = value;
				}
			}
		}

		private SysEntitySchemaColRightLevel _rightLevel;
		/// <summary>
		/// Access level.
		/// </summary>
		public SysEntitySchemaColRightLevel RightLevel {
			get {
				return _rightLevel ??
					(_rightLevel = LookupColumnEntities.GetEntity("RightLevel") as SysEntitySchemaColRightLevel);
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

		/// <summary>
		/// Column.
		/// </summary>
		public Guid SubjectColumnUId {
			get {
				return GetTypedColumnValue<Guid>("SubjectColumnUId");
			}
			set {
				SetColumnValue("SubjectColumnUId", value);
			}
		}

		/// <summary>
		/// Object.
		/// </summary>
		public Guid SubjectSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SubjectSchemaUId");
			}
			set {
				SetColumnValue("SubjectSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysEntitySchemaColumnRight_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysEntitySchemaColumnRightDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysEntitySchemaColumnRightDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysEntitySchemaColumnRightInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysEntitySchemaColumnRightInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysEntitySchemaColumnRightSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysEntitySchemaColumnRightSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysEntitySchemaColumnRightValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysEntitySchemaColumnRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysEntitySchemaColumnRight_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysEntitySchemaColumnRight_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysEntitySchemaColumnRight
	{

		public VwSysEntitySchemaColumnRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysEntitySchemaColumnRight_BaseEventsProcess";
			SchemaUId = new Guid("f302c13d-4a72-483f-9744-345f6b0eb555");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f302c13d-4a72-483f-9744-345f6b0eb555");
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
					SchemaElementUId = new Guid("7dc55ddf-768e-43f5-929b-35c0bed0ed41"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwSysEntitySchemaColumnRightDeleting_StartMessage;
		public ProcessFlowElement VwSysEntitySchemaColumnRightDeleting_StartMessage {
			get {
				return _vwSysEntitySchemaColumnRightDeleting_StartMessage ?? (_vwSysEntitySchemaColumnRightDeleting_StartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysEntitySchemaColumnRightDeleting_StartMessage",
					SchemaElementUId = new Guid("077ce5c9-cb9b-4f2b-b264-bae3d8077126"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _vwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent VwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent {
			get {
				return _vwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent ?? (_vwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "VwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("35db4659-08ec-4f12-9412-28cf20b0dd0d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "VwSysEntitySchemaColumnRightDeleting",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _prepareDataLogDelete_ScriptTask;
		public ProcessScriptTask PrepareDataLogDelete_ScriptTask {
			get {
				return _prepareDataLogDelete_ScriptTask ?? (_prepareDataLogDelete_ScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareDataLogDelete_ScriptTask",
					SchemaElementUId = new Guid("040c1776-93f0-4d25-ad79-47b5cc15cf86"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PrepareDataLogDelete_ScriptTaskExecute,
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
					SchemaElementUId = new Guid("0706dc68-b5d6-4f5e-8973-066289d286dc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwSysEntitySchemaColumnRightDeleted_StartMessage;
		public ProcessFlowElement VwSysEntitySchemaColumnRightDeleted_StartMessage {
			get {
				return _vwSysEntitySchemaColumnRightDeleted_StartMessage ?? (_vwSysEntitySchemaColumnRightDeleted_StartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysEntitySchemaColumnRightDeleted_StartMessage",
					SchemaElementUId = new Guid("3bd5234f-61db-42fe-9802-53b9f4367096"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _vwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent VwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent {
			get {
				return _vwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent ?? (_vwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "VwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("908c2bcd-aea5-4646-aaaa-31a31c620d84"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "VwSysEntitySchemaColumnRightDeleted",
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
					SchemaElementUId = new Guid("aabed8db-9f14-47eb-a6ba-15c861cb66bb"),
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
					SchemaElementUId = new Guid("23720d90-e233-4c61-975c-82f8890f8700"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwSysEntitySchemaColumnRightSaved_StartMessage;
		public ProcessFlowElement VwSysEntitySchemaColumnRightSaved_StartMessage {
			get {
				return _vwSysEntitySchemaColumnRightSaved_StartMessage ?? (_vwSysEntitySchemaColumnRightSaved_StartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysEntitySchemaColumnRightSaved_StartMessage",
					SchemaElementUId = new Guid("6750d03e-e76d-4339-a84b-419c3b9d5315"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _vwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent VwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent {
			get {
				return _vwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent ?? (_vwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "VwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("b92e64f2-5ea0-49fa-98a4-41e1fa99e65d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "VwSysEntitySchemaColumnRightSaved",
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
					SchemaElementUId = new Guid("240a9511-4bbd-4279-a8b4-ab1b5ad9a267"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = LogSave_ScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[VwSysEntitySchemaColumnRightDeleting_StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysEntitySchemaColumnRightDeleting_StartMessage };
			FlowElements[VwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent };
			FlowElements[PrepareDataLogDelete_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareDataLogDelete_ScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[VwSysEntitySchemaColumnRightDeleted_StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysEntitySchemaColumnRightDeleted_StartMessage };
			FlowElements[VwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent };
			FlowElements[LogDelete_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogDelete_ScriptTask };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[VwSysEntitySchemaColumnRightSaved_StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysEntitySchemaColumnRightSaved_StartMessage };
			FlowElements[VwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent };
			FlowElements[LogSave_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogSave_ScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "VwSysEntitySchemaColumnRightDeleting_StartMessage":
						e.Context.QueueTasks.Enqueue("PrepareDataLogDelete_ScriptTask");
						break;
					case "VwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent":
						break;
					case "PrepareDataLogDelete_ScriptTask":
						e.Context.QueueTasks.Enqueue("VwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent");
						break;
					case "EventSubProcess2":
						break;
					case "VwSysEntitySchemaColumnRightDeleted_StartMessage":
						e.Context.QueueTasks.Enqueue("LogDelete_ScriptTask");
						break;
					case "VwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent":
						break;
					case "LogDelete_ScriptTask":
						e.Context.QueueTasks.Enqueue("VwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent");
						break;
					case "EventSubProcess3":
						break;
					case "VwSysEntitySchemaColumnRightSaved_StartMessage":
						e.Context.QueueTasks.Enqueue("LogSave_ScriptTask");
						break;
					case "VwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent":
						break;
					case "LogSave_ScriptTask":
						e.Context.QueueTasks.Enqueue("VwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("VwSysEntitySchemaColumnRightDeleting_StartMessage");
			ActivatedEventElements.Add("VwSysEntitySchemaColumnRightDeleted_StartMessage");
			ActivatedEventElements.Add("VwSysEntitySchemaColumnRightSaved_StartMessage");
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
				case "VwSysEntitySchemaColumnRightDeleting_StartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysEntitySchemaColumnRightDeleting_StartMessage";
					result = VwSysEntitySchemaColumnRightDeleting_StartMessage.Execute(context);
					break;
				case "VwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "VwSysEntitySchemaColumnRightDeleting");
					result = VwSysEntitySchemaColumnRightDeleting_IntermediateThrowMessageEvent.Execute(context);
					break;
				case "PrepareDataLogDelete_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PrepareDataLogDelete_ScriptTask";
					result = PrepareDataLogDelete_ScriptTask.Execute(context, PrepareDataLogDelete_ScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "VwSysEntitySchemaColumnRightDeleted_StartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysEntitySchemaColumnRightDeleted_StartMessage";
					result = VwSysEntitySchemaColumnRightDeleted_StartMessage.Execute(context);
					break;
				case "VwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "VwSysEntitySchemaColumnRightDeleted");
					result = VwSysEntitySchemaColumnRightDeleted_IntermediateThrowMessageEvent.Execute(context);
					break;
				case "LogDelete_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LogDelete_ScriptTask";
					result = LogDelete_ScriptTask.Execute(context, LogDelete_ScriptTaskExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "VwSysEntitySchemaColumnRightSaved_StartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysEntitySchemaColumnRightSaved_StartMessage";
					result = VwSysEntitySchemaColumnRightSaved_StartMessage.Execute(context);
					break;
				case "VwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "VwSysEntitySchemaColumnRightSaved");
					result = VwSysEntitySchemaColumnRightSaved_IntermediateThrowMessageEvent.Execute(context);
					break;
				case "LogSave_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LogSave_ScriptTask";
					result = LogSave_ScriptTask.Execute(context, LogSave_ScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool PrepareDataLogDelete_ScriptTaskExecute(ProcessExecutingContext context) {
			AdminUnitName = Entity.GetTypedColumnValue<string>(Entity.Schema.GetSchemaColumnByPath("SysAdminUnit").DisplayColumnValueName);
			return true;
		}

		public virtual bool LogDelete_ScriptTaskExecute(ProcessExecutingContext context) {
			var schemaUId = Entity.GetTypedColumnValue<Guid>("SubjectSchemaUId");
			var columnUId = Entity.GetTypedColumnValue<Guid>("SubjectColumnUId");
			OperationLogger.Instance.LogEntitySchemaColumnRightDelete(UserConnection, AdminUnitName, schemaUId, columnUId);
			return true;
		}

		public virtual bool LogSave_ScriptTaskExecute(ProcessExecutingContext context) {
			var adminUnitName = Entity.GetTypedColumnValue<string>(Entity.Schema.GetSchemaColumnByPath("SysAdminUnit").DisplayColumnValueName);
			var schemaUId = Entity.GetTypedColumnValue<Guid>("SubjectSchemaUId");
			var columnUId = Entity.GetTypedColumnValue<Guid>("SubjectColumnUId");
			var rightLevelId = Entity.GetTypedColumnValue<Guid>(Entity.Schema.GetSchemaColumnByPath("RightLevel").ColumnValueName);
			var position = Entity.GetTypedColumnValue<int>("Position");
			OperationLogger.Instance.LogEntitySchemaColumnRightEdit(UserConnection, adminUnitName, schemaUId, columnUId, rightLevelId, position);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "VwSysEntitySchemaColumnRightDeleting":
							if (ActivatedEventElements.Contains("VwSysEntitySchemaColumnRightDeleting_StartMessage")) {
							context.QueueTasks.Enqueue("VwSysEntitySchemaColumnRightDeleting_StartMessage");
						}
						break;
					case "VwSysEntitySchemaColumnRightDeleted":
							if (ActivatedEventElements.Contains("VwSysEntitySchemaColumnRightDeleted_StartMessage")) {
							context.QueueTasks.Enqueue("VwSysEntitySchemaColumnRightDeleted_StartMessage");
						}
						break;
					case "VwSysEntitySchemaColumnRightSaved":
							if (ActivatedEventElements.Contains("VwSysEntitySchemaColumnRightSaved_StartMessage")) {
							context.QueueTasks.Enqueue("VwSysEntitySchemaColumnRightSaved_StartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysEntitySchemaColumnRight_BaseEventsProcess

	/// <exclude/>
	public class VwSysEntitySchemaColumnRight_BaseEventsProcess : VwSysEntitySchemaColumnRight_BaseEventsProcess<VwSysEntitySchemaColumnRight>
	{

		public VwSysEntitySchemaColumnRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysEntitySchemaColumnRight_BaseEventsProcess

	public partial class VwSysEntitySchemaColumnRight_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysEntitySchemaColumnRightEventsProcess

	/// <exclude/>
	public class VwSysEntitySchemaColumnRightEventsProcess : VwSysEntitySchemaColumnRight_BaseEventsProcess
	{

		public VwSysEntitySchemaColumnRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

