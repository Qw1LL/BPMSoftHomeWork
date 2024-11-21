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

	#region Class: RunSendEmailToCaseGroupV2Schema

	/// <exclude/>
	public class RunSendEmailToCaseGroupV2Schema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public RunSendEmailToCaseGroupV2Schema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public RunSendEmailToCaseGroupV2Schema(RunSendEmailToCaseGroupV2Schema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "RunSendEmailToCaseGroupV2";
			UId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7");
			CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.7.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"Business process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			Version = 1;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7");
			Version = 1;
			PackageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCaseRecordIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("02541d56-c300-4b56-b7b9-a795a2af3a8e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Name = @"CaseRecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{3c1a583e-579d-4272-8c0c-cb74582f81f0}].[Parameter:{bcf4067c-cafc-4056-b29f-1afecb12a005}]#]  == Guid.Empty ? [#[IsOwnerSchema:false].[IsSchema:false].[Element:{5f24a920-e8d6-4e2b-ab95-9606f938e9ce}].[Parameter:{387361b5-5452-454b-89f5-1cd99a230829}]#] : [#[IsOwnerSchema:false].[IsSchema:false].[Element:{3c1a583e-579d-4272-8c0c-cb74582f81f0}].[Parameter:{bcf4067c-cafc-4056-b29f-1afecb12a005}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCaseRecordIdParameter());
		}

		protected virtual void InitializeStartSignal1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bcf4067c-cafc-4056-b29f-1afecb12a005"),
				ContainerUId = new Guid("3c1a583e-579d-4272-8c0c-cb74582f81f0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3c1a583e-579d-4272-8c0c-cb74582f81f0"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7cc92fc9-fece-47af-9bf1-99d8b3ec74eb"),
				ContainerUId = new Guid("3c1a583e-579d-4272-8c0c-cb74582f81f0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3c1a583e-579d-4272-8c0c-cb74582f81f0"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
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

		protected virtual void InitializeStartSignal2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("387361b5-5452-454b-89f5-1cd99a230829"),
				ContainerUId = new Guid("5f24a920-e8d6-4e2b-ab95-9606f938e9ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("5f24a920-e8d6-4e2b-ab95-9606f938e9ce"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fbbbcb2e-769d-4c62-aa1b-04440ddcd118"),
				ContainerUId = new Guid("5f24a920-e8d6-4e2b-ab95-9606f938e9ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("5f24a920-e8d6-4e2b-ab95-9606f938e9ce"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
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
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaStartSignalEvent startsignal1 = CreateStartSignal1StartSignalEvent();
			FlowElements.Add(startsignal1);
			ProcessSchemaStartSignalEvent startsignal2 = CreateStartSignal2StartSignalEvent();
			FlowElements.Add(startsignal2);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaScriptTask runprocess = CreateRunProcessScriptTask();
			FlowElements.Add(runprocess);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("14ab0ad1-8660-4bb3-8424-564ccb990427"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3c1a583e-579d-4272-8c0c-cb74582f81f0"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("729349f8-3eae-4a71-b2b3-d27ffe76beef"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(185, 127));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("bc83b551-12cb-4fba-accd-964617644676"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5f24a920-e8d6-4e2b-ab95-9606f938e9ce"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("729349f8-3eae-4a71-b2b3-d27ffe76beef"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(185, 267));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("930315a5-ede8-41f0-822f-7abd90adfb85"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				SequenceFlowEndPointPosition = new Point(280, 194),
				SequenceFlowStartPointPosition = new Point(212, 194),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("729349f8-3eae-4a71-b2b3-d27ffe76beef"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6b467a14-3688-4459-af56-2285cc0165d9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("f937c722-64ff-4561-ab8b-c5f114957735"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				SequenceFlowEndPointPosition = new Point(438, 194),
				SequenceFlowStartPointPosition = new Point(349, 194),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6b467a14-3688-4459-af56-2285cc0165d9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2d3139b5-6a1a-4db2-acb1-ecb5cfa443cb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("8c91975d-2cb4-4229-8b2b-8c71b0e9324c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("db57a53e-48a6-4c67-873b-dbda1884c1fa"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8c91975d-2cb4-4229-8b2b-8c71b0e9324c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("2d3139b5-6a1a-4db2-acb1-ecb5cfa443cb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("db57a53e-48a6-4c67-873b-dbda1884c1fa"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Name = @"Terminate1",
				Position = new Point(438, 180),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal1StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("3c1a583e-579d-4272-8c0c-cb74582f81f0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("db57a53e-48a6-4c67-873b-dbda1884c1fa"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Inserted,
				HasEntityColumnChange = false,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Name = @"StartSignal1",
				NewEntityChangedColumns = false,
				Position = new Point(77, 113),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			InitializeStartSignal1Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal2StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("5f24a920-e8d6-4e2b-ab95-9606f938e9ce"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("db57a53e-48a6-4c67-873b-dbda1884c1fa"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Name = @"StartSignal2",
				NewEntityChangedColumns = false,
				Position = new Point(77, 253),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaStartSignalEvent.EntityChangedColumns.Add("70620d00-e4ea-48d1-9fdc-4572fcd8d41b");
			schemaStartSignalEvent.EntityChangedColumns.Add("9147230c-ab53-4eb4-b0b4-ac78be6f8326");
			InitializeStartSignal2Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("729349f8-3eae-4a71-b2b3-d27ffe76beef"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("db57a53e-48a6-4c67-873b-dbda1884c1fa"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Name = @"ExclusiveGateway1",
				Position = new Point(157, 166),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaScriptTask CreateRunProcessScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("6b467a14-3688-4459-af56-2285cc0165d9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("db57a53e-48a6-4c67-873b-dbda1884c1fa"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"),
				Name = @"RunProcess",
				Position = new Point(280, 166),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,86,93,111,219,54,20,125,118,128,252,7,86,79,50,224,8,89,230,22,70,179,100,112,20,59,243,48,119,94,148,180,15,69,31,56,233,198,33,32,81,42,73,117,51,218,252,247,93,126,200,162,100,53,219,144,0,14,36,222,123,15,15,207,253,160,238,37,136,184,228,28,82,197,74,78,234,238,235,5,185,239,44,156,31,31,177,7,18,118,189,162,184,22,2,184,210,174,81,187,124,183,171,128,92,88,4,253,28,37,201,102,76,190,30,31,141,14,54,233,225,205,171,202,123,75,118,82,65,113,192,227,233,248,232,11,21,68,2,207,64,44,10,202,114,4,186,218,172,147,242,65,33,11,1,154,202,3,219,214,130,54,48,9,40,197,248,86,70,55,160,222,211,188,134,159,164,18,184,112,217,59,208,132,32,201,32,169,171,170,20,42,1,241,133,165,96,118,8,38,196,70,68,139,162,82,187,241,176,28,136,190,146,75,160,170,22,176,224,244,207,28,178,48,48,241,107,144,146,110,97,93,231,138,253,70,249,182,198,151,96,76,190,125,35,47,130,120,127,22,140,173,178,90,145,148,74,184,133,180,20,217,42,67,73,194,68,81,60,5,219,114,154,255,16,237,13,175,46,200,77,205,50,119,16,12,29,253,76,134,61,181,237,173,111,59,219,219,206,221,150,32,63,227,78,28,254,34,11,174,152,218,37,233,35,20,244,143,26,196,174,47,142,239,176,166,28,217,139,9,9,98,228,28,104,57,71,8,21,205,179,44,46,243,186,224,97,112,35,202,186,178,150,230,108,22,1,247,211,174,40,148,125,63,72,161,47,131,137,215,153,242,226,81,0,94,231,185,213,205,128,211,172,96,252,158,51,181,120,233,113,176,214,230,13,152,37,63,242,193,35,44,102,99,191,101,219,71,37,113,175,7,154,75,48,126,70,78,157,104,171,192,59,90,96,19,117,168,249,242,32,19,69,83,21,217,234,28,71,218,125,15,179,213,218,153,26,104,143,173,5,211,205,232,16,108,23,232,66,184,116,90,175,178,33,194,75,150,43,16,82,111,29,118,12,177,192,34,5,107,254,192,212,227,134,10,164,160,125,67,187,24,151,69,69,5,147,118,30,68,139,207,53,205,81,161,143,40,145,110,233,21,191,45,115,120,235,222,62,233,46,213,11,216,104,142,253,216,178,49,201,47,243,124,63,50,58,44,246,85,16,239,93,122,137,106,81,4,72,236,29,68,112,157,252,107,201,80,200,115,220,177,197,143,18,208,79,33,74,127,73,96,80,179,102,114,244,114,53,118,124,117,177,189,114,59,172,228,59,44,180,223,197,135,71,166,32,169,104,10,161,37,225,154,214,75,250,29,20,85,142,130,38,102,170,185,34,108,135,154,63,207,76,202,181,228,107,154,138,82,186,226,27,60,246,33,190,169,138,97,92,221,138,184,34,21,142,73,157,130,54,196,98,189,120,224,181,211,10,255,6,78,141,226,243,204,68,47,69,89,220,149,161,223,201,147,254,57,38,254,13,48,113,217,117,199,30,9,64,74,156,40,81,219,174,24,61,17,192,70,107,54,63,148,93,225,189,241,239,170,119,220,135,21,63,196,110,142,255,11,228,213,127,73,237,112,92,79,140,239,239,157,187,48,147,233,103,136,232,228,53,43,171,44,236,169,235,35,42,183,218,206,223,3,45,76,167,184,133,62,212,196,163,212,192,254,255,236,119,73,68,27,193,10,42,118,94,99,62,87,15,248,201,96,255,225,207,171,4,61,254,76,148,213,189,212,29,96,74,223,37,73,219,113,212,190,153,45,95,207,167,139,147,249,245,233,155,147,105,60,251,241,100,54,139,167,39,167,211,211,235,179,233,236,116,57,143,175,218,139,170,176,237,120,248,109,179,17,101,138,77,209,185,49,154,160,202,183,97,168,3,49,253,133,13,73,121,10,87,187,123,204,210,16,217,253,29,215,65,137,92,63,122,215,156,179,47,248,150,113,248,46,65,107,62,239,7,253,13,105,141,153,198,176,14,204,62,202,217,77,220,53,51,136,152,31,55,45,155,175,167,75,130,87,130,189,38,76,206,244,13,168,133,126,38,192,118,236,71,243,161,208,84,67,240,9,227,252,133,232,174,76,140,127,104,62,104,158,12,139,30,243,200,62,64,79,38,84,117,210,103,101,20,213,165,114,124,228,15,146,127,0,144,11,127,42,50,11,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("09015002-8c72-44a0-87aa-300725e2353a"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("4bc22559-3627-4ea2-9aee-a2721c12aafa"),
				Name = "System.Text",
				Alias = "",
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("60d0ddb8-902b-457f-9428-6aa42c5240aa"),
				Name = "System",
				Alias = "",
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7abde226-b990-4e5b-9337-0c55786d6c6f"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new RunSendEmailToCaseGroupV2(userConnection);
		}

		public override object Clone() {
			return new RunSendEmailToCaseGroupV2Schema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3081ee20-1fd1-40af-a743-b2af923716b7"));
		}

		#endregion

	}

	#endregion

	#region Class: RunSendEmailToCaseGroupV2

	/// <exclude/>
	public class RunSendEmailToCaseGroupV2 : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, RunSendEmailToCaseGroupV2 process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public RunSendEmailToCaseGroupV2(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RunSendEmailToCaseGroupV2";
			SchemaUId = new Guid("3081ee20-1fd1-40af-a743-b2af923716b7");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_caseRecordId = () => { return (Guid)((StartSignal1.RecordId)  == Guid.Empty ? (StartSignal2.RecordId) : (StartSignal1.RecordId)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3081ee20-1fd1-40af-a743-b2af923716b7");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: RunSendEmailToCaseGroupV2, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: RunSendEmailToCaseGroupV2, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private ProcessTerminateEvent _terminate1;
		public ProcessTerminateEvent Terminate1 {
			get {
				return _terminate1 ?? (_terminate1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate1",
					SchemaElementUId = new Guid("2d3139b5-6a1a-4db2-acb1-ecb5cfa443cb"),
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
					SchemaElementUId = new Guid("3c1a583e-579d-4272-8c0c-cb74582f81f0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessStartSignalEvent _startSignal2;
		public ProcessStartSignalEvent StartSignal2 {
			get {
				return _startSignal2 ?? (_startSignal2 = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "StartSignal2",
					SerializeToDB = false,
					IsLogging = true,
					SchemaElementUId = new Guid("5f24a920-e8d6-4e2b-ab95-9606f938e9ce"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("729349f8-3eae-4a71-b2b3-d27ffe76beef"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
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
					SchemaElementUId = new Guid("6b467a14-3688-4459-af56-2285cc0165d9"),
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
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[StartSignal1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal1 };
			FlowElements[StartSignal2.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal2 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[RunProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { RunProcess };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Terminate1":
						CompleteProcess();
						break;
					case "StartSignal1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "StartSignal2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("RunProcess", e.Context.SenderName));
						break;
					case "RunProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
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
			MetaPathParameterValues.Add("02541d56-c300-4b56-b7b9-a795a2af3a8e", () => CaseRecordId);
			MetaPathParameterValues.Add("bcf4067c-cafc-4056-b29f-1afecb12a005", () => StartSignal1.RecordId);
			MetaPathParameterValues.Add("7cc92fc9-fece-47af-9bf1-99d8b3ec74eb", () => StartSignal1.EntitySchemaUId);
			MetaPathParameterValues.Add("387361b5-5452-454b-89f5-1cd99a230829", () => StartSignal2.RecordId);
			MetaPathParameterValues.Add("fbbbcb2e-769d-4c62-aa1b-04440ddcd118", () => StartSignal2.EntitySchemaUId);
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
			UserConnection userConnection = UserConnection;
			if (userConnection.CurrentUser.ConnectionType == UserType.SSP) {
				userConnection = userConnection.AppConnection.SystemUserConnection;
			}
			var senderEmail = BPMSoft.Core.Configuration.SysSettings.GetValue<string>(userConnection, 
				"SupportServiceEmail", string.Empty);
			if (userConnection.GetIsFeatureEnabled("EmailMessageMultiLanguage") || userConnection.GetIsFeatureEnabled("EmailMessageMultiLanguageV2")) {
				var caseRecordId = (StartSignal1.RecordId != Guid.Empty)
					? StartSignal1.RecordId 
					: StartSignal2.RecordId;
				var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "Case");
				esq.AddColumn("Group");
				var caseEntity = esq.GetEntity(userConnection, caseRecordId);
				if (caseEntity != null) {
					var adminUnitEsq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "SysAdminUnit");
					adminUnitEsq.UseAdminRights = false;
					var emailColumnName = adminUnitEsq.AddColumn("Contact.Email").Name;
					var groupId = caseEntity.GetTypedColumnValue<Guid>("GroupId");
					adminUnitEsq.Filters.Add(adminUnitEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "[SysUserInRole:SysUser].SysRole", groupId));
					var collection = adminUnitEsq.GetEntityCollection(userConnection);
					var result = string.Join(";", collection.Select(e => e.GetTypedColumnValue<string>(emailColumnName)));
					if (!string.IsNullOrWhiteSpace(result)) {
						var emailTemplateSender = new BPMSoft.Configuration.EmailWithMacrosManager(userConnection);
						var emailTemplateId = BPMSoft.Configuration.CaseConsts.GroupTemplateId;
						if (userConnection.GetIsFeatureEnabled("EmailMessageMultiLanguageV2")) {
							emailTemplateSender.SendEmailFromTo(caseRecordId, emailTemplateId, senderEmail, result);
							return true;
						} else {
							var emailTemplateStore = new BPMSoft.Configuration.EmailTemplateStore(userConnection);
							var emailTemplateLanguageHelper = new BPMSoft.Configuration.EmailTemplateLanguageHelper(caseRecordId, userConnection);
							var languageId = emailTemplateLanguageHelper.GetLanguageId(emailTemplateId);
							var templateEntity = emailTemplateStore.GetTemplate(emailTemplateId, languageId);
							emailTemplateSender.SendEmailFromTo(caseRecordId, templateEntity.PrimaryColumnValue, senderEmail, result);
						}
					}
				}
			} else {
				Guid sendEmailToCaseGroup = new Guid("C68F5A4E-AD06-4C83-88C4-040D2480FACB");
				var manager = userConnection.ProcessSchemaManager;
				var processSchema = manager.GetInstanceByUId(sendEmailToCaseGroup);
				if (processSchema.Enabled) {
					var processEngine = userConnection.ProcessEngine;
					var processExecutor = processEngine.ProcessExecutor;
					Dictionary<string, string> parameterValues = new Dictionary<string, string> {
						["CaseRecordId"] = CaseRecordId.ToString()
					};
					processExecutor.Execute(processSchema.UId, parameterValues);
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
			var cloneItem = (RunSendEmailToCaseGroupV2)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

