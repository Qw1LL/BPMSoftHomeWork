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

	#region Class: ActivityTypeSchema

	/// <exclude/>
	public class ActivityTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public ActivityTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityTypeSchema(ActivityTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityTypeSchema(ActivityTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7");
			RealUId = new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7");
			Name = "ActivityType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateTypeImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.None;
			column.ModifiedInSchemaUId = new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTypeImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("b4265a4b-144c-40ca-9489-88fd5a46eb29"),
				Name = @"TypeImage",
				CreatedInSchemaUId = new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7"),
				ModifiedInSchemaUId = new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7"),
				CreatedInPackageId = new Guid("d8b043ab-1ada-4e1f-9921-a7610c352117")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivityType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityType

	/// <summary>
	/// Activity type.
	/// </summary>
	/// <remarks>
	/// Activity type.
	/// </remarks>
	public class ActivityType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public ActivityType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityType";
		}

		public ActivityType(ActivityType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("ActivityTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("ActivityTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("ActivityTypeInserting", e);
			Saved += (s, e) => ThrowEvent("ActivityTypeSaved", e);
			Saving += (s, e) => ThrowEvent("ActivityTypeSaving", e);
			Validating += (s, e) => ThrowEvent("ActivityTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityType_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : ActivityType
	{

		public ActivityType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityType_BaseEventsProcess";
			SchemaUId = new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _activityTypeEventSubProcess;
		public ProcessFlowElement ActivityTypeEventSubProcess {
			get {
				return _activityTypeEventSubProcess ?? (_activityTypeEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ActivityTypeEventSubProcess",
					SchemaElementUId = new Guid("9fe683cb-ed35-4cf1-b245-2774cac282b7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityTypeSavedStartMessage;
		public ProcessFlowElement ActivityTypeSavedStartMessage {
			get {
				return _activityTypeSavedStartMessage ?? (_activityTypeSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityTypeSavedStartMessage",
					SchemaElementUId = new Guid("9b860427-90b7-4fce-b19a-62f426910cef"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityTypeDeletingStartMessage;
		public ProcessFlowElement ActivityTypeDeletingStartMessage {
			get {
				return _activityTypeDeletingStartMessage ?? (_activityTypeDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityTypeDeletingStartMessage",
					SchemaElementUId = new Guid("fe7f1c36-210b-4bd4-a5b2-ebdfa13e54f8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _activityTypeSavedDeletingScriptTask;
		public ProcessScriptTask ActivityTypeSavedDeletingScriptTask {
			get {
				return _activityTypeSavedDeletingScriptTask ?? (_activityTypeSavedDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivityTypeSavedDeletingScriptTask",
					SchemaElementUId = new Guid("eff0df94-7003-4479-bb66-21f7f04e96e7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivityTypeSavedDeletingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[ActivityTypeEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityTypeEventSubProcess };
			FlowElements[ActivityTypeSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityTypeSavedStartMessage };
			FlowElements[ActivityTypeDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityTypeDeletingStartMessage };
			FlowElements[ActivityTypeSavedDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityTypeSavedDeletingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "ActivityTypeEventSubProcess":
						break;
					case "ActivityTypeSavedStartMessage":
						e.Context.QueueTasks.Enqueue("ActivityTypeSavedDeletingScriptTask");
						break;
					case "ActivityTypeDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("ActivityTypeSavedDeletingScriptTask");
						break;
					case "ActivityTypeSavedDeletingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ActivityTypeSavedStartMessage");
			ActivatedEventElements.Add("ActivityTypeDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "ActivityTypeEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ActivityTypeSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityTypeSavedStartMessage";
					result = ActivityTypeSavedStartMessage.Execute(context);
					break;
				case "ActivityTypeDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityTypeDeletingStartMessage";
					result = ActivityTypeDeletingStartMessage.Execute(context);
					break;
				case "ActivityTypeSavedDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityTypeSavedDeletingScriptTask";
					result = ActivityTypeSavedDeletingScriptTask.Execute(context, ActivityTypeSavedDeletingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ActivityTypeSavedDeletingScriptTaskExecute(ProcessExecutingContext context) {
			ClearCache();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ActivityTypeSaved":
							if (ActivatedEventElements.Contains("ActivityTypeSavedStartMessage")) {
							context.QueueTasks.Enqueue("ActivityTypeSavedStartMessage");
						}
						break;
					case "ActivityTypeDeleting":
							if (ActivatedEventElements.Contains("ActivityTypeDeletingStartMessage")) {
							context.QueueTasks.Enqueue("ActivityTypeDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityType_BaseEventsProcess

	/// <exclude/>
	public class ActivityType_BaseEventsProcess : ActivityType_BaseEventsProcess<ActivityType>
	{

		public ActivityType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityType_BaseEventsProcess

	public partial class ActivityType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void ClearCache() {
			ActivityUtils.ClearActivityCache(UserConnection);
		}

		#endregion

	}

	#endregion


	#region Class: ActivityTypeEventsProcess

	/// <exclude/>
	public class ActivityTypeEventsProcess : ActivityType_BaseEventsProcess
	{

		public ActivityTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

