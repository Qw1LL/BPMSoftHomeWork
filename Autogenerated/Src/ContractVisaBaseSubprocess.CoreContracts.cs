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

	#region Class: ContractVisaBaseSubprocessSchema

	/// <exclude/>
	public class ContractVisaBaseSubprocessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ContractVisaBaseSubprocessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ContractVisaBaseSubprocessSchema(ContractVisaBaseSubprocessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ContractVisaBaseSubprocess";
			UId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53");
			CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2976";
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
			RealUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53");
			Version = 0;
			PackageUId = new Guid("29c7b5a2-1b24-4486-9276-6f30e0b427b5");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateContractParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3a0d5732-da62-4c3b-a064-34320b6b3b70"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"Contract",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateVisaOwnerParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c77907f0-2c9c-4bf7-8e77-d9e1cf50c135"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaOwner",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateVisaObjectiveParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("50d952fa-4e0b-414d-a1d6-444068fea4a1"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaObjective",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateVisaResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d2fd2fb7-ec08-4092-840e-40479398aece"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsAllowedToDelegateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3cafec33-e6b4-4fdf-b420-5fa70f8373c2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"IsAllowedToDelegate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsPreviousVisaCountsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2b0415c8-fe33-430e-b6b0-0d6cee817372"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"IsPreviousVisaCounts",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateContractParameter());
			Parameters.Add(CreateVisaOwnerParameter());
			Parameters.Add(CreateVisaObjectiveParameter());
			Parameters.Add(CreateVisaResultParameter());
			Parameters.Add(CreateIsAllowedToDelegateParameter());
			Parameters.Add(CreateIsPreviousVisaCountsParameter());
		}

		protected virtual void InitializeCancelPreviousVisasParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("6c9b198f-bc19-4b69-ab86-d1dd9334339a"),
				ContainerUId = new Guid("535b4886-240c-4ff4-917d-84b951475499"),
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
				Value = @"e2edcaf0-4bec-418f-9c13-b1e07e7244c5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("49cbb5c4-bd70-43aa-8f31-4879e73d2376"),
				ContainerUId = new Guid("535b4886-240c-4ff4-917d-84b951475499"),
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d6d65720-6f5e-4f79-b9bc-19d68d9d465f"),
				ContainerUId = new Guid("535b4886-240c-4ff4-917d-84b951475499"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,87,75,139,27,71,16,254,47,115,200,105,42,244,115,186,91,185,121,217,128,33,108,12,121,16,48,139,233,71,181,119,88,73,35,75,35,98,35,4,206,250,100,8,49,132,92,141,201,63,48,9,78,54,49,241,111,24,253,163,148,164,149,163,44,202,198,222,181,15,27,114,152,87,207,212,179,191,175,170,102,118,167,158,124,92,247,91,28,247,178,239,79,176,156,222,76,189,66,240,160,178,10,8,222,57,1,138,73,14,46,102,14,30,209,74,163,5,67,19,139,114,232,7,216,43,214,210,251,169,110,139,178,110,113,48,233,221,158,253,165,180,29,79,177,188,147,87,15,159,197,35,28,248,47,150,6,80,96,138,62,51,32,35,17,20,183,153,12,112,9,129,35,51,104,132,82,81,23,107,95,18,175,124,246,90,67,172,66,5,10,157,2,107,13,2,139,57,69,199,185,209,46,23,101,31,115,187,127,127,52,198,201,164,110,134,189,25,190,190,255,252,193,136,188,92,219,222,107,250,211,193,176,40,7,216,250,91,190,61,234,21,25,89,202,62,90,210,238,16,148,81,10,2,147,12,82,229,156,117,82,71,199,84,81,70,63,106,151,106,139,238,135,238,85,247,51,29,63,117,175,22,15,139,114,140,25,199,56,140,184,21,155,117,38,160,68,5,76,74,9,170,50,137,28,70,1,193,120,167,116,100,201,114,86,148,201,183,254,75,223,159,226,202,191,89,77,130,65,56,205,12,207,96,208,59,138,180,18,96,19,247,224,184,11,89,26,41,114,22,155,172,127,210,52,199,211,17,101,124,114,48,29,224,184,142,103,219,135,180,15,205,184,55,139,205,176,29,55,253,165,242,131,45,129,245,54,157,189,252,106,157,154,254,234,205,82,176,152,151,211,9,238,245,107,28,182,251,195,216,164,122,120,119,181,131,243,57,201,12,70,126,92,79,54,9,221,191,55,245,125,74,64,125,247,232,194,196,239,77,39,109,51,184,110,241,150,20,43,169,33,208,174,124,94,98,58,213,147,81,223,63,88,61,247,138,15,238,77,155,246,163,191,195,97,189,86,156,147,221,124,43,61,75,154,130,130,228,41,80,21,101,0,207,42,5,82,73,193,66,21,100,48,236,76,195,188,188,178,181,219,55,39,159,126,61,220,112,110,157,172,195,15,105,245,220,194,173,141,116,111,246,38,14,206,15,55,46,30,18,38,222,41,207,157,96,62,36,29,129,47,73,168,76,202,96,185,8,16,144,241,10,115,10,57,94,133,231,82,122,163,145,17,214,18,105,15,172,2,175,56,131,224,208,73,33,43,165,3,223,230,249,247,221,105,247,107,119,186,120,184,120,180,248,110,241,152,158,126,251,7,182,83,161,84,193,121,210,25,137,237,49,100,240,220,83,61,193,200,68,228,116,114,241,186,161,255,127,182,239,230,223,14,80,92,204,194,104,140,99,134,224,47,162,35,248,135,108,192,162,49,144,28,242,152,53,35,42,232,127,225,252,91,219,188,4,243,223,196,205,247,200,252,74,120,41,67,78,144,43,77,133,199,83,225,177,220,35,36,30,120,8,146,163,117,246,242,204,143,38,9,86,121,34,40,227,228,8,115,26,130,87,18,140,54,209,102,238,56,141,20,219,204,127,218,189,232,158,119,191,47,78,22,143,232,250,114,241,109,247,71,247,124,39,131,29,85,69,29,178,5,150,243,50,68,197,193,82,38,65,40,193,232,198,103,74,234,134,193,55,154,166,143,126,248,22,20,222,59,194,120,124,163,185,127,158,192,20,102,60,14,180,190,139,190,43,157,87,224,239,107,80,92,175,128,119,180,235,243,228,88,125,248,30,192,27,149,100,193,167,10,178,80,153,192,75,8,14,82,89,8,58,72,159,172,137,148,177,203,131,87,91,164,89,178,66,48,210,82,219,162,6,73,227,233,146,163,140,20,19,51,173,87,105,27,188,63,210,100,240,205,226,132,206,79,8,182,167,221,139,221,77,171,170,8,250,218,71,208,68,14,80,25,45,56,237,25,88,231,157,69,105,178,54,249,250,55,173,131,166,125,55,184,255,15,12,170,207,104,108,124,73,199,47,212,74,78,168,194,157,213,181,197,147,139,155,9,26,71,127,71,65,130,140,52,24,42,137,6,188,166,31,37,26,204,60,23,26,43,46,197,86,95,56,156,255,9,173,221,249,92,80,14,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("11edda32-f2fb-41b4-8837-0586bfabade5"),
				ContainerUId = new Guid("535b4886-240c-4ff4-917d-84b951475499"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,157,82,221,111,130,48,16,255,87,150,198,71,107,40,22,16,30,55,182,196,68,23,51,157,47,99,15,103,185,42,9,31,166,192,50,103,248,223,87,42,70,76,220,195,236,195,53,237,221,239,163,215,59,146,65,117,216,35,9,200,227,98,190,44,100,53,122,42,20,142,22,170,16,88,150,163,89,33,32,77,126,96,147,226,2,20,100,88,161,90,67,90,99,57,75,202,106,248,208,7,145,33,25,124,153,28,9,62,142,100,90,97,246,62,141,53,179,96,182,195,98,135,81,95,122,54,229,40,128,250,232,74,42,199,62,115,185,197,125,215,178,52,88,20,105,157,229,115,172,96,1,213,142,4,71,98,216,90,2,47,182,45,23,128,114,139,9,29,124,135,110,128,143,169,231,120,98,34,153,207,56,250,164,25,146,82,236,48,3,35,122,1,163,141,177,0,105,81,190,65,13,102,19,73,125,193,198,116,195,208,242,208,179,57,23,78,11,238,234,47,192,149,210,155,78,196,73,185,79,225,176,254,43,191,191,106,76,191,226,24,157,186,27,145,32,186,221,223,110,95,26,227,215,29,190,110,110,68,134,17,89,22,181,18,45,27,107,15,231,199,26,118,171,91,244,70,56,175,19,135,129,205,33,135,45,170,87,173,103,224,38,21,66,5,70,122,165,61,255,155,248,13,37,42,204,5,222,105,108,221,42,95,204,156,231,64,223,228,117,154,26,129,210,188,191,29,172,206,120,151,9,123,63,212,99,40,226,68,38,24,79,243,59,29,133,40,13,229,75,161,158,191,245,184,39,249,182,251,175,158,244,165,38,20,89,119,223,144,166,249,108,126,1,141,190,212,196,91,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5c9cfea5-678f-44ea-a6b1-85de2a653ac2"),
				ContainerUId = new Guid("535b4886-240c-4ff4-917d-84b951475499"),
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

		protected virtual void InitializeAddVisaParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("69a4680b-dced-4f91-9736-b89098e9b12c"),
				ContainerUId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd"),
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
				Value = @"e2edcaf0-4bec-418f-9c13-b1e07e7244c5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ce9ba715-9c2b-4b46-b3cd-a342eea5cf22"),
				ContainerUId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd"),
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fbf6a978-d0cf-473f-8ce4-5a20e548bb14"),
				ContainerUId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd"),
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
				UId = new Guid("3691ae8b-153d-41dc-8223-2f176da23196"),
				ContainerUId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd"),
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a9c1fff-05ca-424d-919c-e1edf51210b3"),
				ContainerUId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,79,111,91,69,16,192,191,74,244,218,163,39,218,127,111,255,248,8,1,41,82,3,17,129,94,226,28,102,119,103,91,75,254,19,217,14,80,34,75,145,122,1,129,56,32,62,0,39,206,85,75,68,16,34,159,225,249,27,49,126,118,136,67,171,40,234,41,106,251,164,247,236,183,187,51,179,222,153,223,204,248,180,122,56,123,118,76,85,183,250,104,127,239,96,92,102,219,31,143,39,180,189,63,25,39,154,78,183,31,141,19,14,250,223,97,28,208,62,78,112,72,51,154,60,198,193,9,77,31,245,167,179,206,214,166,80,213,169,30,126,221,206,85,221,195,211,106,119,70,195,175,118,51,107,150,136,193,231,154,192,162,209,96,98,40,128,2,35,88,173,20,154,58,150,34,2,11,167,241,224,100,56,218,163,25,238,227,236,105,213,61,173,90,109,172,32,41,175,146,87,6,28,162,4,99,162,129,232,139,128,156,80,20,210,217,71,19,171,121,167,154,166,167,52,196,214,232,181,48,41,226,117,188,218,68,74,96,164,47,16,146,212,16,37,9,71,78,25,147,234,165,240,122,253,181,224,225,131,195,221,233,231,223,140,104,114,208,234,237,22,28,76,233,104,155,71,255,55,240,223,209,116,79,107,145,67,173,10,130,33,17,217,154,201,128,50,91,222,180,17,214,23,66,131,114,126,244,224,104,105,49,247,167,199,3,124,246,248,117,195,205,239,205,121,243,247,226,167,173,230,101,115,209,252,185,248,113,37,112,124,195,5,155,34,167,189,149,31,123,85,183,247,102,79,174,63,87,59,191,233,203,155,110,236,85,157,94,117,48,62,153,164,165,54,189,124,185,58,214,86,187,88,95,240,134,199,213,181,210,209,138,237,225,8,159,208,228,51,182,215,138,183,83,59,56,195,214,244,151,188,231,43,197,57,71,141,146,8,216,45,30,76,182,10,162,195,0,89,144,149,62,10,81,98,110,165,191,160,66,19,26,37,122,203,141,181,150,175,55,115,21,113,60,50,58,25,12,90,3,211,246,247,47,67,120,189,241,245,204,206,134,203,54,52,140,115,191,244,41,239,142,222,114,71,59,84,90,149,159,142,39,159,124,203,96,245,71,79,214,254,218,48,125,189,102,39,13,215,227,243,106,62,239,108,178,150,165,148,24,29,1,58,105,56,254,2,129,79,164,193,22,111,28,74,107,36,250,91,89,43,90,163,171,73,128,163,204,10,162,176,128,70,10,136,129,130,86,218,50,175,242,158,176,150,156,11,194,177,53,149,2,91,139,197,129,39,231,32,7,146,169,212,130,45,215,119,96,237,151,37,98,205,197,226,108,241,124,241,243,226,7,126,251,235,125,192,45,170,80,11,39,11,59,154,33,51,196,184,249,44,17,130,12,177,104,167,85,41,234,54,220,188,41,156,137,3,103,186,152,56,171,167,200,89,157,131,11,18,37,161,146,228,71,72,239,60,110,162,102,160,180,149,92,138,10,135,96,226,196,31,98,114,144,68,206,89,249,26,37,87,166,91,113,35,145,11,38,62,54,203,168,26,103,184,180,9,205,165,205,134,224,131,174,83,16,230,158,224,166,81,228,154,227,2,50,114,172,152,164,35,151,113,107,64,27,173,68,180,81,71,39,238,128,219,175,205,101,243,138,239,151,205,229,226,236,3,104,119,0,45,184,72,154,12,8,173,25,52,235,50,120,79,171,226,104,106,142,52,47,223,253,186,38,29,103,43,84,26,82,212,220,2,58,73,16,83,176,224,10,199,121,42,134,195,47,221,10,154,203,166,214,204,9,24,207,59,53,46,48,38,222,120,176,206,201,140,38,40,225,236,125,1,141,77,81,98,95,147,229,78,215,148,92,32,26,37,160,46,232,68,241,28,50,73,221,1,180,223,154,23,220,58,158,53,231,139,239,185,155,252,167,185,220,106,254,88,182,149,124,191,90,150,187,150,193,23,60,113,209,156,191,15,28,6,78,82,252,103,195,131,40,203,92,45,141,4,207,29,4,40,62,91,254,130,133,155,137,15,253,37,189,198,225,209,252,95,2,64,52,24,37,14,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("58cb0143-4eb3-4db4-b3d9-85dbab73eef1"),
				ContainerUId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd"),
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
				UId = new Guid("40034502-d147-42a5-ad98-6ebaa49dd191"),
				ContainerUId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd"),
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

		protected virtual void InitializeVisaApprovedEventParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c031b7d4-47c5-4757-b402-f10b423e1766"),
				ContainerUId = new Guid("e6b71c76-86d0-43a1-8852-c815814f361e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8d004d94-5e54-4b1e-80a4-f03f34f6f0bd}].[Parameter:{58cb0143-4eb3-4db4-b3d9-85dbab73eef1}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeVisaRejectedEventParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a3b7e6ec-ad76-4a63-9b48-ee16803ca206"),
				ContainerUId = new Guid("b0ff5122-dde6-487d-a7e0-e7ba43e507a9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8d004d94-5e54-4b1e-80a4-f03f34f6f0bd}].[Parameter:{58cb0143-4eb3-4db4-b3d9-85dbab73eef1}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeVisaCanceledEventParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9cba3ba9-8b2e-4d4b-a3a5-ba1a989ed52a"),
				ContainerUId = new Guid("7c046ee4-d44b-49a9-9e4f-4606b8554bec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8d004d94-5e54-4b1e-80a4-f03f34f6f0bd}].[Parameter:{58cb0143-4eb3-4db4-b3d9-85dbab73eef1}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeFindPositiveVisaParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2cb83f28-00c3-4498-b39b-2f4679606074"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,221,138,28,69,20,199,223,165,47,188,234,35,245,217,85,53,222,101,89,33,32,49,224,7,66,88,66,125,156,202,54,59,51,61,153,233,193,132,97,33,110,174,2,98,64,188,21,241,13,130,18,93,13,230,25,122,222,200,211,51,59,113,92,198,53,217,53,23,171,94,76,79,119,117,87,213,57,167,254,191,58,167,22,119,235,217,251,245,176,197,233,32,251,225,12,203,249,205,52,40,42,159,171,42,138,10,12,250,8,138,51,11,182,18,22,28,99,86,85,137,73,161,76,81,142,253,8,7,197,186,247,126,170,219,162,172,91,28,205,6,119,22,127,12,218,78,231,88,222,205,171,135,143,226,33,142,252,39,253,4,40,48,69,159,25,168,128,253,4,54,131,139,92,66,224,200,12,26,161,84,212,197,218,22,147,67,148,34,120,112,62,100,80,137,115,8,198,75,200,153,51,93,49,142,129,243,162,28,98,110,247,31,76,166,56,155,213,205,120,176,192,87,247,31,63,156,144,149,235,185,247,154,225,124,52,46,202,17,182,254,182,111,15,7,69,70,150,178,143,22,98,229,16,148,81,10,2,147,12,82,229,156,117,82,71,199,84,81,70,63,105,251,97,139,238,155,238,101,247,35,253,126,232,94,46,31,21,229,20,51,78,113,28,113,203,55,235,76,64,137,10,152,148,18,84,101,18,88,139,162,183,218,41,29,89,178,156,21,101,242,173,255,212,15,231,184,178,111,81,83,199,32,156,102,134,231,62,234,14,20,86,2,108,226,228,56,119,33,75,35,69,206,98,19,245,15,154,230,104,62,161,136,207,110,205,71,56,173,227,217,242,33,173,67,51,29,44,98,51,110,167,205,176,31,252,214,86,135,245,50,157,189,252,108,29,154,225,234,77,223,177,56,46,231,51,220,27,214,56,110,247,199,177,73,245,248,222,106,5,143,143,169,207,104,226,167,245,108,19,208,253,251,115,63,164,0,212,247,14,47,12,252,222,124,214,54,163,235,230,111,73,190,210,48,36,218,149,205,189,166,83,61,155,12,253,195,213,243,160,120,231,254,188,105,223,251,179,28,214,109,197,185,190,155,111,165,103,73,147,83,144,60,57,170,162,12,224,89,165,64,42,41,88,168,130,12,134,157,141,112,92,94,121,182,59,55,103,31,126,62,222,48,183,14,214,193,187,212,122,174,225,246,166,247,96,241,58,6,30,31,108,76,60,32,77,252,163,156,87,73,100,158,88,5,42,27,194,198,50,14,222,99,2,166,53,102,30,21,38,25,175,192,185,148,222,104,100,164,181,164,200,26,154,199,211,190,6,193,161,147,66,86,74,7,190,205,249,215,221,105,247,115,119,186,124,180,124,188,252,106,249,132,158,126,249,11,218,85,86,42,56,79,99,70,50,59,210,30,229,185,167,253,4,35,19,145,211,197,197,235,166,254,255,105,223,205,223,14,81,92,76,97,52,198,49,67,242,23,209,145,252,67,54,96,209,24,72,14,121,204,154,17,10,250,111,152,127,227,57,47,65,254,235,152,249,22,201,103,22,81,49,33,128,11,71,108,10,212,224,9,31,240,193,73,76,204,48,111,228,229,201,143,38,9,86,121,2,148,113,50,132,57,13,193,43,9,70,155,104,51,119,92,161,219,38,255,219,238,121,247,172,251,117,121,178,124,76,255,47,150,95,118,191,117,207,118,18,236,104,87,212,33,91,96,57,247,46,42,14,150,34,9,66,9,70,55,62,83,80,55,4,223,104,154,33,250,241,27,32,188,119,136,241,232,70,243,224,60,192,228,102,60,10,212,190,11,223,213,152,87,224,247,149,40,174,151,195,59,210,245,121,56,86,31,190,29,241,218,32,251,100,37,35,167,109,156,242,103,72,40,1,101,180,193,106,110,83,200,151,23,175,182,72,181,100,133,96,164,37,52,124,72,84,158,246,140,50,19,43,34,211,122,149,182,197,251,61,85,6,95,44,79,232,250,148,100,123,218,61,223,157,180,168,184,183,89,83,105,175,9,14,74,184,72,165,189,246,12,172,243,206,162,52,89,155,252,223,73,90,23,139,254,95,80,165,126,71,53,227,11,250,253,68,121,228,132,182,183,179,77,109,249,244,226,76,130,198,209,209,40,72,144,116,0,3,37,209,128,215,116,74,226,116,26,227,66,99,197,165,216,74,10,7,199,191,3,36,131,109,60,77,14,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9a26576c-c7c3-446c-84c6-01bfb60e881c"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6c8ba82f-8a97-45f4-84a5-d3fa4a515b71"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("71734acf-2f73-40f2-8700-2c88d70553ce"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e31e30a5-7698-42ba-bee5-b12248b7f70c"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("deaa2aa9-71f7-423c-950f-88351e8c8775"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bbaada9f-c766-4ba8-b5d1-b74d05465f22"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5"),
				UId = new Guid("468b242d-1dd5-4213-86e5-2cdc5fba51e2"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d6348dc3-4710-49a2-8cd5-eafb895e4fa5"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0ed51c81-29b7-44dc-8000-5478283dbe98"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("38909994-7218-4923-acc1-cb94b885239e"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("19a6723d-07af-4e13-b781-faa4906b1b21"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("195b1cc1-73e4-4d81-b1bc-fba63109558b"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2cf29bbb-a6c1-49f3-b333-58f19e6a7f0f"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5"),
				UId = new Guid("b9d95ef0-203a-45b1-b583-ce4f734719f6"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eac06a30-8133-464e-b39f-0f9124e46853"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6fabb303-28c8-4090-9fa2-d74dd5df6abd"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ac579543-3210-4dc5-aca8-f246c51e7882"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("461e4f0f-5fe4-4832-89b6-3ef93aa9af0c"),
				ContainerUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaLaneSet schemaContractVisa = CreateContractVisaLaneSet();
			LaneSets.Add(schemaContractVisa);
			ProcessSchemaLane schemaBPMCRM = CreateBPMCRMLane();
			schemaContractVisa.Lanes.Add(schemaBPMCRM);
			ProcessSchemaStartEvent startprocess = CreateStartProcessStartEvent();
			FlowElements.Add(startprocess);
			ProcessSchemaTerminateEvent visarejectedendprocess = CreateVisaRejectedEndProcessTerminateEvent();
			FlowElements.Add(visarejectedendprocess);
			ProcessSchemaUserTask cancelpreviousvisas = CreateCancelPreviousVisasUserTask();
			FlowElements.Add(cancelpreviousvisas);
			ProcessSchemaUserTask addvisa = CreateAddVisaUserTask();
			FlowElements.Add(addvisa);
			ProcessSchemaEventBasedGateway visaeventgateway = CreateVisaEventGatewayEventBasedGateway();
			FlowElements.Add(visaeventgateway);
			ProcessSchemaIntermediateCatchSignalEvent visaapprovedevent = CreateVisaApprovedEventIntermediateCatchSignalEvent();
			FlowElements.Add(visaapprovedevent);
			ProcessSchemaIntermediateCatchSignalEvent visarejectedevent = CreateVisaRejectedEventIntermediateCatchSignalEvent();
			FlowElements.Add(visarejectedevent);
			ProcessSchemaTerminateEvent visaapprovedendprocess = CreateVisaApprovedEndProcessTerminateEvent();
			FlowElements.Add(visaapprovedendprocess);
			ProcessSchemaTerminateEvent visacanceledendprocess = CreateVisaCanceledEndProcessTerminateEvent();
			FlowElements.Add(visacanceledendprocess);
			ProcessSchemaIntermediateCatchSignalEvent visacanceledevent = CreateVisaCanceledEventIntermediateCatchSignalEvent();
			FlowElements.Add(visacanceledevent);
			ProcessSchemaUserTask findpositivevisa = CreateFindPositiveVisaUserTask();
			FlowElements.Add(findpositivevisa);
			ProcessSchemaTerminateEvent alreadyexistsvisaendprocess = CreateAlreadyExistsVisaEndProcessTerminateEvent();
			FlowElements.Add(alreadyexistsvisaendprocess);
			ProcessSchemaTerminateEvent errorendprocess = CreateErrorEndProcessTerminateEvent();
			FlowElements.Add(errorendprocess);
			ProcessSchemaExclusiveGateway inputparametersgateway = CreateInputParametersGatewayExclusiveGateway();
			FlowElements.Add(inputparametersgateway);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaFormulaTask formulatask2 = CreateFormulaTask2FormulaTask();
			FlowElements.Add(formulatask2);
			ProcessSchemaFormulaTask formulatask3 = CreateFormulaTask3FormulaTask();
			FlowElements.Add(formulatask3);
			ProcessSchemaFormulaTask formulatask4 = CreateFormulaTask4FormulaTask();
			FlowElements.Add(formulatask4);
			ProcessSchemaFormulaTask formulatask5 = CreateFormulaTask5FormulaTask();
			FlowElements.Add(formulatask5);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateSequenceFlow15SequenceFlow());
			FlowElements.Add(CreateSequenceFlow16SequenceFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow17SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("1dc82dd8-37b0-41c4-9be8-77f8c650aa55"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("535b4886-240c-4ff4-917d-84b951475499"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("1258d959-0f51-4d43-afc5-af858431206f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6d317fc3-3ec1-4167-8100-d452dfeebaa2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("5c1c448f-c2e7-4f3c-9182-e636a81e7f7c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6d317fc3-3ec1-4167-8100-d452dfeebaa2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b0ff5122-dde6-487d-a7e0-e7ba43e507a9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("bb9764a1-e3ab-4542-986c-92da3fd39779"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b0ff5122-dde6-487d-a7e0-e7ba43e507a9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("51f42a41-e4fc-4878-a6cd-34cd87dc1969"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("0f49d1bc-bc71-436e-843b-a34c46c48362"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(662, 160),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6d317fc3-3ec1-4167-8100-d452dfeebaa2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e6b71c76-86d0-43a1-8852-c815814f361e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("087d1368-afa9-40b9-be32-2694e52e92da"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(769, 120),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e6b71c76-86d0-43a1-8852-c815814f361e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("df06cffd-2788-47f3-aa36-e9630c969070"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("b9961282-3cb6-4502-aa85-4444430f651b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(649, 266),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6d317fc3-3ec1-4167-8100-d452dfeebaa2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7c046ee4-d44b-49a9-9e4f-4606b8554bec"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("544d63d5-6acc-40a1-bb6e-8d8ea0190205"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(767, 302),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7c046ee4-d44b-49a9-9e4f-4606b8554bec"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0984b4ad-b023-4a3d-a496-1586cf9586d6"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("7623fa5a-d0ea-4b67-a2d2-e48bf8f59eaf"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{80386e6f-06c0-42ef-980b-c608cd4c8d26}].[Parameter:{d6348dc3-4710-49a2-8cd5-eafb895e4fa5}]#]>0",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(210, 289),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8dad276d-a200-40aa-92a0-bf4cb821d2fc"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow10",
				UId = new Guid("56ad27c9-8324-4da0-9a9f-e48181195aca"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(308, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("535b4886-240c-4ff4-917d-84b951475499"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("2baf54f3-f62d-4407-a7f7-8673978956af"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{c77907f0-2c9c-4bf7-8e77-d9e1cf50c135}]#] == null || [#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{3a0d5732-da62-4c3b-a064-34320b6b3b70}]#] == null",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(151, 225),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("113c262b-8fe0-4413-8ba5-8315e16ea3f2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("77e77a39-537a-4a84-a052-aec8ab139324"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow11",
				UId = new Guid("b2f53c23-91cd-453e-afbb-fec1183a0551"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(215, 147),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("113c262b-8fe0-4413-8ba5-8315e16ea3f2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("19e5e6ad-7695-4006-8c97-6f41ed28c7c9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("933b0a22-b066-47b7-a1eb-22ad3b60df27"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(160, 147),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ec42dc50-18dd-4744-816b-b2811303d2e1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("113c262b-8fe0-4413-8ba5-8315e16ea3f2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("82a29c07-c98e-461a-acb1-adc459002e03"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(196, 324),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("77e77a39-537a-4a84-a052-aec8ab139324"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3e0a1d3e-7215-4cac-807f-02a021ddd2a3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("15a2a359-fc14-47d5-b440-421f4c241560"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(769, 120),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("df06cffd-2788-47f3-aa36-e9630c969070"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e699229d-457b-40cc-94e1-d536113a8b65"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("21827e4a-8c02-4933-940e-dce0e25a9029"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(767, 302),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0984b4ad-b023-4a3d-a496-1586cf9586d6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f7ed8781-388b-41bb-913f-acec5ab5fa49"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow15SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow15",
				UId = new Guid("1d4dc3d3-4be4-49f6-8cfd-9309439632ce"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("51f42a41-e4fc-4878-a6cd-34cd87dc1969"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("de31436f-6b97-4b75-a6e9-12218945fb31"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow16SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow16",
				UId = new Guid("ebf681b6-4805-4601-87cf-3b22da74dcb5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(316, 312),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8dad276d-a200-40aa-92a0-bf4cb821d2fc"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("10c69615-38e8-4a65-a9ab-7f0bfc22a18d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("4eed58cf-4e0d-47f2-9ad9-b5341d3c41e3"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{2b0415c8-fe33-430e-b6b0-0d6cee817372}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(315, 216),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("19e5e6ad-7695-4006-8c97-6f41ed28c7c9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow17SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow17",
				UId = new Guid("8dde0824-6cfa-478e-901a-2c316c9deff5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				CurveCenterPosition = new Point(393, 148),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("19e5e6ad-7695-4006-8c97-6f41ed28c7c9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("535b4886-240c-4ff4-917d-84b951475499"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateContractVisaLaneSet() {
			ProcessSchemaLaneSet schemaContractVisa = new ProcessSchemaLaneSet(this) {
				UId = new Guid("ece8cb92-e6e7-4b4d-8cec-dd9f3a5c15b4"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"ContractVisa",
				Position = new Point(5, 5),
				Size = new Size(1090, 487),
				UseBackgroundMode = false
			};
			return schemaContractVisa;
		}

		protected virtual ProcessSchemaLane CreateBPMCRMLane() {
			ProcessSchemaLane schemaBPMCRM = new ProcessSchemaLane(this) {
				UId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("ece8cb92-e6e7-4b4d-8cec-dd9f3a5c15b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"BPMCRM",
				Position = new Point(29, 0),
				Size = new Size(1061, 487),
				UseBackgroundMode = false
			};
			return schemaBPMCRM;
		}

		protected virtual ProcessSchemaStartEvent CreateStartProcessStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("ec42dc50-18dd-4744-816b-b2811303d2e1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"StartProcess",
				Position = new Point(57, 128),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateVisaRejectedEndProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("de31436f-6b97-4b75-a6e9-12218945fb31"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaRejectedEndProcess",
				Position = new Point(911, 128),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateCancelPreviousVisasUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("535b4886-240c-4ff4-917d-84b951475499"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"CancelPreviousVisas",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(379, 114),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeCancelPreviousVisasParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddVisaUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"AddVisa",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(498, 114),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddVisaParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaEventBasedGateway CreateVisaEventGatewayEventBasedGateway() {
			ProcessSchemaEventBasedGateway gateway = new ProcessSchemaEventBasedGateway(this) {
				UId = new Guid("6d317fc3-3ec1-4167-8100-d452dfeebaa2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				Instantiate = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0ddbda75-9cac-4e42-b94c-5cf1edb45846"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaEventGateway",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(617, 114),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateVisaApprovedEventIntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("e6b71c76-86d0-43a1-8852-c815814f361e"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaApprovedEvent",
				NewEntityChangedColumns = false,
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(708, 44),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("58ebe36e-7384-4abd-b09c-407c6f508a4d");
			InitializeVisaApprovedEventParameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateVisaRejectedEventIntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("b0ff5122-dde6-487d-a7e0-e7ba43e507a9"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaRejectedEvent",
				NewEntityChangedColumns = false,
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(708, 128),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("58ebe36e-7384-4abd-b09c-407c6f508a4d");
			InitializeVisaRejectedEventParameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateVisaApprovedEndProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("e699229d-457b-40cc-94e1-d536113a8b65"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaApprovedEndProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(911, 44),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateVisaCanceledEndProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("f7ed8781-388b-41bb-913f-acec5ab5fa49"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaCanceledEndProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(911, 212),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateVisaCanceledEventIntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("7c046ee4-d44b-49a9-9e4f-4606b8554bec"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaCanceledEvent",
				NewEntityChangedColumns = false,
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(708, 212),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("c7d206aa-401c-4095-ba43-757c8f1914e9");
			InitializeVisaCanceledEventParameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateFindPositiveVisaUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"FindPositiveVisa",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(246, 226),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeFindPositiveVisaParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateAlreadyExistsVisaEndProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("10c69615-38e8-4a65-a9ab-7f0bfc22a18d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"AlreadyExistsVisaEndProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(267, 429),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateErrorEndProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("3e0a1d3e-7215-4cac-807f-02a021ddd2a3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"ErrorEndProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(148, 317),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateInputParametersGatewayExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("113c262b-8fe0-4413-8ba5-8315e16ea3f2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"InputParametersGateway",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(134, 114),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("77e77a39-537a-4a84-a052-aec8ab139324"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"FormulaTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(127, 226),
				ResultParameterMetaPath = @"d2fd2fb7-ec08-4092-840e-40479398aece",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,114,45,42,202,47,82,2,0,33,97,29,83,7,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask2FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("df06cffd-2788-47f3-aa36-e9630c969070"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"FormulaTask2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(792, 30),
				ResultParameterMetaPath = @"d2fd2fb7-ec08-4092-840e-40479398aece",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,114,44,40,40,202,47,75,77,81,2,0,254,184,194,168,10,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask3FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("0984b4ad-b023-4a3d-a496-1586cf9586d6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"FormulaTask3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(792, 198),
				ResultParameterMetaPath = @"d2fd2fb7-ec08-4092-840e-40479398aece",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,114,78,204,75,78,205,73,77,81,2,0,58,56,90,188,10,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask4FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("51f42a41-e4fc-4878-a6cd-34cd87dc1969"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"FormulaTask4",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(792, 114),
				ResultParameterMetaPath = @"d2fd2fb7-ec08-4092-840e-40479398aece",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,10,74,205,74,77,46,73,77,81,2,0,44,45,80,187,10,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask5FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("8dad276d-a200-40aa-92a0-bf4cb821d2fc"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"FormulaTask5",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(246, 338),
				ResultParameterMetaPath = @"d2fd2fb7-ec08-4092-840e-40479398aece",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,114,44,40,40,202,47,75,77,81,2,0,254,184,194,168,10,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("19e5e6ad-7695-4006-8c97-6f41ed28c7c9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("561bb91d-719b-4b9d-a8fe-65b13a8e9e3f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ccbd91c8-b356-4a0d-a8c1-5f4c3839a373"),
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"ExclusiveGateway1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(253, 114),
				SerializeToDB = false,
				Size = new Size(0, 0),
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
			return new ContractVisaBaseSubprocess(userConnection);
		}

		public override object Clone() {
			return new ContractVisaBaseSubprocessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"));
		}

		#endregion

	}

	#endregion

	#region Class: ContractVisaBaseSubprocess

	/// <exclude/>
	public class ContractVisaBaseSubprocess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessBPMCRM

		/// <exclude/>
		public class ProcessBPMCRM : ProcessLane
		{

			public ProcessBPMCRM(UserConnection userConnection, ContractVisaBaseSubprocess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: CancelPreviousVisasFlowElement

		/// <exclude/>
		public class CancelPreviousVisasFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public CancelPreviousVisasFlowElement(UserConnection userConnection, ContractVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "CancelPreviousVisas";
				IsLogging = true;
				SchemaElementUId = new Guid("535b4886-240c-4ff4-917d-84b951475499");
				CreatedInSchemaUId = process.InternalSchemaUId;
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

			private Guid _entitySchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,87,75,139,27,71,16,254,47,115,200,105,42,244,115,186,91,185,121,217,128,33,108,12,121,16,48,139,233,71,181,119,88,73,35,75,35,98,35,4,206,250,100,8,49,132,92,141,201,63,48,9,78,54,49,241,111,24,253,163,148,164,149,163,44,202,198,222,181,15,27,114,152,87,207,212,179,191,175,170,102,118,167,158,124,92,247,91,28,247,178,239,79,176,156,222,76,189,66,240,160,178,10,8,222,57,1,138,73,14,46,102,14,30,209,74,163,5,67,19,139,114,232,7,216,43,214,210,251,169,110,139,178,110,113,48,233,221,158,253,165,180,29,79,177,188,147,87,15,159,197,35,28,248,47,150,6,80,96,138,62,51,32,35,17,20,183,153,12,112,9,129,35,51,104,132,82,81,23,107,95,18,175,124,246,90,67,172,66,5,10,157,2,107,13,2,139,57,69,199,185,209,46,23,101,31,115,187,127,127,52,198,201,164,110,134,189,25,190,190,255,252,193,136,188,92,219,222,107,250,211,193,176,40,7,216,250,91,190,61,234,21,25,89,202,62,90,210,238,16,148,81,10,2,147,12,82,229,156,117,82,71,199,84,81,70,63,106,151,106,139,238,135,238,85,247,51,29,63,117,175,22,15,139,114,140,25,199,56,140,184,21,155,117,38,160,68,5,76,74,9,170,50,137,28,70,1,193,120,167,116,100,201,114,86,148,201,183,254,75,223,159,226,202,191,89,77,130,65,56,205,12,207,96,208,59,138,180,18,96,19,247,224,184,11,89,26,41,114,22,155,172,127,210,52,199,211,17,101,124,114,48,29,224,184,142,103,219,135,180,15,205,184,55,139,205,176,29,55,253,165,242,131,45,129,245,54,157,189,252,106,157,154,254,234,205,82,176,152,151,211,9,238,245,107,28,182,251,195,216,164,122,120,119,181,131,243,57,201,12,70,126,92,79,54,9,221,191,55,245,125,74,64,125,247,232,194,196,239,77,39,109,51,184,110,241,150,20,43,169,33,208,174,124,94,98,58,213,147,81,223,63,88,61,247,138,15,238,77,155,246,163,191,195,97,189,86,156,147,221,124,43,61,75,154,130,130,228,41,80,21,101,0,207,42,5,82,73,193,66,21,100,48,236,76,195,188,188,178,181,219,55,39,159,126,61,220,112,110,157,172,195,15,105,245,220,194,173,141,116,111,246,38,14,206,15,55,46,30,18,38,222,41,207,157,96,62,36,29,129,47,73,168,76,202,96,185,8,16,144,241,10,115,10,57,94,133,231,82,122,163,145,17,214,18,105,15,172,2,175,56,131,224,208,73,33,43,165,3,223,230,249,247,221,105,247,107,119,186,120,184,120,180,248,110,241,152,158,126,251,7,182,83,161,84,193,121,210,25,137,237,49,100,240,220,83,61,193,200,68,228,116,114,241,186,161,255,127,182,239,230,223,14,80,92,204,194,104,140,99,134,224,47,162,35,248,135,108,192,162,49,144,28,242,152,53,35,42,232,127,225,252,91,219,188,4,243,223,196,205,247,200,252,74,120,41,67,78,144,43,77,133,199,83,225,177,220,35,36,30,120,8,146,163,117,246,242,204,143,38,9,86,121,34,40,227,228,8,115,26,130,87,18,140,54,209,102,238,56,141,20,219,204,127,218,189,232,158,119,191,47,78,22,143,232,250,114,241,109,247,71,247,124,39,131,29,85,69,29,178,5,150,243,50,68,197,193,82,38,65,40,193,232,198,103,74,234,134,193,55,154,166,143,126,248,22,20,222,59,194,120,124,163,185,127,158,192,20,102,60,14,180,190,139,190,43,157,87,224,239,107,80,92,175,128,119,180,235,243,228,88,125,248,30,192,27,149,100,193,167,10,178,80,153,192,75,8,14,82,89,8,58,72,159,172,137,148,177,203,131,87,91,164,89,178,66,48,210,82,219,162,6,73,227,233,146,163,140,20,19,51,173,87,105,27,188,63,210,100,240,205,226,132,206,79,8,182,167,221,139,221,77,171,170,8,250,218,71,208,68,14,80,25,45,56,237,25,88,231,157,69,105,178,54,249,250,55,173,131,166,125,55,184,255,15,12,170,207,104,108,124,73,199,47,212,74,78,168,194,157,213,181,197,147,139,155,9,26,71,127,71,65,130,140,52,24,42,137,6,188,166,31,37,26,204,60,23,26,43,46,197,86,95,56,156,255,9,173,221,249,92,80,14,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,82,221,111,130,48,16,255,87,150,198,71,107,40,22,16,30,55,182,196,68,23,51,157,47,99,15,103,185,42,9,31,166,192,50,103,248,223,87,42,70,76,220,195,236,195,53,237,221,239,163,215,59,146,65,117,216,35,9,200,227,98,190,44,100,53,122,42,20,142,22,170,16,88,150,163,89,33,32,77,126,96,147,226,2,20,100,88,161,90,67,90,99,57,75,202,106,248,208,7,145,33,25,124,153,28,9,62,142,100,90,97,246,62,141,53,179,96,182,195,98,135,81,95,122,54,229,40,128,250,232,74,42,199,62,115,185,197,125,215,178,52,88,20,105,157,229,115,172,96,1,213,142,4,71,98,216,90,2,47,182,45,23,128,114,139,9,29,124,135,110,128,143,169,231,120,98,34,153,207,56,250,164,25,146,82,236,48,3,35,122,1,163,141,177,0,105,81,190,65,13,102,19,73,125,193,198,116,195,208,242,208,179,57,23,78,11,238,234,47,192,149,210,155,78,196,73,185,79,225,176,254,43,191,191,106,76,191,226,24,157,186,27,145,32,186,221,223,110,95,26,227,215,29,190,110,110,68,134,17,89,22,181,18,45,27,107,15,231,199,26,118,171,91,244,70,56,175,19,135,129,205,33,135,45,170,87,173,103,224,38,21,66,5,70,122,165,61,255,155,248,13,37,42,204,5,222,105,108,221,42,95,204,156,231,64,223,228,117,154,26,129,210,188,191,29,172,206,120,151,9,123,63,212,99,40,226,68,38,24,79,243,59,29,133,40,13,229,75,161,158,191,245,184,39,249,182,251,175,158,244,165,38,20,89,119,223,144,166,249,108,126,1,141,190,212,196,91,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b4ef173acd864fed8781695413ee6e53",
							"BaseElements.CancelPreviousVisas.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("29c7b5a2-1b24-4486-9276-6f30e0b427b5");
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

		#region Class: AddVisaFlowElement

		/// <exclude/>
		public class AddVisaFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddVisaFlowElement(UserConnection userConnection, ContractVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddVisa";
				IsLogging = true;
				SchemaElementUId = new Guid("8d004d94-5e54-4b1e-80a4-f03f34f6f0bd");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Objective = () => new LocalizableString((process.VisaObjective));
				_recordDefValues_VisaOwner = () => (Guid)((process.VisaOwner));
				_recordDefValues_Contract = () => (Guid)((process.Contract));
				_recordDefValues_IsAllowedToDelegate = () => (bool)((process.IsAllowedToDelegate));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Objective", () => _recordDefValues_Objective.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_VisaOwner", () => _recordDefValues_VisaOwner.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Contract", () => _recordDefValues_Contract.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_IsAllowedToDelegate", () => _recordDefValues_IsAllowedToDelegate.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<string> _recordDefValues_Objective;
			internal Func<Guid> _recordDefValues_VisaOwner;
			internal Func<Guid> _recordDefValues_Contract;
			internal Func<bool> _recordDefValues_IsAllowedToDelegate;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,79,111,91,69,16,192,191,74,244,218,163,39,218,127,111,255,248,8,1,41,82,3,17,129,94,226,28,102,119,103,91,75,254,19,217,14,80,34,75,145,122,1,129,56,32,62,0,39,206,85,75,68,16,34,159,225,249,27,49,126,118,136,67,171,40,234,41,106,251,164,247,236,183,187,51,179,222,153,223,204,248,180,122,56,123,118,76,85,183,250,104,127,239,96,92,102,219,31,143,39,180,189,63,25,39,154,78,183,31,141,19,14,250,223,97,28,208,62,78,112,72,51,154,60,198,193,9,77,31,245,167,179,206,214,166,80,213,169,30,126,221,206,85,221,195,211,106,119,70,195,175,118,51,107,150,136,193,231,154,192,162,209,96,98,40,128,2,35,88,173,20,154,58,150,34,2,11,167,241,224,100,56,218,163,25,238,227,236,105,213,61,173,90,109,172,32,41,175,146,87,6,28,162,4,99,162,129,232,139,128,156,80,20,210,217,71,19,171,121,167,154,166,167,52,196,214,232,181,48,41,226,117,188,218,68,74,96,164,47,16,146,212,16,37,9,71,78,25,147,234,165,240,122,253,181,224,225,131,195,221,233,231,223,140,104,114,208,234,237,22,28,76,233,104,155,71,255,55,240,223,209,116,79,107,145,67,173,10,130,33,17,217,154,201,128,50,91,222,180,17,214,23,66,131,114,126,244,224,104,105,49,247,167,199,3,124,246,248,117,195,205,239,205,121,243,247,226,167,173,230,101,115,209,252,185,248,113,37,112,124,195,5,155,34,167,189,149,31,123,85,183,247,102,79,174,63,87,59,191,233,203,155,110,236,85,157,94,117,48,62,153,164,165,54,189,124,185,58,214,86,187,88,95,240,134,199,213,181,210,209,138,237,225,8,159,208,228,51,182,215,138,183,83,59,56,195,214,244,151,188,231,43,197,57,71,141,146,8,216,45,30,76,182,10,162,195,0,89,144,149,62,10,81,98,110,165,191,160,66,19,26,37,122,203,141,181,150,175,55,115,21,113,60,50,58,25,12,90,3,211,246,247,47,67,120,189,241,245,204,206,134,203,54,52,140,115,191,244,41,239,142,222,114,71,59,84,90,149,159,142,39,159,124,203,96,245,71,79,214,254,218,48,125,189,102,39,13,215,227,243,106,62,239,108,178,150,165,148,24,29,1,58,105,56,254,2,129,79,164,193,22,111,28,74,107,36,250,91,89,43,90,163,171,73,128,163,204,10,162,176,128,70,10,136,129,130,86,218,50,175,242,158,176,150,156,11,194,177,53,149,2,91,139,197,129,39,231,32,7,146,169,212,130,45,215,119,96,237,151,37,98,205,197,226,108,241,124,241,243,226,7,126,251,235,125,192,45,170,80,11,39,11,59,154,33,51,196,184,249,44,17,130,12,177,104,167,85,41,234,54,220,188,41,156,137,3,103,186,152,56,171,167,200,89,157,131,11,18,37,161,146,228,71,72,239,60,110,162,102,160,180,149,92,138,10,135,96,226,196,31,98,114,144,68,206,89,249,26,37,87,166,91,113,35,145,11,38,62,54,203,168,26,103,184,180,9,205,165,205,134,224,131,174,83,16,230,158,224,166,81,228,154,227,2,50,114,172,152,164,35,151,113,107,64,27,173,68,180,81,71,39,238,128,219,175,205,101,243,138,239,151,205,229,226,236,3,104,119,0,45,184,72,154,12,8,173,25,52,235,50,120,79,171,226,104,106,142,52,47,223,253,186,38,29,103,43,84,26,82,212,220,2,58,73,16,83,176,224,10,199,121,42,134,195,47,221,10,154,203,166,214,204,9,24,207,59,53,46,48,38,222,120,176,206,201,140,38,40,225,236,125,1,141,77,81,98,95,147,229,78,215,148,92,32,26,37,160,46,232,68,241,28,50,73,221,1,180,223,154,23,220,58,158,53,231,139,239,185,155,252,167,185,220,106,254,88,182,149,124,191,90,150,187,150,193,23,60,113,209,156,191,15,28,6,78,82,252,103,195,131,40,203,92,45,141,4,207,29,4,40,62,91,254,130,133,155,137,15,253,37,189,198,225,209,252,95,2,64,52,24,37,14,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b4ef173acd864fed8781695413ee6e53",
							"BaseElements.AddVisa.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("29c7b5a2-1b24-4486-9276-6f30e0b427b5");
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

		#region Class: VisaApprovedEventFlowElement

		/// <exclude/>
		public class VisaApprovedEventFlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public VisaApprovedEventFlowElement(UserConnection userConnection, ContractVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "VisaApprovedEvent";
				IsLogging = false;
				SchemaElementUId = new Guid("e6b71c76-86d0-43a1-8852-c815814f361e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""58ebe36e-7384-4abd-b09c-407c6f508a4d""]}";
				EntityFilters = @"{_isFilter:false,uId:""c0285505-677e-4cea-84d2-37df6c645ebf"",name:""FilterEdit"",items:[{_isFilter:true,_filterSchemaUId:""e2edcaf0-4bec-418f-9c13-b1e07e7244c5"",uId:""6015b714-a7d3-47f6-bb98-63fbe17da2f2"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""58ebe36e-7384-4abd-b09c-407c6f508a4d"",caption:""Состояние"",referenceSchemaUId:""66c8f5ac-57d2-4fe8-95a0-89a98e37f57f"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true},parameterValues:[{displayValue:""&quot;Положительная&quot;"",parameterValue:""&quot;e79facb3-3c32-43e7-a59e-12ba125e6132&quot;""}]}},{_isFilter:true,_filterSchemaUId:""e2edcaf0-4bec-418f-9c13-b1e07e7244c5"",uId:""dd728109-65d2-4661-b30a-c56a7b3cf587"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""c7d206aa-401c-4095-ba43-757c8f1914e9"",caption:""Неактуальна"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false},parameterValues:[{parameterValue:""false""}]}}]}";
				_recordId = () => (Guid)((process.AddVisa.RecordId));
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

		#region Class: VisaRejectedEventFlowElement

		/// <exclude/>
		public class VisaRejectedEventFlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public VisaRejectedEventFlowElement(UserConnection userConnection, ContractVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "VisaRejectedEvent";
				IsLogging = false;
				SchemaElementUId = new Guid("b0ff5122-dde6-487d-a7e0-e7ba43e507a9");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""58ebe36e-7384-4abd-b09c-407c6f508a4d""]}";
				EntityFilters = @"{_isFilter:false,uId:""a4e00283-aeb3-447c-8f98-d96408285b25"",name:""FilterEdit"",items:[{_isFilter:true,_filterSchemaUId:""e2edcaf0-4bec-418f-9c13-b1e07e7244c5"",uId:""fceb530d-c1fd-474b-9f1b-bfbf3c1c5e12"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""58ebe36e-7384-4abd-b09c-407c6f508a4d"",caption:""Состояние"",referenceSchemaUId:""66c8f5ac-57d2-4fe8-95a0-89a98e37f57f"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true},parameterValues:[{displayValue:""&quot;Отрицательная&quot;"",parameterValue:""&quot;a93ab0b9-ca36-4b95-9b23-e01aa169c338&quot;""}]}},{_isFilter:true,_filterSchemaUId:""e2edcaf0-4bec-418f-9c13-b1e07e7244c5"",uId:""09e9eb10-1458-4a32-938e-20e56cde2704"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""c7d206aa-401c-4095-ba43-757c8f1914e9"",caption:""Неактуальна"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false},parameterValues:[{parameterValue:""false""}]}}]}";
				_recordId = () => (Guid)((process.AddVisa.RecordId));
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

		#region Class: VisaCanceledEventFlowElement

		/// <exclude/>
		public class VisaCanceledEventFlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public VisaCanceledEventFlowElement(UserConnection userConnection, ContractVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "VisaCanceledEvent";
				IsLogging = false;
				SchemaElementUId = new Guid("7c046ee4-d44b-49a9-9e4f-4606b8554bec");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""c7d206aa-401c-4095-ba43-757c8f1914e9""]}";
				EntityFilters = @"{_isFilter:false,uId:""4491cfc0-beff-4e52-a226-7603ab3e4f16"",name:""FilterEdit"",items:[{_isFilter:true,_filterSchemaUId:""e2edcaf0-4bec-418f-9c13-b1e07e7244c5"",uId:""01d4b4fd-a90b-4e44-b49a-37749e2d75b4"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""c7d206aa-401c-4095-ba43-757c8f1914e9"",caption:""Неактуальна"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""90b65bf8-0ffc-4141-8779-2420877af907"",name:""Boolean"",isNumeric:false,editor:{controlTypeName:""CheckBox"",controlXType:""checkbox""},useClientEncoding:false},parameterValues:[{parameterValue:""true""}]}}]}";
				_recordId = () => (Guid)((process.AddVisa.RecordId));
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

		#region Class: FindPositiveVisaFlowElement

		/// <exclude/>
		public class FindPositiveVisaFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public FindPositiveVisaFlowElement(UserConnection userConnection, ContractVisaBaseSubprocess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "FindPositiveVisa";
				IsLogging = true;
				SchemaElementUId = new Guid("80386e6f-06c0-42ef-980b-c608cd4c8d26");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,221,138,28,69,20,199,223,165,47,188,234,35,245,217,85,53,222,101,89,33,32,49,224,7,66,88,66,125,156,202,54,59,51,61,153,233,193,132,97,33,110,174,2,98,64,188,21,241,13,130,18,93,13,230,25,122,222,200,211,51,59,113,92,198,53,217,53,23,171,94,76,79,119,117,87,213,57,167,254,191,58,167,22,119,235,217,251,245,176,197,233,32,251,225,12,203,249,205,52,40,42,159,171,42,138,10,12,250,8,138,51,11,182,18,22,28,99,86,85,137,73,161,76,81,142,253,8,7,197,186,247,126,170,219,162,172,91,28,205,6,119,22,127,12,218,78,231,88,222,205,171,135,143,226,33,142,252,39,253,4,40,48,69,159,25,168,128,253,4,54,131,139,92,66,224,200,12,26,161,84,212,197,218,22,147,67,148,34,120,112,62,100,80,137,115,8,198,75,200,153,51,93,49,142,129,243,162,28,98,110,247,31,76,166,56,155,213,205,120,176,192,87,247,31,63,156,144,149,235,185,247,154,225,124,52,46,202,17,182,254,182,111,15,7,69,70,150,178,143,22,98,229,16,148,81,10,2,147,12,82,229,156,117,82,71,199,84,81,70,63,105,251,97,139,238,155,238,101,247,35,253,126,232,94,46,31,21,229,20,51,78,113,28,113,203,55,235,76,64,137,10,152,148,18,84,101,18,88,139,162,183,218,41,29,89,178,156,21,101,242,173,255,212,15,231,184,178,111,81,83,199,32,156,102,134,231,62,234,14,20,86,2,108,226,228,56,119,33,75,35,69,206,98,19,245,15,154,230,104,62,161,136,207,110,205,71,56,173,227,217,242,33,173,67,51,29,44,98,51,110,167,205,176,31,252,214,86,135,245,50,157,189,252,108,29,154,225,234,77,223,177,56,46,231,51,220,27,214,56,110,247,199,177,73,245,248,222,106,5,143,143,169,207,104,226,167,245,108,19,208,253,251,115,63,164,0,212,247,14,47,12,252,222,124,214,54,163,235,230,111,73,190,210,48,36,218,149,205,189,166,83,61,155,12,253,195,213,243,160,120,231,254,188,105,223,251,179,28,214,109,197,185,190,155,111,165,103,73,147,83,144,60,57,170,162,12,224,89,165,64,42,41,88,168,130,12,134,157,141,112,92,94,121,182,59,55,103,31,126,62,222,48,183,14,214,193,187,212,122,174,225,246,166,247,96,241,58,6,30,31,108,76,60,32,77,252,163,156,87,73,100,158,88,5,42,27,194,198,50,14,222,99,2,166,53,102,30,21,38,25,175,192,185,148,222,104,100,164,181,164,200,26,154,199,211,190,6,193,161,147,66,86,74,7,190,205,249,215,221,105,247,115,119,186,124,180,124,188,252,106,249,132,158,126,249,11,218,85,86,42,56,79,99,70,50,59,210,30,229,185,167,253,4,35,19,145,211,197,197,235,166,254,255,105,223,205,223,14,81,92,76,97,52,198,49,67,242,23,209,145,252,67,54,96,209,24,72,14,121,204,154,17,10,250,111,152,127,227,57,47,65,254,235,152,249,22,201,103,22,81,49,33,128,11,71,108,10,212,224,9,31,240,193,73,76,204,48,111,228,229,201,143,38,9,86,121,2,148,113,50,132,57,13,193,43,9,70,155,104,51,119,92,161,219,38,255,219,238,121,247,172,251,117,121,178,124,76,255,47,150,95,118,191,117,207,118,18,236,104,87,212,33,91,96,57,247,46,42,14,150,34,9,66,9,70,55,62,83,80,55,4,223,104,154,33,250,241,27,32,188,119,136,241,232,70,243,224,60,192,228,102,60,10,212,190,11,223,213,152,87,224,247,149,40,174,151,195,59,210,245,121,56,86,31,190,29,241,218,32,251,100,37,35,167,109,156,242,103,72,40,1,101,180,193,106,110,83,200,151,23,175,182,72,181,100,133,96,164,37,52,124,72,84,158,246,140,50,19,43,34,211,122,149,182,197,251,61,85,6,95,44,79,232,250,148,100,123,218,61,223,157,180,168,184,183,89,83,105,175,9,14,74,184,72,165,189,246,12,172,243,206,162,52,89,155,252,223,73,90,23,139,254,95,80,165,126,71,53,227,11,250,253,68,121,228,132,182,183,179,77,109,249,244,226,76,130,198,209,209,40,72,144,116,0,3,37,209,128,215,116,74,226,116,26,227,66,99,197,165,216,74,10,7,199,191,3,36,131,109,60,77,14,0,0 })));
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
								new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5"));
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

		public ContractVisaBaseSubprocess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContractVisaBaseSubprocess";
			SchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53");
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
				return new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ContractVisaBaseSubprocess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ContractVisaBaseSubprocess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid Contract {
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

		private ProcessBPMCRM _bPMCRM;
		public ProcessBPMCRM BPMCRM {
			get {
				return _bPMCRM ?? ((_bPMCRM) = new ProcessBPMCRM(UserConnection, this));
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
					SchemaElementUId = new Guid("ec42dc50-18dd-4744-816b-b2811303d2e1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("de31436f-6b97-4b75-a6e9-12218945fb31"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private CancelPreviousVisasFlowElement _cancelPreviousVisas;
		public CancelPreviousVisasFlowElement CancelPreviousVisas {
			get {
				return _cancelPreviousVisas ?? (_cancelPreviousVisas = new CancelPreviousVisasFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddVisaFlowElement _addVisa;
		public AddVisaFlowElement AddVisa {
			get {
				return _addVisa ?? (_addVisa = new AddVisaFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("6d317fc3-3ec1-4167-8100-d452dfeebaa2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Events = new Collection<string> { "VisaRejectedEvent", "VisaApprovedEvent", "VisaCanceledEvent", },
				});
			}
		}

		private VisaApprovedEventFlowElement _visaApprovedEvent;
		public VisaApprovedEventFlowElement VisaApprovedEvent {
			get {
				return _visaApprovedEvent ?? ((_visaApprovedEvent) = new VisaApprovedEventFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private VisaRejectedEventFlowElement _visaRejectedEvent;
		public VisaRejectedEventFlowElement VisaRejectedEvent {
			get {
				return _visaRejectedEvent ?? ((_visaRejectedEvent) = new VisaRejectedEventFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("e699229d-457b-40cc-94e1-d536113a8b65"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("f7ed8781-388b-41bb-913f-acec5ab5fa49"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private VisaCanceledEventFlowElement _visaCanceledEvent;
		public VisaCanceledEventFlowElement VisaCanceledEvent {
			get {
				return _visaCanceledEvent ?? ((_visaCanceledEvent) = new VisaCanceledEventFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private FindPositiveVisaFlowElement _findPositiveVisa;
		public FindPositiveVisaFlowElement FindPositiveVisa {
			get {
				return _findPositiveVisa ?? (_findPositiveVisa = new FindPositiveVisaFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("10c69615-38e8-4a65-a9ab-7f0bfc22a18d"),
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
					SchemaElementUId = new Guid("3e0a1d3e-7215-4cac-807f-02a021ddd2a3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessExclusiveGateway _inputParametersGateway;
		public ProcessExclusiveGateway InputParametersGateway {
			get {
				return _inputParametersGateway ?? (_inputParametersGateway = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "InputParametersGateway",
					SchemaElementUId = new Guid("113c262b-8fe0-4413-8ba5-8315e16ea3f2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.InputParametersGateway.Question"),
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
					SchemaElementUId = new Guid("77e77a39-537a-4a84-a052-aec8ab139324"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask1Execute,
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
					SchemaElementUId = new Guid("df06cffd-2788-47f3-aa36-e9630c969070"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask2Execute,
				});
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
					SchemaElementUId = new Guid("0984b4ad-b023-4a3d-a496-1586cf9586d6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask3Execute,
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
					SchemaElementUId = new Guid("51f42a41-e4fc-4878-a6cd-34cd87dc1969"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask4Execute,
				});
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
					SchemaElementUId = new Guid("8dad276d-a200-40aa-92a0-bf4cb821d2fc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask5Execute,
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
					SchemaElementUId = new Guid("19e5e6ad-7695-4006-8c97-6f41ed28c7c9"),
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

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("7623fa5a-d0ea-4b67-a2d2-e48bf8f59eaf"),
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
					SchemaElementUId = new Guid("2baf54f3-f62d-4407-a7f7-8673978956af"),
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
					SchemaElementUId = new Guid("4eed58cf-4e0d-47f2-9ad9-b5341d3c41e3"),
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
			FlowElements[VisaRejectedEndProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaRejectedEndProcess };
			FlowElements[CancelPreviousVisas.SchemaElementUId] = new Collection<ProcessFlowElement> { CancelPreviousVisas };
			FlowElements[AddVisa.SchemaElementUId] = new Collection<ProcessFlowElement> { AddVisa };
			FlowElements[VisaEventGateway.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaEventGateway };
			FlowElements[VisaApprovedEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaApprovedEvent };
			FlowElements[VisaRejectedEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaRejectedEvent };
			FlowElements[VisaApprovedEndProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaApprovedEndProcess };
			FlowElements[VisaCanceledEndProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaCanceledEndProcess };
			FlowElements[VisaCanceledEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { VisaCanceledEvent };
			FlowElements[FindPositiveVisa.SchemaElementUId] = new Collection<ProcessFlowElement> { FindPositiveVisa };
			FlowElements[AlreadyExistsVisaEndProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { AlreadyExistsVisaEndProcess };
			FlowElements[ErrorEndProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ErrorEndProcess };
			FlowElements[InputParametersGateway.SchemaElementUId] = new Collection<ProcessFlowElement> { InputParametersGateway };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[FormulaTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask2 };
			FlowElements[FormulaTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask3 };
			FlowElements[FormulaTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask4 };
			FlowElements[FormulaTask5.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask5 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InputParametersGateway", e.Context.SenderName));
						break;
					case "VisaRejectedEndProcess":
						CompleteProcess();
						break;
					case "CancelPreviousVisas":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddVisa", e.Context.SenderName));
						break;
					case "AddVisa":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaEventGateway", e.Context.SenderName));
						break;
					case "VisaEventGateway":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaRejectedEvent", e.Context.SenderName));
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaApprovedEvent", e.Context.SenderName));
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaCanceledEvent", e.Context.SenderName));
						break;
					case "VisaApprovedEvent":
						VisaEventGateway.CancelNonexecutedEvents("VisaApprovedEvent");
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask2", e.Context.SenderName));
						break;
					case "VisaRejectedEvent":
						VisaEventGateway.CancelNonexecutedEvents("VisaRejectedEvent");
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask4", e.Context.SenderName));
						break;
					case "VisaApprovedEndProcess":
						CompleteProcess();
						break;
					case "VisaCanceledEndProcess":
						CompleteProcess();
						break;
					case "VisaCanceledEvent":
						VisaEventGateway.CancelNonexecutedEvents("VisaCanceledEvent");
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask3", e.Context.SenderName));
						break;
					case "FindPositiveVisa":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask5", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CancelPreviousVisas", e.Context.SenderName));
						break;
					case "AlreadyExistsVisaEndProcess":
						CompleteProcess();
						break;
					case "ErrorEndProcess":
						CompleteProcess();
						break;
					case "InputParametersGateway":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ErrorEndProcess", e.Context.SenderName));
						break;
					case "FormulaTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaApprovedEndProcess", e.Context.SenderName));
						break;
					case "FormulaTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaCanceledEndProcess", e.Context.SenderName));
						break;
					case "FormulaTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("VisaRejectedEndProcess", e.Context.SenderName));
						break;
					case "FormulaTask5":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AlreadyExistsVisaEndProcess", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FindPositiveVisa", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CancelPreviousVisas", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((FindPositiveVisa.ResultCount)>0);
			Log.InfoFormat(ConditionalExpressionLogMessage, "FindPositiveVisa", "ConditionalFlow1", "(FindPositiveVisa.ResultCount)>0", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((VisaOwner) == null || (Contract) == null);
			Log.InfoFormat(ConditionalExpressionLogMessage, "InputParametersGateway", "ConditionalFlow2", "(VisaOwner) == null || (Contract) == null", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean((IsPreviousVisaCounts));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow3", "(IsPreviousVisaCounts)", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("Contract")) {
				writer.WriteValue("Contract", Contract, Guid.Empty);
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
			MetaPathParameterValues.Add("3a0d5732-da62-4c3b-a064-34320b6b3b70", () => Contract);
			MetaPathParameterValues.Add("c77907f0-2c9c-4bf7-8e77-d9e1cf50c135", () => VisaOwner);
			MetaPathParameterValues.Add("50d952fa-4e0b-414d-a1d6-444068fea4a1", () => VisaObjective);
			MetaPathParameterValues.Add("d2fd2fb7-ec08-4092-840e-40479398aece", () => VisaResult);
			MetaPathParameterValues.Add("3cafec33-e6b4-4fdf-b420-5fa70f8373c2", () => IsAllowedToDelegate);
			MetaPathParameterValues.Add("2b0415c8-fe33-430e-b6b0-0d6cee817372", () => IsPreviousVisaCounts);
			MetaPathParameterValues.Add("6c9b198f-bc19-4b69-ab86-d1dd9334339a", () => CancelPreviousVisas.EntitySchemaUId);
			MetaPathParameterValues.Add("49cbb5c4-bd70-43aa-8f31-4879e73d2376", () => CancelPreviousVisas.IsMatchConditions);
			MetaPathParameterValues.Add("d6d65720-6f5e-4f79-b9bc-19d68d9d465f", () => CancelPreviousVisas.DataSourceFilters);
			MetaPathParameterValues.Add("11edda32-f2fb-41b4-8837-0586bfabade5", () => CancelPreviousVisas.RecordColumnValues);
			MetaPathParameterValues.Add("5c9cfea5-678f-44ea-a6b1-85de2a653ac2", () => CancelPreviousVisas.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("69a4680b-dced-4f91-9736-b89098e9b12c", () => AddVisa.EntitySchemaId);
			MetaPathParameterValues.Add("ce9ba715-9c2b-4b46-b3cd-a342eea5cf22", () => AddVisa.DataSourceFilters);
			MetaPathParameterValues.Add("fbf6a978-d0cf-473f-8ce4-5a20e548bb14", () => AddVisa.RecordAddMode);
			MetaPathParameterValues.Add("3691ae8b-153d-41dc-8223-2f176da23196", () => AddVisa.FilterEntitySchemaId);
			MetaPathParameterValues.Add("0a9c1fff-05ca-424d-919c-e1edf51210b3", () => AddVisa.RecordDefValues);
			MetaPathParameterValues.Add("58cb0143-4eb3-4db4-b3d9-85dbab73eef1", () => AddVisa.RecordId);
			MetaPathParameterValues.Add("40034502-d147-42a5-ad98-6ebaa49dd191", () => AddVisa.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("c031b7d4-47c5-4757-b402-f10b423e1766", () => VisaApprovedEvent.RecordId);
			MetaPathParameterValues.Add("a3b7e6ec-ad76-4a63-9b48-ee16803ca206", () => VisaRejectedEvent.RecordId);
			MetaPathParameterValues.Add("9cba3ba9-8b2e-4d4b-a3a5-ba1a989ed52a", () => VisaCanceledEvent.RecordId);
			MetaPathParameterValues.Add("2cb83f28-00c3-4498-b39b-2f4679606074", () => FindPositiveVisa.DataSourceFilters);
			MetaPathParameterValues.Add("9a26576c-c7c3-446c-84c6-01bfb60e881c", () => FindPositiveVisa.ResultType);
			MetaPathParameterValues.Add("6c8ba82f-8a97-45f4-84a5-d3fa4a515b71", () => FindPositiveVisa.ReadSomeTopRecords);
			MetaPathParameterValues.Add("71734acf-2f73-40f2-8700-2c88d70553ce", () => FindPositiveVisa.NumberOfRecords);
			MetaPathParameterValues.Add("e31e30a5-7698-42ba-bee5-b12248b7f70c", () => FindPositiveVisa.FunctionType);
			MetaPathParameterValues.Add("deaa2aa9-71f7-423c-950f-88351e8c8775", () => FindPositiveVisa.AggregationColumnName);
			MetaPathParameterValues.Add("bbaada9f-c766-4ba8-b5d1-b74d05465f22", () => FindPositiveVisa.OrderInfo);
			MetaPathParameterValues.Add("468b242d-1dd5-4213-86e5-2cdc5fba51e2", () => FindPositiveVisa.ResultEntity);
			MetaPathParameterValues.Add("d6348dc3-4710-49a2-8cd5-eafb895e4fa5", () => FindPositiveVisa.ResultCount);
			MetaPathParameterValues.Add("0ed51c81-29b7-44dc-8000-5478283dbe98", () => FindPositiveVisa.ResultIntegerFunction);
			MetaPathParameterValues.Add("38909994-7218-4923-acc1-cb94b885239e", () => FindPositiveVisa.ResultFloatFunction);
			MetaPathParameterValues.Add("19a6723d-07af-4e13-b781-faa4906b1b21", () => FindPositiveVisa.ResultDateTimeFunction);
			MetaPathParameterValues.Add("195b1cc1-73e4-4d81-b1bc-fba63109558b", () => FindPositiveVisa.ResultRowsCount);
			MetaPathParameterValues.Add("2cf29bbb-a6c1-49f3-b333-58f19e6a7f0f", () => FindPositiveVisa.CanReadUncommitedData);
			MetaPathParameterValues.Add("b9d95ef0-203a-45b1-b583-ce4f734719f6", () => FindPositiveVisa.ResultEntityCollection);
			MetaPathParameterValues.Add("eac06a30-8133-464e-b39f-0f9124e46853", () => FindPositiveVisa.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("6fabb303-28c8-4090-9fa2-d74dd5df6abd", () => FindPositiveVisa.IgnoreDisplayValues);
			MetaPathParameterValues.Add("ac579543-3210-4dc5-aca8-f246c51e7882", () => FindPositiveVisa.ResultCompositeObjectList);
			MetaPathParameterValues.Add("461e4f0f-5fe4-4832-89b6-3ef93aa9af0c", () => FindPositiveVisa.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "Contract":
					if (!hasValueToRead) break;
					Contract = reader.GetValue<System.Guid>();
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
			var localVisaResult = "Canceled";
			VisaResult = (System.String)localVisaResult;
			return true;
		}

		public virtual bool FormulaTask4Execute(ProcessExecutingContext context) {
			var localVisaResult = "Rejected";
			VisaResult = (System.String)localVisaResult;
			return true;
		}

		public virtual bool FormulaTask5Execute(ProcessExecutingContext context) {
			var localVisaResult = "Approved";
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
			var cloneItem = (ContractVisaBaseSubprocess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

