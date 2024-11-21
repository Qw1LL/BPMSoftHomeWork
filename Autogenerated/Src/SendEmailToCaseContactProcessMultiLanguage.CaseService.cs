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
	using BPMSoft.Mail;
	using BPMSoft.Mail.Sender;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: SendEmailToCaseContactProcessMultiLanguageSchema

	/// <exclude/>
	public class SendEmailToCaseContactProcessMultiLanguageSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SendEmailToCaseContactProcessMultiLanguageSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SendEmailToCaseContactProcessMultiLanguageSchema(SendEmailToCaseContactProcessMultiLanguageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SendEmailToCaseContactProcessMultiLanguage";
			UId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce");
			CreatedInPackageId = new Guid("18e91881-16c9-49f4-ab06-bb16b1eb7b07");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce");
			Version = 0;
			PackageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCaseIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2182c543-89b6-4709-8a44-0ccc49d8c85a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"CaseId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTemplateIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d30737ec-df8a-4aeb-805c-7bc8649175e6"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"TemplateId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#Lookup.93030575-f70f-4041-902e-c4badaf62c63.253cd392-267a-45bb-83b4-17630bcfa37b#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3da60100-fb70-4440-a82a-0ee88ccc4b13"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"SenderEmail",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSubjectParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7f0cb231-3dda-4b22-a6ea-e79291d7ee8c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"Subject",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateParentActivityIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("be5104c4-7adc-4c31-a4a7-99463c431b36"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ParentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{70ba378d-c705-4902-a786-2c2d4f623c91}].[Parameter:{de51c882-736f-4db7-9a1b-bb605ec75208}].[EntityColumn:{b59a15ea-751e-4fd8-8281-f1a3dc7190ff}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateIsMultiLanguageEnabledParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d8ed1115-f389-47a1-bee9-8ed2415c428e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"IsMultiLanguageEnabled",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsEstimateWithIconsEnabledParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a1ceebce-05dc-410e-a7d4-682eee2c2a92"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"IsEstimateWithIconsEnabled",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsMultilanguageV2EnabledParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b65555c6-7f69-41d1-9675-aa4693ee6b54"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"IsMultilanguageV2Enabled",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCaseIdParameter());
			Parameters.Add(CreateTemplateIdParameter());
			Parameters.Add(CreateSenderEmailParameter());
			Parameters.Add(CreateSubjectParameter());
			Parameters.Add(CreateParentActivityIdParameter());
			Parameters.Add(CreateIsMultiLanguageEnabledParameter());
			Parameters.Add(CreateIsEstimateWithIconsEnabledParameter());
			Parameters.Add(CreateIsMultilanguageV2EnabledParameter());
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2240c0c2-4f40-423c-8b95-f111c72bbfd9"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,84,205,142,211,48,16,126,21,148,243,122,149,164,249,113,122,131,82,80,15,176,149,186,218,11,217,195,196,113,90,139,164,137,236,116,161,172,42,33,94,128,114,69,136,39,224,176,72,32,33,36,56,180,71,222,130,39,97,236,180,161,139,42,40,92,216,72,150,198,147,111,102,190,249,243,165,197,114,80,234,33,20,220,234,90,119,134,15,70,101,86,31,223,19,121,205,229,125,89,206,42,235,200,82,92,10,200,197,51,158,54,250,126,42,234,187,80,3,26,92,198,63,237,99,171,27,239,243,16,91,71,177,37,106,94,40,68,160,65,234,132,52,243,82,74,66,55,72,136,23,250,64,32,116,124,18,58,16,216,105,18,241,140,122,13,114,191,235,94,89,84,32,121,19,193,56,207,140,120,58,175,52,208,65,5,51,16,161,202,233,70,217,209,20,84,127,10,73,206,83,188,215,114,198,81,85,75,81,96,38,252,84,20,124,8,18,35,105,63,165,86,33,40,131,92,105,84,206,179,186,255,180,146,92,41,81,78,127,79,45,159,21,211,93,44,154,243,246,186,33,99,27,134,26,57,132,122,98,28,12,144,212,194,112,188,61,30,75,62,134,90,92,236,82,120,204,231,6,119,88,237,208,32,197,254,156,65,62,227,59,49,175,231,209,131,170,110,210,105,194,35,64,138,241,228,192,76,219,106,253,41,89,23,149,213,22,124,144,199,189,252,221,0,149,23,90,209,248,216,138,177,245,104,160,78,158,76,185,28,177,9,47,160,169,216,249,49,106,127,81,180,254,187,151,174,67,93,230,123,29,66,163,36,192,42,218,17,161,224,121,196,102,140,121,81,74,25,245,97,113,222,240,16,170,202,97,126,214,134,91,47,191,189,89,47,87,31,240,124,196,243,101,253,234,251,243,215,40,124,210,194,91,35,44,87,159,241,92,109,255,124,69,225,197,187,91,70,90,174,222,155,219,246,255,85,235,198,120,88,189,52,65,117,59,48,20,141,40,5,219,113,137,227,187,33,241,92,8,8,13,125,78,162,140,187,118,234,166,29,223,71,78,11,253,233,238,150,99,193,32,63,169,184,196,233,49,221,179,247,79,253,181,117,209,117,149,101,89,55,213,106,187,210,3,133,194,206,228,101,52,73,179,180,19,18,198,168,38,131,180,34,59,11,73,144,112,8,162,200,1,230,36,72,6,159,11,221,186,81,57,147,108,179,162,170,121,39,254,233,5,248,15,155,253,55,235,186,119,97,14,89,129,155,50,222,131,155,50,105,11,107,241,3,161,19,125,207,139,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b46a95f8-c76e-49f0-a82f-3277d460a1f6"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("db33b5a6-46aa-47ff-8e4b-5e13fdb80187"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("77acc736-6e4a-4799-8893-f31e6c67dd35"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("576434f3-e5c5-4731-be98-011701f8c85c"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8aa5b82c-3a24-4b4e-b291-b0353a2dc144"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0b953ab2-858c-4dd9-9bce-9d641ba01668"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("de51c882-736f-4db7-9a1b-bb605ec75208"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1a5ebf76-4ad7-4eb7-81fd-71180b9cf610"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c4106eb8-5ed0-42c8-b84f-34b0294210ca"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("51459f74-5d40-4e53-8ac7-ffca49ce3463"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("76c7a624-b7e2-4ab7-b03b-403b54d5cf2c"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f5df9dd5-1461-4018-96ef-5e5408602213"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4e739645-cfcf-4acb-b2c4-d98d6c2154ce"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("8453c16f-b75c-4362-9c4c-34a7a9599cbc"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dd247f81-c60d-43ef-a529-7e9e698f5f8a"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d72a4519-9e07-4c3a-ae50-fb5c05a32b5e"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("63abd854-a87d-4589-8a12-384eb55afc80"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("55e9058b-1352-4783-96b1-8527c49bfe42"),
				ContainerUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0ec419a6-4bb4-40da-806a-7aff639e25bd"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,211,64,16,253,43,149,207,221,202,223,246,230,6,37,160,30,160,149,90,113,33,61,236,174,199,169,133,191,100,111,10,33,138,132,184,35,146,30,123,130,19,23,14,128,168,232,7,229,144,168,252,16,126,9,179,182,19,82,20,65,224,2,18,145,86,90,191,125,111,230,205,102,118,6,154,136,89,89,222,99,9,104,45,237,230,206,221,221,44,148,27,183,163,88,66,113,167,200,122,185,182,174,149,80,68,44,142,158,64,80,227,237,32,146,183,152,100,40,24,116,190,235,59,90,171,179,44,66,71,91,239,104,145,132,164,68,6,10,76,135,58,130,83,74,28,198,128,216,186,201,136,31,128,75,66,97,80,97,24,33,11,67,191,102,46,15,189,153,37,57,43,160,206,80,5,15,171,237,94,63,87,68,3,1,81,81,162,50,75,27,208,82,22,202,118,202,120,12,1,126,203,162,7,8,201,34,74,176,18,216,139,18,216,97,5,102,82,113,50,5,33,41,100,113,169,88,49,132,178,253,56,47,160,44,163,44,253,185,181,184,151,164,139,92,148,195,252,179,49,163,87,14,21,115,135,201,131,42,192,22,154,26,86,30,111,116,187,5,116,153,140,14,23,45,60,132,126,197,91,237,238,80,16,224,255,115,159,197,61,88,200,121,189,142,77,150,203,186,156,58,61,18,138,168,123,176,98,165,243,219,250,85,177,38,130,249,140,188,82,196,165,254,77,23,193,67,5,212,49,102,219,142,246,96,171,220,126,148,66,177,43,14,32,97,245,141,237,111,32,250,3,208,142,33,129,84,182,6,158,206,153,229,249,1,17,158,238,16,155,234,38,97,158,239,18,83,152,129,29,186,166,37,168,49,68,193,220,80,107,16,128,99,8,223,55,137,103,185,33,177,3,238,17,202,12,78,56,119,117,7,132,231,152,186,175,36,237,84,70,178,95,119,65,107,224,90,212,13,109,23,136,176,41,170,66,110,16,223,209,3,226,155,182,239,210,48,212,109,110,13,247,235,114,163,50,143,89,255,254,188,170,233,104,242,26,215,233,116,252,245,233,49,110,222,214,155,241,213,209,26,126,125,168,144,209,228,178,90,120,114,134,155,19,117,242,25,215,59,68,158,189,153,137,20,239,164,225,98,184,201,139,141,233,232,234,180,2,27,218,251,89,132,179,53,60,127,142,155,139,70,243,105,174,85,217,215,102,2,5,125,156,142,191,28,85,84,244,52,115,121,90,51,212,201,248,234,114,49,59,134,30,77,206,27,131,23,11,41,206,21,235,101,165,197,165,188,189,106,88,117,210,166,210,138,118,92,221,149,106,86,188,161,128,90,161,237,129,65,32,244,125,98,27,46,37,156,122,30,241,4,245,185,101,7,150,199,41,62,42,245,83,189,159,117,35,193,226,237,28,10,124,91,85,111,235,203,103,194,181,97,162,186,174,200,50,89,247,210,188,103,55,179,84,50,33,43,59,179,167,41,44,155,121,92,24,132,130,48,137,205,108,32,220,5,27,123,132,6,148,83,14,6,56,232,7,231,169,234,237,221,172,87,136,102,134,149,245,32,253,163,17,249,23,70,223,239,204,179,165,19,101,149,25,241,159,189,255,173,127,168,167,135,218,240,27,200,201,146,155,22,8,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b0de42aa-d0a6-43c9-84cd-9298f4cb6c71"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("12b7121c-ee28-40f6-89c1-935e8b7d7ca7"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("df939b4e-dde0-4d27-824d-3ce613d1a8df"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("70545f3a-7add-45c7-ba78-4585c9bf7ee7"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ba3c18dd-7276-4d59-a388-7dd72332309c"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7569fb84-ca21-4722-9617-c42bd11f787f"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("e88f81f6-bb4f-4667-8712-8244a108432a"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("13f6b58c-3dac-47b1-8c2a-67b10c00b042"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f661c175-85bd-46e2-be1b-f8f2696bed90"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c3e9fc0d-0126-49b4-b41c-42ce78706d8d"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("eb5bda7b-e48e-4c43-a503-e9218b4bf960"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("1a676d4f-b1c2-4fb2-ad01-f5ebd45a6e19"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("b6d720fe-0e34-42a7-8e39-608e8b72fb38"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("89bf6187-da0e-4a92-9f82-dffbe82cc14c"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fc3b7c87-0f42-4827-bc59-66107a5f6680"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a9eeba5-9cd2-4b31-b5da-2bb820239f2a"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f82956d1-db47-4d97-8b70-cc7e3dfd605c"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("45fd680b-c0b8-4b2c-9912-97eb3cdc375e"),
				ContainerUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeFillEmailUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var subjectParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f8d2ec88-506d-4044-908d-a191e3892bb2"),
				ContainerUId = new Guid("873c3cad-514e-4042-977b-50b059400b12"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				Name = @"Subject",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText")
			};
			subjectParameter.SourceValue = new ProcessSchemaParameterValue(subjectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(subjectParameter);
			var bodyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("21eff95f-b71a-4567-861f-65486cfabf8f"),
				ContainerUId = new Guid("873c3cad-514e-4042-977b-50b059400b12"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				Name = @"Body",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			bodyParameter.SourceValue = new ProcessSchemaParameterValue(bodyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(bodyParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("47f64290-f732-4e87-9a44-4cf2485d1240"),
				ContainerUId = new Guid("873c3cad-514e-4042-977b-50b059400b12"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{2182c543-89b6-4709-8a44-0ccc49d8c85a}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var templateIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4f0a1a14-83f4-4436-9927-3286a76c15e2"),
				ContainerUId = new Guid("873c3cad-514e-4042-977b-50b059400b12"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				Name = @"TemplateId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			templateIdParameter.SourceValue = new ProcessSchemaParameterValue(templateIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d30737ec-df8a-4aeb-805c-7bc8649175e6}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(templateIdParameter);
			var sysEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5f5844ae-4b77-4818-8542-1f6474d6e62c"),
				ContainerUId = new Guid("873c3cad-514e-4042-977b-50b059400b12"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				Name = @"SysEntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			sysEntitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(sysEntitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{68684123-fbf5-4c0a-a480-775f630307b9}].[Parameter:{8e42a1ac-c457-45b8-8e4d-7e6e530c82aa}].[EntityColumn:{ed98cf3e-1642-4755-acb2-a61181429306}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(sysEntitySchemaIdParameter);
		}

		protected virtual void InitializeAddActivityDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("78fa348b-febc-4c15-9ab7-8db84e2baf7a"),
				ContainerUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
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
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a251d4b1-48d0-4b81-bd57-227f8c042748"),
				ContainerUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5464c2e0-a7bf-468f-ba2c-a086e8b7cb5b"),
				ContainerUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("8d80b754-2b5d-4731-ada2-68af17a0c8be"),
				ContainerUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eef95653-dcf6-49d4-b0e9-a9f6f4c8b03d"),
				ContainerUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,219,110,27,201,17,253,21,130,187,143,106,162,239,23,189,197,94,7,17,96,103,13,107,179,47,150,31,170,171,171,109,38,20,199,32,71,187,80,4,253,123,206,80,210,250,18,131,178,18,72,177,17,241,65,196,180,250,82,83,93,167,78,213,225,197,252,199,241,252,189,204,15,231,79,94,190,56,30,250,184,120,58,108,100,241,114,51,176,108,183,139,231,3,211,106,249,79,170,43,121,73,27,58,149,81,54,191,210,234,76,182,207,151,219,241,96,246,241,162,249,193,252,199,223,118,255,155,31,190,190,152,31,141,114,250,183,163,134,157,91,46,61,115,208,74,215,18,148,23,41,138,152,154,42,173,6,237,141,175,37,107,44,230,97,117,118,186,126,33,35,189,164,241,221,252,240,98,190,219,13,27,248,198,93,147,51,42,245,150,148,111,149,20,105,237,149,120,227,170,73,193,121,103,230,151,7,243,45,191,147,83,218,29,250,97,49,123,95,90,118,86,145,103,86,190,106,163,106,105,65,101,50,150,189,37,216,86,166,197,215,243,63,44,124,253,195,235,163,237,207,191,175,101,115,188,219,247,176,211,106,43,111,22,24,253,108,224,15,215,28,94,164,174,185,90,152,234,90,35,156,102,113,110,20,82,146,138,45,166,37,145,204,151,111,126,120,51,157,216,150,219,247,43,58,255,245,223,15,62,62,171,127,23,30,175,166,189,255,196,241,31,79,188,56,185,186,189,147,249,225,201,151,239,239,250,251,202,222,79,111,240,211,203,59,153,31,156,204,143,135,179,13,79,187,57,60,252,244,145,117,187,3,118,83,62,123,188,185,45,140,172,207,86,171,235,145,159,104,164,155,137,55,195,67,91,246,165,180,163,245,241,205,37,237,118,209,215,31,245,133,63,55,159,43,219,254,155,101,47,104,77,111,101,243,87,188,254,7,219,255,176,242,23,184,240,102,227,192,228,66,55,90,145,65,160,120,142,73,81,137,164,92,118,141,34,117,226,206,187,213,175,164,203,70,214,44,255,161,97,175,100,187,243,246,4,147,107,187,38,87,93,206,47,47,15,62,6,143,39,202,58,138,85,206,179,85,222,33,236,11,66,90,9,226,169,120,235,216,199,180,23,60,193,23,195,206,245,105,5,192,195,148,21,133,84,84,243,217,104,161,224,57,196,251,0,207,243,97,248,199,217,251,69,10,213,55,87,170,10,161,77,59,180,168,114,131,127,93,247,133,66,110,37,114,90,136,205,206,52,97,5,239,106,213,186,193,49,90,119,120,205,180,168,165,184,204,241,54,204,92,159,247,39,30,151,191,45,199,243,217,4,140,197,179,83,90,174,30,97,244,224,48,170,182,4,157,76,87,73,168,32,229,71,59,221,58,169,98,74,237,46,57,219,187,221,7,163,175,137,154,59,193,200,130,104,108,18,13,0,24,24,4,54,81,37,250,172,52,181,94,19,215,216,91,219,11,163,104,178,164,160,157,202,160,28,229,131,109,138,200,225,177,167,136,220,158,131,171,225,127,201,65,207,86,114,42,235,241,240,34,39,199,110,162,215,96,188,224,77,189,85,37,37,120,82,87,29,138,215,186,26,123,249,41,105,89,35,189,151,208,85,77,184,35,31,144,244,114,196,229,197,224,115,228,78,181,231,126,59,105,253,133,214,109,37,51,184,28,19,70,153,245,97,51,131,133,203,213,236,247,229,248,110,118,74,188,25,182,139,39,67,59,127,4,228,131,3,146,117,215,62,78,4,16,45,64,80,145,102,179,151,160,138,55,165,113,14,38,86,243,160,188,86,27,120,86,123,240,144,171,117,202,16,192,147,105,86,137,225,14,156,229,22,122,223,207,107,182,154,40,45,171,8,130,6,172,53,10,202,156,241,130,149,50,87,84,154,78,202,55,82,20,78,165,131,54,240,22,82,13,156,239,61,202,139,108,73,105,84,131,153,153,125,53,238,118,124,237,184,108,182,149,117,147,205,35,130,30,28,65,173,85,71,70,68,233,36,25,77,8,40,173,38,144,91,211,2,110,152,202,149,218,30,20,65,166,90,19,51,202,57,116,26,160,180,144,12,24,9,137,190,196,106,181,128,174,92,47,123,17,132,78,37,76,84,172,178,70,58,240,134,42,42,67,16,64,166,160,139,241,142,74,174,223,4,165,85,109,209,238,153,164,138,6,106,188,100,188,105,96,212,192,141,145,210,208,63,182,92,63,163,52,0,171,103,211,163,170,213,119,36,189,137,210,146,65,21,98,189,71,105,159,189,179,52,45,121,182,30,81,44,62,221,249,232,240,162,213,110,181,157,234,80,128,84,249,132,2,164,114,247,170,101,9,213,228,232,172,54,183,3,245,149,80,155,241,176,30,137,199,89,67,44,45,254,188,220,108,199,217,18,87,55,27,250,108,35,219,179,213,184,92,191,197,164,213,10,125,222,114,88,63,86,170,95,198,231,255,31,49,58,84,99,160,53,72,28,185,35,114,147,65,165,26,44,43,169,196,129,42,89,52,131,251,213,146,196,16,76,60,2,62,88,228,5,228,39,72,16,157,84,183,192,51,82,3,55,227,190,17,98,180,38,91,14,30,85,116,169,224,240,164,11,14,2,242,244,68,138,176,3,254,167,219,241,246,148,182,50,59,106,143,156,248,221,181,121,198,164,134,73,184,117,155,160,12,66,200,3,248,208,252,27,142,209,152,192,82,184,221,9,60,68,204,130,178,74,85,87,39,78,116,65,213,94,72,69,91,91,113,213,250,222,243,94,240,80,15,148,92,115,10,20,138,248,71,18,80,25,47,163,76,72,48,199,128,91,155,189,71,181,4,130,97,138,132,110,55,25,70,151,89,97,122,149,210,148,75,101,34,59,232,33,182,47,82,143,13,220,238,85,119,17,150,121,244,197,58,102,134,201,220,157,174,174,192,243,95,169,150,188,128,56,136,187,190,18,75,126,62,27,223,14,160,165,71,32,125,119,64,250,154,184,185,19,144,116,100,40,133,232,86,106,234,78,121,170,2,225,3,162,130,37,95,24,98,138,176,236,151,29,57,27,223,9,53,169,104,131,254,206,217,0,209,63,55,188,150,39,91,156,128,132,242,61,2,169,68,35,86,231,136,166,210,226,248,6,130,175,122,250,245,1,242,135,68,84,239,204,122,145,181,203,228,208,61,166,12,243,96,168,1,216,99,152,100,71,232,78,26,70,107,127,87,217,145,33,125,188,29,54,231,143,5,221,119,10,165,175,137,156,187,41,29,149,41,65,118,83,226,12,130,217,129,228,160,92,0,14,53,102,100,113,137,148,246,115,82,214,29,104,129,9,9,58,185,242,57,160,160,11,17,138,168,237,144,62,38,189,67,223,67,159,54,110,240,181,55,244,159,12,195,74,104,61,219,141,44,126,193,252,71,230,120,240,112,47,186,198,0,129,86,233,222,113,191,168,6,208,232,226,231,29,235,17,196,41,81,47,250,70,41,191,183,254,229,205,229,191,0,79,178,46,134,71,30,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d07a51ae-6eef-4fae-8974-16c453d75d56"),
				ContainerUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
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
				UId = new Guid("9dda719d-b4a0-4ac6-9c98-843d7ba7d192"),
				ContainerUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
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

		protected virtual void InitializeReadDataUserTask3Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3c44ff41-7d4f-4045-985d-f5591d95f153"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,211,64,16,253,47,62,119,35,199,159,73,111,16,2,39,32,82,42,78,190,140,215,99,103,85,59,182,118,55,21,161,138,196,63,160,189,34,248,15,168,82,5,66,237,165,17,39,254,5,191,132,89,59,13,169,100,129,169,20,1,226,176,210,250,233,205,248,205,243,243,156,90,60,7,165,158,65,129,214,161,245,112,242,116,90,166,186,247,88,228,26,229,19,89,46,42,235,192,82,40,5,228,226,21,38,13,62,78,132,126,4,26,168,224,52,250,81,31,89,135,81,91,135,200,58,136,44,161,177,80,196,160,130,129,155,58,49,132,125,134,169,227,49,207,118,99,6,49,79,25,122,169,203,125,159,39,224,251,13,179,189,245,168,44,42,144,216,188,161,110,158,214,215,163,101,101,136,125,2,120,77,17,170,156,111,64,215,72,80,227,57,196,57,38,244,172,229,2,9,210,82,20,52,9,30,137,2,39,32,233,77,166,79,105,32,34,165,144,43,195,202,49,213,227,151,149,68,165,68,57,255,185,180,124,81,204,119,185,84,142,219,199,141,24,187,86,104,152,19,208,179,186,65,211,105,85,171,124,144,101,18,51,208,226,100,87,196,49,46,107,102,55,247,168,32,161,47,244,2,242,5,238,248,114,119,146,17,84,186,25,40,178,214,103,95,223,173,207,110,174,214,231,55,111,234,114,41,178,89,199,169,183,206,253,106,112,135,192,234,150,220,169,99,235,36,206,128,192,19,3,212,69,35,80,198,187,149,113,207,229,9,31,160,29,50,143,115,159,121,158,199,89,204,67,159,161,235,38,238,16,29,219,13,251,255,91,182,166,75,53,1,126,12,25,246,186,199,172,155,145,247,136,217,151,79,20,179,15,116,62,211,185,92,159,127,123,253,182,71,183,247,27,244,35,157,139,205,253,154,142,97,95,254,171,129,52,70,231,101,38,56,228,207,43,148,228,117,173,219,110,15,204,157,164,5,102,226,178,212,83,62,195,2,182,122,232,91,54,72,173,227,246,99,133,16,216,161,227,6,44,14,49,101,158,207,61,6,110,24,176,180,239,196,1,122,195,116,24,56,36,136,86,185,81,62,45,23,146,111,34,174,154,29,126,175,237,252,7,254,140,223,91,165,173,137,233,146,129,189,44,156,191,212,174,105,219,118,216,187,115,123,253,51,86,214,234,59,53,162,145,151,215,8,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8f65b044-884b-49ca-9219-5baf24f17958"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5523d04c-3e1b-4f60-9563-9e520dac2c6c"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a8f08199-d9c0-4005-9c94-7c03f7670d2e"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ebd74111-6e32-475d-ab86-716f0976612e"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("573cfd72-52b9-4c1e-a621-58e6e1c6ce39"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("524f3776-d1c5-42c1-a379-e9b3d4ea79d5"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,78,44,40,201,204,207,179,50,180,50,212,241,76,177,50,176,50,0,0,176,27,135,17,18,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("8e42a1ac-c457-45b8-8e4d-7e6e530c82aa"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0e982666-3fc9-4b3d-bf43-1c31a8e6cb53"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ac82296a-e4a2-4f63-8ecf-fc2befdcc54e"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2ce6abdb-47e7-4462-a89a-faa0c73eff6e"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5e71482a-fa3d-496e-aab2-d15119381051"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5af71371-6345-46b7-91d8-531f111fc281"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7ee2a87a-3e6d-4e07-bf35-2fba8030ddcd"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("e505355f-473f-4baf-a0c5-a7acfe566ab9"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("65c22ff4-89c4-41cc-9507-4121365b392c"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("898740ca-c0ac-43d9-bb83-01db84a4e988"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ef68ece7-b557-4e7c-a75c-1655ae2a8984"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("580236c7-16fb-418f-95fc-61d13bf042e6"),
				ContainerUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeReadDataUserTask4Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("01c24e99-0525-4c53-bd4b-2b34f9d3766f"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,203,110,211,64,20,253,21,52,235,186,138,31,121,238,74,9,168,11,104,164,84,221,224,46,38,227,107,103,132,237,177,102,198,133,16,69,130,47,160,97,201,138,79,64,8,164,10,4,139,70,252,8,95,194,157,153,52,164,200,130,128,132,32,210,149,174,79,206,125,206,185,115,194,114,170,212,3,90,0,25,144,219,163,251,99,145,234,253,187,60,215,32,239,73,81,87,100,143,40,144,156,230,252,41,36,14,31,38,92,223,161,154,98,192,60,254,30,31,147,65,220,148,33,38,123,49,225,26,10,133,12,12,232,117,162,118,119,18,118,60,72,130,192,139,252,180,237,245,187,65,207,11,153,223,242,3,58,9,219,189,192,49,155,83,31,138,162,162,18,92,5,155,60,181,238,201,172,50,68,31,1,102,41,92,137,114,13,134,166,5,53,44,233,36,135,4,191,181,172,1,33,45,121,129,147,192,9,47,96,68,37,86,50,121,132,129,144,148,210,92,25,86,14,169,30,62,169,36,40,197,69,249,243,214,242,186,40,183,185,24,14,155,207,117,51,45,219,161,97,142,168,158,218,4,71,216,212,194,246,120,144,101,18,50,170,249,249,118,11,143,96,102,121,187,237,14,3,18,124,159,83,154,215,176,85,243,230,28,135,180,210,110,28,87,30,9,146,103,211,29,39,221,108,235,87,195,6,8,86,215,228,157,50,54,246,31,116,16,60,55,128,203,113,237,198,228,225,145,58,126,92,130,28,179,41,20,212,109,236,108,31,209,31,128,77,254,193,124,2,109,191,21,177,200,235,210,132,121,17,11,125,143,70,180,235,245,251,81,39,100,81,232,227,134,23,103,174,15,174,170,156,206,78,55,229,86,23,87,175,209,62,163,189,67,187,92,45,191,62,123,133,206,123,180,143,171,229,151,151,171,229,213,115,244,63,160,189,65,255,197,45,235,24,96,205,188,68,123,139,246,201,166,49,108,251,7,134,162,6,204,207,60,149,200,56,163,249,113,5,18,165,96,159,162,213,44,225,27,218,55,75,146,66,104,55,250,102,197,7,12,229,196,53,74,104,75,74,88,12,111,219,236,121,44,106,201,214,247,164,220,81,255,209,185,254,131,51,252,157,219,106,84,247,46,122,77,254,7,45,254,109,101,44,200,226,27,157,90,55,49,12,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c7d73d91-0514-42af-999d-7a34d7ec0e95"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("eeb351c9-365d-423c-800b-a2a013bab823"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("71bd15f4-6282-4eae-a7e9-6faa031d959e"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("3f1dbb68-9a58-49b3-a323-5ac45052dfef"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2056ce2f-42d8-4fd2-bf24-61ea6742c3dd"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7f067451-f8bd-4ba8-942d-d6a482207da2"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,77,241,207,179,50,180,50,4,0,252,157,29,132,13,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("95cb3a8c-de47-4ebf-ab83-44e2e6e9b06e"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
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
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a0062d8b-80ae-4931-8d0d-9e40b6beed2a"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e646785e-110f-4438-bc03-5a65ff0404d2"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("45fdb25d-4878-4115-a5db-f8c6a0d63fdb"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6c591f23-80f8-405f-bcf7-acb6c98329e5"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5764dd4b-f9ff-4af0-ad7a-a37ba669478c"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("177a98fd-0f17-4427-86c0-92b3fd286f79"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("8071ca0f-90db-43d4-8161-5e54d91f00ea"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f92969bc-781b-4b37-b423-62af4cbe765b"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,5,193,129,9,0,48,8,3,176,139,10,150,118,120,143,206,249,255,9,75,60,119,163,68,228,78,194,211,133,138,48,158,169,102,30,89,252,2,221,81,196,36,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3bcea3e3-3e90-4842-98a1-348ce8d75cc4"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c90d7462-b6c8-4bda-ad55-cfa805f6475d"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("666c551a-f30d-48ef-82b5-53faef7380ca"),
				ContainerUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			ProcessSchemaUserTask fillemailusertask = CreateFillEmailUserTaskUserTask();
			FlowElements.Add(fillemailusertask);
			ProcessSchemaUserTask addactivitydatausertask = CreateAddActivityDataUserTaskUserTask();
			FlowElements.Add(addactivitydatausertask);
			ProcessSchemaUserTask readdatausertask3 = CreateReadDataUserTask3UserTask();
			FlowElements.Add(readdatausertask3);
			ProcessSchemaScriptTask sendmailscripttask = CreateSendMailScriptTaskScriptTask();
			FlowElements.Add(sendmailscripttask);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask readdatausertask4 = CreateReadDataUserTask4UserTask();
			FlowElements.Add(readdatausertask4);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			ProcessSchemaScriptTask scripttask2 = CreateScriptTask2ScriptTask();
			FlowElements.Add(scripttask2);
			ProcessSchemaExclusiveGateway exclusivegateway3 = CreateExclusiveGateway3ExclusiveGateway();
			FlowElements.Add(exclusivegateway3);
			ProcessSchemaScriptTask scripttask3 = CreateScriptTask3ScriptTask();
			FlowElements.Add(scripttask3);
			ProcessSchemaScriptTask scripttask4 = CreateScriptTask4ScriptTask();
			FlowElements.Add(scripttask4);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow2ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("9ddc1a0b-a466-47d2-82b5-83aa49438994"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7f074929-411d-41a1-9f14-36b4e42641af"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("a2e8ef78-e0cb-4b03-80ee-1ef683b0ed83"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{70ba378d-c705-4902-a786-2c2d4f623c91}].[Parameter:{de51c882-736f-4db7-9a1b-bb605ec75208}].[EntityColumn:{6396f46e-c49f-4fb1-850d-824869ff04b3}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(430, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow2",
				UId = new Guid("35dcb8df-533d-48b8-aa1d-33128db9836d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(438, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("24ec1bfd-0193-4b66-b797-b1118b9a6f2a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(154, 30));
			schemaFlow.PolylinePointPositions.Add(new Point(1186, 30));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("f07aee8e-1621-486d-92b1-1591317f60c2"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{b0200417-902a-4e81-a5c4-edc6274b9d8b}].[Parameter:{e88f81f6-bb4f-4667-8712-8244a108432a}].[EntityColumn:{dbf202ec-c444-479b-bcf4-d8e5b1863201}]#] != string.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(522, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("20333f00-a29d-40bd-b174-f1b74f89bf82"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow3",
				UId = new Guid("598e616a-5180-40f1-a0ab-9f92b088b9bb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(528, 197),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("24ec1bfd-0193-4b66-b797-b1118b9a6f2a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(325, 30));
			schemaFlow.PolylinePointPositions.Add(new Point(1186, 30));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("44c5fa4c-0096-49bc-ad9a-40266638707f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(722, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b2f6e645-ba3c-41d5-8709-1dc94bbb5be1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("b4bd0bb9-d007-42c8-a087-feac9a3ed139"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(628, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("873c3cad-514e-4042-977b-50b059400b12"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("e72d381c-dce6-4ad4-8896-113ee36b7e48"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(722, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b2f6e645-ba3c-41d5-8709-1dc94bbb5be1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("24ec1bfd-0193-4b66-b797-b1118b9a6f2a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1136, 307));
			schemaFlow.PolylinePointPositions.Add(new Point(1136, 306));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("261cef82-4b0a-4d18-8b5b-aa42470fb2fd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("873c3cad-514e-4042-977b-50b059400b12"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1db9fc77-db99-4250-918d-046db047f9a5"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("0c2036ff-eec7-4fed-8a49-c46b3cf449a6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1db9fc77-db99-4250-918d-046db047f9a5"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("5880c05f-f6d8-4064-bb1f-0c7b60536fb5"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{70ba378d-c705-4902-a786-2c2d4f623c91}].[Parameter:{de51c882-736f-4db7-9a1b-bb605ec75208}].[EntityColumn:{a93cb111-ce30-4da4-89ec-d2a2f3dd71c4}]#]==[#Lookup.b17869fe-43f9-487a-af82-b7626f1fc810.7f9e1f1e-f46b-1410-3492-0050ba5d6c38#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1db9fc77-db99-4250-918d-046db047f9a5"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("fb4832f6-f288-41c6-97da-95371a8537c1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("320c19cd-a242-47b6-9d55-21bac6ccbe86"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("917d22fe-13e7-4464-9603-0f46fd69e64b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("320c19cd-a242-47b6-9d55-21bac6ccbe86"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(945, 438));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("b1a5cc59-fab4-481f-bb51-e46500862a56"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c6a037ba-b91a-4d5c-92e1-a7eec4637e82"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("24ec1bfd-0193-4b66-b797-b1118b9a6f2a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1186, 587));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("a20641fa-66ed-435b-b183-c42d20af156f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("20333f00-a29d-40bd-b174-f1b74f89bf82"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ba4d73bb-1240-4a05-8f5f-158635ee29ba"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow2",
				UId = new Guid("9b12ac39-b4ba-4c0c-82b1-cfb780881afa"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d8ed1115-f389-47a1-bee9-8ed2415c428e}]#] || [#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{b65555c6-7f69-41d1-9675-aa4693ee6b54}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ba4d73bb-1240-4a05-8f5f-158635ee29ba"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c6a037ba-b91a-4d5c-92e1-a7eec4637e82"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("f60f98e4-d97c-4371-acf7-9c4a391ebf4b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ba4d73bb-1240-4a05-8f5f-158635ee29ba"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2046ac4f-8c0b-4a3d-b998-d90962403018"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow3",
				UId = new Guid("a74ece8a-b021-4c1b-97e8-0bf72172a17a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f72d3295-d03d-44df-913e-ce128e26f6eb"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow3",
				UId = new Guid("2978ae22-dedc-4a05-ad74-8eea4e29b03f"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{a1ceebce-05dc-410e-a7d4-682eee2c2a92}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f72d3295-d03d-44df-913e-ce128e26f6eb"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7be43985-dcda-49bd-8a77-0caecc01a550"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(531, 128));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("8c158063-a878-4261-bf3a-83c6c3bf8981"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7be43985-dcda-49bd-8a77-0caecc01a550"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("24ec1bfd-0193-4b66-b797-b1118b9a6f2a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1186, 128));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("43051823-ae32-45a6-a439-5b1c2bea4bde"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2046ac4f-8c0b-4a3d-b998-d90962403018"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f72d3295-d03d-44df-913e-ce128e26f6eb"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("dae6eec2-f54b-41ae-aabb-69a51383693f"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("dae6eec2-f54b-41ae-aabb-69a51383693f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("7f074929-411d-41a1-9f14-36b4e42641af"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"Start1",
				Position = new Point(20, 74),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("24ec1bfd-0193-4b66-b797-b1118b9a6f2a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"Terminate1",
				Position = new Point(1173, 293),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ReadDataUserTask1",
				Position = new Point(120, 60),
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
				UId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ReadDataUserTask2",
				Position = new Point(291, 60),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateFillEmailUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("873c3cad-514e-4042-977b-50b059400b12"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"FillEmailUserTask",
				Position = new Point(620, 280),
				SchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeFillEmailUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddActivityDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("157ccf72-d402-417b-8311-0635535d7e00"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"AddActivityDataUserTask",
				Position = new Point(911, 280),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddActivityDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask3UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4dbfae82-70d6-4c31-aacd-fc794e4811aa"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ReadDataUserTask3",
				Position = new Point(620, 420),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask3Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSendMailScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("b2f6e645-ba3c-41d5-8709-1dc94bbb5be1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"SendMailScriptTask",
				Position = new Point(1031, 280),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,77,10,194,48,16,133,247,130,119,8,93,165,32,189,64,85,40,245,135,110,253,57,192,96,6,9,182,9,76,38,149,222,222,137,180,84,168,171,48,243,230,189,239,145,30,72,193,131,109,111,121,104,140,218,169,202,152,106,156,15,192,112,15,72,55,8,175,226,130,15,79,166,49,229,122,213,139,7,59,176,109,221,90,116,124,18,191,167,65,188,117,11,33,140,99,113,70,222,30,23,87,123,237,240,173,106,239,2,83,76,155,138,158,177,19,93,103,81,80,34,56,20,188,119,217,70,37,246,188,200,243,17,61,213,253,134,95,209,25,36,97,167,216,169,248,143,162,151,69,23,193,146,251,39,179,72,143,158,255,38,157,17,114,36,167,164,58,150,31,3,155,136,48,58,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("1db9fc77-db99-4250-918d-046db047f9a5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ExclusiveGateway1",
				Position = new Point(738, 280),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask4UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ReadDataUserTask4",
				Position = new Point(731, 411),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask4Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("320c19cd-a242-47b6-9d55-21bac6ccbe86"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"FormulaTask1",
				Position = new Point(845, 411),
				ResultParameterMetaPath = @"7f0cb231-3dda-4b22-a6ea-e79291d7ee8c",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,221,207,189,106,195,48,20,134,225,91,17,201,98,83,142,145,44,217,82,4,33,67,240,144,41,165,63,83,240,112,36,29,209,130,173,4,199,165,45,38,247,94,181,99,47,33,235,7,47,31,79,113,90,159,14,215,227,103,162,233,217,191,209,136,54,226,112,165,190,202,235,191,161,27,104,164,52,219,69,55,206,71,77,8,24,29,7,85,155,26,92,173,17,130,209,109,99,132,199,214,212,183,28,60,226,132,35,205,52,217,101,211,120,39,209,120,8,164,52,40,114,17,208,25,9,74,81,77,45,109,28,111,233,55,233,210,252,62,127,239,207,195,199,152,236,162,130,143,28,165,0,29,67,174,130,203,151,156,43,32,37,164,19,186,145,74,138,91,191,238,203,234,229,252,122,185,208,84,148,213,33,5,250,58,198,98,245,212,89,182,42,217,118,203,56,219,177,123,96,178,12,250,83,177,135,187,240,252,0,224,102,164,15,124,2,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("ba4d73bb-1240-4a05-8f5f-158635ee29ba"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ExclusiveGateway2",
				Position = new Point(298, 420),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("c6a037ba-b91a-4d5c-92e1-a7eec4637e82"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ScriptTask1",
				Position = new Point(291, 560),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,65,79,132,48,16,133,207,242,43,154,61,177,201,134,195,94,87,189,32,81,18,73,204,46,174,231,145,142,216,88,166,164,29,214,16,227,127,183,32,171,32,171,137,183,50,125,249,222,27,94,15,96,69,97,136,161,224,164,2,165,197,133,216,34,200,43,96,184,119,104,115,112,47,235,104,139,174,209,156,16,43,110,163,107,228,188,173,81,198,70,55,21,237,65,55,120,238,216,42,42,47,195,69,207,88,44,55,193,193,115,177,251,200,177,170,53,48,102,80,88,227,50,32,40,209,122,23,194,87,209,171,31,20,63,79,46,195,206,56,54,68,88,176,50,228,97,234,73,132,169,203,124,6,165,129,202,198,171,246,235,132,224,81,163,92,138,183,224,236,119,167,104,135,36,123,159,220,132,49,56,76,229,74,28,149,221,121,188,188,183,122,23,168,29,118,204,217,6,59,54,22,199,201,39,23,243,212,115,194,237,16,254,6,117,61,253,9,167,21,95,129,79,179,245,32,78,165,71,253,97,212,85,118,156,164,50,252,222,254,8,226,97,242,217,240,79,88,191,94,95,251,48,24,17,86,163,16,29,237,159,69,76,141,163,59,171,42,176,237,232,101,205,251,9,44,114,99,73,176,109,112,243,1,16,134,246,2,190,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask2ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("20333f00-a29d-40bd-b174-f1b74f89bf82"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("10cb6199-40c6-4b6d-9d0e-500310d45f57"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ScriptTask2",
				Position = new Point(291, 280),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,243,44,246,45,205,41,201,244,73,204,75,47,77,76,79,117,205,75,76,202,73,77,81,176,85,8,45,78,45,114,206,207,203,75,77,46,201,204,207,211,115,79,45,241,44,118,75,77,44,41,45,130,41,210,80,114,205,77,204,204,241,77,45,46,6,234,68,49,70,73,211,154,203,19,98,114,14,84,40,204,136,74,102,135,25,129,76,47,74,5,170,206,83,40,41,42,77,181,6,0,79,140,17,95,196,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway3ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("f72d3295-d03d-44df-913e-ce128e26f6eb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ExclusiveGateway3",
				Position = new Point(504, 420),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask3ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("7be43985-dcda-49bd-8a77-0caecc01a550"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ScriptTask3",
				Position = new Point(711, 101),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,140,49,10,194,64,16,69,123,79,49,101,4,217,11,4,27,131,133,197,130,144,72,234,33,249,137,11,201,172,204,206,234,245,179,177,19,172,254,47,222,123,111,86,194,202,97,233,131,61,61,15,26,83,11,25,161,116,38,193,135,46,119,223,198,201,92,19,101,10,115,86,182,16,197,93,127,13,207,194,51,180,122,36,104,1,5,195,78,29,235,195,223,178,219,231,91,168,26,78,184,141,39,234,176,190,22,182,242,139,164,176,172,66,166,25,245,6,13,35,227,24,159,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask4ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2046ac4f-8c0b-4a3d-b998-d90962403018"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("65546fe6-cd1d-49c0-96d8-e09f7c342a01"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				Name = @"ScriptTask4",
				Position = new Point(394, 420),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,142,203,10,194,48,16,69,215,237,87,132,46,74,187,233,15,148,110,12,85,178,16,197,7,174,99,157,212,64,58,209,204,228,255,29,212,133,224,242,190,14,215,208,72,236,23,203,112,241,124,55,83,68,26,209,94,3,220,212,160,154,19,44,143,32,153,17,53,168,213,126,123,140,142,59,29,209,249,57,39,203,62,98,167,45,129,56,196,244,9,146,192,196,223,57,29,34,121,156,15,240,204,64,252,131,42,139,162,174,213,153,32,201,0,97,122,99,54,192,134,214,96,57,39,248,62,104,170,191,111,85,219,246,101,2,41,161,226,148,161,127,1,150,50,212,98,192,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("6a058acc-ee02-4e77-b820-891e6bc0cb95"),
				Name = "BPMSoft.Mail",
				Alias = "",
				CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("be966acc-af84-4226-9b13-0286de9ffd75"),
				Name = "BPMSoft.Mail.Sender",
				Alias = "",
				CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("06bb9208-0bbc-4847-80a8-8bc33de240ad"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3b91697b-7fa9-4a1d-b948-99807c7539c5"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("8394e686-2333-42c9-8ea4-7feddc53fa46")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SendEmailToCaseContactProcessMultiLanguage(userConnection);
		}

		public override object Clone() {
			return new SendEmailToCaseContactProcessMultiLanguageSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"));
		}

		#endregion

	}

	#endregion

	#region Class: SendEmailToCaseContactProcessMultiLanguage

	/// <exclude/>
	public class SendEmailToCaseContactProcessMultiLanguage : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SendEmailToCaseContactProcessMultiLanguage process)
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, SendEmailToCaseContactProcessMultiLanguage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("70ba378d-c705-4902-a786-2c2d4f623c91");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,84,205,142,211,48,16,126,21,148,243,122,149,164,249,113,122,131,82,80,15,176,149,186,218,11,217,195,196,113,90,139,164,137,236,116,161,172,42,33,94,128,114,69,136,39,224,176,72,32,33,36,56,180,71,222,130,39,97,236,180,161,139,42,40,92,216,72,150,198,147,111,102,190,249,243,165,197,114,80,234,33,20,220,234,90,119,134,15,70,101,86,31,223,19,121,205,229,125,89,206,42,235,200,82,92,10,200,197,51,158,54,250,126,42,234,187,80,3,26,92,198,63,237,99,171,27,239,243,16,91,71,177,37,106,94,40,68,160,65,234,132,52,243,82,74,66,55,72,136,23,250,64,32,116,124,18,58,16,216,105,18,241,140,122,13,114,191,235,94,89,84,32,121,19,193,56,207,140,120,58,175,52,208,65,5,51,16,161,202,233,70,217,209,20,84,127,10,73,206,83,188,215,114,198,81,85,75,81,96,38,252,84,20,124,8,18,35,105,63,165,86,33,40,131,92,105,84,206,179,186,255,180,146,92,41,81,78,127,79,45,159,21,211,93,44,154,243,246,186,33,99,27,134,26,57,132,122,98,28,12,144,212,194,112,188,61,30,75,62,134,90,92,236,82,120,204,231,6,119,88,237,208,32,197,254,156,65,62,227,59,49,175,231,209,131,170,110,210,105,194,35,64,138,241,228,192,76,219,106,253,41,89,23,149,213,22,124,144,199,189,252,221,0,149,23,90,209,248,216,138,177,245,104,160,78,158,76,185,28,177,9,47,160,169,216,249,49,106,127,81,180,254,187,151,174,67,93,230,123,29,66,163,36,192,42,218,17,161,224,121,196,102,140,121,81,74,25,245,97,113,222,240,16,170,202,97,126,214,134,91,47,191,189,89,47,87,31,240,124,196,243,101,253,234,251,243,215,40,124,210,194,91,35,44,87,159,241,92,109,255,124,69,225,197,187,91,70,90,174,222,155,219,246,255,85,235,198,120,88,189,52,65,117,59,48,20,141,40,5,219,113,137,227,187,33,241,92,8,8,13,125,78,162,140,187,118,234,166,29,223,71,78,11,253,233,238,150,99,193,32,63,169,184,196,233,49,221,179,247,79,253,181,117,209,117,149,101,89,55,213,106,187,210,3,133,194,206,228,101,52,73,179,180,19,18,198,168,38,131,180,34,59,11,73,144,112,8,162,200,1,230,36,72,6,159,11,221,186,81,57,147,108,179,162,170,121,39,254,233,5,248,15,155,253,55,235,186,119,97,14,89,129,155,50,222,131,155,50,105,11,107,241,3,161,19,125,207,139,6,0,0 })));
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

			public ReadDataUserTask2FlowElement(UserConnection userConnection, SendEmailToCaseContactProcessMultiLanguage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("b0200417-902a-4e81-a5c4-edc6274b9d8b");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,211,64,16,253,43,149,207,221,202,223,246,230,6,37,160,30,160,149,90,113,33,61,236,174,199,169,133,191,100,111,10,33,138,132,184,35,146,30,123,130,19,23,14,128,168,232,7,229,144,168,252,16,126,9,179,182,19,82,20,65,224,2,18,145,86,90,191,125,111,230,205,102,118,6,154,136,89,89,222,99,9,104,45,237,230,206,221,221,44,148,27,183,163,88,66,113,167,200,122,185,182,174,149,80,68,44,142,158,64,80,227,237,32,146,183,152,100,40,24,116,190,235,59,90,171,179,44,66,71,91,239,104,145,132,164,68,6,10,76,135,58,130,83,74,28,198,128,216,186,201,136,31,128,75,66,97,80,97,24,33,11,67,191,102,46,15,189,153,37,57,43,160,206,80,5,15,171,237,94,63,87,68,3,1,81,81,162,50,75,27,208,82,22,202,118,202,120,12,1,126,203,162,7,8,201,34,74,176,18,216,139,18,216,97,5,102,82,113,50,5,33,41,100,113,169,88,49,132,178,253,56,47,160,44,163,44,253,185,181,184,151,164,139,92,148,195,252,179,49,163,87,14,21,115,135,201,131,42,192,22,154,26,86,30,111,116,187,5,116,153,140,14,23,45,60,132,126,197,91,237,238,80,16,224,255,115,159,197,61,88,200,121,189,142,77,150,203,186,156,58,61,18,138,168,123,176,98,165,243,219,250,85,177,38,130,249,140,188,82,196,165,254,77,23,193,67,5,212,49,102,219,142,246,96,171,220,126,148,66,177,43,14,32,97,245,141,237,111,32,250,3,208,142,33,129,84,182,6,158,206,153,229,249,1,17,158,238,16,155,234,38,97,158,239,18,83,152,129,29,186,166,37,168,49,68,193,220,80,107,16,128,99,8,223,55,137,103,185,33,177,3,238,17,202,12,78,56,119,117,7,132,231,152,186,175,36,237,84,70,178,95,119,65,107,224,90,212,13,109,23,136,176,41,170,66,110,16,223,209,3,226,155,182,239,210,48,212,109,110,13,247,235,114,163,50,143,89,255,254,188,170,233,104,242,26,215,233,116,252,245,233,49,110,222,214,155,241,213,209,26,126,125,168,144,209,228,178,90,120,114,134,155,19,117,242,25,215,59,68,158,189,153,137,20,239,164,225,98,184,201,139,141,233,232,234,180,2,27,218,251,89,132,179,53,60,127,142,155,139,70,243,105,174,85,217,215,102,2,5,125,156,142,191,28,85,84,244,52,115,121,90,51,212,201,248,234,114,49,59,134,30,77,206,27,131,23,11,41,206,21,235,101,165,197,165,188,189,106,88,117,210,166,210,138,118,92,221,149,106,86,188,161,128,90,161,237,129,65,32,244,125,98,27,46,37,156,122,30,241,4,245,185,101,7,150,199,41,62,42,245,83,189,159,117,35,193,226,237,28,10,124,91,85,111,235,203,103,194,181,97,162,186,174,200,50,89,247,210,188,103,55,179,84,50,33,43,59,179,167,41,44,155,121,92,24,132,130,48,137,205,108,32,220,5,27,123,132,6,148,83,14,6,56,232,7,231,169,234,237,221,172,87,136,102,134,149,245,32,253,163,17,249,23,70,223,239,204,179,165,19,101,149,25,241,159,189,255,173,127,168,167,135,218,240,27,200,201,146,155,22,8,0,0 })));
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

		#region Class: FillEmailUserTaskFlowElement

		/// <exclude/>
		public class FillEmailUserTaskFlowElement : FillEmailTemplateUserTask
		{

			#region Constructors: Public

			public FillEmailUserTaskFlowElement(UserConnection userConnection, SendEmailToCaseContactProcessMultiLanguage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "FillEmailUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("873c3cad-514e-4042-977b-50b059400b12");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordId = () => (Guid)((process.CaseId));
				_templateId = () => (Guid)((process.TemplateId));
				_sysEntitySchemaId = () => (Guid)(((process.ReadDataUserTask3.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask3.ResultEntity.Schema.Columns.GetByName("UId").ColumnValueName) ? process.ReadDataUserTask3.ResultEntity.GetTypedColumnValue<Guid>("UId") : Guid.Empty)));
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

			internal Func<Guid> _templateId;
			public override Guid TemplateId {
				get {
					return (_templateId ?? (_templateId = () => Guid.Empty)).Invoke();
				}
				set {
					_templateId = () => { return value; };
				}
			}

			internal Func<Guid> _sysEntitySchemaId;
			public override Guid SysEntitySchemaId {
				get {
					return (_sysEntitySchemaId ?? (_sysEntitySchemaId = () => Guid.Empty)).Invoke();
				}
				set {
					_sysEntitySchemaId = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: AddActivityDataUserTaskFlowElement

		/// <exclude/>
		public class AddActivityDataUserTaskFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddActivityDataUserTaskFlowElement(UserConnection userConnection, SendEmailToCaseContactProcessMultiLanguage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddActivityDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("157ccf72-d402-417b-8311-0635535d7e00");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Title = () => new LocalizableString((process.Subject));
				_recordDefValues_Type = () => (Guid)(new Guid("e2831dec-cfc0-df11-b00f-001d60e938c6"));
				_recordDefValues_Body = () => new LocalizableString((process.FillEmailUserTask.Body));
				_recordDefValues_Sender = () => new LocalizableString((process.SenderEmail));
				_recordDefValues_Recepient = () => new LocalizableString(((process.ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? process.ReadDataUserTask2.ResultEntity.GetTypedColumnValue<string>("Email") : null)));
				_recordDefValues_Case = () => (Guid)((process.CaseId));
				_recordDefValues_MessageType = () => (Guid)(new Guid("7f6d3f94-f36b-1410-068c-20cf30b39373"));
				_recordDefValues_ActivityCategory = () => (Guid)(new Guid("8038a396-7825-e011-8165-00155d043204"));
				_recordDefValues_IsHtmlBody = () => (bool)(true);
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Title", () => _recordDefValues_Title.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Type", () => _recordDefValues_Type.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Body", () => _recordDefValues_Body.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Sender", () => _recordDefValues_Sender.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Recepient", () => _recordDefValues_Recepient.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Case", () => _recordDefValues_Case.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_MessageType", () => _recordDefValues_MessageType.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_ActivityCategory", () => _recordDefValues_ActivityCategory.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_IsHtmlBody", () => _recordDefValues_IsHtmlBody.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<string> _recordDefValues_Title;
			internal Func<Guid> _recordDefValues_Type;
			internal Func<string> _recordDefValues_Body;
			internal Func<string> _recordDefValues_Sender;
			internal Func<string> _recordDefValues_Recepient;
			internal Func<Guid> _recordDefValues_Case;
			internal Func<Guid> _recordDefValues_MessageType;
			internal Func<Guid> _recordDefValues_ActivityCategory;
			internal Func<bool> _recordDefValues_IsHtmlBody;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,219,110,27,201,17,253,21,130,187,143,106,162,239,23,189,197,94,7,17,96,103,13,107,179,47,150,31,170,171,171,109,38,20,199,32,71,187,80,4,253,123,206,80,210,250,18,131,178,18,72,177,17,241,65,196,180,250,82,83,93,167,78,213,225,197,252,199,241,252,189,204,15,231,79,94,190,56,30,250,184,120,58,108,100,241,114,51,176,108,183,139,231,3,211,106,249,79,170,43,121,73,27,58,149,81,54,191,210,234,76,182,207,151,219,241,96,246,241,162,249,193,252,199,223,118,255,155,31,190,190,152,31,141,114,250,183,163,134,157,91,46,61,115,208,74,215,18,148,23,41,138,152,154,42,173,6,237,141,175,37,107,44,230,97,117,118,186,126,33,35,189,164,241,221,252,240,98,190,219,13,27,248,198,93,147,51,42,245,150,148,111,149,20,105,237,149,120,227,170,73,193,121,103,230,151,7,243,45,191,147,83,218,29,250,97,49,123,95,90,118,86,145,103,86,190,106,163,106,105,65,101,50,150,189,37,216,86,166,197,215,243,63,44,124,253,195,235,163,237,207,191,175,101,115,188,219,247,176,211,106,43,111,22,24,253,108,224,15,215,28,94,164,174,185,90,152,234,90,35,156,102,113,110,20,82,146,138,45,166,37,145,204,151,111,126,120,51,157,216,150,219,247,43,58,255,245,223,15,62,62,171,127,23,30,175,166,189,255,196,241,31,79,188,56,185,186,189,147,249,225,201,151,239,239,250,251,202,222,79,111,240,211,203,59,153,31,156,204,143,135,179,13,79,187,57,60,252,244,145,117,187,3,118,83,62,123,188,185,45,140,172,207,86,171,235,145,159,104,164,155,137,55,195,67,91,246,165,180,163,245,241,205,37,237,118,209,215,31,245,133,63,55,159,43,219,254,155,101,47,104,77,111,101,243,87,188,254,7,219,255,176,242,23,184,240,102,227,192,228,66,55,90,145,65,160,120,142,73,81,137,164,92,118,141,34,117,226,206,187,213,175,164,203,70,214,44,255,161,97,175,100,187,243,246,4,147,107,187,38,87,93,206,47,47,15,62,6,143,39,202,58,138,85,206,179,85,222,33,236,11,66,90,9,226,169,120,235,216,199,180,23,60,193,23,195,206,245,105,5,192,195,148,21,133,84,84,243,217,104,161,224,57,196,251,0,207,243,97,248,199,217,251,69,10,213,55,87,170,10,161,77,59,180,168,114,131,127,93,247,133,66,110,37,114,90,136,205,206,52,97,5,239,106,213,186,193,49,90,119,120,205,180,168,165,184,204,241,54,204,92,159,247,39,30,151,191,45,199,243,217,4,140,197,179,83,90,174,30,97,244,224,48,170,182,4,157,76,87,73,168,32,229,71,59,221,58,169,98,74,237,46,57,219,187,221,7,163,175,137,154,59,193,200,130,104,108,18,13,0,24,24,4,54,81,37,250,172,52,181,94,19,215,216,91,219,11,163,104,178,164,160,157,202,160,28,229,131,109,138,200,225,177,167,136,220,158,131,171,225,127,201,65,207,86,114,42,235,241,240,34,39,199,110,162,215,96,188,224,77,189,85,37,37,120,82,87,29,138,215,186,26,123,249,41,105,89,35,189,151,208,85,77,184,35,31,144,244,114,196,229,197,224,115,228,78,181,231,126,59,105,253,133,214,109,37,51,184,28,19,70,153,245,97,51,131,133,203,213,236,247,229,248,110,118,74,188,25,182,139,39,67,59,127,4,228,131,3,146,117,215,62,78,4,16,45,64,80,145,102,179,151,160,138,55,165,113,14,38,86,243,160,188,86,27,120,86,123,240,144,171,117,202,16,192,147,105,86,137,225,14,156,229,22,122,223,207,107,182,154,40,45,171,8,130,6,172,53,10,202,156,241,130,149,50,87,84,154,78,202,55,82,20,78,165,131,54,240,22,82,13,156,239,61,202,139,108,73,105,84,131,153,153,125,53,238,118,124,237,184,108,182,149,117,147,205,35,130,30,28,65,173,85,71,70,68,233,36,25,77,8,40,173,38,144,91,211,2,110,152,202,149,218,30,20,65,166,90,19,51,202,57,116,26,160,180,144,12,24,9,137,190,196,106,181,128,174,92,47,123,17,132,78,37,76,84,172,178,70,58,240,134,42,42,67,16,64,166,160,139,241,142,74,174,223,4,165,85,109,209,238,153,164,138,6,106,188,100,188,105,96,212,192,141,145,210,208,63,182,92,63,163,52,0,171,103,211,163,170,213,119,36,189,137,210,146,65,21,98,189,71,105,159,189,179,52,45,121,182,30,81,44,62,221,249,232,240,162,213,110,181,157,234,80,128,84,249,132,2,164,114,247,170,101,9,213,228,232,172,54,183,3,245,149,80,155,241,176,30,137,199,89,67,44,45,254,188,220,108,199,217,18,87,55,27,250,108,35,219,179,213,184,92,191,197,164,213,10,125,222,114,88,63,86,170,95,198,231,255,31,49,58,84,99,160,53,72,28,185,35,114,147,65,165,26,44,43,169,196,129,42,89,52,131,251,213,146,196,16,76,60,2,62,88,228,5,228,39,72,16,157,84,183,192,51,82,3,55,227,190,17,98,180,38,91,14,30,85,116,169,224,240,164,11,14,2,242,244,68,138,176,3,254,167,219,241,246,148,182,50,59,106,143,156,248,221,181,121,198,164,134,73,184,117,155,160,12,66,200,3,248,208,252,27,142,209,152,192,82,184,221,9,60,68,204,130,178,74,85,87,39,78,116,65,213,94,72,69,91,91,113,213,250,222,243,94,240,80,15,148,92,115,10,20,138,248,71,18,80,25,47,163,76,72,48,199,128,91,155,189,71,181,4,130,97,138,132,110,55,25,70,151,89,97,122,149,210,148,75,101,34,59,232,33,182,47,82,143,13,220,238,85,119,17,150,121,244,197,58,102,134,201,220,157,174,174,192,243,95,169,150,188,128,56,136,187,190,18,75,126,62,27,223,14,160,165,71,32,125,119,64,250,154,184,185,19,144,116,100,40,133,232,86,106,234,78,121,170,2,225,3,162,130,37,95,24,98,138,176,236,151,29,57,27,223,9,53,169,104,131,254,206,217,0,209,63,55,188,150,39,91,156,128,132,242,61,2,169,68,35,86,231,136,166,210,226,248,6,130,175,122,250,245,1,242,135,68,84,239,204,122,145,181,203,228,208,61,166,12,243,96,168,1,216,99,152,100,71,232,78,26,70,107,127,87,217,145,33,125,188,29,54,231,143,5,221,119,10,165,175,137,156,187,41,29,149,41,65,118,83,226,12,130,217,129,228,160,92,0,14,53,102,100,113,137,148,246,115,82,214,29,104,129,9,9,58,185,242,57,160,160,11,17,138,168,237,144,62,38,189,67,223,67,159,54,110,240,181,55,244,159,12,195,74,104,61,219,141,44,126,193,252,71,230,120,240,112,47,186,198,0,129,86,233,222,113,191,168,6,208,232,226,231,29,235,17,196,41,81,47,250,70,41,191,183,254,229,205,229,191,0,79,178,46,134,71,30,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "7c391a20e766436b8c18fe98a522ddce",
							"BaseElements.AddActivityDataUserTask.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
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

		#region Class: ReadDataUserTask3FlowElement

		/// <exclude/>
		public class ReadDataUserTask3FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask3FlowElement(UserConnection userConnection, SendEmailToCaseContactProcessMultiLanguage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask3";
				IsLogging = true;
				SchemaElementUId = new Guid("68684123-fbf5-4c0a-a480-775f630307b9");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,211,64,16,253,47,62,119,35,199,159,73,111,16,2,39,32,82,42,78,190,140,215,99,103,85,59,182,118,55,21,161,138,196,63,160,189,34,248,15,168,82,5,66,237,165,17,39,254,5,191,132,89,59,13,169,100,129,169,20,1,226,176,210,250,233,205,248,205,243,243,156,90,60,7,165,158,65,129,214,161,245,112,242,116,90,166,186,247,88,228,26,229,19,89,46,42,235,192,82,40,5,228,226,21,38,13,62,78,132,126,4,26,168,224,52,250,81,31,89,135,81,91,135,200,58,136,44,161,177,80,196,160,130,129,155,58,49,132,125,134,169,227,49,207,118,99,6,49,79,25,122,169,203,125,159,39,224,251,13,179,189,245,168,44,42,144,216,188,161,110,158,214,215,163,101,101,136,125,2,120,77,17,170,156,111,64,215,72,80,227,57,196,57,38,244,172,229,2,9,210,82,20,52,9,30,137,2,39,32,233,77,166,79,105,32,34,165,144,43,195,202,49,213,227,151,149,68,165,68,57,255,185,180,124,81,204,119,185,84,142,219,199,141,24,187,86,104,152,19,208,179,186,65,211,105,85,171,124,144,101,18,51,208,226,100,87,196,49,46,107,102,55,247,168,32,161,47,244,2,242,5,238,248,114,119,146,17,84,186,25,40,178,214,103,95,223,173,207,110,174,214,231,55,111,234,114,41,178,89,199,169,183,206,253,106,112,135,192,234,150,220,169,99,235,36,206,128,192,19,3,212,69,35,80,198,187,149,113,207,229,9,31,160,29,50,143,115,159,121,158,199,89,204,67,159,161,235,38,238,16,29,219,13,251,255,91,182,166,75,53,1,126,12,25,246,186,199,172,155,145,247,136,217,151,79,20,179,15,116,62,211,185,92,159,127,123,253,182,71,183,247,27,244,35,157,139,205,253,154,142,97,95,254,171,129,52,70,231,101,38,56,228,207,43,148,228,117,173,219,110,15,204,157,164,5,102,226,178,212,83,62,195,2,182,122,232,91,54,72,173,227,246,99,133,16,216,161,227,6,44,14,49,101,158,207,61,6,110,24,176,180,239,196,1,122,195,116,24,56,36,136,86,185,81,62,45,23,146,111,34,174,154,29,126,175,237,252,7,254,140,223,91,165,173,137,233,146,129,189,44,156,191,212,174,105,219,118,216,187,115,123,253,51,86,214,234,59,53,162,145,151,215,8,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,78,44,40,201,204,207,179,50,180,50,212,241,76,177,50,176,50,0,0,176,27,135,17,18,0,0,0 })));
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
								new Guid("6c7394db-06ff-4050-91ef-8278e21dce15")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"));
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

		#region Class: ReadDataUserTask4FlowElement

		/// <exclude/>
		public class ReadDataUserTask4FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask4FlowElement(UserConnection userConnection, SendEmailToCaseContactProcessMultiLanguage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask4";
				IsLogging = true;
				SchemaElementUId = new Guid("75bcf7ea-afb0-4282-b27a-d876581ca682");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,203,110,211,64,20,253,21,52,235,186,138,31,121,238,74,9,168,11,104,164,84,221,224,46,38,227,107,103,132,237,177,102,198,133,16,69,130,47,160,97,201,138,79,64,8,164,10,4,139,70,252,8,95,194,157,153,52,164,200,130,128,132,32,210,149,174,79,206,125,206,185,115,194,114,170,212,3,90,0,25,144,219,163,251,99,145,234,253,187,60,215,32,239,73,81,87,100,143,40,144,156,230,252,41,36,14,31,38,92,223,161,154,98,192,60,254,30,31,147,65,220,148,33,38,123,49,225,26,10,133,12,12,232,117,162,118,119,18,118,60,72,130,192,139,252,180,237,245,187,65,207,11,153,223,242,3,58,9,219,189,192,49,155,83,31,138,162,162,18,92,5,155,60,181,238,201,172,50,68,31,1,102,41,92,137,114,13,134,166,5,53,44,233,36,135,4,191,181,172,1,33,45,121,129,147,192,9,47,96,68,37,86,50,121,132,129,144,148,210,92,25,86,14,169,30,62,169,36,40,197,69,249,243,214,242,186,40,183,185,24,14,155,207,117,51,45,219,161,97,142,168,158,218,4,71,216,212,194,246,120,144,101,18,50,170,249,249,118,11,143,96,102,121,187,237,14,3,18,124,159,83,154,215,176,85,243,230,28,135,180,210,110,28,87,30,9,146,103,211,29,39,221,108,235,87,195,6,8,86,215,228,157,50,54,246,31,116,16,60,55,128,203,113,237,198,228,225,145,58,126,92,130,28,179,41,20,212,109,236,108,31,209,31,128,77,254,193,124,2,109,191,21,177,200,235,210,132,121,17,11,125,143,70,180,235,245,251,81,39,100,81,232,227,134,23,103,174,15,174,170,156,206,78,55,229,86,23,87,175,209,62,163,189,67,187,92,45,191,62,123,133,206,123,180,143,171,229,151,151,171,229,213,115,244,63,160,189,65,255,197,45,235,24,96,205,188,68,123,139,246,201,166,49,108,251,7,134,162,6,204,207,60,149,200,56,163,249,113,5,18,165,96,159,162,213,44,225,27,218,55,75,146,66,104,55,250,102,197,7,12,229,196,53,74,104,75,74,88,12,111,219,236,121,44,106,201,214,247,164,220,81,255,209,185,254,131,51,252,157,219,106,84,247,46,122,77,254,7,45,254,109,101,44,200,226,27,157,90,55,49,12,6,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,77,241,207,179,50,180,50,4,0,252,157,29,132,13,0,0,0 })));
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

			private string _entityColumnMetaPathes;
			public override string EntityColumnMetaPathes {
				get {
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,5,193,129,9,0,48,8,3,176,139,10,150,118,120,143,206,249,255,9,75,60,119,163,68,228,78,194,211,133,138,48,158,169,102,30,89,252,2,221,81,196,36,0,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
				}
			}

			#endregion

		}

		#endregion

		public SendEmailToCaseContactProcessMultiLanguage(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SendEmailToCaseContactProcessMultiLanguage";
			SchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_templateId = () => { return (Guid)(new Guid("253cd392-267a-45bb-83b4-17630bcfa37b")); };
			_subject = () => { return new LocalizableString((FillEmailUserTask.Subject)); };
			_parentActivityId = () => { return (Guid)(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("ParentActivity").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("ParentActivityId") : Guid.Empty))); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7c391a20-e766-436b-8c18-fe98a522ddce");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SendEmailToCaseContactProcessMultiLanguage, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SendEmailToCaseContactProcessMultiLanguage, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid CaseId {
			get;
			set;
		}

		private Func<Guid> _templateId;
		public virtual Guid TemplateId {
			get {
				return (_templateId ?? (_templateId = () => Guid.Empty)).Invoke();
			}
			set {
				_templateId = () => { return value; };
			}
		}

		public virtual string SenderEmail {
			get;
			set;
		}

		private Func<string> _subject;
		public virtual string Subject {
			get {
				return (_subject ?? (_subject = () => null)).Invoke();
			}
			set {
				_subject = () => { return value; };
			}
		}

		private Func<Guid> _parentActivityId;
		public virtual Guid ParentActivityId {
			get {
				return (_parentActivityId ?? (_parentActivityId = () => Guid.Empty)).Invoke();
			}
			set {
				_parentActivityId = () => { return value; };
			}
		}

		public virtual bool IsMultiLanguageEnabled {
			get;
			set;
		}

		public virtual bool IsEstimateWithIconsEnabled {
			get;
			set;
		}

		public virtual bool IsMultilanguageV2Enabled {
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
					SchemaElementUId = new Guid("7f074929-411d-41a1-9f14-36b4e42641af"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("24ec1bfd-0193-4b66-b797-b1118b9a6f2a"),
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

		private FillEmailUserTaskFlowElement _fillEmailUserTask;
		public FillEmailUserTaskFlowElement FillEmailUserTask {
			get {
				return _fillEmailUserTask ?? (_fillEmailUserTask = new FillEmailUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddActivityDataUserTaskFlowElement _addActivityDataUserTask;
		public AddActivityDataUserTaskFlowElement AddActivityDataUserTask {
			get {
				return _addActivityDataUserTask ?? (_addActivityDataUserTask = new AddActivityDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataUserTask3FlowElement _readDataUserTask3;
		public ReadDataUserTask3FlowElement ReadDataUserTask3 {
			get {
				return _readDataUserTask3 ?? (_readDataUserTask3 = new ReadDataUserTask3FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _sendMailScriptTask;
		public ProcessScriptTask SendMailScriptTask {
			get {
				return _sendMailScriptTask ?? (_sendMailScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendMailScriptTask",
					SchemaElementUId = new Guid("b2f6e645-ba3c-41d5-8709-1dc94bbb5be1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SendMailScriptTaskExecute,
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
					SchemaElementUId = new Guid("1db9fc77-db99-4250-918d-046db047f9a5"),
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

		private ReadDataUserTask4FlowElement _readDataUserTask4;
		public ReadDataUserTask4FlowElement ReadDataUserTask4 {
			get {
				return _readDataUserTask4 ?? (_readDataUserTask4 = new ReadDataUserTask4FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("320c19cd-a242-47b6-9d55-21bac6ccbe86"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask1Execute,
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
					SchemaElementUId = new Guid("ba4d73bb-1240-4a05-8f5f-158635ee29ba"),
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

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("c6a037ba-b91a-4d5c-92e1-a7eec4637e82"),
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
					SchemaElementUId = new Guid("20333f00-a29d-40bd-b174-f1b74f89bf82"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask2Execute,
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
					SchemaElementUId = new Guid("f72d3295-d03d-44df-913e-ce128e26f6eb"),
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

		private ProcessScriptTask _scriptTask3;
		public ProcessScriptTask ScriptTask3 {
			get {
				return _scriptTask3 ?? (_scriptTask3 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3",
					SchemaElementUId = new Guid("7be43985-dcda-49bd-8a77-0caecc01a550"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask3Execute,
				});
			}
		}

		private ProcessScriptTask _scriptTask4;
		public ProcessScriptTask ScriptTask4 {
			get {
				return _scriptTask4 ?? (_scriptTask4 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask4",
					SchemaElementUId = new Guid("2046ac4f-8c0b-4a3d-b998-d90962403018"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask4Execute,
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
					SchemaElementUId = new Guid("a2e8ef78-e0cb-4b03-80ee-1ef683b0ed83"),
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
					SchemaElementUId = new Guid("f07aee8e-1621-486d-92b1-1591317f60c2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
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
					SchemaElementUId = new Guid("5880c05f-f6d8-4064-bb1f-0c7b60536fb5"),
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
					SchemaElementUId = new Guid("9b12ac39-b4ba-4c0c-82b1-cfb780881afa"),
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
					SchemaElementUId = new Guid("2978ae22-dedc-4a05-ad74-8eea4e29b03f"),
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
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
			FlowElements[FillEmailUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { FillEmailUserTask };
			FlowElements[AddActivityDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AddActivityDataUserTask };
			FlowElements[ReadDataUserTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask3 };
			FlowElements[SendMailScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SendMailScriptTask };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ReadDataUserTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask4 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
			FlowElements[ExclusiveGateway3.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway3 };
			FlowElements[ScriptTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3 };
			FlowElements[ScriptTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask4 };
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
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "FillEmailUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "AddActivityDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendMailScriptTask", e.Context.SenderName));
						break;
					case "ReadDataUserTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FillEmailUserTask", e.Context.SenderName));
						break;
					case "SendMailScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask4", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddActivityDataUserTask", e.Context.SenderName));
						break;
					case "ReadDataUserTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddActivityDataUserTask", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalSequenceFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask4", e.Context.SenderName));
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ScriptTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "ExclusiveGateway3":
						if (ConditionalSequenceFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask3", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask3", e.Context.SenderName));
						break;
					case "ScriptTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ScriptTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway3", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty)) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask1", "ConditionalFlow1", "((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName(\"Contact\").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>(\"ContactId\") : Guid.Empty)) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<string>("Email") : null)) != string.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask2", "ConditionalFlow2", "((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName(\"Email\").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<string>(\"Email\") : null)) != string.Empty", result);
			return result;
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Origin").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("OriginId") : Guid.Empty))==new Guid("7f9e1f1e-f46b-1410-3492-0050ba5d6c38"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow1", "((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName(\"Origin\").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>(\"OriginId\") : Guid.Empty))==new Guid(\"7f9e1f1e-f46b-1410-3492-0050ba5d6c38\")", result);
			return result;
		}

		private bool ConditionalSequenceFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((IsMultiLanguageEnabled) || (IsMultilanguageV2Enabled));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalSequenceFlow2", "(IsMultiLanguageEnabled) || (IsMultilanguageV2Enabled)", result);
			return result;
		}

		private bool ConditionalSequenceFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean((IsEstimateWithIconsEnabled));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway3", "ConditionalSequenceFlow3", "(IsEstimateWithIconsEnabled)", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CaseId")) {
				writer.WriteValue("CaseId", CaseId, Guid.Empty);
			}
			if (!HasMapping("SenderEmail")) {
				writer.WriteValue("SenderEmail", SenderEmail, null);
			}
			if (!HasMapping("IsMultiLanguageEnabled")) {
				writer.WriteValue("IsMultiLanguageEnabled", IsMultiLanguageEnabled, false);
			}
			if (!HasMapping("IsEstimateWithIconsEnabled")) {
				writer.WriteValue("IsEstimateWithIconsEnabled", IsEstimateWithIconsEnabled, false);
			}
			if (!HasMapping("IsMultilanguageV2Enabled")) {
				writer.WriteValue("IsMultilanguageV2Enabled", IsMultilanguageV2Enabled, false);
			}
			if (!HasMapping("TemplateId")) {
				writer.WriteValue("TemplateId", TemplateId, Guid.Empty);
			}
			if (!HasMapping("Subject")) {
				writer.WriteValue("Subject", Subject, null);
			}
			if (!HasMapping("ParentActivityId")) {
				writer.WriteValue("ParentActivityId", ParentActivityId, Guid.Empty);
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
			MetaPathParameterValues.Add("2182c543-89b6-4709-8a44-0ccc49d8c85a", () => CaseId);
			MetaPathParameterValues.Add("d30737ec-df8a-4aeb-805c-7bc8649175e6", () => TemplateId);
			MetaPathParameterValues.Add("3da60100-fb70-4440-a82a-0ee88ccc4b13", () => SenderEmail);
			MetaPathParameterValues.Add("7f0cb231-3dda-4b22-a6ea-e79291d7ee8c", () => Subject);
			MetaPathParameterValues.Add("be5104c4-7adc-4c31-a4a7-99463c431b36", () => ParentActivityId);
			MetaPathParameterValues.Add("d8ed1115-f389-47a1-bee9-8ed2415c428e", () => IsMultiLanguageEnabled);
			MetaPathParameterValues.Add("a1ceebce-05dc-410e-a7d4-682eee2c2a92", () => IsEstimateWithIconsEnabled);
			MetaPathParameterValues.Add("b65555c6-7f69-41d1-9675-aa4693ee6b54", () => IsMultilanguageV2Enabled);
			MetaPathParameterValues.Add("2240c0c2-4f40-423c-8b95-f111c72bbfd9", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("b46a95f8-c76e-49f0-a82f-3277d460a1f6", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("db33b5a6-46aa-47ff-8e4b-5e13fdb80187", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("77acc736-6e4a-4799-8893-f31e6c67dd35", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("576434f3-e5c5-4731-be98-011701f8c85c", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("8aa5b82c-3a24-4b4e-b291-b0353a2dc144", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("0b953ab2-858c-4dd9-9bce-9d641ba01668", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("de51c882-736f-4db7-9a1b-bb605ec75208", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("1a5ebf76-4ad7-4eb7-81fd-71180b9cf610", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("c4106eb8-5ed0-42c8-b84f-34b0294210ca", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("51459f74-5d40-4e53-8ac7-ffca49ce3463", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("76c7a624-b7e2-4ab7-b03b-403b54d5cf2c", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("f5df9dd5-1461-4018-96ef-5e5408602213", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("4e739645-cfcf-4acb-b2c4-d98d6c2154ce", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("8453c16f-b75c-4362-9c4c-34a7a9599cbc", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("dd247f81-c60d-43ef-a529-7e9e698f5f8a", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("d72a4519-9e07-4c3a-ae50-fb5c05a32b5e", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("63abd854-a87d-4589-8a12-384eb55afc80", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("55e9058b-1352-4783-96b1-8527c49bfe42", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("0ec419a6-4bb4-40da-806a-7aff639e25bd", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("b0de42aa-d0a6-43c9-84cd-9298f4cb6c71", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("12b7121c-ee28-40f6-89c1-935e8b7d7ca7", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("df939b4e-dde0-4d27-824d-3ce613d1a8df", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("70545f3a-7add-45c7-ba78-4585c9bf7ee7", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("ba3c18dd-7276-4d59-a388-7dd72332309c", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("7569fb84-ca21-4722-9617-c42bd11f787f", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("e88f81f6-bb4f-4667-8712-8244a108432a", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("13f6b58c-3dac-47b1-8c2a-67b10c00b042", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("f661c175-85bd-46e2-be1b-f8f2696bed90", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("c3e9fc0d-0126-49b4-b41c-42ce78706d8d", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("eb5bda7b-e48e-4c43-a503-e9218b4bf960", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("1a676d4f-b1c2-4fb2-ad01-f5ebd45a6e19", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("b6d720fe-0e34-42a7-8e39-608e8b72fb38", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("89bf6187-da0e-4a92-9f82-dffbe82cc14c", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("fc3b7c87-0f42-4827-bc59-66107a5f6680", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("0a9eeba5-9cd2-4b31-b5da-2bb820239f2a", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("f82956d1-db47-4d97-8b70-cc7e3dfd605c", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("45fd680b-c0b8-4b2c-9912-97eb3cdc375e", () => ReadDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("f8d2ec88-506d-4044-908d-a191e3892bb2", () => FillEmailUserTask.Subject);
			MetaPathParameterValues.Add("21eff95f-b71a-4567-861f-65486cfabf8f", () => FillEmailUserTask.Body);
			MetaPathParameterValues.Add("47f64290-f732-4e87-9a44-4cf2485d1240", () => FillEmailUserTask.RecordId);
			MetaPathParameterValues.Add("4f0a1a14-83f4-4436-9927-3286a76c15e2", () => FillEmailUserTask.TemplateId);
			MetaPathParameterValues.Add("5f5844ae-4b77-4818-8542-1f6474d6e62c", () => FillEmailUserTask.SysEntitySchemaId);
			MetaPathParameterValues.Add("78fa348b-febc-4c15-9ab7-8db84e2baf7a", () => AddActivityDataUserTask.EntitySchemaId);
			MetaPathParameterValues.Add("a251d4b1-48d0-4b81-bd57-227f8c042748", () => AddActivityDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("5464c2e0-a7bf-468f-ba2c-a086e8b7cb5b", () => AddActivityDataUserTask.RecordAddMode);
			MetaPathParameterValues.Add("8d80b754-2b5d-4731-ada2-68af17a0c8be", () => AddActivityDataUserTask.FilterEntitySchemaId);
			MetaPathParameterValues.Add("eef95653-dcf6-49d4-b0e9-a9f6f4c8b03d", () => AddActivityDataUserTask.RecordDefValues);
			MetaPathParameterValues.Add("d07a51ae-6eef-4fae-8974-16c453d75d56", () => AddActivityDataUserTask.RecordId);
			MetaPathParameterValues.Add("9dda719d-b4a0-4ac6-9c98-843d7ba7d192", () => AddActivityDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("3c44ff41-7d4f-4045-985d-f5591d95f153", () => ReadDataUserTask3.DataSourceFilters);
			MetaPathParameterValues.Add("8f65b044-884b-49ca-9219-5baf24f17958", () => ReadDataUserTask3.ResultType);
			MetaPathParameterValues.Add("5523d04c-3e1b-4f60-9563-9e520dac2c6c", () => ReadDataUserTask3.ReadSomeTopRecords);
			MetaPathParameterValues.Add("a8f08199-d9c0-4005-9c94-7c03f7670d2e", () => ReadDataUserTask3.NumberOfRecords);
			MetaPathParameterValues.Add("ebd74111-6e32-475d-ab86-716f0976612e", () => ReadDataUserTask3.FunctionType);
			MetaPathParameterValues.Add("573cfd72-52b9-4c1e-a621-58e6e1c6ce39", () => ReadDataUserTask3.AggregationColumnName);
			MetaPathParameterValues.Add("524f3776-d1c5-42c1-a379-e9b3d4ea79d5", () => ReadDataUserTask3.OrderInfo);
			MetaPathParameterValues.Add("8e42a1ac-c457-45b8-8e4d-7e6e530c82aa", () => ReadDataUserTask3.ResultEntity);
			MetaPathParameterValues.Add("0e982666-3fc9-4b3d-bf43-1c31a8e6cb53", () => ReadDataUserTask3.ResultCount);
			MetaPathParameterValues.Add("ac82296a-e4a2-4f63-8ecf-fc2befdcc54e", () => ReadDataUserTask3.ResultIntegerFunction);
			MetaPathParameterValues.Add("2ce6abdb-47e7-4462-a89a-faa0c73eff6e", () => ReadDataUserTask3.ResultFloatFunction);
			MetaPathParameterValues.Add("5e71482a-fa3d-496e-aab2-d15119381051", () => ReadDataUserTask3.ResultDateTimeFunction);
			MetaPathParameterValues.Add("5af71371-6345-46b7-91d8-531f111fc281", () => ReadDataUserTask3.ResultRowsCount);
			MetaPathParameterValues.Add("7ee2a87a-3e6d-4e07-bf35-2fba8030ddcd", () => ReadDataUserTask3.CanReadUncommitedData);
			MetaPathParameterValues.Add("e505355f-473f-4baf-a0c5-a7acfe566ab9", () => ReadDataUserTask3.ResultEntityCollection);
			MetaPathParameterValues.Add("65c22ff4-89c4-41cc-9507-4121365b392c", () => ReadDataUserTask3.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("898740ca-c0ac-43d9-bb83-01db84a4e988", () => ReadDataUserTask3.IgnoreDisplayValues);
			MetaPathParameterValues.Add("ef68ece7-b557-4e7c-a75c-1655ae2a8984", () => ReadDataUserTask3.ResultCompositeObjectList);
			MetaPathParameterValues.Add("580236c7-16fb-418f-95fc-61d13bf042e6", () => ReadDataUserTask3.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("01c24e99-0525-4c53-bd4b-2b34f9d3766f", () => ReadDataUserTask4.DataSourceFilters);
			MetaPathParameterValues.Add("c7d73d91-0514-42af-999d-7a34d7ec0e95", () => ReadDataUserTask4.ResultType);
			MetaPathParameterValues.Add("eeb351c9-365d-423c-800b-a2a013bab823", () => ReadDataUserTask4.ReadSomeTopRecords);
			MetaPathParameterValues.Add("71bd15f4-6282-4eae-a7e9-6faa031d959e", () => ReadDataUserTask4.NumberOfRecords);
			MetaPathParameterValues.Add("3f1dbb68-9a58-49b3-a323-5ac45052dfef", () => ReadDataUserTask4.FunctionType);
			MetaPathParameterValues.Add("2056ce2f-42d8-4fd2-bf24-61ea6742c3dd", () => ReadDataUserTask4.AggregationColumnName);
			MetaPathParameterValues.Add("7f067451-f8bd-4ba8-942d-d6a482207da2", () => ReadDataUserTask4.OrderInfo);
			MetaPathParameterValues.Add("95cb3a8c-de47-4ebf-ab83-44e2e6e9b06e", () => ReadDataUserTask4.ResultEntity);
			MetaPathParameterValues.Add("a0062d8b-80ae-4931-8d0d-9e40b6beed2a", () => ReadDataUserTask4.ResultCount);
			MetaPathParameterValues.Add("e646785e-110f-4438-bc03-5a65ff0404d2", () => ReadDataUserTask4.ResultIntegerFunction);
			MetaPathParameterValues.Add("45fdb25d-4878-4115-a5db-f8c6a0d63fdb", () => ReadDataUserTask4.ResultFloatFunction);
			MetaPathParameterValues.Add("6c591f23-80f8-405f-bcf7-acb6c98329e5", () => ReadDataUserTask4.ResultDateTimeFunction);
			MetaPathParameterValues.Add("5764dd4b-f9ff-4af0-ad7a-a37ba669478c", () => ReadDataUserTask4.ResultRowsCount);
			MetaPathParameterValues.Add("177a98fd-0f17-4427-86c0-92b3fd286f79", () => ReadDataUserTask4.CanReadUncommitedData);
			MetaPathParameterValues.Add("8071ca0f-90db-43d4-8161-5e54d91f00ea", () => ReadDataUserTask4.ResultEntityCollection);
			MetaPathParameterValues.Add("f92969bc-781b-4b37-b423-62af4cbe765b", () => ReadDataUserTask4.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("3bcea3e3-3e90-4842-98a1-348ce8d75cc4", () => ReadDataUserTask4.IgnoreDisplayValues);
			MetaPathParameterValues.Add("c90d7462-b6c8-4bda-ad55-cfa805f6475d", () => ReadDataUserTask4.ResultCompositeObjectList);
			MetaPathParameterValues.Add("666c551a-f30d-48ef-82b5-53faef7380ca", () => ReadDataUserTask4.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CaseId":
					if (!hasValueToRead) break;
					CaseId = reader.GetValue<System.Guid>();
				break;
				case "SenderEmail":
					if (!hasValueToRead) break;
					SenderEmail = reader.GetValue<System.String>();
				break;
				case "IsMultiLanguageEnabled":
					if (!hasValueToRead) break;
					IsMultiLanguageEnabled = reader.GetValue<System.Boolean>();
				break;
				case "IsEstimateWithIconsEnabled":
					if (!hasValueToRead) break;
					IsEstimateWithIconsEnabled = reader.GetValue<System.Boolean>();
				break;
				case "IsMultilanguageV2Enabled":
					if (!hasValueToRead) break;
					IsMultilanguageV2Enabled = reader.GetValue<System.Boolean>();
				break;
				case "TemplateId":
					if (!hasValueToRead) break;
					TemplateId = reader.GetValue<System.Guid>();
				break;
				case "Subject":
					if (!hasValueToRead) break;
					Subject = reader.GetValue<System.String>();
				break;
				case "ParentActivityId":
					if (!hasValueToRead) break;
					ParentActivityId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SendMailScriptTaskExecute(ProcessExecutingContext context) {
			var activityId = AddActivityDataUserTask.RecordId;
			var emailClientFactory = ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection", UserConnection));
			var activityEmailSender = new ActivityEmailSender(emailClientFactory, UserConnection);
			activityEmailSender.Send(activityId);
			return true;
		}

		public virtual bool FormulaTask1Execute(ProcessExecutingContext context) {
			var localSubject = (((ReadDataUserTask4.ResultEntity.IsColumnValueLoaded(ReadDataUserTask4.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? ReadDataUserTask4.ResultEntity.GetTypedColumnValue<string>("Title") : null))).ToUpper().IndexOf("RE: ") == 0 ? ((ReadDataUserTask4.ResultEntity.IsColumnValueLoaded(ReadDataUserTask4.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? ReadDataUserTask4.ResultEntity.GetTypedColumnValue<string>("Title") : null)) : "RE: " + ((ReadDataUserTask4.ResultEntity.IsColumnValueLoaded(ReadDataUserTask4.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? ReadDataUserTask4.ResultEntity.GetTypedColumnValue<string>("Title") : null));
			Subject = (System.String)localSubject;
			return true;
		}

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			var contactEmail = ReadDataUserTask2.ResultEntity.GetTypedColumnValue<string>("Email");
			var emailTemplateMacrosManager = new EmailWithMacrosManager(UserConnection);
			if (IsMultilanguageV2Enabled) {
				emailTemplateMacrosManager.SendEmailTo(CaseId, TemplateId, contactEmail);
			} else {
				var emailTemplateStore = new EmailTemplateStore(UserConnection);
				var emailTemplateLanguageHelper = new EmailTemplateLanguageHelper(CaseId, UserConnection);
				var languageId = emailTemplateLanguageHelper.GetLanguageId(TemplateId);
				var templateEntity = emailTemplateStore.GetTemplate(TemplateId, languageId);
				emailTemplateMacrosManager.SendEmailTo(CaseId, templateEntity.PrimaryColumnValue, contactEmail);
			}
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			IsMultiLanguageEnabled = UserConnection.GetIsFeatureEnabled("EmailMessageMultiLanguage");
			IsMultilanguageV2Enabled = UserConnection.GetIsFeatureEnabled("EmailMessageMultiLanguageV2");
			return true;
		}

		public virtual bool ScriptTask3Execute(ProcessExecutingContext context) {
			var emailWithMacrosSender = new BPMSoft.Configuration.EmailWithMacrosManager(UserConnection);
			emailWithMacrosSender.SendEmail(CaseId, TemplateId);
			return true;
		}

		public virtual bool ScriptTask4Execute(ProcessExecutingContext context) {
			IsEstimateWithIconsEnabled = (TemplateId == BPMSoft.Configuration.CaseConsts.ConfirmationOfClosingRequestTemplateId 
					&& UserConnection.GetIsFeatureEnabled("EstimateWithIcons"));
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
			var cloneItem = (SendEmailToCaseContactProcessMultiLanguage)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

