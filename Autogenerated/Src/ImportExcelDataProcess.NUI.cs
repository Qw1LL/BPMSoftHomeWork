namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.ImportExcelData;
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
	using System.ComponentModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;

	#region Class: ImportExcelDataProcessSchema

	/// <exclude/>
	public class ImportExcelDataProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ImportExcelDataProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ImportExcelDataProcessSchema(ImportExcelDataProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ImportExcelDataProcess";
			UId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64");
			CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145");
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
			RealUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64");
			Version = 0;
			PackageUId = new Guid("a7d9c356-450c-46d7-bc85-72dca4e280ba");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateIsPrimaryDisplayColumnExistsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9a4361f7-ca56-4c89-a1bb-1c5f8f5d53f0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"IsPrimaryDisplayColumnExists",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSelectedIdentificationColumnsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1a42fa28-bcfb-48ee-a10b-66e8962144f8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"SelectedIdentificationColumns",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNameColumnIndexParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("04e7f954-858c-4d11-8095-05a47ffe3066"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"NameColumnIndex",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCaptionsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3f3f43c6-d874-4769-8327-eea1ac82943e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"Captions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateExcelImportIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1cf3f54f-a7eb-419b-9ca6-896f1097a9b0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"ExcelImportId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateFileNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("84b1fb8a-a77a-4385-89dd-66088e2965d2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"FileName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSchemaNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("53049422-8db2-4323-b9bb-8ecf8ab0801a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"SchemaName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportModeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("89f55192-d503-40b4-93a4-cf6fa6a472a3"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"ImportMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsOnlyErrorsModeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c73b974a-5e91-4d65-8d8f-f38fefcfefc8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"IsOnlyErrorsMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateHeaderNamesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a8ec71b6-9125-42fa-b2c6-baad509c6725"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"HeaderNames",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportExcelDataParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3ca610ee-f99e-4a6e-9441-e9c5d7bdd6e0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"ImportExcelData",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportRowCountParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("cbb05c77-81a3-4d4f-b084-319b00d9858d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"ImportRowCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateIsPrimaryDisplayColumnExistsParameter());
			Parameters.Add(CreateSelectedIdentificationColumnsParameter());
			Parameters.Add(CreateNameColumnIndexParameter());
			Parameters.Add(CreateCaptionsParameter());
			Parameters.Add(CreateExcelImportIdParameter());
			Parameters.Add(CreateFileNameParameter());
			Parameters.Add(CreateSchemaNameParameter());
			Parameters.Add(CreateImportModeParameter());
			Parameters.Add(CreateIsOnlyErrorsModeParameter());
			Parameters.Add(CreateHeaderNamesParameter());
			Parameters.Add(CreateImportExcelDataParameter());
			Parameters.Add(CreateImportRowCountParameter());
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
			ProcessSchemaScriptTask saveimportdata = CreateSaveImportDataScriptTask();
			FlowElements.Add(saveimportdata);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateUpdateItemLocalizableStringLocalizableString());
			LocalizableStrings.Add(CreateAddItemLocalizableStringLocalizableString());
			LocalizableStrings.Add(CreateNotUniqueRecordLocalizableString());
			LocalizableStrings.Add(CreateErrorMessageLocalizableString());
			LocalizableStrings.Add(CreateErrorAddItemLocalizableStringLocalizableString());
			LocalizableStrings.Add(CreateImportSuccessMessageLocalizableString());
			LocalizableStrings.Add(CreateImportErrorMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateUpdateItemLocalizableStringLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("ccbf6331-9b8f-4c31-b9b9-e9691351ac69"),
				Name = "UpdateItemLocalizableString",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateAddItemLocalizableStringLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("006487b0-19b1-4090-af23-4eb6601a711d"),
				Name = "AddItemLocalizableString",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateNotUniqueRecordLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("b19f1299-23d4-44a1-8806-75f90952a493"),
				Name = "NotUniqueRecord",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("e86114bf-be71-4e8e-9b53-0b97b089da78"),
				Name = "ErrorMessage",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateErrorAddItemLocalizableStringLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("fdd713f7-fec7-4e53-9f67-c0346c36e5cf"),
				Name = "ErrorAddItemLocalizableString",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateImportSuccessMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("d5f6cd85-5a1d-4143-8838-bfc00be73318"),
				Name = "ImportSuccessMessage",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateImportErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("d50a2059-1cbc-4518-a080-2252f50fdcf4"),
				Name = "ImportErrorMessage",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("3f7496dc-09ea-4bbe-a1d6-1aa6acd5fd6a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CurveCenterPosition = new Point(440, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b485fa8c-08ec-481c-9267-63a57b159e32"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3ea486ab-5a7e-4d56-8161-9b07e98876c4"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("782b29fa-1d4e-4449-91ad-627c99ee22a9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CurveCenterPosition = new Point(440, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3ea486ab-5a7e-4d56-8161-9b07e98876c4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d01663b7-8c62-41be-b627-fff3d92a6896"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("23c30c37-3b35-41c0-b31c-018e48b9a304"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(1107, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("e9c6ef1d-9b34-4e60-a22c-524d6edf2df1"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("23c30c37-3b35-41c0-b31c-018e48b9a304"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(1078, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("b485fa8c-08ec-481c-9267-63a57b159e32"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e9c6ef1d-9b34-4e60-a22c-524d6edf2df1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"Start1",
				Position = new Point(183, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("d01663b7-8c62-41be-b627-fff3d92a6896"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e9c6ef1d-9b34-4e60-a22c-524d6edf2df1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSaveImportDataScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("3ea486ab-5a7e-4d56-8161-9b07e98876c4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e9c6ef1d-9b34-4e60-a22c-524d6edf2df1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"SaveImportData",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(372, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,85,93,111,218,64,16,124,118,164,252,135,171,159,140,112,172,180,143,144,164,106,41,105,92,1,173,2,149,42,17,30,46,246,26,172,218,119,232,124,36,161,145,255,123,247,62,140,237,152,68,149,138,132,133,239,102,231,102,231,118,151,9,95,135,44,225,94,33,69,202,214,193,53,23,57,149,158,123,39,159,207,75,124,188,199,199,157,156,211,7,32,105,190,229,66,146,152,74,74,182,130,71,80,20,62,41,36,21,210,245,201,117,154,193,140,230,224,147,241,83,4,89,168,177,97,220,235,13,79,79,30,168,32,130,63,22,228,146,152,117,13,249,162,120,104,65,204,193,203,213,114,133,208,148,73,34,185,164,217,45,226,71,124,135,175,151,58,54,152,0,91,203,141,133,24,41,16,55,81,231,184,39,197,158,60,159,158,56,234,68,96,50,149,251,121,180,129,156,78,41,163,107,16,136,250,89,128,24,113,198,32,146,41,103,193,184,11,26,30,137,199,192,35,116,193,87,144,33,67,7,88,4,159,247,42,123,207,236,171,159,189,138,39,149,144,155,99,94,176,4,35,1,84,130,217,243,218,194,14,209,17,207,118,57,195,36,89,146,174,145,128,193,35,153,164,133,188,208,30,142,244,174,217,188,242,14,65,27,160,49,8,165,66,121,126,211,120,67,191,117,180,49,253,170,29,80,57,217,8,15,244,154,130,37,92,16,79,123,207,98,120,210,126,219,159,23,205,112,187,216,239,247,244,69,52,114,104,165,208,81,239,33,158,132,150,218,240,150,195,54,129,18,212,86,183,212,192,213,1,167,172,54,164,138,228,224,123,80,249,109,188,12,174,49,204,222,87,205,172,205,115,210,4,147,172,89,222,161,218,93,150,217,92,156,102,34,182,116,70,77,105,53,219,176,139,159,1,196,166,252,17,41,197,238,24,38,44,38,156,255,222,109,23,251,173,226,171,149,180,118,116,96,169,30,173,234,8,62,197,177,77,200,44,232,148,74,115,119,64,163,13,177,77,190,92,169,150,66,151,117,103,217,228,170,214,113,156,123,206,51,82,236,34,213,224,40,194,84,105,136,82,60,132,251,173,18,246,143,181,133,223,46,90,99,172,118,214,146,86,118,58,157,54,238,247,13,88,39,87,146,136,74,165,90,21,203,86,117,5,129,42,212,36,162,103,209,2,158,148,163,118,126,125,227,41,243,220,33,193,145,132,106,237,217,22,141,21,83,160,192,26,108,135,221,88,8,46,208,60,149,227,132,71,52,75,255,208,251,12,230,26,228,27,169,206,97,192,217,119,247,206,117,73,159,64,48,181,172,125,162,150,218,39,50,83,23,250,128,26,87,169,54,208,9,95,55,70,38,190,121,86,167,175,195,13,161,50,4,191,175,91,242,159,99,124,252,107,252,99,17,126,159,13,200,243,135,242,245,113,238,215,249,234,201,94,146,36,101,52,203,76,233,116,108,246,186,115,26,59,170,61,223,123,42,189,143,47,110,196,254,77,52,108,243,187,51,223,127,193,84,171,214,156,131,163,156,115,83,130,111,177,30,88,148,243,115,96,241,45,228,56,49,144,170,186,25,157,250,233,201,63,120,142,110,190,101,59,146,191,101,54,254,69,194,34,205,33,152,241,199,96,193,77,65,122,238,30,63,103,211,233,89,28,147,155,155,65,158,15,138,34,72,146,196,237,233,59,17,32,119,130,153,9,243,23,220,40,34,12,221,7,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
			Methods.Add(CreateCreateItemMethod());
			Methods.Add(CreateSendRemindingMethod());
			Methods.Add(CreateLogInfoMethod());
			Methods.Add(CreateLogExcelImportLogMethod());
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d097e45e-402b-4591-8e36-e9a9d7f1fdb6"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("4c0c881d-c893-46c9-ae2c-25eea7d1fea3"),
				Name = "BPMSoft.Core.DB",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a0a7e2c2-5457-4758-9b94-ea539f7a0bad"),
				Name = "BPMSoft.Common.Json",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3e1b3f83-4e55-4a35-b4dc-9f2dea44c4b6"),
				Name = "System.Globalization",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("186f725e-b39f-4507-8a48-6296e282151a"),
				Name = "System.Text.RegularExpressions",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("11275c13-d741-4c6b-b3a8-d161309f9823"),
				Name = "System.Text",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ba6abfe0-3eeb-463e-a1da-a47f7d0f18c8"),
				Name = "System.ComponentModel",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("614c8862-a10c-426b-a599-7ea3b968f56d"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("383e9e4b-44c4-4b84-8b49-26913e44b669"),
				Name = "BPMSoft.Configuration.ImportExcelData",
				Alias = "",
				CreatedInPackageId = new Guid("811fcb66-130b-4d85-9d3f-7b0df7ea2049")
			});
		}

		protected virtual SchemaMethod CreateCreateItemMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("d27dab11-9089-48b5-86f4-c2618af25368"),
				Name = "CreateItem",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				ResultValueTypeName = "bool"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("d64f878d-febb-4e9c-a0ce-d29590025d60"),
				Name = "row",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string[]",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("9822e0b9-20d7-443b-a191-d27bae29c472"),
				Name = "entitySchema",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "EntitySchema",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("057c7d29-42fc-4930-a4c9-c823e5a4ddd0"),
				Name = "entitySchemaManager",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "EntitySchemaManager",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("67bde463-3490-4770-a508-2419a46af7bc"),
				Name = "columnsConfig",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "List<ExcelColumnConfig>",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,88,75,111,219,70,16,62,203,128,255,195,70,135,152,2,20,42,45,80,4,173,31,129,45,201,169,130,248,81,219,105,15,134,15,107,114,101,19,229,67,93,46,109,171,77,128,198,41,122,41,208,2,253,37,110,81,3,110,131,52,127,129,250,71,157,125,144,90,138,164,69,41,174,15,18,201,221,121,207,55,179,67,158,97,138,124,236,17,180,138,122,225,46,117,60,76,135,29,39,28,184,120,216,14,220,200,243,187,23,78,200,66,244,20,209,224,252,112,27,40,229,114,207,183,201,197,17,250,2,133,140,58,254,137,217,245,6,108,184,188,184,112,198,229,5,231,187,152,2,41,35,20,228,250,228,28,125,21,17,58,76,23,141,58,144,212,155,168,131,25,57,112,60,98,190,100,214,118,112,222,68,245,100,165,222,80,178,172,136,82,226,179,151,33,161,237,192,103,216,98,61,123,154,112,141,167,103,131,26,197,236,19,139,57,129,111,182,199,219,102,42,51,209,231,132,155,132,89,167,196,6,217,125,236,134,68,173,99,215,237,217,192,229,244,29,11,115,49,34,12,225,58,37,61,127,211,113,121,252,24,141,56,245,226,66,23,200,216,16,57,140,120,234,118,21,113,86,54,220,7,201,30,54,219,148,128,159,114,207,200,90,151,216,161,211,11,255,148,175,221,201,117,67,167,220,194,62,62,33,180,153,85,199,179,198,229,230,120,101,42,53,67,123,182,90,202,26,44,136,205,117,91,237,102,84,154,207,8,83,184,145,187,92,155,209,224,250,90,173,246,30,58,252,228,201,227,39,159,125,126,132,58,59,139,11,78,31,25,15,20,98,122,225,118,228,186,59,84,32,199,216,39,46,4,128,216,5,65,246,195,70,3,253,176,184,80,19,249,81,251,68,217,18,130,169,207,67,200,106,135,64,28,29,236,58,223,147,41,194,16,14,209,243,117,74,49,199,171,16,122,74,176,77,40,55,156,139,251,82,123,2,210,23,128,255,21,105,243,90,194,16,10,215,199,22,140,35,104,38,41,150,123,156,161,31,64,186,173,83,100,8,60,171,144,251,121,79,164,147,53,169,42,183,205,237,153,196,209,166,227,219,242,86,210,108,12,183,8,195,187,152,157,26,82,207,97,221,83,11,245,35,243,32,216,23,162,33,57,2,18,220,54,225,13,84,182,40,103,16,175,69,194,20,107,59,125,163,200,18,158,222,90,141,167,51,101,94,65,143,193,3,212,106,197,191,143,222,196,215,40,126,23,223,160,248,207,209,47,241,31,163,31,227,171,248,125,252,30,238,97,253,67,252,111,252,110,244,27,138,255,146,151,27,184,185,134,205,203,248,102,244,19,60,253,19,95,141,126,134,43,112,127,0,206,155,209,155,209,219,209,37,252,95,130,180,183,163,95,71,151,32,22,1,233,85,252,55,40,185,126,202,77,169,85,40,208,164,158,129,218,130,186,119,124,81,175,181,218,235,36,16,228,194,34,174,116,242,107,236,70,156,135,119,189,196,197,35,65,93,90,69,105,152,244,213,219,11,169,60,180,57,20,104,66,21,20,10,247,198,153,229,201,201,224,84,192,101,99,40,234,179,80,49,148,228,139,32,248,54,26,28,12,7,68,161,177,86,94,178,147,209,82,85,90,147,177,4,217,174,173,199,42,215,4,171,90,181,71,250,4,26,182,69,36,227,50,26,43,9,163,227,238,199,53,202,156,153,105,183,228,58,202,115,157,166,183,200,4,45,195,121,249,229,253,146,107,44,20,7,248,133,131,45,228,98,13,73,86,76,39,207,21,73,253,141,195,78,211,51,49,76,216,106,114,179,29,120,3,76,29,232,155,60,213,102,247,187,8,187,205,132,36,111,114,209,92,32,226,148,242,76,98,65,173,55,228,53,27,78,32,227,237,25,74,116,28,60,109,173,36,164,16,182,73,210,130,163,147,107,17,192,207,11,6,192,69,62,67,107,162,77,41,251,72,149,80,23,80,85,8,244,109,145,86,8,230,182,150,213,183,70,83,224,203,225,227,35,30,16,46,210,214,162,190,242,44,114,236,53,40,35,45,69,42,5,105,46,210,100,188,70,4,218,97,197,80,148,133,64,118,4,73,105,148,58,147,162,91,116,218,9,205,247,161,88,232,205,168,173,146,249,121,242,94,33,235,211,115,94,92,77,50,129,210,35,238,16,255,141,71,197,76,5,145,121,203,135,215,14,41,45,28,244,240,225,212,65,88,21,151,62,71,107,211,145,88,220,164,129,215,217,200,233,153,2,234,220,144,42,225,45,204,134,80,104,217,109,181,30,61,226,211,166,240,230,182,183,154,236,196,53,40,160,43,154,186,74,187,97,58,80,241,23,170,74,231,127,153,74,153,228,249,42,163,16,157,183,193,114,108,173,236,233,98,65,85,78,174,59,223,37,216,166,160,45,157,64,238,21,74,208,38,56,160,224,15,64,37,134,159,84,191,52,72,159,245,9,235,144,190,166,32,52,100,21,101,72,180,125,163,46,94,72,185,25,230,54,57,231,87,121,244,131,174,130,215,4,136,87,223,129,33,208,87,207,161,92,144,118,40,212,90,58,78,117,54,51,77,129,218,95,158,100,210,103,220,12,231,120,218,21,1,200,236,109,19,120,175,242,6,1,101,232,213,43,40,47,113,187,21,216,32,104,21,125,202,59,68,225,176,168,105,108,36,131,162,62,132,231,154,89,190,120,138,38,198,177,247,105,251,154,203,34,213,180,128,61,27,136,162,129,184,52,185,99,99,160,134,64,83,130,39,237,216,41,103,214,29,207,176,11,52,10,17,85,204,187,125,244,86,104,47,156,168,201,255,55,72,203,23,247,74,29,113,182,121,249,158,58,228,44,19,177,94,91,202,202,187,62,164,171,246,205,138,88,155,177,121,22,181,204,44,70,51,88,19,188,92,22,175,70,6,215,160,111,236,15,67,176,205,76,62,246,37,229,103,7,209,49,188,168,51,88,18,98,147,125,100,195,77,234,120,71,80,153,7,226,147,95,152,84,157,80,3,192,134,116,88,196,88,50,151,154,104,169,185,212,104,162,32,98,66,98,99,182,250,77,63,77,242,19,102,103,157,63,26,82,140,94,212,194,158,132,178,200,34,169,159,219,63,163,126,193,50,87,112,59,196,2,108,186,137,62,245,136,108,121,21,28,66,110,59,114,89,196,167,182,126,144,124,101,85,75,128,205,219,62,153,74,34,253,43,133,37,151,246,7,160,3,198,194,228,92,217,35,39,228,34,205,73,38,42,245,195,166,121,4,39,97,86,177,185,29,121,199,132,110,6,212,195,76,61,40,251,247,9,212,37,102,1,29,87,128,218,209,226,94,96,134,74,128,230,252,172,137,208,89,231,74,200,113,16,184,13,126,12,61,168,124,14,85,178,204,210,24,197,17,58,131,77,210,146,59,209,247,49,18,228,144,165,241,226,51,232,237,176,69,9,100,210,151,159,212,255,3,114,161,171,140,163,24,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateSendRemindingMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("bc0df034-fe1f-479d-8895-3302db57a211"),
				Name = "SendReminding",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("7cdb378a-d9d9-4190-b3dd-edb4c7a01322"),
				Name = "message",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,61,142,189,10,194,48,20,133,119,193,119,8,153,90,8,69,29,237,102,107,161,32,34,150,110,89,66,123,45,23,154,68,110,46,162,148,190,187,65,173,203,89,206,119,126,78,126,168,221,205,39,129,9,221,144,85,158,172,225,68,106,158,54,115,148,109,20,205,13,184,94,16,88,116,125,132,132,133,16,204,0,123,161,229,180,155,181,148,74,84,56,194,217,88,80,226,248,236,96,172,237,221,19,215,189,90,216,52,205,215,171,235,210,208,0,61,128,90,198,17,25,33,100,5,129,97,248,219,135,215,133,124,23,131,73,27,128,10,239,28,116,140,222,41,33,191,197,159,141,210,176,249,113,241,192,178,147,191,1,219,192,214,246,209,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateLogInfoMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("a01dec9a-023e-4323-b5b2-dda71fad05e6"),
				Name = "LogInfo",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("df3ed52c-43ff-4c7e-8c78-880167a52d8e"),
				Name = "message",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,203,76,83,208,112,173,72,78,205,9,45,201,204,201,44,201,76,45,214,243,201,79,87,80,180,85,200,43,205,201,209,84,168,230,229,226,196,148,215,243,204,75,203,215,200,77,45,46,78,76,79,213,180,230,229,170,5,0,51,238,221,68,72,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateLogExcelImportLogMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("aad222b4-7528-45c2-9e78-52ac71f3fca1"),
				Name = "LogExcelImportLog",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("a26b8482-c202-46c5-8b7c-01a05e3054d9"),
				Name = "message",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("f69ac4c6-8250-46a3-a0d4-8df5a71d9efa"),
				Name = "name",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,145,221,106,195,48,12,133,175,87,232,59,24,95,37,16,252,2,99,55,203,74,9,108,217,198,218,7,48,182,22,12,141,60,28,165,73,223,126,114,187,252,148,133,142,93,9,172,239,28,73,199,71,29,4,250,238,77,7,93,3,65,16,15,2,161,19,239,45,132,211,248,152,72,70,100,38,158,52,193,206,213,160,246,100,74,223,101,66,14,47,50,189,95,175,142,236,101,218,16,0,105,223,64,200,61,146,54,84,216,191,204,103,154,194,202,108,189,186,251,145,35,24,114,30,85,62,1,106,116,29,38,86,173,179,108,188,229,162,74,232,98,77,98,47,78,42,144,37,148,92,219,165,60,64,21,72,62,145,155,222,192,161,168,191,124,160,103,95,201,115,231,3,40,145,113,15,145,251,67,91,163,154,54,141,163,210,9,202,3,240,249,246,21,153,157,103,248,139,120,60,157,253,110,102,147,142,162,23,111,221,167,187,233,59,32,255,52,134,166,209,21,236,160,167,165,235,234,75,123,118,224,44,158,229,64,174,128,153,176,228,254,18,143,92,47,216,166,7,211,18,240,79,125,3,17,153,73,69,130,2,0,0 };
			return method;
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ImportExcelDataProcess(userConnection);
		}

		public override object Clone() {
			return new ImportExcelDataProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"));
		}

		#endregion

	}

	#endregion

	#region Class: ImportExcelDataProcess

	/// <exclude/>
	public class ImportExcelDataProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ImportExcelDataProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ImportExcelDataProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ImportExcelDataProcess";
			SchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64");
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
				return new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ImportExcelDataProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ImportExcelDataProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

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

		public virtual Guid ExcelImportId {
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

		public virtual Object ImportExcelData {
			get;
			set;
		}

		public virtual int ImportRowCount {
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
					SchemaElementUId = new Guid("b485fa8c-08ec-481c-9267-63a57b159e32"),
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
					SchemaElementUId = new Guid("d01663b7-8c62-41be-b627-fff3d92a6896"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _saveImportData;
		public ProcessScriptTask SaveImportData {
			get {
				return _saveImportData ?? (_saveImportData = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SaveImportData",
					SchemaElementUId = new Guid("3ea486ab-5a7e-4d56-8161-9b07e98876c4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SaveImportDataExecute,
				});
			}
		}

		private LocalizableString _updateItemLocalizableString;
		public LocalizableString UpdateItemLocalizableString {
			get {
				return _updateItemLocalizableString ?? (_updateItemLocalizableString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.UpdateItemLocalizableString.Value"));
			}
		}

		private LocalizableString _addItemLocalizableString;
		public LocalizableString AddItemLocalizableString {
			get {
				return _addItemLocalizableString ?? (_addItemLocalizableString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.AddItemLocalizableString.Value"));
			}
		}

		private LocalizableString _notUniqueRecord;
		public LocalizableString NotUniqueRecord {
			get {
				return _notUniqueRecord ?? (_notUniqueRecord = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.NotUniqueRecord.Value"));
			}
		}

		private LocalizableString _errorMessage;
		public LocalizableString ErrorMessage {
			get {
				return _errorMessage ?? (_errorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ErrorMessage.Value"));
			}
		}

		private LocalizableString _errorAddItemLocalizableString;
		public LocalizableString ErrorAddItemLocalizableString {
			get {
				return _errorAddItemLocalizableString ?? (_errorAddItemLocalizableString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ErrorAddItemLocalizableString.Value"));
			}
		}

		private LocalizableString _importSuccessMessage;
		public LocalizableString ImportSuccessMessage {
			get {
				return _importSuccessMessage ?? (_importSuccessMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ImportSuccessMessage.Value"));
			}
		}

		private LocalizableString _importErrorMessage;
		public LocalizableString ImportErrorMessage {
			get {
				return _importErrorMessage ?? (_importErrorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ImportErrorMessage.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[SaveImportData.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveImportData };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveImportData", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "SaveImportData":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
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
			if (!HasMapping("ExcelImportId")) {
				writer.WriteValue("ExcelImportId", ExcelImportId, Guid.Empty);
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
			if (ImportExcelData != null) {
				if (ImportExcelData.GetType().IsSerializable ||
					ImportExcelData.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ImportExcelData", ImportExcelData, null);
				}
			}
			if (!HasMapping("ImportRowCount")) {
				writer.WriteValue("ImportRowCount", ImportRowCount, 0);
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
			MetaPathParameterValues.Add("9a4361f7-ca56-4c89-a1bb-1c5f8f5d53f0", () => IsPrimaryDisplayColumnExists);
			MetaPathParameterValues.Add("1a42fa28-bcfb-48ee-a10b-66e8962144f8", () => SelectedIdentificationColumns);
			MetaPathParameterValues.Add("04e7f954-858c-4d11-8095-05a47ffe3066", () => NameColumnIndex);
			MetaPathParameterValues.Add("3f3f43c6-d874-4769-8327-eea1ac82943e", () => Captions);
			MetaPathParameterValues.Add("1cf3f54f-a7eb-419b-9ca6-896f1097a9b0", () => ExcelImportId);
			MetaPathParameterValues.Add("84b1fb8a-a77a-4385-89dd-66088e2965d2", () => FileName);
			MetaPathParameterValues.Add("53049422-8db2-4323-b9bb-8ecf8ab0801a", () => SchemaName);
			MetaPathParameterValues.Add("89f55192-d503-40b4-93a4-cf6fa6a472a3", () => ImportMode);
			MetaPathParameterValues.Add("c73b974a-5e91-4d65-8d8f-f38fefcfefc8", () => IsOnlyErrorsMode);
			MetaPathParameterValues.Add("a8ec71b6-9125-42fa-b2c6-baad509c6725", () => HeaderNames);
			MetaPathParameterValues.Add("3ca610ee-f99e-4a6e-9441-e9c5d7bdd6e0", () => ImportExcelData);
			MetaPathParameterValues.Add("cbb05c77-81a3-4d4f-b084-319b00d9858d", () => ImportRowCount);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
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
				case "ExcelImportId":
					if (!hasValueToRead) break;
					ExcelImportId = reader.GetValue<System.Guid>();
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
				case "ImportExcelData":
					if (!hasValueToRead) break;
					ImportExcelData = reader.GetSerializableObjectValue();
				break;
				case "ImportRowCount":
					if (!hasValueToRead) break;
					ImportRowCount = reader.GetValue<System.Int32>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SaveImportDataExecute(ProcessExecutingContext context) {
			LogInfo(string.Format("\t{0}\t{1}\t\tSave import data process, start", FileName, ExcelImportId));
			var rows = ImportExcelData as string[][];
			int totalRowsCount = rows.Length;
			int importedRowsCount = 0;
			try {
				var entitySchemaManager = UserConnection.EntitySchemaManager;
				var entitySchema = entitySchemaManager.GetInstanceByName(SchemaName);
				var itemEntity = entitySchema.CreateEntity(UserConnection);
				var columnsConfig = new List<ExcelColumnConfig>();
				var headerNames = HeaderNames as List<string>;
				var headerCount = headerNames.Count;
				for (int index = 0; index < headerCount; index++) {
					var columnConfig = new ExcelColumnConfig() { Index = index };
					var columnName = headerNames[index];
					var itemColumn = itemEntity.Schema.Columns.FindByName(columnName);
					if (itemColumn != null) {
						columnConfig.EntityColumnName = columnName;
						columnConfig.NeedImport = true;
						columnConfig.IsLookupType = itemColumn.IsLookupType;
					}
					columnsConfig.Add(columnConfig);
				}
				foreach (string[] row in rows) {
					try {
						bool success = CreateItem(row, entitySchema, entitySchemaManager, columnsConfig);
						if (success) {
							importedRowsCount++;
						}
					} catch (Exception e) {
						string dataText = string.Join("; ", row);
						string message = string.Format(ErrorAddItemLocalizableString,
								FileName,
								"\"" + e.Message + "\"");
						string name = ErrorMessage + dataText;
						LogExcelImportLog(message, name);
					}
				}
			} catch (Exception e) {
				LogInfo(string.Format("\t{0}\t{1}\t\tSave import data process, EXEPTION: {2}", FileName, ExcelImportId, e.Message));
			} finally {
				string message = (importedRowsCount != totalRowsCount)
					? string.Format(ImportErrorMessage, importedRowsCount, totalRowsCount, FileName)
					: string.Format(ImportSuccessMessage, importedRowsCount, FileName);
				SendReminding(message);
			}
			LogInfo(string.Format("\t{0}\t{1}\t{2}\tSave import data process, end", FileName, ExcelImportId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
			return true;
		}

		public virtual bool CreateItem(string[] row, EntitySchema entitySchema, EntitySchemaManager entitySchemaManager, List<ExcelColumnConfig> columnsConfig) {
			var name = IsPrimaryDisplayColumnExists ? row[NameColumnIndex] : string.Empty;
			var nowParameter = new QueryParameter("now", DateTime.UtcNow, "DateTime");
			var currentUserContactIdParameter = new QueryParameter("currentUserId", UserConnection.CurrentUser.ContactId);
			var isFetched = false;
			var allIdentificationColumsAreInFile = true;
			
			Entity itemEntity = entitySchema.CreateEntity(UserConnection);
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, entitySchema.Name);
			EntitySchemaQueryColumn itemEntityIdColumn = entitySchemaQuery.AddColumn(entitySchema.GetPrimaryColumnName());
			//CR [170759] DO
			if (!string.IsNullOrEmpty(SelectedIdentificationColumns)) {
				var identifiedColumns = Json.Deserialize(SelectedIdentificationColumns) as JArray;
				var headerNames = HeaderNames as List<string>;
				var schemaColumns = itemEntity.Schema.Columns;
				foreach (var column in identifiedColumns) {
					string identifiedColumnName = entitySchema.FindSchemaColumnByMetaPath(column["metaPath"].ToString()).Name;
					var rowIndex = headerNames.IndexOf(identifiedColumnName);
					if (rowIndex < 0) { //Все ли выбранные поля для идентификации присутствуют в файле?
						allIdentificationColumsAreInFile = false;
						continue;
					}
					var excelColumnValue = row[rowIndex];
					EntitySchemaQueryColumn identifiedQueryColumn = entitySchemaQuery.AddColumn(identifiedColumnName);
					string identifiedQueryColumnName = identifiedQueryColumn.Name;
					if (schemaColumns.FindByName(identifiedColumnName).IsLookupType) {
						if (!string.IsNullOrEmpty(excelColumnValue)) {
							var fieldEntitySchema = entitySchema.Columns.FindByName(identifiedColumnName).ReferenceSchema; 
							var subEntitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, fieldEntitySchema.Name);
							EntitySchemaQueryColumn idColumn = subEntitySchemaQuery.AddColumn(fieldEntitySchema.GetPrimaryColumnName());
							subEntitySchemaQuery.Filters.Add(
								subEntitySchemaQuery.CreateFilterWithParameters(
									FilterComparisonType.Equal,
									fieldEntitySchema.PrimaryDisplayColumn.Name,
									excelColumnValue
								)
							);
							EntityCollection subEntityCollection = subEntitySchemaQuery.GetEntityCollection(UserConnection);
							if (subEntityCollection.Count > 0) {
								entitySchemaQuery.Filters.Add(
									entitySchemaQuery.CreateFilterWithParameters(
										FilterComparisonType.Equal, 
										identifiedQueryColumnName, 
										subEntityCollection[0].GetTypedColumnValue<Guid>(idColumn.Name)
									)
								);
							} else {
								entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateIsNullFilter(identifiedQueryColumnName));
							}
						} else {
							entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateIsNullFilter(identifiedQueryColumnName));
						}
					} else {
						entitySchemaQuery.Filters.Add(
							entitySchemaQuery.CreateFilterWithParameters(
								FilterComparisonType.Equal, 
								identifiedQueryColumnName, 
								excelColumnValue
							)
						);
					}
				}
				var entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
				if (entityCollection.Count > 0 && allIdentificationColumsAreInFile) {
					isFetched = itemEntity.FetchFromDB(entityCollection[0].GetTypedColumnValue<Guid>(itemEntityIdColumn.Name));
				}
			} else {
				//--DO
				if (IsPrimaryDisplayColumnExists) {
					string primaryDisplayColumnName = entitySchema.PrimaryDisplayColumn.Name;
					var nameColumn = entitySchemaQuery.AddColumn(primaryDisplayColumnName);
					entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, nameColumn.Name, name));
					EntityCollection entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
					if (entityCollection.Count > 0) {
						isFetched = itemEntity.FetchFromDB(entityCollection[0].GetTypedColumnValue<Guid>(itemEntityIdColumn.Name));
					} 
				} 
			}
			if (!isFetched) {
				itemEntity.SetDefColumnValues();
				itemEntity.SetColumnValue("Id", Guid.NewGuid());
			}
			foreach (var columnConfig in columnsConfig) {
				string columnName = columnConfig.EntityColumnName;
				string columnValue = row[columnConfig.Index];
				if (!columnConfig.NeedImport || (ImportMode == 2 && string.IsNullOrEmpty(columnValue))) {
					continue;
				}
				var entityColumn = entitySchema.Columns.FindByName(columnName);
				if (ImportMode == 2 && string.IsNullOrEmpty(columnValue)) {
					if (columnConfig.IsLookupType) {
						itemEntity.SetColumnValue(columnName, null);
					} else {
						itemEntity.SetColumnValue(entityColumn, null);
					}
				} else if (columnConfig.IsLookupType) {
					var fieldEntitySchema = entityColumn.ReferenceSchema; 
					entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, fieldEntitySchema.Name);
					var idColumn = entitySchemaQuery.AddColumn(fieldEntitySchema.GetPrimaryColumnName());
					entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, fieldEntitySchema.PrimaryDisplayColumn.Name, columnValue));
					var entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
					if (entityCollection.Count > 0) {
						itemEntity.SetColumnValue(entityColumn, entityCollection[0].GetTypedColumnValue<Guid>(idColumn.Name));
					}
				} else if (entityColumn.ValueType == typeof(System.DateTime)) {
					double time;
					DateTime date;
					if (Double.TryParse(columnValue.Replace('.', ','), out time)) {
						itemEntity.SetColumnValue(columnName, DateTime.FromOADate(time));
					} else if (DateTime.TryParse(columnValue, out date)) {
						itemEntity.SetColumnValue(columnName, date);
					}
				} else if (entityColumn.ValueType == typeof(Decimal)) {
					Decimal decimalValue;
					CultureInfo currentCulture = UserConnection.CurrentUser.Culture;
					string cultureSpecificValue = Regex.Replace(columnValue, "[,.]", currentCulture.NumberFormat.NumberDecimalSeparator);
					if (Decimal.TryParse(cultureSpecificValue, out decimalValue)) {
						itemEntity.SetColumnValue(columnName, decimalValue);
					}
				} else if (entityColumn.ValueType == typeof(bool) && !string.IsNullOrEmpty(columnValue)) {
					itemEntity.SetColumnValue(columnName, columnValue);
				} else if (entityColumn.ValueType == typeof(string)) {
					itemEntity.SetColumnValue(columnName, columnValue);
				} else {
					itemEntity.SetColumnValue(columnName, columnValue);
				}
			}
			itemEntity.Save();
			return true;
		}

		public virtual void SendReminding(string message) {
			LogInfo(string.Format("\t{0}\t{1}\t\tSend reminding message: \"{2}\"", FileName, ExcelImportId, message));
			RemindingServerUtilities.CreateRemindingByProcess(UserConnection, "ImportExcelDataProcess", message);
		}

		public virtual void LogInfo(string message) {
			if (ExcelUtilities.Log != null) {
				ExcelUtilities.Log.Info(message);
			}
		}

		public virtual void LogExcelImportLog(string message, string name) {
			var nowParameter = new QueryParameter("now", DateTime.UtcNow, "DateTime");
			var currentUserContactIdParameter = new QueryParameter("currentUserId",
				UserConnection.CurrentUser.ContactId);
			var guid = Guid.NewGuid();
			new Insert(UserConnection)
				.Into("ExcelImportLog")
				.Set("Id", Column.Parameter(guid))
				.Set("CreatedOn", nowParameter)
				.Set("CreatedById", currentUserContactIdParameter)
				.Set("ModifiedOn", nowParameter)
				.Set("ModifiedById", currentUserContactIdParameter)
				.Set("MessageText", Column.Parameter(message))
				.Set("ExcelImportId", Column.Parameter(ExcelImportId))
				.Set("Name", Column.Parameter(name))
				.Execute();
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
			var cloneItem = (ImportExcelDataProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Captions = Captions;
			cloneItem.HeaderNames = HeaderNames;
			cloneItem.ImportExcelData = ImportExcelData;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

