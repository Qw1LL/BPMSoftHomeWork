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

	#region Class: LocalMessageSchema

	/// <exclude/>
	public class LocalMessageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LocalMessageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LocalMessageSchema(LocalMessageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LocalMessageSchema(LocalMessageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45");
			RealUId = new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45");
			Name = "LocalMessage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fbc6b186-99e1-4d4c-b364-60c4cd825fdb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a1f10d23-ef64-411c-a1a3-1d2b9a04ba22")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("61e46e95-a216-4327-a468-8f6ca2512fd2")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("906fd74d-fc8a-467c-b07f-e55fec5b7565")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a1f10d23-ef64-411c-a1a3-1d2b9a04ba22"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45"),
				ModifiedInSchemaUId = new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45"),
				CreatedInPackageId = new Guid("fbc6b186-99e1-4d4c-b364-60c4cd825fdb")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("61e46e95-a216-4327-a468-8f6ca2512fd2"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45"),
				ModifiedInSchemaUId = new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45"),
				CreatedInPackageId = new Guid("c7e51cd7-a0e6-4ced-adba-1c886021699d")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("906fd74d-fc8a-467c-b07f-e55fec5b7565"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45"),
				ModifiedInSchemaUId = new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45"),
				CreatedInPackageId = new Guid("c7e51cd7-a0e6-4ced-adba-1c886021699d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LocalMessage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LocalMessage_LocalMessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LocalMessageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LocalMessageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45"));
		}

		#endregion

	}

	#endregion

	#region Class: LocalMessage

	/// <summary>
	/// Системное сообщение.
	/// </summary>
	public class LocalMessage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LocalMessage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LocalMessage";
		}

		public LocalMessage(LocalMessage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Сообщение.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <summary>
		/// Схема.
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
		/// EntityId.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LocalMessage_LocalMessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LocalMessageDeleted", e);
			Inserted += (s, e) => ThrowEvent("LocalMessageInserted", e);
			Validating += (s, e) => ThrowEvent("LocalMessageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LocalMessage(this);
		}

		#endregion

	}

	#endregion

	#region Class: LocalMessage_LocalMessageEventsProcess

	/// <exclude/>
	public partial class LocalMessage_LocalMessageEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LocalMessage
	{

		public LocalMessage_LocalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LocalMessage_LocalMessageEventsProcess";
			SchemaUId = new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("77be0245-e5e4-4e4e-a953-5baba9d6ae45");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess145674674;
		public ProcessFlowElement EventSubProcess145674674 {
			get {
				return _eventSubProcess145674674 ?? (_eventSubProcess145674674 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess145674674",
					SchemaElementUId = new Guid("ff9699e6-7268-4476-9613-b20336f66eaa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _localMessageInserted;
		public ProcessFlowElement LocalMessageInserted {
			get {
				return _localMessageInserted ?? (_localMessageInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "LocalMessageInserted",
					SchemaElementUId = new Guid("b4b996f4-17d5-48ba-ba98-1bab7be992ab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _notifyListeners;
		public ProcessScriptTask NotifyListeners {
			get {
				return _notifyListeners ?? (_notifyListeners = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "NotifyListeners",
					SchemaElementUId = new Guid("bb232437-5032-42b4-9640-2c87b12b0c76"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = NotifyListenersExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess145674674.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess145674674 };
			FlowElements[LocalMessageInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { LocalMessageInserted };
			FlowElements[NotifyListeners.SchemaElementUId] = new Collection<ProcessFlowElement> { NotifyListeners };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess145674674":
						break;
					case "LocalMessageInserted":
						e.Context.QueueTasks.Enqueue("NotifyListeners");
						break;
					case "NotifyListeners":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("LocalMessageInserted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess145674674":
					context.QueueTasks.Dequeue();
					break;
				case "LocalMessageInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "LocalMessageInserted";
					result = LocalMessageInserted.Execute(context);
					break;
				case "NotifyListeners":
					context.QueueTasks.Dequeue();
					context.SenderName = "NotifyListeners";
					result = NotifyListeners.Execute(context, NotifyListenersExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool NotifyListenersExecute(ProcessExecutingContext context) {
			var notifier = new LocalMessageNotifier(this.Entity);
			var manager = new MessageHistoryManager(UserConnection, notifier);
			manager.Notify();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "LocalMessageInserted":
							if (ActivatedEventElements.Contains("LocalMessageInserted")) {
							context.QueueTasks.Enqueue("LocalMessageInserted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: LocalMessage_LocalMessageEventsProcess

	/// <exclude/>
	public class LocalMessage_LocalMessageEventsProcess : LocalMessage_LocalMessageEventsProcess<LocalMessage>
	{

		public LocalMessage_LocalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LocalMessage_LocalMessageEventsProcess

	public partial class LocalMessage_LocalMessageEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: LocalMessageEventsProcess

	/// <exclude/>
	public class LocalMessageEventsProcess : LocalMessage_LocalMessageEventsProcess
	{

		public LocalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

