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

	#region Class: VwAccountRelationshipSchema

	/// <exclude/>
	public class VwAccountRelationshipSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwAccountRelationshipSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwAccountRelationshipSchema(VwAccountRelationshipSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwAccountRelationshipSchema(VwAccountRelationshipSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b");
			RealUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b");
			Name = "VwAccountRelationship";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1437e774-afb9-4331-9cdb-e1be2d7987cc")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("010495ab-710f-4d8c-8502-39518c16458d")) == null) {
				Columns.Add(CreateRelatedAccountColumn());
			}
			if (Columns.FindByUId(new Guid("32d2149b-3624-4f40-b59e-946eeb527e15")) == null) {
				Columns.Add(CreateRelatedContactColumn());
			}
			if (Columns.FindByUId(new Guid("4ebcae2d-6185-458d-8d08-af63fa136cfe")) == null) {
				Columns.Add(CreateRelationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("65f16185-47e9-4fc2-abe3-65f2aa5b5b99")) == null) {
				Columns.Add(CreateReverseRelationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("ab47c488-344e-425d-a34c-3dec611f3dff")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("3d2d7c5b-613d-4aec-a9c1-49829503c027")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("28503d1b-16da-4ff0-a632-82255760ecde")) == null) {
				Columns.Add(CreateRelatedObjectNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b");
			column.CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b");
			column.CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b");
			column.CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b");
			column.CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b");
			column.CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b");
			column.CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3");
			return column;
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1437e774-afb9-4331-9cdb-e1be2d7987cc"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateRelatedAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("010495ab-710f-4d8c-8502-39518c16458d"),
				Name = @"RelatedAccount",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateRelatedContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("32d2149b-3624-4f40-b59e-946eeb527e15"),
				Name = @"RelatedContact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateRelationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4ebcae2d-6185-458d-8d08-af63fa136cfe"),
				Name = @"RelationType",
				ReferenceSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateReverseRelationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("65f16185-47e9-4fc2-abe3-65f2aa5b5b99"),
				Name = @"ReverseRelationType",
				ReferenceSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ab47c488-344e-425d-a34c-3dec611f3dff"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("3d2d7c5b-613d-4aec-a9c1-49829503c027"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateRelatedObjectNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("28503d1b-16da-4ff0-a632-82255760ecde"),
				Name = @"RelatedObjectName",
				CreatedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				ModifiedInSchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"),
				CreatedInPackageId = new Guid("6919e88d-10ea-487b-a245-20d0cd99bafd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwAccountRelationship(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwAccountRelationship_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwAccountRelationshipSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwAccountRelationshipSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6a2487dd-c803-4bcf-903a-30355df9866b"));
		}

		#endregion

	}

	#endregion

	#region Class: VwAccountRelationship

	/// <summary>
	/// Relationship of account (view).
	/// </summary>
	public class VwAccountRelationship : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwAccountRelationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwAccountRelationship";
		}

		public VwAccountRelationship(VwAccountRelationship source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <exclude/>
		public Guid RelatedAccountId {
			get {
				return GetTypedColumnValue<Guid>("RelatedAccountId");
			}
			set {
				SetColumnValue("RelatedAccountId", value);
				_relatedAccount = null;
			}
		}

		/// <exclude/>
		public string RelatedAccountName {
			get {
				return GetTypedColumnValue<string>("RelatedAccountName");
			}
			set {
				SetColumnValue("RelatedAccountName", value);
				if (_relatedAccount != null) {
					_relatedAccount.Name = value;
				}
			}
		}

		private Account _relatedAccount;
		/// <summary>
		/// Connected account.
		/// </summary>
		public Account RelatedAccount {
			get {
				return _relatedAccount ??
					(_relatedAccount = LookupColumnEntities.GetEntity("RelatedAccount") as Account);
			}
		}

		/// <exclude/>
		public Guid RelatedContactId {
			get {
				return GetTypedColumnValue<Guid>("RelatedContactId");
			}
			set {
				SetColumnValue("RelatedContactId", value);
				_relatedContact = null;
			}
		}

		/// <exclude/>
		public string RelatedContactName {
			get {
				return GetTypedColumnValue<string>("RelatedContactName");
			}
			set {
				SetColumnValue("RelatedContactName", value);
				if (_relatedContact != null) {
					_relatedContact.Name = value;
				}
			}
		}

		private Contact _relatedContact;
		/// <summary>
		/// Connected contact.
		/// </summary>
		public Contact RelatedContact {
			get {
				return _relatedContact ??
					(_relatedContact = LookupColumnEntities.GetEntity("RelatedContact") as Contact);
			}
		}

		/// <exclude/>
		public Guid RelationTypeId {
			get {
				return GetTypedColumnValue<Guid>("RelationTypeId");
			}
			set {
				SetColumnValue("RelationTypeId", value);
				_relationType = null;
			}
		}

		/// <exclude/>
		public string RelationTypeName {
			get {
				return GetTypedColumnValue<string>("RelationTypeName");
			}
			set {
				SetColumnValue("RelationTypeName", value);
				if (_relationType != null) {
					_relationType.Name = value;
				}
			}
		}

		private RelationType _relationType;
		/// <summary>
		/// Relationship type.
		/// </summary>
		public RelationType RelationType {
			get {
				return _relationType ??
					(_relationType = LookupColumnEntities.GetEntity("RelationType") as RelationType);
			}
		}

		/// <exclude/>
		public Guid ReverseRelationTypeId {
			get {
				return GetTypedColumnValue<Guid>("ReverseRelationTypeId");
			}
			set {
				SetColumnValue("ReverseRelationTypeId", value);
				_reverseRelationType = null;
			}
		}

		/// <exclude/>
		public string ReverseRelationTypeName {
			get {
				return GetTypedColumnValue<string>("ReverseRelationTypeName");
			}
			set {
				SetColumnValue("ReverseRelationTypeName", value);
				if (_reverseRelationType != null) {
					_reverseRelationType.Name = value;
				}
			}
		}

		private RelationType _reverseRelationType;
		/// <summary>
		/// Inverse relationship type.
		/// </summary>
		public RelationType ReverseRelationType {
			get {
				return _reverseRelationType ??
					(_reverseRelationType = LookupColumnEntities.GetEntity("ReverseRelationType") as RelationType);
			}
		}

		/// <summary>
		/// Actual.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
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

		/// <summary>
		/// Connected object.
		/// </summary>
		public string RelatedObjectName {
			get {
				return GetTypedColumnValue<string>("RelatedObjectName");
			}
			set {
				SetColumnValue("RelatedObjectName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwAccountRelationship_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwAccountRelationshipDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwAccountRelationshipDeleting", e);
			Inserting += (s, e) => ThrowEvent("VwAccountRelationshipInserting", e);
			Validating += (s, e) => ThrowEvent("VwAccountRelationshipValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwAccountRelationship(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwAccountRelationship_NUIEventsProcess

	/// <exclude/>
	public partial class VwAccountRelationship_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwAccountRelationship
	{

		public VwAccountRelationship_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwAccountRelationship_NUIEventsProcess";
			SchemaUId = new Guid("6a2487dd-c803-4bcf-903a-30355df9866b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6a2487dd-c803-4bcf-903a-30355df9866b");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("b74adec4-71be-4778-af83-ac5037669624"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwAccountRelationshipDeletedStartMessage;
		public ProcessFlowElement VwAccountRelationshipDeletedStartMessage {
			get {
				return _vwAccountRelationshipDeletedStartMessage ?? (_vwAccountRelationshipDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwAccountRelationshipDeletedStartMessage",
					SchemaElementUId = new Guid("ec581509-4ca5-47e6-bea9-b0b6db2b95c3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _vwAccountRelationshipDeletedScriptTask;
		public ProcessScriptTask VwAccountRelationshipDeletedScriptTask {
			get {
				return _vwAccountRelationshipDeletedScriptTask ?? (_vwAccountRelationshipDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "VwAccountRelationshipDeletedScriptTask",
					SchemaElementUId = new Guid("c3e65b35-4793-4f69-8685-fb129e76b307"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = VwAccountRelationshipDeletedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3_585cb3ddf2c44f369791fce7024dc199;
		public ProcessFlowElement EventSubProcess3_585cb3ddf2c44f369791fce7024dc199 {
			get {
				return _eventSubProcess3_585cb3ddf2c44f369791fce7024dc199 ?? (_eventSubProcess3_585cb3ddf2c44f369791fce7024dc199 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_585cb3ddf2c44f369791fce7024dc199",
					SchemaElementUId = new Guid("585cb3dd-f2c4-4f36-9791-fce7024dc199"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwAccountRelationshipDeletingStartMessage;
		public ProcessFlowElement VwAccountRelationshipDeletingStartMessage {
			get {
				return _vwAccountRelationshipDeletingStartMessage ?? (_vwAccountRelationshipDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwAccountRelationshipDeletingStartMessage",
					SchemaElementUId = new Guid("697c9fc2-de4f-40fb-924c-d814c86ca12b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _vwAccountRelationshipDeletingScriptTask;
		public ProcessScriptTask VwAccountRelationshipDeletingScriptTask {
			get {
				return _vwAccountRelationshipDeletingScriptTask ?? (_vwAccountRelationshipDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "VwAccountRelationshipDeletingScriptTask",
					SchemaElementUId = new Guid("7bd3395a-151b-401d-85b0-76f0bf80346f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = VwAccountRelationshipDeletingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[VwAccountRelationshipDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { VwAccountRelationshipDeletedStartMessage };
			FlowElements[VwAccountRelationshipDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { VwAccountRelationshipDeletedScriptTask };
			FlowElements[EventSubProcess3_585cb3ddf2c44f369791fce7024dc199.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_585cb3ddf2c44f369791fce7024dc199 };
			FlowElements[VwAccountRelationshipDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { VwAccountRelationshipDeletingStartMessage };
			FlowElements[VwAccountRelationshipDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { VwAccountRelationshipDeletingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "VwAccountRelationshipDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("VwAccountRelationshipDeletedScriptTask");
						break;
					case "VwAccountRelationshipDeletedScriptTask":
						break;
					case "EventSubProcess3_585cb3ddf2c44f369791fce7024dc199":
						break;
					case "VwAccountRelationshipDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("VwAccountRelationshipDeletingScriptTask");
						break;
					case "VwAccountRelationshipDeletingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("VwAccountRelationshipDeletedStartMessage");
			ActivatedEventElements.Add("VwAccountRelationshipDeletingStartMessage");
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
				case "VwAccountRelationshipDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwAccountRelationshipDeletedStartMessage";
					result = VwAccountRelationshipDeletedStartMessage.Execute(context);
					break;
				case "VwAccountRelationshipDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwAccountRelationshipDeletedScriptTask";
					result = VwAccountRelationshipDeletedScriptTask.Execute(context, VwAccountRelationshipDeletedScriptTaskExecute);
					break;
				case "EventSubProcess3_585cb3ddf2c44f369791fce7024dc199":
					context.QueueTasks.Dequeue();
					break;
				case "VwAccountRelationshipDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwAccountRelationshipDeletingStartMessage";
					result = VwAccountRelationshipDeletingStartMessage.Execute(context);
					break;
				case "VwAccountRelationshipDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwAccountRelationshipDeletingScriptTask";
					result = VwAccountRelationshipDeletingScriptTask.Execute(context, VwAccountRelationshipDeletingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool VwAccountRelationshipDeletedScriptTaskExecute(ProcessExecutingContext context) {
			ClearAccountParentId();
			return true;
		}

		public virtual bool VwAccountRelationshipDeletingScriptTaskExecute(ProcessExecutingContext context) {
			CheckCanEditAccount();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "VwAccountRelationshipDeleted":
							if (ActivatedEventElements.Contains("VwAccountRelationshipDeletedStartMessage")) {
							context.QueueTasks.Enqueue("VwAccountRelationshipDeletedStartMessage");
						}
						break;
					case "VwAccountRelationshipDeleting":
							if (ActivatedEventElements.Contains("VwAccountRelationshipDeletingStartMessage")) {
							context.QueueTasks.Enqueue("VwAccountRelationshipDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: VwAccountRelationship_NUIEventsProcess

	/// <exclude/>
	public class VwAccountRelationship_NUIEventsProcess : VwAccountRelationship_NUIEventsProcess<VwAccountRelationship>
	{

		public VwAccountRelationship_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: VwAccountRelationshipEventsProcess

	/// <exclude/>
	public class VwAccountRelationshipEventsProcess : VwAccountRelationship_NUIEventsProcess
	{

		public VwAccountRelationshipEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

