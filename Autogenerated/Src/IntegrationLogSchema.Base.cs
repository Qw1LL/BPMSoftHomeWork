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

	#region Class: IntegrationLogSchema

	/// <exclude/>
	public class IntegrationLogSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public IntegrationLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public IntegrationLogSchema(IntegrationLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public IntegrationLogSchema(IntegrationLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086");
			RealUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086");
			Name = "IntegrationLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cc2ebf21-ef2d-4ef3-80da-6345649c70c9")) == null) {
				Columns.Add(CreateIntegrationSystemColumn());
			}
			if (Columns.FindByUId(new Guid("0712b7db-3846-47e5-b735-6fc5d962f759")) == null) {
				Columns.Add(CreateSessionNumberColumn());
			}
			if (Columns.FindByUId(new Guid("0c2b0beb-339d-4e42-bba6-3f06267b831b")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("4f45a347-95cf-4c1b-be43-be69fc62806d")) == null) {
				Columns.Add(CreateDirectionColumn());
			}
			if (Columns.FindByUId(new Guid("384024d7-330a-4487-90e8-a8bbaf58bb49")) == null) {
				Columns.Add(CreateOperationColumn());
			}
			if (Columns.FindByUId(new Guid("40ad9faa-f737-4828-83d4-90c845b435a5")) == null) {
				Columns.Add(CreateResultColumn());
			}
			if (Columns.FindByUId(new Guid("e272fb1a-d751-4cbe-b633-f24086f64cf2")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("98bfc088-c17b-4fdd-bafd-fa59253b2c66")) == null) {
				Columns.Add(CreateErrorDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIntegrationSystemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cc2ebf21-ef2d-4ef3-80da-6345649c70c9"),
				Name = @"IntegrationSystem",
				ReferenceSchemaUId = new Guid("673fd68f-fe84-465a-a2d3-ff7bd824b22f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				ModifiedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateSessionNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0712b7db-3846-47e5-b735-6fc5d962f759"),
				Name = @"SessionNumber",
				CreatedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				ModifiedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("0c2b0beb-339d-4e42-bba6-3f06267b831b"),
				Name = @"Date",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				ModifiedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDirectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4f45a347-95cf-4c1b-be43-be69fc62806d"),
				Name = @"Direction",
				ReferenceSchemaUId = new Guid("0ad85e2e-9a97-41f2-9fe5-7e6b8af16844"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				ModifiedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("384024d7-330a-4487-90e8-a8bbaf58bb49"),
				Name = @"Operation",
				ReferenceSchemaUId = new Guid("e8feefe8-3d22-4f8d-aca2-32d180f7fa92"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				ModifiedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("40ad9faa-f737-4828-83d4-90c845b435a5"),
				Name = @"Result",
				ReferenceSchemaUId = new Guid("fb695ee6-670b-4dc7-9118-7df4ccf95ed7"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				ModifiedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("e272fb1a-d751-4cbe-b633-f24086f64cf2"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				ModifiedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateErrorDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("98bfc088-c17b-4fdd-bafd-fa59253b2c66"),
				Name = @"ErrorDescription",
				CreatedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
				ModifiedInSchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"),
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
			return new IntegrationLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new IntegrationLog_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new IntegrationLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new IntegrationLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086"));
		}

		#endregion

	}

	#endregion

	#region Class: IntegrationLog

	/// <summary>
	/// Integration log.
	/// </summary>
	public class IntegrationLog : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public IntegrationLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "IntegrationLog";
		}

		public IntegrationLog(IntegrationLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid IntegrationSystemId {
			get {
				return GetTypedColumnValue<Guid>("IntegrationSystemId");
			}
			set {
				SetColumnValue("IntegrationSystemId", value);
				_integrationSystem = null;
			}
		}

		/// <exclude/>
		public string IntegrationSystemName {
			get {
				return GetTypedColumnValue<string>("IntegrationSystemName");
			}
			set {
				SetColumnValue("IntegrationSystemName", value);
				if (_integrationSystem != null) {
					_integrationSystem.Name = value;
				}
			}
		}

		private IntegrationSystem _integrationSystem;
		/// <summary>
		/// Integration system.
		/// </summary>
		public IntegrationSystem IntegrationSystem {
			get {
				return _integrationSystem ??
					(_integrationSystem = LookupColumnEntities.GetEntity("IntegrationSystem") as IntegrationSystem);
			}
		}

		/// <summary>
		/// Session number.
		/// </summary>
		public int SessionNumber {
			get {
				return GetTypedColumnValue<int>("SessionNumber");
			}
			set {
				SetColumnValue("SessionNumber", value);
			}
		}

		/// <summary>
		/// Date.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
			}
		}

		/// <exclude/>
		public Guid DirectionId {
			get {
				return GetTypedColumnValue<Guid>("DirectionId");
			}
			set {
				SetColumnValue("DirectionId", value);
				_direction = null;
			}
		}

		/// <exclude/>
		public string DirectionName {
			get {
				return GetTypedColumnValue<string>("DirectionName");
			}
			set {
				SetColumnValue("DirectionName", value);
				if (_direction != null) {
					_direction.Name = value;
				}
			}
		}

		private IntegrationDirection _direction;
		/// <summary>
		/// Direction.
		/// </summary>
		public IntegrationDirection Direction {
			get {
				return _direction ??
					(_direction = LookupColumnEntities.GetEntity("Direction") as IntegrationDirection);
			}
		}

		/// <exclude/>
		public Guid OperationId {
			get {
				return GetTypedColumnValue<Guid>("OperationId");
			}
			set {
				SetColumnValue("OperationId", value);
				_operation = null;
			}
		}

		/// <exclude/>
		public string OperationName {
			get {
				return GetTypedColumnValue<string>("OperationName");
			}
			set {
				SetColumnValue("OperationName", value);
				if (_operation != null) {
					_operation.Name = value;
				}
			}
		}

		private IntegrationOperation _operation;
		/// <summary>
		/// Operation.
		/// </summary>
		public IntegrationOperation Operation {
			get {
				return _operation ??
					(_operation = LookupColumnEntities.GetEntity("Operation") as IntegrationOperation);
			}
		}

		/// <exclude/>
		public Guid ResultId {
			get {
				return GetTypedColumnValue<Guid>("ResultId");
			}
			set {
				SetColumnValue("ResultId", value);
				_result = null;
			}
		}

		/// <exclude/>
		public string ResultName {
			get {
				return GetTypedColumnValue<string>("ResultName");
			}
			set {
				SetColumnValue("ResultName", value);
				if (_result != null) {
					_result.Name = value;
				}
			}
		}

		private IntegrationResult _result;
		/// <summary>
		/// Result.
		/// </summary>
		public IntegrationResult Result {
			get {
				return _result ??
					(_result = LookupColumnEntities.GetEntity("Result") as IntegrationResult);
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
		/// Error details.
		/// </summary>
		public string ErrorDescription {
			get {
				return GetTypedColumnValue<string>("ErrorDescription");
			}
			set {
				SetColumnValue("ErrorDescription", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new IntegrationLog_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("IntegrationLogDeleted", e);
			Deleting += (s, e) => ThrowEvent("IntegrationLogDeleting", e);
			Inserting += (s, e) => ThrowEvent("IntegrationLogInserting", e);
			Saving += (s, e) => ThrowEvent("IntegrationLogSaving", e);
			Validating += (s, e) => ThrowEvent("IntegrationLogValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new IntegrationLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: IntegrationLog_BaseEventsProcess

	/// <exclude/>
	public partial class IntegrationLog_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : IntegrationLog
	{

		public IntegrationLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "IntegrationLog_BaseEventsProcess";
			SchemaUId = new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d5bb4bdc-06d3-4275-8d23-96ae2a19b086");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _integrationLogEventSubProcess;
		public ProcessFlowElement IntegrationLogEventSubProcess {
			get {
				return _integrationLogEventSubProcess ?? (_integrationLogEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "IntegrationLogEventSubProcess",
					SchemaElementUId = new Guid("c277160d-4a50-4519-a473-356332dfadf5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _integrationLogInsertingStartMessage;
		public ProcessFlowElement IntegrationLogInsertingStartMessage {
			get {
				return _integrationLogInsertingStartMessage ?? (_integrationLogInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "IntegrationLogInsertingStartMessage",
					SchemaElementUId = new Guid("eaeb9c4a-d166-4866-b55b-0873436da347"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _integrationLogSavingStartMessage;
		public ProcessFlowElement IntegrationLogSavingStartMessage {
			get {
				return _integrationLogSavingStartMessage ?? (_integrationLogSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "IntegrationLogSavingStartMessage",
					SchemaElementUId = new Guid("bf3a5391-db38-4a89-8685-07f1be7ba68b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _integrationLogDeletingStartMessage;
		public ProcessFlowElement IntegrationLogDeletingStartMessage {
			get {
				return _integrationLogDeletingStartMessage ?? (_integrationLogDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "IntegrationLogDeletingStartMessage",
					SchemaElementUId = new Guid("f789eeda-4e58-4a07-9dfc-822b07ec308b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _integrationLogCheckCanExecuteOperationsScriptTask;
		public ProcessScriptTask IntegrationLogCheckCanExecuteOperationsScriptTask {
			get {
				return _integrationLogCheckCanExecuteOperationsScriptTask ?? (_integrationLogCheckCanExecuteOperationsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "IntegrationLogCheckCanExecuteOperationsScriptTask",
					SchemaElementUId = new Guid("287bacc9-0174-496a-96de-319678893477"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = IntegrationLogCheckCanExecuteOperationsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[IntegrationLogEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { IntegrationLogEventSubProcess };
			FlowElements[IntegrationLogInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { IntegrationLogInsertingStartMessage };
			FlowElements[IntegrationLogSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { IntegrationLogSavingStartMessage };
			FlowElements[IntegrationLogDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { IntegrationLogDeletingStartMessage };
			FlowElements[IntegrationLogCheckCanExecuteOperationsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { IntegrationLogCheckCanExecuteOperationsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "IntegrationLogEventSubProcess":
						break;
					case "IntegrationLogInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("IntegrationLogCheckCanExecuteOperationsScriptTask");
						break;
					case "IntegrationLogSavingStartMessage":
						e.Context.QueueTasks.Enqueue("IntegrationLogCheckCanExecuteOperationsScriptTask");
						break;
					case "IntegrationLogDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("IntegrationLogCheckCanExecuteOperationsScriptTask");
						break;
					case "IntegrationLogCheckCanExecuteOperationsScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("IntegrationLogInsertingStartMessage");
			ActivatedEventElements.Add("IntegrationLogSavingStartMessage");
			ActivatedEventElements.Add("IntegrationLogDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "IntegrationLogEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "IntegrationLogInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "IntegrationLogInsertingStartMessage";
					result = IntegrationLogInsertingStartMessage.Execute(context);
					break;
				case "IntegrationLogSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "IntegrationLogSavingStartMessage";
					result = IntegrationLogSavingStartMessage.Execute(context);
					break;
				case "IntegrationLogDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "IntegrationLogDeletingStartMessage";
					result = IntegrationLogDeletingStartMessage.Execute(context);
					break;
				case "IntegrationLogCheckCanExecuteOperationsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "IntegrationLogCheckCanExecuteOperationsScriptTask";
					result = IntegrationLogCheckCanExecuteOperationsScriptTask.Execute(context, IntegrationLogCheckCanExecuteOperationsScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool IntegrationLogCheckCanExecuteOperationsScriptTaskExecute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "IntegrationLogInserting":
							if (ActivatedEventElements.Contains("IntegrationLogInsertingStartMessage")) {
							context.QueueTasks.Enqueue("IntegrationLogInsertingStartMessage");
						}
						break;
					case "IntegrationLogSaving":
							if (ActivatedEventElements.Contains("IntegrationLogSavingStartMessage")) {
							context.QueueTasks.Enqueue("IntegrationLogSavingStartMessage");
						}
						break;
					case "IntegrationLogDeleting":
							if (ActivatedEventElements.Contains("IntegrationLogDeletingStartMessage")) {
							context.QueueTasks.Enqueue("IntegrationLogDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: IntegrationLog_BaseEventsProcess

	/// <exclude/>
	public class IntegrationLog_BaseEventsProcess : IntegrationLog_BaseEventsProcess<IntegrationLog>
	{

		public IntegrationLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: IntegrationLog_BaseEventsProcess

	public partial class IntegrationLog_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: IntegrationLogEventsProcess

	/// <exclude/>
	public class IntegrationLogEventsProcess : IntegrationLog_BaseEventsProcess
	{

		public IntegrationLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

