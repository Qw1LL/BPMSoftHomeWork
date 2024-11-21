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
	using BPMSoft.Core.OperationLog;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using BPMSoft.Web.Common;
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

	#region Class: SysUserInRole_Base_BPMSoftSchema

	/// <exclude/>
	public class SysUserInRole_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysUserInRole_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserInRole_Base_BPMSoftSchema(SysUserInRole_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserInRole_Base_BPMSoftSchema(SysUserInRole_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4b27f502-c296-47cf-af5d-3197d54e0d2a");
			RealUId = new Guid("4b27f502-c296-47cf-af5d-3197d54e0d2a");
			Name = "SysUserInRole_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c540ad32-33ed-4ad0-abb7-cc1575b9f6f2")) == null) {
				Columns.Add(CreateSysUserColumn());
			}
			if (Columns.FindByUId(new Guid("ceffac9c-08c8-4792-a3fc-2931b23bc538")) == null) {
				Columns.Add(CreateSysRoleColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c540ad32-33ed-4ad0-abb7-cc1575b9f6f2"),
				Name = @"SysUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInSchemaUId = new Guid("4b27f502-c296-47cf-af5d-3197d54e0d2a"),
				ModifiedInSchemaUId = new Guid("4b27f502-c296-47cf-af5d-3197d54e0d2a"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ceffac9c-08c8-4792-a3fc-2931b23bc538"),
				Name = @"SysRole",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInSchemaUId = new Guid("4b27f502-c296-47cf-af5d-3197d54e0d2a"),
				ModifiedInSchemaUId = new Guid("4b27f502-c296-47cf-af5d-3197d54e0d2a"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysUserInRole_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserInRole_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserInRole_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserInRole_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4b27f502-c296-47cf-af5d-3197d54e0d2a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserInRole_Base_BPMSoft

	/// <summary>
	/// Вхождение пользователя в роли.
	/// </summary>
	public class SysUserInRole_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysUserInRole_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserInRole_Base_BPMSoft";
		}

		public SysUserInRole_Base_BPMSoft(SysUserInRole_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysUserId {
			get {
				return GetTypedColumnValue<Guid>("SysUserId");
			}
			set {
				SetColumnValue("SysUserId", value);
				_sysUser = null;
			}
		}

		/// <exclude/>
		public string SysUserName {
			get {
				return GetTypedColumnValue<string>("SysUserName");
			}
			set {
				SetColumnValue("SysUserName", value);
				if (_sysUser != null) {
					_sysUser.Name = value;
				}
			}
		}

		private SysAdminUnit _sysUser;
		/// <summary>
		/// Пользователь.
		/// </summary>
		public SysAdminUnit SysUser {
			get {
				return _sysUser ??
					(_sysUser = LookupColumnEntities.GetEntity("SysUser") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid SysRoleId {
			get {
				return GetTypedColumnValue<Guid>("SysRoleId");
			}
			set {
				SetColumnValue("SysRoleId", value);
				_sysRole = null;
			}
		}

		/// <exclude/>
		public string SysRoleName {
			get {
				return GetTypedColumnValue<string>("SysRoleName");
			}
			set {
				SetColumnValue("SysRoleName", value);
				if (_sysRole != null) {
					_sysRole.Name = value;
				}
			}
		}

		private SysAdminUnit _sysRole;
		/// <summary>
		/// Роль.
		/// </summary>
		public SysAdminUnit SysRole {
			get {
				return _sysRole ??
					(_sysRole = LookupColumnEntities.GetEntity("SysRole") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUserInRole_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysUserInRole_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysUserInRole_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysUserInRole_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("SysUserInRole_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("SysUserInRole_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("SysUserInRole_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("SysUserInRole_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysUserInRole_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserInRole_BaseEventsProcess

	/// <exclude/>
	public partial class SysUserInRole_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysUserInRole_Base_BPMSoft
	{

		public SysUserInRole_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserInRole_BaseEventsProcess";
			SchemaUId = new Guid("4b27f502-c296-47cf-af5d-3197d54e0d2a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4b27f502-c296-47cf-af5d-3197d54e0d2a");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _actualizeOrganizationalStructureEventSubProcess;
		public ProcessFlowElement ActualizeOrganizationalStructureEventSubProcess {
			get {
				return _actualizeOrganizationalStructureEventSubProcess ?? (_actualizeOrganizationalStructureEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ActualizeOrganizationalStructureEventSubProcess",
					SchemaElementUId = new Guid("3941c985-81aa-48f6-94ee-3e3d4c559598"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysUserInRoleSaved;
		public ProcessFlowElement SysUserInRoleSaved {
			get {
				return _sysUserInRoleSaved ?? (_sysUserInRoleSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysUserInRoleSaved",
					SchemaElementUId = new Guid("2da404f8-487d-47d3-9384-1293939346e0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _actualizeOrganizationalStructureScriptTask;
		public ProcessScriptTask ActualizeOrganizationalStructureScriptTask {
			get {
				return _actualizeOrganizationalStructureScriptTask ?? (_actualizeOrganizationalStructureScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActualizeOrganizationalStructureScriptTask",
					SchemaElementUId = new Guid("109da2aa-f93c-492f-91c7-7f6290e75c90"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActualizeOrganizationalStructureScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _sysUserInRoleDeleted;
		public ProcessFlowElement SysUserInRoleDeleted {
			get {
				return _sysUserInRoleDeleted ?? (_sysUserInRoleDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysUserInRoleDeleted",
					SchemaElementUId = new Guid("a539b7bb-f7d1-41b5-9b3c-7fddac1181db"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysUserInRoleSavedLogScriptTask;
		public ProcessScriptTask SysUserInRoleSavedLogScriptTask {
			get {
				return _sysUserInRoleSavedLogScriptTask ?? (_sysUserInRoleSavedLogScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysUserInRoleSavedLogScriptTask",
					SchemaElementUId = new Guid("c5b2ebc6-8c3d-4af9-be56-0351fe3f6b79"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysUserInRoleSavedLogScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _sysUserInRoleDeletedLogScriptTask;
		public ProcessScriptTask SysUserInRoleDeletedLogScriptTask {
			get {
				return _sysUserInRoleDeletedLogScriptTask ?? (_sysUserInRoleDeletedLogScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysUserInRoleDeletedLogScriptTask",
					SchemaElementUId = new Guid("9f805372-23cc-4587-be38-ca5b48718dfe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysUserInRoleDeletedLogScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _resetPersonalUserSessionTimeouts;
		public ProcessScriptTask ResetPersonalUserSessionTimeouts {
			get {
				return _resetPersonalUserSessionTimeouts ?? (_resetPersonalUserSessionTimeouts = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ResetPersonalUserSessionTimeouts",
					SchemaElementUId = new Guid("69dc0d70-f066-47fd-a84a-df8e2d30d11f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ResetPersonalUserSessionTimeoutsExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[ActualizeOrganizationalStructureEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ActualizeOrganizationalStructureEventSubProcess };
			FlowElements[SysUserInRoleSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { SysUserInRoleSaved };
			FlowElements[ActualizeOrganizationalStructureScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActualizeOrganizationalStructureScriptTask };
			FlowElements[SysUserInRoleDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { SysUserInRoleDeleted };
			FlowElements[SysUserInRoleSavedLogScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysUserInRoleSavedLogScriptTask };
			FlowElements[SysUserInRoleDeletedLogScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysUserInRoleDeletedLogScriptTask };
			FlowElements[ResetPersonalUserSessionTimeouts.SchemaElementUId] = new Collection<ProcessFlowElement> { ResetPersonalUserSessionTimeouts };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "ActualizeOrganizationalStructureEventSubProcess":
						break;
					case "SysUserInRoleSaved":
						e.Context.QueueTasks.Enqueue("SysUserInRoleSavedLogScriptTask");
						break;
					case "ActualizeOrganizationalStructureScriptTask":
						break;
					case "SysUserInRoleDeleted":
						e.Context.QueueTasks.Enqueue("SysUserInRoleDeletedLogScriptTask");
						break;
					case "SysUserInRoleSavedLogScriptTask":
						e.Context.QueueTasks.Enqueue("ResetPersonalUserSessionTimeouts");
						break;
					case "SysUserInRoleDeletedLogScriptTask":
						e.Context.QueueTasks.Enqueue("ResetPersonalUserSessionTimeouts");
						break;
					case "ResetPersonalUserSessionTimeouts":
						e.Context.QueueTasks.Enqueue("ActualizeOrganizationalStructureScriptTask");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysUserInRoleSaved");
			ActivatedEventElements.Add("SysUserInRoleDeleted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "ActualizeOrganizationalStructureEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SysUserInRoleSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysUserInRoleSaved";
					result = SysUserInRoleSaved.Execute(context);
					break;
				case "ActualizeOrganizationalStructureScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActualizeOrganizationalStructureScriptTask";
					result = ActualizeOrganizationalStructureScriptTask.Execute(context, ActualizeOrganizationalStructureScriptTaskExecute);
					break;
				case "SysUserInRoleDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysUserInRoleDeleted";
					result = SysUserInRoleDeleted.Execute(context);
					break;
				case "SysUserInRoleSavedLogScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysUserInRoleSavedLogScriptTask";
					result = SysUserInRoleSavedLogScriptTask.Execute(context, SysUserInRoleSavedLogScriptTaskExecute);
					break;
				case "SysUserInRoleDeletedLogScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysUserInRoleDeletedLogScriptTask";
					result = SysUserInRoleDeletedLogScriptTask.Execute(context, SysUserInRoleDeletedLogScriptTaskExecute);
					break;
				case "ResetPersonalUserSessionTimeouts":
					context.QueueTasks.Dequeue();
					context.SenderName = "ResetPersonalUserSessionTimeouts";
					result = ResetPersonalUserSessionTimeouts.Execute(context, ResetPersonalUserSessionTimeoutsExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ActualizeOrganizationalStructureScriptTaskExecute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool SysUserInRoleSavedLogScriptTaskExecute(ProcessExecutingContext context) {
			OperationLogger.Instance.LogUserRoleAdd(UserConnection, Entity.SysUserId, Entity.SysRoleId);
			return true;
		}

		public virtual bool SysUserInRoleDeletedLogScriptTaskExecute(ProcessExecutingContext context) {
			OperationLogger.Instance.LogUserRoleDelete(UserConnection, Entity.SysUserId, Entity.SysRoleId);
			return true;
		}

		public virtual bool ResetPersonalUserSessionTimeoutsExecute(ProcessExecutingContext context) {
			#if !NETSTANDARD2_0 // TODO
			SessionHelper sessionHelper = new SessionHelper();
			sessionHelper.UpdatePersonalUserSessionTimeoutFromDB(UserConnection.AppConnection.SystemUserConnection, Entity.SysUserId);
			#endif
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysUserInRole_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("SysUserInRoleSaved")) {
							context.QueueTasks.Enqueue("SysUserInRoleSaved");
						}
						break;
					case "SysUserInRole_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("SysUserInRoleDeleted")) {
							context.QueueTasks.Enqueue("SysUserInRoleDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserInRole_BaseEventsProcess

	/// <exclude/>
	public class SysUserInRole_BaseEventsProcess : SysUserInRole_BaseEventsProcess<SysUserInRole_Base_BPMSoft>
	{

		public SysUserInRole_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserInRole_BaseEventsProcess

	public partial class SysUserInRole_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

