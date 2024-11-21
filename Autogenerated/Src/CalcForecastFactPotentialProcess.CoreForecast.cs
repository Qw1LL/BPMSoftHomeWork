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

	#region Class: CalcForecastFactPotentialProcessSchema

	/// <exclude/>
	public class CalcForecastFactPotentialProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CalcForecastFactPotentialProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CalcForecastFactPotentialProcessSchema(CalcForecastFactPotentialProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CalcForecastFactPotentialProcess";
			UId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a");
			CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.8.0.0";
			CultureName = @"en-US";
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,83,193,78,227,48,16,61,111,165,254,195,168,167,84,170,44,238,108,145,80,90,80,15,32,22,232,238,97,181,7,147,76,169,81,98,151,241,184,40,90,246,223,215,142,147,52,73,57,197,177,223,188,121,126,243,60,157,28,220,75,161,50,56,42,98,39,11,56,26,149,67,74,40,25,31,177,84,58,87,250,53,153,195,223,233,68,237,32,185,49,132,153,180,188,201,97,185,132,91,167,114,177,46,15,92,193,231,39,164,142,8,53,111,45,82,106,52,203,236,12,85,211,124,35,100,71,250,114,58,249,55,157,88,38,207,15,187,134,246,94,150,8,75,136,187,177,198,227,142,146,0,237,187,63,208,248,1,107,205,138,171,167,108,143,165,252,225,144,170,164,233,168,49,99,101,180,232,3,238,164,150,175,72,11,152,181,202,103,243,203,174,109,102,10,87,234,166,169,239,32,174,243,60,173,247,146,89,216,157,205,69,248,248,130,205,89,215,27,85,48,210,134,177,132,93,189,108,40,162,117,241,244,151,226,253,131,36,79,225,127,108,18,55,83,83,30,36,41,107,244,115,117,64,177,126,247,174,47,192,251,18,170,31,141,225,216,68,220,34,63,144,42,37,85,81,82,80,146,204,23,112,26,65,184,73,40,138,188,54,168,79,162,150,112,18,21,251,218,34,250,2,126,54,138,21,218,70,168,231,31,67,70,78,6,150,48,244,182,80,164,198,105,134,43,184,136,131,28,77,173,133,253,190,248,19,200,195,237,26,55,127,202,194,225,247,104,250,85,114,114,125,30,67,208,229,12,168,91,197,89,159,18,120,174,172,195,138,39,228,21,238,122,173,108,50,4,92,59,222,27,10,105,132,81,86,122,153,21,93,104,135,228,198,81,134,117,109,167,198,35,45,91,209,253,71,76,219,101,80,222,123,9,95,62,144,1,56,18,62,171,218,206,149,143,81,88,138,45,103,247,230,99,0,92,161,205,72,29,234,177,118,207,197,7,163,148,156,116,170,122,160,197,224,133,141,220,115,47,111,222,141,84,182,116,167,107,13,78,190,42,170,175,117,10,228,16,82,217,254,163,25,64,27,3,219,223,62,110,59,166,145,71,31,251,24,148,233,228,63,138,38,252,151,175,4,0,0 };
			RealUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a");
			Version = 0;
			PackageUId = new Guid("ac31baee-da21-4a6a-8206-cc9cad5b9385");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCurrentUserContactIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("99c4f988-d8e3-4f37-bf52-4fce005d8f98"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Name = @"CurrentUserContactId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateForecastIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ed0a7641-5e95-46e5-98fb-fdd4783a0fda"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Name = @"ForecastId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateRemindingDescriptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2a873ba5-e10b-4b12-9308-5aad57f4a73d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9"),
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Name = @"RemindingDescription",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateRemindingSubjectCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0868024e-f0d0-4a64-bf9f-a60b9cfb78ea"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9"),
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Name = @"RemindingSubjectCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCurrentUserContactIdParameter());
			Parameters.Add(CreateForecastIdParameter());
			Parameters.Add(CreateRemindingDescriptionParameter());
			Parameters.Add(CreateRemindingSubjectCaptionParameter());
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
			ProcessSchemaScriptTask scriptcalculatefact = CreateScriptCalculateFactScriptTask();
			FlowElements.Add(scriptcalculatefact);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("906d5678-b3d3-4bcc-8753-2ca9595f15bc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9"),
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("74ffad96-8e68-4020-a9f5-20133075d3d6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6a213519-968a-4263-8368-e11ce64b8e7b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("902e9903-8692-4a64-93bc-863bfc8ace90"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9"),
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6a213519-968a-4263-8368-e11ce64b8e7b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b32b0f8e-745e-4035-9a1c-0388e5f58a97"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("ba7c15ad-0542-4b92-8638-16c253cc926f"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9"),
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("59acf088-3a61-49fe-a5b7-06fd307aede7"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("ba7c15ad-0542-4b92-8638-16c253cc926f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9"),
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("74ffad96-8e68-4020-a9f5-20133075d3d6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("59acf088-3a61-49fe-a5b7-06fd307aede7"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9"),
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
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
				UId = new Guid("b32b0f8e-745e-4035-9a1c-0388e5f58a97"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("59acf088-3a61-49fe-a5b7-06fd307aede7"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9"),
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptCalculateFactScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("6a213519-968a-4263-8368-e11ce64b8e7b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("59acf088-3a61-49fe-a5b7-06fd307aede7"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9"),
				CreatedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"),
				Name = @"ScriptCalculateFact",
				Position = new Point(169, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,193,106,195,48,12,134,207,29,236,29,52,159,18,40,121,129,210,83,104,203,46,35,116,140,29,139,177,255,101,166,141,83,100,153,109,140,189,251,148,178,82,240,114,148,44,253,223,103,133,55,170,182,35,195,217,36,143,158,30,214,180,203,193,55,155,225,44,95,53,125,223,223,45,158,69,159,125,199,163,131,207,12,74,69,189,166,136,15,42,166,170,151,4,110,199,24,225,36,140,113,73,70,210,249,176,87,204,201,229,147,21,92,153,91,235,196,212,138,89,52,175,65,222,59,203,118,128,128,43,115,179,50,75,186,21,53,217,84,210,86,186,95,104,53,157,117,71,219,227,73,227,84,113,194,31,251,195,53,198,76,27,65,191,222,102,102,68,249,179,21,149,153,63,194,191,248,66,118,46,71,181,231,218,245,196,254,153,49,222,124,194,101,65,117,25,104,25,122,165,61,134,16,125,136,253,165,169,75,12,201,28,73,56,99,245,11,74,134,255,107,187,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("22478daa-240f-4b50-b59c-0c967dad1e91"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("0db428d0-fc38-40d1-af3f-5cbb75ee95a9")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CalcForecastFactPotentialProcess(userConnection);
		}

		public override object Clone() {
			return new CalcForecastFactPotentialProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a"));
		}

		#endregion

	}

	#endregion

	#region Class: CalcForecastFactPotentialProcess

	/// <exclude/>
	public class CalcForecastFactPotentialProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CalcForecastFactPotentialProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public CalcForecastFactPotentialProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CalcForecastFactPotentialProcess";
			SchemaUId = new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a");
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
				return new Guid("8050561b-65ac-430e-bd44-72ca90da7c5a");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CalcForecastFactPotentialProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CalcForecastFactPotentialProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid CurrentUserContactId {
			get;
			set;
		}

		public virtual Guid ForecastId {
			get;
			set;
		}

		private LocalizableString _remindingDescription;
		public virtual LocalizableString RemindingDescription {
			get {
				return _remindingDescription ?? (_remindingDescription = GetLocalizableString("8050561b65ac430ebd4472ca90da7c5a",
						 "Parameters.RemindingDescription.Value"));
			}
			set {
				_remindingDescription = value;
			}
		}

		private LocalizableString _remindingSubjectCaption;
		public virtual LocalizableString RemindingSubjectCaption {
			get {
				return _remindingSubjectCaption ?? (_remindingSubjectCaption = GetLocalizableString("8050561b65ac430ebd4472ca90da7c5a",
						 "Parameters.RemindingSubjectCaption.Value"));
			}
			set {
				_remindingSubjectCaption = value;
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
					SchemaElementUId = new Guid("74ffad96-8e68-4020-a9f5-20133075d3d6"),
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
					SchemaElementUId = new Guid("b32b0f8e-745e-4035-9a1c-0388e5f58a97"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptCalculateFact;
		public ProcessScriptTask ScriptCalculateFact {
			get {
				return _scriptCalculateFact ?? (_scriptCalculateFact = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptCalculateFact",
					SchemaElementUId = new Guid("6a213519-968a-4263-8368-e11ce64b8e7b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptCalculateFactExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ScriptCalculateFact.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptCalculateFact };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptCalculateFact", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ScriptCalculateFact":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CurrentUserContactId")) {
				writer.WriteValue("CurrentUserContactId", CurrentUserContactId, Guid.Empty);
			}
			if (!HasMapping("ForecastId")) {
				writer.WriteValue("ForecastId", ForecastId, Guid.Empty);
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
			MetaPathParameterValues.Add("99c4f988-d8e3-4f37-bf52-4fce005d8f98", () => CurrentUserContactId);
			MetaPathParameterValues.Add("ed0a7641-5e95-46e5-98fb-fdd4783a0fda", () => ForecastId);
			MetaPathParameterValues.Add("2a873ba5-e10b-4b12-9308-5aad57f4a73d", () => RemindingDescription);
			MetaPathParameterValues.Add("0868024e-f0d0-4a64-bf9f-a60b9cfb78ea", () => RemindingSubjectCaption);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CurrentUserContactId":
					if (!hasValueToRead) break;
					CurrentUserContactId = reader.GetValue<System.Guid>();
				break;
				case "ForecastId":
					if (!hasValueToRead) break;
					ForecastId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptCalculateFactExecute(ProcessExecutingContext context) {
			if (ForecastId != Guid.Empty) {
				StoredProcedure storedProcedure = new StoredProcedure(UserConnection, "tsp_RecalculateForecastFact")
					.WithParameter("ForecastId", ForecastId) as StoredProcedure;
				storedProcedure.PackageName = "tspkg_Forecast";
				if (CurrentUserContactId != Guid.Empty) {
					storedProcedure.WithParameter("CurrentUserContactId", CurrentUserContactId);
				}
				storedProcedure.Execute();
				CreateReminding();
			}
			return true;
		}

			
			public virtual void CreateReminding() {
			if (ForecastId == Guid.Empty || CurrentUserContactId == Guid.Empty) {
				return;
			}
			string forecastName = string.Empty;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Forecast");
			string columnName = esq.AddColumn("Name").Name;
			IEntitySchemaQueryFilterItem filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				esq.RootSchema.GetPrimaryColumnName(), ForecastId);
			esq.Filters.Add(filter);
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				forecastName = entities[0].GetTypedColumnValue<string>(columnName);
			}
			Reminding reminding = new Reminding(UserConnection);
			reminding.SetDefColumnValues();
			reminding.AuthorId = UserConnection.CurrentUser.ContactId;
			reminding.SourceId = RemindingConsts.RemindingSourceAuthorId;
			reminding.ContactId = CurrentUserContactId;
			reminding.RemindTime = DateTime.UtcNow;
			reminding.Description = string.Format(RemindingDescription, forecastName);
			reminding.SubjectCaption = RemindingSubjectCaption;
			reminding.SubjectId = ForecastId;
			reminding.SysEntitySchemaId = ForecastConsts.ForecastEntitySchemaUId;
			reminding.Save();
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
			var cloneItem = (CalcForecastFactPotentialProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

