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

	#region Class: StartGlobalAccountDuplicatesSearchSchema

	/// <exclude/>
	public class StartGlobalAccountDuplicatesSearchSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public StartGlobalAccountDuplicatesSearchSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public StartGlobalAccountDuplicatesSearchSchema(StartGlobalAccountDuplicatesSearchSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "StartGlobalAccountDuplicatesSearch";
			UId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3");
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
			RealUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3");
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
				UId = new Guid("3dd4d7a0-8865-49c4-8656-599abd6bb579"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("306c4ed4-9c5e-4008-8a29-d487d38b12ac"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("41a2c61b-b422-403e-a2a0-876d4652aad4"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("e2938a3d-54cc-47df-bf73-3c07ff396a5b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("44a68c86-5b29-4040-a4a4-d65da239539e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("306c4ed4-9c5e-4008-8a29-d487d38b12ac"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("4873907b-aa76-4764-be72-9ba07ace4d44"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("e7615ac2-db2f-4c81-96eb-6f8e6b3e43d5"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("4873907b-aa76-4764-be72-9ba07ace4d44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("44a68c86-5b29-4040-a4a4-d65da239539e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e7615ac2-db2f-4c81-96eb-6f8e6b3e43d5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
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
				UId = new Guid("41a2c61b-b422-403e-a2a0-876d4652aad4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e7615ac2-db2f-4c81-96eb-6f8e6b3e43d5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
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
				UId = new Guid("306c4ed4-9c5e-4008-8a29-d487d38b12ac"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e7615ac2-db2f-4c81-96eb-6f8e6b3e43d5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				CreatedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"),
				Name = @"SearchForDuplicatesScriptTask",
				Position = new Point(288, 163),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,142,205,10,130,64,20,70,215,9,190,195,224,106,132,240,5,162,69,63,214,46,4,137,150,49,142,151,20,198,59,114,231,142,21,209,187,55,210,66,178,237,225,227,124,103,80,36,148,214,214,35,151,186,129,78,157,84,7,98,45,146,205,23,38,171,56,26,194,198,177,37,168,11,178,26,106,79,227,2,225,46,202,95,42,207,14,104,103,17,65,115,107,113,41,18,118,253,245,104,108,165,140,121,150,160,72,55,7,75,123,223,155,86,43,6,151,164,65,63,83,103,151,150,155,66,81,232,96,32,185,179,198,119,152,77,224,175,54,29,37,222,181,120,19,114,76,173,171,252,1,218,7,107,168,252,45,202,114,116,225,98,191,157,144,76,83,241,138,163,197,188,226,235,0,57,217,198,155,119,28,17,176,39,20,76,30,86,31,62,6,26,43,62,1,0,0 }
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
			return new StartGlobalAccountDuplicatesSearch(userConnection);
		}

		public override object Clone() {
			return new StartGlobalAccountDuplicatesSearchSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3"));
		}

		#endregion

	}

	#endregion

	#region Class: StartGlobalAccountDuplicatesSearch

	/// <exclude/>
	public class StartGlobalAccountDuplicatesSearch : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, StartGlobalAccountDuplicatesSearch process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public StartGlobalAccountDuplicatesSearch(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "StartGlobalAccountDuplicatesSearch";
			SchemaUId = new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3");
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
				return new Guid("25bbdc71-864f-4421-b9ed-db52b3fec6b3");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: StartGlobalAccountDuplicatesSearch, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: StartGlobalAccountDuplicatesSearch, Source element: {0}, None of the exclusive gateway conditions are met!";
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
					SchemaElementUId = new Guid("44a68c86-5b29-4040-a4a4-d65da239539e"),
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
					SchemaElementUId = new Guid("41a2c61b-b422-403e-a2a0-876d4652aad4"),
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
					SchemaElementUId = new Guid("306c4ed4-9c5e-4008-8a29-d487d38b12ac"),
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
			var accountSchemaName = "Account";
			var storedProcedure = new StoredProcedure(UserConnection, "tsp_GloballySearchForDuplicates");
			storedProcedure.WithParameter(Column.Parameter(accountSchemaName));
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
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
			var cloneItem = (StartGlobalAccountDuplicatesSearch)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

