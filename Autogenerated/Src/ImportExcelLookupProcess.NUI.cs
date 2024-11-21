namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration.ImportExcelData;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Core.Scheduler;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: ImportExcelLookupProcessSchema

	/// <exclude/>
	public class ImportExcelLookupProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ImportExcelLookupProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ImportExcelLookupProcessSchema(ImportExcelLookupProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ImportExcelLookupProcess";
			UId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6");
			CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.6.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6");
			Version = 0;
			PackageUId = new Guid("a7d9c356-450c-46d7-bc85-72dca4e280ba");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateExcelImportIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a33a32de-c086-4f92-b20a-2ecb38197547"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"ExcelImportId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLookupEntitiesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("32fcd137-5c32-49ff-b621-5ded5a21588e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"LookupEntities",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportExcelDataParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("bc384458-adcd-49cc-950e-156042eeee69"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"ImportExcelData",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsSyncLookupConflictsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("38440d1b-38d4-4040-9d9f-c78538332ba0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"IsSyncLookupConflicts",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsPrimaryDisplayColumnExistsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("efcad133-b57b-4e7c-907c-b9b137a0328c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"IsPrimaryDisplayColumnExists",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSelectedIdentificationColumnsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b15e2c93-c5cd-4c7a-9267-ecbd73d1a51b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"SelectedIdentificationColumns",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNameColumnIndexParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5aa0b7c4-fad6-4370-a377-741952e2a5cf"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"NameColumnIndex",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCaptionsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1d491fcf-7aee-4b68-8c5f-ea6a0e9d34bf"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"Captions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateFileNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6bb6fbcc-df17-4639-ae28-867e618449a4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"FileName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSchemaNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("86b91419-8758-4026-b1af-32973690a3cb"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"SchemaName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportModeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d5788ce6-58ec-4f86-9f22-23bca9e168d9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"ImportMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsOnlyErrorsModeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("174730ca-2f45-440f-a606-a20e8f607ddb"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"IsOnlyErrorsMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateHeaderNamesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a8ad5735-6f37-4d58-977a-852f8c0e76b2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"HeaderNames",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateExcelImportIdParameter());
			Parameters.Add(CreateLookupEntitiesParameter());
			Parameters.Add(CreateImportExcelDataParameter());
			Parameters.Add(CreateIsSyncLookupConflictsParameter());
			Parameters.Add(CreateIsPrimaryDisplayColumnExistsParameter());
			Parameters.Add(CreateSelectedIdentificationColumnsParameter());
			Parameters.Add(CreateNameColumnIndexParameter());
			Parameters.Add(CreateCaptionsParameter());
			Parameters.Add(CreateFileNameParameter());
			Parameters.Add(CreateSchemaNameParameter());
			Parameters.Add(CreateImportModeParameter());
			Parameters.Add(CreateIsOnlyErrorsModeParameter());
			Parameters.Add(CreateHeaderNamesParameter());
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
			ProcessSchemaScriptTask importexcellookupscript = CreateImportExcelLookupScriptScriptTask();
			FlowElements.Add(importexcellookupscript);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateAddNewLookupRecordLocalizableStringLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateAddNewLookupRecordLocalizableStringLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("755a1469-e50c-46ab-8441-d4b8cc63ecb2"),
				Name = "AddNewLookupRecordLocalizableString",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6")
			};
			return localizableString;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("37a349d4-5a55-48d3-a1f7-d5d3b54f0fc5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a377f05b-f5de-414d-8be3-1897a148bb94"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2b2a85f6-eeb3-4fa0-95a6-8fa8274aeebb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("55146d14-e829-4625-baeb-639e0a1274ed"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2b2a85f6-eeb3-4fa0-95a6-8fa8274aeebb"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fee8d430-0d34-47bd-9381-539a86d3e1f1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("d0f4f95d-5af6-47f9-8842-f43344ea79a5"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(710, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("173b2246-e526-42de-8bef-f3ce4656eb80"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("d0f4f95d-5af6-47f9-8842-f43344ea79a5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(681, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("a377f05b-f5de-414d-8be3-1897a148bb94"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("173b2246-e526-42de-8bef-f3ce4656eb80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("fee8d430-0d34-47bd-9381-539a86d3e1f1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("173b2246-e526-42de-8bef-f3ce4656eb80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateImportExcelLookupScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2b2a85f6-eeb3-4fa0-95a6-8fa8274aeebb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("173b2246-e526-42de-8bef-f3ce4656eb80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"ImportExcelLookupScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(288, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,84,77,111,26,49,16,61,111,164,252,7,39,167,69,66,86,155,67,47,124,72,13,144,104,85,26,161,210,244,66,114,112,151,129,88,245,218,212,30,67,16,226,191,215,179,38,176,11,84,85,91,14,94,214,251,222,155,241,155,25,47,133,101,160,81,162,4,199,58,108,104,204,15,191,24,188,109,8,199,134,210,97,251,171,95,40,104,223,123,57,109,50,135,86,234,249,239,159,151,23,73,242,9,214,223,132,242,48,18,210,214,104,221,38,235,203,28,165,209,194,174,219,82,99,147,245,140,82,80,110,209,123,55,252,90,151,23,114,198,210,125,90,87,29,166,189,82,13,182,9,218,67,51,207,244,204,164,81,143,223,25,91,8,76,175,159,112,243,110,27,150,247,97,121,194,177,88,2,211,176,98,155,155,45,83,229,153,28,165,32,44,94,55,217,157,84,240,32,10,104,178,193,107,14,42,43,22,198,98,22,114,124,139,200,123,198,107,108,52,66,34,201,146,12,170,194,70,194,6,46,130,13,118,133,220,125,161,249,126,43,173,9,30,248,164,187,30,231,47,80,136,207,66,139,121,73,126,116,96,123,70,235,120,120,62,56,5,157,227,83,149,232,100,21,27,163,193,85,126,55,45,99,207,140,5,145,191,176,244,32,194,164,222,31,51,26,154,16,157,205,105,233,48,250,207,31,96,69,207,168,145,68,163,217,146,234,153,233,219,69,17,96,81,139,103,8,197,77,107,175,81,77,243,49,155,214,113,31,120,104,138,18,91,77,180,198,41,191,82,229,175,106,7,14,213,208,40,164,118,65,32,61,138,209,216,157,33,169,238,239,3,215,204,228,247,128,153,14,61,160,115,184,93,7,238,137,86,235,68,201,241,143,211,19,220,174,79,118,27,145,181,101,160,28,252,57,23,55,57,18,123,142,116,90,190,27,163,200,102,57,21,8,95,224,167,151,22,200,196,153,8,210,37,140,202,24,187,57,122,120,36,206,123,161,220,8,241,91,90,111,175,152,102,149,204,199,128,125,152,197,22,46,167,213,165,231,81,21,72,205,11,62,178,178,8,13,184,155,130,56,82,212,72,255,38,211,151,110,161,68,93,237,208,117,231,52,195,148,167,199,134,69,92,184,37,42,163,24,222,118,17,203,175,228,246,127,92,35,160,167,127,121,137,132,128,84,58,107,86,52,189,17,90,178,250,2,5,93,178,49,139,201,243,132,218,97,240,10,185,71,56,130,141,172,201,193,185,148,68,72,211,2,122,171,25,90,15,173,95,112,219,227,133,197,5,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
			Methods.Add(CreateLogExcelImportLogMethod());
			Methods.Add(CreateExecuteImportExcelDataProcessMethod());
			Methods.Add(CreateLogInfoMethod());
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("904e2760-8199-4f76-b62e-e4c2d9467849"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a642d3c5-2e54-430c-89a6-414775ba31b1"),
				Name = "BPMSoft.Core.Scheduler",
				Alias = "",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("5786d2b1-c8fb-4f01-8af1-471f29ba83bb"),
				Name = "BPMSoft.Configuration.ImportExcelData",
				Alias = "",
				CreatedInPackageId = new Guid("811fcb66-130b-4d85-9d3f-7b0df7ea2049")
			});
		}

		protected virtual SchemaMethod CreateLogExcelImportLogMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("bc5d1600-aade-46f0-8175-e9c2bb41a229"),
				Name = "LogExcelImportLog",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("1d639ce2-48d5-426e-8b2c-1a3282bf5b28"),
				Name = "entity",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Tuple<Guid, string, string, string, string, KeyValuePair<Guid, string>, Dictionary<int, Collection<int>>>",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,61,79,195,48,20,156,91,169,255,193,242,148,168,145,7,36,166,138,1,66,65,145,74,249,104,97,98,49,206,107,100,145,216,149,243,66,26,16,255,29,59,105,154,148,86,69,76,150,125,247,46,239,238,34,87,196,139,242,69,165,196,76,235,247,98,29,106,181,74,165,192,220,39,95,163,225,192,0,22,70,77,70,195,239,209,240,131,27,146,20,50,38,23,228,214,30,108,14,165,59,61,127,210,96,74,151,15,220,240,12,16,140,229,40,40,201,99,1,166,218,61,122,212,82,104,64,174,57,194,82,102,192,230,186,12,8,109,175,180,21,18,133,49,160,240,57,7,99,215,65,46,48,138,255,82,238,205,68,49,13,236,234,219,113,5,2,165,86,44,236,8,108,167,234,190,152,163,145,42,33,105,109,223,170,91,146,196,138,69,8,217,249,111,248,133,167,5,236,115,206,58,78,6,121,206,19,135,55,15,236,70,155,140,163,119,25,199,54,171,38,223,39,16,218,196,51,45,120,42,63,249,91,10,139,154,26,16,187,241,128,190,82,74,198,237,42,99,226,238,193,1,208,44,209,160,206,128,139,35,82,214,23,122,251,158,125,59,202,34,133,218,163,211,141,128,52,202,214,218,224,76,39,180,70,22,128,30,117,97,145,80,167,69,166,88,23,167,171,217,239,72,161,1,219,81,124,175,44,183,223,242,1,227,170,170,245,78,22,216,13,221,233,88,174,228,73,221,150,242,79,225,166,136,37,108,240,152,187,109,79,61,131,189,120,142,7,178,71,104,6,167,27,16,5,130,253,253,127,0,38,182,211,47,68,3,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateExecuteImportExcelDataProcessMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("0485fb01-477a-4349-99e0-e16f5cbf3b0f"),
				Name = "ExecuteImportExcelDataProcess",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("81de6b2e-307d-4033-9533-6c9c5b042b56"),
				Name = "rows",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string[][]",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,201,78,195,48,16,61,83,169,255,96,229,148,74,81,5,231,82,36,212,5,130,88,42,33,196,165,23,55,158,22,23,199,142,198,78,23,85,253,119,198,141,211,13,232,197,242,204,123,126,51,243,60,114,26,163,89,90,214,237,50,93,42,213,98,155,102,227,10,193,149,168,59,205,198,182,217,120,54,179,84,79,77,108,29,74,61,107,15,13,230,220,197,209,216,109,174,183,116,220,208,49,118,239,142,163,35,152,89,190,0,38,184,227,76,230,133,65,199,10,52,25,88,27,37,108,40,21,188,242,28,18,54,88,101,160,210,29,158,138,86,139,234,84,226,108,110,38,158,193,186,44,170,224,29,179,79,114,209,9,233,1,77,89,252,193,218,229,143,168,161,248,63,154,163,208,26,241,23,28,107,242,136,35,209,29,32,121,194,52,44,89,95,102,78,26,205,113,125,91,201,38,204,76,230,144,185,187,184,114,107,19,157,12,68,163,158,196,219,100,199,57,31,40,97,222,247,26,180,35,148,57,149,232,75,91,40,190,238,25,85,230,122,176,146,214,121,235,46,193,65,225,29,20,181,4,34,21,160,157,156,202,140,251,166,43,162,151,184,136,7,13,239,83,149,73,181,128,21,189,58,203,4,94,143,23,254,177,151,173,175,1,169,255,248,232,187,235,254,178,47,200,121,192,14,193,137,57,47,70,120,244,16,236,221,121,211,106,61,64,52,104,107,206,89,42,48,31,129,11,64,47,236,155,59,138,104,145,183,244,207,247,69,225,107,139,82,1,182,235,91,154,231,32,36,119,16,22,226,201,76,226,176,137,201,126,219,146,227,101,242,197,62,44,96,207,104,77,174,146,1,237,79,131,223,182,224,25,180,171,119,103,112,175,68,36,227,125,54,16,126,173,91,171,243,3,57,105,246,237,140,3,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateLogInfoMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("dbdf9a53-91fa-490e-b61c-4d8602ffdde6"),
				Name = "LogInfo",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				CreatedInPackageId = new Guid("811fcb66-130b-4d85-9d3f-7b0df7ea2049"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("caa17fc3-34bb-4a6c-ac69-72493042db65"),
				Name = "message",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("811fcb66-130b-4d85-9d3f-7b0df7ea2049")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,203,76,211,112,173,72,78,205,9,45,201,204,201,44,201,76,45,214,243,201,79,87,80,180,85,200,43,205,201,209,84,168,230,229,226,196,148,215,243,204,75,203,215,200,77,45,46,78,76,79,213,180,230,229,170,5,0,224,225,217,64,71,0,0,0 };
			return method;
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ImportExcelLookupProcess(userConnection);
		}

		public override object Clone() {
			return new ImportExcelLookupProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"));
		}

		#endregion

	}

	#endregion

	#region Class: ImportExcelLookupProcess

	/// <exclude/>
	public class ImportExcelLookupProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ImportExcelLookupProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ImportExcelLookupProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ImportExcelLookupProcess";
			SchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6");
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
				return new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ImportExcelLookupProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ImportExcelLookupProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid ExcelImportId {
			get;
			set;
		}

		public virtual Object LookupEntities {
			get;
			set;
		}

		public virtual Object ImportExcelData {
			get;
			set;
		}

		public virtual bool IsSyncLookupConflicts {
			get;
			set;
		}

		public virtual bool IsPrimaryDisplayColumnExists {
			get;
			set;
		}

		public virtual string SelectedIdentificationColumns {
			get;
			set;
		}

		public virtual int NameColumnIndex {
			get;
			set;
		}

		public virtual Object Captions {
			get;
			set;
		}

		public virtual string FileName {
			get;
			set;
		}

		public virtual string SchemaName {
			get;
			set;
		}

		public virtual int ImportMode {
			get;
			set;
		}

		public virtual bool IsOnlyErrorsMode {
			get;
			set;
		}

		public virtual Object HeaderNames {
			get;
			set;
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
					SchemaElementUId = new Guid("a377f05b-f5de-414d-8be3-1897a148bb94"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("fee8d430-0d34-47bd-9381-539a86d3e1f1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _importExcelLookupScript;
		public ProcessScriptTask ImportExcelLookupScript {
			get {
				return _importExcelLookupScript ?? (_importExcelLookupScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ImportExcelLookupScript",
					SchemaElementUId = new Guid("2b2a85f6-eeb3-4fa0-95a6-8fa8274aeebb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ImportExcelLookupScriptExecute,
				});
			}
		}

		private LocalizableString _addNewLookupRecordLocalizableString;
		public LocalizableString AddNewLookupRecordLocalizableString {
			get {
				return _addNewLookupRecordLocalizableString ?? (_addNewLookupRecordLocalizableString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.AddNewLookupRecordLocalizableString.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ImportExcelLookupScript.SchemaElementUId] = new Collection<ProcessFlowElement> { ImportExcelLookupScript };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ImportExcelLookupScript", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ImportExcelLookupScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("ExcelImportId")) {
				writer.WriteValue("ExcelImportId", ExcelImportId, Guid.Empty);
			}
			if (LookupEntities != null) {
				if (LookupEntities.GetType().IsSerializable ||
					LookupEntities.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("LookupEntities", LookupEntities, null);
				}
			}
			if (ImportExcelData != null) {
				if (ImportExcelData.GetType().IsSerializable ||
					ImportExcelData.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ImportExcelData", ImportExcelData, null);
				}
			}
			if (!HasMapping("IsSyncLookupConflicts")) {
				writer.WriteValue("IsSyncLookupConflicts", IsSyncLookupConflicts, false);
			}
			if (!HasMapping("IsPrimaryDisplayColumnExists")) {
				writer.WriteValue("IsPrimaryDisplayColumnExists", IsPrimaryDisplayColumnExists, false);
			}
			if (!HasMapping("SelectedIdentificationColumns")) {
				writer.WriteValue("SelectedIdentificationColumns", SelectedIdentificationColumns, null);
			}
			if (!HasMapping("NameColumnIndex")) {
				writer.WriteValue("NameColumnIndex", NameColumnIndex, 0);
			}
			if (Captions != null) {
				if (Captions.GetType().IsSerializable ||
					Captions.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Captions", Captions, null);
				}
			}
			if (!HasMapping("FileName")) {
				writer.WriteValue("FileName", FileName, null);
			}
			if (!HasMapping("SchemaName")) {
				writer.WriteValue("SchemaName", SchemaName, null);
			}
			if (!HasMapping("ImportMode")) {
				writer.WriteValue("ImportMode", ImportMode, 0);
			}
			if (!HasMapping("IsOnlyErrorsMode")) {
				writer.WriteValue("IsOnlyErrorsMode", IsOnlyErrorsMode, false);
			}
			if (HeaderNames != null) {
				if (HeaderNames.GetType().IsSerializable ||
					HeaderNames.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("HeaderNames", HeaderNames, null);
				}
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
			MetaPathParameterValues.Add("a33a32de-c086-4f92-b20a-2ecb38197547", () => ExcelImportId);
			MetaPathParameterValues.Add("32fcd137-5c32-49ff-b621-5ded5a21588e", () => LookupEntities);
			MetaPathParameterValues.Add("bc384458-adcd-49cc-950e-156042eeee69", () => ImportExcelData);
			MetaPathParameterValues.Add("38440d1b-38d4-4040-9d9f-c78538332ba0", () => IsSyncLookupConflicts);
			MetaPathParameterValues.Add("efcad133-b57b-4e7c-907c-b9b137a0328c", () => IsPrimaryDisplayColumnExists);
			MetaPathParameterValues.Add("b15e2c93-c5cd-4c7a-9267-ecbd73d1a51b", () => SelectedIdentificationColumns);
			MetaPathParameterValues.Add("5aa0b7c4-fad6-4370-a377-741952e2a5cf", () => NameColumnIndex);
			MetaPathParameterValues.Add("1d491fcf-7aee-4b68-8c5f-ea6a0e9d34bf", () => Captions);
			MetaPathParameterValues.Add("6bb6fbcc-df17-4639-ae28-867e618449a4", () => FileName);
			MetaPathParameterValues.Add("86b91419-8758-4026-b1af-32973690a3cb", () => SchemaName);
			MetaPathParameterValues.Add("d5788ce6-58ec-4f86-9f22-23bca9e168d9", () => ImportMode);
			MetaPathParameterValues.Add("174730ca-2f45-440f-a606-a20e8f607ddb", () => IsOnlyErrorsMode);
			MetaPathParameterValues.Add("a8ad5735-6f37-4d58-977a-852f8c0e76b2", () => HeaderNames);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "ExcelImportId":
					if (!hasValueToRead) break;
					ExcelImportId = reader.GetValue<System.Guid>();
				break;
				case "LookupEntities":
					if (!hasValueToRead) break;
					LookupEntities = reader.GetSerializableObjectValue();
				break;
				case "ImportExcelData":
					if (!hasValueToRead) break;
					ImportExcelData = reader.GetSerializableObjectValue();
				break;
				case "IsSyncLookupConflicts":
					if (!hasValueToRead) break;
					IsSyncLookupConflicts = reader.GetValue<System.Boolean>();
				break;
				case "IsPrimaryDisplayColumnExists":
					if (!hasValueToRead) break;
					IsPrimaryDisplayColumnExists = reader.GetValue<System.Boolean>();
				break;
				case "SelectedIdentificationColumns":
					if (!hasValueToRead) break;
					SelectedIdentificationColumns = reader.GetValue<System.String>();
				break;
				case "NameColumnIndex":
					if (!hasValueToRead) break;
					NameColumnIndex = reader.GetValue<System.Int32>();
				break;
				case "Captions":
					if (!hasValueToRead) break;
					Captions = reader.GetSerializableObjectValue();
				break;
				case "FileName":
					if (!hasValueToRead) break;
					FileName = reader.GetValue<System.String>();
				break;
				case "SchemaName":
					if (!hasValueToRead) break;
					SchemaName = reader.GetValue<System.String>();
				break;
				case "ImportMode":
					if (!hasValueToRead) break;
					ImportMode = reader.GetValue<System.Int32>();
				break;
				case "IsOnlyErrorsMode":
					if (!hasValueToRead) break;
					IsOnlyErrorsMode = reader.GetValue<System.Boolean>();
				break;
				case "HeaderNames":
					if (!hasValueToRead) break;
					HeaderNames = reader.GetSerializableObjectValue();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ImportExcelLookupScriptExecute(ProcessExecutingContext context) {
			var entities = LookupEntities as List<Tuple<Guid, string, string, string, string, 
					KeyValuePair<Guid, string>, Dictionary<int, Collection<int>>>>;
			if (entities != null) {
				LogInfo(string.Format("\t{0}\t{1}\t\tSave new {2} lookups, start", FileName, ExcelImportId, entities.Count));
				var excelImportIdParameter = Column.Parameter(ExcelImportId);
				var entitySchemaManager = UserConnection.EntitySchemaManager;
				var entitySchemas = new Dictionary<Guid, EntitySchema>();
				foreach (var entity in entities) {
					Guid guid = Guid.NewGuid();
					string valueInBpm = entity.Item2;
					Guid entitySchemaUId = entity.Item6.Key;
					EntitySchema entitySchema;
					if (!entitySchemas.ContainsKey(entitySchemaUId)) {
						entitySchema = entitySchemaManager.GetInstanceByUId(entitySchemaUId);
						entitySchemas.Add(entitySchemaUId, entitySchema);
					} else {
						entitySchema = entitySchemas[entitySchemaUId];
					}
					bool validateRequired = false;
					var lookupEntity = entitySchema.CreateEntity(UserConnection);
					lookupEntity.SetDefColumnValues();
					lookupEntity.SetColumnValue(entitySchema.PrimaryColumn.Name, guid);
					lookupEntity.SetColumnValue(entitySchema.PrimaryDisplayColumn.Name, valueInBpm);
					lookupEntity.Save(validateRequired);
					LogExcelImportLog(entity);
				}
				LogInfo(string.Format("\t{0}\t{1}\t\tSave new {2} lookups, end", FileName, ExcelImportId, entities.Count));
			}
			var rows = ImportExcelData as string[][];
			ExecuteImportExcelDataProcess(rows);
			return true;
		}

		public virtual void LogExcelImportLog(Tuple<Guid, string, string, string, string, KeyValuePair<Guid, string>, Dictionary<int, Collection<int>>> entity) {
			if (IsSyncLookupConflicts) {
				return;
			}
			var guid = Guid.NewGuid();
			var nowParameter = new QueryParameter("now", DateTime.Now, "DateTime");
			var currentUserContactIdParameter = new QueryParameter("currentUserId",
				UserConnection.CurrentUser.ContactId);
			string lookup = entity.Item5;
			string lookupValue = entity.Item2;
			string message = string.Format(AddNewLookupRecordLocalizableString, 
					"\"" + lookup + "\"",
					"\"" + lookupValue + "\"");
			new Insert(UserConnection)
				.Into("ExcelImportLog")
				.Set("Id", Column.Parameter(guid))
				.Set("CreatedOn", nowParameter)
				.Set("CreatedById", currentUserContactIdParameter)
				.Set("ModifiedOn", nowParameter)
				.Set("ModifiedById", currentUserContactIdParameter)
				.Set("MessageText", Column.Parameter(message))
				.Set("ExcelImportId", Column.Parameter(ExcelImportId))
				.Execute();
		}

		public virtual void ExecuteImportExcelDataProcess(string[][] rows) {
			if(rows == null) {
				return;
			}
			LogInfo(string.Format("\t{0}\t{1}\t\tStarting save data import process", FileName, ExcelImportId));
			string jobName = "ImportExcelData";
			string jobGroup = "ImportExcelDataGroup";
			string processName = "ImportExcelDataProcess";
			var processParameters = new Dictionary<string, object>() {
				{"ExcelImportId", ExcelImportId},
				{"ImportExcelData", rows},
				{"IsPrimaryDisplayColumnExists", IsPrimaryDisplayColumnExists},
				{"SelectedIdentificationColumns", SelectedIdentificationColumns},
				{"NameColumnIndex", NameColumnIndex},
				{"Captions", Captions},
				{"FileName", FileName},
				{"SchemaName", SchemaName},
				{"ImportMode", ImportMode},
				{"IsOnlyErrorsMode", IsOnlyErrorsMode},
				{"HeaderNames", HeaderNames}
			};
			AppScheduler.ScheduleImmediateProcessJob(jobName, jobGroup, processName,
				UserConnection.Workspace.Name, UserConnection.CurrentUser.Name, processParameters);
		}

		public virtual void LogInfo(string message) {
			if(ExcelUtilities.Log != null) {
				ExcelUtilities.Log.Info(message);
			}
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
			var cloneItem = (ImportExcelLookupProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.LookupEntities = LookupEntities;
			cloneItem.ImportExcelData = ImportExcelData;
			cloneItem.Captions = Captions;
			cloneItem.HeaderNames = HeaderNames;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

