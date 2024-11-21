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

	#region Class: LeadAutoToEndStateSchema

	/// <exclude/>
	public class LeadAutoToEndStateSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LeadAutoToEndStateSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LeadAutoToEndStateSchema(LeadAutoToEndStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LeadAutoToEndState";
			UId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386");
			CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.8.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"LeadManagement";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386");
			Version = 0;
			PackageUId = new Guid("72dfd004-1fad-41fa-ad05-3cbc97f2958e");
			UseSystemSecurityContext = false;
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
		}

		protected virtual void InitializeStartSignal1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2555d5e5-9d69-46c1-901f-ed528bffbcdc"),
				ContainerUId = new Guid("0633146f-9541-4c90-8494-6facae83a817"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0633146f-9541-4c90-8494-6facae83a817"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
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
				UId = new Guid("fb76d37f-4030-42f0-b828-cbb1a4b381aa"),
				ContainerUId = new Guid("0633146f-9541-4c90-8494-6facae83a817"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0633146f-9541-4c90-8494-6facae83a817"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"ae46fb87-c02c-4ae8-ad31-a923cdd994cf",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c674161d-9746-4a42-af2f-efe9123f908d"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,19,49,20,253,21,52,235,186,154,25,207,51,59,40,1,117,1,137,72,213,13,233,194,177,175,83,139,121,201,227,20,66,20,9,248,130,134,239,96,193,2,241,148,88,52,234,143,244,75,184,158,73,67,138,34,8,108,16,18,35,121,102,124,116,238,245,185,47,207,28,158,177,186,126,200,114,112,58,206,157,254,131,65,41,205,254,61,149,25,208,247,117,57,169,156,61,167,6,173,88,166,158,131,104,241,174,80,230,46,51,12,13,102,195,239,246,67,167,51,220,230,97,232,236,13,29,101,32,175,145,129,6,82,8,47,74,147,148,4,177,116,73,0,220,35,44,241,67,66,169,164,130,114,63,73,168,219,50,183,187,62,40,243,138,105,104,79,104,156,203,230,247,104,90,89,162,135,0,111,40,170,46,139,21,72,173,132,186,91,176,81,6,2,247,70,79,0,33,163,85,142,145,192,145,202,161,207,52,158,100,253,148,22,66,146,100,89,109,89,25,72,211,125,86,105,168,107,85,22,63,151,150,77,242,98,147,139,230,176,222,174,196,184,141,66,203,236,51,115,218,56,56,68,81,243,70,227,237,241,88,195,152,25,117,182,41,225,9,76,27,222,110,185,67,3,129,245,57,102,217,4,54,206,188,25,199,1,171,76,27,78,123,60,18,180,26,159,238,24,233,58,91,191,10,214,71,176,186,38,239,228,113,171,126,63,66,240,204,2,173,143,235,223,161,243,248,176,238,61,45,64,15,248,41,228,172,205,216,201,62,162,63,0,221,12,114,40,76,103,230,70,148,122,65,36,73,26,6,30,9,120,234,146,36,72,3,18,73,198,25,36,148,37,94,60,71,131,181,160,206,204,15,195,80,132,16,146,84,68,152,251,8,211,158,186,158,36,32,66,63,25,73,57,226,130,207,79,90,225,170,174,50,54,61,94,235,91,158,95,126,92,46,174,94,189,89,158,95,124,197,245,14,215,91,92,239,237,247,22,190,62,172,128,207,45,107,113,245,226,19,238,190,52,232,226,226,229,114,113,249,122,255,17,240,82,139,85,153,236,7,29,135,113,76,131,144,166,132,69,177,36,129,228,54,142,24,8,75,99,238,71,169,27,8,230,99,87,217,199,22,191,28,43,206,178,94,5,26,155,171,41,174,187,125,40,110,76,147,77,187,46,75,211,38,115,93,180,94,85,149,218,76,10,101,176,47,55,250,51,137,56,132,35,17,144,48,74,40,230,54,0,50,18,46,54,169,39,168,43,61,223,141,37,67,77,120,169,216,2,15,202,137,230,171,65,174,219,219,228,143,238,137,191,48,255,191,51,212,91,199,106,151,65,249,63,4,203,127,102,8,230,206,252,27,58,192,189,235,76,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8e022789-4e9c-4ca9-a63a-bafe8b45d27a"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("891c2114-c8fc-465d-b1f5-f5278d3afcf2"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b8c3887c-acc7-4db4-a068-a6c9b5095c6f"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0d2e4df5-ebbe-4435-8f78-c990952374df"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d5c75813-9a69-4394-aa21-757ee0a79c85"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4a96c175-f201-4971-a84c-667bf1d98abb"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("d3d56bf1-777a-4bc7-aa00-24988a0b714f"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0e30322a-5528-4686-8289-0dd270a0747e"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0515d8e0-89b7-4b5f-86f2-57c17fa5c211"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a43a1cf1-ff6b-4013-8469-b230f95aeed3"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("15f88c4d-b432-4552-a155-90b07e7d0e80"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7acadd53-ed9a-430e-92da-737ed1810ea7"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6f8ca22a-b3a4-47eb-9ec6-08f559063864"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c9b43dca-27ca-4615-a3d9-6b0896d38d91"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a6b199bd-b0af-4235-9fd8-d432bef1342d"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,183,52,79,76,54,54,53,210,53,177,52,183,212,53,73,49,178,208,181,52,48,75,211,181,48,74,75,77,50,75,73,74,182,76,73,6,0,174,79,115,201,36,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0c0fb151-9665-481d-a943-69460316e837"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f6be456e-854b-4527-b219-91f89da82e8a"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d66e8488-0ca3-4d87-9c75-aa6fb8035f8a"),
				ContainerUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeUserQuestionUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var branchingDecisionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("23470eda-fd4a-4dcb-a26f-6eb160c6b305"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"BranchingDecisions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableParameterValuesListDataValueType")
			};
			branchingDecisionsParameter.SourceValue = new ProcessSchemaParameterValue(branchingDecisionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,193,74,195,64,16,134,95,69,150,30,51,101,211,204,102,119,123,180,69,40,84,41,136,94,196,195,236,102,22,131,169,41,73,42,216,146,139,207,224,213,119,240,226,123,212,55,50,201,65,42,136,122,27,248,231,251,249,191,189,24,53,79,27,22,83,113,186,58,191,44,67,51,158,149,21,143,87,85,233,185,174,199,203,210,83,145,239,200,21,188,162,138,214,220,112,117,77,197,150,235,101,94,55,209,201,49,36,34,49,122,28,50,49,189,217,139,69,195,235,171,69,214,53,75,99,109,144,214,129,215,104,0,3,77,192,177,183,160,77,70,146,8,3,154,184,131,251,223,189,24,26,58,136,52,98,166,16,129,149,204,0,149,246,64,210,16,120,35,101,154,33,234,56,33,209,70,226,162,27,117,204,205,217,231,117,94,62,200,62,156,209,166,233,238,62,207,235,165,223,13,211,197,180,169,182,28,125,17,135,151,195,91,255,60,231,48,187,99,127,207,223,118,156,81,81,179,104,219,232,216,40,56,45,93,162,28,196,82,50,160,97,13,134,179,4,148,159,160,119,137,78,82,245,131,81,130,62,77,39,25,72,76,45,32,90,5,46,181,1,18,201,65,106,101,141,194,248,55,163,33,252,159,209,235,225,253,227,249,111,167,219,246,19,204,53,185,69,255,1,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(branchingDecisionsParameter);
			var resultDecisionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("17cd0f5c-25fe-42a4-99da-d593c8a0a37f"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ResultDecisions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			resultDecisionsParameter.SourceValue = new ProcessSchemaParameterValue(resultDecisionsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultDecisionsParameter);
			var decisionModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fb9218e3-edba-4d6d-9f82-2f0ad13153dd"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"DecisionMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			decisionModeParameter.SourceValue = new ProcessSchemaParameterValue(decisionModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(decisionModeParameter);
			var isDecisionRequiredParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("711528bb-6676-488b-8c54-79154028c8f1"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"IsDecisionRequired",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isDecisionRequiredParameter.SourceValue = new ProcessSchemaParameterValue(isDecisionRequiredParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(isDecisionRequiredParameter);
			var questionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e4ef48da-4ee6-4ee6-ba67-0f5dd93a47cd"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Question",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			questionParameter.SourceValue = new ProcessSchemaParameterValue(questionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Удовлетворена ли потребность/потребности лидов?",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(questionParameter);
			var windowCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0849dedf-33cf-448d-87ad-a9ba022daa4a"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"WindowCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			windowCaptionParameter.SourceValue = new ProcessSchemaParameterValue(windowCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Answer selection page for item &quot;Is lead need fulfilled?&quot;",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(windowCaptionParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3db58c3f-22ba-40b8-b71d-4b8bcd16a115"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Удовлетворена ли потребность/потребности лидов?",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("fad75be7-0f8a-4872-967c-7d2c62690303"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("22a1d630-b988-4a27-b8ff-6fd69dca7b08"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"OwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			ownerIdParameter.SourceValue = new ProcessSchemaParameterValue(ownerIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"[#SysVariable.CurrentUserContact#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("11afda49-35e6-4c12-9ea2-96db901da46b"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9c63a071-4375-4cdc-9829-9904f26e6585"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("588fd741-5860-4c73-8326-9fff706860b8"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("29355950-5494-47a3-b730-2dca6b41b7d3"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b0c7abe8-1b56-4322-a1af-34567e8ee6c0"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("10e64984-20e7-4e23-b0a7-b1d11798514c"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a6270bb2-5dac-4ad4-b8bc-207c2b3dce6b"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5d251a59-539c-46e1-8fbc-7d54869ffe8f"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("1e3036be-34b9-4a4a-85ec-999e85694aba"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("693953dc-26bc-4cc8-893c-50df8cbfa540"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("2edcfe17-f472-4a05-911e-ff5f6158c136"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("6560a60a-c2f8-4a12-8405-2ed91eed8bf0"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("d553a0ac-618b-4bef-bfee-e24778fcd6ad"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("65175ba0-3b99-41ba-8e49-8f54e6f87036"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("7b349c4c-8ceb-41b3-9e56-cbee348bc604"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("98189f43-a322-4b76-a3a9-14c369544dee"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("bc28920d-a411-4c17-85ca-e6461f60c921"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("7b906324-fffe-4806-a5bc-9c1e52e06325"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("a929915e-60ad-42c2-9a7c-93301d1da38a"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ad6124ce-5389-44e0-a050-e08ee0924021"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ExecutionContext",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			executionContextParameter.SourceValue = new ProcessSchemaParameterValue(executionContextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executionContextParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bc996c5b-31fa-4a91-aeb2-7031c3994ca5"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("2f0d536d-6d1d-4845-9703-1adeb8576fd9"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("59fbf60e-8f41-448a-8616-849f39991f00"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("56c34026-9ed0-4dcb-b716-886b7c4b2b09"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("e04571cf-6c74-4140-b50b-a9ea256bd366"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("27c89055-6026-4244-8ff4-093dfc05c28c"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("f9d05259-826b-43fc-bddb-d0915320cac5"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
			var problemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				UId = new Guid("670d3618-61ea-44bb-bdc7-c282f5c9882a"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("7140ffaf-6034-4859-adb2-33eb5086764b"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("07899f83-a011-4912-99f0-cf24347c6ba4"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b33f2c42-2933-4c92-aedb-1b9556f6b169"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("5e0dd5b5-b354-49a4-ad86-ca7413b530b7"),
				ContainerUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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

		protected virtual void InitializeChangeDataUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("a904d73f-a09c-44a8-878a-a19fc5c41658"),
				ContainerUId = new Guid("f9de1386-6917-4d63-9831-56fcec025df4"),
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0c2bfccf-ed5e-4d79-9cc8-06c7445de2ab"),
				ContainerUId = new Guid("f9de1386-6917-4d63-9831-56fcec025df4"),
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("adbba650-d377-41d5-a69f-514e3c05c2a6"),
				ContainerUId = new Guid("f9de1386-6917-4d63-9831-56fcec025df4"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,73,110,212,64,20,189,10,242,154,138,108,151,203,67,239,32,52,40,18,144,136,68,108,226,44,190,203,191,58,22,158,84,174,14,52,45,75,192,9,210,156,131,5,11,196,40,177,72,43,23,201,73,168,178,59,77,18,58,131,178,65,72,44,202,195,211,251,175,254,60,181,120,14,77,243,20,10,180,6,214,253,173,39,219,149,80,107,15,179,92,161,124,36,171,113,109,221,181,26,148,25,228,217,107,76,123,124,152,102,234,1,40,208,6,211,248,183,125,108,13,226,85,10,177,117,55,182,50,133,69,163,25,218,128,82,230,131,96,33,73,221,128,17,47,164,9,137,4,5,226,51,59,113,32,116,68,20,166,61,115,181,244,70,217,139,119,186,162,251,220,153,212,134,227,105,128,87,69,13,50,107,170,114,1,82,115,123,51,44,33,201,209,232,42,57,70,13,41,153,21,58,8,220,201,10,220,2,169,47,49,58,149,129,52,73,64,222,24,86,142,66,13,95,213,18,155,38,171,202,171,188,90,175,242,113,81,158,229,106,115,92,254,46,156,177,59,15,13,115,11,212,126,39,176,89,215,149,84,227,50,83,147,216,106,59,103,239,141,70,18,71,160,178,131,179,190,188,192,73,103,112,179,252,105,131,84,215,232,57,228,99,92,92,238,216,127,68,180,14,181,234,3,139,173,249,225,241,215,249,236,228,221,135,249,225,209,79,125,62,233,243,81,159,207,230,221,9,74,20,40,177,228,184,205,247,177,128,101,14,206,133,96,120,217,104,255,204,37,166,238,187,151,38,110,153,252,235,114,231,106,176,62,37,95,85,138,165,226,202,44,184,190,6,15,12,208,107,156,126,198,214,238,70,179,249,178,68,217,71,215,231,125,111,77,163,23,128,97,142,5,150,106,48,181,125,74,29,207,23,36,98,158,67,60,30,217,36,244,34,143,248,2,56,96,72,117,49,130,86,27,44,29,26,76,93,198,88,202,144,145,40,245,35,226,249,220,33,145,237,8,130,41,115,195,68,136,132,167,188,221,235,29,207,154,58,135,73,231,251,245,5,186,163,31,95,22,192,247,158,53,59,121,243,77,255,253,232,208,217,209,219,249,236,248,253,218,51,228,149,76,55,250,14,49,47,45,236,251,212,19,65,18,18,39,100,41,241,34,219,39,64,209,37,73,16,37,182,23,137,128,5,145,238,205,182,221,107,77,131,230,213,40,227,144,111,214,40,97,209,61,246,234,33,59,55,157,38,239,178,170,212,133,230,121,140,208,59,115,218,223,41,117,145,7,186,181,25,48,161,179,26,4,36,228,220,37,16,122,182,112,128,82,10,198,27,189,152,76,105,183,171,177,228,216,111,132,166,223,72,183,218,53,127,97,145,220,106,59,92,50,91,55,153,150,255,147,48,255,7,38,161,181,218,95,220,161,200,240,149,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bec87d14-9ecd-40b3-a7ce-6925d9200e60"),
				ContainerUId = new Guid("f9de1386-6917-4d63-9831-56fcec025df4"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,143,218,48,16,253,43,43,239,30,153,200,142,63,18,115,108,247,130,4,21,42,237,94,150,61,140,237,113,55,106,32,40,9,149,182,136,255,222,36,132,2,213,86,170,84,31,98,121,60,239,205,243,188,201,129,61,180,111,59,98,83,246,97,185,88,85,177,77,62,86,53,37,203,186,242,212,52,201,188,242,88,22,63,209,149,180,196,26,55,212,82,253,132,229,158,154,121,209,180,147,187,107,16,155,176,135,31,195,29,155,62,31,216,172,165,205,215,89,232,152,51,153,106,147,25,4,201,93,4,165,77,4,231,136,131,13,65,235,44,164,14,125,15,246,85,185,223,108,23,212,226,18,219,87,54,61,176,129,173,35,112,158,251,52,24,14,26,101,0,149,43,14,136,138,192,27,78,152,101,134,82,110,216,113,194,26,255,74,27,28,138,94,192,74,96,204,45,89,200,52,119,160,200,57,200,61,122,136,81,90,103,58,50,65,190,7,143,249,23,224,243,253,188,170,190,239,119,73,154,74,37,124,16,160,157,148,160,124,87,222,114,33,192,196,204,88,73,209,144,82,9,71,158,243,220,107,208,74,104,80,34,114,112,132,18,132,200,189,151,60,183,86,219,251,151,190,80,40,154,93,137,111,79,127,173,55,39,12,119,77,139,223,40,89,97,91,52,177,160,112,130,238,110,60,184,6,31,214,39,35,215,108,186,126,223,202,113,95,13,61,186,53,243,214,199,53,155,172,217,170,218,215,190,103,147,221,225,241,74,241,80,96,72,249,227,120,54,174,139,108,247,101,57,70,30,177,197,115,226,57,92,133,162,127,210,108,187,58,251,53,176,240,113,193,59,159,243,58,105,251,31,216,2,183,93,99,235,79,221,243,47,218,127,171,252,210,181,240,76,236,82,171,121,38,34,100,132,182,27,28,147,66,30,4,130,21,214,69,217,13,117,140,233,128,254,76,145,106,218,122,186,21,246,47,99,51,226,155,161,219,253,31,51,234,234,91,117,100,199,227,203,241,23,238,67,139,104,161,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a7558cf4-1e39-4ddd-a54e-51a0a4b48fc9"),
				ContainerUId = new Guid("f9de1386-6917-4d63-9831-56fcec025df4"),
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

		protected virtual void InitializeChangeDataUserTask3Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("fa05a2c7-0e11-4e5f-a19b-16fb050762c1"),
				ContainerUId = new Guid("88714082-9190-4092-9c5b-580b606c294f"),
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fc0b26dd-f352-4bdc-85e2-8c07f97c3355"),
				ContainerUId = new Guid("88714082-9190-4092-9c5b-580b606c294f"),
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ae8ff592-352a-4e64-b2ff-890082dfab9d"),
				ContainerUId = new Guid("88714082-9190-4092-9c5b-580b606c294f"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,205,110,212,48,16,126,21,148,115,93,57,255,201,222,160,44,168,18,208,138,86,92,154,30,28,103,188,181,200,159,28,111,97,89,69,162,60,65,151,231,224,192,1,241,43,113,232,170,47,210,39,97,156,108,151,182,244,79,189,32,36,14,78,236,79,51,159,103,62,207,204,212,226,57,107,154,103,172,0,107,96,61,216,124,186,85,9,189,250,72,230,26,212,99,85,141,107,107,197,106,64,73,150,203,55,144,245,248,48,147,250,33,211,12,29,166,201,111,255,196,26,36,151,49,36,214,74,98,73,13,69,131,22,232,96,3,8,26,68,64,210,212,13,137,151,218,46,137,25,77,73,72,69,38,28,10,94,202,12,215,149,212,235,101,79,222,241,138,110,187,61,169,141,141,135,0,175,138,154,41,217,84,229,2,116,205,237,205,176,100,105,14,25,158,181,26,3,66,90,201,2,147,128,109,89,192,38,83,120,137,225,169,12,132,70,130,229,141,177,202,65,232,225,235,90,65,211,200,170,188,46,170,181,42,31,23,229,89,91,116,135,229,113,17,12,237,34,52,150,155,76,239,117,4,27,117,93,41,61,46,165,158,36,86,219,5,123,127,52,82,48,98,90,238,159,141,229,37,76,58,135,219,233,135,14,25,190,209,11,150,143,97,113,185,77,255,200,104,141,213,186,79,44,177,230,135,199,95,231,179,147,119,31,230,135,71,63,113,125,194,245,17,215,103,243,239,8,21,8,80,80,114,216,226,123,80,176,165,6,231,82,48,118,114,180,119,230,18,243,238,59,87,10,183,20,255,38,237,28,4,235,83,227,235,158,98,201,120,169,10,78,128,224,190,1,122,142,211,109,98,237,172,55,27,175,74,80,125,118,189,238,187,171,136,94,0,134,57,20,80,234,193,148,6,174,107,123,129,32,177,239,217,196,227,49,37,145,23,123,36,16,140,51,136,92,22,217,97,139,14,203,128,6,83,199,247,253,204,7,159,196,89,16,19,47,224,54,137,169,45,8,100,190,19,165,66,164,60,227,237,110,31,184,108,234,156,77,186,216,111,126,160,123,248,249,178,0,190,247,86,179,147,183,223,240,244,163,67,103,71,7,243,217,241,251,213,231,192,43,149,173,103,221,21,230,135,196,145,157,186,17,245,92,18,100,30,86,148,151,166,132,197,62,166,21,133,16,49,26,97,138,33,214,102,219,238,182,166,64,243,106,36,57,203,55,106,80,108,81,61,244,242,38,59,215,157,70,119,85,85,250,66,241,60,1,214,7,115,90,223,49,99,94,200,185,67,40,117,80,85,223,232,27,154,74,23,148,243,192,177,81,108,244,108,113,48,153,167,221,170,198,138,67,63,17,154,126,34,221,105,214,252,133,65,114,167,233,112,69,111,221,166,91,254,119,194,252,31,232,132,214,106,127,1,185,235,248,168,149,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a93327ad-0eff-457f-ac57-26fbc93ce95a"),
				ContainerUId = new Guid("88714082-9190-4092-9c5b-580b606c294f"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,75,143,155,48,16,254,43,43,239,30,99,132,177,177,113,142,219,92,34,37,85,212,180,123,217,236,97,108,143,187,168,4,34,30,149,182,81,254,123,13,129,38,169,182,82,165,245,1,228,97,190,7,243,217,71,242,208,190,29,144,204,201,227,102,189,173,124,27,125,170,106,140,54,117,101,177,105,162,85,101,161,200,127,129,41,112,3,53,236,177,197,250,9,138,14,155,85,222,180,179,187,107,16,153,145,135,159,195,55,50,127,62,146,101,139,251,111,75,23,152,149,64,239,82,110,169,195,20,168,64,195,104,166,93,70,149,180,25,23,58,5,149,232,0,182,85,209,237,203,53,182,176,129,246,149,204,143,100,96,11,4,198,198,54,113,50,166,41,112,71,69,38,98,10,32,144,90,25,35,40,37,49,137,37,57,205,72,99,95,113,15,131,232,5,44,24,248,76,163,166,42,141,77,175,110,104,102,193,82,239,185,54,50,144,49,180,61,120,236,191,0,159,239,87,85,245,163,59,68,73,194,5,179,142,209,212,112,78,133,13,242,58,102,140,74,175,164,230,232,37,10,17,49,97,189,149,66,80,228,24,60,106,133,52,75,148,166,232,4,103,218,152,44,214,252,254,165,23,114,121,115,40,224,237,233,159,122,43,4,119,215,180,240,29,163,69,152,114,157,155,174,205,171,242,140,62,220,196,112,141,63,238,206,89,238,200,124,247,126,154,227,123,59,140,233,54,207,219,40,119,100,182,35,219,170,171,109,207,198,195,102,113,101,122,16,24,90,254,218,78,217,133,74,217,21,197,88,89,64,11,83,227,84,174,92,238,115,116,203,114,59,69,54,176,196,227,162,239,60,166,117,246,246,17,216,26,202,48,219,250,115,248,253,139,247,63,46,191,134,17,78,196,38,209,105,172,152,167,10,65,135,179,35,19,154,57,6,84,135,68,61,87,60,241,62,25,208,95,208,99,141,165,197,91,99,255,115,114,70,124,51,76,187,191,52,163,175,126,84,39,114,58,189,156,126,3,26,96,209,139,164,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("931ee3e8-56d8-4076-840e-2d8e9b79977c"),
				ContainerUId = new Guid("88714082-9190-4092-9c5b-580b606c294f"),
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

		protected virtual void InitializeReadDataUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fdead1a0-736b-4043-8b38-7b10af3b41ac"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,59,111,19,65,16,254,43,209,213,217,232,94,190,135,59,8,6,165,128,68,114,68,131,83,236,237,237,57,43,238,165,189,117,192,88,150,16,61,194,78,153,10,42,26,138,8,241,200,131,135,116,86,248,33,252,18,102,119,109,199,65,22,24,10,104,98,233,228,217,111,191,153,249,230,110,102,6,6,73,113,85,221,195,25,53,154,198,205,157,187,237,34,17,27,183,89,42,40,191,195,139,94,105,172,27,21,229,12,167,236,9,141,53,222,138,153,184,133,5,6,135,65,231,210,191,99,52,59,203,34,116,140,245,142,193,4,205,42,96,128,3,165,73,35,113,130,4,57,113,210,64,46,241,34,20,82,43,64,52,178,72,224,89,196,115,3,172,153,203,67,111,22,89,137,57,213,25,84,240,68,153,187,253,82,18,45,0,136,162,176,170,200,167,160,35,37,84,173,28,71,41,141,225,44,120,143,2,36,56,203,160,18,186,203,50,186,131,57,100,146,113,10,9,1,41,193,105,37,89,41,77,68,235,113,201,105,85,177,34,255,181,180,180,151,229,139,92,112,167,243,227,84,140,169,20,74,230,14,22,251,42,192,22,136,26,42,141,55,186,93,78,187,88,176,131,69,9,15,105,95,241,86,123,119,224,16,195,247,185,143,211,30,93,200,121,181,142,77,92,10,93,142,78,15,4,206,186,251,43,86,58,127,91,191,43,214,6,176,156,145,87,138,184,84,191,237,1,120,32,1,29,99,102,118,140,7,91,213,246,163,156,242,54,217,167,25,214,111,108,111,3,208,159,128,86,74,51,154,139,230,32,10,28,226,217,113,128,60,18,56,200,245,156,0,5,182,111,34,27,99,199,244,173,6,142,137,51,4,135,185,160,230,32,118,226,134,23,37,22,242,125,31,35,55,34,62,194,216,4,23,55,12,2,108,70,190,229,38,210,165,149,11,38,250,186,11,154,3,63,244,49,113,26,54,114,67,63,68,110,108,7,40,52,189,4,178,37,52,242,226,136,132,49,25,238,233,114,89,85,166,184,127,127,94,213,100,84,191,134,231,100,50,254,254,244,8,140,99,109,140,47,14,215,224,244,78,33,163,250,179,122,224,230,20,140,247,242,230,43,156,158,189,1,227,203,2,237,131,140,180,49,25,93,156,72,218,140,241,118,230,120,186,54,25,215,207,193,56,87,215,163,250,211,244,95,133,62,90,155,57,72,232,227,100,252,237,80,81,65,202,76,220,137,102,200,155,241,133,114,58,158,210,33,244,168,62,155,202,57,95,72,113,38,89,47,149,175,214,86,191,186,44,85,43,135,168,245,11,24,11,249,147,221,91,116,25,193,233,118,73,57,76,135,234,78,115,249,84,95,89,7,178,111,120,81,8,221,13,243,174,219,46,203,130,139,94,14,159,171,45,112,23,192,133,41,131,164,176,246,100,11,182,139,30,39,211,85,83,233,125,247,87,155,236,63,108,168,63,89,59,75,7,127,149,81,190,30,211,235,49,157,252,211,49,29,26,195,31,187,44,57,213,180,8,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9af14c8d-5edd-4be4-82c3-646e2adff0bc"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7f6dda89-a2ac-45ad-b8c0-966007f49fd0"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e5ecd48e-a7a6-47ec-82df-5380d83aa6de"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7f02d3d0-3614-4905-abe0-9735007319da"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("59927067-c313-487e-a77d-d761614e8ff2"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ef491bee-22fc-489d-b39e-7ddd0b703901"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				UId = new Guid("89a40511-3074-42c8-86d3-3a3435c824cf"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
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
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8d6e0dc8-5703-47d6-a9fb-bd2247ac15b2"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("37274c45-33e6-4771-b984-e64a60ac3c9e"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2da695c0-6a45-4669-bb65-ac00a4c44e4b"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("b5a2e001-fa12-4f66-aee8-dedbda666123"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("520dc2ae-127d-4a19-a262-4cb393dd7059"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("80b7ce3d-4682-44d1-9eed-989e91e8cd2a"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("31093895-ecdd-44eb-8dcb-68e59c009683"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7b2e740a-bafe-4153-b031-137e02d7f695"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,179,76,49,54,75,51,179,52,215,53,53,75,73,210,53,49,53,182,212,181,180,48,176,212,77,50,48,79,51,48,76,73,75,181,76,52,0,0,122,108,77,60,36,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fefe044c-19ec-45d1-b204-216cac3e8aec"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fe71eb97-16f3-42db-9478-dca5f20acd34"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d1dec698-059d-4e1f-9c6c-bd4b692f4e01"),
				ContainerUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaStartSignalEvent startsignal1 = CreateStartSignal1StartSignalEvent();
			FlowElements.Add(startsignal1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaUserTask userquestionusertask1 = CreateUserQuestionUserTask1UserTask();
			FlowElements.Add(userquestionusertask1);
			ProcessSchemaUserTask changedatausertask2 = CreateChangeDataUserTask2UserTask();
			FlowElements.Add(changedatausertask2);
			ProcessSchemaUserTask changedatausertask3 = CreateChangeDataUserTask3UserTask();
			FlowElements.Add(changedatausertask3);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow4ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("5f32329f-b1e7-4999-96ba-8ca0f115bc9c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0633146f-9541-4c90-8494-6facae83a817"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("424a9228-4ce5-4385-b3ca-3e1dafa48978"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("f0787462-3d38-48ab-97ca-b6cff17f42ff"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{67cfff35-621a-4e09-916b-349b66e15f44}].[Parameter:{89a40511-3074-42c8-86d3-3a3435c824cf}].[EntityColumn:{9d36f697-56db-4539-9809-b07f01dfe9a0}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				CurveCenterPosition = new Point(371, 134),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f3d8feeb-df0e-417b-aaee-25280baf9119"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f9de1386-6917-4d63-9831-56fcec025df4"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(505, 198));
			schemaFlow.PolylinePointPositions.Add(new Point(505, 197));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("562067d2-5de3-4e83-9d05-3d9b10938727"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				CurveCenterPosition = new Point(488, 332),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("88714082-9190-4092-9c5b-580b606c294f"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"), new Collection<Guid>() {
						new Guid("a34c662d-0469-4495-b69f-30ef07598541"),
					}},
				}
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow4ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow4",
				UId = new Guid("4c59f6a2-cc7e-42c1-b95d-e084dc60daf6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				CurveCenterPosition = new Point(486, 279),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f9de1386-6917-4d63-9831-56fcec025df4"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"), new Collection<Guid>() {
						new Guid("a744d544-e50d-457c-a08a-c8006d44713a"),
					}},
				}
			};
			schemaFlow.PolylinePointPositions.Add(new Point(508, 351));
			schemaFlow.PolylinePointPositions.Add(new Point(508, 197));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("a6aeda21-aa55-407e-a759-b9c780e3273f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				CurveCenterPosition = new Point(606, 233),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f9de1386-6917-4d63-9831-56fcec025df4"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b4e8b447-2802-40bb-989f-573cc8842404"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("4c05c146-e826-447f-9102-5c5bef796db0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				CurveCenterPosition = new Point(598, 269),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("88714082-9190-4092-9c5b-580b606c294f"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b4e8b447-2802-40bb-989f-573cc8842404"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(736, 351));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("aa9be9f1-0de3-487e-a9c6-4fae18f3f45f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("72dfd004-1fad-41fa-ad05-3cbc97f2958e"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f3d8feeb-df0e-417b-aaee-25280baf9119"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("f235cee2-4622-4f1f-9e61-5ce539fae4a6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("72dfd004-1fad-41fa-ad05-3cbc97f2958e"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f3d8feeb-df0e-417b-aaee-25280baf9119"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("a9a1c213-ba59-43f2-9719-43d1cc48485b"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("39173b28-7cb6-47ae-a429-5024c44d51a9"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("a9a1c213-ba59-43f2-9719-43d1cc48485b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("b4e8b447-2802-40bb-989f-573cc8842404"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("39173b28-7cb6-47ae-a429-5024c44d51a9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"Terminate1",
				Position = new Point(723, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal1StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("0633146f-9541-4c90-8494-6facae83a817"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("39173b28-7cb6-47ae-a429-5024c44d51a9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"StartSignal1",
				NewEntityChangedColumns = false,
				Position = new Point(57, 185),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaStartSignalEvent.EntityChangedColumns.Add("797ac352-4979-4d28-906f-82feb6dbc9dc");
			InitializeStartSignal1Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("f3d8feeb-df0e-417b-aaee-25280baf9119"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("39173b28-7cb6-47ae-a429-5024c44d51a9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"ExclusiveGateway1",
				Position = new Point(366, 171),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("39173b28-7cb6-47ae-a429-5024c44d51a9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"ReadDataUserTask1",
				Position = new Point(125, 171),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateUserQuestionUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("39173b28-7cb6-47ae-a429-5024c44d51a9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"UserQuestionUserTask1",
				Position = new Point(359, 324),
				SchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeUserQuestionUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("f9de1386-6917-4d63-9831-56fcec025df4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("39173b28-7cb6-47ae-a429-5024c44d51a9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"ChangeDataUserTask2",
				Position = new Point(589, 170),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask3UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("88714082-9190-4092-9c5b-580b606c294f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("39173b28-7cb6-47ae-a429-5024c44d51a9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c30b0386-9ab7-4104-8ab8-78b14b83ab49"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"ChangeDataUserTask3",
				Position = new Point(589, 324),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask3Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("39173b28-7cb6-47ae-a429-5024c44d51a9"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("72dfd004-1fad-41fa-ad05-3cbc97f2958e"),
				CreatedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"),
				Name = @"ReadDataUserTask2",
				Position = new Point(236, 171),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LeadAutoToEndState(userConnection);
		}

		public override object Clone() {
			return new LeadAutoToEndStateSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadAutoToEndState

	/// <exclude/>
	public class LeadAutoToEndState : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, LeadAutoToEndState process)
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, LeadAutoToEndState process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("b83c62d8-6c83-4638-8270-2aa30715adc3");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,19,49,20,253,21,52,235,186,154,25,207,51,59,40,1,117,1,137,72,213,13,233,194,177,175,83,139,121,201,227,20,66,20,9,248,130,134,239,96,193,2,241,148,88,52,234,143,244,75,184,158,73,67,138,34,8,108,16,18,35,121,102,124,116,238,245,185,47,207,28,158,177,186,126,200,114,112,58,206,157,254,131,65,41,205,254,61,149,25,208,247,117,57,169,156,61,167,6,173,88,166,158,131,104,241,174,80,230,46,51,12,13,102,195,239,246,67,167,51,220,230,97,232,236,13,29,101,32,175,145,129,6,82,8,47,74,147,148,4,177,116,73,0,220,35,44,241,67,66,169,164,130,114,63,73,168,219,50,183,187,62,40,243,138,105,104,79,104,156,203,230,247,104,90,89,162,135,0,111,40,170,46,139,21,72,173,132,186,91,176,81,6,2,247,70,79,0,33,163,85,142,145,192,145,202,161,207,52,158,100,253,148,22,66,146,100,89,109,89,25,72,211,125,86,105,168,107,85,22,63,151,150,77,242,98,147,139,230,176,222,174,196,184,141,66,203,236,51,115,218,56,56,68,81,243,70,227,237,241,88,195,152,25,117,182,41,225,9,76,27,222,110,185,67,3,129,245,57,102,217,4,54,206,188,25,199,1,171,76,27,78,123,60,18,180,26,159,238,24,233,58,91,191,10,214,71,176,186,38,239,228,113,171,126,63,66,240,204,2,173,143,235,223,161,243,248,176,238,61,45,64,15,248,41,228,172,205,216,201,62,162,63,0,221,12,114,40,76,103,230,70,148,122,65,36,73,26,6,30,9,120,234,146,36,72,3,18,73,198,25,36,148,37,94,60,71,131,181,160,206,204,15,195,80,132,16,146,84,68,152,251,8,211,158,186,158,36,32,66,63,25,73,57,226,130,207,79,90,225,170,174,50,54,61,94,235,91,158,95,126,92,46,174,94,189,89,158,95,124,197,245,14,215,91,92,239,237,247,22,190,62,172,128,207,45,107,113,245,226,19,238,190,52,232,226,226,229,114,113,249,122,255,17,240,82,139,85,153,236,7,29,135,113,76,131,144,166,132,69,177,36,129,228,54,142,24,8,75,99,238,71,169,27,8,230,99,87,217,199,22,191,28,43,206,178,94,5,26,155,171,41,174,187,125,40,110,76,147,77,187,46,75,211,38,115,93,180,94,85,149,218,76,10,101,176,47,55,250,51,137,56,132,35,17,144,48,74,40,230,54,0,50,18,46,54,169,39,168,43,61,223,141,37,67,77,120,169,216,2,15,202,137,230,171,65,174,219,219,228,143,238,137,191,48,255,191,51,212,91,199,106,151,65,249,63,4,203,127,102,8,230,206,252,27,58,192,189,235,76,7,0,0 })));
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

			private string _entityColumnMetaPathes;
			public override string EntityColumnMetaPathes {
				get {
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,183,52,79,76,54,54,53,210,53,177,52,183,212,53,73,49,178,208,181,52,48,75,211,181,48,74,75,77,50,75,73,74,182,76,73,6,0,174,79,115,201,36,0,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: UserQuestionUserTask1FlowElement

		/// <exclude/>
		public class UserQuestionUserTask1FlowElement : UserQuestionUserTask
		{

			#region Constructors: Public

			public UserQuestionUserTask1FlowElement(UserConnection userConnection, LeadAutoToEndState process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "UserQuestionUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("ab596052-3889-4d6f-ac74-f7be133771d7");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private LocalizableString _branchingDecisions;
			public override LocalizableString BranchingDecisions {
				get {
					if (_branchingDecisions == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,143,193,74,3,49,16,134,95,69,66,143,59,37,219,76,54,73,143,182,8,133,42,5,209,139,120,152,36,19,92,220,186,101,55,21,108,217,119,119,187,167,10,226,197,219,192,55,223,63,243,159,197,44,127,29,88,44,197,237,238,254,177,77,121,190,106,59,158,239,186,54,112,223,207,183,109,160,166,62,145,111,120,71,29,237,57,115,247,76,205,145,251,109,221,231,226,230,90,18,133,152,125,78,76,44,95,206,98,147,121,255,180,137,99,178,180,206,37,233,60,4,131,22,48,209,2,60,7,7,198,70,146,68,152,208,150,163,124,217,61,139,41,97,148,200,32,70,141,8,172,101,4,212,38,0,73,75,16,172,148,85,68,52,165,34,49,20,226,97,124,234,218,91,115,168,251,186,253,144,23,184,162,67,30,231,11,175,251,109,56,77,175,139,101,238,142,60,210,53,167,213,27,135,119,254,113,248,142,154,158,197,48,20,215,21,146,55,210,43,237,161,148,146,1,45,27,176,28,21,232,176,192,224,149,81,149,254,165,130,194,80,85,139,8,18,43,7,136,78,131,175,92,2,37,57,73,163,157,213,88,254,85,97,130,255,169,240,58,124,3,208,217,68,129,223,1,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "9af301a024e549919da3cf2e0f291386",
							"BaseElements.UserQuestionUserTask1.Parameters.BranchingDecisions.Value");
						dataList.LoadLocalizableValues();
						_branchingDecisions = dataList.GetSerializedItems();
						};
					return _branchingDecisions;
				}
				set {
					_branchingDecisions = value;
				}
			}

			private int _decisionMode = 0;
			public override int DecisionMode {
				get {
					return _decisionMode;
				}
				set {
					_decisionMode = value;
				}
			}

			private bool _isDecisionRequired = true;
			public override bool IsDecisionRequired {
				get {
					return _isDecisionRequired;
				}
				set {
					_isDecisionRequired = value;
				}
			}

			private LocalizableString _question;
			public override LocalizableString Question {
				get {
					return _question ?? (_question = GetLocalizableString("9af301a024e549919da3cf2e0f291386",
						 "BaseElements.UserQuestionUserTask1.Parameters.Question.Value"));
				}
				set {
					_question = value;
				}
			}

			private LocalizableString _windowCaption;
			public override LocalizableString WindowCaption {
				get {
					return _windowCaption ?? (_windowCaption = GetLocalizableString("9af301a024e549919da3cf2e0f291386",
						 "BaseElements.UserQuestionUserTask1.Parameters.WindowCaption.Value"));
				}
				set {
					_windowCaption = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("9af301a024e549919da3cf2e0f291386",
						 "BaseElements.UserQuestionUserTask1.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			private int _duration = 5;
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

			private bool _showInScheduler = false;
			public override bool ShowInScheduler {
				get {
					return _showInScheduler;
				}
				set {
					_showInScheduler = value;
				}
			}

			private bool _showExecutionPage = true;
			public override bool ShowExecutionPage {
				get {
					return _showExecutionPage;
				}
				set {
					_showExecutionPage = value;
				}
			}

			#endregion

			#region Methods: Public

			public override string GetResultAllowedValues() {
				return "[\"a34c662d-0469-4495-b69f-30ef07598541\",\"a744d544-e50d-457c-a08a-c8006d44713a\"]";
			}

			#endregion

		}

		#endregion

		#region Class: ChangeDataUserTask2FlowElement

		/// <exclude/>
		public class ChangeDataUserTask2FlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataUserTask2FlowElement(UserConnection userConnection, LeadAutoToEndState process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("f9de1386-6917-4d63-9831-56fcec025df4");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifyStatus = () => (Guid)(new Guid("0a0808c5-5415-41f0-bea3-118cc3089959"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifyStatus", () => _recordColumnValues_QualifyStatus.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifyStatus;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,73,110,212,64,20,189,10,242,154,138,108,151,203,67,239,32,52,40,18,144,136,68,108,226,44,190,203,191,58,22,158,84,174,14,52,45,75,192,9,210,156,131,5,11,196,40,177,72,43,23,201,73,168,178,59,77,18,58,131,178,65,72,44,202,195,211,251,175,254,60,181,120,14,77,243,20,10,180,6,214,253,173,39,219,149,80,107,15,179,92,161,124,36,171,113,109,221,181,26,148,25,228,217,107,76,123,124,152,102,234,1,40,208,6,211,248,183,125,108,13,226,85,10,177,117,55,182,50,133,69,163,25,218,128,82,230,131,96,33,73,221,128,17,47,164,9,137,4,5,226,51,59,113,32,116,68,20,166,61,115,181,244,70,217,139,119,186,162,251,220,153,212,134,227,105,128,87,69,13,50,107,170,114,1,82,115,123,51,44,33,201,209,232,42,57,70,13,41,153,21,58,8,220,201,10,220,2,169,47,49,58,149,129,52,73,64,222,24,86,142,66,13,95,213,18,155,38,171,202,171,188,90,175,242,113,81,158,229,106,115,92,254,46,156,177,59,15,13,115,11,212,126,39,176,89,215,149,84,227,50,83,147,216,106,59,103,239,141,70,18,71,160,178,131,179,190,188,192,73,103,112,179,252,105,131,84,215,232,57,228,99,92,92,238,216,127,68,180,14,181,234,3,139,173,249,225,241,215,249,236,228,221,135,249,225,209,79,125,62,233,243,81,159,207,230,221,9,74,20,40,177,228,184,205,247,177,128,101,14,206,133,96,120,217,104,255,204,37,166,238,187,151,38,110,153,252,235,114,231,106,176,62,37,95,85,138,165,226,202,44,184,190,6,15,12,208,107,156,126,198,214,238,70,179,249,178,68,217,71,215,231,125,111,77,163,23,128,97,142,5,150,106,48,181,125,74,29,207,23,36,98,158,67,60,30,217,36,244,34,143,248,2,56,96,72,117,49,130,86,27,44,29,26,76,93,198,88,202,144,145,40,245,35,226,249,220,33,145,237,8,130,41,115,195,68,136,132,167,188,221,235,29,207,154,58,135,73,231,251,245,5,186,163,31,95,22,192,247,158,53,59,121,243,77,255,253,232,208,217,209,219,249,236,248,253,218,51,228,149,76,55,250,14,49,47,45,236,251,212,19,65,18,18,39,100,41,241,34,219,39,64,209,37,73,16,37,182,23,137,128,5,145,238,205,182,221,107,77,131,230,213,40,227,144,111,214,40,97,209,61,246,234,33,59,55,157,38,239,178,170,212,133,230,121,140,208,59,115,218,223,41,117,145,7,186,181,25,48,161,179,26,4,36,228,220,37,16,122,182,112,128,82,10,198,27,189,152,76,105,183,171,177,228,216,111,132,166,223,72,183,218,53,127,97,145,220,106,59,92,50,91,55,153,150,255,147,48,255,7,38,161,181,218,95,220,161,200,240,149,7,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,143,218,48,16,253,43,43,239,30,153,200,142,63,18,115,108,247,130,4,21,42,237,94,150,61,140,237,113,55,106,32,40,9,149,182,136,255,222,36,132,2,213,86,170,84,31,98,121,60,239,205,243,188,201,129,61,180,111,59,98,83,246,97,185,88,85,177,77,62,86,53,37,203,186,242,212,52,201,188,242,88,22,63,209,149,180,196,26,55,212,82,253,132,229,158,154,121,209,180,147,187,107,16,155,176,135,31,195,29,155,62,31,216,172,165,205,215,89,232,152,51,153,106,147,25,4,201,93,4,165,77,4,231,136,131,13,65,235,44,164,14,125,15,246,85,185,223,108,23,212,226,18,219,87,54,61,176,129,173,35,112,158,251,52,24,14,26,101,0,149,43,14,136,138,192,27,78,152,101,134,82,110,216,113,194,26,255,74,27,28,138,94,192,74,96,204,45,89,200,52,119,160,200,57,200,61,122,136,81,90,103,58,50,65,190,7,143,249,23,224,243,253,188,170,190,239,119,73,154,74,37,124,16,160,157,148,160,124,87,222,114,33,192,196,204,88,73,209,144,82,9,71,158,243,220,107,208,74,104,80,34,114,112,132,18,132,200,189,151,60,183,86,219,251,151,190,80,40,154,93,137,111,79,127,173,55,39,12,119,77,139,223,40,89,97,91,52,177,160,112,130,238,110,60,184,6,31,214,39,35,215,108,186,126,223,202,113,95,13,61,186,53,243,214,199,53,155,172,217,170,218,215,190,103,147,221,225,241,74,241,80,96,72,249,227,120,54,174,139,108,247,101,57,70,30,177,197,115,226,57,92,133,162,127,210,108,187,58,251,53,176,240,113,193,59,159,243,58,105,251,31,216,2,183,93,99,235,79,221,243,47,218,127,171,252,210,181,240,76,236,82,171,121,38,34,100,132,182,27,28,147,66,30,4,130,21,214,69,217,13,117,140,233,128,254,76,145,106,218,122,186,21,246,47,99,51,226,155,161,219,253,31,51,234,234,91,117,100,199,227,203,241,23,238,67,139,104,161,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "9af301a024e549919da3cf2e0f291386",
							"BaseElements.ChangeDataUserTask2.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("72dfd004-1fad-41fa-ad05-3cbc97f2958e");
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

		#region Class: ChangeDataUserTask3FlowElement

		/// <exclude/>
		public class ChangeDataUserTask3FlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataUserTask3FlowElement(UserConnection userConnection, LeadAutoToEndState process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask3";
				IsLogging = true;
				SchemaElementUId = new Guid("88714082-9190-4092-9c5b-580b606c294f");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifyStatus = () => (Guid)(new Guid("14cfc644-e3ed-497e-8279-ed4319bb8093"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifyStatus", () => _recordColumnValues_QualifyStatus.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifyStatus;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,205,110,212,48,16,126,21,148,115,93,57,255,201,222,160,44,168,18,208,138,86,92,154,30,28,103,188,181,200,159,28,111,97,89,69,162,60,65,151,231,224,192,1,241,43,113,232,170,47,210,39,97,156,108,151,182,244,79,189,32,36,14,78,236,79,51,159,103,62,207,204,212,226,57,107,154,103,172,0,107,96,61,216,124,186,85,9,189,250,72,230,26,212,99,85,141,107,107,197,106,64,73,150,203,55,144,245,248,48,147,250,33,211,12,29,166,201,111,255,196,26,36,151,49,36,214,74,98,73,13,69,131,22,232,96,3,8,26,68,64,210,212,13,137,151,218,46,137,25,77,73,72,69,38,28,10,94,202,12,215,149,212,235,101,79,222,241,138,110,187,61,169,141,141,135,0,175,138,154,41,217,84,229,2,116,205,237,205,176,100,105,14,25,158,181,26,3,66,90,201,2,147,128,109,89,192,38,83,120,137,225,169,12,132,70,130,229,141,177,202,65,232,225,235,90,65,211,200,170,188,46,170,181,42,31,23,229,89,91,116,135,229,113,17,12,237,34,52,150,155,76,239,117,4,27,117,93,41,61,46,165,158,36,86,219,5,123,127,52,82,48,98,90,238,159,141,229,37,76,58,135,219,233,135,14,25,190,209,11,150,143,97,113,185,77,255,200,104,141,213,186,79,44,177,230,135,199,95,231,179,147,119,31,230,135,71,63,113,125,194,245,17,215,103,243,239,8,21,8,80,80,114,216,226,123,80,176,165,6,231,82,48,118,114,180,119,230,18,243,238,59,87,10,183,20,255,38,237,28,4,235,83,227,235,158,98,201,120,169,10,78,128,224,190,1,122,142,211,109,98,237,172,55,27,175,74,80,125,118,189,238,187,171,136,94,0,134,57,20,80,234,193,148,6,174,107,123,129,32,177,239,217,196,227,49,37,145,23,123,36,16,140,51,136,92,22,217,97,139,14,203,128,6,83,199,247,253,204,7,159,196,89,16,19,47,224,54,137,169,45,8,100,190,19,165,66,164,60,227,237,110,31,184,108,234,156,77,186,216,111,126,160,123,248,249,178,0,190,247,86,179,147,183,223,240,244,163,67,103,71,7,243,217,241,251,213,231,192,43,149,173,103,221,21,230,135,196,145,157,186,17,245,92,18,100,30,86,148,151,166,132,197,62,166,21,133,16,49,26,97,138,33,214,102,219,238,182,166,64,243,106,36,57,203,55,106,80,108,81,61,244,242,38,59,215,157,70,119,85,85,250,66,241,60,1,214,7,115,90,223,49,99,94,200,185,67,40,117,80,85,223,232,27,154,74,23,148,243,192,177,81,108,244,108,113,48,153,167,221,170,198,138,67,63,17,154,126,34,221,105,214,252,133,65,114,167,233,112,69,111,221,166,91,254,119,194,252,31,232,132,214,106,127,1,185,235,248,168,149,7,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,75,143,155,48,16,254,43,43,239,30,99,132,177,177,113,142,219,92,34,37,85,212,180,123,217,236,97,108,143,187,168,4,34,30,149,182,81,254,123,13,129,38,169,182,82,165,245,1,228,97,190,7,243,217,71,242,208,190,29,144,204,201,227,102,189,173,124,27,125,170,106,140,54,117,101,177,105,162,85,101,161,200,127,129,41,112,3,53,236,177,197,250,9,138,14,155,85,222,180,179,187,107,16,153,145,135,159,195,55,50,127,62,146,101,139,251,111,75,23,152,149,64,239,82,110,169,195,20,168,64,195,104,166,93,70,149,180,25,23,58,5,149,232,0,182,85,209,237,203,53,182,176,129,246,149,204,143,100,96,11,4,198,198,54,113,50,166,41,112,71,69,38,98,10,32,144,90,25,35,40,37,49,137,37,57,205,72,99,95,113,15,131,232,5,44,24,248,76,163,166,42,141,77,175,110,104,102,193,82,239,185,54,50,144,49,180,61,120,236,191,0,159,239,87,85,245,163,59,68,73,194,5,179,142,209,212,112,78,133,13,242,58,102,140,74,175,164,230,232,37,10,17,49,97,189,149,66,80,228,24,60,106,133,52,75,148,166,232,4,103,218,152,44,214,252,254,165,23,114,121,115,40,224,237,233,159,122,43,4,119,215,180,240,29,163,69,152,114,157,155,174,205,171,242,140,62,220,196,112,141,63,238,206,89,238,200,124,247,126,154,227,123,59,140,233,54,207,219,40,119,100,182,35,219,170,171,109,207,198,195,102,113,101,122,16,24,90,254,218,78,217,133,74,217,21,197,88,89,64,11,83,227,84,174,92,238,115,116,203,114,59,69,54,176,196,227,162,239,60,166,117,246,246,17,216,26,202,48,219,250,115,248,253,139,247,63,46,191,134,17,78,196,38,209,105,172,152,167,10,65,135,179,35,19,154,57,6,84,135,68,61,87,60,241,62,25,208,95,208,99,141,165,197,91,99,255,115,114,70,124,51,76,187,191,52,163,175,126,84,39,114,58,189,156,126,3,26,96,209,139,164,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "9af301a024e549919da3cf2e0f291386",
							"BaseElements.ChangeDataUserTask3.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("72dfd004-1fad-41fa-ad05-3cbc97f2958e");
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

		#region Class: ReadDataUserTask2FlowElement

		/// <exclude/>
		public class ReadDataUserTask2FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask2FlowElement(UserConnection userConnection, LeadAutoToEndState process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("67cfff35-621a-4e09-916b-349b66e15f44");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,59,111,19,65,16,254,43,209,213,217,232,94,190,135,59,8,6,165,128,68,114,68,131,83,236,237,237,57,43,238,165,189,117,192,88,150,16,61,194,78,153,10,42,26,138,8,241,200,131,135,116,86,248,33,252,18,102,119,109,199,65,22,24,10,104,98,233,228,217,111,191,153,249,230,110,102,6,6,73,113,85,221,195,25,53,154,198,205,157,187,237,34,17,27,183,89,42,40,191,195,139,94,105,172,27,21,229,12,167,236,9,141,53,222,138,153,184,133,5,6,135,65,231,210,191,99,52,59,203,34,116,140,245,142,193,4,205,42,96,128,3,165,73,35,113,130,4,57,113,210,64,46,241,34,20,82,43,64,52,178,72,224,89,196,115,3,172,153,203,67,111,22,89,137,57,213,25,84,240,68,153,187,253,82,18,45,0,136,162,176,170,200,167,160,35,37,84,173,28,71,41,141,225,44,120,143,2,36,56,203,160,18,186,203,50,186,131,57,100,146,113,10,9,1,41,193,105,37,89,41,77,68,235,113,201,105,85,177,34,255,181,180,180,151,229,139,92,112,167,243,227,84,140,169,20,74,230,14,22,251,42,192,22,136,26,42,141,55,186,93,78,187,88,176,131,69,9,15,105,95,241,86,123,119,224,16,195,247,185,143,211,30,93,200,121,181,142,77,92,10,93,142,78,15,4,206,186,251,43,86,58,127,91,191,43,214,6,176,156,145,87,138,184,84,191,237,1,120,32,1,29,99,102,118,140,7,91,213,246,163,156,242,54,217,167,25,214,111,108,111,3,208,159,128,86,74,51,154,139,230,32,10,28,226,217,113,128,60,18,56,200,245,156,0,5,182,111,34,27,99,199,244,173,6,142,137,51,4,135,185,160,230,32,118,226,134,23,37,22,242,125,31,35,55,34,62,194,216,4,23,55,12,2,108,70,190,229,38,210,165,149,11,38,250,186,11,154,3,63,244,49,113,26,54,114,67,63,68,110,108,7,40,52,189,4,178,37,52,242,226,136,132,49,25,238,233,114,89,85,166,184,127,127,94,213,100,84,191,134,231,100,50,254,254,244,8,140,99,109,140,47,14,215,224,244,78,33,163,250,179,122,224,230,20,140,247,242,230,43,156,158,189,1,227,203,2,237,131,140,180,49,25,93,156,72,218,140,241,118,230,120,186,54,25,215,207,193,56,87,215,163,250,211,244,95,133,62,90,155,57,72,232,227,100,252,237,80,81,65,202,76,220,137,102,200,155,241,133,114,58,158,210,33,244,168,62,155,202,57,95,72,113,38,89,47,149,175,214,86,191,186,44,85,43,135,168,245,11,24,11,249,147,221,91,116,25,193,233,118,73,57,76,135,234,78,115,249,84,95,89,7,178,111,120,81,8,221,13,243,174,219,46,203,130,139,94,14,159,171,45,112,23,192,133,41,131,164,176,246,100,11,182,139,30,39,211,85,83,233,125,247,87,155,236,63,108,168,63,89,59,75,7,127,149,81,190,30,211,235,49,157,252,211,49,29,26,195,31,187,44,57,213,180,8,0,0 })));
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

			private string _entityColumnMetaPathes;
			public override string EntityColumnMetaPathes {
				get {
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,179,76,49,54,75,51,179,52,215,53,53,75,73,210,53,49,53,182,212,181,180,48,176,212,77,50,48,79,51,48,76,73,75,181,76,52,0,0,122,108,77,60,36,0,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
				}
			}

			#endregion

		}

		#endregion

		public LeadAutoToEndState(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadAutoToEndState";
			SchemaUId = new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386");
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
				return new Guid("9af301a0-24e5-4991-9da3-cf2e0f291386");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LeadAutoToEndState, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LeadAutoToEndState, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

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
					SchemaElementUId = new Guid("b4e8b447-2802-40bb-989f-573cc8842404"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("0633146f-9541-4c90-8494-6facae83a817"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("f3d8feeb-df0e-417b-aaee-25280baf9119"),
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

		private ReadDataUserTask1FlowElement _readDataUserTask1;
		public ReadDataUserTask1FlowElement ReadDataUserTask1 {
			get {
				return _readDataUserTask1 ?? (_readDataUserTask1 = new ReadDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private UserQuestionUserTask1FlowElement _userQuestionUserTask1;
		public UserQuestionUserTask1FlowElement UserQuestionUserTask1 {
			get {
				return _userQuestionUserTask1 ?? (_userQuestionUserTask1 = new UserQuestionUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeDataUserTask2FlowElement _changeDataUserTask2;
		public ChangeDataUserTask2FlowElement ChangeDataUserTask2 {
			get {
				return _changeDataUserTask2 ?? (_changeDataUserTask2 = new ChangeDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeDataUserTask3FlowElement _changeDataUserTask3;
		public ChangeDataUserTask3FlowElement ChangeDataUserTask3 {
			get {
				return _changeDataUserTask3 ?? (_changeDataUserTask3 = new ChangeDataUserTask3FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataUserTask2FlowElement _readDataUserTask2;
		public ReadDataUserTask2FlowElement ReadDataUserTask2 {
			get {
				return _readDataUserTask2 ?? (_readDataUserTask2 = new ReadDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("f0787462-3d38-48ab-97ca-b6cff17f42ff"),
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
					SchemaElementUId = new Guid("562067d2-5de3-4e83-9d05-3d9b10938727"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"), new Collection<Guid>() {
							new Guid("a34c662d-0469-4495-b69f-30ef07598541"),
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
					SchemaElementUId = new Guid("4c59f6a2-cc7e-42c1-b95d-e084dc60daf6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("ab596052-3889-4d6f-ac74-f7be133771d7"), new Collection<Guid>() {
							new Guid("a744d544-e50d-457c-a08a-c8006d44713a"),
						}},
					},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[StartSignal1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[UserQuestionUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { UserQuestionUserTask1 };
			FlowElements[ChangeDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask2 };
			FlowElements[ChangeDataUserTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask3 };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Terminate1":
						CompleteProcess();
						break;
					case "StartSignal1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("UserQuestionUserTask1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
						break;
					case "UserQuestionUserTask1":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask3", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow4ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask2", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "UserQuestionUserTask1");
						break;
					case "ChangeDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ChangeDataUserTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Successful").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<bool>("Successful") : false)));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow1", "((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName(\"Successful\").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<bool>(\"Successful\") : false))", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalFlow3.ProcessActivitiesSelectedResults[new Guid("ab596052-3889-4d6f-ac74-f7be133771d7")])) != 0;
			Log.InfoFormat(ConditionalExpressionLogMessage, "UserQuestionUserTask1", "ConditionalFlow3", "System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalFlow3.ProcessActivitiesSelectedResults[new Guid(\"ab596052-3889-4d6f-ac74-f7be133771d7\")])) != 0", result);
			Log.Info($"UserQuestionUserTask1.ResultDecisions: {UserQuestionUserTask1.ResultDecisions}");
			return result;
		}

		private bool ConditionalFlow4ExpressionExecute() {
			bool result = System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalFlow4.ProcessActivitiesSelectedResults[new Guid("ab596052-3889-4d6f-ac74-f7be133771d7")])) != 0;
			Log.InfoFormat(ConditionalExpressionLogMessage, "UserQuestionUserTask1", "ConditionalFlow4", "System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalFlow4.ProcessActivitiesSelectedResults[new Guid(\"ab596052-3889-4d6f-ac74-f7be133771d7\")])) != 0", result);
			Log.Info($"UserQuestionUserTask1.ResultDecisions: {UserQuestionUserTask1.ResultDecisions}");
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
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
			MetaPathParameterValues.Add("2555d5e5-9d69-46c1-901f-ed528bffbcdc", () => StartSignal1.RecordId);
			MetaPathParameterValues.Add("fb76d37f-4030-42f0-b828-cbb1a4b381aa", () => StartSignal1.EntitySchemaUId);
			MetaPathParameterValues.Add("c674161d-9746-4a42-af2f-efe9123f908d", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("8e022789-4e9c-4ca9-a63a-bafe8b45d27a", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("891c2114-c8fc-465d-b1f5-f5278d3afcf2", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("b8c3887c-acc7-4db4-a068-a6c9b5095c6f", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("0d2e4df5-ebbe-4435-8f78-c990952374df", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("d5c75813-9a69-4394-aa21-757ee0a79c85", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("4a96c175-f201-4971-a84c-667bf1d98abb", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("d3d56bf1-777a-4bc7-aa00-24988a0b714f", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("0e30322a-5528-4686-8289-0dd270a0747e", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("0515d8e0-89b7-4b5f-86f2-57c17fa5c211", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("a43a1cf1-ff6b-4013-8469-b230f95aeed3", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("15f88c4d-b432-4552-a155-90b07e7d0e80", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("7acadd53-ed9a-430e-92da-737ed1810ea7", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("6f8ca22a-b3a4-47eb-9ec6-08f559063864", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("c9b43dca-27ca-4615-a3d9-6b0896d38d91", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("a6b199bd-b0af-4235-9fd8-d432bef1342d", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("0c0fb151-9665-481d-a943-69460316e837", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("f6be456e-854b-4527-b219-91f89da82e8a", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("d66e8488-0ca3-4d87-9c75-aa6fb8035f8a", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("23470eda-fd4a-4dcb-a26f-6eb160c6b305", () => UserQuestionUserTask1.BranchingDecisions);
			MetaPathParameterValues.Add("17cd0f5c-25fe-42a4-99da-d593c8a0a37f", () => UserQuestionUserTask1.ResultDecisions);
			MetaPathParameterValues.Add("fb9218e3-edba-4d6d-9f82-2f0ad13153dd", () => UserQuestionUserTask1.DecisionMode);
			MetaPathParameterValues.Add("711528bb-6676-488b-8c54-79154028c8f1", () => UserQuestionUserTask1.IsDecisionRequired);
			MetaPathParameterValues.Add("e4ef48da-4ee6-4ee6-ba67-0f5dd93a47cd", () => UserQuestionUserTask1.Question);
			MetaPathParameterValues.Add("0849dedf-33cf-448d-87ad-a9ba022daa4a", () => UserQuestionUserTask1.WindowCaption);
			MetaPathParameterValues.Add("3db58c3f-22ba-40b8-b71d-4b8bcd16a115", () => UserQuestionUserTask1.Recommendation);
			MetaPathParameterValues.Add("fad75be7-0f8a-4872-967c-7d2c62690303", () => UserQuestionUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("22a1d630-b988-4a27-b8ff-6fd69dca7b08", () => UserQuestionUserTask1.OwnerId);
			MetaPathParameterValues.Add("11afda49-35e6-4c12-9ea2-96db901da46b", () => UserQuestionUserTask1.Duration);
			MetaPathParameterValues.Add("9c63a071-4375-4cdc-9829-9904f26e6585", () => UserQuestionUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("588fd741-5860-4c73-8326-9fff706860b8", () => UserQuestionUserTask1.StartIn);
			MetaPathParameterValues.Add("29355950-5494-47a3-b730-2dca6b41b7d3", () => UserQuestionUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("b0c7abe8-1b56-4322-a1af-34567e8ee6c0", () => UserQuestionUserTask1.RemindBefore);
			MetaPathParameterValues.Add("10e64984-20e7-4e23-b0a7-b1d11798514c", () => UserQuestionUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("a6270bb2-5dac-4ad4-b8bc-207c2b3dce6b", () => UserQuestionUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("5d251a59-539c-46e1-8fbc-7d54869ffe8f", () => UserQuestionUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("1e3036be-34b9-4a4a-85ec-999e85694aba", () => UserQuestionUserTask1.Lead);
			MetaPathParameterValues.Add("693953dc-26bc-4cc8-893c-50df8cbfa540", () => UserQuestionUserTask1.Account);
			MetaPathParameterValues.Add("2edcfe17-f472-4a05-911e-ff5f6158c136", () => UserQuestionUserTask1.Contact);
			MetaPathParameterValues.Add("6560a60a-c2f8-4a12-8405-2ed91eed8bf0", () => UserQuestionUserTask1.Opportunity);
			MetaPathParameterValues.Add("d553a0ac-618b-4bef-bfee-e24778fcd6ad", () => UserQuestionUserTask1.Invoice);
			MetaPathParameterValues.Add("65175ba0-3b99-41ba-8e49-8f54e6f87036", () => UserQuestionUserTask1.Document);
			MetaPathParameterValues.Add("7b349c4c-8ceb-41b3-9e56-cbee348bc604", () => UserQuestionUserTask1.Incident);
			MetaPathParameterValues.Add("98189f43-a322-4b76-a3a9-14c369544dee", () => UserQuestionUserTask1.Case);
			MetaPathParameterValues.Add("bc28920d-a411-4c17-85ca-e6461f60c921", () => UserQuestionUserTask1.ActivityResult);
			MetaPathParameterValues.Add("7b906324-fffe-4806-a5bc-9c1e52e06325", () => UserQuestionUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("a929915e-60ad-42c2-9a7c-93301d1da38a", () => UserQuestionUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("ad6124ce-5389-44e0-a050-e08ee0924021", () => UserQuestionUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("bc996c5b-31fa-4a91-aeb2-7031c3994ca5", () => UserQuestionUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("2f0d536d-6d1d-4845-9703-1adeb8576fd9", () => UserQuestionUserTask1.Order);
			MetaPathParameterValues.Add("59fbf60e-8f41-448a-8616-849f39991f00", () => UserQuestionUserTask1.Requests);
			MetaPathParameterValues.Add("56c34026-9ed0-4dcb-b716-886b7c4b2b09", () => UserQuestionUserTask1.Listing);
			MetaPathParameterValues.Add("e04571cf-6c74-4140-b50b-a9ea256bd366", () => UserQuestionUserTask1.Property);
			MetaPathParameterValues.Add("27c89055-6026-4244-8ff4-093dfc05c28c", () => UserQuestionUserTask1.Contract);
			MetaPathParameterValues.Add("f9d05259-826b-43fc-bddb-d0915320cac5", () => UserQuestionUserTask1.Project);
			MetaPathParameterValues.Add("670d3618-61ea-44bb-bdc7-c282f5c9882a", () => UserQuestionUserTask1.Problem);
			MetaPathParameterValues.Add("7140ffaf-6034-4859-adb2-33eb5086764b", () => UserQuestionUserTask1.Change);
			MetaPathParameterValues.Add("07899f83-a011-4912-99f0-cf24347c6ba4", () => UserQuestionUserTask1.Release);
			MetaPathParameterValues.Add("b33f2c42-2933-4c92-aedb-1b9556f6b169", () => UserQuestionUserTask1.CreateActivity);
			MetaPathParameterValues.Add("5e0dd5b5-b354-49a4-ad86-ca7413b530b7", () => UserQuestionUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("a904d73f-a09c-44a8-878a-a19fc5c41658", () => ChangeDataUserTask2.EntitySchemaUId);
			MetaPathParameterValues.Add("0c2bfccf-ed5e-4d79-9cc8-06c7445de2ab", () => ChangeDataUserTask2.IsMatchConditions);
			MetaPathParameterValues.Add("adbba650-d377-41d5-a69f-514e3c05c2a6", () => ChangeDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("bec87d14-9ecd-40b3-a7ce-6925d9200e60", () => ChangeDataUserTask2.RecordColumnValues);
			MetaPathParameterValues.Add("a7558cf4-1e39-4ddd-a54e-51a0a4b48fc9", () => ChangeDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("fa05a2c7-0e11-4e5f-a19b-16fb050762c1", () => ChangeDataUserTask3.EntitySchemaUId);
			MetaPathParameterValues.Add("fc0b26dd-f352-4bdc-85e2-8c07f97c3355", () => ChangeDataUserTask3.IsMatchConditions);
			MetaPathParameterValues.Add("ae8ff592-352a-4e64-b2ff-890082dfab9d", () => ChangeDataUserTask3.DataSourceFilters);
			MetaPathParameterValues.Add("a93327ad-0eff-457f-ac57-26fbc93ce95a", () => ChangeDataUserTask3.RecordColumnValues);
			MetaPathParameterValues.Add("931ee3e8-56d8-4076-840e-2d8e9b79977c", () => ChangeDataUserTask3.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("fdead1a0-736b-4043-8b38-7b10af3b41ac", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("9af14c8d-5edd-4be4-82c3-646e2adff0bc", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("7f6dda89-a2ac-45ad-b8c0-966007f49fd0", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("e5ecd48e-a7a6-47ec-82df-5380d83aa6de", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("7f02d3d0-3614-4905-abe0-9735007319da", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("59927067-c313-487e-a77d-d761614e8ff2", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("ef491bee-22fc-489d-b39e-7ddd0b703901", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("89a40511-3074-42c8-86d3-3a3435c824cf", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("8d6e0dc8-5703-47d6-a9fb-bd2247ac15b2", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("37274c45-33e6-4771-b984-e64a60ac3c9e", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("2da695c0-6a45-4669-bb65-ac00a4c44e4b", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("b5a2e001-fa12-4f66-aee8-dedbda666123", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("520dc2ae-127d-4a19-a262-4cb393dd7059", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("80b7ce3d-4682-44d1-9eed-989e91e8cd2a", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("31093895-ecdd-44eb-8dcb-68e59c009683", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("7b2e740a-bafe-4153-b031-137e02d7f695", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("fefe044c-19ec-45d1-b204-216cac3e8aec", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("fe71eb97-16f3-42db-9478-dca5f20acd34", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("d1dec698-059d-4e1f-9c6c-bd4b692f4e01", () => ReadDataUserTask2.ConsiderTimeInFilter);
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
			var cloneItem = (LeadAutoToEndState)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

