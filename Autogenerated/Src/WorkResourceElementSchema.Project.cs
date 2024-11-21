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

	#region Class: WorkResourceElementSchema

	/// <exclude/>
	public class WorkResourceElementSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WorkResourceElementSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WorkResourceElementSchema(WorkResourceElementSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WorkResourceElementSchema(WorkResourceElementSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb");
			RealUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb");
			Name = "WorkResourceElement";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ac209bd7-cd6c-436f-8880-b9f73a173b09")) == null) {
				Columns.Add(CreateProjectColumn());
			}
			if (Columns.FindByUId(new Guid("d5abdcd4-070e-4aa0-9f63-cd2461c93de6")) == null) {
				Columns.Add(CreateProjectResourceElementColumn());
			}
			if (Columns.FindByUId(new Guid("c984dfb3-7e35-4f08-8a24-f89757ad3b78")) == null) {
				Columns.Add(CreatePlanningWorkColumn());
			}
			if (Columns.FindByUId(new Guid("cc0f4ccc-ea7e-4152-9a5e-3a03ef43e0a5")) == null) {
				Columns.Add(CreateActualWorkColumn());
			}
			if (Columns.FindByUId(new Guid("883e51c0-723c-40c2-9d2b-b21b29ecc4de")) == null) {
				Columns.Add(CreateExternalRateColumn());
			}
			if (Columns.FindByUId(new Guid("42b5251c-dd69-4d44-9eb8-e6a342ab0611")) == null) {
				Columns.Add(CreateInternalRateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ac209bd7-cd6c-436f-8880-b9f73a173b09"),
				Name = @"Project",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateProjectResourceElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d5abdcd4-070e-4aa0-9f63-cd2461c93de6"),
				Name = @"ProjectResourceElement",
				ReferenceSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanningWorkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("c984dfb3-7e35-4f08-8a24-f89757ad3b78"),
				Name = @"PlanningWork",
				CreatedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateActualWorkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("cc0f4ccc-ea7e-4152-9a5e-3a03ef43e0a5"),
				Name = @"ActualWork",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateExternalRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("883e51c0-723c-40c2-9d2b-b21b29ecc4de"),
				Name = @"ExternalRate",
				CreatedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				CreatedInPackageId = new Guid("61c8641f-c044-4b81-ab30-bcda839818c3")
			};
		}

		protected virtual EntitySchemaColumn CreateInternalRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("42b5251c-dd69-4d44-9eb8-e6a342ab0611"),
				Name = @"InternalRate",
				CreatedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				ModifiedInSchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"),
				CreatedInPackageId = new Guid("61c8641f-c044-4b81-ab30-bcda839818c3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WorkResourceElement(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WorkResourceElement_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WorkResourceElementSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WorkResourceElementSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb"));
		}

		#endregion

	}

	#endregion

	#region Class: WorkResourceElement

	/// <summary>
	/// Элемент ресурсов работы.
	/// </summary>
	public class WorkResourceElement : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WorkResourceElement(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WorkResourceElement";
		}

		public WorkResourceElement(WorkResourceElement source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProjectId {
			get {
				return GetTypedColumnValue<Guid>("ProjectId");
			}
			set {
				SetColumnValue("ProjectId", value);
				_project = null;
			}
		}

		/// <exclude/>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
				if (_project != null) {
					_project.Name = value;
				}
			}
		}

		private Project _project;
		/// <summary>
		/// Проект.
		/// </summary>
		public Project Project {
			get {
				return _project ??
					(_project = LookupColumnEntities.GetEntity("Project") as Project);
			}
		}

		/// <exclude/>
		public Guid ProjectResourceElementId {
			get {
				return GetTypedColumnValue<Guid>("ProjectResourceElementId");
			}
			set {
				SetColumnValue("ProjectResourceElementId", value);
				_projectResourceElement = null;
			}
		}

		/// <exclude/>
		public string ProjectResourceElementName {
			get {
				return GetTypedColumnValue<string>("ProjectResourceElementName");
			}
			set {
				SetColumnValue("ProjectResourceElementName", value);
				if (_projectResourceElement != null) {
					_projectResourceElement.Name = value;
				}
			}
		}

		private ProjectResourceElement _projectResourceElement;
		/// <summary>
		/// Ресурс.
		/// </summary>
		public ProjectResourceElement ProjectResourceElement {
			get {
				return _projectResourceElement ??
					(_projectResourceElement = LookupColumnEntities.GetEntity("ProjectResourceElement") as ProjectResourceElement);
			}
		}

		/// <summary>
		/// План. трудозатраты, ч.
		/// </summary>
		public Decimal PlanningWork {
			get {
				return GetTypedColumnValue<Decimal>("PlanningWork");
			}
			set {
				SetColumnValue("PlanningWork", value);
			}
		}

		/// <summary>
		/// Фактические трудозатраты, ч.
		/// </summary>
		public Decimal ActualWork {
			get {
				return GetTypedColumnValue<Decimal>("ActualWork");
			}
			set {
				SetColumnValue("ActualWork", value);
			}
		}

		/// <summary>
		/// Внешняя ставка, б.в.
		/// </summary>
		public Decimal ExternalRate {
			get {
				return GetTypedColumnValue<Decimal>("ExternalRate");
			}
			set {
				SetColumnValue("ExternalRate", value);
			}
		}

		/// <summary>
		/// Внутренняя стоимость, б.в.
		/// </summary>
		public Decimal InternalRate {
			get {
				return GetTypedColumnValue<Decimal>("InternalRate");
			}
			set {
				SetColumnValue("InternalRate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WorkResourceElement_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WorkResourceElementDeleted", e);
			Deleting += (s, e) => ThrowEvent("WorkResourceElementDeleting", e);
			Inserting += (s, e) => ThrowEvent("WorkResourceElementInserting", e);
			Saved += (s, e) => ThrowEvent("WorkResourceElementSaved", e);
			Validating += (s, e) => ThrowEvent("WorkResourceElementValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WorkResourceElement(this);
		}

		#endregion

	}

	#endregion

	#region Class: WorkResourceElement_ProjectEventsProcess

	/// <exclude/>
	public partial class WorkResourceElement_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : WorkResourceElement
	{

		public WorkResourceElement_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WorkResourceElement_ProjectEventsProcess";
			SchemaUId = new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("63e01d26-170e-4b48-bcad-6a275f2276bb");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid ProjectResourceElementId {
			get;
			set;
		}

		public virtual Guid ProjectId {
			get;
			set;
		}

		private bool _isWorkResourceDeleted = false;
		public bool IsWorkResourceDeleted {
			get {
				return _isWorkResourceDeleted;
			}
			set {
				_isWorkResourceDeleted = value;
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
					SchemaElementUId = new Guid("a32a90f0-9b16-46a2-8663-29c9327d1db4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _workResourceElementDeleting;
		public ProcessFlowElement WorkResourceElementDeleting {
			get {
				return _workResourceElementDeleting ?? (_workResourceElementDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "WorkResourceElementDeleting",
					SchemaElementUId = new Guid("b6be68e7-0128-40f2-b3d3-88f9b612852e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _workResourceElementDeletedScriptTask;
		public ProcessScriptTask WorkResourceElementDeletedScriptTask {
			get {
				return _workResourceElementDeletedScriptTask ?? (_workResourceElementDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "WorkResourceElementDeletedScriptTask",
					SchemaElementUId = new Guid("68fe3975-6e7a-4435-bcb6-707bf26fad5b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = WorkResourceElementDeletedScriptTaskExecute,
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
					SchemaElementUId = new Guid("cf091e89-59bf-4236-870a-3f3235e3ea24"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _workResourceElementSaved;
		public ProcessFlowElement WorkResourceElementSaved {
			get {
				return _workResourceElementSaved ?? (_workResourceElementSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "WorkResourceElementSaved",
					SchemaElementUId = new Guid("6b65bbc9-8e75-4133-ab68-b85768dc8907"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _prepareWorkResourceElementSavedScriptTask;
		public ProcessScriptTask PrepareWorkResourceElementSavedScriptTask {
			get {
				return _prepareWorkResourceElementSavedScriptTask ?? (_prepareWorkResourceElementSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareWorkResourceElementSavedScriptTask",
					SchemaElementUId = new Guid("dfca4607-3ff3-4f06-ba70-5ddcaa7d52b6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PrepareWorkResourceElementSavedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _workResourceElementDeleted;
		public ProcessFlowElement WorkResourceElementDeleted {
			get {
				return _workResourceElementDeleted ?? (_workResourceElementDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "WorkResourceElementDeleted",
					SchemaElementUId = new Guid("4c32a242-e1a7-499f-89ba-44b9ba00fec2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _workResourceElementSavedScriptTask;
		public ProcessScriptTask WorkResourceElementSavedScriptTask {
			get {
				return _workResourceElementSavedScriptTask ?? (_workResourceElementSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "WorkResourceElementSavedScriptTask",
					SchemaElementUId = new Guid("ed9ac42c-98a1-40f2-8710-35a8ab6292eb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = WorkResourceElementSavedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[WorkResourceElementDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { WorkResourceElementDeleting };
			FlowElements[WorkResourceElementDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { WorkResourceElementDeletedScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[WorkResourceElementSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { WorkResourceElementSaved };
			FlowElements[PrepareWorkResourceElementSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareWorkResourceElementSavedScriptTask };
			FlowElements[WorkResourceElementDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { WorkResourceElementDeleted };
			FlowElements[WorkResourceElementSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { WorkResourceElementSavedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "WorkResourceElementDeleting":
						e.Context.QueueTasks.Enqueue("WorkResourceElementDeletedScriptTask");
						break;
					case "WorkResourceElementDeletedScriptTask":
						break;
					case "EventSubProcess2":
						break;
					case "WorkResourceElementSaved":
						e.Context.QueueTasks.Enqueue("PrepareWorkResourceElementSavedScriptTask");
						break;
					case "PrepareWorkResourceElementSavedScriptTask":
						e.Context.QueueTasks.Enqueue("WorkResourceElementSavedScriptTask");
						break;
					case "WorkResourceElementDeleted":
						e.Context.QueueTasks.Enqueue("WorkResourceElementSavedScriptTask");
						break;
					case "WorkResourceElementSavedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("WorkResourceElementDeleting");
			ActivatedEventElements.Add("WorkResourceElementSaved");
			ActivatedEventElements.Add("WorkResourceElementDeleted");
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
				case "WorkResourceElementDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "WorkResourceElementDeleting";
					result = WorkResourceElementDeleting.Execute(context);
					break;
				case "WorkResourceElementDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "WorkResourceElementDeletedScriptTask";
					result = WorkResourceElementDeletedScriptTask.Execute(context, WorkResourceElementDeletedScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "WorkResourceElementSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "WorkResourceElementSaved";
					result = WorkResourceElementSaved.Execute(context);
					break;
				case "PrepareWorkResourceElementSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PrepareWorkResourceElementSavedScriptTask";
					result = PrepareWorkResourceElementSavedScriptTask.Execute(context, PrepareWorkResourceElementSavedScriptTaskExecute);
					break;
				case "WorkResourceElementDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "WorkResourceElementDeleted";
					result = WorkResourceElementDeleted.Execute(context);
					break;
				case "WorkResourceElementSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "WorkResourceElementSavedScriptTask";
					result = WorkResourceElementSavedScriptTask.Execute(context, WorkResourceElementSavedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool WorkResourceElementDeletedScriptTaskExecute(ProcessExecutingContext context) {
			ProjectResourceElementId = Entity.GetTypedColumnValue<Guid>("ProjectResourceElementId");
			ProjectId = Entity.GetTypedColumnValue<Guid>("ProjectId");
			IsWorkResourceDeleted = true;
			return true;
		}

		public virtual bool PrepareWorkResourceElementSavedScriptTaskExecute(ProcessExecutingContext context) {
			ProjectResourceElementId = Entity.GetTypedColumnValue<Guid>("ProjectResourceElementId");
			ProjectId = Entity.GetTypedColumnValue<Guid>("ProjectId");
			return true;
		}

		public virtual bool WorkResourceElementSavedScriptTaskExecute(ProcessExecutingContext context) {
			return OnWorkResourceElementSaved(ProjectResourceElementId, ProjectId);
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "WorkResourceElementDeleting":
							if (ActivatedEventElements.Contains("WorkResourceElementDeleting")) {
							context.QueueTasks.Enqueue("WorkResourceElementDeleting");
						}
						break;
					case "WorkResourceElementSaved":
							if (ActivatedEventElements.Contains("WorkResourceElementSaved")) {
							context.QueueTasks.Enqueue("WorkResourceElementSaved");
						}
						break;
					case "WorkResourceElementDeleted":
							if (ActivatedEventElements.Contains("WorkResourceElementDeleted")) {
							context.QueueTasks.Enqueue("WorkResourceElementDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: WorkResourceElement_ProjectEventsProcess

	/// <exclude/>
	public class WorkResourceElement_ProjectEventsProcess : WorkResourceElement_ProjectEventsProcess<WorkResourceElement>
	{

		public WorkResourceElement_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WorkResourceElement_ProjectEventsProcess

	public partial class WorkResourceElement_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void LaborPlanWorkResourceElementUpdate(Guid projectId, Guid projectResourceElementId, decimal planningWork) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var workResourceElementSchema = entitySchemaManager.GetInstanceByName("WorkResourceElement");
			var esq = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
			var esqIdColumn = esq.AddColumn("Id");
			var esqPlanningWorkColumn = esq.AddColumn("PlanningWork");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", projectId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ProjectResourceElement", projectResourceElementId));
			var entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				foreach(var entity in entities) {
					var elementId = entity.GetTypedColumnValue<Guid>(esqIdColumn.Name);
					var work = entity.GetTypedColumnValue<decimal>(esqPlanningWorkColumn.Name);
					if (work < planningWork || (IsWorkResourceDeleted && projectResourceElementId == ProjectResourceElementId)) {
						var entityToSave = workResourceElementSchema.CreateEntity(UserConnection);
						if (entityToSave.FetchFromDB(workResourceElementSchema.GetPrimaryColumnName(), elementId)) {
							entityToSave.SetColumnValue("PlanningWork", planningWork);
							entityToSave.Save();
						}
					}
				}
			} else {
			//	var esqProjectRes = new EntitySchemaQuery(entitySchemaManager, "ProjectResourceElement");
			//	var esqExternalRateColumn = esqProjectRes.AddColumn("ExternalRate");
			//	var esqInternalRateColumn = esqProjectRes.AddColumn("InternalRate");
			//	var projectResourceEntity = esqProjectRes.GetEntity(UserConnection, projectResourceElementId);
			//	if (projectResourceEntity != null) {
			//		var externalRate = projectResourceEntity.GetTypedColumnValue<decimal>(esqExternalRateColumn.Name);
			//		var internalRate = projectResourceEntity.GetTypedColumnValue<decimal>(esqInternalRateColumn.Name);
					var newEntity = workResourceElementSchema.CreateEntity(UserConnection);
					newEntity.SetDefColumnValues();
					newEntity.SetColumnValue("ProjectId", projectId);
					newEntity.SetColumnValue("ProjectResourceElementId", projectResourceElementId);
			//		newEntity.SetColumnValue("ExternalRate", externalRate);
			//		newEntity.SetColumnValue("InternalRate", internalRate);
					newEntity.SetColumnValue("PlanningWork", planningWork);
					newEntity.Save(); 
			//	}
			}
		}

		public virtual bool OnWorkResourceElementSaved(Guid elementId, Guid prjctId) {
			if (elementId != null && elementId != Guid.Empty) {
				var esqProject = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Project");
				var parentProjectIdColumn = esqProject.AddColumn("ParentProject.Id");
				var projectEntryTypeIdColumn = esqProject.AddColumn("ParentProject.ProjectEntryType.Id");
				var parentProjectId = Guid.Empty;
				var projectEntryTypeId = Guid.Empty;
				
				var project = esqProject.GetEntity(UserConnection, prjctId);
				if (project == null) {
					return true;
				}
				parentProjectId = project.GetTypedColumnValue<Guid>(parentProjectIdColumn.Name);
				projectEntryTypeId = project.GetTypedColumnValue<Guid>(projectEntryTypeIdColumn.Name);
				var planCollection = new Dictionary<Guid, decimal>();
				var esqManhour = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkResourceElement");
				var planColumn = esqManhour.AddColumn("PlanningWork");
				var projectResourceColumn = esqManhour.AddColumn("ProjectResourceElement.Id");
				var projectManhourFilter = esqManhour.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Project.ParentProject", parentProjectId);
				esqManhour.Filters.Add(projectManhourFilter);
				var manhourEntities = esqManhour.GetEntityCollection(UserConnection);
				if (manhourEntities.Count > 0) {
					foreach(var manhourEntity in manhourEntities) {
						var plan = manhourEntity.GetTypedColumnValue<decimal>(planColumn.Name);
						var projectResourceId = manhourEntity.GetTypedColumnValue<Guid>(projectResourceColumn.Name);
						if (planCollection.ContainsKey(projectResourceId)) {
							planCollection[projectResourceId] += plan;
						} else {
							planCollection.Add(projectResourceId, plan);
						}
					}
				}
				if (projectEntryTypeId == new Guid("6B4928D7-456A-4ACD-A863-3361D46B7649")) {
					var projectService = new BPMSoft.Configuration.ProjectService.ProjectService();
					projectService.UpdateProjectResource(parentProjectId);
				} else {
					foreach(var plan in planCollection) {
						LaborPlanWorkResourceElementUpdate(parentProjectId, plan.Key, plan.Value); 
					}
				}
			}
			return true;
		}

		#endregion

	}

	#endregion


	#region Class: WorkResourceElementEventsProcess

	/// <exclude/>
	public class WorkResourceElementEventsProcess : WorkResourceElement_ProjectEventsProcess
	{

		public WorkResourceElementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

