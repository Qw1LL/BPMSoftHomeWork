namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration.Translation;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Core.Translation;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: TranslationActualizationProcessSchema

	/// <exclude/>
	public class TranslationActualizationProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public TranslationActualizationProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public TranslationActualizationProcessSchema(TranslationActualizationProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "TranslationActualizationProcess";
			UId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a");
			CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a");
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
			SerializeToMemory = false;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,193,78,195,48,12,134,207,32,241,14,86,79,169,84,245,5,88,39,141,78,67,28,6,135,118,220,67,235,77,145,186,100,74,220,77,5,241,238,36,129,118,43,100,211,196,37,178,19,231,255,191,56,222,181,111,141,168,96,47,52,181,188,129,189,18,53,204,42,23,139,119,44,53,151,166,225,36,148,100,49,124,220,221,222,84,74,26,2,67,90,200,13,208,241,120,184,82,191,200,162,51,5,18,217,10,147,171,26,33,131,168,12,87,70,247,86,114,206,9,75,177,69,168,251,32,131,19,137,244,17,233,149,55,45,78,250,194,41,91,25,212,185,146,18,43,167,152,92,9,146,88,179,193,45,93,10,233,101,227,31,6,238,179,178,219,121,144,147,44,131,177,93,58,42,94,114,201,55,168,29,229,104,255,161,27,66,70,118,81,107,214,91,199,189,229,247,107,207,192,91,223,227,141,17,209,208,145,133,210,5,223,227,159,118,244,141,244,62,79,161,222,107,179,224,21,41,221,5,221,143,167,25,228,13,55,125,234,140,39,23,229,166,204,245,88,226,1,44,143,157,146,214,237,206,244,166,221,162,36,22,181,35,208,40,249,213,217,248,2,48,4,65,45,224,197,7,56,226,160,28,243,86,193,187,105,112,252,207,252,146,151,57,157,86,27,204,113,237,191,231,191,99,10,195,140,174,168,122,86,7,231,241,249,5,160,132,82,157,168,3,0,0 };
			RealUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a");
			Version = 0;
			PackageUId = new Guid("77e888d2-c4a4-45ce-a906-ac00adb364a2");
			UseSystemSecurityContext = false;
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaTranslationActualizationProcessLaneSet = CreateTranslationActualizationProcessLaneSetLaneSet();
			LaneSets.Add(schemaTranslationActualizationProcessLaneSet);
			ProcessSchemaLane schemaTranslationActualizationProcessLane = CreateTranslationActualizationProcessLaneLane();
			schemaTranslationActualizationProcessLaneSet.Lanes.Add(schemaTranslationActualizationProcessLane);
			ProcessSchemaStartEvent translationactualizationprocessstart = CreateTranslationActualizationProcessStartStartEvent();
			FlowElements.Add(translationactualizationprocessstart);
			ProcessSchemaTerminateEvent translationactualizationprocessterminate = CreateTranslationActualizationProcessTerminateTerminateEvent();
			FlowElements.Add(translationactualizationprocessterminate);
			ProcessSchemaScriptTask translationactualizationprocessscripttask = CreateTranslationActualizationProcessScriptTaskScriptTask();
			FlowElements.Add(translationactualizationprocessscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("7e9cebf2-338d-4072-8e98-209dc3d91967"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a"),
				CreatedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5ef54ee7-7f79-4ebe-a3de-490e0c49bd08"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("58db64e5-e7e4-4675-95f6-6ab024df5ffa"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("2b5b29c6-1850-4e1a-8968-a9644cbf7c5e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a"),
				CreatedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("58db64e5-e7e4-4675-95f6-6ab024df5ffa"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dad0e78c-6ec2-4914-bf30-87182a2ba079"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateTranslationActualizationProcessLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaTranslationActualizationProcessLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("feae7991-70d2-4f1c-8160-827494f7128a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a"),
				CreatedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				Name = @"TranslationActualizationProcessLaneSet",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaTranslationActualizationProcessLaneSet;
		}

		protected virtual ProcessSchemaLane CreateTranslationActualizationProcessLaneLane() {
			ProcessSchemaLane schemaTranslationActualizationProcessLane = new ProcessSchemaLane(this) {
				UId = new Guid("709fd794-e645-4432-a1ae-eedde6ad6f8b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("feae7991-70d2-4f1c-8160-827494f7128a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a"),
				CreatedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				Name = @"TranslationActualizationProcessLane",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaTranslationActualizationProcessLane;
		}

		protected virtual ProcessSchemaStartEvent CreateTranslationActualizationProcessStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("5ef54ee7-7f79-4ebe-a3de-490e0c49bd08"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("709fd794-e645-4432-a1ae-eedde6ad6f8b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a"),
				CreatedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				Name = @"TranslationActualizationProcessStart",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTranslationActualizationProcessTerminateTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("dad0e78c-6ec2-4914-bf30-87182a2ba079"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("709fd794-e645-4432-a1ae-eedde6ad6f8b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a"),
				CreatedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				Name = @"TranslationActualizationProcessTerminate",
				Position = new Point(273, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateTranslationActualizationProcessScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("58db64e5-e7e4-4675-95f6-6ab024df5ffa"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("709fd794-e645-4432-a1ae-eedde6ad6f8b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a"),
				CreatedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"),
				Name = @"TranslationActualizationProcessScriptTask",
				Position = new Point(140, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,115,76,46,41,77,204,201,172,74,13,41,74,204,43,206,73,44,201,204,207,211,208,180,230,42,74,45,41,45,202,83,40,41,42,77,181,6,0,29,203,142,99,36,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ff9dca82-977a-4ce9-8062-8ac2eaaeb786"),
				Name = "BPMSoft.Core.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1fdd7fb9-f16a-484d-a501-9028841e2925"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1ea5ceef-5c8f-4fad-9acb-a04bdc64b6bb"),
				Name = "BPMSoft.Core.Translation",
				Alias = "",
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("56050a26-d70f-4468-96c1-eb3ce2704f77"),
				Name = "BPMSoft.Configuration.Translation",
				Alias = "",
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new TranslationActualizationProcess(userConnection);
		}

		public override object Clone() {
			return new TranslationActualizationProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a"));
		}

		#endregion

	}

	#endregion

	#region Class: TranslationActualizationProcess

	/// <exclude/>
	public class TranslationActualizationProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessTranslationActualizationProcessLane

		/// <exclude/>
		public class ProcessTranslationActualizationProcessLane : ProcessLane
		{

			public ProcessTranslationActualizationProcessLane(UserConnection userConnection, TranslationActualizationProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public TranslationActualizationProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TranslationActualizationProcess";
			SchemaUId = new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a");
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
				return new Guid("2e8af05a-20e3-4721-a092-cd856bb6319a");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: TranslationActualizationProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: TranslationActualizationProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		private ProcessTranslationActualizationProcessLane _translationActualizationProcessLane;
		public ProcessTranslationActualizationProcessLane TranslationActualizationProcessLane {
			get {
				return _translationActualizationProcessLane ?? ((_translationActualizationProcessLane) = new ProcessTranslationActualizationProcessLane(UserConnection, this));
			}
		}

		private ProcessFlowElement _translationActualizationProcessStart;
		public ProcessFlowElement TranslationActualizationProcessStart {
			get {
				return _translationActualizationProcessStart ?? (_translationActualizationProcessStart = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "TranslationActualizationProcessStart",
					SchemaElementUId = new Guid("5ef54ee7-7f79-4ebe-a3de-490e0c49bd08"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessTerminateEvent _translationActualizationProcessTerminate;
		public ProcessTerminateEvent TranslationActualizationProcessTerminate {
			get {
				return _translationActualizationProcessTerminate ?? (_translationActualizationProcessTerminate = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TranslationActualizationProcessTerminate",
					SchemaElementUId = new Guid("dad0e78c-6ec2-4914-bf30-87182a2ba079"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _translationActualizationProcessScriptTask;
		public ProcessScriptTask TranslationActualizationProcessScriptTask {
			get {
				return _translationActualizationProcessScriptTask ?? (_translationActualizationProcessScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "TranslationActualizationProcessScriptTask",
					SchemaElementUId = new Guid("58db64e5-e7e4-4675-95f6-6ab024df5ffa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = TranslationActualizationProcessScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[TranslationActualizationProcessStart.SchemaElementUId] = new Collection<ProcessFlowElement> { TranslationActualizationProcessStart };
			FlowElements[TranslationActualizationProcessTerminate.SchemaElementUId] = new Collection<ProcessFlowElement> { TranslationActualizationProcessTerminate };
			FlowElements[TranslationActualizationProcessScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { TranslationActualizationProcessScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "TranslationActualizationProcessStart":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TranslationActualizationProcessScriptTask", e.Context.SenderName));
						break;
					case "TranslationActualizationProcessTerminate":
						CompleteProcess();
						break;
					case "TranslationActualizationProcessScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TranslationActualizationProcessTerminate", e.Context.SenderName));
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("TranslationActualizationProcessStart", string.Empty));
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

		public virtual bool TranslationActualizationProcessScriptTaskExecute(ProcessExecutingContext context) {
			ActualizeTranslation();
			return true;
		}

			public virtual void ActualizeTranslation() {
				const string translationActualizedOnSysSettingsCode = "TranslationActualizedOn";
				DateTime dateTime = SysSettings.GetValue<DateTime>(UserConnection, translationActualizedOnSysSettingsCode,
					DateTime.MinValue);
				DataValueType dataValueType = UserConnection.DataValueTypeManager.GetDataValueTypeByValueType(typeof(DateTime));
				DateTime translationActualizedOn = (DateTime)dataValueType.GetValueForSave(UserConnection, dateTime);
				ITranslationActualizersFactory translationActualizersFactory = ClassFactory.Get<TranslationActualizersFactory>(
					new ConstructorArgument("userConnection", UserConnection));
				ITranslationActualizer translationActualizer = translationActualizersFactory.GetTranslationActualizer();
				translationActualizer.ActualizeTranslation(translationActualizedOn);
				SysSettings.SetDefValue(UserConnection, translationActualizedOnSysSettingsCode, DateTime.UtcNow);
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
			var cloneItem = (TranslationActualizationProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

