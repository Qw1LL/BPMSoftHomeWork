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

	#region Class: ScoringModelSchema

	/// <exclude/>
	public class ScoringModelSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ScoringModelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ScoringModelSchema(ScoringModelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ScoringModelSchema(ScoringModelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0");
			RealUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0");
			Name = "ScoringModel";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1");
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
			if (Columns.FindByUId(new Guid("04e671fb-4cf2-478f-a837-2190a6cc61a7")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("b5d2dfb5-8c24-4ae9-9c15-abbe00698f79")) == null) {
				Columns.Add(CreateSourceModelColumn());
			}
			if (Columns.FindByUId(new Guid("ca5b9620-32cf-4d8f-a792-d79accf4ea2b")) == null) {
				Columns.Add(CreateScoringObjectColumn());
			}
			if (Columns.FindByUId(new Guid("4bc379a1-d441-402f-98e7-37dedcec5dd5")) == null) {
				Columns.Add(CreateColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("cf62f13d-11ec-46aa-a547-3994ceb74c13")) == null) {
				Columns.Add(CreateColumnCaptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("329f12fa-b2e8-4aad-9361-eed8935548ac"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				ModifiedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("04e671fb-4cf2-478f-a837-2190a6cc61a7"),
				Name = @"IsActive",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				ModifiedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b5d2dfb5-8c24-4ae9-9c15-abbe00698f79"),
				Name = @"SourceModel",
				ReferenceSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsWeakReference = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				ModifiedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				CreatedInPackageId = new Guid("3d7df93a-399a-4bbe-9b09-fe2c0e15eb28")
			};
		}

		protected virtual EntitySchemaColumn CreateScoringObjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ca5b9620-32cf-4d8f-a792-d79accf4ea2b"),
				Name = @"ScoringObject",
				ReferenceSchemaUId = new Guid("a2d407a1-cda4-4344-ac71-88a4e2bf9c28"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				ModifiedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4bc379a1-d441-402f-98e7-37dedcec5dd5"),
				Name = @"ColumnUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				ModifiedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cf62f13d-11ec-46aa-a547-3994ceb74c13"),
				Name = @"ColumnCaption",
				CreatedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				ModifiedInSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ScoringModel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ScoringModel_BaseScoringEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ScoringModelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ScoringModelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"));
		}

		#endregion

	}

	#endregion

	#region Class: ScoringModel

	/// <summary>
	/// Scoring model.
	/// </summary>
	public class ScoringModel : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ScoringModel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ScoringModel";
		}

		public ScoringModel(ScoringModel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Active.
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
		public Guid SourceModelId {
			get {
				return GetTypedColumnValue<Guid>("SourceModelId");
			}
			set {
				SetColumnValue("SourceModelId", value);
				_sourceModel = null;
			}
		}

		/// <exclude/>
		public string SourceModelName {
			get {
				return GetTypedColumnValue<string>("SourceModelName");
			}
			set {
				SetColumnValue("SourceModelName", value);
				if (_sourceModel != null) {
					_sourceModel.Name = value;
				}
			}
		}

		private ScoringModel _sourceModel;
		/// <summary>
		/// Source model.
		/// </summary>
		public ScoringModel SourceModel {
			get {
				return _sourceModel ??
					(_sourceModel = LookupColumnEntities.GetEntity("SourceModel") as ScoringModel);
			}
		}

		/// <exclude/>
		public Guid ScoringObjectId {
			get {
				return GetTypedColumnValue<Guid>("ScoringObjectId");
			}
			set {
				SetColumnValue("ScoringObjectId", value);
				_scoringObject = null;
			}
		}

		/// <exclude/>
		public string ScoringObjectName {
			get {
				return GetTypedColumnValue<string>("ScoringObjectName");
			}
			set {
				SetColumnValue("ScoringObjectName", value);
				if (_scoringObject != null) {
					_scoringObject.Name = value;
				}
			}
		}

		private VwSysModuleEntity _scoringObject;
		/// <summary>
		/// Scoring object.
		/// </summary>
		public VwSysModuleEntity ScoringObject {
			get {
				return _scoringObject ??
					(_scoringObject = LookupColumnEntities.GetEntity("ScoringObject") as VwSysModuleEntity);
			}
		}

		/// <summary>
		/// Scoring parameter UId.
		/// </summary>
		public Guid ColumnUId {
			get {
				return GetTypedColumnValue<Guid>("ColumnUId");
			}
			set {
				SetColumnValue("ColumnUId", value);
			}
		}

		/// <summary>
		/// Scoring parameter.
		/// </summary>
		public string ColumnCaption {
			get {
				return GetTypedColumnValue<string>("ColumnCaption");
			}
			set {
				SetColumnValue("ColumnCaption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ScoringModel_BaseScoringEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ScoringModelDeleted", e);
			Inserted += (s, e) => ThrowEvent("ScoringModelInserted", e);
			Validating += (s, e) => ThrowEvent("ScoringModelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ScoringModel(this);
		}

		#endregion

	}

	#endregion

	#region Class: ScoringModel_BaseScoringEventsProcess

	/// <exclude/>
	public partial class ScoringModel_BaseScoringEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ScoringModel
	{

		public ScoringModel_BaseScoringEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ScoringModel_BaseScoringEventsProcess";
			SchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _insertedEventSubProcess;
		public ProcessFlowElement InsertedEventSubProcess {
			get {
				return _insertedEventSubProcess ?? (_insertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "InsertedEventSubProcess",
					SchemaElementUId = new Guid("a82fc2d3-b203-4930-a0c0-2018326e07e4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _scoringModelInsertedStartMessage;
		public ProcessFlowElement ScoringModelInsertedStartMessage {
			get {
				return _scoringModelInsertedStartMessage ?? (_scoringModelInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ScoringModelInsertedStartMessage",
					SchemaElementUId = new Guid("106a82ea-2148-44e6-9cae-e5e4d0191489"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _insertedScriptTask;
		public ProcessScriptTask InsertedScriptTask {
			get {
				return _insertedScriptTask ?? (_insertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "InsertedScriptTask",
					SchemaElementUId = new Guid("620d1517-541c-476f-b536-bacb7d1650b6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = InsertedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[InsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { InsertedEventSubProcess };
			FlowElements[ScoringModelInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ScoringModelInsertedStartMessage };
			FlowElements[InsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { InsertedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "InsertedEventSubProcess":
						break;
					case "ScoringModelInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("InsertedScriptTask");
						break;
					case "InsertedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ScoringModelInsertedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "InsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ScoringModelInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScoringModelInsertedStartMessage";
					result = ScoringModelInsertedStartMessage.Execute(context);
					break;
				case "InsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "InsertedScriptTask";
					result = InsertedScriptTask.Execute(context, InsertedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool InsertedScriptTaskExecute(ProcessExecutingContext context) {
			return OnInserted(context);
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ScoringModelInserted":
							if (ActivatedEventElements.Contains("ScoringModelInsertedStartMessage")) {
							context.QueueTasks.Enqueue("ScoringModelInsertedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ScoringModel_BaseScoringEventsProcess

	/// <exclude/>
	public class ScoringModel_BaseScoringEventsProcess : ScoringModel_BaseScoringEventsProcess<ScoringModel>
	{

		public ScoringModel_BaseScoringEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ScoringModel_BaseScoringEventsProcess

	public partial class ScoringModel_BaseScoringEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool OnInserted(ProcessExecutingContext context) {
			CopyRules();
			return true;
		}

		public virtual void CopyRules() {
			if (!Entity.GetIsColumnValueLoaded("SourceModelId")) {
				return;
			}
			Guid sourceModelId = Entity.GetTypedColumnValue<Guid>("SourceModelId");
			if (sourceModelId.IsEmpty()) {
				return;
			}
			Guid recordId = Entity.GetTypedColumnValue<Guid>("Id");
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName("ScoringRule");
			var esq = new EntitySchemaQuery(schema);
			esq.AddAllSchemaColumns();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				false, "ScoringModel", sourceModelId));
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			foreach(Entity scoringRule in entities) {
				var scoringRuleCopy = (BPMSoft.Configuration.ScoringRule)scoringRule.Clone();
				scoringRuleCopy.SetColumnValue("Id", Guid.NewGuid());
				scoringRuleCopy.SetColumnValue("ScoringModelId", recordId);
				scoringRuleCopy.Save();
			}
		}

		#endregion

	}

	#endregion


	#region Class: ScoringModelEventsProcess

	/// <exclude/>
	public class ScoringModelEventsProcess : ScoringModel_BaseScoringEventsProcess
	{

		public ScoringModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

