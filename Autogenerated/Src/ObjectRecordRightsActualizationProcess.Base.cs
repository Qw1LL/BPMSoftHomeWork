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

	#region Class: ObjectRecordRightsActualizationProcessSchema

	/// <exclude/>
	public class ObjectRecordRightsActualizationProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ObjectRecordRightsActualizationProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ObjectRecordRightsActualizationProcessSchema(ObjectRecordRightsActualizationProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ObjectRecordRightsActualizationProcess";
			UId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301");
			CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = null;
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
			UseSystemSecurityContext = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,61,142,81,10,194,48,16,68,191,45,244,14,161,95,21,138,23,240,75,123,0,37,165,7,72,147,37,174,180,155,178,217,6,84,188,187,41,72,190,102,96,230,49,179,110,211,140,86,37,100,217,204,172,82,64,167,6,32,167,97,65,114,72,190,141,194,89,212,2,49,26,15,71,245,169,171,67,73,7,224,4,60,10,206,40,8,241,212,51,24,129,18,95,95,119,14,54,147,237,24,129,251,64,4,86,48,80,167,154,219,244,204,94,131,13,236,52,250,135,196,139,221,47,224,219,236,141,63,215,116,101,248,92,87,223,31,83,176,29,62,174,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = true;
		}

		protected virtual ProcessSchemaParameter CreateEntitySchemaUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a5251af1-5a5f-4a1a-b2df-fa3127bd8a6d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateChunkSizeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3a99f3cf-49f7-4bb2-8733-3f5ae25c02a6"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"ChunkSize",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"500",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateChunkProcessingDelayParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("63f8392a-72cc-4846-a89e-83ae75644a3c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"ChunkProcessingDelay",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"500",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateMaxDegreeOfParallelismParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9975462c-580e-4b2b-93b8-5e7bd11a190c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"MaxDegreeOfParallelism",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"2",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateActualizationSuccessMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a9fa7b5b-d4bb-4388-a77e-49064d132625"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"ActualizationSuccessMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateErrorMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6354a50a-69fc-4571-acc6-d1383701816d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"ErrorMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateGeneralErrorMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4153df13-3f82-47fc-b18f-281fe0e47ae6"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"GeneralErrorMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateEntitySchemaUIdParameter());
			Parameters.Add(CreateChunkSizeParameter());
			Parameters.Add(CreateChunkProcessingDelayParameter());
			Parameters.Add(CreateMaxDegreeOfParallelismParameter());
			Parameters.Add(CreateActualizationSuccessMessageParameter());
			Parameters.Add(CreateErrorMessageParameter());
			Parameters.Add(CreateGeneralErrorMessageParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaTerminateEvent terminator = CreateTerminatorTerminateEvent();
			FlowElements.Add(terminator);
			ProcessSchemaScriptTask actualizationexecutionscripttask = CreateActualizationExecutionScriptTaskScriptTask();
			FlowElements.Add(actualizationexecutionscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("bf247216-8908-4312-80d9-ccfc78d89f9c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("be6f6b49-189f-4148-bff8-2c8c58642b76"),
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c7a5f5a7-e453-44de-91ea-22c336bb64a1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dfc394f8-650b-4d0a-a8cf-51caf2020168"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("da8527a2-5a1a-424e-9051-2e16259681f7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("be6f6b49-189f-4148-bff8-2c8c58642b76"),
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dfc394f8-650b-4d0a-a8cf-51caf2020168"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("88ba5837-c741-4192-be87-98750b79328e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("f4d04a01-c7d4-4bdd-a1c6-e8b41cb0d318"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("be6f6b49-189f-4148-bff8-2c8c58642b76"),
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("c6e7cba3-06af-4f9e-ad67-421c556de0e7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f4d04a01-c7d4-4bdd-a1c6-e8b41cb0d318"),
				CreatedInOwnerSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				CreatedInPackageId = new Guid("be6f6b49-189f-4148-bff8-2c8c58642b76"),
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("c7a5f5a7-e453-44de-91ea-22c336bb64a1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c6e7cba3-06af-4f9e-ad67-421c556de0e7"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("be6f6b49-189f-4148-bff8-2c8c58642b76"),
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"StartEvent1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = true
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminatorTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("88ba5837-c741-4192-be87-98750b79328e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c6e7cba3-06af-4f9e-ad67-421c556de0e7"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("be6f6b49-189f-4148-bff8-2c8c58642b76"),
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"Terminator",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateActualizationExecutionScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("dfc394f8-650b-4d0a-a8cf-51caf2020168"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c6e7cba3-06af-4f9e-ad67-421c556de0e7"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("be6f6b49-189f-4148-bff8-2c8c58642b76"),
				CreatedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"),
				Name = @"ActualizationExecutionScriptTask",
				Position = new Point(304, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,93,115,155,48,16,124,54,191,130,225,73,204,116,244,3,66,63,166,117,176,199,15,182,51,166,153,62,43,112,49,106,37,225,74,194,9,237,228,191,247,132,48,1,76,154,55,155,187,221,189,189,91,157,153,14,65,89,110,155,44,47,65,178,251,77,17,126,10,109,201,13,93,131,253,184,174,121,241,153,68,233,184,35,138,147,224,140,192,218,128,94,86,74,65,110,121,165,134,184,251,81,5,25,198,31,46,4,44,183,53,19,252,15,104,4,43,120,10,247,15,63,177,227,0,121,165,139,3,63,150,214,124,237,91,200,88,14,41,94,225,116,89,214,234,87,134,63,135,83,112,101,81,186,47,69,51,144,59,93,229,96,12,87,199,91,16,172,121,3,61,233,154,16,109,217,243,45,28,53,192,254,241,142,105,38,4,8,110,228,53,213,124,159,35,227,143,33,153,92,129,166,191,145,223,16,244,207,207,88,64,227,198,26,122,249,59,185,72,28,135,127,131,69,183,210,182,33,3,129,123,90,113,97,251,229,250,79,100,124,138,152,46,43,81,75,69,34,119,87,186,210,149,36,209,69,37,138,131,197,130,254,40,65,3,137,190,55,39,104,123,54,102,87,217,118,60,226,177,212,217,145,128,74,211,113,83,201,184,112,64,63,35,51,221,16,73,176,24,44,208,155,241,87,223,20,147,201,231,12,37,193,75,155,159,225,206,182,76,177,99,139,24,231,164,99,31,53,117,233,43,36,87,220,88,205,44,20,62,121,136,158,225,116,55,220,160,31,166,114,248,214,160,149,233,177,240,132,72,131,241,152,227,220,225,106,156,143,235,10,117,165,36,176,186,113,215,27,44,164,15,253,140,80,123,101,137,105,196,201,144,214,235,210,85,165,37,179,164,79,156,255,140,161,187,80,49,183,139,172,206,93,142,183,30,29,197,31,222,154,215,233,100,160,138,3,96,185,64,38,210,41,98,225,37,204,153,205,203,144,164,207,57,156,218,151,15,109,252,186,21,128,214,149,238,36,230,125,59,5,159,162,93,45,196,94,167,242,100,27,226,178,246,229,93,63,233,128,253,127,6,144,236,230,245,1,246,240,53,40,192,167,55,102,185,50,59,180,224,170,182,212,213,147,11,157,6,91,107,21,90,93,67,242,15,149,179,31,70,59,5,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("bb926b70-8e92-4f36-94ed-dfe5dc28b2d5"),
				Name = "BPMSoft.Core",
				Alias = "",
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("896b9851-e42c-45a9-b833-b6ce2cb9410a"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("05699b3f-cd69-4cf9-b85e-834319913046"),
				Name = "BPMSoft.Common",
				Alias = "",
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ObjectRecordRightsActualizationProcess(userConnection);
		}

		public override object Clone() {
			return new ObjectRecordRightsActualizationProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301"));
		}

		#endregion

	}

	#endregion

	#region Class: ObjectRecordRightsActualizationProcessMethodsWrapper

	/// <exclude/>
	public class ObjectRecordRightsActualizationProcessMethodsWrapper : ProcessModel
	{

		public ObjectRecordRightsActualizationProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ActualizationExecutionScriptTaskExecute", ActualizationExecutionScriptTaskExecute);
		}

		#region Methods: Private

		private bool ActualizationExecutionScriptTaskExecute(ProcessExecutingContext context) {
			var entitySchemaUId = this.Get<Guid>("EntitySchemaUId");
			var userConnection = this.Get<UserConnection>("UserConnection");
			var actualizer = new ObjectRecordRightsActualizer(userConnection);
			actualizer.ChunkSize = this.Get<int>("ChunkSize");
			actualizer.ChunkProcessingDelay = this.Get<int>("ChunkProcessingDelay");
			actualizer.MaxDegreeOfParallelism = this.Get<int>("MaxDegreeOfParallelism");
			if (entitySchemaUId.Equals(ActivityConsts.ActivityEntitySchemaUId)) {
				var activitySelectFilter = new Select(UserConnection).Column("Id").From("Activity")
					.Where("TypeId").IsNotEqual(Column.Parameter(ActivityConsts.EmailTypeUId)) as Select;
				actualizer.EntityRecordIdSelectFilter = activitySelectFilter;
			}
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var administratedObject = entitySchemaManager.GetInstanceByUId(entitySchemaUId);
			string administratedObjectName = administratedObject.Name;
			try {
				actualizer.Actualize(entitySchemaUId);
				var message = string.Format(this.Get<string>("ActualizationSuccessMessage"), administratedObjectName);
				SendReminding(message);
			} catch (Exception e) {
				string errorMessage = administratedObjectName.IsNotNullOrEmpty()
					? string.Format(this.Get<string>("ErrorMessage"), administratedObjectName)
					: this.Get<string>("GeneralErrorMessage");
				SendReminding(errorMessage);
				throw;
			}
			return true;
		}

			public virtual void SendReminding(string message) {
				RemindingServerUtilities.CreateRemindingByProcess(UserConnection, "ObjectRecordRightsActualizationProcess", message);
			}

		#endregion

	}

	#endregion

	#region Class: ObjectRecordRightsActualizationProcess

	/// <exclude/>
	public class ObjectRecordRightsActualizationProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ObjectRecordRightsActualizationProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ObjectRecordRightsActualizationProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ObjectRecordRightsActualizationProcess";
			SchemaUId = new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = true;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new ObjectRecordRightsActualizationProcessMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c949331e-753b-48bb-88a9-9e89d8c8a301");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ObjectRecordRightsActualizationProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ObjectRecordRightsActualizationProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid EntitySchemaUId {
			get;
			set;
		}

		private int _chunkSize = 500;
		public int ChunkSize {
			get {
				return _chunkSize;
			}
			set {
				_chunkSize = value;
			}
		}

		private int _chunkProcessingDelay = 500;
		public int ChunkProcessingDelay {
			get {
				return _chunkProcessingDelay;
			}
			set {
				_chunkProcessingDelay = value;
			}
		}

		private int _maxDegreeOfParallelism = 2;
		public int MaxDegreeOfParallelism {
			get {
				return _maxDegreeOfParallelism;
			}
			set {
				_maxDegreeOfParallelism = value;
			}
		}

		private string _actualizationSuccessMessage;
		public virtual string ActualizationSuccessMessage {
			get {
				return _actualizationSuccessMessage ?? (_actualizationSuccessMessage = GetLocalizableString("c949331e753b48bb88a99e89d8c8a301",
						 "Parameters.ActualizationSuccessMessage.Value"));
			}
			set {
				_actualizationSuccessMessage = value;
			}
		}

		private string _errorMessage;
		public virtual string ErrorMessage {
			get {
				return _errorMessage ?? (_errorMessage = GetLocalizableString("c949331e753b48bb88a99e89d8c8a301",
						 "Parameters.ErrorMessage.Value"));
			}
			set {
				_errorMessage = value;
			}
		}

		private string _generalErrorMessage;
		public virtual string GeneralErrorMessage {
			get {
				return _generalErrorMessage ?? (_generalErrorMessage = GetLocalizableString("c949331e753b48bb88a99e89d8c8a301",
						 "Parameters.GeneralErrorMessage.Value"));
			}
			set {
				_generalErrorMessage = value;
			}
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _startEvent1;
		public ProcessFlowElement StartEvent1 {
			get {
				return _startEvent1 ?? (_startEvent1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartEvent1",
					SchemaElementUId = new Guid("c7a5f5a7-e453-44de-91ea-22c336bb64a1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessTerminateEvent _terminator;
		public ProcessTerminateEvent Terminator {
			get {
				return _terminator ?? (_terminator = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminator",
					SchemaElementUId = new Guid("88ba5837-c741-4192-be87-98750b79328e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _actualizationExecutionScriptTask;
		public ProcessScriptTask ActualizationExecutionScriptTask {
			get {
				return _actualizationExecutionScriptTask ?? (_actualizationExecutionScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActualizationExecutionScriptTask",
					SchemaElementUId = new Guid("dfc394f8-650b-4d0a-a8cf-51caf2020168"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ActualizationExecutionScriptTaskExecute"),
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[Terminator.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminator };
			FlowElements[ActualizationExecutionScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActualizationExecutionScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ActualizationExecutionScriptTask", e.Context.SenderName));
						break;
					case "Terminator":
						CompleteProcess();
						break;
					case "ActualizationExecutionScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminator", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("EntitySchemaUId")) {
				writer.WriteValue("EntitySchemaUId", EntitySchemaUId, Guid.Empty);
			}
			if (!HasMapping("ChunkSize")) {
				writer.WriteValue("ChunkSize", ChunkSize, 0);
			}
			if (!HasMapping("ChunkProcessingDelay")) {
				writer.WriteValue("ChunkProcessingDelay", ChunkProcessingDelay, 0);
			}
			if (!HasMapping("MaxDegreeOfParallelism")) {
				writer.WriteValue("MaxDegreeOfParallelism", MaxDegreeOfParallelism, 0);
			}
			if (!HasMapping("ActualizationSuccessMessage")) {
				writer.WriteValue("ActualizationSuccessMessage", ActualizationSuccessMessage, null);
			}
			if (!HasMapping("ErrorMessage")) {
				writer.WriteValue("ErrorMessage", ErrorMessage, null);
			}
			if (!HasMapping("GeneralErrorMessage")) {
				writer.WriteValue("GeneralErrorMessage", GeneralErrorMessage, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartEvent1", string.Empty));
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
			MetaPathParameterValues.Add("a5251af1-5a5f-4a1a-b2df-fa3127bd8a6d", () => EntitySchemaUId);
			MetaPathParameterValues.Add("3a99f3cf-49f7-4bb2-8733-3f5ae25c02a6", () => ChunkSize);
			MetaPathParameterValues.Add("63f8392a-72cc-4846-a89e-83ae75644a3c", () => ChunkProcessingDelay);
			MetaPathParameterValues.Add("9975462c-580e-4b2b-93b8-5e7bd11a190c", () => MaxDegreeOfParallelism);
			MetaPathParameterValues.Add("a9fa7b5b-d4bb-4388-a77e-49064d132625", () => ActualizationSuccessMessage);
			MetaPathParameterValues.Add("6354a50a-69fc-4571-acc6-d1383701816d", () => ErrorMessage);
			MetaPathParameterValues.Add("4153df13-3f82-47fc-b18f-281fe0e47ae6", () => GeneralErrorMessage);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "EntitySchemaUId":
					if (!hasValueToRead) break;
					EntitySchemaUId = reader.GetValue<System.Guid>();
				break;
				case "ChunkSize":
					if (!hasValueToRead) break;
					ChunkSize = reader.GetValue<System.Int32>();
				break;
				case "ChunkProcessingDelay":
					if (!hasValueToRead) break;
					ChunkProcessingDelay = reader.GetValue<System.Int32>();
				break;
				case "MaxDegreeOfParallelism":
					if (!hasValueToRead) break;
					MaxDegreeOfParallelism = reader.GetValue<System.Int32>();
				break;
				case "ActualizationSuccessMessage":
					if (!hasValueToRead) break;
					ActualizationSuccessMessage = reader.GetValue<System.String>();
				break;
				case "ErrorMessage":
					if (!hasValueToRead) break;
					ErrorMessage = reader.GetValue<System.String>();
				break;
				case "GeneralErrorMessage":
					if (!hasValueToRead) break;
					GeneralErrorMessage = reader.GetValue<System.String>();
				break;
			}
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
			var cloneItem = (ObjectRecordRightsActualizationProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

