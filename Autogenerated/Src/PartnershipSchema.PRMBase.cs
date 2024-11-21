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

	#region Class: Partnership_PRMBase_BPMSoftSchema

	/// <exclude/>
	public class Partnership_PRMBase_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Partnership_PRMBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Partnership_PRMBase_BPMSoftSchema(Partnership_PRMBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Partnership_PRMBase_BPMSoftSchema(Partnership_PRMBase_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
			RealUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
			Name = "Partnership_PRMBase_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3644c994-8f85-41ec-8125-47013bac161f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("72a684b2-baa7-4389-8ed2-84d1b6b9ab9f")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("bc5fdb3b-b6ee-4f31-9a56-5c713cd82b40")) == null) {
				Columns.Add(CreatePartnerLevelColumn());
			}
			if (Columns.FindByUId(new Guid("9b465ac9-cb0e-4418-bfcf-eeb3b79ed51d")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("17e2fac9-f01b-4392-a9d6-be80c85d5ab1")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("2a6447d4-3c79-4ceb-8b02-aa3eeb1ba11e")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("52f0ff51-ba26-4402-83bd-056065ca393f")) == null) {
				Columns.Add(CreatePartnerTypeColumn());
			}
			if (Columns.FindByUId(new Guid("05340663-5114-422d-a4dc-3fc6074a5fbd")) == null) {
				Columns.Add(CreateScoreLeftColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Text")) {
				UId = new Guid("5525b0a8-acba-4838-90d7-e48b01f1db54"),
				Name = @"Name",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				CreatedInPackageId = new Guid("047f00c4-7c65-4fe2-bb2b-f56703cb1187")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("72a684b2-baa7-4389-8ed2-84d1b6b9ab9f"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				CreatedInPackageId = new Guid("047f00c4-7c65-4fe2-bb2b-f56703cb1187")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnerLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bc5fdb3b-b6ee-4f31-9a56-5c713cd82b40"),
				Name = @"PartnerLevel",
				ReferenceSchemaUId = new Guid("0e098241-437e-4443-b864-0c5cc0cd1a80"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				CreatedInPackageId = new Guid("047f00c4-7c65-4fe2-bb2b-f56703cb1187"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0ca08806-1b48-4954-9fa7-d8ebd71545ab"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("9b465ac9-cb0e-4418-bfcf-eeb3b79ed51d"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				CreatedInPackageId = new Guid("047f00c4-7c65-4fe2-bb2b-f56703cb1187")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("17e2fac9-f01b-4392-a9d6-be80c85d5ab1"),
				Name = @"DueDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				CreatedInPackageId = new Guid("047f00c4-7c65-4fe2-bb2b-f56703cb1187")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2a6447d4-3c79-4ceb-8b02-aa3eeb1ba11e"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				CreatedInPackageId = new Guid("047f00c4-7c65-4fe2-bb2b-f56703cb1187")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnerTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("52f0ff51-ba26-4402-83bd-056065ca393f"),
				Name = @"PartnerType",
				ReferenceSchemaUId = new Guid("43cadf79-8d33-4697-8344-ec24fa905332"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				CreatedInPackageId = new Guid("047f00c4-7c65-4fe2-bb2b-f56703cb1187"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"d6d8342c-bad2-4161-8aa8-547394b98b49"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateScoreLeftColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("05340663-5114-422d-a4dc-3fc6074a5fbd"),
				Name = @"ScoreLeft",
				CreatedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				ModifiedInSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				CreatedInPackageId = new Guid("ad40b837-06de-4802-b0a3-084f3cf30f81")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Partnership_PRMBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Partnership_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Partnership_PRMBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Partnership_PRMBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"));
		}

		#endregion

	}

	#endregion

	#region Class: Partnership_PRMBase_BPMSoft

	/// <summary>
	/// Партнерство.
	/// </summary>
	public class Partnership_PRMBase_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Partnership_PRMBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Partnership_PRMBase_BPMSoft";
		}

		public Partnership_PRMBase_BPMSoft(Partnership_PRMBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

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
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <exclude/>
		public Guid PartnerLevelId {
			get {
				return GetTypedColumnValue<Guid>("PartnerLevelId");
			}
			set {
				SetColumnValue("PartnerLevelId", value);
				_partnerLevel = null;
			}
		}

		/// <exclude/>
		public string PartnerLevelName {
			get {
				return GetTypedColumnValue<string>("PartnerLevelName");
			}
			set {
				SetColumnValue("PartnerLevelName", value);
				if (_partnerLevel != null) {
					_partnerLevel.Name = value;
				}
			}
		}

		private PartnerLevel _partnerLevel;
		/// <summary>
		/// Уровень.
		/// </summary>
		public PartnerLevel PartnerLevel {
			get {
				return _partnerLevel ??
					(_partnerLevel = LookupColumnEntities.GetEntity("PartnerLevel") as PartnerLevel);
			}
		}

		/// <summary>
		/// Дата начала.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Дата завершения.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Активно.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <exclude/>
		public Guid PartnerTypeId {
			get {
				return GetTypedColumnValue<Guid>("PartnerTypeId");
			}
			set {
				SetColumnValue("PartnerTypeId", value);
				_partnerType = null;
			}
		}

		/// <exclude/>
		public string PartnerTypeName {
			get {
				return GetTypedColumnValue<string>("PartnerTypeName");
			}
			set {
				SetColumnValue("PartnerTypeName", value);
				if (_partnerType != null) {
					_partnerType.Name = value;
				}
			}
		}

		private PartnerType _partnerType;
		/// <summary>
		/// Тип.
		/// </summary>
		public PartnerType PartnerType {
			get {
				return _partnerType ??
					(_partnerType = LookupColumnEntities.GetEntity("PartnerType") as PartnerType);
			}
		}

		/// <summary>
		/// Осталось до уровня.
		/// </summary>
		public int ScoreLeft {
			get {
				return GetTypedColumnValue<int>("ScoreLeft");
			}
			set {
				SetColumnValue("ScoreLeft", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Partnership_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Partnership_PRMBase_BPMSoftDeleted", e);
			Inserted += (s, e) => ThrowEvent("Partnership_PRMBase_BPMSoftInserted", e);
			Saved += (s, e) => ThrowEvent("Partnership_PRMBase_BPMSoftSaved", e);
			Updated += (s, e) => ThrowEvent("Partnership_PRMBase_BPMSoftUpdated", e);
			Updating += (s, e) => ThrowEvent("Partnership_PRMBase_BPMSoftUpdating", e);
			Validating += (s, e) => ThrowEvent("Partnership_PRMBase_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Partnership_PRMBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Partnership_PRMBaseEventsProcess

	/// <exclude/>
	public partial class Partnership_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Partnership_PRMBase_BPMSoft
	{

		public Partnership_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Partnership_PRMBaseEventsProcess";
			SchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
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
					SchemaElementUId = new Guid("38ffbefa-60e7-4a6b-bd17-cd1c11ba4fd0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage1;
		public ProcessFlowElement StartMessage1 {
			get {
				return _startMessage1 ?? (_startMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1",
					SchemaElementUId = new Guid("5b50c550-a8d2-4b5a-90d6-522a9cef0ceb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onPartnershipSaved;
		public ProcessScriptTask OnPartnershipSaved {
			get {
				return _onPartnershipSaved ?? (_onPartnershipSaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnPartnershipSaved",
					SchemaElementUId = new Guid("4eac8c13-d02c-4d07-a637-dbc2c4c98774"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnPartnershipSavedExecute,
				});
			}
		}

		private ProcessFlowElement _partnershipInsertedEventSubProcess;
		public ProcessFlowElement PartnershipInsertedEventSubProcess {
			get {
				return _partnershipInsertedEventSubProcess ?? (_partnershipInsertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "PartnershipInsertedEventSubProcess",
					SchemaElementUId = new Guid("71c80eec-a5c6-462c-b9c2-c043d762f664"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage2;
		public ProcessFlowElement StartMessage2 {
			get {
				return _startMessage2 ?? (_startMessage2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage2",
					SchemaElementUId = new Guid("1e8d081b-e402-45b9-9545-edf5e1c82e01"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onPartnershipInsertedScriptTask;
		public ProcessScriptTask OnPartnershipInsertedScriptTask {
			get {
				return _onPartnershipInsertedScriptTask ?? (_onPartnershipInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnPartnershipInsertedScriptTask",
					SchemaElementUId = new Guid("914c0a70-48c4-43b0-9792-f4431c7c7cf9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnPartnershipInsertedScriptTaskExecute,
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
					SchemaElementUId = new Guid("3996b812-de69-4433-96cc-ae7ea2d2eedf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _partnershipUpdated;
		public ProcessFlowElement PartnershipUpdated {
			get {
				return _partnershipUpdated ?? (_partnershipUpdated = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PartnershipUpdated",
					SchemaElementUId = new Guid("94fc97e5-ecec-4b31-8393-2bec88bfba9c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onPartnershipUpdatedScriptTask;
		public ProcessScriptTask OnPartnershipUpdatedScriptTask {
			get {
				return _onPartnershipUpdatedScriptTask ?? (_onPartnershipUpdatedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnPartnershipUpdatedScriptTask",
					SchemaElementUId = new Guid("9546c9d0-5f23-4828-815c-3ca993d079a8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnPartnershipUpdatedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[StartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1 };
			FlowElements[OnPartnershipSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { OnPartnershipSaved };
			FlowElements[PartnershipInsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipInsertedEventSubProcess };
			FlowElements[StartMessage2.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage2 };
			FlowElements[OnPartnershipInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OnPartnershipInsertedScriptTask };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[PartnershipUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { PartnershipUpdated };
			FlowElements[OnPartnershipUpdatedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OnPartnershipUpdatedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "StartMessage1":
						e.Context.QueueTasks.Enqueue("OnPartnershipSaved");
						break;
					case "OnPartnershipSaved":
						break;
					case "PartnershipInsertedEventSubProcess":
						break;
					case "StartMessage2":
						e.Context.QueueTasks.Enqueue("OnPartnershipInsertedScriptTask");
						break;
					case "OnPartnershipInsertedScriptTask":
						break;
					case "EventSubProcess3":
						break;
					case "PartnershipUpdated":
						e.Context.QueueTasks.Enqueue("OnPartnershipUpdatedScriptTask");
						break;
					case "OnPartnershipUpdatedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage1");
			ActivatedEventElements.Add("StartMessage2");
			ActivatedEventElements.Add("PartnershipUpdated");
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
				case "StartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage1";
					result = StartMessage1.Execute(context);
					break;
				case "OnPartnershipSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnPartnershipSaved";
					result = OnPartnershipSaved.Execute(context, OnPartnershipSavedExecute);
					break;
				case "PartnershipInsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage2":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage2";
					result = StartMessage2.Execute(context);
					break;
				case "OnPartnershipInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnPartnershipInsertedScriptTask";
					result = OnPartnershipInsertedScriptTask.Execute(context, OnPartnershipInsertedScriptTaskExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "PartnershipUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "PartnershipUpdated";
					result = PartnershipUpdated.Execute(context);
					break;
				case "OnPartnershipUpdatedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnPartnershipUpdatedScriptTask";
					result = OnPartnershipUpdatedScriptTask.Execute(context, OnPartnershipUpdatedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool OnPartnershipSavedExecute(ProcessExecutingContext context) {
			if (UserConnection.GetIsFeatureEnabled("EnableOldPartnershipLogic")) {
				UpdateActivePartnerships(context);
			}
			return true;
		}

		public virtual bool OnPartnershipInsertedScriptTaskExecute(ProcessExecutingContext context) {
			if (UserConnection.GetIsFeatureEnabled("EnableOldPartnershipLogic")) {
				OnPartnershipInserted(context);
			}
			return true;
		}

		public virtual bool OnPartnershipUpdatedScriptTaskExecute(ProcessExecutingContext context) {
			if (UserConnection.GetIsFeatureEnabled("EnableOldPartnershipLogic")) {
				OnPartnershipUpdated(context);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Partnership_PRMBase_BPMSoftSaved":
							if (ActivatedEventElements.Contains("StartMessage1")) {
							context.QueueTasks.Enqueue("StartMessage1");
						}
						break;
					case "Partnership_PRMBase_BPMSoftInserted":
							if (ActivatedEventElements.Contains("StartMessage2")) {
							context.QueueTasks.Enqueue("StartMessage2");
						}
						break;
					case "Partnership_PRMBase_BPMSoftUpdated":
							if (ActivatedEventElements.Contains("PartnershipUpdated")) {
							context.QueueTasks.Enqueue("PartnershipUpdated");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Partnership_PRMBaseEventsProcess

	/// <exclude/>
	public class Partnership_PRMBaseEventsProcess : Partnership_PRMBaseEventsProcess<Partnership_PRMBase_BPMSoft>
	{

		public Partnership_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Partnership_PRMBaseEventsProcess

	public partial class Partnership_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void UpdateActivePartnerships(ProcessExecutingContext context) {
			var isActive = Entity.GetTypedColumnValue<bool>("IsActive");
			if (isActive) {
				Update update = new Update(UserConnection, "Partnership")
					.Set("IsActive", Column.Parameter(false))
					.Where("Id").IsNotEqual(Column.Parameter(Entity.PrimaryColumnValue))
					.And("AccountId").IsEqual(Column.Parameter(Entity.GetTypedColumnValue<Guid>("AccountId"))) as Update;
				update.Execute();
			}
		}

		public virtual void OnPartnershipInserted(ProcessExecutingContext context) {
			var currentId = PRMBaseConstants.CurrentPartnershipParamTypeId;
			var targetId = PRMBaseConstants.TargetPartnershipParamTypeId;
			var obligationTypeId = PRMBaseConstants.ObligationParameterTypeId;
			var benefitTypeId = PRMBaseConstants.BenefitParameterTypeId;
			
			var partnershipId = Entity.PrimaryColumnValue;
			var partnerLevelId = Entity.GetTypedColumnValue<Guid>("PartnerLevelId");
			
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			var benefitEsq = GetLevelPartnershipParamEsq(benefitTypeId, partnerLevelId);
			var benefitCollection = benefitEsq.GetEntityCollection(UserConnection);
			var partnershipParameterSchema = entitySchemaManager.GetInstanceByName("PartnershipParameter");
			foreach (var levelPartnershipParam in benefitCollection) {
				var benefitPartnershipParameter = partnershipParameterSchema.CreateEntity(UserConnection);
				CopyLevelPartnershipParameterValues(benefitPartnershipParameter, levelPartnershipParam);
				benefitPartnershipParameter.SetColumnValue("ParameterTypeId", benefitTypeId);
				benefitPartnershipParameter.SetColumnValue("PartnershipParameterTypeId", currentId);
				benefitPartnershipParameter.SetColumnValue("PartnershipId", partnershipId);
				benefitPartnershipParameter.SetColumnValue("PartnerLevelId", partnerLevelId);
				benefitPartnershipParameter.Save();
			}
			var obligationEsq = GetLevelPartnershipParamEsq(obligationTypeId, partnerLevelId);
			var obligationCollection = obligationEsq.GetEntityCollection(UserConnection);
			foreach (var levelPartnershipParam in obligationCollection) {
				var currentPartnershipParameter = partnershipParameterSchema.CreateEntity(UserConnection);
				var partnerParamCategoryId = levelPartnershipParam.GetTypedColumnValue<Guid>("PartnerParamCategoryId");
				var parameterValueTypeId = levelPartnershipParam.GetTypedColumnValue<Guid>("ParameterValueTypeId");
				currentPartnershipParameter.SetDefColumnValues();
				currentPartnershipParameter.SetColumnValue("ParameterTypeId", obligationTypeId);
				currentPartnershipParameter.SetColumnValue("PartnershipParameterTypeId", currentId);
				currentPartnershipParameter.SetColumnValue("PartnershipId", partnershipId);
				currentPartnershipParameter.SetColumnValue("PartnerParamCategoryId", partnerParamCategoryId);
				currentPartnershipParameter.SetColumnValue("ParameterValueTypeId", parameterValueTypeId);
				currentPartnershipParameter.SetColumnValue("PartnerLevelId", partnerLevelId);
				currentPartnershipParameter.Save();
			}
			foreach (var levelPartnershipParam in obligationCollection) {
				var targetPartnershipParameter = partnershipParameterSchema.CreateEntity(UserConnection);
				CopyLevelPartnershipParameterValues(targetPartnershipParameter, levelPartnershipParam);
				targetPartnershipParameter.SetColumnValue("ParameterTypeId", obligationTypeId);
				targetPartnershipParameter.SetColumnValue("PartnershipParameterTypeId", targetId);
				targetPartnershipParameter.SetColumnValue("PartnershipId", partnershipId);
				targetPartnershipParameter.SetColumnValue("PartnerLevelId", partnerLevelId);
				targetPartnershipParameter.Save();
			}
			PartnershipHelper partnershipHelper
					= ClassFactory.Get<PartnershipHelper>(new ConstructorArgument("userConnection", UserConnection));
			partnershipHelper.SetPartnershipScoreLeft(partnershipId);
		}

		public virtual void OnPartnershipUpdated(ProcessExecutingContext context) {
			var partnerLevel = Entity.GetTypedColumnValue<Guid>("PartnerLevelId");
			var oldPartnerLevel = Entity.GetTypedOldColumnValue<Guid>("PartnerLevelId");
			if (partnerLevel == oldPartnerLevel) {
				return;
			}
			PartnershipHelper partnershipHelper
					= ClassFactory.Get<PartnershipHelper>(new ConstructorArgument("userConnection", UserConnection));
			var partnershipId = Entity.GetTypedColumnValue<Guid>("Id");
			EntityCollection levelPartnershipParameters = partnershipHelper.GetLevelPartnershipParameters(partnerLevel);
			partnershipHelper.DeleteOldBenefits(partnershipId);
			partnershipHelper.DeleteOldTarget(partnershipId);
			List<Guid> listOfNotDeletedCategoryId = levelPartnershipParameters.Select(x => x.GetTypedColumnValue<Guid>("PartnerParamCategoryId")).ToList();
			List<object> list = listOfNotDeletedCategoryId.ConvertAll<object>(new Converter<Guid, object>(g => (object)g));
			partnershipHelper.DeleteCurrentCategory(partnershipId, list.ToArray());
			partnershipHelper.CopyBenefitParameters(partnershipId, partnerLevel, levelPartnershipParameters);
			EntityCollection currentObligations = partnershipHelper.GetCurrentObligations(partnershipId);
			foreach (var partnershipParam in currentObligations) {
				partnershipParam.SetColumnValue("PartnerLevelId", partnerLevel);
				partnershipParam.Save();
			}
			partnershipHelper.AddNewCurrentObligations(partnershipId, partnerLevel, currentObligations, levelPartnershipParameters);
			partnershipHelper.AddNewTargetObligations(partnershipId, partnerLevel, levelPartnershipParameters);
			partnershipHelper.RecalculateAllScore(partnershipId);
			partnershipHelper.ChangePartnershipLevel(partnershipId);
		}

		public virtual EntitySchemaQuery GetLevelPartnershipParamEsq(Guid parameterTypeId, Guid partnerLevelId) {
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByName("LevelPartnershipParam");
			var esq = new EntitySchemaQuery(entitySchema);
			esq.AddColumn("PartnerParamCategory");
			esq.AddColumn("ParameterValueType");
			esq.AddColumn("IntValue");
			esq.AddColumn("StringValue");
			esq.AddColumn("FloatValue");
			esq.AddColumn("BooleanValue");
			esq.AddColumn("Score");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "PartnerLevel", partnerLevelId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ParameterType", parameterTypeId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "StartDate", DateTime.UtcNow));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.GreaterOrEqual, "DueDate", DateTime.UtcNow));
			return esq;
		}

		public virtual void CopyLevelPartnershipParameterValues(Entity partnershipParameter, Entity levelPartnershipParam) {
			var partnerParamCategoryId = levelPartnershipParam.GetTypedColumnValue<Guid>("PartnerParamCategoryId");
			var parameterValueTypeId = levelPartnershipParam.GetTypedColumnValue<Guid>("ParameterValueTypeId");
			var stringValue = levelPartnershipParam.GetTypedColumnValue<string>("StringValue");
			var intValue = levelPartnershipParam.GetTypedColumnValue<int>("IntValue");
			var floatValue = levelPartnershipParam.GetTypedColumnValue<double>("FloatValue");
			var booleanValue = levelPartnershipParam.GetTypedColumnValue<bool>("BooleanValue");
			var score = levelPartnershipParam.GetTypedColumnValue<int>("Score");
			partnershipParameter.SetDefColumnValues();
			partnershipParameter.SetColumnValue("StringValue", stringValue);
			partnershipParameter.SetColumnValue("IntValue", intValue);
			partnershipParameter.SetColumnValue("FloatValue", floatValue);
			partnershipParameter.SetColumnValue("BooleanValue", booleanValue);
			partnershipParameter.SetColumnValue("Score", score);
			partnershipParameter.SetColumnValue("PartnerParamCategoryId", partnerParamCategoryId);
			partnershipParameter.SetColumnValue("ParameterValueTypeId", parameterValueTypeId);
		}

		#endregion

	}

	#endregion

}

