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

	#region Class: ProjectEntryTypeSchema

	/// <exclude/>
	public class ProjectEntryTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public ProjectEntryTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProjectEntryTypeSchema(ProjectEntryTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProjectEntryTypeSchema(ProjectEntryTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			RealUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			Name = "ProjectEntryType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
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
			return new ProjectEntryType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProjectEntryType_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProjectEntryTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProjectEntryTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9"));
		}

		#endregion

	}

	#endregion

	#region Class: ProjectEntryType

	/// <summary>
	/// Тип записи проекта.
	/// </summary>
	public class ProjectEntryType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public ProjectEntryType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProjectEntryType";
		}

		public ProjectEntryType(ProjectEntryType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProjectEntryType_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProjectEntryTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProjectEntryTypeInserting", e);
			Validating += (s, e) => ThrowEvent("ProjectEntryTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProjectEntryType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProjectEntryType_ProjectEventsProcess

	/// <exclude/>
	public partial class ProjectEntryType_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : ProjectEntryType
	{

		public ProjectEntryType_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProjectEntryType_ProjectEventsProcess";
			SchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9");
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

	#region Class: ProjectEntryType_ProjectEventsProcess

	/// <exclude/>
	public class ProjectEntryType_ProjectEventsProcess : ProjectEntryType_ProjectEventsProcess<ProjectEntryType>
	{

		public ProjectEntryType_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProjectEntryType_ProjectEventsProcess

	public partial class ProjectEntryType_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProjectEntryTypeEventsProcess

	/// <exclude/>
	public class ProjectEntryTypeEventsProcess : ProjectEntryType_ProjectEventsProcess
	{

		public ProjectEntryTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

