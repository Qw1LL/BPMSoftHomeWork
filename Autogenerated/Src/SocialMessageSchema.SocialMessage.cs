namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.ESN;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Messaging.Common;
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
	using System.Security;
	using System.Text.RegularExpressions;

	#region Class: SocialMessageSchema

	/// <exclude/>
	public class SocialMessageSchema : BPMSoft.Configuration.SocialMessage_ESN_BPMSoftSchema
	{

		#region Constructors: Public

		public SocialMessageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialMessageSchema(SocialMessageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialMessageSchema(SocialMessageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("484d4617-cde2-455d-93d8-98f58bf85cbb");
			Name = "SocialMessage";
			ParentSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			ExtendParent = true;
			CreatedInPackageId = new Guid("54cf5269-6f00-4e87-a6e6-8261561e21be");
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
			return new SocialMessage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialMessage_SocialMessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialMessageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialMessageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("484d4617-cde2-455d-93d8-98f58bf85cbb"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialMessage

	/// <summary>
	/// Сообщение/комментарий.
	/// </summary>
	public class SocialMessage : BPMSoft.Configuration.SocialMessage_ESN_BPMSoft
	{

		#region Constructors: Public

		public SocialMessage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialMessage";
		}

		public SocialMessage(SocialMessage source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialMessage_SocialMessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("SocialMessageInserted", e);
			Saved += (s, e) => ThrowEvent("SocialMessageSaved", e);
			Updated += (s, e) => ThrowEvent("SocialMessageUpdated", e);
			Validating += (s, e) => ThrowEvent("SocialMessageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialMessage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialMessage_SocialMessageEventsProcess

	/// <exclude/>
	public partial class SocialMessage_SocialMessageEventsProcess<TEntity> : BPMSoft.Configuration.SocialMessage_ESNEventsProcess<TEntity> where TEntity : SocialMessage
	{

		public SocialMessage_SocialMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialMessage_SocialMessageEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("484d4617-cde2-455d-93d8-98f58bf85cbb");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _socialMessageEventSubProcess1;
		public ProcessFlowElement SocialMessageEventSubProcess1 {
			get {
				return _socialMessageEventSubProcess1 ?? (_socialMessageEventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SocialMessageEventSubProcess1",
					SchemaElementUId = new Guid("eeb06647-78c1-4911-98dc-ffc6f020d7ee"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _socSocialMessageInsertedChildMessage;
		public ProcessFlowElement SocSocialMessageInsertedChildMessage {
			get {
				return _socSocialMessageInsertedChildMessage ?? (_socSocialMessageInsertedChildMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocSocialMessageInsertedChildMessage",
					SchemaElementUId = new Guid("db10de47-b4d3-4b8c-a001-f1dd2024cbfd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _socialMessageInsertedChildToParentMessage;
		public ProcessThrowMessageEvent SocialMessageInsertedChildToParentMessage {
			get {
				return _socialMessageInsertedChildToParentMessage ?? (_socialMessageInsertedChildToParentMessage = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SocialMessageInsertedChildToParentMessage",
					SchemaElementUId = new Guid("61b04ce4-a816-4c1c-83a9-f3dd518da3c1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SocialMessageInserted",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _notifyListenersScriptTask;
		public ProcessScriptTask NotifyListenersScriptTask {
			get {
				return _notifyListenersScriptTask ?? (_notifyListenersScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "NotifyListenersScriptTask",
					SchemaElementUId = new Guid("31a5ebf0-03a1-4fca-a0dc-68d97eb27d62"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = NotifyListenersScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _socialMessageEventSubProcessUpdate;
		public ProcessFlowElement SocialMessageEventSubProcessUpdate {
			get {
				return _socialMessageEventSubProcessUpdate ?? (_socialMessageEventSubProcessUpdate = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SocialMessageEventSubProcessUpdate",
					SchemaElementUId = new Guid("4e83c29d-9c37-4df3-a7e2-2c8a7161fd52"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _socialMessageUpdatedChildMessage;
		public ProcessFlowElement SocialMessageUpdatedChildMessage {
			get {
				return _socialMessageUpdatedChildMessage ?? (_socialMessageUpdatedChildMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialMessageUpdatedChildMessage",
					SchemaElementUId = new Guid("21ad5aad-f657-45ab-a37b-8954b8467253"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _socialMessageUpdatedChildToParentMessage;
		public ProcessThrowMessageEvent SocialMessageUpdatedChildToParentMessage {
			get {
				return _socialMessageUpdatedChildToParentMessage ?? (_socialMessageUpdatedChildToParentMessage = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SocialMessageUpdatedChildToParentMessage",
					SchemaElementUId = new Guid("7e8b2139-362c-4e7e-9819-1d9946850819"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SocialMessageUpdated",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _updateNotifyListenersScriptTaks;
		public ProcessScriptTask UpdateNotifyListenersScriptTaks {
			get {
				return _updateNotifyListenersScriptTaks ?? (_updateNotifyListenersScriptTaks = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateNotifyListenersScriptTaks",
					SchemaElementUId = new Guid("fef7c93c-33b0-4b62-bb90-c20f27103d4f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateNotifyListenersScriptTaksExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SocialMessageEventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageEventSubProcess1 };
			FlowElements[SocSocialMessageInsertedChildMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocSocialMessageInsertedChildMessage };
			FlowElements[SocialMessageInsertedChildToParentMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageInsertedChildToParentMessage };
			FlowElements[NotifyListenersScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { NotifyListenersScriptTask };
			FlowElements[SocialMessageEventSubProcessUpdate.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageEventSubProcessUpdate };
			FlowElements[SocialMessageUpdatedChildMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageUpdatedChildMessage };
			FlowElements[SocialMessageUpdatedChildToParentMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageUpdatedChildToParentMessage };
			FlowElements[UpdateNotifyListenersScriptTaks.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateNotifyListenersScriptTaks };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SocialMessageEventSubProcess1":
						break;
					case "SocSocialMessageInsertedChildMessage":
						e.Context.QueueTasks.Enqueue("SocialMessageInsertedChildToParentMessage");
						break;
					case "SocialMessageInsertedChildToParentMessage":
						e.Context.QueueTasks.Enqueue("NotifyListenersScriptTask");
						break;
					case "NotifyListenersScriptTask":
						break;
					case "SocialMessageEventSubProcessUpdate":
						break;
					case "SocialMessageUpdatedChildMessage":
						e.Context.QueueTasks.Enqueue("SocialMessageUpdatedChildToParentMessage");
						break;
					case "SocialMessageUpdatedChildToParentMessage":
						e.Context.QueueTasks.Enqueue("UpdateNotifyListenersScriptTaks");
						break;
					case "UpdateNotifyListenersScriptTaks":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SocSocialMessageInsertedChildMessage");
			ActivatedEventElements.Add("SocialMessageUpdatedChildMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SocialMessageEventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "SocSocialMessageInsertedChildMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocSocialMessageInsertedChildMessage";
					result = SocSocialMessageInsertedChildMessage.Execute(context);
					break;
				case "SocialMessageInsertedChildToParentMessage":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "SocialMessageInserted");
					result = SocialMessageInsertedChildToParentMessage.Execute(context);
					break;
				case "NotifyListenersScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "NotifyListenersScriptTask";
					result = NotifyListenersScriptTask.Execute(context, NotifyListenersScriptTaskExecute);
					break;
				case "SocialMessageEventSubProcessUpdate":
					context.QueueTasks.Dequeue();
					break;
				case "SocialMessageUpdatedChildMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialMessageUpdatedChildMessage";
					result = SocialMessageUpdatedChildMessage.Execute(context);
					break;
				case "SocialMessageUpdatedChildToParentMessage":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "SocialMessageUpdated");
					result = SocialMessageUpdatedChildToParentMessage.Execute(context);
					break;
				case "UpdateNotifyListenersScriptTaks":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateNotifyListenersScriptTaks";
					result = UpdateNotifyListenersScriptTaks.Execute(context, UpdateNotifyListenersScriptTaksExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool NotifyListenersScriptTaskExecute(ProcessExecutingContext context) {
			var notifier = new SocialMessageNotifier(this.Entity);
			var manager = new MessageHistoryManager(UserConnection, notifier);
			manager.Notify();
			return true;
		}

		public virtual bool UpdateNotifyListenersScriptTaksExecute(ProcessExecutingContext context) {
			if (UserConnection.GetIsFeatureEnabled("CanUpdateHistoryMessage")) {
				var notifier = new SocialMessageNotifier(this.Entity);
				var manager = new MessageHistoryManager(UserConnection, notifier);
				manager.Notify();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SocialMessageInserted":
							if (ActivatedEventElements.Contains("SocSocialMessageInsertedChildMessage")) {
							context.QueueTasks.Enqueue("SocSocialMessageInsertedChildMessage");
							ProcessQueue(context);
							return;
						}
						break;
					case "SocialMessageUpdated":
							if (ActivatedEventElements.Contains("SocialMessageUpdatedChildMessage")) {
							context.QueueTasks.Enqueue("SocialMessageUpdatedChildMessage");
							ProcessQueue(context);
							return;
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SocialMessage_SocialMessageEventsProcess

	/// <exclude/>
	public class SocialMessage_SocialMessageEventsProcess : SocialMessage_SocialMessageEventsProcess<SocialMessage>
	{

		public SocialMessage_SocialMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialMessage_SocialMessageEventsProcess

	public partial class SocialMessage_SocialMessageEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialMessageEventsProcess

	/// <exclude/>
	public class SocialMessageEventsProcess : SocialMessage_SocialMessageEventsProcess
	{

		public SocialMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

