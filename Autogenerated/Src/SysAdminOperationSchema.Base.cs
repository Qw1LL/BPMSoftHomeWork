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

	#region Class: SysAdminOperationSchema

	/// <exclude/>
	public class SysAdminOperationSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysAdminOperationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminOperationSchema(SysAdminOperationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminOperationSchema(SysAdminOperationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638");
			RealUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638");
			Name = "SysAdminOperation";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2aec9cef-232e-413a-9a5a-9ddde2e8a2af")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("a2987d84-12ca-4f95-a27f-54d1cfc2517d")) == null) {
				Columns.Add(CreateSysFolderColumn());
			}
			if (Columns.FindByUId(new Guid("ea5c0817-d558-42ef-a5f9-9379560f16f1")) == null) {
				Columns.Add(CreateUseSystemOperationRestrictionsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2aec9cef-232e-413a-9a5a-9ddde2e8a2af"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"),
				ModifiedInSchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a2987d84-12ca-4f95-a27f-54d1cfc2517d"),
				Name = @"SysFolder",
				ReferenceSchemaUId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd"),
				CreatedInSchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"),
				ModifiedInSchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateUseSystemOperationRestrictionsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ea5c0817-d558-42ef-a5f9-9379560f16f1"),
				Name = @"UseSystemOperationRestrictions",
				CreatedInSchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"),
				ModifiedInSchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"),
				CreatedInPackageId = new Guid("90e8157f-4651-4349-83a7-f0455fc70915")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminOperation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminOperation_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminOperationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminOperationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminOperation

	/// <summary>
	/// Administrated operation.
	/// </summary>
	public class SysAdminOperation : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysAdminOperation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminOperation";
		}

		public SysAdminOperation(SysAdminOperation source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <exclude/>
		public Guid SysFolderId {
			get {
				return GetTypedColumnValue<Guid>("SysFolderId");
			}
			set {
				SetColumnValue("SysFolderId", value);
				_sysFolder = null;
			}
		}

		/// <exclude/>
		public string SysFolderName {
			get {
				return GetTypedColumnValue<string>("SysFolderName");
			}
			set {
				SetColumnValue("SysFolderName", value);
				if (_sysFolder != null) {
					_sysFolder.Name = value;
				}
			}
		}

		private SysAdminOperationFolder _sysFolder;
		/// <summary>
		/// Folder.
		/// </summary>
		public SysAdminOperationFolder SysFolder {
			get {
				return _sysFolder ??
					(_sysFolder = LookupColumnEntities.GetEntity("SysFolder") as SysAdminOperationFolder);
			}
		}

		/// <summary>
		/// Use restrictions on operations by system.
		/// </summary>
		public bool UseSystemOperationRestrictions {
			get {
				return GetTypedColumnValue<bool>("UseSystemOperationRestrictions");
			}
			set {
				SetColumnValue("UseSystemOperationRestrictions", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminOperation_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysAdminOperationDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysAdminOperationDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysAdminOperationInserted", e);
			Inserting += (s, e) => ThrowEvent("SysAdminOperationInserting", e);
			Loading += (s, e) => ThrowEvent("SysAdminOperationLoading", e);
			Saved += (s, e) => ThrowEvent("SysAdminOperationSaved", e);
			Saving += (s, e) => ThrowEvent("SysAdminOperationSaving", e);
			Validating += (s, e) => ThrowEvent("SysAdminOperationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminOperation(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminOperation_BaseEventsProcess

	/// <exclude/>
	public partial class SysAdminOperation_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SysAdminOperation
	{

		public SysAdminOperation_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminOperation_BaseEventsProcess";
			SchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _sysAdminOperationEventSubProcess;
		public ProcessFlowElement SysAdminOperationEventSubProcess {
			get {
				return _sysAdminOperationEventSubProcess ?? (_sysAdminOperationEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysAdminOperationEventSubProcess",
					SchemaElementUId = new Guid("bef2c72a-43c9-4ff2-801c-e7f14cf2a523"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseSysAdminOperationSavingStartMessage;
		public ProcessFlowElement BaseSysAdminOperationSavingStartMessage {
			get {
				return _baseSysAdminOperationSavingStartMessage ?? (_baseSysAdminOperationSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseSysAdminOperationSavingStartMessage",
					SchemaElementUId = new Guid("b74e3c6a-9096-48b4-81c9-76578e09e044"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseSysAdminOperationInsertingStartMessage;
		public ProcessFlowElement BaseSysAdminOperationInsertingStartMessage {
			get {
				return _baseSysAdminOperationInsertingStartMessage ?? (_baseSysAdminOperationInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseSysAdminOperationInsertingStartMessage",
					SchemaElementUId = new Guid("06f042a4-4f3d-42fc-8a64-1a783fab322a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseSysAdminOperationDeletingStartMessage;
		public ProcessFlowElement BaseSysAdminOperationDeletingStartMessage {
			get {
				return _baseSysAdminOperationDeletingStartMessage ?? (_baseSysAdminOperationDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseSysAdminOperationDeletingStartMessage",
					SchemaElementUId = new Guid("9e3085f1-6ddd-40e6-baf8-9bebd9ab1fe4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseSysAdminOperationLoadingStartMessage;
		public ProcessFlowElement BaseSysAdminOperationLoadingStartMessage {
			get {
				return _baseSysAdminOperationLoadingStartMessage ?? (_baseSysAdminOperationLoadingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseSysAdminOperationLoadingStartMessage",
					SchemaElementUId = new Guid("73cbb533-a610-4648-abe4-79177b431a56"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseSysAdminOperationCheckCanChangeScriptTask;
		public ProcessScriptTask BaseSysAdminOperationCheckCanChangeScriptTask {
			get {
				return _baseSysAdminOperationCheckCanChangeScriptTask ?? (_baseSysAdminOperationCheckCanChangeScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseSysAdminOperationCheckCanChangeScriptTask",
					SchemaElementUId = new Guid("be2e37ec-dffe-42a8-8e77-5ef077924294"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseSysAdminOperationCheckCanChangeScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _baseSysAdminOperationCheckCanReadScriptTask;
		public ProcessScriptTask BaseSysAdminOperationCheckCanReadScriptTask {
			get {
				return _baseSysAdminOperationCheckCanReadScriptTask ?? (_baseSysAdminOperationCheckCanReadScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseSysAdminOperationCheckCanReadScriptTask",
					SchemaElementUId = new Guid("35df9c08-0318-4108-b09a-ebd0b01d740b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseSysAdminOperationCheckCanReadScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SysAdminOperationEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminOperationEventSubProcess };
			FlowElements[BaseSysAdminOperationSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysAdminOperationSavingStartMessage };
			FlowElements[BaseSysAdminOperationInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysAdminOperationInsertingStartMessage };
			FlowElements[BaseSysAdminOperationDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysAdminOperationDeletingStartMessage };
			FlowElements[BaseSysAdminOperationLoadingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysAdminOperationLoadingStartMessage };
			FlowElements[BaseSysAdminOperationCheckCanChangeScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysAdminOperationCheckCanChangeScriptTask };
			FlowElements[BaseSysAdminOperationCheckCanReadScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysAdminOperationCheckCanReadScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SysAdminOperationEventSubProcess":
						break;
					case "BaseSysAdminOperationSavingStartMessage":
						e.Context.QueueTasks.Enqueue("BaseSysAdminOperationCheckCanChangeScriptTask");
						break;
					case "BaseSysAdminOperationInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("BaseSysAdminOperationCheckCanChangeScriptTask");
						break;
					case "BaseSysAdminOperationDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("BaseSysAdminOperationCheckCanChangeScriptTask");
						break;
					case "BaseSysAdminOperationLoadingStartMessage":
						e.Context.QueueTasks.Enqueue("BaseSysAdminOperationCheckCanReadScriptTask");
						break;
					case "BaseSysAdminOperationCheckCanChangeScriptTask":
						break;
					case "BaseSysAdminOperationCheckCanReadScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseSysAdminOperationSavingStartMessage");
			ActivatedEventElements.Add("BaseSysAdminOperationInsertingStartMessage");
			ActivatedEventElements.Add("BaseSysAdminOperationDeletingStartMessage");
			ActivatedEventElements.Add("BaseSysAdminOperationLoadingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SysAdminOperationEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseSysAdminOperationSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysAdminOperationSavingStartMessage";
					result = BaseSysAdminOperationSavingStartMessage.Execute(context);
					break;
				case "BaseSysAdminOperationInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysAdminOperationInsertingStartMessage";
					result = BaseSysAdminOperationInsertingStartMessage.Execute(context);
					break;
				case "BaseSysAdminOperationDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysAdminOperationDeletingStartMessage";
					result = BaseSysAdminOperationDeletingStartMessage.Execute(context);
					break;
				case "BaseSysAdminOperationLoadingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysAdminOperationLoadingStartMessage";
					result = BaseSysAdminOperationLoadingStartMessage.Execute(context);
					break;
				case "BaseSysAdminOperationCheckCanChangeScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysAdminOperationCheckCanChangeScriptTask";
					result = BaseSysAdminOperationCheckCanChangeScriptTask.Execute(context, BaseSysAdminOperationCheckCanChangeScriptTaskExecute);
					break;
				case "BaseSysAdminOperationCheckCanReadScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysAdminOperationCheckCanReadScriptTask";
					result = BaseSysAdminOperationCheckCanReadScriptTask.Execute(context, BaseSysAdminOperationCheckCanReadScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool BaseSysAdminOperationCheckCanChangeScriptTaskExecute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			return true;
		}

		public virtual bool BaseSysAdminOperationCheckCanReadScriptTaskExecute(ProcessExecutingContext context) {
			if (UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanViewConfiguration") ||
					UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanManageSysSettings")) {
				return true;
			}
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysAdminOperationSaving":
							if (ActivatedEventElements.Contains("BaseSysAdminOperationSavingStartMessage")) {
							context.QueueTasks.Enqueue("BaseSysAdminOperationSavingStartMessage");
						}
						break;
					case "SysAdminOperationInserting":
							if (ActivatedEventElements.Contains("BaseSysAdminOperationInsertingStartMessage")) {
							context.QueueTasks.Enqueue("BaseSysAdminOperationInsertingStartMessage");
						}
						break;
					case "SysAdminOperationDeleting":
							if (ActivatedEventElements.Contains("BaseSysAdminOperationDeletingStartMessage")) {
							context.QueueTasks.Enqueue("BaseSysAdminOperationDeletingStartMessage");
						}
						break;
					case "SysAdminOperationLoading":
							if (ActivatedEventElements.Contains("BaseSysAdminOperationLoadingStartMessage")) {
							context.QueueTasks.Enqueue("BaseSysAdminOperationLoadingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminOperation_BaseEventsProcess

	/// <exclude/>
	public class SysAdminOperation_BaseEventsProcess : SysAdminOperation_BaseEventsProcess<SysAdminOperation>
	{

		public SysAdminOperation_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminOperation_BaseEventsProcess

	public partial class SysAdminOperation_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion


	#region Class: SysAdminOperationEventsProcess

	/// <exclude/>
	public class SysAdminOperationEventsProcess : SysAdminOperation_BaseEventsProcess
	{

		public SysAdminOperationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

