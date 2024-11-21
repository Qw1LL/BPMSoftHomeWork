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

	#region Class: PortalMessageSchema

	/// <exclude/>
	public class PortalMessageSchema : BPMSoft.Configuration.PortalMessage_PortalMessageFeed_BPMSoftSchema
	{

		#region Constructors: Public

		public PortalMessageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PortalMessageSchema(PortalMessageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PortalMessageSchema(PortalMessageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("cdbe490f-b290-4c2f-8cfc-cd24be0bdb29");
			Name = "PortalMessage";
			ParentSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0");
			ExtendParent = true;
			CreatedInPackageId = new Guid("3d13b118-f5cc-492f-950e-fcd19f4bb9cc");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("47703666-69f2-47ed-8746-5c85c6a6bb9a")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("47703666-69f2-47ed-8746-5c85c6a6bb9a"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("ceb61101-7562-4107-bf84-9dfb310c1c1c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cdbe490f-b290-4c2f-8cfc-cd24be0bdb29"),
				ModifiedInSchemaUId = new Guid("cdbe490f-b290-4c2f-8cfc-cd24be0bdb29"),
				CreatedInPackageId = new Guid("761cfd91-bc98-408a-bd46-c0d06c3eba85"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"d00c02b1-f740-409d-9f04-d921f2aaae3e"
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
			return new PortalMessage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PortalMessage_PortalMessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PortalMessageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PortalMessageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cdbe490f-b290-4c2f-8cfc-cd24be0bdb29"));
		}

		#endregion

	}

	#endregion

	#region Class: PortalMessage

	/// <summary>
	/// Портальное сообщение.
	/// </summary>
	public class PortalMessage : BPMSoft.Configuration.PortalMessage_PortalMessageFeed_BPMSoft
	{

		#region Constructors: Public

		public PortalMessage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PortalMessage";
		}

		public PortalMessage(PortalMessage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private PortalMessageType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public PortalMessageType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as PortalMessageType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PortalMessage_PortalMessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PortalMessageDeleted", e);
			Saving += (s, e) => ThrowEvent("PortalMessageSaving", e);
			Updating += (s, e) => ThrowEvent("PortalMessageUpdating", e);
			Validating += (s, e) => ThrowEvent("PortalMessageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PortalMessage(this);
		}

		#endregion

	}

	#endregion

	#region Class: PortalMessage_PortalMessageEventsProcess

	/// <exclude/>
	public partial class PortalMessage_PortalMessageEventsProcess<TEntity> : BPMSoft.Configuration.PortalMessage_PortalMessageFeedEventsProcess<TEntity> where TEntity : PortalMessage
	{

		public PortalMessage_PortalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PortalMessage_PortalMessageEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cdbe490f-b290-4c2f-8cfc-cd24be0bdb29");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1xcvcfgdrtgwe;
		public ProcessFlowElement EventSubProcess1xcvcfgdrtgwe {
			get {
				return _eventSubProcess1xcvcfgdrtgwe ?? (_eventSubProcess1xcvcfgdrtgwe = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1xcvcfgdrtgwe",
					SchemaElementUId = new Guid("9914235a-db8a-4c38-931c-0d176ca9f65d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _portalMessageSavingChildMessage;
		public ProcessFlowElement PortalMessageSavingChildMessage {
			get {
				return _portalMessageSavingChildMessage ?? (_portalMessageSavingChildMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PortalMessageSavingChildMessage",
					SchemaElementUId = new Guid("a8ae8528-f416-48be-aa9c-3efc8e696eb7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _portalMessageUpdatingMessage;
		public ProcessFlowElement PortalMessageUpdatingMessage {
			get {
				return _portalMessageUpdatingMessage ?? (_portalMessageUpdatingMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PortalMessageUpdatingMessage",
					SchemaElementUId = new Guid("0dc311df-6d12-4500-bc70-463c637d1cca"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkPermissionsBeforeUpdating;
		public ProcessScriptTask CheckPermissionsBeforeUpdating {
			get {
				return _checkPermissionsBeforeUpdating ?? (_checkPermissionsBeforeUpdating = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckPermissionsBeforeUpdating",
					SchemaElementUId = new Guid("b9cecc8f-9c63-4211-bd89-f4e2017ac9a0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckPermissionsBeforeUpdatingExecute,
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
					SchemaElementUId = new Guid("03f56908-f4ed-4b71-a399-9f711ffd5f1a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = NotifyListenersScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1xcvcfgdrtgwe.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1xcvcfgdrtgwe };
			FlowElements[PortalMessageSavingChildMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { PortalMessageSavingChildMessage };
			FlowElements[PortalMessageUpdatingMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { PortalMessageUpdatingMessage };
			FlowElements[CheckPermissionsBeforeUpdating.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckPermissionsBeforeUpdating };
			FlowElements[NotifyListenersScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { NotifyListenersScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1xcvcfgdrtgwe":
						break;
					case "PortalMessageSavingChildMessage":
						e.Context.QueueTasks.Enqueue("NotifyListenersScriptTask");
						break;
					case "PortalMessageUpdatingMessage":
						e.Context.QueueTasks.Enqueue("CheckPermissionsBeforeUpdating");
						break;
					case "CheckPermissionsBeforeUpdating":
						break;
					case "NotifyListenersScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("PortalMessageSavingChildMessage");
			ActivatedEventElements.Add("PortalMessageUpdatingMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1xcvcfgdrtgwe":
					context.QueueTasks.Dequeue();
					break;
				case "PortalMessageSavingChildMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "PortalMessageSavingChildMessage";
					result = PortalMessageSavingChildMessage.Execute(context);
					break;
				case "PortalMessageUpdatingMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "PortalMessageUpdatingMessage";
					result = PortalMessageUpdatingMessage.Execute(context);
					break;
				case "CheckPermissionsBeforeUpdating":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckPermissionsBeforeUpdating";
					result = CheckPermissionsBeforeUpdating.Execute(context, CheckPermissionsBeforeUpdatingExecute);
					break;
				case "NotifyListenersScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "NotifyListenersScriptTask";
					result = NotifyListenersScriptTask.Execute(context, NotifyListenersScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CheckPermissionsBeforeUpdatingExecute(ProcessExecutingContext context) {
			if (UserConnection.CurrentUser.ConnectionType != UserType.SSP) {
				return true;
			}
			var createdById = Entity.GetTypedColumnValue<System.Guid>("CreatedById");
			if (UserConnection.CurrentUser.ContactId != createdById || Entity.GetTypedOldColumnValue<int>("IsNotPublished") == 0) {
				return false;
			}
			return true;
		}

		public virtual bool NotifyListenersScriptTaskExecute(ProcessExecutingContext context) {
			if(Entity.StoringState != StoringObjectState.New){
				CopyFiles();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "PortalMessageSaving":
							if (ActivatedEventElements.Contains("PortalMessageSavingChildMessage")) {
							context.QueueTasks.Enqueue("PortalMessageSavingChildMessage");
						}
						break;
					case "PortalMessageUpdating":
							if (ActivatedEventElements.Contains("PortalMessageUpdatingMessage")) {
							context.QueueTasks.Enqueue("PortalMessageUpdatingMessage");
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

	#region Class: PortalMessage_PortalMessageEventsProcess

	/// <exclude/>
	public class PortalMessage_PortalMessageEventsProcess : PortalMessage_PortalMessageEventsProcess<PortalMessage>
	{

		public PortalMessage_PortalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PortalMessage_PortalMessageEventsProcess

	public partial class PortalMessage_PortalMessageEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CopyFiles() {
			var recordId = Entity.GetTypedColumnValue<Guid>("EntityId");
			var entityUId = Entity.GetTypedColumnValue<Guid>("EntitySchemaUId");
			var schemaName = UserConnection.EntitySchemaManager.GetInstanceByUId(entityUId).Name;
			
			if(Entity.GetTypedColumnValue<bool>("IsNotPublished") && recordId.IsNotEmpty()) {
				Entity.SetColumnValue("IsNotPublished", false);
				var ignoreSchemaListForCopingFiles = GetIgnoreForCopyFilesSchemaList();
				if (ignoreSchemaListForCopingFiles.Contains(schemaName)) {
					return;
				}
				var schemasWithSpecifiedClassForCopying = GetSchemasWithSpecifiedClassForCopying();
				if (schemasWithSpecifiedClassForCopying.Contains(schemaName)) {
					var copyingUtility = GetInstanceOfSpecifiedClassForCopying(schemaName);
					if(copyingUtility != null) {
						copyingUtility.CopyAll("PortalMessage", Entity.PrimaryColumnValue, recordId);
						return;
					}
				}
				BPMSoft.Configuration.CommonUtilities
					.CopyFileDetail(UserConnection, Entity.PrimaryColumnValue, recordId, "PortalMessage", schemaName, false);
			}
		}

		public virtual void NotifyListeners() {
			if(this.Entity.GetTypedColumnValue<bool>("IsNotPublished")){
				return;
			}
			var notifier = new PortalMessageNotifier(this.Entity);
			var manager = new MessageHistoryManager(UserConnection, notifier);
			manager.Notify();
		}

		public virtual List<string> GetIgnoreForCopyFilesSchemaList() {
			return new List<string> { "Lead" };
		}

		public virtual List<string> GetSchemasWithSpecifiedClassForCopying() {
			return new List<string> { "Case" };
		}

		public virtual IEntityFileCopier GetInstanceOfSpecifiedClassForCopying(string schemaName) {
			var userConnectionArgument = new ConstructorArgument("schemaName", UserConnection);
			return	ClassFactory.Get<IEntityFileCopier>(schemaName, userConnectionArgument);
		}

		#endregion

	}

	#endregion


	#region Class: PortalMessageEventsProcess

	/// <exclude/>
	public class PortalMessageEventsProcess : PortalMessage_PortalMessageEventsProcess
	{

		public PortalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

