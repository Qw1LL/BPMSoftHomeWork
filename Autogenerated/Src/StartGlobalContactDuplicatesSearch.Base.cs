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

	#region Class: StartGlobalContactDuplicatesSearchSchema

	/// <exclude/>
	public class StartGlobalContactDuplicatesSearchSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public StartGlobalContactDuplicatesSearchSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public StartGlobalContactDuplicatesSearchSchema(StartGlobalContactDuplicatesSearchSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "StartGlobalContactDuplicatesSearch";
			UId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001");
			CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
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
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask searchforduplicatesscripttask = CreateSearchForDuplicatesScriptTaskScriptTask();
			FlowElements.Add(searchforduplicatesscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("d832b400-4f8a-4c53-a03f-24a429624e96"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0309dd1c-7bb6-45d4-acb8-5f3d6541e460"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("17c3650b-a140-43e3-8fbb-ff52d3b79f0b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("310c46a4-d355-484b-aff0-66f70cb05b28"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8b9fc258-7476-4b2e-8023-1e67f231e7da"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0309dd1c-7bb6-45d4-acb8-5f3d6541e460"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("559f9d78-9fa4-4d9f-aa00-248cc689cdc2"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("f580e8a0-c07b-4ca7-ac7f-5007648f80f2"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("559f9d78-9fa4-4d9f-aa00-248cc689cdc2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("8b9fc258-7476-4b2e-8023-1e67f231e7da"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f580e8a0-c07b-4ca7-ac7f-5007648f80f2"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				Name = @"Start1",
				Position = new Point(50, 177),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("17c3650b-a140-43e3-8fbb-ff52d3b79f0b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f580e8a0-c07b-4ca7-ac7f-5007648f80f2"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				Name = @"End1",
				Position = new Point(603, 177),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSearchForDuplicatesScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("0309dd1c-7bb6-45d4-acb8-5f3d6541e460"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f580e8a0-c07b-4ca7-ac7f-5007648f80f2"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"),
				Name = @"SearchForDuplicatesScriptTask",
				Position = new Point(288, 163),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,142,77,107,195,48,16,68,207,49,248,63,8,159,100,40,198,57,244,20,122,169,147,246,22,2,110,233,177,108,228,165,22,72,171,176,90,229,131,208,255,94,153,28,76,210,235,48,243,230,29,129,149,9,36,96,164,55,35,122,216,130,71,245,162,170,238,22,86,171,178,56,230,78,148,192,56,236,56,24,28,18,79,13,194,147,234,239,83,253,25,145,243,144,208,136,13,244,164,42,137,135,239,119,23,246,224,220,165,71,96,51,190,5,94,167,131,179,6,4,99,85,103,252,3,186,249,178,50,238,128,179,135,32,235,46,184,228,169,153,131,127,182,245,4,73,209,210,143,210,147,234,176,223,156,209,164,76,205,150,247,70,205,134,98,190,88,191,206,145,174,107,117,45,139,197,188,106,186,224,61,208,240,97,61,134,36,25,178,124,110,219,54,159,44,30,85,111,19,212,243,120,114,249,45,11,70,73,76,74,56,225,234,15,164,176,94,131,99,1,0,0 }
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
			return new StartGlobalContactDuplicatesSearch(userConnection);
		}

		public override object Clone() {
			return new StartGlobalContactDuplicatesSearchSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001"));
		}

		#endregion

	}

	#endregion

	#region Class: StartGlobalContactDuplicatesSearch

	/// <exclude/>
	public class StartGlobalContactDuplicatesSearch : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, StartGlobalContactDuplicatesSearch process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public StartGlobalContactDuplicatesSearch(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "StartGlobalContactDuplicatesSearch";
			SchemaUId = new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0b74450a-0dc4-481a-a7bc-8925808a5001");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: StartGlobalContactDuplicatesSearch, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: StartGlobalContactDuplicatesSearch, Source element: {0}, None of the exclusive gateway conditions are met!";
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
					SchemaElementUId = new Guid("8b9fc258-7476-4b2e-8023-1e67f231e7da"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessEndEvent _end1;
		public ProcessEndEvent End1 {
			get {
				return _end1 ?? (_end1 = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "End1",
					SchemaElementUId = new Guid("17c3650b-a140-43e3-8fbb-ff52d3b79f0b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _searchForDuplicatesScriptTask;
		public ProcessScriptTask SearchForDuplicatesScriptTask {
			get {
				return _searchForDuplicatesScriptTask ?? (_searchForDuplicatesScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SearchForDuplicatesScriptTask",
					SchemaElementUId = new Guid("0309dd1c-7bb6-45d4-acb8-5f3d6541e460"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SearchForDuplicatesScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[SearchForDuplicatesScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchForDuplicatesScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchForDuplicatesScriptTask", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "SearchForDuplicatesScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
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

		public virtual bool SearchForDuplicatesScriptTaskExecute(ProcessExecutingContext context) {
			var contactSchemaName = "Contact";
			var storedProcedure = new StoredProcedure(UserConnection, "tsp_GloballySearchForDuplicates");
			storedProcedure.WithParameter(Column.Parameter(contactSchemaName));
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.CommandTimeout = 15000;
				storedProcedure.Execute(dbExecutor);
			}
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
			var cloneItem = (StartGlobalContactDuplicatesSearch)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

