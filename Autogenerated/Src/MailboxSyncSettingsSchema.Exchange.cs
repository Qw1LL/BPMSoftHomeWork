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

	#region Class: MailboxSyncSettings_Exchange_BPMSoftSchema

	/// <exclude/>
	public class MailboxSyncSettings_Exchange_BPMSoftSchema : BPMSoft.Configuration.MailboxSyncSettings_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public MailboxSyncSettings_Exchange_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailboxSyncSettings_Exchange_BPMSoftSchema(MailboxSyncSettings_Exchange_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailboxSyncSettings_Exchange_BPMSoftSchema(MailboxSyncSettings_Exchange_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1");
			Name = "MailboxSyncSettings_Exchange_BPMSoft";
			ParentSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315");
			ExtendParent = true;
			CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6c99d648-2324-4384-8330-b32cf258cb37")) == null) {
				Columns.Add(CreateMailSyncPeriodColumn());
			}
			if (Columns.FindByUId(new Guid("befec718-bb2e-4b77-95b3-f421c0a72196")) == null) {
				Columns.Add(CreateExchangeAutoSynchronizationColumn());
			}
			if (Columns.FindByUId(new Guid("d55aa1b5-9c33-4635-9aef-0e1d5a80f96e")) == null) {
				Columns.Add(CreateExchangeSyncIntervalColumn());
			}
			if (Columns.FindByUId(new Guid("a08de309-02eb-45f1-84a0-d627fcfe054f")) == null) {
				Columns.Add(CreateContactSyncIntervalColumn());
			}
			if (Columns.FindByUId(new Guid("e4fe0282-0d7d-4eaf-8dd2-69edeab162d7")) == null) {
				Columns.Add(CreateExchangeAutoSyncActivityColumn());
			}
			if (Columns.FindByUId(new Guid("6ddcc001-933c-4c78-8e0d-c9804c067489")) == null) {
				Columns.Add(CreateSyncDateMinutesOffsetColumn());
			}
		}

		protected override EntitySchemaColumn CreateEmailsCyclicallyAddingIntervalColumn() {
			EntitySchemaColumn column = base.CreateEmailsCyclicallyAddingIntervalColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"MailboxSyncInterval"
			};
			column.ModifiedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMailSyncPeriodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6c99d648-2324-4384-8330-b32cf258cb37"),
				Name = @"MailSyncPeriod",
				ReferenceSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				ModifiedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"2d480351-94b7-4cad-b02f-885730c7eb3e"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateExchangeAutoSynchronizationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("befec718-bb2e-4b77-95b3-f421c0a72196"),
				Name = @"ExchangeAutoSynchronization",
				CreatedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				ModifiedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateExchangeSyncIntervalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d55aa1b5-9c33-4635-9aef-0e1d5a80f96e"),
				Name = @"ExchangeSyncInterval",
				CreatedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				ModifiedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"MailboxSyncInterval"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateContactSyncIntervalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a08de309-02eb-45f1-84a0-d627fcfe054f"),
				Name = @"ContactSyncInterval",
				CreatedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				ModifiedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				CreatedInPackageId = new Guid("649234ea-022f-4546-b594-8b15be33559c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"MailboxSyncInterval"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateExchangeAutoSyncActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e4fe0282-0d7d-4eaf-8dd2-69edeab162d7"),
				Name = @"ExchangeAutoSyncActivity",
				CreatedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				ModifiedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				CreatedInPackageId = new Guid("649234ea-022f-4546-b594-8b15be33559c")
			};
		}

		protected virtual EntitySchemaColumn CreateSyncDateMinutesOffsetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6ddcc001-933c-4c78-8e0d-c9804c067489"),
				Name = @"SyncDateMinutesOffset",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				ModifiedInSchemaUId = new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"),
				CreatedInPackageId = new Guid("0dceaad6-a204-4806-b152-45288d90ce02"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"5"
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
			return new MailboxSyncSettings_Exchange_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailboxSyncSettings_ExchangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailboxSyncSettings_Exchange_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailboxSyncSettings_Exchange_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1"));
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSyncSettings_Exchange_BPMSoft

	/// <summary>
	/// Настройки синхронизации с почтовым ящиком.
	/// </summary>
	public class MailboxSyncSettings_Exchange_BPMSoft : BPMSoft.Configuration.MailboxSyncSettings_Base_BPMSoft
	{

		#region Constructors: Public

		public MailboxSyncSettings_Exchange_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxSyncSettings_Exchange_BPMSoft";
		}

		public MailboxSyncSettings_Exchange_BPMSoft(MailboxSyncSettings_Exchange_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MailSyncPeriodId {
			get {
				return GetTypedColumnValue<Guid>("MailSyncPeriodId");
			}
			set {
				SetColumnValue("MailSyncPeriodId", value);
				_mailSyncPeriod = null;
			}
		}

		/// <exclude/>
		public string MailSyncPeriodName {
			get {
				return GetTypedColumnValue<string>("MailSyncPeriodName");
			}
			set {
				SetColumnValue("MailSyncPeriodName", value);
				if (_mailSyncPeriod != null) {
					_mailSyncPeriod.Name = value;
				}
			}
		}

		private MailSyncPeriod _mailSyncPeriod;
		/// <summary>
		/// Загружать письма за период.
		/// </summary>
		public MailSyncPeriod MailSyncPeriod {
			get {
				return _mailSyncPeriod ??
					(_mailSyncPeriod = LookupColumnEntities.GetEntity("MailSyncPeriod") as MailSyncPeriod);
			}
		}

		/// <summary>
		/// Циклически синхронизировать контакты и активности.
		/// </summary>
		public bool ExchangeAutoSynchronization {
			get {
				return GetTypedColumnValue<bool>("ExchangeAutoSynchronization");
			}
			set {
				SetColumnValue("ExchangeAutoSynchronization", value);
			}
		}

		/// <summary>
		/// Интервал синхронизации контактов и активностей.
		/// </summary>
		public int ExchangeSyncInterval {
			get {
				return GetTypedColumnValue<int>("ExchangeSyncInterval");
			}
			set {
				SetColumnValue("ExchangeSyncInterval", value);
			}
		}

		/// <summary>
		/// Column 1.
		/// </summary>
		public int ContactSyncInterval {
			get {
				return GetTypedColumnValue<int>("ContactSyncInterval");
			}
			set {
				SetColumnValue("ContactSyncInterval", value);
			}
		}

		/// <summary>
		/// Column 1.
		/// </summary>
		public bool ExchangeAutoSyncActivity {
			get {
				return GetTypedColumnValue<bool>("ExchangeAutoSyncActivity");
			}
			set {
				SetColumnValue("ExchangeAutoSyncActivity", value);
			}
		}

		/// <summary>
		/// SyncDateMinutesOffset.
		/// </summary>
		public int SyncDateMinutesOffset {
			get {
				return GetTypedColumnValue<int>("SyncDateMinutesOffset");
			}
			set {
				SetColumnValue("SyncDateMinutesOffset", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailboxSyncSettings_ExchangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailboxSyncSettings_Exchange_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("MailboxSyncSettings_Exchange_BPMSoftDeleting", e);
			Updated += (s, e) => ThrowEvent("MailboxSyncSettings_Exchange_BPMSoftUpdated", e);
			Validating += (s, e) => ThrowEvent("MailboxSyncSettings_Exchange_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailboxSyncSettings_Exchange_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSyncSettings_ExchangeEventsProcess

	/// <exclude/>
	public partial class MailboxSyncSettings_ExchangeEventsProcess<TEntity> : BPMSoft.Configuration.MailboxSyncSettings_BaseEventsProcess<TEntity> where TEntity : MailboxSyncSettings_Exchange_BPMSoft
	{

		public MailboxSyncSettings_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailboxSyncSettings_ExchangeEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e9ad8f21-9530-445e-ace0-84df96cff0c1");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess6;
		public ProcessFlowElement EventSubProcess6 {
			get {
				return _eventSubProcess6 ?? (_eventSubProcess6 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess6",
					SchemaElementUId = new Guid("ff8c33ff-ed7d-4228-8d38-2d1494dc5dcf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _mailboxSyncSettingsJobDeletingScriptTask;
		public ProcessScriptTask MailboxSyncSettingsJobDeletingScriptTask {
			get {
				return _mailboxSyncSettingsJobDeletingScriptTask ?? (_mailboxSyncSettingsJobDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MailboxSyncSettingsJobDeletingScriptTask",
					SchemaElementUId = new Guid("f9a2767a-4bd9-495d-a9fc-169e31f37fb4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MailboxSyncSettingsJobDeletingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _mailboxSyncSettingsJobDeleting;
		public ProcessFlowElement MailboxSyncSettingsJobDeleting {
			get {
				return _mailboxSyncSettingsJobDeleting ?? (_mailboxSyncSettingsJobDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailboxSyncSettingsJobDeleting",
					SchemaElementUId = new Guid("9aa79d84-d06a-4622-8847-f8b2420d608f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessage1;
		public ProcessThrowMessageEvent IntermediateThrowMessage1 {
			get {
				return _intermediateThrowMessage1 ?? (_intermediateThrowMessage1 = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessage1",
					SchemaElementUId = new Guid("0c4e16ac-a45a-4d8e-aaba-d7e769975b56"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "MailboxSyncSettingsDeleting",
						ThrowToBase = true,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess7_d80813d0de31491494a0aa9d76130357;
		public ProcessFlowElement EventSubProcess7_d80813d0de31491494a0aa9d76130357 {
			get {
				return _eventSubProcess7_d80813d0de31491494a0aa9d76130357 ?? (_eventSubProcess7_d80813d0de31491494a0aa9d76130357 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess7_d80813d0de31491494a0aa9d76130357",
					SchemaElementUId = new Guid("d80813d0-de31-4914-94a0-aa9d76130357"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_131a01cf1b0c4e718160ce94f6211232;
		public ProcessFlowElement StartMessage3_131a01cf1b0c4e718160ce94f6211232 {
			get {
				return _startMessage3_131a01cf1b0c4e718160ce94f6211232 ?? (_startMessage3_131a01cf1b0c4e718160ce94f6211232 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_131a01cf1b0c4e718160ce94f6211232",
					SchemaElementUId = new Guid("131a01cf-1b0c-4e71-8160-ce94f6211232"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_5f2ee4deb773482cbfd5753884a96b7c;
		public ProcessScriptTask ScriptTask3_5f2ee4deb773482cbfd5753884a96b7c {
			get {
				return _scriptTask3_5f2ee4deb773482cbfd5753884a96b7c ?? (_scriptTask3_5f2ee4deb773482cbfd5753884a96b7c = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_5f2ee4deb773482cbfd5753884a96b7c",
					SchemaElementUId = new Guid("5f2ee4de-b773-482c-bfd5-753884a96b7c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_5f2ee4deb773482cbfd5753884a96b7cExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess6.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess6 };
			FlowElements[MailboxSyncSettingsJobDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxSyncSettingsJobDeletingScriptTask };
			FlowElements[MailboxSyncSettingsJobDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxSyncSettingsJobDeleting };
			FlowElements[IntermediateThrowMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessage1 };
			FlowElements[EventSubProcess7_d80813d0de31491494a0aa9d76130357.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess7_d80813d0de31491494a0aa9d76130357 };
			FlowElements[StartMessage3_131a01cf1b0c4e718160ce94f6211232.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_131a01cf1b0c4e718160ce94f6211232 };
			FlowElements[ScriptTask3_5f2ee4deb773482cbfd5753884a96b7c.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_5f2ee4deb773482cbfd5753884a96b7c };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess6":
						break;
					case "MailboxSyncSettingsJobDeletingScriptTask":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessage1");
						break;
					case "MailboxSyncSettingsJobDeleting":
						e.Context.QueueTasks.Enqueue("MailboxSyncSettingsJobDeletingScriptTask");
						break;
					case "IntermediateThrowMessage1":
						break;
					case "EventSubProcess7_d80813d0de31491494a0aa9d76130357":
						break;
					case "StartMessage3_131a01cf1b0c4e718160ce94f6211232":
						e.Context.QueueTasks.Enqueue("ScriptTask3_5f2ee4deb773482cbfd5753884a96b7c");
						break;
					case "ScriptTask3_5f2ee4deb773482cbfd5753884a96b7c":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("MailboxSyncSettingsJobDeleting");
			ActivatedEventElements.Add("StartMessage3_131a01cf1b0c4e718160ce94f6211232");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess6":
					context.QueueTasks.Dequeue();
					break;
				case "MailboxSyncSettingsJobDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxSyncSettingsJobDeletingScriptTask";
					result = MailboxSyncSettingsJobDeletingScriptTask.Execute(context, MailboxSyncSettingsJobDeletingScriptTaskExecute);
					break;
				case "MailboxSyncSettingsJobDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxSyncSettingsJobDeleting";
					result = MailboxSyncSettingsJobDeleting.Execute(context);
					break;
				case "IntermediateThrowMessage1":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "MailboxSyncSettingsDeleting");
					result = IntermediateThrowMessage1.Execute(context);
					break;
				case "EventSubProcess7_d80813d0de31491494a0aa9d76130357":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_131a01cf1b0c4e718160ce94f6211232":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_131a01cf1b0c4e718160ce94f6211232";
					result = StartMessage3_131a01cf1b0c4e718160ce94f6211232.Execute(context);
					break;
				case "ScriptTask3_5f2ee4deb773482cbfd5753884a96b7c":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_5f2ee4deb773482cbfd5753884a96b7c";
					result = ScriptTask3_5f2ee4deb773482cbfd5753884a96b7c.Execute(context, ScriptTask3_5f2ee4deb773482cbfd5753884a96b7cExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool MailboxSyncSettingsJobDeletingScriptTaskExecute(ProcessExecutingContext context) {
			var serverId = Entity.MailServerId;
			var mailBoxSettingsEntity = UserConnection.EntitySchemaManager.GetInstanceByName("MailServer").
				CreateEntity(UserConnection);
			Guid serverTypeId = Guid.Empty;
			if(mailBoxSettingsEntity.FetchFromDB(serverId)) {
				serverTypeId = mailBoxSettingsEntity.GetTypedColumnValue<Guid>("TypeId");
			}
			#if !NETSTANDARD2_0 //TODO 
			ExchangeUtility.RemoveAllSyncJob(UserConnection, Entity.MailboxName, serverTypeId);
			#endif
			return true;
		}

		public virtual bool ScriptTask3_5f2ee4deb773482cbfd5753884a96b7cExecute(ProcessExecutingContext context) {
			SendSyncStatus(Entity);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "MailboxSyncSettings_Exchange_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("MailboxSyncSettingsJobDeleting")) {
							context.QueueTasks.Enqueue("MailboxSyncSettingsJobDeleting");
							ProcessQueue(context);
							return;
						}
						break;
					case "MailboxSyncSettings_Exchange_BPMSoftUpdated":
							if (ActivatedEventElements.Contains("StartMessage3_131a01cf1b0c4e718160ce94f6211232")) {
							context.QueueTasks.Enqueue("StartMessage3_131a01cf1b0c4e718160ce94f6211232");
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

	#region Class: MailboxSyncSettings_ExchangeEventsProcess

	/// <exclude/>
	public class MailboxSyncSettings_ExchangeEventsProcess : MailboxSyncSettings_ExchangeEventsProcess<MailboxSyncSettings_Exchange_BPMSoft>
	{

		public MailboxSyncSettings_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailboxSyncSettings_ExchangeEventsProcess

	public partial class MailboxSyncSettings_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void SendSyncStatus(Entity mailbox) {
			var userConnection = new ConstructorArgument("userConnection", UserConnection);
			SynchronizationErrorHelper helper = ClassFactory.Get<SynchronizationErrorHelper>(userConnection);
			helper.SendSynchronizationStatus(mailbox);
		}

		#endregion

	}

	#endregion

}

