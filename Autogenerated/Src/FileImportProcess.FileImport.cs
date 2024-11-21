namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.FileImport;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Messaging.Common;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: FileImportProcessSchema

	/// <exclude/>
	public class FileImportProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public FileImportProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public FileImportProcessSchema(FileImportProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "FileImportProcess";
			UId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e");
			CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.7.0.0";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,148,219,110,26,49,16,64,159,65,226,31,44,158,140,138,246,7,26,34,133,91,138,4,21,106,104,250,236,44,3,178,234,181,87,99,47,45,141,242,239,29,123,3,187,222,112,9,18,66,222,241,204,153,139,103,38,47,94,148,76,217,78,162,43,132,98,179,161,176,48,149,10,102,89,110,208,1,178,17,130,112,145,136,63,22,114,205,44,88,43,141,158,173,123,236,181,211,110,85,10,43,177,93,8,45,182,100,123,82,56,96,26,254,156,188,226,63,45,224,200,104,13,169,35,116,239,43,113,119,2,89,17,137,31,112,251,206,32,153,117,88,164,206,32,9,139,12,180,227,221,88,185,219,103,103,160,218,232,37,160,149,214,145,89,148,241,128,141,148,176,118,42,60,120,159,60,130,187,171,223,223,243,15,241,4,104,121,191,20,40,50,32,53,203,242,234,56,56,239,206,243,155,166,188,42,110,69,158,155,109,85,190,186,168,81,182,126,205,113,205,252,187,113,114,35,27,128,131,240,26,226,124,244,229,97,162,157,116,251,39,177,131,9,162,65,246,101,192,56,175,199,216,139,62,146,111,66,175,21,76,254,166,144,123,127,55,185,144,122,91,231,31,82,120,247,112,252,76,194,105,127,25,61,50,170,200,244,18,77,74,5,191,41,116,175,251,233,176,37,216,5,224,22,62,9,159,233,141,89,80,64,52,19,151,93,12,97,99,16,98,71,254,17,188,159,83,3,150,148,195,76,2,123,25,252,176,161,255,27,184,99,80,212,44,84,113,234,163,245,117,124,179,105,214,103,193,161,165,130,222,129,74,191,57,33,239,142,170,247,204,209,149,159,218,99,114,252,74,211,122,234,209,190,54,109,253,128,10,198,8,174,64,125,126,108,73,231,173,211,238,180,243,120,127,54,67,171,199,20,246,228,88,56,241,44,84,1,171,125,14,108,29,125,13,26,187,42,137,148,15,37,161,125,17,201,135,251,227,145,59,250,51,27,78,247,176,146,25,244,66,42,180,35,253,204,164,5,34,37,225,239,200,83,228,217,51,203,81,24,75,155,43,81,18,185,46,148,106,238,207,100,84,98,188,52,152,85,84,239,145,71,46,169,154,43,200,8,24,92,250,181,51,55,169,80,242,159,120,81,240,20,116,26,155,39,249,101,240,183,205,69,10,201,15,176,166,192,148,244,12,82,226,125,214,61,213,33,221,62,185,107,117,63,112,109,66,58,7,231,73,200,167,27,61,172,15,166,241,88,175,204,179,170,237,72,194,240,102,173,86,189,44,148,73,153,94,50,53,152,9,199,107,89,246,235,85,238,121,83,106,146,214,155,111,150,255,111,185,95,137,105,7,0,0 };
			RealUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e");
			Version = 0;
			PackageUId = new Guid("5932ac85-0d31-43c8-aeef-8b7dc5b56f60");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateImportSessionIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c225458a-326c-44d0-97b2-08164e4e8c26"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"ImportSessionId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateRemindingByProcessParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d521237d-a51c-4c4e-879b-0f2c6b4b1102"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"CreateRemindingByProcess",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#BooleanValue.False#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateImportLoggerParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fc3e6aca-899d-4ba0-92f7-d6f237c2f5eb"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"ImportLogger",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateFileImporterParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a78ba39a-a76e-4d2f-a8b2-478e94949415"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"FileImporter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportNotifierParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ee62b062-c5b1-407a-9433-31685004961e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"ImportNotifier",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCompleteRemindingSubjectParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e6a5383b-27dc-4e3f-acaf-0be29d36ba9f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"CompleteRemindingSubject",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCompleteRemindingDescriptionTemplateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("bc14359b-5447-4d41-9da0-76039b4f5831"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"CompleteRemindingDescriptionTemplate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNotImportedRowsCountMessageTemplateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("231f8a46-6136-4dc2-a7ab-9f6f0e4c544e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"NotImportedRowsCountMessageTemplate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateIsUsePersistentFileImportEnabledParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d8a6c0ee-2b88-438c-9995-a64609e5aa7e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"IsUsePersistentFileImportEnabled",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#BooleanValue.True#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateImportSessionIdParameter());
			Parameters.Add(CreateCreateRemindingByProcessParameter());
			Parameters.Add(CreateImportLoggerParameter());
			Parameters.Add(CreateFileImporterParameter());
			Parameters.Add(CreateImportNotifierParameter());
			Parameters.Add(CreateCompleteRemindingSubjectParameter());
			Parameters.Add(CreateCompleteRemindingDescriptionTemplateParameter());
			Parameters.Add(CreateNotImportedRowsCountMessageTemplateParameter());
			Parameters.Add(CreateIsUsePersistentFileImportEnabledParameter());
		}

		protected virtual void InitializeUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var importSessionIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("32b65f96-f26c-4513-8e9a-057ffcd02fab"),
				ContainerUId = new Guid("2c488a31-9f43-43e5-ac28-0a3a3ea2489c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				Name = @"ImportSessionId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			importSessionIdParameter.SourceValue = new ProcessSchemaParameterValue(importSessionIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{c225458a-326c-44d0-97b2-08164e4e8c26}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e")
			};
			parametrizedElement.Parameters.Add(importSessionIdParameter);
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
			ProcessSchemaScriptTask fileimporttask = CreateFileImportTaskScriptTask();
			FlowElements.Add(fileimporttask);
			ProcessSchemaScriptTask createremindingtask = CreateCreateRemindingTaskScriptTask();
			FlowElements.Add(createremindingtask);
			ProcessSchemaScriptTask postmessagetask = CreatePostMessageTaskScriptTask();
			FlowElements.Add(postmessagetask);
			ProcessSchemaScriptTask logimportresultstask = CreateLogImportResultsTaskScriptTask();
			FlowElements.Add(logimportresultstask);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			ProcessSchemaUserTask usertask2 = CreateUserTask2UserTask();
			FlowElements.Add(usertask2);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow4ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("9f06bebc-217e-4b00-ac59-7b362c3e3060"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("796e22f0-f52d-4fb6-ab29-873e9f245a40"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1b82b689-cca2-4475-8702-4bf214f6fa9a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("93fb1d2e-b3d6-45c5-9b81-19bbe1c7567b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("77c19b8e-5131-4a98-a063-832f58635a81"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d24ff5d0-038b-47d1-931c-3f4de75a2a0f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("e16eac81-10f4-484b-af2f-4008bcf126b3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("52abf94a-4a51-4e9b-afae-86480a04ff1e"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d24ff5d0-038b-47d1-931c-3f4de75a2a0f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("45ff1004-c87c-45b0-bfd2-5023cfd02f79"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("55a7bc6d-9a13-4817-92c2-23510a5a7d42"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("45ff1004-c87c-45b0-bfd2-5023cfd02f79"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("89735d99-1cde-4bd2-bbd1-d90f9c524476"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("41f61400-0554-4da5-b9f1-e39401588edd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("89735d99-1cde-4bd2-bbd1-d90f9c524476"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4579883e-dfbb-4b76-b3f4-dae2f995a4bb"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("4c648c3e-231c-4394-a943-9058c33a35d7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5932ac85-0d31-43c8-aeef-8b7dc5b56f60"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a72c31b2-8a30-4119-8d97-33024d6f7375"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("77c19b8e-5131-4a98-a063-832f58635a81"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow4ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow4",
				UId = new Guid("109cd7cc-53f0-4df7-8071-4824befba3c4"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d8a6c0ee-2b88-438c-9995-a64609e5aa7e}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5932ac85-0d31-43c8-aeef-8b7dc5b56f60"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a72c31b2-8a30-4119-8d97-33024d6f7375"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2c488a31-9f43-43e5-ac28-0a3a3ea2489c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(272, 327));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("46bab91d-7603-4088-a4b9-5144990fca9f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5932ac85-0d31-43c8-aeef-8b7dc5b56f60"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1b82b689-cca2-4475-8702-4bf214f6fa9a"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a72c31b2-8a30-4119-8d97-33024d6f7375"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("76cf7621-139f-423b-9d18-abc5cd910d73"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5932ac85-0d31-43c8-aeef-8b7dc5b56f60"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2c488a31-9f43-43e5-ac28-0a3a3ea2489c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4579883e-dfbb-4b76-b3f4-dae2f995a4bb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(833, 327));
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("81a2d907-3fa9-45ca-a3ed-a676ac7edf2e"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("09a3376c-fbe5-466b-b421-55bb79fc0742"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("81a2d907-3fa9-45ca-a3ed-a676ac7edf2e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("796e22f0-f52d-4fb6-ab29-873e9f245a40"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("09a3376c-fbe5-466b-b421-55bb79fc0742"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
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
				UId = new Guid("4579883e-dfbb-4b76-b3f4-dae2f995a4bb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("09a3376c-fbe5-466b-b421-55bb79fc0742"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"Terminate1",
				Position = new Point(820, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateFileImportTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("77c19b8e-5131-4a98-a063-832f58635a81"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("09a3376c-fbe5-466b-b421-55bb79fc0742"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"FileImportTask",
				Position = new Point(351, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,227,229,114,203,204,73,245,204,45,200,47,42,73,45,82,176,85,112,46,74,77,44,73,69,22,212,128,48,130,83,139,139,51,243,243,60,83,52,173,121,185,74,138,42,21,170,121,185,56,53,52,60,157,18,139,81,148,107,162,112,244,32,44,108,102,212,42,36,39,150,36,103,40,104,184,86,36,167,22,148,0,197,21,82,53,97,166,130,149,251,228,167,167,3,205,64,225,232,1,105,215,162,162,252,34,141,84,176,33,188,92,69,169,37,165,69,121,10,37,69,165,169,214,0,177,89,131,54,207,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateCreateRemindingTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("45ff1004-c87c-45b0-bfd2-5023cfd02f79"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("09a3376c-fbe5-466b-b421-55bb79fc0742"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("52abf94a-4a51-4e9b-afae-86480a04ff1e"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"CreateRemindingTask",
				Position = new Point(591, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,84,95,111,218,48,16,127,6,169,223,193,202,83,208,80,104,165,77,125,232,168,52,66,169,34,181,85,213,208,190,187,201,65,61,17,27,217,231,86,17,226,187,207,142,9,49,36,45,155,246,20,199,254,253,185,59,159,111,52,138,37,80,132,39,40,24,207,25,95,78,202,71,41,50,80,138,48,69,20,160,34,40,200,130,174,20,12,201,89,127,52,122,133,140,106,5,36,179,52,131,39,178,102,146,66,188,67,110,225,73,177,22,18,31,4,178,5,3,25,85,139,242,134,231,132,113,114,25,93,252,136,190,159,245,217,130,132,159,89,15,200,230,172,223,115,42,143,84,210,2,16,164,34,235,102,57,38,97,152,76,168,130,25,91,129,3,130,28,28,252,68,51,163,122,172,17,186,141,212,152,48,193,147,124,112,101,140,210,82,61,43,144,9,95,8,146,105,41,129,163,253,55,38,246,19,11,206,33,67,3,143,226,230,208,242,110,53,203,73,38,56,210,12,147,220,192,61,114,20,215,251,22,57,53,105,206,89,1,36,175,23,135,224,91,192,157,118,141,12,171,200,52,227,72,184,192,93,82,249,147,248,80,177,208,102,115,236,85,195,22,184,133,176,116,133,210,222,75,14,42,147,108,109,83,48,60,183,25,205,132,44,40,134,177,40,214,43,240,46,97,218,128,231,96,206,76,60,67,223,171,101,52,52,70,61,15,48,23,72,87,205,169,207,181,247,243,96,126,170,220,108,3,116,166,118,77,206,93,3,244,252,192,191,29,71,222,149,244,189,185,87,186,132,38,240,46,131,202,125,219,148,39,163,221,165,9,54,231,91,178,185,216,6,67,210,170,82,170,95,127,155,166,24,250,181,173,116,147,52,123,131,130,222,83,110,226,144,9,66,241,243,134,35,195,210,237,95,19,118,208,128,230,156,140,109,170,71,157,230,115,118,90,182,73,44,126,82,218,18,134,193,65,39,7,127,103,174,74,181,123,98,119,98,249,63,230,47,31,169,47,229,236,125,94,51,22,118,255,173,199,244,153,11,87,72,121,6,181,211,190,228,190,135,55,116,198,199,78,145,155,42,14,24,30,154,86,18,123,124,148,2,78,97,17,139,149,46,248,11,93,105,80,97,27,225,29,135,193,47,141,111,66,38,185,233,137,253,195,63,65,217,15,130,127,224,164,66,203,12,42,202,62,127,163,163,80,69,77,11,86,152,58,160,19,130,142,101,7,139,145,172,135,208,9,142,55,9,130,118,163,127,17,188,174,222,70,21,125,215,184,253,130,89,42,191,43,42,133,86,203,70,207,167,117,92,4,177,123,216,182,238,110,117,130,118,39,104,110,158,141,117,109,189,210,46,87,250,238,198,180,153,37,18,80,75,78,80,106,184,250,3,85,66,51,142,83,7,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreatePostMessageTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("d24ff5d0-038b-47d1-931c-3f4de75a2a0f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("09a3376c-fbe5-466b-b421-55bb79fc0742"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("52abf94a-4a51-4e9b-afae-86480a04ff1e"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"PostMessageTask",
				Position = new Point(471, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,211,215,247,204,45,200,47,42,241,203,47,201,76,203,76,45,210,3,51,42,93,243,82,52,52,21,114,243,203,82,83,20,74,242,21,220,50,115,82,33,234,82,139,120,185,138,82,75,74,139,242,20,74,138,74,83,173,1,64,184,13,32,64,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateLogImportResultsTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("89735d99-1cde-4bd2-bbd1-d90f9c524476"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("09a3376c-fbe5-466b-b421-55bb79fc0742"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"LogImportResultsTask",
				Position = new Point(711, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,211,208,240,204,45,200,47,42,241,201,79,79,79,45,210,68,225,232,5,39,150,165,2,217,26,154,214,188,92,69,169,37,165,69,121,10,37,69,165,169,214,0,88,235,121,210,53,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("a72c31b2-8a30-4119-8d97-33024d6f7375"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("09a3376c-fbe5-466b-b421-55bb79fc0742"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5932ac85-0d31-43c8-aeef-8b7dc5b56f60"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"ExclusiveGateway1",
				Position = new Point(245, 170),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("1b82b689-cca2-4475-8702-4bf214f6fa9a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("09a3376c-fbe5-466b-b421-55bb79fc0742"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5932ac85-0d31-43c8-aeef-8b7dc5b56f60"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"ScriptTask1",
				Position = new Point(125, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,204,49,10,128,48,12,5,208,221,83,148,78,10,226,5,58,138,149,110,130,120,128,170,127,40,212,84,146,120,127,59,184,186,63,222,10,109,109,144,77,176,128,37,137,130,212,167,140,112,221,133,117,162,184,103,156,182,55,21,240,88,136,112,104,42,52,204,208,32,30,81,31,198,135,90,251,147,216,174,115,13,163,82,50,202,15,220,11,205,159,150,252,116,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("2c488a31-9f43-43e5-ac28-0a3a3ea2489c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("09a3376c-fbe5-466b-b421-55bb79fc0742"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5932ac85-0d31-43c8-aeef-8b7dc5b56f60"),
				CreatedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"),
				Name = @"UserTask2",
				Position = new Point(351, 300),
				SchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = true,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("f41c767b-58cf-438a-ae91-abe533146f2d"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2eb91ae4-6b15-469b-b9fc-09f42e13303e"),
				Name = "BPMSoft.Configuration.FileImport",
				Alias = "",
				CreatedInPackageId = new Guid("422e303b-e4b1-4d5c-a964-ae75099f60da")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("bbc74413-5949-4426-a5eb-dbae26e7d140"),
				Name = "BPMSoft.Messaging.Common",
				Alias = "",
				CreatedInPackageId = new Guid("52abf94a-4a51-4e9b-afae-86480a04ff1e")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("5a9cb62b-9b58-4ad0-9299-3feeec1d49b1"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new FileImportProcess(userConnection);
		}

		public override object Clone() {
			return new FileImportProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e"));
		}

		#endregion

	}

	#endregion

	#region Class: FileImportProcessMethodsWrapper

	/// <exclude/>
	public class FileImportProcessMethodsWrapper : ProcessModel
	{

		public FileImportProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			Set("IsUsePersistentFileImportEnabled", UserConnection.GetIsFeatureEnabled("UsePersistentFileImport"));
			return true;
		}

		#endregion

	}

	#endregion

	#region Class: FileImportProcess

	/// <exclude/>
	public class FileImportProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, FileImportProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: UserTask2FlowElement

		/// <exclude/>
		public class UserTask2FlowElement : FileImportPersistentTask
		{

			#region Constructors: Public

			public UserTask2FlowElement(UserConnection userConnection, FileImportProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "UserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("2c488a31-9f43-43e5-ac28-0a3a3ea2489c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_importSessionId = () => (Guid)((process.ImportSessionId));
			}

			#endregion

			#region Properties: Public

			internal Func<Guid> _importSessionId;
			public override Guid ImportSessionId {
				get {
					return (_importSessionId ?? (_importSessionId = () => Guid.Empty)).Invoke();
				}
				set {
					_importSessionId = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		public FileImportProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FileImportProcess";
			SchemaUId = new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_createRemindingByProcess = () => { return (bool)(false); };
			_isUsePersistentFileImportEnabled = () => { return (bool)(true); };
			ProcessModel = new FileImportProcessMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3e7e191e-6b0c-4c8a-bfc3-00fe715aa84e");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: FileImportProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: FileImportProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid ImportSessionId {
			get;
			set;
		}

		private Func<bool> _createRemindingByProcess;
		public virtual bool CreateRemindingByProcess {
			get {
				return (_createRemindingByProcess ?? (_createRemindingByProcess = () => false)).Invoke();
			}
			set {
				_createRemindingByProcess = () => { return value; };
			}
		}

		public virtual Object ImportLogger {
			get;
			set;
		}

		public virtual Object FileImporter {
			get;
			set;
		}

		public virtual Object ImportNotifier {
			get;
			set;
		}

		private LocalizableString _completeRemindingSubject;
		public virtual LocalizableString CompleteRemindingSubject {
			get {
				return _completeRemindingSubject ?? (_completeRemindingSubject = GetLocalizableString("3e7e191e6b0c4c8abfc300fe715aa84e",
						 "Parameters.CompleteRemindingSubject.Value"));
			}
			set {
				_completeRemindingSubject = value;
			}
		}

		private LocalizableString _completeRemindingDescriptionTemplate;
		public virtual LocalizableString CompleteRemindingDescriptionTemplate {
			get {
				return _completeRemindingDescriptionTemplate ?? (_completeRemindingDescriptionTemplate = GetLocalizableString("3e7e191e6b0c4c8abfc300fe715aa84e",
						 "Parameters.CompleteRemindingDescriptionTemplate.Value"));
			}
			set {
				_completeRemindingDescriptionTemplate = value;
			}
		}

		private LocalizableString _notImportedRowsCountMessageTemplate;
		public virtual LocalizableString NotImportedRowsCountMessageTemplate {
			get {
				return _notImportedRowsCountMessageTemplate ?? (_notImportedRowsCountMessageTemplate = GetLocalizableString("3e7e191e6b0c4c8abfc300fe715aa84e",
						 "Parameters.NotImportedRowsCountMessageTemplate.Value"));
			}
			set {
				_notImportedRowsCountMessageTemplate = value;
			}
		}

		private Func<bool> _isUsePersistentFileImportEnabled;
		public virtual bool IsUsePersistentFileImportEnabled {
			get {
				return (_isUsePersistentFileImportEnabled ?? (_isUsePersistentFileImportEnabled = () => false)).Invoke();
			}
			set {
				_isUsePersistentFileImportEnabled = () => { return value; };
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
					SchemaElementUId = new Guid("796e22f0-f52d-4fb6-ab29-873e9f245a40"),
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
					SchemaElementUId = new Guid("4579883e-dfbb-4b76-b3f4-dae2f995a4bb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _fileImportTask;
		public ProcessScriptTask FileImportTask {
			get {
				return _fileImportTask ?? (_fileImportTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "FileImportTask",
					SchemaElementUId = new Guid("77c19b8e-5131-4a98-a063-832f58635a81"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FileImportTaskExecute,
				});
			}
		}

		private ProcessScriptTask _createRemindingTask;
		public ProcessScriptTask CreateRemindingTask {
			get {
				return _createRemindingTask ?? (_createRemindingTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CreateRemindingTask",
					SchemaElementUId = new Guid("45ff1004-c87c-45b0-bfd2-5023cfd02f79"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = CreateRemindingTaskExecute,
				});
			}
		}

		private ProcessScriptTask _postMessageTask;
		public ProcessScriptTask PostMessageTask {
			get {
				return _postMessageTask ?? (_postMessageTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PostMessageTask",
					SchemaElementUId = new Guid("d24ff5d0-038b-47d1-931c-3f4de75a2a0f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = PostMessageTaskExecute,
				});
			}
		}

		private ProcessScriptTask _logImportResultsTask;
		public ProcessScriptTask LogImportResultsTask {
			get {
				return _logImportResultsTask ?? (_logImportResultsTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LogImportResultsTask",
					SchemaElementUId = new Guid("89735d99-1cde-4bd2-bbd1-d90f9c524476"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = LogImportResultsTaskExecute,
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
					SchemaElementUId = new Guid("a72c31b2-8a30-4119-8d97-33024d6f7375"),
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

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("1b82b689-cca2-4475-8702-4bf214f6fa9a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ScriptTask1Execute"),
				});
			}
		}

		private UserTask2FlowElement _userTask2;
		public UserTask2FlowElement UserTask2 {
			get {
				return _userTask2 ?? (_userTask2 = new UserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow4;
		public ProcessConditionalFlow ConditionalSequenceFlow4 {
			get {
				return _conditionalSequenceFlow4 ?? (_conditionalSequenceFlow4 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow4",
					SchemaElementUId = new Guid("109cd7cc-53f0-4df7-8071-4824befba3c4"),
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
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[FileImportTask.SchemaElementUId] = new Collection<ProcessFlowElement> { FileImportTask };
			FlowElements[CreateRemindingTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateRemindingTask };
			FlowElements[PostMessageTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PostMessageTask };
			FlowElements[LogImportResultsTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogImportResultsTask };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[UserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { UserTask2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "FileImportTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PostMessageTask", e.Context.SenderName));
						break;
					case "CreateRemindingTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LogImportResultsTask", e.Context.SenderName));
						break;
					case "PostMessageTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateRemindingTask", e.Context.SenderName));
						break;
					case "LogImportResultsTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow4ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("UserTask2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FileImportTask", e.Context.SenderName));
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "UserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow4ExpressionExecute() {
			bool result = Convert.ToBoolean((IsUsePersistentFileImportEnabled));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow4", "(IsUsePersistentFileImportEnabled)", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("ImportSessionId")) {
				writer.WriteValue("ImportSessionId", ImportSessionId, Guid.Empty);
			}
			if (ImportLogger != null) {
				if (ImportLogger.GetType().IsSerializable ||
					ImportLogger.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ImportLogger", ImportLogger, null);
				}
			}
			if (FileImporter != null) {
				if (FileImporter.GetType().IsSerializable ||
					FileImporter.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("FileImporter", FileImporter, null);
				}
			}
			if (ImportNotifier != null) {
				if (ImportNotifier.GetType().IsSerializable ||
					ImportNotifier.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ImportNotifier", ImportNotifier, null);
				}
			}
			if (!HasMapping("CreateRemindingByProcess")) {
				writer.WriteValue("CreateRemindingByProcess", CreateRemindingByProcess, false);
			}
			if (!HasMapping("IsUsePersistentFileImportEnabled")) {
				writer.WriteValue("IsUsePersistentFileImportEnabled", IsUsePersistentFileImportEnabled, false);
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
			MetaPathParameterValues.Add("c225458a-326c-44d0-97b2-08164e4e8c26", () => ImportSessionId);
			MetaPathParameterValues.Add("d521237d-a51c-4c4e-879b-0f2c6b4b1102", () => CreateRemindingByProcess);
			MetaPathParameterValues.Add("fc3e6aca-899d-4ba0-92f7-d6f237c2f5eb", () => ImportLogger);
			MetaPathParameterValues.Add("a78ba39a-a76e-4d2f-a8b2-478e94949415", () => FileImporter);
			MetaPathParameterValues.Add("ee62b062-c5b1-407a-9433-31685004961e", () => ImportNotifier);
			MetaPathParameterValues.Add("e6a5383b-27dc-4e3f-acaf-0be29d36ba9f", () => CompleteRemindingSubject);
			MetaPathParameterValues.Add("bc14359b-5447-4d41-9da0-76039b4f5831", () => CompleteRemindingDescriptionTemplate);
			MetaPathParameterValues.Add("231f8a46-6136-4dc2-a7ab-9f6f0e4c544e", () => NotImportedRowsCountMessageTemplate);
			MetaPathParameterValues.Add("d8a6c0ee-2b88-438c-9995-a64609e5aa7e", () => IsUsePersistentFileImportEnabled);
			MetaPathParameterValues.Add("32b65f96-f26c-4513-8e9a-057ffcd02fab", () => UserTask2.ImportSessionId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "ImportSessionId":
					if (!hasValueToRead) break;
					ImportSessionId = reader.GetValue<System.Guid>();
				break;
				case "ImportLogger":
					if (!hasValueToRead) break;
					ImportLogger = reader.GetSerializableObjectValue();
				break;
				case "FileImporter":
					if (!hasValueToRead) break;
					FileImporter = reader.GetSerializableObjectValue();
				break;
				case "ImportNotifier":
					if (!hasValueToRead) break;
					ImportNotifier = reader.GetSerializableObjectValue();
				break;
				case "CreateRemindingByProcess":
					if (!hasValueToRead) break;
					CreateRemindingByProcess = reader.GetValue<System.Boolean>();
				break;
				case "IsUsePersistentFileImportEnabled":
					if (!hasValueToRead) break;
					IsUsePersistentFileImportEnabled = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool FileImportTaskExecute(ProcessExecutingContext context) {
			
			FileImporter = CreateFileImporter(ImportSessionId);
			try {
				((IBaseFileImporter)FileImporter).Import(ImportSessionId);
			} catch (Exception e) {
				((ImportLogger)ImportLogger).LogError(e);
			}
			return true;
		}

		public virtual bool CreateRemindingTaskExecute(ProcessExecutingContext context) {
			//CreateRemindingByProcess is sets to false, 
			//because creating reminding moved to ImportNotifier.NotifyEnd in 7.15.4
			if (CreateRemindingByProcess) {
				ImportParameters parameters = ((IBaseFileImporter)FileImporter).FindImportParameters(ImportSessionId);
				SysUserInfo currentUser = UserConnection.CurrentUser;
				Guid contactId = currentUser.ContactId;
				DateTime dateTime = currentUser.GetCurrentDateTime();
				uint notImportedRowsCount = parameters.NotImportedRowsCount;
				string description = string.Format(CompleteRemindingDescriptionTemplate, parameters.ImportedRowsCount,
					parameters.TotalRowsCount, parameters.FileName);
				if (notImportedRowsCount > 0) {
					description += string.Format(NotImportedRowsCountMessageTemplate, notImportedRowsCount);
				}
				string caption = string.Format("{0} {1}", CompleteRemindingSubject, description);
				ISchemaManagerItem<EntitySchema> importSessionItem =
					UserConnection.EntitySchemaManager.GetItemByName("ImportSession");
				ISchemaManagerItem<EntitySchema> sysProcessLogItem =
					UserConnection.EntitySchemaManager.GetItemByName("VwSysProcessLog");
				EntitySchema remindingSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Reminding");
				Entity reminding = remindingSchema.CreateEntity(UserConnection);
				reminding.SetDefColumnValues();
				reminding.SetColumnValue("AuthorId", contactId);
				reminding.SetColumnValue("ContactId", contactId);
				reminding.SetColumnValue("SourceId", RemindingConsts.RemindingSourceAuthorId);
				reminding.SetColumnValue("RemindTime", dateTime);
				reminding.SetColumnValue("Description", description);
				reminding.SetColumnValue("SubjectId", ImportSessionId);
				reminding.SetColumnValue("SysEntitySchemaId", sysProcessLogItem.UId);
				reminding.SetColumnValue("SubjectCaption", caption);
				reminding.SetColumnValue("LoaderId", importSessionItem.UId);
				reminding.Save();
			}
			return true;
		}

		public virtual bool PostMessageTaskExecute(ProcessExecutingContext context) {
			//ImportNotifier.NotifyEnd() moved to FileImporter
			return true;
		}

		public virtual bool LogImportResultsTaskExecute(ProcessExecutingContext context) {
			((ImportLogger)ImportLogger).SaveLog();
			return true;
		}

			public virtual IBaseFileImporter CreateFileImporter(Guid sessionId) {
				FileImportTagManager FileImportTagManager = new FileImportTagManager(UserConnection);
				var userConnectionArg = new ConstructorArgument("userConnection", UserConnection);
				var nonPersistentFileImporter = ClassFactory.Get<FileImporter>(userConnectionArg);
				ImportParameters parameters = nonPersistentFileImporter.GetImportParameters(sessionId);
				ImportLogger = new ImportLogger(UserConnection, parameters);
				ImportNotifier = new ImportNotifier(UserConnection, parameters);
				nonPersistentFileImporter.ImportEntitySaveError += ((ImportLogger)ImportLogger).HandleException;
				nonPersistentFileImporter.ImportEntitySaving += ((ImportNotifier)ImportNotifier).Notify;
				nonPersistentFileImporter.ColumnProcessError += ((ImportLogger)ImportLogger).HandleError;
				nonPersistentFileImporter.ImportEntitiesMerge += ((ImportLogger)ImportLogger).HandleInfoMessage;
				nonPersistentFileImporter.BeforeImportEntitiesSave += FileImportTagManager.CreateTags;
				nonPersistentFileImporter.AfterImportEntitiesSave += FileImportTagManager.DeleteNotUsedTags;
				nonPersistentFileImporter.ImportEntitySaved += FileImportTagManager.SaveEntityTags;
				
				List<ImportTag> tags = CreateTags();
				nonPersistentFileImporter.SaveImportTags(sessionId, tags);
				return nonPersistentFileImporter;
			}
			
			public virtual List<ImportTag> CreateTags() {
				DataValueType dataValueType = UserConnection.DataValueTypeManager.GetDataValueTypeByValueType(typeof(DateTime));
				string currentDate = dataValueType.GetColumnDisplayValue(null, UserConnection.CurrentUser.GetCurrentDateTime());
				string tagTemplate = new LocalizableString(UserConnection.Workspace.ResourceStorage, "FileImportTagManager",
					"LocalizableStrings.TagTemplate.Value");
				return new List<ImportTag> { 
					new ImportTag {
						DisplayValue = string.Format(tagTemplate, currentDate)
					}
				};
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
			var cloneItem = (FileImportProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.ImportLogger = ImportLogger;
			cloneItem.FileImporter = FileImporter;
			cloneItem.ImportNotifier = ImportNotifier;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

