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

	#region Class: VwSysSSPEntitySchemaAccessList_Base_BPMSoftSchema

	/// <exclude/>
	public class VwSysSSPEntitySchemaAccessList_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysSSPEntitySchemaAccessList_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysSSPEntitySchemaAccessList_Base_BPMSoftSchema(VwSysSSPEntitySchemaAccessList_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysSSPEntitySchemaAccessList_Base_BPMSoftSchema(VwSysSSPEntitySchemaAccessList_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			RealUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			Name = "VwSysSSPEntitySchemaAccessList_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("317015be-6ee9-410c-9498-b07b82cfb6f3")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("4fa3d6c4-bcbe-4a4f-b36d-de76dd97e2a9")) == null) {
				Columns.Add(CreateWorkspaceIdColumn());
			}
			if (Columns.FindByUId(new Guid("229a3213-ff4e-4e32-a76d-b1098b341659")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("317015be-6ee9-410c-9498-b07b82cfb6f3"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51"),
				ModifiedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateWorkspaceIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4fa3d6c4-bcbe-4a4f-b36d-de76dd97e2a9"),
				Name = @"WorkspaceId",
				CreatedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51"),
				ModifiedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("229a3213-ff4e-4e32-a76d-b1098b341659"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51"),
				ModifiedInSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51"),
				CreatedInPackageId = new Guid("6bf5758c-66bd-49a0-954e-ca6d0303eb69")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysSSPEntitySchemaAccessList_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysSSPEntitySchemaAccessList_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysSSPEntitySchemaAccessList_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysSSPEntitySchemaAccessList_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSSPEntitySchemaAccessList_Base_BPMSoft

	/// <summary>
	/// SSP Entity Schema Access List (View).
	/// </summary>
	public class VwSysSSPEntitySchemaAccessList_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysSSPEntitySchemaAccessList_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSSPEntitySchemaAccessList_Base_BPMSoft";
		}

		public VwSysSSPEntitySchemaAccessList_Base_BPMSoft(VwSysSSPEntitySchemaAccessList_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object Id.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Workspace Id.
		/// </summary>
		public Guid WorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("WorkspaceId");
			}
			set {
				SetColumnValue("WorkspaceId", value);
			}
		}

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Object.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysSSPEntitySchemaAccessList_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysSSPEntitySchemaAccessList_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysSSPEntitySchemaAccessList_Base_BPMSoftDeleting", e);
			Inserting += (s, e) => ThrowEvent("VwSysSSPEntitySchemaAccessList_Base_BPMSoftInserting", e);
			Saving += (s, e) => ThrowEvent("VwSysSSPEntitySchemaAccessList_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysSSPEntitySchemaAccessList_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysSSPEntitySchemaAccessList_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSSPEntitySchemaAccessList_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysSSPEntitySchemaAccessList_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysSSPEntitySchemaAccessList_Base_BPMSoft
	{

		public VwSysSSPEntitySchemaAccessList_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysSSPEntitySchemaAccessList_BaseEventsProcess";
			SchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _vwSysSSPEntitySchemaAccessListEventSubProcess;
		public ProcessFlowElement VwSysSSPEntitySchemaAccessListEventSubProcess {
			get {
				return _vwSysSSPEntitySchemaAccessListEventSubProcess ?? (_vwSysSSPEntitySchemaAccessListEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "VwSysSSPEntitySchemaAccessListEventSubProcess",
					SchemaElementUId = new Guid("8fdb7ac9-5be7-4e92-b456-de15dee14d03"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwSysSSPEntitySchemaAccessListInsertingStartMessage;
		public ProcessFlowElement VwSysSSPEntitySchemaAccessListInsertingStartMessage {
			get {
				return _vwSysSSPEntitySchemaAccessListInsertingStartMessage ?? (_vwSysSSPEntitySchemaAccessListInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysSSPEntitySchemaAccessListInsertingStartMessage",
					SchemaElementUId = new Guid("7271bffd-7aa3-47d4-907c-5c1b48e32645"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwSysSSPEntitySchemaAccessListSavingStartMessage;
		public ProcessFlowElement VwSysSSPEntitySchemaAccessListSavingStartMessage {
			get {
				return _vwSysSSPEntitySchemaAccessListSavingStartMessage ?? (_vwSysSSPEntitySchemaAccessListSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysSSPEntitySchemaAccessListSavingStartMessage",
					SchemaElementUId = new Guid("80b414d7-268c-437c-8d22-17d4a0a7aa2d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwSysSSPEntitySchemaAccessListDeletingStartMessage;
		public ProcessFlowElement VwSysSSPEntitySchemaAccessListDeletingStartMessage {
			get {
				return _vwSysSSPEntitySchemaAccessListDeletingStartMessage ?? (_vwSysSSPEntitySchemaAccessListDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysSSPEntitySchemaAccessListDeletingStartMessage",
					SchemaElementUId = new Guid("e0153570-d317-41d5-b04a-fc49842828d0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkCanManageLookupsScriptTask;
		public ProcessScriptTask CheckCanManageLookupsScriptTask {
			get {
				return _checkCanManageLookupsScriptTask ?? (_checkCanManageLookupsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckCanManageLookupsScriptTask",
					SchemaElementUId = new Guid("866a0395-7f15-4d45-a855-3b679bf72692"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckCanManageLookupsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[VwSysSSPEntitySchemaAccessListEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysSSPEntitySchemaAccessListEventSubProcess };
			FlowElements[VwSysSSPEntitySchemaAccessListInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysSSPEntitySchemaAccessListInsertingStartMessage };
			FlowElements[VwSysSSPEntitySchemaAccessListSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysSSPEntitySchemaAccessListSavingStartMessage };
			FlowElements[VwSysSSPEntitySchemaAccessListDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysSSPEntitySchemaAccessListDeletingStartMessage };
			FlowElements[CheckCanManageLookupsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckCanManageLookupsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "VwSysSSPEntitySchemaAccessListEventSubProcess":
						break;
					case "VwSysSSPEntitySchemaAccessListInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "VwSysSSPEntitySchemaAccessListSavingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "VwSysSSPEntitySchemaAccessListDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "CheckCanManageLookupsScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("VwSysSSPEntitySchemaAccessListInsertingStartMessage");
			ActivatedEventElements.Add("VwSysSSPEntitySchemaAccessListSavingStartMessage");
			ActivatedEventElements.Add("VwSysSSPEntitySchemaAccessListDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "VwSysSSPEntitySchemaAccessListEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "VwSysSSPEntitySchemaAccessListInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysSSPEntitySchemaAccessListInsertingStartMessage";
					result = VwSysSSPEntitySchemaAccessListInsertingStartMessage.Execute(context);
					break;
				case "VwSysSSPEntitySchemaAccessListSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysSSPEntitySchemaAccessListSavingStartMessage";
					result = VwSysSSPEntitySchemaAccessListSavingStartMessage.Execute(context);
					break;
				case "VwSysSSPEntitySchemaAccessListDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysSSPEntitySchemaAccessListDeletingStartMessage";
					result = VwSysSSPEntitySchemaAccessListDeletingStartMessage.Execute(context);
					break;
				case "CheckCanManageLookupsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckCanManageLookupsScriptTask";
					result = CheckCanManageLookupsScriptTask.Execute(context, CheckCanManageLookupsScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CheckCanManageLookupsScriptTaskExecute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageLookups");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "VwSysSSPEntitySchemaAccessList_Base_BPMSoftInserting":
							if (ActivatedEventElements.Contains("VwSysSSPEntitySchemaAccessListInsertingStartMessage")) {
							context.QueueTasks.Enqueue("VwSysSSPEntitySchemaAccessListInsertingStartMessage");
						}
						break;
					case "VwSysSSPEntitySchemaAccessList_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("VwSysSSPEntitySchemaAccessListSavingStartMessage")) {
							context.QueueTasks.Enqueue("VwSysSSPEntitySchemaAccessListSavingStartMessage");
						}
						break;
					case "VwSysSSPEntitySchemaAccessList_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("VwSysSSPEntitySchemaAccessListDeletingStartMessage")) {
							context.QueueTasks.Enqueue("VwSysSSPEntitySchemaAccessListDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSSPEntitySchemaAccessList_BaseEventsProcess

	/// <exclude/>
	public class VwSysSSPEntitySchemaAccessList_BaseEventsProcess : VwSysSSPEntitySchemaAccessList_BaseEventsProcess<VwSysSSPEntitySchemaAccessList_Base_BPMSoft>
	{

		public VwSysSSPEntitySchemaAccessList_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysSSPEntitySchemaAccessList_BaseEventsProcess

	public partial class VwSysSSPEntitySchemaAccessList_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

