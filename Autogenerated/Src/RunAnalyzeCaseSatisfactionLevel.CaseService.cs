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

	#region Class: RunAnalyzeCaseSatisfactionLevelSchema

	/// <exclude/>
	public class RunAnalyzeCaseSatisfactionLevelSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public RunAnalyzeCaseSatisfactionLevelSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public RunAnalyzeCaseSatisfactionLevelSchema(RunAnalyzeCaseSatisfactionLevelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "RunAnalyzeCaseSatisfactionLevel";
			UId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1");
			CreatedInPackageId = new Guid("30de0e3b-0a22-4b21-aec2-eb5dee3a342f");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.8.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsActiveVersion = false;
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
			RealUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1");
			Version = 0;
			PackageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCaseRecordIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c38a0af2-cfe7-436f-8d64-87341f47d144"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Name = @"CaseRecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{73da230b-c3b0-4648-b931-60aef0bc046c}].[Parameter:{5984f6fb-289e-4980-aea6-b57aa1779872}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCaseRecordIdParameter());
		}

		protected virtual void InitializeStartSignal1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5984f6fb-289e-4980-aea6-b57aa1779872"),
				ContainerUId = new Guid("73da230b-c3b0-4648-b931-60aef0bc046c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e9f654a3-168a-4e03-958d-43d8e77b1431"),
				ContainerUId = new Guid("73da230b-c3b0-4648-b931-60aef0bc046c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("73da230b-c3b0-4648-b931-60aef0bc046c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"117d32f9-8275-4534-8411-1c66115ce9cd",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaStartSignalEvent startsignal1 = CreateStartSignal1StartSignalEvent();
			FlowElements.Add(startsignal1);
			ProcessSchemaScriptTask runprocess = CreateRunProcessScriptTask();
			FlowElements.Add(runprocess);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("58c48669-2996-455f-8128-3c393ebe0a43"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("73da230b-c3b0-4648-b931-60aef0bc046c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0b998ab2-94c4-48c4-9555-71041042693b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("072884ec-d907-4c9c-9716-1d042fe62b58"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0b998ab2-94c4-48c4-9555-71041042693b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d85c2283-ddfa-4265-a558-c22d2429128a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("5a8d38cc-2217-4e06-aae6-58dbe1e2d7cb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("cde03cbb-c778-4c8e-a9a0-f1dd4b69874c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a8d38cc-2217-4e06-aae6-58dbe1e2d7cb"),
				CreatedInOwnerSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("d85c2283-ddfa-4265-a558-c22d2429128a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("cde03cbb-c778-4c8e-a9a0-f1dd4b69874c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Name = @"TerminateEvent1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal1StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("73da230b-c3b0-4648-b931-60aef0bc046c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("cde03cbb-c778-4c8e-a9a0-f1dd4b69874c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Name = @"StartSignal1",
				NewEntityChangedColumns = false,
				Position = new Point(53, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = true,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaStartSignalEvent.EntityChangedColumns.Add("ccfc5fbf-4dc9-47e4-91f3-54ea9251ab18");
			InitializeStartSignal1Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateRunProcessScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("0b998ab2-94c4-48c4-9555-71041042693b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("cde03cbb-c778-4c8e-a9a0-f1dd4b69874c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"),
				Name = @"RunProcess",
				Position = new Point(322, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,84,219,142,218,48,16,125,134,175,200,230,97,21,36,228,31,232,69,90,66,88,69,234,174,182,64,183,207,110,50,1,75,142,3,190,164,141,186,252,123,199,118,2,33,187,148,94,30,237,153,57,115,230,204,177,107,42,3,80,251,224,67,32,224,123,144,8,205,116,179,202,182,80,210,207,6,100,19,125,81,32,227,74,8,200,52,171,4,233,39,60,80,65,55,32,167,65,24,83,5,225,228,221,184,70,48,165,169,54,42,174,184,41,197,35,45,1,145,109,3,114,151,231,254,50,10,87,84,51,85,80,135,248,9,106,224,100,229,138,72,154,135,19,98,139,250,80,169,90,48,65,185,47,70,180,63,6,243,117,231,188,82,181,4,85,241,26,242,139,120,93,117,151,56,24,12,71,189,198,232,85,127,155,128,66,222,229,37,19,75,182,217,106,133,85,5,229,170,29,52,67,80,175,108,139,118,15,218,159,7,250,79,3,219,127,9,89,37,243,52,71,100,86,4,81,175,250,6,215,104,56,159,4,63,199,35,11,204,28,95,199,3,145,79,137,182,193,186,217,117,42,60,83,110,224,253,183,170,226,31,163,11,99,186,181,96,195,22,182,19,231,239,80,135,234,31,65,237,24,125,174,47,47,193,205,169,137,27,103,36,65,27,41,2,45,13,170,54,58,120,38,104,90,91,229,37,191,78,230,222,176,252,56,226,209,162,221,88,208,51,55,98,93,183,190,237,145,10,132,19,25,204,26,11,21,29,223,194,168,93,137,4,101,184,182,183,118,183,61,12,18,75,160,26,222,220,179,173,63,21,94,244,142,211,173,151,183,0,157,109,23,178,42,231,179,232,204,40,193,237,237,64,42,116,138,21,131,36,229,78,55,157,192,71,160,21,232,158,108,157,165,241,121,78,207,97,44,207,214,17,255,96,178,183,13,214,154,193,133,60,177,223,49,139,121,165,140,132,57,42,137,228,6,43,139,141,148,40,185,189,181,100,218,163,205,93,51,220,213,196,181,115,252,115,224,160,161,253,5,231,238,48,92,137,77,37,86,220,40,196,4,218,64,254,88,105,86,176,12,63,160,74,132,62,254,117,11,178,53,129,251,204,82,149,236,13,229,81,59,227,19,149,56,165,6,121,190,30,95,123,39,242,40,76,74,202,248,26,202,29,71,150,169,131,16,145,13,143,94,65,204,158,30,86,85,161,9,114,44,216,198,72,199,131,184,229,128,172,89,6,24,80,90,17,247,140,140,13,246,9,175,119,28,59,79,131,255,195,78,148,102,165,11,46,97,111,64,105,15,107,65,189,184,94,88,146,252,128,204,160,166,238,18,223,238,217,74,105,13,145,115,180,141,30,198,135,113,255,169,255,2,93,145,36,250,161,6,0,0 }
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
			return new RunAnalyzeCaseSatisfactionLevel(userConnection);
		}

		public override object Clone() {
			return new RunAnalyzeCaseSatisfactionLevelSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1"));
		}

		#endregion

	}

	#endregion

	#region Class: RunAnalyzeCaseSatisfactionLevel

	/// <exclude/>
	public class RunAnalyzeCaseSatisfactionLevel : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, RunAnalyzeCaseSatisfactionLevel process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public RunAnalyzeCaseSatisfactionLevel(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RunAnalyzeCaseSatisfactionLevel";
			SchemaUId = new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_caseRecordId = () => { return (Guid)((StartSignal1.RecordId)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4898f7ea-06ca-401a-9cd3-bbb193f916c1");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: RunAnalyzeCaseSatisfactionLevel, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: RunAnalyzeCaseSatisfactionLevel, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private Func<Guid> _caseRecordId;
		public virtual Guid CaseRecordId {
			get {
				return (_caseRecordId ?? (_caseRecordId = () => Guid.Empty)).Invoke();
			}
			set {
				_caseRecordId = () => { return value; };
			}
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
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
					SchemaElementUId = new Guid("d85c2283-ddfa-4265-a558-c22d2429128a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessStartSignalEvent _startSignal1;
		public ProcessStartSignalEvent StartSignal1 {
			get {
				return _startSignal1 ?? (_startSignal1 = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "StartSignal1",
					SerializeToDB = false,
					IsLogging = true,
					SchemaElementUId = new Guid("73da230b-c3b0-4648-b931-60aef0bc046c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _runProcess;
		public ProcessScriptTask RunProcess {
			get {
				return _runProcess ?? (_runProcess = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RunProcess",
					SchemaElementUId = new Guid("0b998ab2-94c4-48c4-9555-71041042693b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = RunProcessExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[StartSignal1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal1 };
			FlowElements[RunProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { RunProcess };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "StartSignal1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("RunProcess", e.Context.SenderName));
						break;
					case "RunProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CaseRecordId")) {
				writer.WriteValue("CaseRecordId", CaseRecordId, Guid.Empty);
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
			MetaPathParameterValues.Add("c38a0af2-cfe7-436f-8d64-87341f47d144", () => CaseRecordId);
			MetaPathParameterValues.Add("5984f6fb-289e-4980-aea6-b57aa1779872", () => StartSignal1.RecordId);
			MetaPathParameterValues.Add("e9f654a3-168a-4e03-958d-43d8e77b1431", () => StartSignal1.EntitySchemaUId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CaseRecordId":
					if (!hasValueToRead) break;
					CaseRecordId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool RunProcessExecute(ProcessExecutingContext context) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Case");
			var statusColumnName =  esq.AddColumn("SatisfactionLevel.Status.Id").Name;
			var statusIsFinalColumn = esq.AddColumn("SatisfactionLevel.Status.IsFinal");
			var statusIsResolvedColumn = esq.AddColumn("Status.IsResolved");
			var statusCaseIsFinalColumn = esq.AddColumn("Status.IsFinal");
			esq.UseAdminRights = false;
			var caseEntity = esq.GetEntity(UserConnection, CaseRecordId);
			if (caseEntity != null) {
				var isCaseFinal = caseEntity.GetTypedColumnValue<bool>(statusCaseIsFinalColumn.Name);
				var isResolved = caseEntity.GetTypedColumnValue<bool>(statusIsResolvedColumn.Name);
				if (isCaseFinal || !isResolved) {
					return true;
				}
				var newCaseStatus = caseEntity.GetTypedColumnValue<Guid>(statusColumnName);
				var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("Case");
				Entity resultCase = entitySchema.CreateEntity(UserConnection);
				resultCase.UseAdminRights = false;
				if (resultCase.FetchFromDB(CaseRecordId) && newCaseStatus != Guid.Empty) {
					resultCase.SetColumnValue("StatusId", newCaseStatus);
					var isFinal = caseEntity.GetTypedColumnValue<bool>(statusIsFinalColumn.Name);
					if (isFinal) {
						resultCase.SetColumnValue("ClosureDate", UserConnection.CurrentUser.GetCurrentDateTime());
						var delete = new Delete(UserConnection)
						.From("DelayedNotification")
						.Where("CaseId").IsEqual(Column.Parameter(CaseRecordId))
						.And("EmailTemplateId").In(
							Column.Parameter(BPMSoft.Configuration.CaseServiceConsts.ResolutionNotificationTplId), 
							Column.Parameter(BPMSoft.Configuration.CaseServiceConsts.EstimationRequestTplId)
						);
						delete.Execute();
					}
					resultCase.Save(false);
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
			var cloneItem = (RunAnalyzeCaseSatisfactionLevel)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

