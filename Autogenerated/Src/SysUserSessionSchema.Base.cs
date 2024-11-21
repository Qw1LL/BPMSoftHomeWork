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

	#region Class: SysUserSession_Base_BPMSoftSchema

	/// <exclude/>
	public class SysUserSession_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysUserSession_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserSession_Base_BPMSoftSchema(SysUserSession_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserSession_Base_BPMSoftSchema(SysUserSession_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISysUserSessEndDateIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("97fc6e87-0eac-4738-a3a0-cded3ee2affe");
			index.Name = "ISysUserSessEndDateId";
			index.CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			EntitySchemaIndexColumn sessionEndDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("99d28ef5-8120-4605-a15c-a47bf3268905"),
				ColumnUId = new Guid("86a0a1f4-7d2d-45da-b313-8f96c983215c"),
				CreatedInSchemaUId = Guid.Empty,
				ModifiedInSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sessionEndDateIndexColumn);
			EntitySchemaIndexColumn sessionIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("97d387d1-2969-4331-8bd8-cc9cac20c9c7"),
				ColumnUId = new Guid("f443b1a3-3c1c-4a25-8add-b3255ea19099"),
				CreatedInSchemaUId = Guid.Empty,
				ModifiedInSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sessionIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateISysUserSessionUserIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("e1f2730f-03f5-4526-acf1-cd929fdbb3a0");
			index.Name = "ISysUserSessionUserId";
			index.CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf");
			EntitySchemaIndexColumn sysUserIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("cdda2024-8137-4a11-ad6f-11d702d8a8f6"),
				ColumnUId = new Guid("61b6df7e-99db-458f-980d-68308d2dd08c"),
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysUserIdIndexColumn);
			EntitySchemaIndexColumn sessionEndDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ffcfaa0a-d163-4978-bf5d-73a7e781472a"),
				ColumnUId = new Guid("86a0a1f4-7d2d-45da-b313-8f96c983215c"),
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sessionEndDateIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			RealUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			Name = "SysUserSession_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("61b6df7e-99db-458f-980d-68308d2dd08c")) == null) {
				Columns.Add(CreateSysUserColumn());
			}
			if (Columns.FindByUId(new Guid("f443b1a3-3c1c-4a25-8add-b3255ea19099")) == null) {
				Columns.Add(CreateSessionIdColumn());
			}
			if (Columns.FindByUId(new Guid("a3557536-73b8-4621-8374-8f2c77fc1abd")) == null) {
				Columns.Add(CreateSessionStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("86a0a1f4-7d2d-45da-b313-8f96c983215c")) == null) {
				Columns.Add(CreateSessionEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("6ee436a9-5490-4cf4-a2e0-d79f6cdb901c")) == null) {
				Columns.Add(CreateSessionEndMethodColumn());
			}
			if (Columns.FindByUId(new Guid("ac2b69b9-8448-4b1d-b095-d2410c2b7321")) == null) {
				Columns.Add(CreateClientIPColumn());
			}
			if (Columns.FindByUId(new Guid("ac479e55-e8d2-408e-9284-0354087f213a")) == null) {
				Columns.Add(CreateAgentColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("61b6df7e-99db-458f-980d-68308d2dd08c"),
				Name = @"SysUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("f443b1a3-3c1c-4a25-8add-b3255ea19099"),
				Name = @"SessionId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("a3557536-73b8-4621-8374-8f2c77fc1abd"),
				Name = @"SessionStartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("86a0a1f4-7d2d-45da-b313-8f96c983215c"),
				Name = @"SessionEndDate",
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionEndMethodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6ee436a9-5490-4cf4-a2e0-d79f6cdb901c"),
				Name = @"SessionEndMethod",
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateClientIPColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("ac2b69b9-8448-4b1d-b095-d2410c2b7321"),
				Name = @"ClientIP",
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateAgentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ac479e55-e8d2-408e-9284-0354087f213a"),
				Name = @"Agent",
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISysUserSessEndDateIdIndex());
			Indexes.Add(CreateISysUserSessionUserIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysUserSession_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserSession_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserSession_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserSession_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserSession_Base_BPMSoft

	/// <summary>
	/// User session.
	/// </summary>
	public class SysUserSession_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysUserSession_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserSession_Base_BPMSoft";
		}

		public SysUserSession_Base_BPMSoft(SysUserSession_Base_BPMSoft source)
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
		/// User.
		/// </summary>
		public SysAdminUnit SysUser {
			get {
				return _sysUser ??
					(_sysUser = LookupColumnEntities.GetEntity("SysUser") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Session Id.
		/// </summary>
		public string SessionId {
			get {
				return GetTypedColumnValue<string>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// Session start.
		/// </summary>
		public DateTime SessionStartDate {
			get {
				return GetTypedColumnValue<DateTime>("SessionStartDate");
			}
			set {
				SetColumnValue("SessionStartDate", value);
			}
		}

		/// <summary>
		/// Session end.
		/// </summary>
		public DateTime SessionEndDate {
			get {
				return GetTypedColumnValue<DateTime>("SessionEndDate");
			}
			set {
				SetColumnValue("SessionEndDate", value);
			}
		}

		/// <summary>
		/// Session end method.
		/// </summary>
		public int SessionEndMethod {
			get {
				return GetTypedColumnValue<int>("SessionEndMethod");
			}
			set {
				SetColumnValue("SessionEndMethod", value);
			}
		}

		/// <summary>
		/// IP address.
		/// </summary>
		public string ClientIP {
			get {
				return GetTypedColumnValue<string>("ClientIP");
			}
			set {
				SetColumnValue("ClientIP", value);
			}
		}

		/// <summary>
		/// Agent.
		/// </summary>
		public string Agent {
			get {
				return GetTypedColumnValue<string>("Agent");
			}
			set {
				SetColumnValue("Agent", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUserSession_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysUserSession_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysUserSession_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysUserSession_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("SysUserSession_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("SysUserSession_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("SysUserSession_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("SysUserSession_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysUserSession_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserSession_BaseEventsProcess

	/// <exclude/>
	public partial class SysUserSession_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysUserSession_Base_BPMSoft
	{

		public SysUserSession_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserSession_BaseEventsProcess";
			SchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("c611cfd7-fa63-4e89-a530-8eeb62793fdb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysUserSessionSaving;
		public ProcessFlowElement SysUserSessionSaving {
			get {
				return _sysUserSessionSaving ?? (_sysUserSessionSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysUserSessionSaving",
					SchemaElementUId = new Guid("22729f53-31f9-40e1-85b4-4ca8f0d76db5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("55a3ea37-b315-46a4-b54b-2c8bae253a67"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("4f3c7825-e61a-4a88-8d75-bfd3b08e0988"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysUserSessionDeleting;
		public ProcessFlowElement SysUserSessionDeleting {
			get {
				return _sysUserSessionDeleting ?? (_sysUserSessionDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysUserSessionDeleting",
					SchemaElementUId = new Guid("7f3eda8c-1c74-4bc7-b3a2-650ee5d22e62"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask2;
		public ProcessScriptTask ScriptTask2 {
			get {
				return _scriptTask2 ?? (_scriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask2",
					SchemaElementUId = new Guid("4596cf35-cf27-415f-be23-9e3b8afb725d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask2Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[SysUserSessionSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { SysUserSessionSaving };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[SysUserSessionDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { SysUserSessionDeleting };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "SysUserSessionSaving":
						e.Context.QueueTasks.Enqueue("ScriptTask1");
						break;
					case "ScriptTask1":
						break;
					case "EventSubProcess2":
						break;
					case "SysUserSessionDeleting":
						e.Context.QueueTasks.Enqueue("ScriptTask2");
						break;
					case "ScriptTask2":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysUserSessionSaving");
			ActivatedEventElements.Add("SysUserSessionDeleting");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "SysUserSessionSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysUserSessionSaving";
					result = SysUserSessionSaving.Execute(context);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "SysUserSessionDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysUserSessionDeleting";
					result = SysUserSessionDeleting.Execute(context);
					break;
				case "ScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask2";
					result = ScriptTask2.Execute(context, ScriptTask2Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysUserSession_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("SysUserSessionSaving")) {
							context.QueueTasks.Enqueue("SysUserSessionSaving");
						}
						break;
					case "SysUserSession_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("SysUserSessionDeleting")) {
							context.QueueTasks.Enqueue("SysUserSessionDeleting");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserSession_BaseEventsProcess

	/// <exclude/>
	public class SysUserSession_BaseEventsProcess : SysUserSession_BaseEventsProcess<SysUserSession_Base_BPMSoft>
	{

		public SysUserSession_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserSession_BaseEventsProcess

	public partial class SysUserSession_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

