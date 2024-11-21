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

	#region Class: DiagramSchema

	/// <exclude/>
	[IsVirtual]
	public class DiagramSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DiagramSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DiagramSchema(DiagramSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DiagramSchema(DiagramSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("92dc123e-a3cc-4430-8c79-127fee51cee8");
			RealUId = new Guid("92dc123e-a3cc-4430-8c79-127fee51cee8");
			Name = "Diagram";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("67ca742a-491c-42e4-bed9-36e7f4e73ff4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Diagram(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Diagram_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DiagramSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DiagramSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("92dc123e-a3cc-4430-8c79-127fee51cee8"));
		}

		#endregion

	}

	#endregion

	#region Class: Diagram

	/// <summary>
	/// Diagram.
	/// </summary>
	public class Diagram : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Diagram(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Diagram";
		}

		public Diagram(Diagram source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Diagram_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DiagramDeleted", e);
			Loaded += (s, e) => ThrowEvent("DiagramLoaded", e);
			Saved += (s, e) => ThrowEvent("DiagramSaved", e);
			Validating += (s, e) => ThrowEvent("DiagramValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Diagram(this);
		}

		#endregion

	}

	#endregion

	#region Class: Diagram_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class Diagram_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Diagram
	{

		public Diagram_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Diagram_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("92dc123e-a3cc-4430-8c79-127fee51cee8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("92dc123e-a3cc-4430-8c79-127fee51cee8");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual string NodesSchemaName {
			get;
			set;
		}

		public virtual string ConnectorsSchemaName {
			get;
			set;
		}

		public virtual string DiagramStorageColumnName {
			get;
			set;
		}

		private ProcessFlowElement _diagramSavedEventSubProcess;
		public ProcessFlowElement DiagramSavedEventSubProcess {
			get {
				return _diagramSavedEventSubProcess ?? (_diagramSavedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "DiagramSavedEventSubProcess",
					SchemaElementUId = new Guid("45900010-bdc2-43ee-bf13-3217377ca174"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _diagramSavedStartMessage;
		public ProcessFlowElement DiagramSavedStartMessage {
			get {
				return _diagramSavedStartMessage ?? (_diagramSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "DiagramSavedStartMessage",
					SchemaElementUId = new Guid("ebfc9eac-b746-4462-9481-3c0b19be0fd8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _diagramSavedScriptTask;
		public ProcessScriptTask DiagramSavedScriptTask {
			get {
				return _diagramSavedScriptTask ?? (_diagramSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DiagramSavedScriptTask",
					SchemaElementUId = new Guid("78587b56-e7a3-400b-8fb5-067a82ccfc4b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = DiagramSavedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _diagramLoadedEventSubProcess;
		public ProcessFlowElement DiagramLoadedEventSubProcess {
			get {
				return _diagramLoadedEventSubProcess ?? (_diagramLoadedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "DiagramLoadedEventSubProcess",
					SchemaElementUId = new Guid("8799ad18-7516-4d10-8516-cd0df9953e92"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _diagramLoadedStartMessage;
		public ProcessFlowElement DiagramLoadedStartMessage {
			get {
				return _diagramLoadedStartMessage ?? (_diagramLoadedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "DiagramLoadedStartMessage",
					SchemaElementUId = new Guid("e22c4a9c-1785-4000-8790-2fb00faef7e1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _diagramLoadedScriptTask;
		public ProcessScriptTask DiagramLoadedScriptTask {
			get {
				return _diagramLoadedScriptTask ?? (_diagramLoadedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DiagramLoadedScriptTask",
					SchemaElementUId = new Guid("0e546333-d6f8-43b8-8184-543abf5a192c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = DiagramLoadedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[DiagramSavedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { DiagramSavedEventSubProcess };
			FlowElements[DiagramSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { DiagramSavedStartMessage };
			FlowElements[DiagramSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { DiagramSavedScriptTask };
			FlowElements[DiagramLoadedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { DiagramLoadedEventSubProcess };
			FlowElements[DiagramLoadedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { DiagramLoadedStartMessage };
			FlowElements[DiagramLoadedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { DiagramLoadedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "DiagramSavedEventSubProcess":
						break;
					case "DiagramSavedStartMessage":
						e.Context.QueueTasks.Enqueue("DiagramSavedScriptTask");
						break;
					case "DiagramSavedScriptTask":
						break;
					case "DiagramLoadedEventSubProcess":
						break;
					case "DiagramLoadedStartMessage":
						e.Context.QueueTasks.Enqueue("DiagramLoadedScriptTask");
						break;
					case "DiagramLoadedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("DiagramSavedStartMessage");
			ActivatedEventElements.Add("DiagramLoadedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "DiagramSavedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "DiagramSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "DiagramSavedStartMessage";
					result = DiagramSavedStartMessage.Execute(context);
					break;
				case "DiagramSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "DiagramSavedScriptTask";
					result = DiagramSavedScriptTask.Execute(context, DiagramSavedScriptTaskExecute);
					break;
				case "DiagramLoadedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "DiagramLoadedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "DiagramLoadedStartMessage";
					result = DiagramLoadedStartMessage.Execute(context);
					break;
				case "DiagramLoadedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "DiagramLoadedScriptTask";
					result = DiagramLoadedScriptTask.Execute(context, DiagramLoadedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool DiagramSavedScriptTaskExecute(ProcessExecutingContext context) {
			return DiagramSavedMethod(context);
		}

		public virtual bool DiagramLoadedScriptTaskExecute(ProcessExecutingContext context) {
			return DiagramLoadedMethod(context);
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "DiagramSaved":
							if (ActivatedEventElements.Contains("DiagramSavedStartMessage")) {
							context.QueueTasks.Enqueue("DiagramSavedStartMessage");
						}
						break;
					case "DiagramLoaded":
							if (ActivatedEventElements.Contains("DiagramLoadedStartMessage")) {
							context.QueueTasks.Enqueue("DiagramLoadedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Diagram_ProcessLibraryEventsProcess

	/// <exclude/>
	public class Diagram_ProcessLibraryEventsProcess : Diagram_ProcessLibraryEventsProcess<Diagram>
	{

		public Diagram_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Diagram_ProcessLibraryEventsProcess

	public partial class Diagram_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool DiagramSavedMethod(ProcessExecutingContext  context) {
			SaveDiagram();
			return true;
		}

		public virtual void SaveDiagram() {
			if (!Entity.Schema.Columns.Any(column => column.Name == DiagramStorageColumnName)) {
				return;
			}
			string json = Entity.GetTypedColumnValue<string>(DiagramStorageColumnName);
			Guid recordId = Entity.PrimaryColumnValue;
			JObject diagram = JObject.Parse(json);
			JToken nodes = diagram["nodes"];
			JToken connectors = diagram["connectors"];
			SaveNodes(recordId, nodes);
			SaveConnectors(recordId, connectors);
		}

		public virtual void SaveNodes(Guid parentId, JToken nodes) {
			DiagramElementMap nodesMap = GetNodesMap();
			List<Guid> records = SaveItems(parentId, nodes, nodesMap);
			if (records.Count > 0) {
				new Delete(UserConnection)
					.From(nodesMap.SchemaName)
					.Where("Id").Not().In(Column.Parameters(records))
					.And(nodesMap.ReferenceColumnValueName + "Id").IsEqual(Column.Parameter(parentId))
					.Execute();
			} else {
				new Delete(UserConnection)
					.From(nodesMap.SchemaName)
					.Where(nodesMap.ReferenceColumnValueName + "Id").IsEqual(Column.Parameter(parentId))
					.Execute();
			}
		}

		public virtual void SaveConnectors(Guid parentId, JToken connectors) {
			DiagramElementMap connectorsMap = GetConnectorsMap();
			DiagramElementMap nodesMap = GetNodesMap();
			List<Guid> records = SaveItems(parentId, connectors, connectorsMap);
			if (records.Count > 0) {
				new Delete(UserConnection)
					.From(connectorsMap.SchemaName)
					.Where("Id").Not().In(Column.Parameters(records))
					.And("Id").In(
						new Select(UserConnection).Column("Id").From(connectorsMap.SchemaName)
						.Where("SourceStepId").In(
							new Select(UserConnection).Column("Id").From(nodesMap.SchemaName)
							.Where(nodesMap.ReferenceColumnValueName + "Id").IsEqual(Column.Parameter(parentId))
						).UnionAll(
							new Select(UserConnection).Column("Id").From(connectorsMap.SchemaName)
							.Where("TargetStepId").In(
								new Select(UserConnection).Column("Id").From(nodesMap.SchemaName)
								.Where(nodesMap.ReferenceColumnValueName + "Id").IsEqual(Column.Parameter(parentId))
							)
						)
					).Execute();
			} else {
				new Delete(UserConnection)
					.From(connectorsMap.SchemaName)
					.Where("Id").In(
						new Select(UserConnection).Column("Id").From(connectorsMap.SchemaName)
						.Where("SourceStepId").In(
							new Select(UserConnection).Column("Id").From(nodesMap.SchemaName)
							.Where(nodesMap.ReferenceColumnValueName + "Id").IsEqual(Column.Parameter(parentId))
						).UnionAll(
							new Select(UserConnection).Column("Id").From(connectorsMap.SchemaName)
							.Where("TargetStepId").In(
								new Select(UserConnection).Column("Id").From(nodesMap.SchemaName)
								.Where(nodesMap.ReferenceColumnValueName + "Id").IsEqual(Column.Parameter(parentId))
							)
						)
					).Execute();
			}
		}

		public virtual DiagramElementMap GetConnectorsMap() {
			return new DiagramElementMap(ConnectorsSchemaName, new DiagramElementMapPointer[] {});
		}

		public virtual DiagramElementMap GetNodesMap() {
			return new DiagramElementMap(NodesSchemaName, new DiagramElementMapPointer[] {});
		}

		public virtual List<Guid> SaveItems(Guid parentId, JToken nodes, DiagramElementMap map) {
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName(map.SchemaName);
			List<Guid> records = new List<Guid>();
			foreach (JToken node in nodes) {
				string nodeName = node.Value<string>("name");
				Guid nodeId = Guid.Empty;
				if (!Guid.TryParse(nodeName, out nodeId)) {
					continue;
				}
				records.Add(nodeId);
				Entity entity = schema.CreateEntity(UserConnection);
				if (!entity.FetchFromDB(nodeId)) {
					entity.SetColumnValue("Id", nodeId);
					if (!string.IsNullOrEmpty(map.ReferenceColumnValueName)) {
						entity.SetColumnValue(map.ReferenceColumnValueName + "Id", parentId);
					}
					entity.SetDefColumnValues();
				}
				map.Apply(entity, node);
				entity.SetColumnValue("JSON", node.ToString());
				entity.Save();
			}
			return records;
		}

		public virtual EntityCollection LoadNodes(Guid recordId, DiagramElementMap map) {
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName(map.SchemaName);
			var esq = new EntitySchemaQuery(schema);
			esq.AddAllSchemaColumns();
			IEntitySchemaQueryFilterItem filter = 
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, map.ReferenceColumnValueName, recordId);
			esq.Filters.Add(filter);
			return esq.GetEntityCollection(UserConnection);
		}

		public virtual EntityCollection LoadConnectors(Guid recordId, DiagramElementMap nodesMap, DiagramElementMap connectorsMap) {
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName(connectorsMap.SchemaName);
			var esq = new EntitySchemaQuery(schema);
			esq.AddAllSchemaColumns();
			var filters = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"[" + nodesMap.SchemaName + ":Id:SourceStep]." + nodesMap.ReferenceColumnValueName, recordId));
			filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"[" + nodesMap.SchemaName + ":Id:TargetStep]." + nodesMap.ReferenceColumnValueName, recordId));
			esq.Filters.Add(filters);
			return esq.GetEntityCollection(UserConnection);
		}

		public virtual JArray BuildConfig(EntityCollection entityCollection, DiagramElementMap map) {
			JArray jArray = new JArray();
			foreach (Entity entity in entityCollection) {
				string json = entity.GetTypedColumnValue<string>("JSON");
				JObject jObject = new JObject();
				if (!string.IsNullOrEmpty(json)) {
					jObject = JObject.Parse(json);
				}
				map.Apply(jObject, entity);
				jArray.Add(jObject);
			}
			return jArray;
		}

		public virtual void LoadDiagram() {
			if (!Entity.Schema.Columns.Any(column => column.Name == DiagramStorageColumnName)) {
				return;
			}
			Guid recordId = Entity.PrimaryColumnValue;
			DiagramElementMap nodesMap = GetNodesMap();
			DiagramElementMap connectorsMap = GetConnectorsMap();
			EntityCollection nodes = LoadNodes(recordId, nodesMap);
			EntityCollection connectors = LoadConnectors(recordId, nodesMap, connectorsMap);
			JToken nodesConfig = BuildConfig(nodes, nodesMap);
			JToken connectorsConfig = BuildConfig(connectors, connectorsMap);
			JObject config = new JObject();
			config.Add("nodes", nodesConfig);
			config.Add("connectors", connectorsConfig);
			string json = config.ToString();
			Entity.SetColumnValue(DiagramStorageColumnName, json);
			Entity.StoringState = StoringObjectState.NotChanged;
		}

		public virtual bool DiagramLoadedMethod(ProcessExecutingContext  context) {
			LoadDiagram();
			return true;
		}

		#endregion

	}

	#endregion


	#region Class: DiagramEventsProcess

	/// <exclude/>
	public class DiagramEventsProcess : Diagram_ProcessLibraryEventsProcess
	{

		public DiagramEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

