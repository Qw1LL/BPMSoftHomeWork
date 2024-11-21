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
	using System.Linq;
	using System.Text;

	#region Class: LeadManagementProceedToOrderSchema

	/// <exclude/>
	public class LeadManagementProceedToOrderSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LeadManagementProceedToOrderSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LeadManagementProceedToOrderSchema(LeadManagementProceedToOrderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LeadManagementProceedToOrder";
			UId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d");
			CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a");
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
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d");
			Version = 0;
			PackageUId = new Guid("23109609-1650-4a4b-aecb-d0974c538074");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateNewOrderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2a65c94d-ad96-4e1a-8678-3223fff78f0d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"NewOrder",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3dad7563-c615-43f4-ad63-595693663fd7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"LeadId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{233e216d-e42b-4488-bb80-ae2955e15772}].[Parameter:{39c2ee29-de07-42d7-9978-27bbe105b922}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateActivityOwnerParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("56720a3e-4608-4bb3-8953-ed86f7f2fb7b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"ActivityOwner",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ab568057-901b-4628-947b-e71e93061aed}].[Parameter:{b63e014f-03e2-411a-b56e-cd11fcd2dedf}].[EntityColumn:{52817348-4c01-4015-a766-cb10c7b554c8}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateAccountIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("947f5e54-f169-418b-9dfc-7652c84973d9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"AccountId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ab568057-901b-4628-947b-e71e93061aed}].[Parameter:{b63e014f-03e2-411a-b56e-cd11fcd2dedf}].[EntityColumn:{32949ae4-ff13-48f5-9f5d-45a74558ea55}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateNewOrderParameter());
			Parameters.Add(CreateLeadIdParameter());
			Parameters.Add(CreateActivityOwnerParameter());
			Parameters.Add(CreateAccountIdParameter());
		}

		protected virtual void InitializeStartSignal1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("39c2ee29-de07-42d7-9978-27bbe105b922"),
				ContainerUId = new Guid("233e216d-e42b-4488-bb80-ae2955e15772"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("233e216d-e42b-4488-bb80-ae2955e15772"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
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
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("51e58f82-c660-4f51-a482-2e47790531e4"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,111,212,48,16,253,43,81,206,184,74,156,100,29,239,173,148,5,85,2,90,209,170,23,194,97,18,79,82,139,124,201,246,182,148,213,254,119,198,201,118,105,209,10,22,46,64,46,177,159,223,140,223,124,121,19,86,45,88,251,30,58,12,151,225,203,203,119,87,67,237,78,94,235,214,161,121,99,134,245,24,190,8,45,26,13,173,254,138,106,198,87,74,187,87,224,128,12,54,197,119,251,34,92,22,135,60,20,225,139,34,212,14,59,75,12,50,72,23,82,8,81,166,44,93,36,130,165,74,196,12,50,37,25,151,16,213,121,41,176,146,245,204,60,236,250,108,232,70,48,56,223,48,57,175,167,229,245,195,232,137,49,1,213,68,209,118,232,119,96,226,37,216,85,15,101,139,138,246,206,172,145,32,103,116,71,145,224,181,238,240,18,12,221,228,253,12,30,34,82,13,173,245,172,22,107,183,250,50,26,180,86,15,253,207,165,181,235,174,127,202,37,115,220,111,119,98,162,73,161,103,94,130,187,157,28,156,147,168,237,164,241,180,105,12,54,224,244,221,83,9,159,241,97,226,29,151,59,50,80,84,159,27,104,215,248,228,206,231,113,156,193,232,230,112,230,235,137,96,116,115,123,100,164,251,108,253,42,88,78,224,248,72,62,202,227,65,253,124,65,224,157,7,102,31,143,203,34,252,120,110,47,238,123,52,87,213,45,118,48,103,236,211,9,161,63,0,171,22,59,236,221,114,195,147,4,121,188,80,12,83,94,178,52,205,115,86,150,121,196,0,185,204,50,140,51,33,248,150,12,246,130,150,155,68,86,28,233,152,41,140,40,237,92,9,38,165,200,25,23,101,137,113,148,149,146,147,201,44,92,219,177,133,135,155,189,190,183,8,42,208,125,80,20,69,120,122,15,218,233,190,9,44,180,232,129,192,58,104,48,128,94,5,142,2,13,134,122,58,10,180,157,248,23,70,81,62,104,113,242,1,171,193,168,93,157,252,143,60,163,168,83,36,177,140,71,17,103,105,34,129,201,68,148,172,82,73,38,147,10,43,46,57,181,149,255,124,245,135,70,87,208,94,140,104,168,187,166,234,70,135,167,226,217,56,249,188,155,97,112,115,54,247,85,243,81,77,90,30,59,51,78,5,231,73,94,179,18,171,138,165,113,186,96,192,203,132,37,11,158,39,81,157,197,41,7,18,67,207,137,47,237,213,176,54,213,110,132,237,252,142,252,209,11,241,23,38,255,119,198,249,224,64,29,51,34,255,109,251,159,255,43,173,185,13,183,223,0,68,196,202,135,220,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("72785b41-22fc-440b-9e25-09541a823da1"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ba95284a-479c-4695-b20e-f63e9d809aef"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9cfa6a66-c948-435e-a77c-ce3c093762b0"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("38ad1df5-1e23-417a-b816-604ee5ebd463"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("43a2921d-cbf9-4ccf-9e18-3b7e690771cf"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("b56a9823-aa72-425f-bd71-e269cc7c6b9e"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("b63e014f-03e2-411a-b56e-cd11fcd2dedf"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c5ddbc71-2bb8-4428-9200-8670e0c41529"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("39c0f849-1bbe-41f7-a8ec-60baac586e9d"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("362c2b06-2632-4385-811f-5d44097aba94"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f78dac62-b855-47c2-98b1-8d7452f88518"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("dbb1f233-5174-43e1-b1c7-d09d994ca216"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("1156c6f8-f42f-40e6-aabd-037e9316c30f"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(canReadUncommitedDataParameter);
			var resultEntityCollectionParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("f91976d0-6fa2-4bfa-aa99-75e535e05b15"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f0036525-a88d-4f8f-9e33-96275cc4add9"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("21c581af-6689-4593-83b0-ade1bc6ace04"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(ignoreDisplayValuesParameter);
			var resultCompositeObjectListParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1c841b42-21d7-449c-9c25-e5d9006c569c"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a849651b-3c94-415e-8f28-495c77cb69c2"),
				ContainerUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("233422b6-ee14-4a8a-ba4e-5872f8b8c777"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,111,212,48,16,253,43,81,206,245,42,113,190,247,86,202,130,42,1,93,209,170,23,194,193,142,39,169,69,18,71,182,183,165,172,246,191,51,118,218,165,69,11,44,92,128,92,226,188,188,25,191,121,158,241,54,108,122,102,204,59,54,64,184,12,95,172,223,94,170,214,46,94,201,222,130,126,173,213,102,10,79,66,3,90,178,94,126,1,49,227,43,33,237,75,102,25,6,108,235,111,241,117,184,172,15,101,168,195,147,58,148,22,6,131,12,12,40,120,158,180,121,146,146,50,139,91,146,66,10,132,69,121,78,242,188,224,80,64,158,38,224,114,253,48,245,153,26,38,166,97,222,193,39,111,253,242,234,126,114,196,24,129,198,83,164,81,227,3,152,56,9,102,53,50,222,131,192,111,171,55,128,144,213,114,192,74,224,74,14,176,102,26,119,114,121,148,131,144,212,178,222,56,86,15,173,93,125,158,52,24,35,213,248,115,105,253,102,24,159,114,49,28,246,159,15,98,34,175,208,49,215,204,222,248,4,111,128,137,197,57,42,219,121,161,167,93,167,161,99,86,222,62,213,241,9,238,61,249,56,3,49,64,224,33,93,179,126,3,79,54,126,94,204,25,155,236,92,211,172,193,135,105,217,221,28,89,240,222,180,95,213,76,17,156,30,201,71,101,60,88,1,205,17,188,117,192,156,227,113,89,135,31,206,205,197,221,8,250,178,185,129,129,205,158,125,92,32,250,29,176,234,97,128,209,46,183,52,73,128,198,185,32,144,82,78,210,180,44,9,231,101,68,24,208,42,203,32,206,138,130,238,48,96,47,104,185,77,170,134,2,254,38,2,162,130,164,84,20,164,170,138,146,208,130,115,136,163,140,87,20,67,102,225,210,76,61,187,247,218,247,238,6,114,12,234,186,14,79,239,152,180,114,236,2,195,122,112,64,96,44,235,32,96,163,8,44,22,26,168,214,255,10,164,241,252,11,45,208,15,92,44,222,67,163,180,112,141,130,123,184,23,102,134,52,166,144,229,49,41,69,149,144,180,73,0,11,1,74,120,25,199,208,52,80,36,101,134,141,229,30,119,254,170,147,13,235,47,38,208,216,95,254,116,163,195,195,241,108,170,156,239,90,41,59,187,185,63,53,87,213,90,43,177,105,172,151,244,216,162,165,136,138,138,59,127,50,142,45,26,53,104,46,154,70,226,152,182,49,99,188,40,121,133,154,240,114,113,39,124,169,54,186,121,24,104,51,223,42,127,116,95,252,133,123,224,183,135,251,224,112,29,51,46,255,237,40,156,255,99,109,186,11,119,95,1,84,30,43,183,246,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0e73147b-3fca-4520-ae87-958d8a954ecb"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4741dc21-15cb-41c2-8680-9e717f617814"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1830ecce-1fbf-4a1d-927b-835b4390eef4"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("be29adc6-c305-4fb0-b446-ae26278a5cf6"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4fd6ce9f-f292-41a0-a8ba-d343dfc9cb25"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f5c8e8e8-ec65-413b-b1ef-1e44cb614020"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,73,77,76,177,50,180,50,212,241,76,177,50,176,50,0,0,230,77,107,227,15,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("1f66152e-4108-49d8-9953-69045f06df88"),
				UId = new Guid("83189d35-e077-4319-b18e-c6f2b2393707"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("17afe864-aaad-4c4e-ad01-768cbd0e842d"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("53363eca-d6fd-4903-a89f-afc707231e89"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2d30b140-c803-410d-99de-46fefa3903f9"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e8a3eb91-0b0d-419f-8a07-a279783a4aed"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9e8fe1c5-61e9-4c8c-93e5-05ed37a5a23b"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("de74e707-3683-47dc-acb1-0620c233b644"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("1f66152e-4108-49d8-9953-69045f06df88"),
				UId = new Guid("6afe29bc-36f3-4e7b-a2a6-ed65c01eaae2"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("77c33b50-7f50-4a1e-846b-d24d080ce656"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("abe22acf-b177-4dbf-a6d4-52b190f66261"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a36f8fca-865d-4aa4-8cc3-db83862aa504"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d1cd5032-a015-49e6-8905-762ec1677544"),
				ContainerUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeAddDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("28914bf3-2c8b-4583-b644-625e18978559"),
				ContainerUId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c"),
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
				Value = @"80294582-06b5-4faa-a85f-3323e5536b71",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c1ffede0-fe00-42d9-a867-6030c7ce74a0"),
				ContainerUId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("86435d98-74c1-4ada-b6e5-22961dde1a37"),
				ContainerUId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("1f919ca3-5929-45db-98dd-c0fa939af046"),
				ContainerUId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9b610c3e-7085-4d3f-963b-b33fd03a0d68"),
				ContainerUId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,153,219,110,27,71,18,134,95,133,96,114,169,38,250,124,208,221,174,157,0,6,236,68,176,118,125,99,249,162,186,171,58,38,66,145,194,112,232,133,86,208,187,231,31,74,140,15,27,40,18,22,10,32,68,188,160,196,209,84,77,119,177,190,250,171,75,87,243,239,199,203,11,153,31,207,255,121,242,230,116,211,199,197,139,205,32,139,147,97,211,100,187,93,188,222,52,90,45,255,75,117,37,39,52,208,185,140,50,188,163,213,78,182,175,151,219,241,104,246,165,209,252,104,254,253,167,253,223,230,199,239,175,230,175,70,57,255,247,43,134,103,107,76,40,18,181,42,185,136,242,129,141,162,98,68,177,244,108,169,23,14,134,96,220,54,171,221,249,250,141,140,116,66,227,199,249,241,213,124,239,13,14,90,210,90,115,115,112,64,112,208,147,87,228,157,168,148,165,132,18,181,111,182,204,175,143,230,219,246,81,206,105,255,208,207,198,89,219,226,67,182,74,199,26,96,76,164,40,135,174,156,179,78,66,112,177,38,51,25,223,222,255,217,240,253,119,239,95,109,127,254,207,90,134,211,189,223,227,78,171,173,124,88,224,234,55,23,126,88,201,185,172,199,227,43,170,33,102,29,146,42,218,84,229,163,205,170,248,84,149,36,35,197,233,104,72,248,26,6,191,199,242,248,170,70,39,218,248,174,180,19,171,188,49,164,224,68,84,99,99,122,99,203,194,125,50,249,97,61,46,199,203,23,251,24,29,95,57,236,169,144,120,213,187,113,202,231,30,84,233,129,17,92,74,62,132,44,20,194,245,135,239,62,76,27,227,229,246,98,69,151,239,254,119,127,111,133,120,198,52,210,108,133,223,22,63,46,135,237,56,91,226,123,155,109,250,108,144,237,110,53,46,215,191,204,240,197,172,164,141,203,205,122,241,143,214,54,187,245,120,227,248,226,171,140,248,210,245,213,217,77,90,157,205,143,207,254,56,177,110,127,222,4,242,235,212,250,58,171,206,230,71,103,243,211,205,110,104,147,55,135,15,47,191,216,207,254,1,251,91,190,249,120,72,35,92,89,239,86,171,219,43,47,177,215,195,141,135,203,27,94,246,165,240,171,245,233,33,123,246,94,144,113,251,151,250,131,183,195,235,102,109,255,143,217,27,90,211,47,50,252,132,237,127,94,251,239,171,252,23,66,120,112,92,109,9,58,153,174,146,80,81,94,162,85,153,145,44,197,148,218,93,114,182,119,187,183,126,43,93,6,89,55,249,122,97,54,112,106,134,170,50,44,26,121,162,141,170,94,131,10,43,90,144,53,150,227,77,172,223,202,118,31,237,137,223,219,117,77,161,186,158,95,95,31,125,73,181,215,61,25,106,90,145,41,72,220,108,146,170,38,19,114,61,86,237,180,173,49,150,59,169,206,146,75,14,141,176,15,176,236,27,92,149,86,73,89,31,163,115,69,91,19,255,102,84,19,251,162,57,100,165,131,39,229,57,131,106,68,67,49,103,196,68,170,43,217,61,6,213,47,54,235,145,218,51,213,79,143,106,19,171,184,24,140,202,125,159,103,161,192,158,193,100,214,142,125,204,142,217,61,136,106,234,177,132,230,172,178,161,1,74,203,1,14,1,101,116,228,181,107,182,105,206,119,82,93,93,111,209,122,148,152,74,17,57,92,176,34,157,155,106,26,169,109,92,142,182,167,199,160,250,245,102,243,235,238,98,225,141,213,70,7,173,140,7,110,62,17,214,95,130,85,205,177,182,30,181,46,229,180,48,221,17,59,27,149,244,14,205,36,116,22,52,113,90,66,146,132,174,196,197,236,255,140,178,219,231,253,60,176,12,179,237,72,227,110,187,48,139,217,203,129,250,51,72,79,15,164,251,228,205,131,64,106,61,17,105,32,192,18,81,203,209,175,170,34,236,149,99,35,53,178,209,157,251,157,32,117,141,118,217,219,164,76,144,6,193,134,152,224,66,80,78,26,123,103,88,163,245,125,68,144,154,65,219,158,32,204,69,59,175,188,142,81,65,230,68,69,180,236,190,73,238,148,243,162,118,113,80,111,86,149,33,143,62,115,82,100,241,150,173,119,1,50,151,124,163,7,129,116,65,151,147,230,30,128,58,89,209,122,45,252,220,110,62,57,158,238,147,62,15,227,201,155,202,40,208,42,56,52,153,190,117,175,114,246,172,92,174,37,26,93,187,177,241,78,158,98,172,189,34,241,149,211,26,132,115,131,104,198,226,20,3,52,192,40,150,157,126,76,97,2,175,161,38,172,95,176,116,159,117,131,220,116,180,147,133,59,232,209,80,214,178,200,49,53,50,33,168,218,81,128,60,225,49,197,36,139,131,174,129,146,123,193,35,195,131,120,98,89,45,63,201,112,249,12,212,83,63,191,221,39,127,30,4,148,212,90,125,237,77,229,58,9,84,65,147,135,19,25,74,121,11,193,115,116,41,199,187,167,50,142,130,135,34,213,169,218,35,89,157,197,88,39,68,163,4,109,103,247,206,231,202,143,9,20,55,27,82,245,6,30,4,1,141,168,10,69,154,85,174,176,239,173,21,171,137,22,65,115,79,9,13,113,170,8,189,231,218,20,105,203,248,136,227,84,45,129,59,235,123,2,245,242,128,210,52,216,192,145,105,55,44,101,120,86,166,39,7,210,125,242,230,97,202,196,37,87,131,44,166,78,200,49,200,139,42,53,5,28,153,28,139,64,5,91,76,119,143,55,67,232,158,177,24,242,126,154,47,68,212,255,234,209,123,66,36,123,140,83,235,231,30,17,164,194,81,39,68,13,133,96,154,32,246,154,21,206,141,93,117,141,48,77,147,156,44,105,209,44,231,169,171,131,128,79,55,73,174,128,221,57,149,128,122,171,40,28,177,212,123,130,116,114,219,227,237,57,250,105,179,86,141,182,31,15,157,223,51,80,79,14,168,251,228,207,131,128,138,45,230,94,208,219,145,198,116,208,23,211,48,60,195,120,145,9,130,21,153,27,228,238,78,160,208,206,197,156,171,40,156,178,48,29,111,208,40,42,24,103,56,129,7,242,66,212,195,99,0,117,122,185,125,71,195,114,250,111,201,226,197,110,64,172,70,68,92,254,140,11,152,77,211,185,79,223,152,206,62,219,62,79,218,231,127,29,15,108,49,214,157,154,172,166,227,116,116,49,86,85,155,163,234,100,8,83,110,195,40,211,119,241,112,239,133,221,193,195,135,235,223,0,68,170,138,174,153,27,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7c960984-040e-414d-913e-c8e671a175c3"),
				ContainerUId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c"),
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
				UId = new Guid("17c6c401-1a7f-4ae1-9875-916d79fbd200"),
				ContainerUId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c"),
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

		protected virtual void InitializeChangeDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("3a8fb70e-eb46-4374-ad70-c1d1df862c33"),
				ContainerUId = new Guid("bc3a0978-1caa-4f50-93e6-cbdbf05d9935"),
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
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ed01677f-c36f-4d12-bdce-2d077bf60563"),
				ContainerUId = new Guid("bc3a0978-1caa-4f50-93e6-cbdbf05d9935"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a6c6ca26-ca85-48d8-aa3f-ea21bffa2172"),
				ContainerUId = new Guid("bc3a0978-1caa-4f50-93e6-cbdbf05d9935"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,75,111,212,48,16,254,43,81,206,117,229,56,239,189,149,178,160,74,64,43,90,245,66,56,76,226,73,214,34,47,217,222,150,178,218,255,206,56,217,110,91,180,130,133,11,144,75,236,207,223,140,191,121,121,227,87,45,24,243,1,58,244,23,254,171,171,247,215,67,109,79,223,168,214,162,126,171,135,245,232,159,248,6,181,130,86,125,67,57,227,75,169,236,107,176,64,6,155,226,201,190,240,23,197,33,15,133,127,82,248,202,98,103,136,65,6,161,144,85,38,66,206,120,152,114,22,113,94,177,44,44,75,150,67,34,121,144,148,130,163,152,153,135,93,159,15,221,8,26,231,27,38,231,245,180,188,121,24,29,49,32,160,154,40,202,12,253,14,12,157,4,179,236,161,108,81,210,222,234,53,18,100,181,234,40,18,188,81,29,94,129,166,155,156,159,193,65,68,170,161,53,142,213,98,109,151,95,71,141,198,168,161,255,185,180,118,221,245,207,185,100,142,251,237,78,12,159,20,58,230,21,216,213,228,224,130,68,109,39,141,103,77,163,177,1,171,238,158,75,248,130,15,19,239,184,220,145,129,164,250,220,66,187,198,103,119,190,140,227,28,70,59,135,51,95,79,4,173,154,213,145,145,238,179,245,171,96,5,129,227,35,249,40,143,7,245,139,132,192,59,7,204,62,30,151,133,255,233,194,92,222,247,168,175,171,21,118,48,103,236,243,41,161,63,0,203,22,59,236,237,98,35,194,16,69,144,72,134,145,40,89,20,101,25,43,203,140,51,64,145,199,49,6,113,154,138,45,25,236,5,45,54,97,94,9,164,99,38,145,167,44,18,50,101,121,158,102,76,164,101,137,1,143,203,92,144,201,44,92,153,177,133,135,219,189,190,119,8,210,83,189,87,20,133,127,118,15,202,170,190,241,12,180,232,0,207,88,104,208,131,94,122,150,2,245,134,122,58,242,148,153,248,151,90,82,62,104,113,250,17,171,65,203,93,157,220,143,60,7,82,196,18,49,97,192,211,144,69,178,166,64,242,40,103,113,150,68,97,18,6,200,101,73,109,229,62,87,253,161,81,21,180,151,35,106,234,174,169,186,252,240,84,188,24,39,151,119,61,12,118,206,230,190,106,46,170,73,203,83,103,6,1,74,164,126,196,52,102,81,10,41,43,57,165,182,206,69,29,215,18,162,50,168,72,12,61,39,174,180,215,195,90,87,187,17,54,243,59,242,71,47,196,95,152,252,223,25,231,131,3,117,204,136,252,183,237,127,241,175,180,230,214,223,126,7,98,73,49,241,220,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b2c3e896-818e-48fd-bd84-3c8320d25e1a"),
				ContainerUId = new Guid("bc3a0978-1caa-4f50-93e6-cbdbf05d9935"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,114,155,48,16,253,21,143,146,163,229,145,144,4,18,199,38,61,120,38,110,61,117,155,139,237,195,34,173,26,207,96,240,0,110,39,101,248,247,202,24,98,59,205,173,58,0,90,246,189,125,218,125,106,201,125,243,122,64,146,146,79,203,197,170,244,205,236,161,172,112,182,172,74,139,117,61,123,42,45,228,187,63,144,229,184,132,10,246,216,96,245,12,249,17,235,167,93,221,76,39,215,32,50,37,247,191,250,127,36,93,183,100,222,224,254,199,220,5,102,141,76,163,204,18,170,188,227,84,102,220,83,96,62,166,12,189,101,82,48,148,145,12,96,91,230,199,125,177,192,6,150,208,188,144,180,37,61,91,32,136,157,117,76,48,73,49,115,49,149,200,56,213,142,25,154,160,65,116,70,89,237,144,116,83,82,219,23,220,67,95,244,2,150,28,188,54,24,178,21,203,2,56,203,168,182,96,169,247,194,100,177,212,146,163,61,129,135,252,11,112,125,183,158,215,95,127,23,88,173,122,222,212,67,94,227,118,22,162,239,2,159,115,220,99,209,164,45,112,13,76,154,136,130,228,140,74,9,16,190,84,40,152,56,197,149,243,78,68,182,11,128,183,94,166,109,98,77,204,140,150,148,73,134,84,114,233,168,225,2,169,213,24,39,28,120,162,172,232,182,119,219,147,68,183,171,15,57,188,62,255,171,244,161,66,104,112,82,86,14,171,217,121,227,38,21,218,16,152,204,221,25,125,184,25,224,53,190,221,156,93,176,33,233,230,99,31,12,239,243,185,111,157,112,107,130,13,153,110,200,170,60,86,246,196,38,194,230,241,74,116,95,160,79,121,183,29,167,30,34,197,49,207,135,200,35,52,48,38,142,225,210,237,252,14,221,188,88,141,195,238,89,216,176,232,7,143,113,157,181,253,15,108,1,5,252,196,234,75,56,254,69,251,155,202,239,161,133,35,113,22,25,197,146,224,244,4,193,4,215,197,81,176,44,135,48,91,147,121,145,136,200,251,168,71,127,67,143,21,22,22,111,133,105,22,25,169,116,68,89,156,41,42,253,201,73,90,121,42,68,36,80,41,17,103,9,31,240,117,223,237,211,117,27,116,157,90,213,145,174,219,118,127,1,31,52,33,225,222,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("15992e42-e5a9-4ef3-b8ad-95b4a29b03ee"),
				ContainerUId = new Guid("bc3a0978-1caa-4f50-93e6-cbdbf05d9935"),
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

		protected virtual void InitializeOpenEditPageUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var objectSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("ae68593e-fa7c-4048-b895-2278f193bf56"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"80294582-06b5-4faa-a85f-3323e5536b71",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(objectSchemaIdParameter);
			var pageSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("660ef167-9f42-438e-8e32-a0abcc62314c"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"23d86ac4-1d23-4314-a5e3-5da5e61b495a",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(pageSchemaIdParameter);
			var editModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7df2eca1-dc6c-4087-9840-bee0cc1e644b"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(editModeParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f101f976-de4b-4470-b288-dc04974ea7d9"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				UId = new Guid("6cff8c4f-e5db-4f8a-aa7a-f5ac4428b6ea"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a18a0492-a410-44aa-a45b-87d515dfd32c}].[Parameter:{7c960984-040e-414d-913e-c8e671a175c3}]#]",
				MetaPath = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a18a0492-a410-44aa-a45b-87d515dfd32c}].[Parameter:{7c960984-040e-414d-913e-c8e671a175c3}]#]",
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var executedModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e5ec6ce6-b474-4ec1-956c-dfb129b1a5ce"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("b956b76e-964d-46ce-823f-beb59ae28699"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("00eecca3-2d14-485a-8a8d-eb397d8ffbe8"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var generateDecisionsFromColumnParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bdac390a-ff58-46a2-907b-14a0c0565f2d"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(generateDecisionsFromColumnParameter);
			var decisionalColumnMetaPathParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f6bbd23d-5104-4c79-9ac8-67b6d9a5d3bd"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(decisionalColumnMetaPathParameter);
			var resultParameterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a7ec73e2-62cc-4a89-a496-e288aec50bdd"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("07ade664-1878-4494-93a7-397c9d9a6ba7"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("a25f8f25-a5bc-45f5-a3af-e84d2a250555"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"Заполните необходимые поля и сохраните заказ",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("c5bf469a-ca79-4c27-93c4-428493383a2b"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("109924be-1b7d-46bd-8855-110f7046c49a"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{56720a3e-4608-4bb3-8953-ed86f7f2fb7b}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("44c80af5-265f-4ca1-8c98-78e4479635ae"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c2f936e7-236a-4f61-9aa8-1cadbac9d2fd"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2983e005-8470-45c9-be2e-d84d93a53203"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("61ea02d3-de9d-4459-b975-072fcd9eff4e"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c610af2b-9150-43b8-aa79-239e85143fb7"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("41ec49be-7cd4-437d-910a-78a49a359978"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("16cb3b84-997b-460f-931d-69d58bf053af"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9060fb85-9faf-4a13-809f-40fd6d37daa4"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("3ca71ac5-ea92-4f42-a671-9da656bf2653"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{3dad7563-c615-43f4-ad63-595693663fd7}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(leadParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("1e40cbb6-dc33-43c4-907a-c06736c03f8c"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ab568057-901b-4628-947b-e71e93061aed}].[Parameter:{b63e014f-03e2-411a-b56e-cd11fcd2dedf}].[EntityColumn:{32949ae4-ff13-48f5-9f5d-45a74558ea55}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("42b3fc94-7228-4d8e-a9a0-44a7c7f1a17f"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ab568057-901b-4628-947b-e71e93061aed}].[Parameter:{b63e014f-03e2-411a-b56e-cd11fcd2dedf}].[EntityColumn:{ad490d58-054a-4d85-9246-dd8466eb3983}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("68804ba6-68d6-4d9a-8543-e1311e13aa63"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("dba832e4-be08-4c39-a60b-c029abee42d9"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("24b1894d-cb19-4761-95a7-21945965fd96"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("79b75417-25b2-4638-9fc0-4ba8602c8164"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("493d3b26-b741-456e-a4a9-1660de4605f1"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("1b88a7ef-d511-4681-afe2-7e7af45479bb"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("b8c8487c-7ec9-4fd7-8382-45adcafaa80a"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("9bba3ff9-9d5d-49eb-9944-5a24a927c8ee"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("02d10657-558f-4de5-bc41-185610ee3c4e"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("9ddc804c-6acd-4c8d-abf1-0a89835fc9f5"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(pageTypeUIdParameter);
			var activitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0f985d04-5e4c-4f3f-8bb9-7b29315ceede"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("17fa3835-9993-4c3b-910d-6fb4b4eb8ab5"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("1ea2f7f3-5e09-433d-a01f-16a9ece5d11f"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{2a65c94d-ad96-4e1a-8678-3223fff78f0d}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d")
			};
			parametrizedElement.Parameters.Add(orderParameter);
			var requestsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2e83dfcb-d1d1-445a-9f96-e47984017cff"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("fae4b282-9884-4e09-9382-4e83f9cec633"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("985510b3-2488-477a-a863-3ebb94e621e1"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("38999ad9-2ac8-48c0-8d33-55e204924212"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("fa4a8316-c6cc-40b6-8c02-edb5ba71cba1"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("26e8d57d-215d-4749-8846-746c59eb9b24"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("cbc1205a-31ec-4838-8fc9-aef608dfbee4"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("f54e7ee6-df35-43bf-a417-1b4b63aa77d4"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("24ef6849-3037-457c-bea3-0a4c0b7ee7be"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
				UId = new Guid("379d1b03-69ec-4765-b1e7-99dd602e70f2"),
				ContainerUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
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
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaStartSignalEvent startsignal1 = CreateStartSignal1StartSignalEvent();
			FlowElements.Add(startsignal1);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			ProcessSchemaUserTask adddatausertask1 = CreateAddDataUserTask1UserTask();
			FlowElements.Add(adddatausertask1);
			ProcessSchemaUserTask changedatausertask1 = CreateChangeDataUserTask1UserTask();
			FlowElements.Add(changedatausertask1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			ProcessSchemaUserTask openeditpageusertask1 = CreateOpenEditPageUserTask1UserTask();
			FlowElements.Add(openeditpageusertask1);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaExclusiveGateway exclusivegatewayuseproduct = CreateExclusiveGatewayUseProductExclusiveGateway();
			FlowElements.Add(exclusivegatewayuseproduct);
			ProcessSchemaExclusiveGateway exclusivegatewaycontainsowner = CreateExclusiveGatewayContainsOwnerExclusiveGateway();
			FlowElements.Add(exclusivegatewaycontainsowner);
			ProcessSchemaFormulaTask formulatask2 = CreateFormulaTask2FormulaTask();
			FlowElements.Add(formulatask2);
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow2ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow4ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("ce9777c8-0300-4372-ad96-9248f5e91a0c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("81b3a4f0-4c35-4ef8-9bd7-f217b5163dfd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("2939990e-abae-4748-8572-9190deffcb21"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("bc3a0978-1caa-4f50-93e6-cbdbf05d9935"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("e51e6ffc-424c-4ce3-a4f5-8ee830d2b8ca"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("233e216d-e42b-4488-bb80-ae2955e15772"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("69c15883-6503-4463-a254-378cf5b5f503"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("10679508-f2c3-44a1-b1e6-4833590364ed"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("69c15883-6503-4463-a254-378cf5b5f503"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6b2d1b2d-8ccf-4962-9073-d5cecdf6c2dd"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(83, 231));
			schemaFlow.PolylinePointPositions.Add(new Point(84, 231));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("a7178c4c-176e-442c-bd14-a31bac9eaac7"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{233e216d-e42b-4488-bb80-ae2955e15772}].[Parameter:{39c2ee29-de07-42d7-9978-27bbe105b922}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("69c15883-6503-4463-a254-378cf5b5f503"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("391c3d74-5ca7-44c2-accb-5eeba7b07f80"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("17207bea-f7f4-4e1c-85ee-b5f4af812e1c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1074, 317));
			schemaFlow.PolylinePointPositions.Add(new Point(1074, 188));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("4c6443fd-d84a-42e5-b51a-0c57c0acdc37"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("36a74fd9-906b-4e48-b36f-eeba6b29c35b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("f496c1c2-9114-4581-a08e-d8cfb472041e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("42c40f4d-fcc3-47cb-a47f-beee84ae882d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("17207bea-f7f4-4e1c-85ee-b5f4af812e1c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("5e01239b-825b-4e46-9b8c-d2bd7e7a7502"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bc3a0978-1caa-4f50-93e6-cbdbf05d9935"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("98e1d81a-4d06-4707-96b1-d201519c7ee1"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow2",
				UId = new Guid("2464e066-7e89-42fe-a792-c0681c0223a7"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{6c6198b1-4959-4529-90ea-d61784ab5100}].[Parameter:{17afe864-aaad-4c4e-ad01-768cbd0e842d}]#] > 0",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("951af993-3900-4618-9898-be413728166b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("42c40f4d-fcc3-47cb-a47f-beee84ae882d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(792, 317));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("fbe102fe-3947-4c2d-bbe1-07cf19332670"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("951af993-3900-4618-9898-be413728166b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow4",
				UId = new Guid("d1345e84-0430-446e-bd62-9a9b023143e4"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("98e1d81a-4d06-4707-96b1-d201519c7ee1"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("951af993-3900-4618-9898-be413728166b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow4ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow4",
				UId = new Guid("b57d3370-16d1-44e5-8e6f-851093a1cab2"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ab568057-901b-4628-947b-e71e93061aed}].[Parameter:{b63e014f-03e2-411a-b56e-cd11fcd2dedf}].[EntityColumn:{52817348-4c01-4015-a766-cb10c7b554c8}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("98e1d81a-4d06-4707-96b1-d201519c7ee1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("640f47a7-f8d1-43b2-a576-7e45f8aa3dd8"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(644, 316));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("744348fe-7225-44dc-a649-19685cf5b691"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("640f47a7-f8d1-43b2-a576-7e45f8aa3dd8"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("951af993-3900-4618-9898-be413728166b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(705, 188));
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("cab6cd99-d30a-49a7-b146-48197ae12bf5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("cab6cd99-d30a-49a7-b146-48197ae12bf5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("36a74fd9-906b-4e48-b36f-eeba6b29c35b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"Terminate1",
				Position = new Point(1220, 175),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal1StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("233e216d-e42b-4488-bb80-ae2955e15772"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
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
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"StartSignal1",
				NewEntityChangedColumns = false,
				Position = new Point(70, 63),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaStartSignalEvent.EntityChangedColumns.Add("bc0c2d60-5a3d-4840-aa4e-c60ea776e206");
			InitializeStartSignal1Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("ab568057-901b-4628-947b-e71e93061aed"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"ReadDataUserTask1",
				Position = new Point(183, 161),
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
				UId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"ReadDataUserTask2",
				Position = new Point(287, 161),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"AddDataUserTask1",
				Position = new Point(393, 161),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("bc3a0978-1caa-4f50-93e6-cbdbf05d9935"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"ChangeDataUserTask1",
				Position = new Point(504, 161),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("69c15883-6503-4463-a254-378cf5b5f503"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"ExclusiveGateway1",
				Position = new Point(56, 161),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("6b2d1b2d-8ccf-4962-9073-d5cecdf6c2dd"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"TerminateEvent1",
				Position = new Point(71, 287),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("17207bea-f7f4-4e1c-85ee-b5f4af812e1c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"ScriptTask1",
				Position = new Point(980, 290),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,88,75,111,219,56,16,62,59,191,130,245,161,144,187,134,54,189,166,77,22,137,147,20,6,218,196,173,221,221,195,98,17,48,18,157,16,213,35,37,169,180,110,155,255,190,51,36,37,81,15,203,146,155,67,98,91,156,199,199,225,204,55,35,142,110,211,52,34,15,130,7,236,31,174,238,87,244,59,147,228,152,156,45,62,44,211,181,242,103,169,96,240,47,89,243,187,76,80,197,211,196,95,110,228,146,41,197,147,59,233,191,99,234,111,26,101,236,45,90,57,241,62,75,38,64,56,97,1,74,78,201,120,81,177,59,158,30,140,70,107,26,73,54,121,115,48,10,89,192,99,26,17,69,191,47,152,8,88,162,170,15,79,227,52,171,62,75,21,141,138,167,11,145,134,89,160,180,135,115,170,232,39,246,144,74,174,82,177,129,221,108,93,58,38,9,251,70,182,235,214,182,128,56,31,169,48,241,121,207,165,186,20,105,92,6,96,143,64,189,203,120,216,18,168,51,42,217,34,119,162,227,20,178,53,205,34,229,161,194,4,113,224,23,0,194,192,102,33,9,0,42,114,45,113,105,68,99,75,12,188,124,175,76,126,181,34,23,137,226,106,179,12,238,89,76,63,102,172,17,29,223,21,248,64,19,122,199,4,238,116,158,72,69,147,128,157,109,174,104,204,188,241,123,70,67,235,110,172,183,2,46,252,211,48,156,165,81,22,39,222,216,174,249,40,61,238,88,255,156,112,213,181,14,73,182,99,217,183,153,214,37,166,35,210,37,48,15,187,86,103,153,16,44,9,54,29,50,109,75,255,218,53,220,227,145,253,158,127,254,231,95,101,241,45,19,215,107,76,19,148,144,195,77,84,130,119,201,35,197,132,68,109,15,127,207,4,163,138,153,167,88,174,11,42,224,44,80,196,131,84,52,207,103,105,252,64,5,151,105,178,218,60,48,255,226,107,70,35,200,92,60,220,241,148,224,199,220,36,170,41,24,237,22,169,4,237,67,82,152,92,1,172,145,73,158,150,74,227,107,226,229,138,80,75,80,231,228,132,28,78,200,79,192,128,70,185,44,18,95,94,36,244,54,98,33,216,175,229,36,230,159,188,132,237,100,130,89,33,111,12,50,165,234,251,244,142,7,58,20,218,99,139,85,227,178,90,249,11,30,124,97,2,252,205,34,42,229,37,13,144,46,208,219,219,249,162,42,115,226,97,241,0,36,169,4,108,37,21,167,226,46,139,33,235,188,113,86,193,10,97,67,55,163,90,36,52,50,13,237,52,8,48,10,243,144,188,168,21,186,69,56,106,242,65,13,48,34,44,150,75,131,198,199,83,238,168,97,166,230,142,188,124,89,143,179,201,115,133,79,253,103,199,217,199,215,142,45,212,145,144,95,191,182,210,248,118,212,219,250,132,63,135,114,226,52,226,63,152,62,109,52,106,184,157,252,172,147,244,116,171,223,167,169,235,70,250,75,134,197,145,215,0,57,62,201,235,8,163,131,85,103,107,221,109,37,57,169,220,32,45,77,252,85,170,3,56,41,163,131,127,154,215,155,100,221,172,158,22,70,71,67,182,18,98,42,54,57,191,193,97,63,87,247,67,164,56,42,184,230,161,54,80,216,191,136,31,212,102,146,99,8,236,234,39,96,171,37,156,3,224,107,171,200,89,83,108,104,81,182,213,100,29,1,172,63,50,1,212,216,133,161,16,234,64,96,141,114,38,29,196,22,72,203,150,75,52,169,8,153,176,9,96,14,13,9,183,95,87,190,118,116,199,181,253,233,82,131,140,103,43,30,99,132,59,234,17,44,219,159,185,188,158,36,70,107,72,9,26,220,19,207,105,7,132,39,69,103,176,53,166,199,207,185,188,98,44,92,165,43,250,197,240,52,214,137,75,22,109,204,15,148,244,188,69,175,107,17,172,118,84,253,74,108,52,79,213,70,167,129,85,58,37,105,166,26,110,76,197,218,41,79,47,85,74,109,71,140,254,106,216,243,29,245,163,33,68,82,234,153,180,40,6,112,29,201,189,160,232,111,59,80,88,47,14,144,114,18,51,20,255,162,17,23,51,133,72,175,193,77,14,133,27,204,173,117,171,147,215,254,8,205,155,197,42,205,141,228,167,90,26,181,237,122,212,240,102,25,126,218,86,61,78,155,42,223,116,246,10,226,170,84,63,34,158,13,215,196,9,169,19,205,50,136,160,117,227,78,189,77,226,48,156,15,144,154,108,98,7,67,35,209,50,177,141,70,77,67,208,197,170,72,244,88,63,237,60,123,160,68,40,73,231,232,205,171,64,111,23,118,21,50,118,58,184,101,246,245,129,3,244,64,7,168,114,83,102,179,249,180,118,250,59,198,161,255,99,70,245,226,14,247,141,26,106,69,208,242,54,209,27,12,164,147,14,194,94,233,59,148,137,140,179,254,224,116,75,211,240,174,216,55,253,163,183,170,19,224,115,19,68,255,58,97,3,18,80,83,130,97,44,75,7,67,148,247,208,50,124,181,143,51,68,186,167,246,57,151,122,252,46,212,15,123,171,58,109,69,123,173,17,246,80,51,72,228,96,232,245,96,232,120,75,48,117,110,157,202,254,210,157,211,121,71,233,123,160,168,227,242,69,173,27,154,229,198,75,140,123,95,54,204,35,198,115,85,94,145,85,143,182,87,105,111,85,46,110,227,160,73,120,78,23,123,101,165,200,159,196,123,125,120,72,254,104,132,245,137,48,184,238,179,251,168,152,49,141,249,149,171,1,102,192,138,117,89,130,201,95,22,141,249,226,2,240,55,2,227,24,223,55,60,13,19,79,253,9,180,52,146,127,255,189,25,199,153,207,244,94,157,48,239,49,246,116,204,56,141,121,72,229,174,58,70,159,33,167,228,196,166,190,153,150,124,218,207,112,129,121,199,185,209,71,230,21,151,213,40,246,116,32,24,220,42,37,4,222,223,216,155,255,1,95,152,51,8,57,23,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenEditPageUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Task",
				EntitySchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"OpenEditPageUserTask1",
				Position = new Point(1100, 161),
				SchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenEditPageUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("42c40f4d-fcc3-47cb-a47f-beee84ae882d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"FormulaTask1",
				Position = new Point(851, 290),
				ResultParameterMetaPath = @"2a65c94d-ad96-4e1a-8678-3223fff78f0d",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,187,14,131,48,12,64,209,143,97,118,21,19,135,60,246,14,76,69,234,136,50,184,137,81,7,194,16,144,58,32,254,157,204,221,174,142,116,231,110,30,247,215,111,147,250,78,95,41,28,22,94,119,137,143,166,127,240,92,165,200,118,132,147,209,177,34,223,3,19,42,32,98,110,101,62,224,108,54,104,242,146,117,159,174,54,76,92,185,200,33,53,156,54,249,65,121,71,160,72,9,16,82,6,143,90,32,57,25,44,50,90,147,244,21,187,120,3,152,79,215,44,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayUseProductExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("951af993-3900-4618-9898-be413728166b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"ExclusiveGatewayUseProduct",
				Position = new Point(765, 161),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayContainsOwnerExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("98e1d81a-4d06-4707-96b1-d201519c7ee1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"ExclusiveGatewayContainsOwner",
				Position = new Point(617, 161),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask2FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("640f47a7-f8d1-43b2-a576-7e45f8aa3dd8"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("915a628e-c19f-4a9f-a44c-a4e524cf5816"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a"),
				CreatedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"),
				Name = @"FormulaTask2",
				Position = new Point(671, 288),
				ResultParameterMetaPath = @"56720a3e-4608-4bb3-8953-ed86f7f2fb7b",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,204,187,10,194,48,20,128,225,135,113,62,146,147,123,179,74,7,39,5,199,210,33,151,19,20,154,8,109,68,164,244,221,173,171,235,15,223,63,28,134,243,114,121,87,154,111,241,78,197,187,236,167,133,198,227,94,255,66,63,81,161,218,220,234,131,210,150,41,3,29,195,0,82,115,11,157,52,1,200,32,117,130,105,244,148,182,29,92,253,236,11,53,154,221,26,180,32,134,50,3,19,196,65,34,122,216,39,4,49,33,230,152,120,162,148,127,164,175,237,209,62,167,231,244,42,213,173,138,91,52,66,90,144,145,33,72,134,10,188,209,26,98,64,22,77,80,74,70,187,141,135,241,11,154,157,117,132,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("32e89cc2-c170-4148-993c-07ae3aa76178"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("b0ad8bea-22e0-4780-944c-36847851410d"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("b1e601a2-10f6-4a89-94e0-aa4ecaa830e9"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("8beebd12-d17f-4e9e-805f-0ffb7364705a")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LeadManagementProceedToOrder(userConnection);
		}

		public override object Clone() {
			return new LeadManagementProceedToOrderSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadManagementProceedToOrder

	/// <exclude/>
	public class LeadManagementProceedToOrder : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, LeadManagementProceedToOrder process)
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, LeadManagementProceedToOrder process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("ab568057-901b-4628-947b-e71e93061aed");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,111,212,48,16,253,43,81,206,184,74,156,100,29,239,173,148,5,85,2,90,209,170,23,194,97,18,79,82,139,124,201,246,182,148,213,254,119,198,201,118,105,209,10,22,46,64,46,177,159,223,140,223,124,121,19,86,45,88,251,30,58,12,151,225,203,203,119,87,67,237,78,94,235,214,161,121,99,134,245,24,190,8,45,26,13,173,254,138,106,198,87,74,187,87,224,128,12,54,197,119,251,34,92,22,135,60,20,225,139,34,212,14,59,75,12,50,72,23,82,8,81,166,44,93,36,130,165,74,196,12,50,37,25,151,16,213,121,41,176,146,245,204,60,236,250,108,232,70,48,56,223,48,57,175,167,229,245,195,232,137,49,1,213,68,209,118,232,119,96,226,37,216,85,15,101,139,138,246,206,172,145,32,103,116,71,145,224,181,238,240,18,12,221,228,253,12,30,34,82,13,173,245,172,22,107,183,250,50,26,180,86,15,253,207,165,181,235,174,127,202,37,115,220,111,119,98,162,73,161,103,94,130,187,157,28,156,147,168,237,164,241,180,105,12,54,224,244,221,83,9,159,241,97,226,29,151,59,50,80,84,159,27,104,215,248,228,206,231,113,156,193,232,230,112,230,235,137,96,116,115,123,100,164,251,108,253,42,88,78,224,248,72,62,202,227,65,253,124,65,224,157,7,102,31,143,203,34,252,120,110,47,238,123,52,87,213,45,118,48,103,236,211,9,161,63,0,171,22,59,236,221,114,195,147,4,121,188,80,12,83,94,178,52,205,115,86,150,121,196,0,185,204,50,140,51,33,248,150,12,246,130,150,155,68,86,28,233,152,41,140,40,237,92,9,38,165,200,25,23,101,137,113,148,149,146,147,201,44,92,219,177,133,135,155,189,190,183,8,42,208,125,80,20,69,120,122,15,218,233,190,9,44,180,232,129,192,58,104,48,128,94,5,142,2,13,134,122,58,10,180,157,248,23,70,81,62,104,113,242,1,171,193,168,93,157,252,143,60,163,168,83,36,177,140,71,17,103,105,34,129,201,68,148,172,82,73,38,147,10,43,46,57,181,149,255,124,245,135,70,87,208,94,140,104,168,187,166,234,70,135,167,226,217,56,249,188,155,97,112,115,54,247,85,243,81,77,90,30,59,51,78,5,231,73,94,179,18,171,138,165,113,186,96,192,203,132,37,11,158,39,81,157,197,41,7,18,67,207,137,47,237,213,176,54,213,110,132,237,252,142,252,209,11,241,23,38,255,119,198,249,224,64,29,51,34,255,109,251,159,255,43,173,185,13,183,223,0,68,196,202,135,220,6,0,0 })));
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

			private bool _canReadUncommitedData = false;
			public override bool CanReadUncommitedData {
				get {
					return _canReadUncommitedData;
				}
				set {
					_canReadUncommitedData = value;
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

		#region Class: ReadDataUserTask2FlowElement

		/// <exclude/>
		public class ReadDataUserTask2FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask2FlowElement(UserConnection userConnection, LeadManagementProceedToOrder process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("6c6198b1-4959-4529-90ea-d61784ab5100");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,111,212,48,16,253,43,81,206,245,42,113,190,247,86,202,130,42,1,93,209,170,23,194,193,142,39,169,69,18,71,182,183,165,172,246,191,51,118,218,165,69,11,44,92,128,92,226,188,188,25,191,121,158,241,54,108,122,102,204,59,54,64,184,12,95,172,223,94,170,214,46,94,201,222,130,126,173,213,102,10,79,66,3,90,178,94,126,1,49,227,43,33,237,75,102,25,6,108,235,111,241,117,184,172,15,101,168,195,147,58,148,22,6,131,12,12,40,120,158,180,121,146,146,50,139,91,146,66,10,132,69,121,78,242,188,224,80,64,158,38,224,114,253,48,245,153,26,38,166,97,222,193,39,111,253,242,234,126,114,196,24,129,198,83,164,81,227,3,152,56,9,102,53,50,222,131,192,111,171,55,128,144,213,114,192,74,224,74,14,176,102,26,119,114,121,148,131,144,212,178,222,56,86,15,173,93,125,158,52,24,35,213,248,115,105,253,102,24,159,114,49,28,246,159,15,98,34,175,208,49,215,204,222,248,4,111,128,137,197,57,42,219,121,161,167,93,167,161,99,86,222,62,213,241,9,238,61,249,56,3,49,64,224,33,93,179,126,3,79,54,126,94,204,25,155,236,92,211,172,193,135,105,217,221,28,89,240,222,180,95,213,76,17,156,30,201,71,101,60,88,1,205,17,188,117,192,156,227,113,89,135,31,206,205,197,221,8,250,178,185,129,129,205,158,125,92,32,250,29,176,234,97,128,209,46,183,52,73,128,198,185,32,144,82,78,210,180,44,9,231,101,68,24,208,42,203,32,206,138,130,238,48,96,47,104,185,77,170,134,2,254,38,2,162,130,164,84,20,164,170,138,146,208,130,115,136,163,140,87,20,67,102,225,210,76,61,187,247,218,247,238,6,114,12,234,186,14,79,239,152,180,114,236,2,195,122,112,64,96,44,235,32,96,163,8,44,22,26,168,214,255,10,164,241,252,11,45,208,15,92,44,222,67,163,180,112,141,130,123,184,23,102,134,52,166,144,229,49,41,69,149,144,180,73,0,11,1,74,120,25,199,208,52,80,36,101,134,141,229,30,119,254,170,147,13,235,47,38,208,216,95,254,116,163,195,195,241,108,170,156,239,90,41,59,187,185,63,53,87,213,90,43,177,105,172,151,244,216,162,165,136,138,138,59,127,50,142,45,26,53,104,46,154,70,226,152,182,49,99,188,40,121,133,154,240,114,113,39,124,169,54,186,121,24,104,51,223,42,127,116,95,252,133,123,224,183,135,251,224,112,29,51,46,255,237,40,156,255,99,109,186,11,119,95,1,84,30,43,183,246,6,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,73,77,76,177,50,180,50,212,241,76,177,50,176,50,0,0,230,77,107,227,15,0,0,0 })));
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
								new Guid("1f66152e-4108-49d8-9953-69045f06df88")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("1f66152e-4108-49d8-9953-69045f06df88"));
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

		#region Class: AddDataUserTask1FlowElement

		/// <exclude/>
		public class AddDataUserTask1FlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddDataUserTask1FlowElement(UserConnection userConnection, LeadManagementProceedToOrder process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("a18a0492-a410-44aa-a45b-87d515dfd32c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Account = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("QualifiedAccount").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("QualifiedAccountId") : Guid.Empty)));
				_recordDefValues_Contact = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("QualifiedContact").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("QualifiedContactId") : Guid.Empty)));
				_recordDefValues_Status = () => (Guid)(new Guid("1f3ad326-effd-4ac3-a3e2-957e7def3684"));
				_recordDefValues_PaymentStatus = () => (Guid)(new Guid("bfe38d3d-bd57-48d7-a2d7-82435cd274ca"));
				_recordDefValues_DeliveryStatus = () => (Guid)(new Guid("867ca155-bfa5-4aaa-9172-7813dd4e85f5"));
				_recordDefValues_DeliveryType = () => (Guid)(new Guid("50df77d0-7b1f-4dbc-a02d-7b6ebb95dfd0"));
				_recordDefValues_PaymentType = () => (Guid)(new Guid("c2d88243-685d-4e8b-a533-73f4cb8e869b"));
				_recordDefValues_Date = () => (DateTime)(((DateTime)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentDate")));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Account", () => _recordDefValues_Account.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Status", () => _recordDefValues_Status.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_PaymentStatus", () => _recordDefValues_PaymentStatus.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DeliveryStatus", () => _recordDefValues_DeliveryStatus.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DeliveryType", () => _recordDefValues_DeliveryType.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_PaymentType", () => _recordDefValues_PaymentType.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Date", () => _recordDefValues_Date.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Account;
			internal Func<Guid> _recordDefValues_Contact;
			internal Func<Guid> _recordDefValues_Status;
			internal Func<Guid> _recordDefValues_PaymentStatus;
			internal Func<Guid> _recordDefValues_DeliveryStatus;
			internal Func<Guid> _recordDefValues_DeliveryType;
			internal Func<Guid> _recordDefValues_PaymentType;
			internal Func<DateTime> _recordDefValues_Date;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,153,219,110,27,71,18,134,95,133,96,114,169,38,250,124,208,221,174,157,0,6,236,68,176,118,125,99,249,162,186,171,58,38,66,145,194,112,232,133,86,208,187,231,31,74,140,15,27,40,18,22,10,32,68,188,160,196,209,84,77,119,177,190,250,171,75,87,243,239,199,203,11,153,31,207,255,121,242,230,116,211,199,197,139,205,32,139,147,97,211,100,187,93,188,222,52,90,45,255,75,117,37,39,52,208,185,140,50,188,163,213,78,182,175,151,219,241,104,246,165,209,252,104,254,253,167,253,223,230,199,239,175,230,175,70,57,255,247,43,134,103,107,76,40,18,181,42,185,136,242,129,141,162,98,68,177,244,108,169,23,14,134,96,220,54,171,221,249,250,141,140,116,66,227,199,249,241,213,124,239,13,14,90,210,90,115,115,112,64,112,208,147,87,228,157,168,148,165,132,18,181,111,182,204,175,143,230,219,246,81,206,105,255,208,207,198,89,219,226,67,182,74,199,26,96,76,164,40,135,174,156,179,78,66,112,177,38,51,25,223,222,255,217,240,253,119,239,95,109,127,254,207,90,134,211,189,223,227,78,171,173,124,88,224,234,55,23,126,88,201,185,172,199,227,43,170,33,102,29,146,42,218,84,229,163,205,170,248,84,149,36,35,197,233,104,72,248,26,6,191,199,242,248,170,70,39,218,248,174,180,19,171,188,49,164,224,68,84,99,99,122,99,203,194,125,50,249,97,61,46,199,203,23,251,24,29,95,57,236,169,144,120,213,187,113,202,231,30,84,233,129,17,92,74,62,132,44,20,194,245,135,239,62,76,27,227,229,246,98,69,151,239,254,119,127,111,133,120,198,52,210,108,133,223,22,63,46,135,237,56,91,226,123,155,109,250,108,144,237,110,53,46,215,191,204,240,197,172,164,141,203,205,122,241,143,214,54,187,245,120,227,248,226,171,140,248,210,245,213,217,77,90,157,205,143,207,254,56,177,110,127,222,4,242,235,212,250,58,171,206,230,71,103,243,211,205,110,104,147,55,135,15,47,191,216,207,254,1,251,91,190,249,120,72,35,92,89,239,86,171,219,43,47,177,215,195,141,135,203,27,94,246,165,240,171,245,233,33,123,246,94,144,113,251,151,250,131,183,195,235,102,109,255,143,217,27,90,211,47,50,252,132,237,127,94,251,239,171,252,23,66,120,112,92,109,9,58,153,174,146,80,81,94,162,85,153,145,44,197,148,218,93,114,182,119,187,183,126,43,93,6,89,55,249,122,97,54,112,106,134,170,50,44,26,121,162,141,170,94,131,10,43,90,144,53,150,227,77,172,223,202,118,31,237,137,223,219,117,77,161,186,158,95,95,31,125,73,181,215,61,25,106,90,145,41,72,220,108,146,170,38,19,114,61,86,237,180,173,49,150,59,169,206,146,75,14,141,176,15,176,236,27,92,149,86,73,89,31,163,115,69,91,19,255,102,84,19,251,162,57,100,165,131,39,229,57,131,106,68,67,49,103,196,68,170,43,217,61,6,213,47,54,235,145,218,51,213,79,143,106,19,171,184,24,140,202,125,159,103,161,192,158,193,100,214,142,125,204,142,217,61,136,106,234,177,132,230,172,178,161,1,74,203,1,14,1,101,116,228,181,107,182,105,206,119,82,93,93,111,209,122,148,152,74,17,57,92,176,34,157,155,106,26,169,109,92,142,182,167,199,160,250,245,102,243,235,238,98,225,141,213,70,7,173,140,7,110,62,17,214,95,130,85,205,177,182,30,181,46,229,180,48,221,17,59,27,149,244,14,205,36,116,22,52,113,90,66,146,132,174,196,197,236,255,140,178,219,231,253,60,176,12,179,237,72,227,110,187,48,139,217,203,129,250,51,72,79,15,164,251,228,205,131,64,106,61,17,105,32,192,18,81,203,209,175,170,34,236,149,99,35,53,178,209,157,251,157,32,117,141,118,217,219,164,76,144,6,193,134,152,224,66,80,78,26,123,103,88,163,245,125,68,144,154,65,219,158,32,204,69,59,175,188,142,81,65,230,68,69,180,236,190,73,238,148,243,162,118,113,80,111,86,149,33,143,62,115,82,100,241,150,173,119,1,50,151,124,163,7,129,116,65,151,147,230,30,128,58,89,209,122,45,252,220,110,62,57,158,238,147,62,15,227,201,155,202,40,208,42,56,52,153,190,117,175,114,246,172,92,174,37,26,93,187,177,241,78,158,98,172,189,34,241,149,211,26,132,115,131,104,198,226,20,3,52,192,40,150,157,126,76,97,2,175,161,38,172,95,176,116,159,117,131,220,116,180,147,133,59,232,209,80,214,178,200,49,53,50,33,168,218,81,128,60,225,49,197,36,139,131,174,129,146,123,193,35,195,131,120,98,89,45,63,201,112,249,12,212,83,63,191,221,39,127,30,4,148,212,90,125,237,77,229,58,9,84,65,147,135,19,25,74,121,11,193,115,116,41,199,187,167,50,142,130,135,34,213,169,218,35,89,157,197,88,39,68,163,4,109,103,247,206,231,202,143,9,20,55,27,82,245,6,30,4,1,141,168,10,69,154,85,174,176,239,173,21,171,137,22,65,115,79,9,13,113,170,8,189,231,218,20,105,203,248,136,227,84,45,129,59,235,123,2,245,242,128,210,52,216,192,145,105,55,44,101,120,86,166,39,7,210,125,242,230,97,202,196,37,87,131,44,166,78,200,49,200,139,42,53,5,28,153,28,139,64,5,91,76,119,143,55,67,232,158,177,24,242,126,154,47,68,212,255,234,209,123,66,36,123,140,83,235,231,30,17,164,194,81,39,68,13,133,96,154,32,246,154,21,206,141,93,117,141,48,77,147,156,44,105,209,44,231,169,171,131,128,79,55,73,174,128,221,57,149,128,122,171,40,28,177,212,123,130,116,114,219,227,237,57,250,105,179,86,141,182,31,15,157,223,51,80,79,14,168,251,228,207,131,128,138,45,230,94,208,219,145,198,116,208,23,211,48,60,195,120,145,9,130,21,153,27,228,238,78,160,208,206,197,156,171,40,156,178,48,29,111,208,40,42,24,103,56,129,7,242,66,212,195,99,0,117,122,185,125,71,195,114,250,111,201,226,197,110,64,172,70,68,92,254,140,11,152,77,211,185,79,223,152,206,62,219,62,79,218,231,127,29,15,108,49,214,157,154,172,166,227,116,116,49,86,85,155,163,234,100,8,83,110,195,40,211,119,241,112,239,133,221,193,195,135,235,223,0,68,170,138,174,153,27,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "83ce9b125c1b43478e8d24010d4b812d",
							"BaseElements.AddDataUserTask1.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("23109609-1650-4a4b-aecb-d0974c538074");
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

		#region Class: ChangeDataUserTask1FlowElement

		/// <exclude/>
		public class ChangeDataUserTask1FlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataUserTask1FlowElement(UserConnection userConnection, LeadManagementProceedToOrder process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("bc3a0978-1caa-4f50-93e6-cbdbf05d9935");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Order = () => (Guid)((process.AddDataUserTask1.RecordId));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Order", () => _recordColumnValues_Order.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Order;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,75,111,212,48,16,254,43,81,206,117,229,56,239,189,149,178,160,74,64,43,90,245,66,56,76,226,73,214,34,47,217,222,150,178,218,255,206,56,217,110,91,180,130,133,11,144,75,236,207,223,140,191,121,121,227,87,45,24,243,1,58,244,23,254,171,171,247,215,67,109,79,223,168,214,162,126,171,135,245,232,159,248,6,181,130,86,125,67,57,227,75,169,236,107,176,64,6,155,226,201,190,240,23,197,33,15,133,127,82,248,202,98,103,136,65,6,161,144,85,38,66,206,120,152,114,22,113,94,177,44,44,75,150,67,34,121,144,148,130,163,152,153,135,93,159,15,221,8,26,231,27,38,231,245,180,188,121,24,29,49,32,160,154,40,202,12,253,14,12,157,4,179,236,161,108,81,210,222,234,53,18,100,181,234,40,18,188,81,29,94,129,166,155,156,159,193,65,68,170,161,53,142,213,98,109,151,95,71,141,198,168,161,255,185,180,118,221,245,207,185,100,142,251,237,78,12,159,20,58,230,21,216,213,228,224,130,68,109,39,141,103,77,163,177,1,171,238,158,75,248,130,15,19,239,184,220,145,129,164,250,220,66,187,198,103,119,190,140,227,28,70,59,135,51,95,79,4,173,154,213,145,145,238,179,245,171,96,5,129,227,35,249,40,143,7,245,139,132,192,59,7,204,62,30,151,133,255,233,194,92,222,247,168,175,171,21,118,48,103,236,243,41,161,63,0,203,22,59,236,237,98,35,194,16,69,144,72,134,145,40,89,20,101,25,43,203,140,51,64,145,199,49,6,113,154,138,45,25,236,5,45,54,97,94,9,164,99,38,145,167,44,18,50,101,121,158,102,76,164,101,137,1,143,203,92,144,201,44,92,153,177,133,135,219,189,190,119,8,210,83,189,87,20,133,127,118,15,202,170,190,241,12,180,232,0,207,88,104,208,131,94,122,150,2,245,134,122,58,242,148,153,248,151,90,82,62,104,113,250,17,171,65,203,93,157,220,143,60,7,82,196,18,49,97,192,211,144,69,178,166,64,242,40,103,113,150,68,97,18,6,200,101,73,109,229,62,87,253,161,81,21,180,151,35,106,234,174,169,186,252,240,84,188,24,39,151,119,61,12,118,206,230,190,106,46,170,73,203,83,103,6,1,74,164,126,196,52,102,81,10,41,43,57,165,182,206,69,29,215,18,162,50,168,72,12,61,39,174,180,215,195,90,87,187,17,54,243,59,242,71,47,196,95,152,252,223,25,231,131,3,117,204,136,252,183,237,127,241,175,180,230,214,223,126,7,98,73,49,241,220,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,114,155,48,16,253,21,143,146,163,229,145,144,4,18,199,38,61,120,38,110,61,117,155,139,237,195,34,173,26,207,96,240,0,110,39,101,248,247,202,24,98,59,205,173,58,0,90,246,189,125,218,125,106,201,125,243,122,64,146,146,79,203,197,170,244,205,236,161,172,112,182,172,74,139,117,61,123,42,45,228,187,63,144,229,184,132,10,246,216,96,245,12,249,17,235,167,93,221,76,39,215,32,50,37,247,191,250,127,36,93,183,100,222,224,254,199,220,5,102,141,76,163,204,18,170,188,227,84,102,220,83,96,62,166,12,189,101,82,48,148,145,12,96,91,230,199,125,177,192,6,150,208,188,144,180,37,61,91,32,136,157,117,76,48,73,49,115,49,149,200,56,213,142,25,154,160,65,116,70,89,237,144,116,83,82,219,23,220,67,95,244,2,150,28,188,54,24,178,21,203,2,56,203,168,182,96,169,247,194,100,177,212,146,163,61,129,135,252,11,112,125,183,158,215,95,127,23,88,173,122,222,212,67,94,227,118,22,162,239,2,159,115,220,99,209,164,45,112,13,76,154,136,130,228,140,74,9,16,190,84,40,152,56,197,149,243,78,68,182,11,128,183,94,166,109,98,77,204,140,150,148,73,134,84,114,233,168,225,2,169,213,24,39,28,120,162,172,232,182,119,219,147,68,183,171,15,57,188,62,255,171,244,161,66,104,112,82,86,14,171,217,121,227,38,21,218,16,152,204,221,25,125,184,25,224,53,190,221,156,93,176,33,233,230,99,31,12,239,243,185,111,157,112,107,130,13,153,110,200,170,60,86,246,196,38,194,230,241,74,116,95,160,79,121,183,29,167,30,34,197,49,207,135,200,35,52,48,38,142,225,210,237,252,14,221,188,88,141,195,238,89,216,176,232,7,143,113,157,181,253,15,108,1,5,252,196,234,75,56,254,69,251,155,202,239,161,133,35,113,22,25,197,146,224,244,4,193,4,215,197,81,176,44,135,48,91,147,121,145,136,200,251,168,71,127,67,143,21,22,22,111,133,105,22,25,169,116,68,89,156,41,42,253,201,73,90,121,42,68,36,80,41,17,103,9,31,240,117,223,237,211,117,27,116,157,90,213,145,174,219,118,127,1,31,52,33,225,222,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "83ce9b125c1b43478e8d24010d4b812d",
							"BaseElements.ChangeDataUserTask1.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("23109609-1650-4a4b-aecb-d0974c538074");
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

		#region Class: OpenEditPageUserTask1FlowElement

		/// <exclude/>
		public class OpenEditPageUserTask1FlowElement : OpenEditPageUserTask
		{

			#region Constructors: Public

			public OpenEditPageUserTask1FlowElement(UserConnection userConnection, LeadManagementProceedToOrder process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenEditPageUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("d782fcdc-1a7b-4377-afb4-3feb6efac43d");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_recordId = () => (Guid)((process.AddDataUserTask1.RecordId));
				_ownerId = () => (Guid)((process.ActivityOwner));
				_lead = () => (Guid)((process.LeadId));
				_account = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("QualifiedAccount").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("QualifiedAccountId") : Guid.Empty)));
				_contact = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("QualifiedContact").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("QualifiedContactId") : Guid.Empty)));
				_order = () => (Guid)((process.NewOrder));
			}

			#endregion

			#region Properties: Public

			private Guid _objectSchemaId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71");
			public override Guid ObjectSchemaId {
				get {
					return _objectSchemaId;
				}
				set {
					_objectSchemaId = value;
				}
			}

			private Guid _pageSchemaId = new Guid("23d86ac4-1d23-4314-a5e3-5da5e61b495a");
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

			private bool _isMatchConditions = false;
			public override bool IsMatchConditions {
				get {
					return _isMatchConditions;
				}
				set {
					_isMatchConditions = value;
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
					return _recommendation ?? (_recommendation = GetLocalizableString("83ce9b125c1b43478e8d24010d4b812d",
						 "BaseElements.OpenEditPageUserTask1.Parameters.Recommendation.Value"));
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

			private int _startInPeriod = 0;
			public override int StartInPeriod {
				get {
					return _startInPeriod;
				}
				set {
					_startInPeriod = value;
				}
			}

			private int _remindBefore = 1;
			public override int RemindBefore {
				get {
					return _remindBefore;
				}
				set {
					_remindBefore = value;
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

			private bool _showExecutionPage = true;
			public override bool ShowExecutionPage {
				get {
					return _showExecutionPage;
				}
				set {
					_showExecutionPage = value;
				}
			}

			internal Func<Guid> _lead;
			public override Guid Lead {
				get {
					return (_lead ?? (_lead = () => Guid.Empty)).Invoke();
				}
				set {
					_lead = () => { return value; };
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

			internal Func<Guid> _order;
			public override Guid Order {
				get {
					return (_order ?? (_order = () => Guid.Empty)).Invoke();
				}
				set {
					_order = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		public LeadManagementProceedToOrder(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadManagementProceedToOrder";
			SchemaUId = new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_leadId = () => { return (Guid)((StartSignal1.RecordId)); };
			_activityOwner = () => { return (Guid)(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty))); };
			_accountId = () => { return (Guid)(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("QualifiedAccount").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("QualifiedAccountId") : Guid.Empty))); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("83ce9b12-5c1b-4347-8e8d-24010d4b812d");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LeadManagementProceedToOrder, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LeadManagementProceedToOrder, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid NewOrder {
			get;
			set;
		}

		private Func<Guid> _leadId;
		public virtual Guid LeadId {
			get {
				return (_leadId ?? (_leadId = () => Guid.Empty)).Invoke();
			}
			set {
				_leadId = () => { return value; };
			}
		}

		private Func<Guid> _activityOwner;
		public virtual Guid ActivityOwner {
			get {
				return (_activityOwner ?? (_activityOwner = () => Guid.Empty)).Invoke();
			}
			set {
				_activityOwner = () => { return value; };
			}
		}

		private Func<Guid> _accountId;
		public virtual Guid AccountId {
			get {
				return (_accountId ?? (_accountId = () => Guid.Empty)).Invoke();
			}
			set {
				_accountId = () => { return value; };
			}
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
					SchemaElementUId = new Guid("36a74fd9-906b-4e48-b36f-eeba6b29c35b"),
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
					SchemaElementUId = new Guid("233e216d-e42b-4488-bb80-ae2955e15772"),
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

		private ReadDataUserTask2FlowElement _readDataUserTask2;
		public ReadDataUserTask2FlowElement ReadDataUserTask2 {
			get {
				return _readDataUserTask2 ?? (_readDataUserTask2 = new ReadDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddDataUserTask1FlowElement _addDataUserTask1;
		public AddDataUserTask1FlowElement AddDataUserTask1 {
			get {
				return _addDataUserTask1 ?? (_addDataUserTask1 = new AddDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeDataUserTask1FlowElement _changeDataUserTask1;
		public ChangeDataUserTask1FlowElement ChangeDataUserTask1 {
			get {
				return _changeDataUserTask1 ?? (_changeDataUserTask1 = new ChangeDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("69c15883-6503-4463-a254-378cf5b5f503"),
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

		private ProcessTerminateEvent _terminateEvent1;
		public ProcessTerminateEvent TerminateEvent1 {
			get {
				return _terminateEvent1 ?? (_terminateEvent1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateEvent1",
					SchemaElementUId = new Guid("6b2d1b2d-8ccf-4962-9073-d5cecdf6c2dd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("17207bea-f7f4-4e1c-85ee-b5f4af812e1c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
				});
			}
		}

		private OpenEditPageUserTask1FlowElement _openEditPageUserTask1;
		public OpenEditPageUserTask1FlowElement OpenEditPageUserTask1 {
			get {
				return _openEditPageUserTask1 ?? (_openEditPageUserTask1 = new OpenEditPageUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("42c40f4d-fcc3-47cb-a47f-beee84ae882d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask1Execute,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGatewayUseProduct;
		public ProcessExclusiveGateway ExclusiveGatewayUseProduct {
			get {
				return _exclusiveGatewayUseProduct ?? (_exclusiveGatewayUseProduct = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewayUseProduct",
					SchemaElementUId = new Guid("951af993-3900-4618-9898-be413728166b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayUseProduct.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGatewayContainsOwner;
		public ProcessExclusiveGateway ExclusiveGatewayContainsOwner {
			get {
				return _exclusiveGatewayContainsOwner ?? (_exclusiveGatewayContainsOwner = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewayContainsOwner",
					SchemaElementUId = new Guid("98e1d81a-4d06-4707-96b1-d201519c7ee1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayContainsOwner.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _formulaTask2;
		public ProcessScriptTask FormulaTask2 {
			get {
				return _formulaTask2 ?? (_formulaTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask2",
					SchemaElementUId = new Guid("640f47a7-f8d1-43b2-a576-7e45f8aa3dd8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask2Execute,
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
					SchemaElementUId = new Guid("a7178c4c-176e-442c-bd14-a31bac9eaac7"),
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
					SchemaElementUId = new Guid("2464e066-7e89-42fe-a792-c0681c0223a7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow4;
		public ProcessConditionalFlow ConditionalSequenceFlow4 {
			get {
				return _conditionalSequenceFlow4 ?? (_conditionalSequenceFlow4 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow4",
					SchemaElementUId = new Guid("b57d3370-16d1-44e5-8e6f-851093a1cab2"),
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
			FlowElements[StartSignal1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal1 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
			FlowElements[AddDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataUserTask1 };
			FlowElements[ChangeDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[OpenEditPageUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenEditPageUserTask1 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[ExclusiveGatewayUseProduct.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayUseProduct };
			FlowElements[ExclusiveGatewayContainsOwner.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayContainsOwner };
			FlowElements[FormulaTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Terminate1":
						CompleteProcess();
						break;
					case "StartSignal1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataUserTask1", e.Context.SenderName));
						break;
					case "AddDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask1", e.Context.SenderName));
						break;
					case "ChangeDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayContainsOwner", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenEditPageUserTask1", e.Context.SenderName));
						break;
					case "OpenEditPageUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "ExclusiveGatewayUseProduct":
						if (ConditionalSequenceFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenEditPageUserTask1", e.Context.SenderName));
						break;
					case "ExclusiveGatewayContainsOwner":
						if (ConditionalSequenceFlow4ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayUseProduct", e.Context.SenderName));
						break;
					case "FormulaTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayUseProduct", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((StartSignal1.RecordId) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow1", "(StartSignal1.RecordId) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalSequenceFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((ReadDataUserTask2.ResultCount) > 0);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayUseProduct", "ConditionalSequenceFlow2", "(ReadDataUserTask2.ResultCount) > 0", result);
			return result;
		}

		private bool ConditionalSequenceFlow4ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayContainsOwner", "ConditionalSequenceFlow4", "((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName(\"Owner\").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>(\"OwnerId\") : Guid.Empty)) != Guid.Empty", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("NewOrder")) {
				writer.WriteValue("NewOrder", NewOrder, Guid.Empty);
			}
			if (!HasMapping("LeadId")) {
				writer.WriteValue("LeadId", LeadId, Guid.Empty);
			}
			if (!HasMapping("ActivityOwner")) {
				writer.WriteValue("ActivityOwner", ActivityOwner, Guid.Empty);
			}
			if (!HasMapping("AccountId")) {
				writer.WriteValue("AccountId", AccountId, Guid.Empty);
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
			MetaPathParameterValues.Add("2a65c94d-ad96-4e1a-8678-3223fff78f0d", () => NewOrder);
			MetaPathParameterValues.Add("3dad7563-c615-43f4-ad63-595693663fd7", () => LeadId);
			MetaPathParameterValues.Add("56720a3e-4608-4bb3-8953-ed86f7f2fb7b", () => ActivityOwner);
			MetaPathParameterValues.Add("947f5e54-f169-418b-9dfc-7652c84973d9", () => AccountId);
			MetaPathParameterValues.Add("39c2ee29-de07-42d7-9978-27bbe105b922", () => StartSignal1.RecordId);
			MetaPathParameterValues.Add("51e58f82-c660-4f51-a482-2e47790531e4", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("72785b41-22fc-440b-9e25-09541a823da1", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("ba95284a-479c-4695-b20e-f63e9d809aef", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("9cfa6a66-c948-435e-a77c-ce3c093762b0", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("38ad1df5-1e23-417a-b816-604ee5ebd463", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("43a2921d-cbf9-4ccf-9e18-3b7e690771cf", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("b56a9823-aa72-425f-bd71-e269cc7c6b9e", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("b63e014f-03e2-411a-b56e-cd11fcd2dedf", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("c5ddbc71-2bb8-4428-9200-8670e0c41529", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("39c0f849-1bbe-41f7-a8ec-60baac586e9d", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("362c2b06-2632-4385-811f-5d44097aba94", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("f78dac62-b855-47c2-98b1-8d7452f88518", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("dbb1f233-5174-43e1-b1c7-d09d994ca216", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("1156c6f8-f42f-40e6-aabd-037e9316c30f", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("f91976d0-6fa2-4bfa-aa99-75e535e05b15", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("f0036525-a88d-4f8f-9e33-96275cc4add9", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("21c581af-6689-4593-83b0-ade1bc6ace04", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("1c841b42-21d7-449c-9c25-e5d9006c569c", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("a849651b-3c94-415e-8f28-495c77cb69c2", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("233422b6-ee14-4a8a-ba4e-5872f8b8c777", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("0e73147b-3fca-4520-ae87-958d8a954ecb", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("4741dc21-15cb-41c2-8680-9e717f617814", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("1830ecce-1fbf-4a1d-927b-835b4390eef4", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("be29adc6-c305-4fb0-b446-ae26278a5cf6", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("4fd6ce9f-f292-41a0-a8ba-d343dfc9cb25", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("f5c8e8e8-ec65-413b-b1ef-1e44cb614020", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("83189d35-e077-4319-b18e-c6f2b2393707", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("17afe864-aaad-4c4e-ad01-768cbd0e842d", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("53363eca-d6fd-4903-a89f-afc707231e89", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("2d30b140-c803-410d-99de-46fefa3903f9", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("e8a3eb91-0b0d-419f-8a07-a279783a4aed", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("9e8fe1c5-61e9-4c8c-93e5-05ed37a5a23b", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("de74e707-3683-47dc-acb1-0620c233b644", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("6afe29bc-36f3-4e7b-a2a6-ed65c01eaae2", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("77c33b50-7f50-4a1e-846b-d24d080ce656", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("abe22acf-b177-4dbf-a6d4-52b190f66261", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("a36f8fca-865d-4aa4-8cc3-db83862aa504", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("d1cd5032-a015-49e6-8905-762ec1677544", () => ReadDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("28914bf3-2c8b-4583-b644-625e18978559", () => AddDataUserTask1.EntitySchemaId);
			MetaPathParameterValues.Add("c1ffede0-fe00-42d9-a867-6030c7ce74a0", () => AddDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("86435d98-74c1-4ada-b6e5-22961dde1a37", () => AddDataUserTask1.RecordAddMode);
			MetaPathParameterValues.Add("1f919ca3-5929-45db-98dd-c0fa939af046", () => AddDataUserTask1.FilterEntitySchemaId);
			MetaPathParameterValues.Add("9b610c3e-7085-4d3f-963b-b33fd03a0d68", () => AddDataUserTask1.RecordDefValues);
			MetaPathParameterValues.Add("7c960984-040e-414d-913e-c8e671a175c3", () => AddDataUserTask1.RecordId);
			MetaPathParameterValues.Add("17c6c401-1a7f-4ae1-9875-916d79fbd200", () => AddDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("3a8fb70e-eb46-4374-ad70-c1d1df862c33", () => ChangeDataUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("ed01677f-c36f-4d12-bdce-2d077bf60563", () => ChangeDataUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("a6c6ca26-ca85-48d8-aa3f-ea21bffa2172", () => ChangeDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("b2c3e896-818e-48fd-bd84-3c8320d25e1a", () => ChangeDataUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("15992e42-e5a9-4ef3-b8ad-95b4a29b03ee", () => ChangeDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("ae68593e-fa7c-4048-b895-2278f193bf56", () => OpenEditPageUserTask1.ObjectSchemaId);
			MetaPathParameterValues.Add("660ef167-9f42-438e-8e32-a0abcc62314c", () => OpenEditPageUserTask1.PageSchemaId);
			MetaPathParameterValues.Add("7df2eca1-dc6c-4087-9840-bee0cc1e644b", () => OpenEditPageUserTask1.EditMode);
			MetaPathParameterValues.Add("f101f976-de4b-4470-b288-dc04974ea7d9", () => OpenEditPageUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("6cff8c4f-e5db-4f8a-aa7a-f5ac4428b6ea", () => OpenEditPageUserTask1.RecordId);
			MetaPathParameterValues.Add("e5ec6ce6-b474-4ec1-956c-dfb129b1a5ce", () => OpenEditPageUserTask1.ExecutedMode);
			MetaPathParameterValues.Add("b956b76e-964d-46ce-823f-beb59ae28699", () => OpenEditPageUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("00eecca3-2d14-485a-8a8d-eb397d8ffbe8", () => OpenEditPageUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("bdac390a-ff58-46a2-907b-14a0c0565f2d", () => OpenEditPageUserTask1.GenerateDecisionsFromColumn);
			MetaPathParameterValues.Add("f6bbd23d-5104-4c79-9ac8-67b6d9a5d3bd", () => OpenEditPageUserTask1.DecisionalColumnMetaPath);
			MetaPathParameterValues.Add("a7ec73e2-62cc-4a89-a496-e288aec50bdd", () => OpenEditPageUserTask1.ResultParameter);
			MetaPathParameterValues.Add("07ade664-1878-4494-93a7-397c9d9a6ba7", () => OpenEditPageUserTask1.IsReexecution);
			MetaPathParameterValues.Add("a25f8f25-a5bc-45f5-a3af-e84d2a250555", () => OpenEditPageUserTask1.Recommendation);
			MetaPathParameterValues.Add("c5bf469a-ca79-4c27-93c4-428493383a2b", () => OpenEditPageUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("109924be-1b7d-46bd-8855-110f7046c49a", () => OpenEditPageUserTask1.OwnerId);
			MetaPathParameterValues.Add("44c80af5-265f-4ca1-8c98-78e4479635ae", () => OpenEditPageUserTask1.Duration);
			MetaPathParameterValues.Add("c2f936e7-236a-4f61-9aa8-1cadbac9d2fd", () => OpenEditPageUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("2983e005-8470-45c9-be2e-d84d93a53203", () => OpenEditPageUserTask1.StartIn);
			MetaPathParameterValues.Add("61ea02d3-de9d-4459-b975-072fcd9eff4e", () => OpenEditPageUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("c610af2b-9150-43b8-aa79-239e85143fb7", () => OpenEditPageUserTask1.RemindBefore);
			MetaPathParameterValues.Add("41ec49be-7cd4-437d-910a-78a49a359978", () => OpenEditPageUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("16cb3b84-997b-460f-931d-69d58bf053af", () => OpenEditPageUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("9060fb85-9faf-4a13-809f-40fd6d37daa4", () => OpenEditPageUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("3ca71ac5-ea92-4f42-a671-9da656bf2653", () => OpenEditPageUserTask1.Lead);
			MetaPathParameterValues.Add("1e40cbb6-dc33-43c4-907a-c06736c03f8c", () => OpenEditPageUserTask1.Account);
			MetaPathParameterValues.Add("42b3fc94-7228-4d8e-a9a0-44a7c7f1a17f", () => OpenEditPageUserTask1.Contact);
			MetaPathParameterValues.Add("68804ba6-68d6-4d9a-8543-e1311e13aa63", () => OpenEditPageUserTask1.Opportunity);
			MetaPathParameterValues.Add("dba832e4-be08-4c39-a60b-c029abee42d9", () => OpenEditPageUserTask1.Invoice);
			MetaPathParameterValues.Add("24b1894d-cb19-4761-95a7-21945965fd96", () => OpenEditPageUserTask1.Document);
			MetaPathParameterValues.Add("79b75417-25b2-4638-9fc0-4ba8602c8164", () => OpenEditPageUserTask1.Incident);
			MetaPathParameterValues.Add("493d3b26-b741-456e-a4a9-1660de4605f1", () => OpenEditPageUserTask1.Case);
			MetaPathParameterValues.Add("1b88a7ef-d511-4681-afe2-7e7af45479bb", () => OpenEditPageUserTask1.ActivityResult);
			MetaPathParameterValues.Add("b8c8487c-7ec9-4fd7-8382-45adcafaa80a", () => OpenEditPageUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("9bba3ff9-9d5d-49eb-9944-5a24a927c8ee", () => OpenEditPageUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("02d10657-558f-4de5-bc41-185610ee3c4e", () => OpenEditPageUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("9ddc804c-6acd-4c8d-abf1-0a89835fc9f5", () => OpenEditPageUserTask1.PageTypeUId);
			MetaPathParameterValues.Add("0f985d04-5e4c-4f3f-8bb9-7b29315ceede", () => OpenEditPageUserTask1.ActivitySchemaUId);
			MetaPathParameterValues.Add("17fa3835-9993-4c3b-910d-6fb4b4eb8ab5", () => OpenEditPageUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("1ea2f7f3-5e09-433d-a01f-16a9ece5d11f", () => OpenEditPageUserTask1.Order);
			MetaPathParameterValues.Add("2e83dfcb-d1d1-445a-9f96-e47984017cff", () => OpenEditPageUserTask1.Requests);
			MetaPathParameterValues.Add("fae4b282-9884-4e09-9382-4e83f9cec633", () => OpenEditPageUserTask1.Listing);
			MetaPathParameterValues.Add("985510b3-2488-477a-a863-3ebb94e621e1", () => OpenEditPageUserTask1.Property);
			MetaPathParameterValues.Add("38999ad9-2ac8-48c0-8d33-55e204924212", () => OpenEditPageUserTask1.Contract);
			MetaPathParameterValues.Add("fa4a8316-c6cc-40b6-8c02-edb5ba71cba1", () => OpenEditPageUserTask1.Problem);
			MetaPathParameterValues.Add("26e8d57d-215d-4749-8846-746c59eb9b24", () => OpenEditPageUserTask1.Change);
			MetaPathParameterValues.Add("cbc1205a-31ec-4838-8fc9-aef608dfbee4", () => OpenEditPageUserTask1.Release);
			MetaPathParameterValues.Add("f54e7ee6-df35-43bf-a417-1b4b63aa77d4", () => OpenEditPageUserTask1.Project);
			MetaPathParameterValues.Add("24ef6849-3037-457c-bea3-0a4c0b7ee7be", () => OpenEditPageUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("379d1b03-69ec-4765-b1e7-99dd602e70f2", () => OpenEditPageUserTask1.CreateActivity);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "NewOrder":
					if (!hasValueToRead) break;
					NewOrder = reader.GetValue<System.Guid>();
				break;
				case "LeadId":
					if (!hasValueToRead) break;
					LeadId = reader.GetValue<System.Guid>();
				break;
				case "ActivityOwner":
					if (!hasValueToRead) break;
					ActivityOwner = reader.GetValue<System.Guid>();
				break;
				case "AccountId":
					if (!hasValueToRead) break;
					AccountId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
				bool priceWithTaxes = BPMSoft.Core.Configuration.SysSettings.GetValue<bool>(UserConnection, "PriceWithTaxes",
					false);
				decimal taxPercent;
				decimal taxAmount;
				decimal totalAmount;
				ProductPriceDataRepository productPriceDataRepository = new ProductPriceDataRepository(UserConnection);
				var priceListFromSysSetting = BPMSoft.Core.Configuration.SysSettings.GetValue<Guid>(UserConnection, "BasePriceList",
					default(Guid));
				Guid preSetPriceList = default(Guid);
				ProductPriceData productPriceData = new ProductPriceData();
				var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager.GetInstanceByName("LeadProduct"));
				esq.AddColumn("Product.Name");
				esq.AddColumn("Product.Unit");
				esq.AddColumn("Product.Tax");
				esq.AddColumn("Product.Tax.Percent");
				esq.AddColumn("Product.Price");
				esq.AddColumn("Product.Id");
				esq.AddColumn("Product.Currency");
				esq.AddColumn("Product");
				esq.AddColumn("[ProductUnit:Product:Product].NumberOfBaseUnits");
				esq.AddColumn("[ProductUnit:Product:Product].Unit");
				esq.Filters.Add(esq.CreateFilterWithParameters(
					FilterComparisonType.Equal, "Lead", LeadId));
				var products = esq.GetEntityCollection(UserConnection);
				if (products.Count > 0) {
					var isPriceListsEnabled = UserConnection.GetIsFeatureEnabled("UsePriceListsLogic");
					if (isPriceListsEnabled) {
						var priceListPicker = ClassFactory.Get<IPriceListPicker>(new ConstructorArgument("userConnection", 
							UserConnection));
						if (AccountId != default(Guid)) {
							preSetPriceList = priceListPicker.GetPriceList(AccountId);
						}
						if (preSetPriceList == default(Guid) && UserConnection.CurrentUser.AccountId != default(Guid)) {
							preSetPriceList = priceListPicker.GetPriceList(UserConnection.CurrentUser.AccountId);
						}
						if (preSetPriceList != default(Guid) || priceListFromSysSetting != default(Guid)) {
							productPriceDataRepository.Initialize(new List<Guid> { preSetPriceList, priceListFromSysSetting },
							products.Select(product => product.GetTypedColumnValue<Guid>("Product_Id")).ToList());
						}
					}
					var entitySchemaManager = UserConnection.EntitySchemaManager;
					var primaryCurrencyId = BPMSoft.Core.Configuration.SysSettings.GetValue<Guid>(UserConnection, 
						"PrimaryCurrency", Guid.Empty);
					var currencyRateStorage = ClassFactory.Get<CurrencyRateStorage>(new ConstructorArgument("userConnection", 
						UserConnection));
					var currencyRateConverter = ClassFactory.Get<CurrencyConverter>(new ConstructorArgument("currenciesRateStorage", 
						currencyRateStorage));
					var orderProductSchema = entitySchemaManager.GetInstanceByName("OrderProduct");
					var currentUserDateTime = UserConnection.CurrentUser.GetCurrentDateTime();
					foreach (var product in products) {
						bool IsNeedToTakePriceFromPriceList = isPriceListsEnabled && (preSetPriceList != default(Guid) || priceListFromSysSetting != default(Guid))
							&& productPriceDataRepository.TryGetProductPriceData(product.GetTypedColumnValue<Guid>("Product_Id"), out productPriceData);
						Guid productCurrencyId = IsNeedToTakePriceFromPriceList ? productPriceData.CurrencyId : product.GetTypedColumnValue<Guid>("Product_CurrencyId");
						decimal price = IsNeedToTakePriceFromPriceList ? productPriceData.Price : product.GetTypedColumnValue<decimal>("Product_Price");
						if (!productCurrencyId.Equals(primaryCurrencyId)) {
							price = currencyRateConverter.GetConvertedAmountToCurrency(productCurrencyId, 
								primaryCurrencyId, price, currentUserDateTime);
						}
						taxPercent = IsNeedToTakePriceFromPriceList ? productPriceData.TaxPercent : (decimal)product.GetColumnValue("Product_Tax_Percent");
						var orderProductEntity = orderProductSchema.CreateEntity(UserConnection);
						orderProductEntity.SetColumnValue("Name", product.GetTypedColumnValue<string>("Product_Name"));
						orderProductEntity.SetColumnValue("ProductId", product.GetTypedColumnValue<Guid>("Product_Id"));
						orderProductEntity.SetColumnValue("UnitId", product.GetTypedColumnValue<Guid>("ProductUnit_Product_Product_UnitId"));
						orderProductEntity.SetColumnValue("BaseQuantity", product.GetTypedColumnValue<decimal>("ProductUnit_Product_Product_NumberOfBaseUnits"));
						orderProductEntity.SetColumnValue("TaxId", IsNeedToTakePriceFromPriceList ? productPriceData.TaxId : product.GetTypedColumnValue<Guid>("Product_TaxId"));
						orderProductEntity.SetColumnValue("OrderId", NewOrder);
						orderProductEntity.SetColumnValue("Quantity", Decimal.One);
						orderProductEntity.SetColumnValue("PrimaryPrice", price);
						orderProductEntity.SetColumnValue("Price", price);
						orderProductEntity.SetColumnValue("Amount", price);
						orderProductEntity.SetColumnValue("PrimaryAmount", price);
						orderProductEntity.SetColumnValue("DiscountAmount", 0);
						orderProductEntity.SetColumnValue("CurrencyId", primaryCurrencyId);
						orderProductEntity.SetColumnValue("CurrencyRate", 1);
						orderProductEntity.SetColumnValue("DiscountTax", taxPercent);
						if (IsNeedToTakePriceFromPriceList) {
							orderProductEntity.SetColumnValue("PriceListId", productPriceData.PriceListId);
						}
						if (priceWithTaxes) {
							orderProductEntity.SetColumnValue("PrimaryTotalAmount", price);
							orderProductEntity.SetColumnValue("TotalAmount", price);
							taxAmount = (taxPercent * price) / (100 + taxPercent);
						} else {
							taxAmount = (price * taxPercent) / 100;
							totalAmount = price + taxAmount;
							orderProductEntity.SetColumnValue("PrimaryTotalAmount", totalAmount);
							orderProductEntity.SetColumnValue("TotalAmount", totalAmount);
						}
						orderProductEntity.SetColumnValue("TaxAmount", taxAmount);
						if (!productCurrencyId.Equals(primaryCurrencyId)) {
							decimal primaryTaxAmount = currencyRateConverter.GetConvertedAmountToCurrency(
								primaryCurrencyId, productCurrencyId, taxAmount, currentUserDateTime);
							orderProductEntity.SetColumnValue("PrimaryTaxAmount", primaryTaxAmount);
						} else {
							orderProductEntity.SetColumnValue("PrimaryTaxAmount", taxAmount);
						}
						orderProductEntity.Save(false);
					}
				}
			return true;
		}

		public virtual bool FormulaTask1Execute(ProcessExecutingContext context) {
			var localNewOrder = (AddDataUserTask1.RecordId);
			NewOrder = (System.Guid)localNewOrder;
			return true;
		}

		public virtual bool FormulaTask2Execute(ProcessExecutingContext context) {
			var localActivityOwner = ((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty));
			ActivityOwner = (System.Guid)localActivityOwner;
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
			var cloneItem = (LeadManagementProceedToOrder)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

