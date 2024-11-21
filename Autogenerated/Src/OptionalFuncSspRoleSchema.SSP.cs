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

	#region Class: OptionalFuncSspRoleSchema

	/// <exclude/>
	public class OptionalFuncSspRoleSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OptionalFuncSspRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OptionalFuncSspRoleSchema(OptionalFuncSspRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OptionalFuncSspRoleSchema(OptionalFuncSspRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6683ee62-4939-41cc-9a61-e15b10dcbe81");
			RealUId = new Guid("6683ee62-4939-41cc-9a61-e15b10dcbe81");
			Name = "OptionalFuncSspRole";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("427d9055-0683-4368-b3bd-0704922bfd2e")) == null) {
				Columns.Add(CreateOrgRoleColumn());
			}
			if (Columns.FindByUId(new Guid("62fb7143-70e0-4a89-9939-06587e4cf53d")) == null) {
				Columns.Add(CreateFuncRoleColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOrgRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("427d9055-0683-4368-b3bd-0704922bfd2e"),
				Name = @"OrgRole",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("6683ee62-4939-41cc-9a61-e15b10dcbe81"),
				ModifiedInSchemaUId = new Guid("6683ee62-4939-41cc-9a61-e15b10dcbe81"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateFuncRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("62fb7143-70e0-4a89-9939-06587e4cf53d"),
				Name = @"FuncRole",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6683ee62-4939-41cc-9a61-e15b10dcbe81"),
				ModifiedInSchemaUId = new Guid("6683ee62-4939-41cc-9a61-e15b10dcbe81"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OptionalFuncSspRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OptionalFuncSspRole_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OptionalFuncSspRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OptionalFuncSspRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6683ee62-4939-41cc-9a61-e15b10dcbe81"));
		}

		#endregion

	}

	#endregion

	#region Class: OptionalFuncSspRole

	/// <summary>
	/// Roles for portal organization.
	/// </summary>
	public class OptionalFuncSspRole : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OptionalFuncSspRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OptionalFuncSspRole";
		}

		public OptionalFuncSspRole(OptionalFuncSspRole source)
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
			var process = new OptionalFuncSspRole_SSPEventsProcess(UserConnection);
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
			return new OptionalFuncSspRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: OptionalFuncSspRole_SSPEventsProcess

	/// <exclude/>
	public partial class OptionalFuncSspRole_SSPEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OptionalFuncSspRole
	{

		public OptionalFuncSspRole_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OptionalFuncSspRole_SSPEventsProcess";
			SchemaUId = new Guid("6683ee62-4939-41cc-9a61-e15b10dcbe81");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6683ee62-4939-41cc-9a61-e15b10dcbe81");
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

	#region Class: OptionalFuncSspRole_SSPEventsProcess

	/// <exclude/>
	public class OptionalFuncSspRole_SSPEventsProcess : OptionalFuncSspRole_SSPEventsProcess<OptionalFuncSspRole>
	{

		public OptionalFuncSspRole_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OptionalFuncSspRole_SSPEventsProcess

	public partial class OptionalFuncSspRole_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OptionalFuncSspRoleEventsProcess

	/// <exclude/>
	public class OptionalFuncSspRoleEventsProcess : OptionalFuncSspRole_SSPEventsProcess
	{

		public OptionalFuncSspRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

