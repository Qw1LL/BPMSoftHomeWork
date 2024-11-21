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

	#region Class: ProblemInCaseSchema

	/// <exclude/>
	public class ProblemInCaseSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProblemInCaseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProblemInCaseSchema(ProblemInCaseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProblemInCaseSchema(ProblemInCaseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fb6dab95-e48a-425d-8131-aa6eb0a63da7");
			RealUId = new Guid("fb6dab95-e48a-425d-8131-aa6eb0a63da7");
			Name = "ProblemInCase";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c33fea4-8dbf-4aca-bdb3-74630a448d22");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("66aa964a-d680-4bf5-b83f-b4e80dd16cc3")) == null) {
				Columns.Add(CreateCaseColumn());
			}
			if (Columns.FindByUId(new Guid("3eff4921-de34-47d7-8db8-772caac9ffe8")) == null) {
				Columns.Add(CreateProblemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("66aa964a-d680-4bf5-b83f-b4e80dd16cc3"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fb6dab95-e48a-425d-8131-aa6eb0a63da7"),
				ModifiedInSchemaUId = new Guid("fb6dab95-e48a-425d-8131-aa6eb0a63da7"),
				CreatedInPackageId = new Guid("3c33fea4-8dbf-4aca-bdb3-74630a448d22")
			};
		}

		protected virtual EntitySchemaColumn CreateProblemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3eff4921-de34-47d7-8db8-772caac9ffe8"),
				Name = @"Problem",
				ReferenceSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fb6dab95-e48a-425d-8131-aa6eb0a63da7"),
				ModifiedInSchemaUId = new Guid("fb6dab95-e48a-425d-8131-aa6eb0a63da7"),
				CreatedInPackageId = new Guid("3c33fea4-8dbf-4aca-bdb3-74630a448d22")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProblemInCase(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProblemInCase_ProblemEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProblemInCaseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProblemInCaseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fb6dab95-e48a-425d-8131-aa6eb0a63da7"));
		}

		#endregion

	}

	#endregion

	#region Class: ProblemInCase

	/// <summary>
	/// Проблема в обращении.
	/// </summary>
	public class ProblemInCase : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProblemInCase(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProblemInCase";
		}

		public ProblemInCase(ProblemInCase source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		/// <exclude/>
		public Guid ProblemId {
			get {
				return GetTypedColumnValue<Guid>("ProblemId");
			}
			set {
				SetColumnValue("ProblemId", value);
				_problem = null;
			}
		}

		/// <exclude/>
		public string ProblemNumber {
			get {
				return GetTypedColumnValue<string>("ProblemNumber");
			}
			set {
				SetColumnValue("ProblemNumber", value);
				if (_problem != null) {
					_problem.Number = value;
				}
			}
		}

		private Problem _problem;
		/// <summary>
		/// Проблема.
		/// </summary>
		public Problem Problem {
			get {
				return _problem ??
					(_problem = LookupColumnEntities.GetEntity("Problem") as Problem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProblemInCase_ProblemEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProblemInCaseDeleted", e);
			Saved += (s, e) => ThrowEvent("ProblemInCaseSaved", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProblemInCase(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProblemInCase_ProblemEventsProcess

	/// <exclude/>
	public partial class ProblemInCase_ProblemEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ProblemInCase
	{

		public ProblemInCase_ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProblemInCase_ProblemEventsProcess";
			SchemaUId = new Guid("fb6dab95-e48a-425d-8131-aa6eb0a63da7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fb6dab95-e48a-425d-8131-aa6eb0a63da7");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_3ea87d9f46474996b971e9667a407d8a;
		public ProcessFlowElement EventSubProcess3_3ea87d9f46474996b971e9667a407d8a {
			get {
				return _eventSubProcess3_3ea87d9f46474996b971e9667a407d8a ?? (_eventSubProcess3_3ea87d9f46474996b971e9667a407d8a = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_3ea87d9f46474996b971e9667a407d8a",
					SchemaElementUId = new Guid("3ea87d9f-4647-4996-b971-e9667a407d8a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _problemInCaseSavedMessage;
		public ProcessFlowElement ProblemInCaseSavedMessage {
			get {
				return _problemInCaseSavedMessage ?? (_problemInCaseSavedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ProblemInCaseSavedMessage",
					SchemaElementUId = new Guid("10ef34d8-b4a3-4d4f-b3d2-3e21bc1b228a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updateCaseScriptTask;
		public ProcessScriptTask UpdateCaseScriptTask {
			get {
				return _updateCaseScriptTask ?? (_updateCaseScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateCaseScriptTask",
					SchemaElementUId = new Guid("9ef8ce3a-0d2b-4ee6-a63b-13fb52d8debe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateCaseScriptTaskExecute,
				});
			}
		}

		private ProcessThrowMessageEvent _parentBaseEntitySaved;
		public ProcessThrowMessageEvent ParentBaseEntitySaved {
			get {
				return _parentBaseEntitySaved ?? (_parentBaseEntitySaved = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "ParentBaseEntitySaved",
					SchemaElementUId = new Guid("3bf1ecb5-4197-4476-9e16-b3f2c2fb3869"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "BaseEntitySaved",
						ThrowToBase = true,
				});
			}
		}

		private ProcessFlowElement _problemInCaseDeletedEventSubProcess;
		public ProcessFlowElement ProblemInCaseDeletedEventSubProcess {
			get {
				return _problemInCaseDeletedEventSubProcess ?? (_problemInCaseDeletedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ProblemInCaseDeletedEventSubProcess",
					SchemaElementUId = new Guid("e62c02f6-c874-43b5-83e2-5247eb07f5bc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _problemInCaseDeletedMessage;
		public ProcessFlowElement ProblemInCaseDeletedMessage {
			get {
				return _problemInCaseDeletedMessage ?? (_problemInCaseDeletedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ProblemInCaseDeletedMessage",
					SchemaElementUId = new Guid("0f1889fa-8558-4c67-9be7-8d7c773267bc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updateProblemInCaseScript;
		public ProcessScriptTask UpdateProblemInCaseScript {
			get {
				return _updateProblemInCaseScript ?? (_updateProblemInCaseScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateProblemInCaseScript",
					SchemaElementUId = new Guid("9c2a46d7-376c-4e66-a59b-9c6de90b3c29"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateProblemInCaseScriptExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_3ea87d9f46474996b971e9667a407d8a.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_3ea87d9f46474996b971e9667a407d8a };
			FlowElements[ProblemInCaseSavedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ProblemInCaseSavedMessage };
			FlowElements[UpdateCaseScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateCaseScriptTask };
			FlowElements[ParentBaseEntitySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ParentBaseEntitySaved };
			FlowElements[ProblemInCaseDeletedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ProblemInCaseDeletedEventSubProcess };
			FlowElements[ProblemInCaseDeletedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ProblemInCaseDeletedMessage };
			FlowElements[UpdateProblemInCaseScript.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateProblemInCaseScript };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_3ea87d9f46474996b971e9667a407d8a":
						break;
					case "ProblemInCaseSavedMessage":
						e.Context.QueueTasks.Enqueue("UpdateCaseScriptTask");
						break;
					case "UpdateCaseScriptTask":
						e.Context.QueueTasks.Enqueue("ParentBaseEntitySaved");
						break;
					case "ParentBaseEntitySaved":
						break;
					case "ProblemInCaseDeletedEventSubProcess":
						break;
					case "ProblemInCaseDeletedMessage":
						e.Context.QueueTasks.Enqueue("UpdateProblemInCaseScript");
						break;
					case "UpdateProblemInCaseScript":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ProblemInCaseSavedMessage");
			ActivatedEventElements.Add("ProblemInCaseDeletedMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_3ea87d9f46474996b971e9667a407d8a":
					context.QueueTasks.Dequeue();
					break;
				case "ProblemInCaseSavedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProblemInCaseSavedMessage";
					result = ProblemInCaseSavedMessage.Execute(context);
					break;
				case "UpdateCaseScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateCaseScriptTask";
					result = UpdateCaseScriptTask.Execute(context, UpdateCaseScriptTaskExecute);
					break;
				case "ParentBaseEntitySaved":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "BaseEntitySaved");
					result = ParentBaseEntitySaved.Execute(context);
					break;
				case "ProblemInCaseDeletedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ProblemInCaseDeletedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProblemInCaseDeletedMessage";
					result = ProblemInCaseDeletedMessage.Execute(context);
					break;
				case "UpdateProblemInCaseScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateProblemInCaseScript";
					result = UpdateProblemInCaseScript.Execute(context, UpdateProblemInCaseScriptExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool UpdateCaseScriptTaskExecute(ProcessExecutingContext context) {
			if (Entity.IsColumnValueLoaded("CaseId") && Entity.IsColumnValueLoaded("ProblemId")){
				var caseId = Entity.GetTypedColumnValue<Guid>("CaseId");
				var problemId = Entity.GetTypedColumnValue<Guid>("ProblemId");
				var caseEntity = UserConnection.EntitySchemaManager.GetInstanceByName("Case").CreateEntity(UserConnection);
				if (caseEntity.FetchFromDB(caseId)){
					caseEntity.SetColumnValue("ProblemId", problemId);
					caseEntity.Save(false);
				}
			}
			return true;
		}

		public virtual bool UpdateProblemInCaseScriptExecute(ProcessExecutingContext context) {
			if (Entity.IsColumnValueLoaded("CaseId")){
				var caseId = Entity.GetTypedColumnValue<Guid>("CaseId");
				var caseEntity = UserConnection.EntitySchemaManager.GetInstanceByName("Case").CreateEntity(UserConnection);
				if (caseEntity.FetchFromDB(caseId)){
					Guid? actualProblemId = GetLastProblemAddedToCase(caseId);
					caseEntity.SetColumnValue("ProblemId", actualProblemId);
					caseEntity.Save(false);
				}
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ProblemInCaseSaved":
							if (ActivatedEventElements.Contains("ProblemInCaseSavedMessage")) {
							context.QueueTasks.Enqueue("ProblemInCaseSavedMessage");
						}
						break;
					case "ProblemInCaseDeleted":
							if (ActivatedEventElements.Contains("ProblemInCaseDeletedMessage")) {
							context.QueueTasks.Enqueue("ProblemInCaseDeletedMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ProblemInCase_ProblemEventsProcess

	/// <exclude/>
	public class ProblemInCase_ProblemEventsProcess : ProblemInCase_ProblemEventsProcess<ProblemInCase>
	{

		public ProblemInCase_ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProblemInCase_ProblemEventsProcess

	public partial class ProblemInCase_ProblemEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual Guid? GetLastProblemAddedToCase(Guid caseId) {
			Guid? actualProblemId = null;
			if (caseId != Guid.Empty){
				Select select = new Select(UserConnection)
							.Column("ProblemId")
							.From("ProblemInCase")
							.Top(1)
							.Where("CaseId")
							.IsEqual(Column.Parameter(caseId))
							.OrderByDesc("CreatedOn") as Select;
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
						while (reader.Read()) {
							actualProblemId = reader.GetColumnValue<Guid>("ProblemId");
						}
					}
				}
			}
			return actualProblemId;
		}

		#endregion

	}

	#endregion


	#region Class: ProblemInCaseEventsProcess

	/// <exclude/>
	public class ProblemInCaseEventsProcess : ProblemInCase_ProblemEventsProcess
	{

		public ProblemInCaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

