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

	#region Class: OpportunityManagementContractionSchema

	/// <exclude/>
	public class OpportunityManagementContractionSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public OpportunityManagementContractionSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public OpportunityManagementContractionSchema(OpportunityManagementContractionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "OpportunityManagementContraction";
			UId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368");
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
			RealUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368");
			Version = 0;
			PackageUId = new Guid("75b64d44-f646-4025-b2dc-16a7526ff5fd");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCurrentOpportunityParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e445615d-e4cb-4008-8fb6-06ac646c9b1d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateOpportunityStageChangedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("88df6c2c-946a-477d-873f-71f366a99486"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"OpportunityStageChanged",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMainContactParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("04523d12-f6b8-419e-bccb-f9be9dd26362"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"MainContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCurrentOpportunityParameter());
			Parameters.Add(CreateOpportunityStageChangedParameter());
			Parameters.Add(CreateMainContactParameter());
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8f4a4849-9493-4e2f-844b-f698457ce514"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,205,110,212,48,16,126,21,228,3,167,24,37,177,227,196,225,184,90,208,94,74,37,10,66,106,87,213,196,30,119,45,229,103,155,56,162,213,106,37,36,78,156,120,7,158,96,15,192,129,3,125,133,236,27,213,217,116,65,234,1,113,224,130,228,195,120,236,249,230,251,62,123,54,151,182,123,97,75,135,109,110,160,236,48,232,23,58,39,130,165,160,140,68,138,200,11,202,51,76,40,68,192,104,161,4,215,133,129,2,84,68,130,26,42,204,201,84,61,215,214,145,192,58,172,186,252,124,243,27,212,181,61,6,151,230,176,121,173,86,88,193,155,177,1,32,23,166,200,82,170,194,88,81,14,152,81,208,44,162,32,99,166,180,150,146,43,67,38,46,153,20,9,231,5,167,82,152,152,114,33,193,71,200,168,82,137,81,81,152,37,152,32,9,74,52,110,126,179,110,177,235,108,83,231,27,252,21,159,221,174,61,203,169,247,172,41,251,170,38,65,133,14,78,193,173,70,34,33,242,68,1,85,92,38,148,27,76,41,48,169,41,131,34,141,211,12,35,17,165,36,80,176,118,35,44,89,104,18,104,112,240,22,202,30,15,200,27,235,57,198,44,140,178,68,248,218,136,121,57,44,14,105,38,188,58,163,133,119,145,9,41,11,125,244,235,101,111,125,108,187,147,190,194,214,170,7,219,209,251,215,180,249,70,53,181,107,155,114,132,62,57,92,63,195,27,55,153,251,112,244,110,18,228,124,126,44,34,219,160,239,112,86,90,172,221,188,86,141,182,245,213,132,185,221,250,146,106,13,173,237,142,46,204,175,123,40,73,208,218,171,213,31,221,154,245,157,107,170,255,72,106,224,101,122,12,255,201,14,116,199,63,168,109,183,46,225,246,176,207,201,211,235,190,113,207,135,47,195,183,225,199,254,227,254,211,176,219,127,126,50,220,237,63,12,63,135,175,195,110,248,62,236,166,43,228,17,84,78,46,8,114,158,136,40,209,20,185,242,227,16,134,25,205,76,33,104,40,192,15,132,80,178,136,244,5,241,244,254,101,211,243,69,247,234,125,125,156,154,73,231,242,153,207,62,74,156,30,43,253,51,254,5,207,237,114,100,186,220,250,117,15,39,11,81,177,252,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4014b7ef-16bc-41f6-baec-19b9013b9312"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d9ea8a7b-f3e9-4a1c-9fa7-f078e98333ab"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("09a1a83a-4492-4a83-993e-89a263175d60"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("82737ed0-7a4a-4ff4-b059-09969ea18610"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("00ab2ba3-17dc-4f80-a2cc-50070e128af8"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				UId = new Guid("4be420fc-337b-4a67-8a6a-c0dc63c803ec"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("a2eb3b4d-89b3-47e3-a71a-a9af9ea02d43"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("464cbe2d-ad13-45fd-bcc6-a63ee98115aa"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				UId = new Guid("b48ad8a6-545a-4455-9d3b-a4bc35df4b84"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				UId = new Guid("576b1762-a496-48e8-a0c3-5bd2ea4c034e"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				UId = new Guid("4036bfc1-f28a-4f25-99be-08627493ff79"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				UId = new Guid("dfd83cce-3024-4965-aac6-90a11b2e6275"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				UId = new Guid("28d0c589-93d1-47c4-b7fc-3705103f3f56"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				UId = new Guid("9dd070fb-a444-4291-8d1e-fc32a3224fa2"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4c195665-6057-45a6-9822-86ed12a63c71"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("926a2ee8-0613-4c64-9cf2-88585d5fa80b"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				UId = new Guid("cf09060e-14f6-4096-a383-9bb90ee12518"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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
				UId = new Guid("b01fa112-d77f-4a5f-ab30-eb91374ac7ae"),
				ContainerUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
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

		protected virtual void InitializeChangeDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("c3cf9431-8846-41fc-9850-72403c00e796"),
				ContainerUId = new Guid("3ddbcc19-3b7e-4bf6-9e07-fd4451c8f862"),
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
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b0a44d9c-4f65-4362-8cff-3075bdcb5c5f"),
				ContainerUId = new Guid("3ddbcc19-3b7e-4bf6-9e07-fd4451c8f862"),
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
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4394db70-02ff-403b-91c8-91898e517092"),
				ContainerUId = new Guid("3ddbcc19-3b7e-4bf6-9e07-fd4451c8f862"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,110,212,48,20,253,21,228,5,171,24,197,137,227,56,97,57,26,208,108,74,37,10,66,106,71,149,99,95,119,44,229,213,216,17,173,70,145,144,88,177,226,31,248,130,89,0,11,22,244,23,50,127,84,103,210,1,169,11,196,130,13,146,23,246,205,61,231,158,115,98,111,47,141,125,97,74,7,93,174,69,105,33,232,87,42,71,44,4,161,66,66,49,101,137,196,52,38,9,46,18,46,177,12,169,84,180,72,89,90,0,10,106,81,65,142,102,244,82,25,135,2,227,160,178,249,249,246,55,169,235,122,8,46,245,225,240,90,110,160,18,111,166,1,2,40,211,5,79,61,99,228,7,8,224,88,168,152,96,145,69,177,84,42,203,168,212,104,214,146,105,46,53,72,192,74,71,10,83,202,125,23,165,49,142,164,214,132,130,38,41,79,81,80,130,118,203,155,182,3,107,77,83,231,91,248,181,63,187,109,189,202,121,246,162,41,251,170,70,65,5,78,156,10,183,153,132,132,64,19,41,176,164,89,130,169,134,20,139,56,83,56,22,69,26,165,28,8,35,158,93,138,214,77,180,104,165,80,160,132,19,111,69,217,195,129,121,107,188,198,40,14,9,79,152,199,146,120,202,43,10,49,103,222,157,86,76,103,16,179,44,43,212,49,175,151,189,241,123,99,79,250,10,58,35,31,98,7,159,95,211,229,91,217,212,174,107,202,137,250,228,208,126,6,55,110,14,247,225,211,187,217,144,243,245,9,132,134,160,183,176,40,13,212,110,89,203,70,153,250,106,230,28,6,15,169,90,209,25,123,76,97,121,221,139,18,5,157,185,218,252,49,173,69,111,93,83,253,71,86,3,111,211,115,248,75,118,144,59,221,65,101,108,91,138,219,195,57,71,79,175,251,198,61,31,191,140,223,198,31,251,143,251,79,227,110,255,249,201,120,183,255,48,254,28,191,142,187,241,251,184,155,91,208,35,170,28,93,32,160,52,97,36,81,24,168,44,48,13,67,142,185,46,24,14,153,144,140,50,153,21,68,93,32,47,239,95,14,61,95,217,87,239,235,227,171,153,125,174,159,249,234,163,194,233,17,233,127,227,95,232,28,214,147,210,245,224,215,61,146,170,218,97,252,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e242e8eb-83ae-4cd6-a738-bda900c3da33"),
				ContainerUId = new Guid("3ddbcc19-3b7e-4bf6-9e07-fd4451c8f862"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,19,49,16,253,43,209,182,199,120,101,175,247,203,61,210,130,84,169,69,21,133,94,8,135,177,61,134,136,36,27,109,54,136,82,69,106,203,1,16,7,142,156,225,23,148,170,129,80,65,249,11,222,127,132,215,77,213,84,32,168,144,184,128,15,177,60,158,55,111,226,121,111,247,130,229,106,119,136,193,74,112,99,107,115,187,48,85,184,90,148,24,110,149,133,194,209,40,220,40,20,244,186,207,64,246,112,11,74,232,99,133,229,14,244,198,56,218,232,142,170,118,107,17,20,180,131,229,39,254,46,88,185,191,23,172,87,216,191,183,174,93,229,8,32,161,17,74,146,65,12,36,206,16,73,158,2,37,185,204,56,85,90,73,22,197,14,172,138,222,184,63,216,196,10,182,160,122,20,172,236,5,190,154,43,144,137,12,20,79,34,18,139,76,144,88,71,57,17,52,53,36,143,12,202,84,75,37,180,10,38,237,96,164,30,97,31,60,233,37,24,48,78,141,204,51,162,104,164,72,12,152,19,208,156,17,16,17,87,90,11,17,43,211,128,231,249,151,192,251,75,27,69,241,120,60,12,149,50,153,206,25,39,70,229,220,245,15,154,72,76,25,201,13,151,92,138,28,146,216,132,41,213,9,103,84,145,196,221,17,109,24,35,34,99,146,80,202,116,74,81,240,92,165,75,15,26,34,221,29,13,123,176,187,243,35,159,125,103,191,213,251,246,200,30,219,179,250,133,253,106,103,246,52,180,239,234,67,23,58,177,179,250,77,203,223,159,185,195,145,253,104,103,161,125,235,147,167,245,126,253,210,78,29,224,168,85,31,184,36,151,242,193,157,79,220,254,249,156,116,120,101,122,139,180,123,157,115,9,116,130,149,206,207,69,48,223,183,253,235,94,149,193,85,5,116,130,118,39,216,46,198,165,106,170,241,230,112,49,17,95,157,206,151,123,148,31,126,46,214,121,13,15,219,132,1,60,196,242,182,227,243,112,127,181,6,21,120,234,187,174,231,139,194,50,18,9,205,152,33,25,130,19,8,166,17,201,53,3,34,152,144,134,103,60,50,38,242,232,59,104,176,196,129,194,171,141,93,103,194,30,239,153,47,155,185,16,171,139,12,198,189,158,39,24,249,255,223,168,127,222,248,252,102,109,97,236,11,21,10,221,53,93,212,235,131,63,124,170,53,52,190,228,173,162,188,249,212,121,178,59,120,56,159,215,2,245,101,206,154,234,207,227,147,96,50,105,47,218,84,1,7,42,83,73,100,146,196,206,40,92,16,96,66,19,20,40,57,101,146,195,111,108,170,114,147,232,84,103,4,64,184,41,184,153,56,167,33,37,177,49,41,230,49,77,147,196,252,13,155,110,239,142,118,160,236,54,31,169,112,117,92,186,249,86,78,37,120,183,219,199,107,56,110,86,31,56,131,77,237,151,198,62,222,98,141,159,124,160,113,148,15,134,246,189,59,156,214,207,235,87,110,159,182,236,39,31,127,225,51,102,77,192,57,178,62,172,95,183,236,172,101,143,23,224,179,255,193,126,58,98,78,36,38,118,179,75,157,114,40,139,136,140,242,148,24,96,144,179,140,105,136,227,95,217,143,206,215,111,27,251,199,236,247,96,242,29,115,8,130,15,127,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5deaf690-2ceb-468b-b89a-9138b0ba6813"),
				ContainerUId = new Guid("3ddbcc19-3b7e-4bf6-9e07-fd4451c8f862"),
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

		protected virtual void InitializeActivityUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6ca9f9fb-b8f2-4faf-ad43-f958521c933d"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Собрать информацию для подготовки договора",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("67e0db65-e87b-4e3d-904f-5df238c24945"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ActivityCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityCategoryParameter.SourceValue = new ProcessSchemaParameterValue(activityCategoryParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"f51c4643-58e6-df11-971b-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("354f4d1d-8b87-4501-9d1c-927e640cbb78"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"OwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			ownerIdParameter.SourceValue = new ProcessSchemaParameterValue(ownerIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c511c956-3b86-4674-9f55-6b17f7dcc136}].[Parameter:{a2eb3b4d-89b3-47e3-a71a-a9af9ea02d43}].[EntityColumn:{684553a7-a59d-46fa-af4b-fc76e9fe3694}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("de9ed6c3-ed88-4cf7-ab83-d01f65a72d4d"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Duration",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationParameter.SourceValue = new ProcessSchemaParameterValue(durationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"60",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2d1b169e-e03f-4fdb-af83-330a2202e382"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7c8743bd-2621-4111-9391-e88aef7392d8"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d40a0c92-22fe-41e5-a347-863014e64651"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("05fa3610-54a9-41cf-8823-02427b559243"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"RemindBefore",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			remindBeforeParameter.SourceValue = new ProcessSchemaParameterValue(remindBeforeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("86328bc8-e79f-4784-8de2-62f529d4731d"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f36b46a3-6e19-4d93-b14b-92711c0af67d"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a8223992-1077-458a-a43b-f31646faf720"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"True",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("f9bb4916-8b76-441b-97f5-3829e9c7577d"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Lead",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadParameter.SourceValue = new ProcessSchemaParameterValue(leadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(leadParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("12354b8d-1de4-42c0-8580-8b4a8cc87644"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c511c956-3b86-4674-9f55-6b17f7dcc136}].[Parameter:{a2eb3b4d-89b3-47e3-a71a-a9af9ea02d43}].[EntityColumn:{4b95e3ff-fd52-4ae1-b0a5-2c5103ff15a7}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("b8943928-f451-4c29-bf21-c8507dd71fc7"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{04523d12-f6b8-419e-bccb-f9be9dd26362}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("ef324c1b-e6ef-414b-a2f4-e062755504d0"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Opportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			opportunityParameter.SourceValue = new ProcessSchemaParameterValue(opportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{e445615d-e4cb-4008-8fb6-06ac646c9b1d}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(opportunityParameter);
			var invoiceParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				UId = new Guid("1f3316a3-39d7-4532-a92f-135fb5048ca8"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Invoice",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			invoiceParameter.SourceValue = new ProcessSchemaParameterValue(invoiceParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(invoiceParameter);
			var documentParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				UId = new Guid("66a9f475-a400-4a24-997b-95a2c9456896"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Document",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			documentParameter.SourceValue = new ProcessSchemaParameterValue(documentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(documentParameter);
			var incidentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f7a924c4-c114-49f3-8a76-9c5ed5d86eef"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Incident",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			incidentParameter.SourceValue = new ProcessSchemaParameterValue(incidentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(incidentParameter);
			var caseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("08e08054-4aa0-44df-be80-6525a00a04b0"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Case",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			caseParameter.SourceValue = new ProcessSchemaParameterValue(caseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(caseParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7407a07e-08b0-46c2-90f1-567d9404eef6"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4c85b1b2-de28-4d04-a982-7c03d79a17f2"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b25e3158-4d7e-4bf2-8030-468e084c0944"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0d6f5944-41a2-467c-8c65-796bb3acb432"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ExecutionContext",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			executionContextParameter.SourceValue = new ProcessSchemaParameterValue(executionContextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executionContextParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a42c4cae-2324-4529-9fab-25532c110293"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
			var orderParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				UId = new Guid("d5474c10-2bda-4d1b-bc75-02f6fd9bfd70"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Order",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			orderParameter.SourceValue = new ProcessSchemaParameterValue(orderParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(orderParameter);
			var requestsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e524d819-e62f-4554-b5ed-afec584fa507"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Requests",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			requestsParameter.SourceValue = new ProcessSchemaParameterValue(requestsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(requestsParameter);
			var listingParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c3c40c47-9aaa-4df0-90ec-4f266efe3678"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Listing",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			listingParameter.SourceValue = new ProcessSchemaParameterValue(listingParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(listingParameter);
			var propertyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0af83741-79a2-4bcd-9f3e-911d95dab9e5"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Property",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			propertyParameter.SourceValue = new ProcessSchemaParameterValue(propertyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(propertyParameter);
			var contractParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				UId = new Guid("3316f182-99c4-4104-991a-609222b5420b"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Contract",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contractParameter.SourceValue = new ProcessSchemaParameterValue(contractParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contractParameter);
			var projectParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				UId = new Guid("de0ad26a-2a33-4bf7-ac7e-03801341d8d9"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Project",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			projectParameter.SourceValue = new ProcessSchemaParameterValue(projectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(projectParameter);
			var problemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				UId = new Guid("bf85018d-4659-454d-ac34-6a708760914a"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Problem",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			problemParameter.SourceValue = new ProcessSchemaParameterValue(problemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(problemParameter);
			var changeParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				UId = new Guid("577c5150-850c-4c09-8c5f-5fa5a57d7548"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Change",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			changeParameter.SourceValue = new ProcessSchemaParameterValue(changeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(changeParameter);
			var releaseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				UId = new Guid("d5ab01b8-003b-46a9-a84d-003715cb87ac"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Release",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			releaseParameter.SourceValue = new ProcessSchemaParameterValue(releaseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(releaseParameter);
			var queueItemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569"),
				UId = new Guid("4f72a1bc-9aff-47c1-b5aa-8bfde0a75d91"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"QueueItem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			queueItemParameter.SourceValue = new ProcessSchemaParameterValue(queueItemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(queueItemParameter);
			var applicationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0c1fc807-0b14-4f63-b9d0-c076b1977247"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Application",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			applicationParameter.SourceValue = new ProcessSchemaParameterValue(applicationParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(applicationParameter);
			var finApplicationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6d9aa803-7f13-479b-a9f2-2fceb21b3981"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"FinApplication",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			finApplicationParameter.SourceValue = new ProcessSchemaParameterValue(finApplicationParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(finApplicationParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("3e34f1e7-66a4-4368-be82-782625ad4885"),
				ContainerUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
		}

		protected virtual void InitializeActivityUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0d0a8195-0aeb-46fd-8689-03e9b40f0f52"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Подготовить договор",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("5120addc-ac6a-4727-bb46-1545cfa211a6"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ActivityCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityCategoryParameter.SourceValue = new ProcessSchemaParameterValue(activityCategoryParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"42c74c49-58e6-df11-971b-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("9f65b725-0817-4cbb-87ad-65fbd2ec8e2f"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"OwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			ownerIdParameter.SourceValue = new ProcessSchemaParameterValue(ownerIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c511c956-3b86-4674-9f55-6b17f7dcc136}].[Parameter:{a2eb3b4d-89b3-47e3-a71a-a9af9ea02d43}].[EntityColumn:{684553a7-a59d-46fa-af4b-fc76e9fe3694}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5ae12602-413f-4cf5-830c-f6922e887fe5"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Duration",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationParameter.SourceValue = new ProcessSchemaParameterValue(durationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"60",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bc328e43-e4dc-425c-a51d-1537a869b60d"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bfbaa963-9bd8-43da-91e2-524d26db6dcd"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("accce4dc-a559-42de-bf3f-bab9e65e8d31"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("47aad2de-0203-4c5a-a133-1bf273b360e8"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"RemindBefore",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			remindBeforeParameter.SourceValue = new ProcessSchemaParameterValue(remindBeforeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6d185412-2985-421f-b651-95c20507c79c"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7ebcc39c-bdaa-451a-8880-83ae7ae560a7"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("721d8393-fd64-4829-8365-96c05df7afaf"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"True",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("4b9707d4-2d4e-4894-98b6-fc178c952c44"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Lead",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadParameter.SourceValue = new ProcessSchemaParameterValue(leadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(leadParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("38722f57-6ead-42f2-8c52-267229961091"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c511c956-3b86-4674-9f55-6b17f7dcc136}].[Parameter:{a2eb3b4d-89b3-47e3-a71a-a9af9ea02d43}].[EntityColumn:{4b95e3ff-fd52-4ae1-b0a5-2c5103ff15a7}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("97e1f0f9-b62c-4364-b68e-9e2767680910"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{04523d12-f6b8-419e-bccb-f9be9dd26362}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("abb3d8e1-f454-4f1b-80e0-ad8f7b12582f"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Opportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			opportunityParameter.SourceValue = new ProcessSchemaParameterValue(opportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{e445615d-e4cb-4008-8fb6-06ac646c9b1d}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(opportunityParameter);
			var invoiceParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				UId = new Guid("3e07573c-be11-4fca-95a2-5ceae42d8192"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Invoice",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			invoiceParameter.SourceValue = new ProcessSchemaParameterValue(invoiceParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(invoiceParameter);
			var documentParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				UId = new Guid("0c76179d-9e38-479c-b03c-45ba5645c6ac"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Document",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			documentParameter.SourceValue = new ProcessSchemaParameterValue(documentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(documentParameter);
			var incidentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2e7fe8a8-2aac-4527-9781-68b22acb6ce7"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Incident",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			incidentParameter.SourceValue = new ProcessSchemaParameterValue(incidentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(incidentParameter);
			var caseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("138db65d-0482-4cb1-86a2-94c2f5aa9b70"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Case",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			caseParameter.SourceValue = new ProcessSchemaParameterValue(caseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(caseParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ea67008d-5899-44b9-ac91-0ac32942795c"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fc27e255-ef1c-4795-90e8-6b40e7364871"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f8c3e8ba-f5ea-44d1-8b43-28c8b4b1536c"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c5d0f37f-c1fd-49a5-b9cc-411b1b386347"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ExecutionContext",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			executionContextParameter.SourceValue = new ProcessSchemaParameterValue(executionContextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executionContextParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9b0f3698-f5d1-48f8-a317-90f6604436b8"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
			var orderParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				UId = new Guid("33187b1a-8d54-48d7-accf-120b4b9eafab"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Order",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			orderParameter.SourceValue = new ProcessSchemaParameterValue(orderParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(orderParameter);
			var requestsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("247b61ae-b4c8-4ea0-ab8e-17fccebc3c20"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Requests",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			requestsParameter.SourceValue = new ProcessSchemaParameterValue(requestsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(requestsParameter);
			var listingParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ca266c2d-a613-4ea1-bc01-110141f0e458"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Listing",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			listingParameter.SourceValue = new ProcessSchemaParameterValue(listingParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(listingParameter);
			var propertyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7e9a25e6-5836-4d07-927c-a09c258f245e"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Property",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			propertyParameter.SourceValue = new ProcessSchemaParameterValue(propertyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(propertyParameter);
			var contractParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				UId = new Guid("e3048d25-8664-40e9-9e10-e977d5960a47"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Contract",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contractParameter.SourceValue = new ProcessSchemaParameterValue(contractParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contractParameter);
			var projectParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				UId = new Guid("50a860b6-f5dd-44db-acc3-54621ac65994"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Project",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			projectParameter.SourceValue = new ProcessSchemaParameterValue(projectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(projectParameter);
			var problemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				UId = new Guid("20d1f52d-259c-4956-99b7-16b23ff5982b"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Problem",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			problemParameter.SourceValue = new ProcessSchemaParameterValue(problemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(problemParameter);
			var changeParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				UId = new Guid("6aad6b75-a077-4be7-bce4-bc10637f2dd0"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Change",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			changeParameter.SourceValue = new ProcessSchemaParameterValue(changeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(changeParameter);
			var releaseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				UId = new Guid("434afa75-99a0-4125-b2b9-78769ef32cf6"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Release",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			releaseParameter.SourceValue = new ProcessSchemaParameterValue(releaseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(releaseParameter);
			var queueItemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569"),
				UId = new Guid("5f1fd5ca-188e-44aa-9889-40df49cd44ff"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"QueueItem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			queueItemParameter.SourceValue = new ProcessSchemaParameterValue(queueItemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(queueItemParameter);
			var applicationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a7aee2de-8128-4e3d-b856-ad844296500d"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Application",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			applicationParameter.SourceValue = new ProcessSchemaParameterValue(applicationParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(applicationParameter);
			var finApplicationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f8cade62-1dde-41ae-b843-3061d6739d39"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"FinApplication",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			finApplicationParameter.SourceValue = new ProcessSchemaParameterValue(finApplicationParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(finApplicationParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("2dc8797c-3ccb-432f-9414-ad2131d06bdd"),
				ContainerUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
		}

		protected virtual void InitializeActivityUserTask3Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8d1bde28-9f1d-4e36-8b9a-3984a5101911"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Согласовать и подписать договор с клиентом",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("4d2046a6-44ac-440e-a7ac-045452cf845e"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ActivityCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityCategoryParameter.SourceValue = new ProcessSchemaParameterValue(activityCategoryParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"42c74c49-58e6-df11-971b-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("ca7534c4-7fb2-4226-a685-e20a9cedf7d3"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"OwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			ownerIdParameter.SourceValue = new ProcessSchemaParameterValue(ownerIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c511c956-3b86-4674-9f55-6b17f7dcc136}].[Parameter:{a2eb3b4d-89b3-47e3-a71a-a9af9ea02d43}].[EntityColumn:{684553a7-a59d-46fa-af4b-fc76e9fe3694}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("41df2887-609e-47ea-8750-cb20bf71b28a"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("477ad5e4-09d5-46f4-9eb3-a2add254cb82"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3001ced2-7863-4224-a9f4-6f0e170f1803"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ba9f16f7-7cf5-4919-b4b0-56b0f4326448"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8aa55692-6c95-4a12-9bd4-accb27e95e73"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("34f34eac-b72e-4938-9da7-22661a4ddc1e"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dc5bb9c3-e76c-48cc-b289-3595b05d43a6"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e2461305-7a1f-4119-bea0-03d61dcb8b7a"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"True",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("9df9f471-a948-4b49-a743-594a9d47982c"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Lead",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadParameter.SourceValue = new ProcessSchemaParameterValue(leadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(leadParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("10287c0c-5de9-4727-bba1-cd8c2bbfb7a6"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c511c956-3b86-4674-9f55-6b17f7dcc136}].[Parameter:{a2eb3b4d-89b3-47e3-a71a-a9af9ea02d43}].[EntityColumn:{4b95e3ff-fd52-4ae1-b0a5-2c5103ff15a7}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("a20fed6b-20e2-44a2-882a-2787218b3023"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{04523d12-f6b8-419e-bccb-f9be9dd26362}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("e0a7ebb4-6055-4117-9732-f734f9027097"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Opportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			opportunityParameter.SourceValue = new ProcessSchemaParameterValue(opportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{e445615d-e4cb-4008-8fb6-06ac646c9b1d}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(opportunityParameter);
			var invoiceParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				UId = new Guid("c29eedfa-4e51-41b5-8a82-027c22f33696"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Invoice",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			invoiceParameter.SourceValue = new ProcessSchemaParameterValue(invoiceParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(invoiceParameter);
			var documentParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				UId = new Guid("426d19c7-2f48-49f6-ac64-d0f781f92da6"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Document",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			documentParameter.SourceValue = new ProcessSchemaParameterValue(documentParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a51e066f-c7a2-4e1e-b210-f772e1f1f1c2}].[Parameter:{0c76179d-9e38-479c-b03c-45ba5645c6ac}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(documentParameter);
			var incidentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8a941eeb-ff7b-4f00-b0be-b394c578c953"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Incident",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			incidentParameter.SourceValue = new ProcessSchemaParameterValue(incidentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(incidentParameter);
			var caseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("69593abd-2dde-4a06-b6e4-8535411b60c4"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Case",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			caseParameter.SourceValue = new ProcessSchemaParameterValue(caseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(caseParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2aa25261-e527-47a8-8f9f-1193f9077eaf"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e6bf6064-b0fc-48c5-9f5b-5a866eb56cb1"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b0fd853a-497f-4923-ae36-2698d9aeb833"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e9993c3d-a3f8-4719-9ad3-ccf48e051778"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"ExecutionContext",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			executionContextParameter.SourceValue = new ProcessSchemaParameterValue(executionContextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executionContextParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("01f1f79c-154f-42e2-bd93-ef4b2754baa8"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
			var orderParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				UId = new Guid("01c010d1-0eb4-4578-9ef0-7a3316d972fa"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Order",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			orderParameter.SourceValue = new ProcessSchemaParameterValue(orderParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(orderParameter);
			var requestsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c732885e-4181-4343-ac01-80b814c64743"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Requests",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			requestsParameter.SourceValue = new ProcessSchemaParameterValue(requestsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(requestsParameter);
			var listingParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a480a653-7275-43e1-995a-a435338be920"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Listing",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			listingParameter.SourceValue = new ProcessSchemaParameterValue(listingParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(listingParameter);
			var propertyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("029b8b2e-60e9-4ceb-8de1-36c118a73975"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Property",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			propertyParameter.SourceValue = new ProcessSchemaParameterValue(propertyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(propertyParameter);
			var contractParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				UId = new Guid("67a1ab5b-be26-41ef-ad9d-769580e29663"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Contract",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contractParameter.SourceValue = new ProcessSchemaParameterValue(contractParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contractParameter);
			var projectParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				UId = new Guid("11109add-cffb-42ed-90df-c1db6cfa328e"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Project",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			projectParameter.SourceValue = new ProcessSchemaParameterValue(projectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(projectParameter);
			var problemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				UId = new Guid("728162f9-e142-496d-8213-297a6f65ddf3"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Problem",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			problemParameter.SourceValue = new ProcessSchemaParameterValue(problemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(problemParameter);
			var changeParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				UId = new Guid("70e5504a-570d-4400-814b-3e1d2ab51954"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Change",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			changeParameter.SourceValue = new ProcessSchemaParameterValue(changeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(changeParameter);
			var releaseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				UId = new Guid("d005960d-9e19-48ff-989b-608c23204804"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Release",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			releaseParameter.SourceValue = new ProcessSchemaParameterValue(releaseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(releaseParameter);
			var queueItemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569"),
				UId = new Guid("d925d534-beb4-44fa-b795-ccfac218eb13"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"QueueItem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			queueItemParameter.SourceValue = new ProcessSchemaParameterValue(queueItemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(queueItemParameter);
			var applicationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("91eea3fb-878a-4cdc-b3d2-ed2776d1e736"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"Application",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			applicationParameter.SourceValue = new ProcessSchemaParameterValue(applicationParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(applicationParameter);
			var finApplicationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6eb104ae-5d3f-4c4f-9fc4-3e7b0f977982"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Name = @"FinApplication",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			finApplicationParameter.SourceValue = new ProcessSchemaParameterValue(finApplicationParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(finApplicationParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("1a3726e1-9d63-40f5-97cd-b4fbdb26dafa"),
				ContainerUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
		}

		protected virtual void InitializeIntermediateCatchSignalEvent1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b54054fe-0c3e-4a40-8a0c-5810600ce07c"),
				ContainerUId = new Guid("d1f41578-b28e-45cc-9a47-ea4134488c23"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d1f41578-b28e-45cc-9a47-ea4134488c23"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{e445615d-e4cb-4008-8fb6-06ac646c9b1d}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaContractation = CreateContractationLaneSet();
			LaneSets.Add(schemaContractation);
			ProcessSchemaLane schemaSalesManager = CreateSalesManagerLane();
			schemaContractation.Lanes.Add(schemaSalesManager);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaUserTask changedatausertask1 = CreateChangeDataUserTask1UserTask();
			FlowElements.Add(changedatausertask1);
			ProcessSchemaUserTask activityusertask1 = CreateActivityUserTask1UserTask();
			FlowElements.Add(activityusertask1);
			ProcessSchemaUserTask activityusertask2 = CreateActivityUserTask2UserTask();
			FlowElements.Add(activityusertask2);
			ProcessSchemaUserTask activityusertask3 = CreateActivityUserTask3UserTask();
			FlowElements.Add(activityusertask3);
			ProcessSchemaIntermediateCatchSignalEvent intermediatecatchsignalevent1 = CreateIntermediateCatchSignalEvent1IntermediateCatchSignalEvent();
			FlowElements.Add(intermediatecatchsignalevent1);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaTerminateEvent terminate2 = CreateTerminate2TerminateEvent();
			FlowElements.Add(terminate2);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow4ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow5ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow6ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("d8a33e36-7030-41f2-b11e-0d8994c4cfab"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2357469d-9fc9-4fff-88c2-df8eb0f57577"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("3079647f-4e84-4749-8ff1-35dcd422e29d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("28740242-3b2a-4259-bd67-ef2705241859"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3ddbcc19-3b7e-4bf6-9e07-fd4451c8f862"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0c682bc5-fcae-40de-be1f-1d6f10249e20"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("c3d98049-da4e-4e58-a818-5494fa1b1162"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(102, 289),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2357469d-9fc9-4fff-88c2-df8eb0f57577"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d1f41578-b28e-45cc-9a47-ea4134488c23"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("0f9969b6-8a06-4cca-93e8-5df8e6a996fc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(172, 359),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d1f41578-b28e-45cc-9a47-ea4134488c23"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("75108602-c2e0-462f-88f6-3c0b843d7c9a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("2d10d40c-9c5d-4187-a9ba-d4d10201b991"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(302, 364),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("75108602-c2e0-462f-88f6-3c0b843d7c9a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("76e9ac5a-9d68-494f-bec3-777e671d2d5e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("01775baf-7204-4f79-8cd7-3b086fa2e1c5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(556, 216),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"), new Collection<Guid>() {
						new Guid("d8af30f0-f36b-1410-8f8f-485b39b2edcc"),
					}},
				}
			};
			schemaFlow.PolylinePointPositions.Add(new Point(672, 224));
			schemaFlow.PolylinePointPositions.Add(new Point(518, 224));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow4ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow4",
				UId = new Guid("b812eddc-9a3e-4779-b4cc-8ee0cfce8e40"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(690, 134),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("76e9ac5a-9d68-494f-bec3-777e671d2d5e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"), new Collection<Guid>() {
						new Guid("dbbf0e10-f46b-1410-6598-00155d043204"),
					}},
				}
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow5ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow5",
				UId = new Guid("6faecda4-3e44-40e1-a211-6ca29bed080e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(604, 134),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"), new Collection<Guid>() {
						new Guid("632afdd2-f616-4ea6-87d2-8ed38eed8aff"),
					}},
				}
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow6ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow6",
				UId = new Guid("1a35ebfe-e45b-4aad-92c6-0a51ba413692"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(453, 226),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0c682bc5-fcae-40de-be1f-1d6f10249e20"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"), new Collection<Guid>() {
						new Guid("dbbf0e10-f46b-1410-6598-00155d043204"),
					}},
				}
			};
			schemaFlow.PolylinePointPositions.Add(new Point(518, 56));
			schemaFlow.PolylinePointPositions.Add(new Point(966, 56));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("2bded54b-69a3-4a49-814e-e49a5f1338d6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(764, 133),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3ddbcc19-3b7e-4bf6-9e07-fd4451c8f862"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"), new Collection<Guid>() {
						new Guid("632afdd2-f616-4ea6-87d2-8ed38eed8aff"),
					}},
				}
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("6b33f279-ebd7-4b30-bf54-852999c8dbe6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				CurveCenterPosition = new Point(456, 134),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"), new Collection<Guid>() {
						new Guid("632afdd2-f616-4ea6-87d2-8ed38eed8aff"),
					}},
				}
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateContractationLaneSet() {
			ProcessSchemaLaneSet schemaContractation = new ProcessSchemaLaneSet(this) {
				UId = new Guid("fbcafd58-bc74-4f42-a8bf-e7d8fcda2555"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"Contractation",
				Position = new Point(5, 5),
				Size = new Size(989, 417),
				UseBackgroundMode = false
			};
			return schemaContractation;
		}

		protected virtual ProcessSchemaLane CreateSalesManagerLane() {
			ProcessSchemaLane schemaSalesManager = new ProcessSchemaLane(this) {
				UId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("fbcafd58-bc74-4f42-a8bf-e7d8fcda2555"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"SalesManager",
				Position = new Point(29, 0),
				Size = new Size(960, 417),
				UseBackgroundMode = false
			};
			return schemaSalesManager;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("2357469d-9fc9-4fff-88c2-df8eb0f57577"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"Start1",
				Position = new Point(71, 114),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("0c682bc5-fcae-40de-be1f-1d6f10249e20"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"Terminate1",
				Position = new Point(918, 114),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"ReadDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(169, 100),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("3ddbcc19-3b7e-4bf6-9e07-fd4451c8f862"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"ChangeDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(785, 100),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateActivityUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"ActivityUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(309, 100),
				SchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeActivityUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateActivityUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"ActivityUserTask2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(449, 100),
				SchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeActivityUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateActivityUserTask3UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"ActivityUserTask3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(603, 100),
				SchemaUId = new Guid("b5c726f2-af5b-4381-bac6-913074144308"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeActivityUserTask3Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateIntermediateCatchSignalEvent1IntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("d1f41578-b28e-45cc-9a47-ea4134488c23"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = false,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"IntermediateCatchSignalEvent1",
				NewEntityChangedColumns = false,
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(71, 275),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("797ac352-4979-4d28-906f-82feb6dbc9dc");
			InitializeIntermediateCatchSignalEvent1Parameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("75108602-c2e0-462f-88f6-3c0b843d7c9a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"FormulaTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(169, 261),
				ResultParameterMetaPath = @"88df6c2c-946a-477d-873f-71f366a99486",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,41,42,77,5,0,141,76,252,253,4,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate2TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("76e9ac5a-9d68-494f-bec3-777e671d2d5e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fad38e36-0801-4722-b343-c10bc94a5b3a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"Terminate2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(330, 275),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new OpportunityManagementContraction(userConnection);
		}

		public override object Clone() {
			return new OpportunityManagementContractionSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityManagementContraction

	/// <exclude/>
	public class OpportunityManagementContraction : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessSalesManager

		/// <exclude/>
		public class ProcessSalesManager : ProcessLane
		{

			public ProcessSalesManager(UserConnection userConnection, OpportunityManagementContraction process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ReadDataUserTask1FlowElement

		/// <exclude/>
		public class ReadDataUserTask1FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask1FlowElement(UserConnection userConnection, OpportunityManagementContraction process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("c511c956-3b86-4674-9f55-6b17f7dcc136");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,205,110,212,48,16,126,21,228,3,167,24,37,177,227,196,225,184,90,208,94,74,37,10,66,106,87,213,196,30,119,45,229,103,155,56,162,213,106,37,36,78,156,120,7,158,96,15,192,129,3,125,133,236,27,213,217,116,65,234,1,113,224,130,228,195,120,236,249,230,251,62,123,54,151,182,123,97,75,135,109,110,160,236,48,232,23,58,39,130,165,160,140,68,138,200,11,202,51,76,40,68,192,104,161,4,215,133,129,2,84,68,130,26,42,204,201,84,61,215,214,145,192,58,172,186,252,124,243,27,212,181,61,6,151,230,176,121,173,86,88,193,155,177,1,32,23,166,200,82,170,194,88,81,14,152,81,208,44,162,32,99,166,180,150,146,43,67,38,46,153,20,9,231,5,167,82,152,152,114,33,193,71,200,168,82,137,81,81,152,37,152,32,9,74,52,110,126,179,110,177,235,108,83,231,27,252,21,159,221,174,61,203,169,247,172,41,251,170,38,65,133,14,78,193,173,70,34,33,242,68,1,85,92,38,148,27,76,41,48,169,41,131,34,141,211,12,35,17,165,36,80,176,118,35,44,89,104,18,104,112,240,22,202,30,15,200,27,235,57,198,44,140,178,68,248,218,136,121,57,44,14,105,38,188,58,163,133,119,145,9,41,11,125,244,235,101,111,125,108,187,147,190,194,214,170,7,219,209,251,215,180,249,70,53,181,107,155,114,132,62,57,92,63,195,27,55,153,251,112,244,110,18,228,124,126,44,34,219,160,239,112,86,90,172,221,188,86,141,182,245,213,132,185,221,250,146,106,13,173,237,142,46,204,175,123,40,73,208,218,171,213,31,221,154,245,157,107,170,255,72,106,224,101,122,12,255,201,14,116,199,63,168,109,183,46,225,246,176,207,201,211,235,190,113,207,135,47,195,183,225,199,254,227,254,211,176,219,127,126,50,220,237,63,12,63,135,175,195,110,248,62,236,166,43,228,17,84,78,46,8,114,158,136,40,209,20,185,242,227,16,134,25,205,76,33,104,40,192,15,132,80,178,136,244,5,241,244,254,101,211,243,69,247,234,125,125,156,154,73,231,242,153,207,62,74,156,30,43,253,51,254,5,207,237,114,100,186,220,250,117,15,39,11,81,177,252,3,0,0 })));
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

		#region Class: ChangeDataUserTask1FlowElement

		/// <exclude/>
		public class ChangeDataUserTask1FlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataUserTask1FlowElement(UserConnection userConnection, OpportunityManagementContraction process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("3ddbcc19-3b7e-4bf6-9e07-fd4451c8f862");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Stage = () => (Guid)(new Guid("60d5310c-5be6-df11-971b-001d60e938c6"));
				_recordColumnValues_DueDate = () => (DateTime)(((DateTime)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentDateTime")));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Stage", () => _recordColumnValues_Stage.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_DueDate", () => _recordColumnValues_DueDate.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Stage;
			internal Func<DateTime> _recordColumnValues_DueDate;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,110,212,48,20,253,21,228,5,171,24,197,137,227,56,97,57,26,208,108,74,37,10,66,106,71,149,99,95,119,44,229,213,216,17,173,70,145,144,88,177,226,31,248,130,89,0,11,22,244,23,50,127,84,103,210,1,169,11,196,130,13,146,23,246,205,61,231,158,115,98,111,47,141,125,97,74,7,93,174,69,105,33,232,87,42,71,44,4,161,66,66,49,101,137,196,52,38,9,46,18,46,177,12,169,84,180,72,89,90,0,10,106,81,65,142,102,244,82,25,135,2,227,160,178,249,249,246,55,169,235,122,8,46,245,225,240,90,110,160,18,111,166,1,2,40,211,5,79,61,99,228,7,8,224,88,168,152,96,145,69,177,84,42,203,168,212,104,214,146,105,46,53,72,192,74,71,10,83,202,125,23,165,49,142,164,214,132,130,38,41,79,81,80,130,118,203,155,182,3,107,77,83,231,91,248,181,63,187,109,189,202,121,246,162,41,251,170,70,65,5,78,156,10,183,153,132,132,64,19,41,176,164,89,130,169,134,20,139,56,83,56,22,69,26,165,28,8,35,158,93,138,214,77,180,104,165,80,160,132,19,111,69,217,195,129,121,107,188,198,40,14,9,79,152,199,146,120,202,43,10,49,103,222,157,86,76,103,16,179,44,43,212,49,175,151,189,241,123,99,79,250,10,58,35,31,98,7,159,95,211,229,91,217,212,174,107,202,137,250,228,208,126,6,55,110,14,247,225,211,187,217,144,243,245,9,132,134,160,183,176,40,13,212,110,89,203,70,153,250,106,230,28,6,15,169,90,209,25,123,76,97,121,221,139,18,5,157,185,218,252,49,173,69,111,93,83,253,71,86,3,111,211,115,248,75,118,144,59,221,65,101,108,91,138,219,195,57,71,79,175,251,198,61,31,191,140,223,198,31,251,143,251,79,227,110,255,249,201,120,183,255,48,254,28,191,142,187,241,251,184,155,91,208,35,170,28,93,32,160,52,97,36,81,24,168,44,48,13,67,142,185,46,24,14,153,144,140,50,153,21,68,93,32,47,239,95,14,61,95,217,87,239,235,227,171,153,125,174,159,249,234,163,194,233,17,233,127,227,95,232,28,214,147,210,245,224,215,61,146,170,218,97,252,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,19,49,16,253,43,209,182,199,120,101,175,247,203,61,210,130,84,169,69,21,133,94,8,135,177,61,134,136,36,27,109,54,136,82,69,106,203,1,16,7,142,156,225,23,148,170,129,80,65,249,11,222,127,132,215,77,213,84,32,168,144,184,128,15,177,60,158,55,111,226,121,111,247,130,229,106,119,136,193,74,112,99,107,115,187,48,85,184,90,148,24,110,149,133,194,209,40,220,40,20,244,186,207,64,246,112,11,74,232,99,133,229,14,244,198,56,218,232,142,170,118,107,17,20,180,131,229,39,254,46,88,185,191,23,172,87,216,191,183,174,93,229,8,32,161,17,74,146,65,12,36,206,16,73,158,2,37,185,204,56,85,90,73,22,197,14,172,138,222,184,63,216,196,10,182,160,122,20,172,236,5,190,154,43,144,137,12,20,79,34,18,139,76,144,88,71,57,17,52,53,36,143,12,202,84,75,37,180,10,38,237,96,164,30,97,31,60,233,37,24,48,78,141,204,51,162,104,164,72,12,152,19,208,156,17,16,17,87,90,11,17,43,211,128,231,249,151,192,251,75,27,69,241,120,60,12,149,50,153,206,25,39,70,229,220,245,15,154,72,76,25,201,13,151,92,138,28,146,216,132,41,213,9,103,84,145,196,221,17,109,24,35,34,99,146,80,202,116,74,81,240,92,165,75,15,26,34,221,29,13,123,176,187,243,35,159,125,103,191,213,251,246,200,30,219,179,250,133,253,106,103,246,52,180,239,234,67,23,58,177,179,250,77,203,223,159,185,195,145,253,104,103,161,125,235,147,167,245,126,253,210,78,29,224,168,85,31,184,36,151,242,193,157,79,220,254,249,156,116,120,101,122,139,180,123,157,115,9,116,130,149,206,207,69,48,223,183,253,235,94,149,193,85,5,116,130,118,39,216,46,198,165,106,170,241,230,112,49,17,95,157,206,151,123,148,31,126,46,214,121,13,15,219,132,1,60,196,242,182,227,243,112,127,181,6,21,120,234,187,174,231,139,194,50,18,9,205,152,33,25,130,19,8,166,17,201,53,3,34,152,144,134,103,60,50,38,242,232,59,104,176,196,129,194,171,141,93,103,194,30,239,153,47,155,185,16,171,139,12,198,189,158,39,24,249,255,223,168,127,222,248,252,102,109,97,236,11,21,10,221,53,93,212,235,131,63,124,170,53,52,190,228,173,162,188,249,212,121,178,59,120,56,159,215,2,245,101,206,154,234,207,227,147,96,50,105,47,218,84,1,7,42,83,73,100,146,196,206,40,92,16,96,66,19,20,40,57,101,146,195,111,108,170,114,147,232,84,103,4,64,184,41,184,153,56,167,33,37,177,49,41,230,49,77,147,196,252,13,155,110,239,142,118,160,236,54,31,169,112,117,92,186,249,86,78,37,120,183,219,199,107,56,110,86,31,56,131,77,237,151,198,62,222,98,141,159,124,160,113,148,15,134,246,189,59,156,214,207,235,87,110,159,182,236,39,31,127,225,51,102,77,192,57,178,62,172,95,183,236,172,101,143,23,224,179,255,193,126,58,98,78,36,38,118,179,75,157,114,40,139,136,140,242,148,24,96,144,179,140,105,136,227,95,217,143,206,215,111,27,251,199,236,247,96,242,29,115,8,130,15,127,7,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b7ae2d2317b74dcabd064ac79c6dd368",
							"BaseElements.ChangeDataUserTask1.Parameters.RecordColumnValues.Value");
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

		#region Class: ActivityUserTask1FlowElement

		/// <exclude/>
		public class ActivityUserTask1FlowElement : ActivityUserTask
		{

			#region Constructors: Public

			public ActivityUserTask1FlowElement(UserConnection userConnection, OpportunityManagementContraction process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ActivityUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("2e691573-e278-4a4d-907f-5818bfc37f70");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.SalesManager;
				SerializeToDB = true;
				_ownerId = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
				_account = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("AccountId") : Guid.Empty)));
				_contact = () => (Guid)((process.MainContact));
				_opportunity = () => (Guid)((process.CurrentOpportunity));
			}

			#endregion

			#region Properties: Public

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("b7ae2d2317b74dcabd064ac79c6dd368",
						 "BaseElements.ActivityUserTask1.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			private Guid _activityCategory = new Guid("f51c4643-58e6-df11-971b-001d60e938c6");
			public override Guid ActivityCategory {
				get {
					return _activityCategory;
				}
				set {
					_activityCategory = value;
				}
			}

			internal Func<Guid> _ownerId;
			public override Guid OwnerId {
				get {
					return (_ownerId ?? (_ownerId = () => Guid.Empty)).Invoke();
				}
				set {
					_ownerId = () => { return value; };
				}
			}

			private int _duration = 60;
			public override int Duration {
				get {
					return _duration;
				}
				set {
					_duration = value;
				}
			}

			private int _remindBefore = 5;
			public override int RemindBefore {
				get {
					return _remindBefore;
				}
				set {
					_remindBefore = value;
				}
			}

			private bool _showInScheduler = true;
			public override bool ShowInScheduler {
				get {
					return _showInScheduler;
				}
				set {
					_showInScheduler = value;
				}
			}

			internal Func<Guid> _account;
			public override Guid Account {
				get {
					return (_account ?? (_account = () => Guid.Empty)).Invoke();
				}
				set {
					_account = () => { return value; };
				}
			}

			internal Func<Guid> _contact;
			public override Guid Contact {
				get {
					return (_contact ?? (_contact = () => Guid.Empty)).Invoke();
				}
				set {
					_contact = () => { return value; };
				}
			}

			internal Func<Guid> _opportunity;
			public override Guid Opportunity {
				get {
					return (_opportunity ?? (_opportunity = () => Guid.Empty)).Invoke();
				}
				set {
					_opportunity = () => { return value; };
				}
			}

			#endregion

			#region Methods: Public

			public override string GetResultAllowedValues() {
				return "[\"dbbf0e10-f46b-1410-6598-00155d043204\",\"632afdd2-f616-4ea6-87d2-8ed38eed8aff\"]";
			}

			#endregion

			#region Methods: Protected

			protected override void AfterActivitySaveScriptExecute(Entity activity) {
			}

			#endregion

		}

		#endregion

		#region Class: ActivityUserTask2FlowElement

		/// <exclude/>
		public class ActivityUserTask2FlowElement : ActivityUserTask
		{

			#region Constructors: Public

			public ActivityUserTask2FlowElement(UserConnection userConnection, OpportunityManagementContraction process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ActivityUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.SalesManager;
				SerializeToDB = true;
				_ownerId = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
				_account = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("AccountId") : Guid.Empty)));
				_contact = () => (Guid)((process.MainContact));
				_opportunity = () => (Guid)((process.CurrentOpportunity));
			}

			#endregion

			#region Properties: Public

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("b7ae2d2317b74dcabd064ac79c6dd368",
						 "BaseElements.ActivityUserTask2.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			private Guid _activityCategory = new Guid("42c74c49-58e6-df11-971b-001d60e938c6");
			public override Guid ActivityCategory {
				get {
					return _activityCategory;
				}
				set {
					_activityCategory = value;
				}
			}

			internal Func<Guid> _ownerId;
			public override Guid OwnerId {
				get {
					return (_ownerId ?? (_ownerId = () => Guid.Empty)).Invoke();
				}
				set {
					_ownerId = () => { return value; };
				}
			}

			private int _duration = 60;
			public override int Duration {
				get {
					return _duration;
				}
				set {
					_duration = value;
				}
			}

			private int _remindBefore = 5;
			public override int RemindBefore {
				get {
					return _remindBefore;
				}
				set {
					_remindBefore = value;
				}
			}

			private bool _showInScheduler = true;
			public override bool ShowInScheduler {
				get {
					return _showInScheduler;
				}
				set {
					_showInScheduler = value;
				}
			}

			internal Func<Guid> _account;
			public override Guid Account {
				get {
					return (_account ?? (_account = () => Guid.Empty)).Invoke();
				}
				set {
					_account = () => { return value; };
				}
			}

			internal Func<Guid> _contact;
			public override Guid Contact {
				get {
					return (_contact ?? (_contact = () => Guid.Empty)).Invoke();
				}
				set {
					_contact = () => { return value; };
				}
			}

			internal Func<Guid> _opportunity;
			public override Guid Opportunity {
				get {
					return (_opportunity ?? (_opportunity = () => Guid.Empty)).Invoke();
				}
				set {
					_opportunity = () => { return value; };
				}
			}

			#endregion

			#region Methods: Public

			public override string GetResultAllowedValues() {
				return "[\"632afdd2-f616-4ea6-87d2-8ed38eed8aff\",\"dbbf0e10-f46b-1410-6598-00155d043204\"]";
			}

			#endregion

			#region Methods: Protected

			protected override void AfterActivitySaveScriptExecute(Entity activity) {
			}

			#endregion

		}

		#endregion

		#region Class: ActivityUserTask3FlowElement

		/// <exclude/>
		public class ActivityUserTask3FlowElement : ActivityUserTask
		{

			#region Constructors: Public

			public ActivityUserTask3FlowElement(UserConnection userConnection, OpportunityManagementContraction process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ActivityUserTask3";
				IsLogging = true;
				SchemaElementUId = new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.SalesManager;
				SerializeToDB = true;
				_ownerId = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
				_account = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("AccountId") : Guid.Empty)));
				_contact = () => (Guid)((process.MainContact));
				_opportunity = () => (Guid)((process.CurrentOpportunity));
				_document = () => (Guid)((process.ActivityUserTask2.Document));
			}

			#endregion

			#region Properties: Public

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("b7ae2d2317b74dcabd064ac79c6dd368",
						 "BaseElements.ActivityUserTask3.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			private Guid _activityCategory = new Guid("42c74c49-58e6-df11-971b-001d60e938c6");
			public override Guid ActivityCategory {
				get {
					return _activityCategory;
				}
				set {
					_activityCategory = value;
				}
			}

			internal Func<Guid> _ownerId;
			public override Guid OwnerId {
				get {
					return (_ownerId ?? (_ownerId = () => Guid.Empty)).Invoke();
				}
				set {
					_ownerId = () => { return value; };
				}
			}

			private bool _showInScheduler = true;
			public override bool ShowInScheduler {
				get {
					return _showInScheduler;
				}
				set {
					_showInScheduler = value;
				}
			}

			internal Func<Guid> _account;
			public override Guid Account {
				get {
					return (_account ?? (_account = () => Guid.Empty)).Invoke();
				}
				set {
					_account = () => { return value; };
				}
			}

			internal Func<Guid> _contact;
			public override Guid Contact {
				get {
					return (_contact ?? (_contact = () => Guid.Empty)).Invoke();
				}
				set {
					_contact = () => { return value; };
				}
			}

			internal Func<Guid> _opportunity;
			public override Guid Opportunity {
				get {
					return (_opportunity ?? (_opportunity = () => Guid.Empty)).Invoke();
				}
				set {
					_opportunity = () => { return value; };
				}
			}

			internal Func<Guid> _document;
			public override Guid Document {
				get {
					return (_document ?? (_document = () => Guid.Empty)).Invoke();
				}
				set {
					_document = () => { return value; };
				}
			}

			#endregion

			#region Methods: Public

			public override string GetResultAllowedValues() {
				return "[\"d8af30f0-f36b-1410-8f8f-485b39b2edcc\",\"632afdd2-f616-4ea6-87d2-8ed38eed8aff\"]";
			}

			#endregion

			#region Methods: Protected

			protected override void AfterActivitySaveScriptExecute(Entity activity) {
			}

			#endregion

		}

		#endregion

		#region Class: IntermediateCatchSignalEvent1FlowElement

		/// <exclude/>
		public class IntermediateCatchSignalEvent1FlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public IntermediateCatchSignalEvent1FlowElement(UserConnection userConnection, OpportunityManagementContraction process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "IntermediateCatchSignalEvent1";
				IsLogging = false;
				SchemaElementUId = new Guid("d1f41578-b28e-45cc-9a47-ea4134488c23");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = false;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""797ac352-4979-4d28-906f-82feb6dbc9dc""]}";
				EntityFilters = @"{_isFilter:false,uId:""a63ed972-c618-4e6d-8175-4734418510ce"",name:""FilterEdit"",items:[]}";
				_recordId = () => (Guid)((process.CurrentOpportunity));
			}

			#endregion

			#region Properties: Public

			internal Func<Guid> _recordId;
			public override Guid RecordId {
				get {
					return (_recordId ?? (_recordId = () => Guid.Empty)).Invoke();
				}
				set {
					_recordId = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		public OpportunityManagementContraction(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityManagementContraction";
			SchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368");
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
				return new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: OpportunityManagementContraction, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: OpportunityManagementContraction, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid CurrentOpportunity {
			get;
			set;
		}

		public virtual bool OpportunityStageChanged {
			get;
			set;
		}

		public virtual Guid MainContact {
			get;
			set;
		}

		private ProcessSalesManager _salesManager;
		public ProcessSalesManager SalesManager {
			get {
				return _salesManager ?? ((_salesManager) = new ProcessSalesManager(UserConnection, this));
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
					SchemaElementUId = new Guid("2357469d-9fc9-4fff-88c2-df8eb0f57577"),
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
					SchemaElementUId = new Guid("0c682bc5-fcae-40de-be1f-1d6f10249e20"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ReadDataUserTask1FlowElement _readDataUserTask1;
		public ReadDataUserTask1FlowElement ReadDataUserTask1 {
			get {
				return _readDataUserTask1 ?? (_readDataUserTask1 = new ReadDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeDataUserTask1FlowElement _changeDataUserTask1;
		public ChangeDataUserTask1FlowElement ChangeDataUserTask1 {
			get {
				return _changeDataUserTask1 ?? (_changeDataUserTask1 = new ChangeDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ActivityUserTask1FlowElement _activityUserTask1;
		public ActivityUserTask1FlowElement ActivityUserTask1 {
			get {
				return _activityUserTask1 ?? (_activityUserTask1 = new ActivityUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ActivityUserTask2FlowElement _activityUserTask2;
		public ActivityUserTask2FlowElement ActivityUserTask2 {
			get {
				return _activityUserTask2 ?? (_activityUserTask2 = new ActivityUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ActivityUserTask3FlowElement _activityUserTask3;
		public ActivityUserTask3FlowElement ActivityUserTask3 {
			get {
				return _activityUserTask3 ?? (_activityUserTask3 = new ActivityUserTask3FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private IntermediateCatchSignalEvent1FlowElement _intermediateCatchSignalEvent1;
		public IntermediateCatchSignalEvent1FlowElement IntermediateCatchSignalEvent1 {
			get {
				return _intermediateCatchSignalEvent1 ?? ((_intermediateCatchSignalEvent1) = new IntermediateCatchSignalEvent1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _formulaTask1;
		public ProcessScriptTask FormulaTask1 {
			get {
				return _formulaTask1 ?? (_formulaTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask1",
					SchemaElementUId = new Guid("75108602-c2e0-462f-88f6-3c0b843d7c9a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask1Execute,
				});
			}
		}

		private ProcessTerminateEvent _terminate2;
		public ProcessTerminateEvent Terminate2 {
			get {
				return _terminate2 ?? (_terminate2 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate2",
					SchemaElementUId = new Guid("76e9ac5a-9d68-494f-bec3-777e671d2d5e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("01775baf-7204-4f79-8cd7-3b086fa2e1c5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"), new Collection<Guid>() {
							new Guid("d8af30f0-f36b-1410-8f8f-485b39b2edcc"),
						}},
					},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow4;
		public ProcessConditionalFlow ConditionalFlow4 {
			get {
				return _conditionalFlow4 ?? (_conditionalFlow4 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow4",
					SchemaElementUId = new Guid("b812eddc-9a3e-4779-b4cc-8ee0cfce8e40"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"), new Collection<Guid>() {
							new Guid("dbbf0e10-f46b-1410-6598-00155d043204"),
						}},
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
					SchemaElementUId = new Guid("6faecda4-3e44-40e1-a211-6ca29bed080e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"), new Collection<Guid>() {
							new Guid("632afdd2-f616-4ea6-87d2-8ed38eed8aff"),
						}},
					},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow6;
		public ProcessConditionalFlow ConditionalFlow6 {
			get {
				return _conditionalFlow6 ?? (_conditionalFlow6 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow6",
					SchemaElementUId = new Guid("1a35ebfe-e45b-4aad-92c6-0a51ba413692"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("a51e066f-c7a2-4e1e-b210-f772e1f1f1c2"), new Collection<Guid>() {
							new Guid("dbbf0e10-f46b-1410-6598-00155d043204"),
						}},
					},
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
					SchemaElementUId = new Guid("2bded54b-69a3-4a49-814e-e49a5f1338d6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("3af383a4-4ad2-4e3e-8ca0-5244284be0d0"), new Collection<Guid>() {
							new Guid("632afdd2-f616-4ea6-87d2-8ed38eed8aff"),
						}},
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
					SchemaElementUId = new Guid("6b33f279-ebd7-4b30-bf54-852999c8dbe6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("2e691573-e278-4a4d-907f-5818bfc37f70"), new Collection<Guid>() {
							new Guid("632afdd2-f616-4ea6-87d2-8ed38eed8aff"),
						}},
					},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[ChangeDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask1 };
			FlowElements[ActivityUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityUserTask1 };
			FlowElements[ActivityUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityUserTask2 };
			FlowElements[ActivityUserTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityUserTask3 };
			FlowElements[IntermediateCatchSignalEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateCatchSignalEvent1 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[Terminate2.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("IntermediateCatchSignalEvent1", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ReadDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ActivityUserTask1", e.Context.SenderName));
						break;
					case "ChangeDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ActivityUserTask1":
						if (ConditionalFlow4ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ActivityUserTask2", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "ActivityUserTask1");
						break;
					case "ActivityUserTask2":
						if (ConditionalFlow5ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ActivityUserTask3", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow6ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "ActivityUserTask2");
						break;
					case "ActivityUserTask3":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ActivityUserTask2", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask1", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "ActivityUserTask3");
						break;
					case "IntermediateCatchSignalEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
						break;
					case "Terminate2":
						CompleteProcess();
						break;
			}
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = ActivityUserTask3.ActivityResult == new Guid("d8af30f0-f36b-1410-8f8f-485b39b2edcc");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ActivityUserTask3", "ConditionalFlow2", "ActivityUserTask3.ActivityResult == new Guid(\"d8af30f0-f36b-1410-8f8f-485b39b2edcc\")", result);
			Log.Info($"ActivityUserTask3.ActivityResult: {ActivityUserTask3.ActivityResult}");
			return result;
		}

		private bool ConditionalFlow4ExpressionExecute() {
			bool result = ActivityUserTask1.ActivityResult == new Guid("dbbf0e10-f46b-1410-6598-00155d043204");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ActivityUserTask1", "ConditionalFlow4", "ActivityUserTask1.ActivityResult == new Guid(\"dbbf0e10-f46b-1410-6598-00155d043204\")", result);
			Log.Info($"ActivityUserTask1.ActivityResult: {ActivityUserTask1.ActivityResult}");
			return result;
		}

		private bool ConditionalFlow5ExpressionExecute() {
			bool result = ActivityUserTask2.ActivityResult == new Guid("632afdd2-f616-4ea6-87d2-8ed38eed8aff");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ActivityUserTask2", "ConditionalFlow5", "ActivityUserTask2.ActivityResult == new Guid(\"632afdd2-f616-4ea6-87d2-8ed38eed8aff\")", result);
			Log.Info($"ActivityUserTask2.ActivityResult: {ActivityUserTask2.ActivityResult}");
			return result;
		}

		private bool ConditionalFlow6ExpressionExecute() {
			bool result = ActivityUserTask2.ActivityResult == new Guid("dbbf0e10-f46b-1410-6598-00155d043204");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ActivityUserTask2", "ConditionalFlow6", "ActivityUserTask2.ActivityResult == new Guid(\"dbbf0e10-f46b-1410-6598-00155d043204\")", result);
			Log.Info($"ActivityUserTask2.ActivityResult: {ActivityUserTask2.ActivityResult}");
			return result;
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = ActivityUserTask3.ActivityResult == new Guid("632afdd2-f616-4ea6-87d2-8ed38eed8aff");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ActivityUserTask3", "ConditionalFlow1", "ActivityUserTask3.ActivityResult == new Guid(\"632afdd2-f616-4ea6-87d2-8ed38eed8aff\")", result);
			Log.Info($"ActivityUserTask3.ActivityResult: {ActivityUserTask3.ActivityResult}");
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = ActivityUserTask1.ActivityResult == new Guid("632afdd2-f616-4ea6-87d2-8ed38eed8aff");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ActivityUserTask1", "ConditionalFlow3", "ActivityUserTask1.ActivityResult == new Guid(\"632afdd2-f616-4ea6-87d2-8ed38eed8aff\")", result);
			Log.Info($"ActivityUserTask1.ActivityResult: {ActivityUserTask1.ActivityResult}");
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CurrentOpportunity")) {
				writer.WriteValue("CurrentOpportunity", CurrentOpportunity, Guid.Empty);
			}
			if (!HasMapping("MainContact")) {
				writer.WriteValue("MainContact", MainContact, Guid.Empty);
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
			MetaPathParameterValues.Add("e445615d-e4cb-4008-8fb6-06ac646c9b1d", () => CurrentOpportunity);
			MetaPathParameterValues.Add("88df6c2c-946a-477d-873f-71f366a99486", () => OpportunityStageChanged);
			MetaPathParameterValues.Add("04523d12-f6b8-419e-bccb-f9be9dd26362", () => MainContact);
			MetaPathParameterValues.Add("8f4a4849-9493-4e2f-844b-f698457ce514", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("4014b7ef-16bc-41f6-baec-19b9013b9312", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("d9ea8a7b-f3e9-4a1c-9fa7-f078e98333ab", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("09a1a83a-4492-4a83-993e-89a263175d60", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("82737ed0-7a4a-4ff4-b059-09969ea18610", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("00ab2ba3-17dc-4f80-a2cc-50070e128af8", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("4be420fc-337b-4a67-8a6a-c0dc63c803ec", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("a2eb3b4d-89b3-47e3-a71a-a9af9ea02d43", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("464cbe2d-ad13-45fd-bcc6-a63ee98115aa", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("b48ad8a6-545a-4455-9d3b-a4bc35df4b84", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("576b1762-a496-48e8-a0c3-5bd2ea4c034e", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("4036bfc1-f28a-4f25-99be-08627493ff79", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("dfd83cce-3024-4965-aac6-90a11b2e6275", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("28d0c589-93d1-47c4-b7fc-3705103f3f56", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("9dd070fb-a444-4291-8d1e-fc32a3224fa2", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("4c195665-6057-45a6-9822-86ed12a63c71", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("926a2ee8-0613-4c64-9cf2-88585d5fa80b", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("cf09060e-14f6-4096-a383-9bb90ee12518", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("b01fa112-d77f-4a5f-ab30-eb91374ac7ae", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("c3cf9431-8846-41fc-9850-72403c00e796", () => ChangeDataUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("b0a44d9c-4f65-4362-8cff-3075bdcb5c5f", () => ChangeDataUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("4394db70-02ff-403b-91c8-91898e517092", () => ChangeDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("e242e8eb-83ae-4cd6-a738-bda900c3da33", () => ChangeDataUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("5deaf690-2ceb-468b-b89a-9138b0ba6813", () => ChangeDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("6ca9f9fb-b8f2-4faf-ad43-f958521c933d", () => ActivityUserTask1.Recommendation);
			MetaPathParameterValues.Add("67e0db65-e87b-4e3d-904f-5df238c24945", () => ActivityUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("354f4d1d-8b87-4501-9d1c-927e640cbb78", () => ActivityUserTask1.OwnerId);
			MetaPathParameterValues.Add("de9ed6c3-ed88-4cf7-ab83-d01f65a72d4d", () => ActivityUserTask1.Duration);
			MetaPathParameterValues.Add("2d1b169e-e03f-4fdb-af83-330a2202e382", () => ActivityUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("7c8743bd-2621-4111-9391-e88aef7392d8", () => ActivityUserTask1.StartIn);
			MetaPathParameterValues.Add("d40a0c92-22fe-41e5-a347-863014e64651", () => ActivityUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("05fa3610-54a9-41cf-8823-02427b559243", () => ActivityUserTask1.RemindBefore);
			MetaPathParameterValues.Add("86328bc8-e79f-4784-8de2-62f529d4731d", () => ActivityUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("f36b46a3-6e19-4d93-b14b-92711c0af67d", () => ActivityUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("a8223992-1077-458a-a43b-f31646faf720", () => ActivityUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("f9bb4916-8b76-441b-97f5-3829e9c7577d", () => ActivityUserTask1.Lead);
			MetaPathParameterValues.Add("12354b8d-1de4-42c0-8580-8b4a8cc87644", () => ActivityUserTask1.Account);
			MetaPathParameterValues.Add("b8943928-f451-4c29-bf21-c8507dd71fc7", () => ActivityUserTask1.Contact);
			MetaPathParameterValues.Add("ef324c1b-e6ef-414b-a2f4-e062755504d0", () => ActivityUserTask1.Opportunity);
			MetaPathParameterValues.Add("1f3316a3-39d7-4532-a92f-135fb5048ca8", () => ActivityUserTask1.Invoice);
			MetaPathParameterValues.Add("66a9f475-a400-4a24-997b-95a2c9456896", () => ActivityUserTask1.Document);
			MetaPathParameterValues.Add("f7a924c4-c114-49f3-8a76-9c5ed5d86eef", () => ActivityUserTask1.Incident);
			MetaPathParameterValues.Add("08e08054-4aa0-44df-be80-6525a00a04b0", () => ActivityUserTask1.Case);
			MetaPathParameterValues.Add("7407a07e-08b0-46c2-90f1-567d9404eef6", () => ActivityUserTask1.ActivityResult);
			MetaPathParameterValues.Add("4c85b1b2-de28-4d04-a982-7c03d79a17f2", () => ActivityUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("b25e3158-4d7e-4bf2-8030-468e084c0944", () => ActivityUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("0d6f5944-41a2-467c-8c65-796bb3acb432", () => ActivityUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("a42c4cae-2324-4529-9fab-25532c110293", () => ActivityUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("d5474c10-2bda-4d1b-bc75-02f6fd9bfd70", () => ActivityUserTask1.Order);
			MetaPathParameterValues.Add("e524d819-e62f-4554-b5ed-afec584fa507", () => ActivityUserTask1.Requests);
			MetaPathParameterValues.Add("c3c40c47-9aaa-4df0-90ec-4f266efe3678", () => ActivityUserTask1.Listing);
			MetaPathParameterValues.Add("0af83741-79a2-4bcd-9f3e-911d95dab9e5", () => ActivityUserTask1.Property);
			MetaPathParameterValues.Add("3316f182-99c4-4104-991a-609222b5420b", () => ActivityUserTask1.Contract);
			MetaPathParameterValues.Add("de0ad26a-2a33-4bf7-ac7e-03801341d8d9", () => ActivityUserTask1.Project);
			MetaPathParameterValues.Add("bf85018d-4659-454d-ac34-6a708760914a", () => ActivityUserTask1.Problem);
			MetaPathParameterValues.Add("577c5150-850c-4c09-8c5f-5fa5a57d7548", () => ActivityUserTask1.Change);
			MetaPathParameterValues.Add("d5ab01b8-003b-46a9-a84d-003715cb87ac", () => ActivityUserTask1.Release);
			MetaPathParameterValues.Add("4f72a1bc-9aff-47c1-b5aa-8bfde0a75d91", () => ActivityUserTask1.QueueItem);
			MetaPathParameterValues.Add("0c1fc807-0b14-4f63-b9d0-c076b1977247", () => ActivityUserTask1.Application);
			MetaPathParameterValues.Add("6d9aa803-7f13-479b-a9f2-2fceb21b3981", () => ActivityUserTask1.FinApplication);
			MetaPathParameterValues.Add("3e34f1e7-66a4-4368-be82-782625ad4885", () => ActivityUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("0d0a8195-0aeb-46fd-8689-03e9b40f0f52", () => ActivityUserTask2.Recommendation);
			MetaPathParameterValues.Add("5120addc-ac6a-4727-bb46-1545cfa211a6", () => ActivityUserTask2.ActivityCategory);
			MetaPathParameterValues.Add("9f65b725-0817-4cbb-87ad-65fbd2ec8e2f", () => ActivityUserTask2.OwnerId);
			MetaPathParameterValues.Add("5ae12602-413f-4cf5-830c-f6922e887fe5", () => ActivityUserTask2.Duration);
			MetaPathParameterValues.Add("bc328e43-e4dc-425c-a51d-1537a869b60d", () => ActivityUserTask2.DurationPeriod);
			MetaPathParameterValues.Add("bfbaa963-9bd8-43da-91e2-524d26db6dcd", () => ActivityUserTask2.StartIn);
			MetaPathParameterValues.Add("accce4dc-a559-42de-bf3f-bab9e65e8d31", () => ActivityUserTask2.StartInPeriod);
			MetaPathParameterValues.Add("47aad2de-0203-4c5a-a133-1bf273b360e8", () => ActivityUserTask2.RemindBefore);
			MetaPathParameterValues.Add("6d185412-2985-421f-b651-95c20507c79c", () => ActivityUserTask2.RemindBeforePeriod);
			MetaPathParameterValues.Add("7ebcc39c-bdaa-451a-8880-83ae7ae560a7", () => ActivityUserTask2.ShowInScheduler);
			MetaPathParameterValues.Add("721d8393-fd64-4829-8365-96c05df7afaf", () => ActivityUserTask2.ShowExecutionPage);
			MetaPathParameterValues.Add("4b9707d4-2d4e-4894-98b6-fc178c952c44", () => ActivityUserTask2.Lead);
			MetaPathParameterValues.Add("38722f57-6ead-42f2-8c52-267229961091", () => ActivityUserTask2.Account);
			MetaPathParameterValues.Add("97e1f0f9-b62c-4364-b68e-9e2767680910", () => ActivityUserTask2.Contact);
			MetaPathParameterValues.Add("abb3d8e1-f454-4f1b-80e0-ad8f7b12582f", () => ActivityUserTask2.Opportunity);
			MetaPathParameterValues.Add("3e07573c-be11-4fca-95a2-5ceae42d8192", () => ActivityUserTask2.Invoice);
			MetaPathParameterValues.Add("0c76179d-9e38-479c-b03c-45ba5645c6ac", () => ActivityUserTask2.Document);
			MetaPathParameterValues.Add("2e7fe8a8-2aac-4527-9781-68b22acb6ce7", () => ActivityUserTask2.Incident);
			MetaPathParameterValues.Add("138db65d-0482-4cb1-86a2-94c2f5aa9b70", () => ActivityUserTask2.Case);
			MetaPathParameterValues.Add("ea67008d-5899-44b9-ac91-0ac32942795c", () => ActivityUserTask2.ActivityResult);
			MetaPathParameterValues.Add("fc27e255-ef1c-4795-90e8-6b40e7364871", () => ActivityUserTask2.CurrentActivityId);
			MetaPathParameterValues.Add("f8c3e8ba-f5ea-44d1-8b43-28c8b4b1536c", () => ActivityUserTask2.IsActivityCompleted);
			MetaPathParameterValues.Add("c5d0f37f-c1fd-49a5-b9cc-411b1b386347", () => ActivityUserTask2.ExecutionContext);
			MetaPathParameterValues.Add("9b0f3698-f5d1-48f8-a317-90f6604436b8", () => ActivityUserTask2.InformationOnStep);
			MetaPathParameterValues.Add("33187b1a-8d54-48d7-accf-120b4b9eafab", () => ActivityUserTask2.Order);
			MetaPathParameterValues.Add("247b61ae-b4c8-4ea0-ab8e-17fccebc3c20", () => ActivityUserTask2.Requests);
			MetaPathParameterValues.Add("ca266c2d-a613-4ea1-bc01-110141f0e458", () => ActivityUserTask2.Listing);
			MetaPathParameterValues.Add("7e9a25e6-5836-4d07-927c-a09c258f245e", () => ActivityUserTask2.Property);
			MetaPathParameterValues.Add("e3048d25-8664-40e9-9e10-e977d5960a47", () => ActivityUserTask2.Contract);
			MetaPathParameterValues.Add("50a860b6-f5dd-44db-acc3-54621ac65994", () => ActivityUserTask2.Project);
			MetaPathParameterValues.Add("20d1f52d-259c-4956-99b7-16b23ff5982b", () => ActivityUserTask2.Problem);
			MetaPathParameterValues.Add("6aad6b75-a077-4be7-bce4-bc10637f2dd0", () => ActivityUserTask2.Change);
			MetaPathParameterValues.Add("434afa75-99a0-4125-b2b9-78769ef32cf6", () => ActivityUserTask2.Release);
			MetaPathParameterValues.Add("5f1fd5ca-188e-44aa-9889-40df49cd44ff", () => ActivityUserTask2.QueueItem);
			MetaPathParameterValues.Add("a7aee2de-8128-4e3d-b856-ad844296500d", () => ActivityUserTask2.Application);
			MetaPathParameterValues.Add("f8cade62-1dde-41ae-b843-3061d6739d39", () => ActivityUserTask2.FinApplication);
			MetaPathParameterValues.Add("2dc8797c-3ccb-432f-9414-ad2131d06bdd", () => ActivityUserTask2.ActivityPriority);
			MetaPathParameterValues.Add("8d1bde28-9f1d-4e36-8b9a-3984a5101911", () => ActivityUserTask3.Recommendation);
			MetaPathParameterValues.Add("4d2046a6-44ac-440e-a7ac-045452cf845e", () => ActivityUserTask3.ActivityCategory);
			MetaPathParameterValues.Add("ca7534c4-7fb2-4226-a685-e20a9cedf7d3", () => ActivityUserTask3.OwnerId);
			MetaPathParameterValues.Add("41df2887-609e-47ea-8750-cb20bf71b28a", () => ActivityUserTask3.Duration);
			MetaPathParameterValues.Add("477ad5e4-09d5-46f4-9eb3-a2add254cb82", () => ActivityUserTask3.DurationPeriod);
			MetaPathParameterValues.Add("3001ced2-7863-4224-a9f4-6f0e170f1803", () => ActivityUserTask3.StartIn);
			MetaPathParameterValues.Add("ba9f16f7-7cf5-4919-b4b0-56b0f4326448", () => ActivityUserTask3.StartInPeriod);
			MetaPathParameterValues.Add("8aa55692-6c95-4a12-9bd4-accb27e95e73", () => ActivityUserTask3.RemindBefore);
			MetaPathParameterValues.Add("34f34eac-b72e-4938-9da7-22661a4ddc1e", () => ActivityUserTask3.RemindBeforePeriod);
			MetaPathParameterValues.Add("dc5bb9c3-e76c-48cc-b289-3595b05d43a6", () => ActivityUserTask3.ShowInScheduler);
			MetaPathParameterValues.Add("e2461305-7a1f-4119-bea0-03d61dcb8b7a", () => ActivityUserTask3.ShowExecutionPage);
			MetaPathParameterValues.Add("9df9f471-a948-4b49-a743-594a9d47982c", () => ActivityUserTask3.Lead);
			MetaPathParameterValues.Add("10287c0c-5de9-4727-bba1-cd8c2bbfb7a6", () => ActivityUserTask3.Account);
			MetaPathParameterValues.Add("a20fed6b-20e2-44a2-882a-2787218b3023", () => ActivityUserTask3.Contact);
			MetaPathParameterValues.Add("e0a7ebb4-6055-4117-9732-f734f9027097", () => ActivityUserTask3.Opportunity);
			MetaPathParameterValues.Add("c29eedfa-4e51-41b5-8a82-027c22f33696", () => ActivityUserTask3.Invoice);
			MetaPathParameterValues.Add("426d19c7-2f48-49f6-ac64-d0f781f92da6", () => ActivityUserTask3.Document);
			MetaPathParameterValues.Add("8a941eeb-ff7b-4f00-b0be-b394c578c953", () => ActivityUserTask3.Incident);
			MetaPathParameterValues.Add("69593abd-2dde-4a06-b6e4-8535411b60c4", () => ActivityUserTask3.Case);
			MetaPathParameterValues.Add("2aa25261-e527-47a8-8f9f-1193f9077eaf", () => ActivityUserTask3.ActivityResult);
			MetaPathParameterValues.Add("e6bf6064-b0fc-48c5-9f5b-5a866eb56cb1", () => ActivityUserTask3.CurrentActivityId);
			MetaPathParameterValues.Add("b0fd853a-497f-4923-ae36-2698d9aeb833", () => ActivityUserTask3.IsActivityCompleted);
			MetaPathParameterValues.Add("e9993c3d-a3f8-4719-9ad3-ccf48e051778", () => ActivityUserTask3.ExecutionContext);
			MetaPathParameterValues.Add("01f1f79c-154f-42e2-bd93-ef4b2754baa8", () => ActivityUserTask3.InformationOnStep);
			MetaPathParameterValues.Add("01c010d1-0eb4-4578-9ef0-7a3316d972fa", () => ActivityUserTask3.Order);
			MetaPathParameterValues.Add("c732885e-4181-4343-ac01-80b814c64743", () => ActivityUserTask3.Requests);
			MetaPathParameterValues.Add("a480a653-7275-43e1-995a-a435338be920", () => ActivityUserTask3.Listing);
			MetaPathParameterValues.Add("029b8b2e-60e9-4ceb-8de1-36c118a73975", () => ActivityUserTask3.Property);
			MetaPathParameterValues.Add("67a1ab5b-be26-41ef-ad9d-769580e29663", () => ActivityUserTask3.Contract);
			MetaPathParameterValues.Add("11109add-cffb-42ed-90df-c1db6cfa328e", () => ActivityUserTask3.Project);
			MetaPathParameterValues.Add("728162f9-e142-496d-8213-297a6f65ddf3", () => ActivityUserTask3.Problem);
			MetaPathParameterValues.Add("70e5504a-570d-4400-814b-3e1d2ab51954", () => ActivityUserTask3.Change);
			MetaPathParameterValues.Add("d005960d-9e19-48ff-989b-608c23204804", () => ActivityUserTask3.Release);
			MetaPathParameterValues.Add("d925d534-beb4-44fa-b795-ccfac218eb13", () => ActivityUserTask3.QueueItem);
			MetaPathParameterValues.Add("91eea3fb-878a-4cdc-b3d2-ed2776d1e736", () => ActivityUserTask3.Application);
			MetaPathParameterValues.Add("6eb104ae-5d3f-4c4f-9fc4-3e7b0f977982", () => ActivityUserTask3.FinApplication);
			MetaPathParameterValues.Add("1a3726e1-9d63-40f5-97cd-b4fbdb26dafa", () => ActivityUserTask3.ActivityPriority);
			MetaPathParameterValues.Add("b54054fe-0c3e-4a40-8a0c-5810600ce07c", () => IntermediateCatchSignalEvent1.RecordId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CurrentOpportunity":
					if (!hasValueToRead) break;
					CurrentOpportunity = reader.GetValue<System.Guid>();
				break;
				case "MainContact":
					if (!hasValueToRead) break;
					MainContact = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool FormulaTask1Execute(ProcessExecutingContext context) {
			var localOpportunityStageChanged = true;
			OpportunityStageChanged = (System.Boolean)localOpportunityStageChanged;
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
			var cloneItem = (OpportunityManagementContraction)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

