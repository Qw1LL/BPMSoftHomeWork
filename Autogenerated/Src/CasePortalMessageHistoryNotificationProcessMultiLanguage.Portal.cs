namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration.CaseService;
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
	using System.Text;

	#region Class: CasePortalMessageHistoryNotificationProcessMultiLanguageSchema

	/// <exclude/>
	public class CasePortalMessageHistoryNotificationProcessMultiLanguageSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CasePortalMessageHistoryNotificationProcessMultiLanguageSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CasePortalMessageHistoryNotificationProcessMultiLanguageSchema(CasePortalMessageHistoryNotificationProcessMultiLanguageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CasePortalMessageHistoryNotificationProcessMultiLanguage";
			UId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea");
			CreatedInPackageId = new Guid("18e91881-16c9-49f4-ab06-bb16b1eb7b07");
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
			Tag = @"Business process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea");
			Version = 0;
			PackageUId = new Guid("86855550-4426-427b-be00-b859353b97a8");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateRecordIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1e267b79-c922-45b4-9f6a-4bf64c884502"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsReopenCaseClassEnabledParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6429b14e-0647-4a96-8657-fc24f1b2d5f0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"IsReopenCaseClassEnabled",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateRecordIdParameter());
			Parameters.Add(CreateIsReopenCaseClassEnabledParameter());
		}

		protected virtual void InitializeSubProcessEmailSendParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var caseIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7940742d-4c38-4f07-90aa-bbaf23396e1b"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			caseIdParameter.SourceValue = new ProcessSchemaParameterValue(caseIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{801ca19e-32a1-4dd0-86c4-94f6d44efb9d}].[Parameter:{9e554e92-8851-42e7-a68a-cb5776dd061d}].[EntityColumn:{5ea77165-6b18-479b-920f-09df0aa69dc7}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(caseIdParameter);
			var templateIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				UId = new Guid("30c56724-4a36-4eb0-b3ec-f13a4f28763b"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			templateIdParameter.SourceValue = new ProcessSchemaParameterValue(templateIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#Lookup.93030575-f70f-4041-902e-c4badaf62c63.253cd392-267a-45bb-83b4-17630bcfa37b#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(templateIdParameter);
			var senderEmailParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7dc2f29b-acf6-4d95-99fd-f8103e8fe4ef"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText")
			};
			senderEmailParameter.SourceValue = new ProcessSchemaParameterValue(senderEmailParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#SysSettings.SupportServiceEmail<String>#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(senderEmailParameter);
			var subjectParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9bab31a2-e713-4aac-aec7-0af47ef03133"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText")
			};
			subjectParameter.SourceValue = new ProcessSchemaParameterValue(subjectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(subjectParameter);
			var parentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f999d377-f2a2-4b84-bc96-3817141124e5"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			parentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(parentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce")
			};
			parametrizedElement.Parameters.Add(parentActivityIdParameter);
			var isMultiLanguageEnabledParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c6945318-f46c-46b6-ab08-428ef28b4c07"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isMultiLanguageEnabledParameter.SourceValue = new ProcessSchemaParameterValue(isMultiLanguageEnabledParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(isMultiLanguageEnabledParameter);
			var isEstimateWithIconsEnabledParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ea12075a-9ee3-4fcb-976c-d58812bcaf4c"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isEstimateWithIconsEnabledParameter.SourceValue = new ProcessSchemaParameterValue(isEstimateWithIconsEnabledParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(isEstimateWithIconsEnabledParameter);
			var isMultilanguageV2EnabledParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7ccb2f00-6d4f-462b-a0ff-94b795795ba1"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isMultilanguageV2EnabledParameter.SourceValue = new ProcessSchemaParameterValue(isMultilanguageV2EnabledParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(isMultilanguageV2EnabledParameter);
		}

		protected virtual void InitializeSubProcessEmailSendFromPortalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var activityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5340039f-7871-4082-a0e0-e6362bb2dd10"),
				ContainerUId = new Guid("26357527-d117-40e6-836e-88dcad4d1726"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activityIdParameter.SourceValue = new ProcessSchemaParameterValue(activityIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{1e267b79-c922-45b4-9f6a-4bf64c884502}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(activityIdParameter);
			var caseOwnerIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8f8b331b-115e-475c-b2e8-98f47254cbb0"),
				ContainerUId = new Guid("26357527-d117-40e6-836e-88dcad4d1726"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			caseOwnerIdParameter.SourceValue = new ProcessSchemaParameterValue(caseOwnerIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(caseOwnerIdParameter);
			var caseIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("799dca73-d934-40af-abba-ae02499a48b3"),
				ContainerUId = new Guid("26357527-d117-40e6-836e-88dcad4d1726"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			caseIdParameter.SourceValue = new ProcessSchemaParameterValue(caseIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{801ca19e-32a1-4dd0-86c4-94f6d44efb9d}].[Parameter:{9e554e92-8851-42e7-a68a-cb5776dd061d}].[EntityColumn:{5ea77165-6b18-479b-920f-09df0aa69dc7}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(caseIdParameter);
			var subjectCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9a462fc2-e0f8-4213-92c4-7fae6dc0cb0a"),
				ContainerUId = new Guid("26357527-d117-40e6-836e-88dcad4d1726"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			subjectCaptionParameter.SourceValue = new ProcessSchemaParameterValue(subjectCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(subjectCaptionParameter);
			var assigneeIsClearedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8311e749-1a95-493b-b394-c65382471f6d"),
				ContainerUId = new Guid("26357527-d117-40e6-836e-88dcad4d1726"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			assigneeIsClearedParameter.SourceValue = new ProcessSchemaParameterValue(assigneeIsClearedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625")
			};
			parametrizedElement.Parameters.Add(assigneeIsClearedParameter);
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1c839231-432e-4ae7-b985-18aab77e3ce2"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,193,110,219,48,12,253,149,194,231,170,136,101,69,177,115,219,218,108,200,161,107,128,20,189,204,61,200,18,229,8,179,35,67,82,186,101,69,254,125,148,157,102,233,16,108,217,46,171,79,210,243,35,249,248,68,62,39,178,17,222,127,18,45,36,211,228,253,226,118,105,117,184,250,96,154,0,238,163,179,155,46,185,76,60,56,35,26,243,29,212,128,207,148,9,55,34,8,12,120,46,127,198,151,201,180,60,149,161,76,46,203,196,4,104,61,50,48,32,21,66,78,42,154,17,81,73,77,216,88,84,164,144,41,39,249,56,29,201,177,202,228,152,87,3,243,116,234,107,219,118,194,193,80,161,79,174,251,227,253,182,139,196,20,1,217,83,140,183,235,61,152,69,9,126,182,22,85,3,10,239,193,109,0,161,224,76,139,157,192,189,105,97,33,28,86,138,121,108,132,144,164,69,227,35,171,1,29,102,223,58,7,222,27,187,254,189,180,102,211,174,143,185,24,14,135,235,94,204,168,87,24,153,11,17,86,125,130,57,138,218,245,26,223,213,181,131,90,4,243,116,44,225,11,108,123,222,121,222,97,128,194,247,121,16,205,6,142,106,190,238,227,90,116,97,104,103,40,143,4,103,234,213,153,157,30,220,250,83,179,20,193,238,133,124,86,198,147,250,41,71,240,41,2,67,142,151,99,153,124,158,251,187,175,107,112,75,185,130,86,12,142,61,94,33,250,11,112,200,63,125,78,129,242,73,53,41,136,44,40,69,23,43,70,10,205,5,97,149,230,76,230,57,27,143,232,238,113,208,97,124,215,136,237,195,161,156,80,10,212,133,3,105,157,186,152,223,244,164,104,31,254,162,52,43,20,104,78,210,9,100,132,73,78,73,206,120,70,114,46,185,210,140,203,188,24,225,51,199,47,190,134,173,141,20,205,93,7,14,95,187,119,123,116,122,74,95,141,119,244,193,89,27,134,238,14,46,46,172,11,162,185,69,235,69,141,200,209,200,208,92,115,206,51,32,19,170,25,97,10,59,174,82,84,165,43,202,10,134,51,147,106,28,153,29,238,121,244,124,105,55,78,238,119,203,15,11,254,79,171,251,31,86,242,111,246,236,228,164,159,51,187,111,101,46,231,111,110,228,118,201,238,7,131,205,105,164,77,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("63e67c04-7f13-482d-8c89-337082ba72ab"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("449fc4b1-5119-446c-84a1-ba9099adea3e"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0153f965-f208-4361-ac51-7fd994fe7a63"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eaa421b0-a02b-48bf-b5dd-103c4146fd5e"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fe4a5b10-3bc9-427a-98fd-39f61d3a8e93"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("047636fd-130d-438b-89d4-f92c9cc9a1fa"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				UId = new Guid("9e554e92-8851-42e7-a68a-cb5776dd061d"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
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
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("204aea01-b339-4962-acf8-2fc22f24ebea"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("3560be14-03e4-4f50-a54e-8d950eb8f8ed"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("37c47e56-51c8-49d2-886c-c4cb83d1ab27"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2f25291e-94bb-458a-bd58-51b8899d3b6d"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("791a69c5-4753-49aa-a27f-5dcccba53986"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("147eb388-76cf-4593-9069-93f8861885fb"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				UId = new Guid("3c485674-96e7-4547-8a23-9566c858d20e"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4677117f-e5d2-47cc-b779-53c720b43249"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7bf6a11a-ea1e-431a-b4ae-c665cb57a1b1"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f3459f3a-6f92-4d97-abfa-e86899dc1053"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6e0b7354-5d91-41b8-bc56-32c46ff2b065"),
				ContainerUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaSubProcess subprocessemailsend = CreateSubProcessEmailSendSubProcess();
			FlowElements.Add(subprocessemailsend);
			ProcessSchemaSubProcess subprocessemailsendfromportal = CreateSubProcessEmailSendFromPortalSubProcess();
			FlowElements.Add(subprocessemailsendfromportal);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaScriptTask scripttask2 = CreateScriptTask2ScriptTask();
			FlowElements.Add(scripttask2);
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow2ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("6176c390-fbd4-4651-81ce-ea276113887e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ffadfddb-072a-44cc-8f2c-7d1a7d6cc4e7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(781, 114));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("0ba0ba60-c81d-4dc2-b1ed-6af1b600cbb8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f95b1bc9-0ce1-41e1-b3b5-5379137f66f2"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("18f22263-9410-41bc-a9fd-cad3e9a997f6"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("e8e00f98-1f59-489f-9354-d1b61f88e2c5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("18f22263-9410-41bc-a9fd-cad3e9a997f6"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("33d65c37-f40a-4df5-97a2-4dda8374508c"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{801ca19e-32a1-4dd0-86c4-94f6d44efb9d}].[Parameter:{9e554e92-8851-42e7-a68a-cb5776dd061d}].[EntityColumn:{e9fa984c-8b2f-487b-ba68-880d0e6341b5}]#] == false",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(365, 114));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("9d7273a6-906b-4dd8-9e9a-265be9e1517f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5db4bc35-a26a-4b5b-abec-d5c475497968"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(365, 284));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("0f023f2c-dbf6-423d-9423-8680f734fd6c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("26357527-d117-40e6-836e-88dcad4d1726"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ffadfddb-072a-44cc-8f2c-7d1a7d6cc4e7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(781, 285));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow2",
				UId = new Guid("6c39745b-4b2f-4d29-9843-fb6a5a13e219"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{6429b14e-0647-4a96-8657-fc24f1b2d5f0}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("86855550-4426-427b-be00-b859353b97a8"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5db4bc35-a26a-4b5b-abec-d5c475497968"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7686ee2b-c888-47be-9492-bb2a2b9b90c9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("26c7b453-569d-43da-952b-f90ea503f95b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("86855550-4426-427b-be00-b859353b97a8"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5db4bc35-a26a-4b5b-abec-d5c475497968"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("26357527-d117-40e6-836e-88dcad4d1726"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("dc52ed54-2a88-49ac-be05-0d687f76ee15"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("86855550-4426-427b-be00-b859353b97a8"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7686ee2b-c888-47be-9492-bb2a2b9b90c9"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ffadfddb-072a-44cc-8f2c-7d1a7d6cc4e7"),
				TargetSequenceFlowPointLocalPosition = new Point(1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(825, 447));
			schemaFlow.PolylinePointPositions.Add(new Point(825, 199));
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("534a3c51-a56a-4bb5-93a6-5723a904594c"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("417ae82c-7497-4157-940b-a1497fcc7b73"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("01214544-7f6c-4e04-a3d3-f67f78822327"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("534a3c51-a56a-4bb5-93a6-5723a904594c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("417ae82c-7497-4157-940b-a1497fcc7b73"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("f95b1bc9-0ce1-41e1-b3b5-5379137f66f2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("01214544-7f6c-4e04-a3d3-f67f78822327"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"StartEvent1",
				Position = new Point(88, 186),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("ffadfddb-072a-44cc-8f2c-7d1a7d6cc4e7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("01214544-7f6c-4e04-a3d3-f67f78822327"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"TerminateEvent1",
				Position = new Point(768, 186),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaSubProcess CreateSubProcessEmailSendSubProcess() {
			ProcessSchemaSubProcess schemaSubProcessEmailSend = new ProcessSchemaSubProcess(this) {
				UId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("01214544-7f6c-4e04-a3d3-f67f78822327"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"SubProcessEmailSend",
				Position = new Point(611, 87),
				SchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeSubProcessEmailSendParameters(schemaSubProcessEmailSend);
			return schemaSubProcessEmailSend;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("18f22263-9410-41bc-a9fd-cad3e9a997f6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("01214544-7f6c-4e04-a3d3-f67f78822327"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"ScriptTask1",
				Position = new Point(181, 172),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,69,205,65,10,194,48,16,133,225,189,167,8,93,41,72,46,80,186,168,65,165,11,165,84,122,128,104,95,202,64,152,148,204,100,225,237,173,88,112,251,224,123,127,39,3,210,2,118,94,224,162,23,57,179,127,70,76,166,49,167,254,246,72,65,173,75,28,104,46,217,43,37,182,23,120,45,25,163,82,36,37,136,189,66,59,217,214,13,239,71,65,94,25,227,245,53,71,83,13,133,255,157,150,167,123,82,10,239,86,132,102,198,47,92,29,234,93,198,250,194,70,115,65,253,1,60,248,202,92,154,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("01214544-7f6c-4e04-a3d3-f67f78822327"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"ReadDataUserTask1",
				Position = new Point(331, 172),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaSubProcess CreateSubProcessEmailSendFromPortalSubProcess() {
			ProcessSchemaSubProcess schemaSubProcessEmailSendFromPortal = new ProcessSchemaSubProcess(this) {
				UId = new Guid("26357527-d117-40e6-836e-88dcad4d1726"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("01214544-7f6c-4e04-a3d3-f67f78822327"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"SubProcessEmailSendFromPortal",
				Position = new Point(601, 257),
				SchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeSubProcessEmailSendFromPortalParameters(schemaSubProcessEmailSendFromPortal);
			return schemaSubProcessEmailSendFromPortal;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("5db4bc35-a26a-4b5b-abec-d5c475497968"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("01214544-7f6c-4e04-a3d3-f67f78822327"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("86855550-4426-427b-be00-b859353b97a8"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"ExclusiveGateway1",
				Position = new Point(448, 257),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask2ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("7686ee2b-c888-47be-9492-bb2a2b9b90c9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("01214544-7f6c-4e04-a3d3-f67f78822327"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("86855550-4426-427b-be00-b859353b97a8"),
				CreatedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"),
				Name = @"ScriptTask2",
				Position = new Point(441, 420),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,78,187,170,194,64,16,173,245,43,150,84,17,36,96,237,3,66,174,138,141,69,208,219,15,217,163,44,55,153,149,157,25,53,127,111,226,173,196,242,188,207,157,146,107,90,18,217,62,209,152,198,228,214,147,106,196,59,106,6,212,23,123,232,170,70,188,129,43,18,148,236,143,81,195,165,47,69,194,149,129,77,206,120,184,42,178,104,178,49,81,166,171,117,96,205,51,19,164,65,96,52,26,34,103,115,119,254,32,102,179,229,244,99,185,24,7,14,222,173,93,13,242,63,164,52,6,78,36,127,139,162,134,88,171,91,214,160,239,75,167,254,6,95,197,214,58,254,165,214,176,218,91,240,155,60,251,119,28,124,246,85,94,27,231,3,153,160,150,216,13,103,177,124,1,98,188,146,215,252,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("f51e0915-30e6-402e-b9d8-a9f4c3cc52b9"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("18e91881-16c9-49f4-ab06-bb16b1eb7b07")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("65192642-2bf0-4133-acdf-c68bb031ba29"),
				Name = "BPMSoft.Configuration.CaseService",
				Alias = "",
				CreatedInPackageId = new Guid("18e91881-16c9-49f4-ab06-bb16b1eb7b07")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CasePortalMessageHistoryNotificationProcessMultiLanguage(userConnection);
		}

		public override object Clone() {
			return new CasePortalMessageHistoryNotificationProcessMultiLanguageSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea"));
		}

		#endregion

	}

	#endregion

	#region Class: CasePortalMessageHistoryNotificationProcessMultiLanguage

	/// <exclude/>
	public class CasePortalMessageHistoryNotificationProcessMultiLanguage : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CasePortalMessageHistoryNotificationProcessMultiLanguage process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: SubProcessEmailSendFlowElement

		/// <exclude/>
		public class SubProcessEmailSendFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public SubProcessEmailSendFlowElement(UserConnection userConnection, CasePortalMessageHistoryNotificationProcessMultiLanguage process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("7c391a20-e766-436b-8c18-fe98a522ddce");
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

			public bool IsMultiLanguageEnabled {
				get {
					return GetParameterValue<bool>("IsMultiLanguageEnabled");
				}
				set {
					SetParameterValue("IsMultiLanguageEnabled", value);
				}
			}

			public bool IsEstimateWithIconsEnabled {
				get {
					return GetParameterValue<bool>("IsEstimateWithIconsEnabled");
				}
				set {
					SetParameterValue("IsEstimateWithIconsEnabled", value);
				}
			}

			public bool IsMultilanguageV2Enabled {
				get {
					return GetParameterValue<bool>("IsMultilanguageV2Enabled");
				}
				set {
					SetParameterValue("IsMultilanguageV2Enabled", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (CasePortalMessageHistoryNotificationProcessMultiLanguage)owner;
				Name = "SubProcessEmailSend";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (CasePortalMessageHistoryNotificationProcessMultiLanguage)Owner;
				SetParameterValue("CaseId", (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("EntityId").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("EntityId") : Guid.Empty))));
				SetParameterValue("TemplateId", (Guid)(new Guid("253cd392-267a-45bb-83b4-17630bcfa37b")));
				SetParameterValue("SenderEmail", new LocalizableString(((String)SysSettings.GetValue(UserConnection, "SupportServiceEmail"))));
			}

			#endregion

		}

		#endregion

		#region Class: ReadDataUserTask1FlowElement

		/// <exclude/>
		public class ReadDataUserTask1FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask1FlowElement(UserConnection userConnection, CasePortalMessageHistoryNotificationProcessMultiLanguage process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,193,110,219,48,12,253,149,194,231,170,136,101,69,177,115,219,218,108,200,161,107,128,20,189,204,61,200,18,229,8,179,35,67,82,186,101,69,254,125,148,157,102,233,16,108,217,46,171,79,210,243,35,249,248,68,62,39,178,17,222,127,18,45,36,211,228,253,226,118,105,117,184,250,96,154,0,238,163,179,155,46,185,76,60,56,35,26,243,29,212,128,207,148,9,55,34,8,12,120,46,127,198,151,201,180,60,149,161,76,46,203,196,4,104,61,50,48,32,21,66,78,42,154,17,81,73,77,216,88,84,164,144,41,39,249,56,29,201,177,202,228,152,87,3,243,116,234,107,219,118,194,193,80,161,79,174,251,227,253,182,139,196,20,1,217,83,140,183,235,61,152,69,9,126,182,22,85,3,10,239,193,109,0,161,224,76,139,157,192,189,105,97,33,28,86,138,121,108,132,144,164,69,227,35,171,1,29,102,223,58,7,222,27,187,254,189,180,102,211,174,143,185,24,14,135,235,94,204,168,87,24,153,11,17,86,125,130,57,138,218,245,26,223,213,181,131,90,4,243,116,44,225,11,108,123,222,121,222,97,128,194,247,121,16,205,6,142,106,190,238,227,90,116,97,104,103,40,143,4,103,234,213,153,157,30,220,250,83,179,20,193,238,133,124,86,198,147,250,41,71,240,41,2,67,142,151,99,153,124,158,251,187,175,107,112,75,185,130,86,12,142,61,94,33,250,11,112,200,63,125,78,129,242,73,53,41,136,44,40,69,23,43,70,10,205,5,97,149,230,76,230,57,27,143,232,238,113,208,97,124,215,136,237,195,161,156,80,10,212,133,3,105,157,186,152,223,244,164,104,31,254,162,52,43,20,104,78,210,9,100,132,73,78,73,206,120,70,114,46,185,210,140,203,188,24,225,51,199,47,190,134,173,141,20,205,93,7,14,95,187,119,123,116,122,74,95,141,119,244,193,89,27,134,238,14,46,46,172,11,162,185,69,235,69,141,200,209,200,208,92,115,206,51,32,19,170,25,97,10,59,174,82,84,165,43,202,10,134,51,147,106,28,153,29,238,121,244,124,105,55,78,238,119,203,15,11,254,79,171,251,31,86,242,111,246,236,228,164,159,51,187,111,101,46,231,111,110,228,118,201,238,7,131,205,105,164,77,6,0,0 })));
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
								new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"));
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

		#region Class: SubProcessEmailSendFromPortalFlowElement

		/// <exclude/>
		public class SubProcessEmailSendFromPortalFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public SubProcessEmailSendFromPortalFlowElement(UserConnection userConnection, CasePortalMessageHistoryNotificationProcessMultiLanguage process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625");
			}

			#endregion

			#region Properties: Public

			public Guid ActivityId {
				get {
					return GetParameterValue<Guid>("ActivityId");
				}
				set {
					SetParameterValue("ActivityId", value);
				}
			}

			public Guid CaseOwnerId {
				get {
					return GetParameterValue<Guid>("CaseOwnerId");
				}
				set {
					SetParameterValue("CaseOwnerId", value);
				}
			}

			public Guid CaseId {
				get {
					return GetParameterValue<Guid>("CaseId");
				}
				set {
					SetParameterValue("CaseId", value);
				}
			}

			public LocalizableString SubjectCaption {
				get {
					return GetParameterValue<LocalizableString>("SubjectCaption");
				}
				set {
					SetParameterValue("SubjectCaption", value);
				}
			}

			public bool AssigneeIsCleared {
				get {
					return GetParameterValue<bool>("AssigneeIsCleared");
				}
				set {
					SetParameterValue("AssigneeIsCleared", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (CasePortalMessageHistoryNotificationProcessMultiLanguage)owner;
				Name = "SubProcessEmailSendFromPortal";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("26357527-d117-40e6-836e-88dcad4d1726");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (CasePortalMessageHistoryNotificationProcessMultiLanguage)Owner;
				SetParameterValue("ActivityId", (Guid)((process.RecordId)));
				SetParameterValue("CaseId", (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("EntityId").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("EntityId") : Guid.Empty))));
			}

			#endregion

		}

		#endregion

		public CasePortalMessageHistoryNotificationProcessMultiLanguage(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CasePortalMessageHistoryNotificationProcessMultiLanguage";
			SchemaUId = new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea");
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
				return new Guid("bcb68c85-4f6b-4f1f-bb9c-dee432ca0bea");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CasePortalMessageHistoryNotificationProcessMultiLanguage, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CasePortalMessageHistoryNotificationProcessMultiLanguage, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid RecordId {
			get;
			set;
		}

		public virtual bool IsReopenCaseClassEnabled {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
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
					SchemaElementUId = new Guid("f95b1bc9-0ce1-41e1-b3b5-5379137f66f2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("ffadfddb-072a-44cc-8f2c-7d1a7d6cc4e7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private SubProcessEmailSendFlowElement _subProcessEmailSend;
		public SubProcessEmailSendFlowElement SubProcessEmailSend {
			get {
				return _subProcessEmailSend ?? ((_subProcessEmailSend) = new SubProcessEmailSendFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("18f22263-9410-41bc-a9fd-cad3e9a997f6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
				});
			}
		}

		private ReadDataUserTask1FlowElement _readDataUserTask1;
		public ReadDataUserTask1FlowElement ReadDataUserTask1 {
			get {
				return _readDataUserTask1 ?? (_readDataUserTask1 = new ReadDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private SubProcessEmailSendFromPortalFlowElement _subProcessEmailSendFromPortal;
		public SubProcessEmailSendFromPortalFlowElement SubProcessEmailSendFromPortal {
			get {
				return _subProcessEmailSendFromPortal ?? ((_subProcessEmailSendFromPortal) = new SubProcessEmailSendFromPortalFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("5db4bc35-a26a-4b5b-abec-d5c475497968"),
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

		private ProcessScriptTask _scriptTask2;
		public ProcessScriptTask ScriptTask2 {
			get {
				return _scriptTask2 ?? (_scriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask2",
					SchemaElementUId = new Guid("7686ee2b-c888-47be-9492-bb2a2b9b90c9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask2Execute,
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
					SchemaElementUId = new Guid("33d65c37-f40a-4df5-97a2-4dda8374508c"),
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
					SchemaElementUId = new Guid("6c39745b-4b2f-4d29-9843-fb6a5a13e219"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessToken _readDataUserTask1SubProcessEmailSendToken;
		public ProcessToken ReadDataUserTask1SubProcessEmailSendToken {
			get {
				return _readDataUserTask1SubProcessEmailSendToken ?? (_readDataUserTask1SubProcessEmailSendToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ReadDataUserTask1SubProcessEmailSendToken",
					SchemaElementUId = new Guid("ffc13d74-b7a5-4db5-bf4d-8f263b85253a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _exclusiveGateway1SubProcessEmailSendFromPortalToken;
		public ProcessToken ExclusiveGateway1SubProcessEmailSendFromPortalToken {
			get {
				return _exclusiveGateway1SubProcessEmailSendFromPortalToken ?? (_exclusiveGateway1SubProcessEmailSendFromPortalToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ExclusiveGateway1SubProcessEmailSendFromPortalToken",
					SchemaElementUId = new Guid("1f408ed2-fd4d-4950-8b6c-f79dbd04b198"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[SubProcessEmailSend.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcessEmailSend };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[SubProcessEmailSendFromPortal.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcessEmailSendFromPortal };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
			FlowElements[ReadDataUserTask1SubProcessEmailSendToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1SubProcessEmailSendToken };
			FlowElements[ExclusiveGateway1SubProcessEmailSendFromPortalToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1SubProcessEmailSendFromPortalToken };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "SubProcessEmailSend":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1SubProcessEmailSendToken", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "SubProcessEmailSendFromPortal":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalSequenceFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1SubProcessEmailSendFromPortalToken", e.Context.SenderName));
						break;
					case "ScriptTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1SubProcessEmailSendToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SubProcessEmailSend", e.Context.SenderName));
						break;
					case "ExclusiveGateway1SubProcessEmailSendFromPortalToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SubProcessEmailSendFromPortal", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("FromPortal").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<bool>("FromPortal") : false)) == false);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask1", "ConditionalSequenceFlow1", "((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName(\"FromPortal\").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<bool>(\"FromPortal\") : false)) == false", result);
			return result;
		}

		private bool ConditionalSequenceFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((IsReopenCaseClassEnabled));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalSequenceFlow2", "(IsReopenCaseClassEnabled)", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("RecordId")) {
				writer.WriteValue("RecordId", RecordId, Guid.Empty);
			}
			if (!HasMapping("IsReopenCaseClassEnabled")) {
				writer.WriteValue("IsReopenCaseClassEnabled", IsReopenCaseClassEnabled, false);
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
			MetaPathParameterValues.Add("1e267b79-c922-45b4-9f6a-4bf64c884502", () => RecordId);
			MetaPathParameterValues.Add("6429b14e-0647-4a96-8657-fc24f1b2d5f0", () => IsReopenCaseClassEnabled);
			MetaPathParameterValues.Add("7940742d-4c38-4f07-90aa-bbaf23396e1b", () => SubProcessEmailSend.CaseId);
			MetaPathParameterValues.Add("30c56724-4a36-4eb0-b3ec-f13a4f28763b", () => SubProcessEmailSend.TemplateId);
			MetaPathParameterValues.Add("7dc2f29b-acf6-4d95-99fd-f8103e8fe4ef", () => SubProcessEmailSend.SenderEmail);
			MetaPathParameterValues.Add("9bab31a2-e713-4aac-aec7-0af47ef03133", () => SubProcessEmailSend.Subject);
			MetaPathParameterValues.Add("f999d377-f2a2-4b84-bc96-3817141124e5", () => SubProcessEmailSend.ParentActivityId);
			MetaPathParameterValues.Add("c6945318-f46c-46b6-ab08-428ef28b4c07", () => SubProcessEmailSend.IsMultiLanguageEnabled);
			MetaPathParameterValues.Add("ea12075a-9ee3-4fcb-976c-d58812bcaf4c", () => SubProcessEmailSend.IsEstimateWithIconsEnabled);
			MetaPathParameterValues.Add("7ccb2f00-6d4f-462b-a0ff-94b795795ba1", () => SubProcessEmailSend.IsMultilanguageV2Enabled);
			MetaPathParameterValues.Add("1c839231-432e-4ae7-b985-18aab77e3ce2", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("63e67c04-7f13-482d-8c89-337082ba72ab", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("449fc4b1-5119-446c-84a1-ba9099adea3e", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("0153f965-f208-4361-ac51-7fd994fe7a63", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("eaa421b0-a02b-48bf-b5dd-103c4146fd5e", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("fe4a5b10-3bc9-427a-98fd-39f61d3a8e93", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("047636fd-130d-438b-89d4-f92c9cc9a1fa", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("9e554e92-8851-42e7-a68a-cb5776dd061d", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("204aea01-b339-4962-acf8-2fc22f24ebea", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("3560be14-03e4-4f50-a54e-8d950eb8f8ed", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("37c47e56-51c8-49d2-886c-c4cb83d1ab27", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("2f25291e-94bb-458a-bd58-51b8899d3b6d", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("791a69c5-4753-49aa-a27f-5dcccba53986", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("147eb388-76cf-4593-9069-93f8861885fb", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("3c485674-96e7-4547-8a23-9566c858d20e", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("4677117f-e5d2-47cc-b779-53c720b43249", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("7bf6a11a-ea1e-431a-b4ae-c665cb57a1b1", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("f3459f3a-6f92-4d97-abfa-e86899dc1053", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("6e0b7354-5d91-41b8-bc56-32c46ff2b065", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("5340039f-7871-4082-a0e0-e6362bb2dd10", () => SubProcessEmailSendFromPortal.ActivityId);
			MetaPathParameterValues.Add("8f8b331b-115e-475c-b2e8-98f47254cbb0", () => SubProcessEmailSendFromPortal.CaseOwnerId);
			MetaPathParameterValues.Add("799dca73-d934-40af-abba-ae02499a48b3", () => SubProcessEmailSendFromPortal.CaseId);
			MetaPathParameterValues.Add("9a462fc2-e0f8-4213-92c4-7fae6dc0cb0a", () => SubProcessEmailSendFromPortal.SubjectCaption);
			MetaPathParameterValues.Add("8311e749-1a95-493b-b394-c65382471f6d", () => SubProcessEmailSendFromPortal.AssigneeIsCleared);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "RecordId":
					if (!hasValueToRead) break;
					RecordId = reader.GetValue<System.Guid>();
				break;
				case "IsReopenCaseClassEnabled":
					if (!hasValueToRead) break;
					IsReopenCaseClassEnabled = reader.GetValue<System.Boolean>();
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
			IsReopenCaseClassEnabled = BPMSoft.Configuration.FeatureUtilities.GetIsFeatureEnabled(UserConnection, "RunReopenCaseAndNotifyAssigneeClass");
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			var classExecutor =	ClassFactory.Get<ReopenCaseAndNotifyAssignee>(new ConstructorArgument("userConnection", UserConnection));
			classExecutor.CaseId = ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("EntityId");
			classExecutor.Run();
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
			var cloneItem = (CasePortalMessageHistoryNotificationProcessMultiLanguage)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

