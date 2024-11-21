namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
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

	#region Class: CompletenessRenewSchema

	/// <exclude/>
	public class CompletenessRenewSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CompletenessRenewSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CompletenessRenewSchema(CompletenessRenewSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CompletenessRenew";
			UId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47");
			CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.6.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47");
			Version = 0;
			PackageUId = new Guid("76c2f1ba-2917-4eea-8bd0-e2cfd8cc3dde");
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
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("ff580068-1e01-4acd-917e-727da9061aa8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f"),
				CreatedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f06722a5-71df-4576-a362-44771d39a3d0"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("73fb3ad1-178b-49af-9d0f-8140ded8862d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("6d0017d9-0a44-4b86-82b7-a398ab04b9e2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f"),
				CreatedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("73fb3ad1-178b-49af-9d0f-8140ded8862d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("023d44ed-8f51-44ec-918a-9ecec8ebe47e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("56569114-3b2c-4c0e-b168-a88e7a6df68c"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f"),
				CreatedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("f26994bb-698d-4aeb-b933-5390ba9f53ee"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("56569114-3b2c-4c0e-b168-a88e7a6df68c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f"),
				CreatedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("f06722a5-71df-4576-a362-44771d39a3d0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f26994bb-698d-4aeb-b933-5390ba9f53ee"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f"),
				CreatedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("023d44ed-8f51-44ec-918a-9ecec8ebe47e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f26994bb-698d-4aeb-b933-5390ba9f53ee"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f"),
				CreatedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				Name = @"Terminate1",
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
				UId = new Guid("73fb3ad1-178b-49af-9d0f-8140ded8862d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f26994bb-698d-4aeb-b933-5390ba9f53ee"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f"),
				CreatedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"),
				Name = @"ScriptTask1",
				Position = new Point(295, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,141,77,10,194,48,16,133,247,130,119,8,93,165,32,189,64,85,104,3,117,175,120,128,16,30,82,152,78,100,102,162,120,123,83,232,70,112,245,224,253,124,111,140,138,144,151,39,193,192,80,189,65,94,115,130,211,77,79,46,80,84,157,98,178,44,159,238,2,59,142,255,39,103,207,120,187,144,89,77,202,218,30,228,81,22,176,249,166,84,90,13,24,201,230,204,205,193,221,127,140,182,237,247,187,237,176,187,34,69,74,133,162,97,32,242,107,36,176,34,236,42,22,253,23,254,105,136,61,176,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a1742330-e8f5-42aa-bf8a-24f498447cd5"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("63ed8a35-ff0f-45c7-888c-a1ff5f251e15"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("723df037-0016-403c-a198-8225dd0ceb1a")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CompletenessRenew(userConnection);
		}

		public override object Clone() {
			return new CompletenessRenewSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47"));
		}

		#endregion

	}

	#endregion

	#region Class: CompletenessRenew

	/// <exclude/>
	public class CompletenessRenew : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CompletenessRenew process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public CompletenessRenew(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CompletenessRenew";
			SchemaUId = new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9b626d39-6bcd-4e75-8ffb-7e16f67b8f47");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CompletenessRenew, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CompletenessRenew, Source element: {0}, None of the exclusive gateway conditions are met!";
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
					SchemaElementUId = new Guid("f06722a5-71df-4576-a362-44771d39a3d0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("023d44ed-8f51-44ec-918a-9ecec8ebe47e"),
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
					SchemaElementUId = new Guid("73fb3ad1-178b-49af-9d0f-8140ded8862d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ScriptTask1":
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

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			BaseCompletenessService service = ClassFactory.Get<BaseCompletenessService>(new ConstructorArgument("userConnection", UserConnection));
			service.RecalculateAll();
			return true;
		}

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
			var cloneItem = (CompletenessRenew)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

