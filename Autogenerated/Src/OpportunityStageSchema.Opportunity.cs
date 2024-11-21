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
	using BPMSoft.Core.Store;
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

	#region Class: OpportunityStage_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OpportunityStage_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OpportunityStage_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityStage_Opportunity_BPMSoftSchema(OpportunityStage_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityStage_Opportunity_BPMSoftSchema(OpportunityStage_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f");
			RealUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f");
			Name = "OpportunityStage_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("146e7f2e-a20d-4cc2-9c5c-bcc8dde6ed63")) == null) {
				Columns.Add(CreateEndColumn());
			}
			if (Columns.FindByUId(new Guid("9d36f697-56db-4539-9809-b07f01dfe9a0")) == null) {
				Columns.Add(CreateSuccessfulColumn());
			}
			if (Columns.FindByUId(new Guid("5cff1d37-c039-46ce-ac3e-a4d7abe49c5f")) == null) {
				Columns.Add(CreateNumberColumn());
			}
			if (Columns.FindByUId(new Guid("388070cb-b942-4af8-a6fb-4b722d30847e")) == null) {
				Columns.Add(CreateMaxProbabilityColumn());
			}
			if (Columns.FindByUId(new Guid("5112d458-569f-445a-90a9-a4c8e0041b28")) == null) {
				Columns.Add(CreateNextStepTermColumn());
			}
			if (Columns.FindByUId(new Guid("875d786d-74b6-4f1c-b885-5fb7da04453b")) == null) {
				Columns.Add(CreateShowInFunnelColumn());
			}
			if (Columns.FindByUId(new Guid("d463f315-b9c9-41ee-a625-60669d205559")) == null) {
				Columns.Add(CreateColorColumn());
			}
			if (Columns.FindByUId(new Guid("ce321ce4-c2fd-43e9-b4ca-26a3aca754c4")) == null) {
				Columns.Add(CreateShowInProgressBarColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEndColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("146e7f2e-a20d-4cc2-9c5c-bcc8dde6ed63"),
				Name = @"End",
				CreatedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				ModifiedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateSuccessfulColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9d36f697-56db-4539-9809-b07f01dfe9a0"),
				Name = @"Successful",
				CreatedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				ModifiedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5cff1d37-c039-46ce-ac3e-a4d7abe49c5f"),
				Name = @"Number",
				CreatedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				ModifiedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateMaxProbabilityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("388070cb-b942-4af8-a6fb-4b722d30847e"),
				Name = @"MaxProbability",
				CreatedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				ModifiedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateNextStepTermColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5112d458-569f-445a-90a9-a4c8e0041b28"),
				Name = @"NextStepTerm",
				CreatedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				ModifiedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateShowInFunnelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("875d786d-74b6-4f1c-b885-5fb7da04453b"),
				Name = @"ShowInFunnel",
				CreatedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				ModifiedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				CreatedInPackageId = new Guid("331ebe45-2152-452a-9e4b-d72e7bcbf340")
			};
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d463f315-b9c9-41ee-a625-60669d205559"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				ModifiedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				CreatedInPackageId = new Guid("331ebe45-2152-452a-9e4b-d72e7bcbf340")
			};
		}

		protected virtual EntitySchemaColumn CreateShowInProgressBarColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ce321ce4-c2fd-43e9-b4ca-26a3aca754c4"),
				Name = @"ShowInProgressBar",
				CreatedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				ModifiedInSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				CreatedInPackageId = new Guid("331ebe45-2152-452a-9e4b-d72e7bcbf340"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
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
			return new OpportunityStage_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityStage_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityStage_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityStage_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityStage_Opportunity_BPMSoft

	/// <summary>
	/// Стадия продажи.
	/// </summary>
	public class OpportunityStage_Opportunity_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OpportunityStage_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityStage_Opportunity_BPMSoft";
		}

		public OpportunityStage_Opportunity_BPMSoft(OpportunityStage_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Конечная.
		/// </summary>
		public bool End {
			get {
				return GetTypedColumnValue<bool>("End");
			}
			set {
				SetColumnValue("End", value);
			}
		}

		/// <summary>
		/// Успешная.
		/// </summary>
		public bool Successful {
			get {
				return GetTypedColumnValue<bool>("Successful");
			}
			set {
				SetColumnValue("Successful", value);
			}
		}

		/// <summary>
		/// Порядковый номер.
		/// </summary>
		public int Number {
			get {
				return GetTypedColumnValue<int>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <summary>
		/// Максимальная вероятность.
		/// </summary>
		public int MaxProbability {
			get {
				return GetTypedColumnValue<int>("MaxProbability");
			}
			set {
				SetColumnValue("MaxProbability", value);
			}
		}

		/// <summary>
		/// Период планирования следующего шага, дн.
		/// </summary>
		public int NextStepTerm {
			get {
				return GetTypedColumnValue<int>("NextStepTerm");
			}
			set {
				SetColumnValue("NextStepTerm", value);
			}
		}

		/// <summary>
		/// Показывать в воронке.
		/// </summary>
		public bool ShowInFunnel {
			get {
				return GetTypedColumnValue<bool>("ShowInFunnel");
			}
			set {
				SetColumnValue("ShowInFunnel", value);
			}
		}

		/// <summary>
		/// Цвет.
		/// </summary>
		public string Color {
			get {
				return GetTypedColumnValue<string>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		/// <summary>
		/// Показывать на индикаторе стадий.
		/// </summary>
		public bool ShowInProgressBar {
			get {
				return GetTypedColumnValue<bool>("ShowInProgressBar");
			}
			set {
				SetColumnValue("ShowInProgressBar", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityStage_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityStage_Opportunity_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityStage_Opportunity_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityStage_Opportunity_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityStage_Opportunity_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityStage_Opportunity_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityStage_Opportunity_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityStage_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityStage_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityStage_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityStage_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OpportunityStage_Opportunity_BPMSoft
	{

		public OpportunityStage_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityStage_OpportunityEventsProcess";
			SchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _opportunityStageSaving_Process;
		public ProcessFlowElement OpportunityStageSaving_Process {
			get {
				return _opportunityStageSaving_Process ?? (_opportunityStageSaving_Process = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "OpportunityStageSaving_Process",
					SchemaElementUId = new Guid("b3564746-ed13-4b1b-9fbf-6fec4872bcd8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _opportunityStageSaving_message;
		public ProcessFlowElement OpportunityStageSaving_message {
			get {
				return _opportunityStageSaving_message ?? (_opportunityStageSaving_message = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OpportunityStageSaving_message",
					SchemaElementUId = new Guid("f390aafc-20b0-4248-89e6-6816c4af3e1a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _opportunityStageSaving_ScriptTask;
		public ProcessScriptTask OpportunityStageSaving_ScriptTask {
			get {
				return _opportunityStageSaving_ScriptTask ?? (_opportunityStageSaving_ScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OpportunityStageSaving_ScriptTask",
					SchemaElementUId = new Guid("6d3eb545-a705-4111-be95-a19d32192fcc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OpportunityStageSaving_ScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _opportunityStageDeleting_message;
		public ProcessFlowElement OpportunityStageDeleting_message {
			get {
				return _opportunityStageDeleting_message ?? (_opportunityStageDeleting_message = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OpportunityStageDeleting_message",
					SchemaElementUId = new Guid("f4986217-c34a-4a4f-9981-2495237022c9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _opportunityStageInserting_m;
		public ProcessFlowElement OpportunityStageInserting_m {
			get {
				return _opportunityStageInserting_m ?? (_opportunityStageInserting_m = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OpportunityStageInserting_m",
					SchemaElementUId = new Guid("e295c678-c68c-40f7-97ba-225311d1b063"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[OpportunityStageSaving_Process.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageSaving_Process };
			FlowElements[OpportunityStageSaving_message.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageSaving_message };
			FlowElements[OpportunityStageSaving_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageSaving_ScriptTask };
			FlowElements[OpportunityStageDeleting_message.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageDeleting_message };
			FlowElements[OpportunityStageInserting_m.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageInserting_m };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "OpportunityStageSaving_Process":
						break;
					case "OpportunityStageSaving_message":
						e.Context.QueueTasks.Enqueue("OpportunityStageSaving_ScriptTask");
						break;
					case "OpportunityStageSaving_ScriptTask":
						break;
					case "OpportunityStageDeleting_message":
						e.Context.QueueTasks.Enqueue("OpportunityStageSaving_ScriptTask");
						break;
					case "OpportunityStageInserting_m":
						e.Context.QueueTasks.Enqueue("OpportunityStageSaving_ScriptTask");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("OpportunityStageSaving_message");
			ActivatedEventElements.Add("OpportunityStageDeleting_message");
			ActivatedEventElements.Add("OpportunityStageInserting_m");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "OpportunityStageSaving_Process":
					context.QueueTasks.Dequeue();
					break;
				case "OpportunityStageSaving_message":
					context.QueueTasks.Dequeue();
					context.SenderName = "OpportunityStageSaving_message";
					result = OpportunityStageSaving_message.Execute(context);
					break;
				case "OpportunityStageSaving_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "OpportunityStageSaving_ScriptTask";
					result = OpportunityStageSaving_ScriptTask.Execute(context, OpportunityStageSaving_ScriptTaskExecute);
					break;
				case "OpportunityStageDeleting_message":
					context.QueueTasks.Dequeue();
					context.SenderName = "OpportunityStageDeleting_message";
					result = OpportunityStageDeleting_message.Execute(context);
					break;
				case "OpportunityStageInserting_m":
					context.QueueTasks.Dequeue();
					context.SenderName = "OpportunityStageInserting_m";
					result = OpportunityStageInserting_m.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool OpportunityStageSaving_ScriptTaskExecute(ProcessExecutingContext context) {
			ClearCache();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "OpportunityStage_Opportunity_BPMSoftSaving":
							if (ActivatedEventElements.Contains("OpportunityStageSaving_message")) {
							context.QueueTasks.Enqueue("OpportunityStageSaving_message");
						}
						break;
					case "OpportunityStage_Opportunity_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("OpportunityStageDeleting_message")) {
							context.QueueTasks.Enqueue("OpportunityStageDeleting_message");
						}
						break;
					case "OpportunityStage_Opportunity_BPMSoftInserting":
							if (ActivatedEventElements.Contains("OpportunityStageInserting_m")) {
							context.QueueTasks.Enqueue("OpportunityStageInserting_m");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityStage_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityStage_OpportunityEventsProcess : OpportunityStage_OpportunityEventsProcess<OpportunityStage_Opportunity_BPMSoft>
	{

		public OpportunityStage_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

