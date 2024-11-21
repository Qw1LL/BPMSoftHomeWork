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

	#region Class: DiagramElementSchema

	/// <exclude/>
	[IsVirtual]
	public class DiagramElementSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DiagramElementSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DiagramElementSchema(DiagramElementSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DiagramElementSchema(DiagramElementSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e1b5b3fc-bd8e-4cba-b470-5c2e909dab3e");
			RealUId = new Guid("e1b5b3fc-bd8e-4cba-b470-5c2e909dab3e");
			Name = "DiagramElement";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e7fd766a-3b94-49b8-831c-ca4d3b5a4c66")) == null) {
				Columns.Add(CreateJSONColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateJSONColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e7fd766a-3b94-49b8-831c-ca4d3b5a4c66"),
				Name = @"JSON",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("e1b5b3fc-bd8e-4cba-b470-5c2e909dab3e"),
				ModifiedInSchemaUId = new Guid("e1b5b3fc-bd8e-4cba-b470-5c2e909dab3e"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DiagramElement(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DiagramElement_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DiagramElementSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DiagramElementSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e1b5b3fc-bd8e-4cba-b470-5c2e909dab3e"));
		}

		#endregion

	}

	#endregion

	#region Class: DiagramElement

	/// <summary>
	/// Diagram element object.
	/// </summary>
	public class DiagramElement : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DiagramElement(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DiagramElement";
		}

		public DiagramElement(DiagramElement source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// JSON.
		/// </summary>
		public string JSON {
			get {
				return GetTypedColumnValue<string>("JSON");
			}
			set {
				SetColumnValue("JSON", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DiagramElement_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DiagramElementDeleted", e);
			Loaded += (s, e) => ThrowEvent("DiagramElementLoaded", e);
			Saving += (s, e) => ThrowEvent("DiagramElementSaving", e);
			Validating += (s, e) => ThrowEvent("DiagramElementValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DiagramElement(this);
		}

		#endregion

	}

	#endregion

	#region Class: DiagramElement_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class DiagramElement_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DiagramElement
	{

		public DiagramElement_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DiagramElement_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("e1b5b3fc-bd8e-4cba-b470-5c2e909dab3e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			_supportedProperties = () => {{ return "offsetX,offsetY"; }};
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e1b5b3fc-bd8e-4cba-b470-5c2e909dab3e");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private Func<string> _supportedProperties;
		public virtual string SupportedProperties {
			get {
				return (_supportedProperties ?? (_supportedProperties = () => null)).Invoke();
			}
			set {
				_supportedProperties = () => { return value; };
			}
		}

		private ProcessFlowElement _syncfusionDiagramObjLoadedEventSubProcess;
		public ProcessFlowElement SyncfusionDiagramObjLoadedEventSubProcess {
			get {
				return _syncfusionDiagramObjLoadedEventSubProcess ?? (_syncfusionDiagramObjLoadedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SyncfusionDiagramObjLoadedEventSubProcess",
					SchemaElementUId = new Guid("88b9dd14-9251-43db-b553-b42bd88f543f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _diagramElementLoadedStartMessage;
		public ProcessFlowElement DiagramElementLoadedStartMessage {
			get {
				return _diagramElementLoadedStartMessage ?? (_diagramElementLoadedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "DiagramElementLoadedStartMessage",
					SchemaElementUId = new Guid("8489d170-579d-4843-aeed-e253e822b3da"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _syncfusionDiagramObjLoadedScriptTask;
		public ProcessScriptTask SyncfusionDiagramObjLoadedScriptTask {
			get {
				return _syncfusionDiagramObjLoadedScriptTask ?? (_syncfusionDiagramObjLoadedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SyncfusionDiagramObjLoadedScriptTask",
					SchemaElementUId = new Guid("9b2fcb73-b86f-48cb-bcc4-ea35acb8b214"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SyncfusionDiagramObjLoadedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SyncfusionDiagramObjLoadedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SyncfusionDiagramObjLoadedEventSubProcess };
			FlowElements[DiagramElementLoadedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { DiagramElementLoadedStartMessage };
			FlowElements[SyncfusionDiagramObjLoadedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SyncfusionDiagramObjLoadedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SyncfusionDiagramObjLoadedEventSubProcess":
						break;
					case "DiagramElementLoadedStartMessage":
						e.Context.QueueTasks.Enqueue("SyncfusionDiagramObjLoadedScriptTask");
						break;
					case "SyncfusionDiagramObjLoadedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("DiagramElementLoadedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SyncfusionDiagramObjLoadedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "DiagramElementLoadedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "DiagramElementLoadedStartMessage";
					result = DiagramElementLoadedStartMessage.Execute(context);
					break;
				case "SyncfusionDiagramObjLoadedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SyncfusionDiagramObjLoadedScriptTask";
					result = SyncfusionDiagramObjLoadedScriptTask.Execute(context, SyncfusionDiagramObjLoadedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SyncfusionDiagramObjLoadedScriptTaskExecute(ProcessExecutingContext context) {
			return LoadedMethod(context);
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "DiagramElementLoaded":
							if (ActivatedEventElements.Contains("DiagramElementLoadedStartMessage")) {
							context.QueueTasks.Enqueue("DiagramElementLoadedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: DiagramElement_ProcessLibraryEventsProcess

	/// <exclude/>
	public class DiagramElement_ProcessLibraryEventsProcess : DiagramElement_ProcessLibraryEventsProcess<DiagramElement>
	{

		public DiagramElement_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DiagramElement_ProcessLibraryEventsProcess

	public partial class DiagramElement_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool LoadedMethod(ProcessExecutingContext context) {
			if (!Entity.Schema.Columns.Any(column => column.Name == "JSON")) {
				return true;
			}
			string json = Entity.GetTypedColumnValue<string>("JSON");
			if (!string.IsNullOrEmpty(json)) {
				string[] properties = GetSupportedProperties();
				string extractedProperties = ExtractProperties(json, properties);
				Entity.SetColumnValue("JSON", extractedProperties);
			}
			return true;
		}

		public virtual string ExtractProperties(string json, params string[] properties) {
			JObject sourceObject = JObject.Parse(json);
			JObject newObject = new JObject();
			foreach (string propertyName in properties) {
				JToken value = sourceObject[propertyName];
				if (value == null) {
					continue;
				}
				newObject.Add(propertyName, value);
			}
			return newObject.ToString();
		}

		public virtual string[] GetSupportedProperties() {
			if (string.IsNullOrEmpty(SupportedProperties)) {
				return new string[] { };
			}
			return SupportedProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		}

		#endregion

	}

	#endregion


	#region Class: DiagramElementEventsProcess

	/// <exclude/>
	public class DiagramElementEventsProcess : DiagramElement_ProcessLibraryEventsProcess
	{

		public DiagramElementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

