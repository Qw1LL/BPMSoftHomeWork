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

	#region Class: AnalyzeCaseSatisfactionLevelSchema

	/// <exclude/>
	public class AnalyzeCaseSatisfactionLevelSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public AnalyzeCaseSatisfactionLevelSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public AnalyzeCaseSatisfactionLevelSchema(AnalyzeCaseSatisfactionLevelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "AnalyzeCaseSatisfactionLevel";
			UId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12");
			CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
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
			RealUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12");
			Version = 0;
			PackageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCaseRecordIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7c806e5d-f304-455d-b2e4-9ed5a8c88f0c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"CaseRecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCaseRecordIdParameter());
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("643fc2b1-37e6-4c13-b874-541f74be69c6"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,77,115,211,48,16,253,43,29,159,171,142,63,100,199,206,141,134,192,244,0,205,144,78,47,184,7,89,94,59,26,100,203,35,41,133,144,201,127,103,101,39,38,101,60,37,112,225,130,79,242,155,183,111,223,126,237,61,46,153,49,31,89,3,222,220,187,93,125,88,171,202,222,188,19,210,130,126,175,213,182,243,174,61,3,90,48,41,190,67,57,224,203,82,216,183,204,50,12,216,231,63,227,115,111,158,79,41,228,222,117,238,9,11,141,65,6,6,164,81,82,102,21,13,137,31,100,9,161,73,92,17,54,163,1,225,80,150,105,22,85,89,72,103,3,115,90,122,161,154,142,105,24,50,244,226,85,255,124,216,117,142,24,32,192,123,138,48,170,61,130,145,179,96,150,45,43,36,148,248,111,245,22,16,178,90,52,88,9,60,136,6,86,76,99,38,167,163,28,132,164,138,73,227,88,18,42,187,252,214,105,48,70,168,246,117,107,114,219,180,231,92,12,135,241,247,104,198,239,29,58,230,138,217,77,47,112,135,166,14,189,199,55,117,173,161,102,86,60,159,91,248,2,187,158,119,89,239,48,160,196,249,60,50,185,133,179,156,47,235,88,176,206,14,229,12,233,145,160,69,189,185,176,210,177,91,191,43,54,68,176,59,145,47,82,156,244,31,38,8,62,59,96,208,56,61,115,239,243,157,185,255,218,130,94,243,13,52,108,232,216,211,13,162,191,0,163,254,124,63,227,169,159,64,92,146,42,242,41,161,49,190,138,16,40,201,160,140,89,202,211,180,242,249,225,105,240,33,76,39,217,238,113,76,183,96,6,174,62,1,87,186,188,234,167,230,62,215,92,85,11,206,228,125,7,26,135,215,55,207,159,94,186,23,219,234,202,210,74,217,193,236,216,20,151,165,207,127,26,60,135,106,22,101,65,64,88,154,134,132,70,52,38,69,20,135,36,140,138,148,82,44,39,13,10,52,131,215,234,58,183,86,91,205,143,23,98,134,51,253,171,3,252,7,135,245,39,215,50,185,175,151,108,224,255,237,2,183,44,135,31,227,196,130,50,254,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fb56437e-ba33-4a23-9d0c-ae27bb35a2a4"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("28d07f6e-0d89-4984-ae74-9e1d6c8a64b5"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c4dec099-47fa-4366-98a4-b699ffa357e6"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("72de3fe9-d5d9-40ab-85f1-88ea175b52be"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5e86df7f-bd13-4bc4-9cc7-8b7f60824845"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("247ba482-7f2c-4dc6-94f2-7174de79afd0"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,43,205,77,74,45,178,50,180,50,212,241,76,177,50,176,50,0,0,237,33,101,51,17,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("a7ec7ea4-ce5b-4f68-85b1-5bcb0f131a52"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("608cedf5-b8e9-4b65-b2eb-f05daae2899e"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				UId = new Guid("d10c7fb3-28cc-4700-a5b8-66c91209a9f8"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				UId = new Guid("fdea50bf-6a67-4306-9bf6-a560509191ee"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				UId = new Guid("85ce2111-939c-4c61-a6fc-25f3d846bef3"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				UId = new Guid("c8ea1ef0-089c-4d1e-ad79-bb1881d2a81b"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				UId = new Guid("6400198a-fd0f-42e8-aff8-558ad741e1f3"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				UId = new Guid("b853c17a-5aa9-4f6a-b6f5-dc1d14e76e99"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cbfaa20f-5593-406d-b8d0-2a98e6a2c065"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55ff5bcf-9e1c-431e-be5e-7d02bf259e96"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				UId = new Guid("73fb66b7-7813-445c-8f6a-f7fe4fa1ee4d"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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
				UId = new Guid("190f5682-64a8-4fc5-98eb-483231bb8736"),
				ContainerUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
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

		protected virtual void InitializeReadDataUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3dc139f3-bcc4-413e-937a-9d613d137381"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,19,49,20,253,149,104,214,117,53,15,207,43,59,40,1,117,1,173,72,213,77,211,197,181,125,39,181,152,151,108,79,33,68,249,119,174,103,218,144,162,8,2,27,36,196,172,60,71,231,94,159,251,56,222,6,178,6,107,63,64,131,193,60,120,125,253,126,217,85,238,252,173,174,29,154,119,166,27,250,224,44,176,104,52,212,250,43,170,9,95,40,237,222,128,3,10,216,174,190,199,175,130,249,234,88,134,85,112,182,10,180,195,198,18,131,2,42,153,0,47,66,100,97,148,35,227,169,82,172,72,227,148,197,74,96,88,134,188,144,74,77,204,227,169,47,186,166,7,131,211,13,99,242,106,60,222,108,122,79,140,8,144,35,69,219,174,125,2,19,47,193,46,90,16,53,250,228,206,12,72,144,51,186,161,74,240,70,55,120,13,134,110,242,121,58,15,17,169,130,218,122,86,141,149,91,124,233,13,90,171,187,246,231,210,234,161,105,15,185,20,142,251,223,39,49,225,168,208,51,175,193,61,140,9,46,73,212,110,212,248,106,189,54,184,6,167,31,15,37,124,194,205,200,59,173,119,20,160,104,62,183,80,15,120,112,231,203,58,46,160,119,83,57,211,245,68,48,122,253,112,98,165,251,110,253,170,216,152,192,254,153,124,82,198,163,250,227,140,192,71,15,76,57,158,143,171,224,238,210,94,125,110,209,44,229,3,54,48,117,236,254,156,208,31,128,69,141,13,182,110,190,85,2,68,38,82,96,50,42,21,245,48,163,30,170,60,100,34,41,98,200,10,94,22,85,180,163,128,189,160,249,22,114,148,57,2,103,18,83,193,120,149,21,212,118,17,177,84,72,17,86,81,18,65,26,251,144,69,235,180,219,76,91,224,163,34,80,128,192,18,158,113,198,21,34,19,130,87,76,230,144,38,41,79,67,80,249,238,126,42,87,219,190,134,205,237,190,170,143,8,106,38,193,226,204,119,98,70,126,50,214,205,188,139,102,93,53,163,22,15,181,211,237,122,70,123,84,163,244,131,60,95,58,112,131,29,211,249,121,82,146,68,242,34,131,82,178,56,45,98,198,243,44,102,165,164,95,158,36,80,69,85,89,240,200,239,157,255,252,122,116,107,45,161,190,234,209,208,250,141,227,15,143,219,230,133,223,252,96,76,215,185,169,221,251,177,94,144,246,3,69,207,11,44,162,52,41,195,188,98,40,67,160,78,22,5,43,85,138,12,211,82,160,76,18,196,178,34,73,244,234,248,186,151,221,96,228,147,211,237,244,220,252,209,67,242,23,30,136,223,113,253,81,223,157,226,164,255,46,129,127,199,37,187,96,247,13,31,162,246,247,142,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0c6de25d-2707-4643-a8ad-911d475e594c"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2c01b2a0-4d16-41e0-a641-3d9a2f02561b"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c0073aa2-5633-49ad-b4a3-2e43b3e5669f"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("02c2428c-c555-47dc-9e99-df353f553049"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cbd3780c-de4a-4e33-8ee8-b9febddbf1a5"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bd37a5c6-0d37-4523-b75c-cf34a74888cb"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,75,204,77,181,50,180,50,212,241,76,177,50,176,50,0,0,248,134,94,83,15,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c"),
				UId = new Guid("7092f775-9a72-4aaf-b608-e2668011359f"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("352856bf-54d3-414b-a777-6ea0f684dd68"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				UId = new Guid("38097a14-57ca-4d1c-a9b6-b83821594568"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				UId = new Guid("891c23be-079e-4dcf-afa7-6c04ead53b72"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				UId = new Guid("ca27a4b0-7cce-4840-9bca-800f545dca25"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				UId = new Guid("101a3fe4-83d5-45b2-94de-c891f8aae0b1"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				UId = new Guid("9b75f53d-4836-4518-9ff9-ac4c9e368e0f"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				ReferenceSchemaUId = new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c"),
				UId = new Guid("b0a000e3-e6fc-4cdd-b51c-12f6e2c080eb"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ae705119-6e00-4b54-afa3-f7214514ce18"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7b964786-d631-40c6-80bc-46e13902504e"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				UId = new Guid("b4f1ec14-f838-4cfa-a79c-534da992704d"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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
				UId = new Guid("47cdc713-9a4d-4a76-a520-6aa5b9cc1431"),
				ContainerUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
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

		protected virtual void InitializeReadDataUserTask3Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("42a0be64-dc23-4a7d-9fe3-953b6cefb20b"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,93,111,211,48,20,253,43,81,158,231,41,78,227,38,233,27,140,130,38,1,155,232,180,23,186,135,107,231,186,179,112,62,20,187,131,82,245,191,115,157,108,165,67,21,20,94,64,34,79,241,209,185,199,231,126,121,27,43,11,206,189,135,26,227,89,252,242,250,221,162,213,254,252,181,177,30,251,55,125,187,238,226,179,216,97,111,192,154,175,88,141,248,188,50,254,21,120,160,128,237,242,123,252,50,158,45,143,41,44,227,179,101,108,60,214,142,24,20,32,210,92,230,144,76,152,230,21,176,44,77,43,38,81,103,12,139,12,212,132,231,42,47,210,145,121,92,250,162,173,59,232,113,188,97,16,215,195,239,205,166,11,68,78,128,26,40,198,181,205,35,56,9,22,220,188,1,105,177,162,179,239,215,72,144,239,77,77,153,224,141,169,241,26,122,186,41,232,180,1,34,146,6,235,2,203,162,246,243,47,93,143,206,153,182,249,185,53,187,174,155,67,46,133,227,254,248,104,38,25,28,6,230,53,248,251,65,224,146,76,237,6,143,47,86,171,30,87,224,205,195,161,133,79,184,25,120,167,213,142,2,42,234,207,45,216,53,30,220,249,60,143,11,232,252,152,206,120,61,17,122,179,186,63,49,211,125,181,126,149,108,74,96,247,68,62,73,241,168,255,116,74,224,67,0,70,141,167,223,101,252,241,210,93,125,110,176,95,168,123,172,97,172,216,221,57,161,63,0,115,139,53,54,126,182,173,36,200,169,20,192,20,47,43,150,137,105,197,138,42,79,152,156,20,41,76,139,172,44,52,223,81,192,222,208,108,11,57,170,28,33,99,10,133,100,153,158,22,172,16,146,51,33,149,76,52,159,112,16,105,8,153,55,222,248,205,56,5,179,173,82,90,9,45,53,203,42,85,178,44,199,140,149,92,79,152,200,16,202,84,112,144,188,216,221,141,233,26,215,89,216,220,238,179,250,128,80,69,10,28,70,161,18,17,237,83,239,124,20,182,40,106,117,68,37,94,91,111,154,85,68,115,100,81,133,70,158,47,104,104,156,134,225,16,89,124,64,59,72,135,222,146,96,149,151,40,64,76,88,1,37,77,14,240,146,178,150,84,132,138,167,25,231,165,76,32,163,25,12,95,24,149,118,101,20,216,171,14,123,82,29,70,33,57,190,66,207,118,47,52,169,111,91,63,150,126,223,226,67,103,111,247,198,158,102,154,11,157,39,211,82,49,74,153,138,11,137,96,165,68,49,204,52,38,2,178,164,228,228,140,30,162,80,138,69,187,238,213,227,242,187,241,5,250,163,183,229,47,188,25,191,243,16,28,93,197,83,150,235,63,91,156,203,127,114,186,119,241,238,27,134,162,235,22,89,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d6167808-425a-4541-a89f-19118a685830"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("df97a40d-caba-46d0-ae3b-3ab77b3aa563"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b70e85c0-915b-4104-b121-b468de8a4637"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("223eb29e-364a-44cc-becc-69e01425be9c"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("656b1ea1-bac6-4518-8006-2d3d95f56bed"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ec808db1-3f0a-4038-a26b-446f2935c069"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,75,204,77,181,50,180,50,212,241,76,177,50,176,50,0,0,248,134,94,83,15,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				UId = new Guid("f5fc4e93-92c3-47f2-a1dc-a5ba89846ff7"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("92813432-e952-427c-b775-57f77d398b6d"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				UId = new Guid("2ef81675-328b-4e33-8a16-6a0df1006683"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				UId = new Guid("2f91fd7b-c25b-45ae-ac98-c772e1c88493"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				UId = new Guid("3a06c5c6-afac-4bd1-9115-551805b1f7bb"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				UId = new Guid("af6a486a-47e5-47a2-85fe-6687125e74bd"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				UId = new Guid("32bf5acf-9862-459e-a98e-55e6f938cfb2"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				ReferenceSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				UId = new Guid("fc23f180-56cd-4e39-a2cf-d3dad81c0dd1"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("be278a15-6327-41b0-a4a8-6c2d57c5a3cc"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9105f6d4-f8a4-4fc1-b550-632a6cf66f9a"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				UId = new Guid("b8a99524-586b-48f3-83bc-2ae529dfc080"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				UId = new Guid("56c369ec-c7b2-4e20-8d5a-ef3f21585a5d"),
				ContainerUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
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
				UId = new Guid("9368f221-436d-4df7-8b76-c98cf6d025a9"),
				ContainerUId = new Guid("2f66b44b-a3ad-4488-adac-18654ff735ea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				Value = @"117d32f9-8275-4534-8411-1c66115ce9cd",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("65d9b230-45b3-4daa-bb41-9096e6b07169"),
				ContainerUId = new Guid("2f66b44b-a3ad-4488-adac-18654ff735ea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a461b0ff-7cf6-4abc-aab6-8c25d8833b2b"),
				ContainerUId = new Guid("2f66b44b-a3ad-4488-adac-18654ff735ea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,211,64,16,253,43,149,207,221,202,113,252,153,27,132,128,122,128,70,164,234,165,238,97,188,59,78,86,216,94,107,119,93,8,81,254,59,179,118,98,82,20,65,64,66,224,211,250,233,205,155,55,95,59,143,87,96,204,7,168,209,155,121,175,151,239,87,170,180,55,111,101,101,81,191,211,170,107,189,107,207,160,150,80,201,175,40,6,124,33,164,125,3,22,40,96,151,127,143,207,189,89,126,78,33,247,174,115,79,90,172,13,49,40,32,9,130,73,144,101,1,227,209,84,176,112,34,4,43,178,40,97,62,135,48,141,227,4,11,94,12,204,243,210,115,85,183,160,113,200,208,139,151,253,243,126,219,58,226,132,0,222,83,164,81,205,1,156,58,11,102,209,64,81,161,160,127,171,59,36,200,106,89,83,37,120,47,107,92,130,166,76,78,71,57,136,72,37,84,198,177,42,44,237,226,75,171,209,24,169,154,159,91,171,186,186,57,229,82,56,142,191,7,51,126,239,208,49,151,96,55,189,192,45,153,218,247,30,95,173,215,26,215,96,229,243,169,133,79,184,237,121,151,245,142,2,4,205,231,1,170,14,79,114,190,172,99,14,173,29,202,25,210,19,65,203,245,230,194,74,199,110,253,170,216,128,192,246,72,190,72,241,172,255,32,38,240,217,1,131,198,241,153,123,143,183,230,238,115,131,122,197,55,88,195,208,177,167,27,66,127,0,70,253,217,46,225,169,31,99,36,88,57,245,67,22,70,244,42,2,12,89,134,34,130,148,167,105,233,243,253,211,224,67,154,182,130,237,195,152,110,14,6,175,62,34,87,90,92,245,83,115,159,107,174,90,75,14,213,93,139,154,134,215,55,207,63,191,116,47,182,213,149,165,149,178,131,217,177,41,46,75,159,255,56,248,176,16,101,16,251,5,43,202,34,99,161,224,62,3,17,150,204,15,69,153,248,147,40,3,30,145,25,186,86,215,185,149,234,52,63,92,136,25,206,244,143,14,240,31,28,214,239,92,203,217,125,189,100,3,197,255,176,93,127,115,115,246,222,254,27,24,29,255,227,218,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3ef5ba64-31d5-408a-91cd-c4b705177d41"),
				ContainerUId = new Guid("2f66b44b-a3ad-4488-adac-18654ff735ea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,110,219,48,12,253,21,67,237,49,12,44,75,178,44,31,215,118,64,128,118,43,150,173,151,38,7,90,162,90,3,142,93,216,74,135,46,200,191,79,113,146,182,233,122,155,14,50,68,243,61,146,79,79,27,118,30,94,158,136,149,236,203,237,205,188,243,97,122,209,245,52,189,237,59,75,195,48,189,238,44,54,245,31,172,26,186,197,30,87,20,168,191,195,102,77,195,117,61,132,73,242,30,196,38,236,252,121,252,199,202,251,13,155,5,90,253,154,185,200,172,10,159,87,89,81,129,173,20,129,204,85,6,133,205,57,56,157,21,38,195,170,146,190,136,96,219,53,235,85,123,67,1,111,49,60,178,114,195,70,182,72,128,154,163,67,66,16,50,151,32,29,17,236,64,96,53,42,161,164,74,209,105,182,157,176,193,62,210,10,199,162,111,96,206,181,19,153,55,80,100,90,129,84,66,66,33,57,7,110,243,156,115,101,201,88,183,3,31,242,223,128,247,103,247,179,225,251,239,150,250,249,200,91,122,108,6,90,78,99,244,67,224,170,161,21,181,161,220,112,109,169,160,194,131,73,139,2,36,250,28,208,43,3,90,27,46,188,113,84,164,98,27,1,175,90,150,27,175,188,149,100,4,152,204,10,144,218,103,128,220,89,64,85,97,97,10,153,123,175,119,144,171,54,212,225,229,98,212,168,220,40,110,40,151,100,193,138,212,131,172,162,54,85,234,52,228,196,141,72,141,202,101,74,219,229,217,114,55,152,171,135,167,6,95,238,254,157,239,7,161,75,6,12,245,224,209,134,186,107,147,134,158,169,73,28,6,156,126,173,251,33,36,117,188,197,164,243,73,79,195,186,9,117,251,144,196,107,106,104,204,158,206,3,134,245,176,175,242,116,98,143,247,117,54,139,189,199,22,172,92,124,238,178,195,119,175,234,169,207,78,45,182,96,147,5,155,119,235,222,238,216,68,60,92,190,27,110,44,48,166,124,56,30,61,21,35,237,186,105,14,145,203,56,229,49,241,24,238,92,237,107,114,179,118,126,180,210,200,146,30,22,124,178,29,215,190,183,255,129,221,96,139,15,212,127,139,227,191,245,254,218,229,207,40,225,145,184,202,140,74,53,247,160,9,13,72,202,227,139,114,28,193,112,83,121,161,163,221,125,54,162,127,144,167,158,90,75,167,141,25,227,133,74,185,128,188,210,24,77,231,114,168,164,76,129,132,231,152,86,104,12,183,7,252,48,170,189,123,204,135,190,118,82,109,217,118,187,220,254,5,171,74,167,225,60,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7302a841-bd54-4b8e-bf45-25d59c0ffa77"),
				ContainerUId = new Guid("2f66b44b-a3ad-4488-adac-18654ff735ea"),
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

		protected virtual void InitializeReadDataUserTask4Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d51b136d-f674-45ae-991e-74dc6a36e5a5"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,203,142,211,64,16,252,21,203,231,117,228,183,157,220,32,4,180,7,216,136,172,246,178,222,67,123,220,118,70,140,31,154,25,47,132,200,255,78,143,157,132,44,138,32,32,33,14,248,100,151,170,187,171,31,229,189,205,4,40,245,1,106,180,23,246,235,245,251,77,91,234,217,91,46,52,202,119,178,237,59,251,198,86,40,57,8,254,21,139,9,95,21,92,191,1,13,20,176,207,190,199,103,246,34,187,148,33,179,111,50,155,107,172,21,49,40,32,154,207,253,212,203,61,7,61,136,157,48,118,61,7,226,57,58,105,17,21,94,18,68,12,146,100,98,94,78,189,108,235,14,36,78,21,198,228,229,248,122,191,235,12,209,35,128,141,20,174,218,230,0,6,70,130,90,53,144,11,44,232,91,203,30,9,210,146,215,212,9,222,243,26,215,32,169,146,201,211,26,136,72,37,8,101,88,2,75,189,250,210,73,84,138,183,205,207,165,137,190,110,206,185,20,142,167,207,131,24,119,84,104,152,107,208,219,49,193,45,137,26,70,141,175,170,74,98,5,154,63,159,75,248,132,187,145,119,221,236,40,160,160,253,60,128,232,241,172,230,203,62,150,208,233,169,157,169,60,17,36,175,182,87,118,122,154,214,175,154,245,9,236,142,228,171,50,94,212,239,199,4,62,27,96,202,113,124,205,236,199,91,117,247,185,65,185,97,91,172,97,154,216,211,140,208,31,128,149,192,26,27,189,216,23,57,228,113,30,129,195,188,121,225,132,81,92,208,248,18,215,201,131,212,135,56,13,231,105,233,13,20,112,18,180,216,67,130,44,65,8,29,134,81,238,132,101,156,58,105,68,91,136,114,150,187,165,23,120,16,249,38,100,213,104,174,119,211,21,80,20,186,24,210,74,28,22,206,35,138,194,196,129,128,74,6,144,39,126,146,162,23,123,201,240,52,181,203,85,39,96,247,112,234,234,35,66,97,49,80,104,153,73,88,228,39,169,180,101,92,100,181,165,69,35,238,133,230,77,101,209,29,9,100,102,145,179,241,134,204,99,86,221,86,156,129,184,235,80,210,41,141,171,116,47,91,224,133,119,204,144,101,219,234,105,116,167,21,45,73,199,40,243,120,134,84,136,254,11,70,217,166,237,37,59,120,81,77,63,132,63,178,250,63,176,240,239,248,242,162,51,174,185,245,255,233,142,7,243,252,165,227,27,236,225,27,105,13,236,191,171,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fe0fa648-3fc3-4ce1-a8d3-1681f04a67c9"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ae404d44-60d7-4e4b-8282-762b27d3a152"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8763f1ba-63c6-4753-87a2-dbaeb9ea40d3"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9eda2b32-157f-4e17-b87c-cc0782b8e875"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d2adb4a4-eb38-4950-aadd-fdeebf093883"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				UId = new Guid("6c320b14-8f29-402a-a272-3d4d451107ba"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,43,205,77,74,45,178,50,180,50,4,0,62,85,105,155,10,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("b3c152f3-8f5d-4ccd-a444-d697a2992b1a"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("919f3607-18a5-44b4-b8c5-a553b21c63f7"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				UId = new Guid("275b1604-78cd-4f80-ad1a-dbb6afbae187"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				UId = new Guid("58b416b7-18b4-43de-b90e-b775fc705598"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				UId = new Guid("18226361-e716-427e-8881-44a4fbfcbcbc"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				UId = new Guid("acdae03e-04e7-470b-acab-80f8b02cde3d"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				UId = new Guid("98406230-ae2f-4d18-934d-4512830c3860"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f")
			};
			parametrizedElement.Parameters.Add(canReadUncommitedDataParameter);
			var resultEntityCollectionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4ed4d571-44c8-4a27-a65a-4131b67102cd"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b38a94a0-f6e4-4feb-8786-12e8b069d09b"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a4fde4e6-b89d-4d7a-9c00-a5b453b8f484"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				UId = new Guid("28a5fc14-9a30-49d1-a16b-10c46525c62f"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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
				UId = new Guid("81c601c6-152c-477f-9379-ba093a3b2641"),
				ContainerUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
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

		protected virtual void InitializeChangeDataUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("838069b1-290a-4dfe-8a76-789d0b22ee56"),
				ContainerUId = new Guid("76d999c8-bdbc-4338-8a0c-62bc13b6b90a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				Value = @"117d32f9-8275-4534-8411-1c66115ce9cd",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9aae8482-6a87-492c-a2eb-c2cc69f1a33a"),
				ContainerUId = new Guid("76d999c8-bdbc-4338-8a0c-62bc13b6b90a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7f1e55bc-3c69-4e8d-ab13-4c60e7f1c2b5"),
				ContainerUId = new Guid("76d999c8-bdbc-4338-8a0c-62bc13b6b90a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,193,110,219,48,12,253,149,194,231,186,112,99,59,113,114,91,179,108,232,97,107,176,20,189,212,61,48,50,237,8,147,45,67,146,187,101,65,254,125,148,148,120,233,96,172,217,128,97,51,124,144,30,30,31,31,41,114,23,48,1,90,127,132,26,131,89,112,179,252,176,146,165,185,122,199,133,65,245,94,201,174,13,46,3,141,138,131,224,223,176,240,248,162,224,230,45,24,160,128,93,254,35,62,15,102,249,144,66,30,92,230,1,55,88,107,98,80,64,2,105,4,215,172,12,167,209,26,194,36,158,176,112,26,103,69,136,227,56,30,199,41,253,147,169,103,14,75,207,101,221,130,66,159,193,137,151,238,120,191,109,45,241,154,0,230,40,92,203,230,0,198,214,130,94,52,176,22,88,208,221,168,14,9,50,138,215,84,9,222,243,26,151,160,40,147,213,145,22,34,82,9,66,91,150,192,210,44,190,182,10,181,230,178,249,181,53,209,213,205,41,151,194,177,191,30,204,68,206,161,101,46,193,108,156,192,45,153,218,59,143,111,170,74,97,5,134,63,159,90,248,140,91,199,59,175,119,20,80,208,251,60,128,232,240,36,231,203,58,230,208,26,95,142,79,79,4,197,171,205,153,149,246,221,122,173,216,17,129,237,145,124,150,226,160,255,209,152,192,103,11,120,141,227,49,15,30,111,245,221,151,6,213,138,109,176,6,223,177,167,43,66,127,2,122,253,217,110,194,178,104,140,105,17,150,113,148,132,73,74,167,245,8,147,112,138,69,10,25,203,178,50,98,251,39,239,131,235,86,192,246,161,79,55,7,141,23,159,144,73,85,92,184,87,179,159,109,174,172,56,3,113,215,162,162,199,115,205,139,134,135,238,197,180,218,178,148,148,198,155,237,155,98,179,184,252,199,135,167,68,180,137,182,43,43,217,41,118,152,126,237,87,240,143,150,235,31,44,205,239,108,194,224,44,158,51,93,197,255,48,57,127,115,42,246,193,254,59,201,35,212,64,182,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("75fd7f6c-28fc-4c7c-bf17-b30ef4fedf91"),
				ContainerUId = new Guid("76d999c8-bdbc-4338-8a0c-62bc13b6b90a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,147,75,111,163,48,20,133,255,10,114,187,140,35,12,6,76,150,109,55,145,154,81,84,58,217,148,46,46,246,117,139,196,35,226,81,41,19,241,223,199,56,208,36,85,86,51,94,128,108,252,29,159,123,15,62,146,251,238,176,71,178,34,15,219,77,82,235,110,249,88,55,184,220,54,181,196,182,93,62,215,18,138,252,15,100,5,110,161,129,18,59,108,118,80,244,216,62,231,109,183,112,46,33,178,32,247,95,246,27,89,189,29,201,186,195,242,247,90,25,101,161,133,43,125,17,81,197,49,163,156,137,140,10,205,67,202,164,200,84,16,113,29,135,158,129,101,93,244,101,181,193,14,182,208,125,146,213,145,88,53,35,128,204,99,49,211,154,122,130,49,202,125,87,81,64,9,52,2,206,253,0,121,198,178,152,12,11,210,202,79,44,193,30,122,134,25,139,148,239,233,152,10,47,10,40,15,124,78,5,55,50,76,134,33,99,129,196,88,170,17,158,246,159,193,183,187,228,208,238,160,201,199,234,151,143,125,211,96,213,61,65,135,175,121,137,119,239,35,163,242,118,95,192,97,119,19,53,245,59,95,63,112,103,100,29,168,148,51,10,157,68,246,87,141,189,148,57,166,167,116,82,178,74,111,231,51,189,19,91,248,117,66,215,225,164,100,145,146,164,238,27,57,170,249,102,242,116,225,221,30,96,183,252,152,206,105,152,149,170,47,138,105,197,120,135,121,227,188,92,171,92,231,168,214,85,50,135,96,85,220,105,208,27,143,121,156,188,253,15,182,129,10,62,176,249,101,202,63,123,255,118,249,106,90,56,11,43,143,97,140,154,83,233,134,156,114,151,121,52,243,68,72,53,48,16,44,98,202,252,82,150,126,65,141,38,49,137,255,104,236,5,91,219,237,241,26,76,190,198,86,13,100,24,222,135,191,91,223,216,11,118,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e3332d10-e53e-403f-baee-fcf6672932b8"),
				ContainerUId = new Guid("76d999c8-bdbc-4338-8a0c-62bc13b6b90a"),
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

		protected virtual void InitializeReadDataUserTask5Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8a822ce2-db65-4f4c-9559-c00347db1b23"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,75,143,211,48,16,254,43,85,206,235,170,73,243,236,13,74,65,123,128,173,232,106,47,219,61,76,236,73,107,225,60,100,59,11,165,202,127,103,156,180,165,139,42,40,72,136,3,62,217,159,190,153,249,230,229,189,199,21,24,243,1,74,244,102,222,235,229,251,85,93,216,241,91,169,44,234,119,186,110,27,239,198,51,168,37,40,249,21,197,128,47,132,180,111,192,2,25,236,215,223,237,215,222,108,125,201,195,218,187,89,123,210,98,105,136,65,6,133,72,68,144,139,140,229,28,124,22,70,105,192,82,46,4,3,223,207,18,17,5,137,207,167,3,243,178,235,121,93,54,160,113,136,208,59,47,250,235,253,174,113,68,159,0,222,83,164,169,171,3,56,117,18,204,162,130,92,161,160,183,213,45,18,100,181,44,41,19,188,151,37,46,65,83,36,231,167,118,16,145,10,80,198,177,20,22,118,241,165,209,104,140,172,171,159,75,83,109,89,157,115,201,28,79,207,131,152,73,175,208,49,151,96,183,189,131,91,18,213,245,26,95,109,54,26,55,96,229,243,185,132,79,184,235,121,215,213,142,12,4,245,231,1,84,139,103,49,95,230,49,135,198,14,233,12,225,137,160,229,102,123,101,166,167,106,253,42,217,128,192,230,72,190,202,227,69,253,65,76,224,179,3,6,31,199,235,218,123,188,53,119,159,43,212,43,190,197,18,134,138,61,141,9,253,1,88,40,44,177,178,179,61,135,56,159,112,31,89,81,68,41,11,39,116,203,114,1,44,21,73,44,226,52,142,82,63,238,200,224,36,104,182,207,167,220,143,130,98,202,210,34,18,44,228,156,42,30,134,33,19,113,150,64,144,101,65,238,131,51,89,84,86,218,221,48,5,179,61,36,62,8,64,96,211,48,14,89,40,16,89,158,135,5,227,9,68,211,40,140,38,32,146,238,105,72,87,154,70,193,238,225,148,213,71,4,49,226,96,112,100,44,216,214,208,66,105,99,71,110,141,70,117,49,162,26,183,202,202,106,51,162,65,82,200,93,39,199,171,158,73,131,228,142,235,119,189,145,28,212,93,131,154,230,169,239,231,228,242,30,188,88,32,87,105,93,215,118,168,223,169,79,115,18,115,140,112,54,145,20,142,190,8,215,174,85,221,106,126,88,75,51,252,13,127,180,245,255,96,155,127,103,69,47,46,201,53,99,255,63,141,116,231,206,95,29,193,206,235,190,1,34,94,155,219,188,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("94072bca-6162-4e8e-b862-b76f105bc46a"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5c651444-a144-4931-821b-e26e9fb71f60"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d6933145-11a6-41e0-a083-8e3d0f5cb15f"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("41bdacb0-38ba-4c89-b2bd-9e26c44910c6"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0f225841-4a24-46aa-9ab5-c60099fe3a63"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				UId = new Guid("e30c8bb4-f01c-440f-8a45-b98eb8058e08"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,75,204,77,181,50,180,50,4,0,127,229,4,95,8,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c"),
				UId = new Guid("82d3dd51-cb6e-431e-b725-0622ebd71499"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1397425e-4ae0-4803-9260-930a308717ad"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				UId = new Guid("3bbdd8db-b7fb-45ce-a565-73afafc90561"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				UId = new Guid("1a775799-e9f7-4e06-9c16-7b002d6e9c48"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				UId = new Guid("a39c131b-b8b8-409b-b619-3e350352fc5e"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				UId = new Guid("2f2d12aa-73bf-4cc5-9ed8-61b85e547204"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				UId = new Guid("2d5e1b39-c1bd-463e-aa87-b6982b2c0502"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f")
			};
			parametrizedElement.Parameters.Add(canReadUncommitedDataParameter);
			var resultEntityCollectionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ecdc24d5-dc69-4e45-9cdc-bbbc660c2d5e"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("93186690-48ea-44b2-a2cf-18064e1d9d6d"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dc93e612-6e5f-4209-89e2-bf47d63b7bf2"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				UId = new Guid("18603ef7-a04b-45c0-bec2-7f829fb55c3e"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
				UId = new Guid("55394453-1ffd-4d1e-831b-6a853258bfab"),
				ContainerUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
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
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask readdatausertask3 = CreateReadDataUserTask3UserTask();
			FlowElements.Add(readdatausertask3);
			ProcessSchemaUserTask changedatausertask1 = CreateChangeDataUserTask1UserTask();
			FlowElements.Add(changedatausertask1);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaExclusiveGateway exclusivegateway3 = CreateExclusiveGateway3ExclusiveGateway();
			FlowElements.Add(exclusivegateway3);
			ProcessSchemaUserTask readdatausertask4 = CreateReadDataUserTask4UserTask();
			FlowElements.Add(readdatausertask4);
			ProcessSchemaUserTask changedatausertask2 = CreateChangeDataUserTask2UserTask();
			FlowElements.Add(changedatausertask2);
			ProcessSchemaUserTask readdatausertask5 = CreateReadDataUserTask5UserTask();
			FlowElements.Add(readdatausertask5);
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("8c28c284-86be-46b8-b2e6-f127f4feec81"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("83737d09-45d0-40fd-9630-7d18b9e17546"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a2bcfc44-4bb9-471f-82b7-6a0b3a316268"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("738ffaeb-4a93-4ede-99d2-a18ebefe310d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a2bcfc44-4bb9-471f-82b7-6a0b3a316268"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3658f89e-eda6-4d65-b32c-1a1ea21763fd"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(417, 261));
			schemaFlow.PolylinePointPositions.Add(new Point(1406, 261));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("e7bc3b23-71ca-41a9-a7d7-73a1b7c38399"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{9b9bf88c-1372-47f8-9d44-ebeaec7db7c0}].[Parameter:{7092f775-9a72-4aaf-b608-e2668011359f}].[EntityColumn:{98771b3f-7dbe-4b12-a017-0ab8d406a02a}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a2bcfc44-4bb9-471f-82b7-6a0b3a316268"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(417, 148));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("34efd614-e31d-4208-b42f-1c9207feaceb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8593432b-dbe4-49d2-ab4e-15dbe6b69a1c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("97d8cfff-02dd-47e0-ab08-ab86e99a853e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2f66b44b-a3ad-4488-adac-18654ff735ea"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("6d531419-b788-4cf5-9023-81bd006b0421"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8593432b-dbe4-49d2-ab4e-15dbe6b69a1c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2f66b44b-a3ad-4488-adac-18654ff735ea"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow2",
				UId = new Guid("5a9762ab-9fb2-4607-92d8-972d548892b2"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{17ce8e8f-9088-4af6-af59-77913f9de803}].[Parameter:{f5fc4e93-92c3-47f2-a1dc-a5ba89846ff7}].[EntityColumn:{519e64ec-c30f-4bea-b0d7-6e193095640e}]#] == Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8593432b-dbe4-49d2-ab4e-15dbe6b69a1c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3658f89e-eda6-4d65-b32c-1a1ea21763fd"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(601, 91));
			schemaFlow.PolylinePointPositions.Add(new Point(1406, 91));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("b5c8bbf2-28c0-4bcd-811a-ea6ebe0336f6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6f8502a0-3594-4b8f-977d-f540357b0266"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow3",
				UId = new Guid("4c1ae41c-a832-4454-9f59-95e8303e57f8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5689cf75-4c45-4caa-af3e-b87939b74ebc"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3658f89e-eda6-4d65-b32c-1a1ea21763fd"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1092, 217));
			schemaFlow.PolylinePointPositions.Add(new Point(1406, 217));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("b12f7964-a59e-4b0d-b921-f24173ada1db"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow3",
				UId = new Guid("43d68cc9-41d1-4662-a26b-62bb02a1f91a"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{de73a61b-399c-4391-9e63-7eff8e68c02f}].[Parameter:{82d3dd51-cb6e-431e-b725-0622ebd71499}].[EntityColumn:{b78647f6-76db-4d25-b665-00fce475324e}]#] == true",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5689cf75-4c45-4caa-af3e-b87939b74ebc"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("76d999c8-bdbc-4338-8a0c-62bc13b6b90a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("fa228622-278b-4c12-b91f-ed2309e9c835"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("76d999c8-bdbc-4338-8a0c-62bc13b6b90a"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3658f89e-eda6-4d65-b32c-1a1ea21763fd"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1331, 148));
			schemaFlow.PolylinePointPositions.Add(new Point(1331, 173));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("838a62a1-26d2-4951-932f-58f4cb859319"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5689cf75-4c45-4caa-af3e-b87939b74ebc"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("033cef62-157b-4804-9ded-0bba90f7da42"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("033cef62-157b-4804-9ded-0bba90f7da42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("3658f89e-eda6-4d65-b32c-1a1ea21763fd"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"Terminate1",
				Position = new Point(1393, 160),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"ReadDataUserTask1",
				Position = new Point(137, 176),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"ReadDataUserTask2",
				Position = new Point(260, 176),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("a2bcfc44-4bb9-471f-82b7-6a0b3a316268"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"ExclusiveGateway1",
				Position = new Point(390, 176),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask3UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"ReadDataUserTask3",
				Position = new Point(467, 121),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask3Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("2f66b44b-a3ad-4488-adac-18654ff735ea"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"ChangeDataUserTask1",
				Position = new Point(680, 121),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("8593432b-dbe4-49d2-ab4e-15dbe6b69a1c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"ExclusiveGateway2",
				Position = new Point(574, 121),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("6f8502a0-3594-4b8f-977d-f540357b0266"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"StartEvent1",
				Position = new Point(56, 190),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway3ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("5689cf75-4c45-4caa-af3e-b87939b74ebc"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"ExclusiveGateway3",
				Position = new Point(1065, 121),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask4UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"ReadDataUserTask4",
				Position = new Point(810, 121),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask4Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("76d999c8-bdbc-4338-8a0c-62bc13b6b90a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"ChangeDataUserTask2",
				Position = new Point(1200, 121),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask5UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("73d4e26a-203e-4287-9a4d-dfc1a61e4f3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"),
				Name = @"ReadDataUserTask5",
				Position = new Point(926, 121),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask5Parameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new AnalyzeCaseSatisfactionLevel(userConnection);
		}

		public override object Clone() {
			return new AnalyzeCaseSatisfactionLevelSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("01896e87-3e42-46cf-8f01-9781cacfce12"));
		}

		#endregion

	}

	#endregion

	#region Class: AnalyzeCaseSatisfactionLevel

	/// <exclude/>
	public class AnalyzeCaseSatisfactionLevel : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, AnalyzeCaseSatisfactionLevel process)
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, AnalyzeCaseSatisfactionLevel process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("dbab6b5a-c19d-456d-8d70-b382a68498f1");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,77,115,211,48,16,253,43,29,159,171,142,63,100,199,206,141,134,192,244,0,205,144,78,47,184,7,89,94,59,26,100,203,35,41,133,144,201,127,103,101,39,38,101,60,37,112,225,130,79,242,155,183,111,223,126,237,61,46,153,49,31,89,3,222,220,187,93,125,88,171,202,222,188,19,210,130,126,175,213,182,243,174,61,3,90,48,41,190,67,57,224,203,82,216,183,204,50,12,216,231,63,227,115,111,158,79,41,228,222,117,238,9,11,141,65,6,6,164,81,82,102,21,13,137,31,100,9,161,73,92,17,54,163,1,225,80,150,105,22,85,89,72,103,3,115,90,122,161,154,142,105,24,50,244,226,85,255,124,216,117,142,24,32,192,123,138,48,170,61,130,145,179,96,150,45,43,36,148,248,111,245,22,16,178,90,52,88,9,60,136,6,86,76,99,38,167,163,28,132,164,138,73,227,88,18,42,187,252,214,105,48,70,168,246,117,107,114,219,180,231,92,12,135,241,247,104,198,239,29,58,230,138,217,77,47,112,135,166,14,189,199,55,117,173,161,102,86,60,159,91,248,2,187,158,119,89,239,48,160,196,249,60,50,185,133,179,156,47,235,88,176,206,14,229,12,233,145,160,69,189,185,176,210,177,91,191,43,54,68,176,59,145,47,82,156,244,31,38,8,62,59,96,208,56,61,115,239,243,157,185,255,218,130,94,243,13,52,108,232,216,211,13,162,191,0,163,254,124,63,227,169,159,64,92,146,42,242,41,161,49,190,138,16,40,201,160,140,89,202,211,180,242,249,225,105,240,33,76,39,217,238,113,76,183,96,6,174,62,1,87,186,188,234,167,230,62,215,92,85,11,206,228,125,7,26,135,215,55,207,159,94,186,23,219,234,202,210,74,217,193,236,216,20,151,165,207,127,26,60,135,106,22,101,65,64,88,154,134,132,70,52,38,69,20,135,36,140,138,148,82,44,39,13,10,52,131,215,234,58,183,86,91,205,143,23,98,134,51,253,171,3,252,7,135,245,39,215,50,185,175,151,108,224,255,237,2,183,44,135,31,227,196,130,50,254,5,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,43,205,77,74,45,178,50,180,50,212,241,76,177,50,176,50,0,0,237,33,101,51,17,0,0,0 })));
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

			#endregion

		}

		#endregion

		#region Class: ReadDataUserTask2FlowElement

		/// <exclude/>
		public class ReadDataUserTask2FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask2FlowElement(UserConnection userConnection, AnalyzeCaseSatisfactionLevel process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("9b9bf88c-1372-47f8-9d44-ebeaec7db7c0");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,19,49,20,253,149,104,214,117,53,15,207,43,59,40,1,117,1,173,72,213,77,211,197,181,125,39,181,152,151,108,79,33,68,249,119,174,103,218,144,162,8,2,27,36,196,172,60,71,231,94,159,251,56,222,6,178,6,107,63,64,131,193,60,120,125,253,126,217,85,238,252,173,174,29,154,119,166,27,250,224,44,176,104,52,212,250,43,170,9,95,40,237,222,128,3,10,216,174,190,199,175,130,249,234,88,134,85,112,182,10,180,195,198,18,131,2,42,153,0,47,66,100,97,148,35,227,169,82,172,72,227,148,197,74,96,88,134,188,144,74,77,204,227,169,47,186,166,7,131,211,13,99,242,106,60,222,108,122,79,140,8,144,35,69,219,174,125,2,19,47,193,46,90,16,53,250,228,206,12,72,144,51,186,161,74,240,70,55,120,13,134,110,242,121,58,15,17,169,130,218,122,86,141,149,91,124,233,13,90,171,187,246,231,210,234,161,105,15,185,20,142,251,223,39,49,225,168,208,51,175,193,61,140,9,46,73,212,110,212,248,106,189,54,184,6,167,31,15,37,124,194,205,200,59,173,119,20,160,104,62,183,80,15,120,112,231,203,58,46,160,119,83,57,211,245,68,48,122,253,112,98,165,251,110,253,170,216,152,192,254,153,124,82,198,163,250,227,140,192,71,15,76,57,158,143,171,224,238,210,94,125,110,209,44,229,3,54,48,117,236,254,156,208,31,128,69,141,13,182,110,190,85,2,68,38,82,96,50,42,21,245,48,163,30,170,60,100,34,41,98,200,10,94,22,85,180,163,128,189,160,249,22,114,148,57,2,103,18,83,193,120,149,21,212,118,17,177,84,72,17,86,81,18,65,26,251,144,69,235,180,219,76,91,224,163,34,80,128,192,18,158,113,198,21,34,19,130,87,76,230,144,38,41,79,67,80,249,238,126,42,87,219,190,134,205,237,190,170,143,8,106,38,193,226,204,119,98,70,126,50,214,205,188,139,102,93,53,163,22,15,181,211,237,122,70,123,84,163,244,131,60,95,58,112,131,29,211,249,121,82,146,68,242,34,131,82,178,56,45,98,198,243,44,102,165,164,95,158,36,80,69,85,89,240,200,239,157,255,252,122,116,107,45,161,190,234,209,208,250,141,227,15,143,219,230,133,223,252,96,76,215,185,169,221,251,177,94,144,246,3,69,207,11,44,162,52,41,195,188,98,40,67,160,78,22,5,43,85,138,12,211,82,160,76,18,196,178,34,73,244,234,248,186,151,221,96,228,147,211,237,244,220,252,209,67,242,23,30,136,223,113,253,81,223,157,226,164,255,46,129,127,199,37,187,96,247,13,31,162,246,247,142,7,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,75,204,77,181,50,180,50,212,241,76,177,50,176,50,0,0,248,134,94,83,15,0,0,0 })));
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
								new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c"));
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

		#region Class: ReadDataUserTask3FlowElement

		/// <exclude/>
		public class ReadDataUserTask3FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask3FlowElement(UserConnection userConnection, AnalyzeCaseSatisfactionLevel process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask3";
				IsLogging = true;
				SchemaElementUId = new Guid("17ce8e8f-9088-4af6-af59-77913f9de803");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,93,111,211,48,20,253,43,81,158,231,41,78,227,38,233,27,140,130,38,1,155,232,180,23,186,135,107,231,186,179,112,62,20,187,131,82,245,191,115,157,108,165,67,21,20,94,64,34,79,241,209,185,199,231,126,121,27,43,11,206,189,135,26,227,89,252,242,250,221,162,213,254,252,181,177,30,251,55,125,187,238,226,179,216,97,111,192,154,175,88,141,248,188,50,254,21,120,160,128,237,242,123,252,50,158,45,143,41,44,227,179,101,108,60,214,142,24,20,32,210,92,230,144,76,152,230,21,176,44,77,43,38,81,103,12,139,12,212,132,231,42,47,210,145,121,92,250,162,173,59,232,113,188,97,16,215,195,239,205,166,11,68,78,128,26,40,198,181,205,35,56,9,22,220,188,1,105,177,162,179,239,215,72,144,239,77,77,153,224,141,169,241,26,122,186,41,232,180,1,34,146,6,235,2,203,162,246,243,47,93,143,206,153,182,249,185,53,187,174,155,67,46,133,227,254,248,104,38,25,28,6,230,53,248,251,65,224,146,76,237,6,143,47,86,171,30,87,224,205,195,161,133,79,184,25,120,167,213,142,2,42,234,207,45,216,53,30,220,249,60,143,11,232,252,152,206,120,61,17,122,179,186,63,49,211,125,181,126,149,108,74,96,247,68,62,73,241,168,255,116,74,224,67,0,70,141,167,223,101,252,241,210,93,125,110,176,95,168,123,172,97,172,216,221,57,161,63,0,115,139,53,54,126,182,173,36,200,169,20,192,20,47,43,150,137,105,197,138,42,79,152,156,20,41,76,139,172,44,52,223,81,192,222,208,108,11,57,170,28,33,99,10,133,100,153,158,22,172,16,146,51,33,149,76,52,159,112,16,105,8,153,55,222,248,205,56,5,179,173,82,90,9,45,53,203,42,85,178,44,199,140,149,92,79,152,200,16,202,84,112,144,188,216,221,141,233,26,215,89,216,220,238,179,250,128,80,69,10,28,70,161,18,17,237,83,239,124,20,182,40,106,117,68,37,94,91,111,154,85,68,115,100,81,133,70,158,47,104,104,156,134,225,16,89,124,64,59,72,135,222,146,96,149,151,40,64,76,88,1,37,77,14,240,146,178,150,84,132,138,167,25,231,165,76,32,163,25,12,95,24,149,118,101,20,216,171,14,123,82,29,70,33,57,190,66,207,118,47,52,169,111,91,63,150,126,223,226,67,103,111,247,198,158,102,154,11,157,39,211,82,49,74,153,138,11,137,96,165,68,49,204,52,38,2,178,164,228,228,140,30,162,80,138,69,187,238,213,227,242,187,241,5,250,163,183,229,47,188,25,191,243,16,28,93,197,83,150,235,63,91,156,203,127,114,186,119,241,238,27,134,162,235,22,89,7,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,75,204,77,181,50,180,50,212,241,76,177,50,176,50,0,0,248,134,94,83,15,0,0,0 })));
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
								new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"));
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

			public ChangeDataUserTask1FlowElement(UserConnection userConnection, AnalyzeCaseSatisfactionLevel process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("2f66b44b-a3ad-4488-adac-18654ff735ea");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Status = () => (Guid)(((process.ReadDataUserTask3.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask3.ResultEntity.Schema.Columns.GetByName("Status").ColumnValueName) ? process.ReadDataUserTask3.ResultEntity.GetTypedColumnValue<Guid>("StatusId") : Guid.Empty)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Status", () => _recordColumnValues_Status.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Status;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,211,64,16,253,43,149,207,221,202,113,252,153,27,132,128,122,128,70,164,234,165,238,97,188,59,78,86,216,94,107,119,93,8,81,254,59,179,118,98,82,20,65,64,66,224,211,250,233,205,155,55,95,59,143,87,96,204,7,168,209,155,121,175,151,239,87,170,180,55,111,101,101,81,191,211,170,107,189,107,207,160,150,80,201,175,40,6,124,33,164,125,3,22,40,96,151,127,143,207,189,89,126,78,33,247,174,115,79,90,172,13,49,40,32,9,130,73,144,101,1,227,209,84,176,112,34,4,43,178,40,97,62,135,48,141,227,4,11,94,12,204,243,210,115,85,183,160,113,200,208,139,151,253,243,126,219,58,226,132,0,222,83,164,81,205,1,156,58,11,102,209,64,81,161,160,127,171,59,36,200,106,89,83,37,120,47,107,92,130,166,76,78,71,57,136,72,37,84,198,177,42,44,237,226,75,171,209,24,169,154,159,91,171,186,186,57,229,82,56,142,191,7,51,126,239,208,49,151,96,55,189,192,45,153,218,247,30,95,173,215,26,215,96,229,243,169,133,79,184,237,121,151,245,142,2,4,205,231,1,170,14,79,114,190,172,99,14,173,29,202,25,210,19,65,203,245,230,194,74,199,110,253,170,216,128,192,246,72,190,72,241,172,255,32,38,240,217,1,131,198,241,153,123,143,183,230,238,115,131,122,197,55,88,195,208,177,167,27,66,127,0,70,253,217,46,225,169,31,99,36,88,57,245,67,22,70,244,42,2,12,89,134,34,130,148,167,105,233,243,253,211,224,67,154,182,130,237,195,152,110,14,6,175,62,34,87,90,92,245,83,115,159,107,174,90,75,14,213,93,139,154,134,215,55,207,63,191,116,47,182,213,149,165,149,178,131,217,177,41,46,75,159,255,56,248,176,16,101,16,251,5,43,202,34,99,161,224,62,3,17,150,204,15,69,153,248,147,40,3,30,145,25,186,86,215,185,149,234,52,63,92,136,25,206,244,143,14,240,31,28,214,239,92,203,217,125,189,100,3,197,255,176,93,127,115,115,246,222,254,27,24,29,255,227,218,5,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,110,219,48,12,253,21,67,237,49,12,44,75,178,44,31,215,118,64,128,118,43,150,173,151,38,7,90,162,90,3,142,93,216,74,135,46,200,191,79,113,146,182,233,122,155,14,50,68,243,61,146,79,79,27,118,30,94,158,136,149,236,203,237,205,188,243,97,122,209,245,52,189,237,59,75,195,48,189,238,44,54,245,31,172,26,186,197,30,87,20,168,191,195,102,77,195,117,61,132,73,242,30,196,38,236,252,121,252,199,202,251,13,155,5,90,253,154,185,200,172,10,159,87,89,81,129,173,20,129,204,85,6,133,205,57,56,157,21,38,195,170,146,190,136,96,219,53,235,85,123,67,1,111,49,60,178,114,195,70,182,72,128,154,163,67,66,16,50,151,32,29,17,236,64,96,53,42,161,164,74,209,105,182,157,176,193,62,210,10,199,162,111,96,206,181,19,153,55,80,100,90,129,84,66,66,33,57,7,110,243,156,115,101,201,88,183,3,31,242,223,128,247,103,247,179,225,251,239,150,250,249,200,91,122,108,6,90,78,99,244,67,224,170,161,21,181,161,220,112,109,169,160,194,131,73,139,2,36,250,28,208,43,3,90,27,46,188,113,84,164,98,27,1,175,90,150,27,175,188,149,100,4,152,204,10,144,218,103,128,220,89,64,85,97,97,10,153,123,175,119,144,171,54,212,225,229,98,212,168,220,40,110,40,151,100,193,138,212,131,172,162,54,85,234,52,228,196,141,72,141,202,101,74,219,229,217,114,55,152,171,135,167,6,95,238,254,157,239,7,161,75,6,12,245,224,209,134,186,107,147,134,158,169,73,28,6,156,126,173,251,33,36,117,188,197,164,243,73,79,195,186,9,117,251,144,196,107,106,104,204,158,206,3,134,245,176,175,242,116,98,143,247,117,54,139,189,199,22,172,92,124,238,178,195,119,175,234,169,207,78,45,182,96,147,5,155,119,235,222,238,216,68,60,92,190,27,110,44,48,166,124,56,30,61,21,35,237,186,105,14,145,203,56,229,49,241,24,238,92,237,107,114,179,118,126,180,210,200,146,30,22,124,178,29,215,190,183,255,129,221,96,139,15,212,127,139,227,191,245,254,218,229,207,40,225,145,184,202,140,74,53,247,160,9,13,72,202,227,139,114,28,193,112,83,121,161,163,221,125,54,162,127,144,167,158,90,75,167,141,25,227,133,74,185,128,188,210,24,77,231,114,168,164,76,129,132,231,152,86,104,12,183,7,252,48,170,189,123,204,135,190,118,82,109,217,118,187,220,254,5,171,74,167,225,60,4,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "01896e873e4246cf8f019781cacfce12",
							"BaseElements.ChangeDataUserTask1.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
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

		#region Class: ReadDataUserTask4FlowElement

		/// <exclude/>
		public class ReadDataUserTask4FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask4FlowElement(UserConnection userConnection, AnalyzeCaseSatisfactionLevel process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask4";
				IsLogging = true;
				SchemaElementUId = new Guid("ca6b0c1e-ff58-401e-9bda-8d76d6865816");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,203,142,211,64,16,252,21,203,231,117,228,183,157,220,32,4,180,7,216,136,172,246,178,222,67,123,220,118,70,140,31,154,25,47,132,200,255,78,143,157,132,44,138,32,32,33,14,248,100,151,170,187,171,31,229,189,205,4,40,245,1,106,180,23,246,235,245,251,77,91,234,217,91,46,52,202,119,178,237,59,251,198,86,40,57,8,254,21,139,9,95,21,92,191,1,13,20,176,207,190,199,103,246,34,187,148,33,179,111,50,155,107,172,21,49,40,32,154,207,253,212,203,61,7,61,136,157,48,118,61,7,226,57,58,105,17,21,94,18,68,12,146,100,98,94,78,189,108,235,14,36,78,21,198,228,229,248,122,191,235,12,209,35,128,141,20,174,218,230,0,6,70,130,90,53,144,11,44,232,91,203,30,9,210,146,215,212,9,222,243,26,215,32,169,146,201,211,26,136,72,37,8,101,88,2,75,189,250,210,73,84,138,183,205,207,165,137,190,110,206,185,20,142,167,207,131,24,119,84,104,152,107,208,219,49,193,45,137,26,70,141,175,170,74,98,5,154,63,159,75,248,132,187,145,119,221,236,40,160,160,253,60,128,232,241,172,230,203,62,150,208,233,169,157,169,60,17,36,175,182,87,118,122,154,214,175,154,245,9,236,142,228,171,50,94,212,239,199,4,62,27,96,202,113,124,205,236,199,91,117,247,185,65,185,97,91,172,97,154,216,211,140,208,31,128,149,192,26,27,189,216,23,57,228,113,30,129,195,188,121,225,132,81,92,208,248,18,215,201,131,212,135,56,13,231,105,233,13,20,112,18,180,216,67,130,44,65,8,29,134,81,238,132,101,156,58,105,68,91,136,114,150,187,165,23,120,16,249,38,100,213,104,174,119,211,21,80,20,186,24,210,74,28,22,206,35,138,194,196,129,128,74,6,144,39,126,146,162,23,123,201,240,52,181,203,85,39,96,247,112,234,234,35,66,97,49,80,104,153,73,88,228,39,169,180,101,92,100,181,165,69,35,238,133,230,77,101,209,29,9,100,102,145,179,241,134,204,99,86,221,86,156,129,184,235,80,210,41,141,171,116,47,91,224,133,119,204,144,101,219,234,105,116,167,21,45,73,199,40,243,120,134,84,136,254,11,70,217,166,237,37,59,120,81,77,63,132,63,178,250,63,176,240,239,248,242,162,51,174,185,245,255,233,142,7,243,252,165,227,27,236,225,27,105,13,236,191,171,6,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,43,205,77,74,45,178,50,180,50,4,0,62,85,105,155,10,0,0,0 })));
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

			#endregion

		}

		#endregion

		#region Class: ChangeDataUserTask2FlowElement

		/// <exclude/>
		public class ChangeDataUserTask2FlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataUserTask2FlowElement(UserConnection userConnection, AnalyzeCaseSatisfactionLevel process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("76d999c8-bdbc-4338-8a0c-62bc13b6b90a");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_ClosureDate = () => (DateTime)(((DateTime)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentDateTime")));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_ClosureDate", () => _recordColumnValues_ClosureDate.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<DateTime> _recordColumnValues_ClosureDate;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,193,110,219,48,12,253,149,194,231,186,112,99,59,113,114,91,179,108,232,97,107,176,20,189,212,61,48,50,237,8,147,45,67,146,187,101,65,254,125,148,148,120,233,96,172,217,128,97,51,124,144,30,30,31,31,41,114,23,48,1,90,127,132,26,131,89,112,179,252,176,146,165,185,122,199,133,65,245,94,201,174,13,46,3,141,138,131,224,223,176,240,248,162,224,230,45,24,160,128,93,254,35,62,15,102,249,144,66,30,92,230,1,55,88,107,98,80,64,2,105,4,215,172,12,167,209,26,194,36,158,176,112,26,103,69,136,227,56,30,199,41,253,147,169,103,14,75,207,101,221,130,66,159,193,137,151,238,120,191,109,45,241,154,0,230,40,92,203,230,0,198,214,130,94,52,176,22,88,208,221,168,14,9,50,138,215,84,9,222,243,26,151,160,40,147,213,145,22,34,82,9,66,91,150,192,210,44,190,182,10,181,230,178,249,181,53,209,213,205,41,151,194,177,191,30,204,68,206,161,101,46,193,108,156,192,45,153,218,59,143,111,170,74,97,5,134,63,159,90,248,140,91,199,59,175,119,20,80,208,251,60,128,232,240,36,231,203,58,230,208,26,95,142,79,79,4,197,171,205,153,149,246,221,122,173,216,17,129,237,145,124,150,226,160,255,209,152,192,103,11,120,141,227,49,15,30,111,245,221,151,6,213,138,109,176,6,223,177,167,43,66,127,2,122,253,217,110,194,178,104,140,105,17,150,113,148,132,73,74,167,245,8,147,112,138,69,10,25,203,178,50,98,251,39,239,131,235,86,192,246,161,79,55,7,141,23,159,144,73,85,92,184,87,179,159,109,174,172,56,3,113,215,162,162,199,115,205,139,134,135,238,197,180,218,178,148,148,198,155,237,155,98,179,184,252,199,135,167,68,180,137,182,43,43,217,41,118,152,126,237,87,240,143,150,235,31,44,205,239,108,194,224,44,158,51,93,197,255,48,57,127,115,42,246,193,254,59,201,35,212,64,182,5,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,147,75,111,163,48,20,133,255,10,114,187,140,35,12,6,76,150,109,55,145,154,81,84,58,217,148,46,46,246,117,139,196,35,226,81,41,19,241,223,199,56,208,36,85,86,51,94,128,108,252,29,159,123,15,62,146,251,238,176,71,178,34,15,219,77,82,235,110,249,88,55,184,220,54,181,196,182,93,62,215,18,138,252,15,100,5,110,161,129,18,59,108,118,80,244,216,62,231,109,183,112,46,33,178,32,247,95,246,27,89,189,29,201,186,195,242,247,90,25,101,161,133,43,125,17,81,197,49,163,156,137,140,10,205,67,202,164,200,84,16,113,29,135,158,129,101,93,244,101,181,193,14,182,208,125,146,213,145,88,53,35,128,204,99,49,211,154,122,130,49,202,125,87,81,64,9,52,2,206,253,0,121,198,178,152,12,11,210,202,79,44,193,30,122,134,25,139,148,239,233,152,10,47,10,40,15,124,78,5,55,50,76,134,33,99,129,196,88,170,17,158,246,159,193,183,187,228,208,238,160,201,199,234,151,143,125,211,96,213,61,65,135,175,121,137,119,239,35,163,242,118,95,192,97,119,19,53,245,59,95,63,112,103,100,29,168,148,51,10,157,68,246,87,141,189,148,57,166,167,116,82,178,74,111,231,51,189,19,91,248,117,66,215,225,164,100,145,146,164,238,27,57,170,249,102,242,116,225,221,30,96,183,252,152,206,105,152,149,170,47,138,105,197,120,135,121,227,188,92,171,92,231,168,214,85,50,135,96,85,220,105,208,27,143,121,156,188,253,15,182,129,10,62,176,249,101,202,63,123,255,118,249,106,90,56,11,43,143,97,140,154,83,233,134,156,114,151,121,52,243,68,72,53,48,16,44,98,202,252,82,150,126,65,141,38,49,137,255,104,236,5,91,219,237,241,26,76,190,198,86,13,100,24,222,135,191,91,223,216,11,118,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "01896e873e4246cf8f019781cacfce12",
							"BaseElements.ChangeDataUserTask2.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
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

		#region Class: ReadDataUserTask5FlowElement

		/// <exclude/>
		public class ReadDataUserTask5FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask5FlowElement(UserConnection userConnection, AnalyzeCaseSatisfactionLevel process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask5";
				IsLogging = true;
				SchemaElementUId = new Guid("de73a61b-399c-4391-9e63-7eff8e68c02f");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,75,143,211,48,16,254,43,85,206,235,170,73,243,236,13,74,65,123,128,173,232,106,47,219,61,76,236,73,107,225,60,100,59,11,165,202,127,103,156,180,165,139,42,40,72,136,3,62,217,159,190,153,249,230,229,189,199,21,24,243,1,74,244,102,222,235,229,251,85,93,216,241,91,169,44,234,119,186,110,27,239,198,51,168,37,40,249,21,197,128,47,132,180,111,192,2,25,236,215,223,237,215,222,108,125,201,195,218,187,89,123,210,98,105,136,65,6,133,72,68,144,139,140,229,28,124,22,70,105,192,82,46,4,3,223,207,18,17,5,137,207,167,3,243,178,235,121,93,54,160,113,136,208,59,47,250,235,253,174,113,68,159,0,222,83,164,169,171,3,56,117,18,204,162,130,92,161,160,183,213,45,18,100,181,44,41,19,188,151,37,46,65,83,36,231,167,118,16,145,10,80,198,177,20,22,118,241,165,209,104,140,172,171,159,75,83,109,89,157,115,201,28,79,207,131,152,73,175,208,49,151,96,183,189,131,91,18,213,245,26,95,109,54,26,55,96,229,243,185,132,79,184,235,121,215,213,142,12,4,245,231,1,84,139,103,49,95,230,49,135,198,14,233,12,225,137,160,229,102,123,101,166,167,106,253,42,217,128,192,230,72,190,202,227,69,253,65,76,224,179,3,6,31,199,235,218,123,188,53,119,159,43,212,43,190,197,18,134,138,61,141,9,253,1,88,40,44,177,178,179,61,135,56,159,112,31,89,81,68,41,11,39,116,203,114,1,44,21,73,44,226,52,142,82,63,238,200,224,36,104,182,207,167,220,143,130,98,202,210,34,18,44,228,156,42,30,134,33,19,113,150,64,144,101,65,238,131,51,89,84,86,218,221,48,5,179,61,36,62,8,64,96,211,48,14,89,40,16,89,158,135,5,227,9,68,211,40,140,38,32,146,238,105,72,87,154,70,193,238,225,148,213,71,4,49,226,96,112,100,44,216,214,208,66,105,99,71,110,141,70,117,49,162,26,183,202,202,106,51,162,65,82,200,93,39,199,171,158,73,131,228,142,235,119,189,145,28,212,93,131,154,230,169,239,231,228,242,30,188,88,32,87,105,93,215,118,168,223,169,79,115,18,115,140,112,54,145,20,142,190,8,215,174,85,221,106,126,88,75,51,252,13,127,180,245,255,96,155,127,103,69,47,46,201,53,99,255,63,141,116,231,206,95,29,193,206,235,190,1,34,94,155,219,188,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,75,204,77,181,50,180,50,4,0,127,229,4,95,8,0,0,0 })));
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
								new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c")),
							UseAdminRights = false
						});
				}
				set {
					_resultEntity = value;
				}
			}

			#endregion

		}

		#endregion

		public AnalyzeCaseSatisfactionLevel(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AnalyzeCaseSatisfactionLevel";
			SchemaUId = new Guid("01896e87-3e42-46cf-8f01-9781cacfce12");
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
				return new Guid("01896e87-3e42-46cf-8f01-9781cacfce12");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: AnalyzeCaseSatisfactionLevel, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: AnalyzeCaseSatisfactionLevel, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid CaseRecordId {
			get;
			set;
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
					SchemaElementUId = new Guid("3658f89e-eda6-4d65-b32c-1a1ea21763fd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ReadDataUserTask1FlowElement _readDataUserTask1;
		public ReadDataUserTask1FlowElement ReadDataUserTask1 {
			get {
				return _readDataUserTask1 ?? (_readDataUserTask1 = new ReadDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataUserTask2FlowElement _readDataUserTask2;
		public ReadDataUserTask2FlowElement ReadDataUserTask2 {
			get {
				return _readDataUserTask2 ?? (_readDataUserTask2 = new ReadDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("a2bcfc44-4bb9-471f-82b7-6a0b3a316268"),
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

		private ReadDataUserTask3FlowElement _readDataUserTask3;
		public ReadDataUserTask3FlowElement ReadDataUserTask3 {
			get {
				return _readDataUserTask3 ?? (_readDataUserTask3 = new ReadDataUserTask3FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeDataUserTask1FlowElement _changeDataUserTask1;
		public ChangeDataUserTask1FlowElement ChangeDataUserTask1 {
			get {
				return _changeDataUserTask1 ?? (_changeDataUserTask1 = new ChangeDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("8593432b-dbe4-49d2-ab4e-15dbe6b69a1c"),
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

		private ProcessFlowElement _startEvent1;
		public ProcessFlowElement StartEvent1 {
			get {
				return _startEvent1 ?? (_startEvent1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartEvent1",
					SchemaElementUId = new Guid("6f8502a0-3594-4b8f-977d-f540357b0266"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("5689cf75-4c45-4caa-af3e-b87939b74ebc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway3.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ReadDataUserTask4FlowElement _readDataUserTask4;
		public ReadDataUserTask4FlowElement ReadDataUserTask4 {
			get {
				return _readDataUserTask4 ?? (_readDataUserTask4 = new ReadDataUserTask4FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeDataUserTask2FlowElement _changeDataUserTask2;
		public ChangeDataUserTask2FlowElement ChangeDataUserTask2 {
			get {
				return _changeDataUserTask2 ?? (_changeDataUserTask2 = new ChangeDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataUserTask5FlowElement _readDataUserTask5;
		public ReadDataUserTask5FlowElement ReadDataUserTask5 {
			get {
				return _readDataUserTask5 ?? (_readDataUserTask5 = new ReadDataUserTask5FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("e7bc3b23-71ca-41a9-a7d7-73a1b7c38399"),
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
					SchemaElementUId = new Guid("5a9762ab-9fb2-4607-92d8-972d548892b2"),
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
					SchemaElementUId = new Guid("43d68cc9-41d1-4662-a26b-62bb02a1f91a"),
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
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ReadDataUserTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask3 };
			FlowElements[ChangeDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask1 };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[ExclusiveGateway3.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway3 };
			FlowElements[ReadDataUserTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask4 };
			FlowElements[ChangeDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask2 };
			FlowElements[ReadDataUserTask5.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask5 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Terminate1":
						CompleteProcess();
						break;
					case "ReadDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask3", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ReadDataUserTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "ChangeDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask4", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalSequenceFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask1", e.Context.SenderName));
						break;
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						break;
					case "ExclusiveGateway3":
						if (ConditionalSequenceFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ReadDataUserTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask5", e.Context.SenderName));
						break;
					case "ChangeDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ReadDataUserTask5":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway3", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("IsResolved").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<bool>("IsResolved") : false)));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow1", "((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName(\"IsResolved\").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<bool>(\"IsResolved\") : false))", result);
			return result;
		}

		private bool ConditionalSequenceFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask3.ResultEntity.IsColumnValueLoaded(ReadDataUserTask3.ResultEntity.Schema.Columns.GetByName("Status").ColumnValueName) ? ReadDataUserTask3.ResultEntity.GetTypedColumnValue<Guid>("StatusId") : Guid.Empty)) == Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalSequenceFlow2", "((ReadDataUserTask3.ResultEntity.IsColumnValueLoaded(ReadDataUserTask3.ResultEntity.Schema.Columns.GetByName(\"Status\").ColumnValueName) ? ReadDataUserTask3.ResultEntity.GetTypedColumnValue<Guid>(\"StatusId\") : Guid.Empty)) == Guid.Empty", result);
			return result;
		}

		private bool ConditionalSequenceFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask5.ResultEntity.IsColumnValueLoaded(ReadDataUserTask5.ResultEntity.Schema.Columns.GetByName("IsFinal").ColumnValueName) ? ReadDataUserTask5.ResultEntity.GetTypedColumnValue<bool>("IsFinal") : false)) == true);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway3", "ConditionalSequenceFlow3", "((ReadDataUserTask5.ResultEntity.IsColumnValueLoaded(ReadDataUserTask5.ResultEntity.Schema.Columns.GetByName(\"IsFinal\").ColumnValueName) ? ReadDataUserTask5.ResultEntity.GetTypedColumnValue<bool>(\"IsFinal\") : false)) == true", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CaseRecordId")) {
				writer.WriteValue("CaseRecordId", CaseRecordId, Guid.Empty);
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
			MetaPathParameterValues.Add("7c806e5d-f304-455d-b2e4-9ed5a8c88f0c", () => CaseRecordId);
			MetaPathParameterValues.Add("643fc2b1-37e6-4c13-b874-541f74be69c6", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("fb56437e-ba33-4a23-9d0c-ae27bb35a2a4", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("28d07f6e-0d89-4984-ae74-9e1d6c8a64b5", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("c4dec099-47fa-4366-98a4-b699ffa357e6", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("72de3fe9-d5d9-40ab-85f1-88ea175b52be", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("5e86df7f-bd13-4bc4-9cc7-8b7f60824845", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("247ba482-7f2c-4dc6-94f2-7174de79afd0", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("a7ec7ea4-ce5b-4f68-85b1-5bcb0f131a52", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("608cedf5-b8e9-4b65-b2eb-f05daae2899e", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("d10c7fb3-28cc-4700-a5b8-66c91209a9f8", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("fdea50bf-6a67-4306-9bf6-a560509191ee", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("85ce2111-939c-4c61-a6fc-25f3d846bef3", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("c8ea1ef0-089c-4d1e-ad79-bb1881d2a81b", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("6400198a-fd0f-42e8-aff8-558ad741e1f3", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("b853c17a-5aa9-4f6a-b6f5-dc1d14e76e99", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("cbfaa20f-5593-406d-b8d0-2a98e6a2c065", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("55ff5bcf-9e1c-431e-be5e-7d02bf259e96", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("73fb66b7-7813-445c-8f6a-f7fe4fa1ee4d", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("190f5682-64a8-4fc5-98eb-483231bb8736", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("3dc139f3-bcc4-413e-937a-9d613d137381", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("0c6de25d-2707-4643-a8ad-911d475e594c", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("2c01b2a0-4d16-41e0-a641-3d9a2f02561b", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("c0073aa2-5633-49ad-b4a3-2e43b3e5669f", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("02c2428c-c555-47dc-9e99-df353f553049", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("cbd3780c-de4a-4e33-8ee8-b9febddbf1a5", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("bd37a5c6-0d37-4523-b75c-cf34a74888cb", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("7092f775-9a72-4aaf-b608-e2668011359f", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("352856bf-54d3-414b-a777-6ea0f684dd68", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("38097a14-57ca-4d1c-a9b6-b83821594568", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("891c23be-079e-4dcf-afa7-6c04ead53b72", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("ca27a4b0-7cce-4840-9bca-800f545dca25", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("101a3fe4-83d5-45b2-94de-c891f8aae0b1", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("9b75f53d-4836-4518-9ff9-ac4c9e368e0f", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("b0a000e3-e6fc-4cdd-b51c-12f6e2c080eb", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("ae705119-6e00-4b54-afa3-f7214514ce18", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("7b964786-d631-40c6-80bc-46e13902504e", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("b4f1ec14-f838-4cfa-a79c-534da992704d", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("47cdc713-9a4d-4a76-a520-6aa5b9cc1431", () => ReadDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("42a0be64-dc23-4a7d-9fe3-953b6cefb20b", () => ReadDataUserTask3.DataSourceFilters);
			MetaPathParameterValues.Add("d6167808-425a-4541-a89f-19118a685830", () => ReadDataUserTask3.ResultType);
			MetaPathParameterValues.Add("df97a40d-caba-46d0-ae3b-3ab77b3aa563", () => ReadDataUserTask3.ReadSomeTopRecords);
			MetaPathParameterValues.Add("b70e85c0-915b-4104-b121-b468de8a4637", () => ReadDataUserTask3.NumberOfRecords);
			MetaPathParameterValues.Add("223eb29e-364a-44cc-becc-69e01425be9c", () => ReadDataUserTask3.FunctionType);
			MetaPathParameterValues.Add("656b1ea1-bac6-4518-8006-2d3d95f56bed", () => ReadDataUserTask3.AggregationColumnName);
			MetaPathParameterValues.Add("ec808db1-3f0a-4038-a26b-446f2935c069", () => ReadDataUserTask3.OrderInfo);
			MetaPathParameterValues.Add("f5fc4e93-92c3-47f2-a1dc-a5ba89846ff7", () => ReadDataUserTask3.ResultEntity);
			MetaPathParameterValues.Add("92813432-e952-427c-b775-57f77d398b6d", () => ReadDataUserTask3.ResultCount);
			MetaPathParameterValues.Add("2ef81675-328b-4e33-8a16-6a0df1006683", () => ReadDataUserTask3.ResultIntegerFunction);
			MetaPathParameterValues.Add("2f91fd7b-c25b-45ae-ac98-c772e1c88493", () => ReadDataUserTask3.ResultFloatFunction);
			MetaPathParameterValues.Add("3a06c5c6-afac-4bd1-9115-551805b1f7bb", () => ReadDataUserTask3.ResultDateTimeFunction);
			MetaPathParameterValues.Add("af6a486a-47e5-47a2-85fe-6687125e74bd", () => ReadDataUserTask3.ResultRowsCount);
			MetaPathParameterValues.Add("32bf5acf-9862-459e-a98e-55e6f938cfb2", () => ReadDataUserTask3.CanReadUncommitedData);
			MetaPathParameterValues.Add("fc23f180-56cd-4e39-a2cf-d3dad81c0dd1", () => ReadDataUserTask3.ResultEntityCollection);
			MetaPathParameterValues.Add("be278a15-6327-41b0-a4a8-6c2d57c5a3cc", () => ReadDataUserTask3.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("9105f6d4-f8a4-4fc1-b550-632a6cf66f9a", () => ReadDataUserTask3.IgnoreDisplayValues);
			MetaPathParameterValues.Add("b8a99524-586b-48f3-83bc-2ae529dfc080", () => ReadDataUserTask3.ResultCompositeObjectList);
			MetaPathParameterValues.Add("56c369ec-c7b2-4e20-8d5a-ef3f21585a5d", () => ReadDataUserTask3.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("9368f221-436d-4df7-8b76-c98cf6d025a9", () => ChangeDataUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("65d9b230-45b3-4daa-bb41-9096e6b07169", () => ChangeDataUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("a461b0ff-7cf6-4abc-aab6-8c25d8833b2b", () => ChangeDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("3ef5ba64-31d5-408a-91cd-c4b705177d41", () => ChangeDataUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("7302a841-bd54-4b8e-bf45-25d59c0ffa77", () => ChangeDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("d51b136d-f674-45ae-991e-74dc6a36e5a5", () => ReadDataUserTask4.DataSourceFilters);
			MetaPathParameterValues.Add("fe0fa648-3fc3-4ce1-a8d3-1681f04a67c9", () => ReadDataUserTask4.ResultType);
			MetaPathParameterValues.Add("ae404d44-60d7-4e4b-8282-762b27d3a152", () => ReadDataUserTask4.ReadSomeTopRecords);
			MetaPathParameterValues.Add("8763f1ba-63c6-4753-87a2-dbaeb9ea40d3", () => ReadDataUserTask4.NumberOfRecords);
			MetaPathParameterValues.Add("9eda2b32-157f-4e17-b87c-cc0782b8e875", () => ReadDataUserTask4.FunctionType);
			MetaPathParameterValues.Add("d2adb4a4-eb38-4950-aadd-fdeebf093883", () => ReadDataUserTask4.AggregationColumnName);
			MetaPathParameterValues.Add("6c320b14-8f29-402a-a272-3d4d451107ba", () => ReadDataUserTask4.OrderInfo);
			MetaPathParameterValues.Add("b3c152f3-8f5d-4ccd-a444-d697a2992b1a", () => ReadDataUserTask4.ResultEntity);
			MetaPathParameterValues.Add("919f3607-18a5-44b4-b8c5-a553b21c63f7", () => ReadDataUserTask4.ResultCount);
			MetaPathParameterValues.Add("275b1604-78cd-4f80-ad1a-dbb6afbae187", () => ReadDataUserTask4.ResultIntegerFunction);
			MetaPathParameterValues.Add("58b416b7-18b4-43de-b90e-b775fc705598", () => ReadDataUserTask4.ResultFloatFunction);
			MetaPathParameterValues.Add("18226361-e716-427e-8881-44a4fbfcbcbc", () => ReadDataUserTask4.ResultDateTimeFunction);
			MetaPathParameterValues.Add("acdae03e-04e7-470b-acab-80f8b02cde3d", () => ReadDataUserTask4.ResultRowsCount);
			MetaPathParameterValues.Add("98406230-ae2f-4d18-934d-4512830c3860", () => ReadDataUserTask4.CanReadUncommitedData);
			MetaPathParameterValues.Add("4ed4d571-44c8-4a27-a65a-4131b67102cd", () => ReadDataUserTask4.ResultEntityCollection);
			MetaPathParameterValues.Add("b38a94a0-f6e4-4feb-8786-12e8b069d09b", () => ReadDataUserTask4.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("a4fde4e6-b89d-4d7a-9c00-a5b453b8f484", () => ReadDataUserTask4.IgnoreDisplayValues);
			MetaPathParameterValues.Add("28a5fc14-9a30-49d1-a16b-10c46525c62f", () => ReadDataUserTask4.ResultCompositeObjectList);
			MetaPathParameterValues.Add("81c601c6-152c-477f-9379-ba093a3b2641", () => ReadDataUserTask4.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("838069b1-290a-4dfe-8a76-789d0b22ee56", () => ChangeDataUserTask2.EntitySchemaUId);
			MetaPathParameterValues.Add("9aae8482-6a87-492c-a2eb-c2cc69f1a33a", () => ChangeDataUserTask2.IsMatchConditions);
			MetaPathParameterValues.Add("7f1e55bc-3c69-4e8d-ab13-4c60e7f1c2b5", () => ChangeDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("75fd7f6c-28fc-4c7c-bf17-b30ef4fedf91", () => ChangeDataUserTask2.RecordColumnValues);
			MetaPathParameterValues.Add("e3332d10-e53e-403f-baee-fcf6672932b8", () => ChangeDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("8a822ce2-db65-4f4c-9559-c00347db1b23", () => ReadDataUserTask5.DataSourceFilters);
			MetaPathParameterValues.Add("94072bca-6162-4e8e-b862-b76f105bc46a", () => ReadDataUserTask5.ResultType);
			MetaPathParameterValues.Add("5c651444-a144-4931-821b-e26e9fb71f60", () => ReadDataUserTask5.ReadSomeTopRecords);
			MetaPathParameterValues.Add("d6933145-11a6-41e0-a083-8e3d0f5cb15f", () => ReadDataUserTask5.NumberOfRecords);
			MetaPathParameterValues.Add("41bdacb0-38ba-4c89-b2bd-9e26c44910c6", () => ReadDataUserTask5.FunctionType);
			MetaPathParameterValues.Add("0f225841-4a24-46aa-9ab5-c60099fe3a63", () => ReadDataUserTask5.AggregationColumnName);
			MetaPathParameterValues.Add("e30c8bb4-f01c-440f-8a45-b98eb8058e08", () => ReadDataUserTask5.OrderInfo);
			MetaPathParameterValues.Add("82d3dd51-cb6e-431e-b725-0622ebd71499", () => ReadDataUserTask5.ResultEntity);
			MetaPathParameterValues.Add("1397425e-4ae0-4803-9260-930a308717ad", () => ReadDataUserTask5.ResultCount);
			MetaPathParameterValues.Add("3bbdd8db-b7fb-45ce-a565-73afafc90561", () => ReadDataUserTask5.ResultIntegerFunction);
			MetaPathParameterValues.Add("1a775799-e9f7-4e06-9c16-7b002d6e9c48", () => ReadDataUserTask5.ResultFloatFunction);
			MetaPathParameterValues.Add("a39c131b-b8b8-409b-b619-3e350352fc5e", () => ReadDataUserTask5.ResultDateTimeFunction);
			MetaPathParameterValues.Add("2f2d12aa-73bf-4cc5-9ed8-61b85e547204", () => ReadDataUserTask5.ResultRowsCount);
			MetaPathParameterValues.Add("2d5e1b39-c1bd-463e-aa87-b6982b2c0502", () => ReadDataUserTask5.CanReadUncommitedData);
			MetaPathParameterValues.Add("ecdc24d5-dc69-4e45-9cdc-bbbc660c2d5e", () => ReadDataUserTask5.ResultEntityCollection);
			MetaPathParameterValues.Add("93186690-48ea-44b2-a2cf-18064e1d9d6d", () => ReadDataUserTask5.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("dc93e612-6e5f-4209-89e2-bf47d63b7bf2", () => ReadDataUserTask5.IgnoreDisplayValues);
			MetaPathParameterValues.Add("18603ef7-a04b-45c0-bec2-7f829fb55c3e", () => ReadDataUserTask5.ResultCompositeObjectList);
			MetaPathParameterValues.Add("55394453-1ffd-4d1e-831b-6a853258bfab", () => ReadDataUserTask5.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CaseRecordId":
					if (!hasValueToRead) break;
					CaseRecordId = reader.GetValue<System.Guid>();
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
			var cloneItem = (AnalyzeCaseSatisfactionLevel)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

