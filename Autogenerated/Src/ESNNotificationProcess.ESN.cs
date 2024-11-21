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
	using BPMSoft.Messaging.Common;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: ESNNotificationProcessSchema

	/// <exclude/>
	public class ESNNotificationProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ESNNotificationProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ESNNotificationProcessSchema(ESNNotificationProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ESNNotificationProcess";
			UId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3");
			CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.8.0.0";
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
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3");
			Version = 0;
			PackageUId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateNotificationIdParameterParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f0a3cf6a-71c5-4eef-add2-9dfe3c7b24a4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"NotificationIdParameter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateNotificationIdParameterParameter());
		}

		protected virtual void InitializeOnPostCommentedStartSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d70075ca-9e0b-44df-a779-e59e0e2f85b4"),
				ContainerUId = new Guid("08f41d99-9838-418a-b579-a7177272506b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("08f41d99-9838-418a-b579-a7177272506b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
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
				UId = new Guid("2f478e43-a126-41ef-bd27-886141b52843"),
				ContainerUId = new Guid("08f41d99-9838-418a-b579-a7177272506b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("08f41d99-9838-418a-b579-a7177272506b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"b0e78c23-7095-4d59-b8eb-c10243bcd67b",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeReadCommentedPostUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ba9ba9d2-475d-40f2-8404-7ac59bcee891"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,75,111,212,48,16,254,43,171,156,235,42,15,219,73,246,6,101,65,61,148,86,108,213,11,219,131,99,143,83,11,231,33,199,91,88,86,251,223,25,39,237,178,69,43,88,184,128,68,78,241,167,111,102,190,121,110,35,105,197,48,188,23,13,68,243,232,245,205,213,178,211,254,252,173,177,30,220,59,215,173,251,232,44,26,192,25,97,205,87,80,19,190,80,198,191,17,94,160,193,118,245,221,126,21,205,87,199,60,172,162,179,85,100,60,52,3,50,208,128,177,44,43,88,174,8,75,41,37,84,8,73,42,149,115,194,85,201,121,34,181,172,146,124,98,30,119,125,209,53,189,112,48,69,24,157,235,241,247,118,211,7,98,130,128,28,41,102,232,218,39,48,11,18,134,69,43,42,11,10,223,222,173,1,33,239,76,131,153,192,173,105,224,70,56,140,20,252,116,1,66,146,22,118,8,44,11,218,47,190,244,14,134,193,116,237,207,165,217,117,211,30,114,209,28,246,207,39,49,241,168,48,48,111,132,127,24,29,92,162,168,221,168,241,85,93,59,168,133,55,143,135,18,62,193,102,228,157,86,59,52,80,216,159,59,97,215,112,16,243,101,30,23,162,247,83,58,83,120,36,56,83,63,156,152,233,190,90,191,74,54,69,176,127,38,159,228,241,168,254,148,35,248,24,128,201,199,243,239,42,250,120,57,92,127,110,193,45,229,3,52,98,170,216,253,57,162,63,0,11,11,13,180,126,190,213,156,38,66,82,73,88,85,100,88,195,84,144,42,41,10,34,160,140,139,42,102,25,139,245,14,13,246,130,230,219,52,145,84,151,37,37,149,200,11,66,41,7,130,175,148,40,94,232,52,78,178,178,224,89,48,89,180,222,248,205,52,5,243,173,130,148,198,188,224,36,171,116,74,104,206,74,82,113,45,73,1,5,43,171,184,74,153,148,187,251,41,93,51,244,86,108,238,246,89,125,0,161,102,56,198,65,242,44,20,3,55,202,13,126,22,246,104,214,233,25,22,121,109,189,105,107,36,89,11,50,180,50,148,48,208,27,108,128,168,97,116,28,58,139,238,84,12,154,198,84,144,156,87,138,208,50,73,73,145,243,24,149,41,73,105,201,69,22,39,56,129,225,11,131,210,213,70,10,123,221,131,195,65,28,7,33,62,190,64,47,54,47,180,200,117,157,159,10,191,111,240,178,147,120,62,174,14,68,61,79,51,79,101,145,241,60,35,42,102,140,208,36,23,68,112,202,136,148,10,219,162,89,162,82,156,230,29,158,160,80,129,101,183,118,242,105,237,135,233,246,252,209,85,249,11,215,226,119,78,192,209,37,60,101,173,254,179,149,185,252,231,38,123,23,237,190,1,164,246,42,95,79,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9a60810c-41d3-474d-908b-832435849593"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("56642892-05c7-42ae-8a57-ac21482d70bb"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0c54e3ed-b510-44aa-95e8-d5869d6647b7"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3ea11d01-ccd4-45c3-9644-14df37bc5ce0"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fd3d7954-cc74-4986-a523-d221d7761c23"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("92450397-12f0-4f17-a75d-d38567c6327b"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,45,46,78,76,79,181,50,180,50,212,241,76,177,50,176,50,208,9,72,44,74,205,43,1,49,1,78,75,80,76,29,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				UId = new Guid("5a1f2b83-ed26-4c92-8480-206a321e9963"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2e4064fd-64ed-4abc-8260-c6a14fb6a6c5"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fd53a939-0d8c-44b8-9ef1-fc1e8c5694e4"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d146f3f2-4cb7-4239-92bf-c9081aa150f5"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4508d2c7-78c9-422c-977e-5f7441f0ef76"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0cc7df16-22da-417e-b78a-80ea545febad"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("15a46e90-2180-4324-bb5b-dcb14fbe07ee"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				UId = new Guid("720d957d-e275-469f-8956-e925ee0c382a"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d7c50aae-200a-41d3-8177-d3acea16b585"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9702aa85-1629-4ea9-8aa4-2753d1f1692e"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6a3574e7-1c32-41ba-9a16-e9ed315eef65"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f2c99b37-6016-4f45-af48-6e6f1c684e46"),
				ContainerUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeAddCommentNotificationUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("d2f54b5a-bf50-4842-a4f0-4d72ad23d06c"),
				ContainerUId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61"),
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
				Value = @"104d30b1-458a-49b9-8464-aef17d78b411",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7f07f8e3-92dd-4b85-b1a9-b8d1a524e5d5"),
				ContainerUId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9abee62b-56b1-4c28-93ae-c885bfff3a39"),
				ContainerUId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("a806be87-94ba-47b4-9129-331e6d19c0a5"),
				ContainerUId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b8bbeac4-174d-4926-9467-5e78622c517a"),
				ContainerUId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,219,110,219,70,16,253,21,129,201,163,71,216,251,69,143,77,92,192,128,157,26,113,155,23,219,15,179,187,179,137,80,74,52,36,186,133,43,232,223,59,164,37,95,210,192,113,209,166,64,80,243,129,34,87,115,102,103,134,231,236,204,166,121,221,223,92,81,51,107,126,56,61,57,235,106,63,125,211,173,104,122,186,234,50,173,215,211,227,46,99,59,255,3,83,75,167,184,194,5,245,180,250,128,237,53,173,143,231,235,254,96,242,16,212,28,52,175,127,27,255,107,102,231,155,230,168,167,197,47,71,133,61,163,167,104,165,22,32,66,40,96,82,182,128,213,68,192,68,66,162,112,209,68,205,224,220,181,215,139,229,9,245,120,138,253,167,102,182,105,70,111,236,32,177,133,149,57,66,66,198,26,133,2,98,246,18,156,203,218,43,167,148,173,190,217,30,52,235,252,137,22,56,110,122,15,150,194,20,45,146,4,99,3,130,137,41,66,48,206,0,82,149,190,248,144,140,148,3,120,103,127,15,60,127,117,126,180,254,233,247,37,173,206,70,191,179,138,237,154,46,167,188,250,217,194,97,75,11,90,246,179,77,164,26,162,207,4,70,215,10,198,171,2,177,120,11,42,98,176,89,105,146,145,182,12,184,171,229,108,99,81,86,149,130,6,42,202,129,201,81,113,120,65,128,18,14,181,146,20,163,211,3,228,112,217,207,251,155,55,99,141,102,27,74,213,165,20,53,4,68,70,161,144,16,133,40,144,29,161,243,88,43,41,185,189,124,117,57,36,86,230,235,171,22,111,62,252,53,191,247,132,101,146,187,197,16,60,149,201,85,183,238,39,5,123,156,254,56,95,241,227,156,191,224,164,171,147,21,173,175,219,126,190,252,200,182,109,75,185,159,119,75,254,226,203,30,115,127,187,197,213,35,110,60,220,100,115,113,75,176,139,102,118,241,101,138,237,126,111,75,250,152,100,143,249,117,209,28,92,52,103,221,245,42,15,222,52,191,188,125,144,217,184,193,104,242,217,235,158,80,188,178,188,110,219,221,202,91,78,115,111,184,95,238,202,188,206,169,28,45,207,246,60,26,189,136,221,5,95,184,237,175,219,216,254,9,236,4,151,248,145,86,239,56,253,251,216,239,162,252,153,75,184,119,156,84,180,194,203,10,158,48,130,33,199,140,41,18,33,202,152,170,246,90,213,170,70,244,123,170,180,162,101,166,199,129,73,151,72,59,43,33,48,75,192,72,203,130,40,69,0,6,161,139,113,65,151,162,119,248,245,88,237,65,201,187,184,134,82,109,155,237,246,224,161,190,115,96,77,107,195,100,116,53,15,242,52,16,29,5,208,228,139,86,37,96,40,248,164,190,139,119,222,144,102,152,96,97,26,165,60,164,28,18,248,104,109,96,109,12,49,254,251,250,30,213,251,148,64,238,12,94,232,253,31,210,59,138,228,108,170,1,68,29,216,36,13,19,213,251,8,202,40,193,15,88,163,240,79,209,251,217,129,61,151,222,232,170,241,210,17,200,76,76,48,201,39,123,16,158,41,74,70,4,178,69,81,22,79,210,59,24,147,45,75,14,124,45,158,29,100,15,65,150,2,150,73,31,146,23,217,216,250,45,218,215,113,215,253,122,125,53,181,34,231,20,66,0,52,134,187,103,161,4,209,150,193,161,202,145,21,91,98,48,83,37,200,21,210,22,88,111,220,80,188,173,156,95,137,160,157,116,33,56,105,178,115,95,107,39,187,253,14,207,222,77,150,93,207,103,105,198,161,85,76,134,243,127,122,223,102,120,229,134,11,63,182,155,151,246,241,221,181,143,231,208,233,111,233,43,22,227,77,73,5,124,177,124,250,243,28,196,177,104,142,202,26,142,85,186,26,83,120,82,95,36,101,193,100,88,29,130,135,76,35,164,97,238,106,9,94,120,33,178,174,82,214,240,255,26,15,145,4,25,155,17,50,15,206,96,42,121,64,29,11,104,76,94,249,64,210,73,255,109,199,195,163,242,34,237,239,78,218,73,144,15,204,67,86,206,64,155,194,147,97,10,172,239,44,133,50,58,229,226,124,250,154,180,47,183,127,2,191,17,22,152,83,14,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f640e209-6e76-4601-93eb-8e3eda7f8505"),
				ContainerUId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61"),
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
				UId = new Guid("4fedc289-b361-4e10-81bf-a2fcb257fe3d"),
				ContainerUId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61"),
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

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b16c2a23-8fa1-410c-8bf0-9ded1dcbf5b3"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,115,211,48,16,253,43,29,159,171,142,101,203,182,148,27,148,192,244,208,143,33,157,94,72,15,146,188,78,53,216,145,71,82,90,74,38,255,157,149,157,134,148,201,64,224,2,248,98,233,205,219,221,183,95,90,39,186,149,222,95,201,14,146,73,242,246,230,114,102,155,112,246,222,180,1,220,7,103,87,125,114,154,120,112,70,182,230,43,212,35,62,173,77,120,39,131,68,131,245,252,187,253,60,153,204,15,121,152,39,167,243,196,4,232,60,50,208,160,40,211,74,113,90,16,174,242,140,48,174,40,225,130,41,2,92,0,40,40,25,103,108,100,30,118,125,110,187,94,58,24,35,12,206,155,225,120,251,220,71,34,69,64,15,20,227,237,114,11,230,81,130,159,46,165,106,161,198,123,112,43,64,40,56,211,97,38,112,107,58,184,145,14,35,69,63,54,66,72,106,100,235,35,171,133,38,76,191,244,14,188,55,118,249,115,105,237,170,91,238,115,209,28,118,215,173,152,116,80,24,153,55,50,60,12,14,46,80,212,102,208,248,102,177,112,176,144,193,60,238,75,248,12,207,3,239,184,218,161,65,141,253,185,147,237,10,246,98,190,206,227,92,246,97,76,103,12,143,4,103,22,15,71,102,186,171,214,175,146,205,16,236,95,200,71,121,60,168,63,43,17,124,140,192,232,227,229,56,79,62,93,248,235,167,37,184,153,126,128,78,142,21,187,63,67,244,7,96,218,66,7,203,48,89,167,188,97,180,22,130,8,158,115,194,40,151,68,21,149,32,178,162,85,149,85,89,145,150,106,131,6,59,65,147,117,93,165,105,85,104,73,4,164,138,48,86,55,200,70,19,40,16,128,172,225,133,98,155,251,81,184,241,125,43,159,239,118,250,174,224,233,4,231,49,198,62,233,173,15,80,159,125,4,109,93,189,45,122,252,33,45,207,25,175,181,206,8,173,21,170,226,50,35,130,213,26,59,203,53,173,120,33,10,174,113,70,226,23,91,105,23,70,203,246,186,7,135,163,50,180,42,61,60,226,175,118,35,22,209,89,27,198,210,236,90,48,179,26,23,252,18,251,38,23,136,236,205,155,210,148,10,166,43,34,5,109,8,211,165,34,60,19,140,232,84,149,121,46,178,146,210,12,85,225,35,17,27,54,179,43,167,183,139,233,199,215,225,143,246,254,47,236,243,239,44,233,193,53,57,102,240,255,219,161,190,248,231,102,116,147,108,190,1,34,65,119,204,187,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("310495bd-78ef-46e8-bd4f-08a98a050897"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cb3ef4f3-9764-4095-a7f4-5e41a35ac0ac"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("54c3435c-6332-48a2-a3e3-e3146231388c"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("48f7c6e0-02c8-4675-80b8-8367b0ef9190"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d5e71c2a-4e7a-4bbc-8424-96fac9c00de2"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("062d7511-3234-4dc6-98d1-9a2bd134a872"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,45,46,78,76,79,181,50,180,50,212,9,72,44,74,205,43,177,50,176,50,208,113,46,74,77,44,73,77,113,170,4,243,60,83,64,20,0,81,116,18,230,43,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				UId = new Guid("21c4f994-ba78-446e-9942-d68f20139863"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("66e87786-c605-4fec-b02e-830988bb2e7d"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a122acd7-cc81-49fd-8c39-9aab1b9c747c"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("677eaf70-16e1-4664-bae1-944189695e0b"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f8162883-d725-4f4b-b85f-218697d31396"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fc9471e4-6058-424b-acd0-8b0ae601c0c6"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e98494ea-7338-4c9a-b507-c8b3dc9be58f"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				UId = new Guid("e0adb813-1f6d-4072-b83f-eafcb5ba680c"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("49fd90d6-76c8-48f2-8b16-ea83004edbda"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b833533c-49e1-4ebc-ac9f-1a911d02ccc4"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7c3db1aa-d065-4619-9e55-0615dfb22975"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fa088023-44c1-4370-afa4-5c6b45d07773"),
				ContainerUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeOnLikeAddedStartSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e4cf7a08-cf11-4efc-aad9-78919c7c9593"),
				ContainerUId = new Guid("1b77d543-2d8f-468e-ac45-367e57574f2f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("1b77d543-2d8f-468e-ac45-367e57574f2f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
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
				UId = new Guid("f836b77b-679f-4dfa-a647-9a7e89c1ec39"),
				ContainerUId = new Guid("1b77d543-2d8f-468e-ac45-367e57574f2f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("1b77d543-2d8f-468e-ac45-367e57574f2f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeReadDataUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("39c452ee-d582-4fc4-89da-188114ddf6aa"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,111,26,49,16,253,43,104,207,49,90,246,203,44,183,54,37,85,164,182,65,37,202,165,228,48,216,99,176,178,139,87,182,73,75,17,255,189,227,93,160,164,66,45,173,84,85,245,201,126,122,51,243,230,121,102,27,137,10,156,251,0,53,70,163,232,245,228,253,212,40,223,191,209,149,71,251,214,154,117,19,93,69,14,173,134,74,127,69,217,225,99,169,253,27,240,64,1,219,217,247,248,89,52,154,157,203,48,139,174,102,145,246,88,59,98,132,0,5,92,22,92,178,56,43,82,150,21,48,96,192,227,152,205,133,76,50,57,7,224,124,184,103,158,77,125,109,234,6,44,118,21,218,228,170,189,222,111,154,64,28,16,32,90,138,118,102,181,7,211,32,193,141,87,48,175,80,210,219,219,53,18,228,173,174,169,19,188,215,53,78,192,82,165,144,199,4,136,72,10,42,23,88,21,42,63,254,210,88,116,78,155,213,207,165,85,235,122,117,202,165,112,60,62,247,98,226,86,97,96,78,192,47,219,4,183,36,106,215,106,124,181,88,88,92,128,215,207,167,18,158,112,211,242,46,243,142,2,36,253,207,3,84,107,60,169,249,178,143,107,104,124,215,78,87,158,8,86,47,150,23,118,122,116,235,87,205,38,4,54,7,242,69,25,207,234,79,10,2,159,3,208,229,56,92,103,209,167,91,119,247,121,133,118,42,150,88,67,231,216,99,159,208,31,128,113,133,53,174,252,104,59,152,115,46,243,44,101,137,28,42,242,112,136,12,68,150,179,180,224,152,243,156,103,42,81,59,10,56,10,26,109,49,19,138,67,60,100,66,13,6,44,67,37,24,128,44,25,31,150,131,82,112,81,230,101,186,123,236,132,107,215,84,176,121,56,234,187,65,148,189,198,56,223,171,244,19,246,64,74,148,253,143,40,140,149,237,175,135,19,62,199,44,180,128,234,174,65,75,159,223,154,31,159,31,218,23,211,30,108,177,198,248,174,217,163,169,83,35,104,101,223,81,193,86,212,97,124,18,210,27,243,132,211,188,164,57,203,84,25,51,72,36,178,84,168,50,139,147,188,16,188,32,73,180,243,193,255,169,89,91,177,223,51,215,45,251,31,173,241,63,88,207,223,217,185,179,83,127,201,28,255,159,51,186,11,231,175,14,220,46,218,125,3,106,36,148,146,87,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ab5d3b2f-e2fb-4c08-99ff-2f80f260179f"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eb26905a-bd71-46d4-8d6a-d6ed38d0edde"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c33a347d-db7a-4e6a-919d-dcec7662e460"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9e247ae1-2b40-42ab-805b-c5d6096d9ba4"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a73401c-113f-4c6f-861a-7262b910e6cb"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a2463ef1-b5d5-415d-b646-059986b3a408"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,11,45,78,45,178,50,180,50,212,113,46,74,77,44,73,77,241,207,179,50,176,50,208,9,206,79,206,76,204,241,77,45,46,78,76,79,5,139,120,166,128,40,0,3,32,50,156,47,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb"),
				UId = new Guid("d73fb076-b90d-4745-a4b2-fac13c95af7d"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("16d9166d-3ef0-42f4-8408-44ae67b0bbf8"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7375ce45-bc51-437e-87e1-eedd8eff6e54"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fe779b3d-abd3-45e1-aeab-f8081843611c"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("41b06c6a-fc83-481d-8934-d1b75bfe8a0f"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("074acb9f-4b51-4a71-96b0-a688dc1e4df0"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f30a6c29-f244-4a31-9102-fcea5bed4454"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb"),
				UId = new Guid("5556b314-99f0-40b0-8172-959a76296469"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("990df6b1-021b-4232-9284-f92fa22ee682"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("272ed838-6e7e-4ec3-b267-81140797856d"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("daa71dc2-1fb1-4636-bb5a-75c107201ba4"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("489232d2-1dc4-492b-a5a8-1ef8e65ac76c"),
				ContainerUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeAddLikedNotificationUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("da240fb2-c774-4c74-99fd-2e1fdfae3964"),
				ContainerUId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae"),
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
				Value = @"104d30b1-458a-49b9-8464-aef17d78b411",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("17ac42d2-21e6-4d36-ba16-b249f630b24b"),
				ContainerUId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e8734de8-8d7a-4251-a4ab-c545f58d718b"),
				ContainerUId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("644e1f0f-142c-4e1f-8cad-d8d970d36e91"),
				ContainerUId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("56e0b34b-5e15-42e9-b5c8-2bb82ace64b4"),
				ContainerUId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,150,89,111,219,70,16,199,191,10,193,228,209,35,236,125,232,177,142,11,24,176,83,195,78,243,98,251,97,143,217,88,8,77,26,34,213,194,21,244,221,59,164,45,95,77,29,167,23,26,192,124,144,200,229,204,236,236,127,231,199,217,117,253,118,184,190,194,122,94,255,112,116,120,210,149,97,182,219,45,113,118,180,236,18,246,253,236,160,75,161,89,252,22,98,131,71,97,25,46,113,192,229,199,208,172,176,63,88,244,195,78,245,208,169,222,169,223,254,50,189,171,231,167,235,122,127,192,203,159,247,51,69,54,33,24,231,140,6,107,164,7,133,210,130,231,44,67,42,198,103,151,83,40,73,144,115,234,154,213,101,123,136,67,56,10,195,69,61,95,215,83,52,10,144,173,177,228,166,192,51,163,64,9,97,33,38,23,193,122,173,93,116,82,113,237,235,205,78,221,167,11,188,12,211,164,247,206,156,169,44,89,228,160,180,11,160,124,244,224,20,133,9,88,184,205,214,69,197,249,232,124,107,127,239,88,66,211,227,248,38,47,250,171,38,92,127,252,83,131,171,71,210,60,52,89,159,221,232,123,86,207,207,190,172,240,237,255,201,148,250,99,141,31,203,123,86,239,156,213,39,221,106,153,198,104,146,30,222,61,200,107,154,96,50,121,242,184,213,147,70,218,85,211,220,142,188,11,67,216,26,110,135,187,188,40,11,204,251,237,201,86,198,41,10,187,189,224,11,63,219,235,38,183,191,227,118,24,218,240,9,151,239,105,249,247,185,223,101,249,129,36,220,6,246,44,26,29,139,3,86,74,2,197,21,7,103,173,7,161,4,163,155,80,60,179,147,247,49,22,92,98,155,240,47,38,118,140,253,164,246,88,200,183,121,141,82,109,234,205,102,231,97,121,99,20,165,8,193,64,5,42,76,197,153,6,103,152,4,44,197,96,177,5,29,202,103,203,219,41,149,52,74,3,182,228,49,64,178,224,120,206,160,169,232,93,180,44,41,93,254,249,242,62,125,115,208,117,159,87,87,51,205,82,138,206,57,8,74,105,80,25,35,120,157,199,128,34,121,83,82,246,78,205,84,44,89,56,161,33,217,64,12,115,41,33,122,143,192,178,137,50,199,24,148,230,111,206,159,163,229,110,190,189,147,247,85,219,13,84,108,41,12,139,174,173,70,64,102,205,226,51,230,234,154,20,175,174,186,126,184,137,245,10,214,127,8,86,20,94,51,203,11,88,28,183,24,141,0,151,121,160,111,181,143,69,90,57,86,249,115,96,189,164,142,190,9,172,200,2,19,150,150,134,94,17,233,78,36,136,156,35,100,41,21,243,104,85,136,234,89,176,144,243,76,54,132,5,147,132,39,227,10,34,74,14,150,81,212,36,11,231,197,253,27,96,157,238,247,63,253,218,226,242,70,159,249,212,39,206,103,52,250,100,96,175,193,75,108,135,249,218,151,18,117,72,10,82,214,212,224,198,229,250,40,50,160,22,65,99,80,86,101,191,33,135,187,254,48,95,103,43,75,100,214,16,134,212,74,201,66,147,238,81,64,9,137,203,228,117,40,54,143,46,123,237,176,24,174,119,39,141,230,107,151,140,81,140,20,145,212,139,9,99,27,193,249,100,0,109,214,212,166,233,62,203,205,249,215,64,62,198,144,171,225,2,171,17,218,42,83,49,205,126,92,44,251,161,90,208,222,85,93,169,150,216,175,154,97,209,126,170,104,115,26,76,35,230,179,67,106,115,84,138,175,100,127,119,100,71,134,214,37,33,9,28,63,146,173,61,68,71,120,39,206,132,146,49,101,99,227,55,145,237,50,145,228,169,192,125,182,4,88,112,133,2,142,7,196,16,80,4,198,140,23,254,89,178,163,87,94,243,68,121,132,68,25,145,15,248,68,161,140,73,210,10,35,132,46,246,127,65,118,146,146,231,18,51,176,68,170,171,168,51,184,226,105,185,193,24,73,178,22,145,243,19,178,157,20,218,89,238,233,99,96,41,61,77,91,22,5,34,72,90,179,15,50,24,198,229,31,201,198,88,76,140,94,130,163,211,54,73,202,56,157,150,199,67,182,193,96,232,84,84,80,240,23,146,125,211,138,199,46,252,98,182,119,187,118,8,233,181,107,127,127,108,115,67,45,209,104,58,68,83,133,80,71,32,182,93,206,12,130,99,146,40,117,50,103,249,53,182,207,55,191,3,14,45,123,115,71,14,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8010ef15-aad8-4dba-850c-692c850d65b9"),
				ContainerUId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae"),
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
				UId = new Guid("c7010526-a688-4407-922b-f374a9b3244a"),
				ContainerUId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae"),
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

		protected virtual void InitializeReadLikedPostUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bb823b89-4655-4e40-9e5c-0e10daf24deb"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,203,110,219,48,16,252,21,65,231,48,144,37,82,178,124,107,83,183,200,33,77,80,7,185,196,57,172,200,165,76,68,47,80,116,90,215,240,191,119,41,37,174,83,24,173,219,75,11,84,39,106,48,187,156,125,12,183,161,172,160,239,63,66,141,225,44,124,123,115,181,104,181,59,127,111,42,135,246,131,109,215,93,120,22,246,104,13,84,230,43,170,17,159,43,227,222,129,3,10,216,46,191,199,47,195,217,242,88,134,101,120,182,12,141,195,186,39,6,5,160,202,18,4,41,216,52,5,201,120,148,100,12,10,145,177,4,121,154,160,142,197,36,142,71,230,241,212,23,109,221,129,197,241,134,33,185,30,142,183,155,206,19,39,4,200,129,98,250,182,121,6,19,47,161,159,55,80,84,168,232,223,217,53,18,228,172,169,169,18,188,53,53,222,128,165,155,124,158,214,67,68,210,80,245,158,85,161,118,243,47,157,197,190,55,109,243,115,105,213,186,110,14,185,20,142,251,223,103,49,209,160,208,51,111,192,173,134,4,151,36,106,55,104,124,83,150,22,75,112,230,233,80,194,35,110,6,222,105,189,163,0,69,243,185,131,106,141,7,119,190,174,227,2,58,55,150,51,94,79,4,107,202,213,137,149,238,187,245,171,98,99,2,187,23,242,73,25,143,234,143,83,2,159,60,48,230,120,57,46,195,251,203,254,250,115,131,118,33,87,88,195,216,177,135,115,66,127,0,230,21,214,216,184,217,54,215,186,16,32,57,147,74,112,198,115,46,89,94,196,138,161,136,65,32,240,140,171,124,71,1,123,65,179,45,117,93,23,81,150,178,34,143,20,35,134,96,192,139,152,105,144,147,68,230,2,116,166,124,200,188,113,198,109,198,45,152,109,167,50,77,121,196,129,37,89,154,48,62,201,10,54,205,101,202,48,83,34,5,160,179,74,118,15,99,185,166,239,42,216,220,237,171,250,132,160,2,183,194,160,50,143,24,248,110,144,165,108,239,2,111,164,160,213,1,117,121,93,57,211,148,1,173,82,133,210,207,242,252,138,90,15,37,14,41,253,76,41,145,136,166,128,89,174,89,166,39,83,198,147,40,99,57,10,96,41,143,57,143,49,210,177,55,196,206,127,126,69,218,210,72,168,174,59,180,180,130,195,10,68,199,173,243,202,115,126,56,182,109,221,216,242,253,104,23,173,164,135,227,80,212,203,30,171,68,113,206,163,9,227,106,26,51,46,84,206,32,41,4,203,121,145,165,121,166,10,169,167,164,138,30,31,95,250,162,93,91,249,108,248,126,124,117,254,232,61,249,11,239,196,239,152,255,168,253,78,49,212,127,102,150,203,127,110,179,119,225,238,27,199,81,135,143,73,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("df4038dc-6372-4684-8eec-b443a51b08be"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b90f1d0e-459b-4ff2-84b9-84bdd7ae294d"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55f43d53-adf7-49ba-b7fc-3fdfc2fb2ef5"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("be6e2286-7b11-4750-807e-4ce55e79daca"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4e88fd04-f4da-40e3-b8c4-35afe197eb57"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("8e49b308-b01a-4375-803d-4e3f3770a686"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,45,46,78,76,79,181,50,180,50,212,241,76,177,50,176,50,208,9,72,44,74,205,43,1,49,1,78,75,80,76,29,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				UId = new Guid("83258719-cd7a-45a9-b2ee-39499a3a6013"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c164263e-1a79-4940-9a57-e2dccc8fa7a0"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("eec87964-39ad-40af-a379-61083fb27433"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c2061afa-5a06-4890-9015-495796290789"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("56e6c97a-488f-4add-9847-e81524046833"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("8e5240fe-f6fb-4a6b-9ab0-214fcca33c93"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ef6b4042-e216-4b4f-a5ee-db4fe2678424"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				UId = new Guid("8c09f3bd-485d-4bc4-8868-7ed8fdc1494b"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3001471f-45f4-4b10-bb93-e968de3645f2"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e2be980a-5e5d-46f0-b248-73fd2d5c1967"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7eced334-87e9-445d-b4fc-c349d0303875"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4e2a3f16-2ed0-4300-85ef-3daad88e98d6"),
				ContainerUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("985f26f9-02d6-49a5-afcc-1da4c66649df"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,115,211,48,16,253,43,29,159,171,140,109,201,118,156,27,148,192,228,80,218,33,109,47,164,135,149,180,74,53,216,177,71,86,10,37,147,255,206,202,78,66,203,100,32,112,1,124,177,244,230,237,238,219,47,109,34,85,65,215,189,135,26,163,73,244,250,250,114,222,24,63,122,107,43,143,238,157,107,214,109,116,30,117,232,44,84,246,43,234,1,159,106,235,223,128,7,50,216,44,190,219,47,162,201,226,152,135,69,116,190,136,172,199,186,35,6,25,72,201,37,207,75,96,42,73,13,19,60,203,89,89,198,99,198,133,224,220,112,37,120,9,3,243,184,235,139,166,110,193,225,16,161,119,110,250,227,205,83,27,136,9,1,170,167,216,174,89,237,64,30,36,116,211,21,200,10,53,221,189,91,35,65,222,217,154,50,193,27,91,227,53,56,138,20,252,52,1,34,146,129,170,11,172,10,141,159,126,105,29,118,157,109,86,63,151,86,173,235,213,115,46,153,227,225,186,19,19,247,10,3,243,26,252,67,239,96,70,162,182,189,198,87,203,165,195,37,120,251,248,92,194,39,124,234,121,167,213,142,12,52,245,231,14,170,53,62,139,249,50,143,11,104,253,144,206,16,158,8,206,46,31,78,204,244,80,173,95,37,155,18,216,238,201,39,121,60,170,63,205,9,124,12,192,224,99,127,92,68,31,103,221,213,231,21,186,185,122,192,26,134,138,221,143,8,253,1,152,86,88,227,202,79,54,227,172,52,210,24,193,18,173,21,19,73,34,24,72,157,178,12,226,50,45,56,26,147,22,91,50,56,8,154,108,84,156,23,192,75,195,18,28,83,217,69,102,24,164,188,100,40,98,136,149,65,145,136,124,123,63,8,183,93,91,193,211,221,65,223,45,173,207,89,136,76,53,57,3,173,81,143,62,160,106,156,222,21,61,252,136,166,208,140,149,16,138,1,207,53,19,134,231,108,156,165,41,19,5,66,34,177,228,153,84,52,35,225,11,173,108,150,86,65,117,213,162,163,81,233,91,21,31,31,241,23,187,17,138,232,154,198,15,165,57,180,96,222,40,90,240,203,65,99,47,106,63,111,99,94,112,33,77,206,114,94,0,19,40,51,38,11,157,176,52,214,144,96,42,19,169,10,82,69,143,68,104,216,188,89,59,181,91,204,110,120,29,254,104,239,255,194,62,255,206,146,30,93,147,83,6,255,191,29,234,217,63,55,163,219,104,251,13,198,87,201,6,187,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("14407ed4-7b93-4bb0-8947-61bee5163314"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4825dd82-7b93-46dc-930d-b83505b1dfac"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8dbf8aa1-5f3b-4120-a9f7-2ce998b5271d"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("97994f7a-bac7-48f6-b00e-124a48fb410b"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4410d85f-c656-4d35-8868-6b0cf395c87f"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("cd03c654-a7de-4ffc-89fa-6c63a3c8eb4e"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,77,241,207,179,50,176,50,212,9,206,79,206,76,204,241,77,45,46,78,76,79,5,138,24,232,120,166,128,40,0,102,106,230,161,38,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe"),
				UId = new Guid("d92065a7-8e79-43e7-9061-f16b60b4846f"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("152ec142-0c82-4d70-a402-a52fef871f70"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("b2c24b55-7356-45da-b7fa-06d890b61f98"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("1533582a-753c-4ea4-a4b7-fbee9273241e"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4d80d870-a1ef-4838-819a-2b0dfb2ceee5"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("379f0ed1-624c-4682-bc40-71ebf792b7c5"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("264b43ca-f583-4d03-9225-6c4c86add08b"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe"),
				UId = new Guid("5965ef63-7801-4c91-9a41-a15ad70a5605"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("838e5c55-a218-4d7e-8db5-2a2360539a1e"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9af0e793-7b1b-40b6-b726-89e6b53d8b6b"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5bd1a28f-6eb3-4163-9ad0-e598003c1907"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e9dd48c5-c7fe-46e1-b496-5b5dae63c6ee"),
				ContainerUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeOnMentionAddedStartSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c067a39f-1e8f-445f-a239-e40a0cfe4146"),
				ContainerUId = new Guid("859fbff4-1ddc-4114-abd2-5a09273eff27"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("859fbff4-1ddc-4114-abd2-5a09273eff27"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
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
				UId = new Guid("50d03153-866c-49a1-b09f-f3572ef11b73"),
				ContainerUId = new Guid("859fbff4-1ddc-4114-abd2-5a09273eff27"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("859fbff4-1ddc-4114-abd2-5a09273eff27"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"99ab74f3-cdbf-4054-83d8-96c433f423fe",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeReadDataUserTask4Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("242ce24d-3ddd-45ff-9b66-b7ca7b504cbc"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,212,48,16,253,43,171,156,235,202,142,29,39,217,27,148,5,245,80,90,177,85,47,108,15,142,51,78,45,242,37,199,91,88,86,251,223,25,39,237,178,69,43,88,184,128,68,78,206,211,155,241,155,55,51,222,70,186,86,195,240,94,53,16,205,163,215,55,87,203,206,248,243,183,182,246,224,222,185,110,221,71,103,209,0,206,170,218,126,133,114,194,23,165,245,111,148,87,24,176,93,125,143,95,69,243,213,177,12,171,232,108,21,89,15,205,128,12,12,160,44,45,89,154,22,164,204,68,65,4,77,56,201,51,41,9,103,73,201,165,41,100,76,243,137,121,60,245,69,215,244,202,193,116,195,152,220,140,199,219,77,31,136,12,1,61,82,236,208,181,79,32,15,18,134,69,171,138,26,74,252,247,110,13,8,121,103,27,172,4,110,109,3,55,202,225,77,33,79,23,32,36,25,85,15,129,85,131,241,139,47,189,131,97,176,93,251,115,105,245,186,105,15,185,24,14,251,223,39,49,116,84,24,152,55,202,63,140,9,46,81,212,110,212,248,170,170,28,84,202,219,199,67,9,159,96,51,242,78,243,14,3,74,236,207,157,170,215,112,112,231,203,58,46,84,239,167,114,166,235,145,224,108,245,112,98,165,123,183,126,85,108,140,96,255,76,62,41,227,81,253,177,68,240,49,0,83,142,231,227,42,250,120,57,92,127,110,193,45,245,3,52,106,114,236,254,28,209,31,128,69,13,13,180,126,190,149,156,198,204,208,152,128,212,57,17,82,199,36,99,180,32,74,25,33,10,154,165,153,46,118,24,176,23,52,223,150,121,76,101,162,82,146,65,138,33,28,82,146,83,201,136,97,178,144,180,16,153,144,38,132,44,90,111,253,102,154,130,249,86,49,46,36,213,41,145,60,193,102,9,101,72,206,53,16,150,154,184,40,68,201,83,81,238,238,167,114,237,208,215,106,115,183,175,234,3,168,114,22,244,162,147,179,96,6,110,148,27,252,44,236,209,172,51,51,52,121,93,123,219,86,51,156,164,26,116,224,157,95,161,243,170,130,49,99,104,41,230,225,96,178,132,39,130,36,66,11,34,242,88,18,37,100,74,82,195,104,30,51,206,89,156,224,232,133,47,76,72,87,89,173,234,235,30,28,78,224,56,1,244,248,230,188,88,185,208,27,215,117,126,114,124,223,217,101,167,241,221,56,20,181,31,227,34,73,208,64,212,82,160,251,34,147,148,168,12,253,212,73,102,242,88,100,74,3,69,85,248,246,132,210,151,221,218,233,167,125,31,166,71,231,143,158,147,191,240,76,252,206,238,31,221,190,83,246,233,63,219,149,203,127,110,178,119,209,238,27,195,248,119,236,72,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0cd58999-5230-4ef3-a513-99389ff530c0"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("99ae8ad0-6499-4567-8c65-86a56bbea68f"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4c952f0e-dffd-4986-846d-384a7af8a09a"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f8117a6f-4913-432b-b814-eeab6e96632d"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0dca8765-93e1-4123-8811-6ec3651653bf"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("69d9d40d-db8f-43e9-88ae-a3abf24a965a"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,45,46,78,76,79,181,50,180,50,212,9,72,44,74,205,43,177,50,176,50,208,241,76,1,81,0,255,202,163,187,29,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				UId = new Guid("8cc5ccbc-2b9c-463a-9bab-aa349cb77cd2"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1c4950dc-eb9d-4ad4-ab50-8fbb9420594b"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("290fc9b4-9025-4e3f-98b9-1747c5e4346a"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("575e6cd5-8a18-469a-9cd6-55e129df411f"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4ae0aeb5-961a-4027-9a0c-5ac3d4a5ac77"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("68d9c290-aed7-4455-8d6c-9b0597a13528"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("cb390c3d-53e0-4db5-8ba9-d854ceef7d5e"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				UId = new Guid("e177f00d-bbb5-4a71-96a5-6b3bd5c30c02"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7d9a88fc-ab6e-4c1a-b52c-764cccb74f1a"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6ea463a5-4871-446f-af0b-1667f7dedda3"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("48bd0458-36a0-4710-9baf-d55b64ad2ab2"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ad88c443-aa08-4a50-8ab0-0e7f5effc244"),
				ContainerUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeAddMentionNotificationUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("e037ba80-32fe-4970-89b0-011247b9cfca"),
				ContainerUId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162"),
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
				Value = @"104d30b1-458a-49b9-8464-aef17d78b411",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("aa175d01-463f-4eaa-b6dd-6e062b0a9fbe"),
				ContainerUId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("31adc4d6-d5e5-44b1-a41c-9f6561db382d"),
				ContainerUId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("75b974c3-f286-497f-b22e-63339fcad82c"),
				ContainerUId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162"),
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
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4772da4a-5d0b-4678-8701-ff35ab251456"),
				ContainerUId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,150,219,110,219,70,16,134,95,133,96,114,233,21,246,124,208,101,29,23,48,96,167,70,156,230,198,246,197,30,102,98,161,20,105,136,84,11,87,208,187,119,72,75,62,4,169,211,180,77,129,160,230,5,37,46,119,134,179,63,255,143,179,155,250,245,112,123,3,245,188,254,225,236,244,188,195,97,118,216,173,96,118,182,234,50,244,253,236,164,203,177,89,252,30,83,3,103,113,21,151,48,192,234,67,108,214,208,159,44,250,225,160,122,28,84,31,212,175,127,157,238,213,243,139,77,125,60,192,242,231,227,66,153,193,112,239,149,44,204,21,14,76,167,228,152,119,89,50,212,28,147,138,66,103,110,40,56,119,205,122,217,158,194,16,207,226,112,93,207,55,245,148,141,18,20,103,157,6,165,89,224,86,51,45,165,99,41,251,196,92,48,198,39,175,180,48,161,222,30,212,125,190,134,101,156,30,250,16,44,184,46,138,39,193,180,241,145,233,144,2,243,154,210,68,64,225,138,243,73,11,49,6,239,230,63,4,98,108,122,24,239,148,69,127,211,196,219,15,127,58,225,230,137,52,143,167,108,46,239,244,189,172,231,151,159,87,120,247,123,62,149,254,84,227,167,242,94,214,7,151,245,121,183,94,229,49,155,162,139,55,143,234,154,30,48,77,249,228,114,175,39,141,180,235,166,217,141,188,137,67,220,79,220,15,119,101,129,11,40,199,237,249,94,198,41,11,223,29,236,51,167,253,113,87,219,63,9,59,141,109,252,8,171,183,180,252,135,218,239,171,124,79,18,238,19,7,158,172,73,232,25,71,204,76,11,45,200,77,46,48,169,37,167,63,17,3,119,83,244,59,64,88,65,155,225,111,22,246,14,250,73,237,209,200,187,186,70,169,182,245,118,123,240,216,222,46,20,229,48,121,22,181,37,123,67,178,44,102,238,153,176,222,161,66,4,15,226,89,123,123,173,179,1,101,153,195,226,104,69,153,248,16,165,48,67,166,247,201,241,172,13,254,251,246,190,120,117,210,117,191,172,111,102,134,231,156,188,31,235,215,134,233,2,137,5,83,198,132,50,7,139,185,4,175,103,222,196,196,117,226,12,173,36,4,67,210,204,3,173,153,98,13,210,51,184,47,246,213,213,115,180,220,63,239,232,252,109,213,118,3,153,45,199,97,209,181,213,8,200,108,9,237,120,1,165,186,237,214,213,130,70,175,161,90,18,25,100,139,187,196,47,148,253,135,148,37,25,12,119,2,153,131,24,200,212,86,50,95,68,100,65,132,132,202,41,137,40,159,163,236,175,152,234,171,40,147,10,173,195,16,88,1,158,40,77,74,84,16,97,159,145,23,17,10,154,16,244,179,148,129,16,37,38,77,140,112,197,233,36,52,75,160,4,115,220,113,158,21,10,129,254,91,80,118,113,220,255,244,91,11,171,59,125,230,83,211,184,154,209,232,39,3,71,13,140,12,204,55,86,113,41,144,75,6,54,147,244,150,58,165,23,180,230,24,81,19,129,222,249,156,182,20,112,223,44,230,155,18,36,183,38,210,119,3,72,18,173,192,141,173,82,48,20,54,89,158,52,213,138,99,200,17,49,54,220,30,78,26,205,55,81,40,109,57,125,109,172,50,36,169,142,200,130,202,192,132,67,153,18,45,216,233,178,189,250,18,213,239,32,150,106,71,111,85,200,75,179,31,23,171,126,168,22,244,234,170,14,171,21,244,235,102,88,180,31,43,122,55,13,228,113,222,236,244,5,236,239,20,236,196,129,12,40,21,113,19,70,176,77,96,137,58,1,203,130,75,173,82,46,214,165,175,2,187,160,138,228,55,193,8,49,234,231,40,3,11,201,7,106,52,66,112,161,188,212,66,62,11,118,10,58,24,65,168,164,152,169,34,25,57,11,217,9,102,109,86,78,90,41,13,186,255,23,216,188,208,48,186,241,29,185,113,191,108,40,42,70,195,104,123,145,76,176,42,241,168,191,17,216,135,93,59,196,60,188,116,236,239,14,108,114,20,237,65,13,237,166,17,36,237,66,9,108,95,10,103,209,115,69,126,242,170,20,245,37,176,175,182,127,0,230,86,203,198,80,14,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2d9562bc-844a-4dc6-86f8-0bfb638f3379"),
				ContainerUId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162"),
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
				UId = new Guid("90b1d03c-5734-4fac-a35c-c496904ac513"),
				ContainerUId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162"),
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

		protected virtual void InitializeStartSignal1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ab84c217-21ad-45fe-a710-9a563a7cf619"),
				ContainerUId = new Guid("2e85559f-f12a-47bc-ab83-2d0181bfba46"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaESNNotificationsLaneSet = CreateESNNotificationsLaneSetLaneSet();
			LaneSets.Add(schemaESNNotificationsLaneSet);
			ProcessSchemaLane schemaPostCommentLane = CreatePostCommentLaneLane();
			schemaESNNotificationsLaneSet.Lanes.Add(schemaPostCommentLane);
			ProcessSchemaTerminateEvent terminateprocess = CreateTerminateProcessTerminateEvent();
			FlowElements.Add(terminateprocess);
			ProcessSchemaStartSignalEvent onpostcommentedstartsignal = CreateOnPostCommentedStartSignalStartSignalEvent();
			FlowElements.Add(onpostcommentedstartsignal);
			ProcessSchemaUserTask readcommentedpostusertask = CreateReadCommentedPostUserTaskUserTask();
			FlowElements.Add(readcommentedpostusertask);
			ProcessSchemaUserTask addcommentnotificationusertask = CreateAddCommentNotificationUserTaskUserTask();
			FlowElements.Add(addcommentnotificationusertask);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaStartSignalEvent onlikeaddedstartsignal = CreateOnLikeAddedStartSignalStartSignalEvent();
			FlowElements.Add(onlikeaddedstartsignal);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			ProcessSchemaUserTask addlikednotificationusertask = CreateAddLikedNotificationUserTaskUserTask();
			FlowElements.Add(addlikednotificationusertask);
			ProcessSchemaUserTask readlikedpostusertask = CreateReadLikedPostUserTaskUserTask();
			FlowElements.Add(readlikedpostusertask);
			ProcessSchemaScriptTask sendnotificationscripttask = CreateSendNotificationScriptTaskScriptTask();
			FlowElements.Add(sendnotificationscripttask);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaInclusiveGateway inclusivegateway1 = CreateInclusiveGateway1InclusiveGateway();
			FlowElements.Add(inclusivegateway1);
			ProcessSchemaFormulaTask formulatask2 = CreateFormulaTask2FormulaTask();
			FlowElements.Add(formulatask2);
			ProcessSchemaUserTask readdatausertask3 = CreateReadDataUserTask3UserTask();
			FlowElements.Add(readdatausertask3);
			ProcessSchemaStartSignalEvent onmentionaddedstartsignal = CreateOnMentionAddedStartSignalStartSignalEvent();
			FlowElements.Add(onmentionaddedstartsignal);
			ProcessSchemaUserTask readdatausertask4 = CreateReadDataUserTask4UserTask();
			FlowElements.Add(readdatausertask4);
			ProcessSchemaUserTask addmentionnotificationusertask = CreateAddMentionNotificationUserTaskUserTask();
			FlowElements.Add(addmentionnotificationusertask);
			ProcessSchemaFormulaTask formulatask3 = CreateFormulaTask3FormulaTask();
			FlowElements.Add(formulatask3);
			ProcessSchemaStartSignalEvent startsignal1 = CreateStartSignal1StartSignalEvent();
			FlowElements.Add(startsignal1);
			ProcessSchemaFormulaTask formulatask4 = CreateFormulaTask4FormulaTask();
			FlowElements.Add(formulatask4);
			FlowElements.Add(CreateCommentAddedSequenceFlowSequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateLikeAddedSequenceFlowSequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateMentionAddedSequenceFlowSequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow15SequenceFlow());
			FlowElements.Add(CreateSequenceFlow16SequenceFlow());
			FlowElements.Add(CreateSequenceFlow17SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateCommentAddedSequenceFlowSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "CommentAddedSequenceFlow",
				UId = new Guid("0156db7a-f82d-4ed9-a5ef-8530400fce08"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(168, 316),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("08f41d99-9838-418a-b579-a7177272506b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("b43be58a-f5cb-4c05-9b13-4b8c5b8464c3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(350, 314),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateLikeAddedSequenceFlowSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "LikeAddedSequenceFlow",
				UId = new Guid("32aa6322-db45-4d67-9c50-41a911ad85c5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(192, 274),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1b77d543-2d8f-468e-ac45-367e57574f2f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("bfdef988-ecab-417f-91d7-9a0b65d48de3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(476, 272),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("125e3237-d312-47eb-a932-945ac6d5edda"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(782, 216),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c6a307e4-94ad-4577-b6c1-23185045e859"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("7850594b-b39d-4a6f-abe8-17e96c27fc2b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(825, 242),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(1024, 226),
				SequenceFlowStartPointPosition = new Point(940, 226),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("32d0ae3e-a939-4d47-95b8-8a0fefbe6a8c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b31e7b6c-362c-41a5-9e34-85da4aeff8e1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("c62d023f-d7a2-438c-8edc-ec8862fe1137"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(298, 184),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("ad6782a6-6114-4142-b433-ce08d7b4364a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(294, 388),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow13",
				UId = new Guid("3644824f-fc0f-4f3a-9911-ec3d6c880567"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(803, 301),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8b08f239-cebb-480e-aa3e-b2513abac21b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("32d0ae3e-a939-4d47-95b8-8a0fefbe6a8c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("d965760d-4fd1-46a1-b3fb-ba8ccfd6f025"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(737, 262),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c6a307e4-94ad-4577-b6c1-23185045e859"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8b08f239-cebb-480e-aa3e-b2513abac21b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("35a7daa0-7cf9-4d50-b40b-d99484b2a4fa"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(656, 234),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("109b1c48-4f13-4d85-b81a-a9a72ece3004"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("7fb09131-0ba8-4de8-9bfb-5a01072bee92"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(788, 194),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("109b1c48-4f13-4d85-b81a-a9a72ece3004"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8b08f239-cebb-480e-aa3e-b2513abac21b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateMentionAddedSequenceFlowSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "MentionAddedSequenceFlow",
				UId = new Guid("57280d6b-6f93-4766-bcb4-4b19793e96b2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(216, 363),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("859fbff4-1ddc-4114-abd2-5a09273eff27"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("bb7c2e57-a962-4bca-b5d6-73ab487208a6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(368, 363),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow15SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow15",
				UId = new Guid("5f1ffd43-e907-4974-9701-526673cc6cdc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(527, 365),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow16SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow16",
				UId = new Guid("633c7a4b-8103-4372-9ed1-991ca224e83d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(674, 364),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c23bd082-a1cf-453c-b6ea-7067d9f9c0dc"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow17SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow17",
				UId = new Guid("a0334895-3f8d-43e7-846a-72782b717b40"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(781, 254),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c23bd082-a1cf-453c-b6ea-7067d9f9c0dc"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8b08f239-cebb-480e-aa3e-b2513abac21b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("e21c3341-b60d-4cf8-9369-00f996cb958c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(659, 535),
				SequenceFlowStartPointPosition = new Point(142, 535),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2e85559f-f12a-47bc-ab83-2d0181bfba46"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dc6f485e-b8a2-4027-84e9-46cb310090d1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("67a3da84-74e1-4051-9a38-2559e2217ade"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				SequenceFlowEndPointPosition = new Point(813, 253),
				SequenceFlowStartPointPosition = new Point(728, 535),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dc6f485e-b8a2-4027-84e9-46cb310090d1"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8b08f239-cebb-480e-aa3e-b2513abac21b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(813, 535));
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateESNNotificationsLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaESNNotificationsLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("bbb40bf8-7fa3-4cea-89cf-ea95f81755d8"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"ESNNotificationsLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaESNNotificationsLaneSet;
		}

		protected virtual ProcessSchemaLane CreatePostCommentLaneLane() {
			ProcessSchemaLane schemaPostCommentLane = new ProcessSchemaLane(this) {
				UId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("bbb40bf8-7fa3-4cea-89cf-ea95f81755d8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"PostCommentLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaPostCommentLane;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("b31e7b6c-362c-41a5-9e34-85da4aeff8e1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"TerminateProcess",
				Position = new Point(1024, 212),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateOnPostCommentedStartSignalStartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("08f41d99-9838-418a-b579-a7177272506b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				EntitySignal = EntityChangeType.Inserted,
				HasEntityColumnChange = false,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"OnPostCommentedStartSignal",
				NewEntityChangedColumns = false,
				Position = new Point(113, 51),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			InitializeOnPostCommentedStartSignalParameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadCommentedPostUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"ReadCommentedPostUserTask",
				Position = new Point(358, 37),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadCommentedPostUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddCommentNotificationUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"AddCommentNotificationUserTask",
				Position = new Point(512, 37),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddCommentNotificationUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"ReadDataUserTask1",
				Position = new Point(204, 37),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateOnLikeAddedStartSignalStartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("1b77d543-2d8f-468e-ac45-367e57574f2f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb"),
				EntitySignal = EntityChangeType.Inserted,
				HasEntityColumnChange = false,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"OnLikeAddedStartSignal",
				NewEntityChangedColumns = false,
				Position = new Point(113, 212),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			InitializeOnLikeAddedStartSignalParameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"ReadDataUserTask2",
				Position = new Point(204, 198),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddLikedNotificationUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"AddLikedNotificationUserTask",
				Position = new Point(512, 198),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddLikedNotificationUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadLikedPostUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"ReadLikedPostUserTask",
				Position = new Point(358, 198),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadLikedPostUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSendNotificationScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("32d0ae3e-a939-4d47-95b8-8a0fefbe6a8c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"SendNotificationScriptTask",
				Position = new Point(871, 198),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,89,109,111,219,54,16,254,236,2,253,15,154,63,201,128,33,164,47,251,210,213,25,18,55,233,188,45,105,22,199,25,176,166,40,88,139,78,56,232,197,149,168,100,154,225,255,190,59,146,146,72,138,86,228,4,24,80,212,53,239,253,185,227,221,209,189,39,153,87,228,52,155,166,73,66,151,156,165,137,55,241,22,198,193,79,47,95,220,3,23,205,191,3,41,161,15,222,73,194,25,47,231,203,59,26,147,63,10,154,149,190,169,33,208,25,206,72,66,110,105,54,246,134,39,243,243,243,148,179,21,91,18,228,26,142,64,49,40,13,46,50,22,147,172,20,154,166,105,84,196,73,48,203,143,162,7,82,230,115,26,129,74,48,203,179,130,42,63,150,25,37,156,134,159,18,201,11,68,84,114,20,134,242,187,63,156,86,12,194,2,138,228,233,146,145,232,140,230,57,184,50,11,119,9,206,117,182,96,22,186,229,175,232,63,188,159,6,245,233,86,35,49,234,235,76,197,221,165,75,226,189,216,79,101,45,228,214,124,65,50,154,240,190,42,37,247,78,228,36,121,191,192,149,202,238,248,117,197,123,162,96,232,111,131,193,203,117,71,193,92,1,53,176,184,143,196,21,232,148,144,44,134,212,57,137,105,167,12,50,152,94,45,211,228,49,207,128,165,150,81,215,230,184,3,121,117,113,142,75,61,166,90,174,203,197,70,210,240,179,150,189,184,75,121,218,199,176,96,172,229,211,135,132,102,187,197,62,33,185,102,78,180,222,114,202,34,78,51,37,33,181,203,163,63,25,191,131,148,131,147,240,37,247,229,225,52,141,215,36,99,121,154,8,216,78,190,23,36,130,126,5,32,140,61,189,99,205,194,90,180,234,93,82,65,142,94,249,109,7,92,174,229,202,171,143,84,21,44,68,131,77,14,72,86,27,69,105,182,242,12,189,121,48,77,139,4,58,226,196,59,24,121,155,151,47,6,25,229,69,150,120,43,18,229,216,33,183,109,139,216,181,117,21,159,15,190,216,173,212,98,65,231,16,10,133,244,53,137,10,250,254,3,176,94,177,152,30,250,86,7,22,57,175,156,173,105,193,111,44,9,209,207,74,14,191,7,191,167,75,18,73,199,117,227,21,79,48,95,211,37,91,149,200,219,168,26,155,58,22,73,46,184,24,13,71,50,226,156,103,44,185,109,194,153,203,239,141,94,248,36,34,10,145,224,57,205,160,3,176,127,169,110,2,217,254,74,19,58,75,86,105,176,224,75,87,238,102,161,13,148,154,93,26,78,238,145,211,7,224,143,5,11,15,125,231,172,170,33,118,78,163,62,202,37,68,150,250,102,148,237,54,80,117,222,39,70,96,118,251,199,204,212,13,248,89,214,172,17,176,219,104,53,221,158,104,205,28,142,143,153,121,38,144,174,225,217,207,228,115,65,237,152,174,134,3,114,86,246,55,162,207,214,150,34,57,35,247,169,108,123,248,182,125,19,19,179,191,127,98,136,126,149,82,173,97,189,175,103,205,244,52,252,210,166,114,127,199,90,163,220,173,114,95,55,29,147,222,173,88,77,243,61,144,172,7,252,87,37,107,143,248,61,116,137,169,175,105,128,97,58,47,243,163,48,102,201,34,97,252,121,111,20,93,211,112,132,99,10,222,66,226,228,146,221,222,113,28,222,98,210,194,216,81,230,153,177,158,232,242,218,170,98,83,46,211,148,75,211,24,169,49,68,16,113,127,164,246,11,67,72,223,53,44,26,248,249,228,53,7,48,225,100,201,97,215,81,185,24,213,200,34,68,140,170,141,197,240,165,255,246,82,41,233,185,184,228,102,42,43,233,102,103,209,25,68,221,232,7,29,117,83,229,201,216,86,204,135,46,74,207,242,83,128,177,200,96,148,144,111,17,13,253,161,190,1,94,191,30,142,164,247,40,109,187,50,177,94,210,193,180,200,176,117,162,21,199,166,32,21,153,56,12,224,4,144,24,88,111,101,28,212,167,105,22,195,78,203,155,127,78,188,105,68,242,252,20,178,151,102,37,122,255,126,167,220,161,143,182,240,102,128,127,112,227,11,148,57,202,110,139,24,28,244,135,166,227,80,11,86,50,17,176,1,2,41,51,98,204,20,231,76,132,39,252,73,188,230,165,63,66,187,63,119,14,123,228,120,215,99,126,89,62,60,203,248,163,86,165,57,181,89,234,65,171,182,106,2,132,202,92,45,69,156,159,194,214,58,3,208,73,178,164,199,37,4,34,47,69,19,216,72,20,37,218,51,158,27,176,137,154,235,39,30,200,246,214,226,19,165,52,139,171,101,211,238,213,99,36,159,180,163,104,69,38,24,47,41,84,117,136,27,113,163,10,118,100,36,237,218,104,13,19,130,90,37,73,156,127,204,210,98,173,108,182,126,8,18,28,86,15,55,239,150,224,56,78,195,18,127,10,170,107,26,43,30,15,125,68,228,3,19,137,128,43,166,6,26,244,179,111,127,67,118,14,37,54,131,141,246,195,208,88,123,250,108,199,38,89,206,191,134,69,13,210,154,77,189,222,199,250,154,82,19,171,159,124,198,142,45,93,50,109,71,226,227,138,241,136,182,162,17,167,125,195,193,70,167,92,173,183,146,173,52,129,93,4,203,201,126,192,204,105,18,186,27,199,236,188,197,182,111,203,88,56,90,70,219,56,188,190,224,109,135,90,63,127,241,54,118,121,111,197,139,206,163,208,11,69,156,230,203,238,184,172,95,118,146,16,32,116,4,156,217,108,110,134,247,216,84,111,134,239,110,134,155,131,237,13,56,116,51,12,89,190,142,72,121,221,80,94,41,202,90,182,99,113,99,52,242,107,32,111,183,178,34,181,53,203,42,134,113,235,126,137,96,149,179,142,150,210,229,54,11,77,159,171,123,99,250,107,117,140,182,183,206,70,56,238,234,111,29,196,166,51,237,138,11,43,250,87,88,37,32,166,115,250,192,161,64,210,21,15,240,68,252,5,117,112,79,51,30,92,165,50,244,246,187,179,33,141,118,26,217,1,27,134,235,132,78,171,128,87,238,10,0,200,218,24,191,233,194,248,109,85,48,2,30,84,241,227,214,137,121,11,208,214,65,133,153,117,188,35,31,86,38,156,217,146,0,233,248,97,39,248,63,47,137,124,196,233,205,80,254,91,62,155,70,85,19,154,179,120,29,81,229,187,154,97,198,153,47,88,141,163,64,53,252,158,201,175,59,186,25,67,125,83,155,236,27,64,226,241,27,113,140,110,227,183,183,117,126,119,252,248,167,77,15,9,181,214,15,170,3,71,29,75,96,180,148,153,209,182,150,217,153,216,64,76,166,95,40,169,122,168,232,227,173,89,138,34,103,249,237,244,142,64,35,142,212,22,226,197,234,115,226,181,104,65,181,153,160,228,172,33,123,75,245,57,169,164,229,30,195,105,44,119,24,211,85,17,16,91,249,149,212,15,144,227,34,82,63,245,13,212,105,112,145,230,188,74,184,17,152,16,135,225,5,127,212,62,44,254,199,231,63,221,184,202,208,158,26,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("c6a307e4-94ad-4577-b6c1-23185045e859"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"FormulaTask1",
				Position = new Point(659, 37),
				ResultParameterMetaPath = @"f0a3cf6a-71c5-4eef-add2-9dfe3c7b24a4",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,173,14,131,48,20,6,208,135,65,223,229,246,23,168,159,152,218,146,73,82,113,91,190,102,130,34,10,201,4,225,221,135,158,61,201,153,186,233,177,61,191,43,218,59,127,80,37,20,89,54,196,219,165,127,112,95,80,177,238,225,96,73,26,37,9,101,167,13,89,54,160,52,107,71,106,224,34,179,22,157,189,58,175,240,146,38,21,59,90,56,138,183,12,205,35,121,244,158,172,103,69,163,65,162,1,6,179,244,101,112,236,206,216,197,31,234,102,75,234,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaInclusiveGateway CreateInclusiveGateway1InclusiveGateway() {
			ProcessSchemaInclusiveGateway gateway = new ProcessSchemaInclusiveGateway(this) {
				UId = new Guid("8b08f239-cebb-480e-aa3e-b2513abac21b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("ffa4a06a-5747-49d4-96c2-c32a727a3b14"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"InclusiveGateway1",
				Position = new Point(785, 198),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask2FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("109b1c48-4f13-4d85-b81a-a9a72ece3004"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"FormulaTask2",
				Position = new Point(659, 198),
				ResultParameterMetaPath = @"f0a3cf6a-71c5-4eef-add2-9dfe3c7b24a4",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,177,10,195,32,16,128,225,135,201,124,69,79,79,212,189,67,167,22,58,6,135,83,47,116,136,25,76,160,67,200,187,215,185,219,207,7,255,60,205,143,253,249,221,164,191,203,71,26,199,133,215,93,210,109,232,31,220,87,105,178,29,241,20,131,193,6,116,32,170,32,216,234,12,120,36,11,89,107,85,13,57,44,44,215,24,94,220,185,201,33,61,158,94,105,37,139,38,96,174,126,44,153,193,147,42,224,2,150,17,213,81,14,87,154,210,15,163,88,133,182,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask3UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"ReadDataUserTask3",
				Position = new Point(204, 352),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask3Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateOnMentionAddedStartSignalStartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("859fbff4-1ddc-4114-abd2-5a09273eff27"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe"),
				EntitySignal = EntityChangeType.Inserted,
				HasEntityColumnChange = false,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"OnMentionAddedStartSignal",
				NewEntityChangedColumns = false,
				Position = new Point(113, 366),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			InitializeOnMentionAddedStartSignalParameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask4UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"ReadDataUserTask4",
				Position = new Point(358, 352),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask4Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddMentionNotificationUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"AddMentionNotificationUserTask",
				Position = new Point(512, 352),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddMentionNotificationUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask3FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("c23bd082-a1cf-453c-b6ea-7067d9f9c0dc"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"FormulaTask3",
				Position = new Point(659, 352),
				ResultParameterMetaPath = @"f0a3cf6a-71c5-4eef-add2-9dfe3c7b24a4",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,59,14,131,48,12,0,208,195,48,187,34,159,218,33,123,7,166,86,234,136,50,56,137,173,14,192,16,144,58,32,238,94,230,174,79,122,83,55,141,219,243,187,74,123,151,143,44,28,149,231,77,210,237,210,63,120,204,178,200,186,199,195,80,230,64,189,135,234,4,193,27,69,96,205,12,72,72,100,43,7,131,246,188,194,139,27,47,178,75,139,135,173,195,29,109,46,16,188,103,240,181,32,4,212,0,125,214,140,46,168,115,52,156,169,75,63,109,26,49,214,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal1StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("2e85559f-f12a-47bc-ab83-2d0181bfba46"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				EntitySchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411"),
				EntitySignal = EntityChangeType.Inserted,
				HasEntityColumnChange = false,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"StartSignal1",
				NewEntityChangedColumns = false,
				Position = new Point(111, 519),
				SerializeToDB = false,
				Size = new Size(31, 31),
				UseBackgroundMode = true,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			InitializeStartSignal1Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask4FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("dc6f485e-b8a2-4027-84e9-46cb310090d1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509"),
				CreatedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"),
				Name = @"FormulaTask4",
				Position = new Point(659, 507),
				ResultParameterMetaPath = @"f0a3cf6a-71c5-4eef-add2-9dfe3c7b24a4",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,187,14,131,48,12,64,209,143,97,118,133,67,222,123,135,78,173,212,17,101,112,130,173,14,132,33,32,117,64,252,123,51,119,61,87,119,30,230,199,254,252,110,220,222,229,195,149,162,208,186,115,186,117,253,131,251,202,149,183,35,158,138,189,49,38,8,8,42,2,237,114,1,202,126,2,181,140,232,49,75,38,109,175,62,188,168,81,229,131,91,60,123,215,69,161,3,133,180,128,54,194,64,14,71,8,100,236,68,174,136,197,112,165,33,253,0,44,207,211,152,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ed792714-f7cc-4d65-861b-bf1701dd5157"),
				Name = "BPMSoft.Messaging.Common",
				Alias = "",
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("09668c8e-1e00-4d2a-a040-35cd7a7045d1"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("15acea73-0568-4254-95cc-9ac7e24aed39")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("257f42e9-08c7-402e-8ccc-800826314b17"),
				Name = "Newtonsoft.Json",
				Alias = "",
				CreatedInPackageId = new Guid("982aa7db-afb3-478f-ad21-ce96e46fb25b")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("22aaf901-be11-4228-b8c4-b254129c86d7"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ESNNotificationProcess(userConnection);
		}

		public override object Clone() {
			return new ESNNotificationProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3"));
		}

		#endregion

	}

	#endregion

	#region Class: ESNNotificationProcess

	/// <exclude/>
	public class ESNNotificationProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessPostCommentLane

		/// <exclude/>
		public class ProcessPostCommentLane : ProcessLane
		{

			public ProcessPostCommentLane(UserConnection userConnection, ESNNotificationProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ReadCommentedPostUserTaskFlowElement

		/// <exclude/>
		public class ReadCommentedPostUserTaskFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadCommentedPostUserTaskFlowElement(UserConnection userConnection, ESNNotificationProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadCommentedPostUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("9ef897ce-43ff-472d-9d75-29a85c23e19e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,75,111,212,48,16,254,43,171,156,235,42,15,219,73,246,6,101,65,61,148,86,108,213,11,219,131,99,143,83,11,231,33,199,91,88,86,251,223,25,39,237,178,69,43,88,184,128,68,78,241,167,111,102,190,121,110,35,105,197,48,188,23,13,68,243,232,245,205,213,178,211,254,252,173,177,30,220,59,215,173,251,232,44,26,192,25,97,205,87,80,19,190,80,198,191,17,94,160,193,118,245,221,126,21,205,87,199,60,172,162,179,85,100,60,52,3,50,208,128,177,44,43,88,174,8,75,41,37,84,8,73,42,149,115,194,85,201,121,34,181,172,146,124,98,30,119,125,209,53,189,112,48,69,24,157,235,241,247,118,211,7,98,130,128,28,41,102,232,218,39,48,11,18,134,69,43,42,11,10,223,222,173,1,33,239,76,131,153,192,173,105,224,70,56,140,20,252,116,1,66,146,22,118,8,44,11,218,47,190,244,14,134,193,116,237,207,165,217,117,211,30,114,209,28,246,207,39,49,241,168,48,48,111,132,127,24,29,92,162,168,221,168,241,85,93,59,168,133,55,143,135,18,62,193,102,228,157,86,59,52,80,216,159,59,97,215,112,16,243,101,30,23,162,247,83,58,83,120,36,56,83,63,156,152,233,190,90,191,74,54,69,176,127,38,159,228,241,168,254,148,35,248,24,128,201,199,243,239,42,250,120,57,92,127,110,193,45,229,3,52,98,170,216,253,57,162,63,0,11,11,13,180,126,190,213,156,38,66,82,73,88,85,100,88,195,84,144,42,41,10,34,160,140,139,42,102,25,139,245,14,13,246,130,230,219,52,145,84,151,37,37,149,200,11,66,41,7,130,175,148,40,94,232,52,78,178,178,224,89,48,89,180,222,248,205,52,5,243,173,130,148,198,188,224,36,171,116,74,104,206,74,82,113,45,73,1,5,43,171,184,74,153,148,187,251,41,93,51,244,86,108,238,246,89,125,0,161,102,56,198,65,242,44,20,3,55,202,13,126,22,246,104,214,233,25,22,121,109,189,105,107,36,89,11,50,180,50,148,48,208,27,108,128,168,97,116,28,58,139,238,84,12,154,198,84,144,156,87,138,208,50,73,73,145,243,24,149,41,73,105,201,69,22,39,56,129,225,11,131,210,213,70,10,123,221,131,195,65,28,7,33,62,190,64,47,54,47,180,200,117,157,159,10,191,111,240,178,147,120,62,174,14,68,61,79,51,79,101,145,241,60,35,42,102,140,208,36,23,68,112,202,136,148,10,219,162,89,162,82,156,230,29,158,160,80,129,101,183,118,242,105,237,135,233,246,252,209,85,249,11,215,226,119,78,192,209,37,60,101,173,254,179,149,185,252,231,38,123,23,237,190,1,164,246,42,95,79,7,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,45,46,78,76,79,181,50,180,50,212,241,76,177,50,176,50,208,9,72,44,74,205,43,1,49,1,78,75,80,76,29,0,0,0 })));
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
								new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"));
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

		#region Class: AddCommentNotificationUserTaskFlowElement

		/// <exclude/>
		public class AddCommentNotificationUserTaskFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddCommentNotificationUserTaskFlowElement(UserConnection userConnection, ESNNotificationProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddCommentNotificationUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("0ab2efba-c523-403e-bd25-180fad2a2c61");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Owner = () => (Guid)(((process.ReadCommentedPostUserTask.ResultEntity.IsColumnValueLoaded(process.ReadCommentedPostUserTask.ResultEntity.Schema.Columns.GetByName("CreatedBy").ColumnValueName) ? process.ReadCommentedPostUserTask.ResultEntity.GetTypedColumnValue<Guid>("CreatedById") : Guid.Empty)));
				_recordDefValues_IsRead = () => (bool)(false);
				_recordDefValues_Type = () => (Guid)(new Guid("20e6de35-8b86-475f-bed9-361688614c66"));
				_recordDefValues_SocialMessage = () => (Guid)(((process.ReadCommentedPostUserTask.ResultEntity.IsColumnValueLoaded(process.ReadCommentedPostUserTask.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadCommentedPostUserTask.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Owner", () => _recordDefValues_Owner.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_IsRead", () => _recordDefValues_IsRead.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Type", () => _recordDefValues_Type.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_SocialMessage", () => _recordDefValues_SocialMessage.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Owner;
			internal Func<bool> _recordDefValues_IsRead;
			internal Func<Guid> _recordDefValues_Type;
			internal Func<Guid> _recordDefValues_SocialMessage;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,219,110,219,70,16,253,21,129,201,163,71,216,251,69,143,77,92,192,128,157,26,113,155,23,219,15,179,187,179,137,80,74,52,36,186,133,43,232,223,59,164,37,95,210,192,113,209,166,64,80,243,129,34,87,115,102,103,134,231,236,204,166,121,221,223,92,81,51,107,126,56,61,57,235,106,63,125,211,173,104,122,186,234,50,173,215,211,227,46,99,59,255,3,83,75,167,184,194,5,245,180,250,128,237,53,173,143,231,235,254,96,242,16,212,28,52,175,127,27,255,107,102,231,155,230,168,167,197,47,71,133,61,163,167,104,165,22,32,66,40,96,82,182,128,213,68,192,68,66,162,112,209,68,205,224,220,181,215,139,229,9,245,120,138,253,167,102,182,105,70,111,236,32,177,133,149,57,66,66,198,26,133,2,98,246,18,156,203,218,43,167,148,173,190,217,30,52,235,252,137,22,56,110,122,15,150,194,20,45,146,4,99,3,130,137,41,66,48,206,0,82,149,190,248,144,140,148,3,120,103,127,15,60,127,117,126,180,254,233,247,37,173,206,70,191,179,138,237,154,46,167,188,250,217,194,97,75,11,90,246,179,77,164,26,162,207,4,70,215,10,198,171,2,177,120,11,42,98,176,89,105,146,145,182,12,184,171,229,108,99,81,86,149,130,6,42,202,129,201,81,113,120,65,128,18,14,181,146,20,163,211,3,228,112,217,207,251,155,55,99,141,102,27,74,213,165,20,53,4,68,70,161,144,16,133,40,144,29,161,243,88,43,41,185,189,124,117,57,36,86,230,235,171,22,111,62,252,53,191,247,132,101,146,187,197,16,60,149,201,85,183,238,39,5,123,156,254,56,95,241,227,156,191,224,164,171,147,21,173,175,219,126,190,252,200,182,109,75,185,159,119,75,254,226,203,30,115,127,187,197,213,35,110,60,220,100,115,113,75,176,139,102,118,241,101,138,237,126,111,75,250,152,100,143,249,117,209,28,92,52,103,221,245,42,15,222,52,191,188,125,144,217,184,193,104,242,217,235,158,80,188,178,188,110,219,221,202,91,78,115,111,184,95,238,202,188,206,169,28,45,207,246,60,26,189,136,221,5,95,184,237,175,219,216,254,9,236,4,151,248,145,86,239,56,253,251,216,239,162,252,153,75,184,119,156,84,180,194,203,10,158,48,130,33,199,140,41,18,33,202,152,170,246,90,213,170,70,244,123,170,180,162,101,166,199,129,73,151,72,59,43,33,48,75,192,72,203,130,40,69,0,6,161,139,113,65,151,162,119,248,245,88,237,65,201,187,184,134,82,109,155,237,246,224,161,190,115,96,77,107,195,100,116,53,15,242,52,16,29,5,208,228,139,86,37,96,40,248,164,190,139,119,222,144,102,152,96,97,26,165,60,164,28,18,248,104,109,96,109,12,49,254,251,250,30,213,251,148,64,238,12,94,232,253,31,210,59,138,228,108,170,1,68,29,216,36,13,19,213,251,8,202,40,193,15,88,163,240,79,209,251,217,129,61,151,222,232,170,241,210,17,200,76,76,48,201,39,123,16,158,41,74,70,4,178,69,81,22,79,210,59,24,147,45,75,14,124,45,158,29,100,15,65,150,2,150,73,31,146,23,217,216,250,45,218,215,113,215,253,122,125,53,181,34,231,20,66,0,52,134,187,103,161,4,209,150,193,161,202,145,21,91,98,48,83,37,200,21,210,22,88,111,220,80,188,173,156,95,137,160,157,116,33,56,105,178,115,95,107,39,187,253,14,207,222,77,150,93,207,103,105,198,161,85,76,134,243,127,122,223,102,120,229,134,11,63,182,155,151,246,241,221,181,143,231,208,233,111,233,43,22,227,77,73,5,124,177,124,250,243,28,196,177,104,142,202,26,142,85,186,26,83,120,82,95,36,101,193,100,88,29,130,135,76,35,164,97,238,106,9,94,120,33,178,174,82,214,240,255,26,15,145,4,25,155,17,50,15,206,96,42,121,64,29,11,104,76,94,249,64,210,73,255,109,199,195,163,242,34,237,239,78,218,73,144,15,204,67,86,206,64,155,194,147,97,10,172,239,44,133,50,58,229,226,124,250,154,180,47,183,127,2,191,17,22,152,83,14,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "5ca46f1711e94116b7e56dc129a6bce3",
							"BaseElements.AddCommentNotificationUserTask.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509");
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

		#region Class: ReadDataUserTask1FlowElement

		/// <exclude/>
		public class ReadDataUserTask1FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask1FlowElement(UserConnection userConnection, ESNNotificationProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("f641ac4c-5b83-4a2a-b188-ae908b05350f");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,115,211,48,16,253,43,29,159,171,142,101,203,182,148,27,148,192,244,208,143,33,157,94,72,15,146,188,78,53,216,145,71,82,90,74,38,255,157,149,157,134,148,201,64,224,2,248,98,233,205,219,221,183,95,90,39,186,149,222,95,201,14,146,73,242,246,230,114,102,155,112,246,222,180,1,220,7,103,87,125,114,154,120,112,70,182,230,43,212,35,62,173,77,120,39,131,68,131,245,252,187,253,60,153,204,15,121,152,39,167,243,196,4,232,60,50,208,160,40,211,74,113,90,16,174,242,140,48,174,40,225,130,41,2,92,0,40,40,25,103,108,100,30,118,125,110,187,94,58,24,35,12,206,155,225,120,251,220,71,34,69,64,15,20,227,237,114,11,230,81,130,159,46,165,106,161,198,123,112,43,64,40,56,211,97,38,112,107,58,184,145,14,35,69,63,54,66,72,106,100,235,35,171,133,38,76,191,244,14,188,55,118,249,115,105,237,170,91,238,115,209,28,118,215,173,152,116,80,24,153,55,50,60,12,14,46,80,212,102,208,248,102,177,112,176,144,193,60,238,75,248,12,207,3,239,184,218,161,65,141,253,185,147,237,10,246,98,190,206,227,92,246,97,76,103,12,143,4,103,22,15,71,102,186,171,214,175,146,205,16,236,95,200,71,121,60,168,63,43,17,124,140,192,232,227,229,56,79,62,93,248,235,167,37,184,153,126,128,78,142,21,187,63,67,244,7,96,218,66,7,203,48,89,167,188,97,180,22,130,8,158,115,194,40,151,68,21,149,32,178,162,85,149,85,89,145,150,106,131,6,59,65,147,117,93,165,105,85,104,73,4,164,138,48,86,55,200,70,19,40,16,128,172,225,133,98,155,251,81,184,241,125,43,159,239,118,250,174,224,233,4,231,49,198,62,233,173,15,80,159,125,4,109,93,189,45,122,252,33,45,207,25,175,181,206,8,173,21,170,226,50,35,130,213,26,59,203,53,173,120,33,10,174,113,70,226,23,91,105,23,70,203,246,186,7,135,163,50,180,42,61,60,226,175,118,35,22,209,89,27,198,210,236,90,48,179,26,23,252,18,251,38,23,136,236,205,155,210,148,10,166,43,34,5,109,8,211,165,34,60,19,140,232,84,149,121,46,178,146,210,12,85,225,35,17,27,54,179,43,167,183,139,233,199,215,225,143,246,254,47,236,243,239,44,233,193,53,57,102,240,255,219,161,190,248,231,102,116,147,108,190,1,34,65,119,204,187,6,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,45,46,78,76,79,181,50,180,50,212,9,72,44,74,205,43,177,50,176,50,208,113,46,74,77,44,73,77,113,170,4,243,60,83,64,20,0,81,116,18,230,43,0,0,0 })));
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
								new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"));
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

			public ReadDataUserTask2FlowElement(UserConnection userConnection, ESNNotificationProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("9ffb5ac4-cd54-494c-9b2d-e52a5ea474d9");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,111,26,49,16,253,43,104,207,49,90,246,203,44,183,54,37,85,164,182,65,37,202,165,228,48,216,99,176,178,139,87,182,73,75,17,255,189,227,93,160,164,66,45,173,84,85,245,201,126,122,51,243,230,121,102,27,137,10,156,251,0,53,70,163,232,245,228,253,212,40,223,191,209,149,71,251,214,154,117,19,93,69,14,173,134,74,127,69,217,225,99,169,253,27,240,64,1,219,217,247,248,89,52,154,157,203,48,139,174,102,145,246,88,59,98,132,0,5,92,22,92,178,56,43,82,150,21,48,96,192,227,152,205,133,76,50,57,7,224,124,184,103,158,77,125,109,234,6,44,118,21,218,228,170,189,222,111,154,64,28,16,32,90,138,118,102,181,7,211,32,193,141,87,48,175,80,210,219,219,53,18,228,173,174,169,19,188,215,53,78,192,82,165,144,199,4,136,72,10,42,23,88,21,42,63,254,210,88,116,78,155,213,207,165,85,235,122,117,202,165,112,60,62,247,98,226,86,97,96,78,192,47,219,4,183,36,106,215,106,124,181,88,88,92,128,215,207,167,18,158,112,211,242,46,243,142,2,36,253,207,3,84,107,60,169,249,178,143,107,104,124,215,78,87,158,8,86,47,150,23,118,122,116,235,87,205,38,4,54,7,242,69,25,207,234,79,10,2,159,3,208,229,56,92,103,209,167,91,119,247,121,133,118,42,150,88,67,231,216,99,159,208,31,128,113,133,53,174,252,104,59,152,115,46,243,44,101,137,28,42,242,112,136,12,68,150,179,180,224,152,243,156,103,42,81,59,10,56,10,26,109,49,19,138,67,60,100,66,13,6,44,67,37,24,128,44,25,31,150,131,82,112,81,230,101,186,123,236,132,107,215,84,176,121,56,234,187,65,148,189,198,56,223,171,244,19,246,64,74,148,253,143,40,140,149,237,175,135,19,62,199,44,180,128,234,174,65,75,159,223,154,31,159,31,218,23,211,30,108,177,198,248,174,217,163,169,83,35,104,101,223,81,193,86,212,97,124,18,210,27,243,132,211,188,164,57,203,84,25,51,72,36,178,84,168,50,139,147,188,16,188,32,73,180,243,193,255,169,89,91,177,223,51,215,45,251,31,173,241,63,88,207,223,217,185,179,83,127,201,28,255,159,51,186,11,231,175,14,220,46,218,125,3,106,36,148,146,87,6,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,11,45,78,45,178,50,180,50,212,113,46,74,77,44,73,77,241,207,179,50,176,50,208,9,206,79,206,76,204,241,77,45,46,78,76,79,5,139,120,166,128,40,0,3,32,50,156,47,0,0,0 })));
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
								new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb"));
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

		#region Class: AddLikedNotificationUserTaskFlowElement

		/// <exclude/>
		public class AddLikedNotificationUserTaskFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddLikedNotificationUserTaskFlowElement(UserConnection userConnection, ESNNotificationProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddLikedNotificationUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("e3294926-e0c2-4d63-8254-b110d3562cae");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_IsRead = () => (bool)(false);
				_recordDefValues_Type = () => (Guid)(new Guid("4bfd2825-c7a9-4133-b99e-0d6b3dbba451"));
				_recordDefValues_SocialMessage = () => (Guid)(((process.ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("SocialMessage").ColumnValueName) ? process.ReadDataUserTask2.ResultEntity.GetTypedColumnValue<Guid>("SocialMessageId") : Guid.Empty)));
				_recordDefValues_Owner = () => (Guid)(((process.ReadLikedPostUserTask.ResultEntity.IsColumnValueLoaded(process.ReadLikedPostUserTask.ResultEntity.Schema.Columns.GetByName("CreatedBy").ColumnValueName) ? process.ReadLikedPostUserTask.ResultEntity.GetTypedColumnValue<Guid>("CreatedById") : Guid.Empty)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_IsRead", () => _recordDefValues_IsRead.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Type", () => _recordDefValues_Type.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_SocialMessage", () => _recordDefValues_SocialMessage.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Owner", () => _recordDefValues_Owner.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<bool> _recordDefValues_IsRead;
			internal Func<Guid> _recordDefValues_Type;
			internal Func<Guid> _recordDefValues_SocialMessage;
			internal Func<Guid> _recordDefValues_Owner;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,150,89,111,219,70,16,199,191,10,193,228,209,35,236,125,232,177,142,11,24,176,83,195,78,243,98,251,97,143,217,88,8,77,26,34,213,194,21,244,221,59,164,45,95,77,29,167,23,26,192,124,144,200,229,204,236,236,127,231,199,217,117,253,118,184,190,194,122,94,255,112,116,120,210,149,97,182,219,45,113,118,180,236,18,246,253,236,160,75,161,89,252,22,98,131,71,97,25,46,113,192,229,199,208,172,176,63,88,244,195,78,245,208,169,222,169,223,254,50,189,171,231,167,235,122,127,192,203,159,247,51,69,54,33,24,231,140,6,107,164,7,133,210,130,231,44,67,42,198,103,151,83,40,73,144,115,234,154,213,101,123,136,67,56,10,195,69,61,95,215,83,52,10,144,173,177,228,166,192,51,163,64,9,97,33,38,23,193,122,173,93,116,82,113,237,235,205,78,221,167,11,188,12,211,164,247,206,156,169,44,89,228,160,180,11,160,124,244,224,20,133,9,88,184,205,214,69,197,249,232,124,107,127,239,88,66,211,227,248,38,47,250,171,38,92,127,252,83,131,171,71,210,60,52,89,159,221,232,123,86,207,207,190,172,240,237,255,201,148,250,99,141,31,203,123,86,239,156,213,39,221,106,153,198,104,146,30,222,61,200,107,154,96,50,121,242,184,213,147,70,218,85,211,220,142,188,11,67,216,26,110,135,187,188,40,11,204,251,237,201,86,198,41,10,187,189,224,11,63,219,235,38,183,191,227,118,24,218,240,9,151,239,105,249,247,185,223,101,249,129,36,220,6,246,44,26,29,139,3,86,74,2,197,21,7,103,173,7,161,4,163,155,80,60,179,147,247,49,22,92,98,155,240,47,38,118,140,253,164,246,88,200,183,121,141,82,109,234,205,102,231,97,121,99,20,165,8,193,64,5,42,76,197,153,6,103,152,4,44,197,96,177,5,29,202,103,203,219,41,149,52,74,3,182,228,49,64,178,224,120,206,160,169,232,93,180,44,41,93,254,249,242,62,125,115,208,117,159,87,87,51,205,82,138,206,57,8,74,105,80,25,35,120,157,199,128,34,121,83,82,246,78,205,84,44,89,56,161,33,217,64,12,115,41,33,122,143,192,178,137,50,199,24,148,230,111,206,159,163,229,110,190,189,147,247,85,219,13,84,108,41,12,139,174,173,70,64,102,205,226,51,230,234,154,20,175,174,186,126,184,137,245,10,214,127,8,86,20,94,51,203,11,88,28,183,24,141,0,151,121,160,111,181,143,69,90,57,86,249,115,96,189,164,142,190,9,172,200,2,19,150,150,134,94,17,233,78,36,136,156,35,100,41,21,243,104,85,136,234,89,176,144,243,76,54,132,5,147,132,39,227,10,34,74,14,150,81,212,36,11,231,197,253,27,96,157,238,247,63,253,218,226,242,70,159,249,212,39,206,103,52,250,100,96,175,193,75,108,135,249,218,151,18,117,72,10,82,214,212,224,198,229,250,40,50,160,22,65,99,80,86,101,191,33,135,187,254,48,95,103,43,75,100,214,16,134,212,74,201,66,147,238,81,64,9,137,203,228,117,40,54,143,46,123,237,176,24,174,119,39,141,230,107,151,140,81,140,20,145,212,139,9,99,27,193,249,100,0,109,214,212,166,233,62,203,205,249,215,64,62,198,144,171,225,2,171,17,218,42,83,49,205,126,92,44,251,161,90,208,222,85,93,169,150,216,175,154,97,209,126,170,104,115,26,76,35,230,179,67,106,115,84,138,175,100,127,119,100,71,134,214,37,33,9,28,63,146,173,61,68,71,120,39,206,132,146,49,101,99,227,55,145,237,50,145,228,169,192,125,182,4,88,112,133,2,142,7,196,16,80,4,198,140,23,254,89,178,163,87,94,243,68,121,132,68,25,145,15,248,68,161,140,73,210,10,35,132,46,246,127,65,118,146,146,231,18,51,176,68,170,171,168,51,184,226,105,185,193,24,73,178,22,145,243,19,178,157,20,218,89,238,233,99,96,41,61,77,91,22,5,34,72,90,179,15,50,24,198,229,31,201,198,88,76,140,94,130,163,211,54,73,202,56,157,150,199,67,182,193,96,232,84,84,80,240,23,146,125,211,138,199,46,252,98,182,119,187,118,8,233,181,107,127,127,108,115,67,45,209,104,58,68,83,133,80,71,32,182,93,206,12,130,99,146,40,117,50,103,249,53,182,207,55,191,3,14,45,123,115,71,14,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "5ca46f1711e94116b7e56dc129a6bce3",
							"BaseElements.AddLikedNotificationUserTask.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509");
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

		#region Class: ReadLikedPostUserTaskFlowElement

		/// <exclude/>
		public class ReadLikedPostUserTaskFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadLikedPostUserTaskFlowElement(UserConnection userConnection, ESNNotificationProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadLikedPostUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("c331dfbd-0c62-4b5d-8f9f-ba6630e7f2dd");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,203,110,219,48,16,252,21,65,231,48,144,37,82,178,124,107,83,183,200,33,77,80,7,185,196,57,172,200,165,76,68,47,80,116,90,215,240,191,119,41,37,174,83,24,173,219,75,11,84,39,106,48,187,156,125,12,183,161,172,160,239,63,66,141,225,44,124,123,115,181,104,181,59,127,111,42,135,246,131,109,215,93,120,22,246,104,13,84,230,43,170,17,159,43,227,222,129,3,10,216,46,191,199,47,195,217,242,88,134,101,120,182,12,141,195,186,39,6,5,160,202,18,4,41,216,52,5,201,120,148,100,12,10,145,177,4,121,154,160,142,197,36,142,71,230,241,212,23,109,221,129,197,241,134,33,185,30,142,183,155,206,19,39,4,200,129,98,250,182,121,6,19,47,161,159,55,80,84,168,232,223,217,53,18,228,172,169,169,18,188,53,53,222,128,165,155,124,158,214,67,68,210,80,245,158,85,161,118,243,47,157,197,190,55,109,243,115,105,213,186,110,14,185,20,142,251,223,103,49,209,160,208,51,111,192,173,134,4,151,36,106,55,104,124,83,150,22,75,112,230,233,80,194,35,110,6,222,105,189,163,0,69,243,185,131,106,141,7,119,190,174,227,2,58,55,150,51,94,79,4,107,202,213,137,149,238,187,245,171,98,99,2,187,23,242,73,25,143,234,143,83,2,159,60,48,230,120,57,46,195,251,203,254,250,115,131,118,33,87,88,195,216,177,135,115,66,127,0,230,21,214,216,184,217,54,215,186,16,32,57,147,74,112,198,115,46,89,94,196,138,161,136,65,32,240,140,171,124,71,1,123,65,179,45,117,93,23,81,150,178,34,143,20,35,134,96,192,139,152,105,144,147,68,230,2,116,166,124,200,188,113,198,109,198,45,152,109,167,50,77,121,196,129,37,89,154,48,62,201,10,54,205,101,202,48,83,34,5,160,179,74,118,15,99,185,166,239,42,216,220,237,171,250,132,160,2,183,194,160,50,143,24,248,110,144,165,108,239,2,111,164,160,213,1,117,121,93,57,211,148,1,173,82,133,210,207,242,252,138,90,15,37,14,41,253,76,41,145,136,166,128,89,174,89,166,39,83,198,147,40,99,57,10,96,41,143,57,143,49,210,177,55,196,206,127,126,69,218,210,72,168,174,59,180,180,130,195,10,68,199,173,243,202,115,126,56,182,109,221,216,242,253,104,23,173,164,135,227,80,212,203,30,171,68,113,206,163,9,227,106,26,51,46,84,206,32,41,4,203,121,145,165,121,166,10,169,167,164,138,30,31,95,250,162,93,91,249,108,248,126,124,117,254,232,61,249,11,239,196,239,152,255,168,253,78,49,212,127,102,150,203,127,110,179,119,225,238,27,199,81,135,143,73,7,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,45,46,78,76,79,181,50,180,50,212,241,76,177,50,176,50,208,9,72,44,74,205,43,1,49,1,78,75,80,76,29,0,0,0 })));
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
								new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"));
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

			public ReadDataUserTask3FlowElement(UserConnection userConnection, ESNNotificationProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask3";
				IsLogging = true;
				SchemaElementUId = new Guid("63021f02-e6c9-46c2-810b-aaf44b0878cb");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,115,211,48,16,253,43,29,159,171,140,109,201,118,156,27,148,192,228,80,218,33,109,47,164,135,149,180,74,53,216,177,71,86,10,37,147,255,206,202,78,66,203,100,32,112,1,124,177,244,230,237,238,219,47,109,34,85,65,215,189,135,26,163,73,244,250,250,114,222,24,63,122,107,43,143,238,157,107,214,109,116,30,117,232,44,84,246,43,234,1,159,106,235,223,128,7,50,216,44,190,219,47,162,201,226,152,135,69,116,190,136,172,199,186,35,6,25,72,201,37,207,75,96,42,73,13,19,60,203,89,89,198,99,198,133,224,220,112,37,120,9,3,243,184,235,139,166,110,193,225,16,161,119,110,250,227,205,83,27,136,9,1,170,167,216,174,89,237,64,30,36,116,211,21,200,10,53,221,189,91,35,65,222,217,154,50,193,27,91,227,53,56,138,20,252,52,1,34,146,129,170,11,172,10,141,159,126,105,29,118,157,109,86,63,151,86,173,235,213,115,46,153,227,225,186,19,19,247,10,3,243,26,252,67,239,96,70,162,182,189,198,87,203,165,195,37,120,251,248,92,194,39,124,234,121,167,213,142,12,52,245,231,14,170,53,62,139,249,50,143,11,104,253,144,206,16,158,8,206,46,31,78,204,244,80,173,95,37,155,18,216,238,201,39,121,60,170,63,205,9,124,12,192,224,99,127,92,68,31,103,221,213,231,21,186,185,122,192,26,134,138,221,143,8,253,1,152,86,88,227,202,79,54,227,172,52,210,24,193,18,173,21,19,73,34,24,72,157,178,12,226,50,45,56,26,147,22,91,50,56,8,154,108,84,156,23,192,75,195,18,28,83,217,69,102,24,164,188,100,40,98,136,149,65,145,136,124,123,63,8,183,93,91,193,211,221,65,223,45,173,207,89,136,76,53,57,3,173,81,143,62,160,106,156,222,21,61,252,136,166,208,140,149,16,138,1,207,53,19,134,231,108,156,165,41,19,5,66,34,177,228,153,84,52,35,225,11,173,108,150,86,65,117,213,162,163,81,233,91,21,31,31,241,23,187,17,138,232,154,198,15,165,57,180,96,222,40,90,240,203,65,99,47,106,63,111,99,94,112,33,77,206,114,94,0,19,40,51,38,11,157,176,52,214,144,96,42,19,169,10,82,69,143,68,104,216,188,89,59,181,91,204,110,120,29,254,104,239,255,194,62,255,206,146,30,93,147,83,6,255,191,29,234,217,63,55,163,219,104,251,13,198,87,201,6,187,6,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,77,241,207,179,50,176,50,212,9,206,79,206,76,204,241,77,45,46,78,76,79,5,138,24,232,120,166,128,40,0,102,106,230,161,38,0,0,0 })));
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
								new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe"));
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

			public ReadDataUserTask4FlowElement(UserConnection userConnection, ESNNotificationProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask4";
				IsLogging = true;
				SchemaElementUId = new Guid("b5abaf4a-f9f0-466b-b826-7a4745708a79");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,212,48,16,253,43,171,156,235,202,142,29,39,217,27,148,5,245,80,90,177,85,47,108,15,142,51,78,45,242,37,199,91,88,86,251,223,25,39,237,178,69,43,88,184,128,68,78,206,211,155,241,155,55,51,222,70,186,86,195,240,94,53,16,205,163,215,55,87,203,206,248,243,183,182,246,224,222,185,110,221,71,103,209,0,206,170,218,126,133,114,194,23,165,245,111,148,87,24,176,93,125,143,95,69,243,213,177,12,171,232,108,21,89,15,205,128,12,12,160,44,45,89,154,22,164,204,68,65,4,77,56,201,51,41,9,103,73,201,165,41,100,76,243,137,121,60,245,69,215,244,202,193,116,195,152,220,140,199,219,77,31,136,12,1,61,82,236,208,181,79,32,15,18,134,69,171,138,26,74,252,247,110,13,8,121,103,27,172,4,110,109,3,55,202,225,77,33,79,23,32,36,25,85,15,129,85,131,241,139,47,189,131,97,176,93,251,115,105,245,186,105,15,185,24,14,251,223,39,49,116,84,24,152,55,202,63,140,9,46,81,212,110,212,248,170,170,28,84,202,219,199,67,9,159,96,51,242,78,243,14,3,74,236,207,157,170,215,112,112,231,203,58,46,84,239,167,114,166,235,145,224,108,245,112,98,165,123,183,126,85,108,140,96,255,76,62,41,227,81,253,177,68,240,49,0,83,142,231,227,42,250,120,57,92,127,110,193,45,245,3,52,106,114,236,254,28,209,31,128,69,13,13,180,126,190,149,156,198,204,208,152,128,212,57,17,82,199,36,99,180,32,74,25,33,10,154,165,153,46,118,24,176,23,52,223,150,121,76,101,162,82,146,65,138,33,28,82,146,83,201,136,97,178,144,180,16,153,144,38,132,44,90,111,253,102,154,130,249,86,49,46,36,213,41,145,60,193,102,9,101,72,206,53,16,150,154,184,40,68,201,83,81,238,238,167,114,237,208,215,106,115,183,175,234,3,168,114,22,244,162,147,179,96,6,110,148,27,252,44,236,209,172,51,51,52,121,93,123,219,86,51,156,164,26,116,224,157,95,161,243,170,130,49,99,104,41,230,225,96,178,132,39,130,36,66,11,34,242,88,18,37,100,74,82,195,104,30,51,206,89,156,224,232,133,47,76,72,87,89,173,234,235,30,28,78,224,56,1,244,248,230,188,88,185,208,27,215,117,126,114,124,223,217,101,167,241,221,56,20,181,31,227,34,73,208,64,212,82,160,251,34,147,148,168,12,253,212,73,102,242,88,100,74,3,69,85,248,246,132,210,151,221,218,233,167,125,31,166,71,231,143,158,147,191,240,76,252,206,238,31,221,190,83,246,233,63,219,149,203,127,110,178,119,209,238,27,195,248,119,236,72,7,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,45,46,78,76,79,181,50,180,50,212,9,72,44,74,205,43,177,50,176,50,208,241,76,1,81,0,255,202,163,187,29,0,0,0 })));
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
								new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"));
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

		#region Class: AddMentionNotificationUserTaskFlowElement

		/// <exclude/>
		public class AddMentionNotificationUserTaskFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddMentionNotificationUserTaskFlowElement(UserConnection userConnection, ESNNotificationProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddMentionNotificationUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("17ba8704-d3e6-41f6-afba-676772da8162");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_IsRead = () => (bool)(false);
				_recordDefValues_Type = () => (Guid)(new Guid("85ab04b0-f624-49b4-8eb8-0cc5fb4108d6"));
				_recordDefValues_SocialMessage = () => (Guid)(((process.ReadDataUserTask3.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask3.ResultEntity.Schema.Columns.GetByName("SocialMessage").ColumnValueName) ? process.ReadDataUserTask3.ResultEntity.GetTypedColumnValue<Guid>("SocialMessageId") : Guid.Empty)));
				_recordDefValues_Owner = () => (Guid)(((process.ReadDataUserTask3.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask3.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? process.ReadDataUserTask3.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_IsRead", () => _recordDefValues_IsRead.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Type", () => _recordDefValues_Type.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_SocialMessage", () => _recordDefValues_SocialMessage.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Owner", () => _recordDefValues_Owner.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<bool> _recordDefValues_IsRead;
			internal Func<Guid> _recordDefValues_Type;
			internal Func<Guid> _recordDefValues_SocialMessage;
			internal Func<Guid> _recordDefValues_Owner;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,150,219,110,219,70,16,134,95,133,96,114,233,21,246,124,208,101,29,23,48,96,167,70,156,230,198,246,197,30,102,98,161,20,105,136,84,11,87,208,187,119,72,75,62,4,169,211,180,77,129,160,230,5,37,46,119,134,179,63,255,143,179,155,250,245,112,123,3,245,188,254,225,236,244,188,195,97,118,216,173,96,118,182,234,50,244,253,236,164,203,177,89,252,30,83,3,103,113,21,151,48,192,234,67,108,214,208,159,44,250,225,160,122,28,84,31,212,175,127,157,238,213,243,139,77,125,60,192,242,231,227,66,153,193,112,239,149,44,204,21,14,76,167,228,152,119,89,50,212,28,147,138,66,103,110,40,56,119,205,122,217,158,194,16,207,226,112,93,207,55,245,148,141,18,20,103,157,6,165,89,224,86,51,45,165,99,41,251,196,92,48,198,39,175,180,48,161,222,30,212,125,190,134,101,156,30,250,16,44,184,46,138,39,193,180,241,145,233,144,2,243,154,210,68,64,225,138,243,73,11,49,6,239,230,63,4,98,108,122,24,239,148,69,127,211,196,219,15,127,58,225,230,137,52,143,167,108,46,239,244,189,172,231,151,159,87,120,247,123,62,149,254,84,227,167,242,94,214,7,151,245,121,183,94,229,49,155,162,139,55,143,234,154,30,48,77,249,228,114,175,39,141,180,235,166,217,141,188,137,67,220,79,220,15,119,101,129,11,40,199,237,249,94,198,41,11,223,29,236,51,167,253,113,87,219,63,9,59,141,109,252,8,171,183,180,252,135,218,239,171,124,79,18,238,19,7,158,172,73,232,25,71,204,76,11,45,200,77,46,48,169,37,167,63,17,3,119,83,244,59,64,88,65,155,225,111,22,246,14,250,73,237,209,200,187,186,70,169,182,245,118,123,240,216,222,46,20,229,48,121,22,181,37,123,67,178,44,102,238,153,176,222,161,66,4,15,226,89,123,123,173,179,1,101,153,195,226,104,69,153,248,16,165,48,67,166,247,201,241,172,13,254,251,246,190,120,117,210,117,191,172,111,102,134,231,156,188,31,235,215,134,233,2,137,5,83,198,132,50,7,139,185,4,175,103,222,196,196,117,226,12,173,36,4,67,210,204,3,173,153,98,13,210,51,184,47,246,213,213,115,180,220,63,239,232,252,109,213,118,3,153,45,199,97,209,181,213,8,200,108,9,237,120,1,165,186,237,214,213,130,70,175,161,90,18,25,100,139,187,196,47,148,253,135,148,37,25,12,119,2,153,131,24,200,212,86,50,95,68,100,65,132,132,202,41,137,40,159,163,236,175,152,234,171,40,147,10,173,195,16,88,1,158,40,77,74,84,16,97,159,145,23,17,10,154,16,244,179,148,129,16,37,38,77,140,112,197,233,36,52,75,160,4,115,220,113,158,21,10,129,254,91,80,118,113,220,255,244,91,11,171,59,125,230,83,211,184,154,209,232,39,3,71,13,140,12,204,55,86,113,41,144,75,6,54,147,244,150,58,165,23,180,230,24,81,19,129,222,249,156,182,20,112,223,44,230,155,18,36,183,38,210,119,3,72,18,173,192,141,173,82,48,20,54,89,158,52,213,138,99,200,17,49,54,220,30,78,26,205,55,81,40,109,57,125,109,172,50,36,169,142,200,130,202,192,132,67,153,18,45,216,233,178,189,250,18,213,239,32,150,106,71,111,85,200,75,179,31,23,171,126,168,22,244,234,170,14,171,21,244,235,102,88,180,31,43,122,55,13,228,113,222,236,244,5,236,239,20,236,196,129,12,40,21,113,19,70,176,77,96,137,58,1,203,130,75,173,82,46,214,165,175,2,187,160,138,228,55,193,8,49,234,231,40,3,11,201,7,106,52,66,112,161,188,212,66,62,11,118,10,58,24,65,168,164,152,169,34,25,57,11,217,9,102,109,86,78,90,41,13,186,255,23,216,188,208,48,186,241,29,185,113,191,108,40,42,70,195,104,123,145,76,176,42,241,168,191,17,216,135,93,59,196,60,188,116,236,239,14,108,114,20,237,65,13,237,166,17,36,237,66,9,108,95,10,103,209,115,69,126,242,170,20,245,37,176,175,182,127,0,230,86,203,198,80,14,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "5ca46f1711e94116b7e56dc129a6bce3",
							"BaseElements.AddMentionNotificationUserTask.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509");
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

		public ESNNotificationProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ESNNotificationProcess";
			SchemaUId = new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5ca46f17-11e9-4116-b7e5-6dc129a6bce3");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ESNNotificationProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ESNNotificationProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid NotificationIdParameter {
			get;
			set;
		}

		private ProcessPostCommentLane _postCommentLane;
		public ProcessPostCommentLane PostCommentLane {
			get {
				return _postCommentLane ?? ((_postCommentLane) = new ProcessPostCommentLane(UserConnection, this));
			}
		}

		private ProcessTerminateEvent _terminateProcess;
		public ProcessTerminateEvent TerminateProcess {
			get {
				return _terminateProcess ?? (_terminateProcess = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateProcess",
					SchemaElementUId = new Guid("b31e7b6c-362c-41a5-9e34-85da4aeff8e1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessStartSignalEvent _onPostCommentedStartSignal;
		public ProcessStartSignalEvent OnPostCommentedStartSignal {
			get {
				return _onPostCommentedStartSignal ?? (_onPostCommentedStartSignal = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "OnPostCommentedStartSignal",
					SerializeToDB = false,
					IsLogging = true,
					SchemaElementUId = new Guid("08f41d99-9838-418a-b579-a7177272506b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ReadCommentedPostUserTaskFlowElement _readCommentedPostUserTask;
		public ReadCommentedPostUserTaskFlowElement ReadCommentedPostUserTask {
			get {
				return _readCommentedPostUserTask ?? (_readCommentedPostUserTask = new ReadCommentedPostUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddCommentNotificationUserTaskFlowElement _addCommentNotificationUserTask;
		public AddCommentNotificationUserTaskFlowElement AddCommentNotificationUserTask {
			get {
				return _addCommentNotificationUserTask ?? (_addCommentNotificationUserTask = new AddCommentNotificationUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataUserTask1FlowElement _readDataUserTask1;
		public ReadDataUserTask1FlowElement ReadDataUserTask1 {
			get {
				return _readDataUserTask1 ?? (_readDataUserTask1 = new ReadDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessStartSignalEvent _onLikeAddedStartSignal;
		public ProcessStartSignalEvent OnLikeAddedStartSignal {
			get {
				return _onLikeAddedStartSignal ?? (_onLikeAddedStartSignal = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "OnLikeAddedStartSignal",
					SerializeToDB = false,
					IsLogging = true,
					SchemaElementUId = new Guid("1b77d543-2d8f-468e-ac45-367e57574f2f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ReadDataUserTask2FlowElement _readDataUserTask2;
		public ReadDataUserTask2FlowElement ReadDataUserTask2 {
			get {
				return _readDataUserTask2 ?? (_readDataUserTask2 = new ReadDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddLikedNotificationUserTaskFlowElement _addLikedNotificationUserTask;
		public AddLikedNotificationUserTaskFlowElement AddLikedNotificationUserTask {
			get {
				return _addLikedNotificationUserTask ?? (_addLikedNotificationUserTask = new AddLikedNotificationUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadLikedPostUserTaskFlowElement _readLikedPostUserTask;
		public ReadLikedPostUserTaskFlowElement ReadLikedPostUserTask {
			get {
				return _readLikedPostUserTask ?? (_readLikedPostUserTask = new ReadLikedPostUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _sendNotificationScriptTask;
		public ProcessScriptTask SendNotificationScriptTask {
			get {
				return _sendNotificationScriptTask ?? (_sendNotificationScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendNotificationScriptTask",
					SchemaElementUId = new Guid("32d0ae3e-a939-4d47-95b8-8a0fefbe6a8c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SendNotificationScriptTaskExecute,
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
					SchemaElementUId = new Guid("c6a307e4-94ad-4577-b6c1-23185045e859"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask1Execute,
				});
			}
		}

		private ProcessInclusiveGateway _inclusiveGateway1;
		public ProcessInclusiveGateway InclusiveGateway1 {
			get {
				return _inclusiveGateway1 ?? (_inclusiveGateway1 = new ProcessInclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaInclusiveGateway",
					Name = "InclusiveGateway1",
					SchemaElementUId = new Guid("8b08f239-cebb-480e-aa3e-b2513abac21b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.InclusiveGateway1.Question"),
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
					SchemaElementUId = new Guid("109b1c48-4f13-4d85-b81a-a9a72ece3004"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask2Execute,
				});
			}
		}

		private ReadDataUserTask3FlowElement _readDataUserTask3;
		public ReadDataUserTask3FlowElement ReadDataUserTask3 {
			get {
				return _readDataUserTask3 ?? (_readDataUserTask3 = new ReadDataUserTask3FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessStartSignalEvent _onMentionAddedStartSignal;
		public ProcessStartSignalEvent OnMentionAddedStartSignal {
			get {
				return _onMentionAddedStartSignal ?? (_onMentionAddedStartSignal = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "OnMentionAddedStartSignal",
					SerializeToDB = false,
					IsLogging = true,
					SchemaElementUId = new Guid("859fbff4-1ddc-4114-abd2-5a09273eff27"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ReadDataUserTask4FlowElement _readDataUserTask4;
		public ReadDataUserTask4FlowElement ReadDataUserTask4 {
			get {
				return _readDataUserTask4 ?? (_readDataUserTask4 = new ReadDataUserTask4FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddMentionNotificationUserTaskFlowElement _addMentionNotificationUserTask;
		public AddMentionNotificationUserTaskFlowElement AddMentionNotificationUserTask {
			get {
				return _addMentionNotificationUserTask ?? (_addMentionNotificationUserTask = new AddMentionNotificationUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("c23bd082-a1cf-453c-b6ea-7067d9f9c0dc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask3Execute,
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
					SchemaElementUId = new Guid("2e85559f-f12a-47bc-ab83-2d0181bfba46"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
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
					SchemaElementUId = new Guid("dc6f485e-b8a2-4027-84e9-46cb310090d1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask4Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[TerminateProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateProcess };
			FlowElements[OnPostCommentedStartSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { OnPostCommentedStartSignal };
			FlowElements[ReadCommentedPostUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadCommentedPostUserTask };
			FlowElements[AddCommentNotificationUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AddCommentNotificationUserTask };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[OnLikeAddedStartSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { OnLikeAddedStartSignal };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
			FlowElements[AddLikedNotificationUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AddLikedNotificationUserTask };
			FlowElements[ReadLikedPostUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadLikedPostUserTask };
			FlowElements[SendNotificationScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SendNotificationScriptTask };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[InclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { InclusiveGateway1 };
			FlowElements[FormulaTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask2 };
			FlowElements[ReadDataUserTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask3 };
			FlowElements[OnMentionAddedStartSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { OnMentionAddedStartSignal };
			FlowElements[ReadDataUserTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask4 };
			FlowElements[AddMentionNotificationUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AddMentionNotificationUserTask };
			FlowElements[FormulaTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask3 };
			FlowElements[StartSignal1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal1 };
			FlowElements[FormulaTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask4 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "TerminateProcess":
						CompleteProcess();
						break;
					case "OnPostCommentedStartSignal":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						break;
					case "ReadCommentedPostUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddCommentNotificationUserTask", e.Context.SenderName));
						break;
					case "AddCommentNotificationUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadCommentedPostUserTask", e.Context.SenderName));
						break;
					case "OnLikeAddedStartSignal":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLikedPostUserTask", e.Context.SenderName));
						break;
					case "AddLikedNotificationUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask2", e.Context.SenderName));
						break;
					case "ReadLikedPostUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddLikedNotificationUserTask", e.Context.SenderName));
						break;
					case "SendNotificationScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateProcess", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InclusiveGateway1", e.Context.SenderName));
						break;
					case "InclusiveGateway1":
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendNotificationScriptTask", e.Context.SenderName));
						break;
					case "FormulaTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InclusiveGateway1", e.Context.SenderName));
						break;
					case "ReadDataUserTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask4", e.Context.SenderName));
						break;
					case "OnMentionAddedStartSignal":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask3", e.Context.SenderName));
						break;
					case "ReadDataUserTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddMentionNotificationUserTask", e.Context.SenderName));
						break;
					case "AddMentionNotificationUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask3", e.Context.SenderName));
						break;
					case "FormulaTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InclusiveGateway1", e.Context.SenderName));
						break;
					case "StartSignal1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask4", e.Context.SenderName));
						break;
					case "FormulaTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InclusiveGateway1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("NotificationIdParameter")) {
				writer.WriteValue("NotificationIdParameter", NotificationIdParameter, Guid.Empty);
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
			MetaPathParameterValues.Add("f0a3cf6a-71c5-4eef-add2-9dfe3c7b24a4", () => NotificationIdParameter);
			MetaPathParameterValues.Add("d70075ca-9e0b-44df-a779-e59e0e2f85b4", () => OnPostCommentedStartSignal.RecordId);
			MetaPathParameterValues.Add("2f478e43-a126-41ef-bd27-886141b52843", () => OnPostCommentedStartSignal.EntitySchemaUId);
			MetaPathParameterValues.Add("ba9ba9d2-475d-40f2-8404-7ac59bcee891", () => ReadCommentedPostUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("9a60810c-41d3-474d-908b-832435849593", () => ReadCommentedPostUserTask.ResultType);
			MetaPathParameterValues.Add("56642892-05c7-42ae-8a57-ac21482d70bb", () => ReadCommentedPostUserTask.ReadSomeTopRecords);
			MetaPathParameterValues.Add("0c54e3ed-b510-44aa-95e8-d5869d6647b7", () => ReadCommentedPostUserTask.NumberOfRecords);
			MetaPathParameterValues.Add("3ea11d01-ccd4-45c3-9644-14df37bc5ce0", () => ReadCommentedPostUserTask.FunctionType);
			MetaPathParameterValues.Add("fd3d7954-cc74-4986-a523-d221d7761c23", () => ReadCommentedPostUserTask.AggregationColumnName);
			MetaPathParameterValues.Add("92450397-12f0-4f17-a75d-d38567c6327b", () => ReadCommentedPostUserTask.OrderInfo);
			MetaPathParameterValues.Add("5a1f2b83-ed26-4c92-8480-206a321e9963", () => ReadCommentedPostUserTask.ResultEntity);
			MetaPathParameterValues.Add("2e4064fd-64ed-4abc-8260-c6a14fb6a6c5", () => ReadCommentedPostUserTask.ResultCount);
			MetaPathParameterValues.Add("fd53a939-0d8c-44b8-9ef1-fc1e8c5694e4", () => ReadCommentedPostUserTask.ResultIntegerFunction);
			MetaPathParameterValues.Add("d146f3f2-4cb7-4239-92bf-c9081aa150f5", () => ReadCommentedPostUserTask.ResultFloatFunction);
			MetaPathParameterValues.Add("4508d2c7-78c9-422c-977e-5f7441f0ef76", () => ReadCommentedPostUserTask.ResultDateTimeFunction);
			MetaPathParameterValues.Add("0cc7df16-22da-417e-b78a-80ea545febad", () => ReadCommentedPostUserTask.ResultRowsCount);
			MetaPathParameterValues.Add("15a46e90-2180-4324-bb5b-dcb14fbe07ee", () => ReadCommentedPostUserTask.CanReadUncommitedData);
			MetaPathParameterValues.Add("720d957d-e275-469f-8956-e925ee0c382a", () => ReadCommentedPostUserTask.ResultEntityCollection);
			MetaPathParameterValues.Add("d7c50aae-200a-41d3-8177-d3acea16b585", () => ReadCommentedPostUserTask.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("9702aa85-1629-4ea9-8aa4-2753d1f1692e", () => ReadCommentedPostUserTask.IgnoreDisplayValues);
			MetaPathParameterValues.Add("6a3574e7-1c32-41ba-9a16-e9ed315eef65", () => ReadCommentedPostUserTask.ResultCompositeObjectList);
			MetaPathParameterValues.Add("f2c99b37-6016-4f45-af48-6e6f1c684e46", () => ReadCommentedPostUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("d2f54b5a-bf50-4842-a4f0-4d72ad23d06c", () => AddCommentNotificationUserTask.EntitySchemaId);
			MetaPathParameterValues.Add("7f07f8e3-92dd-4b85-b1a9-b8d1a524e5d5", () => AddCommentNotificationUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("9abee62b-56b1-4c28-93ae-c885bfff3a39", () => AddCommentNotificationUserTask.RecordAddMode);
			MetaPathParameterValues.Add("a806be87-94ba-47b4-9129-331e6d19c0a5", () => AddCommentNotificationUserTask.FilterEntitySchemaId);
			MetaPathParameterValues.Add("b8bbeac4-174d-4926-9467-5e78622c517a", () => AddCommentNotificationUserTask.RecordDefValues);
			MetaPathParameterValues.Add("f640e209-6e76-4601-93eb-8e3eda7f8505", () => AddCommentNotificationUserTask.RecordId);
			MetaPathParameterValues.Add("4fedc289-b361-4e10-81bf-a2fcb257fe3d", () => AddCommentNotificationUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("b16c2a23-8fa1-410c-8bf0-9ded1dcbf5b3", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("310495bd-78ef-46e8-bd4f-08a98a050897", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("cb3ef4f3-9764-4095-a7f4-5e41a35ac0ac", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("54c3435c-6332-48a2-a3e3-e3146231388c", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("48f7c6e0-02c8-4675-80b8-8367b0ef9190", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("d5e71c2a-4e7a-4bbc-8424-96fac9c00de2", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("062d7511-3234-4dc6-98d1-9a2bd134a872", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("21c4f994-ba78-446e-9942-d68f20139863", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("66e87786-c605-4fec-b02e-830988bb2e7d", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("a122acd7-cc81-49fd-8c39-9aab1b9c747c", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("677eaf70-16e1-4664-bae1-944189695e0b", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("f8162883-d725-4f4b-b85f-218697d31396", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("fc9471e4-6058-424b-acd0-8b0ae601c0c6", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("e98494ea-7338-4c9a-b507-c8b3dc9be58f", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("e0adb813-1f6d-4072-b83f-eafcb5ba680c", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("49fd90d6-76c8-48f2-8b16-ea83004edbda", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("b833533c-49e1-4ebc-ac9f-1a911d02ccc4", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("7c3db1aa-d065-4619-9e55-0615dfb22975", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("fa088023-44c1-4370-afa4-5c6b45d07773", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("e4cf7a08-cf11-4efc-aad9-78919c7c9593", () => OnLikeAddedStartSignal.RecordId);
			MetaPathParameterValues.Add("f836b77b-679f-4dfa-a647-9a7e89c1ec39", () => OnLikeAddedStartSignal.EntitySchemaUId);
			MetaPathParameterValues.Add("39c452ee-d582-4fc4-89da-188114ddf6aa", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("ab5d3b2f-e2fb-4c08-99ff-2f80f260179f", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("eb26905a-bd71-46d4-8d6a-d6ed38d0edde", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("c33a347d-db7a-4e6a-919d-dcec7662e460", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("9e247ae1-2b40-42ab-805b-c5d6096d9ba4", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("0a73401c-113f-4c6f-861a-7262b910e6cb", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("a2463ef1-b5d5-415d-b646-059986b3a408", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("d73fb076-b90d-4745-a4b2-fac13c95af7d", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("16d9166d-3ef0-42f4-8408-44ae67b0bbf8", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("7375ce45-bc51-437e-87e1-eedd8eff6e54", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("fe779b3d-abd3-45e1-aeab-f8081843611c", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("41b06c6a-fc83-481d-8934-d1b75bfe8a0f", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("074acb9f-4b51-4a71-96b0-a688dc1e4df0", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("f30a6c29-f244-4a31-9102-fcea5bed4454", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("5556b314-99f0-40b0-8172-959a76296469", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("990df6b1-021b-4232-9284-f92fa22ee682", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("272ed838-6e7e-4ec3-b267-81140797856d", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("daa71dc2-1fb1-4636-bb5a-75c107201ba4", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("489232d2-1dc4-492b-a5a8-1ef8e65ac76c", () => ReadDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("da240fb2-c774-4c74-99fd-2e1fdfae3964", () => AddLikedNotificationUserTask.EntitySchemaId);
			MetaPathParameterValues.Add("17ac42d2-21e6-4d36-ba16-b249f630b24b", () => AddLikedNotificationUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("e8734de8-8d7a-4251-a4ab-c545f58d718b", () => AddLikedNotificationUserTask.RecordAddMode);
			MetaPathParameterValues.Add("644e1f0f-142c-4e1f-8cad-d8d970d36e91", () => AddLikedNotificationUserTask.FilterEntitySchemaId);
			MetaPathParameterValues.Add("56e0b34b-5e15-42e9-b5c8-2bb82ace64b4", () => AddLikedNotificationUserTask.RecordDefValues);
			MetaPathParameterValues.Add("8010ef15-aad8-4dba-850c-692c850d65b9", () => AddLikedNotificationUserTask.RecordId);
			MetaPathParameterValues.Add("c7010526-a688-4407-922b-f374a9b3244a", () => AddLikedNotificationUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("bb823b89-4655-4e40-9e5c-0e10daf24deb", () => ReadLikedPostUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("df4038dc-6372-4684-8eec-b443a51b08be", () => ReadLikedPostUserTask.ResultType);
			MetaPathParameterValues.Add("b90f1d0e-459b-4ff2-84b9-84bdd7ae294d", () => ReadLikedPostUserTask.ReadSomeTopRecords);
			MetaPathParameterValues.Add("55f43d53-adf7-49ba-b7fc-3fdfc2fb2ef5", () => ReadLikedPostUserTask.NumberOfRecords);
			MetaPathParameterValues.Add("be6e2286-7b11-4750-807e-4ce55e79daca", () => ReadLikedPostUserTask.FunctionType);
			MetaPathParameterValues.Add("4e88fd04-f4da-40e3-b8c4-35afe197eb57", () => ReadLikedPostUserTask.AggregationColumnName);
			MetaPathParameterValues.Add("8e49b308-b01a-4375-803d-4e3f3770a686", () => ReadLikedPostUserTask.OrderInfo);
			MetaPathParameterValues.Add("83258719-cd7a-45a9-b2ee-39499a3a6013", () => ReadLikedPostUserTask.ResultEntity);
			MetaPathParameterValues.Add("c164263e-1a79-4940-9a57-e2dccc8fa7a0", () => ReadLikedPostUserTask.ResultCount);
			MetaPathParameterValues.Add("eec87964-39ad-40af-a379-61083fb27433", () => ReadLikedPostUserTask.ResultIntegerFunction);
			MetaPathParameterValues.Add("c2061afa-5a06-4890-9015-495796290789", () => ReadLikedPostUserTask.ResultFloatFunction);
			MetaPathParameterValues.Add("56e6c97a-488f-4add-9847-e81524046833", () => ReadLikedPostUserTask.ResultDateTimeFunction);
			MetaPathParameterValues.Add("8e5240fe-f6fb-4a6b-9ab0-214fcca33c93", () => ReadLikedPostUserTask.ResultRowsCount);
			MetaPathParameterValues.Add("ef6b4042-e216-4b4f-a5ee-db4fe2678424", () => ReadLikedPostUserTask.CanReadUncommitedData);
			MetaPathParameterValues.Add("8c09f3bd-485d-4bc4-8868-7ed8fdc1494b", () => ReadLikedPostUserTask.ResultEntityCollection);
			MetaPathParameterValues.Add("3001471f-45f4-4b10-bb93-e968de3645f2", () => ReadLikedPostUserTask.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("e2be980a-5e5d-46f0-b248-73fd2d5c1967", () => ReadLikedPostUserTask.IgnoreDisplayValues);
			MetaPathParameterValues.Add("7eced334-87e9-445d-b4fc-c349d0303875", () => ReadLikedPostUserTask.ResultCompositeObjectList);
			MetaPathParameterValues.Add("4e2a3f16-2ed0-4300-85ef-3daad88e98d6", () => ReadLikedPostUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("985f26f9-02d6-49a5-afcc-1da4c66649df", () => ReadDataUserTask3.DataSourceFilters);
			MetaPathParameterValues.Add("14407ed4-7b93-4bb0-8947-61bee5163314", () => ReadDataUserTask3.ResultType);
			MetaPathParameterValues.Add("4825dd82-7b93-46dc-930d-b83505b1dfac", () => ReadDataUserTask3.ReadSomeTopRecords);
			MetaPathParameterValues.Add("8dbf8aa1-5f3b-4120-a9f7-2ce998b5271d", () => ReadDataUserTask3.NumberOfRecords);
			MetaPathParameterValues.Add("97994f7a-bac7-48f6-b00e-124a48fb410b", () => ReadDataUserTask3.FunctionType);
			MetaPathParameterValues.Add("4410d85f-c656-4d35-8868-6b0cf395c87f", () => ReadDataUserTask3.AggregationColumnName);
			MetaPathParameterValues.Add("cd03c654-a7de-4ffc-89fa-6c63a3c8eb4e", () => ReadDataUserTask3.OrderInfo);
			MetaPathParameterValues.Add("d92065a7-8e79-43e7-9061-f16b60b4846f", () => ReadDataUserTask3.ResultEntity);
			MetaPathParameterValues.Add("152ec142-0c82-4d70-a402-a52fef871f70", () => ReadDataUserTask3.ResultCount);
			MetaPathParameterValues.Add("b2c24b55-7356-45da-b7fa-06d890b61f98", () => ReadDataUserTask3.ResultIntegerFunction);
			MetaPathParameterValues.Add("1533582a-753c-4ea4-a4b7-fbee9273241e", () => ReadDataUserTask3.ResultFloatFunction);
			MetaPathParameterValues.Add("4d80d870-a1ef-4838-819a-2b0dfb2ceee5", () => ReadDataUserTask3.ResultDateTimeFunction);
			MetaPathParameterValues.Add("379f0ed1-624c-4682-bc40-71ebf792b7c5", () => ReadDataUserTask3.ResultRowsCount);
			MetaPathParameterValues.Add("264b43ca-f583-4d03-9225-6c4c86add08b", () => ReadDataUserTask3.CanReadUncommitedData);
			MetaPathParameterValues.Add("5965ef63-7801-4c91-9a41-a15ad70a5605", () => ReadDataUserTask3.ResultEntityCollection);
			MetaPathParameterValues.Add("838e5c55-a218-4d7e-8db5-2a2360539a1e", () => ReadDataUserTask3.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("9af0e793-7b1b-40b6-b726-89e6b53d8b6b", () => ReadDataUserTask3.IgnoreDisplayValues);
			MetaPathParameterValues.Add("5bd1a28f-6eb3-4163-9ad0-e598003c1907", () => ReadDataUserTask3.ResultCompositeObjectList);
			MetaPathParameterValues.Add("e9dd48c5-c7fe-46e1-b496-5b5dae63c6ee", () => ReadDataUserTask3.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("c067a39f-1e8f-445f-a239-e40a0cfe4146", () => OnMentionAddedStartSignal.RecordId);
			MetaPathParameterValues.Add("50d03153-866c-49a1-b09f-f3572ef11b73", () => OnMentionAddedStartSignal.EntitySchemaUId);
			MetaPathParameterValues.Add("242ce24d-3ddd-45ff-9b66-b7ca7b504cbc", () => ReadDataUserTask4.DataSourceFilters);
			MetaPathParameterValues.Add("0cd58999-5230-4ef3-a513-99389ff530c0", () => ReadDataUserTask4.ResultType);
			MetaPathParameterValues.Add("99ae8ad0-6499-4567-8c65-86a56bbea68f", () => ReadDataUserTask4.ReadSomeTopRecords);
			MetaPathParameterValues.Add("4c952f0e-dffd-4986-846d-384a7af8a09a", () => ReadDataUserTask4.NumberOfRecords);
			MetaPathParameterValues.Add("f8117a6f-4913-432b-b814-eeab6e96632d", () => ReadDataUserTask4.FunctionType);
			MetaPathParameterValues.Add("0dca8765-93e1-4123-8811-6ec3651653bf", () => ReadDataUserTask4.AggregationColumnName);
			MetaPathParameterValues.Add("69d9d40d-db8f-43e9-88ae-a3abf24a965a", () => ReadDataUserTask4.OrderInfo);
			MetaPathParameterValues.Add("8cc5ccbc-2b9c-463a-9bab-aa349cb77cd2", () => ReadDataUserTask4.ResultEntity);
			MetaPathParameterValues.Add("1c4950dc-eb9d-4ad4-ab50-8fbb9420594b", () => ReadDataUserTask4.ResultCount);
			MetaPathParameterValues.Add("290fc9b4-9025-4e3f-98b9-1747c5e4346a", () => ReadDataUserTask4.ResultIntegerFunction);
			MetaPathParameterValues.Add("575e6cd5-8a18-469a-9cd6-55e129df411f", () => ReadDataUserTask4.ResultFloatFunction);
			MetaPathParameterValues.Add("4ae0aeb5-961a-4027-9a0c-5ac3d4a5ac77", () => ReadDataUserTask4.ResultDateTimeFunction);
			MetaPathParameterValues.Add("68d9c290-aed7-4455-8d6c-9b0597a13528", () => ReadDataUserTask4.ResultRowsCount);
			MetaPathParameterValues.Add("cb390c3d-53e0-4db5-8ba9-d854ceef7d5e", () => ReadDataUserTask4.CanReadUncommitedData);
			MetaPathParameterValues.Add("e177f00d-bbb5-4a71-96a5-6b3bd5c30c02", () => ReadDataUserTask4.ResultEntityCollection);
			MetaPathParameterValues.Add("7d9a88fc-ab6e-4c1a-b52c-764cccb74f1a", () => ReadDataUserTask4.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("6ea463a5-4871-446f-af0b-1667f7dedda3", () => ReadDataUserTask4.IgnoreDisplayValues);
			MetaPathParameterValues.Add("48bd0458-36a0-4710-9baf-d55b64ad2ab2", () => ReadDataUserTask4.ResultCompositeObjectList);
			MetaPathParameterValues.Add("ad88c443-aa08-4a50-8ab0-0e7f5effc244", () => ReadDataUserTask4.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("e037ba80-32fe-4970-89b0-011247b9cfca", () => AddMentionNotificationUserTask.EntitySchemaId);
			MetaPathParameterValues.Add("aa175d01-463f-4eaa-b6dd-6e062b0a9fbe", () => AddMentionNotificationUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("31adc4d6-d5e5-44b1-a41c-9f6561db382d", () => AddMentionNotificationUserTask.RecordAddMode);
			MetaPathParameterValues.Add("75b974c3-f286-497f-b22e-63339fcad82c", () => AddMentionNotificationUserTask.FilterEntitySchemaId);
			MetaPathParameterValues.Add("4772da4a-5d0b-4678-8701-ff35ab251456", () => AddMentionNotificationUserTask.RecordDefValues);
			MetaPathParameterValues.Add("2d9562bc-844a-4dc6-86f8-0bfb638f3379", () => AddMentionNotificationUserTask.RecordId);
			MetaPathParameterValues.Add("90b1d03c-5734-4fac-a35c-c496904ac513", () => AddMentionNotificationUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("ab84c217-21ad-45fe-a710-9a563a7cf619", () => StartSignal1.RecordId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "NotificationIdParameter":
					if (!hasValueToRead) break;
					NotificationIdParameter = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SendNotificationScriptTaskExecute(ProcessExecutingContext context) {
			var userConnection = UserConnection;
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "ESNNotification");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var createdOnColumn = esq.AddColumn("CreatedOn");
			var socialMessageIdColumn = esq.AddColumn("SocialMessage.Id");
			var socialMessageTextColumn = esq.AddColumn("SocialMessage.Message");
			var socialMessageEntityIdColumn = esq.AddColumn("SocialMessage.EntityId");
			var socialMessageEntitySchemaUIdColumn = esq.AddColumn("SocialMessage.EntitySchemaUId");
			var socialMessageParentIdColumn = esq.AddColumn("SocialMessage.Parent.Id");
			var socialMessageParentEntityIdColumn = esq.AddColumn("SocialMessage.Parent.EntityId");
			var socialMessageParentEntitySchemaUIdColumn = esq.AddColumn("SocialMessage.Parent.EntitySchemaUId");
			var typeIdColumn = esq.AddColumn("Type.Id");
			var typeActionColumn = esq.AddColumn("Type.Action");
			var typeNameColumn = esq.AddColumn("Type.Name");
			var typeIconIdColumn = esq.AddColumn("Type.Icon");
			var createdByIdColumn = esq.AddColumn("CreatedBy.Id");
			var createdByNameColumn = esq.AddColumn("CreatedBy.Name");
			var createdByPhotoIdColumn = esq.AddColumn("CreatedBy.Photo");
			var ownerIdColumn = esq.AddColumn("Owner");
			var notificationFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", NotificationIdParameter);
			esq.Filters.Add(notificationFilter);
			var notifications = esq.GetEntityCollection(userConnection);
			if (notifications.Count == 0) {
				return false;
			}
			var notification = notifications[0];
			var createdOn = notification.GetTypedColumnValue<DateTime>(createdOnColumn.Name);
			if (createdOn.Kind == DateTimeKind.Local) {
				createdOn = DateTime.SpecifyKind(createdOn, DateTimeKind.Unspecified);
			}
			string createdOnString = DateTimeDataValueType.Serialize(createdOn, TimeZoneInfo.Utc);
			var notificationId = notification.PrimaryColumnValue;
			var socialMessageId = notification.GetTypedColumnValue<Guid>(socialMessageIdColumn.Name);
			var socialMessageText = notification.GetTypedColumnValue<string>(socialMessageTextColumn.Name);
			var socialMessageEntityId = notification.GetTypedColumnValue<Guid>(socialMessageEntityIdColumn.Name);
			var socialMessageEntitySchemaUId = notification.GetTypedColumnValue<Guid>(socialMessageEntitySchemaUIdColumn.Name);
			var socialMessageParentId = notification.GetTypedColumnValue<Guid>(socialMessageParentIdColumn.Name);
			var socialMessageParentEntityId = notification.GetTypedColumnValue<Guid>(socialMessageParentEntityIdColumn.Name);
			var socialMessageParentEntitySchemaUId = notification.GetTypedColumnValue<Guid>(socialMessageParentEntitySchemaUIdColumn.Name);
			var typeId = notification.GetTypedColumnValue<Guid>(typeIdColumn.Name);
			var typeAction = notification.GetTypedColumnValue<string>(typeActionColumn.Name);
			var typeIconId = notification.GetTypedColumnValue<Guid>("Type_IconId");
			var typeName = notification.GetTypedColumnValue<string>(typeNameColumn.Name);
			var createdById = notification.GetTypedColumnValue<Guid>(createdByIdColumn.Name);
			var createdByName = notification.GetTypedColumnValue<string>(createdByNameColumn.Name);
			var createdByPhotoId = notification.GetTypedColumnValue<Guid>("CreatedBy_PhotoId");
			var ownerId = notification.GetTypedColumnValue<Guid>("OwnerId");
			var esqSysAdminUnit = new EntitySchemaQuery(userConnection.EntitySchemaManager, "SysAdminUnit"){
				UseAdminRights = false
			};
			var idColumn = esqSysAdminUnit.AddColumn(esqSysAdminUnit.RootSchema.GetPrimaryColumnName());
			esqSysAdminUnit.Filters.Add(esqSysAdminUnit
				.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", ownerId));
			var entities = esqSysAdminUnit.GetEntityCollection(userConnection);
			if (entities.Count == 0) {
				return false;
			}
			var sysAdminUnit = entities[0];
			var sysAdminUnitId = sysAdminUnit.GetTypedColumnValue<Guid>(idColumn.Name);
			if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
				if (sysAdminUnitId == userConnection.CurrentUser.PrimaryColumnValue) {
					return false;	
				}
				ESNNotificationTextFormer textFormer = ClassFactory.Get<ESNNotificationTextFormer>(
					new ConstructorArgument("userConnection", userConnection));
				Guid entitySchemaUId = socialMessageParentId.IsEmpty()
					? socialMessageEntitySchemaUId
					: socialMessageParentEntitySchemaUId;
				Guid entityId = socialMessageParentId.IsEmpty()
					? socialMessageEntityId
					: socialMessageParentEntityId;
				string entitySchemaName = userConnection
					.EntitySchemaManager
					.FindInstanceByUId(entitySchemaUId).Name;
				NotificationInfo notificationInfo = new NotificationInfo {
					ImageId = createdByPhotoId,
					EntitySchemaName =  entitySchemaName,
					RemindTime = createdOn,
					MessageId = notificationId,
					EntityId = entityId,
					GroupName = "ESNNotification",
					SysAdminUnit = sysAdminUnitId,
					Body = textFormer.GetBody(new Dictionary<string, object> {
						{"CreatedOn", createdOn },
						{"CreatedByName", createdByName },
						{"Action", typeAction },
						{"Message", socialMessageText },
					}),
					Title = textFormer.GetTitle(new Dictionary<string, object> {
						{"TypeName", typeName }
					})
				};
				var notificationSender = ClassFactory.Get<INotificationSender>(
					new ConstructorArgument("userConnection", UserConnection));
				notificationSender.Send(new [] {notificationInfo});
			} else {
				string createdByString = string.Format("{{\"value\":\"{0}\", \"displayValue\":\"{1}\", \"primaryImageValue\":\"{2}\"}}",
					createdById, createdByName, createdByPhotoId);
				string socialMessageParentString = string.Format("{{\"id\":\"{0}\", \"entityId\":\"{1}\", \"entitySchemaUId\":\"{2}\"}}",
					socialMessageParentId, socialMessageParentEntityId, socialMessageParentEntitySchemaUId);
				string socialMessageTextJson = Newtonsoft.Json.JsonConvert.ToString(socialMessageText.ToString());
				string socialMessageString = string.Format(
					"{{\"id\":\"{0}\", \"value\":\"{1}\", \"displayValue\":{2}, \"entityId\":\"{3}\", \"entitySchemaUId\":\"{4}\", \"parent\":{5}}}",
					socialMessageId, socialMessageId, socialMessageTextJson, socialMessageEntityId, socialMessageEntitySchemaUId, socialMessageParentString);
				string typeString = string.Format("{{\"value\":\"{0}\", \"displayValue\":\"{1}\", \"primaryImageValue\":\"{2}\"}}",
					typeId, typeAction, typeIconId);
				var SimpleMessage = new SimpleMessage();
				SimpleMessage.Body = string.Format(
					"{{\"id\":\"{0}\", \"createdOn\":\"{1}\", \"createdBy\":{2}, \"socialMessage\":{3}, \"type\":{4}}}",
					NotificationIdParameter, createdOnString, createdByString, socialMessageString, typeString);
				SimpleMessage.Id = sysAdminUnitId;
				SimpleMessage.Header.Sender = "ESNNotification";
				MsgChannelManager manager = MsgChannelManager.Instance;
				IMsgChannel channel = manager.FindItemByUId(sysAdminUnitId);
				if(channel != null) {
					channel.PostMessage(SimpleMessage);
				}
			}
			return true;
		}

		public virtual bool FormulaTask1Execute(ProcessExecutingContext context) {
			var localNotificationIdParameter = (AddCommentNotificationUserTask.RecordId);
			NotificationIdParameter = (System.Guid)localNotificationIdParameter;
			return true;
		}

		public virtual bool FormulaTask2Execute(ProcessExecutingContext context) {
			var localNotificationIdParameter = (AddLikedNotificationUserTask.RecordId);
			NotificationIdParameter = (System.Guid)localNotificationIdParameter;
			return true;
		}

		public virtual bool FormulaTask3Execute(ProcessExecutingContext context) {
			var localNotificationIdParameter = (AddMentionNotificationUserTask.RecordId);
			NotificationIdParameter = (System.Guid)localNotificationIdParameter;
			return true;
		}

		public virtual bool FormulaTask4Execute(ProcessExecutingContext context) {
			var localNotificationIdParameter = (StartSignal1.RecordId);
			NotificationIdParameter = (System.Guid)localNotificationIdParameter;
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
			var cloneItem = (ESNNotificationProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

