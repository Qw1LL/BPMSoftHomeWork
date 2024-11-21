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

	#region Class: ProjectInFolderSchema

	/// <exclude/>
	public class ProjectInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public ProjectInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProjectInFolderSchema(ProjectInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProjectInFolderSchema(ProjectInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
			RealUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
			Name = "ProjectInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0339946c-6688-4969-9edc-cc9257b496eb")) == null) {
				Columns.Add(CreateProjectColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0339946c-6688-4969-9edc-cc9257b496eb"),
				Name = @"Project",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5"),
				ModifiedInSchemaUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProjectInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProjectInFolder_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProjectInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProjectInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5"));
		}

		#endregion

	}

	#endregion

	#region Class: ProjectInFolder

	/// <summary>
	/// Проект в группе.
	/// </summary>
	public class ProjectInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public ProjectInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProjectInFolder";
		}

		public ProjectInFolder(ProjectInFolder source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProjectInFolder_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProjectInFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProjectInFolderInserting", e);
			Validating += (s, e) => ThrowEvent("ProjectInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProjectInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProjectInFolder_ProjectEventsProcess

	/// <exclude/>
	public partial class ProjectInFolder_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : ProjectInFolder
	{

		public ProjectInFolder_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProjectInFolder_ProjectEventsProcess";
			SchemaUId = new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d7a2323c-3e5a-4ca5-b11f-7b5f753d94f5");
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

	#region Class: ProjectInFolder_ProjectEventsProcess

	/// <exclude/>
	public class ProjectInFolder_ProjectEventsProcess : ProjectInFolder_ProjectEventsProcess<ProjectInFolder>
	{

		public ProjectInFolder_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProjectInFolder_ProjectEventsProcess

	public partial class ProjectInFolder_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProjectInFolderEventsProcess

	/// <exclude/>
	public class ProjectInFolderEventsProcess : ProjectInFolder_ProjectEventsProcess
	{

		public ProjectInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

