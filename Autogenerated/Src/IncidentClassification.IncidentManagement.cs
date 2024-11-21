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

	#region Class: IncidentClassificationSchema

	/// <exclude/>
	public class IncidentClassificationSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public IncidentClassificationSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public IncidentClassificationSchema(IncidentClassificationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "IncidentClassification";
			UId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b");
			CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab");
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
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b");
			Version = 0;
			PackageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateIncidentIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d383a904-01bc-48db-aa27-ea4bb618f782"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				Name = @"IncidentId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateIncidentIdParameter());
		}

		protected virtual void InitializeSearchForParentParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var incidentIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("abceed8c-c3dd-4674-9bce-5ea3599b7797"),
				ContainerUId = new Guid("7a8a973b-3cac-4678-96a2-ebf2179751e0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"IncidentId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			incidentIdParameter.SourceValue = new ProcessSchemaParameterValue(incidentIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d383a904-01bc-48db-aa27-ea4bb618f782}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b")
			};
			parametrizedElement.Parameters.Add(incidentIdParameter);
			var isCaseCollectionAnyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("175e0f29-9e7d-46d8-add2-688541e40b0b"),
				ContainerUId = new Guid("7a8a973b-3cac-4678-96a2-ebf2179751e0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"IsCaseCollectionAny",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isCaseCollectionAnyParameter.SourceValue = new ProcessSchemaParameterValue(isCaseCollectionAnyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(isCaseCollectionAnyParameter);
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d9cd6ff7-8c44-4ad3-9dc6-8537b799e76a"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,205,106,220,48,20,133,95,165,104,209,149,85,44,201,63,178,187,28,166,101,54,105,160,105,41,36,67,184,150,174,19,129,127,38,182,76,19,204,64,201,162,155,190,67,158,33,41,45,180,208,188,131,231,141,42,219,153,22,178,40,221,116,81,48,226,234,218,231,232,187,7,185,63,53,237,11,83,88,108,210,28,138,22,189,110,165,83,194,36,151,34,140,145,230,60,140,104,224,115,160,32,124,69,147,32,207,16,65,9,206,99,226,85,80,98,74,102,245,82,27,75,60,99,177,108,211,227,254,183,169,109,58,244,78,243,105,243,90,157,99,9,111,166,3,88,172,5,207,19,42,121,28,210,32,20,1,149,1,99,148,169,40,98,44,84,152,40,77,102,22,20,190,208,32,114,154,229,34,166,1,32,167,210,81,80,149,133,49,72,237,180,35,75,129,185,93,94,110,26,108,91,83,87,105,143,191,234,163,171,141,163,156,207,94,212,69,87,86,196,43,209,194,33,216,243,148,0,250,24,132,10,168,10,18,7,146,99,236,38,77,52,21,144,197,60,150,200,34,230,220,21,108,236,104,75,86,142,74,131,133,183,80,116,56,57,247,198,49,114,225,51,25,70,78,203,132,162,129,224,62,149,145,140,105,174,163,60,65,17,37,73,166,247,121,189,236,140,171,77,123,208,149,216,24,245,16,59,186,252,234,38,237,85,93,217,166,46,70,235,131,233,243,35,188,180,115,184,15,175,222,205,3,89,215,31,69,100,235,117,45,46,10,131,149,93,86,170,214,166,58,155,61,183,91,39,41,55,208,152,118,159,194,242,162,131,130,120,141,57,59,255,99,90,139,174,181,117,249,31,141,234,185,49,157,135,187,100,19,238,120,7,181,105,55,5,92,77,251,148,60,189,232,106,251,124,184,25,238,118,31,134,219,225,110,184,221,93,239,62,13,159,93,253,117,248,225,170,239,79,134,111,195,253,238,163,91,191,184,214,253,238,122,150,144,71,214,41,57,33,90,72,1,137,31,80,159,101,46,3,169,51,10,192,99,138,16,100,89,196,100,30,75,126,66,28,238,191,132,56,94,181,175,222,87,251,191,106,206,97,253,204,117,31,53,14,247,202,180,255,27,238,237,122,36,95,111,221,243,19,1,61,79,238,28,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("478bb032-888a-4f41-9359-41cdb90d377e"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5979b1c3-b827-4ad7-a3eb-52822c581832"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b0b1805a-5abb-4475-805c-218ee548217c"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fdee5873-86f8-4f3d-aa5c-e69b12f97fee"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5d0fa38c-f2c2-4f78-95b6-f3676b75c8e1"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				UId = new Guid("3c207d1d-42f2-4e68-bd85-e688aa78b24b"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("72f86497-87b0-46fe-bac9-b3db7791047b"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c7c58a2b-cac9-491c-b4c9-fb948db2f97f"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				UId = new Guid("661d1b62-01ff-4fa0-bfb4-5df1d5d0ba10"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				UId = new Guid("74411649-0f9c-415d-a4c8-9024b0f3ed9f"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				UId = new Guid("711a202f-1cdc-41ef-afd8-c20b828b210a"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				UId = new Guid("8d5ec566-8e21-4a38-8039-ce6bb8fb64dd"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				UId = new Guid("3a63bde1-e78c-404e-80db-ae395affa439"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				UId = new Guid("26f4ab8c-c295-46bd-be1d-c830377c5cff"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c3b3c15e-6fd3-4da9-8787-36b8370bf8df"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fe099617-16b2-4b5e-ab53-736d73a5c5b3"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				UId = new Guid("345d0946-df0f-42e4-a53d-fc5622c989de"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
				UId = new Guid("d4c8f596-3b69-4252-9915-9a07ee11f256"),
				ContainerUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
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
			ProcessSchemaLaneSet schemaIncidentsClassification = CreateIncidentsClassificationLaneSet();
			LaneSets.Add(schemaIncidentsClassification);
			ProcessSchemaLane schemaFirstSupportLine = CreateFirstSupportLineLane();
			schemaIncidentsClassification.Lanes.Add(schemaFirstSupportLine);
			ProcessSchemaSubProcess searchforparent = CreateSearchForParentSubProcess();
			FlowElements.Add(searchforparent);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("49a737a4-9193-4f32-a219-0bb7e79b7131"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8842294e-237e-46c1-984d-cc0645df4cf2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("2670d16c-ad43-4008-9d0c-adc18008f4b5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7a8a973b-3cac-4678-96a2-ebf2179751e0"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0b514df5-26a2-44f1-982e-68d9d3618f2b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("6ee4d0dc-aa5b-4686-b8f5-2dc4374b7b45"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("409c047c-767f-4fe1-831e-6a5e6d719a3f"),
				CreatedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				CurveCenterPosition = new Point(384, 206),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7a8a973b-3cac-4678-96a2-ebf2179751e0"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateIncidentsClassificationLaneSet() {
			ProcessSchemaLaneSet schemaIncidentsClassification = new ProcessSchemaLaneSet(this) {
				UId = new Guid("ea634c1e-a6c6-4dde-9ab0-402a332972fb"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				Name = @"IncidentsClassification",
				Position = new Point(5, 5),
				Size = new Size(1093, 400),
				UseBackgroundMode = false
			};
			return schemaIncidentsClassification;
		}

		protected virtual ProcessSchemaLane CreateFirstSupportLineLane() {
			ProcessSchemaLane schemaFirstSupportLine = new ProcessSchemaLane(this) {
				UId = new Guid("d77f88d0-4bd4-432e-997a-1c08e49cf4f6"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("ea634c1e-a6c6-4dde-9ab0-402a332972fb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				Name = @"FirstSupportLine",
				Position = new Point(29, 0),
				Size = new Size(1064, 400),
				UseBackgroundMode = false
			};
			return schemaFirstSupportLine;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("8842294e-237e-46c1-984d-cc0645df4cf2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d77f88d0-4bd4-432e-997a-1c08e49cf4f6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
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
				UId = new Guid("0b514df5-26a2-44f1-982e-68d9d3618f2b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d77f88d0-4bd4-432e-997a-1c08e49cf4f6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				Name = @"Terminate1",
				Position = new Point(757, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d77f88d0-4bd4-432e-997a-1c08e49cf4f6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				Name = @"ReadDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(127, 170),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaSubProcess CreateSearchForParentSubProcess() {
			ProcessSchemaSubProcess schemaSearchForParent = new ProcessSchemaSubProcess(this) {
				UId = new Guid("7a8a973b-3cac-4678-96a2-ebf2179751e0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d77f88d0-4bd4-432e-997a-1c08e49cf4f6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b"),
				Name = @"SearchForParent",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(505, 170),
				SchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeSearchForParentParameters(schemaSearchForParent);
			return schemaSearchForParent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new IncidentClassification(userConnection);
		}

		public override object Clone() {
			return new IncidentClassificationSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("476a1146-b211-4c61-897d-fb0ea900085b"));
		}

		#endregion

	}

	#endregion

	#region Class: IncidentClassification

	/// <exclude/>
	public class IncidentClassification : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessFirstSupportLine

		/// <exclude/>
		public class ProcessFirstSupportLine : ProcessLane
		{

			public ProcessFirstSupportLine(UserConnection userConnection, IncidentClassification process)
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, IncidentClassification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("4529a033-5f2b-450c-89ad-ad746fe8ed5c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,205,106,220,48,20,133,95,165,104,209,149,85,44,201,63,178,187,28,166,101,54,105,160,105,41,36,67,184,150,174,19,129,127,38,182,76,19,204,64,201,162,155,190,67,158,33,41,45,180,208,188,131,231,141,42,219,153,22,178,40,221,116,81,48,226,234,218,231,232,187,7,185,63,53,237,11,83,88,108,210,28,138,22,189,110,165,83,194,36,151,34,140,145,230,60,140,104,224,115,160,32,124,69,147,32,207,16,65,9,206,99,226,85,80,98,74,102,245,82,27,75,60,99,177,108,211,227,254,183,169,109,58,244,78,243,105,243,90,157,99,9,111,166,3,88,172,5,207,19,42,121,28,210,32,20,1,149,1,99,148,169,40,98,44,84,152,40,77,102,22,20,190,208,32,114,154,229,34,166,1,32,167,210,81,80,149,133,49,72,237,180,35,75,129,185,93,94,110,26,108,91,83,87,105,143,191,234,163,171,141,163,156,207,94,212,69,87,86,196,43,209,194,33,216,243,148,0,250,24,132,10,168,10,18,7,146,99,236,38,77,52,21,144,197,60,150,200,34,230,220,21,108,236,104,75,86,142,74,131,133,183,80,116,56,57,247,198,49,114,225,51,25,70,78,203,132,162,129,224,62,149,145,140,105,174,163,60,65,17,37,73,166,247,121,189,236,140,171,77,123,208,149,216,24,245,16,59,186,252,234,38,237,85,93,217,166,46,70,235,131,233,243,35,188,180,115,184,15,175,222,205,3,89,215,31,69,100,235,117,45,46,10,131,149,93,86,170,214,166,58,155,61,183,91,39,41,55,208,152,118,159,194,242,162,131,130,120,141,57,59,255,99,90,139,174,181,117,249,31,141,234,185,49,157,135,187,100,19,238,120,7,181,105,55,5,92,77,251,148,60,189,232,106,251,124,184,25,238,118,31,134,219,225,110,184,221,93,239,62,13,159,93,253,117,248,225,170,239,79,134,111,195,253,238,163,91,191,184,214,253,238,122,150,144,71,214,41,57,33,90,72,1,137,31,80,159,101,46,3,169,51,10,192,99,138,16,100,89,196,100,30,75,126,66,28,238,191,132,56,94,181,175,222,87,251,191,106,206,97,253,204,117,31,53,14,247,202,180,255,27,238,237,122,36,95,111,221,243,19,1,61,79,238,28,4,0,0 })));
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

			#endregion

		}

		#endregion

		#region Class: SearchForParentFlowElement

		/// <exclude/>
		public class SearchForParentFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public SearchForParentFlowElement(UserConnection userConnection, IncidentClassification process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a");
			}

			#endregion

			#region Properties: Public

			public Guid IncidentId {
				get {
					return GetParameterValue<Guid>("IncidentId");
				}
				set {
					SetParameterValue("IncidentId", value);
				}
			}

			public bool IsCaseCollectionAny {
				get {
					return GetParameterValue<bool>("IsCaseCollectionAny");
				}
				set {
					SetParameterValue("IsCaseCollectionAny", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (IncidentClassification)owner;
				Name = "SearchForParent";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("7a8a973b-3cac-4678-96a2-ebf2179751e0");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.FirstSupportLine;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (IncidentClassification)Owner;
				SetParameterValue("IncidentId", (Guid)((process.IncidentId)));
			}

			#endregion

		}

		#endregion

		public IncidentClassification(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "IncidentClassification";
			SchemaUId = new Guid("476a1146-b211-4c61-897d-fb0ea900085b");
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
				return new Guid("476a1146-b211-4c61-897d-fb0ea900085b");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: IncidentClassification, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: IncidentClassification, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid IncidentId {
			get;
			set;
		}

		private ProcessFirstSupportLine _firstSupportLine;
		public ProcessFirstSupportLine FirstSupportLine {
			get {
				return _firstSupportLine ?? ((_firstSupportLine) = new ProcessFirstSupportLine(UserConnection, this));
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
					SchemaElementUId = new Guid("8842294e-237e-46c1-984d-cc0645df4cf2"),
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
					SchemaElementUId = new Guid("0b514df5-26a2-44f1-982e-68d9d3618f2b"),
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

		private SearchForParentFlowElement _searchForParent;
		public SearchForParentFlowElement SearchForParent {
			get {
				return _searchForParent ?? ((_searchForParent) = new SearchForParentFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessToken _readDataUserTask1SearchForParentToken;
		public ProcessToken ReadDataUserTask1SearchForParentToken {
			get {
				return _readDataUserTask1SearchForParentToken ?? (_readDataUserTask1SearchForParentToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ReadDataUserTask1SearchForParentToken",
					SchemaElementUId = new Guid("7a6be040-abbb-4c25-abfd-d584ff0b1ea8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[SearchForParent.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchForParent };
			FlowElements[ReadDataUserTask1SearchForParentToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1SearchForParentToken };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ReadDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1SearchForParentToken", e.Context.SenderName));
						break;
					case "SearchForParent":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1SearchForParentToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchForParent", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("IncidentId")) {
				writer.WriteValue("IncidentId", IncidentId, Guid.Empty);
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
			MetaPathParameterValues.Add("d383a904-01bc-48db-aa27-ea4bb618f782", () => IncidentId);
			MetaPathParameterValues.Add("d9cd6ff7-8c44-4ad3-9dc6-8537b799e76a", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("478bb032-888a-4f41-9359-41cdb90d377e", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("5979b1c3-b827-4ad7-a3eb-52822c581832", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("b0b1805a-5abb-4475-805c-218ee548217c", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("fdee5873-86f8-4f3d-aa5c-e69b12f97fee", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("5d0fa38c-f2c2-4f78-95b6-f3676b75c8e1", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("3c207d1d-42f2-4e68-bd85-e688aa78b24b", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("72f86497-87b0-46fe-bac9-b3db7791047b", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("c7c58a2b-cac9-491c-b4c9-fb948db2f97f", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("661d1b62-01ff-4fa0-bfb4-5df1d5d0ba10", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("74411649-0f9c-415d-a4c8-9024b0f3ed9f", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("711a202f-1cdc-41ef-afd8-c20b828b210a", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("8d5ec566-8e21-4a38-8039-ce6bb8fb64dd", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("3a63bde1-e78c-404e-80db-ae395affa439", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("26f4ab8c-c295-46bd-be1d-c830377c5cff", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("c3b3c15e-6fd3-4da9-8787-36b8370bf8df", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("fe099617-16b2-4b5e-ab53-736d73a5c5b3", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("345d0946-df0f-42e4-a53d-fc5622c989de", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("d4c8f596-3b69-4252-9915-9a07ee11f256", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("abceed8c-c3dd-4674-9bce-5ea3599b7797", () => SearchForParent.IncidentId);
			MetaPathParameterValues.Add("175e0f29-9e7d-46d8-add2-688541e40b0b", () => SearchForParent.IsCaseCollectionAny);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "IncidentId":
					if (!hasValueToRead) break;
					IncidentId = reader.GetValue<System.Guid>();
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
			var cloneItem = (IncidentClassification)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

