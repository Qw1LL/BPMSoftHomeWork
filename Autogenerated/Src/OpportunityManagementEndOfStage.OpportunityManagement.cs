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

	#region Class: OpportunityManagementEndOfStageSchema

	/// <exclude/>
	public class OpportunityManagementEndOfStageSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public OpportunityManagementEndOfStageSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public OpportunityManagementEndOfStageSchema(OpportunityManagementEndOfStageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "OpportunityManagementEndOfStage";
			UId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8");
			CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2936";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"OpportunityManagement";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8");
			Version = 0;
			PackageUId = new Guid("75b64d44-f646-4025-b2dc-16a7526ff5fd");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCurrentOpportunityParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("dfce71b8-964d-4c09-bd58-0c97f1365945"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNextOpportunityStageNumberParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d7748fee-12d1-4402-9af3-177336bb4bb3"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"NextOpportunityStageNumber",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentStageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7411fdec-830d-495b-8fcc-4494af5fe84c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"CurrentStage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{456fe102-f895-4fd8-8351-a77859dd709e}].[Parameter:{e11d0fd9-aca0-4ee9-b9cf-f8d97c1fc2ba}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateRecommendationParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c26d6544-4636-434b-b986-690a58c482d2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateIsStageChangedByUserParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2d124c72-8de2-4327-a821-7370bb4f3f04"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"IsStageChangedByUser",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateDontShowPageEndOfStageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4a896c50-5660-4509-bcfa-09fdb87708e7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"DontShowPageEndOfStage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNextStageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b84b8659-7d6c-46df-be98-b96c5d0e5b85"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"NextStage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCurrentOpportunityParameter());
			Parameters.Add(CreateNextOpportunityStageNumberParameter());
			Parameters.Add(CreateCurrentStageParameter());
			Parameters.Add(CreateRecommendationParameter());
			Parameters.Add(CreateIsStageChangedByUserParameter());
			Parameters.Add(CreateDontShowPageEndOfStageParameter());
			Parameters.Add(CreateNextStageParameter());
		}

		protected virtual void InitializeReadCurrentStageParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a180ecd0-2639-46fe-8f28-b1f4bf23afb2"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,148,193,106,220,48,16,134,95,101,209,161,39,107,177,44,219,178,220,99,216,150,92,210,64,211,82,72,66,144,173,81,98,176,189,27,91,166,9,203,66,72,160,80,154,182,143,80,122,234,53,148,110,187,73,154,246,21,228,55,170,188,206,182,144,67,201,53,96,131,53,210,252,243,235,243,72,211,189,172,126,146,229,26,170,88,137,188,6,167,89,151,49,2,9,144,36,148,99,0,34,176,79,195,0,39,34,84,152,17,15,152,32,1,241,8,65,78,41,10,136,81,159,61,146,153,70,78,166,161,168,227,237,233,63,81,93,53,224,236,169,229,224,121,122,0,133,120,209,21,72,83,197,100,68,40,86,105,68,177,207,132,196,9,132,4,71,138,38,52,225,145,8,124,133,122,47,17,23,73,200,173,141,36,164,128,125,79,5,152,131,242,176,164,32,0,220,128,166,44,68,78,14,74,143,142,38,21,212,117,54,46,227,41,252,253,222,58,158,88,151,125,237,181,113,222,20,37,114,10,208,98,83,232,131,24,9,112,193,15,82,129,83,159,7,216,87,192,176,160,92,98,42,18,230,177,8,72,72,24,114,82,49,209,157,44,90,151,200,145,66,139,151,34,111,96,169,60,205,172,71,143,186,36,10,66,155,75,104,106,121,121,46,142,194,136,97,37,67,197,129,134,156,39,114,197,235,105,147,217,239,172,222,104,10,168,178,244,22,59,88,126,227,42,158,166,227,82,87,227,188,147,222,88,46,223,130,35,221,195,189,157,122,213,111,72,219,120,151,132,102,78,83,195,90,158,65,169,71,101,58,150,89,185,223,107,206,102,54,165,152,136,42,171,87,20,70,135,141,200,145,83,101,251,7,255,165,181,214,212,122,92,60,160,173,58,118,155,86,195,54,217,210,110,215,131,50,171,39,185,56,94,142,99,244,232,176,25,235,199,230,139,89,180,167,230,162,61,109,207,7,230,155,185,48,55,230,166,125,103,230,3,243,187,61,49,191,150,161,239,102,49,52,159,204,220,6,190,218,185,203,65,251,222,92,155,185,249,105,223,155,246,116,96,227,115,243,163,61,51,215,237,185,21,91,180,39,237,89,251,161,125,107,163,151,3,115,101,85,174,151,235,175,218,55,102,209,105,125,238,74,90,233,69,251,177,183,129,238,216,141,209,14,2,18,169,192,117,9,150,145,165,233,19,150,224,136,120,20,51,174,162,196,119,57,241,221,112,216,157,17,153,250,46,14,128,122,216,151,110,130,185,244,24,38,22,60,1,123,102,60,47,25,50,206,68,74,3,59,207,25,183,139,188,8,115,215,30,222,200,83,144,132,50,73,185,76,119,144,133,249,208,16,109,175,215,207,94,151,171,123,164,255,243,187,67,27,189,19,24,229,80,216,22,177,109,125,15,166,51,155,176,185,42,21,79,239,67,184,75,25,149,58,211,199,253,125,18,79,239,131,124,182,219,65,223,157,217,231,15,80,37,94,191,117,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("42e7b0d0-17c7-4dcc-a264-7be5a6a0e0b1"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1ee60d4e-4844-4702-9e5b-a9ef2faca871"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f8cf2516-53d6-45f6-ba8d-4bfdabb48124"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b9fa8b3c-2f06-4b34-bbef-4f29b1947858"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a9ce46aa-34eb-48fb-be04-e9c34eceff5f"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				UId = new Guid("5061fcf5-7f96-49fa-8be4-619e0f5209ae"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,75,204,77,181,50,180,50,4,0,203,8,241,43,15,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				UId = new Guid("e11d0fd9-aca0-4ee9-b9cf-f8d97c1fc2ba"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bbaa560d-a45c-4f10-ac9f-e0a221e816e8"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				UId = new Guid("c64386d0-db34-457e-833d-a14939236608"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				UId = new Guid("e5dde80e-3396-4686-a165-fafbfad811d2"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				UId = new Guid("c161dd2c-4540-45be-9271-b9b410ff5929"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				UId = new Guid("1ca50f2d-35c9-435b-85de-6154c601ed28"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				UId = new Guid("30c203aa-798c-414b-b6e2-e7435cabddcd"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				UId = new Guid("18002008-4ddc-4cdc-9996-18caf8454929"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7d1b816f-c970-49b1-bfdb-4212142710ce"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e979c3ad-ef25-4300-b738-0666bbd3e28a"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				UId = new Guid("18801700-5425-4afa-8a8a-87a4499f280f"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8fd411c2-fbf5-4ed0-a07e-e3a6a9c630a1"),
				ContainerUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
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

		protected virtual void InitializeUpdateOpportunityStageParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("e99fa34f-868e-4b57-a3a8-13c100885498"),
				ContainerUId = new Guid("ff16041c-18d5-46f3-baed-a5b8b559b3fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"ae46fb87-c02c-4ae8-ad31-a923cdd994cf",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("05fb8dfb-1204-478c-a016-5e0dacf67068"),
				ContainerUId = new Guid("ff16041c-18d5-46f3-baed-a5b8b559b3fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"IsMatchConditions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isMatchConditionsParameter.SourceValue = new ProcessSchemaParameterValue(isMatchConditionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cc2f766d-1506-48eb-8d63-91ddc235a521"),
				ContainerUId = new Guid("ff16041c-18d5-46f3-baed-a5b8b559b3fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,110,212,48,20,253,21,228,5,171,24,37,177,227,71,88,142,6,52,155,82,137,130,144,218,81,229,216,55,29,75,121,76,19,71,180,138,70,66,98,197,138,127,224,11,102,1,44,88,208,95,200,252,81,157,164,3,82,23,136,5,27,36,47,174,175,125,206,61,231,200,238,47,109,251,194,22,14,154,52,87,69,11,65,183,50,41,82,25,49,138,234,16,103,194,68,152,82,162,113,22,3,199,92,155,80,112,105,4,99,26,5,149,42,33,69,51,122,105,172,67,129,117,80,182,233,121,255,155,212,53,29,4,151,249,180,121,173,55,80,170,55,211,0,160,44,207,4,199,58,140,53,166,10,4,86,134,68,88,201,152,104,99,164,164,58,71,179,22,195,227,156,199,89,136,9,225,2,83,1,25,206,66,33,177,80,130,83,166,152,142,33,65,65,1,185,91,222,108,27,104,91,91,87,105,15,191,234,179,219,173,87,57,207,94,212,69,87,86,40,40,193,169,83,229,54,163,144,16,104,162,21,214,84,38,152,230,222,164,34,210,96,162,50,30,115,1,17,139,56,10,180,218,186,145,22,173,12,10,140,114,234,173,42,58,152,152,123,235,53,198,36,140,68,194,60,54,242,81,81,18,135,88,48,239,46,55,44,151,64,152,148,153,57,230,245,178,179,190,182,237,73,87,66,99,245,67,236,224,243,171,155,180,215,117,229,154,186,24,169,79,166,235,103,112,227,230,112,31,142,222,205,134,156,239,143,32,180,11,186,22,22,133,133,202,45,43,93,27,91,93,205,156,187,157,135,148,91,213,216,246,152,194,242,186,83,5,10,26,123,181,249,99,90,139,174,117,117,249,31,89,13,188,77,207,225,31,217,36,119,124,131,198,182,219,66,221,78,251,20,61,189,238,106,247,124,248,50,124,27,126,28,62,30,62,13,251,195,231,39,195,221,225,195,240,115,248,58,236,135,239,195,126,190,130,30,81,165,232,2,153,92,3,143,50,129,37,163,6,251,127,33,113,102,18,129,67,45,121,30,17,150,72,154,92,32,47,239,95,14,61,95,181,175,222,87,199,95,51,251,92,63,243,221,71,141,211,35,50,237,255,70,231,110,61,42,93,239,252,186,7,243,111,105,53,252,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0b1a99dc-d621-4151-8384-3e221142a390"),
				ContainerUId = new Guid("ff16041c-18d5-46f3-baed-a5b8b559b3fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"RecordColumnValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordColumnValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordColumnValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,79,111,211,48,20,255,42,147,183,99,93,37,182,107,199,57,66,135,84,105,131,138,193,46,107,15,142,253,188,85,74,147,41,73,129,81,85,98,112,129,11,59,114,230,27,76,104,147,38,33,190,67,242,141,112,221,148,182,176,19,142,20,203,239,249,247,199,126,207,115,116,80,93,93,2,138,209,147,225,241,73,110,171,238,211,188,128,238,176,200,53,148,101,247,40,215,42,157,188,87,73,10,67,85,168,41,84,80,156,170,116,6,229,209,164,172,58,123,219,32,212,65,7,111,124,14,197,103,115,52,168,96,250,122,96,28,179,228,146,245,184,224,88,4,132,99,198,68,136,19,46,24,78,20,11,137,0,174,41,229,14,172,243,116,54,205,142,161,82,67,85,93,160,120,142,60,155,35,16,82,40,77,123,4,51,41,36,102,134,68,88,6,220,226,136,88,72,184,73,180,52,26,45,58,168,212,23,48,85,94,116,3,86,192,184,77,34,129,117,64,52,102,10,34,172,12,13,177,146,132,106,99,164,100,218,46,193,237,254,13,240,108,255,108,80,190,120,155,65,113,226,121,99,171,210,18,198,93,23,253,43,112,152,194,20,178,42,158,27,194,117,207,74,119,52,201,21,102,129,147,137,76,168,176,161,36,9,220,103,88,36,23,14,240,231,46,227,185,165,206,135,96,4,27,97,4,102,20,28,132,17,137,193,18,66,122,60,132,16,146,197,120,127,188,180,104,38,229,101,170,174,78,255,117,90,127,171,111,235,31,245,125,243,161,249,92,223,215,191,234,135,250,126,175,185,110,62,186,240,157,91,60,116,235,239,245,79,151,185,107,62,53,95,155,47,245,109,115,179,149,111,110,86,2,151,59,53,222,150,152,143,86,141,50,66,241,232,241,86,105,231,213,213,236,54,203,110,159,140,80,103,132,78,242,89,161,151,108,116,185,88,215,205,179,7,237,192,143,252,214,99,197,225,97,199,42,83,231,80,60,119,122,30,238,83,125,85,41,47,253,202,121,94,19,39,68,246,2,17,90,44,64,185,54,2,78,86,213,145,161,76,44,21,148,88,75,60,250,37,88,40,32,211,176,107,76,107,43,76,20,82,108,117,68,49,19,202,224,4,184,171,151,165,9,77,100,164,122,204,122,188,87,222,152,89,183,180,139,100,179,52,245,2,165,63,255,242,141,180,198,219,76,127,171,196,91,12,185,153,216,9,152,65,246,159,87,213,7,235,41,159,229,197,225,59,247,114,39,217,121,91,175,45,233,205,158,190,158,182,241,5,90,44,198,139,223,47,138,38,130,38,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8fba1047-ae93-410a-a843-da9895119d14"),
				ContainerUId = new Guid("ff16041c-18d5-46f3-baed-a5b8b559b3fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
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
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeShowEndOfStagePageParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var clientUnitSchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3fc920dd-5c62-4946-a873-1c00873e193a"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ClientUnitSchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			clientUnitSchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(clientUnitSchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"e1ba28db-8dae-4e66-869f-e505d74c589a",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(clientUnitSchemaUIdParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("95bf65a8-5bdc-4b02-b95a-1f12ff622cbd"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var entityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("29a26301-669f-494a-8967-ef76ebcb346b"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"EntityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entityIdParameter.SourceValue = new ProcessSchemaParameterValue(entityIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{dfce71b8-964d-4c09-bd58-0c97f1365945}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(entityIdParameter);
			var entryPointIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f14e9164-cb48-4c4d-9eda-2a426442f1fd"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"EntryPointId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entryPointIdParameter.SourceValue = new ProcessSchemaParameterValue(entryPointIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entryPointIdParameter);
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("63792a62-2e22-48b7-8c75-26ed007ef6a2"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"ae46fb87-c02c-4ae8-ad31-a923cdd994cf",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var titleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a9895f5a-79bc-4b95-be4c-0b420f907431"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Title",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			titleParameter.SourceValue = new ProcessSchemaParameterValue(titleParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Завершение стадии",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(titleParameter);
			var useCardProcessModuleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("17508aa3-5868-4feb-acab-c83ec5a89cff"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"UseCardProcessModule",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useCardProcessModuleParameter.SourceValue = new ProcessSchemaParameterValue(useCardProcessModuleParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(useCardProcessModuleParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("37dae5df-0de8-4721-b69a-620d86c5a9c6"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"OwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			ownerIdParameter.SourceValue = new ProcessSchemaParameterValue(ownerIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4ecc7287-ee70-49bd-b052-12d9c04640cc"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("81c142cf-f5e8-4758-b878-a1157cb21f63"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"InformationOnStep",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			informationOnStepParameter.SourceValue = new ProcessSchemaParameterValue(informationOnStepParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(informationOnStepParameter);
			var isRunningParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1f3d14a9-bcd1-4c8e-a749-366397869b93"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"IsRunning",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isRunningParameter.SourceValue = new ProcessSchemaParameterValue(isRunningParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(isRunningParameter);
			var templateParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				UId = new Guid("d9172536-2edb-4e0a-8746-c1e0cc5f4372"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Template",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			templateParameter.SourceValue = new ProcessSchemaParameterValue(templateParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#Lookup.90fa6d02-3e93-45d6-a72b-58dcffa411ae.21620f25-166f-42f1-8b4d-224a959040a3#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(templateParameter);
			var moduleParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				UId = new Guid("517a7110-5a34-4df7-82d8-d5dc907e9672"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Module",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			moduleParameter.SourceValue = new ProcessSchemaParameterValue(moduleParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#Lookup.90fa6d02-3e93-45d6-a72b-58dcffa411ae.eb89c336-08b9-4951-bffd-3f5abc433174#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(moduleParameter);
			var pressedButtonCodeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a14f806a-3e1e-4e54-bb85-35b9fa16cb46"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"PressedButtonCode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			pressedButtonCodeParameter.SourceValue = new ProcessSchemaParameterValue(pressedButtonCodeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pressedButtonCodeParameter);
			var urlParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("87c4ce9c-dc60-48b9-829f-2413eccb33a5"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Url",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			urlParameter.SourceValue = new ProcessSchemaParameterValue(urlParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"""[Module]/[Page]/add""",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(urlParameter);
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ff39510a-5dba-415c-ac1f-d1a574335f9d"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"CurrentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			currentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(currentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(currentActivityIdParameter);
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f4e19f90-eeee-4fa4-a962-1ac9c5d13239"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"CreateActivity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			createActivityParameter.SourceValue = new ProcessSchemaParameterValue(createActivityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("50c1dbf6-4a8a-4780-8b54-f3800758bf98"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ActivityPriority",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityPriorityParameter.SourceValue = new ProcessSchemaParameterValue(activityPriorityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"ab96fa02-7fe6-df11-971b-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e931b39e-499f-427a-8132-41dc73371b59"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"StartIn",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			startInParameter.SourceValue = new ProcessSchemaParameterValue(startInParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("25dee447-fd15-4f67-b915-1792256a14e8"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"StartInPeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			startInPeriodParameter.SourceValue = new ProcessSchemaParameterValue(startInPeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f2884f23-6703-46ee-a2cd-2d78c0c2b128"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Duration",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationParameter.SourceValue = new ProcessSchemaParameterValue(durationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3aebb227-f5ea-4f1c-8d10-a95417dbe719"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"DurationPeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationPeriodParameter.SourceValue = new ProcessSchemaParameterValue(durationPeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("42bdb602-b83d-43d8-842d-440077c90388"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4dac1b12-153a-42be-902d-fedcd1d759ed"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"RemindBefore",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			remindBeforeParameter.SourceValue = new ProcessSchemaParameterValue(remindBeforeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6ffa6e10-a7e1-43b9-bb48-f7c62916ec47"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"RemindBeforePeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			remindBeforePeriodParameter.SourceValue = new ProcessSchemaParameterValue(remindBeforePeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1bd8bcc2-2d82-447c-b71e-1d0771c9d792"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ActivityResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activityResultParameter.SourceValue = new ProcessSchemaParameterValue(activityResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activityResultParameter);
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5fba8a1d-f1e7-4d1c-b41d-83662181e6e2"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"IsActivityCompleted",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isActivityCompletedParameter.SourceValue = new ProcessSchemaParameterValue(isActivityCompletedParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var nextStageResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7584122f-a24d-4575-a5b9-b55b2a9abc8a"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"NextStageResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			nextStageResultParameter.SourceValue = new ProcessSchemaParameterValue(nextStageResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(nextStageResultParameter);
			var currentStageIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				UId = new Guid("8de5380d-ac3d-411c-8a77-2c835c3d43d4"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"CurrentStageId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			currentStageIdParameter.SourceValue = new ProcessSchemaParameterValue(currentStageIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{e18f5001-d887-417b-8123-79f8b4091406}].[Parameter:{be61dc40-5e32-4d0b-9d27-1e361e54f22b}].[EntityColumn:{797ac352-4979-4d28-906f-82feb6dbc9dc}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(currentStageIdParameter);
			var nextStageIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				UId = new Guid("f3923742-d7d7-43e1-8429-ef222561e1eb"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"NextStageId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			nextStageIdParameter.SourceValue = new ProcessSchemaParameterValue(nextStageIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{b84b8659-7d6c-46df-be98-b96c5d0e5b85}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(nextStageIdParameter);
			var opportunityIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("7b3decd5-3d89-4cff-b95d-730a6013cb27"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"OpportunityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			opportunityIdParameter.SourceValue = new ProcessSchemaParameterValue(opportunityIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{dfce71b8-964d-4c09-bd58-0c97f1365945}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(opportunityIdParameter);
			var isStageChangedByUserParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("61077983-3941-4d4a-9630-edfbacf49a87"),
				ContainerUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"IsStageChangedByUser",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isStageChangedByUserParameter.SourceValue = new ProcessSchemaParameterValue(isStageChangedByUserParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{2d124c72-8de2-4327-a821-7370bb4f3f04}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(isStageChangedByUserParameter);
		}

		protected virtual void InitializeReadOpportunityParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4e5d457b-42b9-4672-8b52-c52e77513010"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,187,142,212,48,20,253,21,228,130,42,70,113,226,36,118,40,71,3,154,102,89,137,5,33,237,142,86,142,125,189,99,41,143,217,216,17,187,138,70,66,162,162,226,31,248,130,41,128,130,2,126,33,243,71,56,201,12,72,91,32,10,26,36,23,246,181,207,185,231,28,93,247,215,198,62,51,165,131,54,215,162,180,16,116,43,149,35,205,40,149,113,164,112,33,34,129,105,36,1,51,202,24,230,180,128,84,49,153,136,34,67,65,45,42,200,209,140,94,42,227,80,96,28,84,54,191,236,127,147,186,182,131,224,90,79,135,151,114,3,149,120,53,54,16,64,83,93,176,12,203,48,146,152,10,96,88,168,152,96,193,163,88,42,197,57,149,26,29,181,16,146,128,230,4,19,22,134,152,82,82,96,206,82,141,21,87,192,57,240,36,36,128,130,18,180,91,222,109,91,176,214,52,117,222,195,175,253,197,253,214,171,156,123,47,154,178,171,106,20,84,224,196,185,112,155,81,72,8,52,145,2,75,202,19,76,53,100,88,196,92,225,216,59,140,50,6,36,37,222,169,20,91,55,210,162,149,66,129,18,78,188,22,101,7,19,115,111,188,198,40,14,9,75,82,143,37,177,183,19,71,33,102,169,119,167,85,170,57,196,41,231,133,58,229,245,188,51,126,111,236,89,87,65,107,228,49,118,240,249,53,109,222,203,166,118,109,83,142,212,103,211,243,11,184,115,115,184,199,171,55,179,33,231,235,35,8,237,130,206,194,162,52,80,187,101,45,27,101,234,155,153,115,183,243,144,106,43,90,99,79,41,44,111,59,81,162,160,53,55,155,63,166,181,232,172,107,170,255,200,106,224,109,122,14,63,100,147,220,113,6,149,177,219,82,220,79,231,28,61,190,237,26,247,116,248,52,124,25,190,29,222,31,62,12,251,195,199,71,195,143,195,187,225,251,240,121,216,15,95,135,253,252,4,61,160,202,209,21,82,90,66,70,10,63,255,41,85,152,202,144,227,66,37,12,135,146,103,154,196,105,194,105,114,133,188,188,127,217,244,114,101,95,188,173,79,191,102,246,185,126,226,171,15,10,231,39,100,222,255,141,206,221,122,84,186,222,249,245,19,174,198,111,137,252,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8447c567-6c37-4e2b-a3dd-2447daaaaf66"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0e8e3ca1-4e02-4cfd-9534-dfc91c400628"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7f19d59d-6e3e-4583-9422-7df884633ba7"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fbccc177-264d-4b7a-81b0-a23219940711"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d4181cb4-8130-424d-ae68-c843f87a8855"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				UId = new Guid("50b25f81-e993-4f01-a6e6-374b3659b858"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("be61dc40-5e32-4d0b-9d27-1e361e54f22b"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("06755d62-3109-44a6-a9ab-3f4754d27ca3"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				UId = new Guid("daf5e600-722b-43e1-a28d-5cefd2a1ba80"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				UId = new Guid("f1cb258f-287d-4c5c-b4ac-277f0f9884bb"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				UId = new Guid("797c93d6-bc60-4d21-a669-039897df02c3"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				UId = new Guid("0f2ed61f-3f3e-487a-8430-3fb6764f469d"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				UId = new Guid("4e8bf658-f625-4d19-ad5b-727fb3b2847e"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("3d15909c-f006-4a7a-8b1c-fede8e2a9eae"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("86e11392-27d0-4340-9d60-c67a8335b463"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4b80d1c9-90f8-4449-82d6-693bf426b73b"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				UId = new Guid("dd921855-88e1-45b5-a243-fcafcf724ef7"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b7b63732-4013-4ac2-ae59-c3d73f0c2d6d"),
				ContainerUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
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

		protected virtual void InitializeReadNextStageParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a75219e0-00f3-4d5d-a9f7-651b6e4376ef"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,106,220,48,20,253,149,160,69,87,86,177,45,141,101,187,203,97,10,217,164,129,62,40,36,67,208,227,106,70,224,199,196,150,105,131,25,72,219,85,41,180,95,80,250,11,165,36,144,244,145,111,144,255,168,154,113,167,45,89,148,110,186,40,8,115,117,165,123,206,185,71,215,253,137,105,239,155,194,66,147,107,94,180,16,116,251,42,71,50,77,100,2,132,99,70,35,130,169,84,26,167,138,74,28,201,84,198,90,167,60,139,25,10,42,94,66,142,198,234,153,50,22,5,198,66,217,230,71,253,47,80,219,116,16,156,232,237,230,161,92,66,201,31,111,9,164,102,42,245,216,90,166,158,128,113,133,5,36,17,78,53,17,68,100,41,159,80,141,70,45,58,100,113,150,77,40,142,121,168,49,165,153,196,25,100,20,3,208,148,137,73,146,50,29,162,160,0,109,103,207,87,13,180,173,169,171,188,135,159,241,163,179,149,87,57,114,79,235,162,43,43,20,148,96,249,33,183,203,28,77,164,214,145,34,12,203,144,100,152,38,18,48,151,196,127,168,98,92,128,103,155,120,33,146,175,236,6,22,185,15,238,102,56,31,222,185,11,247,217,221,184,79,195,27,119,189,231,190,249,240,171,187,28,206,81,160,184,229,79,120,209,193,150,182,55,190,129,68,36,130,81,136,113,26,135,10,211,44,244,232,97,196,112,44,24,241,166,74,29,139,112,103,230,126,101,97,1,141,119,178,61,232,74,104,140,28,29,4,111,111,221,228,189,172,43,219,212,197,6,252,224,247,130,209,254,31,167,79,199,150,205,120,180,41,69,235,160,107,97,90,24,168,236,172,146,181,50,213,98,124,239,245,218,87,149,43,222,152,118,103,213,236,180,227,5,10,26,179,88,254,209,210,105,215,218,186,252,15,91,14,124,187,30,201,79,228,86,246,102,96,149,105,87,5,63,219,238,115,116,231,180,171,237,61,247,126,247,172,123,195,11,247,197,93,186,139,225,213,240,118,120,237,163,107,159,26,94,186,143,126,14,174,220,213,120,31,221,194,205,209,49,82,140,209,84,3,224,40,86,145,31,222,48,198,25,215,4,71,140,17,146,8,65,133,32,199,200,107,253,103,10,142,246,219,7,207,170,221,207,55,58,48,191,235,179,183,18,135,187,202,188,255,27,209,235,249,70,246,124,237,215,119,84,51,51,197,67,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b64d0a3c-c0d0-4958-81f1-b5ede9765ad4"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("24325d83-50e7-4573-8f91-35e07a45c717"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f3903c6b-98c5-40bf-916d-98a7b572a579"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a0182d1d-381b-4c10-a8ec-d985836d5cc9"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("85950cf7-252d-4b5c-9bfd-ad509d940e2f"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				UId = new Guid("81c297c2-fc42-4e9b-89ee-73751508db6a"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,75,204,77,181,50,180,50,4,0,203,8,241,43,15,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				UId = new Guid("92ea37fd-45c4-4fb2-98b7-eb6e66edd5ff"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7ab26365-d3e5-4729-92b4-d09e2de024d0"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				UId = new Guid("95f97244-d092-4885-aea6-53b76e1303a7"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				UId = new Guid("2cc4d02b-1588-44de-9fa7-b09506a2c14f"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				UId = new Guid("1cb876d9-d17b-4fc0-a745-da0b4ea53266"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				UId = new Guid("4201c6a3-e0ab-4f41-b531-0fb631720790"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				UId = new Guid("96bc11af-2c34-4987-a0f6-2575203da254"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				UId = new Guid("92ba46a0-d926-4f32-868c-882c9bef0c1b"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3df688c3-a044-4e2f-b4d5-974b22314e82"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e3d4eab8-cdc4-425a-be85-68f08022c240"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				UId = new Guid("8d2f8884-011d-4524-ac6d-614dedac86a0"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a222d31f-5ecb-4b6e-9561-198ae0448311"),
				ContainerUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
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

		protected virtual void InitializeReadCountNotFinishedActivitiesParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6a1d2bd1-de4f-40aa-9125-c113b2d391c5"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,85,75,107,220,86,20,254,43,65,139,174,116,205,125,233,62,166,187,24,183,24,74,26,104,90,10,193,132,251,56,55,22,214,72,147,145,68,29,6,67,157,64,75,87,217,119,83,218,125,193,139,186,148,182,118,255,130,244,143,122,102,198,147,152,97,82,210,52,93,100,33,113,117,117,222,231,124,223,89,60,42,219,143,202,170,131,249,36,185,170,133,188,63,140,147,204,74,165,180,227,142,120,155,12,145,92,120,226,66,76,196,211,66,123,235,140,72,90,100,121,237,166,48,201,214,218,7,177,236,178,188,236,96,218,78,30,46,94,25,237,230,61,228,143,210,234,227,179,112,12,83,247,249,210,65,144,210,70,35,56,113,50,4,34,61,101,232,42,22,196,56,198,131,228,14,221,218,108,29,11,149,222,203,96,41,81,34,112,34,131,227,196,23,74,17,238,156,52,92,39,206,157,207,242,10,82,119,112,58,155,67,219,150,77,61,89,192,203,243,131,167,51,140,114,237,123,191,169,250,105,157,229,83,232,220,125,215,29,79,50,169,140,140,210,59,140,65,121,34,35,115,196,138,228,137,166,16,184,75,16,11,157,178,60,184,89,183,52,155,13,63,140,95,15,215,195,47,195,197,240,235,112,145,229,115,72,48,135,58,192,173,220,28,72,149,188,209,36,80,142,185,57,48,196,69,193,136,179,92,132,24,173,149,1,77,70,215,185,47,92,213,195,42,190,69,137,138,158,219,130,106,150,136,6,103,137,4,197,137,89,5,196,172,79,66,11,158,18,223,84,253,147,166,57,233,103,88,241,246,94,63,133,121,25,110,218,7,216,135,102,62,89,132,166,238,230,77,181,52,126,239,150,194,186,77,55,63,191,92,151,166,90,253,89,42,102,103,121,223,194,126,85,66,221,29,212,161,137,101,253,120,213,193,179,51,212,153,206,220,188,108,55,5,61,120,210,187,10,11,80,62,62,254,199,194,239,247,109,215,76,223,183,124,115,204,21,205,224,208,174,98,94,206,116,44,219,89,229,158,174,190,39,217,7,79,250,166,251,112,248,105,184,28,126,31,159,143,223,13,23,227,139,59,195,95,183,167,99,45,146,109,153,218,168,198,20,64,51,111,136,85,50,226,88,83,75,124,44,12,161,193,234,196,132,42,172,44,110,44,156,229,239,218,249,195,195,246,211,175,234,13,34,215,165,60,218,195,219,173,139,251,27,237,201,226,77,226,61,59,218,68,124,132,19,243,78,89,0,128,23,54,112,20,117,75,176,202,72,145,140,130,38,90,71,38,88,212,62,44,69,223,150,5,130,137,70,38,27,136,151,6,89,64,91,79,172,11,10,253,48,158,132,20,10,89,103,207,43,102,192,26,65,36,165,40,4,0,196,40,89,144,164,92,33,82,20,188,128,112,155,42,126,28,174,199,243,241,25,190,95,12,87,195,111,195,229,222,240,61,54,232,106,184,28,191,197,247,245,112,121,103,60,223,150,217,9,20,75,189,42,60,50,49,77,9,235,196,36,35,70,107,75,184,228,20,15,46,89,170,55,64,185,219,52,21,184,250,95,32,101,255,24,194,201,221,230,116,27,39,88,171,112,226,241,126,23,74,86,54,255,3,45,188,156,172,247,43,225,29,188,176,141,176,149,224,255,128,0,17,84,164,66,37,18,64,226,30,244,5,238,100,48,137,0,167,150,69,86,20,218,176,183,71,0,226,139,105,129,197,166,70,82,68,128,192,24,2,147,184,106,141,87,32,162,245,22,3,121,53,220,63,15,127,32,251,252,137,207,213,248,236,134,123,198,111,112,180,207,113,166,113,49,238,104,42,23,148,153,66,105,226,152,192,92,5,167,136,31,92,147,41,170,100,65,40,107,125,220,52,245,227,190,196,243,27,119,244,1,156,118,187,168,190,195,251,215,18,253,235,70,248,16,189,86,213,178,131,127,3,170,229,58,107,29,9,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0959d33a-0a66-4437-b25b-f3bda29e8610"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bb79a7c9-22cc-4cfa-8454-2c336d3bbfa5"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("24dd4a10-4e2c-4dbc-ac53-610bca6745d2"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fc43106b-6ad4-40bf-a590-bdcc5c40964f"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0d8bea86-be3d-47ce-be07-e371b62fc691"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,1,0,242,67,189,42,2,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("37082b06-1012-4b4d-a2ad-042c8195bd8d"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,9,201,44,201,73,181,50,180,50,4,0,57,183,224,50,16,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("1fd1d50c-01de-4e1b-90a2-28e34e2af4be"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("adb67efb-8644-4a2e-a47b-ead879586020"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				UId = new Guid("b4741ed6-a5d9-425f-89cb-d88bb25d9d90"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				UId = new Guid("2708fded-c17f-4033-9321-837e75a17968"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				UId = new Guid("86a273c0-dc2f-4650-9c6c-5b7ffee3cd43"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				UId = new Guid("cbd49361-8bca-4903-b561-a67607267747"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				UId = new Guid("ce29d90c-dbf6-45ef-b05c-543edaf33473"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				UId = new Guid("59ffe7bc-8788-4279-be21-1c5a28993330"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f2b89827-46fd-4c18-b956-876018f44ca1"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c76447c0-1087-47a0-b5f1-4dbe3d1a44b8"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				UId = new Guid("68448e85-b99c-40e3-8923-f71f373a760d"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fc431747-d3f1-46b1-8204-6f7506150101"),
				ContainerUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
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
			ProcessSchemaUserTask readcurrentstage = CreateReadCurrentStageUserTask();
			FlowElements.Add(readcurrentstage);
			ProcessSchemaUserTask updateopportunitystage = CreateUpdateOpportunityStageUserTask();
			FlowElements.Add(updateopportunitystage);
			ProcessSchemaUserTask showendofstagepage = CreateShowEndOfStagePageUserTask();
			FlowElements.Add(showendofstagepage);
			ProcessSchemaUserTask readopportunity = CreateReadOpportunityUserTask();
			FlowElements.Add(readopportunity);
			ProcessSchemaUserTask readnextstage = CreateReadNextStageUserTask();
			FlowElements.Add(readnextstage);
			ProcessSchemaFormulaTask setnextstagenumber = CreateSetNextStageNumberFormulaTask();
			FlowElements.Add(setnextstagenumber);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask readcountnotfinishedactivities = CreateReadCountNotFinishedActivitiesUserTask();
			FlowElements.Add(readcountnotfinishedactivities);
			ProcessSchemaFormulaTask setshowendofstagepage = CreateSetShowEndOfStagePageFormulaTask();
			FlowElements.Add(setshowendofstagepage);
			ProcessSchemaFormulaTask setnextstagebyprocess = CreateSetNextStageByProcessFormulaTask();
			FlowElements.Add(setnextstagebyprocess);
			ProcessSchemaExclusiveGateway exclusivegateway3 = CreateExclusiveGateway3ExclusiveGateway();
			FlowElements.Add(exclusivegateway3);
			ProcessSchemaExclusiveGateway exclusivegateway4 = CreateExclusiveGateway4ExclusiveGateway();
			FlowElements.Add(exclusivegateway4);
			ProcessSchemaFormulaTask setnextstagebyuser = CreateSetNextStageByUserFormulaTask();
			FlowElements.Add(setnextstagebyuser);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateConditionalFlow5ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow15SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("b3f9e0ab-7904-428d-b390-7329ccaaea72"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f2f9628a-148c-457c-86a9-7f7baece560b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3442dd87-3f5e-436c-9d5c-f6787c0fab8d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("4fabb2fd-fc21-47f9-bdc2-021c87df6c32"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(1002, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ff16041c-18d5-46f3-baed-a5b8b559b3fa"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2a12d765-1b7d-47e3-a00b-5c931dab802d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("de86ae86-1ff7-41f6-a500-595b3738ef05"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(260, 212),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("7446a197-1d3b-4d89-ae1b-7b1cff8b47a1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(638, 214),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2cc075ef-e2dc-4bbc-8186-706550bc8b21"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("78c5c0a9-ea1b-4e76-b049-2da3afc80ec6"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("dc49463a-2212-4b84-8e05-c80a9aaceadd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("126115de-6094-4d04-b02d-edb4098a40a6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(1200, 213),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ff16041c-18d5-46f3-baed-a5b8b559b3fa"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("88c362ec-c9e0-406d-8843-df7ff2006237"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(411, 215),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2cc075ef-e2dc-4bbc-8186-706550bc8b21"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("61b4d6d8-8e40-41d0-97fb-42dc65fd11af"),
				ConditionExpression = @"![#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{2d124c72-8de2-4327-a821-7370bb4f3f04}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(210, 266),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3442dd87-3f5e-436c-9d5c-f6787c0fab8d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow7",
				UId = new Guid("274be584-2828-4da3-beb0-c801d5ce9ff7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(198, 264),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3442dd87-3f5e-436c-9d5c-f6787c0fab8d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("a7181db3-fab9-4d7c-8eee-d4d845df77f3"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{868321fe-9c79-4ab3-8a81-b41ecb0e6d15}].[Parameter:{adb67efb-8644-4a2e-a47b-ead879586020}]#] > 0",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(310, 270),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(315, 315));
			schemaFlow.PolylinePointPositions.Add(new Point(315, 254));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow8",
				UId = new Guid("c5adeff7-f3e3-4188-a300-892a510bc2dc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(199, 391),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4f941b7c-c6b4-4ad8-959c-b82b3f3767e5"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("0ce357c0-1c14-46c6-84d5-8ecb0f975c95"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(289, 316),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4f941b7c-c6b4-4ad8-959c-b82b3f3767e5"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("d1371036-7604-4d06-bb84-ab1771858c58"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{4a896c50-5660-4509-bcfa-09fdb87708e7}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(944, 201),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("78c5c0a9-ea1b-4e76-b049-2da3afc80ec6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2a12d765-1b7d-47e3-a00b-5c931dab802d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(763, 105));
			schemaFlow.PolylinePointPositions.Add(new Point(1442, 105));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow5",
				UId = new Guid("afad4434-030b-4ed8-9fde-a8b0477c8747"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(777, 258),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("78c5c0a9-ea1b-4e76-b049-2da3afc80ec6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ee1eb647-192e-47bf-9462-02ad7e99bd9e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow12",
				UId = new Guid("a1d18a8e-b062-4566-a237-1d628e789f17"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(828, 250),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ee1eb647-192e-47bf-9462-02ad7e99bd9e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow5ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow5",
				UId = new Guid("3bdfa389-17e8-4004-86a8-c6c06af091ae"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{2d124c72-8de2-4327-a821-7370bb4f3f04}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(837, 346),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ee1eb647-192e-47bf-9462-02ad7e99bd9e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("55b8d26d-8e5c-487a-81de-2f9292f3aa90"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("a2626743-6dbb-41a7-b547-aaed96410cf4"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(1030, 210),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2b19d13a-f7cf-4d1c-b231-8775fd9b48d7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("3d3b7a67-cde7-4567-b363-dac27ac781cc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(1174, 212),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2b19d13a-f7cf-4d1c-b231-8775fd9b48d7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow15SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow15",
				UId = new Guid("03de0816-6c46-488e-b4ce-bfb9d85b7edb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				CurveCenterPosition = new Point(1108, 302),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("55b8d26d-8e5c-487a-81de-2f9292f3aa90"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("7563325b-66c4-4b05-af10-d2119fcd7b6c"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(1465, 570),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("7563325b-66c4-4b05-af10-d2119fcd7b6c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(1436, 570),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("f2f9628a-148c-457c-86a9-7f7baece560b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"Start1",
				Position = new Point(50, 191),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("2a12d765-1b7d-47e3-a00b-5c931dab802d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"Terminate1",
				Position = new Point(1394, 191),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadCurrentStageUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"ReadCurrentStage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(449, 177),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadCurrentStageParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateUpdateOpportunityStageUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("ff16041c-18d5-46f3-baed-a5b8b559b3fa"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"UpdateOpportunityStage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1261, 177),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeUpdateOpportunityStageParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateShowEndOfStagePageUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"ShowEndOfStagePage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1142, 177),
				SchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeShowEndOfStagePageParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadOpportunityUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e18f5001-d887-417b-8123-79f8b4091406"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"ReadOpportunity",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(309, 177),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadOpportunityParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadNextStageUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"ReadNextStage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(897, 177),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadNextStageParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateSetNextStageNumberFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("2cc075ef-e2dc-4bbc-8186-706550bc8b21"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"SetNextStageNumber",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(582, 177),
				ResultParameterMetaPath = @"d7748fee-12d1-4402-9af3-177336bb4bb3",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,204,65,11,130,64,16,134,225,191,34,120,140,137,221,220,117,29,175,209,161,83,65,71,241,48,206,206,80,160,6,106,68,136,255,189,237,218,229,59,188,240,124,77,222,156,231,203,123,148,233,198,119,25,168,86,234,103,105,247,169,254,133,83,47,131,140,75,189,58,95,170,88,115,0,173,208,131,211,88,65,85,120,11,20,66,229,49,198,96,80,182,4,174,52,209,32,139,76,245,42,214,70,163,17,129,152,12,56,17,132,14,89,211,67,196,192,86,249,208,209,143,156,198,229,177,124,142,207,254,53,140,245,234,89,213,198,34,0,155,2,193,149,44,201,23,105,92,12,212,137,67,246,186,181,121,155,237,50,251,5,232,159,135,158,200,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("3442dd87-3f5e-436c-9d5c-f6787c0fab8d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"ExclusiveGateway1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(134, 177),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadCountNotFinishedActivitiesUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"ReadCountNotFinishedActivities",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(127, 282),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadCountNotFinishedActivitiesParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateSetShowEndOfStagePageFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("4f941b7c-c6b4-4ad8-959c-b82b3f3767e5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"SetShowEndOfStagePage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(127, 394),
				ResultParameterMetaPath = @"4a896c50-5660-4509-bcfa-09fdb87708e7",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,41,42,77,5,0,141,76,252,253,4,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateSetNextStageByProcessFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("2b19d13a-f7cf-4d1c-b231-8775fd9b48d7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"SetNextStageByProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1016, 177),
				ResultParameterMetaPath = @"b84b8659-7d6c-46df-be98-b96c5d0e5b85",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,205,10,130,64,20,6,208,135,105,125,99,212,249,81,183,225,162,85,65,75,113,113,231,206,55,20,56,6,106,68,136,239,222,180,109,123,224,244,135,254,188,92,222,19,230,155,220,145,184,141,60,46,24,142,89,255,160,27,145,48,173,237,86,137,21,49,214,80,144,34,146,22,101,136,21,43,242,33,22,2,120,23,160,247,28,174,60,115,194,138,185,221,154,18,92,185,24,72,27,209,164,163,47,169,169,189,35,120,11,107,17,130,137,241,87,186,105,125,172,159,211,115,124,165,169,221,24,10,57,48,137,110,76,94,112,196,85,19,168,98,239,74,87,163,176,133,219,135,195,240,5,112,43,96,236,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway3ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("78c5c0a9-ea1b-4e76-b049-2da3afc80ec6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"ExclusiveGateway3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(701, 177),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway4ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("ee1eb647-192e-47bf-9462-02ad7e99bd9e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"ExclusiveGateway4",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(792, 177),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaFormulaTask CreateSetNextStageByUserFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("55b8d26d-8e5c-487a-81de-2f9292f3aa90"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6c23f386-0505-4ea2-980f-92a547bf98fe"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"SetNextStageByUser",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1016, 310),
				ResultParameterMetaPath = @"b84b8659-7d6c-46df-be98-b96c5d0e5b85",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,187,10,194,48,20,0,208,143,113,190,146,247,107,149,14,78,10,142,165,67,30,55,40,52,17,218,136,72,233,191,27,87,215,3,103,60,140,231,245,242,174,184,220,226,29,139,119,217,207,43,78,199,174,127,48,204,88,176,54,183,33,53,89,18,66,33,25,163,65,80,29,192,80,198,65,219,108,130,32,150,10,162,246,30,174,126,241,5,27,46,110,11,168,104,138,130,128,68,206,64,36,18,192,38,166,129,34,87,20,165,200,140,133,95,25,106,123,180,207,233,57,191,74,117,155,182,218,71,46,123,176,218,246,197,12,88,162,50,24,150,49,168,20,162,77,113,159,14,211,23,183,37,236,205,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new OpportunityManagementEndOfStage(userConnection);
		}

		public override object Clone() {
			return new OpportunityManagementEndOfStageSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityManagementEndOfStage

	/// <exclude/>
	public class OpportunityManagementEndOfStage : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, OpportunityManagementEndOfStage process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ReadCurrentStageFlowElement

		/// <exclude/>
		public class ReadCurrentStageFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadCurrentStageFlowElement(UserConnection userConnection, OpportunityManagementEndOfStage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadCurrentStage";
				IsLogging = true;
				SchemaElementUId = new Guid("456fe102-f895-4fd8-8351-a77859dd709e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,148,193,106,220,48,16,134,95,101,209,161,39,107,177,44,219,178,220,99,216,150,92,210,64,211,82,72,66,144,173,81,98,176,189,27,91,166,9,203,66,72,160,80,154,182,143,80,122,234,53,148,110,187,73,154,246,21,228,55,170,188,206,182,144,67,201,53,96,131,53,210,252,243,235,243,72,211,189,172,126,146,229,26,170,88,137,188,6,167,89,151,49,2,9,144,36,148,99,0,34,176,79,195,0,39,34,84,152,17,15,152,32,1,241,8,65,78,41,10,136,81,159,61,146,153,70,78,166,161,168,227,237,233,63,81,93,53,224,236,169,229,224,121,122,0,133,120,209,21,72,83,197,100,68,40,86,105,68,177,207,132,196,9,132,4,71,138,38,52,225,145,8,124,133,122,47,17,23,73,200,173,141,36,164,128,125,79,5,152,131,242,176,164,32,0,220,128,166,44,68,78,14,74,143,142,38,21,212,117,54,46,227,41,252,253,222,58,158,88,151,125,237,181,113,222,20,37,114,10,208,98,83,232,131,24,9,112,193,15,82,129,83,159,7,216,87,192,176,160,92,98,42,18,230,177,8,72,72,24,114,82,49,209,157,44,90,151,200,145,66,139,151,34,111,96,169,60,205,172,71,143,186,36,10,66,155,75,104,106,121,121,46,142,194,136,97,37,67,197,129,134,156,39,114,197,235,105,147,217,239,172,222,104,10,168,178,244,22,59,88,126,227,42,158,166,227,82,87,227,188,147,222,88,46,223,130,35,221,195,189,157,122,213,111,72,219,120,151,132,102,78,83,195,90,158,65,169,71,101,58,150,89,185,223,107,206,102,54,165,152,136,42,171,87,20,70,135,141,200,145,83,101,251,7,255,165,181,214,212,122,92,60,160,173,58,118,155,86,195,54,217,210,110,215,131,50,171,39,185,56,94,142,99,244,232,176,25,235,199,230,139,89,180,167,230,162,61,109,207,7,230,155,185,48,55,230,166,125,103,230,3,243,187,61,49,191,150,161,239,102,49,52,159,204,220,6,190,218,185,203,65,251,222,92,155,185,249,105,223,155,246,116,96,227,115,243,163,61,51,215,237,185,21,91,180,39,237,89,251,161,125,107,163,151,3,115,101,85,174,151,235,175,218,55,102,209,105,125,238,74,90,233,69,251,177,183,129,238,216,141,209,14,2,18,169,192,117,9,150,145,165,233,19,150,224,136,120,20,51,174,162,196,119,57,241,221,112,216,157,17,153,250,46,14,128,122,216,151,110,130,185,244,24,38,22,60,1,123,102,60,47,25,50,206,68,74,3,59,207,25,183,139,188,8,115,215,30,222,200,83,144,132,50,73,185,76,119,144,133,249,208,16,109,175,215,207,94,151,171,123,164,255,243,187,67,27,189,19,24,229,80,216,22,177,109,125,15,166,51,155,176,185,42,21,79,239,67,184,75,25,149,58,211,199,253,125,18,79,239,131,124,182,219,65,223,157,217,231,15,80,37,94,191,117,5,0,0 })));
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

			private bool _readSomeTopRecords = false;
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,75,204,77,181,50,180,50,4,0,203,8,241,43,15,0,0,0 })));
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
								new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"));
					}
					return _resultEntityCollection;
				}
				set {
					_resultEntityCollection = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: UpdateOpportunityStageFlowElement

		/// <exclude/>
		public class UpdateOpportunityStageFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public UpdateOpportunityStageFlowElement(UserConnection userConnection, OpportunityManagementEndOfStage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "UpdateOpportunityStage";
				IsLogging = true;
				SchemaElementUId = new Guid("ff16041c-18d5-46f3-baed-a5b8b559b3fa");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Stage = () => (Guid)((process.ShowEndOfStagePage.NextStageId));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Stage", () => _recordColumnValues_Stage.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Stage;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private bool _isMatchConditions = true;
			public override bool IsMatchConditions {
				get {
					return _isMatchConditions;
				}
				set {
					_isMatchConditions = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,110,212,48,20,253,21,228,5,171,24,37,177,227,71,88,142,6,52,155,82,137,130,144,218,81,229,216,55,29,75,121,76,19,71,180,138,70,66,98,197,138,127,224,11,102,1,44,88,208,95,200,252,81,157,164,3,82,23,136,5,27,36,47,174,175,125,206,61,231,200,238,47,109,251,194,22,14,154,52,87,69,11,65,183,50,41,82,25,49,138,234,16,103,194,68,152,82,162,113,22,3,199,92,155,80,112,105,4,99,26,5,149,42,33,69,51,122,105,172,67,129,117,80,182,233,121,255,155,212,53,29,4,151,249,180,121,173,55,80,170,55,211,0,160,44,207,4,199,58,140,53,166,10,4,86,134,68,88,201,152,104,99,164,164,58,71,179,22,195,227,156,199,89,136,9,225,2,83,1,25,206,66,33,177,80,130,83,166,152,142,33,65,65,1,185,91,222,108,27,104,91,91,87,105,15,191,234,179,219,173,87,57,207,94,212,69,87,86,40,40,193,169,83,229,54,163,144,16,104,162,21,214,84,38,152,230,222,164,34,210,96,162,50,30,115,1,17,139,56,10,180,218,186,145,22,173,12,10,140,114,234,173,42,58,152,152,123,235,53,198,36,140,68,194,60,54,242,81,81,18,135,88,48,239,46,55,44,151,64,152,148,153,57,230,245,178,179,190,182,237,73,87,66,99,245,67,236,224,243,171,155,180,215,117,229,154,186,24,169,79,166,235,103,112,227,230,112,31,142,222,205,134,156,239,143,32,180,11,186,22,22,133,133,202,45,43,93,27,91,93,205,156,187,157,135,148,91,213,216,246,152,194,242,186,83,5,10,26,123,181,249,99,90,139,174,117,117,249,31,89,13,188,77,207,225,31,217,36,119,124,131,198,182,219,66,221,78,251,20,61,189,238,106,247,124,248,50,124,27,126,28,62,30,62,13,251,195,231,39,195,221,225,195,240,115,248,58,236,135,239,195,126,190,130,30,81,165,232,2,153,92,3,143,50,129,37,163,6,251,127,33,113,102,18,129,67,45,121,30,17,150,72,154,92,32,47,239,95,14,61,95,181,175,222,87,199,95,51,251,92,63,243,221,71,141,211,35,50,237,255,70,231,110,61,42,93,239,252,186,7,243,111,105,53,252,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,79,111,211,48,20,255,42,147,183,99,93,37,182,107,199,57,66,135,84,105,131,138,193,46,107,15,142,253,188,85,74,147,41,73,129,81,85,98,112,129,11,59,114,230,27,76,104,147,38,33,190,67,242,141,112,221,148,182,176,19,142,20,203,239,249,247,199,126,207,115,116,80,93,93,2,138,209,147,225,241,73,110,171,238,211,188,128,238,176,200,53,148,101,247,40,215,42,157,188,87,73,10,67,85,168,41,84,80,156,170,116,6,229,209,164,172,58,123,219,32,212,65,7,111,124,14,197,103,115,52,168,96,250,122,96,28,179,228,146,245,184,224,88,4,132,99,198,68,136,19,46,24,78,20,11,137,0,174,41,229,14,172,243,116,54,205,142,161,82,67,85,93,160,120,142,60,155,35,16,82,40,77,123,4,51,41,36,102,134,68,88,6,220,226,136,88,72,184,73,180,52,26,45,58,168,212,23,48,85,94,116,3,86,192,184,77,34,129,117,64,52,102,10,34,172,12,13,177,146,132,106,99,164,100,218,46,193,237,254,13,240,108,255,108,80,190,120,155,65,113,226,121,99,171,210,18,198,93,23,253,43,112,152,194,20,178,42,158,27,194,117,207,74,119,52,201,21,102,129,147,137,76,168,176,161,36,9,220,103,88,36,23,14,240,231,46,227,185,165,206,135,96,4,27,97,4,102,20,28,132,17,137,193,18,66,122,60,132,16,146,197,120,127,188,180,104,38,229,101,170,174,78,255,117,90,127,171,111,235,31,245,125,243,161,249,92,223,215,191,234,135,250,126,175,185,110,62,186,240,157,91,60,116,235,239,245,79,151,185,107,62,53,95,155,47,245,109,115,179,149,111,110,86,2,151,59,53,222,150,152,143,86,141,50,66,241,232,241,86,105,231,213,213,236,54,203,110,159,140,80,103,132,78,242,89,161,151,108,116,185,88,215,205,179,7,237,192,143,252,214,99,197,225,97,199,42,83,231,80,60,119,122,30,238,83,125,85,41,47,253,202,121,94,19,39,68,246,2,17,90,44,64,185,54,2,78,86,213,145,161,76,44,21,148,88,75,60,250,37,88,40,32,211,176,107,76,107,43,76,20,82,108,117,68,49,19,202,224,4,184,171,151,165,9,77,100,164,122,204,122,188,87,222,152,89,183,180,139,100,179,52,245,2,165,63,255,242,141,180,198,219,76,127,171,196,91,12,185,153,216,9,152,65,246,159,87,213,7,235,41,159,229,197,225,59,247,114,39,217,121,91,175,45,233,205,158,190,158,182,241,5,90,44,198,139,223,47,138,38,130,38,4,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "fea753aeb6dc408abac3b7d60bec1df8",
							"BaseElements.UpdateOpportunityStage.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("75b64d44-f646-4025-b2dc-16a7526ff5fd");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordColumnValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordColumnValues", getColumnValue);
					}
					return _recordColumnValues;
				}
				set {
					_recordColumnValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ShowEndOfStagePageFlowElement

		/// <exclude/>
		public class ShowEndOfStagePageFlowElement : PreconfiguredPageUserTask
		{

			#region Constructors: Public

			public ShowEndOfStagePageFlowElement(UserConnection userConnection, OpportunityManagementEndOfStage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ShowEndOfStagePage";
				IsLogging = true;
				SchemaElementUId = new Guid("d26c5f94-b96a-4031-8d1a-d32b0b0bd489");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_entityId = () => (Guid)((process.CurrentOpportunity));
				_currentStageId = () => (Guid)(((process.ReadOpportunity.ResultEntity.IsColumnValueLoaded(process.ReadOpportunity.ResultEntity.Schema.Columns.GetByName("Stage").ColumnValueName) ? process.ReadOpportunity.ResultEntity.GetTypedColumnValue<Guid>("StageId") : Guid.Empty)));
				_nextStageId = () => (Guid)((process.NextStage));
				_opportunityId = () => (Guid)((process.CurrentOpportunity));
				_isStageChangedByUser = () => (bool)((process.IsStageChangedByUser));
			}

			#endregion

			#region Properties: Public

			private Guid _clientUnitSchemaUId = new Guid("e1ba28db-8dae-4e66-869f-e505d74c589a");
			public override Guid ClientUnitSchemaUId {
				get {
					return _clientUnitSchemaUId;
				}
				set {
					_clientUnitSchemaUId = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("fea753aeb6dc408abac3b7d60bec1df8",
						 "BaseElements.ShowEndOfStagePage.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			internal Func<Guid> _entityId;
			public override Guid EntityId {
				get {
					return (_entityId ?? (_entityId = () => Guid.Empty)).Invoke();
				}
				set {
					_entityId = () => { return value; };
				}
			}

			private Guid _entitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private LocalizableString _title;
			public override LocalizableString Title {
				get {
					return _title ?? (_title = GetLocalizableString("fea753aeb6dc408abac3b7d60bec1df8",
						 "BaseElements.ShowEndOfStagePage.Parameters.Title.Value"));
				}
				set {
					_title = value;
				}
			}

			private bool _useCardProcessModule = true;
			public override bool UseCardProcessModule {
				get {
					return _useCardProcessModule;
				}
				set {
					_useCardProcessModule = value;
				}
			}

			public virtual string NextStageResult {
				get;
				set;
			}

			internal Func<Guid> _currentStageId;
			public virtual Guid CurrentStageId {
				get {
					return (_currentStageId ?? (_currentStageId = () => Guid.Empty)).Invoke();
				}
				set {
					_currentStageId = () => { return value; };
				}
			}

			internal Func<Guid> _nextStageId;
			public virtual Guid NextStageId {
				get {
					return (_nextStageId ?? (_nextStageId = () => Guid.Empty)).Invoke();
				}
				set {
					_nextStageId = () => { return value; };
				}
			}

			internal Func<Guid> _opportunityId;
			public virtual Guid OpportunityId {
				get {
					return (_opportunityId ?? (_opportunityId = () => Guid.Empty)).Invoke();
				}
				set {
					_opportunityId = () => { return value; };
				}
			}

			internal Func<bool> _isStageChangedByUser;
			public virtual bool IsStageChangedByUser {
				get {
					return (_isStageChangedByUser ?? (_isStageChangedByUser = () => false)).Invoke();
				}
				set {
					_isStageChangedByUser = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: ReadOpportunityFlowElement

		/// <exclude/>
		public class ReadOpportunityFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadOpportunityFlowElement(UserConnection userConnection, OpportunityManagementEndOfStage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadOpportunity";
				IsLogging = true;
				SchemaElementUId = new Guid("e18f5001-d887-417b-8123-79f8b4091406");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,187,142,212,48,20,253,21,228,130,42,70,113,226,36,118,40,71,3,154,102,89,137,5,33,237,142,86,142,125,189,99,41,143,217,216,17,187,138,70,66,162,162,226,31,248,130,41,128,130,2,126,33,243,71,56,201,12,72,91,32,10,26,36,23,246,181,207,185,231,28,93,247,215,198,62,51,165,131,54,215,162,180,16,116,43,149,35,205,40,149,113,164,112,33,34,129,105,36,1,51,202,24,230,180,128,84,49,153,136,34,67,65,45,42,200,209,140,94,42,227,80,96,28,84,54,191,236,127,147,186,182,131,224,90,79,135,151,114,3,149,120,53,54,16,64,83,93,176,12,203,48,146,152,10,96,88,168,152,96,193,163,88,42,197,57,149,26,29,181,16,146,128,230,4,19,22,134,152,82,82,96,206,82,141,21,87,192,57,240,36,36,128,130,18,180,91,222,109,91,176,214,52,117,222,195,175,253,197,253,214,171,156,123,47,154,178,171,106,20,84,224,196,185,112,155,81,72,8,52,145,2,75,202,19,76,53,100,88,196,92,225,216,59,140,50,6,36,37,222,169,20,91,55,210,162,149,66,129,18,78,188,22,101,7,19,115,111,188,198,40,14,9,75,82,143,37,177,183,19,71,33,102,169,119,167,85,170,57,196,41,231,133,58,229,245,188,51,126,111,236,89,87,65,107,228,49,118,240,249,53,109,222,203,166,118,109,83,142,212,103,211,243,11,184,115,115,184,199,171,55,179,33,231,235,35,8,237,130,206,194,162,52,80,187,101,45,27,101,234,155,153,115,183,243,144,106,43,90,99,79,41,44,111,59,81,162,160,53,55,155,63,166,181,232,172,107,170,255,200,106,224,109,122,14,63,100,147,220,113,6,149,177,219,82,220,79,231,28,61,190,237,26,247,116,248,52,124,25,190,29,222,31,62,12,251,195,199,71,195,143,195,187,225,251,240,121,216,15,95,135,253,252,4,61,160,202,209,21,82,90,66,70,10,63,255,41,85,152,202,144,227,66,37,12,135,146,103,154,196,105,194,105,114,133,188,188,127,217,244,114,101,95,188,173,79,191,102,246,185,126,226,171,15,10,231,39,100,222,255,141,206,221,122,84,186,222,249,245,19,174,198,111,137,252,3,0,0 })));
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

			private bool _readSomeTopRecords = false;
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
								new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"));
					}
					return _resultEntityCollection;
				}
				set {
					_resultEntityCollection = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ReadNextStageFlowElement

		/// <exclude/>
		public class ReadNextStageFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadNextStageFlowElement(UserConnection userConnection, OpportunityManagementEndOfStage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadNextStage";
				IsLogging = true;
				SchemaElementUId = new Guid("3c6cc565-dc1f-4c05-a0a0-bdf1ceeb7de4");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,106,220,48,20,253,149,160,69,87,86,177,45,141,101,187,203,97,10,217,164,129,62,40,36,67,208,227,106,70,224,199,196,150,105,131,25,72,219,85,41,180,95,80,250,11,165,36,144,244,145,111,144,255,168,154,113,167,45,89,148,110,186,40,8,115,117,165,123,206,185,71,215,253,137,105,239,155,194,66,147,107,94,180,16,116,251,42,71,50,77,100,2,132,99,70,35,130,169,84,26,167,138,74,28,201,84,198,90,167,60,139,25,10,42,94,66,142,198,234,153,50,22,5,198,66,217,230,71,253,47,80,219,116,16,156,232,237,230,161,92,66,201,31,111,9,164,102,42,245,216,90,166,158,128,113,133,5,36,17,78,53,17,68,100,41,159,80,141,70,45,58,100,113,150,77,40,142,121,168,49,165,153,196,25,100,20,3,208,148,137,73,146,50,29,162,160,0,109,103,207,87,13,180,173,169,171,188,135,159,241,163,179,149,87,57,114,79,235,162,43,43,20,148,96,249,33,183,203,28,77,164,214,145,34,12,203,144,100,152,38,18,48,151,196,127,168,98,92,128,103,155,120,33,146,175,236,6,22,185,15,238,102,56,31,222,185,11,247,217,221,184,79,195,27,119,189,231,190,249,240,171,187,28,206,81,160,184,229,79,120,209,193,150,182,55,190,129,68,36,130,81,136,113,26,135,10,211,44,244,232,97,196,112,44,24,241,166,74,29,139,112,103,230,126,101,97,1,141,119,178,61,232,74,104,140,28,29,4,111,111,221,228,189,172,43,219,212,197,6,252,224,247,130,209,254,31,167,79,199,150,205,120,180,41,69,235,160,107,97,90,24,168,236,172,146,181,50,213,98,124,239,245,218,87,149,43,222,152,118,103,213,236,180,227,5,10,26,179,88,254,209,210,105,215,218,186,252,15,91,14,124,187,30,201,79,228,86,246,102,96,149,105,87,5,63,219,238,115,116,231,180,171,237,61,247,126,247,172,123,195,11,247,197,93,186,139,225,213,240,118,120,237,163,107,159,26,94,186,143,126,14,174,220,213,120,31,221,194,205,209,49,82,140,209,84,3,224,40,86,145,31,222,48,198,25,215,4,71,140,17,146,8,65,133,32,199,200,107,253,103,10,142,246,219,7,207,170,221,207,55,58,48,191,235,179,183,18,135,187,202,188,255,27,209,235,249,70,246,124,237,215,119,84,51,51,197,67,4,0,0 })));
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

			private bool _readSomeTopRecords = false;
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,75,204,77,181,50,180,50,4,0,203,8,241,43,15,0,0,0 })));
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
								new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"));
					}
					return _resultEntityCollection;
				}
				set {
					_resultEntityCollection = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ReadCountNotFinishedActivitiesFlowElement

		/// <exclude/>
		public class ReadCountNotFinishedActivitiesFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadCountNotFinishedActivitiesFlowElement(UserConnection userConnection, OpportunityManagementEndOfStage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadCountNotFinishedActivities";
				IsLogging = true;
				SchemaElementUId = new Guid("868321fe-9c79-4ab3-8a81-b41ecb0e6d15");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,85,75,107,220,86,20,254,43,65,139,174,116,205,125,233,62,166,187,24,183,24,74,26,104,90,10,193,132,251,56,55,22,214,72,147,145,68,29,6,67,157,64,75,87,217,119,83,218,125,193,139,186,148,182,118,255,130,244,143,122,102,198,147,152,97,82,210,52,93,100,33,113,117,117,222,231,124,223,89,60,42,219,143,202,170,131,249,36,185,170,133,188,63,140,147,204,74,165,180,227,142,120,155,12,145,92,120,226,66,76,196,211,66,123,235,140,72,90,100,121,237,166,48,201,214,218,7,177,236,178,188,236,96,218,78,30,46,94,25,237,230,61,228,143,210,234,227,179,112,12,83,247,249,210,65,144,210,70,35,56,113,50,4,34,61,101,232,42,22,196,56,198,131,228,14,221,218,108,29,11,149,222,203,96,41,81,34,112,34,131,227,196,23,74,17,238,156,52,92,39,206,157,207,242,10,82,119,112,58,155,67,219,150,77,61,89,192,203,243,131,167,51,140,114,237,123,191,169,250,105,157,229,83,232,220,125,215,29,79,50,169,140,140,210,59,140,65,121,34,35,115,196,138,228,137,166,16,184,75,16,11,157,178,60,184,89,183,52,155,13,63,140,95,15,215,195,47,195,197,240,235,112,145,229,115,72,48,135,58,192,173,220,28,72,149,188,209,36,80,142,185,57,48,196,69,193,136,179,92,132,24,173,149,1,77,70,215,185,47,92,213,195,42,190,69,137,138,158,219,130,106,150,136,6,103,137,4,197,137,89,5,196,172,79,66,11,158,18,223,84,253,147,166,57,233,103,88,241,246,94,63,133,121,25,110,218,7,216,135,102,62,89,132,166,238,230,77,181,52,126,239,150,194,186,77,55,63,191,92,151,166,90,253,89,42,102,103,121,223,194,126,85,66,221,29,212,161,137,101,253,120,213,193,179,51,212,153,206,220,188,108,55,5,61,120,210,187,10,11,80,62,62,254,199,194,239,247,109,215,76,223,183,124,115,204,21,205,224,208,174,98,94,206,116,44,219,89,229,158,174,190,39,217,7,79,250,166,251,112,248,105,184,28,126,31,159,143,223,13,23,227,139,59,195,95,183,167,99,45,146,109,153,218,168,198,20,64,51,111,136,85,50,226,88,83,75,124,44,12,161,193,234,196,132,42,172,44,110,44,156,229,239,218,249,195,195,246,211,175,234,13,34,215,165,60,218,195,219,173,139,251,27,237,201,226,77,226,61,59,218,68,124,132,19,243,78,89,0,128,23,54,112,20,117,75,176,202,72,145,140,130,38,90,71,38,88,212,62,44,69,223,150,5,130,137,70,38,27,136,151,6,89,64,91,79,172,11,10,253,48,158,132,20,10,89,103,207,43,102,192,26,65,36,165,40,4,0,196,40,89,144,164,92,33,82,20,188,128,112,155,42,126,28,174,199,243,241,25,190,95,12,87,195,111,195,229,222,240,61,54,232,106,184,28,191,197,247,245,112,121,103,60,223,150,217,9,20,75,189,42,60,50,49,77,9,235,196,36,35,70,107,75,184,228,20,15,46,89,170,55,64,185,219,52,21,184,250,95,32,101,255,24,194,201,221,230,116,27,39,88,171,112,226,241,126,23,74,86,54,255,3,45,188,156,172,247,43,225,29,188,176,141,176,149,224,255,128,0,17,84,164,66,37,18,64,226,30,244,5,238,100,48,137,0,167,150,69,86,20,218,176,183,71,0,226,139,105,129,197,166,70,82,68,128,192,24,2,147,184,106,141,87,32,162,245,22,3,121,53,220,63,15,127,32,251,252,137,207,213,248,236,134,123,198,111,112,180,207,113,166,113,49,238,104,42,23,148,153,66,105,226,152,192,92,5,167,136,31,92,147,41,170,100,65,40,107,125,220,52,245,227,190,196,243,27,119,244,1,156,118,187,168,190,195,251,215,18,253,235,70,248,16,189,86,213,178,131,127,3,170,229,58,107,29,9,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private int _resultType = 1;
			public override int ResultType {
				get {
					return _resultType;
				}
				set {
					_resultType = value;
				}
			}

			private bool _readSomeTopRecords = false;
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

			private string _aggregationColumnName;
			public override string AggregationColumnName {
				get {
					return _aggregationColumnName ?? (_aggregationColumnName = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,1,0,242,67,189,42,2,0,0,0 })));
				}
				set {
					_aggregationColumnName = value;
				}
			}

			private string _orderInfo;
			public override string OrderInfo {
				get {
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,9,201,44,201,73,181,50,180,50,4,0,57,183,224,50,16,0,0,0 })));
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

			#endregion

		}

		#endregion

		public OpportunityManagementEndOfStage(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityManagementEndOfStage";
			SchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_currentStage = () => { return (Guid)(((ReadCurrentStage.ResultEntity.IsColumnValueLoaded(ReadCurrentStage.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? ReadCurrentStage.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty))); };
			_recommendation = () => { return new LocalizableString("Вы завершили все шаги по стадии \"" + ((ReadCurrentStage.ResultEntity.IsColumnValueLoaded(ReadCurrentStage.ResultEntity.Schema.Columns.GetByName("Name").ColumnValueName) ? ReadCurrentStage.ResultEntity.GetTypedColumnValue<string>("Name") : null)) + "\". Выберите дальнейшее действие:"); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: OpportunityManagementEndOfStage, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: OpportunityManagementEndOfStage, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid CurrentOpportunity {
			get;
			set;
		}

		public virtual int NextOpportunityStageNumber {
			get;
			set;
		}

		private Func<Guid> _currentStage;
		public virtual Guid CurrentStage {
			get {
				return (_currentStage ?? (_currentStage = () => Guid.Empty)).Invoke();
			}
			set {
				_currentStage = () => { return value; };
			}
		}

		private Func<LocalizableString> _recommendation;
		public virtual LocalizableString Recommendation {
			get {
				return (_recommendation ?? (_recommendation = () => null)).Invoke();
			}
			set {
				_recommendation = () => { return value; };
			}
		}

		public virtual bool IsStageChangedByUser {
			get;
			set;
		}

		public virtual bool DontShowPageEndOfStage {
			get;
			set;
		}

		public virtual Guid NextStage {
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
					SchemaElementUId = new Guid("f2f9628a-148c-457c-86a9-7f7baece560b"),
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
					SchemaElementUId = new Guid("2a12d765-1b7d-47e3-a00b-5c931dab802d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ReadCurrentStageFlowElement _readCurrentStage;
		public ReadCurrentStageFlowElement ReadCurrentStage {
			get {
				return _readCurrentStage ?? (_readCurrentStage = new ReadCurrentStageFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private UpdateOpportunityStageFlowElement _updateOpportunityStage;
		public UpdateOpportunityStageFlowElement UpdateOpportunityStage {
			get {
				return _updateOpportunityStage ?? (_updateOpportunityStage = new UpdateOpportunityStageFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ShowEndOfStagePageFlowElement _showEndOfStagePage;
		public ShowEndOfStagePageFlowElement ShowEndOfStagePage {
			get {
				return _showEndOfStagePage ?? (_showEndOfStagePage = new ShowEndOfStagePageFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadOpportunityFlowElement _readOpportunity;
		public ReadOpportunityFlowElement ReadOpportunity {
			get {
				return _readOpportunity ?? (_readOpportunity = new ReadOpportunityFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadNextStageFlowElement _readNextStage;
		public ReadNextStageFlowElement ReadNextStage {
			get {
				return _readNextStage ?? (_readNextStage = new ReadNextStageFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _setNextStageNumber;
		public ProcessScriptTask SetNextStageNumber {
			get {
				return _setNextStageNumber ?? (_setNextStageNumber = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SetNextStageNumber",
					SchemaElementUId = new Guid("2cc075ef-e2dc-4bbc-8186-706550bc8b21"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SetNextStageNumberExecute,
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
					SchemaElementUId = new Guid("3442dd87-3f5e-436c-9d5c-f6787c0fab8d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ReadCountNotFinishedActivitiesFlowElement _readCountNotFinishedActivities;
		public ReadCountNotFinishedActivitiesFlowElement ReadCountNotFinishedActivities {
			get {
				return _readCountNotFinishedActivities ?? (_readCountNotFinishedActivities = new ReadCountNotFinishedActivitiesFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _setShowEndOfStagePage;
		public ProcessScriptTask SetShowEndOfStagePage {
			get {
				return _setShowEndOfStagePage ?? (_setShowEndOfStagePage = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SetShowEndOfStagePage",
					SchemaElementUId = new Guid("4f941b7c-c6b4-4ad8-959c-b82b3f3767e5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SetShowEndOfStagePageExecute,
				});
			}
		}

		private ProcessScriptTask _setNextStageByProcess;
		public ProcessScriptTask SetNextStageByProcess {
			get {
				return _setNextStageByProcess ?? (_setNextStageByProcess = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SetNextStageByProcess",
					SchemaElementUId = new Guid("2b19d13a-f7cf-4d1c-b231-8775fd9b48d7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SetNextStageByProcessExecute,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway3;
		public ProcessExclusiveGateway ExclusiveGateway3 {
			get {
				return _exclusiveGateway3 ?? (_exclusiveGateway3 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway3",
					SchemaElementUId = new Guid("78c5c0a9-ea1b-4e76-b049-2da3afc80ec6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway3.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway4;
		public ProcessExclusiveGateway ExclusiveGateway4 {
			get {
				return _exclusiveGateway4 ?? (_exclusiveGateway4 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway4",
					SchemaElementUId = new Guid("ee1eb647-192e-47bf-9462-02ad7e99bd9e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway4.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _setNextStageByUser;
		public ProcessScriptTask SetNextStageByUser {
			get {
				return _setNextStageByUser ?? (_setNextStageByUser = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SetNextStageByUser",
					SchemaElementUId = new Guid("55b8d26d-8e5c-487a-81de-2f9292f3aa90"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SetNextStageByUserExecute,
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("61b4d6d8-8e40-41d0-97fb-42dc65fd11af"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow3;
		public ProcessConditionalFlow ConditionalFlow3 {
			get {
				return _conditionalFlow3 ?? (_conditionalFlow3 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow3",
					SchemaElementUId = new Guid("a7181db3-fab9-4d7c-8eee-d4d845df77f3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow2;
		public ProcessConditionalFlow ConditionalFlow2 {
			get {
				return _conditionalFlow2 ?? (_conditionalFlow2 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow2",
					SchemaElementUId = new Guid("d1371036-7604-4d06-bb84-ab1771858c58"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow5;
		public ProcessConditionalFlow ConditionalFlow5 {
			get {
				return _conditionalFlow5 ?? (_conditionalFlow5 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow5",
					SchemaElementUId = new Guid("3bdfa389-17e8-4004-86a8-c6c06af091ae"),
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
			FlowElements[ReadCurrentStage.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadCurrentStage };
			FlowElements[UpdateOpportunityStage.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateOpportunityStage };
			FlowElements[ShowEndOfStagePage.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowEndOfStagePage };
			FlowElements[ReadOpportunity.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadOpportunity };
			FlowElements[ReadNextStage.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadNextStage };
			FlowElements[SetNextStageNumber.SchemaElementUId] = new Collection<ProcessFlowElement> { SetNextStageNumber };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ReadCountNotFinishedActivities.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadCountNotFinishedActivities };
			FlowElements[SetShowEndOfStagePage.SchemaElementUId] = new Collection<ProcessFlowElement> { SetShowEndOfStagePage };
			FlowElements[SetNextStageByProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SetNextStageByProcess };
			FlowElements[ExclusiveGateway3.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway3 };
			FlowElements[ExclusiveGateway4.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway4 };
			FlowElements[SetNextStageByUser.SchemaElementUId] = new Collection<ProcessFlowElement> { SetNextStageByUser };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ReadCurrentStage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetNextStageNumber", e.Context.SenderName));
						break;
					case "UpdateOpportunityStage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ShowEndOfStagePage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("UpdateOpportunityStage", e.Context.SenderName));
						break;
					case "ReadOpportunity":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadCurrentStage", e.Context.SenderName));
						break;
					case "ReadNextStage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetNextStageByProcess", e.Context.SenderName));
						break;
					case "SetNextStageNumber":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway3", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadOpportunity", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadCountNotFinishedActivities", e.Context.SenderName));
						break;
					case "ReadCountNotFinishedActivities":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadOpportunity", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetShowEndOfStagePage", e.Context.SenderName));
						break;
					case "SetShowEndOfStagePage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadOpportunity", e.Context.SenderName));
						break;
					case "SetNextStageByProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowEndOfStagePage", e.Context.SenderName));
						break;
					case "ExclusiveGateway3":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway4", e.Context.SenderName));
						break;
					case "ExclusiveGateway4":
						if (ConditionalFlow5ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetNextStageByUser", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadNextStage", e.Context.SenderName));
						break;
					case "SetNextStageByUser":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowEndOfStagePage", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(!(IsStageChangedByUser));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow1", "!(IsStageChangedByUser)", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean((ReadCountNotFinishedActivities.ResultCount) > 0);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadCountNotFinishedActivities", "ConditionalFlow3", "(ReadCountNotFinishedActivities.ResultCount) > 0", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((DontShowPageEndOfStage));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway3", "ConditionalFlow2", "(DontShowPageEndOfStage)", result);
			return result;
		}

		private bool ConditionalFlow5ExpressionExecute() {
			bool result = Convert.ToBoolean((IsStageChangedByUser));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway4", "ConditionalFlow5", "(IsStageChangedByUser)", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("ShowEndOfStagePage.NextStageResult")) {
				writer.WriteValue("ShowEndOfStagePage.NextStageResult", ShowEndOfStagePage.NextStageResult, null);
			}
			if (!HasMapping("ShowEndOfStagePage.CurrentStageId")) {
				writer.WriteValue("ShowEndOfStagePage.CurrentStageId", ShowEndOfStagePage.CurrentStageId, Guid.Empty);
			}
			if (!HasMapping("ShowEndOfStagePage.NextStageId")) {
				writer.WriteValue("ShowEndOfStagePage.NextStageId", ShowEndOfStagePage.NextStageId, Guid.Empty);
			}
			if (!HasMapping("ShowEndOfStagePage.OpportunityId")) {
				writer.WriteValue("ShowEndOfStagePage.OpportunityId", ShowEndOfStagePage.OpportunityId, Guid.Empty);
			}
			if (!HasMapping("ShowEndOfStagePage.IsStageChangedByUser")) {
				writer.WriteValue("ShowEndOfStagePage.IsStageChangedByUser", ShowEndOfStagePage.IsStageChangedByUser, false);
			}
			if (!HasMapping("CurrentOpportunity")) {
				writer.WriteValue("CurrentOpportunity", CurrentOpportunity, Guid.Empty);
			}
			if (!HasMapping("NextOpportunityStageNumber")) {
				writer.WriteValue("NextOpportunityStageNumber", NextOpportunityStageNumber, 0);
			}
			if (!HasMapping("IsStageChangedByUser")) {
				writer.WriteValue("IsStageChangedByUser", IsStageChangedByUser, false);
			}
			if (!HasMapping("DontShowPageEndOfStage")) {
				writer.WriteValue("DontShowPageEndOfStage", DontShowPageEndOfStage, false);
			}
			if (!HasMapping("NextStage")) {
				writer.WriteValue("NextStage", NextStage, Guid.Empty);
			}
			if (!HasMapping("CurrentStage")) {
				writer.WriteValue("CurrentStage", CurrentStage, Guid.Empty);
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
			MetaPathParameterValues.Add("dfce71b8-964d-4c09-bd58-0c97f1365945", () => CurrentOpportunity);
			MetaPathParameterValues.Add("d7748fee-12d1-4402-9af3-177336bb4bb3", () => NextOpportunityStageNumber);
			MetaPathParameterValues.Add("7411fdec-830d-495b-8fcc-4494af5fe84c", () => CurrentStage);
			MetaPathParameterValues.Add("c26d6544-4636-434b-b986-690a58c482d2", () => Recommendation);
			MetaPathParameterValues.Add("2d124c72-8de2-4327-a821-7370bb4f3f04", () => IsStageChangedByUser);
			MetaPathParameterValues.Add("4a896c50-5660-4509-bcfa-09fdb87708e7", () => DontShowPageEndOfStage);
			MetaPathParameterValues.Add("b84b8659-7d6c-46df-be98-b96c5d0e5b85", () => NextStage);
			MetaPathParameterValues.Add("a180ecd0-2639-46fe-8f28-b1f4bf23afb2", () => ReadCurrentStage.DataSourceFilters);
			MetaPathParameterValues.Add("42e7b0d0-17c7-4dcc-a264-7be5a6a0e0b1", () => ReadCurrentStage.ResultType);
			MetaPathParameterValues.Add("1ee60d4e-4844-4702-9e5b-a9ef2faca871", () => ReadCurrentStage.ReadSomeTopRecords);
			MetaPathParameterValues.Add("f8cf2516-53d6-45f6-ba8d-4bfdabb48124", () => ReadCurrentStage.NumberOfRecords);
			MetaPathParameterValues.Add("b9fa8b3c-2f06-4b34-bbef-4f29b1947858", () => ReadCurrentStage.FunctionType);
			MetaPathParameterValues.Add("a9ce46aa-34eb-48fb-be04-e9c34eceff5f", () => ReadCurrentStage.AggregationColumnName);
			MetaPathParameterValues.Add("5061fcf5-7f96-49fa-8be4-619e0f5209ae", () => ReadCurrentStage.OrderInfo);
			MetaPathParameterValues.Add("e11d0fd9-aca0-4ee9-b9cf-f8d97c1fc2ba", () => ReadCurrentStage.ResultEntity);
			MetaPathParameterValues.Add("bbaa560d-a45c-4f10-ac9f-e0a221e816e8", () => ReadCurrentStage.ResultCount);
			MetaPathParameterValues.Add("c64386d0-db34-457e-833d-a14939236608", () => ReadCurrentStage.ResultIntegerFunction);
			MetaPathParameterValues.Add("e5dde80e-3396-4686-a165-fafbfad811d2", () => ReadCurrentStage.ResultFloatFunction);
			MetaPathParameterValues.Add("c161dd2c-4540-45be-9271-b9b410ff5929", () => ReadCurrentStage.ResultDateTimeFunction);
			MetaPathParameterValues.Add("1ca50f2d-35c9-435b-85de-6154c601ed28", () => ReadCurrentStage.ResultRowsCount);
			MetaPathParameterValues.Add("30c203aa-798c-414b-b6e2-e7435cabddcd", () => ReadCurrentStage.CanReadUncommitedData);
			MetaPathParameterValues.Add("18002008-4ddc-4cdc-9996-18caf8454929", () => ReadCurrentStage.ResultEntityCollection);
			MetaPathParameterValues.Add("7d1b816f-c970-49b1-bfdb-4212142710ce", () => ReadCurrentStage.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("e979c3ad-ef25-4300-b738-0666bbd3e28a", () => ReadCurrentStage.IgnoreDisplayValues);
			MetaPathParameterValues.Add("18801700-5425-4afa-8a8a-87a4499f280f", () => ReadCurrentStage.ResultCompositeObjectList);
			MetaPathParameterValues.Add("8fd411c2-fbf5-4ed0-a07e-e3a6a9c630a1", () => ReadCurrentStage.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("e99fa34f-868e-4b57-a3a8-13c100885498", () => UpdateOpportunityStage.EntitySchemaUId);
			MetaPathParameterValues.Add("05fb8dfb-1204-478c-a016-5e0dacf67068", () => UpdateOpportunityStage.IsMatchConditions);
			MetaPathParameterValues.Add("cc2f766d-1506-48eb-8d63-91ddc235a521", () => UpdateOpportunityStage.DataSourceFilters);
			MetaPathParameterValues.Add("0b1a99dc-d621-4151-8384-3e221142a390", () => UpdateOpportunityStage.RecordColumnValues);
			MetaPathParameterValues.Add("8fba1047-ae93-410a-a843-da9895119d14", () => UpdateOpportunityStage.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("3fc920dd-5c62-4946-a873-1c00873e193a", () => ShowEndOfStagePage.ClientUnitSchemaUId);
			MetaPathParameterValues.Add("95bf65a8-5bdc-4b02-b95a-1f12ff622cbd", () => ShowEndOfStagePage.Recommendation);
			MetaPathParameterValues.Add("29a26301-669f-494a-8967-ef76ebcb346b", () => ShowEndOfStagePage.EntityId);
			MetaPathParameterValues.Add("f14e9164-cb48-4c4d-9eda-2a426442f1fd", () => ShowEndOfStagePage.EntryPointId);
			MetaPathParameterValues.Add("63792a62-2e22-48b7-8c75-26ed007ef6a2", () => ShowEndOfStagePage.EntitySchemaUId);
			MetaPathParameterValues.Add("a9895f5a-79bc-4b95-be4c-0b420f907431", () => ShowEndOfStagePage.Title);
			MetaPathParameterValues.Add("17508aa3-5868-4feb-acab-c83ec5a89cff", () => ShowEndOfStagePage.UseCardProcessModule);
			MetaPathParameterValues.Add("37dae5df-0de8-4721-b69a-620d86c5a9c6", () => ShowEndOfStagePage.OwnerId);
			MetaPathParameterValues.Add("4ecc7287-ee70-49bd-b052-12d9c04640cc", () => ShowEndOfStagePage.ShowExecutionPage);
			MetaPathParameterValues.Add("81c142cf-f5e8-4758-b878-a1157cb21f63", () => ShowEndOfStagePage.InformationOnStep);
			MetaPathParameterValues.Add("1f3d14a9-bcd1-4c8e-a749-366397869b93", () => ShowEndOfStagePage.IsRunning);
			MetaPathParameterValues.Add("d9172536-2edb-4e0a-8746-c1e0cc5f4372", () => ShowEndOfStagePage.Template);
			MetaPathParameterValues.Add("517a7110-5a34-4df7-82d8-d5dc907e9672", () => ShowEndOfStagePage.Module);
			MetaPathParameterValues.Add("a14f806a-3e1e-4e54-bb85-35b9fa16cb46", () => ShowEndOfStagePage.PressedButtonCode);
			MetaPathParameterValues.Add("87c4ce9c-dc60-48b9-829f-2413eccb33a5", () => ShowEndOfStagePage.Url);
			MetaPathParameterValues.Add("ff39510a-5dba-415c-ac1f-d1a574335f9d", () => ShowEndOfStagePage.CurrentActivityId);
			MetaPathParameterValues.Add("f4e19f90-eeee-4fa4-a962-1ac9c5d13239", () => ShowEndOfStagePage.CreateActivity);
			MetaPathParameterValues.Add("50c1dbf6-4a8a-4780-8b54-f3800758bf98", () => ShowEndOfStagePage.ActivityPriority);
			MetaPathParameterValues.Add("e931b39e-499f-427a-8132-41dc73371b59", () => ShowEndOfStagePage.StartIn);
			MetaPathParameterValues.Add("25dee447-fd15-4f67-b915-1792256a14e8", () => ShowEndOfStagePage.StartInPeriod);
			MetaPathParameterValues.Add("f2884f23-6703-46ee-a2cd-2d78c0c2b128", () => ShowEndOfStagePage.Duration);
			MetaPathParameterValues.Add("3aebb227-f5ea-4f1c-8d10-a95417dbe719", () => ShowEndOfStagePage.DurationPeriod);
			MetaPathParameterValues.Add("42bdb602-b83d-43d8-842d-440077c90388", () => ShowEndOfStagePage.ShowInScheduler);
			MetaPathParameterValues.Add("4dac1b12-153a-42be-902d-fedcd1d759ed", () => ShowEndOfStagePage.RemindBefore);
			MetaPathParameterValues.Add("6ffa6e10-a7e1-43b9-bb48-f7c62916ec47", () => ShowEndOfStagePage.RemindBeforePeriod);
			MetaPathParameterValues.Add("1bd8bcc2-2d82-447c-b71e-1d0771c9d792", () => ShowEndOfStagePage.ActivityResult);
			MetaPathParameterValues.Add("5fba8a1d-f1e7-4d1c-b41d-83662181e6e2", () => ShowEndOfStagePage.IsActivityCompleted);
			MetaPathParameterValues.Add("7584122f-a24d-4575-a5b9-b55b2a9abc8a", () => ShowEndOfStagePage.NextStageResult);
			MetaPathParameterValues.Add("8de5380d-ac3d-411c-8a77-2c835c3d43d4", () => ShowEndOfStagePage.CurrentStageId);
			MetaPathParameterValues.Add("f3923742-d7d7-43e1-8429-ef222561e1eb", () => ShowEndOfStagePage.NextStageId);
			MetaPathParameterValues.Add("7b3decd5-3d89-4cff-b95d-730a6013cb27", () => ShowEndOfStagePage.OpportunityId);
			MetaPathParameterValues.Add("61077983-3941-4d4a-9630-edfbacf49a87", () => ShowEndOfStagePage.IsStageChangedByUser);
			MetaPathParameterValues.Add("4e5d457b-42b9-4672-8b52-c52e77513010", () => ReadOpportunity.DataSourceFilters);
			MetaPathParameterValues.Add("8447c567-6c37-4e2b-a3dd-2447daaaaf66", () => ReadOpportunity.ResultType);
			MetaPathParameterValues.Add("0e8e3ca1-4e02-4cfd-9534-dfc91c400628", () => ReadOpportunity.ReadSomeTopRecords);
			MetaPathParameterValues.Add("7f19d59d-6e3e-4583-9422-7df884633ba7", () => ReadOpportunity.NumberOfRecords);
			MetaPathParameterValues.Add("fbccc177-264d-4b7a-81b0-a23219940711", () => ReadOpportunity.FunctionType);
			MetaPathParameterValues.Add("d4181cb4-8130-424d-ae68-c843f87a8855", () => ReadOpportunity.AggregationColumnName);
			MetaPathParameterValues.Add("50b25f81-e993-4f01-a6e6-374b3659b858", () => ReadOpportunity.OrderInfo);
			MetaPathParameterValues.Add("be61dc40-5e32-4d0b-9d27-1e361e54f22b", () => ReadOpportunity.ResultEntity);
			MetaPathParameterValues.Add("06755d62-3109-44a6-a9ab-3f4754d27ca3", () => ReadOpportunity.ResultCount);
			MetaPathParameterValues.Add("daf5e600-722b-43e1-a28d-5cefd2a1ba80", () => ReadOpportunity.ResultIntegerFunction);
			MetaPathParameterValues.Add("f1cb258f-287d-4c5c-b4ac-277f0f9884bb", () => ReadOpportunity.ResultFloatFunction);
			MetaPathParameterValues.Add("797c93d6-bc60-4d21-a669-039897df02c3", () => ReadOpportunity.ResultDateTimeFunction);
			MetaPathParameterValues.Add("0f2ed61f-3f3e-487a-8430-3fb6764f469d", () => ReadOpportunity.ResultRowsCount);
			MetaPathParameterValues.Add("4e8bf658-f625-4d19-ad5b-727fb3b2847e", () => ReadOpportunity.CanReadUncommitedData);
			MetaPathParameterValues.Add("3d15909c-f006-4a7a-8b1c-fede8e2a9eae", () => ReadOpportunity.ResultEntityCollection);
			MetaPathParameterValues.Add("86e11392-27d0-4340-9d60-c67a8335b463", () => ReadOpportunity.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("4b80d1c9-90f8-4449-82d6-693bf426b73b", () => ReadOpportunity.IgnoreDisplayValues);
			MetaPathParameterValues.Add("dd921855-88e1-45b5-a243-fcafcf724ef7", () => ReadOpportunity.ResultCompositeObjectList);
			MetaPathParameterValues.Add("b7b63732-4013-4ac2-ae59-c3d73f0c2d6d", () => ReadOpportunity.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("a75219e0-00f3-4d5d-a9f7-651b6e4376ef", () => ReadNextStage.DataSourceFilters);
			MetaPathParameterValues.Add("b64d0a3c-c0d0-4958-81f1-b5ede9765ad4", () => ReadNextStage.ResultType);
			MetaPathParameterValues.Add("24325d83-50e7-4573-8f91-35e07a45c717", () => ReadNextStage.ReadSomeTopRecords);
			MetaPathParameterValues.Add("f3903c6b-98c5-40bf-916d-98a7b572a579", () => ReadNextStage.NumberOfRecords);
			MetaPathParameterValues.Add("a0182d1d-381b-4c10-a8ec-d985836d5cc9", () => ReadNextStage.FunctionType);
			MetaPathParameterValues.Add("85950cf7-252d-4b5c-9bfd-ad509d940e2f", () => ReadNextStage.AggregationColumnName);
			MetaPathParameterValues.Add("81c297c2-fc42-4e9b-89ee-73751508db6a", () => ReadNextStage.OrderInfo);
			MetaPathParameterValues.Add("92ea37fd-45c4-4fb2-98b7-eb6e66edd5ff", () => ReadNextStage.ResultEntity);
			MetaPathParameterValues.Add("7ab26365-d3e5-4729-92b4-d09e2de024d0", () => ReadNextStage.ResultCount);
			MetaPathParameterValues.Add("95f97244-d092-4885-aea6-53b76e1303a7", () => ReadNextStage.ResultIntegerFunction);
			MetaPathParameterValues.Add("2cc4d02b-1588-44de-9fa7-b09506a2c14f", () => ReadNextStage.ResultFloatFunction);
			MetaPathParameterValues.Add("1cb876d9-d17b-4fc0-a745-da0b4ea53266", () => ReadNextStage.ResultDateTimeFunction);
			MetaPathParameterValues.Add("4201c6a3-e0ab-4f41-b531-0fb631720790", () => ReadNextStage.ResultRowsCount);
			MetaPathParameterValues.Add("96bc11af-2c34-4987-a0f6-2575203da254", () => ReadNextStage.CanReadUncommitedData);
			MetaPathParameterValues.Add("92ba46a0-d926-4f32-868c-882c9bef0c1b", () => ReadNextStage.ResultEntityCollection);
			MetaPathParameterValues.Add("3df688c3-a044-4e2f-b4d5-974b22314e82", () => ReadNextStage.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("e3d4eab8-cdc4-425a-be85-68f08022c240", () => ReadNextStage.IgnoreDisplayValues);
			MetaPathParameterValues.Add("8d2f8884-011d-4524-ac6d-614dedac86a0", () => ReadNextStage.ResultCompositeObjectList);
			MetaPathParameterValues.Add("a222d31f-5ecb-4b6e-9561-198ae0448311", () => ReadNextStage.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("6a1d2bd1-de4f-40aa-9125-c113b2d391c5", () => ReadCountNotFinishedActivities.DataSourceFilters);
			MetaPathParameterValues.Add("0959d33a-0a66-4437-b25b-f3bda29e8610", () => ReadCountNotFinishedActivities.ResultType);
			MetaPathParameterValues.Add("bb79a7c9-22cc-4cfa-8454-2c336d3bbfa5", () => ReadCountNotFinishedActivities.ReadSomeTopRecords);
			MetaPathParameterValues.Add("24dd4a10-4e2c-4dbc-ac53-610bca6745d2", () => ReadCountNotFinishedActivities.NumberOfRecords);
			MetaPathParameterValues.Add("fc43106b-6ad4-40bf-a590-bdcc5c40964f", () => ReadCountNotFinishedActivities.FunctionType);
			MetaPathParameterValues.Add("0d8bea86-be3d-47ce-be07-e371b62fc691", () => ReadCountNotFinishedActivities.AggregationColumnName);
			MetaPathParameterValues.Add("37082b06-1012-4b4d-a2ad-042c8195bd8d", () => ReadCountNotFinishedActivities.OrderInfo);
			MetaPathParameterValues.Add("1fd1d50c-01de-4e1b-90a2-28e34e2af4be", () => ReadCountNotFinishedActivities.ResultEntity);
			MetaPathParameterValues.Add("adb67efb-8644-4a2e-a47b-ead879586020", () => ReadCountNotFinishedActivities.ResultCount);
			MetaPathParameterValues.Add("b4741ed6-a5d9-425f-89cb-d88bb25d9d90", () => ReadCountNotFinishedActivities.ResultIntegerFunction);
			MetaPathParameterValues.Add("2708fded-c17f-4033-9321-837e75a17968", () => ReadCountNotFinishedActivities.ResultFloatFunction);
			MetaPathParameterValues.Add("86a273c0-dc2f-4650-9c6c-5b7ffee3cd43", () => ReadCountNotFinishedActivities.ResultDateTimeFunction);
			MetaPathParameterValues.Add("cbd49361-8bca-4903-b561-a67607267747", () => ReadCountNotFinishedActivities.ResultRowsCount);
			MetaPathParameterValues.Add("ce29d90c-dbf6-45ef-b05c-543edaf33473", () => ReadCountNotFinishedActivities.CanReadUncommitedData);
			MetaPathParameterValues.Add("59ffe7bc-8788-4279-be21-1c5a28993330", () => ReadCountNotFinishedActivities.ResultEntityCollection);
			MetaPathParameterValues.Add("f2b89827-46fd-4c18-b956-876018f44ca1", () => ReadCountNotFinishedActivities.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("c76447c0-1087-47a0-b5f1-4dbe3d1a44b8", () => ReadCountNotFinishedActivities.IgnoreDisplayValues);
			MetaPathParameterValues.Add("68448e85-b99c-40e3-8923-f71f373a760d", () => ReadCountNotFinishedActivities.ResultCompositeObjectList);
			MetaPathParameterValues.Add("fc431747-d3f1-46b1-8204-6f7506150101", () => ReadCountNotFinishedActivities.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "ShowEndOfStagePage.NextStageResult":
					ShowEndOfStagePage.NextStageResult = reader.GetValue<System.String>();
				break;
				case "ShowEndOfStagePage.CurrentStageId":
					ShowEndOfStagePage.CurrentStageId = reader.GetValue<System.Guid>();
				break;
				case "ShowEndOfStagePage.NextStageId":
					ShowEndOfStagePage.NextStageId = reader.GetValue<System.Guid>();
				break;
				case "ShowEndOfStagePage.OpportunityId":
					ShowEndOfStagePage.OpportunityId = reader.GetValue<System.Guid>();
				break;
				case "ShowEndOfStagePage.IsStageChangedByUser":
					ShowEndOfStagePage.IsStageChangedByUser = reader.GetValue<System.Boolean>();
				break;
				case "CurrentOpportunity":
					if (!hasValueToRead) break;
					CurrentOpportunity = reader.GetValue<System.Guid>();
				break;
				case "NextOpportunityStageNumber":
					if (!hasValueToRead) break;
					NextOpportunityStageNumber = reader.GetValue<System.Int32>();
				break;
				case "IsStageChangedByUser":
					if (!hasValueToRead) break;
					IsStageChangedByUser = reader.GetValue<System.Boolean>();
				break;
				case "DontShowPageEndOfStage":
					if (!hasValueToRead) break;
					DontShowPageEndOfStage = reader.GetValue<System.Boolean>();
				break;
				case "NextStage":
					if (!hasValueToRead) break;
					NextStage = reader.GetValue<System.Guid>();
				break;
				case "CurrentStage":
					if (!hasValueToRead) break;
					CurrentStage = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SetNextStageNumberExecute(ProcessExecutingContext context) {
			var localNextOpportunityStageNumber = ((ReadCurrentStage.ResultEntity.IsColumnValueLoaded(ReadCurrentStage.ResultEntity.Schema.Columns.GetByName("Number").ColumnValueName) ? ReadCurrentStage.ResultEntity.GetTypedColumnValue<int>("Number") : 0)) + 1;
			NextOpportunityStageNumber = (System.Int32)localNextOpportunityStageNumber;
			return true;
		}

		public virtual bool SetShowEndOfStagePageExecute(ProcessExecutingContext context) {
			var localDontShowPageEndOfStage = true;
			DontShowPageEndOfStage = (System.Boolean)localDontShowPageEndOfStage;
			return true;
		}

		public virtual bool SetNextStageByProcessExecute(ProcessExecutingContext context) {
			var localNextStage = ((ReadNextStage.ResultEntity.IsColumnValueLoaded(ReadNextStage.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? ReadNextStage.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty));
			NextStage = (System.Guid)localNextStage;
			return true;
		}

		public virtual bool SetNextStageByUserExecute(ProcessExecutingContext context) {
			var localNextStage = ((ReadOpportunity.ResultEntity.IsColumnValueLoaded(ReadOpportunity.ResultEntity.Schema.Columns.GetByName("Stage").ColumnValueName) ? ReadOpportunity.ResultEntity.GetTypedColumnValue<Guid>("StageId") : Guid.Empty));
			NextStage = (System.Guid)localNextStage;
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
			var cloneItem = (OpportunityManagementEndOfStage)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

