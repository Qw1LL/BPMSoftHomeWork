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

	#region Class: BaseLookupSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseLookupSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseLookupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseLookupSchema(BaseLookupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseLookupSchema(BaseLookupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			RealUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			Name = "BaseLookup";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9e53fd7c-dde4-4502-a64c-b9e34148108b")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("736c30a7-c0ec-4fa9-b034-2552b319b633"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75"),
				ModifiedInSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9e53fd7c-dde4-4502-a64c-b9e34148108b"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75"),
				ModifiedInSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseLookup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseLookup_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseLookupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseLookupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseLookup

	/// <summary>
	/// Base lookup.
	/// </summary>
	public class BaseLookup : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseLookup";
		}

		public BaseLookup(BaseLookup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseLookup_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseLookupDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseLookupDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseLookupInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseLookupInserting", e);
			Saved += (s, e) => ThrowEvent("BaseLookupSaved", e);
			Saving += (s, e) => ThrowEvent("BaseLookupSaving", e);
			Validating += (s, e) => ThrowEvent("BaseLookupValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseLookup(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseLookup_BaseEventsProcess

	/// <exclude/>
	public partial class BaseLookup_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseLookup
	{

		public BaseLookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseLookup_BaseEventsProcess";
			SchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _baseLookupEventSubProcess;
		public ProcessFlowElement BaseLookupEventSubProcess {
			get {
				return _baseLookupEventSubProcess ?? (_baseLookupEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseLookupEventSubProcess",
					SchemaElementUId = new Guid("e57d317f-6f21-48a8-9999-5ecf05719145"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseLookupInsertingStartMessage;
		public ProcessFlowElement BaseLookupInsertingStartMessage {
			get {
				return _baseLookupInsertingStartMessage ?? (_baseLookupInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseLookupInsertingStartMessage",
					SchemaElementUId = new Guid("9f186c66-1b04-4f3f-a712-2aadefc904c7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseLookupSavingStartMessage;
		public ProcessFlowElement BaseLookupSavingStartMessage {
			get {
				return _baseLookupSavingStartMessage ?? (_baseLookupSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseLookupSavingStartMessage",
					SchemaElementUId = new Guid("48ed15e5-1285-49c5-8946-0344c7a15bbe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseLookupDeletingStartMessage;
		public ProcessFlowElement BaseLookupDeletingStartMessage {
			get {
				return _baseLookupDeletingStartMessage ?? (_baseLookupDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseLookupDeletingStartMessage",
					SchemaElementUId = new Guid("e0bb263d-5a8e-4ea3-a9e2-c824eb9ec5aa"),
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
					SchemaElementUId = new Guid("bdca0c6b-eb97-4d14-83df-aa53b214c463"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckCanManageLookupsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BaseLookupEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseLookupEventSubProcess };
			FlowElements[BaseLookupInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseLookupInsertingStartMessage };
			FlowElements[BaseLookupSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseLookupSavingStartMessage };
			FlowElements[BaseLookupDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseLookupDeletingStartMessage };
			FlowElements[CheckCanManageLookupsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckCanManageLookupsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BaseLookupEventSubProcess":
						break;
					case "BaseLookupInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "BaseLookupSavingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "BaseLookupDeletingStartMessage":
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
			ActivatedEventElements.Add("BaseLookupInsertingStartMessage");
			ActivatedEventElements.Add("BaseLookupSavingStartMessage");
			ActivatedEventElements.Add("BaseLookupDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BaseLookupEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseLookupInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseLookupInsertingStartMessage";
					result = BaseLookupInsertingStartMessage.Execute(context);
					break;
				case "BaseLookupSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseLookupSavingStartMessage";
					result = BaseLookupSavingStartMessage.Execute(context);
					break;
				case "BaseLookupDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseLookupDeletingStartMessage";
					result = BaseLookupDeletingStartMessage.Execute(context);
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
			CheckCanManageLookups();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BaseLookupInserting":
							if (ActivatedEventElements.Contains("BaseLookupInsertingStartMessage")) {
							context.QueueTasks.Enqueue("BaseLookupInsertingStartMessage");
						}
						break;
					case "BaseLookupSaving":
							if (ActivatedEventElements.Contains("BaseLookupSavingStartMessage")) {
							context.QueueTasks.Enqueue("BaseLookupSavingStartMessage");
						}
						break;
					case "BaseLookupDeleting":
							if (ActivatedEventElements.Contains("BaseLookupDeletingStartMessage")) {
							context.QueueTasks.Enqueue("BaseLookupDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: BaseLookup_BaseEventsProcess

	/// <exclude/>
	public class BaseLookup_BaseEventsProcess : BaseLookup_BaseEventsProcess<BaseLookup>
	{

		public BaseLookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseLookup_BaseEventsProcess

	public partial class BaseLookup_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CheckCanManageLookups() {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageLookups");
		}

		#endregion

	}

	#endregion


	#region Class: BaseLookupEventsProcess

	/// <exclude/>
	public class BaseLookupEventsProcess : BaseLookup_BaseEventsProcess
	{

		public BaseLookupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

