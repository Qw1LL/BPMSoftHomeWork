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
	using BPMSoft.Core.Store;
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

	#region Class: ActivityParticipantRoleSchema

	/// <exclude/>
	public class ActivityParticipantRoleSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public ActivityParticipantRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityParticipantRoleSchema(ActivityParticipantRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityParticipantRoleSchema(ActivityParticipantRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("01e72783-64d7-4fac-9d9a-1648eacd51c9");
			RealUId = new Guid("01e72783-64d7-4fac-9d9a-1648eacd51c9");
			Name = "ActivityParticipantRole";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d5a7ef71-6903-49c6-895f-378c283b75c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivityParticipantRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityParticipantRole_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityParticipantRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityParticipantRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("01e72783-64d7-4fac-9d9a-1648eacd51c9"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityParticipantRole

	/// <summary>
	/// Activity participant roles.
	/// </summary>
	public class ActivityParticipantRole : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public ActivityParticipantRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityParticipantRole";
		}

		public ActivityParticipantRole(ActivityParticipantRole source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityParticipantRole_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityParticipantRoleDeleted", e);
			Deleting += (s, e) => ThrowEvent("ActivityParticipantRoleDeleting", e);
			Inserted += (s, e) => ThrowEvent("ActivityParticipantRoleInserted", e);
			Inserting += (s, e) => ThrowEvent("ActivityParticipantRoleInserting", e);
			Saved += (s, e) => ThrowEvent("ActivityParticipantRoleSaved", e);
			Saving += (s, e) => ThrowEvent("ActivityParticipantRoleSaving", e);
			Validating += (s, e) => ThrowEvent("ActivityParticipantRoleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityParticipantRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityParticipantRole_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityParticipantRole_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : ActivityParticipantRole
	{

		public ActivityParticipantRole_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityParticipantRole_BaseEventsProcess";
			SchemaUId = new Guid("01e72783-64d7-4fac-9d9a-1648eacd51c9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("01e72783-64d7-4fac-9d9a-1648eacd51c9");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _activityParticipantRoleSaveProcess;
		public ProcessFlowElement ActivityParticipantRoleSaveProcess {
			get {
				return _activityParticipantRoleSaveProcess ?? (_activityParticipantRoleSaveProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ActivityParticipantRoleSaveProcess",
					SchemaElementUId = new Guid("184fdae1-05ce-46e2-ba70-1f052396e59b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityParticipantRoleSavedStartMessage;
		public ProcessFlowElement ActivityParticipantRoleSavedStartMessage {
			get {
				return _activityParticipantRoleSavedStartMessage ?? (_activityParticipantRoleSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityParticipantRoleSavedStartMessage",
					SchemaElementUId = new Guid("4ded59b0-8609-4308-bfea-050579fe32a5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _activityParticipantRoleSavedDeletedScriptTask;
		public ProcessScriptTask ActivityParticipantRoleSavedDeletedScriptTask {
			get {
				return _activityParticipantRoleSavedDeletedScriptTask ?? (_activityParticipantRoleSavedDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivityParticipantRoleSavedDeletedScriptTask",
					SchemaElementUId = new Guid("f47261a0-0e29-4132-9697-abf8e298e847"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivityParticipantRoleSavedDeletedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _activityParticipantRoleDeletingStartMessage;
		public ProcessFlowElement ActivityParticipantRoleDeletingStartMessage {
			get {
				return _activityParticipantRoleDeletingStartMessage ?? (_activityParticipantRoleDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityParticipantRoleDeletingStartMessage",
					SchemaElementUId = new Guid("2013cf05-aab6-4b24-84c4-47dd78b470b0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[ActivityParticipantRoleSaveProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityParticipantRoleSaveProcess };
			FlowElements[ActivityParticipantRoleSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityParticipantRoleSavedStartMessage };
			FlowElements[ActivityParticipantRoleSavedDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityParticipantRoleSavedDeletedScriptTask };
			FlowElements[ActivityParticipantRoleDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityParticipantRoleDeletingStartMessage };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "ActivityParticipantRoleSaveProcess":
						break;
					case "ActivityParticipantRoleSavedStartMessage":
						e.Context.QueueTasks.Enqueue("ActivityParticipantRoleSavedDeletedScriptTask");
						break;
					case "ActivityParticipantRoleSavedDeletedScriptTask":
						break;
					case "ActivityParticipantRoleDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("ActivityParticipantRoleSavedDeletedScriptTask");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ActivityParticipantRoleSavedStartMessage");
			ActivatedEventElements.Add("ActivityParticipantRoleDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "ActivityParticipantRoleSaveProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ActivityParticipantRoleSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityParticipantRoleSavedStartMessage";
					result = ActivityParticipantRoleSavedStartMessage.Execute(context);
					break;
				case "ActivityParticipantRoleSavedDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityParticipantRoleSavedDeletedScriptTask";
					result = ActivityParticipantRoleSavedDeletedScriptTask.Execute(context, ActivityParticipantRoleSavedDeletedScriptTaskExecute);
					break;
				case "ActivityParticipantRoleDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityParticipantRoleDeletingStartMessage";
					result = ActivityParticipantRoleDeletingStartMessage.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ActivityParticipantRoleSavedDeletedScriptTaskExecute(ProcessExecutingContext context) {
			ClearCache();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ActivityParticipantRoleSaved":
							if (ActivatedEventElements.Contains("ActivityParticipantRoleSavedStartMessage")) {
							context.QueueTasks.Enqueue("ActivityParticipantRoleSavedStartMessage");
						}
						break;
					case "ActivityParticipantRoleDeleting":
							if (ActivatedEventElements.Contains("ActivityParticipantRoleDeletingStartMessage")) {
							context.QueueTasks.Enqueue("ActivityParticipantRoleDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityParticipantRole_BaseEventsProcess

	/// <exclude/>
	public class ActivityParticipantRole_BaseEventsProcess : ActivityParticipantRole_BaseEventsProcess<ActivityParticipantRole>
	{

		public ActivityParticipantRole_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityParticipantRole_BaseEventsProcess

	public partial class ActivityParticipantRole_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void ClearCache() {
			ActivityUtils.ClearActivityCache(UserConnection);
		}

		#endregion

	}

	#endregion


	#region Class: ActivityParticipantRoleEventsProcess

	/// <exclude/>
	public class ActivityParticipantRoleEventsProcess : ActivityParticipantRole_BaseEventsProcess
	{

		public ActivityParticipantRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

