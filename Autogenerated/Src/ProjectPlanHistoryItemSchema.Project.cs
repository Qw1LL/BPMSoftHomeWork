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

	#region Class: ProjectPlanHistoryItemSchema

	/// <exclude/>
	public class ProjectPlanHistoryItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProjectPlanHistoryItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProjectPlanHistoryItemSchema(ProjectPlanHistoryItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProjectPlanHistoryItemSchema(ProjectPlanHistoryItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f");
			RealUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f");
			Name = "ProjectPlanHistoryItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a960d699-2ffa-41d4-b774-2361d46af048")) == null) {
				Columns.Add(CreateProjectColumn());
			}
			if (Columns.FindByUId(new Guid("f2ebc2a1-606d-4b84-b70f-1696f855220d")) == null) {
				Columns.Add(CreateRoleColumn());
			}
			if (Columns.FindByUId(new Guid("55be9d19-33a7-4cb5-81ed-3f91ea530970")) == null) {
				Columns.Add(CreatePlanningWorkColumn());
			}
			if (Columns.FindByUId(new Guid("c65b17a2-d3a5-4ef4-a67f-8e66e3d67be3")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("c3a435f0-4aaa-4cb6-8c12-a456894997f7")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("26602526-02a0-4372-83d9-618753640820")) == null) {
				Columns.Add(CreatePlanningCompletionColumn());
			}
			if (Columns.FindByUId(new Guid("2f6526c4-85b4-4f26-b52e-f44f8a822fb6")) == null) {
				Columns.Add(CreateActualCompletionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a960d699-2ffa-41d4-b774-2361d46af048"),
				Name = @"Project",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected virtual EntitySchemaColumn CreateRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f2ebc2a1-606d-4b84-b70f-1696f855220d"),
				Name = @"Role",
				ReferenceSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanningWorkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("55be9d19-33a7-4cb5-81ed-3f91ea530970"),
				Name = @"PlanningWork",
				CreatedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("c65b17a2-d3a5-4ef4-a67f-8e66e3d67be3"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("c3a435f0-4aaa-4cb6-8c12-a456894997f7"),
				Name = @"EndDate",
				CreatedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanningCompletionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("26602526-02a0-4372-83d9-618753640820"),
				Name = @"PlanningCompletion",
				CreatedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected virtual EntitySchemaColumn CreateActualCompletionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("2f6526c4-85b4-4f26-b52e-f44f8a822fb6"),
				Name = @"ActualCompletion",
				CreatedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				ModifiedInSchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProjectPlanHistoryItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProjectPlanHistoryItem_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProjectPlanHistoryItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProjectPlanHistoryItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f"));
		}

		#endregion

	}

	#endregion

	#region Class: ProjectPlanHistoryItem

	/// <summary>
	/// Запись истории плана проекта.
	/// </summary>
	public class ProjectPlanHistoryItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProjectPlanHistoryItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProjectPlanHistoryItem";
		}

		public ProjectPlanHistoryItem(ProjectPlanHistoryItem source)
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
		public Guid RoleId {
			get {
				return GetTypedColumnValue<Guid>("RoleId");
			}
			set {
				SetColumnValue("RoleId", value);
				_role = null;
			}
		}

		/// <exclude/>
		public string RoleName {
			get {
				return GetTypedColumnValue<string>("RoleName");
			}
			set {
				SetColumnValue("RoleName", value);
				if (_role != null) {
					_role.Name = value;
				}
			}
		}

		private ProjectRole _role;
		/// <summary>
		/// Роль.
		/// </summary>
		public ProjectRole Role {
			get {
				return _role ??
					(_role = LookupColumnEntities.GetEntity("Role") as ProjectRole);
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
		/// Начало.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Завершение.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <summary>
		/// План. завершение, %.
		/// </summary>
		public Decimal PlanningCompletion {
			get {
				return GetTypedColumnValue<Decimal>("PlanningCompletion");
			}
			set {
				SetColumnValue("PlanningCompletion", value);
			}
		}

		/// <summary>
		/// Факт. завершение, %.
		/// </summary>
		public Decimal ActualCompletion {
			get {
				return GetTypedColumnValue<Decimal>("ActualCompletion");
			}
			set {
				SetColumnValue("ActualCompletion", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProjectPlanHistoryItem_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProjectPlanHistoryItemDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProjectPlanHistoryItemInserting", e);
			Validating += (s, e) => ThrowEvent("ProjectPlanHistoryItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProjectPlanHistoryItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProjectPlanHistoryItem_ProjectEventsProcess

	/// <exclude/>
	public partial class ProjectPlanHistoryItem_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ProjectPlanHistoryItem
	{

		public ProjectPlanHistoryItem_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProjectPlanHistoryItem_ProjectEventsProcess";
			SchemaUId = new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("59fbdedf-d508-41f0-b37d-8fd6c54c961f");
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

	#region Class: ProjectPlanHistoryItem_ProjectEventsProcess

	/// <exclude/>
	public class ProjectPlanHistoryItem_ProjectEventsProcess : ProjectPlanHistoryItem_ProjectEventsProcess<ProjectPlanHistoryItem>
	{

		public ProjectPlanHistoryItem_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProjectPlanHistoryItem_ProjectEventsProcess

	public partial class ProjectPlanHistoryItem_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProjectPlanHistoryItemEventsProcess

	/// <exclude/>
	public class ProjectPlanHistoryItemEventsProcess : ProjectPlanHistoryItem_ProjectEventsProcess
	{

		public ProjectPlanHistoryItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

