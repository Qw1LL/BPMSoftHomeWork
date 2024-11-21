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

	#region Class: VwEmployeesHierarchySchema

	/// <exclude/>
	public class VwEmployeesHierarchySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwEmployeesHierarchySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwEmployeesHierarchySchema(VwEmployeesHierarchySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwEmployeesHierarchySchema(VwEmployeesHierarchySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("81321fdd-5442-4fac-baf1-6c28185d1051");
			RealUId = new Guid("81321fdd-5442-4fac-baf1-6c28185d1051");
			Name = "VwEmployeesHierarchy";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("420cdcc5-79ce-4423-8a8c-752d357975fb")) == null) {
				Columns.Add(CreateEmployeeColumn());
			}
			if (Columns.FindByUId(new Guid("e33c43e1-eb6f-4b53-b9b2-14d9e482f95e")) == null) {
				Columns.Add(CreateManagerUserColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEmployeeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("420cdcc5-79ce-4423-8a8c-752d357975fb"),
				Name = @"Employee",
				ReferenceSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("81321fdd-5442-4fac-baf1-6c28185d1051"),
				ModifiedInSchemaUId = new Guid("81321fdd-5442-4fac-baf1-6c28185d1051"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateManagerUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e33c43e1-eb6f-4b53-b9b2-14d9e482f95e"),
				Name = @"ManagerUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("81321fdd-5442-4fac-baf1-6c28185d1051"),
				ModifiedInSchemaUId = new Guid("81321fdd-5442-4fac-baf1-6c28185d1051"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwEmployeesHierarchy(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwEmployeesHierarchy_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwEmployeesHierarchySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwEmployeesHierarchySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("81321fdd-5442-4fac-baf1-6c28185d1051"));
		}

		#endregion

	}

	#endregion

	#region Class: VwEmployeesHierarchy

	/// <summary>
	/// View of "Employee managers".
	/// </summary>
	public class VwEmployeesHierarchy : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwEmployeesHierarchy(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwEmployeesHierarchy";
		}

		public VwEmployeesHierarchy(VwEmployeesHierarchy source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EmployeeId {
			get {
				return GetTypedColumnValue<Guid>("EmployeeId");
			}
			set {
				SetColumnValue("EmployeeId", value);
				_employee = null;
			}
		}

		/// <exclude/>
		public string EmployeeName {
			get {
				return GetTypedColumnValue<string>("EmployeeName");
			}
			set {
				SetColumnValue("EmployeeName", value);
				if (_employee != null) {
					_employee.Name = value;
				}
			}
		}

		private Employee _employee;
		/// <summary>
		/// Employee.
		/// </summary>
		public Employee Employee {
			get {
				return _employee ??
					(_employee = LookupColumnEntities.GetEntity("Employee") as Employee);
			}
		}

		/// <exclude/>
		public Guid ManagerUserId {
			get {
				return GetTypedColumnValue<Guid>("ManagerUserId");
			}
			set {
				SetColumnValue("ManagerUserId", value);
				_managerUser = null;
			}
		}

		/// <exclude/>
		public string ManagerUserName {
			get {
				return GetTypedColumnValue<string>("ManagerUserName");
			}
			set {
				SetColumnValue("ManagerUserName", value);
				if (_managerUser != null) {
					_managerUser.Name = value;
				}
			}
		}

		private SysAdminUnit _managerUser;
		/// <summary>
		/// User of manager.
		/// </summary>
		public SysAdminUnit ManagerUser {
			get {
				return _managerUser ??
					(_managerUser = LookupColumnEntities.GetEntity("ManagerUser") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwEmployeesHierarchy_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwEmployeesHierarchyDeleted", e);
			Validating += (s, e) => ThrowEvent("VwEmployeesHierarchyValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwEmployeesHierarchy(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwEmployeesHierarchy_BaseEventsProcess

	/// <exclude/>
	public partial class VwEmployeesHierarchy_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwEmployeesHierarchy
	{

		public VwEmployeesHierarchy_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwEmployeesHierarchy_BaseEventsProcess";
			SchemaUId = new Guid("81321fdd-5442-4fac-baf1-6c28185d1051");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("81321fdd-5442-4fac-baf1-6c28185d1051");
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

	#region Class: VwEmployeesHierarchy_BaseEventsProcess

	/// <exclude/>
	public class VwEmployeesHierarchy_BaseEventsProcess : VwEmployeesHierarchy_BaseEventsProcess<VwEmployeesHierarchy>
	{

		public VwEmployeesHierarchy_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwEmployeesHierarchy_BaseEventsProcess

	public partial class VwEmployeesHierarchy_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwEmployeesHierarchyEventsProcess

	/// <exclude/>
	public class VwEmployeesHierarchyEventsProcess : VwEmployeesHierarchy_BaseEventsProcess
	{

		public VwEmployeesHierarchyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

