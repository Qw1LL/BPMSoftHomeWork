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
	using System.Linq;
	using System.Text;

	#region Class: SatisfactionUpdateProcessSchema

	/// <exclude/>
	public class SatisfactionUpdateProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SatisfactionUpdateProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SatisfactionUpdateProcessSchema(SatisfactionUpdateProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SatisfactionUpdateProcess";
			UId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca");
			CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22");
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
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,205,106,195,48,16,132,207,49,248,29,84,159,100,48,126,129,182,129,144,134,28,218,66,130,219,222,85,123,157,44,200,178,209,143,139,41,125,247,174,172,150,216,137,65,23,49,179,243,205,110,28,117,238,83,98,201,122,212,214,9,201,158,176,180,216,42,161,135,7,84,54,99,123,135,213,154,237,193,94,132,66,88,52,181,24,191,47,208,131,228,41,251,142,163,85,47,52,219,21,71,246,200,20,124,177,157,178,104,135,162,60,67,35,142,14,244,192,223,13,232,109,171,20,140,147,249,212,240,42,148,56,129,206,88,114,19,158,164,247,113,68,177,249,166,170,54,82,6,255,182,149,174,81,134,123,205,99,205,245,148,161,22,126,136,138,7,14,77,200,0,190,234,241,31,161,167,43,254,237,176,120,140,17,90,183,26,68,121,230,139,112,134,106,161,209,229,72,93,75,105,132,184,241,248,186,111,67,7,85,216,239,67,72,7,158,188,230,201,193,207,140,183,88,97,205,239,102,109,115,218,198,10,84,230,25,6,62,134,167,1,182,154,219,232,130,65,206,22,208,7,141,13,153,38,228,17,246,19,71,244,40,199,105,53,191,17,169,164,196,209,47,205,204,68,9,67,2,0,0 };
			RealUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca");
			Version = 0;
			PackageUId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57");
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
			ProcessSchemaScriptTask setsatisfactionlevelscripttask = CreateSetSatisfactionLevelScriptTaskScriptTask();
			FlowElements.Add(setsatisfactionlevelscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("c35981e6-30bd-4881-a05d-ea9eb86708a0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22"),
				CreatedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("03ed6b2a-7daa-4d2e-acc8-3c5231eb7a36"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d1cfdcbf-8b95-4b1f-96a9-755138c91dd2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("01d452f2-ee08-430e-a761-667ecdf437b2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22"),
				CreatedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d1cfdcbf-8b95-4b1f-96a9-755138c91dd2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("bf5a4500-60e8-49a7-b936-cab4fc19a130"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("8f1a79b9-e0b9-4065-bb4c-6773b9d9a52f"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22"),
				CreatedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("28ed4bf2-6990-4640-a02d-25e42219854d"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("8f1a79b9-e0b9-4065-bb4c-6773b9d9a52f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22"),
				CreatedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("03ed6b2a-7daa-4d2e-acc8-3c5231eb7a36"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28ed4bf2-6990-4640-a02d-25e42219854d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22"),
				CreatedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
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
				UId = new Guid("bf5a4500-60e8-49a7-b936-cab4fc19a130"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28ed4bf2-6990-4640-a02d-25e42219854d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22"),
				CreatedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				Name = @"Terminate1",
				Position = new Point(309, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSetSatisfactionLevelScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("d1cfdcbf-8b95-4b1f-96a9-755138c91dd2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28ed4bf2-6990-4640-a02d-25e42219854d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22"),
				CreatedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"),
				Name = @"SetSatisfactionLevelScriptTask",
				Position = new Point(155, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,85,93,111,218,48,20,125,102,210,254,131,203,147,35,161,104,207,219,232,68,233,135,208,186,150,149,117,125,168,250,96,37,23,176,148,24,102,59,237,162,137,255,190,235,107,167,113,2,98,90,145,74,69,114,124,238,185,231,126,120,240,44,52,3,243,139,141,153,130,23,118,161,172,180,245,34,91,67,41,190,87,160,107,126,111,64,79,55,74,65,102,229,70,165,49,224,155,80,98,5,122,196,134,11,97,165,89,10,130,220,111,115,97,97,152,124,122,255,110,128,196,233,92,203,82,232,154,216,166,155,162,42,85,58,51,147,226,69,212,102,1,5,210,98,104,171,43,112,120,99,181,84,43,150,105,64,138,252,86,121,252,141,40,1,65,142,108,146,231,254,25,31,78,27,208,48,73,111,117,14,250,172,62,7,147,241,36,117,248,152,77,24,152,229,71,169,16,145,206,242,225,222,209,237,70,42,123,236,228,220,1,246,207,101,155,178,132,227,39,167,30,210,156,29,248,15,82,120,135,17,230,188,65,63,89,69,134,154,64,113,5,182,143,232,213,136,156,151,75,198,79,194,201,116,162,106,158,36,236,15,62,31,104,176,149,86,175,142,239,240,207,181,0,101,106,66,23,156,75,34,194,170,125,190,170,100,62,98,113,125,175,225,25,10,202,251,148,83,168,229,6,43,145,173,25,247,186,24,102,229,254,201,87,229,33,178,11,35,115,151,6,1,92,38,63,234,45,4,71,126,138,162,2,10,119,202,251,21,163,48,148,146,151,153,98,178,86,72,101,190,66,205,101,222,164,214,38,130,65,60,242,81,230,79,116,120,64,191,211,224,58,190,247,149,194,86,188,169,138,226,86,95,148,91,91,243,14,40,97,95,142,73,245,4,40,182,95,235,132,125,100,29,162,88,192,60,150,215,252,26,179,15,199,99,145,217,189,102,108,195,16,11,5,217,49,40,12,4,55,130,87,216,115,232,209,136,10,123,184,142,236,15,107,100,253,175,134,17,69,26,180,182,190,201,48,34,217,249,42,239,162,166,204,113,63,88,192,34,55,141,121,45,141,13,61,66,232,168,81,81,215,136,209,43,102,250,89,186,227,168,168,69,239,249,224,233,226,229,70,107,163,243,96,204,254,189,11,211,75,169,242,153,50,86,168,12,206,106,151,157,95,47,126,31,134,9,105,169,145,180,31,39,245,139,205,63,58,52,218,237,129,20,223,78,242,82,170,59,185,90,211,244,46,5,214,191,51,148,237,76,224,64,250,150,8,227,226,230,41,226,186,4,155,173,47,245,166,60,63,11,115,128,198,119,70,11,140,197,85,110,221,50,243,0,170,107,212,126,68,185,239,126,103,92,27,146,87,230,56,159,5,132,182,32,102,222,185,87,136,11,151,244,232,64,125,31,27,214,39,223,68,212,65,94,206,73,111,208,31,214,210,194,98,43,50,224,113,18,205,204,191,73,85,179,203,71,236,16,101,172,40,102,21,207,192,169,94,49,130,190,218,190,119,211,123,39,212,10,120,179,203,23,116,103,242,138,141,79,89,213,92,174,145,188,164,93,150,49,77,116,3,68,163,69,151,114,179,244,233,73,191,225,188,25,169,235,139,110,226,205,53,31,0,15,107,208,104,13,93,162,51,197,195,69,63,23,26,39,192,130,54,145,24,212,33,76,8,231,51,143,196,164,23,191,33,171,80,71,100,74,124,101,253,5,207,201,84,10,176,8,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ca2c725f-edc8-445a-a394-c112481e1f94"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2c267f4e-2dc4-4414-8725-4fc3c492c5aa"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SatisfactionUpdateProcess(userConnection);
		}

		public override object Clone() {
			return new SatisfactionUpdateProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca"));
		}

		#endregion

	}

	#endregion

	#region Class: SatisfactionUpdateProcess

	/// <exclude/>
	public class SatisfactionUpdateProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SatisfactionUpdateProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SatisfactionUpdateProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SatisfactionUpdateProcess";
			SchemaUId = new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca");
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
				return new Guid("92753ebc-e72e-41f5-8d5a-68c4b7974bca");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SatisfactionUpdateProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SatisfactionUpdateProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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
					SchemaElementUId = new Guid("03ed6b2a-7daa-4d2e-acc8-3c5231eb7a36"),
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
					SchemaElementUId = new Guid("bf5a4500-60e8-49a7-b936-cab4fc19a130"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _setSatisfactionLevelScriptTask;
		public ProcessScriptTask SetSatisfactionLevelScriptTask {
			get {
				return _setSatisfactionLevelScriptTask ?? (_setSatisfactionLevelScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetSatisfactionLevelScriptTask",
					SchemaElementUId = new Guid("d1cfdcbf-8b95-4b1f-96a9-755138c91dd2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SetSatisfactionLevelScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[SetSatisfactionLevelScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetSatisfactionLevelScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetSatisfactionLevelScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "SetSatisfactionLevelScriptTask":
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

		public virtual bool SetSatisfactionLevelScriptTaskExecute(ProcessExecutingContext context) {
				var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SatisfactionUpdate");
				esq.PrimaryQueryColumn.IsAlwaysSelect = true;
				string createdOnColumnName = esq.AddColumn("CreatedOn").OrderByDesc().Name;
				string caseIdColumnName = esq.AddColumn("Case.Id").Name;
				string pointColumnName = esq.AddColumn("Point").Name;
				string commentColumnName = esq.AddColumn("Comment").Name;							
				EntityCollection updates = esq.GetEntityCollection(UserConnection);
				if (!updates.Any()) {
					return true;
				}
				var points = new Dictionary<Guid, SatisfactionLevelPoint>();
				foreach (Entity entity in updates) {
					var id = entity.GetTypedColumnValue<Guid>(caseIdColumnName);
					if (points.ContainsKey(id)) {
						var point = points[id];
						point.Comment = string.IsNullOrEmpty(point.Comment) ? entity.GetTypedColumnValue<string>(commentColumnName) : point.Comment;
						point.Point = point.Point == 0 ? entity.GetTypedColumnValue<int>(pointColumnName) : point.Point;
					} else {
						points.Add(id, new SatisfactionLevelPoint { Point = entity.GetTypedColumnValue<int>(pointColumnName),
							Comment = entity.GetTypedColumnValue<string>(commentColumnName)
						});
					}
				}
				var deleteKeys = new List<Guid>();
				Dictionary<int, Guid> satisfactionLevels = GetDictionarySatisfactionLevel();
				EntitySchema caseEntitySchema = UserConnection.EntitySchemaManager.FindInstanceByName("Case");
				Entity caseEntity = caseEntitySchema.CreateEntity(UserConnection);
				caseEntity.UseAdminRights = false;
				foreach (var point in points) {
					if (caseEntity.FetchFromDB(point.Key)) {
						var estimate = point.Value.Point;
						if (satisfactionLevels.ContainsKey(estimate)) {
							caseEntity.SetColumnValue("SatisfactionLevelId", satisfactionLevels[estimate]);
						}
						if (!string.IsNullOrWhiteSpace(point.Value.Comment)) {
							caseEntity.SetColumnValue("SatisfactionLevelComment", point.Value.Comment);
						}
						caseEntity.Save(false);
						}
					}
					deleteKeys.AddRange(updates.Select(u => u.PrimaryColumnValue));
					if (deleteKeys.Any()) {
						var deleteQuery = new Delete(UserConnection)
							.From("SatisfactionUpdate")
							.Where("Id").In(Column.Parameters(deleteKeys)) as Delete;
						deleteQuery.Execute();
						}
				return true;
		}

			
			public virtual Dictionary<int, Guid> GetDictionarySatisfactionLevel() {
				var ESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SatisfactionLevel");
			ESQ.AddAllSchemaColumns();
			var satisfactionLevels = ESQ.GetEntityCollection(UserConnection);
			var retDictionary = new Dictionary<int, Guid>();
			foreach(var satisfactionLevel in satisfactionLevels) {
				var point = satisfactionLevel.GetTypedColumnValue<int>("Point");
				if(!retDictionary.ContainsKey(point)) {
					retDictionary.Add(point, satisfactionLevel.PrimaryColumnValue);
				}
			}
			return retDictionary;
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
			var cloneItem = (SatisfactionUpdateProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

