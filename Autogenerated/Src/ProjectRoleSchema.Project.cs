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

	#region Class: ProjectRoleSchema

	/// <exclude/>
	public class ProjectRoleSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ProjectRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProjectRoleSchema(ProjectRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProjectRoleSchema(ProjectRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			RealUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			Name = "ProjectRole";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1c0f586f-b552-444a-9126-d5ef80205f70")) == null) {
				Columns.Add(CreateExternalRateColumn());
			}
			if (Columns.FindByUId(new Guid("e4dc8763-b985-4d80-ab26-5a9fd007e63b")) == null) {
				Columns.Add(CreateInternalRateColumn());
			}
			if (Columns.FindByUId(new Guid("60d0cd19-0ac3-4f03-a125-35421aaeee0e")) == null) {
				Columns.Add(CreateJobTitleColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateExternalRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("1c0f586f-b552-444a-9126-d5ef80205f70"),
				Name = @"ExternalRate",
				CreatedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df"),
				ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected virtual EntitySchemaColumn CreateInternalRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("e4dc8763-b985-4d80-ab26-5a9fd007e63b"),
				Name = @"InternalRate",
				CreatedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df"),
				ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected virtual EntitySchemaColumn CreateJobTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("60d0cd19-0ac3-4f03-a125-35421aaeee0e"),
				Name = @"JobTitle",
				ReferenceSchemaUId = new Guid("c82ab6f0-0e36-4376-9ab3-c583d714b7b6"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df"),
				ModifiedInSchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df"),
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
			return new ProjectRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProjectRole_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProjectRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProjectRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df"));
		}

		#endregion

	}

	#endregion

	#region Class: ProjectRole

	/// <summary>
	/// Роль в проекте.
	/// </summary>
	public class ProjectRole : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ProjectRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProjectRole";
		}

		public ProjectRole(ProjectRole source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid JobTitleId {
			get {
				return GetTypedColumnValue<Guid>("JobTitleId");
			}
			set {
				SetColumnValue("JobTitleId", value);
				_jobTitle = null;
			}
		}

		/// <exclude/>
		public string JobTitleName {
			get {
				return GetTypedColumnValue<string>("JobTitleName");
			}
			set {
				SetColumnValue("JobTitleName", value);
				if (_jobTitle != null) {
					_jobTitle.Name = value;
				}
			}
		}

		private Job _jobTitle;
		/// <summary>
		/// Должность.
		/// </summary>
		public Job JobTitle {
			get {
				return _jobTitle ??
					(_jobTitle = LookupColumnEntities.GetEntity("JobTitle") as Job);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProjectRole_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProjectRoleDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProjectRoleInserting", e);
			Validating += (s, e) => ThrowEvent("ProjectRoleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProjectRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProjectRole_ProjectEventsProcess

	/// <exclude/>
	public partial class ProjectRole_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ProjectRole
	{

		public ProjectRole_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProjectRole_ProjectEventsProcess";
			SchemaUId = new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fea6a5b4-c59a-4824-9844-49b5694b53df");
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

	#region Class: ProjectRole_ProjectEventsProcess

	/// <exclude/>
	public class ProjectRole_ProjectEventsProcess : ProjectRole_ProjectEventsProcess<ProjectRole>
	{

		public ProjectRole_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProjectRole_ProjectEventsProcess

	public partial class ProjectRole_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProjectRoleEventsProcess

	/// <exclude/>
	public class ProjectRoleEventsProcess : ProjectRole_ProjectEventsProcess
	{

		public ProjectRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

