namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.CaseService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
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

	#region Class: RunSendNotificationCaseOwnerProcessSchema

	/// <exclude/>
	public class RunSendNotificationCaseOwnerProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public RunSendNotificationCaseOwnerProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public RunSendNotificationCaseOwnerProcessSchema(RunSendNotificationCaseOwnerProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "RunSendNotificationCaseOwnerProcess";
			UId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8");
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8");
			Version = 0;
			PackageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateActivityIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4f0122fd-6611-4f5a-a1c4-896cc2730a2f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"ActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCaseIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1a08787f-46f9-4f5e-8eea-5eeae6c5d89e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"CaseId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsFeatureEnableParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("805bc79a-0996-478c-a0ac-57079dd9a789"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"IsFeatureEnable",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsIncidentRegistrationMailboxParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("24d726e6-e10b-4408-9548-4460b7cf0641"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"IsIncidentRegistrationMailbox",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#BooleanValue.True#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateActivityIdParameter());
			Parameters.Add(CreateCaseIdParameter());
			Parameters.Add(CreateIsFeatureEnableParameter());
			Parameters.Add(CreateIsIncidentRegistrationMailboxParameter());
		}

		protected virtual void InitializeSubProcess1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var activityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b691dfca-9347-4e44-84a8-4939f1a1746f"),
				ContainerUId = new Guid("10bf746b-8480-484f-b27e-5a80a648e11e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"ActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activityIdParameter.SourceValue = new ProcessSchemaParameterValue(activityIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{3c307d40-6b97-4046-aad0-1c422afe4266}].[Parameter:{b88fdf50-f248-47ab-97e6-c177a5789162}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(activityIdParameter);
			var caseOwnerIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bede2d56-acf4-4ae7-b69d-650852c2b5ff"),
				ContainerUId = new Guid("10bf746b-8480-484f-b27e-5a80a648e11e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"CaseOwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			caseOwnerIdParameter.SourceValue = new ProcessSchemaParameterValue(caseOwnerIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(caseOwnerIdParameter);
			var caseIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5dcc9d95-6fd4-4d41-b933-1172cbdda0de"),
				ContainerUId = new Guid("10bf746b-8480-484f-b27e-5a80a648e11e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"CaseId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			caseIdParameter.SourceValue = new ProcessSchemaParameterValue(caseIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{d9a1236c-1afc-4aa1-b741-778cbb19f5c3}].[Parameter:{47e7870d-887a-40b1-93cc-a983dd581997}].[EntityColumn:{47c4dc47-8529-4d0e-a6fa-f298bb20cd13}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(caseIdParameter);
			var subjectCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2cab6cf8-6bbc-4233-af81-113390c3a97d"),
				ContainerUId = new Guid("10bf746b-8480-484f-b27e-5a80a648e11e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"SubjectCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			subjectCaptionParameter.SourceValue = new ProcessSchemaParameterValue(subjectCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(subjectCaptionParameter);
			var assigneeIsClearedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("827693bd-253a-4de2-a10f-e5401e86b7ea"),
				ContainerUId = new Guid("10bf746b-8480-484f-b27e-5a80a648e11e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"AssigneeIsCleared",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			assigneeIsClearedParameter.SourceValue = new ProcessSchemaParameterValue(assigneeIsClearedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(assigneeIsClearedParameter);
		}

		protected virtual void InitializeReadActivityDataUserParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e7321b39-3dcf-4e41-b3cc-df552c5bdc87"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,211,64,16,253,43,104,207,221,202,95,177,211,220,218,18,80,15,208,72,169,122,193,61,76,214,99,103,197,250,67,187,235,66,136,252,223,153,181,19,147,34,139,6,36,4,62,173,159,222,188,121,243,181,103,66,129,49,31,161,68,182,96,55,171,15,235,58,183,151,239,164,178,168,223,235,186,109,216,5,51,168,37,40,249,13,179,1,95,102,210,190,5,11,20,176,79,127,196,167,108,145,78,41,164,236,34,101,210,98,105,136,65,1,89,20,93,161,231,101,60,8,125,193,163,153,239,243,57,70,1,79,252,60,78,194,120,30,137,141,24,152,211,210,183,117,217,128,198,33,67,47,158,247,207,135,93,227,136,62,1,162,167,72,83,87,7,48,116,22,204,178,130,141,194,140,254,173,110,145,32,171,101,73,149,224,131,44,113,5,154,50,57,157,218,65,68,202,65,25,199,82,152,219,229,215,70,163,49,178,174,126,109,77,181,101,117,202,165,112,28,127,15,102,188,222,161,99,174,192,110,123,129,59,50,213,245,30,175,139,66,99,1,86,62,159,90,248,140,187,158,119,94,239,40,32,163,249,60,130,106,241,36,231,203,58,110,161,177,67,57,67,122,34,104,89,108,207,172,116,236,214,107,197,6,4,54,71,242,89,138,147,254,131,152,192,103,7,12,26,199,103,202,62,221,153,251,47,21,234,181,216,98,9,67,199,158,46,9,253,9,24,245,23,251,40,247,252,32,200,51,30,199,212,192,40,159,1,7,95,68,124,126,21,11,17,36,161,7,65,222,61,13,62,164,105,20,236,30,199,116,215,130,70,35,237,238,77,63,50,247,185,206,214,133,20,160,238,27,212,52,185,190,115,222,244,198,189,88,85,87,147,174,107,59,56,29,59,114,76,209,27,56,78,222,143,61,76,66,204,121,18,207,129,71,113,140,28,162,112,195,19,128,217,156,150,1,4,82,116,71,231,234,90,183,174,91,45,14,39,98,134,59,253,163,11,252,7,151,245,59,231,50,185,176,231,172,96,246,63,172,215,223,222,158,142,117,223,1,5,210,113,57,223,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f7602c82-5724-4619-b5ad-db7c8422196a"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultType",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultTypeParameter.SourceValue = new ProcessSchemaParameterValue(resultTypeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c3172b45-57f1-418c-bb67-72f2a0b32ca9"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ReadSomeTopRecords",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			readSomeTopRecordsParameter.SourceValue = new ProcessSchemaParameterValue(readSomeTopRecordsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ca3426cb-c9af-40cb-a32b-904acc859374"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"NumberOfRecords",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			numberOfRecordsParameter.SourceValue = new ProcessSchemaParameterValue(numberOfRecordsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e1610b41-ea4d-438c-8c58-378fb51ac753"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"FunctionType",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			functionTypeParameter.SourceValue = new ProcessSchemaParameterValue(functionTypeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6cb59cf9-7e62-40d3-b56b-f0f534d4f44e"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"AggregationColumnName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			aggregationColumnNameParameter.SourceValue = new ProcessSchemaParameterValue(aggregationColumnNameParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8e325b05-c166-4b00-85aa-63ed25302c07"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"OrderInfo",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			orderInfoParameter.SourceValue = new ProcessSchemaParameterValue(orderInfoParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,11,201,44,201,73,181,50,180,50,212,241,76,177,50,176,50,0,0,169,240,29,88,16,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("47e7870d-887a-40b1-93cc-a983dd581997"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultEntity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityDataValueType")
			};
			resultEntityParameter.SourceValue = new ProcessSchemaParameterValue(resultEntityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("32c1ca4e-2d39-47b4-9e04-2ed66fa28612"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultCountParameter.SourceValue = new ProcessSchemaParameterValue(resultCountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCountParameter);
			var resultIntegerFunctionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9e422dfd-7e93-4cb7-ab8b-c7ce32476fd3"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultIntegerFunction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultIntegerFunctionParameter.SourceValue = new ProcessSchemaParameterValue(resultIntegerFunctionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultIntegerFunctionParameter);
			var resultFloatFunctionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a8f9510c-d77b-4cbf-848d-35c3c61471c5"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultFloatFunction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Float4")
			};
			resultFloatFunctionParameter.SourceValue = new ProcessSchemaParameterValue(resultFloatFunctionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultFloatFunctionParameter);
			var resultDateTimeFunctionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1f599cca-c1e8-4f63-916e-ffbb37100840"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultDateTimeFunction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime")
			};
			resultDateTimeFunctionParameter.SourceValue = new ProcessSchemaParameterValue(resultDateTimeFunctionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultDateTimeFunctionParameter);
			var resultRowsCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c5bca14a-e98e-4998-9d2e-cbf637811033"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultRowsCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultRowsCountParameter.SourceValue = new ProcessSchemaParameterValue(resultRowsCountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultRowsCountParameter);
			var canReadUncommitedDataParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2982470c-9421-49e3-8897-89e7d6d1acfa"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"CanReadUncommitedData",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			canReadUncommitedDataParameter.SourceValue = new ProcessSchemaParameterValue(canReadUncommitedDataParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f")
			};
			parametrizedElement.Parameters.Add(canReadUncommitedDataParameter);
			var resultEntityCollectionParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("4107628a-1df0-4777-a8de-55903da24ba4"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultEntityCollection",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityCollectionDataValueType")
			};
			resultEntityCollectionParameter.SourceValue = new ProcessSchemaParameterValue(resultEntityCollectionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d912ec4e-4d3a-4a19-8c12-2960d7668f24"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"EntityColumnMetaPathes",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			entityColumnMetaPathesParameter.SourceValue = new ProcessSchemaParameterValue(entityColumnMetaPathesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,49,79,54,73,73,54,49,215,181,48,53,178,212,53,73,49,72,213,77,52,75,75,212,77,51,178,180,72,74,50,50,72,78,49,52,6,0,113,141,145,146,36,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0332951d-79d9-4809-a406-5c0d3bf7e5ad"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"IgnoreDisplayValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			ignoreDisplayValuesParameter.SourceValue = new ProcessSchemaParameterValue(ignoreDisplayValuesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ignoreDisplayValuesParameter);
			var resultCompositeObjectListParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3091de9e-87e7-4669-ad40-f8c0a8f2585a"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultCompositeObjectList",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("CompositeObjectList")
			};
			resultCompositeObjectListParameter.SourceValue = new ProcessSchemaParameterValue(resultCompositeObjectListParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("260053d0-1a7c-4abd-a474-bab21ae902f1"),
				ContainerUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeStartSignal2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b88fdf50-f248-47ab-97e6-c177a5789162"),
				ContainerUId = new Guid("3c307d40-6b97-4046-aad0-1c422afe4266"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3c307d40-6b97-4046-aad0-1c422afe4266"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
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
				UId = new Guid("b112453c-1b45-4306-a3dd-10896d076870"),
				ContainerUId = new Guid("3c307d40-6b97-4046-aad0-1c422afe4266"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3c307d40-6b97-4046-aad0-1c422afe4266"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeStartSignal1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("81646e39-fe12-4dd8-adc3-afc8b985af41"),
				ContainerUId = new Guid("21263efe-213f-4d54-b5db-99dafd2586d6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaSubProcess subprocess1 = CreateSubProcess1SubProcess();
			FlowElements.Add(subprocess1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask readactivitydatauser = CreateReadActivityDataUserUserTask();
			FlowElements.Add(readactivitydatauser);
			ProcessSchemaStartSignalEvent startsignal2 = CreateStartSignal2StartSignalEvent();
			FlowElements.Add(startsignal2);
			ProcessSchemaStartSignalEvent startsignal1 = CreateStartSignal1StartSignalEvent();
			FlowElements.Add(startsignal1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			ProcessSchemaScriptTask scripttask2 = CreateScriptTask2ScriptTask();
			FlowElements.Add(scripttask2);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow2ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("8b62217e-6fd9-4b76-907a-1a8092c971ba"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("10bf746b-8480-484f-b27e-5a80a648e11e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c3209743-08bb-4f2e-ab1e-349db9c9c10b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("9a17aa64-d07d-4f5b-ada6-740bc841fb89"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3c307d40-6b97-4046-aad0-1c422afe4266"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("36c1c820-22fb-4952-84d9-289ec75da081"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("7cfbd5c8-2f08-4517-be93-ee01505afb62"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("21263efe-213f-4d54-b5db-99dafd2586d6"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("36c1c820-22fb-4952-84d9-289ec75da081"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(210, 246));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("fd3a1586-142c-4895-af42-10c54e8e971f"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{805bc79a-0996-478c-a0ac-57079dd9a789}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f1975729-7dcb-46fd-a02c-1117b02a66ac"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2a63a676-cc63-4348-a9b5-4f0f4dfc2d79"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(561, 47));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("3cab3973-3165-4971-9094-f20bf918c51e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2a63a676-cc63-4348-a9b5-4f0f4dfc2d79"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c3209743-08bb-4f2e-ab1e-349db9c9c10b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(866, 47));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("e3fae13d-71da-4a9f-9d98-447001a29949"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f1975729-7dcb-46fd-a02c-1117b02a66ac"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("10bf746b-8480-484f-b27e-5a80a648e11e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("dba08559-25a8-44b1-a589-79e6f08b0218"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f1975729-7dcb-46fd-a02c-1117b02a66ac"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow2",
				UId = new Guid("7571afe2-e05b-43a7-a0f8-5673ecca3277"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{24d726e6-e10b-4408-9548-4460b7cf0641}]#] == false",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8fade873-093e-40ba-ae1c-6bbd9f67e3af"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c3209743-08bb-4f2e-ab1e-349db9c9c10b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(327, 246));
			schemaFlow.PolylinePointPositions.Add(new Point(866, 246));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow3",
				UId = new Guid("6543925a-5a23-4614-a1d2-a4824967c93a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8fade873-093e-40ba-ae1c-6bbd9f67e3af"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("171f19e7-c440-4bf7-bac5-aef64a270ce8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("36c1c820-22fb-4952-84d9-289ec75da081"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8fade873-093e-40ba-ae1c-6bbd9f67e3af"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("248f9aa2-4f6f-4470-abce-e8e78c078ecf"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("7f4f47b1-5e10-42b3-95cc-f493d88eb158"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("248f9aa2-4f6f-4470-abce-e8e78c078ecf"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("c3209743-08bb-4f2e-ab1e-349db9c9c10b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7f4f47b1-5e10-42b3-95cc-f493d88eb158"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"Terminate1",
				Position = new Point(853, 140),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadActivityDataUserUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7f4f47b1-5e10-42b3-95cc-f493d88eb158"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"ReadActivityDataUser",
				Position = new Point(410, 126),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadActivityDataUserParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaSubProcess CreateSubProcess1SubProcess() {
			ProcessSchemaSubProcess schemaSubProcess1 = new ProcessSchemaSubProcess(this) {
				UId = new Guid("10bf746b-8480-484f-b27e-5a80a648e11e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7f4f47b1-5e10-42b3-95cc-f493d88eb158"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"SubProcess1",
				Position = new Point(671, 126),
				SchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeSubProcess1Parameters(schemaSubProcess1);
			return schemaSubProcess1;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal2StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("3c307d40-6b97-4046-aad0-1c422afe4266"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7f4f47b1-5e10-42b3-95cc-f493d88eb158"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3f3b9f1f-d04f-4426-ad64-9acca96812fe"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"StartSignal2",
				NewEntityChangedColumns = false,
				Position = new Point(60, 140),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaStartSignalEvent.EntityChangedColumns.Add("47c4dc47-8529-4d0e-a6fa-f298bb20cd13");
			InitializeStartSignal2Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal1StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("21263efe-213f-4d54-b5db-99dafd2586d6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7f4f47b1-5e10-42b3-95cc-f493d88eb158"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				EntitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				EntitySignal = EntityChangeType.Inserted,
				HasEntityColumnChange = false,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"StartSignal1",
				NewEntityChangedColumns = false,
				Position = new Point(60, 233),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			InitializeStartSignal1Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("36c1c820-22fb-4952-84d9-289ec75da081"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7f4f47b1-5e10-42b3-95cc-f493d88eb158"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"ScriptTask1",
				Position = new Point(176, 126),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,145,193,106,195,48,16,68,239,129,252,131,154,147,3,69,208,30,27,76,113,140,19,124,72,9,54,249,0,197,90,155,5,101,21,180,235,182,254,251,202,117,90,138,105,169,46,18,204,155,157,145,148,53,130,175,40,67,105,85,170,146,90,76,144,26,59,50,238,65,87,208,248,96,163,112,151,170,125,143,86,23,151,171,12,235,229,66,197,245,172,126,101,39,241,233,167,248,248,45,110,150,139,146,119,96,164,15,80,144,57,59,136,153,219,227,161,246,173,232,220,83,139,93,31,140,160,39,125,163,78,130,14,5,129,245,30,100,230,181,201,137,33,68,27,65,188,131,167,123,181,170,122,170,192,95,129,114,195,144,145,125,241,130,237,144,49,199,34,0,185,51,204,171,245,216,130,26,36,11,36,21,116,200,50,101,30,12,186,179,127,223,161,19,8,170,157,182,84,17,188,169,255,249,89,151,207,16,30,109,127,184,226,224,41,65,151,124,12,192,51,170,184,68,44,250,179,219,239,36,95,135,210,142,163,3,196,103,32,37,161,135,205,7,153,112,156,10,193,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask2ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2a63a676-cc63-4348-a9b5-4f0f4dfc2d79"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7f4f47b1-5e10-42b3-95cc-f493d88eb158"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"ScriptTask2",
				Position = new Point(664, 20),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,79,203,10,194,48,16,60,235,87,132,158,42,72,127,160,42,148,250,192,139,135,162,222,67,51,74,160,110,36,217,173,246,239,77,20,17,245,56,179,243,218,94,123,213,118,58,132,213,29,173,176,243,106,62,170,19,94,235,54,162,161,216,128,103,13,220,21,84,235,128,138,204,206,177,61,13,85,8,246,76,192,34,39,220,84,237,40,176,151,228,168,252,89,46,32,206,51,9,240,241,64,104,217,58,202,166,234,240,69,76,38,229,248,171,185,72,5,91,163,230,170,129,54,85,20,245,150,135,165,102,157,140,69,131,32,29,175,136,35,153,86,237,135,43,76,237,58,185,208,81,119,130,217,70,172,89,228,217,43,37,251,75,127,7,62,27,62,224,87,214,8,229,209,235,193,226,73,197,167,80,62,0,164,93,86,230,36,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("f1975729-7dcb-46fd-a02c-1117b02a66ac"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7f4f47b1-5e10-42b3-95cc-f493d88eb158"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"ExclusiveGateway1",
				Position = new Point(534, 126),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("8fade873-093e-40ba-ae1c-6bbd9f67e3af"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7f4f47b1-5e10-42b3-95cc-f493d88eb158"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"),
				Name = @"ExclusiveGateway2",
				Position = new Point(300, 126),
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
				UId = new Guid("386e21ef-2e31-4a75-a81b-1b0fef03f239"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("78ed474b-cb20-4a7c-b0ff-cf86b32a568e"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("9bb5e1c4-93ab-4e57-85af-f4497e383df9"),
				Name = "BPMSoft.Configuration.CaseService",
				Alias = "",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new RunSendNotificationCaseOwnerProcess(userConnection);
		}

		public override object Clone() {
			return new RunSendNotificationCaseOwnerProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8"));
		}

		#endregion

	}

	#endregion

	#region Class: RunSendNotificationCaseOwnerProcess

	/// <exclude/>
	public class RunSendNotificationCaseOwnerProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, RunSendNotificationCaseOwnerProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ReadActivityDataUserFlowElement

		/// <exclude/>
		public class ReadActivityDataUserFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadActivityDataUserFlowElement(UserConnection userConnection, RunSendNotificationCaseOwnerProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadActivityDataUser";
				IsLogging = true;
				SchemaElementUId = new Guid("d9a1236c-1afc-4aa1-b741-778cbb19f5c3");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,211,64,16,253,43,104,207,221,202,95,177,211,220,218,18,80,15,208,72,169,122,193,61,76,214,99,103,197,250,67,187,235,66,136,252,223,153,181,19,147,34,139,6,36,4,62,173,159,222,188,121,243,181,103,66,129,49,31,161,68,182,96,55,171,15,235,58,183,151,239,164,178,168,223,235,186,109,216,5,51,168,37,40,249,13,179,1,95,102,210,190,5,11,20,176,79,127,196,167,108,145,78,41,164,236,34,101,210,98,105,136,65,1,89,20,93,161,231,101,60,8,125,193,163,153,239,243,57,70,1,79,252,60,78,194,120,30,137,141,24,152,211,210,183,117,217,128,198,33,67,47,158,247,207,135,93,227,136,62,1,162,167,72,83,87,7,48,116,22,204,178,130,141,194,140,254,173,110,145,32,171,101,73,149,224,131,44,113,5,154,50,57,157,218,65,68,202,65,25,199,82,152,219,229,215,70,163,49,178,174,126,109,77,181,101,117,202,165,112,28,127,15,102,188,222,161,99,174,192,110,123,129,59,50,213,245,30,175,139,66,99,1,86,62,159,90,248,140,187,158,119,94,239,40,32,163,249,60,130,106,241,36,231,203,58,110,161,177,67,57,67,122,34,104,89,108,207,172,116,236,214,107,197,6,4,54,71,242,89,138,147,254,131,152,192,103,7,12,26,199,103,202,62,221,153,251,47,21,234,181,216,98,9,67,199,158,46,9,253,9,24,245,23,251,40,247,252,32,200,51,30,199,212,192,40,159,1,7,95,68,124,126,21,11,17,36,161,7,65,222,61,13,62,164,105,20,236,30,199,116,215,130,70,35,237,238,77,63,50,247,185,206,214,133,20,160,238,27,212,52,185,190,115,222,244,198,189,88,85,87,147,174,107,59,56,29,59,114,76,209,27,56,78,222,143,61,76,66,204,121,18,207,129,71,113,140,28,162,112,195,19,128,217,156,150,1,4,82,116,71,231,234,90,183,174,91,45,14,39,98,134,59,253,163,11,252,7,151,245,59,231,50,185,176,231,172,96,246,63,172,215,223,222,158,142,117,223,1,5,210,113,57,223,5,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private int _resultType = 0;
			public override int ResultType {
				get {
					return _resultType;
				}
				set {
					_resultType = value;
				}
			}

			private bool _readSomeTopRecords = true;
			public override bool ReadSomeTopRecords {
				get {
					return _readSomeTopRecords;
				}
				set {
					_readSomeTopRecords = value;
				}
			}

			private int _numberOfRecords = 1;
			public override int NumberOfRecords {
				get {
					return _numberOfRecords;
				}
				set {
					_numberOfRecords = value;
				}
			}

			private int _functionType = 0;
			public override int FunctionType {
				get {
					return _functionType;
				}
				set {
					_functionType = value;
				}
			}

			private string _orderInfo;
			public override string OrderInfo {
				get {
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,11,201,44,201,73,181,50,180,50,212,241,76,177,50,176,50,0,0,169,240,29,88,16,0,0,0 })));
				}
				set {
					_orderInfo = value;
				}
			}

			private Entity _resultEntity;
			public override Entity ResultEntity {
				get {
					return _resultEntity ?? (_resultEntity =
						new Entity(UserConnection) {
							Schema = UserConnection.EntitySchemaManager.GetInstanceByUId(
								new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89")),
							UseAdminRights = false
						});
				}
				set {
					_resultEntity = value;
				}
			}

			private EntityCollection _resultEntityCollection;
			public override EntityCollection ResultEntityCollection {
				get {
					if (_resultEntityCollection == null) {
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"));
					}
					return _resultEntityCollection;
				}
				set {
					_resultEntityCollection = value;
				}
			}

			private string _entityColumnMetaPathes;
			public override string EntityColumnMetaPathes {
				get {
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,49,79,54,73,73,54,49,215,181,48,53,178,212,53,73,49,72,213,77,52,75,75,212,77,51,178,180,72,74,50,50,72,78,49,52,6,0,113,141,145,146,36,0,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: SubProcess1FlowElement

		/// <exclude/>
		public class SubProcess1FlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public SubProcess1FlowElement(UserConnection userConnection, RunSendNotificationCaseOwnerProcess process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625");
			}

			#endregion

			#region Properties: Public

			public Guid ActivityId {
				get {
					return GetParameterValue<Guid>("ActivityId");
				}
				set {
					SetParameterValue("ActivityId", value);
				}
			}

			public Guid CaseOwnerId {
				get {
					return GetParameterValue<Guid>("CaseOwnerId");
				}
				set {
					SetParameterValue("CaseOwnerId", value);
				}
			}

			public Guid CaseId {
				get {
					return GetParameterValue<Guid>("CaseId");
				}
				set {
					SetParameterValue("CaseId", value);
				}
			}

			public LocalizableString SubjectCaption {
				get {
					return GetParameterValue<LocalizableString>("SubjectCaption");
				}
				set {
					SetParameterValue("SubjectCaption", value);
				}
			}

			public bool AssigneeIsCleared {
				get {
					return GetParameterValue<bool>("AssigneeIsCleared");
				}
				set {
					SetParameterValue("AssigneeIsCleared", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (RunSendNotificationCaseOwnerProcess)owner;
				Name = "SubProcess1";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("10bf746b-8480-484f-b27e-5a80a648e11e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (RunSendNotificationCaseOwnerProcess)Owner;
				SetParameterValue("ActivityId", (Guid)((process.StartSignal2.RecordId)));
				SetParameterValue("CaseId", (Guid)(((process.ReadActivityDataUser.ResultEntity.IsColumnValueLoaded(process.ReadActivityDataUser.ResultEntity.Schema.Columns.GetByName("Case").ColumnValueName) ? process.ReadActivityDataUser.ResultEntity.GetTypedColumnValue<Guid>("CaseId") : Guid.Empty))));
			}

			#endregion

		}

		#endregion

		public RunSendNotificationCaseOwnerProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RunSendNotificationCaseOwnerProcess";
			SchemaUId = new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_isIncidentRegistrationMailbox = () => { return (bool)(true); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("69d87f84-1b89-4c6f-b4ce-39467a9d55b8");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: RunSendNotificationCaseOwnerProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: RunSendNotificationCaseOwnerProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid ActivityId {
			get;
			set;
		}

		public virtual Guid CaseId {
			get;
			set;
		}

		public virtual bool IsFeatureEnable {
			get;
			set;
		}

		private Func<bool> _isIncidentRegistrationMailbox;
		public virtual bool IsIncidentRegistrationMailbox {
			get {
				return (_isIncidentRegistrationMailbox ?? (_isIncidentRegistrationMailbox = () => false)).Invoke();
			}
			set {
				_isIncidentRegistrationMailbox = () => { return value; };
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
					SchemaElementUId = new Guid("c3209743-08bb-4f2e-ab1e-349db9c9c10b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ReadActivityDataUserFlowElement _readActivityDataUser;
		public ReadActivityDataUserFlowElement ReadActivityDataUser {
			get {
				return _readActivityDataUser ?? (_readActivityDataUser = new ReadActivityDataUserFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private SubProcess1FlowElement _subProcess1;
		public SubProcess1FlowElement SubProcess1 {
			get {
				return _subProcess1 ?? ((_subProcess1) = new SubProcess1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("3c307d40-6b97-4046-aad0-1c422afe4266"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("21263efe-213f-4d54-b5db-99dafd2586d6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("36c1c820-22fb-4952-84d9-289ec75da081"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
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
					SchemaElementUId = new Guid("2a63a676-cc63-4348-a9b5-4f0f4dfc2d79"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask2Execute,
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
					SchemaElementUId = new Guid("f1975729-7dcb-46fd-a02c-1117b02a66ac"),
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
					SchemaElementUId = new Guid("8fade873-093e-40ba-ae1c-6bbd9f67e3af"),
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
					SchemaElementUId = new Guid("fd3a1586-142c-4895-af42-10c54e8e971f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow2;
		public ProcessConditionalFlow ConditionalSequenceFlow2 {
			get {
				return _conditionalSequenceFlow2 ?? (_conditionalSequenceFlow2 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow2",
					SchemaElementUId = new Guid("7571afe2-e05b-43a7-a0f8-5673ecca3277"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessToken _exclusiveGateway1SubProcess1Token;
		public ProcessToken ExclusiveGateway1SubProcess1Token {
			get {
				return _exclusiveGateway1SubProcess1Token ?? (_exclusiveGateway1SubProcess1Token = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ExclusiveGateway1SubProcess1Token",
					SchemaElementUId = new Guid("f4a86b44-1da3-44ef-8646-e30a9a92fa18"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ReadActivityDataUser.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadActivityDataUser };
			FlowElements[SubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess1 };
			FlowElements[StartSignal2.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal2 };
			FlowElements[StartSignal1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[ExclusiveGateway1SubProcess1Token.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1SubProcess1Token };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Terminate1":
						CompleteProcess();
						break;
					case "ReadActivityDataUser":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "SubProcess1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "StartSignal2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "StartSignal1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "ScriptTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1SubProcess1Token", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalSequenceFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadActivityDataUser", e.Context.SenderName));
						break;
					case "ExclusiveGateway1SubProcess1Token":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SubProcess1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((IsFeatureEnable));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow1", "(IsFeatureEnable)", result);
			return result;
		}

		private bool ConditionalSequenceFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((IsIncidentRegistrationMailbox) == false);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalSequenceFlow2", "(IsIncidentRegistrationMailbox) == false", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("ActivityId")) {
				writer.WriteValue("ActivityId", ActivityId, Guid.Empty);
			}
			if (!HasMapping("CaseId")) {
				writer.WriteValue("CaseId", CaseId, Guid.Empty);
			}
			if (!HasMapping("IsFeatureEnable")) {
				writer.WriteValue("IsFeatureEnable", IsFeatureEnable, false);
			}
			if (!HasMapping("IsIncidentRegistrationMailbox")) {
				writer.WriteValue("IsIncidentRegistrationMailbox", IsIncidentRegistrationMailbox, false);
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
			MetaPathParameterValues.Add("4f0122fd-6611-4f5a-a1c4-896cc2730a2f", () => ActivityId);
			MetaPathParameterValues.Add("1a08787f-46f9-4f5e-8eea-5eeae6c5d89e", () => CaseId);
			MetaPathParameterValues.Add("805bc79a-0996-478c-a0ac-57079dd9a789", () => IsFeatureEnable);
			MetaPathParameterValues.Add("24d726e6-e10b-4408-9548-4460b7cf0641", () => IsIncidentRegistrationMailbox);
			MetaPathParameterValues.Add("e7321b39-3dcf-4e41-b3cc-df552c5bdc87", () => ReadActivityDataUser.DataSourceFilters);
			MetaPathParameterValues.Add("f7602c82-5724-4619-b5ad-db7c8422196a", () => ReadActivityDataUser.ResultType);
			MetaPathParameterValues.Add("c3172b45-57f1-418c-bb67-72f2a0b32ca9", () => ReadActivityDataUser.ReadSomeTopRecords);
			MetaPathParameterValues.Add("ca3426cb-c9af-40cb-a32b-904acc859374", () => ReadActivityDataUser.NumberOfRecords);
			MetaPathParameterValues.Add("e1610b41-ea4d-438c-8c58-378fb51ac753", () => ReadActivityDataUser.FunctionType);
			MetaPathParameterValues.Add("6cb59cf9-7e62-40d3-b56b-f0f534d4f44e", () => ReadActivityDataUser.AggregationColumnName);
			MetaPathParameterValues.Add("8e325b05-c166-4b00-85aa-63ed25302c07", () => ReadActivityDataUser.OrderInfo);
			MetaPathParameterValues.Add("47e7870d-887a-40b1-93cc-a983dd581997", () => ReadActivityDataUser.ResultEntity);
			MetaPathParameterValues.Add("32c1ca4e-2d39-47b4-9e04-2ed66fa28612", () => ReadActivityDataUser.ResultCount);
			MetaPathParameterValues.Add("9e422dfd-7e93-4cb7-ab8b-c7ce32476fd3", () => ReadActivityDataUser.ResultIntegerFunction);
			MetaPathParameterValues.Add("a8f9510c-d77b-4cbf-848d-35c3c61471c5", () => ReadActivityDataUser.ResultFloatFunction);
			MetaPathParameterValues.Add("1f599cca-c1e8-4f63-916e-ffbb37100840", () => ReadActivityDataUser.ResultDateTimeFunction);
			MetaPathParameterValues.Add("c5bca14a-e98e-4998-9d2e-cbf637811033", () => ReadActivityDataUser.ResultRowsCount);
			MetaPathParameterValues.Add("2982470c-9421-49e3-8897-89e7d6d1acfa", () => ReadActivityDataUser.CanReadUncommitedData);
			MetaPathParameterValues.Add("4107628a-1df0-4777-a8de-55903da24ba4", () => ReadActivityDataUser.ResultEntityCollection);
			MetaPathParameterValues.Add("d912ec4e-4d3a-4a19-8c12-2960d7668f24", () => ReadActivityDataUser.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("0332951d-79d9-4809-a406-5c0d3bf7e5ad", () => ReadActivityDataUser.IgnoreDisplayValues);
			MetaPathParameterValues.Add("3091de9e-87e7-4669-ad40-f8c0a8f2585a", () => ReadActivityDataUser.ResultCompositeObjectList);
			MetaPathParameterValues.Add("260053d0-1a7c-4abd-a474-bab21ae902f1", () => ReadActivityDataUser.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("b691dfca-9347-4e44-84a8-4939f1a1746f", () => SubProcess1.ActivityId);
			MetaPathParameterValues.Add("bede2d56-acf4-4ae7-b69d-650852c2b5ff", () => SubProcess1.CaseOwnerId);
			MetaPathParameterValues.Add("5dcc9d95-6fd4-4d41-b933-1172cbdda0de", () => SubProcess1.CaseId);
			MetaPathParameterValues.Add("2cab6cf8-6bbc-4233-af81-113390c3a97d", () => SubProcess1.SubjectCaption);
			MetaPathParameterValues.Add("827693bd-253a-4de2-a10f-e5401e86b7ea", () => SubProcess1.AssigneeIsCleared);
			MetaPathParameterValues.Add("b88fdf50-f248-47ab-97e6-c177a5789162", () => StartSignal2.RecordId);
			MetaPathParameterValues.Add("b112453c-1b45-4306-a3dd-10896d076870", () => StartSignal2.EntitySchemaUId);
			MetaPathParameterValues.Add("81646e39-fe12-4dd8-adc3-afc8b985af41", () => StartSignal1.RecordId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "ActivityId":
					if (!hasValueToRead) break;
					ActivityId = reader.GetValue<System.Guid>();
				break;
				case "CaseId":
					if (!hasValueToRead) break;
					CaseId = reader.GetValue<System.Guid>();
				break;
				case "IsFeatureEnable":
					if (!hasValueToRead) break;
					IsFeatureEnable = reader.GetValue<System.Boolean>();
				break;
				case "IsIncidentRegistrationMailbox":
					if (!hasValueToRead) break;
					IsIncidentRegistrationMailbox = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			ActivityId = (StartSignal1.RecordId != Guid.Empty)
			    ? StartSignal1.RecordId
			    : StartSignal2.RecordId;
			IsFeatureEnable = BPMSoft.Configuration.FeatureUtilities.GetIsFeatureEnabled(UserConnection, "RunReopenCaseAndNotifyAssigneeClass");
			IncindentRegistrationMailboxFilter filter = new IncindentRegistrationMailboxFilter(UserConnection);
			IsIncidentRegistrationMailbox = filter.IsPresentRegistrationEmailsInActivity(ActivityId);
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			var classExecutor =	ClassFactory.Get<ReopenCaseAndNotifyAssignee>(new ConstructorArgument("userConnection", UserConnection));
			classExecutor.CaseId = ReadActivityDataUser.ResultEntity.GetTypedColumnValue<Guid>("CaseId");
			classExecutor.ActivityId = ActivityId;
			classExecutor.Run();
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
			var cloneItem = (RunSendNotificationCaseOwnerProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

