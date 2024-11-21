namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: ProcessNotificationsUpdateScenarioSchema

	/// <exclude/>
	public class ProcessNotificationsUpdateScenarioSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ProcessNotificationsUpdateScenarioSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ProcessNotificationsUpdateScenarioSchema(ProcessNotificationsUpdateScenarioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ProcessNotificationsUpdateScenario";
			UId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4");
			CreatedInPackageId = new Guid("a1a6f4c5-4ce0-49cf-afb2-f720b4b96f90");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = null;
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = false;
			SerializeToMemory = true;
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4");
			Version = 0;
			PackageUId = new Guid("6f46362b-0d60-47d7-b211-fc5e4117aecb");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateWriteMessageActionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7e393355-c515-4954-93b2-37d45f7018de"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				Name = @"WriteMessageAction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateWriteMessageActionParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("dbf4b744-f059-4843-95b4-8d10569f81de"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6f46362b-0d60-47d7-b211-fc5e4117aecb"),
				CreatedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d8c9cb92-bca8-4a84-9527-ff5262348713"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("bcb11dcc-3a23-4d90-83d1-c94267afe4f0"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("6473d974-760b-4d40-9b23-eca8483f17d9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6f46362b-0d60-47d7-b211-fc5e4117aecb"),
				CreatedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bcb11dcc-3a23-4d90-83d1-c94267afe4f0"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("653bbab7-57f9-4017-90f4-ab04cc9fda98"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("31196a5c-3bcf-43ae-b8ae-70b9edb394a2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6f46362b-0d60-47d7-b211-fc5e4117aecb"),
				CreatedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("919164fa-db73-485f-b5dc-2ff50d13f590"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("31196a5c-3bcf-43ae-b8ae-70b9edb394a2"),
				CreatedInOwnerSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				CreatedInPackageId = new Guid("6f46362b-0d60-47d7-b211-fc5e4117aecb"),
				CreatedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("d8c9cb92-bca8-4a84-9527-ff5262348713"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("919164fa-db73-485f-b5dc-2ff50d13f590"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6f46362b-0d60-47d7-b211-fc5e4117aecb"),
				CreatedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				Name = @"StartEvent1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("653bbab7-57f9-4017-90f4-ab04cc9fda98"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("919164fa-db73-485f-b5dc-2ff50d13f590"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6f46362b-0d60-47d7-b211-fc5e4117aecb"),
				CreatedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				Name = @"TerminateEvent1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("bcb11dcc-3a23-4d90-83d1-c94267afe4f0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("919164fa-db73-485f-b5dc-2ff50d13f590"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6f46362b-0d60-47d7-b211-fc5e4117aecb"),
				CreatedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"),
				Name = @"ScriptTask1",
				Position = new Point(295, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,85,142,193,10,194,48,16,68,239,126,197,210,83,133,226,15,180,22,68,212,139,138,136,197,115,172,107,27,137,27,217,108,44,254,189,41,13,66,110,59,179,51,143,105,28,242,218,18,97,43,218,18,248,84,46,97,135,82,53,137,89,231,89,106,100,243,114,246,81,12,3,107,193,189,237,98,203,222,158,225,31,210,215,209,63,160,115,170,195,85,108,128,114,48,221,149,19,214,212,21,16,19,151,239,27,235,9,216,43,186,27,228,192,35,28,96,171,141,57,177,109,67,108,99,240,133,36,71,43,250,161,91,53,98,92,158,78,47,254,115,194,186,8,90,156,61,229,65,50,138,103,2,97,143,229,15,183,241,83,178,0,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("fb519971-db73-4e56-9846-6e6f2dc83899"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("a1a6f4c5-4ce0-49cf-afb2-f720b4b96f90")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ProcessNotificationsUpdateScenario(userConnection);
		}

		public override object Clone() {
			return new ProcessNotificationsUpdateScenarioSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4"));
		}

		#endregion

	}

	#endregion

	#region Class: ProcessNotificationsUpdateScenarioMethodsWrapper

	/// <exclude/>
	public class ProcessNotificationsUpdateScenarioMethodsWrapper : ProcessModel
	{

		public ProcessNotificationsUpdateScenarioMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			UserConnection userConnection = Get<UserConnection>("UserConnection");
			var writeLog = Get<object>("WriteMessageAction") as Action<string, MessageType>;
			var handler = new FillProcessElementNotifications(userConnection, writeLog);
			handler.Run();
			return true;
		}

		#endregion

	}

	#endregion

	#region Class: ProcessNotificationsUpdateScenario

	/// <exclude/>
	public class ProcessNotificationsUpdateScenario : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ProcessNotificationsUpdateScenario process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ProcessNotificationsUpdateScenario(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProcessNotificationsUpdateScenario";
			SchemaUId = new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new ProcessNotificationsUpdateScenarioMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f9f4a192-0ac8-4e49-a938-d5ec1cee37c4");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ProcessNotificationsUpdateScenario, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ProcessNotificationsUpdateScenario, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		private Func<string> _notificationCaption;
		public virtual string NotificationCaption {
			get {
				return (_notificationCaption ?? (_notificationCaption = () => null)).Invoke();
			}
			set {
				_notificationCaption = () => { return value; };
			}
		}

		public virtual Object WriteMessageAction {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _startEvent1;
		public ProcessFlowElement StartEvent1 {
			get {
				return _startEvent1 ?? (_startEvent1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartEvent1",
					SchemaElementUId = new Guid("d8c9cb92-bca8-4a84-9527-ff5262348713"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessTerminateEvent _terminateEvent1;
		public ProcessTerminateEvent TerminateEvent1 {
			get {
				return _terminateEvent1 ?? (_terminateEvent1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateEvent1",
					SchemaElementUId = new Guid("653bbab7-57f9-4017-90f4-ab04cc9fda98"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("bcb11dcc-3a23-4d90-83d1-c94267afe4f0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ScriptTask1Execute"),
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			if (IsProcessExecutedBySignal) {
				return;
			}
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartEvent1", string.Empty));
		}

		protected override void CompleteApplyingFlowElementsPropertiesData() {
			base.CompleteApplyingFlowElementsPropertiesData();
			foreach (var item in FlowElements) {
				foreach (var itemValue in item.Value) {
					if (Guid.Equals(itemValue.CreatedInSchemaUId, InternalSchemaUId)) {
						itemValue.ExecutedEventHandler = OnExecuted;
					}
				}
			}
		}

		protected override void InitializeMetaPathParameterValues() {
			base.InitializeMetaPathParameterValues();
			MetaPathParameterValues.Add("7e393355-c515-4954-93b2-37d45f7018de", () => WriteMessageAction);
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
		}

		public override void WritePropertiesData(DataWriter writer, bool writeFlowElements = true) {
			if (Status == Core.Process.ProcessStatus.Inactive) {
				return;
			}
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer, writeFlowElements);
			WritePropertyValues(writer, false);
			writer.WriteFinishObject();
		}

		public override object CloneShallow() {
			var cloneItem = (ProcessNotificationsUpdateScenario)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.WriteMessageAction = WriteMessageAction;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

