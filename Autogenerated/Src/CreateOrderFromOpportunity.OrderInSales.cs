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

	#region Class: CreateOrderFromOpportunitySchema

	/// <exclude/>
	public class CreateOrderFromOpportunitySchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CreateOrderFromOpportunitySchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CreateOrderFromOpportunitySchema(CreateOrderFromOpportunitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CreateOrderFromOpportunity";
			UId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5");
			CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"CreateOrderFromOpportunity";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5");
			Version = 0;
			PackageUId = new Guid("b8e3670d-40ce-4674-8aa5-3d4805a5932d");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCurrentOpportunityParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("515496b8-401a-4a70-b54d-64bfd7124238"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNewOrderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d828a3fe-e2a4-4160-a91c-92ab92b04cfc"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"NewOrder",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateProductItemsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6c324739-8a48-4082-998b-fa670868c7ce"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"ProductItems",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsCopyAllProductParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d7f0950e-8bc1-4a4d-b695-906d525716a4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"IsCopyAllProduct",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCurrentOpportunityParameter());
			Parameters.Add(CreateNewOrderParameter());
			Parameters.Add(CreateProductItemsParameter());
			Parameters.Add(CreateIsCopyAllProductParameter());
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e1d83148-df86-4cc1-810a-5310eb1688e8"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,143,155,48,16,253,43,21,231,245,138,15,27,226,220,218,52,173,114,104,19,41,171,189,148,61,12,48,36,86,1,35,219,108,155,70,249,239,181,33,75,179,43,212,166,189,116,57,193,227,205,155,55,95,71,47,175,64,235,207,80,163,55,247,222,109,62,109,101,105,110,63,136,202,160,250,168,100,215,122,55,158,70,37,160,18,63,176,24,240,101,33,204,123,48,96,3,142,233,175,248,212,155,167,83,10,169,119,147,122,194,96,173,45,195,6,100,192,129,151,28,8,103,88,18,90,150,33,1,202,98,18,248,156,209,220,103,212,167,197,192,156,150,94,200,186,5,133,67,134,94,188,236,95,239,14,173,35,6,22,200,123,138,208,178,57,131,145,179,160,151,13,100,21,58,113,163,58,180,144,81,162,182,149,224,157,168,113,3,202,102,114,58,210,65,150,84,66,165,29,171,194,210,44,191,183,10,181,22,178,249,189,181,170,171,155,75,174,13,199,241,243,108,198,239,29,58,230,6,204,190,23,88,89,83,167,222,227,219,221,78,225,14,140,120,188,180,240,21,15,61,239,186,222,217,128,194,206,231,30,170,14,47,114,62,175,99,1,173,25,202,25,210,91,130,18,187,253,149,149,142,221,250,83,177,161,5,219,39,242,85,138,147,254,195,216,130,143,14,24,52,158,94,83,239,203,74,175,191,53,168,182,249,30,107,24,58,246,112,107,209,23,192,168,63,63,178,128,81,30,103,51,66,253,0,8,133,196,39,25,163,5,137,105,86,22,73,16,210,48,154,157,30,6,31,66,183,21,28,238,199,116,139,78,41,108,204,27,217,182,82,153,174,17,230,208,19,93,11,237,239,50,129,36,202,130,132,216,65,80,66,115,86,16,72,56,35,60,200,56,22,5,99,121,156,219,81,187,199,77,68,238,68,14,213,186,69,101,39,222,119,220,159,222,212,103,43,238,122,161,164,52,67,133,99,39,215,47,44,141,75,147,135,51,164,69,68,2,74,35,66,121,144,19,206,67,36,0,60,142,146,50,102,49,13,172,39,123,233,174,235,91,217,169,252,124,93,122,56,241,127,58,222,255,112,148,127,115,105,147,187,126,205,246,190,150,205,92,189,178,133,59,121,167,159,225,88,21,227,77,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3898f5c3-ee0f-45d0-95ac-9cd9a0d94564"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cea4bbf0-8f34-4f22-ab35-9a44c8f81e1e"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f5a484b3-8778-45a8-abde-f587d34577ef"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ebe4df04-3e0e-419e-833f-8e94cd7d6497"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c2db847b-3042-4668-bddd-dc4935ba4078"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f824e334-f632-4f09-a820-7cf5de24447a"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("9809e6b3-5ddb-4caf-aa53-a91b85840985"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2d44e8b3-9be9-44d9-989e-801007f332a2"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("af44f78e-77ce-4e84-89aa-a4a8589acaca"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a3bbda1d-938c-4804-bae7-3e6727495500"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d90e7819-b5bb-4322-b1a1-688430cac361"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("adbeddd4-1b47-439f-b56f-eaf1ce7c22bd"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("1f3ec804-485b-4fb7-ba6c-b97ab3bcb1a8"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("44077e26-c243-4885-bf41-802b99ca00f2"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("87d3453d-f7b9-41d7-953c-1ce1e1ade596"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8e68ae20-c6e7-4bff-bc6f-c7c1e2476fe2"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a15e8fcf-ba82-439f-bb6f-99ba54972dbc"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("832f2f71-b292-40cd-aa19-4b7009297b25"),
				ContainerUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeOpenEditPageUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var objectSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("4fb1e2ff-2cc4-4788-bae0-e74102fa14e8"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(objectSchemaIdParameter);
			var pageSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("30aa1c24-3e58-45a3-a546-cdf3bedb9b62"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(pageSchemaIdParameter);
			var editModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c831eecc-a5e6-4e9b-8f0a-6d639e5e35fb"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(editModeParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("874c268f-6319-4d17-ad59-f40c4f774b05"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				UId = new Guid("01172481-a565-47df-a5be-cb9da2fc12a3"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d828a3fe-e2a4-4160-a91c-92ab92b04cfc}]#]",
				MetaPath = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d828a3fe-e2a4-4160-a91c-92ab92b04cfc}]#]",
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var executedModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("30f2bca3-c96e-4e5c-88c8-085b0ae8cf0d"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("1408b6b8-cf8c-4425-b12e-fbad9c403b3d"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c7f158e2-218b-4b9f-8725-909927e9b8b5"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var generateDecisionsFromColumnParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3d20f3f7-5984-43c4-9f1d-394a5d9dc018"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(generateDecisionsFromColumnParameter);
			var decisionalColumnMetaPathParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e46b1b8b-1819-4789-a14f-65ddf3741c3b"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(decisionalColumnMetaPathParameter);
			var resultParameterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ab96af1a-57c8-4824-96f8-6ba447e62e14"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("2450b4ac-bc00-4be2-9f76-e7e372ca7f07"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("67908e65-2f58-45f9-983b-2c1da6379cd5"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("4dea05bc-b597-4eb2-8f8e-707838c63a9e"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("08b712e2-4919-4423-b244-28f0ab6e324e"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a4574b01-f7d9-4d5b-b3e8-504a67746654"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("69a2aa31-7c0d-4a87-9dba-2547b60626e5"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f9f8a922-41df-4718-9bb2-5709eef02ce4"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("d01eb000-e5aa-49b1-a95c-82a0dbd4a4a8"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("540dcd0c-778c-4a17-ac36-7def92eab44c"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("6ba4e133-0564-4f7f-91ad-971ae82a9e2d"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3e4d0ff6-c547-4b65-ad49-292460443cd8"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("73d80e1b-1dc6-4b92-92e4-c0ff21953dad"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("5d24cbb8-ba27-4390-9faf-4ac736c965fe"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("f6a640ee-aeff-4e52-a0ef-83b05ca53c8c"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("71ebff1e-d62b-43b6-9539-02c2dffd16a2"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("c29a5757-0505-47ee-b548-5293e3acbd89"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("d6fc85c9-a2f4-455e-b336-fa9b65be5720"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("13610d95-0021-419e-88ad-79b772cbba42"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("e4606663-de9c-46d9-8891-543f07160143"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("89f85502-0eb1-4d21-9eaa-96ebe6cf07ff"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("b9d6544d-94ae-49b4-af5c-ec4c5ed0dc76"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("30207a75-7e4e-4522-904b-474a8b804296"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("1c1730bc-905c-42f3-add5-b5767a8cc78c"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("251964b1-f33f-4a0d-bf37-4b2a62a2a899"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("29a2680c-fd32-4012-916a-2548fffff631"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(pageTypeUIdParameter);
			var activitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b9101517-77b1-4251-8334-6c0beefd8041"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("88dfbdf6-104a-448e-8a68-5256a4d8de7d"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("bcaeafa8-ef4e-4977-81f8-d000782ce97f"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("5da83713-07c4-4e79-9df3-1e7de802bcee"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("fa6dc17d-dd86-43d4-b71a-1d6b901489b5"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("eb233771-7ac3-4db6-aa21-e29355f9b0f1"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("975dc8f2-6321-4417-9c7b-bd02cf1f0781"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("b3793aa7-c2bf-4f7e-ba51-134097f27019"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("2d39a734-7bc1-4c2e-b145-d00733f01f98"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("e4f8491d-13aa-43d4-b1a6-366538d33a50"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("99c0a079-b569-486d-8118-2ff619216465"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("f79f50cc-a5b0-4573-8aae-10d177876838"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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
				UId = new Guid("b4a22b62-7433-4a38-ae5b-4996553676ea"),
				ContainerUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
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

		protected virtual void InitializeAddDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("c29c1ea2-c50d-4de5-ac66-516920f18b79"),
				ContainerUId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2a9808a0-acf6-420e-bba5-93f802478e80"),
				ContainerUId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("627ad3cd-7998-4ecb-b7bc-4e7f08515ed5"),
				ContainerUId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("87fa38ed-1e46-464b-bfb2-1adf9fb90a14"),
				ContainerUId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1644d055-35f1-46be-b85d-cbd5030192cb"),
				ContainerUId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,150,223,79,27,71,16,199,255,21,235,146,71,198,218,223,63,252,214,146,84,66,130,130,66,155,23,224,97,118,119,54,88,53,119,232,124,110,69,45,255,239,29,31,56,64,26,145,70,21,15,40,220,131,237,91,223,204,236,204,125,63,59,179,110,222,14,55,215,212,204,154,159,79,142,78,187,58,76,247,187,158,166,39,125,151,105,185,156,30,118,25,23,243,191,49,45,232,4,123,188,162,129,250,143,184,88,209,242,112,190,28,246,38,15,141,154,189,230,237,159,227,127,205,236,108,221,28,12,116,245,251,65,97,207,78,8,25,181,49,16,101,12,96,164,140,144,130,246,224,138,211,197,123,37,165,138,108,156,187,197,234,170,61,162,1,79,112,184,108,102,235,102,244,198,14,178,23,66,148,172,33,6,36,48,213,27,64,163,9,124,160,104,163,19,38,179,131,205,94,179,204,151,116,133,99,208,123,227,32,84,52,54,40,16,46,89,54,70,4,12,182,130,214,74,147,181,218,37,47,183,198,119,207,223,27,158,189,57,59,88,30,255,213,82,127,58,250,157,85,92,44,233,98,202,171,95,44,188,95,208,21,181,195,108,157,29,121,99,115,4,114,129,99,81,206,16,10,255,10,82,5,165,171,51,42,200,13,27,124,174,229,108,29,131,136,228,146,6,91,74,2,147,177,2,162,213,128,81,166,96,131,17,49,216,173,201,251,118,152,15,55,251,99,141,102,107,147,162,37,93,43,212,98,21,24,36,9,73,160,5,149,173,20,188,46,45,250,205,197,155,139,109,98,101,190,188,94,224,205,199,127,231,247,129,176,76,186,235,235,174,31,86,45,123,159,20,28,112,250,203,188,95,14,147,57,191,190,73,87,39,61,45,87,139,97,222,126,154,240,251,89,80,30,230,93,59,253,41,231,110,213,14,183,254,175,31,9,227,97,132,245,249,173,186,206,155,217,249,215,245,117,247,125,91,207,199,10,123,44,174,243,102,239,188,57,237,86,125,222,122,211,124,243,238,65,90,99,128,241,145,47,110,119,106,226,149,118,181,88,220,173,188,227,52,119,15,238,150,187,50,175,115,42,7,237,233,78,68,163,23,22,222,120,193,87,62,118,215,237,222,254,143,217,17,182,248,137,250,95,57,253,251,189,127,222,229,111,92,194,157,227,164,162,21,94,86,240,132,145,21,230,20,43,76,226,22,173,84,181,215,170,86,53,90,127,160,74,61,181,153,30,111,76,217,226,179,196,4,178,144,0,99,5,11,199,8,134,67,145,32,22,141,42,238,182,214,31,104,57,86,123,139,241,221,190,182,165,218,52,155,205,222,67,184,75,116,5,75,149,96,34,35,109,18,41,136,49,36,200,170,42,178,82,37,143,226,73,184,125,37,97,176,58,168,62,111,29,36,206,200,72,13,201,217,130,145,76,213,58,255,88,112,35,191,10,14,132,144,77,220,38,69,30,80,199,2,26,147,87,124,230,73,39,159,19,238,131,242,202,245,139,227,26,201,184,154,130,135,44,84,222,54,132,0,88,180,100,165,41,157,75,137,209,228,250,93,92,59,85,29,161,51,32,42,183,25,227,81,67,224,78,13,46,22,172,49,84,235,180,122,146,235,90,180,224,214,28,64,234,194,93,31,11,55,109,103,4,119,44,212,62,160,55,46,234,231,224,250,176,235,254,88,93,79,115,174,40,72,18,100,95,25,61,101,37,132,154,50,36,27,73,4,233,171,167,50,69,235,109,228,10,129,83,84,56,140,142,16,172,245,80,178,114,206,7,155,173,167,111,113,118,23,239,184,47,212,79,242,37,182,45,45,166,199,247,220,189,194,244,226,96,250,47,218,249,62,152,200,70,233,37,139,159,60,143,107,142,103,225,160,120,107,34,186,136,178,162,203,242,233,9,56,80,224,86,193,45,33,20,158,123,77,206,2,98,78,8,202,56,167,117,20,74,186,31,108,2,118,6,133,77,21,65,91,193,232,150,84,33,85,62,104,106,178,62,242,233,194,44,211,51,54,201,253,174,29,48,191,78,192,47,15,110,233,18,105,55,34,205,179,170,145,150,207,252,82,4,35,33,116,49,46,232,82,244,183,224,190,216,252,3,194,248,140,11,56,15,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e61c73fa-a1cd-4ced-8c2f-a8a753e62a94"),
				ContainerUId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7"),
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
				UId = new Guid("a45e951d-fb18-4f4c-877e-3ad634d94c8b"),
				ContainerUId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7"),
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
				UId = new Guid("ad435e49-6d29-49c1-b37f-07b4169035df"),
				ContainerUId = new Guid("4c37bea9-eca9-46f6-a1ba-ae64d00de7d7"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f8ee27e9-0fe2-4341-8e23-4267f53b9416"),
				ContainerUId = new Guid("4c37bea9-eca9-46f6-a1ba-ae64d00de7d7"),
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
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a050532e-2c9a-4f51-81bb-cf840e62ef62"),
				ContainerUId = new Guid("4c37bea9-eca9-46f6-a1ba-ae64d00de7d7"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,75,111,211,64,16,254,43,145,207,108,181,126,175,115,131,18,80,36,160,21,173,122,169,123,24,175,199,233,138,245,67,235,77,33,68,254,239,204,218,105,90,218,180,84,61,32,36,78,89,127,153,199,55,51,223,204,214,147,26,250,254,11,212,232,205,189,119,167,159,207,218,202,30,125,80,218,162,249,104,218,117,231,189,241,122,52,10,180,250,137,229,132,47,74,101,223,131,5,114,216,230,119,254,185,55,207,15,69,200,189,55,185,167,44,214,61,89,144,67,22,136,216,23,62,50,158,38,5,139,170,84,176,34,133,144,201,132,203,34,12,56,47,132,63,89,30,14,189,108,166,224,99,220,106,124,158,111,58,103,19,17,32,219,186,3,163,250,182,217,129,161,203,222,47,26,40,52,150,244,109,205,26,9,178,70,213,84,4,158,171,26,79,193,80,18,23,167,117,208,157,145,198,202,46,126,116,6,251,94,181,205,115,164,142,91,189,174,155,251,182,228,142,251,207,29,23,62,18,116,150,167,96,175,199,0,39,93,215,26,187,110,148,221,228,222,48,114,125,187,90,25,92,129,85,55,206,167,2,221,59,46,223,112,51,58,188,172,125,228,80,210,136,46,64,175,113,151,220,231,143,42,58,134,206,78,133,61,32,66,150,6,43,52,216,72,60,147,215,88,195,190,226,71,118,106,117,125,47,164,27,242,229,147,109,218,119,250,79,157,10,8,236,110,141,159,107,252,62,226,193,154,131,132,192,27,7,76,49,110,159,185,119,185,236,79,190,55,104,166,234,166,46,95,29,17,250,0,88,104,172,177,177,243,173,76,48,141,98,153,49,76,68,204,34,148,146,137,146,94,194,15,68,16,86,73,20,8,127,32,135,61,161,249,54,19,60,195,164,8,89,92,150,52,42,9,21,3,136,67,6,153,95,136,88,68,60,19,177,115,89,52,150,186,57,73,104,190,5,228,72,137,128,201,40,163,68,21,166,12,194,172,100,33,20,105,144,10,244,19,63,29,174,166,114,85,223,105,216,92,236,171,250,138,80,206,218,187,9,205,92,67,104,25,77,111,103,110,5,103,109,53,163,70,175,181,85,205,106,70,82,212,40,157,2,142,150,229,24,208,253,56,141,65,74,82,170,4,139,51,136,88,196,75,162,16,4,17,43,98,159,248,7,156,254,142,73,173,195,112,53,56,201,234,118,165,36,232,147,14,13,236,244,196,15,111,221,111,235,234,102,99,218,214,62,16,216,39,170,97,36,115,171,248,56,43,227,170,74,57,43,83,106,122,132,65,193,32,1,206,162,132,11,153,6,97,150,38,130,216,208,165,114,213,158,181,107,35,113,58,17,253,116,162,94,117,124,254,254,101,121,213,185,120,98,253,94,178,80,255,217,178,44,255,25,109,15,222,240,11,137,125,174,164,120,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a9bdd0c6-ef02-470d-918b-9984c37e8456"),
				ContainerUId = new Guid("4c37bea9-eca9-46f6-a1ba-ae64d00de7d7"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,114,155,48,20,252,21,143,146,163,229,145,144,0,137,99,147,30,60,19,167,158,186,205,37,246,225,73,122,106,60,131,193,3,184,153,148,225,223,43,99,136,237,52,183,234,0,163,229,237,190,213,211,210,146,219,230,109,143,36,35,95,150,139,85,233,155,217,93,89,225,108,89,149,22,235,122,246,80,90,200,183,127,192,228,184,132,10,118,216,96,245,4,249,1,235,135,109,221,76,39,151,36,50,37,183,191,251,111,36,123,110,201,188,193,221,207,185,11,202,105,36,180,148,32,104,156,170,148,74,30,75,106,56,51,148,43,72,65,114,6,94,187,64,182,101,126,216,21,11,108,96,9,205,11,201,90,210,171,5,129,196,89,199,4,147,20,141,75,168,68,198,169,114,76,211,20,53,162,211,177,85,14,73,55,37,181,125,193,29,244,77,207,100,201,193,43,141,161,58,14,61,37,26,67,149,5,75,189,23,218,36,82,73,142,246,72,30,234,207,196,231,155,231,121,253,237,181,192,106,213,235,102,30,242,26,55,179,128,126,0,190,230,184,195,162,201,90,167,21,83,202,199,84,70,154,81,25,90,80,80,86,81,72,77,18,105,31,139,196,166,93,32,188,207,50,107,49,225,54,21,30,40,112,235,168,180,232,130,189,200,7,30,164,177,192,36,2,45,187,205,205,230,104,209,109,235,125,14,111,79,255,58,125,196,215,73,89,57,172,102,119,21,66,131,110,82,161,13,192,100,238,78,212,253,213,237,93,146,219,245,41,2,107,146,173,63,15,193,240,62,29,250,58,6,215,9,88,147,233,154,172,202,67,101,143,106,34,108,238,47,28,247,13,250,146,15,219,241,202,3,82,28,242,124,64,238,161,129,177,112,132,75,183,245,91,116,243,98,53,222,116,175,194,134,69,63,121,140,235,228,237,127,104,11,40,224,23,86,143,225,248,103,239,239,46,127,132,17,142,194,38,210,49,75,185,15,1,5,29,34,151,68,33,175,28,168,230,218,120,145,138,200,251,168,103,127,71,143,21,22,22,175,141,41,22,105,25,171,136,178,196,132,44,121,8,233,80,177,167,66,68,2,227,144,34,147,242,129,95,247,211,62,254,107,131,175,227,168,58,210,117,155,238,47,190,244,187,218,219,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1cf407c8-8982-4a40-84a9-c214579d1cc1"),
				ContainerUId = new Guid("4c37bea9-eca9-46f6-a1ba-ae64d00de7d7"),
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
			ProcessSchemaStartEvent startbusinessprocess = CreateStartBusinessProcessStartEvent();
			FlowElements.Add(startbusinessprocess);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaScriptTask copyproductscripttask = CreateCopyProductScriptTaskScriptTask();
			FlowElements.Add(copyproductscripttask);
			ProcessSchemaTerminateEvent terminate2 = CreateTerminate2TerminateEvent();
			FlowElements.Add(terminate2);
			ProcessSchemaUserTask openeditpageusertask1 = CreateOpenEditPageUserTask1UserTask();
			FlowElements.Add(openeditpageusertask1);
			ProcessSchemaUserTask adddatausertask1 = CreateAddDataUserTask1UserTask();
			FlowElements.Add(adddatausertask1);
			ProcessSchemaUserTask changedatausertask1 = CreateChangeDataUserTask1UserTask();
			FlowElements.Add(changedatausertask1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("e547bf8f-5a9b-4973-836c-fa05e0c51a0f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5afbdb3d-b891-4182-a1de-b0b6cd7afbb5"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6d5433e0-f6f4-4777-b1a7-0a61b5f39bca"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("e47d7853-ced5-43da-a7db-fd3385011ab1"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{515496b8-401a-4a70-b54d-64bfd7124238}]#]== Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				CurveCenterPosition = new Point(202, 122),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6d5433e0-f6f4-4777-b1a7-0a61b5f39bca"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a7eafc6e-049d-4a84-90b6-6ed571fef54e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("55f5bf80-a21a-4643-9564-9d88b48ef8a5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				CurveCenterPosition = new Point(438, 300),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow3",
				UId = new Guid("589ffe59-36f0-4ca1-a22c-97cb3e65f133"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				CurveCenterPosition = new Point(282, 206),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6d5433e0-f6f4-4777-b1a7-0a61b5f39bca"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("1ec6908e-e69c-424f-9c8c-d14758de5c50"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				CurveCenterPosition = new Point(708, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0fba4b88-d25b-42b4-9c15-bd0a670ee85a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("87083a40-d9d4-4976-aa29-e3be8bc53d5e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("4cb57c2d-2023-4f58-87a5-9a9bfc3c9e3c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				CurveCenterPosition = new Point(846, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("87083a40-d9d4-4976-aa29-e3be8bc53d5e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4c37bea9-eca9-46f6-a1ba-ae64d00de7d7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("a865471d-c404-4675-9fa5-733f6f1e378a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				CurveCenterPosition = new Point(846, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2e20440b-bd9c-4844-8378-0cd290e3bd3b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("bfd2a0e9-ab44-4ff1-92dd-dacb801c9d9d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("11b832b1-75bb-4c0d-bb5d-5aa5088efe52"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				CurveCenterPosition = new Point(438, 300),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0fba4b88-d25b-42b4-9c15-bd0a670ee85a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("f2263e84-a07c-46fe-9fcb-c50b6a8f03d1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("b6fb0ad3-6ee4-4e3f-a948-15ac8ee3c7f4"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				CurveCenterPosition = new Point(846, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4c37bea9-eca9-46f6-a1ba-ae64d00de7d7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("9572b96f-ef1d-462d-8516-9a36c0b9a189"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("9572b96f-ef1d-462d-8516-9a36c0b9a189"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartBusinessProcessStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("5afbdb3d-b891-4182-a1de-b0b6cd7afbb5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"StartBusinessProcess",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("a7eafc6e-049d-4a84-90b6-6ed571fef54e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"Terminate1",
				Position = new Point(155, 37),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("6d5433e0-f6f4-4777-b1a7-0a61b5f39bca"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"ExclusiveGateway1",
				Position = new Point(141, 170),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"ReadDataUserTask1",
				Position = new Point(295, 170),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("0fba4b88-d25b-42b4-9c15-bd0a670ee85a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"FormulaTask1",
				Position = new Point(568, 170),
				ResultParameterMetaPath = @"d828a3fe-e2a4-4160-a91c-92ab92b04cfc",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,173,14,131,48,16,0,224,135,65,223,2,253,111,253,4,106,75,38,73,197,237,122,151,9,138,40,36,19,132,119,95,245,236,151,124,203,176,204,251,227,187,113,123,209,135,43,38,193,117,231,124,235,250,7,247,149,43,111,71,58,75,12,99,8,98,193,168,56,130,17,209,128,129,2,160,127,59,21,197,106,71,254,234,225,137,13,43,31,220,210,201,110,34,175,5,1,39,42,96,136,11,4,82,210,31,122,171,217,41,140,230,202,67,254,1,206,164,124,32,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateCopyProductScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("87083a40-d9d4-4976-aa29-e3be8bc53d5e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"CopyProductScriptTask",
				Position = new Point(701, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,65,110,131,64,12,60,19,41,127,216,114,2,41,226,3,105,42,165,168,169,56,180,68,74,251,0,4,6,173,4,107,228,245,54,69,77,254,94,47,164,21,141,114,232,209,227,25,123,60,214,181,138,246,132,149,43,57,99,232,108,242,134,7,38,109,154,40,86,119,27,21,134,234,116,82,153,77,177,31,182,109,123,97,198,234,107,185,8,62,10,82,165,224,23,208,230,61,80,193,26,141,218,168,93,81,50,146,6,155,164,109,97,237,84,14,201,51,240,189,40,131,199,253,203,1,107,78,82,52,181,110,220,36,147,170,31,114,170,128,126,38,238,8,187,188,239,145,216,25,205,195,239,130,135,200,15,49,112,156,239,65,99,153,68,133,180,165,198,117,96,56,10,157,5,146,134,129,210,203,194,149,122,255,3,196,241,90,6,221,188,33,121,250,132,210,49,68,126,203,77,187,222,194,255,45,223,102,139,83,59,102,25,4,51,81,86,73,130,169,35,146,27,102,240,106,226,121,253,200,120,133,227,88,76,248,245,143,172,48,174,177,137,57,127,183,144,230,165,244,207,62,147,243,114,65,192,142,140,146,72,97,253,13,40,121,21,3,37,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate2TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("2e20440b-bd9c-4844-8378-0cd290e3bd3b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"Terminate2",
				Position = new Point(1044, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateOpenEditPageUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Task",
				EntitySchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"OpenEditPageUserTask1",
				Position = new Point(939, 170),
				SchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenEditPageUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("11b832b1-75bb-4c0d-bb5d-5aa5088efe52"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"AddDataUserTask1",
				Position = new Point(428, 170),
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
				UId = new Guid("4c37bea9-eca9-46f6-a1ba-ae64d00de7d7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11dc7f42-4bda-4a8f-96ab-9846636adc43"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("b6fb0ad3-6ee4-4e3f-a948-15ac8ee3c7f4"),
				CreatedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"),
				Name = @"ChangeDataUserTask1",
				Position = new Point(820, 170),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CreateOrderFromOpportunity(userConnection);
		}

		public override object Clone() {
			return new CreateOrderFromOpportunitySchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5"));
		}

		#endregion

	}

	#endregion

	#region Class: CreateOrderFromOpportunity

	/// <exclude/>
	public class CreateOrderFromOpportunity : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CreateOrderFromOpportunity process)
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, CreateOrderFromOpportunity process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("c6e745c9-e685-4ecc-8d85-812823f64281");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,143,155,48,16,253,43,21,231,245,138,15,27,226,220,218,52,173,114,104,19,41,171,189,148,61,12,48,36,86,1,35,219,108,155,70,249,239,181,33,75,179,43,212,166,189,116,57,193,227,205,155,55,95,71,47,175,64,235,207,80,163,55,247,222,109,62,109,101,105,110,63,136,202,160,250,168,100,215,122,55,158,70,37,160,18,63,176,24,240,101,33,204,123,48,96,3,142,233,175,248,212,155,167,83,10,169,119,147,122,194,96,173,45,195,6,100,192,129,151,28,8,103,88,18,90,150,33,1,202,98,18,248,156,209,220,103,212,167,197,192,156,150,94,200,186,5,133,67,134,94,188,236,95,239,14,173,35,6,22,200,123,138,208,178,57,131,145,179,160,151,13,100,21,58,113,163,58,180,144,81,162,182,149,224,157,168,113,3,202,102,114,58,210,65,150,84,66,165,29,171,194,210,44,191,183,10,181,22,178,249,189,181,170,171,155,75,174,13,199,241,243,108,198,239,29,58,230,6,204,190,23,88,89,83,167,222,227,219,221,78,225,14,140,120,188,180,240,21,15,61,239,186,222,217,128,194,206,231,30,170,14,47,114,62,175,99,1,173,25,202,25,210,91,130,18,187,253,149,149,142,221,250,83,177,161,5,219,39,242,85,138,147,254,195,216,130,143,14,24,52,158,94,83,239,203,74,175,191,53,168,182,249,30,107,24,58,246,112,107,209,23,192,168,63,63,178,128,81,30,103,51,66,253,0,8,133,196,39,25,163,5,137,105,86,22,73,16,210,48,154,157,30,6,31,66,183,21,28,238,199,116,139,78,41,108,204,27,217,182,82,153,174,17,230,208,19,93,11,237,239,50,129,36,202,130,132,216,65,80,66,115,86,16,72,56,35,60,200,56,22,5,99,121,156,219,81,187,199,77,68,238,68,14,213,186,69,101,39,222,119,220,159,222,212,103,43,238,122,161,164,52,67,133,99,39,215,47,44,141,75,147,135,51,164,69,68,2,74,35,66,121,144,19,206,67,36,0,60,142,146,50,102,49,13,172,39,123,233,174,235,91,217,169,252,124,93,122,56,241,127,58,222,255,112,148,127,115,105,147,187,126,205,246,190,150,205,92,189,178,133,59,121,167,159,225,88,21,227,77,6,0,0 })));
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

		#region Class: OpenEditPageUserTask1FlowElement

		/// <exclude/>
		public class OpenEditPageUserTask1FlowElement : OpenEditPageUserTask
		{

			#region Constructors: Public

			public OpenEditPageUserTask1FlowElement(UserConnection userConnection, CreateOrderFromOpportunity process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenEditPageUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("1512504c-d402-4646-a61b-a0c1ce3cdef6");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_recordId = () => (Guid)((process.NewOrder));
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

			#endregion

		}

		#endregion

		#region Class: AddDataUserTask1FlowElement

		/// <exclude/>
		public class AddDataUserTask1FlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddDataUserTask1FlowElement(UserConnection userConnection, CreateOrderFromOpportunity process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("d98088f5-4290-4ff3-a8c8-a7b629f536c7");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Account = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("AccountId") : Guid.Empty)));
				_recordDefValues_Opportunity = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
				_recordDefValues_SourceOrder = () => (Guid)(new Guid("a5759923-62ed-4f39-8557-dc266785c57e"));
				_recordDefValues_Contact = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Account", () => _recordDefValues_Account.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Opportunity", () => _recordDefValues_Opportunity.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_SourceOrder", () => _recordDefValues_SourceOrder.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Account;
			internal Func<Guid> _recordDefValues_Opportunity;
			internal Func<Guid> _recordDefValues_SourceOrder;
			internal Func<Guid> _recordDefValues_Contact;

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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,150,223,79,27,71,16,199,255,21,235,146,71,198,218,223,63,252,214,146,84,66,130,130,66,155,23,224,97,118,119,54,88,53,119,232,124,110,69,45,255,239,29,31,56,64,26,145,70,21,15,40,220,131,237,91,223,204,236,204,125,63,59,179,110,222,14,55,215,212,204,154,159,79,142,78,187,58,76,247,187,158,166,39,125,151,105,185,156,30,118,25,23,243,191,49,45,232,4,123,188,162,129,250,143,184,88,209,242,112,190,28,246,38,15,141,154,189,230,237,159,227,127,205,236,108,221,28,12,116,245,251,65,97,207,78,8,25,181,49,16,101,12,96,164,140,144,130,246,224,138,211,197,123,37,165,138,108,156,187,197,234,170,61,162,1,79,112,184,108,102,235,102,244,198,14,178,23,66,148,172,33,6,36,48,213,27,64,163,9,124,160,104,163,19,38,179,131,205,94,179,204,151,116,133,99,208,123,227,32,84,52,54,40,16,46,89,54,70,4,12,182,130,214,74,147,181,218,37,47,183,198,119,207,223,27,158,189,57,59,88,30,255,213,82,127,58,250,157,85,92,44,233,98,202,171,95,44,188,95,208,21,181,195,108,157,29,121,99,115,4,114,129,99,81,206,16,10,255,10,82,5,165,171,51,42,200,13,27,124,174,229,108,29,131,136,228,146,6,91,74,2,147,177,2,162,213,128,81,166,96,131,17,49,216,173,201,251,118,152,15,55,251,99,141,102,107,147,162,37,93,43,212,98,21,24,36,9,73,160,5,149,173,20,188,46,45,250,205,197,155,139,109,98,101,190,188,94,224,205,199,127,231,247,129,176,76,186,235,235,174,31,86,45,123,159,20,28,112,250,203,188,95,14,147,57,191,190,73,87,39,61,45,87,139,97,222,126,154,240,251,89,80,30,230,93,59,253,41,231,110,213,14,183,254,175,31,9,227,97,132,245,249,173,186,206,155,217,249,215,245,117,247,125,91,207,199,10,123,44,174,243,102,239,188,57,237,86,125,222,122,211,124,243,238,65,90,99,128,241,145,47,110,119,106,226,149,118,181,88,220,173,188,227,52,119,15,238,150,187,50,175,115,42,7,237,233,78,68,163,23,22,222,120,193,87,62,118,215,237,222,254,143,217,17,182,248,137,250,95,57,253,251,189,127,222,229,111,92,194,157,227,164,162,21,94,86,240,132,145,21,230,20,43,76,226,22,173,84,181,215,170,86,53,90,127,160,74,61,181,153,30,111,76,217,226,179,196,4,178,144,0,99,5,11,199,8,134,67,145,32,22,141,42,238,182,214,31,104,57,86,123,139,241,221,190,182,165,218,52,155,205,222,67,184,75,116,5,75,149,96,34,35,109,18,41,136,49,36,200,170,42,178,82,37,143,226,73,184,125,37,97,176,58,168,62,111,29,36,206,200,72,13,201,217,130,145,76,213,58,255,88,112,35,191,10,14,132,144,77,220,38,69,30,80,199,2,26,147,87,124,230,73,39,159,19,238,131,242,202,245,139,227,26,201,184,154,130,135,44,84,222,54,132,0,88,180,100,165,41,157,75,137,209,228,250,93,92,59,85,29,161,51,32,42,183,25,227,81,67,224,78,13,46,22,172,49,84,235,180,122,146,235,90,180,224,214,28,64,234,194,93,31,11,55,109,103,4,119,44,212,62,160,55,46,234,231,224,250,176,235,254,88,93,79,115,174,40,72,18,100,95,25,61,101,37,132,154,50,36,27,73,4,233,171,167,50,69,235,109,228,10,129,83,84,56,140,142,16,172,245,80,178,114,206,7,155,173,167,111,113,118,23,239,184,47,212,79,242,37,182,45,45,166,199,247,220,189,194,244,226,96,250,47,218,249,62,152,200,70,233,37,139,159,60,143,107,142,103,225,160,120,107,34,186,136,178,162,203,242,233,9,56,80,224,86,193,45,33,20,158,123,77,206,2,98,78,8,202,56,167,117,20,74,186,31,108,2,118,6,133,77,21,65,91,193,232,150,84,33,85,62,104,106,178,62,242,233,194,44,211,51,54,201,253,174,29,48,191,78,192,47,15,110,233,18,105,55,34,205,179,170,145,150,207,252,82,4,35,33,116,49,46,232,82,244,183,224,190,216,252,3,194,248,140,11,56,15,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "be82d4e046384058975d050a3dcff8b5",
							"BaseElements.AddDataUserTask1.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("b8e3670d-40ce-4674-8aa5-3d4805a5932d");
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

			public ChangeDataUserTask1FlowElement(UserConnection userConnection, CreateOrderFromOpportunity process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("4c37bea9-eca9-46f6-a1ba-ae64d00de7d7");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,75,111,211,64,16,254,43,145,207,108,181,126,175,115,131,18,80,36,160,21,173,122,169,123,24,175,199,233,138,245,67,235,77,33,68,254,239,204,218,105,90,218,180,84,61,32,36,78,89,127,153,199,55,51,223,204,214,147,26,250,254,11,212,232,205,189,119,167,159,207,218,202,30,125,80,218,162,249,104,218,117,231,189,241,122,52,10,180,250,137,229,132,47,74,101,223,131,5,114,216,230,119,254,185,55,207,15,69,200,189,55,185,167,44,214,61,89,144,67,22,136,216,23,62,50,158,38,5,139,170,84,176,34,133,144,201,132,203,34,12,56,47,132,63,89,30,14,189,108,166,224,99,220,106,124,158,111,58,103,19,17,32,219,186,3,163,250,182,217,129,161,203,222,47,26,40,52,150,244,109,205,26,9,178,70,213,84,4,158,171,26,79,193,80,18,23,167,117,208,157,145,198,202,46,126,116,6,251,94,181,205,115,164,142,91,189,174,155,251,182,228,142,251,207,29,23,62,18,116,150,167,96,175,199,0,39,93,215,26,187,110,148,221,228,222,48,114,125,187,90,25,92,129,85,55,206,167,2,221,59,46,223,112,51,58,188,172,125,228,80,210,136,46,64,175,113,151,220,231,143,42,58,134,206,78,133,61,32,66,150,6,43,52,216,72,60,147,215,88,195,190,226,71,118,106,117,125,47,164,27,242,229,147,109,218,119,250,79,157,10,8,236,110,141,159,107,252,62,226,193,154,131,132,192,27,7,76,49,110,159,185,119,185,236,79,190,55,104,166,234,166,46,95,29,17,250,0,88,104,172,177,177,243,173,76,48,141,98,153,49,76,68,204,34,148,146,137,146,94,194,15,68,16,86,73,20,8,127,32,135,61,161,249,54,19,60,195,164,8,89,92,150,52,42,9,21,3,136,67,6,153,95,136,88,68,60,19,177,115,89,52,150,186,57,73,104,190,5,228,72,137,128,201,40,163,68,21,166,12,194,172,100,33,20,105,144,10,244,19,63,29,174,166,114,85,223,105,216,92,236,171,250,138,80,206,218,187,9,205,92,67,104,25,77,111,103,110,5,103,109,53,163,70,175,181,85,205,106,70,82,212,40,157,2,142,150,229,24,208,253,56,141,65,74,82,170,4,139,51,136,88,196,75,162,16,4,17,43,98,159,248,7,156,254,142,73,173,195,112,53,56,201,234,118,165,36,232,147,14,13,236,244,196,15,111,221,111,235,234,102,99,218,214,62,16,216,39,170,97,36,115,171,248,56,43,227,170,74,57,43,83,106,122,132,65,193,32,1,206,162,132,11,153,6,97,150,38,130,216,208,165,114,213,158,181,107,35,113,58,17,253,116,162,94,117,124,254,254,101,121,213,185,120,98,253,94,178,80,255,217,178,44,255,25,109,15,222,240,11,137,125,174,164,120,7,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,114,155,48,20,252,21,143,146,163,229,145,144,0,137,99,147,30,60,19,167,158,186,205,37,246,225,73,122,106,60,131,193,3,184,153,148,225,223,43,99,136,237,52,183,234,0,163,229,237,190,213,211,210,146,219,230,109,143,36,35,95,150,139,85,233,155,217,93,89,225,108,89,149,22,235,122,246,80,90,200,183,127,192,228,184,132,10,118,216,96,245,4,249,1,235,135,109,221,76,39,151,36,50,37,183,191,251,111,36,123,110,201,188,193,221,207,185,11,202,105,36,180,148,32,104,156,170,148,74,30,75,106,56,51,148,43,72,65,114,6,94,187,64,182,101,126,216,21,11,108,96,9,205,11,201,90,210,171,5,129,196,89,199,4,147,20,141,75,168,68,198,169,114,76,211,20,53,162,211,177,85,14,73,55,37,181,125,193,29,244,77,207,100,201,193,43,141,161,58,14,61,37,26,67,149,5,75,189,23,218,36,82,73,142,246,72,30,234,207,196,231,155,231,121,253,237,181,192,106,213,235,102,30,242,26,55,179,128,126,0,190,230,184,195,162,201,90,167,21,83,202,199,84,70,154,81,25,90,80,80,86,81,72,77,18,105,31,139,196,166,93,32,188,207,50,107,49,225,54,21,30,40,112,235,168,180,232,130,189,200,7,30,164,177,192,36,2,45,187,205,205,230,104,209,109,235,125,14,111,79,255,58,125,196,215,73,89,57,172,102,119,21,66,131,110,82,161,13,192,100,238,78,212,253,213,237,93,146,219,245,41,2,107,146,173,63,15,193,240,62,29,250,58,6,215,9,88,147,233,154,172,202,67,101,143,106,34,108,238,47,28,247,13,250,146,15,219,241,202,3,82,28,242,124,64,238,161,129,177,112,132,75,183,245,91,116,243,98,53,222,116,175,194,134,69,63,121,140,235,228,237,127,104,11,40,224,23,86,143,225,248,103,239,239,46,127,132,17,142,194,38,210,49,75,185,15,1,5,29,34,151,68,33,175,28,168,230,218,120,145,138,200,251,168,103,127,71,143,21,22,22,175,141,41,22,105,25,171,136,178,196,132,44,121,8,233,80,177,167,66,68,2,227,144,34,147,242,129,95,247,211,62,254,107,131,175,227,168,58,210,117,155,238,47,190,244,187,218,219,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "be82d4e046384058975d050a3dcff8b5",
							"BaseElements.ChangeDataUserTask1.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("b8e3670d-40ce-4674-8aa5-3d4805a5932d");
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

		public CreateOrderFromOpportunity(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CreateOrderFromOpportunity";
			SchemaUId = new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("be82d4e0-4638-4058-975d-050a3dcff8b5");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CreateOrderFromOpportunity, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CreateOrderFromOpportunity, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid CurrentOpportunity {
			get;
			set;
		}

		public virtual Guid NewOrder {
			get;
			set;
		}

		public virtual string ProductItems {
			get;
			set;
		}

		public virtual bool IsCopyAllProduct {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _startBusinessProcess;
		public ProcessFlowElement StartBusinessProcess {
			get {
				return _startBusinessProcess ?? (_startBusinessProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartBusinessProcess",
					SchemaElementUId = new Guid("5afbdb3d-b891-4182-a1de-b0b6cd7afbb5"),
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
					SchemaElementUId = new Guid("a7eafc6e-049d-4a84-90b6-6ed571fef54e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("6d5433e0-f6f4-4777-b1a7-0a61b5f39bca"),
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

		private ProcessScriptTask _formulaTask1;
		public ProcessScriptTask FormulaTask1 {
			get {
				return _formulaTask1 ?? (_formulaTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask1",
					SchemaElementUId = new Guid("0fba4b88-d25b-42b4-9c15-bd0a670ee85a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask1Execute,
				});
			}
		}

		private ProcessScriptTask _copyProductScriptTask;
		public ProcessScriptTask CopyProductScriptTask {
			get {
				return _copyProductScriptTask ?? (_copyProductScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CopyProductScriptTask",
					SchemaElementUId = new Guid("87083a40-d9d4-4976-aa29-e3be8bc53d5e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = CopyProductScriptTaskExecute,
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
					SchemaElementUId = new Guid("2e20440b-bd9c-4844-8378-0cd290e3bd3b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private OpenEditPageUserTask1FlowElement _openEditPageUserTask1;
		public OpenEditPageUserTask1FlowElement OpenEditPageUserTask1 {
			get {
				return _openEditPageUserTask1 ?? (_openEditPageUserTask1 = new OpenEditPageUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("e47d7853-ced5-43da-a7db-fd3385011ab1"),
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
			FlowElements[StartBusinessProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { StartBusinessProcess };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[CopyProductScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CopyProductScriptTask };
			FlowElements[Terminate2.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate2 };
			FlowElements[OpenEditPageUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenEditPageUserTask1 };
			FlowElements[AddDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataUserTask1 };
			FlowElements[ChangeDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartBusinessProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataUserTask1", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CopyProductScriptTask", e.Context.SenderName));
						break;
					case "CopyProductScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask1", e.Context.SenderName));
						break;
					case "Terminate2":
						CompleteProcess();
						break;
					case "OpenEditPageUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
						break;
					case "AddDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
						break;
					case "ChangeDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenEditPageUserTask1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((CurrentOpportunity)== Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow1", "(CurrentOpportunity)== Guid.Empty", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CurrentOpportunity")) {
				writer.WriteValue("CurrentOpportunity", CurrentOpportunity, Guid.Empty);
			}
			if (!HasMapping("NewOrder")) {
				writer.WriteValue("NewOrder", NewOrder, Guid.Empty);
			}
			if (!HasMapping("ProductItems")) {
				writer.WriteValue("ProductItems", ProductItems, null);
			}
			if (!HasMapping("IsCopyAllProduct")) {
				writer.WriteValue("IsCopyAllProduct", IsCopyAllProduct, false);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartBusinessProcess", string.Empty));
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
			MetaPathParameterValues.Add("515496b8-401a-4a70-b54d-64bfd7124238", () => CurrentOpportunity);
			MetaPathParameterValues.Add("d828a3fe-e2a4-4160-a91c-92ab92b04cfc", () => NewOrder);
			MetaPathParameterValues.Add("6c324739-8a48-4082-998b-fa670868c7ce", () => ProductItems);
			MetaPathParameterValues.Add("d7f0950e-8bc1-4a4d-b695-906d525716a4", () => IsCopyAllProduct);
			MetaPathParameterValues.Add("e1d83148-df86-4cc1-810a-5310eb1688e8", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("3898f5c3-ee0f-45d0-95ac-9cd9a0d94564", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("cea4bbf0-8f34-4f22-ab35-9a44c8f81e1e", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("f5a484b3-8778-45a8-abde-f587d34577ef", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("ebe4df04-3e0e-419e-833f-8e94cd7d6497", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("c2db847b-3042-4668-bddd-dc4935ba4078", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("f824e334-f632-4f09-a820-7cf5de24447a", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("9809e6b3-5ddb-4caf-aa53-a91b85840985", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("2d44e8b3-9be9-44d9-989e-801007f332a2", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("af44f78e-77ce-4e84-89aa-a4a8589acaca", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("a3bbda1d-938c-4804-bae7-3e6727495500", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("d90e7819-b5bb-4322-b1a1-688430cac361", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("adbeddd4-1b47-439f-b56f-eaf1ce7c22bd", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("1f3ec804-485b-4fb7-ba6c-b97ab3bcb1a8", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("44077e26-c243-4885-bf41-802b99ca00f2", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("87d3453d-f7b9-41d7-953c-1ce1e1ade596", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("8e68ae20-c6e7-4bff-bc6f-c7c1e2476fe2", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("a15e8fcf-ba82-439f-bb6f-99ba54972dbc", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("832f2f71-b292-40cd-aa19-4b7009297b25", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("4fb1e2ff-2cc4-4788-bae0-e74102fa14e8", () => OpenEditPageUserTask1.ObjectSchemaId);
			MetaPathParameterValues.Add("30aa1c24-3e58-45a3-a546-cdf3bedb9b62", () => OpenEditPageUserTask1.PageSchemaId);
			MetaPathParameterValues.Add("c831eecc-a5e6-4e9b-8f0a-6d639e5e35fb", () => OpenEditPageUserTask1.EditMode);
			MetaPathParameterValues.Add("874c268f-6319-4d17-ad59-f40c4f774b05", () => OpenEditPageUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("01172481-a565-47df-a5be-cb9da2fc12a3", () => OpenEditPageUserTask1.RecordId);
			MetaPathParameterValues.Add("30f2bca3-c96e-4e5c-88c8-085b0ae8cf0d", () => OpenEditPageUserTask1.ExecutedMode);
			MetaPathParameterValues.Add("1408b6b8-cf8c-4425-b12e-fbad9c403b3d", () => OpenEditPageUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("c7f158e2-218b-4b9f-8725-909927e9b8b5", () => OpenEditPageUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("3d20f3f7-5984-43c4-9f1d-394a5d9dc018", () => OpenEditPageUserTask1.GenerateDecisionsFromColumn);
			MetaPathParameterValues.Add("e46b1b8b-1819-4789-a14f-65ddf3741c3b", () => OpenEditPageUserTask1.DecisionalColumnMetaPath);
			MetaPathParameterValues.Add("ab96af1a-57c8-4824-96f8-6ba447e62e14", () => OpenEditPageUserTask1.ResultParameter);
			MetaPathParameterValues.Add("2450b4ac-bc00-4be2-9f76-e7e372ca7f07", () => OpenEditPageUserTask1.IsReexecution);
			MetaPathParameterValues.Add("67908e65-2f58-45f9-983b-2c1da6379cd5", () => OpenEditPageUserTask1.Recommendation);
			MetaPathParameterValues.Add("4dea05bc-b597-4eb2-8f8e-707838c63a9e", () => OpenEditPageUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("08b712e2-4919-4423-b244-28f0ab6e324e", () => OpenEditPageUserTask1.OwnerId);
			MetaPathParameterValues.Add("a4574b01-f7d9-4d5b-b3e8-504a67746654", () => OpenEditPageUserTask1.Duration);
			MetaPathParameterValues.Add("69a2aa31-7c0d-4a87-9dba-2547b60626e5", () => OpenEditPageUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("f9f8a922-41df-4718-9bb2-5709eef02ce4", () => OpenEditPageUserTask1.StartIn);
			MetaPathParameterValues.Add("d01eb000-e5aa-49b1-a95c-82a0dbd4a4a8", () => OpenEditPageUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("540dcd0c-778c-4a17-ac36-7def92eab44c", () => OpenEditPageUserTask1.RemindBefore);
			MetaPathParameterValues.Add("6ba4e133-0564-4f7f-91ad-971ae82a9e2d", () => OpenEditPageUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("3e4d0ff6-c547-4b65-ad49-292460443cd8", () => OpenEditPageUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("73d80e1b-1dc6-4b92-92e4-c0ff21953dad", () => OpenEditPageUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("5d24cbb8-ba27-4390-9faf-4ac736c965fe", () => OpenEditPageUserTask1.Lead);
			MetaPathParameterValues.Add("f6a640ee-aeff-4e52-a0ef-83b05ca53c8c", () => OpenEditPageUserTask1.Account);
			MetaPathParameterValues.Add("71ebff1e-d62b-43b6-9539-02c2dffd16a2", () => OpenEditPageUserTask1.Contact);
			MetaPathParameterValues.Add("c29a5757-0505-47ee-b548-5293e3acbd89", () => OpenEditPageUserTask1.Opportunity);
			MetaPathParameterValues.Add("d6fc85c9-a2f4-455e-b336-fa9b65be5720", () => OpenEditPageUserTask1.Invoice);
			MetaPathParameterValues.Add("13610d95-0021-419e-88ad-79b772cbba42", () => OpenEditPageUserTask1.Document);
			MetaPathParameterValues.Add("e4606663-de9c-46d9-8891-543f07160143", () => OpenEditPageUserTask1.Incident);
			MetaPathParameterValues.Add("89f85502-0eb1-4d21-9eaa-96ebe6cf07ff", () => OpenEditPageUserTask1.Case);
			MetaPathParameterValues.Add("b9d6544d-94ae-49b4-af5c-ec4c5ed0dc76", () => OpenEditPageUserTask1.ActivityResult);
			MetaPathParameterValues.Add("30207a75-7e4e-4522-904b-474a8b804296", () => OpenEditPageUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("1c1730bc-905c-42f3-add5-b5767a8cc78c", () => OpenEditPageUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("251964b1-f33f-4a0d-bf37-4b2a62a2a899", () => OpenEditPageUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("29a2680c-fd32-4012-916a-2548fffff631", () => OpenEditPageUserTask1.PageTypeUId);
			MetaPathParameterValues.Add("b9101517-77b1-4251-8334-6c0beefd8041", () => OpenEditPageUserTask1.ActivitySchemaUId);
			MetaPathParameterValues.Add("88dfbdf6-104a-448e-8a68-5256a4d8de7d", () => OpenEditPageUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("bcaeafa8-ef4e-4977-81f8-d000782ce97f", () => OpenEditPageUserTask1.Order);
			MetaPathParameterValues.Add("5da83713-07c4-4e79-9df3-1e7de802bcee", () => OpenEditPageUserTask1.Requests);
			MetaPathParameterValues.Add("fa6dc17d-dd86-43d4-b71a-1d6b901489b5", () => OpenEditPageUserTask1.Listing);
			MetaPathParameterValues.Add("eb233771-7ac3-4db6-aa21-e29355f9b0f1", () => OpenEditPageUserTask1.Property);
			MetaPathParameterValues.Add("975dc8f2-6321-4417-9c7b-bd02cf1f0781", () => OpenEditPageUserTask1.Contract);
			MetaPathParameterValues.Add("b3793aa7-c2bf-4f7e-ba51-134097f27019", () => OpenEditPageUserTask1.Problem);
			MetaPathParameterValues.Add("2d39a734-7bc1-4c2e-b145-d00733f01f98", () => OpenEditPageUserTask1.Change);
			MetaPathParameterValues.Add("e4f8491d-13aa-43d4-b1a6-366538d33a50", () => OpenEditPageUserTask1.Release);
			MetaPathParameterValues.Add("99c0a079-b569-486d-8118-2ff619216465", () => OpenEditPageUserTask1.Project);
			MetaPathParameterValues.Add("f79f50cc-a5b0-4573-8aae-10d177876838", () => OpenEditPageUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("b4a22b62-7433-4a38-ae5b-4996553676ea", () => OpenEditPageUserTask1.CreateActivity);
			MetaPathParameterValues.Add("c29c1ea2-c50d-4de5-ac66-516920f18b79", () => AddDataUserTask1.EntitySchemaId);
			MetaPathParameterValues.Add("2a9808a0-acf6-420e-bba5-93f802478e80", () => AddDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("627ad3cd-7998-4ecb-b7bc-4e7f08515ed5", () => AddDataUserTask1.RecordAddMode);
			MetaPathParameterValues.Add("87fa38ed-1e46-464b-bfb2-1adf9fb90a14", () => AddDataUserTask1.FilterEntitySchemaId);
			MetaPathParameterValues.Add("1644d055-35f1-46be-b85d-cbd5030192cb", () => AddDataUserTask1.RecordDefValues);
			MetaPathParameterValues.Add("e61c73fa-a1cd-4ced-8c2f-a8a753e62a94", () => AddDataUserTask1.RecordId);
			MetaPathParameterValues.Add("a45e951d-fb18-4f4c-877e-3ad634d94c8b", () => AddDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("ad435e49-6d29-49c1-b37f-07b4169035df", () => ChangeDataUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("f8ee27e9-0fe2-4341-8e23-4267f53b9416", () => ChangeDataUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("a050532e-2c9a-4f51-81bb-cf840e62ef62", () => ChangeDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("a9bdd0c6-ef02-470d-918b-9984c37e8456", () => ChangeDataUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("1cf407c8-8982-4a40-84a9-c214579d1cc1", () => ChangeDataUserTask1.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CurrentOpportunity":
					if (!hasValueToRead) break;
					CurrentOpportunity = reader.GetValue<System.Guid>();
				break;
				case "NewOrder":
					if (!hasValueToRead) break;
					NewOrder = reader.GetValue<System.Guid>();
				break;
				case "ProductItems":
					if (!hasValueToRead) break;
					ProductItems = reader.GetValue<System.String>();
				break;
				case "IsCopyAllProduct":
					if (!hasValueToRead) break;
					IsCopyAllProduct = reader.GetValue<System.Boolean>();
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
			var localNewOrder = (AddDataUserTask1.RecordId);
			NewOrder = (System.Guid)localNewOrder;
			return true;
		}

		public virtual bool CopyProductScriptTaskExecute(ProcessExecutingContext context) {
			if (ProductItems.ToString() != "" || IsCopyAllProduct) {
				var copyProductsOperation = Factories.ClassFactory.Get<
					BPMSoft.Configuration.CopyOrderProductsFromOpportunityOperation>(
					new Factories.ConstructorArgument("userConnection", UserConnection));
				copyProductsOperation.Execute(new BPMSoft.Configuration
					.CopyOrderProductsFromOpportunityOperation
					.CopyOrderProductsArgs {
						OpportunityId = CurrentOpportunity,
						OrderId = NewOrder,
						IsCopyAllProducts = IsCopyAllProduct,
						ProductItems = ProductItems
				});
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
			var cloneItem = (CreateOrderFromOpportunity)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

