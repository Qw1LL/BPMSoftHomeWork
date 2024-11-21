namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration.OrderInvoice;
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

	#region Class: CreateInvoiceFromOrderSchema

	/// <exclude/>
	public class CreateInvoiceFromOrderSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CreateInvoiceFromOrderSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CreateInvoiceFromOrderSchema(CreateInvoiceFromOrderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CreateInvoiceFromOrder";
			UId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835");
			CreatedInPackageId = new Guid("5aa8040b-8cb0-4885-ac08-be852fb6adeb");
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
			Tag = @"CreateInvoiceFromOrder";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,81,219,138,131,48,16,125,222,128,255,16,124,82,16,127,96,187,133,226,222,250,84,88,216,15,176,113,232,166,216,137,140,73,139,20,255,125,199,36,138,101,89,124,200,153,156,51,147,115,198,68,116,238,216,106,37,175,154,172,171,91,121,53,186,145,21,65,109,97,143,92,40,200,114,121,79,196,211,129,26,160,120,245,9,109,7,36,127,194,241,34,223,107,101,13,105,232,203,170,173,251,62,148,67,249,1,118,243,183,109,155,33,220,214,45,6,123,75,110,42,119,116,114,23,64,155,165,174,7,98,2,65,89,109,48,45,228,247,195,69,158,63,39,34,184,108,226,240,125,195,70,130,163,50,48,111,104,181,29,178,212,91,224,17,105,84,50,172,28,17,191,227,153,66,78,126,94,181,31,92,211,176,97,55,26,79,133,12,231,214,167,191,167,161,69,13,211,160,5,143,197,3,247,197,175,174,121,95,207,26,131,150,51,123,58,194,200,236,148,50,14,61,51,195,200,28,110,24,156,7,48,235,47,139,60,160,89,221,117,134,127,34,114,104,223,179,42,199,68,140,255,230,52,199,51,111,149,115,242,183,44,107,189,33,57,202,113,90,56,79,73,196,47,227,248,19,10,50,2,0,0 };
			RealUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835");
			Version = 0;
			PackageUId = new Guid("25b0287a-c3a8-4066-b6ef-e5dad7c3be5a");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCurrentOrderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("08117217-b6a2-4caa-87cb-57b42ebbdf81"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"CurrentOrder",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreatedInvoiceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9b6df9ca-b4dc-4748-a446-878f58f9abe8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"CreatedInvoiceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCurrentOrderParameter());
			Parameters.Add(CreateCreatedInvoiceIdParameter());
		}

		protected virtual void InitializeOpenEditPageUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var objectSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("d85118e6-2c1e-4d34-afa5-de5b61c76366"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				Value = @"bfb313dd-bb55-4e1b-8e42-3d346e0da7c5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(objectSchemaIdParameter);
			var pageSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("91937424-2f71-4f1f-a3b2-d440bd5541d2"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				Value = @"b8a98131-367e-4bc0-88b7-06bea6a143de",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(pageSchemaIdParameter);
			var editModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2dac85ca-0040-4966-a412-c2232b004d2b"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(editModeParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c1fbab13-0fcc-4a08-8a27-9c61b940678a"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				UId = new Guid("69857298-5af6-4e7c-8304-9fec7c1d334f"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{9b6df9ca-b4dc-4748-a446-878f58f9abe8}]#]",
				MetaPath = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{9b6df9ca-b4dc-4748-a446-878f58f9abe8}]#]",
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var executedModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("03005092-ebd2-40a5-a4ba-1feda715e4ab"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("0e17b357-37db-48e3-b5b8-e62e0687bddf"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e7f46f88-3a82-4148-a2e2-d7bd427e03a0"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var generateDecisionsFromColumnParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2ae3d7cd-e356-43c7-bc44-a3695025a7f9"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(generateDecisionsFromColumnParameter);
			var decisionalColumnMetaPathParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9bdca34c-1f63-47aa-a579-fdd93f26eac3"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(decisionalColumnMetaPathParameter);
			var resultParameterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4a705262-6f06-417e-a8c7-f5a2d1f63fe5"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("26151eb5-20dc-466e-972e-c72498300aa7"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("ea935a75-0c11-482c-9e99-d04fc6977707"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Заполните необходимые поля и сохраните счет",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("a3c2a6f9-b087-4a04-b687-52b26aa4e66b"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("75d81580-4664-441e-9b0d-0d954ffefc72"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("56d9018d-ca95-4d5a-b482-07336f8786cb"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("171f4ae2-f53f-4545-8cec-973f64a4576c"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("83f5e8fe-aef9-4bc8-b439-e3d3f6f61866"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("22b00966-521c-4147-b0dd-880c07bb49b4"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("1076ae54-e8ed-4d6f-8d4d-2e25408bb776"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("390e7e01-63f1-47ee-9272-137e604112f1"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("3100ca53-bbf6-4ce1-81f5-3a74d220ec16"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("1864aa91-6db8-4edf-9528-1e271677b340"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("d4513854-0edf-4b46-864c-3ec250465806"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("d1a00ae7-ea8e-4faf-9be8-bbb151893c96"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("81643ee9-7afe-4461-9cf6-9a97b4c18843"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("7d314b93-7262-4ca5-9f0b-175bcee0be87"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("0dcd1985-fcf0-477b-85e3-cc32230b0c60"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("9d7f3abd-fc1c-4c09-8a0d-793ad6b9a9d1"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("28c6ffdb-91ea-49c5-a622-85c4248e047b"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("ca2ee227-e2c2-4921-9f1a-a4c6d06626af"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("b0b3b700-462c-4ee9-9ee9-96a4e8025ac3"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("181dd2d4-64b2-43c6-81b6-7da3a77e8d99"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("390cf318-8787-4fe8-a591-fd13ce90f619"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("7f8bb765-5d0a-48b2-9e75-386a8ab527be"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("60f21d76-a090-4c82-84cb-c585656e2ded"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(pageTypeUIdParameter);
			var activitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("88f33366-ebf3-4f29-a163-205a1deb5e34"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("3dd6fca7-4f4a-40a9-9e3d-f07132784352"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("278b08b6-9931-4a80-9bec-d1cf8806418e"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("94f83067-f3d9-441a-9281-b941faa79cfe"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("ea59ddce-2ba7-40ed-aa25-704516701ef4"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("fcc06da5-e8f1-46c5-b82b-cc2bad57d865"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("ffd60755-0701-4d4a-839e-d42c73b329d1"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("c4615610-2142-459f-939a-22b2b835c4e6"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("5bd2622b-1a31-47db-9cc6-ef0f1d28d691"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("6eb2abed-f54f-4366-b8c5-7433e0d5803b"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("f7032715-9611-4c85-ba14-fd6be7ecb408"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("67240458-d827-41af-bff9-bc3ba337e680"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("6928c6a9-a547-4376-ae74-e4f1c734dbbd"),
				ContainerUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
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
				UId = new Guid("e6c68d49-3a67-4c77-af1f-5ebc245cef08"),
				ContainerUId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103"),
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
				Value = @"732baa21-890b-4894-a457-623630e33a6f",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f0e3fb86-16b6-43cd-bf28-e690dfa14675"),
				ContainerUId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103"),
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
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,193,114,155,48,16,253,149,14,231,40,3,24,3,246,173,117,221,142,15,173,61,227,76,46,193,135,69,44,182,166,128,24,73,164,117,61,252,123,87,96,19,55,113,210,180,151,230,38,189,121,251,118,247,237,238,193,225,5,104,253,21,74,116,166,206,135,213,151,181,204,205,245,39,81,24,84,159,149,108,106,231,202,209,168,4,20,226,39,102,61,62,207,132,249,8,6,40,224,144,60,196,39,206,52,185,164,144,56,87,137,35,12,150,154,24,54,192,13,61,156,228,19,150,98,154,178,32,206,232,197,113,196,198,121,232,65,156,225,40,13,210,35,243,162,244,162,234,197,59,221,188,123,222,236,107,203,9,8,224,178,172,65,9,45,171,35,56,178,217,245,188,130,180,192,140,254,70,53,72,144,81,162,164,38,240,70,148,184,2,69,73,172,142,180,16,145,114,40,180,101,21,152,155,249,143,90,161,214,66,86,47,85,53,147,69,83,86,231,92,10,199,225,123,44,198,237,42,180,204,21,152,93,39,176,84,153,237,165,237,202,124,191,221,42,220,130,17,247,231,85,124,195,125,71,125,157,115,20,144,209,116,110,161,104,240,152,214,115,159,244,50,131,218,244,45,13,37,16,71,97,142,10,43,142,107,190,195,18,134,46,207,24,98,187,59,147,177,51,189,123,214,148,193,216,63,249,226,19,88,159,200,47,217,60,40,94,236,211,15,9,188,183,64,175,113,122,38,206,221,66,47,191,87,168,250,190,122,103,55,215,132,62,2,6,253,233,193,141,61,47,242,189,136,165,33,248,44,224,0,44,142,120,202,198,81,26,248,52,128,44,143,189,118,211,215,33,116,93,192,254,118,72,55,107,20,217,104,222,201,193,183,133,221,61,234,106,20,135,227,200,13,152,55,193,128,5,161,15,44,141,208,99,60,28,67,60,226,56,201,48,164,101,104,219,77,107,55,162,144,91,193,161,88,214,168,224,56,46,247,242,62,255,118,8,214,6,37,165,185,52,197,149,146,89,195,77,87,212,105,177,40,35,221,185,117,115,45,27,197,177,63,48,221,31,248,63,157,238,127,184,203,191,60,182,103,22,249,53,171,249,86,214,110,241,230,118,170,117,218,95,64,51,139,249,82,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("21a0db48-c769-44b9-bca9-1e4a8e5d8196"),
				ContainerUId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,4,0,183,239,220,131,1,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("98e598ab-767c-4f41-b9d0-7f528e24771c"),
				ContainerUId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103"),
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
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"a31247aa-b718-40ed-982e-5b569d7d7b0e",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9aee3d4d-32c8-472c-b908-f40aee815e2b"),
				ContainerUId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,91,221,110,91,199,17,126,21,130,78,239,180,194,254,239,142,238,218,230,70,128,157,186,85,146,27,219,23,179,127,13,1,138,52,248,147,212,17,4,4,238,101,251,10,69,242,8,105,208,32,105,138,184,175,64,189,81,191,67,73,137,45,216,4,233,82,74,130,28,94,80,226,225,217,157,61,231,204,183,51,223,204,199,179,225,59,139,103,79,235,240,104,248,187,135,15,78,166,109,113,248,251,233,172,30,62,156,77,115,157,207,15,239,79,51,143,71,159,114,26,215,135,60,227,211,186,168,179,15,121,188,172,243,251,163,249,226,96,240,242,160,225,193,240,157,143,215,223,13,143,30,157,13,143,23,245,244,131,227,130,153,165,118,202,132,106,132,246,50,11,219,136,4,123,178,130,157,98,82,236,77,118,13,131,243,116,188,60,157,60,168,11,126,200,139,143,134,71,103,195,245,108,152,160,132,86,149,34,22,28,141,18,54,107,22,137,131,21,169,112,114,49,186,96,188,25,158,31,12,231,249,163,122,202,107,163,63,14,14,70,39,102,173,68,36,153,132,141,157,97,235,130,240,26,163,100,53,134,125,235,6,95,157,191,187,213,50,154,63,29,243,179,15,111,142,127,116,239,164,142,107,94,140,166,147,193,172,206,151,227,197,225,7,147,209,98,48,109,131,211,202,243,229,172,222,123,210,141,127,250,202,141,125,121,134,179,199,151,79,231,241,240,232,241,235,159,207,213,223,147,245,133,191,250,132,94,125,56,143,135,7,143,135,39,211,229,44,119,179,121,124,120,247,165,101,175,13,172,79,185,241,241,250,105,224,200,100,57,30,95,29,121,151,23,124,125,226,245,225,105,25,181,81,45,199,147,147,235,135,176,158,69,94,189,196,107,222,174,95,151,107,251,127,134,61,224,9,255,185,206,222,195,229,255,184,246,31,86,249,62,110,225,245,196,73,147,147,65,53,17,42,147,176,213,107,17,139,98,65,138,82,51,240,149,214,244,122,244,159,106,171,179,58,201,245,213,133,153,216,180,214,178,138,32,163,19,150,108,17,201,102,18,134,60,94,201,27,29,210,213,248,249,250,110,119,48,184,90,87,119,171,206,135,231,231,7,47,131,163,102,45,85,224,36,98,182,152,48,6,194,130,184,8,229,84,107,214,84,146,86,110,4,71,166,144,125,231,208,28,113,131,108,208,69,144,140,73,16,169,234,77,242,46,73,183,127,112,108,107,117,7,112,188,63,93,240,184,135,196,157,67,130,60,73,50,85,11,157,108,21,22,79,79,196,104,88,152,98,82,204,94,53,153,203,38,72,108,189,176,109,33,17,225,247,89,182,38,92,147,128,132,119,82,36,79,89,72,11,140,122,165,189,183,117,35,36,148,207,202,230,28,133,117,4,175,150,17,32,205,25,78,158,124,214,84,91,210,151,94,189,95,72,108,107,117,87,72,28,12,18,207,235,32,47,103,221,205,127,214,35,164,71,72,49,154,225,107,65,232,102,26,124,180,69,145,156,33,161,115,241,136,37,161,180,106,54,7,13,91,173,179,54,10,46,22,185,77,131,215,82,238,182,111,105,3,201,34,165,105,183,128,144,109,173,238,128,144,63,46,121,178,24,45,122,84,220,61,42,92,168,213,102,164,198,174,102,139,77,175,33,63,38,87,132,97,29,125,100,142,196,241,78,227,6,82,146,170,66,141,194,153,132,156,196,42,228,118,6,137,73,106,26,81,76,103,231,82,218,136,138,230,171,228,216,164,240,53,225,138,44,121,193,146,180,72,90,83,110,6,84,165,248,253,163,98,91,171,111,129,138,171,208,177,4,237,152,31,246,129,163,135,72,10,22,108,214,97,7,86,13,169,85,194,230,27,45,179,200,46,235,164,90,86,50,250,141,16,145,38,56,164,248,85,180,12,87,183,33,98,11,79,186,194,99,165,43,69,171,24,117,217,31,68,70,243,251,249,211,43,135,95,204,192,105,119,94,199,77,208,188,121,198,71,247,86,95,172,190,94,125,115,241,215,213,127,46,254,126,241,124,245,229,197,243,193,234,171,139,191,173,254,185,122,113,241,217,234,187,213,183,135,171,127,172,190,92,125,179,250,10,239,223,175,190,93,125,221,67,234,206,33,21,147,105,154,82,18,21,25,16,170,50,213,161,142,148,157,208,100,152,240,133,79,172,239,52,234,40,242,140,90,144,22,28,10,35,237,7,154,88,121,18,82,41,107,139,11,212,204,230,168,83,162,49,9,124,90,196,166,64,30,148,111,130,107,83,162,5,184,49,39,120,181,220,35,164,118,181,186,11,91,225,191,244,128,248,197,85,180,24,30,228,26,92,70,118,143,223,22,83,80,157,173,240,6,95,170,86,202,180,84,119,3,132,137,222,120,133,148,48,43,214,194,234,46,3,43,85,162,98,22,156,145,77,151,160,55,151,123,169,36,229,138,50,2,132,26,121,92,132,127,198,138,11,108,57,57,71,193,230,104,234,254,1,177,173,213,221,0,49,248,77,15,137,62,237,210,150,189,143,30,78,105,145,163,88,205,8,90,86,130,185,179,51,129,44,105,109,237,70,72,48,133,160,58,36,129,39,160,133,66,169,203,116,114,21,41,81,227,22,85,42,249,22,152,201,182,86,119,128,4,26,22,101,153,23,61,40,126,113,113,2,229,38,196,5,116,38,108,77,72,24,90,150,2,27,125,21,20,225,219,214,121,106,181,236,20,39,92,33,149,37,10,65,174,164,174,204,139,74,86,84,88,159,108,197,230,134,46,91,46,110,35,40,180,9,153,3,60,51,89,215,21,174,193,252,57,214,36,60,122,141,210,129,215,52,163,239,130,139,108,187,142,61,115,145,207,241,207,11,176,144,142,143,188,232,206,91,125,143,19,254,61,88,253,119,253,197,191,48,248,187,139,231,61,210,122,138,146,240,114,153,128,52,52,116,64,81,64,253,73,193,235,139,227,230,76,137,104,172,108,206,200,80,85,211,142,114,193,46,228,13,60,188,0,170,25,228,91,203,132,158,145,102,46,49,221,66,67,101,75,171,59,132,31,52,189,243,116,57,129,114,161,207,203,238,30,24,63,191,78,163,114,174,120,164,251,33,32,156,89,9,210,66,81,147,8,44,177,129,55,14,74,234,205,21,99,244,251,60,186,25,66,134,174,17,99,187,86,37,163,153,207,24,172,181,79,132,210,238,45,84,140,183,180,186,3,48,126,123,218,193,162,15,22,61,38,84,206,6,148,183,9,47,9,105,89,227,140,38,29,178,52,208,122,224,211,144,70,178,179,153,171,148,164,99,78,1,176,14,30,21,58,50,168,208,217,38,40,176,205,94,70,34,123,27,92,101,75,171,59,210,119,238,113,241,218,77,255,215,23,43,168,81,118,65,42,164,245,93,157,183,170,4,30,140,157,23,213,51,146,149,42,120,114,220,220,58,177,76,96,93,182,163,77,32,80,40,100,95,246,193,149,236,218,127,197,69,211,104,255,184,216,214,234,91,225,162,151,166,252,212,122,198,159,29,76,156,215,42,56,231,132,79,157,42,64,38,132,143,136,164,221,147,46,148,185,162,220,176,89,154,226,35,58,59,84,208,197,151,26,158,222,117,86,112,65,232,137,19,100,85,232,135,215,202,97,255,48,217,214,234,91,112,141,62,134,244,224,184,86,194,55,80,214,12,1,20,85,224,194,198,220,68,82,42,139,144,99,150,181,122,71,188,57,183,130,168,144,140,135,52,82,165,0,184,179,135,0,183,65,43,162,57,34,52,69,201,153,110,161,87,184,173,213,183,7,71,31,72,250,64,114,179,141,104,29,122,250,50,64,94,182,238,148,16,20,230,181,160,77,9,41,151,178,41,168,146,54,75,85,2,23,231,157,245,34,184,8,175,69,17,22,74,176,106,33,82,243,12,213,161,69,245,251,22,52,142,219,90,221,153,155,247,16,233,33,114,147,146,184,72,208,108,53,81,106,183,47,231,236,161,56,135,244,49,89,109,154,2,41,97,187,153,146,68,159,160,1,33,108,236,132,61,221,66,39,137,172,7,174,110,130,150,53,20,13,160,217,253,67,228,209,189,71,199,243,63,124,50,169,179,203,92,244,168,241,120,94,159,28,226,232,141,3,63,252,162,233,232,12,202,158,2,6,6,141,169,45,8,157,161,83,17,91,192,44,134,216,92,108,196,169,198,243,39,151,5,172,55,99,235,189,250,201,96,52,249,120,58,202,117,112,92,126,178,114,151,249,53,252,254,234,13,140,35,181,100,148,41,16,133,64,87,113,201,163,99,181,186,99,44,104,157,201,194,33,187,157,139,184,144,201,2,5,168,241,64,201,4,77,35,219,22,5,122,114,248,42,37,21,226,230,34,174,130,34,178,68,104,200,130,143,64,65,66,143,147,45,7,145,60,230,73,205,58,2,140,246,223,221,216,210,234,78,205,117,248,117,95,195,237,73,56,212,189,145,20,144,69,86,162,232,19,160,195,34,139,55,224,203,1,18,170,114,221,12,9,67,42,234,12,209,150,85,104,100,219,22,20,178,24,192,85,21,52,255,35,188,220,199,91,128,196,182,86,119,133,68,159,58,245,169,211,249,249,147,243,255,1,23,101,183,166,237,62,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("79d72c86-b946-4e74-b82c-577c9d0709aa"),
				ContainerUId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103"),
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
				UId = new Guid("5ab8dc60-4761-45d5-9108-08b4232cf439"),
				ContainerUId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103"),
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

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaTerminateEvent terminate2 = CreateTerminate2TerminateEvent();
			FlowElements.Add(terminate2);
			ProcessSchemaUserTask openeditpageusertask1 = CreateOpenEditPageUserTask1UserTask();
			FlowElements.Add(openeditpageusertask1);
			ProcessSchemaScriptTask createinvoicebyorderscripttask = CreateCreateInvoiceByOrderScriptTaskScriptTask();
			FlowElements.Add(createinvoicebyorderscripttask);
			ProcessSchemaUserTask adddatausertask1 = CreateAddDataUserTask1UserTask();
			FlowElements.Add(adddatausertask1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("f443c380-06ca-42a4-a4e4-b7b872174d35"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5aa8040b-8cb0-4885-ac08-be852fb6adeb"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a3117259-5f0d-4df4-bc73-269483d394df"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a003fd82-9248-4113-b40e-b8740d59adfc"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("f46b6e3b-9407-4fbb-996a-46db3398573f"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{08117217-b6a2-4caa-87cb-57b42ebbdf81}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5aa8040b-8cb0-4885-ac08-be852fb6adeb"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				CurveCenterPosition = new Point(280, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a003fd82-9248-4113-b40e-b8740d59adfc"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a4dd9327-058c-4700-90d5-2755a7fb610e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow5",
				UId = new Guid("6232cb52-bf09-4f98-ba6c-c2f814947e82"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5aa8040b-8cb0-4885-ac08-be852fb6adeb"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				CurveCenterPosition = new Point(196, 132),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a003fd82-9248-4113-b40e-b8740d59adfc"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5ea2d96f-07ec-414d-94ef-8b09e6207daa"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("1e44a001-eb2b-4334-a096-4a5004526ddb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c8c880a9-c137-49b0-9cc0-525f6f195c44"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0b76f581-3e18-4e18-be44-b60d06cfca12"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow2",
				UId = new Guid("0ee76b44-a070-4ad2-aaf7-74d92fd9cf6a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("650a2ad9-42d3-4738-b18c-b0f4ce2ed031"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				CurveCenterPosition = new Point(424, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a4dd9327-058c-4700-90d5-2755a7fb610e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("00639cff-47d3-49fc-9b19-be763f064d26"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("25b0287a-c3a8-4066-b6ef-e5dad7c3be5a"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("b3946209-b995-4883-907a-ab9d2b18d187"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5aa8040b-8cb0-4885-ac08-be852fb6adeb"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("c8da6c77-6ee6-42cc-8c4e-47768f1b383a"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("b3946209-b995-4883-907a-ab9d2b18d187"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("5aa8040b-8cb0-4885-ac08-be852fb6adeb"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("a3117259-5f0d-4df4-bc73-269483d394df"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c8da6c77-6ee6-42cc-8c4e-47768f1b383a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5aa8040b-8cb0-4885-ac08-be852fb6adeb"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("0b76f581-3e18-4e18-be44-b60d06cfca12"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c8da6c77-6ee6-42cc-8c4e-47768f1b383a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5aa8040b-8cb0-4885-ac08-be852fb6adeb"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"Terminate1",
				Position = new Point(687, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("a003fd82-9248-4113-b40e-b8740d59adfc"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c8da6c77-6ee6-42cc-8c4e-47768f1b383a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5aa8040b-8cb0-4885-ac08-be852fb6adeb"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"ExclusiveGateway1",
				Position = new Point(134, 170),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate2TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("5ea2d96f-07ec-414d-94ef-8b09e6207daa"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c8da6c77-6ee6-42cc-8c4e-47768f1b383a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5aa8040b-8cb0-4885-ac08-be852fb6adeb"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"Terminate2",
				Position = new Point(148, 72),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateOpenEditPageUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c8da6c77-6ee6-42cc-8c4e-47768f1b383a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c8c880a9-c137-49b0-9cc0-525f6f195c44"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				DragGroupName = @"Task",
				EntitySchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"OpenEditPageUserTask1",
				Position = new Point(561, 170),
				SchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenEditPageUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateCreateInvoiceByOrderScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("a4dd9327-058c-4700-90d5-2755a7fb610e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c8da6c77-6ee6-42cc-8c4e-47768f1b383a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("650a2ad9-42d3-4738-b18c-b0f4ce2ed031"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"CreateInvoiceByOrderScriptTask",
				Position = new Point(281, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,245,204,43,203,207,76,78,213,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,141,78,144,14,30,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c8da6c77-6ee6-42cc-8c4e-47768f1b383a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("25b0287a-c3a8-4066-b6ef-e5dad7c3be5a"),
				CreatedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"),
				Name = @"AddDataUserTask1",
				Position = new Point(421, 170),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("26608e55-5a62-4b83-bf82-7355ce9827fa"),
				Name = "BPMSoft.Configuration.OrderInvoice",
				Alias = "",
				CreatedInPackageId = new Guid("650a2ad9-42d3-4738-b18c-b0f4ce2ed031")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CreateInvoiceFromOrder(userConnection);
		}

		public override object Clone() {
			return new CreateInvoiceFromOrderSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835"));
		}

		#endregion

	}

	#endregion

	#region Class: CreateInvoiceFromOrder

	/// <exclude/>
	public class CreateInvoiceFromOrder : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CreateInvoiceFromOrder process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenEditPageUserTask1FlowElement

		/// <exclude/>
		public class OpenEditPageUserTask1FlowElement : OpenEditPageUserTask
		{

			#region Constructors: Public

			public OpenEditPageUserTask1FlowElement(UserConnection userConnection, CreateInvoiceFromOrder process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenEditPageUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("f1a1e116-6123-4a56-9344-3526a839225c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_recordId = () => (Guid)((process.CreatedInvoiceId));
			}

			#endregion

			#region Properties: Public

			private Guid _objectSchemaId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			public override Guid ObjectSchemaId {
				get {
					return _objectSchemaId;
				}
				set {
					_objectSchemaId = value;
				}
			}

			private Guid _pageSchemaId = new Guid("b8a98131-367e-4bc0-88b7-06bea6a143de");
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

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("608044dbcecb4a1fbf9171d57b8a1835",
						 "BaseElements.OpenEditPageUserTask1.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
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

			public AddDataUserTask1FlowElement(UserConnection userConnection, CreateInvoiceFromOrder process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("7c141fed-2ab7-4b81-aaf7-05788f198103");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Invoice = () => (Guid)((process.CreatedInvoiceId));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Unit", () => _recordDefValues_Unit.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_TotalAmount", () => _recordDefValues_TotalAmount.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_PrimaryTotalAmount", () => _recordDefValues_PrimaryTotalAmount.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Quantity", () => _recordDefValues_Quantity.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_BaseQuantity", () => _recordDefValues_BaseQuantity.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Name", () => _recordDefValues_Name.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Tax", () => _recordDefValues_Tax.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DiscountTax", () => _recordDefValues_DiscountTax.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Product", () => _recordDefValues_Product.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_CustomProduct", () => _recordDefValues_CustomProduct.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DiscountPercent", () => _recordDefValues_DiscountPercent.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Amount", () => _recordDefValues_Amount.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_TaxAmount", () => _recordDefValues_TaxAmount.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_PrimaryTaxAmount", () => _recordDefValues_PrimaryTaxAmount.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DiscountAmount", () => _recordDefValues_DiscountAmount.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_PrimaryDiscountAmount", () => _recordDefValues_PrimaryDiscountAmount.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_PrimaryAmount", () => _recordDefValues_PrimaryAmount.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Invoice", () => _recordDefValues_Invoice.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Price", () => _recordDefValues_Price.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_PrimaryPrice", () => _recordDefValues_PrimaryPrice.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Unit;
			internal Func<Decimal> _recordDefValues_TotalAmount;
			internal Func<Decimal> _recordDefValues_PrimaryTotalAmount;
			internal Func<Decimal> _recordDefValues_Quantity;
			internal Func<Decimal> _recordDefValues_BaseQuantity;
			internal Func<string> _recordDefValues_Name;
			internal Func<Guid> _recordDefValues_Tax;
			internal Func<Decimal> _recordDefValues_DiscountTax;
			internal Func<Guid> _recordDefValues_Product;
			internal Func<string> _recordDefValues_CustomProduct;
			internal Func<Decimal> _recordDefValues_DiscountPercent;
			internal Func<Decimal> _recordDefValues_Amount;
			internal Func<Decimal> _recordDefValues_TaxAmount;
			internal Func<Decimal> _recordDefValues_PrimaryTaxAmount;
			internal Func<Decimal> _recordDefValues_DiscountAmount;
			internal Func<Decimal> _recordDefValues_PrimaryDiscountAmount;
			internal Func<Decimal> _recordDefValues_PrimaryAmount;
			internal Func<Guid> _recordDefValues_Invoice;
			internal Func<Decimal> _recordDefValues_Price;
			internal Func<Decimal> _recordDefValues_PrimaryPrice;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("732baa21-890b-4894-a457-623630e33a6f");
			public override Guid EntitySchemaId {
				get {
					return _entitySchemaId;
				}
				set {
					_entitySchemaId = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,193,114,155,48,16,253,149,14,231,40,3,24,3,246,173,117,221,142,15,173,61,227,76,46,193,135,69,44,182,166,128,24,73,164,117,61,252,123,87,96,19,55,113,210,180,151,230,38,189,121,251,118,247,237,238,193,225,5,104,253,21,74,116,166,206,135,213,151,181,204,205,245,39,81,24,84,159,149,108,106,231,202,209,168,4,20,226,39,102,61,62,207,132,249,8,6,40,224,144,60,196,39,206,52,185,164,144,56,87,137,35,12,150,154,24,54,192,13,61,156,228,19,150,98,154,178,32,206,232,197,113,196,198,121,232,65,156,225,40,13,210,35,243,162,244,162,234,197,59,221,188,123,222,236,107,203,9,8,224,178,172,65,9,45,171,35,56,178,217,245,188,130,180,192,140,254,70,53,72,144,81,162,164,38,240,70,148,184,2,69,73,172,142,180,16,145,114,40,180,101,21,152,155,249,143,90,161,214,66,86,47,85,53,147,69,83,86,231,92,10,199,225,123,44,198,237,42,180,204,21,152,93,39,176,84,153,237,165,237,202,124,191,221,42,220,130,17,247,231,85,124,195,125,71,125,157,115,20,144,209,116,110,161,104,240,152,214,115,159,244,50,131,218,244,45,13,37,16,71,97,142,10,43,142,107,190,195,18,134,46,207,24,98,187,59,147,177,51,189,123,214,148,193,216,63,249,226,19,88,159,200,47,217,60,40,94,236,211,15,9,188,183,64,175,113,122,38,206,221,66,47,191,87,168,250,190,122,103,55,215,132,62,2,6,253,233,193,141,61,47,242,189,136,165,33,248,44,224,0,44,142,120,202,198,81,26,248,52,128,44,143,189,118,211,215,33,116,93,192,254,118,72,55,107,20,217,104,222,201,193,183,133,221,61,234,106,20,135,227,200,13,152,55,193,128,5,161,15,44,141,208,99,60,28,67,60,226,56,201,48,164,101,104,219,77,107,55,162,144,91,193,161,88,214,168,224,56,46,247,242,62,255,118,8,214,6,37,165,185,52,197,149,146,89,195,77,87,212,105,177,40,35,221,185,117,115,45,27,197,177,63,48,221,31,248,63,157,238,127,184,203,191,60,182,103,22,249,53,171,249,86,214,110,241,230,118,170,117,218,95,64,51,139,249,82,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _recordAddMode;
			public override string RecordAddMode {
				get {
					return _recordAddMode ?? (_recordAddMode = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,4,0,183,239,220,131,1,0,0,0 })));
				}
				set {
					_recordAddMode = value;
				}
			}

			private Guid _filterEntitySchemaId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			public override Guid FilterEntitySchemaId {
				get {
					return _filterEntitySchemaId;
				}
				set {
					_filterEntitySchemaId = value;
				}
			}

			private EntityColumnMappingValues _recordDefValues;
			public override EntityColumnMappingValues RecordDefValues {
				get {
					if (_recordDefValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,91,77,111,27,71,18,253,43,2,157,220,212,66,127,119,151,110,187,201,69,128,157,245,174,146,92,44,31,170,187,171,55,4,40,210,224,71,178,142,161,255,158,55,148,148,216,130,67,144,94,74,118,144,225,65,130,134,236,169,225,76,189,174,247,234,149,222,77,190,90,191,125,35,147,243,201,63,95,190,184,92,244,245,217,55,139,165,156,189,92,46,170,172,86,103,207,23,149,103,211,95,185,204,228,37,47,249,90,214,178,252,145,103,27,89,61,159,174,214,167,39,239,47,154,156,78,190,250,121,251,222,228,252,213,187,201,197,90,174,127,184,104,56,179,182,193,184,36,78,217,168,171,242,157,72,113,36,175,56,24,38,195,209,213,208,177,184,46,102,155,235,249,11,89,243,75,94,255,52,57,127,55,217,158,13,39,104,169,139,49,196,138,179,51,202,87,203,170,112,242,170,52,46,33,231,144,92,116,147,155,211,201,170,254,36,215,188,13,250,199,226,228,108,97,182,70,101,210,69,249,60,4,246,33,169,104,177,74,139,115,28,251,176,248,238,243,135,71,109,211,213,155,25,191,253,241,225,250,87,207,46,101,38,117,61,93,204,79,150,178,218,204,214,103,63,204,167,235,147,69,63,185,22,94,109,150,242,236,245,176,254,205,7,55,246,253,51,188,187,186,125,58,87,147,243,171,143,63,159,187,223,151,219,47,254,225,19,250,240,225,92,77,78,175,38,151,139,205,178,14,103,139,248,227,219,247,46,123,27,96,251,145,7,127,222,63,13,28,153,111,102,179,187,35,223,242,154,239,63,120,127,120,209,166,125,42,237,98,126,121,255,16,182,103,209,119,47,245,145,31,247,175,219,107,251,127,150,189,224,57,255,87,150,223,225,235,255,113,237,191,95,229,247,184,133,247,39,46,150,130,78,166,171,36,76,202,75,180,42,55,195,138,12,149,238,144,43,189,219,237,234,255,72,151,165,204,171,124,120,97,46,119,107,173,22,149,116,14,202,147,111,170,248,74,202,81,196,171,68,103,83,185,91,191,218,222,237,1,6,119,215,53,220,170,155,201,205,205,233,251,224,144,106,181,73,92,84,174,30,39,204,137,112,65,220,148,9,166,119,239,132,180,215,59,193,81,41,213,56,36,52,103,220,32,159,108,83,164,115,81,68,70,162,43,49,20,29,142,15,142,125,163,30,0,142,239,23,107,158,141,144,120,114,72,80,36,77,78,172,178,197,139,242,120,122,42,103,199,202,53,87,114,141,166,235,218,118,65,98,239,11,219,23,18,25,121,95,117,239,42,116,13,72,196,160,85,137,84,149,246,192,104,52,54,70,47,59,33,97,98,53,190,214,172,124,32,100,181,206,0,105,173,72,242,18,171,37,233,197,222,102,245,113,33,177,111,212,67,33,113,122,82,120,37,39,117,179,28,110,254,219,17,33,35,66,154,179,140,92,75,202,118,215,145,163,61,171,18,28,41,91,91,68,45,73,173,139,219,93,52,188,248,224,125,86,220,60,184,77,71,214,82,29,182,111,237,19,233,166,181,235,143,128,144,125,163,30,128,144,127,111,120,190,158,174,71,84,60,61,42,66,18,241,21,212,56,72,245,216,244,58,248,49,133,166,28,219,28,51,115,38,206,79,90,55,64,73,196,36,201,42,184,2,78,226,13,184,157,3,49,41,221,162,138,217,26,66,41,59,81,209,163,104,206,93,171,40,5,223,200,83,84,172,201,170,98,45,213,238,32,85,90,60,62,42,246,141,250,9,168,184,43,29,27,200,142,213,217,88,56,70,136,148,228,161,102,3,118,96,211,65,173,10,54,223,236,153,85,13,213,22,211,171,209,57,238,132,136,118,41,128,226,139,234,21,169,238,83,198,22,94,172,32,99,117,104,205,154,156,109,59,30,68,166,171,231,245,215,187,132,95,47,55,242,17,20,124,228,35,163,160,126,194,42,144,139,235,150,74,81,2,70,130,46,137,4,244,117,106,80,150,28,19,222,136,133,237,147,86,1,67,145,209,155,177,138,83,99,208,112,100,55,155,72,74,27,227,125,11,137,186,219,93,5,90,118,174,64,223,170,220,13,200,188,137,93,177,116,163,122,66,122,115,65,182,235,35,166,248,161,81,15,81,15,252,191,113,207,255,203,117,152,24,25,20,58,82,70,15,143,223,55,215,208,45,21,100,67,108,98,141,113,189,200,97,128,112,57,186,104,64,209,170,97,171,188,29,24,81,19,141,14,86,10,78,119,219,146,221,221,126,165,86,76,104,198,41,8,92,240,170,140,252,204,130,47,216,107,9,129,146,175,217,201,241,1,177,111,212,195,0,113,242,245,8,137,145,6,89,207,49,230,136,164,244,224,46,222,50,138,150,215,80,210,28,92,34,79,214,122,191,19,18,76,41,153,1,73,224,237,176,52,168,12,12,168,138,42,133,58,247,108,74,171,143,160,20,246,141,122,0,36,96,32,180,77,93,143,160,248,203,213,9,180,127,80,23,224,20,120,41,32,12,189,106,133,141,94,20,101,228,182,15,145,186,180,131,234,68,104,100,170,70,99,38,180,50,180,93,209,89,202,6,215,167,123,243,181,195,245,170,45,236,4,133,117,169,114,66,102,22,31,134,70,50,148,56,103,41,42,194,251,211,1,58,163,59,59,106,131,191,145,217,246,197,105,131,130,87,168,132,20,135,179,1,109,0,13,76,6,123,112,11,220,131,107,25,14,195,110,42,132,246,146,13,84,27,46,33,58,164,120,3,70,42,212,176,213,5,230,137,101,110,185,60,130,179,176,103,212,3,246,125,184,191,117,177,153,195,194,31,9,209,211,3,227,203,179,220,76,8,45,130,103,167,132,58,226,53,212,2,101,75,42,177,198,14,222,57,25,109,119,183,78,97,124,69,180,245,149,78,131,35,225,7,207,142,225,106,51,22,91,27,11,161,199,249,8,173,211,61,163,30,0,140,127,92,15,176,24,249,208,136,9,83,171,131,214,236,42,106,2,31,234,92,225,86,129,30,65,79,3,159,142,44,216,206,110,145,208,138,205,181,36,192,58,69,148,63,114,40,127,190,43,74,236,107,212,153,200,63,134,72,216,51,234,129,186,153,71,92,124,30,18,245,197,213,10,234,84,67,210,6,188,126,104,176,138,41,16,160,216,121,209,182,34,45,36,16,168,121,183,135,224,153,32,119,252,160,87,160,92,192,18,111,13,97,163,7,31,172,133,236,58,29,31,23,251,70,253,36,92,140,51,26,159,91,107,124,113,48,9,209,154,20,66,80,177,12,246,184,46,40,31,25,164,61,146,109,84,89,160,243,119,207,104,196,12,217,68,13,118,182,182,200,244,193,210,192,23,130,57,76,152,47,130,49,44,194,233,248,48,217,55,234,39,104,141,177,134,140,224,184,31,9,239,144,172,21,147,64,36,192,133,207,181,171,98,76,85,169,230,170,69,98,32,222,205,173,48,93,71,46,98,70,208,148,4,184,115,196,36,106,199,208,132,229,140,210,148,53,87,122,4,147,110,223,168,159,14,142,177,144,140,133,228,161,127,231,3,26,102,58,97,206,106,107,81,16,70,173,165,193,31,196,76,147,241,37,153,86,118,207,108,36,110,33,6,31,85,10,25,89,139,46,44,70,162,196,99,90,43,50,198,239,60,218,206,143,48,236,183,111,212,131,181,249,8,145,17,34,15,37,73,200,132,225,165,174,154,12,251,114,173,17,163,215,152,1,44,222,186,110,32,74,216,239,150,36,57,22,12,95,16,54,118,194,158,238,49,48,8,214,131,84,119,201,106,73,205,2,104,254,248,16,121,245,236,213,197,234,95,191,204,101,121,203,69,207,59,207,86,242,250,12,71,31,28,248,253,95,123,206,223,161,109,222,160,192,48,108,233,27,74,103,26,198,105,61,96,150,83,238,33,119,226,34,249,230,245,109,3,235,207,177,245,157,252,114,50,157,255,188,152,86,57,185,104,159,173,221,229,254,14,255,136,244,39,138,163,244,226,140,107,152,198,192,64,195,173,142,206,226,237,160,88,224,157,233,198,169,134,131,155,184,152,23,5,10,208,227,193,8,17,134,251,216,99,52,28,166,28,222,42,197,164,188,187,137,107,48,26,216,50,12,154,20,51,80,80,96,46,178,231,164,74,196,121,74,247,129,0,163,227,187,27,123,70,61,200,213,70,94,143,61,220,81,132,99,204,53,147,1,178,200,107,52,125,18,6,160,200,227,7,240,21,0,9,35,44,187,33,225,200,100,91,49,45,229,13,156,108,223,147,1,139,1,92,77,131,235,158,145,229,49,63,2,36,246,141,122,40,36,70,234,52,82,167,155,155,215,55,191,1,191,34,220,233,246,61,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "608044dbcecb4a1fbf9171d57b8a1835",
							"BaseElements.AddDataUserTask1.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("25b0287a-c3a8-4066-b6ef-e5dad7c3be5a");
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

		public CreateInvoiceFromOrder(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CreateInvoiceFromOrder";
			SchemaUId = new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835");
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
				return new Guid("608044db-cecb-4a1f-bf91-71d57b8a1835");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CreateInvoiceFromOrder, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CreateInvoiceFromOrder, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid CurrentOrder {
			get;
			set;
		}

		public virtual Guid CreatedInvoiceId {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _start1;
		public ProcessFlowElement Start1 {
			get {
				return _start1 ?? (_start1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "Start1",
					SchemaElementUId = new Guid("a3117259-5f0d-4df4-bc73-269483d394df"),
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
					SchemaElementUId = new Guid("0b76f581-3e18-4e18-be44-b60d06cfca12"),
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
					SchemaElementUId = new Guid("a003fd82-9248-4113-b40e-b8740d59adfc"),
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

		private ProcessTerminateEvent _terminate2;
		public ProcessTerminateEvent Terminate2 {
			get {
				return _terminate2 ?? (_terminate2 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate2",
					SchemaElementUId = new Guid("5ea2d96f-07ec-414d-94ef-8b09e6207daa"),
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

		private ProcessScriptTask _createInvoiceByOrderScriptTask;
		public ProcessScriptTask CreateInvoiceByOrderScriptTask {
			get {
				return _createInvoiceByOrderScriptTask ?? (_createInvoiceByOrderScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CreateInvoiceByOrderScriptTask",
					SchemaElementUId = new Guid("a4dd9327-058c-4700-90d5-2755a7fb610e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = CreateInvoiceByOrderScriptTaskExecute,
				});
			}
		}

		private AddDataUserTask1FlowElement _addDataUserTask1;
		public AddDataUserTask1FlowElement AddDataUserTask1 {
			get {
				return _addDataUserTask1 ?? (_addDataUserTask1 = new AddDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("f46b6e3b-9407-4fbb-996a-46db3398573f"),
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
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[Terminate2.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate2 };
			FlowElements[OpenEditPageUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenEditPageUserTask1 };
			FlowElements[CreateInvoiceByOrderScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateInvoiceByOrderScriptTask };
			FlowElements[AddDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataUserTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateInvoiceByOrderScriptTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
						break;
					case "Terminate2":
						CompleteProcess();
						break;
					case "OpenEditPageUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "CreateInvoiceByOrderScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataUserTask1", e.Context.SenderName));
						break;
					case "AddDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenEditPageUserTask1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((CurrentOrder) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow1", "(CurrentOrder) != Guid.Empty", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CurrentOrder")) {
				writer.WriteValue("CurrentOrder", CurrentOrder, Guid.Empty);
			}
			if (!HasMapping("CreatedInvoiceId")) {
				writer.WriteValue("CreatedInvoiceId", CreatedInvoiceId, Guid.Empty);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("Start1", string.Empty));
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
			MetaPathParameterValues.Add("08117217-b6a2-4caa-87cb-57b42ebbdf81", () => CurrentOrder);
			MetaPathParameterValues.Add("9b6df9ca-b4dc-4748-a446-878f58f9abe8", () => CreatedInvoiceId);
			MetaPathParameterValues.Add("d85118e6-2c1e-4d34-afa5-de5b61c76366", () => OpenEditPageUserTask1.ObjectSchemaId);
			MetaPathParameterValues.Add("91937424-2f71-4f1f-a3b2-d440bd5541d2", () => OpenEditPageUserTask1.PageSchemaId);
			MetaPathParameterValues.Add("2dac85ca-0040-4966-a412-c2232b004d2b", () => OpenEditPageUserTask1.EditMode);
			MetaPathParameterValues.Add("c1fbab13-0fcc-4a08-8a27-9c61b940678a", () => OpenEditPageUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("69857298-5af6-4e7c-8304-9fec7c1d334f", () => OpenEditPageUserTask1.RecordId);
			MetaPathParameterValues.Add("03005092-ebd2-40a5-a4ba-1feda715e4ab", () => OpenEditPageUserTask1.ExecutedMode);
			MetaPathParameterValues.Add("0e17b357-37db-48e3-b5b8-e62e0687bddf", () => OpenEditPageUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("e7f46f88-3a82-4148-a2e2-d7bd427e03a0", () => OpenEditPageUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("2ae3d7cd-e356-43c7-bc44-a3695025a7f9", () => OpenEditPageUserTask1.GenerateDecisionsFromColumn);
			MetaPathParameterValues.Add("9bdca34c-1f63-47aa-a579-fdd93f26eac3", () => OpenEditPageUserTask1.DecisionalColumnMetaPath);
			MetaPathParameterValues.Add("4a705262-6f06-417e-a8c7-f5a2d1f63fe5", () => OpenEditPageUserTask1.ResultParameter);
			MetaPathParameterValues.Add("26151eb5-20dc-466e-972e-c72498300aa7", () => OpenEditPageUserTask1.IsReexecution);
			MetaPathParameterValues.Add("ea935a75-0c11-482c-9e99-d04fc6977707", () => OpenEditPageUserTask1.Recommendation);
			MetaPathParameterValues.Add("a3c2a6f9-b087-4a04-b687-52b26aa4e66b", () => OpenEditPageUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("75d81580-4664-441e-9b0d-0d954ffefc72", () => OpenEditPageUserTask1.OwnerId);
			MetaPathParameterValues.Add("56d9018d-ca95-4d5a-b482-07336f8786cb", () => OpenEditPageUserTask1.Duration);
			MetaPathParameterValues.Add("171f4ae2-f53f-4545-8cec-973f64a4576c", () => OpenEditPageUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("83f5e8fe-aef9-4bc8-b439-e3d3f6f61866", () => OpenEditPageUserTask1.StartIn);
			MetaPathParameterValues.Add("22b00966-521c-4147-b0dd-880c07bb49b4", () => OpenEditPageUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("1076ae54-e8ed-4d6f-8d4d-2e25408bb776", () => OpenEditPageUserTask1.RemindBefore);
			MetaPathParameterValues.Add("390e7e01-63f1-47ee-9272-137e604112f1", () => OpenEditPageUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("3100ca53-bbf6-4ce1-81f5-3a74d220ec16", () => OpenEditPageUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("1864aa91-6db8-4edf-9528-1e271677b340", () => OpenEditPageUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("d4513854-0edf-4b46-864c-3ec250465806", () => OpenEditPageUserTask1.Lead);
			MetaPathParameterValues.Add("d1a00ae7-ea8e-4faf-9be8-bbb151893c96", () => OpenEditPageUserTask1.Account);
			MetaPathParameterValues.Add("81643ee9-7afe-4461-9cf6-9a97b4c18843", () => OpenEditPageUserTask1.Contact);
			MetaPathParameterValues.Add("7d314b93-7262-4ca5-9f0b-175bcee0be87", () => OpenEditPageUserTask1.Opportunity);
			MetaPathParameterValues.Add("0dcd1985-fcf0-477b-85e3-cc32230b0c60", () => OpenEditPageUserTask1.Invoice);
			MetaPathParameterValues.Add("9d7f3abd-fc1c-4c09-8a0d-793ad6b9a9d1", () => OpenEditPageUserTask1.Document);
			MetaPathParameterValues.Add("28c6ffdb-91ea-49c5-a622-85c4248e047b", () => OpenEditPageUserTask1.Incident);
			MetaPathParameterValues.Add("ca2ee227-e2c2-4921-9f1a-a4c6d06626af", () => OpenEditPageUserTask1.Case);
			MetaPathParameterValues.Add("b0b3b700-462c-4ee9-9ee9-96a4e8025ac3", () => OpenEditPageUserTask1.ActivityResult);
			MetaPathParameterValues.Add("181dd2d4-64b2-43c6-81b6-7da3a77e8d99", () => OpenEditPageUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("390cf318-8787-4fe8-a591-fd13ce90f619", () => OpenEditPageUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("7f8bb765-5d0a-48b2-9e75-386a8ab527be", () => OpenEditPageUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("60f21d76-a090-4c82-84cb-c585656e2ded", () => OpenEditPageUserTask1.PageTypeUId);
			MetaPathParameterValues.Add("88f33366-ebf3-4f29-a163-205a1deb5e34", () => OpenEditPageUserTask1.ActivitySchemaUId);
			MetaPathParameterValues.Add("3dd6fca7-4f4a-40a9-9e3d-f07132784352", () => OpenEditPageUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("278b08b6-9931-4a80-9bec-d1cf8806418e", () => OpenEditPageUserTask1.Order);
			MetaPathParameterValues.Add("94f83067-f3d9-441a-9281-b941faa79cfe", () => OpenEditPageUserTask1.Requests);
			MetaPathParameterValues.Add("ea59ddce-2ba7-40ed-aa25-704516701ef4", () => OpenEditPageUserTask1.Listing);
			MetaPathParameterValues.Add("fcc06da5-e8f1-46c5-b82b-cc2bad57d865", () => OpenEditPageUserTask1.Property);
			MetaPathParameterValues.Add("ffd60755-0701-4d4a-839e-d42c73b329d1", () => OpenEditPageUserTask1.Contract);
			MetaPathParameterValues.Add("c4615610-2142-459f-939a-22b2b835c4e6", () => OpenEditPageUserTask1.Problem);
			MetaPathParameterValues.Add("5bd2622b-1a31-47db-9cc6-ef0f1d28d691", () => OpenEditPageUserTask1.Change);
			MetaPathParameterValues.Add("6eb2abed-f54f-4366-b8c5-7433e0d5803b", () => OpenEditPageUserTask1.Release);
			MetaPathParameterValues.Add("f7032715-9611-4c85-ba14-fd6be7ecb408", () => OpenEditPageUserTask1.Project);
			MetaPathParameterValues.Add("67240458-d827-41af-bff9-bc3ba337e680", () => OpenEditPageUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("6928c6a9-a547-4376-ae74-e4f1c734dbbd", () => OpenEditPageUserTask1.CreateActivity);
			MetaPathParameterValues.Add("e6c68d49-3a67-4c77-af1f-5ebc245cef08", () => AddDataUserTask1.EntitySchemaId);
			MetaPathParameterValues.Add("f0e3fb86-16b6-43cd-bf28-e690dfa14675", () => AddDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("21a0db48-c769-44b9-bca9-1e4a8e5d8196", () => AddDataUserTask1.RecordAddMode);
			MetaPathParameterValues.Add("98e598ab-767c-4f41-b9d0-7f528e24771c", () => AddDataUserTask1.FilterEntitySchemaId);
			MetaPathParameterValues.Add("9aee3d4d-32c8-472c-b908-f40aee815e2b", () => AddDataUserTask1.RecordDefValues);
			MetaPathParameterValues.Add("79d72c86-b946-4e74-b82c-577c9d0709aa", () => AddDataUserTask1.RecordId);
			MetaPathParameterValues.Add("5ab8dc60-4761-45d5-9108-08b4232cf439", () => AddDataUserTask1.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CurrentOrder":
					if (!hasValueToRead) break;
					CurrentOrder = reader.GetValue<System.Guid>();
				break;
				case "CreatedInvoiceId":
					if (!hasValueToRead) break;
					CreatedInvoiceId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool CreateInvoiceByOrderScriptTaskExecute(ProcessExecutingContext context) {
			CreateInvoice();
			return true;
		}

			
			public virtual void CreateInvoice() {
				OrderInvoiceHelper helper = Factories.ClassFactory.Get<OrderInvoiceHelper>(new Factories.ConstructorArgument("userConnection", UserConnection));
			CreatedInvoiceId = helper.CreateEntity("Order", "Invoice", CurrentOrder, new Dictionary<string, string> {
				{"Currency", "Currency"},
				{"CurrencyRate", "CurrencyRate"},
				{"Contact", "Contact"},
				{"Account", "Account"},
				{"Owner", "Owner"},
				{"Amount", "Amount"},
				{"Opportunity", "Opportunity"}
			}, new Dictionary<string, object> { { "Order", CurrentOrder } });
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
			var cloneItem = (CreateInvoiceFromOrder)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

