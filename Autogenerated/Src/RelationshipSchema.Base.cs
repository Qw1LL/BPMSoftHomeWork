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
	using System.Security;

	#region Class: RelationshipSchema

	/// <exclude/>
	public class RelationshipSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RelationshipSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationshipSchema(RelationshipSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationshipSchema(RelationshipSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5");
			RealUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5");
			Name = "Relationship";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a2053f3d-ed48-45cb-abf1-054daa988f76")) == null) {
				Columns.Add(CreateRelationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("02c1f1b3-301f-4888-a7a4-2b78250eb5bb")) == null) {
				Columns.Add(CreateReverseRelationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("55b05a23-2493-4ed3-8427-933390c09045")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("3fbe0cad-7567-4321-83b2-b3eabda01fdc")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("88fb424c-9256-4164-a30f-b926f42725d3")) == null) {
				Columns.Add(CreateAccountAColumn());
			}
			if (Columns.FindByUId(new Guid("7c3362ec-7c34-431e-b28d-734922452ef0")) == null) {
				Columns.Add(CreateContactAColumn());
			}
			if (Columns.FindByUId(new Guid("404af122-1f0d-4765-bee8-2d5401fedc9e")) == null) {
				Columns.Add(CreateAccountBColumn());
			}
			if (Columns.FindByUId(new Guid("74441e5a-2ea1-4fd5-821b-d0cd5be78751")) == null) {
				Columns.Add(CreateContactBColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRelationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a2053f3d-ed48-45cb-abf1-054daa988f76"),
				Name = @"RelationType",
				ReferenceSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				ModifiedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateReverseRelationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("02c1f1b3-301f-4888-a7a4-2b78250eb5bb"),
				Name = @"ReverseRelationType",
				ReferenceSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				CreatedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				ModifiedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("55b05a23-2493-4ed3-8427-933390c09045"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				ModifiedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3fbe0cad-7567-4321-83b2-b3eabda01fdc"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				ModifiedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountAColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("88fb424c-9256-4164-a30f-b926f42725d3"),
				Name = @"AccountA",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				ModifiedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactAColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7c3362ec-7c34-431e-b28d-734922452ef0"),
				Name = @"ContactA",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				ModifiedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountBColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("404af122-1f0d-4765-bee8-2d5401fedc9e"),
				Name = @"AccountB",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				ModifiedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactBColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("74441e5a-2ea1-4fd5-821b-d0cd5be78751"),
				Name = @"ContactB",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				ModifiedInSchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Relationship(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Relationship_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationshipSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationshipSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5"));
		}

		#endregion

	}

	#endregion

	#region Class: Relationship

	/// <summary>
	/// Взаимосвязь.
	/// </summary>
	public class Relationship : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Relationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Relationship";
		}

		public Relationship(Relationship source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Тип взаимосвязи.
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
		/// Обратный тип взаимосвязи.
		/// </summary>
		public RelationType ReverseRelationType {
			get {
				return _reverseRelationType ??
					(_reverseRelationType = LookupColumnEntities.GetEntity("ReverseRelationType") as RelationType);
			}
		}

		/// <summary>
		/// Актуальна.
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
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <exclude/>
		public Guid AccountAId {
			get {
				return GetTypedColumnValue<Guid>("AccountAId");
			}
			set {
				SetColumnValue("AccountAId", value);
				_accountA = null;
			}
		}

		/// <exclude/>
		public string AccountAName {
			get {
				return GetTypedColumnValue<string>("AccountAName");
			}
			set {
				SetColumnValue("AccountAName", value);
				if (_accountA != null) {
					_accountA.Name = value;
				}
			}
		}

		private Account _accountA;
		/// <summary>
		/// Контрагент А.
		/// </summary>
		public Account AccountA {
			get {
				return _accountA ??
					(_accountA = LookupColumnEntities.GetEntity("AccountA") as Account);
			}
		}

		/// <exclude/>
		public Guid ContactAId {
			get {
				return GetTypedColumnValue<Guid>("ContactAId");
			}
			set {
				SetColumnValue("ContactAId", value);
				_contactA = null;
			}
		}

		/// <exclude/>
		public string ContactAName {
			get {
				return GetTypedColumnValue<string>("ContactAName");
			}
			set {
				SetColumnValue("ContactAName", value);
				if (_contactA != null) {
					_contactA.Name = value;
				}
			}
		}

		private Contact _contactA;
		/// <summary>
		/// Контакт А.
		/// </summary>
		public Contact ContactA {
			get {
				return _contactA ??
					(_contactA = LookupColumnEntities.GetEntity("ContactA") as Contact);
			}
		}

		/// <exclude/>
		public Guid AccountBId {
			get {
				return GetTypedColumnValue<Guid>("AccountBId");
			}
			set {
				SetColumnValue("AccountBId", value);
				_accountB = null;
			}
		}

		/// <exclude/>
		public string AccountBName {
			get {
				return GetTypedColumnValue<string>("AccountBName");
			}
			set {
				SetColumnValue("AccountBName", value);
				if (_accountB != null) {
					_accountB.Name = value;
				}
			}
		}

		private Account _accountB;
		/// <summary>
		/// Контрагент Б.
		/// </summary>
		public Account AccountB {
			get {
				return _accountB ??
					(_accountB = LookupColumnEntities.GetEntity("AccountB") as Account);
			}
		}

		/// <exclude/>
		public Guid ContactBId {
			get {
				return GetTypedColumnValue<Guid>("ContactBId");
			}
			set {
				SetColumnValue("ContactBId", value);
				_contactB = null;
			}
		}

		/// <exclude/>
		public string ContactBName {
			get {
				return GetTypedColumnValue<string>("ContactBName");
			}
			set {
				SetColumnValue("ContactBName", value);
				if (_contactB != null) {
					_contactB.Name = value;
				}
			}
		}

		private Contact _contactB;
		/// <summary>
		/// Контакт Б.
		/// </summary>
		public Contact ContactB {
			get {
				return _contactB ??
					(_contactB = LookupColumnEntities.GetEntity("ContactB") as Contact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Relationship_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("RelationshipDeleted", e);
			Deleting += (s, e) => ThrowEvent("RelationshipDeleting", e);
			Inserted += (s, e) => ThrowEvent("RelationshipInserted", e);
			Inserting += (s, e) => ThrowEvent("RelationshipInserting", e);
			Saved += (s, e) => ThrowEvent("RelationshipSaved", e);
			Saving += (s, e) => ThrowEvent("RelationshipSaving", e);
			Validating += (s, e) => ThrowEvent("RelationshipValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Relationship(this);
		}

		#endregion

	}

	#endregion

	#region Class: Relationship_BaseEventsProcess

	/// <exclude/>
	public partial class Relationship_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Relationship
	{

		public Relationship_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Relationship_BaseEventsProcess";
			SchemaUId = new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("533e9db5-b10c-44a9-bbef-168af653d2d5");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid ChildAccountId {
			get;
			set;
		}

		public virtual Guid OldChildAccountId {
			get;
			set;
		}

		public virtual Guid ParentAccountId {
			get;
			set;
		}

		public virtual Guid OldParentAccountId {
			get;
			set;
		}

		public virtual Guid RelationTypeId {
			get;
			set;
		}

		public virtual Guid OldRelationTypeId {
			get;
			set;
		}

		public virtual Guid ReverseRelationTypeId {
			get;
			set;
		}

		public virtual Guid OldReverseRelationTypeId {
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
					SchemaElementUId = new Guid("8db64475-8492-4ef2-8c07-3561a75ea878"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _relationshipInsertingStartMessage;
		public ProcessFlowElement RelationshipInsertingStartMessage {
			get {
				return _relationshipInsertingStartMessage ?? (_relationshipInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RelationshipInsertingStartMessage",
					SchemaElementUId = new Guid("c7c50777-0f61-4f22-9927-a707a6fcb028"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkParentAccountExistScriptTask;
		public ProcessScriptTask CheckParentAccountExistScriptTask {
			get {
				return _checkParentAccountExistScriptTask ?? (_checkParentAccountExistScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckParentAccountExistScriptTask",
					SchemaElementUId = new Guid("9b65e755-de5c-4faf-bdc6-211bd7fe78e8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckParentAccountExistScriptTaskExecute,
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
					SchemaElementUId = new Guid("1c2c0fd5-f223-4b15-ba35-f632fe7bcf8e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _relationshipInsertedStartMessage;
		public ProcessFlowElement RelationshipInsertedStartMessage {
			get {
				return _relationshipInsertedStartMessage ?? (_relationshipInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RelationshipInsertedStartMessage",
					SchemaElementUId = new Guid("437ca897-5a90-473b-9292-f7fa2ae06d3f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _relationshipInsertedScriptTask;
		public ProcessScriptTask RelationshipInsertedScriptTask {
			get {
				return _relationshipInsertedScriptTask ?? (_relationshipInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RelationshipInsertedScriptTask",
					SchemaElementUId = new Guid("e4d8fc41-5e0e-4765-b4b5-0a32ea9fc154"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RelationshipInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3;
		public ProcessFlowElement EventSubProcess3 {
			get {
				return _eventSubProcess3 ?? (_eventSubProcess3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3",
					SchemaElementUId = new Guid("c5e3b5b4-70f1-4b35-9dbd-f61e9f9480cb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _relationshipSavingStartMessage;
		public ProcessFlowElement RelationshipSavingStartMessage {
			get {
				return _relationshipSavingStartMessage ?? (_relationshipSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RelationshipSavingStartMessage",
					SchemaElementUId = new Guid("83cc73a5-0002-42c1-b21b-50b86bc43b80"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _relationshipSavingScriptTask;
		public ProcessScriptTask RelationshipSavingScriptTask {
			get {
				return _relationshipSavingScriptTask ?? (_relationshipSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RelationshipSavingScriptTask",
					SchemaElementUId = new Guid("d53e8f53-8f1d-4c63-8aa7-92b7d16c9ed1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RelationshipSavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4;
		public ProcessFlowElement EventSubProcess4 {
			get {
				return _eventSubProcess4 ?? (_eventSubProcess4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4",
					SchemaElementUId = new Guid("a8d95e40-b56a-49c3-a1d8-3a59ef4b59ea"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _relationshipSavedStartMessage;
		public ProcessFlowElement RelationshipSavedStartMessage {
			get {
				return _relationshipSavedStartMessage ?? (_relationshipSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "RelationshipSavedStartMessage",
					SchemaElementUId = new Guid("3a8fe39f-97ee-4871-9937-bf6f5eb9f7f8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _relationshipSavedScriptTask;
		public ProcessScriptTask RelationshipSavedScriptTask {
			get {
				return _relationshipSavedScriptTask ?? (_relationshipSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RelationshipSavedScriptTask",
					SchemaElementUId = new Guid("4c3e46b3-9c2c-4261-8637-db8c59aa3233"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RelationshipSavedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[RelationshipInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RelationshipInsertingStartMessage };
			FlowElements[CheckParentAccountExistScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckParentAccountExistScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[RelationshipInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RelationshipInsertedStartMessage };
			FlowElements[RelationshipInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RelationshipInsertedScriptTask };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[RelationshipSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RelationshipSavingStartMessage };
			FlowElements[RelationshipSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RelationshipSavingScriptTask };
			FlowElements[EventSubProcess4.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4 };
			FlowElements[RelationshipSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { RelationshipSavedStartMessage };
			FlowElements[RelationshipSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RelationshipSavedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "RelationshipInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckParentAccountExistScriptTask");
						break;
					case "CheckParentAccountExistScriptTask":
						break;
					case "EventSubProcess2":
						break;
					case "RelationshipInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("RelationshipInsertedScriptTask");
						break;
					case "RelationshipInsertedScriptTask":
						break;
					case "EventSubProcess3":
						break;
					case "RelationshipSavingStartMessage":
						e.Context.QueueTasks.Enqueue("RelationshipSavingScriptTask");
						break;
					case "RelationshipSavingScriptTask":
						break;
					case "EventSubProcess4":
						break;
					case "RelationshipSavedStartMessage":
						e.Context.QueueTasks.Enqueue("RelationshipSavedScriptTask");
						break;
					case "RelationshipSavedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("RelationshipInsertingStartMessage");
			ActivatedEventElements.Add("RelationshipInsertedStartMessage");
			ActivatedEventElements.Add("RelationshipSavingStartMessage");
			ActivatedEventElements.Add("RelationshipSavedStartMessage");
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
				case "RelationshipInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RelationshipInsertingStartMessage";
					result = RelationshipInsertingStartMessage.Execute(context);
					break;
				case "CheckParentAccountExistScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckParentAccountExistScriptTask";
					result = CheckParentAccountExistScriptTask.Execute(context, CheckParentAccountExistScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "RelationshipInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RelationshipInsertedStartMessage";
					result = RelationshipInsertedStartMessage.Execute(context);
					break;
				case "RelationshipInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "RelationshipInsertedScriptTask";
					result = RelationshipInsertedScriptTask.Execute(context, RelationshipInsertedScriptTaskExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "RelationshipSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RelationshipSavingStartMessage";
					result = RelationshipSavingStartMessage.Execute(context);
					break;
				case "RelationshipSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "RelationshipSavingScriptTask";
					result = RelationshipSavingScriptTask.Execute(context, RelationshipSavingScriptTaskExecute);
					break;
				case "EventSubProcess4":
					context.QueueTasks.Dequeue();
					break;
				case "RelationshipSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "RelationshipSavedStartMessage";
					result = RelationshipSavedStartMessage.Execute(context);
					break;
				case "RelationshipSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "RelationshipSavedScriptTask";
					result = RelationshipSavedScriptTask.Execute(context, RelationshipSavedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CheckParentAccountExistScriptTaskExecute(ProcessExecutingContext context) {
			if (CheckParentAccountExist()) {
				((BPMSoft.Core.Entities.EntityBeforeEventArgs)(context.ThrowEventArgs)).IsCanceled = true;
			}
			return true;
		}

		public virtual bool RelationshipInsertedScriptTaskExecute(ProcessExecutingContext context) {
			UpdateAccountAfterRelationshipInserted();
			return true;
		}

		public virtual bool RelationshipSavingScriptTaskExecute(ProcessExecutingContext context) {
			SetParametersBeforeSaving();
			return true;
		}

		public virtual bool RelationshipSavedScriptTaskExecute(ProcessExecutingContext context) {
			UpdateAccountAfterRelationshipSaved();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "RelationshipInserting":
							if (ActivatedEventElements.Contains("RelationshipInsertingStartMessage")) {
							context.QueueTasks.Enqueue("RelationshipInsertingStartMessage");
						}
						break;
					case "RelationshipInserted":
							if (ActivatedEventElements.Contains("RelationshipInsertedStartMessage")) {
							context.QueueTasks.Enqueue("RelationshipInsertedStartMessage");
						}
						break;
					case "RelationshipSaving":
							if (ActivatedEventElements.Contains("RelationshipSavingStartMessage")) {
							context.QueueTasks.Enqueue("RelationshipSavingStartMessage");
						}
						break;
					case "RelationshipSaved":
							if (ActivatedEventElements.Contains("RelationshipSavedStartMessage")) {
							context.QueueTasks.Enqueue("RelationshipSavedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Relationship_BaseEventsProcess

	/// <exclude/>
	public class Relationship_BaseEventsProcess : Relationship_BaseEventsProcess<Relationship>
	{

		public Relationship_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: RelationshipEventsProcess

	/// <exclude/>
	public class RelationshipEventsProcess : Relationship_BaseEventsProcess
	{

		public RelationshipEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

