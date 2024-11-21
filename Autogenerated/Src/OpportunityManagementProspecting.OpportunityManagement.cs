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

	#region Class: OpportunityManagementProspectingSchema

	/// <exclude/>
	public class OpportunityManagementProspectingSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public OpportunityManagementProspectingSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public OpportunityManagementProspectingSchema(OpportunityManagementProspectingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "OpportunityManagementProspecting";
			UId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f");
			CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58");
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
			Tag = @"OpportunityManagement";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f");
			Version = 0;
			PackageUId = new Guid("75b64d44-f646-4025-b2dc-16a7526ff5fd");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCurrentOpportunityParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4c6e9a6c-52a3-4f25-879f-96941c1aa349"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateOpportunityStageChangedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0bd1bc47-97dc-487d-b8b8-e5bd0a629ed8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"OpportunityStageChanged",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMainContactParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("83114e9e-fb66-424f-a1a6-d23fb5945480"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"MainContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCurrentOpportunityParameter());
			Parameters.Add(CreateOpportunityStageChangedParameter());
			Parameters.Add(CreateMainContactParameter());
		}

		protected virtual void InitializeOpenEditPageUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var objectSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("ae7d9be8-2794-4f16-9a39-ccf50ecdba24"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				Value = @"ae46fb87-c02c-4ae8-ad31-a923cdd994cf",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(objectSchemaIdParameter);
			var pageSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("db76b6e1-5420-4968-9631-759ba37819e2"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				Value = @"df249c13-df7a-48d2-b128-85183c4a0e10",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(pageSchemaIdParameter);
			var editModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6efa15b1-5137-45fa-809e-79bb3db89358"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(editModeParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9324bb9c-5017-411c-b5a5-fb117947ef43"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("f271250b-3c06-467b-b95f-c2d2e9c3019c"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{4c6e9a6c-52a3-4f25-879f-96941c1aa349}]#]",
				MetaPath = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{4c6e9a6c-52a3-4f25-879f-96941c1aa349}]#]",
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var executedModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dbb47148-8d67-4fe3-825b-477f8d55c92b"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("701175ea-0e46-4f61-938b-eedf9af21920"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("540b1d28-96f8-4793-b6dc-f222c6d4efbd"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var generateDecisionsFromColumnParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8a056fe6-95e1-4710-b4ff-d50ef63e2916"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(generateDecisionsFromColumnParameter);
			var decisionalColumnMetaPathParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e842c411-a194-41b8-8520-bc517224cd01"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(decisionalColumnMetaPathParameter);
			var resultParameterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d6313c1e-3152-439f-88a5-ca4f5b397ee8"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("ed2ab973-7009-4a0c-bc37-6e4eaa3450bd"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("5f81e72e-7cb6-4775-b4ef-709235e30ef2"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				Value = @"Назначить ответственного по продаже",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("e825034b-3779-4c1e-aa88-08a25cddf922"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("79b71a16-363b-4270-804f-96c0266a9226"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("49fc1967-693a-4c7c-a90b-ff57e9609483"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("15acbe32-9e04-4bda-813f-0dbf7140366e"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fac6a98d-6e1f-4791-90ff-6388fd5c7dfa"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("52348b4d-d057-423b-bbd2-b27ffdcb31b7"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ac12bebe-1559-4b69-be65-0ec920c26ed8"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				Value = @"5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1163d8da-f734-4ad7-824c-da7bd888483c"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("09e933cd-ec8e-464b-aa57-a0653129c148"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e108111b-f473-4ec3-ac71-171a7e932396"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("c5cbdcb1-8456-4d6c-a2a3-efde611f3db8"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("8727b23d-8ab9-43de-adcf-b6411baf04bf"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{219dc79c-3bc4-48da-b5b7-90defe1aec40}].[Parameter:{40333f27-6073-4fdf-8195-0a76448c3050}].[EntityColumn:{4b95e3ff-fd52-4ae1-b0a5-2c5103ff15a7}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("701b6be8-7bde-4ddc-a8ea-05d5e3a6f32b"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{219dc79c-3bc4-48da-b5b7-90defe1aec40}].[Parameter:{40333f27-6073-4fdf-8195-0a76448c3050}].[EntityColumn:{64a05bfa-350d-4dbf-bfd8-fb579a74f39e}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("070365fb-e8d5-49f1-a71d-933a82563693"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{4c6e9a6c-52a3-4f25-879f-96941c1aa349}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(opportunityParameter);
			var invoiceParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				UId = new Guid("798646c0-f074-4300-a2d7-73558f4302b8"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("97e1828c-89e8-4b30-a736-129257a18787"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("dc76bc3f-26e8-4e12-99eb-06875b580140"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("10863539-42e3-4ec9-a0e1-93835649f96f"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("ed45b44a-4ef2-4090-a7d6-d660ff6794df"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("4dddec06-0b54-4279-b578-5adbd29937de"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("9dea1cae-603b-480e-91b9-2cedc8043fe3"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("396ca1cb-2a2c-47c0-9bce-7f8d32e2948e"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("d8194d6c-dcc9-4b4e-a9d6-3d49314e8e98"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(pageTypeUIdParameter);
			var activitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0c84cdb3-00ef-43ef-8ec5-929ab4936120"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("265cd111-1e70-4cac-83ae-bf14d2756bb9"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("2d1fa997-5890-44a6-8b5f-864795599deb"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("69814e7a-c257-4df5-bec5-ce4565034b2d"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("862b6225-5967-4969-9fd9-8c8e79df20c0"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("ead44738-c37f-4ac5-b25e-4cbcd2ae893b"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("b0849d2a-bce7-43f8-beb1-fa2c375357ac"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("d7450c11-e4da-4c5a-96e1-fbcb7ea94867"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("c54f578d-a593-499f-a846-b08a7bd3ca7b"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("40753f3d-3149-4919-9649-169e2c608b25"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("54a12540-bcb5-4fb7-b795-3cc857cd0d72"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("43a7025f-f4e3-4c4a-97d2-432e99f32840"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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
				UId = new Guid("60b6c6a3-3e7f-4b68-8cab-362be6a4d16a"),
				ContainerUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
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

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6f986137-04cb-4983-b7b0-54ae0cf8a109"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,187,142,212,48,20,253,21,228,130,42,70,137,237,56,113,40,71,3,218,102,89,137,5,33,237,142,86,55,246,205,142,165,60,102,19,71,236,42,26,9,137,138,138,127,224,11,166,0,10,10,248,133,204,31,225,76,118,64,218,2,81,208,32,185,176,175,125,206,61,231,232,122,184,178,221,51,91,58,108,179,2,202,14,131,254,196,100,36,14,115,197,67,140,41,36,90,80,17,169,148,66,152,231,148,73,64,35,140,140,194,84,147,160,134,10,51,50,163,151,198,58,18,88,135,85,151,93,12,191,73,93,219,99,112,85,28,14,47,245,26,43,120,53,53,0,20,178,200,211,132,234,144,105,42,0,125,3,195,35,10,138,113,109,140,82,66,23,100,214,130,154,177,84,161,164,156,9,73,5,38,154,66,26,33,205,19,169,153,100,33,75,18,70,130,18,11,183,188,221,180,216,117,182,169,179,1,127,237,207,239,54,94,229,220,123,209,148,125,85,147,160,66,7,103,224,214,147,144,16,69,172,129,106,161,98,42,10,76,40,112,101,40,135,60,97,73,138,145,140,18,18,104,216,184,137,150,156,24,18,24,112,240,26,202,30,15,204,131,245,26,25,15,163,52,150,30,27,113,111,135,179,144,166,210,187,43,140,44,20,114,169,84,110,142,121,61,239,173,223,219,238,180,175,176,181,250,62,118,244,249,53,109,54,232,166,118,109,83,78,212,167,135,231,231,120,235,230,112,239,175,222,204,134,156,175,79,32,178,13,250,14,23,165,197,218,45,107,221,24,91,95,207,156,219,173,135,84,27,104,109,119,76,97,121,211,67,73,130,214,94,175,255,152,214,162,239,92,83,253,71,86,3,111,211,115,248,33,59,200,157,102,208,216,110,83,194,221,225,156,145,199,55,125,227,158,142,159,198,47,227,183,253,251,253,135,113,183,255,248,104,252,177,127,55,126,31,63,143,187,241,235,184,155,159,144,7,84,25,185,36,66,75,84,32,53,141,25,112,63,36,44,166,105,162,10,170,164,18,145,142,0,184,80,151,196,203,251,151,77,47,78,186,23,111,235,227,175,153,125,174,158,248,234,131,194,217,17,153,13,127,163,115,187,154,148,174,182,126,253,4,58,34,155,168,252,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9ead078e-f887-43ca-a04e-d8ce3a1ce902"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3f155961-0b7c-488a-ad58-3d3edf964358"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("97f729d1-9c97-41b7-807b-90a33d51655e"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("36f4066e-90fc-4fdb-9746-c383e7463ec7"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("05e54116-4bc1-4945-ba99-e9e2dc05d937"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e6227e17-dc85-4e02-837c-e9990987d128"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,11,201,44,201,73,181,50,180,50,212,241,76,177,50,176,50,0,0,169,240,29,88,16,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("40333f27-6073-4fdf-8195-0a76448c3050"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0bfa05ed-5c32-4321-830d-fdf5729623fc"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7072dcc2-6391-4ac4-90c5-03e41d350032"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("158d4a9d-89ef-4cff-94d2-a1d2c46119d9"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5c5148f8-73c6-4e66-9f88-0776da38ac4a"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5306de25-557e-4d14-ab0d-61ef40ef14f7"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7088c4df-1695-4ef3-bc05-566678b8b453"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("51c42171-ea97-42a6-86d6-748585c8132e"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("225571a2-2754-47d9-8903-bcf25cb22132"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ac7c66ef-d757-43a3-b7c8-3172e4cf1bf7"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("871dd3a4-acb8-4449-a993-dc43792a5fb9"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("77dcb533-0081-4f70-894c-b35e0c724c1f"),
				ContainerUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeChangeAdminRightsUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c0fec3ae-801f-45d1-9ef1-f5d96f2e507e"),
				ContainerUId = new Guid("3d527ad4-f295-4b8c-a9d8-5bd27c06dc5c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"25d7c1ab-1de0-4501-b402-02e0e5a72d6e",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("219973db-f3e9-415f-9801-d02ea613c197"),
				ContainerUId = new Guid("3d527ad4-f295-4b8c-a9d8-5bd27c06dc5c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,205,110,212,48,16,126,149,149,15,156,226,85,156,56,113,18,142,213,130,122,41,149,40,8,169,173,42,199,118,218,72,249,217,110,28,209,106,181,210,182,72,72,136,194,3,112,225,200,181,20,10,219,150,150,87,112,222,136,73,210,5,169,7,212,43,66,138,20,207,120,190,111,60,243,141,61,221,73,171,71,105,166,213,36,74,120,86,41,171,94,149,17,34,73,236,198,129,231,96,197,105,136,41,21,33,230,220,97,216,247,24,117,220,128,216,50,8,144,85,240,92,69,168,71,143,100,170,145,149,106,149,87,209,230,244,15,169,158,212,202,218,73,58,227,169,216,83,57,127,214,38,112,60,201,4,225,49,38,82,217,152,122,54,193,49,181,29,108,59,202,86,30,103,142,244,21,234,207,226,122,132,57,196,113,176,79,98,138,169,205,32,212,11,56,38,132,83,69,93,22,122,20,206,146,169,68,143,14,198,19,85,85,105,89,68,83,245,123,189,113,56,134,83,246,185,87,202,172,206,11,100,229,74,243,117,174,247,34,196,33,31,245,4,199,130,134,30,166,137,98,152,187,161,196,46,143,153,195,2,69,124,194,144,37,248,88,183,180,104,85,34,75,114,205,159,243,172,86,29,243,52,109,203,113,109,18,120,62,96,137,43,48,117,29,27,7,126,192,112,34,253,36,84,174,31,134,177,92,246,235,113,157,194,58,173,214,234,92,77,82,113,219,118,5,253,43,39,209,84,148,133,158,148,89,75,189,214,133,111,168,3,221,55,247,118,235,69,95,144,6,127,11,66,51,171,174,212,74,150,170,66,143,10,81,202,180,216,237,57,103,51,128,228,99,62,73,171,101,23,70,251,53,207,144,53,73,119,247,254,218,173,149,186,210,101,254,15,149,106,65,153,192,1,67,214,29,183,157,65,153,86,227,140,31,118,118,132,30,236,215,165,126,104,62,153,69,115,108,78,155,227,230,100,96,190,154,83,115,109,174,155,183,230,124,96,126,54,115,115,211,185,190,153,5,152,230,166,57,50,87,237,206,25,4,124,6,115,110,78,7,240,59,54,103,230,28,8,142,250,85,203,0,192,47,230,102,104,62,194,198,188,139,191,24,52,239,90,180,249,209,70,52,199,3,240,159,155,239,205,43,115,213,156,0,112,209,204,155,87,205,251,230,13,120,47,6,230,18,24,174,186,248,203,230,181,89,152,197,208,124,0,23,0,219,172,64,222,145,244,53,160,59,181,70,104,11,9,230,198,158,107,39,88,218,33,193,84,74,16,37,22,14,14,93,193,152,76,66,33,28,123,200,193,224,156,10,236,197,73,12,202,217,10,70,157,187,24,212,115,2,63,161,76,248,100,72,227,208,83,110,146,128,158,112,253,41,87,112,219,108,238,97,71,120,196,6,63,129,203,185,133,64,137,255,170,191,155,171,213,147,151,197,242,5,235,103,110,123,8,222,59,142,81,166,114,24,78,152,237,123,8,50,3,192,250,50,85,52,189,143,60,45,100,84,232,84,31,246,47,89,52,189,143,94,179,237,86,177,237,25,124,191,0,0,155,104,247,239,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var deleteRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bc07c289-1319-4c29-92d4-aebdf026812e"),
				ContainerUId = new Guid("3d527ad4-f295-4b8c-a9d8-5bd27c06dc5c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DeleteRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			deleteRightsParameter.SourceValue = new ProcessSchemaParameterValue(deleteRightsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,142,5,0,41,187,76,13,2,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(deleteRightsParameter);
			var addRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d3292ff8-7bbd-45cb-a9ee-cb83ff795d43"),
				ContainerUId = new Guid("3d527ad4-f295-4b8c-a9d8-5bd27c06dc5c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"AddRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			addRightsParameter.SourceValue = new ProcessSchemaParameterValue(addRightsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,193,106,219,64,16,253,21,161,92,189,70,210,174,36,75,215,212,148,64,105,74,2,189,24,31,86,187,179,141,65,146,131,178,110,9,198,224,56,80,40,77,251,9,237,177,87,55,173,91,37,110,220,95,152,253,163,142,28,232,161,244,180,243,222,188,247,134,153,29,205,143,116,238,235,2,68,0,160,152,202,180,98,34,202,128,73,21,10,150,25,25,38,58,141,66,29,114,191,119,40,235,19,144,58,183,205,12,58,48,212,19,251,23,60,129,18,44,228,70,150,23,208,59,157,206,26,5,185,79,166,167,141,172,45,80,61,172,206,203,233,37,128,223,123,46,43,194,163,3,252,130,173,91,225,218,173,220,141,135,223,113,141,15,248,224,222,227,198,195,223,110,137,187,61,245,3,91,130,184,115,87,184,237,58,183,36,248,74,112,137,107,143,158,21,222,226,134,2,174,30,171,46,129,140,223,112,215,199,207,212,88,238,245,119,158,251,208,185,241,87,167,112,43,143,248,13,254,116,215,184,117,55,100,108,221,210,93,187,143,238,29,177,119,30,222,83,194,118,175,191,119,111,177,197,182,143,159,254,55,168,75,62,24,251,189,151,178,156,237,23,26,29,93,28,191,169,161,57,85,103,80,201,199,91,140,251,196,254,67,12,75,168,160,182,249,92,165,188,136,121,96,152,14,178,144,9,173,3,54,40,84,196,50,174,210,84,155,76,169,40,88,144,225,133,108,232,102,22,154,124,46,169,37,165,80,44,46,76,193,4,15,232,171,184,228,44,25,164,209,32,49,34,85,73,216,89,134,181,157,216,203,195,105,57,171,234,124,158,12,68,28,115,153,50,25,103,154,137,196,72,38,141,40,152,81,105,2,153,1,158,100,98,49,238,150,57,62,135,70,218,201,180,62,153,188,58,179,207,224,53,148,185,31,250,139,241,31,75,83,224,195,42,2,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(addRightsParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cb97cbfa-8808-4c7f-bb23-d492c52addfa"),
				ContainerUId = new Guid("3d527ad4-f295-4b8c-a9d8-5bd27c06dc5c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
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
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
			var employee1Parameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("dbe40eec-c9dc-429e-ac14-9fa16d721d13"),
				ContainerUId = new Guid("3d527ad4-f295-4b8c-a9d8-5bd27c06dc5c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"Employee1",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			employee1Parameter.SourceValue = new ProcessSchemaParameterValue(employee1Parameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c73b530f-d091-4dd0-8bc2-93c77df9cc20}].[Parameter:{a3c7aa4c-5bfb-430e-a3a3-687286f47c61}].[EntityColumn:{684553a7-a59d-46fa-af4b-fc76e9fe3694}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(employee1Parameter);
		}

		protected virtual void InitializeChangeAdminRightsUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4e965dc3-d0a7-4e19-90e1-c7cbf2fc0ab5"),
				ContainerUId = new Guid("fc62fa4b-52eb-4eaa-ad02-5b1dfefe4d77"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"ae46fb87-c02c-4ae8-ad31-a923cdd994cf",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f82856dc-9a64-4a0c-9fb8-9535d9d36049"),
				ContainerUId = new Guid("fc62fa4b-52eb-4eaa-ad02-5b1dfefe4d77"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,93,107,212,64,20,253,43,75,30,124,202,44,201,36,217,236,196,199,186,130,32,42,88,69,144,82,110,102,238,180,193,124,172,249,64,203,178,80,43,8,98,245,7,248,226,163,175,126,85,215,86,235,95,152,252,35,111,146,174,138,136,244,85,132,64,230,222,153,115,114,239,61,39,179,216,78,170,203,73,90,99,25,105,72,43,180,155,43,42,178,98,151,79,81,196,192,100,16,2,243,133,64,54,149,74,50,49,9,20,162,231,114,25,186,150,157,67,134,145,53,160,103,42,169,45,59,169,49,171,162,187,139,159,164,117,217,160,189,173,251,224,166,220,197,12,110,117,31,0,244,39,58,158,134,76,58,92,50,31,112,202,64,121,46,3,193,61,169,148,16,190,212,214,80,139,4,224,33,215,156,197,190,167,152,143,177,98,2,99,206,66,63,230,60,22,10,136,193,178,235,50,201,46,65,141,155,73,134,55,160,164,202,232,131,155,69,151,26,106,72,81,215,179,135,243,18,171,42,41,242,104,129,63,214,155,123,115,106,99,40,110,163,72,155,44,183,108,130,195,13,168,119,35,203,143,69,128,158,214,76,171,128,119,149,186,44,118,32,96,92,6,174,67,121,55,128,208,178,37,204,235,142,214,50,47,205,169,249,218,30,180,251,230,141,121,111,142,186,181,101,151,168,177,196,92,226,47,35,224,129,10,165,11,49,115,21,58,204,15,28,34,246,29,206,28,142,14,18,41,87,19,180,108,5,53,220,134,180,193,190,202,69,210,137,195,69,224,132,174,102,33,130,160,129,76,56,155,42,23,152,112,69,172,189,208,227,90,243,181,56,87,139,226,94,51,39,97,170,107,77,134,101,34,207,84,70,146,171,40,163,133,44,242,186,44,210,142,252,218,47,128,65,205,179,205,59,195,128,210,126,167,3,90,75,187,169,112,35,77,48,175,103,185,44,84,146,239,244,67,94,46,9,147,205,161,76,170,245,88,103,247,27,72,105,0,201,206,238,95,199,191,209,84,117,145,253,107,253,218,243,181,213,250,154,59,235,171,164,154,167,176,215,199,145,117,225,126,83,212,23,205,107,179,106,15,204,27,178,197,225,200,124,32,103,124,37,95,60,51,71,35,243,141,140,114,218,167,62,154,21,133,230,180,125,100,78,186,157,119,116,224,45,133,100,164,17,189,14,204,59,115,68,4,143,134,85,199,64,192,247,230,116,108,94,209,198,126,127,254,243,168,125,222,161,205,151,193,121,35,202,31,153,79,237,99,115,210,30,18,112,213,238,183,143,219,23,237,83,202,126,30,153,99,98,56,233,207,31,183,79,204,202,172,198,127,178,239,208,131,245,91,175,235,222,100,232,197,129,231,104,166,28,225,50,95,41,135,77,99,201,153,240,100,24,42,45,164,228,206,24,40,0,240,37,11,98,29,51,223,115,144,129,7,30,155,76,67,62,157,104,63,148,19,119,124,158,63,237,172,150,165,253,223,205,249,238,149,234,250,131,124,125,137,14,182,222,26,83,246,183,196,44,197,140,124,74,86,63,135,48,75,2,252,184,45,163,197,121,100,234,32,179,188,78,234,189,225,174,140,22,231,209,109,185,181,86,110,107,73,207,119,113,141,185,55,118,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var deleteRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1231ae80-ee39-4ea7-b240-5e40eeb4c9d1"),
				ContainerUId = new Guid("fc62fa4b-52eb-4eaa-ad02-5b1dfefe4d77"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DeleteRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			deleteRightsParameter.SourceValue = new ProcessSchemaParameterValue(deleteRightsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,142,5,0,41,187,76,13,2,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(deleteRightsParameter);
			var addRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("53a4af30-14e3-43b5-8ef1-88f2cf3a040f"),
				ContainerUId = new Guid("fc62fa4b-52eb-4eaa-ad02-5b1dfefe4d77"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"AddRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			addRightsParameter.SourceValue = new ProcessSchemaParameterValue(addRightsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,77,111,211,64,16,253,43,150,123,205,70,78,118,253,177,190,150,8,85,66,20,181,18,151,40,135,241,122,150,70,178,157,202,221,128,170,40,82,154,74,72,136,194,79,128,35,215,80,8,184,13,13,127,97,246,31,177,118,57,33,78,59,239,205,123,111,53,51,227,197,81,158,250,74,65,18,134,34,99,10,180,102,66,14,129,201,72,2,139,18,25,107,45,121,36,226,196,239,29,66,117,130,144,167,166,158,99,11,70,249,212,164,26,138,139,14,61,193,2,13,254,197,167,179,121,173,48,245,185,223,123,90,67,101,208,213,163,242,188,152,93,34,250,189,231,80,58,60,62,160,47,212,216,53,109,236,218,222,120,244,157,54,244,64,15,246,61,109,61,250,109,87,180,239,168,31,212,56,72,123,123,69,187,182,115,235,4,95,29,92,209,198,115,207,154,110,105,235,2,174,30,171,54,193,25,191,209,190,79,159,93,99,213,233,239,60,251,161,117,211,175,86,97,215,158,227,183,244,211,94,211,206,222,56,99,99,87,246,218,126,180,239,28,123,231,209,189,75,216,117,250,123,251,150,26,106,250,244,233,127,31,181,201,7,19,191,247,18,138,121,55,208,248,232,226,248,77,133,245,169,58,195,18,30,119,49,233,59,246,31,98,84,96,137,149,73,23,42,230,89,200,3,205,242,64,14,152,200,243,128,37,153,26,50,201,85,28,231,90,42,53,12,150,206,240,2,106,183,51,131,117,186,0,215,2,16,138,133,153,206,152,224,1,50,224,192,221,173,226,97,18,105,17,171,104,208,90,70,149,153,154,203,195,89,49,47,171,116,17,37,34,12,57,196,12,66,153,51,17,105,96,160,221,193,181,138,35,148,26,121,36,197,114,210,14,115,124,142,53,152,233,172,58,153,190,58,51,207,240,53,22,169,63,240,151,147,63,236,126,43,164,43,2,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(addRightsParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("78cc3f50-c40f-4cfa-9481-79259b9ce64b"),
				ContainerUId = new Guid("fc62fa4b-52eb-4eaa-ad02-5b1dfefe4d77"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
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
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
			var employee1Parameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("cca8554b-caff-492a-969a-6897ff936478"),
				ContainerUId = new Guid("fc62fa4b-52eb-4eaa-ad02-5b1dfefe4d77"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"Employee1",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			employee1Parameter.SourceValue = new ProcessSchemaParameterValue(employee1Parameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c73b530f-d091-4dd0-8bc2-93c77df9cc20}].[Parameter:{a3c7aa4c-5bfb-430e-a3a3-687286f47c61}].[EntityColumn:{684553a7-a59d-46fa-af4b-fc76e9fe3694}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(employee1Parameter);
		}

		protected virtual void InitializeIntermediateCatchSignalEvent1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("09cca40d-6c18-48f7-9457-13734419af29"),
				ContainerUId = new Guid("b0a72e82-9fc1-437a-ae75-2166804d3791"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0a72e82-9fc1-437a-ae75-2166804d3791"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{4c6e9a6c-52a3-4f25-879f-96941c1aa349}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeReadDataUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6ae9a99b-d2db-4a58-b211-f6e962641886"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,110,212,48,20,253,21,228,5,171,24,197,177,227,196,97,57,26,80,55,165,18,5,33,181,85,117,99,95,119,44,229,49,77,28,209,106,52,18,18,43,86,252,3,95,208,5,176,96,1,191,144,249,35,156,73,7,164,46,16,11,54,72,94,216,215,62,231,158,115,116,189,185,116,253,51,87,121,236,10,11,85,143,209,112,100,10,82,106,133,12,68,78,75,147,49,42,20,72,90,50,193,40,170,24,65,10,155,91,43,72,212,64,141,5,153,209,75,227,60,137,156,199,186,47,206,54,191,73,125,55,96,116,105,247,135,151,122,133,53,188,154,26,0,10,105,203,60,163,58,78,52,21,128,57,5,195,25,5,149,112,109,140,82,66,91,50,107,145,105,12,57,43,21,21,105,82,82,33,57,167,42,53,134,198,165,205,164,204,153,86,150,147,168,66,235,151,55,235,14,251,222,181,77,177,193,95,251,211,219,117,80,57,247,94,180,213,80,55,36,170,209,195,9,248,213,36,36,70,145,106,160,90,168,148,10,139,25,5,174,12,229,80,102,73,150,35,147,44,35,145,134,181,159,104,201,145,33,145,1,15,175,161,26,112,207,188,113,65,99,194,99,150,167,50,96,25,15,118,120,18,211,92,6,119,214,72,171,144,75,165,74,115,200,235,249,224,194,222,245,199,67,141,157,211,247,177,99,200,175,237,138,141,110,27,223,181,213,68,125,188,127,126,138,55,126,14,247,254,234,205,108,200,135,250,4,34,219,104,232,113,81,57,108,252,178,209,173,113,205,213,204,185,221,6,72,189,134,206,245,135,20,150,215,3,84,36,234,220,213,234,143,105,45,134,222,183,245,127,100,53,10,54,3,71,24,178,189,220,105,6,141,235,215,21,220,238,207,5,121,124,61,180,254,233,248,105,252,50,126,219,189,223,125,24,239,118,31,31,141,63,118,239,198,239,227,231,241,110,252,58,222,205,79,200,3,170,130,156,19,161,37,134,63,160,105,154,0,15,67,146,164,52,207,148,165,74,42,193,52,3,224,66,157,147,32,239,95,54,61,59,234,95,188,109,14,191,102,246,121,241,36,84,31,20,78,14,200,98,243,55,58,183,23,147,210,139,109,88,63,1,248,210,33,144,252,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8f241b16-53a3-4a3f-bca5-3fb01c76cdd9"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("feb5fafe-ddb7-4fe9-b154-6aef4a84a2cf"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dee4a26d-9bf8-4814-aeaa-2079ae11751d"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b36aaeec-e9e9-4b97-83b4-c930ade9d221"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("93823506-41d3-455a-be79-cd11bd04d813"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6f281dc6-1639-492d-b3a7-91eea3ca365f"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,9,201,44,201,73,181,50,180,50,4,0,57,183,224,50,16,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("a3c7aa4c-5bfb-430e-a3a3-687286f47c61"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("08fb2ebc-49a5-4226-98ba-39f6038c9c60"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("1fb6d738-110a-43fc-b8d1-6ad1b87f1781"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f96019c2-3d7b-4c65-af7c-00f7360fdef1"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("607243ca-d4f9-4326-ba0d-63444eb5120f"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5eef0b4b-0874-4d83-bc5e-5cd3703dc83e"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("960b87b1-7cf1-4c07-9505-dcda4ff83c63"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("32c63487-e6c1-47ec-90de-78ac92f5bc30"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8633d044-d682-4d53-abc5-2ebe81cc2939"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a147c744-f32b-48b9-a6b4-71a9270154db"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e9467ebf-a34b-47f7-b8bd-c50966de3734"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6981ba7b-3378-488d-9bc5-36c590b26b7f"),
				ContainerUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("113f4e62-765c-44d4-8ae1-58cf9d82d61f"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,85,93,107,220,70,20,253,43,139,30,250,164,49,243,41,105,212,71,179,45,134,226,6,154,150,66,98,194,124,198,162,90,105,179,146,104,204,178,16,28,8,148,166,249,7,161,125,235,171,49,217,212,137,235,230,47,140,254,81,174,164,108,27,130,91,220,210,151,60,72,104,238,204,61,115,239,153,51,71,235,123,69,243,89,81,182,110,149,123,85,54,46,238,14,108,30,101,2,167,216,99,134,36,150,28,241,44,51,72,121,226,144,161,150,26,202,76,150,10,29,197,149,90,184,60,154,178,231,182,104,163,184,104,221,162,201,239,172,255,2,109,87,157,139,239,249,113,240,149,57,118,11,245,245,176,129,176,25,23,137,230,136,8,135,17,183,78,32,141,225,165,188,38,216,39,169,20,6,71,83,45,86,178,196,75,1,11,140,149,136,39,84,35,197,177,70,150,43,194,24,209,41,22,36,138,75,231,219,249,195,229,202,53,77,81,87,249,218,253,249,125,251,100,9,85,78,123,239,215,101,183,168,162,120,225,90,117,75,181,199,121,164,28,118,92,24,133,12,151,2,113,239,82,164,152,180,136,41,157,210,52,115,36,33,105,20,27,181,108,7,216,232,192,70,177,85,173,250,70,149,157,27,145,215,5,212,72,25,38,153,72,32,151,48,131,56,163,24,101,73,150,34,111,161,116,199,18,41,181,221,241,245,121,87,192,119,209,28,118,11,183,42,204,59,218,29,240,87,175,242,181,169,171,118,85,151,3,244,225,184,252,182,123,216,78,228,190,155,250,118,106,168,133,248,144,20,109,226,174,113,251,101,225,170,118,94,153,218,22,213,253,9,115,179,129,148,197,82,173,138,102,199,194,252,65,167,202,40,94,21,247,143,255,145,173,253,174,105,235,197,71,212,106,12,109,2,6,136,108,44,119,208,160,45,154,101,169,78,198,113,30,125,242,160,171,219,79,195,175,225,162,63,13,103,253,105,255,116,22,94,132,179,112,21,174,250,31,195,118,22,222,244,143,194,31,99,232,101,184,216,11,63,135,45,4,206,97,238,213,172,255,41,92,134,109,248,29,158,171,254,116,6,241,109,248,173,127,28,46,251,167,0,118,209,63,234,31,247,207,250,31,32,250,106,22,94,3,202,229,184,254,117,255,36,92,12,88,207,1,116,128,63,11,231,227,196,21,132,183,83,65,209,7,133,231,209,221,136,18,105,77,42,13,98,218,12,151,207,42,164,133,78,225,46,90,231,29,81,206,112,188,199,49,99,204,211,20,37,56,101,160,91,235,81,70,64,193,88,165,9,231,153,97,88,224,61,34,60,220,98,73,144,75,18,143,56,181,26,101,56,213,200,115,67,149,77,24,75,117,114,55,2,90,63,94,178,238,28,52,95,126,95,237,188,101,82,195,209,30,68,63,8,204,75,183,0,217,228,235,155,176,187,129,132,91,187,173,242,245,77,184,30,82,230,85,91,180,39,147,199,228,235,155,144,191,57,26,232,63,130,155,250,191,90,38,163,212,40,66,19,196,37,131,30,141,181,72,89,227,144,227,169,17,148,131,125,103,246,191,91,166,19,154,122,109,36,98,146,129,33,51,75,81,198,57,67,74,9,35,117,150,48,42,216,123,150,25,126,129,211,31,14,250,124,148,204,32,169,237,160,6,176,33,32,124,229,42,227,222,235,146,36,26,76,68,16,148,121,71,17,39,66,162,204,90,140,84,134,153,229,73,198,172,5,240,107,124,73,83,9,63,45,226,81,234,20,84,229,18,168,202,18,133,36,145,218,179,148,81,239,233,206,151,190,168,235,239,186,229,191,112,166,41,225,58,111,42,199,153,191,117,167,225,44,175,241,225,131,230,176,110,15,187,178,28,14,255,45,180,231,107,154,131,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("081ada6f-f2ec-42a9-9282-5b3d9c407f55"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("50975cf4-f986-42be-848f-f2dbab118fa5"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8e5ac671-36f1-474e-9cff-66a8407b8fa5"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e0169671-eb4f-4762-b6a3-191c60062fb3"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("19d5393e-631c-4edd-b20b-b75111f8c70b"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0498e93f-e38c-409f-a4b4-8d6ca4869331"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				UId = new Guid("b2e51ef1-6aab-4ca1-8848-6008a8d519a5"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1e00e7f8-aeee-4b21-a00c-23045ba60e93"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("bf8fa2bb-6f13-45d3-8ac3-1af8add4e2e1"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("b11bba9c-7570-4c91-b5b8-ce0f87f32de9"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("3f45a94b-9b1a-45bc-a1eb-1c63396fd296"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("65beb8a8-7a77-4d89-b41a-5e90a25bf16f"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("70f9d4af-0491-4dd3-bc7e-64f44d775fc3"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				UId = new Guid("02165bd8-27fb-4e68-8dbc-6910d0dd6351"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c018b09d-9be8-4dc0-94a3-6a98bb7f7223"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b90f88bb-6a42-491a-b18c-602ac3087bbb"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ca815e4f-a340-47cc-86d2-101fdc98f3db"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5c02e1cd-d7ab-4435-8468-889e8961de88"),
				ContainerUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeReadDataUserTask4Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a20fbdf2-0724-4878-885a-78691620252b"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,85,93,139,220,54,20,253,43,139,31,250,100,45,146,245,97,203,125,92,166,101,161,108,3,77,75,33,89,130,44,93,101,77,61,227,201,216,166,89,134,129,176,129,64,105,154,127,16,218,183,190,46,75,167,221,100,187,237,95,144,255,81,175,237,76,27,194,182,108,75,95,242,96,99,93,233,30,93,29,157,123,188,126,80,54,31,149,85,11,171,220,155,170,129,184,59,116,121,148,122,199,52,72,75,82,237,56,17,210,56,98,168,74,137,245,66,112,48,134,75,11,81,188,48,115,200,163,41,123,230,202,54,138,203,22,230,77,126,111,253,23,104,187,234,32,126,224,199,193,103,246,4,230,230,243,97,3,233,50,33,85,33,8,147,64,137,112,32,73,65,241,101,124,193,168,87,169,150,150,70,83,45,78,42,97,185,183,68,130,22,68,80,203,73,102,173,37,58,161,62,179,156,38,66,164,81,92,129,111,103,143,151,43,104,154,178,94,228,107,248,243,251,238,233,18,171,156,246,62,168,171,110,190,136,226,57,180,230,142,105,79,242,200,0,5,33,173,33,86,104,73,132,135,148,24,174,29,225,166,72,147,52,3,166,24,162,91,179,108,7,216,232,208,69,177,51,173,249,194,84,29,140,200,235,18,107,76,56,101,153,68,130,12,227,150,8,158,80,146,169,44,37,222,41,175,129,43,173,11,183,227,235,227,174,196,239,178,57,234,230,176,42,237,27,218,1,249,171,87,249,218,214,139,118,85,87,3,244,209,184,252,46,60,110,39,114,223,76,125,57,29,168,197,248,144,20,109,226,174,129,131,170,132,69,59,91,216,218,149,139,135,19,230,102,131,41,243,165,89,149,205,142,133,217,163,206,84,81,188,42,31,158,252,35,91,7,93,211,214,243,247,232,168,49,30,19,49,80,100,99,185,131,6,93,217,44,43,115,58,142,243,232,131,71,93,221,126,24,126,12,151,253,89,56,239,207,250,231,123,225,167,112,30,174,195,117,255,109,216,238,133,223,251,39,225,183,49,244,115,184,220,15,223,135,45,6,46,112,238,213,94,255,93,184,10,219,240,43,62,215,253,217,30,198,183,225,151,254,105,184,234,159,35,216,101,255,164,127,218,191,232,191,193,232,171,189,240,26,81,174,198,245,175,251,103,225,114,192,122,137,160,3,252,121,184,24,39,174,49,188,157,10,138,222,41,60,143,238,71,9,211,206,166,218,18,94,88,20,124,230,12,41,100,145,18,77,29,120,96,6,172,160,251,130,114,206,125,146,18,69,83,236,80,239,60,201,24,42,152,154,84,9,49,244,133,164,251,76,122,234,169,102,4,148,242,68,36,174,32,25,77,11,226,133,77,140,83,156,167,133,186,31,33,173,239,47,89,247,14,155,79,191,94,236,188,101,82,195,241,62,70,223,9,204,42,152,163,108,242,245,109,216,221,96,194,157,221,86,249,250,54,92,15,41,179,69,91,182,167,147,199,228,235,219,144,191,57,30,232,63,198,78,253,95,45,147,89,203,10,165,0,157,155,41,236,81,151,224,42,159,17,199,65,102,222,21,218,121,248,239,150,9,178,72,124,97,53,225,154,235,9,61,195,223,2,49,70,90,93,100,138,39,146,191,101,153,225,7,188,253,225,162,47,70,201,12,146,218,14,106,64,27,66,194,87,176,176,240,214,41,153,42,208,68,36,35,153,135,132,8,38,53,201,156,163,196,100,148,59,161,50,238,28,130,223,224,75,69,162,37,77,153,39,41,24,172,10,20,86,229,152,33,154,233,194,243,148,39,222,39,59,95,250,164,174,191,234,150,255,194,153,166,132,155,188,169,26,103,254,214,157,134,187,188,193,135,15,155,163,186,61,234,170,106,184,252,63,0,69,24,50,65,131,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("27339781-38b3-4487-9014-db0a37f14b83"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4521de8c-08bc-444c-b658-6c4d2a4e5fe3"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7d343aa0-5460-4284-979f-8f5994a7d42b"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e1b48494-ddbb-473b-a958-1051eee1f98a"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("70780388-abf3-42af-893d-f28adb4649e9"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("aec5d8f1-c2e7-4e32-a7c0-04acfef39267"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,75,204,77,181,50,180,50,4,0,203,8,241,43,15,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				UId = new Guid("bee4631c-fc60-4367-b698-697143c1db86"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a3bc60f3-2c39-4535-b598-fbd578d70e3e"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("abc3c14b-0934-40d2-bbe4-d7850d2fbf68"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("769bd711-c503-449a-b51c-4a46a32185a4"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("3f93d92a-65c1-4d5d-a345-d590032b6d6f"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4c78f474-685f-4529-81f4-9021f679a821"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("092e4b03-f419-48ef-a4be-8468d71225ed"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				UId = new Guid("e799395e-b3b7-458a-83af-8462a0ee992e"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5e3110b5-1123-4cb7-b152-accafabe8138"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3dd48f20-8cf8-49bb-802a-23fa55d6001d"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0ff80e34-e72a-4579-be2d-eca0480b8ab0"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d7fc461a-30e7-48fe-ae22-a0dfd9543c3b"),
				ContainerUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeChangeAdminRightsUserTask3Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e7f3928e-a4d5-465d-bbc7-a71f81fc3a25"),
				ContainerUId = new Guid("9953d48c-257d-4ca8-84fc-cae371581aa3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"16be3651-8fe2-4159-8dd0-a803d4683dd3",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5a649550-03e1-4b0f-bc8c-d2de65fc0b09"),
				ContainerUId = new Guid("9953d48c-257d-4ca8-84fc-cae371581aa3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,219,106,212,64,24,126,149,101,46,188,202,44,73,38,135,73,188,44,171,244,166,22,172,34,180,165,204,41,109,32,135,237,102,130,45,203,66,187,130,32,86,31,192,27,47,189,173,213,234,182,181,245,21,38,111,228,159,164,171,208,11,233,173,8,129,204,127,248,190,249,143,51,221,73,171,71,105,166,213,36,78,88,86,41,171,94,149,49,242,35,215,119,2,194,177,227,217,1,246,66,161,48,83,129,194,174,27,209,72,168,144,114,158,32,171,96,185,138,81,143,30,201,84,35,43,213,42,175,226,205,233,31,82,61,169,149,181,147,116,194,83,177,167,114,246,172,189,192,9,184,34,129,239,96,154,40,23,123,142,31,97,42,165,141,25,181,137,244,2,74,164,36,168,143,69,80,226,115,198,3,76,5,9,33,22,197,49,11,69,136,169,167,124,73,3,201,67,6,174,153,74,244,232,96,60,81,85,149,150,69,60,85,191,207,27,135,99,136,178,191,123,165,204,234,188,64,86,174,52,91,103,122,47,70,76,217,202,243,5,195,194,139,124,236,37,42,196,140,68,18,19,198,67,55,164,202,9,156,16,89,130,141,117,75,139,86,37,178,36,211,236,57,203,106,213,49,79,83,136,209,37,182,67,253,0,176,14,17,216,35,174,141,105,64,67,156,200,32,137,32,209,40,226,114,89,175,199,117,10,231,180,90,171,115,53,73,197,109,217,21,212,175,156,196,83,81,22,122,82,102,45,245,90,231,190,161,14,116,95,220,91,211,139,62,33,13,250,22,132,102,86,93,169,149,44,85,133,30,21,162,148,105,177,219,115,206,102,0,201,199,108,146,86,203,42,140,246,107,150,33,107,146,238,238,253,181,90,43,117,165,203,252,31,74,213,130,52,129,3,134,172,11,183,157,65,153,86,227,140,29,118,114,140,30,236,215,165,126,104,62,153,69,51,55,167,205,188,57,25,152,175,230,212,92,155,235,230,173,57,31,152,159,205,145,185,233,84,223,204,2,68,115,211,28,155,171,214,114,6,14,159,65,60,50,167,3,248,205,205,153,57,7,130,227,254,212,50,0,240,139,185,25,154,143,96,56,234,252,47,6,205,187,22,109,126,180,30,205,124,0,250,115,243,189,121,101,174,154,19,0,46,154,163,230,85,243,190,121,3,218,139,129,185,4,134,171,206,255,178,121,109,22,102,49,52,31,64,5,64,136,231,178,153,247,209,163,59,89,198,104,11,137,144,112,159,216,9,150,118,228,96,175,221,33,202,133,139,35,34,194,80,38,145,16,174,61,100,32,48,230,9,236,243,132,67,207,108,88,103,194,8,134,190,185,52,72,96,191,3,103,24,120,204,6,59,195,196,183,37,48,241,4,243,68,82,156,112,63,140,88,232,37,36,82,91,8,122,240,159,84,118,115,181,122,242,178,88,190,90,253,156,109,15,65,123,71,49,202,84,14,3,9,243,124,143,86,204,0,176,190,188,42,158,222,167,49,45,100,84,232,84,31,246,175,87,60,189,79,167,102,219,109,175,182,103,240,253,2,216,125,249,219,227,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var deleteRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d450dd6d-3502-4a49-93dc-3796f8d6b862"),
				ContainerUId = new Guid("9953d48c-257d-4ca8-84fc-cae371581aa3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DeleteRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			deleteRightsParameter.SourceValue = new ProcessSchemaParameterValue(deleteRightsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,142,5,0,41,187,76,13,2,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(deleteRightsParameter);
			var addRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c573582f-cae6-4f5d-9f77-cddaff23070d"),
				ContainerUId = new Guid("9953d48c-257d-4ca8-84fc-cae371581aa3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"AddRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			addRightsParameter.SourceValue = new ProcessSchemaParameterValue(addRightsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,93,81,193,106,219,64,16,253,21,161,92,181,70,214,202,90,75,215,212,148,64,105,74,2,189,24,31,70,171,217,198,32,201,65,145,91,130,49,56,14,20,74,211,124,64,47,61,246,234,38,113,171,216,141,251,11,179,127,212,145,3,61,244,180,243,222,188,55,187,243,118,56,59,202,18,215,151,105,224,171,46,8,19,196,74,132,25,4,34,14,51,95,104,5,25,66,164,163,46,130,235,29,66,121,130,144,37,117,53,197,22,12,178,113,253,15,188,192,28,107,76,12,228,23,232,157,78,166,149,198,196,149,174,247,178,130,178,70,174,7,197,121,62,185,68,116,189,215,80,48,30,30,208,119,106,236,146,86,118,105,111,28,122,160,21,61,209,147,253,76,107,135,254,216,5,237,246,212,79,106,24,210,206,94,209,182,237,220,177,224,7,195,5,173,28,62,150,116,71,107,30,112,245,92,181,19,216,120,79,187,14,125,227,198,98,175,127,116,236,151,214,77,191,91,133,93,58,204,175,233,151,189,166,173,189,97,99,99,23,246,218,222,218,79,204,62,58,180,225,9,219,189,126,99,63,82,67,77,135,190,50,197,70,126,207,198,46,15,70,174,247,22,242,233,126,137,225,209,197,241,135,18,171,83,125,134,5,60,239,63,234,48,251,31,49,200,177,192,178,78,102,90,201,180,39,125,35,50,63,238,114,214,28,115,63,213,28,184,212,74,101,38,214,58,240,231,108,120,3,21,231,84,99,149,204,128,91,0,161,22,189,212,164,34,148,62,10,144,32,69,212,87,65,63,50,161,226,15,106,45,131,178,30,215,151,135,147,124,90,148,201,44,10,193,103,3,8,217,243,51,190,40,53,34,53,89,95,152,180,167,98,80,161,145,49,206,71,237,50,199,231,88,65,61,158,148,39,227,119,103,245,43,124,143,121,226,118,221,249,232,47,120,191,167,160,30,2,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(addRightsParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("742b13f0-5019-4828-a783-95cecd4e7e00"),
				ContainerUId = new Guid("9953d48c-257d-4ca8-84fc-cae371581aa3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
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
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
			var employee1Parameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("03b2071a-f297-4da2-94d0-c7adea6c61ea"),
				ContainerUId = new Guid("9953d48c-257d-4ca8-84fc-cae371581aa3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"Employee1",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			employee1Parameter.SourceValue = new ProcessSchemaParameterValue(employee1Parameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c73b530f-d091-4dd0-8bc2-93c77df9cc20}].[Parameter:{a3c7aa4c-5bfb-430e-a3a3-687286f47c61}].[EntityColumn:{64a05bfa-350d-4dbf-bfd8-fb579a74f39e}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(employee1Parameter);
		}

		protected virtual void InitializeChangeAdminRightsUserTask4Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c2fd6fee-f1c7-45e7-ac9a-c1ab494df220"),
				ContainerUId = new Guid("bfa78fda-181f-4764-8b3a-2f4b75e455ea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"ae46fb87-c02c-4ae8-ad31-a923cdd994cf",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b7a5464f-131b-4b4c-8a32-1f2138329f44"),
				ContainerUId = new Guid("bfa78fda-181f-4764-8b3a-2f4b75e455ea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,91,107,212,64,20,254,43,75,30,124,202,44,73,38,201,36,241,177,172,80,144,90,240,130,80,74,153,204,165,13,230,178,77,38,104,89,22,182,43,8,98,245,7,248,226,163,175,181,90,221,182,182,254,133,201,63,242,36,233,106,237,131,236,171,8,33,201,57,115,190,115,253,206,76,118,146,234,94,146,42,81,70,146,166,149,48,235,117,30,25,1,243,169,229,197,18,5,22,147,200,117,99,130,40,21,46,242,153,107,73,34,136,237,122,196,48,115,154,137,200,232,209,35,158,40,195,76,148,200,170,104,107,242,219,169,42,107,97,238,200,78,120,200,246,68,70,31,183,1,192,153,47,227,128,32,102,57,12,185,84,4,136,114,108,35,26,58,152,113,30,134,46,147,70,159,11,196,114,28,199,6,43,238,4,200,197,158,141,98,143,192,43,240,165,39,45,91,218,22,54,204,84,72,53,122,49,46,69,85,37,69,30,77,196,175,255,71,7,99,200,178,143,189,86,164,117,150,27,102,38,20,221,164,106,47,50,124,183,43,148,34,236,89,28,66,64,205,177,228,1,146,16,35,164,196,149,56,20,134,201,232,88,181,110,13,253,94,95,233,203,102,174,143,245,121,51,55,204,82,72,81,138,156,137,27,181,217,126,44,176,15,105,6,82,56,200,181,189,16,5,156,91,136,6,22,230,174,31,96,206,33,97,78,21,125,66,211,90,116,249,77,18,0,198,78,232,89,196,150,136,8,26,34,87,248,14,0,109,138,66,59,140,37,38,216,145,210,89,118,253,126,81,60,171,199,208,241,106,163,206,68,153,176,235,241,9,152,67,81,70,19,86,228,170,44,210,214,249,198,13,64,63,166,235,195,167,125,107,210,238,164,5,26,83,179,174,196,90,154,136,92,141,114,86,240,36,223,237,38,56,157,2,38,27,211,50,169,150,13,29,237,215,52,133,6,36,187,123,127,109,252,90,93,169,34,251,215,234,53,161,86,112,3,164,237,114,110,57,205,147,106,156,210,131,78,142,140,59,251,117,161,238,234,143,122,209,146,161,153,55,71,3,253,5,88,113,9,236,120,163,79,7,250,71,51,3,170,180,170,175,122,1,162,190,106,14,245,69,123,114,2,6,159,64,156,233,227,1,124,230,250,68,159,130,131,195,254,175,245,0,192,207,250,106,168,63,192,193,172,179,63,27,52,111,91,180,254,222,90,52,243,1,232,79,245,183,230,165,190,104,142,0,184,104,102,205,203,230,93,243,26,180,103,3,125,14,30,46,58,251,243,230,149,94,232,197,240,79,226,246,217,27,183,170,92,86,197,8,142,61,108,73,196,173,208,134,157,0,238,6,49,115,80,136,25,33,92,134,140,57,214,144,130,64,169,203,16,108,79,12,107,105,9,68,49,197,200,15,136,3,155,233,18,230,219,195,85,182,235,58,151,169,249,31,117,120,107,189,122,240,60,95,222,136,61,149,183,135,160,189,165,24,165,34,3,110,2,189,87,24,201,20,0,155,203,112,209,100,149,1,181,144,81,174,18,117,208,223,140,209,100,149,137,77,183,151,51,219,158,194,243,19,67,64,249,153,67,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var deleteRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("310641c2-c313-4ca7-9003-58bb95ba5d84"),
				ContainerUId = new Guid("bfa78fda-181f-4764-8b3a-2f4b75e455ea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DeleteRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			deleteRightsParameter.SourceValue = new ProcessSchemaParameterValue(deleteRightsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,142,5,0,41,187,76,13,2,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(deleteRightsParameter);
			var addRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0f101973-6976-4c62-8342-e1c9f265457a"),
				ContainerUId = new Guid("bfa78fda-181f-4764-8b3a-2f4b75e455ea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"AddRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			addRightsParameter.SourceValue = new ProcessSchemaParameterValue(addRightsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,109,80,205,110,211,64,16,126,21,203,189,102,35,39,187,222,141,125,45,17,170,132,40,106,37,46,81,14,227,245,44,141,100,59,149,187,1,85,81,164,52,149,144,16,133,71,128,35,215,80,8,164,13,13,175,48,251,70,172,93,78,136,211,206,247,187,154,25,205,143,242,52,76,18,105,50,197,35,214,215,146,51,161,57,103,144,73,205,20,87,130,163,225,154,247,162,176,115,8,213,9,66,158,218,122,134,13,24,230,19,155,26,40,46,90,244,4,11,180,248,23,159,78,103,181,198,52,228,97,231,105,13,149,69,63,15,203,243,98,122,137,24,118,158,67,233,241,232,128,190,208,214,173,104,237,86,238,38,160,239,180,166,7,122,112,239,105,19,208,111,183,164,125,75,253,160,173,135,180,119,87,180,107,148,91,111,248,234,225,146,214,129,127,86,116,75,27,95,112,245,56,53,13,62,248,141,246,93,250,236,133,101,235,191,11,220,135,38,77,191,26,135,91,5,158,223,208,79,119,77,59,119,227,131,91,183,116,215,238,163,123,231,217,187,128,238,125,195,174,245,223,187,183,180,165,109,151,62,253,239,163,166,249,96,28,118,94,66,49,107,23,26,29,93,28,191,169,176,62,213,103,88,194,227,45,198,93,207,254,67,12,11,44,177,178,233,92,43,158,197,60,50,44,143,146,30,19,121,30,177,65,166,251,44,225,90,169,220,36,90,247,163,133,15,188,128,218,223,204,98,157,206,193,75,0,66,179,56,51,25,19,60,66,6,28,56,147,3,213,31,72,35,148,150,189,38,50,172,236,196,94,30,78,139,89,89,165,115,57,16,113,204,65,49,136,147,156,9,105,128,129,17,25,51,90,73,76,12,114,153,136,197,184,89,230,248,28,107,176,147,105,117,50,121,117,102,159,225,107,44,210,176,23,46,198,127,0,108,250,88,50,43,2,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(addRightsParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c58716e7-0cac-4344-8f1b-9512a93cc454"),
				ContainerUId = new Guid("bfa78fda-181f-4764-8b3a-2f4b75e455ea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
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
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
			var employee1Parameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("996fb730-2c63-4c33-ab6c-73743ef3c310"),
				ContainerUId = new Guid("bfa78fda-181f-4764-8b3a-2f4b75e455ea"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"Employee1",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			employee1Parameter.SourceValue = new ProcessSchemaParameterValue(employee1Parameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c73b530f-d091-4dd0-8bc2-93c77df9cc20}].[Parameter:{a3c7aa4c-5bfb-430e-a3a3-687286f47c61}].[EntityColumn:{684553a7-a59d-46fa-af4b-fc76e9fe3694}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(employee1Parameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaProspecting = CreateProspectingLaneSet();
			LaneSets.Add(schemaProspecting);
			ProcessSchemaLane schemaSalesManager = CreateSalesManagerLane();
			schemaProspecting.Lanes.Add(schemaSalesManager);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask openeditpageusertask1 = CreateOpenEditPageUserTask1UserTask();
			FlowElements.Add(openeditpageusertask1);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaUserTask changeadminrightsusertask1 = CreateChangeAdminRightsUserTask1UserTask();
			FlowElements.Add(changeadminrightsusertask1);
			ProcessSchemaUserTask changeadminrightsusertask2 = CreateChangeAdminRightsUserTask2UserTask();
			FlowElements.Add(changeadminrightsusertask2);
			ProcessSchemaIntermediateCatchSignalEvent intermediatecatchsignalevent1 = CreateIntermediateCatchSignalEvent1IntermediateCatchSignalEvent();
			FlowElements.Add(intermediatecatchsignalevent1);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			ProcessSchemaTerminateEvent terminate2 = CreateTerminate2TerminateEvent();
			FlowElements.Add(terminate2);
			ProcessSchemaUserTask readdatausertask3 = CreateReadDataUserTask3UserTask();
			FlowElements.Add(readdatausertask3);
			ProcessSchemaUserTask readdatausertask4 = CreateReadDataUserTask4UserTask();
			FlowElements.Add(readdatausertask4);
			ProcessSchemaFormulaTask formulatask2 = CreateFormulaTask2FormulaTask();
			FlowElements.Add(formulatask2);
			ProcessSchemaFormulaTask formulatask3 = CreateFormulaTask3FormulaTask();
			FlowElements.Add(formulatask3);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask changeadminrightsusertask3 = CreateChangeAdminRightsUserTask3UserTask();
			FlowElements.Add(changeadminrightsusertask3);
			ProcessSchemaUserTask changeadminrightsusertask4 = CreateChangeAdminRightsUserTask4UserTask();
			FlowElements.Add(changeadminrightsusertask4);
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalFlow4ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateSequenceFlow15SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateConditionalFlow5ConditionalFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("6f29b238-4584-4950-b6ad-b68667918619"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(522, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3d527ad4-f295-4b8c-a9d8-5bd27c06dc5c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fc62fa4b-52eb-4eaa-ad02-5b1dfefe4d77"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("1b71a3e8-6c51-490e-9444-e5f6d5cf43fd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(152, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("80ba5382-aa5f-407f-adb0-a09f93271323"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("1b51c7a8-2830-4a6f-92ee-2073ea6ca9c1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(436, 206),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b0b23273-c3ed-47d0-bab7-c44b1459da2c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("15cfe4b9-aede-4d41-8c5a-58dc03ead64a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("126115de-6094-4d04-b02d-edb4098a40a6"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(96, 256),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("80ba5382-aa5f-407f-adb0-a09f93271323"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b0a72e82-9fc1-437a-ae75-2166804d3791"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("b7b9cf0a-fcd3-4e86-aeae-88c3bf0a6266"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("126115de-6094-4d04-b02d-edb4098a40a6"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(481, 260),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b0a72e82-9fc1-437a-ae75-2166804d3791"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4529baea-eac0-49a9-818f-ed63ef212d92"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("60146d87-d82b-4ea6-ad78-672d75ecfb77"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(292, 268),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4529baea-eac0-49a9-818f-ed63ef212d92"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5a3a044f-4e7d-4766-b31d-7faa8b9908e8"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("6abb8a1d-d77d-4d5d-9a41-f39f1512025d"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{dd4cc279-afe1-401f-a48a-8aa72c711e42}].[Parameter:{a3bc60f3-2c39-4535-b598-fbd578d70e3e}]#] > 0",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(398, 126),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("47c8f086-6221-4fdc-abce-6709e2e61ead"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{dd4cc279-afe1-401f-a48a-8aa72c711e42}].[Parameter:{a3bc60f3-2c39-4535-b598-fbd578d70e3e}]#] == 0",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(450, 89),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1915b8b9-69de-4118-8fd3-21a88fdd3097"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("8cd798ac-003a-4f7f-9951-ed637a29ad57"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(506, 125),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("90929524-44b3-4698-8b37-0a5c654d1461"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("f9665c87-412e-409c-afda-6e97c759a5cb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(619, 126),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("90929524-44b3-4698-8b37-0a5c654d1461"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("e0b03253-ff26-4de3-ba2e-c20782c1ef24"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(638, 74),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1915b8b9-69de-4118-8fd3-21a88fdd3097"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("3351d977-0f52-4d7f-8471-7f0b417a163a"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{219dc79c-3bc4-48da-b5b7-90defe1aec40}].[Parameter:{40333f27-6073-4fdf-8195-0a76448c3050}].[EntityColumn:{15f0f091-e66f-42db-807b-f4c2ad6337b6}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(294, 125),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow2",
				UId = new Guid("f245c894-e899-4439-b757-5cda1041f135"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(470, 138),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1915b8b9-69de-4118-8fd3-21a88fdd3097"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow4ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow4",
				UId = new Guid("4476647f-b722-42dd-ac2f-219a0e5e87de"),
				ConditionExpression = @"true",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1444d101-6aac-4086-8471-ffd89cf6e26d"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(958, 232),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b0b23273-c3ed-47d0-bab7-c44b1459da2c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("26657c91-c5a9-4613-a3c7-9581caa59fb7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("098b9d4a-82ed-44bc-912f-a5f1c3a148bb"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(1084, 232),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9e7139c8-194f-4683-8e84-ae27396bdfa7"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow13",
				UId = new Guid("3ce58dd3-2a27-4f6b-8ff1-4e3df2884ede"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("098b9d4a-82ed-44bc-912f-a5f1c3a148bb"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(1171, 155),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9e7139c8-194f-4683-8e84-ae27396bdfa7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3d527ad4-f295-4b8c-a9d8-5bd27c06dc5c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("825a5e1d-1211-4599-8ac9-2f948b86fc56"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("098b9d4a-82ed-44bc-912f-a5f1c3a148bb"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(1308, 322),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9953d48c-257d-4ca8-84fc-cae371581aa3"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("bfa78fda-181f-4764-8b3a-2f4b75e455ea"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow15SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow15",
				UId = new Guid("1958a841-6837-438a-bd91-1abfc424609b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("098b9d4a-82ed-44bc-912f-a5f1c3a148bb"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(1440, 280),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bfa78fda-181f-4764-8b3a-2f4b75e455ea"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0906a331-a59b-4472-bf33-a9c04f38e6f6"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("d99f5c75-3d4f-45e7-993e-d796c641cdfd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("098b9d4a-82ed-44bc-912f-a5f1c3a148bb"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(1440, 162),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fc62fa4b-52eb-4eaa-ad02-5b1dfefe4d77"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0906a331-a59b-4472-bf33-a9c04f38e6f6"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow5ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow5",
				UId = new Guid("ea08f07d-eb4d-48f3-a091-6ee9d8a32153"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{c73b530f-d091-4dd0-8bc2-93c77df9cc20}].[Parameter:{a3c7aa4c-5bfb-430e-a3a3-687286f47c61}].[EntityColumn:{4b95e3ff-fd52-4ae1-b0a5-2c5103ff15a7}]#] == Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("098b9d4a-82ed-44bc-912f-a5f1c3a148bb"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				CurveCenterPosition = new Point(1171, 292),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9e7139c8-194f-4683-8e84-ae27396bdfa7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9953d48c-257d-4ca8-84fc-cae371581aa3"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateProspectingLaneSet() {
			ProcessSchemaLaneSet schemaProspecting = new ProcessSchemaLaneSet(this) {
				UId = new Guid("0b311493-4d71-4e0c-bd28-39dd809640e3"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"Prospecting",
				Position = new Point(5, 5),
				Size = new Size(1493, 437),
				UseBackgroundMode = false
			};
			return schemaProspecting;
		}

		protected virtual ProcessSchemaLane CreateSalesManagerLane() {
			ProcessSchemaLane schemaSalesManager = new ProcessSchemaLane(this) {
				UId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("0b311493-4d71-4e0c-bd28-39dd809640e3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"SalesManager",
				Position = new Point(29, 0),
				Size = new Size(1464, 437),
				UseBackgroundMode = false
			};
			return schemaSalesManager;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("80ba5382-aa5f-407f-adb0-a09f93271323"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"Start1",
				Position = new Point(78, 212),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("0906a331-a59b-4472-bf33-a9c04f38e6f6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"Terminate1",
				Position = new Point(1422, 212),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateOpenEditPageUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"OpenEditPageUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(708, 198),
				SchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenEditPageUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"ReadDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(155, 198),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeAdminRightsUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("3d527ad4-f295-4b8c-a9d8-5bd27c06dc5c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"ChangeAdminRightsUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1170, 72),
				SchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeAdminRightsUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeAdminRightsUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("fc62fa4b-52eb-4eaa-ad02-5b1dfefe4d77"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"ChangeAdminRightsUserTask2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1303, 72),
				SchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeAdminRightsUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateIntermediateCatchSignalEvent1IntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("b0a72e82-9fc1-437a-ae75-2166804d3791"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("126115de-6094-4d04-b02d-edb4098a40a6"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"IntermediateCatchSignalEvent1",
				NewEntityChangedColumns = false,
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(78, 359),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("797ac352-4979-4d28-906f-82feb6dbc9dc");
			InitializeIntermediateCatchSignalEvent1Parameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("4529baea-eac0-49a9-818f-ed63ef212d92"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("126115de-6094-4d04-b02d-edb4098a40a6"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"FormulaTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(155, 345),
				ResultParameterMetaPath = @"0bd1bc47-97dc-487d-b8b8-e5bd0a629ed8",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,41,42,77,5,0,141,76,252,253,4,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"ReadDataUserTask2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(953, 198),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate2TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("5a3a044f-4e7d-4766-b31d-7faa8b9908e8"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"Terminate2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(288, 359),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask3UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"ReadDataUserTask3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(470, 198),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask3Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask4UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"ReadDataUserTask4",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(330, 198),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask4Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask2FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("90929524-44b3-4698-8b37-0a5c654d1461"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"FormulaTask2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(589, 198),
				ResultParameterMetaPath = @"d8dabfd8-e319-49b0-8bc4-b3f85a47f487.79b71a16-363b-4270-804f-96c0266a9226",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,204,189,10,194,48,20,64,225,135,233,124,165,249,229,38,171,116,112,82,112,44,29,110,146,27,20,218,10,109,68,164,244,221,77,87,215,3,223,233,155,254,178,94,63,51,47,247,248,224,137,124,166,113,229,225,84,235,95,232,70,158,120,46,126,75,164,100,155,56,65,50,34,131,102,36,64,163,17,172,77,78,153,20,217,4,189,87,112,163,133,38,46,188,248,45,72,54,130,179,0,75,20,64,71,18,128,120,144,182,69,194,250,113,100,14,210,205,229,89,190,231,215,248,158,102,191,213,145,204,33,58,80,78,57,208,42,73,64,173,21,16,153,232,2,90,37,141,218,135,102,248,1,12,195,44,181,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask3FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("1915b8b9-69de-4118-8fd3-21a88fdd3097"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"FormulaTask3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(330, 72),
				ResultParameterMetaPath = @"d8dabfd8-e319-49b0-8bc4-b3f85a47f487.79b71a16-363b-4270-804f-96c0266a9226",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,139,86,14,174,44,14,75,44,202,76,76,202,73,213,115,46,45,42,74,205,43,9,45,78,45,114,206,207,43,73,76,46,81,142,5,0,45,65,78,225,34,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("b0b23273-c3ed-47d0-bab7-c44b1459da2c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1444d101-6aac-4086-8471-ffd89cf6e26d"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"ScriptTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(820, 198),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,74,45,41,45,202,83,40,201,200,44,214,11,74,77,76,113,73,44,73,12,45,78,45,10,73,44,206,54,2,138,20,151,230,148,184,230,149,100,150,84,58,231,231,228,164,38,151,100,230,231,233,57,231,151,230,149,40,216,218,42,24,88,3,0,7,66,170,173,64,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("9e7139c8-194f-4683-8e84-ae27396bdfa7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("098b9d4a-82ed-44bc-912f-a5f1c3a148bb"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"ExclusiveGateway1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1072, 198),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateChangeAdminRightsUserTask3UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("9953d48c-257d-4ca8-84fc-cae371581aa3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("098b9d4a-82ed-44bc-912f-a5f1c3a148bb"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"ChangeAdminRightsUserTask3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1170, 289),
				SchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeAdminRightsUserTask3Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeAdminRightsUserTask4UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("bfa78fda-181f-4764-8b3a-2f4b75e455ea"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f49c28d5-51b7-49b8-b1d1-cad272db9f2f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("098b9d4a-82ed-44bc-912f-a5f1c3a148bb"),
				CreatedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				Name = @"ChangeAdminRightsUserTask4",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1303, 289),
				SchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeAdminRightsUserTask4Parameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new OpportunityManagementProspecting(userConnection);
		}

		public override object Clone() {
			return new OpportunityManagementProspectingSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityManagementProspecting

	/// <exclude/>
	public class OpportunityManagementProspecting : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessSalesManager

		/// <exclude/>
		public class ProcessSalesManager : ProcessLane
		{

			public ProcessSalesManager(UserConnection userConnection, OpportunityManagementProspecting process)
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

			public OpenEditPageUserTask1FlowElement(UserConnection userConnection, OpportunityManagementProspecting process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenEditPageUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("d8dabfd8-e319-49b0-8bc4-b3f85a47f487");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.SalesManager;
				SerializeToDB = true;
				_recordId = () => (Guid)((process.CurrentOpportunity));
				_account = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("AccountId") : Guid.Empty)));
				_contact = () => (Guid)(((process.ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? process.ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty)));
				_opportunity = () => (Guid)((process.CurrentOpportunity));
			}

			#endregion

			#region Properties: Public

			private Guid _objectSchemaId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			public override Guid ObjectSchemaId {
				get {
					return _objectSchemaId;
				}
				set {
					_objectSchemaId = value;
				}
			}

			private Guid _pageSchemaId = new Guid("df249c13-df7a-48d2-b128-85183c4a0e10");
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
					return _recommendation ?? (_recommendation = GetLocalizableString("7fce678b995e4c539b43ec2f04fae40f",
						 "BaseElements.OpenEditPageUserTask1.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			private int _durationPeriod = 0;
			public override int DurationPeriod {
				get {
					return _durationPeriod;
				}
				set {
					_durationPeriod = value;
				}
			}

			private int _startInPeriod = 0;
			public override int StartInPeriod {
				get {
					return _startInPeriod;
				}
				set {
					_startInPeriod = value;
				}
			}

			private int _remindBefore = 5;
			public override int RemindBefore {
				get {
					return _remindBefore;
				}
				set {
					_remindBefore = value;
				}
			}

			private int _remindBeforePeriod = 0;
			public override int RemindBeforePeriod {
				get {
					return _remindBeforePeriod;
				}
				set {
					_remindBeforePeriod = value;
				}
			}

			private bool _showInScheduler = true;
			public override bool ShowInScheduler {
				get {
					return _showInScheduler;
				}
				set {
					_showInScheduler = value;
				}
			}

			internal Func<Guid> _account;
			public override Guid Account {
				get {
					return (_account ?? (_account = () => Guid.Empty)).Invoke();
				}
				set {
					_account = () => { return value; };
				}
			}

			internal Func<Guid> _contact;
			public override Guid Contact {
				get {
					return (_contact ?? (_contact = () => Guid.Empty)).Invoke();
				}
				set {
					_contact = () => { return value; };
				}
			}

			internal Func<Guid> _opportunity;
			public override Guid Opportunity {
				get {
					return (_opportunity ?? (_opportunity = () => Guid.Empty)).Invoke();
				}
				set {
					_opportunity = () => { return value; };
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, OpportunityManagementProspecting process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("219dc79c-3bc4-48da-b5b7-90defe1aec40");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,187,142,212,48,20,253,21,228,130,42,70,137,237,56,113,40,71,3,218,102,89,137,5,33,237,142,86,55,246,205,142,165,60,102,19,71,236,42,26,9,137,138,138,127,224,11,166,0,10,10,248,133,204,31,225,76,118,64,218,2,81,208,32,185,176,175,125,206,61,231,232,122,184,178,221,51,91,58,108,179,2,202,14,131,254,196,100,36,14,115,197,67,140,41,36,90,80,17,169,148,66,152,231,148,73,64,35,140,140,194,84,147,160,134,10,51,50,163,151,198,58,18,88,135,85,151,93,12,191,73,93,219,99,112,85,28,14,47,245,26,43,120,53,53,0,20,178,200,211,132,234,144,105,42,0,125,3,195,35,10,138,113,109,140,82,66,23,100,214,130,154,177,84,161,164,156,9,73,5,38,154,66,26,33,205,19,169,153,100,33,75,18,70,130,18,11,183,188,221,180,216,117,182,169,179,1,127,237,207,239,54,94,229,220,123,209,148,125,85,147,160,66,7,103,224,214,147,144,16,69,172,129,106,161,98,42,10,76,40,112,101,40,135,60,97,73,138,145,140,18,18,104,216,184,137,150,156,24,18,24,112,240,26,202,30,15,204,131,245,26,25,15,163,52,150,30,27,113,111,135,179,144,166,210,187,43,140,44,20,114,169,84,110,142,121,61,239,173,223,219,238,180,175,176,181,250,62,118,244,249,53,109,54,232,166,118,109,83,78,212,167,135,231,231,120,235,230,112,239,175,222,204,134,156,175,79,32,178,13,250,14,23,165,197,218,45,107,221,24,91,95,207,156,219,173,135,84,27,104,109,119,76,97,121,211,67,73,130,214,94,175,255,152,214,162,239,92,83,253,71,86,3,111,211,115,248,33,59,200,157,102,208,216,110,83,194,221,225,156,145,199,55,125,227,158,142,159,198,47,227,183,253,251,253,135,113,183,255,248,104,252,177,127,55,126,31,63,143,187,241,235,184,155,159,144,7,84,25,185,36,66,75,84,32,53,141,25,112,63,36,44,166,105,162,10,170,164,18,145,142,0,184,80,151,196,203,251,151,77,47,78,186,23,111,235,227,175,153,125,174,158,248,234,131,194,217,17,153,13,127,163,115,187,154,148,174,182,126,253,4,58,34,155,168,252,3,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,11,201,44,201,73,181,50,180,50,212,241,76,177,50,176,50,0,0,169,240,29,88,16,0,0,0 })));
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
								new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"));
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

		#region Class: ChangeAdminRightsUserTask1FlowElement

		/// <exclude/>
		public class ChangeAdminRightsUserTask1FlowElement : ChangeAdminRightsUserTask
		{

			#region Constructors: Public

			public ChangeAdminRightsUserTask1FlowElement(UserConnection userConnection, OpportunityManagementProspecting process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeAdminRightsUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("3d527ad4-f295-4b8c-a9d8-5bd27c06dc5c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_employee1 = () => (Guid)(((process.ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadDataUserTask2.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,205,110,212,48,16,126,149,149,15,156,226,85,156,56,113,18,142,213,130,122,41,149,40,8,169,173,42,199,118,218,72,249,217,110,28,209,106,181,210,182,72,72,136,194,3,112,225,200,181,20,10,219,150,150,87,112,222,136,73,210,5,169,7,212,43,66,138,20,207,120,190,111,60,243,141,61,221,73,171,71,105,166,213,36,74,120,86,41,171,94,149,17,34,73,236,198,129,231,96,197,105,136,41,21,33,230,220,97,216,247,24,117,220,128,216,50,8,144,85,240,92,69,168,71,143,100,170,145,149,106,149,87,209,230,244,15,169,158,212,202,218,73,58,227,169,216,83,57,127,214,38,112,60,201,4,225,49,38,82,217,152,122,54,193,49,181,29,108,59,202,86,30,103,142,244,21,234,207,226,122,132,57,196,113,176,79,98,138,169,205,32,212,11,56,38,132,83,69,93,22,122,20,206,146,169,68,143,14,198,19,85,85,105,89,68,83,245,123,189,113,56,134,83,246,185,87,202,172,206,11,100,229,74,243,117,174,247,34,196,33,31,245,4,199,130,134,30,166,137,98,152,187,161,196,46,143,153,195,2,69,124,194,144,37,248,88,183,180,104,85,34,75,114,205,159,243,172,86,29,243,52,109,203,113,109,18,120,62,96,137,43,48,117,29,27,7,126,192,112,34,253,36,84,174,31,134,177,92,246,235,113,157,194,58,173,214,234,92,77,82,113,219,118,5,253,43,39,209,84,148,133,158,148,89,75,189,214,133,111,168,3,221,55,247,118,235,69,95,144,6,127,11,66,51,171,174,212,74,150,170,66,143,10,81,202,180,216,237,57,103,51,128,228,99,62,73,171,101,23,70,251,53,207,144,53,73,119,247,254,218,173,149,186,210,101,254,15,149,106,65,153,192,1,67,214,29,183,157,65,153,86,227,140,31,118,118,132,30,236,215,165,126,104,62,153,69,115,108,78,155,227,230,100,96,190,154,83,115,109,174,155,183,230,124,96,126,54,115,115,211,185,190,153,5,152,230,166,57,50,87,237,206,25,4,124,6,115,110,78,7,240,59,54,103,230,28,8,142,250,85,203,0,192,47,230,102,104,62,194,198,188,139,191,24,52,239,90,180,249,209,70,52,199,3,240,159,155,239,205,43,115,213,156,0,112,209,204,155,87,205,251,230,13,120,47,6,230,18,24,174,186,248,203,230,181,89,152,197,208,124,0,23,0,219,172,64,222,145,244,53,160,59,181,70,104,11,9,230,198,158,107,39,88,218,33,193,84,74,16,37,22,14,14,93,193,152,76,66,33,28,123,200,193,224,156,10,236,197,73,12,202,217,10,70,157,187,24,212,115,2,63,161,76,248,100,72,227,208,83,110,146,128,158,112,253,41,87,112,219,108,238,97,71,120,196,6,63,129,203,185,133,64,137,255,170,191,155,171,213,147,151,197,242,5,235,103,110,123,8,222,59,142,81,166,114,24,78,152,237,123,8,50,3,192,250,50,85,52,189,143,60,45,100,84,232,84,31,246,47,89,52,189,143,94,179,237,86,177,237,25,124,191,0,0,155,104,247,239,5,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _addRights;
			public override string AddRights {
				get {
					return _addRights ?? (_addRights = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,193,106,219,64,16,253,21,161,92,189,70,210,174,36,75,215,212,148,64,105,74,2,189,24,31,86,187,179,141,65,146,131,178,110,9,198,224,56,80,40,77,251,9,237,177,87,55,173,91,37,110,220,95,152,253,163,142,28,232,161,244,180,243,222,188,247,134,153,29,205,143,116,238,235,2,68,0,160,152,202,180,98,34,202,128,73,21,10,150,25,25,38,58,141,66,29,114,191,119,40,235,19,144,58,183,205,12,58,48,212,19,251,23,60,129,18,44,228,70,150,23,208,59,157,206,26,5,185,79,166,167,141,172,45,80,61,172,206,203,233,37,128,223,123,46,43,194,163,3,252,130,173,91,225,218,173,220,141,135,223,113,141,15,248,224,222,227,198,195,223,110,137,187,61,245,3,91,130,184,115,87,184,237,58,183,36,248,74,112,137,107,143,158,21,222,226,134,2,174,30,171,46,129,140,223,112,215,199,207,212,88,238,245,119,158,251,208,185,241,87,167,112,43,143,248,13,254,116,215,184,117,55,100,108,221,210,93,187,143,238,29,177,119,30,222,83,194,118,175,191,119,111,177,197,182,143,159,254,55,168,75,62,24,251,189,151,178,156,237,23,26,29,93,28,191,169,161,57,85,103,80,201,199,91,140,251,196,254,67,12,75,168,160,182,249,92,165,188,136,121,96,152,14,178,144,9,173,3,54,40,84,196,50,174,210,84,155,76,169,40,88,144,225,133,108,232,102,22,154,124,46,169,37,165,80,44,46,76,193,4,15,232,171,184,228,44,25,164,209,32,49,34,85,73,216,89,134,181,157,216,203,195,105,57,171,234,124,158,12,68,28,115,153,50,25,103,154,137,196,72,38,141,40,152,81,105,2,153,1,158,100,98,49,238,150,57,62,135,70,218,201,180,62,153,188,58,179,207,224,53,148,185,31,250,139,241,31,75,83,224,195,42,2,0,0 })));
				}
				set {
					_addRights = value;
				}
			}

			internal Func<Guid> _employee1;
			public virtual Guid Employee1 {
				get {
					return (_employee1 ?? (_employee1 = () => Guid.Empty)).Invoke();
				}
				set {
					_employee1 = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: ChangeAdminRightsUserTask2FlowElement

		/// <exclude/>
		public class ChangeAdminRightsUserTask2FlowElement : ChangeAdminRightsUserTask
		{

			#region Constructors: Public

			public ChangeAdminRightsUserTask2FlowElement(UserConnection userConnection, OpportunityManagementProspecting process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeAdminRightsUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("fc62fa4b-52eb-4eaa-ad02-5b1dfefe4d77");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_employee1 = () => (Guid)(((process.ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadDataUserTask2.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,93,107,212,64,20,253,43,75,30,124,202,44,201,36,217,236,196,199,186,130,32,42,88,69,144,82,110,102,238,180,193,124,172,249,64,203,178,80,43,8,98,245,7,248,226,163,175,126,85,215,86,235,95,152,252,35,111,146,174,138,136,244,85,132,64,230,222,153,115,114,239,61,39,179,216,78,170,203,73,90,99,25,105,72,43,180,155,43,42,178,98,151,79,81,196,192,100,16,2,243,133,64,54,149,74,50,49,9,20,162,231,114,25,186,150,157,67,134,145,53,160,103,42,169,45,59,169,49,171,162,187,139,159,164,117,217,160,189,173,251,224,166,220,197,12,110,117,31,0,244,39,58,158,134,76,58,92,50,31,112,202,64,121,46,3,193,61,169,148,16,190,212,214,80,139,4,224,33,215,156,197,190,167,152,143,177,98,2,99,206,66,63,230,60,22,10,136,193,178,235,50,201,46,65,141,155,73,134,55,160,164,202,232,131,155,69,151,26,106,72,81,215,179,135,243,18,171,42,41,242,104,129,63,214,155,123,115,106,99,40,110,163,72,155,44,183,108,130,195,13,168,119,35,203,143,69,128,158,214,76,171,128,119,149,186,44,118,32,96,92,6,174,67,121,55,128,208,178,37,204,235,142,214,50,47,205,169,249,218,30,180,251,230,141,121,111,142,186,181,101,151,168,177,196,92,226,47,35,224,129,10,165,11,49,115,21,58,204,15,28,34,246,29,206,28,142,14,18,41,87,19,180,108,5,53,220,134,180,193,190,202,69,210,137,195,69,224,132,174,102,33,130,160,129,76,56,155,42,23,152,112,69,172,189,208,227,90,243,181,56,87,139,226,94,51,39,97,170,107,77,134,101,34,207,84,70,146,171,40,163,133,44,242,186,44,210,142,252,218,47,128,65,205,179,205,59,195,128,210,126,167,3,90,75,187,169,112,35,77,48,175,103,185,44,84,146,239,244,67,94,46,9,147,205,161,76,170,245,88,103,247,27,72,105,0,201,206,238,95,199,191,209,84,117,145,253,107,253,218,243,181,213,250,154,59,235,171,164,154,167,176,215,199,145,117,225,126,83,212,23,205,107,179,106,15,204,27,178,197,225,200,124,32,103,124,37,95,60,51,71,35,243,141,140,114,218,167,62,154,21,133,230,180,125,100,78,186,157,119,116,224,45,133,100,164,17,189,14,204,59,115,68,4,143,134,85,199,64,192,247,230,116,108,94,209,198,126,127,254,243,168,125,222,161,205,151,193,121,35,202,31,153,79,237,99,115,210,30,18,112,213,238,183,143,219,23,237,83,202,126,30,153,99,98,56,233,207,31,183,79,204,202,172,198,127,178,239,208,131,245,91,175,235,222,100,232,197,129,231,104,166,28,225,50,95,41,135,77,99,201,153,240,100,24,42,45,164,228,206,24,40,0,240,37,11,98,29,51,223,115,144,129,7,30,155,76,67,62,157,104,63,148,19,119,124,158,63,237,172,150,165,253,223,205,249,238,149,234,250,131,124,125,137,14,182,222,26,83,246,183,196,44,197,140,124,74,86,63,135,48,75,2,252,184,45,163,197,121,100,234,32,179,188,78,234,189,225,174,140,22,231,209,109,185,181,86,110,107,73,207,119,113,141,185,55,118,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _addRights;
			public override string AddRights {
				get {
					return _addRights ?? (_addRights = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,77,111,211,64,16,253,43,150,123,205,70,78,118,253,177,190,150,8,85,66,20,181,18,151,40,135,241,122,150,70,178,157,202,221,128,170,40,82,154,74,72,136,194,79,128,35,215,80,8,184,13,13,127,97,246,31,177,118,57,33,78,59,239,205,123,111,53,51,227,197,81,158,250,74,65,18,134,34,99,10,180,102,66,14,129,201,72,2,139,18,25,107,45,121,36,226,196,239,29,66,117,130,144,167,166,158,99,11,70,249,212,164,26,138,139,14,61,193,2,13,254,197,167,179,121,173,48,245,185,223,123,90,67,101,208,213,163,242,188,152,93,34,250,189,231,80,58,60,62,160,47,212,216,53,109,236,218,222,120,244,157,54,244,64,15,246,61,109,61,250,109,87,180,239,168,31,212,56,72,123,123,69,187,182,115,235,4,95,29,92,209,198,115,207,154,110,105,235,2,174,30,171,54,193,25,191,209,190,79,159,93,99,213,233,239,60,251,161,117,211,175,86,97,215,158,227,183,244,211,94,211,206,222,56,99,99,87,246,218,126,180,239,28,123,231,209,189,75,216,117,250,123,251,150,26,106,250,244,233,127,31,181,201,7,19,191,247,18,138,121,55,208,248,232,226,248,77,133,245,169,58,195,18,30,119,49,233,59,246,31,98,84,96,137,149,73,23,42,230,89,200,3,205,242,64,14,152,200,243,128,37,153,26,50,201,85,28,231,90,42,53,12,150,206,240,2,106,183,51,131,117,186,0,215,2,16,138,133,153,206,152,224,1,50,224,192,221,173,226,97,18,105,17,171,104,208,90,70,149,153,154,203,195,89,49,47,171,116,17,37,34,12,57,196,12,66,153,51,17,105,96,160,221,193,181,138,35,148,26,121,36,197,114,210,14,115,124,142,53,152,233,172,58,153,190,58,51,207,240,53,22,169,63,240,151,147,63,236,126,43,164,43,2,0,0 })));
				}
				set {
					_addRights = value;
				}
			}

			internal Func<Guid> _employee1;
			public virtual Guid Employee1 {
				get {
					return (_employee1 ?? (_employee1 = () => Guid.Empty)).Invoke();
				}
				set {
					_employee1 = () => { return value; };
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

			public IntermediateCatchSignalEvent1FlowElement(UserConnection userConnection, OpportunityManagementProspecting process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "IntermediateCatchSignalEvent1";
				IsLogging = false;
				SchemaElementUId = new Guid("b0a72e82-9fc1-437a-ae75-2166804d3791");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""797ac352-4979-4d28-906f-82feb6dbc9dc""]}";
				EntityFilters = @"{_isFilter:false,uId:""33168933-be31-4312-947b-6a899a2df890"",name:""FilterEdit"",items:[]}";
				_recordId = () => (Guid)((process.CurrentOpportunity));
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

		#region Class: ReadDataUserTask2FlowElement

		/// <exclude/>
		public class ReadDataUserTask2FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask2FlowElement(UserConnection userConnection, OpportunityManagementProspecting process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("c73b530f-d091-4dd0-8bc2-93c77df9cc20");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,110,212,48,20,253,21,228,5,171,24,197,177,227,196,97,57,26,80,55,165,18,5,33,181,85,117,99,95,119,44,229,49,77,28,209,106,52,18,18,43,86,252,3,95,208,5,176,96,1,191,144,249,35,156,73,7,164,46,16,11,54,72,94,216,215,62,231,158,115,116,189,185,116,253,51,87,121,236,10,11,85,143,209,112,100,10,82,106,133,12,68,78,75,147,49,42,20,72,90,50,193,40,170,24,65,10,155,91,43,72,212,64,141,5,153,209,75,227,60,137,156,199,186,47,206,54,191,73,125,55,96,116,105,247,135,151,122,133,53,188,154,26,0,10,105,203,60,163,58,78,52,21,128,57,5,195,25,5,149,112,109,140,82,66,91,50,107,145,105,12,57,43,21,21,105,82,82,33,57,167,42,53,134,198,165,205,164,204,153,86,150,147,168,66,235,151,55,235,14,251,222,181,77,177,193,95,251,211,219,117,80,57,247,94,180,213,80,55,36,170,209,195,9,248,213,36,36,70,145,106,160,90,168,148,10,139,25,5,174,12,229,80,102,73,150,35,147,44,35,145,134,181,159,104,201,145,33,145,1,15,175,161,26,112,207,188,113,65,99,194,99,150,167,50,96,25,15,118,120,18,211,92,6,119,214,72,171,144,75,165,74,115,200,235,249,224,194,222,245,199,67,141,157,211,247,177,99,200,175,237,138,141,110,27,223,181,213,68,125,188,127,126,138,55,126,14,247,254,234,205,108,200,135,250,4,34,219,104,232,113,81,57,108,252,178,209,173,113,205,213,204,185,221,6,72,189,134,206,245,135,20,150,215,3,84,36,234,220,213,234,143,105,45,134,222,183,245,127,100,53,10,54,3,71,24,178,189,220,105,6,141,235,215,21,220,238,207,5,121,124,61,180,254,233,248,105,252,50,126,219,189,223,125,24,239,118,31,31,141,63,118,239,198,239,227,231,241,110,252,58,222,205,79,200,3,170,130,156,19,161,37,134,63,160,105,154,0,15,67,146,164,52,207,148,165,74,42,193,52,3,224,66,157,147,32,239,95,54,61,59,234,95,188,109,14,191,102,246,121,241,36,84,31,20,78,14,200,98,243,55,58,183,23,147,210,139,109,88,63,1,248,210,33,144,252,3,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,9,201,44,201,73,181,50,180,50,4,0,57,183,224,50,16,0,0,0 })));
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
								new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"));
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

			public ReadDataUserTask3FlowElement(UserConnection userConnection, OpportunityManagementProspecting process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask3";
				IsLogging = true;
				SchemaElementUId = new Guid("da320ded-d51f-4e8a-8548-66d935dce5b4");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,85,93,107,220,70,20,253,43,139,30,250,164,49,243,41,105,212,71,179,45,134,226,6,154,150,66,98,194,124,198,162,90,105,179,146,104,204,178,16,28,8,148,166,249,7,161,125,235,171,49,217,212,137,235,230,47,140,254,81,174,164,108,27,130,91,220,210,151,60,72,104,238,204,61,115,239,153,51,71,235,123,69,243,89,81,182,110,149,123,85,54,46,238,14,108,30,101,2,167,216,99,134,36,150,28,241,44,51,72,121,226,144,161,150,26,202,76,150,10,29,197,149,90,184,60,154,178,231,182,104,163,184,104,221,162,201,239,172,255,2,109,87,157,139,239,249,113,240,149,57,118,11,245,245,176,129,176,25,23,137,230,136,8,135,17,183,78,32,141,225,165,188,38,216,39,169,20,6,71,83,45,86,178,196,75,1,11,140,149,136,39,84,35,197,177,70,150,43,194,24,209,41,22,36,138,75,231,219,249,195,229,202,53,77,81,87,249,218,253,249,125,251,100,9,85,78,123,239,215,101,183,168,162,120,225,90,117,75,181,199,121,164,28,118,92,24,133,12,151,2,113,239,82,164,152,180,136,41,157,210,52,115,36,33,105,20,27,181,108,7,216,232,192,70,177,85,173,250,70,149,157,27,145,215,5,212,72,25,38,153,72,32,151,48,131,56,163,24,101,73,150,34,111,161,116,199,18,41,181,221,241,245,121,87,192,119,209,28,118,11,183,42,204,59,218,29,240,87,175,242,181,169,171,118,85,151,3,244,225,184,252,182,123,216,78,228,190,155,250,118,106,168,133,248,144,20,109,226,174,113,251,101,225,170,118,94,153,218,22,213,253,9,115,179,129,148,197,82,173,138,102,199,194,252,65,167,202,40,94,21,247,143,255,145,173,253,174,105,235,197,71,212,106,12,109,2,6,136,108,44,119,208,160,45,154,101,169,78,198,113,30,125,242,160,171,219,79,195,175,225,162,63,13,103,253,105,255,116,22,94,132,179,112,21,174,250,31,195,118,22,222,244,143,194,31,99,232,101,184,216,11,63,135,45,4,206,97,238,213,172,255,41,92,134,109,248,29,158,171,254,116,6,241,109,248,173,127,28,46,251,167,0,118,209,63,234,31,247,207,250,31,32,250,106,22,94,3,202,229,184,254,117,255,36,92,12,88,207,1,116,128,63,11,231,227,196,21,132,183,83,65,209,7,133,231,209,221,136,18,105,77,42,13,98,218,12,151,207,42,164,133,78,225,46,90,231,29,81,206,112,188,199,49,99,204,211,20,37,56,101,160,91,235,81,70,64,193,88,165,9,231,153,97,88,224,61,34,60,220,98,73,144,75,18,143,56,181,26,101,56,213,200,115,67,149,77,24,75,117,114,55,2,90,63,94,178,238,28,52,95,126,95,237,188,101,82,195,209,30,68,63,8,204,75,183,0,217,228,235,155,176,187,129,132,91,187,173,242,245,77,184,30,82,230,85,91,180,39,147,199,228,235,155,144,191,57,26,232,63,130,155,250,191,90,38,163,212,40,66,19,196,37,131,30,141,181,72,89,227,144,227,169,17,148,131,125,103,246,191,91,166,19,154,122,109,36,98,146,129,33,51,75,81,198,57,67,74,9,35,117,150,48,42,216,123,150,25,126,129,211,31,14,250,124,148,204,32,169,237,160,6,176,33,32,124,229,42,227,222,235,146,36,26,76,68,16,148,121,71,17,39,66,162,204,90,140,84,134,153,229,73,198,172,5,240,107,124,73,83,9,63,45,226,81,234,20,84,229,18,168,202,18,133,36,145,218,179,148,81,239,233,206,151,190,168,235,239,186,229,191,112,166,41,225,58,111,42,199,153,191,117,167,225,44,175,241,225,131,230,176,110,15,187,178,28,14,255,45,180,231,107,154,131,7,0,0 })));
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
								new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"));
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

			public ReadDataUserTask4FlowElement(UserConnection userConnection, OpportunityManagementProspecting process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask4";
				IsLogging = true;
				SchemaElementUId = new Guid("dd4cc279-afe1-401f-a48a-8aa72c711e42");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,85,93,139,220,54,20,253,43,139,31,250,100,45,146,245,97,203,125,92,166,101,161,108,3,77,75,33,89,130,44,93,101,77,61,227,201,216,166,89,134,129,176,129,64,105,154,127,16,218,183,190,46,75,167,221,100,187,237,95,144,255,81,175,237,76,27,194,182,108,75,95,242,96,99,93,233,30,93,29,157,123,188,126,80,54,31,149,85,11,171,220,155,170,129,184,59,116,121,148,122,199,52,72,75,82,237,56,17,210,56,98,168,74,137,245,66,112,48,134,75,11,81,188,48,115,200,163,41,123,230,202,54,138,203,22,230,77,126,111,253,23,104,187,234,32,126,224,199,193,103,246,4,230,230,243,97,3,233,50,33,85,33,8,147,64,137,112,32,73,65,241,101,124,193,168,87,169,150,150,70,83,45,78,42,97,185,183,68,130,22,68,80,203,73,102,173,37,58,161,62,179,156,38,66,164,81,92,129,111,103,143,151,43,104,154,178,94,228,107,248,243,251,238,233,18,171,156,246,62,168,171,110,190,136,226,57,180,230,142,105,79,242,200,0,5,33,173,33,86,104,73,132,135,148,24,174,29,225,166,72,147,52,3,166,24,162,91,179,108,7,216,232,208,69,177,51,173,249,194,84,29,140,200,235,18,107,76,56,101,153,68,130,12,227,150,8,158,80,146,169,44,37,222,41,175,129,43,173,11,183,227,235,227,174,196,239,178,57,234,230,176,42,237,27,218,1,249,171,87,249,218,214,139,118,85,87,3,244,209,184,252,46,60,110,39,114,223,76,125,57,29,168,197,248,144,20,109,226,174,129,131,170,132,69,59,91,216,218,149,139,135,19,230,102,131,41,243,165,89,149,205,142,133,217,163,206,84,81,188,42,31,158,252,35,91,7,93,211,214,243,247,232,168,49,30,19,49,80,100,99,185,131,6,93,217,44,43,115,58,142,243,232,131,71,93,221,126,24,126,12,151,253,89,56,239,207,250,231,123,225,167,112,30,174,195,117,255,109,216,238,133,223,251,39,225,183,49,244,115,184,220,15,223,135,45,6,46,112,238,213,94,255,93,184,10,219,240,43,62,215,253,217,30,198,183,225,151,254,105,184,234,159,35,216,101,255,164,127,218,191,232,191,193,232,171,189,240,26,81,174,198,245,175,251,103,225,114,192,122,137,160,3,252,121,184,24,39,174,49,188,157,10,138,222,41,60,143,238,71,9,211,206,166,218,18,94,88,20,124,230,12,41,100,145,18,77,29,120,96,6,172,160,251,130,114,206,125,146,18,69,83,236,80,239,60,201,24,42,152,154,84,9,49,244,133,164,251,76,122,234,169,102,4,148,242,68,36,174,32,25,77,11,226,133,77,140,83,156,167,133,186,31,33,173,239,47,89,247,14,155,79,191,94,236,188,101,82,195,241,62,70,223,9,204,42,152,163,108,242,245,109,216,221,96,194,157,221,86,249,250,54,92,15,41,179,69,91,182,167,147,199,228,235,219,144,191,57,30,232,63,198,78,253,95,45,147,89,203,10,165,0,157,155,41,236,81,151,224,42,159,17,199,65,102,222,21,218,121,248,239,150,9,178,72,124,97,53,225,154,235,9,61,195,223,2,49,70,90,93,100,138,39,146,191,101,153,225,7,188,253,225,162,47,70,201,12,146,218,14,106,64,27,66,194,87,176,176,240,214,41,153,42,208,68,36,35,153,135,132,8,38,53,201,156,163,196,100,148,59,161,50,238,28,130,223,224,75,69,162,37,77,153,39,41,24,172,10,20,86,229,152,33,154,233,194,243,148,39,222,39,59,95,250,164,174,191,234,150,255,194,153,166,132,155,188,169,26,103,254,214,157,134,187,188,193,135,15,155,163,186,61,234,170,106,184,252,63,0,69,24,50,65,131,7,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,75,204,77,181,50,180,50,4,0,203,8,241,43,15,0,0,0 })));
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
								new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"));
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

		#region Class: ChangeAdminRightsUserTask3FlowElement

		/// <exclude/>
		public class ChangeAdminRightsUserTask3FlowElement : ChangeAdminRightsUserTask
		{

			#region Constructors: Public

			public ChangeAdminRightsUserTask3FlowElement(UserConnection userConnection, OpportunityManagementProspecting process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeAdminRightsUserTask3";
				IsLogging = true;
				SchemaElementUId = new Guid("9953d48c-257d-4ca8-84fc-cae371581aa3");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_employee1 = () => (Guid)(((process.ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? process.ReadDataUserTask2.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,219,106,212,64,24,126,149,101,46,188,202,44,73,38,135,73,188,44,171,244,166,22,172,34,180,165,204,41,109,32,135,237,102,130,45,203,66,187,130,32,86,31,192,27,47,189,173,213,234,182,181,245,21,38,111,228,159,164,171,208,11,233,173,8,129,204,127,248,190,249,143,51,221,73,171,71,105,166,213,36,78,88,86,41,171,94,149,49,242,35,215,119,2,194,177,227,217,1,246,66,161,48,83,129,194,174,27,209,72,168,144,114,158,32,171,96,185,138,81,143,30,201,84,35,43,213,42,175,226,205,233,31,82,61,169,149,181,147,116,194,83,177,167,114,246,172,189,192,9,184,34,129,239,96,154,40,23,123,142,31,97,42,165,141,25,181,137,244,2,74,164,36,168,143,69,80,226,115,198,3,76,5,9,33,22,197,49,11,69,136,169,167,124,73,3,201,67,6,174,153,74,244,232,96,60,81,85,149,150,69,60,85,191,207,27,135,99,136,178,191,123,165,204,234,188,64,86,174,52,91,103,122,47,70,76,217,202,243,5,195,194,139,124,236,37,42,196,140,68,18,19,198,67,55,164,202,9,156,16,89,130,141,117,75,139,86,37,178,36,211,236,57,203,106,213,49,79,83,136,209,37,182,67,253,0,176,14,17,216,35,174,141,105,64,67,156,200,32,137,32,209,40,226,114,89,175,199,117,10,231,180,90,171,115,53,73,197,109,217,21,212,175,156,196,83,81,22,122,82,102,45,245,90,231,190,161,14,116,95,220,91,211,139,62,33,13,250,22,132,102,86,93,169,149,44,85,133,30,21,162,148,105,177,219,115,206,102,0,201,199,108,146,86,203,42,140,246,107,150,33,107,146,238,238,253,181,90,43,117,165,203,252,31,74,213,130,52,129,3,134,172,11,183,157,65,153,86,227,140,29,118,114,140,30,236,215,165,126,104,62,153,69,51,55,167,205,188,57,25,152,175,230,212,92,155,235,230,173,57,31,152,159,205,145,185,233,84,223,204,2,68,115,211,28,155,171,214,114,6,14,159,65,60,50,167,3,248,205,205,153,57,7,130,227,254,212,50,0,240,139,185,25,154,143,96,56,234,252,47,6,205,187,22,109,126,180,30,205,124,0,250,115,243,189,121,101,174,154,19,0,46,154,163,230,85,243,190,121,3,218,139,129,185,4,134,171,206,255,178,121,109,22,102,49,52,31,64,5,64,136,231,178,153,247,209,163,59,89,198,104,11,137,144,112,159,216,9,150,118,228,96,175,221,33,202,133,139,35,34,194,80,38,145,16,174,61,100,32,48,230,9,236,243,132,67,207,108,88,103,194,8,134,190,185,52,72,96,191,3,103,24,120,204,6,59,195,196,183,37,48,241,4,243,68,82,156,112,63,140,88,232,37,36,82,91,8,122,240,159,84,118,115,181,122,242,178,88,190,90,253,156,109,15,65,123,71,49,202,84,14,3,9,243,124,143,86,204,0,176,190,188,42,158,222,167,49,45,100,84,232,84,31,246,175,87,60,189,79,167,102,219,109,175,182,103,240,253,2,216,125,249,219,227,5,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _addRights;
			public override string AddRights {
				get {
					return _addRights ?? (_addRights = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,93,81,193,106,219,64,16,253,21,161,92,181,70,214,202,90,75,215,212,148,64,105,74,2,189,24,31,70,171,217,198,32,201,65,145,91,130,49,56,14,20,74,211,124,64,47,61,246,234,38,113,171,216,141,251,11,179,127,212,145,3,61,244,180,243,222,188,55,187,243,118,56,59,202,18,215,151,105,224,171,46,8,19,196,74,132,25,4,34,14,51,95,104,5,25,66,164,163,46,130,235,29,66,121,130,144,37,117,53,197,22,12,178,113,253,15,188,192,28,107,76,12,228,23,232,157,78,166,149,198,196,149,174,247,178,130,178,70,174,7,197,121,62,185,68,116,189,215,80,48,30,30,208,119,106,236,146,86,118,105,111,28,122,160,21,61,209,147,253,76,107,135,254,216,5,237,246,212,79,106,24,210,206,94,209,182,237,220,177,224,7,195,5,173,28,62,150,116,71,107,30,112,245,92,181,19,216,120,79,187,14,125,227,198,98,175,127,116,236,151,214,77,191,91,133,93,58,204,175,233,151,189,166,173,189,97,99,99,23,246,218,222,218,79,204,62,58,180,225,9,219,189,126,99,63,82,67,77,135,190,50,197,70,126,207,198,46,15,70,174,247,22,242,233,126,137,225,209,197,241,135,18,171,83,125,134,5,60,239,63,234,48,251,31,49,200,177,192,178,78,102,90,201,180,39,125,35,50,63,238,114,214,28,115,63,213,28,184,212,74,101,38,214,58,240,231,108,120,3,21,231,84,99,149,204,128,91,0,161,22,189,212,164,34,148,62,10,144,32,69,212,87,65,63,50,161,226,15,106,45,131,178,30,215,151,135,147,124,90,148,201,44,10,193,103,3,8,217,243,51,190,40,53,34,53,89,95,152,180,167,98,80,161,145,49,206,71,237,50,199,231,88,65,61,158,148,39,227,119,103,245,43,124,143,121,226,118,221,249,232,47,120,191,167,160,30,2,0,0 })));
				}
				set {
					_addRights = value;
				}
			}

			internal Func<Guid> _employee1;
			public virtual Guid Employee1 {
				get {
					return (_employee1 ?? (_employee1 = () => Guid.Empty)).Invoke();
				}
				set {
					_employee1 = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: ChangeAdminRightsUserTask4FlowElement

		/// <exclude/>
		public class ChangeAdminRightsUserTask4FlowElement : ChangeAdminRightsUserTask
		{

			#region Constructors: Public

			public ChangeAdminRightsUserTask4FlowElement(UserConnection userConnection, OpportunityManagementProspecting process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeAdminRightsUserTask4";
				IsLogging = true;
				SchemaElementUId = new Guid("bfa78fda-181f-4764-8b3a-2f4b75e455ea");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_employee1 = () => (Guid)(((process.ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadDataUserTask2.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,91,107,212,64,20,254,43,75,30,124,202,44,73,38,201,36,241,177,172,80,144,90,240,130,80,74,153,204,165,13,230,178,77,38,104,89,22,182,43,8,98,245,7,248,226,163,175,181,90,221,182,182,254,133,201,63,242,36,233,106,237,131,236,171,8,33,201,57,115,190,115,253,206,76,118,146,234,94,146,42,81,70,146,166,149,48,235,117,30,25,1,243,169,229,197,18,5,22,147,200,117,99,130,40,21,46,242,153,107,73,34,136,237,122,196,48,115,154,137,200,232,209,35,158,40,195,76,148,200,170,104,107,242,219,169,42,107,97,238,200,78,120,200,246,68,70,31,183,1,192,153,47,227,128,32,102,57,12,185,84,4,136,114,108,35,26,58,152,113,30,134,46,147,70,159,11,196,114,28,199,6,43,238,4,200,197,158,141,98,143,192,43,240,165,39,45,91,218,22,54,204,84,72,53,122,49,46,69,85,37,69,30,77,196,175,255,71,7,99,200,178,143,189,86,164,117,150,27,102,38,20,221,164,106,47,50,124,183,43,148,34,236,89,28,66,64,205,177,228,1,146,16,35,164,196,149,56,20,134,201,232,88,181,110,13,253,94,95,233,203,102,174,143,245,121,51,55,204,82,72,81,138,156,137,27,181,217,126,44,176,15,105,6,82,56,200,181,189,16,5,156,91,136,6,22,230,174,31,96,206,33,97,78,21,125,66,211,90,116,249,77,18,0,198,78,232,89,196,150,136,8,26,34,87,248,14,0,109,138,66,59,140,37,38,216,145,210,89,118,253,126,81,60,171,199,208,241,106,163,206,68,153,176,235,241,9,152,67,81,70,19,86,228,170,44,210,214,249,198,13,64,63,166,235,195,167,125,107,210,238,164,5,26,83,179,174,196,90,154,136,92,141,114,86,240,36,223,237,38,56,157,2,38,27,211,50,169,150,13,29,237,215,52,133,6,36,187,123,127,109,252,90,93,169,34,251,215,234,53,161,86,112,3,164,237,114,110,57,205,147,106,156,210,131,78,142,140,59,251,117,161,238,234,143,122,209,146,161,153,55,71,3,253,5,88,113,9,236,120,163,79,7,250,71,51,3,170,180,170,175,122,1,162,190,106,14,245,69,123,114,2,6,159,64,156,233,227,1,124,230,250,68,159,130,131,195,254,175,245,0,192,207,250,106,168,63,192,193,172,179,63,27,52,111,91,180,254,222,90,52,243,1,232,79,245,183,230,165,190,104,142,0,184,104,102,205,203,230,93,243,26,180,103,3,125,14,30,46,58,251,243,230,149,94,232,197,240,79,226,246,217,27,183,170,92,86,197,8,142,61,108,73,196,173,208,134,157,0,238,6,49,115,80,136,25,33,92,134,140,57,214,144,130,64,169,203,16,108,79,12,107,105,9,68,49,197,200,15,136,3,155,233,18,230,219,195,85,182,235,58,151,169,249,31,117,120,107,189,122,240,60,95,222,136,61,149,183,135,160,189,165,24,165,34,3,110,2,189,87,24,201,20,0,155,203,112,209,100,149,1,181,144,81,174,18,117,208,223,140,209,100,149,137,77,183,151,51,219,158,194,243,19,67,64,249,153,67,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _addRights;
			public override string AddRights {
				get {
					return _addRights ?? (_addRights = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,109,80,205,110,211,64,16,126,21,203,189,102,35,39,187,222,141,125,45,17,170,132,40,106,37,46,81,14,227,245,44,141,100,59,149,187,1,85,81,164,52,149,144,16,133,71,128,35,215,80,8,164,13,13,175,48,251,70,172,93,78,136,211,206,247,187,154,25,205,143,242,52,76,18,105,50,197,35,214,215,146,51,161,57,103,144,73,205,20,87,130,163,225,154,247,162,176,115,8,213,9,66,158,218,122,134,13,24,230,19,155,26,40,46,90,244,4,11,180,248,23,159,78,103,181,198,52,228,97,231,105,13,149,69,63,15,203,243,98,122,137,24,118,158,67,233,241,232,128,190,208,214,173,104,237,86,238,38,160,239,180,166,7,122,112,239,105,19,208,111,183,164,125,75,253,160,173,135,180,119,87,180,107,148,91,111,248,234,225,146,214,129,127,86,116,75,27,95,112,245,56,53,13,62,248,141,246,93,250,236,133,101,235,191,11,220,135,38,77,191,26,135,91,5,158,223,208,79,119,77,59,119,227,131,91,183,116,215,238,163,123,231,217,187,128,238,125,195,174,245,223,187,183,180,165,109,151,62,253,239,163,166,249,96,28,118,94,66,49,107,23,26,29,93,28,191,169,176,62,213,103,88,194,227,45,198,93,207,254,67,12,11,44,177,178,233,92,43,158,197,60,50,44,143,146,30,19,121,30,177,65,166,251,44,225,90,169,220,36,90,247,163,133,15,188,128,218,223,204,98,157,206,193,75,0,66,179,56,51,25,19,60,66,6,28,56,147,3,213,31,72,35,148,150,189,38,50,172,236,196,94,30,78,139,89,89,165,115,57,16,113,204,65,49,136,147,156,9,105,128,129,17,25,51,90,73,76,12,114,153,136,197,184,89,230,248,28,107,176,147,105,117,50,121,117,102,159,225,107,44,210,176,23,46,198,127,0,108,250,88,50,43,2,0,0 })));
				}
				set {
					_addRights = value;
				}
			}

			internal Func<Guid> _employee1;
			public virtual Guid Employee1 {
				get {
					return (_employee1 ?? (_employee1 = () => Guid.Empty)).Invoke();
				}
				set {
					_employee1 = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		public OpportunityManagementProspecting(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityManagementProspecting";
			SchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f");
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
				return new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: OpportunityManagementProspecting, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: OpportunityManagementProspecting, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid CurrentOpportunity {
			get;
			set;
		}

		public virtual bool OpportunityStageChanged {
			get;
			set;
		}

		public virtual Guid MainContact {
			get;
			set;
		}

		private ProcessSalesManager _salesManager;
		public ProcessSalesManager SalesManager {
			get {
				return _salesManager ?? ((_salesManager) = new ProcessSalesManager(UserConnection, this));
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
					SchemaElementUId = new Guid("80ba5382-aa5f-407f-adb0-a09f93271323"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("0906a331-a59b-4472-bf33-a9c04f38e6f6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private OpenEditPageUserTask1FlowElement _openEditPageUserTask1;
		public OpenEditPageUserTask1FlowElement OpenEditPageUserTask1 {
			get {
				return _openEditPageUserTask1 ?? (_openEditPageUserTask1 = new OpenEditPageUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataUserTask1FlowElement _readDataUserTask1;
		public ReadDataUserTask1FlowElement ReadDataUserTask1 {
			get {
				return _readDataUserTask1 ?? (_readDataUserTask1 = new ReadDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeAdminRightsUserTask1FlowElement _changeAdminRightsUserTask1;
		public ChangeAdminRightsUserTask1FlowElement ChangeAdminRightsUserTask1 {
			get {
				return _changeAdminRightsUserTask1 ?? (_changeAdminRightsUserTask1 = new ChangeAdminRightsUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeAdminRightsUserTask2FlowElement _changeAdminRightsUserTask2;
		public ChangeAdminRightsUserTask2FlowElement ChangeAdminRightsUserTask2 {
			get {
				return _changeAdminRightsUserTask2 ?? (_changeAdminRightsUserTask2 = new ChangeAdminRightsUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private IntermediateCatchSignalEvent1FlowElement _intermediateCatchSignalEvent1;
		public IntermediateCatchSignalEvent1FlowElement IntermediateCatchSignalEvent1 {
			get {
				return _intermediateCatchSignalEvent1 ?? ((_intermediateCatchSignalEvent1) = new IntermediateCatchSignalEvent1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("4529baea-eac0-49a9-818f-ed63ef212d92"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask1Execute,
				});
			}
		}

		private ReadDataUserTask2FlowElement _readDataUserTask2;
		public ReadDataUserTask2FlowElement ReadDataUserTask2 {
			get {
				return _readDataUserTask2 ?? (_readDataUserTask2 = new ReadDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("5a3a044f-4e7d-4766-b31d-7faa8b9908e8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ReadDataUserTask3FlowElement _readDataUserTask3;
		public ReadDataUserTask3FlowElement ReadDataUserTask3 {
			get {
				return _readDataUserTask3 ?? (_readDataUserTask3 = new ReadDataUserTask3FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataUserTask4FlowElement _readDataUserTask4;
		public ReadDataUserTask4FlowElement ReadDataUserTask4 {
			get {
				return _readDataUserTask4 ?? (_readDataUserTask4 = new ReadDataUserTask4FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("90929524-44b3-4698-8b37-0a5c654d1461"),
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
					SchemaElementUId = new Guid("1915b8b9-69de-4118-8fd3-21a88fdd3097"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask3Execute,
				});
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
					SchemaElementUId = new Guid("b0b23273-c3ed-47d0-bab7-c44b1459da2c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("9e7139c8-194f-4683-8e84-ae27396bdfa7"),
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

		private ChangeAdminRightsUserTask3FlowElement _changeAdminRightsUserTask3;
		public ChangeAdminRightsUserTask3FlowElement ChangeAdminRightsUserTask3 {
			get {
				return _changeAdminRightsUserTask3 ?? (_changeAdminRightsUserTask3 = new ChangeAdminRightsUserTask3FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeAdminRightsUserTask4FlowElement _changeAdminRightsUserTask4;
		public ChangeAdminRightsUserTask4FlowElement ChangeAdminRightsUserTask4 {
			get {
				return _changeAdminRightsUserTask4 ?? (_changeAdminRightsUserTask4 = new ChangeAdminRightsUserTask4FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("6abb8a1d-d77d-4d5d-9a41-f39f1512025d"),
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
					SchemaElementUId = new Guid("47c8f086-6221-4fdc-abce-6709e2e61ead"),
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
					SchemaElementUId = new Guid("3351d977-0f52-4d7f-8471-7f0b417a163a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow4;
		public ProcessConditionalFlow ConditionalFlow4 {
			get {
				return _conditionalFlow4 ?? (_conditionalFlow4 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow4",
					SchemaElementUId = new Guid("4476647f-b722-42dd-ac2f-219a0e5e87de"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow5;
		public ProcessConditionalFlow ConditionalFlow5 {
			get {
				return _conditionalFlow5 ?? (_conditionalFlow5 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow5",
					SchemaElementUId = new Guid("ea08f07d-eb4d-48f3-a091-6ee9d8a32153"),
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
			FlowElements[OpenEditPageUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenEditPageUserTask1 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[ChangeAdminRightsUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeAdminRightsUserTask1 };
			FlowElements[ChangeAdminRightsUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeAdminRightsUserTask2 };
			FlowElements[IntermediateCatchSignalEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateCatchSignalEvent1 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
			FlowElements[Terminate2.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate2 };
			FlowElements[ReadDataUserTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask3 };
			FlowElements[ReadDataUserTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask4 };
			FlowElements[FormulaTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask2 };
			FlowElements[FormulaTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask3 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ChangeAdminRightsUserTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeAdminRightsUserTask3 };
			FlowElements[ChangeAdminRightsUserTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeAdminRightsUserTask4 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("IntermediateCatchSignalEvent1", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "OpenEditPageUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask4", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask3", e.Context.SenderName));
						break;
					case "ChangeAdminRightsUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeAdminRightsUserTask2", e.Context.SenderName));
						break;
					case "ChangeAdminRightsUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "IntermediateCatchSignalEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "Terminate2":
						CompleteProcess();
						break;
					case "ReadDataUserTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask2", e.Context.SenderName));
						break;
					case "ReadDataUserTask4":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask3", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask3", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "ReadDataUserTask4");
						break;
					case "FormulaTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenEditPageUserTask1", e.Context.SenderName));
						break;
					case "FormulaTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenEditPageUserTask1", e.Context.SenderName));
						break;
					case "ScriptTask1":
						if (ConditionalFlow4ExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "ScriptTask1");
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow5ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeAdminRightsUserTask3", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeAdminRightsUserTask1", e.Context.SenderName));
						break;
					case "ChangeAdminRightsUserTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeAdminRightsUserTask4", e.Context.SenderName));
						break;
					case "ChangeAdminRightsUserTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((ReadDataUserTask4.ResultCount) > 0);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask4", "ConditionalFlow1", "(ReadDataUserTask4.ResultCount) > 0", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((ReadDataUserTask4.ResultCount) == 0);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask4", "ConditionalFlow2", "(ReadDataUserTask4.ResultCount) == 0", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("ResponsibleDepartment").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("ResponsibleDepartmentId") : Guid.Empty)) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask1", "ConditionalFlow3", "((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName(\"ResponsibleDepartment\").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>(\"ResponsibleDepartmentId\") : Guid.Empty)) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlow4ExpressionExecute() {
			bool result = Convert.ToBoolean(true);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ScriptTask1", "ConditionalFlow4", "true", result);
			return result;
		}

		private bool ConditionalFlow5ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<Guid>("AccountId") : Guid.Empty)) == Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow5", "((ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName(\"Account\").ColumnValueName) ? ReadDataUserTask2.ResultEntity.GetTypedColumnValue<Guid>(\"AccountId\") : Guid.Empty)) == Guid.Empty", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("ChangeAdminRightsUserTask1.Employee1")) {
				writer.WriteValue("ChangeAdminRightsUserTask1.Employee1", ChangeAdminRightsUserTask1.Employee1, Guid.Empty);
			}
			if (!HasMapping("ChangeAdminRightsUserTask2.Employee1")) {
				writer.WriteValue("ChangeAdminRightsUserTask2.Employee1", ChangeAdminRightsUserTask2.Employee1, Guid.Empty);
			}
			if (!HasMapping("ChangeAdminRightsUserTask3.Employee1")) {
				writer.WriteValue("ChangeAdminRightsUserTask3.Employee1", ChangeAdminRightsUserTask3.Employee1, Guid.Empty);
			}
			if (!HasMapping("ChangeAdminRightsUserTask4.Employee1")) {
				writer.WriteValue("ChangeAdminRightsUserTask4.Employee1", ChangeAdminRightsUserTask4.Employee1, Guid.Empty);
			}
			if (!HasMapping("CurrentOpportunity")) {
				writer.WriteValue("CurrentOpportunity", CurrentOpportunity, Guid.Empty);
			}
			if (!HasMapping("MainContact")) {
				writer.WriteValue("MainContact", MainContact, Guid.Empty);
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
			MetaPathParameterValues.Add("4c6e9a6c-52a3-4f25-879f-96941c1aa349", () => CurrentOpportunity);
			MetaPathParameterValues.Add("0bd1bc47-97dc-487d-b8b8-e5bd0a629ed8", () => OpportunityStageChanged);
			MetaPathParameterValues.Add("83114e9e-fb66-424f-a1a6-d23fb5945480", () => MainContact);
			MetaPathParameterValues.Add("ae7d9be8-2794-4f16-9a39-ccf50ecdba24", () => OpenEditPageUserTask1.ObjectSchemaId);
			MetaPathParameterValues.Add("db76b6e1-5420-4968-9631-759ba37819e2", () => OpenEditPageUserTask1.PageSchemaId);
			MetaPathParameterValues.Add("6efa15b1-5137-45fa-809e-79bb3db89358", () => OpenEditPageUserTask1.EditMode);
			MetaPathParameterValues.Add("9324bb9c-5017-411c-b5a5-fb117947ef43", () => OpenEditPageUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("f271250b-3c06-467b-b95f-c2d2e9c3019c", () => OpenEditPageUserTask1.RecordId);
			MetaPathParameterValues.Add("dbb47148-8d67-4fe3-825b-477f8d55c92b", () => OpenEditPageUserTask1.ExecutedMode);
			MetaPathParameterValues.Add("701175ea-0e46-4f61-938b-eedf9af21920", () => OpenEditPageUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("540b1d28-96f8-4793-b6dc-f222c6d4efbd", () => OpenEditPageUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("8a056fe6-95e1-4710-b4ff-d50ef63e2916", () => OpenEditPageUserTask1.GenerateDecisionsFromColumn);
			MetaPathParameterValues.Add("e842c411-a194-41b8-8520-bc517224cd01", () => OpenEditPageUserTask1.DecisionalColumnMetaPath);
			MetaPathParameterValues.Add("d6313c1e-3152-439f-88a5-ca4f5b397ee8", () => OpenEditPageUserTask1.ResultParameter);
			MetaPathParameterValues.Add("ed2ab973-7009-4a0c-bc37-6e4eaa3450bd", () => OpenEditPageUserTask1.IsReexecution);
			MetaPathParameterValues.Add("5f81e72e-7cb6-4775-b4ef-709235e30ef2", () => OpenEditPageUserTask1.Recommendation);
			MetaPathParameterValues.Add("e825034b-3779-4c1e-aa88-08a25cddf922", () => OpenEditPageUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("79b71a16-363b-4270-804f-96c0266a9226", () => OpenEditPageUserTask1.OwnerId);
			MetaPathParameterValues.Add("49fc1967-693a-4c7c-a90b-ff57e9609483", () => OpenEditPageUserTask1.Duration);
			MetaPathParameterValues.Add("15acbe32-9e04-4bda-813f-0dbf7140366e", () => OpenEditPageUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("fac6a98d-6e1f-4791-90ff-6388fd5c7dfa", () => OpenEditPageUserTask1.StartIn);
			MetaPathParameterValues.Add("52348b4d-d057-423b-bbd2-b27ffdcb31b7", () => OpenEditPageUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("ac12bebe-1559-4b69-be65-0ec920c26ed8", () => OpenEditPageUserTask1.RemindBefore);
			MetaPathParameterValues.Add("1163d8da-f734-4ad7-824c-da7bd888483c", () => OpenEditPageUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("09e933cd-ec8e-464b-aa57-a0653129c148", () => OpenEditPageUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("e108111b-f473-4ec3-ac71-171a7e932396", () => OpenEditPageUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("c5cbdcb1-8456-4d6c-a2a3-efde611f3db8", () => OpenEditPageUserTask1.Lead);
			MetaPathParameterValues.Add("8727b23d-8ab9-43de-adcf-b6411baf04bf", () => OpenEditPageUserTask1.Account);
			MetaPathParameterValues.Add("701b6be8-7bde-4ddc-a8ea-05d5e3a6f32b", () => OpenEditPageUserTask1.Contact);
			MetaPathParameterValues.Add("070365fb-e8d5-49f1-a71d-933a82563693", () => OpenEditPageUserTask1.Opportunity);
			MetaPathParameterValues.Add("798646c0-f074-4300-a2d7-73558f4302b8", () => OpenEditPageUserTask1.Invoice);
			MetaPathParameterValues.Add("97e1828c-89e8-4b30-a736-129257a18787", () => OpenEditPageUserTask1.Document);
			MetaPathParameterValues.Add("dc76bc3f-26e8-4e12-99eb-06875b580140", () => OpenEditPageUserTask1.Incident);
			MetaPathParameterValues.Add("10863539-42e3-4ec9-a0e1-93835649f96f", () => OpenEditPageUserTask1.Case);
			MetaPathParameterValues.Add("ed45b44a-4ef2-4090-a7d6-d660ff6794df", () => OpenEditPageUserTask1.ActivityResult);
			MetaPathParameterValues.Add("4dddec06-0b54-4279-b578-5adbd29937de", () => OpenEditPageUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("9dea1cae-603b-480e-91b9-2cedc8043fe3", () => OpenEditPageUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("396ca1cb-2a2c-47c0-9bce-7f8d32e2948e", () => OpenEditPageUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("d8194d6c-dcc9-4b4e-a9d6-3d49314e8e98", () => OpenEditPageUserTask1.PageTypeUId);
			MetaPathParameterValues.Add("0c84cdb3-00ef-43ef-8ec5-929ab4936120", () => OpenEditPageUserTask1.ActivitySchemaUId);
			MetaPathParameterValues.Add("265cd111-1e70-4cac-83ae-bf14d2756bb9", () => OpenEditPageUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("2d1fa997-5890-44a6-8b5f-864795599deb", () => OpenEditPageUserTask1.Order);
			MetaPathParameterValues.Add("69814e7a-c257-4df5-bec5-ce4565034b2d", () => OpenEditPageUserTask1.Requests);
			MetaPathParameterValues.Add("862b6225-5967-4969-9fd9-8c8e79df20c0", () => OpenEditPageUserTask1.Listing);
			MetaPathParameterValues.Add("ead44738-c37f-4ac5-b25e-4cbcd2ae893b", () => OpenEditPageUserTask1.Property);
			MetaPathParameterValues.Add("b0849d2a-bce7-43f8-beb1-fa2c375357ac", () => OpenEditPageUserTask1.Contract);
			MetaPathParameterValues.Add("d7450c11-e4da-4c5a-96e1-fbcb7ea94867", () => OpenEditPageUserTask1.Problem);
			MetaPathParameterValues.Add("c54f578d-a593-499f-a846-b08a7bd3ca7b", () => OpenEditPageUserTask1.Change);
			MetaPathParameterValues.Add("40753f3d-3149-4919-9649-169e2c608b25", () => OpenEditPageUserTask1.Release);
			MetaPathParameterValues.Add("54a12540-bcb5-4fb7-b795-3cc857cd0d72", () => OpenEditPageUserTask1.Project);
			MetaPathParameterValues.Add("43a7025f-f4e3-4c4a-97d2-432e99f32840", () => OpenEditPageUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("60b6c6a3-3e7f-4b68-8cab-362be6a4d16a", () => OpenEditPageUserTask1.CreateActivity);
			MetaPathParameterValues.Add("6f986137-04cb-4983-b7b0-54ae0cf8a109", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("9ead078e-f887-43ca-a04e-d8ce3a1ce902", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("3f155961-0b7c-488a-ad58-3d3edf964358", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("97f729d1-9c97-41b7-807b-90a33d51655e", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("36f4066e-90fc-4fdb-9746-c383e7463ec7", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("05e54116-4bc1-4945-ba99-e9e2dc05d937", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("e6227e17-dc85-4e02-837c-e9990987d128", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("40333f27-6073-4fdf-8195-0a76448c3050", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("0bfa05ed-5c32-4321-830d-fdf5729623fc", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("7072dcc2-6391-4ac4-90c5-03e41d350032", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("158d4a9d-89ef-4cff-94d2-a1d2c46119d9", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("5c5148f8-73c6-4e66-9f88-0776da38ac4a", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("5306de25-557e-4d14-ab0d-61ef40ef14f7", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("7088c4df-1695-4ef3-bc05-566678b8b453", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("51c42171-ea97-42a6-86d6-748585c8132e", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("225571a2-2754-47d9-8903-bcf25cb22132", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("ac7c66ef-d757-43a3-b7c8-3172e4cf1bf7", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("871dd3a4-acb8-4449-a993-dc43792a5fb9", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("77dcb533-0081-4f70-894c-b35e0c724c1f", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("c0fec3ae-801f-45d1-9ef1-f5d96f2e507e", () => ChangeAdminRightsUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("219973db-f3e9-415f-9801-d02ea613c197", () => ChangeAdminRightsUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("bc07c289-1319-4c29-92d4-aebdf026812e", () => ChangeAdminRightsUserTask1.DeleteRights);
			MetaPathParameterValues.Add("d3292ff8-7bbd-45cb-a9ee-cb83ff795d43", () => ChangeAdminRightsUserTask1.AddRights);
			MetaPathParameterValues.Add("cb97cbfa-8808-4c7f-bb23-d492c52addfa", () => ChangeAdminRightsUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("dbe40eec-c9dc-429e-ac14-9fa16d721d13", () => ChangeAdminRightsUserTask1.Employee1);
			MetaPathParameterValues.Add("4e965dc3-d0a7-4e19-90e1-c7cbf2fc0ab5", () => ChangeAdminRightsUserTask2.EntitySchemaUId);
			MetaPathParameterValues.Add("f82856dc-9a64-4a0c-9fb8-9535d9d36049", () => ChangeAdminRightsUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("1231ae80-ee39-4ea7-b240-5e40eeb4c9d1", () => ChangeAdminRightsUserTask2.DeleteRights);
			MetaPathParameterValues.Add("53a4af30-14e3-43b5-8ef1-88f2cf3a040f", () => ChangeAdminRightsUserTask2.AddRights);
			MetaPathParameterValues.Add("78cc3f50-c40f-4cfa-9481-79259b9ce64b", () => ChangeAdminRightsUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("cca8554b-caff-492a-969a-6897ff936478", () => ChangeAdminRightsUserTask2.Employee1);
			MetaPathParameterValues.Add("09cca40d-6c18-48f7-9457-13734419af29", () => IntermediateCatchSignalEvent1.RecordId);
			MetaPathParameterValues.Add("6ae9a99b-d2db-4a58-b211-f6e962641886", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("8f241b16-53a3-4a3f-bca5-3fb01c76cdd9", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("feb5fafe-ddb7-4fe9-b154-6aef4a84a2cf", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("dee4a26d-9bf8-4814-aeaa-2079ae11751d", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("b36aaeec-e9e9-4b97-83b4-c930ade9d221", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("93823506-41d3-455a-be79-cd11bd04d813", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("6f281dc6-1639-492d-b3a7-91eea3ca365f", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("a3c7aa4c-5bfb-430e-a3a3-687286f47c61", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("08fb2ebc-49a5-4226-98ba-39f6038c9c60", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("1fb6d738-110a-43fc-b8d1-6ad1b87f1781", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("f96019c2-3d7b-4c65-af7c-00f7360fdef1", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("607243ca-d4f9-4326-ba0d-63444eb5120f", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("5eef0b4b-0874-4d83-bc5e-5cd3703dc83e", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("960b87b1-7cf1-4c07-9505-dcda4ff83c63", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("32c63487-e6c1-47ec-90de-78ac92f5bc30", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("8633d044-d682-4d53-abc5-2ebe81cc2939", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("a147c744-f32b-48b9-a6b4-71a9270154db", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("e9467ebf-a34b-47f7-b8bd-c50966de3734", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("6981ba7b-3378-488d-9bc5-36c590b26b7f", () => ReadDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("113f4e62-765c-44d4-8ae1-58cf9d82d61f", () => ReadDataUserTask3.DataSourceFilters);
			MetaPathParameterValues.Add("081ada6f-f2ec-42a9-9282-5b3d9c407f55", () => ReadDataUserTask3.ResultType);
			MetaPathParameterValues.Add("50975cf4-f986-42be-848f-f2dbab118fa5", () => ReadDataUserTask3.ReadSomeTopRecords);
			MetaPathParameterValues.Add("8e5ac671-36f1-474e-9cff-66a8407b8fa5", () => ReadDataUserTask3.NumberOfRecords);
			MetaPathParameterValues.Add("e0169671-eb4f-4762-b6a3-191c60062fb3", () => ReadDataUserTask3.FunctionType);
			MetaPathParameterValues.Add("19d5393e-631c-4edd-b20b-b75111f8c70b", () => ReadDataUserTask3.AggregationColumnName);
			MetaPathParameterValues.Add("0498e93f-e38c-409f-a4b4-8d6ca4869331", () => ReadDataUserTask3.OrderInfo);
			MetaPathParameterValues.Add("b2e51ef1-6aab-4ca1-8848-6008a8d519a5", () => ReadDataUserTask3.ResultEntity);
			MetaPathParameterValues.Add("1e00e7f8-aeee-4b21-a00c-23045ba60e93", () => ReadDataUserTask3.ResultCount);
			MetaPathParameterValues.Add("bf8fa2bb-6f13-45d3-8ac3-1af8add4e2e1", () => ReadDataUserTask3.ResultIntegerFunction);
			MetaPathParameterValues.Add("b11bba9c-7570-4c91-b5b8-ce0f87f32de9", () => ReadDataUserTask3.ResultFloatFunction);
			MetaPathParameterValues.Add("3f45a94b-9b1a-45bc-a1eb-1c63396fd296", () => ReadDataUserTask3.ResultDateTimeFunction);
			MetaPathParameterValues.Add("65beb8a8-7a77-4d89-b41a-5e90a25bf16f", () => ReadDataUserTask3.ResultRowsCount);
			MetaPathParameterValues.Add("70f9d4af-0491-4dd3-bc7e-64f44d775fc3", () => ReadDataUserTask3.CanReadUncommitedData);
			MetaPathParameterValues.Add("02165bd8-27fb-4e68-8dbc-6910d0dd6351", () => ReadDataUserTask3.ResultEntityCollection);
			MetaPathParameterValues.Add("c018b09d-9be8-4dc0-94a3-6a98bb7f7223", () => ReadDataUserTask3.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("b90f88bb-6a42-491a-b18c-602ac3087bbb", () => ReadDataUserTask3.IgnoreDisplayValues);
			MetaPathParameterValues.Add("ca815e4f-a340-47cc-86d2-101fdc98f3db", () => ReadDataUserTask3.ResultCompositeObjectList);
			MetaPathParameterValues.Add("5c02e1cd-d7ab-4435-8468-889e8961de88", () => ReadDataUserTask3.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("a20fbdf2-0724-4878-885a-78691620252b", () => ReadDataUserTask4.DataSourceFilters);
			MetaPathParameterValues.Add("27339781-38b3-4487-9014-db0a37f14b83", () => ReadDataUserTask4.ResultType);
			MetaPathParameterValues.Add("4521de8c-08bc-444c-b658-6c4d2a4e5fe3", () => ReadDataUserTask4.ReadSomeTopRecords);
			MetaPathParameterValues.Add("7d343aa0-5460-4284-979f-8f5994a7d42b", () => ReadDataUserTask4.NumberOfRecords);
			MetaPathParameterValues.Add("e1b48494-ddbb-473b-a958-1051eee1f98a", () => ReadDataUserTask4.FunctionType);
			MetaPathParameterValues.Add("70780388-abf3-42af-893d-f28adb4649e9", () => ReadDataUserTask4.AggregationColumnName);
			MetaPathParameterValues.Add("aec5d8f1-c2e7-4e32-a7c0-04acfef39267", () => ReadDataUserTask4.OrderInfo);
			MetaPathParameterValues.Add("bee4631c-fc60-4367-b698-697143c1db86", () => ReadDataUserTask4.ResultEntity);
			MetaPathParameterValues.Add("a3bc60f3-2c39-4535-b598-fbd578d70e3e", () => ReadDataUserTask4.ResultCount);
			MetaPathParameterValues.Add("abc3c14b-0934-40d2-bbe4-d7850d2fbf68", () => ReadDataUserTask4.ResultIntegerFunction);
			MetaPathParameterValues.Add("769bd711-c503-449a-b51c-4a46a32185a4", () => ReadDataUserTask4.ResultFloatFunction);
			MetaPathParameterValues.Add("3f93d92a-65c1-4d5d-a345-d590032b6d6f", () => ReadDataUserTask4.ResultDateTimeFunction);
			MetaPathParameterValues.Add("4c78f474-685f-4529-81f4-9021f679a821", () => ReadDataUserTask4.ResultRowsCount);
			MetaPathParameterValues.Add("092e4b03-f419-48ef-a4be-8468d71225ed", () => ReadDataUserTask4.CanReadUncommitedData);
			MetaPathParameterValues.Add("e799395e-b3b7-458a-83af-8462a0ee992e", () => ReadDataUserTask4.ResultEntityCollection);
			MetaPathParameterValues.Add("5e3110b5-1123-4cb7-b152-accafabe8138", () => ReadDataUserTask4.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("3dd48f20-8cf8-49bb-802a-23fa55d6001d", () => ReadDataUserTask4.IgnoreDisplayValues);
			MetaPathParameterValues.Add("0ff80e34-e72a-4579-be2d-eca0480b8ab0", () => ReadDataUserTask4.ResultCompositeObjectList);
			MetaPathParameterValues.Add("d7fc461a-30e7-48fe-ae22-a0dfd9543c3b", () => ReadDataUserTask4.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("e7f3928e-a4d5-465d-bbc7-a71f81fc3a25", () => ChangeAdminRightsUserTask3.EntitySchemaUId);
			MetaPathParameterValues.Add("5a649550-03e1-4b0f-bc8c-d2de65fc0b09", () => ChangeAdminRightsUserTask3.DataSourceFilters);
			MetaPathParameterValues.Add("d450dd6d-3502-4a49-93dc-3796f8d6b862", () => ChangeAdminRightsUserTask3.DeleteRights);
			MetaPathParameterValues.Add("c573582f-cae6-4f5d-9f77-cddaff23070d", () => ChangeAdminRightsUserTask3.AddRights);
			MetaPathParameterValues.Add("742b13f0-5019-4828-a783-95cecd4e7e00", () => ChangeAdminRightsUserTask3.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("03b2071a-f297-4da2-94d0-c7adea6c61ea", () => ChangeAdminRightsUserTask3.Employee1);
			MetaPathParameterValues.Add("c2fd6fee-f1c7-45e7-ac9a-c1ab494df220", () => ChangeAdminRightsUserTask4.EntitySchemaUId);
			MetaPathParameterValues.Add("b7a5464f-131b-4b4c-8a32-1f2138329f44", () => ChangeAdminRightsUserTask4.DataSourceFilters);
			MetaPathParameterValues.Add("310641c2-c313-4ca7-9003-58bb95ba5d84", () => ChangeAdminRightsUserTask4.DeleteRights);
			MetaPathParameterValues.Add("0f101973-6976-4c62-8342-e1c9f265457a", () => ChangeAdminRightsUserTask4.AddRights);
			MetaPathParameterValues.Add("c58716e7-0cac-4344-8f1b-9512a93cc454", () => ChangeAdminRightsUserTask4.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("996fb730-2c63-4c33-ab6c-73743ef3c310", () => ChangeAdminRightsUserTask4.Employee1);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "ChangeAdminRightsUserTask1.Employee1":
					ChangeAdminRightsUserTask1.Employee1 = reader.GetValue<System.Guid>();
				break;
				case "ChangeAdminRightsUserTask2.Employee1":
					ChangeAdminRightsUserTask2.Employee1 = reader.GetValue<System.Guid>();
				break;
				case "ChangeAdminRightsUserTask3.Employee1":
					ChangeAdminRightsUserTask3.Employee1 = reader.GetValue<System.Guid>();
				break;
				case "ChangeAdminRightsUserTask4.Employee1":
					ChangeAdminRightsUserTask4.Employee1 = reader.GetValue<System.Guid>();
				break;
				case "CurrentOpportunity":
					if (!hasValueToRead) break;
					CurrentOpportunity = reader.GetValue<System.Guid>();
				break;
				case "MainContact":
					if (!hasValueToRead) break;
					MainContact = reader.GetValue<System.Guid>();
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
			var localOpportunityStageChanged = true;
			OpportunityStageChanged = (System.Boolean)localOpportunityStageChanged;
			return true;
		}

		public virtual bool FormulaTask2Execute(ProcessExecutingContext context) {
			var localOpenEditPageUserTask1_OwnerId = ((ReadDataUserTask3.ResultEntity.IsColumnValueLoaded(ReadDataUserTask3.ResultEntity.Schema.Columns.GetByName("SalesDirector").ColumnValueName) ? ReadDataUserTask3.ResultEntity.GetTypedColumnValue<Guid>("SalesDirectorId") : Guid.Empty));
			OpenEditPageUserTask1.OwnerId = (System.Guid)localOpenEditPageUserTask1_OwnerId;
			return true;
		}

		public virtual bool FormulaTask3Execute(ProcessExecutingContext context) {
			var localOpenEditPageUserTask1_OwnerId = ((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentUserContact"));
			OpenEditPageUserTask1.OwnerId = (System.Guid)localOpenEditPageUserTask1_OwnerId;
			return true;
		}

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			return this.ReadDataUserTask2.ResultEntityCollection.Count == 0;
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
			var cloneItem = (OpportunityManagementProspecting)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

