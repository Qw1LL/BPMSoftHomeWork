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

	#region Class: PRMTransaction_PRMBase_BPMSoftSchema

	/// <exclude/>
	public class PRMTransaction_PRMBase_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public PRMTransaction_PRMBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PRMTransaction_PRMBase_BPMSoftSchema(PRMTransaction_PRMBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PRMTransaction_PRMBase_BPMSoftSchema(PRMTransaction_PRMBase_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26");
			RealUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26");
			Name = "PRMTransaction_PRMBase_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e3f6af0f-4ac0-46d1-b2e6-e18d10bd5c8e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5f2fbe25-b461-458b-90cc-f306506a7b24")) == null) {
				Columns.Add(CreateAmountColumn());
			}
			if (Columns.FindByUId(new Guid("64288f0c-505b-466c-98d2-ab5cadbd6f0c")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("4243678b-b970-429d-94d2-70f7b5888882")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("d21c3641-3022-44c4-9a79-34df75905602")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("1a4672d4-ea8a-4ecc-9d96-afe7fcf6dd42")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("f5c3767a-15e0-4e59-8252-165a7f19d80e")) == null) {
				Columns.Add(CreateFundColumn());
			}
			if (Columns.FindByUId(new Guid("50b2e5f6-9b51-4954-9f99-3571ebbed2c1")) == null) {
				Columns.Add(CreatePartnershipColumn());
			}
			if (Columns.FindByUId(new Guid("101f0411-c552-42d7-aada-843a28e74f5a")) == null) {
				Columns.Add(CreateTransactionTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("5f2fbe25-b461-458b-90cc-f306506a7b24"),
				Name = @"Amount",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				ModifiedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				CreatedInPackageId = new Guid("e3f6af0f-4ac0-46d1-b2e6-e18d10bd5c8e")
			};
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("64288f0c-505b-466c-98d2-ab5cadbd6f0c"),
				Name = @"Date",
				CreatedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				ModifiedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				CreatedInPackageId = new Guid("e3f6af0f-4ac0-46d1-b2e6-e18d10bd5c8e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4243678b-b970-429d-94d2-70f7b5888882"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				ModifiedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				CreatedInPackageId = new Guid("e3f6af0f-4ac0-46d1-b2e6-e18d10bd5c8e")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d21c3641-3022-44c4-9a79-34df75905602"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				ModifiedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				CreatedInPackageId = new Guid("e3f6af0f-4ac0-46d1-b2e6-e18d10bd5c8e")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("1a4672d4-ea8a-4ecc-9d96-afe7fcf6dd42"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				ModifiedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				CreatedInPackageId = new Guid("e3f6af0f-4ac0-46d1-b2e6-e18d10bd5c8e")
			};
		}

		protected virtual EntitySchemaColumn CreateFundColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f5c3767a-15e0-4e59-8252-165a7f19d80e"),
				Name = @"Fund",
				ReferenceSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				ModifiedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				CreatedInPackageId = new Guid("e3f6af0f-4ac0-46d1-b2e6-e18d10bd5c8e")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnershipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("50b2e5f6-9b51-4954-9f99-3571ebbed2c1"),
				Name = @"Partnership",
				ReferenceSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				ModifiedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				CreatedInPackageId = new Guid("1b540174-2dfe-4dee-ae21-9985404549f1")
			};
		}

		protected virtual EntitySchemaColumn CreateTransactionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("101f0411-c552-42d7-aada-843a28e74f5a"),
				Name = @"TransactionType",
				ReferenceSchemaUId = new Guid("49361e32-f6a5-4eb0-b0b2-7e13b1e2ed30"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				ModifiedInSchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"),
				CreatedInPackageId = new Guid("f43a6760-9275-4070-90a5-eacccad59d8c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PRMTransaction_PRMBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PRMTransaction_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PRMTransaction_PRMBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PRMTransaction_PRMBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26"));
		}

		#endregion

	}

	#endregion

	#region Class: PRMTransaction_PRMBase_BPMSoft

	/// <summary>
	/// Операция.
	/// </summary>
	public class PRMTransaction_PRMBase_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public PRMTransaction_PRMBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PRMTransaction_PRMBase_BPMSoft";
		}

		public PRMTransaction_PRMBase_BPMSoft(PRMTransaction_PRMBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Сумма/Количество.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Дата операции.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
			}
		}

		/// <summary>
		/// Идентификатор записи.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// Идентификатор объекта.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
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
		public Guid FundId {
			get {
				return GetTypedColumnValue<Guid>("FundId");
			}
			set {
				SetColumnValue("FundId", value);
				_fund = null;
			}
		}

		/// <exclude/>
		public string FundName {
			get {
				return GetTypedColumnValue<string>("FundName");
			}
			set {
				SetColumnValue("FundName", value);
				if (_fund != null) {
					_fund.Name = value;
				}
			}
		}

		private Fund _fund;
		/// <summary>
		/// Фонд.
		/// </summary>
		public Fund Fund {
			get {
				return _fund ??
					(_fund = LookupColumnEntities.GetEntity("Fund") as Fund);
			}
		}

		/// <exclude/>
		public Guid PartnershipId {
			get {
				return GetTypedColumnValue<Guid>("PartnershipId");
			}
			set {
				SetColumnValue("PartnershipId", value);
				_partnership = null;
			}
		}

		/// <exclude/>
		public string PartnershipName {
			get {
				return GetTypedColumnValue<string>("PartnershipName");
			}
			set {
				SetColumnValue("PartnershipName", value);
				if (_partnership != null) {
					_partnership.Name = value;
				}
			}
		}

		private Partnership _partnership;
		/// <summary>
		/// Партнерство.
		/// </summary>
		public Partnership Partnership {
			get {
				return _partnership ??
					(_partnership = LookupColumnEntities.GetEntity("Partnership") as Partnership);
			}
		}

		/// <exclude/>
		public Guid TransactionTypeId {
			get {
				return GetTypedColumnValue<Guid>("TransactionTypeId");
			}
			set {
				SetColumnValue("TransactionTypeId", value);
				_transactionType = null;
			}
		}

		/// <exclude/>
		public string TransactionTypeName {
			get {
				return GetTypedColumnValue<string>("TransactionTypeName");
			}
			set {
				SetColumnValue("TransactionTypeName", value);
				if (_transactionType != null) {
					_transactionType.Name = value;
				}
			}
		}

		private PRMTransactionType _transactionType;
		/// <summary>
		/// Тип.
		/// </summary>
		public PRMTransactionType TransactionType {
			get {
				return _transactionType ??
					(_transactionType = LookupColumnEntities.GetEntity("TransactionType") as PRMTransactionType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PRMTransaction_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PRMTransaction_PRMBase_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("PRMTransaction_PRMBase_BPMSoftDeleting", e);
			Inserting += (s, e) => ThrowEvent("PRMTransaction_PRMBase_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("PRMTransaction_PRMBase_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PRMTransaction_PRMBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: PRMTransaction_PRMBaseEventsProcess

	/// <exclude/>
	public partial class PRMTransaction_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : PRMTransaction_PRMBase_BPMSoft
	{

		public PRMTransaction_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PRMTransaction_PRMBaseEventsProcess";
			SchemaUId = new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3fd4e44d-f373-4dea-8263-6bcfb3f64d26");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _pRMTransactionInsertingEventSubProcess;
		public ProcessFlowElement PRMTransactionInsertingEventSubProcess {
			get {
				return _pRMTransactionInsertingEventSubProcess ?? (_pRMTransactionInsertingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "PRMTransactionInsertingEventSubProcess",
					SchemaElementUId = new Guid("716b39c0-c5c1-4fe0-a532-6b7a1b404ad7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _pRMTransactionInsertingScriptTask;
		public ProcessScriptTask PRMTransactionInsertingScriptTask {
			get {
				return _pRMTransactionInsertingScriptTask ?? (_pRMTransactionInsertingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PRMTransactionInsertingScriptTask",
					SchemaElementUId = new Guid("648688a0-bb91-4abe-97d8-273af32e5130"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PRMTransactionInsertingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _pRMTransactionInsertingStartMessage;
		public ProcessFlowElement PRMTransactionInsertingStartMessage {
			get {
				return _pRMTransactionInsertingStartMessage ?? (_pRMTransactionInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PRMTransactionInsertingStartMessage",
					SchemaElementUId = new Guid("cc8805a5-d83a-48b0-806e-f14c52b8202c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _pRMTransactionDeletingEventSubProcess;
		public ProcessFlowElement PRMTransactionDeletingEventSubProcess {
			get {
				return _pRMTransactionDeletingEventSubProcess ?? (_pRMTransactionDeletingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "PRMTransactionDeletingEventSubProcess",
					SchemaElementUId = new Guid("a7837f4b-403e-4655-8457-3b0cef567271"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _pRMTransactionDeletingStartMessage;
		public ProcessFlowElement PRMTransactionDeletingStartMessage {
			get {
				return _pRMTransactionDeletingStartMessage ?? (_pRMTransactionDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PRMTransactionDeletingStartMessage",
					SchemaElementUId = new Guid("b10c2a6e-bf03-47ba-baef-582ce20271db"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _pRMTransactionDeletingScriptTask;
		public ProcessScriptTask PRMTransactionDeletingScriptTask {
			get {
				return _pRMTransactionDeletingScriptTask ?? (_pRMTransactionDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PRMTransactionDeletingScriptTask",
					SchemaElementUId = new Guid("59ce3af1-8c73-4cdd-b777-299fae5fc397"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PRMTransactionDeletingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[PRMTransactionInsertingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { PRMTransactionInsertingEventSubProcess };
			FlowElements[PRMTransactionInsertingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PRMTransactionInsertingScriptTask };
			FlowElements[PRMTransactionInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { PRMTransactionInsertingStartMessage };
			FlowElements[PRMTransactionDeletingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { PRMTransactionDeletingEventSubProcess };
			FlowElements[PRMTransactionDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { PRMTransactionDeletingStartMessage };
			FlowElements[PRMTransactionDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PRMTransactionDeletingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "PRMTransactionInsertingEventSubProcess":
						break;
					case "PRMTransactionInsertingScriptTask":
						break;
					case "PRMTransactionInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("PRMTransactionInsertingScriptTask");
						break;
					case "PRMTransactionDeletingEventSubProcess":
						break;
					case "PRMTransactionDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("PRMTransactionDeletingScriptTask");
						break;
					case "PRMTransactionDeletingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("PRMTransactionInsertingStartMessage");
			ActivatedEventElements.Add("PRMTransactionDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "PRMTransactionInsertingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "PRMTransactionInsertingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PRMTransactionInsertingScriptTask";
					result = PRMTransactionInsertingScriptTask.Execute(context, PRMTransactionInsertingScriptTaskExecute);
					break;
				case "PRMTransactionInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "PRMTransactionInsertingStartMessage";
					result = PRMTransactionInsertingStartMessage.Execute(context);
					break;
				case "PRMTransactionDeletingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "PRMTransactionDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "PRMTransactionDeletingStartMessage";
					result = PRMTransactionDeletingStartMessage.Execute(context);
					break;
				case "PRMTransactionDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PRMTransactionDeletingScriptTask";
					result = PRMTransactionDeletingScriptTask.Execute(context, PRMTransactionDeletingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool PRMTransactionInsertingScriptTaskExecute(ProcessExecutingContext context) {
			if (UserConnection.GetIsFeatureEnabled("SyncOppWithFund")) {
				OnTransactionInserting();
			}
			return true;
		}

		public virtual bool PRMTransactionDeletingScriptTaskExecute(ProcessExecutingContext context) {
			if (UserConnection.GetIsFeatureEnabled("SyncOppWithFund")) {
				OnTransactionDeleting();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "PRMTransaction_PRMBase_BPMSoftInserting":
							if (ActivatedEventElements.Contains("PRMTransactionInsertingStartMessage")) {
							context.QueueTasks.Enqueue("PRMTransactionInsertingStartMessage");
						}
						break;
					case "PRMTransaction_PRMBase_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("PRMTransactionDeletingStartMessage")) {
							context.QueueTasks.Enqueue("PRMTransactionDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: PRMTransaction_PRMBaseEventsProcess

	/// <exclude/>
	public class PRMTransaction_PRMBaseEventsProcess : PRMTransaction_PRMBaseEventsProcess<PRMTransaction_PRMBase_BPMSoft>
	{

		public PRMTransaction_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PRMTransaction_PRMBaseEventsProcess

	public partial class PRMTransaction_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void UpdateFundAmount(double transactionAmount) {
			Guid fundId = Entity.GetTypedColumnValue<Guid>("FundId");
			EntitySchema fundSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Fund");
			Entity fundEntity = fundSchema.CreateEntity(UserConnection);
			fundEntity.UseAdminRights = false;
			if (!fundEntity.FetchFromDB(fundId)) {
				return;
			}
			double fundAmount = fundEntity.GetTypedColumnValue<double>("Amount");
			fundEntity.SetColumnValue("Amount", fundAmount + transactionAmount);
			fundEntity.Save();
		}

		public virtual void OnTransactionInserting() {
			Guid typeId = Entity.GetTypedColumnValue<Guid>("TransactionTypeId");
			double transactionAmount = Entity.GetTypedColumnValue<double>("Amount");
			if (typeId == null) {
				return;
			}
			if (Guid.Equals(PRMBaseConstants.CreditTransactionType, typeId)) {
				transactionAmount = Math.Abs(transactionAmount);
			}
			if (Guid.Equals(PRMBaseConstants.DebitTransactionType, typeId)) {
				transactionAmount = -1 * Math.Abs(transactionAmount);
			}
			Entity.SetColumnValue("Amount", transactionAmount);
			UpdateFundAmount(transactionAmount);
		}

		public virtual void OnTransactionDeleting() {
			Guid typeId = Entity.GetTypedColumnValue<Guid>("TransactionTypeId");
			double transactionAmount = Entity.GetTypedColumnValue<double>("Amount");
			if (typeId == null) {
				return;
			}
			if (Guid.Equals(PRMBaseConstants.CreditTransactionType, typeId)) {
				transactionAmount = -1 * Math.Abs(transactionAmount);
			}
			if (Guid.Equals(PRMBaseConstants.DebitTransactionType, typeId)) {
				transactionAmount = Math.Abs(transactionAmount);
			}
			UpdateFundAmount(transactionAmount);
		}

		#endregion

	}

	#endregion

}

