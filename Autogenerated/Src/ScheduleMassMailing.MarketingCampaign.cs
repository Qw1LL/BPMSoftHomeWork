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

	#region Class: ScheduleMassMailingSchema

	/// <exclude/>
	public class ScheduleMassMailingSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ScheduleMassMailingSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ScheduleMassMailingSchema(ScheduleMassMailingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ScheduleMassMailing";
			UId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f");
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = false;
			SerializeToMemory = false;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,85,204,49,10,194,64,16,133,225,218,64,238,48,229,6,196,11,136,133,138,98,99,33,33,7,88,179,3,14,78,102,151,217,204,90,136,119,55,41,20,82,62,126,222,87,87,201,238,76,61,20,210,209,60,67,137,20,224,234,73,92,3,239,186,90,21,175,144,251,7,6,99,188,32,39,84,216,129,224,11,14,198,207,211,224,137,219,69,117,93,70,61,70,17,236,71,138,178,134,125,74,147,239,231,209,41,55,219,201,92,122,155,31,240,23,243,89,227,208,162,132,155,161,161,155,63,159,47,241,218,60,37,169,0,0,0 };
			RealUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f");
			Version = 0;
			PackageUId = new Guid("789c617e-760f-4576-a608-ee12728eae0a");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateApplicationUrlParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a2e74648-4d63-46c8-a9b0-6390554d56eb"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				Name = @"ApplicationUrl",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateApplicationUrlParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaMainLaneSet = CreateMainLaneSetLaneSet();
			LaneSets.Add(schemaMainLaneSet);
			ProcessSchemaLane schemaMainLane = CreateMainLaneLane();
			schemaMainLaneSet.Lanes.Add(schemaMainLane);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaScriptTask processscripttask = CreateProcessScriptTaskScriptTask();
			FlowElements.Add(processscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("c7d7c3ff-7e4c-440c-8618-eafaa3409ba5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				CreatedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("26c6dd28-0568-43cc-9643-36a630e9a170"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2ff86f31-f4bb-44b7-bf97-ff622b7f1c6b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("d950930b-b896-42bc-82bd-1bf76079c056"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				CreatedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2ff86f31-f4bb-44b7-bf97-ff622b7f1c6b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b3395e05-a3e4-47cf-9baf-e9219fc0f588"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateMainLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaMainLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("d352d59e-3a58-42c9-ab4d-31b39785da35"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				CreatedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				Name = @"MainLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaMainLaneSet;
		}

		protected virtual ProcessSchemaLane CreateMainLaneLane() {
			ProcessSchemaLane schemaMainLane = new ProcessSchemaLane(this) {
				UId = new Guid("8f63321c-02be-49ac-80a2-47e2479b6e84"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("d352d59e-3a58-42c9-ab4d-31b39785da35"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				CreatedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				Name = @"MainLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaMainLane;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("26c6dd28-0568-43cc-9643-36a630e9a170"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8f63321c-02be-49ac-80a2-47e2479b6e84"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				CreatedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				Name = @"Start1",
				Position = new Point(40, 34),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("b3395e05-a3e4-47cf-9baf-e9219fc0f588"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8f63321c-02be-49ac-80a2-47e2479b6e84"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				CreatedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				Name = @"Terminate1",
				Position = new Point(253, 34),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateProcessScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2ff86f31-f4bb-44b7-bf97-ff622b7f1c6b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8f63321c-02be-49ac-80a2-47e2479b6e84"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				CreatedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"),
				Name = @"ProcessScriptTask",
				Position = new Point(120, 20),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,204,204,211,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,176,217,148,41,21,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1c3a371e-6d52-464a-8512-c062f9828840"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("d6fec08a-2746-46b6-a96c-0a31e271957f")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ScheduleMassMailing(userConnection);
		}

		public override object Clone() {
			return new ScheduleMassMailingSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d05b24a3-5154-4a43-83ae-94830640f35f"));
		}

		#endregion

	}

	#endregion

	#region Class: ScheduleMassMailing

	/// <exclude/>
	public class ScheduleMassMailing : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessMainLane

		/// <exclude/>
		public class ProcessMainLane : ProcessLane
		{

			public ProcessMainLane(UserConnection userConnection, ScheduleMassMailing process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ScheduleMassMailing(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ScheduleMassMailing";
			SchemaUId = new Guid("d05b24a3-5154-4a43-83ae-94830640f35f");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = false;
			IsLogging = false;
			UseSystemSecurityContext = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d05b24a3-5154-4a43-83ae-94830640f35f");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ScheduleMassMailing, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ScheduleMassMailing, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual string ApplicationUrl {
			get;
			set;
		}

		private ProcessMainLane _mainLane;
		public ProcessMainLane MainLane {
			get {
				return _mainLane ?? ((_mainLane) = new ProcessMainLane(UserConnection, this));
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
					SchemaElementUId = new Guid("26c6dd28-0568-43cc-9643-36a630e9a170"),
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
					SchemaElementUId = new Guid("b3395e05-a3e4-47cf-9baf-e9219fc0f588"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _processScriptTask;
		public ProcessScriptTask ProcessScriptTask {
			get {
				return _processScriptTask ?? (_processScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ProcessScriptTask",
					SchemaElementUId = new Guid("2ff86f31-f4bb-44b7-bf97-ff622b7f1c6b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ProcessScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ProcessScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ProcessScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ProcessScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("ApplicationUrl")) {
				writer.WriteValue("ApplicationUrl", ApplicationUrl, null);
			}
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
			MetaPathParameterValues.Add("a2e74648-4d63-46c8-a9b0-6390554d56eb", () => ApplicationUrl);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "ApplicationUrl":
					if (!hasValueToRead) break;
					ApplicationUrl = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ProcessScriptTaskExecute(ProcessExecutingContext context) {
			Main();
			return true;
		}

			
			public virtual void Main() {
				var scheduleHelper = new BulkEmailScheduleHelper(UserConnection, ApplicationUrl);
				scheduleHelper.ScheduleBulkEmailsFromSendQueue();
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
			var cloneItem = (ScheduleMassMailing)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

