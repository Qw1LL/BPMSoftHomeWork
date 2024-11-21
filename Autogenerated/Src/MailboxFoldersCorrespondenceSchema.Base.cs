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

	#region Class: MailboxFoldersCorrespondence_Base_BPMSoftSchema

	/// <exclude/>
	public class MailboxFoldersCorrespondence_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MailboxFoldersCorrespondence_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailboxFoldersCorrespondence_Base_BPMSoftSchema(MailboxFoldersCorrespondence_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailboxFoldersCorrespondence_Base_BPMSoftSchema(MailboxFoldersCorrespondence_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			RealUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			Name = "MailboxFoldersCorrespondence_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7a646759-5625-40b8-b9b2-a130fe59eabe");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c55e72a2-77b6-411d-a1b9-f1aafe4bc2a2")) == null) {
				Columns.Add(CreateMailboxColumn());
			}
			if (Columns.FindByUId(new Guid("defe22ae-686f-407f-94e4-d331a858fe1a")) == null) {
				Columns.Add(CreateActivityFolderColumn());
			}
			if (Columns.FindByUId(new Guid("80041bc7-5130-4a6e-b202-905cb969bf49")) == null) {
				Columns.Add(CreateFolderPathColumn());
			}
			if (Columns.FindByUId(new Guid("f5c3a03f-c9db-4891-9331-ffe6b5a698b1")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("4ad9420a-93a9-483c-b1f9-7405503425f4")) == null) {
				Columns.Add(CreateUIdValidityColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			column.CreatedInPackageId = new Guid("7a646759-5625-40b8-b9b2-a130fe59eabe");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			column.CreatedInPackageId = new Guid("7a646759-5625-40b8-b9b2-a130fe59eabe");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			column.CreatedInPackageId = new Guid("7a646759-5625-40b8-b9b2-a130fe59eabe");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			column.CreatedInPackageId = new Guid("7a646759-5625-40b8-b9b2-a130fe59eabe");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			column.CreatedInPackageId = new Guid("7a646759-5625-40b8-b9b2-a130fe59eabe");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			column.CreatedInPackageId = new Guid("7a646759-5625-40b8-b9b2-a130fe59eabe");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMailboxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c55e72a2-77b6-411d-a1b9-f1aafe4bc2a2"),
				Name = @"Mailbox",
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"),
				ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"),
				CreatedInPackageId = new Guid("7a646759-5625-40b8-b9b2-a130fe59eabe")
			};
		}

		protected virtual EntitySchemaColumn CreateActivityFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("defe22ae-686f-407f-94e4-d331a858fe1a"),
				Name = @"ActivityFolder",
				ReferenceSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"),
				ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"),
				CreatedInPackageId = new Guid("7a646759-5625-40b8-b9b2-a130fe59eabe")
			};
		}

		protected virtual EntitySchemaColumn CreateFolderPathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("80041bc7-5130-4a6e-b202-905cb969bf49"),
				Name = @"FolderPath",
				CreatedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"),
				ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"),
				CreatedInPackageId = new Guid("7a646759-5625-40b8-b9b2-a130fe59eabe")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("f5c3a03f-c9db-4891-9331-ffe6b5a698b1"),
				Name = @"UId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"),
				ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateUIdValidityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("4ad9420a-93a9-483c-b1f9-7405503425f4"),
				Name = @"UIdValidity",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"),
				ModifiedInSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
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
			return new MailboxFoldersCorrespondence_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailboxFoldersCorrespondence_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailboxFoldersCorrespondence_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailboxFoldersCorrespondence_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc"));
		}

		#endregion

	}

	#endregion

	#region Class: MailboxFoldersCorrespondence_Base_BPMSoft

	/// <summary>
	/// Correlation between Activity folders and Mailbox folders.
	/// </summary>
	public class MailboxFoldersCorrespondence_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MailboxFoldersCorrespondence_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxFoldersCorrespondence_Base_BPMSoft";
		}

		public MailboxFoldersCorrespondence_Base_BPMSoft(MailboxFoldersCorrespondence_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MailboxId {
			get {
				return GetTypedColumnValue<Guid>("MailboxId");
			}
			set {
				SetColumnValue("MailboxId", value);
				_mailbox = null;
			}
		}

		/// <exclude/>
		public string MailboxUserName {
			get {
				return GetTypedColumnValue<string>("MailboxUserName");
			}
			set {
				SetColumnValue("MailboxUserName", value);
				if (_mailbox != null) {
					_mailbox.UserName = value;
				}
			}
		}

		private MailboxSyncSettings _mailbox;
		/// <summary>
		/// Mailbox.
		/// </summary>
		public MailboxSyncSettings Mailbox {
			get {
				return _mailbox ??
					(_mailbox = LookupColumnEntities.GetEntity("Mailbox") as MailboxSyncSettings);
			}
		}

		/// <exclude/>
		public Guid ActivityFolderId {
			get {
				return GetTypedColumnValue<Guid>("ActivityFolderId");
			}
			set {
				SetColumnValue("ActivityFolderId", value);
				_activityFolder = null;
			}
		}

		/// <exclude/>
		public string ActivityFolderName {
			get {
				return GetTypedColumnValue<string>("ActivityFolderName");
			}
			set {
				SetColumnValue("ActivityFolderName", value);
				if (_activityFolder != null) {
					_activityFolder.Name = value;
				}
			}
		}

		private ActivityFolder _activityFolder;
		/// <summary>
		/// Activity folder.
		/// </summary>
		public ActivityFolder ActivityFolder {
			get {
				return _activityFolder ??
					(_activityFolder = LookupColumnEntities.GetEntity("ActivityFolder") as ActivityFolder);
			}
		}

		/// <summary>
		/// Path to mailbox folder.
		/// </summary>
		public string FolderPath {
			get {
				return GetTypedColumnValue<string>("FolderPath");
			}
			set {
				SetColumnValue("FolderPath", value);
			}
		}

		/// <summary>
		/// UId of last downloaded letter.
		/// </summary>
		public string UId {
			get {
				return GetTypedColumnValue<string>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// UIdValidity of folder.
		/// </summary>
		public string UIdValidity {
			get {
				return GetTypedColumnValue<string>("UIdValidity");
			}
			set {
				SetColumnValue("UIdValidity", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailboxFoldersCorrespondence_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailboxFoldersCorrespondence_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("MailboxFoldersCorrespondence_Base_BPMSoftDeleting", e);
			Inserting += (s, e) => ThrowEvent("MailboxFoldersCorrespondence_Base_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("MailboxFoldersCorrespondence_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailboxFoldersCorrespondence_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxFoldersCorrespondence_BaseEventsProcess

	/// <exclude/>
	public partial class MailboxFoldersCorrespondence_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MailboxFoldersCorrespondence_Base_BPMSoft
	{

		public MailboxFoldersCorrespondence_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailboxFoldersCorrespondence_BaseEventsProcess";
			SchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid ActivityFolderId {
			get;
			set;
		}

		public virtual Guid MailboxId {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("92c87dd7-5027-4214-9608-da0cb4398eed"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailboxFoldersCorrespondenceDeleting;
		public ProcessFlowElement MailboxFoldersCorrespondenceDeleting {
			get {
				return _mailboxFoldersCorrespondenceDeleting ?? (_mailboxFoldersCorrespondenceDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailboxFoldersCorrespondenceDeleting",
					SchemaElementUId = new Guid("09d6f9dc-4bed-47e8-8a24-b8c825288d63"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _baseEntityDeletingThrow;
		public ProcessThrowMessageEvent BaseEntityDeletingThrow {
			get {
				return _baseEntityDeletingThrow ?? (_baseEntityDeletingThrow = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "BaseEntityDeletingThrow",
					SchemaElementUId = new Guid("e7cae2e6-9b00-4009-980b-1016452b48c7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "BaseEntityDeleting",
				});
			}
		}

		private ProcessScriptTask _mailboxFoldersCorrespondenceDeletingScript;
		public ProcessScriptTask MailboxFoldersCorrespondenceDeletingScript {
			get {
				return _mailboxFoldersCorrespondenceDeletingScript ?? (_mailboxFoldersCorrespondenceDeletingScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MailboxFoldersCorrespondenceDeletingScript",
					SchemaElementUId = new Guid("c857f4d7-1fdb-4fe1-888a-7fc9510bff6e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MailboxFoldersCorrespondenceDeletingScriptExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("d819515e-9c4e-4c16-9c79-0419add0d864"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailboxFoldersCorrespondenceDeleted;
		public ProcessFlowElement MailboxFoldersCorrespondenceDeleted {
			get {
				return _mailboxFoldersCorrespondenceDeleted ?? (_mailboxFoldersCorrespondenceDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailboxFoldersCorrespondenceDeleted",
					SchemaElementUId = new Guid("820cc956-3c72-43c0-9652-3e2d07dfc620"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _baseEntityDeletedThrow;
		public ProcessThrowMessageEvent BaseEntityDeletedThrow {
			get {
				return _baseEntityDeletedThrow ?? (_baseEntityDeletedThrow = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "BaseEntityDeletedThrow",
					SchemaElementUId = new Guid("7b6c02fc-f5e9-48ee-a2ba-da31313b5e6c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "BaseEntityDeleted",
				});
			}
		}

		private ProcessScriptTask _mailboxFoldersCorrespondenceDeletedScript;
		public ProcessScriptTask MailboxFoldersCorrespondenceDeletedScript {
			get {
				return _mailboxFoldersCorrespondenceDeletedScript ?? (_mailboxFoldersCorrespondenceDeletedScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MailboxFoldersCorrespondenceDeletedScript",
					SchemaElementUId = new Guid("055ab9ec-03b2-49e6-a8c7-21ea47a81f12"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MailboxFoldersCorrespondenceDeletedScriptExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[MailboxFoldersCorrespondenceDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxFoldersCorrespondenceDeleting };
			FlowElements[BaseEntityDeletingThrow.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletingThrow };
			FlowElements[MailboxFoldersCorrespondenceDeletingScript.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxFoldersCorrespondenceDeletingScript };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[MailboxFoldersCorrespondenceDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxFoldersCorrespondenceDeleted };
			FlowElements[BaseEntityDeletedThrow.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletedThrow };
			FlowElements[MailboxFoldersCorrespondenceDeletedScript.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxFoldersCorrespondenceDeletedScript };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "MailboxFoldersCorrespondenceDeleting":
						e.Context.QueueTasks.Enqueue("BaseEntityDeletingThrow");
						break;
					case "BaseEntityDeletingThrow":
						e.Context.QueueTasks.Enqueue("MailboxFoldersCorrespondenceDeletingScript");
						break;
					case "MailboxFoldersCorrespondenceDeletingScript":
						break;
					case "EventSubProcess2":
						break;
					case "MailboxFoldersCorrespondenceDeleted":
						e.Context.QueueTasks.Enqueue("BaseEntityDeletedThrow");
						break;
					case "BaseEntityDeletedThrow":
						e.Context.QueueTasks.Enqueue("MailboxFoldersCorrespondenceDeletedScript");
						break;
					case "MailboxFoldersCorrespondenceDeletedScript":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("MailboxFoldersCorrespondenceDeleting");
			ActivatedEventElements.Add("MailboxFoldersCorrespondenceDeleted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "MailboxFoldersCorrespondenceDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxFoldersCorrespondenceDeleting";
					result = MailboxFoldersCorrespondenceDeleting.Execute(context);
					break;
				case "BaseEntityDeletingThrow":
					context.QueueTasks.Dequeue();
					result = BaseEntityDeletingThrow.Execute(context);
					break;
				case "MailboxFoldersCorrespondenceDeletingScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxFoldersCorrespondenceDeletingScript";
					result = MailboxFoldersCorrespondenceDeletingScript.Execute(context, MailboxFoldersCorrespondenceDeletingScriptExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "MailboxFoldersCorrespondenceDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxFoldersCorrespondenceDeleted";
					result = MailboxFoldersCorrespondenceDeleted.Execute(context);
					break;
				case "BaseEntityDeletedThrow":
					context.QueueTasks.Dequeue();
					result = BaseEntityDeletedThrow.Execute(context);
					break;
				case "MailboxFoldersCorrespondenceDeletedScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxFoldersCorrespondenceDeletedScript";
					result = MailboxFoldersCorrespondenceDeletedScript.Execute(context, MailboxFoldersCorrespondenceDeletedScriptExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool MailboxFoldersCorrespondenceDeletingScriptExecute(ProcessExecutingContext context) {
			MailboxId = Entity.GetTypedColumnValue<Guid>("MailboxId");
			ActivityFolderId = Entity.GetTypedColumnValue<Guid>("ActivityFolderId");
			return true;
		}

		public virtual bool MailboxFoldersCorrespondenceDeletedScriptExecute(ProcessExecutingContext context) {
			var activityFolderSchema = UserConnection.EntitySchemaManager.FindInstanceByName("ActivityFolder");
			var activityFolder = activityFolderSchema.CreateEntity(UserConnection);
			if(activityFolder.FetchFromDB(ActivityFolderId)) {
				activityFolder.Delete();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "MailboxFoldersCorrespondence_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("MailboxFoldersCorrespondenceDeleting")) {
							context.QueueTasks.Enqueue("MailboxFoldersCorrespondenceDeleting");
						}
						break;
					case "MailboxFoldersCorrespondence_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("MailboxFoldersCorrespondenceDeleted")) {
							context.QueueTasks.Enqueue("MailboxFoldersCorrespondenceDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxFoldersCorrespondence_BaseEventsProcess

	/// <exclude/>
	public class MailboxFoldersCorrespondence_BaseEventsProcess : MailboxFoldersCorrespondence_BaseEventsProcess<MailboxFoldersCorrespondence_Base_BPMSoft>
	{

		public MailboxFoldersCorrespondence_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailboxFoldersCorrespondence_BaseEventsProcess

	public partial class MailboxFoldersCorrespondence_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

