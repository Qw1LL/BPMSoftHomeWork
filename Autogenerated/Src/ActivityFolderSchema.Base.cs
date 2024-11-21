namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: ActivityFolderSchema

	/// <exclude/>
	public class ActivityFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public ActivityFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityFolderSchema(ActivityFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityFolderSchema(ActivityFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			RealUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			Name = "ActivityFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6734071f-f02c-44b2-9b41-25d75036b663")) == null) {
				Columns.Add(CreateFolderEmbeddedProcessIdColumn());
			}
			if (Columns.FindByUId(new Guid("32fe519c-cd89-4c16-bb81-a8e67e86d0cb")) == null) {
				Columns.Add(CreateSynchronizeColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.ModifiedInSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateFolderEmbeddedProcessIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6734071f-f02c-44b2-9b41-25d75036b663"),
				Name = @"FolderEmbeddedProcessId",
				CreatedInSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f"),
				ModifiedInSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSynchronizeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("32fe519c-cd89-4c16-bb81-a8e67e86d0cb"),
				Name = @"Synchronize",
				CreatedInSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f"),
				ModifiedInSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivityFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("31464792-6754-447f-83ae-90a1b468c29f"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityFolder

	/// <summary>
	/// Группа активности.
	/// </summary>
	public class ActivityFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public ActivityFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityFolder";
		}

		public ActivityFolder(ActivityFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private ActivityFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public ActivityFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as ActivityFolder);
			}
		}

		/// <summary>
		/// Процесс папки.
		/// </summary>
		public Guid FolderEmbeddedProcessId {
			get {
				return GetTypedColumnValue<Guid>("FolderEmbeddedProcessId");
			}
			set {
				SetColumnValue("FolderEmbeddedProcessId", value);
			}
		}

		/// <summary>
		/// Синхронизировать.
		/// </summary>
		public bool Synchronize {
			get {
				return GetTypedColumnValue<bool>("Synchronize");
			}
			set {
				SetColumnValue("Synchronize", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("ActivityFolderDeleting", e);
			Inserting += (s, e) => ThrowEvent("ActivityFolderInserting", e);
			Validating += (s, e) => ThrowEvent("ActivityFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityFolder_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : ActivityFolder
	{

		public ActivityFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityFolder_BaseEventsProcess";
			SchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual int EntityStoringStateBeforeSave {
			get;
			set;
		}

		public virtual string ActivityFolderOldNameBeforeSave {
			get;
			set;
		}

		private ProcessFlowElement _deleteEventSubProcess;
		public ProcessFlowElement DeleteEventSubProcess {
			get {
				return _deleteEventSubProcess ?? (_deleteEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "DeleteEventSubProcess",
					SchemaElementUId = new Guid("2110d011-28c4-4993-9aa0-c3ead6a4b0bb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityFolderDeleting;
		public ProcessFlowElement ActivityFolderDeleting {
			get {
				return _activityFolderDeleting ?? (_activityFolderDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityFolderDeleting",
					SchemaElementUId = new Guid("ad478654-bb12-40b3-9e8f-a1091ff2be78"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _activityFolderDeletingScriptTask;
		public ProcessScriptTask ActivityFolderDeletingScriptTask {
			get {
				return _activityFolderDeletingScriptTask ?? (_activityFolderDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivityFolderDeletingScriptTask",
					SchemaElementUId = new Guid("6c73982b-a75e-4e03-ab6f-0fe5474db902"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivityFolderDeletingScriptTaskExecute,
				});
			}
		}

		private LocalizableString _sameFolderAlreadyExistLS;
		public LocalizableString SameFolderAlreadyExistLS {
			get {
				return _sameFolderAlreadyExistLS ?? (_sameFolderAlreadyExistLS = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.SameFolderAlreadyExistLS.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[DeleteEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { DeleteEventSubProcess };
			FlowElements[ActivityFolderDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityFolderDeleting };
			FlowElements[ActivityFolderDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityFolderDeletingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "DeleteEventSubProcess":
						break;
					case "ActivityFolderDeleting":
						e.Context.QueueTasks.Enqueue("ActivityFolderDeletingScriptTask");
						break;
					case "ActivityFolderDeletingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ActivityFolderDeleting");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "DeleteEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ActivityFolderDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityFolderDeleting";
					result = ActivityFolderDeleting.Execute(context);
					break;
				case "ActivityFolderDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityFolderDeletingScriptTask";
					result = ActivityFolderDeletingScriptTask.Execute(context, ActivityFolderDeletingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ActivityFolderDeletingScriptTaskExecute(ProcessExecutingContext context) {
			if (Entity.FolderTypeId == FolderConsts.MailboxFolderTypeId) {
				var parameters = new Dictionary<string, object> {
							{ "SenderEmailAddress", Entity.Name },
							{ "CurrentUserId", UserConnection.CurrentUser.Id }
						};
				var scheduler = ClassFactory.Get<BPMSoft.Mail.IImapSyncJobScheduler>();
				scheduler.RemoveSyncJob(UserConnection, parameters);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ActivityFolderDeleting":
							if (ActivatedEventElements.Contains("ActivityFolderDeleting")) {
							context.QueueTasks.Enqueue("ActivityFolderDeleting");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityFolder_BaseEventsProcess

	/// <exclude/>
	public class ActivityFolder_BaseEventsProcess : ActivityFolder_BaseEventsProcess<ActivityFolder>
	{

		public ActivityFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: ActivityFolderEventsProcess

	/// <exclude/>
	public class ActivityFolderEventsProcess : ActivityFolder_BaseEventsProcess
	{

		public ActivityFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

