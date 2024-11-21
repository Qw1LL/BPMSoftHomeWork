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

	#region Class: HandleWebHookProcessSchema

	/// <exclude/>
	public class HandleWebHookProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public HandleWebHookProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public HandleWebHookProcessSchema(HandleWebHookProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "HandleWebHookProcess";
			UId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4");
			CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.8.0.0";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = false;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4");
			Version = 0;
			PackageUId = new Guid("d6330a93-b88b-4e78-8576-55accfd9054f");
			UseSystemSecurityContext = false;
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaScriptTask handlewebhookscript = CreateHandleWebHookScriptScriptTask();
			FlowElements.Add(handlewebhookscript);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("ce61022c-7c2e-4553-a4ee-edc7cfd2187a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2"),
				CreatedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5fedd901-a1e1-4221-a3dd-acbcb9385776"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("47d4da18-9bfa-4e12-8ca3-737117eb72af"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("aec4800a-eeab-42b8-bcc8-587ff993685b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2"),
				CreatedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("47d4da18-9bfa-4e12-8ca3-737117eb72af"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9a0a8832-d44a-4b60-9ec1-1af7b6c85f39"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("dd13797d-05aa-4df0-a25a-ade91cafe89d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2"),
				CreatedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("394c77fc-4d68-4606-85c5-160e5505e93e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("dd13797d-05aa-4df0-a25a-ade91cafe89d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2"),
				CreatedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(700, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("5fedd901-a1e1-4221-a3dd-acbcb9385776"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("394c77fc-4d68-4606-85c5-160e5505e93e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2"),
				CreatedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("9a0a8832-d44a-4b60-9ec1-1af7b6c85f39"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("394c77fc-4d68-4606-85c5-160e5505e93e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2"),
				CreatedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateHandleWebHookScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("47d4da18-9bfa-4e12-8ca3-737117eb72af"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("394c77fc-4d68-4606-85c5-160e5505e93e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2"),
				CreatedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				Name = @"HandleWebHookScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(290, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,243,72,204,75,201,73,13,79,77,242,200,207,207,46,214,208,180,230,42,74,45,41,45,202,83,40,41,42,77,181,6,0,30,172,252,93,30,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
			Methods.Add(CreateHandleWebHooksMethod());
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("07618152-fceb-4884-b902-e61da67c0a26"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("f7f6d04d-a395-435b-b083-a5d8c8d260b9"),
				Name = "BPMSoft.Core",
				Alias = "",
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2")
			});
		}

		protected virtual SchemaMethod CreateHandleWebHooksMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("8d21bfa9-8153-4f6b-a35f-c46fec8059d0"),
				Name = "HandleWebHooks",
				CreatedInSchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"),
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2"),
				ResultValueTypeName = "void"
			};
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,75,44,82,40,45,78,45,114,206,207,203,75,77,46,201,204,207,83,176,85,112,79,45,177,9,69,17,180,211,80,66,21,80,210,180,230,202,75,45,87,8,79,77,242,200,207,207,246,72,204,75,201,73,45,210,64,53,74,83,47,160,40,63,57,181,184,24,170,170,88,67,211,26,0,195,169,215,24,113,0,0,0 };
			return method;
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new HandleWebHookProcess(userConnection);
		}

		public override object Clone() {
			return new HandleWebHookProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4"));
		}

		#endregion

	}

	#endregion

	#region Class: HandleWebHookProcessMethodsWrapper

	/// <exclude/>
	public class HandleWebHookProcessMethodsWrapper : ProcessModel
	{

		public HandleWebHookProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("HandleWebHookScriptExecute", HandleWebHookScriptExecute);
		}

		#region Methods: Private

		private bool HandleWebHookScriptExecute(ProcessExecutingContext context) {
			HandleWebHooks();
			return true;
		}

		private void HandleWebHooks() {
			var userConnection = Get<UserConnection>("UserConnection");
			new WebHookHandler(userConnection).ProcessWebHooks();
		}

		#endregion

	}

	#endregion

	#region Class: HandleWebHookProcess

	/// <exclude/>
	public class HandleWebHookProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, HandleWebHookProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public HandleWebHookProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "HandleWebHookProcess";
			SchemaUId = new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			ProcessModel = new HandleWebHookProcessMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f10b5493-bfe4-4557-8a20-cc11ea2720b4");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: HandleWebHookProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: HandleWebHookProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _start1;
		public ProcessFlowElement Start1 {
			get {
				return _start1 ?? (_start1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "Start1",
					SchemaElementUId = new Guid("5fedd901-a1e1-4221-a3dd-acbcb9385776"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessTerminateEvent _terminate1;
		public ProcessTerminateEvent Terminate1 {
			get {
				return _terminate1 ?? (_terminate1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate1",
					SchemaElementUId = new Guid("9a0a8832-d44a-4b60-9ec1-1af7b6c85f39"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _handleWebHookScript;
		public ProcessScriptTask HandleWebHookScript {
			get {
				return _handleWebHookScript ?? (_handleWebHookScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "HandleWebHookScript",
					SchemaElementUId = new Guid("47d4da18-9bfa-4e12-8ca3-737117eb72af"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ProcessModel.GetScriptTaskMethod("HandleWebHookScriptExecute"),
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[HandleWebHookScript.SchemaElementUId] = new Collection<ProcessFlowElement> { HandleWebHookScript };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("HandleWebHookScript", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "HandleWebHookScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("Start1", string.Empty));
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
			var cloneItem = (HandleWebHookProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

