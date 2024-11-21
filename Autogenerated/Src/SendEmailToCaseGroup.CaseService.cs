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

	#region Class: SendEmailToCaseGroupSchema

	/// <exclude/>
	public class SendEmailToCaseGroupSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SendEmailToCaseGroupSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SendEmailToCaseGroupSchema(SendEmailToCaseGroupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SendEmailToCaseGroup";
			UId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb");
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.7.0.0";
			CultureName = @"ru-RU";
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
			RealUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb");
			Version = 0;
			PackageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateIsNeedSendEmailParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("56772c15-0da6-416b-89f3-18ff8e888563"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"IsNeedSendEmail",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"false",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateRecipientEmailsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7ea8c009-6542-4fdd-9572-6a844d21ab92"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"RecipientEmails",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTemplateIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("94d0d4a6-3942-434c-add8-db0c09b339ba"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"TemplateId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#Lookup.93030575-f70f-4041-902e-c4badaf62c63.0dc0759c-80b3-48b3-a832-7e32925d748b#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCaseRecordIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ce79eab9-3a98-423f-b3e9-66323aac7d60"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"CaseRecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSubjectParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("50441308-78db-4135-97ae-5d3c91b5f48f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"Subject",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateEmailSenderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fb6b20e1-ef67-4e02-ae21-d8d6528daffe"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"EmailSender",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateIsNeedSendEmailParameter());
			Parameters.Add(CreateRecipientEmailsParameter());
			Parameters.Add(CreateTemplateIdParameter());
			Parameters.Add(CreateCaseRecordIdParameter());
			Parameters.Add(CreateSubjectParameter());
			Parameters.Add(CreateEmailSenderParameter());
		}

		protected virtual void InitializeReadCaseDataParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4bff0fd5-1b5b-42da-97ec-43b95e6ba9cb"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,143,211,48,16,253,43,171,156,215,171,124,213,73,122,131,82,80,15,176,149,186,218,11,217,195,196,158,180,22,73,29,217,238,66,169,250,223,25,39,109,233,162,10,10,23,54,151,196,47,111,222,188,25,207,236,2,209,128,181,159,160,197,96,28,188,157,127,92,232,218,221,189,87,141,67,243,193,232,77,23,220,6,22,141,130,70,125,71,57,224,83,169,220,59,112,64,1,187,242,103,124,25,140,203,75,10,101,112,91,6,202,97,107,137,65,1,73,88,100,17,231,25,139,249,104,196,210,80,134,172,74,195,140,165,128,53,240,164,40,226,52,31,152,151,165,39,186,237,192,224,144,161,23,175,251,207,135,109,231,137,17,1,162,167,40,171,215,7,48,241,22,236,116,13,85,131,146,206,206,108,144,32,103,84,75,149,224,131,106,113,14,134,50,121,29,237,33,34,213,208,88,207,106,176,118,211,111,157,65,107,149,94,255,222,90,179,105,215,231,92,10,199,211,241,96,38,236,29,122,230,28,220,170,23,152,145,169,125,239,241,205,114,105,112,9,78,61,159,91,248,130,219,158,119,93,239,40,64,210,253,60,66,179,193,179,156,47,235,152,64,231,134,114,134,244,68,48,106,185,186,178,210,83,183,254,84,108,76,96,119,36,95,165,120,209,127,204,9,124,246,192,160,113,252,44,131,207,51,123,255,117,141,102,33,86,216,194,208,177,167,59,66,127,1,78,250,227,157,192,172,64,168,10,150,64,145,179,52,78,106,86,37,88,48,206,147,56,1,16,153,228,225,254,105,240,161,108,215,192,246,241,148,110,2,22,111,12,10,109,228,205,161,109,254,69,127,34,153,139,136,199,146,65,146,215,44,173,242,156,129,0,193,48,26,69,40,68,62,202,120,72,183,236,31,127,25,122,169,4,52,247,29,26,186,236,190,217,209,229,33,125,49,221,190,13,70,107,55,20,119,106,162,119,213,123,57,14,74,30,11,164,105,136,152,204,71,64,37,2,103,85,33,19,198,11,94,11,41,163,40,242,41,246,180,221,190,211,11,189,49,226,176,81,118,88,235,127,90,216,255,176,136,127,179,93,23,231,251,154,137,125,45,211,56,123,45,147,182,15,246,63,0,115,106,193,105,58,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a33f837c-29dc-4fee-a6ce-9b43656fdcf8"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("abb94808-5aed-4a2b-91a0-b3c4e019244f"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5c31db74-03b4-4e13-b937-a5bd1c4b9346"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("43f58502-a3f9-4d89-8b05-bfd006634914"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9bbb4181-ec2f-4b6d-9c67-a8acb3d3bb29"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("71f14a14-3659-44b0-8b17-52639bb50b8b"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("b3e79b7f-0cf2-4db9-a3b5-50f22bd30da9"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b94c3537-238d-4c55-bf91-3524d23fa348"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("11c9e107-95c8-4c1c-9999-e948c31b229b"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ec11c857-840d-4bf0-81d9-e4b22444f6a4"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a7dfeac1-20f7-4098-9ddf-8b4e9e037ab5"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("3b5fc9e6-f635-4946-96d0-99a07663b06a"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("1b1d7240-335a-4137-9822-956528e4d5c8"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("79abe934-9fa1-465e-b36c-e6a83fcae767"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a7890ce-b0ce-4cb6-9467-4d2a3d591114"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("957348b6-6c6f-4f23-9005-92046516fcbf"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("8e1ae56b-f9d9-41eb-b81a-4dc38cf04d6c"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("96b21a73-14d5-4fa6-8f8d-0478e4b9b6b8"),
				ContainerUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5601149a-7688-4bb0-829b-346b4f6428e9"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,211,64,16,253,47,62,119,35,59,142,191,122,131,16,56,1,145,82,113,242,101,108,143,157,85,237,216,218,221,84,132,42,18,255,128,246,138,224,63,32,164,10,132,224,210,136,19,255,130,95,194,236,58,132,84,178,192,84,138,0,113,88,201,126,122,51,126,243,246,121,206,173,180,4,41,31,65,133,214,177,117,119,250,112,86,231,106,112,159,151,10,197,3,81,47,27,235,200,146,40,56,148,252,25,102,45,62,201,184,186,7,10,168,224,60,254,81,31,91,199,113,87,135,216,58,138,45,174,176,146,196,160,130,48,196,36,15,124,151,121,185,151,176,145,151,229,44,1,59,100,158,155,248,25,70,73,152,12,163,150,217,221,122,92,87,13,8,108,191,96,154,231,230,241,100,213,104,162,67,64,106,40,92,214,139,45,232,106,9,114,178,128,164,196,140,222,149,88,34,65,74,240,138,38,193,19,94,225,20,4,125,73,247,169,53,68,164,28,74,169,89,37,230,106,242,180,17,40,37,175,23,63,151,86,46,171,197,62,151,202,113,247,186,21,99,27,133,154,57,5,53,55,13,218,78,107,163,242,78,81,8,44,64,241,179,125,17,167,184,50,204,126,238,81,65,70,55,244,4,202,37,238,249,114,115,146,49,52,170,29,40,182,54,23,95,94,109,46,174,63,110,46,175,95,152,114,193,139,121,207,169,119,206,253,106,240,33,129,205,119,114,175,142,157,147,12,67,2,207,52,96,138,198,32,181,119,107,237,158,51,116,51,15,130,156,161,103,71,108,148,162,205,162,40,64,134,190,155,164,224,140,156,196,134,255,45,91,179,149,156,66,122,10,5,14,250,199,172,159,145,183,136,217,231,247,20,179,55,116,62,208,185,218,92,126,125,254,114,64,79,175,183,232,59,58,111,183,207,159,232,104,246,213,191,26,72,109,116,89,23,60,133,242,113,131,130,188,54,186,237,238,192,220,72,154,175,39,174,107,53,75,231,88,193,78,15,221,101,139,24,29,187,203,10,134,116,77,24,48,47,242,92,218,9,163,128,65,16,186,204,119,70,161,235,167,169,7,169,67,130,104,149,107,229,179,122,41,210,109,196,101,187,195,111,181,157,255,192,159,241,123,171,180,51,49,125,50,112,144,133,243,151,218,53,235,218,14,7,119,238,160,127,198,218,90,127,3,95,150,67,124,215,8,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("33bce745-fb67-43b6-b483-90cf9af1f475"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c1bec890-46fb-4d20-8d4a-05948010b323"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9b2c93dd-c44c-440a-9072-328f06f7b94c"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f13d3489-febd-495e-87cf-34c08df24766"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5109a2ba-50c9-44b0-8714-4102a725b645"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("82ffd8c0-e88a-4530-87aa-024e8633e4d5"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("6f04cfdc-2015-4135-b910-ee8e91e73e65"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("81e8c52d-6348-476a-919b-4c222b549563"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f54c25eb-87ff-4e05-9ea4-fa641521ef7d"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("bf35315a-7b9b-4e81-9cca-4628bc3abbe5"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("19ab1ec6-b279-4170-9439-600c31df5a4a"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("bafbaee0-2586-4010-ba1c-e98dd9e853cc"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6abdacf3-1dd7-4b36-b7bc-80b7b2a13122"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("31a337f9-edbe-45b5-995e-4c7b22eee133"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9f758c03-00f6-4843-b6eb-99c9178eaf1a"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bbc539f4-868f-49dd-9dd3-cef59500c068"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("042a250d-ce52-4489-9aa6-08ffd6f292fa"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c6ee1c80-de6f-44c3-9095-64f714ff2357"),
				ContainerUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("eb64ce85-4fbd-4226-97de-985e5b9fef59"),
				ContainerUId = new Guid("8324eaeb-dafc-4716-8d8a-e87af28697d3"),
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
				UId = new Guid("35173a57-a2e2-479f-aa27-bd861b439f14"),
				ContainerUId = new Guid("8324eaeb-dafc-4716-8d8a-e87af28697d3"),
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
				UId = new Guid("80f75966-6900-4fcd-8f09-804f82c014af"),
				ContainerUId = new Guid("8324eaeb-dafc-4716-8d8a-e87af28697d3"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{4dc83797-2f02-421a-8c91-14b4b0109539}].[Parameter:{b3e79b7f-0cf2-4db9-a3b5-50f22bd30da9}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var templateIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("86a9ca15-a29b-468f-92c9-7070bbd6f371"),
				ContainerUId = new Guid("8324eaeb-dafc-4716-8d8a-e87af28697d3"),
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
				Value = @"[#Lookup.93030575-f70f-4041-902e-c4badaf62c63.0dc0759c-80b3-48b3-a832-7e32925d748b#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(templateIdParameter);
			var sysEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9fbf2e69-990b-41f6-8ec5-c33d551a4914"),
				ContainerUId = new Guid("8324eaeb-dafc-4716-8d8a-e87af28697d3"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{d8487221-4c12-4a8e-9887-24309eafbaea}].[Parameter:{6f04cfdc-2015-4135-b910-ee8e91e73e65}].[EntityColumn:{ed98cf3e-1642-4755-acb2-a61181429306}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(sysEntitySchemaIdParameter);
		}

		protected virtual void InitializeAddEmailDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("847cacd4-6fdf-4340-890f-2d494c4c5c98"),
				ContainerUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("31e0eb82-93a1-4879-91aa-b744930a4611"),
				ContainerUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("567a0c1b-7356-49ce-93db-d58cb11abf8f"),
				ContainerUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("6a9f6041-ec7b-424a-88e3-3c868e83e490"),
				ContainerUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("91d4d62a-3cec-433d-b549-0651c8113c05"),
				ContainerUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,93,79,91,71,16,253,43,150,147,71,214,218,239,15,222,154,143,170,72,161,65,161,205,75,224,97,118,119,150,184,53,54,178,175,19,81,196,127,239,185,6,18,72,35,3,173,160,68,178,31,174,237,235,187,187,179,179,115,230,204,28,159,13,159,119,167,39,60,220,30,190,216,219,221,159,181,110,244,114,54,231,209,222,124,86,120,177,24,189,153,21,154,140,255,162,60,225,61,154,211,49,119,60,127,79,147,37,47,222,140,23,221,214,224,250,160,225,214,240,249,167,213,111,195,237,15,103,195,157,142,143,127,223,169,152,185,106,82,49,16,11,157,149,21,182,88,41,162,41,74,168,146,92,144,190,112,246,17,131,203,108,178,60,158,238,114,71,123,212,125,28,110,159,13,87,179,97,2,91,75,147,100,148,8,173,6,97,107,38,65,82,90,193,86,153,172,130,51,214,168,225,249,214,112,81,62,242,49,173,22,253,58,184,88,155,106,52,90,144,45,69,216,44,149,200,169,58,17,73,233,98,53,165,22,83,63,248,242,249,175,3,63,60,251,176,179,120,251,121,202,243,253,213,188,219,141,38,11,62,28,225,238,55,55,190,184,102,251,204,73,11,163,100,20,33,214,44,240,209,137,212,111,221,85,83,146,202,174,217,216,206,15,159,29,246,43,214,241,226,100,66,167,239,255,185,240,254,50,255,193,165,187,120,236,228,134,227,175,63,120,118,112,113,122,7,195,237,131,239,159,223,229,251,133,189,55,79,240,230,225,29,12,183,14,134,251,179,229,188,244,179,25,124,121,117,205,186,213,2,171,71,190,249,122,117,90,184,51,93,78,38,151,119,94,81,71,87,15,94,221,158,213,113,27,115,221,153,238,95,29,210,106,22,121,249,18,223,185,92,189,46,108,251,47,195,118,105,74,71,60,255,21,219,255,106,251,23,43,127,131,11,175,38,118,133,140,107,74,10,82,8,20,91,124,16,148,60,9,19,77,37,79,141,74,43,171,209,239,184,241,156,167,133,255,165,97,239,120,177,242,118,15,147,75,187,122,87,157,15,207,207,183,174,131,39,21,14,201,37,39,180,171,94,216,148,179,200,217,120,196,48,130,183,120,157,163,49,107,193,227,85,228,224,164,1,230,50,118,228,116,21,68,6,95,91,240,33,233,232,76,118,255,39,120,94,79,248,152,167,221,246,25,150,177,76,156,69,165,134,181,130,242,34,214,72,130,145,59,154,142,62,133,106,206,111,162,205,56,21,12,57,156,145,102,141,33,169,97,111,58,136,92,163,87,217,154,212,148,189,29,109,191,208,180,78,120,0,151,227,129,142,7,109,54,31,192,194,241,100,240,121,220,125,28,28,83,153,207,22,163,23,179,122,186,1,228,163,3,178,200,38,173,199,153,226,34,17,129,5,228,97,25,89,213,170,84,75,116,202,103,245,168,128,12,73,50,226,180,138,210,83,144,181,22,104,48,84,132,150,50,35,68,149,107,113,61,155,57,155,84,49,166,9,78,253,182,10,69,129,16,78,162,218,168,36,147,179,197,249,135,0,228,155,217,236,207,229,201,40,184,108,171,73,89,56,87,251,25,144,85,98,69,194,51,205,38,114,177,38,95,194,136,117,52,170,114,17,72,119,82,212,166,176,140,148,13,94,83,213,75,78,38,22,127,27,172,46,215,251,169,116,227,79,227,238,116,208,51,213,232,117,143,171,13,140,30,29,70,89,39,39,131,106,34,48,37,97,217,235,254,212,73,36,149,114,51,193,232,214,244,58,24,221,37,106,238,5,35,157,130,162,22,149,240,173,50,80,208,24,144,142,86,20,23,92,100,205,165,181,245,188,70,205,81,48,213,0,120,136,83,84,93,73,68,108,70,40,76,80,88,37,159,171,126,64,24,217,172,131,39,184,33,40,148,178,54,39,18,153,83,21,38,36,174,197,3,40,186,141,66,243,213,180,100,69,51,30,150,89,56,76,250,216,231,138,210,140,204,38,193,243,119,132,209,46,202,56,156,245,5,138,222,46,187,163,217,120,122,180,1,210,15,7,164,187,196,205,253,248,40,38,118,200,200,104,142,52,12,82,200,210,185,170,32,26,167,16,157,37,233,36,175,5,82,137,202,54,10,74,176,84,104,89,140,118,130,74,172,216,150,37,157,12,87,101,226,3,2,41,121,197,90,70,143,138,91,99,249,218,151,111,18,245,174,149,89,177,183,213,151,34,71,81,154,72,38,193,107,17,230,193,80,5,176,123,215,243,17,18,146,132,209,210,222,151,143,10,106,189,163,217,252,116,195,73,63,40,148,238,18,57,247,130,146,75,68,44,81,92,122,231,208,107,69,96,179,7,129,72,53,17,187,20,24,237,196,250,210,14,10,135,231,26,133,71,211,8,82,147,85,164,24,81,228,101,138,37,231,228,12,167,39,34,84,180,236,51,152,19,168,111,232,113,45,75,172,203,90,137,26,171,119,58,162,7,107,124,123,235,180,42,231,6,11,158,86,158,111,200,232,209,17,84,107,54,164,152,133,12,28,129,0,32,40,7,96,169,74,70,219,223,87,236,185,62,106,115,84,84,86,145,208,180,19,1,60,86,198,4,52,115,207,72,9,245,156,205,170,6,90,47,245,133,2,181,207,6,17,93,207,102,216,136,32,223,72,128,219,98,70,192,22,176,209,147,80,43,96,101,4,103,7,161,27,160,99,53,242,86,132,194,135,34,47,247,11,35,15,153,244,141,90,145,13,164,156,28,208,69,149,134,33,53,39,65,16,95,132,147,77,235,92,141,172,180,26,242,122,218,129,159,94,174,124,180,125,214,103,36,11,89,74,20,219,231,182,198,80,59,76,95,48,80,14,58,68,86,94,133,219,129,250,14,29,43,24,111,193,131,138,64,26,140,126,30,207,23,221,96,140,131,27,204,218,96,206,139,229,164,67,65,57,192,201,76,160,60,142,103,211,209,78,221,32,250,135,227,68,165,160,146,233,134,94,72,7,68,11,164,113,200,37,168,150,84,241,94,41,52,70,169,212,123,33,90,90,109,29,53,37,26,88,16,18,155,109,160,52,9,97,0,42,69,49,16,223,85,90,143,104,89,178,235,237,22,24,5,1,71,81,134,220,209,163,133,156,76,202,26,2,176,159,8,39,194,231,17,170,78,2,255,91,0,180,85,208,183,11,26,108,30,45,202,11,152,158,244,93,160,86,198,39,99,36,137,11,17,113,177,65,209,163,163,232,201,137,134,14,66,125,178,0,1,52,62,92,188,131,230,87,179,135,4,40,193,26,33,160,112,92,95,89,70,217,192,124,32,128,0,105,14,179,56,240,162,243,16,97,116,67,169,217,215,151,242,1,80,212,205,241,182,38,216,175,126,223,252,69,53,124,188,224,78,50,123,151,91,20,178,245,255,147,64,85,18,49,64,63,214,22,205,80,192,127,37,73,94,73,113,15,22,220,135,231,127,3,73,209,212,37,57,30,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("296257aa-1125-48e6-a411-79017af52a29"),
				ContainerUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
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
				UId = new Guid("7fc8f448-31d5-4d20-b2f1-eddefe530853"),
				ContainerUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
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
				UId = new Guid("4d3f858a-52c5-430f-800f-6955ea542711"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,193,110,219,48,12,253,149,66,231,58,112,109,67,169,115,107,179,108,232,97,107,128,20,187,204,61,208,54,237,8,179,45,67,146,187,101,65,254,125,148,148,122,233,96,116,217,128,97,243,73,126,120,36,31,31,201,61,43,26,208,250,3,180,200,22,236,118,253,126,35,43,51,123,43,26,131,234,157,146,67,207,46,153,70,37,160,17,223,176,244,248,170,20,230,13,24,160,128,125,246,35,62,99,139,108,42,67,198,46,51,38,12,182,154,24,20,112,157,32,231,21,206,131,60,76,175,130,36,41,203,0,162,138,7,57,242,42,225,105,8,101,204,61,115,58,245,82,182,61,40,244,21,92,242,202,61,31,118,189,37,94,17,80,56,138,208,178,59,130,177,149,160,87,29,228,13,150,244,111,212,128,4,25,37,90,234,4,31,68,139,107,80,84,201,230,145,22,34,82,5,141,182,172,6,43,179,250,218,43,212,90,200,238,117,105,205,208,118,167,92,10,199,241,247,40,38,116,10,45,115,13,102,235,18,44,65,227,236,142,148,29,156,208,155,186,86,88,131,17,79,167,58,62,227,206,145,207,51,144,2,74,26,210,71,104,6,60,41,252,178,153,37,244,198,247,228,53,184,48,37,234,237,153,13,143,166,253,170,231,136,192,254,153,124,86,198,201,14,34,78,224,147,5,124,142,231,103,198,62,221,233,251,47,29,170,77,177,197,22,188,103,143,51,66,127,2,198,252,139,125,129,243,20,33,79,131,24,210,235,32,137,226,42,200,99,76,3,206,227,40,6,40,230,37,15,15,143,94,135,208,125,3,59,39,101,52,235,66,97,33,85,121,225,230,102,63,107,175,172,69,1,205,125,143,138,198,231,204,11,167,119,239,197,210,218,182,148,148,198,139,29,77,185,41,104,5,132,161,177,159,140,159,138,209,81,90,103,54,114,80,197,241,16,180,191,198,63,186,179,127,112,63,191,125,20,147,75,121,206,154,149,255,195,10,253,237,245,56,176,195,119,147,240,164,84,202,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bfbc3d0d-9a1e-43da-adb7-89e445d1a625"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("18710cc5-5550-481e-a010-e0505fa8b2a9"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("66e99c9d-a861-41c9-9892-3b4320edcabf"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("55a48763-bffc-4c07-9950-003aefdc3654"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d00b0ee2-e935-4829-a4db-fe5abd649d41"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("39985f73-d9e1-4a6e-8cd4-a40b31d7e533"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("9c756e63-5afb-42ed-94f8-3ee3f4bf4d9d"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ea2ee12d-af13-403c-883f-817b024d86a9"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fd47a28a-0a99-4a41-8153-9064ca9dad24"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ab1d5b68-f04f-4772-8051-b480bf6acbc0"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d83f0b00-f100-417a-a588-eb7796e2396a"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4295e0df-6d0d-459b-a4fe-8ae3f18b4356"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("67446c2d-1033-4a62-98c7-f79a1d2cff50"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a65afada-0121-4d32-8046-c15726057d12"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("85c368fc-5947-409e-9f8d-423a3de5d035"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b7f41d79-3f1f-44f6-97ed-626171550655"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("eb49a7cd-d724-4167-9776-b1e3208d10e1"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a13f778c-34ec-43f9-b0b2-d3f3f94fcbd7"),
				ContainerUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaUserTask readcasedata = CreateReadCaseDataUserTask();
			FlowElements.Add(readcasedata);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			ProcessSchemaUserTask fillemailusertask = CreateFillEmailUserTaskUserTask();
			FlowElements.Add(fillemailusertask);
			ProcessSchemaScriptTask preparerecipientemails = CreatePrepareRecipientEmailsScriptTask();
			FlowElements.Add(preparerecipientemails);
			ProcessSchemaUserTask addemaildatausertask = CreateAddEmailDataUserTaskUserTask();
			FlowElements.Add(addemaildatausertask);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaScriptTask sendemailscripttask = CreateSendEmailScriptTaskScriptTask();
			FlowElements.Add(sendemailscripttask);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("57a6edbc-8a5e-418d-bf67-29dcb9cdfef0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("cb98fa26-176c-4258-957d-5f366e784589"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8324eaeb-dafc-4716-8d8a-e87af28697d3"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("5b6bbda6-2544-4984-a493-33ea3d53997e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("60f2028e-d6aa-415b-bb5b-ef027be86bcf"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("96c28b67-1288-4df0-96f5-2a55923ff807"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("60f2028e-d6aa-415b-bb5b-ef027be86bcf"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fce8a14e-9408-4274-8948-3165aeb15892"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("217c6685-36c5-4584-8a80-2f2f04b00727"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8324eaeb-dafc-4716-8d8a-e87af28697d3"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4a1291aa-8caf-4e54-8275-887b0bb550c4"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("75bdf120-c093-47fd-b23e-d52f059ec58c"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{56772c15-0da6-416b-89f3-18ff8e888563}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4a1291aa-8caf-4e54-8275-887b0bb550c4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b19e5a82-b497-469b-b25d-0c491fd8111a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(535, 332));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("8b7489eb-b116-4b26-a892-34fb88add808"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4a1291aa-8caf-4e54-8275-887b0bb550c4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fce8a14e-9408-4274-8948-3165aeb15892"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(535, 146));
			schemaFlow.PolylinePointPositions.Add(new Point(1093, 146));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("b5a3673d-f005-4df7-b7e5-edef707a8f96"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("58c9e19e-5a97-42fa-8666-4613269c9517"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow2",
				UId = new Guid("8f83be51-9c06-45ff-b8d8-dd8224eb633a"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{4dc83797-2f02-421a-8c91-14b4b0109539}].[Parameter:{b3e79b7f-0cf2-4db9-a3b5-50f22bd30da9}].[EntityColumn:{a93cb111-ce30-4da4-89ec-d2a2f3dd71c4}]#] ==[#Lookup.b17869fe-43f9-487a-af82-b7626f1fc810.7f9e1f1e-f46b-1410-3492-0050ba5d6c38#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b19e5a82-b497-469b-b25d-0c491fd8111a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(627, 407));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("bf943044-0e65-4a76-9f79-6e7bcf838238"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("eeede76c-0137-4ded-80aa-cc1cc3f876de"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("f74b17bb-0662-4a73-b5ab-e34bcda5b0bc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b19e5a82-b497-469b-b25d-0c491fd8111a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(627, 203));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("86e8cd15-190e-497b-8609-884788958143"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("eeede76c-0137-4ded-80aa-cc1cc3f876de"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("b1d52543-8143-4b41-b705-fbf73d8e80ca"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b1d52543-8143-4b41-b705-fbf73d8e80ca"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaUserTask CreateReadCaseDataUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"ReadCaseData",
				Position = new Point(171, 176),
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
				UId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"ReadDataUserTask2",
				Position = new Point(281, 176),
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
				UId = new Guid("8324eaeb-dafc-4716-8d8a-e87af28697d3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"FillEmailUserTask",
				Position = new Point(391, 176),
				SchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeFillEmailUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareRecipientEmailsScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("4a1291aa-8caf-4e54-8275-887b0bb550c4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"PrepareRecipientEmails",
				Position = new Point(501, 176),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,82,193,138,219,48,16,61,39,144,127,80,125,146,105,48,123,110,218,192,214,245,134,28,118,187,141,187,237,161,244,32,236,73,34,144,37,119,52,218,98,150,253,247,142,172,36,117,3,5,99,240,248,205,123,111,222,76,213,41,109,106,176,45,160,248,32,164,39,212,246,144,127,124,188,175,221,158,138,210,33,240,203,238,245,33,160,34,237,108,81,15,190,6,34,70,249,98,3,244,77,153,0,239,83,219,90,62,121,64,134,91,104,34,118,41,22,243,89,86,135,190,119,72,53,224,179,110,160,138,122,217,82,212,99,71,81,117,61,13,249,106,49,127,86,40,32,121,49,220,205,94,44,252,22,149,37,77,67,221,28,249,215,151,0,56,92,41,20,83,192,189,178,234,0,184,20,25,123,188,109,59,109,159,172,166,236,31,246,210,153,208,89,102,159,104,21,183,109,155,234,50,99,106,82,92,74,54,207,173,7,116,161,223,182,220,182,3,213,150,202,195,39,69,170,216,129,15,134,146,133,152,197,215,161,135,19,83,138,101,19,116,187,150,217,38,181,143,116,83,221,59,109,8,208,71,125,57,173,151,8,138,32,253,253,174,233,248,168,80,117,16,161,50,21,75,215,245,10,181,119,54,74,22,213,175,160,12,143,253,131,231,142,249,108,237,206,25,120,119,250,250,25,87,22,11,156,250,105,144,252,60,88,227,140,73,73,94,69,194,211,164,185,202,11,226,42,250,72,177,245,15,0,109,188,158,49,47,230,248,75,200,103,19,44,137,181,184,97,224,14,26,221,107,176,52,226,60,3,211,197,164,253,51,96,207,135,166,154,163,28,23,53,10,11,109,39,108,185,120,225,91,186,172,49,186,253,127,236,231,107,156,108,188,120,224,4,243,85,60,72,189,23,242,205,73,158,7,8,198,124,198,209,70,194,231,73,106,118,109,249,237,197,243,157,195,78,145,204,94,110,94,87,156,105,234,226,25,102,175,139,57,63,8,20,208,10,194,0,43,241,7,239,58,245,239,95,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddEmailDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"AddEmailDataUserTask",
				Position = new Point(831, 176),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddEmailDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("fce8a14e-9408-4274-8948-3165aeb15892"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"Terminate1",
				Position = new Point(1080, 190),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSendEmailScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("60f2028e-d6aa-415b-bb5b-ef027be86bcf"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"SendEmailScriptTask",
				Position = new Point(980, 176),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,82,193,106,195,48,12,61,55,208,127,16,57,57,16,242,3,93,7,89,154,142,28,6,99,109,63,192,139,149,98,234,216,197,118,50,194,216,191,79,54,43,235,146,157,44,75,79,122,239,89,30,185,5,222,122,57,74,63,53,2,182,80,10,81,247,92,170,29,247,252,228,208,30,185,187,20,111,216,26,43,26,177,89,39,178,3,22,242,149,209,26,169,209,232,226,25,125,227,246,200,253,96,177,214,252,93,161,96,41,97,74,55,233,54,14,59,160,22,104,211,44,131,207,117,178,154,231,1,239,226,45,104,252,128,57,100,70,153,145,144,213,93,87,17,142,216,195,126,205,4,208,23,160,114,24,89,71,114,26,91,42,37,81,251,61,1,141,157,136,175,82,220,185,159,107,240,242,80,47,80,143,44,136,34,126,231,237,16,50,165,61,15,61,213,89,58,252,17,150,230,48,83,26,165,6,238,155,176,122,105,118,89,97,75,165,139,201,97,240,211,235,203,193,116,190,160,116,39,207,131,229,113,33,149,233,123,163,79,94,42,233,37,58,186,95,167,189,84,184,67,79,83,103,111,153,195,17,251,171,226,30,27,145,223,253,133,28,210,40,232,86,37,107,233,77,41,197,244,16,152,109,128,52,252,99,44,238,99,190,138,117,98,145,190,136,142,173,155,111,156,231,195,60,121,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("58c9e19e-5a97-42fa-8666-4613269c9517"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7a0d600e-cd90-4098-b0b6-70054dbd4b49"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"StartEvent1",
				Position = new Point(80, 190),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("b19e5a82-b497-469b-b25d-0c491fd8111a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"ExclusiveGateway1",
				Position = new Point(600, 305),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"ReadDataUserTask1",
				Position = new Point(680, 380),
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
				UId = new Guid("eeede76c-0137-4ded-80aa-cc1cc3f876de"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("996dfe48-590a-43d9-a7fb-c3907c19dda5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"),
				Name = @"FormulaTask1",
				Position = new Point(831, 380),
				ResultParameterMetaPath = @"50441308-78db-4135-97ae-5d3c91b5f48f",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,221,144,189,110,131,48,20,70,95,197,74,22,162,230,34,28,95,126,165,168,3,98,96,162,106,198,136,225,130,175,19,36,48,149,161,106,171,40,239,94,43,99,30,33,235,209,119,134,243,5,231,237,185,94,154,31,203,238,212,95,121,162,194,208,184,112,27,122,250,4,170,145,39,182,107,113,203,49,233,242,44,86,16,75,133,128,156,196,144,229,82,67,122,64,67,40,123,102,165,239,94,248,32,71,19,175,236,188,210,167,113,194,137,87,200,116,128,7,214,144,163,201,64,249,173,193,206,160,206,31,74,101,215,97,253,43,231,241,123,178,197,13,117,111,34,82,18,82,163,83,64,221,17,80,20,33,48,74,213,201,52,86,168,228,189,221,182,187,176,182,154,127,27,19,108,62,171,66,108,246,226,180,186,193,94,202,121,250,34,55,44,179,13,27,167,7,75,99,125,177,179,227,146,22,222,137,227,81,68,226,93,4,47,241,128,240,217,143,118,241,246,34,69,255,68,39,120,43,154,2,0,0 }
			};
			
			return FormulaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("6eceebac-b0e5-4cc8-b022-84e50eb7f42e"),
				Name = "BPMSoft.Mail",
				Alias = "",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("fb35bbc2-5e4c-4518-a793-46d126c86da9"),
				Name = "BPMSoft.Mail.Sender",
				Alias = "",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("bab858b4-c2ef-4534-94c5-1f8e9452cf9b"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("4256f56b-80d4-4887-900e-0f587b83f100"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SendEmailToCaseGroup(userConnection);
		}

		public override object Clone() {
			return new SendEmailToCaseGroupSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb"));
		}

		#endregion

	}

	#endregion

	#region Class: SendEmailToCaseGroup

	/// <exclude/>
	public class SendEmailToCaseGroup : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SendEmailToCaseGroup process)
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

			public ReadCaseDataFlowElement(UserConnection userConnection, SendEmailToCaseGroup process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadCaseData";
				IsLogging = true;
				SchemaElementUId = new Guid("4dc83797-2f02-421a-8c91-14b4b0109539");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,143,211,48,16,253,43,171,156,215,171,124,213,73,122,131,82,80,15,176,149,186,218,11,217,195,196,158,180,22,73,29,217,238,66,169,250,223,25,39,109,233,162,10,10,23,54,151,196,47,111,222,188,25,207,236,2,209,128,181,159,160,197,96,28,188,157,127,92,232,218,221,189,87,141,67,243,193,232,77,23,220,6,22,141,130,70,125,71,57,224,83,169,220,59,112,64,1,187,242,103,124,25,140,203,75,10,101,112,91,6,202,97,107,137,65,1,73,88,100,17,231,25,139,249,104,196,210,80,134,172,74,195,140,165,128,53,240,164,40,226,52,31,152,151,165,39,186,237,192,224,144,161,23,175,251,207,135,109,231,137,17,1,162,167,40,171,215,7,48,241,22,236,116,13,85,131,146,206,206,108,144,32,103,84,75,149,224,131,106,113,14,134,50,121,29,237,33,34,213,208,88,207,106,176,118,211,111,157,65,107,149,94,255,222,90,179,105,215,231,92,10,199,211,241,96,38,236,29,122,230,28,220,170,23,152,145,169,125,239,241,205,114,105,112,9,78,61,159,91,248,130,219,158,119,93,239,40,64,210,253,60,66,179,193,179,156,47,235,152,64,231,134,114,134,244,68,48,106,185,186,178,210,83,183,254,84,108,76,96,119,36,95,165,120,209,127,204,9,124,246,192,160,113,252,44,131,207,51,123,255,117,141,102,33,86,216,194,208,177,167,59,66,127,1,78,250,227,157,192,172,64,168,10,150,64,145,179,52,78,106,86,37,88,48,206,147,56,1,16,153,228,225,254,105,240,161,108,215,192,246,241,148,110,2,22,111,12,10,109,228,205,161,109,254,69,127,34,153,139,136,199,146,65,146,215,44,173,242,156,129,0,193,48,26,69,40,68,62,202,120,72,183,236,31,127,25,122,169,4,52,247,29,26,186,236,190,217,209,229,33,125,49,221,190,13,70,107,55,20,119,106,162,119,213,123,57,14,74,30,11,164,105,136,152,204,71,64,37,2,103,85,33,19,198,11,94,11,41,163,40,242,41,246,180,221,190,211,11,189,49,226,176,81,118,88,235,127,90,216,255,176,136,127,179,93,23,231,251,154,137,125,45,211,56,123,45,147,182,15,246,63,0,115,106,193,105,58,6,0,0 })));
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

			public ReadDataUserTask2FlowElement(UserConnection userConnection, SendEmailToCaseGroup process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("d8487221-4c12-4a8e-9887-24309eafbaea");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,211,64,16,253,47,62,119,35,59,142,191,122,131,16,56,1,145,82,113,242,101,108,143,157,85,237,216,218,221,84,132,42,18,255,128,246,138,224,63,32,164,10,132,224,210,136,19,255,130,95,194,236,58,132,84,178,192,84,138,0,113,88,201,126,122,51,126,243,246,121,206,173,180,4,41,31,65,133,214,177,117,119,250,112,86,231,106,112,159,151,10,197,3,81,47,27,235,200,146,40,56,148,252,25,102,45,62,201,184,186,7,10,168,224,60,254,81,31,91,199,113,87,135,216,58,138,45,174,176,146,196,160,130,48,196,36,15,124,151,121,185,151,176,145,151,229,44,1,59,100,158,155,248,25,70,73,152,12,163,150,217,221,122,92,87,13,8,108,191,96,154,231,230,241,100,213,104,162,67,64,106,40,92,214,139,45,232,106,9,114,178,128,164,196,140,222,149,88,34,65,74,240,138,38,193,19,94,225,20,4,125,73,247,169,53,68,164,28,74,169,89,37,230,106,242,180,17,40,37,175,23,63,151,86,46,171,197,62,151,202,113,247,186,21,99,27,133,154,57,5,53,55,13,218,78,107,163,242,78,81,8,44,64,241,179,125,17,167,184,50,204,126,238,81,65,70,55,244,4,202,37,238,249,114,115,146,49,52,170,29,40,182,54,23,95,94,109,46,174,63,110,46,175,95,152,114,193,139,121,207,169,119,206,253,106,240,33,129,205,119,114,175,142,157,147,12,67,2,207,52,96,138,198,32,181,119,107,237,158,51,116,51,15,130,156,161,103,71,108,148,162,205,162,40,64,134,190,155,164,224,140,156,196,134,255,45,91,179,149,156,66,122,10,5,14,250,199,172,159,145,183,136,217,231,247,20,179,55,116,62,208,185,218,92,126,125,254,114,64,79,175,183,232,59,58,111,183,207,159,232,104,246,213,191,26,72,109,116,89,23,60,133,242,113,131,130,188,54,186,237,238,192,220,72,154,175,39,174,107,53,75,231,88,193,78,15,221,101,139,24,29,187,203,10,134,116,77,24,48,47,242,92,218,9,163,128,65,16,186,204,119,70,161,235,167,169,7,169,67,130,104,149,107,229,179,122,41,210,109,196,101,187,195,111,181,157,255,192,159,241,123,171,180,51,49,125,50,112,144,133,243,151,218,53,235,218,14,7,119,238,160,127,198,218,90,127,3,95,150,67,124,215,8,0,0 })));
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

		#region Class: FillEmailUserTaskFlowElement

		/// <exclude/>
		public class FillEmailUserTaskFlowElement : FillEmailTemplateUserTask
		{

			#region Constructors: Public

			public FillEmailUserTaskFlowElement(UserConnection userConnection, SendEmailToCaseGroup process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "FillEmailUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("8324eaeb-dafc-4716-8d8a-e87af28697d3");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordId = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
				_templateId = () => (Guid)(new Guid("0dc0759c-80b3-48b3-a832-7e32925d748b"));
				_sysEntitySchemaId = () => (Guid)(((process.ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("UId").ColumnValueName) ? process.ReadDataUserTask2.ResultEntity.GetTypedColumnValue<Guid>("UId") : Guid.Empty)));
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

		#region Class: AddEmailDataUserTaskFlowElement

		/// <exclude/>
		public class AddEmailDataUserTaskFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddEmailDataUserTaskFlowElement(UserConnection userConnection, SendEmailToCaseGroup process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddEmailDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("ff0726c2-565e-4ac8-8c9a-a57108ff3533");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Title = () => new LocalizableString((process.Subject));
				_recordDefValues_Body = () => new LocalizableString((process.FillEmailUserTask.Body));
				_recordDefValues_Type = () => (Guid)(new Guid("e2831dec-cfc0-df11-b00f-001d60e938c6"));
				_recordDefValues_MessageType = () => (Guid)(new Guid("7f6d3f94-f36b-1410-068c-20cf30b39373"));
				_recordDefValues_ActivityCategory = () => (Guid)(new Guid("8038a396-7825-e011-8165-00155d043204"));
				_recordDefValues_Sender = () => new LocalizableString((process.EmailSender));
				_recordDefValues_Case = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
				_recordDefValues_Recepient = () => new LocalizableString((process.RecipientEmails));
				_recordDefValues_IsHtmlBody = () => (bool)(true);
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Title", () => _recordDefValues_Title.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Body", () => _recordDefValues_Body.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Type", () => _recordDefValues_Type.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_MessageType", () => _recordDefValues_MessageType.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_ActivityCategory", () => _recordDefValues_ActivityCategory.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Sender", () => _recordDefValues_Sender.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Case", () => _recordDefValues_Case.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Recepient", () => _recordDefValues_Recepient.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_IsHtmlBody", () => _recordDefValues_IsHtmlBody.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<string> _recordDefValues_Title;
			internal Func<string> _recordDefValues_Body;
			internal Func<Guid> _recordDefValues_Type;
			internal Func<Guid> _recordDefValues_MessageType;
			internal Func<Guid> _recordDefValues_ActivityCategory;
			internal Func<string> _recordDefValues_Sender;
			internal Func<Guid> _recordDefValues_Case;
			internal Func<string> _recordDefValues_Recepient;
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,93,79,91,71,16,253,43,150,147,71,214,218,239,15,222,154,143,170,72,161,65,161,205,75,224,97,118,119,150,184,53,54,178,175,19,81,196,127,239,185,6,18,72,35,3,173,160,68,178,31,174,237,235,187,187,179,179,115,230,204,28,159,13,159,119,167,39,60,220,30,190,216,219,221,159,181,110,244,114,54,231,209,222,124,86,120,177,24,189,153,21,154,140,255,162,60,225,61,154,211,49,119,60,127,79,147,37,47,222,140,23,221,214,224,250,160,225,214,240,249,167,213,111,195,237,15,103,195,157,142,143,127,223,169,152,185,106,82,49,16,11,157,149,21,182,88,41,162,41,74,168,146,92,144,190,112,246,17,131,203,108,178,60,158,238,114,71,123,212,125,28,110,159,13,87,179,97,2,91,75,147,100,148,8,173,6,97,107,38,65,82,90,193,86,153,172,130,51,214,168,225,249,214,112,81,62,242,49,173,22,253,58,184,88,155,106,52,90,144,45,69,216,44,149,200,169,58,17,73,233,98,53,165,22,83,63,248,242,249,175,3,63,60,251,176,179,120,251,121,202,243,253,213,188,219,141,38,11,62,28,225,238,55,55,190,184,102,251,204,73,11,163,100,20,33,214,44,240,209,137,212,111,221,85,83,146,202,174,217,216,206,15,159,29,246,43,214,241,226,100,66,167,239,255,185,240,254,50,255,193,165,187,120,236,228,134,227,175,63,120,118,112,113,122,7,195,237,131,239,159,223,229,251,133,189,55,79,240,230,225,29,12,183,14,134,251,179,229,188,244,179,25,124,121,117,205,186,213,2,171,71,190,249,122,117,90,184,51,93,78,38,151,119,94,81,71,87,15,94,221,158,213,113,27,115,221,153,238,95,29,210,106,22,121,249,18,223,185,92,189,46,108,251,47,195,118,105,74,71,60,255,21,219,255,106,251,23,43,127,131,11,175,38,118,133,140,107,74,10,82,8,20,91,124,16,148,60,9,19,77,37,79,141,74,43,171,209,239,184,241,156,167,133,255,165,97,239,120,177,242,118,15,147,75,187,122,87,157,15,207,207,183,174,131,39,21,14,201,37,39,180,171,94,216,148,179,200,217,120,196,48,130,183,120,157,163,49,107,193,227,85,228,224,164,1,230,50,118,228,116,21,68,6,95,91,240,33,233,232,76,118,255,39,120,94,79,248,152,167,221,246,25,150,177,76,156,69,165,134,181,130,242,34,214,72,130,145,59,154,142,62,133,106,206,111,162,205,56,21,12,57,156,145,102,141,33,169,97,111,58,136,92,163,87,217,154,212,148,189,29,109,191,208,180,78,120,0,151,227,129,142,7,109,54,31,192,194,241,100,240,121,220,125,28,28,83,153,207,22,163,23,179,122,186,1,228,163,3,178,200,38,173,199,153,226,34,17,129,5,228,97,25,89,213,170,84,75,116,202,103,245,168,128,12,73,50,226,180,138,210,83,144,181,22,104,48,84,132,150,50,35,68,149,107,113,61,155,57,155,84,49,166,9,78,253,182,10,69,129,16,78,162,218,168,36,147,179,197,249,135,0,228,155,217,236,207,229,201,40,184,108,171,73,89,56,87,251,25,144,85,98,69,194,51,205,38,114,177,38,95,194,136,117,52,170,114,17,72,119,82,212,166,176,140,148,13,94,83,213,75,78,38,22,127,27,172,46,215,251,169,116,227,79,227,238,116,208,51,213,232,117,143,171,13,140,30,29,70,89,39,39,131,106,34,48,37,97,217,235,254,212,73,36,149,114,51,193,232,214,244,58,24,221,37,106,238,5,35,157,130,162,22,149,240,173,50,80,208,24,144,142,86,20,23,92,100,205,165,181,245,188,70,205,81,48,213,0,120,136,83,84,93,73,68,108,70,40,76,80,88,37,159,171,126,64,24,217,172,131,39,184,33,40,148,178,54,39,18,153,83,21,38,36,174,197,3,40,186,141,66,243,213,180,100,69,51,30,150,89,56,76,250,216,231,138,210,140,204,38,193,243,119,132,209,46,202,56,156,245,5,138,222,46,187,163,217,120,122,180,1,210,15,7,164,187,196,205,253,248,40,38,118,200,200,104,142,52,12,82,200,210,185,170,32,26,167,16,157,37,233,36,175,5,82,137,202,54,10,74,176,84,104,89,140,118,130,74,172,216,150,37,157,12,87,101,226,3,2,41,121,197,90,70,143,138,91,99,249,218,151,111,18,245,174,149,89,177,183,213,151,34,71,81,154,72,38,193,107,17,230,193,80,5,176,123,215,243,17,18,146,132,209,210,222,151,143,10,106,189,163,217,252,116,195,73,63,40,148,238,18,57,247,130,146,75,68,44,81,92,122,231,208,107,69,96,179,7,129,72,53,17,187,20,24,237,196,250,210,14,10,135,231,26,133,71,211,8,82,147,85,164,24,81,228,101,138,37,231,228,12,167,39,34,84,180,236,51,152,19,168,111,232,113,45,75,172,203,90,137,26,171,119,58,162,7,107,124,123,235,180,42,231,6,11,158,86,158,111,200,232,209,17,84,107,54,164,152,133,12,28,129,0,32,40,7,96,169,74,70,219,223,87,236,185,62,106,115,84,84,86,145,208,180,19,1,60,86,198,4,52,115,207,72,9,245,156,205,170,6,90,47,245,133,2,181,207,6,17,93,207,102,216,136,32,223,72,128,219,98,70,192,22,176,209,147,80,43,96,101,4,103,7,161,27,160,99,53,242,86,132,194,135,34,47,247,11,35,15,153,244,141,90,145,13,164,156,28,208,69,149,134,33,53,39,65,16,95,132,147,77,235,92,141,172,180,26,242,122,218,129,159,94,174,124,180,125,214,103,36,11,89,74,20,219,231,182,198,80,59,76,95,48,80,14,58,68,86,94,133,219,129,250,14,29,43,24,111,193,131,138,64,26,140,126,30,207,23,221,96,140,131,27,204,218,96,206,139,229,164,67,65,57,192,201,76,160,60,142,103,211,209,78,221,32,250,135,227,68,165,160,146,233,134,94,72,7,68,11,164,113,200,37,168,150,84,241,94,41,52,70,169,212,123,33,90,90,109,29,53,37,26,88,16,18,155,109,160,52,9,97,0,42,69,49,16,223,85,90,143,104,89,178,235,237,22,24,5,1,71,81,134,220,209,163,133,156,76,202,26,2,176,159,8,39,194,231,17,170,78,2,255,91,0,180,85,208,183,11,26,108,30,45,202,11,152,158,244,93,160,86,198,39,99,36,137,11,17,113,177,65,209,163,163,232,201,137,134,14,66,125,178,0,1,52,62,92,188,131,230,87,179,135,4,40,193,26,33,160,112,92,95,89,70,217,192,124,32,128,0,105,14,179,56,240,162,243,16,97,116,67,169,217,215,151,242,1,80,212,205,241,182,38,216,175,126,223,252,69,53,124,188,224,78,50,123,151,91,20,178,245,255,147,64,85,18,49,64,63,214,22,205,80,192,127,37,73,94,73,113,15,22,220,135,231,127,3,73,209,212,37,57,30,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "c68f5a4ead064c8388c4040d2480facb",
							"BaseElements.AddEmailDataUserTask.Parameters.RecordDefValues.Value");
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

		#region Class: ReadDataUserTask1FlowElement

		/// <exclude/>
		public class ReadDataUserTask1FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask1FlowElement(UserConnection userConnection, SendEmailToCaseGroup process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("946b9853-5134-4e65-891d-724fa41cee3d");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,193,110,219,48,12,253,149,66,231,58,112,109,67,169,115,107,179,108,232,97,107,128,20,187,204,61,208,54,237,8,179,45,67,146,187,101,65,254,125,148,148,122,233,96,116,217,128,97,243,73,126,120,36,31,31,201,61,43,26,208,250,3,180,200,22,236,118,253,126,35,43,51,123,43,26,131,234,157,146,67,207,46,153,70,37,160,17,223,176,244,248,170,20,230,13,24,160,128,125,246,35,62,99,139,108,42,67,198,46,51,38,12,182,154,24,20,112,157,32,231,21,206,131,60,76,175,130,36,41,203,0,162,138,7,57,242,42,225,105,8,101,204,61,115,58,245,82,182,61,40,244,21,92,242,202,61,31,118,189,37,94,17,80,56,138,208,178,59,130,177,149,160,87,29,228,13,150,244,111,212,128,4,25,37,90,234,4,31,68,139,107,80,84,201,230,145,22,34,82,5,141,182,172,6,43,179,250,218,43,212,90,200,238,117,105,205,208,118,167,92,10,199,241,247,40,38,116,10,45,115,13,102,235,18,44,65,227,236,142,148,29,156,208,155,186,86,88,131,17,79,167,58,62,227,206,145,207,51,144,2,74,26,210,71,104,6,60,41,252,178,153,37,244,198,247,228,53,184,48,37,234,237,153,13,143,166,253,170,231,136,192,254,153,124,86,198,201,14,34,78,224,147,5,124,142,231,103,198,62,221,233,251,47,29,170,77,177,197,22,188,103,143,51,66,127,2,198,252,139,125,129,243,20,33,79,131,24,210,235,32,137,226,42,200,99,76,3,206,227,40,6,40,230,37,15,15,143,94,135,208,125,3,59,39,101,52,235,66,97,33,85,121,225,230,102,63,107,175,172,69,1,205,125,143,138,198,231,204,11,167,119,239,197,210,218,182,148,148,198,139,29,77,185,41,104,5,132,161,177,159,140,159,138,209,81,90,103,54,114,80,197,241,16,180,191,198,63,186,179,127,112,63,191,125,20,147,75,121,206,154,149,255,195,10,253,237,245,56,176,195,119,147,240,164,84,202,5,0,0 })));
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

		public SendEmailToCaseGroup(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SendEmailToCaseGroup";
			SchemaUId = new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_isNeedSendEmail = () => { return (bool)(false); };
			_templateId = () => { return (Guid)(new Guid("0dc0759c-80b3-48b3-a832-7e32925d748b")); };
			_subject = () => { return new LocalizableString((FillEmailUserTask.Subject)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c68f5a4e-ad06-4c83-88c4-040d2480facb");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SendEmailToCaseGroup, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SendEmailToCaseGroup, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private Func<bool> _isNeedSendEmail;
		public virtual bool IsNeedSendEmail {
			get {
				return (_isNeedSendEmail ?? (_isNeedSendEmail = () => false)).Invoke();
			}
			set {
				_isNeedSendEmail = () => { return value; };
			}
		}

		public virtual string RecipientEmails {
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

		public virtual Guid CaseRecordId {
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

		public virtual string EmailSender {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
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

		private FillEmailUserTaskFlowElement _fillEmailUserTask;
		public FillEmailUserTaskFlowElement FillEmailUserTask {
			get {
				return _fillEmailUserTask ?? (_fillEmailUserTask = new FillEmailUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _prepareRecipientEmails;
		public ProcessScriptTask PrepareRecipientEmails {
			get {
				return _prepareRecipientEmails ?? (_prepareRecipientEmails = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareRecipientEmails",
					SchemaElementUId = new Guid("4a1291aa-8caf-4e54-8275-887b0bb550c4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = PrepareRecipientEmailsExecute,
				});
			}
		}

		private AddEmailDataUserTaskFlowElement _addEmailDataUserTask;
		public AddEmailDataUserTaskFlowElement AddEmailDataUserTask {
			get {
				return _addEmailDataUserTask ?? (_addEmailDataUserTask = new AddEmailDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("fce8a14e-9408-4274-8948-3165aeb15892"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _sendEmailScriptTask;
		public ProcessScriptTask SendEmailScriptTask {
			get {
				return _sendEmailScriptTask ?? (_sendEmailScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendEmailScriptTask",
					SchemaElementUId = new Guid("60f2028e-d6aa-415b-bb5b-ef027be86bcf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SendEmailScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _startEvent1;
		public ProcessFlowElement StartEvent1 {
			get {
				return _startEvent1 ?? (_startEvent1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartEvent1",
					SchemaElementUId = new Guid("58c9e19e-5a97-42fa-8666-4613269c9517"),
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
					SchemaElementUId = new Guid("b19e5a82-b497-469b-b25d-0c491fd8111a"),
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
					SchemaElementUId = new Guid("eeede76c-0137-4ded-80aa-cc1cc3f876de"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask1Execute,
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
					SchemaElementUId = new Guid("75bdf120-c093-47fd-b23e-d52f059ec58c"),
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
					SchemaElementUId = new Guid("8f83be51-9c06-45ff-b8d8-dd8224eb633a"),
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
			FlowElements[ReadCaseData.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadCaseData };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
			FlowElements[FillEmailUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { FillEmailUserTask };
			FlowElements[PrepareRecipientEmails.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareRecipientEmails };
			FlowElements[AddEmailDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AddEmailDataUserTask };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[SendEmailScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SendEmailScriptTask };
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "ReadCaseData":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FillEmailUserTask", e.Context.SenderName));
						break;
					case "FillEmailUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareRecipientEmails", e.Context.SenderName));
						break;
					case "PrepareRecipientEmails":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						Log.ErrorFormat(DeadEndGatewayLogMessage, "PrepareRecipientEmails");
						break;
					case "AddEmailDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendEmailScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "SendEmailScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadCaseData", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddEmailDataUserTask", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddEmailDataUserTask", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((IsNeedSendEmail));
			Log.InfoFormat(ConditionalExpressionLogMessage, "PrepareRecipientEmails", "ConditionalSequenceFlow1", "(IsNeedSendEmail)", result);
			return result;
		}

		private bool ConditionalSequenceFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadCaseData.ResultEntity.IsColumnValueLoaded(ReadCaseData.ResultEntity.Schema.Columns.GetByName("Origin").ColumnValueName) ? ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("OriginId") : Guid.Empty)) ==new Guid("7f9e1f1e-f46b-1410-3492-0050ba5d6c38"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow2", "((ReadCaseData.ResultEntity.IsColumnValueLoaded(ReadCaseData.ResultEntity.Schema.Columns.GetByName(\"Origin\").ColumnValueName) ? ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>(\"OriginId\") : Guid.Empty)) ==new Guid(\"7f9e1f1e-f46b-1410-3492-0050ba5d6c38\")", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("RecipientEmails")) {
				writer.WriteValue("RecipientEmails", RecipientEmails, null);
			}
			if (!HasMapping("CaseRecordId")) {
				writer.WriteValue("CaseRecordId", CaseRecordId, Guid.Empty);
			}
			if (!HasMapping("EmailSender")) {
				writer.WriteValue("EmailSender", EmailSender, null);
			}
			if (!HasMapping("IsNeedSendEmail")) {
				writer.WriteValue("IsNeedSendEmail", IsNeedSendEmail, false);
			}
			if (!HasMapping("TemplateId")) {
				writer.WriteValue("TemplateId", TemplateId, Guid.Empty);
			}
			if (!HasMapping("Subject")) {
				writer.WriteValue("Subject", Subject, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartEvent1", string.Empty));
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
			MetaPathParameterValues.Add("56772c15-0da6-416b-89f3-18ff8e888563", () => IsNeedSendEmail);
			MetaPathParameterValues.Add("7ea8c009-6542-4fdd-9572-6a844d21ab92", () => RecipientEmails);
			MetaPathParameterValues.Add("94d0d4a6-3942-434c-add8-db0c09b339ba", () => TemplateId);
			MetaPathParameterValues.Add("ce79eab9-3a98-423f-b3e9-66323aac7d60", () => CaseRecordId);
			MetaPathParameterValues.Add("50441308-78db-4135-97ae-5d3c91b5f48f", () => Subject);
			MetaPathParameterValues.Add("fb6b20e1-ef67-4e02-ae21-d8d6528daffe", () => EmailSender);
			MetaPathParameterValues.Add("4bff0fd5-1b5b-42da-97ec-43b95e6ba9cb", () => ReadCaseData.DataSourceFilters);
			MetaPathParameterValues.Add("a33f837c-29dc-4fee-a6ce-9b43656fdcf8", () => ReadCaseData.ResultType);
			MetaPathParameterValues.Add("abb94808-5aed-4a2b-91a0-b3c4e019244f", () => ReadCaseData.ReadSomeTopRecords);
			MetaPathParameterValues.Add("5c31db74-03b4-4e13-b937-a5bd1c4b9346", () => ReadCaseData.NumberOfRecords);
			MetaPathParameterValues.Add("43f58502-a3f9-4d89-8b05-bfd006634914", () => ReadCaseData.FunctionType);
			MetaPathParameterValues.Add("9bbb4181-ec2f-4b6d-9c67-a8acb3d3bb29", () => ReadCaseData.AggregationColumnName);
			MetaPathParameterValues.Add("71f14a14-3659-44b0-8b17-52639bb50b8b", () => ReadCaseData.OrderInfo);
			MetaPathParameterValues.Add("b3e79b7f-0cf2-4db9-a3b5-50f22bd30da9", () => ReadCaseData.ResultEntity);
			MetaPathParameterValues.Add("b94c3537-238d-4c55-bf91-3524d23fa348", () => ReadCaseData.ResultCount);
			MetaPathParameterValues.Add("11c9e107-95c8-4c1c-9999-e948c31b229b", () => ReadCaseData.ResultIntegerFunction);
			MetaPathParameterValues.Add("ec11c857-840d-4bf0-81d9-e4b22444f6a4", () => ReadCaseData.ResultFloatFunction);
			MetaPathParameterValues.Add("a7dfeac1-20f7-4098-9ddf-8b4e9e037ab5", () => ReadCaseData.ResultDateTimeFunction);
			MetaPathParameterValues.Add("3b5fc9e6-f635-4946-96d0-99a07663b06a", () => ReadCaseData.ResultRowsCount);
			MetaPathParameterValues.Add("1b1d7240-335a-4137-9822-956528e4d5c8", () => ReadCaseData.CanReadUncommitedData);
			MetaPathParameterValues.Add("79abe934-9fa1-465e-b36c-e6a83fcae767", () => ReadCaseData.ResultEntityCollection);
			MetaPathParameterValues.Add("0a7890ce-b0ce-4cb6-9467-4d2a3d591114", () => ReadCaseData.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("957348b6-6c6f-4f23-9005-92046516fcbf", () => ReadCaseData.IgnoreDisplayValues);
			MetaPathParameterValues.Add("8e1ae56b-f9d9-41eb-b81a-4dc38cf04d6c", () => ReadCaseData.ResultCompositeObjectList);
			MetaPathParameterValues.Add("96b21a73-14d5-4fa6-8f8d-0478e4b9b6b8", () => ReadCaseData.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("5601149a-7688-4bb0-829b-346b4f6428e9", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("33bce745-fb67-43b6-b483-90cf9af1f475", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("c1bec890-46fb-4d20-8d4a-05948010b323", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("9b2c93dd-c44c-440a-9072-328f06f7b94c", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("f13d3489-febd-495e-87cf-34c08df24766", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("5109a2ba-50c9-44b0-8714-4102a725b645", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("82ffd8c0-e88a-4530-87aa-024e8633e4d5", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("6f04cfdc-2015-4135-b910-ee8e91e73e65", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("81e8c52d-6348-476a-919b-4c222b549563", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("f54c25eb-87ff-4e05-9ea4-fa641521ef7d", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("bf35315a-7b9b-4e81-9cca-4628bc3abbe5", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("19ab1ec6-b279-4170-9439-600c31df5a4a", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("bafbaee0-2586-4010-ba1c-e98dd9e853cc", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("6abdacf3-1dd7-4b36-b7bc-80b7b2a13122", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("31a337f9-edbe-45b5-995e-4c7b22eee133", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("9f758c03-00f6-4843-b6eb-99c9178eaf1a", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("bbc539f4-868f-49dd-9dd3-cef59500c068", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("042a250d-ce52-4489-9aa6-08ffd6f292fa", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("c6ee1c80-de6f-44c3-9095-64f714ff2357", () => ReadDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("eb64ce85-4fbd-4226-97de-985e5b9fef59", () => FillEmailUserTask.Subject);
			MetaPathParameterValues.Add("35173a57-a2e2-479f-aa27-bd861b439f14", () => FillEmailUserTask.Body);
			MetaPathParameterValues.Add("80f75966-6900-4fcd-8f09-804f82c014af", () => FillEmailUserTask.RecordId);
			MetaPathParameterValues.Add("86a9ca15-a29b-468f-92c9-7070bbd6f371", () => FillEmailUserTask.TemplateId);
			MetaPathParameterValues.Add("9fbf2e69-990b-41f6-8ec5-c33d551a4914", () => FillEmailUserTask.SysEntitySchemaId);
			MetaPathParameterValues.Add("847cacd4-6fdf-4340-890f-2d494c4c5c98", () => AddEmailDataUserTask.EntitySchemaId);
			MetaPathParameterValues.Add("31e0eb82-93a1-4879-91aa-b744930a4611", () => AddEmailDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("567a0c1b-7356-49ce-93db-d58cb11abf8f", () => AddEmailDataUserTask.RecordAddMode);
			MetaPathParameterValues.Add("6a9f6041-ec7b-424a-88e3-3c868e83e490", () => AddEmailDataUserTask.FilterEntitySchemaId);
			MetaPathParameterValues.Add("91d4d62a-3cec-433d-b549-0651c8113c05", () => AddEmailDataUserTask.RecordDefValues);
			MetaPathParameterValues.Add("296257aa-1125-48e6-a411-79017af52a29", () => AddEmailDataUserTask.RecordId);
			MetaPathParameterValues.Add("7fc8f448-31d5-4d20-b2f1-eddefe530853", () => AddEmailDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("4d3f858a-52c5-430f-800f-6955ea542711", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("bfbc3d0d-9a1e-43da-adb7-89e445d1a625", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("18710cc5-5550-481e-a010-e0505fa8b2a9", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("66e99c9d-a861-41c9-9892-3b4320edcabf", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("55a48763-bffc-4c07-9950-003aefdc3654", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("d00b0ee2-e935-4829-a4db-fe5abd649d41", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("39985f73-d9e1-4a6e-8cd4-a40b31d7e533", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("9c756e63-5afb-42ed-94f8-3ee3f4bf4d9d", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("ea2ee12d-af13-403c-883f-817b024d86a9", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("fd47a28a-0a99-4a41-8153-9064ca9dad24", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("ab1d5b68-f04f-4772-8051-b480bf6acbc0", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("d83f0b00-f100-417a-a588-eb7796e2396a", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("4295e0df-6d0d-459b-a4fe-8ae3f18b4356", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("67446c2d-1033-4a62-98c7-f79a1d2cff50", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("a65afada-0121-4d32-8046-c15726057d12", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("85c368fc-5947-409e-9f8d-423a3de5d035", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("b7f41d79-3f1f-44f6-97ed-626171550655", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("eb49a7cd-d724-4167-9776-b1e3208d10e1", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("a13f778c-34ec-43f9-b0b2-d3f3f94fcbd7", () => ReadDataUserTask1.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "RecipientEmails":
					if (!hasValueToRead) break;
					RecipientEmails = reader.GetValue<System.String>();
				break;
				case "CaseRecordId":
					if (!hasValueToRead) break;
					CaseRecordId = reader.GetValue<System.Guid>();
				break;
				case "EmailSender":
					if (!hasValueToRead) break;
					EmailSender = reader.GetValue<System.String>();
				break;
				case "IsNeedSendEmail":
					if (!hasValueToRead) break;
					IsNeedSendEmail = reader.GetValue<System.Boolean>();
				break;
				case "TemplateId":
					if (!hasValueToRead) break;
					TemplateId = reader.GetValue<System.Guid>();
				break;
				case "Subject":
					if (!hasValueToRead) break;
					Subject = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool PrepareRecipientEmailsExecute(ProcessExecutingContext context) {
			EmailSender = (string)BPMSoft.Core.Configuration.SysSettings.GetValue<string>(UserConnection, 
				"SupportServiceEmail", String.Empty);
			var emailSelect = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			var emailColumn = emailSelect.AddColumn("Contact.Email");
			var groupId = ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("GroupId");
			emailSelect.Filters.Add(emailSelect.CreateFilterWithParameters(FilterComparisonType.Equal, "[SysUserInRole:SysUser].SysRole", groupId));
			var collection = emailSelect.GetEntityCollection(UserConnection);
			IsNeedSendEmail = collection.Count > 0;
			RecipientEmails = string.Empty;
			foreach(var entity in collection) {
				var email = entity.GetTypedColumnValue<string>(emailColumn.Name); 
				if (!string.IsNullOrEmpty(email)) {
					RecipientEmails += string.Format("{0};", email);
				}
			}
			return true; 
		}

		public virtual bool SendEmailScriptTaskExecute(ProcessExecutingContext context) {
			var activityId = AddEmailDataUserTask.RecordId;
			if (UserConnection.GetIsFeatureEnabled("UseAsyncEmailSender")) {
				AsyncEmailSender emailSender = new AsyncEmailSender(UserConnection);
				emailSender.SendAsync(activityId);
			} else {
				var emailClientFactory = ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection", UserConnection));
				var activityEmailSender = new ActivityEmailSender(emailClientFactory, UserConnection);
				BPMSoft.Configuration.CommonUtilities.CopyFileDetail(UserConnection, TemplateId, activityId, "EmailTemplate", "Activity", true); 
				activityEmailSender.Send(activityId);
			}
			return true;
		}

		public virtual bool FormulaTask1Execute(ProcessExecutingContext context) {
			var localSubject = (((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<string>("Title") : null))).IndexOf("RE: ", StringComparison.OrdinalIgnoreCase) == 0 ? (((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<string>("Title") : null))) : "RE: " + (((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<string>("Title") : null)));
			Subject = (System.String)localSubject;
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
			var cloneItem = (SendEmailToCaseGroup)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

