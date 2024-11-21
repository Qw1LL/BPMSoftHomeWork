namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: VwProjectHierarchySchema

	/// <exclude/>
	public class VwProjectHierarchySchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwProjectHierarchySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProjectHierarchySchema(VwProjectHierarchySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProjectHierarchySchema(VwProjectHierarchySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0");
			RealUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0");
			Name = "VwProjectHierarchy";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0baf3f21-9d78-444f-ba02-a8eae918796b")) == null) {
				Columns.Add(CreateProjectColumn());
			}
			if (Columns.FindByUId(new Guid("f6e62ef6-2a8d-4375-adbe-f37a1cbdac47")) == null) {
				Columns.Add(CreateBaseProjectColumn());
			}
			if (Columns.FindByUId(new Guid("eb7ed1d6-2290-4727-b990-739d5bfe8e46")) == null) {
				Columns.Add(CreateIsFirstColumn());
			}
			if (Columns.FindByUId(new Guid("d3e8eb30-5d7d-4c18-8b88-ffe4441549ee")) == null) {
				Columns.Add(CreateAccountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0baf3f21-9d78-444f-ba02-a8eae918796b"),
				Name = @"Project",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"),
				ModifiedInSchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateBaseProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f6e62ef6-2a8d-4375-adbe-f37a1cbdac47"),
				Name = @"BaseProject",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"),
				ModifiedInSchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateIsFirstColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("eb7ed1d6-2290-4727-b990-739d5bfe8e46"),
				Name = @"IsFirst",
				CreatedInSchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"),
				ModifiedInSchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7e488c16-15dd-410d-b053-d4aab26b4db6"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"),
				ModifiedInSchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d3e8eb30-5d7d-4c18-8b88-ffe4441549ee"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"),
				ModifiedInSchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"),
				CreatedInPackageId = new Guid("8b197fec-cca3-49e4-9295-6ade986ba854")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwProjectHierarchy(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProjectHierarchy_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProjectHierarchySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProjectHierarchySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6ab03512-d9aa-4747-a342-75d7975342f0"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProjectHierarchy

	/// <summary>
	/// Иерархия проектов (представление).
	/// </summary>
	public class VwProjectHierarchy : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwProjectHierarchy(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProjectHierarchy";
		}

		public VwProjectHierarchy(VwProjectHierarchy source)
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
		public Guid BaseProjectId {
			get {
				return GetTypedColumnValue<Guid>("BaseProjectId");
			}
			set {
				SetColumnValue("BaseProjectId", value);
				_baseProject = null;
			}
		}

		/// <exclude/>
		public string BaseProjectName {
			get {
				return GetTypedColumnValue<string>("BaseProjectName");
			}
			set {
				SetColumnValue("BaseProjectName", value);
				if (_baseProject != null) {
					_baseProject.Name = value;
				}
			}
		}

		private Project _baseProject;
		/// <summary>
		/// Проект развертывания.
		/// </summary>
		public Project BaseProject {
			get {
				return _baseProject ??
					(_baseProject = LookupColumnEntities.GetEntity("BaseProject") as Project);
			}
		}

		/// <summary>
		/// Первый элемент в развертывании.
		/// </summary>
		public bool IsFirst {
			get {
				return GetTypedColumnValue<bool>("IsFirst");
			}
			set {
				SetColumnValue("IsFirst", value);
			}
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProjectHierarchy_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwProjectHierarchy(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProjectHierarchy_ProjectEventsProcess

	/// <exclude/>
	public partial class VwProjectHierarchy_ProjectEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwProjectHierarchy
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwProjectHierarchy_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProjectHierarchy_ProjectEventsProcess";
			SchemaUId = new Guid("6ab03512-d9aa-4747-a342-75d7975342f0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6ab03512-d9aa-4747-a342-75d7975342f0");
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

	#region Class: VwProjectHierarchy_ProjectEventsProcess

	/// <exclude/>
	public class VwProjectHierarchy_ProjectEventsProcess : VwProjectHierarchy_ProjectEventsProcess<VwProjectHierarchy>
	{

		public VwProjectHierarchy_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProjectHierarchy_ProjectEventsProcess

	public partial class VwProjectHierarchy_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwProjectHierarchyEventsProcess

	/// <exclude/>
	public class VwProjectHierarchyEventsProcess : VwProjectHierarchy_ProjectEventsProcess
	{

		public VwProjectHierarchyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

