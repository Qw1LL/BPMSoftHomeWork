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

	#region Class: OrderVisaBaseSubprocessSchema

	/// <exclude/>
	public class OrderVisaBaseSubprocessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public OrderVisaBaseSubprocessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public OrderVisaBaseSubprocessSchema(OrderVisaBaseSubprocessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "OrderVisaBaseSubprocess";
			UId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be");
			CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2936";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
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
			RealUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be");
			Version = 0;
			PackageUId = new Guid("ef11e995-ba92-40e9-9077-1a6fee8d4c35");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateOrderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d61a0989-8779-4783-b113-deb50cf15b47"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"Order",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateVisaOwnerParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9083bea5-93b0-4bc9-8a38-0da7a8890273"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"VisaOwner",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateVisaObjectiveParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a7d20fb9-d1a3-4f6c-8cc6-b6e88a8c4343"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"VisaObjective",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateVisaResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("31a29f35-3211-4fc9-a634-b719a4bcbe4f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"VisaResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsAllowedToDelegateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ab166058-c417-46eb-98a4-67cb25768bed"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"IsAllowedToDelegate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsPreviousVisaCountsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7a369c26-a919-430e-9fcc-b7dbd03e82cc"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"IsPreviousVisaCounts",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateOrderParameter());
			Parameters.Add(CreateVisaOwnerParameter());
			Parameters.Add(CreateVisaObjectiveParameter());
			Parameters.Add(CreateVisaResultParameter());
			Parameters.Add(CreateIsAllowedToDelegateParameter());
			Parameters.Add(CreateIsPreviousVisaCountsParameter());
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("04f4034b-c6d8-4043-81ff-11c4f91ff61f"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,221,138,219,70,20,199,223,69,23,189,210,148,25,205,183,123,151,101,11,129,146,6,250,65,33,44,225,204,204,153,172,88,219,114,44,153,38,24,67,187,185,10,148,6,122,211,171,82,250,6,185,73,179,109,104,158,65,126,163,30,219,235,196,44,238,54,217,52,23,219,246,66,178,70,210,156,175,249,255,230,200,243,187,117,251,113,61,236,112,58,200,48,108,177,156,221,76,131,194,37,237,81,121,203,2,231,137,169,24,57,11,104,45,203,6,156,69,1,42,138,80,148,99,24,225,160,216,204,62,76,117,87,148,117,135,163,118,112,103,254,218,104,55,157,97,121,55,175,7,159,197,99,28,193,23,43,7,26,201,158,138,200,132,141,64,14,140,99,222,162,97,14,43,141,92,160,178,81,23,155,88,114,206,201,58,147,89,8,58,51,5,62,81,84,85,102,104,67,52,136,66,155,12,69,57,196,220,29,62,152,76,177,109,235,102,60,152,227,171,235,207,31,78,40,202,141,239,131,102,56,27,141,139,114,132,29,220,134,238,120,80,84,156,91,153,81,51,37,93,96,170,210,148,105,10,158,9,202,89,91,25,109,10,178,40,35,76,186,149,217,162,255,177,127,218,255,78,199,243,162,156,98,198,41,142,35,238,228,229,120,229,149,118,21,227,38,144,205,12,192,192,81,216,82,86,18,181,150,38,88,81,148,9,58,248,18,134,51,92,199,54,175,105,98,168,188,230,86,100,102,17,60,83,104,42,230,146,0,230,133,15,89,90,89,229,92,109,43,254,73,211,156,204,38,84,237,246,214,108,132,211,58,158,47,29,210,26,52,211,193,60,54,227,110,218,12,87,198,111,237,76,216,44,209,249,195,175,54,101,25,174,159,172,38,22,139,114,214,226,193,176,198,113,119,56,142,77,170,199,247,214,171,183,88,208,156,209,4,166,117,187,45,230,225,253,25,12,169,0,245,189,227,75,139,126,48,107,187,102,116,221,242,45,41,87,50,67,130,93,199,188,210,115,170,219,201,16,30,174,199,131,226,131,251,179,166,251,232,181,20,54,227,226,194,188,237,123,201,8,224,222,121,230,172,165,76,173,147,44,8,33,89,194,160,121,204,66,7,101,207,45,44,202,119,242,116,231,102,251,233,215,227,45,103,155,34,29,125,72,119,47,220,184,189,157,61,152,191,73,112,139,163,109,120,71,164,133,127,148,109,229,193,166,24,73,5,66,112,122,53,36,230,188,148,12,82,4,244,138,171,156,245,213,217,206,82,130,37,151,164,177,164,152,10,220,48,80,228,39,120,244,196,163,81,58,136,93,182,127,232,207,250,231,253,217,242,155,229,163,229,247,203,199,52,250,237,47,40,87,89,169,224,41,185,16,229,42,236,204,64,128,99,17,35,175,162,160,147,143,215,77,245,255,83,190,159,189,61,162,184,156,66,207,157,12,8,154,121,25,72,211,33,18,92,32,29,227,9,44,56,231,121,101,229,223,240,254,214,62,175,64,254,155,132,249,30,201,215,150,6,160,20,243,206,26,106,148,145,72,48,92,50,41,184,86,153,62,63,114,84,87,39,159,218,118,197,13,53,95,197,69,164,147,215,44,128,146,204,106,27,93,22,94,40,244,187,228,255,212,63,91,109,177,203,211,229,35,250,125,177,252,174,255,163,127,186,151,96,207,131,209,33,83,157,114,38,203,66,137,205,214,89,169,138,211,5,100,207,237,150,224,27,77,51,68,24,191,5,194,7,199,24,79,110,52,15,46,2,76,105,198,147,64,247,247,225,187,182,249,14,252,190,18,197,245,74,120,79,155,190,8,199,250,197,247,32,222,40,83,48,86,5,150,0,144,169,68,236,128,131,138,165,36,93,132,12,149,92,237,255,87,21,175,118,20,137,52,200,172,116,212,182,128,154,98,224,126,37,99,27,77,214,220,129,74,187,226,253,165,127,185,252,118,121,74,231,39,36,219,179,254,217,254,166,101,12,73,95,67,100,154,224,32,226,144,242,211,192,169,225,130,119,40,109,214,54,255,119,154,214,229,162,255,23,124,157,254,220,191,236,95,208,241,43,245,145,83,218,222,206,55,181,229,147,203,59,9,90,159,33,6,218,136,163,36,149,72,180,12,232,191,32,19,85,0,65,32,24,33,171,157,166,112,180,248,19,149,138,216,62,65,14,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e666ae4f-cd81-441a-9f61-c2de41eb84f2"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0eedbcbc-25ab-494a-bbeb-e21d15d3be92"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("382fa627-a8e0-4d33-862f-361c9d9220da"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3c107cd1-2016-4d0e-b57d-815d74cd3861"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0ca6bb93-a18e-49e0-ac02-7b6f8cdb0549"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("614e748d-e9f4-4f3b-bdc4-35ee7dcb1b74"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,79,202,74,77,46,201,44,75,181,50,180,50,4,0,6,191,96,252,20,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"),
				UId = new Guid("15145695-748a-430e-b902-b281b552c89f"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b3e85650-29fb-4199-af80-4eaf98698a27"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("31a4ff18-1803-4d14-8843-1882f4aebc11"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("12fa2c87-6548-4026-a641-3939fadc4b42"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e8720629-f6ec-43e7-8a7b-2c24630badb3"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c003ab55-826d-4b64-9e5f-8804a5848b21"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0ef917e9-7826-4a02-b4bd-171856e1ef12"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"),
				UId = new Guid("4ece07e9-a9db-4a55-87b9-48e11c9ff7e5"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4b15cb40-0f50-4078-a24f-a5956fc6b157"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3785519b-3fe4-434c-86da-2b81ae73e599"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("153ddfa4-67d6-4be6-b015-deefed442eb8"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("dc25ae11-2965-4477-9857-699bd9d2adb0"),
				ContainerUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("1404379d-a79a-4596-893d-7c620dfd8caf"),
				ContainerUId = new Guid("607c2930-07fe-47db-a6d2-0c0ce46e5459"),
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
				Value = @"5ebe74ce-17ca-4c68-97e6-8e25e01e47c5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55ef8b53-d3cc-43e6-b2cb-7bf702d94f72"),
				ContainerUId = new Guid("607c2930-07fe-47db-a6d2-0c0ce46e5459"),
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e99d85dc-8cbe-4f1e-ba54-7c57ddf21953"),
				ContainerUId = new Guid("607c2930-07fe-47db-a6d2-0c0ce46e5459"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,150,75,139,27,71,16,199,191,203,28,114,154,14,253,126,40,55,47,27,48,132,141,33,15,2,102,49,253,168,246,14,59,210,200,154,17,177,17,130,196,62,25,66,12,185,228,20,66,190,129,47,142,55,49,241,103,152,249,70,41,73,43,91,44,202,198,94,219,135,13,57,104,52,221,51,93,93,85,243,255,85,245,226,78,213,126,90,213,29,204,70,217,215,45,148,243,155,105,84,120,171,21,15,41,146,4,202,17,25,132,37,142,7,70,168,224,153,219,16,82,118,161,40,39,126,12,163,98,179,250,48,85,93,81,86,29,140,219,209,237,197,107,163,221,108,14,229,157,188,30,124,17,79,96,236,191,90,109,160,32,128,145,17,8,51,209,19,25,53,110,96,64,19,11,92,1,101,32,77,84,197,198,23,237,85,214,201,121,18,147,146,68,58,161,73,136,32,136,129,160,68,14,148,229,152,138,178,134,220,29,222,159,206,160,109,171,102,50,90,192,171,251,47,31,76,209,203,205,222,7,77,61,31,79,138,114,12,157,191,229,187,147,81,193,41,53,34,131,34,82,216,64,36,87,148,132,20,28,97,49,82,101,68,52,41,136,162,140,126,218,173,204,22,253,207,253,211,254,79,252,61,47,202,25,100,152,193,36,194,78,92,150,114,39,149,229,132,234,128,54,179,247,196,91,149,137,16,92,128,82,66,7,195,138,50,249,206,127,237,235,57,172,125,91,84,184,48,112,167,168,97,25,195,242,152,113,208,156,216,196,60,113,204,133,44,12,230,61,243,109,198,63,107,154,211,249,20,179,221,30,205,199,48,171,226,249,167,3,252,6,205,108,180,136,205,164,155,53,245,202,248,209,206,130,205,39,58,127,248,205,38,45,245,250,201,106,97,177,44,231,45,28,212,21,76,186,195,73,108,82,53,185,187,254,122,203,37,174,25,79,253,172,106,183,201,60,188,55,247,53,38,160,186,123,114,105,210,15,230,109,215,140,175,91,188,37,198,138,102,80,176,107,159,87,122,78,85,59,173,253,131,245,120,84,124,116,111,222,116,159,188,150,194,102,92,92,88,183,125,47,105,230,169,179,142,88,99,48,82,99,5,9,140,9,68,43,40,26,51,83,65,154,115,11,203,242,157,118,186,125,179,253,252,219,201,150,179,77,146,142,63,198,217,11,19,183,182,171,71,139,55,113,110,121,188,117,239,24,181,240,94,217,102,217,134,40,176,206,224,36,226,2,6,136,179,66,18,238,172,1,38,147,64,215,174,206,118,22,194,27,220,18,53,150,176,114,4,170,137,151,12,1,119,224,144,71,45,85,96,187,108,255,212,159,245,207,251,179,225,187,225,209,240,227,240,24,71,127,252,3,229,50,75,25,176,36,73,244,30,35,12,153,120,230,45,137,16,41,143,12,47,46,94,55,213,255,79,249,126,246,246,136,226,114,10,29,181,34,128,87,196,137,64,87,10,65,184,60,54,80,154,188,241,214,58,202,141,248,23,222,223,122,207,43,144,255,38,110,126,64,242,181,82,209,74,236,187,22,32,175,154,47,35,158,99,13,0,22,17,8,154,19,95,157,48,174,74,62,182,109,78,53,54,95,73,89,196,139,83,36,120,137,103,6,101,162,205,204,49,9,110,151,252,95,250,103,171,18,59,60,28,30,225,255,139,225,135,254,175,254,233,94,130,29,13,90,133,140,121,202,25,45,51,201,54,165,147,75,78,241,198,103,71,205,150,224,27,77,83,131,159,188,5,194,7,39,16,79,111,52,247,47,2,140,97,198,211,128,243,251,240,93,219,124,7,126,95,137,226,122,5,188,167,77,95,132,99,253,226,7,16,111,74,62,98,39,81,36,135,200,177,140,103,67,172,114,129,68,166,53,54,130,100,192,230,171,139,87,89,244,68,104,32,70,88,108,91,62,36,18,168,91,201,216,68,157,21,181,94,166,93,241,254,214,191,28,190,31,30,226,245,9,202,246,172,127,182,191,105,105,141,210,87,62,18,133,112,224,209,20,48,62,229,41,177,206,59,11,194,100,101,242,245,111,90,71,77,247,126,116,255,31,56,160,254,218,191,236,95,224,239,119,108,37,15,177,194,157,215,181,225,201,229,205,4,140,203,62,6,65,68,20,40,20,1,134,120,229,144,11,30,60,67,22,52,19,124,167,47,28,47,255,6,13,157,50,237,68,14,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cb208bfe-de96-49f6-81bc-f82ec1afd252"),
				ContainerUId = new Guid("607c2930-07fe-47db-a6d2-0c0ce46e5459"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,157,82,91,79,195,32,20,254,43,134,248,56,22,218,65,105,247,168,211,100,137,51,139,211,189,88,31,78,233,65,155,244,178,80,102,212,165,255,93,138,93,214,37,250,34,15,208,114,206,119,225,131,3,185,180,159,59,36,115,114,181,94,109,26,109,167,215,141,193,233,218,52,10,219,118,122,215,40,40,139,47,200,74,92,131,129,10,45,154,45,148,123,108,239,138,214,78,46,198,32,50,33,151,239,190,70,230,207,7,178,180,88,61,45,115,199,60,131,16,145,229,130,98,206,5,229,90,10,10,2,67,10,1,203,117,150,97,4,51,112,96,213,148,251,170,94,161,133,53,216,55,50,63,16,207,230,8,148,204,67,22,1,80,206,2,229,166,68,208,12,248,140,74,33,85,172,131,36,224,152,144,110,66,90,245,134,21,120,209,19,88,96,134,146,43,164,129,84,142,65,69,49,77,36,70,52,198,80,32,11,144,75,37,122,240,208,127,2,90,227,22,87,200,139,118,87,194,231,246,175,250,238,44,152,113,199,33,253,73,55,37,243,244,247,124,135,117,227,141,159,39,124,30,110,74,38,41,217,52,123,163,122,182,89,255,115,60,172,103,103,195,160,191,76,199,241,195,225,97,43,168,225,21,205,189,211,243,112,95,90,128,5,47,253,232,60,31,137,19,150,69,34,211,49,101,90,187,236,3,30,208,88,202,132,134,60,100,238,3,116,194,164,71,63,160,70,131,181,194,127,26,219,246,202,39,51,199,119,224,118,234,125,89,122,129,214,159,191,127,88,131,241,161,178,24,221,208,136,161,201,11,93,96,190,172,255,233,104,129,218,83,222,54,230,230,195,61,247,162,126,29,238,107,36,125,234,89,168,106,216,239,72,215,189,116,223,59,18,41,195,91,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b1068955-5851-43c7-a7cf-e923621021db"),
				ContainerUId = new Guid("607c2930-07fe-47db-a6d2-0c0ce46e5459"),
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

		protected virtual void InitializeAddDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("8aad1115-eaba-4c12-98ce-a8b0ae405981"),
				ContainerUId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab"),
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
				Value = @"5ebe74ce-17ca-4c68-97e6-8e25e01e47c5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9df5d5d0-f073-472c-859b-f5e3b67221ea"),
				ContainerUId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab"),
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("443af2ec-aeea-4cc0-886a-e903dd5eefa7"),
				ContainerUId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("d0252b09-da98-4d4e-9dc0-ef8bb6f92f23"),
				ContainerUId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab"),
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
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("48aec832-cd69-4509-a9b4-abd75a914dc6"),
				ContainerUId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,150,75,111,28,69,16,128,255,138,53,201,209,101,245,251,177,71,48,72,150,98,176,8,228,98,251,80,221,93,157,172,180,222,181,118,215,64,176,86,138,196,5,4,226,192,133,43,39,206,17,96,197,128,200,111,152,253,71,212,140,215,120,77,34,203,226,100,37,25,105,102,119,166,187,30,93,213,95,85,159,54,247,231,79,143,169,25,52,239,237,237,62,156,212,249,214,251,147,41,109,237,77,39,153,102,179,173,7,147,140,163,225,87,152,70,180,135,83,60,162,57,77,31,225,232,132,102,15,134,179,249,230,198,186,80,179,217,220,255,188,31,107,6,251,167,205,206,156,142,62,219,41,172,89,134,224,181,47,17,76,42,1,76,241,9,146,21,6,180,12,82,6,79,214,41,193,194,121,50,58,57,26,239,210,28,247,112,254,164,25,156,54,189,54,86,160,132,240,186,146,5,163,67,2,163,172,128,84,82,4,153,179,176,94,103,95,146,110,22,155,205,44,63,161,35,236,141,94,9,91,74,228,77,38,144,62,35,152,236,2,68,79,14,2,41,75,66,146,241,217,118,194,171,249,87,130,251,247,246,119,102,31,127,49,166,233,195,94,239,160,226,104,70,135,91,252,245,63,31,254,13,205,224,180,56,137,34,134,8,193,123,94,176,15,26,146,148,26,10,241,146,115,149,54,25,191,56,188,119,216,89,44,195,217,241,8,159,62,122,213,112,251,83,251,188,253,147,239,23,23,51,143,175,197,126,125,238,233,193,69,2,15,154,193,193,235,83,184,250,189,112,249,122,18,175,231,239,160,217,60,104,30,78,78,166,185,211,166,187,151,203,120,246,218,197,234,130,215,60,46,175,11,29,189,216,46,142,241,49,77,63,98,123,189,120,63,180,141,115,236,77,127,202,62,95,42,78,42,90,225,101,5,79,200,49,35,167,32,20,137,16,101,76,85,123,173,106,85,189,244,39,84,105,74,227,76,215,29,11,66,69,99,131,2,225,18,239,145,138,8,24,108,5,173,149,38,107,181,75,94,246,242,189,229,43,103,46,183,26,127,25,159,140,70,189,129,89,191,254,110,239,174,28,95,141,108,175,229,106,77,195,164,12,235,144,202,206,248,127,134,106,155,106,175,242,195,201,244,131,47,153,168,225,248,241,42,95,107,166,175,230,108,231,163,213,247,69,179,88,108,174,67,230,164,115,74,107,15,17,137,192,88,38,45,5,171,64,85,163,116,113,85,229,104,111,132,172,106,141,158,137,224,44,20,195,168,10,7,104,36,147,22,41,114,32,157,177,73,222,17,200,162,8,58,17,90,136,58,9,118,53,51,110,168,3,136,130,30,67,136,66,121,125,11,200,126,108,207,219,23,237,249,242,217,242,235,229,15,203,111,249,237,143,119,184,221,2,55,83,141,73,145,211,156,178,230,92,167,10,40,49,64,166,44,84,150,252,136,249,141,199,205,70,93,163,112,6,148,173,220,146,184,19,65,226,26,4,58,104,222,253,85,135,154,227,141,184,101,21,84,14,202,128,71,148,192,1,53,204,107,21,80,50,138,74,186,132,100,210,29,193,13,125,81,162,114,191,229,162,204,9,175,46,67,200,217,65,114,20,2,134,108,180,185,13,110,191,180,103,237,95,203,239,55,218,95,59,238,150,223,189,13,172,21,62,153,160,228,130,44,60,117,71,31,110,109,201,115,147,43,130,156,12,73,112,88,203,77,172,221,218,177,55,153,181,106,130,204,81,9,64,202,170,11,98,130,72,34,66,86,78,112,127,231,138,149,194,141,172,249,98,172,54,137,219,98,96,79,141,143,124,40,11,38,128,243,94,22,52,172,218,187,187,194,90,226,62,46,184,144,100,35,61,24,71,188,214,128,134,93,205,73,89,239,66,162,114,11,214,126,238,206,142,203,103,237,217,242,27,166,238,239,246,229,70,251,123,135,31,223,191,117,29,175,125,201,20,62,231,129,243,246,236,109,224,48,138,228,108,170,124,68,168,53,115,185,54,242,226,128,174,140,18,252,7,185,150,251,119,28,210,43,28,30,46,254,1,50,58,233,249,33,14,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("70f3c8ce-16ff-40fc-8eda-5a3419a1ec22"),
				ContainerUId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab"),
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
				UId = new Guid("76fb1c92-4acb-475e-95bf-e3b9ff59dfb5"),
				ContainerUId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab"),
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

		protected virtual void InitializeIntermediateCatchSignalEvent1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fbb5cec9-6a5b-44ae-829a-1f19c78d0339"),
				ContainerUId = new Guid("a5816ab2-fc89-46c9-b765-fc883a751c57"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a5816ab2-fc89-46c9-b765-fc883a751c57"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{79386b89-3dc1-45f8-920c-163c2dd52bab}].[Parameter:{70f3c8ce-16ff-40fc-8eda-5a3419a1ec22}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeIntermediateCatchSignalEvent2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2baee59c-8079-46b4-8f24-2a77f99b38b2"),
				ContainerUId = new Guid("0840873f-90de-46aa-83ad-ffee9f1dbd9c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0840873f-90de-46aa-83ad-ffee9f1dbd9c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{79386b89-3dc1-45f8-920c-163c2dd52bab}].[Parameter:{70f3c8ce-16ff-40fc-8eda-5a3419a1ec22}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeIntermediateCatchSignalEvent3Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dbcabc88-7940-493a-9211-1d7ef9018176"),
				ContainerUId = new Guid("6ab5ea91-43ce-458d-a7a4-4f584c10c14f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ab5ea91-43ce-458d-a7a4-4f584c10c14f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{79386b89-3dc1-45f8-920c-163c2dd52bab}].[Parameter:{70f3c8ce-16ff-40fc-8eda-5a3419a1ec22}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaOrderVisa = CreateOrderVisaLaneSet();
			LaneSets.Add(schemaOrderVisa);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaOrderVisa.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent startprocess = CreateStartProcessStartEvent();
			FlowElements.Add(startprocess);
			ProcessSchemaTerminateEvent errorendprocess = CreateErrorEndProcessTerminateEvent();
			FlowElements.Add(errorendprocess);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaFormulaTask formulatask2 = CreateFormulaTask2FormulaTask();
			FlowElements.Add(formulatask2);
			ProcessSchemaTerminateEvent alreadyexistsvisaendprocess = CreateAlreadyExistsVisaEndProcessTerminateEvent();
			FlowElements.Add(alreadyexistsvisaendprocess);
			ProcessSchemaUserTask changedatausertask1 = CreateChangeDataUserTask1UserTask();
			FlowElements.Add(changedatausertask1);
			ProcessSchemaEventBasedGateway visaeventgateway = CreateVisaEventGatewayEventBasedGateway();
			FlowElements.Add(visaeventgateway);
			ProcessSchemaUserTask adddatausertask1 = CreateAddDataUserTask1UserTask();
			FlowElements.Add(adddatausertask1);
			ProcessSchemaIntermediateCatchSignalEvent intermediatecatchsignalevent1 = CreateIntermediateCatchSignalEvent1IntermediateCatchSignalEvent();
			FlowElements.Add(intermediatecatchsignalevent1);
			ProcessSchemaFormulaTask formulatask3 = CreateFormulaTask3FormulaTask();
			FlowElements.Add(formulatask3);
			ProcessSchemaTerminateEvent visaapprovedendprocess = CreateVisaApprovedEndProcessTerminateEvent();
			FlowElements.Add(visaapprovedendprocess);
			ProcessSchemaIntermediateCatchSignalEvent intermediatecatchsignalevent2 = CreateIntermediateCatchSignalEvent2IntermediateCatchSignalEvent();
			FlowElements.Add(intermediatecatchsignalevent2);
			ProcessSchemaFormulaTask formulatask4 = CreateFormulaTask4FormulaTask();
			FlowElements.Add(formulatask4);
			ProcessSchemaTerminateEvent visarejectedendprocess = CreateVisaRejectedEndProcessTerminateEvent();
			FlowElements.Add(visarejectedendprocess);
			ProcessSchemaIntermediateCatchSignalEvent intermediatecatchsignalevent3 = CreateIntermediateCatchSignalEvent3IntermediateCatchSignalEvent();
			FlowElements.Add(intermediatecatchsignalevent3);
			ProcessSchemaFormulaTask formulatask5 = CreateFormulaTask5FormulaTask();
			FlowElements.Add(formulatask5);
			ProcessSchemaTerminateEvent visacanceledendprocess = CreateVisaCanceledEndProcessTerminateEvent();
			FlowElements.Add(visacanceledendprocess);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateSequenceFlow15SequenceFlow());
			FlowElements.Add(CreateSequenceFlow16SequenceFlow());
			FlowElements.Add(CreateSequenceFlow17SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("8d149aa9-f724-4667-8861-9130e330ef44"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3ad3c2d7-2e4d-4801-90b9-adc3f9a1e128"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("da192822-0ea3-4542-ac3b-745985e64333"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("e24b4502-eda7-4443-bab4-eab12e044974"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{9083bea5-93b0-4bc9-8a38-0da7a8890273}]#] == null || [#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d61a0989-8779-4783-b113-deb50cf15b47}]#] == null",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(241, 255),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("da192822-0ea3-4542-ac3b-745985e64333"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("628ae4b5-5b8f-477c-ad0a-e2af292bde57"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("a1268ea1-cf94-4054-ba62-50dd9f316349"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(234, 414),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("628ae4b5-5b8f-477c-ad0a-e2af292bde57"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0cf03be0-f5ba-4629-b8ac-e68a921b26d2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("c4ebf13f-3b7a-4280-88b0-b0585f1b8c72"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{7a369c26-a919-430e-9fcc-b7dbd03e82cc}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(392, 275),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3ce13491-ee06-4e1b-9ddd-8aa953f4f35a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("6b6fcea0-ef81-4fa0-bbcc-711ae6b9a4f1"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9}].[Parameter:{b3e85650-29fb-4199-af80-4eaf98698a27}]#] > 0
",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(388, 394),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("62965831-85c2-42aa-95cd-175d0d0ec167"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("24ddb40a-70ed-4876-987c-a8ba582c89b2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(392, 502),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("62965831-85c2-42aa-95cd-175d0d0ec167"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("11d26795-fc8e-4951-92e8-475a7d324942"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow4",
				UId = new Guid("bf0addbd-fc4a-4c1e-9fb0-c25a90c78370"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(319, 208),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("da192822-0ea3-4542-ac3b-745985e64333"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3ce13491-ee06-4e1b-9ddd-8aa953f4f35a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow5",
				UId = new Guid("fb939242-ceeb-42c7-b74b-0313d1d2a983"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(463, 270),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("607c2930-07fe-47db-a6d2-0c0ce46e5459"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow6",
				UId = new Guid("f75e062b-eee2-468d-b106-d706ab512610"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(460, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3ce13491-ee06-4e1b-9ddd-8aa953f4f35a"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("607c2930-07fe-47db-a6d2-0c0ce46e5459"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("2496e46d-4529-4988-8d95-51eb8d5c4507"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(584, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("607c2930-07fe-47db-a6d2-0c0ce46e5459"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("e214a69d-1716-4815-b81b-22bfc27d203e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(741, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a13d0d86-8ec4-428b-9d85-22422b17e4b3"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("4afb8eef-8424-4618-b9a1-6576ff7169e6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(756, 132),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a13d0d86-8ec4-428b-9d85-22422b17e4b3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a5816ab2-fc89-46c9-b765-fc883a751c57"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("456ef303-2cc2-4ea0-b2c3-a1639deb5d7b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(811, 81),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a5816ab2-fc89-46c9-b765-fc883a751c57"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b0824d06-aa50-4291-998c-158027d75f3c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("a385cbea-c321-4c4a-b01a-2771fe86487a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(957, 80),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b0824d06-aa50-4291-998c-158027d75f3c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("645ce592-4039-4a09-81b6-0e17213a8913"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("416ed36c-73aa-40e0-a696-3d4087b84829"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(819, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a13d0d86-8ec4-428b-9d85-22422b17e4b3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0840873f-90de-46aa-83ad-ffee9f1dbd9c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("3f4b6dc0-e5a5-40a7-91ce-c7883660f2d5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(927, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0840873f-90de-46aa-83ad-ffee9f1dbd9c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c2370307-718a-419a-b9c8-fabe4d772f0c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("fab7ffe0-79a3-4a17-ad3c-b1bc7a5ec243"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(1091, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c2370307-718a-419a-b9c8-fabe4d772f0c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("cdb279c0-a2b0-4dca-8f8b-c4201c2e2a8a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow15SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow15",
				UId = new Guid("6b9424b7-cf36-41f9-8ba3-11cda9997246"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(804, 277),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a13d0d86-8ec4-428b-9d85-22422b17e4b3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6ab5ea91-43ce-458d-a7a4-4f584c10c14f"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow16SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow16",
				UId = new Guid("36b5865d-7cf0-494c-b2b8-fc81614eb219"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(926, 322),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6ab5ea91-43ce-458d-a7a4-4f584c10c14f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fb598c27-623f-45e8-a356-973c10f8c81e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow17SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow17",
				UId = new Guid("8eece8cd-e6cc-45e7-8909-2fd4f891d664"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				CurveCenterPosition = new Point(1089, 324),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fb598c27-623f-45e8-a356-973c10f8c81e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0bb38633-49c6-4537-a858-4d3cf3ad4e21"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateOrderVisaLaneSet() {
			ProcessSchemaLaneSet schemaOrderVisa = new ProcessSchemaLaneSet(this) {
				UId = new Guid("02520355-2dd5-47f3-a88b-281cf8d040e2"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"OrderVisa",
				Position = new Point(5, 5),
				Size = new Size(1190, 571),
				UseBackgroundMode = false
			};
			return schemaOrderVisa;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("02520355-2dd5-47f3-a88b-281cf8d040e2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(1161, 571),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartProcessStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("3ad3c2d7-2e4d-4801-90b9-adc3f9a1e128"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"StartProcess",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateErrorEndProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("0cf03be0-f5ba-4629-b8ac-e68a921b26d2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"ErrorEndProcess",
				Position = new Point(190, 443),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("da192822-0ea3-4542-ac3b-745985e64333"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"ExclusiveGateway1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(176, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("628ae4b5-5b8f-477c-ad0a-e2af292bde57"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"FormulaTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(169, 310),
				ResultParameterMetaPath = @"31a29f35-3211-4fc9-a634-b719a4bcbe4f",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,114,45,42,202,47,82,2,0,33,97,29,83,7,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("3ce13491-ee06-4e1b-9ddd-8aa953f4f35a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"ExclusiveGateway2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(330, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"ReadDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(323, 303),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask2FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("62965831-85c2-42aa-95cd-175d0d0ec167"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"FormulaTask2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(323, 415),
				ResultParameterMetaPath = @"31a29f35-3211-4fc9-a634-b719a4bcbe4f",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,114,44,40,40,202,47,75,77,81,2,0,254,184,194,168,10,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateAlreadyExistsVisaEndProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("11d26795-fc8e-4951-92e8-475a7d324942"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"AlreadyExistsVisaEndProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(344, 513),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("607c2930-07fe-47db-a6d2-0c0ce46e5459"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"ChangeDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(463, 170),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaEventBasedGateway CreateVisaEventGatewayEventBasedGateway() {
			ProcessSchemaEventBasedGateway gateway = new ProcessSchemaEventBasedGateway(this) {
				UId = new Guid("a13d0d86-8ec4-428b-9d85-22422b17e4b3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				Instantiate = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0ddbda75-9cac-4e42-b94c-5cf1edb45846"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"VisaEventGateway",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(694, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"AddDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(582, 170),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateIntermediateCatchSignalEvent1IntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("a5816ab2-fc89-46c9-b765-fc883a751c57"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"IntermediateCatchSignalEvent1",
				NewEntityChangedColumns = false,
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(813, 58),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("58ebe36e-7384-4abd-b09c-407c6f508a4d");
			InitializeIntermediateCatchSignalEvent1Parameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask3FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("b0824d06-aa50-4291-998c-158027d75f3c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"FormulaTask3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(939, 44),
				ResultParameterMetaPath = @"31a29f35-3211-4fc9-a634-b719a4bcbe4f",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,114,44,40,40,202,47,75,77,81,2,0,254,184,194,168,10,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateVisaApprovedEndProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("645ce592-4039-4a09-81b6-0e17213a8913"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"VisaApprovedEndProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1093, 58),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateIntermediateCatchSignalEvent2IntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("0840873f-90de-46aa-83ad-ffee9f1dbd9c"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"IntermediateCatchSignalEvent2",
				NewEntityChangedColumns = false,
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(813, 184),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("58ebe36e-7384-4abd-b09c-407c6f508a4d");
			InitializeIntermediateCatchSignalEvent2Parameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask4FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("c2370307-718a-419a-b9c8-fabe4d772f0c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"FormulaTask4",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(939, 170),
				ResultParameterMetaPath = @"31a29f35-3211-4fc9-a634-b719a4bcbe4f",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,10,74,205,74,77,46,73,77,81,2,0,44,45,80,187,10,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateVisaRejectedEndProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("cdb279c0-a2b0-4dca-8f8b-c4201c2e2a8a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"VisaRejectedEndProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1093, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateIntermediateCatchSignalEvent3IntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("6ab5ea91-43ce-458d-a7a4-4f584c10c14f"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"IntermediateCatchSignalEvent3",
				NewEntityChangedColumns = false,
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(813, 303),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("c7d206aa-401c-4095-ba43-757c8f1914e9");
			InitializeIntermediateCatchSignalEvent3Parameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask5FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("fb598c27-623f-45e8-a356-973c10f8c81e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"FormulaTask5",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(939, 289),
				ResultParameterMetaPath = @"31a29f35-3211-4fc9-a634-b719a4bcbe4f",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,114,78,204,75,78,205,73,77,81,2,0,58,56,90,188,10,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateVisaCanceledEndProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("0bb38633-49c6-4537-a858-4d3cf3ad4e21"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("34d97ac5-5685-456a-a06d-6b7aea7a8be1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6085de11-ad02-4192-ac1e-8e1e01838e27"),
				CreatedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"),
				Name = @"VisaCanceledEndProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1093, 303),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new OrderVisaBaseSubprocess(userConnection);
		}

		public override object Clone() {
			return new OrderVisaBaseSubprocessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderVisaBaseSubprocess

	/// <exclude/>
	public class OrderVisaBaseSubprocess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, OrderVisaBaseSubprocess process)
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, OrderVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("8642a8d0-7f1d-4ca0-9233-1c4c3e6d33f9");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,221,138,219,70,20,199,223,69,23,189,210,148,25,205,183,123,151,101,11,129,146,6,250,65,33,44,225,204,204,153,172,88,219,114,44,153,38,24,67,187,185,10,148,6,122,211,171,82,250,6,185,73,179,109,104,158,65,126,163,30,219,235,196,44,238,54,217,52,23,219,246,66,178,70,210,156,175,249,255,230,200,243,187,117,251,113,61,236,112,58,200,48,108,177,156,221,76,131,194,37,237,81,121,203,2,231,137,169,24,57,11,104,45,203,6,156,69,1,42,138,80,148,99,24,225,160,216,204,62,76,117,87,148,117,135,163,118,112,103,254,218,104,55,157,97,121,55,175,7,159,197,99,28,193,23,43,7,26,201,158,138,200,132,141,64,14,140,99,222,162,97,14,43,141,92,160,178,81,23,155,88,114,206,201,58,147,89,8,58,51,5,62,81,84,85,102,104,67,52,136,66,155,12,69,57,196,220,29,62,152,76,177,109,235,102,60,152,227,171,235,207,31,78,40,202,141,239,131,102,56,27,141,139,114,132,29,220,134,238,120,80,84,156,91,153,81,51,37,93,96,170,210,148,105,10,158,9,202,89,91,25,109,10,178,40,35,76,186,149,217,162,255,177,127,218,255,78,199,243,162,156,98,198,41,142,35,238,228,229,120,229,149,118,21,227,38,144,205,12,192,192,81,216,82,86,18,181,150,38,88,81,148,9,58,248,18,134,51,92,199,54,175,105,98,168,188,230,86,100,102,17,60,83,104,42,230,146,0,230,133,15,89,90,89,229,92,109,43,254,73,211,156,204,38,84,237,246,214,108,132,211,58,158,47,29,210,26,52,211,193,60,54,227,110,218,12,87,198,111,237,76,216,44,209,249,195,175,54,101,25,174,159,172,38,22,139,114,214,226,193,176,198,113,119,56,142,77,170,199,247,214,171,183,88,208,156,209,4,166,117,187,45,230,225,253,25,12,169,0,245,189,227,75,139,126,48,107,187,102,116,221,242,45,41,87,50,67,130,93,199,188,210,115,170,219,201,16,30,174,199,131,226,131,251,179,166,251,232,181,20,54,227,226,194,188,237,123,201,8,224,222,121,230,172,165,76,173,147,44,8,33,89,194,160,121,204,66,7,101,207,45,44,202,119,242,116,231,102,251,233,215,227,45,103,155,34,29,125,72,119,47,220,184,189,157,61,152,191,73,112,139,163,109,120,71,164,133,127,148,109,229,193,166,24,73,5,66,112,122,53,36,230,188,148,12,82,4,244,138,171,156,245,213,217,206,82,130,37,151,164,177,164,152,10,220,48,80,228,39,120,244,196,163,81,58,136,93,182,127,232,207,250,231,253,217,242,155,229,163,229,247,203,199,52,250,237,47,40,87,89,169,224,41,185,16,229,42,236,204,64,128,99,17,35,175,162,160,147,143,215,77,245,255,83,190,159,189,61,162,184,156,66,207,157,12,8,154,121,25,72,211,33,18,92,32,29,227,9,44,56,231,121,101,229,223,240,254,214,62,175,64,254,155,132,249,30,201,215,150,6,160,20,243,206,26,106,148,145,72,48,92,50,41,184,86,153,62,63,114,84,87,39,159,218,118,197,13,53,95,197,69,164,147,215,44,128,146,204,106,27,93,22,94,40,244,187,228,255,212,63,91,109,177,203,211,229,35,250,125,177,252,174,255,163,127,186,151,96,207,131,209,33,83,157,114,38,203,66,137,205,214,89,169,138,211,5,100,207,237,150,224,27,77,51,68,24,191,5,194,7,199,24,79,110,52,15,46,2,76,105,198,147,64,247,247,225,187,182,249,14,252,190,18,197,245,74,120,79,155,190,8,199,250,197,247,32,222,40,83,48,86,5,150,0,144,169,68,236,128,131,138,165,36,93,132,12,149,92,237,255,87,21,175,118,20,137,52,200,172,116,212,182,128,154,98,224,126,37,99,27,77,214,220,129,74,187,226,253,165,127,185,252,118,121,74,231,39,36,219,179,254,217,254,166,101,12,73,95,67,100,154,224,32,226,144,242,211,192,169,225,130,119,40,109,214,54,255,119,154,214,229,162,255,23,124,157,254,220,191,236,95,208,241,43,245,145,83,218,222,206,55,181,229,147,203,59,9,90,159,33,6,218,136,163,36,149,72,180,12,232,191,32,19,85,0,65,32,24,33,171,157,166,112,180,248,19,149,138,216,62,65,14,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,79,202,74,77,46,201,44,75,181,50,180,50,4,0,6,191,96,252,20,0,0,0 })));
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
								new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"));
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

			public ChangeDataUserTask1FlowElement(UserConnection userConnection, OrderVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("607c2930-07fe-47db-a6d2-0c0ce46e5459");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_IsCanceled = () => (bool)(true);
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_IsCanceled", () => _recordColumnValues_IsCanceled.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<bool> _recordColumnValues_IsCanceled;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,150,75,139,27,71,16,199,191,203,28,114,154,14,253,126,40,55,47,27,48,132,141,33,15,2,102,49,253,168,246,14,59,210,200,154,17,177,17,130,196,62,25,66,12,185,228,20,66,190,129,47,142,55,49,241,103,152,249,70,41,73,43,91,44,202,198,94,219,135,13,57,104,52,221,51,93,93,85,243,255,85,245,226,78,213,126,90,213,29,204,70,217,215,45,148,243,155,105,84,120,171,21,15,41,146,4,202,17,25,132,37,142,7,70,168,224,153,219,16,82,118,161,40,39,126,12,163,98,179,250,48,85,93,81,86,29,140,219,209,237,197,107,163,221,108,14,229,157,188,30,124,17,79,96,236,191,90,109,160,32,128,145,17,8,51,209,19,25,53,110,96,64,19,11,92,1,101,32,77,84,197,198,23,237,85,214,201,121,18,147,146,68,58,161,73,136,32,136,129,160,68,14,148,229,152,138,178,134,220,29,222,159,206,160,109,171,102,50,90,192,171,251,47,31,76,209,203,205,222,7,77,61,31,79,138,114,12,157,191,229,187,147,81,193,41,53,34,131,34,82,216,64,36,87,148,132,20,28,97,49,82,101,68,52,41,136,162,140,126,218,173,204,22,253,207,253,211,254,79,252,61,47,202,25,100,152,193,36,194,78,92,150,114,39,149,229,132,234,128,54,179,247,196,91,149,137,16,92,128,82,66,7,195,138,50,249,206,127,237,235,57,172,125,91,84,184,48,112,167,168,97,25,195,242,152,113,208,156,216,196,60,113,204,133,44,12,230,61,243,109,198,63,107,154,211,249,20,179,221,30,205,199,48,171,226,249,167,3,252,6,205,108,180,136,205,164,155,53,245,202,248,209,206,130,205,39,58,127,248,205,38,45,245,250,201,106,97,177,44,231,45,28,212,21,76,186,195,73,108,82,53,185,187,254,122,203,37,174,25,79,253,172,106,183,201,60,188,55,247,53,38,160,186,123,114,105,210,15,230,109,215,140,175,91,188,37,198,138,102,80,176,107,159,87,122,78,85,59,173,253,131,245,120,84,124,116,111,222,116,159,188,150,194,102,92,92,88,183,125,47,105,230,169,179,142,88,99,48,82,99,5,9,140,9,68,43,40,26,51,83,65,154,115,11,203,242,157,118,186,125,179,253,252,219,201,150,179,77,146,142,63,198,217,11,19,183,182,171,71,139,55,113,110,121,188,117,239,24,181,240,94,217,102,217,134,40,176,206,224,36,226,2,6,136,179,66,18,238,172,1,38,147,64,215,174,206,118,22,194,27,220,18,53,150,176,114,4,170,137,151,12,1,119,224,144,71,45,85,96,187,108,255,212,159,245,207,251,179,225,187,225,209,240,227,240,24,71,127,252,3,229,50,75,25,176,36,73,244,30,35,12,153,120,230,45,137,16,41,143,12,47,46,94,55,213,255,79,249,126,246,246,136,226,114,10,29,181,34,128,87,196,137,64,87,10,65,184,60,54,80,154,188,241,214,58,202,141,248,23,222,223,122,207,43,144,255,38,110,126,64,242,181,82,209,74,236,187,22,32,175,154,47,35,158,99,13,0,22,17,8,154,19,95,157,48,174,74,62,182,109,78,53,54,95,73,89,196,139,83,36,120,137,103,6,101,162,205,204,49,9,110,151,252,95,250,103,171,18,59,60,28,30,225,255,139,225,135,254,175,254,233,94,130,29,13,90,133,140,121,202,25,45,51,201,54,165,147,75,78,241,198,103,71,205,150,224,27,77,83,131,159,188,5,194,7,39,16,79,111,52,247,47,2,140,97,198,211,128,243,251,240,93,219,124,7,126,95,137,226,122,5,188,167,77,95,132,99,253,226,7,16,111,74,62,98,39,81,36,135,200,177,140,103,67,172,114,129,68,166,53,54,130,100,192,230,171,139,87,89,244,68,104,32,70,88,108,91,62,36,18,168,91,201,216,68,157,21,181,94,166,93,241,254,214,191,28,190,31,30,226,245,9,202,246,172,127,182,191,105,105,141,210,87,62,18,133,112,224,209,20,48,62,229,41,177,206,59,11,194,100,101,242,245,111,90,71,77,247,126,116,255,31,56,160,254,218,191,236,95,224,239,119,108,37,15,177,194,157,215,181,225,201,229,205,4,140,203,62,6,65,68,20,40,20,1,134,120,229,144,11,30,60,67,22,52,19,124,167,47,28,47,255,6,13,157,50,237,68,14,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,82,91,79,195,32,20,254,43,134,248,56,22,218,65,105,247,168,211,100,137,51,139,211,189,88,31,78,233,65,155,244,178,80,102,212,165,255,93,138,93,214,37,250,34,15,208,114,206,119,225,131,3,185,180,159,59,36,115,114,181,94,109,26,109,167,215,141,193,233,218,52,10,219,118,122,215,40,40,139,47,200,74,92,131,129,10,45,154,45,148,123,108,239,138,214,78,46,198,32,50,33,151,239,190,70,230,207,7,178,180,88,61,45,115,199,60,131,16,145,229,130,98,206,5,229,90,10,10,2,67,10,1,203,117,150,97,4,51,112,96,213,148,251,170,94,161,133,53,216,55,50,63,16,207,230,8,148,204,67,22,1,80,206,2,229,166,68,208,12,248,140,74,33,85,172,131,36,224,152,144,110,66,90,245,134,21,120,209,19,88,96,134,146,43,164,129,84,142,65,69,49,77,36,70,52,198,80,32,11,144,75,37,122,240,208,127,2,90,227,22,87,200,139,118,87,194,231,246,175,250,238,44,152,113,199,33,253,73,55,37,243,244,247,124,135,117,227,141,159,39,124,30,110,74,38,41,217,52,123,163,122,182,89,255,115,60,172,103,103,195,160,191,76,199,241,195,225,97,43,168,225,21,205,189,211,243,112,95,90,128,5,47,253,232,60,31,137,19,150,69,34,211,49,101,90,187,236,3,30,208,88,202,132,134,60,100,238,3,116,194,164,71,63,160,70,131,181,194,127,26,219,246,202,39,51,199,119,224,118,234,125,89,122,129,214,159,191,127,88,131,241,161,178,24,221,208,136,161,201,11,93,96,190,172,255,233,104,129,218,83,222,54,230,230,195,61,247,162,126,29,238,107,36,125,234,89,168,106,216,239,72,215,189,116,223,59,18,41,195,91,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "f20cf97d26c94e96963d91df1c9d86be",
							"BaseElements.ChangeDataUserTask1.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("ef11e995-ba92-40e9-9077-1a6fee8d4c35");
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

		#region Class: AddDataUserTask1FlowElement

		/// <exclude/>
		public class AddDataUserTask1FlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddDataUserTask1FlowElement(UserConnection userConnection, OrderVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("79386b89-3dc1-45f8-920c-163c2dd52bab");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Order = () => (Guid)((process.Order));
				_recordDefValues_VisaOwner = () => (Guid)((process.VisaOwner));
				_recordDefValues_Objective = () => new LocalizableString((process.VisaObjective));
				_recordDefValues_IsAllowedToDelegate = () => (bool)((process.IsAllowedToDelegate));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Order", () => _recordDefValues_Order.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_VisaOwner", () => _recordDefValues_VisaOwner.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Objective", () => _recordDefValues_Objective.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_IsAllowedToDelegate", () => _recordDefValues_IsAllowedToDelegate.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Order;
			internal Func<Guid> _recordDefValues_VisaOwner;
			internal Func<string> _recordDefValues_Objective;
			internal Func<bool> _recordDefValues_IsAllowedToDelegate;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5");
			public override Guid EntitySchemaId {
				get {
					return _entitySchemaId;
				}
				set {
					_entitySchemaId = value;
				}
			}

			private EntityColumnMappingValues _recordDefValues;
			public override EntityColumnMappingValues RecordDefValues {
				get {
					if (_recordDefValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,150,75,111,28,69,16,128,255,138,53,201,209,101,245,251,177,71,48,72,150,98,176,8,228,98,251,80,221,93,157,172,180,222,181,118,215,64,176,86,138,196,5,4,226,192,133,43,39,206,17,96,197,128,200,111,152,253,71,212,140,215,120,77,34,203,226,100,37,25,105,102,119,166,187,30,93,213,95,85,159,54,247,231,79,143,169,25,52,239,237,237,62,156,212,249,214,251,147,41,109,237,77,39,153,102,179,173,7,147,140,163,225,87,152,70,180,135,83,60,162,57,77,31,225,232,132,102,15,134,179,249,230,198,186,80,179,217,220,255,188,31,107,6,251,167,205,206,156,142,62,219,41,172,89,134,224,181,47,17,76,42,1,76,241,9,146,21,6,180,12,82,6,79,214,41,193,194,121,50,58,57,26,239,210,28,247,112,254,164,25,156,54,189,54,86,160,132,240,186,146,5,163,67,2,163,172,128,84,82,4,153,179,176,94,103,95,146,110,22,155,205,44,63,161,35,236,141,94,9,91,74,228,77,38,144,62,35,152,236,2,68,79,14,2,41,75,66,146,241,217,118,194,171,249,87,130,251,247,246,119,102,31,127,49,166,233,195,94,239,160,226,104,70,135,91,252,245,63,31,254,13,205,224,180,56,137,34,134,8,193,123,94,176,15,26,146,148,26,10,241,146,115,149,54,25,191,56,188,119,216,89,44,195,217,241,8,159,62,122,213,112,251,83,251,188,253,147,239,23,23,51,143,175,197,126,125,238,233,193,69,2,15,154,193,193,235,83,184,250,189,112,249,122,18,175,231,239,160,217,60,104,30,78,78,166,185,211,166,187,151,203,120,246,218,197,234,130,215,60,46,175,11,29,189,216,46,142,241,49,77,63,98,123,189,120,63,180,141,115,236,77,127,202,62,95,42,78,42,90,225,101,5,79,200,49,35,167,32,20,137,16,101,76,85,123,173,106,85,189,244,39,84,105,74,227,76,215,29,11,66,69,99,131,2,225,18,239,145,138,8,24,108,5,173,149,38,107,181,75,94,246,242,189,229,43,103,46,183,26,127,25,159,140,70,189,129,89,191,254,110,239,174,28,95,141,108,175,229,106,77,195,164,12,235,144,202,206,248,127,134,106,155,106,175,242,195,201,244,131,47,153,168,225,248,241,42,95,107,166,175,230,108,231,163,213,247,69,179,88,108,174,67,230,164,115,74,107,15,17,137,192,88,38,45,5,171,64,85,163,116,113,85,229,104,111,132,172,106,141,158,137,224,44,20,195,168,10,7,104,36,147,22,41,114,32,157,177,73,222,17,200,162,8,58,17,90,136,58,9,118,53,51,110,168,3,136,130,30,67,136,66,121,125,11,200,126,108,207,219,23,237,249,242,217,242,235,229,15,203,111,249,237,143,119,184,221,2,55,83,141,73,145,211,156,178,230,92,167,10,40,49,64,166,44,84,150,252,136,249,141,199,205,70,93,163,112,6,148,173,220,146,184,19,65,226,26,4,58,104,222,253,85,135,154,227,141,184,101,21,84,14,202,128,71,148,192,1,53,204,107,21,80,50,138,74,186,132,100,210,29,193,13,125,81,162,114,191,229,162,204,9,175,46,67,200,217,65,114,20,2,134,108,180,185,13,110,191,180,103,237,95,203,239,55,218,95,59,238,150,223,189,13,172,21,62,153,160,228,130,44,60,117,71,31,110,109,201,115,147,43,130,156,12,73,112,88,203,77,172,221,218,177,55,153,181,106,130,204,81,9,64,202,170,11,98,130,72,34,66,86,78,112,127,231,138,149,194,141,172,249,98,172,54,137,219,98,96,79,141,143,124,40,11,38,128,243,94,22,52,172,218,187,187,194,90,226,62,46,184,144,100,35,61,24,71,188,214,128,134,93,205,73,89,239,66,162,114,11,214,126,238,206,142,203,103,237,217,242,27,166,238,239,246,229,70,251,123,135,31,223,191,117,29,175,125,201,20,62,231,129,243,246,236,109,224,48,138,228,108,170,124,68,168,53,115,185,54,242,226,128,174,140,18,252,7,185,150,251,119,28,210,43,28,30,46,254,1,50,58,233,249,33,14,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "f20cf97d26c94e96963d91df1c9d86be",
							"BaseElements.AddDataUserTask1.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("ef11e995-ba92-40e9-9077-1a6fee8d4c35");
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

		#region Class: IntermediateCatchSignalEvent1FlowElement

		/// <exclude/>
		public class IntermediateCatchSignalEvent1FlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public IntermediateCatchSignalEvent1FlowElement(UserConnection userConnection, OrderVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "IntermediateCatchSignalEvent1";
				IsLogging = false;
				SchemaElementUId = new Guid("a5816ab2-fc89-46c9-b765-fc883a751c57");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""58ebe36e-7384-4abd-b09c-407c6f508a4d""]}";
				EntityFilters = @"{_isFilter:false,uId:""9ab6c665-e152-40ba-a827-1ccb9ce9e285"",name:""FilterEdit"",items:[{_isFilter:true,_filterSchemaUId:""5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"",uId:""5c734bfa-8975-4adf-87ca-82ea5c384b5c"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""58ebe36e-7384-4abd-b09c-407c6f508a4d"",caption:""Состояние"",referenceSchemaUId:""66c8f5ac-57d2-4fe8-95a0-89a98e37f57f"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true},parameterValues:[{displayValue:""&quot;Положительная&quot;"",parameterValue:""&quot;e79facb3-3c32-43e7-a59e-12ba125e6132&quot;""}]}},{_isFilter:true,_filterSchemaUId:""5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"",uId:""93604a91-4a82-4c7a-b1ec-420b8412c9b2"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""c7d206aa-401c-4095-ba43-757c8f1914e9"",caption:""Неактуальна"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false},parameterValues:[{parameterValue:""false""}]}}]}";
				_recordId = () => (Guid)((process.AddDataUserTask1.RecordId));
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

			#endregion

		}

		#endregion

		#region Class: IntermediateCatchSignalEvent2FlowElement

		/// <exclude/>
		public class IntermediateCatchSignalEvent2FlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public IntermediateCatchSignalEvent2FlowElement(UserConnection userConnection, OrderVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "IntermediateCatchSignalEvent2";
				IsLogging = false;
				SchemaElementUId = new Guid("0840873f-90de-46aa-83ad-ffee9f1dbd9c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""58ebe36e-7384-4abd-b09c-407c6f508a4d""]}";
				EntityFilters = @"{_isFilter:false,uId:""dc18c4b1-c7bc-4aee-9544-0b37b1596341"",name:""FilterEdit"",items:[{_isFilter:true,_filterSchemaUId:""5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"",uId:""b9cb58cf-39c5-4e9f-8a6f-c7db5ce0c14d"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""58ebe36e-7384-4abd-b09c-407c6f508a4d"",caption:""Состояние"",referenceSchemaUId:""66c8f5ac-57d2-4fe8-95a0-89a98e37f57f"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true},parameterValues:[{displayValue:""&quot;Отрицательная&quot;"",parameterValue:""&quot;a93ab0b9-ca36-4b95-9b23-e01aa169c338&quot;""}]}},{_isFilter:true,_filterSchemaUId:""5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"",uId:""65704568-78e8-4381-802a-6558d898e85c"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""c7d206aa-401c-4095-ba43-757c8f1914e9"",caption:""Неактуальна"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false},parameterValues:[{parameterValue:""false""}]}}]}";
				_recordId = () => (Guid)((process.AddDataUserTask1.RecordId));
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

			#endregion

		}

		#endregion

		#region Class: IntermediateCatchSignalEvent3FlowElement

		/// <exclude/>
		public class IntermediateCatchSignalEvent3FlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public IntermediateCatchSignalEvent3FlowElement(UserConnection userConnection, OrderVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "IntermediateCatchSignalEvent3";
				IsLogging = false;
				SchemaElementUId = new Guid("6ab5ea91-43ce-458d-a7a4-4f584c10c14f");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("5ebe74ce-17ca-4c68-97e6-8e25e01e47c5");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""c7d206aa-401c-4095-ba43-757c8f1914e9""]}";
				EntityFilters = @"{_isFilter:false,uId:""b7b3e303-3b88-49cb-b059-e921d77d816d"",name:""FilterEdit"",items:[{_isFilter:true,_filterSchemaUId:""5ebe74ce-17ca-4c68-97e6-8e25e01e47c5"",uId:""c01373f7-59e4-4771-af0b-8cee4ede4312"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""c7d206aa-401c-4095-ba43-757c8f1914e9"",caption:""Неактуальна"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false},parameterValues:[{parameterValue:""true""}]}}]}";
				_recordId = () => (Guid)((process.AddDataUserTask1.RecordId));
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

			#endregion

		}

		#endregion

		public OrderVisaBaseSubprocess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderVisaBaseSubprocess";
			SchemaUId = new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be");
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
				return new Guid("f20cf97d-26c9-4e96-963d-91df1c9d86be");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: OrderVisaBaseSubprocess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: OrderVisaBaseSubprocess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid Order {
			get;
			set;
		}

		public virtual Guid VisaOwner {
			get;
			set;
		}

		public virtual string VisaObjective {
			get;
			set;
		}

		public virtual string VisaResult {
			get;
			set;
		}

		public virtual bool IsAllowedToDelegate {
			get;
			set;
		}

		public virtual bool IsPreviousVisaCounts {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _startProcess;
		public ProcessFlowElement StartProcess {
			get {
				return _startProcess ?? (_startProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartProcess",
					SchemaElementUId = new Guid("3ad3c2d7-2e4d-4801-90b9-adc3f9a1e128"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessTerminateEvent _errorEndProcess;
		public ProcessTerminateEvent ErrorEndProcess {
			get {
				return _errorEndProcess ?? (_errorEndProcess = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "ErrorEndProcess",
					SchemaElementUId = new Guid("0cf03be0-f5ba-4629-b8ac-e68a921b26d2"),
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
					SchemaElementUId = new Guid("da192822-0ea3-4542-ac3b-745985e64333"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
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
					SchemaElementUId = new Guid("628ae4b5-5b8f-477c-ad0a-e2af292bde57"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("3ce13491-ee06-4e1b-9ddd-8aa953f4f35a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway2.Question"),
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

		private ProcessScriptTask _formulaTask2;
		public ProcessScriptTask FormulaTask2 {
			get {
				return _formulaTask2 ?? (_formulaTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask2",
					SchemaElementUId = new Guid("62965831-85c2-42aa-95cd-175d0d0ec167"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask2Execute,
				});
			}
		}

		private ProcessTerminateEvent _alreadyExistsVisaEndProcess;
		public ProcessTerminateEvent AlreadyExistsVisaEndProcess {
			get {
				return _alreadyExistsVisaEndProcess ?? (_alreadyExistsVisaEndProcess = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "AlreadyExistsVisaEndProcess",
					SchemaElementUId = new Guid("11d26795-fc8e-4951-92e8-475a7d324942"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ChangeDataUserTask1FlowElement _changeDataUserTask1;
		public ChangeDataUserTask1FlowElement ChangeDataUserTask1 {
			get {
				return _changeDataUserTask1 ?? (_changeDataUserTask1 = new ChangeDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveEventBasedGateway _visaEventGateway;
		public ProcessExclusiveEventBasedGateway VisaEventGateway {
			get {
				return _visaEventGateway ?? (_visaEventGateway = new ProcessExclusiveEventBasedGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventBasedGateway",
					Name = "VisaEventGateway",
					SchemaElementUId = new Guid("a13d0d86-8ec4-428b-9d85-22422b17e4b3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Events = new Collection<string> { "IntermediateCatchSignalEvent1", "IntermediateCatchSignalEvent2", "IntermediateCatchSignalEvent3", },
				});
			}
		}

		private AddDataUserTask1FlowElement _addDataUserTask1;
		public AddDataUserTask1FlowElement AddDataUserTask1 {
			get {
				return _addDataUserTask1 ?? (_addDataUserTask1 = new AddDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private IntermediateCatchSignalEvent1FlowElement _intermediateCatchSignalEvent1;
		public IntermediateCatchSignalEvent1FlowElement IntermediateCatchSignalEvent1 {
			get {
				return _intermediateCatchSignalEvent1 ?? ((_intermediateCatchSignalEvent1) = new IntermediateCatchSignalEvent1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _formulaTask3;
		public ProcessScriptTask FormulaTask3 {
			get {
				return _formulaTask3 ?? (_formulaTask3 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask3",
					SchemaElementUId = new Guid("b0824d06-aa50-4291-998c-158027d75f3c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask3Execute,
				});
			}
		}

		private ProcessTerminateEvent _visaApprovedEndProcess;
		public ProcessTerminateEvent VisaApprovedEndProcess {
			get {
				return _visaApprovedEndProcess ?? (_visaApprovedEndProcess = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "VisaApprovedEndProcess",
					SchemaElementUId = new Guid("645ce592-4039-4a09-81b6-0e17213a8913"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private IntermediateCatchSignalEvent2FlowElement _intermediateCatchSignalEvent2;
		public IntermediateCatchSignalEvent2FlowElement IntermediateCatchSignalEvent2 {
			get {
				return _intermediateCatchSignalEvent2 ?? ((_intermediateCatchSignalEvent2) = new IntermediateCatchSignalEvent2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _formulaTask4;
		public ProcessScriptTask FormulaTask4 {
			get {
				return _formulaTask4 ?? (_formulaTask4 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask4",
					SchemaElementUId = new Guid("c2370307-718a-419a-b9c8-fabe4d772f0c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask4Execute,
				});
			}
		}

		private ProcessTerminateEvent _visaRejectedEndProcess;
		public ProcessTerminateEvent VisaRejectedEndProcess {
			get {
				return _visaRejectedEndProcess ?? (_visaRejectedEndProcess = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "VisaRejectedEndProcess",
					SchemaElementUId = new Guid("cdb279c0-a2b0-4dca-8f8b-c4201c2e2a8a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private IntermediateCatchSignalEvent3FlowElement _intermediateCatchSignalEvent3;
		public IntermediateCatchSignalEvent3FlowElement IntermediateCatchSignalEvent3 {
			get {
				return _intermediateCatchSignalEvent3 ?? ((_intermediateCatchSignalEvent3) = new IntermediateCatchSignalEvent3FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _formulaTask5;
		public ProcessScriptTask FormulaTask5 {
			get {
				return _formulaTask5 ?? (_formulaTask5 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask5",
					SchemaElementUId = new Guid("fb598c27-623f-45e8-a356-973c10f8c81e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask5Execute,
				});
			}
		}

		private ProcessTerminateEvent _visaCanceledEndProcess;
		public ProcessTerminateEvent VisaCanceledEndProcess {
			get {
				return _visaCanceledEndProcess ?? (_visaCanceledEndProcess = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "VisaCanceledEndProcess",
					SchemaElementUId = new Guid("0bb38633-49c6-4537-a858-4d3cf3ad4e21"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("e24b4502-eda7-4443-bab4-eab12e044974"),
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
					SchemaElementUId = new Guid("c4ebf13f-3b7a-4280-88b0-b0585f1b8c72"),
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
					SchemaElementUId = new Guid("6b6fcea0-ef81-4fa0-bbcc-711ae6b9a4f1"),
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
			FlowElements[StartProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { StartProcess };
			FlowElements[ErrorEndProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ErrorEndProcess };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[FormulaTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask2 };
			FlowElements[AlreadyExistsVisaEndProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { AlreadyExistsVisaEndProcess };
			FlowElements[ChangeDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask1 };
			FlowElements[VisaEventGateway.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaEventGateway };
			FlowElements[AddDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataUserTask1 };
			FlowElements[IntermediateCatchSignalEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateCatchSignalEvent1 };
			FlowElements[FormulaTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask3 };
			FlowElements[VisaApprovedEndProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaApprovedEndProcess };
			FlowElements[IntermediateCatchSignalEvent2.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateCatchSignalEvent2 };
			FlowElements[FormulaTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask4 };
			FlowElements[VisaRejectedEndProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaRejectedEndProcess };
			FlowElements[IntermediateCatchSignalEvent3.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateCatchSignalEvent3 };
			FlowElements[FormulaTask5.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask5 };
			FlowElements[VisaCanceledEndProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaCanceledEndProcess };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ErrorEndProcess":
						CompleteProcess();
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ErrorEndProcess", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask1", e.Context.SenderName));
						break;
					case "FormulaTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AlreadyExistsVisaEndProcess", e.Context.SenderName));
						break;
					case "AlreadyExistsVisaEndProcess":
						CompleteProcess();
						break;
					case "ChangeDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataUserTask1", e.Context.SenderName));
						break;
					case "VisaEventGateway":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("IntermediateCatchSignalEvent1", e.Context.SenderName));
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("IntermediateCatchSignalEvent2", e.Context.SenderName));
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("IntermediateCatchSignalEvent3", e.Context.SenderName));
						break;
					case "AddDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaEventGateway", e.Context.SenderName));
						break;
					case "IntermediateCatchSignalEvent1":
						VisaEventGateway.CancelNonexecutedEvents("IntermediateCatchSignalEvent1");
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask3", e.Context.SenderName));
						break;
					case "FormulaTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaApprovedEndProcess", e.Context.SenderName));
						break;
					case "VisaApprovedEndProcess":
						CompleteProcess();
						break;
					case "IntermediateCatchSignalEvent2":
						VisaEventGateway.CancelNonexecutedEvents("IntermediateCatchSignalEvent2");
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask4", e.Context.SenderName));
						break;
					case "FormulaTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaRejectedEndProcess", e.Context.SenderName));
						break;
					case "VisaRejectedEndProcess":
						CompleteProcess();
						break;
					case "IntermediateCatchSignalEvent3":
						VisaEventGateway.CancelNonexecutedEvents("IntermediateCatchSignalEvent3");
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask5", e.Context.SenderName));
						break;
					case "FormulaTask5":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaCanceledEndProcess", e.Context.SenderName));
						break;
					case "VisaCanceledEndProcess":
						CompleteProcess();
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((VisaOwner) == null || (Order) == null);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow1", "(VisaOwner) == null || (Order) == null", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((IsPreviousVisaCounts));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalFlow2", "(IsPreviousVisaCounts)", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean((ReadDataUserTask1.ResultCount) > 0
);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask1", "ConditionalFlow3", "(ReadDataUserTask1.ResultCount) > 0\n", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("Order")) {
				writer.WriteValue("Order", Order, Guid.Empty);
			}
			if (!HasMapping("VisaOwner")) {
				writer.WriteValue("VisaOwner", VisaOwner, Guid.Empty);
			}
			if (!HasMapping("VisaObjective")) {
				writer.WriteValue("VisaObjective", VisaObjective, null);
			}
			if (!HasMapping("VisaResult")) {
				writer.WriteValue("VisaResult", VisaResult, null);
			}
			if (!HasMapping("IsAllowedToDelegate")) {
				writer.WriteValue("IsAllowedToDelegate", IsAllowedToDelegate, false);
			}
			if (!HasMapping("IsPreviousVisaCounts")) {
				writer.WriteValue("IsPreviousVisaCounts", IsPreviousVisaCounts, false);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartProcess", string.Empty));
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
			MetaPathParameterValues.Add("d61a0989-8779-4783-b113-deb50cf15b47", () => Order);
			MetaPathParameterValues.Add("9083bea5-93b0-4bc9-8a38-0da7a8890273", () => VisaOwner);
			MetaPathParameterValues.Add("a7d20fb9-d1a3-4f6c-8cc6-b6e88a8c4343", () => VisaObjective);
			MetaPathParameterValues.Add("31a29f35-3211-4fc9-a634-b719a4bcbe4f", () => VisaResult);
			MetaPathParameterValues.Add("ab166058-c417-46eb-98a4-67cb25768bed", () => IsAllowedToDelegate);
			MetaPathParameterValues.Add("7a369c26-a919-430e-9fcc-b7dbd03e82cc", () => IsPreviousVisaCounts);
			MetaPathParameterValues.Add("04f4034b-c6d8-4043-81ff-11c4f91ff61f", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("e666ae4f-cd81-441a-9f61-c2de41eb84f2", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("0eedbcbc-25ab-494a-bbeb-e21d15d3be92", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("382fa627-a8e0-4d33-862f-361c9d9220da", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("3c107cd1-2016-4d0e-b57d-815d74cd3861", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("0ca6bb93-a18e-49e0-ac02-7b6f8cdb0549", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("614e748d-e9f4-4f3b-bdc4-35ee7dcb1b74", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("15145695-748a-430e-b902-b281b552c89f", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("b3e85650-29fb-4199-af80-4eaf98698a27", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("31a4ff18-1803-4d14-8843-1882f4aebc11", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("12fa2c87-6548-4026-a641-3939fadc4b42", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("e8720629-f6ec-43e7-8a7b-2c24630badb3", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("c003ab55-826d-4b64-9e5f-8804a5848b21", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("0ef917e9-7826-4a02-b4bd-171856e1ef12", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("4ece07e9-a9db-4a55-87b9-48e11c9ff7e5", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("4b15cb40-0f50-4078-a24f-a5956fc6b157", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("3785519b-3fe4-434c-86da-2b81ae73e599", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("153ddfa4-67d6-4be6-b015-deefed442eb8", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("dc25ae11-2965-4477-9857-699bd9d2adb0", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("1404379d-a79a-4596-893d-7c620dfd8caf", () => ChangeDataUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("55ef8b53-d3cc-43e6-b2cb-7bf702d94f72", () => ChangeDataUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("e99d85dc-8cbe-4f1e-ba54-7c57ddf21953", () => ChangeDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("cb208bfe-de96-49f6-81bc-f82ec1afd252", () => ChangeDataUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("b1068955-5851-43c7-a7cf-e923621021db", () => ChangeDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("8aad1115-eaba-4c12-98ce-a8b0ae405981", () => AddDataUserTask1.EntitySchemaId);
			MetaPathParameterValues.Add("9df5d5d0-f073-472c-859b-f5e3b67221ea", () => AddDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("443af2ec-aeea-4cc0-886a-e903dd5eefa7", () => AddDataUserTask1.RecordAddMode);
			MetaPathParameterValues.Add("d0252b09-da98-4d4e-9dc0-ef8bb6f92f23", () => AddDataUserTask1.FilterEntitySchemaId);
			MetaPathParameterValues.Add("48aec832-cd69-4509-a9b4-abd75a914dc6", () => AddDataUserTask1.RecordDefValues);
			MetaPathParameterValues.Add("70f3c8ce-16ff-40fc-8eda-5a3419a1ec22", () => AddDataUserTask1.RecordId);
			MetaPathParameterValues.Add("76fb1c92-4acb-475e-95bf-e3b9ff59dfb5", () => AddDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("fbb5cec9-6a5b-44ae-829a-1f19c78d0339", () => IntermediateCatchSignalEvent1.RecordId);
			MetaPathParameterValues.Add("2baee59c-8079-46b4-8f24-2a77f99b38b2", () => IntermediateCatchSignalEvent2.RecordId);
			MetaPathParameterValues.Add("dbcabc88-7940-493a-9211-1d7ef9018176", () => IntermediateCatchSignalEvent3.RecordId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "Order":
					if (!hasValueToRead) break;
					Order = reader.GetValue<System.Guid>();
				break;
				case "VisaOwner":
					if (!hasValueToRead) break;
					VisaOwner = reader.GetValue<System.Guid>();
				break;
				case "VisaObjective":
					if (!hasValueToRead) break;
					VisaObjective = reader.GetValue<System.String>();
				break;
				case "VisaResult":
					if (!hasValueToRead) break;
					VisaResult = reader.GetValue<System.String>();
				break;
				case "IsAllowedToDelegate":
					if (!hasValueToRead) break;
					IsAllowedToDelegate = reader.GetValue<System.Boolean>();
				break;
				case "IsPreviousVisaCounts":
					if (!hasValueToRead) break;
					IsPreviousVisaCounts = reader.GetValue<System.Boolean>();
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
			var localVisaResult = "Error";
			VisaResult = (System.String)localVisaResult;
			return true;
		}

		public virtual bool FormulaTask2Execute(ProcessExecutingContext context) {
			var localVisaResult = "Approved";
			VisaResult = (System.String)localVisaResult;
			return true;
		}

		public virtual bool FormulaTask3Execute(ProcessExecutingContext context) {
			var localVisaResult = "Approved";
			VisaResult = (System.String)localVisaResult;
			return true;
		}

		public virtual bool FormulaTask4Execute(ProcessExecutingContext context) {
			var localVisaResult = "Rejected";
			VisaResult = (System.String)localVisaResult;
			return true;
		}

		public virtual bool FormulaTask5Execute(ProcessExecutingContext context) {
			var localVisaResult = "Canceled";
			VisaResult = (System.String)localVisaResult;
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
			var cloneItem = (OrderVisaBaseSubprocess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

