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

	#region Class: LeadManagementDisqualificationSchema

	/// <exclude/>
	public class LeadManagementDisqualificationSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LeadManagementDisqualificationSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LeadManagementDisqualificationSchema(LeadManagementDisqualificationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LeadManagementDisqualification";
			UId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3");
			CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5");
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
			SerializeToMemory = true;
			Tag = @"LeadManagementDisqualification";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3");
			Version = 0;
			PackageUId = new Guid("34a08715-d94b-478c-887e-dbb951baceeb");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateQualificationProcessIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("dfb6d9c3-dafe-46e1-80ad-be11953cf50a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Name = @"QualificationProcessId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{5c812ead-9e0e-4e95-91c1-b0a297de4131}].[Parameter:{5056dd51-b8ad-4402-af00-1569d1a4b1ac}].[EntityColumn:{9fb3dc53-b29b-46e2-ba98-ae587bf61fb2}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateQualificationProcessIdParameter());
		}

		protected virtual void InitializeLeadStageChangedStartSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7b88593e-3322-4c2d-846d-b8f3a9a1d3b2"),
				ContainerUId = new Guid("fca1bd17-d4df-4b32-8533-5a8b589d5085"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fca1bd17-d4df-4b32-8533-5a8b589d5085"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
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
				UId = new Guid("c39e1c18-9a60-4c66-9faf-c847b74c2df5"),
				ContainerUId = new Guid("fca1bd17-d4df-4b32-8533-5a8b589d5085"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fca1bd17-d4df-4b32-8533-5a8b589d5085"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeReadContactDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("40ec267a-a7cd-4d95-a98c-9a1d12e5cca3"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,85,77,111,219,48,12,253,43,129,207,85,33,219,242,87,110,91,151,13,57,108,45,214,162,151,165,7,90,162,82,97,254,8,100,165,91,22,228,191,143,178,155,44,221,178,46,40,10,172,216,124,48,108,226,145,122,36,31,169,117,32,43,232,186,15,80,99,48,14,94,95,188,191,108,181,59,125,107,42,135,246,157,109,151,139,224,36,232,208,26,168,204,55,84,131,125,162,140,123,3,14,200,97,61,251,225,63,11,198,179,67,17,102,193,201,44,48,14,235,142,16,228,128,74,203,82,196,146,233,80,103,76,104,144,172,148,2,88,158,23,177,138,18,206,85,17,13,200,195,161,207,218,122,1,22,135,19,250,224,186,255,188,90,45,60,48,36,131,236,33,166,107,155,123,99,236,41,116,147,6,202,10,21,253,59,187,68,50,57,107,106,202,4,175,76,141,23,96,233,36,31,167,245,38,2,105,168,58,143,170,80,187,201,215,133,197,174,51,109,243,56,181,106,89,55,251,88,114,199,221,239,61,25,222,51,244,200,11,112,183,125,128,179,182,209,198,214,158,219,166,167,250,106,62,183,56,7,103,238,246,153,124,198,85,15,63,174,132,228,160,168,77,215,80,45,113,91,156,232,151,124,206,96,225,134,180,30,208,32,156,53,243,219,35,19,223,21,239,79,185,251,243,23,91,240,81,17,127,159,199,157,55,108,171,179,217,248,194,165,17,213,34,141,57,75,98,13,76,68,58,102,57,164,5,147,113,38,226,92,67,34,100,249,191,105,107,122,164,168,142,171,221,129,102,240,71,53,53,125,241,98,138,210,61,49,81,140,237,231,44,248,52,237,206,191,52,104,47,229,45,214,48,84,236,230,148,172,63,25,38,21,214,216,184,241,58,145,121,24,33,40,86,32,71,38,176,72,88,17,202,144,149,28,162,34,83,40,194,56,220,144,195,142,16,185,240,36,85,42,33,76,78,126,66,240,136,129,230,156,133,73,90,168,16,68,25,130,244,46,147,198,25,183,26,84,48,94,131,18,5,87,73,206,120,66,115,47,84,78,7,69,34,101,74,229,34,77,177,140,139,60,222,220,12,233,154,110,81,193,234,122,151,213,71,34,56,170,232,69,91,218,118,110,228,119,243,168,213,35,42,238,178,114,166,153,143,72,65,21,74,223,66,146,93,227,64,186,62,146,111,37,249,147,16,226,72,23,17,139,209,159,157,22,36,148,132,43,6,81,169,120,26,131,34,193,144,228,252,227,149,209,206,141,132,234,124,129,150,148,215,119,158,31,158,152,7,163,230,123,98,219,214,13,149,222,117,116,159,206,86,184,101,153,113,149,99,198,84,33,137,79,86,102,172,16,57,176,18,84,148,101,90,134,60,214,196,135,110,50,223,249,203,118,105,229,253,132,119,195,21,246,164,203,233,47,44,134,39,220,36,7,199,238,152,65,122,254,141,251,66,11,54,125,238,74,253,227,235,100,250,130,150,192,38,216,124,7,0,171,88,79,193,10,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e79bf73d-74cf-4335-853b-937287105f36"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7913e1e4-9e87-4692-9069-55b03a1b9232"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b9faa3f9-e91c-4350-bcb6-0ee0428ce70c"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ee0ce0fc-fd5f-4994-bc91-51aa9c50669a"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("99edb6c9-e18a-4b79-8ac7-b906d830fb52"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ed53142f-e2f8-4b8c-9a9f-c658f11be2ab"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("da6b78a7-a73e-4724-8ca9-b95af2c60105"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("821d7f8d-8a3f-4770-b9b8-ebd3f9233a98"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fa834639-2221-4cd8-8911-dc298bc99e16"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5297ac4f-fc6d-4cb0-9678-95f6c5108b5c"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e545c311-11e1-46d0-9aaa-4e1f54abda07"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("963f06c1-e4a8-4bf8-b945-29f477df51b9"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ac4dc6fe-5e17-4ca5-8ff9-902d0bb960fd"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("422d4901-ab76-4ef0-8ab8-1554f56cea82"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e4e55b30-0ac9-4bc7-a39e-3a01d5ad7018"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8c65435c-2c20-453a-8a46-cca74d849630"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("db32d26f-c21d-4e9b-b60c-f99dc7f50800"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("66a9112b-0a3e-4891-9211-47e448897fa1"),
				ContainerUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeReadLeadDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c5f5b5ca-c522-4aad-a8d8-999393894c04"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,20,252,43,65,135,158,172,96,125,216,150,220,227,178,45,11,37,13,109,90,10,73,8,79,210,211,174,192,31,27,91,166,9,102,255,123,181,235,108,11,57,148,28,122,41,232,32,61,105,230,205,12,79,243,67,24,63,132,38,226,80,123,104,70,204,166,141,171,73,137,44,87,210,10,90,176,210,83,233,176,164,32,11,73,25,87,22,65,9,224,204,144,172,131,22,107,178,160,215,46,68,146,133,136,237,88,223,206,127,72,227,48,97,246,224,79,135,175,118,135,45,124,59,54,144,12,188,210,168,105,85,228,134,74,52,134,42,11,150,122,47,180,41,165,146,12,45,89,180,104,231,21,175,164,163,218,235,164,165,224,140,42,39,10,42,148,205,115,195,75,46,84,78,178,6,125,92,63,237,7,28,199,208,119,245,140,191,247,55,207,251,164,114,233,189,234,155,169,237,72,214,98,132,107,136,187,154,0,230,40,11,11,212,74,93,80,233,177,162,32,180,163,2,76,197,43,133,172,100,21,201,44,236,227,145,150,108,28,201,28,68,248,14,205,132,39,230,57,36,141,92,228,76,21,101,194,50,97,169,20,60,167,170,84,21,245,174,244,26,69,169,181,113,231,188,62,78,33,237,195,120,53,181,56,4,251,18,59,166,252,250,161,158,109,223,197,161,111,142,212,87,167,231,55,248,20,151,112,95,174,126,44,134,98,170,31,65,228,144,77,35,174,154,128,93,92,119,182,119,161,219,46,156,135,67,130,180,123,24,194,120,78,97,253,56,65,67,178,33,108,119,127,77,107,53,141,177,111,255,35,171,89,178,153,56,210,144,157,228,30,103,208,133,113,223,192,243,233,92,147,119,143,83,31,223,127,66,112,23,99,132,45,94,216,29,116,91,116,151,95,208,246,131,187,216,184,229,5,121,197,84,147,59,226,45,48,227,88,69,157,116,105,2,141,224,84,21,34,125,14,80,166,80,218,21,185,42,46,43,163,84,161,5,82,33,56,167,210,114,71,149,44,29,53,202,11,208,192,156,48,252,142,36,11,255,80,216,237,102,252,252,179,59,127,172,37,138,251,203,84,125,85,88,55,216,166,204,234,249,45,78,14,9,112,125,110,85,207,111,241,117,184,63,58,187,63,164,245,11,15,198,51,90,80,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("959030b1-25af-4cd9-b5e7-5a744bdaedf0"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("093e10f8-8eef-4d51-9167-1a7a01cd507f"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6d51a122-e70a-433e-9818-82f47a7aeafb"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c5d5908e-a924-4a0c-87fe-396c1eed83f1"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0bde32d3-80c0-4cb2-85a9-e9d0248e1cfe"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7ef1809d-3038-4732-a5e8-f856ec73ed85"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("5056dd51-b8ad-4402-af00-1569d1a4b1ac"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8399996e-d16e-4a0d-8a6c-d6f8f3077d8c"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("18028651-6139-43f8-afd6-2480c010cb30"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a0d37cec-a28e-4776-8424-b9fb9052daa3"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5cd05c9b-4654-4a13-9dab-234f585de3b2"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e3077e0b-4a11-42b8-80c8-e2a3808dae05"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0ffd69eb-68b9-4b76-99c8-e81148f86182"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4467b208-843d-4f64-afe0-7a290b704b5c"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("76541bf9-a56b-425f-8612-0c857be8f9b6"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9424fa47-cc52-45e9-b48d-98a75c45d72d"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f13d2218-157b-46dd-a0d9-3bfb12f95274"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4f3391d4-629c-4271-9d8e-ec411a1710f7"),
				ContainerUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaLaneSet schemaMainLaneSet = CreateMainLaneSetLaneSet();
			LaneSets.Add(schemaMainLaneSet);
			ProcessSchemaLane schemaMainLane = CreateMainLaneLane();
			schemaMainLaneSet.Lanes.Add(schemaMainLane);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaStartSignalEvent leadstagechangedstartsignal = CreateLeadStageChangedStartSignalStartSignalEvent();
			FlowElements.Add(leadstagechangedstartsignal);
			ProcessSchemaUserTask readcontactdatausertask = CreateReadContactDataUserTaskUserTask();
			FlowElements.Add(readcontactdatausertask);
			ProcessSchemaUserTask readleaddatausertask = CreateReadLeadDataUserTaskUserTask();
			FlowElements.Add(readleaddatausertask);
			ProcessSchemaScriptTask detachleadscripttask = CreateDetachLeadScriptTaskScriptTask();
			FlowElements.Add(detachleadscripttask);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("a1b55d09-2cc0-40a6-92ed-7894787973de"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fca1bd17-d4df-4b32-8533-5a8b589d5085"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow4",
				UId = new Guid("222487e2-6c99-4b8e-999b-9cf120c86771"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("22c65d4f-3a16-4535-b75a-59b6538812d9"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				CurveCenterPosition = new Point(600, 174),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7273fec0-03c3-42e6-a0da-01828c552d9c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0b58be4a-4d85-426d-a3fe-edaab7536d93"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(329, 134));
			schemaFlow.PolylinePointPositions.Add(new Point(814, 134));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("36657ba9-c834-4a14-b7b3-7c94b26f9df2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("22c65d4f-3a16-4535-b75a-59b6538812d9"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				CurveCenterPosition = new Point(320, 184),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7273fec0-03c3-42e6-a0da-01828c552d9c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("82f6af9e-9756-45d6-ace6-29fda131a0c9"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{5c812ead-9e0e-4e95-91c1-b0a297de4131}].[Parameter:{5056dd51-b8ad-4402-af00-1569d1a4b1ac}].[EntityColumn:{ad490d58-054a-4d85-9246-dd8466eb3983}]#]  !=  Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("22c65d4f-3a16-4535-b75a-59b6538812d9"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				CurveCenterPosition = new Point(476, 180),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7273fec0-03c3-42e6-a0da-01828c552d9c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("2d6a85fd-5246-4e3e-b3ed-e41e3eebc517"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9991b8a2-84b0-4228-a2dc-a24cad0bd72d"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0b58be4a-4d85-426d-a3fe-edaab7536d93"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("77567f62-1a7e-4348-bc78-7cc946b0e6ec"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("16442db3-34f7-48da-8d65-c9c1885540dd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("34a08715-d94b-478c-887e-dbb951baceeb"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0b58be4a-4d85-426d-a3fe-edaab7536d93"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateMainLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaMainLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("77c6ef5e-4575-475d-9c5b-a782147567c0"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Name = @"MainLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaMainLaneSet;
		}

		protected virtual ProcessSchemaLane CreateMainLaneLane() {
			ProcessSchemaLane schemaMainLane = new ProcessSchemaLane(this) {
				UId = new Guid("2e6f94b4-a500-4557-9add-3a25b3c1f2d3"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("77c6ef5e-4575-475d-9c5b-a782147567c0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Name = @"MainLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaMainLane;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("77567f62-1a7e-4348-bc78-7cc946b0e6ec"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2e6f94b4-a500-4557-9add-3a25b3c1f2d3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Name = @"Terminate1",
				Position = new Point(913, 163),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateLeadStageChangedStartSignalStartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("fca1bd17-d4df-4b32-8533-5a8b589d5085"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2e6f94b4-a500-4557-9add-3a25b3c1f2d3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Name = @"LeadStageChangedStartSignal",
				NewEntityChangedColumns = false,
				Position = new Point(106, 163),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaStartSignalEvent.EntityChangedColumns.Add("bc0c2d60-5a3d-4840-aa4e-c60ea776e206");
			InitializeLeadStageChangedStartSignalParameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadContactDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2e6f94b4-a500-4557-9add-3a25b3c1f2d3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Name = @"ReadContactDataUserTask",
				Position = new Point(508, 149),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadContactDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadLeadDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2e6f94b4-a500-4557-9add-3a25b3c1f2d3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Name = @"ReadLeadDataUserTask",
				Position = new Point(176, 149),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadLeadDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateDetachLeadScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("0b58be4a-4d85-426d-a3fe-edaab7536d93"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2e6f94b4-a500-4557-9add-3a25b3c1f2d3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Name = @"DetachLeadScriptTask",
				Position = new Point(780, 149),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,81,221,106,195,32,20,190,78,160,239,32,189,74,160,248,2,163,55,201,146,18,216,160,107,214,221,139,57,177,130,57,22,163,221,202,216,187,79,141,27,29,172,16,48,28,191,223,163,28,73,241,226,152,146,163,228,204,74,141,123,163,57,204,115,55,208,110,110,166,179,189,22,101,73,62,87,121,102,192,58,131,196,26,7,15,171,252,107,149,39,36,57,167,115,75,142,51,152,90,35,2,15,74,52,1,26,20,18,129,182,18,135,52,169,174,199,110,184,103,251,170,123,107,36,138,162,220,68,179,210,187,73,159,242,215,102,75,208,41,117,39,212,13,146,246,150,89,23,9,73,125,25,208,131,67,244,6,139,194,15,184,102,200,65,53,31,192,93,200,83,4,219,236,194,12,81,192,6,223,13,225,157,84,251,231,94,143,150,250,142,163,20,206,196,228,244,201,3,138,191,213,35,121,231,228,16,217,93,224,7,148,247,23,80,159,24,10,8,255,198,246,82,32,83,244,0,92,27,15,11,172,80,32,144,104,11,150,159,90,163,167,199,42,14,186,33,61,68,22,175,123,176,181,86,110,194,55,166,28,20,235,255,183,185,222,44,203,10,202,137,199,46,176,148,243,219,242,223,237,6,191,1,193,132,205,9,13,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("7273fec0-03c3-42e6-a0da-01828c552d9c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2e6f94b4-a500-4557-9add-3a25b3c1f2d3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("22c65d4f-3a16-4535-b75a-59b6538812d9"),
				CreatedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"),
				Name = @"ExclusiveGateway2",
				Position = new Point(302, 149),
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

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LeadManagementDisqualification(userConnection);
		}

		public override object Clone() {
			return new LeadManagementDisqualificationSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadManagementDisqualification

	/// <exclude/>
	public class LeadManagementDisqualification : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessMainLane

		/// <exclude/>
		public class ProcessMainLane : ProcessLane
		{

			public ProcessMainLane(UserConnection userConnection, LeadManagementDisqualification process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ReadContactDataUserTaskFlowElement

		/// <exclude/>
		public class ReadContactDataUserTaskFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadContactDataUserTaskFlowElement(UserConnection userConnection, LeadManagementDisqualification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadContactDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("d587fc99-d596-473e-8b4c-47ed99139561");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,85,77,111,219,48,12,253,43,129,207,85,33,219,242,87,110,91,151,13,57,108,45,214,162,151,165,7,90,162,82,97,254,8,100,165,91,22,228,191,143,178,155,44,221,178,46,40,10,172,216,124,48,108,226,145,122,36,31,169,117,32,43,232,186,15,80,99,48,14,94,95,188,191,108,181,59,125,107,42,135,246,157,109,151,139,224,36,232,208,26,168,204,55,84,131,125,162,140,123,3,14,200,97,61,251,225,63,11,198,179,67,17,102,193,201,44,48,14,235,142,16,228,128,74,203,82,196,146,233,80,103,76,104,144,172,148,2,88,158,23,177,138,18,206,85,17,13,200,195,161,207,218,122,1,22,135,19,250,224,186,255,188,90,45,60,48,36,131,236,33,166,107,155,123,99,236,41,116,147,6,202,10,21,253,59,187,68,50,57,107,106,202,4,175,76,141,23,96,233,36,31,167,245,38,2,105,168,58,143,170,80,187,201,215,133,197,174,51,109,243,56,181,106,89,55,251,88,114,199,221,239,61,25,222,51,244,200,11,112,183,125,128,179,182,209,198,214,158,219,166,167,250,106,62,183,56,7,103,238,246,153,124,198,85,15,63,174,132,228,160,168,77,215,80,45,113,91,156,232,151,124,206,96,225,134,180,30,208,32,156,53,243,219,35,19,223,21,239,79,185,251,243,23,91,240,81,17,127,159,199,157,55,108,171,179,217,248,194,165,17,213,34,141,57,75,98,13,76,68,58,102,57,164,5,147,113,38,226,92,67,34,100,249,191,105,107,122,164,168,142,171,221,129,102,240,71,53,53,125,241,98,138,210,61,49,81,140,237,231,44,248,52,237,206,191,52,104,47,229,45,214,48,84,236,230,148,172,63,25,38,21,214,216,184,241,58,145,121,24,33,40,86,32,71,38,176,72,88,17,202,144,149,28,162,34,83,40,194,56,220,144,195,142,16,185,240,36,85,42,33,76,78,126,66,240,136,129,230,156,133,73,90,168,16,68,25,130,244,46,147,198,25,183,26,84,48,94,131,18,5,87,73,206,120,66,115,47,84,78,7,69,34,101,74,229,34,77,177,140,139,60,222,220,12,233,154,110,81,193,234,122,151,213,71,34,56,170,232,69,91,218,118,110,228,119,243,168,213,35,42,238,178,114,166,153,143,72,65,21,74,223,66,146,93,227,64,186,62,146,111,37,249,147,16,226,72,23,17,139,209,159,157,22,36,148,132,43,6,81,169,120,26,131,34,193,144,228,252,227,149,209,206,141,132,234,124,129,150,148,215,119,158,31,158,152,7,163,230,123,98,219,214,13,149,222,117,116,159,206,86,184,101,153,113,149,99,198,84,33,137,79,86,102,172,16,57,176,18,84,148,101,90,134,60,214,196,135,110,50,223,249,203,118,105,229,253,132,119,195,21,246,164,203,233,47,44,134,39,220,36,7,199,238,152,65,122,254,141,251,66,11,54,125,238,74,253,227,235,100,250,130,150,192,38,216,124,7,0,171,88,79,193,10,0,0 })));
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

			#endregion

		}

		#endregion

		#region Class: ReadLeadDataUserTaskFlowElement

		/// <exclude/>
		public class ReadLeadDataUserTaskFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadLeadDataUserTaskFlowElement(UserConnection userConnection, LeadManagementDisqualification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadLeadDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("5c812ead-9e0e-4e95-91c1-b0a297de4131");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,20,252,43,65,135,158,172,96,125,216,150,220,227,178,45,11,37,13,109,90,10,73,8,79,210,211,174,192,31,27,91,166,9,102,255,123,181,235,108,11,57,148,28,122,41,232,32,61,105,230,205,12,79,243,67,24,63,132,38,226,80,123,104,70,204,166,141,171,73,137,44,87,210,10,90,176,210,83,233,176,164,32,11,73,25,87,22,65,9,224,204,144,172,131,22,107,178,160,215,46,68,146,133,136,237,88,223,206,127,72,227,48,97,246,224,79,135,175,118,135,45,124,59,54,144,12,188,210,168,105,85,228,134,74,52,134,42,11,150,122,47,180,41,165,146,12,45,89,180,104,231,21,175,164,163,218,235,164,165,224,140,42,39,10,42,148,205,115,195,75,46,84,78,178,6,125,92,63,237,7,28,199,208,119,245,140,191,247,55,207,251,164,114,233,189,234,155,169,237,72,214,98,132,107,136,187,154,0,230,40,11,11,212,74,93,80,233,177,162,32,180,163,2,76,197,43,133,172,100,21,201,44,236,227,145,150,108,28,201,28,68,248,14,205,132,39,230,57,36,141,92,228,76,21,101,194,50,97,169,20,60,167,170,84,21,245,174,244,26,69,169,181,113,231,188,62,78,33,237,195,120,53,181,56,4,251,18,59,166,252,250,161,158,109,223,197,161,111,142,212,87,167,231,55,248,20,151,112,95,174,126,44,134,98,170,31,65,228,144,77,35,174,154,128,93,92,119,182,119,161,219,46,156,135,67,130,180,123,24,194,120,78,97,253,56,65,67,178,33,108,119,127,77,107,53,141,177,111,255,35,171,89,178,153,56,210,144,157,228,30,103,208,133,113,223,192,243,233,92,147,119,143,83,31,223,127,66,112,23,99,132,45,94,216,29,116,91,116,151,95,208,246,131,187,216,184,229,5,121,197,84,147,59,226,45,48,227,88,69,157,116,105,2,141,224,84,21,34,125,14,80,166,80,218,21,185,42,46,43,163,84,161,5,82,33,56,167,210,114,71,149,44,29,53,202,11,208,192,156,48,252,142,36,11,255,80,216,237,102,252,252,179,59,127,172,37,138,251,203,84,125,85,88,55,216,166,204,234,249,45,78,14,9,112,125,110,85,207,111,241,117,184,63,58,187,63,164,245,11,15,198,51,90,80,4,0,0 })));
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

			#endregion

		}

		#endregion

		public LeadManagementDisqualification(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadManagementDisqualification";
			SchemaUId = new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_qualificationProcessId = () => { return (Guid)(((ReadLeadDataUserTask.ResultEntity.IsColumnValueLoaded(ReadLeadDataUserTask.ResultEntity.Schema.Columns.GetByName("QualificationProcessId").ColumnValueName) ? ReadLeadDataUserTask.ResultEntity.GetTypedColumnValue<Guid>("QualificationProcessId") : Guid.Empty))); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6034bf20-3f99-4e89-95d3-98d9ba74a6f3");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LeadManagementDisqualification, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LeadManagementDisqualification, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		private Func<Guid> _qualificationProcessId;
		public virtual Guid QualificationProcessId {
			get {
				return (_qualificationProcessId ?? (_qualificationProcessId = () => Guid.Empty)).Invoke();
			}
			set {
				_qualificationProcessId = () => { return value; };
			}
		}

		private ProcessMainLane _mainLane;
		public ProcessMainLane MainLane {
			get {
				return _mainLane ?? ((_mainLane) = new ProcessMainLane(UserConnection, this));
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
					SchemaElementUId = new Guid("77567f62-1a7e-4348-bc78-7cc946b0e6ec"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessStartSignalEvent _leadStageChangedStartSignal;
		public ProcessStartSignalEvent LeadStageChangedStartSignal {
			get {
				return _leadStageChangedStartSignal ?? (_leadStageChangedStartSignal = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "LeadStageChangedStartSignal",
					SerializeToDB = false,
					IsLogging = true,
					SchemaElementUId = new Guid("fca1bd17-d4df-4b32-8533-5a8b589d5085"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ReadContactDataUserTaskFlowElement _readContactDataUserTask;
		public ReadContactDataUserTaskFlowElement ReadContactDataUserTask {
			get {
				return _readContactDataUserTask ?? (_readContactDataUserTask = new ReadContactDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadLeadDataUserTaskFlowElement _readLeadDataUserTask;
		public ReadLeadDataUserTaskFlowElement ReadLeadDataUserTask {
			get {
				return _readLeadDataUserTask ?? (_readLeadDataUserTask = new ReadLeadDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _detachLeadScriptTask;
		public ProcessScriptTask DetachLeadScriptTask {
			get {
				return _detachLeadScriptTask ?? (_detachLeadScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DetachLeadScriptTask",
					SchemaElementUId = new Guid("0b58be4a-4d85-426d-a3fe-edaab7536d93"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = DetachLeadScriptTaskExecute,
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
					SchemaElementUId = new Guid("7273fec0-03c3-42e6-a0da-01828c552d9c"),
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

		private ProcessConditionalFlow _conditionalFlow2;
		public ProcessConditionalFlow ConditionalFlow2 {
			get {
				return _conditionalFlow2 ?? (_conditionalFlow2 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow2",
					SchemaElementUId = new Guid("82f6af9e-9756-45d6-ace6-29fda131a0c9"),
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
			FlowElements[LeadStageChangedStartSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { LeadStageChangedStartSignal };
			FlowElements[ReadContactDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadContactDataUserTask };
			FlowElements[ReadLeadDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadLeadDataUserTask };
			FlowElements[DetachLeadScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { DetachLeadScriptTask };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Terminate1":
						CompleteProcess();
						break;
					case "LeadStageChangedStartSignal":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadDataUserTask", e.Context.SenderName));
						break;
					case "ReadContactDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("DetachLeadScriptTask", e.Context.SenderName));
						break;
					case "ReadLeadDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "DetachLeadScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadContactDataUserTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("DetachLeadScriptTask", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadLeadDataUserTask.ResultEntity.IsColumnValueLoaded(ReadLeadDataUserTask.ResultEntity.Schema.Columns.GetByName("QualifiedContact").ColumnValueName) ? ReadLeadDataUserTask.ResultEntity.GetTypedColumnValue<Guid>("QualifiedContactId") : Guid.Empty))  !=  Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalFlow2", "((ReadLeadDataUserTask.ResultEntity.IsColumnValueLoaded(ReadLeadDataUserTask.ResultEntity.Schema.Columns.GetByName(\"QualifiedContact\").ColumnValueName) ? ReadLeadDataUserTask.ResultEntity.GetTypedColumnValue<Guid>(\"QualifiedContactId\") : Guid.Empty))  !=  Guid.Empty", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("QualificationProcessId")) {
				writer.WriteValue("QualificationProcessId", QualificationProcessId, Guid.Empty);
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
			MetaPathParameterValues.Add("dfb6d9c3-dafe-46e1-80ad-be11953cf50a", () => QualificationProcessId);
			MetaPathParameterValues.Add("7b88593e-3322-4c2d-846d-b8f3a9a1d3b2", () => LeadStageChangedStartSignal.RecordId);
			MetaPathParameterValues.Add("c39e1c18-9a60-4c66-9faf-c847b74c2df5", () => LeadStageChangedStartSignal.EntitySchemaUId);
			MetaPathParameterValues.Add("40ec267a-a7cd-4d95-a98c-9a1d12e5cca3", () => ReadContactDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("e79bf73d-74cf-4335-853b-937287105f36", () => ReadContactDataUserTask.ResultType);
			MetaPathParameterValues.Add("7913e1e4-9e87-4692-9069-55b03a1b9232", () => ReadContactDataUserTask.ReadSomeTopRecords);
			MetaPathParameterValues.Add("b9faa3f9-e91c-4350-bcb6-0ee0428ce70c", () => ReadContactDataUserTask.NumberOfRecords);
			MetaPathParameterValues.Add("ee0ce0fc-fd5f-4994-bc91-51aa9c50669a", () => ReadContactDataUserTask.FunctionType);
			MetaPathParameterValues.Add("99edb6c9-e18a-4b79-8ac7-b906d830fb52", () => ReadContactDataUserTask.AggregationColumnName);
			MetaPathParameterValues.Add("ed53142f-e2f8-4b8c-9a9f-c658f11be2ab", () => ReadContactDataUserTask.OrderInfo);
			MetaPathParameterValues.Add("da6b78a7-a73e-4724-8ca9-b95af2c60105", () => ReadContactDataUserTask.ResultEntity);
			MetaPathParameterValues.Add("821d7f8d-8a3f-4770-b9b8-ebd3f9233a98", () => ReadContactDataUserTask.ResultCount);
			MetaPathParameterValues.Add("fa834639-2221-4cd8-8911-dc298bc99e16", () => ReadContactDataUserTask.ResultIntegerFunction);
			MetaPathParameterValues.Add("5297ac4f-fc6d-4cb0-9678-95f6c5108b5c", () => ReadContactDataUserTask.ResultFloatFunction);
			MetaPathParameterValues.Add("e545c311-11e1-46d0-9aaa-4e1f54abda07", () => ReadContactDataUserTask.ResultDateTimeFunction);
			MetaPathParameterValues.Add("963f06c1-e4a8-4bf8-b945-29f477df51b9", () => ReadContactDataUserTask.ResultRowsCount);
			MetaPathParameterValues.Add("ac4dc6fe-5e17-4ca5-8ff9-902d0bb960fd", () => ReadContactDataUserTask.CanReadUncommitedData);
			MetaPathParameterValues.Add("422d4901-ab76-4ef0-8ab8-1554f56cea82", () => ReadContactDataUserTask.ResultEntityCollection);
			MetaPathParameterValues.Add("e4e55b30-0ac9-4bc7-a39e-3a01d5ad7018", () => ReadContactDataUserTask.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("8c65435c-2c20-453a-8a46-cca74d849630", () => ReadContactDataUserTask.IgnoreDisplayValues);
			MetaPathParameterValues.Add("db32d26f-c21d-4e9b-b60c-f99dc7f50800", () => ReadContactDataUserTask.ResultCompositeObjectList);
			MetaPathParameterValues.Add("66a9112b-0a3e-4891-9211-47e448897fa1", () => ReadContactDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("c5f5b5ca-c522-4aad-a8d8-999393894c04", () => ReadLeadDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("959030b1-25af-4cd9-b5e7-5a744bdaedf0", () => ReadLeadDataUserTask.ResultType);
			MetaPathParameterValues.Add("093e10f8-8eef-4d51-9167-1a7a01cd507f", () => ReadLeadDataUserTask.ReadSomeTopRecords);
			MetaPathParameterValues.Add("6d51a122-e70a-433e-9818-82f47a7aeafb", () => ReadLeadDataUserTask.NumberOfRecords);
			MetaPathParameterValues.Add("c5d5908e-a924-4a0c-87fe-396c1eed83f1", () => ReadLeadDataUserTask.FunctionType);
			MetaPathParameterValues.Add("0bde32d3-80c0-4cb2-85a9-e9d0248e1cfe", () => ReadLeadDataUserTask.AggregationColumnName);
			MetaPathParameterValues.Add("7ef1809d-3038-4732-a5e8-f856ec73ed85", () => ReadLeadDataUserTask.OrderInfo);
			MetaPathParameterValues.Add("5056dd51-b8ad-4402-af00-1569d1a4b1ac", () => ReadLeadDataUserTask.ResultEntity);
			MetaPathParameterValues.Add("8399996e-d16e-4a0d-8a6c-d6f8f3077d8c", () => ReadLeadDataUserTask.ResultCount);
			MetaPathParameterValues.Add("18028651-6139-43f8-afd6-2480c010cb30", () => ReadLeadDataUserTask.ResultIntegerFunction);
			MetaPathParameterValues.Add("a0d37cec-a28e-4776-8424-b9fb9052daa3", () => ReadLeadDataUserTask.ResultFloatFunction);
			MetaPathParameterValues.Add("5cd05c9b-4654-4a13-9dab-234f585de3b2", () => ReadLeadDataUserTask.ResultDateTimeFunction);
			MetaPathParameterValues.Add("e3077e0b-4a11-42b8-80c8-e2a3808dae05", () => ReadLeadDataUserTask.ResultRowsCount);
			MetaPathParameterValues.Add("0ffd69eb-68b9-4b76-99c8-e81148f86182", () => ReadLeadDataUserTask.CanReadUncommitedData);
			MetaPathParameterValues.Add("4467b208-843d-4f64-afe0-7a290b704b5c", () => ReadLeadDataUserTask.ResultEntityCollection);
			MetaPathParameterValues.Add("76541bf9-a56b-425f-8612-0c857be8f9b6", () => ReadLeadDataUserTask.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("9424fa47-cc52-45e9-b48d-98a75c45d72d", () => ReadLeadDataUserTask.IgnoreDisplayValues);
			MetaPathParameterValues.Add("f13d2218-157b-46dd-a0d9-3bfb12f95274", () => ReadLeadDataUserTask.ResultCompositeObjectList);
			MetaPathParameterValues.Add("4f3391d4-629c-4271-9d8e-ec411a1710f7", () => ReadLeadDataUserTask.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "QualificationProcessId":
					if (!hasValueToRead) break;
					QualificationProcessId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool DetachLeadScriptTaskExecute(ProcessExecutingContext context) {
			if (QualificationProcessId.IsEmpty()) {
				return true;
			}
			Process process = UserConnection.ProcessEngine.FindProcessByUId(QualificationProcessId.ToString(), true);
			if (process == null) {
				return true;
			}
			if (process.Status == ProcessStatus.Running) {
				process.CancelExecution();
				var lead = new BPMSoft.Configuration.Lead(UserConnection);
				Guid leadId = LeadStageChangedStartSignal.RecordId;
				if (lead.FetchFromDB(leadId)) {
					lead.SetColumnValue("QualificationProcessId", null);
					lead.Save();
				}
			}
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
			var cloneItem = (LeadManagementDisqualification)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

