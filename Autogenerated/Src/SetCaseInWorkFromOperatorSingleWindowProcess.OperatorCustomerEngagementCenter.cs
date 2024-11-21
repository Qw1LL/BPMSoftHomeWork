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

	#region Class: SetCaseInWorkFromOperatorSingleWindowProcessSchema

	/// <exclude/>
	public class SetCaseInWorkFromOperatorSingleWindowProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SetCaseInWorkFromOperatorSingleWindowProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SetCaseInWorkFromOperatorSingleWindowProcessSchema(SetCaseInWorkFromOperatorSingleWindowProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SetCaseInWorkFromOperatorSingleWindowProcess";
			UId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba");
			CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2936";
			CultureName = @"ru-RU";
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba");
			Version = 0;
			PackageUId = new Guid("e16ad5af-f2b8-4128-ab85-84768b536fe3");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatequeueItemIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("43dc2cc4-56f4-4375-9b7e-6678733a10b8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Name = @"queueItemId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateentityRecordIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a3115906-98c5-476f-b511-42e526f42d22"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Name = @"entityRecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatequeueItemIdParameter());
			Parameters.Add(CreateentityRecordIdParameter());
		}

		protected virtual void InitializeReadCaseDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c2ee65cc-1e90-4553-8d20-3178607ee237"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,20,252,47,58,244,100,21,203,146,101,201,61,46,219,178,151,52,180,105,41,36,75,120,150,158,178,2,127,108,44,153,38,152,253,239,149,215,217,20,114,40,133,158,10,58,72,79,154,121,243,134,209,124,239,195,71,223,70,28,107,7,109,192,108,218,217,154,24,163,202,42,207,25,213,210,52,84,40,83,82,48,38,167,165,227,44,183,185,0,35,12,201,122,232,176,38,43,122,107,125,36,153,143,216,133,250,118,254,77,26,199,9,179,123,119,62,124,53,7,236,224,219,210,128,177,202,242,194,105,170,138,170,164,162,228,130,42,193,24,101,70,74,198,74,131,218,88,178,106,81,13,90,195,65,81,176,78,166,167,6,41,52,66,82,94,90,134,128,66,105,161,73,214,162,139,219,167,227,136,33,248,161,175,103,124,221,223,60,31,147,202,181,247,102,104,167,174,39,89,135,17,174,33,30,106,2,152,99,226,4,106,132,78,66,28,86,20,184,182,148,67,83,21,149,66,38,89,69,50,3,199,184,208,146,93,82,101,33,194,119,104,39,60,51,207,62,105,44,120,206,84,41,19,150,113,67,5,47,114,170,164,170,168,179,210,105,228,82,235,198,94,252,250,52,249,180,247,225,106,234,112,244,230,197,118,76,254,13,99,61,155,161,143,227,208,46,212,87,231,231,55,248,20,87,115,95,174,126,172,3,197,84,95,64,228,148,77,1,55,173,199,62,110,123,51,88,223,63,172,156,167,83,130,116,71,24,125,184,184,176,125,156,160,37,217,232,31,14,127,116,107,51,133,56,116,255,209,168,89,26,51,113,164,144,157,229,46,25,180,62,28,91,120,62,159,107,242,238,113,26,226,135,4,244,241,249,11,154,97,180,59,187,214,200,27,108,77,238,8,240,20,66,157,75,170,151,232,139,74,58,218,148,41,158,162,192,178,144,78,20,182,40,238,72,210,243,79,93,110,119,225,243,207,254,242,47,214,73,246,239,83,245,77,225,250,130,172,231,191,17,118,218,47,210,246,167,180,126,1,185,120,199,116,222,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f350e55f-585f-45c0-95f5-7db45767593a"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9355bd1a-1f10-4a9e-a601-cf464756d93f"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2061d672-5bf2-49d7-8e12-a882322cb67e"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9c9a5509-40b0-4eab-a790-027aaf7b0101"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("307882e3-9d8d-4857-b7bc-5fbcaad0a1b7"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				UId = new Guid("ce6d8bba-0242-4f3b-a66b-eddf60cacaac"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,43,205,77,74,45,178,50,180,50,4,0,178,212,123,197,17,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("a0867c52-dd78-452c-b1dc-ded2e82cd05b"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("19009b20-37be-44d0-86c7-63193e38e0d9"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				UId = new Guid("766277e4-c5a1-4e16-a15b-4fd6b9256122"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				UId = new Guid("321d89e8-2f9b-4e7e-94bf-8258f2dd3497"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				UId = new Guid("fb78a53b-f0d9-48ec-bb2e-00485c114a9f"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				UId = new Guid("6123acce-e28e-4ad1-84a6-fdb36a4f58bf"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				UId = new Guid("82ac66dc-eee0-4b42-aa1e-89d64a88df6f"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("995852ed-8c09-4182-a91f-7a1691dc09db"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2b71f00c-f538-43e3-919f-65adf1a65aa0"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,5,193,129,13,0,33,8,4,176,137,46,1,61,17,242,211,136,200,254,35,124,107,51,172,105,15,151,209,96,167,194,151,20,124,208,45,186,133,57,191,212,53,101,220,64,174,75,176,130,56,93,11,179,40,209,113,170,159,126,91,108,72,137,224,241,29,208,75,17,93,23,92,123,244,45,47,106,254,13,29,92,242,110,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1c5c6d7e-3154-482b-a049-0bfa453be0fc"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				UId = new Guid("6452b314-ba96-4a82-9a78-762a0d60a3f9"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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
				UId = new Guid("e0de160a-496e-4b45-ba97-2ca0f3bf0f0c"),
				ContainerUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
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

		protected virtual void InitializeOpenCaseEditPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var objectSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("228080ba-1f27-4a01-a8b6-bf29d7f03ad7"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ObjectSchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			objectSchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(objectSchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"117d32f9-8275-4534-8411-1c66115ce9cd",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(objectSchemaIdParameter);
			var pageSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("0a92316e-4ace-4238-b1c2-f10eef389115"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"PageSchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			pageSchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(pageSchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"73c75b87-44f4-4ab1-9ebb-6373a1f3903d",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(pageSchemaIdParameter);
			var editModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5329e3d5-a84c-44a7-9013-83a97ebbaba5"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"EditMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			editModeParameter.SourceValue = new ProcessSchemaParameterValue(editModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(editModeParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8eedb476-d7c7-4d57-bf65-ce30fced92e1"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"RecordColumnValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordColumnValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordColumnValuesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,171,86,82,41,169,44,72,85,178,82,114,10,240,13,206,79,43,209,115,206,47,74,213,11,40,202,79,78,45,46,214,243,201,79,78,204,201,172,74,76,202,73,13,72,44,74,204,77,45,73,45,10,75,204,41,77,45,246,201,44,46,209,81,64,214,164,164,163,164,82,6,150,83,178,138,142,173,5,0,224,26,131,0,90,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("855b3575-ea56-4b5d-b28b-8ebb007408d8"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{6bce5c3b-b12c-4e00-a5c2-37c0189a2cea}].[Parameter:{a0867c52-dd78-452c-b1dc-ded2e82cd05b}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
				MetaPath = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{6bce5c3b-b12c-4e00-a5c2-37c0189a2cea}].[Parameter:{a0867c52-dd78-452c-b1dc-ded2e82cd05b}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var executedModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1df0017d-53a6-42f5-afd4-4be0b452c846"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ExecutedMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			executedModeParameter.SourceValue = new ProcessSchemaParameterValue(executedModeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executedModeParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("35e8b0f9-c35e-461d-94eb-0e395c2daaf1"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b6d7b1e7-ca3d-4d2d-bcec-bb586593805b"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,107,220,48,16,253,47,62,244,228,1,201,26,201,214,246,24,182,16,40,155,208,180,165,80,74,24,73,163,196,212,107,59,254,32,13,203,254,247,202,187,217,54,180,33,135,210,75,110,18,210,232,189,55,111,158,118,215,245,248,174,110,38,30,86,145,154,145,243,249,60,172,178,232,81,83,197,17,72,74,4,244,46,66,133,149,3,29,61,177,172,138,224,131,202,242,150,182,188,202,142,213,235,80,79,89,222,116,55,181,167,230,162,231,129,166,186,107,87,217,197,144,229,245,196,219,113,245,117,247,27,106,26,102,206,175,227,97,115,229,111,121,75,159,22,88,41,203,160,138,104,161,42,74,13,168,21,38,88,41,65,122,99,164,212,158,173,15,217,145,161,102,139,100,17,65,89,17,1,49,113,117,10,37,24,140,49,136,138,116,170,72,124,56,78,235,31,253,192,227,184,176,217,241,175,245,199,135,62,113,63,98,159,117,205,188,109,179,124,203,19,93,210,116,187,202,168,148,20,136,9,20,154,164,63,48,131,115,24,193,151,164,149,70,45,40,148,89,238,169,63,138,188,154,104,154,199,44,31,56,242,192,173,231,39,154,172,141,74,11,169,192,184,146,0,203,96,192,33,10,96,21,37,9,71,214,74,159,229,129,38,250,76,205,204,7,94,187,58,21,186,194,106,81,202,8,37,147,5,100,83,64,21,36,129,149,214,69,85,166,62,197,226,228,193,251,174,251,62,247,169,211,227,102,222,242,80,251,71,51,57,185,210,13,171,157,239,218,105,232,154,229,241,205,147,130,163,105,143,135,95,142,45,105,14,39,75,97,182,207,231,145,207,154,154,219,105,221,250,46,212,237,205,193,185,253,62,213,108,123,26,234,241,212,200,77,55,173,239,102,106,82,15,234,155,219,23,123,126,73,67,162,144,140,127,109,170,243,254,196,252,192,121,153,232,80,143,125,67,15,135,253,42,123,115,55,119,211,219,13,223,31,23,217,31,5,167,11,196,58,22,81,10,136,104,28,72,92,86,193,18,8,161,211,60,232,96,188,170,30,95,216,231,207,66,124,224,174,231,150,195,203,56,81,24,197,206,113,122,221,27,64,91,165,86,162,146,16,42,31,73,23,145,131,143,39,156,111,201,211,255,155,79,173,68,40,209,65,37,77,2,79,130,193,98,250,70,88,232,168,189,21,214,71,252,247,124,150,194,20,34,136,148,34,76,33,197,52,33,96,147,202,68,169,44,162,15,85,64,233,158,228,243,226,190,93,198,237,185,120,74,227,88,25,45,161,138,92,0,74,157,196,133,32,128,42,161,2,154,74,133,229,167,123,93,131,250,119,60,207,199,20,208,205,220,52,139,211,63,1,49,212,98,187,243,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var generateDecisionsFromColumnParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cb67acf1-8eb7-4547-89ff-538edc782186"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"GenerateDecisionsFromColumn",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			generateDecisionsFromColumnParameter.SourceValue = new ProcessSchemaParameterValue(generateDecisionsFromColumnParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(generateDecisionsFromColumnParameter);
			var decisionalColumnMetaPathParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bd139764-de8a-419f-896e-f1a9bad65f09"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"DecisionalColumnMetaPath",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			decisionalColumnMetaPathParameter.SourceValue = new ProcessSchemaParameterValue(decisionalColumnMetaPathParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(decisionalColumnMetaPathParameter);
			var resultParameterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2dcceaa1-5ec7-42dc-86f9-219761d06cfa"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ResultParameter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			resultParameterParameter.SourceValue = new ProcessSchemaParameterValue(resultParameterParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultParameterParameter);
			var isReexecutionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a4df2bde-a100-4a77-8d4c-0a02b467852c"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"IsReexecution",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isReexecutionParameter.SourceValue = new ProcessSchemaParameterValue(isReexecutionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(isReexecutionParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("69ecde2c-d4dd-4337-a6d2-82cf79dd0cfa"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Обработать обращение",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("61abc7c8-2ef7-40ff-9d0a-e6982ff1305c"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("fd05f4c5-6126-481d-b937-770c614f11bf"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"OwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			ownerIdParameter.SourceValue = new ProcessSchemaParameterValue(ownerIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{6bce5c3b-b12c-4e00-a5c2-37c0189a2cea}].[Parameter:{a0867c52-dd78-452c-b1dc-ded2e82cd05b}].[EntityColumn:{70620d00-e4ea-48d1-9fdc-4572fcd8d41b}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2c0879c3-06f1-4a33-87c1-0451b0c55346"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Duration",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationParameter.SourceValue = new ProcessSchemaParameterValue(durationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"15",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7ca22f67-ce98-4b76-b3bf-b855951087ad"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a1e03cd9-7ed3-4ef6-be8d-6c51ff7c512a"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2dbc9f68-ce00-42a7-a118-560a9053bae0"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a4fc7c0-3982-4da3-98bd-ecbe38f9aa09"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a8c50d93-5ec8-476b-82f0-dd6a9a972dea"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e6a420b4-ea45-44bf-b633-b24cc17c3bfa"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cb0e1040-d4d1-489e-a193-aab9d0b5279c"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("f9853e4e-35c5-482c-bf26-7c5458cf3941"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Lead",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadParameter.SourceValue = new ProcessSchemaParameterValue(leadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(leadParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("f37aed9d-0eaf-455f-b40a-46d336b67bde"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{6bce5c3b-b12c-4e00-a5c2-37c0189a2cea}].[Parameter:{a0867c52-dd78-452c-b1dc-ded2e82cd05b}].[EntityColumn:{b15302c9-b5c4-4d94-afd5-3d409f9adfe1}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("c066593c-8b10-4096-890c-57e6dd1e9d63"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{6bce5c3b-b12c-4e00-a5c2-37c0189a2cea}].[Parameter:{a0867c52-dd78-452c-b1dc-ded2e82cd05b}].[EntityColumn:{6396f46e-c49f-4fb1-850d-824869ff04b3}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("c235c8fd-9c00-4757-ab5b-23d5af1ff6b4"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Opportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			opportunityParameter.SourceValue = new ProcessSchemaParameterValue(opportunityParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(opportunityParameter);
			var invoiceParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				UId = new Guid("b0b0b025-e805-44ae-a1cd-854b7f37f4a2"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Invoice",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			invoiceParameter.SourceValue = new ProcessSchemaParameterValue(invoiceParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(invoiceParameter);
			var documentParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				UId = new Guid("d8d5f6da-69d9-4e0b-b2da-1c544861a804"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Document",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			documentParameter.SourceValue = new ProcessSchemaParameterValue(documentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(documentParameter);
			var incidentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("22cd23e5-b5d2-4719-9fc6-6ee633ccb75f"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				UId = new Guid("654f09cd-bcae-43c6-ae0e-5c7f9103d7b1"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				UId = new Guid("d6387a8d-565e-4c66-baa0-22c0dfdae79a"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ActivityResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activityResultParameter.SourceValue = new ProcessSchemaParameterValue(activityResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activityResultParameter);
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("494bce0f-1ed6-4786-8064-d1af09e0ba56"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"CurrentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			currentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(currentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(currentActivityIdParameter);
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4b47d347-694e-4b23-966e-81e0b9436d4f"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6e05ffaf-7175-4a25-b30e-b9149c63a61a"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
			var pageTypeUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("aaf1bda0-c05d-4739-862b-8b7a708980a1"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"PageTypeUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			pageTypeUIdParameter.SourceValue = new ProcessSchemaParameterValue(pageTypeUIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba")
			};
			parametrizedElement.Parameters.Add(pageTypeUIdParameter);
			var activitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5f6287da-97d9-46d7-b633-d12672d72f63"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ActivitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(activitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activitySchemaUIdParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d98e6bc6-6f90-447f-b0ed-62d5c4c6bbfa"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				UId = new Guid("1e61c3d0-a846-4dc9-9da9-6910e8c92801"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				UId = new Guid("c69ee88f-fa71-4e1f-bf77-7b08d8ed25df"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				UId = new Guid("54bcda7d-7ae9-4aa7-a9f2-fcb3d36f5379"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				UId = new Guid("c73115a2-9593-46f9-b1de-7f79f0b0c7b5"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				UId = new Guid("d3b6514b-ad04-4867-bee1-53c358a32cf1"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
			var problemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				UId = new Guid("f5163c93-3b37-4684-a212-0deb3ba60759"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Problem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			problemParameter.SourceValue = new ProcessSchemaParameterValue(problemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(problemParameter);
			var changeParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				UId = new Guid("fd066318-341b-4c3c-9d2f-3d23b8ba1814"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Change",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			changeParameter.SourceValue = new ProcessSchemaParameterValue(changeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(changeParameter);
			var releaseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				UId = new Guid("f3ff095a-985c-4cdf-949b-8272814a1e93"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Release",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			releaseParameter.SourceValue = new ProcessSchemaParameterValue(releaseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(releaseParameter);
			var projectParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				UId = new Guid("81c9193f-dbbd-44e0-ba5f-8d126be20992"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Project",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			projectParameter.SourceValue = new ProcessSchemaParameterValue(projectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(projectParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("7856519d-7de0-4a62-9da7-af7bf749ed22"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
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
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0075d6b5-16d7-4f20-9394-6407922de606"),
				ContainerUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"CreateActivity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			createActivityParameter.SourceValue = new ProcessSchemaParameterValue(createActivityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaProcessCaseFromQueueLaneSet = CreateProcessCaseFromQueueLaneSetLaneSet();
			LaneSets.Add(schemaProcessCaseFromQueueLaneSet);
			ProcessSchemaLane schemaOperatorLane = CreateOperatorLaneLane();
			schemaProcessCaseFromQueueLaneSet.Lanes.Add(schemaOperatorLane);
			ProcessSchemaStartEvent start = CreateStartStartEvent();
			FlowElements.Add(start);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask readcasedatausertask = CreateReadCaseDataUserTaskUserTask();
			FlowElements.Add(readcasedatausertask);
			ProcessSchemaUserTask opencaseeditpageusertask = CreateOpenCaseEditPageUserTaskUserTask();
			FlowElements.Add(opencaseeditpageusertask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("8ccbbab7-bbd9-4e5c-b9f9-247c97fd74ac"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f9357fda-6bc8-4b0c-8bc1-2371a2cc9919"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("a09be13c-d355-4c9b-bdd8-d5d7df69451f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("69e143ce-e8e8-4549-8c00-d7c3559c9dc7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ec922e6c-3ff9-4d6c-b8c3-5ea232d58757"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateProcessCaseFromQueueLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaProcessCaseFromQueueLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("d10f1a49-2cfd-4eaa-a0e3-e59ab54c1566"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Name = @"ProcessCaseFromQueueLaneSet",
				Position = new Point(5, 5),
				Size = new Size(1666, 400),
				UseBackgroundMode = false
			};
			return schemaProcessCaseFromQueueLaneSet;
		}

		protected virtual ProcessSchemaLane CreateOperatorLaneLane() {
			ProcessSchemaLane schemaOperatorLane = new ProcessSchemaLane(this) {
				UId = new Guid("85d22627-656a-4efa-b193-acb360bd950b"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("d10f1a49-2cfd-4eaa-a0e3-e59ab54c1566"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Name = @"OperatorLane",
				Position = new Point(29, 0),
				Size = new Size(1637, 400),
				UseBackgroundMode = false
			};
			return schemaOperatorLane;
		}

		protected virtual ProcessSchemaStartEvent CreateStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("f9357fda-6bc8-4b0c-8bc1-2371a2cc9919"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("85d22627-656a-4efa-b193-acb360bd950b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Name = @"Start",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("ec922e6c-3ff9-4d6c-b8c3-5ea232d58757"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("85d22627-656a-4efa-b193-acb360bd950b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Name = @"Terminate1",
				Position = new Point(624, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadCaseDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("85d22627-656a-4efa-b193-acb360bd950b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Name = @"ReadCaseDataUserTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(208, 170),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadCaseDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenCaseEditPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("85d22627-656a-4efa-b193-acb360bd950b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				DragGroupName = @"Task",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				ModifiedInSchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"),
				Name = @"OpenCaseEditPageUserTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(408, 170),
				SchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenCaseEditPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SetCaseInWorkFromOperatorSingleWindowProcess(userConnection);
		}

		public override object Clone() {
			return new SetCaseInWorkFromOperatorSingleWindowProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("adf571f9-2b44-433a-bc78-fa17128089ba"));
		}

		#endregion

	}

	#endregion

	#region Class: SetCaseInWorkFromOperatorSingleWindowProcess

	/// <exclude/>
	public class SetCaseInWorkFromOperatorSingleWindowProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessOperatorLane

		/// <exclude/>
		public class ProcessOperatorLane : ProcessLane
		{

			public ProcessOperatorLane(UserConnection userConnection, SetCaseInWorkFromOperatorSingleWindowProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ReadCaseDataUserTaskFlowElement

		/// <exclude/>
		public class ReadCaseDataUserTaskFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadCaseDataUserTaskFlowElement(UserConnection userConnection, SetCaseInWorkFromOperatorSingleWindowProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadCaseDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("6bce5c3b-b12c-4e00-a5c2-37c0189a2cea");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,20,252,47,58,244,100,21,203,146,101,201,61,46,219,178,151,52,180,105,41,36,75,120,150,158,178,2,127,108,44,153,38,152,253,239,149,215,217,20,114,40,133,158,10,58,72,79,154,121,243,134,209,124,239,195,71,223,70,28,107,7,109,192,108,218,217,154,24,163,202,42,207,25,213,210,52,84,40,83,82,48,38,167,165,227,44,183,185,0,35,12,201,122,232,176,38,43,122,107,125,36,153,143,216,133,250,118,254,77,26,199,9,179,123,119,62,124,53,7,236,224,219,210,128,177,202,242,194,105,170,138,170,164,162,228,130,42,193,24,101,70,74,198,74,131,218,88,178,106,81,13,90,195,65,81,176,78,166,167,6,41,52,66,82,94,90,134,128,66,105,161,73,214,162,139,219,167,227,136,33,248,161,175,103,124,221,223,60,31,147,202,181,247,102,104,167,174,39,89,135,17,174,33,30,106,2,152,99,226,4,106,132,78,66,28,86,20,184,182,148,67,83,21,149,66,38,89,69,50,3,199,184,208,146,93,82,101,33,194,119,104,39,60,51,207,62,105,44,120,206,84,41,19,150,113,67,5,47,114,170,164,170,168,179,210,105,228,82,235,198,94,252,250,52,249,180,247,225,106,234,112,244,230,197,118,76,254,13,99,61,155,161,143,227,208,46,212,87,231,231,55,248,20,87,115,95,174,126,172,3,197,84,95,64,228,148,77,1,55,173,199,62,110,123,51,88,223,63,172,156,167,83,130,116,71,24,125,184,184,176,125,156,160,37,217,232,31,14,127,116,107,51,133,56,116,255,209,168,89,26,51,113,164,144,157,229,46,25,180,62,28,91,120,62,159,107,242,238,113,26,226,135,4,244,241,249,11,154,97,180,59,187,214,200,27,108,77,238,8,240,20,66,157,75,170,151,232,139,74,58,218,148,41,158,162,192,178,144,78,20,182,40,238,72,210,243,79,93,110,119,225,243,207,254,242,47,214,73,246,239,83,245,77,225,250,130,172,231,191,17,118,218,47,210,246,167,180,126,1,185,120,199,116,222,3,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,43,205,77,74,45,178,50,180,50,4,0,178,212,123,197,17,0,0,0 })));
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
								new Guid("117d32f9-8275-4534-8411-1c66115ce9cd")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"));
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
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,5,193,129,13,0,33,8,4,176,137,46,1,61,17,242,211,136,200,254,35,124,107,51,172,105,15,151,209,96,167,194,151,20,124,208,45,186,133,57,191,212,53,101,220,64,174,75,176,130,56,93,11,179,40,209,113,170,159,126,91,108,72,137,224,241,29,208,75,17,93,23,92,123,244,45,47,106,254,13,29,92,242,110,0,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: OpenCaseEditPageUserTaskFlowElement

		/// <exclude/>
		public class OpenCaseEditPageUserTaskFlowElement : OpenEditPageUserTask
		{

			#region Constructors: Public

			public OpenCaseEditPageUserTaskFlowElement(UserConnection userConnection, SetCaseInWorkFromOperatorSingleWindowProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenCaseEditPageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("d1520d87-55f3-45a9-a561-310c18caca32");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OperatorLane;
				SerializeToDB = true;
				_recordId = () => (Guid)(((process.ReadCaseDataUserTask.ResultEntity.IsColumnValueLoaded(process.ReadCaseDataUserTask.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadCaseDataUserTask.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
				_ownerId = () => (Guid)(((process.ReadCaseDataUserTask.ResultEntity.IsColumnValueLoaded(process.ReadCaseDataUserTask.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadCaseDataUserTask.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
				_account = () => (Guid)(((process.ReadCaseDataUserTask.ResultEntity.IsColumnValueLoaded(process.ReadCaseDataUserTask.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? process.ReadCaseDataUserTask.ResultEntity.GetTypedColumnValue<Guid>("AccountId") : Guid.Empty)));
				_contact = () => (Guid)(((process.ReadCaseDataUserTask.ResultEntity.IsColumnValueLoaded(process.ReadCaseDataUserTask.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? process.ReadCaseDataUserTask.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			private Guid _objectSchemaId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			public override Guid ObjectSchemaId {
				get {
					return _objectSchemaId;
				}
				set {
					_objectSchemaId = value;
				}
			}

			private Guid _pageSchemaId = new Guid("73c75b87-44f4-4ab1-9ebb-6373a1f3903d");
			public override Guid PageSchemaId {
				get {
					return _pageSchemaId;
				}
				set {
					_pageSchemaId = value;
				}
			}

			private int _editMode = 1;
			public override int EditMode {
				get {
					return _editMode;
				}
				set {
					_editMode = value;
				}
			}

			internal Func<Guid> _recordId;
			public override Guid RecordId {
				get {
					return (_recordId ?? (_recordId = () => Guid.Empty)).Invoke();
				}
				set {
					_recordId = () => { return value; };
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,107,220,48,16,253,47,62,244,228,1,201,26,201,214,246,24,182,16,40,155,208,180,165,80,74,24,73,163,196,212,107,59,254,32,13,203,254,247,202,187,217,54,180,33,135,210,75,110,18,210,232,189,55,111,158,118,215,245,248,174,110,38,30,86,145,154,145,243,249,60,172,178,232,81,83,197,17,72,74,4,244,46,66,133,149,3,29,61,177,172,138,224,131,202,242,150,182,188,202,142,213,235,80,79,89,222,116,55,181,167,230,162,231,129,166,186,107,87,217,197,144,229,245,196,219,113,245,117,247,27,106,26,102,206,175,227,97,115,229,111,121,75,159,22,88,41,203,160,138,104,161,42,74,13,168,21,38,88,41,65,122,99,164,212,158,173,15,217,145,161,102,139,100,17,65,89,17,1,49,113,117,10,37,24,140,49,136,138,116,170,72,124,56,78,235,31,253,192,227,184,176,217,241,175,245,199,135,62,113,63,98,159,117,205,188,109,179,124,203,19,93,210,116,187,202,168,148,20,136,9,20,154,164,63,48,131,115,24,193,151,164,149,70,45,40,148,89,238,169,63,138,188,154,104,154,199,44,31,56,242,192,173,231,39,154,172,141,74,11,169,192,184,146,0,203,96,192,33,10,96,21,37,9,71,214,74,159,229,129,38,250,76,205,204,7,94,187,58,21,186,194,106,81,202,8,37,147,5,100,83,64,21,36,129,149,214,69,85,166,62,197,226,228,193,251,174,251,62,247,169,211,227,102,222,242,80,251,71,51,57,185,210,13,171,157,239,218,105,232,154,229,241,205,147,130,163,105,143,135,95,142,45,105,14,39,75,97,182,207,231,145,207,154,154,219,105,221,250,46,212,237,205,193,185,253,62,213,108,123,26,234,241,212,200,77,55,173,239,102,106,82,15,234,155,219,23,123,126,73,67,162,144,140,127,109,170,243,254,196,252,192,121,153,232,80,143,125,67,15,135,253,42,123,115,55,119,211,219,13,223,31,23,217,31,5,167,11,196,58,22,81,10,136,104,28,72,92,86,193,18,8,161,211,60,232,96,188,170,30,95,216,231,207,66,124,224,174,231,150,195,203,56,81,24,197,206,113,122,221,27,64,91,165,86,162,146,16,42,31,73,23,145,131,143,39,156,111,201,211,255,155,79,173,68,40,209,65,37,77,2,79,130,193,98,250,70,88,232,168,189,21,214,71,252,247,124,150,194,20,34,136,148,34,76,33,197,52,33,96,147,202,68,169,44,162,15,85,64,233,158,228,243,226,190,93,198,237,185,120,74,227,88,25,45,161,138,92,0,74,157,196,133,32,128,42,161,2,154,74,133,229,167,123,93,131,250,119,60,207,199,20,208,205,220,52,139,211,63,1,49,212,98,187,243,5,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private bool _generateDecisionsFromColumn = false;
			public override bool GenerateDecisionsFromColumn {
				get {
					return _generateDecisionsFromColumn;
				}
				set {
					_generateDecisionsFromColumn = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("adf571f92b44433abc78fa17128089ba",
						 "BaseElements.OpenCaseEditPageUserTask.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
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

			private int _duration = 15;
			public override int Duration {
				get {
					return _duration;
				}
				set {
					_duration = value;
				}
			}

			private int _durationPeriod = 0;
			public override int DurationPeriod {
				get {
					return _durationPeriod;
				}
				set {
					_durationPeriod = value;
				}
			}

			private int _startInPeriod = 0;
			public override int StartInPeriod {
				get {
					return _startInPeriod;
				}
				set {
					_startInPeriod = value;
				}
			}

			private int _remindBeforePeriod = 0;
			public override int RemindBeforePeriod {
				get {
					return _remindBeforePeriod;
				}
				set {
					_remindBeforePeriod = value;
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

			#endregion

		}

		#endregion

		public SetCaseInWorkFromOperatorSingleWindowProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SetCaseInWorkFromOperatorSingleWindowProcess";
			SchemaUId = new Guid("adf571f9-2b44-433a-bc78-fa17128089ba");
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
				return new Guid("adf571f9-2b44-433a-bc78-fa17128089ba");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SetCaseInWorkFromOperatorSingleWindowProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SetCaseInWorkFromOperatorSingleWindowProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid queueItemId {
			get;
			set;
		}

		public virtual Guid entityRecordId {
			get;
			set;
		}

		private ProcessOperatorLane _operatorLane;
		public ProcessOperatorLane OperatorLane {
			get {
				return _operatorLane ?? ((_operatorLane) = new ProcessOperatorLane(UserConnection, this));
			}
		}

		private ProcessFlowElement _start;
		public ProcessFlowElement Start {
			get {
				return _start ?? (_start = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "Start",
					SchemaElementUId = new Guid("f9357fda-6bc8-4b0c-8bc1-2371a2cc9919"),
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
					SchemaElementUId = new Guid("ec922e6c-3ff9-4d6c-b8c3-5ea232d58757"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ReadCaseDataUserTaskFlowElement _readCaseDataUserTask;
		public ReadCaseDataUserTaskFlowElement ReadCaseDataUserTask {
			get {
				return _readCaseDataUserTask ?? (_readCaseDataUserTask = new ReadCaseDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private OpenCaseEditPageUserTaskFlowElement _openCaseEditPageUserTask;
		public OpenCaseEditPageUserTaskFlowElement OpenCaseEditPageUserTask {
			get {
				return _openCaseEditPageUserTask ?? (_openCaseEditPageUserTask = new OpenCaseEditPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start.SchemaElementUId] = new Collection<ProcessFlowElement> { Start };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ReadCaseDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadCaseDataUserTask };
			FlowElements[OpenCaseEditPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenCaseEditPageUserTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadCaseDataUserTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ReadCaseDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenCaseEditPageUserTask", e.Context.SenderName));
						break;
					case "OpenCaseEditPageUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("queueItemId")) {
				writer.WriteValue("queueItemId", queueItemId, Guid.Empty);
			}
			if (!HasMapping("entityRecordId")) {
				writer.WriteValue("entityRecordId", entityRecordId, Guid.Empty);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("Start", string.Empty));
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
			MetaPathParameterValues.Add("43dc2cc4-56f4-4375-9b7e-6678733a10b8", () => queueItemId);
			MetaPathParameterValues.Add("a3115906-98c5-476f-b511-42e526f42d22", () => entityRecordId);
			MetaPathParameterValues.Add("c2ee65cc-1e90-4553-8d20-3178607ee237", () => ReadCaseDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("f350e55f-585f-45c0-95f5-7db45767593a", () => ReadCaseDataUserTask.ResultType);
			MetaPathParameterValues.Add("9355bd1a-1f10-4a9e-a601-cf464756d93f", () => ReadCaseDataUserTask.ReadSomeTopRecords);
			MetaPathParameterValues.Add("2061d672-5bf2-49d7-8e12-a882322cb67e", () => ReadCaseDataUserTask.NumberOfRecords);
			MetaPathParameterValues.Add("9c9a5509-40b0-4eab-a790-027aaf7b0101", () => ReadCaseDataUserTask.FunctionType);
			MetaPathParameterValues.Add("307882e3-9d8d-4857-b7bc-5fbcaad0a1b7", () => ReadCaseDataUserTask.AggregationColumnName);
			MetaPathParameterValues.Add("ce6d8bba-0242-4f3b-a66b-eddf60cacaac", () => ReadCaseDataUserTask.OrderInfo);
			MetaPathParameterValues.Add("a0867c52-dd78-452c-b1dc-ded2e82cd05b", () => ReadCaseDataUserTask.ResultEntity);
			MetaPathParameterValues.Add("19009b20-37be-44d0-86c7-63193e38e0d9", () => ReadCaseDataUserTask.ResultCount);
			MetaPathParameterValues.Add("766277e4-c5a1-4e16-a15b-4fd6b9256122", () => ReadCaseDataUserTask.ResultIntegerFunction);
			MetaPathParameterValues.Add("321d89e8-2f9b-4e7e-94bf-8258f2dd3497", () => ReadCaseDataUserTask.ResultFloatFunction);
			MetaPathParameterValues.Add("fb78a53b-f0d9-48ec-bb2e-00485c114a9f", () => ReadCaseDataUserTask.ResultDateTimeFunction);
			MetaPathParameterValues.Add("6123acce-e28e-4ad1-84a6-fdb36a4f58bf", () => ReadCaseDataUserTask.ResultRowsCount);
			MetaPathParameterValues.Add("82ac66dc-eee0-4b42-aa1e-89d64a88df6f", () => ReadCaseDataUserTask.CanReadUncommitedData);
			MetaPathParameterValues.Add("995852ed-8c09-4182-a91f-7a1691dc09db", () => ReadCaseDataUserTask.ResultEntityCollection);
			MetaPathParameterValues.Add("2b71f00c-f538-43e3-919f-65adf1a65aa0", () => ReadCaseDataUserTask.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("1c5c6d7e-3154-482b-a049-0bfa453be0fc", () => ReadCaseDataUserTask.IgnoreDisplayValues);
			MetaPathParameterValues.Add("6452b314-ba96-4a82-9a78-762a0d60a3f9", () => ReadCaseDataUserTask.ResultCompositeObjectList);
			MetaPathParameterValues.Add("e0de160a-496e-4b45-ba97-2ca0f3bf0f0c", () => ReadCaseDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("228080ba-1f27-4a01-a8b6-bf29d7f03ad7", () => OpenCaseEditPageUserTask.ObjectSchemaId);
			MetaPathParameterValues.Add("0a92316e-4ace-4238-b1c2-f10eef389115", () => OpenCaseEditPageUserTask.PageSchemaId);
			MetaPathParameterValues.Add("5329e3d5-a84c-44a7-9013-83a97ebbaba5", () => OpenCaseEditPageUserTask.EditMode);
			MetaPathParameterValues.Add("8eedb476-d7c7-4d57-bf65-ce30fced92e1", () => OpenCaseEditPageUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("855b3575-ea56-4b5d-b28b-8ebb007408d8", () => OpenCaseEditPageUserTask.RecordId);
			MetaPathParameterValues.Add("1df0017d-53a6-42f5-afd4-4be0b452c846", () => OpenCaseEditPageUserTask.ExecutedMode);
			MetaPathParameterValues.Add("35e8b0f9-c35e-461d-94eb-0e395c2daaf1", () => OpenCaseEditPageUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("b6d7b1e7-ca3d-4d2d-bcec-bb586593805b", () => OpenCaseEditPageUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("cb67acf1-8eb7-4547-89ff-538edc782186", () => OpenCaseEditPageUserTask.GenerateDecisionsFromColumn);
			MetaPathParameterValues.Add("bd139764-de8a-419f-896e-f1a9bad65f09", () => OpenCaseEditPageUserTask.DecisionalColumnMetaPath);
			MetaPathParameterValues.Add("2dcceaa1-5ec7-42dc-86f9-219761d06cfa", () => OpenCaseEditPageUserTask.ResultParameter);
			MetaPathParameterValues.Add("a4df2bde-a100-4a77-8d4c-0a02b467852c", () => OpenCaseEditPageUserTask.IsReexecution);
			MetaPathParameterValues.Add("69ecde2c-d4dd-4337-a6d2-82cf79dd0cfa", () => OpenCaseEditPageUserTask.Recommendation);
			MetaPathParameterValues.Add("61abc7c8-2ef7-40ff-9d0a-e6982ff1305c", () => OpenCaseEditPageUserTask.ActivityCategory);
			MetaPathParameterValues.Add("fd05f4c5-6126-481d-b937-770c614f11bf", () => OpenCaseEditPageUserTask.OwnerId);
			MetaPathParameterValues.Add("2c0879c3-06f1-4a33-87c1-0451b0c55346", () => OpenCaseEditPageUserTask.Duration);
			MetaPathParameterValues.Add("7ca22f67-ce98-4b76-b3bf-b855951087ad", () => OpenCaseEditPageUserTask.DurationPeriod);
			MetaPathParameterValues.Add("a1e03cd9-7ed3-4ef6-be8d-6c51ff7c512a", () => OpenCaseEditPageUserTask.StartIn);
			MetaPathParameterValues.Add("2dbc9f68-ce00-42a7-a118-560a9053bae0", () => OpenCaseEditPageUserTask.StartInPeriod);
			MetaPathParameterValues.Add("0a4fc7c0-3982-4da3-98bd-ecbe38f9aa09", () => OpenCaseEditPageUserTask.RemindBefore);
			MetaPathParameterValues.Add("a8c50d93-5ec8-476b-82f0-dd6a9a972dea", () => OpenCaseEditPageUserTask.RemindBeforePeriod);
			MetaPathParameterValues.Add("e6a420b4-ea45-44bf-b633-b24cc17c3bfa", () => OpenCaseEditPageUserTask.ShowInScheduler);
			MetaPathParameterValues.Add("cb0e1040-d4d1-489e-a193-aab9d0b5279c", () => OpenCaseEditPageUserTask.ShowExecutionPage);
			MetaPathParameterValues.Add("f9853e4e-35c5-482c-bf26-7c5458cf3941", () => OpenCaseEditPageUserTask.Lead);
			MetaPathParameterValues.Add("f37aed9d-0eaf-455f-b40a-46d336b67bde", () => OpenCaseEditPageUserTask.Account);
			MetaPathParameterValues.Add("c066593c-8b10-4096-890c-57e6dd1e9d63", () => OpenCaseEditPageUserTask.Contact);
			MetaPathParameterValues.Add("c235c8fd-9c00-4757-ab5b-23d5af1ff6b4", () => OpenCaseEditPageUserTask.Opportunity);
			MetaPathParameterValues.Add("b0b0b025-e805-44ae-a1cd-854b7f37f4a2", () => OpenCaseEditPageUserTask.Invoice);
			MetaPathParameterValues.Add("d8d5f6da-69d9-4e0b-b2da-1c544861a804", () => OpenCaseEditPageUserTask.Document);
			MetaPathParameterValues.Add("22cd23e5-b5d2-4719-9fc6-6ee633ccb75f", () => OpenCaseEditPageUserTask.Incident);
			MetaPathParameterValues.Add("654f09cd-bcae-43c6-ae0e-5c7f9103d7b1", () => OpenCaseEditPageUserTask.Case);
			MetaPathParameterValues.Add("d6387a8d-565e-4c66-baa0-22c0dfdae79a", () => OpenCaseEditPageUserTask.ActivityResult);
			MetaPathParameterValues.Add("494bce0f-1ed6-4786-8064-d1af09e0ba56", () => OpenCaseEditPageUserTask.CurrentActivityId);
			MetaPathParameterValues.Add("4b47d347-694e-4b23-966e-81e0b9436d4f", () => OpenCaseEditPageUserTask.IsActivityCompleted);
			MetaPathParameterValues.Add("6e05ffaf-7175-4a25-b30e-b9149c63a61a", () => OpenCaseEditPageUserTask.ExecutionContext);
			MetaPathParameterValues.Add("aaf1bda0-c05d-4739-862b-8b7a708980a1", () => OpenCaseEditPageUserTask.PageTypeUId);
			MetaPathParameterValues.Add("5f6287da-97d9-46d7-b633-d12672d72f63", () => OpenCaseEditPageUserTask.ActivitySchemaUId);
			MetaPathParameterValues.Add("d98e6bc6-6f90-447f-b0ed-62d5c4c6bbfa", () => OpenCaseEditPageUserTask.InformationOnStep);
			MetaPathParameterValues.Add("1e61c3d0-a846-4dc9-9da9-6910e8c92801", () => OpenCaseEditPageUserTask.Order);
			MetaPathParameterValues.Add("c69ee88f-fa71-4e1f-bf77-7b08d8ed25df", () => OpenCaseEditPageUserTask.Requests);
			MetaPathParameterValues.Add("54bcda7d-7ae9-4aa7-a9f2-fcb3d36f5379", () => OpenCaseEditPageUserTask.Listing);
			MetaPathParameterValues.Add("c73115a2-9593-46f9-b1de-7f79f0b0c7b5", () => OpenCaseEditPageUserTask.Property);
			MetaPathParameterValues.Add("d3b6514b-ad04-4867-bee1-53c358a32cf1", () => OpenCaseEditPageUserTask.Contract);
			MetaPathParameterValues.Add("f5163c93-3b37-4684-a212-0deb3ba60759", () => OpenCaseEditPageUserTask.Problem);
			MetaPathParameterValues.Add("fd066318-341b-4c3c-9d2f-3d23b8ba1814", () => OpenCaseEditPageUserTask.Change);
			MetaPathParameterValues.Add("f3ff095a-985c-4cdf-949b-8272814a1e93", () => OpenCaseEditPageUserTask.Release);
			MetaPathParameterValues.Add("81c9193f-dbbd-44e0-ba5f-8d126be20992", () => OpenCaseEditPageUserTask.Project);
			MetaPathParameterValues.Add("7856519d-7de0-4a62-9da7-af7bf749ed22", () => OpenCaseEditPageUserTask.ActivityPriority);
			MetaPathParameterValues.Add("0075d6b5-16d7-4f20-9394-6407922de606", () => OpenCaseEditPageUserTask.CreateActivity);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "queueItemId":
					if (!hasValueToRead) break;
					queueItemId = reader.GetValue<System.Guid>();
				break;
				case "entityRecordId":
					if (!hasValueToRead) break;
					entityRecordId = reader.GetValue<System.Guid>();
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
			var cloneItem = (SetCaseInWorkFromOperatorSingleWindowProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

