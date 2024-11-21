namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
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

	#region Class: ClearExpiredAccountRegistrationRecordsProcessSchema

	/// <exclude/>
	public class ClearExpiredAccountRegistrationRecordsProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ClearExpiredAccountRegistrationRecordsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ClearExpiredAccountRegistrationRecordsProcessSchema(ClearExpiredAccountRegistrationRecordsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ClearExpiredAccountRegistrationRecordsProcess";
			UId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3");
			CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.3.0.3015";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3");
			Version = 0;
			PackageUId = new Guid("a7d9c356-450c-46d7-bc85-72dca4e280ba");
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
			ProcessSchemaScriptTask clearexpiredrecordsscripttask = CreateClearExpiredRecordsScriptTaskScriptTask();
			FlowElements.Add(clearexpiredrecordsscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("d9ce71e8-042b-4ac7-ae0f-dd046f79f044"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bc076a86-2773-4e7a-b8d1-6bad41a79fe4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("53a2efdd-03a6-487b-b8be-fd99d8290a7e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("1bc7b5da-8a0b-41ad-bb85-292aba094f55"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("53a2efdd-03a6-487b-b8be-fd99d8290a7e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2c48f762-51b2-4186-a19d-93988449d9ab"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("6b6d4e4d-fb12-4892-a7f0-9f439ca93c27"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(1201, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("0b69eee9-a311-4df3-ae5b-675e15c8474a"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("6b6d4e4d-fb12-4892-a7f0-9f439ca93c27"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(1172, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("bc076a86-2773-4e7a-b8d1-6bad41a79fe4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0b69eee9-a311-4df3-ae5b-675e15c8474a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
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
				UId = new Guid("2c48f762-51b2-4186-a19d-93988449d9ab"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0b69eee9-a311-4df3-ae5b-675e15c8474a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateClearExpiredRecordsScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("53a2efdd-03a6-487b-b8be-fd99d8290a7e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0b69eee9-a311-4df3-ae5b-675e15c8474a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Name = @"ClearExpiredRecordsScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(281, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,203,106,195,48,16,60,39,144,127,16,58,201,16,244,3,161,135,224,164,212,37,212,161,109,218,179,144,55,181,192,150,210,149,100,231,243,43,201,194,148,210,66,122,18,171,157,157,153,125,12,2,137,54,227,78,56,32,119,36,62,175,170,7,126,114,242,201,140,155,213,114,8,249,6,58,72,105,13,35,217,165,128,157,44,96,105,180,6,233,148,209,197,106,185,224,247,104,122,70,143,128,214,104,209,109,165,52,94,187,103,248,80,214,161,136,40,154,96,239,45,32,48,90,53,180,224,149,102,145,243,37,112,74,247,11,231,130,151,166,243,189,102,244,34,144,174,83,81,250,190,65,139,111,237,84,54,85,28,224,236,106,239,0,31,141,10,124,111,128,234,172,100,194,150,166,129,140,111,7,153,241,181,158,162,53,201,86,237,254,211,139,46,59,33,244,65,216,118,182,115,27,185,29,190,147,199,232,47,242,159,4,179,80,30,94,54,182,191,94,20,130,173,99,183,149,61,128,181,108,154,23,63,10,20,125,216,19,178,188,220,34,11,227,44,252,223,226,34,92,195,116,9,124,127,5,25,186,101,241,11,193,121,212,196,161,135,205,23,114,142,6,71,77,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ClearExpiredAccountRegistrationRecordsProcess(userConnection);
		}

		public override object Clone() {
			return new ClearExpiredAccountRegistrationRecordsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"));
		}

		#endregion

	}

	#endregion

	#region Class: ClearExpiredAccountRegistrationRecordsProcess

	/// <exclude/>
	public class ClearExpiredAccountRegistrationRecordsProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ClearExpiredAccountRegistrationRecordsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ClearExpiredAccountRegistrationRecordsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ClearExpiredAccountRegistrationRecordsProcess";
			SchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3");
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
				return new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ClearExpiredAccountRegistrationRecordsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ClearExpiredAccountRegistrationRecordsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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
					SchemaElementUId = new Guid("bc076a86-2773-4e7a-b8d1-6bad41a79fe4"),
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
					SchemaElementUId = new Guid("2c48f762-51b2-4186-a19d-93988449d9ab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _clearExpiredRecordsScriptTask;
		public ProcessScriptTask ClearExpiredRecordsScriptTask {
			get {
				return _clearExpiredRecordsScriptTask ?? (_clearExpiredRecordsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ClearExpiredRecordsScriptTask",
					SchemaElementUId = new Guid("53a2efdd-03a6-487b-b8be-fd99d8290a7e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ClearExpiredRecordsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ClearExpiredRecordsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ClearExpiredRecordsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearExpiredRecordsScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ClearExpiredRecordsScriptTask":
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

		public virtual bool ClearExpiredRecordsScriptTaskExecute(ProcessExecutingContext context) {
			var nowDate = DateTime.UtcNow;
			var delete = new Delete(UserConnection)
				.From("PersonalAccountRegistration")
				.Where("Id").In(new Select(UserConnection)
					.Column("par","Id")
					.From("PersonalAccountRegistration").As("par")
					.LeftOuterJoin("VerificationCode").As("hvc")
					.On("hvc", "Id").IsEqual("par", "HashId")
					.LeftOuterJoin("VerificationCode").As("svc")
					.On("svc", "Id").IsEqual("par", "VerificationCodeId")
					.Where("hvc", "ExpiresOn").IsLess(Column.Parameter(nowDate))
					.Or("svc", "ExpiresOn").IsLess(Column.Parameter(nowDate))
				);
			delete.Execute();
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
			var cloneItem = (ClearExpiredAccountRegistrationRecordsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

