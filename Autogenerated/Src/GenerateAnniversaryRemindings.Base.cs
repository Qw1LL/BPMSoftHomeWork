namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using System.Threading.Tasks;

	#region Class: GenerateAnniversaryRemindingsSchema

	/// <exclude/>
	public class GenerateAnniversaryRemindingsSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public GenerateAnniversaryRemindingsSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public GenerateAnniversaryRemindingsSchema(GenerateAnniversaryRemindingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "GenerateAnniversaryRemindings";
			UId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e");
			CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.7.0.0";
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
			RealUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e");
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
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaScriptTask generatereminding = CreateGenerateRemindingScriptTask();
			FlowElements.Add(generatereminding);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("fa41dea9-7551-47ab-9e2c-1763bd583484"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("528e9bac-1ed2-4e52-8225-6cb1c5f70e0e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c4cc0ca4-aabf-45e6-af76-18930d341b4c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("3d5af550-2a17-4078-8ba4-35edf569ca6f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c4cc0ca4-aabf-45e6-af76-18930d341b4c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("621e8ff4-222d-4239-a838-9104b30d406d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("22f42928-141f-4715-8685-d8996ebbbd4f"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("2a8d5978-d804-4c5e-9392-eef26de94931"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("22f42928-141f-4715-8685-d8996ebbbd4f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("528e9bac-1ed2-4e52-8225-6cb1c5f70e0e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2a8d5978-d804-4c5e-9392-eef26de94931"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
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
				UId = new Guid("621e8ff4-222d-4239-a838-9104b30d406d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2a8d5978-d804-4c5e-9392-eef26de94931"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Name = @"Terminate1",
				Position = new Point(353, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateGenerateRemindingScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("c4cc0ca4-aabf-45e6-af76-18930d341b4c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2a8d5978-d804-4c5e-9392-eef26de94931"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Name = @"GenerateReminding",
				Position = new Point(171, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,83,203,110,227,48,12,60,203,95,161,250,164,0,129,127,32,77,128,166,8,138,0,155,110,209,180,187,135,69,15,178,75,59,218,181,165,66,162,211,26,133,255,125,73,57,15,167,232,73,15,114,134,51,164,20,208,27,91,201,54,192,29,88,240,26,141,179,91,244,114,158,136,109,23,182,128,72,225,144,221,1,254,210,117,11,215,33,230,47,84,225,44,194,7,102,207,1,252,173,179,22,10,70,78,101,250,124,98,130,27,107,205,30,124,208,190,123,132,198,216,87,166,74,41,7,125,11,233,100,150,236,181,191,172,44,231,146,200,8,131,217,147,91,58,87,131,182,234,171,54,2,154,82,170,171,139,251,137,252,76,132,7,108,189,149,76,63,75,250,72,95,212,58,132,123,221,0,81,167,203,135,205,214,149,152,81,141,210,84,237,128,204,150,58,124,43,53,29,4,54,128,59,247,122,164,56,121,43,176,213,245,200,214,44,121,234,222,96,168,23,119,115,201,11,119,142,87,117,18,66,242,215,43,219,54,68,147,215,112,205,193,133,52,118,7,222,96,32,212,77,8,208,228,117,199,200,227,126,64,115,234,36,17,71,202,160,248,240,155,128,160,48,86,92,72,94,179,117,216,182,121,68,252,44,71,200,67,195,181,175,184,140,133,119,233,242,191,52,183,63,47,242,243,251,113,246,179,100,245,81,192,91,28,13,241,224,249,68,4,109,93,207,146,210,121,208,197,78,170,232,57,202,48,246,100,39,78,101,168,66,119,1,181,45,184,49,212,60,179,215,232,124,118,75,104,132,245,33,20,109,76,163,66,18,43,54,177,243,107,91,186,195,16,226,118,62,152,164,38,12,113,117,30,208,148,93,177,29,206,112,165,202,233,5,77,122,166,226,7,51,230,24,228,71,121,130,189,27,203,79,70,244,137,64,223,197,219,115,118,182,182,123,247,15,212,209,64,172,50,234,93,169,235,0,177,10,193,11,141,220,141,115,163,96,40,194,157,175,93,69,234,127,184,106,163,173,174,192,179,7,58,209,78,165,247,14,77,105,8,77,152,192,127,67,8,74,207,86,222,59,175,248,205,208,249,203,0,6,193,125,252,12,151,177,171,145,61,220,121,247,126,57,60,250,27,66,136,100,252,91,254,3,156,70,181,78,7,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("fb29449b-948a-42d8-9ce4-d8a2a70cb237"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ae5cf1a1-fd3c-4e1a-a803-58809bfaee7d"),
				Name = "System.Threading.Tasks",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("49c070a0-632a-4ee3-85de-d059e293c3ee"),
				Name = "System.Collections.Generic",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a4f930e4-62bd-4e84-96b4-2c761af4d3d3"),
				Name = "System.Reflection",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("0db02f09-1196-4f60-80e9-5e7f08e20706"),
				Name = "global::Common.Logging",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new GenerateAnniversaryRemindings(userConnection);
		}

		public override object Clone() {
			return new GenerateAnniversaryRemindingsSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"));
		}

		#endregion

	}

	#endregion

	#region Class: GenerateAnniversaryRemindingsMethodsWrapper

	/// <exclude/>
	public class GenerateAnniversaryRemindingsMethodsWrapper : ProcessModel
	{

		public GenerateAnniversaryRemindingsMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("GenerateRemindingExecute", GenerateRemindingExecute);
		}

		#region Methods: Private

		private bool GenerateRemindingExecute(ProcessExecutingContext context) {
			string useGenerationStr =
				SysSettings.GetValue<string>(context.UserConnection, "UseGenerateAnniversaryRemindings", "true");
			var useGeneration = Convert.ToBoolean(useGenerationStr);
			if (!useGeneration) {
				return true;
			}
			var className = "BPMSoft.Configuration.BaseAnniversaryReminding";
			var methodName = "GenerateActualRemindings";
			Type classType = Type.GetType(className);
			IEnumerable<Type> inherits = Assembly.GetAssembly(classType)
				.GetTypes()
				.Where(type => type.IsSubclassOf(classType));
			var args = new object[] {context.UserConnection};
			Exception lastException = null;
			foreach (Type type in inherits) {
				object instance = Activator.CreateInstance(type, args);
				MethodInfo methodInfo = type.GetMethod(methodName, new[] {typeof(bool)});
				if (methodInfo == null) {
					continue;
				}
				try {
					methodInfo.Invoke(instance, new object[] {false});
				}
				catch (Exception e) {
					var log = LogManager.GetLogger("Notifications");
					log.Error(e);
					lastException = e;
				}
			}
			if (lastException != null) {
				throw lastException;
			}			
			return true;
		}

		#endregion

	}

	#endregion

	#region Class: GenerateAnniversaryRemindings

	/// <exclude/>
	public class GenerateAnniversaryRemindings : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, GenerateAnniversaryRemindings process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public GenerateAnniversaryRemindings(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GenerateAnniversaryRemindings";
			SchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new GenerateAnniversaryRemindingsMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: GenerateAnniversaryRemindings, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: GenerateAnniversaryRemindings, Source element: {0}, None of the exclusive gateway conditions are met!";
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
					SchemaElementUId = new Guid("528e9bac-1ed2-4e52-8225-6cb1c5f70e0e"),
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
					SchemaElementUId = new Guid("621e8ff4-222d-4239-a838-9104b30d406d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _generateReminding;
		public ProcessScriptTask GenerateReminding {
			get {
				return _generateReminding ?? (_generateReminding = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "GenerateReminding",
					SchemaElementUId = new Guid("c4cc0ca4-aabf-45e6-af76-18930d341b4c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("GenerateRemindingExecute"),
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[GenerateReminding.SchemaElementUId] = new Collection<ProcessFlowElement> { GenerateReminding };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GenerateReminding", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "GenerateReminding":
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
			var cloneItem = (GenerateAnniversaryRemindings)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

