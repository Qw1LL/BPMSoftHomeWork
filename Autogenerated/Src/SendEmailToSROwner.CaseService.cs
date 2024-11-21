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
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Mail;
	using BPMSoft.Mail.Sender;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using SysSettings = BPMSoft.Core.Configuration.SysSettings;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: SendEmailToSROwnerSchema

	/// <exclude/>
	public class SendEmailToSROwnerSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SendEmailToSROwnerSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SendEmailToSROwnerSchema(SendEmailToSROwnerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SendEmailToSROwner";
			UId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698");
			CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.6.0.541";
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
			RealUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698");
			Version = 0;
			PackageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateTemplateIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e2d6e188-0536-4cbb-a47d-546de3233a1d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"TemplateId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#Lookup.93030575-f70f-4041-902e-c4badaf62c63.b47e41c6-94d0-4d02-8531-4054c157c2ac#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a7d24a5a-b023-47ad-be9a-c28a39a5ae4f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"SenderEmail",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSubjectParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c4cbc9bd-932f-4649-87a1-e88804fb12c1"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"Subject",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCaseRecordIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7ebb67ae-b1e9-459b-b25c-d3ca6c2d1b78"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"CaseRecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b}].[Parameter:{021d04f3-0d96-4292-a469-49763741f632}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateIsCloseAndExitParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("57bee078-709b-4064-8102-a8d287b5ba04"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"IsCloseAndExit",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateTemplateIdParameter());
			Parameters.Add(CreateSenderEmailParameter());
			Parameters.Add(CreateSubjectParameter());
			Parameters.Add(CreateCaseRecordIdParameter());
			Parameters.Add(CreateIsCloseAndExitParameter());
		}

		protected virtual void InitializeStartSignal1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c046b569-c1d5-44ee-bef5-2f0c073b6e8d"),
				ContainerUId = new Guid("e6d9f080-86f6-4f00-a466-f201ef6be795"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e6d9f080-86f6-4f00-a466-f201ef6be795"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
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
				UId = new Guid("85939570-5e97-434a-8ec4-3e328c887084"),
				ContainerUId = new Guid("e6d9f080-86f6-4f00-a466-f201ef6be795"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e6d9f080-86f6-4f00-a466-f201ef6be795"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"117d32f9-8275-4534-8411-1c66115ce9cd",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeStartSignal2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fae2fcb8-9ebc-4d88-a763-51a8fd7fa007"),
				ContainerUId = new Guid("6d7c2bd5-2207-47e5-a6d9-083e2d7ae1dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6d7c2bd5-2207-47e5-a6d9-083e2d7ae1dd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
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
				UId = new Guid("df23ea66-cd2f-4c48-a92d-7b123685cf55"),
				ContainerUId = new Guid("6d7c2bd5-2207-47e5-a6d9-083e2d7ae1dd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6d7c2bd5-2207-47e5-a6d9-083e2d7ae1dd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"117d32f9-8275-4534-8411-1c66115ce9cd",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9fe73c5e-c65c-4dc9-8a14-32ddee1d2062"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,77,111,211,64,16,253,43,145,207,108,181,182,215,235,117,110,80,2,234,1,90,209,170,23,210,195,236,238,108,98,225,47,173,157,66,137,242,223,25,219,105,104,171,180,4,36,68,145,154,75,236,209,204,236,155,89,191,247,214,129,41,160,109,63,66,137,193,52,120,115,246,225,188,118,221,209,187,188,232,208,191,247,245,170,9,94,5,45,250,28,138,252,59,218,49,62,179,121,247,22,58,160,130,245,252,103,253,60,152,206,247,117,152,7,175,230,65,222,97,217,82,6,21,184,68,103,41,104,206,100,42,4,19,86,0,211,6,129,33,143,67,149,88,17,243,44,28,51,247,183,62,174,203,6,60,142,39,12,205,221,240,120,113,211,244,137,33,5,204,144,146,183,117,181,13,198,61,132,118,86,129,46,208,210,123,231,87,72,161,206,231,37,77,130,23,121,137,103,224,233,164,190,79,221,135,40,201,65,209,246,89,5,186,110,246,173,241,216,182,121,93,61,13,173,88,149,213,221,92,42,199,221,235,22,12,31,16,246,153,103,208,45,135,6,39,4,106,51,96,124,189,88,120,92,64,151,95,223,133,240,5,111,134,188,195,118,71,5,150,238,231,18,138,21,222,57,243,254,28,199,208,116,227,56,227,241,148,224,243,197,242,192,73,119,219,250,213,176,17,5,155,219,228,131,58,238,197,31,73,10,94,247,129,177,199,237,227,60,248,124,210,158,126,173,208,159,155,37,150,48,110,236,234,136,162,15,2,179,2,75,172,186,233,26,165,205,28,87,156,41,233,36,19,142,115,6,66,74,230,34,30,162,147,26,211,44,217,80,193,14,208,116,109,184,144,58,145,25,51,161,77,152,16,136,76,163,75,88,228,184,225,105,172,37,42,187,185,26,129,231,109,83,192,205,229,14,223,197,18,39,6,90,156,44,161,157,104,196,106,66,211,231,139,10,237,164,171,39,117,15,253,232,19,154,218,219,237,45,244,127,84,103,140,48,153,52,130,133,97,202,153,0,227,24,168,12,89,38,149,130,216,165,6,156,166,143,134,126,84,147,169,20,93,170,50,166,66,19,211,76,6,153,210,113,196,44,141,39,149,150,9,234,23,78,61,194,169,195,118,247,194,169,167,56,37,109,106,34,77,220,136,34,158,50,145,98,194,128,104,198,184,138,49,178,41,96,104,237,3,78,57,192,200,25,173,88,134,218,144,148,41,197,32,149,49,75,66,80,206,166,14,56,79,31,227,212,113,207,39,168,236,72,159,137,241,72,138,109,247,210,72,24,206,5,199,136,197,113,74,108,79,120,76,108,143,19,22,71,74,39,156,67,232,112,75,163,158,71,69,189,200,13,20,167,13,122,146,224,65,2,195,253,214,113,207,115,122,113,242,117,221,141,235,217,73,91,15,115,192,114,251,169,73,27,103,58,33,38,135,189,254,8,158,32,163,213,208,151,23,41,145,161,139,108,40,18,2,67,158,219,235,223,121,189,242,102,235,115,237,104,182,127,100,163,255,192,30,127,199,243,246,186,206,33,62,242,223,122,196,223,85,248,151,235,126,102,242,117,98,159,137,18,109,130,205,15,106,19,59,52,240,11,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("faf88bc7-9ec3-474f-85c3-47d19c91dd4c"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("87c61dbc-e2fe-4c1d-a939-228b0714856a"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("489aeb16-3e43-4075-8bb1-f85b63fd422a"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bc13a1cb-f6d2-48da-8094-9471e8db4dc6"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c395b470-4a8b-4af1-9692-e47f4c846c96"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("38b53574-4673-4dd1-93d8-83f1e4d170ed"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("021d04f3-0d96-4292-a469-49763741f632"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d1a08149-aeef-49fe-8363-1b80aad76636"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f4318b8e-a4ba-4399-bb71-48847b675f4d"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("eda4e7cd-cb31-419b-ad36-22a6022aa70d"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("655b9008-70a9-4c03-a04d-b2f308450e34"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("25e0fa4b-970d-43dd-b80e-b2a2625e0dd3"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("bf24a190-2262-4aa4-b32e-c6169bca3b2f"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(canReadUncommitedDataParameter);
			var resultEntityCollectionParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("014d404c-3972-44b9-a7b0-4e7fca6be3b6"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7be14a6d-bf83-44ed-a78c-1601116baefd"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f4e0fd1b-8be5-40bd-9ac3-e85c039c4f9f"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(ignoreDisplayValuesParameter);
			var resultCompositeObjectListParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ddb3398e-58cd-4e8c-9e32-678df8172a66"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c4e67b30-1c3b-463c-a33c-d95308105c66"),
				ContainerUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("70b11618-c71a-4155-8014-3a53fd5cd1c8"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,212,48,16,253,43,171,156,235,42,137,29,39,222,91,41,11,234,1,90,209,170,151,46,7,199,30,111,45,242,37,219,91,88,86,251,223,25,39,237,210,162,21,44,92,64,34,39,231,233,205,204,155,207,109,162,26,233,253,123,217,66,50,79,94,93,189,187,238,77,56,125,99,155,0,238,173,235,215,67,114,146,120,112,86,54,246,43,232,9,95,104,27,94,203,32,209,96,187,252,110,191,76,230,203,67,30,150,201,201,50,177,1,90,143,12,52,168,88,37,40,19,21,169,121,170,9,99,2,136,168,104,74,104,45,10,97,50,77,115,200,39,230,97,215,231,125,59,72,7,83,132,209,185,25,159,55,155,33,18,51,4,212,72,177,190,239,30,65,26,37,248,69,39,235,6,52,254,7,183,6,132,130,179,45,102,2,55,182,133,43,233,48,82,244,211,71,8,73,70,54,62,178,26,48,97,241,101,112,224,189,237,187,159,75,107,214,109,247,156,139,230,176,255,125,20,147,142,10,35,243,74,134,251,209,193,5,138,218,141,26,207,86,43,7,43,25,236,195,115,9,159,96,51,242,142,171,29,26,104,236,207,173,108,214,240,44,230,203,60,206,229,16,166,116,166,240,72,112,118,117,127,100,166,251,106,253,42,217,28,193,225,137,124,148,199,131,250,115,142,224,67,4,38,31,79,207,101,114,119,225,47,63,119,224,174,213,61,180,114,170,216,199,83,68,127,0,22,13,180,208,133,249,182,86,134,2,148,134,240,202,20,132,25,37,137,100,181,38,160,51,149,149,133,160,170,170,119,104,176,23,52,223,166,121,166,83,102,40,73,181,224,132,229,34,71,19,46,8,19,37,167,37,203,12,167,121,52,89,116,193,134,205,52,5,243,109,153,242,60,213,105,74,128,129,36,172,210,25,17,70,43,194,138,50,55,74,87,154,101,24,104,74,215,250,161,145,155,219,125,86,31,64,234,153,146,30,102,177,18,184,78,206,135,89,92,162,89,111,102,88,225,117,19,108,183,154,225,24,53,160,98,31,79,207,176,234,171,14,96,244,23,27,138,94,100,65,75,109,68,73,40,205,112,92,120,154,147,186,172,106,66,89,38,105,81,43,154,25,28,151,93,252,226,124,244,43,171,100,115,57,128,195,249,27,251,159,30,222,155,23,11,23,59,227,250,62,76,245,222,247,245,188,239,130,84,97,148,243,52,190,138,87,218,232,218,144,162,172,177,34,28,155,32,160,160,132,86,156,115,99,106,153,81,133,122,240,230,196,172,175,251,181,83,143,123,238,167,99,243,71,103,228,47,156,135,223,217,249,131,91,119,204,30,253,103,59,114,161,255,157,153,222,37,187,111,224,193,107,120,58,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("67dd077f-eb7e-455c-bd25-7a2739501199"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("920a67b6-1c8c-4f36-a894-356d4b59f1df"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d32b69b8-da12-4d43-9e3f-b871199dc2ac"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5ef8e651-f0f6-44c6-bd11-f287de677557"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ff3266dd-6661-4954-9be1-753c4436c33c"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f4581450-6bde-48e5-8aeb-24e01a3f6cb3"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("5719453e-2032-4300-a9bf-e4208bede94d"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("76dd0aac-acbd-4d32-bed0-d30d3e00b7bf"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("485e921a-c9c1-4491-88dc-28252e30e587"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("250b6f40-ea89-421d-b1a1-885362269881"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4a2e7dfa-30ae-4c59-b872-15ea611cc23d"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e7d5edde-50a9-47cf-b4d3-02ad39fbec6a"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("984c8a1b-a1b9-4152-ae3f-a823be19b2fc"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2d33dda1-70ec-434d-8bf0-4a150a70b973"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e4e926dc-1916-4d49-b91e-d1b3b9ee27f6"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6e2df57d-caef-4ef7-9bda-a15c8fe5861b"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("416fa2d3-de4d-44d5-9978-c81f98f5e3f1"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f082c002-fcd5-4525-b652-643120eef8b6"),
				ContainerUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e4f314d3-291c-45de-a2c4-0bb7a7a4a043"),
				ContainerUId = new Guid("96510c7e-efc0-4848-a44e-7ccf55d9b17a"),
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
				UId = new Guid("fd3e36ce-30b6-4382-a169-07ea62f57648"),
				ContainerUId = new Guid("96510c7e-efc0-4848-a44e-7ccf55d9b17a"),
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
				UId = new Guid("4becebac-6618-4cf8-acff-5399dc9ef219"),
				ContainerUId = new Guid("96510c7e-efc0-4848-a44e-7ccf55d9b17a"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b}].[Parameter:{021d04f3-0d96-4292-a469-49763741f632}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var templateIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8ada520f-9328-4d23-8e28-7cd84ab83abd"),
				ContainerUId = new Guid("96510c7e-efc0-4848-a44e-7ccf55d9b17a"),
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
				Value = @"[#Lookup.93030575-f70f-4041-902e-c4badaf62c63.b47e41c6-94d0-4d02-8531-4054c157c2ac#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(templateIdParameter);
			var sysEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("19997124-7bc1-4d68-91c0-f2a7263fc478"),
				ContainerUId = new Guid("96510c7e-efc0-4848-a44e-7ccf55d9b17a"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{6a3f340b-79dd-4dc2-8779-5140388e5320}].[Parameter:{492ae6cd-2386-4f94-b3dc-ecfe0a561e90}].[EntityColumn:{ed98cf3e-1642-4755-acb2-a61181429306}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(sysEntitySchemaIdParameter);
		}

		protected virtual void InitializeReadDataUserTask3Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("09d4d948-3e28-4f04-9934-8ff03d3aee8c"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,193,142,211,48,16,253,151,156,215,171,54,206,38,205,222,160,20,78,64,165,172,56,229,50,177,39,169,181,78,29,217,206,138,178,234,191,99,59,109,105,165,8,82,164,10,16,183,248,233,205,228,205,243,243,188,70,76,130,49,159,160,197,232,49,122,187,254,88,168,218,222,191,23,210,162,254,160,85,223,69,119,145,65,45,64,138,111,200,7,124,197,133,125,7,22,92,193,107,249,163,190,140,30,203,177,14,101,116,87,70,194,98,107,28,195,21,164,57,231,73,206,18,146,212,57,146,4,23,140,228,105,202,8,198,57,171,227,52,171,170,52,27,152,227,173,151,170,237,64,227,240,135,208,188,14,159,79,187,206,19,231,14,96,129,34,140,218,30,64,234,37,152,213,22,42,137,220,157,173,238,209,65,86,139,214,77,130,79,162,197,53,104,247,39,223,71,121,200,145,106,144,198,179,36,214,118,245,181,211,104,140,80,219,159,75,147,125,187,61,231,186,114,60,29,15,98,102,65,161,103,174,193,110,66,131,161,211,62,168,124,211,52,26,27,176,226,229,92,196,51,238,2,115,154,123,174,128,187,27,250,2,178,199,51,95,46,39,89,66,103,135,129,142,2,28,69,139,102,51,113,218,147,99,191,26,56,118,96,119,36,79,234,56,58,65,188,112,224,139,7,66,209,18,140,247,108,239,93,75,19,204,48,166,148,208,42,171,73,18,115,78,114,58,127,32,244,97,65,83,58,207,18,200,249,255,150,169,98,103,214,192,158,161,193,251,43,226,53,201,200,171,227,117,41,228,223,140,153,183,79,170,70,48,144,159,59,212,206,193,160,123,54,30,131,139,252,164,126,98,165,108,193,54,216,194,73,143,187,161,1,9,58,142,87,0,21,171,56,230,149,127,220,41,73,22,51,74,42,62,175,8,77,49,225,60,131,108,145,51,39,200,45,102,175,188,80,189,102,135,224,154,97,35,255,214,174,253,3,121,191,110,49,142,38,102,74,6,110,178,70,254,82,187,138,221,200,155,191,185,115,55,125,25,251,104,255,29,234,2,71,128,165,8,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fc417be0-069a-44c3-9150-0bb0efc91d55"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("58f21f7f-2f16-4ac7-8ac8-ce14b47deace"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a030b9d0-e7a0-4ced-bbbe-9539dfb1dd22"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3825a909-209e-4923-923d-23603fc8a105"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("702fea70-3f23-4480-8b9f-b553d0a194a6"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9bcb9ea2-2f79-4c66-be40-60fc89827613"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("492ae6cd-2386-4f94-b3dc-ecfe0a561e90"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2fabbf13-01ca-42c6-9f0d-07f14a79d614"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("96c84c00-2797-4646-a698-7f02695068c7"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6356bc10-9b8b-4a7c-b5e7-8b18ccb8d4cd"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c5c8881b-1545-4573-bffe-420faeaa97bc"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("64c177fe-eb36-4a4b-b7ae-91f33fcd1623"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("18bfd995-e4af-4ba7-9844-31322fbc7da7"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(canReadUncommitedDataParameter);
			var resultEntityCollectionParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("753cf6dc-9ea4-44fd-adc1-48898e488426"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e8af8fcc-bceb-41bc-99dd-9e7f54a2cc6e"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55390786-dd46-43fb-add4-4f851434760e"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(ignoreDisplayValuesParameter);
			var resultCompositeObjectListParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4fbec98f-004d-4f1f-87a7-b668063d0884"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("de308fad-dcf4-42c5-832a-534722bee38f"),
				ContainerUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a244c08e-bd09-4ca7-8a99-1077520a1ec5"),
				ContainerUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("31b660b1-300f-4f12-a4b2-98efc57cd867"),
				ContainerUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("441998e4-8821-4d10-8a9c-40c050c8dd78"),
				ContainerUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("dde1dd64-30a8-4ef6-b1d1-6d6d6661ac9b"),
				ContainerUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1d10b34a-77ec-4277-99b6-ce89fe7cd27d"),
				ContainerUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,217,110,91,201,17,253,21,130,51,64,94,84,68,239,139,222,102,113,16,1,118,198,176,146,121,177,252,80,221,93,109,51,161,72,131,188,26,67,17,244,239,57,151,146,198,203,24,52,149,64,138,141,144,128,68,220,203,94,170,187,235,212,57,85,125,53,253,126,184,124,43,211,227,233,143,207,159,157,174,250,48,251,105,181,150,217,243,245,170,202,102,51,123,186,170,188,152,255,139,203,66,158,243,154,207,101,144,245,175,188,184,144,205,211,249,102,56,154,124,216,105,122,52,253,254,183,237,111,211,227,151,87,211,147,65,206,255,126,210,48,178,107,138,83,231,70,189,187,76,46,228,78,41,233,74,62,105,41,94,57,103,83,66,231,186,90,92,156,47,159,201,192,207,121,120,51,61,190,154,110,71,219,14,80,187,98,171,41,246,22,201,181,194,196,74,57,18,167,109,209,209,91,103,245,244,250,104,186,169,111,228,156,183,147,190,239,92,157,203,45,89,67,236,106,37,87,148,166,146,155,167,196,218,84,103,56,247,148,199,206,183,237,223,119,124,249,221,203,147,205,47,239,150,178,62,221,142,123,220,121,177,145,87,51,188,253,228,197,239,91,115,124,85,93,45,53,151,70,217,154,142,181,98,193,41,178,38,73,41,41,215,11,230,212,215,175,190,123,53,206,216,230,155,183,11,190,252,245,143,19,159,94,148,127,72,29,110,154,189,253,104,227,63,108,120,117,118,115,122,103,211,227,179,207,159,223,237,247,141,189,31,159,224,199,135,119,54,61,58,155,158,174,46,214,117,28,205,226,225,231,15,172,219,78,176,109,242,201,227,221,105,225,205,242,98,177,184,125,243,51,15,124,215,240,238,245,170,205,251,92,218,201,242,244,238,144,182,163,168,219,15,125,230,223,221,231,198,182,255,166,219,51,94,242,107,89,255,21,203,127,111,251,239,86,254,13,91,120,55,176,175,108,125,215,138,88,195,81,92,13,145,56,7,38,155,108,227,192,157,107,175,219,222,47,164,203,90,150,85,254,67,195,94,200,102,187,219,35,76,110,237,26,183,234,122,122,125,125,244,33,120,130,104,199,94,51,85,30,29,74,23,79,108,57,82,137,61,231,28,149,169,54,236,4,143,119,89,87,107,59,73,54,0,79,229,68,236,99,166,230,146,86,194,222,85,31,30,2,60,79,87,171,127,94,188,157,69,95,92,179,185,144,247,109,28,161,5,74,13,251,107,17,11,216,167,150,67,141,51,49,201,234,38,149,176,187,138,90,215,152,70,169,142,93,211,45,40,201,54,213,240,37,204,220,206,247,67,29,230,191,205,135,203,201,8,140,217,147,115,158,47,14,48,122,116,24,21,147,189,138,186,83,20,70,200,151,96,198,83,103,202,58,151,110,35,98,99,55,187,96,180,143,215,220,11,70,221,217,102,84,27,71,104,134,92,52,176,197,212,66,186,91,83,69,139,246,69,237,132,81,208,73,162,87,150,18,40,135,156,55,141,152,45,30,123,12,49,155,228,109,241,255,75,14,122,178,144,115,89,14,199,87,57,120,173,106,20,146,17,75,46,57,224,221,57,161,88,107,199,110,102,16,38,95,127,76,90,189,89,177,161,10,89,85,2,129,142,97,168,14,153,20,78,47,152,238,99,112,233,203,164,245,23,94,182,133,76,176,229,104,48,200,164,175,214,19,88,56,95,76,222,205,135,55,147,115,174,235,213,102,246,227,170,93,30,0,249,232,128,172,170,43,23,70,2,8,6,94,81,224,26,201,137,167,236,116,110,53,121,29,138,126,84,94,51,61,58,72,183,134,104,159,45,185,30,183,182,120,106,57,121,37,166,89,237,119,139,66,111,138,14,210,18,5,16,52,120,77,65,115,165,132,5,22,78,181,148,236,173,228,175,68,20,114,108,6,36,206,32,53,131,181,70,72,225,34,25,148,110,18,91,196,51,22,215,247,16,133,178,108,178,254,211,230,6,84,7,12,61,58,134,90,43,150,181,200,24,23,19,210,16,144,90,137,160,183,166,4,236,48,10,150,210,30,23,67,53,234,20,75,165,16,141,135,54,180,1,30,6,122,107,236,64,103,61,74,177,113,39,134,84,45,126,36,99,74,106,228,10,205,5,218,16,52,157,216,171,172,157,229,156,202,87,65,106,136,93,205,167,212,161,90,61,216,183,140,179,138,2,97,177,70,162,53,10,196,146,63,33,53,31,117,118,8,2,100,20,90,59,139,141,102,136,15,36,141,70,165,34,77,178,107,99,151,39,203,1,114,241,167,237,30,29,95,181,210,141,50,163,18,117,206,1,170,144,32,165,118,71,45,137,47,58,5,107,212,30,249,219,11,225,54,89,141,43,156,52,120,210,236,207,243,245,102,152,204,113,112,147,85,159,172,101,115,177,24,230,203,215,19,156,204,2,121,222,124,181,60,40,213,207,163,243,255,143,24,187,164,138,40,147,73,138,2,175,181,109,194,7,165,170,148,183,65,3,157,42,230,221,213,146,88,81,48,113,145,146,55,208,222,136,78,196,161,51,117,3,52,23,163,106,211,246,171,0,53,128,101,69,98,167,144,58,194,87,175,40,235,64,234,147,52,93,33,13,178,173,169,124,2,106,101,116,67,25,197,146,66,10,64,206,228,209,80,40,85,151,99,176,16,20,29,0,253,35,168,199,80,225,144,217,3,212,121,156,72,144,212,219,220,16,61,74,52,49,137,14,58,238,9,234,202,27,217,27,211,39,237,192,210,223,92,234,169,117,108,104,132,186,157,129,38,5,131,56,4,4,20,36,116,13,65,107,95,37,215,118,47,64,103,120,153,235,236,9,172,37,32,89,228,144,197,234,66,22,226,33,170,108,59,254,118,2,154,187,231,104,155,5,147,129,152,28,2,19,37,44,134,180,143,48,71,231,80,154,121,192,10,142,43,38,6,70,6,30,1,75,140,0,225,10,245,10,244,196,44,173,6,212,104,76,159,197,30,154,237,217,81,183,1,150,97,149,164,66,170,48,25,32,87,197,102,236,252,158,21,156,103,40,88,226,172,111,10,56,191,92,12,175,87,128,213,1,72,223,28,144,246,241,155,123,1,169,193,28,167,112,13,192,90,35,141,202,78,65,155,21,67,217,55,86,5,248,76,95,0,82,77,26,64,140,168,198,43,224,207,89,136,102,174,169,97,89,142,77,182,224,29,155,30,16,72,57,104,129,246,12,176,223,96,250,6,209,81,212,72,72,48,94,2,242,137,90,213,44,41,59,38,133,216,181,4,243,96,168,6,216,131,31,75,161,168,222,40,24,173,220,125,75,161,21,229,152,215,171,245,229,65,100,126,163,80,218,199,115,238,151,57,70,239,139,207,149,108,141,72,101,123,0,168,138,70,244,78,141,141,199,157,66,231,190,19,74,73,117,160,5,38,68,212,238,81,101,244,16,153,62,160,74,107,58,202,49,99,13,70,61,64,230,56,172,241,181,195,245,239,126,63,92,153,61,162,115,103,20,141,125,233,137,84,239,56,77,112,63,174,60,113,193,100,198,68,59,70,238,89,197,71,205,160,106,71,253,195,160,14,98,12,234,139,78,183,12,193,133,154,54,178,168,154,217,20,167,28,239,206,160,178,245,112,197,177,188,131,226,10,238,167,43,177,193,0,209,148,6,7,143,65,170,123,64,158,232,182,235,152,112,75,222,11,110,25,156,13,29,216,202,10,87,202,33,196,170,36,5,231,102,65,217,50,94,72,82,208,42,222,240,4,7,23,72,7,76,94,25,225,33,169,61,121,98,123,73,54,57,29,120,184,216,204,126,120,199,243,49,143,57,8,174,237,231,91,98,137,125,252,230,75,64,122,117,253,111,190,45,101,230,18,34,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b80339a8-820c-40b9-aa5e-7542914dc2df"),
				ContainerUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
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
				UId = new Guid("94e9a24c-27da-4f2f-898d-31e395dc6cc2"),
				ContainerUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
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

		protected virtual void InitializeReadDataUserTask4Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("977cad3d-2c65-430b-8902-f756c05291e4"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,115,218,48,16,253,43,25,159,227,140,63,192,6,110,41,165,29,14,109,152,33,211,75,204,97,37,173,65,83,219,242,72,34,45,101,252,223,187,178,193,161,41,164,105,47,205,201,246,243,211,211,238,219,183,123,143,23,96,204,103,40,209,155,120,239,22,159,150,42,183,55,31,100,97,81,127,212,106,91,123,215,158,65,45,161,144,63,80,116,248,76,72,251,30,44,208,129,125,246,116,62,243,38,217,57,133,204,187,206,60,105,177,52,196,160,3,121,40,146,81,44,2,159,241,4,252,193,48,76,124,54,20,177,159,198,35,145,178,40,76,68,238,180,46,74,207,171,78,188,213,205,219,215,251,93,237,56,3,2,184,42,107,208,210,168,234,0,198,238,118,51,171,128,21,40,232,219,234,45,18,100,181,44,169,9,188,151,37,46,64,211,37,78,71,57,136,72,57,20,198,177,10,204,237,236,123,173,209,24,169,170,151,170,154,170,98,91,86,167,92,58,142,253,231,161,152,160,173,208,49,23,96,55,173,192,20,12,253,105,218,42,111,215,107,141,107,176,242,241,180,136,175,184,107,153,175,51,142,14,8,26,206,23,40,182,120,184,53,12,126,107,101,10,181,237,58,58,86,64,20,141,57,106,172,56,46,249,6,75,232,123,124,34,200,245,230,68,196,13,244,225,162,35,189,171,127,50,37,34,176,62,146,95,242,184,87,60,219,101,148,16,248,232,128,78,227,248,154,121,15,115,115,247,173,66,221,181,213,249,186,186,33,244,25,208,235,79,246,41,50,150,164,128,62,11,113,76,94,143,153,207,162,33,247,69,204,33,225,145,8,89,58,106,86,93,29,210,212,5,236,218,82,122,187,174,52,114,165,197,213,92,180,28,247,160,63,108,136,144,230,163,192,143,153,160,9,6,140,251,227,84,112,159,13,198,33,19,41,12,162,196,101,161,105,86,141,11,68,161,214,146,67,113,87,163,134,195,180,130,243,105,254,101,13,156,15,90,41,251,108,138,183,156,114,37,45,101,233,36,83,116,27,109,184,179,114,169,182,154,99,183,90,166,91,237,127,90,218,255,176,145,127,183,102,23,66,252,154,88,190,149,200,205,197,91,138,83,227,53,63,1,59,250,80,253,71,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9c6f141c-5da9-4856-8b61-9f48b7911781"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4e3be632-b70c-4b4c-8308-380d8171b89f"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a4a0e571-6551-46d8-9aa9-dd1afda8956c"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e3c26302-9b0d-4a54-8335-90d353b47af9"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3be3fe2d-ee9f-45c2-915c-ea7ebe38b5e3"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9f627d7b-d9c3-4a70-aa62-1e7d41fa025c"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("d5304989-02e5-4d55-9d1d-091d6ef8ca92"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1217e6ca-8d64-4667-ae20-c8be0b49ba25"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("48649703-f62f-4c0f-a38e-076044d6d4b2"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fd373003-c24e-424c-b3c5-56117473ca44"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2b34f769-63d0-497e-ba58-140a71c665cd"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("dcbdb688-b666-4348-9e82-b8f414a14ff9"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("97d4b158-03da-42e6-8e2d-9c1391a6e264"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("23ad489e-59f4-4704-a50f-89d316ef79aa"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("07605453-95da-4cae-bb85-94983ae46c6d"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4df5accf-b45e-4785-839d-c9360472a236"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("dd5564ee-277d-43ad-bbc6-bf73ebd13b2e"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5b165516-cbae-4f7a-b065-9fbf5cb28241"),
				ContainerUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaStartSignalEvent startsignal2 = CreateStartSignal2StartSignalEvent();
			FlowElements.Add(startsignal2);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			ProcessSchemaUserTask fillemailusertask = CreateFillEmailUserTaskUserTask();
			FlowElements.Add(fillemailusertask);
			ProcessSchemaUserTask readdatausertask3 = CreateReadDataUserTask3UserTask();
			FlowElements.Add(readdatausertask3);
			ProcessSchemaUserTask adddatausertask1 = CreateAddDataUserTask1UserTask();
			FlowElements.Add(adddatausertask1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask readdatausertask4 = CreateReadDataUserTask4UserTask();
			FlowElements.Add(readdatausertask4);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaScriptTask scripttask2 = CreateScriptTask2ScriptTask();
			FlowElements.Add(scripttask2);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow2ConditionalFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("aa5ade14-1be3-4e08-ac39-209a6b873b1c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(154, 146),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e6d9f080-86f6-4f00-a466-f201ef6be795"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("94bba729-c06a-4c0c-954a-a363bb53f98a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("a758c66e-b1b6-431b-9ce4-e115f3479d9c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(156, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6d7c2bd5-2207-47e5-a6d9-083e2d7ae1dd"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("94bba729-c06a-4c0c-954a-a363bb53f98a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(83, 192));
			schemaFlow.PolylinePointPositions.Add(new Point(83, 93));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow4",
				UId = new Guid("5ebcb3b3-95e2-4b52-b11b-1cd548bd659e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(504, 190),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("33ec13b0-6c8a-4620-8921-30f51798762c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("a7874379-205f-41fe-96f1-309febd80697"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{046d588f-d451-4b32-ae0e-3a1932e938b9}].[Parameter:{5719453e-2032-4300-a9bf-e4208bede94d}].[EntityColumn:{dbf202ec-c444-479b-bcf4-d8e5b1863201}]#] != string.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(329, 163),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("bb807e9b-583c-4859-9c29-095a70d66f33"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(402, 267),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("96510c7e-efc0-4848-a44e-7ccf55d9b17a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("b27c22ab-0638-4e97-9349-352e005e3609"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(510, 266),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("96510c7e-efc0-4848-a44e-7ccf55d9b17a"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("79a25b3e-6735-442d-b68f-a2544aeea005"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("69b7d2e9-299a-4779-a633-d185a4b71e04"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(634, 269),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fac52282-ed67-44a7-bd72-ed38e5e56220"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(935, 233));
			schemaFlow.PolylinePointPositions.Add(new Point(935, 113));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("08cbffd4-ed3f-46f8-a81f-4f5c5cdf4834"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(564, 168),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fac52282-ed67-44a7-bd72-ed38e5e56220"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("33ec13b0-6c8a-4620-8921-30f51798762c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1006, 55));
			schemaFlow.PolylinePointPositions.Add(new Point(610, 55));
			schemaFlow.PolylinePointPositions.Add(new Point(610, 93));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow3",
				UId = new Guid("689283cf-dd44-4ce0-9556-210b607aa27c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(274, 100),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("4b3aed1a-644a-45c5-815c-97053ed16b8b"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b}].[Parameter:{021d04f3-0d96-4292-a469-49763741f632}].[EntityColumn:{3015559e-cbc6-406a-88af-07f7930be832}]#]==[#[IsOwnerSchema:false].[IsSchema:false].[Element:{bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b}].[Parameter:{021d04f3-0d96-4292-a469-49763741f632}].[EntityColumn:{70620d00-e4ea-48d1-9fdc-4572fcd8d41b}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(324, 78),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("33ec13b0-6c8a-4620-8921-30f51798762c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(384, 35));
			schemaFlow.PolylinePointPositions.Add(new Point(567, 35));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("4af39791-80bf-4a7d-9619-a1bf7a5ced17"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b}].[Parameter:{021d04f3-0d96-4292-a469-49763741f632}].[EntityColumn:{b59a15ea-751e-4fd8-8281-f1a3dc7190ff}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("79a25b3e-6735-442d-b68f-a2544aeea005"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(688, 428));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("f37ba6da-aaaf-466c-b9bb-0e6ea73adcfd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("79a25b3e-6735-442d-b68f-a2544aeea005"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(688, 233));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("0ff8f18a-1b60-4d3b-8549-3705eda4a5a3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5ed81272-95c4-4558-9999-a96862be7013"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("b41b1611-c34b-431b-a6ec-a0a0e41e3b57"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5ed81272-95c4-4558-9999-a96862be7013"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("43d381c1-2317-4601-9d21-a326412570ef"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("94bba729-c06a-4c0c-954a-a363bb53f98a"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7059a9d3-af29-4546-b5d1-b46029a486d7"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(210, 93));
			schemaFlow.PolylinePointPositions.Add(new Point(210, 92));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("56043e87-d590-4613-b649-bf6fa7e632b6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7059a9d3-af29-4546-b5d1-b46029a486d7"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(318, 92));
			schemaFlow.PolylinePointPositions.Add(new Point(318, 93));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow2",
				UId = new Guid("cdb788c4-3d14-4967-b75e-18d8e829c806"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{57bee078-709b-4064-8102-a8d287b5ba04}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7059a9d3-af29-4546-b5d1-b46029a486d7"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("33ec13b0-6c8a-4620-8921-30f51798762c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(255, 92));
			schemaFlow.PolylinePointPositions.Add(new Point(255, 1));
			schemaFlow.PolylinePointPositions.Add(new Point(567, 1));
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("bab75b4b-ea1f-49e7-8a58-3a33ef7f9457"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("bab75b4b-ea1f-49e7-8a58-3a33ef7f9457"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("33ec13b0-6c8a-4620-8921-30f51798762c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"Terminate1",
				Position = new Point(553, 79),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal1StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("e6d9f080-86f6-4f00-a466-f201ef6be795"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"StartSignal1",
				NewEntityChangedColumns = false,
				Position = new Point(40, 79),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaStartSignalEvent.EntityChangedColumns.Add("70620d00-e4ea-48d1-9fdc-4572fcd8d41b");
			InitializeStartSignal1Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal2StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("6d7c2bd5-2207-47e5-a6d9-083e2d7ae1dd"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Inserted,
				HasEntityColumnChange = false,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"StartSignal2",
				NewEntityChangedColumns = false,
				Position = new Point(20, 178),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			InitializeStartSignal2Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"ReadDataUserTask1",
				Position = new Point(349, 65),
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
				UId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"ReadDataUserTask2",
				Position = new Point(451, 65),
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
				UId = new Guid("96510c7e-efc0-4848-a44e-7ccf55d9b17a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"FillEmailUserTask",
				Position = new Point(551, 280),
				SchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeFillEmailUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask3UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"ReadDataUserTask3",
				Position = new Point(451, 280),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask3Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"AddDataUserTask1",
				Position = new Point(831, 205),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("fac52282-ed67-44a7-bd72-ed38e5e56220"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"ScriptTask1",
				Position = new Point(971, 85),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,65,106,195,48,16,60,199,224,63,44,62,201,80,12,57,167,41,24,55,41,190,54,233,3,182,214,54,136,42,50,72,178,131,41,249,123,86,34,165,142,220,147,164,221,153,157,153,213,136,22,176,243,106,84,126,106,37,108,161,150,242,21,61,126,56,178,71,116,223,235,234,157,186,222,202,86,110,242,76,125,129,8,141,166,55,134,152,212,155,234,141,124,235,246,132,126,176,180,51,248,169,73,138,130,49,181,155,76,183,59,163,210,7,50,146,108,81,150,240,147,103,171,180,14,52,187,111,193,208,5,82,72,34,89,178,145,213,140,85,133,35,114,196,95,144,0,186,2,105,71,81,117,228,148,145,210,104,69,198,239,25,216,219,137,245,26,141,206,221,159,33,203,115,212,125,64,189,136,96,138,245,157,183,67,168,212,246,52,156,185,47,138,225,193,88,241,4,137,211,104,53,104,255,26,155,7,191,135,93,118,196,210,233,98,114,24,252,207,208,184,139,116,13,12,205,51,75,252,67,6,56,2,109,110,126,184,91,109,244,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("79a25b3e-6735-442d-b68f-a2544aeea005"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"ExclusiveGateway1",
				Position = new Point(660, 280),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask4UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"ReadDataUserTask4",
				Position = new Point(731, 400),
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
				UId = new Guid("5ed81272-95c4-4558-9999-a96862be7013"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"FormulaTask1",
				Position = new Point(831, 400),
				ResultParameterMetaPath = @"c4cbc9bd-932f-4649-87a1-e88804fb12c1",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,221,207,189,106,195,48,20,64,225,87,17,201,226,80,110,144,172,171,95,8,25,130,135,76,41,237,24,60,220,88,87,164,96,171,224,184,180,197,228,221,235,210,173,143,144,245,192,55,156,234,188,62,31,111,167,207,194,227,107,119,229,129,98,166,254,198,237,118,169,255,66,211,243,192,101,138,179,241,157,85,172,24,188,179,8,104,168,6,159,157,4,180,164,81,42,204,217,219,251,2,158,105,164,129,39,30,227,156,140,150,24,124,0,89,179,1,76,198,64,72,42,129,12,42,89,206,190,163,80,255,146,166,76,111,211,247,225,189,255,24,74,156,49,117,89,146,86,224,114,114,139,186,16,144,148,8,140,74,95,148,51,26,181,186,183,235,118,179,61,150,196,95,167,92,173,94,154,40,86,27,177,219,9,41,246,162,122,136,59,17,197,223,151,120,122,144,163,31,150,200,134,88,118,2,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask2ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("94bba729-c06a-4c0c-954a-a363bb53f98a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"ScriptTask2",
				Position = new Point(120, 65),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,85,77,83,219,48,16,61,219,191,66,248,100,207,100,60,3,199,134,164,67,62,96,210,105,160,197,20,142,29,197,222,4,181,142,228,234,3,200,64,254,123,87,146,227,56,110,104,15,213,193,177,181,187,79,187,251,158,54,25,240,2,228,116,77,89,73,6,100,244,101,158,137,165,78,199,66,2,62,248,146,173,140,164,154,9,158,102,27,149,129,214,140,175,84,122,5,250,158,150,6,206,149,150,184,49,140,191,41,144,232,206,33,183,190,61,18,6,81,102,170,74,72,157,129,124,98,57,184,3,162,30,241,1,233,116,93,233,77,210,15,217,146,116,98,45,246,76,93,2,213,70,194,148,211,69,9,69,28,185,240,57,40,69,87,48,55,165,102,159,41,95,25,252,136,18,242,246,70,254,11,226,254,44,74,18,242,26,6,51,53,46,133,130,11,94,76,95,152,198,110,104,105,160,31,6,79,84,146,156,42,184,133,92,200,98,86,160,37,206,52,197,218,216,138,211,242,52,109,12,39,3,114,101,88,81,151,23,6,193,71,114,220,17,77,31,218,166,179,198,212,15,9,46,163,176,75,36,158,140,166,47,144,27,45,36,41,22,205,235,160,91,239,148,43,172,116,50,218,111,197,73,226,112,94,221,179,169,224,230,153,131,204,160,68,167,175,6,228,134,12,48,17,235,193,225,153,248,253,14,29,73,122,39,170,248,212,214,130,11,37,81,154,53,143,163,49,130,33,155,145,3,156,21,209,123,246,185,40,216,146,65,49,218,28,115,18,92,211,92,91,63,47,15,239,144,94,74,177,174,33,118,33,51,204,71,126,18,172,21,85,155,130,244,230,88,62,233,76,77,127,25,90,30,156,210,228,144,62,60,130,132,125,216,65,132,79,47,253,66,37,93,131,6,25,183,185,71,165,80,85,183,202,83,213,162,107,54,161,154,222,2,197,11,69,164,255,25,28,237,123,234,185,68,84,235,20,239,185,173,105,243,212,57,102,236,122,126,100,37,144,216,67,162,82,104,97,249,13,90,158,205,187,101,90,216,211,240,228,218,31,111,131,47,201,95,89,43,208,97,188,239,84,191,19,189,110,40,251,23,196,33,185,93,28,170,20,74,27,224,93,148,221,236,216,145,223,5,96,106,127,128,203,22,145,234,210,6,173,44,219,97,118,156,156,252,17,231,46,247,33,118,181,35,87,33,168,21,255,132,57,185,83,185,169,243,234,17,177,248,129,124,13,99,39,153,118,175,91,95,196,73,104,39,14,148,210,193,156,216,246,186,222,174,212,59,88,87,37,213,224,2,108,60,74,84,105,149,94,212,29,219,219,143,32,32,56,171,24,112,43,232,166,197,219,118,138,91,219,17,92,23,85,149,229,143,80,152,18,123,127,39,217,106,101,175,208,226,60,195,137,127,48,0,175,133,198,118,229,110,204,15,227,122,66,99,78,184,19,71,127,245,222,201,246,74,10,83,217,139,244,189,211,130,196,231,31,4,157,137,245,32,228,79,85,209,28,210,107,228,161,215,29,104,99,35,37,150,104,119,107,135,61,97,61,55,150,15,212,226,202,223,54,55,199,191,109,195,109,40,1,255,2,184,159,227,191,1,230,51,170,198,233,6,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("7059a9d3-af29-4546-b5d1-b46029a486d7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ab8e2b9d-422d-4dce-b15c-eb177262002f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"),
				Name = @"ExclusiveGateway2",
				Position = new Point(232, 64),
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
				UId = new Guid("b664894c-10e2-4207-9f2a-e18100f3a271"),
				Name = "BPMSoft.Mail",
				Alias = "",
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("f4ad8837-96b8-46ff-9488-8002103ea83c"),
				Name = "BPMSoft.Mail.Sender",
				Alias = "",
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("275e8026-6921-41d0-bf0e-2f9d9f0051c4"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3af073b6-ff03-4de8-a1ef-c261aabf7ba8"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c9759650-9711-40d6-a7e2-c5aba34fe0a9"),
				Name = "BPMSoft.Core.Scheduler",
				Alias = "",
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("4cc50205-bb0b-4854-abab-6a774187dd16"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("84ceba09-0dcf-4ced-a843-30e0b024f78b"),
				Name = "BPMSoft.Core.DB",
				Alias = "",
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("4f275d04-4104-4f26-9f0f-7b1eb2419c23"),
				Name = "System",
				Alias = "",
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("70f57acd-ff6a-42b0-9dd8-ec32c122c084"),
				Name = "BPMSoft.Core.Configuration.SysSettings",
				Alias = "SysSettings",
				CreatedInPackageId = new Guid("0d63071a-6d99-47e6-b34e-9457e3237a19")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SendEmailToSROwner(userConnection);
		}

		public override object Clone() {
			return new SendEmailToSROwnerSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698"));
		}

		#endregion

	}

	#endregion

	#region Class: SendEmailToSROwner

	/// <exclude/>
	public class SendEmailToSROwner : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SendEmailToSROwner process)
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, SendEmailToSROwner process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("bcf3ee7f-68f5-4fca-a4bd-ed1c17593c8b");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,77,111,211,64,16,253,43,145,207,108,181,182,215,235,117,110,80,2,234,1,90,209,170,23,210,195,236,238,108,98,225,47,173,157,66,137,242,223,25,219,105,104,171,180,4,36,68,145,154,75,236,209,204,236,155,89,191,247,214,129,41,160,109,63,66,137,193,52,120,115,246,225,188,118,221,209,187,188,232,208,191,247,245,170,9,94,5,45,250,28,138,252,59,218,49,62,179,121,247,22,58,160,130,245,252,103,253,60,152,206,247,117,152,7,175,230,65,222,97,217,82,6,21,184,68,103,41,104,206,100,42,4,19,86,0,211,6,129,33,143,67,149,88,17,243,44,28,51,247,183,62,174,203,6,60,142,39,12,205,221,240,120,113,211,244,137,33,5,204,144,146,183,117,181,13,198,61,132,118,86,129,46,208,210,123,231,87,72,161,206,231,37,77,130,23,121,137,103,224,233,164,190,79,221,135,40,201,65,209,246,89,5,186,110,246,173,241,216,182,121,93,61,13,173,88,149,213,221,92,42,199,221,235,22,12,31,16,246,153,103,208,45,135,6,39,4,106,51,96,124,189,88,120,92,64,151,95,223,133,240,5,111,134,188,195,118,71,5,150,238,231,18,138,21,222,57,243,254,28,199,208,116,227,56,227,241,148,224,243,197,242,192,73,119,219,250,213,176,17,5,155,219,228,131,58,238,197,31,73,10,94,247,129,177,199,237,227,60,248,124,210,158,126,173,208,159,155,37,150,48,110,236,234,136,162,15,2,179,2,75,172,186,233,26,165,205,28,87,156,41,233,36,19,142,115,6,66,74,230,34,30,162,147,26,211,44,217,80,193,14,208,116,109,184,144,58,145,25,51,161,77,152,16,136,76,163,75,88,228,184,225,105,172,37,42,187,185,26,129,231,109,83,192,205,229,14,223,197,18,39,6,90,156,44,161,157,104,196,106,66,211,231,139,10,237,164,171,39,117,15,253,232,19,154,218,219,237,45,244,127,84,103,140,48,153,52,130,133,97,202,153,0,227,24,168,12,89,38,149,130,216,165,6,156,166,143,134,126,84,147,169,20,93,170,50,166,66,19,211,76,6,153,210,113,196,44,141,39,149,150,9,234,23,78,61,194,169,195,118,247,194,169,167,56,37,109,106,34,77,220,136,34,158,50,145,98,194,128,104,198,184,138,49,178,41,96,104,237,3,78,57,192,200,25,173,88,134,218,144,148,41,197,32,149,49,75,66,80,206,166,14,56,79,31,227,212,113,207,39,168,236,72,159,137,241,72,138,109,247,210,72,24,206,5,199,136,197,113,74,108,79,120,76,108,143,19,22,71,74,39,156,67,232,112,75,163,158,71,69,189,200,13,20,167,13,122,146,224,65,2,195,253,214,113,207,115,122,113,242,117,221,141,235,217,73,91,15,115,192,114,251,169,73,27,103,58,33,38,135,189,254,8,158,32,163,213,208,151,23,41,145,161,139,108,40,18,2,67,158,219,235,223,121,189,242,102,235,115,237,104,182,127,100,163,255,192,30,127,199,243,246,186,206,33,62,242,223,122,196,223,85,248,151,235,126,102,242,117,98,159,137,18,109,130,205,15,106,19,59,52,240,11,0,0 })));
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

			public ReadDataUserTask2FlowElement(UserConnection userConnection, SendEmailToSROwner process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("046d588f-d451-4b32-ae0e-3a1932e938b9");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,212,48,16,253,43,171,156,235,42,137,29,39,222,91,41,11,234,1,90,209,170,151,46,7,199,30,111,45,242,37,219,91,88,86,251,223,25,39,237,210,162,21,44,92,64,34,39,231,233,205,204,155,207,109,162,26,233,253,123,217,66,50,79,94,93,189,187,238,77,56,125,99,155,0,238,173,235,215,67,114,146,120,112,86,54,246,43,232,9,95,104,27,94,203,32,209,96,187,252,110,191,76,230,203,67,30,150,201,201,50,177,1,90,143,12,52,168,88,37,40,19,21,169,121,170,9,99,2,136,168,104,74,104,45,10,97,50,77,115,200,39,230,97,215,231,125,59,72,7,83,132,209,185,25,159,55,155,33,18,51,4,212,72,177,190,239,30,65,26,37,248,69,39,235,6,52,254,7,183,6,132,130,179,45,102,2,55,182,133,43,233,48,82,244,211,71,8,73,70,54,62,178,26,48,97,241,101,112,224,189,237,187,159,75,107,214,109,247,156,139,230,176,255,125,20,147,142,10,35,243,74,134,251,209,193,5,138,218,141,26,207,86,43,7,43,25,236,195,115,9,159,96,51,242,142,171,29,26,104,236,207,173,108,214,240,44,230,203,60,206,229,16,166,116,166,240,72,112,118,117,127,100,166,251,106,253,42,217,28,193,225,137,124,148,199,131,250,115,142,224,67,4,38,31,79,207,101,114,119,225,47,63,119,224,174,213,61,180,114,170,216,199,83,68,127,0,22,13,180,208,133,249,182,86,134,2,148,134,240,202,20,132,25,37,137,100,181,38,160,51,149,149,133,160,170,170,119,104,176,23,52,223,166,121,166,83,102,40,73,181,224,132,229,34,71,19,46,8,19,37,167,37,203,12,167,121,52,89,116,193,134,205,52,5,243,109,153,242,60,213,105,74,128,129,36,172,210,25,17,70,43,194,138,50,55,74,87,154,101,24,104,74,215,250,161,145,155,219,125,86,31,64,234,153,146,30,102,177,18,184,78,206,135,89,92,162,89,111,102,88,225,117,19,108,183,154,225,24,53,160,98,31,79,207,176,234,171,14,96,244,23,27,138,94,100,65,75,109,68,73,40,205,112,92,120,154,147,186,172,106,66,89,38,105,81,43,154,25,28,151,93,252,226,124,244,43,171,100,115,57,128,195,249,27,251,159,30,222,155,23,11,23,59,227,250,62,76,245,222,247,245,188,239,130,84,97,148,243,52,190,138,87,218,232,218,144,162,172,177,34,28,155,32,160,160,132,86,156,115,99,106,153,81,133,122,240,230,196,172,175,251,181,83,143,123,238,167,99,243,71,103,228,47,156,135,223,217,249,131,91,119,204,30,253,103,59,114,161,255,157,153,222,37,187,111,224,193,107,120,58,7,0,0 })));
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

			public FillEmailUserTaskFlowElement(UserConnection userConnection, SendEmailToSROwner process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "FillEmailUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("96510c7e-efc0-4848-a44e-7ccf55d9b17a");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordId = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
				_templateId = () => (Guid)(new Guid("b47e41c6-94d0-4d02-8531-4054c157c2ac"));
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

		#region Class: ReadDataUserTask3FlowElement

		/// <exclude/>
		public class ReadDataUserTask3FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask3FlowElement(UserConnection userConnection, SendEmailToSROwner process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask3";
				IsLogging = true;
				SchemaElementUId = new Guid("6a3f340b-79dd-4dc2-8779-5140388e5320");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,193,142,211,48,16,253,151,156,215,171,54,206,38,205,222,160,20,78,64,165,172,56,229,50,177,39,169,181,78,29,217,206,138,178,234,191,99,59,109,105,165,8,82,164,10,16,183,248,233,205,228,205,243,243,188,70,76,130,49,159,160,197,232,49,122,187,254,88,168,218,222,191,23,210,162,254,160,85,223,69,119,145,65,45,64,138,111,200,7,124,197,133,125,7,22,92,193,107,249,163,190,140,30,203,177,14,101,116,87,70,194,98,107,28,195,21,164,57,231,73,206,18,146,212,57,146,4,23,140,228,105,202,8,198,57,171,227,52,171,170,52,27,152,227,173,151,170,237,64,227,240,135,208,188,14,159,79,187,206,19,231,14,96,129,34,140,218,30,64,234,37,152,213,22,42,137,220,157,173,238,209,65,86,139,214,77,130,79,162,197,53,104,247,39,223,71,121,200,145,106,144,198,179,36,214,118,245,181,211,104,140,80,219,159,75,147,125,187,61,231,186,114,60,29,15,98,102,65,161,103,174,193,110,66,131,161,211,62,168,124,211,52,26,27,176,226,229,92,196,51,238,2,115,154,123,174,128,187,27,250,2,178,199,51,95,46,39,89,66,103,135,129,142,2,28,69,139,102,51,113,218,147,99,191,26,56,118,96,119,36,79,234,56,58,65,188,112,224,139,7,66,209,18,140,247,108,239,93,75,19,204,48,166,148,208,42,171,73,18,115,78,114,58,127,32,244,97,65,83,58,207,18,200,249,255,150,169,98,103,214,192,158,161,193,251,43,226,53,201,200,171,227,117,41,228,223,140,153,183,79,170,70,48,144,159,59,212,206,193,160,123,54,30,131,139,252,164,126,98,165,108,193,54,216,194,73,143,187,161,1,9,58,142,87,0,21,171,56,230,149,127,220,41,73,22,51,74,42,62,175,8,77,49,225,60,131,108,145,51,39,200,45,102,175,188,80,189,102,135,224,154,97,35,255,214,174,253,3,121,191,110,49,142,38,102,74,6,110,178,70,254,82,187,138,221,200,155,191,185,115,55,125,25,251,104,255,29,234,2,71,128,165,8,0,0 })));
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

		#region Class: AddDataUserTask1FlowElement

		/// <exclude/>
		public class AddDataUserTask1FlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddDataUserTask1FlowElement(UserConnection userConnection, SendEmailToSROwner process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("642b124c-467a-47e3-8a39-a64f0b375256");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Title = () => new LocalizableString((process.Subject));
				_recordDefValues_Type = () => (Guid)(new Guid("e2831dec-cfc0-df11-b00f-001d60e938c6"));
				_recordDefValues_Body = () => new LocalizableString((process.FillEmailUserTask.Body));
				_recordDefValues_Sender = () => new LocalizableString((process.SenderEmail));
				_recordDefValues_Recepient = () => new LocalizableString(((process.ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? process.ReadDataUserTask2.ResultEntity.GetTypedColumnValue<string>("Email") : null)));
				_recordDefValues_Case = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
				_recordDefValues_MessageType = () => (Guid)(new Guid("7f6d3f94-f36b-1410-068c-20cf30b39373"));
				_recordDefValues_ActivityCategory = () => (Guid)(new Guid("8038a396-7825-e011-8165-00155d043204"));
				_recordDefValues_IsHtmlBody = () => (bool)(true);
				_recordDefValues_EmailSendStatus = () => (Guid)(new Guid("603ba6af-6107-e011-a646-16d83cab0980"));
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
						_getColumnValueFunctions.Add("_recordDefValues_EmailSendStatus", () => _recordDefValues_EmailSendStatus.Invoke());
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
			internal Func<Guid> _recordDefValues_EmailSendStatus;

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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,217,110,91,201,17,253,21,130,51,64,94,84,68,239,139,222,102,113,16,1,118,198,176,146,121,177,252,80,221,93,109,51,161,72,131,188,26,67,17,244,239,57,151,146,198,203,24,52,149,64,138,141,144,128,68,220,203,94,170,187,235,212,57,85,125,53,253,126,184,124,43,211,227,233,143,207,159,157,174,250,48,251,105,181,150,217,243,245,170,202,102,51,123,186,170,188,152,255,139,203,66,158,243,154,207,101,144,245,175,188,184,144,205,211,249,102,56,154,124,216,105,122,52,253,254,183,237,111,211,227,151,87,211,147,65,206,255,126,210,48,178,107,138,83,231,70,189,187,76,46,228,78,41,233,74,62,105,41,94,57,103,83,66,231,186,90,92,156,47,159,201,192,207,121,120,51,61,190,154,110,71,219,14,80,187,98,171,41,246,22,201,181,194,196,74,57,18,167,109,209,209,91,103,245,244,250,104,186,169,111,228,156,183,147,190,239,92,157,203,45,89,67,236,106,37,87,148,166,146,155,167,196,218,84,103,56,247,148,199,206,183,237,223,119,124,249,221,203,147,205,47,239,150,178,62,221,142,123,220,121,177,145,87,51,188,253,228,197,239,91,115,124,85,93,45,53,151,70,217,154,142,181,98,193,41,178,38,73,41,41,215,11,230,212,215,175,190,123,53,206,216,230,155,183,11,190,252,245,143,19,159,94,148,127,72,29,110,154,189,253,104,227,63,108,120,117,118,115,122,103,211,227,179,207,159,223,237,247,141,189,31,159,224,199,135,119,54,61,58,155,158,174,46,214,117,28,205,226,225,231,15,172,219,78,176,109,242,201,227,221,105,225,205,242,98,177,184,125,243,51,15,124,215,240,238,245,170,205,251,92,218,201,242,244,238,144,182,163,168,219,15,125,230,223,221,231,198,182,255,166,219,51,94,242,107,89,255,21,203,127,111,251,239,86,254,13,91,120,55,176,175,108,125,215,138,88,195,81,92,13,145,56,7,38,155,108,227,192,157,107,175,219,222,47,164,203,90,150,85,254,67,195,94,200,102,187,219,35,76,110,237,26,183,234,122,122,125,125,244,33,120,130,104,199,94,51,85,30,29,74,23,79,108,57,82,137,61,231,28,149,169,54,236,4,143,119,89,87,107,59,73,54,0,79,229,68,236,99,166,230,146,86,194,222,85,31,30,2,60,79,87,171,127,94,188,157,69,95,92,179,185,144,247,109,28,161,5,74,13,251,107,17,11,216,167,150,67,141,51,49,201,234,38,149,176,187,138,90,215,152,70,169,142,93,211,45,40,201,54,213,240,37,204,220,206,247,67,29,230,191,205,135,203,201,8,140,217,147,115,158,47,14,48,122,116,24,21,147,189,138,186,83,20,70,200,151,96,198,83,103,202,58,151,110,35,98,99,55,187,96,180,143,215,220,11,70,221,217,102,84,27,71,104,134,92,52,176,197,212,66,186,91,83,69,139,246,69,237,132,81,208,73,162,87,150,18,40,135,156,55,141,152,45,30,123,12,49,155,228,109,241,255,75,14,122,178,144,115,89,14,199,87,57,120,173,106,20,146,17,75,46,57,224,221,57,161,88,107,199,110,102,16,38,95,127,76,90,189,89,177,161,10,89,85,2,129,142,97,168,14,153,20,78,47,152,238,99,112,233,203,164,245,23,94,182,133,76,176,229,104,48,200,164,175,214,19,88,56,95,76,222,205,135,55,147,115,174,235,213,102,246,227,170,93,30,0,249,232,128,172,170,43,23,70,2,8,6,94,81,224,26,201,137,167,236,116,110,53,121,29,138,126,84,94,51,61,58,72,183,134,104,159,45,185,30,183,182,120,106,57,121,37,166,89,237,119,139,66,111,138,14,210,18,5,16,52,120,77,65,115,165,132,5,22,78,181,148,236,173,228,175,68,20,114,108,6,36,206,32,53,131,181,70,72,225,34,25,148,110,18,91,196,51,22,215,247,16,133,178,108,178,254,211,230,6,84,7,12,61,58,134,90,43,150,181,200,24,23,19,210,16,144,90,137,160,183,166,4,236,48,10,150,210,30,23,67,53,234,20,75,165,16,141,135,54,180,1,30,6,122,107,236,64,103,61,74,177,113,39,134,84,45,126,36,99,74,106,228,10,205,5,218,16,52,157,216,171,172,157,229,156,202,87,65,106,136,93,205,167,212,161,90,61,216,183,140,179,138,2,97,177,70,162,53,10,196,146,63,33,53,31,117,118,8,2,100,20,90,59,139,141,102,136,15,36,141,70,165,34,77,178,107,99,151,39,203,1,114,241,167,237,30,29,95,181,210,141,50,163,18,117,206,1,170,144,32,165,118,71,45,137,47,58,5,107,212,30,249,219,11,225,54,89,141,43,156,52,120,210,236,207,243,245,102,152,204,113,112,147,85,159,172,101,115,177,24,230,203,215,19,156,204,2,121,222,124,181,60,40,213,207,163,243,255,143,24,187,164,138,40,147,73,138,2,175,181,109,194,7,165,170,148,183,65,3,157,42,230,221,213,146,88,81,48,113,145,146,55,208,222,136,78,196,161,51,117,3,52,23,163,106,211,246,171,0,53,128,101,69,98,167,144,58,194,87,175,40,235,64,234,147,52,93,33,13,178,173,169,124,2,106,101,116,67,25,197,146,66,10,64,206,228,209,80,40,85,151,99,176,16,20,29,0,253,35,168,199,80,225,144,217,3,212,121,156,72,144,212,219,220,16,61,74,52,49,137,14,58,238,9,234,202,27,217,27,211,39,237,192,210,223,92,234,169,117,108,104,132,186,157,129,38,5,131,56,4,4,20,36,116,13,65,107,95,37,215,118,47,64,103,120,153,235,236,9,172,37,32,89,228,144,197,234,66,22,226,33,170,108,59,254,118,2,154,187,231,104,155,5,147,129,152,28,2,19,37,44,134,180,143,48,71,231,80,154,121,192,10,142,43,38,6,70,6,30,1,75,140,0,225,10,245,10,244,196,44,173,6,212,104,76,159,197,30,154,237,217,81,183,1,150,97,149,164,66,170,48,25,32,87,197,102,236,252,158,21,156,103,40,88,226,172,111,10,56,191,92,12,175,87,128,213,1,72,223,28,144,246,241,155,123,1,169,193,28,167,112,13,192,90,35,141,202,78,65,155,21,67,217,55,86,5,248,76,95,0,82,77,26,64,140,168,198,43,224,207,89,136,102,174,169,97,89,142,77,182,224,29,155,30,16,72,57,104,129,246,12,176,223,96,250,6,209,81,212,72,72,48,94,2,242,137,90,213,44,41,59,38,133,216,181,4,243,96,168,6,216,131,31,75,161,168,222,40,24,173,220,125,75,161,21,229,152,215,171,245,229,65,100,126,163,80,218,199,115,238,151,57,70,239,139,207,149,108,141,72,101,123,0,168,138,70,244,78,141,141,199,157,66,231,190,19,74,73,117,160,5,38,68,212,238,81,101,244,16,153,62,160,74,107,58,202,49,99,13,70,61,64,230,56,172,241,181,195,245,239,126,63,92,153,61,162,115,103,20,141,125,233,137,84,239,56,77,112,63,174,60,113,193,100,198,68,59,70,238,89,197,71,205,160,106,71,253,195,160,14,98,12,234,139,78,183,12,193,133,154,54,178,168,154,217,20,167,28,239,206,160,178,245,112,197,177,188,131,226,10,238,167,43,177,193,0,209,148,6,7,143,65,170,123,64,158,232,182,235,152,112,75,222,11,110,25,156,13,29,216,202,10,87,202,33,196,170,36,5,231,102,65,217,50,94,72,82,208,42,222,240,4,7,23,72,7,76,94,25,225,33,169,61,121,98,123,73,54,57,29,120,184,216,204,126,120,199,243,49,143,57,8,174,237,231,91,98,137,125,252,230,75,64,122,117,253,111,190,45,101,230,18,34,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "77b64dfc5e5942e8baa6a231f1fdd698",
							"BaseElements.AddDataUserTask1.Parameters.RecordDefValues.Value");
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

		#region Class: ReadDataUserTask4FlowElement

		/// <exclude/>
		public class ReadDataUserTask4FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask4FlowElement(UserConnection userConnection, SendEmailToSROwner process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask4";
				IsLogging = true;
				SchemaElementUId = new Guid("58c61e1e-8764-45a2-8f70-46a34014ff86");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,115,218,48,16,253,43,25,159,227,140,63,192,6,110,41,165,29,14,109,152,33,211,75,204,97,37,173,65,83,219,242,72,34,45,101,252,223,187,178,193,161,41,164,105,47,205,201,246,243,211,211,238,219,183,123,143,23,96,204,103,40,209,155,120,239,22,159,150,42,183,55,31,100,97,81,127,212,106,91,123,215,158,65,45,161,144,63,80,116,248,76,72,251,30,44,208,129,125,246,116,62,243,38,217,57,133,204,187,206,60,105,177,52,196,160,3,121,40,146,81,44,2,159,241,4,252,193,48,76,124,54,20,177,159,198,35,145,178,40,76,68,238,180,46,74,207,171,78,188,213,205,219,215,251,93,237,56,3,2,184,42,107,208,210,168,234,0,198,238,118,51,171,128,21,40,232,219,234,45,18,100,181,44,169,9,188,151,37,46,64,211,37,78,71,57,136,72,57,20,198,177,10,204,237,236,123,173,209,24,169,170,151,170,154,170,98,91,86,167,92,58,142,253,231,161,152,160,173,208,49,23,96,55,173,192,20,12,253,105,218,42,111,215,107,141,107,176,242,241,180,136,175,184,107,153,175,51,142,14,8,26,206,23,40,182,120,184,53,12,126,107,101,10,181,237,58,58,86,64,20,141,57,106,172,56,46,249,6,75,232,123,124,34,200,245,230,68,196,13,244,225,162,35,189,171,127,50,37,34,176,62,146,95,242,184,87,60,219,101,148,16,248,232,128,78,227,248,154,121,15,115,115,247,173,66,221,181,213,249,186,186,33,244,25,208,235,79,246,41,50,150,164,128,62,11,113,76,94,143,153,207,162,33,247,69,204,33,225,145,8,89,58,106,86,93,29,210,212,5,236,218,82,122,187,174,52,114,165,197,213,92,180,28,247,160,63,108,136,144,230,163,192,143,153,160,9,6,140,251,227,84,112,159,13,198,33,19,41,12,162,196,101,161,105,86,141,11,68,161,214,146,67,113,87,163,134,195,180,130,243,105,254,101,13,156,15,90,41,251,108,138,183,156,114,37,45,101,233,36,83,116,27,109,184,179,114,169,182,154,99,183,90,166,91,237,127,90,218,255,176,145,127,183,102,23,66,252,154,88,190,149,200,205,197,91,138,83,227,53,63,1,59,250,80,253,71,6,0,0 })));
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

		public SendEmailToSROwner(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SendEmailToSROwner";
			SchemaUId = new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_templateId = () => { return (Guid)(new Guid("b47e41c6-94d0-4d02-8531-4054c157c2ac")); };
			_senderEmail = () => { return new LocalizableString(((String)SysSettings.GetValue(UserConnection, "SupportServiceEmail"))); };
			_subject = () => { return new LocalizableString((FillEmailUserTask.Subject)); };
			_caseRecordId = () => { return (Guid)(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty))); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("77b64dfc-5e59-42e8-baa6-a231f1fdd698");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SendEmailToSROwner, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SendEmailToSROwner, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private Func<Guid> _templateId;
		public virtual Guid TemplateId {
			get {
				return (_templateId ?? (_templateId = () => Guid.Empty)).Invoke();
			}
			set {
				_templateId = () => { return value; };
			}
		}

		private Func<string> _senderEmail;
		public virtual string SenderEmail {
			get {
				return (_senderEmail ?? (_senderEmail = () => null)).Invoke();
			}
			set {
				_senderEmail = () => { return value; };
			}
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

		private Func<Guid> _caseRecordId;
		public virtual Guid CaseRecordId {
			get {
				return (_caseRecordId ?? (_caseRecordId = () => Guid.Empty)).Invoke();
			}
			set {
				_caseRecordId = () => { return value; };
			}
		}

		public virtual bool IsCloseAndExit {
			get;
			set;
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
					SchemaElementUId = new Guid("33ec13b0-6c8a-4620-8921-30f51798762c"),
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
					SchemaElementUId = new Guid("e6d9f080-86f6-4f00-a466-f201ef6be795"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessStartSignalEvent _startSignal2;
		public ProcessStartSignalEvent StartSignal2 {
			get {
				return _startSignal2 ?? (_startSignal2 = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "StartSignal2",
					SerializeToDB = false,
					IsLogging = true,
					SchemaElementUId = new Guid("6d7c2bd5-2207-47e5-a6d9-083e2d7ae1dd"),
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

		private FillEmailUserTaskFlowElement _fillEmailUserTask;
		public FillEmailUserTaskFlowElement FillEmailUserTask {
			get {
				return _fillEmailUserTask ?? (_fillEmailUserTask = new FillEmailUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataUserTask3FlowElement _readDataUserTask3;
		public ReadDataUserTask3FlowElement ReadDataUserTask3 {
			get {
				return _readDataUserTask3 ?? (_readDataUserTask3 = new ReadDataUserTask3FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddDataUserTask1FlowElement _addDataUserTask1;
		public AddDataUserTask1FlowElement AddDataUserTask1 {
			get {
				return _addDataUserTask1 ?? (_addDataUserTask1 = new AddDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("fac52282-ed67-44a7-bd72-ed38e5e56220"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
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
					SchemaElementUId = new Guid("79a25b3e-6735-442d-b68f-a2544aeea005"),
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
					SchemaElementUId = new Guid("5ed81272-95c4-4558-9999-a96862be7013"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask1Execute,
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
					SchemaElementUId = new Guid("94bba729-c06a-4c0c-954a-a363bb53f98a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask2Execute,
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
					SchemaElementUId = new Guid("7059a9d3-af29-4546-b5d1-b46029a486d7"),
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

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("a7874379-205f-41fe-96f1-309febd80697"),
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
					SchemaElementUId = new Guid("4b3aed1a-644a-45c5-815c-97053ed16b8b"),
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
					SchemaElementUId = new Guid("4af39791-80bf-4a7d-9619-a1bf7a5ced17"),
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
					SchemaElementUId = new Guid("cdb788c4-3d14-4967-b75e-18d8e829c806"),
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
			FlowElements[StartSignal2.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal2 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
			FlowElements[FillEmailUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { FillEmailUserTask };
			FlowElements[ReadDataUserTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask3 };
			FlowElements[AddDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataUserTask1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ReadDataUserTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask4 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Terminate1":
						CompleteProcess();
						break;
					case "StartSignal1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask2", e.Context.SenderName));
						break;
					case "StartSignal2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask2", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask3", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "FillEmailUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ReadDataUserTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FillEmailUserTask", e.Context.SenderName));
						break;
					case "AddDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask4", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataUserTask1", e.Context.SenderName));
						break;
					case "ReadDataUserTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataUserTask1", e.Context.SenderName));
						break;
					case "ScriptTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalSequenceFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<string>("Email") : null)) != string.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask2", "ConditionalFlow1", "((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName(\"Email\").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<string>(\"Email\") : null)) != string.Empty", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("ModifiedBy").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("ModifiedById") : Guid.Empty))==((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask1", "ConditionalFlow2", "((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName(\"ModifiedBy\").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>(\"ModifiedById\") : Guid.Empty))==((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName(\"Owner\").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>(\"OwnerId\") : Guid.Empty))", result);
			return result;
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("ParentActivity").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("ParentActivityId") : Guid.Empty)) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow1", "((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName(\"ParentActivity\").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>(\"ParentActivityId\") : Guid.Empty)) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalSequenceFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((IsCloseAndExit));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalSequenceFlow2", "(IsCloseAndExit)", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("IsCloseAndExit")) {
				writer.WriteValue("IsCloseAndExit", IsCloseAndExit, false);
			}
			if (!HasMapping("TemplateId")) {
				writer.WriteValue("TemplateId", TemplateId, Guid.Empty);
			}
			if (!HasMapping("SenderEmail")) {
				writer.WriteValue("SenderEmail", SenderEmail, null);
			}
			if (!HasMapping("Subject")) {
				writer.WriteValue("Subject", Subject, null);
			}
			if (!HasMapping("CaseRecordId")) {
				writer.WriteValue("CaseRecordId", CaseRecordId, Guid.Empty);
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
			MetaPathParameterValues.Add("e2d6e188-0536-4cbb-a47d-546de3233a1d", () => TemplateId);
			MetaPathParameterValues.Add("a7d24a5a-b023-47ad-be9a-c28a39a5ae4f", () => SenderEmail);
			MetaPathParameterValues.Add("c4cbc9bd-932f-4649-87a1-e88804fb12c1", () => Subject);
			MetaPathParameterValues.Add("7ebb67ae-b1e9-459b-b25c-d3ca6c2d1b78", () => CaseRecordId);
			MetaPathParameterValues.Add("57bee078-709b-4064-8102-a8d287b5ba04", () => IsCloseAndExit);
			MetaPathParameterValues.Add("c046b569-c1d5-44ee-bef5-2f0c073b6e8d", () => StartSignal1.RecordId);
			MetaPathParameterValues.Add("85939570-5e97-434a-8ec4-3e328c887084", () => StartSignal1.EntitySchemaUId);
			MetaPathParameterValues.Add("fae2fcb8-9ebc-4d88-a763-51a8fd7fa007", () => StartSignal2.RecordId);
			MetaPathParameterValues.Add("df23ea66-cd2f-4c48-a92d-7b123685cf55", () => StartSignal2.EntitySchemaUId);
			MetaPathParameterValues.Add("9fe73c5e-c65c-4dc9-8a14-32ddee1d2062", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("faf88bc7-9ec3-474f-85c3-47d19c91dd4c", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("87c61dbc-e2fe-4c1d-a939-228b0714856a", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("489aeb16-3e43-4075-8bb1-f85b63fd422a", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("bc13a1cb-f6d2-48da-8094-9471e8db4dc6", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("c395b470-4a8b-4af1-9692-e47f4c846c96", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("38b53574-4673-4dd1-93d8-83f1e4d170ed", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("021d04f3-0d96-4292-a469-49763741f632", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("d1a08149-aeef-49fe-8363-1b80aad76636", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("f4318b8e-a4ba-4399-bb71-48847b675f4d", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("eda4e7cd-cb31-419b-ad36-22a6022aa70d", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("655b9008-70a9-4c03-a04d-b2f308450e34", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("25e0fa4b-970d-43dd-b80e-b2a2625e0dd3", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("bf24a190-2262-4aa4-b32e-c6169bca3b2f", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("014d404c-3972-44b9-a7b0-4e7fca6be3b6", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("7be14a6d-bf83-44ed-a78c-1601116baefd", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("f4e0fd1b-8be5-40bd-9ac3-e85c039c4f9f", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("ddb3398e-58cd-4e8c-9e32-678df8172a66", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("c4e67b30-1c3b-463c-a33c-d95308105c66", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("70b11618-c71a-4155-8014-3a53fd5cd1c8", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("67dd077f-eb7e-455c-bd25-7a2739501199", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("920a67b6-1c8c-4f36-a894-356d4b59f1df", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("d32b69b8-da12-4d43-9e3f-b871199dc2ac", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("5ef8e651-f0f6-44c6-bd11-f287de677557", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("ff3266dd-6661-4954-9be1-753c4436c33c", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("f4581450-6bde-48e5-8aeb-24e01a3f6cb3", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("5719453e-2032-4300-a9bf-e4208bede94d", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("76dd0aac-acbd-4d32-bed0-d30d3e00b7bf", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("485e921a-c9c1-4491-88dc-28252e30e587", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("250b6f40-ea89-421d-b1a1-885362269881", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("4a2e7dfa-30ae-4c59-b872-15ea611cc23d", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("e7d5edde-50a9-47cf-b4d3-02ad39fbec6a", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("984c8a1b-a1b9-4152-ae3f-a823be19b2fc", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("2d33dda1-70ec-434d-8bf0-4a150a70b973", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("e4e926dc-1916-4d49-b91e-d1b3b9ee27f6", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("6e2df57d-caef-4ef7-9bda-a15c8fe5861b", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("416fa2d3-de4d-44d5-9978-c81f98f5e3f1", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("f082c002-fcd5-4525-b652-643120eef8b6", () => ReadDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("e4f314d3-291c-45de-a2c4-0bb7a7a4a043", () => FillEmailUserTask.Subject);
			MetaPathParameterValues.Add("fd3e36ce-30b6-4382-a169-07ea62f57648", () => FillEmailUserTask.Body);
			MetaPathParameterValues.Add("4becebac-6618-4cf8-acff-5399dc9ef219", () => FillEmailUserTask.RecordId);
			MetaPathParameterValues.Add("8ada520f-9328-4d23-8e28-7cd84ab83abd", () => FillEmailUserTask.TemplateId);
			MetaPathParameterValues.Add("19997124-7bc1-4d68-91c0-f2a7263fc478", () => FillEmailUserTask.SysEntitySchemaId);
			MetaPathParameterValues.Add("09d4d948-3e28-4f04-9934-8ff03d3aee8c", () => ReadDataUserTask3.DataSourceFilters);
			MetaPathParameterValues.Add("fc417be0-069a-44c3-9150-0bb0efc91d55", () => ReadDataUserTask3.ResultType);
			MetaPathParameterValues.Add("58f21f7f-2f16-4ac7-8ac8-ce14b47deace", () => ReadDataUserTask3.ReadSomeTopRecords);
			MetaPathParameterValues.Add("a030b9d0-e7a0-4ced-bbbe-9539dfb1dd22", () => ReadDataUserTask3.NumberOfRecords);
			MetaPathParameterValues.Add("3825a909-209e-4923-923d-23603fc8a105", () => ReadDataUserTask3.FunctionType);
			MetaPathParameterValues.Add("702fea70-3f23-4480-8b9f-b553d0a194a6", () => ReadDataUserTask3.AggregationColumnName);
			MetaPathParameterValues.Add("9bcb9ea2-2f79-4c66-be40-60fc89827613", () => ReadDataUserTask3.OrderInfo);
			MetaPathParameterValues.Add("492ae6cd-2386-4f94-b3dc-ecfe0a561e90", () => ReadDataUserTask3.ResultEntity);
			MetaPathParameterValues.Add("2fabbf13-01ca-42c6-9f0d-07f14a79d614", () => ReadDataUserTask3.ResultCount);
			MetaPathParameterValues.Add("96c84c00-2797-4646-a698-7f02695068c7", () => ReadDataUserTask3.ResultIntegerFunction);
			MetaPathParameterValues.Add("6356bc10-9b8b-4a7c-b5e7-8b18ccb8d4cd", () => ReadDataUserTask3.ResultFloatFunction);
			MetaPathParameterValues.Add("c5c8881b-1545-4573-bffe-420faeaa97bc", () => ReadDataUserTask3.ResultDateTimeFunction);
			MetaPathParameterValues.Add("64c177fe-eb36-4a4b-b7ae-91f33fcd1623", () => ReadDataUserTask3.ResultRowsCount);
			MetaPathParameterValues.Add("18bfd995-e4af-4ba7-9844-31322fbc7da7", () => ReadDataUserTask3.CanReadUncommitedData);
			MetaPathParameterValues.Add("753cf6dc-9ea4-44fd-adc1-48898e488426", () => ReadDataUserTask3.ResultEntityCollection);
			MetaPathParameterValues.Add("e8af8fcc-bceb-41bc-99dd-9e7f54a2cc6e", () => ReadDataUserTask3.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("55390786-dd46-43fb-add4-4f851434760e", () => ReadDataUserTask3.IgnoreDisplayValues);
			MetaPathParameterValues.Add("4fbec98f-004d-4f1f-87a7-b668063d0884", () => ReadDataUserTask3.ResultCompositeObjectList);
			MetaPathParameterValues.Add("de308fad-dcf4-42c5-832a-534722bee38f", () => ReadDataUserTask3.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("a244c08e-bd09-4ca7-8a99-1077520a1ec5", () => AddDataUserTask1.EntitySchemaId);
			MetaPathParameterValues.Add("31b660b1-300f-4f12-a4b2-98efc57cd867", () => AddDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("441998e4-8821-4d10-8a9c-40c050c8dd78", () => AddDataUserTask1.RecordAddMode);
			MetaPathParameterValues.Add("dde1dd64-30a8-4ef6-b1d1-6d6d6661ac9b", () => AddDataUserTask1.FilterEntitySchemaId);
			MetaPathParameterValues.Add("1d10b34a-77ec-4277-99b6-ce89fe7cd27d", () => AddDataUserTask1.RecordDefValues);
			MetaPathParameterValues.Add("b80339a8-820c-40b9-aa5e-7542914dc2df", () => AddDataUserTask1.RecordId);
			MetaPathParameterValues.Add("94e9a24c-27da-4f2f-898d-31e395dc6cc2", () => AddDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("977cad3d-2c65-430b-8902-f756c05291e4", () => ReadDataUserTask4.DataSourceFilters);
			MetaPathParameterValues.Add("9c6f141c-5da9-4856-8b61-9f48b7911781", () => ReadDataUserTask4.ResultType);
			MetaPathParameterValues.Add("4e3be632-b70c-4b4c-8308-380d8171b89f", () => ReadDataUserTask4.ReadSomeTopRecords);
			MetaPathParameterValues.Add("a4a0e571-6551-46d8-9aa9-dd1afda8956c", () => ReadDataUserTask4.NumberOfRecords);
			MetaPathParameterValues.Add("e3c26302-9b0d-4a54-8335-90d353b47af9", () => ReadDataUserTask4.FunctionType);
			MetaPathParameterValues.Add("3be3fe2d-ee9f-45c2-915c-ea7ebe38b5e3", () => ReadDataUserTask4.AggregationColumnName);
			MetaPathParameterValues.Add("9f627d7b-d9c3-4a70-aa62-1e7d41fa025c", () => ReadDataUserTask4.OrderInfo);
			MetaPathParameterValues.Add("d5304989-02e5-4d55-9d1d-091d6ef8ca92", () => ReadDataUserTask4.ResultEntity);
			MetaPathParameterValues.Add("1217e6ca-8d64-4667-ae20-c8be0b49ba25", () => ReadDataUserTask4.ResultCount);
			MetaPathParameterValues.Add("48649703-f62f-4c0f-a38e-076044d6d4b2", () => ReadDataUserTask4.ResultIntegerFunction);
			MetaPathParameterValues.Add("fd373003-c24e-424c-b3c5-56117473ca44", () => ReadDataUserTask4.ResultFloatFunction);
			MetaPathParameterValues.Add("2b34f769-63d0-497e-ba58-140a71c665cd", () => ReadDataUserTask4.ResultDateTimeFunction);
			MetaPathParameterValues.Add("dcbdb688-b666-4348-9e82-b8f414a14ff9", () => ReadDataUserTask4.ResultRowsCount);
			MetaPathParameterValues.Add("97d4b158-03da-42e6-8e2d-9c1391a6e264", () => ReadDataUserTask4.CanReadUncommitedData);
			MetaPathParameterValues.Add("23ad489e-59f4-4704-a50f-89d316ef79aa", () => ReadDataUserTask4.ResultEntityCollection);
			MetaPathParameterValues.Add("07605453-95da-4cae-bb85-94983ae46c6d", () => ReadDataUserTask4.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("4df5accf-b45e-4785-839d-c9360472a236", () => ReadDataUserTask4.IgnoreDisplayValues);
			MetaPathParameterValues.Add("dd5564ee-277d-43ad-bbc6-bf73ebd13b2e", () => ReadDataUserTask4.ResultCompositeObjectList);
			MetaPathParameterValues.Add("5b165516-cbae-4f7a-b065-9fbf5cb28241", () => ReadDataUserTask4.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "IsCloseAndExit":
					if (!hasValueToRead) break;
					IsCloseAndExit = reader.GetValue<System.Boolean>();
				break;
				case "TemplateId":
					if (!hasValueToRead) break;
					TemplateId = reader.GetValue<System.Guid>();
				break;
				case "SenderEmail":
					if (!hasValueToRead) break;
					SenderEmail = reader.GetValue<System.String>();
				break;
				case "Subject":
					if (!hasValueToRead) break;
					Subject = reader.GetValue<System.String>();
				break;
				case "CaseRecordId":
					if (!hasValueToRead) break;
					CaseRecordId = reader.GetValue<System.Guid>();
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
			var activityId = AddDataUserTask1.RecordId;
			if (UserConnection.GetIsFeatureEnabled("UseAsyncEmailSender")) {
				AsyncEmailSender emailSender = new AsyncEmailSender(UserConnection);
				emailSender.SendAsync(activityId);
			} else {
				var emailClientFactory = ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection", UserConnection));
				var activityEmailSender = new ActivityEmailSender(emailClientFactory, UserConnection);
				activityEmailSender.Send(activityId);
			}
				
			return true;
		}

		public virtual bool FormulaTask1Execute(ProcessExecutingContext context) {
			var localSubject = (((ReadDataUserTask4.ResultEntity.IsColumnValueLoaded(ReadDataUserTask4.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? ReadDataUserTask4.ResultEntity.GetTypedColumnValue<string>("Title") : null))).IndexOf("RE: ") == 0 ? (((ReadDataUserTask4.ResultEntity.IsColumnValueLoaded(ReadDataUserTask4.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? ReadDataUserTask4.ResultEntity.GetTypedColumnValue<string>("Title") : null))) : "RE: " + (((ReadDataUserTask4.ResultEntity.IsColumnValueLoaded(ReadDataUserTask4.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? ReadDataUserTask4.ResultEntity.GetTypedColumnValue<string>("Title") : null)));
			Subject = (System.String)localSubject;
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			SenderEmail = BPMSoft.Core.Configuration.SysSettings.GetValue<string>(UserConnection, 
				"SupportServiceEmail", string.Empty);
			if (UserConnection.GetIsFeatureEnabled("EmailMessageMultiLanguage") || UserConnection.GetIsFeatureEnabled("EmailMessageMultiLanguageV2")) {
				IsCloseAndExit = true;
				var caseRecordId = (StartSignal1.RecordId != Guid.Empty)
					? StartSignal1.RecordId 
					: StartSignal2.RecordId;
			    using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection())
			    {
			    	var caseOwnerSelectQuery =
					    new Select(UserConnection).Top(1)
								.Column("Case", "OwnerId")
								.Column("Case", "ModifiedById")
								.Column("Contact", "Email")
							.From("Case")
								.InnerJoin("Contact")
									.On("Case", "OwnerId").IsEqual("Contact", "Id")
							.Where("Case", "Id").IsEqual(Column.Parameter(caseRecordId)) as Select;
			        using (IDataReader reader = caseOwnerSelectQuery.ExecuteReader(dbExecutor))
			        {
				        while (reader.Read())
				        {
					        var owner = reader.GetColumnValue<Guid>("OwnerId");
					        var modifiedBy = reader.GetColumnValue<Guid>("ModifiedById");
					        var assignee = reader.GetColumnValue<string>("Email");
					        var isModifiedByOwner = owner == modifiedBy;
					        if (!isModifiedByOwner) {
						        var parameters = new Dictionary<string, object>()
						        {
							        { "CaseRecordId", caseRecordId },
							        { "EmailTemplateId", CaseConsts.AssigneeTemplateId },
							        { "Recipient", assignee }
						        };
								AppScheduler.TriggerJob<SendMultiLanguageNotification>(string.Concat("SendMultiLanguageNotificationExecutorGroup", "_", caseRecordId),
									UserConnection.Workspace.Name, UserConnection.CurrentUser.Name, parameters, true);
					        }
						}
			        }
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
			var cloneItem = (SendEmailToSROwner)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

