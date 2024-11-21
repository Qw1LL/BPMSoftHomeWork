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

	#region Class: SysFuncRoleInOrgRoleSchema

	/// <exclude/>
	public class SysFuncRoleInOrgRoleSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysFuncRoleInOrgRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysFuncRoleInOrgRoleSchema(SysFuncRoleInOrgRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysFuncRoleInOrgRoleSchema(SysFuncRoleInOrgRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63");
			RealUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63");
			Name = "SysFuncRoleInOrgRole";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e284f91-c9c3-4061-a0d7-d57d0e7e0e3f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a413f58f-4d46-4bb9-9824-b723c40af619")) == null) {
				Columns.Add(CreateOrgRoleColumn());
			}
			if (Columns.FindByUId(new Guid("99361ab4-386d-4c13-a0f4-19253b9f207f")) == null) {
				Columns.Add(CreateFuncRoleColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63");
			column.CreatedInPackageId = new Guid("2e284f91-c9c3-4061-a0d7-d57d0e7e0e3f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63");
			column.CreatedInPackageId = new Guid("2e284f91-c9c3-4061-a0d7-d57d0e7e0e3f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63");
			column.CreatedInPackageId = new Guid("2e284f91-c9c3-4061-a0d7-d57d0e7e0e3f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63");
			column.CreatedInPackageId = new Guid("2e284f91-c9c3-4061-a0d7-d57d0e7e0e3f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63");
			column.CreatedInPackageId = new Guid("2e284f91-c9c3-4061-a0d7-d57d0e7e0e3f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63");
			column.CreatedInPackageId = new Guid("2e284f91-c9c3-4061-a0d7-d57d0e7e0e3f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOrgRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a413f58f-4d46-4bb9-9824-b723c40af619"),
				Name = @"OrgRole",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63"),
				ModifiedInSchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63"),
				CreatedInPackageId = new Guid("2e284f91-c9c3-4061-a0d7-d57d0e7e0e3f")
			};
		}

		protected virtual EntitySchemaColumn CreateFuncRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("99361ab4-386d-4c13-a0f4-19253b9f207f"),
				Name = @"FuncRole",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63"),
				ModifiedInSchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63"),
				CreatedInPackageId = new Guid("2e284f91-c9c3-4061-a0d7-d57d0e7e0e3f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysFuncRoleInOrgRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysFuncRoleInOrgRole_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysFuncRoleInOrgRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysFuncRoleInOrgRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63"));
		}

		#endregion

	}

	#endregion

	#region Class: SysFuncRoleInOrgRole

	/// <summary>
	/// Functional role in organizational role.
	/// </summary>
	public class SysFuncRoleInOrgRole : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysFuncRoleInOrgRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysFuncRoleInOrgRole";
		}

		public SysFuncRoleInOrgRole(SysFuncRoleInOrgRole source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OrgRoleId {
			get {
				return GetTypedColumnValue<Guid>("OrgRoleId");
			}
			set {
				SetColumnValue("OrgRoleId", value);
				_orgRole = null;
			}
		}

		/// <exclude/>
		public string OrgRoleName {
			get {
				return GetTypedColumnValue<string>("OrgRoleName");
			}
			set {
				SetColumnValue("OrgRoleName", value);
				if (_orgRole != null) {
					_orgRole.Name = value;
				}
			}
		}

		private SysAdminUnit _orgRole;
		/// <summary>
		/// Organizational role.
		/// </summary>
		public SysAdminUnit OrgRole {
			get {
				return _orgRole ??
					(_orgRole = LookupColumnEntities.GetEntity("OrgRole") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid FuncRoleId {
			get {
				return GetTypedColumnValue<Guid>("FuncRoleId");
			}
			set {
				SetColumnValue("FuncRoleId", value);
				_funcRole = null;
			}
		}

		/// <exclude/>
		public string FuncRoleName {
			get {
				return GetTypedColumnValue<string>("FuncRoleName");
			}
			set {
				SetColumnValue("FuncRoleName", value);
				if (_funcRole != null) {
					_funcRole.Name = value;
				}
			}
		}

		private SysAdminUnit _funcRole;
		/// <summary>
		/// Functional role.
		/// </summary>
		public SysAdminUnit FuncRole {
			get {
				return _funcRole ??
					(_funcRole = LookupColumnEntities.GetEntity("FuncRole") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysFuncRoleInOrgRole_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysFuncRoleInOrgRoleDeleted", e);
			Validating += (s, e) => ThrowEvent("SysFuncRoleInOrgRoleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysFuncRoleInOrgRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysFuncRoleInOrgRole_UIv2EventsProcess

	/// <exclude/>
	public partial class SysFuncRoleInOrgRole_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysFuncRoleInOrgRole
	{

		public SysFuncRoleInOrgRole_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysFuncRoleInOrgRole_UIv2EventsProcess";
			SchemaUId = new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d9bf8007-9380-4ef1-ac05-a27b9b44fc63");
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

	#region Class: SysFuncRoleInOrgRole_UIv2EventsProcess

	/// <exclude/>
	public class SysFuncRoleInOrgRole_UIv2EventsProcess : SysFuncRoleInOrgRole_UIv2EventsProcess<SysFuncRoleInOrgRole>
	{

		public SysFuncRoleInOrgRole_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysFuncRoleInOrgRole_UIv2EventsProcess

	public partial class SysFuncRoleInOrgRole_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysFuncRoleInOrgRoleEventsProcess

	/// <exclude/>
	public class SysFuncRoleInOrgRoleEventsProcess : SysFuncRoleInOrgRole_UIv2EventsProcess
	{

		public SysFuncRoleInOrgRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

