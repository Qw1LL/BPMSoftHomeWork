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

	#region Class: SendEmailToCaseStatusChangedProcessSchema

	/// <exclude/>
	public class SendEmailToCaseStatusChangedProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SendEmailToCaseStatusChangedProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SendEmailToCaseStatusChangedProcessSchema(SendEmailToCaseStatusChangedProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SendEmailToCaseStatusChangedProcess";
			UId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277");
			CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.7.0.0";
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
			Tag = @"Business process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277");
			Version = 0;
			PackageUId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateIsCloseAndExitParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("94883989-46c7-4825-b827-2c151618e017"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"IsCloseAndExit",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateEmailTemplateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0d056708-d60e-42dd-86c1-f5efcfd86bef"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"EmailTemplate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCaseRecordIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e9f06e37-ba23-48d4-832c-0745bb5b6289"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"CaseRecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCloseStatusIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9fc90727-5ac3-4ea8-a541-e3baca1ade4f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"CloseStatusId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#Lookup.99f35013-6b7a-47d6-b440-e3f1a0ba991c.3e7f420c-f46b-1410-fc9a-0050ba5d6c38#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateEmailSenderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6adbdb8d-22e9-4e5f-91e9-ac5d02328433"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"EmailSender",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateIsCloseAndExitParameter());
			Parameters.Add(CreateEmailTemplateParameter());
			Parameters.Add(CreateCaseRecordIdParameter());
			Parameters.Add(CreateCloseStatusIdParameter());
			Parameters.Add(CreateEmailSenderParameter());
		}

		protected virtual void InitializeSubProcessSendEmailParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var caseIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2ea97d45-fb65-4126-9177-dd5587f15336"),
				ContainerUId = new Guid("3ad05c84-c9fa-4316-bb75-2bcaa742c41b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
				Name = @"CaseId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			caseIdParameter.SourceValue = new ProcessSchemaParameterValue(caseIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{e9f06e37-ba23-48d4-832c-0745bb5b6289}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277")
			};
			parametrizedElement.Parameters.Add(caseIdParameter);
			var templateIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3f984456-427a-4177-9163-9b73842be371"),
				ContainerUId = new Guid("3ad05c84-c9fa-4316-bb75-2bcaa742c41b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
				Name = @"TemplateId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			templateIdParameter.SourceValue = new ProcessSchemaParameterValue(templateIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{0d056708-d60e-42dd-86c1-f5efcfd86bef}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277")
			};
			parametrizedElement.Parameters.Add(templateIdParameter);
			var senderEmailParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4ea09cbc-77f4-49ed-932b-bfc84d1131fb"),
				ContainerUId = new Guid("3ad05c84-c9fa-4316-bb75-2bcaa742c41b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
				Name = @"SenderEmail",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText")
			};
			senderEmailParameter.SourceValue = new ProcessSchemaParameterValue(senderEmailParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{6adbdb8d-22e9-4e5f-91e9-ac5d02328433}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277")
			};
			parametrizedElement.Parameters.Add(senderEmailParameter);
			var subjectParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e9652116-1fbc-423a-809f-5abee6bc90cb"),
				ContainerUId = new Guid("3ad05c84-c9fa-4316-bb75-2bcaa742c41b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
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
				ModifiedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41")
			};
			parametrizedElement.Parameters.Add(subjectParameter);
			var parentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("46ad5752-9bc9-40b5-8f41-4568b7813102"),
				ContainerUId = new Guid("3ad05c84-c9fa-4316-bb75-2bcaa742c41b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
				Name = @"ParentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			parentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(parentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41")
			};
			parametrizedElement.Parameters.Add(parentActivityIdParameter);
		}

		protected virtual void InitializeStartSignal1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b45094d5-b09f-4ac1-94fb-eb15b5624972"),
				ContainerUId = new Guid("d67fd76a-2fbe-4045-8049-736af35bdb13"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d67fd76a-2fbe-4045-8049-736af35bdb13"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
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
				UId = new Guid("0ea1b5d8-4e6c-43d5-a7b7-f9bb4610ae41"),
				ContainerUId = new Guid("d67fd76a-2fbe-4045-8049-736af35bdb13"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d67fd76a-2fbe-4045-8049-736af35bdb13"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
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
				UId = new Guid("ce8c0266-efa5-44a9-bff8-26d3da1ebeff"),
				ContainerUId = new Guid("97b8b056-c069-497d-ad15-52df06e79c67"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("97b8b056-c069-497d-ad15-52df06e79c67"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
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
				UId = new Guid("021c651a-8af8-4170-b888-138386e1329f"),
				ContainerUId = new Guid("97b8b056-c069-497d-ad15-52df06e79c67"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("97b8b056-c069-497d-ad15-52df06e79c67"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
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

		protected virtual void InitializeChangeDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("810b9374-7a6a-46db-896a-f030e43430f9"),
				ContainerUId = new Guid("a9434382-a448-40ee-b92f-07bbc051af96"),
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
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3e718202-15ca-44b5-b786-1c807f779f66"),
				ContainerUId = new Guid("a9434382-a448-40ee-b92f-07bbc051af96"),
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
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6ff8853b-20dd-41d4-8339-8a3541af22e2"),
				ContainerUId = new Guid("a9434382-a448-40ee-b92f-07bbc051af96"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,86,81,83,219,48,12,254,43,92,158,49,231,56,137,19,247,141,177,110,199,195,128,131,29,47,148,7,199,150,219,220,210,36,151,184,108,172,215,255,62,57,105,75,187,149,46,229,110,3,242,146,68,39,201,159,100,125,146,230,158,202,101,211,92,200,41,120,3,239,195,213,151,155,210,216,147,79,89,110,161,254,92,151,179,202,59,246,26,168,51,153,103,63,65,119,242,161,206,236,71,105,37,26,204,71,79,246,35,111,48,218,229,97,228,29,143,188,204,194,180,65,13,52,224,17,51,137,207,128,24,19,199,36,212,134,146,132,82,77,20,55,198,79,24,13,184,86,157,230,110,215,103,229,180,146,53,116,39,180,206,77,251,249,245,177,114,138,62,10,84,171,146,53,101,177,20,6,14,66,51,44,100,154,131,198,127,91,207,0,69,182,206,166,24,9,124,205,166,112,37,107,60,201,249,41,157,8,149,140,204,27,167,149,131,177,195,31,85,13,77,147,149,197,126,104,249,108,90,108,234,162,57,172,127,151,96,104,139,208,105,94,73,59,105,29,156,35,168,69,139,241,116,60,174,97,44,109,246,176,9,225,27,60,182,122,253,114,135,6,26,239,231,86,230,51,216,56,115,59,142,51,89,217,46,156,238,120,84,168,179,241,164,103,164,235,108,253,45,88,134,194,106,165,220,203,227,78,252,140,163,240,193,9,58,31,171,207,145,119,119,222,92,126,47,160,190,81,19,152,202,46,99,247,39,40,253,77,48,204,97,10,133,29,204,69,156,38,41,141,56,81,148,11,18,138,88,19,169,253,136,68,12,211,201,33,22,138,199,11,52,88,3,26,204,21,36,138,50,206,9,24,25,145,48,148,130,164,198,36,132,113,29,104,233,67,10,198,44,238,59,224,89,83,229,242,241,118,141,239,76,54,112,212,88,105,103,205,145,154,200,98,12,250,228,26,84,89,235,101,214,221,11,245,34,188,190,36,160,1,17,198,71,88,156,199,68,68,2,72,154,114,10,65,28,37,148,25,44,18,124,92,249,32,86,101,2,65,184,31,41,18,210,196,39,2,34,180,85,177,79,131,56,142,5,55,251,146,125,94,60,71,159,240,61,210,231,166,77,111,63,10,245,75,221,142,18,244,247,115,104,133,193,241,8,12,212,80,40,232,74,112,29,167,43,133,77,181,109,186,185,246,120,247,102,8,215,70,187,65,184,101,149,34,67,2,72,83,108,64,90,113,36,79,194,72,18,6,62,209,137,66,106,48,3,90,117,217,91,31,119,13,101,5,133,43,155,13,135,7,56,250,131,80,79,14,145,11,247,238,202,25,139,162,88,27,65,164,146,146,132,81,74,137,144,12,217,10,34,213,65,40,176,47,250,123,217,208,92,204,242,252,57,70,176,93,140,96,111,156,17,109,75,236,71,136,126,217,59,156,16,167,40,25,23,0,251,41,81,22,86,42,219,237,8,237,53,172,16,182,125,46,47,199,153,146,249,101,5,181,92,58,166,187,51,191,117,101,110,88,212,101,105,119,240,175,61,105,21,122,234,251,90,132,161,114,69,136,125,61,80,134,136,132,134,132,165,16,167,76,7,28,36,197,36,226,14,228,98,191,41,103,181,90,238,29,77,183,252,188,104,173,121,133,117,229,144,29,100,231,22,208,167,205,188,219,153,253,111,39,240,43,140,215,67,103,230,51,147,232,37,151,190,53,55,250,182,249,131,251,248,43,52,104,56,180,235,254,151,102,182,240,22,191,0,254,173,109,108,195,13,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("84e64196-ae90-4d27-ba05-56b7d0cb5cf6"),
				ContainerUId = new Guid("a9434382-a448-40ee-b92f-07bbc051af96"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,82,193,110,219,48,12,253,149,65,232,49,10,36,91,182,228,28,219,94,2,52,67,176,180,189,204,59,208,34,181,26,112,236,192,118,6,180,129,255,189,178,106,47,201,144,219,116,144,32,146,239,241,233,137,39,118,215,191,31,136,173,216,253,118,179,107,92,191,124,104,90,90,110,219,198,82,215,45,159,26,11,85,249,1,69,69,91,104,97,79,61,181,175,80,29,169,123,42,187,126,241,237,18,196,22,236,238,79,200,177,213,207,19,91,247,180,127,89,163,103,38,133,86,67,42,57,198,145,228,10,19,224,89,162,145,163,209,20,91,97,8,139,204,131,109,83,29,247,245,134,122,216,66,255,198,86,39,22,216,60,129,22,105,36,80,8,78,138,128,43,131,146,103,14,45,87,137,142,156,69,131,74,22,108,88,176,206,190,209,30,66,211,51,88,74,237,251,186,140,155,72,39,30,18,43,110,148,148,92,218,52,149,50,177,148,89,28,193,83,253,25,56,6,177,236,14,21,188,191,222,202,29,174,12,185,204,158,242,47,87,115,182,202,111,251,58,157,187,32,248,218,217,107,83,115,182,200,217,174,57,182,118,100,19,254,242,120,33,41,52,8,37,255,92,103,23,125,164,62,86,213,20,121,132,30,230,194,57,220,96,233,74,194,117,189,155,205,11,44,98,90,252,198,54,175,47,109,255,3,219,64,13,191,169,253,238,159,127,214,254,87,229,179,183,112,38,46,162,44,17,90,58,174,9,50,174,40,141,184,31,3,63,72,50,43,92,172,253,7,187,40,160,127,144,163,150,106,75,215,194,100,90,80,156,38,146,27,71,17,87,50,241,243,128,40,56,24,17,163,74,77,140,24,79,248,46,184,61,142,239,164,107,180,106,96,195,240,107,248,4,51,178,17,55,46,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bc3d543a-e907-49e5-9305-1badf49c0e15"),
				ContainerUId = new Guid("a9434382-a448-40ee-b92f-07bbc051af96"),
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
			ProcessSchemaSubProcess subprocesssendemail = CreateSubProcessSendEmailSubProcess();
			FlowElements.Add(subprocesssendemail);
			ProcessSchemaStartSignalEvent startsignal1 = CreateStartSignal1StartSignalEvent();
			FlowElements.Add(startsignal1);
			ProcessSchemaStartSignalEvent startsignal2 = CreateStartSignal2StartSignalEvent();
			FlowElements.Add(startsignal2);
			ProcessSchemaScriptTask scripttask = CreateScriptTaskScriptTask();
			FlowElements.Add(scripttask);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask changedatausertask1 = CreateChangeDataUserTask1UserTask();
			FlowElements.Add(changedatausertask1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("fcb1629b-22ff-42cb-9266-b81588ed68d3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d67fd76a-2fbe-4045-8049-736af35bdb13"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("87b14dd0-8690-4c2d-970a-35c3656cd9f9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("f9180d1b-7e24-4b75-811a-70caff864c67"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2abdea98-cf8b-47f8-8868-0da495323261"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3ad05c84-c9fa-4316-bb75-2bcaa742c41b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(487, 72));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("21cdafae-cfe7-4c14-85dd-a45603176746"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3ad05c84-c9fa-4316-bb75-2bcaa742c41b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("526b358c-eb90-47e8-8a27-4e49156b7f73"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(734, 72));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("ebcf97b5-1631-42e6-8413-edda66493717"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{94883989-46c7-4825-b827-2c151618e017}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2abdea98-cf8b-47f8-8868-0da495323261"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("526b358c-eb90-47e8-8a27-4e49156b7f73"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("5a22b753-52b0-43ce-9a7b-c55286215695"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("97b8b056-c069-497d-ad15-52df06e79c67"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a9434382-a448-40ee-b92f-07bbc051af96"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("815b13ec-93a8-4af3-a0f5-cbff738b1263"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a9434382-a448-40ee-b92f-07bbc051af96"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("87b14dd0-8690-4c2d-970a-35c3656cd9f9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(320, 325));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("936b82a8-012d-4b83-b3d5-481528a4b911"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("87b14dd0-8690-4c2d-970a-35c3656cd9f9"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2abdea98-cf8b-47f8-8868-0da495323261"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("87200ec3-22b2-494e-824f-744d1f9062d8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("877593b0-6738-40f5-9061-ed61292b498c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("87200ec3-22b2-494e-824f-744d1f9062d8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal1StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("d67fd76a-2fbe-4045-8049-736af35bdb13"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("877593b0-6738-40f5-9061-ed61292b498c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
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
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"StartSignal1",
				NewEntityChangedColumns = false,
				Position = new Point(82, 191),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			InitializeStartSignal1Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal2StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("97b8b056-c069-497d-ad15-52df06e79c67"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("877593b0-6738-40f5-9061-ed61292b498c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
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
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"StartSignal2",
				NewEntityChangedColumns = false,
				Position = new Point(82, 312),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaStartSignalEvent.EntityChangedColumns.Add("a71adaea-3464-4dee-bb4f-c7a535450ad7");
			InitializeStartSignal2Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("87b14dd0-8690-4c2d-970a-35c3656cd9f9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("877593b0-6738-40f5-9061-ed61292b498c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"ScriptTask",
				Position = new Point(286, 177),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,89,95,111,219,54,16,127,118,129,125,7,213,15,133,12,24,106,151,215,54,1,90,199,233,12,44,109,102,39,235,67,209,7,85,166,19,2,178,228,146,84,90,99,232,119,223,221,145,20,73,137,118,236,38,205,128,161,34,239,255,253,120,188,163,239,115,145,76,114,201,230,172,168,197,114,182,76,78,147,247,13,95,102,211,245,70,109,95,255,241,236,30,246,139,92,177,219,90,108,227,187,82,229,170,145,241,61,46,47,155,82,241,50,175,110,155,252,150,77,171,252,107,201,144,242,70,50,49,169,171,138,21,138,215,85,246,158,169,153,188,96,32,72,88,162,116,56,93,231,188,188,100,82,2,39,137,249,219,136,25,142,64,252,76,78,202,90,178,183,213,114,250,131,43,16,185,202,75,201,96,131,175,146,116,161,114,161,22,252,182,202,203,63,179,214,181,231,190,133,163,228,191,63,158,13,58,174,71,249,64,230,207,158,216,147,95,20,123,210,17,171,227,132,206,228,50,140,0,240,189,187,186,92,212,43,149,65,164,86,252,182,17,57,5,203,80,221,64,92,185,226,76,70,163,23,6,120,156,12,23,12,34,133,17,189,174,209,186,143,213,130,242,54,185,131,160,50,210,78,97,229,171,52,102,140,118,139,192,128,123,211,31,172,104,84,45,192,198,138,125,223,97,231,94,141,61,3,253,144,161,33,131,64,81,54,111,170,148,150,123,121,87,162,193,180,15,4,3,115,43,251,73,161,197,255,22,205,215,43,81,23,0,163,214,158,12,117,81,98,124,165,45,100,47,56,228,201,3,20,174,50,249,205,248,58,173,20,87,219,69,113,199,214,249,63,13,19,219,142,39,153,79,112,153,87,128,87,1,225,71,77,20,96,144,148,189,93,46,39,117,217,172,171,116,168,99,18,219,153,152,83,71,123,26,36,115,38,235,242,158,25,18,48,40,42,44,115,132,30,47,121,165,9,63,228,107,182,135,153,40,135,163,12,201,34,102,213,149,202,11,21,179,248,227,247,138,9,218,120,249,18,183,46,120,169,152,144,72,146,226,247,68,0,164,152,94,253,196,213,221,85,46,64,5,146,164,122,113,82,175,55,185,224,178,174,174,183,27,150,77,191,53,121,9,177,155,45,135,29,124,88,183,10,88,212,241,54,254,192,81,208,223,15,226,11,207,179,199,14,135,184,106,202,114,132,48,15,234,157,163,65,225,104,151,241,247,223,188,108,216,27,60,249,103,46,89,96,42,161,212,43,138,135,9,208,209,183,236,97,186,31,22,242,181,174,203,179,180,11,16,202,32,201,115,160,62,80,80,7,45,90,8,68,236,185,211,161,75,2,153,218,108,150,224,191,57,32,55,244,209,47,64,231,172,204,183,108,249,161,86,124,197,33,196,176,58,28,161,132,1,84,10,5,17,128,227,121,14,156,152,107,109,62,176,75,149,82,90,12,225,167,59,38,24,70,27,207,47,64,116,38,9,35,169,97,104,1,149,134,104,209,204,80,50,204,165,114,205,214,155,18,84,105,25,85,74,251,131,158,144,120,89,67,209,11,38,238,121,193,200,64,153,81,68,26,220,244,157,187,222,148,160,123,156,60,82,248,84,42,190,166,205,57,251,214,48,169,180,92,146,74,105,25,12,116,248,51,93,43,153,46,147,63,19,6,213,203,165,168,208,199,246,24,72,91,14,13,73,146,82,227,9,63,66,6,85,132,86,2,29,57,103,199,169,21,103,144,180,187,180,107,229,172,95,88,251,157,68,164,250,198,37,96,193,232,211,210,93,10,113,207,171,130,189,219,34,244,53,218,140,7,3,83,45,52,39,110,116,196,152,26,23,173,65,70,4,70,193,241,195,109,174,138,187,11,81,175,207,223,197,80,171,35,51,192,120,194,213,91,75,184,145,39,245,146,157,179,85,191,227,66,66,125,69,251,116,11,37,120,117,27,116,19,130,117,175,234,45,220,142,74,1,29,117,19,148,195,222,9,214,10,6,20,143,73,160,2,78,209,117,173,245,104,244,193,159,231,34,136,246,176,225,213,58,56,233,152,112,251,125,0,171,209,107,234,68,39,247,147,70,8,224,197,85,244,194,124,34,237,53,135,68,142,172,124,204,0,5,238,90,108,225,64,74,150,198,34,54,78,234,70,245,98,62,178,96,61,196,76,228,34,55,123,82,140,37,208,165,116,37,229,247,230,4,195,95,216,210,88,122,252,223,79,175,121,4,216,241,18,171,39,157,135,84,146,245,163,35,179,253,70,179,157,197,178,62,92,52,155,77,13,29,172,46,76,84,66,193,41,29,38,211,246,190,142,119,90,218,44,250,55,158,20,103,169,235,171,78,30,223,88,249,101,119,222,148,109,163,117,226,119,39,65,229,143,82,32,235,13,78,27,209,93,186,191,220,78,167,185,57,57,186,187,1,163,109,131,227,20,143,119,244,210,116,230,244,133,112,206,37,118,228,24,70,226,65,97,163,167,51,203,218,68,55,145,110,78,199,237,140,247,155,244,180,173,46,156,148,182,145,106,155,60,230,39,14,178,81,106,60,232,142,239,196,181,124,110,43,82,120,169,234,198,5,65,168,155,74,157,189,210,39,59,128,137,197,108,159,233,243,171,47,251,46,190,94,155,97,27,168,248,68,236,245,82,129,190,5,140,62,182,175,138,3,99,218,35,143,222,58,61,201,118,150,254,139,149,27,170,27,7,170,8,249,130,27,171,91,143,181,230,21,152,148,23,119,73,218,51,33,225,213,174,232,218,34,219,227,161,75,47,88,57,58,11,90,170,77,64,95,96,232,33,138,183,43,51,128,122,40,209,19,168,204,162,27,71,122,153,33,83,205,66,87,210,216,179,200,72,13,221,236,94,49,93,223,198,29,11,178,43,1,125,163,216,122,76,90,174,185,62,6,177,114,29,132,57,208,160,241,155,30,242,110,19,109,244,61,132,23,238,94,6,45,246,122,206,110,84,241,161,254,110,26,69,56,39,52,130,248,64,88,106,185,211,199,142,226,81,251,116,200,157,138,96,50,182,147,201,94,42,191,77,140,83,184,27,196,120,196,151,193,64,30,231,162,33,197,204,226,134,111,165,139,175,14,195,231,47,182,35,241,248,31,83,141,187,195,246,120,175,244,184,188,153,252,0,99,155,121,118,210,177,211,13,76,47,62,222,69,50,167,135,33,227,156,23,38,75,141,120,12,234,191,39,230,176,91,128,154,191,52,46,15,230,195,45,244,136,54,152,15,163,180,173,109,84,218,124,161,88,217,226,74,92,247,248,4,115,243,158,209,217,205,153,158,31,24,227,75,94,193,140,40,205,200,235,231,149,10,64,172,152,114,184,28,91,240,194,95,171,219,76,227,193,36,142,158,208,89,116,22,60,168,64,87,107,255,48,128,22,19,226,232,112,219,118,206,109,63,236,227,196,143,212,238,11,220,88,47,160,245,74,78,207,172,79,248,185,239,70,105,59,53,116,26,71,216,135,219,53,52,42,108,214,108,141,139,216,27,130,208,199,87,229,123,229,240,229,51,183,224,122,10,108,61,26,89,190,193,71,224,234,81,111,60,187,31,121,118,195,243,65,59,119,53,19,161,78,87,232,186,22,251,207,88,222,148,46,152,132,78,144,122,79,200,210,14,152,3,74,2,186,211,196,180,169,246,6,169,32,165,200,143,142,205,232,163,91,246,76,62,224,157,75,213,233,33,213,196,68,126,156,68,130,21,139,185,229,211,153,140,178,29,139,133,80,112,191,213,249,29,105,124,138,98,122,52,230,147,92,154,180,217,122,167,51,122,80,189,227,235,53,91,114,176,229,168,138,55,15,43,222,252,201,43,222,204,154,21,175,122,81,171,195,186,215,159,131,236,235,198,3,83,10,182,58,151,121,33,106,105,218,189,120,15,176,175,174,70,205,11,206,156,194,7,88,180,229,87,17,103,82,170,196,214,189,37,245,189,117,191,159,117,166,44,210,223,226,2,39,102,24,175,172,32,124,95,5,84,178,29,176,217,253,196,218,121,107,66,106,72,86,103,26,62,32,251,11,88,145,43,120,226,133,245,69,35,238,217,214,27,42,80,209,139,23,135,253,250,171,223,189,25,166,116,6,94,193,111,100,238,71,72,10,151,75,246,147,194,35,42,123,103,50,130,0,237,255,129,18,223,236,220,171,252,225,191,99,250,11,255,3,126,111,137,235,175,31,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaSubProcess CreateSubProcessSendEmailSubProcess() {
			ProcessSchemaSubProcess schemaSubProcessSendEmail = new ProcessSchemaSubProcess(this) {
				UId = new Guid("3ad05c84-c9fa-4316-bb75-2bcaa742c41b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("877593b0-6738-40f5-9061-ed61292b498c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"SubProcessSendEmail",
				Position = new Point(591, 45),
				SchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeSubProcessSendEmailParameters(schemaSubProcessSendEmail);
			return schemaSubProcessSendEmail;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("526b358c-eb90-47e8-8a27-4e49156b7f73"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("877593b0-6738-40f5-9061-ed61292b498c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"Terminate1",
				Position = new Point(721, 191),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a9434382-a448-40ee-b92f-07bbc051af96"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("877593b0-6738-40f5-9061-ed61292b498c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"ChangeDataUserTask1",
				Position = new Point(191, 298),
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
				UId = new Guid("2abdea98-cf8b-47f8-8868-0da495323261"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("877593b0-6738-40f5-9061-ed61292b498c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1f513d05-8e3f-4989-92ce-3af40e5127d6"),
				CreatedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277"),
				Name = @"ExclusiveGateway1",
				Position = new Point(460, 177),
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
				UId = new Guid("fb058002-0bf1-4e72-950d-847a882e3c69"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1e8b887e-ebaa-40ce-be6c-6b5e1191a3e4"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("b964c921-e7ab-4448-9709-966667751d2e"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SendEmailToCaseStatusChangedProcess(userConnection);
		}

		public override object Clone() {
			return new SendEmailToCaseStatusChangedProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("22405112-0a8c-4444-870f-deb07a0f7277"));
		}

		#endregion

	}

	#endregion

	#region Class: SendEmailToCaseStatusChangedProcess

	/// <exclude/>
	public class SendEmailToCaseStatusChangedProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SendEmailToCaseStatusChangedProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: SubProcessSendEmailFlowElement

		/// <exclude/>
		public class SubProcessSendEmailFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public SubProcessSendEmailFlowElement(UserConnection userConnection, SendEmailToCaseStatusChangedProcess process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41");
			}

			#endregion

			#region Properties: Public

			public Guid CaseId {
				get {
					return GetParameterValue<Guid>("CaseId");
				}
				set {
					SetParameterValue("CaseId", value);
				}
			}

			public Guid TemplateId {
				get {
					return GetParameterValue<Guid>("TemplateId");
				}
				set {
					SetParameterValue("TemplateId", value);
				}
			}

			public string SenderEmail {
				get {
					return GetParameterValue<string>("SenderEmail");
				}
				set {
					SetParameterValue("SenderEmail", value);
				}
			}

			public string Subject {
				get {
					return GetParameterValue<string>("Subject");
				}
				set {
					SetParameterValue("Subject", value);
				}
			}

			public Guid ParentActivityId {
				get {
					return GetParameterValue<Guid>("ParentActivityId");
				}
				set {
					SetParameterValue("ParentActivityId", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (SendEmailToCaseStatusChangedProcess)owner;
				Name = "SubProcessSendEmail";
				SerializeToDB = true;
				IsLogging = false;
				SchemaElementUId = new Guid("3ad05c84-c9fa-4316-bb75-2bcaa742c41b");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (SendEmailToCaseStatusChangedProcess)Owner;
				SetParameterValue("CaseId", (Guid)((process.CaseRecordId)));
				SetParameterValue("TemplateId", (Guid)((process.EmailTemplate)));
				SetParameterValue("SenderEmail", new LocalizableString((process.EmailSender)));
			}

			#endregion

		}

		#endregion

		#region Class: ChangeDataUserTask1FlowElement

		/// <exclude/>
		public class ChangeDataUserTask1FlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataUserTask1FlowElement(UserConnection userConnection, SendEmailToCaseStatusChangedProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask1";
				IsLogging = false;
				SchemaElementUId = new Guid("a9434382-a448-40ee-b92f-07bbc051af96");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Owner", () => _recordColumnValues_Owner.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,86,81,83,219,48,12,254,43,92,158,49,231,56,137,19,247,141,177,110,199,195,128,131,29,47,148,7,199,150,219,220,210,36,151,184,108,172,215,255,62,57,105,75,187,149,46,229,110,3,242,146,68,39,201,159,100,125,146,230,158,202,101,211,92,200,41,120,3,239,195,213,151,155,210,216,147,79,89,110,161,254,92,151,179,202,59,246,26,168,51,153,103,63,65,119,242,161,206,236,71,105,37,26,204,71,79,246,35,111,48,218,229,97,228,29,143,188,204,194,180,65,13,52,224,17,51,137,207,128,24,19,199,36,212,134,146,132,82,77,20,55,198,79,24,13,184,86,157,230,110,215,103,229,180,146,53,116,39,180,206,77,251,249,245,177,114,138,62,10,84,171,146,53,101,177,20,6,14,66,51,44,100,154,131,198,127,91,207,0,69,182,206,166,24,9,124,205,166,112,37,107,60,201,249,41,157,8,149,140,204,27,167,149,131,177,195,31,85,13,77,147,149,197,126,104,249,108,90,108,234,162,57,172,127,151,96,104,139,208,105,94,73,59,105,29,156,35,168,69,139,241,116,60,174,97,44,109,246,176,9,225,27,60,182,122,253,114,135,6,26,239,231,86,230,51,216,56,115,59,142,51,89,217,46,156,238,120,84,168,179,241,164,103,164,235,108,253,45,88,134,194,106,165,220,203,227,78,252,140,163,240,193,9,58,31,171,207,145,119,119,222,92,126,47,160,190,81,19,152,202,46,99,247,39,40,253,77,48,204,97,10,133,29,204,69,156,38,41,141,56,81,148,11,18,138,88,19,169,253,136,68,12,211,201,33,22,138,199,11,52,88,3,26,204,21,36,138,50,206,9,24,25,145,48,148,130,164,198,36,132,113,29,104,233,67,10,198,44,238,59,224,89,83,229,242,241,118,141,239,76,54,112,212,88,105,103,205,145,154,200,98,12,250,228,26,84,89,235,101,214,221,11,245,34,188,190,36,160,1,17,198,71,88,156,199,68,68,2,72,154,114,10,65,28,37,148,25,44,18,124,92,249,32,86,101,2,65,184,31,41,18,210,196,39,2,34,180,85,177,79,131,56,142,5,55,251,146,125,94,60,71,159,240,61,210,231,166,77,111,63,10,245,75,221,142,18,244,247,115,104,133,193,241,8,12,212,80,40,232,74,112,29,167,43,133,77,181,109,186,185,246,120,247,102,8,215,70,187,65,184,101,149,34,67,2,72,83,108,64,90,113,36,79,194,72,18,6,62,209,137,66,106,48,3,90,117,217,91,31,119,13,101,5,133,43,155,13,135,7,56,250,131,80,79,14,145,11,247,238,202,25,139,162,88,27,65,164,146,146,132,81,74,137,144,12,217,10,34,213,65,40,176,47,250,123,217,208,92,204,242,252,57,70,176,93,140,96,111,156,17,109,75,236,71,136,126,217,59,156,16,167,40,25,23,0,251,41,81,22,86,42,219,237,8,237,53,172,16,182,125,46,47,199,153,146,249,101,5,181,92,58,166,187,51,191,117,101,110,88,212,101,105,119,240,175,61,105,21,122,234,251,90,132,161,114,69,136,125,61,80,134,136,132,134,132,165,16,167,76,7,28,36,197,36,226,14,228,98,191,41,103,181,90,238,29,77,183,252,188,104,173,121,133,117,229,144,29,100,231,22,208,167,205,188,219,153,253,111,39,240,43,140,215,67,103,230,51,147,232,37,151,190,53,55,250,182,249,131,251,248,43,52,104,56,180,235,254,151,102,182,240,22,191,0,254,173,109,108,195,13,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,82,193,110,219,48,12,253,149,65,232,49,10,36,91,182,228,28,219,94,2,52,67,176,180,189,204,59,208,34,181,26,112,236,192,118,6,180,129,255,189,178,106,47,201,144,219,116,144,32,146,239,241,233,137,39,118,215,191,31,136,173,216,253,118,179,107,92,191,124,104,90,90,110,219,198,82,215,45,159,26,11,85,249,1,69,69,91,104,97,79,61,181,175,80,29,169,123,42,187,126,241,237,18,196,22,236,238,79,200,177,213,207,19,91,247,180,127,89,163,103,38,133,86,67,42,57,198,145,228,10,19,224,89,162,145,163,209,20,91,97,8,139,204,131,109,83,29,247,245,134,122,216,66,255,198,86,39,22,216,60,129,22,105,36,80,8,78,138,128,43,131,146,103,14,45,87,137,142,156,69,131,74,22,108,88,176,206,190,209,30,66,211,51,88,74,237,251,186,140,155,72,39,30,18,43,110,148,148,92,218,52,149,50,177,148,89,28,193,83,253,25,56,6,177,236,14,21,188,191,222,202,29,174,12,185,204,158,242,47,87,115,182,202,111,251,58,157,187,32,248,218,217,107,83,115,182,200,217,174,57,182,118,100,19,254,242,120,33,41,52,8,37,255,92,103,23,125,164,62,86,213,20,121,132,30,230,194,57,220,96,233,74,194,117,189,155,205,11,44,98,90,252,198,54,175,47,109,255,3,219,64,13,191,169,253,238,159,127,214,254,87,229,179,183,112,38,46,162,44,17,90,58,174,9,50,174,40,141,184,31,3,63,72,50,43,92,172,253,7,187,40,160,127,144,163,150,106,75,215,194,100,90,80,156,38,146,27,71,17,87,50,241,243,128,40,56,24,17,163,74,77,140,24,79,248,46,184,61,142,239,164,107,180,106,96,195,240,107,248,4,51,178,17,55,46,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "224051120a8c4444870fdeb07a0f7277",
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

		public SendEmailToCaseStatusChangedProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SendEmailToCaseStatusChangedProcess";
			SchemaUId = new Guid("22405112-0a8c-4444-870f-deb07a0f7277");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_closeStatusId = () => { return (Guid)(new Guid("3e7f420c-f46b-1410-fc9a-0050ba5d6c38")); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("22405112-0a8c-4444-870f-deb07a0f7277");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SendEmailToCaseStatusChangedProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SendEmailToCaseStatusChangedProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual bool IsCloseAndExit {
			get;
			set;
		}

		public virtual Guid EmailTemplate {
			get;
			set;
		}

		public virtual Guid CaseRecordId {
			get;
			set;
		}

		private Func<Guid> _closeStatusId;
		public virtual Guid CloseStatusId {
			get {
				return (_closeStatusId ?? (_closeStatusId = () => Guid.Empty)).Invoke();
			}
			set {
				_closeStatusId = () => { return value; };
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
					SchemaElementUId = new Guid("d67fd76a-2fbe-4045-8049-736af35bdb13"),
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
					SchemaElementUId = new Guid("97b8b056-c069-497d-ad15-52df06e79c67"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask;
		public ProcessScriptTask ScriptTask {
			get {
				return _scriptTask ?? (_scriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask",
					SchemaElementUId = new Guid("87b14dd0-8690-4c2d-970a-35c3656cd9f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTaskExecute,
				});
			}
		}

		private SubProcessSendEmailFlowElement _subProcessSendEmail;
		public SubProcessSendEmailFlowElement SubProcessSendEmail {
			get {
				return _subProcessSendEmail ?? ((_subProcessSendEmail) = new SubProcessSendEmailFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("526b358c-eb90-47e8-8a27-4e49156b7f73"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
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
					SchemaElementUId = new Guid("2abdea98-cf8b-47f8-8868-0da495323261"),
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

		private ProcessConditionalFlow _conditionalSequenceFlow1;
		public ProcessConditionalFlow ConditionalSequenceFlow1 {
			get {
				return _conditionalSequenceFlow1 ?? (_conditionalSequenceFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow1",
					SchemaElementUId = new Guid("ebcf97b5-1631-42e6-8413-edda66493717"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessToken _exclusiveGateway1SubProcessSendEmailToken;
		public ProcessToken ExclusiveGateway1SubProcessSendEmailToken {
			get {
				return _exclusiveGateway1SubProcessSendEmailToken ?? (_exclusiveGateway1SubProcessSendEmailToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ExclusiveGateway1SubProcessSendEmailToken",
					SchemaElementUId = new Guid("86c57a19-7f39-4123-8196-42ed38dac958"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartSignal1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal1 };
			FlowElements[StartSignal2.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal2 };
			FlowElements[ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask };
			FlowElements[SubProcessSendEmail.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcessSendEmail };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ChangeDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ExclusiveGateway1SubProcessSendEmailToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1SubProcessSendEmailToken };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartSignal1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask", e.Context.SenderName));
						break;
					case "StartSignal2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask1", e.Context.SenderName));
						break;
					case "ScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "SubProcessSendEmail":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ChangeDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1SubProcessSendEmailToken", e.Context.SenderName));
						break;
					case "ExclusiveGateway1SubProcessSendEmailToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SubProcessSendEmail", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((IsCloseAndExit));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow1", "(IsCloseAndExit)", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("IsCloseAndExit")) {
				writer.WriteValue("IsCloseAndExit", IsCloseAndExit, false);
			}
			if (!HasMapping("EmailTemplate")) {
				writer.WriteValue("EmailTemplate", EmailTemplate, Guid.Empty);
			}
			if (!HasMapping("CaseRecordId")) {
				writer.WriteValue("CaseRecordId", CaseRecordId, Guid.Empty);
			}
			if (!HasMapping("EmailSender")) {
				writer.WriteValue("EmailSender", EmailSender, null);
			}
			if (!HasMapping("CloseStatusId")) {
				writer.WriteValue("CloseStatusId", CloseStatusId, Guid.Empty);
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
			MetaPathParameterValues.Add("94883989-46c7-4825-b827-2c151618e017", () => IsCloseAndExit);
			MetaPathParameterValues.Add("0d056708-d60e-42dd-86c1-f5efcfd86bef", () => EmailTemplate);
			MetaPathParameterValues.Add("e9f06e37-ba23-48d4-832c-0745bb5b6289", () => CaseRecordId);
			MetaPathParameterValues.Add("9fc90727-5ac3-4ea8-a541-e3baca1ade4f", () => CloseStatusId);
			MetaPathParameterValues.Add("6adbdb8d-22e9-4e5f-91e9-ac5d02328433", () => EmailSender);
			MetaPathParameterValues.Add("b45094d5-b09f-4ac1-94fb-eb15b5624972", () => StartSignal1.RecordId);
			MetaPathParameterValues.Add("0ea1b5d8-4e6c-43d5-a7b7-f9bb4610ae41", () => StartSignal1.EntitySchemaUId);
			MetaPathParameterValues.Add("ce8c0266-efa5-44a9-bff8-26d3da1ebeff", () => StartSignal2.RecordId);
			MetaPathParameterValues.Add("021c651a-8af8-4170-b888-138386e1329f", () => StartSignal2.EntitySchemaUId);
			MetaPathParameterValues.Add("2ea97d45-fb65-4126-9177-dd5587f15336", () => SubProcessSendEmail.CaseId);
			MetaPathParameterValues.Add("3f984456-427a-4177-9163-9b73842be371", () => SubProcessSendEmail.TemplateId);
			MetaPathParameterValues.Add("4ea09cbc-77f4-49ed-932b-bfc84d1131fb", () => SubProcessSendEmail.SenderEmail);
			MetaPathParameterValues.Add("e9652116-1fbc-423a-809f-5abee6bc90cb", () => SubProcessSendEmail.Subject);
			MetaPathParameterValues.Add("46ad5752-9bc9-40b5-8f41-4568b7813102", () => SubProcessSendEmail.ParentActivityId);
			MetaPathParameterValues.Add("810b9374-7a6a-46db-896a-f030e43430f9", () => ChangeDataUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("3e718202-15ca-44b5-b786-1c807f779f66", () => ChangeDataUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("6ff8853b-20dd-41d4-8339-8a3541af22e2", () => ChangeDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("84e64196-ae90-4d27-ba05-56b7d0cb5cf6", () => ChangeDataUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("bc3d543a-e907-49e5-9305-1badf49c0e15", () => ChangeDataUserTask1.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "IsCloseAndExit":
					if (!hasValueToRead) break;
					IsCloseAndExit = reader.GetValue<System.Boolean>();
				break;
				case "EmailTemplate":
					if (!hasValueToRead) break;
					EmailTemplate = reader.GetValue<System.Guid>();
				break;
				case "CaseRecordId":
					if (!hasValueToRead) break;
					CaseRecordId = reader.GetValue<System.Guid>();
				break;
				case "EmailSender":
					if (!hasValueToRead) break;
					EmailSender = reader.GetValue<System.String>();
				break;
				case "CloseStatusId":
					if (!hasValueToRead) break;
					CloseStatusId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTaskExecute(ProcessExecutingContext context) {
			var CaseRecordId = Guid.Empty;
			var categoryId = Guid.Empty;
			var statusId = Guid.Empty;
			var isMultilanguageEnabled = UserConnection.GetIsFeatureEnabled("EmailMessageMultiLanguage");
			IsCloseAndExit = false;
			if (StartSignal1.RecordId != Guid.Empty) {
				CaseRecordId = StartSignal1.RecordId;
			}
			if (StartSignal2.RecordId != Guid.Empty) {
				CaseRecordId = StartSignal2.RecordId;
			}
			
			var IsClassFeatureEnable = BPMSoft.Configuration.FeatureUtilities.GetIsFeatureEnabled(UserConnection, "SendEmailToCaseOnStatusChangeClass");
			if(IsClassFeatureEnable) {
				var classExecutor = new BPMSoft.Configuration.SendEmailToCaseOnStatusChange(UserConnection, CaseRecordId);
				classExecutor.Run();
				IsCloseAndExit = true;
				return true;
			}
			
			
			
			SubProcessSendEmail.CaseId = CaseRecordId;
			var isFinal = false;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Case");
			esq.AddColumn("Status");
			esq.AddColumn("Category");
			var IsResolvedColumn = esq.AddColumn("Status.IsResolved");
			var IsFinalColumnName = esq.AddColumn("Status.IsFinal").Name;
			esq.AddColumn("Contact");
			esq.AddColumn("Owner");
			//esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", CaseRecordId));
			var caseEntity = esq.GetEntity(UserConnection, CaseRecordId);
			if (caseEntity != null){
				categoryId = caseEntity.GetTypedColumnValue<Guid>("CategoryId");
				statusId = caseEntity.GetTypedColumnValue<Guid>("StatusId");
				var IsResolved = caseEntity.GetTypedColumnValue<bool>(IsResolvedColumn.Name);
				isFinal = caseEntity.GetTypedColumnValue<bool>(IsFinalColumnName);
				if (!IsResolved) {
					var update = new Update(UserConnection, "DelayedNotification")
						.Set("SendDate", Column.Const(null))
						.Where("CaseId").IsEqual(Column.Parameter(CaseRecordId))
						.And("EmailTemplateId").In(
							Column.Parameter(BPMSoft.Configuration.CaseServiceConsts.ResolutionNotificationTplId), 
							Column.Parameter(BPMSoft.Configuration.CaseServiceConsts.EstimationRequestTplId)
						);
						update.Execute();
				} else {
					var contactId = caseEntity.GetTypedColumnValue<Guid>("ContactId");
					var ownerId = caseEntity.GetTypedColumnValue<Guid>("OwnerId");
					if (contactId == ownerId) {
						IsCloseAndExit = true;
						var entitySchemaManager = UserConnection.EntitySchemaManager;
						var entitySchema = entitySchemaManager.GetInstanceByName("Case");
						Entity entityCase = entitySchema.CreateEntity(UserConnection);
						if (entityCase.FetchFromDB(CaseRecordId))
						{
							Guid closureCodeDefId = Guid.Empty;
							var closureCodeDefString = BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, 
								"CaseClosureCodeDef").ToString();
							entityCase.SetColumnValue("StatusId", CloseStatusId);
							entityCase.SetColumnValue("ClosureDate", UserConnection.CurrentUser.GetCurrentDateTime());
							if (Guid.TryParse(closureCodeDefString, out closureCodeDefId)) {
								entityCase.SetColumnValue("ClosureCodeId", closureCodeDefId);
							}
							entityCase.Save();
							return true;
						}
					}
				}
			}
			
			var emailSender = (string)BPMSoft.Core.Configuration.SysSettings.GetValue<string>(UserConnection, 
				"SupportServiceEmail", String.Empty);
			SubProcessSendEmail.SenderEmail = emailSender;
			var esq2 = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "CaseNotificationRule");
			esq2.AddColumn("EmailTemplate");
			esq2.AddColumn("RuleUsage");
			esq2.AddColumn("Delay");
			esq2.Filters.Add(esq2.CreateFilterWithParameters(FilterComparisonType.NotEqual, "RuleUsage", BPMSoft.Configuration.CaseConsts.DisableSendUsageType));
			esq2.Filters.Add(esq2.CreateFilterWithParameters(FilterComparisonType.Equal, "CaseStatus", statusId));
			esq2.Filters.Add(esq2.CreateFilterWithParameters(FilterComparisonType.Equal, "CaseCategory", categoryId));
			var emailTemplateCollection = esq2.GetEntityCollection(UserConnection);
			if (emailTemplateCollection.Count>0) {
				EmailTemplate = emailTemplateCollection[0].GetTypedColumnValue<Guid>("EmailTemplateId");
				if (isMultilanguageEnabled) {
					var emailTemplateStore = new BPMSoft.Configuration.EmailTemplateStore(UserConnection);
					var emailTemplateLanguageHelper = new BPMSoft.Configuration.EmailTemplateLanguageHelper(CaseRecordId, UserConnection);
					foreach (var emailTemplate in emailTemplateCollection) {
						var emailTemplateId = emailTemplate.GetTypedColumnValue<Guid>("EmailTemplateId");
						var languageId = emailTemplateLanguageHelper.GetLanguageId(emailTemplateId);
						var templateEntity = emailTemplateStore.GetTemplate(emailTemplateId, languageId);
						emailTemplate.SetColumnValue("EmailTemplateId", templateEntity.PrimaryColumnValue);
					}
				}
				SubProcessSendEmail.TemplateId = EmailTemplate;
				if(UserConnection.GetIsFeatureEnabled("DelayedNotification")) {
					var currentDate = DateTime.UtcNow;
					if(isFinal) {
						var delayedEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "DelayedNotification");
						delayedEsq.AddColumn("SendDate");
						delayedEsq.AddColumn("Case");
						delayedEsq.AddColumn("Delay");
						var idColumnName = delayedEsq.AddColumn("Id").Name;
						var filters = new[] {
							delayedEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Case", CaseRecordId),
							delayedEsq.CreateFilter(FilterComparisonType.IsNull, "SendDate")
						};
						delayedEsq.Filters.AddRange(filters);
						var delayedEmailCollection = delayedEsq.GetEntityCollection(UserConnection);
						if(delayedEmailCollection.Any()) {
							currentDate = DateTime.UtcNow;
							foreach(var delayedEmail in delayedEmailCollection) {
								var update = new Update(UserConnection, "DelayedNotification")
									.Set("SendDate", Column.Parameter(currentDate.AddMinutes(
											delayedEmail.GetTypedColumnValue<int>("Delay"))))
									.Where("Id").IsEqual(new QueryParameter(delayedEmail.GetTypedColumnValue<Guid>(idColumnName)));
								update.Execute();
							}
						}
					}
					var delayedNotification = emailTemplateCollection.Where(rule =>
									rule.GetTypedColumnValue<Guid>("RuleUsageId") == BPMSoft.Configuration.CaseConsts.DelaySendUsageType);
					if(delayedNotification.Any()) {
						foreach(var notification in delayedNotification) {
							var update = new Update(UserConnection, "DelayedNotification")
							.Set("SendDate", Column.Parameter(currentDate.AddMinutes(
									notification.GetTypedColumnValue<int>("Delay"))))
							.Where("CaseId").IsEqual(Column.Parameter(CaseRecordId))
							.And("EmailTemplateId").IsEqual(new QueryParameter(notification.GetTypedColumnValue<Guid>("EmailTemplateId")))
							.And("SendDate").IsEqual(Column.Const(null));
							var resultCount = update.Execute();
							if(resultCount == 0) {
							var insert = new Insert(UserConnection)
								.Into("DelayedNotification")
									.Set("CaseId", new QueryParameter(CaseRecordId))
									.Set("Delay", new QueryParameter(notification.GetTypedColumnValue<int>("Delay")))
									.Set("EmailTemplateId", new QueryParameter(notification.GetTypedColumnValue<Guid>("EmailTemplateId")))
									.Set("SendDate", Column.Parameter(currentDate.AddMinutes(
										notification.GetTypedColumnValue<int>("Delay")))) as Insert;
								insert.Execute();
							}
						}
					}
					var immediateNotification = emailTemplateCollection.Where(Rule =>
									Rule.GetTypedColumnValue<Guid>("RuleUsageId") == BPMSoft.Configuration.CaseConsts.ImmediateSendUsageType);
					if(immediateNotification.Any()) {
						var emailTemplateSender = new BPMSoft.Configuration.EmailWithMacrosManager(UserConnection);
						foreach(var notification in immediateNotification) {
							var tplId = notification.GetTypedColumnValue<Guid>("EmailTemplateId");
							try {
								emailTemplateSender.SendEmail(CaseRecordId, tplId);
							} catch {
								continue;
							}
						}
					}
					IsCloseAndExit = true;
					return true;
				}
				if(EmailTemplate == BPMSoft.Configuration.CaseConsts.SatisfactionSurveyTemplateId 
					&& UserConnection.GetIsFeatureEnabled("EstimateWithIcons")) {
				var emailWithMacrosSender = new BPMSoft.Configuration.EmailWithMacrosManager(UserConnection);
				emailWithMacrosSender.SendEmail(CaseRecordId, EmailTemplate);
				IsCloseAndExit = true;
				}
			} else {
				IsCloseAndExit = true;
				return true;
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
			var cloneItem = (SendEmailToCaseStatusChangedProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

