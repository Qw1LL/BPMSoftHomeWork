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

	#region Class: LeadManagementDistribution10Schema

	/// <exclude/>
	public class LeadManagementDistribution10Schema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LeadManagementDistribution10Schema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LeadManagementDistribution10Schema(LeadManagementDistribution10Schema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LeadManagementDistribution10";
			UId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe");
			CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"LeadManagementDistribution10";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe");
			Version = 0;
			PackageUId = new Guid("34a08715-d94b-478c-887e-dbb951baceeb");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateLeadIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("30cf6943-a881-4c30-a088-ff65572e4241"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"LeadId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateReminderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9cd3f863-0eda-4338-895e-97f82adfe406"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"CreateReminder",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{3e566048-ef49-45bf-9d2d-500669220b4e}].[Parameter:{cd5eefc4-6c19-4719-be10-6babbc9acc6e}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateResponsibleIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("77bfc541-1a1a-4b5e-bd77-3e429c4b637f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"ResponsibleId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{3e566048-ef49-45bf-9d2d-500669220b4e}].[Parameter:{0d01d7bb-ccf9-4184-a64f-953b68988ea4}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateShowDistributionPageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("51139bfa-4db4-45f7-aa2f-590d604f8469"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"ShowDistributionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"false",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNotificationTemplateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("32a9ba6f-4045-4aad-9a53-b618b30c6a99"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"NotificationTemplate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateLeadIdParameter());
			Parameters.Add(CreateCreateReminderParameter());
			Parameters.Add(CreateResponsibleIdParameter());
			Parameters.Add(CreateShowDistributionPageParameter());
			Parameters.Add(CreateNotificationTemplateParameter());
		}

		protected virtual void InitializeSaveLeadHandoffParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("188fdd38-de95-4c10-8ab3-34128e7e82c9"),
				ContainerUId = new Guid("79bed3ce-b5f5-4199-a64d-91f1eede0c61"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9cad839f-9e67-4603-a369-f4c25fce8216"),
				ContainerUId = new Guid("79bed3ce-b5f5-4199-a64d-91f1eede0c61"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("51b908e1-277f-4fd9-954b-c200b506502f"),
				ContainerUId = new Guid("79bed3ce-b5f5-4199-a64d-91f1eede0c61"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,211,64,16,253,47,62,119,171,245,122,253,213,27,148,128,34,1,141,148,170,151,186,135,137,61,78,86,216,177,181,187,41,132,40,255,157,89,111,98,82,20,65,224,66,125,242,62,189,121,243,230,107,23,148,13,24,243,25,90,12,110,130,183,179,79,243,174,182,215,239,85,99,81,127,208,221,166,15,174,2,131,90,65,163,190,99,229,241,73,165,236,59,176,64,1,187,226,103,124,17,220,20,231,20,138,224,170,8,148,197,214,16,131,2,32,225,40,50,137,44,142,36,103,50,134,148,45,132,172,88,152,98,44,69,20,213,89,46,61,243,188,244,109,215,246,160,209,103,24,196,235,225,247,126,219,59,98,72,64,57,80,148,233,214,7,48,114,22,204,100,13,139,6,43,122,91,189,65,130,172,86,45,85,130,247,170,197,25,104,202,228,116,58,7,17,169,134,198,56,86,131,181,157,124,235,53,26,163,186,245,239,173,53,155,118,125,202,165,112,28,159,7,51,124,112,232,152,51,176,171,65,96,74,166,246,131,199,55,203,165,198,37,88,245,124,106,225,11,110,7,222,101,189,163,128,138,230,243,0,205,6,79,114,190,172,227,22,122,235,203,241,233,137,160,213,114,117,97,165,99,183,254,84,172,32,176,63,146,47,82,60,235,95,36,4,62,59,192,107,28,127,139,224,113,106,238,190,174,81,207,203,21,182,224,59,246,116,77,232,47,192,168,127,179,139,120,89,39,185,140,24,100,89,200,100,25,113,6,60,203,88,93,39,113,156,10,148,66,134,251,39,239,67,153,190,129,237,195,152,238,35,130,111,150,235,25,189,51,94,135,41,164,192,144,139,152,73,153,84,12,22,85,196,48,15,105,36,121,190,224,113,74,179,117,159,27,65,183,84,37,52,119,61,106,26,241,208,98,126,126,53,95,236,180,43,94,119,157,245,37,141,173,27,189,28,215,131,87,98,33,0,36,19,137,76,153,172,92,97,121,153,57,91,117,204,171,20,120,9,100,134,110,218,245,119,222,109,116,121,184,35,227,143,249,159,206,244,63,156,223,223,220,212,217,173,190,100,79,95,203,14,78,95,203,166,237,131,253,15,163,181,209,2,48,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e91b04af-7a52-4f54-a02b-32ac50a9f8ad"),
				ContainerUId = new Guid("79bed3ce-b5f5-4199-a64d-91f1eede0c61"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,91,111,219,86,12,199,191,138,161,246,49,52,206,253,226,199,181,3,22,32,217,130,101,235,75,156,135,115,33,87,99,182,21,72,114,135,206,240,119,31,229,216,77,82,116,73,134,97,232,10,196,15,178,116,44,254,73,145,231,39,210,219,230,245,240,241,6,155,89,243,221,197,249,101,75,195,244,77,219,225,244,162,107,11,246,253,244,172,45,105,185,248,51,229,37,94,164,46,173,112,192,238,93,90,110,176,63,91,244,195,201,228,190,81,115,210,188,254,176,255,173,153,93,109,155,211,1,87,191,158,86,86,206,54,122,101,131,129,152,40,131,73,53,64,138,37,241,153,55,154,162,18,185,6,54,46,237,114,179,90,159,227,144,46,210,240,190,153,109,155,189,218,40,80,68,81,213,9,176,73,87,48,193,8,72,201,32,20,39,48,121,239,80,9,215,236,78,154,190,188,199,85,218,59,189,51,54,50,81,136,24,193,91,193,222,49,103,8,37,21,32,210,49,59,22,147,88,70,227,195,253,119,134,87,175,206,218,246,247,205,205,84,41,109,100,169,18,108,214,26,76,97,247,81,72,9,142,188,139,26,201,161,49,211,130,217,139,172,11,196,96,137,99,116,30,18,250,2,33,80,172,213,75,225,66,120,117,61,58,170,139,254,102,153,62,190,251,91,127,103,152,234,164,31,210,111,56,253,33,173,107,75,52,25,218,73,159,150,216,223,42,220,60,40,197,125,141,237,252,182,158,243,102,54,255,114,69,15,223,151,251,84,61,172,233,195,114,206,155,147,121,115,217,110,186,50,170,105,190,120,123,47,240,189,131,253,45,159,93,30,235,199,43,235,205,114,121,88,121,155,134,116,188,241,184,220,214,5,45,176,158,174,47,143,101,219,171,136,195,7,190,112,56,126,110,99,251,55,102,231,105,205,249,237,126,228,199,191,139,253,83,148,191,112,10,143,194,89,69,43,188,36,240,152,34,239,31,167,32,84,153,32,202,152,73,123,173,136,212,222,250,103,36,236,112,93,240,97,96,207,217,61,7,251,126,159,237,17,156,67,92,99,170,118,205,110,119,114,31,39,22,115,222,120,226,71,147,8,70,87,222,105,65,4,240,213,16,122,139,38,167,242,40,78,86,5,233,181,9,28,140,144,96,132,180,144,188,115,80,178,20,197,103,107,77,9,255,5,78,87,167,253,79,127,172,177,187,205,207,140,210,178,199,235,41,175,126,182,240,105,87,206,182,222,103,42,214,72,144,137,83,110,178,69,200,213,123,208,104,84,44,38,59,237,105,119,253,36,87,35,80,237,232,250,133,159,111,142,31,233,50,106,103,37,4,66,5,70,218,200,246,149,59,64,16,186,26,23,116,173,250,31,241,147,19,135,227,34,83,99,72,140,1,121,136,232,120,67,43,83,136,162,201,89,198,71,249,81,62,18,106,20,224,99,97,1,10,2,88,147,128,172,171,164,140,37,19,203,255,132,159,88,170,166,224,52,8,172,204,143,214,1,66,100,136,162,167,160,82,37,52,194,61,205,207,155,14,211,128,147,14,87,139,117,197,110,66,109,247,130,211,87,106,71,81,100,103,51,5,16,68,133,113,224,119,99,240,62,130,50,74,240,73,162,40,252,99,56,61,59,176,231,226,228,52,207,119,232,120,27,107,197,237,200,10,199,96,165,12,154,120,228,17,86,231,108,229,163,56,37,35,146,51,148,32,241,52,199,237,8,29,68,227,89,197,198,34,43,229,28,53,125,77,156,190,95,226,10,215,195,108,171,209,58,39,184,111,34,19,206,79,154,9,98,85,21,172,16,206,69,197,115,172,193,221,67,254,130,82,158,123,43,2,191,101,184,249,139,36,33,105,210,160,164,80,72,150,75,228,211,211,252,241,224,53,116,139,188,25,22,237,122,114,51,206,133,151,227,48,56,169,139,15,139,158,215,94,186,218,55,215,213,108,13,198,186,108,64,90,110,36,166,162,133,44,248,192,255,144,164,32,231,163,45,79,98,120,189,251,11,184,208,186,240,190,13,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1f789915-973d-451b-b755-63de28256494"),
				ContainerUId = new Guid("79bed3ce-b5f5-4199-a64d-91f1eede0c61"),
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

		protected virtual void InitializeSaveLeadNoInterestParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("a147d2f0-eb4f-4a91-bda3-6b4d5423014b"),
				ContainerUId = new Guid("7969b2cd-51e0-490c-b289-63e0473f9af3"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d71bf98b-10c9-4b4e-9da3-927f4c707df2"),
				ContainerUId = new Guid("7969b2cd-51e0-490c-b289-63e0473f9af3"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8b04704d-b57f-4aed-8143-0ba2dc774953"),
				ContainerUId = new Guid("7969b2cd-51e0-490c-b289-63e0473f9af3"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,93,111,211,48,20,253,47,121,158,39,39,118,190,246,6,163,160,74,192,42,117,218,203,178,7,215,190,105,45,146,38,178,221,65,169,250,223,185,142,219,208,161,10,10,47,44,79,241,209,185,231,158,251,181,139,100,35,172,253,44,90,136,110,162,183,179,79,243,174,118,215,239,117,227,192,124,48,221,166,143,174,34,11,70,139,70,127,7,21,240,137,210,238,157,112,2,3,118,213,207,248,42,186,169,206,41,84,209,85,21,105,7,173,69,6,6,176,146,102,121,81,2,73,168,74,8,23,153,36,101,94,228,36,7,30,39,121,89,170,56,97,129,121,94,250,182,107,123,97,32,100,24,196,235,225,247,126,219,123,98,140,128,28,40,218,118,235,3,200,188,5,59,89,139,69,3,10,223,206,108,0,33,103,116,139,149,192,189,110,97,38,12,102,242,58,157,135,144,84,139,198,122,86,3,181,155,124,235,13,88,171,187,245,239,173,53,155,118,125,202,197,112,24,159,7,51,116,112,232,153,51,225,86,131,192,20,77,237,7,143,111,150,75,3,75,225,244,243,169,133,47,176,29,120,151,245,14,3,20,206,231,65,52,27,56,201,249,178,142,91,209,187,80,78,72,143,4,163,151,171,11,43,29,187,245,167,98,19,4,251,35,249,34,197,179,254,147,12,193,103,15,4,141,227,111,21,61,78,237,221,215,53,152,185,92,65,43,66,199,158,174,17,253,5,24,245,111,118,140,202,58,43,57,35,162,40,98,194,37,163,68,208,162,32,117,157,165,105,158,0,79,120,188,127,10,62,180,237,27,177,125,24,211,125,4,17,154,229,123,134,111,28,1,45,20,21,68,202,114,65,120,170,74,178,96,42,37,9,19,57,165,156,47,226,88,226,108,253,231,71,208,45,181,20,205,93,15,6,71,60,180,152,158,95,205,23,59,237,139,55,93,231,66,73,99,235,70,47,199,245,160,169,42,128,21,140,196,192,106,194,179,44,33,101,26,167,68,201,34,151,60,103,12,242,5,154,193,155,246,253,157,119,27,35,15,119,100,195,49,255,211,153,254,135,243,251,155,155,58,187,213,151,236,233,107,217,193,233,107,217,180,125,180,255,1,50,5,67,117,48,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("63cb5219-81b3-4e2c-8f12-bb56e164296d"),
				ContainerUId = new Guid("7969b2cd-51e0-490c-b289-63e0473f9af3"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,75,111,27,71,12,199,191,138,176,201,209,20,230,253,208,177,77,15,6,108,215,136,219,92,108,31,56,51,100,35,84,15,67,187,74,145,26,250,238,165,100,43,182,131,212,113,82,4,133,1,235,176,146,70,67,14,69,242,183,127,238,117,247,122,248,120,69,221,164,251,233,244,248,108,201,195,248,231,229,138,198,167,171,101,165,190,31,31,45,43,206,166,127,99,153,209,41,174,112,78,3,173,222,225,108,77,253,209,180,31,14,70,247,141,186,131,238,245,135,221,111,221,228,252,186,59,28,104,254,251,97,19,207,33,215,226,41,102,224,228,34,184,128,10,48,54,11,222,88,74,220,98,9,57,139,113,93,206,214,243,197,49,13,120,138,195,251,110,114,221,237,188,137,131,82,85,53,45,40,240,104,27,184,228,196,1,58,130,26,20,97,140,129,140,10,221,230,160,235,235,123,154,227,238,208,59,99,167,145,83,166,12,209,171,2,142,74,129,84,177,2,179,205,37,136,51,77,117,107,124,187,255,206,240,252,213,209,114,249,231,250,106,108,140,117,186,54,13,190,88,11,174,202,241,89,105,13,129,99,200,150,56,144,115,99,175,177,85,75,21,172,87,178,169,104,137,81,201,129,169,144,45,138,180,102,149,94,93,110,15,106,211,254,106,134,31,223,253,235,121,71,132,109,212,15,248,7,141,79,150,195,104,186,144,164,83,63,80,187,177,191,122,80,136,251,30,174,47,110,170,121,209,77,46,190,92,207,219,247,179,93,162,30,86,244,97,49,47,186,131,139,238,108,185,94,213,173,55,43,95,222,220,11,123,119,192,110,203,103,95,247,213,147,149,197,122,54,187,93,121,131,3,238,55,238,151,151,109,202,83,106,135,139,179,125,209,118,94,212,237,11,190,112,217,191,110,98,251,47,102,199,184,144,236,174,78,228,239,223,197,254,41,202,223,36,133,123,199,197,100,175,162,102,136,132,89,186,39,24,72,77,35,100,157,11,219,104,13,179,217,89,191,37,150,42,45,42,61,12,236,41,189,115,107,223,239,178,189,197,230,54,174,109,170,54,221,102,115,112,31,166,109,195,70,76,5,178,97,3,78,115,134,140,33,73,219,53,85,74,172,228,74,122,20,166,92,76,204,53,6,80,70,75,68,236,53,96,109,1,108,182,129,180,10,185,52,247,35,97,106,172,107,77,1,130,137,21,92,147,11,54,201,175,106,148,136,10,22,167,234,152,99,82,33,200,45,2,163,37,57,70,182,151,146,51,144,139,145,107,201,174,152,167,194,116,66,212,70,115,28,214,171,233,240,241,133,167,103,207,211,19,218,231,155,120,210,149,171,227,212,192,232,164,192,97,116,80,140,201,80,181,139,72,152,82,50,254,81,158,188,73,58,90,151,4,110,165,193,41,237,165,107,67,128,42,18,80,99,241,222,213,244,35,120,58,63,236,127,253,107,65,171,155,252,76,24,103,61,93,142,101,245,179,133,95,102,52,167,197,48,185,182,228,67,80,18,40,177,147,212,251,194,144,155,105,224,149,176,150,141,81,197,209,70,12,62,201,194,228,218,39,91,149,104,53,100,106,98,34,33,237,10,5,92,66,69,100,214,134,219,230,242,107,36,138,114,12,171,105,89,15,211,229,98,116,181,149,181,93,224,47,106,246,236,232,211,65,166,153,32,138,145,152,182,226,227,179,216,55,153,116,146,178,205,133,100,91,179,223,68,95,76,218,36,164,0,38,215,32,147,29,73,79,134,34,244,49,82,227,96,41,199,250,40,125,162,101,76,150,20,136,166,9,190,44,12,23,84,12,236,67,99,227,188,180,122,125,174,244,213,230,137,228,238,4,161,106,49,137,114,41,162,208,16,228,54,87,106,198,90,3,125,15,125,111,105,62,93,180,209,242,5,194,255,69,2,179,42,65,202,159,64,49,139,132,105,39,56,69,121,58,50,206,40,249,128,156,85,124,12,194,39,7,246,100,8,91,139,193,251,42,125,230,101,218,146,73,11,146,149,91,125,50,166,42,226,82,27,149,71,33,68,167,48,56,70,121,226,33,20,9,20,158,179,147,9,19,125,174,186,177,56,180,252,92,33,148,36,68,209,115,2,10,81,198,101,133,50,46,91,182,50,46,40,67,236,165,68,17,191,7,194,51,156,81,63,106,211,15,211,94,214,94,180,240,217,105,161,111,201,249,80,28,104,47,242,227,26,121,144,231,124,25,254,88,6,63,14,49,251,250,85,12,47,55,255,0,221,93,36,143,128,17,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9bbd4a51-ba19-4092-b17e-e8cb144490a9"),
				ContainerUId = new Guid("7969b2cd-51e0-490c-b289-63e0473f9af3"),
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

		protected virtual void InitializeAddReminderParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("55dd5f60-cee9-44b6-8f68-b543a4174bf2"),
				ContainerUId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e"),
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
				Value = @"ae7a5bc6-115f-4ed2-97c5-13f5c5142c37",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7a3aa063-9af4-482e-adbf-9312dad8b0bf"),
				ContainerUId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2e6f433c-09c2-46dc-89d2-80e6a8f6ebda"),
				ContainerUId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("ddff7e72-873c-4e34-a274-b1fe98dc4dc5"),
				ContainerUId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("95dfe792-7d3e-4db6-8add-2effff3ca7f4"),
				ContainerUId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,93,79,91,71,16,253,43,214,77,31,82,137,181,246,251,131,199,210,164,138,148,180,40,164,121,137,243,48,187,59,155,90,245,7,178,175,83,81,196,127,239,185,6,26,160,145,67,219,4,37,146,121,0,124,185,51,187,59,59,231,204,153,225,188,251,174,63,59,229,238,176,251,225,248,197,201,178,245,227,163,229,138,199,199,171,101,225,245,122,252,124,89,104,54,253,147,242,140,143,105,69,115,238,121,245,154,102,27,94,63,159,174,251,131,209,77,163,238,160,251,238,253,246,111,221,225,155,243,238,89,207,243,95,159,85,120,86,73,179,241,37,138,88,139,20,54,71,47,200,36,18,68,174,214,172,27,235,58,24,151,229,108,51,95,188,224,158,142,169,255,173,59,60,239,182,222,224,128,125,227,22,172,23,141,92,18,86,74,22,49,120,252,102,109,48,54,43,210,210,116,23,7,221,186,252,198,115,218,46,250,193,152,56,144,203,197,11,165,92,19,150,171,22,41,20,39,148,105,174,56,101,117,49,97,48,190,122,255,131,225,130,255,24,253,180,153,214,199,147,206,42,106,49,113,18,193,201,12,31,57,139,88,168,136,214,76,202,222,70,171,184,76,186,239,7,55,117,186,62,157,209,217,235,207,227,237,244,86,208,111,250,59,159,92,222,220,164,59,156,124,252,238,174,126,158,108,131,114,251,246,110,95,220,164,59,152,116,39,203,205,170,12,222,12,62,252,120,227,16,219,5,182,175,220,249,120,125,83,120,178,216,204,102,87,79,126,164,158,174,95,188,126,188,172,211,54,229,250,108,113,114,125,65,91,47,242,234,75,124,228,219,245,215,229,222,254,143,217,11,90,208,59,94,253,140,227,127,216,251,223,187,124,133,16,94,59,206,58,57,25,84,19,129,9,201,197,94,35,99,21,137,164,82,110,38,24,221,154,222,90,191,228,198,43,94,20,190,189,49,210,213,202,64,74,148,74,86,88,99,173,160,18,148,136,145,44,235,220,82,209,241,202,126,189,141,246,0,145,171,125,13,161,186,232,46,46,14,110,2,71,74,44,109,19,28,18,35,117,157,102,145,56,91,129,228,209,57,251,98,41,182,157,192,177,82,89,163,74,21,170,58,13,184,168,36,72,53,37,130,247,129,140,179,182,234,242,249,129,243,230,209,155,103,235,95,254,88,240,234,50,62,135,141,102,107,126,59,198,211,59,15,254,206,202,195,243,16,114,43,206,42,161,8,33,183,217,177,200,53,4,97,216,234,84,108,246,38,180,139,183,143,222,238,194,216,155,71,207,153,234,104,57,44,125,249,230,30,63,223,16,126,148,207,168,19,14,128,65,73,16,86,129,235,99,173,82,80,148,166,90,31,77,173,230,95,225,135,93,37,109,136,69,136,218,11,16,107,19,145,141,28,188,214,162,180,167,160,221,78,252,72,7,252,153,86,81,110,82,4,162,177,173,92,172,17,165,229,32,91,182,58,74,251,149,224,199,200,210,60,54,139,104,69,37,108,193,49,73,198,136,162,226,157,11,26,40,178,234,126,248,217,35,231,193,43,143,54,82,69,231,3,216,217,20,228,153,70,142,250,24,68,171,190,37,96,34,165,92,119,33,231,222,27,187,47,114,140,38,169,84,2,94,164,98,40,46,236,133,34,4,152,50,198,235,108,170,35,75,59,145,83,56,180,20,100,20,174,228,138,19,41,47,50,68,159,176,201,179,49,42,57,163,191,8,114,78,206,214,175,105,53,29,4,235,248,104,179,66,172,122,68,156,95,77,231,252,169,220,135,41,206,63,122,127,199,124,52,216,142,104,81,71,131,163,61,56,30,28,28,85,43,78,220,172,40,210,67,86,73,5,18,214,232,33,26,132,66,84,65,65,108,217,7,5,7,112,145,66,243,3,46,44,50,186,212,32,82,66,217,147,84,92,34,83,160,184,210,78,112,80,99,133,234,17,4,39,5,174,214,6,224,8,240,226,108,174,206,197,160,82,252,2,253,12,216,125,185,252,125,115,58,174,165,100,206,209,9,71,104,61,44,212,164,72,173,49,68,34,17,149,140,176,86,55,38,239,171,140,172,132,70,123,38,24,108,0,49,43,9,81,83,206,85,57,112,148,251,100,53,185,92,239,231,101,15,253,95,168,159,46,23,163,203,62,99,124,180,98,160,169,142,242,217,30,81,223,156,80,187,79,2,253,43,68,105,85,72,233,130,20,83,6,213,162,192,97,78,190,160,209,65,25,36,199,142,226,238,9,65,139,178,38,21,208,56,52,12,22,172,87,65,100,15,68,81,107,141,178,202,169,186,240,249,17,117,210,175,166,139,119,227,167,203,213,156,250,199,255,77,182,105,74,153,60,150,149,214,9,75,84,69,34,103,176,123,21,51,52,157,167,148,6,217,118,48,186,191,251,39,51,158,163,112,29,158,115,225,104,124,246,162,186,138,123,30,122,64,162,38,69,50,4,65,157,209,172,58,123,113,123,63,213,73,31,32,141,69,198,125,12,100,11,237,107,74,17,206,212,40,33,166,181,118,97,48,121,178,232,167,253,217,209,246,66,208,188,97,188,99,36,5,80,52,195,170,33,171,178,52,86,104,231,160,22,144,85,222,152,255,124,138,148,29,134,63,181,9,102,220,40,58,233,10,254,103,28,202,107,19,93,74,54,164,118,231,20,184,245,160,53,26,231,28,44,104,58,14,154,223,24,35,156,167,170,172,100,207,161,252,243,20,228,74,161,144,208,122,132,138,44,212,145,96,213,50,36,76,210,185,86,112,126,139,195,41,118,206,121,238,230,196,75,158,79,23,21,143,70,200,118,88,12,18,98,8,195,203,161,83,45,155,117,191,156,243,106,180,192,217,198,79,167,171,117,63,154,14,34,100,217,70,43,94,111,102,253,96,136,180,159,113,25,216,115,60,128,232,134,253,108,235,100,185,232,169,244,247,49,127,10,240,141,22,91,31,251,241,210,67,179,174,43,24,185,52,133,190,76,201,161,67,27,228,126,242,36,12,26,91,242,212,168,180,242,176,34,191,184,80,12,200,70,91,143,246,216,22,204,171,200,162,216,251,82,116,24,160,16,227,78,214,13,205,22,199,105,224,218,132,58,0,53,54,12,188,164,0,94,77,213,192,124,86,95,64,199,236,89,119,207,186,123,214,221,15,245,239,217,61,214,108,72,49,11,25,24,35,60,136,6,136,2,232,147,10,21,0,137,37,49,198,123,216,209,74,99,172,233,208,242,181,32,33,103,74,40,144,51,25,204,137,89,79,171,197,196,18,237,238,255,134,113,48,208,134,94,56,21,161,85,116,9,151,234,59,153,144,13,84,189,149,173,126,126,214,157,116,195,108,112,210,237,210,62,55,223,217,79,222,187,7,28,145,124,5,73,254,246,226,47,220,134,13,23,76,30,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2af26cad-fdd2-4138-9712-bb3c00009344"),
				ContainerUId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e"),
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
				UId = new Guid("70277ea6-1d86-4786-918d-17e2bb4b24f4"),
				ContainerUId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e"),
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

		protected virtual void InitializeReadLeadDataParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("88b815f6-9ed2-474a-a40e-f96b169054b4"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,203,110,219,48,16,252,23,157,195,64,239,135,111,109,234,22,6,218,198,128,131,92,162,28,86,228,210,38,42,89,2,73,167,117,13,255,123,151,146,173,58,133,145,184,189,52,58,137,131,217,217,217,215,206,227,53,24,243,21,26,244,38,222,251,249,151,69,43,237,245,71,85,91,212,159,116,187,233,188,43,207,160,86,80,171,159,40,6,124,42,148,253,0,22,40,96,87,254,142,47,189,73,121,78,161,244,174,74,79,89,108,12,49,40,64,36,133,31,23,5,178,140,203,140,197,5,228,172,144,121,196,32,225,126,20,9,31,146,32,24,152,231,165,111,218,166,3,141,67,134,94,92,246,191,119,219,206,17,3,2,120,79,81,166,93,31,192,200,89,48,211,53,84,53,10,122,91,189,65,130,172,86,13,85,130,119,170,193,57,104,202,228,116,90,7,17,73,66,109,28,171,70,105,167,63,58,141,198,168,118,253,178,181,122,211,172,79,185,20,142,227,243,96,198,239,29,58,230,28,236,170,23,152,145,169,125,239,241,221,114,169,113,9,86,61,157,90,248,134,219,158,119,89,239,40,64,208,124,238,161,222,224,73,206,231,117,220,64,103,135,114,134,244,68,208,106,185,186,176,210,177,91,175,21,27,18,216,29,201,23,41,158,245,31,166,4,62,57,96,208,56,254,150,222,195,204,220,126,95,163,94,240,21,54,48,116,236,241,154,208,63,128,81,127,178,139,124,46,211,34,166,182,229,121,192,98,30,249,12,252,60,103,82,166,73,146,133,24,135,113,176,127,28,124,40,211,213,176,189,31,211,125,70,24,154,229,122,70,239,32,202,147,40,200,18,86,129,68,210,146,130,65,198,3,150,6,130,251,69,148,83,170,132,102,235,62,55,130,118,169,56,212,183,29,106,26,113,223,98,255,252,106,62,219,105,87,188,110,91,59,148,52,182,110,244,114,92,143,28,147,74,166,148,61,204,170,132,197,85,32,88,17,64,204,4,23,41,134,50,172,138,60,38,51,116,211,174,191,139,118,163,249,225,142,204,112,204,255,116,166,255,225,252,254,230,166,206,110,245,37,123,250,86,118,112,246,86,54,109,239,237,127,1,142,252,10,194,48,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7c774b4b-6e9a-4ef1-bd4d-4af18e1f5a68"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4a5fff69-b63a-49e0-a7c9-da42ff12623b"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1b730802-2250-4ca2-84c5-b50b5d4a07fb"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("be3ad5ec-1ac1-4d88-8421-74079d80259b"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("19076150-3efa-4513-be4e-b624b7233322"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9adb2ee5-70ec-4c6c-b1ab-4cb1ddf4c59b"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("81e8d9be-76bf-41e2-a013-9bfb7a60bbf7"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a4b4eb8-5619-4c19-a817-49e7435ddac0"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("18ee65b6-9004-44b1-b810-660c4b69eb54"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2ba36ea2-087d-4183-8f2e-029d86d94b6b"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("39c22bae-af9c-474a-8c12-e087a1cc5bcc"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("befd9ddf-c017-4e87-bf55-98e25f140075"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2fd8069c-26a9-41c0-9022-20c047525340"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("b92dc5ab-c714-451b-b938-04990fc76593"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("904a1de6-b8cd-43d7-a193-0a8234806d6f"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("addb84e6-59ea-4d30-acaf-3f26b8c94365"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9891f0ad-db82-488b-aedd-64f50dc28baf"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("58751358-9137-4811-8c8b-e31b4917cc58"),
				ContainerUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeReadLeadTypeParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ca3d3049-0f26-41a3-bca2-dd669a7d3396"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,211,64,16,253,43,145,207,221,106,253,109,231,6,37,160,74,64,43,90,245,66,122,24,239,142,211,21,235,15,237,174,11,33,202,127,103,214,78,67,138,34,8,92,64,194,7,203,126,122,51,251,102,230,205,110,2,161,193,218,247,208,96,48,15,94,94,191,187,233,106,119,254,90,105,135,230,141,233,134,62,56,11,44,26,5,90,125,69,57,225,11,169,220,43,112,64,1,155,229,247,248,101,48,95,30,203,176,12,206,150,129,114,216,88,98,80,64,140,121,154,20,60,97,73,141,244,10,227,132,149,85,45,88,152,112,153,196,50,46,33,135,137,121,60,245,69,215,244,96,112,58,97,76,94,143,159,183,235,222,19,67,2,196,72,81,182,107,119,96,236,37,216,69,11,149,70,73,255,206,12,72,144,51,170,161,74,240,86,53,120,13,134,78,242,121,58,15,17,169,6,109,61,75,99,237,22,95,122,131,214,170,174,253,185,52,61,52,237,33,151,194,113,255,187,19,195,71,133,158,121,13,238,97,76,112,73,162,182,163,198,23,171,149,193,21,56,245,120,40,225,19,174,71,222,105,189,163,0,73,243,185,3,61,224,193,153,207,235,184,128,222,77,229,76,199,19,193,168,213,195,137,149,238,187,245,171,98,35,2,251,39,242,73,25,143,234,143,50,2,31,61,48,229,120,250,92,6,31,47,237,213,231,22,205,141,120,192,6,166,142,221,159,19,250,3,176,208,216,96,235,230,27,81,135,89,130,152,178,34,21,53,75,68,44,88,153,112,193,176,194,40,13,107,81,134,57,223,82,192,94,208,124,83,132,88,200,178,66,150,103,21,133,132,24,49,224,97,236,123,95,229,144,241,170,170,115,31,178,104,157,114,235,201,5,243,77,42,178,50,203,105,88,89,132,5,75,82,30,179,194,199,163,204,50,17,75,153,197,50,221,222,79,229,42,219,107,88,223,237,171,250,128,32,103,154,94,180,73,198,186,153,223,159,89,87,207,168,185,131,118,170,93,205,200,65,26,133,31,225,249,197,96,93,215,160,153,181,232,221,125,54,13,148,178,64,5,89,158,242,138,241,138,234,77,120,89,177,50,75,67,86,96,9,192,165,44,33,226,100,60,255,120,127,116,43,37,64,95,245,104,200,127,227,252,249,241,189,121,182,112,126,50,166,235,220,212,239,253,92,223,146,248,137,113,224,95,17,39,101,94,1,103,89,88,32,245,158,75,6,69,42,89,30,65,88,22,152,242,90,38,36,136,46,29,111,128,155,110,48,98,183,232,118,186,109,254,232,30,249,11,247,195,239,44,253,209,181,59,101,145,254,179,37,185,252,151,76,189,13,182,223,0,251,165,173,126,60,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9bb7fdf0-23d9-4a53-9bfc-b65d5b2b58ef"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1fc1bf95-66f6-437e-ae96-ab0226deef9f"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b6eaed28-95a3-4e02-bc92-584da91d9666"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8af81470-64e6-4c25-bc4e-996386dd37c1"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("876c91d3-f5fd-430b-99a7-6da066af2251"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a511d00e-3b57-438c-ad43-a0b965ac41ff"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				UId = new Guid("d5067126-b12c-401d-83cc-53d80a232257"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c25ddf34-5ec7-43ef-9f1b-1f022d5afa06"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("39e87f5c-2965-45a4-8ce7-4446e1173001"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("3aec9151-bb18-4f05-9f98-6ef24b8eb8fa"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("8319a4e6-2ecb-470d-b2fd-9af8514e9ab2"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0e55a545-db7b-429c-8850-c3c910df6b27"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d246ad4e-36de-4230-bc79-a36f43b1befe"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				UId = new Guid("7ad11547-1b9b-4507-b7ff-0d224aa61262"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5bfef119-7795-4c1c-8d01-0d38138f2a41"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3e1d582a-dce9-475f-9eed-bc65b2d11830"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ebb14ab8-1576-4069-9eff-8964285cc2b3"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fd914a29-a951-4c58-a6e5-7402fa7e8761"),
				ContainerUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeReadLeadContactParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fe828bdd-0b5b-4b21-8d0d-7fe8bbb6c978"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,93,111,211,48,20,253,43,85,158,231,41,113,156,196,233,27,140,130,246,0,155,24,218,11,221,195,181,115,221,89,228,75,142,59,40,85,255,59,215,201,86,58,84,65,225,5,36,26,169,74,142,206,189,62,247,227,120,27,233,26,134,225,29,52,24,205,163,151,215,111,111,58,227,207,95,219,218,163,123,227,186,117,31,157,69,3,58,11,181,253,138,213,132,47,42,235,95,129,7,10,216,46,191,199,47,163,249,242,88,134,101,116,182,140,172,199,102,32,6,5,100,6,114,228,178,96,121,34,128,9,84,25,43,165,20,44,211,80,72,122,178,164,224,19,243,120,234,139,174,233,193,225,116,194,152,220,140,175,31,54,125,32,38,4,232,145,98,135,174,125,4,211,32,97,88,180,160,106,172,232,219,187,53,18,228,157,109,168,18,252,96,27,188,6,71,39,133,60,93,128,136,100,160,30,2,171,70,227,23,95,122,135,195,96,187,246,231,210,234,117,211,30,114,41,28,247,159,143,98,226,81,97,96,94,131,191,31,19,92,146,168,221,168,241,197,106,229,112,5,222,62,28,74,248,132,155,145,119,90,239,40,160,162,249,220,66,189,198,131,51,159,215,113,1,189,159,202,153,142,39,130,179,171,251,19,43,221,119,235,87,197,114,2,251,39,242,73,25,143,234,231,57,129,15,1,152,114,60,189,46,163,143,151,195,213,231,22,221,141,190,199,6,166,142,221,157,19,250,3,176,168,177,193,214,207,183,218,36,185,64,204,152,204,180,97,66,167,154,149,34,214,12,21,242,44,49,186,76,138,120,71,1,123,65,243,173,76,80,86,165,66,86,228,138,66,18,228,12,226,36,101,165,50,170,128,60,86,202,20,33,100,209,122,235,55,211,22,204,183,80,137,50,174,50,201,226,44,12,171,146,52,44,46,114,86,85,82,228,57,170,180,148,233,238,110,42,215,14,125,13,155,219,125,85,239,17,170,89,77,127,228,36,55,248,89,240,207,172,51,51,106,238,186,246,182,93,205,104,131,106,212,97,132,180,118,173,7,237,199,76,97,148,20,159,199,105,194,51,142,12,42,195,153,128,152,51,149,107,96,25,207,20,100,137,206,53,47,104,229,194,47,108,70,183,178,26,234,171,30,29,109,222,56,249,248,184,99,158,89,45,204,196,117,157,159,58,189,159,232,161,156,167,197,5,90,216,20,68,193,226,74,73,38,68,102,152,226,34,102,92,26,149,171,88,154,50,213,164,135,110,155,48,249,155,110,237,244,163,195,135,233,154,249,163,11,228,47,92,12,191,227,246,163,126,59,197,65,255,153,59,46,255,161,157,222,69,187,111,28,66,181,76,52,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b4af7ceb-60b9-467c-a8b3-81953d377341"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("311fcede-bca4-4fec-9a42-0f943fe03159"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4f32f247-07f2-471b-ba49-b42cae200cf0"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d72c0941-da6e-42f6-b7a5-0b3ffe8b2c2e"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3356dca2-6b01-46e0-9fe2-d0de44ff97b0"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d550d767-aeda-4cf2-9b2a-90c7c38be81b"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("fff72291-b74e-4830-8333-56ad140e6e7c"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("05f02083-70af-4052-8ee7-2b228747244c"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("123bb774-23e8-4cbe-a707-c0bf2149c012"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a43adf8a-3d3f-4d55-bbb1-030b98ca7464"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2a298fa9-f151-46ad-b486-c3c3bcb89af4"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("51b3ba73-2cd0-43a5-b1bb-d655502ea451"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("bd94e2da-67c7-4c33-985e-1f6fdecc4562"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("53665a2a-42d9-47f3-8bf4-e4ebbd2e10f3"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f382eb7c-1c7a-4c11-93b3-5b6271585801"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("377fdd7e-2835-4e98-a892-93bd77cfe77f"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("76b641e0-afa5-49a2-a9f7-6c63a2f449de"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4ea3d1b9-bd07-4221-9d68-e9102d93f89a"),
				ContainerUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeDistributionLeadPageParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var titleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bbe769c2-34d8-4a8b-a580-a9e4311e6053"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Title",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			titleParameter.SourceValue = new ProcessSchemaParameterValue(titleParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Страница распределения",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(titleParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5160bb63-99ee-4be0-ad4e-f804a2c25915"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Распределите лид, определите стратегию взращивания лида",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var clientUnitSchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2021bd48-f45e-4cd3-b993-7b97a0c3308d"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ClientUnitSchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			clientUnitSchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(clientUnitSchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"65a13f26-c1c8-49e6-9744-ce1c028164df",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(clientUnitSchemaUIdParameter);
			var entityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1905b493-d577-4148-a465-5b25ff5f0ab4"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"EntityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entityIdParameter.SourceValue = new ProcessSchemaParameterValue(entityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entityIdParameter);
			var entryPointIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("702a610c-eae3-442a-b9e5-1eae1657abca"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"EntryPointId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entryPointIdParameter.SourceValue = new ProcessSchemaParameterValue(entryPointIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entryPointIdParameter);
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("ab6017ca-8f69-4ec1-95d6-57eb04cec232"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var useCardProcessModuleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1babcc34-fbcc-4e3e-84fe-432c05fdbbe5"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"UseCardProcessModule",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useCardProcessModuleParameter.SourceValue = new ProcessSchemaParameterValue(useCardProcessModuleParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(useCardProcessModuleParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("583c0a7d-9ed9-49b6-919b-fb6caaff12fd"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"OwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			ownerIdParameter.SourceValue = new ProcessSchemaParameterValue(ownerIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#SysVariable.CurrentUserContact#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3aeda084-6af5-44ea-8738-d38edc340131"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{51139bfa-4db4-45f7-aa2f-590d604f8469}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("63033799-a11b-4b1e-9c2b-6e17977e2c43"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
			var isRunningParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("809907b4-6caf-4cda-8cd8-58f9c1196633"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"IsRunning",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isRunningParameter.SourceValue = new ProcessSchemaParameterValue(isRunningParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(isRunningParameter);
			var templateParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				UId = new Guid("b6ff1632-8447-43c2-9b76-658146844be1"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Template",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			templateParameter.SourceValue = new ProcessSchemaParameterValue(templateParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#Lookup.90fa6d02-3e93-45d6-a72b-58dcffa411ae.21620f25-166f-42f1-8b4d-224a959040a3#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(templateParameter);
			var moduleParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				UId = new Guid("7235fee8-643a-4105-bf60-d6e3855e65b9"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Module",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			moduleParameter.SourceValue = new ProcessSchemaParameterValue(moduleParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#Lookup.90fa6d02-3e93-45d6-a72b-58dcffa411ae.eb89c336-08b9-4951-bffd-3f5abc433174#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(moduleParameter);
			var pressedButtonCodeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f164d1ac-d486-4ad3-91da-1174260bbd01"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"PressedButtonCode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			pressedButtonCodeParameter.SourceValue = new ProcessSchemaParameterValue(pressedButtonCodeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pressedButtonCodeParameter);
			var urlParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1c855ecf-3361-49bf-825f-6281043116c4"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Url",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			urlParameter.SourceValue = new ProcessSchemaParameterValue(urlParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"""[Module]/[Page]/add""",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(urlParameter);
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("989facc2-6ae0-4fdb-b1b6-62dfc27340b9"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"CurrentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			currentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(currentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(currentActivityIdParameter);
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5b402470-dc18-4ccf-851a-bbcb02592ea6"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"CreateActivity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			createActivityParameter.SourceValue = new ProcessSchemaParameterValue(createActivityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("782c00f4-9b07-442c-9934-9625bcb359e3"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ae2d70f4-fc2c-444b-b9aa-d6ee291cf5a9"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("83b4d7eb-5443-4712-856b-4ac60c649892"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("27ff394f-d930-4f15-a24c-1c9d5e1b845e"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a8925615-57bf-48b5-97fb-331918c63cbd"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("71739197-e65a-4d1d-8e67-01c450fbb93b"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("99c2bbee-c62d-4595-949a-680e80d63d2a"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1556d288-a331-4a11-bea7-2e4378450cda"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7e1d7dce-3248-4f36-9b46-703de981b0ea"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ActivityResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activityResultParameter.SourceValue = new ProcessSchemaParameterValue(activityResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activityResultParameter);
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7fe10b97-084f-4f8e-ade5-8f4b0abf384e"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var leadIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("345b747f-6492-4686-a503-0062acd716e0"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"LeadId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			leadIdParameter.SourceValue = new ProcessSchemaParameterValue(leadIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{30cf6943-a881-4c30-a088-ff65572e4241}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(leadIdParameter);
			var resultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a9e78508-ae1b-4141-abe0-24ed11eadb13"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"Result",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText")
			};
			resultParameter.SourceValue = new ProcessSchemaParameterValue(resultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(resultParameter);
			var remindToOwnerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cd5eefc4-6c19-4719-be10-6babbc9acc6e"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"RemindToOwner",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			remindToOwnerParameter.SourceValue = new ProcessSchemaParameterValue(remindToOwnerParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(remindToOwnerParameter);
			var leadOwnerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("0d01d7bb-ccf9-4184-a64f-953b68988ea4"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"LeadOwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			leadOwnerIdParameter.SourceValue = new ProcessSchemaParameterValue(leadOwnerIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(leadOwnerIdParameter);
			var opportunityDepartmentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8227a76e-e673-40a1-a3f3-2102ef5efe7a"),
				ContainerUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"OpportunityDepartment",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			opportunityDepartmentParameter.SourceValue = new ProcessSchemaParameterValue(opportunityDepartmentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(opportunityDepartmentParameter);
		}

		protected virtual void InitializeSaveLeadByDefaultParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("560bc47f-ebc5-4687-aa0c-08705e061a9a"),
				ContainerUId = new Guid("6621ece7-a75a-4921-a234-3d2fa74faf4c"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c4e20e54-2a71-4e75-a167-24858aec6fcb"),
				ContainerUId = new Guid("6621ece7-a75a-4921-a234-3d2fa74faf4c"),
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
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ba1c792f-b05d-43b6-b1d4-1f6f092ae9d7"),
				ContainerUId = new Guid("6621ece7-a75a-4921-a234-3d2fa74faf4c"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,193,110,219,48,12,253,23,159,171,194,182,228,216,238,109,235,178,33,192,182,6,72,209,75,221,3,37,211,137,48,59,54,36,165,91,22,228,223,71,217,137,151,14,193,150,237,178,250,100,61,60,146,143,228,227,46,80,53,88,251,25,26,12,110,130,183,243,79,139,182,114,215,239,117,237,208,124,48,237,166,11,174,2,139,70,67,173,191,99,57,224,211,82,187,119,224,128,2,118,197,207,248,34,184,41,206,101,40,130,171,34,208,14,27,75,12,10,64,25,165,80,1,103,24,69,49,19,160,20,147,144,198,44,231,82,134,60,229,162,204,227,129,121,62,245,109,219,116,96,112,168,208,39,175,250,223,251,109,231,137,17,1,170,167,104,219,174,15,32,247,18,236,116,13,178,198,146,222,206,108,144,32,103,116,67,157,224,189,110,112,14,134,42,249,60,173,135,136,84,65,109,61,171,198,202,77,191,117,6,173,213,237,250,247,210,234,77,179,62,229,82,56,142,207,131,152,176,87,232,153,115,112,171,62,193,140,68,237,123,141,111,150,75,131,75,112,250,249,84,194,23,220,246,188,203,102,71,1,37,237,231,1,234,13,158,212,124,217,199,45,116,110,104,103,40,79,4,163,151,171,11,59,29,167,245,167,102,99,2,187,35,249,162,140,103,245,199,19,2,159,61,48,228,56,254,22,193,227,204,222,125,93,163,89,168,21,54,48,76,236,233,154,208,95,128,49,255,205,142,135,170,154,228,130,51,200,178,136,9,197,67,6,97,150,177,170,154,36,73,26,163,136,69,180,127,26,116,104,219,213,176,125,24,203,125,68,24,134,229,103,70,239,50,2,197,177,204,89,34,147,9,19,81,24,49,89,169,156,165,147,80,40,201,35,148,169,160,221,250,207,175,160,93,106,5,245,93,135,134,86,220,143,56,60,111,205,23,158,246,205,155,182,117,67,75,227,232,70,45,71,123,136,42,87,50,150,146,137,82,113,178,71,9,44,139,147,156,137,52,68,200,120,66,38,33,123,236,233,166,253,124,23,237,198,168,195,29,217,225,152,255,233,76,255,195,249,253,205,77,157,117,245,37,62,125,45,30,156,189,22,167,237,131,253,15,4,55,66,191,48,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f3fd0d58-28e8-457f-8737-49c12cc4cc1d"),
				ContainerUId = new Guid("6621ece7-a75a-4921-a234-3d2fa74faf4c"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,75,111,27,71,12,128,255,138,176,201,209,52,230,253,208,177,73,15,6,236,214,168,155,92,108,31,56,51,100,35,64,15,99,181,78,145,10,250,239,165,214,82,108,167,129,29,180,135,52,128,247,176,210,82,67,14,151,228,71,142,54,221,235,225,211,13,117,211,238,167,243,179,139,21,15,199,111,86,61,29,159,247,171,74,235,245,241,233,170,226,124,246,23,150,57,157,99,143,11,26,168,127,143,243,91,90,159,206,214,195,209,228,161,82,119,212,189,254,56,254,214,77,47,55,221,201,64,139,119,39,77,44,167,196,216,200,86,104,81,19,184,236,19,228,164,13,216,170,115,48,65,187,86,138,40,215,213,252,118,177,60,163,1,207,113,248,208,77,55,221,104,77,12,120,147,116,180,46,129,171,74,131,83,218,3,198,16,160,22,173,106,44,222,187,154,186,237,81,183,174,31,104,129,227,166,247,202,78,35,167,76,25,162,87,5,28,149,2,169,98,5,102,155,75,112,201,105,170,59,229,253,250,123,197,203,87,151,39,235,95,255,92,82,127,49,218,157,50,206,215,116,125,44,210,47,4,159,67,51,221,196,88,184,122,167,65,163,70,112,197,19,148,22,35,88,114,38,87,87,130,141,188,189,126,117,189,219,177,205,214,55,115,252,244,254,159,27,159,18,182,201,106,183,245,221,202,155,71,177,127,184,118,115,117,151,192,171,110,122,245,245,20,238,63,239,92,126,156,196,199,249,187,234,142,174,186,139,213,109,95,119,214,172,60,188,125,224,224,184,193,184,228,139,199,67,194,68,178,188,157,207,247,146,183,56,224,97,225,65,188,106,51,158,81,59,89,94,28,242,52,90,81,251,11,190,114,59,92,119,190,253,23,181,51,92,226,31,212,255,34,175,127,239,251,103,47,127,151,16,30,12,23,147,189,138,154,33,18,102,41,152,96,32,53,73,102,214,185,176,141,214,48,155,81,251,55,98,234,105,89,233,177,99,58,20,178,193,107,72,76,6,156,246,89,244,155,2,76,202,54,23,146,109,205,238,245,215,99,180,119,164,236,253,218,133,106,219,109,183,71,15,249,177,89,199,162,162,3,108,190,130,115,228,160,236,104,8,201,149,34,5,103,50,231,39,249,49,49,51,89,82,16,115,85,224,56,41,40,168,24,216,135,198,198,121,118,185,254,79,248,201,181,89,78,193,130,162,38,252,88,155,32,101,129,40,71,78,6,27,147,83,225,121,126,222,244,132,3,77,122,90,204,150,141,250,9,175,250,23,156,190,19,78,89,149,224,11,39,80,204,82,189,90,122,99,138,49,131,113,70,201,23,228,172,226,83,56,125,179,99,223,138,83,45,136,38,37,15,213,170,6,82,192,13,50,6,6,155,157,15,168,115,35,74,79,143,163,170,24,99,14,80,84,178,242,70,38,0,86,1,164,114,107,213,120,111,51,170,239,137,211,207,115,90,208,114,152,110,44,249,16,148,116,10,18,194,193,73,22,32,55,211,192,43,21,66,54,70,21,71,219,199,252,249,100,171,194,40,33,161,38,42,226,210,216,247,128,75,168,136,204,218,112,123,158,63,25,28,67,63,43,183,195,108,181,156,220,72,161,28,143,142,191,12,179,151,97,134,201,215,160,164,19,132,200,188,59,32,105,40,145,35,248,92,125,72,170,42,57,44,62,73,31,58,133,193,49,2,42,146,9,161,72,42,212,69,65,80,44,232,198,165,100,203,63,42,125,201,152,40,39,91,2,10,81,58,139,66,13,104,217,130,209,202,16,123,105,144,17,255,13,125,23,56,167,245,164,205,62,206,214,34,123,193,240,135,195,208,183,36,195,169,56,208,94,142,113,174,145,151,225,35,55,100,249,11,196,33,102,153,73,207,13,193,235,237,223,142,97,213,1,237,13,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("737a2969-6bcd-4de0-bf6f-2dbd679718d8"),
				ContainerUId = new Guid("6621ece7-a75a-4921-a234-3d2fa74faf4c"),
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

		protected virtual void InitializeIntermediateCatchSignal1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3113a34a-8da2-40e6-8256-f154360ef8a5"),
				ContainerUId = new Guid("dbcbd41e-b326-4d01-b8f3-3d49f00820fe"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("dbcbd41e-b326-4d01-b8f3-3d49f00820fe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{30cf6943-a881-4c30-a088-ff65572e4241}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeLinkLeadToProcessParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entityIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("eaf23f6b-c09c-445f-910f-846067cc4260"),
				ContainerUId = new Guid("030582fb-9053-4d10-9c8d-0d58e8ad1641"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fcace79b-6103-4992-8a1f-8e443114321a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("fcace79b-6103-4992-8a1f-8e443114321a"),
				Name = @"EntityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entityIdParameter.SourceValue = new ProcessSchemaParameterValue(entityIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{30cf6943-a881-4c30-a088-ff65572e4241}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entityIdParameter);
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("eb235528-1302-40b2-8b0d-75f09ed4804b"),
				ContainerUId = new Guid("030582fb-9053-4d10-9c8d-0d58e8ad1641"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fcace79b-6103-4992-8a1f-8e443114321a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("fcace79b-6103-4992-8a1f-8e443114321a"),
				Name = @"EntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLeadDistributionProcess = CreateLeadDistributionProcessLaneSet();
			LaneSets.Add(schemaLeadDistributionProcess);
			ProcessSchemaLane schemaLeadDistribution = CreateLeadDistributionLane();
			schemaLeadDistributionProcess.Lanes.Add(schemaLeadDistribution);
			ProcessSchemaStartEvent start = CreateStartStartEvent();
			FlowElements.Add(start);
			ProcessSchemaTerminateEvent terminatehandoff = CreateTerminateHandoffTerminateEvent();
			FlowElements.Add(terminatehandoff);
			ProcessSchemaExclusiveGateway exclusivegatewayisleadset = CreateExclusiveGatewayIsLeadSetExclusiveGateway();
			FlowElements.Add(exclusivegatewayisleadset);
			ProcessSchemaTerminateEvent terminateleadisnotset = CreateTerminateLeadIsNotSetTerminateEvent();
			FlowElements.Add(terminateleadisnotset);
			ProcessSchemaUserTask saveleadhandoff = CreateSaveLeadHandoffUserTask();
			FlowElements.Add(saveleadhandoff);
			ProcessSchemaUserTask saveleadnointerest = CreateSaveLeadNoInterestUserTask();
			FlowElements.Add(saveleadnointerest);
			ProcessSchemaUserTask addreminder = CreateAddReminderUserTask();
			FlowElements.Add(addreminder);
			ProcessSchemaUserTask readleaddata = CreateReadLeadDataUserTask();
			FlowElements.Add(readleaddata);
			ProcessSchemaUserTask readleadtype = CreateReadLeadTypeUserTask();
			FlowElements.Add(readleadtype);
			ProcessSchemaUserTask readleadcontact = CreateReadLeadContactUserTask();
			FlowElements.Add(readleadcontact);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			ProcessSchemaUserTask distributionleadpage = CreateDistributionLeadPageUserTask();
			FlowElements.Add(distributionleadpage);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask saveleadbydefault = CreateSaveLeadByDefaultUserTask();
			FlowElements.Add(saveleadbydefault);
			ProcessSchemaIntermediateCatchSignalEvent intermediatecatchsignal1 = CreateIntermediateCatchSignal1IntermediateCatchSignalEvent();
			FlowElements.Add(intermediatecatchsignal1);
			ProcessSchemaParallelGateway parallelgateway1 = CreateParallelGateway1ParallelGateway();
			FlowElements.Add(parallelgateway1);
			ProcessSchemaUserTask linkleadtoprocess = CreateLinkLeadToProcessUserTask();
			FlowElements.Add(linkleadtoprocess);
			ProcessSchemaInclusiveGateway inclusivegateway1 = CreateInclusiveGateway1InclusiveGateway();
			FlowElements.Add(inclusivegateway1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalFlowLeadUndefinedConditionalFlow());
			FlowElements.Add(CreateConditionalFlowCreateReminderConditionalFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlowNoReminderSequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("5fb58e15-c3e0-48b9-b270-c3878ba5ec8d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7a92b7ab-7ed4-4582-8e65-9e766afb2829"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0788b001-b01e-467d-8078-6e3f56e8a438"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowLeadUndefinedConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowLeadUndefined",
				UId = new Guid("5805d2d7-5516-4f97-9107-0c6b5c4bbc5c"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{30cf6943-a881-4c30-a088-ff65572e4241}]#] == Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(182, 288),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0788b001-b01e-467d-8078-6e3f56e8a438"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("28c1efc4-e3b9-4c23-8307-4e19e53453b3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowCreateReminderConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowCreateReminder",
				UId = new Guid("97e8e894-d220-43dc-9cfa-0e37f8166e2a"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{9cd3f863-0eda-4338-895e-97f82adfe406}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(648, 154),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("79bed3ce-b5f5-4199-a64d-91f1eede0c61"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("e7b9f7af-f3f3-45b3-b5ef-e55931027930"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(677, 155),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("68552fe0-b6b1-47de-9bdd-6c06dbdf6839"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e0fc6ab2-437d-4492-a531-191b3013d93d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlowNoReminderSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlowNoReminder",
				UId = new Guid("74e4203e-f8b4-42a4-9a72-43c7354d017c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(916, 130),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("79bed3ce-b5f5-4199-a64d-91f1eede0c61"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("68552fe0-b6b1-47de-9bdd-6c06dbdf6839"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(693, 116));
			schemaFlow.PolylinePointPositions.Add(new Point(1360, 116));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow4",
				UId = new Guid("8e0f40d1-6611-4d88-a2b3-db13f8f8268e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(220, 155),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0788b001-b01e-467d-8078-6e3f56e8a438"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("030582fb-9053-4d10-9c8d-0d58e8ad1641"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("f5da7633-709e-40ac-ab2f-51d79b4f1e75"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{3e566048-ef49-45bf-9d2d-500669220b4e}].[Parameter:{a9e78508-ae1b-4141-abe0-24ed11eadb13}]#] == ""TransferToSale""",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(480, 152),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fe8039af-a364-42b4-bf9d-dbe3a1991c15"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("79bed3ce-b5f5-4199-a64d-91f1eede0c61"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("15c1b993-b41b-4b3d-be24-96f8a835c457"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{3e566048-ef49-45bf-9d2d-500669220b4e}].[Parameter:{a9e78508-ae1b-4141-abe0-24ed11eadb13}]#] == ""NotInteresting""",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(468, 226),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fe8039af-a364-42b4-bf9d-dbe3a1991c15"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7969b2cd-51e0-490c-b289-63e0473f9af3"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(555, 270));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("7f0e3663-1ccd-4022-9a63-af412567e1dd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(348, 154),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fe8039af-a364-42b4-bf9d-dbe3a1991c15"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow10",
				UId = new Guid("1d497f73-83f1-49f1-922b-d98d94ddb5e6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(562, 98),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fe8039af-a364-42b4-bf9d-dbe3a1991c15"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6621ece7-a75a-4921-a234-3d2fa74faf4c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(555, 57));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("8693d20e-d10c-4049-b6c4-7b603c0c353d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(1144, 166),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("68552fe0-b6b1-47de-9bdd-6c06dbdf6839"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("a69b197e-c39e-4b7f-b3e2-f9f7e49e02ff"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(809, 166),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("efeba810-1988-471e-8f37-8fdf1b4013e7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(920, 168),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("a2112edf-8702-462c-8323-8546cb7408a8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(1026, 168),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("4365907e-4259-43b7-b5c9-9198eed877cd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fc539133-b8d9-4984-b7be-a58958c7add2"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("62282042-1255-4e64-85bb-e0f48d66d46e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dbcbd41e-b326-4d01-b8f3-3d49f00820fe"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(317, 387));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("adf061c8-5e2b-4b81-9dd6-01ff389371e0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fc539133-b8d9-4984-b7be-a58958c7add2"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("030582fb-9053-4d10-9c8d-0d58e8ad1641"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("62282042-1255-4e64-85bb-e0f48d66d46e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("c6e3e495-2035-4485-b3cf-2b7861e7a0f2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fc539133-b8d9-4984-b7be-a58958c7add2"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("62282042-1255-4e64-85bb-e0f48d66d46e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("a85b720a-fc41-4983-b4eb-113739de786c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fc539133-b8d9-4984-b7be-a58958c7add2"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dbcbd41e-b326-4d01-b8f3-3d49f00820fe"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7ce091e6-4511-4f24-aa1c-98b98f288332"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("0ae66221-8406-4b11-ac9c-ce039b98f222"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{3e566048-ef49-45bf-9d2d-500669220b4e}].[Parameter:{a9e78508-ae1b-4141-abe0-24ed11eadb13}]#] != ""TransferToSale""",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fc539133-b8d9-4984-b7be-a58958c7add2"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7ce091e6-4511-4f24-aa1c-98b98f288332"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e0fc6ab2-437d-4492-a531-191b3013d93d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1360, 387));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("0c3a16d2-6cd1-4cf1-818b-7872e864d8ec"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9991b8a2-84b0-4228-a2dc-a24cad0bd72d"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6621ece7-a75a-4921-a234-3d2fa74faf4c"),
				SourceSequenceFlowPointLocalPosition = new Point(-1, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(608, 15));
			schemaFlow.PolylinePointPositions.Add(new Point(453, 15));
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLeadDistributionProcessLaneSet() {
			ProcessSchemaLaneSet schemaLeadDistributionProcess = new ProcessSchemaLaneSet(this) {
				UId = new Guid("4d9afef7-9066-439f-b71e-60e2c82e61da"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"LeadDistributionProcess",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLeadDistributionProcess;
		}

		protected virtual ProcessSchemaLane CreateLeadDistributionLane() {
			ProcessSchemaLane schemaLeadDistribution = new ProcessSchemaLane(this) {
				UId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("4d9afef7-9066-439f-b71e-60e2c82e61da"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"LeadDistribution",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLeadDistribution;
		}

		protected virtual ProcessSchemaStartEvent CreateStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("7a92b7ab-7ed4-4582-8e65-9e766afb2829"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"Start",
				Position = new Point(50, 23),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateHandoffTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("e0fc6ab2-437d-4492-a531-191b3013d93d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"TerminateHandoff",
				Position = new Point(1347, 257),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayIsLeadSetExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("0788b001-b01e-467d-8078-6e3f56e8a438"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"ExclusiveGatewayIsLeadSet",
				Position = new Point(36, 131),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateLeadIsNotSetTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("28c1efc4-e3b9-4c23-8307-4e19e53453b3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"TerminateLeadIsNotSet",
				Position = new Point(50, 247),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateSaveLeadHandoffUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("79bed3ce-b5f5-4199-a64d-91f1eede0c61"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"SaveLeadHandoff",
				Position = new Point(659, 131),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeSaveLeadHandoffParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateSaveLeadNoInterestUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("7969b2cd-51e0-490c-b289-63e0473f9af3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"SaveLeadNoInterest",
				Position = new Point(608, 243),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeSaveLeadNoInterestParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddReminderUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"AddReminder",
				Position = new Point(1217, 131),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddReminderParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadLeadDataUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"ReadLeadData",
				Position = new Point(819, 131),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadLeadDataParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadLeadTypeUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"ReadLeadType",
				Position = new Point(1088, 131),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadLeadTypeParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadLeadContactUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"ReadLeadContact",
				Position = new Point(959, 131),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadLeadContactParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("68552fe0-b6b1-47de-9bdd-6c06dbdf6839"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"ExclusiveGateway2",
				Position = new Point(1333, 131),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateDistributionLeadPageUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"DistributionLeadPage",
				Position = new Point(419, 131),
				SchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeDistributionLeadPageParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("fe8039af-a364-42b4-bf9d-dbe3a1991c15"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"ExclusiveGateway1",
				Position = new Point(528, 131),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateSaveLeadByDefaultUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("6621ece7-a75a-4921-a234-3d2fa74faf4c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"SaveLeadByDefault",
				Position = new Point(608, 30),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeSaveLeadByDefaultParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateIntermediateCatchSignal1IntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("dbcbd41e-b326-4d01-b8f3-3d49f00820fe"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = false,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fc539133-b8d9-4984-b7be-a58958c7add2"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = false,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"IntermediateCatchSignal1",
				NewEntityChangedColumns = false,
				Position = new Point(792, 374),
				SerializeToDB = true,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("bc0c2d60-5a3d-4840-aa4e-c60ea776e206");
			InitializeIntermediateCatchSignal1Parameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaParallelGateway CreateParallelGateway1ParallelGateway() {
			ProcessSchemaParallelGateway gateway = new ProcessSchemaParallelGateway(this) {
				UId = new Guid("62282042-1255-4e64-85bb-e0f48d66d46e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fc539133-b8d9-4984-b7be-a58958c7add2"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("e9e1e6de-7066-4eb1-bbb4-5b75b13d4f56"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"ParallelGateway1",
				Position = new Point(290, 131),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateLinkLeadToProcessUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("030582fb-9053-4d10-9c8d-0d58e8ad1641"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fc539133-b8d9-4984-b7be-a58958c7add2"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("fcace79b-6103-4992-8a1f-8e443114321a"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"LinkLeadToProcess",
				Position = new Point(147, 131),
				SchemaUId = new Guid("fcace79b-6103-4992-8a1f-8e443114321a"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeLinkLeadToProcessParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaInclusiveGateway CreateInclusiveGateway1InclusiveGateway() {
			ProcessSchemaInclusiveGateway gateway = new ProcessSchemaInclusiveGateway(this) {
				UId = new Guid("7ce091e6-4511-4f24-aa1c-98b98f288332"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6e824c2-16a4-43c0-a73a-7309e704e6e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fc539133-b8d9-4984-b7be-a58958c7add2"),
				CreatedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("ffa4a06a-5747-49d4-96c2-c32a727a3b14"),
				ModifiedInSchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"),
				Name = @"InclusiveGateway1",
				Position = new Point(925, 360),
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

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LeadManagementDistribution10(userConnection);
		}

		public override object Clone() {
			return new LeadManagementDistribution10Schema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadManagementDistribution10

	/// <exclude/>
	public class LeadManagementDistribution10 : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLeadDistribution

		/// <exclude/>
		public class ProcessLeadDistribution : ProcessLane
		{

			public ProcessLeadDistribution(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: SaveLeadHandoffFlowElement

		/// <exclude/>
		public class SaveLeadHandoffFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public SaveLeadHandoffFlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SaveLeadHandoff";
				IsLogging = true;
				SchemaElementUId = new Guid("79bed3ce-b5f5-4199-a64d-91f1eede0c61");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifyStatus = () => (Guid)(new Guid("ceb70b3c-985f-4867-ae7c-88f9dd710688"));
				_recordColumnValues_Owner = () => (Guid)((process.ResponsibleId));
				_recordColumnValues_RemindToOwner = () => (bool)((process.CreateReminder));
				_recordColumnValues_OpportunityDepartment = () => (Guid)((process.DistributionLeadPage.OpportunityDepartment));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifyStatus", () => _recordColumnValues_QualifyStatus.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_Owner", () => _recordColumnValues_Owner.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_RemindToOwner", () => _recordColumnValues_RemindToOwner.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_OpportunityDepartment", () => _recordColumnValues_OpportunityDepartment.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifyStatus;
			internal Func<Guid> _recordColumnValues_Owner;
			internal Func<bool> _recordColumnValues_RemindToOwner;
			internal Func<Guid> _recordColumnValues_OpportunityDepartment;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,211,64,16,253,47,62,119,171,245,122,253,213,27,148,128,34,1,141,148,170,151,186,135,137,61,78,86,216,177,181,187,41,132,40,255,157,89,111,98,82,20,65,224,66,125,242,62,189,121,243,230,107,23,148,13,24,243,25,90,12,110,130,183,179,79,243,174,182,215,239,85,99,81,127,208,221,166,15,174,2,131,90,65,163,190,99,229,241,73,165,236,59,176,64,1,187,226,103,124,17,220,20,231,20,138,224,170,8,148,197,214,16,131,2,32,225,40,50,137,44,142,36,103,50,134,148,45,132,172,88,152,98,44,69,20,213,89,46,61,243,188,244,109,215,246,160,209,103,24,196,235,225,247,126,219,59,98,72,64,57,80,148,233,214,7,48,114,22,204,100,13,139,6,43,122,91,189,65,130,172,86,45,85,130,247,170,197,25,104,202,228,116,58,7,17,169,134,198,56,86,131,181,157,124,235,53,26,163,186,245,239,173,53,155,118,125,202,165,112,28,159,7,51,124,112,232,152,51,176,171,65,96,74,166,246,131,199,55,203,165,198,37,88,245,124,106,225,11,110,7,222,101,189,163,128,138,230,243,0,205,6,79,114,190,172,227,22,122,235,203,241,233,137,160,213,114,117,97,165,99,183,254,84,172,32,176,63,146,47,82,60,235,95,36,4,62,59,192,107,28,127,139,224,113,106,238,190,174,81,207,203,21,182,224,59,246,116,77,232,47,192,168,127,179,139,120,89,39,185,140,24,100,89,200,100,25,113,6,60,203,88,93,39,113,156,10,148,66,134,251,39,239,67,153,190,129,237,195,152,238,35,130,111,150,235,25,189,51,94,135,41,164,192,144,139,152,73,153,84,12,22,85,196,48,15,105,36,121,190,224,113,74,179,117,159,27,65,183,84,37,52,119,61,106,26,241,208,98,126,126,53,95,236,180,43,94,119,157,245,37,141,173,27,189,28,215,131,87,98,33,0,36,19,137,76,153,172,92,97,121,153,57,91,117,204,171,20,120,9,100,134,110,218,245,119,222,109,116,121,184,35,227,143,249,159,206,244,63,156,223,223,220,212,217,173,190,100,79,95,203,14,78,95,203,166,237,131,253,15,163,181,209,2,48,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,91,111,219,86,12,199,191,138,161,246,49,52,206,253,226,199,181,3,22,32,217,130,101,235,75,156,135,115,33,87,99,182,21,72,114,135,206,240,119,31,229,216,77,82,116,73,134,97,232,10,196,15,178,116,44,254,73,145,231,39,210,219,230,245,240,241,6,155,89,243,221,197,249,101,75,195,244,77,219,225,244,162,107,11,246,253,244,172,45,105,185,248,51,229,37,94,164,46,173,112,192,238,93,90,110,176,63,91,244,195,201,228,190,81,115,210,188,254,176,255,173,153,93,109,155,211,1,87,191,158,86,86,206,54,122,101,131,129,152,40,131,73,53,64,138,37,241,153,55,154,162,18,185,6,54,46,237,114,179,90,159,227,144,46,210,240,190,153,109,155,189,218,40,80,68,81,213,9,176,73,87,48,193,8,72,201,32,20,39,48,121,239,80,9,215,236,78,154,190,188,199,85,218,59,189,51,54,50,81,136,24,193,91,193,222,49,103,8,37,21,32,210,49,59,22,147,88,70,227,195,253,119,134,87,175,206,218,246,247,205,205,84,41,109,100,169,18,108,214,26,76,97,247,81,72,9,142,188,139,26,201,161,49,211,130,217,139,172,11,196,96,137,99,116,30,18,250,2,33,80,172,213,75,225,66,120,117,61,58,170,139,254,102,153,62,190,251,91,127,103,152,234,164,31,210,111,56,253,33,173,107,75,52,25,218,73,159,150,216,223,42,220,60,40,197,125,141,237,252,182,158,243,102,54,255,114,69,15,223,151,251,84,61,172,233,195,114,206,155,147,121,115,217,110,186,50,170,105,190,120,123,47,240,189,131,253,45,159,93,30,235,199,43,235,205,114,121,88,121,155,134,116,188,241,184,220,214,5,45,176,158,174,47,143,101,219,171,136,195,7,190,112,56,126,110,99,251,55,102,231,105,205,249,237,126,228,199,191,139,253,83,148,191,112,10,143,194,89,69,43,188,36,240,152,34,239,31,167,32,84,153,32,202,152,73,123,173,136,212,222,250,103,36,236,112,93,240,97,96,207,217,61,7,251,126,159,237,17,156,67,92,99,170,118,205,110,119,114,31,39,22,115,222,120,226,71,147,8,70,87,222,105,65,4,240,213,16,122,139,38,167,242,40,78,86,5,233,181,9,28,140,144,96,132,180,144,188,115,80,178,20,197,103,107,77,9,255,5,78,87,167,253,79,127,172,177,187,205,207,140,210,178,199,235,41,175,126,182,240,105,87,206,182,222,103,42,214,72,144,137,83,110,178,69,200,213,123,208,104,84,44,38,59,237,105,119,253,36,87,35,80,237,232,250,133,159,111,142,31,233,50,106,103,37,4,66,5,70,218,200,246,149,59,64,16,186,26,23,116,173,250,31,241,147,19,135,227,34,83,99,72,140,1,121,136,232,120,67,43,83,136,162,201,89,198,71,249,81,62,18,106,20,224,99,97,1,10,2,88,147,128,172,171,164,140,37,19,203,255,132,159,88,170,166,224,52,8,172,204,143,214,1,66,100,136,162,167,160,82,37,52,194,61,205,207,155,14,211,128,147,14,87,139,117,197,110,66,109,247,130,211,87,106,71,81,100,103,51,5,16,68,133,113,224,119,99,240,62,130,50,74,240,73,162,40,252,99,56,61,59,176,231,226,228,52,207,119,232,120,27,107,197,237,200,10,199,96,165,12,154,120,228,17,86,231,108,229,163,56,37,35,146,51,148,32,241,52,199,237,8,29,68,227,89,197,198,34,43,229,28,53,125,77,156,190,95,226,10,215,195,108,171,209,58,39,184,111,34,19,206,79,154,9,98,85,21,172,16,206,69,197,115,172,193,221,67,254,130,82,158,123,43,2,191,101,184,249,139,36,33,105,210,160,164,80,72,150,75,228,211,211,252,241,224,53,116,139,188,25,22,237,122,114,51,206,133,151,227,48,56,169,139,15,139,158,215,94,186,218,55,215,213,108,13,198,186,108,64,90,110,36,166,162,133,44,248,192,255,144,164,32,231,163,45,79,98,120,189,251,11,184,208,186,240,190,13,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "2747a38633284c0da1bc2acc2ae61cfe",
							"BaseElements.SaveLeadHandoff.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("34a08715-d94b-478c-887e-dbb951baceeb");
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

		#region Class: SaveLeadNoInterestFlowElement

		/// <exclude/>
		public class SaveLeadNoInterestFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public SaveLeadNoInterestFlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SaveLeadNoInterest";
				IsLogging = true;
				SchemaElementUId = new Guid("7969b2cd-51e0-490c-b289-63e0473f9af3");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifyStatus = () => (Guid)(new Guid("51adc3ec-3503-4b10-a00b-8be3b0e11f08"));
				_recordColumnValues_LeadTypeStatus = () => (Guid)(new Guid("f78066d3-a73e-4e86-bb99-e477fcb94b28"));
				_recordColumnValues_Owner = () => (Guid)((process.DistributionLeadPage.OwnerId));
				_recordColumnValues_RemindToOwner = () => (bool)((process.DistributionLeadPage.RemindToOwner));
				_recordColumnValues_OpportunityDepartment = () => (Guid)((process.DistributionLeadPage.OpportunityDepartment));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifyStatus", () => _recordColumnValues_QualifyStatus.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_LeadTypeStatus", () => _recordColumnValues_LeadTypeStatus.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_Owner", () => _recordColumnValues_Owner.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_RemindToOwner", () => _recordColumnValues_RemindToOwner.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_OpportunityDepartment", () => _recordColumnValues_OpportunityDepartment.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifyStatus;
			internal Func<Guid> _recordColumnValues_LeadTypeStatus;
			internal Func<Guid> _recordColumnValues_Owner;
			internal Func<bool> _recordColumnValues_RemindToOwner;
			internal Func<Guid> _recordColumnValues_OpportunityDepartment;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,93,111,211,48,20,253,47,121,158,39,39,118,190,246,6,163,160,74,192,42,117,218,203,178,7,215,190,105,45,146,38,178,221,65,169,250,223,185,142,219,208,161,10,10,47,44,79,241,209,185,231,158,251,181,139,100,35,172,253,44,90,136,110,162,183,179,79,243,174,118,215,239,117,227,192,124,48,221,166,143,174,34,11,70,139,70,127,7,21,240,137,210,238,157,112,2,3,118,213,207,248,42,186,169,206,41,84,209,85,21,105,7,173,69,6,6,176,146,102,121,81,2,73,168,74,8,23,153,36,101,94,228,36,7,30,39,121,89,170,56,97,129,121,94,250,182,107,123,97,32,100,24,196,235,225,247,126,219,123,98,140,128,28,40,218,118,235,3,200,188,5,59,89,139,69,3,10,223,206,108,0,33,103,116,139,149,192,189,110,97,38,12,102,242,58,157,135,144,84,139,198,122,86,3,181,155,124,235,13,88,171,187,245,239,173,53,155,118,125,202,197,112,24,159,7,51,116,112,232,153,51,225,86,131,192,20,77,237,7,143,111,150,75,3,75,225,244,243,169,133,47,176,29,120,151,245,14,3,20,206,231,65,52,27,56,201,249,178,142,91,209,187,80,78,72,143,4,163,151,171,11,43,29,187,245,167,98,19,4,251,35,249,34,197,179,254,147,12,193,103,15,4,141,227,111,21,61,78,237,221,215,53,152,185,92,65,43,66,199,158,174,17,253,5,24,245,111,118,140,202,58,43,57,35,162,40,98,194,37,163,68,208,162,32,117,157,165,105,158,0,79,120,188,127,10,62,180,237,27,177,125,24,211,125,4,17,154,229,123,134,111,28,1,45,20,21,68,202,114,65,120,170,74,178,96,42,37,9,19,57,165,156,47,226,88,226,108,253,231,71,208,45,181,20,205,93,15,6,71,60,180,152,158,95,205,23,59,237,139,55,93,231,66,73,99,235,70,47,199,245,160,169,42,128,21,140,196,192,106,194,179,44,33,101,26,167,68,201,34,151,60,103,12,242,5,154,193,155,246,253,157,119,27,35,15,119,100,195,49,255,211,153,254,135,243,251,155,155,58,187,213,151,236,233,107,217,193,233,107,217,180,125,180,255,1,50,5,67,117,48,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,75,111,27,71,12,199,191,138,176,201,209,20,230,253,208,177,77,15,6,108,215,136,219,92,108,31,56,51,100,35,84,15,67,187,74,145,26,250,238,165,100,43,182,131,212,113,82,4,133,1,235,176,146,70,67,14,69,242,183,127,238,117,247,122,248,120,69,221,164,251,233,244,248,108,201,195,248,231,229,138,198,167,171,101,165,190,31,31,45,43,206,166,127,99,153,209,41,174,112,78,3,173,222,225,108,77,253,209,180,31,14,70,247,141,186,131,238,245,135,221,111,221,228,252,186,59,28,104,254,251,97,19,207,33,215,226,41,102,224,228,34,184,128,10,48,54,11,222,88,74,220,98,9,57,139,113,93,206,214,243,197,49,13,120,138,195,251,110,114,221,237,188,137,131,82,85,53,45,40,240,104,27,184,228,196,1,58,130,26,20,97,140,129,140,10,221,230,160,235,235,123,154,227,238,208,59,99,167,145,83,166,12,209,171,2,142,74,129,84,177,2,179,205,37,136,51,77,117,107,124,187,255,206,240,252,213,209,114,249,231,250,106,108,140,117,186,54,13,190,88,11,174,202,241,89,105,13,129,99,200,150,56,144,115,99,175,177,85,75,21,172,87,178,169,104,137,81,201,129,169,144,45,138,180,102,149,94,93,110,15,106,211,254,106,134,31,223,253,235,121,71,132,109,212,15,248,7,141,79,150,195,104,186,144,164,83,63,80,187,177,191,122,80,136,251,30,174,47,110,170,121,209,77,46,190,92,207,219,247,179,93,162,30,86,244,97,49,47,186,131,139,238,108,185,94,213,173,55,43,95,222,220,11,123,119,192,110,203,103,95,247,213,147,149,197,122,54,187,93,121,131,3,238,55,238,151,151,109,202,83,106,135,139,179,125,209,118,94,212,237,11,190,112,217,191,110,98,251,47,102,199,184,144,236,174,78,228,239,223,197,254,41,202,223,36,133,123,199,197,100,175,162,102,136,132,89,186,39,24,72,77,35,100,157,11,219,104,13,179,217,89,191,37,150,42,45,42,61,12,236,41,189,115,107,223,239,178,189,197,230,54,174,109,170,54,221,102,115,112,31,166,109,195,70,76,5,178,97,3,78,115,134,140,33,73,219,53,85,74,172,228,74,122,20,166,92,76,204,53,6,80,70,75,68,236,53,96,109,1,108,182,129,180,10,185,52,247,35,97,106,172,107,77,1,130,137,21,92,147,11,54,201,175,106,148,136,10,22,167,234,152,99,82,33,200,45,2,163,37,57,70,182,151,146,51,144,139,145,107,201,174,152,167,194,116,66,212,70,115,28,214,171,233,240,241,133,167,103,207,211,19,218,231,155,120,210,149,171,227,212,192,232,164,192,97,116,80,140,201,80,181,139,72,152,82,50,254,81,158,188,73,58,90,151,4,110,165,193,41,237,165,107,67,128,42,18,80,99,241,222,213,244,35,120,58,63,236,127,253,107,65,171,155,252,76,24,103,61,93,142,101,245,179,133,95,102,52,167,197,48,185,182,228,67,80,18,40,177,147,212,251,194,144,155,105,224,149,176,150,141,81,197,209,70,12,62,201,194,228,218,39,91,149,104,53,100,106,98,34,33,237,10,5,92,66,69,100,214,134,219,230,242,107,36,138,114,12,171,105,89,15,211,229,98,116,181,149,181,93,224,47,106,246,236,232,211,65,166,153,32,138,145,152,182,226,227,179,216,55,153,116,146,178,205,133,100,91,179,223,68,95,76,218,36,164,0,38,215,32,147,29,73,79,134,34,244,49,82,227,96,41,199,250,40,125,162,101,76,150,20,136,166,9,190,44,12,23,84,12,236,67,99,227,188,180,122,125,174,244,213,230,137,228,238,4,161,106,49,137,114,41,162,208,16,228,54,87,106,198,90,3,125,15,125,111,105,62,93,180,209,242,5,194,255,69,2,179,42,65,202,159,64,49,139,132,105,39,56,69,121,58,50,206,40,249,128,156,85,124,12,194,39,7,246,100,8,91,139,193,251,42,125,230,101,218,146,73,11,146,149,91,125,50,166,42,226,82,27,149,71,33,68,167,48,56,70,121,226,33,20,9,20,158,179,147,9,19,125,174,186,177,56,180,252,92,33,148,36,68,209,115,2,10,81,198,101,133,50,46,91,182,50,46,40,67,236,165,68,17,191,7,194,51,156,81,63,106,211,15,211,94,214,94,180,240,217,105,161,111,201,249,80,28,104,47,242,227,26,121,144,231,124,25,254,88,6,63,14,49,251,250,85,12,47,55,255,0,221,93,36,143,128,17,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "2747a38633284c0da1bc2acc2ae61cfe",
							"BaseElements.SaveLeadNoInterest.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("34a08715-d94b-478c-887e-dbb951baceeb");
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

		#region Class: AddReminderFlowElement

		/// <exclude/>
		public class AddReminderFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddReminderFlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddReminder";
				IsLogging = true;
				SchemaElementUId = new Guid("acf07003-ffee-46aa-832b-5d378b97f75e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_SysEntitySchema = () => (Guid)(new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"));
				_recordDefValues_Contact = () => (Guid)((process.ResponsibleId));
				_recordDefValues_SubjectId = () => (Guid)((process.LeadId));
				_recordDefValues_RemindTime = () => (DateTime)(((DateTime)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentDateTime")));
				_recordDefValues_Source = () => (Guid)(new Guid("a66d08e1-2e2d-e011-ac0a-00155d043205"));
				_recordDefValues_SubjectCaption = () => new LocalizableString(String.Format((process.NotificationTemplate), ((process.ReadLeadType.ResultEntity.IsColumnValueLoaded(process.ReadLeadType.ResultEntity.Schema.Columns.GetByName("Name").ColumnValueName) ? process.ReadLeadType.ResultEntity.GetTypedColumnValue<string>("Name") : null)), ((process.ReadLeadContact.ResultEntity.IsColumnValueLoaded(process.ReadLeadContact.ResultEntity.Schema.Columns.GetByName("Name").ColumnValueName) ? process.ReadLeadContact.ResultEntity.GetTypedColumnValue<string>("Name") : null))));
				_recordDefValues_Description = () => new LocalizableString(String.Format((process.NotificationTemplate), ((process.ReadLeadType.ResultEntity.IsColumnValueLoaded(process.ReadLeadType.ResultEntity.Schema.Columns.GetByName("Name").ColumnValueName) ? process.ReadLeadType.ResultEntity.GetTypedColumnValue<string>("Name") : null)), ((process.ReadLeadContact.ResultEntity.IsColumnValueLoaded(process.ReadLeadContact.ResultEntity.Schema.Columns.GetByName("Name").ColumnValueName) ? process.ReadLeadContact.ResultEntity.GetTypedColumnValue<string>("Name") : null))));
				_recordDefValues_TypeCaption = () => new LocalizableString("Lead");
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_SysEntitySchema", () => _recordDefValues_SysEntitySchema.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_SubjectId", () => _recordDefValues_SubjectId.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_RemindTime", () => _recordDefValues_RemindTime.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Source", () => _recordDefValues_Source.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_SubjectCaption", () => _recordDefValues_SubjectCaption.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Description", () => _recordDefValues_Description.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_TypeCaption", () => _recordDefValues_TypeCaption.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_SysEntitySchema;
			internal Func<Guid> _recordDefValues_Contact;
			internal Func<Guid> _recordDefValues_SubjectId;
			internal Func<DateTime> _recordDefValues_RemindTime;
			internal Func<Guid> _recordDefValues_Source;
			internal Func<string> _recordDefValues_SubjectCaption;
			internal Func<string> _recordDefValues_Description;
			internal Func<string> _recordDefValues_TypeCaption;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,93,79,91,71,16,253,43,214,77,31,82,137,181,246,251,131,199,210,164,138,148,180,40,164,121,137,243,48,187,59,155,90,245,7,178,175,83,81,196,127,239,185,6,26,160,145,67,219,4,37,146,121,0,124,185,51,187,59,59,231,204,153,225,188,251,174,63,59,229,238,176,251,225,248,197,201,178,245,227,163,229,138,199,199,171,101,225,245,122,252,124,89,104,54,253,147,242,140,143,105,69,115,238,121,245,154,102,27,94,63,159,174,251,131,209,77,163,238,160,251,238,253,246,111,221,225,155,243,238,89,207,243,95,159,85,120,86,73,179,241,37,138,88,139,20,54,71,47,200,36,18,68,174,214,172,27,235,58,24,151,229,108,51,95,188,224,158,142,169,255,173,59,60,239,182,222,224,128,125,227,22,172,23,141,92,18,86,74,22,49,120,252,102,109,48,54,43,210,210,116,23,7,221,186,252,198,115,218,46,250,193,152,56,144,203,197,11,165,92,19,150,171,22,41,20,39,148,105,174,56,101,117,49,97,48,190,122,255,131,225,130,255,24,253,180,153,214,199,147,206,42,106,49,113,18,193,201,12,31,57,139,88,168,136,214,76,202,222,70,171,184,76,186,239,7,55,117,186,62,157,209,217,235,207,227,237,244,86,208,111,250,59,159,92,222,220,164,59,156,124,252,238,174,126,158,108,131,114,251,246,110,95,220,164,59,152,116,39,203,205,170,12,222,12,62,252,120,227,16,219,5,182,175,220,249,120,125,83,120,178,216,204,102,87,79,126,164,158,174,95,188,126,188,172,211,54,229,250,108,113,114,125,65,91,47,242,234,75,124,228,219,245,215,229,222,254,143,217,11,90,208,59,94,253,140,227,127,216,251,223,187,124,133,16,94,59,206,58,57,25,84,19,129,9,201,197,94,35,99,21,137,164,82,110,38,24,221,154,222,90,191,228,198,43,94,20,190,189,49,210,213,202,64,74,148,74,86,88,99,173,160,18,148,136,145,44,235,220,82,209,241,202,126,189,141,246,0,145,171,125,13,161,186,232,46,46,14,110,2,71,74,44,109,19,28,18,35,117,157,102,145,56,91,129,228,209,57,251,98,41,182,157,192,177,82,89,163,74,21,170,58,13,184,168,36,72,53,37,130,247,129,140,179,182,234,242,249,129,243,230,209,155,103,235,95,254,88,240,234,50,62,135,141,102,107,126,59,198,211,59,15,254,206,202,195,243,16,114,43,206,42,161,8,33,183,217,177,200,53,4,97,216,234,84,108,246,38,180,139,183,143,222,238,194,216,155,71,207,153,234,104,57,44,125,249,230,30,63,223,16,126,148,207,168,19,14,128,65,73,16,86,129,235,99,173,82,80,148,166,90,31,77,173,230,95,225,135,93,37,109,136,69,136,218,11,16,107,19,145,141,28,188,214,162,180,167,160,221,78,252,72,7,252,153,86,81,110,82,4,162,177,173,92,172,17,165,229,32,91,182,58,74,251,149,224,199,200,210,60,54,139,104,69,37,108,193,49,73,198,136,162,226,157,11,26,40,178,234,126,248,217,35,231,193,43,143,54,82,69,231,3,216,217,20,228,153,70,142,250,24,68,171,190,37,96,34,165,92,119,33,231,222,27,187,47,114,140,38,169,84,2,94,164,98,40,46,236,133,34,4,152,50,198,235,108,170,35,75,59,145,83,56,180,20,100,20,174,228,138,19,41,47,50,68,159,176,201,179,49,42,57,163,191,8,114,78,206,214,175,105,53,29,4,235,248,104,179,66,172,122,68,156,95,77,231,252,169,220,135,41,206,63,122,127,199,124,52,216,142,104,81,71,131,163,61,56,30,28,28,85,43,78,220,172,40,210,67,86,73,5,18,214,232,33,26,132,66,84,65,65,108,217,7,5,7,112,145,66,243,3,46,44,50,186,212,32,82,66,217,147,84,92,34,83,160,184,210,78,112,80,99,133,234,17,4,39,5,174,214,6,224,8,240,226,108,174,206,197,160,82,252,2,253,12,216,125,185,252,125,115,58,174,165,100,206,209,9,71,104,61,44,212,164,72,173,49,68,34,17,149,140,176,86,55,38,239,171,140,172,132,70,123,38,24,108,0,49,43,9,81,83,206,85,57,112,148,251,100,53,185,92,239,231,101,15,253,95,168,159,46,23,163,203,62,99,124,180,98,160,169,142,242,217,30,81,223,156,80,187,79,2,253,43,68,105,85,72,233,130,20,83,6,213,162,192,97,78,190,160,209,65,25,36,199,142,226,238,9,65,139,178,38,21,208,56,52,12,22,172,87,65,100,15,68,81,107,141,178,202,169,186,240,249,17,117,210,175,166,139,119,227,167,203,213,156,250,199,255,77,182,105,74,153,60,150,149,214,9,75,84,69,34,103,176,123,21,51,52,157,167,148,6,217,118,48,186,191,251,39,51,158,163,112,29,158,115,225,104,124,246,162,186,138,123,30,122,64,162,38,69,50,4,65,157,209,172,58,123,113,123,63,213,73,31,32,141,69,198,125,12,100,11,237,107,74,17,206,212,40,33,166,181,118,97,48,121,178,232,167,253,217,209,246,66,208,188,97,188,99,36,5,80,52,195,170,33,171,178,52,86,104,231,160,22,144,85,222,152,255,124,138,148,29,134,63,181,9,102,220,40,58,233,10,254,103,28,202,107,19,93,74,54,164,118,231,20,184,245,160,53,26,231,28,44,104,58,14,154,223,24,35,156,167,170,172,100,207,161,252,243,20,228,74,161,144,208,122,132,138,44,212,145,96,213,50,36,76,210,185,86,112,126,139,195,41,118,206,121,238,230,196,75,158,79,23,21,143,70,200,118,88,12,18,98,8,195,203,161,83,45,155,117,191,156,243,106,180,192,217,198,79,167,171,117,63,154,14,34,100,217,70,43,94,111,102,253,96,136,180,159,113,25,216,115,60,128,232,134,253,108,235,100,185,232,169,244,247,49,127,10,240,141,22,91,31,251,241,210,67,179,174,43,24,185,52,133,190,76,201,161,67,27,228,126,242,36,12,26,91,242,212,168,180,242,176,34,191,184,80,12,200,70,91,143,246,216,22,204,171,200,162,216,251,82,116,24,160,16,227,78,214,13,205,22,199,105,224,218,132,58,0,53,54,12,188,164,0,94,77,213,192,124,86,95,64,199,236,89,119,207,186,123,214,221,15,245,239,217,61,214,108,72,49,11,25,24,35,60,136,6,136,2,232,147,10,21,0,137,37,49,198,123,216,209,74,99,172,233,208,242,181,32,33,103,74,40,144,51,25,204,137,89,79,171,197,196,18,237,238,255,134,113,48,208,134,94,56,21,161,85,116,9,151,234,59,153,144,13,84,189,149,173,126,126,214,157,116,195,108,112,210,237,210,62,55,223,217,79,222,187,7,28,145,124,5,73,254,246,226,47,220,134,13,23,76,30,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "2747a38633284c0da1bc2acc2ae61cfe",
							"BaseElements.AddReminder.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("34a08715-d94b-478c-887e-dbb951baceeb");
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

		#region Class: ReadLeadDataFlowElement

		/// <exclude/>
		public class ReadLeadDataFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadLeadDataFlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadLeadData";
				IsLogging = true;
				SchemaElementUId = new Guid("cf164ee5-85cf-4c3c-940c-ebe251fc9170");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,203,110,219,48,16,252,23,157,195,64,239,135,111,109,234,22,6,218,198,128,131,92,162,28,86,228,210,38,42,89,2,73,167,117,13,255,123,151,146,173,58,133,145,184,189,52,58,137,131,217,217,217,215,206,227,53,24,243,21,26,244,38,222,251,249,151,69,43,237,245,71,85,91,212,159,116,187,233,188,43,207,160,86,80,171,159,40,6,124,42,148,253,0,22,40,96,87,254,142,47,189,73,121,78,161,244,174,74,79,89,108,12,49,40,64,36,133,31,23,5,178,140,203,140,197,5,228,172,144,121,196,32,225,126,20,9,31,146,32,24,152,231,165,111,218,166,3,141,67,134,94,92,246,191,119,219,206,17,3,2,120,79,81,166,93,31,192,200,89,48,211,53,84,53,10,122,91,189,65,130,172,86,13,85,130,119,170,193,57,104,202,228,116,90,7,17,73,66,109,28,171,70,105,167,63,58,141,198,168,118,253,178,181,122,211,172,79,185,20,142,227,243,96,198,239,29,58,230,28,236,170,23,152,145,169,125,239,241,221,114,169,113,9,86,61,157,90,248,134,219,158,119,89,239,40,64,208,124,238,161,222,224,73,206,231,117,220,64,103,135,114,134,244,68,208,106,185,186,176,210,177,91,175,21,27,18,216,29,201,23,41,158,245,31,166,4,62,57,96,208,56,254,150,222,195,204,220,126,95,163,94,240,21,54,48,116,236,241,154,208,63,128,81,127,178,139,124,46,211,34,166,182,229,121,192,98,30,249,12,252,60,103,82,166,73,146,133,24,135,113,176,127,28,124,40,211,213,176,189,31,211,125,70,24,154,229,122,70,239,32,202,147,40,200,18,86,129,68,210,146,130,65,198,3,150,6,130,251,69,148,83,170,132,102,235,62,55,130,118,169,56,212,183,29,106,26,113,223,98,255,252,106,62,219,105,87,188,110,91,59,148,52,182,110,244,114,92,143,28,147,74,166,148,61,204,170,132,197,85,32,88,17,64,204,4,23,41,134,50,172,138,60,38,51,116,211,174,191,139,118,163,249,225,142,204,112,204,255,116,166,255,225,252,254,230,166,206,110,245,37,123,250,86,118,112,246,86,54,109,239,237,127,1,142,252,10,194,48,6,0,0 })));
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

		#region Class: ReadLeadTypeFlowElement

		/// <exclude/>
		public class ReadLeadTypeFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadLeadTypeFlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadLeadType";
				IsLogging = true;
				SchemaElementUId = new Guid("ece836b6-d5d9-4d52-aaf0-93a3d4b40754");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,77,111,211,64,16,253,43,145,207,221,106,253,109,231,6,37,160,74,64,43,90,245,66,122,24,239,142,211,21,235,15,237,174,11,33,202,127,103,214,78,67,138,34,8,92,64,194,7,203,126,122,51,251,102,230,205,110,2,161,193,218,247,208,96,48,15,94,94,191,187,233,106,119,254,90,105,135,230,141,233,134,62,56,11,44,26,5,90,125,69,57,225,11,169,220,43,112,64,1,155,229,247,248,101,48,95,30,203,176,12,206,150,129,114,216,88,98,80,64,140,121,154,20,60,97,73,141,244,10,227,132,149,85,45,88,152,112,153,196,50,46,33,135,137,121,60,245,69,215,244,96,112,58,97,76,94,143,159,183,235,222,19,67,2,196,72,81,182,107,119,96,236,37,216,69,11,149,70,73,255,206,12,72,144,51,170,161,74,240,86,53,120,13,134,78,242,121,58,15,17,169,6,109,61,75,99,237,22,95,122,131,214,170,174,253,185,52,61,52,237,33,151,194,113,255,187,19,195,71,133,158,121,13,238,97,76,112,73,162,182,163,198,23,171,149,193,21,56,245,120,40,225,19,174,71,222,105,189,163,0,73,243,185,3,61,224,193,153,207,235,184,128,222,77,229,76,199,19,193,168,213,195,137,149,238,187,245,171,98,35,2,251,39,242,73,25,143,234,143,50,2,31,61,48,229,120,250,92,6,31,47,237,213,231,22,205,141,120,192,6,166,142,221,159,19,250,3,176,208,216,96,235,230,27,81,135,89,130,152,178,34,21,53,75,68,44,88,153,112,193,176,194,40,13,107,81,134,57,223,82,192,94,208,124,83,132,88,200,178,66,150,103,21,133,132,24,49,224,97,236,123,95,229,144,241,170,170,115,31,178,104,157,114,235,201,5,243,77,42,178,50,203,105,88,89,132,5,75,82,30,179,194,199,163,204,50,17,75,153,197,50,221,222,79,229,42,219,107,88,223,237,171,250,128,32,103,154,94,180,73,198,186,153,223,159,89,87,207,168,185,131,118,170,93,205,200,65,26,133,31,225,249,197,96,93,215,160,153,181,232,221,125,54,13,148,178,64,5,89,158,242,138,241,138,234,77,120,89,177,50,75,67,86,96,9,192,165,44,33,226,100,60,255,120,127,116,43,37,64,95,245,104,200,127,227,252,249,241,189,121,182,112,126,50,166,235,220,212,239,253,92,223,146,248,137,113,224,95,17,39,101,94,1,103,89,88,32,245,158,75,6,69,42,89,30,65,88,22,152,242,90,38,36,136,46,29,111,128,155,110,48,98,183,232,118,186,109,254,232,30,249,11,247,195,239,44,253,209,181,59,101,145,254,179,37,185,252,151,76,189,13,182,223,0,251,165,173,126,60,7,0,0 })));
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
								new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"));
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

		#region Class: ReadLeadContactFlowElement

		/// <exclude/>
		public class ReadLeadContactFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadLeadContactFlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadLeadContact";
				IsLogging = true;
				SchemaElementUId = new Guid("9b5f74df-eed7-4e2d-b2e6-d6238599479f");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,93,111,211,48,20,253,43,85,158,231,41,113,156,196,233,27,140,130,246,0,155,24,218,11,221,195,181,115,221,89,228,75,142,59,40,85,255,59,215,201,86,58,84,65,225,5,36,26,169,74,142,206,189,62,247,227,120,27,233,26,134,225,29,52,24,205,163,151,215,111,111,58,227,207,95,219,218,163,123,227,186,117,31,157,69,3,58,11,181,253,138,213,132,47,42,235,95,129,7,10,216,46,191,199,47,163,249,242,88,134,101,116,182,140,172,199,102,32,6,5,100,6,114,228,178,96,121,34,128,9,84,25,43,165,20,44,211,80,72,122,178,164,224,19,243,120,234,139,174,233,193,225,116,194,152,220,140,175,31,54,125,32,38,4,232,145,98,135,174,125,4,211,32,97,88,180,160,106,172,232,219,187,53,18,228,157,109,168,18,252,96,27,188,6,71,39,133,60,93,128,136,100,160,30,2,171,70,227,23,95,122,135,195,96,187,246,231,210,234,117,211,30,114,41,28,247,159,143,98,226,81,97,96,94,131,191,31,19,92,146,168,221,168,241,197,106,229,112,5,222,62,28,74,248,132,155,145,119,90,239,40,160,162,249,220,66,189,198,131,51,159,215,113,1,189,159,202,153,142,39,130,179,171,251,19,43,221,119,235,87,197,114,2,251,39,242,73,25,143,234,231,57,129,15,1,152,114,60,189,46,163,143,151,195,213,231,22,221,141,190,199,6,166,142,221,157,19,250,3,176,168,177,193,214,207,183,218,36,185,64,204,152,204,180,97,66,167,154,149,34,214,12,21,242,44,49,186,76,138,120,71,1,123,65,243,173,76,80,86,165,66,86,228,138,66,18,228,12,226,36,101,165,50,170,128,60,86,202,20,33,100,209,122,235,55,211,22,204,183,80,137,50,174,50,201,226,44,12,171,146,52,44,46,114,86,85,82,228,57,170,180,148,233,238,110,42,215,14,125,13,155,219,125,85,239,17,170,89,77,127,228,36,55,248,89,240,207,172,51,51,106,238,186,246,182,93,205,104,131,106,212,97,132,180,118,173,7,237,199,76,97,148,20,159,199,105,194,51,142,12,42,195,153,128,152,51,149,107,96,25,207,20,100,137,206,53,47,104,229,194,47,108,70,183,178,26,234,171,30,29,109,222,56,249,248,184,99,158,89,45,204,196,117,157,159,58,189,159,232,161,156,167,197,5,90,216,20,68,193,226,74,73,38,68,102,152,226,34,102,92,26,149,171,88,154,50,213,164,135,110,155,48,249,155,110,237,244,163,195,135,233,154,249,163,11,228,47,92,12,191,227,246,163,126,59,197,65,255,153,59,46,255,161,157,222,69,187,111,28,66,181,76,52,7,0,0 })));
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

		#region Class: DistributionLeadPageFlowElement

		/// <exclude/>
		public class DistributionLeadPageFlowElement : PreconfiguredPageUserTask
		{

			#region Constructors: Public

			public DistributionLeadPageFlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "DistributionLeadPage";
				IsLogging = true;
				SchemaElementUId = new Guid("3e566048-ef49-45bf-9d2d-500669220b4e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.LeadDistribution;
				SerializeToDB = true;
				_ownerId = () => (Guid)(((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentUserContact")));
				_showExecutionPage = () => (bool)((process.ShowDistributionPage));
				_leadId = () => (Guid)((process.LeadId));
			}

			#endregion

			#region Properties: Public

			private LocalizableString _title;
			public override LocalizableString Title {
				get {
					return _title ?? (_title = GetLocalizableString("2747a38633284c0da1bc2acc2ae61cfe",
						 "BaseElements.DistributionLeadPage.Parameters.Title.Value"));
				}
				set {
					_title = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("2747a38633284c0da1bc2acc2ae61cfe",
						 "BaseElements.DistributionLeadPage.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			private Guid _clientUnitSchemaUId = new Guid("65a13f26-c1c8-49e6-9744-ce1c028164df");
			public override Guid ClientUnitSchemaUId {
				get {
					return _clientUnitSchemaUId;
				}
				set {
					_clientUnitSchemaUId = value;
				}
			}

			private bool _useCardProcessModule = true;
			public override bool UseCardProcessModule {
				get {
					return _useCardProcessModule;
				}
				set {
					_useCardProcessModule = value;
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

			internal Func<bool> _showExecutionPage;
			public override bool ShowExecutionPage {
				get {
					return (_showExecutionPage ?? (_showExecutionPage = () => false)).Invoke();
				}
				set {
					_showExecutionPage = () => { return value; };
				}
			}

			internal Func<Guid> _leadId;
			public virtual Guid LeadId {
				get {
					return (_leadId ?? (_leadId = () => Guid.Empty)).Invoke();
				}
				set {
					_leadId = () => { return value; };
				}
			}

			public virtual string Result {
				get;
				set;
			}

			public virtual bool RemindToOwner {
				get;
				set;
			}

			public virtual Guid LeadOwnerId {
				get;
				set;
			}

			public virtual Guid OpportunityDepartment {
				get;
				set;
			}

			#endregion

		}

		#endregion

		#region Class: SaveLeadByDefaultFlowElement

		/// <exclude/>
		public class SaveLeadByDefaultFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public SaveLeadByDefaultFlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SaveLeadByDefault";
				IsLogging = true;
				SchemaElementUId = new Guid("6621ece7-a75a-4921-a234-3d2fa74faf4c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Owner = () => (Guid)((process.ResponsibleId));
				_recordColumnValues_RemindToOwner = () => (bool)((process.CreateReminder));
				_recordColumnValues_SalesOwner = () => (Guid)((process.DistributionLeadPage.OwnerId));
				_recordColumnValues_OpportunityDepartment = () => (Guid)((process.DistributionLeadPage.OpportunityDepartment));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Owner", () => _recordColumnValues_Owner.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_RemindToOwner", () => _recordColumnValues_RemindToOwner.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_SalesOwner", () => _recordColumnValues_SalesOwner.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_OpportunityDepartment", () => _recordColumnValues_OpportunityDepartment.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Owner;
			internal Func<bool> _recordColumnValues_RemindToOwner;
			internal Func<Guid> _recordColumnValues_SalesOwner;
			internal Func<Guid> _recordColumnValues_OpportunityDepartment;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,193,110,219,48,12,253,23,159,171,194,182,228,216,238,109,235,178,33,192,182,6,72,209,75,221,3,37,211,137,48,59,54,36,165,91,22,228,223,71,217,137,151,14,193,150,237,178,250,100,61,60,146,143,228,227,46,80,53,88,251,25,26,12,110,130,183,243,79,139,182,114,215,239,117,237,208,124,48,237,166,11,174,2,139,70,67,173,191,99,57,224,211,82,187,119,224,128,2,118,197,207,248,34,184,41,206,101,40,130,171,34,208,14,27,75,12,10,64,25,165,80,1,103,24,69,49,19,160,20,147,144,198,44,231,82,134,60,229,162,204,227,129,121,62,245,109,219,116,96,112,168,208,39,175,250,223,251,109,231,137,17,1,170,167,104,219,174,15,32,247,18,236,116,13,178,198,146,222,206,108,144,32,103,116,67,157,224,189,110,112,14,134,42,249,60,173,135,136,84,65,109,61,171,198,202,77,191,117,6,173,213,237,250,247,210,234,77,179,62,229,82,56,142,207,131,152,176,87,232,153,115,112,171,62,193,140,68,237,123,141,111,150,75,131,75,112,250,249,84,194,23,220,246,188,203,102,71,1,37,237,231,1,234,13,158,212,124,217,199,45,116,110,104,103,40,79,4,163,151,171,11,59,29,167,245,167,102,99,2,187,35,249,162,140,103,245,199,19,2,159,61,48,228,56,254,22,193,227,204,222,125,93,163,89,168,21,54,48,76,236,233,154,208,95,128,49,255,205,142,135,170,154,228,130,51,200,178,136,9,197,67,6,97,150,177,170,154,36,73,26,163,136,69,180,127,26,116,104,219,213,176,125,24,203,125,68,24,134,229,103,70,239,50,2,197,177,204,89,34,147,9,19,81,24,49,89,169,156,165,147,80,40,201,35,148,169,160,221,250,207,175,160,93,106,5,245,93,135,134,86,220,143,56,60,111,205,23,158,246,205,155,182,117,67,75,227,232,70,45,71,123,136,42,87,50,150,146,137,82,113,178,71,9,44,139,147,156,137,52,68,200,120,66,38,33,123,236,233,166,253,124,23,237,198,168,195,29,217,225,152,255,233,76,255,195,249,253,205,77,157,117,245,37,62,125,45,30,156,189,22,167,237,131,253,15,4,55,66,191,48,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,75,111,27,71,12,128,255,138,176,201,209,52,230,253,208,177,73,15,6,236,214,168,155,92,108,31,56,51,100,35,64,15,99,181,78,145,10,250,239,165,214,82,108,167,129,29,180,135,52,128,247,176,210,82,67,14,151,228,71,142,54,221,235,225,211,13,117,211,238,167,243,179,139,21,15,199,111,86,61,29,159,247,171,74,235,245,241,233,170,226,124,246,23,150,57,157,99,143,11,26,168,127,143,243,91,90,159,206,214,195,209,228,161,82,119,212,189,254,56,254,214,77,47,55,221,201,64,139,119,39,77,44,167,196,216,200,86,104,81,19,184,236,19,228,164,13,216,170,115,48,65,187,86,138,40,215,213,252,118,177,60,163,1,207,113,248,208,77,55,221,104,77,12,120,147,116,180,46,129,171,74,131,83,218,3,198,16,160,22,173,106,44,222,187,154,186,237,81,183,174,31,104,129,227,166,247,202,78,35,167,76,25,162,87,5,28,149,2,169,98,5,102,155,75,112,201,105,170,59,229,253,250,123,197,203,87,151,39,235,95,255,92,82,127,49,218,157,50,206,215,116,125,44,210,47,4,159,67,51,221,196,88,184,122,167,65,163,70,112,197,19,148,22,35,88,114,38,87,87,130,141,188,189,126,117,189,219,177,205,214,55,115,252,244,254,159,27,159,18,182,201,106,183,245,221,202,155,71,177,127,184,118,115,117,151,192,171,110,122,245,245,20,238,63,239,92,126,156,196,199,249,187,234,142,174,186,139,213,109,95,119,214,172,60,188,125,224,224,184,193,184,228,139,199,67,194,68,178,188,157,207,247,146,183,56,224,97,225,65,188,106,51,158,81,59,89,94,28,242,52,90,81,251,11,190,114,59,92,119,190,253,23,181,51,92,226,31,212,255,34,175,127,239,251,103,47,127,151,16,30,12,23,147,189,138,154,33,18,102,41,152,96,32,53,73,102,214,185,176,141,214,48,155,81,251,55,98,234,105,89,233,177,99,58,20,178,193,107,72,76,6,156,246,89,244,155,2,76,202,54,23,146,109,205,238,245,215,99,180,119,164,236,253,218,133,106,219,109,183,71,15,249,177,89,199,162,162,3,108,190,130,115,228,160,236,104,8,201,149,34,5,103,50,231,39,249,49,49,51,89,82,16,115,85,224,56,41,40,168,24,216,135,198,198,121,118,185,254,79,248,201,181,89,78,193,130,162,38,252,88,155,32,101,129,40,71,78,6,27,147,83,225,121,126,222,244,132,3,77,122,90,204,150,141,250,9,175,250,23,156,190,19,78,89,149,224,11,39,80,204,82,189,90,122,99,138,49,131,113,70,201,23,228,172,226,83,56,125,179,99,223,138,83,45,136,38,37,15,213,170,6,82,192,13,50,6,6,155,157,15,168,115,35,74,79,143,163,170,24,99,14,80,84,178,242,70,38,0,86,1,164,114,107,213,120,111,51,170,239,137,211,207,115,90,208,114,152,110,44,249,16,148,116,10,18,194,193,73,22,32,55,211,192,43,21,66,54,70,21,71,219,199,252,249,100,171,194,40,33,161,38,42,226,210,216,247,128,75,168,136,204,218,112,123,158,63,25,28,67,63,43,183,195,108,181,156,220,72,161,28,143,142,191,12,179,151,97,134,201,215,160,164,19,132,200,188,59,32,105,40,145,35,248,92,125,72,170,42,57,44,62,73,31,58,133,193,49,2,42,146,9,161,72,42,212,69,65,80,44,232,198,165,100,203,63,42,125,201,152,40,39,91,2,10,81,58,139,66,13,104,217,130,209,202,16,123,105,144,17,255,13,125,23,56,167,245,164,205,62,206,214,34,123,193,240,135,195,208,183,36,195,169,56,208,94,142,113,174,145,151,225,35,55,100,249,11,196,33,102,153,73,207,13,193,235,237,223,142,97,213,1,237,13,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "2747a38633284c0da1bc2acc2ae61cfe",
							"BaseElements.SaveLeadByDefault.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("34a08715-d94b-478c-887e-dbb951baceeb");
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

		#region Class: IntermediateCatchSignal1FlowElement

		/// <exclude/>
		public class IntermediateCatchSignal1FlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public IntermediateCatchSignal1FlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "IntermediateCatchSignal1";
				IsLogging = true;
				SchemaElementUId = new Guid("dbcbd41e-b326-4d01-b8f3-3d49f00820fe");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = false;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""bc0c2d60-5a3d-4840-aa4e-c60ea776e206""]}";
				EntityFilters = @"{""className"":""BPMSoft.FilterGroup"",""serializedFilterEditData"":""{\""className\"":\""BPMSoft.FilterGroup\"",\""items\"":{\""fe5d2409-9f82-49cf-b246-2d86ac466b83\"":{\""className\"":\""BPMSoft.InFilter\"",\""filterType\"":4,\""comparisonType\"":4,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""className\"":\""BPMSoft.ColumnExpression\"",\""expressionType\"":0,\""columnPath\"":\""QualifyStatus\""},\""isAggregative\"":false,\""key\"":\""fe5d2409-9f82-49cf-b246-2d86ac466b83\"",\""dataValueType\"":10,\""leftExpressionCaption\"":\""Lead stage\"",\""referenceSchemaName\"":\""QualifyStatus\"",\""rightExpressions\"":[{\""className\"":\""BPMSoft.ParameterExpression\"",\""expressionType\"":2,\""parameter\"":{\""className\"":\""BPMSoft.Parameter\"",\""dataValueType\"":10,\""value\"":{\""Id\"":\""ceb70b3c-985f-4867-ae7c-88f9dd710688\"",\""Name\"":\""Handoff to sales\"",\""value\"":\""ceb70b3c-985f-4867-ae7c-88f9dd710688\"",\""displayValue\"":\""Handoff to sales\""}}}]}},\""logicalOperation\"":0,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Lead\"",\""key\"":\""83621912-8d00-4adf-874d-f52cb98cac29\""}"",""dataSourceFilters"":""{\""items\"":{\""fe5d2409-9f82-49cf-b246-2d86ac466b83\"":{\""filterType\"":4,\""comparisonType\"":4,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""expressionType\"":0,\""columnPath\"":\""QualifyStatus\""},\""rightExpressions\"":[{\""expressionType\"":2,\""parameter\"":{\""dataValueType\"":10,\""value\"":\""ceb70b3c-985f-4867-ae7c-88f9dd710688\""}}]}},\""logicalOperation\"":0,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Lead\""}""}";
				_recordId = () => (Guid)((process.LeadId));
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

		#region Class: ParallelGateway1FlowElement

		/// <exclude/>
		public class ParallelGateway1FlowElement : ProcessParallelGateway
		{

			public ParallelGateway1FlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessParallelGateway";
				Name = "ParallelGateway1";
				IsLogging = true;
				SchemaElementUId = new Guid("62282042-1255-4e64-85bb-e0f48d66d46e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				IncomingTokens = new Dictionary<string, bool> { { "LinkLeadToProcess", false }, };
				SerializeToDB = Owner.SerializeToDB;
			}

		}

		#endregion

		#region Class: LinkLeadToProcessFlowElement

		/// <exclude/>
		public class LinkLeadToProcessFlowElement : LinkEntityToProcessUserTask
		{

			#region Constructors: Public

			public LinkLeadToProcessFlowElement(UserConnection userConnection, LeadManagementDistribution10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "LinkLeadToProcess";
				IsLogging = true;
				SchemaElementUId = new Guid("030582fb-9053-4d10-9c8d-0d58e8ad1641");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_entityId = () => (Guid)((process.LeadId));
			}

			#endregion

			#region Properties: Public

			internal Func<Guid> _entityId;
			public override Guid EntityId {
				get {
					return (_entityId ?? (_entityId = () => Guid.Empty)).Invoke();
				}
				set {
					_entityId = () => { return value; };
				}
			}

			private Guid _entitySchemaId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			public override Guid EntitySchemaId {
				get {
					return _entitySchemaId;
				}
				set {
					_entitySchemaId = value;
				}
			}

			#endregion

		}

		#endregion

		public LeadManagementDistribution10(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadManagementDistribution10";
			SchemaUId = new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_createReminder = () => { return (bool)((DistributionLeadPage.RemindToOwner)); };
			_responsibleId = () => { return (Guid)((DistributionLeadPage.LeadOwnerId)); };
			_showDistributionPage = () => { return (bool)(false); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2747a386-3328-4c0d-a1bc-2acc2ae61cfe");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LeadManagementDistribution10, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LeadManagementDistribution10, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid LeadId {
			get;
			set;
		}

		private Func<bool> _createReminder;
		public virtual bool CreateReminder {
			get {
				return (_createReminder ?? (_createReminder = () => false)).Invoke();
			}
			set {
				_createReminder = () => { return value; };
			}
		}

		private Func<Guid> _responsibleId;
		public virtual Guid ResponsibleId {
			get {
				return (_responsibleId ?? (_responsibleId = () => Guid.Empty)).Invoke();
			}
			set {
				_responsibleId = () => { return value; };
			}
		}

		private Func<bool> _showDistributionPage;
		public virtual bool ShowDistributionPage {
			get {
				return (_showDistributionPage ?? (_showDistributionPage = () => false)).Invoke();
			}
			set {
				_showDistributionPage = () => { return value; };
			}
		}

		private string _notificationTemplate;
		public virtual string NotificationTemplate {
			get {
				return _notificationTemplate ?? (_notificationTemplate = GetLocalizableString("2747a38633284c0da1bc2acc2ae61cfe",
						 "Parameters.NotificationTemplate.Value"));
			}
			set {
				_notificationTemplate = value;
			}
		}

		private ProcessLeadDistribution _leadDistribution;
		public ProcessLeadDistribution LeadDistribution {
			get {
				return _leadDistribution ?? ((_leadDistribution) = new ProcessLeadDistribution(UserConnection, this));
			}
		}

		private ProcessFlowElement _start;
		public ProcessFlowElement Start {
			get {
				return _start ?? (_start = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "Start",
					SchemaElementUId = new Guid("7a92b7ab-7ed4-4582-8e65-9e766afb2829"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessTerminateEvent _terminateHandoff;
		public ProcessTerminateEvent TerminateHandoff {
			get {
				return _terminateHandoff ?? (_terminateHandoff = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateHandoff",
					SchemaElementUId = new Guid("e0fc6ab2-437d-4492-a531-191b3013d93d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGatewayIsLeadSet;
		public ProcessExclusiveGateway ExclusiveGatewayIsLeadSet {
			get {
				return _exclusiveGatewayIsLeadSet ?? (_exclusiveGatewayIsLeadSet = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewayIsLeadSet",
					SchemaElementUId = new Guid("0788b001-b01e-467d-8078-6e3f56e8a438"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayIsLeadSet.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessTerminateEvent _terminateLeadIsNotSet;
		public ProcessTerminateEvent TerminateLeadIsNotSet {
			get {
				return _terminateLeadIsNotSet ?? (_terminateLeadIsNotSet = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateLeadIsNotSet",
					SchemaElementUId = new Guid("28c1efc4-e3b9-4c23-8307-4e19e53453b3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private SaveLeadHandoffFlowElement _saveLeadHandoff;
		public SaveLeadHandoffFlowElement SaveLeadHandoff {
			get {
				return _saveLeadHandoff ?? (_saveLeadHandoff = new SaveLeadHandoffFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private SaveLeadNoInterestFlowElement _saveLeadNoInterest;
		public SaveLeadNoInterestFlowElement SaveLeadNoInterest {
			get {
				return _saveLeadNoInterest ?? (_saveLeadNoInterest = new SaveLeadNoInterestFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddReminderFlowElement _addReminder;
		public AddReminderFlowElement AddReminder {
			get {
				return _addReminder ?? (_addReminder = new AddReminderFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadLeadDataFlowElement _readLeadData;
		public ReadLeadDataFlowElement ReadLeadData {
			get {
				return _readLeadData ?? (_readLeadData = new ReadLeadDataFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadLeadTypeFlowElement _readLeadType;
		public ReadLeadTypeFlowElement ReadLeadType {
			get {
				return _readLeadType ?? (_readLeadType = new ReadLeadTypeFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadLeadContactFlowElement _readLeadContact;
		public ReadLeadContactFlowElement ReadLeadContact {
			get {
				return _readLeadContact ?? (_readLeadContact = new ReadLeadContactFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("68552fe0-b6b1-47de-9bdd-6c06dbdf6839"),
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

		private DistributionLeadPageFlowElement _distributionLeadPage;
		public DistributionLeadPageFlowElement DistributionLeadPage {
			get {
				return _distributionLeadPage ?? (_distributionLeadPage = new DistributionLeadPageFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("fe8039af-a364-42b4-bf9d-dbe3a1991c15"),
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

		private SaveLeadByDefaultFlowElement _saveLeadByDefault;
		public SaveLeadByDefaultFlowElement SaveLeadByDefault {
			get {
				return _saveLeadByDefault ?? (_saveLeadByDefault = new SaveLeadByDefaultFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private IntermediateCatchSignal1FlowElement _intermediateCatchSignal1;
		public IntermediateCatchSignal1FlowElement IntermediateCatchSignal1 {
			get {
				return _intermediateCatchSignal1 ?? ((_intermediateCatchSignal1) = new IntermediateCatchSignal1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ParallelGateway1FlowElement _parallelGateway1;
		public ParallelGateway1FlowElement ParallelGateway1 {
			get {
				return _parallelGateway1 ?? ((_parallelGateway1) = new ParallelGateway1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private LinkLeadToProcessFlowElement _linkLeadToProcess;
		public LinkLeadToProcessFlowElement LinkLeadToProcess {
			get {
				return _linkLeadToProcess ?? (_linkLeadToProcess = new LinkLeadToProcessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("7ce091e6-4511-4f24-aa1c-98b98f288332"),
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

		private ProcessConditionalFlow _conditionalFlowLeadUndefined;
		public ProcessConditionalFlow ConditionalFlowLeadUndefined {
			get {
				return _conditionalFlowLeadUndefined ?? (_conditionalFlowLeadUndefined = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlowLeadUndefined",
					SchemaElementUId = new Guid("5805d2d7-5516-4f97-9107-0c6b5c4bbc5c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlowCreateReminder;
		public ProcessConditionalFlow ConditionalFlowCreateReminder {
			get {
				return _conditionalFlowCreateReminder ?? (_conditionalFlowCreateReminder = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlowCreateReminder",
					SchemaElementUId = new Guid("97e8e894-d220-43dc-9cfa-0e37f8166e2a"),
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
					SchemaElementUId = new Guid("f5da7633-709e-40ac-ab2f-51d79b4f1e75"),
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
					SchemaElementUId = new Guid("15c1b993-b41b-4b3d-be24-96f8a835c457"),
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
					SchemaElementUId = new Guid("0ae66221-8406-4b11-ac9c-ce039b98f222"),
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
			FlowElements[Start.SchemaElementUId] = new Collection<ProcessFlowElement> { Start };
			FlowElements[TerminateHandoff.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateHandoff };
			FlowElements[ExclusiveGatewayIsLeadSet.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayIsLeadSet };
			FlowElements[TerminateLeadIsNotSet.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateLeadIsNotSet };
			FlowElements[SaveLeadHandoff.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveLeadHandoff };
			FlowElements[SaveLeadNoInterest.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveLeadNoInterest };
			FlowElements[AddReminder.SchemaElementUId] = new Collection<ProcessFlowElement> { AddReminder };
			FlowElements[ReadLeadData.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadLeadData };
			FlowElements[ReadLeadType.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadLeadType };
			FlowElements[ReadLeadContact.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadLeadContact };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[DistributionLeadPage.SchemaElementUId] = new Collection<ProcessFlowElement> { DistributionLeadPage };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[SaveLeadByDefault.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveLeadByDefault };
			FlowElements[IntermediateCatchSignal1.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateCatchSignal1 };
			FlowElements[ParallelGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ParallelGateway1 };
			FlowElements[LinkLeadToProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { LinkLeadToProcess };
			FlowElements[InclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { InclusiveGateway1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayIsLeadSet", e.Context.SenderName));
						break;
					case "TerminateHandoff":
						CompleteProcess();
						break;
					case "ExclusiveGatewayIsLeadSet":
						if (ConditionalFlowLeadUndefinedExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateLeadIsNotSet", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LinkLeadToProcess", e.Context.SenderName));
						break;
					case "TerminateLeadIsNotSet":
						CompleteProcess();
						break;
					case "SaveLeadHandoff":
						if (ConditionalFlowCreateReminderExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadData", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "SaveLeadNoInterest":
						break;
					case "AddReminder":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "ReadLeadData":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadContact", e.Context.SenderName));
						break;
					case "ReadLeadType":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddReminder", e.Context.SenderName));
						break;
					case "ReadLeadContact":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadType", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateHandoff", e.Context.SenderName));
						break;
					case "DistributionLeadPage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveLeadHandoff", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveLeadNoInterest", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveLeadByDefault", e.Context.SenderName));
						break;
					case "SaveLeadByDefault":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("DistributionLeadPage", e.Context.SenderName));
						break;
					case "IntermediateCatchSignal1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InclusiveGateway1", e.Context.SenderName));
						break;
					case "ParallelGateway1":
						if (ParallelGateway1.IsAllPreviousFlowElementsExecuted()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("IntermediateCatchSignal1", e.Context.SenderName));
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("DistributionLeadPage", e.Context.SenderName));
						}
						break;
					case "LinkLeadToProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ParallelGateway1", e.Context.SenderName));
						break;
					case "InclusiveGateway1":
						bool isInclusiveGateway1ConditionsEvulated = false;
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateHandoff", e.Context.SenderName));
							isInclusiveGateway1ConditionsEvulated = true;
						} 
						break;
			}
		}

		private bool ConditionalFlowLeadUndefinedExpressionExecute() {
			bool result = Convert.ToBoolean((LeadId) == Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayIsLeadSet", "ConditionalFlowLeadUndefined", "(LeadId) == Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlowCreateReminderExpressionExecute() {
			bool result = Convert.ToBoolean((CreateReminder));
			Log.InfoFormat(ConditionalExpressionLogMessage, "SaveLeadHandoff", "ConditionalFlowCreateReminder", "(CreateReminder)", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((DistributionLeadPage.Result) == "TransferToSale");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow2", "(DistributionLeadPage.Result) == \"TransferToSale\"", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean((DistributionLeadPage.Result) == "NotInteresting");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow3", "(DistributionLeadPage.Result) == \"NotInteresting\"", result);
			return result;
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((DistributionLeadPage.Result) != "TransferToSale");
			Log.InfoFormat(ConditionalExpressionLogMessage, "InclusiveGateway1", "ConditionalSequenceFlow1", "(DistributionLeadPage.Result) != \"TransferToSale\"", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("DistributionLeadPage.LeadId")) {
				writer.WriteValue("DistributionLeadPage.LeadId", DistributionLeadPage.LeadId, Guid.Empty);
			}
			if (!HasMapping("DistributionLeadPage.Result")) {
				writer.WriteValue("DistributionLeadPage.Result", DistributionLeadPage.Result, null);
			}
			if (!HasMapping("DistributionLeadPage.RemindToOwner")) {
				writer.WriteValue("DistributionLeadPage.RemindToOwner", DistributionLeadPage.RemindToOwner, false);
			}
			if (!HasMapping("DistributionLeadPage.LeadOwnerId")) {
				writer.WriteValue("DistributionLeadPage.LeadOwnerId", DistributionLeadPage.LeadOwnerId, Guid.Empty);
			}
			if (!HasMapping("DistributionLeadPage.OpportunityDepartment")) {
				writer.WriteValue("DistributionLeadPage.OpportunityDepartment", DistributionLeadPage.OpportunityDepartment, Guid.Empty);
			}
			if (!HasMapping("LeadId")) {
				writer.WriteValue("LeadId", LeadId, Guid.Empty);
			}
			if (!HasMapping("NotificationTemplate")) {
				writer.WriteValue("NotificationTemplate", NotificationTemplate, null);
			}
			if (!HasMapping("CreateReminder")) {
				writer.WriteValue("CreateReminder", CreateReminder, false);
			}
			if (!HasMapping("ResponsibleId")) {
				writer.WriteValue("ResponsibleId", ResponsibleId, Guid.Empty);
			}
			if (!HasMapping("ShowDistributionPage")) {
				writer.WriteValue("ShowDistributionPage", ShowDistributionPage, false);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("Start", string.Empty));
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
			MetaPathParameterValues.Add("30cf6943-a881-4c30-a088-ff65572e4241", () => LeadId);
			MetaPathParameterValues.Add("9cd3f863-0eda-4338-895e-97f82adfe406", () => CreateReminder);
			MetaPathParameterValues.Add("77bfc541-1a1a-4b5e-bd77-3e429c4b637f", () => ResponsibleId);
			MetaPathParameterValues.Add("51139bfa-4db4-45f7-aa2f-590d604f8469", () => ShowDistributionPage);
			MetaPathParameterValues.Add("32a9ba6f-4045-4aad-9a53-b618b30c6a99", () => NotificationTemplate);
			MetaPathParameterValues.Add("188fdd38-de95-4c10-8ab3-34128e7e82c9", () => SaveLeadHandoff.EntitySchemaUId);
			MetaPathParameterValues.Add("9cad839f-9e67-4603-a369-f4c25fce8216", () => SaveLeadHandoff.IsMatchConditions);
			MetaPathParameterValues.Add("51b908e1-277f-4fd9-954b-c200b506502f", () => SaveLeadHandoff.DataSourceFilters);
			MetaPathParameterValues.Add("e91b04af-7a52-4f54-a02b-32ac50a9f8ad", () => SaveLeadHandoff.RecordColumnValues);
			MetaPathParameterValues.Add("1f789915-973d-451b-b755-63de28256494", () => SaveLeadHandoff.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("a147d2f0-eb4f-4a91-bda3-6b4d5423014b", () => SaveLeadNoInterest.EntitySchemaUId);
			MetaPathParameterValues.Add("d71bf98b-10c9-4b4e-9da3-927f4c707df2", () => SaveLeadNoInterest.IsMatchConditions);
			MetaPathParameterValues.Add("8b04704d-b57f-4aed-8143-0ba2dc774953", () => SaveLeadNoInterest.DataSourceFilters);
			MetaPathParameterValues.Add("63cb5219-81b3-4e2c-8f12-bb56e164296d", () => SaveLeadNoInterest.RecordColumnValues);
			MetaPathParameterValues.Add("9bbd4a51-ba19-4092-b17e-e8cb144490a9", () => SaveLeadNoInterest.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("55dd5f60-cee9-44b6-8f68-b543a4174bf2", () => AddReminder.EntitySchemaId);
			MetaPathParameterValues.Add("7a3aa063-9af4-482e-adbf-9312dad8b0bf", () => AddReminder.DataSourceFilters);
			MetaPathParameterValues.Add("2e6f433c-09c2-46dc-89d2-80e6a8f6ebda", () => AddReminder.RecordAddMode);
			MetaPathParameterValues.Add("ddff7e72-873c-4e34-a274-b1fe98dc4dc5", () => AddReminder.FilterEntitySchemaId);
			MetaPathParameterValues.Add("95dfe792-7d3e-4db6-8add-2effff3ca7f4", () => AddReminder.RecordDefValues);
			MetaPathParameterValues.Add("2af26cad-fdd2-4138-9712-bb3c00009344", () => AddReminder.RecordId);
			MetaPathParameterValues.Add("70277ea6-1d86-4786-918d-17e2bb4b24f4", () => AddReminder.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("88b815f6-9ed2-474a-a40e-f96b169054b4", () => ReadLeadData.DataSourceFilters);
			MetaPathParameterValues.Add("7c774b4b-6e9a-4ef1-bd4d-4af18e1f5a68", () => ReadLeadData.ResultType);
			MetaPathParameterValues.Add("4a5fff69-b63a-49e0-a7c9-da42ff12623b", () => ReadLeadData.ReadSomeTopRecords);
			MetaPathParameterValues.Add("1b730802-2250-4ca2-84c5-b50b5d4a07fb", () => ReadLeadData.NumberOfRecords);
			MetaPathParameterValues.Add("be3ad5ec-1ac1-4d88-8421-74079d80259b", () => ReadLeadData.FunctionType);
			MetaPathParameterValues.Add("19076150-3efa-4513-be4e-b624b7233322", () => ReadLeadData.AggregationColumnName);
			MetaPathParameterValues.Add("9adb2ee5-70ec-4c6c-b1ab-4cb1ddf4c59b", () => ReadLeadData.OrderInfo);
			MetaPathParameterValues.Add("81e8d9be-76bf-41e2-a013-9bfb7a60bbf7", () => ReadLeadData.ResultEntity);
			MetaPathParameterValues.Add("0a4b4eb8-5619-4c19-a817-49e7435ddac0", () => ReadLeadData.ResultCount);
			MetaPathParameterValues.Add("18ee65b6-9004-44b1-b810-660c4b69eb54", () => ReadLeadData.ResultIntegerFunction);
			MetaPathParameterValues.Add("2ba36ea2-087d-4183-8f2e-029d86d94b6b", () => ReadLeadData.ResultFloatFunction);
			MetaPathParameterValues.Add("39c22bae-af9c-474a-8c12-e087a1cc5bcc", () => ReadLeadData.ResultDateTimeFunction);
			MetaPathParameterValues.Add("befd9ddf-c017-4e87-bf55-98e25f140075", () => ReadLeadData.ResultRowsCount);
			MetaPathParameterValues.Add("2fd8069c-26a9-41c0-9022-20c047525340", () => ReadLeadData.CanReadUncommitedData);
			MetaPathParameterValues.Add("b92dc5ab-c714-451b-b938-04990fc76593", () => ReadLeadData.ResultEntityCollection);
			MetaPathParameterValues.Add("904a1de6-b8cd-43d7-a193-0a8234806d6f", () => ReadLeadData.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("addb84e6-59ea-4d30-acaf-3f26b8c94365", () => ReadLeadData.IgnoreDisplayValues);
			MetaPathParameterValues.Add("9891f0ad-db82-488b-aedd-64f50dc28baf", () => ReadLeadData.ResultCompositeObjectList);
			MetaPathParameterValues.Add("58751358-9137-4811-8c8b-e31b4917cc58", () => ReadLeadData.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("ca3d3049-0f26-41a3-bca2-dd669a7d3396", () => ReadLeadType.DataSourceFilters);
			MetaPathParameterValues.Add("9bb7fdf0-23d9-4a53-9bfc-b65d5b2b58ef", () => ReadLeadType.ResultType);
			MetaPathParameterValues.Add("1fc1bf95-66f6-437e-ae96-ab0226deef9f", () => ReadLeadType.ReadSomeTopRecords);
			MetaPathParameterValues.Add("b6eaed28-95a3-4e02-bc92-584da91d9666", () => ReadLeadType.NumberOfRecords);
			MetaPathParameterValues.Add("8af81470-64e6-4c25-bc4e-996386dd37c1", () => ReadLeadType.FunctionType);
			MetaPathParameterValues.Add("876c91d3-f5fd-430b-99a7-6da066af2251", () => ReadLeadType.AggregationColumnName);
			MetaPathParameterValues.Add("a511d00e-3b57-438c-ad43-a0b965ac41ff", () => ReadLeadType.OrderInfo);
			MetaPathParameterValues.Add("d5067126-b12c-401d-83cc-53d80a232257", () => ReadLeadType.ResultEntity);
			MetaPathParameterValues.Add("c25ddf34-5ec7-43ef-9f1b-1f022d5afa06", () => ReadLeadType.ResultCount);
			MetaPathParameterValues.Add("39e87f5c-2965-45a4-8ce7-4446e1173001", () => ReadLeadType.ResultIntegerFunction);
			MetaPathParameterValues.Add("3aec9151-bb18-4f05-9f98-6ef24b8eb8fa", () => ReadLeadType.ResultFloatFunction);
			MetaPathParameterValues.Add("8319a4e6-2ecb-470d-b2fd-9af8514e9ab2", () => ReadLeadType.ResultDateTimeFunction);
			MetaPathParameterValues.Add("0e55a545-db7b-429c-8850-c3c910df6b27", () => ReadLeadType.ResultRowsCount);
			MetaPathParameterValues.Add("d246ad4e-36de-4230-bc79-a36f43b1befe", () => ReadLeadType.CanReadUncommitedData);
			MetaPathParameterValues.Add("7ad11547-1b9b-4507-b7ff-0d224aa61262", () => ReadLeadType.ResultEntityCollection);
			MetaPathParameterValues.Add("5bfef119-7795-4c1c-8d01-0d38138f2a41", () => ReadLeadType.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("3e1d582a-dce9-475f-9eed-bc65b2d11830", () => ReadLeadType.IgnoreDisplayValues);
			MetaPathParameterValues.Add("ebb14ab8-1576-4069-9eff-8964285cc2b3", () => ReadLeadType.ResultCompositeObjectList);
			MetaPathParameterValues.Add("fd914a29-a951-4c58-a6e5-7402fa7e8761", () => ReadLeadType.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("fe828bdd-0b5b-4b21-8d0d-7fe8bbb6c978", () => ReadLeadContact.DataSourceFilters);
			MetaPathParameterValues.Add("b4af7ceb-60b9-467c-a8b3-81953d377341", () => ReadLeadContact.ResultType);
			MetaPathParameterValues.Add("311fcede-bca4-4fec-9a42-0f943fe03159", () => ReadLeadContact.ReadSomeTopRecords);
			MetaPathParameterValues.Add("4f32f247-07f2-471b-ba49-b42cae200cf0", () => ReadLeadContact.NumberOfRecords);
			MetaPathParameterValues.Add("d72c0941-da6e-42f6-b7a5-0b3ffe8b2c2e", () => ReadLeadContact.FunctionType);
			MetaPathParameterValues.Add("3356dca2-6b01-46e0-9fe2-d0de44ff97b0", () => ReadLeadContact.AggregationColumnName);
			MetaPathParameterValues.Add("d550d767-aeda-4cf2-9b2a-90c7c38be81b", () => ReadLeadContact.OrderInfo);
			MetaPathParameterValues.Add("fff72291-b74e-4830-8333-56ad140e6e7c", () => ReadLeadContact.ResultEntity);
			MetaPathParameterValues.Add("05f02083-70af-4052-8ee7-2b228747244c", () => ReadLeadContact.ResultCount);
			MetaPathParameterValues.Add("123bb774-23e8-4cbe-a707-c0bf2149c012", () => ReadLeadContact.ResultIntegerFunction);
			MetaPathParameterValues.Add("a43adf8a-3d3f-4d55-bbb1-030b98ca7464", () => ReadLeadContact.ResultFloatFunction);
			MetaPathParameterValues.Add("2a298fa9-f151-46ad-b486-c3c3bcb89af4", () => ReadLeadContact.ResultDateTimeFunction);
			MetaPathParameterValues.Add("51b3ba73-2cd0-43a5-b1bb-d655502ea451", () => ReadLeadContact.ResultRowsCount);
			MetaPathParameterValues.Add("bd94e2da-67c7-4c33-985e-1f6fdecc4562", () => ReadLeadContact.CanReadUncommitedData);
			MetaPathParameterValues.Add("53665a2a-42d9-47f3-8bf4-e4ebbd2e10f3", () => ReadLeadContact.ResultEntityCollection);
			MetaPathParameterValues.Add("f382eb7c-1c7a-4c11-93b3-5b6271585801", () => ReadLeadContact.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("377fdd7e-2835-4e98-a892-93bd77cfe77f", () => ReadLeadContact.IgnoreDisplayValues);
			MetaPathParameterValues.Add("76b641e0-afa5-49a2-a9f7-6c63a2f449de", () => ReadLeadContact.ResultCompositeObjectList);
			MetaPathParameterValues.Add("4ea3d1b9-bd07-4221-9d68-e9102d93f89a", () => ReadLeadContact.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("bbe769c2-34d8-4a8b-a580-a9e4311e6053", () => DistributionLeadPage.Title);
			MetaPathParameterValues.Add("5160bb63-99ee-4be0-ad4e-f804a2c25915", () => DistributionLeadPage.Recommendation);
			MetaPathParameterValues.Add("2021bd48-f45e-4cd3-b993-7b97a0c3308d", () => DistributionLeadPage.ClientUnitSchemaUId);
			MetaPathParameterValues.Add("1905b493-d577-4148-a465-5b25ff5f0ab4", () => DistributionLeadPage.EntityId);
			MetaPathParameterValues.Add("702a610c-eae3-442a-b9e5-1eae1657abca", () => DistributionLeadPage.EntryPointId);
			MetaPathParameterValues.Add("ab6017ca-8f69-4ec1-95d6-57eb04cec232", () => DistributionLeadPage.EntitySchemaUId);
			MetaPathParameterValues.Add("1babcc34-fbcc-4e3e-84fe-432c05fdbbe5", () => DistributionLeadPage.UseCardProcessModule);
			MetaPathParameterValues.Add("583c0a7d-9ed9-49b6-919b-fb6caaff12fd", () => DistributionLeadPage.OwnerId);
			MetaPathParameterValues.Add("3aeda084-6af5-44ea-8738-d38edc340131", () => DistributionLeadPage.ShowExecutionPage);
			MetaPathParameterValues.Add("63033799-a11b-4b1e-9c2b-6e17977e2c43", () => DistributionLeadPage.InformationOnStep);
			MetaPathParameterValues.Add("809907b4-6caf-4cda-8cd8-58f9c1196633", () => DistributionLeadPage.IsRunning);
			MetaPathParameterValues.Add("b6ff1632-8447-43c2-9b76-658146844be1", () => DistributionLeadPage.Template);
			MetaPathParameterValues.Add("7235fee8-643a-4105-bf60-d6e3855e65b9", () => DistributionLeadPage.Module);
			MetaPathParameterValues.Add("f164d1ac-d486-4ad3-91da-1174260bbd01", () => DistributionLeadPage.PressedButtonCode);
			MetaPathParameterValues.Add("1c855ecf-3361-49bf-825f-6281043116c4", () => DistributionLeadPage.Url);
			MetaPathParameterValues.Add("989facc2-6ae0-4fdb-b1b6-62dfc27340b9", () => DistributionLeadPage.CurrentActivityId);
			MetaPathParameterValues.Add("5b402470-dc18-4ccf-851a-bbcb02592ea6", () => DistributionLeadPage.CreateActivity);
			MetaPathParameterValues.Add("782c00f4-9b07-442c-9934-9625bcb359e3", () => DistributionLeadPage.ActivityPriority);
			MetaPathParameterValues.Add("ae2d70f4-fc2c-444b-b9aa-d6ee291cf5a9", () => DistributionLeadPage.StartIn);
			MetaPathParameterValues.Add("83b4d7eb-5443-4712-856b-4ac60c649892", () => DistributionLeadPage.StartInPeriod);
			MetaPathParameterValues.Add("27ff394f-d930-4f15-a24c-1c9d5e1b845e", () => DistributionLeadPage.Duration);
			MetaPathParameterValues.Add("a8925615-57bf-48b5-97fb-331918c63cbd", () => DistributionLeadPage.DurationPeriod);
			MetaPathParameterValues.Add("71739197-e65a-4d1d-8e67-01c450fbb93b", () => DistributionLeadPage.ShowInScheduler);
			MetaPathParameterValues.Add("99c2bbee-c62d-4595-949a-680e80d63d2a", () => DistributionLeadPage.RemindBefore);
			MetaPathParameterValues.Add("1556d288-a331-4a11-bea7-2e4378450cda", () => DistributionLeadPage.RemindBeforePeriod);
			MetaPathParameterValues.Add("7e1d7dce-3248-4f36-9b46-703de981b0ea", () => DistributionLeadPage.ActivityResult);
			MetaPathParameterValues.Add("7fe10b97-084f-4f8e-ade5-8f4b0abf384e", () => DistributionLeadPage.IsActivityCompleted);
			MetaPathParameterValues.Add("345b747f-6492-4686-a503-0062acd716e0", () => DistributionLeadPage.LeadId);
			MetaPathParameterValues.Add("a9e78508-ae1b-4141-abe0-24ed11eadb13", () => DistributionLeadPage.Result);
			MetaPathParameterValues.Add("cd5eefc4-6c19-4719-be10-6babbc9acc6e", () => DistributionLeadPage.RemindToOwner);
			MetaPathParameterValues.Add("0d01d7bb-ccf9-4184-a64f-953b68988ea4", () => DistributionLeadPage.LeadOwnerId);
			MetaPathParameterValues.Add("8227a76e-e673-40a1-a3f3-2102ef5efe7a", () => DistributionLeadPage.OpportunityDepartment);
			MetaPathParameterValues.Add("560bc47f-ebc5-4687-aa0c-08705e061a9a", () => SaveLeadByDefault.EntitySchemaUId);
			MetaPathParameterValues.Add("c4e20e54-2a71-4e75-a167-24858aec6fcb", () => SaveLeadByDefault.IsMatchConditions);
			MetaPathParameterValues.Add("ba1c792f-b05d-43b6-b1d4-1f6f092ae9d7", () => SaveLeadByDefault.DataSourceFilters);
			MetaPathParameterValues.Add("f3fd0d58-28e8-457f-8737-49c12cc4cc1d", () => SaveLeadByDefault.RecordColumnValues);
			MetaPathParameterValues.Add("737a2969-6bcd-4de0-bf6f-2dbd679718d8", () => SaveLeadByDefault.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("3113a34a-8da2-40e6-8256-f154360ef8a5", () => IntermediateCatchSignal1.RecordId);
			MetaPathParameterValues.Add("eaf23f6b-c09c-445f-910f-846067cc4260", () => LinkLeadToProcess.EntityId);
			MetaPathParameterValues.Add("eb235528-1302-40b2-8b0d-75f09ed4804b", () => LinkLeadToProcess.EntitySchemaId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "DistributionLeadPage.LeadId":
					DistributionLeadPage.LeadId = reader.GetValue<System.Guid>();
				break;
				case "DistributionLeadPage.Result":
					DistributionLeadPage.Result = reader.GetValue<System.String>();
				break;
				case "DistributionLeadPage.RemindToOwner":
					DistributionLeadPage.RemindToOwner = reader.GetValue<System.Boolean>();
				break;
				case "DistributionLeadPage.LeadOwnerId":
					DistributionLeadPage.LeadOwnerId = reader.GetValue<System.Guid>();
				break;
				case "DistributionLeadPage.OpportunityDepartment":
					DistributionLeadPage.OpportunityDepartment = reader.GetValue<System.Guid>();
				break;
				case "LeadId":
					if (!hasValueToRead) break;
					LeadId = reader.GetValue<System.Guid>();
				break;
				case "NotificationTemplate":
					if (!hasValueToRead) break;
					NotificationTemplate = reader.GetValue<System.String>();
				break;
				case "CreateReminder":
					if (!hasValueToRead) break;
					CreateReminder = reader.GetValue<System.Boolean>();
				break;
				case "ResponsibleId":
					if (!hasValueToRead) break;
					ResponsibleId = reader.GetValue<System.Guid>();
				break;
				case "ShowDistributionPage":
					if (!hasValueToRead) break;
					ShowDistributionPage = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

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
			var cloneItem = (LeadManagementDistribution10)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

