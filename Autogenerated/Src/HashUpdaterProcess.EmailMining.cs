namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration.EmailMining;
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

	#region Class: HashUpdaterProcessSchema

	/// <exclude/>
	public class HashUpdaterProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public HashUpdaterProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public HashUpdaterProcessSchema(HashUpdaterProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "HashUpdaterProcess";
			UId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded");
			CreatedInPackageId = new Guid("5e504a85-b356-4f9f-8a4b-82ad398dd0cf");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = null;
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
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded");
			Version = 0;
			PackageUId = new Guid("468413c6-da9a-4bae-a3e9-31456fea166d");
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
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaScriptTask executehashupdaterscripttask = CreateExecuteHashUpdaterScriptTaskScriptTask();
			FlowElements.Add(executehashupdaterscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("227a8684-e83a-4604-89ac-adf4cb62a718"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("790137de-e2d1-45b1-b760-a231c3a3bd4b"),
				CreatedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ee03fe49-d749-4287-abfb-199f4ce9bbea"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("59040377-c371-4dda-b344-e1fcccedecdb"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("ccd12603-1191-4d6a-b947-82deb31d1014"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("790137de-e2d1-45b1-b760-a231c3a3bd4b"),
				CreatedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("59040377-c371-4dda-b344-e1fcccedecdb"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b19af421-ffef-4f36-a378-48508a12ae14"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("1add224e-f4f5-498d-8620-e7a1f2d99648"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("790137de-e2d1-45b1-b760-a231c3a3bd4b"),
				CreatedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("6015fd06-9899-49d0-a6ba-72968b375ac6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("1add224e-f4f5-498d-8620-e7a1f2d99648"),
				CreatedInOwnerSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				CreatedInPackageId = new Guid("790137de-e2d1-45b1-b760-a231c3a3bd4b"),
				CreatedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("ee03fe49-d749-4287-abfb-199f4ce9bbea"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6015fd06-9899-49d0-a6ba-72968b375ac6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("790137de-e2d1-45b1-b760-a231c3a3bd4b"),
				CreatedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
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
				UId = new Guid("b19af421-ffef-4f36-a378-48508a12ae14"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6015fd06-9899-49d0-a6ba-72968b375ac6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("790137de-e2d1-45b1-b760-a231c3a3bd4b"),
				CreatedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				Name = @"TerminateEvent1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateExecuteHashUpdaterScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("59040377-c371-4dda-b344-e1fcccedecdb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6015fd06-9899-49d0-a6ba-72968b375ac6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("790137de-e2d1-45b1-b760-a231c3a3bd4b"),
				CreatedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"),
				Name = @"ExecuteHashUpdaterScriptTask",
				Position = new Point(245, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,45,78,45,114,206,207,203,75,77,46,201,204,207,83,40,69,229,218,42,184,167,150,216,132,162,8,218,105,40,161,10,40,105,90,115,149,37,22,41,100,36,22,103,132,22,164,36,150,164,22,1,53,230,165,150,43,120,32,68,52,80,77,6,106,65,82,174,231,90,145,154,92,90,146,170,1,20,46,74,45,41,45,202,83,40,41,42,77,181,6,0,47,31,80,182,157,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("12d10976-6963-456a-9023-ebfb1497a824"),
				Name = "BPMSoft.Configuration.EmailMining",
				Alias = "",
				CreatedInPackageId = new Guid("5e504a85-b356-4f9f-8a4b-82ad398dd0cf")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new HashUpdaterProcess(userConnection);
		}

		public override object Clone() {
			return new HashUpdaterProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded"));
		}

		#endregion

	}

	#endregion

	#region Class: HashUpdaterProcessMethodsWrapper

	/// <exclude/>
	public class HashUpdaterProcessMethodsWrapper : ProcessModel
	{

		public HashUpdaterProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ExecuteHashUpdaterScriptTaskExecute", ExecuteHashUpdaterScriptTaskExecute);
		}

		#region Methods: Private

		private bool ExecuteHashUpdaterScriptTaskExecute(ProcessExecutingContext context) {
			UserConnection userConnection = Get<UserConnection>("UserConnection");
			var hashUpdater = new HashUpdater(userConnection);
			hashUpdater.Execute();
			return true;
		}

		#endregion

	}

	#endregion

	#region Class: HashUpdaterProcess

	/// <exclude/>
	public class HashUpdaterProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, HashUpdaterProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public HashUpdaterProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "HashUpdaterProcess";
			SchemaUId = new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			ProcessModel = new HashUpdaterProcessMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ff8ce11f-fb93-4e76-b284-7c460e63cded");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: HashUpdaterProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: HashUpdaterProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private ProcessFlowElement _startEvent1;
		public ProcessFlowElement StartEvent1 {
			get {
				return _startEvent1 ?? (_startEvent1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartEvent1",
					SchemaElementUId = new Guid("ee03fe49-d749-4287-abfb-199f4ce9bbea"),
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
					SchemaElementUId = new Guid("b19af421-ffef-4f36-a378-48508a12ae14"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _executeHashUpdaterScriptTask;
		public ProcessScriptTask ExecuteHashUpdaterScriptTask {
			get {
				return _executeHashUpdaterScriptTask ?? (_executeHashUpdaterScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ExecuteHashUpdaterScriptTask",
					SchemaElementUId = new Guid("59040377-c371-4dda-b344-e1fcccedecdb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ExecuteHashUpdaterScriptTaskExecute"),
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[ExecuteHashUpdaterScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ExecuteHashUpdaterScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExecuteHashUpdaterScriptTask", e.Context.SenderName));
						break;
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "ExecuteHashUpdaterScriptTask":
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
			var cloneItem = (HashUpdaterProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

