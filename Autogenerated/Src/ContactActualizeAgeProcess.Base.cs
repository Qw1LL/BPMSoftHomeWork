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

	#region Class: ContactActualizeAgeProcessSchema

	/// <exclude/>
	public class ContactActualizeAgeProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ContactActualizeAgeProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ContactActualizeAgeProcessSchema(ContactActualizeAgeProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ContactActualizeAgeProcess";
			UId = new Guid("51734939-e406-46f0-b832-0b87c66b860b");
			CreatedInPackageId = new Guid("42c464a9-9677-4bbd-86c1-308caea3de84");
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,77,142,65,10,194,64,12,69,215,10,222,33,116,85,161,244,2,226,162,138,184,21,135,30,96,156,134,33,208,102,74,38,29,168,226,221,157,138,20,87,159,228,255,228,253,113,122,244,228,32,145,232,100,123,72,129,58,48,200,221,29,7,226,142,216,151,81,37,11,12,24,163,245,184,135,215,110,187,73,86,64,190,137,11,43,233,12,71,88,15,12,74,66,105,149,122,82,194,88,95,81,87,239,52,223,36,184,252,169,108,35,202,57,48,163,83,10,92,65,145,7,181,78,27,183,244,160,39,54,30,127,217,162,90,225,135,204,254,231,214,198,38,44,151,245,251,3,125,53,58,143,201,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = true;
		}

		protected virtual ProcessSchemaParameter CreateDateToParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b403d6f6-7f5c-4d26-b4bc-805b4f694c85"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"DateTo",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#SysVariable.CurrentDate#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateIsActualizeAllRecordParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fe16a3ef-1f0f-4665-88c5-e32eeab3de81"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"IsActualizeAllRecord",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateChunkSizeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("937e4c8d-de77-41a7-8100-303ce5902401"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"ChunkSize",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"1000",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateMaxDegreeOfParallelismParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6cacdf95-a10b-4abb-a809-9f1339256952"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"MaxDegreeOfParallelism",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"11",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateChunkProcessingDelayParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d3f556eb-a542-44e9-b059-89922ff495a5"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"ChunkProcessingDelay",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"100",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateDateFromParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("248661d3-523b-4c99-a6ac-3187fcd2cd93"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"DateFrom",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#SysVariable.CurrentDate#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateStartNotificationTextParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fbf94615-803b-42f9-9293-0b97fab0b272"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"StartNotificationText",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateFinishNotificationTextParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7c7098d4-e2e3-4749-ae9e-11ed07c800d4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"FinishNotificationText",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateIsNeedToNotifyUserParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c03f934d-853f-4779-a622-4ff82931929d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.In,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"IsNeedToNotifyUser",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#BooleanValue.False#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateDateToParameter());
			Parameters.Add(CreateIsActualizeAllRecordParameter());
			Parameters.Add(CreateChunkSizeParameter());
			Parameters.Add(CreateMaxDegreeOfParallelismParameter());
			Parameters.Add(CreateChunkProcessingDelayParameter());
			Parameters.Add(CreateDateFromParameter());
			Parameters.Add(CreateStartNotificationTextParameter());
			Parameters.Add(CreateFinishNotificationTextParameter());
			Parameters.Add(CreateIsNeedToNotifyUserParameter());
		}

		protected virtual void InitializeUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dateFromParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b34f77a4-e54e-46de-a069-0bcfe764a736"),
				ContainerUId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Name = @"DateFrom",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Date")
			};
			dateFromParameter.SourceValue = new ProcessSchemaParameterValue(dateFromParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{248661d3-523b-4c99-a6ac-3187fcd2cd93}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(dateFromParameter);
			var dateToParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e7c313ff-1857-49aa-9358-c144d964ae24"),
				ContainerUId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Name = @"DateTo",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Date")
			};
			dateToParameter.SourceValue = new ProcessSchemaParameterValue(dateToParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{b403d6f6-7f5c-4d26-b4bc-805b4f694c85}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(dateToParameter);
			var isActualizeAllRecordParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ceb66de6-3b6e-4cea-9861-77504af540b2"),
				ContainerUId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Name = @"IsActualizeAllRecord",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isActualizeAllRecordParameter.SourceValue = new ProcessSchemaParameterValue(isActualizeAllRecordParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{fe16a3ef-1f0f-4665-88c5-e32eeab3de81}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(isActualizeAllRecordParameter);
			var chunkSizeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("289d0abb-34e1-4cfc-be1c-c507c2a25e4c"),
				ContainerUId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Name = @"ChunkSize",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			chunkSizeParameter.SourceValue = new ProcessSchemaParameterValue(chunkSizeParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{937e4c8d-de77-41a7-8100-303ce5902401}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(chunkSizeParameter);
			var maxDegreeOfParallelismParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("451283a2-401d-4f6d-84f3-90c19a8fd595"),
				ContainerUId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Name = @"MaxDegreeOfParallelism",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			maxDegreeOfParallelismParameter.SourceValue = new ProcessSchemaParameterValue(maxDegreeOfParallelismParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{6cacdf95-a10b-4abb-a809-9f1339256952}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(maxDegreeOfParallelismParameter);
			var chunkProcessingDelayParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a08573e-b182-4455-8409-c4d713313ca7"),
				ContainerUId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				Name = @"ChunkProcessingDelay",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			chunkProcessingDelayParameter.SourceValue = new ProcessSchemaParameterValue(chunkProcessingDelayParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d3f556eb-a542-44e9-b059-89922ff495a5}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(chunkProcessingDelayParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaUserTask usertask1 = CreateUserTask1UserTask();
			FlowElements.Add(usertask1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			ProcessSchemaScriptTask scripttask2 = CreateScriptTask2ScriptTask();
			FlowElements.Add(scripttask2);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow3ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("8fc5fdd5-82f4-4c2d-99c6-eef38b8643c0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				SequenceFlowEndPointPosition = new Point(121, 198),
				SequenceFlowStartPointPosition = new Point(77, 198),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("44c1b9de-897a-4c18-932d-521ef9b165db"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dda9367d-fcae-4606-a1cf-181d7eec920d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("dc381b75-6139-42f1-83d4-3c945a103614"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				SequenceFlowEndPointPosition = new Point(540, 198),
				SequenceFlowStartPointPosition = new Point(457, 198),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8fe0ebab-0981-4829-aaa5-3a875af8e7f9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("e6cbab46-f860-4854-b06f-66b07317f094"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				SequenceFlowEndPointPosition = new Point(388, 198),
				SequenceFlowStartPointPosition = new Point(323, 198),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a392565d-ffd5-491f-9203-9bd516aa43d1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("10f15526-5181-45a7-97d0-41a0c2533686"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				SequenceFlowEndPointPosition = new Point(825, 198),
				SequenceFlowStartPointPosition = new Point(770, 198),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4dcfda98-03bd-421b-b6fc-85ad84635e98"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("04e892ea-48ae-4646-a183-144d38a2f166"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("130182af-e308-4469-9f4c-3d33717d66d2"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{c03f934d-853f-4779-a622-4ff82931929d}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				SequenceFlowEndPointPosition = new Point(254, 198),
				SequenceFlowStartPointPosition = new Point(176, 198),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dda9367d-fcae-4606-a1cf-181d7eec920d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a392565d-ffd5-491f-9203-9bd516aa43d1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("91c8b87c-3e04-476c-abea-72bf5594a344"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				SequenceFlowEndPointPosition = new Point(423, 170),
				SequenceFlowStartPointPosition = new Point(149, 170),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dda9367d-fcae-4606-a1cf-181d7eec920d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(149, 128));
			schemaFlow.PolylinePointPositions.Add(new Point(423, 128));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow3",
				UId = new Guid("a2bb631e-97ad-4eb9-8abf-3f0163ff9a78"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{c03f934d-853f-4779-a622-4ff82931929d}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				SequenceFlowEndPointPosition = new Point(701, 198),
				SequenceFlowStartPointPosition = new Point(595, 198),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8fe0ebab-0981-4829-aaa5-3a875af8e7f9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4dcfda98-03bd-421b-b6fc-85ad84635e98"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("36e4d1d2-1dbc-43c4-9ce9-7abb03a26f4b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				SequenceFlowEndPointPosition = new Point(839, 184),
				SequenceFlowStartPointPosition = new Point(568, 170),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8fe0ebab-0981-4829-aaa5-3a875af8e7f9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("04e892ea-48ae-4646-a183-144d38a2f166"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(568, 127));
			schemaFlow.PolylinePointPositions.Add(new Point(839, 127));
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("67ca6015-7f6a-4dee-89c8-ec59810dbcb1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ae8519c2-2aac-4a00-aa61-b0ffaac99ea3"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("0daa7547-536d-4f2d-88ec-929d3ce5b376"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("67ca6015-7f6a-4dee-89c8-ec59810dbcb1"),
				CreatedInOwnerSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				CreatedInPackageId = new Guid("ae8519c2-2aac-4a00-aa61-b0ffaac99ea3"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("44c1b9de-897a-4c18-932d-521ef9b165db"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0daa7547-536d-4f2d-88ec-929d3ce5b376"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ae8519c2-2aac-4a00-aa61-b0ffaac99ea3"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"StartEvent1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = true
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("04e892ea-48ae-4646-a183-144d38a2f166"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0daa7547-536d-4f2d-88ec-929d3ce5b376"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ae8519c2-2aac-4a00-aa61-b0ffaac99ea3"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"TerminateEvent1",
				Position = new Point(825, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0daa7547-536d-4f2d-88ec-929d3ce5b376"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"UserTask1",
				Position = new Point(388, 170),
				SchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("a392565d-ffd5-491f-9203-9bd516aa43d1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0daa7547-536d-4f2d-88ec-929d3ce5b376"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"ScriptTask1",
				Position = new Point(254, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,78,205,75,9,74,205,205,204,75,201,204,75,215,40,201,200,44,214,115,79,45,177,41,46,41,2,242,237,52,148,130,75,18,139,74,252,242,75,50,211,50,147,19,75,50,243,243,66,82,43,74,148,52,53,173,185,138,82,75,74,139,242,20,74,138,74,83,173,1,228,217,249,64,70,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask2ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("4dcfda98-03bd-421b-b6fc-85ad84635e98"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0daa7547-536d-4f2d-88ec-929d3ce5b376"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"ScriptTask2",
				Position = new Point(701, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,78,205,75,9,74,205,205,204,75,201,204,75,215,40,201,200,44,214,115,79,45,177,41,46,41,2,242,237,52,148,220,50,243,50,139,51,252,242,75,50,211,50,147,19,75,50,243,243,66,82,43,74,148,52,53,173,185,138,82,75,74,139,242,20,74,138,74,83,173,1,131,208,205,235,71,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("dda9367d-fcae-4606-a1cf-181d7eec920d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0daa7547-536d-4f2d-88ec-929d3ce5b376"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"ExclusiveGateway1",
				Position = new Point(121, 170),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("8fe0ebab-0981-4829-aaa5-3a875af8e7f9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0daa7547-536d-4f2d-88ec-929d3ce5b376"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"ExclusiveGateway2",
				Position = new Point(540, 170),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("885ca0e6-55f1-446f-8940-40b5bb96a964"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("42c464a9-9677-4bbd-86c1-308caea3de84")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ContactActualizeAgeProcess(userConnection);
		}

		public override object Clone() {
			return new ContactActualizeAgeProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("51734939-e406-46f0-b832-0b87c66b860b"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactActualizeAgeProcessMethodsWrapper

	/// <exclude/>
	public class ContactActualizeAgeProcessMethodsWrapper : ProcessModel
	{

		public ContactActualizeAgeProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
			AddScriptTaskMethod("ScriptTask2Execute", ScriptTask2Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			SendReminding(this.Get<string>("StartNotificationText"));
			return true;
		}

		private bool ScriptTask2Execute(ProcessExecutingContext context) {
			SendReminding(this.Get<string>("FinishNotificationText"));
			return true;
		}

			public virtual void SendReminding(string message) {
				var remindEntity = RemindingServerUtilities.GetRemindingByProcess(UserConnection, "ContactActualizeAgeProcess", message);
				remindEntity.Save();
			}

		#endregion

	}

	#endregion

	#region Class: ContactActualizeAgeProcess

	/// <exclude/>
	public class ContactActualizeAgeProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ContactActualizeAgeProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: UserTask1FlowElement

		/// <exclude/>
		public class UserTask1FlowElement : ActualizeContactsAgeUserTask
		{

			#region Constructors: Public

			public UserTask1FlowElement(UserConnection userConnection, ContactActualizeAgeProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "UserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("9a880b9b-1533-40e1-9ba7-09cf5edc5376");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_dateFrom = () => (DateTime)((process.DateFrom));
				_dateTo = () => (DateTime)((process.DateTo));
				_isActualizeAllRecord = () => (bool)((process.IsActualizeAllRecord));
				_chunkSize = () => (int)((process.ChunkSize));
				_maxDegreeOfParallelism = () => (int)((process.MaxDegreeOfParallelism));
				_chunkProcessingDelay = () => (int)((process.ChunkProcessingDelay));
			}

			#endregion

			#region Properties: Public

			internal Func<DateTime> _dateFrom;
			public override DateTime DateFrom {
				get {
					return (_dateFrom ?? (_dateFrom = () => DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture))).Invoke();
				}
				set {
					_dateFrom = () => { return value; };
				}
			}

			internal Func<DateTime> _dateTo;
			public override DateTime DateTo {
				get {
					return (_dateTo ?? (_dateTo = () => DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture))).Invoke();
				}
				set {
					_dateTo = () => { return value; };
				}
			}

			internal Func<bool> _isActualizeAllRecord;
			public override bool IsActualizeAllRecord {
				get {
					return (_isActualizeAllRecord ?? (_isActualizeAllRecord = () => false)).Invoke();
				}
				set {
					_isActualizeAllRecord = () => { return value; };
				}
			}

			internal Func<int> _chunkSize;
			public override int ChunkSize {
				get {
					return (_chunkSize ?? (_chunkSize = () => 0)).Invoke();
				}
				set {
					_chunkSize = () => { return value; };
				}
			}

			internal Func<int> _maxDegreeOfParallelism;
			public override int MaxDegreeOfParallelism {
				get {
					return (_maxDegreeOfParallelism ?? (_maxDegreeOfParallelism = () => 0)).Invoke();
				}
				set {
					_maxDegreeOfParallelism = () => { return value; };
				}
			}

			internal Func<int> _chunkProcessingDelay;
			public override int ChunkProcessingDelay {
				get {
					return (_chunkProcessingDelay ?? (_chunkProcessingDelay = () => 0)).Invoke();
				}
				set {
					_chunkProcessingDelay = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		public ContactActualizeAgeProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactActualizeAgeProcess";
			SchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = true;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_dateTo = () => { return (DateTime)(((DateTime)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentDate"))); };
			_chunkSize = () => { return (int)(1000); };
			_maxDegreeOfParallelism = () => { return (int)(11); };
			_chunkProcessingDelay = () => { return (int)(100); };
			_dateFrom = () => { return (DateTime)(((DateTime)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentDate"))); };
			_isNeedToNotifyUser = () => { return (bool)(false); };
			ProcessModel = new ContactActualizeAgeProcessMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("51734939-e406-46f0-b832-0b87c66b860b");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ContactActualizeAgeProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ContactActualizeAgeProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private Func<DateTime> _dateTo;
		public virtual DateTime DateTo {
			get {
				return (_dateTo ?? (_dateTo = () => DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture))).Invoke();
			}
			set {
				_dateTo = () => { return value; };
			}
		}

		public virtual bool IsActualizeAllRecord {
			get;
			set;
		}

		private Func<int> _chunkSize;
		public virtual int ChunkSize {
			get {
				return (_chunkSize ?? (_chunkSize = () => 0)).Invoke();
			}
			set {
				_chunkSize = () => { return value; };
			}
		}

		private Func<int> _maxDegreeOfParallelism;
		public virtual int MaxDegreeOfParallelism {
			get {
				return (_maxDegreeOfParallelism ?? (_maxDegreeOfParallelism = () => 0)).Invoke();
			}
			set {
				_maxDegreeOfParallelism = () => { return value; };
			}
		}

		private Func<int> _chunkProcessingDelay;
		public virtual int ChunkProcessingDelay {
			get {
				return (_chunkProcessingDelay ?? (_chunkProcessingDelay = () => 0)).Invoke();
			}
			set {
				_chunkProcessingDelay = () => { return value; };
			}
		}

		private Func<DateTime> _dateFrom;
		public virtual DateTime DateFrom {
			get {
				return (_dateFrom ?? (_dateFrom = () => DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture))).Invoke();
			}
			set {
				_dateFrom = () => { return value; };
			}
		}

		private string _startNotificationText;
		public virtual string StartNotificationText {
			get {
				return _startNotificationText ?? (_startNotificationText = GetLocalizableString("51734939e40646f0b8320b87c66b860b",
						 "Parameters.StartNotificationText.Value"));
			}
			set {
				_startNotificationText = value;
			}
		}

		private string _finishNotificationText;
		public virtual string FinishNotificationText {
			get {
				return _finishNotificationText ?? (_finishNotificationText = GetLocalizableString("51734939e40646f0b8320b87c66b860b",
						 "Parameters.FinishNotificationText.Value"));
			}
			set {
				_finishNotificationText = value;
			}
		}

		private Func<bool> _isNeedToNotifyUser;
		public virtual bool IsNeedToNotifyUser {
			get {
				return (_isNeedToNotifyUser ?? (_isNeedToNotifyUser = () => false)).Invoke();
			}
			set {
				_isNeedToNotifyUser = () => { return value; };
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
					SchemaElementUId = new Guid("44c1b9de-897a-4c18-932d-521ef9b165db"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
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
					SchemaElementUId = new Guid("04e892ea-48ae-4646-a183-144d38a2f166"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private UserTask1FlowElement _userTask1;
		public UserTask1FlowElement UserTask1 {
			get {
				return _userTask1 ?? (_userTask1 = new UserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("a392565d-ffd5-491f-9203-9bd516aa43d1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ScriptTask1Execute"),
				});
			}
		}

		private ProcessScriptTask _scriptTask2;
		public ProcessScriptTask ScriptTask2 {
			get {
				return _scriptTask2 ?? (_scriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask2",
					SchemaElementUId = new Guid("4dcfda98-03bd-421b-b6fc-85ad84635e98"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ScriptTask2Execute"),
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
					SchemaElementUId = new Guid("dda9367d-fcae-4606-a1cf-181d7eec920d"),
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

		private ProcessExclusiveGateway _exclusiveGateway2;
		public ProcessExclusiveGateway ExclusiveGateway2 {
			get {
				return _exclusiveGateway2 ?? (_exclusiveGateway2 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway2",
					SchemaElementUId = new Guid("8fe0ebab-0981-4829-aaa5-3a875af8e7f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway2.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow1;
		public ProcessConditionalFlow ConditionalSequenceFlow1 {
			get {
				return _conditionalSequenceFlow1 ?? (_conditionalSequenceFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow1",
					SchemaElementUId = new Guid("130182af-e308-4469-9f4c-3d33717d66d2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow3;
		public ProcessConditionalFlow ConditionalSequenceFlow3 {
			get {
				return _conditionalSequenceFlow3 ?? (_conditionalSequenceFlow3 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow3",
					SchemaElementUId = new Guid("a2bb631e-97ad-4eb9-8abf-3f0163ff9a78"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[UserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { UserTask1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "UserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("UserTask1", e.Context.SenderName));
						break;
					case "ScriptTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("UserTask1", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalSequenceFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((IsNeedToNotifyUser));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow1", "(IsNeedToNotifyUser)", result);
			return result;
		}

		private bool ConditionalSequenceFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean((IsNeedToNotifyUser));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalSequenceFlow3", "(IsNeedToNotifyUser)", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("IsActualizeAllRecord")) {
				writer.WriteValue("IsActualizeAllRecord", IsActualizeAllRecord, false);
			}
			if (!HasMapping("StartNotificationText")) {
				writer.WriteValue("StartNotificationText", StartNotificationText, null);
			}
			if (!HasMapping("FinishNotificationText")) {
				writer.WriteValue("FinishNotificationText", FinishNotificationText, null);
			}
			if (!HasMapping("DateTo")) {
				writer.WriteValue("DateTo", DateTo, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("ChunkSize")) {
				writer.WriteValue("ChunkSize", ChunkSize, 0);
			}
			if (!HasMapping("MaxDegreeOfParallelism")) {
				writer.WriteValue("MaxDegreeOfParallelism", MaxDegreeOfParallelism, 0);
			}
			if (!HasMapping("ChunkProcessingDelay")) {
				writer.WriteValue("ChunkProcessingDelay", ChunkProcessingDelay, 0);
			}
			if (!HasMapping("DateFrom")) {
				writer.WriteValue("DateFrom", DateFrom, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("IsNeedToNotifyUser")) {
				writer.WriteValue("IsNeedToNotifyUser", IsNeedToNotifyUser, false);
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
			MetaPathParameterValues.Add("b403d6f6-7f5c-4d26-b4bc-805b4f694c85", () => DateTo);
			MetaPathParameterValues.Add("fe16a3ef-1f0f-4665-88c5-e32eeab3de81", () => IsActualizeAllRecord);
			MetaPathParameterValues.Add("937e4c8d-de77-41a7-8100-303ce5902401", () => ChunkSize);
			MetaPathParameterValues.Add("6cacdf95-a10b-4abb-a809-9f1339256952", () => MaxDegreeOfParallelism);
			MetaPathParameterValues.Add("d3f556eb-a542-44e9-b059-89922ff495a5", () => ChunkProcessingDelay);
			MetaPathParameterValues.Add("248661d3-523b-4c99-a6ac-3187fcd2cd93", () => DateFrom);
			MetaPathParameterValues.Add("fbf94615-803b-42f9-9293-0b97fab0b272", () => StartNotificationText);
			MetaPathParameterValues.Add("7c7098d4-e2e3-4749-ae9e-11ed07c800d4", () => FinishNotificationText);
			MetaPathParameterValues.Add("c03f934d-853f-4779-a622-4ff82931929d", () => IsNeedToNotifyUser);
			MetaPathParameterValues.Add("b34f77a4-e54e-46de-a069-0bcfe764a736", () => UserTask1.DateFrom);
			MetaPathParameterValues.Add("e7c313ff-1857-49aa-9358-c144d964ae24", () => UserTask1.DateTo);
			MetaPathParameterValues.Add("ceb66de6-3b6e-4cea-9861-77504af540b2", () => UserTask1.IsActualizeAllRecord);
			MetaPathParameterValues.Add("289d0abb-34e1-4cfc-be1c-c507c2a25e4c", () => UserTask1.ChunkSize);
			MetaPathParameterValues.Add("451283a2-401d-4f6d-84f3-90c19a8fd595", () => UserTask1.MaxDegreeOfParallelism);
			MetaPathParameterValues.Add("0a08573e-b182-4455-8409-c4d713313ca7", () => UserTask1.ChunkProcessingDelay);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "IsActualizeAllRecord":
					if (!hasValueToRead) break;
					IsActualizeAllRecord = reader.GetValue<System.Boolean>();
				break;
				case "StartNotificationText":
					if (!hasValueToRead) break;
					StartNotificationText = reader.GetValue<System.String>();
				break;
				case "FinishNotificationText":
					if (!hasValueToRead) break;
					FinishNotificationText = reader.GetValue<System.String>();
				break;
				case "DateTo":
					if (!hasValueToRead) break;
					DateTo = reader.GetValue<System.DateTime>();
				break;
				case "ChunkSize":
					if (!hasValueToRead) break;
					ChunkSize = reader.GetValue<System.Int32>();
				break;
				case "MaxDegreeOfParallelism":
					if (!hasValueToRead) break;
					MaxDegreeOfParallelism = reader.GetValue<System.Int32>();
				break;
				case "ChunkProcessingDelay":
					if (!hasValueToRead) break;
					ChunkProcessingDelay = reader.GetValue<System.Int32>();
				break;
				case "DateFrom":
					if (!hasValueToRead) break;
					DateFrom = reader.GetValue<System.DateTime>();
				break;
				case "IsNeedToNotifyUser":
					if (!hasValueToRead) break;
					IsNeedToNotifyUser = reader.GetValue<System.Boolean>();
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
			var cloneItem = (ContactActualizeAgeProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

