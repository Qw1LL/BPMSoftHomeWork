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
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: ClearObjectChangeLogProcessSchema

	/// <exclude/>
	public class ClearObjectChangeLogProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ClearObjectChangeLogProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ClearObjectChangeLogProcessSchema(ClearObjectChangeLogProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ClearObjectChangeLogProcess";
			UId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9");
			CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,82,203,78,196,48,12,60,131,196,63,68,61,165,210,170,63,0,139,180,84,128,144,120,119,23,14,136,67,104,76,55,144,38,197,73,139,42,196,191,99,147,101,65,229,210,202,246,120,50,99,187,67,51,168,8,226,180,55,250,225,81,156,66,92,162,170,95,65,87,245,26,90,21,100,46,62,246,118,119,6,133,2,194,155,152,11,7,239,226,216,69,19,199,132,184,233,1,71,185,10,128,165,119,14,234,104,188,43,254,2,46,148,83,13,224,76,100,119,239,231,190,185,122,122,33,80,200,18,239,14,53,46,116,107,220,173,105,214,49,16,255,179,178,1,168,242,185,79,159,127,15,149,222,246,173,19,225,59,179,58,211,155,120,206,226,138,133,222,196,50,163,82,150,51,3,231,79,140,141,128,129,235,146,227,18,129,44,167,236,189,137,235,107,133,170,5,134,200,148,44,125,219,41,52,193,187,229,216,65,113,252,214,43,59,99,181,89,53,134,123,143,175,161,83,53,100,51,49,177,189,45,21,103,58,207,127,13,144,42,155,32,2,56,97,128,157,178,20,154,247,20,50,153,229,55,13,66,236,241,183,185,168,128,193,18,196,252,16,152,131,101,110,188,223,41,219,195,1,175,243,80,78,198,84,92,146,205,60,47,150,126,129,168,70,201,212,159,108,107,111,183,235,159,172,169,197,96,48,146,87,49,120,163,69,5,78,223,2,237,70,27,215,200,16,145,126,162,133,16,104,157,105,123,219,106,5,56,0,174,162,177,73,95,154,240,182,124,52,94,163,175,169,115,226,141,110,162,180,160,48,221,68,185,86,174,1,58,145,13,152,230,251,243,26,11,253,2,224,76,134,94,170,2,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateEntitySchemaUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("26fa5f17-c6cd-4623-a163-2f48820e59d9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateChunkSizeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1b3af3d1-3495-4770-a9fc-c62235bec979"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"ChunkSize",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"500",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateChunkProcessingDelayParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4977bd75-708c-4914-8b07-bbd248542368"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"ChunkProcessingDelay",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"500",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateMaxDegreeOfParallelismParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4c37a499-b647-4d81-8556-a993a95d3fb3"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"MaxDegreeOfParallelism",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"2",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSuccessMessageForObjectsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("109d42aa-b651-4f3f-b885-db06517bd3b0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"SuccessMessageForObjects",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateFromDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("64e4e2c4-c386-4af0-bca1-f931ffdf45dd"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"FromDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected virtual ProcessSchemaParameter CreateEndDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("02685588-f8ca-4440-8250-15b2d3b51b93"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"EndDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSuccessMessageForOneObjectParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("504957be-b628-4a73-af72-b03a3f3996a5"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"SuccessMessageForOneObject",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateErrorMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a433e6b5-e02f-46b9-a11f-b4b74a05f3f5"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"ErrorMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateEntitySchemaUIdParameter());
			Parameters.Add(CreateChunkSizeParameter());
			Parameters.Add(CreateChunkProcessingDelayParameter());
			Parameters.Add(CreateMaxDegreeOfParallelismParameter());
			Parameters.Add(CreateSuccessMessageForObjectsParameter());
			Parameters.Add(CreateFromDateParameter());
			Parameters.Add(CreateEndDateParameter());
			Parameters.Add(CreateSuccessMessageForOneObjectParameter());
			Parameters.Add(CreateErrorMessageParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent startcleaningevent = CreateStartCleaningEventStartEvent();
			FlowElements.Add(startcleaningevent);
			ProcessSchemaTerminateEvent endcleaningevent = CreateEndCleaningEventTerminateEvent();
			FlowElements.Add(endcleaningevent);
			ProcessSchemaScriptTask clearchangelogscripttask = CreateClearChangeLogScriptTaskScriptTask();
			FlowElements.Add(clearchangelogscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("100803b7-baf5-4019-9582-bfa3746f14f8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("117f5545-db57-45ab-9b79-f24841f9295f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("54e03f6b-018e-4e79-9be4-c1a92091bcff"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("55b39004-9198-4410-bd5f-d54582ca10b6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("54e03f6b-018e-4e79-9be4-c1a92091bcff"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("cc285ab6-9731-496f-97c9-d5ec42c92035"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("e9e7a486-3d8f-4b22-b180-2398894c2841"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("16d6f549-e19f-492d-af27-7ad3c88986f9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e9e7a486-3d8f-4b22-b180-2398894c2841"),
				CreatedInOwnerSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartCleaningEventStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("117f5545-db57-45ab-9b79-f24841f9295f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("16d6f549-e19f-492d-af27-7ad3c88986f9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"StartCleaningEvent",
				Position = new Point(53, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = true
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateEndCleaningEventTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("cc285ab6-9731-496f-97c9-d5ec42c92035"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("16d6f549-e19f-492d-af27-7ad3c88986f9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"EndCleaningEvent",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateClearChangeLogScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("54e03f6b-018e-4e79-9be4-c1a92091bcff"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("16d6f549-e19f-492d-af27-7ad3c88986f9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"),
				Name = @"ClearChangeLogScriptTask",
				Position = new Point(299, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,84,77,111,219,48,12,61,39,64,254,131,224,147,13,4,254,1,203,218,0,75,220,162,192,178,6,75,123,42,118,208,100,198,214,106,75,5,37,183,245,138,254,247,81,86,236,196,118,10,20,216,201,16,201,247,248,241,72,63,115,100,160,172,180,245,78,228,80,242,251,155,148,93,48,155,75,19,95,131,253,122,93,201,244,50,12,146,126,68,16,45,102,211,103,66,238,81,151,107,110,225,4,225,158,119,178,4,66,93,29,188,93,56,168,212,189,217,249,240,196,123,187,104,145,115,149,193,119,157,173,10,224,10,144,96,10,94,216,106,96,14,59,174,123,3,184,210,74,129,176,82,43,98,236,27,130,200,49,15,89,227,85,94,169,199,157,252,219,43,75,42,75,248,206,21,124,140,220,162,22,96,140,84,217,26,10,94,127,64,50,136,58,207,183,225,175,107,200,16,224,118,191,229,200,139,2,10,105,202,49,227,249,184,134,211,233,245,240,139,153,86,41,67,54,99,145,242,178,146,242,243,204,117,233,13,113,82,62,217,154,252,114,207,194,209,10,92,48,71,229,99,34,246,54,155,78,142,156,68,65,197,220,33,23,143,144,122,140,9,93,246,201,40,199,149,198,146,219,163,68,222,76,61,236,42,225,6,178,241,0,10,187,253,253,135,100,50,94,164,119,6,133,129,113,90,167,255,161,197,183,209,218,190,187,10,252,154,29,29,27,174,136,223,237,206,231,215,36,78,198,4,45,119,161,179,12,82,95,44,145,158,73,229,114,220,40,99,185,18,240,173,166,194,134,195,253,239,73,41,240,249,131,104,222,171,39,254,193,75,104,198,55,155,182,119,181,36,126,142,118,11,40,181,187,236,246,98,157,194,41,236,121,85,216,176,141,141,216,146,117,143,101,164,170,162,96,95,58,196,226,148,148,46,185,163,236,174,250,179,140,224,1,68,104,177,30,136,236,230,144,112,145,135,166,89,195,203,209,95,32,118,95,108,220,243,211,222,230,199,154,154,21,154,236,232,253,19,74,169,82,154,99,120,152,183,95,46,193,173,200,89,152,188,10,120,114,146,51,42,212,149,209,135,140,165,72,16,53,30,132,240,139,58,177,57,234,23,63,114,4,91,161,98,22,43,88,252,3,250,74,44,194,87,5,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("81d242c0-9e1f-4163-bdb5-6fec8e0fde36"),
				Name = "BPMSoft.Common",
				Alias = "",
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("bc8d52c3-aa32-46e3-b866-46f89b82bd0e"),
				Name = "BPMSoft.Core.DB",
				Alias = "",
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("41de0eb7-ec82-48bb-8c08-d8ccc2832bef"),
				Name = "BPMSoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7c855e7c-512d-4e7f-b879-f6cfb471b27d"),
				Name = "BPMSoft.Core",
				Alias = "",
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("05be42a5-957c-4481-8da3-aefbf9fe66be"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("90f6f376-b70c-4991-9fdf-6a79419bae77"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8c3dd43e-9218-4323-b156-79d6eab16e55"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ClearObjectChangeLogProcess(userConnection);
		}

		public override object Clone() {
			return new ClearObjectChangeLogProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fc3af9e0-a16e-4002-861b-8940856017f9"));
		}

		#endregion

	}

	#endregion

	#region Class: ClearObjectChangeLogProcessMethodsWrapper

	/// <exclude/>
	public class ClearObjectChangeLogProcessMethodsWrapper : ProcessModel
	{

		public ClearObjectChangeLogProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ClearChangeLogScriptTaskExecute", ClearChangeLogScriptTaskExecute);
		}

		#region Methods: Private

		private bool ClearChangeLogScriptTaskExecute(ProcessExecutingContext context) {
			var entitySchemaUId = this.Get<Guid>("EntitySchemaUId");
			var fromDate= this.Get<DateTime>("FromDate");
			var endDate = this.Get<DateTime>("EndDate");
			var changeLogCleaner = new ChangeLogCleaner(this.Get<UserConnection>("UserConnection"));
			changeLogCleaner.ChunkSize = this.Get<int>("ChunkSize");
			changeLogCleaner.ChunkProcessingDelay = this.Get<int>("ChunkProcessingDelay");
			changeLogCleaner.MaxDegreeOfParallelism = this.Get<int>("MaxDegreeOfParallelism");
			Guid[] schemaUIds;
			string message = string.Empty;
			if (entitySchemaUId == Guid.Empty) {
				schemaUIds = GetTrackedSchemas();
				message = string.Format(this.Get<string>("SuccessMessageForObjects"));
			} else {
				schemaUIds = new Guid[] { entitySchemaUId };
				var entitySchemaManager = this.Get<UserConnection>("UserConnection").EntitySchemaManager;
				var loggedObject = entitySchemaManager.GetInstanceByUId(entitySchemaUId);
				message = string.Format(this.Get<string>("SuccessMessageForOneObject"), loggedObject.Name);
			}
			DateTime? startPeriod = fromDate == default(DateTime) ? (DateTime?)null : fromDate;
			DateTime? endPeriod = endDate == default(DateTime) ? (DateTime?)null : endDate;
			try {
				schemaUIds.ForEach(sUId => changeLogCleaner.Clear(sUId, startPeriod, endPeriod));
				SendReminding(message);
			} catch (Exception e) {
				SendReminding(this.Get<string>("ErrorMessage"));
				throw;
			}
			return true;
		}

			private Guid[] GetTrackedSchemas() {
				var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "VwLogObjects") {
					UseAdminRights = false
				};
				EntitySchemaQueryColumn schemaUIdColumn = esq.AddColumn("UId");
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"SysWorkspace", UserConnection.Workspace.Id));
				EntityCollection entities = esq.GetEntityCollection(UserConnection);
				return entities.Select(e =>e.GetTypedColumnValue<Guid>(schemaUIdColumn.Name)).ToArray();
			}
					
			public virtual void SendReminding(string message) {
				RemindingServerUtilities.CreateRemindingByProcess(UserConnection, "ClearObjectChangeLogProcess", message);
			}

		#endregion

	}

	#endregion

	#region Class: ClearObjectChangeLogProcess

	/// <exclude/>
	public class ClearObjectChangeLogProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ClearObjectChangeLogProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ClearObjectChangeLogProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ClearObjectChangeLogProcess";
			SchemaUId = new Guid("fc3af9e0-a16e-4002-861b-8940856017f9");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new ClearObjectChangeLogProcessMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fc3af9e0-a16e-4002-861b-8940856017f9");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ClearObjectChangeLogProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ClearObjectChangeLogProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private string _successMessageForObjects;
		public virtual string SuccessMessageForObjects {
			get {
				return _successMessageForObjects ?? (_successMessageForObjects = GetLocalizableString("fc3af9e0a16e4002861b8940856017f9",
						 "Parameters.SuccessMessageForObjects.Value"));
			}
			set {
				_successMessageForObjects = value;
			}
		}

		public virtual DateTime FromDate {
			get;
			set;
		}

		public virtual DateTime EndDate {
			get;
			set;
		}

		private string _successMessageForOneObject;
		public virtual string SuccessMessageForOneObject {
			get {
				return _successMessageForOneObject ?? (_successMessageForOneObject = GetLocalizableString("fc3af9e0a16e4002861b8940856017f9",
						 "Parameters.SuccessMessageForOneObject.Value"));
			}
			set {
				_successMessageForOneObject = value;
			}
		}

		private string _errorMessage;
		public virtual string ErrorMessage {
			get {
				return _errorMessage ?? (_errorMessage = GetLocalizableString("fc3af9e0a16e4002861b8940856017f9",
						 "Parameters.ErrorMessage.Value"));
			}
			set {
				_errorMessage = value;
			}
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _startCleaningEvent;
		public ProcessFlowElement StartCleaningEvent {
			get {
				return _startCleaningEvent ?? (_startCleaningEvent = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartCleaningEvent",
					SchemaElementUId = new Guid("117f5545-db57-45ab-9b79-f24841f9295f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessTerminateEvent _endCleaningEvent;
		public ProcessTerminateEvent EndCleaningEvent {
			get {
				return _endCleaningEvent ?? (_endCleaningEvent = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "EndCleaningEvent",
					SchemaElementUId = new Guid("cc285ab6-9731-496f-97c9-d5ec42c92035"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _clearChangeLogScriptTask;
		public ProcessScriptTask ClearChangeLogScriptTask {
			get {
				return _clearChangeLogScriptTask ?? (_clearChangeLogScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ClearChangeLogScriptTask",
					SchemaElementUId = new Guid("54e03f6b-018e-4e79-9be4-c1a92091bcff"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ClearChangeLogScriptTaskExecute"),
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartCleaningEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { StartCleaningEvent };
			FlowElements[EndCleaningEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { EndCleaningEvent };
			FlowElements[ClearChangeLogScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ClearChangeLogScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartCleaningEvent":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearChangeLogScriptTask", e.Context.SenderName));
						break;
					case "EndCleaningEvent":
						CompleteProcess();
						break;
					case "ClearChangeLogScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EndCleaningEvent", e.Context.SenderName));
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
			if (!HasMapping("SuccessMessageForObjects")) {
				writer.WriteValue("SuccessMessageForObjects", SuccessMessageForObjects, null);
			}
			if (!HasMapping("FromDate")) {
				writer.WriteValue("FromDate", FromDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("EndDate")) {
				writer.WriteValue("EndDate", EndDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("SuccessMessageForOneObject")) {
				writer.WriteValue("SuccessMessageForOneObject", SuccessMessageForOneObject, null);
			}
			if (!HasMapping("ErrorMessage")) {
				writer.WriteValue("ErrorMessage", ErrorMessage, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartCleaningEvent", string.Empty));
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
			MetaPathParameterValues.Add("26fa5f17-c6cd-4623-a163-2f48820e59d9", () => EntitySchemaUId);
			MetaPathParameterValues.Add("1b3af3d1-3495-4770-a9fc-c62235bec979", () => ChunkSize);
			MetaPathParameterValues.Add("4977bd75-708c-4914-8b07-bbd248542368", () => ChunkProcessingDelay);
			MetaPathParameterValues.Add("4c37a499-b647-4d81-8556-a993a95d3fb3", () => MaxDegreeOfParallelism);
			MetaPathParameterValues.Add("109d42aa-b651-4f3f-b885-db06517bd3b0", () => SuccessMessageForObjects);
			MetaPathParameterValues.Add("64e4e2c4-c386-4af0-bca1-f931ffdf45dd", () => FromDate);
			MetaPathParameterValues.Add("02685588-f8ca-4440-8250-15b2d3b51b93", () => EndDate);
			MetaPathParameterValues.Add("504957be-b628-4a73-af72-b03a3f3996a5", () => SuccessMessageForOneObject);
			MetaPathParameterValues.Add("a433e6b5-e02f-46b9-a11f-b4b74a05f3f5", () => ErrorMessage);
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
				case "SuccessMessageForObjects":
					if (!hasValueToRead) break;
					SuccessMessageForObjects = reader.GetValue<System.String>();
				break;
				case "FromDate":
					if (!hasValueToRead) break;
					FromDate = reader.GetValue<System.DateTime>();
				break;
				case "EndDate":
					if (!hasValueToRead) break;
					EndDate = reader.GetValue<System.DateTime>();
				break;
				case "SuccessMessageForOneObject":
					if (!hasValueToRead) break;
					SuccessMessageForOneObject = reader.GetValue<System.String>();
				break;
				case "ErrorMessage":
					if (!hasValueToRead) break;
					ErrorMessage = reader.GetValue<System.String>();
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
			var cloneItem = (ClearObjectChangeLogProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

