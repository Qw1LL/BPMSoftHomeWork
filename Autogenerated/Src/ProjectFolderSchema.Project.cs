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

	#region Class: ProjectFolderSchema

	/// <exclude/>
	public class ProjectFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public ProjectFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProjectFolderSchema(ProjectFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProjectFolderSchema(ProjectFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			RealUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			Name = "ProjectFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProjectFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProjectFolder_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProjectFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProjectFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af"));
		}

		#endregion

	}

	#endregion

	#region Class: ProjectFolder

	/// <summary>
	/// Группа проекта.
	/// </summary>
	public class ProjectFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public ProjectFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProjectFolder";
		}

		public ProjectFolder(ProjectFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private ProjectFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public ProjectFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as ProjectFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProjectFolder_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProjectFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProjectFolderInserting", e);
			Validating += (s, e) => ThrowEvent("ProjectFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProjectFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProjectFolder_ProjectEventsProcess

	/// <exclude/>
	public partial class ProjectFolder_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : ProjectFolder
	{

		public ProjectFolder_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProjectFolder_ProjectEventsProcess";
			SchemaUId = new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("99e4e4d5-dc28-4f9b-9c16-0ce052c7b5af");
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

	#region Class: ProjectFolder_ProjectEventsProcess

	/// <exclude/>
	public class ProjectFolder_ProjectEventsProcess : ProjectFolder_ProjectEventsProcess<ProjectFolder>
	{

		public ProjectFolder_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProjectFolder_ProjectEventsProcess

	public partial class ProjectFolder_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: ProjectFolderEventsProcess

	/// <exclude/>
	public class ProjectFolderEventsProcess : ProjectFolder_ProjectEventsProcess
	{

		public ProjectFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

