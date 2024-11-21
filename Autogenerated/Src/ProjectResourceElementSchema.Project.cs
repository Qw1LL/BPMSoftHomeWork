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

	#region Class: ProjectResourceElementSchema

	/// <exclude/>
	public class ProjectResourceElementSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProjectResourceElementSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProjectResourceElementSchema(ProjectResourceElementSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProjectResourceElementSchema(ProjectResourceElementSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44");
			RealUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44");
			Name = "ProjectResourceElement";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cad634f0-58b6-4367-8e5f-a88471349fe6")) == null) {
				Columns.Add(CreateProjectColumn());
			}
			if (Columns.FindByUId(new Guid("4ef6d535-6900-4bed-b25e-bc9f21ec8f51")) == null) {
				Columns.Add(CreateExternalRateColumn());
			}
			if (Columns.FindByUId(new Guid("5a690e50-642f-4e2d-a470-440cf68bc757")) == null) {
				Columns.Add(CreateInternalRateColumn());
			}
			if (Columns.FindByUId(new Guid("5f332a4c-0975-4882-93ea-5941eafe2c7d")) == null) {
				Columns.Add(CreatePlanningWorkColumn());
			}
			if (Columns.FindByUId(new Guid("83e9a961-08bf-4d01-a795-997c4fb54686")) == null) {
				Columns.Add(CreateActualWorkColumn());
			}
			if (Columns.FindByUId(new Guid("d5714d9b-0bd1-468b-92eb-577322bad83a")) == null) {
				Columns.Add(CreateContactColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cad634f0-58b6-4367-8e5f-a88471349fe6"),
				Name = @"Project",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateExternalRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("4ef6d535-6900-4bed-b25e-bc9f21ec8f51"),
				Name = @"ExternalRate",
				CreatedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateInternalRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("5a690e50-642f-4e2d-a470-440cf68bc757"),
				Name = @"InternalRate",
				CreatedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanningWorkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("5f332a4c-0975-4882-93ea-5941eafe2c7d"),
				Name = @"PlanningWork",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateActualWorkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("83e9a961-08bf-4d01-a795-997c4fb54686"),
				Name = @"ActualWork",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("32e3c36d-ba76-48bb-ae00-813c61567e97"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d5714d9b-0bd1-468b-92eb-577322bad83a"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				ModifiedInSchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProjectResourceElement(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProjectResourceElement_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProjectResourceElementSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProjectResourceElementSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("83e22973-7506-4bc0-88e3-9502851b6c44"));
		}

		#endregion

	}

	#endregion

	#region Class: ProjectResourceElement

	/// <summary>
	/// Элемент ресурсов проекта.
	/// </summary>
	public class ProjectResourceElement : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProjectResourceElement(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProjectResourceElement";
		}

		public ProjectResourceElement(ProjectResourceElement source)
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

		/// <summary>
		/// Внешняя ставка.
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
		/// Внутренняя ставка.
		/// </summary>
		public Decimal InternalRate {
			get {
				return GetTypedColumnValue<Decimal>("InternalRate");
			}
			set {
				SetColumnValue("InternalRate", value);
			}
		}

		/// <summary>
		/// Плановые трудозатраты, ч.
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
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProjectResourceElement_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProjectResourceElementDeleted", e);
			Deleting += (s, e) => ThrowEvent("ProjectResourceElementDeleting", e);
			Inserting += (s, e) => ThrowEvent("ProjectResourceElementInserting", e);
			Saved += (s, e) => ThrowEvent("ProjectResourceElementSaved", e);
			Validating += (s, e) => ThrowEvent("ProjectResourceElementValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProjectResourceElement(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProjectResourceElement_ProjectEventsProcess

	/// <exclude/>
	public partial class ProjectResourceElement_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ProjectResourceElement
	{

		public ProjectResourceElement_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProjectResourceElement_ProjectEventsProcess";
			SchemaUId = new Guid("83e22973-7506-4bc0-88e3-9502851b6c44");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("83e22973-7506-4bc0-88e3-9502851b6c44");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid ProjectId {
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
					SchemaElementUId = new Guid("e494b425-16df-4a2b-a83b-f0f4c8f3b4b2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _projectManhourDeleting;
		public ProcessFlowElement ProjectManhourDeleting {
			get {
				return _projectManhourDeleting ?? (_projectManhourDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ProjectManhourDeleting",
					SchemaElementUId = new Guid("f652f2c0-ffed-4072-8479-ed052fa1a36c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _projectManhourDeletingScriptTask;
		public ProcessScriptTask ProjectManhourDeletingScriptTask {
			get {
				return _projectManhourDeletingScriptTask ?? (_projectManhourDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ProjectManhourDeletingScriptTask",
					SchemaElementUId = new Guid("77fbed06-9a68-4d36-9d9c-91d011c06cb1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ProjectManhourDeletingScriptTaskExecute,
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
					SchemaElementUId = new Guid("26f0f89a-c98f-433c-b488-d4b7a532a6b1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _projectManhourSaved;
		public ProcessFlowElement ProjectManhourSaved {
			get {
				return _projectManhourSaved ?? (_projectManhourSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ProjectManhourSaved",
					SchemaElementUId = new Guid("dea16d2d-8a39-451c-a2b4-5f0ac9267f69"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _projectManhourSavedScriptTask;
		public ProcessScriptTask ProjectManhourSavedScriptTask {
			get {
				return _projectManhourSavedScriptTask ?? (_projectManhourSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ProjectManhourSavedScriptTask",
					SchemaElementUId = new Guid("3b6ed6c2-bd1d-48f8-a84d-fc6b4fe8fbc4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ProjectManhourSavedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _projectManhourDeleted;
		public ProcessFlowElement ProjectManhourDeleted {
			get {
				return _projectManhourDeleted ?? (_projectManhourDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ProjectManhourDeleted",
					SchemaElementUId = new Guid("445cde7e-1b49-4474-8713-8e2819903e06"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _projectRecalcScriptTask;
		public ProcessScriptTask ProjectRecalcScriptTask {
			get {
				return _projectRecalcScriptTask ?? (_projectRecalcScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ProjectRecalcScriptTask",
					SchemaElementUId = new Guid("c7096a1a-82f2-4fba-8119-83bd90935b0a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ProjectRecalcScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ProjectManhourDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { ProjectManhourDeleting };
			FlowElements[ProjectManhourDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ProjectManhourDeletingScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[ProjectManhourSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ProjectManhourSaved };
			FlowElements[ProjectManhourSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ProjectManhourSavedScriptTask };
			FlowElements[ProjectManhourDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ProjectManhourDeleted };
			FlowElements[ProjectRecalcScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ProjectRecalcScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ProjectManhourDeleting":
						e.Context.QueueTasks.Enqueue("ProjectManhourDeletingScriptTask");
						break;
					case "ProjectManhourDeletingScriptTask":
						break;
					case "EventSubProcess2":
						break;
					case "ProjectManhourSaved":
						e.Context.QueueTasks.Enqueue("ProjectManhourSavedScriptTask");
						break;
					case "ProjectManhourSavedScriptTask":
						e.Context.QueueTasks.Enqueue("ProjectRecalcScriptTask");
						break;
					case "ProjectManhourDeleted":
						e.Context.QueueTasks.Enqueue("ProjectRecalcScriptTask");
						break;
					case "ProjectRecalcScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ProjectManhourDeleting");
			ActivatedEventElements.Add("ProjectManhourSaved");
			ActivatedEventElements.Add("ProjectManhourDeleted");
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
				case "ProjectManhourDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProjectManhourDeleting";
					result = ProjectManhourDeleting.Execute(context);
					break;
				case "ProjectManhourDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProjectManhourDeletingScriptTask";
					result = ProjectManhourDeletingScriptTask.Execute(context, ProjectManhourDeletingScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "ProjectManhourSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProjectManhourSaved";
					result = ProjectManhourSaved.Execute(context);
					break;
				case "ProjectManhourSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProjectManhourSavedScriptTask";
					result = ProjectManhourSavedScriptTask.Execute(context, ProjectManhourSavedScriptTaskExecute);
					break;
				case "ProjectManhourDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProjectManhourDeleted";
					result = ProjectManhourDeleted.Execute(context);
					break;
				case "ProjectRecalcScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProjectRecalcScriptTask";
					result = ProjectRecalcScriptTask.Execute(context, ProjectRecalcScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ProjectManhourDeletingScriptTaskExecute(ProcessExecutingContext context) {
			ProjectId = Entity.GetTypedColumnValue<Guid>("ProjectId");
			return true;
		}

		public virtual bool ProjectManhourSavedScriptTaskExecute(ProcessExecutingContext context) {
			ProjectId = Entity.GetTypedColumnValue<Guid>("ProjectId");
			return true;
		}

		public virtual bool ProjectRecalcScriptTaskExecute(ProcessExecutingContext context) {
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ProjectManhourDeleting":
							if (ActivatedEventElements.Contains("ProjectManhourDeleting")) {
							context.QueueTasks.Enqueue("ProjectManhourDeleting");
						}
						break;
					case "ProjectManhourSaved":
							if (ActivatedEventElements.Contains("ProjectManhourSaved")) {
							context.QueueTasks.Enqueue("ProjectManhourSaved");
						}
						break;
					case "ProjectManhourDeleted":
							if (ActivatedEventElements.Contains("ProjectManhourDeleted")) {
							context.QueueTasks.Enqueue("ProjectManhourDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ProjectResourceElement_ProjectEventsProcess

	/// <exclude/>
	public class ProjectResourceElement_ProjectEventsProcess : ProjectResourceElement_ProjectEventsProcess<ProjectResourceElement>
	{

		public ProjectResourceElement_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProjectResourceElement_ProjectEventsProcess

	public partial class ProjectResourceElement_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual decimal Division(decimal arg1, decimal arg2) {
			decimal result = 0;
			if (arg2 > 0) {
				result = Math.Round(arg1 / arg2, 2);
			}
			return result;
		}

		#endregion

	}

	#endregion


	#region Class: ProjectResourceElementEventsProcess

	/// <exclude/>
	public class ProjectResourceElementEventsProcess : ProjectResourceElement_ProjectEventsProcess
	{

		public ProjectResourceElementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

