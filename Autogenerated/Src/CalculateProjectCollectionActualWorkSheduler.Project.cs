namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration.ProjectService;
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

	#region Class: CalculateProjectCollectionActualWorkShedulerSchema

	/// <exclude/>
	public class CalculateProjectCollectionActualWorkShedulerSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CalculateProjectCollectionActualWorkShedulerSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CalculateProjectCollectionActualWorkShedulerSchema(CalculateProjectCollectionActualWorkShedulerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CalculateProjectCollectionActualWorkSheduler";
			UId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5");
			CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
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
			RealUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5");
			Version = 0;
			PackageUId = new Guid("ca17ff09-8a8b-4af9-8a2a-ff4c0983ba30");
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
			ProcessSchemaScriptTask calculateprojectcollectionactualworkscripttask = CreateCalculateProjectCollectionActualWorkScriptTaskScriptTask();
			FlowElements.Add(calculateprojectcollectionactualworkscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("449ea911-5a0e-4b5f-96ae-34790e96c4ff"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				CreatedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("74e26514-9019-4f98-a031-ee8110a8995e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("12783783-340a-4a65-8b84-0bf6384b866d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("1887873f-76f7-44f1-8095-575b2d17a058"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				CreatedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("12783783-340a-4a65-8b84-0bf6384b866d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c523ef31-e731-4236-a1cd-41f6f86659a2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("835e3f32-8d6a-41e4-8140-fcbc9e34a198"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				CreatedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("d72af235-75c7-4143-aeb5-434ed505c64f"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("835e3f32-8d6a-41e4-8140-fcbc9e34a198"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				CreatedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("74e26514-9019-4f98-a031-ee8110a8995e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d72af235-75c7-4143-aeb5-434ed505c64f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				CreatedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
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
				UId = new Guid("c523ef31-e731-4236-a1cd-41f6f86659a2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d72af235-75c7-4143-aeb5-434ed505c64f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				CreatedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateCalculateProjectCollectionActualWorkScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("12783783-340a-4a65-8b84-0bf6384b866d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d72af235-75c7-4143-aeb5-434ed505c64f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				CreatedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"),
				Name = @"CalculateProjectCollectionActualWorkScriptTask",
				Position = new Point(295, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,82,65,78,195,48,16,60,39,82,254,96,245,148,72,200,226,94,168,84,162,82,229,64,21,40,208,179,149,108,169,193,177,203,218,46,138,16,127,199,169,157,54,41,72,190,120,188,51,59,59,235,18,213,59,84,102,13,120,224,21,144,253,248,122,75,36,124,145,114,4,166,47,26,48,87,82,58,136,43,153,77,147,120,33,13,55,237,186,218,65,195,30,45,96,219,235,44,244,103,208,248,83,114,33,67,135,5,15,76,178,55,192,43,50,9,173,39,93,151,3,67,194,235,92,9,219,72,167,122,110,65,231,117,128,211,1,248,164,148,241,114,116,9,166,68,222,48,108,125,217,138,53,144,102,189,102,224,220,115,97,0,199,194,57,2,51,224,95,54,220,236,74,134,142,234,46,58,245,96,174,154,61,67,174,149,124,110,247,64,11,189,178,66,116,190,25,130,52,67,247,3,85,79,213,157,237,222,176,135,178,41,33,73,60,114,117,140,133,131,30,251,114,3,249,188,220,60,194,7,248,207,90,248,150,156,2,9,50,52,87,86,26,50,35,215,25,249,78,226,104,171,220,132,213,142,164,151,45,91,194,229,165,7,79,137,6,165,69,61,240,117,164,117,214,186,40,194,66,94,153,176,112,179,180,188,158,165,253,238,104,23,127,231,47,138,198,223,141,230,76,84,86,184,196,67,112,243,202,88,38,54,10,63,238,218,0,21,167,200,138,250,168,241,147,196,238,36,49,130,177,40,137,65,11,211,95,152,114,33,137,213,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("bdbdefc2-e4c2-4cd8-9637-3fa3674b56bd"),
				Name = "BPMSoft.Configuration.ProjectService",
				Alias = "",
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CalculateProjectCollectionActualWorkSheduler(userConnection);
		}

		public override object Clone() {
			return new CalculateProjectCollectionActualWorkShedulerSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5"));
		}

		#endregion

	}

	#endregion

	#region Class: CalculateProjectCollectionActualWorkSheduler

	/// <exclude/>
	public class CalculateProjectCollectionActualWorkSheduler : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CalculateProjectCollectionActualWorkSheduler process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public CalculateProjectCollectionActualWorkSheduler(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CalculateProjectCollectionActualWorkSheduler";
			SchemaUId = new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("10a4b33c-eb11-45da-bda7-7b4a81fee1f5");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CalculateProjectCollectionActualWorkSheduler, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CalculateProjectCollectionActualWorkSheduler, Source element: {0}, None of the exclusive gateway conditions are met!";
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
					SchemaElementUId = new Guid("74e26514-9019-4f98-a031-ee8110a8995e"),
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
					SchemaElementUId = new Guid("c523ef31-e731-4236-a1cd-41f6f86659a2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _calculateProjectCollectionActualWorkScriptTask;
		public ProcessScriptTask CalculateProjectCollectionActualWorkScriptTask {
			get {
				return _calculateProjectCollectionActualWorkScriptTask ?? (_calculateProjectCollectionActualWorkScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CalculateProjectCollectionActualWorkScriptTask",
					SchemaElementUId = new Guid("12783783-340a-4a65-8b84-0bf6384b866d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = CalculateProjectCollectionActualWorkScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[CalculateProjectCollectionActualWorkScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CalculateProjectCollectionActualWorkScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CalculateProjectCollectionActualWorkScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "CalculateProjectCollectionActualWorkScriptTask":
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

		public virtual bool CalculateProjectCollectionActualWorkScriptTaskExecute(ProcessExecutingContext context) {
			ProjectService projectService = new ProjectService(UserConnection);
			EntitySchemaQuery projectEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Project");
			var idColumn = projectEsq.AddColumn(projectEsq.RootSchema.GetPrimaryColumnName());
			var projectFilter = projectEsq.CreateFilterWithParameters(FilterComparisonType.IsNull, "ParentProject");
			projectEsq.Filters.Add(projectFilter);  
			
			var projectEntities = projectEsq.GetEntityCollection(UserConnection);
			if (projectEntities.Count > 0) {
				foreach (var projectEntity in projectEntities) {
					var projectId = projectEntity.GetTypedColumnValue<Guid>(idColumn.Name);
					projectService.CalculateProjectActualWorkByProjectId(projectId);
				}
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
			var cloneItem = (CalculateProjectCollectionActualWorkSheduler)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

