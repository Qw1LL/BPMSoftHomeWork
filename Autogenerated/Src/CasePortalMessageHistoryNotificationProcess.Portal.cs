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

	#region Class: CasePortalMessageHistoryNotificationProcessSchema

	/// <exclude/>
	public class CasePortalMessageHistoryNotificationProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CasePortalMessageHistoryNotificationProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CasePortalMessageHistoryNotificationProcessSchema(CasePortalMessageHistoryNotificationProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CasePortalMessageHistoryNotificationProcess";
			UId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d");
			CreatedInPackageId = new Guid("417ae82c-7497-4157-940b-a1497fcc7b73");
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
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d");
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateRecordIdParameter());
		}

		protected virtual void InitializeSubProcessEmailSendParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var caseIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d18ae54e-9fdf-4bb7-b200-9ece5f40603b"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{801ca19e-32a1-4dd0-86c4-94f6d44efb9d}].[Parameter:{9e554e92-8851-42e7-a68a-cb5776dd061d}].[EntityColumn:{5ea77165-6b18-479b-920f-09df0aa69dc7}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
			};
			parametrizedElement.Parameters.Add(caseIdParameter);
			var templateIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("03c312c5-7b64-4476-ada2-9324437924d2"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				Value = @"[#Lookup.93030575-f70f-4041-902e-c4badaf62c63.253cd392-267a-45bb-83b4-17630bcfa37b#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
			};
			parametrizedElement.Parameters.Add(templateIdParameter);
			var senderEmailParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8eb22ddd-93e1-40d4-bd20-bcdb3643964b"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				Value = @"[#SysSettings.SupportServiceEmail#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
			};
			parametrizedElement.Parameters.Add(senderEmailParameter);
			var subjectParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a2e421d-cd24-4911-a2a1-8959f1aa19f1"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				UId = new Guid("b5c39435-242d-4efb-9628-fea25fe60b34"),
				ContainerUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9"),
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
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
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
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
			};
			parametrizedElement.Parameters.Add(caseIdParameter);
			var subjectCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9da230a2-8439-4e71-b11a-e10a64158105"),
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
				UId = new Guid("da9d1889-8aa9-4b18-a343-bc92826c45d9"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,20,252,43,65,135,158,172,98,89,178,100,187,199,101,91,246,146,6,154,150,66,178,132,39,233,41,43,240,199,198,146,105,130,217,255,94,121,157,109,33,135,82,232,169,160,131,244,164,153,55,51,60,205,15,62,124,244,109,196,177,113,208,6,204,166,157,109,72,81,57,41,37,71,170,10,39,168,176,69,65,53,147,156,58,93,136,90,148,150,51,167,73,214,67,135,13,89,209,91,235,35,201,124,196,46,52,119,243,111,210,56,78,152,61,184,243,225,139,57,96,7,95,151,6,92,58,173,82,11,234,68,105,168,168,156,162,26,203,156,50,85,25,5,86,35,55,57,89,181,48,0,163,116,193,41,104,227,168,40,65,211,218,48,73,171,146,229,38,73,49,165,76,90,90,116,113,251,124,28,49,4,63,244,205,140,191,246,183,47,199,164,114,237,189,25,218,169,235,73,214,97,132,27,136,135,134,0,230,152,36,0,53,162,46,169,112,168,40,240,218,82,14,90,21,170,66,38,153,34,153,129,99,92,104,201,206,146,204,66,132,111,208,78,120,102,158,253,146,23,207,89,85,202,132,101,60,217,225,69,78,43,89,41,234,172,116,53,114,89,215,218,94,242,250,52,249,180,247,225,122,234,112,244,230,53,118,76,249,13,99,51,155,161,143,227,208,46,212,215,231,231,183,248,28,215,112,95,175,190,175,134,98,170,47,32,114,202,166,128,155,214,99,31,183,189,25,172,239,31,87,206,211,41,65,186,35,140,62,92,82,216,62,77,208,146,108,244,143,135,63,166,181,153,66,28,186,255,200,106,150,108,38,142,52,100,103,185,203,12,90,31,142,45,188,156,207,13,121,247,52,13,241,195,206,94,129,181,104,175,70,52,195,104,215,34,121,3,110,200,61,97,88,72,165,85,77,77,157,102,95,148,90,208,218,73,160,66,59,41,76,85,137,50,47,238,73,18,244,111,109,238,118,225,243,143,254,242,51,86,47,251,247,169,250,166,112,115,65,54,243,223,40,59,237,23,109,251,83,90,63,1,243,33,183,254,224,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
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
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
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
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
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
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
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
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
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
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,113,205,43,201,44,169,12,78,206,72,205,77,12,245,76,177,50,180,50,4,0,180,231,190,201,26,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
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
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
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
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
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
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d")
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
				UId = new Guid("88e2de2a-add6-4298-be37-627b471e8b33"),
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
				UId = new Guid("0c958298-467d-410d-82aa-08fbc08fff62"),
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
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("6176c390-fbd4-4651-81ce-ea276113887e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("dd03a7ff-dcd1-4d80-9873-801a6ca50c91"),
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
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
			schemaFlow.PolylinePointPositions.Add(new Point(781, 115));
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("801ca19e-32a1-4dd0-86c4-94f6d44efb9d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("26357527-d117-40e6-836e-88dcad4d1726"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(365, 285));
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
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

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("534a3c51-a56a-4bb5-93a6-5723a904594c"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("417ae82c-7497-4157-940b-a1497fcc7b73"),
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(1015, 400),
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(986, 400),
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Name = @"StartEvent1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(88, 186),
				SerializeToDB = false,
				Size = new Size(0, 0),
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Name = @"TerminateEvent1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(768, 186),
				SerializeToDB = false,
				Size = new Size(0, 0),
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Name = @"SubProcessEmailSend",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(611, 87),
				SchemaUId = new Guid("010a69df-55e1-475c-937c-0184594f2e41"),
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Name = @"ScriptTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(181, 172),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,74,45,41,45,202,83,40,41,42,77,181,6,0,0,22,62,211,12,0,0,0 }
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Name = @"ReadDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(331, 172),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
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
				CreatedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d"),
				Name = @"SubProcessEmailSendFromPortal",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(601, 257),
				SchemaUId = new Guid("53d09a3b-5a42-48cd-bd0c-f36c9a389625"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeSubProcessEmailSendFromPortalParameters(schemaSubProcessEmailSendFromPortal);
			return schemaSubProcessEmailSendFromPortal;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CasePortalMessageHistoryNotificationProcess(userConnection);
		}

		public override object Clone() {
			return new CasePortalMessageHistoryNotificationProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1dd861d3-d807-46dc-a479-19f56167521d"));
		}

		#endregion

	}

	#endregion

	#region Class: CasePortalMessageHistoryNotificationProcess

	/// <exclude/>
	public class CasePortalMessageHistoryNotificationProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CasePortalMessageHistoryNotificationProcess process)
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

			public SubProcessEmailSendFlowElement(UserConnection userConnection, CasePortalMessageHistoryNotificationProcess process)
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
				var process = (CasePortalMessageHistoryNotificationProcess)owner;
				Name = "SubProcessEmailSend";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("5487fda2-b472-45f4-b69d-8042a08c72b9");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (CasePortalMessageHistoryNotificationProcess)Owner;
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, CasePortalMessageHistoryNotificationProcess process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,20,252,43,65,135,158,172,98,89,178,100,187,199,101,91,246,146,6,154,150,66,178,132,39,233,41,43,240,199,198,146,105,130,217,255,94,121,157,109,33,135,82,232,169,160,131,244,164,153,55,51,60,205,15,62,124,244,109,196,177,113,208,6,204,166,157,109,72,81,57,41,37,71,170,10,39,168,176,69,65,53,147,156,58,93,136,90,148,150,51,167,73,214,67,135,13,89,209,91,235,35,201,124,196,46,52,119,243,111,210,56,78,152,61,184,243,225,139,57,96,7,95,151,6,92,58,173,82,11,234,68,105,168,168,156,162,26,203,156,50,85,25,5,86,35,55,57,89,181,48,0,163,116,193,41,104,227,168,40,65,211,218,48,73,171,146,229,38,73,49,165,76,90,90,116,113,251,124,28,49,4,63,244,205,140,191,246,183,47,199,164,114,237,189,25,218,169,235,73,214,97,132,27,136,135,134,0,230,152,36,0,53,162,46,169,112,168,40,240,218,82,14,90,21,170,66,38,153,34,153,129,99,92,104,201,206,146,204,66,132,111,208,78,120,102,158,253,146,23,207,89,85,202,132,101,60,217,225,69,78,43,89,41,234,172,116,53,114,89,215,218,94,242,250,52,249,180,247,225,122,234,112,244,230,53,118,76,249,13,99,51,155,161,143,227,208,46,212,215,231,231,183,248,28,215,112,95,175,190,175,134,98,170,47,32,114,202,166,128,155,214,99,31,183,189,25,172,239,31,87,206,211,41,65,186,35,140,62,92,82,216,62,77,208,146,108,244,143,135,63,166,181,153,66,28,186,255,200,106,150,108,38,142,52,100,103,185,203,12,90,31,142,45,188,156,207,13,121,247,52,13,241,195,206,94,129,181,104,175,70,52,195,104,215,34,121,3,110,200,61,97,88,72,165,85,77,77,157,102,95,148,90,208,218,73,160,66,59,41,76,85,137,50,47,238,73,18,244,111,109,238,118,225,243,143,254,242,51,86,47,251,247,169,250,166,112,115,65,54,243,223,40,59,237,23,109,251,83,90,63,1,243,33,183,254,224,3,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,113,205,43,201,44,169,12,78,206,72,205,77,12,245,76,177,50,180,50,4,0,180,231,190,201,26,0,0,0 })));
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

			public SubProcessEmailSendFromPortalFlowElement(UserConnection userConnection, CasePortalMessageHistoryNotificationProcess process)
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
				var process = (CasePortalMessageHistoryNotificationProcess)owner;
				Name = "SubProcessEmailSendFromPortal";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("26357527-d117-40e6-836e-88dcad4d1726");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (CasePortalMessageHistoryNotificationProcess)Owner;
				SetParameterValue("ActivityId", (Guid)((process.RecordId)));
				SetParameterValue("CaseId", (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("EntityId").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("EntityId") : Guid.Empty))));
			}

			#endregion

		}

		#endregion

		public CasePortalMessageHistoryNotificationProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CasePortalMessageHistoryNotificationProcess";
			SchemaUId = new Guid("1dd861d3-d807-46dc-a479-19f56167521d");
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
				return new Guid("1dd861d3-d807-46dc-a479-19f56167521d");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CasePortalMessageHistoryNotificationProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CasePortalMessageHistoryNotificationProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid RecordId {
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

		private ProcessToken _readDataUserTask1SubProcessEmailSendToken;
		public ProcessToken ReadDataUserTask1SubProcessEmailSendToken {
			get {
				return _readDataUserTask1SubProcessEmailSendToken ?? (_readDataUserTask1SubProcessEmailSendToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ReadDataUserTask1SubProcessEmailSendToken",
					SchemaElementUId = new Guid("55ca2175-4b5e-4c5c-a1ec-e8c08e3dd953"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _readDataUserTask1SubProcessEmailSendFromPortalToken;
		public ProcessToken ReadDataUserTask1SubProcessEmailSendFromPortalToken {
			get {
				return _readDataUserTask1SubProcessEmailSendFromPortalToken ?? (_readDataUserTask1SubProcessEmailSendFromPortalToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ReadDataUserTask1SubProcessEmailSendFromPortalToken",
					SchemaElementUId = new Guid("e9861908-31bc-4c1a-bd23-255db0b1837f"),
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
			FlowElements[ReadDataUserTask1SubProcessEmailSendToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1SubProcessEmailSendToken };
			FlowElements[ReadDataUserTask1SubProcessEmailSendFromPortalToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1SubProcessEmailSendFromPortalToken };
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
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1SubProcessEmailSendFromPortalToken", e.Context.SenderName));
						break;
					case "SubProcessEmailSendFromPortal":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1SubProcessEmailSendToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SubProcessEmailSend", e.Context.SenderName));
						break;
					case "ReadDataUserTask1SubProcessEmailSendFromPortalToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SubProcessEmailSendFromPortal", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("FromPortal").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<bool>("FromPortal") : false)) == false);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask1", "ConditionalSequenceFlow1", "((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName(\"FromPortal\").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<bool>(\"FromPortal\") : false)) == false", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("RecordId")) {
				writer.WriteValue("RecordId", RecordId, Guid.Empty);
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
			MetaPathParameterValues.Add("d18ae54e-9fdf-4bb7-b200-9ece5f40603b", () => SubProcessEmailSend.CaseId);
			MetaPathParameterValues.Add("03c312c5-7b64-4476-ada2-9324437924d2", () => SubProcessEmailSend.TemplateId);
			MetaPathParameterValues.Add("8eb22ddd-93e1-40d4-bd20-bcdb3643964b", () => SubProcessEmailSend.SenderEmail);
			MetaPathParameterValues.Add("0a2e421d-cd24-4911-a2a1-8959f1aa19f1", () => SubProcessEmailSend.Subject);
			MetaPathParameterValues.Add("b5c39435-242d-4efb-9628-fea25fe60b34", () => SubProcessEmailSend.ParentActivityId);
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
			MetaPathParameterValues.Add("88e2de2a-add6-4298-be37-627b471e8b33", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("0c958298-467d-410d-82aa-08fbc08fff62", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("5340039f-7871-4082-a0e0-e6362bb2dd10", () => SubProcessEmailSendFromPortal.ActivityId);
			MetaPathParameterValues.Add("8f8b331b-115e-475c-b2e8-98f47254cbb0", () => SubProcessEmailSendFromPortal.CaseOwnerId);
			MetaPathParameterValues.Add("799dca73-d934-40af-abba-ae02499a48b3", () => SubProcessEmailSendFromPortal.CaseId);
			MetaPathParameterValues.Add("9da230a2-8439-4e71-b11a-e10a64158105", () => SubProcessEmailSendFromPortal.SubjectCaption);
			MetaPathParameterValues.Add("da9d1889-8aa9-4b18-a343-bc92826c45d9", () => SubProcessEmailSendFromPortal.AssigneeIsCleared);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "RecordId":
					if (!hasValueToRead) break;
					RecordId = reader.GetValue<System.Guid>();
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
			var cloneItem = (CasePortalMessageHistoryNotificationProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

