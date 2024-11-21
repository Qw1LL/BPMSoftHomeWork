namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
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

	#region Class: LeadManagementIdentificationSchema

	/// <exclude/>
	public class LeadManagementIdentificationSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LeadManagementIdentificationSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LeadManagementIdentificationSchema(LeadManagementIdentificationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LeadManagementIdentification";
			UId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505");
			CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = false;
			Tag = @"LeadManagementIdentification";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,209,74,195,64,16,124,110,161,255,176,246,41,129,114,63,160,21,98,80,91,80,168,74,241,65,250,112,73,54,229,224,114,119,222,237,85,139,248,239,238,165,34,6,173,224,67,224,152,157,217,217,25,50,25,187,88,105,85,195,78,121,138,82,195,206,170,6,138,154,148,53,69,75,232,151,13,26,82,173,170,101,130,178,28,222,38,227,81,32,175,204,22,164,115,250,115,176,246,26,230,112,192,197,101,231,104,127,202,60,213,66,118,177,186,125,176,45,137,71,172,196,130,200,137,162,98,154,236,29,66,143,148,214,16,190,146,40,163,247,108,6,39,115,48,81,235,131,213,232,135,201,247,133,165,237,58,107,210,115,77,74,43,82,24,196,53,210,74,166,69,197,64,249,255,67,196,61,62,71,12,148,167,40,239,252,237,164,7,141,178,185,227,162,190,42,89,160,118,232,249,174,82,203,16,174,120,159,245,251,116,196,217,205,239,212,243,204,224,11,176,23,187,199,196,46,252,54,118,236,247,180,233,3,31,153,102,211,24,208,243,192,96,127,242,116,6,235,1,144,207,254,84,15,123,100,245,16,200,83,198,62,233,145,132,226,248,79,145,130,46,155,36,230,150,38,227,15,112,16,191,177,84,2,0,0 };
			RealUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505");
			Version = 0;
			PackageUId = new Guid("68ee82f8-280b-40ce-951d-6e93d2945a8f");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateLeadIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1300b53e-296c-4858-8368-493adc25a74c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"LeadId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIdentificationPassedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("27623c14-f1c7-4872-8f1c-45103cd82954"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"IdentificationPassed",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"true",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateLeadIdParameter());
			Parameters.Add(CreateIdentificationPassedParameter());
		}

		protected virtual void InitializeReadLeadDataParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f7cf3a22-2a33-428e-9e2b-5f3622d92f72"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,211,64,16,253,47,62,119,43,123,189,206,218,189,65,9,40,18,208,72,169,122,169,123,24,239,78,146,21,118,108,237,110,10,33,202,127,103,214,78,66,138,34,8,92,168,47,182,159,222,188,121,243,181,141,84,13,206,125,134,6,163,155,232,237,244,211,172,157,251,235,247,166,246,104,63,216,118,221,69,87,145,67,107,160,54,223,81,15,248,88,27,255,14,60,80,192,182,252,25,95,70,55,229,57,133,50,186,42,35,227,177,113,196,160,0,145,86,40,242,24,24,38,42,102,66,73,193,114,45,129,197,50,209,69,194,121,156,171,116,96,158,151,190,109,155,14,44,14,25,122,241,121,255,121,191,233,2,49,33,64,245,20,227,218,213,30,76,131,5,55,94,65,85,163,166,127,111,215,72,144,183,166,161,74,240,222,52,56,5,75,153,130,78,27,32,34,205,161,118,129,85,227,220,143,191,117,22,157,51,237,234,247,214,234,117,179,58,229,82,56,30,127,247,102,226,222,97,96,78,193,47,123,129,9,153,218,245,30,223,44,22,22,23,224,205,243,169,133,47,184,233,121,151,245,142,2,52,205,231,1,234,53,158,228,124,89,199,45,116,126,40,103,72,79,4,107,22,203,11,43,61,118,235,79,197,114,2,187,3,249,34,197,179,254,249,136,192,231,0,12,26,135,207,50,122,156,184,187,175,43,180,51,181,196,6,134,142,61,93,19,250,11,112,212,191,217,38,105,28,87,89,138,140,23,35,197,68,158,229,44,79,71,57,19,69,10,90,241,12,164,80,187,167,193,135,113,93,13,155,135,99,186,143,8,122,223,174,240,34,68,206,53,207,176,42,104,18,177,100,66,138,17,171,84,86,177,52,65,153,112,0,173,1,104,186,225,9,67,104,23,70,65,125,215,161,165,33,247,77,142,207,47,231,139,173,14,229,219,182,245,67,81,199,230,5,55,189,151,195,130,112,76,42,37,179,130,129,148,180,32,57,79,88,5,156,179,84,101,137,168,180,40,98,168,200,12,93,117,232,240,172,93,91,181,191,36,55,156,243,63,29,234,127,56,192,191,185,170,179,123,125,201,166,190,150,45,156,188,150,77,219,69,187,31,115,35,247,46,50,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a01e5fd1-7cbb-4e06-9188-a9656c381385"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4db6d4f9-57aa-44ef-8934-56b12a060e0e"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dc3c82bb-8c59-485f-9376-5880ae2ce035"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bcf6ac2d-9970-48a9-80e2-c7d41b6c0c2e"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("76636537-e5df-47a7-9eb6-124881330bf3"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				UId = new Guid("232523cc-cb63-410d-8f7c-58cdcf2ef818"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,73,77,76,241,75,204,77,181,50,180,50,212,241,76,177,50,176,50,0,0,197,68,70,233,19,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("6c984967-8a07-4d65-aefc-418e5a11cdcd"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e3cd6198-af4e-409b-8ba3-0851372ea038"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				UId = new Guid("7e4ceefa-cd15-47a3-8a3b-c8ad4ed1ef7f"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				UId = new Guid("0a326237-a485-4b38-9337-3aa27272cdd9"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				UId = new Guid("f7b52dbf-c358-489e-bf2c-3c4ff7924a2c"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				UId = new Guid("dd6ab013-fc1e-4bc5-a25b-6855ace31f97"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				UId = new Guid("c6cfc815-55cb-4def-b83c-14b182d467ce"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("72ded882-b97d-4f56-91cb-1e6e212f4218"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a075eb5-bcac-445c-993d-bd329be8d6dc"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,21,83,201,13,4,33,12,171,40,82,46,114,104,170,9,4,250,47,97,179,31,94,198,248,194,109,135,218,49,176,122,11,20,15,67,46,55,88,103,245,62,216,198,136,159,89,44,46,95,176,153,47,168,36,66,69,63,208,12,210,211,27,73,232,75,45,169,88,2,24,103,131,198,122,16,249,20,40,56,60,106,85,221,253,41,175,216,54,247,223,117,2,221,94,16,236,1,15,203,119,118,171,7,126,97,235,110,158,251,146,58,32,150,7,165,7,225,120,136,138,69,121,189,175,61,183,54,38,168,231,128,50,101,132,243,134,139,233,24,177,215,58,246,29,127,155,18,47,44,234,0,61,182,160,198,23,28,113,210,150,141,245,252,211,40,60,106,244,119,167,160,175,70,248,237,11,231,138,245,146,122,42,247,139,44,196,126,4,210,50,160,50,129,45,122,128,211,163,207,243,139,117,63,186,113,177,55,1,46,244,17,118,55,164,31,31,166,237,145,138,82,213,223,82,52,63,79,128,228,159,56,55,65,212,75,72,60,182,187,143,187,203,231,135,135,43,18,106,215,184,179,225,220,18,6,19,64,96,178,119,123,124,239,94,225,14,2,191,127,225,53,194,146,230,57,193,144,171,173,41,241,190,201,232,28,89,9,114,39,81,13,58,176,163,10,136,252,148,109,158,96,237,227,229,69,194,4,79,87,15,200,2,246,83,133,155,143,199,161,25,181,124,117,241,234,58,5,71,115,132,79,131,80,146,13,82,219,167,195,75,70,254,85,197,161,105,102,6,242,102,5,28,10,59,45,33,30,45,19,44,94,247,124,35,44,155,199,157,253,61,105,188,3,185,123,1,159,21,206,34,108,198,95,163,237,202,41,99,10,153,231,124,166,80,230,12,151,150,214,93,70,149,250,41,190,251,168,19,94,206,161,172,6,149,56,203,137,188,188,172,234,180,126,247,58,7,183,1,203,12,68,53,223,184,243,13,180,155,47,61,177,90,241,105,45,247,191,103,155,54,231,35,52,194,166,23,48,129,241,121,182,198,41,125,245,186,78,209,140,26,103,143,234,230,127,208,228,52,98,83,173,101,42,255,122,134,131,87,2,100,203,159,105,207,84,114,44,96,108,79,236,20,101,252,174,15,35,217,129,217,225,127,227,52,160,237,14,41,162,189,174,141,192,247,253,197,173,51,76,230,143,65,187,100,18,127,6,173,60,191,173,186,198,239,15,157,239,2,19,193,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("17573208-3be8-4476-9823-f565b0714f28"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				UId = new Guid("807ae5d1-ceac-47d5-8eb5-4720a6cd38c0"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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
				UId = new Guid("5770885f-4a81-42ac-b246-d9db3aa13a28"),
				ContainerUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
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

		protected virtual void InitializeReadContactsByLeadCommunicationsParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b62c39d0-3349-4a21-9582-0f3e9fab1b13"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,75,115,219,70,12,254,43,26,157,218,153,172,103,223,220,245,173,113,213,78,14,121,76,157,201,37,246,97,31,88,155,83,138,212,144,84,90,215,163,255,94,144,148,101,59,145,93,218,117,106,37,149,14,28,121,141,5,1,236,247,97,1,232,114,26,10,215,52,111,220,28,166,135,211,151,239,94,31,87,169,61,248,37,47,90,168,127,173,171,229,98,250,98,218,64,157,187,34,255,11,226,176,62,139,121,251,179,107,29,110,184,60,185,222,127,50,61,60,217,166,225,100,250,226,100,154,183,48,111,80,2,55,104,74,29,5,13,68,129,182,68,198,164,136,23,81,17,22,77,230,99,50,194,248,52,72,110,87,61,251,51,111,218,102,120,65,175,59,245,95,223,95,44,58,57,133,11,161,154,47,92,157,55,85,185,94,100,221,106,222,204,74,231,11,136,184,208,214,75,192,165,182,206,231,232,9,188,207,231,240,206,213,248,166,78,81,213,45,161,80,114,69,211,73,21,144,218,217,159,139,26,154,38,175,202,251,76,59,170,138,229,188,188,41,139,219,97,243,231,218,26,218,155,216,73,190,115,237,121,175,224,227,81,85,182,46,180,71,213,124,190,44,243,224,90,20,63,92,47,158,30,188,66,155,87,189,11,63,157,157,213,112,134,255,254,4,215,110,252,14,23,189,150,113,145,197,13,17,79,239,131,43,150,112,195,162,219,94,30,185,69,103,66,175,118,109,198,36,220,52,110,82,245,2,147,31,252,197,100,112,102,178,150,251,177,127,69,179,244,195,17,173,79,253,193,48,161,50,73,237,66,70,188,100,156,72,221,57,195,181,38,44,112,198,13,128,114,94,220,127,22,29,8,224,46,156,176,109,56,17,59,14,147,55,203,185,239,156,217,134,133,43,51,174,192,48,46,126,91,192,192,205,189,104,184,178,1,133,234,252,236,124,164,203,155,176,253,147,215,28,23,23,87,194,163,52,110,119,66,227,226,167,110,97,208,113,245,21,169,246,170,121,251,71,9,245,113,56,135,185,27,194,118,122,128,171,159,45,204,10,152,67,217,30,94,58,233,116,74,52,16,198,108,194,64,10,70,156,225,156,104,35,37,205,180,1,11,106,133,27,54,6,29,94,234,96,141,180,58,35,198,209,12,137,168,21,113,144,2,145,204,96,220,25,11,49,196,110,203,172,108,243,246,98,128,195,225,101,2,16,60,26,70,50,224,146,72,39,36,177,12,15,80,80,35,64,70,105,133,73,171,211,193,221,188,89,20,238,226,195,198,171,223,192,197,73,129,15,164,84,221,180,147,142,72,147,42,77,48,184,203,162,205,203,179,142,164,5,132,238,24,15,102,115,151,23,189,158,46,177,224,110,48,193,39,165,40,97,144,34,145,20,83,136,1,205,9,21,44,147,2,18,130,7,177,178,194,15,238,97,218,242,204,26,77,192,107,140,135,151,129,56,11,140,80,138,102,123,206,88,130,236,190,131,123,85,222,197,73,249,45,114,242,86,202,30,196,198,208,115,92,20,183,32,155,221,159,172,7,169,47,201,217,101,213,143,59,67,207,222,137,27,244,188,194,33,176,96,84,16,36,164,224,73,76,140,17,235,185,195,160,176,168,41,32,1,130,238,245,109,94,119,13,229,107,134,143,214,242,5,139,214,218,16,231,167,61,212,139,234,12,15,182,120,187,128,186,63,222,53,2,182,192,241,22,142,187,220,83,87,85,59,100,148,141,173,219,238,248,222,142,77,202,142,134,171,64,45,137,142,98,202,150,34,35,86,34,68,152,5,39,20,139,92,201,174,16,232,44,139,65,176,32,68,36,222,40,133,140,181,156,56,42,128,80,207,131,50,204,121,231,228,190,136,122,76,17,53,46,178,223,72,17,149,130,192,155,8,44,209,78,211,174,8,72,196,51,105,137,0,227,84,138,9,203,194,240,88,213,194,139,204,196,140,100,73,249,14,172,130,96,38,51,36,104,176,18,68,136,70,175,201,189,175,207,182,93,0,227,226,183,175,207,118,167,62,147,52,65,98,209,146,100,241,33,185,212,120,101,211,68,132,177,192,149,118,46,68,249,36,245,217,235,202,231,5,76,22,231,85,57,64,96,125,61,234,68,133,230,248,70,136,20,11,68,234,209,83,142,249,73,114,19,121,247,13,73,189,41,211,60,77,76,153,228,136,210,30,173,85,224,137,143,88,87,226,165,232,4,77,26,1,214,105,221,243,243,142,2,109,92,252,246,252,220,29,126,90,108,153,156,81,130,80,108,103,136,52,42,17,99,147,36,204,112,147,33,53,156,3,255,36,252,124,185,108,242,18,175,248,47,25,170,50,107,133,215,140,40,76,237,68,90,99,137,7,45,145,166,194,74,133,31,25,250,10,110,117,87,121,201,190,98,121,57,174,24,232,12,147,22,203,30,239,29,17,146,33,246,33,80,236,7,241,17,144,10,38,58,231,180,85,79,216,226,201,239,179,197,27,23,197,125,139,247,127,106,241,146,76,6,7,111,138,100,54,195,4,145,5,108,251,141,164,132,27,108,242,116,100,150,41,28,209,174,190,158,105,183,172,9,84,107,155,113,65,98,166,176,140,240,8,78,231,153,39,88,207,56,192,132,32,121,192,33,196,10,127,3,232,154,157,227,106,89,135,245,64,181,25,134,255,143,26,235,63,199,188,254,9,135,240,159,55,101,143,154,89,63,195,44,250,161,3,230,173,211,221,49,3,161,253,44,118,7,103,177,207,48,104,253,23,87,235,29,195,203,199,160,239,214,168,113,236,205,241,95,222,14,15,156,231,125,191,217,115,252,176,234,81,99,168,125,202,221,237,159,191,190,215,241,202,30,119,187,141,187,253,216,96,219,165,244,160,41,192,51,180,248,251,226,226,120,92,113,241,21,59,201,213,116,245,55,194,251,125,4,64,38,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("15307ea3-405b-4286-937e-bbd0152634bb"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b0de7902-f6c1-44eb-87ff-109bad0eb346"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d29cd82a-8e0d-4086-8795-48b2899e16af"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("daf2cf98-3c7e-4055-b671-143255e4ffb9"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("34ed4a32-1e5a-4623-ae6a-18a622bf6230"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("97666c94-b7fa-4cf1-858f-96a7f5e41511"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,77,241,207,179,50,180,50,212,241,76,177,50,176,50,0,0,80,50,116,145,20,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("10568b26-1c18-4f39-9578-4a72a1c5fb66"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("935c4f95-44b6-44e3-920e-5b06a85a9a77"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				UId = new Guid("567adf56-c83c-4371-b0d7-e3c15c4a747e"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				UId = new Guid("7ad0d0ed-5315-4834-9632-bc717ea4b547"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				UId = new Guid("06ba8c97-f038-45da-8d5c-e5fa72c64ac0"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				UId = new Guid("085f20cb-53af-486b-a15f-5bc389f586df"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				UId = new Guid("7b7d4ca0-20b2-450c-a302-c217ce695e2c"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("316aa43c-1aa6-47f1-aaf7-572b6f838fcf"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2cc24615-28c1-4668-8f49-c93ae2c5896a"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,75,76,53,72,53,49,77,78,212,77,54,177,52,213,53,73,75,53,215,77,52,182,76,209,53,78,76,50,55,50,183,72,53,52,51,52,7,0,106,93,85,138,36,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b4d0581e-c249-4b18-a38c-f40592d4085d"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				UId = new Guid("2729cf7a-36f6-4003-b06a-e8cb957b2269"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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
				UId = new Guid("f215686f-4d81-4543-93aa-539f611453e4"),
				ContainerUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
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

		protected virtual void InitializeChangeLeadContactAllParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("9a626ad2-321e-427a-9f24-760d9280a022"),
				ContainerUId = new Guid("d21d53d2-a563-4394-aad1-8db8c7558606"),
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
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("564a7988-620b-401f-9bfc-8041ac06be95"),
				ContainerUId = new Guid("d21d53d2-a563-4394-aad1-8db8c7558606"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b7b1963b-962d-4921-a62e-3119d14d8a66"),
				ContainerUId = new Guid("d21d53d2-a563-4394-aad1-8db8c7558606"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,47,62,87,133,63,99,59,183,173,203,134,0,219,26,32,69,47,117,15,148,68,39,194,236,216,144,228,110,89,144,255,62,202,78,178,116,48,218,108,151,53,7,199,126,120,36,31,201,199,157,39,42,48,230,43,212,232,77,189,247,139,47,203,166,180,215,31,85,101,81,127,210,77,215,122,87,158,65,173,160,82,63,81,14,248,76,42,251,1,44,80,192,174,248,29,95,120,211,98,44,67,225,93,21,158,178,88,27,98,80,0,231,24,136,180,148,76,136,40,103,177,240,51,150,167,9,103,8,0,156,203,36,18,16,13,204,241,212,55,77,221,130,198,161,66,159,188,236,95,239,182,173,35,6,4,136,158,162,76,179,57,128,145,147,96,102,27,224,21,74,250,182,186,67,130,172,86,53,117,130,119,170,198,5,104,170,228,242,52,14,34,82,9,149,113,172,10,75,59,251,209,106,52,70,53,155,151,165,85,93,189,57,231,82,56,158,62,15,98,252,94,161,99,46,192,174,251,4,115,18,181,239,53,190,91,173,52,174,192,170,167,115,9,223,112,219,243,46,155,29,5,72,218,207,61,84,29,158,213,124,222,199,13,180,118,104,103,40,79,4,173,86,235,11,59,61,77,235,181,102,67,2,219,35,249,162,140,163,250,195,9,129,79,14,24,114,28,95,11,239,97,110,110,191,111,80,47,197,26,107,24,38,246,120,77,232,31,192,41,255,116,23,68,190,207,147,8,89,152,79,4,139,179,36,99,89,52,201,88,156,71,32,69,152,64,26,139,253,227,160,67,153,182,130,237,253,169,220,103,4,121,24,151,251,35,164,12,115,206,51,63,102,129,31,133,44,150,72,59,201,131,132,241,60,201,226,188,244,121,89,6,180,93,247,115,75,104,86,74,64,117,219,162,166,37,247,67,246,199,205,249,204,213,174,125,221,52,118,104,234,52,60,167,166,215,114,52,8,240,52,140,56,85,79,115,240,89,156,200,152,65,74,143,124,130,147,144,147,78,144,206,106,116,213,110,194,203,166,211,226,112,73,102,56,231,127,58,212,255,112,128,127,115,85,163,190,190,196,169,111,197,133,243,183,226,180,189,183,255,5,17,197,147,134,50,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5d16c9f4-5c23-4097-8d07-fac1cb716e39"),
				ContainerUId = new Guid("d21d53d2-a563-4394-aad1-8db8c7558606"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,147,93,111,218,48,20,134,255,74,148,246,18,163,56,254,136,157,203,181,157,132,212,110,168,108,189,1,46,142,237,227,54,82,72,80,98,54,49,196,127,159,9,208,150,174,119,243,69,98,31,159,231,124,229,205,46,189,14,219,53,166,101,250,101,250,48,107,125,24,223,180,29,142,167,93,107,177,239,199,247,173,133,186,250,3,166,198,41,116,176,194,128,221,19,212,27,236,239,171,62,140,146,247,80,58,74,175,127,13,119,105,57,223,165,147,128,171,159,19,23,35,23,74,35,183,121,78,140,87,148,240,44,115,68,69,19,225,74,162,47,168,150,78,208,8,219,182,222,172,154,7,12,48,133,240,146,150,187,116,136,22,3,128,227,58,115,66,145,76,112,32,220,41,65,116,206,37,113,78,113,41,209,48,173,88,186,31,165,189,125,193,21,12,73,223,96,78,193,199,108,154,20,34,51,132,163,49,68,89,176,196,123,166,141,228,138,83,180,7,248,228,255,6,206,175,230,147,254,251,239,6,187,217,16,183,244,80,247,184,28,71,235,7,195,93,141,43,108,66,185,19,66,229,5,48,75,132,65,75,184,23,16,123,214,138,20,154,21,82,241,156,26,198,246,17,120,157,101,185,163,153,144,202,228,146,80,75,85,68,152,38,90,20,113,7,69,14,212,10,111,164,60,32,119,77,168,194,246,102,152,81,185,3,204,144,11,11,196,114,45,34,133,5,1,166,29,97,96,138,188,80,72,37,45,246,203,171,229,161,49,87,245,235,26,182,79,255,246,247,136,224,18,219,54,190,234,86,56,236,2,216,208,39,102,155,212,135,171,216,99,85,39,208,184,100,253,210,54,216,143,191,86,93,31,146,42,126,217,164,245,73,135,253,166,14,85,243,28,201,186,70,27,170,182,25,79,220,49,235,250,66,46,239,243,238,22,71,205,45,210,114,241,185,234,78,239,227,148,47,117,119,41,185,69,58,90,164,179,118,211,217,67,52,22,15,183,239,154,29,18,12,46,31,142,103,141,69,75,179,169,235,147,229,22,2,156,29,207,230,214,85,190,66,55,105,102,103,105,13,81,178,211,34,159,60,206,235,88,219,255,96,15,208,192,51,118,223,98,251,111,181,191,86,249,35,142,240,28,216,228,90,100,5,245,164,64,208,81,227,50,39,202,81,32,154,106,227,89,193,114,239,243,129,126,68,143,29,54,22,47,11,163,210,32,147,130,18,229,49,39,156,10,29,121,151,17,80,25,115,92,42,230,28,59,241,253,48,237,195,207,125,170,235,48,170,125,186,223,47,247,127,1,240,39,194,64,76,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2c6aba36-8758-475f-ae50-d4a503c1975d"),
				ContainerUId = new Guid("d21d53d2-a563-4394-aad1-8db8c7558606"),
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

		protected virtual void InitializeAddContactByLeadParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("c43dec79-6b59-4fc6-94f0-bcc6a7f8c091"),
				ContainerUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"EntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"16be3651-8fe2-4159-8dd0-a803d4683dd3",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("61b7d5bc-8334-4d0a-8ec3-aac02f0f6b0d"),
				ContainerUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ec4e60e4-4bd2-476d-bfa5-f3879991dce5"),
				ContainerUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordAddMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			recordAddModeParameter.SourceValue = new ProcessSchemaParameterValue(recordAddModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,0,0,33,223,219,244,1,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("fc9a7fd7-6ae6-4198-801f-ed65a0714560"),
				ContainerUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"FilterEntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			filterEntitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(filterEntitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0698fbce-2359-4022-88df-2b5fa4260af7"),
				ContainerUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordDefValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordDefValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordDefValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,91,109,143,27,183,17,254,43,170,18,160,13,96,30,248,206,161,128,162,64,98,167,112,17,55,134,175,205,23,219,31,134,228,48,86,161,147,14,146,174,173,123,184,255,158,103,229,59,191,37,85,125,141,236,250,186,210,135,61,105,111,201,37,185,243,112,158,153,121,246,114,250,229,246,229,185,76,103,211,175,31,63,58,93,245,237,201,55,171,181,156,60,94,175,170,108,54,39,223,173,42,47,230,255,226,178,144,199,188,230,51,217,202,250,7,94,92,200,230,187,249,102,123,111,242,118,163,233,189,233,151,127,223,253,111,58,123,122,57,125,184,149,179,191,62,108,232,57,197,216,83,176,94,105,17,173,188,51,73,113,238,94,85,103,163,246,166,134,20,24,141,235,106,113,113,182,124,36,91,126,204,219,23,211,217,229,116,215,27,58,224,80,43,167,108,149,79,173,41,111,137,21,185,94,84,168,217,150,214,114,234,157,166,87,247,166,155,250,66,206,120,119,211,55,141,77,44,226,98,48,138,186,160,7,19,178,162,214,180,98,210,174,249,72,174,53,55,52,190,190,254,77,195,167,95,60,125,184,249,254,31,75,89,159,238,250,157,117,94,108,228,249,9,206,190,119,226,193,66,206,100,185,157,93,178,231,216,187,174,202,152,220,149,143,206,224,54,214,170,72,222,235,20,73,178,132,43,52,120,189,150,179,203,88,51,249,28,147,34,214,73,249,22,131,98,233,21,3,37,9,108,76,109,181,13,77,30,44,183,243,237,203,111,118,107,52,187,164,24,164,216,208,149,203,222,96,69,92,87,236,171,86,53,145,243,46,18,39,238,87,207,191,120,62,249,205,239,39,167,219,245,124,249,227,201,131,179,243,237,203,201,31,38,255,23,211,154,77,126,247,57,207,163,139,56,219,200,168,36,48,123,207,206,171,108,106,82,78,147,19,223,124,118,116,23,31,207,7,79,235,51,127,60,25,67,103,10,78,105,170,69,121,130,193,209,176,33,25,178,148,136,3,179,148,59,248,120,62,120,90,179,207,122,26,94,119,233,166,101,213,51,14,222,250,8,119,161,177,39,80,22,27,34,115,109,126,152,198,87,95,13,219,118,155,111,206,23,252,242,135,159,239,222,79,132,219,100,129,195,201,183,243,245,102,59,153,195,33,77,86,125,178,150,205,197,98,139,135,58,129,199,89,72,221,206,87,75,56,176,229,150,235,118,178,196,216,255,205,131,255,53,253,237,0,113,171,14,30,156,241,124,113,136,145,220,116,116,251,33,124,125,177,153,47,193,2,38,231,47,86,203,131,172,202,207,122,156,221,182,135,71,171,50,95,200,77,251,87,38,112,254,14,51,121,219,8,46,159,189,162,55,207,166,179,103,191,76,112,174,255,190,50,250,119,41,206,187,236,230,217,244,222,179,233,233,234,98,93,135,222,28,126,220,127,203,242,118,55,216,93,242,222,207,27,58,131,51,203,139,197,226,250,204,125,222,242,205,133,55,167,87,109,222,231,210,30,46,79,111,88,204,174,23,125,253,81,191,112,184,249,188,26,219,175,105,246,136,151,252,163,172,255,140,233,191,25,251,235,81,254,5,75,120,211,113,107,197,177,17,81,58,9,13,152,182,170,36,206,170,105,137,134,138,214,189,180,93,235,39,210,101,45,203,42,255,229,192,158,200,102,183,218,3,143,188,30,215,176,84,87,211,171,171,123,111,179,203,78,182,247,32,93,153,234,25,3,42,164,114,44,65,21,234,217,86,108,28,65,219,189,236,146,74,36,205,112,99,226,35,246,166,136,67,137,78,43,9,181,248,198,198,113,8,227,98,151,190,233,90,29,166,226,4,62,196,147,193,138,16,51,238,155,42,199,98,65,201,226,176,3,31,112,255,253,22,143,118,242,183,85,153,96,28,11,32,251,136,235,209,227,218,107,171,73,55,176,203,132,88,160,139,83,185,12,63,75,175,173,85,19,140,174,123,113,93,67,75,213,55,167,58,248,169,242,26,223,200,199,172,34,3,240,132,192,49,105,30,23,174,69,146,37,219,162,178,206,130,32,122,220,173,244,84,148,41,205,138,233,46,114,160,3,227,250,137,212,249,249,28,211,252,237,230,154,11,29,145,61,118,100,107,97,242,38,118,21,216,14,81,126,43,32,248,28,21,145,119,186,38,239,163,105,123,145,157,125,45,148,2,208,216,208,139,23,210,170,4,196,61,169,101,49,136,130,40,68,25,23,178,107,234,197,100,45,42,152,134,103,92,135,86,1,235,90,93,50,216,2,139,230,158,14,140,236,251,2,222,189,29,230,121,196,244,39,103,225,197,230,0,183,216,145,137,1,146,189,0,211,212,12,35,29,147,75,119,201,129,18,219,125,152,78,108,99,182,22,86,31,3,172,172,128,230,149,94,188,146,34,33,71,241,38,55,186,21,166,131,115,98,75,102,88,92,0,170,98,3,190,116,136,42,90,193,246,227,164,232,24,247,98,218,121,143,12,159,32,163,212,34,124,19,131,128,103,7,116,119,18,246,161,91,110,197,143,11,211,204,84,241,56,61,186,71,174,27,89,111,175,74,6,127,161,110,2,226,19,182,65,234,129,49,253,167,35,1,191,179,144,174,100,65,108,59,70,2,40,160,202,146,162,202,92,156,170,1,230,15,47,80,82,137,183,130,52,195,107,48,39,81,216,42,16,88,123,224,154,18,126,10,42,46,204,22,12,220,239,135,180,41,112,70,221,57,88,188,29,70,4,15,13,30,210,6,30,98,76,199,120,141,177,227,130,52,101,214,186,117,163,92,67,238,28,119,117,170,56,95,149,205,137,90,237,73,52,203,161,221,244,106,178,92,109,39,23,27,153,200,171,76,224,145,128,127,98,100,103,93,98,40,157,148,238,59,11,65,105,11,64,202,202,122,4,184,9,37,173,172,211,39,37,224,169,36,231,138,100,165,17,8,35,50,238,64,182,107,85,133,206,205,117,3,112,134,253,161,53,234,63,25,232,135,9,55,196,21,240,220,132,14,108,85,57,121,231,139,233,54,123,55,46,100,123,92,93,17,184,168,98,135,210,88,103,212,94,164,137,170,152,106,11,142,187,119,31,17,217,167,143,78,143,184,254,228,30,251,179,195,181,102,221,43,247,168,18,101,232,36,164,249,193,8,161,147,128,238,194,85,49,32,8,110,47,174,173,35,132,208,201,171,222,13,160,41,94,15,41,51,20,120,131,46,45,55,196,9,212,198,133,235,224,117,76,181,59,101,92,15,67,174,2,211,195,131,85,89,215,8,233,73,77,41,185,143,135,235,163,195,254,159,80,241,207,14,216,136,0,41,69,131,248,188,155,93,101,223,194,213,34,30,108,160,208,26,174,220,133,190,223,97,163,106,83,123,236,162,88,199,65,65,5,22,142,12,0,82,227,100,179,84,209,161,183,60,46,96,167,106,133,132,178,226,194,72,66,198,2,215,237,8,73,72,231,73,103,11,161,89,162,143,7,236,235,250,245,145,138,143,29,217,57,80,76,29,86,110,195,144,136,139,22,85,46,65,94,46,75,99,215,224,175,53,138,207,251,144,13,183,44,44,45,192,211,123,128,83,67,45,151,11,140,25,136,239,18,147,137,149,71,150,55,51,192,181,110,88,2,141,124,10,36,163,82,176,89,162,188,95,165,128,23,121,237,152,219,199,67,118,231,127,30,113,125,244,216,38,245,236,12,36,203,165,33,191,131,48,57,33,193,238,69,21,175,181,209,100,90,251,15,53,174,42,205,18,100,24,42,65,6,11,139,79,65,101,202,81,9,135,108,57,11,25,142,135,199,245,14,181,251,128,241,250,130,163,232,106,204,110,171,21,200,171,130,134,18,216,5,228,134,109,30,18,64,81,43,147,131,17,19,37,214,144,246,154,119,135,99,42,77,35,35,76,140,20,20,66,41,149,115,130,133,162,0,156,9,155,123,206,113,92,110,139,123,227,202,224,248,208,181,104,184,45,180,71,38,13,148,191,233,152,81,80,115,112,100,7,118,91,167,104,182,229,225,235,209,101,221,185,122,143,184,138,10,46,130,64,227,51,2,24,239,160,123,164,65,14,81,58,42,255,226,11,249,116,43,76,199,166,83,25,170,60,198,150,129,73,130,65,229,98,18,28,144,175,92,16,121,70,75,251,75,184,236,28,20,130,88,155,140,28,148,71,128,9,76,83,81,218,96,98,117,40,25,185,145,97,218,134,4,253,40,68,46,221,7,132,221,20,105,96,1,192,116,238,22,53,159,8,161,203,161,179,71,127,148,101,147,245,17,207,119,14,207,186,64,176,72,192,12,178,18,131,232,182,54,85,224,220,33,127,132,126,162,25,64,203,222,210,71,115,72,240,27,176,81,25,14,93,16,25,86,11,187,53,236,42,113,244,98,247,39,141,122,130,51,142,22,186,95,141,205,197,103,78,138,29,36,100,221,250,94,168,118,212,126,250,184,240,236,177,164,105,0,112,68,177,118,144,148,66,120,102,64,203,160,144,182,200,175,5,151,155,57,180,128,114,117,148,67,223,65,52,7,15,233,196,208,190,23,40,27,125,27,212,24,214,101,108,255,221,117,173,69,156,132,219,121,231,66,22,183,5,97,230,193,76,91,69,10,216,65,232,81,130,15,197,217,8,241,192,254,128,178,149,110,181,149,170,42,234,181,224,151,185,40,228,132,145,67,134,193,23,67,209,89,109,198,133,230,15,125,157,241,128,104,190,126,25,235,24,64,143,93,3,13,245,133,169,144,100,41,91,32,233,131,63,133,18,8,245,135,1,80,76,77,183,92,139,217,175,129,70,146,147,2,172,149,155,7,181,228,10,226,80,77,5,247,46,162,51,170,69,205,143,44,239,251,161,239,141,30,16,206,239,190,141,120,68,245,216,81,29,117,48,217,163,68,11,21,6,212,2,189,243,245,155,13,16,88,67,105,205,57,214,253,78,154,60,228,154,154,24,10,14,96,18,50,108,4,140,28,25,137,62,68,251,1,241,181,214,101,92,168,254,208,151,218,15,136,234,247,223,82,62,226,122,132,184,126,126,245,19,79,31,87,219,27,71,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("77a80f56-4b60-48bc-be27-e96ffd4cc59b"),
				ContainerUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
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
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bd8bab91-7c9c-4f46-a8ee-de69c8479c49"),
				ContainerUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
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
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeAddContactAdressParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("5a0a517a-3cd6-4838-89ed-dd198ad96f83"),
				ContainerUId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"EntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"d54d2218-61c8-413a-a1b7-5748c7e25f56",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dcf0939b-5ae1-4506-a7a2-453c0eb2f2d8"),
				ContainerUId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,75,111,219,70,16,254,43,129,206,217,100,223,15,223,18,39,109,13,180,137,81,7,57,36,202,97,159,14,81,74,20,72,42,173,107,248,191,119,72,201,138,100,203,234,138,72,98,181,182,15,178,180,152,157,157,7,191,225,204,183,151,35,95,218,166,121,99,39,113,116,52,122,121,250,219,89,149,218,103,63,21,101,27,235,159,235,106,62,27,61,29,53,177,46,108,89,252,29,195,98,253,117,40,218,87,182,181,176,225,114,252,117,255,120,116,52,222,166,97,60,122,58,30,21,109,156,52,32,1,27,140,212,52,250,144,144,80,158,34,110,164,65,154,121,142,88,140,129,81,73,146,23,122,33,185,93,245,113,53,153,217,58,46,78,232,149,167,254,235,187,139,89,39,72,96,193,247,34,69,83,77,151,139,172,51,161,121,61,181,174,140,1,126,183,245,60,194,82,91,23,19,240,36,190,43,38,241,212,214,112,82,167,167,234,150,64,40,217,178,233,164,202,152,218,215,127,205,234,216,52,69,53,221,109,90,57,159,76,215,101,97,123,92,253,92,26,131,123,11,59,201,83,219,126,238,21,156,128,81,87,189,141,47,206,207,235,120,110,219,226,203,186,9,127,196,139,94,46,47,118,176,33,64,126,222,219,114,30,215,206,220,244,227,216,206,218,133,59,139,227,65,160,46,206,63,103,122,186,138,214,191,57,75,97,113,118,45,156,165,113,171,253,84,194,226,151,110,97,161,227,250,235,120,244,241,164,121,251,231,52,214,103,254,115,156,216,69,196,62,61,131,213,27,11,43,253,71,151,132,97,236,4,139,136,26,233,17,215,66,67,20,165,134,120,50,27,60,21,86,113,127,245,105,97,71,209,204,74,123,241,126,117,220,175,209,134,101,184,186,127,176,162,149,210,90,82,138,168,11,160,67,25,141,76,226,24,49,79,136,181,216,59,97,28,100,23,254,96,143,38,6,91,147,60,50,58,56,196,73,82,72,71,16,198,62,146,196,189,33,73,44,61,220,27,87,81,18,138,83,178,40,40,23,16,15,130,33,27,133,65,142,17,238,29,143,142,58,185,75,245,201,244,46,72,241,255,34,164,94,132,208,201,44,4,114,176,149,23,191,45,207,38,217,13,174,165,33,79,218,94,186,131,89,76,177,142,83,31,23,79,232,202,229,13,139,111,195,177,75,243,199,131,1,100,239,244,26,32,151,96,224,73,59,26,164,66,138,4,140,184,72,14,105,163,34,242,129,91,134,181,53,202,227,94,223,234,184,95,170,238,203,154,178,61,148,220,66,231,66,25,64,237,83,15,54,78,188,74,81,163,164,120,4,156,39,210,129,205,32,236,180,99,65,81,226,49,222,137,136,230,205,188,44,239,66,5,221,134,10,242,127,67,69,94,12,127,32,42,138,62,41,203,208,118,30,112,197,18,20,110,130,56,235,158,150,164,8,50,152,129,133,204,8,71,53,81,78,239,236,39,30,122,221,203,139,223,99,221,219,89,247,146,83,150,37,105,81,98,210,33,194,9,70,50,105,130,136,151,73,138,40,48,227,108,179,238,189,156,55,197,20,18,117,163,246,101,43,186,85,251,190,42,188,174,127,198,56,78,137,98,136,59,11,216,21,74,33,139,121,64,12,170,105,162,193,99,235,249,35,50,118,116,219,89,241,123,68,198,78,100,40,137,93,146,26,250,108,39,35,10,137,16,228,140,214,8,99,18,36,142,134,105,47,55,145,241,42,150,144,143,250,226,6,50,178,21,221,66,198,87,133,61,50,58,104,148,213,121,225,109,249,118,22,107,200,126,95,138,239,120,117,111,188,17,186,41,164,174,170,246,198,59,170,27,10,250,163,87,111,205,172,54,191,51,132,65,123,73,104,50,40,50,120,188,184,48,22,233,238,131,4,161,109,148,28,106,112,24,56,16,72,40,22,48,206,40,68,189,131,97,209,82,140,64,165,65,12,86,163,210,86,37,226,190,113,251,67,15,252,229,120,92,205,167,109,255,32,100,188,24,243,226,183,63,252,87,70,236,232,122,214,101,86,29,79,111,96,103,121,74,140,42,45,128,6,176,48,165,64,135,6,83,138,182,20,121,65,1,12,58,122,108,252,3,203,236,239,241,188,23,207,73,108,94,248,246,79,236,89,11,110,63,159,213,213,151,2,50,186,51,191,215,230,110,77,175,149,78,71,35,37,2,26,1,170,7,237,58,50,160,118,16,21,148,123,226,184,51,226,161,165,247,67,49,203,203,109,94,236,182,229,118,103,106,63,156,156,62,159,85,77,107,203,39,190,10,241,142,196,113,25,188,165,148,160,160,147,0,10,193,0,133,224,140,71,158,51,78,140,182,4,202,255,3,75,220,113,209,102,150,219,188,224,13,40,183,189,5,187,106,237,181,192,237,132,58,42,36,236,34,136,37,193,129,31,140,20,57,14,35,176,37,86,192,220,228,185,99,241,129,37,116,57,95,230,229,52,47,126,123,163,113,101,195,237,164,253,128,230,46,175,101,187,203,18,252,13,45,161,212,36,195,129,185,198,142,74,232,139,129,122,214,138,38,48,135,90,166,130,18,222,192,176,120,5,119,56,93,124,207,170,121,237,151,247,38,205,226,242,102,208,181,204,61,92,183,236,115,135,178,245,22,35,135,6,61,148,59,135,239,123,175,48,232,198,224,30,104,177,65,92,215,29,148,249,144,236,111,140,179,185,156,244,222,196,243,61,48,202,3,73,196,193,172,235,227,179,147,199,233,237,77,218,61,6,54,143,18,250,158,156,207,126,20,206,32,114,230,30,90,198,1,84,202,112,138,226,64,253,219,36,20,134,143,232,7,234,222,218,64,61,124,138,61,80,223,214,103,206,225,19,221,129,58,247,98,115,254,250,33,195,207,119,155,101,174,70,87,255,0,28,13,127,191,130,38,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55cf3377-2bf5-4a73-8eb5-34e7b911258b"),
				ContainerUId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordAddMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			recordAddModeParameter.SourceValue = new ProcessSchemaParameterValue(recordAddModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,4,0,183,239,220,131,1,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("6d55db5f-8e6c-420b-9a07-be564e8b90da"),
				ContainerUId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"FilterEntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			filterEntitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(filterEntitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6aa29df7-9dcf-4eea-b7dd-70cbb55c6070"),
				ContainerUId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordDefValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordDefValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordDefValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,219,110,28,69,16,253,149,101,225,1,36,247,210,247,203,74,8,65,8,200,82,2,86,12,60,16,231,161,186,187,26,86,172,103,172,217,89,80,176,252,239,156,89,219,196,9,209,66,192,178,8,241,60,236,165,103,186,166,186,167,78,157,83,53,231,243,15,198,231,103,60,95,206,63,63,122,124,220,183,113,241,160,31,120,113,52,244,133,55,155,197,163,190,208,122,245,27,229,53,31,209,64,167,60,242,240,61,173,183,188,121,180,218,140,7,179,155,147,230,7,243,15,126,217,157,155,47,159,158,207,15,71,62,253,238,176,194,178,138,68,138,162,20,181,21,41,108,177,44,178,44,36,40,54,83,140,179,190,214,105,114,233,215,219,211,238,49,143,116,68,227,79,243,229,249,124,103,13,6,60,171,232,82,142,194,145,51,194,58,19,68,86,141,69,11,196,177,100,171,156,183,243,139,131,249,166,252,196,167,180,187,233,139,201,213,217,170,181,138,194,171,18,133,85,6,55,86,57,8,23,108,44,129,181,107,206,79,147,175,174,127,49,241,233,251,79,15,55,223,252,218,241,112,188,179,187,108,180,222,240,179,5,70,95,25,120,184,230,83,238,198,229,57,89,242,173,201,34,148,74,77,88,111,20,22,169,181,240,209,90,25,124,228,196,238,2,19,254,216,203,229,185,47,41,218,228,131,136,36,131,176,213,59,65,220,10,28,141,236,72,169,82,75,157,166,60,236,198,213,248,252,193,110,143,150,231,193,231,104,125,241,194,83,115,194,202,162,69,114,193,11,87,92,205,69,86,175,165,188,120,246,254,179,105,97,117,181,57,91,211,243,239,255,188,190,39,76,117,182,198,199,226,203,213,176,25,103,43,60,178,89,223,102,3,111,182,235,113,213,253,56,195,51,89,115,25,87,125,183,248,172,86,140,111,46,109,158,189,20,12,55,173,158,159,92,70,212,201,124,121,242,250,152,186,250,190,220,195,151,163,234,229,128,58,153,31,156,204,143,251,237,80,38,107,6,127,190,184,177,148,221,13,118,151,188,242,247,58,130,48,210,109,215,235,171,145,47,104,164,235,11,175,135,251,186,106,43,174,135,221,241,117,224,236,172,200,171,67,188,230,227,250,184,244,237,223,76,123,76,29,253,200,195,215,88,254,11,223,255,240,242,91,108,225,181,225,34,155,180,94,35,58,240,88,133,197,243,21,209,178,19,201,170,84,75,116,202,103,181,155,253,132,27,15,220,21,254,135,142,61,225,205,110,183,39,232,94,249,53,109,213,197,252,226,226,224,38,160,179,139,182,144,50,194,32,122,39,72,121,145,152,73,104,68,57,23,74,218,134,182,23,208,202,26,87,106,203,152,171,180,176,156,45,50,130,79,34,202,164,43,75,21,188,15,239,22,160,173,118,49,251,36,69,227,160,240,140,3,137,168,67,20,77,82,200,169,86,27,226,109,3,250,1,110,127,143,230,59,71,115,214,201,201,160,154,8,76,0,15,123,45,98,85,36,146,74,185,153,96,116,107,122,31,154,29,0,38,179,199,4,195,136,47,107,163,200,184,82,80,70,34,240,92,116,105,252,70,104,6,124,153,11,2,86,69,105,133,141,26,104,214,217,139,70,214,182,226,40,83,220,79,207,161,120,37,131,46,34,147,134,1,202,70,68,165,73,120,19,172,34,195,25,217,235,221,66,51,171,134,4,103,176,168,208,144,223,42,25,65,166,121,81,173,78,150,168,98,159,252,45,163,249,135,195,163,143,207,250,205,72,107,140,86,190,7,246,157,3,219,104,71,193,64,165,202,102,39,96,210,68,211,160,183,224,165,111,72,223,210,80,185,83,154,174,181,6,51,229,7,19,225,149,109,108,69,140,181,8,67,73,121,8,135,232,201,239,167,105,47,147,137,46,10,106,25,164,100,192,243,57,230,34,156,86,46,1,72,17,226,243,63,1,108,69,45,74,93,147,72,77,163,64,208,18,142,166,130,156,200,50,75,233,100,165,196,175,0,59,4,84,36,112,1,92,235,33,170,166,101,101,134,198,226,132,20,81,109,41,40,56,254,26,162,16,197,179,109,87,250,174,173,134,83,174,128,94,55,82,25,103,153,54,248,215,119,59,248,206,86,93,235,135,83,186,100,221,129,105,196,185,129,75,63,212,217,97,189,71,234,91,71,193,16,220,108,188,83,34,54,70,122,7,24,48,191,74,144,137,52,213,250,104,106,53,111,132,84,103,85,150,49,76,12,42,1,52,212,187,16,212,224,82,210,146,83,136,112,202,168,189,72,45,200,52,169,193,133,102,35,86,84,35,160,158,188,23,197,180,96,171,149,53,185,119,172,66,174,133,141,100,80,176,201,104,23,88,9,81,146,19,106,101,25,115,72,216,15,131,44,113,203,20,124,60,2,217,31,159,13,253,47,43,132,204,61,174,223,58,92,67,241,162,20,77,32,1,15,197,102,91,44,34,58,143,182,83,109,54,87,77,49,39,245,70,184,102,93,77,69,245,134,234,22,188,107,121,250,229,80,40,43,89,160,22,124,243,198,203,189,184,174,74,85,42,148,97,192,84,72,107,16,20,164,127,22,73,90,68,61,34,185,212,116,251,184,30,7,124,237,193,197,245,249,251,46,208,29,6,247,84,244,185,220,38,121,185,75,126,22,244,19,66,66,211,69,131,58,2,181,36,195,157,202,75,101,169,218,150,89,176,155,58,57,201,85,200,203,56,21,57,56,26,27,52,36,243,222,224,150,30,177,76,104,93,98,85,237,146,70,83,153,8,129,161,205,42,4,88,13,244,142,145,86,72,217,86,137,220,21,18,116,64,74,6,109,93,157,5,203,20,100,140,217,185,114,219,117,227,131,126,219,141,195,125,35,232,237,99,43,153,90,65,163,1,244,164,28,2,75,39,244,109,208,85,21,17,156,0,217,151,200,151,246,70,128,38,188,70,152,94,200,8,237,2,200,166,68,248,82,81,33,161,29,11,249,104,117,115,145,246,179,85,78,210,193,117,16,38,252,176,83,127,138,16,250,162,58,3,81,92,178,150,53,223,62,160,63,252,47,35,218,251,232,52,5,39,178,214,140,45,65,135,23,185,13,183,76,81,89,48,184,84,70,77,136,158,189,247,201,236,171,237,170,46,30,158,158,141,207,63,154,125,58,251,95,172,106,137,101,60,234,251,159,183,103,11,39,163,9,121,50,109,218,228,156,135,138,177,57,11,244,251,163,13,232,64,86,149,23,13,141,111,52,202,72,52,131,243,224,56,41,124,139,74,168,2,177,228,216,73,99,205,254,244,247,225,63,123,173,53,155,222,89,189,254,49,252,27,115,55,214,127,243,204,226,243,237,102,213,77,47,195,254,254,130,239,197,214,252,237,201,205,127,39,216,255,42,55,63,187,248,29,247,67,149,199,157,31,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b9f11eba-9282-49e7-842b-28c1d0f2190f"),
				ContainerUId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
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
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("03d86494-8865-4f33-baa9-734e477aa2f5"),
				ContainerUId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
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
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeAddContactWebParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("97a7e2ca-58ad-4a27-8a87-3f50772b77be"),
				ContainerUId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"EntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"004a9121-21f8-4a1e-8918-45c0f756ea41",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2f713b4e-bdb9-470a-b959-23af1cb99aaa"),
				ContainerUId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,84,93,111,211,48,20,253,47,121,158,167,196,118,190,250,6,163,160,74,176,85,234,52,30,232,30,110,108,167,181,112,154,200,78,6,165,234,127,231,38,105,75,135,186,146,33,193,150,151,36,71,231,126,29,95,159,141,39,12,56,119,13,133,242,70,222,219,233,167,89,153,215,151,239,181,169,149,253,96,203,166,242,46,60,167,172,6,163,127,40,217,227,99,169,235,119,80,3,6,108,230,191,226,231,222,104,126,42,195,220,187,152,123,186,86,133,67,6,6,228,50,98,34,207,3,34,130,32,39,60,145,64,82,154,115,18,101,153,72,211,212,231,148,182,185,158,76,125,85,22,21,88,213,87,232,146,231,221,231,237,186,106,137,1,2,162,163,104,87,174,118,32,107,91,112,227,21,100,70,73,252,175,109,163,16,170,173,46,112,18,117,171,11,53,5,139,149,218,60,101,11,33,41,7,227,90,150,81,121,61,254,94,89,229,156,46,87,231,91,51,77,177,58,230,98,184,58,252,238,154,241,187,14,91,230,20,234,101,151,96,130,77,109,187,30,223,44,22,86,45,160,214,15,199,45,124,85,235,142,55,76,59,12,144,120,62,119,96,26,117,84,243,241,28,87,80,213,253,56,125,121,36,88,189,88,14,156,244,160,214,159,134,165,8,86,123,242,160,140,39,251,167,17,130,15,45,208,231,216,127,206,189,47,19,119,243,109,165,236,76,44,85,1,189,98,247,151,136,254,6,28,242,143,54,1,243,253,44,100,138,208,52,18,168,98,152,144,132,69,9,225,41,3,41,104,8,49,23,219,251,190,15,237,42,3,235,187,67,185,143,10,228,78,174,246,133,72,228,211,40,19,49,35,34,225,64,120,150,225,153,132,192,73,146,37,129,164,52,227,60,20,120,186,248,96,12,75,20,149,9,231,132,2,229,132,11,145,144,84,66,64,88,76,41,203,121,44,152,12,206,169,52,113,215,141,49,79,237,62,61,181,251,244,149,239,254,103,149,57,180,135,97,23,96,152,126,39,22,40,56,123,1,176,135,222,166,58,121,247,117,187,19,51,229,66,11,48,55,149,178,176,227,251,167,21,125,116,20,237,190,218,178,172,251,45,60,168,213,174,79,87,105,63,80,26,251,12,132,207,9,228,97,74,56,77,129,36,17,195,21,138,19,33,101,232,71,84,48,148,6,109,184,157,104,86,54,86,236,172,207,245,254,251,87,206,250,2,142,249,28,27,60,105,68,67,172,229,181,216,198,191,181,134,23,184,243,234,249,23,249,191,220,164,173,183,253,9,136,15,48,255,195,8,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9021827f-1e50-40f2-8b7f-ec1b0e056ccb"),
				ContainerUId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordAddMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			recordAddModeParameter.SourceValue = new ProcessSchemaParameterValue(recordAddModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,4,0,183,239,220,131,1,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("aa2e3f7d-4042-4910-b0eb-0f5b57896d58"),
				ContainerUId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"FilterEntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			filterEntitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(filterEntitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7a98d7a0-39d9-4231-b19a-9c603fa6baf0"),
				ContainerUId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordDefValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordDefValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordDefValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,149,91,111,220,68,20,199,191,202,202,237,99,102,53,247,203,190,65,90,164,72,9,68,13,148,135,36,15,103,102,206,180,22,94,59,178,189,160,178,218,239,206,177,179,219,92,168,146,32,4,2,169,126,240,101,236,115,245,255,55,103,91,189,30,63,221,96,181,170,190,61,63,187,232,202,184,60,238,122,92,158,247,93,194,97,88,158,118,9,154,250,119,136,13,158,67,15,107,28,177,127,15,205,6,135,211,122,24,143,22,247,141,170,163,234,245,175,243,187,106,117,185,173,78,70,92,255,116,146,201,115,86,89,91,19,2,115,160,61,211,220,69,230,37,88,166,140,192,152,165,12,190,0,25,167,174,217,172,219,51,28,225,28,198,143,213,106,91,205,222,200,65,42,82,90,109,60,75,34,113,166,51,79,12,10,26,166,133,181,186,200,108,28,199,106,119,84,13,233,35,174,97,14,122,103,204,185,134,32,164,96,82,20,138,14,2,153,15,130,238,76,226,197,25,139,160,197,100,188,255,254,206,240,242,213,229,201,240,195,111,45,246,23,179,223,85,129,102,192,235,37,173,62,90,120,219,224,26,219,113,181,21,80,60,151,57,176,80,164,98,90,114,203,98,72,200,0,121,228,220,240,12,1,119,100,240,185,151,171,173,115,224,121,49,150,233,104,169,54,31,19,139,40,29,195,96,75,201,58,37,19,226,238,250,213,245,148,98,174,135,155,6,62,189,255,115,166,223,228,188,216,180,169,107,75,221,175,49,47,232,110,132,52,46,34,12,244,212,181,139,6,33,47,234,182,116,253,26,198,186,107,151,199,61,194,72,239,122,76,93,159,23,39,249,54,196,205,131,191,124,63,200,246,234,86,42,87,213,234,234,203,98,217,95,111,155,243,80,46,15,149,114,85,29,93,85,23,221,166,79,147,55,69,15,111,238,85,54,7,152,63,121,244,120,144,6,173,180,155,166,217,175,188,129,17,14,31,30,150,187,92,151,26,243,73,123,113,80,196,236,133,239,15,246,133,211,225,184,205,237,239,152,157,65,11,31,176,255,158,202,191,203,253,115,150,63,82,11,15,142,163,12,134,59,81,152,67,8,76,163,149,204,103,1,44,136,16,139,114,74,150,34,103,235,119,88,176,199,54,225,195,196,132,141,168,172,17,204,23,148,68,131,9,100,159,57,35,69,77,200,121,149,179,218,219,15,115,183,39,38,247,121,77,173,218,85,187,221,209,125,82,101,20,90,58,65,18,44,78,147,24,109,98,65,135,194,188,16,32,194,164,238,146,159,36,149,203,146,0,141,99,5,10,80,69,186,176,160,172,99,209,120,37,28,88,148,152,254,19,164,130,6,226,139,54,18,33,168,62,109,149,160,174,73,201,172,215,180,65,89,143,1,205,35,82,109,10,94,7,42,198,3,119,180,11,89,67,92,151,68,125,247,104,64,136,148,83,158,76,222,182,99,61,126,58,158,123,180,218,162,51,42,8,106,164,208,89,208,150,32,20,139,209,57,106,139,210,217,160,165,78,151,231,249,126,55,225,59,49,188,252,174,238,135,113,81,211,47,91,116,133,232,29,54,205,88,183,31,136,248,166,193,52,163,253,51,198,175,48,255,235,48,231,28,21,73,22,25,119,72,154,205,4,115,116,132,117,230,104,133,167,237,191,196,252,20,204,47,78,236,165,48,103,165,184,117,9,24,228,57,33,210,57,200,100,153,5,158,16,157,247,73,241,39,97,22,178,136,236,20,113,172,18,13,91,48,146,133,152,105,110,35,199,4,37,171,18,245,63,1,243,105,215,253,178,185,89,102,175,109,138,180,131,20,225,51,33,26,200,131,42,101,154,140,162,80,108,240,78,45,45,248,8,129,230,37,85,154,88,46,66,80,142,18,168,107,34,91,142,65,249,100,159,131,107,31,239,184,91,175,55,109,157,230,249,184,232,110,230,203,52,241,38,160,254,66,160,175,35,180,250,255,140,208,151,136,236,57,234,174,119,127,0,25,94,0,86,70,11,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("89ff5387-057a-41f9-a2cd-98c33da073a9"),
				ContainerUId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
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
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bc163fe7-1547-4a7a-9a04-4e4956124bae"),
				ContainerUId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
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
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeReadContactsByLeadEmailParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d6514abc-f96a-4d19-b5f8-f55b1ac00b83"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,75,111,219,70,16,254,43,130,78,45,144,53,118,185,203,229,82,183,214,85,11,31,154,24,117,144,75,228,195,62,102,101,162,124,8,36,149,70,21,244,223,51,75,82,178,156,208,170,226,54,181,11,84,7,129,28,206,204,126,179,243,205,99,59,181,185,110,154,215,186,128,233,108,250,227,245,175,55,149,111,47,126,206,242,22,234,95,234,106,189,154,190,154,54,80,103,58,207,254,4,215,203,231,46,107,127,210,173,70,131,237,226,222,126,49,157,45,198,60,44,166,175,22,211,172,133,162,65,13,52,208,52,117,160,35,71,226,88,59,34,12,151,68,167,210,18,233,180,16,49,151,82,50,213,107,142,187,158,127,204,154,182,233,15,232,124,251,238,241,237,102,21,244,98,20,216,170,88,233,58,107,170,114,16,178,32,205,154,121,169,77,14,14,5,109,189,6,20,181,117,86,96,36,240,54,43,224,90,215,120,82,112,84,5,17,42,121,157,55,65,43,7,223,206,63,174,106,104,154,172,42,79,65,187,172,242,117,81,30,235,162,57,28,94,7,52,180,131,24,52,175,117,123,215,57,120,127,89,149,173,182,237,101,85,20,235,50,179,186,69,245,217,32,188,189,184,66,204,187,46,132,31,150,203,26,150,248,249,3,220,135,241,59,108,58,47,231,221,44,26,56,204,222,59,157,175,225,8,209,195,40,47,245,42,64,232,220,14,48,38,246,24,220,164,234,20,38,223,153,205,164,15,102,50,232,125,223,29,209,172,77,159,162,33,235,95,77,147,56,245,60,17,206,144,36,82,154,8,202,83,98,120,196,136,246,78,209,84,58,31,89,119,58,23,129,4,240,24,79,216,24,79,248,11,167,201,235,117,97,66,48,99,92,216,195,216,147,225,188,251,27,33,67,164,78,178,97,143,1,149,234,108,121,119,102,200,135,107,251,171,168,35,20,174,246,202,103,121,28,15,66,162,240,67,16,244,62,246,143,88,106,87,205,155,63,74,168,111,236,29,20,186,191,182,219,11,148,126,38,152,231,80,64,217,206,182,90,104,233,61,181,132,177,212,19,33,57,222,161,138,34,34,149,16,52,145,10,82,136,119,104,112,0,52,219,74,155,42,145,202,132,40,77,19,34,156,140,137,6,111,137,96,10,98,205,152,117,214,5,147,121,217,102,237,166,167,195,108,235,1,120,228,20,35,9,68,130,8,205,5,73,153,77,8,167,138,131,112,34,229,202,239,110,251,112,179,102,149,235,205,187,67,84,191,129,118,147,28,255,176,164,234,166,157,132,66,154,84,126,130,151,187,206,219,172,92,134,34,205,193,134,52,94,204,11,157,229,157,159,208,88,208,218,202,8,40,165,134,112,133,52,9,189,2,79,142,17,131,229,82,249,84,25,19,51,100,29,254,208,134,179,20,64,240,4,85,16,171,48,30,136,118,81,74,40,143,57,149,248,49,50,250,84,226,174,202,199,106,82,252,23,107,242,65,203,238,213,206,41,207,243,110,113,132,217,236,116,179,238,181,190,44,206,208,85,223,191,152,242,236,130,56,42,207,129,135,0,204,170,216,114,98,189,53,196,121,198,72,106,34,77,40,101,78,82,192,2,176,178,243,119,56,238,158,202,247,21,126,182,151,47,170,104,240,134,60,191,237,168,158,87,75,76,108,254,102,5,117,151,222,129,1,35,116,124,192,227,208,123,234,170,106,251,142,114,192,58,54,227,59,28,123,78,24,233,172,6,225,137,75,5,150,97,228,57,49,76,122,146,168,56,193,94,110,210,136,211,14,221,183,130,246,0,141,230,128,92,100,2,143,103,10,209,48,68,67,169,39,220,196,70,33,74,101,192,35,26,92,16,67,118,111,170,117,109,135,105,219,244,155,225,147,118,190,231,88,230,254,193,13,237,243,181,231,73,11,205,51,44,42,95,187,125,140,142,254,115,186,197,255,131,250,5,14,234,103,152,194,127,99,180,62,50,217,158,194,62,118,60,135,206,157,28,255,230,116,248,166,205,126,55,221,125,2,223,107,38,133,0,16,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("881a211c-0037-4de8-9966-fd5b76082530"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1b0558b6-d02e-43db-a632-da912ff74169"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("38ac0d8a-57fb-4d3c-a724-83243171725c"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2306c9f4-91b3-4ae6-9d0d-b85b15f043a5"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("91e3ad56-02d2-495e-8f8d-6839c1e13901"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				UId = new Guid("09b2ffa0-b537-4970-bb51-a8da7fb89215"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,77,241,207,179,50,176,50,212,241,76,1,82,6,0,110,89,182,126,20,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("4e1e0793-a5ec-42a4-b7b6-dcf4eb1670ee"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f289649e-c0c3-403b-8124-ffe171aafe33"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				UId = new Guid("e7d2a1ae-2033-4d71-9990-c4c12f4faa89"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				UId = new Guid("681c5445-3ca2-45de-bf7c-0f37318944d1"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				UId = new Guid("95b392b6-a727-407b-a3ec-157c1314469b"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				UId = new Guid("0eadc500-3c91-49a1-8071-9d0668f51d38"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				UId = new Guid("849f1602-4ec0-45ef-a640-370b4ec656e7"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("847ce0c0-4e8f-4238-a637-16f20d906278"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1cfe3a33-faaf-4cb5-b49e-d1eadaa81bec"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,75,76,53,72,53,49,77,78,212,77,54,177,52,213,53,73,75,53,215,77,52,182,76,209,53,78,76,50,55,50,183,72,53,52,51,52,7,0,106,93,85,138,36,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f61ce3ad-7460-43d4-b04a-9a8735ba629d"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				UId = new Guid("98cf1789-f51a-4231-b152-7212be2cdca3"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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
				UId = new Guid("1921c84b-08d6-4bab-b0f8-1e4173f757ea"),
				ContainerUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
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

		protected virtual void InitializeChangeLeadContactEmailParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("788c3395-e8dc-443e-9c81-e57decd44c14"),
				ContainerUId = new Guid("f4434864-a2bf-4f22-bf0c-27c7e0c1e19c"),
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
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("40c79c51-5e3e-4a77-881f-bfb3b5148e9c"),
				ContainerUId = new Guid("f4434864-a2bf-4f22-bf0c-27c7e0c1e19c"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3da883c3-07af-4baf-9a48-e1f261dbd978"),
				ContainerUId = new Guid("f4434864-a2bf-4f22-bf0c-27c7e0c1e19c"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,47,62,87,69,252,21,89,185,109,93,54,4,216,214,0,41,122,169,123,160,37,218,17,102,199,134,164,116,203,130,252,247,81,118,146,165,67,208,102,187,172,190,88,122,120,124,124,164,200,109,32,107,176,246,43,52,24,76,130,247,243,47,139,182,116,215,31,117,237,208,124,50,237,186,11,174,2,139,70,67,173,127,162,26,240,169,210,238,3,56,160,128,109,254,59,62,15,38,249,57,133,60,184,202,3,237,176,177,196,160,0,94,134,5,72,94,48,16,49,178,4,185,100,25,200,136,149,10,69,4,10,98,145,148,3,243,188,244,77,219,116,96,112,200,208,139,151,253,241,110,211,121,98,72,128,236,41,218,182,171,61,24,123,11,118,186,130,162,70,69,119,103,214,72,144,51,186,161,74,240,78,55,56,7,67,153,188,78,235,33,34,149,80,91,207,170,177,116,211,31,157,65,107,117,187,122,217,90,189,110,86,167,92,10,199,227,117,111,102,212,59,244,204,57,184,101,47,48,35,83,187,222,227,187,170,50,88,129,211,79,167,22,190,225,166,231,93,214,59,10,80,244,62,247,80,175,241,36,231,243,58,110,160,115,67,57,67,122,34,24,93,45,47,172,244,216,173,215,138,141,8,236,14,228,139,20,207,250,143,198,4,62,121,96,208,56,28,243,224,97,102,111,191,175,208,44,228,18,27,24,58,246,120,77,232,31,192,81,127,178,13,227,209,168,72,169,129,145,24,75,150,100,105,198,178,120,156,177,68,196,160,100,148,2,79,228,238,113,240,161,109,87,195,230,254,152,238,51,130,218,183,203,255,8,137,198,169,80,60,225,172,64,37,88,34,35,82,227,94,28,5,64,17,197,89,90,2,189,174,255,252,35,180,149,150,80,223,118,104,232,145,251,38,143,206,15,231,179,169,246,229,155,182,117,67,81,199,230,121,55,189,151,195,128,136,80,1,207,20,13,72,56,230,44,9,67,193,10,49,74,89,153,112,201,147,56,46,82,65,3,178,163,173,246,29,94,180,107,35,247,155,100,135,117,254,167,69,253,15,11,248,55,91,117,118,174,47,153,212,183,50,133,179,183,50,105,187,96,247,11,3,221,56,119,50,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bec4aa50-4e70-47b5-99c8-d0f15b4b12f8"),
				ContainerUId = new Guid("f4434864-a2bf-4f22-bf0c-27c7e0c1e19c"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,110,219,48,12,253,21,67,237,49,10,36,91,182,36,31,215,118,64,128,118,11,154,173,151,38,7,74,162,90,3,142,93,216,202,134,44,200,191,79,118,146,182,233,122,155,14,182,69,241,61,146,207,79,59,114,25,182,47,72,74,242,101,126,183,104,125,152,94,181,29,78,231,93,107,177,239,167,183,173,133,186,250,3,166,198,57,116,176,198,128,221,3,212,27,236,111,171,62,76,146,247,32,50,33,151,191,198,51,82,62,238,200,44,224,250,231,204,69,102,235,172,202,89,90,80,167,188,161,34,85,156,130,97,57,77,25,20,133,227,41,104,110,34,216,182,245,102,221,220,97,128,57,132,103,82,238,200,200,22,9,192,9,205,92,174,40,203,5,80,225,84,78,117,42,34,159,83,162,40,208,100,90,101,100,63,33,189,125,198,53,140,69,223,192,130,131,87,26,53,149,57,139,213,209,24,170,44,88,234,125,166,77,33,148,224,104,7,240,49,255,13,248,120,241,56,235,191,255,110,176,91,140,188,165,135,186,199,213,52,70,63,4,110,106,92,99,19,202,29,178,20,165,98,138,42,153,106,42,172,150,212,104,38,41,23,74,250,20,185,76,165,218,71,192,171,150,229,78,32,71,38,117,70,33,71,27,197,1,65,141,52,113,54,235,99,175,188,144,12,113,128,220,52,161,10,219,171,81,163,114,7,200,80,228,22,168,21,58,167,194,163,164,144,105,71,51,48,67,13,228,5,151,251,213,197,106,24,204,85,253,75,13,219,135,127,231,187,71,112,137,109,27,95,117,107,28,191,2,216,208,39,102,155,212,195,81,156,177,170,167,95,171,174,15,73,21,127,103,210,250,164,195,126,83,135,170,121,138,233,117,141,54,84,109,51,157,185,67,169,151,51,143,188,47,182,91,30,140,182,36,229,242,115,171,29,223,7,105,207,205,118,238,179,37,153,44,201,162,221,116,118,96,203,226,230,250,221,132,99,129,49,229,195,246,100,172,24,105,54,117,125,140,92,67,128,83,226,41,220,186,202,87,232,102,205,226,228,167,145,133,29,23,253,228,113,90,135,222,254,7,118,7,13,60,97,247,45,142,255,214,251,107,151,63,162,132,39,98,147,234,156,73,238,169,68,136,102,195,34,165,202,113,160,154,107,227,51,153,165,222,167,35,250,30,61,118,216,88,60,111,140,23,6,179,34,231,84,121,76,169,224,185,142,120,199,40,40,150,57,81,168,204,185,236,136,239,71,181,135,27,125,236,107,144,106,79,246,251,213,254,47,246,205,96,123,65,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5211e1fa-3ffd-44d3-a820-58f034e21f3c"),
				ContainerUId = new Guid("f4434864-a2bf-4f22-bf0c-27c7e0c1e19c"),
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

		protected virtual void InitializeReadContactsByLeadPhoneParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55598db2-619f-4f92-a9b5-d03ddb173ed0"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,87,77,115,219,56,12,253,43,30,159,118,103,202,12,41,81,20,233,219,54,235,221,201,161,109,102,211,233,165,201,1,34,65,71,179,250,240,72,114,183,217,76,254,251,130,146,237,36,141,146,117,210,166,241,33,62,120,100,24,132,0,16,15,120,184,156,218,2,218,246,61,148,56,157,77,223,30,191,59,169,125,119,240,71,94,116,216,252,217,212,171,229,244,205,180,197,38,135,34,255,23,221,32,159,187,188,251,29,58,160,3,151,167,215,231,79,167,179,211,49,11,167,211,55,167,211,188,195,178,37,13,58,160,37,112,149,42,205,18,155,100,76,138,20,25,160,79,152,53,58,139,61,7,231,184,31,52,199,77,207,191,230,109,215,14,47,232,109,251,254,241,227,197,50,232,37,36,176,117,185,132,38,111,235,106,45,20,65,154,183,243,10,178,2,29,9,186,102,133,36,234,154,188,164,72,240,99,94,226,49,52,244,166,96,168,14,34,82,242,80,180,65,171,64,223,205,191,46,27,108,219,188,174,30,114,237,176,46,86,101,117,83,151,142,227,246,231,218,27,222,187,24,52,143,161,59,239,13,124,62,172,171,14,108,119,88,151,229,170,202,45,116,164,62,91,11,207,14,142,200,231,171,62,132,223,22,139,6,23,244,247,23,188,14,227,111,188,232,173,236,150,89,58,224,232,246,62,65,177,194,27,30,221,142,242,16,150,193,133,222,236,218,141,137,189,233,220,164,238,21,38,191,100,23,147,33,152,201,90,239,215,254,21,237,42,27,174,104,125,235,143,46,147,56,86,128,105,150,48,29,113,207,100,20,113,166,51,110,25,112,17,203,36,78,36,183,234,137,166,163,76,68,104,189,101,34,5,206,164,143,13,211,70,70,244,36,189,246,14,101,10,241,195,215,28,234,11,239,43,65,49,86,130,241,158,87,224,251,85,153,133,96,198,202,108,227,198,166,206,118,203,223,72,157,69,250,193,66,219,248,64,74,77,190,56,223,49,228,109,218,254,47,234,136,132,203,141,242,78,22,199,131,80,36,252,18,4,131,141,205,35,161,248,168,253,240,79,133,205,137,61,199,18,134,180,157,29,144,244,27,193,188,192,18,171,110,118,9,18,148,247,84,212,66,24,170,113,21,11,6,58,138,152,210,82,114,2,50,26,76,174,232,192,214,161,217,165,34,48,75,163,82,166,129,167,76,58,149,4,140,91,66,187,198,4,132,176,206,186,112,100,94,117,121,119,49,148,195,236,210,72,136,65,39,49,227,218,82,103,208,137,167,27,243,146,9,29,233,84,67,2,128,217,213,217,16,110,222,46,11,184,248,180,141,234,47,4,55,41,232,139,32,213,180,221,36,0,105,82,251,9,37,119,85,116,121,181,8,248,47,208,134,107,60,120,187,106,243,138,178,62,89,158,215,21,246,6,67,243,34,51,146,71,104,20,149,74,8,139,92,16,146,101,206,71,4,106,136,93,154,114,4,163,169,252,232,67,103,50,103,141,243,228,160,231,113,168,48,3,76,167,177,98,96,45,133,233,141,64,31,172,190,34,244,30,132,238,150,191,87,132,238,15,66,37,247,232,133,51,204,27,250,146,145,164,203,50,52,248,98,109,48,74,20,128,117,242,135,32,244,93,157,229,5,222,197,39,38,25,151,105,76,126,90,5,76,6,222,144,101,17,176,196,8,26,190,142,98,141,252,128,207,0,208,162,94,16,17,40,62,44,177,233,233,192,122,236,141,76,184,91,163,49,180,206,166,174,187,33,221,219,198,59,198,126,122,223,54,245,188,27,25,8,142,165,81,148,26,37,18,150,58,136,153,204,194,108,210,128,140,178,43,45,160,49,148,199,135,58,199,81,117,223,88,151,99,99,93,238,249,88,191,149,210,65,109,151,9,191,91,22,71,250,135,120,152,74,14,90,119,231,123,32,102,159,247,102,194,247,65,220,152,240,27,132,160,176,58,177,49,35,234,147,49,231,133,96,38,32,132,115,225,20,71,19,235,80,132,116,116,251,186,121,9,121,209,139,174,73,194,206,86,238,192,124,109,141,0,120,118,31,6,249,51,98,208,197,180,62,164,129,67,40,106,128,52,192,35,150,113,157,49,45,99,154,40,40,4,177,191,222,187,231,114,237,150,55,222,74,229,148,225,44,53,130,42,148,114,202,136,208,40,166,173,72,28,119,70,25,147,146,55,180,190,134,219,61,169,87,141,93,19,246,118,216,91,159,180,145,190,196,170,249,3,247,199,111,151,178,39,173,91,79,90,164,94,96,65,122,236,214,51,186,114,236,210,98,94,23,132,125,94,16,94,43,111,191,87,211,87,226,123,103,232,62,142,199,190,0,73,253,14,230,121,15,241,123,74,159,21,55,105,218,174,196,234,103,146,167,103,229,66,87,211,171,255,0,19,77,156,224,189,23,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("519549f0-c248-40b5-be93-602f4ff55bac"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c1675f40-4a8b-469f-807f-482b441e6236"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8aacc82f-451e-44f0-a1ea-c48fac82b9aa"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1a7cefdb-8943-464e-9818-f056350796f1"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a45be9e6-9a59-46ac-b1b7-9def07669d0c"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				UId = new Guid("6b161822-7e93-4124-b2d6-c1605b5f5657"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,77,241,207,179,50,180,50,212,241,76,177,50,176,50,0,0,80,50,116,145,20,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("97881864-f21d-4f49-b39f-662c780efdc9"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("83016a9c-a67e-4328-a96e-bfacfc2c77c6"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				UId = new Guid("a0d9ba4a-555e-4324-ae31-f59d0233fbc6"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				UId = new Guid("5b48e127-d50b-49a3-8459-4a9a52bf6988"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				UId = new Guid("6ef7572f-4836-4cfe-ad97-3868281a4281"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				UId = new Guid("ce2e72d3-d7a5-4f50-9ecf-44b4bf27b6ea"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				UId = new Guid("98faeefc-cf3f-4be3-a9b9-40bd344629d3"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("e75f4ff2-ebaa-43f4-aff7-36f8fa2f00cd"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1a5f9685-0340-43a4-85bd-917ac7f8b75a"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,75,76,53,72,53,49,77,78,212,77,54,177,52,213,53,73,75,53,215,77,52,182,76,209,53,78,76,50,55,50,183,72,53,52,51,52,7,0,106,93,85,138,36,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4a757dc8-11a2-46d0-962c-01dc9f7cf05c"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				UId = new Guid("d1a04b45-329c-4e0c-90b8-b7463582c944"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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
				UId = new Guid("822209b4-c7f7-4d36-9ddf-32a904b93bda"),
				ContainerUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
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

		protected virtual void InitializeChangeLeadContactPhoneParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("cfc1a8ae-2a77-49bb-a728-a1637ee8c94a"),
				ContainerUId = new Guid("1fe66c39-e645-4115-bb1f-6f62f33d667f"),
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
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5feb2bce-5433-4c25-a83d-3f8d28ccc8ab"),
				ContainerUId = new Guid("1fe66c39-e645-4115-bb1f-6f62f33d667f"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9acd36f8-ce89-4f92-bdb8-e4eea778daf4"),
				ContainerUId = new Guid("1fe66c39-e645-4115-bb1f-6f62f33d667f"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,201,110,219,48,16,253,23,157,195,64,251,226,91,155,186,133,129,182,49,224,32,151,40,135,17,57,146,137,106,3,73,167,117,13,255,123,135,146,236,58,133,145,184,189,52,190,88,124,120,243,230,205,182,115,120,13,90,127,133,6,157,153,243,126,249,101,213,149,230,250,163,172,13,170,79,170,219,244,206,149,163,81,73,168,229,79,20,35,62,23,210,124,0,3,20,176,203,127,199,231,206,44,63,167,144,59,87,185,35,13,54,154,24,54,32,142,60,215,243,129,165,158,240,88,88,8,159,101,152,209,51,73,2,17,138,56,43,128,79,204,179,210,55,93,211,131,194,49,195,32,94,14,159,119,219,222,18,61,2,248,64,145,186,107,39,48,176,22,244,188,133,162,70,65,111,163,54,72,144,81,178,161,74,240,78,54,184,4,69,153,172,78,103,33,34,149,80,107,203,170,177,52,243,31,189,66,173,101,215,190,108,173,222,52,237,41,151,194,241,248,156,204,184,131,67,203,92,130,89,15,2,11,50,181,31,60,190,171,42,133,21,24,249,116,106,225,27,110,7,222,101,189,163,0,65,243,185,135,122,131,39,57,159,215,113,3,189,25,203,25,211,19,65,201,106,125,97,165,199,110,189,86,172,79,96,127,32,95,164,120,214,191,31,19,248,100,129,81,227,240,153,59,15,11,125,251,189,69,181,226,107,108,96,236,216,227,53,161,127,0,71,253,217,206,11,92,183,136,2,100,126,22,115,22,166,81,202,210,32,78,89,152,5,32,184,31,65,18,242,253,227,232,67,234,190,134,237,253,49,221,103,4,49,181,203,254,17,18,165,113,193,41,132,121,34,160,153,148,162,96,128,152,48,95,120,94,88,38,1,247,179,146,166,107,127,118,8,93,37,57,212,183,61,42,26,242,208,100,247,252,114,62,219,106,91,190,234,58,51,22,117,108,158,117,51,120,57,44,72,192,139,194,13,162,136,65,226,39,44,20,60,97,84,105,204,162,40,2,215,139,5,162,176,171,70,87,109,59,188,234,54,138,79,151,164,199,115,254,167,67,253,15,7,248,55,87,117,118,175,47,217,212,183,178,133,139,183,178,105,123,103,255,11,92,62,159,190,50,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("15555f52-d536-4815-a506-977a98d2f0f3"),
				ContainerUId = new Guid("1fe66c39-e645-4115-bb1f-6f62f33d667f"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,114,155,48,16,253,21,70,201,209,242,0,18,66,226,216,36,157,241,76,210,122,226,54,23,219,135,149,180,74,152,193,224,1,185,29,151,241,191,87,96,59,137,211,220,170,3,160,213,190,183,187,143,167,158,92,251,253,22,73,65,190,204,31,22,141,243,211,155,166,197,233,188,109,12,118,221,244,190,49,80,149,127,64,87,56,135,22,54,232,177,125,130,106,135,221,125,217,249,73,244,30,68,38,228,250,215,120,70,138,101,79,102,30,55,63,103,54,48,115,151,43,39,172,164,130,51,75,185,86,41,149,66,74,138,54,49,74,104,165,193,201,0,54,77,181,219,212,15,232,97,14,254,133,20,61,25,217,2,1,88,174,98,155,73,26,103,28,40,183,50,163,42,229,130,90,43,185,16,168,153,146,140,28,38,164,51,47,184,129,177,232,27,152,39,129,94,161,162,121,22,107,202,81,107,42,13,24,234,28,83,90,112,201,19,52,3,248,148,255,6,92,94,45,103,221,247,223,53,182,139,145,183,112,80,117,184,158,134,232,135,192,93,133,27,172,125,209,39,12,117,156,115,70,83,151,37,148,75,193,169,114,25,134,70,83,30,131,150,22,117,122,8,128,87,45,139,94,229,82,38,67,162,75,147,32,142,227,138,134,121,28,21,34,53,185,140,209,89,163,6,200,93,237,75,191,191,25,53,42,122,192,24,121,102,128,26,174,178,128,194,156,2,83,150,50,208,121,154,75,76,68,146,31,214,87,235,97,48,91,118,219,10,246,79,255,206,247,136,96,35,211,212,174,108,55,56,126,121,48,190,139,244,62,170,134,163,237,75,83,99,55,253,90,182,157,143,202,240,63,163,198,69,45,118,187,202,151,245,115,200,175,42,52,190,108,234,233,204,30,107,109,47,76,242,190,90,191,58,58,109,69,138,213,231,94,59,189,143,218,94,186,237,210,104,43,50,89,145,69,179,107,205,192,198,194,230,246,221,136,99,129,49,229,195,246,236,172,16,169,119,85,117,138,220,130,135,115,226,57,220,216,210,149,104,103,245,226,108,168,145,37,62,45,250,201,227,188,142,189,253,15,236,1,106,120,198,246,91,24,255,173,247,215,46,127,4,9,207,196,58,85,89,156,39,142,230,8,42,56,91,132,123,101,19,160,42,81,218,177,156,165,206,165,35,250,17,29,182,88,27,188,108,44,17,26,153,8,70,149,14,83,202,147,76,5,188,141,41,200,152,89,46,36,179,150,157,240,221,168,246,112,165,79,125,13,82,29,200,225,176,62,252,5,61,151,41,130,66,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("99d9c01e-8ac9-41e6-a4ee-12e2c816886a"),
				ContainerUId = new Guid("1fe66c39-e645-4115-bb1f-6f62f33d667f"),
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

		protected virtual void InitializeChangeDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("3719e46d-8e08-48ad-8083-1ccf953996c6"),
				ContainerUId = new Guid("01cee34b-f51b-441d-9110-09e5174d899d"),
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
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("08550f59-4992-48fb-b252-df02ec268766"),
				ContainerUId = new Guid("01cee34b-f51b-441d-9110-09e5174d899d"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("44584732-acad-4754-bde4-a1b1cfd19199"),
				ContainerUId = new Guid("01cee34b-f51b-441d-9110-09e5174d899d"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,47,62,87,133,163,15,199,238,109,235,178,33,192,182,6,72,209,75,221,3,109,209,137,48,59,54,36,165,91,22,228,191,143,178,147,44,29,130,45,219,101,245,197,210,195,227,227,35,69,110,163,178,6,231,62,67,131,209,77,244,118,246,105,222,86,254,250,189,169,61,218,15,182,93,119,209,85,228,208,26,168,205,119,212,3,62,209,198,191,3,15,20,176,205,127,198,231,209,77,126,78,33,143,174,242,200,120,108,28,49,40,160,26,67,33,52,87,12,146,132,51,137,201,152,65,137,192,70,73,204,149,228,99,41,160,24,152,231,165,111,219,166,3,139,67,134,94,188,234,143,247,155,46,16,71,4,148,61,197,184,118,181,7,69,176,224,38,43,40,106,212,116,247,118,141,4,121,107,26,170,4,239,77,131,51,176,148,41,232,180,1,34,82,5,181,11,172,26,43,63,249,214,89,116,206,180,171,223,91,171,215,205,234,148,75,225,120,188,238,205,196,189,195,192,156,129,95,246,2,83,50,181,235,61,190,89,44,44,46,192,155,231,83,11,95,112,211,243,46,235,29,5,104,122,159,7,168,215,120,146,243,101,29,183,208,249,161,156,33,61,17,172,89,44,47,172,244,216,173,63,21,203,9,236,14,228,139,20,207,250,231,9,129,207,1,24,52,14,199,60,122,156,186,187,175,43,180,243,114,137,13,12,29,123,186,38,244,23,224,168,127,179,29,137,56,46,148,64,198,179,164,100,50,85,41,75,69,146,50,153,9,208,37,87,48,150,229,238,105,240,97,92,87,195,230,225,152,238,35,130,222,183,43,252,8,41,64,129,202,100,193,84,86,41,38,85,154,177,66,142,72,173,74,99,21,75,16,177,10,175,27,190,240,8,237,194,148,80,223,117,104,233,145,251,38,199,231,135,243,197,84,135,242,109,219,250,161,168,99,243,130,155,222,203,97,64,180,44,116,60,230,130,169,74,105,26,16,160,81,225,153,96,92,11,172,116,154,41,41,131,25,218,234,208,225,121,187,182,229,126,147,220,176,206,255,180,168,255,97,1,255,102,171,206,206,245,37,147,250,90,166,112,250,90,38,109,23,237,126,0,131,107,171,191,50,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("33aca163-6ecf-4e71-9484-09432fbc4746"),
				ContainerUId = new Guid("01cee34b-f51b-441d-9110-09e5174d899d"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,203,110,219,48,16,252,21,129,201,209,52,40,241,33,81,183,54,233,193,64,210,26,117,154,75,236,195,146,92,54,2,244,8,40,185,69,106,232,223,75,203,118,18,167,185,149,7,73,187,228,204,206,174,134,59,114,57,60,63,33,41,201,231,229,237,170,243,195,252,170,11,56,95,134,206,98,223,207,111,58,11,117,245,7,76,141,75,8,208,224,128,225,30,234,45,246,55,85,63,204,146,183,32,50,35,151,191,166,61,82,62,236,200,98,192,230,199,194,69,102,37,51,229,100,174,41,151,206,82,129,194,82,192,212,83,198,61,207,172,52,185,147,34,130,109,87,111,155,246,22,7,88,194,240,72,202,29,153,216,34,1,56,161,153,147,5,101,82,0,21,174,144,84,103,66,81,231,10,161,20,26,174,11,78,198,25,233,237,35,54,48,21,125,5,139,20,124,161,81,211,92,50,19,171,27,67,11,11,150,122,207,181,81,162,16,41,218,61,248,120,254,21,248,112,241,176,232,191,253,110,49,172,38,222,210,67,221,227,102,30,179,239,18,95,106,108,176,29,202,221,190,20,203,156,166,218,103,156,138,140,41,106,180,197,216,46,51,140,73,230,64,227,24,1,47,179,44,119,121,14,5,243,82,81,97,20,163,162,48,150,26,204,114,138,90,121,239,132,181,82,155,113,115,177,217,75,116,85,255,84,195,243,253,191,74,63,57,151,108,91,219,181,190,10,13,186,36,126,13,96,135,196,64,31,163,174,77,106,4,151,84,173,239,66,3,67,213,181,243,171,128,48,196,189,128,182,11,46,89,184,67,137,167,179,191,252,182,200,110,125,176,202,154,148,235,143,205,114,124,31,134,115,110,151,115,167,172,201,108,77,86,221,54,216,61,27,143,193,245,155,206,166,2,211,145,119,225,201,26,49,211,110,235,250,152,185,134,1,78,7,79,233,206,85,190,66,183,104,87,39,71,76,44,236,184,232,7,143,211,58,104,251,31,216,45,180,240,19,195,215,216,254,171,246,23,149,119,113,132,39,98,147,105,201,242,120,19,114,4,29,173,169,50,90,184,20,168,78,181,241,60,231,153,247,217,132,254,142,30,3,182,22,207,133,165,202,32,87,50,165,133,199,140,138,84,234,136,119,140,70,71,113,39,84,193,157,227,71,124,63,77,123,127,39,143,186,246,163,26,201,56,110,198,191,60,2,99,206,3,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cb50f943-4702-4fd8-9aa9-5698a33e9475"),
				ContainerUId = new Guid("01cee34b-f51b-441d-9110-09e5174d899d"),
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

		protected virtual void InitializeReadLandingPageParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cd3fabe0-1945-4d5e-9fb8-9e85ee54cc3b"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,212,48,16,253,43,171,156,235,42,159,142,179,55,40,219,170,18,208,138,86,229,192,246,48,177,199,169,69,190,228,120,11,203,106,255,59,227,164,93,90,180,192,194,5,36,114,136,146,167,55,227,55,31,207,155,64,214,48,12,111,161,193,96,30,188,188,124,115,213,105,119,124,106,106,135,246,204,118,171,62,56,10,6,180,6,106,243,5,213,132,47,148,113,175,192,1,5,108,150,223,226,151,193,124,185,47,195,50,56,90,6,198,97,51,16,131,2,64,203,172,148,2,89,172,50,197,82,149,199,12,202,188,96,153,44,17,49,12,117,25,249,92,63,76,125,210,53,61,88,156,78,24,147,235,241,243,122,221,123,98,68,128,28,41,102,232,218,7,48,241,18,134,69,11,101,141,138,254,157,93,33,65,206,154,134,42,193,107,211,224,37,88,58,201,231,233,60,68,36,13,245,224,89,53,106,183,248,220,91,28,6,211,181,63,151,86,175,154,246,41,151,194,113,247,251,32,38,28,21,122,230,37,184,187,49,193,57,137,218,142,26,95,84,149,197,10,156,185,127,42,225,35,174,71,222,97,189,163,0,69,243,185,129,122,133,79,206,124,94,199,9,244,110,42,103,58,158,8,214,84,119,7,86,186,235,214,175,138,141,9,236,31,201,7,101,220,171,63,230,4,222,123,96,202,241,248,185,12,62,156,15,23,159,90,180,87,242,14,27,152,58,118,123,76,232,119,192,162,198,6,91,55,223,64,10,92,235,80,178,40,42,52,75,121,18,49,16,113,204,184,72,211,48,231,2,11,204,182,20,176,19,52,223,112,89,136,180,224,57,19,16,230,212,118,158,49,64,45,89,26,9,204,32,138,164,146,202,135,44,90,103,220,122,218,130,249,166,72,68,161,98,81,48,158,8,206,82,65,1,69,169,50,22,203,76,228,113,146,196,156,199,219,219,169,92,51,244,53,172,111,118,85,189,67,80,179,154,94,228,36,59,184,153,247,207,172,211,51,106,238,170,118,166,173,102,180,65,53,74,63,194,227,215,208,42,15,245,80,77,211,247,243,164,36,58,10,57,151,28,153,14,75,100,105,158,112,38,84,30,177,60,194,176,204,75,142,137,230,180,119,254,241,235,209,85,70,66,125,209,163,165,245,27,199,31,238,183,205,51,191,249,193,216,174,115,83,187,119,99,61,67,154,9,249,72,189,199,242,180,179,205,168,235,113,141,169,43,192,19,157,49,228,97,72,157,145,33,3,73,195,16,97,138,66,103,145,68,158,145,48,186,123,252,30,92,117,43,43,31,252,62,76,151,206,31,93,39,127,225,154,248,29,239,239,117,223,33,126,250,207,188,114,254,47,46,247,54,216,126,5,24,117,213,240,75,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c84ed90e-913c-4d79-be6e-0aeb6dbde695"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("528b68b1-c488-499b-b6a9-98d627973317"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7db9bc2b-3431-4feb-8af1-b2fcbc5cf552"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("50c50a69-929a-4ae1-8501-1657483ac91c"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5a09f02d-d645-448c-a427-3dc0ad363ad0"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				UId = new Guid("2793b917-606e-429f-8d6b-56caf9a5d36b"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				UId = new Guid("a435ea7f-ecdc-4500-acc1-f4ab6e8b2a76"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e0010511-9818-4608-8cc6-966c057c7fb7"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				UId = new Guid("5ce1ad73-33d5-4d54-99dc-103fe2185918"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				UId = new Guid("f1d51e05-81e8-439e-be55-ef17ce69d451"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				UId = new Guid("5400d0e0-9171-4da4-9833-ee4bc440d882"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				UId = new Guid("fe6f5c9f-37df-4b0d-b855-65847152e915"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				UId = new Guid("ec12f3b9-746c-4f92-ba49-ce658079412a"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				ReferenceSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				UId = new Guid("6dc416c9-504c-4429-b04e-93f543f173c4"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b66e4485-d571-44cb-9e32-b832c83541ca"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1c52f53d-1e03-445c-bcbe-0982a59c336a"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				UId = new Guid("aadf92c2-302e-499d-a17e-33c74ef006bd"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
				UId = new Guid("b3f6ea08-bb3d-48ff-bb96-9f7e3530b585"),
				ContainerUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
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
			ProcessSchemaLaneSet schemaLeadIdentificationProcess = CreateLeadIdentificationProcessLaneSet();
			LaneSets.Add(schemaLeadIdentificationProcess);
			ProcessSchemaLane schemaLeadIdentification = CreateLeadIdentificationLane();
			schemaLeadIdentificationProcess.Lanes.Add(schemaLeadIdentification);
			ProcessSchemaStartEvent start = CreateStartStartEvent();
			FlowElements.Add(start);
			ProcessSchemaTerminateEvent leadisidentified = CreateLeadIsIdentifiedTerminateEvent();
			FlowElements.Add(leadisidentified);
			ProcessSchemaUserTask readleaddata = CreateReadLeadDataUserTask();
			FlowElements.Add(readleaddata);
			ProcessSchemaExclusiveGateway exclusiveleadhascommunication = CreateExclusiveLeadHasCommunicationExclusiveGateway();
			FlowElements.Add(exclusiveleadhascommunication);
			ProcessSchemaTerminateEvent leaddisqualified = CreateLeadDisqualifiedTerminateEvent();
			FlowElements.Add(leaddisqualified);
			ProcessSchemaUserTask readcontactsbyleadcommunications = CreateReadContactsByLeadCommunicationsUserTask();
			FlowElements.Add(readcontactsbyleadcommunications);
			ProcessSchemaUserTask changeleadcontactall = CreateChangeLeadContactAllUserTask();
			FlowElements.Add(changeleadcontactall);
			ProcessSchemaUserTask addcontactbylead = CreateAddContactByLeadUserTask();
			FlowElements.Add(addcontactbylead);
			ProcessSchemaUserTask addcontactadress = CreateAddContactAdressUserTask();
			FlowElements.Add(addcontactadress);
			ProcessSchemaUserTask addcontactweb = CreateAddContactWebUserTask();
			FlowElements.Add(addcontactweb);
			ProcessSchemaParallelGateway parallelgatewayaddcontactcommunication = CreateParallelGatewayAddContactCommunicationParallelGateway();
			FlowElements.Add(parallelgatewayaddcontactcommunication);
			ProcessSchemaParallelGateway parallelgateway1 = CreateParallelGateway1ParallelGateway();
			FlowElements.Add(parallelgateway1);
			ProcessSchemaUserTask readcontactsbyleademail = CreateReadContactsByLeadEmailUserTask();
			FlowElements.Add(readcontactsbyleademail);
			ProcessSchemaUserTask changeleadcontactemail = CreateChangeLeadContactEmailUserTask();
			FlowElements.Add(changeleadcontactemail);
			ProcessSchemaExclusiveGateway exclusiveinleadcommunication = CreateExclusiveInLeadCommunicationExclusiveGateway();
			FlowElements.Add(exclusiveinleadcommunication);
			ProcessSchemaUserTask readcontactsbyleadphone = CreateReadContactsByLeadPhoneUserTask();
			FlowElements.Add(readcontactsbyleadphone);
			ProcessSchemaUserTask changeleadcontactphone = CreateChangeLeadContactPhoneUserTask();
			FlowElements.Add(changeleadcontactphone);
			ProcessSchemaUserTask changedatausertask1 = CreateChangeDataUserTask1UserTask();
			FlowElements.Add(changedatausertask1);
			ProcessSchemaExclusiveGateway exclusivegatewayisleadset = CreateExclusiveGatewayIsLeadSetExclusiveGateway();
			FlowElements.Add(exclusivegatewayisleadset);
			ProcessSchemaScriptTask actionafteridentificationscripttask = CreateActionAfterIdentificationScriptTaskScriptTask();
			FlowElements.Add(actionafteridentificationscripttask);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask readlandingpage = CreateReadLandingPageUserTask();
			FlowElements.Add(readlandingpage);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			FlowElements.Add(CreateContactFoundAllConditionalFlow());
			FlowElements.Add(CreateContactNotFoundAllSequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateSequenceFlow15SequenceFlow());
			FlowElements.Add(CreateSequenceFlow16SequenceFlow());
			FlowElements.Add(CreateSequenceFlow17SequenceFlow());
			FlowElements.Add(CreateConditionalFlowCommunicationAllConditionalFlow());
			FlowElements.Add(CreateConditionalFlowEmailOnlyConditionalFlow());
			FlowElements.Add(CreateContactFoundEmailConditionalFlow());
			FlowElements.Add(CreateSequenceFlow18SequenceFlow());
			FlowElements.Add(CreateSequenceFlow20SequenceFlow());
			FlowElements.Add(CreateConditionalFlowPhonesOnlyConditionalFlow());
			FlowElements.Add(CreateCntactFoundPhoneConditionalFlow());
			FlowElements.Add(CreateContactNotFoundEmailSequenceFlow());
			FlowElements.Add(CreateContactNotFoundPhoneSequenceFlow());
			FlowElements.Add(CreateSequenceFlow22SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow19SequenceFlow());
			FlowElements.Add(CreateSequenceFlowLeadDefinedSequenceFlow());
			FlowElements.Add(CreateSequenceFlowLeadReadSequenceFlow());
			FlowElements.Add(CreateConditionalFlowLeadUndefinedConditionalFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateIsNotFromLandingFlowConditionalFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateDontContactFlowConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow3SequenceFlow());
		}

		protected virtual ProcessSchemaConditionalFlow CreateContactFoundAllConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ContactFoundAll",
				UId = new Guid("e86cf8b0-28a2-4a9b-b145-adf2cced025e"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{55827a3c-5bec-4f5a-bf98-793768421b33}].[Parameter:{10568b26-1c18-4f39-9578-4a72a1c5fb66}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(743, 206),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d21d53d2-a563-4394-aad1-8db8c7558606"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateContactNotFoundAllSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "ContactNotFoundAll",
				UId = new Guid("de6d680f-d07c-44e0-bad0-0e782cd4ab9d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(663, 272),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("685ffe7e-d19d-424d-af66-eab647e50e57"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(827, 406),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(890, 317),
				SequenceFlowStartPointPosition = new Point(840, 317),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5d0b6b6a-1a92-4477-a8f6-7922798ad8b7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("ac04a55d-ac74-402d-bd4c-e1838bf4708c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(942, 299),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1009, 317),
				SequenceFlowStartPointPosition = new Point(945, 317),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5d0b6b6a-1a92-4477-a8f6-7922798ad8b7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("520f849c-7cf5-482e-8278-85ac18ec9297"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(952, 407),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1009, 408),
				SequenceFlowStartPointPosition = new Point(918, 344),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5d0b6b6a-1a92-4477-a8f6-7922798ad8b7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(918, 408));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("18317a84-4d39-4605-b176-feb243f51a99"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(1086, 544),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1135, 317),
				SequenceFlowStartPointPosition = new Point(1078, 317),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5c0463a9-9ea1-464a-b52e-096674f01418"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow15SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow15",
				UId = new Guid("f6a451c0-89fd-4ccc-ab61-d3c20b1a0644"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(1086, 594),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1163, 344),
				SequenceFlowStartPointPosition = new Point(1078, 408),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5c0463a9-9ea1-464a-b52e-096674f01418"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1163, 408));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow16SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow16",
				UId = new Guid("09a82fde-8ba3-4a5d-9cc0-6aecd8a4bd9b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(1165, 236),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1226, 317),
				SequenceFlowStartPointPosition = new Point(1190, 317),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5c0463a9-9ea1-464a-b52e-096674f01418"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("01cee34b-f51b-441d-9110-09e5174d899d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow17SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow17",
				UId = new Guid("7441390e-adc4-42b8-a095-363e9352da36"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(1012, 302),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1376, 161),
				SequenceFlowStartPointPosition = new Point(892, 71),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d21d53d2-a563-4394-aad1-8db8c7558606"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a4c733cc-151e-47ad-8dde-04d288bd539f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1376, 71));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowCommunicationAllConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowCommunicationAll",
				UId = new Guid("146a48af-ec3c-47df-b53d-49db5dfca733"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a4a6ff0c-119f-4631-a822-68440768e9e5}].[Parameter:{6c984967-8a07-4d65-aefc-418e5a11cdcd}].[EntityColumn:{fee32d81-7e24-4a34-91c7-3083e4d4938f}]#] != String.Empty && ([#[IsOwnerSchema:false].[IsSchema:false].[Element:{a4a6ff0c-119f-4631-a822-68440768e9e5}].[Parameter:{6c984967-8a07-4d65-aefc-418e5a11cdcd}].[EntityColumn:{40fef1d9-f9d9-4246-a90f-389e256aacd4}]#] != String.Empty || [#[IsOwnerSchema:false].[IsSchema:false].[Element:{a4a6ff0c-119f-4631-a822-68440768e9e5}].[Parameter:{6c984967-8a07-4d65-aefc-418e5a11cdcd}].[EntityColumn:{94a3a853-08cb-485f-89f4-182878a5aaeb}]#] != String.Empty)",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(564, 112),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("63c2f821-e43f-4368-83f1-e2bda2505f5b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(560, 71));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowEmailOnlyConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowEmailOnly",
				UId = new Guid("94e08796-33d0-450f-a94d-43d4d8c7e5b4"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a4a6ff0c-119f-4631-a822-68440768e9e5}].[Parameter:{6c984967-8a07-4d65-aefc-418e5a11cdcd}].[EntityColumn:{fee32d81-7e24-4a34-91c7-3083e4d4938f}]#] != String.Empty && [#[IsOwnerSchema:false].[IsSchema:false].[Element:{a4a6ff0c-119f-4631-a822-68440768e9e5}].[Parameter:{6c984967-8a07-4d65-aefc-418e5a11cdcd}].[EntityColumn:{40fef1d9-f9d9-4246-a90f-389e256aacd4}]#] == String.Empty && [#[IsOwnerSchema:false].[IsSchema:false].[Element:{a4a6ff0c-119f-4631-a822-68440768e9e5}].[Parameter:{6c984967-8a07-4d65-aefc-418e5a11cdcd}].[EntityColumn:{94a3a853-08cb-485f-89f4-182878a5aaeb}]#] == String.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(568, 220),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("63c2f821-e43f-4368-83f1-e2bda2505f5b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateContactFoundEmailConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ContactFoundEmail",
				UId = new Guid("8ad3bb27-05b3-4197-85fe-9fca6ddb677c"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{e02e7808-8729-4c97-b907-1487f2e17278}].[Parameter:{4e1e0793-a5ec-42a4-b7b6-dcf4eb1670ee}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(672, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f4434864-a2bf-4f22-bf0c-27c7e0c1e19c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow18SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow18",
				UId = new Guid("d616bcad-397a-4fb0-9ad7-a6b4eecacb7a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(1082, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1348, 189),
				SequenceFlowStartPointPosition = new Point(892, 189),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f4434864-a2bf-4f22-bf0c-27c7e0c1e19c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a4c733cc-151e-47ad-8dde-04d288bd539f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow20SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow20",
				UId = new Guid("04aca506-6521-4495-8b71-07a6e4990984"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(1288, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1451, 189),
				SequenceFlowStartPointPosition = new Point(1403, 189),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a4c733cc-151e-47ad-8dde-04d288bd539f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("823adfbf-968a-44dc-be40-33f3ac4421f9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowPhonesOnlyConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowPhonesOnly",
				UId = new Guid("421b74c1-62c2-430b-965d-8d776c88a27f"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a4a6ff0c-119f-4631-a822-68440768e9e5}].[Parameter:{6c984967-8a07-4d65-aefc-418e5a11cdcd}].[EntityColumn:{fee32d81-7e24-4a34-91c7-3083e4d4938f}]#] == String.Empty && ([#[IsOwnerSchema:false].[IsSchema:false].[Element:{a4a6ff0c-119f-4631-a822-68440768e9e5}].[Parameter:{6c984967-8a07-4d65-aefc-418e5a11cdcd}].[EntityColumn:{40fef1d9-f9d9-4246-a90f-389e256aacd4}]#] != String.Empty || [#[IsOwnerSchema:false].[IsSchema:false].[Element:{a4a6ff0c-119f-4631-a822-68440768e9e5}].[Parameter:{6c984967-8a07-4d65-aefc-418e5a11cdcd}].[EntityColumn:{94a3a853-08cb-485f-89f4-182878a5aaeb}]#] != String.Empty)",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(465, 286),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(665, 490),
				SequenceFlowStartPointPosition = new Point(587, 189),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("63c2f821-e43f-4368-83f1-e2bda2505f5b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(626, 189));
			schemaFlow.PolylinePointPositions.Add(new Point(626, 490));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateCntactFoundPhoneConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "CntactFoundPhone",
				UId = new Guid("9bfd01fc-78f4-4b49-a5a3-0359fc93fab2"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{13eb0743-2f51-4864-9f5e-dd240ab8deb2}].[Parameter:{97881864-f21d-4f49-b39f-662c780efdc9}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(668, 412),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(823, 490),
				SequenceFlowStartPointPosition = new Point(734, 490),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1fe66c39-e645-4115-bb1f-6f62f33d667f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateContactNotFoundEmailSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "ContactNotFoundEmail",
				UId = new Guid("42aea126-6049-4745-ad69-161540c3e406"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(670, 378),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(771, 317),
				SequenceFlowStartPointPosition = new Point(700, 216),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(700, 317));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateContactNotFoundPhoneSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "ContactNotFoundPhone",
				UId = new Guid("df707572-c541-4e4e-862e-378909dd23f7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(670, 438),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(771, 317),
				SequenceFlowStartPointPosition = new Point(700, 462),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(700, 317));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow22SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow22",
				UId = new Guid("4d08fda8-cd6a-41a3-93c1-ea29843a1dd8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(1004, 269),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1376, 216),
				SequenceFlowStartPointPosition = new Point(892, 490),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1fe66c39-e645-4115-bb1f-6f62f33d667f"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a4c733cc-151e-47ad-8dde-04d288bd539f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1376, 490));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("730e6ac4-b34e-4059-a3b7-fdb00cfe6b88"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(130, 176),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(72, 189),
				SequenceFlowStartPointPosition = new Point(35, 189),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e4f191bb-2078-469f-a22b-36763fc3b878"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b9aa1247-b371-4815-926c-3b34166d62ce"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow19SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow19",
				UId = new Guid("d51e9369-1e01-464b-b9e0-a5a76570f27f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(1295, 314),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1376, 216),
				SequenceFlowStartPointPosition = new Point(1295, 317),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("01cee34b-f51b-441d-9110-09e5174d899d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a4c733cc-151e-47ad-8dde-04d288bd539f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1376, 317));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlowLeadDefinedSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlowLeadDefined",
				UId = new Guid("809c0113-c2cd-4fc6-81a2-709589e406ae"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(322, 190),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(160, 189),
				SequenceFlowStartPointPosition = new Point(127, 189),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b9aa1247-b371-4815-926c-3b34166d62ce"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlowLeadReadSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlowLeadRead",
				UId = new Guid("39aa9aa5-0e89-45d2-ab91-45a36ea7120a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(393, 188),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(254, 189),
				SequenceFlowStartPointPosition = new Point(229, 189),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f5bceb61-c764-4125-8416-472d42e1cb8c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowLeadUndefinedConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowLeadUndefined",
				UId = new Guid("86bf0460-da87-44e8-9e19-16d6bb74396c"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{1300b53e-296c-4858-8368-493adc25a74c}]#] == Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(468, 408),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(722, 592),
				SequenceFlowStartPointPosition = new Point(100, 216),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b9aa1247-b371-4815-926c-3b34166d62ce"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f4df356b-d95c-43bc-a856-f9efad105482"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(100, 592));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("820777f0-a887-4f88-bf50-9a94194c500e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("574c9bf8-30b5-4eb9-aa34-ee8fc5cac038"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(1423, 214),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(1583, 189),
				SequenceFlowStartPointPosition = new Point(1520, 189),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("823adfbf-968a-44dc-be40-33f3ac4421f9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c634d34a-9984-4a62-a5cf-c01049fca1c0"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateIsNotFromLandingFlowConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "IsNotFromLandingFlow",
				UId = new Guid("b15dccc1-cb8b-4db6-9245-c999d8b93476"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a4a6ff0c-119f-4631-a822-68440768e9e5}].[Parameter:{6c984967-8a07-4d65-aefc-418e5a11cdcd}].[EntityColumn:{9389d289-6386-48fc-9bd5-2c5872332662}]#] == Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70885459-eb74-4f01-8b36-f019cf6455dd"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f5bceb61-c764-4125-8416-472d42e1cb8c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f4df356b-d95c-43bc-a856-f9efad105482"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(282, 589));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("20f61163-eea7-47a5-b9f2-2e0896ee1530"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70885459-eb74-4f01-8b36-f019cf6455dd"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4003d719-b518-4975-b6e0-f769d615e6b4"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateDontContactFlowConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "DontContactFlow",
				UId = new Guid("6e54dca1-2410-4933-8d29-b9c06c6eb9c5"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{17eaa635-03e6-4644-8e7d-7a81a8f837a6}].[Parameter:{a435ea7f-ecdc-4500-acc1-f4ab6e8b2a76}].[EntityColumn:{7e336bc1-838f-48c6-a4d7-6f5bb3930bb2}]#] == false",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70885459-eb74-4f01-8b36-f019cf6455dd"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4003d719-b518-4975-b6e0-f769d615e6b4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f4df356b-d95c-43bc-a856-f9efad105482"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(471, 589));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("d4060814-2d0d-4e64-93e2-903d9f427c42"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70885459-eb74-4f01-8b36-f019cf6455dd"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("63c2f821-e43f-4368-83f1-e2bda2505f5b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f4df356b-d95c-43bc-a856-f9efad105482"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(560, 589));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("ba39820c-a979-4d6a-9f26-dab9940fce00"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70885459-eb74-4f01-8b36-f019cf6455dd"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f5bceb61-c764-4125-8416-472d42e1cb8c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow3",
				UId = new Guid("704f89d9-2ad0-404e-8ce3-94ce9f308188"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70885459-eb74-4f01-8b36-f019cf6455dd"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4003d719-b518-4975-b6e0-f769d615e6b4"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("63c2f821-e43f-4368-83f1-e2bda2505f5b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLeadIdentificationProcessLaneSet() {
			ProcessSchemaLaneSet schemaLeadIdentificationProcess = new ProcessSchemaLaneSet(this) {
				UId = new Guid("bc24ba6a-fa71-49d5-8e0e-37de1a155822"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"LeadIdentificationProcess",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLeadIdentificationProcess;
		}

		protected virtual ProcessSchemaLane CreateLeadIdentificationLane() {
			ProcessSchemaLane schemaLeadIdentification = new ProcessSchemaLane(this) {
				UId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("bc24ba6a-fa71-49d5-8e0e-37de1a155822"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"LeadIdentification",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLeadIdentification;
		}

		protected virtual ProcessSchemaStartEvent CreateStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("e4f191bb-2078-469f-a22b-36763fc3b878"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"Start",
				Position = new Point(4, 173),
				SerializeToDB = false,
				Size = new Size(31, 31),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateLeadIsIdentifiedTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("c634d34a-9984-4a62-a5cf-c01049fca1c0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"LeadIsIdentified",
				Position = new Point(1583, 173),
				SerializeToDB = false,
				Size = new Size(31, 31),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadLeadDataUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ReadLeadData",
				Position = new Point(160, 161),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadLeadDataParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveLeadHasCommunicationExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("63c2f821-e43f-4368-83f1-e2bda2505f5b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ExclusiveLeadHasCommunication",
				Position = new Point(532, 161),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaTerminateEvent CreateLeadDisqualifiedTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("f4df356b-d95c-43bc-a856-f9efad105482"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"LeadDisqualified",
				Position = new Point(722, 576),
				SerializeToDB = false,
				Size = new Size(31, 31),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadContactsByLeadCommunicationsUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ReadContactsByLeadCommunications",
				Position = new Point(665, 43),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadContactsByLeadCommunicationsParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeLeadContactAllUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d21d53d2-a563-4394-aad1-8db8c7558606"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ChangeLeadContactAll",
				Position = new Point(823, 43),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeLeadContactAllParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddContactByLeadUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"AddContactByLead",
				Position = new Point(771, 289),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddContactByLeadParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddContactAdressUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"AddContactAdress",
				Position = new Point(1009, 380),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddContactAdressParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddContactWebUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"AddContactWeb",
				Position = new Point(1009, 289),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddContactWebParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaParallelGateway CreateParallelGatewayAddContactCommunicationParallelGateway() {
			ProcessSchemaParallelGateway gateway = new ProcessSchemaParallelGateway(this) {
				UId = new Guid("5d0b6b6a-1a92-4477-a8f6-7922798ad8b7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("e9e1e6de-7066-4eb1-bbb4-5b75b13d4f56"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ParallelGatewayAddContactCommunication",
				Position = new Point(890, 289),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaParallelGateway CreateParallelGateway1ParallelGateway() {
			ProcessSchemaParallelGateway gateway = new ProcessSchemaParallelGateway(this) {
				UId = new Guid("5c0463a9-9ea1-464a-b52e-096674f01418"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("e9e1e6de-7066-4eb1-bbb4-5b75b13d4f56"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ParallelGateway1",
				Position = new Point(1135, 289),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadContactsByLeadEmailUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ReadContactsByLeadEmail",
				Position = new Point(665, 161),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadContactsByLeadEmailParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeLeadContactEmailUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("f4434864-a2bf-4f22-bf0c-27c7e0c1e19c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ChangeLeadContactEmail",
				Position = new Point(823, 161),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeLeadContactEmailParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveInLeadCommunicationExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("a4c733cc-151e-47ad-8dde-04d288bd539f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ExclusiveInLeadCommunication",
				Position = new Point(1348, 161),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadContactsByLeadPhoneUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ReadContactsByLeadPhone",
				Position = new Point(665, 462),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadContactsByLeadPhoneParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeLeadContactPhoneUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("1fe66c39-e645-4115-bb1f-6f62f33d667f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ChangeLeadContactPhone",
				Position = new Point(823, 462),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeLeadContactPhoneParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("01cee34b-f51b-441d-9110-09e5174d899d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ChangeDataUserTask1",
				Position = new Point(1226, 289),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayIsLeadSetExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("b9aa1247-b371-4815-926c-3b34166d62ce"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ExclusiveGatewayIsLeadSet",
				Position = new Point(72, 161),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaScriptTask CreateActionAfterIdentificationScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("823adfbf-968a-44dc-be40-33f3ac4421f9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("574c9bf8-30b5-4eb9-aa34-ee8fc5cac038"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ActionAfterIdentificationScriptTask",
				Position = new Point(1451, 161),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,115,76,46,201,204,207,115,76,43,73,45,242,76,73,205,43,201,76,203,76,78,4,9,105,104,90,243,114,21,165,150,148,22,229,41,148,20,149,166,90,3,0,0,140,232,210,42,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("f5bceb61-c764-4125-8416-472d42e1cb8c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70885459-eb74-4f01-8b36-f019cf6455dd"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ExclusiveGateway1",
				Position = new Point(254, 161),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadLandingPageUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70885459-eb74-4f01-8b36-f019cf6455dd"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ReadLandingPage",
				Position = new Point(340, 161),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadLandingPageParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("4003d719-b518-4975-b6e0-f769d615e6b4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("4f0d97bf-6f5d-40cc-b57c-23e715671755"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70885459-eb74-4f01-8b36-f019cf6455dd"),
				CreatedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505"),
				Name = @"ExclusiveGateway2",
				Position = new Point(443, 161),
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
				UId = new Guid("10509a8f-ce1f-49d4-9a6e-2dbe803346be"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("574c9bf8-30b5-4eb9-aa34-ee8fc5cac038")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("5d1dacad-ecaf-4a19-8976-6e14d8694860"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("574c9bf8-30b5-4eb9-aa34-ee8fc5cac038")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LeadManagementIdentification(userConnection);
		}

		public override object Clone() {
			return new LeadManagementIdentificationSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50c67976-474a-4cfb-b066-5ca727be0505"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadManagementIdentification

	/// <exclude/>
	public class LeadManagementIdentification : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLeadIdentification

		/// <exclude/>
		public class ProcessLeadIdentification : ProcessLane
		{

			public ProcessLeadIdentification(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ReadLeadDataFlowElement

		/// <exclude/>
		public class ReadLeadDataFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadLeadDataFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadLeadData";
				IsLogging = true;
				SchemaElementUId = new Guid("a4a6ff0c-119f-4631-a822-68440768e9e5");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,211,64,16,253,47,62,119,43,123,189,206,218,189,65,9,40,18,208,72,169,122,169,123,24,239,78,146,21,118,108,237,110,10,33,202,127,103,214,78,66,138,34,8,92,168,47,182,159,222,188,121,243,181,141,84,13,206,125,134,6,163,155,232,237,244,211,172,157,251,235,247,166,246,104,63,216,118,221,69,87,145,67,107,160,54,223,81,15,248,88,27,255,14,60,80,192,182,252,25,95,70,55,229,57,133,50,186,42,35,227,177,113,196,160,0,145,86,40,242,24,24,38,42,102,66,73,193,114,45,129,197,50,209,69,194,121,156,171,116,96,158,151,190,109,155,14,44,14,25,122,241,121,255,121,191,233,2,49,33,64,245,20,227,218,213,30,76,131,5,55,94,65,85,163,166,127,111,215,72,144,183,166,161,74,240,222,52,56,5,75,153,130,78,27,32,34,205,161,118,129,85,227,220,143,191,117,22,157,51,237,234,247,214,234,117,179,58,229,82,56,30,127,247,102,226,222,97,96,78,193,47,123,129,9,153,218,245,30,223,44,22,22,23,224,205,243,169,133,47,184,233,121,151,245,142,2,52,205,231,1,234,53,158,228,124,89,199,45,116,126,40,103,72,79,4,107,22,203,11,43,61,118,235,79,197,114,2,187,3,249,34,197,179,254,249,136,192,231,0,12,26,135,207,50,122,156,184,187,175,43,180,51,181,196,6,134,142,61,93,19,250,11,112,212,191,217,38,105,28,87,89,138,140,23,35,197,68,158,229,44,79,71,57,19,69,10,90,241,12,164,80,187,167,193,135,113,93,13,155,135,99,186,143,8,122,223,174,240,34,68,206,53,207,176,42,104,18,177,100,66,138,17,171,84,86,177,52,65,153,112,0,173,1,104,186,225,9,67,104,23,70,65,125,215,161,165,33,247,77,142,207,47,231,139,173,14,229,219,182,245,67,81,199,230,5,55,189,151,195,130,112,76,42,37,179,130,129,148,180,32,57,79,88,5,156,179,84,101,137,168,180,40,98,168,200,12,93,117,232,240,172,93,91,181,191,36,55,156,243,63,29,234,127,56,192,191,185,170,179,123,125,201,166,190,150,45,156,188,150,77,219,69,187,31,115,35,247,46,50,6,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,73,77,76,241,75,204,77,181,50,180,50,212,241,76,177,50,176,50,0,0,197,68,70,233,19,0,0,0 })));
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
								new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"));
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
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,21,83,201,13,4,33,12,171,40,82,46,114,104,170,9,4,250,47,97,179,31,94,198,248,194,109,135,218,49,176,122,11,20,15,67,46,55,88,103,245,62,216,198,136,159,89,44,46,95,176,153,47,168,36,66,69,63,208,12,210,211,27,73,232,75,45,169,88,2,24,103,131,198,122,16,249,20,40,56,60,106,85,221,253,41,175,216,54,247,223,117,2,221,94,16,236,1,15,203,119,118,171,7,126,97,235,110,158,251,146,58,32,150,7,165,7,225,120,136,138,69,121,189,175,61,183,54,38,168,231,128,50,101,132,243,134,139,233,24,177,215,58,246,29,127,155,18,47,44,234,0,61,182,160,198,23,28,113,210,150,141,245,252,211,40,60,106,244,119,167,160,175,70,248,237,11,231,138,245,146,122,42,247,139,44,196,126,4,210,50,160,50,129,45,122,128,211,163,207,243,139,117,63,186,113,177,55,1,46,244,17,118,55,164,31,31,166,237,145,138,82,213,223,82,52,63,79,128,228,159,56,55,65,212,75,72,60,182,187,143,187,203,231,135,135,43,18,106,215,184,179,225,220,18,6,19,64,96,178,119,123,124,239,94,225,14,2,191,127,225,53,194,146,230,57,193,144,171,173,41,241,190,201,232,28,89,9,114,39,81,13,58,176,163,10,136,252,148,109,158,96,237,227,229,69,194,4,79,87,15,200,2,246,83,133,155,143,199,161,25,181,124,117,241,234,58,5,71,115,132,79,131,80,146,13,82,219,167,195,75,70,254,85,197,161,105,102,6,242,102,5,28,10,59,45,33,30,45,19,44,94,247,124,35,44,155,199,157,253,61,105,188,3,185,123,1,159,21,206,34,108,198,95,163,237,202,41,99,10,153,231,124,166,80,230,12,151,150,214,93,70,149,250,41,190,251,168,19,94,206,161,172,6,149,56,203,137,188,188,172,234,180,126,247,58,7,183,1,203,12,68,53,223,184,243,13,180,155,47,61,177,90,241,105,45,247,191,103,155,54,231,35,52,194,166,23,48,129,241,121,182,198,41,125,245,186,78,209,140,26,103,143,234,230,127,208,228,52,98,83,173,101,42,255,122,134,131,87,2,100,203,159,105,207,84,114,44,96,108,79,236,20,101,252,174,15,35,217,129,217,225,127,227,52,160,237,14,41,162,189,174,141,192,247,253,197,173,51,76,230,143,65,187,100,18,127,6,173,60,191,173,186,198,239,15,157,239,2,19,193,3,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ReadContactsByLeadCommunicationsFlowElement

		/// <exclude/>
		public class ReadContactsByLeadCommunicationsFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadContactsByLeadCommunicationsFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadContactsByLeadCommunications";
				IsLogging = true;
				SchemaElementUId = new Guid("55827a3c-5bec-4f5a-bf98-793768421b33");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,75,115,219,70,12,254,43,26,157,218,153,172,103,223,220,245,173,113,213,78,14,121,76,157,201,37,246,97,31,88,155,83,138,212,144,84,90,215,163,255,94,144,148,101,59,145,93,218,117,106,37,149,14,28,121,141,5,1,236,247,97,1,232,114,26,10,215,52,111,220,28,166,135,211,151,239,94,31,87,169,61,248,37,47,90,168,127,173,171,229,98,250,98,218,64,157,187,34,255,11,226,176,62,139,121,251,179,107,29,110,184,60,185,222,127,50,61,60,217,166,225,100,250,226,100,154,183,48,111,80,2,55,104,74,29,5,13,68,129,182,68,198,164,136,23,81,17,22,77,230,99,50,194,248,52,72,110,87,61,251,51,111,218,102,120,65,175,59,245,95,223,95,44,58,57,133,11,161,154,47,92,157,55,85,185,94,100,221,106,222,204,74,231,11,136,184,208,214,75,192,165,182,206,231,232,9,188,207,231,240,206,213,248,166,78,81,213,45,161,80,114,69,211,73,21,144,218,217,159,139,26,154,38,175,202,251,76,59,170,138,229,188,188,41,139,219,97,243,231,218,26,218,155,216,73,190,115,237,121,175,224,227,81,85,182,46,180,71,213,124,190,44,243,224,90,20,63,92,47,158,30,188,66,155,87,189,11,63,157,157,213,112,134,255,254,4,215,110,252,14,23,189,150,113,145,197,13,17,79,239,131,43,150,112,195,162,219,94,30,185,69,103,66,175,118,109,198,36,220,52,110,82,245,2,147,31,252,197,100,112,102,178,150,251,177,127,69,179,244,195,17,173,79,253,193,48,161,50,73,237,66,70,188,100,156,72,221,57,195,181,38,44,112,198,13,128,114,94,220,127,22,29,8,224,46,156,176,109,56,17,59,14,147,55,203,185,239,156,217,134,133,43,51,174,192,48,46,126,91,192,192,205,189,104,184,178,1,133,234,252,236,124,164,203,155,176,253,147,215,28,23,23,87,194,163,52,110,119,66,227,226,167,110,97,208,113,245,21,169,246,170,121,251,71,9,245,113,56,135,185,27,194,118,122,128,171,159,45,204,10,152,67,217,30,94,58,233,116,74,52,16,198,108,194,64,10,70,156,225,156,104,35,37,205,180,1,11,106,133,27,54,6,29,94,234,96,141,180,58,35,198,209,12,137,168,21,113,144,2,145,204,96,220,25,11,49,196,110,203,172,108,243,246,98,128,195,225,101,2,16,60,26,70,50,224,146,72,39,36,177,12,15,80,80,35,64,70,105,133,73,171,211,193,221,188,89,20,238,226,195,198,171,223,192,197,73,129,15,164,84,221,180,147,142,72,147,42,77,48,184,203,162,205,203,179,142,164,5,132,238,24,15,102,115,151,23,189,158,46,177,224,110,48,193,39,165,40,97,144,34,145,20,83,136,1,205,9,21,44,147,2,18,130,7,177,178,194,15,238,97,218,242,204,26,77,192,107,140,135,151,129,56,11,140,80,138,102,123,206,88,130,236,190,131,123,85,222,197,73,249,45,114,242,86,202,30,196,198,208,115,92,20,183,32,155,221,159,172,7,169,47,201,217,101,213,143,59,67,207,222,137,27,244,188,194,33,176,96,84,16,36,164,224,73,76,140,17,235,185,195,160,176,168,41,32,1,130,238,245,109,94,119,13,229,107,134,143,214,242,5,139,214,218,16,231,167,61,212,139,234,12,15,182,120,187,128,186,63,222,53,2,182,192,241,22,142,187,220,83,87,85,59,100,148,141,173,219,238,248,222,142,77,202,142,134,171,64,45,137,142,98,202,150,34,35,86,34,68,152,5,39,20,139,92,201,174,16,232,44,139,65,176,32,68,36,222,40,133,140,181,156,56,42,128,80,207,131,50,204,121,231,228,190,136,122,76,17,53,46,178,223,72,17,149,130,192,155,8,44,209,78,211,174,8,72,196,51,105,137,0,227,84,138,9,203,194,240,88,213,194,139,204,196,140,100,73,249,14,172,130,96,38,51,36,104,176,18,68,136,70,175,201,189,175,207,182,93,0,227,226,183,175,207,118,167,62,147,52,65,98,209,146,100,241,33,185,212,120,101,211,68,132,177,192,149,118,46,68,249,36,245,217,235,202,231,5,76,22,231,85,57,64,96,125,61,234,68,133,230,248,70,136,20,11,68,234,209,83,142,249,73,114,19,121,247,13,73,189,41,211,60,77,76,153,228,136,210,30,173,85,224,137,143,88,87,226,165,232,4,77,26,1,214,105,221,243,243,142,2,109,92,252,246,252,220,29,126,90,108,153,156,81,130,80,108,103,136,52,42,17,99,147,36,204,112,147,33,53,156,3,255,36,252,124,185,108,242,18,175,248,47,25,170,50,107,133,215,140,40,76,237,68,90,99,137,7,45,145,166,194,74,133,31,25,250,10,110,117,87,121,201,190,98,121,57,174,24,232,12,147,22,203,30,239,29,17,146,33,246,33,80,236,7,241,17,144,10,38,58,231,180,85,79,216,226,201,239,179,197,27,23,197,125,139,247,127,106,241,146,76,6,7,111,138,100,54,195,4,145,5,108,251,141,164,132,27,108,242,116,100,150,41,28,209,174,190,158,105,183,172,9,84,107,155,113,65,98,166,176,140,240,8,78,231,153,39,88,207,56,192,132,32,121,192,33,196,10,127,3,232,154,157,227,106,89,135,245,64,181,25,134,255,143,26,235,63,199,188,254,9,135,240,159,55,101,143,154,89,63,195,44,250,161,3,230,173,211,221,49,3,161,253,44,118,7,103,177,207,48,104,253,23,87,235,29,195,203,199,160,239,214,168,113,236,205,241,95,222,14,15,156,231,125,191,217,115,252,176,234,81,99,168,125,202,221,237,159,191,190,215,241,202,30,119,187,141,187,253,216,96,219,165,244,160,41,192,51,180,248,251,226,226,120,92,113,241,21,59,201,213,116,245,55,194,251,125,4,64,38,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,77,241,207,179,50,180,50,212,241,76,177,50,176,50,0,0,80,50,116,145,20,0,0,0 })));
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
								new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"));
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
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,75,76,53,72,53,49,77,78,212,77,54,177,52,213,53,73,75,53,215,77,52,182,76,209,53,78,76,50,55,50,183,72,53,52,51,52,7,0,106,93,85,138,36,0,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ChangeLeadContactAllFlowElement

		/// <exclude/>
		public class ChangeLeadContactAllFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeLeadContactAllFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeLeadContactAll";
				IsLogging = true;
				SchemaElementUId = new Guid("d21d53d2-a563-4394-aad1-8db8c7558606");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifiedContact = () => (Guid)(((process.ReadContactsByLeadCommunications.ResultEntity.IsColumnValueLoaded(process.ReadContactsByLeadCommunications.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadContactsByLeadCommunications.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifiedContact", () => _recordColumnValues_QualifiedContact.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifiedContact;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,47,62,87,133,63,99,59,183,173,203,134,0,219,26,32,69,47,117,15,148,68,39,194,236,216,144,228,110,89,144,255,62,202,78,178,116,48,218,108,151,53,7,199,126,120,36,31,201,199,157,39,42,48,230,43,212,232,77,189,247,139,47,203,166,180,215,31,85,101,81,127,210,77,215,122,87,158,65,173,160,82,63,81,14,248,76,42,251,1,44,80,192,174,248,29,95,120,211,98,44,67,225,93,21,158,178,88,27,98,80,0,231,24,136,180,148,76,136,40,103,177,240,51,150,167,9,103,8,0,156,203,36,18,16,13,204,241,212,55,77,221,130,198,161,66,159,188,236,95,239,182,173,35,6,4,136,158,162,76,179,57,128,145,147,96,102,27,224,21,74,250,182,186,67,130,172,86,53,117,130,119,170,198,5,104,170,228,242,52,14,34,82,9,149,113,172,10,75,59,251,209,106,52,70,53,155,151,165,85,93,189,57,231,82,56,158,62,15,98,252,94,161,99,46,192,174,251,4,115,18,181,239,53,190,91,173,52,174,192,170,167,115,9,223,112,219,243,46,155,29,5,72,218,207,61,84,29,158,213,124,222,199,13,180,118,104,103,40,79,4,173,86,235,11,59,61,77,235,181,102,67,2,219,35,249,162,140,163,250,195,9,129,79,14,24,114,28,95,11,239,97,110,110,191,111,80,47,197,26,107,24,38,246,120,77,232,31,192,41,255,116,23,68,190,207,147,8,89,152,79,4,139,179,36,99,89,52,201,88,156,71,32,69,152,64,26,139,253,227,160,67,153,182,130,237,253,169,220,103,4,121,24,151,251,35,164,12,115,206,51,63,102,129,31,133,44,150,72,59,201,131,132,241,60,201,226,188,244,121,89,6,180,93,247,115,75,104,86,74,64,117,219,162,166,37,247,67,246,199,205,249,204,213,174,125,221,52,118,104,234,52,60,167,166,215,114,52,8,240,52,140,56,85,79,115,240,89,156,200,152,65,74,143,124,130,147,144,147,78,144,206,106,116,213,110,194,203,166,211,226,112,73,102,56,231,127,58,212,255,112,128,127,115,85,163,190,190,196,169,111,197,133,243,183,226,180,189,183,255,5,17,197,147,134,50,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,147,93,111,218,48,20,134,255,74,148,246,18,163,56,254,136,157,203,181,157,132,212,110,168,108,189,1,46,142,237,227,54,82,72,80,98,54,49,196,127,159,9,208,150,174,119,243,69,98,31,159,231,124,229,205,46,189,14,219,53,166,101,250,101,250,48,107,125,24,223,180,29,142,167,93,107,177,239,199,247,173,133,186,250,3,166,198,41,116,176,194,128,221,19,212,27,236,239,171,62,140,146,247,80,58,74,175,127,13,119,105,57,223,165,147,128,171,159,19,23,35,23,74,35,183,121,78,140,87,148,240,44,115,68,69,19,225,74,162,47,168,150,78,208,8,219,182,222,172,154,7,12,48,133,240,146,150,187,116,136,22,3,128,227,58,115,66,145,76,112,32,220,41,65,116,206,37,113,78,113,41,209,48,173,88,186,31,165,189,125,193,21,12,73,223,96,78,193,199,108,154,20,34,51,132,163,49,68,89,176,196,123,166,141,228,138,83,180,7,248,228,255,6,206,175,230,147,254,251,239,6,187,217,16,183,244,80,247,184,28,71,235,7,195,93,141,43,108,66,185,19,66,229,5,48,75,132,65,75,184,23,16,123,214,138,20,154,21,82,241,156,26,198,246,17,120,157,101,185,163,153,144,202,228,146,80,75,85,68,152,38,90,20,113,7,69,14,212,10,111,164,60,32,119,77,168,194,246,102,152,81,185,3,204,144,11,11,196,114,45,34,133,5,1,166,29,97,96,138,188,80,72,37,45,246,203,171,229,161,49,87,245,235,26,182,79,255,246,247,136,224,18,219,54,190,234,86,56,236,2,216,208,39,102,155,212,135,171,216,99,85,39,208,184,100,253,210,54,216,143,191,86,93,31,146,42,126,217,164,245,73,135,253,166,14,85,243,28,201,186,70,27,170,182,25,79,220,49,235,250,66,46,239,243,238,22,71,205,45,210,114,241,185,234,78,239,227,148,47,117,119,41,185,69,58,90,164,179,118,211,217,67,52,22,15,183,239,154,29,18,12,46,31,142,103,141,69,75,179,169,235,147,229,22,2,156,29,207,230,214,85,190,66,55,105,102,103,105,13,81,178,211,34,159,60,206,235,88,219,255,96,15,208,192,51,118,223,98,251,111,181,191,86,249,35,142,240,28,216,228,90,100,5,245,164,64,208,81,227,50,39,202,81,32,154,106,227,89,193,114,239,243,129,126,68,143,29,54,22,47,11,163,210,32,147,130,18,229,49,39,156,10,29,121,151,17,80,25,115,92,42,230,28,59,241,253,48,237,195,207,125,170,235,48,170,125,186,223,47,247,127,1,240,39,194,64,76,4,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "50c67976474a4cfbb0665ca727be0505",
							"BaseElements.ChangeLeadContactAll.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("68ee82f8-280b-40ce-951d-6e93d2945a8f");
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

		#region Class: AddContactByLeadFlowElement

		/// <exclude/>
		public class AddContactByLeadFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddContactByLeadFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddContactByLead";
				IsLogging = true;
				SchemaElementUId = new Guid("1af802d9-9f23-4206-b9ce-ae0b0050da9e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Name = () => new LocalizableString(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Contact") : null)) != String.Empty ? ((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Contact") : null)) : (((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Email") : null)) != String.Empty ? ((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Email") : null)) : (((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("BusinesPhone").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("BusinesPhone") : null)) != String.Empty ? ((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("BusinesPhone").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("BusinesPhone") : null)) : ((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("MobilePhone").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("MobilePhone") : null)))));
				_recordDefValues_JobTitle = () => new LocalizableString(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("FullJobTitle").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("FullJobTitle") : null)));
				_recordDefValues_Dear = () => new LocalizableString(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Dear").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Dear") : null)));
				_recordDefValues_Department = () => (Guid)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Department").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("DepartmentId") : Guid.Empty)));
				_recordDefValues_Job = () => (Guid)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Job").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("JobId") : Guid.Empty)));
				_recordDefValues_DoNotUseEmail = () => (bool)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("DoNotUseEmail").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<bool>("DoNotUseEmail") : false)));
				_recordDefValues_DoNotUseSms = () => (bool)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("DoNotUseSMS").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<bool>("DoNotUseSMS") : false)));
				_recordDefValues_DoNotUseMail = () => (bool)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("DoNotUseMail").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<bool>("DoNotUseMail") : false)));
				_recordDefValues_DoNotUseCall = () => (bool)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("DoNotUsePhone").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<bool>("DoNotUsePhone") : false)));
				_recordDefValues_DoNotUseFax = () => (bool)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("DoNotUseFax").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<bool>("DoNotUseFax") : false)));
				_recordDefValues_Confirmed = () => (bool)(false);
				_recordDefValues_SalutationType = () => (Guid)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("TitleId") : Guid.Empty)));
				_recordDefValues_Gender = () => (Guid)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Gender").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("GenderId") : Guid.Empty)));
				_recordDefValues_DecisionRole = () => (Guid)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("DecisionRole").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("DecisionRoleId") : Guid.Empty)));
				_recordDefValues_Email = () => new LocalizableString(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Email") : null)));
				_recordDefValues_MobilePhone = () => new LocalizableString(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("MobilePhone").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("MobilePhone") : null)));
				_recordDefValues_Phone = () => new LocalizableString(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("BusinesPhone").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("BusinesPhone") : null)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Name", () => _recordDefValues_Name.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_JobTitle", () => _recordDefValues_JobTitle.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Dear", () => _recordDefValues_Dear.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Department", () => _recordDefValues_Department.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Job", () => _recordDefValues_Job.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DoNotUseEmail", () => _recordDefValues_DoNotUseEmail.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DoNotUseSms", () => _recordDefValues_DoNotUseSms.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DoNotUseMail", () => _recordDefValues_DoNotUseMail.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DoNotUseCall", () => _recordDefValues_DoNotUseCall.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DoNotUseFax", () => _recordDefValues_DoNotUseFax.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Confirmed", () => _recordDefValues_Confirmed.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_SalutationType", () => _recordDefValues_SalutationType.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Gender", () => _recordDefValues_Gender.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DecisionRole", () => _recordDefValues_DecisionRole.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Email", () => _recordDefValues_Email.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_MobilePhone", () => _recordDefValues_MobilePhone.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Phone", () => _recordDefValues_Phone.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<string> _recordDefValues_Name;
			internal Func<string> _recordDefValues_JobTitle;
			internal Func<string> _recordDefValues_Dear;
			internal Func<Guid> _recordDefValues_Department;
			internal Func<Guid> _recordDefValues_Job;
			internal Func<bool> _recordDefValues_DoNotUseEmail;
			internal Func<bool> _recordDefValues_DoNotUseSms;
			internal Func<bool> _recordDefValues_DoNotUseMail;
			internal Func<bool> _recordDefValues_DoNotUseCall;
			internal Func<bool> _recordDefValues_DoNotUseFax;
			internal Func<bool> _recordDefValues_Confirmed;
			internal Func<Guid> _recordDefValues_SalutationType;
			internal Func<Guid> _recordDefValues_Gender;
			internal Func<Guid> _recordDefValues_DecisionRole;
			internal Func<string> _recordDefValues_Email;
			internal Func<string> _recordDefValues_MobilePhone;
			internal Func<string> _recordDefValues_Phone;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			public override Guid EntitySchemaId {
				get {
					return _entitySchemaId;
				}
				set {
					_entitySchemaId = value;
				}
			}

			private string _recordAddMode;
			public override string RecordAddMode {
				get {
					return _recordAddMode ?? (_recordAddMode = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,0,0,33,223,219,244,1,0,0,0 })));
				}
				set {
					_recordAddMode = value;
				}
			}

			private EntityColumnMappingValues _recordDefValues;
			public override EntityColumnMappingValues RecordDefValues {
				get {
					if (_recordDefValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,91,109,143,27,183,17,254,43,170,18,160,13,96,30,248,206,161,128,162,64,98,167,112,17,55,134,175,205,23,219,31,134,228,48,86,161,147,14,146,174,173,123,184,255,158,103,229,59,191,37,85,125,141,236,250,186,210,135,61,105,111,201,37,185,243,112,158,153,121,246,114,250,229,246,229,185,76,103,211,175,31,63,58,93,245,237,201,55,171,181,156,60,94,175,170,108,54,39,223,173,42,47,230,255,226,178,144,199,188,230,51,217,202,250,7,94,92,200,230,187,249,102,123,111,242,118,163,233,189,233,151,127,223,253,111,58,123,122,57,125,184,149,179,191,62,108,232,57,197,216,83,176,94,105,17,173,188,51,73,113,238,94,85,103,163,246,166,134,20,24,141,235,106,113,113,182,124,36,91,126,204,219,23,211,217,229,116,215,27,58,224,80,43,167,108,149,79,173,41,111,137,21,185,94,84,168,217,150,214,114,234,157,166,87,247,166,155,250,66,206,120,119,211,55,141,77,44,226,98,48,138,186,160,7,19,178,162,214,180,98,210,174,249,72,174,53,55,52,190,190,254,77,195,167,95,60,125,184,249,254,31,75,89,159,238,250,157,117,94,108,228,249,9,206,190,119,226,193,66,206,100,185,157,93,178,231,216,187,174,202,152,220,149,143,206,224,54,214,170,72,222,235,20,73,178,132,43,52,120,189,150,179,203,88,51,249,28,147,34,214,73,249,22,131,98,233,21,3,37,9,108,76,109,181,13,77,30,44,183,243,237,203,111,118,107,52,187,164,24,164,216,208,149,203,222,96,69,92,87,236,171,86,53,145,243,46,18,39,238,87,207,191,120,62,249,205,239,39,167,219,245,124,249,227,201,131,179,243,237,203,201,31,38,255,23,211,154,77,126,247,57,207,163,139,56,219,200,168,36,48,123,207,206,171,108,106,82,78,147,19,223,124,118,116,23,31,207,7,79,235,51,127,60,25,67,103,10,78,105,170,69,121,130,193,209,176,33,25,178,148,136,3,179,148,59,248,120,62,120,90,179,207,122,26,94,119,233,166,101,213,51,14,222,250,8,119,161,177,39,80,22,27,34,115,109,126,152,198,87,95,13,219,118,155,111,206,23,252,242,135,159,239,222,79,132,219,100,129,195,201,183,243,245,102,59,153,195,33,77,86,125,178,150,205,197,98,139,135,58,129,199,89,72,221,206,87,75,56,176,229,150,235,118,178,196,216,255,205,131,255,53,253,237,0,113,171,14,30,156,241,124,113,136,145,220,116,116,251,33,124,125,177,153,47,193,2,38,231,47,86,203,131,172,202,207,122,156,221,182,135,71,171,50,95,200,77,251,87,38,112,254,14,51,121,219,8,46,159,189,162,55,207,166,179,103,191,76,112,174,255,190,50,250,119,41,206,187,236,230,217,244,222,179,233,233,234,98,93,135,222,28,126,220,127,203,242,118,55,216,93,242,222,207,27,58,131,51,203,139,197,226,250,204,125,222,242,205,133,55,167,87,109,222,231,210,30,46,79,111,88,204,174,23,125,253,81,191,112,184,249,188,26,219,175,105,246,136,151,252,163,172,255,140,233,191,25,251,235,81,254,5,75,120,211,113,107,197,177,17,81,58,9,13,152,182,170,36,206,170,105,137,134,138,214,189,180,93,235,39,210,101,45,203,42,255,229,192,158,200,102,183,218,3,143,188,30,215,176,84,87,211,171,171,123,111,179,203,78,182,247,32,93,153,234,25,3,42,164,114,44,65,21,234,217,86,108,28,65,219,189,236,146,74,36,205,112,99,226,35,246,166,136,67,137,78,43,9,181,248,198,198,113,8,227,98,151,190,233,90,29,166,226,4,62,196,147,193,138,16,51,238,155,42,199,98,65,201,226,176,3,31,112,255,253,22,143,118,242,183,85,153,96,28,11,32,251,136,235,209,227,218,107,171,73,55,176,203,132,88,160,139,83,185,12,63,75,175,173,85,19,140,174,123,113,93,67,75,213,55,167,58,248,169,242,26,223,200,199,172,34,3,240,132,192,49,105,30,23,174,69,146,37,219,162,178,206,130,32,122,220,173,244,84,148,41,205,138,233,46,114,160,3,227,250,137,212,249,249,28,211,252,237,230,154,11,29,145,61,118,100,107,97,242,38,118,21,216,14,81,126,43,32,248,28,21,145,119,186,38,239,163,105,123,145,157,125,45,148,2,208,216,208,139,23,210,170,4,196,61,169,101,49,136,130,40,68,25,23,178,107,234,197,100,45,42,152,134,103,92,135,86,1,235,90,93,50,216,2,139,230,158,14,140,236,251,2,222,189,29,230,121,196,244,39,103,225,197,230,0,183,216,145,137,1,146,189,0,211,212,12,35,29,147,75,119,201,129,18,219,125,152,78,108,99,182,22,86,31,3,172,172,128,230,149,94,188,146,34,33,71,241,38,55,186,21,166,131,115,98,75,102,88,92,0,170,98,3,190,116,136,42,90,193,246,227,164,232,24,247,98,218,121,143,12,159,32,163,212,34,124,19,131,128,103,7,116,119,18,246,161,91,110,197,143,11,211,204,84,241,56,61,186,71,174,27,89,111,175,74,6,127,161,110,2,226,19,182,65,234,129,49,253,167,35,1,191,179,144,174,100,65,108,59,70,2,40,160,202,146,162,202,92,156,170,1,230,15,47,80,82,137,183,130,52,195,107,48,39,81,216,42,16,88,123,224,154,18,126,10,42,46,204,22,12,220,239,135,180,41,112,70,221,57,88,188,29,70,4,15,13,30,210,6,30,98,76,199,120,141,177,227,130,52,101,214,186,117,163,92,67,238,28,119,117,170,56,95,149,205,137,90,237,73,52,203,161,221,244,106,178,92,109,39,23,27,153,200,171,76,224,145,128,127,98,100,103,93,98,40,157,148,238,59,11,65,105,11,64,202,202,122,4,184,9,37,173,172,211,39,37,224,169,36,231,138,100,165,17,8,35,50,238,64,182,107,85,133,206,205,117,3,112,134,253,161,53,234,63,25,232,135,9,55,196,21,240,220,132,14,108,85,57,121,231,139,233,54,123,55,46,100,123,92,93,17,184,168,98,135,210,88,103,212,94,164,137,170,152,106,11,142,187,119,31,17,217,167,143,78,143,184,254,228,30,251,179,195,181,102,221,43,247,168,18,101,232,36,164,249,193,8,161,147,128,238,194,85,49,32,8,110,47,174,173,35,132,208,201,171,222,13,160,41,94,15,41,51,20,120,131,46,45,55,196,9,212,198,133,235,224,117,76,181,59,101,92,15,67,174,2,211,195,131,85,89,215,8,233,73,77,41,185,143,135,235,163,195,254,159,80,241,207,14,216,136,0,41,69,131,248,188,155,93,101,223,194,213,34,30,108,160,208,26,174,220,133,190,223,97,163,106,83,123,236,162,88,199,65,65,5,22,142,12,0,82,227,100,179,84,209,161,183,60,46,96,167,106,133,132,178,226,194,72,66,198,2,215,237,8,73,72,231,73,103,11,161,89,162,143,7,236,235,250,245,145,138,143,29,217,57,80,76,29,86,110,195,144,136,139,22,85,46,65,94,46,75,99,215,224,175,53,138,207,251,144,13,183,44,44,45,192,211,123,128,83,67,45,151,11,140,25,136,239,18,147,137,149,71,150,55,51,192,181,110,88,2,141,124,10,36,163,82,176,89,162,188,95,165,128,23,121,237,152,219,199,67,118,231,127,30,113,125,244,216,38,245,236,12,36,203,165,33,191,131,48,57,33,193,238,69,21,175,181,209,100,90,251,15,53,174,42,205,18,100,24,42,65,6,11,139,79,65,101,202,81,9,135,108,57,11,25,142,135,199,245,14,181,251,128,241,250,130,163,232,106,204,110,171,21,200,171,130,134,18,216,5,228,134,109,30,18,64,81,43,147,131,17,19,37,214,144,246,154,119,135,99,42,77,35,35,76,140,20,20,66,41,149,115,130,133,162,0,156,9,155,123,206,113,92,110,139,123,227,202,224,248,208,181,104,184,45,180,71,38,13,148,191,233,152,81,80,115,112,100,7,118,91,167,104,182,229,225,235,209,101,221,185,122,143,184,138,10,46,130,64,227,51,2,24,239,160,123,164,65,14,81,58,42,255,226,11,249,116,43,76,199,166,83,25,170,60,198,150,129,73,130,65,229,98,18,28,144,175,92,16,121,70,75,251,75,184,236,28,20,130,88,155,140,28,148,71,128,9,76,83,81,218,96,98,117,40,25,185,145,97,218,134,4,253,40,68,46,221,7,132,221,20,105,96,1,192,116,238,22,53,159,8,161,203,161,179,71,127,148,101,147,245,17,207,119,14,207,186,64,176,72,192,12,178,18,131,232,182,54,85,224,220,33,127,132,126,162,25,64,203,222,210,71,115,72,240,27,176,81,25,14,93,16,25,86,11,187,53,236,42,113,244,98,247,39,141,122,130,51,142,22,186,95,141,205,197,103,78,138,29,36,100,221,250,94,168,118,212,126,250,184,240,236,177,164,105,0,112,68,177,118,144,148,66,120,102,64,203,160,144,182,200,175,5,151,155,57,180,128,114,117,148,67,223,65,52,7,15,233,196,208,190,23,40,27,125,27,212,24,214,101,108,255,221,117,173,69,156,132,219,121,231,66,22,183,5,97,230,193,76,91,69,10,216,65,232,81,130,15,197,217,8,241,192,254,128,178,149,110,181,149,170,42,234,181,224,151,185,40,228,132,145,67,134,193,23,67,209,89,109,198,133,230,15,125,157,241,128,104,190,126,25,235,24,64,143,93,3,13,245,133,169,144,100,41,91,32,233,131,63,133,18,8,245,135,1,80,76,77,183,92,139,217,175,129,70,146,147,2,172,149,155,7,181,228,10,226,80,77,5,247,46,162,51,170,69,205,143,44,239,251,161,239,141,30,16,206,239,190,141,120,68,245,216,81,29,117,48,217,163,68,11,21,6,212,2,189,243,245,155,13,16,88,67,105,205,57,214,253,78,154,60,228,154,154,24,10,14,96,18,50,108,4,140,28,25,137,62,68,251,1,241,181,214,101,92,168,254,208,151,218,15,136,234,247,223,82,62,226,122,132,184,126,126,245,19,79,31,87,219,27,71,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "50c67976474a4cfbb0665ca727be0505",
							"BaseElements.AddContactByLead.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("68ee82f8-280b-40ce-951d-6e93d2945a8f");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordDefValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordDefValues", getColumnValue);
					}
					return _recordDefValues;
				}
				set {
					_recordDefValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: AddContactAdressFlowElement

		/// <exclude/>
		public class AddContactAdressFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddContactAdressFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddContactAdress";
				IsLogging = true;
				SchemaElementUId = new Guid("1224fb70-fb27-4338-be60-708c6885b75d");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Address = () => new LocalizableString(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Address").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Address") : null)));
				_recordDefValues_City = () => (Guid)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("City").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("CityId") : Guid.Empty)));
				_recordDefValues_Zip = () => new LocalizableString(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Zip").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Zip") : null)));
				_recordDefValues_Contact = () => (Guid)((process.AddContactByLead.RecordId));
				_recordDefValues_Region = () => (Guid)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Region").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("RegionId") : Guid.Empty)));
				_recordDefValues_Primary = () => (bool)(true);
				_recordDefValues_Country = () => (Guid)(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Country").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("CountryId") : Guid.Empty)));
				_recordDefValues_AddressType = () => (Guid)((((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("AddressType").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("AddressTypeId") : Guid.Empty)) != Guid.Empty) ? ((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("AddressType").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("AddressTypeId") : Guid.Empty)) : new Guid("fb7a3f6a-f36b-1410-6f81-1c6f65e50343"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Address", () => _recordDefValues_Address.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_City", () => _recordDefValues_City.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Zip", () => _recordDefValues_Zip.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Region", () => _recordDefValues_Region.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Primary", () => _recordDefValues_Primary.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Country", () => _recordDefValues_Country.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_AddressType", () => _recordDefValues_AddressType.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<string> _recordDefValues_Address;
			internal Func<Guid> _recordDefValues_City;
			internal Func<string> _recordDefValues_Zip;
			internal Func<Guid> _recordDefValues_Contact;
			internal Func<Guid> _recordDefValues_Region;
			internal Func<bool> _recordDefValues_Primary;
			internal Func<Guid> _recordDefValues_Country;
			internal Func<Guid> _recordDefValues_AddressType;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			public override Guid EntitySchemaId {
				get {
					return _entitySchemaId;
				}
				set {
					_entitySchemaId = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,75,111,219,70,16,254,43,129,206,217,100,223,15,223,18,39,109,13,180,137,81,7,57,36,202,97,159,14,81,74,20,72,42,173,107,248,191,119,72,201,138,100,203,234,138,72,98,181,182,15,178,180,152,157,157,7,191,225,204,183,151,35,95,218,166,121,99,39,113,116,52,122,121,250,219,89,149,218,103,63,21,101,27,235,159,235,106,62,27,61,29,53,177,46,108,89,252,29,195,98,253,117,40,218,87,182,181,176,225,114,252,117,255,120,116,52,222,166,97,60,122,58,30,21,109,156,52,32,1,27,140,212,52,250,144,144,80,158,34,110,164,65,154,121,142,88,140,129,81,73,146,23,122,33,185,93,245,113,53,153,217,58,46,78,232,149,167,254,235,187,139,89,39,72,96,193,247,34,69,83,77,151,139,172,51,161,121,61,181,174,140,1,126,183,245,60,194,82,91,23,19,240,36,190,43,38,241,212,214,112,82,167,167,234,150,64,40,217,178,233,164,202,152,218,215,127,205,234,216,52,69,53,221,109,90,57,159,76,215,101,97,123,92,253,92,26,131,123,11,59,201,83,219,126,238,21,156,128,81,87,189,141,47,206,207,235,120,110,219,226,203,186,9,127,196,139,94,46,47,118,176,33,64,126,222,219,114,30,215,206,220,244,227,216,206,218,133,59,139,227,65,160,46,206,63,103,122,186,138,214,191,57,75,97,113,118,45,156,165,113,171,253,84,194,226,151,110,97,161,227,250,235,120,244,241,164,121,251,231,52,214,103,254,115,156,216,69,196,62,61,131,213,27,11,43,253,71,151,132,97,236,4,139,136,26,233,17,215,66,67,20,165,134,120,50,27,60,21,86,113,127,245,105,97,71,209,204,74,123,241,126,117,220,175,209,134,101,184,186,127,176,162,149,210,90,82,138,168,11,160,67,25,141,76,226,24,49,79,136,181,216,59,97,28,100,23,254,96,143,38,6,91,147,60,50,58,56,196,73,82,72,71,16,198,62,146,196,189,33,73,44,61,220,27,87,81,18,138,83,178,40,40,23,16,15,130,33,27,133,65,142,17,238,29,143,142,58,185,75,245,201,244,46,72,241,255,34,164,94,132,208,201,44,4,114,176,149,23,191,45,207,38,217,13,174,165,33,79,218,94,186,131,89,76,177,142,83,31,23,79,232,202,229,13,139,111,195,177,75,243,199,131,1,100,239,244,26,32,151,96,224,73,59,26,164,66,138,4,140,184,72,14,105,163,34,242,129,91,134,181,53,202,227,94,223,234,184,95,170,238,203,154,178,61,148,220,66,231,66,25,64,237,83,15,54,78,188,74,81,163,164,120,4,156,39,210,129,205,32,236,180,99,65,81,226,49,222,137,136,230,205,188,44,239,66,5,221,134,10,242,127,67,69,94,12,127,32,42,138,62,41,203,208,118,30,112,197,18,20,110,130,56,235,158,150,164,8,50,152,129,133,204,8,71,53,81,78,239,236,39,30,122,221,203,139,223,99,221,219,89,247,146,83,150,37,105,81,98,210,33,194,9,70,50,105,130,136,151,73,138,40,48,227,108,179,238,189,156,55,197,20,18,117,163,246,101,43,186,85,251,190,42,188,174,127,198,56,78,137,98,136,59,11,216,21,74,33,139,121,64,12,170,105,162,193,99,235,249,35,50,118,116,219,89,241,123,68,198,78,100,40,137,93,146,26,250,108,39,35,10,137,16,228,140,214,8,99,18,36,142,134,105,47,55,145,241,42,150,144,143,250,226,6,50,178,21,221,66,198,87,133,61,50,58,104,148,213,121,225,109,249,118,22,107,200,126,95,138,239,120,117,111,188,17,186,41,164,174,170,246,198,59,170,27,10,250,163,87,111,205,172,54,191,51,132,65,123,73,104,50,40,50,120,188,184,48,22,233,238,131,4,161,109,148,28,106,112,24,56,16,72,40,22,48,206,40,68,189,131,97,209,82,140,64,165,65,12,86,163,210,86,37,226,190,113,251,67,15,252,229,120,92,205,167,109,255,32,100,188,24,243,226,183,63,252,87,70,236,232,122,214,101,86,29,79,111,96,103,121,74,140,42,45,128,6,176,48,165,64,135,6,83,138,182,20,121,65,1,12,58,122,108,252,3,203,236,239,241,188,23,207,73,108,94,248,246,79,236,89,11,110,63,159,213,213,151,2,50,186,51,191,215,230,110,77,175,149,78,71,35,37,2,26,1,170,7,237,58,50,160,118,16,21,148,123,226,184,51,226,161,165,247,67,49,203,203,109,94,236,182,229,118,103,106,63,156,156,62,159,85,77,107,203,39,190,10,241,142,196,113,25,188,165,148,160,160,147,0,10,193,0,133,224,140,71,158,51,78,140,182,4,202,255,3,75,220,113,209,102,150,219,188,224,13,40,183,189,5,187,106,237,181,192,237,132,58,42,36,236,34,136,37,193,129,31,140,20,57,14,35,176,37,86,192,220,228,185,99,241,129,37,116,57,95,230,229,52,47,126,123,163,113,101,195,237,164,253,128,230,46,175,101,187,203,18,252,13,45,161,212,36,195,129,185,198,142,74,232,139,129,122,214,138,38,48,135,90,166,130,18,222,192,176,120,5,119,56,93,124,207,170,121,237,151,247,38,205,226,242,102,208,181,204,61,92,183,236,115,135,178,245,22,35,135,6,61,148,59,135,239,123,175,48,232,198,224,30,104,177,65,92,215,29,148,249,144,236,111,140,179,185,156,244,222,196,243,61,48,202,3,73,196,193,172,235,227,179,147,199,233,237,77,218,61,6,54,143,18,250,158,156,207,126,20,206,32,114,230,30,90,198,1,84,202,112,138,226,64,253,219,36,20,134,143,232,7,234,222,218,64,61,124,138,61,80,223,214,103,206,225,19,221,129,58,247,98,115,254,250,33,195,207,119,155,101,174,70,87,255,0,28,13,127,191,130,38,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _recordAddMode;
			public override string RecordAddMode {
				get {
					return _recordAddMode ?? (_recordAddMode = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,4,0,183,239,220,131,1,0,0,0 })));
				}
				set {
					_recordAddMode = value;
				}
			}

			private Guid _filterEntitySchemaId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			public override Guid FilterEntitySchemaId {
				get {
					return _filterEntitySchemaId;
				}
				set {
					_filterEntitySchemaId = value;
				}
			}

			private EntityColumnMappingValues _recordDefValues;
			public override EntityColumnMappingValues RecordDefValues {
				get {
					if (_recordDefValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,219,110,28,69,16,253,149,101,225,1,36,247,210,247,203,74,8,65,8,200,82,2,86,12,60,16,231,161,186,187,26,86,172,103,172,217,89,80,176,252,239,156,89,219,196,9,209,66,192,178,8,241,60,236,165,103,186,166,186,167,78,157,83,53,231,243,15,198,231,103,60,95,206,63,63,122,124,220,183,113,241,160,31,120,113,52,244,133,55,155,197,163,190,208,122,245,27,229,53,31,209,64,167,60,242,240,61,173,183,188,121,180,218,140,7,179,155,147,230,7,243,15,126,217,157,155,47,159,158,207,15,71,62,253,238,176,194,178,138,68,138,162,20,181,21,41,108,177,44,178,44,36,40,54,83,140,179,190,214,105,114,233,215,219,211,238,49,143,116,68,227,79,243,229,249,124,103,13,6,60,171,232,82,142,194,145,51,194,58,19,68,86,141,69,11,196,177,100,171,156,183,243,139,131,249,166,252,196,167,180,187,233,139,201,213,217,170,181,138,194,171,18,133,85,6,55,86,57,8,23,108,44,129,181,107,206,79,147,175,174,127,49,241,233,251,79,15,55,223,252,218,241,112,188,179,187,108,180,222,240,179,5,70,95,25,120,184,230,83,238,198,229,57,89,242,173,201,34,148,74,77,88,111,20,22,169,181,240,209,90,25,124,228,196,238,2,19,254,216,203,229,185,47,41,218,228,131,136,36,131,176,213,59,65,220,10,28,141,236,72,169,82,75,157,166,60,236,198,213,248,252,193,110,143,150,231,193,231,104,125,241,194,83,115,194,202,162,69,114,193,11,87,92,205,69,86,175,165,188,120,246,254,179,105,97,117,181,57,91,211,243,239,255,188,190,39,76,117,182,198,199,226,203,213,176,25,103,43,60,178,89,223,102,3,111,182,235,113,213,253,56,195,51,89,115,25,87,125,183,248,172,86,140,111,46,109,158,189,20,12,55,173,158,159,92,70,212,201,124,121,242,250,152,186,250,190,220,195,151,163,234,229,128,58,153,31,156,204,143,251,237,80,38,107,6,127,190,184,177,148,221,13,118,151,188,242,247,58,130,48,210,109,215,235,171,145,47,104,164,235,11,175,135,251,186,106,43,174,135,221,241,117,224,236,172,200,171,67,188,230,227,250,184,244,237,223,76,123,76,29,253,200,195,215,88,254,11,223,255,240,242,91,108,225,181,225,34,155,180,94,35,58,240,88,133,197,243,21,209,178,19,201,170,84,75,116,202,103,181,155,253,132,27,15,220,21,254,135,142,61,225,205,110,183,39,232,94,249,53,109,213,197,252,226,226,224,38,160,179,139,182,144,50,194,32,122,39,72,121,145,152,73,104,68,57,23,74,218,134,182,23,208,202,26,87,106,203,152,171,180,176,156,45,50,130,79,34,202,164,43,75,21,188,15,239,22,160,173,118,49,251,36,69,227,160,240,140,3,137,168,67,20,77,82,200,169,86,27,226,109,3,250,1,110,127,143,230,59,71,115,214,201,201,160,154,8,76,0,15,123,45,98,85,36,146,74,185,153,96,116,107,122,31,154,29,0,38,179,199,4,195,136,47,107,163,200,184,82,80,70,34,240,92,116,105,252,70,104,6,124,153,11,2,86,69,105,133,141,26,104,214,217,139,70,214,182,226,40,83,220,79,207,161,120,37,131,46,34,147,134,1,202,70,68,165,73,120,19,172,34,195,25,217,235,221,66,51,171,134,4,103,176,168,208,144,223,42,25,65,166,121,81,173,78,150,168,98,159,252,45,163,249,135,195,163,143,207,250,205,72,107,140,86,190,7,246,157,3,219,104,71,193,64,165,202,102,39,96,210,68,211,160,183,224,165,111,72,223,210,80,185,83,154,174,181,6,51,229,7,19,225,149,109,108,69,140,181,8,67,73,121,8,135,232,201,239,167,105,47,147,137,46,10,106,25,164,100,192,243,57,230,34,156,86,46,1,72,17,226,243,63,1,108,69,45,74,93,147,72,77,163,64,208,18,142,166,130,156,200,50,75,233,100,165,196,175,0,59,4,84,36,112,1,92,235,33,170,166,101,101,134,198,226,132,20,81,109,41,40,56,254,26,162,16,197,179,109,87,250,174,173,134,83,174,128,94,55,82,25,103,153,54,248,215,119,59,248,206,86,93,235,135,83,186,100,221,129,105,196,185,129,75,63,212,217,97,189,71,234,91,71,193,16,220,108,188,83,34,54,70,122,7,24,48,191,74,144,137,52,213,250,104,106,53,111,132,84,103,85,150,49,76,12,42,1,52,212,187,16,212,224,82,210,146,83,136,112,202,168,189,72,45,200,52,169,193,133,102,35,86,84,35,160,158,188,23,197,180,96,171,149,53,185,119,172,66,174,133,141,100,80,176,201,104,23,88,9,81,146,19,106,101,25,115,72,216,15,131,44,113,203,20,124,60,2,217,31,159,13,253,47,43,132,204,61,174,223,58,92,67,241,162,20,77,32,1,15,197,102,91,44,34,58,143,182,83,109,54,87,77,49,39,245,70,184,102,93,77,69,245,134,234,22,188,107,121,250,229,80,40,43,89,160,22,124,243,198,203,189,184,174,74,85,42,148,97,192,84,72,107,16,20,164,127,22,73,90,68,61,34,185,212,116,251,184,30,7,124,237,193,197,245,249,251,46,208,29,6,247,84,244,185,220,38,121,185,75,126,22,244,19,66,66,211,69,131,58,2,181,36,195,157,202,75,101,169,218,150,89,176,155,58,57,201,85,200,203,56,21,57,56,26,27,52,36,243,222,224,150,30,177,76,104,93,98,85,237,146,70,83,153,8,129,161,205,42,4,88,13,244,142,145,86,72,217,86,137,220,21,18,116,64,74,6,109,93,157,5,203,20,100,140,217,185,114,219,117,227,131,126,219,141,195,125,35,232,237,99,43,153,90,65,163,1,244,164,28,2,75,39,244,109,208,85,21,17,156,0,217,151,200,151,246,70,128,38,188,70,152,94,200,8,237,2,200,166,68,248,82,81,33,161,29,11,249,104,117,115,145,246,179,85,78,210,193,117,16,38,252,176,83,127,138,16,250,162,58,3,81,92,178,150,53,223,62,160,63,252,47,35,218,251,232,52,5,39,178,214,140,45,65,135,23,185,13,183,76,81,89,48,184,84,70,77,136,158,189,247,201,236,171,237,170,46,30,158,158,141,207,63,154,125,58,251,95,172,106,137,101,60,234,251,159,183,103,11,39,163,9,121,50,109,218,228,156,135,138,177,57,11,244,251,163,13,232,64,86,149,23,13,141,111,52,202,72,52,131,243,224,56,41,124,139,74,168,2,177,228,216,73,99,205,254,244,247,225,63,123,173,53,155,222,89,189,254,49,252,27,115,55,214,127,243,204,226,243,237,102,213,77,47,195,254,254,130,239,197,214,252,237,201,205,127,39,216,255,42,55,63,187,248,29,247,67,149,199,157,31,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "50c67976474a4cfbb0665ca727be0505",
							"BaseElements.AddContactAdress.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("68ee82f8-280b-40ce-951d-6e93d2945a8f");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordDefValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordDefValues", getColumnValue);
					}
					return _recordDefValues;
				}
				set {
					_recordDefValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: AddContactWebFlowElement

		/// <exclude/>
		public class AddContactWebFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddContactWebFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddContactWeb";
				IsLogging = true;
				SchemaElementUId = new Guid("88ec16df-a2b4-4df3-9af2-11eeb925ec05");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Contact = () => (Guid)((process.AddContactByLead.RecordId));
				_recordDefValues_Number = () => new LocalizableString(((process.ReadLeadData.ResultEntity.IsColumnValueLoaded(process.ReadLeadData.ResultEntity.Schema.Columns.GetByName("Website").ColumnValueName) ? process.ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Website") : null)));
				_recordDefValues_CommunicationType = () => (Guid)(new Guid("6a8ba927-67cc-df11-9b2a-001d60e938c6"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Number", () => _recordDefValues_Number.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_CommunicationType", () => _recordDefValues_CommunicationType.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Contact;
			internal Func<string> _recordDefValues_Number;
			internal Func<Guid> _recordDefValues_CommunicationType;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41");
			public override Guid EntitySchemaId {
				get {
					return _entitySchemaId;
				}
				set {
					_entitySchemaId = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,84,93,111,211,48,20,253,47,121,158,167,196,118,190,250,6,163,160,74,176,85,234,52,30,232,30,110,108,167,181,112,154,200,78,6,165,234,127,231,38,105,75,135,186,146,33,193,150,151,36,71,231,126,29,95,159,141,39,12,56,119,13,133,242,70,222,219,233,167,89,153,215,151,239,181,169,149,253,96,203,166,242,46,60,167,172,6,163,127,40,217,227,99,169,235,119,80,3,6,108,230,191,226,231,222,104,126,42,195,220,187,152,123,186,86,133,67,6,6,228,50,98,34,207,3,34,130,32,39,60,145,64,82,154,115,18,101,153,72,211,212,231,148,182,185,158,76,125,85,22,21,88,213,87,232,146,231,221,231,237,186,106,137,1,2,162,163,104,87,174,118,32,107,91,112,227,21,100,70,73,252,175,109,163,16,170,173,46,112,18,117,171,11,53,5,139,149,218,60,101,11,33,41,7,227,90,150,81,121,61,254,94,89,229,156,46,87,231,91,51,77,177,58,230,98,184,58,252,238,154,241,187,14,91,230,20,234,101,151,96,130,77,109,187,30,223,44,22,86,45,160,214,15,199,45,124,85,235,142,55,76,59,12,144,120,62,119,96,26,117,84,243,241,28,87,80,213,253,56,125,121,36,88,189,88,14,156,244,160,214,159,134,165,8,86,123,242,160,140,39,251,167,17,130,15,45,208,231,216,127,206,189,47,19,119,243,109,165,236,76,44,85,1,189,98,247,151,136,254,6,28,242,143,54,1,243,253,44,100,138,208,52,18,168,98,152,144,132,69,9,225,41,3,41,104,8,49,23,219,251,190,15,237,42,3,235,187,67,185,143,10,228,78,174,246,133,72,228,211,40,19,49,35,34,225,64,120,150,225,153,132,192,73,146,37,129,164,52,227,60,20,120,186,248,96,12,75,20,149,9,231,132,2,229,132,11,145,144,84,66,64,88,76,41,203,121,44,152,12,206,169,52,113,215,141,49,79,237,62,61,181,251,244,149,239,254,103,149,57,180,135,97,23,96,152,126,39,22,40,56,123,1,176,135,222,166,58,121,247,117,187,19,51,229,66,11,48,55,149,178,176,227,251,167,21,125,116,20,237,190,218,178,172,251,45,60,168,213,174,79,87,105,63,80,26,251,12,132,207,9,228,97,74,56,77,129,36,17,195,21,138,19,33,101,232,71,84,48,148,6,109,184,157,104,86,54,86,236,172,207,245,254,251,87,206,250,2,142,249,28,27,60,105,68,67,172,229,181,216,198,191,181,134,23,184,243,234,249,23,249,191,220,164,173,183,253,9,136,15,48,255,195,8,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _recordAddMode;
			public override string RecordAddMode {
				get {
					return _recordAddMode ?? (_recordAddMode = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,4,0,183,239,220,131,1,0,0,0 })));
				}
				set {
					_recordAddMode = value;
				}
			}

			private Guid _filterEntitySchemaId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			public override Guid FilterEntitySchemaId {
				get {
					return _filterEntitySchemaId;
				}
				set {
					_filterEntitySchemaId = value;
				}
			}

			private EntityColumnMappingValues _recordDefValues;
			public override EntityColumnMappingValues RecordDefValues {
				get {
					if (_recordDefValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,149,91,111,220,68,20,199,191,202,202,237,99,102,53,247,203,190,65,90,164,72,9,68,13,148,135,36,15,103,102,206,180,22,94,59,178,189,160,178,218,239,206,177,179,219,92,168,146,32,4,2,169,126,240,101,236,115,245,255,55,103,91,189,30,63,221,96,181,170,190,61,63,187,232,202,184,60,238,122,92,158,247,93,194,97,88,158,118,9,154,250,119,136,13,158,67,15,107,28,177,127,15,205,6,135,211,122,24,143,22,247,141,170,163,234,245,175,243,187,106,117,185,173,78,70,92,255,116,146,201,115,86,89,91,19,2,115,160,61,211,220,69,230,37,88,166,140,192,152,165,12,190,0,25,167,174,217,172,219,51,28,225,28,198,143,213,106,91,205,222,200,65,42,82,90,109,60,75,34,113,166,51,79,12,10,26,166,133,181,186,200,108,28,199,106,119,84,13,233,35,174,97,14,122,103,204,185,134,32,164,96,82,20,138,14,2,153,15,130,238,76,226,197,25,139,160,197,100,188,255,254,206,240,242,213,229,201,240,195,111,45,246,23,179,223,85,129,102,192,235,37,173,62,90,120,219,224,26,219,113,181,21,80,60,151,57,176,80,164,98,90,114,203,98,72,200,0,121,228,220,240,12,1,119,100,240,185,151,171,173,115,224,121,49,150,233,104,169,54,31,19,139,40,29,195,96,75,201,58,37,19,226,238,250,213,245,148,98,174,135,155,6,62,189,255,115,166,223,228,188,216,180,169,107,75,221,175,49,47,232,110,132,52,46,34,12,244,212,181,139,6,33,47,234,182,116,253,26,198,186,107,151,199,61,194,72,239,122,76,93,159,23,39,249,54,196,205,131,191,124,63,200,246,234,86,42,87,213,234,234,203,98,217,95,111,155,243,80,46,15,149,114,85,29,93,85,23,221,166,79,147,55,69,15,111,238,85,54,7,152,63,121,244,120,144,6,173,180,155,166,217,175,188,129,17,14,31,30,150,187,92,151,26,243,73,123,113,80,196,236,133,239,15,246,133,211,225,184,205,237,239,152,157,65,11,31,176,255,158,202,191,203,253,115,150,63,82,11,15,142,163,12,134,59,81,152,67,8,76,163,149,204,103,1,44,136,16,139,114,74,150,34,103,235,119,88,176,199,54,225,195,196,132,141,168,172,17,204,23,148,68,131,9,100,159,57,35,69,77,200,121,149,179,218,219,15,115,183,39,38,247,121,77,173,218,85,187,221,209,125,82,101,20,90,58,65,18,44,78,147,24,109,98,65,135,194,188,16,32,194,164,238,146,159,36,149,203,146,0,141,99,5,10,80,69,186,176,160,172,99,209,120,37,28,88,148,152,254,19,164,130,6,226,139,54,18,33,168,62,109,149,160,174,73,201,172,215,180,65,89,143,1,205,35,82,109,10,94,7,42,198,3,119,180,11,89,67,92,151,68,125,247,104,64,136,148,83,158,76,222,182,99,61,126,58,158,123,180,218,162,51,42,8,106,164,208,89,208,150,32,20,139,209,57,106,139,210,217,160,165,78,151,231,249,126,55,225,59,49,188,252,174,238,135,113,81,211,47,91,116,133,232,29,54,205,88,183,31,136,248,166,193,52,163,253,51,198,175,48,255,235,48,231,28,21,73,22,25,119,72,154,205,4,115,116,132,117,230,104,133,167,237,191,196,252,20,204,47,78,236,165,48,103,165,184,117,9,24,228,57,33,210,57,200,100,153,5,158,16,157,247,73,241,39,97,22,178,136,236,20,113,172,18,13,91,48,146,133,152,105,110,35,199,4,37,171,18,245,63,1,243,105,215,253,178,185,89,102,175,109,138,180,131,20,225,51,33,26,200,131,42,101,154,140,162,80,108,240,78,45,45,248,8,129,230,37,85,154,88,46,66,80,142,18,168,107,34,91,142,65,249,100,159,131,107,31,239,184,91,175,55,109,157,230,249,184,232,110,230,203,52,241,38,160,254,66,160,175,35,180,250,255,140,208,151,136,236,57,234,174,119,127,0,25,94,0,86,70,11,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "50c67976474a4cfbb0665ca727be0505",
							"BaseElements.AddContactWeb.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("68ee82f8-280b-40ce-951d-6e93d2945a8f");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordDefValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordDefValues", getColumnValue);
					}
					return _recordDefValues;
				}
				set {
					_recordDefValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ParallelGatewayAddContactCommunicationFlowElement

		/// <exclude/>
		public class ParallelGatewayAddContactCommunicationFlowElement : ProcessParallelGateway
		{

			public ParallelGatewayAddContactCommunicationFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessParallelGateway";
				Name = "ParallelGatewayAddContactCommunication";
				IsLogging = true;
				SchemaElementUId = new Guid("5d0b6b6a-1a92-4477-a8f6-7922798ad8b7");
				CreatedInSchemaUId = process.InternalSchemaUId;
				IncomingTokens = new Dictionary<string, bool> { { "AddContactByLead", false }, };
				SerializeToDB = Owner.SerializeToDB;
			}

		}

		#endregion

		#region Class: ParallelGateway1FlowElement

		/// <exclude/>
		public class ParallelGateway1FlowElement : ProcessParallelGateway
		{

			public ParallelGateway1FlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessParallelGateway";
				Name = "ParallelGateway1";
				IsLogging = true;
				SchemaElementUId = new Guid("5c0463a9-9ea1-464a-b52e-096674f01418");
				CreatedInSchemaUId = process.InternalSchemaUId;
				IncomingTokens = new Dictionary<string, bool> { { "AddContactWeb", false }, { "AddContactAdress", false }, };
				SerializeToDB = Owner.SerializeToDB;
			}

		}

		#endregion

		#region Class: ReadContactsByLeadEmailFlowElement

		/// <exclude/>
		public class ReadContactsByLeadEmailFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadContactsByLeadEmailFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadContactsByLeadEmail";
				IsLogging = true;
				SchemaElementUId = new Guid("e02e7808-8729-4c97-b907-1487f2e17278");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,75,111,219,70,16,254,43,130,78,45,144,53,118,185,203,229,82,183,214,85,11,31,154,24,117,144,75,228,195,62,102,101,162,124,8,36,149,70,21,244,223,51,75,82,178,156,208,170,226,54,181,11,84,7,129,28,206,204,126,179,243,205,99,59,181,185,110,154,215,186,128,233,108,250,227,245,175,55,149,111,47,126,206,242,22,234,95,234,106,189,154,190,154,54,80,103,58,207,254,4,215,203,231,46,107,127,210,173,70,131,237,226,222,126,49,157,45,198,60,44,166,175,22,211,172,133,162,65,13,52,208,52,117,160,35,71,226,88,59,34,12,151,68,167,210,18,233,180,16,49,151,82,50,213,107,142,187,158,127,204,154,182,233,15,232,124,251,238,241,237,102,21,244,98,20,216,170,88,233,58,107,170,114,16,178,32,205,154,121,169,77,14,14,5,109,189,6,20,181,117,86,96,36,240,54,43,224,90,215,120,82,112,84,5,17,42,121,157,55,65,43,7,223,206,63,174,106,104,154,172,42,79,65,187,172,242,117,81,30,235,162,57,28,94,7,52,180,131,24,52,175,117,123,215,57,120,127,89,149,173,182,237,101,85,20,235,50,179,186,69,245,217,32,188,189,184,66,204,187,46,132,31,150,203,26,150,248,249,3,220,135,241,59,108,58,47,231,221,44,26,56,204,222,59,157,175,225,8,209,195,40,47,245,42,64,232,220,14,48,38,246,24,220,164,234,20,38,223,153,205,164,15,102,50,232,125,223,29,209,172,77,159,162,33,235,95,77,147,56,245,60,17,206,144,36,82,154,8,202,83,98,120,196,136,246,78,209,84,58,31,89,119,58,23,129,4,240,24,79,216,24,79,248,11,167,201,235,117,97,66,48,99,92,216,195,216,147,225,188,251,27,33,67,164,78,178,97,143,1,149,234,108,121,119,102,200,135,107,251,171,168,35,20,174,246,202,103,121,28,15,66,162,240,67,16,244,62,246,143,88,106,87,205,155,63,74,168,111,236,29,20,186,191,182,219,11,148,126,38,152,231,80,64,217,206,182,90,104,233,61,181,132,177,212,19,33,57,222,161,138,34,34,149,16,52,145,10,82,136,119,104,112,0,52,219,74,155,42,145,202,132,40,77,19,34,156,140,137,6,111,137,96,10,98,205,152,117,214,5,147,121,217,102,237,166,167,195,108,235,1,120,228,20,35,9,68,130,8,205,5,73,153,77,8,167,138,131,112,34,229,202,239,110,251,112,179,102,149,235,205,187,67,84,191,129,118,147,28,255,176,164,234,166,157,132,66,154,84,126,130,151,187,206,219,172,92,134,34,205,193,134,52,94,204,11,157,229,157,159,208,88,208,218,202,8,40,165,134,112,133,52,9,189,2,79,142,17,131,229,82,249,84,25,19,51,100,29,254,208,134,179,20,64,240,4,85,16,171,48,30,136,118,81,74,40,143,57,149,248,49,50,250,84,226,174,202,199,106,82,252,23,107,242,65,203,238,213,206,41,207,243,110,113,132,217,236,116,179,238,181,190,44,206,208,85,223,191,152,242,236,130,56,42,207,129,135,0,204,170,216,114,98,189,53,196,121,198,72,106,34,77,40,101,78,82,192,2,176,178,243,119,56,238,158,202,247,21,126,182,151,47,170,104,240,134,60,191,237,168,158,87,75,76,108,254,102,5,117,151,222,129,1,35,116,124,192,227,208,123,234,170,106,251,142,114,192,58,54,227,59,28,123,78,24,233,172,6,225,137,75,5,150,97,228,57,49,76,122,146,168,56,193,94,110,210,136,211,14,221,183,130,246,0,141,230,128,92,100,2,143,103,10,209,48,68,67,169,39,220,196,70,33,74,101,192,35,26,92,16,67,118,111,170,117,109,135,105,219,244,155,225,147,118,190,231,88,230,254,193,13,237,243,181,231,73,11,205,51,44,42,95,187,125,140,142,254,115,186,197,255,131,250,5,14,234,103,152,194,127,99,180,62,50,217,158,194,62,118,60,135,206,157,28,255,230,116,248,166,205,126,55,221,125,2,223,107,38,133,0,16,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,77,241,207,179,50,176,50,212,241,76,1,82,6,0,110,89,182,126,20,0,0,0 })));
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
								new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"));
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
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,75,76,53,72,53,49,77,78,212,77,54,177,52,213,53,73,75,53,215,77,52,182,76,209,53,78,76,50,55,50,183,72,53,52,51,52,7,0,106,93,85,138,36,0,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ChangeLeadContactEmailFlowElement

		/// <exclude/>
		public class ChangeLeadContactEmailFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeLeadContactEmailFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeLeadContactEmail";
				IsLogging = true;
				SchemaElementUId = new Guid("f4434864-a2bf-4f22-bf0c-27c7e0c1e19c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifiedContact = () => (Guid)(((process.ReadContactsByLeadEmail.ResultEntity.IsColumnValueLoaded(process.ReadContactsByLeadEmail.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadContactsByLeadEmail.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifiedContact", () => _recordColumnValues_QualifiedContact.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifiedContact;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,47,62,87,69,252,21,89,185,109,93,54,4,216,214,0,41,122,169,123,160,37,218,17,102,199,134,164,116,203,130,252,247,81,118,146,165,67,208,102,187,172,190,88,122,120,124,124,164,200,109,32,107,176,246,43,52,24,76,130,247,243,47,139,182,116,215,31,117,237,208,124,50,237,186,11,174,2,139,70,67,173,127,162,26,240,169,210,238,3,56,160,128,109,254,59,62,15,38,249,57,133,60,184,202,3,237,176,177,196,160,0,94,134,5,72,94,48,16,49,178,4,185,100,25,200,136,149,10,69,4,10,98,145,148,3,243,188,244,77,219,116,96,112,200,208,139,151,253,241,110,211,121,98,72,128,236,41,218,182,171,61,24,123,11,118,186,130,162,70,69,119,103,214,72,144,51,186,161,74,240,78,55,56,7,67,153,188,78,235,33,34,149,80,91,207,170,177,116,211,31,157,65,107,117,187,122,217,90,189,110,86,167,92,10,199,227,117,111,102,212,59,244,204,57,184,101,47,48,35,83,187,222,227,187,170,50,88,129,211,79,167,22,190,225,166,231,93,214,59,10,80,244,62,247,80,175,241,36,231,243,58,110,160,115,67,57,67,122,34,24,93,45,47,172,244,216,173,215,138,141,8,236,14,228,139,20,207,250,143,198,4,62,121,96,208,56,28,243,224,97,102,111,191,175,208,44,228,18,27,24,58,246,120,77,232,31,192,81,127,178,13,227,209,168,72,169,129,145,24,75,150,100,105,198,178,120,156,177,68,196,160,100,148,2,79,228,238,113,240,161,109,87,195,230,254,152,238,51,130,218,183,203,255,8,137,198,169,80,60,225,172,64,37,88,34,35,82,227,94,28,5,64,17,197,89,90,2,189,174,255,252,35,180,149,150,80,223,118,104,232,145,251,38,143,206,15,231,179,169,246,229,155,182,117,67,81,199,230,121,55,189,151,195,128,136,80,1,207,20,13,72,56,230,44,9,67,193,10,49,74,89,153,112,201,147,56,46,82,65,3,178,163,173,246,29,94,180,107,35,247,155,100,135,117,254,167,69,253,15,11,248,55,91,117,118,174,47,153,212,183,50,133,179,183,50,105,187,96,247,11,3,221,56,119,50,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,110,219,48,12,253,21,67,237,49,10,36,91,182,36,31,215,118,64,128,118,11,154,173,151,38,7,74,162,90,3,142,93,216,202,134,44,200,191,79,118,146,182,233,122,155,14,182,69,241,61,146,207,79,59,114,25,182,47,72,74,242,101,126,183,104,125,152,94,181,29,78,231,93,107,177,239,167,183,173,133,186,250,3,166,198,57,116,176,198,128,221,3,212,27,236,111,171,62,76,146,247,32,50,33,151,191,198,51,82,62,238,200,44,224,250,231,204,69,102,235,172,202,89,90,80,167,188,161,34,85,156,130,97,57,77,25,20,133,227,41,104,110,34,216,182,245,102,221,220,97,128,57,132,103,82,238,200,200,22,9,192,9,205,92,174,40,203,5,80,225,84,78,117,42,34,159,83,162,40,208,100,90,101,100,63,33,189,125,198,53,140,69,223,192,130,131,87,26,53,149,57,139,213,209,24,170,44,88,234,125,166,77,33,148,224,104,7,240,49,255,13,248,120,241,56,235,191,255,110,176,91,140,188,165,135,186,199,213,52,70,63,4,110,106,92,99,19,202,29,178,20,165,98,138,42,153,106,42,172,150,212,104,38,41,23,74,250,20,185,76,165,218,71,192,171,150,229,78,32,71,38,117,70,33,71,27,197,1,65,141,52,113,54,235,99,175,188,144,12,113,128,220,52,161,10,219,171,81,163,114,7,200,80,228,22,168,21,58,167,194,163,164,144,105,71,51,48,67,13,228,5,151,251,213,197,106,24,204,85,253,75,13,219,135,127,231,187,71,112,137,109,27,95,117,107,28,191,2,216,208,39,102,155,212,195,81,156,177,170,167,95,171,174,15,73,21,127,103,210,250,164,195,126,83,135,170,121,138,233,117,141,54,84,109,51,157,185,67,169,151,51,143,188,47,182,91,30,140,182,36,229,242,115,171,29,223,7,105,207,205,118,238,179,37,153,44,201,162,221,116,118,96,203,226,230,250,221,132,99,129,49,229,195,246,100,172,24,105,54,117,125,140,92,67,128,83,226,41,220,186,202,87,232,102,205,226,228,167,145,133,29,23,253,228,113,90,135,222,254,7,118,7,13,60,97,247,45,142,255,214,251,107,151,63,162,132,39,98,147,234,156,73,238,169,68,136,102,195,34,165,202,113,160,154,107,227,51,153,165,222,167,35,250,30,61,118,216,88,60,111,140,23,6,179,34,231,84,121,76,169,224,185,142,120,199,40,40,150,57,81,168,204,185,236,136,239,71,181,135,27,125,236,107,144,106,79,246,251,213,254,47,246,205,96,123,65,4,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "50c67976474a4cfbb0665ca727be0505",
							"BaseElements.ChangeLeadContactEmail.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("68ee82f8-280b-40ce-951d-6e93d2945a8f");
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

		#region Class: ReadContactsByLeadPhoneFlowElement

		/// <exclude/>
		public class ReadContactsByLeadPhoneFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadContactsByLeadPhoneFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadContactsByLeadPhone";
				IsLogging = true;
				SchemaElementUId = new Guid("13eb0743-2f51-4864-9f5e-dd240ab8deb2");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,87,77,115,219,56,12,253,43,30,159,118,103,202,12,41,81,20,233,219,54,235,221,201,161,109,102,211,233,165,201,1,34,65,71,179,250,240,72,114,183,217,76,254,251,130,146,237,36,141,146,117,210,166,241,33,62,120,100,24,132,0,16,15,120,184,156,218,2,218,246,61,148,56,157,77,223,30,191,59,169,125,119,240,71,94,116,216,252,217,212,171,229,244,205,180,197,38,135,34,255,23,221,32,159,187,188,251,29,58,160,3,151,167,215,231,79,167,179,211,49,11,167,211,55,167,211,188,195,178,37,13,58,160,37,112,149,42,205,18,155,100,76,138,20,25,160,79,152,53,58,139,61,7,231,184,31,52,199,77,207,191,230,109,215,14,47,232,109,251,254,241,227,197,50,232,37,36,176,117,185,132,38,111,235,106,45,20,65,154,183,243,10,178,2,29,9,186,102,133,36,234,154,188,164,72,240,99,94,226,49,52,244,166,96,168,14,34,82,242,80,180,65,171,64,223,205,191,46,27,108,219,188,174,30,114,237,176,46,86,101,117,83,151,142,227,246,231,218,27,222,187,24,52,143,161,59,239,13,124,62,172,171,14,108,119,88,151,229,170,202,45,116,164,62,91,11,207,14,142,200,231,171,62,132,223,22,139,6,23,244,247,23,188,14,227,111,188,232,173,236,150,89,58,224,232,246,62,65,177,194,27,30,221,142,242,16,150,193,133,222,236,218,141,137,189,233,220,164,238,21,38,191,100,23,147,33,152,201,90,239,215,254,21,237,42,27,174,104,125,235,143,46,147,56,86,128,105,150,48,29,113,207,100,20,113,166,51,110,25,112,17,203,36,78,36,183,234,137,166,163,76,68,104,189,101,34,5,206,164,143,13,211,70,70,244,36,189,246,14,101,10,241,195,215,28,234,11,239,43,65,49,86,130,241,158,87,224,251,85,153,133,96,198,202,108,227,198,166,206,118,203,223,72,157,69,250,193,66,219,248,64,74,77,190,56,223,49,228,109,218,254,47,234,136,132,203,141,242,78,22,199,131,80,36,252,18,4,131,141,205,35,161,248,168,253,240,79,133,205,137,61,199,18,134,180,157,29,144,244,27,193,188,192,18,171,110,118,9,18,148,247,84,212,66,24,170,113,21,11,6,58,138,152,210,82,114,2,50,26,76,174,232,192,214,161,217,165,34,48,75,163,82,166,129,167,76,58,149,4,140,91,66,187,198,4,132,176,206,186,112,100,94,117,121,119,49,148,195,236,210,72,136,65,39,49,227,218,82,103,208,137,167,27,243,146,9,29,233,84,67,2,128,217,213,217,16,110,222,46,11,184,248,180,141,234,47,4,55,41,232,139,32,213,180,221,36,0,105,82,251,9,37,119,85,116,121,181,8,248,47,208,134,107,60,120,187,106,243,138,178,62,89,158,215,21,246,6,67,243,34,51,146,71,104,20,149,74,8,139,92,16,146,101,206,71,4,106,136,93,154,114,4,163,169,252,232,67,103,50,103,141,243,228,160,231,113,168,48,3,76,167,177,98,96,45,133,233,141,64,31,172,190,34,244,30,132,238,150,191,87,132,238,15,66,37,247,232,133,51,204,27,250,146,145,164,203,50,52,248,98,109,48,74,20,128,117,242,135,32,244,93,157,229,5,222,197,39,38,25,151,105,76,126,90,5,76,6,222,144,101,17,176,196,8,26,190,142,98,141,252,128,207,0,208,162,94,16,17,40,62,44,177,233,233,192,122,236,141,76,184,91,163,49,180,206,166,174,187,33,221,219,198,59,198,126,122,223,54,245,188,27,25,8,142,165,81,148,26,37,18,150,58,136,153,204,194,108,210,128,140,178,43,45,160,49,148,199,135,58,199,81,117,223,88,151,99,99,93,238,249,88,191,149,210,65,109,151,9,191,91,22,71,250,135,120,152,74,14,90,119,231,123,32,102,159,247,102,194,247,65,220,152,240,27,132,160,176,58,177,49,35,234,147,49,231,133,96,38,32,132,115,225,20,71,19,235,80,132,116,116,251,186,121,9,121,209,139,174,73,194,206,86,238,192,124,109,141,0,120,118,31,6,249,51,98,208,197,180,62,164,129,67,40,106,128,52,192,35,150,113,157,49,45,99,154,40,40,4,177,191,222,187,231,114,237,150,55,222,74,229,148,225,44,53,130,42,148,114,202,136,208,40,166,173,72,28,119,70,25,147,146,55,180,190,134,219,61,169,87,141,93,19,246,118,216,91,159,180,145,190,196,170,249,3,247,199,111,151,178,39,173,91,79,90,164,94,96,65,122,236,214,51,186,114,236,210,98,94,23,132,125,94,16,94,43,111,191,87,211,87,226,123,103,232,62,142,199,190,0,73,253,14,230,121,15,241,123,74,159,21,55,105,218,174,196,234,103,146,167,103,229,66,87,211,171,255,0,19,77,156,224,189,23,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,77,241,207,179,50,180,50,212,241,76,177,50,176,50,0,0,80,50,116,145,20,0,0,0 })));
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
								new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"));
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
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,75,76,53,72,53,49,77,78,212,77,54,177,52,213,53,73,75,53,215,77,52,182,76,209,53,78,76,50,55,50,183,72,53,52,51,52,7,0,106,93,85,138,36,0,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ChangeLeadContactPhoneFlowElement

		/// <exclude/>
		public class ChangeLeadContactPhoneFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeLeadContactPhoneFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeLeadContactPhone";
				IsLogging = true;
				SchemaElementUId = new Guid("1fe66c39-e645-4115-bb1f-6f62f33d667f");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifiedContact = () => (Guid)(((process.ReadContactsByLeadPhone.ResultEntity.IsColumnValueLoaded(process.ReadContactsByLeadPhone.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadContactsByLeadPhone.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifiedContact", () => _recordColumnValues_QualifiedContact.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifiedContact;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,201,110,219,48,16,253,23,157,195,64,251,226,91,155,186,133,129,182,49,224,32,151,40,135,17,57,146,137,106,3,73,167,117,13,255,123,135,146,236,58,133,145,184,189,52,190,88,124,120,243,230,205,182,115,120,13,90,127,133,6,157,153,243,126,249,101,213,149,230,250,163,172,13,170,79,170,219,244,206,149,163,81,73,168,229,79,20,35,62,23,210,124,0,3,20,176,203,127,199,231,206,44,63,167,144,59,87,185,35,13,54,154,24,54,32,142,60,215,243,129,165,158,240,88,88,8,159,101,152,209,51,73,2,17,138,56,43,128,79,204,179,210,55,93,211,131,194,49,195,32,94,14,159,119,219,222,18,61,2,248,64,145,186,107,39,48,176,22,244,188,133,162,70,65,111,163,54,72,144,81,178,161,74,240,78,54,184,4,69,153,172,78,103,33,34,149,80,107,203,170,177,52,243,31,189,66,173,101,215,190,108,173,222,52,237,41,151,194,241,248,156,204,184,131,67,203,92,130,89,15,2,11,50,181,31,60,190,171,42,133,21,24,249,116,106,225,27,110,7,222,101,189,163,0,65,243,185,135,122,131,39,57,159,215,113,3,189,25,203,25,211,19,65,201,106,125,97,165,199,110,189,86,172,79,96,127,32,95,164,120,214,191,31,19,248,100,129,81,227,240,153,59,15,11,125,251,189,69,181,226,107,108,96,236,216,227,53,161,127,0,71,253,217,206,11,92,183,136,2,100,126,22,115,22,166,81,202,210,32,78,89,152,5,32,184,31,65,18,242,253,227,232,67,234,190,134,237,253,49,221,103,4,49,181,203,254,17,18,165,113,193,41,132,121,34,160,153,148,162,96,128,152,48,95,120,94,88,38,1,247,179,146,166,107,127,118,8,93,37,57,212,183,61,42,26,242,208,100,247,252,114,62,219,106,91,190,234,58,51,22,117,108,158,117,51,120,57,44,72,192,139,194,13,162,136,65,226,39,44,20,60,97,84,105,204,162,40,2,215,139,5,162,176,171,70,87,109,59,188,234,54,138,79,151,164,199,115,254,167,67,253,15,7,248,55,87,117,118,175,47,217,212,183,178,133,139,183,178,105,123,103,255,11,92,62,159,190,50,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,114,155,48,16,253,21,70,201,209,242,0,18,66,226,216,36,157,241,76,210,122,226,54,23,219,135,149,180,74,152,193,224,1,185,29,151,241,191,87,96,59,137,211,220,170,3,160,213,190,183,187,143,167,158,92,251,253,22,73,65,190,204,31,22,141,243,211,155,166,197,233,188,109,12,118,221,244,190,49,80,149,127,64,87,56,135,22,54,232,177,125,130,106,135,221,125,217,249,73,244,30,68,38,228,250,215,120,70,138,101,79,102,30,55,63,103,54,48,115,151,43,39,172,164,130,51,75,185,86,41,149,66,74,138,54,49,74,104,165,193,201,0,54,77,181,219,212,15,232,97,14,254,133,20,61,25,217,2,1,88,174,98,155,73,26,103,28,40,183,50,163,42,229,130,90,43,185,16,168,153,146,140,28,38,164,51,47,184,129,177,232,27,152,39,129,94,161,162,121,22,107,202,81,107,42,13,24,234,28,83,90,112,201,19,52,3,248,148,255,6,92,94,45,103,221,247,223,53,182,139,145,183,112,80,117,184,158,134,232,135,192,93,133,27,172,125,209,39,12,117,156,115,70,83,151,37,148,75,193,169,114,25,134,70,83,30,131,150,22,117,122,8,128,87,45,139,94,229,82,38,67,162,75,147,32,142,227,138,134,121,28,21,34,53,185,140,209,89,163,6,200,93,237,75,191,191,25,53,42,122,192,24,121,102,128,26,174,178,128,194,156,2,83,150,50,208,121,154,75,76,68,146,31,214,87,235,97,48,91,118,219,10,246,79,255,206,247,136,96,35,211,212,174,108,55,56,126,121,48,190,139,244,62,170,134,163,237,75,83,99,55,253,90,182,157,143,202,240,63,163,198,69,45,118,187,202,151,245,115,200,175,42,52,190,108,234,233,204,30,107,109,47,76,242,190,90,191,58,58,109,69,138,213,231,94,59,189,143,218,94,186,237,210,104,43,50,89,145,69,179,107,205,192,198,194,230,246,221,136,99,129,49,229,195,246,236,172,16,169,119,85,117,138,220,130,135,115,226,57,220,216,210,149,104,103,245,226,108,168,145,37,62,45,250,201,227,188,142,189,253,15,236,1,106,120,198,246,91,24,255,173,247,215,46,127,4,9,207,196,58,85,89,156,39,142,230,8,42,56,91,132,123,101,19,160,42,81,218,177,156,165,206,165,35,250,17,29,182,88,27,188,108,44,17,26,153,8,70,149,14,83,202,147,76,5,188,141,41,200,152,89,46,36,179,150,157,240,221,168,246,112,165,79,125,13,82,29,200,225,176,62,252,5,61,151,41,130,66,4,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "50c67976474a4cfbb0665ca727be0505",
							"BaseElements.ChangeLeadContactPhone.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("68ee82f8-280b-40ce-951d-6e93d2945a8f");
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

		#region Class: ChangeDataUserTask1FlowElement

		/// <exclude/>
		public class ChangeDataUserTask1FlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataUserTask1FlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("01cee34b-f51b-441d-9110-09e5174d899d");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifiedContact = () => (Guid)((process.AddContactByLead.RecordId));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifiedContact", () => _recordColumnValues_QualifiedContact.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifiedContact;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,47,62,87,133,163,15,199,238,109,235,178,33,192,182,6,72,209,75,221,3,109,209,137,48,59,54,36,165,91,22,228,191,143,178,147,44,29,130,45,219,101,245,197,210,195,227,227,35,69,110,163,178,6,231,62,67,131,209,77,244,118,246,105,222,86,254,250,189,169,61,218,15,182,93,119,209,85,228,208,26,168,205,119,212,3,62,209,198,191,3,15,20,176,205,127,198,231,209,77,126,78,33,143,174,242,200,120,108,28,49,40,160,26,67,33,52,87,12,146,132,51,137,201,152,65,137,192,70,73,204,149,228,99,41,160,24,152,231,165,111,219,166,3,139,67,134,94,188,234,143,247,155,46,16,71,4,148,61,197,184,118,181,7,69,176,224,38,43,40,106,212,116,247,118,141,4,121,107,26,170,4,239,77,131,51,176,148,41,232,180,1,34,82,5,181,11,172,26,43,63,249,214,89,116,206,180,171,223,91,171,215,205,234,148,75,225,120,188,238,205,196,189,195,192,156,129,95,246,2,83,50,181,235,61,190,89,44,44,46,192,155,231,83,11,95,112,211,243,46,235,29,5,104,122,159,7,168,215,120,146,243,101,29,183,208,249,161,156,33,61,17,172,89,44,47,172,244,216,173,63,21,203,9,236,14,228,139,20,207,250,231,9,129,207,1,24,52,14,199,60,122,156,186,187,175,43,180,243,114,137,13,12,29,123,186,38,244,23,224,168,127,179,29,137,56,46,148,64,198,179,164,100,50,85,41,75,69,146,50,153,9,208,37,87,48,150,229,238,105,240,97,92,87,195,230,225,152,238,35,130,222,183,43,252,8,41,64,129,202,100,193,84,86,41,38,85,154,177,66,142,72,173,74,99,21,75,16,177,10,175,27,190,240,8,237,194,148,80,223,117,104,233,145,251,38,199,231,135,243,197,84,135,242,109,219,250,161,168,99,243,130,155,222,203,97,64,180,44,116,60,230,130,169,74,105,26,16,160,81,225,153,96,92,11,172,116,154,41,41,131,25,218,234,208,225,121,187,182,229,126,147,220,176,206,255,180,168,255,97,1,255,102,171,206,206,245,37,147,250,90,166,112,250,90,38,109,23,237,126,0,131,107,171,191,50,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,203,110,219,48,16,252,21,129,201,209,52,40,241,33,81,183,54,233,193,64,210,26,117,154,75,236,195,146,92,54,2,244,8,40,185,69,106,232,223,75,203,118,18,167,185,149,7,73,187,228,204,206,174,134,59,114,57,60,63,33,41,201,231,229,237,170,243,195,252,170,11,56,95,134,206,98,223,207,111,58,11,117,245,7,76,141,75,8,208,224,128,225,30,234,45,246,55,85,63,204,146,183,32,50,35,151,191,166,61,82,62,236,200,98,192,230,199,194,69,102,37,51,229,100,174,41,151,206,82,129,194,82,192,212,83,198,61,207,172,52,185,147,34,130,109,87,111,155,246,22,7,88,194,240,72,202,29,153,216,34,1,56,161,153,147,5,101,82,0,21,174,144,84,103,66,81,231,10,161,20,26,174,11,78,198,25,233,237,35,54,48,21,125,5,139,20,124,161,81,211,92,50,19,171,27,67,11,11,150,122,207,181,81,162,16,41,218,61,248,120,254,21,248,112,241,176,232,191,253,110,49,172,38,222,210,67,221,227,102,30,179,239,18,95,106,108,176,29,202,221,190,20,203,156,166,218,103,156,138,140,41,106,180,197,216,46,51,140,73,230,64,227,24,1,47,179,44,119,121,14,5,243,82,81,97,20,163,162,48,150,26,204,114,138,90,121,239,132,181,82,155,113,115,177,217,75,116,85,255,84,195,243,253,191,74,63,57,151,108,91,219,181,190,10,13,186,36,126,13,96,135,196,64,31,163,174,77,106,4,151,84,173,239,66,3,67,213,181,243,171,128,48,196,189,128,182,11,46,89,184,67,137,167,179,191,252,182,200,110,125,176,202,154,148,235,143,205,114,124,31,134,115,110,151,115,167,172,201,108,77,86,221,54,216,61,27,143,193,245,155,206,166,2,211,145,119,225,201,26,49,211,110,235,250,152,185,134,1,78,7,79,233,206,85,190,66,183,104,87,39,71,76,44,236,184,232,7,143,211,58,104,251,31,216,45,180,240,19,195,215,216,254,171,246,23,149,119,113,132,39,98,147,105,201,242,120,19,114,4,29,173,169,50,90,184,20,168,78,181,241,60,231,153,247,217,132,254,142,30,3,182,22,207,133,165,202,32,87,50,165,133,199,140,138,84,234,136,119,140,70,71,113,39,84,193,157,227,71,124,63,77,123,127,39,143,186,246,163,26,201,56,110,198,191,60,2,99,206,3,4,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "50c67976474a4cfbb0665ca727be0505",
							"BaseElements.ChangeDataUserTask1.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("68ee82f8-280b-40ce-951d-6e93d2945a8f");
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

		#region Class: ReadLandingPageFlowElement

		/// <exclude/>
		public class ReadLandingPageFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadLandingPageFlowElement(UserConnection userConnection, LeadManagementIdentification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadLandingPage";
				IsLogging = true;
				SchemaElementUId = new Guid("17eaa635-03e6-4644-8e7d-7a81a8f837a6");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,212,48,16,253,43,171,156,235,42,159,142,179,55,40,219,170,18,208,138,86,229,192,246,48,177,199,169,69,190,228,120,11,203,106,255,59,227,164,93,90,180,192,194,5,36,114,136,146,167,55,227,55,31,207,155,64,214,48,12,111,161,193,96,30,188,188,124,115,213,105,119,124,106,106,135,246,204,118,171,62,56,10,6,180,6,106,243,5,213,132,47,148,113,175,192,1,5,108,150,223,226,151,193,124,185,47,195,50,56,90,6,198,97,51,16,131,2,64,203,172,148,2,89,172,50,197,82,149,199,12,202,188,96,153,44,17,49,12,117,25,249,92,63,76,125,210,53,61,88,156,78,24,147,235,241,243,122,221,123,98,68,128,28,41,102,232,218,7,48,241,18,134,69,11,101,141,138,254,157,93,33,65,206,154,134,42,193,107,211,224,37,88,58,201,231,233,60,68,36,13,245,224,89,53,106,183,248,220,91,28,6,211,181,63,151,86,175,154,246,41,151,194,113,247,251,32,38,28,21,122,230,37,184,187,49,193,57,137,218,142,26,95,84,149,197,10,156,185,127,42,225,35,174,71,222,97,189,163,0,69,243,185,129,122,133,79,206,124,94,199,9,244,110,42,103,58,158,8,214,84,119,7,86,186,235,214,175,138,141,9,236,31,201,7,101,220,171,63,230,4,222,123,96,202,241,248,185,12,62,156,15,23,159,90,180,87,242,14,27,152,58,118,123,76,232,119,192,162,198,6,91,55,223,64,10,92,235,80,178,40,42,52,75,121,18,49,16,113,204,184,72,211,48,231,2,11,204,182,20,176,19,52,223,112,89,136,180,224,57,19,16,230,212,118,158,49,64,45,89,26,9,204,32,138,164,146,202,135,44,90,103,220,122,218,130,249,166,72,68,161,98,81,48,158,8,206,82,65,1,69,169,50,22,203,76,228,113,146,196,156,199,219,219,169,92,51,244,53,172,111,118,85,189,67,80,179,154,94,228,36,59,184,153,247,207,172,211,51,106,238,170,118,166,173,102,180,65,53,74,63,194,227,215,208,42,15,245,80,77,211,247,243,164,36,58,10,57,151,28,153,14,75,100,105,158,112,38,84,30,177,60,194,176,204,75,142,137,230,180,119,254,241,235,209,85,70,66,125,209,163,165,245,27,199,31,238,183,205,51,191,249,193,216,174,115,83,187,119,99,61,67,154,9,249,72,189,199,242,180,179,205,168,235,113,141,169,43,192,19,157,49,228,97,72,157,145,33,3,73,195,16,97,138,66,103,145,68,158,145,48,186,123,252,30,92,117,43,43,31,252,62,76,151,206,31,93,39,127,225,154,248,29,239,239,117,223,33,126,250,207,188,114,254,47,46,247,54,216,126,5,24,117,213,240,75,7,0,0 })));
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
								new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"));
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

		public LeadManagementIdentification(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadManagementIdentification";
			SchemaUId = new Guid("50c67976-474a-4cfb-b066-5ca727be0505");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = false;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_identificationPassed = () => { return (bool)(true); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("50c67976-474a-4cfb-b066-5ca727be0505");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LeadManagementIdentification, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LeadManagementIdentification, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid LeadId {
			get;
			set;
		}

		private Func<bool> _identificationPassed;
		public virtual bool IdentificationPassed {
			get {
				return (_identificationPassed ?? (_identificationPassed = () => false)).Invoke();
			}
			set {
				_identificationPassed = () => { return value; };
			}
		}

		private ProcessLeadIdentification _leadIdentification;
		public ProcessLeadIdentification LeadIdentification {
			get {
				return _leadIdentification ?? ((_leadIdentification) = new ProcessLeadIdentification(UserConnection, this));
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
					SchemaElementUId = new Guid("e4f191bb-2078-469f-a22b-36763fc3b878"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessTerminateEvent _leadIsIdentified;
		public ProcessTerminateEvent LeadIsIdentified {
			get {
				return _leadIsIdentified ?? (_leadIsIdentified = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "LeadIsIdentified",
					SchemaElementUId = new Guid("c634d34a-9984-4a62-a5cf-c01049fca1c0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ReadLeadDataFlowElement _readLeadData;
		public ReadLeadDataFlowElement ReadLeadData {
			get {
				return _readLeadData ?? (_readLeadData = new ReadLeadDataFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _exclusiveLeadHasCommunication;
		public ProcessExclusiveGateway ExclusiveLeadHasCommunication {
			get {
				return _exclusiveLeadHasCommunication ?? (_exclusiveLeadHasCommunication = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveLeadHasCommunication",
					SchemaElementUId = new Guid("63c2f821-e43f-4368-83f1-e2bda2505f5b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveLeadHasCommunication.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessTerminateEvent _leadDisqualified;
		public ProcessTerminateEvent LeadDisqualified {
			get {
				return _leadDisqualified ?? (_leadDisqualified = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "LeadDisqualified",
					SchemaElementUId = new Guid("f4df356b-d95c-43bc-a856-f9efad105482"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ReadContactsByLeadCommunicationsFlowElement _readContactsByLeadCommunications;
		public ReadContactsByLeadCommunicationsFlowElement ReadContactsByLeadCommunications {
			get {
				return _readContactsByLeadCommunications ?? (_readContactsByLeadCommunications = new ReadContactsByLeadCommunicationsFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeLeadContactAllFlowElement _changeLeadContactAll;
		public ChangeLeadContactAllFlowElement ChangeLeadContactAll {
			get {
				return _changeLeadContactAll ?? (_changeLeadContactAll = new ChangeLeadContactAllFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddContactByLeadFlowElement _addContactByLead;
		public AddContactByLeadFlowElement AddContactByLead {
			get {
				return _addContactByLead ?? (_addContactByLead = new AddContactByLeadFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddContactAdressFlowElement _addContactAdress;
		public AddContactAdressFlowElement AddContactAdress {
			get {
				return _addContactAdress ?? (_addContactAdress = new AddContactAdressFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddContactWebFlowElement _addContactWeb;
		public AddContactWebFlowElement AddContactWeb {
			get {
				return _addContactWeb ?? (_addContactWeb = new AddContactWebFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ParallelGatewayAddContactCommunicationFlowElement _parallelGatewayAddContactCommunication;
		public ParallelGatewayAddContactCommunicationFlowElement ParallelGatewayAddContactCommunication {
			get {
				return _parallelGatewayAddContactCommunication ?? ((_parallelGatewayAddContactCommunication) = new ParallelGatewayAddContactCommunicationFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ParallelGateway1FlowElement _parallelGateway1;
		public ParallelGateway1FlowElement ParallelGateway1 {
			get {
				return _parallelGateway1 ?? ((_parallelGateway1) = new ParallelGateway1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadContactsByLeadEmailFlowElement _readContactsByLeadEmail;
		public ReadContactsByLeadEmailFlowElement ReadContactsByLeadEmail {
			get {
				return _readContactsByLeadEmail ?? (_readContactsByLeadEmail = new ReadContactsByLeadEmailFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeLeadContactEmailFlowElement _changeLeadContactEmail;
		public ChangeLeadContactEmailFlowElement ChangeLeadContactEmail {
			get {
				return _changeLeadContactEmail ?? (_changeLeadContactEmail = new ChangeLeadContactEmailFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _exclusiveInLeadCommunication;
		public ProcessExclusiveGateway ExclusiveInLeadCommunication {
			get {
				return _exclusiveInLeadCommunication ?? (_exclusiveInLeadCommunication = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveInLeadCommunication",
					SchemaElementUId = new Guid("a4c733cc-151e-47ad-8dde-04d288bd539f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveInLeadCommunication.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ReadContactsByLeadPhoneFlowElement _readContactsByLeadPhone;
		public ReadContactsByLeadPhoneFlowElement ReadContactsByLeadPhone {
			get {
				return _readContactsByLeadPhone ?? (_readContactsByLeadPhone = new ReadContactsByLeadPhoneFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeLeadContactPhoneFlowElement _changeLeadContactPhone;
		public ChangeLeadContactPhoneFlowElement ChangeLeadContactPhone {
			get {
				return _changeLeadContactPhone ?? (_changeLeadContactPhone = new ChangeLeadContactPhoneFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeDataUserTask1FlowElement _changeDataUserTask1;
		public ChangeDataUserTask1FlowElement ChangeDataUserTask1 {
			get {
				return _changeDataUserTask1 ?? (_changeDataUserTask1 = new ChangeDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _exclusiveGatewayIsLeadSet;
		public ProcessExclusiveGateway ExclusiveGatewayIsLeadSet {
			get {
				return _exclusiveGatewayIsLeadSet ?? (_exclusiveGatewayIsLeadSet = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewayIsLeadSet",
					SchemaElementUId = new Guid("b9aa1247-b371-4815-926c-3b34166d62ce"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayIsLeadSet.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _actionAfterIdentificationScriptTask;
		public ProcessScriptTask ActionAfterIdentificationScriptTask {
			get {
				return _actionAfterIdentificationScriptTask ?? (_actionAfterIdentificationScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActionAfterIdentificationScriptTask",
					SchemaElementUId = new Guid("823adfbf-968a-44dc-be40-33f3ac4421f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ActionAfterIdentificationScriptTaskExecute,
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
					SchemaElementUId = new Guid("f5bceb61-c764-4125-8416-472d42e1cb8c"),
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

		private ReadLandingPageFlowElement _readLandingPage;
		public ReadLandingPageFlowElement ReadLandingPage {
			get {
				return _readLandingPage ?? (_readLandingPage = new ReadLandingPageFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("4003d719-b518-4975-b6e0-f769d615e6b4"),
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

		private ProcessConditionalFlow _contactFoundAll;
		public ProcessConditionalFlow ContactFoundAll {
			get {
				return _contactFoundAll ?? (_contactFoundAll = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ContactFoundAll",
					SchemaElementUId = new Guid("e86cf8b0-28a2-4a9b-b145-adf2cced025e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlowCommunicationAll;
		public ProcessConditionalFlow ConditionalFlowCommunicationAll {
			get {
				return _conditionalFlowCommunicationAll ?? (_conditionalFlowCommunicationAll = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlowCommunicationAll",
					SchemaElementUId = new Guid("146a48af-ec3c-47df-b53d-49db5dfca733"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlowEmailOnly;
		public ProcessConditionalFlow ConditionalFlowEmailOnly {
			get {
				return _conditionalFlowEmailOnly ?? (_conditionalFlowEmailOnly = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlowEmailOnly",
					SchemaElementUId = new Guid("94e08796-33d0-450f-a94d-43d4d8c7e5b4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _contactFoundEmail;
		public ProcessConditionalFlow ContactFoundEmail {
			get {
				return _contactFoundEmail ?? (_contactFoundEmail = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ContactFoundEmail",
					SchemaElementUId = new Guid("8ad3bb27-05b3-4197-85fe-9fca6ddb677c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlowPhonesOnly;
		public ProcessConditionalFlow ConditionalFlowPhonesOnly {
			get {
				return _conditionalFlowPhonesOnly ?? (_conditionalFlowPhonesOnly = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlowPhonesOnly",
					SchemaElementUId = new Guid("421b74c1-62c2-430b-965d-8d776c88a27f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _cntactFoundPhone;
		public ProcessConditionalFlow CntactFoundPhone {
			get {
				return _cntactFoundPhone ?? (_cntactFoundPhone = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "CntactFoundPhone",
					SchemaElementUId = new Guid("9bfd01fc-78f4-4b49-a5a3-0359fc93fab2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlowLeadUndefined;
		public ProcessConditionalFlow ConditionalFlowLeadUndefined {
			get {
				return _conditionalFlowLeadUndefined ?? (_conditionalFlowLeadUndefined = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlowLeadUndefined",
					SchemaElementUId = new Guid("86bf0460-da87-44e8-9e19-16d6bb74396c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _isNotFromLandingFlow;
		public ProcessConditionalFlow IsNotFromLandingFlow {
			get {
				return _isNotFromLandingFlow ?? (_isNotFromLandingFlow = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "IsNotFromLandingFlow",
					SchemaElementUId = new Guid("b15dccc1-cb8b-4db6-9245-c999d8b93476"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _dontContactFlow;
		public ProcessConditionalFlow DontContactFlow {
			get {
				return _dontContactFlow ?? (_dontContactFlow = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "DontContactFlow",
					SchemaElementUId = new Guid("6e54dca1-2410-4933-8d29-b9c06c6eb9c5"),
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
			FlowElements[Start.SchemaElementUId] = new Collection<ProcessFlowElement> { Start };
			FlowElements[LeadIsIdentified.SchemaElementUId] = new Collection<ProcessFlowElement> { LeadIsIdentified };
			FlowElements[ReadLeadData.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadLeadData };
			FlowElements[ExclusiveLeadHasCommunication.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveLeadHasCommunication };
			FlowElements[LeadDisqualified.SchemaElementUId] = new Collection<ProcessFlowElement> { LeadDisqualified };
			FlowElements[ReadContactsByLeadCommunications.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadContactsByLeadCommunications };
			FlowElements[ChangeLeadContactAll.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeLeadContactAll };
			FlowElements[AddContactByLead.SchemaElementUId] = new Collection<ProcessFlowElement> { AddContactByLead };
			FlowElements[AddContactAdress.SchemaElementUId] = new Collection<ProcessFlowElement> { AddContactAdress };
			FlowElements[AddContactWeb.SchemaElementUId] = new Collection<ProcessFlowElement> { AddContactWeb };
			FlowElements[ParallelGatewayAddContactCommunication.SchemaElementUId] = new Collection<ProcessFlowElement> { ParallelGatewayAddContactCommunication };
			FlowElements[ParallelGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ParallelGateway1 };
			FlowElements[ReadContactsByLeadEmail.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadContactsByLeadEmail };
			FlowElements[ChangeLeadContactEmail.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeLeadContactEmail };
			FlowElements[ExclusiveInLeadCommunication.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveInLeadCommunication };
			FlowElements[ReadContactsByLeadPhone.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadContactsByLeadPhone };
			FlowElements[ChangeLeadContactPhone.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeLeadContactPhone };
			FlowElements[ChangeDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask1 };
			FlowElements[ExclusiveGatewayIsLeadSet.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayIsLeadSet };
			FlowElements[ActionAfterIdentificationScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActionAfterIdentificationScriptTask };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ReadLandingPage.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadLandingPage };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayIsLeadSet", e.Context.SenderName));
						break;
					case "LeadIsIdentified":
						CompleteProcess();
						break;
					case "ReadLeadData":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ExclusiveLeadHasCommunication":
						if (ConditionalFlowCommunicationAllExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadContactsByLeadCommunications", e.Context.SenderName));
							break;
						}
						if (ConditionalFlowEmailOnlyExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadContactsByLeadEmail", e.Context.SenderName));
							break;
						}
						if (ConditionalFlowPhonesOnlyExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadContactsByLeadPhone", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LeadDisqualified", e.Context.SenderName));
						break;
					case "LeadDisqualified":
						CompleteProcess();
						break;
					case "ReadContactsByLeadCommunications":
						if (ContactFoundAllExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeLeadContactAll", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadContactsByLeadEmail", e.Context.SenderName));
						break;
					case "ChangeLeadContactAll":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveInLeadCommunication", e.Context.SenderName));
						break;
					case "AddContactByLead":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ParallelGatewayAddContactCommunication", e.Context.SenderName));
						break;
					case "AddContactAdress":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ParallelGateway1", e.Context.SenderName));
						break;
					case "AddContactWeb":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ParallelGateway1", e.Context.SenderName));
						break;
					case "ParallelGatewayAddContactCommunication":
						if (ParallelGatewayAddContactCommunication.IsAllPreviousFlowElementsExecuted()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddContactWeb", e.Context.SenderName));
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddContactAdress", e.Context.SenderName));
						}
						break;
					case "ParallelGateway1":
						if (ParallelGateway1.IsAllPreviousFlowElementsExecuted()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask1", e.Context.SenderName));
						}
						break;
					case "ReadContactsByLeadEmail":
						if (ContactFoundEmailExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeLeadContactEmail", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddContactByLead", e.Context.SenderName));
						break;
					case "ChangeLeadContactEmail":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveInLeadCommunication", e.Context.SenderName));
						break;
					case "ExclusiveInLeadCommunication":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ActionAfterIdentificationScriptTask", e.Context.SenderName));
						break;
					case "ReadContactsByLeadPhone":
						if (CntactFoundPhoneExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeLeadContactPhone", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddContactByLead", e.Context.SenderName));
						break;
					case "ChangeLeadContactPhone":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveInLeadCommunication", e.Context.SenderName));
						break;
					case "ChangeDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveInLeadCommunication", e.Context.SenderName));
						break;
					case "ExclusiveGatewayIsLeadSet":
						if (ConditionalFlowLeadUndefinedExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LeadDisqualified", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadData", e.Context.SenderName));
						break;
					case "ActionAfterIdentificationScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LeadIsIdentified", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (IsNotFromLandingFlowExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LeadDisqualified", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLandingPage", e.Context.SenderName));
						break;
					case "ReadLandingPage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (DontContactFlowExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LeadDisqualified", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveLeadHasCommunication", e.Context.SenderName));
						break;
			}
		}

		private bool ContactFoundAllExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadContactsByLeadCommunications.ResultEntity.IsColumnValueLoaded(ReadContactsByLeadCommunications.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? ReadContactsByLeadCommunications.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadContactsByLeadCommunications", "ContactFoundAll", "((ReadContactsByLeadCommunications.ResultEntity.IsColumnValueLoaded(ReadContactsByLeadCommunications.ResultEntity.Schema.Columns.GetByName(\"Id\").ColumnValueName) ? ReadContactsByLeadCommunications.ResultEntity.GetTypedColumnValue<Guid>(\"Id\") : Guid.Empty)) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlowCommunicationAllExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Email") : null)) != String.Empty && (((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("MobilePhone").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("MobilePhone") : null)) != String.Empty || ((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("BusinesPhone").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("BusinesPhone") : null)) != String.Empty));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveLeadHasCommunication", "ConditionalFlowCommunicationAll", "((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"Email\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>(\"Email\") : null)) != String.Empty && (((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"MobilePhone\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>(\"MobilePhone\") : null)) != String.Empty || ((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"BusinesPhone\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>(\"BusinesPhone\") : null)) != String.Empty)", result);
			return result;
		}

		private bool ConditionalFlowEmailOnlyExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Email") : null)) != String.Empty && ((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("MobilePhone").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("MobilePhone") : null)) == String.Empty && ((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("BusinesPhone").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("BusinesPhone") : null)) == String.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveLeadHasCommunication", "ConditionalFlowEmailOnly", "((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"Email\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>(\"Email\") : null)) != String.Empty && ((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"MobilePhone\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>(\"MobilePhone\") : null)) == String.Empty && ((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"BusinesPhone\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>(\"BusinesPhone\") : null)) == String.Empty", result);
			return result;
		}

		private bool ContactFoundEmailExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadContactsByLeadEmail.ResultEntity.IsColumnValueLoaded(ReadContactsByLeadEmail.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? ReadContactsByLeadEmail.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadContactsByLeadEmail", "ContactFoundEmail", "((ReadContactsByLeadEmail.ResultEntity.IsColumnValueLoaded(ReadContactsByLeadEmail.ResultEntity.Schema.Columns.GetByName(\"Id\").ColumnValueName) ? ReadContactsByLeadEmail.ResultEntity.GetTypedColumnValue<Guid>(\"Id\") : Guid.Empty)) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlowPhonesOnlyExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Email") : null)) == String.Empty && (((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("MobilePhone").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("MobilePhone") : null)) != String.Empty || ((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("BusinesPhone").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("BusinesPhone") : null)) != String.Empty));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveLeadHasCommunication", "ConditionalFlowPhonesOnly", "((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"Email\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>(\"Email\") : null)) == String.Empty && (((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"MobilePhone\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>(\"MobilePhone\") : null)) != String.Empty || ((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"BusinesPhone\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>(\"BusinesPhone\") : null)) != String.Empty)", result);
			return result;
		}

		private bool CntactFoundPhoneExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadContactsByLeadPhone.ResultEntity.IsColumnValueLoaded(ReadContactsByLeadPhone.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? ReadContactsByLeadPhone.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadContactsByLeadPhone", "CntactFoundPhone", "((ReadContactsByLeadPhone.ResultEntity.IsColumnValueLoaded(ReadContactsByLeadPhone.ResultEntity.Schema.Columns.GetByName(\"Id\").ColumnValueName) ? ReadContactsByLeadPhone.ResultEntity.GetTypedColumnValue<Guid>(\"Id\") : Guid.Empty)) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlowLeadUndefinedExpressionExecute() {
			bool result = Convert.ToBoolean((LeadId) == Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayIsLeadSet", "ConditionalFlowLeadUndefined", "(LeadId) == Guid.Empty", result);
			return result;
		}

		private bool IsNotFromLandingFlowExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("WebForm").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("WebFormId") : Guid.Empty)) == Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "IsNotFromLandingFlow", "((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"WebForm\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>(\"WebFormId\") : Guid.Empty)) == Guid.Empty", result);
			return result;
		}

		private bool DontContactFlowExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadLandingPage.ResultEntity.IsColumnValueLoaded(ReadLandingPage.ResultEntity.Schema.Columns.GetByName("CreateContact").ColumnValueName) ? ReadLandingPage.ResultEntity.GetTypedColumnValue<bool>("CreateContact") : false)) == false);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "DontContactFlow", "((ReadLandingPage.ResultEntity.IsColumnValueLoaded(ReadLandingPage.ResultEntity.Schema.Columns.GetByName(\"CreateContact\").ColumnValueName) ? ReadLandingPage.ResultEntity.GetTypedColumnValue<bool>(\"CreateContact\") : false)) == false", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("LeadId")) {
				writer.WriteValue("LeadId", LeadId, Guid.Empty);
			}
			if (!HasMapping("IdentificationPassed")) {
				writer.WriteValue("IdentificationPassed", IdentificationPassed, false);
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
			MetaPathParameterValues.Add("1300b53e-296c-4858-8368-493adc25a74c", () => LeadId);
			MetaPathParameterValues.Add("27623c14-f1c7-4872-8f1c-45103cd82954", () => IdentificationPassed);
			MetaPathParameterValues.Add("f7cf3a22-2a33-428e-9e2b-5f3622d92f72", () => ReadLeadData.DataSourceFilters);
			MetaPathParameterValues.Add("a01e5fd1-7cbb-4e06-9188-a9656c381385", () => ReadLeadData.ResultType);
			MetaPathParameterValues.Add("4db6d4f9-57aa-44ef-8934-56b12a060e0e", () => ReadLeadData.ReadSomeTopRecords);
			MetaPathParameterValues.Add("dc3c82bb-8c59-485f-9376-5880ae2ce035", () => ReadLeadData.NumberOfRecords);
			MetaPathParameterValues.Add("bcf6ac2d-9970-48a9-80e2-c7d41b6c0c2e", () => ReadLeadData.FunctionType);
			MetaPathParameterValues.Add("76636537-e5df-47a7-9eb6-124881330bf3", () => ReadLeadData.AggregationColumnName);
			MetaPathParameterValues.Add("232523cc-cb63-410d-8f7c-58cdcf2ef818", () => ReadLeadData.OrderInfo);
			MetaPathParameterValues.Add("6c984967-8a07-4d65-aefc-418e5a11cdcd", () => ReadLeadData.ResultEntity);
			MetaPathParameterValues.Add("e3cd6198-af4e-409b-8ba3-0851372ea038", () => ReadLeadData.ResultCount);
			MetaPathParameterValues.Add("7e4ceefa-cd15-47a3-8a3b-c8ad4ed1ef7f", () => ReadLeadData.ResultIntegerFunction);
			MetaPathParameterValues.Add("0a326237-a485-4b38-9337-3aa27272cdd9", () => ReadLeadData.ResultFloatFunction);
			MetaPathParameterValues.Add("f7b52dbf-c358-489e-bf2c-3c4ff7924a2c", () => ReadLeadData.ResultDateTimeFunction);
			MetaPathParameterValues.Add("dd6ab013-fc1e-4bc5-a25b-6855ace31f97", () => ReadLeadData.ResultRowsCount);
			MetaPathParameterValues.Add("c6cfc815-55cb-4def-b83c-14b182d467ce", () => ReadLeadData.CanReadUncommitedData);
			MetaPathParameterValues.Add("72ded882-b97d-4f56-91cb-1e6e212f4218", () => ReadLeadData.ResultEntityCollection);
			MetaPathParameterValues.Add("0a075eb5-bcac-445c-993d-bd329be8d6dc", () => ReadLeadData.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("17573208-3be8-4476-9823-f565b0714f28", () => ReadLeadData.IgnoreDisplayValues);
			MetaPathParameterValues.Add("807ae5d1-ceac-47d5-8eb5-4720a6cd38c0", () => ReadLeadData.ResultCompositeObjectList);
			MetaPathParameterValues.Add("5770885f-4a81-42ac-b246-d9db3aa13a28", () => ReadLeadData.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("b62c39d0-3349-4a21-9582-0f3e9fab1b13", () => ReadContactsByLeadCommunications.DataSourceFilters);
			MetaPathParameterValues.Add("15307ea3-405b-4286-937e-bbd0152634bb", () => ReadContactsByLeadCommunications.ResultType);
			MetaPathParameterValues.Add("b0de7902-f6c1-44eb-87ff-109bad0eb346", () => ReadContactsByLeadCommunications.ReadSomeTopRecords);
			MetaPathParameterValues.Add("d29cd82a-8e0d-4086-8795-48b2899e16af", () => ReadContactsByLeadCommunications.NumberOfRecords);
			MetaPathParameterValues.Add("daf2cf98-3c7e-4055-b671-143255e4ffb9", () => ReadContactsByLeadCommunications.FunctionType);
			MetaPathParameterValues.Add("34ed4a32-1e5a-4623-ae6a-18a622bf6230", () => ReadContactsByLeadCommunications.AggregationColumnName);
			MetaPathParameterValues.Add("97666c94-b7fa-4cf1-858f-96a7f5e41511", () => ReadContactsByLeadCommunications.OrderInfo);
			MetaPathParameterValues.Add("10568b26-1c18-4f39-9578-4a72a1c5fb66", () => ReadContactsByLeadCommunications.ResultEntity);
			MetaPathParameterValues.Add("935c4f95-44b6-44e3-920e-5b06a85a9a77", () => ReadContactsByLeadCommunications.ResultCount);
			MetaPathParameterValues.Add("567adf56-c83c-4371-b0d7-e3c15c4a747e", () => ReadContactsByLeadCommunications.ResultIntegerFunction);
			MetaPathParameterValues.Add("7ad0d0ed-5315-4834-9632-bc717ea4b547", () => ReadContactsByLeadCommunications.ResultFloatFunction);
			MetaPathParameterValues.Add("06ba8c97-f038-45da-8d5c-e5fa72c64ac0", () => ReadContactsByLeadCommunications.ResultDateTimeFunction);
			MetaPathParameterValues.Add("085f20cb-53af-486b-a15f-5bc389f586df", () => ReadContactsByLeadCommunications.ResultRowsCount);
			MetaPathParameterValues.Add("7b7d4ca0-20b2-450c-a302-c217ce695e2c", () => ReadContactsByLeadCommunications.CanReadUncommitedData);
			MetaPathParameterValues.Add("316aa43c-1aa6-47f1-aaf7-572b6f838fcf", () => ReadContactsByLeadCommunications.ResultEntityCollection);
			MetaPathParameterValues.Add("2cc24615-28c1-4668-8f49-c93ae2c5896a", () => ReadContactsByLeadCommunications.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("b4d0581e-c249-4b18-a38c-f40592d4085d", () => ReadContactsByLeadCommunications.IgnoreDisplayValues);
			MetaPathParameterValues.Add("2729cf7a-36f6-4003-b06a-e8cb957b2269", () => ReadContactsByLeadCommunications.ResultCompositeObjectList);
			MetaPathParameterValues.Add("f215686f-4d81-4543-93aa-539f611453e4", () => ReadContactsByLeadCommunications.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("9a626ad2-321e-427a-9f24-760d9280a022", () => ChangeLeadContactAll.EntitySchemaUId);
			MetaPathParameterValues.Add("564a7988-620b-401f-9bfc-8041ac06be95", () => ChangeLeadContactAll.IsMatchConditions);
			MetaPathParameterValues.Add("b7b1963b-962d-4921-a62e-3119d14d8a66", () => ChangeLeadContactAll.DataSourceFilters);
			MetaPathParameterValues.Add("5d16c9f4-5c23-4097-8d07-fac1cb716e39", () => ChangeLeadContactAll.RecordColumnValues);
			MetaPathParameterValues.Add("2c6aba36-8758-475f-ae50-d4a503c1975d", () => ChangeLeadContactAll.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("c43dec79-6b59-4fc6-94f0-bcc6a7f8c091", () => AddContactByLead.EntitySchemaId);
			MetaPathParameterValues.Add("61b7d5bc-8334-4d0a-8ec3-aac02f0f6b0d", () => AddContactByLead.DataSourceFilters);
			MetaPathParameterValues.Add("ec4e60e4-4bd2-476d-bfa5-f3879991dce5", () => AddContactByLead.RecordAddMode);
			MetaPathParameterValues.Add("fc9a7fd7-6ae6-4198-801f-ed65a0714560", () => AddContactByLead.FilterEntitySchemaId);
			MetaPathParameterValues.Add("0698fbce-2359-4022-88df-2b5fa4260af7", () => AddContactByLead.RecordDefValues);
			MetaPathParameterValues.Add("77a80f56-4b60-48bc-be27-e96ffd4cc59b", () => AddContactByLead.RecordId);
			MetaPathParameterValues.Add("bd8bab91-7c9c-4f46-a8ee-de69c8479c49", () => AddContactByLead.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("5a0a517a-3cd6-4838-89ed-dd198ad96f83", () => AddContactAdress.EntitySchemaId);
			MetaPathParameterValues.Add("dcf0939b-5ae1-4506-a7a2-453c0eb2f2d8", () => AddContactAdress.DataSourceFilters);
			MetaPathParameterValues.Add("55cf3377-2bf5-4a73-8eb5-34e7b911258b", () => AddContactAdress.RecordAddMode);
			MetaPathParameterValues.Add("6d55db5f-8e6c-420b-9a07-be564e8b90da", () => AddContactAdress.FilterEntitySchemaId);
			MetaPathParameterValues.Add("6aa29df7-9dcf-4eea-b7dd-70cbb55c6070", () => AddContactAdress.RecordDefValues);
			MetaPathParameterValues.Add("b9f11eba-9282-49e7-842b-28c1d0f2190f", () => AddContactAdress.RecordId);
			MetaPathParameterValues.Add("03d86494-8865-4f33-baa9-734e477aa2f5", () => AddContactAdress.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("97a7e2ca-58ad-4a27-8a87-3f50772b77be", () => AddContactWeb.EntitySchemaId);
			MetaPathParameterValues.Add("2f713b4e-bdb9-470a-b959-23af1cb99aaa", () => AddContactWeb.DataSourceFilters);
			MetaPathParameterValues.Add("9021827f-1e50-40f2-8b7f-ec1b0e056ccb", () => AddContactWeb.RecordAddMode);
			MetaPathParameterValues.Add("aa2e3f7d-4042-4910-b0eb-0f5b57896d58", () => AddContactWeb.FilterEntitySchemaId);
			MetaPathParameterValues.Add("7a98d7a0-39d9-4231-b19a-9c603fa6baf0", () => AddContactWeb.RecordDefValues);
			MetaPathParameterValues.Add("89ff5387-057a-41f9-a2cd-98c33da073a9", () => AddContactWeb.RecordId);
			MetaPathParameterValues.Add("bc163fe7-1547-4a7a-9a04-4e4956124bae", () => AddContactWeb.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("d6514abc-f96a-4d19-b5f8-f55b1ac00b83", () => ReadContactsByLeadEmail.DataSourceFilters);
			MetaPathParameterValues.Add("881a211c-0037-4de8-9966-fd5b76082530", () => ReadContactsByLeadEmail.ResultType);
			MetaPathParameterValues.Add("1b0558b6-d02e-43db-a632-da912ff74169", () => ReadContactsByLeadEmail.ReadSomeTopRecords);
			MetaPathParameterValues.Add("38ac0d8a-57fb-4d3c-a724-83243171725c", () => ReadContactsByLeadEmail.NumberOfRecords);
			MetaPathParameterValues.Add("2306c9f4-91b3-4ae6-9d0d-b85b15f043a5", () => ReadContactsByLeadEmail.FunctionType);
			MetaPathParameterValues.Add("91e3ad56-02d2-495e-8f8d-6839c1e13901", () => ReadContactsByLeadEmail.AggregationColumnName);
			MetaPathParameterValues.Add("09b2ffa0-b537-4970-bb51-a8da7fb89215", () => ReadContactsByLeadEmail.OrderInfo);
			MetaPathParameterValues.Add("4e1e0793-a5ec-42a4-b7b6-dcf4eb1670ee", () => ReadContactsByLeadEmail.ResultEntity);
			MetaPathParameterValues.Add("f289649e-c0c3-403b-8124-ffe171aafe33", () => ReadContactsByLeadEmail.ResultCount);
			MetaPathParameterValues.Add("e7d2a1ae-2033-4d71-9990-c4c12f4faa89", () => ReadContactsByLeadEmail.ResultIntegerFunction);
			MetaPathParameterValues.Add("681c5445-3ca2-45de-bf7c-0f37318944d1", () => ReadContactsByLeadEmail.ResultFloatFunction);
			MetaPathParameterValues.Add("95b392b6-a727-407b-a3ec-157c1314469b", () => ReadContactsByLeadEmail.ResultDateTimeFunction);
			MetaPathParameterValues.Add("0eadc500-3c91-49a1-8071-9d0668f51d38", () => ReadContactsByLeadEmail.ResultRowsCount);
			MetaPathParameterValues.Add("849f1602-4ec0-45ef-a640-370b4ec656e7", () => ReadContactsByLeadEmail.CanReadUncommitedData);
			MetaPathParameterValues.Add("847ce0c0-4e8f-4238-a637-16f20d906278", () => ReadContactsByLeadEmail.ResultEntityCollection);
			MetaPathParameterValues.Add("1cfe3a33-faaf-4cb5-b49e-d1eadaa81bec", () => ReadContactsByLeadEmail.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("f61ce3ad-7460-43d4-b04a-9a8735ba629d", () => ReadContactsByLeadEmail.IgnoreDisplayValues);
			MetaPathParameterValues.Add("98cf1789-f51a-4231-b152-7212be2cdca3", () => ReadContactsByLeadEmail.ResultCompositeObjectList);
			MetaPathParameterValues.Add("1921c84b-08d6-4bab-b0f8-1e4173f757ea", () => ReadContactsByLeadEmail.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("788c3395-e8dc-443e-9c81-e57decd44c14", () => ChangeLeadContactEmail.EntitySchemaUId);
			MetaPathParameterValues.Add("40c79c51-5e3e-4a77-881f-bfb3b5148e9c", () => ChangeLeadContactEmail.IsMatchConditions);
			MetaPathParameterValues.Add("3da883c3-07af-4baf-9a48-e1f261dbd978", () => ChangeLeadContactEmail.DataSourceFilters);
			MetaPathParameterValues.Add("bec4aa50-4e70-47b5-99c8-d0f15b4b12f8", () => ChangeLeadContactEmail.RecordColumnValues);
			MetaPathParameterValues.Add("5211e1fa-3ffd-44d3-a820-58f034e21f3c", () => ChangeLeadContactEmail.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("55598db2-619f-4f92-a9b5-d03ddb173ed0", () => ReadContactsByLeadPhone.DataSourceFilters);
			MetaPathParameterValues.Add("519549f0-c248-40b5-be93-602f4ff55bac", () => ReadContactsByLeadPhone.ResultType);
			MetaPathParameterValues.Add("c1675f40-4a8b-469f-807f-482b441e6236", () => ReadContactsByLeadPhone.ReadSomeTopRecords);
			MetaPathParameterValues.Add("8aacc82f-451e-44f0-a1ea-c48fac82b9aa", () => ReadContactsByLeadPhone.NumberOfRecords);
			MetaPathParameterValues.Add("1a7cefdb-8943-464e-9818-f056350796f1", () => ReadContactsByLeadPhone.FunctionType);
			MetaPathParameterValues.Add("a45be9e6-9a59-46ac-b1b7-9def07669d0c", () => ReadContactsByLeadPhone.AggregationColumnName);
			MetaPathParameterValues.Add("6b161822-7e93-4124-b2d6-c1605b5f5657", () => ReadContactsByLeadPhone.OrderInfo);
			MetaPathParameterValues.Add("97881864-f21d-4f49-b39f-662c780efdc9", () => ReadContactsByLeadPhone.ResultEntity);
			MetaPathParameterValues.Add("83016a9c-a67e-4328-a96e-bfacfc2c77c6", () => ReadContactsByLeadPhone.ResultCount);
			MetaPathParameterValues.Add("a0d9ba4a-555e-4324-ae31-f59d0233fbc6", () => ReadContactsByLeadPhone.ResultIntegerFunction);
			MetaPathParameterValues.Add("5b48e127-d50b-49a3-8459-4a9a52bf6988", () => ReadContactsByLeadPhone.ResultFloatFunction);
			MetaPathParameterValues.Add("6ef7572f-4836-4cfe-ad97-3868281a4281", () => ReadContactsByLeadPhone.ResultDateTimeFunction);
			MetaPathParameterValues.Add("ce2e72d3-d7a5-4f50-9ecf-44b4bf27b6ea", () => ReadContactsByLeadPhone.ResultRowsCount);
			MetaPathParameterValues.Add("98faeefc-cf3f-4be3-a9b9-40bd344629d3", () => ReadContactsByLeadPhone.CanReadUncommitedData);
			MetaPathParameterValues.Add("e75f4ff2-ebaa-43f4-aff7-36f8fa2f00cd", () => ReadContactsByLeadPhone.ResultEntityCollection);
			MetaPathParameterValues.Add("1a5f9685-0340-43a4-85bd-917ac7f8b75a", () => ReadContactsByLeadPhone.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("4a757dc8-11a2-46d0-962c-01dc9f7cf05c", () => ReadContactsByLeadPhone.IgnoreDisplayValues);
			MetaPathParameterValues.Add("d1a04b45-329c-4e0c-90b8-b7463582c944", () => ReadContactsByLeadPhone.ResultCompositeObjectList);
			MetaPathParameterValues.Add("822209b4-c7f7-4d36-9ddf-32a904b93bda", () => ReadContactsByLeadPhone.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("cfc1a8ae-2a77-49bb-a728-a1637ee8c94a", () => ChangeLeadContactPhone.EntitySchemaUId);
			MetaPathParameterValues.Add("5feb2bce-5433-4c25-a83d-3f8d28ccc8ab", () => ChangeLeadContactPhone.IsMatchConditions);
			MetaPathParameterValues.Add("9acd36f8-ce89-4f92-bdb8-e4eea778daf4", () => ChangeLeadContactPhone.DataSourceFilters);
			MetaPathParameterValues.Add("15555f52-d536-4815-a506-977a98d2f0f3", () => ChangeLeadContactPhone.RecordColumnValues);
			MetaPathParameterValues.Add("99d9c01e-8ac9-41e6-a4ee-12e2c816886a", () => ChangeLeadContactPhone.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("3719e46d-8e08-48ad-8083-1ccf953996c6", () => ChangeDataUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("08550f59-4992-48fb-b252-df02ec268766", () => ChangeDataUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("44584732-acad-4754-bde4-a1b1cfd19199", () => ChangeDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("33aca163-6ecf-4e71-9484-09432fbc4746", () => ChangeDataUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("cb50f943-4702-4fd8-9aa9-5698a33e9475", () => ChangeDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("cd3fabe0-1945-4d5e-9fb8-9e85ee54cc3b", () => ReadLandingPage.DataSourceFilters);
			MetaPathParameterValues.Add("c84ed90e-913c-4d79-be6e-0aeb6dbde695", () => ReadLandingPage.ResultType);
			MetaPathParameterValues.Add("528b68b1-c488-499b-b6a9-98d627973317", () => ReadLandingPage.ReadSomeTopRecords);
			MetaPathParameterValues.Add("7db9bc2b-3431-4feb-8af1-b2fcbc5cf552", () => ReadLandingPage.NumberOfRecords);
			MetaPathParameterValues.Add("50c50a69-929a-4ae1-8501-1657483ac91c", () => ReadLandingPage.FunctionType);
			MetaPathParameterValues.Add("5a09f02d-d645-448c-a427-3dc0ad363ad0", () => ReadLandingPage.AggregationColumnName);
			MetaPathParameterValues.Add("2793b917-606e-429f-8d6b-56caf9a5d36b", () => ReadLandingPage.OrderInfo);
			MetaPathParameterValues.Add("a435ea7f-ecdc-4500-acc1-f4ab6e8b2a76", () => ReadLandingPage.ResultEntity);
			MetaPathParameterValues.Add("e0010511-9818-4608-8cc6-966c057c7fb7", () => ReadLandingPage.ResultCount);
			MetaPathParameterValues.Add("5ce1ad73-33d5-4d54-99dc-103fe2185918", () => ReadLandingPage.ResultIntegerFunction);
			MetaPathParameterValues.Add("f1d51e05-81e8-439e-be55-ef17ce69d451", () => ReadLandingPage.ResultFloatFunction);
			MetaPathParameterValues.Add("5400d0e0-9171-4da4-9833-ee4bc440d882", () => ReadLandingPage.ResultDateTimeFunction);
			MetaPathParameterValues.Add("fe6f5c9f-37df-4b0d-b855-65847152e915", () => ReadLandingPage.ResultRowsCount);
			MetaPathParameterValues.Add("ec12f3b9-746c-4f92-ba49-ce658079412a", () => ReadLandingPage.CanReadUncommitedData);
			MetaPathParameterValues.Add("6dc416c9-504c-4429-b04e-93f543f173c4", () => ReadLandingPage.ResultEntityCollection);
			MetaPathParameterValues.Add("b66e4485-d571-44cb-9e32-b832c83541ca", () => ReadLandingPage.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("1c52f53d-1e03-445c-bcbe-0982a59c336a", () => ReadLandingPage.IgnoreDisplayValues);
			MetaPathParameterValues.Add("aadf92c2-302e-499d-a17e-33c74ef006bd", () => ReadLandingPage.ResultCompositeObjectList);
			MetaPathParameterValues.Add("b3f6ea08-bb3d-48ff-bb96-9f7e3530b585", () => ReadLandingPage.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "LeadId":
					if (!hasValueToRead) break;
					LeadId = reader.GetValue<System.Guid>();
				break;
				case "IdentificationPassed":
					if (!hasValueToRead) break;
					IdentificationPassed = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ActionAfterIdentificationScriptTaskExecute(ProcessExecutingContext context) {
			ActionAfterIdentification();
			return true;
		}

			
			public virtual void ActionAfterIdentification() {
				string applicationUrl = string.Empty;
				if (BPMSoft.Web.Http.Abstractions.HttpContext.Current != null) {
					applicationUrl = BPMSoft.Web.Common.WebUtilities.GetParentApplicationUrl(BPMSoft.Web.Http.Abstractions.HttpContext.Current.Request);
				}
				var leadQualificationHelper = ClassFactory.Get<LeadQualificationHelper>(new ConstructorArgument[]{
					new ConstructorArgument("userConnection", UserConnection),
					new ConstructorArgument("applicationUrl", applicationUrl)
				});
				leadQualificationHelper.ActionAfterIdentification(LeadId);
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
			var cloneItem = (LeadManagementIdentification)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

