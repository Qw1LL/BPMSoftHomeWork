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
	using TConfiguration = BPMSoft.Configuration;

	#region Class: SendNotificationToCaseOwnerSchema

	/// <exclude/>
	public class SendNotificationToCaseOwnerSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SendNotificationToCaseOwnerSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SendNotificationToCaseOwnerSchema(SendNotificationToCaseOwnerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SendNotificationToCaseOwner";
			UId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625");
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.7.0.0";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
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
			RealUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625");
			Version = 0;
			PackageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateActivityIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("917716bf-4d97-4095-a230-624af4a6b429"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCaseOwnerIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("dbd4dbea-e2f6-43a8-9366-14aac293091e"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCaseIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("63e2fd8f-d2d4-4c91-a9a3-3eea91ebb907"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSubjectCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("709f0792-1296-4595-93ee-af64360d8192"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateAssigneeIsClearedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9857231e-99d6-4e24-98f0-e976db21dd58"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#BooleanValue.False#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateActivityIdParameter());
			Parameters.Add(CreateCaseOwnerIdParameter());
			Parameters.Add(CreateCaseIdParameter());
			Parameters.Add(CreateSubjectCaptionParameter());
			Parameters.Add(CreateAssigneeIsClearedParameter());
		}

		protected virtual void InitializeReadCaseDataParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4506bd0f-7d6f-4191-9565-845a21c0d11d"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,143,211,48,16,253,43,40,231,245,202,249,142,123,131,82,80,15,176,149,186,218,203,102,15,142,61,110,45,146,38,178,221,133,82,245,191,51,78,218,210,69,17,20,46,108,14,137,243,244,102,230,205,248,205,62,16,53,183,246,51,111,32,152,4,239,22,159,150,173,114,183,31,116,237,192,124,52,237,182,11,110,2,11,70,243,90,127,7,57,224,51,169,221,123,238,56,6,236,203,159,241,101,48,41,199,50,148,193,77,25,104,7,141,69,6,6,20,34,145,121,150,82,146,164,185,192,87,196,72,5,66,144,44,81,97,148,202,184,200,4,29,152,227,169,167,109,211,113,3,67,133,62,185,234,143,247,187,206,19,67,4,68,79,209,182,221,28,193,216,75,176,179,13,175,106,144,248,239,204,22,16,114,70,55,216,9,220,235,6,22,220,96,37,159,167,245,16,146,20,175,173,103,213,160,220,236,91,103,192,90,221,110,126,47,173,222,54,155,75,46,134,195,249,247,40,134,246,10,61,115,193,221,186,79,48,71,81,135,94,227,219,213,202,192,138,59,253,124,41,225,11,236,122,222,117,179,195,0,137,247,243,192,235,45,92,212,124,217,199,148,119,110,104,103,40,143,4,163,87,235,43,59,61,79,235,79,205,70,8,118,39,242,85,25,71,245,71,25,130,207,30,24,114,156,142,101,240,56,183,119,95,55,96,150,98,13,13,31,38,246,116,139,232,47,192,57,255,100,159,197,16,41,89,40,34,35,153,144,68,176,144,112,198,99,18,3,112,22,66,85,49,154,31,158,6,29,218,118,53,223,61,156,203,77,185,133,55,199,121,249,15,66,76,230,44,167,156,17,42,194,140,36,144,230,164,98,170,34,10,20,165,169,8,83,149,20,120,189,254,241,183,208,174,180,224,245,93,7,6,111,185,159,50,29,119,231,11,91,251,254,77,219,186,161,171,243,244,188,156,94,203,201,33,52,79,152,140,50,32,169,172,114,111,147,130,84,34,146,4,66,170,104,33,24,139,43,133,98,112,173,253,136,151,237,214,136,227,42,217,97,159,255,105,83,255,195,6,254,205,90,141,26,251,26,171,190,22,27,206,95,139,211,14,193,225,7,53,206,173,56,51,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("125091b9-9929-4b16-b593-00f43685f38f"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5abb2c3a-53c2-45f9-a792-dc0d56899ec5"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("69ff34a2-2575-4283-8a79-1849034587f1"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6bda2483-0b9a-4e13-83aa-ef65d8e5fc29"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d0a9c951-282e-4b35-b2b9-586d16c25933"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("cd4e92d5-8ac6-4681-9893-10531933e9f7"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("c0f47d08-77d4-4f35-b9b8-79efd4ecc233"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e3648d82-88fe-4d08-83f0-38a192059287"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("51a965b5-b922-460b-8ded-70db0b0b9559"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("1a36246f-ef97-4371-8e3c-6e2fdff4875d"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e6df8d5b-cab3-4471-b93f-f16dbda2f9a4"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("23e88460-2b78-42f3-bb7d-bc523ec78b23"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("efcb90d5-185b-45d2-b46e-ebdd4f4422c5"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("78164945-a544-4c0f-a423-9e6fcc580552"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3c50e486-1699-49e5-a51a-1bc6cd510ae5"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("876cd4a1-2b3c-48b1-85e5-ea04e0312504"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("05eaf8e8-ed1e-4bb7-9c03-0f23809611da"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("bce20962-1b17-494e-858f-2ea1bea16ce6"),
				ContainerUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("78d57c59-616c-456c-ac2c-9cd77bdbd677"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,19,49,16,253,43,209,158,235,106,63,188,95,185,65,9,168,7,104,69,170,94,154,30,102,237,113,106,177,95,178,189,133,16,229,191,51,222,109,67,138,34,8,92,64,98,79,235,167,55,227,55,111,102,188,13,68,13,214,126,128,6,131,121,240,250,250,253,178,83,238,252,173,174,29,154,119,166,27,250,224,44,176,104,52,212,250,43,202,9,95,72,237,222,128,3,10,216,174,190,199,175,130,249,234,88,134,85,112,182,10,180,195,198,18,131,2,114,144,40,210,18,89,153,21,146,241,92,114,86,100,0,76,149,170,148,33,199,152,167,209,196,60,158,250,162,107,122,48,56,221,48,38,87,227,239,205,166,247,196,136,0,49,82,180,237,218,39,48,241,18,236,162,133,170,70,73,103,103,6,36,200,25,221,80,37,120,163,27,188,6,67,55,249,60,157,135,136,164,160,182,158,85,163,114,139,47,189,65,107,117,215,254,92,90,61,52,237,33,151,194,113,127,124,18,19,142,10,61,243,26,220,195,152,224,146,68,237,70,141,175,214,107,131,107,112,250,241,80,194,39,220,140,188,211,188,163,0,73,253,185,133,122,192,131,59,95,214,113,1,189,155,202,153,174,39,130,209,235,135,19,43,221,187,245,171,98,99,2,251,103,242,73,25,143,234,143,51,2,31,61,48,229,120,254,93,5,119,151,246,234,115,139,102,41,30,176,129,201,177,251,115,66,127,0,22,53,54,216,186,249,86,132,113,6,42,79,89,24,147,125,92,85,200,160,40,75,22,85,121,148,20,128,149,226,229,142,2,246,130,124,136,34,175,195,130,229,222,113,174,146,148,85,101,69,199,18,149,228,40,68,156,36,62,100,209,58,237,54,211,20,204,183,144,71,32,1,129,37,60,163,40,137,200,170,138,43,38,114,72,147,148,167,33,200,124,119,63,149,171,109,95,195,230,118,95,213,71,4,57,19,96,113,230,157,160,117,50,214,205,252,18,205,58,53,35,135,135,218,233,118,61,163,49,170,81,248,62,158,47,29,184,193,142,217,124,59,41,71,20,103,105,21,69,146,101,101,229,135,37,77,88,17,137,138,21,149,72,16,32,146,145,136,105,236,252,231,167,163,91,107,1,245,85,143,134,166,111,236,126,120,124,107,94,172,155,239,139,233,58,55,185,189,239,234,5,73,63,80,244,60,191,42,207,242,136,115,114,92,229,130,113,145,2,73,202,99,38,147,20,32,206,146,48,7,154,223,29,61,58,190,236,101,55,24,241,180,232,118,122,109,254,232,29,249,11,239,195,239,44,253,209,181,59,101,145,254,179,37,185,252,183,198,122,23,236,190,1,88,72,146,81,62,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("86e26d5e-484f-41f0-bbab-fc34eeb9aa75"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e78616d2-d5e4-45ff-b596-cd4077bd95f6"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("15712166-8aff-40a6-aa13-01c7f3e35c6d"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4f55e2a6-ba23-43c6-830c-0c37149c2dfa"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("22a51850-96e2-4f1b-921c-2e8ae641277c"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("bbcdf8e1-e64e-4131-8c66-a7875bc9aa86"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c"),
				UId = new Guid("7f3b2864-d5d3-405d-b781-90d93ae8c182"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3fdbb8ea-a109-436f-9526-5f4981e720df"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9b717c7a-0916-4442-a7e2-1eb5d8444932"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f94eb8f0-f6d7-4e39-bcac-5f524d486d10"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0a8a652e-132a-4a06-ba66-aaf55eb0d4ee"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("02e560cd-10d7-4e56-bd33-2638021393b9"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("b6a76e86-7bda-4867-9d85-33825ffc996a"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9e70bb31-84bd-4894-9154-dc72555d80ee"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ae4b4580-882a-42d6-858b-fc7f1a5ad5ae"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("41083d4f-db04-4676-8683-a5a2eb046ccf"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("8fb309ac-0c35-48a0-856a-2aacf3289d08"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c82e7189-64aa-4140-a271-af01a760eb17"),
				ContainerUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4de1092c-2886-4a3a-b044-6a900b08bad6"),
				ContainerUId = new Guid("ff731486-2289-44bf-807c-51e954d04ed7"),
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0ba9435d-0627-444d-8a1f-ad7297863488"),
				ContainerUId = new Guid("ff731486-2289-44bf-807c-51e954d04ed7"),
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("179d913f-3405-40bc-89fb-a1def3ab9a09"),
				ContainerUId = new Guid("ff731486-2289-44bf-807c-51e954d04ed7"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,203,110,19,49,20,253,149,104,214,117,53,51,246,60,156,29,148,128,186,128,86,20,117,67,186,184,99,223,73,45,230,37,219,41,132,40,255,206,245,76,26,90,20,65,96,3,18,217,100,124,116,206,245,185,47,111,35,213,128,115,239,160,197,104,30,189,188,126,123,211,215,254,252,181,105,60,218,55,182,95,15,209,89,228,208,26,104,204,87,212,19,190,208,198,191,2,15,36,216,46,191,235,151,209,124,121,44,194,50,58,91,70,198,99,235,136,17,4,105,38,53,207,4,211,50,85,76,84,21,103,37,170,156,197,144,40,157,197,192,115,13,123,230,209,208,23,125,59,128,197,233,134,49,120,61,126,126,216,12,129,152,16,160,70,138,113,125,183,7,121,176,224,22,29,84,13,106,58,123,187,70,130,188,53,45,101,130,31,76,139,215,96,233,166,16,167,15,16,145,106,104,92,96,53,88,251,197,151,193,162,115,166,239,126,110,173,89,183,221,83,46,201,241,112,220,155,137,71,135,129,121,13,254,126,12,112,73,166,118,163,199,23,171,149,197,21,120,243,240,212,194,39,220,140,188,211,106,71,2,77,253,185,133,102,141,79,238,124,158,199,5,12,126,74,103,186,158,8,214,172,238,79,204,244,80,173,95,37,155,18,56,60,146,79,138,120,212,127,154,19,248,16,128,41,198,227,231,50,250,120,233,174,62,119,104,111,212,61,182,48,85,236,238,156,208,31,128,69,131,45,118,126,190,85,113,154,67,93,100,44,78,181,96,162,174,144,65,41,37,75,170,34,225,37,96,85,11,185,35,193,193,80,144,212,162,208,113,201,138,98,148,240,140,85,178,162,163,196,90,11,84,42,229,60,72,22,157,55,126,51,77,193,124,11,24,163,200,20,48,37,100,70,42,44,24,112,169,25,135,170,72,139,18,147,60,41,118,119,83,186,198,13,13,108,110,15,89,189,71,208,51,5,14,103,161,18,180,78,214,249,89,88,162,89,95,207,168,194,235,198,155,110,53,163,49,106,80,133,62,158,239,123,24,254,72,159,165,88,228,92,36,76,87,92,210,160,168,132,65,42,75,166,147,82,129,0,9,69,174,104,228,194,47,76,70,191,50,10,154,171,1,45,77,222,216,249,248,248,198,60,91,181,208,19,219,247,126,170,244,161,163,23,100,123,244,114,152,218,26,242,92,103,41,35,87,154,137,178,78,88,165,10,193,164,192,74,115,174,100,22,115,50,67,79,77,72,246,166,95,91,181,95,111,55,189,49,127,244,122,252,133,87,225,119,86,253,232,178,157,178,62,255,217,106,92,254,43,3,189,139,118,223,0,114,46,48,243,46,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a90561e6-7bbd-4a0f-96af-b770af8d44eb"),
				ContainerUId = new Guid("ff731486-2289-44bf-807c-51e954d04ed7"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,203,110,19,49,20,253,149,202,237,50,30,217,227,119,150,180,8,85,106,81,212,64,55,77,23,215,246,53,141,152,100,162,121,32,149,40,255,142,51,77,104,130,74,65,130,13,18,179,152,145,61,247,156,251,56,231,174,201,89,247,184,66,50,38,111,38,215,211,58,117,197,121,221,96,49,105,234,128,109,91,92,213,1,170,249,87,240,21,78,160,129,5,118,216,220,66,213,99,123,53,111,187,209,201,33,136,140,200,217,151,225,31,25,223,173,201,101,135,139,143,151,49,51,151,214,149,18,146,162,150,149,154,202,232,5,5,41,19,149,202,7,101,164,143,2,125,6,135,186,234,23,203,107,236,96,2,221,3,25,175,201,192,150,9,192,112,136,128,64,133,212,50,19,32,82,239,51,65,48,160,132,146,138,65,52,100,51,34,109,120,192,5,12,73,159,193,156,155,40,202,228,168,45,141,202,57,133,164,86,114,78,121,208,154,115,21,208,133,184,5,239,226,159,129,119,167,87,117,253,185,95,21,206,37,161,24,23,84,123,3,84,154,168,169,151,146,81,20,137,3,243,224,28,15,69,98,58,183,225,145,166,24,114,147,206,150,57,141,224,52,218,144,64,149,9,99,72,167,247,219,68,113,222,174,42,120,188,253,105,190,115,104,241,164,237,160,235,219,226,6,235,21,46,49,62,65,87,71,26,28,130,215,179,39,33,103,100,60,123,89,202,221,119,58,204,232,88,204,99,29,103,100,52,35,211,186,111,194,150,77,228,195,197,65,197,67,130,33,228,135,227,94,184,124,179,236,171,106,119,115,1,29,236,3,247,215,117,156,167,57,198,203,229,116,175,215,192,194,118,15,125,225,181,127,158,106,251,19,216,53,44,225,19,54,239,115,251,207,181,127,175,242,67,30,225,158,216,151,78,49,195,19,53,8,142,74,212,89,209,200,129,58,238,124,18,38,123,42,149,3,250,6,19,54,184,12,120,92,216,239,216,102,135,111,135,105,111,55,102,87,215,118,84,27,178,217,140,14,247,136,25,103,19,147,150,26,145,68,118,114,8,20,44,104,170,149,21,40,140,54,202,198,87,247,200,48,93,178,152,103,131,50,47,147,204,221,80,151,237,154,169,76,153,66,180,81,114,255,247,247,232,93,63,143,197,219,197,170,123,124,205,253,199,81,255,141,78,254,29,163,115,237,81,104,197,169,77,88,82,201,85,246,72,140,44,155,147,137,40,181,21,49,138,95,25,253,126,243,13,226,31,176,190,138,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ea7c2443-4cb3-4838-a488-bd01379c5580"),
				ContainerUId = new Guid("ff731486-2289-44bf-807c-51e954d04ed7"),
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

		protected virtual void InitializeChangeDataUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("dc0d8500-2c5d-44ee-8b80-5d1ee9e419af"),
				ContainerUId = new Guid("db5fa60f-1727-44d8-8ec6-131c3f7eeb75"),
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
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("582913d8-566d-458d-b331-4604de9e8c23"),
				ContainerUId = new Guid("db5fa60f-1727-44d8-8ec6-131c3f7eeb75"),
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
				UId = new Guid("db752332-2f10-401f-9ce4-5238cd69c2e9"),
				ContainerUId = new Guid("db5fa60f-1727-44d8-8ec6-131c3f7eeb75"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,143,211,48,16,253,43,85,206,235,42,159,77,211,27,148,130,246,0,91,209,213,94,182,123,152,56,227,212,194,249,144,237,44,148,170,255,157,113,210,150,46,170,160,32,33,14,228,100,63,189,55,243,102,60,147,157,199,21,24,243,1,42,244,102,222,235,229,251,85,35,236,248,173,84,22,245,59,221,116,173,119,227,25,212,18,148,252,138,197,128,47,10,105,223,128,5,18,236,214,223,245,107,111,182,190,20,97,237,221,172,61,105,177,50,196,32,65,34,160,240,131,108,202,2,228,33,139,249,68,176,76,68,33,155,242,34,76,68,18,132,81,234,15,204,203,161,231,77,213,130,198,33,67,31,92,244,199,251,109,235,136,1,1,188,167,72,211,212,7,48,114,22,204,162,134,92,97,65,119,171,59,36,200,106,89,81,37,120,47,43,92,130,166,76,46,78,227,32,34,9,80,198,177,20,10,187,248,210,106,52,70,54,245,207,173,169,174,170,207,185,36,199,211,245,96,198,239,29,58,230,18,236,166,15,112,75,166,246,189,199,87,101,169,177,4,43,159,207,45,124,194,109,207,187,174,119,36,40,232,125,30,64,117,120,150,243,101,29,115,104,237,80,206,144,158,8,90,150,155,43,43,61,117,235,87,197,134,4,182,71,242,85,17,47,250,15,39,4,62,59,96,136,113,60,174,189,199,91,115,247,185,70,189,226,27,172,96,232,216,211,152,208,31,128,133,194,10,107,59,219,113,63,156,128,72,19,230,135,69,204,98,145,35,131,105,150,177,32,79,131,104,10,152,139,56,219,147,224,100,200,73,68,156,22,254,148,165,105,47,137,18,150,103,57,93,51,20,69,140,156,135,81,228,36,139,218,74,187,29,166,96,182,3,244,49,78,56,48,30,103,9,169,48,101,16,101,5,139,32,79,195,116,138,193,36,72,247,79,67,185,210,180,10,182,15,167,170,62,34,20,35,14,6,71,174,19,180,78,218,216,145,91,162,81,35,70,212,225,78,89,89,151,35,26,35,133,220,189,227,184,31,33,247,185,151,110,74,201,65,221,181,168,105,146,250,151,244,47,111,192,139,213,113,61,214,77,99,135,206,157,94,104,78,54,122,151,199,41,164,68,244,91,112,198,86,77,167,249,97,21,205,240,63,248,163,77,255,7,27,252,59,107,121,113,49,174,25,245,255,105,140,247,238,251,75,195,183,247,246,223,0,55,150,62,92,170,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bc1fbcca-fa65-4c95-9a77-ce97f378b282"),
				ContainerUId = new Guid("db5fa60f-1727-44d8-8ec6-131c3f7eeb75"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,111,219,48,12,253,43,133,218,99,104,88,150,108,69,57,182,189,4,72,134,160,217,122,105,122,160,36,106,53,230,216,129,63,6,116,65,254,251,20,199,94,146,161,3,6,84,7,11,162,248,30,159,248,232,61,187,107,223,119,196,102,236,126,181,92,87,190,141,30,170,154,162,85,93,89,106,154,104,81,89,44,242,95,104,10,90,97,141,91,106,169,126,198,162,163,102,145,55,237,228,230,18,196,38,236,238,103,127,199,102,47,123,54,111,105,251,109,238,2,179,51,202,75,25,59,72,124,194,65,10,27,195,84,112,15,90,41,110,19,147,152,204,165,1,108,171,162,219,150,75,106,113,133,237,27,155,237,89,207,22,8,80,113,116,72,8,66,102,18,164,35,2,99,164,7,171,48,21,169,76,99,116,138,29,38,172,177,111,180,197,190,232,25,204,185,114,34,241,26,166,137,74,65,166,66,194,84,114,14,220,102,25,231,169,37,109,221,17,60,228,159,129,47,183,139,170,250,209,237,34,173,189,72,99,46,32,51,10,65,42,151,129,9,239,1,18,158,99,108,80,107,110,35,31,103,130,140,33,240,206,102,32,245,52,9,101,4,7,55,181,30,211,196,147,179,254,246,245,88,200,229,205,174,192,247,231,127,214,123,192,134,110,154,22,219,174,137,158,168,218,81,73,238,4,221,93,121,112,9,222,111,78,70,110,216,108,243,177,149,195,190,238,123,116,109,230,181,143,27,54,217,176,117,213,213,246,200,38,194,225,241,66,113,95,160,79,249,235,56,26,23,34,101,87,20,67,228,17,91,28,19,199,112,229,114,159,147,155,151,235,209,175,158,37,30,22,124,240,25,215,73,219,103,96,75,44,241,59,213,95,194,243,207,218,255,168,252,26,90,56,18,155,68,167,177,10,115,170,8,53,72,202,130,163,142,35,104,174,141,23,42,204,148,79,122,244,19,121,170,169,180,116,45,236,127,198,102,192,55,125,183,143,127,204,160,235,216,170,3,59,28,94,15,191,1,79,207,173,122,161,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("23d07b66-6a7e-4f05-b4e7-f13e098de695"),
				ContainerUId = new Guid("db5fa60f-1727-44d8-8ec6-131c3f7eeb75"),
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
			ProcessSchemaUserTask readcasedata = CreateReadCaseDataUserTask();
			FlowElements.Add(readcasedata);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask changedatausertask1 = CreateChangeDataUserTask1UserTask();
			FlowElements.Add(changedatausertask1);
			ProcessSchemaScriptTask createnotificationscripttask = CreateCreateNotificationScriptTaskScriptTask();
			FlowElements.Add(createnotificationscripttask);
			ProcessSchemaScriptTask setactivityserviceprocessed = CreateSetActivityServiceProcessedScriptTask();
			FlowElements.Add(setactivityserviceprocessed);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			ProcessSchemaUserTask changedatausertask2 = CreateChangeDataUserTask2UserTask();
			FlowElements.Add(changedatausertask2);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaExclusiveGateway exclusivegateway3 = CreateExclusiveGateway3ExclusiveGateway();
			FlowElements.Add(exclusivegateway3);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateConditionalSequenceFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow3ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("707dc0f7-731e-4b42-b6bc-33a3ac14d1d6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0f86f691-728b-4367-98e9-372c14b8eb83"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("e480bdab-02d9-43fb-9d11-3cab3de13d05"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("dea78ebe-598e-4789-8933-7e97ada40c4e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d7cc27a6-e003-48dc-a893-2c2b634e3685"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("164028a5-0e9f-43b5-b440-9f409420a265"),
				ConditionExpression = @"([#[IsOwnerSchema:false].[IsSchema:false].[Element:{9755f7a3-15ff-4623-b0f7-6bd8b05d9682}].[Parameter:{7f3b2864-d5d3-405d-b781-90d93ae8c182}].[EntityColumn:{0a97a9ee-3cf1-4e17-ae9c-b06583f4b46e}]#] || [#[IsOwnerSchema:false].[IsSchema:false].[Element:{9755f7a3-15ff-4623-b0f7-6bd8b05d9682}].[Parameter:{7f3b2864-d5d3-405d-b781-90d93ae8c182}].[EntityColumn:{98771b3f-7dbe-4b12-a017-0ab8d406a02a}]#]) &&  ([#[IsOwnerSchema:false].[IsSchema:false].[Element:{c026af75-02d4-4fbe-a899-1b7138aebf49}].[Parameter:{c0f47d08-77d4-4f35-b9b8-79efd4ecc233}].[EntityColumn:{a71adaea-3464-4dee-bb4f-c7a535450ad7}]#] != [#Lookup.99f35013-6b7a-47d6-b440-e3f1a0ba991c.f063ebbe-fdc6-4982-8431-d8cfa52fedcf#])",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7e40039d-bc2e-48e6-98a8-825e345002f1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow2",
				UId = new Guid("e5b968fe-a1e2-4553-9f9e-2365429b0f48"),
				ConditionExpression = @"([#[IsOwnerSchema:false].[IsSchema:false].[Element:{c026af75-02d4-4fbe-a899-1b7138aebf49}].[Parameter:{c0f47d08-77d4-4f35-b9b8-79efd4ecc233}].[EntityColumn:{70620d00-e4ea-48d1-9fdc-4572fcd8d41b}]#] == Guid.Empty) || ([#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{9857231e-99d6-4e24-98f0-e976db21dd58}]#]==true)",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d7cc27a6-e003-48dc-a893-2c2b634e3685"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f0ec85e6-466f-4c94-a9e7-34f9f0f6a0f2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(687, 84));
			schemaFlow.PolylinePointPositions.Add(new Point(862, 84));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("293d8afc-a4e7-4800-987c-5de2164824aa"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2fbbc7ef-f73b-4ac7-8e1a-1d9b4ccd5702"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f0ec85e6-466f-4c94-a9e7-34f9f0f6a0f2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("a35125c1-02b5-47c1-926b-95f966f6b9ce"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d7cc27a6-e003-48dc-a893-2c2b634e3685"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2fbbc7ef-f73b-4ac7-8e1a-1d9b4ccd5702"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("efc90b80-b772-4205-bf51-315a08b3047a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c7612672-4aa0-4784-991c-5276cb1e1131"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d7cc27a6-e003-48dc-a893-2c2b634e3685"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow3",
				UId = new Guid("1e21d9c0-b54f-47a0-8af2-5c4ae0fa2720"),
				ConditionExpression = @"[#SysSettings.ClearAssigneeOnCaseReopening<Boolean>#]==true",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7e40039d-bc2e-48e6-98a8-825e345002f1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("18b93021-759a-4d94-84cd-74f76d9acc7d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(274, 452));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow3",
				UId = new Guid("8824362b-6385-4a61-a315-c46db2761d09"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7e40039d-bc2e-48e6-98a8-825e345002f1"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("db5fa60f-1727-44d8-8ec6-131c3f7eeb75"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("df870c75-8a1b-4baa-8304-cfb719f11ef8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("db5fa60f-1727-44d8-8ec6-131c3f7eeb75"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3534cd8c-fb72-4ff0-b6a9-ddc3708c723c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(576, 332));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("a301fe1f-8a8c-4bb6-9d8c-06bf6dc5581d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ff731486-2289-44bf-807c-51e954d04ed7"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3534cd8c-fb72-4ff0-b6a9-ddc3708c723c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(576, 452));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("6a9d764d-7daf-46c9-88d3-78c3efb8d84f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("18b93021-759a-4d94-84cd-74f76d9acc7d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ff731486-2289-44bf-807c-51e954d04ed7"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("4149de33-d5f1-4f2f-8636-d849aa44aaaf"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3534cd8c-fb72-4ff0-b6a9-ddc3708c723c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c7612672-4aa0-4784-991c-5276cb1e1131"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("db31b497-0277-4fd6-9e5b-27bc8d92092d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("db31b497-0277-4fd6-9e5b-27bc8d92092d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("0f86f691-728b-4367-98e9-372c14b8eb83"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("f0ec85e6-466f-4c94-a9e7-34f9f0f6a0f2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"Terminate1",
				Position = new Point(849, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadCaseDataUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"ReadCaseData",
				Position = new Point(140, 170),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadCaseDataParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"ReadDataUserTask2",
				Position = new Point(240, 170),
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
				UId = new Guid("d7cc27a6-e003-48dc-a893-2c2b634e3685"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"ExclusiveGateway1",
				Position = new Point(660, 170),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("ff731486-2289-44bf-807c-51e954d04ed7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"ChangeDataUserTask1",
				Position = new Point(460, 425),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateCreateNotificationScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2fbbc7ef-f73b-4ac7-8e1a-1d9b4ccd5702"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"CreateNotificationScriptTask",
				Position = new Point(751, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,85,75,143,218,48,16,62,131,196,127,112,115,74,36,100,245,210,75,183,187,21,4,118,203,97,217,138,71,239,222,100,32,174,18,27,249,193,42,90,241,223,59,182,3,132,85,183,164,123,64,138,61,243,125,158,249,230,193,84,24,110,106,162,160,226,34,231,98,59,13,231,91,178,214,160,82,41,4,100,134,75,65,195,253,50,43,160,98,143,76,176,45,40,250,0,102,38,180,97,34,131,113,61,103,21,196,209,226,200,19,37,131,126,143,166,10,152,129,128,141,47,25,147,155,65,127,207,20,201,152,134,89,142,15,46,128,229,41,30,38,204,48,186,0,109,75,19,128,244,167,226,21,83,117,42,75,91,137,95,172,180,112,67,2,88,190,8,80,87,208,24,229,170,222,65,222,130,127,123,176,60,191,139,163,167,0,143,142,177,8,91,61,131,250,111,54,109,20,102,140,124,115,143,63,209,101,18,165,112,185,34,163,128,23,50,225,62,115,76,165,129,12,137,124,254,141,114,220,145,87,84,203,253,122,209,200,154,66,170,104,248,182,0,169,85,10,132,113,183,20,175,13,203,204,44,71,196,97,232,193,189,168,185,68,100,163,74,219,184,148,86,101,128,182,21,186,109,248,214,42,230,89,79,245,194,107,109,244,249,28,0,33,152,75,170,38,201,97,163,86,219,52,194,80,247,168,18,74,58,36,231,131,115,25,244,15,141,42,152,122,163,199,210,139,48,182,188,204,65,197,78,181,141,196,134,201,10,18,7,93,200,222,233,75,184,56,75,73,189,228,58,241,47,34,21,29,237,118,32,242,216,123,58,138,67,120,165,96,186,192,103,238,121,9,107,195,75,196,130,118,197,123,156,124,249,129,166,120,42,50,233,242,164,107,193,241,11,156,109,92,27,208,177,35,93,201,16,91,156,36,142,243,205,116,208,37,152,9,108,90,45,160,227,119,220,90,62,113,83,90,47,78,151,226,118,161,60,57,159,203,222,5,22,170,235,81,31,107,136,46,143,4,232,138,87,240,239,132,81,249,230,136,227,6,206,31,101,63,54,139,245,141,144,178,93,51,71,97,112,232,189,84,21,51,241,167,230,56,211,115,91,150,79,106,90,237,112,209,44,47,64,237,98,186,46,253,78,222,181,227,86,233,245,190,146,104,142,205,137,123,142,151,184,23,51,224,123,200,241,99,203,148,75,150,152,2,252,210,34,115,73,95,63,31,48,55,135,58,13,67,226,118,211,85,253,47,34,64,138,203,60,219,187,49,172,220,15,47,228,20,41,252,66,186,26,82,173,219,148,190,55,206,239,211,117,199,198,10,121,156,208,221,80,110,34,17,224,102,246,175,238,108,143,45,225,13,198,42,65,140,194,127,128,63,42,221,156,166,185,6,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSetActivityServiceProcessedScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("c7612672-4aa0-4784-991c-5276cb1e1131"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"SetActivityServiceProcessed",
				Position = new Point(653, 365),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,142,177,10,194,48,20,69,103,251,21,143,76,9,148,252,64,113,144,210,161,155,80,138,243,35,185,98,161,77,245,37,169,250,247,86,172,131,56,94,56,151,115,22,22,98,151,134,101,72,207,254,234,57,129,246,20,112,167,207,208,125,132,212,115,8,88,153,57,148,164,14,27,172,76,177,179,29,146,86,29,100,25,28,142,50,59,196,8,175,74,170,231,49,79,193,30,89,120,66,130,232,51,143,17,230,125,57,93,32,208,170,245,202,216,54,54,183,204,163,254,195,191,146,214,27,67,28,183,152,170,248,45,181,205,3,46,175,145,166,42,4,41,75,160,36,25,213,11,109,242,86,202,212,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("7e40039d-bc2e-48e6-98a8-825e345002f1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"ExclusiveGateway2",
				Position = new Point(247, 305),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("db5fa60f-1727-44d8-8ec6-131c3f7eeb75"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"ChangeDataUserTask2",
				Position = new Point(391, 305),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("18b93021-759a-4d94-84cd-74f76d9acc7d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"FormulaTask1",
				Position = new Point(340, 425),
				ResultParameterMetaPath = @"9857231e-99d6-4e24-98f0-e976db21dd58",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,41,42,77,5,0,141,76,252,253,4,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway3ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("3534cd8c-fb72-4ff0-b6a9-ddc3708c723c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("bb8f9711-ecbe-4c20-9d66-6633413c713d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				Name = @"ExclusiveGateway3",
				Position = new Point(549, 365),
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
				UId = new Guid("a62d71a9-1414-4f68-86ab-baff31296a19"),
				Name = "BPMSoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("f119a82c-706c-4b56-bf2d-bb763a00c4e7"),
				Name = "BPMSoft.Core.DB",
				Alias = "",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7c0c3676-9acd-4b48-a524-ac71ec25ed67"),
				Name = "System.Text",
				Alias = "",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2ec255eb-3b3c-4d0a-a3e1-616e3f38ecdf"),
				Name = "BPMSoft.Configuration",
				Alias = "TConfiguration",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SendNotificationToCaseOwner(userConnection);
		}

		public override object Clone() {
			return new SendNotificationToCaseOwnerSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"));
		}

		#endregion

	}

	#endregion

	#region Class: SendNotificationToCaseOwner

	/// <exclude/>
	public class SendNotificationToCaseOwner : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SendNotificationToCaseOwner process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ReadCaseDataFlowElement

		/// <exclude/>
		public class ReadCaseDataFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadCaseDataFlowElement(UserConnection userConnection, SendNotificationToCaseOwner process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadCaseData";
				IsLogging = true;
				SchemaElementUId = new Guid("c026af75-02d4-4fbe-a899-1b7138aebf49");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,143,211,48,16,253,43,40,231,245,202,249,142,123,131,82,80,15,176,149,186,218,203,102,15,142,61,110,45,146,38,178,221,133,82,245,191,51,78,218,210,69,17,20,46,108,14,137,243,244,102,230,205,248,205,62,16,53,183,246,51,111,32,152,4,239,22,159,150,173,114,183,31,116,237,192,124,52,237,182,11,110,2,11,70,243,90,127,7,57,224,51,169,221,123,238,56,6,236,203,159,241,101,48,41,199,50,148,193,77,25,104,7,141,69,6,6,20,34,145,121,150,82,146,164,185,192,87,196,72,5,66,144,44,81,97,148,202,184,200,4,29,152,227,169,167,109,211,113,3,67,133,62,185,234,143,247,187,206,19,67,4,68,79,209,182,221,28,193,216,75,176,179,13,175,106,144,248,239,204,22,16,114,70,55,216,9,220,235,6,22,220,96,37,159,167,245,16,146,20,175,173,103,213,160,220,236,91,103,192,90,221,110,126,47,173,222,54,155,75,46,134,195,249,247,40,134,246,10,61,115,193,221,186,79,48,71,81,135,94,227,219,213,202,192,138,59,253,124,41,225,11,236,122,222,117,179,195,0,137,247,243,192,235,45,92,212,124,217,199,148,119,110,104,103,40,143,4,163,87,235,43,59,61,79,235,79,205,70,8,118,39,242,85,25,71,245,71,25,130,207,30,24,114,156,142,101,240,56,183,119,95,55,96,150,98,13,13,31,38,246,116,139,232,47,192,57,255,100,159,197,16,41,89,40,34,35,153,144,68,176,144,112,198,99,18,3,112,22,66,85,49,154,31,158,6,29,218,118,53,223,61,156,203,77,185,133,55,199,121,249,15,66,76,230,44,167,156,17,42,194,140,36,144,230,164,98,170,34,10,20,165,169,8,83,149,20,120,189,254,241,183,208,174,180,224,245,93,7,6,111,185,159,50,29,119,231,11,91,251,254,77,219,186,161,171,243,244,188,156,94,203,201,33,52,79,152,140,50,32,169,172,114,111,147,130,84,34,146,4,66,170,104,33,24,139,43,133,98,112,173,253,136,151,237,214,136,227,42,217,97,159,255,105,83,255,195,6,254,205,90,141,26,251,26,171,190,22,27,206,95,139,211,14,193,225,7,53,206,173,56,51,6,0,0 })));
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

			public ReadDataUserTask2FlowElement(UserConnection userConnection, SendNotificationToCaseOwner process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("9755f7a3-15ff-4623-b0f7-6bd8b05d9682");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,19,49,16,253,43,209,158,235,106,63,188,95,185,65,9,168,7,104,69,170,94,154,30,102,237,113,106,177,95,178,189,133,16,229,191,51,222,109,67,138,34,8,92,64,98,79,235,167,55,227,55,111,102,188,13,68,13,214,126,128,6,131,121,240,250,250,253,178,83,238,252,173,174,29,154,119,166,27,250,224,44,176,104,52,212,250,43,202,9,95,72,237,222,128,3,10,216,174,190,199,175,130,249,234,88,134,85,112,182,10,180,195,198,18,131,2,114,144,40,210,18,89,153,21,146,241,92,114,86,100,0,76,149,170,148,33,199,152,167,209,196,60,158,250,162,107,122,48,56,221,48,38,87,227,239,205,166,247,196,136,0,49,82,180,237,218,39,48,241,18,236,162,133,170,70,73,103,103,6,36,200,25,221,80,37,120,163,27,188,6,67,55,249,60,157,135,136,164,160,182,158,85,163,114,139,47,189,65,107,117,215,254,92,90,61,52,237,33,151,194,113,127,124,18,19,142,10,61,243,26,220,195,152,224,146,68,237,70,141,175,214,107,131,107,112,250,241,80,194,39,220,140,188,211,188,163,0,73,253,185,133,122,192,131,59,95,214,113,1,189,155,202,153,174,39,130,209,235,135,19,43,221,187,245,171,98,99,2,251,103,242,73,25,143,234,143,51,2,31,61,48,229,120,254,93,5,119,151,246,234,115,139,102,41,30,176,129,201,177,251,115,66,127,0,22,53,54,216,186,249,86,132,113,6,42,79,89,24,147,125,92,85,200,160,40,75,22,85,121,148,20,128,149,226,229,142,2,246,130,124,136,34,175,195,130,229,222,113,174,146,148,85,101,69,199,18,149,228,40,68,156,36,62,100,209,58,237,54,211,20,204,183,144,71,32,1,129,37,60,163,40,137,200,170,138,43,38,114,72,147,148,167,33,200,124,119,63,149,171,109,95,195,230,118,95,213,71,4,57,19,96,113,230,157,160,117,50,214,205,252,18,205,58,53,35,135,135,218,233,118,61,163,49,170,81,248,62,158,47,29,184,193,142,217,124,59,41,71,20,103,105,21,69,146,101,101,229,135,37,77,88,17,137,138,21,149,72,16,32,146,145,136,105,236,252,231,167,163,91,107,1,245,85,143,134,166,111,236,126,120,124,107,94,172,155,239,139,233,58,55,185,189,239,234,5,73,63,80,244,60,191,42,207,242,136,115,114,92,229,130,113,145,2,73,202,99,38,147,20,32,206,146,48,7,154,223,29,61,58,190,236,101,55,24,241,180,232,118,122,109,254,232,29,249,11,239,195,239,44,253,209,181,59,101,145,254,179,37,185,252,183,198,122,23,236,190,1,88,72,146,81,62,7,0,0 })));
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

		#region Class: ChangeDataUserTask1FlowElement

		/// <exclude/>
		public class ChangeDataUserTask1FlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataUserTask1FlowElement(UserConnection userConnection, SendNotificationToCaseOwner process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("ff731486-2289-44bf-807c-51e954d04ed7");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Status = () => (Guid)(new Guid("f063ebbe-fdc6-4982-8431-d8cfa52fedcf"));
				_recordColumnValues_Owner = () => (Guid)(Guid.Empty);
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Status", () => _recordColumnValues_Status.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_Owner", () => _recordColumnValues_Owner.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Status;
			internal Func<Guid> _recordColumnValues_Owner;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,203,110,19,49,20,253,149,104,214,117,53,51,246,60,156,29,148,128,186,128,86,20,117,67,186,184,99,223,73,45,230,37,219,41,132,40,255,206,245,76,26,90,20,65,96,3,18,217,100,124,116,206,245,185,47,111,35,213,128,115,239,160,197,104,30,189,188,126,123,211,215,254,252,181,105,60,218,55,182,95,15,209,89,228,208,26,104,204,87,212,19,190,208,198,191,2,15,36,216,46,191,235,151,209,124,121,44,194,50,58,91,70,198,99,235,136,17,4,105,38,53,207,4,211,50,85,76,84,21,103,37,170,156,197,144,40,157,197,192,115,13,123,230,209,208,23,125,59,128,197,233,134,49,120,61,126,126,216,12,129,152,16,160,70,138,113,125,183,7,121,176,224,22,29,84,13,106,58,123,187,70,130,188,53,45,101,130,31,76,139,215,96,233,166,16,167,15,16,145,106,104,92,96,53,88,251,197,151,193,162,115,166,239,126,110,173,89,183,221,83,46,201,241,112,220,155,137,71,135,129,121,13,254,126,12,112,73,166,118,163,199,23,171,149,197,21,120,243,240,212,194,39,220,140,188,211,106,71,2,77,253,185,133,102,141,79,238,124,158,199,5,12,126,74,103,186,158,8,214,172,238,79,204,244,80,173,95,37,155,18,56,60,146,79,138,120,212,127,154,19,248,16,128,41,198,227,231,50,250,120,233,174,62,119,104,111,212,61,182,48,85,236,238,156,208,31,128,69,131,45,118,126,190,85,113,154,67,93,100,44,78,181,96,162,174,144,65,41,37,75,170,34,225,37,96,85,11,185,35,193,193,80,144,212,162,208,113,201,138,98,148,240,140,85,178,162,163,196,90,11,84,42,229,60,72,22,157,55,126,51,77,193,124,11,24,163,200,20,48,37,100,70,42,44,24,112,169,25,135,170,72,139,18,147,60,41,118,119,83,186,198,13,13,108,110,15,89,189,71,208,51,5,14,103,161,18,180,78,214,249,89,88,162,89,95,207,168,194,235,198,155,110,53,163,49,106,80,133,62,158,239,123,24,254,72,159,165,88,228,92,36,76,87,92,210,160,168,132,65,42,75,166,147,82,129,0,9,69,174,104,228,194,47,76,70,191,50,10,154,171,1,45,77,222,216,249,248,248,198,60,91,181,208,19,219,247,126,170,244,161,163,23,100,123,244,114,152,218,26,242,92,103,41,35,87,154,137,178,78,88,165,10,193,164,192,74,115,174,100,22,115,50,67,79,77,72,246,166,95,91,181,95,111,55,189,49,127,244,122,252,133,87,225,119,86,253,232,178,157,178,62,255,217,106,92,254,43,3,189,139,118,223,0,114,46,48,243,46,7,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,203,110,19,49,20,253,149,202,237,50,30,217,227,119,150,180,8,85,106,81,212,64,55,77,23,215,246,53,141,152,100,162,121,32,149,40,255,142,51,77,104,130,74,65,130,13,18,179,152,145,61,247,156,251,56,231,174,201,89,247,184,66,50,38,111,38,215,211,58,117,197,121,221,96,49,105,234,128,109,91,92,213,1,170,249,87,240,21,78,160,129,5,118,216,220,66,213,99,123,53,111,187,209,201,33,136,140,200,217,151,225,31,25,223,173,201,101,135,139,143,151,49,51,151,214,149,18,146,162,150,149,154,202,232,5,5,41,19,149,202,7,101,164,143,2,125,6,135,186,234,23,203,107,236,96,2,221,3,25,175,201,192,150,9,192,112,136,128,64,133,212,50,19,32,82,239,51,65,48,160,132,146,138,65,52,100,51,34,109,120,192,5,12,73,159,193,156,155,40,202,228,168,45,141,202,57,133,164,86,114,78,121,208,154,115,21,208,133,184,5,239,226,159,129,119,167,87,117,253,185,95,21,206,37,161,24,23,84,123,3,84,154,168,169,151,146,81,20,137,3,243,224,28,15,69,98,58,183,225,145,166,24,114,147,206,150,57,141,224,52,218,144,64,149,9,99,72,167,247,219,68,113,222,174,42,120,188,253,105,190,115,104,241,164,237,160,235,219,226,6,235,21,46,49,62,65,87,71,26,28,130,215,179,39,33,103,100,60,123,89,202,221,119,58,204,232,88,204,99,29,103,100,52,35,211,186,111,194,150,77,228,195,197,65,197,67,130,33,228,135,227,94,184,124,179,236,171,106,119,115,1,29,236,3,247,215,117,156,167,57,198,203,229,116,175,215,192,194,118,15,125,225,181,127,158,106,251,19,216,53,44,225,19,54,239,115,251,207,181,127,175,242,67,30,225,158,216,151,78,49,195,19,53,8,142,74,212,89,209,200,129,58,238,124,18,38,123,42,149,3,250,6,19,54,184,12,120,92,216,239,216,102,135,111,135,105,111,55,102,87,215,118,84,27,178,217,140,14,247,136,25,103,19,147,150,26,145,68,118,114,8,20,44,104,170,149,21,40,140,54,202,198,87,247,200,48,93,178,152,103,131,50,47,147,204,221,80,151,237,154,169,76,153,66,180,81,114,255,247,247,232,93,63,143,197,219,197,170,123,124,205,253,199,81,255,141,78,254,29,163,115,237,81,104,197,169,77,88,82,201,85,246,72,140,44,155,147,137,40,181,21,49,138,95,25,253,126,243,13,226,31,176,190,138,6,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "53d09a3b5a4248cdbd0cf36c9a389625",
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

		#region Class: ChangeDataUserTask2FlowElement

		/// <exclude/>
		public class ChangeDataUserTask2FlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataUserTask2FlowElement(UserConnection userConnection, SendNotificationToCaseOwner process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("db5fa60f-1727-44d8-8ec6-131c3f7eeb75");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Status = () => (Guid)(new Guid("f063ebbe-fdc6-4982-8431-d8cfa52fedcf"));
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

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,143,211,48,16,253,43,85,206,235,42,159,77,211,27,148,130,246,0,91,209,213,94,182,123,152,56,227,212,194,249,144,237,44,148,170,255,157,113,210,150,46,170,160,32,33,14,228,100,63,189,55,243,102,60,147,157,199,21,24,243,1,42,244,102,222,235,229,251,85,35,236,248,173,84,22,245,59,221,116,173,119,227,25,212,18,148,252,138,197,128,47,10,105,223,128,5,18,236,214,223,245,107,111,182,190,20,97,237,221,172,61,105,177,50,196,32,65,34,160,240,131,108,202,2,228,33,139,249,68,176,76,68,33,155,242,34,76,68,18,132,81,234,15,204,203,161,231,77,213,130,198,33,67,31,92,244,199,251,109,235,136,1,1,188,167,72,211,212,7,48,114,22,204,162,134,92,97,65,119,171,59,36,200,106,89,81,37,120,47,43,92,130,166,76,46,78,227,32,34,9,80,198,177,20,10,187,248,210,106,52,70,54,245,207,173,169,174,170,207,185,36,199,211,245,96,198,239,29,58,230,18,236,166,15,112,75,166,246,189,199,87,101,169,177,4,43,159,207,45,124,194,109,207,187,174,119,36,40,232,125,30,64,117,120,150,243,101,29,115,104,237,80,206,144,158,8,90,150,155,43,43,61,117,235,87,197,134,4,182,71,242,85,17,47,250,15,39,4,62,59,96,136,113,60,174,189,199,91,115,247,185,70,189,226,27,172,96,232,216,211,152,208,31,128,133,194,10,107,59,219,113,63,156,128,72,19,230,135,69,204,98,145,35,131,105,150,177,32,79,131,104,10,152,139,56,219,147,224,100,200,73,68,156,22,254,148,165,105,47,137,18,150,103,57,93,51,20,69,140,156,135,81,228,36,139,218,74,187,29,166,96,182,3,244,49,78,56,48,30,103,9,169,48,101,16,101,5,139,32,79,195,116,138,193,36,72,247,79,67,185,210,180,10,182,15,167,170,62,34,20,35,14,6,71,174,19,180,78,218,216,145,91,162,81,35,70,212,225,78,89,89,151,35,26,35,133,220,189,227,184,31,33,247,185,151,110,74,201,65,221,181,168,105,146,250,151,244,47,111,192,139,213,113,61,214,77,99,135,206,157,94,104,78,54,122,151,199,41,164,68,244,91,112,198,86,77,167,249,97,21,205,240,63,248,163,77,255,7,27,252,59,107,121,113,49,174,25,245,255,105,140,247,238,251,75,195,183,247,246,223,0,55,150,62,92,170,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,111,219,48,12,253,43,133,218,99,104,88,150,108,69,57,182,189,4,72,134,160,217,122,105,122,160,36,106,53,230,216,129,63,6,116,65,254,251,20,199,94,146,161,3,6,84,7,11,162,248,30,159,248,232,61,187,107,223,119,196,102,236,126,181,92,87,190,141,30,170,154,162,85,93,89,106,154,104,81,89,44,242,95,104,10,90,97,141,91,106,169,126,198,162,163,102,145,55,237,228,230,18,196,38,236,238,103,127,199,102,47,123,54,111,105,251,109,238,2,179,51,202,75,25,59,72,124,194,65,10,27,195,84,112,15,90,41,110,19,147,152,204,165,1,108,171,162,219,150,75,106,113,133,237,27,155,237,89,207,22,8,80,113,116,72,8,66,102,18,164,35,2,99,164,7,171,48,21,169,76,99,116,138,29,38,172,177,111,180,197,190,232,25,204,185,114,34,241,26,166,137,74,65,166,66,194,84,114,14,220,102,25,231,169,37,109,221,17,60,228,159,129,47,183,139,170,250,209,237,34,173,189,72,99,46,32,51,10,65,42,151,129,9,239,1,18,158,99,108,80,107,110,35,31,103,130,140,33,240,206,102,32,245,52,9,101,4,7,55,181,30,211,196,147,179,254,246,245,88,200,229,205,174,192,247,231,127,214,123,192,134,110,154,22,219,174,137,158,168,218,81,73,238,4,221,93,121,112,9,222,111,78,70,110,216,108,243,177,149,195,190,238,123,116,109,230,181,143,27,54,217,176,117,213,213,246,200,38,194,225,241,66,113,95,160,79,249,235,56,26,23,34,101,87,20,67,228,17,91,28,19,199,112,229,114,159,147,155,151,235,209,175,158,37,30,22,124,240,25,215,73,219,103,96,75,44,241,59,213,95,194,243,207,218,255,168,252,26,90,56,18,155,68,167,177,10,115,170,8,53,72,202,130,163,142,35,104,174,141,23,42,204,148,79,122,244,19,121,170,169,180,116,45,236,127,198,102,192,55,125,183,143,127,204,160,235,216,170,3,59,28,94,15,191,1,79,207,173,122,161,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "53d09a3b5a4248cdbd0cf36c9a389625",
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

		public SendNotificationToCaseOwner(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SendNotificationToCaseOwner";
			SchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_assigneeIsCleared = () => { return (bool)(false); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SendNotificationToCaseOwner, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SendNotificationToCaseOwner, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid CaseOwnerId {
			get;
			set;
		}

		public virtual Guid CaseId {
			get;
			set;
		}

		private LocalizableString _subjectCaption;
		public virtual LocalizableString SubjectCaption {
			get {
				return _subjectCaption ?? (_subjectCaption = GetLocalizableString("53d09a3b5a4248cdbd0cf36c9a389625",
						 "Parameters.SubjectCaption.Value"));
			}
			set {
				_subjectCaption = value;
			}
		}

		private Func<bool> _assigneeIsCleared;
		public virtual bool AssigneeIsCleared {
			get {
				return (_assigneeIsCleared ?? (_assigneeIsCleared = () => false)).Invoke();
			}
			set {
				_assigneeIsCleared = () => { return value; };
			}
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
					SchemaElementUId = new Guid("0f86f691-728b-4367-98e9-372c14b8eb83"),
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
					SchemaElementUId = new Guid("f0ec85e6-466f-4c94-a9e7-34f9f0f6a0f2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ReadCaseDataFlowElement _readCaseData;
		public ReadCaseDataFlowElement ReadCaseData {
			get {
				return _readCaseData ?? (_readCaseData = new ReadCaseDataFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("d7cc27a6-e003-48dc-a893-2c2b634e3685"),
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

		private ChangeDataUserTask1FlowElement _changeDataUserTask1;
		public ChangeDataUserTask1FlowElement ChangeDataUserTask1 {
			get {
				return _changeDataUserTask1 ?? (_changeDataUserTask1 = new ChangeDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _createNotificationScriptTask;
		public ProcessScriptTask CreateNotificationScriptTask {
			get {
				return _createNotificationScriptTask ?? (_createNotificationScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CreateNotificationScriptTask",
					SchemaElementUId = new Guid("2fbbc7ef-f73b-4ac7-8e1a-1d9b4ccd5702"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = CreateNotificationScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _setActivityServiceProcessed;
		public ProcessScriptTask SetActivityServiceProcessed {
			get {
				return _setActivityServiceProcessed ?? (_setActivityServiceProcessed = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetActivityServiceProcessed",
					SchemaElementUId = new Guid("c7612672-4aa0-4784-991c-5276cb1e1131"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SetActivityServiceProcessedExecute,
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
					SchemaElementUId = new Guid("7e40039d-bc2e-48e6-98a8-825e345002f1"),
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

		private ChangeDataUserTask2FlowElement _changeDataUserTask2;
		public ChangeDataUserTask2FlowElement ChangeDataUserTask2 {
			get {
				return _changeDataUserTask2 ?? (_changeDataUserTask2 = new ChangeDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("18b93021-759a-4d94-84cd-74f76d9acc7d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask1Execute,
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
					SchemaElementUId = new Guid("3534cd8c-fb72-4ff0-b6a9-ddc3708c723c"),
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

		private ProcessConditionalFlow _conditionalSequenceFlow1;
		public ProcessConditionalFlow ConditionalSequenceFlow1 {
			get {
				return _conditionalSequenceFlow1 ?? (_conditionalSequenceFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow1",
					SchemaElementUId = new Guid("164028a5-0e9f-43b5-b440-9f409420a265"),
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
					SchemaElementUId = new Guid("e5b968fe-a1e2-4553-9f9e-2365429b0f48"),
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
					SchemaElementUId = new Guid("1e21d9c0-b54f-47a0-8af2-5c4ae0fa2720"),
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
			FlowElements[ReadCaseData.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadCaseData };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ChangeDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask1 };
			FlowElements[CreateNotificationScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateNotificationScriptTask };
			FlowElements[SetActivityServiceProcessed.SchemaElementUId] = new Collection<ProcessFlowElement> { SetActivityServiceProcessed };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[ChangeDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask2 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[ExclusiveGateway3.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway3 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadCaseData", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ReadCaseData":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateNotificationScriptTask", e.Context.SenderName));
						break;
					case "ChangeDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway3", e.Context.SenderName));
						break;
					case "CreateNotificationScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "SetActivityServiceProcessed":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalSequenceFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask2", e.Context.SenderName));
						break;
					case "ChangeDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway3", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask1", e.Context.SenderName));
						break;
					case "ExclusiveGateway3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetActivityServiceProcessed", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("IsPaused").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<bool>("IsPaused") : false)) || ((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("IsResolved").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<bool>("IsResolved") : false))) &&  (((ReadCaseData.ResultEntity.IsColumnValueLoaded(ReadCaseData.ResultEntity.Schema.Columns.GetByName("Status").ColumnValueName) ? ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("StatusId") : Guid.Empty)) != new Guid("f063ebbe-fdc6-4982-8431-d8cfa52fedcf")));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask2", "ConditionalSequenceFlow1", "(((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName(\"IsPaused\").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<bool>(\"IsPaused\") : false)) || ((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName(\"IsResolved\").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<bool>(\"IsResolved\") : false))) &&  (((ReadCaseData.ResultEntity.IsColumnValueLoaded(ReadCaseData.ResultEntity.Schema.Columns.GetByName(\"Status\").ColumnValueName) ? ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>(\"StatusId\") : Guid.Empty)) != new Guid(\"f063ebbe-fdc6-4982-8431-d8cfa52fedcf\"))", result);
			return result;
		}

		private bool ConditionalSequenceFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((((ReadCaseData.ResultEntity.IsColumnValueLoaded(ReadCaseData.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)) == Guid.Empty) || ((AssigneeIsCleared)==true));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow2", "(((ReadCaseData.ResultEntity.IsColumnValueLoaded(ReadCaseData.ResultEntity.Schema.Columns.GetByName(\"Owner\").ColumnValueName) ? ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>(\"OwnerId\") : Guid.Empty)) == Guid.Empty) || ((AssigneeIsCleared)==true)", result);
			return result;
		}

		private bool ConditionalSequenceFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean(((Boolean)SysSettings.GetValue(UserConnection, "ClearAssigneeOnCaseReopening"))==true);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalSequenceFlow3", "((Boolean)SysSettings.GetValue(UserConnection, \"ClearAssigneeOnCaseReopening\"))==true", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("ActivityId")) {
				writer.WriteValue("ActivityId", ActivityId, Guid.Empty);
			}
			if (!HasMapping("CaseOwnerId")) {
				writer.WriteValue("CaseOwnerId", CaseOwnerId, Guid.Empty);
			}
			if (!HasMapping("CaseId")) {
				writer.WriteValue("CaseId", CaseId, Guid.Empty);
			}
			if (!HasMapping("AssigneeIsCleared")) {
				writer.WriteValue("AssigneeIsCleared", AssigneeIsCleared, false);
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
			MetaPathParameterValues.Add("917716bf-4d97-4095-a230-624af4a6b429", () => ActivityId);
			MetaPathParameterValues.Add("dbd4dbea-e2f6-43a8-9366-14aac293091e", () => CaseOwnerId);
			MetaPathParameterValues.Add("63e2fd8f-d2d4-4c91-a9a3-3eea91ebb907", () => CaseId);
			MetaPathParameterValues.Add("709f0792-1296-4595-93ee-af64360d8192", () => SubjectCaption);
			MetaPathParameterValues.Add("9857231e-99d6-4e24-98f0-e976db21dd58", () => AssigneeIsCleared);
			MetaPathParameterValues.Add("4506bd0f-7d6f-4191-9565-845a21c0d11d", () => ReadCaseData.DataSourceFilters);
			MetaPathParameterValues.Add("125091b9-9929-4b16-b593-00f43685f38f", () => ReadCaseData.ResultType);
			MetaPathParameterValues.Add("5abb2c3a-53c2-45f9-a792-dc0d56899ec5", () => ReadCaseData.ReadSomeTopRecords);
			MetaPathParameterValues.Add("69ff34a2-2575-4283-8a79-1849034587f1", () => ReadCaseData.NumberOfRecords);
			MetaPathParameterValues.Add("6bda2483-0b9a-4e13-83aa-ef65d8e5fc29", () => ReadCaseData.FunctionType);
			MetaPathParameterValues.Add("d0a9c951-282e-4b35-b2b9-586d16c25933", () => ReadCaseData.AggregationColumnName);
			MetaPathParameterValues.Add("cd4e92d5-8ac6-4681-9893-10531933e9f7", () => ReadCaseData.OrderInfo);
			MetaPathParameterValues.Add("c0f47d08-77d4-4f35-b9b8-79efd4ecc233", () => ReadCaseData.ResultEntity);
			MetaPathParameterValues.Add("e3648d82-88fe-4d08-83f0-38a192059287", () => ReadCaseData.ResultCount);
			MetaPathParameterValues.Add("51a965b5-b922-460b-8ded-70db0b0b9559", () => ReadCaseData.ResultIntegerFunction);
			MetaPathParameterValues.Add("1a36246f-ef97-4371-8e3c-6e2fdff4875d", () => ReadCaseData.ResultFloatFunction);
			MetaPathParameterValues.Add("e6df8d5b-cab3-4471-b93f-f16dbda2f9a4", () => ReadCaseData.ResultDateTimeFunction);
			MetaPathParameterValues.Add("23e88460-2b78-42f3-bb7d-bc523ec78b23", () => ReadCaseData.ResultRowsCount);
			MetaPathParameterValues.Add("efcb90d5-185b-45d2-b46e-ebdd4f4422c5", () => ReadCaseData.CanReadUncommitedData);
			MetaPathParameterValues.Add("78164945-a544-4c0f-a423-9e6fcc580552", () => ReadCaseData.ResultEntityCollection);
			MetaPathParameterValues.Add("3c50e486-1699-49e5-a51a-1bc6cd510ae5", () => ReadCaseData.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("876cd4a1-2b3c-48b1-85e5-ea04e0312504", () => ReadCaseData.IgnoreDisplayValues);
			MetaPathParameterValues.Add("05eaf8e8-ed1e-4bb7-9c03-0f23809611da", () => ReadCaseData.ResultCompositeObjectList);
			MetaPathParameterValues.Add("bce20962-1b17-494e-858f-2ea1bea16ce6", () => ReadCaseData.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("78d57c59-616c-456c-ac2c-9cd77bdbd677", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("86e26d5e-484f-41f0-bbab-fc34eeb9aa75", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("e78616d2-d5e4-45ff-b596-cd4077bd95f6", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("15712166-8aff-40a6-aa13-01c7f3e35c6d", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("4f55e2a6-ba23-43c6-830c-0c37149c2dfa", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("22a51850-96e2-4f1b-921c-2e8ae641277c", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("bbcdf8e1-e64e-4131-8c66-a7875bc9aa86", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("7f3b2864-d5d3-405d-b781-90d93ae8c182", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("3fdbb8ea-a109-436f-9526-5f4981e720df", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("9b717c7a-0916-4442-a7e2-1eb5d8444932", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("f94eb8f0-f6d7-4e39-bcac-5f524d486d10", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("0a8a652e-132a-4a06-ba66-aaf55eb0d4ee", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("02e560cd-10d7-4e56-bd33-2638021393b9", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("b6a76e86-7bda-4867-9d85-33825ffc996a", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("9e70bb31-84bd-4894-9154-dc72555d80ee", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("ae4b4580-882a-42d6-858b-fc7f1a5ad5ae", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("41083d4f-db04-4676-8683-a5a2eb046ccf", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("8fb309ac-0c35-48a0-856a-2aacf3289d08", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("c82e7189-64aa-4140-a271-af01a760eb17", () => ReadDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("4de1092c-2886-4a3a-b044-6a900b08bad6", () => ChangeDataUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("0ba9435d-0627-444d-8a1f-ad7297863488", () => ChangeDataUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("179d913f-3405-40bc-89fb-a1def3ab9a09", () => ChangeDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("a90561e6-7bbd-4a0f-96af-b770af8d44eb", () => ChangeDataUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("ea7c2443-4cb3-4838-a488-bd01379c5580", () => ChangeDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("dc0d8500-2c5d-44ee-8b80-5d1ee9e419af", () => ChangeDataUserTask2.EntitySchemaUId);
			MetaPathParameterValues.Add("582913d8-566d-458d-b331-4604de9e8c23", () => ChangeDataUserTask2.IsMatchConditions);
			MetaPathParameterValues.Add("db752332-2f10-401f-9ce4-5238cd69c2e9", () => ChangeDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("bc1fbcca-fa65-4c95-9a77-ce97f378b282", () => ChangeDataUserTask2.RecordColumnValues);
			MetaPathParameterValues.Add("23d07b66-6a7e-4f05-b4e7-f13e098de695", () => ChangeDataUserTask2.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "ActivityId":
					if (!hasValueToRead) break;
					ActivityId = reader.GetValue<System.Guid>();
				break;
				case "CaseOwnerId":
					if (!hasValueToRead) break;
					CaseOwnerId = reader.GetValue<System.Guid>();
				break;
				case "CaseId":
					if (!hasValueToRead) break;
					CaseId = reader.GetValue<System.Guid>();
				break;
				case "AssigneeIsCleared":
					if (!hasValueToRead) break;
					AssigneeIsCleared = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool CreateNotificationScriptTaskExecute(ProcessExecutingContext context) {
			Entity remindingEntity = UserConnection.EntitySchemaManager.GetInstanceByName("Reminding")
				.CreateEntity(UserConnection);
			var caseId = ReadCaseData.ResultEntity.PrimaryColumnValue; 
			var ownerId = ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("OwnerId");
			var number = ReadCaseData.ResultEntity.GetTypedColumnValue<string>("Number");
			var condition = new Dictionary<string, object> {
				{
					"Author", UserConnection.CurrentUser.ContactId
				}, {
					"Contact", ownerId
				}, {
					"Source", TConfiguration.RemindingConsts.RemindingSourceAuthorId
				}, {
					"Number", number
				}, {
					"ActivityId", ActivityId
				}
			};
			var str = new StringBuilder();
			foreach (object value in condition.Values) {
				str.Append(value);
			}
			var hash = FileUtilities.GetMD5Hash(Encoding.Unicode.GetBytes(str.ToString()));
			remindingEntity.SetDefColumnValues();
			remindingEntity.SetColumnValue("AuthorId", UserConnection.CurrentUser.ContactId);
			remindingEntity.SetColumnValue("ContactId", ownerId);
			remindingEntity.SetColumnValue("SourceId", TConfiguration.RemindingConsts.RemindingSourceAuthorId);
			remindingEntity.SetColumnValue("RemindTime", UserConnection.CurrentUser.GetCurrentDateTime());
			var subjectCaption = string.Format(!string.IsNullOrEmpty(SubjectCaption.ToString())
					? SubjectCaption.ToString() 
					: "New email received regarding the case No.{0}", 
					number
				); 
			remindingEntity.SetColumnValue("SubjectCaption", subjectCaption);
			var caseSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Case");
			remindingEntity.SetColumnValue("SysEntitySchemaId", caseSchema.UId);
			remindingEntity.SetColumnValue("SubjectId", caseId);
			remindingEntity.SetColumnValue("Hash", hash);
			remindingEntity.Save();
			return true;
		}

		public virtual bool SetActivityServiceProcessedExecute(ProcessExecutingContext context) {
			var activityUpdate = new Update(UserConnection, "Activity")
				.Set("ServiceProcessed", Column.Parameter(false))
				.Where("Id").IsEqual(Column.Parameter(ActivityId)) as Update;
			activityUpdate.Execute();
			return true;
		}

		public virtual bool FormulaTask1Execute(ProcessExecutingContext context) {
			var localAssigneeIsCleared = true;
			AssigneeIsCleared = (System.Boolean)localAssigneeIsCleared;
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
			var cloneItem = (SendNotificationToCaseOwner)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

